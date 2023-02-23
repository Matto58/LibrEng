namespace Mattodev.LibrEng;

public enum PlTitle
{
	None,
	Grandmaster = 1,
	Internationalmaster = 2,
	FIDEmaster = 3,
	Candidatemaster = 4,
	WomanGrandmaster = 5,
	WomanInternationalmaster = 6,
	WomanFIDEmaster = 7,
	WomanCandidatemaster = 8,
	Bot = 9,
}
public class Player
{
	public string name;
	public PColor color;
	public PlTitle title;
	public int elo;

	public Player(string name, PlTitle title, PColor color, int elo)
	{
		this.name = name;
		this.color = color;
		this.elo = elo;
		this.title = title;
	}

	public static PlTitle titleFromText(string text)
		=> text.ToUpper() switch
		{
			"GM" => PlTitle.Grandmaster,
			"IM" => PlTitle.Internationalmaster,
			"FM" => PlTitle.FIDEmaster,
			"CM" => PlTitle.Candidatemaster,
			"WGM" => PlTitle.WomanGrandmaster,
			"WIM" => PlTitle.WomanInternationalmaster,
			"WFM" => PlTitle.WomanFIDEmaster,
			"WCM" => PlTitle.WomanCandidatemaster,
			"BOT" => PlTitle.Bot,
			_ => PlTitle.None,
		};
	public static string textFromTitle(PlTitle title)
		=> title.ToString() switch
		{
			"Grandmaster" => "GM",
			"Internationalmaster" => "IM",
			"FIDEmaster" => "FM",
			"Candidatemaster" => "CM",
			"WomanGrandmaster" => "WGM",
			"WomanInternationalmaster" => "WIM",
			"WomanFIDEmaster" => "WFM",
			"WomanCandidatemaster" => "WCM",
			"Bot" => "BOT",
			_ => "",
		};
}
