using System;
using System.Collections.Generic;

namespace Avtopark
{
    public class Car
    {
        protected string lab;
        protected int pow;
        protected int year;

        public Car(string lab, int pow, int year)
        {
            this.lab = lab;
            this.pow = pow;
            this.year = year;
        }
    }
    public class PCar : Car
    {
        private int Passazhiri;
        private Dictionary<string, int> repair;
        public PCar(string lab, int pow, int year, int Passazhiri) : base(lab, pow, year)
        {
            this.Passazhiri = Passazhiri;
            repair = new Dictionary<string, int>();

        }
        public void addBook(string repaired, int year2)
        {
            repair.Add(repaired, year2);
        }
        public int FindYear2(string n)
        {
            if (repair.ContainsKey(n)) return repair[n];
            return 0;
        }
        public void printBook()
        {
            foreach (string k in repair.Keys)
            {
                Console.Write(k + " - ");
                Console.WriteLine(repair[k]);
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            return $"Марка: {lab}\nМощность:{pow}\nГод производства: {year}\nКоличество пассажиров: {Passazhiri}\n\n";
        }
    }
    public class Truck : Car
    {
        private int ves;
        private string nSur;
        Dictionary<string, int> cargo;

        public Truck(string lab, int pow, int year, int ves, string nSur) : base(lab, pow, year)
        {
            this.ves = ves;
            this.nSur = nSur;
            cargo = new Dictionary<string, int>();
        }
        public void changeDriver(string nSur)
        {
            this.nSur = nSur;
        }
        public void addGruz(string n, int ves2)
        {
            cargo.Add(n, ves2);
        }
        public void removeCargo(string n)
        {
            if (!cargo.Remove(n)) Console.WriteLine("Нет такого груза!");
        }
        public void printCargo()
        {
            foreach (string k in cargo.Keys)
            {
                Console.Write(k + " - ");
                Console.WriteLine(cargo[k]);
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            return $"Марка: {lab}\nМощность:{pow}\nГод производства: {year}\nМаксимальная грузоподъёмность: {ves}\nФИ водителя: {nSur}\n\n";
        }
    }
    public class AutoPark
    {
        private string parkName;
        public List<Passazhiri> passengerCars;
        public List<Truck> truck;

        public AutoPark()
        {

        }
        public override string ToString()
        {
            string park = "";
            park += "ЛЕГКОВЫЕ МАШИНЫ\n";
            foreach (Passazhiri i in passengerCars)
            {
                park += i.ToString();
            }
            Console.WriteLine();
            foreach (Truck i in truck)
            {
                park += i.ToString();
            }
            return park;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

