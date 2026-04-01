namespace TaskNumber5;

public class Finder
{
    public static bool PathFinder(string maze)
    {
        var cells = MazeParser.Parse(maze);
        return GameSearch.CanEscape(cells);
    }
}
