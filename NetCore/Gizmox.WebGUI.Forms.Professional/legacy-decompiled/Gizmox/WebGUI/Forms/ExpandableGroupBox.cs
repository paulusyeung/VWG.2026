using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Summary description for ExpandableGroupBox
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(ExpandableGroupBox), "Professional.ExpandableGroupBox_45.png")]
[Skin(typeof(ExpandableGroupBoxSkin))]
public class ExpandableGroupBox : GroupBox, IRequiresRegistration, ISupportInitialize
{
	/// <summary>
	/// Horizontal text-image relation -- TextImageRelation analogue containing horizontal values only.
	/// </summary>
	public enum HorizontalTextImageRelation
	{
		/// <summary>
		/// Header image appears before title.
		/// </summary>
		ImageBeforeText = 4,
		/// <summary>
		/// Header title appears before image.
		/// </summary>
		TextBeforeImage = 8
	}

	private bool mblnExpanded = true;

	private bool mblnIsExpanding;

	private int mintHeaderHeight = -1;

	private int mintRestoredHeight = -1;

	/// <summary>
	/// The Collapse event registration.
	/// </summary>
	private static readonly SerializableEvent CollapseEvent;

	/// <summary>
	/// The Expand event registration.
	/// </summary>
	private static readonly SerializableEvent ExpandEvent;

	private static SerializableProperty IsTextImageSpreadProperty;

	private static SerializableProperty TextImageRelationProperty;

	/// <summary>
	/// Gets the hanlder for the Collapse event.
	/// </summary>
	private EventHandler CollapseHandler => (EventHandler)GetHandler(CollapseEvent);

	/// <summary>
	/// Gets the hanlder for the Expand event.
	/// </summary>
	private EventHandler ExpandHandler => (EventHandler)GetHandler(ExpandEvent);

	/// <summary>
	/// Gets the height of the header.
	/// </summary>
	/// <value>
	/// The height of the header.
	/// </value>
	private int HeaderHeight
	{
		get
		{
			if (mintHeaderHeight == -1 && SkinFactory.GetSkin(this) is ExpandableGroupBoxSkin expandableGroupBoxSkin)
			{
				mintHeaderHeight = expandableGroupBoxSkin.HeaderHeight;
			}
			return mintHeaderHeight;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ExpandableGroupBox" /> is expanded.
	/// </summary>
	/// <value>
	///   <c>true</c> if expanded; otherwise, <c>false</c>.
	/// </value>
	[DefaultValue(true)]
	public bool IsExpanded
	{
		get
		{
			return mblnExpanded;
		}
		set
		{
			SetIsExpanded(value, blnClientSource: false);
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether the header is spread.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if header is spread; otherwise, <c>false</c>.
	/// </value>
	[DefaultValue(false)]
	public bool IsTextImageSpread
	{
		get
		{
			return GetValue<bool>(IsTextImageSpreadProperty);
		}
		set
		{
			if (SetValue(IsTextImageSpreadProperty, value))
			{
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	/// <summary>
	/// Gets or sets the text image relation.
	/// </summary>
	/// <value>
	/// The text image relation.
	/// </value>
	[DefaultValue(HorizontalTextImageRelation.ImageBeforeText)]
	public HorizontalTextImageRelation TextImageRelation
	{
		get
		{
			return GetValue<HorizontalTextImageRelation>(TextImageRelationProperty);
		}
		set
		{
			if (SetValue(TextImageRelationProperty, value))
			{
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether tab stop is enabled.
	/// </summary>
	/// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
	[DefaultValue(true)]
	[Description("ControlTabStopDescr")]
	[Category("CatBehavior")]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
	/// </summary>
	/// <value>
	///   <c>true</c> if focusable; otherwise, <c>false</c>.
	/// </value>
	protected override bool Focusable => true;

	/// <summary>
	/// Occurs when [Collapseed].
	/// </summary>
	public event EventHandler Collapse
	{
		add
		{
			AddCriticalHandler(CollapseEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(CollapseEvent, value);
		}
	}

	/// <summary>
	/// Occurs when [expanded].
	/// </summary>
	public event EventHandler Expand
	{
		add
		{
			AddCriticalHandler(ExpandEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(ExpandEvent, value);
		}
	}

	/// <summary>
	/// Occurs when [client expand].
	/// </summary>
	[SRDescription("Occurs when control's tab expanded in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientIsExpandedChanged
	{
		add
		{
			AddClientHandler("Expand", value);
		}
		remove
		{
			RemoveClientHandler("Expand", value);
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ExpandableGroupBox" /> class.
	/// </summary>
	public ExpandableGroupBox()
	{
		SetStyle(ControlStyles.ContainerControl, blnValue: true);
		SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, blnValue: true);
		TabStop = true;
		CustomStyle = "X";
		mintRestoredHeight = base.Height;
	}

	/// <summary>
	/// Signals the object that initialization is starting.
	/// </summary>
	void ISupportInitialize.BeginInit()
	{
	}

	/// <summary>
	/// Signals the object that initialization is complete.
	/// </summary>
	void ISupportInitialize.EndInit()
	{
		if (!base.DesignMode)
		{
			ApplyHeight(blnClientSource: false);
		}
	}

	/// <summary>
	/// Fires an event.
	/// </summary>
	/// <param name="objEvent">event.</param>
	protected override void FireEvent(IEvent objEvent)
	{
		string type = objEvent.Type;
		if (type == "Expand")
		{
			bool result = false;
			if (bool.TryParse(objEvent["EX"], out result))
			{
				SetIsExpanded(result, blnClientSource: true);
			}
		}
		base.FireEvent(objEvent);
	}

	/// <summary>
	/// Called when [collapse].
	/// </summary>
	protected virtual void OnCollapse()
	{
		if (CollapseHandler != null)
		{
			CollapseHandler(this, EventArgs.Empty);
		}
	}

	/// <summary>
	/// Called when [expand].
	/// </summary>
	protected virtual void OnExpand()
	{
		if (ExpandHandler != null)
		{
			ExpandHandler(this, EventArgs.Empty);
		}
	}

	/// <summary>
	/// Gets the critical events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (ExpandHandler != null)
		{
			criticalEventsData.Set("EXP");
		}
		if (CollapseHandler != null)
		{
			criticalEventsData.Set("COL");
		}
		return criticalEventsData;
	}

	protected override CriticalEventsData GetCriticalClientEventsData()
	{
		CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
		if (HasClientHandler("Expand"))
		{
			criticalClientEventsData.Set("EXP");
			criticalClientEventsData.Set("COL");
		}
		return criticalClientEventsData;
	}

	/// <summary>
	/// Renders <see cref="T:Gizmox.WebGUI.Forms.ExpandableGroupBox" /> attributes.
	/// </summary>
	/// <param name="objContext">current context</param>
	/// <param name="objWriter">writer</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		RenderExpandedAttribute(objWriter, blnForceRender: false);
		RenderRestoredHeightAttribute(objWriter);
		RenderIsTextImageSpreadAttribute(objWriter, blnForceRender: false);
		RenderTextImageRelationAttribute(objWriter, blnForceRender: false);
	}

	/// <summary>
	/// Renders the text image relation.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [p].</param>
	private void RenderTextImageRelationAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		HorizontalTextImageRelation textImageRelation = TextImageRelation;
		if (textImageRelation != HorizontalTextImageRelation.ImageBeforeText || blnForceRender)
		{
			int num = (int)textImageRelation;
			objWriter.WriteAttributeString("TIR", num.ToString());
		}
	}

	/// <summary>
	/// Renders the header style.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderIsTextImageSpreadAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		bool isTextImageSpread = IsTextImageSpread;
		if (isTextImageSpread || blnForceRender)
		{
			objWriter.WriteAttributeString("HDS", isTextImageSpread ? "1" : "0");
		}
	}

	/// <summary>
	/// Renders the restored height attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	private void RenderRestoredHeightAttribute(IAttributeWriter objWriter)
	{
		objWriter.WriteAttributeString("RH", mintRestoredHeight.ToString());
	}

	/// <summary>
	/// Renders the expanded attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderExpandedAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		bool isExpanded = IsExpanded;
		if (!isExpanded || blnForceRender)
		{
			objWriter.WriteAttributeString("EX", isExpanded ? "1" : "0");
		}
	}

	/// <summary>
	/// An abstract param attribute rendering
	/// </summary>
	/// <param name="objContext">Request context.</param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
		{
			RenderExpandedAttribute(objWriter, blnForceRender: true);
			RenderRestoredHeightAttribute(objWriter);
			RenderIsTextImageSpreadAttribute(objWriter, blnForceRender: true);
			RenderTextImageRelationAttribute(objWriter, blnForceRender: true);
		}
	}

	/// <summary>
	/// Sets the specified bounds of the control to the specified location and size.
	/// </summary>
	/// <param name="intLeft">The int left.</param>
	/// <param name="intTop">The int top.</param>
	/// <param name="intWidth">Width of the int layout.</param>
	/// <param name="intHeight">Height of the int layout.</param>
	/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
	/// <returns></returns>
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
	public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
	{
		if (!base.DesignMode && (enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && !mblnIsExpanding)
		{
			if (!IsExpanded)
			{
				enmSpecified &= (BoundsSpecified)(-9);
			}
			mintRestoredHeight = intHeight;
			UpdateParams(AttributeType.Visual);
		}
		return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified);
	}

	/// <summary>
	/// Sets the IsExpanded.
	/// </summary>
	/// <param name="blnIsExpanded">if set to <c>true</c> [BLN is expanded].</param>
	/// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
	private bool SetIsExpanded(bool blnIsExpanded, bool blnClientSource)
	{
		bool flag = false;
		if (mblnExpanded != blnIsExpanded)
		{
			mblnExpanded = blnIsExpanded;
			if (!base.DesignMode && !base.IsLayoutSuspended)
			{
				ApplyHeight(blnClientSource);
				if (!blnClientSource)
				{
					UpdateParams(AttributeType.Visual);
					UpdateParams(AttributeType.Layout);
				}
			}
			flag = true;
		}
		if (flag || blnClientSource)
		{
			if (blnIsExpanded)
			{
				OnExpand();
			}
			else
			{
				OnCollapse();
			}
		}
		return flag;
	}

	/// <summary>
	/// Applies the height.
	/// </summary>
	/// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
	private void ApplyHeight(bool blnClientSource)
	{
		if (!blnClientSource)
		{
			UpdateParams(AttributeType.Visual);
		}
		mblnIsExpanding = true;
		int intHeight = (mblnExpanded ? mintRestoredHeight : HeaderHeight);
		if (SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height))
		{
			InvalidateParentLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
		}
		mblnIsExpanding = false;
	}

	static ExpandableGroupBox()
	{
		CollapseEvent = SerializableEvent.Register("Collapse", typeof(EventHandler), typeof(ExpandableGroupBox));
		ExpandEvent = SerializableEvent.Register("Expand", typeof(EventHandler), typeof(ExpandableGroupBox));
		IsTextImageSpreadProperty = SerializableProperty.Register("IsTextImageSpread", typeof(bool), typeof(ExpandableGroupBox), new SerializablePropertyMetadata(false));
		TextImageRelationProperty = SerializableProperty.Register("TextImageRelation", typeof(HorizontalTextImageRelation), typeof(ExpandableGroupBox), new SerializablePropertyMetadata(HorizontalTextImageRelation.ImageBeforeText));
	}
}
