using System.Diagnostics.Contracts;
using System.Drawing;

namespace TaskNumber1;

public class Finder
{
    public static bool PathFinder(string maze)
    {
        string[] rows = maze.Split('\n');
        var position = new Point(0, 0);
        var limits = new Point(rows[0].Length - 1, rows.Length - 1);
        var visitedPath = new List<Point> { new Point(-1, -1) };
        
        while (InsideLimits(position, limits))
        {
            if (CanGoRight(position, rows, limits))
            {
                position.X++;
                visitedPath.Add(position);
                continue;
            }
            
            if (CanGoDown(position, rows, limits))
            {
                position.Y++;
                visitedPath.Add(position);
                continue;
            }

            BlockThisPath(position, rows);
            position = GoBack(visitedPath);
        }
        return position == limits;
    }

    private static void BlockThisPath(Point position, string[] rows)
    {
        rows[position.Y] = rows[position.Y].Remove(position.X, 1).Insert(position.X, "W");
    }

    private static Point GoBack(List<Point> visitedPath)
    {
        var previousPosition = visitedPath.Last();
        visitedPath.RemoveAt(visitedPath.Count - 1);
        return previousPosition;
    }

    private static bool InsideLimits(Point position, Point limits)
    {
        return (position.X >= 0 && position.X < limits.X) || (position.Y >= 0 && position.Y < limits.Y);
    }

    private static bool CanGoRight(Point position, string[] rows, Point limits)
    {
        return position.X < limits.X && rows[position.Y][position.X + 1] == '.';
    }

    private static bool CanGoDown(Point position, string[] rows, Point limits)
    {
        return position.Y < limits.Y && rows[position.Y + 1][position.X] == '.';
    }
}
