using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс чека
    /// </summary>
     public class Cheque
     {
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
         /// <param name="benefit">Выгода</param>
         public Cheque(string chequeBody, double cost, 
             double discountedCost, double benefit)
         {
             ChequeBody = chequeBody;
             Cost = cost;
             DiscountedCost = discountedCost;
             Benefit = benefit;
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
                _benefit = value;
             }
         }

         /// <summary>
         /// Проверка тела чека
         /// </summary>
         /// <param name="name">Тело чека</param>
         /// <returns></returns>
        private bool CheckChequeBody(string name) 
         {
             if (name == "")
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
            if (value < 0)
            {
                throw new Exception
                ("This value " +
                 "cannot be less than 0");
            }

            return true;
        }

         private double SetDiscountedCost(double discountedCost)
         {
             if (discountedCost <= 0)
             {
                 return 0;
             }

             return 0;
         }

     }
}
