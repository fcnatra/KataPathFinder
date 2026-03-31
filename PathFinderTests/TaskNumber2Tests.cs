using TaskNumber2;

namespace PathFinderTests;

public class TaskNumber2Tests
{
    [Fact]
    public void PathFinder_ReturnsZero_WhenMazeHasSingleCell()
    {
        Assert.Equal(0, Finder.PathFinder("."));
    }

    [Fact]
    public void PathFinder_ReturnsFour_WhenOpenThreeByThreeMaze()
    {
        string maze = "...\n" +
                      "...\n" +
                      "...";

        Assert.Equal(4, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsFour_WhenPathExistsInSimpleGrid()
    {
        string maze = ".W.\n" +
                      ".W.\n" +
                      "...";

        Assert.Equal(4, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsMinusOne_WhenExitIsUnreachable()
    {
        string maze = ".W.\n" +
                      ".W.\n" +
                      "W..";

        Assert.Equal(-1, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsTen_WhenDetourStillKeepsShortestDistance()
    {
        string maze = "..W...\n" +
                      ".W....\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      "......";

        Assert.Equal(10, Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsTen_WhenThereIsAShortcut()
    {
        string maze = "......\n" +
                      ".W.WW.\n" +
                      ".W....\n" +
                      "....WW\n" +
                      "......\n" +
                      "......";

        Assert.Equal(10, Finder.PathFinder(maze));
    }
}
