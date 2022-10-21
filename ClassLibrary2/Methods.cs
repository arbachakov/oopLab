using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //TODO: naming
    /// <summary>
    /// Класс, содержащий в себе различные методы
    /// </summary>
    public class Methods
    {
        //TODO: RSDN
        /// <summary>
        /// Рандом
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Метод возвращает семью или набор людей 
        /// </summary>
        /// <param name="number">Необходимое количество людей</param>
        /// <returns></returns>
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
                        list.AddToEnd(parentFamily1);
                        for (int i = 0; i <= number - 1; i++)
                        {
                            Child child = Child.GetRandomChild();
                            child.Parent1 = parentFamily1;
                            child.Surname = parentFamily1.Surname;
                            list.AddToEnd(child);
                        }
                        break;
                    }
                case 1:
                    {
                        Adult parentFamily1 = Adult.GetRandomAdult();
                        Adult parentFamily2 = Adult.GetRandomAdult();

                        parentFamily2.Surname = parentFamily1.Surname;
                        parentFamily1.Partner = parentFamily2;
                        parentFamily2.Partner = parentFamily1;
                        parentFamily1.MarriageMethod = Marriage.married;
                        parentFamily2.MarriageMethod = Marriage.married;
                        list.AddToEnd(parentFamily1);
                        list.AddToEnd(parentFamily2);
                        for (int i = 0; i <= number - 2; i++)
                        {
                            Child child = Child.GetRandomChild();
                            child.Parent1 = parentFamily1;
                            child.Parent2 = parentFamily2;
                            child.Surname = parentFamily1.Surname;
                            list.AddToEnd(child);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i <= number; i++)
                        {
                            Child child = Child.GetRandomChild();
                            list.AddToEnd(child);
                        }
                        break;
                    }
            }
            return list;
        }

        //TODO: XML
        public static PersonList GetRandomPersons(int number)
        {
            PersonList list = new PersonList();
            Random random = new Random();
            int randomNext = random.Next(0, 1);
            int i = 0;
            while (i < number)
            {
                switch (randomNext)
                {
                    case 0:
                    {
                        Adult adult = Adult.GetRandomAdult();
                        list.AddToEnd(adult);
                        break;
                    }
                    case 1:
                    {
                        Child child = Child.GetRandomChild();
                        list.AddToEnd(child);
                        break;
                    }
                }

                i++;
            }

            return list;
        }
    }
}
