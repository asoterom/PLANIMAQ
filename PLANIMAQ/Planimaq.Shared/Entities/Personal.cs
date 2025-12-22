using Microsoft.EntityFrameworkCore;

namespace Planimaq.Shared.Entities
{
    public class Personal
    {
        public int id { get; set; }
        public string snomb_pers { get; set; }
        public string sappa_pers { get; set; }
        public string sapma_pers { get; set; }
        public int nesta_pers { get; set; }
        public string sdni_pers { get; set; }
        public string snomc_pers { get; set; }
        public string slogo_pers { get; set; }
        public int npimpo_pers { get; set; }
        public string smail_pers { get; set; }
        public int ncode_cargo { get; set; }
        public string dfein_pers { get; set; }
        public string dfena_pers { get; set; }
        public int ncode_orar { get; set; }
        public string sdire_pers { get; set; }
        public byte[] vimagen_pers { get; set; }
        public string dfeba_pers { get; set; }
        public int ncond_pers { get; set; }
        public DateTime dhoini_pers { get; set; }
        public DateTime dhofin_pers { get; set; }
        public string shoini_pers { get; set; }
        public string shofin_pers { get; set; }
        public byte[] vfirma_pers { get; set; }
        public string cargo_pers { get; set; }
        public string area_pers { get; set; }
        public string ccosto_pers { get; set; }
        public string subigeo_pers { get; set; }
        public string codccostotareo_pers { get; set; }
        public string stelefono_pers { get; set; }
        public string stelefonocorp_pers { get; set; }
        public string scamisatalla_pers { get; set; }
        public string spantalontalla_pers { get; set; }
        public string szapatotalla_pers { get; set; }
        public string smailcorp_pers { get; set; }
        
        [Precision(18,2)]
        public decimal ncostohora_pers { get; set; }
    }
}
