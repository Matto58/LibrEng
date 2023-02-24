namespace Mattodev.LibrEng;
using static System.MathF;

public enum PColor
{
	Black = 0,
	White = 1
}
public enum PType
{
	Empty = 0,
	Pawn = 1,
	Rook = 2,
	Bishop = 3,
	Knight = 4,
	Queen = 5,
	King = 6,
}
public class Piece
{
	public PColor color;
	public PType type;

	public Piece(PColor color, PType type)
	{
		this.color = color;
		this.type = type;
	}

	public static string letterFromType(PType type)
		=> type switch
		{
			PType.Rook => "R",
			PType.Bishop => "B",
			PType.Knight => "N",
			PType.Queen => "Q",
			PType.King => "K",
			_ => " "
		};

	public static float dist(int x1, int y1, int x2, int y2)
		=> Abs(Sqrt(x1 * x2 + y1 * y2));

	public Board posFromFen(string fen)
	{
		Board board = new();
		string[] f = fen.Split(' ');
		string[] p = f[0].Split('/');

		return board;
	}

	public const float CORNER_DIST = 9.8994949366117f;
}
public class Board
{
	public Piece[,] pieces;

	public Board()
	{
		pieces = new Piece[8, 8];
		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				pieces[x, y] = new(PColor.Black, PType.Empty);
	}

	public void place(Piece piece, int x, int y)
	{
		pieces[x, y] = piece;
	}
	public void place(PColor color, PType type, int x, int y)
	{
		pieces[x, y] = new(color, type);
	}
	
	public Board selectColor(PColor color)
	{
		Board b = new();
		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].color == color)
					b.pieces[x, y] = pieces[x, y];
		return b;
	}
	public Board selectType(PType type)
	{
		Board b = new();
		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type)
					b.pieces[x,y] = pieces[x, y];

		return b;
	}
	public List<(int x, int y)> lookForPiecePositions(PColor color)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].color == color)
					piecePos.Add((x, y));

		return piecePos;
	}
	public List<(int x, int y)> lookForPiecePositions(PType type)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type)
					piecePos.Add((x, y));

		return piecePos;
	}
	public List<(int x, int y)> lookForPiecePositions(PColor color, PType type)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type && pieces[x, y].color == color)
					piecePos.Add((x, y));

		return piecePos;
	}

	public List<Piece> lookForPieces(PColor color) =>
		lookForPiecePositions(color)
		.Select(t => pieces[t.Item1, t.Item2])
		.ToList();
	public List<Piece> lookForPieces(PType type) =>
		lookForPiecePositions(type)
		.Select(t => pieces[t.Item1, t.Item2])
		.ToList();
	public List<Piece> lookForPieces(PColor color, PType type) =>
		lookForPiecePositions(color, type)
		.Select(t => pieces[t.Item1, t.Item2])
		.ToList();

	public string draw()
	{
		string o = "+--+--+--+--+--+--+--+--+";
		for (int y = 0; y < 8; y++)
		{
			o += "\n";
			for (int x = 0; x < 8; x++)
			{
				o +=
					"|"
					+ (pieces[x, y].type != PType.Empty ? (pieces[x, y].color == PColor.White ? "W" : "B") : " ")
					+ Piece.letterFromType(pieces[x, y].type);
			}
			o += "|\n+--+--+--+--+--+--+--+--+";
		}
		return o;
	}
}
