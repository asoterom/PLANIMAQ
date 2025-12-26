using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planimaq.Shared.Enums
{
    public enum UserType
    {
        [Description("Administrador")]
        Admin,

        [Description("Técnico")]
        Tecnico,

        [Description("Operador")]
        Operador,

        [Description("Usuario")]
        User
    }
}
