using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    class Adult : Person
    {
        // В класс Adult добавьте информацию о паспортных данных, состоянии брака (со ссылкой на партнёра), название места работы.

        private string _pasportNumber;
        private Marriage _marriage;
        private Adult _partner;
        private string _workCompany;

        /// <summary>
        /// Конструктор Взрослого
        /// </summary>
        /// <param name="pasportNumber">Номер паспорта</param>
        /// <param name="marriage">Статус брака</param>
        /// <param name="partner">Партнер</param>
        /// <param name="workCompany">Место работы</param>
        public Adult(string pasportNumber, Marriage marriage, Adult partner, string workCompany)
        {
            PassportNumber = pasportNumber;
            MarriageMethod = marriage;
            AdultMethod = partner;
            WorkCompany = workCompany;
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

        public Adult AdultMethod
        {
            get => _partner;
            set => _partner = value;
        }

        public string WorkCompany
        {
            get => _workCompany;
            set => _workCompany = value;
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

    }
}
