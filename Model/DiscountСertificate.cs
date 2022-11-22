using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DiscountСertificate(double discount) : base(discount) { }
        
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
