using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planimaq.Shared.Entities
{
    public class Cargo
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public bool state { get; set; }
        public string suserCreate { get; set; } = null!;
        public DateTime dfechCreate { get; set; }
        public string suserEdit { get; set; } = null!;
        public DateTime dfechEdit { get; set; }


    }
}