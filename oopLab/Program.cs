using Model;
using System;

namespace View
{
    //TODO: RSDN (+)
    /// <summary>
    /// Класс Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            PersonList list = new PersonList();

            Adult arkadiyAdult = new Adult("Arkady", "Parovozov", 
                48, Gender.Male, "4587 456123", 
                Marriage.Unmarried, null, "Super hero.");
            Adult papaAdult = new Adult("Papa", "Barboskin", 
                48, Gender.Male, "4812 123456", 
                Marriage.Married, null, "LLC 'Horns and hooves");
            Adult mamaAdult = new Adult("Mom", "Barboskina", 
                45, Gender.Female, "7859 457189", 
                Marriage.Married, papaAdult, "JSC 'SO UES'");
            papaAdult.Partner = mamaAdult;

            Child rozaChild = new Child("Rosa", "Barboskina", 
                14, Gender.Female, papaAdult, mamaAdult, 
                "School No. 45");
            Child druzjokChild = new Child("Buddy", "Barboskin", 
                12, Gender.Male, papaAdult, mamaAdult, 
                "School No. 45");
            Child genaChild = new Child("Gena", "Nameless", 
                12, Gender.Male, null, null, 
                "School No. 45");
            Child lizaChild = new Child("Lisa", "Dog", 
                14, Gender.Female, null, null, 
                "School No. 45");
            Child malishChild = new Child("Kid", "Barboskin", 
                6, Gender.Male, papaAdult, mamaAdult, 
                "Poseidon Kindergarten");

            list.AddToEnd(arkadiyAdult);
            list.AddToEnd(papaAdult);
            list.AddToEnd(mamaAdult);
            list.AddToEnd(rozaChild);
            list.AddToEnd(druzjokChild);
            list.AddToEnd(genaChild);
            list.AddToEnd(lizaChild);
            list.AddToEnd(malishChild);
            Console.WriteLine(list.ReadAll());
            Console.Read();


            PersonList family = GenerathionPersonListMethods.
                GetFamily(7);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("-------------------------------------------");
            PersonList family2 = GenerathionPersonListMethods.
                GetFamily(2);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("-------------------------------------------");
            PersonList family3 = GenerathionPersonListMethods.
                GetFamily(3);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("-------------------------------------------");
            PersonList family4 = GenerathionPersonListMethods.
                GetFamily(1);
            Console.WriteLine(family.ReadAll());
            Console.WriteLine("-------------------------------------------");
            Console.ReadKey();

            PersonList randomList = GenerathionPersonListMethods.
                GetRandomPersons(7);
            var person4 = randomList.ReturnPersonByIndex(4);
            Console.WriteLine(person4.InfoPerson());
            Console.WriteLine(UseClassMethod(person4));

            Console.ReadKey();
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
                    result = fourthChild.GoToKindergarden();
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
