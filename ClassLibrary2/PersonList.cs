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
        private PersonBase[] _personList = new PersonBase[0];

        /// <summary>
        /// Добавляет человека в конец списка
        /// </summary>
        /// <param name="personBase"></param>
        public void AddToEnd(PersonBase personBase)
        {
            int indexOfPerson = _personList.Length;
            Array.Resize(ref _personList, _personList.Length + 1);
            _personList[indexOfPerson] = personBase;
        }

        /// <summary>
        /// Удаляет из списка по индексу
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        public void DeleteByIndex(int index)
        {
            PersonBase[] newPersonList = new PersonBase[_personList.Length - 1];
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
        /// Удаляет человека по названию экземпляра класса PersonBase
        /// </summary>
        /// <param name="personBase">Экземпляр класса PersonBase</param>
        public void DeleteByPerson(PersonBase personBase)
        {
            DeleteByIndex(ReadIndexByPerson(personBase));
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
        /// Возвращает экземпляр класса PersonBase по индексу из списка
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        /// <returns></returns>
        public PersonBase ReturnPersonByIndex(int index)
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
        /// <param name="personBase">Название экземпляра класса PersonBase</param>
        /// <returns></returns>
        public int ReadIndexByPerson(PersonBase personBase)
        {
            for (int i = 0; i < _personList.Length; i++)
            {
                if (personBase == _personList[i])
                {
                    return i;
                }
            }

            throw new Exception("PersonBase not found");
        }

        /// <summary>
        /// Вывести в консоль всю информацию о всех людях
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


        //TODO: Не должен быть тут. (+)
        
    }
}
