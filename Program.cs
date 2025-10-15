namespace AzubiDemo;

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello and welcome to the number guessing game");
        Thread.Sleep(1000);
        
        GlobalStatus.CurrentStatus = Status.WhatDifficulty_Running;
        WhatDifficulty.Run();
    }
}