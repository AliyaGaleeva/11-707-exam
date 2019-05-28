using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public int DishID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual Order Order { get; set; }
    }
}
