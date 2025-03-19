using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace BakeryCoreMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public IActionResult Index()
        {
            // Retrieve the cart from session or create a new one if null
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        // POST: Add to cart
        [HttpPost]
        public IActionResult AddToCart(int id, string name, decimal price)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            cart.Add(new CartItem { Id = id, Name = name, Price = price });

            // Store the updated cart back into session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true });
        }

        // POST: Clear Cart
        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart"); // Remove the cart from session
            return Json(new { success = true });
        }
    }

    // CartItem model
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Extension methods to make working with session easier
    public static class SessionExtensions
    {
        // Convert object to JSON and store it in session
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Retrieve object from session and deserialize it
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
