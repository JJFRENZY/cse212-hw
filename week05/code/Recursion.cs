using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + ... + n^2
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size'
    /// from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string newLetters = letters.Remove(i, 1);
            PermutationsChoose(results, newLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb stairs with memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Given a pattern with * wildcards, return all binary strings
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int starIndex = pattern.IndexOf('*');
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string prefix = pattern[..starIndex];
        string suffix = pattern[(starIndex + 1)..];
        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths from (0,0) to End into results.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));
            SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));
            SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));
            SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));
        }
    }
}

