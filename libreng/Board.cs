namespace Mattodev.LibrEng
{
	public enum PColor
	{
		Black = 0b0000,
		White = 0b1000
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
		public int asNum { get { return (int)type | (int)color; } }

		public Piece(PColor color, PType type)
		{
			this.color = color;
			this.type = type;
		}
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
						+ (pieces[x, y].type != PType.Empty ? pieces[x, y].type.ToString()[0] : ' ');
				}
				o += "|\n+--+--+--+--+--+--+--+--+";
			}
			return o;
		}
	}
}
