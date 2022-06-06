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

        public DbSet<TiendaApp_Backend.Models.Product>? Product { get; set; }

        public DbSet<TiendaApp_Backend.Models.Category>? Category { get; set; }

        public DbSet<TiendaApp_Backend.Models.Client>? Client { get; set; }
    }
}
