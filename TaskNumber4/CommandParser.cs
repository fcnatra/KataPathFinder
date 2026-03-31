namespace TaskNumber4;

public static class CommandParser
{
	public static IEnumerable<Command> Parse(string input)
	{
		int i = 0;
		while (i < input.Length)
		{
			char c = input[i];

			if (char.IsDigit(c))
			{
				int start = i;
				while (i < input.Length && char.IsDigit(input[i])) i++;
				yield return new Command(CommandType.Move, int.Parse(input[start..i]));
			}
			else
			{
				yield return c switch
				{
					'R' => new Command(CommandType.TurnRight90, 0),
					'L' => new Command(CommandType.TurnLeft90, 0),
					'r' => new Command(CommandType.TurnRight45, 0),
					'l' => new Command(CommandType.TurnLeft45, 0),
					_ => throw new ArgumentException($"Unknown command: {c}")
				};
				i++;
			}
		}
	}
}

public record Command(CommandType Type, int Steps);

public enum CommandType { Move, TurnRight90, TurnLeft90, TurnRight45, TurnLeft45 }
