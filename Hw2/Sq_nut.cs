using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int kak_zhizn = int.Parse(Console.ReadLine()); 
            int udaci = int.Parse(Console.ReadLine());
            Console.WriteLine(udaci / kak_zhizn);
            Console.ReadKey();
        }
    }
}
