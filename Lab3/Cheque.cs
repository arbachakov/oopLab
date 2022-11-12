﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

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
             double discountedCost) //, double benefit
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
                 _benefit = Math.Round(GetBenefit(Cost, DiscountedCost), 2);
             }
         }

         /// <summary>
         /// Проверка тела чека
         /// </summary>
         /// <param name="name">Тело чека</param>
         /// <returns></returns>
        private bool CheckChequeBody(string name)
         {
             if (string.IsNullOrWhiteSpace(name) || name == "NaN") 
             {
                throw new Exception("The body of cheque is not specified");
             }

             return true;
         }

         /// <summary>
         /// Проверка значения
         /// </summary>
         /// <param name="value"></param>
         /// <returns></returns>
        private bool CheckValue(double value)
        {
            if (value < 0 || double.IsNaN(value))
            {
                throw new Exception
                ("This value cannot be less than 0 or NaN");
            }

            return true;
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
             foreach (var product in products)
             {
                 if (product != products[products.Count - 1])
                 {
                     result += product.InfoProduct() + "\n";
                 }
                 else
                 {
                     result += product.InfoProduct();
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
            
            for (int i = 0; i < _random.Next(1, 5); i++)
            {
                 Product product = Product.GetRandomProduct();
                 products.Add(product);
            }
            string body = "";
            double costs = 0;
            
            foreach (var product in products)
            {
                if (product != products[products.Count - 1])
                {
                    body += product.InfoProduct() + "\n";
                    costs += product.GetCost();
                }
                else
                {
                    body += product.InfoProduct();
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
                DiscountСertificate disCert = new DiscountСertificate(_random.Next(1, 100));
                list.Add(disCert);
            }

            double benefit = list[0].GetResultPrice(costs);
            DateTime date = RandomDay();
            Cheque cheque = new Cheque(body, costs, benefit);
            cheque.Date = RandomDay();
            return cheque;
        }
     }
}
