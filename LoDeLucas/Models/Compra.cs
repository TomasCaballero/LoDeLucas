using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoDeLucas.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool EnvioADomicilio { get; set; }

        public Compra() { }

        public Compra(int id, Cliente cliente, Producto producto, int cantidad, DateTime createdAt, bool envioADomicilio)
        {
            Id = id;
            Cliente = cliente;
            Producto = producto;
            Cantidad = cantidad;
            CreatedAt = createdAt;
            EnvioADomicilio = envioADomicilio;
        }

        public double CalcularCosto()
        {
            if (Producto == null) return 0;
            var costoEnvio = EnvioADomicilio ? 2000 : 0;
            var descuento = Producto.Precio * (Producto.Descuento / 100);
            var costoProducto = Producto.Precio - descuento;
            return costoProducto * Cantidad + costoEnvio;
        }
    }
}
