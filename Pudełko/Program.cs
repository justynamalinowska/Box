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
            Pudelko p1 = new Pudelko(54, 54, 54, UnitOfMeasure.centimeter);
            Console.WriteLine(p1.ToString());

            Pudelko p2 = new Pudelko(0.7, 42, unitOfMeasure: UnitOfMeasure.centimeter);
            Console.WriteLine(p2.ToString());

            Pudelko p3 = new Pudelko(19.3, 9, 15, UnitOfMeasure.centimeter);
            Console.WriteLine(p3.ToString());

            Pudelko p4 = new Pudelko(4, 5, 6);
            Console.WriteLine(p4.ToString());

            Pudelko p5 = new Pudelko(2, 3, 1, UnitOfMeasure.meter);
            Console.WriteLine(p5.ToString());

            Pudelko p10 = new Pudelko(3, 1, 2, UnitOfMeasure.meter);
            Console.WriteLine(p10.ToString());

            //ToString
            Console.WriteLine();
            Console.WriteLine("ToString");
            Console.WriteLine(p5.ToString("cm"));
            Console.WriteLine(p5.ToString("mm"));
            Console.WriteLine(p1.ToString(null));


            //Pole i Objętość
            Console.WriteLine();
            Console.WriteLine("Pole i objętość");
            Console.WriteLine("P = " + p1.Pole);
            Console.WriteLine("V = " + p1.Objetosc);


            //Equals
            Console.WriteLine();
            Console.WriteLine("Równość pudełek");
            Console.WriteLine(p5 == p10);
            Console.WriteLine(p1.Equals(p2));


            //dodawanie
            Console.WriteLine();
            Console.WriteLine("Dodawanie pudełek");
            Console.WriteLine(p1 + p2);


            //indexer i iterator
            Console.WriteLine();
            Console.WriteLine("Indexer i iterator");
            Console.WriteLine("p2[1] = " + p2[1]);
            Console.WriteLine("p3: ");
            foreach (var item in p3)
                Console.WriteLine(item);


            //parsowanie
            Console.WriteLine();
            Console.WriteLine("Parsowanie");
            Pudelko p7 = Pudelko.Parse("250.0 cm × 932.1 cm × 10.0 cm");
            Console.WriteLine(p5.ToString("cm"));

            //kompresja
            Console.WriteLine();
            Console.WriteLine("Kompresja");
            Pudelko p8 = p7.Kompresuj();
            Console.WriteLine(p8.ToString());

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
                if (p1.Objetosc != p2.Objetosc)
                    return (p1.Objetosc.CompareTo(p2.Objetosc));
                else
                {
                    if(p1.Pole!=p2.Pole)
                        return (p1.Pole.CompareTo(p2.Pole));
                    else
                    {
                        if((p1.A + p1.B + p1.C) != (p2.A + p2.B + p2.C))
                            return(p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C);
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