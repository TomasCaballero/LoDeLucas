using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDeLucas
{
    public class Cafe : Producto
    {
        public TipoCafe TipoCafe { get; private set; }

        public Cafe() { }
        public Cafe(string nombre, double precio, double descuento, TipoCafe tipoCafe) : base(nombre, precio, descuento)
        {
            this.TipoCafe = tipoCafe;
        }
    }
}
