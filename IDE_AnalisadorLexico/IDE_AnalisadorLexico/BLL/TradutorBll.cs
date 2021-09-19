using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;
using IDE_AnalisadorLexico.Utils;

namespace IDE_AnalisadorLexico.BLL
{
    public class TradutorBll
    {
        private static readonly string PathExecutavel = "./programa.com";

        public static void GeraExecutavel()
        {
            List<TTokenValido> tokensValidos = MeuCompiladorDAL.ObterTokensSemanticos();
            List<TIndLib> indLibs = MeuCompiladorDAL.GetIndicadoresTokens();
            List<QtdArgumento> qtdArgumentos = MeuCompiladorDAL.GetQtdArgumentos();

            if (File.Exists(PathExecutavel))
            {
                File.Delete(PathExecutavel);
            }

            using (FileStream reader = new FileStream("./PONTOCOM.LIB", FileMode.Open, FileAccess.Read))
            {
                for (var i = 0; i < tokensValidos.Count; i++)
                {
                    if (tokensValidos[i].Codigo >= 100)
                        continue;

                    TIndLib indicadorToken = indLibs.FirstOrDefault(il => il.Codigo == tokensValidos[i].Codigo);


                    if (indicadorToken == null)
                    {
                        Erro.setErro(
                            $"Não foi possivel encontrar um indicador com o codigo {tokensValidos[i].Codigo} nessa biblioteca!");
                        break;
                    }

                    reader.Position = indicadorToken.Inicio;

                    int qtdTokens = qtdArgumentos.FirstOrDefault(qa => qa.Codigo == tokensValidos[i].Codigo)?.QtdArg ?? 0;

                    using FileStream writer = new FileStream(PathExecutavel, FileMode.Append, FileAccess.Write);
                    for (int j = 0; j < indicadorToken.Tamanho; j++)
                    {
                        byte readByte = (byte)reader.ReadByte();
                        writer.WriteByte(readByte);

                        if (qtdTokens != 0)
                        {
                            reader.ReadByte();
                            i++;
                            qtdTokens--;
                            
                            bool isNumber = Int32.TryParse(tokensValidos[i].NomeToken, out var tokenNum);

                            if (!isNumber)
                            {
                                Erro.setErro(
                                    $"Não foi possivel converter o parámetro {tokensValidos[i].NomeToken} para inteiro!");
                                break;
                            }

                            writer.WriteByte((byte)tokenNum);
                            j++;
                        }
                    }
                }
            }
        }
    }
}