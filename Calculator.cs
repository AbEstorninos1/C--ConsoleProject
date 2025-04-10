using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator;
class calculator
{

    string Answer = "";

    static void Main()
    {
        calculator cal = new calculator();
        cal.Function();

    }
    void printBoard(string Input)
    {
        Console.Clear();
        string[,] board =

        {
                {"    Calculator    "},
                {"\n _________________"},
                {$"\n |{Input,15}|"},
                {$"\n |{Answer,15}|"},
                {" \n |_______________|"},
                {"\n |   |   |   |   |"},
                {$"\n | c | ÷ | x | z |"},
                {"\n |___|___|___|___|"},
                {$"\n | 1 | 2 | 3 | - |"},
                {"\n |___|___|___|___|"},
                {$"\n | 4 | 5 | 6 | + |"},
                {"\n |___|___|___|___|"},
                {$"\n | 7 | 8 | 9 |   |"},
                {$"\n |___|___|___| = |"},
                {$"\n | % | 0 | . |   |"},
                {"\n |___|___|___|___|"}

            };

        foreach (var Board in board)
        {
            Console.Write(Board);
        }
    }
    void Function()
    {

        List<object> list = new List<object>();
        StringBuilder sb = new StringBuilder();
        string currentNumber = "";
        string[] operators = { "x", "/", "+", "-", "%" };

        while (true)
        {

            printBoard(sb.ToString());
            Console.SetCursorPosition(0, 16);
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (char.IsDigit(key.KeyChar) || key.KeyChar == '.')
            {

                currentNumber += key.KeyChar;
                sb.Append(key.KeyChar);
            }

            else if (key.KeyChar == 'z' || key.KeyChar == (char)ConsoleKey.Backspace)
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    if (currentNumber.Length > 0)
                    {
                        currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);

                    }
                }
            }

            else if (key.KeyChar == 'c')
            {
                sb.Clear();
                list.Clear();
                Answer = "";
                currentNumber = "";
            }

            else if (Array.Exists(operators, op => op == key.KeyChar.ToString()))
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    list.Add(currentNumber);
                    currentNumber = "";
                }

                list.Add(key.KeyChar.ToString());
                sb.Append(key.KeyChar);
            }

            else if (key.KeyChar == '=' || key.KeyChar == (char)ConsoleKey.Enter)
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    list.Add(currentNumber);
                }
                Total(list);

                sb.Append(Answer);
                sb.Clear();
                currentNumber = "";
            }
        }
    }

    void Total(List<object> list)
    {

        double total = 0;
        double currentNumber = 0;
        string currentOperator = "+";

        foreach (var item in list)
        {
            if (item is string strItem && double.TryParse(strItem, out currentNumber))
            {

                switch (currentOperator)
                {
                    case "+":
                        total += currentNumber;
                        break;
                    case "-":
                        total -= currentNumber;
                        break;
                    case "x":
                    case "*":
                        total *= currentNumber;
                        break;
                    case "/":
                        if (currentNumber != 0)
                        {
                            total /= currentNumber;
                        }
                        break;
                    case "%":
                        currentNumber *= 0.01;
                        total *= currentNumber;
                        break;
                }
            }

            else if (item is string op)
            {
                currentOperator = op;

            }
        }

        Answer = total.ToString();
        list.Clear();
        list.Add(Answer);
    }
}
