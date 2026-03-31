using System.Drawing;
using TaskNumber4;

namespace PathFinderTests;

public class TaskNumber4Tests
{
    [Theory]
    [InlineData("r5L2l4", 4, 3)]
    [InlineData("r5L2l4", 0, 0)]
    [InlineData("10r5r0", -10, 5)]
    [InlineData("10r5r0", 0, 0)]
    [InlineData("10", 0, 10)]
    [InlineData("R10", 10, 0)]
    [InlineData("L10", -10, 0)]
    [InlineData("r10", 10, 10)]
    [InlineData("l10", -10, 10)]
    [InlineData("RRRR5", 0, 5)]
    [InlineData("10R10L10", 10, 20)] // North 10 → (0,10), turn R → East, East 10 → (10,10), turn L → North, North 10 → (10,20)
    [InlineData("RR3", 0, -3)] // RR = South, move 3 → (0,-3)
    public void GivenCommands_ResultingCoordinates_AreTheExpected(string commands, int expectedX, int expectedY)
    {
        Assert.Equal(new Point(expectedX, expectedY), Finder.iAmHere(commands));
    }
}
