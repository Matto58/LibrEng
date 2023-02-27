namespace Mattodev.LibrEng;

public class Game
{
	public Board board;
	public Player white;
	public Player black;
	public List<Move> whiteMoveStorage;
	public List<Move> blackMoveStorage;
	public bool whiteturn;
	public bool running = true;

	public Game(Player w, Player b)
	{
		board = new();
		white = w;
		black = b;
		whiteturn = true;

		whiteMoveStorage = new();
		blackMoveStorage = new();
	}

	/// <summary>
	/// Summarizes the game.
	/// </summary>
	/// <returns>A summary.</returns>
	public string shortSummary()
	{
		string move = whiteturn ? "White" : "Black";
		float eval = board.eval();
		string wtitle = white.title != PlTitle.None ? $"[{Player.textFromTitle(white.title)}] " : "";
		string btitle = black.title != PlTitle.None ? $"[{Player.textFromTitle(black.title)}] " : "";

		if (float.IsNaN(eval)) return "! 1101"; // error 1101
		
		return
			$"{move} to move - Eval: {(float.IsPositive(eval) ? "+" : "-")}{eval}\n" +
			$"White: {wtitle}{white.name} ({white.elo})\n" +
			$"Black: {btitle}{black.name} ({black.elo})";
	}
}
