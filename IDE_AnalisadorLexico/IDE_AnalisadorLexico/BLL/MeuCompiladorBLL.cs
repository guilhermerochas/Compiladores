using IDE_AnalisadorLexico.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IDE_AnalisadorLexico.BLL
{
    class MeuCompiladorBLL
    {
        public static Exception compilarPrograma(ProgramaFonte cdFonte)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cdFonte.PathNome))
                    return new Exception("Arquivo não encontrado!");

                using (StreamReader sr = new StreamReader(cdFonte.PathNome))
                {
                    Filtro(sr);
                }

                return null;
            }
            catch(Exception e)
            {
                return e;
            }
        }

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
    }
}
