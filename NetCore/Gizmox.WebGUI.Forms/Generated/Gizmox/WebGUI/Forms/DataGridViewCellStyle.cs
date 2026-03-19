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
/// Represents the formatting and style information applied to individual cells within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
	[TypeConverter(typeof(DataGridViewCellStyleConverter))]
	public class DataGridViewCellStyle : SerializableObject, ICloneable
	{
		[Serializable]
		internal enum DataGridViewCellStylePropertyInternal
		{
			Color,
			Other,
			Font,
			ForeColor
		}

		private const string DATAGRIDVIEWCELLSTYLE_nullText = "";

		private DataGridViewCellStyleScopes menmScope;

		private DataGridView mobjDataGridView = null;

		private DataGridViewTriState menmWrapMode = DataGridViewTriState.NotSet;

		private object mobjTag = null;

		private Padding mobjPadding = Padding.Empty;

		private object mobjNullValue = string.Empty;

		private object mobjFormat = null;

		private DataGridViewContentAlignment menmAlignment = DataGridViewContentAlignment.NotSet;

		private Color mobjSelectionForeColor = Color.Empty;

		private Color mobjSelectionBackColor = Color.Empty;

		private object mobjFormatProvider = null;

		private Color mobjForeColor = Color.Empty;

		private SerializableFont mobjFont = null;

		private Color mobjBackColor = Color.Empty;

		private object mobjDataSourceNullValue = DBNull.Value;

		/// 
		/// Gets or sets the data grid view.
		/// </summary>
		/// The data grid view.</value>
		private DataGridView DataGridView
		{
			get
			{
				return mobjDataGridView;
			}
			set
			{
				mobjDataGridView = value;
			}
		}

		/// Gets or sets a value indicating the position of the cell content within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewContentAlignment.NotSet"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> value. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewCellStyleAlignmentDescr")]
		[DefaultValue(DataGridViewContentAlignment.NotSet)]
		[SRCategory("CatLayout")]
		public DataGridViewContentAlignment Alignment
		{
			get
			{
				return menmAlignment;
			}
			set
			{
				switch (value)
				{
				case DataGridViewContentAlignment.NotSet:
				case DataGridViewContentAlignment.TopLeft:
				case DataGridViewContentAlignment.TopCenter:
				case DataGridViewContentAlignment.TopRight:
				case DataGridViewContentAlignment.MiddleLeft:
				case DataGridViewContentAlignment.MiddleCenter:
				case DataGridViewContentAlignment.MiddleRight:
				case DataGridViewContentAlignment.BottomLeft:
				case DataGridViewContentAlignment.BottomCenter:
				case DataGridViewContentAlignment.BottomRight:
					AlignmentInternal = value;
					break;
				default:
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewContentAlignment));
				}
			}
		}

		internal DataGridViewContentAlignment AlignmentInternal
		{
			set
			{
				if (Alignment != value)
				{
					menmAlignment = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		public Color BackColor
		{
			get
			{
				return mobjBackColor;
			}
			set
			{
				_ = mobjBackColor;
				_ = mobjBackColor;
				if (!mobjBackColor.Equals(value))
				{
					mobjBackColor = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
				}
			}
		}

		/// Gets or sets the value saved to the data source when the user enters a null value into a cell.</summary>
		/// The value saved to the data source when the user specifies a null cell value. The default is <see cref="F:System.DBNull.Value"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object DataSourceNullValue
		{
			get
			{
				return mobjDataSourceNullValue;
			}
			set
			{
				object dataSourceNullValue = DataSourceNullValue;
				if (dataSourceNullValue != value && (dataSourceNullValue == null || !dataSourceNullValue.Equals(value)))
				{
					mobjDataSourceNullValue = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
		/// The <see cref="T:System.Drawing.Font"></see> applied to the cell text. The default is null.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		public Font Font
		{
			get
			{
				return mobjFont;
			}
			set
			{
				if ((mobjFont == null && value != null) || (mobjFont != null && !mobjFont.Equals((SerializableFont)value)))
				{
					mobjFont = (SerializableFont)value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Font);
				}
			}
		}

		/// Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		public Color ForeColor
		{
			get
			{
				return mobjForeColor;
			}
			set
			{
				_ = mobjForeColor;
				_ = mobjForeColor;
				if (!mobjForeColor.Equals(value))
				{
					mobjForeColor = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.ForeColor);
				}
			}
		}

		/// Gets or sets the format string applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
		/// A string that indicates the format of the cell value. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// 1</filterpriority>
		[Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DefaultValue("")]
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public string Format
		{
			get
			{
				object obj = mobjFormat;
				if (obj == null)
				{
					return string.Empty;
				}
				return (string)obj;
			}
			set
			{
				string format = Format;
				mobjFormat = value;
				if (!format.Equals(Format))
				{
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// Gets or sets the object used to provide culture-specific formatting of <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell values.</summary>
		/// An <see cref="T:System.IFormatProvider"></see> used for cell formatting. The default is <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"></see>.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public IFormatProvider FormatProvider
		{
			get
			{
				if (mobjFormatProvider == null)
				{
					IContext current = VWGContext.Current;
					if (current != null)
					{
						return current.CurrentUICulture;
					}
				}
				return mobjFormatProvider as IFormatProvider;
			}
			set
			{
				if (value != mobjFormatProvider)
				{
					mobjFormatProvider = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property has been set.</summary>
		/// true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property is the default value; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public bool IsDataSourceNullValueDefault => mobjDataSourceNullValue == DBNull.Value;

		/// Gets a value that indicates whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property has been set.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property is the default value; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsFormatProviderDefault => mobjFormatProvider == null;

		/// Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property has been set.</summary>
		/// true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property is the default value; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public bool IsNullValueDefault => mobjNullValue is string && mobjNullValue.Equals("");

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell display value corresponding to a cell value of <see cref="F:System.DBNull.Value"></see> or null.</summary>
		/// The object used to indicate a null value in a cell. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[DefaultValue("")]
		[TypeConverter(typeof(StringConverter))]
		public object NullValue
		{
			get
			{
				return mobjNullValue;
			}
			set
			{
				object nullValue = NullValue;
				if (mobjNullValue != value)
				{
					mobjNullValue = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// Gets or sets the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</returns>
		/// 1</filterpriority>
		[SRCategory("CatLayout")]
		public Padding Padding
		{
			get
			{
				return mobjPadding;
			}
			set
			{
				if (value.Left < 0 || value.Right < 0 || value.Top < 0 || value.Bottom < 0)
				{
					if (value.All != -1)
					{
						value.All = 0;
					}
					else
					{
						value.Left = Math.Max(0, value.Left);
						value.Right = Math.Max(0, value.Right);
						value.Top = Math.Max(0, value.Top);
						value.Bottom = Math.Max(0, value.Bottom);
					}
				}
				PaddingInternal = value;
			}
		}

		internal Padding PaddingInternal
		{
			set
			{
				if (mobjPadding != value)
				{
					mobjPadding = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// 
		/// Gets or sets the scope.
		/// </summary>
		/// The scope.</value>
		internal DataGridViewCellStyleScopes Scope
		{
			get
			{
				return menmScope;
			}
			set
			{
				menmScope = value;
			}
		}

		/// Gets or sets the background color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		public Color SelectionBackColor
		{
			get
			{
				return mobjSelectionBackColor;
			}
			set
			{
				_ = mobjSelectionBackColor;
				_ = mobjSelectionBackColor;
				if (!mobjSelectionBackColor.Equals(value))
				{
					mobjSelectionBackColor = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
				}
			}
		}

		/// Gets or sets the foreground color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		public Color SelectionForeColor
		{
			get
			{
				return mobjSelectionForeColor;
			}
			set
			{
				_ = mobjSelectionForeColor;
				_ = mobjSelectionForeColor;
				if (!mobjSelectionForeColor.Equals(value))
				{
					mobjSelectionForeColor = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
				}
			}
		}

		/// Gets or sets an object that contains additional data related to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
		/// An object that contains additional data. The default is null.</returns>
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

		/// Gets or sets a value indicating whether textual content in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell is wrapped to subsequent lines or truncated when it is too long to fit on a single line.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.NotSet"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value. </exception>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewTriState.NotSet)]
		[SRCategory("CatLayout")]
		public DataGridViewTriState WrapMode
		{
			get
			{
				return menmWrapMode;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewTriState));
				}
				WrapModeInternal = value;
			}
		}

		internal DataGridViewTriState WrapModeInternal
		{
			set
			{
				if (WrapMode != value)
				{
					menmWrapMode = value;
					OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle" /> class.
		/// </summary>
		public DataGridViewCellStyle()
		{
			Scope = DataGridViewCellStyleScopes.None;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> class using the property values of the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
		/// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used as a template to provide initial property values. </param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
		public DataGridViewCellStyle(DataGridViewCellStyle objDataGridViewCellStyle)
		{
			if (objDataGridViewCellStyle == null)
			{
				throw new ArgumentNullException("dataGridViewCellStyle");
			}
			Scope = DataGridViewCellStyleScopes.None;
			BackColor = objDataGridViewCellStyle.BackColor;
			ForeColor = objDataGridViewCellStyle.ForeColor;
			SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
			SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
			Font = objDataGridViewCellStyle.Font;
			NullValue = objDataGridViewCellStyle.NullValue;
			DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
			Format = objDataGridViewCellStyle.Format;
			if (!objDataGridViewCellStyle.IsFormatProviderDefault)
			{
				FormatProvider = objDataGridViewCellStyle.FormatProvider;
			}
			AlignmentInternal = objDataGridViewCellStyle.Alignment;
			WrapModeInternal = objDataGridViewCellStyle.WrapMode;
			Tag = objDataGridViewCellStyle.Tag;
			PaddingInternal = objDataGridViewCellStyle.Padding;
		}

		/// 
		/// Called when [property changed].
		/// </summary>
		/// <param name="enmProperty">The property.</param>
		private void OnPropertyChanged(DataGridViewCellStylePropertyInternal enmProperty)
		{
			DataGridView dataGridView = DataGridView;
			if (dataGridView != null && Scope != DataGridViewCellStyleScopes.None)
			{
				dataGridView.OnCellStyleContentChanged(this, enmProperty);
			}
		}

		internal void AddScope(DataGridView objDataGridView, DataGridViewCellStyleScopes enmScope)
		{
			Scope |= enmScope;
			DataGridView = objDataGridView;
		}

		/// Applies the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
		/// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
		/// 1</filterpriority>
		public virtual void ApplyStyle(DataGridViewCellStyle objDataGridViewCellStyle)
		{
			if (objDataGridViewCellStyle == null)
			{
				throw new ArgumentNullException("dataGridViewCellStyle");
			}
			if (!objDataGridViewCellStyle.BackColor.IsEmpty)
			{
				BackColor = objDataGridViewCellStyle.BackColor;
			}
			if (!objDataGridViewCellStyle.ForeColor.IsEmpty)
			{
				ForeColor = objDataGridViewCellStyle.ForeColor;
			}
			if (!objDataGridViewCellStyle.SelectionBackColor.IsEmpty)
			{
				SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
			}
			if (!objDataGridViewCellStyle.SelectionForeColor.IsEmpty)
			{
				SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
			}
			if (objDataGridViewCellStyle.Font != null)
			{
				Font = objDataGridViewCellStyle.Font;
			}
			if (!objDataGridViewCellStyle.IsNullValueDefault)
			{
				NullValue = objDataGridViewCellStyle.NullValue;
			}
			if (!objDataGridViewCellStyle.IsDataSourceNullValueDefault)
			{
				DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
			}
			if (objDataGridViewCellStyle.Format.Length != 0)
			{
				Format = objDataGridViewCellStyle.Format;
			}
			if (!objDataGridViewCellStyle.IsFormatProviderDefault)
			{
				FormatProvider = objDataGridViewCellStyle.FormatProvider;
			}
			if (objDataGridViewCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
			{
				AlignmentInternal = objDataGridViewCellStyle.Alignment;
			}
			if (objDataGridViewCellStyle.WrapMode != DataGridViewTriState.NotSet)
			{
				WrapModeInternal = objDataGridViewCellStyle.WrapMode;
			}
			if (objDataGridViewCellStyle.Tag != null)
			{
				Tag = objDataGridViewCellStyle.Tag;
			}
			if (objDataGridViewCellStyle.Padding != Padding.Empty)
			{
				PaddingInternal = objDataGridViewCellStyle.Padding;
			}
		}

		/// Creates an exact copy of this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents an exact copy of this cell style.</returns>
		public virtual DataGridViewCellStyle Clone()
		{
			return new DataGridViewCellStyle(this);
		}

		/// Returns a value indicating whether this instance is equivalent to the specified object.</summary>
		/// true if o is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> and has the same property values as this instance; otherwise, false.</returns>
		/// <param name="o">An object to compare with this instance, or null. </param>
		/// 1</filterpriority>
		public override bool Equals(object obj)
		{
			return obj is DataGridViewCellStyle objDataGridViewCellStyle && GetDifferencesFrom(objDataGridViewCellStyle) == DataGridViewCellStyleDifferences.None;
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add(Alignment);
			hashCode.Add(BackColor);
			hashCode.Add(ForeColor);
			hashCode.Add(SelectionBackColor);
			hashCode.Add(SelectionForeColor);
			hashCode.Add(Font);
			hashCode.Add(NullValue);
			hashCode.Add(DataSourceNullValue);
			hashCode.Add(Format);
			hashCode.Add(FormatProvider);
			hashCode.Add(WrapMode);
			hashCode.Add(Tag);
			hashCode.Add(Padding);
			return hashCode.ToHashCode();
		}

		/// 
		/// Gets the differences from.
		/// </summary>
		/// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
		/// </returns>
		internal DataGridViewCellStyleDifferences GetDifferencesFrom(DataGridViewCellStyle objDataGridViewCellStyle)
		{
			bool flag = objDataGridViewCellStyle.Alignment != Alignment || objDataGridViewCellStyle.DataSourceNullValue != DataSourceNullValue || objDataGridViewCellStyle.Font != Font || objDataGridViewCellStyle.Format != Format || objDataGridViewCellStyle.FormatProvider != FormatProvider || objDataGridViewCellStyle.NullValue != NullValue || objDataGridViewCellStyle.Padding != Padding || objDataGridViewCellStyle.Tag != Tag || objDataGridViewCellStyle.WrapMode != WrapMode;
			bool flag2 = objDataGridViewCellStyle.BackColor != BackColor || objDataGridViewCellStyle.ForeColor != ForeColor || objDataGridViewCellStyle.SelectionBackColor != SelectionBackColor || objDataGridViewCellStyle.SelectionForeColor != SelectionForeColor;
			if (flag)
			{
				return DataGridViewCellStyleDifferences.AffectPreferredSize;
			}
			if (flag2)
			{
				return DataGridViewCellStyleDifferences.DoNotAffectPreferredSize;
			}
			return DataGridViewCellStyleDifferences.None;
		}

		/// 
		/// Removes the scope.
		/// </summary>
		/// <param name="scope">The scope.</param>
		internal void RemoveScope(DataGridViewCellStyleScopes scope)
		{
			Scope &= ~scope;
			if (Scope == DataGridViewCellStyleScopes.None)
			{
				DataGridView = null;
			}
		}

		internal bool ShouldSerializeBackColor()
		{
			return mobjBackColor != Color.Empty;
		}

		internal bool ShouldSerializeFont()
		{
			return mobjFont != null;
		}

		internal bool ShouldSerializeForeColor()
		{
			return mobjForeColor != Color.Empty;
		}

		internal bool ShouldSerializeFormatProvider()
		{
			return mobjFormatProvider != null;
		}

		internal bool ShouldSerializePadding()
		{
			return Padding != Padding.Empty;
		}

		internal bool ShouldSerializeSelectionBackColor()
		{
			return mobjSelectionBackColor != Color.Empty;
		}

		internal bool ShouldSerializeSelectionForeColor()
		{
			return mobjSelectionForeColor != Color.Empty;
		}

		internal bool ShouldSerializeAlignment()
		{
			return menmAlignment != DataGridViewContentAlignment.NotSet;
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		/// Returns a string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
		/// A string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			stringBuilder.Append("DataGridViewCellStyle {");
			bool flag = true;
			if (BackColor != Color.Empty)
			{
				stringBuilder.Append(" BackColor=" + BackColor.ToString());
				flag = false;
			}
			if (ForeColor != Color.Empty)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" ForeColor=" + ForeColor.ToString());
				flag = false;
			}
			if (SelectionBackColor != Color.Empty)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" SelectionBackColor=" + SelectionBackColor.ToString());
				flag = false;
			}
			if (SelectionForeColor != Color.Empty)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" SelectionForeColor=" + SelectionForeColor.ToString());
				flag = false;
			}
			if (Font != null)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" Font=" + Font.ToString());
				flag = false;
			}
			if (!IsNullValueDefault && NullValue != null)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" NullValue=" + NullValue.ToString());
				flag = false;
			}
			if (!IsDataSourceNullValueDefault && DataSourceNullValue != null)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" DataSourceNullValue=" + DataSourceNullValue.ToString());
				flag = false;
			}
			if (!CommonUtils.IsNullOrEmpty(Format))
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" Format=" + Format);
				flag = false;
			}
			if (WrapMode != DataGridViewTriState.NotSet)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" WrapMode=" + WrapMode);
				flag = false;
			}
			if (Alignment != DataGridViewContentAlignment.NotSet)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" Alignment=" + Alignment);
				flag = false;
			}
			if (Padding != Padding.Empty)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" Padding=" + Padding.ToString());
				flag = false;
			}
			if (Tag != null)
			{
				if (!flag)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(" Tag=" + Tag.ToString());
				flag = false;
			}
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}
