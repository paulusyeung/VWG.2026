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
	public class ComponentController : GenericComponentController
	{
		private ContextMenuController mobjContextMenuController = null;

		protected ContextMenuController ContextMenuController
		{
			get
			{
				if (mobjContextMenuController == null && WebComponent != null && WebComponent.ContextMenu != null)
				{
					System.Windows.Forms.ContextMenu objWinControl = new System.Windows.Forms.ContextMenu();
					mobjContextMenuController = new ContextMenuController(base.Context, WebComponent.ContextMenu, objWinControl);
					mobjContextMenuController.InitializeController();
				}
				return mobjContextMenuController;
			}
		}

		public Gizmox.WebGUI.Forms.Component WebComponent => base.SourceObject as Gizmox.WebGUI.Forms.Component;

		public System.ComponentModel.Component WinComponent => base.TargetObject as System.ComponentModel.Component;

		public ComponentController(IContext objContext, object objWebComponent, object objWinComponent)
			: base(objContext, objWebComponent, objWinComponent)
		{
		}

		public ComponentController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			IObservableItem webComponent = WebComponent;
			if (webComponent != null && !base.DesignMode)
			{
				webComponent.ObservableItemPropertyChanged += objObservableItem_ObservableItemPropertyChanged;
			}
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			IObservableItem webComponent = WebComponent;
			if (webComponent != null && !base.DesignMode)
			{
				webComponent.ObservableItemPropertyChanged -= objObservableItem_ObservableItemPropertyChanged;
			}
		}

		protected void SetWinProperty(string strPropertyName, object objNewValue)
		{
			SuspendDesigner();
			SuspendNotifications();
			try
			{
				object winComponent = WinComponent;
				if (winComponent == null)
				{
					return;
				}
				PropertyInfo property = winComponent.GetType().GetProperty(strPropertyName);
				if (property != null)
				{
					if (base.DesignMode)
					{
						base.DesignServices.FireWinComponentChanging(WinComponent, strPropertyName);
					}
					object value = property.GetValue(winComponent, new object[0]);
					property.SetValue(winComponent, objNewValue, new object[0]);
					if (base.DesignMode)
					{
						base.DesignServices.FireWinComponentChanged(WinComponent, strPropertyName, value, objNewValue);
					}
				}
			}
			finally
			{
				ResumeNotifications();
				ResumeDesigner();
			}
		}

		protected void SetWebProperty(string strPropertyName, object objNewValue)
		{
			SuspendDesigner();
			SuspendNotifications();
			try
			{
				object webComponent = WebComponent;
				if (webComponent == null)
				{
					return;
				}
				PropertyInfo property = webComponent.GetType().GetProperty(strPropertyName);
				if (property != null)
				{
					if (base.DesignMode)
					{
						base.DesignServices.FireWebComponentChanging(WebComponent, strPropertyName);
					}
					object value = property.GetValue(webComponent, new object[0]);
					property.SetValue(webComponent, objNewValue, new object[0]);
					if (base.DesignMode)
					{
						base.DesignServices.FireWebComponentChanged(WebComponent, strPropertyName, value, objNewValue);
					}
				}
			}
			finally
			{
				ResumeNotifications();
				ResumeDesigner();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ReplaceSource(object objSource)
		{
			if (base.DesignMode && objSource is IComponent objWebComponent)
			{
				base.DesignServices.RegisterWebComponent(objWebComponent);
				IComponent webComponent = WebComponent;
				if (webComponent != null)
				{
					base.DesignServices.UnregisterWebComponent(webComponent);
				}
				base.ReplaceSource(objSource);
			}
		}

		private void objObservableItem_ObservableItemPropertyChanged(object objSender, ObservableItemPropertyChangedArgs objArgs)
		{
			((IContextNotifications)base.Context).NotifyItemPropertyChanged(this, objArgs, blnWebEvent: true);
		}

		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			OnSourceObjectPropertyChange(objPropertyChangeArgs);
		}

		public override void FireWinPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWinPropertyChanged(objPropertyChangeArgs);
			OnTargetObjectPropertyChange(objPropertyChangeArgs);
		}

		protected virtual Event CreateWebEvent(string strType)
		{
			return CreateWebEvent(strType, base.SourceObject);
		}

		protected virtual Event CreateWebEvent(string strType, object objWebSource)
		{
			return CreateWebEvent(base.Context, strType, objWebSource, null);
		}

		protected virtual Event CreateWebEvent(string strType, object objWebSource, object objWebTarget)
		{
			return CreateWebEvent(base.Context, strType, objWebSource, objWebTarget);
		}

		protected virtual Event CreateWebEvent(IContext objContext, string strType, object objWebSource, object objWebTarget)
		{
			if (objWebSource is IRegisteredComponent objSource)
			{
				return new Event(objContext, strType, objSource, objWebTarget as IRegisteredComponent);
			}
			return null;
		}
	}
}


