using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

//TODO: RSDN (+)
namespace View
{
    //TODO: RSDN
    /// <summary>
    /// Класс Program
    /// </summary>
    class Program
    {
        //TODO: RSDN
        /// <summary>
        /// Исполняемый код
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //TODO: RSDN (+)
            Person personArthas = new Person("Arthas", "Menethil", 
                24, Gender.Male);
            Person personUther = new Person("Uther", "Lightbringer", 
                72, Gender.Male);
            Person personSilvana = new Person("Sylvanas", "Windrunner", 
                135, Gender.Female);
            Person personJaina = new Person("Jaina", "Proudmoore", 
                22, Gender.Female);

            Person personGarrosh = new Person("Garrosh", "Hellscream", 
                16, Gender.Male);
            Person personBaine = new Person("Baine", "Bloodhoof", 
                35, Gender.Male);
            Person personLorthemar = new Person("Lorthemar", "Theron",
                95, Gender.Male);


            Console.WriteLine("Creating PersonLists...");
            Console.ReadKey();
            PersonList allianceList = new PersonList();
            allianceList.AddToEnd(personArthas);
            allianceList.AddToEnd(personSilvana);
            allianceList.AddToEnd(personUther);

            PersonList hordeList = new PersonList();
            hordeList.AddToEnd(personGarrosh);
            hordeList.AddToEnd(personBaine);
            hordeList.AddToEnd(personLorthemar);

            Console.WriteLine("Writing PersonLists...");
            Console.ReadKey();
            Console.WriteLine(allianceList.ReadAll());
            Console.WriteLine(hordeList.ReadAll());
            
            //TODO: RSDN (+)
            Console.WriteLine("Adding a new person... " +
                              "and copy the second on the list from the alliance");
            Console.ReadKey();

            allianceList.AddToEnd(personJaina);

            hordeList.AddToEnd(allianceList.ReturnPersonByIndex(1));

            Console.WriteLine(allianceList.ReadAll());
            Console.WriteLine(hordeList.ReadAll());

            Console.WriteLine("Removing Silvana from the alliance((");
            Console.ReadKey();

            allianceList.DeleteByIndex(1);

            Console.WriteLine("Watch.");
            Console.ReadKey();

            allianceList.ReadAll();
            hordeList.ReadAll();

            Console.WriteLine("Destroy the horde...");
            Console.ReadKey();

            hordeList.ClearList();

            Console.WriteLine(allianceList.ReadAll());
            Console.WriteLine(hordeList.ReadAll());

            Console.ReadKey();



            Person person1 = Person.GetRandomPerson();
            
            Console.WriteLine(person1.InfoPerson());
            Console.ReadKey();
            Person person = new Person();
            Console.WriteLine(person.InfoPerson());

            //TODO: термины
            Action actionName = () =>
            {
                person.Name = Console.ReadLine();
            };

            Action actionSename = () =>
            {
                person.Surname = Console.ReadLine();
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
                        person.Gender = Gender.Male;
                        return;
                    }
                    case "2":
                    {
                        person.Gender = Gender.Female;
                        return;
                    }
                    case "3":
                    {
                        person.Gender = Gender.Unknoun;
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
                                        "1 - Male; 2 - Female; 3 - you dont know gender this person(");
            Console.WriteLine(person.InfoPerson());
            Console.ReadKey();
        }
        
        /// <summary>
        /// Обработчик действий 
        /// </summary>
        /// <param name="action">Действие</param>
        /// <param name="messege">Сообщение в консоль</param>
        public static void ActionHandler(Action action, string messege)
        {
            while (true)
            {
                Console.WriteLine(messege);
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
