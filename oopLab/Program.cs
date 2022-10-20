using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Lab3;

namespace oopLab
{
    //TODO: RSDN (+)
    /// <summary>
    /// Класс Программ 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: показать полиморфизм (+)
            
            
            //TODO: добавить ввод с клавиатуры (+)

            Console.WriteLine("Введите процент скидки для процентного купона");
            InterestCoupon coupon = new InterestCoupon(double.
                Parse(Console.ReadLine()));
            Console.WriteLine("Введите стоимость товаров");

            //double resultPrice = coupon.GetResultPrice(double.Parse(Console.ReadLine()));

            //Console.WriteLine($"Итоговая стоимость товаров будет равна: {resultPrice}");

            Console.WriteLine($"Итоговая стоимость товаров будет равна: " +
                              $"{coupon.GetResultPrice(double.Parse(Console.ReadLine()))}");

            Console.WriteLine("Введите величину скидки сертификата");

            Сertificate certificate = new Сertificate(double.
                Parse(Console.ReadLine()));

            Console.WriteLine("Введите стоимость товаров");

            Console.WriteLine($"Итоговая стоимость товаров будет равна: " +
                              $"{certificate.GetResultPrice(double.Parse(Console.ReadLine()))}");
            Console.ReadKey();
        }
    }
}
