using System;

//TODO: Переименовать сборку
namespace Model
{
    /// <summary>
    /// Абстрактный класс скидки
    /// </summary>
    public abstract class DiscountBase
    {
        //TODO: RSDN
        /// <summary>
        /// Минимальное значение скидки
        /// </summary>
        public const int minDiscount = 0;

        /// <summary>
        /// Скидка 
        /// </summary>
        protected int _discount;

        /// <summary>
        /// Конструктор сертификата
        /// </summary>
        /// <param name="discount">Скидка</param>
        protected DiscountBase(int discount)
        {
            Discount = discount;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected DiscountBase() : this(10) { }

        /// <summary>
        /// Свойство скидки
        /// </summary>
        public int Discount
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
        protected virtual bool CheckDiscount(int discount)
        {
            if (discount <= minDiscount)
            {
                throw new Exception($"The discount cannot be less than or equal to {minDiscount}");
            }

            return true;
        }

        /// <summary>
        /// Возвращает итоговую цену товара
        /// </summary>
        /// <param name="price">Первоначальная цена товара</param>
        /// <returns></returns>
        abstract public double GetResultPrice(double price);

    }
}
