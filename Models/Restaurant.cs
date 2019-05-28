using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        

        public Restaurant()
        {
            Dishes = new List<Dish>();
        }

        public ICollection<Dish> Dishes { get; set; }
    }
}
