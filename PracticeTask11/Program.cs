using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PracticeTask11
{
    class Program
    {
        // Ввод сообщения с клавиатуры
        static string ConsoleInput()
        {
            // Результирующая строка
            string Result;
            // Флаг правильности ввода
            bool ok;
            // Регулярное выражение для сообщения
            Regex regex = new Regex("{0,1}*");
            do
            {
                Console.WriteLine("Введите сообщение из 0 и 1, которое хотите обработать: ");
                Result = Console.ReadLine();
                ok = regex.IsMatch(Result);
                if (!ok)
                    Console.WriteLine("Сообщение должно содержать только 0 и 1.");
            } while (!ok);

            return Result;
        }

        // Шифровка сообщения
        static string EncryptMessage(string Input)
        {
            string Output = "";
            Output += Input[0];
            for (ushort i = 1; i < Input.Length; i++)
                if (Input[i] == Input[i - 1])
                    Output += 1;
                else Output += 0;

            return Output;
        }

        // Расшифровка сообщения
        static string DecryptMessage(string Input)
        {
            string Output = "";
            Output += Input[0];
            for (ushort i = 1; i < Input.Length; i++)
                if (Input[i] == 1)
                    Output += Output[i-1];
                else Output += (Output[i-1] + 1) % 2;

            return Output;
        }

        static void Main(string[] args)
        {
            // Входное сообщение
            string InputMessage;
            // Выходное сообщение
            string OutputMessage;
            // Переменная для работы с файлами
            // Флаг правильности ввода
            bool ok = false;

            // Выбор способа ввода
            do
            {
                Console.Clear();
                //Вывод меню
                Console.WriteLine();
                Console.WriteLine("1 - Ввести выражение с клавиатуры");
                Console.WriteLine("2 - Ввести выражение из файла");

                //Выбор пункта меню и вызов соответствующих функций
                var ChosenOption = Console.ReadKey();
                Console.WriteLine();

                switch (ChosenOption.Key)
                {
                    case (ConsoleKey.D1):
                    case (ConsoleKey.NumPad1):
                        InputMessage = ConsoleInput();
                        ok = true;
                        break;
                    case (ConsoleKey.D2):
                    case (ConsoleKey.NumPad2):
                        InputMessage = FileInput();
                        ok = true;
                        break;
                }
            } while (!ok);

            // Выбор операции
            do
            {
                Console.Clear();
                //Вывод меню
                Console.WriteLine();
                Console.WriteLine("1 - Зашифровать сообщение");
                Console.WriteLine("2 - Расшифровать сообщение");

                //Выбор пункта меню и вызов соответствующих функций
                var ChosenOption = Console.ReadKey();
                Console.WriteLine();

                switch (ChosenOption.Key)
                {
                    case (ConsoleKey.D1):
                    case (ConsoleKey.NumPad1):
                        OutputMessage = EncryptMessage(InputMessage);
                        ok = true;
                        break;
                    case (ConsoleKey.D2):
                    case (ConsoleKey.NumPad2):
                        OutputMessage = DecryptMessage(InputMessage);
                        ok = true;
                        break;
                }
            } while (!ok);
        }
    }
}