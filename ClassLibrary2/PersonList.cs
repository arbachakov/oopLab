using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
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
            return personList[index].Result();
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
                Console.WriteLine(personList[i].Result());
            }
        }
        private void IsIndexInRange(int index)
        {
            if (index < 0 || index >= personNumber())
            {
                throw new Exception("Такого индекса нет(");
            }
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
