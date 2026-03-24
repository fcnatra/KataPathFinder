namespace TaskNumber1;

internal class MazeGrid
{
    private const char OpenCell = '.';
    private const char DeadEndCell = 'W';

    private readonly char[][] _cells;

    public GridPoint Start { get; } = new(Col: 0, Row: 0);
    public GridPoint Exit { get; }

    public MazeGrid(string maze)
    {
        var rows = maze.Split('\n');
        _cells = rows.Select(r => r.ToCharArray()).ToArray();
        Exit = new GridPoint(Col: _cells[0].Length - 1, Row: _cells.Length - 1);
    }

    public bool IsOpen(GridPoint point)
    {
        if (point.Col < 0 || point.Col > Exit.Col) return false;
        if (point.Row < 0 || point.Row > Exit.Row) return false;
        return _cells[point.Row][point.Col] == OpenCell;
    }

    public void MarkDeadEnd(GridPoint point)
    {
        _cells[point.Row][point.Col] = DeadEndCell;
    }
}
