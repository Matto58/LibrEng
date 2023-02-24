using System.Numerics;

namespace Mattodev.LibrEng
{
	public class Move
	{
		public static string numToFile(int num)
			=> num switch
			{
				0 => "h",
				1 => "g",
				2 => "f",
				3 => "e",
				4 => "d",
				5 => "c",
				6 => "b",
				7 => "a",
				_ => ""
			};

		public Piece piece;
		public int x, y;
		public bool takes, check, mate;

		public Move(Piece piece, int x, int y, bool takes, bool check, bool mate)
		{
			this.piece = piece;
			this.x = x;
			this.y = y;
		}
		public Move(Piece piece, Vector2 pos)
		{
			this.piece = piece;
			x = (int)pos.X;
			y = (int)pos.Y;
		}

		public override string ToString() =>
			(piece.type != PType.Pawn ? Piece.letterFromType(piece.type) : "")
			+ (takes ? "x" : "")
			+ numToFile(y)
			+ (x + 1).ToString()
			+ (check ? "+" : "")
			+ (mate ? "#" : "");
	}
}
