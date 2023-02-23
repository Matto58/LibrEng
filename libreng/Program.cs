namespace Mattodev.LibrEng
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Board board = new Board();
			Console.WriteLine($"LibrEng {Ver.eng} - https://github.com/Matto58/LibrEng");
			Console.WriteLine(board.draw());
		}
	}
}