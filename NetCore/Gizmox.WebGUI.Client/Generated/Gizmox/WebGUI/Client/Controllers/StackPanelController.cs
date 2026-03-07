using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client.Controllers
{
	public class StackPanelController : PanelController
	{
		public StackPanelController(IContext objContext, object objWebObject, object objWinObject)
			: base(objContext, objWebObject, objWinObject)
		{
		}

		public StackPanelController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		public object GetPropertyValue(object objInstance, string strProperty)
		{
			return GetPropertyValue(objInstance, strProperty, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		public string GetPropertyValue(object objInstance, string strProperty, string strDefault)
		{
			object propertyValue = GetPropertyValue(objInstance, strProperty);
			if (propertyValue != null)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(propertyValue.GetType());
				if (converter != null && converter.CanConvertTo(typeof(string)))
				{
					return converter.ConvertToInvariantString(propertyValue);
				}
			}
			return strDefault;
		}

		public object GetPropertyValue(object objInstance, string strProperty, BindingFlags enmBindingFlags)
		{
			if (objInstance != null)
			{
				PropertyInfo property = objInstance.GetType().GetProperty(strProperty, enmBindingFlags);
				if (property != null)
				{
					object obj = null;
					try
					{
						obj = property.GetValue(objInstance, new object[0]);
					}
					catch (TargetInvocationException ex)
					{
						if (ex.InnerException != null)
						{
							throw ex.InnerException;
						}
						throw ex;
					}
					return obj;
				}
			}
			return null;
		}

		public void SetPropertyValue(object objInstance, string strProperty, object objValue)
		{
			if (objInstance != null)
			{
				PropertyInfo property = objInstance.GetType().GetProperty(strProperty);
				if (property != null)
				{
					property.SetValue(objInstance, objValue, new object[0]);
				}
			}
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new ClientStackPanel();
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinStackPanelOrientation();
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "Orientation")
			{
				SetWinStackPanelOrientation();
			}
		}

		private void SetWinStackPanelOrientation()
		{
			if (base.SourceObject != null && base.TargetObject != null)
			{
				object propertyValue = GetPropertyValue(base.SourceObject, "Orientation");
				if (propertyValue != null)
				{
					SuspendNotifications();
					SetPropertyValue(base.TargetObject, "Orientation", propertyValue);
					ResumeNotifications();
				}
			}
		}
	}
}
