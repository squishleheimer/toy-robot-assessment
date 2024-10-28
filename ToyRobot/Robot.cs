namespace ToyRobot
{
  public class Robot
  {
    public bool IsPlaced => Position.X > -1 && Position.Y > -1;

    public Direction Direction { get; set; } = Direction.NORTH;

    public Position Position { get; private set; } = Position.NoPlace;

    public void Place(int x, int y)
    {
      Position.X = Math.Clamp(x, 0, Table.Size - 1);
      Position.Y = Math.Clamp(y, 0, Table.Size - 1);
    }

    public void MoveForward()
    {
      if (IsPlaced)
      {
        switch (Direction)
        {
          case Direction.NORTH:
            Place(Position.X, Position.Y + 1);
            break;
          case Direction.SOUTH:
            Place(Position.X, Position.Y - 1);
            break;
          case Direction.EAST:
            Place(Position.X + 1, Position.Y);
            break;
          case Direction.WEST:
            Place(Position.X - 1, Position.Y);
            break;
        }
      }
    }

    public void TurnLeft()
    {
      if (IsPlaced)
      {
        Direction = Direction.TurnLeft();
      }
    }

    public void TurnRight()
    {
      if (IsPlaced)
      {
        Direction = Direction.TurnRight();
      }
    }

    public string Report => $"{Position.X},{Position.Y},{Direction}";
  }
}
