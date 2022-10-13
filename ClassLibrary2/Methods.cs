using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Methods
    {
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
                            child.Sername = parentFamily1.Sername;
                            list.AddToEnd(child);
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
                        list.AddToEnd(parentFamily1);
                        list.AddToEnd(parentFamily2);
                        for (int i = 0; i <= number - 2; i++)
                        {
                            Child child = Child.GetRandomChild();
                            child.Parent1 = parentFamily1;
                            child.Parent2 = parentFamily2;
                            child.Sername = parentFamily1.Sername;
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
    }
}
