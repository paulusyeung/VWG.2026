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
/// Provides a user interface for browsing the properties of an object.</summary>
	/// 1</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(PropertyGrid), "PropertyGrid_45.bmp")]
	[DesignTimeController("Design.PropertyGridController, Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PropertyGridController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Data")]
	[MetadataTag("PG")]
	[Skin(typeof(PropertyGridSkin))]
	public class PropertyGrid : ContainerControl, ISealedComponent
	{
		private interface IUnimplemented
		{
		}

		[Serializable]
		private class PropertyGridServiceProvider : IServiceProvider
		{
			private PropertyGrid mobjOwner;

			public PropertyGridServiceProvider(PropertyGrid objOwner)
			{
				mobjOwner = objOwner;
			}

			public object GetService(Type objServiceType)
			{
				object obj = null;
				if (mobjOwner.ActiveDesigner != null)
				{
					obj = mobjOwner.ActiveDesigner.GetService(objServiceType);
				}
				if (obj == null)
				{
					obj = mobjOwner.mobjPropertyGridView.GetService(objServiceType);
				}
				if (obj == null && mobjOwner.Site != null)
				{
					obj = mobjOwner.Site.GetService(objServiceType);
				}
				return obj;
			}
		}

		/// Contains a collection of <see cref="T:Design.PropertyTab"></see> objects.</summary>
		[Serializable]
		public class PropertyTabCollection : ICollection, IEnumerable
		{
			/// 
			///
			/// </summary>
			internal static PropertyTabCollection Empty;

			/// 
			///
			/// </summary>
			private PropertyGrid mobjOwner;

			/// Gets the number of Property tabs in the collection.</summary>
			/// The number of Property tabs in the collection.</returns>
			public int Count
			{
				get
				{
					if (mobjOwner == null)
					{
						return 0;
					}
					return mobjOwner.marrViewTabs.Length;
				}
			}

			/// Gets the <see cref="T:Design.PropertyTab"></see> at the specified index.</summary>
			/// The <see cref="T:Design.PropertyTab"></see> at the specified index.</returns>
			/// <param name="index">The index of the <see cref="T:Design.PropertyTab"></see> to return. </param>
			public PropertyTab this[int index]
			{
				get
				{
					if (mobjOwner == null)
					{
						throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
					}
					return mobjOwner.marrViewTabs[index];
				}
			}

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => this;

			static PropertyTabCollection()
			{
				Empty = new PropertyTabCollection(null);
			}

			internal PropertyTabCollection(PropertyGrid objOwner)
			{
				mobjOwner = objOwner;
			}

			/// Adds a Property tab of the specified type to the collection.</summary>
			/// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
			public void AddTabType(Type objPropertyTabType)
			{
				if (mobjOwner == null)
				{
					throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
				}
				mobjOwner.AddTab(objPropertyTabType, PropertyTabScope.Global);
			}

			/// Adds a Property tab of the specified type and with the specified scope to the collection.</summary>
			/// <param name="objPropertyTabType">The Property tab type to add to the grid. </param>
			/// <param name="objPropertyTabScope">One of the <see cref="T:System.ComponentModel.PropertyTabScope"></see> values. </param>
			public void AddTabType(Type objPropertyTabType, PropertyTabScope objPropertyTabScope)
			{
				if (mobjOwner == null)
				{
					throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
				}
				mobjOwner.AddTab(objPropertyTabType, objPropertyTabScope);
			}

			/// Removes all the Property tabs of the specified scope from the collection.</summary>
			/// <param name="objPropertyTabScope">The scope of the tabs to clear. </param>
			/// <exception cref="T:System.ArgumentException">The assigned value of the objPropertyTabScope parameter is less than the Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
			public void Clear(PropertyTabScope objPropertyTabScope)
			{
				if (mobjOwner == null)
				{
					throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
				}
				mobjOwner.ClearTabs(objPropertyTabScope);
			}

			/// Returns an enumeration of all the Property tabs in the collection.</summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:PropertyGrid.PropertyTabCollection"></see>.</returns>
			public IEnumerator GetEnumerator()
			{
				if (mobjOwner == null)
				{
					return new PropertyTab[0].GetEnumerator();
				}
				return mobjOwner.marrViewTabs.GetEnumerator();
			}

			/// Removes the specified tab type from the collection.</summary>
			/// <param name="objPropertyTabType">The tab type to remove from the collection. </param>
			public void RemoveTabType(Type objPropertyTabType)
			{
				if (mobjOwner == null)
				{
					throw new InvalidOperationException(SR.GetString("PropertyGridPropertyTabCollectionReadOnly"));
				}
				mobjOwner.RemoveTab(objPropertyTabType);
			}

			void ICollection.CopyTo(Array objDestinationArray, int index)
			{
				if (mobjOwner != null && mobjOwner.marrViewTabs.Length != 0)
				{
					Array.Copy(mobjOwner.marrViewTabs, 0, objDestinationArray, index, mobjOwner.marrViewTabs.Length);
				}
			}
		}

		internal class SelectedObjectConverter : ReferenceConverter
		{
			public SelectedObjectConverter()
				: base(typeof(IComponent))
			{
			}
		}

		/// 
		/// The PropertySortChanged event registration.
		/// </summary>
		private static readonly SerializableEvent PropertySortChangedEvent;

		/// 
		/// The PropertyTabChanged event registration.
		/// </summary>
		private static readonly SerializableEvent PropertyTabChangedEvent;

		/// 
		/// The PropertyValueChanged event registration.
		/// </summary>
		private static readonly SerializableEvent PropertyValueChangedEvent;

		/// 
		/// The PropertyValueChanging event registration.
		/// </summary>
		private static readonly SerializableEvent PropertyValueChangingEvent;

		/// 
		/// The SelectedGridItemChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedGridItemChangedEvent;

		/// 
		/// The SelectedObjectsChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedObjectsChangedEvent;

		/// 
		/// The showing type editor event
		/// </summary>
		private static readonly SerializableEvent ShowingTypeEditorEvent;

		private const ushort mcntTabsChanging = 8;

		private const int mcntPROPERTIES = 0;

		private const ushort mcntPropertiesChanged = 1;

		private const ushort mcntRefreshingProperties = 512;

		private const ushort mcntReInitTab = 32;

		private const ushort mcntInternalChange = 4;

		private const int mcntLARGE_BUTTONS = 1;

		private const int mcntEVENTS = 1;

		private const int mcntMIN_GRID_HEIGHT = 20;

		private const int mcntNO_SORT = 2;

		private const int mcntNORMAL_BUTTONS = 0;

		private const ushort mcntFullRefreshAfterBatch = 128;

		private const ushort mcntGotDesignerEventService = 2;

		private const int mcntCXINDENT = 0;

		private const int mcntCYDIVIDER = 3;

		private const int mcntCYINDENT = 2;

		private const int mcntALPHA = 1;

		private const ushort mcntBatchMode = 16;

		private const ushort mcntBatchModeChange = 256;

		private const int mcntCATEGORIES = 0;

		/// 
		/// Attributes indicating browsable properties
		/// </summary>
		[NonSerialized]
		private System.ComponentModel.AttributeCollection mobjBrowsableAttributes;

		/// 
		/// The current browsed objects
		/// </summary>
		[NonSerialized]
		private object[] marrCurrentObjects;

		/// 
		/// All the property entries
		/// </summary>
		[NonSerialized]
		private GridEntryCollection mobjCurrentPropEntries;

		/// 
		/// The documentation panel
		/// </summary>
		[NonSerialized]
		private Panel mobjDocComment;

		/// 
		/// The splitter for the documentation panel
		/// </summary>
		[NonSerialized]
		private Splitter mobjSplitter;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private Label mobjLabelDocTitle;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private Label mobjLabelDocDescription;

		/// 
		/// Reference to the containing designer if there is one
		/// </summary>
		[NonSerialized]
		private IDesignerHost mobjDesignerHost;

		/// 
		/// Gets or sets the state
		/// </summary>
		/// The state.</value>
		[NonSerialized]
		private ushort mState;

		/// 
		/// Reference to the internal property grid view control.
		/// </summary>
		[NonSerialized]
		private PropertyGridView mobjPropertyGridView;

		/// 
		/// Visibility flag indicating if the help is visible
		/// </summary>
		private bool mblnHelpVisible = true;

		/// 
		/// The default grid entry
		/// </summary>
		[NonSerialized]
		private GridEntry mobjDefaultGridEntry;

		/// 
		/// Reference to the main grid entry
		/// </summary>
		[NonSerialized]
		private GridEntry mobjMainGridEntry;

		/// 
		/// The current sort value
		/// </summary>
		private PropertySort menmPropertySortValue;

		/// 
		/// The current selected view sort
		/// </summary>
		private int mintSelectedViewSort;

		/// 
		/// The current selected view tab
		/// </summary>
		private int mintSelectedViewTab;

		/// 
		/// ToolStrip serperator
		/// </summary>
		[NonSerialized]
		private ToolStripSeparator mobjTBSeperator1;

		/// 
		/// ToolStrip serperator
		/// </summary>
		[NonSerialized]
		private ToolStripSeparator mobjTBSeperator2;

		/// 
		/// ToolStrip visibility flag
		/// </summary>
		private bool mblnToolbarVisible;

		/// 
		/// The internal ToolStrip
		/// </summary>
		[NonSerialized]
		private PropertyGridToolStrip mobjToolStrip;

		/// 
		/// The Reset button
		/// </summary>
		[NonSerialized]
		private ToolStripButton mobjResetButton;

		/// 
		/// The current ToolStrip sort buttons
		/// </summary>
		[NonSerialized]
		private ToolStripButton[] marrViewSortButtons;

		/// 
		/// The current ToolStrip tab buttons
		/// </summary>
		[NonSerialized]
		private ToolStripButton[] marrViewTabButtons;

		/// 
		/// The current property tabs
		/// </summary>
		[NonSerialized]
		private Hashtable mobjViewTabProps;

		/// 
		/// The current property tabs
		/// </summary>
		[NonSerialized]
		private PropertyTab[] marrViewTabs;

		/// 
		/// Property tab scope collection
		/// </summary>
		[NonSerialized]
		private PropertyTabScope[] marrViewTabScopes;

		/// 
		/// Dirty flag indicating if tabs are dirty
		/// </summary>
		[NonSerialized]
		private bool mblnViewTabsDirty;

		private long mlngPrivateId = 1L;

		/// 
		/// Gets the hanlder for the PropertySortChanged event.
		/// </summary>
		private EventHandler PropertySortChangedHandler => (EventHandler)GetHandler(PropertySortChangedEvent);

		/// 
		/// Gets the hanlder for the PropertyTabChanged event.
		/// </summary>
		private PropertyTabChangedEventHandler PropertyTabChangedHandler => (PropertyTabChangedEventHandler)GetHandler(PropertyTabChangedEvent);

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected override string ClientEventsPropogationTags => string.Format("WC:{0}", "PV");

		/// 
		/// Gets the hanlder for the PropertyValueChanged event.
		/// </summary>
		private PropertyValueChangedEventHandler PropertyValueChangedHandler => (PropertyValueChangedEventHandler)GetHandler(PropertyValueChangedEvent);

		/// 
		/// Gets the handler for the PropertyValueChanging event.
		/// </summary>
		private PropertyValueChangingEventHandler PropertyValueChangingHandler => (PropertyValueChangingEventHandler)GetHandler(PropertyValueChangingEvent);

		/// 
		/// Gets the hanlder for the SelectedGridItemChanged event.
		/// </summary>
		private SelectedGridItemChangedEventHandler SelectedGridItemChangedHandler => (SelectedGridItemChangedEventHandler)GetHandler(SelectedGridItemChangedEvent);

		/// 
		/// Gets the hanlder for the SelectedObjectsChanged event.
		/// </summary>
		private EventHandler SelectedObjectsChangedHandler => (EventHandler)GetHandler(SelectedObjectsChangedEvent);

		/// 
		/// Gets the showing type editor handler.
		/// </summary>
		/// 
		/// The showing type editor handler.
		/// </value>
		private ShowingTypeEditorEventHandler ShowingTypeEditorHandler => (ShowingTypeEditorEventHandler)GetHandler(ShowingTypeEditorEvent);

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize;

		/// 
		/// Gets a value indicating whether serializable object should serialize controls.
		/// </summary>
		/// 
		/// 	true</c> if serializable object should serialize controls; otherwise, false</c>.
		/// </value>
		protected override bool ShouldSerializableObjectSerializeControls => false;

		internal IDesignerHost ActiveDesigner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// This property is not relevant for this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override bool AutoScroll
		{
			get
			{
				return base.AutoScroll;
			}
			set
			{
				base.AutoScroll = value;
			}
		}

		/// Gets or sets the browsable attributes associated with the object that the property grid is attached to.</summary>
		/// The collection of browsable attributes associated with the object.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public System.ComponentModel.AttributeCollection BrowsableAttributes
		{
			get
			{
				if (mobjBrowsableAttributes == null)
				{
					mobjBrowsableAttributes = new System.ComponentModel.AttributeCollection(new BrowsableAttribute(browsable: true));
				}
				return mobjBrowsableAttributes;
			}
			set
			{
				if (value == null || value == System.ComponentModel.AttributeCollection.Empty)
				{
					mobjBrowsableAttributes = new System.ComponentModel.AttributeCollection(BrowsableAttribute.Yes);
				}
				else
				{
					Attribute[] array = new Attribute[value.Count];
					value.CopyTo(array, 0);
					mobjBrowsableAttributes = new System.ComponentModel.AttributeCollection(array);
				}
				if (marrCurrentObjects != null && marrCurrentObjects.Length != 0 && mobjMainGridEntry != null)
				{
					mobjMainGridEntry.BrowsableAttributes = BrowsableAttributes;
					Refresh(blnClearCached: true);
				}
			}
		}

		private bool CanCopy => mobjPropertyGridView.CanCopy;

		private bool CanCut => mobjPropertyGridView.CanCut;

		private bool CanPaste => mobjPropertyGridView.CanPaste;

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets the main GridItem. i.e. the root item.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public GridItem MainGridItem => mobjMainGridEntry;

		/// Gets a value indicating whether the commands pane can be made visible for the currently selected objects.</summary>
		/// true if the commands pane can be made visible; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[SRDescription("PropertyGridCanShowCommandsDesc")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual bool CanShowCommands => false;

		private bool CanUndo => mobjPropertyGridView.CanUndo;

		/// Gets or sets the text color used for category headings. </summary>
		/// A <see cref="T:System.Drawing.Color"></see> structure representing the text color.</returns>
		[SRCategory("CatAppearance")]
		[SRDescription("PropertyGridCategoryForeColorDesc")]
		[DefaultValue(typeof(Color), "ControlText")]
		public Color CategoryForeColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		/// Gets a value indicating whether the commands pane is visible.</summary>
		/// true if the commands pane is visible; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public virtual bool CommandsVisible => false;

		/// Gets or sets a value indicating whether the commands pane is visible for objects that expose verbs.</summary>
		/// true if the commands pane is visible; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		[SRDescription("PropertyGridCommandsVisibleIfAvailable")]
		public virtual bool CommandsVisibleIfAvailable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:Control.ControlCollection"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ControlCollection Controls => base.Controls;

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(130, 130);

		/// Gets the type of the default tab.</summary>
		/// A <see cref="T:System.Type"></see> representing the default tab.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual Type DefaultTabType => typeof(PropertiesTab);

		/// Gets or sets a value indicating whether the <see cref="T:PropertyGrid"></see> control paints its toolbar with flat buttons.</summary>
		/// true if the <see cref="T:PropertyGrid"></see> paints its toolbar with flat buttons; otherwise false. The default is false.</returns>
		protected bool DrawFlatToolbar
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// This property is not relevant for this class.</summary>
		/// A <see cref="T:System.Drawing.Color"></see>.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// Gets or sets the background color for the Help region.</summary>
		/// One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for controls.</returns>
		/// 1</filterpriority>
		[SRDescription("PropertyGridHelpBackColorDesc")]
		[SRCategory("CatAppearance")]
		public Color HelpBackColor
		{
			get
			{
				return mobjDocComment.BackColor;
			}
			set
			{
				mobjDocComment.BackColor = value;
			}
		}

		/// Gets or sets the foreground color for the Help region.</summary>
		/// One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for control text.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(typeof(Color), "ControlText")]
		[SRDescription("PropertyGridHelpForeColorDesc")]
		public Color HelpForeColor
		{
			get
			{
				return mobjDocComment.ForeColor;
			}
			set
			{
				mobjDocComment.ForeColor = value;
			}
		}

		/// Gets or sets a value indicating whether the Help text is visible.</summary>
		/// true if the help text is visible; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		[Localizable(true)]
		[SRDescription("PropertyGridHelpVisibleDesc")]
		public virtual bool HelpVisible
		{
			get
			{
				return mblnHelpVisible;
			}
			set
			{
				if (mblnHelpVisible != value)
				{
					mblnHelpVisible = value;
					mobjSplitter.Visible = value;
					mobjDocComment.Visible = value;
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether buttons appear in standard size or in large size.</summary>
		/// true if buttons on the control appear large; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("PropertyGridLargeButtonsDesc")]
		public bool LargeButtons
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets the color of the gridlines and borders.</summary>
		/// One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for scroll bars.</returns>
		/// 1</filterpriority>
		[SRDescription("PropertyGridLineColorDesc")]
		[DefaultValue(typeof(Color), "InactiveBorder")]
		[SRCategory("CatAppearance")]
		public Color LineColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		internal PropertyGridView PropertyGridView => mobjPropertyGridView;

		/// 
		/// Gets the property grid skin.
		/// </summary>
		/// The property grid skin.</value>
		private PropertyGridSkin PropertyGridSkin => base.Skin as PropertyGridSkin;

		/// Gets or sets the type of sorting the <see cref="T:PropertyGrid"></see> uses to display properties.</summary>
		/// One of the <see cref="T:PropertySort"></see> values. The default is <see cref="F:PropertySort.Categorized"></see> or <see cref="F:PropertySort.Alphabetical"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:PropertySort"></see> values.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("PropertyGridPropertySortDesc")]
		[DefaultValue(3)]
		public PropertySort PropertySort
		{
			get
			{
				return menmPropertySortValue;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(PropertySort));
				}
				if ((value & PropertySort.Categorized) != PropertySort.NoSort)
				{
					ToolStripButton toolStripButton = marrViewSortButtons[0];
				}
				else if ((value & PropertySort.Alphabetical) != PropertySort.NoSort)
				{
					ToolStripButton toolStripButton = marrViewSortButtons[1];
				}
				GridItem selectedGridItem = SelectedGridItem;
				menmPropertySortValue = value;
				if (selectedGridItem != null)
				{
					try
					{
						SelectedGridItem = selectedGridItem;
					}
					catch (ArgumentException)
					{
					}
				}
			}
		}

		/// Gets the collection of property tabs that are displayed in the grid.</summary>
		/// A <see cref="T:PropertyGrid.PropertyTabCollection"></see> containing the collection of <see cref="T:Design.PropertyTab"></see> objects being displayed by the <see cref="T:PropertyGrid"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PropertyTabCollection PropertyTabs => new PropertyTabCollection(this);

		/// Gets or sets the selected grid item.</summary>
		/// The currently selected row in the property grid.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public GridItem SelectedGridItem
		{
			get
			{
				GridItem selectedGridEntry = mobjPropertyGridView.SelectedGridEntry;
				if (selectedGridEntry == null)
				{
					return mobjMainGridEntry;
				}
				return selectedGridEntry;
			}
			set
			{
				mobjPropertyGridView.SelectedGridEntry = (GridEntry)value;
			}
		}

		/// Gets or sets the object for which the grid displays properties.</summary>
		/// The first object in the object list. If there is no currently selected object the return is null.</returns>
		/// 1</filterpriority>
		[SRDescription("PropertyGridSelectedObjectDesc")]
		[SRCategory("CatBehavior")]
		[DefaultValue(null)]
		[TypeConverter(typeof(SelectedObjectConverter))]
		public object SelectedObject
		{
			get
			{
				if (marrCurrentObjects != null && marrCurrentObjects.Length != 0)
				{
					return marrCurrentObjects[0];
				}
				return null;
			}
			set
			{
				if (value != SelectedObject || SelectedObjects.Length > 1)
				{
					if (value == null)
					{
						SelectedObjects = new object[0];
						return;
					}
					SelectedObjects = new object[1] { value };
				}
			}
		}

		/// Gets or sets the currently selected objects.</summary>
		/// An array of type <see cref="T:System.Object"></see>. The default is an empty array.</returns>
		/// <exception cref="T:System.ArgumentException">One of the items in the array of objects had a null value. </exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object[] SelectedObjects
		{
			get
			{
				if (marrCurrentObjects == null)
				{
					return new object[0];
				}
				return (object[])marrCurrentObjects.Clone();
			}
			set
			{
				bool flag = false;
				SetState(128, blnValue: false);
				if (GetState(16))
				{
					SetState(256, blnValue: false);
				}
				mobjPropertyGridView.EnsurePendingChangesCommitted();
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = true;
				if (value != null && value.Length != 0)
				{
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] == null)
						{
							throw new ArgumentException("SelectedObjects can not have a null item.");
						}
						if (value[i] is IUnimplemented)
						{
							throw new NotSupportedException("SelectedObjects can not contain PropertyGrid.");
						}
					}
				}
				else
				{
					flag4 = false;
				}
				if (marrCurrentObjects != null && value != null && marrCurrentObjects.Length == value.Length)
				{
					flag2 = true;
					flag3 = true;
					for (int j = 0; j < value.Length; j++)
					{
						if (!(flag2 || flag3))
						{
							break;
						}
						if (flag2 && marrCurrentObjects[j] != value[j])
						{
							flag2 = false;
						}
						Type type = GetUnwrappedObject(j).GetType();
						object obj = value[j];
						if (obj is ICustomTypeDescriptor)
						{
							obj = ((ICustomTypeDescriptor)obj).GetPropertyOwner(null);
						}
						Type type2 = obj.GetType();
						if (flag3 && (type != type2 || (type.IsCOMObject && type2.IsCOMObject)))
						{
							flag3 = false;
						}
					}
				}
				if (!flag2)
				{
					flag = true;
					flag4 = flag4 && GetState(2);
					SetStatusBox("", "");
					ClearCachedProps();
					if (value == null)
					{
						marrCurrentObjects = new object[0];
					}
					else
					{
						marrCurrentObjects = (object[])value.Clone();
					}
					SetState(1, blnValue: true);
					if (mobjPropertyGridView != null)
					{
						mobjPropertyGridView.RemoveSelectedEntryHelpAttributes();
					}
					if (mobjMainGridEntry != null)
					{
						mobjMainGridEntry.Dispose();
					}
					if (!flag3 && !GetState(8) && mintSelectedViewTab < marrViewTabButtons.Length)
					{
						Type type3 = ((mintSelectedViewTab == -1) ? null : marrViewTabs[mintSelectedViewTab].GetType());
						ToolStripButton objToolBarButton = null;
						RefreshTabs(PropertyTabScope.Component);
						EnableTabs();
						if (type3 != null)
						{
							for (int k = 0; k < marrViewTabs.Length; k++)
							{
								if (marrViewTabs[k].GetType() == type3 && marrViewTabButtons[k].Visible)
								{
									objToolBarButton = marrViewTabButtons[k];
									break;
								}
							}
						}
						SelectViewTabButtonDefault(objToolBarButton);
					}
					if (flag4 && marrViewTabs != null && marrViewTabs.Length > 1 && marrViewTabs[1] is EventsTab)
					{
						flag4 = marrViewTabButtons[1].Visible;
						Attribute[] array = new Attribute[BrowsableAttributes.Count];
						BrowsableAttributes.CopyTo(array, 0);
						Hashtable hashtable = null;
						if (marrCurrentObjects.Length > 10)
						{
							hashtable = new Hashtable();
						}
						for (int l = 0; l < marrCurrentObjects.Length && flag4; l++)
						{
							object obj2 = marrCurrentObjects[l];
							if (obj2 is ICustomTypeDescriptor)
							{
								obj2 = ((ICustomTypeDescriptor)obj2).GetPropertyOwner(null);
							}
							Type type4 = obj2.GetType();
							if (hashtable == null || !hashtable.Contains(type4))
							{
								flag4 = flag4 && obj2 is IComponent && ((IComponent)obj2).Site != null;
								PropertyDescriptorCollection properties = ((EventsTab)marrViewTabs[1]).GetProperties(obj2, array);
								flag4 = flag4 && properties != null && properties.Count > 0;
								if (flag4 && hashtable != null)
								{
									hashtable[type4] = type4;
								}
							}
						}
					}
					ShowEventsButton(flag4 && marrCurrentObjects.Length != 0);
					DisplayHotCommands();
					if (marrCurrentObjects.Length == 1)
					{
						EnablePropPageButton(marrCurrentObjects[0]);
					}
					else
					{
						EnablePropPageButton(null);
					}
					OnSelectedObjectsChanged(EventArgs.Empty);
				}
				if (!GetState(8))
				{
					if (marrCurrentObjects.Length != 0 && GetState(32))
					{
						Refresh(blnClearCached: false);
						SetState(32, blnValue: false);
					}
					else
					{
						Refresh(blnClearCached: true);
					}
					if (marrCurrentObjects.Length != 0)
					{
						SaveTabSelection();
					}
				}
				if (flag)
				{
					FireObservableItemPropertyChanged("SelectedObjects");
				}
			}
		}

		/// 
		/// Gets the currently selected property tab.
		/// </summary>
		/// The selected tab.</value>
		/// The <see cref="T:Design.PropertyTab"></see> that is providing the selected view.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PropertyTab SelectedTab => marrViewTabs[mintSelectedViewTab];

		/// 
		/// Gets the reset button.
		/// </summary>
		/// 
		/// The reset button.
		/// </value>
		internal ToolStripButton ResetButton => mobjResetButton;

		/// 
		/// Gets a value indicating whether [show focus cues].
		/// </summary>
		/// true</c> if [show focus cues]; otherwise, false</c>.</value>
		protected internal bool ShowFocusCues => true;

		/// 
		/// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:System.ComponentModel.Component"></see>.
		/// </summary>
		/// </value>
		/// The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:System.ComponentModel.Component"></see>, if any. null if the <see cref="T:System.ComponentModel.Component"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:System.ComponentModel.Component"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:System.ComponentModel.Component"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				mobjPropertyGridView.ServiceProvider = value;
				if (value == null)
				{
					ActiveDesigner = null;
				}
				else
				{
					ActiveDesigner = (IDesignerHost)value.GetService(typeof(IDesignerHost));
				}
			}
		}

		internal bool SupportsUseCompatibleTextRendering => true;

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// Gets or sets a value indicating whether the ToolStrip is visible.</summary>
		/// true if the ToolStrip is visible; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRDescription("PropertyGridToolbarVisibleDesc")]
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public virtual bool ToolbarVisible
		{
			get
			{
				return mblnToolbarVisible;
			}
			set
			{
				mblnToolbarVisible = value;
				mobjToolStrip.Visible = value;
				if (value)
				{
					SetupToolbar(mblnViewTabsDirty);
				}
				Invalidate();
				mobjToolStrip.Invalidate();
			}
		}

		/// 
		/// Gets the tool strip.
		/// </summary>
		public ToolStrip Toolbar => mobjToolStrip;

		/// Gets or sets a value indicating the background color in the grid.</summary>
		/// One of the <see cref="T:System.Drawing.Color"></see> values. The default is the default system color for windows.</returns>
		/// 2</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("PropertyGridViewBackColorDesc")]
		[DefaultValue(typeof(Color), "Window")]
		public Color ViewBackColor
		{
			get
			{
				return mobjPropertyGridView.BackColor;
			}
			set
			{
				mobjPropertyGridView.BackColor = value;
				mobjPropertyGridView.Invalidate();
			}
		}

		/// Gets or sets a value indicating the color of the text in the grid.</summary>
		/// One of the <see cref="T:System.Drawing.Color"></see> values. The default is current system color for text in windows.</returns>
		/// 2</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(typeof(Color), "WindowText")]
		[SRDescription("PropertyGridViewForeColorDesc")]
		public Color ViewForeColor
		{
			get
			{
				return mobjPropertyGridView.ForeColor;
			}
			set
			{
				mobjPropertyGridView.ForeColor = value;
				mobjPropertyGridView.Invalidate();
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// Occurs when the sort mode is changed.</summary>
		/// 1</filterpriority>
		[SRDescription("PropertyGridPropertySortChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler PropertySortChanged
		{
			add
			{
				AddHandler(PropertySortChangedEvent, value);
			}
			remove
			{
				RemoveHandler(PropertySortChangedEvent, value);
			}
		}

		/// Occurs when a property tab changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("PropertyGridPropertyTabchangedDescr")]
		public event PropertyTabChangedEventHandler PropertyTabChanged
		{
			add
			{
				AddHandler(PropertyTabChangedEvent, value);
			}
			remove
			{
				RemoveHandler(PropertyTabChangedEvent, value);
			}
		}

		/// Occurs when a property value changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("PropertyGridPropertyValueChangedDescr")]
		public event PropertyValueChangedEventHandler PropertyValueChanged
		{
			add
			{
				AddHandler(PropertyValueChangedEvent, value);
			}
			remove
			{
				RemoveHandler(PropertyValueChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("Occurs when property value changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientPropertyValueChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// Occurs when a property value is about to change.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanging")]
		[SRDescription("PropertyGridPropertyValueChangingDescr")]
		public event PropertyValueChangingEventHandler PropertyValueChanging
		{
			add
			{
				AddHandler(PropertyValueChangingEvent, value);
			}
			remove
			{
				RemoveHandler(PropertyValueChangingEvent, value);
			}
		}

		/// Occurs when the selected <see cref="T:GridItem"></see> is changed.</summary>
		/// 1</filterpriority>
		[SRDescription("PropertyGridSelectedGridItemChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event SelectedGridItemChangedEventHandler SelectedGridItemChanged
		{
			add
			{
				AddHandler(SelectedGridItemChangedEvent, value);
			}
			remove
			{
				RemoveHandler(SelectedGridItemChangedEvent, value);
			}
		}

		[SRDescription("Occurs when property grid's entry selected item changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectedGridItemChanged
		{
			add
			{
				AddClientHandler("Activated", value);
			}
			remove
			{
				RemoveClientHandler("Activated", value);
			}
		}

		/// Occurs when the objects selected by the <see cref="P:PropertyGrid.SelectedObjects"></see> property have changed.</summary>
		/// 1</filterpriority>
		[SRDescription("PropertyGridSelectedObjectsChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler SelectedObjectsChanged
		{
			add
			{
				AddHandler(SelectedObjectsChangedEvent, value);
			}
			remove
			{
				RemoveHandler(SelectedObjectsChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [showing type editor].
		/// </summary>
		internal event ShowingTypeEditorEventHandler ShowingTypeEditor
		{
			add
			{
				AddHandler(ShowingTypeEditorEvent, value);
			}
			remove
			{
				RemoveHandler(ShowingTypeEditorEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:PropertyGrid"></see> class.
		/// </summary>
		public PropertyGrid()
		{
			InitializeComponent();
		}

		/// 
		/// Initialize the component contained controls
		/// </summary>
		private void InitializeComponent()
		{
			mblnHelpVisible = true;
			mblnToolbarVisible = true;
			mblnViewTabsDirty = true;
			marrViewTabs = new PropertyTab[0];
			marrViewTabScopes = new PropertyTabScope[0];
			menmPropertySortValue = PropertySort.CategorizedAlphabetical;
			SuspendLayout();
			try
			{
				mobjPropertyGridView = CreateGridView(null);
				mobjPropertyGridView.TabStop = true;
				mobjPropertyGridView.TabIndex = 2;
				mobjPropertyGridView.Dock = DockStyle.Fill;
				mobjPropertyGridView.Visible = true;
				mobjTBSeperator1 = CreateSeparatorButton();
				mobjTBSeperator2 = CreateSeparatorButton();
				mobjToolStrip = new PropertyGridToolStrip();
				mobjToolStrip.TabStop = true;
				mobjToolStrip.Dock = DockStyle.Top;
				mobjToolStrip.Text = "PropertyGridToolBar";
				mobjToolStrip.TabIndex = 1;
				mobjToolStrip.GripStyle = ToolStripGripStyle.Hidden;
				mobjToolStrip.AutoSize = false;
				mobjToolStrip.Height = 24;
				AddRefTab(DefaultTabType, null, PropertyTabScope.Static, blnSetupToolbar: true);
				CreateDocComment();
				SuspendLayout();
				mobjSplitter.Dock = DockStyle.Bottom;
				mobjSplitter.Visible = mblnHelpVisible;
				mobjDocComment.BorderStyle = PropertyGridSkin.HelpPanelStyle.BorderStyle;
				mobjDocComment.BorderColor = PropertyGridSkin.HelpPanelStyle.BorderColor;
				mobjDocComment.Padding = PropertyGridSkin.HelpPanelStyle.Padding;
				mobjDocComment.BackColor = PropertyGridSkin.HelpPanelStyle.BackColor;
				mobjDocComment.Dock = DockStyle.Bottom;
				mobjDocComment.Visible = mblnHelpVisible;
				Controls.Add(mobjPropertyGridView);
				Controls.Add(mobjSplitter);
				Controls.Add(mobjDocComment);
				Controls.Add(mobjToolStrip);
				ResumeLayout(blnPerformLayout: false);
				SetupToolbar();
				Text = "PropertyGrid";
			}
			catch (Exception)
			{
			}
			finally
			{
				if (mobjDocComment != null)
				{
					mobjDocComment.ResumeLayout(blnPerformLayout: false);
				}
				ResumeLayout(blnPerformLayout: true);
			}
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
		}

		internal void AddRefTab(Type objTabType, object objComponent, PropertyTabScope objPropertyTabScope, bool blnSetupToolbar)
		{
			PropertyTab propertyTab = null;
			int num = -1;
			if (marrViewTabs != null)
			{
				for (int i = 0; i < marrViewTabs.Length; i++)
				{
					if (objTabType == marrViewTabs[i].GetType())
					{
						propertyTab = marrViewTabs[i];
						num = i;
						break;
					}
				}
			}
			else
			{
				num = 0;
			}
			if (propertyTab == null)
			{
				IDesignerHost objDesignerHost = null;
				if (objComponent != null && objComponent is IComponent && ((IComponent)objComponent).Site != null)
				{
					objDesignerHost = (IDesignerHost)((IComponent)objComponent).Site.GetService(typeof(IDesignerHost));
				}
				try
				{
					propertyTab = CreateTab(objTabType, objDesignerHost);
				}
				catch (Exception)
				{
					return;
				}
				if (marrViewTabs != null)
				{
					num = marrViewTabs.Length;
					if (objTabType == DefaultTabType)
					{
						num = 0;
					}
					else if (typeof(EventsTab).IsAssignableFrom(objTabType))
					{
						num = 1;
					}
					else
					{
						for (int j = 1; j < marrViewTabs.Length; j++)
						{
							if (!(marrViewTabs[j] is EventsTab) && string.Compare(propertyTab.TabName, marrViewTabs[j].TabName, ignoreCase: false, CultureInfo.InvariantCulture) < 0)
							{
								num = j;
								break;
							}
						}
					}
				}
				PropertyTab[] array = new PropertyTab[marrViewTabs.Length + 1];
				Array.Copy(marrViewTabs, 0, array, 0, num);
				Array.Copy(marrViewTabs, num, array, num + 1, marrViewTabs.Length - num);
				array[num] = propertyTab;
				marrViewTabs = array;
				mblnViewTabsDirty = true;
				PropertyTabScope[] array2 = new PropertyTabScope[marrViewTabScopes.Length + 1];
				Array.Copy(marrViewTabScopes, 0, array2, 0, num);
				Array.Copy(marrViewTabScopes, num, array2, num + 1, marrViewTabScopes.Length - num);
				array2[num] = objPropertyTabScope;
				marrViewTabScopes = array2;
			}
			if (propertyTab != null && objComponent != null)
			{
				try
				{
					object[] components = propertyTab.Components;
					int num2 = ((components != null) ? components.Length : 0);
					object[] array3 = new object[num2 + 1];
					if (num2 > 0)
					{
						Array.Copy(components, array3, num2);
					}
					array3[num2] = objComponent;
					propertyTab.Components = array3;
				}
				catch (Exception)
				{
					RemoveTab(num, blnSetupToolbar: false);
				}
			}
			if (blnSetupToolbar)
			{
				SetupToolbar();
				ShowEventsButton(blnValue: false);
			}
		}

		/// 
		/// Adds the tab.
		/// </summary>
		/// <param name="objTabType">Type of the obj tab.</param>
		/// <param name="objScope">The obj scope.</param>
		internal void AddTab(Type objTabType, PropertyTabScope objScope)
		{
			AddRefTab(objTabType, null, objScope, blnSetupToolbar: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="objPropertyTabScope"></param>
		internal void ClearTabs(PropertyTabScope objPropertyTabScope)
		{
			if (objPropertyTabScope < PropertyTabScope.Document)
			{
				throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
			}
			RemoveTabs(objPropertyTabScope, blnSetupToolbar: true);
		}

		/// 
		///
		/// </summary>
		private void ClearCachedProps()
		{
			if (mobjViewTabProps != null)
			{
				mobjViewTabProps.Clear();
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objTabType"></param>
		internal void RemoveTab(Type objTabType)
		{
			int num = -1;
			for (int i = 0; i < marrViewTabs.Length; i++)
			{
				if (objTabType == marrViewTabs[i].GetType())
				{
					PropertyTab propertyTab = marrViewTabs[i];
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				PropertyTab[] destinationArray = new PropertyTab[marrViewTabs.Length - 1];
				Array.Copy(marrViewTabs, 0, destinationArray, 0, num);
				Array.Copy(marrViewTabs, num + 1, destinationArray, num, marrViewTabs.Length - num - 1);
				marrViewTabs = destinationArray;
				PropertyTabScope[] destinationArray2 = new PropertyTabScope[marrViewTabScopes.Length - 1];
				Array.Copy(marrViewTabScopes, 0, destinationArray2, 0, num);
				Array.Copy(marrViewTabScopes, num + 1, destinationArray2, num, marrViewTabScopes.Length - num - 1);
				marrViewTabScopes = destinationArray2;
				mblnViewTabsDirty = true;
				SetupToolbar();
			}
		}

		/// 
		/// Removes the tab.
		/// </summary>
		/// <param name="intTabIndex">Index of the int tab.</param>
		/// <param name="blnSetupToolbar">if set to true</c> [BLN setup toolbar].</param>
		internal void RemoveTab(int intTabIndex, bool blnSetupToolbar)
		{
			if (intTabIndex >= marrViewTabs.Length || intTabIndex < 0)
			{
				throw new ArgumentOutOfRangeException("tabIndex", SR.GetString("PropertyGridBadTabIndex"));
			}
			if (marrViewTabScopes[intTabIndex] == PropertyTabScope.Static)
			{
				throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
			}
			if (mintSelectedViewTab == intTabIndex)
			{
				mintSelectedViewTab = 0;
			}
			ToolStripButton toolStripButton = marrViewTabButtons[mintSelectedViewTab];
			PropertyTab[] destinationArray = new PropertyTab[marrViewTabs.Length - 1];
			Array.Copy(marrViewTabs, 0, destinationArray, 0, intTabIndex);
			Array.Copy(marrViewTabs, intTabIndex + 1, destinationArray, intTabIndex, marrViewTabs.Length - intTabIndex - 1);
			marrViewTabs = destinationArray;
			PropertyTabScope[] destinationArray2 = new PropertyTabScope[marrViewTabScopes.Length - 1];
			Array.Copy(marrViewTabScopes, 0, destinationArray2, 0, intTabIndex);
			Array.Copy(marrViewTabScopes, intTabIndex + 1, destinationArray2, intTabIndex, marrViewTabScopes.Length - intTabIndex - 1);
			marrViewTabScopes = destinationArray2;
			mblnViewTabsDirty = true;
			if (blnSetupToolbar)
			{
				SetupToolbar();
				mintSelectedViewTab = -1;
			}
		}

		/// 
		/// Removes the tabs.
		/// </summary>
		/// <param name="enmClassification">The enm classification.</param>
		/// <param name="blnSetupToolbar">if set to true</c> [BLN setup toolbar].</param>
		internal void RemoveTabs(PropertyTabScope enmClassification, bool blnSetupToolbar)
		{
			if (enmClassification == PropertyTabScope.Static)
			{
				throw new ArgumentException(SR.GetString("PropertyGridRemoveStaticTabs"));
			}
			if (marrViewTabButtons == null || marrViewTabs == null || marrViewTabScopes == null)
			{
				return;
			}
			ToolStripButton toolStripButton = ((mintSelectedViewTab >= 0 && mintSelectedViewTab < marrViewTabButtons.Length) ? marrViewTabButtons[mintSelectedViewTab] : null);
			for (int num = marrViewTabs.Length - 1; num >= 0; num--)
			{
				if (marrViewTabScopes[num] >= enmClassification)
				{
					if (mintSelectedViewTab == num)
					{
						mintSelectedViewTab = -1;
					}
					else if (mintSelectedViewTab > num)
					{
						mintSelectedViewTab--;
					}
					PropertyTab[] destinationArray = new PropertyTab[marrViewTabs.Length - 1];
					Array.Copy(marrViewTabs, 0, destinationArray, 0, num);
					Array.Copy(marrViewTabs, num + 1, destinationArray, num, marrViewTabs.Length - num - 1);
					marrViewTabs = destinationArray;
					PropertyTabScope[] destinationArray2 = new PropertyTabScope[marrViewTabScopes.Length - 1];
					Array.Copy(marrViewTabScopes, 0, destinationArray2, 0, num);
					Array.Copy(marrViewTabScopes, num + 1, destinationArray2, num, marrViewTabScopes.Length - num - 1);
					marrViewTabScopes = destinationArray2;
					mblnViewTabsDirty = true;
				}
			}
			if (blnSetupToolbar && mblnViewTabsDirty)
			{
				SetupToolbar();
				mintSelectedViewTab = -1;
				for (int i = 0; i < marrViewTabs.Length; i++)
				{
					marrViewTabs[i].Components = new object[0];
				}
			}
		}

		/// When overridden in a derived class, enables the creation of a <see cref="T:Design.PropertyTab"></see>.</summary>
		/// The newly created property tab. Returns null in its default implementation.</returns>
		/// <param name="objTabType">The type of tab to create. </param>
		protected virtual PropertyTab CreatePropertyTab(Type objTabType)
		{
			return null;
		}

		/// 
		///
		/// </summary>
		/// <param name="objTabType"></param>
		/// <param name="objDesignerHost"></param>
		/// </returns>
		private PropertyTab CreateTab(Type objTabType, IDesignerHost objDesignerHost)
		{
			PropertyTab propertyTab = CreatePropertyTab(objTabType);
			if (propertyTab == null)
			{
				ConstructorInfo constructor = objTabType.GetConstructor(new Type[1] { typeof(IServiceProvider) });
				object obj = null;
				if (constructor == null)
				{
					constructor = objTabType.GetConstructor(new Type[1] { typeof(IDesignerHost) });
					if (constructor != null)
					{
						obj = objDesignerHost;
					}
				}
				else
				{
					obj = Site;
				}
				propertyTab = ((obj == null || !(constructor != null)) ? ((PropertyTab)Activator.CreateInstance(objTabType)) : ((PropertyTab)constructor.Invoke(new object[1] { obj })));
			}
			return propertyTab;
		}

		private void EnableTabs()
		{
			if (marrCurrentObjects == null)
			{
				return;
			}
			SetupToolbar();
			for (int i = 1; i < marrViewTabs.Length; i++)
			{
				bool flag = true;
				for (int j = 0; j < marrCurrentObjects.Length; j++)
				{
					try
					{
						if (marrViewTabs[i].CanExtend(GetUnwrappedObject(j)))
						{
							continue;
						}
						flag = false;
						break;
					}
					catch (Exception)
					{
						flag = false;
						break;
					}
				}
				if (flag != marrViewTabButtons[i].Visible)
				{
					marrViewTabButtons[i].Visible = flag;
					if (!flag && i == mintSelectedViewTab)
					{
						SelectViewTabButton(marrViewTabButtons[0], blnUpdateSelection: true);
					}
				}
			}
		}

		private void SelectViewTabButton(ToolStripButton objToolBarButton, bool blnUpdateSelection)
		{
			SelectViewTabButtonDefault(objToolBarButton);
			if (blnUpdateSelection)
			{
				Refresh(blnClearCached: false);
			}
		}

		/// 
		/// Resets the selected property.
		/// </summary>
		public void ResetSelectedProperty()
		{
			GridEntry selectedGridEntry = mobjPropertyGridView.SelectedGridEntry;
			if (selectedGridEntry != null)
			{
				ResetSelectedProperty(selectedGridEntry.PropertyDescriptor);
			}
			else
			{
				ResetSelectedProperty(null);
			}
		}

		/// 
		/// Resets the selected property.
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		public virtual void ResetSelectedProperty(PropertyDescriptor objPropertyDescriptor)
		{
			mobjPropertyGridView.Reset();
		}

		/// 
		/// Clears the value caches
		/// </summary>
		internal void ClearValueCaches()
		{
			if (mobjMainGridEntry != null)
			{
				mobjMainGridEntry.ClearCachedValues();
			}
		}

		/// Collapses all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
		/// 2</filterpriority>
		public void CollapseAllGridItems()
		{
		}

		private void CreateDocComment()
		{
			mobjDocComment = new Panel();
			mobjSplitter = new Splitter();
			mobjSplitter.Height = 5;
			mobjLabelDocTitle = new Label(string.Empty);
			mobjLabelDocTitle.Font = new Font(Font, FontStyle.Bold);
			mobjLabelDocTitle.Dock = DockStyle.Top;
			mobjLabelDocDescription = new Label(string.Empty);
			mobjLabelDocDescription.Font = Font;
			mobjLabelDocDescription.Dock = DockStyle.Fill;
			mobjDocComment.Controls.Add(mobjLabelDocDescription);
			mobjDocComment.Controls.Add(mobjLabelDocTitle);
		}

		/// 
		/// Creates the grid view
		/// </summary>
		/// <param name="objServiceProvider"></param>
		/// </returns>
		private PropertyGridView CreateGridView(IServiceProvider objServiceProvider)
		{
			return new PropertyGridView(objServiceProvider, this);
		}

		/// 
		/// Create a Push button
		/// </summary>
		/// <param name="strToolTipText">The STR tool tip text.</param>
		/// <param name="strSkinImage">The STR skin image.</param>
		/// <param name="objEventHandler">The obj event handler.</param>
		/// </returns>
		private ToolStripButton CreatePushButton(string strToolTipText, string strSkinImage, EventHandler objEventHandler)
		{
			ToolStripButton toolStripButton = new ToolStripButton();
			toolStripButton.Text = strToolTipText;
			toolStripButton.AutoToolTip = true;
			toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			if (strSkinImage != string.Empty)
			{
				toolStripButton.Image = base.Skin.GetResourceHandle(strSkinImage);
			}
			toolStripButton.Click += objEventHandler;
			toolStripButton.ImageScaling = ToolStripItemImageScaling.SizeToFit;
			return toolStripButton;
		}

		/// 
		/// Creates the separator button.
		/// </summary>
		/// </returns>
		private ToolStripSeparator CreateSeparatorButton()
		{
			ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
			toolStripSeparator.Height = 20;
			return toolStripSeparator;
		}

		/// 
		/// Unregister a grid component.
		/// </summary>
		/// <param name="objComponent">Component.</param>
		internal void UnRegisterGridComponent(IRegisteredComponentMember objComponent)
		{
			if (objComponent.IsRegistered)
			{
				objComponent.MemberID = 0L;
				objComponent.IsRegistered = false;
			}
		}

		/// 
		/// Unregister a collection of grid components
		/// </summary>
		/// <param name="objComponents"></param>
		internal void UnRegisterGridComponents(ICollection objComponents)
		{
			foreach (IRegisteredComponentMember objComponent in objComponents)
			{
				UnRegisterGridComponent(objComponent);
			}
		}

		/// 
		/// Provides a registering service for contained components.
		/// </summary>
		/// <param name="objComponent"></param>
		internal void RegisterGridComponent(IRegisteredComponentMember objComponent)
		{
			if (!objComponent.IsRegistered)
			{
				objComponent.MemberID = mlngPrivateId++;
				objComponent.IsRegistered = true;
			}
		}

		/// 
		/// Provides a registering service for contained components.
		/// </summary>
		/// <param name="objComponents"></param>
		internal void RegisterGridComponents(ICollection objComponents)
		{
			foreach (IRegisteredComponentMember objComponent in objComponents)
			{
				RegisterGridComponent(objComponent);
			}
		}

		/// Expands all the categories in the <see cref="T:PropertyGrid"></see>.</summary>
		/// 1</filterpriority>
		public void ExpandAllGridItems()
		{
		}

		private static Type[] GetCommonTabs(object[] arrObjects, PropertyTabScope objPropertyTabScope)
		{
			if (arrObjects == null || arrObjects.Length == 0)
			{
				return new Type[0];
			}
			Type[] array = new Type[5];
			int num = 0;
			PropertyTabAttribute propertyTabAttribute = (PropertyTabAttribute)TypeDescriptor.GetAttributes(arrObjects[0])[typeof(PropertyTabAttribute)];
			if (propertyTabAttribute == null)
			{
				return new Type[0];
			}
			for (int i = 0; i < propertyTabAttribute.TabScopes.Length; i++)
			{
				PropertyTabScope propertyTabScope = propertyTabAttribute.TabScopes[i];
				if (propertyTabScope == objPropertyTabScope)
				{
					if (num == array.Length)
					{
						Type[] array2 = new Type[num * 2];
						Array.Copy(array, 0, array2, 0, num);
						array = array2;
					}
					array[num++] = propertyTabAttribute.TabClasses[i];
				}
			}
			if (num == 0)
			{
				return new Type[0];
			}
			for (int i = 1; i < arrObjects.Length; i++)
			{
				if (num <= 0)
				{
					break;
				}
				propertyTabAttribute = (PropertyTabAttribute)TypeDescriptor.GetAttributes(arrObjects[i])[typeof(PropertyTabAttribute)];
				if (propertyTabAttribute == null)
				{
					return new Type[0];
				}
				for (int j = 0; j < num; j++)
				{
					bool flag = false;
					for (int k = 0; k < propertyTabAttribute.TabClasses.Length; k++)
					{
						if (propertyTabAttribute.TabClasses[k] == array[j])
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						array[j] = array[num - 1];
						array[num - 1] = null;
						num--;
						j--;
					}
				}
			}
			Type[] array3 = new Type[num];
			if (num > 0)
			{
				Array.Copy(array, 0, array3, 0, num);
			}
			return array3;
		}

		internal GridEntry GetDefaultGridEntry()
		{
			if (mobjDefaultGridEntry == null && mobjCurrentPropEntries != null)
			{
				mobjDefaultGridEntry = (GridEntry)mobjCurrentPropEntries[0];
			}
			return mobjDefaultGridEntry;
		}

		/// 
		/// Get the state of a specific flag
		/// </summary>
		private bool GetState(ushort flag)
		{
			return (mState & flag) != 0;
		}

		internal GridEntryCollection GetPropEntries()
		{
			if (mobjCurrentPropEntries == null)
			{
				UpdateSelection();
			}
			SetState(1, blnValue: false);
			return mobjCurrentPropEntries;
		}

		private PropertyGridView GetPropertyGridView()
		{
			return mobjPropertyGridView;
		}

		private object GetUnwrappedObject(int intIndex)
		{
			if (marrCurrentObjects == null || intIndex < 0 || intIndex > marrCurrentObjects.Length)
			{
				return null;
			}
			object obj = marrCurrentObjects[intIndex];
			if (obj is ICustomTypeDescriptor)
			{
				obj = ((ICustomTypeDescriptor)obj).GetPropertyOwner(null);
			}
			return obj;
		}

		/// 
		/// Gets the property value.
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		/// <param name="objTarget">The obj target.</param>
		/// </returns>
		protected internal virtual object GetPropertyValue(PropertyDescriptor objPropertyDescriptor, object objTarget)
		{
			return objPropertyDescriptor.GetValue(objTarget);
		}

		/// 
		/// Sets the property value.
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objValue">The obj value.</param>
		protected internal virtual void SetPropertyValue(PropertyDescriptor objPropertyDescriptor, object objComponent, object objValue)
		{
			objPropertyDescriptor.SetValue(objComponent, objValue);
		}

		/// 
		/// Determines whether this instance [can reset property value] the specified obj grid entry.
		/// </summary>
		/// <param name="objGridEntry">The obj grid entry.</param>
		/// 
		///   true</c> if this instance [can reset property value] the specified obj grid entry; otherwise, false</c>.
		/// </returns>
		protected internal virtual bool CanResetPropertyValue(GridEntry objGridEntry)
		{
			return objGridEntry?.CanResetPropertyValue() ?? false;
		}

		/// Raises the <see cref="M:System.Drawing.Design.IPropertyValueUIService.NotifyPropertyValueUIItemsChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		/// <param name="sender">The source of the event. </param>
		protected void OnNotifyPropertyValueUIItemsChanged(object sender, EventArgs e)
		{
			mobjPropertyGridView.Invalidate(blnInvalidateChildren: true);
		}

		/// Raises the <see cref="E:PropertyGrid.PropertySortChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnPropertySortChanged(EventArgs e)
		{
			PropertySortChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:PropertyGrid.PropertyTabChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:PropertyTabChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnPropertyTabChanged(PropertyTabChangedEventArgs e)
		{
			PropertyTabChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:PropertyGrid.PropertyValueChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:PropertyValueChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
		{
			PropertyValueChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the PropertyValue event.
		/// </summary>
		internal void OnPropertyValueSet(GridItem objChangedItem, object objOldValue)
		{
			OnPropertyValueChanged(new PropertyValueChangedEventArgs(objChangedItem, objOldValue));
		}

		/// Raises the <see cref="E:PropertyGrid.PropertyValueChanging"></see> event.</summary>
		/// <param name="e">A <see cref="T:PropertyValueChangingEventArgs"></see> that contains the event data. </param>
		protected virtual void OnPropertyValueChanging(PropertyValueChangingEventArgs e)
		{
			PropertyValueChangingHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the PropertyValueChanging event.
		/// Returns true if the action should be cancelled</returns>
		/// </summary>
		internal PropertyValueChangingEventArgs OnPropertyValueSetting(GridItem objChangingItem, object objNewValue)
		{
			PropertyValueChangingEventArgs e = new PropertyValueChangingEventArgs(objChangingItem, objNewValue);
			OnPropertyValueChanging(e);
			return e;
		}

		/// Raises the <see cref="E:PropertyGrid.SelectedGridItemChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:SelectedGridItemChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnSelectedGridItemChanged(SelectedGridItemChangedEventArgs e)
		{
			SelectedGridItemChangedHandler?.Invoke(this, e);
		}

		internal void OnSelectedGridItemChanged(GridEntry objOldEntry, GridEntry objNewEntry)
		{
			OnSelectedGridItemChanged(new SelectedGridItemChangedEventArgs(objOldEntry, objNewEntry));
		}

		/// Raises the <see cref="E:PropertyGrid.SelectedObjectsChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnSelectedObjectsChanged(EventArgs e)
		{
			SelectedObjectsChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:OnShowingEditTypeEditor" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ShowingTypeEditorEventArgs" /> instance containing the event data.</param>
		internal virtual void OnShowingEditTypeEditor(ShowingTypeEditorEventArgs e)
		{
			ShowingTypeEditorHandler?.Invoke(this, e);
		}

		private void OnTransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
		{
		}

		/// 
		/// Causes the property grid to refresh it's view.
		/// </summary>
		private void Refresh(bool blnClearCached)
		{
			if (base.Disposing || GetState(512))
			{
				return;
			}
			try
			{
				SetState(512, blnValue: true);
				if (blnClearCached)
				{
					ClearCachedProps();
				}
				RefreshProperties(blnClearCached);
				mobjPropertyGridView.Refresh();
				DisplayHotCommands();
			}
			finally
			{
				SetState(512, blnValue: false);
				mobjPropertyGridView.Update();
			}
		}

		private void OnTransactionOpened(object sender, EventArgs e)
		{
			SetState(16, blnValue: true);
		}

		/// 
		/// Causes the property grid to refresh it's view.
		/// </summary>
		/// 2</filterpriority>
		public new void Refresh()
		{
			Refresh(blnClearCached: true);
		}

		/// 
		/// Causes the property grid to refresh it's calculated properties.
		/// </summary>
		protected internal void RefreshProperties(bool blnClearCached)
		{
			if (blnClearCached && mintSelectedViewTab != -1 && marrViewTabs != null)
			{
				PropertyTab propertyTab = marrViewTabs[mintSelectedViewTab];
				if (propertyTab != null && mobjViewTabProps != null)
				{
					string key = propertyTab.TabName + menmPropertySortValue;
					mobjViewTabProps.Remove(key);
				}
			}
			SetState(1, blnValue: true);
			UpdateSelection();
		}

		/// Refreshes the property tabs of the specified scope.</summary>
		/// <param name="objPropertyTabScope">Either the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </param>
		/// <exception cref="T:System.ArgumentException">The objPropertyTabScope parameter is not the Component or Document value of <see cref="T:System.ComponentModel.PropertyTabScope"></see>. </exception>
		/// 2</filterpriority>
		public void RefreshTabs(PropertyTabScope objPropertyTabScope)
		{
			if (objPropertyTabScope < PropertyTabScope.Document)
			{
				throw new ArgumentException(SR.GetString("PropertyGridTabScope"));
			}
			RemoveTabs(objPropertyTabScope, blnSetupToolbar: false);
			if (objPropertyTabScope <= PropertyTabScope.Component && marrCurrentObjects != null && marrCurrentObjects.Length != 0)
			{
				Type[] commonTabs = GetCommonTabs(marrCurrentObjects, PropertyTabScope.Component);
				for (int i = 0; i < commonTabs.Length; i++)
				{
					for (int j = 0; j < marrCurrentObjects.Length; j++)
					{
						AddRefTab(commonTabs[i], marrCurrentObjects[j], PropertyTabScope.Component, blnSetupToolbar: false);
					}
				}
			}
			SetupToolbar();
		}

		internal void ReleaseTab(Type objTabType, object objComponent)
		{
			PropertyTab propertyTab = null;
			int num = -1;
			for (int i = 0; i < marrViewTabs.Length; i++)
			{
				if (objTabType == marrViewTabs[i].GetType())
				{
					propertyTab = marrViewTabs[i];
					num = i;
					break;
				}
			}
			if (propertyTab == null)
			{
				return;
			}
			object[] array = propertyTab.Components;
			bool flag = false;
			try
			{
				int num2 = -1;
				if (array != null)
				{
					ArrayList arrayList = new ArrayList(array);
					num2 = arrayList.IndexOf(objComponent);
				}
				if (num2 >= 0)
				{
					object[] array2 = new object[array.Length - 1];
					Array.Copy(array, 0, array2, 0, num2);
					Array.Copy(array, num2 + 1, array2, num2, array.Length - num2 - 1);
					array = (propertyTab.Components = array2);
				}
				flag = array.Length == 0;
			}
			catch (Exception)
			{
				flag = true;
			}
			if (flag && marrViewTabScopes[num] > PropertyTabScope.Global)
			{
				RemoveTab(num, blnSetupToolbar: false);
			}
		}

		internal void ReplaceSelectedObject(object objOldObject, object objNewObject)
		{
			for (int i = 0; i < marrCurrentObjects.Length; i++)
			{
				if (marrCurrentObjects[i] == objOldObject)
				{
					marrCurrentObjects[i] = objNewObject;
					Refresh(blnClearCached: true);
					break;
				}
			}
		}

		private void SetState(ushort flag, bool blnValue)
		{
			if (blnValue)
			{
				mState |= flag;
			}
			else
			{
				mState = (ushort)(mState & ~flag);
			}
		}

		internal void SetStatusBox(string strTitle, string strDescription)
		{
			mobjLabelDocTitle.Text = ((strTitle == null) ? "" : strTitle);
			mobjLabelDocDescription.Text = ((strDescription == null) ? "" : strDescription);
		}

		/// 
		/// Create the toolbar.
		/// </summary>
		private void SetupToolbar()
		{
			SetupToolbar(blnFullRebuild: false);
		}

		/// 
		/// Show or hide the toolbar.
		/// </summary>
		private void SetupToolbar(bool blnFullRebuild)
		{
			if (!(mblnViewTabsDirty || blnFullRebuild))
			{
				return;
			}
			try
			{
				EventHandler objEventHandler = OnViewTabButtonClick;
				EventHandler objEventHandler2 = OnViewSortButtonClick;
				EventHandler objEventHandler3 = OnResetButtonClick;
				EventHandler objEventHandler4 = OnViewButtonCategories;
				ArrayList arrayList = ((!blnFullRebuild) ? new ArrayList(mobjToolStrip.Items) : new ArrayList());
				if (marrViewSortButtons == null || blnFullRebuild)
				{
					marrViewSortButtons = new ToolStripButton[2];
					marrViewSortButtons[1] = CreatePushButton(SR.GetString("PBRSToolTipAlphabetic"), "SortAtoZ.gif", objEventHandler2);
					marrViewSortButtons[0] = CreatePushButton(SR.GetString("PBRSToolTipCategorized"), "ShowCategories.gif", objEventHandler4);
					marrViewSortButtons[0].Checked = menmPropertySortValue == PropertySort.CategorizedAlphabetical;
					marrViewSortButtons[1].Checked = menmPropertySortValue == PropertySort.Alphabetical;
					for (int i = 0; i < marrViewSortButtons.Length; i++)
					{
						arrayList.Add(marrViewSortButtons[i]);
					}
				}
				else
				{
					for (int i = arrayList.Count - 1; i >= 2; i--)
					{
						arrayList.RemoveAt(i);
					}
				}
				arrayList.Add(mobjTBSeperator1);
				mobjResetButton = CreatePushButton(string.Empty, "Reset.png", objEventHandler3);
				mobjResetButton.Enabled = false;
				arrayList.Add(mobjResetButton);
				marrViewTabButtons = new ToolStripButton[marrViewTabs.Length];
				bool flag = marrViewTabs.Length > 1;
				for (int i = 0; i < marrViewTabs.Length; i++)
				{
					try
					{
						marrViewTabButtons[i] = CreatePushButton(marrViewTabs[i].TabName, "Action.ShowPropertyPages.gif", objEventHandler);
						if (flag)
						{
							arrayList.Add(marrViewTabButtons[i]);
						}
					}
					catch (Exception)
					{
					}
				}
				if (flag)
				{
					arrayList.Add(mobjTBSeperator2);
				}
				mobjToolStrip.Items.Clear();
				for (int j = 0; j < arrayList.Count; j++)
				{
					mobjToolStrip.Items.Add(arrayList[j] as ToolStripItem);
				}
				mblnViewTabsDirty = false;
			}
			finally
			{
			}
		}

		/// 
		/// Called when [view reset button click].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnResetButtonClick(object sender, EventArgs e)
		{
			ResetSelectedProperty();
		}

		/// 
		/// Show or hide the events button.
		/// </summary>
		protected void ShowEventsButton(bool blnValue)
		{
			if (marrViewTabs != null && marrViewTabs.Length > 1 && marrViewTabs[1] is EventsTab)
			{
				marrViewTabButtons[1].Visible = blnValue;
				if (!blnValue && mintSelectedViewTab == 1)
				{
					SelectViewTabButton(marrViewTabButtons[0], blnUpdateSelection: true);
				}
			}
			UpdatePropertiesViewTabVisibility();
		}

		private void UpdatePropertiesViewTabVisibility()
		{
			if (marrViewTabButtons == null)
			{
				return;
			}
			int num = 0;
			for (int i = 1; i < marrViewTabButtons.Length; i++)
			{
				if (marrViewTabButtons[i].Visible)
				{
					num++;
				}
			}
			if (num > 0)
			{
				marrViewTabButtons[0].Visible = true;
				mobjTBSeperator2.Visible = true;
			}
			else
			{
				marrViewTabButtons[0].Visible = false;
				mobjTBSeperator2.Visible = false;
			}
		}

		/// 
		/// Updates the current selection to apply selected objects
		/// </summary>
		internal void UpdateSelection()
		{
			if (!GetState(1) || marrViewTabs == null)
			{
				return;
			}
			string key = marrViewTabs[mintSelectedViewTab].TabName + menmPropertySortValue;
			if (mobjViewTabProps != null && mobjViewTabProps.ContainsKey(key))
			{
				mobjMainGridEntry = (GridEntry)mobjViewTabProps[key];
				if (mobjMainGridEntry != null)
				{
					mobjMainGridEntry.Refresh();
				}
			}
			else
			{
				if (marrCurrentObjects != null && marrCurrentObjects.Length != 0)
				{
					mobjMainGridEntry = (GridEntry)GridEntry.Create(mobjPropertyGridView, marrCurrentObjects, new PropertyGridServiceProvider(this), mobjDesignerHost, SelectedTab, menmPropertySortValue);
				}
				else
				{
					mobjMainGridEntry = null;
				}
				if (mobjMainGridEntry == null)
				{
					mobjCurrentPropEntries = new GridEntryCollection(null, new GridEntry[0]);
					mobjPropertyGridView.ClearProps();
					return;
				}
				if (BrowsableAttributes != null)
				{
					mobjMainGridEntry.BrowsableAttributes = BrowsableAttributes;
				}
				if (mobjViewTabProps == null)
				{
					mobjViewTabProps = new Hashtable();
				}
				mobjViewTabProps[key] = mobjMainGridEntry;
			}
			mobjCurrentPropEntries = mobjMainGridEntry.Children;
			mobjDefaultGridEntry = mobjMainGridEntry.DefaultChild;
			mobjPropertyGridView.Invalidate();
		}

		/// 
		/// Resets the color of the help back.
		/// </summary>
		private void ResetHelpBackColor()
		{
			HelpBackColor = PropertyGridSkin.HelpPanelStyle.BackColor;
		}

		/// 
		/// Determine whether We Should the HelpBackColor
		/// </summary>
		/// </returns>
		private bool ShouldSerializeHelpBackColor()
		{
			return mobjDocComment.BackColor != PropertyGridSkin.HelpPanelStyle.BackColor;
		}

		private void OnViewTabButtonClick(object objSender, EventArgs eventArgs)
		{
		}

		private void OnViewSortButtonClick(object objSender, EventArgs eventArgs)
		{
			ApplyPropertySort(PropertySort.Alphabetical);
		}

		/// 
		/// Called when [view button categories].
		/// </summary>
		/// <param name="objSender">The obj sender.</param>
		/// <param name="eventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnViewButtonCategories(object objSender, EventArgs eventArgs)
		{
			ApplyPropertySort(PropertySort.CategorizedAlphabetical);
		}

		/// 
		/// Applies the property sort.
		/// </summary>
		/// <param name="enmPropertySort">The enm property sort.</param>
		private void ApplyPropertySort(PropertySort enmPropertySort)
		{
			if (menmPropertySortValue != enmPropertySort)
			{
				marrViewSortButtons[0].Checked = enmPropertySort == PropertySort.CategorizedAlphabetical;
				marrViewSortButtons[1].Checked = enmPropertySort == PropertySort.Alphabetical;
				menmPropertySortValue = enmPropertySort;
				Refresh(blnClearCached: false);
			}
		}

		internal bool HavePropEntriesChanged()
		{
			return GetState(1);
		}

		internal void SetActiveGridEntry(GridEntry objGridEntry)
		{
			SetStatusBox(objGridEntry.PropertyLabel, objGridEntry.PropertyDescription);
		}

		/// 
		/// Indicates if to render padding attribute
		/// </summary>
		/// </returns>
		protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
		{
			return PaddingValue.Empty != objPadding;
		}

		/// 
		/// Fires the click.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		internal void FireClick(EventArgs objEventArgs)
		{
			base.OnClick(objEventArgs);
		}

		/// 
		/// Gets the entries critical events.
		/// </summary>
		/// </returns>
		internal CriticalEventsData GetEntriesCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = new CriticalEventsData();
			CriticalEventsData criticalEventsData2 = GetCriticalEventsData();
			if (criticalEventsData2.HasEvent("CL"))
			{
				criticalEventsData.Set("CL");
			}
			if (criticalEventsData2.HasEvent("KD"))
			{
				criticalEventsData2.Set("KD");
			}
			return criticalEventsData;
		}

		private void SaveTabSelection()
		{
		}

		private void EnablePropPageButton(object obj)
		{
		}

		private void DisplayHotCommands()
		{
		}

		private bool SelectViewTabButtonDefault(ToolStripButton objToolBarButton)
		{
			if (mintSelectedViewTab >= 0 && mintSelectedViewTab >= marrViewTabButtons.Length)
			{
				mintSelectedViewTab = -1;
			}
			if (mintSelectedViewTab >= 0 && mintSelectedViewTab < marrViewTabButtons.Length && objToolBarButton == marrViewTabButtons[mintSelectedViewTab])
			{
				marrViewTabButtons[mintSelectedViewTab].Checked = true;
				return true;
			}
			PropertyTab objOldTab = null;
			if (mintSelectedViewTab != -1)
			{
				marrViewTabButtons[mintSelectedViewTab].Checked = false;
				objOldTab = marrViewTabs[mintSelectedViewTab];
			}
			for (int i = 0; i < marrViewTabButtons.Length; i++)
			{
				if (marrViewTabButtons[i] == objToolBarButton)
				{
					mintSelectedViewTab = i;
					marrViewTabButtons[i].Checked = true;
					try
					{
						SetState(8, blnValue: true);
						OnPropertyTabChanged(new PropertyTabChangedEventArgs(objOldTab, marrViewTabs[i]));
					}
					finally
					{
						SetState(8, blnValue: false);
					}
					return true;
				}
			}
			mintSelectedViewTab = 0;
			SelectViewTabButton(marrViewTabButtons[0], blnUpdateSelection: false);
			return false;
		}

		static PropertyGrid()
		{
			PropertySortChangedEvent = SerializableEvent.Register("PropertySortChanged", typeof(EventHandler), typeof(PropertyGrid));
			PropertyTabChangedEvent = SerializableEvent.Register("PropertyTabChanged", typeof(PropertyTabChangedEventHandler), typeof(PropertyGrid));
			PropertyValueChangedEvent = SerializableEvent.Register("PropertyValueChanged", typeof(PropertyValueChangedEventHandler), typeof(PropertyGrid));
			PropertyValueChangingEvent = SerializableEvent.Register("PropertyValueChanging", typeof(PropertyValueChangingEventHandler), typeof(PropertyGrid));
			SelectedGridItemChangedEvent = SerializableEvent.Register("SelectedGridItemChanged", typeof(SelectedGridItemChangedEventHandler), typeof(PropertyGrid));
			SelectedObjectsChangedEvent = SerializableEvent.Register("SelectedObjectsChanged", typeof(EventHandler), typeof(PropertyGrid));
			ShowingTypeEditorEvent = SerializableEvent.Register("BeforeTypeEditorOpen", typeof(EventHandler), typeof(PropertyGrid));
		}
	}
}
