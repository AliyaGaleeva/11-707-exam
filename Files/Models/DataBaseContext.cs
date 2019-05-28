using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Files.Models
{
    public class DataBaseContext:DbContext
    {
        public DbSet<File> Files { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> context) : base(context)
        {

        }
    }
}
