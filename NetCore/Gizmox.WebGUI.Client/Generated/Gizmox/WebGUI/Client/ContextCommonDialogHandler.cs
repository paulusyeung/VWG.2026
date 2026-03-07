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

namespace Gizmox.WebGUI.Client
{
	internal class ContextCommonDialogHandler : ICommonDialogHandler
	{
		private EventHandler mobjDirectEventHandler = null;

		private EventHandler mobjCloseEventHandler = null;

		private ICommonDialog mobjCommonDialog = null;

		private Gizmox.WebGUI.Forms.DialogResult mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.None;

		Gizmox.WebGUI.Forms.DialogResult ICommonDialogHandler.DialogResult => mobjWebDialogResult;

		EventHandler ICommonDialogHandler.DirectHandler => mobjDirectEventHandler;

		public void ShowDialog(ICommonDialog objCommonDialog, System.Windows.Forms.Form objOwner, EventHandler objCloseHandler, EventHandler objDirectHandler)
		{
			mobjDirectEventHandler = objDirectHandler;
			mobjCloseEventHandler = objCloseHandler;
			mobjCommonDialog = objCommonDialog;
			if (objCommonDialog is Gizmox.WebGUI.Forms.FontDialog objWebFontDialog)
			{
				ShowFontDialog(objWebFontDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.ColorDialog objWebColorDialog)
			{
				ShowColorDialog(objWebColorDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.OpenFileDialog objWebOpenFileDialog)
			{
				ShowOpenFileDialog(objWebOpenFileDialog, objOwner);
			}
			if (objCommonDialog is Gizmox.WebGUI.Forms.FolderBrowserDialog objOpenFileDialog)
			{
				ShowFolderBrowserDialog(objOpenFileDialog, objOwner);
			}
		}

		private void ShowFolderBrowserDialog(Gizmox.WebGUI.Forms.FolderBrowserDialog objOpenFileDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			CopyCommonProperties(objOpenFileDialog, folderBrowserDialog);
			folderBrowserDialog.ShowDialog(objOwner);
			if (folderBrowserDialog.SelectedPath != objOpenFileDialog.SelectedPath)
			{
				objOpenFileDialog.SelectedPath = folderBrowserDialog.SelectedPath;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void ShowColorDialog(Gizmox.WebGUI.Forms.ColorDialog objWebColorDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
			CopyCommonProperties(objWebColorDialog, colorDialog);
			colorDialog.ShowDialog(objOwner);
			if (colorDialog.Color != objWebColorDialog.Color)
			{
				objWebColorDialog.Color = colorDialog.Color;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void ShowFontDialog(Gizmox.WebGUI.Forms.FontDialog objWebFontDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.FontDialog fontDialog = new System.Windows.Forms.FontDialog();
			CopyCommonProperties(objWebFontDialog, fontDialog);
			fontDialog.Apply += objWinFontDialog_Apply;
			fontDialog.ShowDialog(objOwner);
			if (fontDialog.Font != objWebFontDialog.Font)
			{
				objWebFontDialog.Font = fontDialog.Font;
				mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
			}
			OnDialogClosed();
		}

		private void objWinFontDialog_Apply(object sender, EventArgs e)
		{
			mobjCommonDialog.OnApply();
		}

		private void ShowOpenFileDialog(Gizmox.WebGUI.Forms.OpenFileDialog objWebOpenFileDialog, System.Windows.Forms.Form objOwner)
		{
			System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
			CopyCommonProperties(objWebOpenFileDialog, openFileDialog);
			openFileDialog.FileOk += objWinOpenFileDialog_FileOk;
			openFileDialog.ShowDialog(objOwner);
			if (mobjWebDialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
			{
				objWebOpenFileDialog.Files.Clear();
				string[] fileNames = openFileDialog.FileNames;
				foreach (string text in fileNames)
				{
					objWebOpenFileDialog.Files.Add(text, PhysicalFileHandle.Create(text));
				}
			}
			OnDialogClosed();
		}

		private void CopyCommonProperties(object objSource, object objTarget)
		{
			if (objSource == null || objTarget == null)
			{
				return;
			}
			Type type = objSource.GetType();
			Type type2 = objTarget.GetType();
			if (!(type != null) || !(type2 != null))
			{
				return;
			}
			PropertyInfo[] properties = type.GetProperties();
			if (properties == null)
			{
				return;
			}
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				PropertyInfo property = type2.GetProperty(propertyInfo.Name);
				if (property != null && property.CanWrite && property.PropertyType == propertyInfo.PropertyType)
				{
					object obj = type.InvokeMember(propertyInfo.Name, BindingFlags.GetProperty, null, objSource, null);
					type2.InvokeMember(property.Name, BindingFlags.SetProperty, null, objTarget, new object[1] { obj });
				}
			}
		}

		private void objWinOpenFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			mobjWebDialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
		}

		private void OnDialogClosed()
		{
			if (mobjCloseEventHandler != null)
			{
				mobjCloseEventHandler(this, EventArgs.Empty);
			}
		}
	}
}
