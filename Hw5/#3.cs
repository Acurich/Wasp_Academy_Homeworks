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
            int num = int.Parse(Console.ReadLine()), moon = int.Parse(Console.ReadLine());
            int number = num;
            do
            {
                num *= number;
            } while (num < moon);
            if (num == moon)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
