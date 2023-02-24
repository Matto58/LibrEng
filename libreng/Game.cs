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
		board = new Board();
		white = w;
		black = b;
		whiteturn = true;

		whiteMoveStorage = new();
		blackMoveStorage = new();
	}

	public string shortSummary()
	{
		string move = whiteturn ? "White" : "Black";
		float eval = this.eval();
		string wtitle = white.title != PlTitle.None ? $"[{Player.textFromTitle(white.title)}] " : "";
		string btitle = black.title != PlTitle.None ? $"[{Player.textFromTitle(black.title)}] " : "";

		if (eval == float.NaN) return "! 1101"; // error 1101
		
		return
			$"{move} to move - Eval: {eval}\n" +
			$"White: {wtitle}{white.name} ({white.elo})\n" +
			$"Black: {btitle}{black.name} ({black.elo})";
	}

	public float eval()
	{
		float e = 0f;
		e += -kingSafety(PColor.Black) + kingSafety(PColor.White);
		e += -material(PColor.Black) + material(PColor.White);
		return e;
	}

	public float kingSafety(PColor color)
		=> kingSafetyPt1(color) + kingSafetyPt2(color);

	// determine king safety on average distance between
	// friendly pieces and friendly king
	public float kingSafetyPt1(PColor color)
	{
		var kings = board.lookForPiecePositions(color, PType.King);
		if (kings.Count == 0) return float.PositiveInfinity;
		var king = kings[0];

		float dist = 0f;
		int count = 0;

		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++)
			{
				if (board.pieces[x, y].type != PType.Empty && board.pieces[x, y].type != PType.Pawn)
				{
					dist += Piece.dist(x, y, king.x, king.y);
					count++;
				}
			}
		}

		return Piece.CORNER_DIST - (dist / count);
	}

	// todo: finish kingSafetyPt2(PColor) and material(PColor)

	// determine king unsafety on average distance between
	// enemy pieces and friendly king
	public float kingSafetyPt2(PColor color)
	{
		float e = 0f;

		return e;
	}
	public float material(PColor color)
	{
		float e = 0f;

		return e;
	}
}
