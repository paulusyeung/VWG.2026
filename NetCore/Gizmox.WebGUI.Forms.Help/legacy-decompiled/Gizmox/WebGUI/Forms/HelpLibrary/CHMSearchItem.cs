namespace Gizmox.WebGUI.Forms.HelpLibrary;

internal class CHMSearchItem
{
	private string mstrTitle = "";

	private string mstrUrl = "";

	private string mstrLocation = "";

	private double mstrRating = 0.0;

	public string Title => mstrTitle;

	public string URL => mstrUrl;

	public string Location => mstrLocation;

	public double Rating => mstrRating;

	public CHMSearchItem(string title, string url, string location, double rating)
	{
		mstrTitle = title;
		mstrUrl = url;
		mstrLocation = location;
		mstrRating = rating;
	}
}
