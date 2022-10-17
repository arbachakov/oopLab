using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Класс товара
    /// </summary>
    public class Product
    {
        private string _name;
        private int _quantity;
        private double _price;

        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Name
        {
            get => _name;
            set
            {
                CheckName(value);
                _name = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                CheckQuantity(value);
                _quantity = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                CheckPrice(value);
                _price = value;
            }
        }

        private bool CheckName(string name)
        {
            if (name == "")
            {
                throw new Exception("Название товара не задано");
            }

            return true;
        }
        private bool CheckQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception
                    ("Количество товара " +
                     "не может быть равно или меньше 0");
            }

            return true;
        }
        private bool CheckPrice(double price)
        {
            if (price <= 0)
            {
                throw new Exception
                ("Цена товара " +
                 "не может быть равно или меньше 0");
            }

            return true;
        }
    }
}
