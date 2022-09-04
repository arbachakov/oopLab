using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Circle : IGeoFigureble
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => _radius;
            set
            {
                CheckRadius(value);
                _radius = value;
            }
        }

        public bool CheckRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception("Радиус не может быть равен или ниже 0");
            }

            return true;
        }

        public double GetArea()
        {
            double area = Math.PI * 2 * Radius;
            return area;
        }
    }
}
