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

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(30)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(30)]
        public String Apellido { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "El numero ingresado no debe tener entre 8 y 11 dígitos")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Solo se pueden ingresar numeros")]
        public String Telefono { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email no valido")]
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
