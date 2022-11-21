namespace Model
{
    /// <summary>
    /// Класс сертификата
    /// </summary>
    public class DiscountСertificate : DiscountBase
    {
        /// <summary>
        /// Конструктор сертификата
        /// </summary>
        /// <param name="discount">Скидка</param>
        public DiscountСertificate(int discount) : base(discount) { }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DiscountСertificate() : this(10) { }

        /// <summary>
        /// Возвращает итоговую цену товара
        /// </summary>
        /// <param name="price">Первоначальная цена товара</param>
        /// <returns></returns>
        public override double GetResultPrice(double price)
        {
            if (price - Discount < 0)
            {
                return 0;
            }
            return price - Discount;
        }
    }
}
