using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class ShoppingCartController
    {
        private readonly Models.Restaurant restaurant;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(Models.Restaurant restaurant, ShoppingCart shoppingCart)
        {
            this.restaurant = restaurant;
            this.shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var selected = restaurant.Dishes.FirstOrDefault(p => p.DishID == id);
            if (selected != null)
            {
                shoppingCart.AddToCart(selected, restaurant, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var selected = restaurant.Dishes.FirstOrDefault(p => p.DishID == id);
            if (selected != null)
            {
                shoppingCart.RemoveFromCart(selected);
            }
            return RedirectToAction("Index");
        }
    }
}
