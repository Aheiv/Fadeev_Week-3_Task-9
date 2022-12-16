using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace лаба9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double b;
            Console.Write("Введите число n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                Console.Write("Некорректный ввод данных!\nВведите число n: ");
            Console.Write("Введите число b: ");
            while (!double.TryParse(Console.ReadLine(), out b))
                Console.Write("Некорректный ввод данных!\nВведите число b: ");
            FileStream f = File.Create("t.dat");
            BinaryWriter fOut = new BinaryWriter(f);
            double[] mas = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Число {0}: ", i + 1);
                double temp = double.Parse(Console.ReadLine());
                mas[i] = temp;
                fOut.Write(temp); ;
            }
            fOut.Close();
            f = new FileStream("t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length;
            for (long i = 0; i < m; i += 16)
            {
                f.Seek(i, SeekOrigin.Begin);
                double a = fIn.ReadDouble();
                if (a > b) Console.Write("{0:f2} ", a);
            }
            fIn.Close();
            f.Close();
            FileStream ff = File.Create("t.txt");
            StreamWriter fWrt = new StreamWriter(ff);
            for (int i = 0; i < n; i++)
            {
                double temp = mas[i];
                fWrt.Write(temp + " "); ;
            }
            fWrt.Close();
            ff.Close();
        }
    }
}
