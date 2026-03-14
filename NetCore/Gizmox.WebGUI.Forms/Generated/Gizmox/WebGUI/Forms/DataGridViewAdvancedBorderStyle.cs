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
/// Contains border styles for the cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	public sealed class DataGridViewAdvancedBorderStyle : ICloneable
	{
		private bool mblnAll;

		private DataGridViewAdvancedCellBorderStyle menmBanned1;

		private DataGridViewAdvancedCellBorderStyle menmBanned2;

		private DataGridViewAdvancedCellBorderStyle menmBanned3;

		private DataGridViewAdvancedCellBorderStyle menmBottom;

		private DataGridViewAdvancedCellBorderStyle menmLeft;

		private DataGridView mobjOwner;

		private DataGridViewAdvancedCellBorderStyle menmRight;

		private DataGridViewAdvancedCellBorderStyle menmTop;

		/// Gets or sets the border style for all of the borders of a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetPartial"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance was retrieved through the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AdvancedCellBorderStyle"></see> property.</exception>
		/// 1</filterpriority>
		public DataGridViewAdvancedCellBorderStyle All
		{
			get
			{
				if (!mblnAll)
				{
					return DataGridViewAdvancedCellBorderStyle.NotSet;
				}
				return menmTop;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
				}
				if (value == DataGridViewAdvancedCellBorderStyle.NotSet || value == menmBanned1 || value == menmBanned2 || value == menmBanned3)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "All"));
				}
				if (!mblnAll || menmTop != value)
				{
					mblnAll = true;
					menmTop = (menmLeft = (menmRight = (menmBottom = value)));
					if (mobjOwner == null)
					{
					}
				}
			}
		}

		/// Gets or sets the style for the bottom border of a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
		/// 1</filterpriority>
		public DataGridViewAdvancedCellBorderStyle Bottom
		{
			get
			{
				if (mblnAll)
				{
					return menmTop;
				}
				return menmBottom;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
				}
				if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Bottom"));
				}
				BottomInternal = value;
			}
		}

		internal DataGridViewAdvancedCellBorderStyle BottomInternal
		{
			set
			{
				if ((mblnAll && menmTop != value) || (!mblnAll && menmBottom != value))
				{
					if (mblnAll && menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
					}
					mblnAll = false;
					menmBottom = value;
					if (mobjOwner == null)
					{
					}
				}
			}
		}

		/// Gets the style for the left border of a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of true.</exception>
		/// 1</filterpriority>
		public DataGridViewAdvancedCellBorderStyle Left
		{
			get
			{
				if (mblnAll)
				{
					return menmTop;
				}
				return menmLeft;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
				}
				if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Left"));
				}
				LeftInternal = value;
			}
		}

		internal DataGridViewAdvancedCellBorderStyle LeftInternal
		{
			set
			{
				if ((!mblnAll || menmTop == value) && (mblnAll || menmLeft == value))
				{
					return;
				}
				if (mobjOwner != null)
				{
				}
				if (false)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Left"));
				}
				if (mblnAll)
				{
					if (menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
					}
					if (menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
					}
				}
				mblnAll = false;
				menmLeft = value;
				if (mobjOwner == null)
				{
				}
			}
		}

		/// Gets the style for the right border of a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of false.</exception>
		/// 1</filterpriority>
		public DataGridViewAdvancedCellBorderStyle Right
		{
			get
			{
				if (mblnAll)
				{
					return menmTop;
				}
				return menmRight;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
				}
				if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Right"));
				}
				RightInternal = value;
			}
		}

		internal DataGridViewAdvancedCellBorderStyle RightInternal
		{
			set
			{
				if ((mblnAll && menmTop != value) || (!mblnAll && menmRight != value))
				{
					if (mobjOwner != null)
					{
					}
					if (false)
					{
						throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Right"));
					}
					if (mblnAll && menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
					}
					mblnAll = false;
					menmRight = value;
					if (mobjOwner == null)
					{
					}
				}
			}
		}

		/// Gets the style for the top border of a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
		/// 1</filterpriority>
		public DataGridViewAdvancedCellBorderStyle Top
		{
			get
			{
				return menmTop;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 7))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
				}
				if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
				{
					throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", "Top"));
				}
				TopInternal = value;
			}
		}

		internal DataGridViewAdvancedCellBorderStyle TopInternal
		{
			set
			{
				if ((!mblnAll || menmTop == value) && (mblnAll || menmTop == value))
				{
					return;
				}
				if (mblnAll)
				{
					if (menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
					}
					if (menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
					{
						menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
					}
				}
				mblnAll = false;
				menmTop = value;
				if (mobjOwner == null)
				{
				}
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> class. </summary>
		public DataGridViewAdvancedBorderStyle()
			: this(null, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
		{
		}

		internal DataGridViewAdvancedBorderStyle(DataGridView objOwner)
			: this(objOwner, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
		{
		}

		internal DataGridViewAdvancedBorderStyle(DataGridView objOwner, DataGridViewAdvancedCellBorderStyle enmBanned1, DataGridViewAdvancedCellBorderStyle enmBanned2, DataGridViewAdvancedCellBorderStyle enmBanned3)
		{
			mblnAll = true;
			menmTop = DataGridViewAdvancedCellBorderStyle.None;
			menmLeft = DataGridViewAdvancedCellBorderStyle.None;
			menmRight = DataGridViewAdvancedCellBorderStyle.None;
			menmBottom = DataGridViewAdvancedCellBorderStyle.None;
			mobjOwner = objOwner;
			menmBanned1 = enmBanned1;
			menmBanned2 = enmBanned2;
			menmBanned3 = enmBanned3;
		}

		/// Determines whether the specified object is equal to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
		/// true if other is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> and the values for the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Top"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Bottom"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Left"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Right"></see> properties are equal to their counterpart in the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>; otherwise, false.</returns>
		/// <param name="other">An <see cref="T:System.Object"></see> to be compared.</param>
		/// 1</filterpriority>
		public override bool Equals(object other)
		{
			if (other is DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyle && dataGridViewAdvancedBorderStyle.mblnAll == mblnAll && dataGridViewAdvancedBorderStyle.menmTop == menmTop && dataGridViewAdvancedBorderStyle.menmLeft == menmLeft && dataGridViewAdvancedBorderStyle.menmBottom == menmBottom)
			{
				return dataGridViewAdvancedBorderStyle.menmRight == menmRight;
			}
			return false;
		}

		/// 1</filterpriority>
		public override int GetHashCode()
		{
			return ClientUtils.GetCombinedHashCodes((int)menmTop, (int)menmLeft, (int)menmBottom, (int)menmRight);
		}

		object ICloneable.Clone()
		{
			DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyle = new DataGridViewAdvancedBorderStyle(mobjOwner, menmBanned1, menmBanned2, menmBanned3);
			dataGridViewAdvancedBorderStyle.mblnAll = mblnAll;
			dataGridViewAdvancedBorderStyle.menmTop = menmTop;
			dataGridViewAdvancedBorderStyle.menmRight = menmRight;
			dataGridViewAdvancedBorderStyle.menmBottom = menmBottom;
			dataGridViewAdvancedBorderStyle.menmLeft = menmLeft;
			return dataGridViewAdvancedBorderStyle;
		}

		/// Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
		/// A string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			return "DataGridViewAdvancedBorderStyle { All=" + All.ToString() + ", Left=" + Left.ToString() + ", Right=" + Right.ToString() + ", Top=" + Top.ToString() + ", Bottom=" + Bottom.ToString() + " }";
		}
	}
}
