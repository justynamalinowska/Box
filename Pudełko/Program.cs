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

            Console.ReadKey();
        }
    }
}