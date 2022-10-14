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
            InterestCoupon coupon1 = new InterestCoupon(45);
            Сertificate certifikate1 = new Сertificate(150);

            Console.WriteLine(coupon1.GetResultPrice(100));
            Console.WriteLine(certifikate1.GetResultPrice(1000));

            Console.ReadKey();
        }
    }
}
