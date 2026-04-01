using TaskNumber5;

namespace PathFinderTests;

public class TaskNumber5Tests
{
    [Fact]
    public void PathFinder_ReturnsTrue_WhenMazeHasSingleCell()
    {
        Assert.True(Finder.PathFinder("."));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPlayerCanOutwit_3x3_WithCenterWall()
    {
        string maze = "...\n" +
                      ".W.\n" +
                      "...";

        Assert.True(Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsFalse_WhenMonsterAlwaysIntercepts_3x3_OpenMaze()
    {
        string maze = "...\n" +
                      "...\n" +
                      "...";

        Assert.False(Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPlayerCanOutwit_5x5_WithCenterWall()
    {
        string maze = ".....\n" +
                      ".....\n" +
                      "..W..\n" +
                      ".....\n" +
                      ".....";

        Assert.True(Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsTrue_WhenPlayerCanOutwit_5x5_WithWallNearExit()
    {
        string maze = ".....\n" +
                      ".....\n" +
                      ".....\n" +
                      "...W.\n" +
                      ".....";

        Assert.True(Finder.PathFinder(maze));
    }

    [Fact]
    public void PathFinder_ReturnsFalse_WhenMonsterCatchesPlayerImmediately_2x2_OpenMaze()
    {
        string maze = "..\n" +
                      "..";

        Assert.False(Finder.PathFinder(maze));
    }
}
