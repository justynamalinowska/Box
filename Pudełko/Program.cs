using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;
using ExtensionMethod;

namespace Pudełko
{
    public delegate int Comparison<Pudelko>(Pudelko p1, Pudelko p2);

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
            Console.WriteLine(p2==p5);
            Console.WriteLine(p2!=p4);
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p5);
            Console.WriteLine(p4 + p5);
            Console.WriteLine((p4+p5).Objetosc);

            Pudelko p6 = (2100, 1000, 3050);
            Console.WriteLine(p6);
            double[] tablica = (double[])p6;
            Console.WriteLine(tablica[0] + " " + tablica[1] + " " + tablica[2]);

            Console.WriteLine(p6[0]);
            foreach (var x in p6)
            {
                Console.WriteLine(x);
            }

            Pudelko p7 = new Pudelko(2.5, 9.321);
            Console.WriteLine(p7.ToString());

            Pudelko p10 = new Pudelko(1, 2, 3);
            Pudelko p20 = new Pudelko(4, 5, 6);

            Console.WriteLine(p10+p20);

            Pudelko pudelko = new Pudelko(2, 3, 4);
            Console.WriteLine(pudelko.Kompresuj());

            List<Pudelko> boxes = new List<Pudelko>();
            boxes.Add(new Pudelko(2, 3, 9));
            boxes.Add(new Pudelko(1.5, 2, 3));
            boxes.Add(new Pudelko(8, 4, 5));
            boxes.Add(new Pudelko(1, 2, 2.5));
            boxes.Add(new Pudelko(3, 6, 4));


            Console.WriteLine("Nieposortowane");
            foreach (Pudelko box in boxes)
                Console.WriteLine(box);

            boxes.Sort(delegate (Pudelko p1, Pudelko p2)
            {
                if (p1.Objetosc < p2.Objetosc) return -1;
                else if (p1.Objetosc > p2.Objetosc) return 1;

                else
                {
                    if (p1.Pole < p2.Pole) return -1;
                    else if (p1.Pole > p2.Pole) return 1;

                    else
                    {
                        if ((p1.A + p1.B + p1.C) < (p2.A + p2.B + p2.C)) return -1;
                        else if ((p1.A + p1.B + p1.C) > (p2.A + p2.B + p2.C)) return 1;
                        else return 0;
                    }
                }
            });

            Console.WriteLine("Posortowane");
            foreach (Pudelko box in boxes)
                Console.WriteLine(box);

            Console.ReadKey();
        }

    }
}