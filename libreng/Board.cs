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
		public Piece[,] pieces;

		public Board()
		{
			pieces = new Piece[8, 8];
		}
	}
}
