using System;

namespace _090221Task
{
    public static class CeoSideHelper
    {
        public static double InputPercent()
        {
            while (true)
            {
                Console.Write(">> ");

                try
                {
                    var percent = Convert.ToDouble(Console.ReadLine());

                    if (percent >= -100 && percent <= 100)
                        return percent;

                    Console.WriteLine("Percent must be between [ 0 - 100 ]");
                }
                catch (Exception)
                {
                    Console.WriteLine("Percent must be numeric value!");
                }
            }
        }
    }
}