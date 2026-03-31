namespace TaskNumber3;

public static class DijkstraTraverser
{
	private static readonly (int DRow, int DCol)[] Directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];

	public static int FindMinimumClimb(int[][] grid)
	{
		int size = grid.Length;
		int lastIndex = size - 1;

		var costs = InitCosts(size);
		costs[0, 0] = 0;

		var queue = new PriorityQueue<(int Row, int Col), int>();
		queue.Enqueue((0, 0), 0);

		while (queue.Count > 0)
		{
			var (row, col) = queue.Dequeue();
			int currentCost = costs[row, col];

			if (row == lastIndex && col == lastIndex)
				return currentCost;

			foreach (var (dRow, dCol) in Directions)
			{
				int nRow = row + dRow;
				int nCol = col + dCol;

				if (nRow < 0 || nRow >= size || nCol < 0 || nCol >= size) continue;

				int climbCost = Math.Abs(grid[row][col] - grid[nRow][nCol]);
				int newCost = currentCost + climbCost;

				if (newCost < costs[nRow, nCol])
				{
					costs[nRow, nCol] = newCost;
					queue.Enqueue((nRow, nCol), newCost);
				}
			}
		}

		return -1;
	}

	private static int[,] InitCosts(int size)
	{
		var costs = new int[size, size];
		for (int row = 0; row < size; row++)
			for (int col = 0; col < size; col++)
				costs[row, col] = int.MaxValue;
		return costs;
	}
}
