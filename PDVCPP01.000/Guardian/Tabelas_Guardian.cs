using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Guardian
{
    class Tabelas_Guardian
    {
#if (DEBUG)
        public static string Empresa = "990";
#else
        public static string Empresa = "010";
#endif

        public static string ZA0 { get; set; } = "ZA0" + Empresa;

        public static string ZA1 { get; set; } = "ZA1" + Empresa;

        public static string ZA5 { get; set; } = "ZA5" + Empresa;

        public static string ZA6 { get; set; } = "ZA6" + Empresa;

        public static string ZAP { get; set; } = "ZAP" + Empresa;

        public static string ZAN { get; set; } = "ZAN" + Empresa;

        public static string ZAE { get; set; } = "ZAE" + Empresa;

        public static string ConfigUpload { get; set; } = "ZAU" + Empresa;

        public static string ConfigLog { get; set; } = "ZAL" + Empresa;

    }
}
