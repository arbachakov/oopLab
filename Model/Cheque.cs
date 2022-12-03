using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс чека
    /// </summary>
     public class Cheque
     {   
         /// <summary>
         /// Дата
         /// </summary>
         private DateTime _date;

         /// <summary>
         /// Тело чека
         /// </summary>
         private string _chequeBody;

         /// <summary>
         /// Стоимость товаров
         /// </summary>
         private double _cost;

         /// <summary>
         /// Стоимость товаров со скидкой
         /// </summary>
         private double _discountedCost;

         /// <summary>
         /// Выгода
         /// </summary>
         private double _benefit;

         /// <summary>
         /// Конструктор чека
         /// </summary>
         /// <param name="chequeBody">Тело чека</param>
         /// <param name="cost">Стоимость</param>
         /// <param name="discountedCost">Стоимость со скидкой</param>
         public Cheque(string chequeBody, double cost, 
             double discountedCost) 
         {
             _date = DateTime.Now;
             ChequeBody = chequeBody;
             Cost = cost;
             DiscountedCost = discountedCost;
             Benefit = GetBenefit(Cost, DiscountedCost);
         }

         /// <summary>
         /// Свойство даты
         /// </summary>
         public DateTime Date
         {
             get => _date;
             set
             {
                 _date = value;
             }
         }

         /// <summary>
         /// Свойство тела чека
         /// </summary>
         public string ChequeBody
         {
             get => _chequeBody;
             set
             {
                 CheckChequeBody(value);
                 _chequeBody = value;
             }
         }

         /// <summary>
         /// Свойство стоимости
         /// </summary>
         public double Cost
         {
             get => _cost;
             set
             {
                 CheckValue(value);
                 _cost = value;
             }
         }

         /// <summary>
         /// Свойство стоимости со скидкой
         /// </summary>
         public double DiscountedCost
         {
             get => _discountedCost;
             set
             {
                 _discountedCost = SetDiscountedCost(value);
             }
         }

         /// <summary>
         /// Выгода
         /// </summary>
         public double Benefit
         {
             get => _benefit;
             set
             {
                 CheckValue(value);
                 _benefit = GetBenefit(Cost, DiscountedCost);
             }
         }

         /// <summary>
         /// Проверка тела чека
         /// </summary>
         /// <param name="chequeBody">Тело чека</param>
         /// <returns></returns>
         private void CheckChequeBody(string chequeBody)
         {
             if (string.IsNullOrWhiteSpace(chequeBody) || chequeBody == "NaN") 
             {
                throw new Exception("The body of cheque is not specified");
             }
             int amount = new Regex("\n").Matches(chequeBody).Count;
             if (amount > 19)
             {
                 throw new Exception("The body of the receipt consists of more than 20 lines");
            }
            
         }

         /// <summary>
         /// Проверка значения
         /// </summary>
         /// <param name="value"></param>
         /// <returns></returns>
         private void CheckValue(double value)
        {
            if (value < 0 || double.IsNaN(value))
            {
                throw new Exception
                ("This value cannot be less than 0 or NaN");
            }
        }

         /// <summary>
         /// Возвращает стоимость со скидкой
         /// </summary>
         /// <param name="discountedCost"></param>
         /// <returns></returns>
         private double SetDiscountedCost(double discountedCost)
         {
             if (discountedCost <= 0)
             {
                 return 0;
             }

             return discountedCost;
         }

         /// <summary>
         /// Возвращает выгоду
         /// </summary>
         /// <param name="cost"></param>
         /// <param name="discountedCost"></param>
         /// <returns></returns>
         private double GetBenefit(double cost, double discountedCost)
         {
             if (cost - discountedCost <= 0)
             {
                 return cost;
             }

             return cost - discountedCost;
         }

         /// <summary>
         /// Генератор случайных дат
         /// </summary>
         /// <returns></returns>
         private static DateTime RandomDay()
         { 
             Random random = new Random(); 
             DateTime start = new DateTime(2020, 1, 1, 0, 0,0);
             int range = (DateTime.Today - start).Days;
             return start.AddDays(random.Next(range));
         }

         /// <summary>
         /// Возвращает информацию обо всех продуктах
         /// </summary>
         /// <returns></returns>
         public static string GetProductsInfo(BindingList<Product> products)
         {
             string result = "";
             int i = 1;
             foreach (var product in products)
             {
                 if (product != products[products.Count - 1])
                 {
                     result += $"{i}) " + product.InfoProduct() + "\n";
                     i++;
                 }
                 else
                 {
                     result += $"{i}) " + product.InfoProduct();
                 }
             }
             return result;
         }

         /// <summary>
         /// Возвращает стоимость всей покупки
         /// </summary>
         /// <returns></returns>
         public static double GetProductsCost(BindingList<Product> products)
         {
             double sum = 0;
             foreach (var product in products)
             {
                 sum += product.GetCost();
             }

             return sum;
         }

        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random _random = new Random();

         /// <summary>
         /// Возвращает случайный чек
         /// </summary>
         /// <returns></returns>
        public static Cheque GetRandomCheque()
        {
            List<Product> products = new List<Product>();
            
            for (int i = 0; i < _random.Next(1, 21); i++)
            {
                 Product product = Product.GetRandomProduct();
                 products.Add(product);
            }
            string body = "";
            double costs = 0;
            int index = 1;
            foreach (var product in products)
            {
                if (product != products[products.Count - 1])
                {
                    body += $"{index}) " + product.InfoProduct() + "\n";
                    costs += product.GetCost();
                    index++;
                }
                else
                {
                    body += $"{index}) " + product.InfoProduct();
                    costs += product.GetCost();
                }
            }

            List<DiscountBase> list = new List<DiscountBase>();
            if (_random.Next(0, 1) == 0)
            {
                InterestCoupon coupon = new InterestCoupon(_random.Next(1, 50));
                list.Add(coupon);
            }
            else
            {
                DiscountСertificate disCert = new DiscountСertificate(_random.Next(1, 1000));
                list.Add(disCert);
            }

            double benefit = list[0].GetResultPrice(costs);
            Cheque cheque = new Cheque(body, costs, benefit);
            cheque.Date = RandomDay();
            return cheque;
        }
     }
}
