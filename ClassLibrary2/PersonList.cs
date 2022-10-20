using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс списка людей
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список людей
        /// </summary>
        private Person[] _personList = new Person[0];
        
        /// <summary>
        /// Добавляет человека в конец списка
        /// </summary>
        /// <param name="person"></param>
        public void AddToEnd(Person person)
        {
            int indexOfPerson = _personList.Length;
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[indexOfPerson] = person;
        }

        /// <summary>
        /// Удаляет из списка по индексу
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        public void DeleteByIndex(int index)
        {
            Person[] newPersonList = new Person[_personList.Length - 1];
            int count = 0;
            for (int i = 0; i < _personList.Length; i++)
            {
                if (i == index)
                {
                    i++;
                    count++;
                }
                newPersonList[i - count] = _personList[i];
            }
            _personList = newPersonList;
        }

        /// <summary>
        /// Удаляет человека по названию экземпляра класса Person
        /// </summary>
        /// <param name="person">Экземпляр класса Person</param>
        public void DeleteByPerson(Person person)
        {
            DeleteByIndex(ReadIndexByPerson(person));
        }

        /// <summary>
        /// Возвращает всю информацию о человеке из списка по индексу
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        /// <returns></returns>
        public string ReadPersonByIndex(int index)
        {
            return _personList[index].InfoPerson();
        }

        /// <summary>
        /// Возвращает экземпляр класса Person по индексу из списка
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        /// <returns></returns>
        public Person ReturnPersonByIndex(int index)
        {
            return _personList[index];
        }

        /// <summary>
        /// Удаляет всех людей из списка
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref _personList, 0);
        }

        /// <summary>
        /// Возвращает индекс человека из списка
        /// </summary>
        /// <param name="person">Название экземпляра класса Person</param>
        /// <returns></returns>
        public int ReadIndexByPerson(Person person)
        {
            for (int i = 0; i < _personList.Length; i++)
            {
                if (person == _personList[i])
                {
                    return i;
                }
            }

            throw new Exception("Person not found");
        }

        /// <summary>
        /// Возвращает строки информации о людях
        /// </summary>
        public string ReadAll()
        {
            string result = "";
            for (int i = 0; i < _personList.Length; i++)
            {
                result += _personList[i].InfoPerson() + "\n";
            }

            return result;
        }
        
        /// <summary>
        /// Проверка, существует ли индекс в списке
        /// </summary>
        /// <param name="index"></param>
        private void IsIndexInRange(int index)
        {
            if (index < 0 || index >= _personList.Length)
            {
                throw new Exception("Index not found");
            }
        }
    }
}
