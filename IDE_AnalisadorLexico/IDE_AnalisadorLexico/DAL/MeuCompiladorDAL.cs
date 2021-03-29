﻿using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.Collections.Generic;
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

        public static List<Token> obterTokensValidos()
        {
            List<Token> tokens = new List<Token>();
            string aux = @"Select * from TTokens";
            strSQL = new OleDbCommand(aux, conn);
            OleDbDataReader reader = strSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tokens.Add(new Token 
                    { 
                        Codigo = reader.GetInt32(0),
                        NomeToken = reader.GetString(1)
                    });
                }
            }

            var texto = "";
            tokens.ForEach(t => texto += t.NomeToken + "\n");

            System.Windows.Forms.MessageBox.Show(texto);

            return tokens;
        }
    }
}