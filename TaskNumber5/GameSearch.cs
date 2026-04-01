namespace TaskNumber5;

public static class GameSearch
{
    private static readonly (int dRow, int dCol)[] Directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
    private const char Wall = 'W';

    public static bool CanEscape(char[][] cells)
    {
        int last = cells.Length - 1;
        var start = (Row: 0, Col: 0);
        var exit = (Row: last, Col: last);

        if (start == exit) return true;

        var distances = BuildDistances(cells);
        var initial = new GameState(start, exit);
        var queue = new Queue<GameState>();
        var visited = new HashSet<GameState>();

        queue.Enqueue(initial);
        visited.Add(initial);

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();

            foreach (var next in GetNextStates(state, cells, distances, exit))
            {
                if (next.Player == exit) return true;
                if (visited.Contains(next)) continue;
                visited.Add(next);
                queue.Enqueue(next);
            }
        }

        return false;
    }

    private static IEnumerable<GameState> GetNextStates(
        GameState state, char[][] cells, Func<(int Row, int Col), int[]> distances, (int Row, int Col) exit)
    {
        foreach (var (dRow, dCol) in Directions)
        {
            var newPlayer = (Row: state.Player.Row + dRow, Col: state.Player.Col + dCol);

            if (!IsOpen(cells, newPlayer)) continue;
            if (newPlayer == state.Monster) continue;

            var newMonster = MoveMonsterToward(state.Monster, newPlayer, cells, distances);

            if (newPlayer == newMonster) continue;

            yield return new GameState(newPlayer, newMonster);
        }
    }

    private static (int Row, int Col) MoveMonsterToward(
        (int Row, int Col) monster, (int Row, int Col) target,
        char[][] cells, Func<(int Row, int Col), int[]> distances)
    {
        var best = monster;
        int bestDist = distances(target)[monster.Row * cells.Length + monster.Col];

        foreach (var (dRow, dCol) in Directions)
        {
            var candidate = (Row: monster.Row + dRow, Col: monster.Col + dCol);

            if (!IsOpen(cells, candidate)) continue;

            int dist = distances(target)[candidate.Row * cells.Length + candidate.Col];

            if (dist < bestDist)
            {
                bestDist = dist;
                best = candidate;
            }
        }

        return best;
    }

    // Use lazy evaluation with a cache to avoid O(n^4) upfront computation
    private static Func<(int Row, int Col), int[]> BuildDistances(char[][] cells)
    {
        int size = cells.Length;
        var cache = new Dictionary<(int Row, int Col), int[]>();

        return source =>
        {
            if (!cache.TryGetValue(source, out var dist))
            {
                dist = BfsFrom(source, cells);
                cache[source] = dist;
            }
            return dist;
        };
    }

    private static int GetIndex(int row, int col, int size)
    {
        // Linearizes 2D coordinates into a flat array index
        return row * size + col;
    }

    private static int[] BfsFrom((int Row, int Col) source, char[][] cells)
    {
        int size = cells.Length;
        var dist = new int[size * size];
        Array.Fill(dist, int.MaxValue);
        dist[GetIndex(source.Row, source.Col, size)] = 0;

        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            int current = dist[GetIndex(row, col, size)];

            foreach (var (dRow, dCol) in Directions)
            {
                var next = (Row: row + dRow, Col: col + dCol);
                if (!IsOpen(cells, next)) continue;
                int idx = GetIndex(next.Row, next.Col, size);
                if (dist[idx] != int.MaxValue) continue;
                dist[idx] = current + 1;
                queue.Enqueue(next);
            }
        }

        return dist;
    }

    private static bool IsOpen(char[][] cells, (int Row, int Col) pos)
    {
        if (pos.Row < 0 || pos.Row >= cells.Length) return false;
        if (pos.Col < 0 || pos.Col >= cells[pos.Row].Length) return false;
        return cells[pos.Row][pos.Col] != Wall;
    }
}
