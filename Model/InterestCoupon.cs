using System;

namespace Model
{
    /// <summary>
    /// Класс процентного купона
    /// </summary>
    public class InterestCoupon : DiscountBase
    {
        //TODO: RSDN (+)
        /// <summary>
        /// Максимальный размер скидки
        /// </summary>
        public const int MaxDiscount = 100;
        
        /// <summary>
        /// Конструктор процентного купона
        /// </summary>
        /// <param name="discount">Процент</param>
        public InterestCoupon(int discount) : base(discount) { }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InterestCoupon() : this(10) { }

        /// <summary>
        /// Проверка скидки
        /// </summary>
        /// <param name="discount"></param>
        /// <returns></returns>
        protected override bool CheckDiscount(int discount)
        {
            if (discount <= MinDiscount || discount > MaxDiscount)
            {
                throw new Exception($"The discount cannot be less " + 
                  $"than or equal to {MinDiscount} " +
                  $"or more than {MaxDiscount}");
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
