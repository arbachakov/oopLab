using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс круга
    /// </summary>
    public class Circle : IGeoFigureble
    {
        /// <summary>
        /// Радиус
        /// </summary>
        private double _radius;

        /// <summary>
        /// Конструктор Круга
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Свойства круга
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

        /// <summary>
        /// Проверка радиуса
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public bool CheckRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new Exception("Радиус не может быть равен или ниже 0");
            }

            return true;
        }

        /// <summary>
        /// Возвращает площадь круга
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double area = Math.PI * 2 * Radius;
            return area;
        }
    }
}
