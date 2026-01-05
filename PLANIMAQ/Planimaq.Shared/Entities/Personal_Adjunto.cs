using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class Personal_Adjunto
    {
        public int id { get; set; }
        [Display(Name = "Certificación")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;
        public DateTime FechaVigencia { get; set; }
        public DateTime FechaTermino { get; set; }

        [Display(Name = "Tipo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string tipo { get; set; } = null!;
        public byte[]? Foto { get; set; }
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
