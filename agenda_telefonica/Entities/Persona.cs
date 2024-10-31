using System.ComponentModel.DataAnnotations;

namespace agenda_telefonica.Entities
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        [StringLength(11)]
        public required string Cedula { get; set; }
        [StringLength(120)]
        public required string Direccion { get; set; }
    
        public ICollection<Correo> Correos { get; set; } = new List<Correo>();
    }
}
