﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVCPP01._000.Guardian
{
    class ConexaoGestor
    {
        public static string Banco { get; set; }
        public static string Login { get; set; }
        public static string Senha { get; set; }
        public static string Servidor { get; set; }

        public static string Conexao()
        {
            return "Server=" + Servidor + ";Database=" + Banco + ";UID=" + Login + ";PWD=" + Senha + ";";
        }
    }
}
