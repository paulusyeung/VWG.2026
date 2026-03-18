using System;
using System.IO;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Common.Resources;

/// <summary>
///
/// </summary>
[Serializable]
internal class GeneralResourceHandleDefaultGranter : IGeneralResourceHandleAccessGranter
{
	/// <summary>
	/// Determines whether the specified string path is granted.
	/// </summary>
	/// <param name="strPath">The string path.</param>
	/// <param name="blnIsLocalFile">if set to <c>true</c> [BLN is local file].</param>
	/// <returns></returns>
	public bool IsGranted(string strPath, bool blnIsLocalFile)
	{
		bool result = !blnIsLocalFile;
		if (blnIsLocalFile)
		{
			string text = Path.Combine(Application.StartupPath, "Resources");
			string fullPath = Path.GetFullPath(strPath);
			if (Directory.Exists(text) && fullPath.StartsWith(text))
			{
				result = true;
			}
		}
		return result;
	}
}
