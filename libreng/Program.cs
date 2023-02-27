namespace Mattodev.LibrEng;

internal class Program
{
	static int Err(string msg, int code)
	{
		Console.WriteLine($"\nERROR {code}! {msg}");
		return code;
	}

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
				return Err("Invalid piece color!", 1001);
			PColor color;

			Console.WriteLine("\nWhat's your name?");
			string name = Console.ReadLine()!;

			Console.WriteLine("What's your title (if you have one)? (i.e. IM, WGM, ...)");
			PlTitle title = Player.titleFromText(Console.ReadLine()!);

			Console.WriteLine("What's your ELO/rating?");
			if (!int.TryParse(Console.ReadLine(), out int elo))
				return Err("Invalid rating!", 1002);

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
						// the following line is only here to get the IndexOutOfRangeException before starting game
						string fen = args[1];

						Console.Write("Are you playing with the (W)hite pieces or the (B)lack pieces?");
						ConsoleKeyInfo k = Console.ReadKey();
						if (k.KeyChar.ToString().ToUpper() != "W" || k.KeyChar.ToString().ToUpper() == "B")
							return Err("Invalid piece color!", 1001);
						PColor color;

						Console.WriteLine("\nWhat's your name?");
						string name = Console.ReadLine()!;

						Console.WriteLine("What's your title (if you have one)? (i.e. IM, WGM, ...)");
						PlTitle title = Player.titleFromText(Console.ReadLine()!);

						Console.WriteLine("What's your ELO/rating?");
						if (!int.TryParse(Console.ReadLine(), out int elo))
							return Err("Invalid rating!", 1002);

						if (k.KeyChar.ToString().ToLower() == "W")
							color = PColor.White;
						else if (k.KeyChar.ToString().ToLower() == "B")
							color = PColor.Black;
						else return 1003;

						Board? brd = Board.fromFEN(fen);
						if (brd == null) return Err("Invalid FEN!", 1005);

						player = new(name, title, color, elo);
						game = new(
							color != PColor.White ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.White, EngInfo.elo),
							color != PColor.Black ? player : new($"LibrEng {EngInfo.ver}", PlTitle.Bot, PColor.Black, EngInfo.elo))
						{
							board = brd
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
						Board? brd2 = Board.fromFEN(args[0]);
						if (brd2 == null) return Err("Invalid FEN!", 1005);
						Console.WriteLine(brd2.eval());
						break;
				}
			}
			catch (IndexOutOfRangeException)
			{
				return Err("Too little args!"
					+ (args[0] == "-pf" || args[0] == "--play-fen"
					|| args[0] == "-ef" || args[0] == "--eval-fen" ? " (maybe put in a FEN you dumbass)" : ""), 1004);
			}
			catch (Exception e)
			{
				return Err("Internal: " + e.Message, 1100);
			}
		}

		return 0;
	}
}
