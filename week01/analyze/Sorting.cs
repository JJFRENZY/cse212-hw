using System;

public static class Sorting
{
    public static void Run()
    {
        int[] data = { 9, 3, 1, 5, 13, 12 };
        Console.WriteLine("Before sort: " + string.Join(", ", data));
        SortArray(data);
        Console.WriteLine("After sort: " + string.Join(", ", data));
    }

    public static void SortArray(int[] data)
    {
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--)
        {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos)
            {
                if (data[swapPos] > data[swapPos + 1])
                {
                    var temp = data[swapPos];
                    data[swapPos] = data[swapPos + 1];
                    data[swapPos + 1] = temp;
                }
            }
        }
    }
}
