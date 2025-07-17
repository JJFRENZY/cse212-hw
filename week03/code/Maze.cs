using System;
using System.Collections.Generic;

public class Maze
{
    // Dictionary key: (x,y) coordinate
    // Value: bool array of movements allowed {left, right, up, down}
    private Dictionary<(int, int), bool[]> maze;

    // Current position
    public int X { get; private set; } = 1;
    public int Y { get; private set; } = 1;

    public Maze(Dictionary<(int, int), bool[]> maze)
    {
        this.maze = maze;
    }

    public void MoveLeft()
    {
        if (maze.ContainsKey((X, Y)) && maze[(X, Y)][0])
        {
            X--;
        }
        else
        {
            throw new InvalidOperationException("Cannot move left from current position.");
        }
    }

    public void MoveRight()
    {
        if (maze.ContainsKey((X, Y)) && maze[(X, Y)][1])
        {
            X++;
        }
        else
        {
            throw new InvalidOperationException("Cannot move right from current position.");
        }
    }

    public void MoveUp()
    {
        if (maze.ContainsKey((X, Y)) && maze[(X, Y)][2])
        {
            Y--;
        }
        else
        {
            throw new InvalidOperationException("Cannot move up from current position.");
        }
    }

    public void MoveDown()
    {
        if (maze.ContainsKey((X, Y)) && maze[(X, Y)][3])
        {
            Y++;
        }
        else
        {
            throw new InvalidOperationException("Cannot move down from current position.");
        }
    }
}
