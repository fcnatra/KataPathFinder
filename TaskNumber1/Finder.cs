namespace TaskNumber1;

public class Finder
{
    private static readonly (int dx, int dy)[] Directions = [(1, 0), (0, 1), (-1, 0), (0, -1)];

    public static bool PathFinder(string maze)
    {
        string[] rows = maze.Split('\n');
        int height = rows.Length;
        int width = rows[0].Length;
        var visited = new bool[width, height];
        var queue = new Queue<(int x, int y)>();

        queue.Enqueue((0, 0));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            if (x == width - 1 && y == height - 1)
                return true;

            foreach (var (dx, dy) in Directions)
            {
                int nx = x + dx, ny = y + dy;
                if (nx >= 0 && nx < width && ny >= 0 && ny < height
                    && rows[ny][nx] == '.' && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }
        }
        return false;
    }
}
