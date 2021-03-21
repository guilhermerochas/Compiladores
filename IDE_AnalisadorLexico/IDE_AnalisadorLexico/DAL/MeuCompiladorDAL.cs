using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.Data.OleDb;

namespace IDE_AnalisadorLexico.DAL
{
    class MeuCompiladorDAL
    {
        private static string strConexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Compilador.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;

        public static void Conecta()
        {
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                Erro.setErro($"Falha na conexão com o Banco de Dados! {e}");
                return;
            }
        }

        public static void Desconecta()
        {
            try
            {
                conn.Close();
            }
            catch(Exception e)
            {
                Erro.setErro($"Falha na desconexão com o Banco de Dados! {e}");
                return;
            }
        }

        public static void InsereTokenValido()
        {
            string aux = $@"insert into TTokensValidos(Codigo,Token,Tipo,Linha) values ({TokenValido.Codigo},'{TokenValido.NomeToken}','{TokenValido.Tipo}',{TokenValido.Linha})";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void ResetaBanco()
        {
            string aux = @"Delete * from TTokensValidos";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }
    }
}
