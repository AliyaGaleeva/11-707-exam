using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Files.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using File = Files.Models.File;

namespace Files.Controllers
{
    public class HomeController : Controller
    {
            DataBaseContext _context;
            IHostingEnvironment _appEnvironment;

            public HomeController(DataBaseContext context, IHostingEnvironment appEnvironment)
            {
                _context = context;
                _appEnvironment = appEnvironment;
            }

            public IActionResult Index()
            {
                return View(_context.Files.ToList());
            }

            

            [HttpPost]
            public async Task<IActionResult> AddFile(IFormFile uploadedFile, string lD, string sD)
            {
                if (uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "/Files/" + uploadedFile.Name;

                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    File file = new File { Name = uploadedFile.FileName, Path = path, LongDescription=lD, ShortDescription = sD };
                    _context.Files.Add(file);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");
            }       
    }
} 

