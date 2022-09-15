using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class PersonList
    {
        public  List<Person> personList = new List<Person>();

        public int personNumber()
        {
            return personList.Count;
        }
            

        public void AddPersonInList(Person person)
        {
            personList.Add(person);
        }

        public void DeleteByIndex(int index)
        {
            personList.RemoveAt(index);
        }
        public void DeleteByName(Person person)
        {
            personList.Remove(person);
        }

        public string ReadPersonInfoByIndex(int index)
        {
            return personList[index].InfoPerson();
        }

        public Person ReturnPersonByIndex(int index)
        {
            return personList[index];
        }

        public void ClearList()
        {
            personList.Clear();
        }

        public int ReadIndexByPerson(Person person)
        {
            return personList.IndexOf(person);
        }

        public void ReadAllList()
        {
            for (int i = 0; i < personNumber(); i++)
            {
                Console.WriteLine(personList[i].InfoPerson());
            }
        }
        private void IsIndexInRange(int index)
        {
            if (index < 0 || index >= personNumber())
            {
                throw new Exception("Такого индекса нет(");
            }
        }

        

        public static PersonList GetFamily(int number)
        {
            PersonList list = new PersonList();
            Random random = new Random();
            int intFamily = random.Next(0, 3);
            switch (intFamily)
            {
                case 0:
                {
                    Adult parentFamily1 = Adult.GetRandomAdult();
                    list.AddPersonInList(parentFamily1);
                    for (int i = 0; i <= number - 1; i++)
                    {
                        Child child = Child.GetRandomChild();
                        child.Parent1 = parentFamily1;
                        child.Sername = parentFamily1.Sername;
                        list.AddPersonInList(child);
                    }
                    break;
                    }
                case 1:
                {
                    Adult parentFamily1 = Adult.GetRandomAdult();
                    Adult parentFamily2 = Adult.GetRandomAdult();

                    parentFamily2.Sername = parentFamily1.Sername;
                    parentFamily1.Partner = parentFamily2;
                    parentFamily2.Partner = parentFamily1;
                    parentFamily1.MarriageMethod = Marriage.married;
                    parentFamily2.MarriageMethod = Marriage.married;
                    list.AddPersonInList(parentFamily1);
                    list.AddPersonInList(parentFamily2);
                    for (int i = 0; i <= number - 2; i++)
                    {
                        Child child = Child.GetRandomChild();
                        child.Parent1 = parentFamily1;
                        child.Parent2 = parentFamily2;
                        child.Sername = parentFamily1.Sername;
                        list.AddPersonInList(child);
                    }
                    break;
                }
                case 2:
                {
                    for (int i = 0; i <= number; i++)
                    {
                        Child child = Child.GetRandomChild();
                        list.AddPersonInList(child);
                    }
                    break;
                }
            }
            return list;
        }

        public void blueRead()
        {
            Console.WriteLine("Alliance");
            Console.ForegroundColor = ConsoleColor.Blue; 
            ReadAllList();
            Console.ResetColor();
        }

        public void darkRedRead()
        {
            Console.WriteLine("Horde");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            ReadAllList();
            Console.ResetColor();
        }
    }
}
