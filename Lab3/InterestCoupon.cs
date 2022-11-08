using System;

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

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InterestCoupon() : this(10) { }

        /// <summary>
        /// Проверка скидки
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
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
            return Math.Round((price - price * Discount / 100), 2);
        }
    }
}
