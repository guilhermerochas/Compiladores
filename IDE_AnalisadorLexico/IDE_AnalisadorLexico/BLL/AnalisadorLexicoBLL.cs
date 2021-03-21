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
        public static void Filtro(StreamReader reader)
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

            using (StreamWriter sw = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Desktop\PFTMP.TXT"))
            {
                sw.Write(sb.ToString());
            }
        }

        public static void Scanner()
        {   
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
                        ExtratoDeTokens.Tokens.Add($"Linha {numeroLinha} (int) => {valor}");
                        MontaTokenValido(24, valor, "Inteiro", numeroLinha);
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
                        ExtratoDeTokens.Tokens.Add($"Linha {numeroLinha} (string) => {valor}");
                        MontaTokenValido(24, valor, "String", numeroLinha);
                        valor = "";
                    }

                    if (char.IsPunctuation(letraArquivo) || char.IsSymbol(letraArquivo))
                    {
                        ExtratoDeTokens.Tokens.Add($"Linha {numeroLinha} (Delimitador) => {letraArquivo}");
                        MontaTokenValido(24, letraArquivo.ToString(), "Delimitador", numeroLinha);
                    }

                    if (char.IsDigit(letraArquivo))
                        valor += letraArquivo;


                    if (letraArquivo == 13)
                        numeroLinha++;
                }
            }
        }

        public static void MontaTokenValido(int codigo, string token, string tipo, int linha)
        {
            TokenValido.Codigo = codigo;
            TokenValido.NomeToken = token;
            TokenValido.Tipo = tipo;
            TokenValido.Linha = linha;

            MeuCompiladorDAL.InsereTokenValido();
        }
    }
}
