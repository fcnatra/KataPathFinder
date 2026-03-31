using TaskNumber3;

namespace PathFinderTests;

public class TaskNumber3Tests
{
    [Fact]
    public void PathFinder_ReturnsZero_WhenMazeHasSingleCell()
    {
        Assert.Equal(0, Finder.PathFinder("0"));
    }

    [Fact]
    public void PathFinder_ReturnsZero_WhenTerrainIsFlat()
    {
        string maze = "000\n" +
                      "000\n" +
                      "000";

        Assert.Equal(0, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsTwo_WhenPathMustCrossARidge()
    {
        string maze = "010\n" +
                      "010\n" +
                      "010";

        Assert.Equal(2, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsFourteen_WhenStartAndEndAreHighPeaks()
    {
        string maze = "700\n" +
                      "000\n" +
                      "007";

        Assert.Equal(14, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsFortyTwo_WhenTerrainAlternatesHighAndLow()
    {
        string maze = "0707\n" +
                      "7070\n" +
                      "0707\n" +
                      "7070";

        Assert.Equal(42, Finder.PathFinder(maze));
    }
}
