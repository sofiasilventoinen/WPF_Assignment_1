using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_1.Models.Entities;

namespace WPF_Assignment_1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}

