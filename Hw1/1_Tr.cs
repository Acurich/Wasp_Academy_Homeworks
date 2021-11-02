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
            int nolic = 1;
            if (av == bv)
            {
                nolic++;
            }
            if (av == cv)
            {
                nolic++;
            }
            if (bv == cv)
            {
                nolic++;
            }
            if (nolic == 1 || nolic == 4)
            {
                Console.WriteLine(nolic - 1);
            }
            else
            {
                Console.WriteLine(nolic);
            }
            Console.ReadKey();
        }
    }
}
