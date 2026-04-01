namespace TaskNumber3;

public static class MazeParser
{
	public static int[][] Parse(string maze)
	{
		return maze.Split('\n')
			.Select(row => row.Select(c => c - '0').ToArray())
			.ToArray();
	}
}
