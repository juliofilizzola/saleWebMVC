using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleWebMVC2.Models;

namespace SaleWebMVC2.Data
{
    public class SaleWebMVC2Context : DbContext
    {
        public SaleWebMVC2Context (DbContextOptions<SaleWebMVC2Context> options)
            : base(options)
        {
        }

        public DbSet<SaleWebMVC2.Models.Department> Department { get; set; } = default!;
    }
}
