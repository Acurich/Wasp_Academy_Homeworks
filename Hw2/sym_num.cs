using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int horoshego_dna = int.Parse(Console.ReadLine());
            while (horoshego_dna > 0)
            {
                Console.Write(horoshego_dna % 10);
                horoshego_dna /= 10;
            }
            Console.ReadKey();
        }
    }
}
