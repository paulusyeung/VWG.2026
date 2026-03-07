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
	public class RowStyleController : TableLayoutStyleController
	{
		public System.Windows.Forms.RowStyle TargetRowStyle => base.TargetObject as System.Windows.Forms.RowStyle;

		public Gizmox.WebGUI.Forms.RowStyle SourceRowStyle => base.SourceObject as Gizmox.WebGUI.Forms.RowStyle;

		public RowStyleController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
		}

		public RowStyleController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			Gizmox.WebGUI.Forms.RowStyle rowStyle = objSourceObject as Gizmox.WebGUI.Forms.RowStyle;
			return new System.Windows.Forms.RowStyle((System.Windows.Forms.SizeType)GetConvertedEnum(typeof(System.Windows.Forms.SizeType), rowStyle.SizeType), rowStyle.Height);
		}

		protected override object CreateSourceObject(object objTargetObject)
		{
			System.Windows.Forms.RowStyle rowStyle = objTargetObject as System.Windows.Forms.RowStyle;
			return new Gizmox.WebGUI.Forms.RowStyle((Gizmox.WebGUI.Forms.SizeType)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.SizeType), rowStyle.SizeType), rowStyle.Height);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			if (base.DesignInitialization)
			{
				SetSourceRowStyleHeight();
			}
			else
			{
				SetTargetRowStyleHeight();
			}
		}

		public override void UpdateSource()
		{
			base.UpdateSource();
			SetSourceRowStyleHeight();
		}

		public override void UpdateTarget()
		{
			base.UpdateTarget();
			SetTargetRowStyleHeight();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Height")
			{
				SetSourceRowStyleHeight();
			}
			else
			{
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			string property = objPropertyChangeArgs.Property;
			if (property == "Height")
			{
				SetTargetRowStyleHeight();
			}
			else
			{
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			}
		}

		protected virtual void SetSourceRowStyleHeight()
		{
			SourceRowStyle.Height = TargetRowStyle.Height;
		}

		protected virtual void SetTargetRowStyleHeight()
		{
			TargetRowStyle.Height = SourceRowStyle.Height;
		}
	}
}
