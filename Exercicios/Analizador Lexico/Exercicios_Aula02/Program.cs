using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Exercicios_Aula02
{
    class Program
    {
        public static void Exercicio_01()
        {
            int quantidadeLetras = 0;
            int quantidadeNumeros = 0;
            int quantidadeOutrosChars = 0;

            using (FileStream fs = new FileStream(@$"{ Directory.GetCurrentDirectory() }/file_tmp.txt", FileMode.Open, FileAccess.Read))
            {
                char currentByte;

                for(int i = 0; i < (int) fs.Length; i++) 
                {
                    currentByte = (char) fs.ReadByte();

                    if (char.IsLetter(currentByte))
                        quantidadeLetras++;
                    else
                    {
                        if (char.IsNumber(currentByte))
                            quantidadeNumeros++;
                        else
                            quantidadeOutrosChars++;
                    }
                }

                Console.WriteLine(" =========== Exercicio 01 ===========");
                Console.WriteLine($"Quantidade de Numeros: {quantidadeNumeros}");
                Console.WriteLine($"Quantidade de Letras: {quantidadeLetras}");
                Console.WriteLine($"Quantidade de Outros Chars: {quantidadeOutrosChars}");
            }
        }

        public static void Exercicio_02()
        {
            if (!File.Exists(@$"{Directory.GetCurrentDirectory()}/file_tmp.txt"))
                File.Create(@$"{Directory.GetCurrentDirectory()}/file_tmp.txt");
            else
                File.WriteAllText(@$"{Directory.GetCurrentDirectory()}/file_tmp.txt", string.Empty);

            using (StreamReader sr = new StreamReader("Teste.txt"))
            {
                Console.WriteLine(" =========== Exercicio 02 ===========");

                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    line = Regex.Replace(line, @"#(.*?)#", string.Empty, RegexOptions.IgnoreCase).ToUpper();
                    using (StreamWriter sw = new StreamWriter(@$"{Directory.GetCurrentDirectory()}/file_tmp.txt", true))
                    {
                        Console.WriteLine(line);
                        sw.WriteLine(line);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Exercicio_01();
            Console.WriteLine("\n\n");
            Exercicio_02();
        }
    }
}
