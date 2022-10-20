using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

//TODO: RSDN
namespace oopLab
{
    //TODO: RSDN
    class Program
    {
        //TODO: RSDN
        static void Main(string[] args)
        {
            //TODO: RSDN
            //Person personArthas = new Person("Arthas", "Menethil", 24, Gender.male);
            //Person personUther = new Person("Uther", "Lightbringer", 72, Gender.male);
            //Person personSilvana = new Person("Sylvanas", "Windrunner", 135, Gender.female);
            //Person personJaina = new Person("Jaina", "Proudmoore", 22, Gender.female);

            //Person personGarrosh = new Person("Garrosh", "Hellscream", 16, Gender.male);
            //Person personBaine = new Person("Baine", "Bloodhoof", 35, Gender.male);
            //Person personLorthemar = new Person("Lorthemar", "Theron", 95, Gender.male);


            //Console.WriteLine("Создание списков...");
            //Console.ReadKey();
            //PersonList allianceList = new PersonList();
            //allianceList.AddToEnd(personArthas);
            //allianceList.AddToEnd(personSilvana);
            //allianceList.AddToEnd(personUther);

            //PersonList hordeList = new PersonList();
            //hordeList.AddToEnd(personGarrosh);
            //hordeList.AddToEnd(personBaine);
            //hordeList.AddToEnd(personLorthemar);

            //Console.WriteLine("Вывод списков...");
            //Console.ReadKey();
            //allianceList.blueRead();
            //hordeList.darkRedRead();

            //Console.WriteLine("Добавляем нового персона... и копируем второго по списку из альянса");
            //Console.ReadKey();

            //allianceList.AddToEnd(personJaina);

            //hordeList.AddToEnd(allianceList.ReturnPersonByIndex(1));

            //allianceList.blueRead();
            //hordeList.darkRedRead();

            //Console.WriteLine("Удаляем из альянса Сильвану((");
            //Console.ReadKey();

            //allianceList.DeleteByIndex(1);

            //Console.WriteLine("Смотрим.");
            //Console.ReadKey();

            //allianceList.blueRead();
            //hordeList.darkRedRead();

            //Console.WriteLine("Уничтожим орду...");
            //Console.ReadKey();

            //hordeList.ClearList();

            //allianceList.blueRead();
            //hordeList.darkRedRead();

            //Console.ReadKey();



            Person person1 = Person.GetRandomPerson();
            
            Console.WriteLine(person1.InfoPerson());
            Console.ReadKey();
            Person person = new Person();
            Console.WriteLine(person.InfoPerson());



            Action actionName = () =>
            {
                person.Name = Console.ReadLine();
            };

            Action actionSename = () =>
            {
                person.Sername = Console.ReadLine();
            };

            Action actionAge = () =>
            {
                person.Age = int.Parse(Console.ReadLine());
            };

            Action actionGender = () =>
            {
                string chooseGender = Console.ReadLine();
                switch (chooseGender)
                {
                    case "1":
                    {
                        person.Gender = Gender.male;
                        return;
                    }
                    case "2":
                    {
                        person.Gender = Gender.female;
                        return;
                    }
                    case "3":
                    {
                        person.Gender = Gender.unknoun;
                        return;
                    }
                    default:
                    {
                        throw new Exception("You write something wrong");
                    }
                }
            };
            ActionHandler(actionName, "Write name of person");
            ActionHandler(actionSename, "Write sername of person");
            ActionHandler(actionAge, "Write age of person");
            ActionHandler(actionGender, "Choose Gender:" + 
                                        "1 - male; 2 - female; 3 - you dont know gender this person(");
            Console.WriteLine(person.InfoPerson());
            Console.ReadKey();
        }

        //TODO: XML
        //TODO: Опечатки
        public static void ActionHandler(Action action, string massege)
        {
            while (true)
            {
                Console.WriteLine(massege);
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again, please");
                }
            }
        }
    }
}
