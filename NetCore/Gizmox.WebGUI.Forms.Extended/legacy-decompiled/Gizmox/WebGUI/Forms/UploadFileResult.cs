using System;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Base EventArg information type for UploadControl
/// </summary>
[Serializable]
public class UploadFileResult
{
	private string mstrName;

	private long mlngSize;

	private string mstrType;

	private string mstrTempFileFullName;

	/// <summary>
	/// Name of uploaded file as reported by the jQuery upload control
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
	/// The size of the file in bytes
	/// </summary>
	public long Size
	{
		get
		{
			return mlngSize;
		}
		set
		{
			mlngSize = value;
		}
	}

	/// <summary>
	/// The MIME content type for the uploaded file
	/// </summary>
	public string Type
	{
		get
		{
			return mstrType;
		}
		set
		{
			mstrType = value;
		}
	}

	/// <summary>
	/// The fully qualified name of the uploaded file on temporary storage, saved by the uploade control. 
	/// This name does not reflect the original filename, since GUID is used upon conflict.
	/// </summary>
	public string TempFileFullName
	{
		get
		{
			return mstrTempFileFullName;
		}
		set
		{
			mstrTempFileFullName = value;
		}
	}

	/// <summary>
	/// Parameterized constructor for UploadFileResult
	/// </summary>
	/// <param name="strName">The filename without path</param>
	/// <param name="lngSize">Size of file in bytes</param>
	/// <param name="strType">MIME type of file</param>
	/// <param name="strTempFileFullName">Full path name of temporary file (where file is uploaded by the control)</param>
	public UploadFileResult(string strName, long lngSize, string strType, string strTempFileFullName)
	{
		mstrName = strName;
		mlngSize = lngSize;
		mstrType = strType;
		mstrTempFileFullName = strTempFileFullName;
	}

	/// <summary>
	/// Default constructor
	/// </summary>
	public UploadFileResult()
	{
	}
}
