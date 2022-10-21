﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace oopLab
{
    class Program
    {
        static void Main(string[] args)
        {   
            //PersonList list = new PersonList();

            //Adult arkhadiyAdult = new Adult("Аркадий", "Паровозов", 48, Gender.male,
            //    "4587 456123", Marriage.unmarried, null, "Супер герой.");
            //Adult papaAdult = new Adult("Папа", "Барбоскин", 48, Gender.male,
            //    "4812 123456", Marriage.married, null, "ООО 'Рога и копыта");
            //Adult mamaAdult = new Adult("Мама", "Барбоскина", 45, Gender.female,
            //    "7859 457189", Marriage.married, papaAdult, "АО 'СО ЕЭС'");
            //papaAdult.Partner = mamaAdult;

            //Child rozaChild = new Child("Роза", "Барбоскина", 14, Gender.female,
            //    papaAdult, mamaAdult, "Школа № 45");
            //Child druzjokChild = new Child("Дружок", "Барбоскин", 12, Gender.male,
            //    papaAdult, mamaAdult, "Школа № 45");
            //Child genaChild = new Child("Гена", "Безфамильный", 12, Gender.male,
            //    null, null, "Школа № 45");
            //Child lizaChild = new Child("Лиза", "Собака", 14, Gender.female,
            //    null, null, "Школа № 45");
            //Child malishChild = new Child("Малыш", "Барбоскин", 6, Gender.male,
            //    papaAdult, mamaAdult, "Детский сад 'Посейдон");
            
            //list.AddToEnd(arkhadiyAdult);
            //list.AddToEnd(papaAdult);
            //list.AddToEnd(mamaAdult);
            //list.AddToEnd(rozaChild);
            //list.AddToEnd(druzjokChild);
            //list.AddToEnd(genaChild);
            //list.AddToEnd(lizaChild);
            //list.AddToEnd(malishChild);
            //Console.WriteLine(list.ReadAll());
            //Console.Read();
            

            PersonList family = Methods.GetFamily(7);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family2 = Methods.GetFamily(2);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family3 = Methods.GetFamily(3);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family4 = Methods.GetFamily(1);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("----------------------------------------------------------------");
            Console.ReadKey();
            PersonList randomList = Methods.GetRandomPersons(7);
            var person4 = randomList.ReturnPersonByIndex(4);
            Console.WriteLine(person4.InfoPerson());
            Console.WriteLine(UseClassMethod(person4));

            Console.ReadKey();
            //TODO: сделать задание 5.с (+)
        }

        /// <summary>
        /// Возвращает строку с применением уникального для класса метода!
        /// </summary>
        /// <param name="person">Персон</param>
        /// <returns></returns>
        static string UseClassMethod(PersonBase person)
        {
            string result = "";
            switch (person)
            {
                case Child fourthChild:
                {
                    result = fourthChild.GoToKindergarten();
                    break;
                }
                case Adult fourthAdult:
                {
                    result = fourthAdult.GoToWork();
                    break;
                }
            }

            return result;
        }
    }
}
