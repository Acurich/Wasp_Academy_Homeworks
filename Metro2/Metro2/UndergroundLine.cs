using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2
{
    public class UndergroundLine : Line
    {

        public UndergroundLine(string n, ConsoleColor c) : base(n, c)
        {

        }

        public override void Print()
        {
            Console.ForegroundColor = Color;
            Console.Write("Underground ");
            base.Print();
        }
    }
}
