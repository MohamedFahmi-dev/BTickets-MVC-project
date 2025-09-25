using BTickets.Data.Carts;
using BTickets.Interfaces;
using BTickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BTickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork, ShoppingCart shoppingCart)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
        }
        public async Task<IActionResult> Index()
        {
            var Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _unitOfWork.OrderRepository.GetOrdersByUserIdAndRoleAsync(Userid, UserRole);
            ViewBag.CartCount = _shoppingCart.GetShoppingCartItems().Count;

            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = item;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _unitOfWork.OrderRepository.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearCart();

            return View("OrderCompleted");
        }
    }
}
