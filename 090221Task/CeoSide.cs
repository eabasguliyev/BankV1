using System;
using _090221Task.Entities;
using _090221Task.Enums;
using _090221Task.Exceptions;

namespace _090221Task
{
    public static class CeoSide
    {
        public static void Start(Bank bank)
        {
            Console.Title = $"{bank.Name}: CEO";
            var ceoMenuLoop = true;

            while (ceoMenuLoop)
            {
                ConsoleScreen.PrintMenu(ConsoleScreen.CeoMenuOptions);

                var choice = ConsoleScreen.Input(ConsoleScreen.CeoMenuOptions.Length);

                Console.Clear();

                switch ((CeoMenuOptions) choice)
                {
                    case CeoMenuOptions.Info:
                    {
                        Console.WriteLine(bank.Ceo);
                        ConsoleScreen.Clear(); 
                        break;
                    }
                    case CeoMenuOptions.Control:
                    {
                        try
                        {
                            bank.Ceo.Control(bank.Workers.Data);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear(); 
                        break;
                    }
                    case CeoMenuOptions.Organize:
                    {
                        try
                        {
                            bank.Ceo.Organize(bank.Workers.Data);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear(); 
                        break;
                    }
                    case CeoMenuOptions.MakeMeeting:
                    {
                        try
                        {
                            bank.Ceo.Organize(bank.Workers.Data);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        ConsoleScreen.Clear(); 
                        break;
                    }
                    case CeoMenuOptions.ChangeCreditPercent:
                    {
                        while (true)
                        {
                            Console.WriteLine($"Old percent: {bank.Percentage:P1}");
                            Console.WriteLine("New percent: ");
                            var percent = CeoSideHelper.InputPercent() / 100;

                            try
                            {
                                bank.Ceo.ChangePercentage(percent, bank);

                                Console.WriteLine("Bank percent changed!");
                                ConsoleScreen.Clear();
                                break;
                            }
                            catch (BankPercentException e) when (e.BankPercentage < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Bank percent must be greater or equal to zero.");
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                            }
                            catch (BankPercentException e) when (e.BankPercentage > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Bank percent must be lower or equal to hundred.");
                                Console.ResetColor();
                                ConsoleScreen.Clear();
                            }
                        }
                        break;
                    }
                    case CeoMenuOptions.Back:
                    {
                        ceoMenuLoop = false;
                        break;
                    }
                }
            }
        }
    }
}
