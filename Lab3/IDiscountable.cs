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
