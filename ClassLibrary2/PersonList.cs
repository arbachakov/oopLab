using System;

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
            IsIndexInRange(index);
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
            IsIndexInRange(index);
            return _personList[index].InfoPerson();
        }

        /// <summary>
        /// Возвращает экземпляр класса PersonBase по индексу из списка
        /// </summary>
        /// <param name="index">Индекс человека по списку</param>
        /// <returns></returns>
        public PersonBase ReturnPersonByIndex(int index)
        {
            IsIndexInRange(index);
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
        /// Возвращает строковую информацию обо всех Person из PersonList
        /// </summary>
        public string ReadAll()
        {
            string result = "";
            foreach (var person in _personList)
            {
                result += person.InfoPerson() + "\n";
            }

            return result;
        }

        //TODO: Не используется (+)
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
