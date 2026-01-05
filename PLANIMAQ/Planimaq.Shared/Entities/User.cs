using Microsoft.AspNetCore.Identity;
using Planimaq.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        public DateTime? FechaNacimiento { get; set; }
      
        public string? Especialidad { get; set; }
        public string? Brevete { get; set; } 
        public string? Nacionalidad { get; set; }
        public string? CaracteristicaA { get; set; }
        public string? CaracteristicaB { get; set; }
        public string? CaracteristicaC { get; set; }



        [Display(Name = "Foto")]
        public string? Photo { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        public ICollection<Personal_Adjunto>? personal_Adjuntos { get; set; }

        [Display(Name = "Adjuntos")]
        public int CertiNumber => personal_Adjuntos == null || personal_Adjuntos.Count == 0 ? 0 : personal_Adjuntos.Count;



        //[Display(Name = "Dirección")]
        //[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public string Address { get; set; } = null!;

        public Empresa? Empresa { get; set; }

        [Display(Name = "Empresa")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int EmpresaId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";
    }

}
