namespace TaskNumber1;

internal class WalkState
{
    private static readonly GridPoint Sentinel = new(Col: -1, Row: -1);

    private readonly List<GridPoint> _history;
    private readonly HashSet<GridPoint> _visited;

    public GridPoint Position => _history[_history.Count - 1];

    public bool IsLost => Position == Sentinel;

    public WalkState(GridPoint start)
    {
        _history = new List<GridPoint> { Sentinel, start };
        _visited = new HashSet<GridPoint> { Sentinel, start };
    }

    public bool HasReached(GridPoint destination) => Position == destination;

    public bool AlreadyVisited(GridPoint point) => _visited.Contains(point);

    public void MoveTo(GridPoint point)
    {
        _history.Add(point);
        _visited.Add(point);
    }

    public void Backtrack()
    {
        _visited.Remove(_history[_history.Count - 1]);
        _history.RemoveAt(_history.Count - 1);
        if (_history.Count == 0) _history.Add(Sentinel);
    }
}
