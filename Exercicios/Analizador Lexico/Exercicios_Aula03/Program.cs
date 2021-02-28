using System;
using System.IO;

namespace Exercicios_Aula03
{
    class Program
    {
        public static void AnaliseLexicaTexto()
        {
            int numeroLinha = 1;
            StreamReader leitorEmStream = new StreamReader("./Teste.txt");
            int tamanhoArquivo = (int) leitorEmStream.BaseStream.Length;

            for (int i = 0; i < tamanhoArquivo; i++)
            {
                char byteArquivo = (char) leitorEmStream.BaseStream.ReadByte();

                if (char.IsDigit(byteArquivo))
                {
                    string valor = "";
                    do
                    {
                        valor += byteArquivo.ToString();
                        i++;
                        byteArquivo = (char)leitorEmStream.BaseStream.ReadByte();
                    }
                    while (char.IsDigit(byteArquivo));

                    Console.WriteLine($"Linha {numeroLinha} => {valor}");
                }

                if (byteArquivo == 13)
                {
                    numeroLinha++;
                }
            }
        }
        
        static void Main(string[] args)
        {
            AnaliseLexicaTexto();
            Console.ReadKey();
        }
    }
}
