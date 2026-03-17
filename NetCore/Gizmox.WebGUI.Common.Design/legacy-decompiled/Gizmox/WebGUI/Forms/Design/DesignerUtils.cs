using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Forms.Design;

public class DesignerUtils
{
	public static IContainer CheckForNestedContainer(IContainer container)
	{
		if (container is NestedContainer nestedContainer)
		{
			return nestedContainer.Owner.Site.Container;
		}
		return container;
	}

	internal static void ShowErrorDialog(IUIService uiService, string errorString, object sender)
	{
		if (uiService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			uiService.ShowError(errorString);
		}
	}

	internal static void ShowErrorDialog(IUIService uiService, Exception ex, object sender)
	{
		if (uiService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			uiService.ShowError(ex);
		}
	}

	public static ICollection FilterGenericTypes(ICollection types)
	{
		if (types == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (types.Count != 0)
		{
			/*OpCode not supported: LdMemberToken*/;
			ArrayList arrayList = new ArrayList(types.Count);
			{
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
		return types;
	}
}
