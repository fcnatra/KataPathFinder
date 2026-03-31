namespace TaskNumber2;

public class Finder
{
	private const char OpenCell = '.';

	public static int PathFinder(string maze)
	{
		var rows = maze.Split('\n');
		var cells = rows.Select(row => row.ToCharArray()).ToArray();

		int size = cells.Length;
		int exit = size - 1;

		var distances = new int[size, size];
		for (int row = 0; row < size; row++)
		{
			for (int col = 0; col < size; col++)
			{
				distances[row, col] = -1;
			}
		}

		var queue = new Queue<(int Col, int Row)>();
		queue.Enqueue((Col: 0, Row: 0));
		distances[0, 0] = 0;

		while (queue.Count > 0)
		{
			var (col, row) = queue.Dequeue();

			if (col == exit && row == exit)
			{
				return distances[row, col];
			}

			TryVisit(queue, cells, distances, col + 1, row, distances[row, col] + 1);
			TryVisit(queue, cells, distances, col - 1, row, distances[row, col] + 1);
			TryVisit(queue, cells, distances, col, row + 1, distances[row, col] + 1);
			TryVisit(queue, cells, distances, col, row - 1, distances[row, col] + 1);
		}

		return -1;
	}

	private static void TryVisit(
		Queue<(int Col, int Row)> queue,
		char[][] cells,
		int[,] distances,
		int col,
		int row,
		int nextDistance)
	{
		if (row < 0 || row >= cells.Length) return;
		if (col < 0 || col >= cells[row].Length) return;
		if (cells[row][col] != OpenCell) return;
		if (distances[row, col] != -1) return;

		distances[row, col] = nextDistance;
		queue.Enqueue((Col: col, Row: row));
	}
}
