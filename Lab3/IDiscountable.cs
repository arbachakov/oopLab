using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Интерфейс, описывающий скидочные методы
    /// </summary>
    interface IDiscountable
    {
        /// <summary>
        /// Возвращает итоговую цену товара
        /// </summary>
        /// <returns></returns>
        double GetResultPrice(double price);
    }
}
