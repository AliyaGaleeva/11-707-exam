﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db;

        public HomeController(DataBaseContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Restaurant.ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
