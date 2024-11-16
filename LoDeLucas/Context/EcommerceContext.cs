using LoDeLucas.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace LoDeLucas.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext>options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cafe> Cafe { get; set; } = default!;
        public DbSet<Taza> Taza { get; set; } = default!;
        public DbSet<Compra> Compra { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }
    }

}
