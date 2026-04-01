using System.Drawing;

namespace TaskNumber5;

public class GameSearch
{
    private static readonly (int dRow, int dCol)[] Directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
    private const char Wall = 'W';
    private readonly char[][] _cells;
    private readonly int _size;
    private readonly Dictionary<Point, int[]> _distanceCache;

    public GameSearch(char[][] cells)
    {
        _cells = cells;
        _size = cells.Length;
        _distanceCache = new Dictionary<Point, int[]>();
    }

    public bool CanEscape()
    {
        int last = _size - 1;
        var start = new Point(0, 0);
        var exit = new Point(last, last);

        if (start == exit) return true;

        return Search(new GameState(start, exit), exit);
    }

    private bool Search(GameState initial, Point exit)
    {
        var queue = new Queue<GameState>();
        var visited = new HashSet<GameState>();

        queue.Enqueue(initial);
        visited.Add(initial);

        while (queue.Count > 0)
        {
            var state = queue.Dequeue();

            foreach (var next in GetNextStates(state))
            {
                if (next.Player == exit) return true;
                if (visited.Contains(next)) continue;
                visited.Add(next);
                queue.Enqueue(next);
            }
        }

        return false;
    }

    private IEnumerable<GameState> GetNextStates(GameState state)
    {
        foreach (var (dRow, dCol) in Directions)
        {
            var newPlayer = new Point(state.Player.X + dCol, state.Player.Y + dRow);

            if (!IsValidPlayerMove(newPlayer, state.Monster)) continue;

            var newMonster = MoveMonsterToward(state.Monster, newPlayer);

            if (newPlayer == newMonster) continue;

            yield return new GameState(newPlayer, newMonster);
        }
    }

    private bool IsValidPlayerMove(Point newPlayer, Point monster) =>
        IsOpen(newPlayer) && newPlayer != monster;

    private Point MoveMonsterToward(Point monster, Point target)
    {
        var targetDistances = GetDistancesFrom(target);
        var best = monster;
        int bestDist = targetDistances[GetIndex(monster.Y, monster.X)];

        foreach (var (dRow, dCol) in Directions)
        {
            var candidate = new Point(monster.X + dCol, monster.Y + dRow);

            if (!IsOpen(candidate)) continue;

            int dist = targetDistances[GetIndex(candidate.Y, candidate.X)];

            if (dist < bestDist)
            {
                bestDist = dist;
                best = candidate;
            }
        }

        return best;
    }

    // Uses lazy evaluation with cache to avoid O(n^4) upfront computation.
    private int[] GetDistancesFrom(Point source)
    {
        if (!_distanceCache.TryGetValue(source, out var distances))
        {
            distances = BfsFrom(source);
            _distanceCache[source] = distances;
        }

        return distances;
    }

    private int GetIndex(int row, int col)
    {
        // Linearizes 2D coordinates into a flat array index
        return row * _size + col;
    }

    private int[] BfsFrom(Point source)
    {
        var dist = new int[_size * _size];
        Array.Fill(dist, int.MaxValue);
        dist[GetIndex(source.Y, source.X)] = 0;

        var queue = new Queue<Point>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var currentPoint = queue.Dequeue();
            int current = dist[GetIndex(currentPoint.Y, currentPoint.X)];

            foreach (var (dRow, dCol) in Directions)
            {
                var next = new Point(currentPoint.X + dCol, currentPoint.Y + dRow);
                if (!IsOpen(next)) continue;
                int idx = GetIndex(next.Y, next.X);
                if (dist[idx] != int.MaxValue) continue;
                dist[idx] = current + 1;
                queue.Enqueue(next);
            }
        }

        return dist;
    }

    private bool IsOpen(Point pos)
    {
        if (pos.Y < 0 || pos.Y >= _cells.Length) return false;
        if (pos.X < 0 || pos.X >= _cells[pos.Y].Length) return false;
        return _cells[pos.Y][pos.X] != Wall;
    }
}
