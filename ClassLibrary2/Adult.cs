﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Класс взослого
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _pasportNumber;

        /// <summary>
        /// Состояние брака
        /// </summary>
        private Marriage _marriage;

        /// <summary>
        /// Партнер
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Компания, в которой работает
        /// </summary>
        private string _workCompany;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        const int minAge = 18;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        const int maxAge = 140;

        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Чтобы рандомайзер работал
        /// </summary>
        static Adult()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Конструктор взрослого
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="sername">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="genger">Пол</param>
        /// <param name="pasportNumber">Номер паспорта</param>
        /// <param name="marriage">Состояние брака</param>
        /// <param name="partner">Партнер</param>
        /// <param name="workCompany">Работа</param>
        public Adult(string name, string sername, int age, Gender genger,
            string pasportNumber, Marriage marriage, Adult partner, string workCompany)
            : base(name, sername, age, genger)
        {
            PassportNumber = pasportNumber;
            MarriageMethod = marriage;
            Partner = partner;
            WorkCompany = workCompany;
        }

        /// <summary>
        /// Конструктор по умолчанию для взрослого
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 18, Gender.Unknown,
            "1234 567891", Marriage.Unmarried, null, "Unemployed...")
        { }

        /// <summary>
        /// Свойство номера паспорта
        /// </summary>
        public string PassportNumber
        {
            get => _pasportNumber;
            set
            {
                CheckPassportNumber(value);
                _pasportNumber = value;
            }
        }

        /// <summary>
        /// Свойство состояния брака
        /// </summary>
        public Marriage MarriageMethod
        {
            get => _marriage;
            set => _marriage = value;
        }

        /// <summary>
        /// Свойство партнера
        /// </summary>
        public Adult Partner
        {
            get => _partner;
            set => _partner = value;
        }

        /// <summary>
        /// Свойство работы
        /// </summary>
        public string WorkCompany
        {
            get => _workCompany;
            set => _workCompany = value;
        }

        /// <summary>
        /// Свойство возраста
        /// </summary>
        public override int Age
        {
            get => _age;
            set
            {
                CheckAge(value);
                _age = value;
            }
        }
        
        /// <summary>
        /// Проверяет возраст
        /// </summary>
        /// <param name="age">Возраст</param>
        public override void CheckAge(int age)
        {
            if (age < minAge | age > maxAge)
            {
                throw new Exception($"The age should be more {minAge} or " +
                                    $"less {maxAge + 1}.");

            }
        }

        /// <summary>
        /// Проверяет номер паспорта
        /// </summary>
        /// <param name="passportNumber"></param>
        public static void CheckPassportNumber(string passportNumber)
        {
            if (passportNumber == "")
            {
                throw new Exception("Passport is not filled in");
            }

            var namePattern = new Regex(@"(\d{4}\s\d{6})");
            if (namePattern.IsMatch(passportNumber) == false)
            {
                throw new Exception("The passport has an incorrect format");
            }
        }

        /// <summary>
        /// Возвращает партнера
        /// </summary>
        /// <param name="partnerAdult">Партнер</param>
        /// <returns></returns>
        public string getNamePartner(Adult partnerAdult)
        {
            string namePartner = $"{partnerAdult.Name} {partnerAdult.Surname}";
            return namePartner;
        }

        /// <summary>
        /// Возвращает информацию о взрослом в виде строки
        /// </summary>
        /// <returns></returns>
        public override string InfoPerson()
        {
            string infoPerson = $"{Name} {Surname} Age: {Age}, Gender: {Gender}, " +
                                $"Pasport number: {PassportNumber}, Job: {WorkCompany}, " +
                                $"Marriage: {MarriageMethod}";
            if (MarriageMethod == Marriage.Married)
            {
                infoPerson += $", Partner: {getNamePartner(Partner)}";
            }

            return infoPerson;
        }

        /// <summary>
        /// Возвращает сообщение об отправке на работу
        /// </summary>
        /// <returns></returns>
        public string GoToWork()
        {
            string result = "";
            if (WorkCompany == "Unemployed...")
            {
                result = $"Look for a job, {Name}!!!";
            }
            else
            {
                result = $"Go to {WorkCompany}, {Name}!!!";
            }
            return result;
        }

        /// <summary>
        /// Возвращает случайного взрослого
        /// </summary>
        /// <returns></returns>
        public static Adult  GetRandomAdult()
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
            string[] workCompanes =
            {
                "School №23", "Roga i Copita", "TPU", "Stark Indastis", 
                "Lenovo Phons", "Baykal Tables", "Russian army"
            };

            string[] allNames = maleNames.Concat(femaleNames).ToArray();
            Adult adult = new Adult();

            switch (rnd.Next(1, 3))
            {
                case 1:
                {
                    adult.Name = maleNames[rnd.Next(maleNames.Length)];
                    adult.Gender = Gender.Male;
                    break;
                }
                case 2:
                {
                    adult.Name = femaleNames[rnd.Next(femaleNames.Length)];
                    adult.Gender = Gender.Female;
                    break;
                }
                case 3:
                {
                    adult.Name = allNames[rnd.Next(allNames.Length)];
                    adult.Gender = Gender.Unknown;
                    break;
                }
            }
            adult.Surname = sernames[rnd.Next(sernames.Length)];

            int firstPartOfPasport = rnd.Next(1000, 9999);
            int secondPartOfPasport = rnd.Next(100000, 999999);
            
            adult.Age = rnd.Next(minAge, maxAge);
            adult.PassportNumber = Convert.ToString(firstPartOfPasport) + 
                                   " " + Convert.ToString(secondPartOfPasport);
            adult.WorkCompany = workCompanes[rnd.Next(workCompanes.Length)];

            return adult;
        }

    }
}
