using Shouldly;

namespace ToyRobot.Tests;

public class RobotTests
{
    [Fact]
    public void NewRobotIsNotPlaced()
    {
        new Robot().IsPlaced.ShouldBeFalse();
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(5, 5)]
    public void RobotCannotBePlacedOffTable(int x, int y)
    {
        var robot = new Robot();

        robot.Place(x, y);

        robot.IsPlaced.ShouldBeTrue();
        Table.OnTable(robot.Position).ShouldBeTrue();
    }

    [Theory]
    [InlineData(0, 0, Direction.SOUTH)]
    [InlineData(4, 4, Direction.NORTH)]
    [InlineData(0, 0, Direction.WEST)]
    [InlineData(4, 4, Direction.EAST)]
    public void RobotCannotMoveOffTable(int x, int y, Direction f)
    {
        var robot = new Robot();

        robot.Place(x, y);
        robot.Direction = f;

        robot.MoveForward();
        robot.Position.X.ShouldBe(x);
        robot.Position.Y.ShouldBe(y);
        Table.OnTable(robot.Position).ShouldBeTrue();
    }
}