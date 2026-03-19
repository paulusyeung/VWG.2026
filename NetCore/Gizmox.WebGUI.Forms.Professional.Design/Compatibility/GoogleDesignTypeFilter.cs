using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Google;

internal static class GoogleDesignTypeFilter
{
	public static ICollection FilterGenericTypes(ICollection types)
	{
		if (types == null || types.Count == 0)
		{
			return types;
		}

		ArrayList arrayList = new ArrayList(types.Count);
		foreach (Type type in types)
		{
			if (!type.ContainsGenericParameters)
			{
				arrayList.Add(type);
			}
		}

		return arrayList;
	}
}