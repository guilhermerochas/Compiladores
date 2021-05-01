﻿using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

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
            catch (Exception e)
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
            catch (Exception e)
            {
                Erro.setErro($"Falha na desconexão com o Banco de Dados! {e}");
                return;
            }
        }

        public static void InsereTokenValido()
        {
            string aux =
                $@"insert into TTokensValidos(Codigo,Token,Tipo,Linha) values ({TokenValido.Codigo},'{TokenValido.NomeToken}','{TokenValido.Tipo}',{TokenValido.Linha})";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static void ResetaBanco()
        {
            string aux = @"Delete * from TTokensValidos";

            strSQL = new OleDbCommand(aux, conn);
            strSQL.ExecuteNonQuery();
        }

        public static List<TTokenValido> PopulaDR()
        {
            var tokens = new List<TTokenValido>();

            string aux = @"Select * from TTokensValidos";
            strSQL = new OleDbCommand(aux, conn);
            OleDbDataReader reader = strSQL.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tokens.Add(new TTokenValido
                    {
                        Codigo = reader.GetInt32(0),
                        NomeToken = reader.GetValue(1).ToString(),
                        Tipo = reader.GetValue(2).ToString(),
                        Linha = reader.GetInt32(3)
                    });
                }
            }

            return tokens;
        }

        public static List<int> obterDicionarioTokenValido(int codigo)
        {
            try
            {
                List<int> dict = new List<int>();

                string aux = @"SELECT * FROM gabarito WHERE previous = @prior AND code = @codigo";
                strSQL = new OleDbCommand(aux, conn);
                strSQL.Parameters.Add("prior", "bof");
                strSQL.Parameters.Add("codigo", codigo);
                OleDbDataReader reader = strSQL.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string info = reader.GetValue(2).ToString();
                    string next = reader.GetValue(3).ToString();

                    while (next != "eof")
                    {
                        dict.Add(Convert.ToInt32(info));
                        
                        aux = @"SELECT * FROM gabarito WHERE info = @inform and code = @codigo and previous = @prev";
                        strSQL = new OleDbCommand(aux, conn);
                        strSQL.Parameters.Add("inform", int.Parse(next!));
                        strSQL.Parameters.Add("codigo", codigo);
                        strSQL.Parameters.Add("prev", info);
                        reader = strSQL.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            info = reader.GetValue(2).ToString();
                            next = reader.GetValue(3).ToString();
                        }
                    }
                    dict.Add(Convert.ToInt32(info));
                }

                return dict;
            }
            catch
            {
                Erro.setErro("Não foi possivel obter os dados do gabarito sintatico");
                return null;
            }
        }

        public static List<Token> ObterTokensValidos()
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

            return tokens;
        }
    }
}