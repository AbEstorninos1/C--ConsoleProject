using System;
using System.Linq;

namespace LargestInputtedNumber;

public static class Program
{
    public static void Main()
    {

        Console.Write("Enter num1:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter num2:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter num3:");
        int num3 = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine();

        if (num1 > num2)
        {
            if (num1 > num3)
            {
                Console.WriteLine($"{num1} is the first largest.");
                Console.WriteLine($"{num2} is the second largest.");
                Console.WriteLine($"{num3} is the third largest number.");
            }
            else if (num1 == num3)
            {
                Console.WriteLine($"{num1} and {num3} is both largest.");
                Console.WriteLine($"{num2} is the second largest");
            }
            else
            {
                Console.WriteLine($"{num3} is the first largest.");
                Console.WriteLine($"{num1} is the second largest.");
                Console.WriteLine($"{num2} is the third largest number.");
            }
        }
        else if (num1 == num2)
        {
            Console.WriteLine($"{num1} and {num2} is both largest.");
            Console.WriteLine($"{num3} is the second largest.");
        }
        else if (num1 == num2 && num1 == num3)
        {
            Console.WriteLine("All the number is the same.");
        }
        else
        {
            if (num2 > num3)
            {
                Console.WriteLine($"{num2} is the first largest.");
                Console.WriteLine($"{num1} is the second largest.");
                Console.WriteLine($"{num3} is the third largest number.");
            }
            else if (num2 == num3)
            {
                Console.WriteLine($"{num2} and {num3} is both largest.");
                Console.WriteLine($"{num1} is the second largest.");
            }
            else
            {
                Console.WriteLine($"{num3} is the first largest.");
                Console.WriteLine($"{num2} is the second largest.");
                Console.WriteLine($"{num1} is the third largest number.");
            }
        }

    }
}
