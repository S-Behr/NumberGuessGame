namespace AzubiDemo;

using System;
using System.Threading;

public class GameLogic
{
    private static Random randomNumber = new Random();
    private static int computerNumber;

    public static void Run(int inputDifficulty)
    {
        DifficultyInit difficulties = new DifficultyInit();
        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];
        int tries = selectedDifficulty.Tries;

        computerNumber = randomNumber.Next(0, 101);
        Console.WriteLine(computerNumber); // Debug: zeigt die Zahl

        int triesRemaining = tries;
        Console.WriteLine($"Test {triesRemaining}");
        bool isValidInput;
        int playerNumber; // Player Guess
        int triesUsed = 0;

        do
        {
            do
            {
                Console.WriteLine("What is my number? ");
                Thread.Sleep(200);
                string userInput = Console.ReadLine();
                isValidInput = int.TryParse(userInput, out playerNumber);

                if (!isValidInput)
                {
                    Console.WriteLine("Please enter a valid number!");
                    Thread.Sleep(200);
                }
            } while (!isValidInput);
            
            triesUsed++;

            if (playerNumber == computerNumber)
            {
                GlobalStatus.CurrentStatus = Status.Win_Running;
                Win.Run(computerNumber, inputDifficulty, triesUsed); 
                return;
            }

            else if (playerNumber > computerNumber && triesRemaining >= 2)
            {
                Console.WriteLine("My number is smaller!");
                Thread.Sleep(200);
                triesRemaining--;
                Console.WriteLine($"Tries remaining: {triesRemaining}");
            }
            else if (playerNumber < computerNumber && triesRemaining >= 2)
            {
                Console.WriteLine("My number is bigger!");
                Thread.Sleep(200);
                triesRemaining--;
                Console.WriteLine($"Tries remaining: {triesRemaining}");
            }

        } while (playerNumber != computerNumber && triesRemaining > 1);

        if (playerNumber != computerNumber)
        {
            GlobalStatus.CurrentStatus = Status.LastChance_Running;
            LastChance.Run(computerNumber, inputDifficulty, triesUsed);
            return;
        }
        
    }
 }