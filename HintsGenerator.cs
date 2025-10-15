namespace AzubiDemo;
using System;


public static class HintsGenerator
{
    //CrossSum
    public static string GetCrossSumHint(int number)
    {
        int sum = 0;
        int temp = number;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }
        return $"The sum of my number is {sum}";
    }
    
    //Range
    public static string GetRangeHint(int number)
    {
        const int RangeWidth = 10;
        int halfRange = RangeWidth / 2;
        int min = Math.Max(0, number - halfRange);
        int max = Math.Min(100, number + halfRange);
        return $"The range is {min} to {max}";
    }
    
    //FirstDigit

    public static string GetFirstDigitHint(int number)
    {
        int firstDigit = number;

        if (number >= 10 && number <= 99)
        {
            firstDigit = number / 10;
        }
        else if(number == 100)
        {
            firstDigit = 1;
        }
        else if (number >= 0 && number <= 9)
        {
            firstDigit = 0;
        }
        return $"My number starts with the Digit {firstDigit}.";
    }
}