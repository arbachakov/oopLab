using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс треугольника
    /// </summary>
    public class Triangle : IGeoFigureble
    {
        /// <summary>
        /// Сторона А
        /// </summary>
        private double _sideA;

        /// <summary>
        /// Сторона Б
        /// </summary>
        private double _sideB;

        /// <summary>
        /// Сторона Ц
        /// </summary>
        private double _sideC;

        /// <summary>
        /// Конструктор треугольника
        /// </summary>
        /// <param name="sideA">Сторона А</param>
        /// <param name="sideB">Сторона Б</param>
        /// <param name="sideC">Сторона Ц</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            ExistTriangle();
        }

        /// <summary>
        /// Проверка на существование тругольника
        /// </summary>
        /// <returns></returns>
        public bool ExistTriangle()
        {
        
          if ((SideA + SideB > SideC ||
               SideA + SideC > SideB ||
               SideB + SideC > SideA) == false)
          {
              throw new Exception("Такого треугольника не существует");
          }
        
          return true;
        }

        /// <summary>
        /// Свойство стороны А
        /// </summary>
        public double SideA
        {
            get => _sideA;
            set
            {
                CheckSide(value);
                _sideA = value;
            }
        }

        /// <summary>
        /// Свойство стороны Б
        /// </summary>
        public double SideB
        {
            get => _sideB;
            set
            {
                CheckSide(value);
                _sideB = value;
            }
        }

        /// <summary>
        /// Свойство стороны Ц
        /// </summary>
        public double SideC
        {
            get => _sideC;
            set
            {
                CheckSide(value);
                _sideC = value;
            }
        }

        /// <summary>
        /// Проверка длины стороны
        /// </summary>
        /// <param name="side">Длина стороны</param>
        /// <returns></returns>
        public bool CheckSide(double side)
        {
            if (side <= 0)
            {
                throw new Exception("Сторона не может быть меньше или равна 0");
            }

            return true;
        }

        /// <summary>
        /// Возвращает периметр
        /// </summary>
        /// <returns></returns>
        private double GetPerimetr()
        {
            double perimetr = SideA + SideB + SideC;
            return perimetr;
        }

        /// <summary>
        /// Возвращает площадь треугольника
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double area = Math.Sqrt(
                GetPerimetr() / 2 * 
                (GetPerimetr() / 2 - SideA) *
                (GetPerimetr() / 2 - SideB) *
                (GetPerimetr() / 2 - SideC));
            return area;
        }
    }
}
