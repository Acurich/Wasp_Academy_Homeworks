using System;
using System.Collections.Generic;
using System.Text;

namespace Metro
{
    class Metro
    {
        List<Line> l;
        string c;
        public Metro(string city)
        {
            this.c = city;
            l = new List<Line>();
        }
        public string GetCity()
        {
            return c;
        }
        public void AddLine(string name, string color)
        {
            Line line = new Line(name, color);
            l.Add(line);
        }
        public Station FindStationByName(string name)
        {
            foreach (Line i in l)
            {
                if (i.GetName() == name)
                {
                    return i;
                }
            }
            return null;
        }
        public void RemoveLine(string name)
        {
            foreach (Line i in l)
            {
                if (i.GetName() == name)
                {
                    l.Remove(i);
                }
            }
        }
    }
}
