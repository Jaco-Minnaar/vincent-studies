using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;

namespace Arrays;

public static class Solution
{
    public static int[] Sort(int[] input)
    {
        // Enter your solution here
        bool KeepIterating = true;
        while (KeepIterating)
        {
            KeepIterating = false;
            for (int i = 0; i < input.Length-1; i++)
            {
                int x = input[i];
                int y = input[i + 1];
                if (x > y )
                {
                    
                    input[i] = y;
                    input[i + 1] = x;
                    KeepIterating = true;

                    for (int j = 0; j < input.Length; j++)
                    {
                    
                    }
                }                    
            }
        } return input;
    }
    

    

    public static int Max(int[] input)
    {
        // Enter your solution here
        var highest = int.MinValue;
        for (int i = 0; i < input.Length; i++)
        {
            var currentValue = input[i];
            if (currentValue > highest)
            {
                highest = currentValue;
            }
            
        }
        return highest;
    }

    public static int Min(int[] input)
    {
        // Enter your solution here
        var lowest = int.MaxValue;
        for (int i = 0; i < input.Length; i++)
        {
            var currentValue = input[i];
            if (currentValue < lowest)
            {
                lowest = currentValue;
            }
            
        }
        return lowest;

        
    }

    public static int Sum(int[] numbers)
    {
        // Enter your solution here
        var sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            var currentValue = numbers[i];
            sum=currentValue+sum;
            
        }
        return sum;


       
    }

    public static double Average(int[] numbers)
    {
        // Enter your solution here
       var average = (double)Sum(numbers) / (double)numbers.Length;

        return average;
    }
}

