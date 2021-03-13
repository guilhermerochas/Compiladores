using System;
using System.Collections.Generic;
using System.Text;

namespace IDE_AnalisadorLexico.Utils
{
    class Erro
    {
        private static Boolean erro;
        private static String msg;

        public static void setErro(Boolean _erro)
        {
            erro = _erro;
        }

        public static void setErro(String _msg)
        {
            erro = true;
            msg = _msg;
        }

        public static Boolean getErro() { return erro; }
        public static String getMsg() { return msg; }
    }
}
