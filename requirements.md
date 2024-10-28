# Toy Robot

## Instructions

We would like you to write a program that simulates a Toy Robot moving on a table top. The table top is a grid of 5 units x 5 units. There are no obstructions on the table surface. The Toy Robot is free to roam around the surface of the table, but must be prevented from falling to destruction. A failed or invalid command should not stop the simulation.

* Be sure to write comments, a README and any assumptions you made. Provide instructions on how to run the project and any extra notes you may have.
* Please use JavaScript, TypeScript or C#.
* A basic CLI is more than enough to pass this assessment and secure an interview, but if you're comfortable and want to add a UI, please do.
* Testing is great, please show us what you've got!
* Every command should provide visual output that the command has either succeeded or failed.
* Commit your code to a public Git repository and provide us with the URL.

### Commands

Please support the following commands:

* `PLACE X,Y,F` will place the Toy Robot on the table at position `X,Y` and facing direction `F`.
  * Direction can be one of the cardinal points: `NORTH`, `EAST`, `SOUTH` or `WEST`.
* `MOVE` will move the Toy Robot one unit forward in the direction it is currently facing.
* `LEFT` will rotate the Toy Robot 90 degrees left (anti-clockwise/counter-clockwise).
* `RIGHT` will rotate the Toy Robot 90 degrees right (clockwise).
* `REPORT` will announce the `X,Y,F` of Toy Robot.

### Constraints

* The first valid command must be the `PLACE`. After that, any sequence of commands may be issued in any order, including another `PLACE` command.

## Example Input and Output

### Example A

**Input:**

```text
PLACE 0,0,NORTH
MOVE
REPORT
```

**Output:**

```text
0,1,NORTH
```

### Example B

**Input:**

```text
PLACE 0,0,NORTH
LEFT
REPORT
```

**Output:**

```text
0,0,WEST
```

### Example C

**Input:**

```text
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```

**Output:**

```text
3,3,NORTH
```
