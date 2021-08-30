using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IDE_AnalisadorLexico.BLL
{
    class MeuCompiladorBLL
    {
        public static void CompilarPrograma(ProgramaFonte cdFonte)
        {
            try
            {
                //faz a limpeza do banco de dados de todos os tokens
                MeuCompiladorDAL.ResetaBanco();
                StringBuilder textValue;

                //Irá retornar um erro caso o arquivo do codigo fonte não seja encontrado
                if (string.IsNullOrWhiteSpace(cdFonte.PathNome))
                {
                    Erro.setErro("erro: Arquivo não encontrado!");
                    return;
                }

                //atribui o filtro de limpeza do codigo fonte ao valor de texto
                using (StreamReader sr = new StreamReader(cdFonte.PathNome))
                {
                    textValue = AnalisadorLexicoBLL.Filtro(sr);
                }

                // uma `tempfile` é criada para armazenar o codigo que será processado nas analises
                AnalisadorLexicoBLL.createTempFile(textValue);

                // o scanner é responsavel por fazer uma verificação sequencial dos tipos dos Tokens,
                // nesse processo os valores são inseridos na base de dados com seus metadados
                AnalisadorLexicoBLL.Scanner();
                if (Erro.getErro())
                    return;

                // Método principal que carrega o processamento da camada de analise sintatica, sendo a responsavel
                // por conter os metodos de processamento da camada
                AnalisadorSintaticoBLL.AnaliseSintatica();
                if (Erro.getErro())
                    return;
                
                AnalisadorSemanticoBLL.analiseSemantica();
                if (Erro.getErro())
                    return;

                TradutorBll.GeraExecutavel();
            }
            catch (Exception e)
            {
                Erro.setErro($"Erro: {e.Message}");
            }
        }

        public static void Conecta() => MeuCompiladorDAL.Conecta();
        public static void Desconecta() => MeuCompiladorDAL.Desconecta();
    }
}
