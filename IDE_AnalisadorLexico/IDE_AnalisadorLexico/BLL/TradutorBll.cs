using System.IO;
using System.Linq;
using System.Windows.Forms;
using IDE_AnalisadorLexico.DAL;
using IDE_AnalisadorLexico.Models;

namespace IDE_AnalisadorLexico.BLL
{
    public class TradutorBll
    {
        public static void GeraExecutavel()
        {
            var tokens = MeuCompiladorDAL.ObterTokensSemanticos();
            var tokensValidos = MeuCompiladorDAL.ObterTokensValidos();

            using (FileStream writer = new FileStream($"./programa.com", FileMode.Append, FileAccess.Write))
            {
                foreach (var token in tokens)
                {
                    Token valido = tokensValidos.FirstOrDefault(t => t.NomeToken == token.NomeToken);

                    if (valido == null)
                        continue;

                    string nomeExecutavel = $"./Asm/{SelecionaComFile(valido.NomeToken)}";
                    if (File.Exists(nomeExecutavel))
                    {
                        using (FileStream reader = new FileStream(nomeExecutavel, FileMode.Open, FileAccess.Read))
                        {
                            int tamanho = (int)reader.Length;

                            for (int i = 0; i < tamanho; i++)
                            {
                                byte readedByte = (byte)reader.ReadByte();
                                writer.WriteByte(readedByte);
                            }
                        }
                    }
                }
            }
        }

        // Helper para retornar qual o arquivo que será acrescentado para o executável.
        // usando um comando como argumento ele retorna o nome do exe equivalente.
        private static string SelecionaComFile(string comando)
        {
            return comando switch
            {
                "ESCREVEDIGITO" => "ED.COM",
                "LIMPATELA" => "LT.COM",
                "POSICIONACURSOR" => "PC.COM",
                "FIM" => "F.COM",
                _ => string.Empty
            };
        }
    }
}