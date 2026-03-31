using System.Drawing;

namespace TaskNumber4;

public class Navigator
{
	// 8 directions clockwise: N, NE, E, SE, S, SW, W, NW
	private static readonly (int Dx, int Dy)[] Deltas =
	[
		( 0,  1),  // 0: N
		( 1,  1),  // 1: NE
		( 1,  0),  // 2: E
		( 1, -1),  // 3: SE
		( 0, -1),  // 4: S
		(-1, -1),  // 5: SW
		(-1,  0),  // 6: W
		(-1,  1),  // 7: NW
	];

	private int _directionIndex = 0; // starts facing North
	private int _x = 0;
	private int _y = 0;

	public void Apply(Command command)
	{
		switch (command.Type)
		{
			case CommandType.TurnRight90: _directionIndex = (_directionIndex + 2) % 8; break;
			case CommandType.TurnLeft90:  _directionIndex = (_directionIndex + 6) % 8; break;
			case CommandType.TurnRight45: _directionIndex = (_directionIndex + 1) % 8; break;
			case CommandType.TurnLeft45:  _directionIndex = (_directionIndex + 7) % 8; break;
			case CommandType.Move:
				var (dx, dy) = Deltas[_directionIndex];
				_x += dx * command.Steps;
				_y += dy * command.Steps;
				break;
		}
	}

	public Point Position => new Point(_x, _y);
}
