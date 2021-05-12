using System;
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
            
            for (int i = 0; i < tokens.Count; i++)
            {
                if(tokens[i].Tipo != "String")
                    continue;

                var tipoToken = (TipoTokens) tokens[i].Codigo;
                switch(tipoToken)
                {
                    case TipoTokens.ESCREVEDIGITO:
                    {
                        int primeiroValor = Convert.ToInt32(tokens[i + 1].NomeToken);
                        if (primeiroValor < 0 || primeiroValor > 9)
                        {
                            Erro.setErro($"Não foi possivel obter o tipo do metodo {tokens[i].NomeToken} na linha {tokens[i].Linha}");
                            return;
                        }
                        break;
                    }
                    case TipoTokens.POSICIONACURSOR:
                    {
                        int primeiroValor = Convert.ToInt32(tokens[i + 1].NomeToken);
                        int segundoValor = Convert.ToInt32(tokens[i + 2].NomeToken);
                        if (primeiroValor < 1 || primeiroValor > 80 || 
                            segundoValor < 1 || segundoValor > 24)
                        {
                            Erro.setErro($"Não foi possivel obter o tipo do metodo {tokens[i].NomeToken} na linha {tokens[i].Linha}");
                            return;
                        }
                        break;   
                    }
                    default:
                        Erro.setErro($"Não foi possivel obter o tipo do metodo {tokens[i].NomeToken} na linha {tokens[i].Linha}");
                        return;
                }
            }
        }
    }
}