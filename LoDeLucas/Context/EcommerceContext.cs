using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LoDeLucas;

namespace LoDeLucas.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext>options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Cafe> Cafe { get; set; } = default!;
    }

}
