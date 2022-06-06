using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaApp_Backend.Models;

namespace TiendaApp_Backend.Data
{
    public class TiendaApp_BackendContext : DbContext
    {
        public TiendaApp_BackendContext (DbContextOptions<TiendaApp_BackendContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(OrderDetail => new { OrderDetail.OrderID, OrderDetail.ProductID });
        }

        public DbSet<TiendaApp_Backend.Models.Product>? Product { get; set; }

        public DbSet<TiendaApp_Backend.Models.Category>? Category { get; set; }

        public DbSet<TiendaApp_Backend.Models.Client>? Client { get; set; }

        public DbSet<TiendaApp_Backend.Models.Order>? Order { get; set; }

        public DbSet<TiendaApp_Backend.Models.OrderDetail>? OrderDetail { get; set; }
    }
}
