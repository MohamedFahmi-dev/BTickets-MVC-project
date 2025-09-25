using BTickets.Data;
using BTickets.Interfaces;
using BTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrdersRepo
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var order = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();
            if (userRole != "Admin")
            {
                order = order.Where(n => n.UserId == userId).ToList();
            }
            return order;


        }

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.MovieId,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                _context.OrderItems.Add(orderItem);
            }
            return _context.SaveChangesAsync();
        }
    }
}
