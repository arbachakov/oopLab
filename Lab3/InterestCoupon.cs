using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс процентного купона
    /// </summary>
    public class InterestCoupon : DiscountBase, IDiscountable
    {
        /// <summary>
        /// Конструктор процентного купона
        /// </summary>
        /// <param name="discount">Процент</param>
        public InterestCoupon(double discount) : base(discount) { }

        //TODO: XML
        public InterestCoupon() : this(10) { }

        //TODO: XML
        protected override bool CheckDiscount(double discount)
        {
            if (discount <= 0 || discount > 100)
            {
                throw new Exception("The discount cannot be less than or equal to 0 or more than 100");
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
