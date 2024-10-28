# Toy Robot Simulation Console App

Given the [requirements](./requirements.md), I've opted to implement using C# in a console application. Textual input and output indicated by the requirements lends itself well to console application.

The requirements indicate that a UI is also acceptable. I assume this mean *Graphical* UI (GUI) but due to time constraints I opted to stick to the console UI even though it would have been fun to do, I do have kids that need attention too on the weekend. :)

## Instructions

- Clone the repo
- Open the repo directory using VS Code.
- Install the .net (8.0) dependencies if they are not already.
- To build and run tests use the commands available from the Command Palette (Ctrl-Shift-P)
- To run the sim, find the .exe in the bin/Debug or bin/Release directory and double-click to start.
- Use the input commands per the [requirements](./requirements.md).
- Use Ctrl-C to terminate the executable at any time.

## Assumptions

- For a PLACE command that provides integers that are out of the bounds of the table, assumption is that the placement is invalid and ignored by the sim.
- Validation of PLACE arguments can permit signed integers but downstream logic can decide that the postion is out-of-bounds/off the table and ignore.
- Test data seems to indicate no textual feedback for either accepted or rejected inputs but given the requirement that "every command should provide visual output that the command has either succeeded or failed" I have simply opted to feedback on the console with text. I opted for the most simple solution for this requirement given time constraints. Potentially a flash of the background would have been cooler but drew the line at simplicity in this case.

## Comments

I made the decision to avoid thrid-party libraries as I thought it would better showcase my knowledge of C# language and syntax a little better.
