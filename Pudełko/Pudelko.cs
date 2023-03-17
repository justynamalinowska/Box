using System;
namespace Pudełko
{
    public class Pudelko : IFormattable
    {

        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public Pudelko(double a)
		{
            this.a = a;
            b = 0.01;
            c = 0.01;
            UnitOfMeasure = UnitOfMeasure.meter;
        }

        public Pudelko(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            UnitOfMeasure = UnitOfMeasure.meter;
        }

        public Pudelko(double a, double b, double c, UnitOfMeasure unitOfMeasure)
        {

            UnitOfMeasure = unitOfMeasure;

            if (unitOfMeasure==UnitOfMeasure.meter)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else if (unitOfMeasure == UnitOfMeasure.centimeter)
            {
                this.a /= 100;
                this.b /= 100;
                this.c /= 100;
            }
            else
            {
                this.a /= 1000;
                this.b /= 1000;
                this.c /= 1000;
            }

            if (this.a <= 0 || this.b <= 0 || this.c <= 0 || this.a > 10 || this.b > 10 || this.c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public double A => Math.Round(a, 3);
        public double B => Math.Round(b, 3);
        public double C => Math.Round(c, 3);

        public override string ToString()
        {
            return $"{A.ToString("F3")} m × {B.ToString("F3")} m × {C.ToString("F3")} m";
        }

        public string ToString(string format)//, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "m";
            }

            switch (format.ToLower())
            {
                case "m":
                    return ToString();

                case ("cm"):
                    return $"{A * 100:F1} {format} × {B * 100:F1} {format} × {C * 100:F1} {format}";

                case ("mm"):
                    return $"{A * 1000:F0} {format} × {B * 1000:F0} {format} × {C * 1000:F0} {format}";

                default:
                    throw new FormatException();

            }
        }

        public double Objetosc => Math.Round(a * b * c, 9);
        public double Pole => Math.Round((2 * a * b) + (2 * b * c) + (2 * c * a), 6);
    }	
}

