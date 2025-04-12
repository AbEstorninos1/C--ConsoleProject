using System;
using System.Linq;

namespace DateConvert
{
    public static class Program
    {
        public static void Main()
        {
            string dateString, day, year, month;

            Console.Write("Enter date:");
            dateString = Console.ReadLine();

            month = dateString.Substring(0, 2);
            day = dateString.Substring(2, 2);
            year = dateString.Substring(4, 4);

            if (month == "01")
            {
                Console.Write($"January {day}, {year}");
            }
            else if (month == "02")
            {
                Console.Write($"February {day}, {year}");
            }
            else if (month == "03")
            {
                Console.Write($"March {day}, {year}");
            }
            else if (month == "04")
            {
                Console.Write($"April {day}, {year}");
            }
            else if (month == "05")
            {
                Console.Write($"May {day}, {year}");
            }
            else if (month == "06")
            {
                Console.Write($"June {day}, {year}");
            }
            else if (month == "07")
            {
                Console.Write($"July {day}, {year}");
            }
            else if (month == "08")
            {
                Console.Write($"August {day}, {year}");
            }
            else if (month == "09")
            {
                Console.Write($"November {day}, {year}");
            }
            else if (month == "10")
            {
                Console.Write($"December {day}, {year}");
            }
            else if (month == "11")
            {
                Console.Write($"November {day}, {year}");
            }
            else if (month == "12")
            {
                Console.Write($"December {day}, {year}");
            }
            else
            {
                Console.Write("Invalid date");
            }

        }
    }
}