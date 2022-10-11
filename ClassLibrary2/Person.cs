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
    public class Person
    {
        //TODO: RSDN
        private string _name;
        private string _sername;
        private int _age;
        private Gender _gender;

        //TODO: Несоответствие XML комментариев коду
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

        //TODO: использовать цепочку конструкторов
        public Person()
        {
            Name = "Unknown";
            Sername = "Unknown";
            Age = 10;
            Gender = Gender.unknoun;
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
                //TODO: RSDN
                throw new Exception("Имя или фамилия не соответствуют латинским или кирилическим символам.");
            }
        }

        //TODO: Нарушение инкапсуляции
        /// <summary>
        /// Проверка фамилии
        /// </summary>
        /// <param Name="surname">Фамилия</param>
        public void CheckSername(string surname)
        {
            var latinPattern = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicPattern = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            CheckName(surname);

            //TODO: Собрать в метод без дублирования
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
                throw new Exception("Возраст должен быть положительным или меньше 140.");
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

        //TODO: RSDN
        public string Result()
        {
            return $"{Name} {Sername} - Age: {Age} - Gender: {Gender}";
        }

        //TODO: RSDN
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
