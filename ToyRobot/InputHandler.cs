using System.Text.RegularExpressions;

namespace ToyRobot {

  /// <summary>
  /// Handles textual input and only accepts the following commands:
  /// PLACE <args>
  /// MOVE
  /// LEFT
  /// RIGHT
  /// REPORT
  /// <args> must be of the pattern: <int>,<int>,<direction>
  /// <direction> must be one of: NORTH, EAST, SOUTH or WEST
  /// </summary>
  public class InputHandler {

      /// <summary>
      /// Regex pattern that is used to validate and capture arguments for PLACE command.
      /// </summary>
      public static readonly Regex ValidPlace = 
        new Regex(@"(?:(?<x>[\d]+),(?<y>[\d]+),(?<f>NORTH|SOUTH|EAST|WEST)\b)", RegexOptions.Compiled);

    /// <summary>
    /// Arguments necessary for handling a PLACE command.
    /// </summary>
    public class PlaceEventArgs : EventArgs
    {
      public Position Position { get; }
      public Direction Direction { get; }
      public PlaceEventArgs(
        Position position,
        Direction direction) {
        Position = position;
        Direction = direction;
      }
    }

    public event EventHandler<PlaceEventArgs>? Place;
    public event EventHandler<EventArgs>? Move;
    public event EventHandler<EventArgs>? Left;
    public event EventHandler<EventArgs>? Right;
    public event EventHandler<EventArgs>? Report;

    /// <summary>
    /// Handles the textual input and triggers actions to perform based on input arguments.
    /// </summary>
    /// <param name="input">The input; typically from a human user.</param>
    /// <returns>true if the input was valid and the command was processed; false otherwise.</returns>
    public bool Process(string input) {

      if (String.IsNullOrWhiteSpace(input))
      {
        return false;
      }

      var split = Regex
        .Split(input.Trim(), @"\s+")
        .Where(_ => !String.IsNullOrWhiteSpace(_))
        .ToArray();

      string cmd = split.First();

      if (!String.IsNullOrWhiteSpace(cmd))
      {
        switch (cmd)
        {
          case "PLACE":
            if (split.Length == 2 &&
              TryParsePlace(
                split.Last(),
                out Position p,
                out Direction f))
            {
              if (p.OnTable())
              {
                Place?.Invoke(this, new PlaceEventArgs(p, f));
                return true;
              }
            }
            return false;
          case "MOVE":
            Move?.Invoke(this, new EventArgs());
            return true;
          case "LEFT":
            Left?.Invoke(this, new EventArgs());
            return true;
          case "RIGHT":
            Right?.Invoke(this, new EventArgs());
            return true;
          case "REPORT":
            Report?.Invoke(this, new EventArgs());
            return true;
          default:
            return false;
        };
      }

      return false;
    }

    /// <summary>
    /// Uses a simple regex with capture groups to validate arguments for the PLACE command.
    /// Sets the out params when input is valid.
    /// </summary>
    /// <param name="input">The arguments for a PLACE command.</param>
    /// <param name="p">out postiion param for use when input deemed valid.</param>
    /// <param name="d">out direction param for use when input deemed valid.</param>
    /// <returns>true if the input is parsed successfully; false otherwise.</returns>
    private bool TryParsePlace(string input, out Position p, out Direction d) {
      p = Position.NoPlace;
      d = Direction.NORTH;
      var placeFilter = ValidPlace.Match(input);
      if (placeFilter.Captures.Any() &&
        int.TryParse(placeFilter.Groups["x"].Value, out int x) &&
        int.TryParse(placeFilter.Groups["y"].Value, out int y) &&
        Enum.TryParse<Direction>(placeFilter.Groups["f"].Value, out d))
      {
        p.X = x;
        p.Y = y;

        return true;
      }

      return false;
    }
  }
}
