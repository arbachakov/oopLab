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
    }
}
