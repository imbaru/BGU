using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prog_Lab7
{
    class Program
    {
        private static void ShowMenu()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem(1, "Добавить запись"));
            menuItems.Add(new MenuItem(2, "Список записей"));
            menuItems.Add(new MenuItem(3, "Выход"));
            foreach (var item in menuItems)
            {
                item.Show();
            }
        }

        static void Main(string[] args)
        {
            // Задаем для переменную выхода
            bool exit = false;

            // Проверяем доступность файла данных и создаем его в случае отсутствия
            const string Path = @"D:\Git\BGU\Prog_Lab7\Data\FileBase.txt";

            // Проверяем доступность файла или создаем его
            CustomFile customFile = new CustomFile(Path);

            // Выводим меню на экран
            ShowMenu();

            while (!exit)
            {
                // Получаем ответ от пользователя
                ConsoleKeyInfo Button = Console.ReadKey();

                // Обработка действий на разные нажатия
                switch (Button.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        customFile.AddToList();
                        Console.Clear();
                        ShowMenu();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Список записей:\n");
                        customFile.ShowList();
                        Console.WriteLine("Для продолжения нажмите любую клавишу");

                        if (Console.ReadKey() != null)
                        {
                            Console.Clear();
                            ShowMenu();
                        }
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("\n\nВыход из программы");
                        exit = true;
                        break;
                }
            }
        }
    }
}
