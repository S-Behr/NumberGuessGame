namespace AzubiDemo;

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Guess-Number-Game!\n");

     
        GlobalPlayer.Load();
        Leaderboard.Load(); 

 
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        GlobalPlayer.Name = name;

      
        if (GlobalPlayer.IsKnown(name))
        {
            int currentScore = Leaderboard.GetScoreForPlayer(name);
            Console.WriteLine($"\nWelcome back, {name}! Nice to see you again!");
            Console.WriteLine($"Your current score is: {currentScore} points.");
        }
        else
        {
            Console.WriteLine($"\nNice to meet you, {name}! Your profile has been created.");
            GlobalPlayer.SaveIfNew();
        }

        Thread.Sleep(1500);
        Console.WriteLine($"Good luck, {name}!\n");

        GlobalStatus.CurrentStatus = Status.WhatDifficulty_Running;
        WhatDifficulty.Run();
    }
}