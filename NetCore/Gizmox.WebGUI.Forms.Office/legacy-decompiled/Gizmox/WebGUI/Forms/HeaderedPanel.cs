using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[Skin(typeof(HeaderedPanelSkin))]
[ToolboxBitmap(typeof(HeaderedPanel), "Office.HeaderedPanel_45.png")]
public class HeaderedPanel : Panel, IRequiresRegistration
{
	private static readonly SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(HeaderedPanel));

	private static readonly SerializableProperty HeaderInternalProperty = SerializableProperty.Register("Header", typeof(Control), typeof(HeaderedPanel));

	private Control HeaderInternal
	{
		get
		{
			return GetValue<Control>(HeaderInternalProperty);
		}
		set
		{
			SetValue(HeaderInternalProperty, value);
		}
	}

	protected override PaddingValue ContainedAreaOffset
	{
		get
		{
			PaddingValue containedAreaOffset = base.ContainedAreaOffset;
			HeaderedPanelSkin headeredPanelSkin = SkinFactory.GetSkin(this) as HeaderedPanelSkin;
			containedAreaOffset.Top += headeredPanelSkin.TopFrameHeight;
			return containedAreaOffset;
		}
	}

	[DefaultValue(null)]
	[ProxyBrowsable(true)]
	public ResourceHandle Icon
	{
		get
		{
			return GetValue<ResourceHandle>(IconProperty);
		}
		set
		{
			if (Icon != value)
			{
				SetValue(IconProperty, value);
				Update();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Control Header
	{
		get
		{
			return HeaderInternal;
		}
		set
		{
			Control headerInternal = HeaderInternal;
			if (headerInternal == value)
			{
				return;
			}
			EventHandler value2 = DetachHeader;
			if (headerInternal != null)
			{
				headerInternal.Disposed -= value2;
				headerInternal.InternalParent = null;
				UnRegisterComponent(headerInternal);
			}
			HeaderInternal = value;
			if (value != null)
			{
				value.Disposed += value2;
				if (value.Parent != null)
				{
					value.Parent.Controls.Remove(HeaderInternal);
				}
				if (!value.IsRegistered)
				{
					RegisterComponent(value);
				}
				value.AssignParent(this);
			}
			Update();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Control header = Header;
			if (header != null)
			{
				header.Disposed -= DetachHeader;
			}
		}
		base.Dispose(disposing);
	}

	public HeaderedPanel()
	{
		CustomStyle = "HeaderedPanel";
	}

	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		if (GetProxyPropertyValue("Icon", Icon) != null)
		{
			objWriter.WriteAttributeString("I", Icon.ToString());
		}
	}

	protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
	{
		if (HeaderInternal != null)
		{
			if (IsDirty(lngRequestID))
			{
				objWriter.WriteStartElement("HDR");
				objWriter.WriteAttributeString("W", HeaderInternal.Width.ToString());
				objWriter.WriteAttributeString("H", HeaderInternal.Height.ToString());
				((IRenderableComponent)HeaderInternal).RenderComponent(objContext, objWriter, lngRequestID);
				objWriter.WriteEndElement();
			}
			else
			{
				((IRenderableComponent)HeaderInternal).RenderComponent(objContext, objWriter, lngRequestID);
			}
		}
		base.RenderControls(objContext, objWriter, lngRequestID);
	}

	private void DetachHeader(object sender, EventArgs e)
	{
		Header = null;
	}

	protected override void OnRegisterComponents()
	{
		base.OnRegisterComponents();
		if (HeaderInternal != null)
		{
			RegisterComponent(HeaderInternal);
		}
	}

	protected override void OnUnregisterComponents()
	{
		base.OnUnregisterComponents();
		if (HeaderInternal != null)
		{
			UnRegisterComponent(HeaderInternal);
		}
	}
}
