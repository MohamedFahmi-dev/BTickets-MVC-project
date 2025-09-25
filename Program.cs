using BTickets.Data;
using BTickets.Data.Carts;
using BTickets.Interfaces;
using BTickets.Models;
using BTickets.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BTickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();

            // Add session support
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ShoppingCart>(sp =>
            {
                var context = sp.GetRequiredService<AppDbContext>();
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                var cartId = GetCartId(httpContextAccessor.HttpContext);
                return ShoppingCart.GetCart(context, cartId);
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static string GetCartId(HttpContext httpContext)
        {
            if (httpContext?.Session != null)
            {
                var cartId = httpContext.Session.GetString("CartId");
                if (string.IsNullOrEmpty(cartId))
                {
                    cartId = Guid.NewGuid().ToString();
                    httpContext.Session.SetString("CartId", cartId);
                }
                return cartId;
            }
            return Guid.NewGuid().ToString();
        }
    }
}
