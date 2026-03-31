namespace TaskNumber1;

public class Finder
{
    public static bool PathFinder(string maze)
    {
        var grid = new MazeGrid(maze);
        var walk = new WalkState(grid.Start);

        while (!walk.HasReached(grid.Exit) && !walk.IsLost)
        {
            if (TryStep(ref walk, grid, dx: 1, dy: 0)) continue;
            if (TryStep(ref walk, grid, dx: 0, dy: 1)) continue;
            if (TryStep(ref walk, grid, dx: 0, dy: -1)) continue;
            if (TryStep(ref walk, grid, dx: -1, dy: 0)) continue;

            grid.MarkDeadEnd(walk.Position);
            walk.Backtrack();
        }

        return walk.Position == grid.Exit;
    }

    private static bool TryStep(ref WalkState walk, MazeGrid grid, int dx, int dy)
    {
        var candidate = new GridPoint(walk.Position.Col + dx, walk.Position.Row + dy);

        if (!grid.IsOpen(candidate)) return false;
        if (walk.AlreadyVisited(candidate)) return false;

        walk.MoveTo(candidate);
        return true;
    }
}
