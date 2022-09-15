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

        public string ReadPersonByIndex(int index)
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

            Adult parent1 = Adult.GetRandomAdult();
            Adult parent2 = Adult.GetRandomAdult();

            parent2.Sername = parent1.Sername;
            parent1.Partner = parent2;
            parent2.Partner = parent1;
            parent1.MarriageMethod = Marriage.married;
            parent2.MarriageMethod = Marriage.married;

            for (int i = 0; i <= number; i++)
            {
                Child child = Child.GetRandomChild();
                child.Parent1 = parent1;
                child.Parent2 = parent2;
                child.Sername = parent1.Sername;
                list.AddPersonInList(child);
            }
            list.AddPersonInList(parent1);
            list.AddPersonInList(parent2);
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
