using System;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// EventArgs for unhandled exceptions
/// </summary>
[Serializable]
public class UploadErrorEventArgs : EventArgs
{
	private string mstrError;

	private Exception mobjException;

	/// <summary>
	/// The error message
	/// </summary>
	public string Error => mstrError;

	/// <summary>
	/// The error exception
	/// </summary>
	public Exception ErrorException => mobjException;

	/// <summary>
	/// Initializes the arguments with information on the error
	/// </summary>
	/// <param name="strError"></param>
	/// <param name="objException"></param>
	public UploadErrorEventArgs(string strError, Exception objException)
	{
		mstrError = strError;
		mobjException = objException;
	}
}
