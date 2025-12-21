using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class Configuracion
    {
        public int id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        [Display(Name = "Estado(SI/NO)")]
        [MaxLength(5, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Status { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos
       
        [Display(Name = "Correo/Datos")]
        [MaxLength(1000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string MailData { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos


    }
}
