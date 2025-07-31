namespace Phonebook;

using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Телефонная книга.
/// </summary>
class Phonebook
{
    #region Свойства

        private static Phonebook instance = null;
        private static readonly object lockObj = new object();
        
        /// <summary>
        /// Список абонентов.
        /// </summary>
        private List<Abonent> abonents = new List<Abonent>();
        /// <summary>
        /// Текстовый файл со списком абонентов.
        /// </summary>
        private string fileName = "phonebook.txt";

    #endregion
    

    /// <summary>
    /// Метод Singleton
    /// </summary>
    public static Phonebook GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Phonebook();
                }
            }
        }
        return instance;
    }
/// <summary>
/// Конструктор.
/// </summary>
    private Phonebook()
    {
        LoadFile();
    }

/// <summary>
/// Загрузка данных из файла (телефонной книги).
/// </summary>
private void LoadFile()
    {
        if (File.Exists(fileName))
        {
            string[] listOfAbonents = File.ReadAllLines(fileName);
            foreach (string abonent in listOfAbonents)
            {
                string[] nameAndNumber = abonent.Split(": ");
                // if (nameAndNumber.Length == 2)
                // {
                    abonents.Add(new Abonent(nameAndNumber[0], nameAndNumber[1]));
                // }
            }
        }
    }

    /// <summary>
    /// Загрузка данных в файл (телефонную книгу).
    /// </summary>
    private void SaveToFile()
    {
        List<string> lines = new List<string>();
        foreach (Abonent abonent in abonents)
        {
            lines.Add(abonent.Name + ": " + abonent.PhoneNumber);
        }
        File.WriteAllLines(fileName, lines);
    }

    /// <summary>
    /// Добавление абонента в книгу c проверкой на дубликат.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <param name="phone">Номер телефона абонента.</param>
    /// <returns></returns>
    public bool AddAbonent(string name, string phone)
    {
        foreach (Abonent abonent in abonents)
        {
            if (abonent.Name == name || abonent.PhoneNumber == phone)
            {
                return false;
            }
        }

        abonents.Add(new Abonent(name, phone));
        SaveToFile();
        return true;
    }

    /// <summary>
    /// Удаление абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона абонента.</param>
    /// <returns></returns>
    public bool RemoveAbonentByPhone(string phone)
    {
        for (int i = 0; i < abonents.Count; i++)
        {
            if (abonents[i].PhoneNumber == phone)
            {
                abonents.RemoveAt(i);
                SaveToFile();
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Поиск абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона абонента.</param>
    /// <returns></returns>
    public Abonent GetByPhone(string phone)
    {
        foreach (Abonent abonent in abonents)
        {
            if (abonent.PhoneNumber == phone)
                return abonent;
        }
        return null;
    }

    /// <summary>
    /// Поиск номера телефона абонента по имени.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string GetPhoneByName(string name)
    {
        foreach (Abonent abonent in abonents)
        {
            if (abonent.Name == name)
                return abonent.PhoneNumber;
        }
        return null;
    }

    /// <summary>
    /// Вывод всех абонентов.
    /// </summary>
    public void PrintAllAbonents()
    {
        Console.WriteLine("-------# Список всех абонентов #-------");
        foreach (Abonent abonent in abonents)
        {
            Console.WriteLine(abonent.Name + ": " + abonent.PhoneNumber);
        }
    }

}