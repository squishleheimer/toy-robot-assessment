namespace ToyRobot
{
  public class Position
  {
    public static Position NoPlace => new Position { X = -1, Y = -1 };

    public int X { get; set; } = -1;

    public int Y { get; set; } = -1;
  }

  public enum Direction
  {
    NORTH = 0,
    EAST,
    SOUTH,
    WEST
  }

  public static class Table
  {
    public const int Size = 5;

    public static int NumberOfDirections => Enum.GetNames<Direction>().Count();

    public static bool OnTable(this Position position) =>
      position.X >= 0 && position.X < Size &&
      position.Y >= 0 && position.Y < Size;

    private static Direction Turn(this Direction direction, bool left) {
      int d = (int)direction+(left ? -1 : 1);
      return (Direction)(d < 0 ? NumberOfDirections - 1 : (d >= NumberOfDirections ? 0 : d));
    }

    public static Direction TurnLeft(this Direction direction) => direction.Turn(true);
    public static Direction TurnRight(this Direction direction) => direction.Turn(false);
  }
}