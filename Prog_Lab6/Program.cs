using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Prog_Lab6
{
    class Program
    {
        //Вывод меню
        public static void ShowMenu()
        {
            Console.WriteLine("Выбирете действие:\n\n" +
                "1. Добавить запись\n" +
                "2. Список записей\n" +
                "3. Выход\n");
        }

        // Проверка файла на существование
        public static void TestFileBase(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    Console.WriteLine($"Файл данных создан: {path}\n");
                    using (FileStream fileStream = new FileStream(path, FileMode.Append))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.WriteLine($"Номер телефона;ФИО;Адрес");
                        }
                    }

                }

                else
                {
                    Console.WriteLine($"Файл данных доступен: {path}\n");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Добавление записи в файл
        public static void AddToList(string path)
        {
            List<string> NewLine = new List<string>();

            Console.WriteLine("Введите номер телефона:");
            string Number = Console.ReadLine();
            while (Number.Length != 11 || !Regex.Match(Number, "(\\w+)").Success || Number == null)
            {
                Console.WriteLine("ОШИБКА: Номер телефона должен содержать только цифры и быть 11-значным\n");
                Console.WriteLine("Введите номер телефона:\n");
                Number = Console.ReadLine();
            }

            Console.WriteLine("Введите ФИО:");
            string Fio = Console.ReadLine();
            while (Fio == null)
            {
                Console.WriteLine("Поле не может быть пустым\n");
                Console.WriteLine("Введите ФИО:");
                Fio = Console.ReadLine();
            }

            Console.WriteLine("Введите адрес:");
            string Address = Console.ReadLine();
            while (Address == null)
            {
                Console.WriteLine("Поле не может быть пустым\n");
                Console.WriteLine("Введите адрес:");
                Address = Console.ReadLine();
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Append))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine($"{Number};{Fio};{Address}");
                }
            }
        }

        // Вывести содержимое файла
        public static void ShowList(string path, string _char)
        {
            List<string> Columns = new List<string>();
            List<Dictionary<string, string>> Data = new List<Dictionary<string, string>>();

            if (File.Exists(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        char[] charitem = new char[] { Char.Parse(_char) };

                        string StringLine = streamReader.ReadLine();
                        string[] StringSplit = StringLine.Split(charitem);


                        foreach (var item in StringSplit)
                        {
                            Columns.Add(item);
                        }

                        StringLine = streamReader.ReadLine();
                        while (StringLine != null)
                        {
                            StringSplit = StringLine.Split(charitem);
                            Dictionary<string, string> Row = new Dictionary<string, string>();

                            for (int i = 0; i <= StringSplit.GetUpperBound(0); i++)
                            {
                                Row.Add(Columns[i], StringSplit[i]);
                            }
                            Data.Add(Row);
                            StringLine = streamReader.ReadLine();
                        }
                    }
                }
            }


            //List<Dictionary<string, string>> GetData = List(path, _char, List<string> columns);

            foreach (var item in Columns)
            {
                Console.Write("{0, -35}", item);
            }
            Console.WriteLine();

            foreach (var Item in Data)
            {
                foreach (var Col in Columns)
                {
                    Console.Write("{0, -35}", Item[Col]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Указываем путь до файла
            const string Path = @"D:\Git\Prog_Lab6\Data\FileBase.txt";

            // Задаем для организации выхода
            bool exit = false;

            // Проверяем доступность файла данных и создаем его в случае отсутствия
            TestFileBase(Path);

            // Выводим меню на экран
            ShowMenu();

            while (!exit)
            {
                // Получаем ответ от пользователя
                ConsoleKeyInfo Button = Console.ReadKey();

                // Обработка действий на разные нажатия клавиш
                switch (Button.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        AddToList(Path);
                        Console.Clear();
                        ShowMenu();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Список записей:\n");
                        ShowList(Path, ";");

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
