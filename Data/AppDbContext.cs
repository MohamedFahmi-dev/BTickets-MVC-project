using BTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            Seeding.Seed(modelBuilder);
            modelBuilder.Entity<Actors_Movies>().HasKey(k => new { k.movieId, k.ActorId });
            modelBuilder.Entity<Actors_Movies>().HasOne(o => o.movie).WithMany(m => m.actors_Movies).HasForeignKey(k => k.movieId);
            modelBuilder.Entity<Actors_Movies>().HasOne(o => o.Actor).WithMany(m => m.actors_Movies).HasForeignKey(k => k.ActorId);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actors_Movies> Actors_Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
