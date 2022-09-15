using System;
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
        {   //
            //PersonList list = new PersonList();
            //
            //Adult arkhadiyAdult = new Adult("Аркадий", "Паровозов", 48, Gender.male,
            //    "4587 456123", Marriage.unmarried, null, "Супер герой.");
            //Adult papaAdult = new Adult("Папа", "Барбоскин", 48, Gender.male,
            //    "4812 123456", Marriage.married, null, "ООО 'Рога и копыта");
            //Adult mamaAdult = new Adult("Мама", "Барбоскина", 45, Gender.female,
            //    "7859 457189", Marriage.married, papaAdult, "АО 'СО ЕЭС'");
            //papaAdult.Partner = mamaAdult;
            //
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
            //
            //list.AddPersonInList(arkhadiyAdult);
            //list.AddPersonInList(papaAdult);
            //list.AddPersonInList(mamaAdult);
            //list.AddPersonInList(rozaChild);
            //list.AddPersonInList(druzjokChild);
            //list.AddPersonInList(genaChild);
            //list.AddPersonInList(lizaChild);
            //list.AddPersonInList(malishChild);
            //list.ReadAllList();
            //Console.Read();
            
            //Child child5 = Child.GetRandomChild();
            //Console.WriteLine(child5.InfoPerson());

            PersonList family = PersonList.GetFamily(5);
            family.ReadAllList();

            Console.ReadKey();
        }

        
    }
}
