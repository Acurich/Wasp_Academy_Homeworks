using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2
{
    public class MCCLine : Line
    {
        public MCCLine(string n, ConsoleColor color) : base(n, color)
        {

        }

        public override void PrintLine()
        {
            Console.ForegroundColor = Color;
            Console.Write("MCC ");
            base.PrintLine();
        }
    }
}
