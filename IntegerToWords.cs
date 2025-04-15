using System;
using System.Linq;

namespace IntegerToWord;

public static class Program
{
    public static void Main()
    {
        Console.Write("Enter number(1-2000):");
        int number = int.Parse(Console.ReadLine());

        string num = number.ToString(); // Convert the number to string to access the index
        string result = "";


        if (number < 0 &&number > 2000) //determine if the number is greater than
        {
            Console.Write("0 - 2000 only.");
        }

        if (num.Length == 4 && number > 0 && number <= 2000) //determine if the number length of 4
        {
            if (num[0] == '1') //if the first number is 1
            {
                result += "One Thousand";
                number -= 1000;

                if (number >= 0 && number < 100)
                {
                    result += "";
                }
                else if (number >= 100 && number < 200)
                {
                    result += " One Hundred";
                    number -= 100;
                }
                else if (number >= 200 && number < 300)
                {
                    result += " Two Hundred";
                    number -= 200;
                }
                else if (number >= 300 && number < 400)
                {
                    result += " Three Hundred";
                    number -= 300;
                }
                else if (number >= 400 && number < 500)
                {
                    result += " Four Hundred";
                    number -= 400;
                }
                else if (number >= 500 && number < 600)
                {
                    result += " Five Hundred";
                    number -= 500;
                }
                else if (number >= 600 && number < 700)
                {
                    result += " Six Hundred";
                    number -= 600;
                }
                else if (number >= 700 && number < 800)
                {
                    result += " Seven Hundred";
                    number -= 700;
                }
                else if (number >= 800 && number < 900)
                {
                    result += " Eight Hundred";
                    number -= 800;
                }
                else if (number >= 900 && number < 1000)
                {
                    result += " Nine Hundred";
                    number -= 900;
                }
                else
                {
                    Console.Write("Invalid number");
                }

            }
            else if (num[0] == '2') // if the first number is 2;
            {
                result += "Two Thousand";
            }


        }
        else if (num.Length == 3 && number > 0 && number <= 2000) // if the number is only 3 digit
        {

            if (number >= 100 && number < 200)
            {
                result += "One Hundred";
                number -= 100;
            }
            else if (number >= 200 && number < 300)
            {
                result += "Two Hundred";
                number -= 200;

            }
            else if (number >= 300 && number < 400)
            {
                result += "Three Hundred";
                number -= 300;
            }
            else if (number >= 400 && number < 500)
            {
                result += "Four Hundred";
                number -= 400;

            }
            else if (number >= 500 && number < 600)
            {
                result += "Five Hundred";
                number -= 500;
            }
            else if (number >= 600 && number < 700)
            {
                result += "Six Hundred";
                number -= 600;
            }
            else if (number >= 700 && number < 800)
            {
                result += "Seven Hundred";
                number -= 700;
            }
            else if (number >= 800 && number < 900)
            {
                result += "Eight Hundred";
                number -= 800;
            }
            else if (number >= 900 && number < 1000)
            {
                result += "Nine Hundred";
                number -= 900;
            }
        }
        else if (num.Length == 2 && number > 0 && number <= 2000) // if the number is 2 digit only
        {
            if (number >= 0 && number < 10)
            {
                result += " ";
            }

            else if (number >= 20 && number < 30)
            {
                number -= 20;
                result += "Twenty";
            }
            else if (number >= 30 && number < 40)
            {
                number -= 30;
                result += "Thirty";
            }
            else if (number >= 40 && number < 50)
            {
                number -= 40;
                result += "Fourty";
            }
            else if (number >= 50 && number < 60)
            {
                number -= 50;
                result += "Fifty";
            }
            else if (number >= 60 && number < 70)
            {
                number -= 60;
                result += "Sixty";
            }
            else if (number >= 70 && number < 80)
            {
                number -= 70;
                result += "Seventy";
            }
            else if (number >= 80 && number < 90)
            {
                number -= 80;
                result += "Eighty";
            }
            else if (number >= 90 && number < 100)
            {
                number -= 90;
                result += "Ninety";

            }
        }


        if (number >= 10 && number < 20) //if the number is 10 to eleven
        {
            if (number == 10)
            {
                result += "ten";
            }
            else if (number == 11)
            {
                result += "eleven";
            }
            else if (number == 12)
            {
                result += "twelve";
            }
            else if (number == 13)
            {
                result += "thirteen";
            }
            else if (number == 14)
            {
                result += "fourteen";
            }
            else if (number == 15)
            {
                result += "fifthteen";
            }
            else if (number == 16)
            {
                result += "sixteen";
            }
            else if (number == 17)
            {
                result += "seventeen";
            }
            else if (number == 18)
            {
                result += "eighteen";
            }
            else if (number == 19)
            {
                result += "nineteen";
            }
            else if (number == 20)
            {
                result += "twenty";
            }
        }


        if (number >= 20 && number < 30) // if the number is 20
        {
            number -= 20;
            result += " twenty";//add space to combine it to 3 - 4 digit number for better output.
        }
        else if (number >= 30 && number < 40)
        {
            number -= 30;
            result += " Thirty";
        }
        else if (number >= 40 && number < 50)
        {
            number -= 40;
            result += " Fourty";
        }
        else if (number >= 50 && number < 60)
        {
            number -= 50;
            result += " Fifty";
        }
        else if (number >= 60 && number < 70)
        {
            number -= 60;
            result += " Sixty";
        }
        else if (number >= 70 && number < 80)
        {
            number -= 70;
            result += " Seventy";
        }
        else if (number >= 80 && number < 90)
        {
            number -= 80;
            result += " Eighty";
        }
        else if (number >= 90 && number < 100)
        {
            number -= 90;
            result += " Ninety";
        }


        if (num.Length == 2 && number >= 20 && number < 30) //if the number is 2 digit only 
        {
            number -= 20;
            result += "twenty";
        }
        else if (num.Length == 2 && number >= 30 && number < 40)
        {
            number -= 30;
            result += "Thirty";
        }
        else if (num.Length == 2 && number >= 40 && number < 50)
        {
            number -= 40;
            result += "Fourty";
        }
        else if (num.Length == 2 && number >= 50 && number < 60)
        {
            number -= 50;
            result += "Fifty";
        }
        else if (num.Length == 2 && number >= 60 && number < 70)
        {
            number -= 60;
            result += "Sixty";
        }
        else if (num.Length == 2 && number >= 70 && number < 80)
        {
            number -= 70;
            result += "Seventy";
        }
        else if (num.Length == 2 && number >= 80 && number < 90)
        {
            number -= 80;
            result += "Eighty";
        }
        else if (num.Length == 2 && number >= 90 && number < 100)
        {
            number -= 90;
            result += "Ninety";
        }


        if (num.Length == 1 && number == 0) //if the number is 1 digit
        {
            result += "Zero";
        }
        else if (num.Length == 1 && number == 1)
        {
            result += "One";
        }
        else if (num.Length == 1 && number == 2)
        {
            result += "Two";
        }
        else if (num.Length == 1 && number == 3)
        {
            result += "Three";
        }
        else if (num.Length == 1 && number == 4)
        {
            result += "Four";
        }
        else if (num.Length == 1 && number == 5)
        {
            result += "Five";
        }
        else if (num.Length == 1 && number == 6)
        {
            result += "Six";
        }
        else if (num.Length == 1 && number == 7)
        {
            result += "Seven";
        }
        else if (num.Length == 1 && number == 8)
        {
            result += "Eight";
        }
        else if (num.Length == 1 && number == 9)
        {
            result += "Nine";
        }


        if (num.Length != 1 && number == 0) //if the number is not 1 digit
        {
            result += " Zero";//Add space for good ouput
        }
        if (num.Length != 1 && number == 1)
        {
            result += " One";
        }
        else if (num.Length != 1 && number == 2)
        {
            result += " Two";
        }
        else if (num.Length != 1 && number == 3)
        {
            result += " Three";
        }
        else if (num.Length != 1 && number == 4)
        {
            result += " Four";
        }
        else if (num.Length != 1 && number == 5)
        {
            result += " Five";
        }
        else if (num.Length != 1 && number == 6)
        {
            result += " Six";
        }
        else if (num.Length != 1 && number == 7)
        {
            result += " Seven";
        }
        else if (num.Length != 1 && number == 8)
        {
            result += " Eight";
        }
        else if (num.Length != 1 && number == 9)
        {
            result += " Nine";
        }

        Console.Write(result);
    }
}
