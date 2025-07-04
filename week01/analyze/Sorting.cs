using System;

namespace Week01
{
    public static class Sorting
    {
        /// <summary>
        /// Sorts an integer array using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="data">The array to sort</param>
        public static void SortArray(int[] data)
        {
            for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--)
            {
                for (var swapPos = 0; swapPos < sortPos; ++swapPos)
                {
                    if (data[swapPos] > data[swapPos + 1])
                    {
                        (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };

            Sorting.SortArray(numbers);

            Console.WriteLine("int[]{{{0}}}", string.Join(", ", numbers));
            // Expected output: int[]{1, 2, 3, 4, 6, 8, 9}
        }
    }
}
