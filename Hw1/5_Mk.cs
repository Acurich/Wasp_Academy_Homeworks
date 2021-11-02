using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int gran = 109;
            if (v >= 0)
            {
                Console.WriteLine(v * t % gran);
            }
            else
            {
                Console.WriteLine(gran + (v * t % gran));
            }
            Console.ReadKey();
        }
    }
}
