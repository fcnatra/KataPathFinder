namespace TaskNumber2;

public class Finder
{
	public static int PathFinder(string maze)
	{
		var cells = MazeParser.Parse(maze);
		return BfsTraverser.FindShortestPath(cells);
	}
}
