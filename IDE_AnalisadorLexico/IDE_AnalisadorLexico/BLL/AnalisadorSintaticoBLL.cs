using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;

namespace IDE_AnalisadorLexico.BLL
{
    public class AnalisadorSintaticoBLL
    {
        private static List<TTokenValido> tokensValidos = MeuCompiladorDAL.PopulaDR();
        
        // Método de verificação do gabarito sintatico, fazendo o processo de carregar na memoria a sequencia
        // valida do comando e verificar se está correta, retornando um erro ao sistema caso não esteja
        private static void ValidaSequencia(List<TTokenValido> tokens)
        {
            List<int> dictToken = MeuCompiladorDAL.obterDicionarioTokenValido(tokens[0].Codigo);

            if (dictToken == null)
                return;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (dictToken[i] != tokens[i].Codigo)
                {
                    string msg =
                        $"Token {tokens[i].NomeToken} invalido na linha {tokens[i].Linha}";
                    MessageBox.Show(msg);
                    Erro.setErro(true);
                    return;
                }
            }
        }
        
        
        
        // Método principal que carrega o processamento da camada de analise sintatica, sendo a responsavel
        // por conter os metodos de processamento da camada
        public static void AnaliseSintatica()
        {
            int? startLine = tokensValidos.FirstOrDefault()?.Linha;
            int? numLinhas = tokensValidos.LastOrDefault()?.Linha;

            for (int? i = startLine; i < numLinhas; i++)
            {
                var reducedTokens = tokensValidos.Where(token => token.Linha == i).ToList();
                ValidaSequencia(reducedTokens);
                if (Erro.getErro())
                    return;
            }

            MeuCompiladorDAL.RemoveDelimitadores();
        }
    }
}