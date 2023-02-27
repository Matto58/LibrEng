namespace Mattodev.LibrEng;

public enum PlTitle
{
	None,
	Grandmaster = 1,
	Internationalmaster = 2,
	Nationalmaster = 10,
	FIDEmaster = 3,
	Candidatemaster = 4,
	WomanGrandmaster = 5,
	WomanInternationalmaster = 6,
	WomanNationalmaster = 11,
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

	/// <summary>
	/// Converts a chess player title from a <see cref="string"/> (e.g. "GM", "WFM", ...) to a <see cref="PlTitle"/>.
	/// </summary>
	/// <param name="text">The title string.</param>
	/// <returns>The <see cref="PlTitle"/>.</returns>
	public static PlTitle titleFromText(string text)
		=> text.ToUpper() switch
		{
			"GM" => PlTitle.Grandmaster,
			"IM" => PlTitle.Internationalmaster,
			"NM" => PlTitle.Nationalmaster,
			"FM" => PlTitle.FIDEmaster,
			"CM" => PlTitle.Candidatemaster,
			"WGM" => PlTitle.WomanGrandmaster,
			"WIM" => PlTitle.WomanInternationalmaster,
			"WNM" => PlTitle.WomanNationalmaster,
			"WFM" => PlTitle.WomanFIDEmaster,
			"WCM" => PlTitle.WomanCandidatemaster,
			"BOT" => PlTitle.Bot,
			_ => PlTitle.None,
		};

	/// <summary>
	/// Converts a <see cref="PlTitle"/> to a chess player title <see cref="string"/> (e.g. "GM", "WFM", ...).
	/// </summary>
	/// <param name="title"></param>
	/// <returns>The <see cref="string"/>.</returns>
	public static string textFromTitle(PlTitle title)
		=> title.ToString() switch
		{
			"Grandmaster" => "GM",
			"Internationalmaster" => "IM",
			"Nationalmaster" => "NM",
			"FIDEmaster" => "FM",
			"Candidatemaster" => "CM",
			"WomanGrandmaster" => "WGM",
			"WomanInternationalmaster" => "WIM",
			"WomanNationalmaster" => "WNM",
			"WomanFIDEmaster" => "WFM",
			"WomanCandidatemaster" => "WCM",
			"Bot" => "BOT",
			_ => "",
		};
}
