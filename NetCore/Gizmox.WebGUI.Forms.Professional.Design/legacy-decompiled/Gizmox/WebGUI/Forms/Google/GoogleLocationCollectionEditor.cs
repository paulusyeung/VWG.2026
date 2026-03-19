using System;
using System.Collections;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms.Google;

public class GoogleLocationCollectionEditor : Gizmox.WebGUI.Forms.Design.CollectionEditor
{
	public GoogleLocationCollectionEditor()
		: base(typeof(GoogleMapLocationCollection))
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
				foreach (Type item in GoogleDesignTypeFilter.FilterGenericTypes(typeDiscoveryService.GetTypes(typeof(GoogleMapLocation), excludeGlobalTypes: false)))
				{
					if (!arrayList.Contains(item) && ShouldAddNewItemType(item))
					{
						arrayList.Add(item);
					}
				}
			}
		}
		return (Type[])arrayList.ToArray(typeof(Type));
	}

	private bool ShouldAddNewItemType(Type objItemType)
	{
		if (!objItemType.IsAbstract && base.Context != null)
		{
			if (base.Context.Instance is GoogleMapPolylineOverlay)
			{
				return objItemType == typeof(GoogleMapLocation);
			}
			return true;
		}
		return false;
	}

	protected override string GetDisplayText(object value)
	{
		return base.GetDisplayText(value);
	}
}
