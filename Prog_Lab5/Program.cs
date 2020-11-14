using System;
using System.Text.RegularExpressions;

namespace Prog_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите строку:");
                Console.WriteLine(FinishStr(Console.ReadLine()));
                Console.WriteLine();
            }
        }

        public static string RegexString(string _str)
        {
            string[] StringArray = Regex.Split(_str, " ");

            string OutString = "";
            string Parrent = "(\\d)";

            foreach (string strg in StringArray)
            {
                var StringRegex = Regex.Match(strg, Parrent);

                if (StringRegex.Success)
                {
                    OutString += strg + " ";
                }
            }

            return OutString.Trim();
        }

        public static string UpFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string LastChar(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            return str.Insert(str.Length, ".");
        }

        public static string FinishStr(string InStr)
        {
            string RgxString = RegexString(InStr);
            RgxString = UpFirst(RgxString);
            RgxString = LastChar(RgxString);
            return RgxString;
        }
    }
}
