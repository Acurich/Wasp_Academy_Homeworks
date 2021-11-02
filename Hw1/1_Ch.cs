using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int av = int.Parse(Console.ReadLine());
            int bv = int.Parse(Console.ReadLine());
            int cv = int.Parse(Console.ReadLine());
            int dv = int.Parse(Console.ReadLine());
            if ((av == cv && bv != dv) || (bv == dv && av != cv))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            Console.ReadKey();
        }
    }
}
