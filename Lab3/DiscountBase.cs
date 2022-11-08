using System;

namespace Lab3
{
    abstract public class DiscountBase
    {
        /// <summary>
        /// Скидка 
        /// </summary>
        protected double _discount;

        /// <summary>
        /// Конструктор сертификата
        /// </summary>
        /// <param name="discount">Скидка</param>
        protected DiscountBase(double discount)
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
        protected virtual bool CheckDiscount(double discount)
        {
            if (discount <= 0)
            {
                throw new Exception("The discount cannot be less than or equal to 0");
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
