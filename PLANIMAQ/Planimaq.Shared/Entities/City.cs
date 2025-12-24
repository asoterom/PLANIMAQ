using Planimaq.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class City :IEntityWithName
    {
        public int id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos
        public int stateId { get; set; }
        public State? State { get; set; }

    }
}
