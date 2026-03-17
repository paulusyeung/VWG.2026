using System;

namespace Gizmox.WebGUI.Forms.Google;

/// <summary>
/// GoogleMap EventArgs class for KmlLayer events
/// </summary>
[Serializable]
public class GoogleMapKmlLayerClickEventArgs : GoogleMapLayerEventArgs
{
	private string mstrAuthor_Name;

	private string mstrAuthor_Email;

	private string mstrAuthor_Uri;

	private string mstrDescription;

	private string mstrId;

	private string mstrInfoWindowHtml;

	private string mstrName;

	private string mstrSnippet;

	/// <summary>
	/// The Author's name
	/// </summary>
	public string Author_Name
	{
		get
		{
			return mstrAuthor_Name;
		}
		set
		{
			mstrAuthor_Name = value;
		}
	}

	/// <summary>
	/// The Author's email
	/// </summary>
	public string Author_Email
	{
		get
		{
			return mstrAuthor_Email;
		}
		set
		{
			mstrAuthor_Email = value;
		}
	}

	/// <summary>
	/// The Author's Uri
	/// </summary>
	public string Author_Uri
	{
		get
		{
			return mstrAuthor_Uri;
		}
		set
		{
			mstrAuthor_Uri = value;
		}
	}

	/// <summary>
	/// The Description of the reference
	/// </summary>
	public string Description
	{
		get
		{
			return mstrDescription;
		}
		set
		{
			mstrDescription = value;
		}
	}

	/// <summary>
	/// The Id of the reference
	/// </summary>
	public string Id
	{
		get
		{
			return mstrId;
		}
		set
		{
			mstrId = value;
		}
	}

	/// <summary>
	/// The Html to show in InfoWindow for the reference
	/// </summary>
	public string InfoWindowHtml
	{
		get
		{
			return mstrInfoWindowHtml;
		}
		set
		{
			mstrInfoWindowHtml = value;
		}
	}

	/// <summary>
	/// The Name of the reference
	/// </summary>
	public string Name
	{
		get
		{
			return mstrName;
		}
		set
		{
			mstrName = value;
		}
	}

	/// <summary>
	/// The Snippet for the reference
	/// </summary>
	public string Snippet
	{
		get
		{
			return mstrSnippet;
		}
		set
		{
			mstrSnippet = value;
		}
	}

	/// <summary>
	/// Does the reference have Author information or not
	/// </summary>
	public bool hasAuthor
	{
		get
		{
			if (string.IsNullOrEmpty(mstrAuthor_Email) && string.IsNullOrEmpty(mstrAuthor_Name))
			{
				return !string.IsNullOrEmpty(mstrAuthor_Uri);
			}
			return true;
		}
	}

	/// <summary>
	/// Initializes the instance from parameters
	/// </summary>
	/// <param name="objLayer">The Kml layer</param>
	/// <param name="objLocation">The location where the event occurred</param>
	public GoogleMapKmlLayerClickEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation)
		: base(objLayer, objLocation)
	{
	}

	/// <summary>
	/// Initializes the instance from parameters
	/// </summary>
	/// <param name="objLayer">The kml Layer</param>
	/// <param name="objLocation">The location where event occurred</param>
	/// <param name="strDescription">Description of the clicked reference</param>
	/// <param name="strId">The ID of the clicked reference</param>
	/// <param name="strInfoWindowHrml">The Html info contents for the clicked reference</param>
	/// <param name="strName">The Name of the clicked reference</param>
	/// <param name="strSnippet">The Snippet for the clicked reference</param>
	public GoogleMapKmlLayerClickEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation, string strDescription, string strId, string strInfoWindowHrml, string strName, string strSnippet)
		: base(objLayer, objLocation)
	{
		mstrDescription = strDescription;
		mstrId = strId;
		mstrInfoWindowHtml = strInfoWindowHrml;
		mstrName = strName;
		mstrSnippet = strSnippet;
	}

	/// <summary>
	/// Initializes the instance from parameters
	/// </summary>
	/// <param name="objLayer">The kml Layer</param>
	/// <param name="objLocation">The location where event occurred</param>
	/// <param name="strAuthorName">The author for the clicked reference</param>
	/// <param name="strAuthorEmail">The email for the clicked reference</param>
	/// <param name="strAuthorUri">The Author Uri for the clicked reference</param>
	/// <param name="strDescription">Description of the clicked reference</param>
	/// <param name="strId">The ID of the clicked reference</param>
	/// <param name="strInfoWindowHrml">The Html info contents for the clicked reference</param>
	/// <param name="strName">The Name of the clicked reference</param>
	/// <param name="strSnippet">The Snippet for the clicked reference</param>
	public GoogleMapKmlLayerClickEventArgs(GoogleMapLayer objLayer, GoogleMapLocation objLocation, string strAuthorName, string strAuthorEmail, string strAuthorUri, string strDescription, string strId, string strInfoWindowHrml, string strName, string strSnippet)
		: base(objLayer, objLocation)
	{
		mstrAuthor_Name = strAuthorName;
		mstrAuthor_Email = strAuthorEmail;
		mstrAuthor_Uri = strAuthorUri;
		mstrDescription = strDescription;
		mstrId = strId;
		mstrInfoWindowHtml = strInfoWindowHrml;
		mstrName = strName;
		mstrSnippet = strSnippet;
	}
}
