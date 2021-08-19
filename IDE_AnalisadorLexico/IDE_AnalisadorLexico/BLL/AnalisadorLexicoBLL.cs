using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IDE_AnalisadorLexico.BLL
{
    class AnalisadorLexicoBLL
    {
        private static List<Token> tokensValidos;

        public static StringBuilder Filtro(StreamReader reader)
        {
            int tamanhoArquivo = (int)reader.BaseStream.Length;
            char byteArquivo;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tamanhoArquivo; i++)
            {
                byteArquivo = (char)reader.BaseStream.ReadByte();

                if (byteArquivo == '#')
                {
                    do
                    {
                        i++;
                        byteArquivo = (char)reader.BaseStream.ReadByte();
                    }
                    while (byteArquivo != '#');
                }
                else
                {
                    if (byteArquivo != ' ' && byteArquivo != '\t')
                        sb.Append(byteArquivo.ToString().ToUpper());
                }
            }

            return sb;
        }

        public static void Scanner()
        {
            tokensValidos = MeuCompiladorDAL.ObterTokensValidos();

            using (StreamReader sr = new StreamReader($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\PFTMP.TXT"))
            {
                int numeroLinha = 1;
                int tamanhoArquivo = (int)sr.BaseStream.Length;
                char letraArquivo;
                string valor = "";

                for (int i = 0; i < tamanhoArquivo; i++)
                {
                    letraArquivo = (char)sr.BaseStream.ReadByte();

                    if (char.IsDigit(letraArquivo))
                    {
                        while (char.IsDigit(letraArquivo))
                        {
                            valor += letraArquivo;
                            i++;
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                        }
                        var result = MontaTokenValido(valor, "Inteiro", numeroLinha, 200);

                        if (result != null)
                            throw result;

                        valor = "";
                    }

                    if (char.IsLetter(letraArquivo))
                    {
                        while (char.IsLetter(letraArquivo))
                        {
                            valor += letraArquivo;
                            i++;
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                        }

                        Exception result;
                        
                        if(valor.Length == 1) 
                            result = MontaTokenValido(valor, "Letra", numeroLinha, 300);
                        else
                            result = MontaTokenValido(valor, "String", numeroLinha);

                        if (result != null)
                            throw result;

                        valor = "";
                    }

                    if (char.IsPunctuation(letraArquivo) || char.IsSymbol(letraArquivo))
                    {
                        var result = MontaTokenValido(letraArquivo.ToString(), "Delimitador", numeroLinha);

                        if (result != null)
                            throw result;
                    }

                    if (char.IsDigit(letraArquivo))
                        valor += letraArquivo;


                    if (letraArquivo == 13)
                        numeroLinha++;
                }
            }
        }

        public static void createTempFile(StringBuilder sb)
        {
            using (StreamWriter sw = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\PFTMP.TXT"))
            {
                sw.Write(sb.ToString());
            }
        }

        public static Exception MontaTokenValido(string token, string tipo, int linha, int? codigo = null)
        {
            int? novoCodigo = codigo ?? tokensValidos.Find(t => t.NomeToken == token)?.Codigo;

            if (novoCodigo == null)
                return new Exception($"Token {token} Invalido na linha {linha}!");

            if (tokensValidos.Find(t => t.NomeToken == token) != null || 
                tipo == "Inteiro" || tipo == "Letra")
            {
                TokenValido.Codigo = novoCodigo.Value;
                TokenValido.NomeToken = token;
                TokenValido.Tipo = tipo;
                TokenValido.Linha = linha;
                MeuCompiladorDAL.InsereTokenValido();
                return null;
            }
            
            return new Exception($"Token {token} Invalido na linha {linha}!");
        }
    }
}
