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
	/// Represents the navigation and manipulation user interface (UI) for controls on a form that are bound to data.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(ToolBar), "BindingNavigator_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxItemCategory("Data")]
	[Skin(typeof(BindingNavigatorSkin))]
	public class BindingNavigator : ToolBar, ISupportInitialize
	{
		/// 
		///
		/// </summary>
		[Serializable]
		public class BindingNavigatorLabel : ToolBarButton
		{
			/// 
			/// </summary>
			/// </value>
			public override string CustomStyle
			{
				get
				{
					return "Label";
				}
				set
				{
					base.CustomStyle = value;
				}
			}
		}

		/// 
		/// Provides a property reference to Initializing property.
		/// </summary>
		private static SerializableProperty InitializingProperty = SerializableProperty.Register("Initializing", typeof(bool), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to PositionItem property.
		/// </summary>
		private static SerializableProperty PositionItemProperty = SerializableProperty.Register("PositionItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to MovePreviousItem property.
		/// </summary>
		private static SerializableProperty MovePreviousItemProperty = SerializableProperty.Register("MovePreviousItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to MoveNextItem property.
		/// </summary>
		private static SerializableProperty MoveNextItemProperty = SerializableProperty.Register("MoveNextItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to MoveLastItem property.
		/// </summary>
		private static SerializableProperty MoveLastItemProperty = SerializableProperty.Register("MoveLastItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to MoveFirstItem property.
		/// </summary>
		private static SerializableProperty MoveFirstItemProperty = SerializableProperty.Register("MoveFirstItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to DeleteItem property.
		/// </summary>
		private static SerializableProperty DeleteItemProperty = SerializableProperty.Register("DeleteItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to CountItemFormat property.
		/// </summary>
		private static SerializableProperty CountItemFormatProperty = SerializableProperty.Register("CountItemFormat", typeof(string), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to BindingSource property.
		/// </summary>
		private static SerializableProperty BindingSourceProperty = SerializableProperty.Register("BindingSource", typeof(BindingSource), typeof(BindingNavigator));

		/// 
		/// Provides a property reference to AddNewItem property.
		/// </summary>
		private static SerializableProperty AddNewItemProperty = SerializableProperty.Register("AddNewItem", typeof(ToolBarButton), typeof(BindingNavigator));

		/// 
		/// The RefreshItems event registration.
		/// </summary>
		private static readonly SerializableEvent RefreshItemsEvent;

		/// 
		/// Gets the hanlder for the RefreshItems event.
		/// </summary>
		private EventHandler RefreshItemsHandler => (EventHandler)GetHandler(RefreshItemsEvent);

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. The default is null.</returns>
		[SRDescription("BindingNavigatorAddNewItemPropDescr")]
		[TypeConverter(typeof(ReferenceConverter))]
		[SRCategory("CatItems")]
		[DefaultValue(null)]
		public ToolBarButton AddNewItem
		{
			get
			{
				return GetValue(AddNewItemProperty);
			}
			set
			{
				if (AddNewItem != value)
				{
					ToolBarButton objValue = WireUpButton(AddNewItem, value, OnAddNew);
					SetValue(AddNewItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component that is the source of data.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>. The default is null.</returns>
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		[SRCategory("CatData")]
		[SRDescription("BindingNavigatorBindingSourcePropDescr")]
		public BindingSource BindingSource
		{
			get
			{
				return GetValue(BindingSourceProperty);
			}
			set
			{
				if (BindingSource != value)
				{
					BindingSource objValue = WireUpBindingSource(BindingSource, value);
					SetValue(BindingSourceProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. </returns>
		[SRDescription("BindingNavigatorCountItemPropDescr")]
		[SRCategory("CatItems")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		[Obsolete("This property is not implemented - please use the PositionItem property which contains both position and count.")]
		public BindingNavigatorLabel CountItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a string used to format the information displayed in the <see cref="P:System.Windows.Forms.BindingNavigator.CountItem"></see> control.
		/// </summary>
		/// The count item format.</value>
		/// The format <see cref="T:System.String"></see> used to format the item count. The default is the string of {0}.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("BindingNavigatorCountItemFormatPropDescr")]
		public string CountItemFormat
		{
			get
			{
				return GetValue(CountItemFormatProperty);
			}
			set
			{
				if (CountItemFormat != value)
				{
					SetValue(CountItemFormatProperty, value);
					RefreshItemsInternal();
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Delete functionality.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Delete button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[SRCategory("CatItems")]
		[TypeConverter(typeof(ReferenceConverter))]
		[SRDescription("BindingNavigatorDeleteItemPropDescr")]
		[DefaultValue(null)]
		public ToolBarButton DeleteItem
		{
			get
			{
				return GetValue(DeleteItemProperty);
			}
			set
			{
				if (DeleteItem != value)
				{
					ToolBarButton objValue = WireUpButton(DeleteItem, value, OnDelete);
					SetValue(DeleteItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move First functionality.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move First button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[SRCategory("CatItems")]
		[TypeConverter(typeof(ReferenceConverter))]
		[SRDescription("BindingNavigatorMoveFirstItemPropDescr")]
		[DefaultValue(null)]
		public ToolBarButton MoveFirstItem
		{
			get
			{
				return GetValue(MoveFirstItemProperty);
			}
			set
			{
				if (MoveFirstItem != value)
				{
					ToolBarButton objValue = WireUpButton(MoveFirstItem, value, OnMoveFirst);
					SetValue(MoveFirstItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Last functionality.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Last button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[SRDescription("BindingNavigatorMoveLastItemPropDescr")]
		[SRCategory("CatItems")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		public ToolBarButton MoveLastItem
		{
			get
			{
				return GetValue(MoveLastItemProperty);
			}
			set
			{
				if (MoveLastItem != value)
				{
					ToolBarButton objValue = WireUpButton(MoveLastItem, value, OnMoveLast);
					SetValue(MoveLastItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Next functionality.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Next button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[SRCategory("CatItems")]
		[SRDescription("BindingNavigatorMoveNextItemPropDescr")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		public ToolBarButton MoveNextItem
		{
			get
			{
				return GetValue(MoveNextItemProperty);
			}
			set
			{
				if (MoveNextItem != value)
				{
					ToolBarButton objValue = WireUpButton(MoveNextItem, value, OnMoveNext);
					SetValue(MoveNextItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Previous functionality.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Previous button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
		[SRCategory("CatItems")]
		[SRDescription("BindingNavigatorMovePreviousItemPropDescr")]
		[TypeConverter(typeof(ReferenceConverter))]
		[DefaultValue(null)]
		public ToolBarButton MovePreviousItem
		{
			get
			{
				return GetValue(MovePreviousItemProperty);
			}
			set
			{
				if (MovePreviousItem != value)
				{
					ToolBarButton objValue = WireUpButton(MovePreviousItem, value, OnMovePrevious);
					SetValue(MovePreviousItemProperty, objValue);
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position within the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position.</returns>
		[SRDescription("BindingNavigatorPositionItemPropDescr")]
		[TypeConverter(typeof(ReferenceConverter))]
		[SRCategory("CatItems")]
		[DefaultValue(null)]
		public BindingNavigatorLabel PositionItem
		{
			get
			{
				return GetValue(PositionItemProperty);
			}
			set
			{
				if (PositionItem != value)
				{
					BindingNavigatorLabel objValue = WireUpTextBox(PositionItem, value, OnPositionKey, OnPositionLostFocus) as BindingNavigatorLabel;
					SetValue(PositionItemProperty, objValue);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator" /> is initializing.
		/// </summary>
		/// true</c> if initializing; otherwise, false</c>.</value>
		private bool Initializing
		{
			get
			{
				return GetValue(InitializingProperty);
			}
			set
			{
				if (Initializing != value)
				{
					SetValue(InitializingProperty, value);
				}
			}
		}

		/// 
		/// Gets the default text align.
		/// </summary>
		/// The default text align.</value>
		protected override ToolBarTextAlign DefaultTextAlign => ToolBarTextAlign.Right;

		/// 
		/// Gets the toolbar button collecction
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override ToolBarItemCollection Buttons => base.Buttons;

		/// Occurs when the state of the navigational user interface (UI) needs to be refreshed to reflect the current state of the underlying data.</summary>
		[SRDescription("BindingNavigatorRefreshItemsEventDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler RefreshItems
		{
			add
			{
				AddHandler(RefreshItemsEvent, value);
			}
			remove
			{
				RemoveHandler(RefreshItemsEvent, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class, indicating whether to display the standard navigation user interface (UI).</summary>
		/// <param name="blnAddStandardItems">true to show the standard navigational UI; otherwise, false.</param>
		public BindingNavigator(bool blnAddStandardItems)
		{
			SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));
			if (blnAddStandardItems)
			{
				AddStandardItems();
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class and adds this new instance to the specified container.</summary>
		/// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the new <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control to.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BindingNavigator(IContainer objContainer)
			: this(blnAddStandardItems: false)
		{
			objContainer?.Add(this);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class with the specified <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> as the data source.</summary>
		/// <param name="objBindingSource">The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> used as a data source.</param>
		public BindingNavigator(BindingSource objBindingSource)
			: this(blnAddStandardItems: true)
		{
			BindingSource = objBindingSource;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BindingNavigator()
			: this(blnAddStandardItems: false)
		{
		}

		/// Adds the standard set of navigation items to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control.</summary>
		public virtual void AddStandardItems()
		{
			if (!base.DesignMode)
			{
				bool flag = false;
				MoveFirstItem = new ToolBarButton();
				MovePreviousItem = new ToolBarButton();
				MoveNextItem = new ToolBarButton();
				MoveLastItem = new ToolBarButton();
				PositionItem = new BindingNavigatorLabel();
				AddNewItem = new ToolBarButton();
				DeleteItem = new ToolBarButton();
				ToolBarButton toolBarButton = new ToolBarButton();
				ToolBarButton toolBarButton2 = new ToolBarButton();
				ToolBarButton toolBarButton3 = new ToolBarButton();
				char c = ((CommonUtils.IsNullOrEmpty(base.Name) || char.IsLower(base.Name[0])) ? 'b' : 'B');
				MoveFirstItem.Name = c + "indingNavigatorMoveFirstItem";
				MovePreviousItem.Name = c + "indingNavigatorMovePreviousItem";
				MoveNextItem.Name = c + "indingNavigatorMoveNextItem";
				MoveLastItem.Name = c + "indingNavigatorMoveLastItem";
				PositionItem.Name = c + "indingNavigatorPositionItem";
				AddNewItem.Name = c + "indingNavigatorAddNewItem";
				DeleteItem.Name = c + "indingNavigatorDeleteItem";
				toolBarButton.Name = c + "indingNavigatorSeparator";
				toolBarButton2.Name = c + "indingNavigatorSeparator";
				toolBarButton3.Name = c + "indingNavigatorSeparator";
				MoveFirstItem.ToolTipText = SR.GetString("BindingNavigatorMoveFirstItemText");
				MovePreviousItem.ToolTipText = SR.GetString("BindingNavigatorMovePreviousItemText");
				MoveNextItem.ToolTipText = SR.GetString("BindingNavigatorMoveNextItemText");
				MoveLastItem.ToolTipText = SR.GetString("BindingNavigatorMoveLastItemText");
				AddNewItem.ToolTipText = SR.GetString("BindingNavigatorAddNewItemText");
				DeleteItem.ToolTipText = SR.GetString("BindingNavigatorDeleteItemText");
				PositionItem.ToolTipText = SR.GetString("BindingNavigatorPositionItemTip");
				if (Context != null)
				{
					flag = Context.RightToLeft;
				}
				MoveFirstItem.Image = new SkinResourceHandle(base.Skin, string.Format("NavigateHome{0}.gif", flag ? "RTL" : "LTR"));
				MovePreviousItem.Image = new SkinResourceHandle(base.Skin, string.Format("NavigatePrev{0}.gif", flag ? "RTL" : "LTR"));
				MoveNextItem.Image = new SkinResourceHandle(base.Skin, string.Format("NavigateNext{0}.gif", flag ? "RTL" : "LTR"));
				MoveLastItem.Image = new SkinResourceHandle(base.Skin, string.Format("NavigateEnd{0}.gif", flag ? "RTL" : "LTR"));
				AddNewItem.Image = new SkinResourceHandle(base.Skin, "Add.gif");
				DeleteItem.Image = new SkinResourceHandle(base.Skin, "Delete.gif");
				MoveFirstItem.Style = ToolBarButtonStyle.PushButton;
				MovePreviousItem.Style = ToolBarButtonStyle.PushButton;
				MoveNextItem.Style = ToolBarButtonStyle.PushButton;
				MoveLastItem.Style = ToolBarButtonStyle.PushButton;
				AddNewItem.Style = ToolBarButtonStyle.PushButton;
				DeleteItem.Style = ToolBarButtonStyle.PushButton;
				toolBarButton.Style = ToolBarButtonStyle.Separator;
				toolBarButton2.Style = ToolBarButtonStyle.Separator;
				toolBarButton3.Style = ToolBarButtonStyle.Separator;
				Buttons.AddRange(new ToolBarButton[10] { MoveFirstItem, MovePreviousItem, toolBarButton, PositionItem, toolBarButton2, MoveNextItem, MoveLastItem, toolBarButton3, AddNewItem, DeleteItem });
			}
		}

		/// Disables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> during the component's initialization.</summary>
		public void BeginInit()
		{
			Initializing = true;
		}

		/// Enables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> after the component's initialization has concluded.</summary>
		public void EndInit()
		{
			Initializing = false;
			RefreshItemsInternal();
		}

		/// Causes form validation to occur and returns whether validation was successful.</summary>
		/// true if validation was successful and focus can shift to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>; otherwise, false.</returns>
		public bool Validate()
		{
			return true;
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> and optionally releases the managed resources. </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				BindingSource = null;
			}
			base.Dispose(blnDisposing);
		}

		/// Raises the <see cref="E:System.Windows.Forms.BindingNavigator.RefreshItems"></see> event.</summary>
		protected virtual void OnRefreshItems()
		{
			RefreshItemsCore();
			RefreshItemsHandler?.Invoke(this, EventArgs.Empty);
		}

		/// 
		/// Refreshes the state of the standard items to reflect the current state of the data.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void RefreshItemsCore()
		{
			ToolBarButton addNewItem = AddNewItem;
			BindingSource bindingSource = BindingSource;
			ToolBarButton moveFirstItem = MoveFirstItem;
			ToolBarButton movePreviousItem = MovePreviousItem;
			ToolBarButton moveNextItem = MoveNextItem;
			ToolBarButton moveLastItem = MoveLastItem;
			ToolBarButton deleteItem = DeleteItem;
			ToolBarButton positionItem = PositionItem;
			int num;
			int num2;
			bool enabled;
			bool flag;
			if (bindingSource == null)
			{
				num = 0;
				num2 = 0;
				enabled = false;
				flag = false;
			}
			else
			{
				num = BindingSource.Count;
				num2 = BindingSource.Position + 1;
				enabled = BindingSource.AllowNew;
				flag = BindingSource.AllowRemove;
			}
			if (!base.DesignMode)
			{
				if (moveFirstItem != null)
				{
					moveFirstItem.Enabled = num2 > 1;
				}
				if (movePreviousItem != null)
				{
					movePreviousItem.Enabled = num2 > 1;
				}
				if (moveNextItem != null)
				{
					moveNextItem.Enabled = num2 < num;
				}
				if (moveLastItem != null)
				{
					moveLastItem.Enabled = num2 < num;
				}
				if (AddNewItem != null)
				{
					addNewItem.Enabled = enabled;
				}
				if (deleteItem != null)
				{
					deleteItem.Enabled = flag && num > 0;
				}
				if (positionItem != null)
				{
					positionItem.Enabled = num2 > 0 && num > 0;
				}
			}
			if (positionItem != null)
			{
				positionItem.Text = (base.DesignMode ? CountItemFormat : string.Format(CultureInfo.CurrentCulture, CountItemFormat, new object[2]
				{
					num2.ToString(CultureInfo.CurrentCulture),
					num
				}));
			}
		}

		private void SetCountItemFormatDirectly(string strValue)
		{
			if (CountItemFormat != strValue)
			{
				SetValue(CountItemFormatProperty, strValue);
			}
		}

		private void AcceptNewPosition()
		{
			BindingSource bindingSource = BindingSource;
			ToolBarButton positionItem = PositionItem;
			if (positionItem != null && bindingSource != null)
			{
				int num = bindingSource.Position;
				try
				{
					num = Convert.ToInt32(positionItem.Text, CultureInfo.CurrentCulture) - 1;
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
				if (num != bindingSource.Position)
				{
					bindingSource.Position = num;
				}
				RefreshItemsInternal();
			}
		}

		private void CancelNewPosition()
		{
			RefreshItemsInternal();
		}

		private void OnAddNew(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.AddNew();
				RefreshItemsInternal();
			}
		}

		private void OnBindingSourceListChanged(object sender, ListChangedEventArgs e)
		{
			RefreshItemsInternal();
		}

		private void OnBindingSourceStateChanged(object sender, EventArgs e)
		{
			RefreshItemsInternal();
		}

		private void OnDelete(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.RemoveCurrent();
				RefreshItemsInternal();
			}
		}

		private void OnMoveFirst(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.MoveFirst();
				RefreshItemsInternal();
			}
		}

		private void OnMoveLast(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.MoveLast();
				RefreshItemsInternal();
			}
		}

		private void OnMoveNext(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.MoveNext();
				RefreshItemsInternal();
			}
		}

		private void OnMovePrevious(object sender, EventArgs e)
		{
			BindingSource bindingSource = BindingSource;
			if (Validate() && bindingSource != null)
			{
				bindingSource.MovePrevious();
				RefreshItemsInternal();
			}
		}

		private void OnPositionKey(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Enter:
				AcceptNewPosition();
				break;
			case Keys.Escape:
				CancelNewPosition();
				break;
			}
		}

		private void OnPositionLostFocus(object sender, EventArgs e)
		{
			AcceptNewPosition();
		}

		private void RefreshItemsInternal()
		{
			if (!Initializing)
			{
				OnRefreshItems();
			}
		}

		private void ResetCountItemFormat()
		{
			SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));
		}

		private bool ShouldSerializeCountItemFormat()
		{
			string countItemFormat = CountItemFormat;
			return countItemFormat != SR.GetString("BindingNavigatorCountItemFormat");
		}

		private BindingSource WireUpBindingSource(BindingSource oldBindingSource, BindingSource newBindingSource)
		{
			if (oldBindingSource != newBindingSource)
			{
				if (oldBindingSource != null)
				{
					oldBindingSource.PositionChanged -= OnBindingSourceStateChanged;
					oldBindingSource.CurrentChanged -= OnBindingSourceStateChanged;
					oldBindingSource.CurrentItemChanged -= OnBindingSourceStateChanged;
					oldBindingSource.DataSourceChanged -= OnBindingSourceStateChanged;
					oldBindingSource.DataMemberChanged -= OnBindingSourceStateChanged;
					oldBindingSource.ListChanged -= OnBindingSourceListChanged;
				}
				if (newBindingSource != null)
				{
					newBindingSource.PositionChanged += OnBindingSourceStateChanged;
					newBindingSource.CurrentChanged += OnBindingSourceStateChanged;
					newBindingSource.CurrentItemChanged += OnBindingSourceStateChanged;
					newBindingSource.DataSourceChanged += OnBindingSourceStateChanged;
					newBindingSource.DataMemberChanged += OnBindingSourceStateChanged;
					newBindingSource.ListChanged += OnBindingSourceListChanged;
				}
				oldBindingSource = newBindingSource;
				RefreshItemsInternal();
			}
			return oldBindingSource;
		}

		private ToolBarButton WireUpButton(ToolBarButton oldButton, ToolBarButton newButton, EventHandler clickHandler)
		{
			if (oldButton != newButton)
			{
				if (oldButton != null)
				{
					oldButton.Click -= clickHandler;
				}
				if (newButton != null)
				{
					newButton.Click += clickHandler;
				}
				oldButton = newButton;
				RefreshItemsInternal();
			}
			return oldButton;
		}

		private ToolBarButton WireUpLabel(ToolBarButton oldLabel, ToolBarButton newLabel)
		{
			if (oldLabel != newLabel)
			{
				oldLabel = newLabel;
				RefreshItemsInternal();
			}
			return oldLabel;
		}

		private ToolBarButton WireUpTextBox(ToolBarButton oldTextBox, ToolBarButton newTextBox, KeyEventHandler keyUpHandler, EventHandler lostFocusHandler)
		{
			if (oldTextBox != newTextBox)
			{
				oldTextBox = newTextBox;
				RefreshItemsInternal();
			}
			return oldTextBox;
		}

		static BindingNavigator()
		{
			RefreshItemsEvent = SerializableEvent.Register("RefreshItems", typeof(EventHandler), typeof(BindingNavigator));
		}
	}
}
