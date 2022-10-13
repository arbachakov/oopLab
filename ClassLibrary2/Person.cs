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
    /// <summary>
    /// Класс, описывающий человека
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _sername;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;

        /// <summary>
        /// Пол
        /// </summary>
        private Gender _gender;

        //TODO: Опечатки
        /// <summary>
        /// Создание объекта класса Person с помощью конструктора
        /// </summary>
        /// <param name="name">Инициализация имени человека</param>
        /// <param name="sername">Инициализация фамилиии человека</param>
        /// <param name="age">Инициализация возраста человека</param>
        /// <param name="genger">Выбор пола человека</param>
        public Person(string name, string sername, int age, Gender genger)
        {
            Name = name;
            Sername = sername;
            Age = age;
            Gender = genger;
        }
        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Person() : this("Unknown", "Unknown", 10, Gender.unknoun) { }

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
                CheckSername(value);
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

        //TODO: Несоответствие XML комментариев коду
        /// <summary>
        /// Проверка имени на запись на одном языке
        /// </summary>
        /// <param Name="name">Имя</param>
        private static void CheckName(string name)
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
        
        //TODO: Опечатки
        /// <summary>
        /// Проверка фамилии
        /// </summary>
        /// <param Name="surname">Фамилия</param>
        private void CheckSername(string surname)
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
        private void CheckAge(int age)
        {
            //TODO: Условный оператор?
            if (age < 0 | age >= 140)
            {
                throw new Exception("Возраст должен быть положительным или меньше 140.");
            }
        }
        
        /// <summary>
        /// Устанавливает заглавную букву
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns></returns>
        private static string FormatName(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }
        
        /// <summary>
        /// Возвращает всю информацию о человеке
        /// </summary>
        /// <returns></returns>
        public string InfoPerson()
        {
            return $"{Name} {Sername} - Age: {Age} - Gender: {Gender}";
        }
        
        /// <summary>
        /// Возвращает случайного человека
        /// </summary>
        /// <returns></returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Max", "Sam", "Greg", "Pol", "Aleksndr", "Petr", "Jason"
            };

            string[] femaleNames =
            {
                "Kate", "Nikki", "Olga", "Marina", "Inna", "Bob", "Alena"
            };
            //TODO: Опечатки
            string[] sernames =
            {
                "Smit", "Anderson", "Morningstar", "Balls", "Gallager", "Dallas", "Wall"
            };
            string[] allNames = maleNames.Concat(femaleNames).ToArray();

            Person person = new Person();
            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case 1:
                {
                    person.Name = maleNames[random.Next(maleNames.Length)];
                    person.Gender = Gender.male;
                    break;
                }
                case 2:
                {
                    person.Name = femaleNames[random.Next(femaleNames.Length)];
                    person.Gender = Gender.female;
                    break;
                }
                case 3:
                {
                    person.Name = allNames[random.Next(allNames.Length)];
                    person.Gender = Gender.unknoun;
                    break;
                }
            }
            person.Sername = sernames[random.Next(sernames.Length)];
            person.Age = random.Next(0, 140);
            return person;
        }
    }
}
