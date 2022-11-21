using System;
using System.Collections.Generic;
using Lab3;

namespace View
{
    /// <summary>
    /// Класс Program 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            DiscountСertificate discountСertificate = new DiscountСertificate();

            InterestCoupon interestCoupon = new InterestCoupon();

            ActionHandler(GetAction(discountСertificate), 
                "Enter the discount amount for the certificate");
            ActionHandler(GetAction(interestCoupon), 
                "Enter the discount amount for the interest coupon");

            List<DiscountBase> list = new List<DiscountBase>()
            {
                discountСertificate, 
                interestCoupon
            };

            foreach (var discount in list)
            {
                switch (discount)
                {
                    case InterestCoupon _:
                    {
                        Console.WriteLine("Real price including discount coupon:");
                        Console.WriteLine(discount.GetResultPrice(1000));
                        break;
                    }
                    case DiscountСertificate _:
                    {
                        Console.WriteLine("Real price including discount certificate:");
                        Console.WriteLine(discount.GetResultPrice(1000));
                        break;
                    }
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Возвращает action, который задает скидку купону или сертификату
        /// </summary>
        /// <param name="discountBase">Купон или сертификат</param>
        /// <returns></returns>
        public static Action GetAction(DiscountBase discountBase)
        {
            Action actionDiscount = () =>
            {
                discountBase.Discount = double.Parse(Console.ReadLine());
            };

            return actionDiscount;
        }

        /// <summary>
        /// Возвращает action 
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="message">Сообщение в консоль</param>
        public static void ActionHandler(Action action, string message)
        {
            while (true)
            {
                Console.WriteLine(message);
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
