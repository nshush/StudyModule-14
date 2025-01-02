using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 79990000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 79990000014, "innokentii@example.com"));

            var sortedPhoneBook = phoneBook
                .OrderBy(contact => contact.Name)
                .ThenBy(contact => contact.LastName)
                .ToList();

            while (true)
            {
                Console.WriteLine("Введите номер страницы от 1 до 3 (или нажмите 'q' для выхода):");

                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input == 'q' || input == 'Q')
                {
                    break;
                }

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);


                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine("Страницы не существует");
                }

                else
                {
                    var pageContent = sortedPhoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    foreach (var entry in pageContent)
                        Console.WriteLine($"{entry.Name} {entry.LastName}: {entry.PhoneNumber}");

                    Console.WriteLine();
                }
            }
        }
    }

    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, string email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }
}