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
            int num = int.Parse(Console.ReadLine());
            string[] mas = Console.ReadLine().Split(" ");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num - 1; j++)
                {
                    if (int.Parse(mas[j + 1]) < int.Parse(mas[j]))
                    {
                        string t = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = t;
                    }
                }
            }
            foreach (string _ in mas)
                Console.Write($"{_} ");
        }
    }
}
