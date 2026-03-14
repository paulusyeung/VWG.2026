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
/// Represents a linear collection of elements in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewBand : DataGridViewElement, ICloneable, IDisposable
	{
		private int mintMinimumThickness;

		private int mintBandIndex;

		private int mintThickness;

		private int mintCachedThickness;

		private bool mblnBandIsRow;

		private DataGridViewCellStyle mobjDefaultCellStyle;

		private object mobjTag = null;

		private DataGridViewHeaderCell mobjHeaderCell = null;

		private Type mobjDefaultHeaderCellType = null;

		private ContextMenu mobjContextMenu = null;

		private ContextMenuStrip mobjContextMenuStrip = null;

		/// Gets or sets the default cell style of the band.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				if (mobjDefaultCellStyle == null)
				{
					mobjDefaultCellStyle = new DataGridViewCellStyle();
					mobjDefaultCellStyle.AddScope(base.DataGridView, IsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
				}
				return mobjDefaultCellStyle;
			}
			set
			{
				DataGridViewCellStyle dataGridViewCellStyle = null;
				bool isRow = IsRow;
				if (HasDefaultCellStyle)
				{
					dataGridViewCellStyle = DefaultCellStyle;
					dataGridViewCellStyle.RemoveScope(isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
				}
				DataGridView dataGridView = base.DataGridView;
				if (value != null || mobjDefaultCellStyle != null)
				{
					value?.AddScope(dataGridView, isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
					mobjDefaultCellStyle = value;
				}
				if ((dataGridViewCellStyle != null && value == null) || (dataGridViewCellStyle == null && value != null) || (dataGridViewCellStyle != null && value != null && !dataGridViewCellStyle.Equals(DefaultCellStyle)))
				{
					dataGridView?.OnBandDefaultCellStyleChanged(this);
				}
			}
		}

		/// 
		/// Gets or sets the run-time type of the default header cell.
		/// </summary>
		/// The type of the default header cell.</value>
		/// A <see cref="T:System.Type"></see> that describes the run-time class of the object used as the default header cell.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:System.Type"></see> representing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> or a derived type. </exception>
		[Browsable(false)]
		public Type DefaultHeaderCellType
		{
			get
			{
				Type type = mobjDefaultHeaderCellType;
				if (type != null)
				{
					return type;
				}
				if (IsRow)
				{
					return typeof(DataGridViewRowHeaderCell);
				}
				return typeof(DataGridViewColumnHeaderCell);
			}
			set
			{
				if (value != null || mobjDefaultHeaderCellType != null)
				{
					if (!Type.GetType("Gizmox.WebGUI.Forms.DataGridViewHeaderCell").IsAssignableFrom(value))
					{
						throw new ArgumentException(SR.GetString("DataGridView_WrongType", "DefaultHeaderCellType", "Gizmox.WebGUI.Forms.DataGridViewHeaderCell"));
					}
					mobjDefaultHeaderCellType = value;
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has header cell.
		/// </summary>
		/// 
		/// 	true</c> if this instance has header cell; otherwise, false</c>.
		/// </value>
		internal virtual bool HasHeaderCell => mobjHeaderCell != null;

		/// 
		/// Gets or sets the cached thickness.
		/// </summary>
		/// The cached thickness.</value>
		internal int CachedThickness
		{
			get
			{
				return mintCachedThickness;
			}
			set
			{
				mintCachedThickness = value;
			}
		}

		/// Gets a value indicating whether the band is currently displayed onscreen. </summary>
		/// true if the band is currently onscreen; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Displayed => (State & DataGridViewElementStates.Displayed) != 0;

		/// Gets or sets a value indicating whether the band will move when a user scrolls through the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// true if the band cannot be scrolled from view; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public virtual bool Frozen
		{
			get
			{
				return (State & DataGridViewElementStates.Frozen) != 0;
			}
			set
			{
				if ((State & DataGridViewElementStates.Frozen) != 0 != value)
				{
					OnStateChanging(DataGridViewElementStates.Frozen);
					if (value)
					{
						base.StateInternal = State | DataGridViewElementStates.Frozen;
					}
					else
					{
						base.StateInternal = State & ~DataGridViewElementStates.Frozen;
					}
					OnStateChanged(DataGridViewElementStates.Frozen);
				}
			}
		}

		/// Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set. </summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool HasDefaultCellStyle => mobjDefaultCellStyle != null;

		/// Gets or sets the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> representing the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.-or-The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		protected DataGridViewHeaderCell HeaderCellCore
		{
			get
			{
				DataGridViewHeaderCell dataGridViewHeaderCell = mobjHeaderCell;
				if (dataGridViewHeaderCell == null)
				{
					DataGridView dataGridView = base.DataGridView;
					dataGridViewHeaderCell = (DataGridViewHeaderCell)Activator.CreateInstance(DefaultHeaderCellType);
					dataGridViewHeaderCell.DataGridViewInternal = dataGridView;
					if (IsRow)
					{
						dataGridViewHeaderCell.OwningRowInternal = (DataGridViewRow)this;
						mobjHeaderCell = dataGridViewHeaderCell;
						return dataGridViewHeaderCell;
					}
					DataGridViewColumn dataGridViewColumn = (dataGridViewHeaderCell.OwningColumnInternal = this as DataGridViewColumn);
					mobjHeaderCell = dataGridViewHeaderCell;
					if (dataGridView != null && dataGridView.SortedColumn == dataGridViewColumn)
					{
						DataGridViewColumnHeaderCell dataGridViewColumnHeaderCell = dataGridViewHeaderCell as DataGridViewColumnHeaderCell;
						dataGridViewColumnHeaderCell.SortGlyphDirection = dataGridView.SortOrder;
					}
				}
				return dataGridViewHeaderCell;
			}
			set
			{
				DataGridView dataGridView = base.DataGridView;
				DataGridViewHeaderCell dataGridViewHeaderCell = mobjHeaderCell;
				bool isRow = IsRow;
				if (value != null || dataGridViewHeaderCell != null)
				{
					if (dataGridViewHeaderCell != null)
					{
						dataGridViewHeaderCell.DataGridViewInternal = null;
						if (isRow)
						{
							dataGridViewHeaderCell.OwningRowInternal = null;
						}
						else
						{
							dataGridViewHeaderCell.OwningColumnInternal = null;
							((DataGridViewColumnHeaderCell)dataGridViewHeaderCell).SortGlyphDirectionInternal = SortOrder.None;
						}
					}
					if (value != null)
					{
						if (isRow)
						{
							if (!(value is DataGridViewRowHeaderCell))
							{
								throw new ArgumentException(SR.GetString("DataGridView_WrongType", "HeaderCell", "Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"));
							}
							if (value.OwningRow != null)
							{
								value.OwningRow.HeaderCell = null;
							}
							value.OwningRowInternal = (DataGridViewRow)this;
						}
						else
						{
							if (!(value is DataGridViewColumnHeaderCell))
							{
								throw new ArgumentException(SR.GetString("DataGridView_WrongType", "HeaderCell", "Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"));
							}
							if (value.OwningColumn != null)
							{
								value.OwningColumn.HeaderCell = null;
							}
							value.OwningColumnInternal = (DataGridViewColumn)this;
						}
						value.DataGridViewInternal = dataGridView;
					}
					mobjHeaderCell = value;
				}
				if ((value == null && dataGridViewHeaderCell != null) || (value != null && dataGridViewHeaderCell == null) || (value != null && dataGridViewHeaderCell != null && !dataGridViewHeaderCell.Equals(value)))
				{
					dataGridView?.OnBandHeaderCellChanged(this);
				}
			}
		}

		/// Gets the relative position of the band within the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// The zero-based position of the band in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> or <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> that it is contained within. The default is -1, indicating that there is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public int Index => mintBandIndex;

		/// 
		/// Sets the index internal.
		/// </summary>
		/// The index internal.</value>
		internal int IndexInternal
		{
			set
			{
				mintBandIndex = value;
			}
		}

		/// 
		/// Sets a value indicating whether [displayed internal].
		/// </summary>
		/// true</c> if [displayed internal]; otherwise, false</c>.</value>
		internal bool DisplayedInternal
		{
			set
			{
				if (value)
				{
					base.StateInternal = State | DataGridViewElementStates.Displayed;
				}
				else
				{
					base.StateInternal = State & ~DataGridViewElementStates.Displayed;
				}
				if (base.DataGridView != null)
				{
					OnStateChanged(DataGridViewElementStates.Displayed);
				}
			}
		}

		/// 
		/// Sets a value indicating whether [read only internal].
		/// </summary>
		/// true</c> if [read only internal]; otherwise, false</c>.</value>
		internal bool ReadOnlyInternal
		{
			set
			{
				if (value)
				{
					base.StateInternal = State | DataGridViewElementStates.ReadOnly;
				}
				else
				{
					base.StateInternal = State & ~DataGridViewElementStates.ReadOnly;
				}
				OnStateChanged(DataGridViewElementStates.ReadOnly);
			}
		}

		/// 
		/// Sets a value indicating whether [selected internal].
		/// </summary>
		/// true</c> if [selected internal]; otherwise, false</c>.</value>
		internal bool SelectedInternal
		{
			set
			{
				if (value)
				{
					base.StateInternal = State | DataGridViewElementStates.Selected;
				}
				else
				{
					base.StateInternal = State & ~DataGridViewElementStates.Selected;
				}
				if (base.DataGridView != null)
				{
					OnStateChanged(DataGridViewElementStates.Selected);
				}
			}
		}

		/// Gets the cell style in effect for the current band, taking into account style inheritance.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>. The default is null.</returns>
		[Browsable(false)]
		public virtual DataGridViewCellStyle InheritedStyle => null;

		/// Gets a value indicating whether the band represents a row.</summary>
		/// true if the band represents a <see cref="T:System.Windows.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
		protected bool IsRow => BandIsRow;

		/// Gets a value indicating whether the band represents a row.</summary>
		/// true if the band represents a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
		protected bool BandIsRow
		{
			get
			{
				return mblnBandIsRow;
			}
			set
			{
				mblnBandIsRow = value;
			}
		}

		/// 
		/// Gets or sets the thickness internal.
		/// </summary>
		/// The thickness internal.</value>
		internal int ThicknessInternal
		{
			get
			{
				return mintThickness;
			}
			set
			{
				mintThickness = value;
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null)
				{
					UpdateParams(AttributeType.Layout);
					dataGridView.Update(blnRedrawOnly: true);
					dataGridView.OnBandThicknessChanged(this);
				}
			}
		}

		/// 
		/// Gets or sets the thickness.
		/// </summary>
		/// The thickness.</value>
		internal int Thickness
		{
			get
			{
				int index = Index;
				if (IsRow && index > -1)
				{
					GetHeightInfo(index, out var intHeight, out var _);
					return intHeight;
				}
				return mintThickness;
			}
			set
			{
				DataGridView dataGridView = base.DataGridView;
				int minimumThickness = MinimumThickness;
				bool isRow = IsRow;
				if (value < minimumThickness)
				{
					value = minimumThickness;
				}
				if (value > 65536)
				{
					if (isRow)
					{
						object[] arrArgs = new object[3]
						{
							"Height",
							value.ToString(CultureInfo.CurrentCulture),
							65536.ToString(CultureInfo.CurrentCulture)
						};
						throw new ArgumentOutOfRangeException("Height", SR.GetString("InvalidHighBoundArgumentEx", arrArgs));
					}
					object[] arrArgs2 = new object[3]
					{
						"Width",
						value.ToString(CultureInfo.CurrentCulture),
						65536.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("Width", SR.GetString("InvalidHighBoundArgumentEx", arrArgs2));
				}
				bool flag = true;
				if (isRow)
				{
					if (dataGridView != null && dataGridView.AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
					{
						CachedThickness = value;
						flag = false;
					}
				}
				else
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)this;
					DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = dataGridViewColumn.InheritedAutoSizeMode;
					if (inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
					{
						CachedThickness = value;
						flag = false;
					}
					else if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && dataGridView != null && dataGridViewColumn.Visible)
					{
						IntPtr handle = dataGridView.Handle;
						dataGridView.AdjustFillingColumn(dataGridViewColumn, value);
						flag = false;
					}
				}
				if (flag && mintThickness != value)
				{
					dataGridView?.OnBandThicknessChanging();
					ThicknessInternal = value;
				}
			}
		}

		/// 
		/// Gets or sets the minimum thickness.
		/// </summary>
		/// The minimum thickness.</value>
		internal int MinimumThickness
		{
			get
			{
				int index = Index;
				if (IsRow && index > -1)
				{
					GetHeightInfo(index, out var _, out var intMinimumHeight);
					return intMinimumHeight;
				}
				return mintMinimumThickness;
			}
			set
			{
				if (mintMinimumThickness == value)
				{
					return;
				}
				DataGridView dataGridView = base.DataGridView;
				bool isRow = IsRow;
				if (value < 2)
				{
					if (isRow)
					{
						object[] arrArgs = new object[1] { 2.ToString(CultureInfo.CurrentCulture) };
						throw new ArgumentOutOfRangeException("MinimumHeight", value, SR.GetString("DataGridViewBand_MinimumHeightSmallerThanOne", arrArgs));
					}
					object[] arrArgs2 = new object[1] { 2.ToString(CultureInfo.CurrentCulture) };
					throw new ArgumentOutOfRangeException("MinimumWidth", value, SR.GetString("DataGridViewBand_MinimumWidthSmallerThanOne", arrArgs2));
				}
				if (Thickness < value)
				{
					if (dataGridView != null && !isRow)
					{
						dataGridView.OnColumnMinimumWidthChanging((DataGridViewColumn)this, value);
					}
					Thickness = value;
				}
				mintMinimumThickness = value;
				dataGridView?.OnBandMinimumThicknessChanged(this);
			}
		}

		/// Gets or sets a value indicating whether the user can edit the band's cells.</summary>
		/// true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// 1</filterpriority>
		[DefaultValue(false)]
		public virtual bool ReadOnly
		{
			get
			{
				DataGridView dataGridView = base.DataGridView;
				return (State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || (dataGridView?.ReadOnly ?? false);
			}
			set
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null)
				{
					if (dataGridView.ReadOnly)
					{
						return;
					}
					if (BandIsRow)
					{
						if (Index == -1)
						{
							throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "ReadOnly"));
						}
						OnStateChanging(DataGridViewElementStates.ReadOnly);
						dataGridView.SetReadOnlyRowCore(Index, value);
					}
					else
					{
						OnStateChanging(DataGridViewElementStates.ReadOnly);
						dataGridView.SetReadOnlyColumnCore(Index, value);
					}
				}
				else if ((State & DataGridViewElementStates.ReadOnly) != 0 != value)
				{
					if (value)
					{
						if (BandIsRow)
						{
							foreach (DataGridViewCell cell in ((DataGridViewRow)this).Cells)
							{
								if (cell.ReadOnly)
								{
									cell.ReadOnlyInternal = false;
								}
							}
						}
						base.StateInternal = State | DataGridViewElementStates.ReadOnly;
					}
					else
					{
						base.StateInternal = State & ~DataGridViewElementStates.ReadOnly;
					}
				}
				ElementReadOnly = ((!value) ? ElementReadOnlyType.False : ElementReadOnlyType.True);
			}
		}

		/// 
		/// Gets or sets the element read only.
		/// </summary>
		/// The element read only.</value>
		protected internal override ElementReadOnlyType ElementReadOnly
		{
			get
			{
				return base.ElementReadOnly;
			}
			set
			{
				base.ElementReadOnly = value;
				if (BandIsRow)
				{
					foreach (DataGridViewCell cell in ((DataGridViewRow)this).Cells)
					{
						cell.ClearElementReadOnly();
					}
					return;
				}
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView == null)
				{
					return;
				}
				int index = Index;
				if (index < 0 || index >= dataGridView.Columns.Count)
				{
					return;
				}
				DataGridViewRowCollection rows = dataGridView.Rows;
				foreach (DataGridViewRow item in (IEnumerable)rows)
				{
					item.Cells[index].ClearElementReadOnly();
				}
			}
		}

		/// Gets or sets a value indicating whether the band can be resized in the user interface (UI).</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(true)]
		public virtual DataGridViewTriState Resizable
		{
			get
			{
				if ((State & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
				{
					if ((State & DataGridViewElementStates.Resizable) == 0)
					{
						return DataGridViewTriState.False;
					}
					return DataGridViewTriState.True;
				}
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView == null)
				{
					return DataGridViewTriState.NotSet;
				}
				if (!dataGridView.AllowUserToResizeColumns)
				{
					return DataGridViewTriState.False;
				}
				return DataGridViewTriState.True;
			}
			set
			{
				DataGridViewTriState resizable = Resizable;
				if (value == DataGridViewTriState.NotSet)
				{
					base.StateInternal = State & ~DataGridViewElementStates.ResizableSet;
				}
				else
				{
					base.StateInternal = State | DataGridViewElementStates.ResizableSet;
					if ((State & DataGridViewElementStates.Resizable) != 0 != (value == DataGridViewTriState.True))
					{
						if (value == DataGridViewTriState.True)
						{
							base.StateInternal = State | DataGridViewElementStates.Resizable;
						}
						else
						{
							base.StateInternal = State & ~DataGridViewElementStates.Resizable;
						}
					}
				}
				if (resizable != Resizable)
				{
					OnStateChanged(DataGridViewElementStates.Resizable);
				}
			}
		}

		/// Gets or sets a value indicating whether the band is in a selected user interface (UI) state.</summary>
		/// true if the band is selected; otherwise, false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is true, but the band has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. -or-This property is being set on a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual bool Selected
		{
			get
			{
				return (State & DataGridViewElementStates.Selected) != 0;
			}
			set
			{
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView != null)
				{
					int index = Index;
					if (!IsRow)
					{
						if (dataGridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect || dataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
						{
							dataGridView.SetSelectedColumnCoreInternal(index, value);
						}
						return;
					}
					if (index == -1)
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", "Selected"));
					}
					if (dataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect || dataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
					{
						dataGridView.SetSelectedRowCoreInternal(index, value);
					}
				}
				else if (value)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewBand_CannotSelect"));
				}
			}
		}

		/// Gets or sets the object that contains data to associate with the band.</summary>
		/// An <see cref="T:System.Object"></see> that contains information associated with the band. The default is null.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object Tag
		{
			get
			{
				return mobjTag;
			}
			set
			{
				mobjTag = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether the band is visible to the user.
		/// </summary>
		/// true</c> if visible; otherwise, false</c>.</value>
		/// true if the band is visible; otherwise, false. The default is true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and the band is the row for new records.</exception>
		[DefaultValue(true)]
		public virtual bool Visible
		{
			get
			{
				return (State & DataGridViewElementStates.Visible) != 0;
			}
			set
			{
				if ((State & DataGridViewElementStates.Visible) != 0 != value)
				{
					DataGridView dataGridView = base.DataGridView;
					if (dataGridView != null && IsRow && dataGridView.NewRowIndex != -1 && dataGridView.NewRowIndex == Index && !value)
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewBand_NewRowCannotBeInvisible"));
					}
					OnStateChanging(DataGridViewElementStates.Visible);
					SetVisibleInternal(value);
					OnStateChanged(DataGridViewElementStates.Visible);
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has default header cell type.
		/// </summary>
		/// 
		/// 	true</c> if this instance has default header cell type; otherwise, false</c>.
		/// </value>
		internal bool HasDefaultHeaderCellType => mobjDefaultHeaderCellType != null;

		/// 
		/// Gets or sets the context menu code.  
		/// </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		public virtual ContextMenu ContextMenu
		{
			get
			{
				if (IsRow)
				{
					return ((DataGridViewRow)this).GetContextMenu(Index);
				}
				return ContextMenuInternal;
			}
			set
			{
				ContextMenuInternal = value;
			}
		}

		/// 
		/// Gets or sets the context menu strip.
		/// </summary>
		/// The context menu strip.</value>
		[DefaultValue(null)]
		public virtual ContextMenuStrip ContextMenuStrip
		{
			get
			{
				if (BandIsRow)
				{
					return ((DataGridViewRow)this).GetContextMenuStrip(Index);
				}
				return ContextMenuStripInternal;
			}
			set
			{
				ContextMenuStripInternal = value;
			}
		}

		/// 
		/// Gets or sets the context menu internal.
		/// </summary>
		/// The context menu internal.</value>
		internal ContextMenu ContextMenuInternal
		{
			get
			{
				return mobjContextMenu;
			}
			set
			{
				ContextMenu contextMenu = mobjContextMenu;
				if (contextMenu != value)
				{
					EventHandler value2 = DetachContextMenu;
					if (contextMenu != null)
					{
						contextMenu.Disposed -= value2;
					}
					mobjContextMenu = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					base.DataGridView?.OnBandContextMenuChanged(this);
				}
			}
		}

		/// 
		/// Gets or sets the context menu strip internal.
		/// </summary>
		/// The context menu strip internal.</value>
		internal ContextMenuStrip ContextMenuStripInternal
		{
			get
			{
				return mobjContextMenuStrip;
			}
			set
			{
				ContextMenuStrip contextMenuStrip = mobjContextMenuStrip;
				if (contextMenuStrip != value)
				{
					EventHandler value2 = DetachContextMenuStrip;
					if (contextMenuStrip != null)
					{
						contextMenuStrip.Disposed -= value2;
					}
					mobjContextMenuStrip = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					base.DataGridView?.OnBandContextMenuStripChanged(this);
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand" /> class.
		/// </summary>
		internal DataGridViewBand()
		{
			IndexInternal = -1;
		}

		/// Called when the band is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		protected override void OnDataGridViewChanged()
		{
			if (HasDefaultCellStyle)
			{
				bool isRow = IsRow;
				DataGridView dataGridView = base.DataGridView;
				if (dataGridView == null)
				{
					DefaultCellStyle.RemoveScope(isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
				}
				else
				{
					DefaultCellStyle.AddScope(dataGridView, isRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
				}
			}
			base.OnDataGridViewChanged();
		}

		/// 
		/// Called when [state changed].
		/// </summary>
		/// <param name="elementState">State of the element.</param>
		internal void OnStateChanged(DataGridViewElementStates elementState)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				return;
			}
			if (IsRow)
			{
				DataGridViewRowCollection rows = dataGridView.Rows;
				rows.InvalidateCachedRowCount(elementState);
				rows.InvalidateCachedRowsHeight(elementState);
				if (Index != -1)
				{
					dataGridView.OnDataGridViewElementStateChanged(this, -1, elementState);
				}
			}
			else
			{
				DataGridViewColumnCollection columns = dataGridView.Columns;
				columns.InvalidateCachedColumnCount(elementState);
				columns.InvalidateCachedColumnsWidth(elementState);
				dataGridView.OnDataGridViewElementStateChanged(this, -1, elementState);
			}
		}

		/// 
		/// Called when [state changing].
		/// </summary>
		/// <param name="elementState">State of the element.</param>
		private void OnStateChanging(DataGridViewElementStates elementState)
		{
			DataGridView dataGridView = base.DataGridView;
			if (dataGridView == null)
			{
				return;
			}
			if (IsRow)
			{
				if (Index != -1)
				{
					dataGridView.OnDataGridViewElementStateChanging(this, -1, elementState);
				}
			}
			else
			{
				dataGridView.OnDataGridViewElementStateChanging(this, -1, elementState);
			}
		}

		/// 
		/// Raises the <see cref="E:RightClick" /> event.
		/// </summary>
		/// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		internal void OnRightClick(MouseEventArgs objMouseEventArgs)
		{
			ContextMenu contextMenu = ContextMenu;
			if (this is DataGridViewRow)
			{
				contextMenu = ((DataGridViewRow)this).HeaderCell.GetInheritedContextMenu(Index);
			}
			else if (this is DataGridViewColumn)
			{
				contextMenu = ((DataGridViewColumn)this).HeaderCell.GetInheritedContextMenu(Index);
			}
			contextMenu?.Show(base.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "Click")
			{
				int eventValue = GetEventValue(objEvent, "X", 0);
				int eventValue2 = GetEventValue(objEvent, "Y", 0);
				MouseEventArgs e = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0);
				if (e != null && e.Button == MouseButtons.Right)
				{
					OnRightClick(e);
				}
			}
		}

		/// 
		/// Renders the band attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			if (Index >= 0 && Frozen)
			{
				objWriter.WriteAttributeString("FZ", "1");
			}
			if (DataGridViewElement.ShouldRender(RenderMask, Renderable.ContextMenuAttribute))
			{
				ContextMenu contextMenu = ContextMenu;
				if (this is DataGridViewRow)
				{
					contextMenu = ((DataGridViewRow)this).HeaderCell.ContextMenu;
				}
				else if (this is DataGridViewColumn)
				{
					contextMenu = ((DataGridViewColumn)this).HeaderCell.ContextMenu;
				}
				if (contextMenu != null)
				{
					objWriter.WriteAttributeString("M", contextMenu.ID.ToString());
				}
			}
			if (ElementReadOnly == ElementReadOnlyType.True)
			{
				objWriter.WriteAttributeString("RO", "1");
			}
		}

		/// 
		/// Gets the height info.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="intHeight">The height.</param>
		/// <param name="intMinimumHeight">The minimum height.</param>
		internal void GetHeightInfo(int intRowIndex, out int intHeight, out int intMinimumHeight)
		{
			intHeight = mintThickness;
			intMinimumHeight = mintMinimumThickness;
		}

		/// 
		/// Detaches the context menu.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DetachContextMenu(object sender, EventArgs e)
		{
			ContextMenuInternal = null;
		}

		/// 
		/// Detaches the context menu strip.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param> 
		private void DetachContextMenuStrip(object sender, EventArgs e)
		{
			ContextMenuStripInternal = null;
		}

		/// 
		/// Clones the internal.
		/// </summary>
		/// <param name="objDataGridViewBand">The data grid view band.</param>
		internal void CloneInternal(DataGridViewBand objDataGridViewBand)
		{
			objDataGridViewBand.IndexInternal = -1;
			bool flag = (objDataGridViewBand.BandIsRow = IsRow);
			if (!flag || Index >= 0 || base.DataGridView == null)
			{
				objDataGridViewBand.StateInternal = State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
			}
			objDataGridViewBand.Thickness = Thickness;
			objDataGridViewBand.MinimumThickness = MinimumThickness;
			objDataGridViewBand.CachedThickness = CachedThickness;
			objDataGridViewBand.Tag = Tag;
			objDataGridViewBand.LastModified = LastModified;
			objDataGridViewBand.LastModifiedParams = LastModifiedParams;
			if (HasDefaultCellStyle)
			{
				objDataGridViewBand.DefaultCellStyle = new DataGridViewCellStyle(DefaultCellStyle);
			}
			if (HasDefaultHeaderCellType)
			{
				objDataGridViewBand.DefaultHeaderCellType = DefaultHeaderCellType;
			}
		}

		/// Creates an exact copy of this band.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
		/// 1</filterpriority>
		public virtual object Clone()
		{
			DataGridViewBand dataGridViewBand = (DataGridViewBand)Activator.CreateInstance(GetType());
			if (dataGridViewBand != null)
			{
				CloneInternal(dataGridViewBand);
			}
			return dataGridViewBand;
		}

		/// Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.  </summary>
		/// 1</filterpriority>
		public void Dispose()
		{
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> and optionally releases the managed resources.  </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected virtual void Dispose(bool blnDisposing)
		{
		}

		/// Returns a string that represents the current band.</summary>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(36);
			stringBuilder.Append("DataGridViewBand { Index=");
			stringBuilder.Append(Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		/// 
		/// Shoulds serialize DefaultHeaderCellType value.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeDefaultHeaderCellType()
		{
			return mobjDefaultHeaderCellType != null;
		}

		/// 
		/// Shoulds serialize resizable value.
		/// </summary>
		/// </returns>
		internal bool ShouldSerializeResizable()
		{
			return StateIncludes(DataGridViewElementStates.ResizableSet);
		}

		/// 
		/// Sets the thickness internally without invoking the OnRowHeightChanged event.
		/// </summary>
		/// <param name="value">The value.</param>
		internal void SetThicknessInternal(int value)
		{
			mintThickness = value;
		}

		/// 
		/// Sets the visible internal.
		/// </summary>
		/// <param name="blnValue">if set to true</c> [BLN value].</param>
		internal void SetVisibleInternal(bool blnValue)
		{
			if (blnValue)
			{
				base.StateInternal = State | DataGridViewElementStates.Visible;
			}
			else
			{
				base.StateInternal = State & ~DataGridViewElementStates.Visible;
			}
		}
	}
}
