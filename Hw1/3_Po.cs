using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int av = int.Parse(Console.ReadLine());
            int bv = int.Parse(Console.ReadLine());
            int xv = int.Parse(Console.ReadLine());
            int yv = int.Parse(Console.ReadLine());
            double checkeric1 = a / 2;
            double checkeric2 = b / 2;
            if (xv > checkeric1)
            {
                xv = av - xv;
            }
            if (yv > checkeric2)
            {
                yv = bv - yv;
            }
            if (xv <= yv)
            {
                Console.WriteLine(xv);
            }
            else
            {
                Console.WriteLine(yv);
            }
            Console.ReadKey();
        }
    }
}
