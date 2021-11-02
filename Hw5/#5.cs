using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mas = Console.ReadLine().Split(" ");
            int num = int.Parse(mas[0]), kek = int.Parse(mas[1]);
            int[] anse = new int[num];
            for (int i = 0; i < kek; i++)
            {
                string[] mas1 = Console.ReadLine().Split(" ");
                int xox = int.Parse(mas1[0]), you = int.Parse(mas1[1]);
                while (xox <= you)
                {
                    anse[xox - 1] = 1;
                    xox++;
                }
            }
            foreach(int j in anse)
            {
                if (j == 0)
                    Console.Write("I");
                else
                    Console.Write(".");
            }
        }
    }
}
