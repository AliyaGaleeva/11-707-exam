using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public Restaurant Restaurant { get; set; }

        public int RestaurantID { get; set; }

        public int DishID { get; set; }

        public Dish Dish { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}
