using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prog_Lab7
{
    public class CustomFile
    {
        public string Path { get; set; }

        public CustomFile(string _Path)
        {
            Path = _Path;
            TestFileBase();
        }

        private void TestFileBase()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    File.Create(Path).Dispose();
                    Console.WriteLine($"Файл данных создан: {Path}\n");
                    using (FileStream fileStream = new FileStream(Path, FileMode.Append))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.WriteLine($"Номер телефона;ФИО;Адрес");
                        }
                    }
                }

                else
                {
                    Console.WriteLine($"Файл данных доступен: {Path}\n");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddToList()
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

            using (FileStream fileStream = new FileStream(Path, FileMode.Append))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine($"{Number};{Fio};{Address}");
                }
            }
        }
        public void ShowList()
        {
            List<string> Columns = new List<string>();
            List<Dictionary<string, string>> Data = new List<Dictionary<string, string>>();

            if (File.Exists(Path))
            {
                using (FileStream fileStream = new FileStream(Path, FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        char[] charitem = new char[] { ';' };

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
    }
}
