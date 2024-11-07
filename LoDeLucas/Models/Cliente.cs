using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoDeLucas
{
    public class Cliente
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        //public Carrito Carrito { get; set; }


        //public Cliente(String nombre, String apellido, String telefono, String email) {
        //    setId();
        //    this.Nombre = nombre;
        //    this.Apellido = apellido;
        //    this.Telefono = telefono;
        //    this.Email = email;
        //    this.Carrito = new Carrito();
        //}


    }
}
