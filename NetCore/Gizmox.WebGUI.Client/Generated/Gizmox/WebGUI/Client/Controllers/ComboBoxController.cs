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
	public class ComboBoxController : ListControlController
	{
		private ItemsCollectionController mobjItemsCollectionController = null;

		public Gizmox.WebGUI.Forms.ComboBox WebComboBox => base.SourceObject as Gizmox.WebGUI.Forms.ComboBox;

		public System.Windows.Forms.ComboBox WinComboBox => base.TargetObject as System.Windows.Forms.ComboBox;

		public ComboBoxController(IContext objContext, object objWebTreeView, object objWinTreeView)
			: base(objContext, objWebTreeView, objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebComboBox, WebComboBox.Items, WinComboBox, WinComboBox.Items);
		}

		public ComboBoxController(IContext objContext, object objWebObject)
			: base(objContext, objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(base.Context, WebComboBox, WebComboBox.Items, WinComboBox, WinComboBox.Items);
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (!(property == "DropDownStyle"))
			{
				if (property == "Items")
				{
					SetWinComboBoxItems();
				}
			}
			else
			{
				SetWinComboDropDownStyle();
			}
		}

		private void SetWinComboBoxItems()
		{
			if (WinComboBox != null && WebComboBox != null)
			{
				WinComboBox.Items.Clear();
				object[] array = new object[WebComboBox.Items.Count];
				WebComboBox.Items.CopyTo(array, 0);
				WinComboBox.Items.AddRange(array);
			}
		}

		protected override void WireDesignTimeEvents()
		{
			base.WireDesignTimeEvents();
			WinComboBox.SizeChanged += WinComboBox_SizeChanged;
		}

		private void WinComboBox_SizeChanged(object sender, EventArgs e)
		{
			SetWebControlSize();
		}

		public override void InitializeNew()
		{
			base.InitializeNew();
			if (WebComboBox != null)
			{
				WebComboBox.FormattingEnabled = true;
			}
		}

		protected override void UnwireDesignTimeEvents()
		{
			base.UnwireDesignTimeEvents();
			WinComboBox.SizeChanged -= WinComboBox_SizeChanged;
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
			string property = objPropertyChangeArgs.Property;
			if (property == "DropDownStyle")
			{
				SetWebComboDropDownStyle();
			}
		}

		protected override void InitializeController()
		{
			base.InitializeController();
			SetWinComboDropDownStyle();
			SetWinComboBoxItems();
		}

		protected override void InitializedContained()
		{
			base.InitializedContained();
			mobjItemsCollectionController.Initialize();
		}

		protected override void SetWebControlText()
		{
		}

		protected virtual void SetWinComboDropDownStyle()
		{
			WinComboBox.DropDownStyle = (System.Windows.Forms.ComboBoxStyle)GetConvertedEnum(typeof(System.Windows.Forms.ComboBoxStyle), WebComboBox.DropDownStyle);
		}

		protected virtual void SetWebComboDropDownStyle()
		{
			WebComboBox.DropDownStyle = (Gizmox.WebGUI.Forms.ComboBoxStyle)GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.ComboBoxStyle), WinComboBox.DropDownStyle);
		}

		protected override object CreateTargetObject(object objWebObject)
		{
			return new System.Windows.Forms.ComboBox();
		}

		protected override void WireEvents()
		{
			base.WireEvents();
			WinComboBox.SelectedIndexChanged += WinListBox_SelectedIndexChanged;
		}

		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Event obj = CreateWebEvent("ValueChange");
			obj.SetParameter("VLB", WinComboBox.SelectedIndex.ToString());
			obj.Fire();
		}

		protected override void UnwireEvents()
		{
			base.UnwireEvents();
			WinComboBox.SelectedIndexChanged -= WinListBox_SelectedIndexChanged;
		}
	}
}
