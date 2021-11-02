using System;

namespace Academy
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int privet = int.Parse(Console.ReadLine()); 
            int postav_pat = int.Parse(Console.ReadLine()); 
            int poka = int.Parse(Console.ReadLine());
            int schetchik = 0, iot = 0;
            while (schetchik < privet)
            {
                iot++;
                schetchik += postav_pat;
                if (schetchik >= privet)
                {
                    Console.WriteLine(iot);
                    break;
                }
                schetchik -= poka;
            }
            Console.ReadKey();
        }
    }
}
