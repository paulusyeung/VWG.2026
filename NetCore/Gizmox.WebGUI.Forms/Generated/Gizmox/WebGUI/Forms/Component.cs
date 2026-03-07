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
	/// The base class for all GUI elements
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[Designer("Gizmox.WebGUI.Forms.Design.MappedComponentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IDesigner))]
	[ProxyComponent(typeof(ProxyComponent))]
	public class Component : RegisteredComponent, IObservableItem, IAttributeExtender
	{
		/// 
		/// Provides support for adding extended attributes
		/// </summary>
		[Serializable]
		private sealed class AttributesWrapper : SerializableObject, IEnumerable
		{
			/// 
			/// The internal attribute collection
			/// </summary>
			[NonSerialized]
			private Dictionary<string, string> mobjAttributes = null;

			/// 
			/// Indicates last render identifiers
			/// </summary>
			[NonSerialized]
			private long mlngLastModified;

			/// 
			/// The size of the initiale serialization data array which is the optmized serialization graph.
			/// </summary>
			/// </value>
			/// 
			/// This value should be the actual size needed so that re-allocations and truncating will not be required.
			/// </remarks>
			protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 2;

			/// 
			/// Gets or sets the <see cref="T:System.String" /> with the specified name.
			/// </summary>
			/// </value>
			public string this[string strName]
			{
				get
				{
					if (mobjAttributes.ContainsKey(strName))
					{
						return mobjAttributes[strName];
					}
					return null;
				}
				set
				{
					mlngLastModified = GetCurrentTicks();
					if (value != null)
					{
						mobjAttributes[strName] = value;
					}
					else if (mobjAttributes.ContainsKey(strName))
					{
						mobjAttributes.Remove(strName);
					}
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Component.AttributesWrapper" /> class.
			/// </summary>
			public AttributesWrapper()
			{
				mobjAttributes = new Dictionary<string, string>();
			}

			/// 
			/// Called when serializable object is deserialized and we need to extract the optimized
			/// object graph to the working graph.
			/// </summary>
			/// <param name="objReader">The optimized object graph reader.</param>
			protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
			{
				base.OnSerializableObjectDeserializing(objReader);
				mlngLastModified = objReader.ReadInt64();
				mobjAttributes = objReader.ReadDictionary<string, string>();
			}

			/// 
			/// Called before serializable object is serialized to optimize the application object graph.
			/// </summary>
			/// <param name="objWriter">The optimized object graph writer.</param>
			protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
			{
				base.OnSerializableObjectSerializing(objWriter);
				objWriter.WriteInt64(mlngLastModified);
				objWriter.WriteDictionary(mobjAttributes);
			}

			public void RenderAttributes(IAttributeWriter attributeWriter, long lngRequestID)
			{
				if (mlngLastModified <= lngRequestID)
				{
					return;
				}
				foreach (string item in (IEnumerable)this)
				{
					attributeWriter.WriteAttributeString(item, this[item]);
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return mobjAttributes.Keys.GetEnumerator();
			}
		}

		/// 
		/// Represent a swipe event handler.
		/// </summary>
		public delegate void SwipeEventHandler(Component objSource, SwipeDirection enmSwipeDirection);

		[Flags]
		internal enum ComponentState
		{
			/// 
			/// The visible state flag
			/// </summary>
			Visible = 1,
			/// 
			/// The enabled state flag
			/// </summary>
			Enabled = 2,
			/// 
			/// The selected flag
			/// </summary>
			Selected = 8,
			/// 
			/// The checked flag
			/// </summary>
			Checked = 0x10,
			/// 
			/// The initializing flag
			/// </summary>
			Initializing = 0x20,
			/// 
			/// the allow drop flag
			/// </summary>
			AllowDrop = 0x80,
			/// 
			/// The loaded flag
			/// </summary>
			Loaded = 0x100,
			/// 
			/// The read only flag
			/// </summary>
			ReadOnly = 0x200,
			/// 
			/// The animation enabled flag
			/// </summary>
			AnimationEnabled = 0x800,
			/// 
			/// The click once flag
			/// </summary>
			ClickOnce = 0x1000,
			/// 
			/// The auto allipsis flag
			/// </summary>
			AutoEllipsis = 0x2000,
			/// 
			/// The allow drag flag
			/// </summary>
			AllowDrag = 0x4000,
			/// 
			/// The propogation of drop target indicator
			/// </summary>
			DropIndicatorPropogation = 0x8000
		}

		/// 
		/// The DragDrop event registration.
		/// </summary>
		private static readonly SerializableEvent DragDropEvent;

		/// 
		/// The DragDrop event registration.
		/// </summary>
		private static readonly SerializableEvent SwipeEvent;

		/// 
		/// The ContextMenuStripChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ContextMenuStripChangedEvent;

		/// 
		/// The MenuClick event registration.
		/// </summary>
		private static readonly SerializableEvent MenuClickEvent;

		private static SkinResourceHandle mobjEmptyGif;

		/// 
		/// The proxy component representing the object during emulations. Will be populated during render time.
		/// </summary>
		private ProxyComponent mobjProxyComponent;

		/// 
		/// The win forms compatibility
		/// </summary>
		private WinFormsCompatibility mobjWinFormsCompatibility;

		/// 
		/// The component state
		/// </summary>
		[NonSerialized]
		private int mintComponentState = 0;

		/// 
		/// Register the LoadingMessage property
		/// </summary>
		private static SerializableProperty LoadingMessageProperty;

		/// 
		/// Register the ClientAction property
		/// </summary>
		private static SerializableProperty ClientActionProperty;

		/// 
		/// Register the Attributes property
		/// </summary>
		private static SerializableProperty AttributesProperty;

		/// 
		/// Register the Tag property
		/// </summary>
		private static SerializableProperty TagProperty;

		/// 
		/// Register the SystemTag property
		/// </summary>
		private static SerializableProperty SystemTagProperty;

		/// 
		/// Register the CustomTemplate property
		/// </summary>
		private static SerializableProperty CustomTemplateProperty;

		/// 
		/// The parent of this component
		/// </summary>
		[NonSerialized]
		private Component mobjInternalParent = null;

		/// 
		/// Register the AllowDragTargetsPropagation property
		/// </summary>
		private static SerializableProperty AllowDragTargetsPropagationProperty;

		/// 
		/// Register the DragTargets property
		/// </summary>
		private static SerializableProperty ExcludedDragTargetsProperty;

		private static SerializableProperty DragTargetsProperty;

		private static SerializableProperty ReferencedDragTargetsComponentProperty;

		/// 
		/// The component context menu
		/// </summary>
		[NonSerialized]
		private ContextMenu mobjContextMenu = null;

		/// 
		/// The component context menu strip.
		/// </summary>
		[NonSerialized]
		private ContextMenuStrip mobjContextMenuStrip = null;

		/// 
		/// Gets the hanlder for the DragDrop event.
		/// </summary>
		private DragEventHandler DragDropHandler => (DragEventHandler)GetHandler(DragDrop);

		/// 
		/// Gets the hanlder for the DragDrop event.
		/// </summary>
		private SwipeEventHandler SwipHandler => (SwipeEventHandler)GetHandler(Swipe);

		/// 
		/// Gets the hanlder for the MenuClick event.
		/// </summary>
		private MenuEventHandler MenuClickHandler => (MenuEventHandler)GetHandler(MenuClick);

		/// 
		/// Gets the hanlder for the ContextMenuStripChanged event.
		/// </summary>
		private EventHandler ContextMenuStripChangedHandler => (EventHandler)GetHandler(ContextMenuStripChanged);

		/// 
		/// Renders the client events and behavior fields.
		/// </summary>
		/// 
		/// true</c> if [should render client events]; otherwise, false</c>.
		/// </value>
		/// </returns>
		protected override bool ShouldRenderClientEvents => GetProxyPropertyValue("ShouldRenderClientEvents", objDefaultValue: true);

		/// 
		/// Gets or sets the client action.
		/// </summary>
		/// The client action.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public RegisteredClientAction ClientAction
		{
			get
			{
				return GetValue(ClientActionProperty);
			}
			set
			{
				if (SetValue(ClientActionProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled
		{
			get
			{
				if (InternalParent != null)
				{
					bool flag = InternalParent.IsEventsEnabled;
					if (!base.DesignMode && InternalParent is Form objFormToAccess && Context.Config.FormsSecurityEnabled)
					{
						IContextParams contextParams = Context as IContextParams;
						flag &= contextParams.GetFormAccessMode(objFormToAccess) == FormAccessMode.FullControl;
					}
					return flag;
				}
				return base.IsEventsEnabled;
			}
		}

		/// 
		/// Gets the empty GIF handle.
		/// </summary>
		/// 
		/// The empty GIF.
		/// </value>
		protected static SkinResourceHandle EmptyGif
		{
			get
			{
				if (mobjEmptyGif == null)
				{
					mobjEmptyGif = new SkinResourceHandle(typeof(CommonSkin), "Empty.gif");
				}
				return mobjEmptyGif;
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is animation.
		/// </summary>
		/// true</c> if animation; otherwise, false</c>.</value>
		/// This is a temporary implementation of animation support.</remarks>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool Animation
		{
			get
			{
				return GetState(ComponentState.AnimationEnabled);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.AnimationEnabled, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets a value indicating whether animation is enabled by default.
		/// </summary>
		/// true</c> if animation is enabled by default; otherwise, false</c>.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool DefaultAnimation => false;

		/// 
		/// Gets a value indicating whether this instance is connected.
		/// </summary>
		/// 
		/// 	true</c> if this instance is connected; otherwise, false</c>.
		/// </value>
		protected override bool IsConnected => InternalParent != null;

		/// 
		/// Gets/Sets User definied tag
		/// </summary>
		[Localizable(false)]
		[Bindable(true)]
		[TypeConverter(typeof(StringConverter))]
		[SRCategory("CatData")]
		[SRDescription("ControlTagDescr")]
		[DefaultValue(null)]
		public object Tag
		{
			get
			{
				return GetValue(TagProperty);
			}
			set
			{
				SetValue(TagProperty, value);
			}
		}

		/// 
		/// Gets/Sets System definied tag
		/// </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object SystemTag
		{
			get
			{
				return GetValue(SystemTagProperty);
			}
			set
			{
				SetValue(SystemTagProperty, value);
			}
		}

		/// 
		/// Gets or sets the custom template.
		/// </summary>
		/// The custom template.</value>
		[DefaultValue("")]
		public string CustomTemplate
		{
			get
			{
				return GetValue(CustomTemplateProperty);
			}
			set
			{
				SetValue(CustomTemplateProperty, value);
			}
		}

		/// 
		/// Gets or sets the proxy component.
		/// </summary>
		/// 
		/// The proxy component.
		/// </value>
		protected internal virtual ProxyComponent ProxyComponent
		{
			get
			{
				return mobjProxyComponent;
			}
			set
			{
				mobjProxyComponent = value;
			}
		}

		/// 
		/// Gets the parent of this component.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Component InternalParent
		{
			get
			{
				return mobjInternalParent;
			}
			set
			{
				mobjInternalParent = value;
			}
		}

		/// 
		/// Gets a flag indicating if the object is initializing
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool IsSerializableObjectInitializing
		{
			get
			{
				return mobjInternalParent == null;
			}
		}

		/// 
		/// Gets the initial size of the serializable filed storage.
		/// </summary>
		/// The initial size of the serializable filed storage.</value>
		protected override int SerializableFieldStorageInitialSize
		{
			get
			{
				return 8;
			}
		}

		/// 
		/// Gets or sets whether this control accepts dropping dragged content to it
		/// </summary>
		/// A flag indicating if this control accepts dropping dragged content to it.</value>
		[Description("A flag indicating whether this component is drop-able.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public virtual bool AllowDrop
		{
			get
			{
				return GetState(ComponentState.AllowDrop);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.AllowDrop, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [allow drop].
		/// </summary>
		/// 
		///   true</c> if [allow drop]; otherwise, false</c>.
		/// </value>
		[Description("A flag indicating whether this component is drag-able.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public virtual bool AllowDrag
		{
			get
			{
				return GetState(ComponentState.AllowDrag);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.AllowDrag, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [propogate drop indicator].
		/// </summary>
		/// 
		/// true</c> if [propogate drop indicator]; otherwise, false</c>.
		/// </value>
		[Description("A flag indicating which control will be illuminated when dragging over inner controls.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public virtual bool DropIndicatorPropogation
		{
			get
			{
				return GetState(ComponentState.DropIndicatorPropogation);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.DropIndicatorPropogation, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected virtual string ClientEventsPropogationTags => string.Empty;

		/// 
		/// Gets or sets a value indicating whether [exclude self from drag targets].
		/// </summary>
		/// 
		/// 	true</c> if [exclude self from drag targets]; otherwise, false</c>.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.ExcludedDragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[Description("An array which contains all components which should be excluded from this component drag targets.")]
		[SRCategory("CatBehavior")]
		public virtual Component[] ExcludedDragTargets
		{
			get
			{
				return GetValue<Component[]>(ExcludedDragTargetsProperty);
			}
			set
			{
				bool flag = false;
				Component[] excludedDragTargets = ExcludedDragTargets;
				if (excludedDragTargets != value)
				{
					if (value == null || excludedDragTargets == null || value.Length == 0 || excludedDragTargets.Length == 0 || value.Length != excludedDragTargets.Length)
					{
						flag = true;
					}
					else
					{
						for (int i = 0; i < value.Length; i++)
						{
							if (value[i] != excludedDragTargets[i])
							{
								flag = true;
								break;
							}
						}
					}
				}
				if (flag)
				{
					if (value == null || value.Length == 0)
					{
						RemoveValue<Component[]>(ExcludedDragTargetsProperty);
					}
					else
					{
						SetValue(ExcludedDragTargetsProperty, value);
					}
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets the owner form.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual Form Form
		{
			get
			{
				if (this is Form)
				{
					return (Form)this;
				}
				if (ProxyComponent != null && !ProxyComponent.IsStateComponent)
				{
					return ProxyComponent.ParentForm;
				}
				if (InternalParent != null)
				{
					return InternalParent.Form;
				}
				return null;
			}
		}

		/// 
		/// Gets the empty drag targets.
		/// </summary>
		/// The empty drag targets.</value>
		private static Component[] EmptyDragTargets => new Component[0];

		/// 
		/// Gets or sets a value indicating whether [allow targets propagate to child controls].
		/// </summary>
		/// 
		/// 	true</c> if [allow targets propagate to child controls]; otherwise, false</c>.
		/// </value>
		[Description("A flag indicating whether this component allows its drag target to propogate to its contained components.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool AllowDragTargetsPropagation
		{
			get
			{
				return GetValue(AllowDragTargetsPropagationProperty);
			}
			set
			{
				if (SetValue(AllowDragTargetsPropagationProperty, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets or sets the referenced drag targets component.
		/// </summary>
		/// 
		/// The referenced drag targets component.
		/// </value>
		[Description("A refference to a component which contains the drag targets which will serve this component.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(null)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public Component ReferencedDragTargetsComponent
		{
			get
			{
				return GetValue(ReferencedDragTargetsComponentProperty);
			}
			set
			{
				if (SetValue(ReferencedDragTargetsComponentProperty, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Defines the valid drag and drop targets when drag starts from this control.
		/// </summary>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.DragTargetsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[Description("An array which represents the component's drag targets.")]
		[SRCategory("CatBehavior")]
		[TypeConverter(typeof(DragTargetsTypeConverter))]
		public virtual Component[] DragTargets
		{
			get
			{
				return GetValue<Component[]>(DragTargetsProperty);
			}
			set
			{
				bool flag = false;
				Component[] dragTargets = DragTargets;
				if (dragTargets != value)
				{
					if (value == null || dragTargets == null || value.Length == 0 || dragTargets.Length == 0 || value.Length != dragTargets.Length)
					{
						flag = true;
					}
					else
					{
						for (int i = 0; i < value.Length; i++)
						{
							if (value[i] != dragTargets[i])
							{
								flag = true;
								break;
							}
						}
					}
				}
				if (flag)
				{
					if (value == null || value.Length == 0)
					{
						RemoveValue<Component[]>(DragTargetsProperty);
					}
					else
					{
						SetValue(DragTargetsProperty, value);
					}
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		internal ISession InternalSession => base.Session;

		/// 
		/// Gets or sets the context menu code.  
		/// </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		public virtual ContextMenu ContextMenu
		{
			get
			{
				return mobjContextMenu;
			}
			set
			{
				ContextMenu contextMenu = mobjContextMenu;
				if (contextMenu != value)
				{
					EventHandler value2 = DetachContextMenu;
					if (contextMenu != null)
					{
						contextMenu.Disposed -= value2;
					}
					mobjContextMenu = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					if (value != null && value.InternalParent == null)
					{
						value.InternalParent = this;
					}
					Update();
				}
			}
		}

		/// 
		/// Gets the inherited context menu.
		/// </summary>
		internal ContextMenu ContextMenuInherited
		{
			get
			{
				ContextMenu contextMenu = ContextMenu;
				if (contextMenu != null)
				{
					return contextMenu;
				}
				return InternalParent?.ContextMenuInherited;
			}
		}

		/// 
		/// Gets or sets the context menu strip.
		/// </summary>
		/// 
		/// The context menu strip.
		/// </value>
		[SRDescription("ControlContextMenuDescr")]
		[DefaultValue(null)]
		[SRCategory("CatBehavior")]
		[Browsable(true)]
		public virtual ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return mobjContextMenuStrip;
			}
			set
			{
				ContextMenuStrip contextMenuStrip = mobjContextMenuStrip;
				if (contextMenuStrip != value)
				{
					EventHandler value2 = DetachContextMenuStrip;
					if (contextMenuStrip != null)
					{
						contextMenuStrip.Disposed -= value2;
					}
					mobjContextMenuStrip = value;
					if (value != null)
					{
						value.Disposed += value2;
					}
					OnContextMenuStripChanged(EventArgs.Empty);
					Update();
				}
			}
		}

		/// 
		/// Gets the inherited context menu strip.
		/// </summary>
		internal ContextMenuStrip ContextMenuStripInherited
		{
			get
			{
				ContextMenuStrip contextMenuStrip = ContextMenuStrip;
				if (contextMenuStrip != null)
				{
					return contextMenuStrip;
				}
				return InternalParent?.ContextMenuStripInherited;
			}
		}

		/// 
		/// Gets the current application context.
		/// </summary>
		/// </value>
		public override IContext Context
		{
			get
			{
				Component internalParent = InternalParent;
				if (internalParent != null)
				{
					return internalParent.Context;
				}
				return VWGContext.Current;
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		protected WinFormsCompatibility WinFormsCompatibility
		{
			get
			{
				if (mobjWinFormsCompatibility == null)
				{
					mobjWinFormsCompatibility = GetWinFormsCompatibility();
					mobjWinFormsCompatibility.OptionValueChanged += WinFormsCompatibilityOptionValueChanged;
				}
				return mobjWinFormsCompatibility;
			}
		}

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 4;

		/// Occurs when a drag-and-drop operation is completed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatDragDrop")]
		[SRDescription("ControlOnDragDropDescr")]
		public virtual event DragEventHandler DragDrop
		{
			add
			{
				AddHandler(DragDropEvent, value);
			}
			remove
			{
				RemoveHandler(DragDropEvent, value);
			}
		}

		/// 
		/// Occurs when [swipe].
		/// </summary>
		public virtual event SwipeEventHandler Swipe
		{
			add
			{
				AddCriticalHandler(SwipeEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SwipeEvent, value);
			}
		}

		/// 
		/// Invokes when a menu item was clicked
		/// </summary>
		public virtual event MenuEventHandler MenuClick
		{
			add
			{
				AddHandler(MenuClickEvent, value);
			}
			remove
			{
				RemoveHandler(MenuClickEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:System.Windows.Forms.Control.ContextMenuStrip"></see> property changes.
		/// </summary>
		[SRDescription("ControlContextMenuStripChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler ContextMenuStripChanged
		{
			add
			{
				AddHandler(ContextMenuStripChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ContextMenuStripChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client after start drag].
		/// </summary>
		[SRDescription("Occurs when control dragged in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientStartDrag
		{
			add
			{
				AddClientHandler("StartDrag", value);
			}
			remove
			{
				RemoveClientHandler("StartDrag", value);
			}
		}

		/// 
		/// Occurs when [client drag drop].
		/// </summary>
		[SRDescription("Occurs when dragged component dropped in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientDragDrop
		{
			add
			{
				AddClientHandler("DragDrop", value);
			}
			remove
			{
				RemoveClientHandler("DragDrop", value);
			}
		}

		/// 
		/// Property change indicator for the observable item interface
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.Component" /> instance.
		/// </summary>
		public Component()
		{
			SetState(ComponentState.AllowDrag, blnValue: true);
			SetState(ComponentState.AnimationEnabled, DefaultAnimation);
			SetState(ComponentState.DropIndicatorPropogation, blnValue: true);
		}

		/// 
		/// Sets the state.
		/// </summary>
		/// <param name="intFlag">The flag to set.</param>
		/// <param name="blnValue">The flag value to set.</param>
		internal void SetState(ComponentState enmState, bool blnValue)
		{
			mintComponentState = (blnValue ? (mintComponentState | (int)enmState) : (mintComponentState & (int)(~enmState)));
		}

		/// 
		/// Sets the state and returns a flag if value had changed.
		/// </summary>
		/// <param name="intFlag">The flag to set.</param>
		/// <param name="blnValue">The flag value to set.</param>
		internal bool SetStateWithCheck(ComponentState enmState, bool blnValue)
		{
			if (GetState(enmState) != blnValue)
			{
				SetState(enmState, blnValue);
				return true;
			}
			return false;
		}

		/// 
		/// Gets the state.
		/// </summary>
		/// <param name="intFlag">The flag to get.</param>
		/// </returns>
		internal bool GetState(ComponentState enmState)
		{
			return ((uint)mintComponentState & (uint)enmState) != 0;
		}

		/// 
		/// Renders the component update attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected void RenderComponentUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			objWriter.WriteAttributeString("Id", GetProxyPropertyValue("ID", ID).ToString());
			if (IsDirtyAttributes(lngRequestID, AttributeType.Drag))
			{
				RenderDragAndDropAttributes(objContext, objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Events))
			{
				RenderComponentEventAttributes(objContext, objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.VisualEffect))
			{
				RenderComponentVisualEffectsAttributes(objContext, objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderClientID(objWriter, blnForceRender: true);
			}
			RenderClientUpdateHandler(objContext, objWriter, blnForceRender: true);
			RenderUseClientUpdateHandlerAttribute(objContext, objWriter);
			RenderSwipableAttribute(objWriter);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected void RenderComponentAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			RenderComponentID(objWriter);
			RenderClientID(objWriter, blnForceRender: false);
			RenderIsDirtyAttributes(objContext, objWriter);
			RenderComponentEventAttributes(objContext, objWriter, blnForceRender: false);
			RenderClientUpdateHandler(objContext, objWriter, blnForceRender: false);
			RenderUseClientUpdateHandlerAttribute(objContext, objWriter);
			RenderAnimationAttributes(objWriter);
			RenderComponentVisualEffectsAttributes(objContext, objWriter);
			RenderClientEventsPropogationTags(objWriter);
			string customTemplate = CustomTemplate;
			if (!string.IsNullOrEmpty(customTemplate))
			{
				objWriter.WriteAttributeString("CT", customTemplate);
			}
			string value = GetValue(LoadingMessageProperty);
			if (!string.IsNullOrEmpty(value))
			{
				objWriter.WriteAttributeText("LM", value);
			}
			ContextMenu contextMenuInherited = ContextMenuInherited;
			if (contextMenuInherited != null)
			{
				objWriter.WriteAttributeString("M", contextMenuInherited.ID.ToString());
			}
			RenderSwipableAttribute(objWriter);
			RenderClientInvocation(objContext, objWriter);
			RenderExtendedComponentAttributes(objContext, objWriter);
			RenderDragAndDropAttributes(objContext, objWriter, blnForceRender: false);
			if (Context.Config.EnableAutomationIds && string.IsNullOrEmpty(((IAttributeExtender)this).GetAttribute("CUID")))
			{
				string componentUniqueID = GetComponentUniqueID(Form, this);
				if (!string.IsNullOrEmpty(componentUniqueID))
				{
					objWriter.WriteAttributeText("CUID", componentUniqueID);
				}
			}
		}

		/// 
		/// Renders the is dirty attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected internal void RenderIsDirtyAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			if (objContext is IContextParams { LastRender: var lastRender } && lastRender != 0 && (IsDirty(lastRender) || IsDirtyAttributes(lastRender)) && ShouldRenderIsDirtyAttribute(lastRender))
			{
				objWriter.WriteAttributeString("IY", "1");
			}
		}

		/// 
		/// Renders the component's ID.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderComponentID(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("Id", GetProxyPropertyValue("ID", ID).ToString());
		}

		/// 
		/// Renders the component's ID.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderClientID(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (blnForceRender || !string.IsNullOrEmpty(base.ClientId))
			{
				objWriter.WriteAttributeString("CID", base.ClientId);
			}
		}

		/// 
		/// Renders the swipable attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderSwipableAttribute(IAttributeWriter objWriter)
		{
			if (SwipHandler != null)
			{
				objWriter.WriteAttributeString("SW", "1");
			}
		}

		/// 
		/// Renders the client invocation mapping if needed.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected internal void RenderClientInvocation(IContext objContext, IAttributeWriter objWriter)
		{
			if (ShouldRenderClientEvents)
			{
				ClientAction?.RenderAttributes((IContextMethodInvoker)objContext, objWriter);
			}
		}

		/// 
		/// Returns the component client events list.
		/// </summary>
		protected override ClientEventList GetClientEvents()
		{
			ClientEventList proxyPropertyValue = GetProxyPropertyValue("ClientEvents", null);
			if (proxyPropertyValue != null)
			{
				return proxyPropertyValue;
			}
			return base.GetClientEvents();
		}

		/// 
		/// Renders the extended component attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected internal void RenderExtendedComponentAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			((IAttributeExtender)this).RenderAttributes(objWriter);
		}

		/// 
		/// Renders the drag and drop attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderDragAndDropAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			Component[] proxyPropertyValue = GetProxyPropertyValue("DragTargets", DragTargets);
			if ((proxyPropertyValue != null && proxyPropertyValue.Length != 0) || blnForceRender)
			{
				objWriter.WriteAttributeString("DTS", CommaSeperatedString(proxyPropertyValue));
			}
			if (AllowDrop || blnForceRender)
			{
				objWriter.WriteAttributeString("AD", AllowDrop ? "1" : "0");
			}
			if (!AllowDrag || blnForceRender)
			{
				objWriter.WriteAttributeString("ADG", AllowDrag ? "1" : "0");
			}
			if (!DropIndicatorPropogation || blnForceRender)
			{
				objWriter.WriteAttributeString("DIP", DropIndicatorPropogation ? "1" : "0");
			}
			if ((ExcludedDragTargets != null && ExcludedDragTargets.Length != 0) || blnForceRender)
			{
				objWriter.WriteAttributeString("EDT", CommaSeperatedString(ExcludedDragTargets));
			}
			bool allowDragTargetsPropagation = AllowDragTargetsPropagation;
			if (!allowDragTargetsPropagation || blnForceRender)
			{
				objWriter.WriteAttributeString("APC", allowDragTargetsPropagation ? "1" : "0");
			}
			if (ReferencedDragTargetsComponent != null || blnForceRender)
			{
				string strValue = ((ReferencedDragTargetsComponent != null) ? ReferencedDragTargetsComponent.ID.ToString() : string.Empty);
				objWriter.WriteAttributeString("DTC", strValue);
			}
		}

		/// 
		/// Commas the seperated string.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// </returns>
		private string CommaSeperatedString(IEnumerable obj)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			foreach (Component item in obj)
			{
				text = text + text2 + item.ID;
				text2 = ",";
			}
			return text;
		}

		/// 
		/// Registers the default client invocation.
		/// </summary>
		/// <param name="strMethod">The target method.</param>
		/// <param name="arrArgs">The invocation args.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void RegisterClientAction(string strMethod, params string[] arrArgs)
		{
			RegisterClientAction(null, strMethod, arrArgs);
		}

		/// 
		/// Registers the default client invocation.
		/// </summary>
		/// <param name="objTarget">The invocation target.</param>
		/// <param name="strMethod">The target method.</param>
		/// <param name="arrArgs">The invocation args.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void RegisterClientAction(Component objTarget, string strMethod, params string[] arrArgs)
		{
			if (strMethod == null)
			{
				throw new ArgumentNullException("strMethod");
			}
			ClientAction = RegisteredClientAction.Create(objTarget, strMethod, arrArgs);
			Update();
		}

		/// 
		/// Registers the default client invocation (Adds component id as the first parameter).
		/// </summary>
		/// <param name="objTarget">The invocation target.</param>
		/// <param name="strMethod">The target method.</param>
		/// <param name="arrArgs">The invocation args.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void RegisterClientActionWithId(Component objTarget, string strMethod, params string[] arrArgs)
		{
			if (strMethod == null)
			{
				throw new ArgumentNullException("strMethod");
			}
			if (objTarget == null)
			{
				throw new ArgumentNullException("objTarget");
			}
			ClientAction = RegisteredClientAction.CreateWithId(objTarget, strMethod, arrArgs);
			Update();
		}

		/// 
		/// Unregisters the default client invocation.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void UnregisterClientAction()
		{
			ClientAction = null;
			Update();
		}

		/// 
		/// Sets the loading message.
		/// </summary>
		/// </value>
		public void SetLoadingMessage(string strLoadingMessage)
		{
			SetValue(LoadingMessageProperty, strLoadingMessage);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
		/// event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		private void OnComponentClick(EventArgs objEventArgs)
		{
			MouseEventArgs e = objEventArgs as MouseEventArgs;
			if (e == null)
			{
				e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
			}
			if (e.Button == MouseButtons.Right)
			{
				if (ContextMenuInherited != null)
				{
					ContextMenuInherited.Show(this, new Point(e.X, e.Y), DialogAlignment.Custom);
				}
				else if (ContextMenuStripInherited != null)
				{
					ContextMenuStripInherited.ShowDropDown(this, e.X, e.Y);
				}
			}
		}

		/// 
		/// Raises the <see cref="E:System.Windows.Forms.Control.ContextMenuStripChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnContextMenuStripChanged(EventArgs e)
		{
			ContextMenuStripChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.Control.DragDrop"></see> event.</summary>
		/// <param name="objDragEventArgs">A <see cref="T:System.Windows.Forms.DragEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnDragDrop(DragEventArgs objDragEventArgs)
		{
			DragDropHandler?.Invoke(this, objDragEventArgs);
		}

		/// 
		/// Called when [swipe].
		/// </summary>
		/// <param name="enmSwipeDirection">The swipe direction.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnSwipe(SwipeDirection enmSwipeDirection)
		{
			SwipHandler?.Invoke(this, enmSwipeDirection);
		}

		/// 
		/// Detaches the context menu.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DetachContextMenu(object sender, EventArgs e)
		{
			ContextMenu = null;
		}

		/// 
		/// Detaches the context menu strip.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DetachContextMenuStrip(object sender, EventArgs e)
		{
			ContextMenuStrip = null;
		}

		/// 
		/// Gets the proxy property value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// <param name="objDefaultValue">The obj default value.</param>
		/// </returns>
		protected internal virtual T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
		{
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				return proxyComponent.GetProxyPropertyValue(strPropertyName, objDefaultValue);
			}
			return objDefaultValue;
		}

		/// 
		/// Determines whether [has proxy property value] [the specified STR property name].
		/// </summary>
		/// <param name="strPropertyName">Name of the STR property.</param>
		/// 
		///   true</c> if [has proxy property value] [the specified STR property name]; otherwise, false</c>.
		/// </returns>
		protected internal virtual bool HasProxyPropertyValue(string strPropertyName)
		{
			return ProxyComponent?.HasProxyPropertyValue(strPropertyName) ?? false;
		}

		/// 
		/// Gets the ancestor by type.
		/// </summary>
		/// <param name="objType">type.</param>
		/// </returns>
		protected Component GetAncestorByType(Type objType)
		{
			Component component = this;
			while (component != null && component != component.InternalParent && !objType.IsInstanceOfType(component) && component != null)
			{
				component = component.InternalParent;
			}
			return component;
		}

		/// 
		/// Disposes the specified component.
		/// </summary>
		/// <param name="blnDisposing"></param>
		protected override void Dispose(bool blnDisposing)
		{
			base.Dispose(blnDisposing);
			if (blnDisposing)
			{
				ContextMenu contextMenu = ContextMenu;
				if (contextMenu != null)
				{
					contextMenu.Disposed -= DetachContextMenu;
				}
			}
		}

		/// 
		/// Gets the event integer attribute value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="strAttribute">The attribute name.</param>
		/// <param name="intDefault">The default integer value.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
		{
			string text = objEvent[strAttribute];
			if (CommonUtils.IsNullOrEmpty(text))
			{
				return intDefault;
			}
			double dblValue = 0.0;
			CommonUtils.TryParse(text, out dblValue);
			return Convert.ToInt32(dblValue);
		}

		/// 
		/// Gets the event buttons value.
		/// </summary>
		/// <param name="objEvent">The event.</param>
		/// <param name="enmDefault">The default value.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
		{
			return objEvent["BTN"] switch
			{
				"L" => MouseButtons.Left, 
				"R" => MouseButtons.Right, 
				"M" => MouseButtons.Middle, 
				_ => enmDefault, 
			};
		}

		/// 
		/// Fires the menu click.
		/// </summary>
		/// <param name="objMenuItem">The obj menu item.</param>
		internal void FireMenuClick(MenuItem objMenuItem, IIdentifiedComponent objMember)
		{
			FireMenuClick(new MenuItemEventArgs(objMenuItem, this, objMember));
		}

		/// 
		/// Fires the menu click.
		/// </summary>
		/// <param name="objMenuItem">The obj menu item.</param>
		internal void FireMenuClick(MenuItem objMenuItem)
		{
			FireMenuClick(new MenuItemEventArgs(objMenuItem, this));
		}

		/// 
		/// Fires the menu click.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MenuItemEventArgs" /> instance containing the event data.</param>
		internal void FireMenuClick(MenuItemEventArgs objEventArgs)
		{
			if (MenuClickHandler != null)
			{
				MenuClickHandler(this, objEventArgs);
			}
			else if (InternalParent != null)
			{
				InternalParent.FireMenuClick(objEventArgs);
			}
		}

		/// 
		/// Gets the image.
		/// </summary>
		/// <param name="intHandledImageKey">The int handled image key.</param>
		/// <param name="objImageList">The obj image list.</param>
		/// <param name="intImageIndex">Index of the int image.</param>
		/// <param name="strImageKey">The STR image key.</param>
		/// <param name="intParentImageIndex">Index of the int parent image.</param>
		/// <param name="strParentImageKey">The STR parent image key.</param>
		/// </returns>
		protected internal ResourceHandle GetImage(SerializableProperty intHandledImageKey, ImageList objImageList, int intImageIndex, string strImageKey, int intParentImageIndex, string strParentImageKey)
		{
			if (objImageList != null)
			{
				if (intImageIndex > -1)
				{
					return objImageList.Images[intImageIndex];
				}
				if (!string.IsNullOrEmpty(strImageKey))
				{
					return objImageList.Images[strImageKey];
				}
				if (intParentImageIndex > -1)
				{
					return objImageList.Images[intParentImageIndex];
				}
				if (!string.IsNullOrEmpty(strParentImageKey))
				{
					return objImageList.Images[strParentImageKey];
				}
				return null;
			}
			return GetValue(intHandledImageKey);
		}

		/// 
		/// Sets the image.
		/// </summary>
		/// <param name="objHandledImage">The obj handled image.</param>
		/// <param name="objNewValue">The obj new value.</param>
		/// <param name="objImageList">The obj image list.</param>
		protected internal bool SetImage(SerializableProperty intHandledImageKey, ResourceHandle objNewValue, ImageList objImageList)
		{
			if (objImageList != null)
			{
				throw new Exception("Cannot assign image when working in ImageList mode.");
			}
			bool flag = SetValue(intHandledImageKey, objNewValue);
			if (flag)
			{
				Update();
			}
			return flag;
		}

		/// 
		/// Gets the component critical events.
		/// </summary>
		/// </returns>
		internal CriticalEventsData GetComponentCriticalEventsData()
		{
			return GetCriticalEventsData();
		}

		/// 
		/// Gets the component critical client events.
		/// </summary>
		/// </returns>
		internal CriticalEventsData GetComponentCriticalClientEventsData()
		{
			return GetCriticalClientEventsData();
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				criticalEventsData.Set(proxyComponent.GetCriticalEventsData());
			}
			if (DragDropHandler != null)
			{
				criticalEventsData.Set("DD");
			}
			if (ContextMenuInherited != null || ContextMenuStripInherited != null)
			{
				criticalEventsData.Set("RC");
			}
			if (SwipHandler != null)
			{
				criticalEventsData.Set("SWP");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				criticalClientEventsData.Set(proxyComponent.GetCriticalClientEventsData());
			}
			if (HasClientHandler("StartDrag"))
			{
				criticalClientEventsData.Set("SD");
			}
			if (HasClientHandler("DragDrop"))
			{
				criticalClientEventsData.Set("DD");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			switch (objEvent.Type)
			{
			case "Click":
				OnComponentClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				break;
			case "DragDrop":
				if (objEvent["DS"] != null && ((ISessionRegistry)Context).GetRegisteredComponent(objEvent["DS"]) is Component objSource && ((ISessionRegistry)Context).GetRegisteredComponent(objEvent["ET"]) is Component objExplicitTarget)
				{
					int intKeyState = 0;
					if (objEvent["KS"] != null)
					{
						intKeyState = Convert.ToInt32(objEvent["KS"]);
					}
					Point eventPosition = GetEventPosition(objEvent, "CPS");
					Point eventPosition2 = GetEventPosition(objEvent, "RPS");
					OnDragDrop(new DragDropEventArgs(objSource, this, objExplicitTarget, intKeyState, eventPosition.X, eventPosition.Y, eventPosition2.X, eventPosition2.Y, DragDropEffects.Move, DragDropEffects.Move));
				}
				break;
			case "Swipe":
			{
				string text = objEvent["DR"];
				if (!string.IsNullOrEmpty(text))
				{
					int result = -1;
					if (int.TryParse(text, out result) && Enum.IsDefined(typeof(SwipeDirection), result))
					{
						SwipeDirection enmSwipeDirection = (SwipeDirection)Enum.Parse(typeof(SwipeDirection), text);
						OnSwipe(enmSwipeDirection);
					}
				}
				break;
			}
			}
		}

		/// 
		/// Gets position from event.
		/// </summary>
		private Point GetEventPosition(IEvent objEvent, string strEventName)
		{
			int x = 0;
			int y = 0;
			if (objEvent[strEventName] != null)
			{
				string text = objEvent[strEventName];
				if (text != null)
				{
					string[] array = text.Split(',');
					if (array != null && array.Length == 2)
					{
						x = Convert.ToInt32(Convert.ToDouble(array[0], CultureInfo.InvariantCulture));
						y = Convert.ToInt32(Convert.ToDouble(array[1], CultureInfo.InvariantCulture));
					}
				}
			}
			return new Point(x, y);
		}

		/// 
		/// Fires the component event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void FireComponentEvent(IEvent objEvent)
		{
			FireEvent(objEvent);
		}

		/// 
		/// Fires a component event
		/// </summary>
		/// <param name="objSource"></param>
		/// <param name="objArgs"></param>
		internal void FireComponentEvent(object objSource, EventArgs objArgs)
		{
			if (objArgs is MenuItemEventArgs && MenuClickHandler != null)
			{
				MenuClickHandler(objSource, objArgs as MenuItemEventArgs);
			}
		}

		/// 
		/// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
		/// </summary>
		/// <param name="strProperty">The name of the property that has changed</param>
		protected void FireObservableItemPropertyChanged(string strProperty)
		{
			if (this.ObservableItemPropertyChanged != null)
			{
				this.ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
			}
		}

		/// 
		/// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
		/// </summary>
		/// <param name="strProperty">The name of the property that has changed</param>
		/// <param name="objSubject">The subject of the property that has changed</param>
		protected void FireObservableItemPropertyChanged(string strProperty, object objSubject)
		{
			if (this.ObservableItemPropertyChanged != null)
			{
				this.ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty, objSubject));
			}
		}

		/// 
		/// Gets an attribute from the container
		/// </summary>
		/// <param name="strName">The attribute name.</param>
		/// </returns>
		string IAttributeExtender.GetAttribute(string strName)
		{
			return GetValue(AttributesProperty)?[strName];
		}

		void IAttributeExtender.SetAttribute(string strName, string strValue)
		{
			AttributesWrapper attributesWrapper = GetValue(AttributesProperty);
			if (attributesWrapper == null)
			{
				attributesWrapper = new AttributesWrapper();
				SetValue(AttributesProperty, attributesWrapper);
			}
			if (attributesWrapper[strName] != strValue)
			{
				attributesWrapper[strName] = strValue;
				UpdateParams(AttributeType.Extended);
			}
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderAttributes(IAttributeWriter objAttributeWriter, long lngRequestID)
		{
			GetValue(AttributesProperty)?.RenderAttributes(objAttributeWriter, lngRequestID);
		}

		/// 
		/// Renders the controls meta attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
		}

		/// 
		/// Renders the client events propogated tags.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		private void RenderClientEventsPropogationTags(IAttributeWriter objAttributeWriter)
		{
			if (!string.IsNullOrEmpty(ClientEventsPropogationTags))
			{
				objAttributeWriter.WriteAttributeString("OEPT", ClientEventsPropogationTags);
			}
		}

		/// 
		/// Writes the container attributes to an IAttributeWriter
		/// </summary>
		/// <param name="objAttributeWriter"></param>
		void IAttributeExtender.RenderAttributes(IAttributeWriter objAttributeWriter)
		{
			RenderAttributes(objAttributeWriter, 0L);
		}

		/// 
		/// Renders the updated attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		void IAttributeExtender.RenderUpdatedAttributes(IAttributeWriter objWriter, long lngRequestID)
		{
			RenderAttributes(objWriter, lngRequestID);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected virtual WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new WinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void WinFormsCompatibilityOptionValueChanged(object sender, WinFormsCompatibilityEventArgs e)
		{
			OnWinFormsCompatibilityOptionValueChanged(e.ChangedOptionName);
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected virtual void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
		}

		/// 
		/// Renders the animation.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected void RenderAnimationAttributes(IAttributeWriter objWriter)
		{
			if (Animation)
			{
				objWriter.WriteAttributeString("AN", "1");
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal virtual IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return null;
		}

		/// 
		/// Gets the component unique ID.
		/// </summary>
		/// <param name="objMainForm">The obj main form.</param>
		/// <param name="objComponent">The obj component.</param>
		/// </returns>
		internal string GetComponentUniqueID(Form objMainForm, Component objComponent)
		{
			if (objComponent != null && objComponent != objMainForm)
			{
				string fullName = objComponent.GetType().FullName;
				if (!string.IsNullOrEmpty(fullName))
				{
					Component internalParent = objComponent.InternalParent;
					if (internalParent != null)
					{
						string text = GetComponentUniqueID(objMainForm, internalParent);
						if (!string.IsNullOrEmpty(text))
						{
							text = $"{text}/";
						}
						IList componentOffsprings = internalParent.GetComponentOffsprings(fullName);
						if (componentOffsprings != null)
						{
							return $"{text}{fullName}[{componentOffsprings.IndexOf(objComponent)}]";
						}
					}
				}
			}
			return null;
		}

		/// 
		/// Shoulds the render is dirty attribute.
		/// </summary>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// </returns>
		protected override bool ShouldRenderIsDirtyAttribute(long lngRequestID)
		{
			if (HasParentWithClientUpdateHandler())
			{
				return FirstDirtyParentHasClientUpdateHandler(lngRequestID);
			}
			return false;
		}

		/// 
		/// Firsts the dirty parent has client update handler.
		/// </summary>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// </returns>
		private bool FirstDirtyParentHasClientUpdateHandler(long lngRequestID)
		{
			Component internalParent = InternalParent;
			if (internalParent != null)
			{
				if (internalParent.IsDirty(lngRequestID) || internalParent.IsDirtyAttributes(lngRequestID))
				{
					return (internalParent.UseClientUpdateHandler && !string.IsNullOrEmpty(internalParent.ClientUpdateHandler)) ? true : false;
				}
				return internalParent.FirstDirtyParentHasClientUpdateHandler(lngRequestID);
			}
			return false;
		}

		/// 
		/// Determines whether [has parent with client update handler].
		/// </summary>
		/// 
		///   true</c> if [has parent with client update handler]; otherwise, false</c>.
		/// </returns>
		protected bool HasParentWithClientUpdateHandler()
		{
			Component internalParent = InternalParent;
			if (internalParent != null)
			{
				if (internalParent.UseClientUpdateHandler && !string.IsNullOrEmpty(internalParent.ClientUpdateHandler))
				{
					return true;
				}
				return internalParent.HasParentWithClientUpdateHandler();
			}
			return false;
		}

		/// 
		/// Shoulds the serialize allow drop.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeAllowDrop()
		{
			return AllowDrop;
		}

		/// 
		/// Shoulds the serialize drag targets.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeDragTargets()
		{
			return ContainsValue<Component[]>(DragTargetsProperty);
		}

		/// 
		/// Shoulds the serialize excluded drag targets.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeExcludedDragTargets()
		{
			return ContainsValue<Component[]>(ExcludedDragTargetsProperty);
		}

		/// 
		/// Shoulds the serialize custom template.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeCustomTemplate()
		{
			return ContainsValue(CustomTemplateProperty);
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			if (mobjContextMenu != null)
			{
				RegisterComponent(mobjContextMenu);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			if (mobjContextMenu != null)
			{
				UnRegisterComponent(mobjContextMenu);
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
			mobjInternalParent = (Component)objReader.ReadObject();
			mintComponentState = objReader.ReadInt32();
			mobjContextMenu = (ContextMenu)objReader.ReadObject();
			mobjContextMenuStrip = (ContextMenuStrip)objReader.ReadObject();
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteObject(mobjInternalParent);
			objWriter.WriteInt32(mintComponentState);
			objWriter.WriteObject(mobjContextMenu);
			objWriter.WriteObject(mobjContextMenuStrip);
		}

		static Component()
		{
			DragDrop = SerializableEvent.Register("DragDrop", typeof(DragEventHandler), typeof(Component));
			Swipe = SerializableEvent.Register("Swipe", typeof(SwipeEventHandler), typeof(Component));
			ContextMenuStripChanged = SerializableEvent.Register("ContextMenuStripChanged", typeof(EventHandler), typeof(Component));
			MenuClick = SerializableEvent.Register("MenuClick", typeof(MenuEventHandler), typeof(Component));
			LoadingMessageProperty = SerializableProperty.Register("LoadingMessage", typeof(string), typeof(Component), new SerializablePropertyMetadata(string.Empty));
			ClientActionProperty = SerializableProperty.Register("ClientAction", typeof(RegisteredClientAction), typeof(Component), new SerializablePropertyMetadata(null));
			AttributesProperty = SerializableProperty.Register("Attributes", typeof(AttributesWrapper), typeof(Component), new SerializablePropertyMetadata(null));
			TagProperty = SerializableProperty.Register("Tag", typeof(object), typeof(Component), new SerializablePropertyMetadata(null));
			SystemTagProperty = SerializableProperty.Register("SystemTag", typeof(object), typeof(Component), new SerializablePropertyMetadata(null));
			CustomTemplateProperty = SerializableProperty.Register("CustomTemplate", typeof(string), typeof(Component), new SerializablePropertyMetadata(string.Empty));
			AllowDragTargetsPropagationProperty = SerializableProperty.Register("AllowDragTargetsPropagation", typeof(bool), typeof(Component), new SerializablePropertyMetadata(true));
			ExcludedDragTargetsProperty = SerializableProperty.Register("ExcludedDragTargets", typeof(Component[]), typeof(Component), new SerializablePropertyMetadata(new Component[0]));
			DragTargetsProperty = SerializableProperty.Register("DragTargets", typeof(Component[]), typeof(Component), new SerializablePropertyMetadata(new Component[0]));
			ReferencedDragTargetsComponentProperty = SerializableProperty.Register("ReferencedDragTargetsComponent", typeof(Component), typeof(Component), new SerializablePropertyMetadata(null));
		}
	}
}
