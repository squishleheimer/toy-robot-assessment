using ToyRobot;

InputHandler _inputHandler = new InputHandler();

Robot _toy = new Robot();

_inputHandler.Place += (_, args) => {
  _toy.Place(args.Position.X, args.Position.Y);
  _toy.Direction = args.Direction;
};

_inputHandler.Move += (_, args) => {
  _toy.MoveForward();
};

_inputHandler.Left += (_, args) => {
  _toy.TurnLeft();
};

_inputHandler.Right += (_, args) => {
  _toy.TurnRight();
};

_inputHandler.Report += (_, args) => {
  if (_toy.IsPlaced)
  {
    Console.WriteLine(_toy.Report);
  }
};

while (true) {
  // provide feedback to user on all inputs.
  Feedback(success: _inputHandler.Process(
    (Console.ReadLine() ?? string.Empty).Trim()));
};

/// Writes to the console a success or fail text with colour variation.
static void Feedback(bool success = true) {
  Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
  Console.WriteLine(success ? "ok" : "invalid");
  Console.ForegroundColor = ConsoleColor.White;
}
