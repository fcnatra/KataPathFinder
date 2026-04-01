namespace TaskNumber5;

public static class MazeParser
{
    public static char[][] Parse(string maze)
    {
        return maze.Split('\n').Select(row => row.ToCharArray()).ToArray();
    }
}
