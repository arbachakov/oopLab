using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс сертификата
    /// </summary>
    public class Сertificate : IDiscountable
    {
        /// <summary>
        /// Скидка по сертификату
        /// </summary>
        private double _discount;

        /// <summary>
        /// Конструктор сертификата
        /// </summary>
        /// <param name="discount">Скидка</param>
        public Сertificate(double discount)
        {
            Discount = discount;
        }

        /// <summary>
        /// Свойство скидки
        /// </summary>
        public double Discount
        {
            get => _discount;
            set
            {
                CheckDiscount(value);
                _discount = value;
            }
        }
        
        /// <summary>
        /// Проверка скидки
        /// </summary>
        /// <param name="discount">Скидка</param>
        /// <returns></returns>
        public bool CheckDiscount(double discount)
        {
            if (discount <= 0)
            {
                throw new Exception("Скидка не может быть меньше или равна 0");
            }

            return true;
        }


        public double GetResultPrice(double price)
        {
            return price - Discount;
        }
    }
}
