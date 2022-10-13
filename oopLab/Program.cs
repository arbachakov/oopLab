using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3;

namespace oopLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle krug1 = new Circle(10);
            double krugArea = krug1.GetArea();
            Console.WriteLine(krugArea);

            Triangle treugolnik = new Triangle(7, 7, 8);
            double treugArea = treugolnik.GetArea();
            Console.WriteLine(treugArea);

            Rectangle prya = new Rectangle(7, 8);
            double pArea = prya.GetArea();
            Console.WriteLine(pArea);

            Console.ReadKey();
        }
    }
}
