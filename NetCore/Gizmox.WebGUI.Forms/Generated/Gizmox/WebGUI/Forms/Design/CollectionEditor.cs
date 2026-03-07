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

namespace Gizmox.WebGUI.Forms.Design
{
	/// Provides a user interface that can edit most types of collections at design time.</summary>
	[Serializable]
	public class CollectionEditor : WebUITypeEditor
	{
		[Serializable]
		internal class PropertyGridSite : ISite, IServiceProvider
		{
			private IComponent mobjComponent;

			private bool mblnInGetService;

			private IServiceProvider mobjServiceProvider;

			public IComponent Component => mobjComponent;

			public IContainer Container => null;

			public bool DesignMode => false;

			public string Name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public PropertyGridSite(IServiceProvider objServiceProvider, IComponent comp)
			{
				mobjServiceProvider = objServiceProvider;
				mobjComponent = comp;
			}

			public object GetService(Type objType)
			{
				if (!mblnInGetService && mobjServiceProvider != null)
				{
					try
					{
						mblnInGetService = true;
						return mobjServiceProvider.GetService(objType);
					}
					finally
					{
						mblnInGetService = false;
					}
				}
				return null;
			}
		}

		[Serializable]
		protected internal class CollectionEditorCollectionForm : CollectionForm
		{
			[Serializable]
			private class SelectionWrapper : PropertyDescriptor, ICustomTypeDescriptor
			{
				private ICollection mobjCollection;

				private Type mobjCollectionItemType;

				private Type mobjCollectionType;

				private Control mobjControl;

				private PropertyDescriptorCollection mobjProperties;

				private object mobjValue;

				public override Type ComponentType => mobjCollectionType;

				public override bool IsReadOnly => false;

				public override Type PropertyType => mobjCollectionItemType;

				public SelectionWrapper(Type objCollectionType, Type objCollectionItemType, Control objControl, ICollection objCollection)
					: base("Value", new Attribute[1]
					{
						new CategoryAttribute(objCollectionItemType.Name)
					})
				{
					mobjCollectionType = objCollectionType;
					mobjCollectionItemType = objCollectionItemType;
					mobjControl = objControl;
					mobjCollection = objCollection;
					mobjProperties = new PropertyDescriptorCollection(new PropertyDescriptor[1] { this });
					mobjValue = this;
					foreach (ListItem item in objCollection)
					{
						if (mobjValue == this)
						{
							mobjValue = item.Value;
							continue;
						}
						object value = item.Value;
						if (mobjValue != null)
						{
							if (value == null)
							{
								mobjValue = null;
								break;
							}
							if (!mobjValue.Equals(value))
							{
								mobjValue = null;
								break;
							}
						}
						else if (value != null)
						{
							mobjValue = null;
							break;
						}
					}
				}

				public override bool CanResetValue(object objComponent)
				{
					return false;
				}

				public override object GetValue(object objComponent)
				{
					return mobjValue;
				}

				public override void ResetValue(object objComponent)
				{
				}

				public override void SetValue(object objComponent, object objValue)
				{
					mobjValue = objValue;
					foreach (ListItem item in mobjCollection)
					{
						item.Value = objValue;
					}
					mobjControl.Invalidate();
					OnValueChanged(objComponent, EventArgs.Empty);
				}

				public override bool ShouldSerializeValue(object objComponent)
				{
					return false;
				}

				System.ComponentModel.AttributeCollection ICustomTypeDescriptor.GetAttributes()
				{
					return TypeDescriptor.GetAttributes(mobjCollectionItemType);
				}

				string ICustomTypeDescriptor.GetClassName()
				{
					return mobjCollectionItemType.Name;
				}

				string ICustomTypeDescriptor.GetComponentName()
				{
					return null;
				}

				TypeConverter ICustomTypeDescriptor.GetConverter()
				{
					return null;
				}

				EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
				{
					return null;
				}

				PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
				{
					return this;
				}

				object ICustomTypeDescriptor.GetEditor(Type objEditorBaseType)
				{
					return null;
				}

				EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
				{
					return EventDescriptorCollection.Empty;
				}

				EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] arrAttributes)
				{
					return EventDescriptorCollection.Empty;
				}

				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
				{
					return mobjProperties;
				}

				PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] arrAttributes)
				{
					return mobjProperties;
				}

				object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor)
				{
					return this;
				}
			}

			[Serializable]
			private class ListItem
			{
				private CollectionEditor mobjParentCollectionEditor;

				private object mobjUITypeEditor;

				private object mobjValue;

				private string mstrDisplayText = "";

				public string DisplayText => mstrDisplayText;

				public UITypeEditor Editor
				{
					get
					{
						if (mobjUITypeEditor == null)
						{
							mobjUITypeEditor = TypeDescriptor.GetEditor(mobjValue, typeof(UITypeEditor));
							if (mobjUITypeEditor == null)
							{
								mobjUITypeEditor = this;
							}
						}
						if (mobjUITypeEditor != this)
						{
							return (UITypeEditor)mobjUITypeEditor;
						}
						return null;
					}
				}

				public object Value
				{
					get
					{
						return mobjValue;
					}
					set
					{
						mobjUITypeEditor = null;
						mobjValue = value;
					}
				}

				public ListItem(CollectionEditor objParentCollectionEditor, object objValue)
				{
					mobjValue = objValue;
					mobjParentCollectionEditor = objParentCollectionEditor;
				}

				public override string ToString()
				{
					return mstrDisplayText;
				}

				public bool UpdateDisplayText()
				{
					string displayText = mobjParentCollectionEditor.GetDisplayText(mobjValue);
					if (displayText != mstrDisplayText)
					{
						mstrDisplayText = displayText;
						return true;
					}
					return false;
				}
			}

			private Panel mobjPanelButtons;

			private Panel mobjPanelItems;

			private Panel mobjPanelProperties;

			private Label mobjLabelMembers;

			private Label mobjLabelProperties;

			private Panel mobjPanelUpDown;

			private Panel mobjPanelAddRemove;

			private Button mobjButtonCancel;

			private Button mobjButtonOk;

			private ListBox mobjListItems;

			private PropertyGrid mobjPropertyGrid;

			private Button mobjButtonUp;

			private Button mobjButtonDown;

			private Button mobjButtonAdd;

			private Button mobjButtonRemove;

			private ArrayList mobjOriginalItems = null;

			private ArrayList mobjCreatedItems = null;

			private ArrayList mobjRemovedItems = null;

			private bool mblnDirty = false;

			private int mintSuspendEnabledCount = 0;

			private CollectionEditor mobjCollectionEditor = null;

			private bool IsImmutable
			{
				get
				{
					bool result = true;
					if (!TypeDescriptor.GetConverter(base.CollectionItemType).GetCreateInstanceSupported())
					{
						foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(base.CollectionItemType))
						{
							if (!property.IsReadOnly)
							{
								return false;
							}
						}
					}
					return result;
				}
			}

			/// 
			/// Gets the property grid.
			/// </summary>
			/// 
			/// The property grid.
			/// </value>
			internal PropertyGrid PropertyGrid => mobjPropertyGrid;

			public CollectionEditorCollectionForm(CollectionEditor objCollectionEditor)
				: base(objCollectionEditor)
			{
				mobjCollectionEditor = objCollectionEditor;
				InitializeComponent();
				InitializeComponentExtra();
				Text = SR.GetString("CollectionEditorCaption", base.CollectionItemType.Name);
			}

			/// 
			/// Adds VWG specifiec initialization
			/// </summary>
			private void InitializeComponentExtra()
			{
				mobjButtonDown.Image = new SkinResourceHandle(base.Skin, "ButtonDownArrow.gif");
				mobjButtonUp.Image = new SkinResourceHandle(base.Skin, "ButtonUpArrow.gif");
				Type[] newItemTypes = base.NewItemTypes;
				if (newItemTypes.Length > 1)
				{
					ContextMenu contextMenu = new ContextMenu();
					mobjButtonAdd.DropDownMenu = contextMenu;
					foreach (Type type in newItemTypes)
					{
						MenuItem menuItem = new MenuItem(GetTypeDisplayName(type));
						menuItem.Tag = type;
						contextMenu.MenuItems.Add(menuItem);
					}
					mobjButtonAdd.MenuClick += objAddDropDownMenu_MenuClick;
				}
				else
				{
					mobjButtonAdd.Click += mobjButtonAdd_Click;
				}
				mobjPropertyGrid.PropertyValueChanged += mobjPropertyGrid_PropertyValueChanged;
			}

			/// 
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				mobjPanelButtons = new Panel();
				mobjPanelItems = new Panel();
				mobjPanelProperties = new Panel();
				mobjLabelMembers = new Label();
				mobjLabelProperties = new Label();
				mobjPanelUpDown = new Panel();
				mobjPanelAddRemove = new Panel();
				mobjButtonCancel = new Button();
				mobjButtonOk = new Button();
				mobjListItems = new ListBox();
				mobjPropertyGrid = GetPropertyGridInstance();
				mobjButtonUp = new Button();
				mobjButtonDown = new Button();
				mobjButtonAdd = new Button();
				mobjButtonRemove = new Button();
				mobjPanelButtons.SuspendLayout();
				mobjPanelItems.SuspendLayout();
				mobjPanelProperties.SuspendLayout();
				mobjPanelUpDown.SuspendLayout();
				mobjPanelAddRemove.SuspendLayout();
				SuspendLayout();
				mobjPanelButtons.Controls.Add(mobjButtonOk);
				mobjPanelButtons.Controls.Add(mobjButtonCancel);
				mobjPanelButtons.Dock = DockStyle.Bottom;
				mobjPanelButtons.Location = new Point(5, 377);
				mobjPanelButtons.Name = "mobjPanelButtons";
				mobjPanelButtons.Size = new Size(470, 40);
				mobjPanelButtons.TabIndex = 0;
				mobjPanelItems.Controls.Add(mobjListItems);
				mobjPanelItems.Controls.Add(mobjPanelAddRemove);
				mobjPanelItems.Controls.Add(mobjPanelUpDown);
				mobjPanelItems.Controls.Add(mobjLabelMembers);
				mobjPanelItems.Dock = DockStyle.Left;
				mobjPanelItems.Location = new Point(5, 5);
				mobjPanelItems.Name = "mobjPanelItems";
				mobjPanelItems.Size = new Size(243, 372);
				mobjPanelItems.TabIndex = 1;
				mobjPanelProperties.Controls.Add(mobjPropertyGrid);
				mobjPanelProperties.Controls.Add(mobjLabelProperties);
				mobjPanelProperties.Dock = DockStyle.Fill;
				mobjPanelProperties.Location = new Point(248, 5);
				mobjPanelProperties.Name = "mobjPanelProperties";
				mobjPanelProperties.Size = new Size(227, 372);
				mobjPanelProperties.TabIndex = 2;
				mobjLabelMembers.Dock = DockStyle.Top;
				mobjLabelMembers.Location = new Point(0, 0);
				mobjLabelMembers.Name = "mobjLabelMembers";
				mobjLabelMembers.Size = new Size(243, 23);
				mobjLabelMembers.TabIndex = 0;
				mobjLabelMembers.Text = "Members:";
				mobjLabelMembers.TextAlign = ContentAlignment.BottomLeft;
				mobjLabelProperties.Dock = DockStyle.Top;
				mobjLabelProperties.Location = new Point(0, 0);
				mobjLabelProperties.Name = "mobjLabelProperties";
				mobjLabelProperties.Size = new Size(227, 23);
				mobjLabelProperties.TabIndex = 0;
				mobjLabelProperties.Text = "{0} properties:";
				mobjLabelProperties.TextAlign = ContentAlignment.BottomLeft;
				mobjPanelUpDown.Controls.Add(mobjButtonDown);
				mobjPanelUpDown.Controls.Add(mobjButtonUp);
				mobjPanelUpDown.Dock = DockStyle.Right;
				mobjPanelUpDown.Location = new Point(195, 23);
				mobjPanelUpDown.Name = "mobjPanelUpDown";
				mobjPanelUpDown.Size = new Size(48, 349);
				mobjPanelUpDown.TabIndex = 1;
				mobjPanelAddRemove.Controls.Add(mobjButtonRemove);
				mobjPanelAddRemove.Controls.Add(mobjButtonAdd);
				mobjPanelAddRemove.Dock = DockStyle.Bottom;
				mobjPanelAddRemove.Location = new Point(0, 332);
				mobjPanelAddRemove.Name = "mobjPanelAddRemove";
				mobjPanelAddRemove.Size = new Size(195, 40);
				mobjPanelAddRemove.TabIndex = 2;
				mobjButtonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
				mobjButtonCancel.DialogResult = DialogResult.Cancel;
				mobjButtonCancel.Location = new Point(392, 8);
				mobjButtonCancel.Name = "mobjButtonCancel";
				mobjButtonCancel.TabIndex = 0;
				mobjButtonCancel.Text = "Cancel";
				mobjButtonCancel.Click += mobjButtonCancel_Click;
				mobjButtonOk.Anchor = AnchorStyles.Right | AnchorStyles.Top;
				mobjButtonOk.Location = new Point(304, 8);
				mobjButtonOk.Name = "mobjButtonOk";
				mobjButtonOk.TabIndex = 1;
				mobjButtonOk.Text = "OK";
				mobjButtonOk.Click += mobjButtonOk_Click;
				mobjListItems.Dock = DockStyle.Fill;
				mobjListItems.Location = new Point(0, 23);
				mobjListItems.Name = "mobjListItems";
				mobjListItems.Size = new Size(195, 303);
				mobjListItems.TabIndex = 3;
				mobjListItems.SelectedIndexChanged += mobjListItems_SelectedIndexChanged;
				mobjListItems.SelectionMode = SelectionMode.MultiExtended;
				mobjPropertyGrid.Dock = DockStyle.Fill;
				mobjPropertyGrid.HelpVisible = false;
				mobjPropertyGrid.LargeButtons = false;
				mobjPropertyGrid.LineColor = SystemColors.ScrollBar;
				mobjPropertyGrid.Location = new Point(0, 23);
				mobjPropertyGrid.Name = "mobjPropertyGrid";
				mobjPropertyGrid.Size = new Size(227, 349);
				mobjPropertyGrid.TabIndex = 1;
				mobjPropertyGrid.Text = "propertyGrid1";
				mobjPropertyGrid.ViewBackColor = SystemColors.Window;
				mobjPropertyGrid.ViewForeColor = SystemColors.WindowText;
				mobjButtonUp.Location = new Point(8, 0);
				mobjButtonUp.Name = "mobjButtonUp";
				mobjButtonUp.Size = new Size(24, 23);
				mobjButtonUp.TabIndex = 0;
				mobjButtonUp.Click += mobjButtonUp_Click;
				mobjButtonDown.Location = new Point(8, 32);
				mobjButtonDown.Name = "mobjButtonDown";
				mobjButtonDown.Size = new Size(24, 23);
				mobjButtonDown.TabIndex = 1;
				mobjButtonDown.Click += mobjButtonDown_Click;
				mobjButtonAdd.Location = new Point(0, 8);
				mobjButtonAdd.Name = "mobjButtonAdd";
				mobjButtonAdd.Size = new Size(88, 23);
				mobjButtonAdd.TabIndex = 0;
				mobjButtonAdd.Text = "Add";
				mobjButtonRemove.Location = new Point(96, 8);
				mobjButtonRemove.Name = "mobjButtonRemove";
				mobjButtonRemove.Size = new Size(88, 23);
				mobjButtonRemove.TabIndex = 1;
				mobjButtonRemove.Text = "Remove";
				mobjButtonRemove.Click += mobjButtonRemove_Click;
				base.ClientSize = new Size(480, 422);
				base.Controls.Add(mobjPanelProperties);
				base.Controls.Add(mobjPanelItems);
				base.Controls.Add(mobjPanelButtons);
				base.DockPadding.All = 5;
				base.Name = "Form2";
				Text = "Form2";
				mobjPanelButtons.ResumeLayout(blnPerformLayout: false);
				mobjPanelItems.ResumeLayout(blnPerformLayout: false);
				mobjPanelProperties.ResumeLayout(blnPerformLayout: false);
				mobjPanelUpDown.ResumeLayout(blnPerformLayout: false);
				mobjPanelAddRemove.ResumeLayout(blnPerformLayout: false);
				ResumeLayout(blnPerformLayout: false);
			}

			/// 
			/// Gets the property grid instance.
			/// </summary>
			/// </returns>
			protected internal virtual PropertyGrid GetPropertyGridInstance()
			{
				return new PropertyGrid();
			}

			private void mobjPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
			{
				mblnDirty = true;
				SuspendEnabledUpdates();
				try
				{
					ListItem listItem = (ListItem)mobjListItems.SelectedItem;
					if (listItem != null && listItem.UpdateDisplayText())
					{
						mobjListItems.Update();
						mobjLabelProperties.Text = SR.GetString("CollectionEditorProperties", GetDisplayText(listItem));
					}
				}
				finally
				{
					ResumeEnabledUpdates(blnUpdateGrid: false);
				}
			}

			private void objAddDropDownMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
			{
				Type type = objArgs.MenuItem.Tag as Type;
				if (type != null)
				{
					CreateAndAddInstance(type);
				}
			}

			private void mobjButtonCancel_Click(object sender, EventArgs e)
			{
				try
				{
					mobjCollectionEditor.CancelChanges();
					if (CollectionEditable && mblnDirty)
					{
						mblnDirty = false;
						mobjListItems.Items.Clear();
						if (mobjCreatedItems != null)
						{
							object[] array = mobjCreatedItems.ToArray();
							if (array.Length != 0 && array[0] is IComponent && ((IComponent)array[0]).Site != null)
							{
								return;
							}
							for (int i = 0; i < array.Length; i++)
							{
								DestroyInstance(array[i]);
							}
							mobjCreatedItems.Clear();
						}
						if (mobjRemovedItems != null)
						{
							mobjRemovedItems.Clear();
						}
						if (mobjOriginalItems != null && mobjOriginalItems.Count > 0)
						{
							object[] array2 = new object[mobjOriginalItems.Count];
							for (int j = 0; j < mobjOriginalItems.Count; j++)
							{
								array2[j] = mobjOriginalItems[j];
							}
							base.Items = array2;
							mobjOriginalItems.Clear();
						}
						else
						{
							base.Items = new object[0];
						}
					}
					Close();
				}
				catch (Exception objException)
				{
					base.DialogResult = DialogResult.None;
					DisplayError(objException);
				}
			}

			private void mobjButtonOk_Click(object sender, EventArgs e)
			{
				try
				{
					if (!mblnDirty || !CollectionEditable)
					{
						mblnDirty = false;
						base.DialogResult = DialogResult.Cancel;
					}
					else
					{
						if (mblnDirty)
						{
							object[] array = new object[mobjListItems.Items.Count];
							for (int i = 0; i < array.Length; i++)
							{
								array[i] = ((ListItem)mobjListItems.Items[i]).Value;
							}
							base.Items = array;
						}
						if (mobjRemovedItems != null && mblnDirty)
						{
							object[] array2 = mobjRemovedItems.ToArray();
							for (int j = 0; j < array2.Length; j++)
							{
								DestroyInstance(array2[j]);
							}
							mobjRemovedItems.Clear();
						}
						if (mobjCreatedItems != null)
						{
							mobjCreatedItems.Clear();
						}
						if (mobjOriginalItems != null)
						{
							mobjOriginalItems.Clear();
						}
						mobjListItems.Items.Clear();
						mblnDirty = false;
					}
					Close();
				}
				catch (Exception objException)
				{
					base.DialogResult = DialogResult.None;
					DisplayError(objException);
				}
			}

			private void mobjButtonRemove_Click(object sender, EventArgs e)
			{
				PerformRemove();
			}

			private void PerformRemove()
			{
				int selectedIndex = mobjListItems.SelectedIndex;
				if (selectedIndex == -1)
				{
					return;
				}
				SuspendEnabledUpdates();
				try
				{
					if (mobjListItems.SelectedItems.Count > 1)
					{
						ArrayList arrayList = new ArrayList(mobjListItems.SelectedItems);
						foreach (ListItem item in arrayList)
						{
							RemoveInternal(item);
						}
					}
					else
					{
						RemoveInternal((ListItem)mobjListItems.SelectedItem);
					}
					if (selectedIndex < mobjListItems.Items.Count)
					{
						mobjListItems.SelectedIndex = selectedIndex;
					}
					else if (mobjListItems.Items.Count > 0)
					{
						mobjListItems.SelectedIndex = mobjListItems.Items.Count - 1;
					}
				}
				finally
				{
					ResumeEnabledUpdates();
				}
			}

			private void RemoveInternal(ListItem objItem)
			{
				if (objItem == null)
				{
					return;
				}
				mobjCollectionEditor.OnItemRemoving(objItem.Value);
				mblnDirty = true;
				if (mobjCreatedItems != null && mobjCreatedItems.Contains(objItem.Value))
				{
					DestroyInstance(objItem.Value);
					mobjCreatedItems.Remove(objItem.Value);
					mobjListItems.Items.Remove(objItem);
					return;
				}
				try
				{
					if (!CanRemoveInstance(objItem.Value))
					{
						throw new Exception(SR.GetString("CollectionEditorCantRemoveItem", GetDisplayText(objItem)));
					}
					if (mobjRemovedItems == null)
					{
						mobjRemovedItems = new ArrayList();
					}
					mobjRemovedItems.Add(objItem.Value);
					mobjListItems.Items.Remove(objItem);
				}
				catch (Exception objException)
				{
					DisplayError(objException);
				}
			}

			private void mobjButtonAdd_Click(object sender, EventArgs e)
			{
				PerformAdd();
			}

			private void PerformAdd()
			{
				CreateAndAddInstance(base.NewItemTypes[0]);
			}

			private void CreateAndAddInstance(Type objType)
			{
				try
				{
					object objInstance = CreateInstance(objType);
					IList objectsFromInstance = mobjCollectionEditor.GetObjectsFromInstance(objInstance);
					if (objectsFromInstance != null)
					{
						AddItems(objectsFromInstance);
					}
				}
				catch (Exception objException)
				{
					DisplayError(objException);
				}
			}

			private void AddItems(IList objInstances)
			{
				if (mobjCreatedItems == null)
				{
					mobjCreatedItems = new ArrayList();
				}
				try
				{
					foreach (object objInstance in objInstances)
					{
						if (objInstance != null)
						{
							mblnDirty = true;
							mobjCreatedItems.Add(objInstance);
							ListItem listItem = new ListItem(mobjCollectionEditor, objInstance);
							listItem.UpdateDisplayText();
							mobjListItems.Items.Add(listItem);
						}
					}
				}
				finally
				{
				}
				SuspendEnabledUpdates();
				try
				{
					mobjListItems.ClearSelected();
					mobjListItems.SelectedIndex = mobjListItems.Items.Count - 1;
					object[] array = new object[mobjListItems.Items.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = ((ListItem)mobjListItems.Items[i]).Value;
					}
					base.Items = array;
					if (mobjListItems.Items.Count > 0 && mobjListItems.SelectedIndex != mobjListItems.Items.Count - 1)
					{
						mobjListItems.ClearSelected();
						mobjListItems.SelectedIndex = mobjListItems.Items.Count - 1;
					}
				}
				finally
				{
					ResumeEnabledUpdates();
				}
			}

			private void mobjListItems_SelectedIndexChanged(object sender, EventArgs e)
			{
				UpdateEnabled();
			}

			private void mobjButtonUp_Click(object sender, EventArgs e)
			{
				int selectedIndex = mobjListItems.SelectedIndex;
				if (selectedIndex == 0)
				{
					return;
				}
				mblnDirty = true;
				try
				{
					SuspendEnabledUpdates();
					object value = mobjListItems.Items[selectedIndex];
					mobjListItems.Items[selectedIndex] = mobjListItems.Items[selectedIndex - 1];
					mobjListItems.Items[selectedIndex - 1] = value;
					mobjListItems.ClearSelected();
					mobjListItems.SelectedIndex = selectedIndex - 1;
					Control control = (Control)sender;
					if (control.Enabled)
					{
						control.Focus();
					}
				}
				finally
				{
					ResumeEnabledUpdates(blnUpdateGrid: false);
				}
			}

			private void mobjButtonDown_Click(object sender, EventArgs e)
			{
				try
				{
					SuspendEnabledUpdates();
					mblnDirty = true;
					int selectedIndex = mobjListItems.SelectedIndex;
					if (selectedIndex != mobjListItems.Items.Count - 1)
					{
						object value = mobjListItems.Items[selectedIndex];
						mobjListItems.Items[selectedIndex] = mobjListItems.Items[selectedIndex + 1];
						mobjListItems.Items[selectedIndex + 1] = value;
						mobjListItems.ClearSelected();
						mobjListItems.SelectedIndex = selectedIndex + 1;
						Control control = (Control)sender;
						if (control.Enabled)
						{
							control.Focus();
						}
					}
				}
				finally
				{
					ResumeEnabledUpdates(blnUpdateGrid: false);
				}
			}

			private void SuspendEnabledUpdates()
			{
				mintSuspendEnabledCount++;
			}

			private void ResumeEnabledUpdates()
			{
				ResumeEnabledUpdates(blnUpdateGrid: true);
			}

			private void ResumeEnabledUpdates(bool blnUpdateGrid)
			{
				mintSuspendEnabledCount--;
				UpdateEnabled(blnUpdateGrid);
			}

			protected override void OnEditValueChanged()
			{
				if (mobjOriginalItems == null)
				{
					mobjOriginalItems = new ArrayList();
				}
				mobjOriginalItems.Clear();
				mobjListItems.Items.Clear();
				mobjPropertyGrid.Site = new PropertyGridSite(base.Context, mobjPropertyGrid);
				if (base.EditValue != null)
				{
					SuspendEnabledUpdates();
					try
					{
						object[] items = base.Items;
						for (int i = 0; i < items.Length; i++)
						{
							ListItem listItem = new ListItem(mobjCollectionEditor, items[i]);
							listItem.UpdateDisplayText();
							mobjListItems.Items.Add(listItem);
							mobjOriginalItems.Add(items[i]);
						}
						if (mobjListItems.Items.Count > 0)
						{
							mobjListItems.SelectedIndex = 0;
						}
						return;
					}
					finally
					{
						ResumeEnabledUpdates();
					}
				}
				UpdateEnabled();
			}

			private void UpdateEnabled()
			{
				UpdateEnabled(blnUpdateGrid: true);
			}

			private void UpdateEnabled(bool blnUpdateGrid)
			{
				if (mintSuspendEnabledCount > 0)
				{
					return;
				}
				bool flag = mobjListItems.SelectedItem != null && CollectionEditable;
				mobjButtonRemove.Enabled = flag && AllowRemoveInstance(((ListItem)mobjListItems.SelectedItem).Value);
				mobjButtonUp.Enabled = flag && mobjListItems.Items.Count > 1;
				mobjButtonDown.Enabled = flag && mobjListItems.Items.Count > 1;
				mobjPropertyGrid.Enabled = flag;
				mobjButtonAdd.Enabled = CollectionEditable;
				if (mobjListItems.SelectedItem == null)
				{
					mobjLabelProperties.Text = SR.GetString("CollectionEditorPropertiesNone");
					mobjPropertyGrid.SelectedObject = null;
					return;
				}
				object[] array;
				if (IsImmutable)
				{
					array = new object[1]
					{
						new SelectionWrapper(base.CollectionType, base.CollectionItemType, mobjListItems, mobjListItems.SelectedItems)
					};
				}
				else
				{
					array = new object[mobjListItems.SelectedItems.Count];
					for (int i = 0; i < array.Length; i++)
					{
						object value = ((ListItem)mobjListItems.SelectedItems[i]).Value;
						array[i] = GetPropertyGridSelectedObjectFromValue(value);
					}
				}
				int count = mobjListItems.SelectedItems.Count;
				if (count == -1 || count == 1)
				{
					mobjLabelProperties.Text = SR.GetString("CollectionEditorProperties", GetDisplayText((ListItem)mobjListItems.SelectedItem));
				}
				else
				{
					mobjLabelProperties.Text = SR.GetString("CollectionEditorPropertiesMultiSelect");
				}
				if (mobjCollectionEditor.IsAnyObjectInheritedReadOnly(array))
				{
					mobjPropertyGrid.SelectedObjects = null;
					mobjPropertyGrid.Enabled = false;
					mobjButtonRemove.Enabled = false;
					mobjButtonUp.Enabled = false;
					mobjButtonDown.Enabled = false;
					mobjLabelProperties.Text = SR.GetString("CollectionEditorInheritedReadOnlySelection");
				}
				else
				{
					mobjPropertyGrid.Enabled = true;
					if (blnUpdateGrid)
					{
						mobjPropertyGrid.SelectedObjects = array;
					}
				}
			}

			/// 
			/// Gets the property grid selected object from value.
			/// </summary>
			/// <param name="objValue">The object value.</param>
			/// </returns>
			protected internal virtual object GetPropertyGridSelectedObjectFromValue(object objValue)
			{
				return objValue;
			}

			private bool AllowRemoveInstance(object objValue)
			{
				if (mobjCreatedItems != null && mobjCreatedItems.Contains(objValue))
				{
					return true;
				}
				return CanRemoveInstance(objValue);
			}

			private string GetDisplayText(ListItem objItem)
			{
				if (objItem != null)
				{
					return objItem.ToString();
				}
				return string.Empty;
			}
		}

		/// Provides a modal dialog box for editing the contents of a collection using a <see cref="T:System.Drawing.Design.UITypeEditor"></see>.</summary>
		[Serializable]
		protected internal abstract class CollectionForm : Form
		{
			private const short mcntEditableDynamic = 0;

			private const short mcntEditableNo = 2;

			private short mshortEditableState;

			private const short mcntEditableYes = 1;

			private CollectionEditor mobjEditor;

			private object mobjValue;

			internal virtual bool CollectionEditable
			{
				get
				{
					if (mshortEditableState != 0)
					{
						return mshortEditableState == 1;
					}
					bool flag = typeof(IList).IsAssignableFrom(mobjEditor.CollectionType);
					if (flag && EditValue is IList list)
					{
						return !list.IsReadOnly;
					}
					return flag;
				}
				set
				{
					if (value)
					{
						mshortEditableState = 1;
					}
					else
					{
						mshortEditableState = 2;
					}
				}
			}

			/// Gets the data type of each item in the collection.</summary>
			/// The data type of the collection items.</returns>
			protected Type CollectionItemType => mobjEditor.CollectionItemType;

			/// Gets the data type of the collection object.</summary>
			/// The data type of the collection object.</returns>
			protected Type CollectionType => mobjEditor.CollectionType;

			/// Gets a type descriptor that indicates the current context.</summary>
			/// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
			protected new ITypeDescriptorContext Context => mobjEditor.Context;

			/// Gets or sets the collection object to edit.</summary>
			/// The collection object to edit.</returns>
			public object EditValue
			{
				get
				{
					return mobjValue;
				}
				set
				{
					mobjValue = value;
					OnEditValueChanged();
				}
			}

			/// Gets or sets the array of items for this form to display.</summary>
			/// An array of objects for the form to display.</returns>
			protected object[] Items
			{
				get
				{
					return mobjEditor.GetItems(EditValue);
				}
				set
				{
					bool flag = false;
					try
					{
						flag = Context.OnComponentChanging();
					}
					catch (Exception objException)
					{
						if (ClientUtils.IsCriticalException(objException))
						{
							throw;
						}
						DisplayError(objException);
					}
					if (flag)
					{
						object obj = mobjEditor.SetItems(EditValue, value);
						if (obj != EditValue)
						{
							EditValue = obj;
						}
						Context.OnComponentChanged();
					}
				}
			}

			/// Gets the available item types that can be created for this collection.</summary>
			/// The types of items that can be created.</returns>
			protected Type[] NewItemTypes => mobjEditor.NewItemTypes;

			/// Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> class.</summary>
			/// <param name="objEditor">The <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> to use for editing the collection. </param>
			public CollectionForm(CollectionEditor objEditor)
			{
				mobjEditor = objEditor;
			}

			/// Indicates whether you can remove the original members of the collection.</summary>
			/// true if it is permissible to remove this value from the collection; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanRemoveInstance(System.Object)"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
			/// <param name="value">The value to remove. </param>
			protected bool CanRemoveInstance(object objValue)
			{
				return mobjEditor.CanRemoveInstance(objValue);
			}

			/// Indicates whether multiple collection items can be selected at once.</summary>
			/// true if it multiple collection members can be selected at the same time; otherwise, false. By default, this method returns the value from <see cref="M:System.ComponentModel.Design.CollectionEditor.CanSelectMultipleInstances"></see> of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> for this form.</returns>
			protected virtual bool CanSelectMultipleInstances()
			{
				return mobjEditor.CanSelectMultipleInstances();
			}

			/// Creates a new instance of the specified collection item type.</summary>
			/// A new instance of the specified object, or null if the user chose to cancel the creation of this instance.</returns>
			/// <param name="objItemType">The type of item to create. </param>
			protected object CreateInstance(Type objItemType)
			{
				return mobjEditor.CreateInstance(objItemType);
			}

			/// Destroys the specified instance of the object.</summary>
			/// <param name="objInstance">The object to destroy. </param>
			protected void DestroyInstance(object objInstance)
			{
				mobjEditor.DestroyInstance(objInstance);
			}

			/// Displays the specified exception to the user.</summary>
			/// <param name="objException">The exception to display. </param>
			protected virtual void DisplayError(Exception objException)
			{
			}

			/// Gets the requested service, if it is available.</summary>
			/// An instance of the service, or null if the service cannot be found.</returns>
			/// <param name="objServiceType">The type of service to retrieve. </param>
			protected override object GetService(Type objServiceType)
			{
				return mobjEditor.GetService(objServiceType);
			}

			/// Provides an opportunity to perform processing when a collection value has changed.</summary>
			protected abstract void OnEditValueChanged();

			/// Shows the dialog box for the collection editor using the specified <see cref="T:Gizmox.WebGUI.Forms.Design.IWindowsFormsEditorService"></see> object.</summary>
			/// A <see cref="T:Gizmox.WebGUI.Forms.DialogResult"></see> that indicates the result code returned from the dialog box.</returns>
			/// <param name="objEditorService">An <see cref="T:Gizmox.WebGUI.Forms.Design.IWebUIEditorService"></see> that can be used to show the dialog box. </param>
			protected internal virtual void ShowEditorDialog(IWebUIEditorService objEditorService)
			{
				objEditorService.ShowDialog(this);
			}

			/// 
			/// Gets the display name of the type.
			/// </summary>
			/// <param name="objType">Type of the object.</param>
			/// </returns>
			protected string GetTypeDisplayName(Type objType)
			{
				object[] customAttributes = objType.GetCustomAttributes(typeof(WebCollectionEditorItemTypeNameAttribute), inherit: true);
				if (customAttributes.Length == 1)
				{
					WebCollectionEditorItemTypeNameAttribute webCollectionEditorItemTypeNameAttribute = customAttributes[0] as WebCollectionEditorItemTypeNameAttribute;
					return webCollectionEditorItemTypeNameAttribute.DisplayName;
				}
				return objType.Name;
			}
		}

		private Type mobjCollectionItemType;

		private ITypeDescriptorContext mobjCurrentContext;

		private Type[] marrNewItemTypes;

		private Type mobjType;

		/// Gets the data type of each item in the collection.</summary>
		/// The data type of the collection items.</returns>
		protected Type CollectionItemType
		{
			get
			{
				if (mobjCollectionItemType == null)
				{
					mobjCollectionItemType = CreateCollectionItemType();
				}
				return mobjCollectionItemType;
			}
		}

		/// Gets the data type of the collection object.</summary>
		/// The data type of the collection object.</returns>
		protected Type CollectionType => mobjType;

		/// Gets a type descriptor that indicates the current context.</summary>
		/// An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context currently in use, or null if no context is available.</returns>
		protected ITypeDescriptorContext Context => mobjCurrentContext;

		/// Gets the available types of items that can be created for this collection.</summary>
		/// The types of items that can be created.</returns>
		protected Type[] NewItemTypes
		{
			get
			{
				if (marrNewItemTypes == null)
				{
					marrNewItemTypes = CreateNewItemTypes();
				}
				return marrNewItemTypes;
			}
		}

		/// 
		/// Gets a value indicating whether this editor value should support text editing.
		/// </summary>
		/// </value>
		/// true if editor value should support text editing; otherwise, false. </returns>
		public override bool IsTextEditable => false;

		/// Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.</summary>
		/// <param name="objType">The type of the collection for this editor to edit. </param>
		public CollectionEditor(Type objType)
		{
			mobjType = objType;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:System.ComponentModel.Design.CollectionEditor"></see> class using the specified collection type.
		/// </summary>
		public CollectionEditor()
		{
		}

		/// Cancels changes to the collection.</summary>
		protected virtual void CancelChanges()
		{
		}

		/// Indicates whether original members of the collection can be removed.</summary>
		/// true if it is permissible to remove this value from the collection; otherwise, false. The default implementation always returns true.</returns>
		/// <param name="value">The value to remove. </param>
		protected virtual bool CanRemoveInstance(object objValue)
		{
			if (objValue is IComponent component)
			{
				InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(component)[typeof(InheritanceAttribute)];
				if (inheritanceAttribute != null && inheritanceAttribute.InheritanceLevel != InheritanceLevel.NotInherited)
				{
					return false;
				}
			}
			return true;
		}

		/// Indicates whether multiple collection items can be selected at once.</summary>
		/// true if it multiple collection members can be selected at the same time; otherwise, false. By default, this returns true.</returns>
		protected virtual bool CanSelectMultipleInstances()
		{
			return true;
		}

		/// Creates a new form to display and edit the current collection.</summary>
		/// A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.</returns>
		protected virtual CollectionForm CreateCollectionForm()
		{
			return new CollectionEditorCollectionForm(this);
		}

		/// Gets the data type that this collection contains.</summary>
		/// The data type of the items in the collection, or an <see cref="T:System.Object"></see> if no Item property can be located on the collection.</returns>
		protected virtual Type CreateCollectionItemType()
		{
			PropertyInfo[] properties = CollectionType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < properties.Length; i++)
			{
				if (properties[i].Name.Equals("Item") || properties[i].Name.Equals("Items"))
				{
					return properties[i].PropertyType;
				}
			}
			return typeof(object);
		}

		/// Creates a new instance of the specified collection item type.</summary>
		/// A new instance of the specified object.</returns>
		/// <param name="objItemType">The type of item to create. </param>
		protected virtual object CreateInstance(Type objItemType)
		{
			return CreateInstance(objItemType, null);
		}

		internal static object CreateInstance(Type objItemType, string strName)
		{
			object obj = null;
			return Activator.CreateInstance(objItemType);
		}

		/// Gets the data types that this collection editor can contain.</summary>
		/// An array of data types that this collection can contain.</returns>
		protected virtual Type[] CreateNewItemTypes()
		{
			return new Type[1] { CollectionItemType };
		}

		/// Destroys the specified instance of the object.</summary>
		/// <param name="objInstance">The object to destroy. </param>
		protected virtual void DestroyInstance(object objInstance)
		{
			if (objInstance is IComponent component)
			{
				component.Dispose();
			}
			else if (objInstance is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		/// Edits the value of the specified object using the specified service provider and context.</summary>
		/// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
		/// <param name="objValue">The object to edit the value of. </param>
		/// <param name="objProvider">A service provider object through which editing services can be obtained. </param>
		/// <param name="objHandler"></param>
		/// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
		public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			if (objProvider != null)
			{
				IWebUIEditorService webUIEditorService = (IWebUIEditorService)objProvider.GetService(typeof(IWebUIEditorService));
				if (webUIEditorService != null)
				{
					mobjCurrentContext = objContext;
					CollectionForm collectionForm = CreateCollectionForm();
					ITypeDescriptorContext typeDescriptorContext = mobjCurrentContext;
					collectionForm.EditValue = objValue;
					collectionForm.ShowEditorDialog(webUIEditorService);
				}
			}
		}

		/// Retrieves the display text for the given list item.</summary>
		/// The display text for value.</returns>
		/// <param name="objValue">The list item for which to retrieve display text.</param>
		protected virtual string GetDisplayText(object objValue)
		{
			if (objValue == null)
			{
				return string.Empty;
			}
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objValue)["Name"];
			string text;
			if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
			{
				text = (string)propertyDescriptor.GetValue(objValue);
				if (text != null && text.Length > 0)
				{
					return text;
				}
			}
			propertyDescriptor = TypeDescriptor.GetDefaultProperty(CollectionType);
			if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(string))
			{
				text = (string)propertyDescriptor.GetValue(objValue);
				if (text != null && text.Length > 0)
				{
					return text;
				}
			}
			text = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
			if (text != null && text.Length != 0)
			{
				return text;
			}
			return objValue.GetType().Name;
		}

		/// Gets the edit style used by the <see cref="M:System.ComponentModel.Design.CollectionEditor.EditValue(System.ComponentModel.ITypeDescriptorContext,System.IServiceProvider,System.Object)"></see> method.</summary>
		/// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> enumeration value indicating the provided editing style. If the method is not supported in the specified context, this method will return the <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see> identifier.</returns>
		/// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information. </param>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
		{
			return UITypeEditorEditStyle.Modal;
		}

		/// Gets an array of objects containing the specified collection.</summary>
		/// An array containing the collection objects, or an empty object array if the specified collection does not inherit from <see cref="T:System.Collections.ICollection"></see>.</returns>
		/// <param name="objEditValue">The collection to edit. </param>
		protected virtual object[] GetItems(object objEditValue)
		{
			if (objEditValue == null || !(objEditValue is ICollection))
			{
				return new object[0];
			}
			ArrayList arrayList = new ArrayList();
			ICollection collection = (ICollection)objEditValue;
			foreach (object item in collection)
			{
				arrayList.Add(item);
			}
			object[] array = new object[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		/// Returns a list containing the given object</summary>
		/// An <see cref="T:System.Collections.ArrayList"></see> which contains the individual objects to be created.</returns>
		/// <param name="objInstance">An <see cref="T:System.Collections.ArrayList"></see> returned as an object.</param>
		protected virtual IList GetObjectsFromInstance(object objInstance)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(objInstance);
			return arrayList;
		}

		/// Gets the requested service, if it is available.</summary>
		/// An instance of the service, or null if the service cannot be found.</returns>
		/// <param name="objServiceType">The type of service to retrieve. </param>
		protected object GetService(Type objServiceType)
		{
			if (Context != null)
			{
				return Context.GetService(objServiceType);
			}
			return null;
		}

		private bool IsAnyObjectInheritedReadOnly(object[] arrItems)
		{
			return false;
		}

		internal virtual void OnItemRemoving(object objItem)
		{
		}

		/// Sets the specified array as the items of the collection.</summary>
		/// The newly created collection object or, otherwise, the collection indicated by the editValue parameter.</returns>
		/// <param name="objEditValue">The collection to edit. </param>
		/// <param name="arrValues">An array of objects to set as the collection items. </param>
		protected virtual object SetItems(object objEditValue, object[] arrValues)
		{
			if (objEditValue != null)
			{
				Array items = GetItems(objEditValue);
				int length = items.Length;
				int num = arrValues.Length;
				if (!(objEditValue is IList))
				{
					return objEditValue;
				}
				IList list = (IList)objEditValue;
				list.Clear();
				for (int i = 0; i < arrValues.Length; i++)
				{
					list.Add(arrValues[i]);
				}
			}
			return objEditValue;
		}

		/// Displays the default Help topic for the collection editor.</summary>
		protected virtual void ShowHelp()
		{
		}
	}
}
