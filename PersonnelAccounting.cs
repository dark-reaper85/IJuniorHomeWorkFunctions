using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJuniorHomeWorkFunctions
{
    class PersonnelAccounting
    {
        static void Main(string[] args)
        {
            string[] workers = new string[] 
            {
                "Болтендейл Крис",
                "Кунст Ханси",
                "Хэммет Кирк"
            };

            string[] posts = new string[]
            {
                "вокалист",
                "вокалист",
                "гитарист"
            };

            bool isWorking = true;
            
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1 - Добавить досье");
                Console.WriteLine("2 - Вывести все досье");
                Console.WriteLine("3 - Удалить досье ");
                Console.WriteLine("4 - Поиск по фамилии");
                Console.WriteLine("5 - Выход");
                
                string choseMenu = Console.ReadLine();
                
                switch (choseMenu)
                {
                    case "1":
                        Console.WriteLine("Введите имя нового работника");
                        string addValue = Console.ReadLine();
                        AddFile(ref workers, addValue);
                        Console.WriteLine("Введите должность нового рабтника");
                        addValue = Console.ReadLine();
                        AddFile(ref posts, addValue);
                        Console.WriteLine("Новый работник добавлен");
                        Console.ReadKey();
                        break;
                    case "2":
                        PrintFiles(workers, posts);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Введите номер удаляемого досье");
                        int deletingFileNumber = Convert.ToInt32(Console.ReadLine());

                        if (deletingFileNumber > 0 && deletingFileNumber <= workers.Length)
                        {
                            DeleteFile(ref workers, deletingFileNumber);
                            DeleteFile(ref posts, deletingFileNumber);
                            Console.WriteLine($"Досье №{deletingFileNumber} удалено");
                        }
                        else
                        {
                            Console.WriteLine("Досье с таким номером отсутствует");
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Введите фамилию работника");
                        string surname = Console.ReadLine();
                        FindBySurname(workers, posts, surname);
                        Console.ReadKey();
                        break;
                    case "5":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void PrintFiles(string[] names, string[] posts) 
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + names[i] + " - " + posts[i]);
            }
        }

        static void AddFile(ref string[] array, string value) 
        {
            string[] tempArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[array.Length] = value;
            array = tempArray;
        }

        static void FindBySurname(string[] names, string[] posts, string surname) 
        {
            int found = 0;
            for (int i = 0; i < names.Length; i++)
            {
                found = names[i].IndexOf(" ");
                if (names[i].Substring(0, found).Equals(surname))
                {
                    Console.WriteLine((i + 1) + ": " + names[i] + " - " + posts[i]);
                }
            }
        }

        static void DeleteFile(ref string[] names, int fileNumber) 
        {
            string[] tempArray = new string[names.Length - 1];
                
            for (int i = 0; i < fileNumber - 1; i++)
            {
                tempArray[i] = names[i];
            }
            for (int i = fileNumber; i < names.Length; i++)
            {
                tempArray[i - 1] = names[i];
            }

            names = tempArray;
        }
    }
}
