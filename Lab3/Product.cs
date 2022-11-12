using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Класс товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        private string _name;

        /// <summary>
        /// Количество товара
        /// </summary>
        private int _quantity;

        /// <summary>
        /// Цена товара
        /// </summary>
        private double _price;

        /// <summary>
        /// Конструктор товара
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="quantity">Количество</param>
        /// <param name="price">Цена</param>
        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Свойство имени
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckName(value);
                _name = value;
            }
        }

        /// <summary>
        /// Свойство количества
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                CheckQuantity(value);
                _quantity = value;
            }
        }

        /// <summary>
        /// Свойство цены
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                CheckPrice(value);
                _price = value;
            }
        }

        /// <summary>
        /// Проверка имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        private bool CheckName(string name)
        {
            if (name == "")
            {
                throw new Exception("The product name is not specified");
            }

            return true;
        }

        /// <summary>
        /// Проверка количества
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private bool CheckQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception
                    ("The quantity of the product " +
                     "cannot be equal to or less than 0");
            }

            return true;
        }

        /// <summary>
        /// Проверка цены
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        private bool CheckPrice(double price)
        {
            if (price <= 0)
            {
                throw new Exception
                ("Product price " +
                 "cannot be equal to or less than 0");
            }

            return true;
        }

        /// <summary>
        /// Возвращает информацию о продукте
        /// </summary>
        /// <returns></returns>
        public string InfoProduct()
        {
            string info = $"{Name} - {Quantity} units - {Price} $";
            return info;
        }

        /// <summary>
        /// Возвращает стоимость товаров
        /// </summary>
        /// <returns></returns>
        public double GetCost()
        {
            return Price * Quantity;
        }
        
        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Возвращает случайный продукт
        /// </summary>
        /// <returns></returns>
        public static Product GetRandomProduct()
        {
            
            List<string> productNames = new List<string>()
            {
                "Milk", "Sausage", "Cookies", "Rice", "Tomato", "Pasta",
                "Herring", "Peas", "Chicken", "Buckwheat", "Mushroom", "Onion"
            };

            string productName = productNames[_random.Next(0, productNames.Count)];
            Product product = new Product(productName, 
                _random.Next(1, 10), _random.Next(1, 50));
            return product;
        }
    }
}
