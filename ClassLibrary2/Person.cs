using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Model
{
    public class Person
    {
        private string _name;
        private string _sername;
        private int _age;
        private Gender _gender;

        /// <summary>
        /// Создание объекта класса Person
        /// </summary>
        /// <param Name="Name">Инициализация имени</param>
        /// <param Name="Sername">Инициализация фамилия</param>
        /// <param Name="Age">Инициализация возраста</param>
        /// <param Name="Genger">Инициализация пола</param>
        public Person(string name, string sername, int age, Gender genger)
        {
            Name = name;
            Sername = sername;
            Age = age;
            Gender = genger;
        }
        /// <summary>
        /// Свойства имени
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                CheckName(value);
                _name = FormatName(value);
            }
        }
        /// <summary>
        /// Свойства фамилии
        /// </summary>
        public string Sername
        {
            get => _sername;
            set
            {
                CheckName(value);
                _sername = FormatName(value);
            }
        }
        /// <summary>
        /// Свойства возраста
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                CheckAge(value);
                _age = value;
            }
        }
        /// <summary>
        /// Свойства пола
        /// </summary>
        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }
        /// <summary>
        /// Проверка имени на запись в одном языке
        /// </summary>
        /// <param Name="name">Имя</param>
        public static void CheckName(string name)
        {
            if (name == "")
            {
                throw new Exception("Имя или фамилия не заполнены.");
            }

            var namePattern = new Regex(
                @"(^[A-z]+(-[A-z])?[A-z]*$)|(^[А-я]+(-[А-я])?[А-я]*$)");

            if (namePattern.IsMatch(name) == false)
            {
                throw new Exception("Имя или фамилия не соответствуют латинским или кирилическим символам.");
            }
        }
        /// <summary>
        /// Проверка фамилии
        /// </summary>
        /// <param Name="surname">Фамилия</param>
        public void CheckSername(string surname)
        {
            var latinPattern = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicPattern = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            CheckName(surname);

            if (latinPattern.IsMatch(_name))
            {
                if (latinPattern.IsMatch(surname) == false)
                {
                    throw new Exception("Имя и фамилия должны быть написаны на латинском.");
                }
            }

            if (cyrillicPattern.IsMatch(_name))
            {
                if (cyrillicPattern.IsMatch(surname) == false)
                {
                    throw new Exception("Имя и фамилия должны быть написаны кириллице.");
                }
            }
        }
        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param Name="age">Возраст</param>
        public void CheckAge(int age)
        {
            if (age < 0 | age >= 140)
            {
                throw new Exception("Возраст должен быть положительным или меньше 100.");

            }
        }
        /// <summary>
        /// Устанавливает заглавную букву
        /// </summary>
        /// <param Name="name"></param>
        /// <returns></returns>
        private static string FormatName(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }

        public string Result()
        {
            return $"{Name} {Sername} - Age: {Age} - Gender: {Gender}";
        }
    }
}
