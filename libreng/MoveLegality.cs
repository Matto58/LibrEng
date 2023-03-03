namespace Mattodev.LibrEng
{
	public class MoveLegality
	{
		public static bool isLegal(Board b, Move m)
		{
			return true; // for now
		}
		public static bool canCastle(Board b, ref Piece rook, ref Piece king, bool longCastle)
		{
			return false; // we dont have castling fully implemented yet
		}
	}
}
