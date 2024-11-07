using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDeLucas
{
    public class Carrito
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCarrito { get; set; }
        public List<Item> items;

        public Carrito() {
            this.items = new List<Item>();
        }
    }
}
