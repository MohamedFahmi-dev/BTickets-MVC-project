using BTickets.Models;

namespace BTickets.Interfaces
{
    public interface IOrdersRepo : IGenericRepository<Order>
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddres);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
