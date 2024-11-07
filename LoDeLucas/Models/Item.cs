using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoDeLucas
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public Item(Producto producto, int cantidad) {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }
    }
}