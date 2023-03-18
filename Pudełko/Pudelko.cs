﻿using System;
namespace Pudełko
{
    public class Pudelko : IFormattable, IEquatable<Pudelko>
    {

        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public Pudelko(double a = 0.01, double b = 0.01, double c = 0.01, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
        {
            if (unitOfMeasure == UnitOfMeasure.centimeter)
            {
                a /= 100;
                b /= 100;
                c /= 100;
            }
            else if (unitOfMeasure == UnitOfMeasure.milimeter)
            {
                a /= 1000;
                b /= 1000;
                c /= 1000;
            }

            if (a <= 0 || b <= 0 || c <= 0 || a > 10 || b > 10 || c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A => Math.Round(a, 3);
        public double B => Math.Round(b, 3);
        public double C => Math.Round(c, 3);

        public override string ToString()
        {
            return $"{A.ToString("F3")} m × {B.ToString("F3")} m × {C.ToString("F3")} m";
        }

        public string ToString(string format)
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

        public bool Equals(Pudelko other)
        {
            if (other is null)
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;

            double[] p1 = { A, B, C };
            Array.Sort(p1);
            double[] p2 = { other.A, other.B, other.C };
            Array.Sort(p2);

            return (p1[0] == p2[0] && p1[1] == p2[1] && p1[2] == p2[2]);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Pudelko)
                return Equals((Pudelko)obj);
            else
                return false;
        }

        public override int GetHashCode() => (A, B, C).GetHashCode();

    }	
}

