using Planimaq.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class State : IEntityWithName
    {
        public int id { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;  //para quitar los warning de nulos con esto ya no acepta nulos

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<City>? Cities { get; set; }

        public int CitiesNumber => Cities == null? 0 : Cities.Count;

    }
}
