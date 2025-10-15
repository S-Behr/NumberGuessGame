namespace AzubiDemo;

using System;
using System.Threading;


public class WhatDifficulty
    {
    public static void Run()
    {



        Console.WriteLine("What difficulty u want to play? ");
        Thread.Sleep(500);

        DifficultyInit difficulties = new DifficultyInit();
        Console.WriteLine("Difficulty 0: Easy");
        Thread.Sleep(20);
        Console.WriteLine("Difficulty 1: Medium");
        Thread.Sleep(20);
        Console.WriteLine("Difficulty 2: Hard");
        Thread.Sleep(20);
        Console.WriteLine("Difficulty 3: Ultra");
        Thread.Sleep(20);

        // lesen was eingegeben wird
        // erlauben nur bestimmte Zahlen

        bool isValidInput;
        int inputDifficulty;
        do
        {
            string userInput = Console.ReadLine();
            isValidInput = int.TryParse(userInput, out inputDifficulty);

        } while (!isValidInput ||
                 !(inputDifficulty < difficulties.Difficulties.Count)); // wieso checken wir das so wie wir es checken?

        // while(!(isValidInput && inputDifficulty < difficulties.Difficulties.Count))
        //(false || true) -> (true || false)
        // wann kommen wir raus?
        // wir kommen raus wenn wenn die Bedingung FALSE ist!


        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];
        Console.WriteLine($"U selectet {selectedDifficulty.Name} with {selectedDifficulty.Tries} tries");
        Thread.Sleep(200);

        // int tries = selectedDifficulty.Tries;

        Console.WriteLine("Let´s Go! Guess my Number.");
        Thread.Sleep(200);

        GlobalStatus.CurrentStatus = Status.GameLogic_Running;
        GameLogic.Run(inputDifficulty);
    }
}