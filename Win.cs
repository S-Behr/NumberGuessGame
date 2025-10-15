namespace AzubiDemo;

using System;
using System.Threading;

public class Win
{
    public static void Run(int computerNumber, int inputDifficulty)
    {
        
        DifficultyInit difficulties = new DifficultyInit();
        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];
        int tries = selectedDifficulty.Tries;
        
        Console.WriteLine($"Perfect! My number was {computerNumber}!");
        Thread.Sleep(200);
        Console.WriteLine("You win!");
        Thread.Sleep(200);
        Console.WriteLine("Do you want to play again? Press Y for Yes or N for No.");
        Thread.Sleep(200);
        Console.WriteLine(tries);
        ConsoleKeyInfo keyInfo; 
        
        do
        {
            keyInfo = Console.ReadKey(true);
            Console.WriteLine(); 
            
            if (keyInfo.Key == ConsoleKey.Y) {
               
                GlobalStatus.CurrentStatus = Status.WhatDifficulty_Running; 
                Console.Clear();
                WhatDifficulty.Run();
                return;
              
            } else if (keyInfo.Key == ConsoleKey.N) {
                Console.WriteLine("See you next time!");
                Thread.Sleep(500);
                GlobalStatus.CurrentStatus = Status.Finished;
                Environment.Exit(0);
            }else{
                Console.WriteLine("Invalid key! Please press Y or N.");
                Thread.Sleep(500);
            }
        } while (keyInfo.Key != ConsoleKey.Y && keyInfo.Key != ConsoleKey.N); 
    }
}

//DRY Don't Repeat Yourself!
public static class Game {
    public static void WriteLine(string message, int timeout)
    {
        Console.WriteLine(message);
        Thread.Sleep(timeout);
    }
}

 