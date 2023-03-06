using System.Numerics;

namespace Mattodev.LibrEng
{
	public class Move
	{
		/// <summary>
		/// Converts an Y value from 0-7 to a-h.
		/// </summary>
		/// <param name="num">The Y value.</param>
		/// <returns>A file ranging from a-h.</returns>
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

		/// <summary>
		/// Converts a X value from 0-7 to 8-1.
		/// </summary>
		/// <param name="num">The X value.</param>
		/// <returns>A rank ranging from 8-1.</returns>
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
		public bool takes, check, mate, doesCastle, isCastleLong;

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
			(!doesCastle ? piece.color.ToString()
			+ " "
			+ piece.type.ToString().ToLower()
			+ " @ "
			+ numToFile((int)piece.pos.Y)
			+ numToRank((int)piece.pos.X)
			+ (takes ? " takes " : " to ")
			+ numToFile(y)
			+ numToRank(x) : "O-O" + (isCastleLong ? "-O" : ""))
			+ (check ? ", check" : "")
			+ (mate ? ", checkmate" : "");
	}
}
