using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ShopContext : DbContext
    {
        private readonly string _connectionString = "server=localhost; database=twab; user=root; password=root1234567890";

        public DbSet<UserEntity> users { get; set; }
        public DbSet<ProductEntity> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql( _connectionString, ServerVersion.AutoDetect(_connectionString));
        }

    }
}
