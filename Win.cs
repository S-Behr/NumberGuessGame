namespace AzubiDemo;

using System;
using System.Threading;

public class Win
{

    public static int CalculateScore(Difficulty difficulty, int usedTries)
    {
 
        if (usedTries < 1)
            usedTries = 1;

     
        double factor = 1.0 - ((double)(usedTries - 1) / difficulty.Tries);

       
        if (factor < 0) factor = 0;

        int score = (int)(difficulty.MaxScore * factor);
        return score;
    }

    public static void Run(int computerNumber, int inputDifficulty, int usedTries)
    {
        DifficultyInit difficulties = new DifficultyInit();
        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];

        int score = CalculateScore(selectedDifficulty, usedTries); 

        Console.WriteLine($"Perfect! My number was {computerNumber}!");
        Thread.Sleep(200);
        Console.WriteLine($"You win! You needed {usedTries} tries.");
        Thread.Sleep(200);
        Console.WriteLine($"You earned {score} points!");
        Thread.Sleep(400);

     
        Leaderboard.Add(GlobalPlayer.Name, score);

      
        Leaderboard.Show();

      
        Console.WriteLine("\nDo you want to play again? Press Y for Yes or N for No.");
        Thread.Sleep(200);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            Console.WriteLine();

            if (keyInfo.Key == ConsoleKey.Y)
            {
                GlobalStatus.CurrentStatus = Status.WhatDifficulty_Running;
                Console.Clear();
                WhatDifficulty.Run();
                return;
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                Console.WriteLine($"See you next time {GlobalPlayer.Name}!");
                Thread.Sleep(500);
                GlobalStatus.CurrentStatus = Status.Finished;
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid key! Please press Y or N.");
                Thread.Sleep(500);
            }
        } while (keyInfo.Key != ConsoleKey.Y && keyInfo.Key != ConsoleKey.N);
    }
}



 