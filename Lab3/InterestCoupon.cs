using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс круга
    /// </summary>
    public class InterestCoupon : IDiscountable
    {
        /// <summary>
        /// Процент
        /// </summary>
        private double _percent;

        /// <summary>
        /// Конструктор процентного купона
        /// </summary>
        /// <param name="percent">Процент</param>
        public InterestCoupon(double percent)
        {
            Percent = percent;
        }

        /// <summary>
        /// Свойства круга
        /// </summary>
        public double Percent
        {
            get => _percent;
            set
            {
                CheckPercent(value);
                _percent = value;
            }
        }

        /// <summary>
        /// Проверка значения процента
        /// </summary>
        /// <param name="percent">Процент</param>
        /// <returns></returns>
        public bool CheckPercent(double percent)
        {
            if (percent <= 0)
            {
                throw new Exception("Процент скидки не может быть равен или ниже 0");
            }

            return true;
        }

        
        /// <summary>
        /// Возвращает итоговую цену товара
        /// </summary>
        /// <param name="price">Первоначальная цена товара</param>
        /// <returns></returns>
        public double GetResultPrice(double price)
        {
            return price - price * Percent / 100;
        }
    }
}
