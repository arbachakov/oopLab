using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Child : Person
    {
        private Adult _parent1;
        private Adult _parent2;
        private string _childPlaceName;

        const int minAge = 0;
        const int maxAge = 17;

        private static Random rnd;
        static Child()
        {
            rnd = new Random();
        }

        public Child(string name, string sername, int age, Gender genger,
            Adult parent1, Adult parent2, string childPlaceName)
            : base(name, sername, age, genger)
        {
            Parent1 = parent1;
            Parent2 = parent2;
            ChildPlaceName = childPlaceName;
        }

        public Child()
        {
            _parent1 = null;
            _parent2 = null;
            _childPlaceName = "Детский дом";
        }
        public new int Age
        {
            get => _age;
            set
            {
                CheckAge(value);
                _age = value;
            }
        }

        public new void  CheckAge(int age)
        {
            if (age < minAge | age > maxAge)
            {
                throw new Exception($"Возраст должен быть больше {minAge} или меньше {maxAge + 1}.");

            }
        }
        public Adult Parent1
        {
           get => _parent1;
           set => _parent1 = value;
        }

       public Adult Parent2
       {
           get => _parent2;
           set
           {
               if (Parent1 == null)
               {
                   Parent1 = value;
               }
               else
               {
                   _parent2 = value;
               }
           }
       }

       public string ChildPlaceName
       {
           get => _childPlaceName;
           set => _childPlaceName = value;
       }

       public string getNameParents(Adult parent1, Adult parent2)
       {
           string parentsName = "";
           if (parent1 != null)
           {
               parentsName = $"Родитель1: {parent1.Name} {parent1.Sername}";
           } 
           if (parent2 != null)
           {
               parentsName += $", Родитель2: {parent2.Name} {parent2.Sername}";
           }
           if (parent1 == null & parent2 == null)
           {
               parentsName = "Родителей нет(";
           }
           return parentsName;
       }

       public override string InfoPerson()
       {
           string infoPerson = $"{Name} {Sername} Возраст: {Age}, Пол: {Gender}, " +
                               $"{getNameParents(Parent1, Parent2)}";
           return infoPerson;
       }

        public static Child GetRandomChild()
        {

            string[] maleNames =
            {
                "Max", "Sam", "Greg", "Pol", "Aleksndr", "Petr", "Jason"
            };

            string[] femaleNames =
            {
                "Kate", "Nikki", "Olga", "Marina", "Inna", "Bob", "Alena"
            };

            string[] sernames =
            {
                "Smit", "Anderson", "Morningstar", "Balls", "Gallager", "Dallas", "Wall"
            };

            string[] childPlaceNames =
            {
                "Fairy tail", "Princess", "TPU", "Good place:)",
                "Red dragon", "Little monsters", "Black Cat"
            };

            string[] allNames = maleNames.Concat(femaleNames).ToArray();

            Child child = new Child();

            switch (rnd.Next(1, 3))
            {
                case 1:
                {
                    child.Name = maleNames[rnd.Next(maleNames.Length)];
                    child.Gender = Gender.male;
                    break;
                }
                case 2:
                {
                    child.Name = femaleNames[rnd.Next(femaleNames.Length)];
                    child.Gender = Gender.female;
                    break;
                }
                case 3:
                {
                    child.Name = allNames[rnd.Next(allNames.Length)];
                    child.Gender = Gender.unknown;
                    break;
                }
            }

            child.Sername = sernames[rnd.Next(sernames.Length)];

            child.Age = rnd.Next(minAge, maxAge);

            child.ChildPlaceName = childPlaceNames[rnd.Next(childPlaceNames.Length)];

            return child;
        }
    }
}
