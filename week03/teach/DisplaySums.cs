using System;
using System.Collections.Generic;

public static class DisplaySums {
    public static void Run() {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        DisplaySumPairs(numbers);
    }

    /// <summary>
    /// Find and display all unique pairs of numbers that sum to 10.
    /// </summary>
    /// <param name="numbers">A list of integers with no duplicates</param>
    private static void DisplaySumPairs(List<int> numbers) {
        var seen = new HashSet<int>();

        foreach (var num in numbers) {
            int complement = 10 - num;
            if (seen.Contains(complement)) {
                Console.WriteLine($"{complement} + {num} = 10");
            }
            seen.Add(num);
        }
    }
}
