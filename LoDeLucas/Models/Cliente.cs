using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace LoDeLucas
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30)]
        public String Nombre { get; set; }

        [StringLength(30)]
        public String Apellido { get; set; }

        [StringLength(11, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]*$")]
        public String Telefono { get; set; }

        [EmailAddress]
        public String Email { get; set; }


        public Cliente() { }
        public Cliente(int id, String nombre, String apellido, String telefono, String email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
        }
    }

}
