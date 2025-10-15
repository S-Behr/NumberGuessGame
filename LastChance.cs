namespace AzubiDemo;

using System;
using System.Threading;
using AzubiDemo.HintsLogic;

public class LastChance
{
    public static void Run(int computerNumber, int inputDifficulty, int trieseUsed)
    {
        HintsInit allHints = new HintsInit();
        Random randomHints = new Random();
        
        Hints randomHintObject = allHints.Hints[randomHints.Next(allHints.Hints.Count)];
        string theTipText = randomHintObject.GeneratorFunction(computerNumber);
        Console.WriteLine($"Hint: {theTipText}");
        DifficultyInit difficulties = new DifficultyInit();
        Difficulty selectedDifficulty = difficulties.Difficulties[inputDifficulty];
        int tries = selectedDifficulty.Tries;
        int triesUsed = 0; 

        
        
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
        
        triesUsed++;


        if (playerNumber == computerNumber)
        {
            GlobalStatus.CurrentStatus = Status.Win_Running;
            Win.Run(computerNumber, inputDifficulty, triesUsed); 
        }

        else
        {
            GlobalStatus.CurrentStatus = Status.Lose_Running;
            Lose.Run(computerNumber);
        }
        
    }
}