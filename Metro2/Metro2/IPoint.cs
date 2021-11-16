using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2
{
    interface IPoint
    {
        public Station Next { get; set; }
        public Station Previous { get; set; }
        public bool Visited { get; set; }
    }
}