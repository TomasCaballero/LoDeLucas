using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDeLucas
{
    public class Taza : Producto 
    {
        public MaterialTaza Material { get; set; }

        public Taza() { }
        public Taza(string nombre, double precio, double descuento, MaterialTaza materialTaza) : base(nombre,  precio, descuento)
        {
            this.Material = materialTaza;
        }
    }
}
