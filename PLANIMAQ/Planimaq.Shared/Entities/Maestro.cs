using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class Maestro
    {

        public int id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        [Display(Name = "Valor")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string sValor { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        [Display(Name = "Cod.Grupo")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string sIdGrupo { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        [Display(Name = "Grupo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string sGrupo { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        [Display(Name = "Estado")]
        public int sEstado { get; set; }
    }
}
