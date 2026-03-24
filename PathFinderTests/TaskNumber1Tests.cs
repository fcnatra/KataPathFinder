using TaskNumber1;

namespace PathFinderTests;

public class TaskNumber1Tests
{
    [Fact]
    public void PathFinder_ReturnsTrue_WhenPathExistsInSimpleGrid()
    {
        string area = ".W.\n" +
                      ".W.\n" +
                      "...";

        Assert.True(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsFalse_WhenStartIsBlocked()
    {
        string area = ".W.\n" +
                      ".W.\n" +
                      "W..";

        Assert.False(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenOpenGridHasNoWalls()
    {
        string area = "......\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      "......";

        Assert.True(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsFalse_WhenExitIsIsolatedByWalls()
    {
        string area = "......\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      ".....W\n" +
                      "....W.";

        Assert.False(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPathToExitRequiresToGoBackOnPath()
    {
        string area = "..W...\n" +
                      ".W....\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      "......";

        Assert.True(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPathRequiresGoingNorth()
    {
        string area = ".W...\n" +
                      ".W...\n" +
                      ".W.W.\n" +
                      "...W.\n" +
                      "...W.";

        Assert.True(Finder.PathFinder(area));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPathRequiresGoingWest()
    {
        string area = "..W\n" +
                      "W.W\n" +
                      "..W\n" +
                      ".WW\n" +
                      "...";

        Assert.True(Finder.PathFinder(area));
    }
}
