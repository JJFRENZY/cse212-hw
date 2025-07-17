using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip the header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
                players[playerId] += points;
            else
                players[playerId] = points;
        }

        // Sort players by total points in descending order and take top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .ToList();

        Console.WriteLine("Top 10 Players by Career Points:");
        Console.WriteLine("Rank\tPlayer ID\tTotal Points");

        for (int i = 0; i < topPlayers.Count; i++)
        {
            var (playerId, totalPoints) = topPlayers[i];
            Console.WriteLine($"{i + 1}\t{playerId}\t{totalPoints}");
        }
    }
}
