using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }

        public Dish()
        {
            Restaurants = new List<Restaurant>();
        }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
