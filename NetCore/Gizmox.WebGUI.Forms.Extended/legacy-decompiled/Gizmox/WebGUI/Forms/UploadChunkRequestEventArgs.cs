using System;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// EventArgs for single gateway/Ajax request
/// </summary>
[Serializable]
public class UploadChunkRequestEventArgs : EventArgs
{
	private UploadChunkRequestResult mobjResult;

	/// <summary>
	/// The results of a single uploaded file
	/// </summary>
	public UploadChunkRequestResult Result => mobjResult;

	/// <summary>
	/// Initializes the arguments with UploadFileResults
	/// </summary>
	/// <param name="objResult"></param>
	public UploadChunkRequestEventArgs(UploadChunkRequestResult objResult)
	{
		mobjResult = objResult;
	}
}
