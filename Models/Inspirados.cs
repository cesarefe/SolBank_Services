using System.ComponentModel.DataAnnotations;

namespace SolBank1.Models
{
    public class Inspirados
    {
        [Key] 
        public int cedula { get; set; }
        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? correo { get; set; }
        public int estado { get; set; }
        public DateTime fechaInscripcion { get; set; }
    }
}
