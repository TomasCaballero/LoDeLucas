using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace LoDeLucas
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        
        [StringLength(30)]
        public string Nombre { get; set;}

        [Range(1, 999999999)]
        public double Precio { get; set;} 
        
        [Range(0, 100)]
        public double Descuento { get; set; } 

        public Producto() { }
        public Producto(string nombre, double precio, double descuento)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Descuento = descuento;
        }
    }
}
