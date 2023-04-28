using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using ExtensionMethod;

namespace Pudełko
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {

        public readonly double a;
        public readonly double b;
        public readonly double c;
        public static UnitOfMeasure unitOfMeasure { get; private set; }

        public Pudelko(double a, double b, double c, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
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

            a = Math.Floor(a * 1000) / 1000;
            b = Math.Floor(b * 1000) / 1000;
            c = Math.Floor(c * 1000) / 1000;

            if (a <= 0 || b <= 0 || c <= 0 || a > 10 || b > 10 || c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Pudelko(double a, double b, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
        {
            if (unitOfMeasure == UnitOfMeasure.centimeter)
            {
                a /= 100;
                b /= 100;
            }
            else if (unitOfMeasure == UnitOfMeasure.milimeter)
            {
                a /= 1000;
                b /= 1000;
            }

            a = Math.Floor(a * 1000) / 1000;
            b = Math.Floor(b * 1000) / 1000;

            if (a <= 0 || b <= 0 || a > 10 || b > 10)
                throw new ArgumentOutOfRangeException();


            this.a = a;
            this.b = b;
            this.c = 0.1;
        }

        public Pudelko(double a, UnitOfMeasure unitOfMeasure = UnitOfMeasure.meter)
        {
            if (unitOfMeasure == UnitOfMeasure.centimeter)
            {
                a /= 100;
            }
            else if (unitOfMeasure == UnitOfMeasure.milimeter)
            {
                a /= 1000;
            }

            a = Math.Floor(a * 1000) / 1000;

            if (a <= 0 || a > 10 )
            {
                throw new ArgumentOutOfRangeException();
            }

            this.a = a;
            this.b = 0.1;
            this.c = 0.1;
        }

        public Pudelko(UnitOfMeasure? unitOfMeasure = UnitOfMeasure.meter)
        {
            this.a = 0.1;
            this.b = 0.1;
            this.c = 0.1;
        }

        public double A => a; 
        public double B => b; 
        public double C => c; 

        public string ToString(string? format = "m", IFormatProvider? provider = default)
        {
            if (format is null)
                format = "m";

            switch (format.ToLower())
            {
                case "m":
                    return $"{A.ToString("F3")} {format} × {B.ToString("F3")} {format} × {C.ToString("F3")} {format}";

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


        public bool Equals(Pudelko? other)
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

        public static bool operator ==(Pudelko m1, Pudelko m2) => m1.Equals(m2);

        public static bool operator !=(Pudelko m1, Pudelko m2) => !m1.Equals(m2);

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double[] pudelko1 = { p1.A, p1.B, p1.C };
            double[] pudelko2 = { p2.A, p2.B, p2.C };
            Array.Sort(pudelko1);
            Array.Sort(pudelko2);

            double x, y, z;
            x = pudelko1[0] + pudelko2[0];
            if (pudelko1[1] > pudelko2[1])
                y = pudelko1[1];
            else
                y = pudelko2[1];
            if (pudelko1[2] > pudelko2[2])
                z = pudelko1[2];
            else
                z = pudelko2[2];

            return new Pudelko(x, y, z);
        }

        public static explicit operator double[](Pudelko pudelko) => new double[] { pudelko.A, pudelko.B, pudelko.C };
        public static implicit operator Pudelko((int a, int b, int c)krawedzie) => new Pudelko((double)krawedzie.a/1000, (double)krawedzie.b/1000, (double)krawedzie.c/1000);

        private double[] array = new double[3];
        public double this[int i]
        { get
            {
                if (i < 0 || i >= array.Length)
                    throw new IndexOutOfRangeException("Index out of range");
                if (i == 0)
                    return A;
                else if (i == 1)
                    return B;
                else
                    return C;
            }
        }

        public IEnumerator<double> GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => array.GetEnumerator();

        public static Pudelko Parse(string pudelkoString)
        {
            var lengths = pudelkoString.Split(' ');

            UnitOfMeasure unit;

            switch (lengths[1])
            {
                case "cm":
                    unit = UnitOfMeasure.centimeter;
                    break;
                case "mm":
                    unit = UnitOfMeasure.milimeter;
                    break;
                default:
                    unit = UnitOfMeasure.meter;
                    break;
            }
            return new Pudelko(double.Parse(lengths[0]), double.Parse(lengths[3]), double.Parse(lengths[3]), unit);
        }
    }
}

