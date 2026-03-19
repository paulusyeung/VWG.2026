using System;
using System.Collections;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms.Google;

public class GoogleLayerCollectionEditor : Gizmox.WebGUI.Forms.Design.CollectionEditor
{
	public GoogleLayerCollectionEditor()
		: base(typeof(GoogleMapLayerCollection))
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
				foreach (Type item in GoogleDesignTypeFilter.FilterGenericTypes(typeDiscoveryService.GetTypes(typeof(GoogleMapLayer), excludeGlobalTypes: false)))
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

	protected override object CreateInstance(Type itemType)
	{
		return base.CreateInstance(itemType);
	}

	private bool ShouldAddNewItemType(Type objItemType)
	{
		if (!objItemType.IsAbstract && base.Context != null)
		{
			return true;
		}
		return false;
	}

	protected override string GetDisplayText(object value)
	{
		if (value is GoogleMapLayer { LayerType: var layerType })
		{
			return layerType.ToString();
		}
		return base.GetDisplayText(value);
	}
}
