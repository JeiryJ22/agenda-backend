using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace agenda_telefonica.Entities
{
    public class Correo
    {
        [Key]
        public int IdCorreo { get; set; }
        [StringLength(70)]
        public required string Email { get; set; }
        [ForeignKey("Persona")]
        public int IdPersona { get; set; }
        public required Persona Persona { get; set; }
        public bool IsDeleted { get; set; } = false;
        //Implementé del soft delete
    }
}
