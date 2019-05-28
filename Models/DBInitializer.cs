using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class DBInitializer
    {
        public static void Initialize(DataBaseContext context)
        {
            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer
                    {
                        FirstName = "admin",
                        Role = "admin"

                    });
            }
        }
    }
}
