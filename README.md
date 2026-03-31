# PATH FINDER
This challenge has 5 different tasks to solve.

## Path Finder Series:
- #1: [Can you reach the exit?](https://www.codewars.com/kata/5765870e190b1472ec0022a2)
- #2: [Shortest path](https://www.codewars.com/kata/57658bfa28ed87ecfa00058a) 
- #3: [The Alpinist](https://www.codewars.com/kata/576986639772456f6f00030c)
- #4: [Where are you?](https://www.codewars.com/kata/5a0573c446d8435b8e00009f)
- #5: [There's someone here](https://www.codewars.com/kata/5a05969cba2a14e541000129)

## Description of each task:

### Task #1 Can you reach the exit?

Type of practice: **ALGORITHMS**

You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return true if you can reach position [N-1, N-1] or false otherwise.

Empty positions are marked **.**

Walls are marked **W**

Start and exit positions are empty in all test cases

### Task #2 Shortest path

Type of practice: **PUZZLES**

You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return the minimal number of steps to exit position [N-1, N-1] if it is possible to reach the exit from the starting position. Otherwise, return -1.

Empty positions are marked **.**

Walls are marked **W**

Start and exit positions are guaranteed to be empty in all test cases.

### Task #3 The Alpinist:

Type of practice: **ALGORITHMS**

You are at start location [0, 0] in mountain area of NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return minimal number of climb rounds to target location [N-1, N-1]. Number of climb rounds between adjacent locations is defined as difference of location altitudes (ascending or descending).

Location altitude is defined as an integer number (0-9).

### Task #4 Where are you?

Type of practice: **PUZZLES**

Hey, Path Finder, where are you?

### Task #5 There's someone here

Type of practice: **ALGORITHMS**

You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West)... Oh, no! There's monster here! He stands exactly at the exit... But you still have to reach the exit position [N-1, N-1]. Can you outwit him?

It's really hard to solve in general, so in this task the maze have only one position with wall.

Empty positions are marked **.**

Walls are marked **W**

All border positions are guaranteed to be empty in all test cases. And yes, wall is close enough to escape without meeting a monster.

Every time you are ready to make a move, call the function endTurn(way) where way parameter equal one of 'N', 'E', 'S' or 'W'. endTurn() returns monster's move.