using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Threading;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.ZedGraph;
using Gizmox.WebGUI.Hosting;
using ZedGraph;

namespace Gizmox.WebGUI.Forms.Professional;

/// <summary>
///
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(ZedGraphControl), "ZedGraph.ZedGraphControl_45.png")]
[MetadataTag("ZedGraphControl")]
[Skin(typeof(ZedGraphControlSkin))]
public class ZedGraphControl : Control, IRequiresRegistration
{
	/// <summary>
	///
	/// </summary>
	public enum ContextMenuObjectState
	{
		/// <summary>
		///
		/// </summary>
		InactiveSelection,
		/// <summary>
		///
		/// </summary>
		ActiveSelection,
		/// <summary>
		///
		/// </summary>
		Background
	}

	public delegate void ContextMenuBuilderEventHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ContextMenuObjectState objState);

	public delegate string CursorValueHandler(ZedGraphControl sender, GraphPane pane, Point mousePt);

	public delegate bool LinkEventHandler(ZedGraphControl sender, GraphPane pane, object source, Link link, int index);

	public delegate string PointEditHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

	public delegate string PointValueHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

	public delegate void ScrollDoneHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

	public delegate void ScrollProgressHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

	public delegate bool ZedMouseEventHandler(ZedGraphControl sender, MouseEventArgs e);

	public delegate void ZoomEventHandler(ZedGraphControl sender, ZoomState oldState, ZoomState newState);

	/// <summary>
	///
	/// </summary>
	[Serializable]
	private class ZedGraphToolTipForm : Form
	{
		private Label mobjTextLabel;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Professional.ZedGraphControl.ZedGraphToolTipForm" /> class.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		public ZedGraphToolTipForm(string strText)
			: this()
		{
			mobjTextLabel.Text = strText;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Professional.ZedGraphControl.ZedGraphToolTipForm" /> class.
		/// </summary>
		public ZedGraphToolTipForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			mobjTextLabel = new Label();
			SuspendLayout();
			mobjTextLabel.Dock = DockStyle.Fill;
			mobjTextLabel.Name = "mobjTextLabel";
			mobjTextLabel.TabIndex = 0;
			base.Controls.Add(mobjTextLabel);
			BackColor = Color.FromArgb(255, 255, 225);
			BorderStyle = BorderStyle.FixedSingle;
			BorderColor = Color.Black;
			base.DockPadding.All = 0;
			base.Size = new Size(50, 17);
			ResumeLayout(blnPerformLayout: false);
		}
	}

	private MasterPane mobjMasterPane;

	private bool mblnIsShowPointValues;

	private int mintToolTipSuspension = 500;

	private ContextMenuStrip mobjContextMenuStrip;

	private PrintDocument mobjPrintDocument;

	private bool mblnIsPrintScaleAll = true;

	private bool mblnIsPrintFillPage = true;

	private bool mblnIsPrintKeepAspectRatio = true;

	private Point mobjContextMenuLocation = Point.Empty;

	private bool mblnIsSynchronizeYAxes;

	private bool mblnIsSynchronizeXAxes;

	private bool mblnIsEnableVZoom = true;

	private bool mblnIsEnableWheelZoom = true;

	private bool mblnIsEnableHZoom = true;

	private bool mblnMasterPaneSizeInitialized;

	private bool mblnIsZoomOnMouseCenter;

	private double mdblZoomStepFraction = 0.1;

	private int mintWheelZoomSuspension = 250;

	/// <summary>
	/// The PointValueEvent event registration.
	/// </summary>
	private static readonly SerializableEvent PointValueEventEvent;

	/// <summary>
	/// The ContextMenuBuilderEvent event registration.
	/// </summary>
	private static readonly SerializableEvent ContextMenuBuilderEvent;

	/// <summary>
	/// The ZoomEventEvent event registration.
	/// </summary>
	private static readonly SerializableEvent ZoomEventEvent;

	[CompilerGenerated]
	private ZedMouseEventHandler m_MouseDownEvent;

	[CompilerGenerated]
	private ZedMouseEventHandler m_MouseMoveEvent;

	[CompilerGenerated]
	private ZedMouseEventHandler m_MouseUpEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool BeenDisposed => false;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons EditButtons
	{
		get
		{
			return MouseButtons.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys EditModifierKeys
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the graph pane.
	/// </summary>
	/// <value>The graph pane.</value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	[Browsable(false)]
	public GraphPane GraphPane
	{
		get
		{
			if (mobjMasterPane != null && ((List<GraphPane>)(object)mobjMasterPane.PaneList).Count > 0)
			{
				return mobjMasterPane[0];
			}
			return null;
		}
		set
		{
			if (mobjMasterPane != null)
			{
				((List<GraphPane>)(object)mobjMasterPane.PaneList).Clear();
				mobjMasterPane.Add(value);
			}
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsAntiAlias
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsAutoScrollRange
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsEnableHEdit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsEnableHPan
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is enable H zoom.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is enable H zoom; otherwise, <c>false</c>.
	/// </value>
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("true to allow horizontal zooming by left-click-drag")]
	[Category("Display")]
	[DefaultValue(true)]
	public bool IsEnableHZoom
	{
		get
		{
			return mblnIsEnableHZoom;
		}
		set
		{
			if (mblnIsEnableHZoom != value)
			{
				mblnIsEnableHZoom = value;
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsEnableSelection
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsEnableVEdit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsEnableVPan
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is enable V zoom.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is enable V zoom; otherwise, <c>false</c>.
	/// </value>
	[DefaultValue(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[Description("true to allow vertical zooming by left-click-drag")]
	public bool IsEnableVZoom
	{
		get
		{
			return mblnIsEnableVZoom;
		}
		set
		{
			if (mblnIsEnableVZoom != value)
			{
				mblnIsEnableVZoom = value;
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is enable wheel zoom.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is enable wheel zoom; otherwise, <c>false</c>.
	/// </value>
	[DefaultValue(true)]
	[Description("true to allow zooming with the mouse wheel")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Category("Display")]
	public bool IsEnableWheelZoom
	{
		get
		{
			return mblnIsEnableWheelZoom;
		}
		set
		{
			if (mblnIsEnableWheelZoom != value)
			{
				UpdateParams(AttributeType.Visual);
				mblnIsEnableWheelZoom = value;
			}
		}
	}

	/// <summary>
	/// Sets a value indicating whether this instance is enable zoom.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is enable zoom; otherwise, <c>false</c>.
	/// </value>
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[Category("Display")]
	[DefaultValue(true)]
	[Description("true to allow horizontal and vertical zooming by left-click-drag")]
	public bool IsEnableZoom
	{
		set
		{
			mblnIsEnableHZoom = value;
			mblnIsEnableVZoom = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is print fill page.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is print fill page; otherwise, <c>false</c>.
	/// </value>
	[Category("Display")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Description("true to resize to fill the page when printing")]
	public bool IsPrintFillPage
	{
		get
		{
			return mblnIsPrintFillPage;
		}
		set
		{
			mblnIsPrintFillPage = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is print keep aspect ratio.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is print keep aspect ratio; otherwise, <c>false</c>.
	/// </value>
	[NotifyParentProperty(true)]
	[Description("true to preserve the displayed aspect ratio when printing")]
	[Category("Display")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool IsPrintKeepAspectRatio
	{
		get
		{
			return mblnIsPrintKeepAspectRatio;
		}
		set
		{
			mblnIsPrintKeepAspectRatio = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is print scale all.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is print scale all; otherwise, <c>false</c>.
	/// </value>
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Description("true to force font and pen width scaling when printing")]
	public bool IsPrintScaleAll
	{
		get
		{
			return mblnIsPrintScaleAll;
		}
		set
		{
			mblnIsPrintScaleAll = value;
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsScrolling => false;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsScrollY2
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is show context menu.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is show context menu; otherwise, <c>false</c>.
	/// </value>
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsShowContextMenu
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsShowCopyMessage
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsShowCursorValues
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsShowHScrollBar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is show point values.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is show point values; otherwise, <c>false</c>.
	/// </value>
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	[Description("true to display tooltips when the mouse hovers over data points")]
	public bool IsShowPointValues
	{
		get
		{
			return mblnIsShowPointValues;
		}
		set
		{
			if (mblnIsShowPointValues != value)
			{
				mblnIsShowPointValues = value;
				UpdateParams(AttributeType.ToolTip);
			}
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsShowVScrollBar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is synchronize X axes.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is synchronize X axes; otherwise, <c>false</c>.
	/// </value>
	[Category("Display")]
	[Bindable(true)]
	[Description("true to force the X axis ranges for all GraphPanes to match")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	public bool IsSynchronizeXAxes
	{
		get
		{
			return mblnIsSynchronizeXAxes;
		}
		set
		{
			if (mblnIsSynchronizeXAxes != value)
			{
				ZoomStatePurge();
			}
			mblnIsSynchronizeXAxes = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is synchronize Y axes.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is synchronize Y axes; otherwise, <c>false</c>.
	/// </value>
	[Bindable(true)]
	[Description("true to force the Y axis ranges for all GraphPanes to match")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	public bool IsSynchronizeYAxes
	{
		get
		{
			return mblnIsSynchronizeYAxes;
		}
		set
		{
			if (mblnIsSynchronizeYAxes != value)
			{
				ZoomStatePurge();
			}
			mblnIsSynchronizeYAxes = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this instance is zoom on mouse center.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if this instance is zoom on mouse center; otherwise, <c>false</c>.
	/// </value>
	[Description("true to center the mouse wheel zoom at the current mouse location")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[DefaultValue(false)]
	[Category("Display")]
	public bool IsZoomOnMouseCenter
	{
		get
		{
			return mblnIsZoomOnMouseCenter;
		}
		set
		{
			mblnIsZoomOnMouseCenter = value;
		}
	}

	/// <summary>
	/// Gets or sets the link buttons.
	/// </summary>
	/// <value>The link buttons.</value>
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons LinkButtons
	{
		get
		{
			return MouseButtons.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys LinkModifierKeys
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the master pane.
	/// </summary>
	/// <value>The master pane.</value>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public MasterPane MasterPane
	{
		get
		{
			return mobjMasterPane;
		}
		set
		{
			if (mobjMasterPane != value)
			{
				mobjMasterPane = value;
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons PanButtons
	{
		get
		{
			return MouseButtons.Left;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override bool IsEventsEnabled => true;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons PanButtons2
	{
		get
		{
			return MouseButtons.Left;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys PanModifierKeys
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys PanModifierKeys2
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the point date format.
	/// </summary>
	/// <value>The point date format.</value>
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string PointDateFormat
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the point value format.
	/// </summary>
	/// <value>The point value format.</value>
	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string PointValueFormat
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the print document.
	/// </summary>
	/// <value>The print document.</value>
	[Localizable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PrintDocument PrintDocument
	{
		get
		{
			if (mobjPrintDocument == null)
			{
				mobjPrintDocument = new PrintDocument();
				mobjPrintDocument.PrintPage += Graph_PrintPage;
			}
			return mobjPrintDocument;
		}
		set
		{
			mobjPrintDocument = value;
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SaveFileDialog SaveFileDialog
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollGrace
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMaxX
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMaxY
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMaxY2
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMinX
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMinY
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ScrollMinY2
	{
		get
		{
			return 0.0;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys SelectAppendModifierKeys => Keys.None;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons SelectButtons
	{
		get
		{
			return MouseButtons.None;
		}
		set
		{
		}
	}

	public Selection Selection => null;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys SelectModifierKeys
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ScrollRangeList Y2ScrollRangeList => null;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ScrollRangeList YScrollRangeList => null;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons ZoomButtons
	{
		get
		{
			return MouseButtons.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MouseButtons ZoomButtons2
	{
		get
		{
			return MouseButtons.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys ZoomModifierKeys
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Keys ZoomModifierKeys2
	{
		get
		{
			return Keys.None;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets the zoom step fraction.
	/// </summary>
	/// <value>
	/// The zoom step fraction.
	/// </value>
	[Description("Sets the step size fraction for zooming with the mouse wheel")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(0.1)]
	public double ZoomStepFraction
	{
		get
		{
			return mdblZoomStepFraction;
		}
		set
		{
			mdblZoomStepFraction = value;
		}
	}

	/// <summary>
	/// Gets or sets the tool tip suspension.
	/// </summary>
	/// <value>The tool tip suspension.</value>
	public int ToolTipSuspension
	{
		get
		{
			return mintToolTipSuspension;
		}
		set
		{
			if (mintToolTipSuspension != value)
			{
				mintToolTipSuspension = value;
				UpdateParams(AttributeType.ToolTip);
			}
		}
	}

	/// <summary>
	/// Gets or sets the wheel zoom suspension.
	/// </summary>
	/// <value>
	/// The wheel zoom suspension.
	/// </value>
	[DefaultValue(250)]
	public int WheelZoomSuspension
	{
		get
		{
			return mintWheelZoomSuspension;
		}
		set
		{
			if (mintWheelZoomSuspension != value)
			{
				mintWheelZoomSuspension = value;
				UpdateParams(AttributeType.Visual);
			}
		}
	}

	/// <summary>
	/// Gets the point value event handler.
	/// </summary>
	/// <value>The point value event handler.</value>
	private PointValueHandler PointValueEventHandler => (PointValueHandler)GetHandler(PointValueEventEvent);

	/// <summary>
	/// Gets the context menu builder handler.
	/// </summary>
	/// <value>The context menu builder handler.</value>
	private ContextMenuBuilderEventHandler ContextMenuBuilderHandler => (ContextMenuBuilderEventHandler)GetHandler(ContextMenuBuilderEvent);

	/// <summary>
	/// Gets the zoom event event handler.
	/// </summary>
	/// <value>The zoom event event handler.</value>
	private ZoomEventHandler ZoomEventEventHandler => (ZoomEventHandler)GetHandler(ZoomEventEvent);

	/// <summary>
	/// Occurs when [point value event].
	/// </summary>
	[Description("Subscribe to this event to provide custom-formatting for data point tooltips")]
	[Category("Events")]
	[Bindable(true)]
	public event PointValueHandler PointValueEvent
	{
		add
		{
			AddHandler(PointValueEventEvent, value);
		}
		remove
		{
			RemoveHandler(PointValueEventEvent, value);
		}
	}

	/// <summary>
	/// Occurs when [context menu builder].
	/// </summary>
	[Description("Subscribe to this event to be able to modify the ZedGraph context menu")]
	[Bindable(true)]
	[Category("Events")]
	public event ContextMenuBuilderEventHandler ContextMenuBuilder
	{
		add
		{
			AddHandler(ContextMenuBuilderEvent, value);
		}
		remove
		{
			RemoveHandler(ContextMenuBuilderEvent, value);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event CursorValueHandler CursorValueEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event ZedMouseEventHandler DoubleClickEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event LinkEventHandler LinkEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event MouseEventHandler MouseDown;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event ZedMouseEventHandler MouseDownEvent
	{
		add
		{
			m_MouseDownEvent = (ZedMouseEventHandler)Delegate.Combine(m_MouseDownEvent, value);
		}
		remove
		{
			m_MouseDownEvent = (ZedMouseEventHandler)Delegate.Remove(m_MouseDownEvent, value);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	private new event MouseEventHandler MouseMove;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event ZedMouseEventHandler MouseMoveEvent
	{
		add
		{
			m_MouseMoveEvent = (ZedMouseEventHandler)Delegate.Combine(m_MouseMoveEvent, value);
		}
		remove
		{
			m_MouseMoveEvent = (ZedMouseEventHandler)Delegate.Remove(m_MouseMoveEvent, value);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event MouseEventHandler MouseUp;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event ZedMouseEventHandler MouseUpEvent
	{
		add
		{
			m_MouseUpEvent = (ZedMouseEventHandler)Delegate.Combine(m_MouseUpEvent, value);
		}
		remove
		{
			m_MouseUpEvent = (ZedMouseEventHandler)Delegate.Remove(m_MouseUpEvent, value);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event PointEditHandler PointEditEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event ScrollDoneHandler ScrollDoneEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event ScrollEventHandler ScrollEvent;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public event ScrollProgressHandler ScrollProgressEvent;

	[Description("Subscribe to this event to be notified when the graph is zoomed or panned")]
	[Bindable(true)]
	[Category("Events")]
	public event ZoomEventHandler ZoomEvent
	{
		add
		{
			AddHandler(ZoomEventEvent, value);
		}
		remove
		{
			RemoveHandler(ZoomEventEvent, value);
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Professional.ZedGraphControl" /> class.
	/// </summary>
	public ZedGraphControl()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		InitializeComponent();
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, blnValue: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, blnValue: true);
		Rectangle rectangle = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
		mobjMasterPane = new MasterPane("", (RectangleF)rectangle);
		((PaneBase)mobjMasterPane).Margin.All = 0f;
		((PaneBase)mobjMasterPane).Title.IsVisible = false;
		string text = "Title";
		string text2 = "X Axis";
		string text3 = "Y Axis";
		GraphPane val = new GraphPane((RectangleF)rectangle, text, text2, text3);
		val.AxisChange();
		mobjMasterPane.Add(val);
	}

	private bool ShouldSerializePrintDocument()
	{
		return false;
	}

	/// <summary>
	/// Draws the control.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objGraphics">The graphics.</param>
	protected override void DrawControl(ControlRenderingContext objContext, Graphics objGraphics)
	{
		using Image image = GetImage();
		objGraphics.DrawImage(image, new Point(0, 0));
	}

	/// <summary>
	/// An abstract param attribute rendering
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
		{
			RenderToolTipSuspension(objWriter, blnForceRender: true);
			RenderIsShowPointValues(objWriter, blnForceRender: true);
		}
		if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
		{
			RenderSourceAttribute(objWriter);
		}
		if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
		{
			RenderWheelZoom(objWriter, blnForceRender: true);
		}
	}

	/// <summary>
	/// Renders the source attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	private void RenderSourceAttribute(IAttributeWriter objWriter)
	{
		if (mblnMasterPaneSizeInitialized)
		{
			objWriter.WriteAttributeString("SR", new GatewayReference(this, "ZedGraphImage").ToString());
		}
	}

	/// <summary>
	/// Renders the tool tip suspension.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderToolTipSuspension(IAttributeWriter objWriter, bool blnForceRender)
	{
		int toolTipSuspension = ToolTipSuspension;
		if (toolTipSuspension != 500 || blnForceRender)
		{
			objWriter.WriteAttributeString("TM", toolTipSuspension.ToString());
		}
	}

	/// <summary>
	/// Renders allow wheel zoom.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderWheelZoom(IAttributeWriter objWriter, bool blnForceRender)
	{
		bool flag = (IsEnableVZoom || IsEnableHZoom) && IsEnableWheelZoom && MasterPane != null;
		if (!flag || blnForceRender)
		{
			objWriter.WriteAttributeString("WZ", flag ? "1" : "0");
		}
		if (flag)
		{
			RenderWheelZoomSuspension(objWriter, blnForceRender);
		}
	}

	/// <summary>
	/// Renders the wheel zoom suspension.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderWheelZoomSuspension(IAttributeWriter objWriter, bool blnForceRender)
	{
		int wheelZoomSuspension = WheelZoomSuspension;
		if (wheelZoomSuspension != 250 || blnForceRender)
		{
			objWriter.WriteAttributeString("WN", wheelZoomSuspension.ToString());
		}
	}

	/// <summary>
	/// Renders the is show point values.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderIsShowPointValues(IAttributeWriter objWriter, bool blnForceRender)
	{
		bool isShowPointValues = IsShowPointValues;
		if (isShowPointValues || blnForceRender)
		{
			objWriter.WriteAttributeString("STT", isShowPointValues ? "1" : "0");
		}
	}

	/// <summary>
	/// Renders the controls meta attributes
	/// </summary>
	/// <param name="objContext">The obj context.</param>
	/// <param name="objWriter">The obj writer.</param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		RenderToolTipSuspension(objWriter, blnForceRender: false);
		RenderWheelZoom(objWriter, blnForceRender: false);
		RenderIsShowPointValues(objWriter, blnForceRender: false);
		RenderSourceAttribute(objWriter);
	}

	/// <summary>
	/// Processes the gateway request.
	/// </summary>
	/// <param name="objHostContext">The host context.</param>
	/// <param name="strAction">The action.</param>
	/// <returns></returns>
	protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
	{
		if (strAction == "ZedGraphImage")
		{
			Image image = GetImage();
			if (image != null)
			{
				objHostContext.Response.ContentType = "image/jpeg";
				image.Save(objHostContext.Response.OutputStream, ImageFormat.Jpeg);
				return null;
			}
		}
		return base.ProcessGatewayRequest(objHostContext, strAction);
	}

	/// <summary>
	/// Fires an event.
	/// </summary>
	/// <param name="objEvent">event.</param>
	protected override void FireEvent(IEvent objEvent)
	{
		base.FireEvent(objEvent);
		switch (objEvent.Type)
		{
		case "MouseWheel":
		{
			int result = 0;
			if (int.TryParse(objEvent["VLB"], out result))
			{
				int eventValue7 = GetEventValue(objEvent, "RX", -1);
				int eventValue8 = GetEventValue(objEvent, "RY", -1);
				OnMouseWheel(result, eventValue7, eventValue8);
			}
			break;
		}
		case "MouseMove":
		{
			int eventValue3 = GetEventValue(objEvent, "RX", -1);
			int eventValue4 = GetEventValue(objEvent, "RY", -1);
			int eventValue5 = GetEventValue(objEvent, "X", -1);
			int eventValue6 = GetEventValue(objEvent, "Y", -1);
			if (eventValue3 >= 0 && eventValue4 >= 0 && eventValue5 >= 0 && eventValue6 >= 0)
			{
				HandleSuspendedMouseOver(eventValue3, eventValue4, eventValue5, eventValue6);
			}
			break;
		}
		case "InitializeImageMeasurements":
		{
			int eventValue = GetEventValue(objEvent, "W", 0);
			int eventValue2 = GetEventValue(objEvent, "H", 0);
			if (eventValue > 0 && eventValue2 > 0)
			{
				InitializeMasterPaneSize(eventValue, eventValue2);
			}
			break;
		}
		}
	}

	/// <summary>
	/// Called when [mouse wheel].
	/// </summary>
	/// <param name="intDelta">The wheel delta.</param>
	/// <param name="intX">The int X.</param>
	/// <param name="intY">The int Y.</param>
	private void OnMouseWheel(int intDelta, int intX, int intY)
	{
		if ((IsEnableVZoom || IsEnableHZoom) && IsEnableWheelZoom && MasterPane != null)
		{
			GraphPane val = MasterPane.FindChartRect(new PointF(intX, intY));
			if (val != null && intDelta != 0)
			{
				PointF centerPt = new PointF(intX, intY);
				double zoomFraction = 1.0 + (double)intDelta * ZoomStepFraction;
				ZoomPane(val, zoomFraction, centerPt, IsZoomOnMouseCenter, isRefresh: false);
				Refresh();
			}
		}
	}

	/// <summary>
	/// Refreshes this instance.
	/// </summary>
	[Obsolete("Overrides legacy obsolete Refresh for compatibility.")]
	public override void Refresh()
	{
		Update();
	}

	/// <summary>
	/// Handles the PrintPage event of the Graph control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.Drawing.Printing.PrintPageEventArgs" /> instance containing the event data.</param>
	private void Graph_PrintPage(object sender, PrintPageEventArgs e)
	{
		MasterPane masterPane = MasterPane;
		bool[] array = new bool[((List<GraphPane>)(object)masterPane.PaneList).Count + 1];
		bool[] array2 = new bool[((List<GraphPane>)(object)masterPane.PaneList).Count + 1];
		array[0] = ((PaneBase)masterPane).IsPenWidthScaled;
		array2[0] = ((PaneBase)masterPane).IsFontsScaled;
		for (int i = 0; i < ((List<GraphPane>)(object)masterPane.PaneList).Count; i++)
		{
			array[i + 1] = ((PaneBase)masterPane[i]).IsPenWidthScaled;
			array2[i + 1] = ((PaneBase)masterPane[i]).IsFontsScaled;
			if (mblnIsPrintScaleAll)
			{
				((PaneBase)masterPane[i]).IsPenWidthScaled = true;
				((PaneBase)masterPane[i]).IsFontsScaled = true;
			}
		}
		RectangleF rect = ((PaneBase)masterPane).Rect;
		SizeF sizeF = ((PaneBase)masterPane).Rect.Size;
		if (mblnIsPrintFillPage && mblnIsPrintKeepAspectRatio)
		{
			float val = (float)e.MarginBounds.Width / sizeF.Width;
			float val2 = (float)e.MarginBounds.Height / sizeF.Height;
			float num = Math.Min(val, val2);
			sizeF.Width *= num;
			sizeF.Height *= num;
		}
		else if (mblnIsPrintFillPage)
		{
			sizeF = e.MarginBounds.Size;
		}
		((PaneBase)masterPane).ReSize(e.Graphics, new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, sizeF.Width, sizeF.Height));
		((PaneBase)masterPane).Draw(e.Graphics);
		using (Graphics graphics = e.Graphics)
		{
			((PaneBase)masterPane).ReSize(graphics, rect);
		}
		((PaneBase)masterPane).IsPenWidthScaled = array[0];
		((PaneBase)masterPane).IsFontsScaled = array2[0];
		for (int j = 0; j < ((List<GraphPane>)(object)masterPane.PaneList).Count; j++)
		{
			((PaneBase)masterPane[j]).IsPenWidthScaled = array[j + 1];
			((PaneBase)masterPane[j]).IsFontsScaled = array2[j + 1];
		}
	}

	/// <summary>
	/// Handles the suspended mouse over.
	/// </summary>
	/// <param name="intRelativeX">The relative X.</param>
	/// <param name="intRelativeY">The relative Y.</param>
	/// <param name="intAbsoluteX">The absolute X.</param>
	/// <param name="intAbsoluteY">The absolute Y.</param>
	private void HandleSuspendedMouseOver(int intRelativeX, int intRelativeY, int intAbsoluteX, int intAbsoluteY)
	{
		if (intRelativeX < 0 || intRelativeY < 0 || mobjMasterPane == null)
		{
			return;
		}
		Form form = Form;
		if (form == null)
		{
			return;
		}
		PointF pointF = new PointF(intRelativeX, intRelativeY);
		GraphPane objGraphPane = null;
		object obj = null;
		int num = 0;
		Graphics measurementGraphics = CommonUtils.GetMeasurementGraphics();
		if (measurementGraphics == null || !mobjMasterPane.FindNearestPaneObject(pointF, measurementGraphics, out objGraphPane, out obj, out num))
		{
			return;
		}
		CurveItem val = (CurveItem)((obj is CurveItem) ? obj : null);
		if (val != null && num >= 0)
		{
			string text = GetPointValue(objGraphPane, val, num);
			if (string.IsNullOrEmpty(text))
			{
				text = $"( {((PointPairBase)val[num]).X.ToString()}, {((PointPairBase)val[num]).Y.ToString()} )";
			}
			ZedGraphToolTipForm zedGraphToolTipForm = new ZedGraphToolTipForm(text);
			zedGraphToolTipForm.Size = CommonUtils.GetStringMeasurements(text, zedGraphToolTipForm.Font);
			zedGraphToolTipForm.StartPosition = FormStartPosition.Manual;
			zedGraphToolTipForm.Location = new Point(intAbsoluteX + 2, intAbsoluteY + 2);
			zedGraphToolTipForm.ShowPopup(form, DialogAlignment.Custom);
		}
	}

	/// <summary>
	/// Axises the change.
	/// </summary>
	public virtual void AxisChange()
	{
		if (mobjMasterPane != null)
		{
			mobjMasterPane.AxisChange();
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void Copy(bool isShowMessage)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void CopyEmf(bool isShowMessage)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void DoPageSetup()
	{
	}

	/// <summary>
	/// Does the print.
	/// </summary>
	public void DoPrint()
	{
		PrintDocument printDocument = PrintDocument;
		if (printDocument != null)
		{
			PrintDialog printDialog = new PrintDialog();
			printDialog.Document = printDocument;
			printDialog.ShowDialog();
			printDocument.Print();
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void DoPrintPreview()
	{
	}

	/// <summary>
	/// Gets the image.
	/// </summary>
	/// <returns></returns>
	[Bindable(false)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Image GetImage()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (mobjMasterPane == null || mobjMasterPane[0] == null)
		{
			throw new ZedGraphException("The control has been disposed");
		}
		return ((PaneBase)mobjMasterPane).GetImage();
	}

	/// <summary>
	/// Initializes the size of the master pane.
	/// </summary>
	private void InitializeMasterPaneSize(int intWidth, int intHeight)
	{
		if (mobjMasterPane != null && (((PaneBase)mobjMasterPane).Rect.Width != (float)intWidth || ((PaneBase)mobjMasterPane).Rect.Height != (float)intHeight))
		{
			((PaneBase)mobjMasterPane).ReSize((Graphics)null, new RectangleF(PointF.Empty, new SizeF(intWidth, intHeight)));
			UpdateParams(AttributeType.Layout);
			mblnMasterPaneSizeInitialized = true;
		}
	}

	/// <summary>
	/// Restores the scale.
	/// </summary>
	/// <param name="primaryPane">The primary pane.</param>
	public void RestoreScale(GraphPane primaryPane)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		if (primaryPane == null)
		{
			return;
		}
		ZoomState oldState = new ZoomState(primaryPane, (ZoomState.StateType)0);
		using (Graphics g = Graphics.FromImage(GetImage()))
		{
			if (mblnIsSynchronizeXAxes || mblnIsSynchronizeYAxes)
			{
				foreach (GraphPane item in (List<GraphPane>)(object)mobjMasterPane.PaneList)
				{
					item.ZoomStack.Push(item, (ZoomState.StateType)0);
					ResetAutoScale(item, g);
				}
			}
			else
			{
				primaryPane.ZoomStack.Push(primaryPane, (ZoomState.StateType)0);
				ResetAutoScale(primaryPane, g);
			}
			ZoomEventEventHandler?.Invoke(this, oldState, new ZoomState(primaryPane, (ZoomState.StateType)0));
		}
		Refresh();
	}

	/// <summary>
	/// Resets the auto scale.
	/// </summary>
	/// <param name="pane">The pane.</param>
	/// <param name="g">The g.</param>
	private void ResetAutoScale(GraphPane pane, Graphics g)
	{
		((Axis)pane.XAxis).ResetAutoScale(pane, g);
		((Axis)pane.X2Axis).ResetAutoScale(pane, g);
		foreach (YAxis item in (List<YAxis>)(object)pane.YAxisList)
		{
			((Axis)item).ResetAutoScale(pane, g);
		}
		foreach (Y2Axis item2 in (List<Y2Axis>)(object)pane.Y2AxisList)
		{
			((Axis)item2).ResetAutoScale(pane, g);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void SaveAs()
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SaveAs(string DefaultFileName)
	{
		return string.Empty;
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void SaveAsBitmap()
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void SaveAsEmf()
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public void SetScrollRangeFromData()
	{
	}

	/// <summary>
	/// Zooms the out.
	/// </summary>
	/// <param name="primaryPane">The primary pane.</param>
	public void ZoomOut(GraphPane primaryPane)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (primaryPane == null || primaryPane.ZoomStack.IsEmpty)
		{
			return;
		}
		ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
		ZoomState oldState = new ZoomState(primaryPane, type);
		ZoomState newState = null;
		if (mblnIsSynchronizeXAxes || mblnIsSynchronizeYAxes)
		{
			foreach (GraphPane item in (List<GraphPane>)(object)mobjMasterPane.PaneList)
			{
				ZoomState val = item.ZoomStack.Pop(item);
				if (item == primaryPane)
				{
					newState = val;
				}
			}
		}
		else
		{
			newState = primaryPane.ZoomStack.Pop(primaryPane);
		}
		ZoomEventEventHandler?.Invoke(this, oldState, newState);
		Refresh();
	}

	/// <summary>
	/// Zooms the out all.
	/// </summary>
	/// <param name="primaryPane">The primary pane.</param>
	public void ZoomOutAll(GraphPane primaryPane)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (primaryPane == null || primaryPane.ZoomStack.IsEmpty)
		{
			return;
		}
		ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
		ZoomState oldState = new ZoomState(primaryPane, type);
		ZoomState newState = null;
		if (mblnIsSynchronizeXAxes || mblnIsSynchronizeYAxes)
		{
			foreach (GraphPane item in (List<GraphPane>)(object)mobjMasterPane.PaneList)
			{
				ZoomState val = item.ZoomStack.PopAll(item);
				if (item == primaryPane)
				{
					newState = val;
				}
			}
		}
		else
		{
			newState = primaryPane.ZoomStack.PopAll(primaryPane);
		}
		ZoomEventEventHandler?.Invoke(this, oldState, newState);
		Refresh();
	}

	/// <summary>
	/// Zooms the pane.
	/// </summary>
	/// <param name="pane">The pane.</param>
	/// <param name="zoomFraction">The zoom fraction.</param>
	/// <param name="centerPt">The center pt.</param>
	/// <param name="isZoomOnCenter">if set to <c>true</c> [is zoom on center].</param>
	public void ZoomPane(GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter)
	{
		ZoomPane(pane, zoomFraction, centerPt, isZoomOnCenter, isRefresh: true);
	}

	/// <summary>
	/// Zooms the pane.
	/// </summary>
	/// <param name="pane">The pane.</param>
	/// <param name="zoomFraction">The zoom fraction.</param>
	/// <param name="centerPt">The center pt.</param>
	/// <param name="isZoomOnCenter">if set to <c>true</c> [is zoom on center].</param>
	/// <param name="isRefresh">if set to <c>true</c> [is refresh].</param>
	protected void ZoomPane(GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter, bool isRefresh)
	{
		double centerVal = default(double);
		double centerVal2 = default(double);
		double[] array = default(double[]);
		double[] array2 = default(double[]);
		pane.ReverseTransform(centerPt, out centerVal, out centerVal2, out array, out array2);
		if (mblnIsEnableHZoom)
		{
			ZoomScale((Axis)(object)pane.XAxis, zoomFraction, centerVal, isZoomOnCenter);
			ZoomScale((Axis)(object)pane.X2Axis, zoomFraction, centerVal2, isZoomOnCenter);
		}
		if (mblnIsEnableVZoom)
		{
			for (int i = 0; i < ((List<YAxis>)(object)pane.YAxisList).Count; i++)
			{
				ZoomScale((Axis)(object)pane.YAxisList[i], zoomFraction, array[i], isZoomOnCenter);
			}
			for (int j = 0; j < ((List<Y2Axis>)(object)pane.Y2AxisList).Count; j++)
			{
				ZoomScale((Axis)(object)pane.Y2AxisList[j], zoomFraction, array2[j], isZoomOnCenter);
			}
		}
		using (Graphics graphics = Graphics.FromImage(GetImage()))
		{
			pane.AxisChange(graphics);
		}
		if (isRefresh)
		{
			Refresh();
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected string MakeValueLabel(Axis axis, double val, int iPt, bool isOverrideOrdinal)
	{
		return string.Empty;
	}

	/// <summary>
	/// Zooms the state purge.
	/// </summary>
	private void ZoomStatePurge()
	{
		foreach (GraphPane item in (List<GraphPane>)(object)mobjMasterPane.PaneList)
		{
			((List<ZoomState>)(object)item.ZoomStack).Clear();
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void MenuClick_Copy(object sender, EventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void MenuClick_PageSetup(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Handles the Print event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_Print(object sender, EventArgs e)
	{
		DoPrint();
	}

	/// <summary>
	/// Handles the RestoreScale event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_RestoreScale(object sender, EventArgs e)
	{
		if (mobjMasterPane != null)
		{
			GraphPane primaryPane = mobjMasterPane.FindPane((PointF)mobjContextMenuLocation);
			RestoreScale(primaryPane);
		}
	}

	/// <summary>
	/// Handles the SaveAs event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_SaveAs(object sender, EventArgs e)
	{
		Link.Download(new GatewayResourceHandle(this, "ZedGraphImage"), "ZedGraphImage.jpg");
	}

	/// <summary>
	/// Handles the ShowValues event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_ShowValues(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem toolStripMenuItem)
		{
			IsShowPointValues = !toolStripMenuItem.Checked;
		}
	}

	/// <summary>
	/// Handles the ZoomOut event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_ZoomOut(object sender, EventArgs e)
	{
		if (mobjMasterPane != null)
		{
			GraphPane primaryPane = mobjMasterPane.FindPane((PointF)mobjContextMenuLocation);
			ZoomOut(primaryPane);
		}
	}

	/// <summary>
	/// Handles the ZoomOutAll event of the MenuClick control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected void MenuClick_ZoomOutAll(object sender, EventArgs e)
	{
		if (mobjMasterPane != null)
		{
			GraphPane primaryPane = mobjMasterPane.FindPane((PointF)mobjContextMenuLocation);
			ZoomOutAll(primaryPane);
		}
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void PanScale(Axis axis, double startVal, double endVal)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void SetCursor()
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void SetCursor(Point mousePt)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_KeyDown(object sender, KeyEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_KeyUp(object sender, KeyEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_MouseDown(object sender, MouseEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_MouseMove(object sender, MouseEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_MouseUp(object sender, MouseEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_MouseWheel(object sender, MouseEventArgs e)
	{
	}

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected void ZedGraphControl_ReSize(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Zooms the scale.
	/// </summary>
	/// <param name="axis">The axis.</param>
	/// <param name="zoomFraction">The zoom fraction.</param>
	/// <param name="centerVal">The center val.</param>
	/// <param name="isZoomOnCenter">if set to <c>true</c> [is zoom on center].</param>
	protected void ZoomScale(Axis axis, double zoomFraction, double centerVal, bool isZoomOnCenter)
	{
		if (axis != null && zoomFraction > 0.0001 && zoomFraction < 1000.0)
		{
			_ = axis.Scale;
			double min = axis.Scale.Min;
			double max = axis.Scale.Max;
			double num = (max - min) * zoomFraction / 2.0;
			if (!isZoomOnCenter)
			{
				centerVal = (max + min) / 2.0;
			}
			axis.Scale.Min = centerVal - num;
			axis.Scale.Max = centerVal + num;
			axis.Scale.MinAuto = false;
			axis.Scale.MaxAuto = false;
		}
	}

	/// <summary>
	/// Gets the point value.
	/// </summary>
	/// <param name="objGraphPane">The graph pane.</param>
	/// <param name="objCurveItem">The curve item.</param>
	/// <param name="intPoint">The point.</param>
	/// <returns></returns>
	private string GetPointValue(GraphPane objGraphPane, CurveItem objCurveItem, int intPoint)
	{
		PointValueHandler pointValueEventHandler = PointValueEventHandler;
		if (pointValueEventHandler != null)
		{
			return pointValueEventHandler(this, objGraphPane, objCurveItem, intPoint);
		}
		return string.Empty;
	}

	/// <summary>
	/// Initializes the component.
	/// </summary>
	private void InitializeComponent()
	{
		mobjContextMenuStrip = new ContextMenuStrip();
		SuspendLayout();
		mobjContextMenuStrip.Name = "contextMenuStrip1";
		mobjContextMenuStrip.Opening += mobjContextMenuStrip_Opening;
		ContextMenuStrip = mobjContextMenuStrip;
		base.Name = "ZedGraphControl";
		ResumeLayout(blnPerformLayout: false);
	}

	/// <summary>
	/// Handles the Opening event of the mobjContextMenuStrip control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
	private void mobjContextMenuStrip_Opening(object sender, CancelEventArgs e)
	{
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected I4, but got Unknown
		e.Cancel = true;
		ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
		ContextMenuObjectState objState = ContextMenuObjectState.InactiveSelection;
		if (mobjMasterPane == null || contextMenuStrip == null)
		{
			return;
		}
		contextMenuStrip.Items.Clear();
		mobjContextMenuLocation = contextMenuStrip.Location;
		GraphPane val = mobjMasterPane.FindPane((PointF)mobjContextMenuLocation);
		string text = string.Empty;
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "copy";
		toolStripMenuItem.Tag = "copy";
		toolStripMenuItem.Text = "Copy";
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "save_as";
		toolStripMenuItem.Tag = "save_as";
		toolStripMenuItem.Text = "Save Image As";
		toolStripMenuItem.Click += MenuClick_SaveAs;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "page_setup";
		toolStripMenuItem.Tag = "page_setup";
		toolStripMenuItem.Text = "Page Setup";
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "print";
		toolStripMenuItem.Tag = "print";
		toolStripMenuItem.Text = "Print";
		toolStripMenuItem.Click += MenuClick_Print;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "show_val";
		toolStripMenuItem.Tag = "show_val";
		toolStripMenuItem.Text = "Show Point Values";
		toolStripMenuItem.Click += MenuClick_ShowValues;
		toolStripMenuItem.Checked = IsShowPointValues;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "unzoom";
		toolStripMenuItem.Tag = "unzoom";
		if (val == null || val.ZoomStack.IsEmpty)
		{
			text = "Un-Zoom";
		}
		else
		{
			ZoomState.StateType type = val.ZoomStack.Top.Type;
			switch ((int)type)
			{
			case 0:
			case 1:
				text = "Un-Zoom";
				break;
			case 2:
				text = "Un-Span";
				break;
			case 3:
				text = "Un-Scroll";
				break;
			}
		}
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_ZoomOut;
		if (val == null || val.ZoomStack.IsEmpty)
		{
			toolStripMenuItem.Enabled = false;
		}
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "undo_all";
		toolStripMenuItem.Tag = "undo_all";
		text = "Undo All Zoom/Pan";
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_ZoomOutAll;
		if (val == null || val.ZoomStack.IsEmpty)
		{
			toolStripMenuItem.Enabled = false;
		}
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "set_default";
		toolStripMenuItem.Tag = "set_default";
		text = "Set Scale to Default";
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_RestoreScale;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		e.Cancel = false;
		ContextMenuBuilderHandler?.Invoke(this, contextMenuStrip, mobjContextMenuLocation, objState);
	}

	static ZedGraphControl()
	{
		PointValueEventEvent = SerializableEvent.Register("PointValueEvent", typeof(PointValueHandler), typeof(ZedGraphControl));
		ContextMenuBuilderEvent = SerializableEvent.Register("ContextMenuBuilder", typeof(ContextMenuBuilderEventHandler), typeof(ZedGraphControl));
		ZoomEventEvent = SerializableEvent.Register("ZoomEvent", typeof(ZoomEventHandler), typeof(ZedGraphControl));
	}
}
