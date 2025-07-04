using System;

public static class Search
{
    // Linear search on sorted list with early exit
    public static int SearchSorted1(int[] sortedArray, int target, out int count)
    {
        count = 0;
        for (int i = 0; i < sortedArray.Length; i++)
        {
            count++;
            if (sortedArray[i] == target)
                return i;
            if (sortedArray[i] > target) // Early stop since sorted
                break;
        }
        return -1; // not found
    }

    // Binary search on sorted list
    public static int SearchSorted2(int[] sortedArray, int target, out int count)
    {
        int low = 0;
        int high = sortedArray.Length - 1;
        count = 0;

        while (low <= high)
        {
            count++;
            int mid = (low + high) / 2;
            if (sortedArray[mid] == target)
                return mid;
            else if (sortedArray[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1; // not found
    }

    // Run test with timing and iteration count
    public static void Run()
    {
        int n = 10000;
        int[] data = new int[n];
        for (int i = 0; i < n; i++)
            data[i] = i * 2; // Even numbers, sorted

        int target = -1; // Target not in array to simulate worst case

        // Run SearchSorted1 100 times
        int totalCount1 = 0;
        var watch1 = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 100; i++)
        {
            SearchSorted1(data, target, out int count1);
            totalCount1 = count1; // count same each run
        }
        watch1.Stop();

        // Run SearchSorted2 100 times
        int totalCount2 = 0;
        var watch2 = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 100; i++)
        {
            SearchSorted2(data, target, out int count2);
            totalCount2 = count2; // count same each run
        }
        watch2.Stop();

        Console.WriteLine($"n = {n}");
        Console.WriteLine($"SearchSorted1 count (iterations): {totalCount1}");
        Console.WriteLine($"SearchSorted1 avg time (ms): {watch1.ElapsedMilliseconds / 100.0}");
        Console.WriteLine($"SearchSorted2 count (iterations): {totalCount2}");
        Console.WriteLine($"SearchSorted2 avg time (ms): {watch2.ElapsedMilliseconds / 100.0}");
    }
}
