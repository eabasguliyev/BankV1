using System;
using _090221Task.AbstractClasses;

namespace _090221Task.Login
{
    public static class LoginHelper
    {
        public static void GetLoginData(out Guid id, out string pin)
        {
            Console.WriteLine("Enter id: ");

            while (true)
            {
                try
                {
                    id = Guid.Parse(Input());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Guid format! Try again.");
                }
            }

            Console.WriteLine("Enter pin: ");

            pin = Input();
        }

        private static string Input()
        {
            var str = String.Empty;
            while (true)
            {
                Console.Write(">> ");

                str = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(str))
                    return str;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input can not be empty.");
                Console.ResetColor();
            }
        }
    }
}