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
    //TODO: RSDN
    /// <summary>
    /// Класс, описывающий человека
    /// </summary>
    public abstract class PersonBase
    {
        //TODO: Несоответствие XML комментариев коду
        /// <summary>
        /// Имя
        /// </summary>
        protected string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        protected string _sername;

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
        /// <param name="sername">Инициализация фамилиии человека</param>
        /// <param name="age">Инициализация возраста человека</param>
        /// <param name="genger">Выбор пола человека</param>
        public PersonBase(string name, string sername, int age, Gender genger)
        {
            Name = name;
            Sername = sername;
            Age = age;
            Gender = genger;
        }

        //TODO: Цепочка конструкторов
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PersonBase() : this("Unknown", "Unknown", 10, Gender.unknown) { }

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
        public abstract int Age
        

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
        /// <param Name="surname">Фамилия</param>
        public void CheckSername(string surname)
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
        private bool CheckSameLanguage(string name, string surname, Regex regex)
        {
            if (regex.IsMatch(name))
            {
                if (regex.IsMatch(surname) == false)
                {
                    throw new Exception("Name and surname should be written" +
                                        " in the same language");
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
        /// <param Name="name"></param>
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
