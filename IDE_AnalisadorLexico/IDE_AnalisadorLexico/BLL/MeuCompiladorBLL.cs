using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IDE_AnalisadorLexico.BLL
{
    class MeuCompiladorBLL
    {
        public static void CompilarPrograma(ProgramaFonte cdFonte)
        {
            try
            {
                MeuCompiladorDAL.ResetaBanco();
                StringBuilder textValue;

                if (string.IsNullOrWhiteSpace(cdFonte.PathNome))
                {
                    Erro.setErro("erro: Arquivo não encontrado!");
                }

                using (StreamReader sr = new StreamReader(cdFonte.PathNome))
                {
                    textValue = AnalisadorLexicoBLL.Filtro(sr);
                }

                AnalisadorLexicoBLL.createTempFile(textValue);
                AnalisadorLexicoBLL.Scanner();
                
                AnalisadorSintaticoBLL.testeTokensValidos();
            }
            catch(Exception e)
            {
                Erro.setErro($"Erro: {e.Message}");
            }
        }

        public static void Conecta() => MeuCompiladorDAL.Conecta();
        public static void Desconecta() => MeuCompiladorDAL.Desconecta();
    }
}
