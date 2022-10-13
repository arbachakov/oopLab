using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс параллелепипеда
    /// </summary>
    public class Rectangle
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
        /// Конструктор параллелепипеда
        /// </summary>
        /// <param name="sideA">Сторона А</param>
        /// <param name="sideB">Сторона Б</param>
        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
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
        /// Свойства стороны Б
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
        /// Проверка сторон
        /// </summary>
        /// <param name="side">Размер стороны</param>
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
        /// Возвращает площадь
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double area = SideA * SideB;
            return area;
        }


    }
}
