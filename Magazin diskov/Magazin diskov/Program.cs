using System;
using System.Collections.Generic;
using System.Linq;

namespace Magazin_diskov
{
    public interface IStoreItem
    {
        public double Price { get; set; }
        public void DiscountPrice(int percent);
    }
    public class Disk : IStoreItem
    {
        protected string n, g;
        protected int burnCount;
        public Disk(string n, string g)
        {
            this.n = n;
            this.g = g;
        }
        public virtual int DiskSize
        {
            get { return 0; }
        }

        public double Price { get; set; }

        public virtual void Burn(params string[] v)
        {

        }

        public void DiscountPrice(int p)
        {
            Price *= Convert.ToDouble(100 - p) / 100.0;
        }

        public virtual string ToString()
        {
            return "";
        }
    }
    public class Audio : Disk
    {
        protected string artist, rS;
        protected int sN;
        public Audio(string artist, string rS, int sN, string n, string g) : base(n, g)    
        {
            this.artist = artist;
            this.rS = rS;
            this.sN = sN;
        }
        public string Name
        {
            get { return n; }
        }
        public override int DiskSize
        {
            get { return sN * 8; }
        }
        public override void Burn(params string[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        n = v[i];
                        break;
                    case 1:
                        g = v[i];
                        break;
                    case 2:
                        artist = v[i];
                        break;
                    case 3:
                        rS = v[i];
                        break;
                    case 4:
                        int.TryParse(v[i], out sN);
                        break;
                }
            }
            burnCount++;
        }
        public override string ToString()
        {
            return n + " " + g + " " + artist + " " + rS + " " + sN + " " + burnCount;
        }
    }
    public class DVD : Disk
    {
        protected string p, fC;
        protected int mC;
        public DVD(string p, string fC, int mC, string n, string g) : base(n, g)
        {
            this.p = p;
            this.fC = fC;
            this.mC = mC;
        }
        public string Name
        {
            get { return n; }
        }
        public override int DiskSize
        {
            get { return mC / 64 * 2; }
        }
        public override void Burn(params string[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        n = v[i];
                        break;
                    case 1:
                        g = v[i];
                        break;
                    case 2:
                        p = v[i];
                        break;
                    case 3:
                        fC = v[i];
                        break;
                    case 4:
                        int.TryParse(v[i], out mC);
                        break;
                }
            }
            burnCount++;
        }
        public override string ToString()
        {
            return n + " " + g + " " + p + " " + fC + " " + mC + " " + burnCount;
        }
    }
    public class Store
    {
        private string sN, ad;
        private List<Audio> au = new List<Audio>();
        private List<DVD> disk = new List<DVD>();
        public Store(string sN, string ad)
        {
            this.sN = sN;
            this.ad = ad;
        }
        public List<Audio> GetAudios
        {
            get { return au; }
            set { au = value; }
        }
        public List<DVD> GetDVDs
        {
            get { return disk; }
            set { disk = value; }
        }
        public virtual string ToString()
        {
            string str = "";
            foreach (Audio a in au)
            {
                str += a.ToString() + '\n';
            }
            foreach (DVD d in disk)
            {
                str += d.ToString() + '\n';
            }
            return str.Trim('\n');
        }
        public static Store operator +(Store s, Audio v)
        {
            s.au.Add(v);
            return s;
        }
        public static Store operator -(Store s, Audio v)
        {
            s.au.Remove(v);
            return s;
        }
        public static Store operator +(Store s, DVD v)
        {
            s.disk.Add(v);
            return s;
        }
        public static Store operator -(Store s, DVD v)
        {
            s.disk.Remove(v);
            return s;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Store s = new Store("Mvideo", "Shopping Centre Europolis");
            s += new Audio("Tommy Ice", "USA", 26, "Forever", "Hip-Hop");
            s += new Audio("Tommy Ice", "USA", 26, "You & me", "Hip-Hop");
            s += new Audio("Tommy Ice", "USA", 26, "gelato", "Hip-Hop");
            s += new DVD("Pirates of the Caribbean", "USA", 55, " Pirates of the Caribbean: On Stranger Tides", "Adventure");
            s += new DVD("Pirates of the Caribbean", "USA", 55, "Pirates of the Caribbean: Dead Man's Chest", "Adventure");
            s += new DVD("Pirates of the Caribbean", "USA", 55, "Pirates of the Caribbean: At World’s End", "Adventure");
            s.GetAudios[0].Burn(new string[] { "I'm so sorry", "Rap", "Imagine Dragons", "USA", "65" });
            Console.WriteLine(s.ToString());
            foreach (Audio a in s.GetAudios)
            {
                Console.WriteLine(a.Name + a.DiskSize);
            }
            foreach (DVD d in s.GetDVDs)
            {
                Console.WriteLine(d.Name + d.DiskSize);
            }
        }
    }
}
