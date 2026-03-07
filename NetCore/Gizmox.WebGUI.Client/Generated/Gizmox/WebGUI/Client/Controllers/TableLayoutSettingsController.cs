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
	public class TableLayoutSettingsController : LayoutSettingsController
	{
		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;

		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;

		public System.Windows.Forms.TableLayoutSettings TargetTableLayoutSettings => base.TargetObject as System.Windows.Forms.TableLayoutSettings;

		public Gizmox.WebGUI.Forms.TableLayoutSettings SourceTableLayoutSettings => base.SourceObject as Gizmox.WebGUI.Forms.TableLayoutSettings;

		public TableLayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject)
			: base(objContext, objSourceObject, objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.RowStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.ColumnStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.ColumnStyles);
		}

		public TableLayoutSettingsController(IContext objContext, object objSourceObject)
			: base(objContext, objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.RowStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext, SourceTableLayoutSettings, SourceTableLayoutSettings.ColumnStyles, TargetTableLayoutSettings, TargetTableLayoutSettings.ColumnStyles);
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjRowStylesController.Initialize();
			mobjColumnStylesController.Initialize();
		}

		protected override object CreateTargetObject(object objSourceObject)
		{
			return base.CreateTargetObject(objSourceObject);
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetTargetTableLayoutSettingsColumnCount();
			SetTargetTableLayoutSettingsRowCount();
			SetTargetTableLayoutSettingsGrowStyle();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "ColumnCount":
				SetSourceTableLayoutSettingsColumnCount();
				break;
			case "RowCount":
				SetSourceTableLayoutSettingsRowCount();
				break;
			case "GrowStyle":
				SetSourceTableLayoutSettingsGrowStyle();
				break;
			default:
				base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch (objPropertyChangeArgs.Property)
			{
			case "ColumnCount":
				SetTargetTableLayoutSettingsColumnCount();
				break;
			case "RowCount":
				SetTargetTableLayoutSettingsRowCount();
				break;
			case "GrowStyle":
				SetTargetTableLayoutSettingsGrowStyle();
				break;
			default:
				base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
				break;
			}
		}

		protected virtual void SetSourceTableLayoutSettingsColumnCount()
		{
			SourceTableLayoutSettings.ColumnCount = TargetTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetTargetTableLayoutSettingsColumnCount()
		{
			TargetTableLayoutSettings.ColumnCount = SourceTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetSourceTableLayoutSettingsRowCount()
		{
			SourceTableLayoutSettings.RowCount = TargetTableLayoutSettings.RowCount;
		}

		protected virtual void SetTargetTableLayoutSettingsRowCount()
		{
			TargetTableLayoutSettings.RowCount = SourceTableLayoutSettings.RowCount;
		}

		protected virtual void SetSourceTableLayoutSettingsGrowStyle()
		{
			SourceTableLayoutSettings.GrowStyle = (Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle), TargetTableLayoutSettings.GrowStyle);
		}

		protected virtual void SetTargetTableLayoutSettingsGrowStyle()
		{
			TargetTableLayoutSettings.GrowStyle = (System.Windows.Forms.TableLayoutPanelGrowStyle)GetConvertedEnum(typeof(System.Windows.Forms.TableLayoutPanelGrowStyle), SourceTableLayoutSettings.GrowStyle);
		}
	}
}
