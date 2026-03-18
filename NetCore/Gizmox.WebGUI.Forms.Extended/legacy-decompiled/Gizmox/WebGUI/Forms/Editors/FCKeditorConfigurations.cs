using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Text;

namespace Gizmox.WebGUI.Forms.Editors;

/// <summary>
/// Hold the FCK editor Configurations
/// </summary>
[Serializable]
public class FCKeditorConfigurations : ISerializable
{
	private Hashtable _Configs;

	/// <summary>
	/// Gets or sets the <see cref="T:System.String" /> with the specified configuration name.
	/// </summary>
	/// <value></value>
	public string this[string configurationName]
	{
		get
		{
			if (_Configs.ContainsKey(configurationName))
			{
				return (string)_Configs[configurationName];
			}
			return null;
		}
		set
		{
			_Configs[configurationName] = value;
		}
	}

	internal FCKeditorConfigurations()
	{
		_Configs = new Hashtable();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Editors.FCKeditorConfigurations" /> class.
	/// </summary>
	/// <param name="info">The info.</param>
	/// <param name="context">The context.</param>
	protected FCKeditorConfigurations(SerializationInfo info, StreamingContext context)
	{
		_Configs = (Hashtable)info.GetValue("ConfigTable", typeof(Hashtable));
	}

	internal string GetHiddenFieldString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (DictionaryEntry config in _Configs)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append("&");
			}
			stringBuilder.AppendFormat("{0}={1}", config.Key.ToString(), config.Value.ToString());
		}
		return stringBuilder.ToString();
	}

	/// <summary>
	/// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
	/// </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
	/// <exception cref="T:System.Security.SecurityException">
	/// The caller does not have the required permission.
	/// </exception>
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("ConfigTable", _Configs);
	}
}
