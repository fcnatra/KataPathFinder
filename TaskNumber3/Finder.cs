namespace TaskNumber3;

public class Finder
{
	public static int PathFinder(string maze)
	{
		var grid = MazeParser.Parse(maze);
		return DijkstraTraverser.FindMinimumClimb(grid);
	}
}
