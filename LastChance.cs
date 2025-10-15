namespace AzubiDemo;

using System;
using System.Threading;
using AzubiDemo.HintsLogic;

public class LastChance
{
    public static void Run(int computerNumber, int inputDifficulty)
    {
        HintsInit allHints = new HintsInit();
        Random randomHints = new Random();
        
        Hints randomHintObject = allHints.Hints[randomHints.Next(allHints.Hints.Count)];
        string theTipText = randomHintObject.GeneratorFunction(computerNumber);
        Console.WriteLine($"Hint: {theTipText}");
        DifficultyInit difficulties = new DifficultyInit();
        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];
        int tries = selectedDifficulty.Tries;
        
        
        
        bool isValidInput;
        int playerNumber;
        
        do
        {
            Console.WriteLine("What is my number? (Last Guess)");
            Thread.Sleep(200);
            string userInput = Console.ReadLine();
            isValidInput = int.TryParse(userInput, out playerNumber);

            if (!isValidInput)
            {
                Console.WriteLine("Please enter a valid number!");
                Thread.Sleep(200);
            }
        } while (!isValidInput);

        if (playerNumber == computerNumber)
        {
            GlobalStatus.CurrentStatus = Status.Win_Running;
            Win.Run(computerNumber, inputDifficulty);
        }
        else
        {
            GlobalStatus.CurrentStatus = Status.Lose_Running;
            Lose.Run(computerNumber);
        }
        
    }
}