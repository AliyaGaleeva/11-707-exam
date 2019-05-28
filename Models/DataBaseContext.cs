using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class DataBaseContext: IdentityDbContext<IdentityUser>
    {
        public IConfiguration Configuration { get; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }


        //Если база данных уже есть, то ничего не происходит.
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

    }
}

