using System;
using System.IO;

namespace Exercicios_Aula04
{
    class Program
    {
        public static void AnaliseLexicaTexto_Exercicio02()
        {
            using (StreamReader sr = new StreamReader("./Teste.txt"))
            {
                int numeroLinha = 1;
                int tamanhoArquivo = (int) sr.BaseStream.Length;
                char letraArquivo;
                string valor = "";

                for (int i = 0; i < tamanhoArquivo; i++)
                {
                    letraArquivo = (char) sr.BaseStream.ReadByte();

                    if (char.IsDigit(letraArquivo))
                    {
                        while (char.IsDigit(letraArquivo))
                        {
                            valor += letraArquivo;
                            i++;
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                        }
                        Console.WriteLine($"Linha {numeroLinha} (int) => {valor}");
                        valor = "";
                    }

                    if (char.IsLetter(letraArquivo))
                    {
                        while (char.IsLetter(letraArquivo))
                        {
                            valor += letraArquivo;
                            i++;
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                        }
                        Console.WriteLine($"Linha {numeroLinha} (string) => {valor}");
                        valor = "";
                    }

                    if (char.IsDigit(letraArquivo))
                        valor += letraArquivo;


                    if (letraArquivo == 13)
                        numeroLinha++;
                }
            }
        }

        public static void AnaliseLexicaTexto_Exercicio03b()
        {
            try
            {
                using (StreamReader sr = new StreamReader("./Arquivo.txt"))
                {
                    int numeroLinha = 1;
                    int tamanhoArquivo = (int)sr.BaseStream.Length;
                    char letraArquivo;
                    string valor = "";

                    for (int i = 0; i < tamanhoArquivo; i++)
                    {
                        letraArquivo = (char)sr.BaseStream.ReadByte();

                        if (letraArquivo == '\"')
                        {
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                            while (letraArquivo != '\"')
                            {
                                valor += letraArquivo;
                                i++;
                                letraArquivo = (char)sr.BaseStream.ReadByte();
                            }
                            Console.WriteLine($"Linha {numeroLinha} (string) => {valor}");
                            valor = "";
                        }

                        if (letraArquivo == '\'')
                        {
                            letraArquivo = (char)sr.BaseStream.ReadByte();
                            while (letraArquivo != '\'')
                            {
                                valor += letraArquivo;
                                i++;
                                letraArquivo = (char)sr.BaseStream.ReadByte();
                            }
                            Console.WriteLine($"Linha {numeroLinha} (char) => {valor}");
                            valor = "";
                        }

                        if (letraArquivo == 13)
                            numeroLinha++;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Não foi possivel ler ;(");
            }
        }

        static void Main(string[] args)
        {
            //AnaliseLexicaTexto_Exercicio02();
            AnaliseLexicaTexto_Exercicio03b();
        }
    }
}
