using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class ShoppingCart
    {
        private readonly DataBaseContext context;

        private ShoppingCart(DataBaseContext context)
        {
            this.context = context;
        }

        [Key]
        public string Id { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var contextDb = services.GetService<DataBaseContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(contextDb) { Id = cartId };
        }

        public void AddToCart(Dish dish, Restaurant restaurant, int amount)
        {
            var shoppingCartItem =
                    context.ShoppingCartItems.SingleOrDefault(
                        s => s.Dish.DishID == dish.DishID && s.ShoppingCartId == Id && s.Restaurant.RestaurantID == restaurant.RestaurantID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    ShoppingCart = context.ShoppingCart.Any(x => x.Id == Id) ? context.ShoppingCart.First(x => x.Id == Id) : this,
                    RestaurantID = restaurant.RestaurantID,
                    Restaurant = restaurant,
                    DishID = dish.DishID,
                    Dish = dish,
                    Amount = 1
                };

                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public int RemoveFromCart(Dish dish)
        {
            var shoppingCartItem =
                    context.ShoppingCartItems.SingleOrDefault(
                        s => s.Dish.DishID == dish.DishID && s.ShoppingCartId == Id);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == Id);

            context.ShoppingCartItems.RemoveRange(cartItems);

            context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Dish.Price * c.Amount).Sum();
            return total;
        }

    }
}
