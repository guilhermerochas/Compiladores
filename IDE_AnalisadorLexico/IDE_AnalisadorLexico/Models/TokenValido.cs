using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_AnalisadorLexico.Models
{
    class TokenValido
    {
        public static int Codigo { get; set; }
        public static string NomeToken { get; set; }
        public static string Tipo { get; set; }
        public static int Linha { get; set; }
    }
}
