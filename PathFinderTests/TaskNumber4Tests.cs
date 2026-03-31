using TaskNumber4;

namespace PathFinderTests;

public class TaskNumber4Tests
{
    [Fact]
    public void PathFinder_ReturnsOrigin_WhenCommandsAreEmpty()
    {
        Assert.Equal((0, 0), Finder.PathFinder(""));
    }

    [Fact]
    public void PathFinder_MovesNorth_WhenOnlyStepsGiven()
    {
        Assert.Equal((0, 10), Finder.PathFinder("10"));
    }

    [Fact]
    public void PathFinder_MovesEast_AfterTurningRight90()
    {
        Assert.Equal((10, 0), Finder.PathFinder("R10"));
    }

    [Fact]
    public void PathFinder_MovesWest_AfterTurningLeft90()
    {
        Assert.Equal((-10, 0), Finder.PathFinder("L10"));
    }

    [Fact]
    public void PathFinder_MovesNorthEast_AfterTurningRight45()
    {
        Assert.Equal((10, 10), Finder.PathFinder("r10"));
    }

    [Fact]
    public void PathFinder_MovesNorthWest_AfterTurningLeft45()
    {
        Assert.Equal((-10, 10), Finder.PathFinder("l10"));
    }

    [Fact]
    public void PathFinder_ReturnsToNorth_AfterFourRightTurns()
    {
        Assert.Equal((0, 5), Finder.PathFinder("RRRR5"));
    }

    [Fact]
    public void PathFinder_CombinesMultipleMovesAndTurns()
    {
        // North 10 → (0,10), turn R → East, East 10 → (10,10), turn L → North, North 10 → (10,20)
        Assert.Equal((10, 20), Finder.PathFinder("10R10L10"));
    }

    [Fact]
    public void PathFinder_HandlesMixedTurnsBeforeMoving()
    {
        // RR = South, move 3 → (0,-3)
        Assert.Equal((0, -3), Finder.PathFinder("RR3"));
    }
}
