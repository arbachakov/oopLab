using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Rectangle
    {
        private double _sideA;
        private double _sideB;

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public double SideA
        {
            get => _sideA;
            set
            {
                CheckSide(value);
                _sideA = value;
            }
        }
        public double SideB
        {
            get => _sideB;
            set
            {
                CheckSide(value);
                _sideB = value;
            }
        }
        public bool CheckSide(double side)
        {
            if (side <= 0)
            {
                throw new Exception("Сторона не может быть меньше или равна 0");
            }

            return true;
        }

        public double GetArea()
        {
            double area = SideA * SideB;
            return area;
        }


    }
}
