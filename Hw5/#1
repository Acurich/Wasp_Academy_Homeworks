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
            int num = int.Parse(Console.ReadLine()), kolich;
            string str = Console.ReadLine();
            string[] mas = str.Split(" ");
            for (int i = 0; i < num; i++)
            {
                kolich = 0;
                for (int j = 0; j < num; j++)
                {
                    if (mas[i] == mas[j])
                        kolich++;
                }
                if (kolich == 1)
                    Console.Write($"{mas[i]} ");
            }
        }
    }
}
