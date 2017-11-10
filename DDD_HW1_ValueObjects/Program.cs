using System;
using System.Collections.Generic;

namespace DDD_HW1_ValueObjects
{
    class Program
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to Bingo!\nThe bow of Bingo Numbers is full" +
                " and each turn a new number will be taken from the bow. You must check if you" +
                " have that number in your set! If you get 4 matching numbers from the bow and" +
                " from your card, you win!");

            Player player = new Player();

            Console.Write("\nPlease enter your name: ");
            player.Name = Console.ReadLine();

            List<BingoNumber> bow = GenerateBowOfNumbers();
            GeneratePlayerNumbers(player);

            Console.WriteLine("Your set of numbers are: ");
            foreach (BingoNumber n in player.CardNumbers)
            {
                Console.Write(n.GetNumber + " ");
            }

            foreach (BingoNumber n in bow)
            {
                if (player.Hits >= 4)
                {
                    Console.WriteLine("\nBINGO! You're lucky today " + player.Name + "!" +
                        " Your final score is " + player.GetPlayerFinalScore() + ".");
                    Environment.Exit(0);
                }

                Console.WriteLine("\nDo you have " + n.GetNumber + " in your set?");

                string answr = Console.ReadLine();

                if (answr.ToUpper().Equals("Y"))
                {
                    foreach (BingoNumber i in player.CardNumbers)
                    {
                        // Using the overriden operator for the value objects we can see
                        // that the Equals method works properly. Using the == operator
                        // will yield the same result.
                        if (i.Equals(n))
                        {
                            Console.WriteLine("Correct! Five point for you!");
                            player.Score.Add(new ScoreToken(5));
                            player.Hits += 1;
                            break;
                        }
                        // To check that the != operator works, this checks if a player has
                        // "found" a number in his set, but has no such number in reality.
                        else if (n != player.CardNumbers[player.CardNumbers.Count - 1] &&
                                 player.CardNumbers.LastIndexOf(i) == player.CardNumbers.Count - 1)
                        {
                            Console.WriteLine("LIAR! You are expelled from the game!!");
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Okay, moving on . . .");
                }
            }
        }

        static void GeneratePlayerNumbers(Player player)
        {
            for (int i = 0; i < 25; i++)
            {
                // Does not produce an uniform, unique distribtion.
                player.CardNumbers.Add(new BingoNumber(rnd.Next(1, 76)));
            }
        }

        static List<BingoNumber> GenerateBowOfNumbers()
        {
            List<BingoNumber> temp = new List<BingoNumber>(1000);
            for (int i = 0; i < 1000; i++)
            {
                // Does not produce an uniform, unique distribtion.
                temp.Add(new BingoNumber(rnd.Next(1, 76)));
            }
            return temp;
        }
    }
}
