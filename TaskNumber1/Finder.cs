using System.Drawing;

namespace TaskNumber1;

public class Finder
{
    public static bool PathFinder(string maze)
    {
        Point position = new Point(0, 0);
        string[] rows = maze.Split('\n');
        Point limits = new Point(rows[0].Length - 1, rows.Length - 1);

        while (InsideLimits(position, limits))
        {
            if (CanGoRight(position, rows, limits)) position.X++;
            else if (CanGoDown(position, rows, limits)) position.Y++;
            else return false;
        }
        return true;
    }

    private static bool CanGoDown(Point position, string[] rows, Point limits)
    {
        return position.Y < limits.Y && rows[position.X][position.Y + 1] == '.';
    }

    private static bool CanGoRight(Point position, string[] rows, Point limits)
    {
        return position.X < limits.X && rows[position.X + 1][position.Y] == '.';
    }

    private static bool InsideLimits(Point position, Point limits)
    {
        return position.X < limits.X || position.Y < limits.Y;
    }
}
