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
			PColor color;

			Console.WriteLine("\nWhat's your name?");
			string name = Console.ReadLine()!;

			Console.WriteLine("What's your title (if you have one)? (i.e. IM, WGM, ...)");
			PlTitle title = Player.titleFromText(Console.ReadLine()!);

			Console.WriteLine("What's your ELO/rating?");
			if (!int.TryParse(Console.ReadLine(), out int elo)) return 1002;

			if (k.KeyChar.ToString().ToLower() == "W")
				color = PColor.White;
			else if (k.KeyChar.ToString().ToLower() == "B")
				color = PColor.Black;
			else return 1003;

			player = new(name, title, color, elo);
			game = new(
				color != PColor.White ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.White, EngInfo.elo),
				color != PColor.Black ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.Black, EngInfo.elo));

			string ss = game.shortSummary();
			
			if (ss[0] == '!')
				return int.Parse(ss.Split(' ')[1]);
			Console.Clear();
			Console.WriteLine(ss);
			Console.WriteLine(game.board.draw());
		}
		else
		{
			try
			{
				switch (args[0])
				{
					// todo: finish fen import
					case "-pf" or "--play-fen":
						Console.Write("Are you playing with the (W)hite pieces or the (B)lack pieces?");
						ConsoleKeyInfo k = Console.ReadKey();
						if (k.KeyChar.ToString().ToUpper() != "W" || k.KeyChar.ToString().ToUpper() == "B")
							return 1001;
						PColor color;

						Console.WriteLine("\nWhat's your name?");
						string name = Console.ReadLine()!;

						Console.WriteLine("What's your title (if you have one)? (i.e. IM, WGM, ...)");
						PlTitle title = Player.titleFromText(Console.ReadLine()!);

						Console.WriteLine("What's your ELO/rating?");
						if (!int.TryParse(Console.ReadLine(), out int elo)) return 1002;

						if (k.KeyChar.ToString().ToLower() == "W")
							color = PColor.White;
						else if (k.KeyChar.ToString().ToLower() == "B")
							color = PColor.Black;
						else return 1003;

						player = new(name, title, color, elo);
						game = new(
							color != PColor.White ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.White, EngInfo.elo),
							color != PColor.Black ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.Black, EngInfo.elo))
						{
							board = Board.fromFEN(args[1])
						};

						while (game.running)
						{
							Console.Clear();
							Console.WriteLine(game.shortSummary());
							Console.WriteLine(game.board.draw());
							game.running = false; // dont go into an infinite loop for now
						}
						break;
					case "-ef" or "--eval-fen":
						Console.WriteLine(Board.fromFEN(args[1]).eval());
						break;
				}
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine(
					"ERROR! Too little args"
					+ (args[0] == "-pf" || args[0] == "--play-fen" ? " (maybe put in a FEN you dumbass)" : ""));
				return 1004;
			}
			catch (Exception e)
			{
				Console.WriteLine("INTERNAL ERROR! " + e.Message);
				return 1100;
			}
		}

		return 0;
	}
}
