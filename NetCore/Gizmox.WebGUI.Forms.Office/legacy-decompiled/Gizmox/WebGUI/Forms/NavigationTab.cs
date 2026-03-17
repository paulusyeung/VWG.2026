using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(false)]
[ToolboxBitmap(typeof(NavigationTabs), "Gizmox.WebGUI.Forms.NavigationTabs.bmp")]
[Skin(typeof(NavigationTabSkin))]
public class NavigationTab : TabPage
{
	private static readonly SerializableProperty ExtraProperty = SerializableProperty.Register("Extra", typeof(bool), typeof(NavigationTab), new SerializablePropertyMetadata(false));

	public NavigationTabs NavigationTabs => (NavigationTabs)base.Parent;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Label property is obsolete use Text instead")]
	public string Label
	{
		get
		{
			return Text;
		}
		set
		{
			Text = value;
		}
	}

	public bool Extra
	{
		get
		{
			return GetValue<bool>(ExtraProperty);
		}
		set
		{
			SetExtraProperty(value, blnIsClientInvokation: false);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override ContextualTabGroup ContextualTabGroup
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public NavigationTab()
	{
		base.Appearance = TabAppearance.Navigation;
	}

	public NavigationTab(string strText)
		: base(strText)
	{
	}

	public NavigationTab(string strIcon, string strText)
		: this(strText)
	{
		base.Image = new IconResourceHandle(strIcon);
	}

	public NavigationTab(string strIcon, string strText, Control objControl)
		: this(strIcon, strText)
	{
		base.Controls.Clear();
		objControl.Dock = DockStyle.Fill;
		base.Controls.Add(objControl);
	}

	public NavigationTab(string strIcon, string strText, bool blnExtra, Control objControl)
		: this(strIcon, strText, objControl)
	{
		if (blnExtra)
		{
			SetValue(ExtraProperty, objValue: true);
		}
	}

	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		RenderExtraAttribute(objWriter, blnForceRender: false);
		base.RenderAttributes(objContext, objWriter);
	}

	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
		{
			RenderExtraAttribute(objWriter, blnForceRender: true);
		}
	}

	private void RenderExtraAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		bool extra = Extra;
		if (extra || blnForceRender)
		{
			objWriter.WriteAttributeString("EXT", extra ? "1" : "0");
		}
	}

	protected override void FireEvent(IEvent objEvent)
	{
		string type = objEvent.Type;
		if (type == "EXT")
		{
			SetExtraProperty(objEvent["value"] != "0", blnIsClientInvokation: true);
		}
		else
		{
			base.FireEvent(objEvent);
		}
	}

	private void SetExtraProperty(bool blnValue, bool blnIsClientInvokation)
	{
		if (SetValue(ExtraProperty, blnValue) && !blnIsClientInvokation)
		{
			UpdateParams(AttributeType.Visual);
			base.TabControl?.Update(blnRedrawOnly: true);
		}
	}

	private void ResetExtra()
	{
		Extra = false;
	}
}
