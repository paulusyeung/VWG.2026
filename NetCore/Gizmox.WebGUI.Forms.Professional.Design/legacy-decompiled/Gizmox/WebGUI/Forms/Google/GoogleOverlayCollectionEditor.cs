using System;
using System.Collections;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms.Google;

public class GoogleOverlayCollectionEditor : Gizmox.WebGUI.Forms.Design.CollectionEditor
{
	public GoogleOverlayCollectionEditor()
		: base(typeof(GoogleMapOverlayCollection))
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		ArrayList arrayList = new ArrayList();
		IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		if (designerHost != null)
		{
			ITypeDiscoveryService typeDiscoveryService = (ITypeDiscoveryService)designerHost.GetService(typeof(ITypeDiscoveryService));
			if (typeDiscoveryService != null)
			{
				arrayList.Add(typeof(GoogleMapMarkerOverlay));
				foreach (Type item in GoogleDesignTypeFilter.FilterGenericTypes(typeDiscoveryService.GetTypes(typeof(GoogleMapOverlay), excludeGlobalTypes: false)))
				{
					if (!(item == typeof(GoogleMapOverlay)) && !item.IsAbstract && (item.IsPublic || item.IsNestedPublic) && !arrayList.Contains(item))
					{
						arrayList.Add(item);
					}
				}
			}
		}
		return (Type[])arrayList.ToArray(typeof(Type));
	}

	protected override string GetDisplayText(object value)
	{
		if (value != null)
		{
			return value.GetType().Name;
		}
		return base.GetDisplayText(value);
	}
}
