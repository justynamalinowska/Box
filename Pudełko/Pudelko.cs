using System;
namespace Pudełko
{
    public class Pudelko
    {

        public double A { get => A; set => A = (value > 0 && value < 10 && UnitOfMeasure
                != UnitOfMeasure.meter) ? A = Math.Round(value, 3) : throw new ArgumentOutOfRangeException();}
        public double B { get => B; set => B = (value > 0 && value < 10 && UnitOfMeasure
                != UnitOfMeasure.meter) ? B = Math.Round(value, 3) : throw new ArgumentOutOfRangeException();}
        public double C { get => C; set => C = (value > 0 && value < 10 && UnitOfMeasure
                != UnitOfMeasure.meter) ? C = Math.Round(value, 3) : throw new ArgumentOutOfRangeException();}
        public UnitOfMeasure UnitOfMeasure { get; set; }


        public Pudelko()
		{
            A = 10;
            B = 10;
            C = 10;
            UnitOfMeasure = UnitOfMeasure.meter;
        }

        public Pudelko(double a, double b, double c, UnitOfMeasure unitOfMeasure)
        {
            A = a;
            B = b;
            C = c;
            UnitOfMeasure = unitOfMeasure;
        }




		}
	}	
}

