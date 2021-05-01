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

        public static void AnaliseSintatica()
        {
            int? startLine = tokensValidos.FirstOrDefault()?.Linha;
            int? numLinhas = tokensValidos.LastOrDefault()?.Linha;

            for (int? i = startLine; i < numLinhas; i++)
            {
                var reducedTokens = tokensValidos.Where(token => token.Linha == i).ToList();
                ValidaSequencia(reducedTokens);
            }

            if (Erro.getErro() == false)
                MessageBox.Show("Analise Sintatica Realizada com sucesso");
        }
    }
}