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

namespace Gizmox.WebGUI.Forms.Skins
{
/// 
	/// hold sthe value that represents padding space between the body of the UI element and its edge.
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[TypeConverter(typeof(PaddingValueConverter))]
	public class PaddingValue : SkinValue
	{
		/// 
		///
		/// </summary>
		private Padding mobjValue;

		/// 
		/// The empty padding reference
		/// </summary>
		private static PaddingValue mobjEmpty = new PaddingValue(Padding.Empty);

		/// 
		/// Gets or sets the padding value for the bottom edge.
		/// </summary>
		/// The padding, in pixels, for the bottom edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Bottom
		{
			get
			{
				return mobjValue.Bottom;
			}
			set
			{
				mobjValue.Bottom = value;
			}
		}

		/// 
		/// Gets or sets the padding value for all the edges.
		/// </summary>
		/// The padding, in pixels, for all edges if the same; otherwise, -1.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int All
		{
			get
			{
				return mobjValue.All;
			}
			set
			{
				mobjValue.All = value;
			}
		}

		/// 
		/// Gets or sets the padding value for the left edge.
		/// </summary>
		/// The padding, in pixels, for the left edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Left
		{
			get
			{
				return mobjValue.Left;
			}
			set
			{
				mobjValue.Left = value;
			}
		}

		/// 
		/// Gets or sets the padding value for the right edge.
		/// </summary>
		/// The padding, in pixels, for the right edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Right
		{
			get
			{
				return mobjValue.Right;
			}
			set
			{
				mobjValue.Right = value;
			}
		}

		/// 
		/// Gets or sets the padding value for the top edge.
		/// </summary>
		/// The padding, in pixels, for the top edge.</returns>
		[RefreshProperties(RefreshProperties.All)]
		public int Top
		{
			get
			{
				return mobjValue.Top;
			}
			set
			{
				mobjValue.Top = value;
			}
		}

		/// 
		/// Gets the combined padding for the right and left edges.
		/// </summary>
		/// Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Left"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Right"></see> padding values.</returns>
		[Browsable(false)]
		public int Horizontal => mobjValue.Horizontal;

		/// 
		/// Gets the combined padding for the top and bottom edges.
		/// </summary>
		/// Gets the sum, in pixels, of the <see cref="P:Gizmox.WebGUI.Forms.Padding.Top"></see> and <see cref="P:Gizmox.WebGUI.Forms.Padding.Bottom"></see> padding values.</returns>
		[Browsable(false)]
		public int Vertical => mobjValue.Vertical;

		/// 
		/// Gets the padding information in the form of a <see cref="T:System.Drawing.Size"></see>.
		/// </summary>
		/// A <see cref="T:System.Drawing.Size"></see> containing the padding information.</returns>
		[Browsable(false)]
		public Size Size => mobjValue.Size;

		/// 
		/// Gets an empty padding value.
		/// </summary>
		/// The empty padding value.</value>
		public static PaddingValue Empty => mobjEmpty;

		/// 
		/// Gets the value.
		/// </summary>
		/// The value.</value>
		[Browsable(false)]
		public Padding Value => mobjValue;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> class.
		/// </summary>
		/// <param name="objValue">The padding value.</param>
		public PaddingValue(Padding objValue)
		{
			mobjValue = objValue;
		}

		/// 
		/// Gets the translated value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// </returns>
		public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
		{
			string importantDeclarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
			if (mobjValue.IsAll)
			{
				return $"{GetWebStyleName()}:{mobjValue.All}px{importantDeclarationValue}";
			}
			return $"{GetWebStyleName()}:{mobjValue.Top}px {mobjValue.Right}px {mobjValue.Bottom}px {mobjValue.Left}px{importantDeclarationValue}";
		}

		/// 
		/// Gets the name of the web style.
		/// </summary>
		/// </returns>
		protected virtual string GetWebStyleName()
		{
			return "padding";
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
		/// </returns>
		public override string ToString()
		{
			return mobjValue.ToString();
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:Gizmox.WebGUI.Forms.Padding" />.
		/// </summary>
		/// <param name="objPaddingValue">The padding value.</param>
		/// The result of the conversion.</returns>
		public static implicit operator Padding(PaddingValue objPaddingValue)
		{
			return objPaddingValue?.Value ?? Padding.Empty;
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Padding" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
		/// </summary>
		/// <param name="objPadding">The padding.</param>
		/// The result of the conversion.</returns>
		public static implicit operator PaddingValue(Padding objPadding)
		{
			return new PaddingValue(objPadding);
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" /> to <see cref="T:System.String" />.
		/// </summary>
		/// <param name="objPaddingValue">The padding value.</param>
		/// The result of the conversion.</returns>
		public static implicit operator string(PaddingValue objPaddingValue)
		{
			if (objPaddingValue.Value.IsAll)
			{
				return objPaddingValue.All.ToString();
			}
			return $"{objPaddingValue.Left},{objPaddingValue.Top},{objPaddingValue.Right},{objPaddingValue.Bottom}";
		}

		/// 
		/// Performs an implicit conversion from <see cref="T:System.String" /> to <see cref="T:Gizmox.WebGUI.Forms.Skins.PaddingValue" />.
		/// </summary>
		/// <param name="strPadding">The padding string.</param>
		/// The result of the conversion.</returns>
		public static implicit operator PaddingValue(string strPadding)
		{
			Padding objValue = Padding.Empty;
			if (!string.IsNullOrEmpty(strPadding))
			{
				string[] array = strPadding.Split(',');
				if (array.Length == 4)
				{
					objValue = new Padding(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]));
				}
				else if (array.Length == 1)
				{
					objValue = new Padding(int.Parse(array[0]));
				}
			}
			return new PaddingValue(objValue);
		}
	}
}
