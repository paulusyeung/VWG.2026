using System;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// EventArgs for end of gateway/Ajax request of a chunk or a one chunk file upload
/// </summary>
[Serializable]
public class UploadChunkRequestResult : UploadFileResult
{
	private string mstrRange;

	/// <summary>
	/// The contained range, for chunked upload. For files uploaded in one chunk, this will be null
	/// </summary>
	public string Range
	{
		get
		{
			return mstrRange;
		}
		set
		{
			mstrRange = value;
		}
	}

	/// <summary>
	/// Parameterized constructor for UploadFileResult
	/// </summary>
	/// <param name="strName">The filename without path</param>
	/// <param name="lngSize">Size of file in bytes</param>
	/// <param name="strType">MIME type of file</param>
	/// <param name="strTempFileFullName">Full path name of temporary file (where file is uploaded by the control)</param>
	public UploadChunkRequestResult(string strName, long lngSize, string strType, string strTempFileFullName, string strRange)
		: base(strName, lngSize, strType, strTempFileFullName)
	{
		mstrRange = strRange;
	}

	/// <summary>
	/// Default constructor
	/// </summary>
	public UploadChunkRequestResult()
	{
	}
}
