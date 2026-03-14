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
	/// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.
	/// </summary>
	[Serializable]
	public class TableLayoutSettingsTypeConverter : TypeConverter
	{
		/// 
		/// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objSourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
		/// 
		/// true if this converter can perform the conversion; otherwise, false.
		/// </returns>
		public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
		{
			return objSourceType == typeof(string) || base.CanConvertFrom(objContext, objSourceType);
		}

		/// 
		/// Returns whether this converter can convert the object to the specified type, using the specified context.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
		/// 
		/// true if this converter can perform the conversion; otherwise, false.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
		{
			if (objDestinationType != typeof(InstanceDescriptor) && objDestinationType != typeof(string))
			{
				return base.CanConvertTo(objContext, objDestinationType);
			}
			return true;
		}

		/// 
		/// Converts the given object to the type of this converter, using the specified context and culture information.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
		/// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
		/// 
		/// An <see cref="T:System.Object" /> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">
		/// The conversion cannot be performed.
		/// </exception>
		public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
		{
			if (objValue is string)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(objValue as string);
				TableLayoutSettings tableLayoutSettings = new TableLayoutSettings();
				ParseControls(tableLayoutSettings, xmlDocument.GetElementsByTagName("Control"));
				ParseStyles(tableLayoutSettings, xmlDocument.GetElementsByTagName("Columns"), blnColumns: true);
				ParseStyles(tableLayoutSettings, xmlDocument.GetElementsByTagName("Rows"), blnColumns: false);
				return tableLayoutSettings;
			}
			return base.ConvertFrom(objContext, objCulture, objValue);
		}

		/// 
		/// Converts the given value object to the specified type, using the specified context and culture information.
		/// </summary>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
		/// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
		/// <param name="objDestinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
		/// 
		/// An <see cref="T:System.Object" /> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="objDestinationType" /> parameter is null.
		/// </exception>
		/// <exception cref="T:System.NotSupportedException">
		/// The conversion cannot be performed.
		/// </exception>
		public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == null)
			{
				throw new ArgumentNullException("objDestinationType");
			}
			if (!(objValue is TableLayoutSettings) || objDestinationType != typeof(string))
			{
				return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
			}
			TableLayoutSettings tableLayoutSettings = objValue as TableLayoutSettings;
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter xmlWriter = XmlWriter.Create(stringBuilder);
			xmlWriter.WriteStartElement("TableLayoutSettings");
			xmlWriter.WriteStartElement("Controls");
			foreach (TableLayoutSettings.ControlInformation item in tableLayoutSettings.GetControlsInformation())
			{
				xmlWriter.WriteStartElement("Control");
				xmlWriter.WriteAttributeString("Name", item.Name.ToString());
				int row = item.Row;
				xmlWriter.WriteAttributeString("Row", row.ToString(CultureInfo.CurrentCulture));
				row = item.RowSpan;
				xmlWriter.WriteAttributeString("RowSpan", row.ToString(CultureInfo.CurrentCulture));
				row = item.Column;
				xmlWriter.WriteAttributeString("Column", row.ToString(CultureInfo.CurrentCulture));
				row = item.ColumnSpan;
				xmlWriter.WriteAttributeString("ColumnSpan", row.ToString(CultureInfo.CurrentCulture));
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteStartElement("Columns");
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (ColumnStyle item2 in (IEnumerable)tableLayoutSettings.ColumnStyles)
			{
				stringBuilder2.AppendFormat("{0},{1},", item2.SizeType, item2.Width);
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
			}
			xmlWriter.WriteAttributeString("Styles", stringBuilder2.ToString());
			xmlWriter.WriteEndElement();
			xmlWriter.WriteStartElement("Rows");
			StringBuilder stringBuilder3 = new StringBuilder();
			foreach (RowStyle item3 in (IEnumerable)tableLayoutSettings.RowStyles)
			{
				stringBuilder3.AppendFormat("{0},{1},", item3.SizeType, item3.Height);
			}
			if (stringBuilder3.Length > 0)
			{
				stringBuilder3.Remove(stringBuilder3.Length - 1, 1);
			}
			xmlWriter.WriteAttributeString("Styles", stringBuilder3.ToString());
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
			xmlWriter.Close();
			return stringBuilder.ToString();
		}

		private string GetAttributeValue(XmlNode objXmlNode, string strAttribute)
		{
			return objXmlNode.Attributes[strAttribute]?.Value;
		}

		private int GetAttributeValue(XmlNode objXmlNode, string strAttribute, int intValueIfNotFound)
		{
			string attributeValue = GetAttributeValue(objXmlNode, strAttribute);
			if (!CommonUtils.IsNullOrEmpty(attributeValue) && CommonUtils.TryParse(attributeValue, out double dblValue))
			{
				return Convert.ToInt32(dblValue);
			}
			return intValueIfNotFound;
		}

		private void ParseControls(TableLayoutSettings objSettings, XmlNodeList controlXmlFragments)
		{
			foreach (XmlNode controlXmlFragment in controlXmlFragments)
			{
				string attributeValue = GetAttributeValue(controlXmlFragment, "Name");
				if (!CommonUtils.IsNullOrEmpty(attributeValue))
				{
					int attributeValue2 = GetAttributeValue(controlXmlFragment, "Row", -1);
					int attributeValue3 = GetAttributeValue(controlXmlFragment, "RowSpan", 1);
					int attributeValue4 = GetAttributeValue(controlXmlFragment, "Column", -1);
					int attributeValue5 = GetAttributeValue(controlXmlFragment, "ColumnSpan", 1);
					objSettings.SetRow(attributeValue, attributeValue2);
					objSettings.SetColumn(attributeValue, attributeValue4);
					objSettings.SetRowSpan(attributeValue, attributeValue3);
					objSettings.SetColumnSpan(attributeValue, attributeValue5);
				}
			}
		}

		private void ParseStyles(TableLayoutSettings objSettings, XmlNodeList objControlXmlFragments, bool blnColumns)
		{
			foreach (XmlNode objControlXmlFragment in objControlXmlFragments)
			{
				string attributeValue = GetAttributeValue(objControlXmlFragment, "Styles");
				Type typeFromHandle = typeof(SizeType);
				if (CommonUtils.IsNullOrEmpty(attributeValue))
				{
					continue;
				}
				int num = 0;
				while (num < attributeValue.Length)
				{
					int i;
					for (i = num; char.IsLetter(attributeValue[i]); i++)
					{
					}
					SizeType objSizeType = (SizeType)Enum.Parse(typeFromHandle, attributeValue.Substring(num, i - num), ignoreCase: true);
					for (; !char.IsDigit(attributeValue[i]); i++)
					{
					}
					StringBuilder stringBuilder = new StringBuilder();
					for (; i < attributeValue.Length && char.IsDigit(attributeValue[i]); i++)
					{
						stringBuilder.Append(attributeValue[i]);
					}
					stringBuilder.Append('.');
					for (; i < attributeValue.Length && !char.IsLetter(attributeValue[i]); i++)
					{
						if (char.IsDigit(attributeValue[i]))
						{
							stringBuilder.Append(attributeValue[i]);
						}
					}
					if (!CommonUtils.TryParse(stringBuilder.ToString(), out float fltValue))
					{
						fltValue = 0f;
					}
					if (blnColumns)
					{
						objSettings.ColumnStyles.Add(new ColumnStyle(objSizeType, fltValue));
					}
					else
					{
						objSettings.RowStyles.Add(new RowStyle(objSizeType, fltValue));
					}
					num = i;
				}
			}
		}
	}
}
