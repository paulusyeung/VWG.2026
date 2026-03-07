#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
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
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Forms.Skins.Resources
{
	[Serializable]
	[ToolboxBitmap(typeof(Skin))]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Skins.SkinResourceCodeDomSerializer, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ToolboxItem(false)]
	[Localizable(false)]
	public class SkinResource : IComponent, ICustomTypeDescriptor, ICloneable, IDisposable
	{
		private class OB : PropertyDescriptor
		{
			private PropertyDescriptor A;

			public override bool IsReadOnly => true;

			public override Type ComponentType => A.ComponentType;

			public override Type PropertyType => A.PropertyType;

			public OB(PropertyDescriptor objProperty)
				: base(objProperty)
			{
				A = objProperty;
			}

			public override bool CanResetValue(object component)
			{
				return A.CanResetValue(component);
			}

			public override object GetValue(object component)
			{
				return A.GetValue(component);
			}

			public override void ResetValue(object component)
			{
				A.ResetValue(component);
			}

			public override void SetValue(object component, object value)
			{
				A.SetValue(component, value);
			}

			public override bool ShouldSerializeValue(object component)
			{
				return A.ShouldSerializeValue(component);
			}
		}

		private string mstrComment = string.Empty;

		private Presentation menmPresentation;

		private PresentationEngine menmPresentationEngine = PresentationEngine.Agnostic;

		private PresentationDrawingEngine menmPresentationDrawingEngine;

		private PresentationRole menmPresentationRole;

		private Inheritance menmInheritance;

		private bool mblnVisible = true;

		private BrowserCapabilities menmBrowserCapabilities = BrowserCapabilities.Empty;

		[CompilerGenerated]
		private EventHandler m_Disposed;

		private ISite mobjSite;

		private bool mblnIsDisposed;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public string Type => GetType().Name;

		[DefaultValue("")]
		public virtual string Comment
		{
			get
			{
				return mstrComment;
			}
			set
			{
				mstrComment = value;
			}
		}

		[Category("Behavior")]
		[Description("Gets or sets the inheritance behavior of current resource.")]
		[DefaultValue(Inheritance.NotInherited)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public virtual Inheritance Inheritance
		{
			get
			{
				return menmInheritance;
			}
			set
			{
				menmInheritance = value;
			}
		}

		protected virtual PresentationDrawingEngine DefaultPresentationDrawingEngine => PresentationDrawingEngine.Agnostic;

		[Browsable(false)]
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return mblnVisible;
			}
			set
			{
				mblnVisible = value;
			}
		}

		[Description("Gets or sets the presentation role that this resource plays in the selected presentation layer.")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Presentation")]
		[DefaultValue(PresentationRole.Custom)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual PresentationRole PresentationRole
		{
			get
			{
				return menmPresentationRole;
			}
			set
			{
				menmPresentationRole = value;
			}
		}

		[Description("Gets or sets the presentation engine that this resource should be used in.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(PresentationEngine.Agnostic)]
		[Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.PresentationEngineEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Presentation")]
		public virtual PresentationEngine PresentationEngine
		{
			get
			{
				return menmPresentationEngine;
			}
			set
			{
				menmPresentationEngine = value;
			}
		}

		[Browsable(false)]
		public virtual PresentationDrawingEngine PresentationDrawingEngine
		{
			get
			{
				return menmPresentationDrawingEngine;
			}
			set
			{
				menmPresentationDrawingEngine = value;
			}
		}

		[Description("Gets or sets the browser capabilities that are required and forbidden for this resource.")]
		[Editor("Gizmox.WebGUI.Common.Design.Skins.Editors.BrowserCapabilitiesEditor, Gizmox.WebGUI.Common.Design.Skins, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=82814e180535b402", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Category("Presentation")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public virtual BrowserCapabilities BrowserCapabilities
		{
			get
			{
				return menmBrowserCapabilities;
			}
			set
			{
				menmBrowserCapabilities = value;
			}
		}

		[Description("Gets or sets the presentation that this resource should be used in.")]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(Presentation.Agnostic)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Presentation")]
		public virtual Presentation Presentation
		{
			get
			{
				return menmPresentation;
			}
			set
			{
				menmPresentation = value;
			}
		}

		ISite IComponent.Site
		{
			get
			{
				return mobjSite;
			}
			set
			{
				mobjSite = value;
			}
		}

		public event EventHandler Disposed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.m_Disposed;
				while (true)
				{
					EventHandler eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_Disposed, value2, eventHandler2);
					if ((object)eventHandler == eventHandler2)
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.m_Disposed;
				while (true)
				{
					EventHandler eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.m_Disposed, value2, eventHandler2);
					if ((object)eventHandler == eventHandler2)
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
		}

		public SkinResource()
		{
			menmPresentationDrawingEngine = DefaultPresentationDrawingEngine;
		}

		public SkinResource(SkinResource objResource)
		{
			mstrComment = objResource.mstrComment;
			menmPresentation = objResource.menmPresentation;
			menmPresentationRole = objResource.menmPresentationRole;
			menmPresentationEngine = objResource.menmPresentationEngine;
			menmPresentationDrawingEngine = objResource.menmPresentationDrawingEngine;
			menmBrowserCapabilities = objResource.menmBrowserCapabilities;
		}

		internal bool ShouldSerializeBrowserCapabilities()
		{
			return !BrowserCapabilities.Equals(BrowserCapabilities.Empty);
		}

		internal bool ShouldSerializePresentationDrawingEngine()
		{
			return !PresentationDrawingEngine.Equals(DefaultPresentationDrawingEngine);
		}

		void IDisposable.Dispose()
		{
			if (mblnIsDisposed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mblnIsDisposed = true;
			m_Disposed?.Invoke(this, EventArgs.Empty);
		}

		System.ComponentModel.AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return GetProperties(TypeDescriptor.GetProperties(this, attributes, noCustomTypeDesc: true));
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return GetProperties(TypeDescriptor.GetProperties(this, noCustomTypeDesc: true));
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}

		protected virtual PropertyDescriptorCollection GetProperties(PropertyDescriptorCollection objProperties)
		{
			if (((IComponent)this).Site != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Skin skin = (Skin)((IComponent)this).Site.GetService(typeof(Skin));
				if (skin != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (skin.IsInherited(this))
					{
						/*OpCode not supported: LdMemberToken*/;
						List<OB> list = new List<OB>();
						IEnumerator enumerator = objProperties.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								PropertyDescriptor objProperty = (PropertyDescriptor)enumerator.Current;
								list.Add(new OB(objProperty));
							}
						}
						finally
						{
							if (!(enumerator is IDisposable disposable))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								disposable.Dispose();
							}
						}
						return new PropertyDescriptorCollection(list.ToArray());
					}
					return objProperties;
				}
				return objProperties;
			}
			return objProperties;
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		protected virtual SkinResource Clone()
		{
			return new SkinResource(this);
		}

		internal virtual VT GetValue<VT>(VT objDefaultValue)
		{
			if (this is VT)
			{
				return (VT)(object)this;
			}
			return objDefaultValue;
		}
	}
}
