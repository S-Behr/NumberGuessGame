namespace AzubiDemo;

using System;
using System.Threading;

public class Lose
{
    public static void Run(int computerNumber)
    {
        Console.WriteLine($"My number was {computerNumber}!");
        Thread.Sleep(200);
        
        Console.WriteLine("Next time you will be better!");
        Thread.Sleep(200);
        
        Console.WriteLine("Do you want to play again? Press Y for Yes or N for No.");
        Thread.Sleep(200);
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        Thread.Sleep(500);

        do 
        {
            keyInfo = Console.ReadKey(true);
            
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