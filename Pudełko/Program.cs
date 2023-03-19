using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;

namespace Pudełko
{
    class Program
    {
        public static void Main(string[] args)
        {
            Pudelko p1 = new Pudelko(2.5, 9.321, 0.1);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.ToString("m"));
            Console.WriteLine(p1.ToString("cm"));
            Console.WriteLine(p1.ToString("mm"));
            Console.WriteLine(p1.Objetosc);
            Console.WriteLine(p1.Pole);

            Pudelko p2 = new Pudelko(1, 3.05, 2.1);
            Pudelko p3 = new Pudelko(2.1, 1, 3.05);
            Pudelko p4 = new Pudelko(2100, 1000, 3050, UnitOfMeasure.milimeter);
            Pudelko p5 = new Pudelko(210, 100, 305, UnitOfMeasure.centimeter);

            Console.WriteLine(p2.Equals(p5));
            Console.WriteLine(p2.Equals(p4));
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p5);
            Console.WriteLine(p4 + p5);
            Console.WriteLine(p4.Objetosc);

            Pudelko p6 = (2100, 1000, 3050);
            Console.WriteLine(p6);
            double[] tablica = (double[])p6;
            Console.WriteLine(tablica[0] + " " + tablica[1] + " " + tablica[2]);

            Console.WriteLine(p6[0]);


            Console.ReadKey();
        }
    }
}