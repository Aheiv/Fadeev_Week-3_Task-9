using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace лаба9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileIn = new StreamReader("t.txt");
            string text = fileIn.ReadToEnd();
            Console.WriteLine("Исходные данные файла t.txt:\n" + text);
            Console.Write("Нечётные строки текста файла:\n");
            string[] lines = File.ReadAllLines("t.txt");
            int n = 0;
            while (n < lines.Length)
            {
                Console.WriteLine(lines[n]);
                n += 2;
            }
        }
    }
}
