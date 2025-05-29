namespace Phonebook;
using System;

class Program
{
    static void Main(string[] args)
    {
        Phonebook book = Phonebook.GetInstance();

        while (true)
        {
            Console.WriteLine("\n1. Добавить нового абонента." +
                              "\n2. Удалить по номеру." +
                              "\n3. Найти по номеру." +
                              "\n4. Найти по имени." +
                              "\n5. Показать всё." +
                              "\n6. Выход.");
            
            Console.Write("Введите действие: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Write("Имя: ");
                string name = Console.ReadLine();
                Console.Write("Телефон: ");
                string phone = Console.ReadLine();
                bool added = book.AddAbonent(name, phone);
                if (added)
                {
                    Console.WriteLine("Добавлено");
                }
                else
                {
                    Console.WriteLine("Уже существует");
                }
            }
            
            else if (input == "2")
            {
                Console.Write("Телефон: ");
                string phone = Console.ReadLine();
                Console.WriteLine(book.RemoveAbonentByPhone(phone) ? "Удалено" : "Не найден");
            }
            
            else if (input == "3")
            {
                Console.Write("Телефон: ");
                string phone = Console.ReadLine();
                Abonent abonent = book.GetByPhone(phone);
                if (abonent != null)
                {
                    Console.WriteLine("Имя: " + abonent.Name);
                }
                else
                {
                    Console.WriteLine("Не найден");
                }
            }
            
            else if (input == "4")
            {
                Console.Write("Имя: ");
                string name = Console.ReadLine();
                string phone = book.GetPhoneByName(name);
                if (phone != null)
                {
                    Console.WriteLine("Телефон: " + phone);
                }
                else
                {
                    Console.WriteLine("Не найден");
                }
            }
            
            else if (input == "5")
            {
                book.PrintAllAbonents();
            }
            
            else if (input == "6")
            {
                Console.WriteLine("До следующего использования, пока!");
                break;
            }
            
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
        }
    }
}