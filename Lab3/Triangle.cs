using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Triangle : IGeoFigureble
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            ExistTriangle();
        }
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
        public double SideC
        {
            get => _sideC;
            set
            {
                CheckSide(value);
                _sideC = value;
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
        private double GetPerimetr()
        {
            double perimetr = SideA + SideB + SideC;
            return perimetr;
        }
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
