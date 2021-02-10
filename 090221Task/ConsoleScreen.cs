using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _090221Task
{
    public static class ConsoleScreen
    {
        public static string[] MainMenuOptions { get; }
        public static string[] CeoMenuOptions { get; }
        public static string[] ManagersMenuOptions { get; }
        public static string[] ManagerMenuOptions { get; }
        public static string[] WorkersMenuOptions { get; }
        public static string[] WorkerMenuOptions { get; }

        static ConsoleScreen()
        {
            MainMenuOptions = new [] { "CEO", "Managers", "Workers", "Exit" };
            CeoMenuOptions = new [] { "Info", "Control", "Organize", "Make meeting", "Change credit percent", "Back"};
            ManagersMenuOptions = new [] { "Show Managers", "Switch Manager", "Back"};
            ManagerMenuOptions = new [] { "Info", "Control", "Organize", "Calculate salaries", "Back"};
            WorkersMenuOptions = new [] { "Show workers", "Switch Worker", "Back"};
            WorkerMenuOptions = new [] { "Info", "Add Operation", "Back"};
        }

        public static int Input(int length)
        {
            while (true)
            {
                Console.Write(">> ");

                var status = int.TryParse(Console.ReadLine(), out int choice);

                if (status)
                {
                    if (choice > 0 && choice <= length)
                        return choice;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Input must be between [ 1 - {length} ]!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numeric value!");
                }
                Console.ResetColor();
            }
        }

        public static void PrintMenu(string[] options)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.ResetColor();
        }

        public static void Clear()
        {
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
