using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Adult : Person
    {
        private string _pasportNumber;
        private Marriage _marriage;
        private Adult _partner;
        private string _workCompany;
        const int minAge = 18;
        const int maxAge = 140;

        private static Random rnd;
        static Adult()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Конструктор Взрослого
        /// </summary>
        /// <param name="pasportNumber">Номер паспорта</param>
        /// <param name="marriage">Статус брака</param>
        /// <param name="partner">Партнер</param>
        /// <param name="workCompany">Место работы</param>
        public Adult(string name, string sername, int age, Gender genger,
            string pasportNumber, Marriage marriage, Adult partner, string workCompany)
            : base(name, sername, age, genger)
        {
            PassportNumber = pasportNumber;
            MarriageMethod = marriage;
            Partner = partner;
            WorkCompany = workCompany;
        }

        public Adult()
        {
            _pasportNumber = "1234 567891";
            _marriage = Marriage.unmarried;
            _partner = null;
            _workCompany = "Безработный...";
        }

        public string PassportNumber
        {
            get => _pasportNumber;
            set
            {
                CheckPassportNumber(value);
                _pasportNumber = value;
            }
        }

        public Marriage MarriageMethod
        {
            get => _marriage;
            set => _marriage = value;
        }

        public Adult Partner
        {
            get => _partner;
            set => _partner = value;
        }

        public string WorkCompany
        {
            get => _workCompany;
            set => _workCompany = value;
        }
        public new int Age
        {
            get => _age;
            set
            {
                CheckAge(value);
                _age = value;
            }
        }

        public new void CheckAge(int age)
        {
            if (age < minAge | age > maxAge)
            {
                throw new Exception($"Возраст должен быть больше {minAge} или меньше {maxAge + 1}.");

            }
        }
        public static void CheckPassportNumber(string passportNumber)
        {
            if (passportNumber == "")
            {
                throw new Exception("Паспорт не заполнен");
            }

            var namePattern = new Regex(@"(\d{4}\s\d{6})");
            if (namePattern.IsMatch(passportNumber) == false)
            {
                throw new Exception("Паспорт имеет неверный формат");
            }
        }

        public string getNamePartner(Adult partnerAdult)
        {
            string namePartner = $"{partnerAdult.Name} {partnerAdult.Sername}";
            return namePartner;
        }

        public override string InfoPerson()
        {
            string infoPerson = $"{Name} {Sername} Возраст: {Age}, Пол: {Gender}, " +
                                $"Номер паспорта: {PassportNumber}, Работа: {WorkCompany}, Состояние брака: {MarriageMethod}";
            if (MarriageMethod == Marriage.married)
            {
                infoPerson += $", Партнер: {getNamePartner(Partner)}";
            }

            return infoPerson;
        }

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
                    adult.Gender = Gender.male;
                    break;
                }
                case 2:
                {
                    adult.Name = femaleNames[rnd.Next(femaleNames.Length)];
                    adult.Gender = Gender.female;
                    break;
                }
                case 3:
                {
                    adult.Name = allNames[rnd.Next(allNames.Length)];
                    adult.Gender = Gender.unknown;
                    break;
                }
            }
            adult.Sername = sernames[rnd.Next(sernames.Length)];

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
