using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndependentWork21
{
    internal class Program
    {
        private static int[,] uchastok;
        private static int m;
        private static int n;

        static void Main()
        {
            Console.WriteLine("Количество ячеек по вертикали");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Количество ячеек по горизонтали");
            m = Convert.ToInt32(Console.ReadLine());

            uchastok = new int[n, m];

            Thread sadovnik1 = new Thread(sad1);
            Thread sadovnik2 = new Thread(sad2);

            sadovnik1.Start();
            sadovnik2.Start();

            sadovnik1.Join();
            sadovnik2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(uchastok[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void sad1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (uchastok[i, j] == 0)
                        uchastok[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (uchastok[j, i] == 0)
                        uchastok[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
