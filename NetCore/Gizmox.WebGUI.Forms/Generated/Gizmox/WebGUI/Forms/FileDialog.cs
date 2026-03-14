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
/// Displays a dialog box from which the user can select a file.</summary>
	/// 1</filterpriority>
	[Serializable]
	[DefaultProperty("FileName")]
	[DefaultEvent("FileOk")]
	[Skin(typeof(FileDialogSkin))]
	public abstract class FileDialog : CommonDialog
	{
		/// 
		/// Dialog bitmap options
		/// </summary>
		internal int mintOptions;

		/// 
		/// The file dialog filter
		/// </summary>
		private string mstrFilter = string.Empty;

		/// 
		/// Dialog title
		/// </summary>
		private string mstrTitle;

		/// 
		/// The dialog default extention
		/// </summary>
		private string mstrDefaultExt;

		/// 
		/// The dialog initial directory
		/// </summary>
		private string mstrInitialDir;

		/// 
		/// Multi dotted extensions supported
		/// </summary>
		private bool mblnSupportMultiDottedExtensions;

		/// 
		/// The maximum file size
		/// </summary>
		private int mintMaxFileSize = 4096;

		/// 
		/// The files collection
		/// </summary>
		private FileHandleCollection mobjFilesList = null;

		/// Gets or sets a value indicating whether the dialog box automatically adds an extension to a file name if the user omits the extension.</summary>
		/// true if the dialog box adds an extension to a file name if the user omits the extension; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[Obsolete("Not implemented.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("FDaddExtensionDescr")]
		[DefaultValue(true)]
		public bool AddExtension
		{
			get
			{
				return GetOption(int.MinValue);
			}
			set
			{
				SetOption(int.MinValue, value);
			}
		}

		/// 
		/// Gets of sets the Maximum file size allowed in kilobytes. 
		/// </summary>
		[DefaultValue(4096)]
		public int MaxFileSize
		{
			get
			{
				return mintMaxFileSize;
			}
			set
			{
				mintMaxFileSize = value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.</summary>
		/// true if the dialog box displays a warning if the user specifies a file name that does not exist; otherwise, false. The default value is false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("FDcheckFileExistsDescr")]
		public virtual bool CheckFileExists
		{
			get
			{
				return GetOption(4096);
			}
			set
			{
				SetOption(4096, value);
			}
		}

		/// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a path that does not exist.</summary>
		/// true if the dialog box displays a warning when the user specifies a path that does not exist; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[SRDescription("FDcheckPathExistsDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool CheckPathExists
		{
			get
			{
				return GetOption(2048);
			}
			set
			{
				SetOption(2048, value);
			}
		}

		/// Gets or sets the default file name extension.</summary>
		/// The default file name extension. The returned string does not include the period. The default value is an empty string ("").</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		[SRCategory("CatBehavior")]
		[SRDescription("FDdefaultExtDescr")]
		public string DefaultExt
		{
			get
			{
				if (mstrDefaultExt != null)
				{
					return mstrDefaultExt;
				}
				return "";
			}
			set
			{
				if (value != null)
				{
					if (value.StartsWith("."))
					{
						value = value.Substring(1);
					}
					else if (value.Length == 0)
					{
						value = null;
					}
				}
				mstrDefaultExt = value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box returns the location of the file referenced by the shortcut or whether it returns the location of the shortcut (.lnk).</summary>
		/// true if the dialog box returns the location of the file referenced by the shortcut; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[SRDescription("FDdereferenceLinksDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool DereferenceLinks
		{
			get
			{
				return !GetOption(1048576);
			}
			set
			{
				SetOption(1048576, !value);
			}
		}

		/// Gets or sets a string containing the file name selected in the file dialog box.</summary>
		/// The file name selected in the file dialog box. The default value is an empty string ("").</returns>
		[DefaultValue("")]
		[SRDescription("FDfileNameDescr")]
		[SRCategory("CatData")]
		public string FileName
		{
			get
			{
				if (File != null)
				{
					return File.FileName;
				}
				return "";
			}
			set
			{
				Files.Clear();
				if (value != null)
				{
					Files.Add(value, PhysicalFileHandle.Create(value));
				}
			}
		}

		/// Gets the file names of all selected files in the dialog box.</summary>
		/// An array of type <see cref="T:System.String"></see>, containing the file names of all selected files in the dialog box.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("FDFileNamesDescr")]
		public string[] FileNames
		{
			get
			{
				string[] array = new string[Files.Count];
				for (int i = 0; i < Files.Count; i++)
				{
					array[i] = Files[i].FileName;
				}
				return array;
			}
		}

		/// 
		/// Gets the current selected file
		/// </summary>
		[Browsable(false)]
		public FileHandle File
		{
			get
			{
				if (mobjFilesList.Count > 0)
				{
					return mobjFilesList[0];
				}
				return null;
			}
		}

		/// 
		/// Gets the current selected files
		/// </summary>
		[Browsable(false)]
		public FileHandleCollection Files => mobjFilesList;

		/// Gets or sets the current file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box.</summary>
		/// The file filtering options available in the dialog box.</returns>
		/// <exception cref="T:System.ArgumentException">Filter format is invalid. </exception>
		[SRCategory("CatBehavior")]
		[DefaultValue("")]
		[Localizable(true)]
		[SRDescription("FDfilterDescr")]
		public string Filter
		{
			get
			{
				return mstrFilter;
			}
			set
			{
				if (!CommonUtils.IsNullOrEmpty(value))
				{
					string[] array = value.Split('|');
					if (array == null || array.Length % 2 != 0)
					{
						throw new ArgumentException(SR.GetString("FileDialogInvalidFilter"));
					}
				}
				mstrFilter = value;
			}
		}

		/// Gets or sets the index of the filter currently selected in the file dialog box.</summary>
		/// A value containing the index of the filter currently selected in the file dialog box. The default value is 1.</returns>
		[SRDescription("FDfilterIndexDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(1)]
		public int FilterIndex
		{
			get
			{
				return 1;
			}
			set
			{
			}
		}

		/// Gets or sets the initial directory displayed by the file dialog box.</summary>
		/// The initial directory displayed by the file dialog box. The default is an empty string ("").</returns>
		[DefaultValue("")]
		[SRCategory("CatData")]
		[SRDescription("FDinitialDirDescr")]
		public string InitialDirectory
		{
			get
			{
				if (mstrInitialDir != null)
				{
					return mstrInitialDir;
				}
				return "";
			}
			set
			{
				mstrInitialDir = value;
			}
		}

		/// Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.FileDialog"></see>.</summary>
		/// A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.FileDialog"></see>.</returns>
		protected int Options => mintOptions;

		/// Gets or sets a value indicating whether the dialog box restores the current directory before closing.</summary>
		/// true if the dialog box restores the current directory to its original value if the user changed the directory while searching for files; otherwise, false. The default value is false.</returns>
		[SRDescription("FDrestoreDirectoryDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool RestoreDirectory
		{
			get
			{
				return GetOption(8);
			}
			set
			{
				SetOption(8, value);
			}
		}

		/// Gets or sets a value indicating whether the Help button is displayed in the file dialog box.</summary>
		/// true if the dialog box includes a help button; otherwise, false. The default value is false.</returns>
		[SRDescription("FDshowHelpDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public bool ShowHelp
		{
			get
			{
				return GetOption(16);
			}
			set
			{
				SetOption(16, value);
			}
		}

		/// 
		/// Gets or sets a value indicating whether [support multi dotted extensions].
		/// </summary>
		/// 
		/// 	true</c> if [support multi dotted extensions]; otherwise, false</c>.
		/// </value>
		[SRDescription("FDsupportMultiDottedExtensionsDescr")]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		public bool SupportMultiDottedExtensions
		{
			get
			{
				return mblnSupportMultiDottedExtensions;
			}
			set
			{
				mblnSupportMultiDottedExtensions = value;
			}
		}

		/// Gets or sets the file dialog box title.</summary>
		/// The file dialog box title. The default value is an empty string ("").</returns>
		[DefaultValue("")]
		[Localizable(true)]
		[SRDescription("FDtitleDescr")]
		[SRCategory("CatAppearance")]
		public string Title
		{
			get
			{
				if (mstrTitle != null)
				{
					return mstrTitle;
				}
				return string.Empty;
			}
			set
			{
				mstrTitle = value;
			}
		}

		/// Gets or sets a value indicating whether the dialog box accepts only valid Win32 file names.</summary>
		/// true if the dialog box accepts only valid Win32 file names; otherwise, false. The default value is true.</returns>
		[SRDescription("FDvalidateNamesDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool ValidateNames
		{
			get
			{
				return !GetOption(256);
			}
			set
			{
				SetOption(256, !value);
			}
		}

		/// Occurs when the user clicks on the Open or Save button on a file dialog box.</summary>
		[SRDescription("FDfileOkDescr")]
		public event CancelEventHandler FileOk;

		internal FileDialog()
		{
			Reset();
		}

		/// 
		/// Handler the dialog closing event
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			if (base.DialogResult == DialogResult.OK)
			{
				OnFileOk(new CancelEventArgs());
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.FileDialog.FileOk"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
		protected void OnFileOk(CancelEventArgs e)
		{
			this.FileOk?.Invoke(this, e);
		}

		/// Resets all properties to their default values.</summary>
		public override void Reset()
		{
			mintOptions = -2147481596;
			mstrTitle = null;
			mstrInitialDir = null;
			mstrDefaultExt = null;
			mstrFilter = "";
			mblnSupportMultiDottedExtensions = false;
			mobjFilesList = new FileHandleCollection();
		}

		/// Provides a string version of this object.</summary>
		/// A string version of this object.</returns>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString() + ": Title: " + Title + ", FileName: ");
			try
			{
				stringBuilder.Append(FileName);
			}
			catch (Exception ex)
			{
				stringBuilder.Append("<");
				stringBuilder.Append(ex.GetType().FullName);
				stringBuilder.Append(">");
			}
			return stringBuilder.ToString();
		}

		/// 
		/// Sets a file dialog option
		/// </summary>
		/// <param name="intOption"></param>
		/// <param name="blnValue"></param>
		internal void SetOption(int intOption, bool blnValue)
		{
			if (blnValue)
			{
				mintOptions |= intOption;
			}
			else
			{
				mintOptions &= ~intOption;
			}
		}

		/// 
		/// Gets a file dialog option
		/// </summary>
		/// <param name="intOption"></param>
		/// </returns>
		internal bool GetOption(int intOption)
		{
			return (mintOptions & intOption) != 0;
		}
	}
}
