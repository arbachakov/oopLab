using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс, описывающий человека
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        protected string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        protected string _surname;
        
        /// <summary>
        /// Возраст
        /// </summary>
        protected int _age;

        /// <summary>
        /// Пол
        /// </summary>
        protected Gender _gender;
        
        /// <summary>
        /// Создание объекта класса PersonBase с помощью конструктора
        /// </summary>
        /// <param name="name">Инициализация имени человека</param>
        /// <param name="surname">Инициализация фамилиии человека</param>
        /// <param name="age">Инициализация возраста человека</param>
        /// <param name="gender">Выбор пола человека</param>
        protected PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        protected PersonBase() : this("Unknown", "Unknown", 10, Gender.Unknown) { }

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
        public string Surname
        {
            get => _surname;
            set
            {
                CheckName(value);
                _surname = FormatName(value);
            }
        }

        /// <summary>
        /// Свойства возраста
        /// </summary>
        public abstract int Age { get; set; }
        

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
        /// <param name="name"></param>
        public static void CheckName(string name)
        {
            if (name == "")
            {
                throw new Exception("Name or surname is not written.");
            }

            var namePattern = new Regex(
                @"(^[A-z]+(-[A-z])?[A-z]*$)|(^[А-я]+(-[А-я])?[А-я]*$)");

            if (namePattern.IsMatch(name) == false)
            {
                throw new Exception("Name or surname does not correspond to " +
                                    "Latin or Cyrillic characters.");
            }
        }

        /// <summary>
        /// Проверка фамилии
        /// </summary>
        /// <param name="surname"></param>
        public void CheckSurname(string surname)
        {

            var latinPattern = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicPattern = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            CheckName(surname);
            CheckSameLanguage(_name, surname, latinPattern);
            CheckSameLanguage(_name, surname, cyrillicPattern);
        }

        /// <summary>
        /// Проверка имени и фамилии на предмет одного языка
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="regex">Паттерн</param>
        /// <returns></returns>
        private bool CheckSameLanguage(string name, string surname, 
            Regex regex)
        {
            if (regex.IsMatch(name))
            {
                if (regex.IsMatch(surname) == false)
                {
                    throw new Exception("Name and surname should be " +
                                        "written in the same language");
                }
            }

            return true;
        }

        /// <summary>
        /// Проверка возраста
        /// </summary>
        /// <param Name="age">Возраст</param>
        public abstract void CheckAge(int age);
        

        /// <summary>
        /// Устанавливает заглавную букву
        /// </summary>
        /// <param name="name">//</param>
        /// <returns></returns>
        private static string FormatName(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }

        /// <summary>
        /// Возвращает информацию о человеке в текстовом виде
        /// </summary>
        /// <returns></returns>
        public abstract string InfoPerson();

        
    }
}
