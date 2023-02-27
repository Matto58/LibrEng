using System.Numerics;

namespace Mattodev.LibrEng
{
	public class Move
	{
		public static string numToFile(int num)
			=> num switch
			{
				0 => "a",
				1 => "b",
				2 => "c",
				3 => "d",
				4 => "e",
				5 => "f",
				6 => "g",
				7 => "h",
				_ => ""
			};
		public static string numToRank(int num)
			=> num switch
			{
				0 => "8",
				1 => "7",
				2 => "6",
				3 => "5",
				4 => "4",
				5 => "3",
				6 => "2",
				7 => "1",
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
			piece.type
			+ " @ "
			+ numToFile((int)piece.pos.Y)
			+ numToRank((int)piece.pos.X)
			+ (takes ? " takes" : " to")
			+ numToFile(y)
			+ numToRank(x)
			+ (check ? ", check" : "")
			+ (mate ? ", checkmate" : "");
	}
}
