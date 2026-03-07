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
	public class ColumnStyleController : TableLayoutStyleController
	{
		public System.Windows.Forms.ColumnStyle TargetColumnStyle => base.TargetObject as System.Windows.Forms.ColumnStyle;

		public Gizmox.WebGUI.Forms.ColumnStyle SourceColumnStyle => base.SourceObject as Gizmox.WebGUI.Forms.ColumnStyle;

		public ColumnStyleController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public ColumnStyleController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			Gizmox.WebGUI.Forms.ColumnStyle columnStyle = objSourceObject as Gizmox.WebGUI.Forms.ColumnStyle;
			return new System.Windows.Forms.ColumnStyle((System.Windows.Forms.SizeType)GetConvertedEnum(typeof(System.Windows.Forms.SizeType), columnStyle.SizeType), columnStyle.Width);
		}

		protected override object CreateSourceObject(object objTargetObject)
		{
			System.Windows.Forms.ColumnStyle columnStyle = objTargetObject as System.Windows.Forms.ColumnStyle;
			return new Gizmox.WebGUI.Forms.ColumnStyle((Gizmox.WebGUI.Forms.SizeType)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.SizeType), columnStyle.SizeType), columnStyle.Width);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (base.DesignInitialization)
			{
				SetSourceColumnStyleWidth();
			}
			else
			{
				SetTargetColumnStyleWidth();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetSourceColumnStyleWidth();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetTargetColumnStyleWidth();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetSourceColumnStyleWidth();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Width")
			{
				SetTargetColumnStyleWidth();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetSourceColumnStyleWidth()
		{
			SourceColumnStyle.Width = TargetColumnStyle.Width;
		}

		protected virtual void SetTargetColumnStyleWidth()
		{
			TargetColumnStyle.Width = SourceColumnStyle.Width;
		}
	}
}
