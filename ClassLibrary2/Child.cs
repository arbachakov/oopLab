using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Родитель1
        /// </summary>
        private Adult _parent1;

        /// <summary>
        /// Родитель2
        /// </summary>
        private Adult _parent2;

        /// <summary>
        /// Детский сад
        /// </summary>
        private string _childPlaceName;

        /// <summary>
        /// Минимальный возраст
        /// </summary>
        const int minAge = 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        const int maxAge = 17;

        /// <summary>
        /// Экземпляр рандомайзера
        /// </summary>
        private static Random rnd;

        /// <summary>
        /// Чтобы работал рандомайзер
        /// </summary>
        static Child()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Конструктор ребенка
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="sername">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="genger">Пол</param>
        /// <param name="parent1">Родитель1</param>
        /// <param name="parent2">Родитель2</param>
        /// <param name="childPlaceName">Детский сад</param>
        public Child(string name, string sername, int age, Gender genger,
            Adult parent1, Adult parent2, string childPlaceName)
            : base(name, sername, age, genger)
        {
            Parent1 = parent1;
            Parent2 = parent2;
            ChildPlaceName = childPlaceName;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Child() :this("Unknown", "Unknown", 10, Gender.unknown,
            null, null, "Детский дом")
        {}

        /// <summary>
        /// Свойство возраста
        /// </summary>
        public override int Age
        {
            get => _age;
            set
            {
                CheckAge(value);
                _age = value;
            }
        }

        /// <summary>
        /// Проверяет возраст
        /// </summary>
        /// <param name="age">Возраст</param>
        public override void  CheckAge(int age)
        {
            if (age < minAge | age > maxAge)
            {
                throw new Exception($"Возраст должен быть больше {minAge} или " +
                                    $"меньше {maxAge + 1}.");

            }
        }

        /// <summary>
        /// Свойства родителя1
        /// </summary>
        public Adult Parent1
        {
           get => _parent1;
           set => _parent1 = value;
        }

        /// <summary>
        /// Свойство родителя2
        /// </summary>
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

        /// <summary>
        /// Свойство детского сада
        /// </summary>
       public string ChildPlaceName
       {
           get => _childPlaceName;
           set => _childPlaceName = value;
       }

        /// <summary>
        /// Возвращает родителей, если есть
        /// </summary>
        /// <param name="parent1">Родитель1</param>
        /// <param name="parent2">Родитель2</param>
        /// <returns></returns>
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

        /// <summary>
        /// Возвращает информацию о ребенке и его родителях
        /// </summary>
        /// <returns></returns>
       public override string InfoPerson()
       {
           string infoPerson = $"{Name} {Sername} Возраст: {Age}, Пол: {Gender}, " +
                               $"{getNameParents(Parent1, Parent2)}";
           return infoPerson;
       }

        /// <summary>
        /// Возвращает случайного ребенка
        /// </summary>
        /// <returns></returns>
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
