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


            //Console.WriteLine("Введите процент скидки для процентного купона");
            //InterestCoupon coupon = new InterestCoupon(double.
            //    Parse(Console.ReadLine()));
            //Console.WriteLine("Введите стоимость товаров");

            ////double resultPrice = coupon.GetResultPrice(double.Parse(Console.ReadLine()));

            ////Console.WriteLine($"Итоговая стоимость товаров будет равна: {resultPrice}");

            //Console.WriteLine($"Итоговая стоимость товаров будет равна: " +
            //                  $"{coupon.GetResultPrice(double.Parse(Console.ReadLine()))}");

            //Console.WriteLine("Введите величину скидки сертификата");

            //DiscountСertificate certificate = new DiscountСertificate(double.
            //    Parse(Console.ReadLine()));

            //Console.WriteLine("Введите стоимость товаров");

            //Console.WriteLine($"Итоговая стоимость товаров будет равна: " +
            //                  $"{certificate.GetResultPrice(double.Parse(Console.ReadLine()))}");
            //Console.ReadKey();

            DiscountСertificate discountСertificate = new DiscountСertificate();

            //Action actionDiscount = () =>
            //{
            //    discountСertificate.Discount = double.Parse(Console.ReadLine());
            //};

            InterestCoupon interestCoupon = new InterestCoupon();

            ActionHandler(GetAction(discountСertificate), "Enter the discount amount for the certificate");
            ActionHandler(GetAction(interestCoupon), "Enter the discount amount for the certificate");

            List<DiscountBase> list = new List<DiscountBase>() { discountСertificate, interestCoupon };
            foreach (var discount in list)
            {
                Console.WriteLine(discount.GetResultPrice(1000));
            }

            Console.ReadLine();
        }

        public static Action GetAction(DiscountBase discountBase)
        {
            Action actionDiscount = () =>
            {
                discountBase.Discount = double.Parse(Console.ReadLine());
            };

            return actionDiscount;
        }

        /// <summary>
        /// Активирует событие 
        /// </summary>
        /// <param name="action">Событие</param>
        /// <param name="messege">Сообщение в консоль</param>
        public static void ActionHandler(Action action, string messege)
        {
            while (true)
            {
                Console.WriteLine(messege);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again, please");
                }
            }
        }
    }
}
