using System;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// EventArgs for completed upload of one uploaded files
/// </summary>
[Serializable]
public class UploadCompletedEventArgs : EventArgs
{
	private UploadFileResult mobjResult;

	/// <summary>
	/// The uploaded file's upload results
	/// </summary>
	public UploadFileResult Result => mobjResult;

	/// <summary>
	/// Initializes the arguments with the results for the uploaded file
	/// </summary>
	/// <param name="objList"></param>
	public UploadCompletedEventArgs(UploadFileResult objResult)
	{
		mobjResult = objResult;
	}
}
