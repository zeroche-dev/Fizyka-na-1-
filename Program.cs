using System;
using System.Collections.Generic;

namespace Automatyzacja_kurwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double[] measures = { 80.4f, 76.03f, 71.98f, 67.53f, 62.59f, 57.65f, 100.0f, 85.68f, 89.40f, 93.60f, };
            double[] string_l = { 100, 90, 80, 70, 60, 50, 145, 110, 120, 130 };
            List<double> times = new List<double>();
            List<double> time_pow = new List<double>();

            for (int i = 0; i < measures.Length; i++)
            {
                double time = measures[i] / 40;
                times.Add(time);
                time_pow.Add(Math.Pow(time, 2.0f));
                Console.WriteLine("Czas jednego dragania T dla l ({0} cm):  {1}s", string_l[i], time);
            }

            for (int i = 0; i < measures.Length; i++)
            {
                Console.WriteLine("Tkwadrat dla l ({0} cm):  {1}s kwadrat", string_l[i], time_pow[i]);
            }

    
            List<double> lowervals = new List<double>();
            List<double> uppervals = new List<double>();


            for (int i = 0; i < measures.Length; i++)
            {


                double lowert = Math.Pow(times[i] - 0.025f, 2);
                double uppert = Math.Pow(times[i] + 0.025f, 2);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Mniejsza wartosc dla l ({0} cm):  {1}s kwadrat", string_l[i], lowert);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wieksza wartosc dla l ({0} cm):  {1}s kwadrat", string_l[i], uppert);
            }

            List<double> gs = new List<double>();

            for (int i = 0; i < measures.Length; i++)
            {


                double g = ((4 * Math.Pow(3.14, 2) * string_l[i]) / time_pow[i]) / 100;

                gs.Add(g);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("G dla l ({0} cm):  {1} m/s kwadrat", string_l[i], g);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("-------");
            }
            double gt = 0;
            foreach (double g in gs) { 
                gt += g;
            }
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("G {0} m/s kwadrat", gt/measures.Length);
            Console.WriteLine("-------");






        }
    }
}
