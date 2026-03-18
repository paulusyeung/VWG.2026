namespace Gizmox.WebGUI.Common.Design.Skins;

public class ThemeCodeDomSerializer : SkinCodeDomSerializer
{
	protected override string GetResourceName(string strComponentName, string strKeyValue)
	{
		return $"Skin:{strKeyValue}";
	}

	protected override string GetResourcePropertyName(string strComponentName, string strKeyValue, string strPropertyName)
	{
		return $"Skin:{strKeyValue}:{strPropertyName}";
	}
}
