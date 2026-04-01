namespace TaskNumber2;

public static class BfsTraverser
{
	private const char OpenCell = '.';

	public static int FindShortestPath(char[][] cells)
	{
		int size = cells.Length;
		int lastIndex = size - 1;

		var distances = InitDistances(size);

		var queue = new Queue<(int Col, int Row)>();
		queue.Enqueue((Col: 0, Row: 0));
		distances[0, 0] = 0;

		while (queue.Count > 0)
		{
			var (col, row) = queue.Dequeue();

			if (col == lastIndex && row == lastIndex)
				return distances[row, col];

			var nextDistance = distances[row, col] + 1;
			TryVisit(queue, cells, distances, col + 1, row, nextDistance);
			TryVisit(queue, cells, distances, col - 1, row, nextDistance);
			TryVisit(queue, cells, distances, col, row + 1, nextDistance);
			TryVisit(queue, cells, distances, col, row - 1, nextDistance);
		}

		return -1;
	}

	private static int[,] InitDistances(int size)
	{
		var distances = new int[size, size];
		for (int row = 0; row < size; row++)
			for (int col = 0; col < size; col++)
				distances[row, col] = -1;
		return distances;
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
