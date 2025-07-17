using System;
using System.Collections.Generic;
using System.IO;

public class SetsAndMaps
{
    // 1. FindPairs: Find symmetric pairs in O(n) using sets
    public static List<string> FindPairs(List<string> words)
    {
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> added = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) // Skip words like "aa"
                continue;

            string reversed = new string(new char[] { word[1], word[0] });

            if (seen.Contains(reversed) && !added.Contains(word) && !added.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                added.Add(word);
                added.Add(reversed);
            }
            else
            {
                seen.Add(word);
            }
        }
        return result;
    }

    // 2. SummarizeDegrees: Reads a CSV file and counts degrees from column 4 (index 3)
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degreeCounts = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length > 3)
            {
                string degree = fields[3].Trim();

                if (!string.IsNullOrEmpty(degree))
                {
                    if (!degreeCounts.ContainsKey(degree))
                        degreeCounts[degree] = 0;

                    degreeCounts[degree]++;
                }
            }
        }

        return degreeCounts;
    }

    // 3. IsAnagram: Use dictionary to determine if two words are anagrams (ignore spaces and case)
    public static bool IsAnagram(string word1, string word2)
    {
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        if (clean1.Length != clean2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in clean1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (char c in clean2)
        {
            if (!counts.ContainsKey(c) || counts[c] == 0)
                return false;
            counts[c]--;
        }

        return true;
    }
}
