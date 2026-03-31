namespace TaskNumber4;

public class Finder
{
	public static (int X, int Y) PathFinder(string commands)
	{
		var navigator = new Navigator();
		foreach (var command in CommandParser.Parse(commands))
			navigator.Apply(command);
		return navigator.Position;
	}
}
