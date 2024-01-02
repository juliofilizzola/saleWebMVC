using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Models;

namespace SaleWebMVC.Data
{
    public class SaleWebMvcContext(DbContextOptions<SaleWebMvcContext> options) : DbContext(options) {

        public DbSet<SaleWebMVC.Models.Department> Department { get; set; } = default!;
    }
}