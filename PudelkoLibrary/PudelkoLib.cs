using System;
using System.Collections.Generic;
using System.Text;
using PudelkoLibrary.Enums;

namespace PudelkoLibrary
{
    public sealed class Pudelko //: IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }

        private double a = 0.1;
        private double b = 0.1;
        private double c = 0.1;
        public Pudelko (double a = 0.1, double? b = null, double? c = null,  UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.a = ToMetres(a, unit);
            if (b != null) { this.b = ToMetres(b, unit); }
            if(c != null) { this.c = ToMetres(c, unit); }
            
        }
        
        public double ToMetres(double size = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            switch (unit)
            {
                case UnitOfMeasure.meter: return size;
                case UnitOfMeasure.centimeter: return Math.Truncate(size * 100) / 100;
                case UnitOfMeasure.milimeter: return Math.Truncate(size * 1000) / 1000;
                default: throw new ArgumentException("");
            }
        }

        }
        public override string ConvertToString(string format = "m")
        {
            switch (format)
            {
            case "mm": return A / 1000 + "mm x " + B / 1000 + "mm x " + C / 1000 + "mm";
            case "cm": return A / 100 + "cm x " + B / 100 + "cm x " + C / 100 + "cm";
            case "m": return A + "m x " + B + "m x " + C + "m";
            default: throw new ArgumentException("");
             }
        }

    }
}
