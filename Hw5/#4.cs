public static void Otkl()
        {
            double num = double.Parse(Console.ReadLine());
            double counter = 0;
            List<double> sp = new List<double>();
            while (num != 0)
            {
                sp.Add(num);
                counter++;
                num = double.Parse(Console.ReadLine()); 
            }
            double Sr = sp.Sum() / counter;
            double newC = counter - 1;
            double ab = 0;
            for (int i = 0; i < counter; i++)
            {
                ab = ab + Math.Pow(sp[i] - Sr, 2);
            }
            double E = Math.Sqrt(ab / newC);
            Console.WriteLine(E);
        }
