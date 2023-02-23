namespace Mattodev.LibrEng
{
	public enum PColor
	{
		Black = 0b0000,
		White = 0b1000
	}
	public enum PType
	{
		Pawn = 0,
		Rook = 1,
		Bishop = 2,
		Knight = 3,
		Queen = 4,
		King = 5,
	}
	public class Piece
	{
		public PColor color;
		public PType type;
		public int asNum { get { return (int)type | (int)color; } }
	}
	public class Board
	{
		public Piece?[,] pieces;

		public Board()
		{
			pieces = new Piece?[8, 8];
		}

		public string draw()
		{
			string o = "+-+-+-+-+-+-+-+-+";
			for (int y = 0; y < 8; y++)
			{
				o += "\n|";
				for (int x = 0; x < 8; x++)
				{
					o += "|" + (pieces[x,y] != null ? pieces[x, y]!.type.ToString()[0] : ' ');
				}
				o += "|";
			}
			return o;
		}
	}
}
