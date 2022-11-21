using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс процентного купона
    /// </summary>
    public class InterestCoupon : DiscountBase
    {
        /// <summary>
        /// Максимальная скидка
        /// </summary>
        private const int MaxDiscount = 100;

        /// <summary>
        /// Конструктор процентного купона
        /// </summary>
        /// <param name="discount">Процент</param>
        public InterestCoupon(double discount) : base(discount) { }
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InterestCoupon() : this(10) { }
        
        /// <summary>
        /// Проверка 
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        protected override bool CheckDiscount(double discount)
        {
            if (discount <= MinDiscount || discount > MaxDiscount)
            {
                throw new Exception($"The discount cannot be less" +
                     $" than or equal to {MinDiscount} or more than {MaxDiscount}");
            }

            return true;
        }

        /// <summary>
        /// Возвращает итоговую цену товара
        /// </summary>
        /// <param name="price">Первоначальная цена товара</param>
        /// <returns></returns>
        public override double GetResultPrice(double price)
        {
            return price - price * Discount / 100;
        }
    }
}
