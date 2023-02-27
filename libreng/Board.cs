namespace Mattodev.LibrEng;

using System.Numerics;
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
	public Vector2 pos;

	public Piece(PColor color, PType type, Vector2 pos)
	{
		this.color = color;
		this.type = type;
		this.pos = pos;
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
	public static PType typeFromLetter(string l)
		=> l switch
		{
			"R" => PType.Rook,
			"B" => PType.Bishop,
			"N" => PType.Knight,
			"Q" => PType.Queen,
			"K" => PType.King,
			_ => PType.Pawn
		};

	public static float dist(int x1, int y1, int x2, int y2)
		=> Abs(Sqrt(x1 * x2 + y1 * y2));

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
				place(PColor.Black, PType.Empty, x, y);
	}

	/// <summary>
	/// Places a piece at a specific location.
	/// </summary>
	/// <param name="piece">The piece.</param>
	public void place(Piece piece)
	{
		pieces[(int)piece.pos.X, (int)piece.pos.Y] = piece;
	}

	/// <summary>
	/// Places a piece at a specific location.
	/// </summary>
	/// <param name="color">The piece color.</param>
	/// <param name="type">The piece type.</param>
	public void place(PColor color, PType type, int x, int y)
	{
		place(new(color, type, new(x, y)));
	}
	
	/// <summary>
	/// Selects pieces of a certain color from this board.
	/// </summary>
	/// <param name="color">The color.</param>
	/// <returns>This board but all pieces are a certain color.</returns>
	public Board selectColor(PColor color)
	{
		Board b = new();
		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].color == color)
					b.pieces[x, y] = pieces[x, y];
		return b;
	}

	/// <summary>
	/// Selects pieces of a certain type from this board.
	/// </summary>
	/// <param name="type">The type.</param>
	/// <returns>This board but all pieces are a certain type.</returns>
	public Board selectType(PType type)
	{
		Board b = new();
		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type)
					b.place(pieces[x, y]);

		return b;
	}

	/// <summary>
	/// Looks for positions of pieces of a certain color.
	/// </summary>
	/// <param name="color">The color.</param>
	/// <returns>A list of positions.</returns>
	public List<(int x, int y)> lookForPiecePositions(PColor color)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].color == color)
					piecePos.Add((x, y));

		return piecePos;
	}

	/// <summary>
	/// Looks for positions of pieces of a certain type.
	/// </summary>
	/// <param name="type">The type.</param>
	/// <returns>A list of positions.</returns>
	public List<(int x, int y)> lookForPiecePositions(PType type)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type)
					piecePos.Add((x, y));

		return piecePos;
	}

	/// <summary>
	/// Looks for positions of pieces of a certain color and type.
	/// </summary>
	/// <param name="color">The color.</param>
	/// <param name="type">The type.</param>
	/// <returns>A list of positions.</returns>
	public List<(int x, int y)> lookForPiecePositions(PColor color, PType type)
	{
		List<(int, int)> piecePos = new();

		for (int y = 0; y < 8; y++)
			for (int x = 0; x < 8; x++)
				if (pieces[x, y].type == type && pieces[x, y].color == color)
					piecePos.Add((x, y));

		return piecePos;
	}

	/// <summary>
	/// Looks for pieces of a certain color.
	/// </summary>
	/// <param name="color">The color.</param>
	/// <returns>A list of <see cref="Piece"/>s.</returns>
	public List<Piece> lookForPieces(PColor color) =>
		lookForPiecePositions(color)
		.Select(t => pieces[t.x, t.y])
		.ToList();

	/// <summary>
	/// Looks for pieces of a certain type.
	/// </summary>
	/// <param name="type">The type.</param>
	/// <returns>A list of <see cref="Piece"/>s.</returns>
	public List<Piece> lookForPieces(PType type) =>
		lookForPiecePositions(type)
		.Select(t => pieces[t.x, t.y])
		.ToList();

	/// <summary>
	/// Looks for pieces of a certain color and type.
	/// </summary>
	/// <param name="color">The color.</param>
	/// <param name="type">The type.</param>
	/// <returns>A list of <see cref="Piece"/>s.</returns>
	public List<Piece> lookForPieces(PColor color, PType type) =>
		lookForPiecePositions(color, type)
		.Select(t => pieces[t.x, t.y])
		.ToList();

	/// <summary>
	/// Draws the board and puts in a string.
	/// </summary>
	/// <returns>The board as a string.</returns>
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

	/// <summary>
	/// Draws the board and puts in a <see cref="string"/>.
	/// </summary>
	/// <returns>The board as a <see cref="string"/>.</returns>
	public override string ToString() => draw();

	/// <summary>
	/// Loads a board from a FEN <see cref="string"/>.
	/// </summary>
	/// <param name="fen">The FEN <see cref="string"/>.</param>
	/// <returns>The board.</returns>
	public static Board fromFEN(string fen)
	{
		Board board = new();
		string[] f = fen.Split(" ");
		string[] p = f[0].Split("/");
		for (int y = 0; y < 8; y++)
		{
			char[] c = p[y].ToCharArray();
			for (int x = 0; x < 8; x++)
			{
				string l = c[x].ToString();
				if (int.TryParse(l, out int n)) x += n - 2;
				else
				{
					board.place(
						new(l.ToLower() == l ? PColor.Black : PColor.White,
							Piece.typeFromLetter(l.ToUpper()), new(x, y)));
				}
			}
		}
		return board;
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
		var kings = lookForPiecePositions(color, PType.King);
		if (kings.Count == 0) return float.PositiveInfinity;
		var king = kings[0];

		float dist = 0f;
		int count = 0;

		for (int y = 0; y < 8; y++)
		{
			for (int x = 0; x < 8; x++)
			{
				if (pieces[x, y].type != PType.Empty && pieces[x, y].type != PType.Pawn)
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
