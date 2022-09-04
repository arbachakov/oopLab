using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Circle : IGeoFigureble
    {
        private double _radius;

        public Circle (double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                CheckRadius(value);
                _radius = value;
            }
        }

        private bool CheckRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception("Радиус не может быть равен 0 или отрицательным числом");
            }

            return true;
        }

        public double getArea()
        {
            double area = Math.PI * _radius * 2;
            return area;
        }
    }
}
