using Shouldly;

namespace ToyRobot.Tests;

public class TableTests
{
    [Theory]
    [InlineData(Direction.NORTH, Direction.WEST)]
    [InlineData(Direction.WEST, Direction.SOUTH)]
    [InlineData(Direction.SOUTH, Direction.EAST)]
    [InlineData(Direction.EAST, Direction.NORTH)]
    public void TestLeft(Direction actual, Direction expected)
    {
        actual.TurnLeft().ShouldBe(expected);
    }

    [Theory]
    [InlineData(Direction.NORTH, Direction.EAST)]
    [InlineData(Direction.EAST, Direction.SOUTH)]
    [InlineData(Direction.SOUTH, Direction.WEST)]
    [InlineData(Direction.WEST, Direction.NORTH)]
    public void TestRight(Direction actual, Direction expected)
    {
        actual.TurnRight().ShouldBe(expected);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(1, 1, true)]
    [InlineData(2, 2, true)]
    [InlineData(3, 3, true)]
    [InlineData(4, 4, true)]
    [InlineData(Table.Size, Table.Size, false)]
    [InlineData(-1, -1, false)]
    public void PositionRelativeToTableAsExpected(int x, int y, bool expected)
    {
        Table.OnTable(new Position { X = x, Y = y }).ShouldBe(expected);
    }
}