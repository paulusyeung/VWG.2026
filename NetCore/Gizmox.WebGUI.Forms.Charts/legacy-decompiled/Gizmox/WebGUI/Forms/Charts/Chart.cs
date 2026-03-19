using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Xml;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Charts.Skins;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.Charts;

/// <summary>
/// Summary description for Chart
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(Chart), "Chart_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[MetadataTag("CT")]
[Skin(typeof(ChartSkin))]
public class Chart : Control, IGatewayControl, IChartData, IRequiresRegistration
{
	internal const string Prefix = "vc";

	internal const string Namespace = "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts";

	/// <summary>
	/// The AxisX property registration.
	/// </summary>
	private static readonly SerializableProperty mobjAxisXProperty = SerializableProperty.Register("mobjAxisX", typeof(AxisX), typeof(Chart));

	/// <summary>
	/// The string property registration.
	/// </summary>
	private static readonly SerializableProperty AnimationEnabledProperty = SerializableProperty.Register("AnimationEnabled", typeof(bool), typeof(Chart));

	/// <summary>
	/// The Title property registration.
	/// </summary>
	private static readonly SerializableProperty mobjTitleProperty = SerializableProperty.Register("mobjTitle", typeof(Title), typeof(Chart), new SerializablePropertyMetadata(null));

	/// <summary>
	/// The AxisY property registration.
	/// </summary>
	private static readonly SerializableProperty mobjAxisYProperty = SerializableProperty.Register("mobjAxisY", typeof(AxisY), typeof(Chart));

	/// <summary>
	/// The AnimationTypes property registration.
	/// </summary>
	private static readonly SerializableProperty AnimationEnabledInitializedProperty = SerializableProperty.Register("AnimationEnabledInitialized", typeof(bool), typeof(Chart), new SerializablePropertyMetadata(false));

	/// <summary>
	/// The AnimationTypes property registration.
	/// </summary>
	private static readonly SerializableProperty AnimationTypeProperty = SerializableProperty.Register("AnimationType", typeof(AnimationTypes), typeof(Chart), new SerializablePropertyMetadata(AnimationTypes.Type1));

	/// <summary>
	/// The string property registration.
	/// </summary>
	private static readonly SerializableProperty mstrView3DProperty = SerializableProperty.Register("mstrView3D", typeof(string), typeof(Chart));

	/// <summary>
	/// The ThemeTypes property registration.
	/// </summary>
	private static readonly SerializableProperty menmThemeProperty = SerializableProperty.Register("menmTheme", typeof(ThemeTypes), typeof(Chart), new SerializablePropertyMetadata(ThemeTypes.Theme1));

	/// <summary>
	/// The string property registration.
	/// </summary>
	private static readonly SerializableProperty mstrColorSetProperty = SerializableProperty.Register("mstrColorSet", typeof(string), typeof(Chart));

	/// <summary>
	/// The Data property registration.
	/// </summary>
	private static readonly SerializableProperty mobjDataProperty = SerializableProperty.Register("mobjData", typeof(Data), typeof(Chart));

	/// <summary>
	/// Gets or sets a value indicating whether [animation enabled].
	/// </summary>
	/// <value><c>true</c> if [animation enabled]; otherwise, <c>false</c>.</value>
	public new bool AnimationEnabled
	{
		get
		{
			return GetValue<bool>(AnimationEnabledProperty);
		}
		set
		{
			SetValue(AnimationEnabledProperty, value);
			if (!AnimationEnabledInitialized)
			{
				AnimationEnabledInitialized = true;
			}
		}
	}

	/// <summary>
	/// Gets or sets the type of the animation.
	/// </summary>
	/// <value>The type of the animation.</value>
	[Obsolete("AnimationTypes not supported anymore")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public AnimationTypes AnimationType
	{
		get
		{
			return GetValue<AnimationTypes>(AnimationTypeProperty);
		}
		set
		{
			SetValue(AnimationTypeProperty, value);
			if (!AnimationEnabledInitialized)
			{
				AnimationEnabled = true;
			}
		}
	}

	/// <summary>
	/// Gets or sets the axis X.
	/// </summary>
	/// <value>The axis X.</value>
	public AxisX AxisX
	{
		get
		{
			return mobjAxisX;
		}
		set
		{
			mobjAxisX = value;
		}
	}

	/// <summary>
	/// Gets or sets the axis Y.
	/// </summary>
	/// <value>The axis Y.</value>
	public AxisY AxisY
	{
		get
		{
			return mobjAxisY;
		}
		set
		{
			mobjAxisY = value;
		}
	}

	/// <summary>
	/// Gets or sets the color set.
	/// </summary>
	/// <value>The color set.</value>
	public string ColorSet
	{
		get
		{
			if (!string.IsNullOrEmpty(mstrColorSet) && !(mstrColorSet == "Undefined"))
			{
				return mstrColorSet;
			}
			return null;
		}
		set
		{
			mstrColorSet = value;
		}
	}

	/// <summary>
	/// Gets the data.
	/// </summary>
	/// <value>The data.</value>
	public Data Data => mobjData;

	/// <summary>
	/// Gets or sets the theme.
	/// </summary>
	/// <value>The theme.</value>
	public new ThemeTypes Theme
	{
		get
		{
			return menmTheme;
		}
		set
		{
			menmTheme = value;
		}
	}

	/// <summary>
	/// Gets or sets the title.
	/// </summary>
	/// <value>The title.</value>
	public Title Title
	{
		get
		{
			return mobjTitle;
		}
		set
		{
			mobjTitle = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether view3 D is on.
	/// </summary>
	/// <value><c>true</c> if [view3 D]; otherwise, <c>false</c>.</value>
	public bool View3D
	{
		get
		{
			if (!(mstrView3D == "Undefined") && !string.IsNullOrEmpty(mstrView3D))
			{
				return bool.Parse(mstrView3D);
			}
			return false;
		}
		set
		{
			mstrView3D = value.ToString();
		}
	}

	/// <summary>
	/// Gets or sets the type of the animation.
	/// </summary>
	/// <value>The type of the animation.</value>
	private bool AnimationEnabledInitialized
	{
		get
		{
			return GetValue<bool>(AnimationEnabledInitializedProperty);
		}
		set
		{
			SetValue(AnimationEnabledInitializedProperty, value);
		}
	}

	private AxisY mobjAxisY
	{
		get
		{
			return GetValue<AxisY>(mobjAxisYProperty);
		}
		set
		{
			SetValue(mobjAxisYProperty, value);
		}
	}

	private Data mobjData
	{
		get
		{
			return GetValue<Data>(mobjDataProperty);
		}
		set
		{
			SetValue(mobjDataProperty, value);
		}
	}

	private Title mobjTitle
	{
		get
		{
			return GetValue<Title>(mobjTitleProperty);
		}
		set
		{
			SetValue(mobjTitleProperty, value);
		}
	}

	private string mstrColorSet
	{
		get
		{
			return GetValue<string>(mstrColorSetProperty);
		}
		set
		{
			SetValue(mstrColorSetProperty, value);
		}
	}

	private ThemeTypes menmTheme
	{
		get
		{
			return GetValue<ThemeTypes>(menmThemeProperty);
		}
		set
		{
			SetValue(menmThemeProperty, value);
		}
	}

	private string mstrView3D
	{
		get
		{
			return GetValue<string>(mstrView3DProperty);
		}
		set
		{
			SetValue(mstrView3DProperty, value);
		}
	}

	private AxisX mobjAxisX
	{
		get
		{
			return GetValue<AxisX>(mobjAxisXProperty);
		}
		set
		{
			SetValue(mobjAxisXProperty, value);
		}
	}

	/// <summary>
	/// Gets the source.
	/// </summary>
	/// <value>The source.</value>
	/// Component.{@Id}..wgx
	private string Source => new GatewayReference(this, "VISIFire").ToString();

	public Chart(Title objTitle, AxisX objAxisX, AxisY objAxisY)
	{
		mobjTitle = objTitle;
		mobjAxisX = objAxisX;
		mobjAxisY = objAxisY;
		Init(null, null, null);
	}

	public Chart(AxisX objAxisX, AxisY objAxisY)
	{
		Init(null, objAxisX, objAxisY);
	}

	public Chart(Title objTitle)
	{
		Init(objTitle, null, null);
	}

	public Chart()
	{
		Init(null, null, null);
	}

	private void Init(Title objTitle, AxisX objAxisX, AxisY objAxisY)
	{
		mobjData = new Data(this);
	}

	protected override void FireEvent(IEvent objEvent)
	{
		if (objEvent.Type == "Click")
		{
			int result = -1;
			if (int.TryParse(objEvent.Member, out result))
			{
				IChartData chartData = null;
				switch (result)
				{
				case 1:
					chartData = Title;
					break;
				case 2:
					chartData = AxisX;
					break;
				case 3:
					chartData = AxisY;
					break;
				default:
				{
					int num = 3;
					foreach (DataSeries datum in Data)
					{
						if (string.IsNullOrEmpty(datum.Name))
						{
							num++;
							if (num == result)
							{
								chartData = datum;
								break;
							}
						}
						foreach (DataPoint item in datum)
						{
							num++;
							if (num == result)
							{
								chartData = item;
								break;
							}
						}
					}
					break;
				}
				}
				chartData?.FireClick();
			}
		}
		base.FireEvent(objEvent);
	}

	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (!criticalEventsData.HasEvent("CL"))
		{
			bool flag = false;
			foreach (DataSeries datum in Data)
			{
				foreach (DataPoint item in datum)
				{
					if (item.IsClickCritical)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				criticalEventsData.Set("CL");
			}
		}
		return criticalEventsData;
	}

	protected override void RenderAttributes(IContext context, IAttributeWriter writer)
	{
		writer.WriteAttributeString("SR", Source);
		base.RenderAttributes(context, writer);
	}

	IGatewayHandler IGatewayControl.GetGatewayHandler(IContext objContext, string strAction)
	{
		HostContext.Current.Response.ContentType = "text/xml";
		HostContext.Current.Response.Expires = -1;
		XmlTextWriter xmlTextWriter = new XmlTextWriter(HostContext.Current.Response.OutputStream, Encoding.UTF8);
		xmlTextWriter.Namespaces = true;
		int intLastID = 0;
		xmlTextWriter = GetChartDataXML(xmlTextWriter, ref intLastID);
		xmlTextWriter.Flush();
		return null;
	}

	/// <summary>
	///
	/// </summary>
	/// <remarks>
	/// Verified for Visifire: 1.0.0.11, 2.3.2.0
	/// </remarks>
	public XmlTextWriter GetChartDataXML(XmlTextWriter objWriter, ref int intLastID)
	{
		objWriter.WriteStartElement("vc", "Chart", "clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts");
		objWriter.WriteAttributeString("xmlns", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
		objWriter.WriteAttributeString("xmlns:x", "http://schemas.microsoft.com/winfx/2006/xaml");
		objWriter.WriteAttributeString("Width", base.Size.Width.ToString(CultureInfo.InvariantCulture));
		objWriter.WriteAttributeString("Height", base.Size.Height.ToString());
		objWriter.WriteAttributeString("Name", $"VWG_{ID.ToString(CultureInfo.InvariantCulture)}");
		objWriter.WriteAttributeString("Watermark", "False");
		_ = menmTheme;
		objWriter.WriteAttributeString("Theme", menmTheme.ToString());
		if (AnimationEnabled)
		{
			objWriter.WriteAttributeString("AnimationEnabled", AnimationEnabled.ToString());
		}
		if (View3D)
		{
			objWriter.WriteAttributeString("View3D", View3D.ToString());
		}
		if (ColorSet != null)
		{
			objWriter.WriteAttributeString("ColorSet", ColorSet);
		}
		if (mobjTitle != null)
		{
			objWriter = mobjTitle.GetChartDataXML(objWriter, ref intLastID);
		}
		if (mobjAxisX != null)
		{
			objWriter = mobjAxisX.GetChartDataXML(objWriter, ref intLastID);
		}
		if (mobjAxisY != null)
		{
			objWriter = mobjAxisY.GetChartDataXML(objWriter, ref intLastID);
		}
		objWriter = mobjData.GetChartDataXML(objWriter, ref intLastID);
		objWriter.WriteEndElement();
		return objWriter;
	}

	void IChartData.FireClick()
	{
	}
}
