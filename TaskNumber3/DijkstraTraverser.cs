namespace TaskNumber3;

public static class DijkstraTraverser
{
	private static readonly (int DRow, int DCol)[] Directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];

	public static int FindMinimumClimb(int[][] grid)
	{
		ValidateGrid(grid);

		int rowCount = grid.Length;
		int colCount = grid[0].Length;
		int lastRow = rowCount - 1;
		int lastCol = colCount - 1;

		var costs = InitCosts(rowCount, colCount);
		costs[0, 0] = 0;

		var queue = new PriorityQueue<(int Row, int Col), int>();
		queue.Enqueue((0, 0), 0);

		while (queue.Count > 0)
		{
			queue.TryDequeue(out var currentPoint, out int queuedCost);
			var (row, col) = currentPoint;
			int currentCost = costs[row, col];

			if (queuedCost > currentCost)
				continue;

			if (row == lastRow && col == lastCol)
				return currentCost;

			foreach (var (dRow, dCol) in Directions)
			{
				int nRow = row + dRow;
				int nCol = col + dCol;

				if (!IsInsideLimits(nRow, nCol, rowCount, colCount))
					continue;

				TryRelaxNeighbor(grid, costs, queue, row, col, nRow, nCol, currentCost);
			}
		}

		return -1;
	}

	private static int[,] InitCosts(int rowCount, int colCount)
	{
		var costs = new int[rowCount, colCount];
		for (int row = 0; row < rowCount; row++)
			for (int col = 0; col < colCount; col++)
				costs[row, col] = int.MaxValue;
		return costs;
	}

	private static bool IsInsideLimits(int row, int col, int rowCount, int colCount)
	{
		return row >= 0 && row < rowCount && col >= 0 && col < colCount;
	}

	private static void TryRelaxNeighbor(
		int[][] grid,
		int[,] costs,
		PriorityQueue<(int Row, int Col), int> queue,
		int row,
		int col,
		int nRow,
		int nCol,
		int currentCost)
	{
		int climbCost = Math.Abs(grid[row][col] - grid[nRow][nCol]);
		int newCost = currentCost + climbCost;

		if (newCost >= costs[nRow, nCol])
			return;

		costs[nRow, nCol] = newCost;
		queue.Enqueue((nRow, nCol), newCost);
	}

	private static void ValidateGrid(int[][] grid)
	{
		if (grid is null || grid.Length == 0 || grid[0].Length == 0)
			throw new ArgumentException("Grid cannot be null or empty.", nameof(grid));

		int expectedLength = grid.Length;
		for (int row = 0; row < grid.Length; row++)
		{
			if (grid[row] is null || grid[row].Length != expectedLength)
				throw new ArgumentException("Grid must be a non-empty square matrix.", nameof(grid));
		}
	}
}
