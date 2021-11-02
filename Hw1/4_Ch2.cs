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
            int razv = Math.Max(av, cv) - Math.Min(av, cv);
            int razv2 = Math.Max(bv, dv) - Math.Min(bv, dv);
            if ((razv > 1) || (razv2 > 1))
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
            Console.ReadKey();
        }
    }
}
