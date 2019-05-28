using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
