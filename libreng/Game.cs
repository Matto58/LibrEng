namespace Mattodev.LibrEng;

public class Game
{
	public Board board;
	public Player white;
	public Player black;
	public bool whiteturn;
	public bool running = true;

	public Game(Player w, Player b)
	{
		board = new Board();
		white = w;
		black = b;
		whiteturn = true;
	}

	public string shortSummary() =>
		$"{(whiteturn ? "White" : "Black")} to move\n" +
		$"White: {(white.title != PlTitle.None ? $"[{Player.textFromTitle(white.title)}] " : "")}{white.name} ({white.elo})\n" +
		$"Black: {(black.title != PlTitle.None ? $"[{Player.textFromTitle(black.title)}] " : "")}{black.name} ({black.elo})";
}
