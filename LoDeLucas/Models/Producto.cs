using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Serialization;

namespace LoDeLucas
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Required (ErrorMessage = "El nombre es requerido")]
        [StringLength(30)]
        public string Nombre { get; set;}

        [Display(Name = "Precio(AR$)")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(1, 999999999, ErrorMessage = "El numero debe estar entre 1-999999999")]
        public double Precio { get; set;}

        [Required(ErrorMessage = "El descuento es requerido, en caso de no tener descuento ingresar 0")]
        [Range(0, 100, ErrorMessage = "El numero debe estar entre 0-100")]

        [Display(Name = "Descuento(%)")]
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
