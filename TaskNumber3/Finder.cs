namespace TaskNumber3;

public class Finder
{
	public static int PathFinder(string maze)
	{
		if (string.IsNullOrEmpty(maze))
			throw new ArgumentException("Maze cannot be null or empty.", nameof(maze));

		var grid = MazeParser.Parse(maze);
		return DijkstraTraverser.FindMinimumClimb(grid);
	}
}
