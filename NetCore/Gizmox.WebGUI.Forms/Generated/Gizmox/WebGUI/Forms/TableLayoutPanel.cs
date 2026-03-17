#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// A table layout control.
	/// </summary>
	/// 
	/// Use this layout control to create static layout that updates
	/// with control resizing.
	/// </remarks>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TableLayoutPanel), "TableLayoutPanel_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ProvideProperty("Column", typeof(Control))]
	[SRDescription("DescriptionTableLayoutPanel")]
	[ProvideProperty("ColumnSpan", typeof(Control))]
	[ProvideProperty("RowSpan", typeof(Control))]
	[ProvideProperty("Row", typeof(Control))]
	[ProvideProperty("CellPosition", typeof(Control))]
	[DefaultProperty("ColumnCount")]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ToolboxItemCategory("Containers")]
	[MetadataTag("TLP")]
	[Skin(typeof(TableLayoutPanelSkin))]
	[ProxyComponent(typeof(ProxyTableLayoutPanel))]
	public class TableLayoutPanel : Control, IExtenderProvider
	{
		/// 
		/// Provides a property reference to LayoutSettings property.
		/// </summary>
		private static SerializableProperty LayoutSettingsProperty = SerializableProperty.Register("LayoutSettings", typeof(TableLayoutSettings), typeof(TableLayoutPanel), new SerializablePropertyMetadata(null));

		private static readonly SerializableEvent EventCellPaintEvent = SerializableEvent.Register("Event", typeof(Delegate), typeof(TableLayoutPanel));

		private BorderStyle menmBorderStyle = BorderStyle.None;

		/// 
		/// Gets or sets the border color.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[Browsable(false)]
		public new Color BorderColor
		{
			get
			{
				return base.BorderColor;
			}
			set
			{
				base.BorderColor = value;
			}
		}

		/// 
		/// Gets or sets the width of the border.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int BorderWidth
		{
			get
			{
				return base.BorderWidth;
			}
			set
			{
				base.BorderWidth = value;
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Localizable(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
			}
		}

		/// 
		/// Gets or sets the cell border style.
		/// </summary>
		/// The cell border style.</value>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[DefaultValue(0)]
		[SRDescription("TableLayoutPanelCellBorderStyleDescr")]
		public TableLayoutPanelCellBorderStyle CellBorderStyle
		{
			get
			{
				return LayoutSettings.CellBorderStyle;
			}
			set
			{
				LayoutSettings.CellBorderStyle = value;
				FireObservableItemPropertyChanged("CellBorderStyle");
				if (value != TableLayoutPanelCellBorderStyle.None)
				{
					SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
				}
				Invalidate();
			}
		}

		private int CellBorderWidth => LayoutSettings.CellBorderWidth;

		/// 
		/// Gets or sets the column count.
		/// </summary>
		/// The column count.</value>
		[SRDescription("GridPanelColumnsDescr")]
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[DefaultValue(0)]
		public int ColumnCount
		{
			get
			{
				return LayoutSettings.ColumnCount;
			}
			set
			{
				LayoutSettings.ColumnCount = value;
				FireObservableItemPropertyChanged("ColumnCount");
				Update();
			}
		}

		/// 
		/// Gets the column styles.
		/// </summary>
		/// The column styles.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("GridPanelColumnStylesDescr")]
		[SRCategory("CatLayout")]
		[MergableProperty(false)]
		[Browsable(true)]
		[DisplayName("Columns")]
		public TableLayoutColumnStyleCollection ColumnStyles => LayoutSettings.ColumnStyles;

		/// 
		/// Gets the collection of controls contained within the control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[SRDescription("ControlControlsDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new TableLayoutControlCollection Controls => (TableLayoutControlCollection)base.Controls;

		/// 
		/// Gets or sets the grow style.
		/// </summary>
		/// The grow style.</value>
		[SRDescription("TableLayoutPanelGrowStyleDescr")]
		[DefaultValue(1)]
		[SRCategory("CatLayout")]
		public TableLayoutPanelGrowStyle GrowStyle
		{
			get
			{
				return LayoutSettings.GrowStyle;
			}
			set
			{
				LayoutSettings.GrowStyle = value;
				FireObservableItemPropertyChanged("GrowStyle");
			}
		}

		/// 
		/// Gets the layout engine.
		/// </summary>
		/// The layout engine.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public LayoutEngine LayoutEngine => TableLayout.Instance;

		/// 
		/// Gets or sets the layout settings.
		/// </summary>
		/// The layout settings.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public TableLayoutSettings LayoutSettings
		{
			get
			{
				return GetValue(LayoutSettingsProperty);
			}
			set
			{
				if (value != null && value.IsStub)
				{
					LayoutSettings.ApplySettings(value);
					FireObservableItemPropertyChanged("LayoutSettings");
					return;
				}
				throw new NotSupportedException(SR.GetString("TableLayoutSettingSettingsIsNotSupported"));
			}
		}

		/// 
		/// Gets or sets the row count.
		/// </summary>
		/// The row count.</value>
		[DefaultValue(0)]
		[SRDescription("GridPanelRowsDescr")]
		[SRCategory("CatLayout")]
		[Localizable(true)]
		public int RowCount
		{
			get
			{
				return LayoutSettings.RowCount;
			}
			set
			{
				LayoutSettings.RowCount = value;
				FireObservableItemPropertyChanged("RowCount");
				Update();
			}
		}

		/// 
		/// Gets a value indicating whether [support child margins].
		/// </summary>
		/// 
		///   true</c> if [support child margins]; otherwise, false</c>.
		/// </value>
		protected override bool SupportChildMargins => true;

		/// 
		/// Gets the row styles.
		/// </summary>
		/// The row styles.</value>
		[SRDescription("GridPanelRowStylesDescr")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatLayout")]
		[MergableProperty(false)]
		[DisplayName("Rows")]
		public TableLayoutRowStyleCollection RowStyles => LayoutSettings.RowStyles;

		/// 
		/// Occurs when [cell paint].
		/// </summary>
		[SRCategory("CatAppearance")]
		[SRDescription("TableLayoutPanelOnPaintCellDescr")]
		public event TableLayoutCellPaintEventHandler CellPaint
		{
			add
			{
				AddHandler(EventCellPaintEvent, value);
			}
			remove
			{
				RemoveHandler(EventCellPaintEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutPanel" /> class.
		/// </summary>
		public TableLayoutPanel()
		{
			SetValue(LayoutSettingsProperty, TableLayout.CreateSettings(this));
		}

		/// 
		/// Renders the current control.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RegisterSelf();
			objWriter.WriteAttributeText("TX", Text);
			if (CellBorderStyle != TableLayoutPanelCellBorderStyle.None)
			{
				objWriter.WriteAttributeString("BS", ((int)CellBorderStyle).ToString());
			}
			int intNewRowNum = 0;
			int intNewColNum = 0;
			GetNewColAndRowCount(out intNewRowNum, out intNewColNum);
			List<TableLayoutPanelCellStyle> objRowsCells = new List<TableLayoutPanelCellStyle>();
			List<TableLayoutPanelCellStyle> objColumnsCells = new List<TableLayoutPanelCellStyle>();
			CalculateColAndRowStyle(intNewRowNum, intNewColNum, objRowsCells, objColumnsCells);
			int num = 0;
			for (num = 0; num < intNewColNum; num++)
			{
				if (num < ColumnStyles.Count)
				{
					objWriter.WriteStartElement("TLC");
					objWriter.WriteAttributeString("W", GetLayoutSize(ColumnStyles[num].Width, ColumnStyles[num].SizeType));
					RenderColumnsPositionAttributes(objWriter, objColumnsCells, num);
					objWriter.WriteEndElement();
				}
				else
				{
					objWriter.WriteStartElement("TLC");
					objWriter.WriteAttributeString("W", "1px");
					RenderColumnsPositionAttributes(objWriter, objColumnsCells, num);
					objWriter.WriteEndElement();
				}
			}
			for (num = 0; num < intNewRowNum; num++)
			{
				if (num < RowStyles.Count)
				{
					objWriter.WriteStartElement("TLR");
					objWriter.WriteAttributeString("H", GetLayoutSize(RowStyles[num].Height, RowStyles[num].SizeType));
					RenderRowsPositionAttributes(objWriter, objRowsCells, num);
					objWriter.WriteEndElement();
				}
				else
				{
					objWriter.WriteStartElement("TLR");
					objWriter.WriteAttributeString("H", "1px");
					RenderRowsPositionAttributes(objWriter, objRowsCells, num);
					objWriter.WriteEndElement();
				}
			}
			for (int num2 = Controls.Count - 1; num2 >= 0; num2--)
			{
				Control control = Controls[num2];
				TableLayoutControlPosition controlPosition = GetControlPosition(control);
				if (controlPosition.Row > -1 && controlPosition.Column > -1)
				{
					((IRenderableComponent)control).RenderComponent(objContext, objWriter, 0L);
				}
			}
		}

		/// 
		/// Renders the columns position attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objColumnsCells">The obj columns cells.</param>
		/// <param name="intInd">The int ind.</param>
		private static void RenderColumnsPositionAttributes(IResponseWriter objWriter, List<TableLayoutPanelCellStyle> objColumnsCells, int intInd)
		{
			if (objColumnsCells.Count > intInd)
			{
				objWriter.WriteAttributeString("L", Math.Round(objColumnsCells[intInd].LeftPercent, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("ML", Math.Round(objColumnsCells[intInd].LeftMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("R", Math.Round(objColumnsCells[intInd].RightPercent, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("MR", Math.Round(objColumnsCells[intInd].RightMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
			}
		}

		/// 
		/// Renders the rows position attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objRowsCells">The obj rows cells.</param>
		/// <param name="intInd">The int ind.</param>
		private static void RenderRowsPositionAttributes(IResponseWriter objWriter, List<TableLayoutPanelCellStyle> objRowsCells, int intInd)
		{
			if (objRowsCells.Count > intInd)
			{
				objWriter.WriteAttributeString("T", Math.Round(objRowsCells[intInd].TopPercent, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("MT", Math.Round(objRowsCells[intInd].TopMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("B", Math.Round(objRowsCells[intInd].BottomPercent, 2).ToString(CultureInfo.InvariantCulture));
				objWriter.WriteAttributeString("MB", Math.Round(objRowsCells[intInd].BottomMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
			}
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			TableLayout instance = TableLayout.Instance;
			if (containerInfo != null)
			{
				instance?.AssignRowsAndColumns(containerInfo);
			}
			for (int num = Controls.Count - 1; num >= 0; num--)
			{
				Control control = Controls[num];
				TableLayoutControlPosition controlPosition = GetControlPosition(control);
				if (controlPosition.Row > -1 && controlPosition.Column > -1)
				{
					string numbers = GetNumbers(controlPosition.Row, controlPosition.Row + (controlPosition.Rowspan - 1));
					string numbers2 = GetNumbers(controlPosition.Column, controlPosition.Column + (controlPosition.Colspan - 1));
					((IAttributeExtender)control).SetAttribute("RS", numbers);
					((IAttributeExtender)control).SetAttribute("CS", numbers2);
					((IAttributeExtender)control).SetAttribute("RSP", controlPosition.Rowspan.ToString());
					((IAttributeExtender)control).SetAttribute("CSP", controlPosition.Colspan.ToString());
				}
			}
			base.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Gets the col and row style.
		/// </summary>
		/// <param name="intNewRowNum">The int new row num.</param>
		/// <param name="intNewColNum">The int new col num.</param>
		/// <param name="objRowsCells">The obj rows cells.</param>
		/// <param name="objColumnsCells">The obj columns cells.</param>
		private void CalculateColAndRowStyle(int intNewRowNum, int intNewColNum, List<TableLayoutPanelCellStyle> objRowsCells, List<TableLayoutPanelCellStyle> objColumnsCells)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < intNewRowNum; i++)
			{
				if (i < RowStyles.Count)
				{
					if (RowStyles[i].SizeType == SizeType.Absolute)
					{
						num2 += RowStyles[i].Height;
					}
					else
					{
						num3 += RowStyles[i].Height;
					}
					continue;
				}
				Control control = null;
				for (int j = 0; j < intNewColNum; j++)
				{
					Control controlFromPosition = GetControlFromPosition(j, i);
					TableLayoutPanelCellPosition positionFromControl = GetPositionFromControl(controlFromPosition);
					if (controlFromPosition != null && GetRowSpan(controlFromPosition) == 1 && positionFromControl.Column == j && positionFromControl.Row == i && (control == null || control.Height < controlFromPosition.Height))
					{
						control = controlFromPosition;
					}
				}
				num2 = ((control == null) ? (num2 + 1f) : (num2 + (float)control.Height));
			}
			for (int k = 0; k < intNewColNum; k++)
			{
				if (k < ColumnStyles.Count)
				{
					if (ColumnStyles[k].SizeType == SizeType.Absolute)
					{
						num += ColumnStyles[k].Width;
					}
					else
					{
						num4 += ColumnStyles[k].Width;
					}
					continue;
				}
				Control control2 = null;
				for (int l = 0; l < intNewRowNum; l++)
				{
					Control controlFromPosition2 = GetControlFromPosition(k, l);
					TableLayoutPanelCellPosition positionFromControl2 = GetPositionFromControl(controlFromPosition2);
					if (controlFromPosition2 != null && positionFromControl2.Column == k && positionFromControl2.Row == l && (control2 == null || control2.Width < controlFromPosition2.Width))
					{
						control2 = controlFromPosition2;
					}
				}
				num = ((control2 == null) ? (num + 1f) : (num + (float)control2.Width));
			}
			float num5 = 0f;
			for (int m = 0; m < intNewRowNum; m++)
			{
				if (m == 0 && m < RowStyles.Count)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle = new TableLayoutPanelCellStyle();
					objRowsCells.Add(tableLayoutPanelCellStyle);
					if (RowStyles[m].SizeType == SizeType.Percent)
					{
						float num6 = NormalizePercentage(num3, RowStyles[m].Height);
						tableLayoutPanelCellStyle.BottomPercent = 100f - num6;
						tableLayoutPanelCellStyle.BottomMarginPixel = num6 / 100f * num2;
					}
					else if (RowStyles[m].SizeType == SizeType.Absolute)
					{
						num5 += RowStyles[m].Height;
						tableLayoutPanelCellStyle.BottomPercent = 100f;
						tableLayoutPanelCellStyle.BottomMarginPixel = num5 * -1f;
					}
					continue;
				}
				if (m < RowStyles.Count)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle2 = null;
					tableLayoutPanelCellStyle2 = objRowsCells[m - 1];
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle3 = new TableLayoutPanelCellStyle();
					objRowsCells.Add(tableLayoutPanelCellStyle3);
					if (tableLayoutPanelCellStyle2 != null)
					{
						tableLayoutPanelCellStyle3.TopPercent = 100f - tableLayoutPanelCellStyle2.BottomPercent;
						tableLayoutPanelCellStyle3.TopMarginPixel = tableLayoutPanelCellStyle2.BottomMarginPixel * -1f;
					}
					if (m == RowStyles.Count - 1 && m == intNewRowNum - 1)
					{
						tableLayoutPanelCellStyle3.BottomPercent = 0f;
						tableLayoutPanelCellStyle3.BottomMarginPixel = 0f;
					}
					else if (RowStyles[m].SizeType == SizeType.Percent)
					{
						float num7 = NormalizePercentage(num3, RowStyles[m].Height);
						tableLayoutPanelCellStyle3.BottomPercent = 100f - (tableLayoutPanelCellStyle3.TopPercent + num7);
						tableLayoutPanelCellStyle3.BottomMarginPixel = (100f - tableLayoutPanelCellStyle3.BottomPercent) / 100f * num2 - num5;
					}
					else if (RowStyles[m].SizeType == SizeType.Absolute)
					{
						num5 += RowStyles[m].Height;
						tableLayoutPanelCellStyle3.BottomPercent = 100f - tableLayoutPanelCellStyle3.TopPercent;
						tableLayoutPanelCellStyle3.BottomMarginPixel = (100f - tableLayoutPanelCellStyle3.BottomPercent) / 100f * num2 - num5;
					}
					continue;
				}
				int num8 = 1;
				for (int n = 0; n < intNewColNum; n++)
				{
					Control controlFromPosition3 = GetControlFromPosition(n, m);
					TableLayoutPanelCellPosition positionFromControl3 = GetPositionFromControl(controlFromPosition3);
					if (controlFromPosition3 == null)
					{
						continue;
					}
					int rowSpan = GetRowSpan(controlFromPosition3);
					if (rowSpan == 1)
					{
						if (num8 < controlFromPosition3.Height)
						{
							num8 = controlFromPosition3.Height;
						}
					}
					else if (rowSpan > 1 && positionFromControl3.Row + rowSpan - 1 == m)
					{
						int num9 = controlFromPosition3.Height;
						for (int num10 = m - 1; num10 >= positionFromControl3.Row; num10--)
						{
							TableLayoutPanelCellStyle tableLayoutPanelCellStyle4 = objRowsCells[num10];
							num9 -= (int)(Math.Abs(tableLayoutPanelCellStyle4.BottomMarginPixel) - tableLayoutPanelCellStyle4.TopMarginPixel);
						}
						if (num8 < num9)
						{
							num8 = num9;
						}
					}
				}
				TableLayoutPanelCellStyle tableLayoutPanelCellStyle5 = new TableLayoutPanelCellStyle();
				objRowsCells.Add(tableLayoutPanelCellStyle5);
				num5 += (float)num8;
				if (m > 0)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle6 = null;
					tableLayoutPanelCellStyle6 = objRowsCells[m - 1];
					if (tableLayoutPanelCellStyle6 != null)
					{
						tableLayoutPanelCellStyle5.TopPercent = 100f - tableLayoutPanelCellStyle6.BottomPercent;
						tableLayoutPanelCellStyle5.TopMarginPixel = tableLayoutPanelCellStyle6.BottomMarginPixel * -1f;
					}
					tableLayoutPanelCellStyle5.BottomPercent = 100f - tableLayoutPanelCellStyle5.TopPercent;
					tableLayoutPanelCellStyle5.BottomMarginPixel = (100f - tableLayoutPanelCellStyle5.BottomPercent) / 100f * num2 - num5;
				}
				else
				{
					if (num2 < (float)base.Height)
					{
						num2 = base.Height;
					}
					tableLayoutPanelCellStyle5.BottomPercent = 100f - tableLayoutPanelCellStyle5.TopPercent;
					tableLayoutPanelCellStyle5.BottomMarginPixel = (100f - tableLayoutPanelCellStyle5.BottomPercent) / 100f * num2 - num5;
				}
				if (m == intNewRowNum - 1)
				{
					tableLayoutPanelCellStyle5.BottomPercent = 0f;
					tableLayoutPanelCellStyle5.BottomMarginPixel = 0f;
				}
			}
			num5 = 0f;
			for (int num11 = 0; num11 < intNewColNum; num11++)
			{
				if (num11 == 0 && num11 < ColumnStyles.Count)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle7 = new TableLayoutPanelCellStyle();
					objColumnsCells.Add(tableLayoutPanelCellStyle7);
					if (ColumnStyles[num11].SizeType == SizeType.Percent)
					{
						float num12 = NormalizePercentage(num4, ColumnStyles[num11].Width);
						tableLayoutPanelCellStyle7.RightPercent = 100f - num12;
						tableLayoutPanelCellStyle7.RightMarginPixel = num12 / 100f * num;
					}
					else if (ColumnStyles[num11].SizeType == SizeType.Absolute)
					{
						num5 += ColumnStyles[num11].Width;
						tableLayoutPanelCellStyle7.RightPercent = 100f;
						tableLayoutPanelCellStyle7.RightMarginPixel = num5 * -1f;
					}
					continue;
				}
				if (num11 < ColumnStyles.Count)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle8 = null;
					tableLayoutPanelCellStyle8 = objColumnsCells[num11 - 1];
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle9 = new TableLayoutPanelCellStyle();
					objColumnsCells.Add(tableLayoutPanelCellStyle9);
					if (tableLayoutPanelCellStyle8 != null)
					{
						tableLayoutPanelCellStyle9.LeftPercent = 100f - tableLayoutPanelCellStyle8.RightPercent;
						tableLayoutPanelCellStyle9.LeftMarginPixel = tableLayoutPanelCellStyle8.RightMarginPixel * -1f;
					}
					if (num11 == ColumnStyles.Count - 1 && num11 == intNewColNum - 1)
					{
						tableLayoutPanelCellStyle9.RightPercent = 0f;
						tableLayoutPanelCellStyle9.RightMarginPixel = 0f;
					}
					else if (ColumnStyles[num11].SizeType == SizeType.Percent)
					{
						float num13 = NormalizePercentage(num4, ColumnStyles[num11].Width);
						tableLayoutPanelCellStyle9.RightPercent = 100f - (tableLayoutPanelCellStyle9.LeftPercent + num13);
						tableLayoutPanelCellStyle9.RightMarginPixel = (100f - tableLayoutPanelCellStyle9.RightPercent) / 100f * num - num5;
					}
					else if (ColumnStyles[num11].SizeType == SizeType.Absolute)
					{
						num5 += ColumnStyles[num11].Width;
						tableLayoutPanelCellStyle9.RightPercent = 100f - tableLayoutPanelCellStyle9.LeftPercent;
						tableLayoutPanelCellStyle9.RightMarginPixel = (100f - tableLayoutPanelCellStyle9.RightPercent) / 100f * num - num5;
					}
					continue;
				}
				int num14 = 1;
				for (int num15 = 0; num15 < intNewRowNum; num15++)
				{
					Control controlFromPosition4 = GetControlFromPosition(num11, num15);
					TableLayoutPanelCellPosition positionFromControl4 = GetPositionFromControl(controlFromPosition4);
					if (controlFromPosition4 == null)
					{
						continue;
					}
					int columnSpan = GetColumnSpan(controlFromPosition4);
					if (columnSpan == 1)
					{
						if (num14 < controlFromPosition4.Width)
						{
							num14 = controlFromPosition4.Width;
						}
					}
					else if (columnSpan > 1 && positionFromControl4.Column + columnSpan - 1 == columnSpan)
					{
						int num16 = controlFromPosition4.Height;
						for (int num17 = num11 - 1; num17 >= positionFromControl4.Column; num17--)
						{
							TableLayoutPanelCellStyle tableLayoutPanelCellStyle10 = objColumnsCells[num17];
							num16 -= (int)(Math.Abs(tableLayoutPanelCellStyle10.RightMarginPixel) - tableLayoutPanelCellStyle10.LeftMarginPixel);
						}
						if (num14 < num16)
						{
							num14 = num16;
						}
					}
				}
				TableLayoutPanelCellStyle tableLayoutPanelCellStyle11 = new TableLayoutPanelCellStyle();
				objColumnsCells.Add(tableLayoutPanelCellStyle11);
				num5 += (float)num14;
				if (num11 > 0)
				{
					TableLayoutPanelCellStyle tableLayoutPanelCellStyle12 = null;
					tableLayoutPanelCellStyle12 = objColumnsCells[num11 - 1];
					if (tableLayoutPanelCellStyle12 != null)
					{
						tableLayoutPanelCellStyle11.LeftPercent = 100f - tableLayoutPanelCellStyle12.RightPercent;
						tableLayoutPanelCellStyle11.LeftMarginPixel = tableLayoutPanelCellStyle12.RightMarginPixel * -1f;
					}
					tableLayoutPanelCellStyle11.RightPercent = 100f - tableLayoutPanelCellStyle11.LeftPercent;
					tableLayoutPanelCellStyle11.RightMarginPixel = (100f - tableLayoutPanelCellStyle11.RightPercent) / 100f * num - num5;
				}
				else
				{
					if (num < (float)base.Width)
					{
						num = base.Width;
					}
					tableLayoutPanelCellStyle11.RightPercent = 100f;
					tableLayoutPanelCellStyle11.RightMarginPixel = (100f - tableLayoutPanelCellStyle11.RightPercent) / 100f * num - num5;
				}
				if (num11 == intNewColNum - 1)
				{
					tableLayoutPanelCellStyle11.RightPercent = 0f;
					tableLayoutPanelCellStyle11.RightMarginPixel = 0f;
				}
			}
		}

		/// 
		/// Normalizes the percentage mainly when the sum of sizes of cells is not 100.
		/// </summary>
		/// <param name="fltTotalSum">The FLT total sum.</param>
		/// <param name="fltCurrentValue">The FLT current value.</param>
		/// </returns>
		private float NormalizePercentage(float fltTotalSum, float fltCurrentValue)
		{
			return fltCurrentValue / fltTotalSum * 100f;
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			if (e.Control != null)
			{
				((IAttributeExtender)e.Control).SetAttribute("RS", (string)null);
				((IAttributeExtender)e.Control).SetAttribute("CS", (string)null);
				((IAttributeExtender)e.Control).SetAttribute("RSP", (string)null);
				((IAttributeExtender)e.Control).SetAttribute("CSP", (string)null);
			}
		}

		/// 
		/// Gets the new row and column number according to the newly added controls.
		/// </summary>
		/// <param name="intNewRowNum">The row count return value.</param>
		/// <param name="intNewColNum">The column count return value.</param>
		/// </returns>
		internal void GetNewColAndRowCount(out int intNewRowNum, out int intNewColNum)
		{
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			if (containerInfo != null)
			{
				intNewColNum = Math.Max(containerInfo.MaxColumns, containerInfo.MinColumns);
				intNewRowNum = Math.Max(containerInfo.MaxRows, containerInfo.MinRows);
			}
			else
			{
				intNewColNum = 0;
				intNewRowNum = 0;
			}
		}

		/// 
		/// Gets the size of the control.
		/// </summary>
		/// <param name="objProposedSize">The proposed size in a 'Size' struct format.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			int num = objProposedSize.Width;
			int num2 = objProposedSize.Height;
			if (AutoSize)
			{
				if (Controls.Count > 0)
				{
					foreach (Control control in Controls)
					{
						TableLayoutControlPosition controlPosition = GetControlPosition(control);
						if (controlPosition != null)
						{
							Size size = new Size(control.LayoutWidth, control.LayoutHeight);
							Size preferredSize;
							if (control.UsePreferredSize)
							{
								preferredSize = control.GetPreferredSize(size);
								preferredSize = Control.GetPreferredSizeByAutoSizeMode(control, size, preferredSize);
							}
							else
							{
								preferredSize = size;
							}
							if (controlPosition.Column >= 0 && controlPosition.Column < ColumnStyles.Count && ColumnStyles[controlPosition.Column].SizeType == SizeType.AutoSize && (float)preferredSize.Width > ColumnStyles[controlPosition.Column].Width)
							{
								ColumnStyles[controlPosition.Column].Width = preferredSize.Width;
							}
							if (controlPosition.Row >= 0 && controlPosition.Row < RowStyles.Count && RowStyles[controlPosition.Row].SizeType == SizeType.AutoSize && (float)preferredSize.Height > RowStyles[controlPosition.Row].Height)
							{
								RowStyles[controlPosition.Row].Height = preferredSize.Height;
							}
						}
					}
				}
				num = 0;
				num2 = 0;
				foreach (ColumnStyle item in (IEnumerable)ColumnStyles)
				{
					num += Convert.ToInt32(item.Width);
				}
				foreach (RowStyle item2 in (IEnumerable)RowStyles)
				{
					num2 += Convert.ToInt32(item2.Height);
				}
			}
			return new Size(num, num2);
		}

		/// 
		/// Layout the internal controls to reflect parent changes
		/// </summary>
		/// <param name="objEventArgs">The layout arguments.</param>
		/// <param name="objNewSize">The new parent size.</param>
		/// <param name="objOldSize">The old parent size.</param>
		protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
		{
			ControlCollection controls = Controls;
			if (controls == null || controls.Count <= 0)
			{
				return;
			}
			int num = objNewSize.Width - objOldSize.Width;
			int num2 = objNewSize.Height - objOldSize.Height;
			if (num2 == 0 && num == 0)
			{
				return;
			}
			foreach (Control item in controls)
			{
				DockStyle dock = item.Dock;
				ColumnStyle columnStyle = null;
				RowStyle rowStyle = null;
				int column = GetColumn(item);
				if (column >= 0 && column < ColumnStyles.Count)
				{
					columnStyle = ColumnStyles[column];
				}
				int row = GetRow(item);
				if (row >= 0 && row < RowStyles.Count)
				{
					rowStyle = RowStyles[row];
				}
				if (columnStyle == null || rowStyle == null || (columnStyle.SizeType != SizeType.Percent && rowStyle.SizeType != SizeType.Percent))
				{
					continue;
				}
				if (dock == DockStyle.Left || dock == DockStyle.Right)
				{
					if (num != 0 && columnStyle.SizeType == SizeType.Percent && dock == DockStyle.Right)
					{
						item.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (num2 != 0 && rowStyle.SizeType == SizeType.Percent)
					{
						item.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					continue;
				}
				if (dock == DockStyle.Top || dock == DockStyle.Bottom)
				{
					if (dock == DockStyle.Bottom && num2 != 0 && rowStyle.SizeType == SizeType.Percent)
					{
						item.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (num != 0 && columnStyle.SizeType == SizeType.Percent)
					{
						item.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					continue;
				}
				if (dock == DockStyle.Fill)
				{
					if ((num != 0 && columnStyle.SizeType == SizeType.Percent) || (num2 != 0 && rowStyle.SizeType == SizeType.Percent))
					{
						item.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					continue;
				}
				int num3 = item.Left;
				int num4 = item.Top;
				int num5 = item.Height;
				int num6 = item.Width;
				AnchorStyles anchor = item.Anchor;
				bool flag = item.IsRightAnchored(anchor);
				bool flag2 = item.IsLeftAnchored(anchor);
				bool flag3 = item.IsTopAnchored(anchor);
				bool flag4 = item.IsBottomAnchored(anchor);
				bool flag5 = false;
				bool flag6 = false;
				if (num != 0 && columnStyle.SizeType == SizeType.Percent)
				{
					if (flag && !flag2)
					{
						num3 += Convert.ToInt32(columnStyle.Size * (float)num / 100f);
						flag6 = true;
					}
					else if (flag && flag2)
					{
						num6 += Convert.ToInt32(columnStyle.Size * (float)num / 100f);
						flag5 = true;
					}
					else if (!flag && !flag2)
					{
						num3 += Convert.ToInt32(columnStyle.Size * (float)num / 200f);
						flag6 = true;
					}
				}
				if (num2 != 0 && rowStyle.SizeType == SizeType.Percent)
				{
					if (flag4 && !flag3)
					{
						num4 += Convert.ToInt32(rowStyle.Size * (float)num2 / 100f);
						flag6 = true;
					}
					else if (flag4 && flag3)
					{
						num5 += Convert.ToInt32(rowStyle.Size * (float)num2 / 100f);
						flag5 = true;
					}
					else if (!flag4 && !flag3)
					{
						num4 += Convert.ToInt32(rowStyle.Size * (float)num2 / 200f);
						flag6 = true;
					}
				}
				if (flag6 || flag5)
				{
					item.UpdateBounds(num3, num4, num6, num5, num6, num5, objEventArgs.IsClientSource);
					if (flag6)
					{
						item.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (flag5)
					{
						item.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
				}
			}
		}

		/// 
		/// Gets the size of the layout.
		/// </summary>
		/// <param name="fltSize">Size of the lay out.</param>
		/// <param name="enmSizeType">Type of size.</param>
		/// </returns>
		private string GetLayoutSize(float fltSize, SizeType enmSizeType)
		{
			string result = string.Empty;
			switch (enmSizeType)
			{
			case SizeType.Absolute:
				result = $"{fltSize.ToString(CultureInfo.InvariantCulture)}px";
				break;
			case SizeType.AutoSize:
				result = string.Empty;
				break;
			case SizeType.Percent:
				result = $"{fltSize.ToString(CultureInfo.InvariantCulture)}%";
				break;
			}
			return result;
		}

		/// 
		/// Renders the child controls.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">Request ID.</param>
		/// 
		/// Overrides default controls rendering cause the fill docking mechanism is not
		/// fit to handle table layout children.
		/// </remarks>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			for (int num = Controls.Count - 1; num >= 0; num--)
			{
				Control control = Controls[num];
				((IRenderableComponent)control).RenderComponent(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Gets the cell position.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRDescription("GridPanelCellPositionDescr")]
		[DefaultValue(-1)]
		[SRCategory("CatLayout")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DisplayName("Cell")]
		public TableLayoutPanelCellPosition GetCellPosition(Control objControl)
		{
			return LayoutSettings.GetCellPosition(objControl);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new TableLayoutPanelRenderer(this);
		}

		/// 
		/// Gets the column.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRDescription("GridPanelColumnDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatLayout")]
		[DefaultValue(-1)]
		[DisplayName("Column")]
		public int GetColumn(Control objControl)
		{
			return LayoutSettings.GetColumn(objControl);
		}

		/// 
		/// Gets the column span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRCategory("CatLayout")]
		[SRDescription("GridPanelGetColumnSpanDescr")]
		[DefaultValue(1)]
		[DisplayName("ColumnSpan")]
		public int GetColumnSpan(Control objControl)
		{
			return LayoutSettings.GetColumnSpan(objControl);
		}

		/// 
		/// Gets the column widths.
		/// </summary>
		/// </returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int[] GetColumnWidths()
		{
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			if (containerInfo.Columns == null)
			{
				return new int[0];
			}
			int[] array = new int[containerInfo.Columns.Length];
			for (int i = 0; i < containerInfo.Columns.Length; i++)
			{
				array[i] = containerInfo.Columns[i].MinSize;
			}
			return array;
		}

		/// 
		/// Returns the child control occupying the specified position.
		/// </summary>
		/// <param name="intColumn">The column position of the control to retrieve.</param>
		/// <param name="intRow">The row position of the control to retrieve.</param>
		/// 
		/// The child control occupying the specified cell; otherwise, null if no control 
		/// exists at the specified column and row.
		/// </returns>
		public Control GetControlFromPosition(int intColumn, int intRow)
		{
			return (Control)LayoutSettings.GetControlFromPosition(intColumn, intRow);
		}

		/// 
		/// Gets the position from control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		public TableLayoutPanelCellPosition GetPositionFromControl(Control objControl)
		{
			return LayoutSettings.GetPositionFromControl(objControl);
		}

		/// 
		/// Gets the row.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(-1)]
		[SRDescription("GridPanelRowDescr")]
		[SRCategory("CatLayout")]
		[DisplayName("Row")]
		public int GetRow(Control objControl)
		{
			return LayoutSettings.GetRow(objControl);
		}

		/// 
		/// Gets the row heights.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int[] GetRowHeights()
		{
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			if (containerInfo.Rows == null)
			{
				return new int[0];
			}
			int[] array = new int[containerInfo.Rows.Length];
			for (int i = 0; i < containerInfo.Rows.Length; i++)
			{
				array[i] = containerInfo.Rows[i].MinSize;
			}
			return array;
		}

		/// 
		/// Gets the row span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		[SRDescription("GridPanelGetRowSpanDescr")]
		[DefaultValue(1)]
		[SRCategory("CatLayout")]
		[DisplayName("RowSpan")]
		public int GetRowSpan(Control objControl)
		{
			return LayoutSettings.GetRowSpan(objControl);
		}

		/// 
		/// Sets the cell position.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="objPosition">The position.</param>
		public void SetCellPosition(Control objControl, TableLayoutPanelCellPosition objPosition)
		{
			LayoutSettings.SetCellPosition(objControl, objPosition);
			FireObservableItemPropertyChanged("CellPosition", objControl);
			Update();
		}

		/// 
		/// Sets the column.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intColumn">The column.</param>
		public void SetColumn(Control objControl, int intColumn)
		{
			LayoutSettings.SetColumn(objControl, intColumn);
			FireObservableItemPropertyChanged("Column", objControl);
			Update();
		}

		/// 
		/// Sets the column span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intValue">The value.</param>
		public void SetColumnSpan(Control objControl, int intValue)
		{
			LayoutSettings.SetColumnSpan(objControl, intValue);
			FireObservableItemPropertyChanged("ColumnSpan", objControl);
			Update();
		}

		/// 
		/// Sets the row.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intRow">The row.</param>
		public void SetRow(Control objControl, int intRow)
		{
			LayoutSettings.SetRow(objControl, intRow);
			FireObservableItemPropertyChanged("Row", objControl);
			Update();
		}

		/// 
		/// Sets the row span.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="intValue">The value.</param>
		public void SetRowSpan(Control objControl, int intValue)
		{
			LayoutSettings.SetRowSpan(objControl, intValue);
			FireObservableItemPropertyChanged("RowSpan", objControl);
			Update();
		}

		/// 
		/// Creates the controls instance.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected override ControlCollection CreateControlsInstance()
		{
			return new TableLayoutControlCollection(this);
		}

		/// 
		/// Raises the <see cref="E:CellPaint" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.TableLayoutCellPaintEventArgs" /> instance containing the event data.</param>
		protected virtual void OnCellPaint(TableLayoutCellPaintEventArgs e)
		{
			((TableLayoutCellPaintEventHandler)GetHandler(EventCellPaintEvent))?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Layout" /> event.
		/// </summary>
		/// <param name="objLevent">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected new void OnLayout(LayoutEventArgs objLevent)
		{
			Invalidate();
		}

		/// 
		/// Raises the <see cref="E:PaintBackground" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> instance containing the event data.</param>
		protected void OnPaintBackground(PaintEventArgs e)
		{
			int cellBorderWidth = CellBorderWidth;
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			TableLayout.Strip[] columns = containerInfo.Columns;
			TableLayout.Strip[] rows = containerInfo.Rows;
			TableLayoutPanelCellBorderStyle cellBorderStyle = CellBorderStyle;
			if (columns == null || rows == null)
			{
				return;
			}
			int num = columns.Length;
			int num2 = rows.Length;
			int num3 = 0;
			int num4 = 0;
			Graphics graphics = e.Graphics;
			Rectangle rectangle = new Rectangle(base.Location, base.Size);
			Rectangle clipRectangle = e.ClipRectangle;
			bool flag = RightToLeft == RightToLeft.Yes;
			int num5 = ((!flag) ? (rectangle.X + cellBorderWidth / 2) : (rectangle.Right - cellBorderWidth / 2));
			for (int i = 0; i < num; i++)
			{
				int num6 = rectangle.Y + cellBorderWidth / 2;
				if (flag)
				{
					num5 -= columns[i].MinSize;
				}
				for (int j = 0; j < num2; j++)
				{
					Rectangle rectangle2 = new Rectangle(num5, num6, columns[i].MinSize, rows[j].MinSize);
					Rectangle rectangle3 = new Rectangle(rectangle2.X + (cellBorderWidth + 1) / 2, rectangle2.Y + (cellBorderWidth + 1) / 2, rectangle2.Width - (cellBorderWidth + 1) / 2, rectangle2.Height - (cellBorderWidth + 1) / 2);
					if (clipRectangle.IntersectsWith(rectangle3))
					{
						TableLayoutCellPaintEventArgs e2 = new TableLayoutCellPaintEventArgs(graphics, clipRectangle, rectangle3, i, j);
						OnCellPaint(e2);
					}
					num6 += rows[j].MinSize;
					if (i == 0)
					{
						num4 += rows[j].MinSize;
					}
				}
				if (!flag)
				{
					num5 += columns[i].MinSize;
				}
				num3 += columns[i].MinSize;
			}
			Rectangle rectangle4 = new Rectangle(cellBorderWidth / 2 + rectangle.X, cellBorderWidth / 2 + rectangle.Y, rectangle.Width - cellBorderWidth, rectangle.Height - cellBorderWidth);
			switch (cellBorderStyle)
			{
			case TableLayoutPanelCellBorderStyle.Inset:
				graphics.DrawLine(SystemPens.ControlDark, rectangle4.Right, rectangle4.Y, rectangle4.Right, rectangle4.Bottom);
				graphics.DrawLine(SystemPens.ControlDark, rectangle4.X, rectangle4.Y + rectangle4.Height - 1, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
				break;
			case TableLayoutPanelCellBorderStyle.Outset:
			{
				using Pen pen = new Pen(SystemColors.Window);
				graphics.DrawLine(pen, rectangle4.X + rectangle4.Width - 1, rectangle4.Y, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
				graphics.DrawLine(pen, rectangle4.X, rectangle4.Y + rectangle4.Height - 1, rectangle4.X + rectangle4.Width - 1, rectangle4.Y + rectangle4.Height - 1);
				break;
			}
			}
		}

		/// 
		/// Gets the calculated height of the control.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		internal float GetControlCalculatedHeight(Control objControl, bool blnUseLayoutValues)
		{
			float num = 0f;
			if (objControl != null)
			{
				int row = GetRow(objControl);
				if (row >= 0)
				{
					int rowSpan = GetRowSpan(objControl);
					float num2 = GetCalculatedHeight(blnUseLayoutValues);
					float num3 = 0f;
					float num4 = 0f;
					int rowCount = RowCount;
					foreach (RowStyle item in (IEnumerable)RowStyles)
					{
						if (RowStyles.IndexOf(item) < rowCount)
						{
							if (item.SizeType == SizeType.Absolute)
							{
								num3 += item.Height;
							}
							else if (item.SizeType == SizeType.Percent)
							{
								num4 += item.Height;
							}
						}
					}
					for (int i = 0; i < rowSpan; i++)
					{
						if (row + i < RowStyles.Count)
						{
							RowStyle rowStyle2 = RowStyles[row + i];
							if (rowStyle2 == null || RowStyles.IndexOf(rowStyle2) >= rowCount)
							{
								continue;
							}
							switch (rowStyle2.SizeType)
							{
							case SizeType.Absolute:
								num += rowStyle2.Height;
								break;
							case SizeType.Percent:
								if (num2 > num3)
								{
									float num5 = rowStyle2.Height;
									if (num4 < 100f)
									{
										num5 += (100f - num4) * num5 / 100f;
									}
									num += (num2 - num3) * num5 / 100f;
								}
								break;
							}
						}
						else if (i == 0)
						{
							num += (float)objControl.LayoutHeight;
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Gets the calculated width of the control.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		internal float GetControlCalculatedWidth(Control objControl, bool blnUseLayoutValues)
		{
			float num = 0f;
			if (objControl != null)
			{
				int column = GetColumn(objControl);
				if (column >= 0)
				{
					int columnSpan = GetColumnSpan(objControl);
					float num2 = GetCalculatedWidth(blnUseLayoutValues);
					float num3 = 0f;
					float num4 = 0f;
					int columnCount = ColumnCount;
					foreach (ColumnStyle item in (IEnumerable)ColumnStyles)
					{
						if (ColumnStyles.IndexOf(item) < columnCount)
						{
							if (item.SizeType == SizeType.Absolute)
							{
								num4 += item.Width;
							}
							else if (item.SizeType == SizeType.Percent)
							{
								num3 += item.Width;
							}
						}
					}
					for (int i = 0; i < columnSpan; i++)
					{
						if (column + i < ColumnStyles.Count)
						{
							ColumnStyle columnStyle2 = ColumnStyles[column + i];
							if (columnStyle2 == null || ColumnStyles.IndexOf(columnStyle2) >= columnCount)
							{
								continue;
							}
							switch (columnStyle2.SizeType)
							{
							case SizeType.Absolute:
								num += columnStyle2.Width;
								break;
							case SizeType.Percent:
								if (num2 > num4)
								{
									float num5 = columnStyle2.Width;
									if (num3 < 100f)
									{
										num5 += (100f - num3) * num5 / 100f;
									}
									num += (num2 - num4) * num5 / 100f;
								}
								break;
							}
						}
						else if (i == 0)
						{
							num += (float)objControl.LayoutWidth;
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Gets the control calculated left.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		internal float GetControlCalculatedLeft(Control objControl, bool blnUseLayoutValues)
		{
			float num = GetCalculatedLeft(blnUseLayoutValues);
			if (objControl != null)
			{
				int column = GetColumn(objControl);
				if (column >= 0)
				{
					int columnSpan = GetColumnSpan(objControl);
					int calculatedWidth = GetCalculatedWidth(blnUseLayoutValues);
					float num2 = 0f;
					float num3 = 0f;
					int columnCount = ColumnCount;
					foreach (ColumnStyle item in (IEnumerable)ColumnStyles)
					{
						if (ColumnStyles.IndexOf(item) < columnCount)
						{
							if (item.SizeType == SizeType.Absolute)
							{
								num3 += item.Width;
							}
							else if (item.SizeType == SizeType.Percent)
							{
								num2 += item.Width;
							}
						}
					}
					for (int i = 0; i < column; i++)
					{
						if (i >= ColumnStyles.Count)
						{
							continue;
						}
						ColumnStyle columnStyle2 = ColumnStyles[i];
						if (columnStyle2 == null || ColumnStyles.IndexOf(columnStyle2) >= columnCount)
						{
							continue;
						}
						switch (columnStyle2.SizeType)
						{
						case SizeType.Absolute:
							num += columnStyle2.Width;
							break;
						case SizeType.Percent:
						{
							float num4 = columnStyle2.Width;
							if (num2 < 100f)
							{
								num4 += (100f - num2) * num4 / 100f;
							}
							num += (float)calculatedWidth * num4 / 100f;
							break;
						}
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Gets the control calculated top.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		internal float GetControlCalculatedTop(Control objControl, bool blnUseLayoutValues)
		{
			float num = GetCalculatedTop(blnUseLayoutValues);
			if (objControl != null)
			{
				int row = GetRow(objControl);
				if (row >= 0)
				{
					int rowSpan = GetRowSpan(objControl);
					int calculatedHeight = GetCalculatedHeight(blnUseLayoutValues);
					float num2 = 0f;
					float num3 = 0f;
					int rowCount = RowCount;
					foreach (RowStyle item in (IEnumerable)RowStyles)
					{
						if (RowStyles.IndexOf(item) < rowCount)
						{
							if (item.SizeType == SizeType.Absolute)
							{
								num3 += item.Height;
							}
							else if (item.SizeType == SizeType.Percent)
							{
								num2 += item.Height;
							}
						}
					}
					for (int i = 0; i < row; i++)
					{
						if (i >= RowStyles.Count)
						{
							continue;
						}
						RowStyle rowStyle2 = RowStyles[i];
						if (rowStyle2 == null || RowStyles.IndexOf(rowStyle2) >= rowCount)
						{
							continue;
						}
						switch (rowStyle2.SizeType)
						{
						case SizeType.Absolute:
							num += rowStyle2.Height;
							break;
						case SizeType.Percent:
						{
							float num4 = rowStyle2.Height;
							if (num2 < 100f)
							{
								num4 += (100f - num2) * num4 / 100f;
							}
							num += (float)calculatedHeight * num4 / 100f;
							break;
						}
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Scales the control.
		/// </summary>
		/// <param name="objFactor">The factor.</param>
		/// <param name="enmSpecified">The specified.</param>
		protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified)
		{
			ScaleAbsoluteStyles(objFactor);
		}

		/// 
		/// Gets a numbers string.
		/// </summary>
		/// <param name="intFrom">Int from.</param>
		/// <param name="intTo">Int to.</param>
		/// </returns>
		private string GetNumbers(int intFrom, int intTo)
		{
			string[] array = new string[intTo - intFrom + 1];
			for (int i = intFrom; i <= intTo; i++)
			{
				array[i - intFrom] = i.ToString();
			}
			return string.Join(",", array);
		}

		/// 
		/// Gets a control position.
		/// </summary>
		/// <param name="objControl">Obj control.</param>
		/// </returns>
		private TableLayoutControlPosition GetControlPosition(Control objControl)
		{
			TableLayoutControlPosition tableLayoutControlPosition = new TableLayoutControlPosition();
			tableLayoutControlPosition.Control = objControl;
			tableLayoutControlPosition.Column = GetColumn(objControl);
			tableLayoutControlPosition.Row = GetRow(objControl);
			tableLayoutControlPosition.Colspan = GetColumnSpan(objControl);
			tableLayoutControlPosition.Rowspan = GetRowSpan(objControl);
			return tableLayoutControlPosition;
		}

		bool IExtenderProvider.CanExtend(object obj)
		{
			if (obj is Control control)
			{
				return control.Parent == this;
			}
			return false;
		}

		private void ScaleAbsoluteStyles(SizeF objFactor)
		{
			TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(this);
			int num = 0;
			int num2 = -1;
			int num3 = containerInfo.Rows.Length - 1;
			if (containerInfo.Rows.Length != 0)
			{
				num2 = containerInfo.Rows[num3].MinSize;
			}
			int num4 = -1;
			int num5 = containerInfo.Columns.Length - 1;
			if (containerInfo.Columns.Length != 0)
			{
				num4 = containerInfo.Columns[containerInfo.Columns.Length - 1].MinSize;
			}
			foreach (ColumnStyle item in (IEnumerable)ColumnStyles)
			{
				if (item.SizeType == SizeType.Absolute)
				{
					if (num == num5 && num4 > 0)
					{
						item.Width = (float)Math.Round((float)num4 * objFactor.Width);
					}
					else
					{
						item.Width = (float)Math.Round(item.Width * objFactor.Width);
					}
				}
				num++;
			}
			num = 0;
			foreach (RowStyle item2 in (IEnumerable)RowStyles)
			{
				if (item2.SizeType == SizeType.Absolute)
				{
					if (num == num3 && num2 > 0)
					{
						item2.Height = (float)Math.Round((float)num2 * objFactor.Height);
					}
					else
					{
						item2.Height = (float)Math.Round(item2.Height * objFactor.Height);
					}
				}
			}
		}

		private bool ShouldSerializeControls()
		{
			TableLayoutControlCollection controls = Controls;
			if (controls != null)
			{
				return controls.Count > 0;
			}
			return false;
		}
	}
}
