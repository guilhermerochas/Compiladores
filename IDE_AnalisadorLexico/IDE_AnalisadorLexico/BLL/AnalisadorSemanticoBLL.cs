using System;
using System.Linq;
using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;

namespace IDE_AnalisadorLexico.BLL
{
    public class AnalisadorSemanticoBLL
    {
        public static void analiseSemantica()
        {
            var tokens = MeuCompiladorDAL.ObterTokensSemanticos();
            var limites = MeuCompiladorDAL.ObterLimitesTokens();
            
            for (int i = 0; i < tokens.Count; i++)
            {
                if(tokens[i].Tipo != "String")
                    continue;
                
                var limiteTokens = limites.Where(l=> l.Codigo == tokens[i].Codigo).ToList();

                if (limiteTokens.Count == 0)
                    continue;

                for (int j = 0; j < limiteTokens.Count; j++)
                {
                    int tokenAnalisado = int.TryParse(tokens[(i + j) + 1].NomeToken, out _) ? 
                        Convert.ToInt32(tokens[(i + j) + 1].NomeToken) :
                        Convert.ToInt32(Convert.ToChar(tokens[(i + j) + 1].NomeToken));
                    
                    if (tokenAnalisado < limiteTokens[j].Minimo || tokenAnalisado > limiteTokens[j].Maximo)
                    {
                        Erro.setErro($"Linha {tokens[i].Linha} fora da faixa de valor ('{tokens[i].NomeToken}')");
                        return;
                    }
                }

                i += limiteTokens.Count;
            }
        }
    }
}