using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        List<int> playerCards = new List<int>();
        List<int> dealerCards = new List<int>();

        // Simulates the player's first two cards being dealt
        for (int j = 0; j < 2; j++)
        {
            int cardNum = rnd.Next(1, 11);
            playerCards.Add(cardNum);
            Console.WriteLine("\nPlayer card: " + cardNum);
        }

        // Simulates dealing two cards to the dealer
        for (int j = 0; j < 2; j++)
        {
            int cardNum = rnd.Next(1, 11);
            dealerCards.Add(cardNum);
            Console.WriteLine("\nDealer card: " + cardNum);
        }

        int playerTotalScore = CalculateTotalScore(playerCards);
        int dealerTotalScore = CalculateTotalScore(dealerCards);

        Console.WriteLine("\nPlayer has a total score of " + playerTotalScore);
        Console.WriteLine("Dealer has a total score of " + dealerTotalScore);

        // Simulates the player's turn
        Console.WriteLine("\nWhat would you like to do? [1] - Hit / [2] - Stand");
        bool playerContinueGame = true;
        while (playerContinueGame)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                int newCardNum = rnd.Next(1, 11);
                playerCards.Add(newCardNum);
                Console.WriteLine("\nPlayer is dealt: " + newCardNum);
                playerTotalScore = CalculateTotalScore(playerCards);
                Console.WriteLine("Player's total score is now: " + playerTotalScore);
                if (playerTotalScore > 21)
                {
                    Console.WriteLine("You have bust! The dealer wins.");
                    playerContinueGame = false;
                }
                else
                {
                    Console.WriteLine("\nWhat would you like to do? [1] - Hit / [2] - Stand");
                }
            }
            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
            {
                Console.WriteLine("\nPlayer stands. Your final score is: " + playerTotalScore);
                playerContinueGame = false;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please press [1] to Hit or [2] to Stand.");
            }
        }

        // Simulates the dealer's turn
        Console.WriteLine("\nDealer's turn:");
        while (dealerTotalScore < 17)
        {
            int newCardNum = rnd.Next(1, 11);
            dealerCards.Add(newCardNum);
            Console.WriteLine("Dealer is dealt: " + newCardNum);
            dealerTotalScore = CalculateTotalScore(dealerCards);
            Console.WriteLine("Dealer's total score is now: " + dealerTotalScore);
        }

        if (dealerTotalScore > 21 || (playerTotalScore <= 21 && playerTotalScore > dealerTotalScore))
        {
            Console.WriteLine("\nYou win!");
        }
        else if (playerTotalScore == dealerTotalScore)
        {
            Console.WriteLine("The game is a draw!");
        }
        else
        {
            Console.WriteLine("\nThe dealer wins!");
        }
    }

    static int CalculateTotalScore(List<int> cards)
    {
        int total = 0;
        foreach (int card in cards)
        {
            total += card;
        }
        return total;
    }
}
