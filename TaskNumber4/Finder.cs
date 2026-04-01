using System.Drawing;

namespace TaskNumber4;

public class Finder
{
	public static Point iAmHere(string path)
	{
		var navigator = new Navigator();
		foreach (var command in CommandParser.Parse(path))
			navigator.Apply(command);
		return navigator.Position;
	}
}
