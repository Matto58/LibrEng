namespace Mattodev.LibrEng;

internal class Program
{
	static int Main(string[] args)
	{
		Game game;
		Player player;
		Console.Clear();
		Console.WriteLine($"LibrEng {EngInfo.ver} - https://github.com/Matto58/LibrEng");
		if (args.Length == 0)
		{
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
				color != PColor.White ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.White, EngInfo.elo),
				color != PColor.Black ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.Black, EngInfo.elo));

			string ss = game.shortSummary();

			if (ss[0] == '!')
				return int.Parse(ss.Split(' ')[1]);

			Console.WriteLine();
			Console.WriteLine(ss);
		}
		else
		{
			switch (args[0])
			{
				// todo: finish fen import
				case "-f" or "--fen":
					Console.Write("Are you playing with the (W)hite pieces or the (B)lack pieces?");
					ConsoleKeyInfo k = Console.ReadKey();
					if (k.KeyChar.ToString().ToUpper() != "W" || k.KeyChar.ToString().ToUpper() == "B")
						return 1001;
					break;
			}
		}

		return 0;
	}
}
