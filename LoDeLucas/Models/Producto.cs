using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDeLucas
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string Nombre { get; set;}
        public double Precio    { get; set;}
        public double Descuento { get; set; }

        public Producto(string nombre, double precio, double descuento)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Descuento = descuento;
        }
    }
}
