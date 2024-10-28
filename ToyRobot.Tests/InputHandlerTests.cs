using Shouldly;

namespace ToyRobot.Tests;

public class InputHandlerTests
{
    [Theory]
    [InlineData("", false)]
    [InlineData("\r\n", false)]
    [InlineData("PLACE 0,0,NORTH", true)]
    [InlineData("REPORT", true)]
    [InlineData("MOVE", true)]
    [InlineData("LEFT", true)]
    [InlineData("RIGHT", true)]
    [InlineData("INVALID", false)]
    [InlineData("REPORTS", false)]
    [InlineData("PLACE 0,0,NORTHEAST", false)]
    [InlineData("PLACE 0,f,NORTH", false)]
    [InlineData("PLACE 0 , f, NORTH", false)]
    public void TestProcess(string input, bool expected)
    {
        var sut = new InputHandler();

        sut.Process(input).ShouldBe(expected);
    }
}