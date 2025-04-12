using System;
using System.Linq;
using System.Diagnostics;
using RockPaperScissor;
using System.Net.NetworkInformation;

namespace RockPaperScissor;

public static class Program
{
    public static void Main()
    {
        string player1Choose, player2Choose, Player1Name, Player2Name;

        Console.Write($"""
       Let's play Rock,Paper and Scissor
       Choices:
       1.Rock/r
       2.Paper/p
       3.Scissor/s
       
       Enter Player 1 Name:
       """);
        Player1Name = Console.ReadLine();

        Console.Write("Enter Player 2 Name:");

        Player2Name = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("Press any key to continue");

        Console.ReadKey();

        Console.Clear();

        Console.Write($"{Player1Name} Choose:");

        player1Choose = Console.ReadLine();

        Console.Clear();

        Console.Write($"{Player2Name} Choose:");
        player2Choose = Console.ReadLine();

        Console.Clear();

        if ((player1Choose.ToLower() == "rock" || player1Choose.ToLower() == "r") && (player2Choose == "scissor" || player2Choose == "s"))
        {
            Console.WriteLine($"{Player1Name} choose rock against scissor.");
            Console.WriteLine();
            Console.WriteLine("Rock breaks scissor.");
            Console.WriteLine();
            Console.Write($"{Player1Name} wins.");
        }

        else if ((player1Choose.ToLower() == "paper" || player1Choose.ToLower() == "p") && (player2Choose == "rock" || player2Choose == "r"))
        {
            Console.WriteLine($"{Player1Name} choose paper against rock.");
            Console.WriteLine();
            Console.WriteLine("Paper cover rock.");
            Console.WriteLine();
            Console.Write($"{Player1Name} wins.");
        }

        else if ((player1Choose.ToLower() == "scissor" || player1Choose.ToLower() == "s") && (player2Choose == "paper" || player2Choose == "p"))
        {
            Console.WriteLine($"{Player1Name} choose scissors against paper.");
            Console.WriteLine();
            Console.WriteLine("Scissors cut paper.");
            Console.WriteLine();
            Console.Write($"{Player1Name} wins.");
        }
        else if ((player2Choose == "rock" || player2Choose.ToLower() == "r") && (player2Choose == "scissor" || player1Choose == "s"))
        {
            Console.WriteLine($"{Player2Name} choose rock against scissor.");
            Console.WriteLine();
            Console.WriteLine("Rock breaks scissor.");
            Console.WriteLine();
            Console.Write($"{Player2Name} wins.");
        }

        else if ((player2Choose == "paper" || player2Choose.ToLower() == "p") && (player2Choose == "rock" || player1Choose == "r"))
        {
            Console.WriteLine($"{Player2Name} choose paper against rock.");
            Console.WriteLine();
            Console.WriteLine("Paper cover rock.");
            Console.WriteLine();
            Console.Write($"{Player2Name} wins.");
        }

        else if ((player2Choose == "scissor" || player2Choose.ToLower() == "s") && (player2Choose == "paper" || player1Choose == "p"))
        {
            Console.WriteLine($"{Player2Name} choose scissors against paper.");
            Console.WriteLine();
            Console.WriteLine("Scissors cut paper.");
            Console.WriteLine();
            Console.Write($"{Player2Name} wins.");
        }
        else if (((player1Choose == "1" || player1Choose.ToLower() == "r") && (player2Choose == "1" || player2Choose == "r")) ||
           ((player1Choose == "2" || player1Choose.ToLower() == "p") && (player2Choose == "2" || player2Choose == "p")) ||
           ((player1Choose == "3" || player1Choose.ToLower() == "s") && (player2Choose == "3" || player2Choose == "s"))
        )
        {
            Console.WriteLine("Nobody Wins.");
        }
    }
}
