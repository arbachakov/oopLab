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
            PersonList list = new PersonList();

            Adult arkhadiyAdult = new Adult("Аркадий", "Паровозов", 48, Gender.male,
                "4587 456123", Marriage.unmarried, null, "Супер герой.");
            Adult papaAdult = new Adult("Папа", "Барбоскин", 48, Gender.male,
                "4812 123456", Marriage.married, null, "ООО 'Рога и копыта");
            Adult mamaAdult = new Adult("Мама", "Барбоскина", 45, Gender.female,
                "7859 457189", Marriage.married, papaAdult, "АО 'СО ЕЭС'");
            papaAdult.Partner = mamaAdult;

            Child rozaChild = new Child("Роза", "Барбоскина", 14, Gender.female,
                papaAdult, mamaAdult, "Школа № 45");
            Child druzjokChild = new Child("Дружок", "Барбоскин", 12, Gender.male,
                papaAdult, mamaAdult, "Школа № 45");
            Child genaChild = new Child("Гена", "Безфамильный", 12, Gender.male,
                null, null, "Школа № 45");
            Child lizaChild = new Child("Лиза", "Собака", 14, Gender.female,
                null, null, "Школа № 45");
            Child malishChild = new Child("Малыш", "Барбоскин", 6, Gender.male,
                papaAdult, mamaAdult, "Детский сад 'Посейдон");
            
            list.AddToEnd(arkhadiyAdult);
            list.AddToEnd(papaAdult);
            list.AddToEnd(mamaAdult);
            list.AddToEnd(rozaChild);
            list.AddToEnd(druzjokChild);
            list.AddToEnd(genaChild);
            list.AddToEnd(lizaChild);
            list.AddToEnd(malishChild);
            list.ReadAll();
            Console.Read();

            Child child5 = Child.GetRandomChild();
            Console.WriteLine(child5.InfoPerson());

            PersonList family = Methods.GetFamily(7);
            family.ReadAll();
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family2 = Methods.GetFamily(2);
            family2.ReadAll();
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family3 = Methods.GetFamily(3);
            family3.ReadAll();
            Console.WriteLine("----------------------------------------------------------------");
            PersonList family4 = Methods.GetFamily(1);
            family4.ReadAll();

            Console.ReadKey();

            //TODO: сделать задание 5.с
        }

        
    }
}
