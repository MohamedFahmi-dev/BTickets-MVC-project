using BTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BTickets.Data.Carts
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetCart(AppDbContext context, string cartId)
        {
            var cart = new ShoppingCart(context);
            cart.ShoppingCartId = cartId ?? Guid.NewGuid().ToString();
            return cart;
        }
        public void AddToCart(Movie movie)
        {
            var add = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (add == null)
            {
                var newItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1,
                    MovieId = movie.Id
                };
                _context.ShoppingCartItems.Add(newItem);
            }
            else
            {
                add.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveFromCart(Movie movie)
        {
            var remove = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (remove != null)
            {
                if (remove.Amount > 1)
                {
                    remove.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(remove);
                }
                _context.SaveChanges();
            }
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            var ShoppingCartItems = _context.ShoppingCartItems
                .Include(x => x.Movie)
                .ThenInclude(m => m.Cinema)
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .ToList();
            return ShoppingCartItems;
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();
            return total;
        }
        public async Task ClearCart()
        {
            var cartItems = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }
    }


}
