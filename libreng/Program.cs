namespace Mattodev.LibrEng;

internal class Program
{
	static int Main(string[] args)
	{
		Game game;
		Player player;
		Console.Clear();
		Console.WriteLine($"LibrEng {Ver.eng} - https://github.com/Matto58/LibrEng");
		Console.Write("Are you playing with the (W)hite pieces or the (B)lack pieces?");
		ConsoleKeyInfo k = Console.ReadKey();
		if (k.KeyChar.ToString().ToUpper() != "W" || k.KeyChar.ToString().ToUpper() == "B")
			return 1001;

		string name = "";
		PlTitle title = PlTitle.None;
		PColor color = PColor.Black;

		Console.WriteLine("\nWhat's your name?");
		name = Console.ReadLine()!;

		Console.WriteLine("What's your title (if you have one)? (i.e. IM, WGM, ...)");
		title = Player.titleFromText(Console.ReadLine()!);

		Console.WriteLine("What's your ELO/rating?");
		if (!int.TryParse(Console.ReadLine(), out int elo)) return 1002;

		if (k.KeyChar.ToString().ToLower() == "W")
			color = PColor.White;
		if (k.KeyChar.ToString().ToLower() == "B")
			color = PColor.Black;

		player = new(name, title, color, elo);
		game = new(
			color != PColor.White ? player : new($"LibrEng {Ver.eng}", PlTitle.Bot, PColor.White, 50),
			color != PColor.Black ? player : new($"LibrEng {Ver.eng}", PlTitle.Bot, PColor.Black, 50));

		Console.WriteLine();
		Console.WriteLine(game.shortSummary());

		return 0;
	}
}
