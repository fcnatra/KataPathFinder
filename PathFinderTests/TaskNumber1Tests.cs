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
    public void PathFinder_ReturnsTrue_WhenOpenGridHasRoute()
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
    public void PathFinder_ReturnsTrue_WhenPathToExitRequiresToGoBack()
    {
        string area = "..W...\n" +
                      ".W....\n" +
                      "......\n" +
                      "......\n" +
                      "......\n" +
                      "......";

        Assert.True(Finder.PathFinder(area));
    }
}
