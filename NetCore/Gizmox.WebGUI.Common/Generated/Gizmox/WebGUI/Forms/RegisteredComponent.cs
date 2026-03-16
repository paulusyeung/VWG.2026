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

namespace Gizmox.WebGUI.Forms
{
	[Serializable]
	[ComVisible(true)]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms")]
	[DesignerCategory("Component")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public abstract class RegisteredComponent : ComponentBase, IAddChild, IClientComponent, IIdentifiedComponent, IGatewayComponent, IEventHandler, IRegisteredComponent
	{
		[Serializable]
		private class NotImplementedGateway : IGatewayHandler
		{
			private string mstrAction;

			public NotImplementedGateway(string strAction)
			{
				mstrAction = strAction;
			}

			public void ProcessGatewayRequest(IContext objContext, IRegisteredComponent objComponent)
			{
				throw new HttpException(501, $"The component does not handle gateway requests [action='{mstrAction}'].");
			}
		}

		private static SerializableProperty VisualEffectsProperty = SerializableProperty.Register("VisualEffects", typeof(VisualEffect), typeof(RegisteredComponent), new SerializablePropertyMetadata(null));

		[NonSerialized]
		private long B;

		[NonSerialized]
		private long C;

		[NonSerialized]
		private AttributeType D;

		[NonSerialized]
		private bool? E;

		[NonSerialized]
		private long F;

		private static readonly SerializableProperty ClientIdProperty = SerializableProperty.Register("ClientId", typeof(string), typeof(RegisteredComponent), new SerializablePropertyMetadata(""));

		[NonSerialized]
		private bool G;

		private static readonly SerializableEvent TransitionVisualEffectEndEvent;

		private static readonly SerializableProperty ClientEventsProperty;

		private EventHandler TransitionVisualEffectEndHandler => (EventHandler)GetHandler(TransitionVisualEffectEndEvent);

		[Description("Provide definitions for visual effects.")]
		[DefaultValue(null)]
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.VisualEffectCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[MergableProperty(false)]
		[SRCategory("CatBehavior")]
		public VisualEffect VisualEffect
		{
			get
			{
				return GetValue<VisualEffect>(VisualEffectsProperty);
			}
			set
			{
				if (SetValue(VisualEffectsProperty, value))
				{
					UpdateParams(AttributeType.VisualEffect);
				}
			}
		}

		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 6;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual bool IsEventsEnabled => true;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public abstract IContext Context { get; }

		protected bool UseClientUpdateHandler => E == true;

		protected ISession Session => Context?.Session;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		protected long LastModified => B;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		protected long LastModifiedParams => C;

		bool IRegisteredComponent.IsConnected => IsConnected;

		protected virtual bool IsConnected => true;

		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool IsRegistered
		{
			get
			{
				return G;
			}
			set
			{
				G = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(0)]
		public virtual long ID
		{
			get
			{
				if (F != 0L)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (IsRegistered)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					RegisterSelf();
				}
				return F;
			}
			set
			{
				F = value;
			}
		}

		[Category("Client")]
		[DefaultValue("")]
		[SRDescription("Gets the id that will be use in the client to access the control.")]
		public string ClientId
		{
			get
			{
				return GetValue(ClientIdProperty, "");
			}
			set
			{
				if (SetValue(ClientIdProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual RegisteredState RegisteredState
		{
			get
			{
				RegisteredState registeredState = RegisteredState.Unregistered;
				if (F == 0L)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					registeredState = RegisteredState.Identified;
				}
				if (!G)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					registeredState |= RegisteredState.Registered;
				}
				return registeredState;
			}
		}

		protected virtual string ClientUpdateHandler
		{
			get
			{
				if (D == AttributeType.VisualEffect)
				{
					return "VisualEffects_ChangeVisualEffect";
				}
				return string.Empty;
			}
		}

		string IIdentifiedComponent.ID => ID.ToString();

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Category("Client")]
		[Description("Provides client id to the component.")]
		[DefaultValue(null)]
		string IClientComponent.ID => GetClientComponentID();

		string IClientComponent.Name => GetClientComponentName();

		ClientEventList IClientComponent.Events
		{
			get
			{
				ClientEventList value = GetValue<ClientEventList>(ClientEventsProperty, null);
				if (value == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return value;
			}
		}

		IClientComponent IClientComponent.Parent => ClientParent;

		protected virtual IClientComponent ClientParent => null;

		protected virtual bool ShouldRenderClientEvents => true;

		public event EventHandler TransitionVisualEffectEnd
		{
			add
			{
				AddCriticalHandler(TransitionVisualEffectEndEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(TransitionVisualEffectEndEvent, value);
			}
		}

		[SRDescription("Occurs when control's transition visual effect ends in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientTransitionVisualEffectEnd
		{
			add
			{
				AddClientHandler("TransitionEnded", value);
			}
			remove
			{
				RemoveClientHandler("TransitionEnded", value);
			}
		}

		public RegisteredComponent()
		{
			C = (B = GetCurrentTicks(blnIsForceRender: true));
		}

		static RegisteredComponent()
		{
			TransitionVisualEffectEndEvent = SerializableEvent.Register("TransitionEnded", typeof(EventHandler), typeof(SerializableObject));
			ClientEventsProperty = SerializableProperty.Register("ClientEvents", typeof(ClientEventList), typeof(ComponentBase), new SerializablePropertyMetadata(null));
		}

		protected virtual void OnTransitionVisualEffectEnd(EventArgs e)
		{
			EventHandler transitionVisualEffectEndHandler = TransitionVisualEffectEndHandler;
			if (transitionVisualEffectEndHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				transitionVisualEffectEndHandler(this, e);
			}
		}

		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			B = objReader.ReadLong();
			C = objReader.ReadLong();
			D = (AttributeType)objReader.ReadObject();
			G = objReader.ReadBoolean();
			E = (bool?)objReader.ReadObject();
			F = objReader.ReadLong();
		}

		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteLong(B);
			objWriter.WriteLong(C);
			objWriter.WriteObject(D);
			objWriter.WriteBoolean(G);
			objWriter.WriteObject(E);
			objWriter.WriteLong(F);
		}

		public virtual void Update()
		{
			Update(blnRedrawOnly: false);
		}

		public virtual void Update(bool blnRedrawOnly)
		{
			Update(blnRedrawOnly, blnUseClientUpdateHandler: false);
		}

		public virtual void Update(bool blnRedrawOnly, bool blnUseClientUpdateHandler)
		{
			if (!G)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (E == false)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				E = blnUseClientUpdateHandler;
			}
			if (blnRedrawOnly)
			{
				UpdateParams(AttributeType.Redraw);
				return;
			}
			B = GetCurrentTicks();
			D = AttributeType.None;
		}

		public virtual void UpdateParams()
		{
			UpdateParams(AttributeType.All);
		}

		public virtual void UpdateParams(AttributeType enmParams)
		{
			UpdateParams(enmParams, blnUseClientUpdateHandler: true);
		}

		public virtual void UpdateParams(AttributeType enmParams, bool blnUseClientUpdateHandler)
		{
			if (!G)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			bool? e = E;
			bool flag = false;
			if (e == true == flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (e.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0058;
				}
			}
			E = blnUseClientUpdateHandler;
			goto IL_0058;
			IL_0058:
			C = GetCurrentTicks();
			D |= enmParams;
		}

		protected bool IsDirty(long lngRequestID)
		{
			return B > lngRequestID;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckDirty(long lngRequestID)
		{
			if (IsDirty(lngRequestID))
			{
				return true;
			}
			if (!IsDirtyAttributes(lngRequestID))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return true;
		}

		protected bool IsDirtyAttributes(long lngRequestID)
		{
			return C > lngRequestID;
		}

		protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams)
		{
			if (C <= lngRequestID)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (D & enmParams) > AttributeType.None;
		}

		protected virtual bool ShouldRenderIsDirtyAttribute(long lngRequestID)
		{
			return false;
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
			if (!IsEventsEnabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				FireEvent(objEvent);
			}
		}

		[Obsolete("Use GetCriticalEventsData instead")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual EventTypes GetCriticalEvents()
		{
			return EventTypes.None;
		}

		[Obsolete("Use GetCriticalClientEventsData instead")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual EventTypes GetCriticalClientEvents()
		{
			return EventTypes.None;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData objCriticalEventsData = new CriticalEventsData();
			if (TransitionVisualEffectEndHandler != null)
			{
				objCriticalEventsData.Set("TVE");
			}
			EventTypes criticalEvents = GetCriticalEvents();
			MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
			return objCriticalEventsData;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData objCriticalEventsData = new CriticalEventsData();
			if (!HasClientHandler("TransitionEnded"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objCriticalEventsData.Set("TVE");
			}
			EventTypes criticalClientEvents = GetCriticalClientEvents();
			MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalClientEvents);
			return objCriticalEventsData;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual MouseCaptures GetMouseEventCaptures()
		{
			return MouseCaptures.None;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual KeyCaptures GetKeyEventCaptures()
		{
			return KeyCaptures.None;
		}

		protected void RenderComponentVisualEffectsAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			VisualEffect visualEffect = VisualEffect;
			if (visualEffect == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				visualEffect.RenderVisualEffectAttributes(objContext, objWriter);
			}
		}

		public static void MergeCriticalEventsWithObselete(ref CriticalEventsData objCriticalEventsData, EventTypes enmObseleteCriticalEvents)
		{
			if (enmObseleteCriticalEvents != EventTypes.None)
			{
				/*OpCode not supported: LdMemberToken*/;
				if ((enmObseleteCriticalEvents & EventTypes.Activated) != EventTypes.Activated)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("AC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.AfterLabelEdit) != EventTypes.AfterLabelEdit)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("ALE");
				}
				if ((enmObseleteCriticalEvents & EventTypes.BeginEdit) != EventTypes.BeginEdit)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("BE");
				}
				if ((enmObseleteCriticalEvents & EventTypes.ChangeColumnWidth) != EventTypes.ChangeColumnWidth)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("CCW");
				}
				if ((enmObseleteCriticalEvents & EventTypes.CheckedChange) == EventTypes.CheckedChange)
				{
					objCriticalEventsData.Set("CC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Click) != EventTypes.Click)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("CL");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Closed) != EventTypes.Closed)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("CLO");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Closing) != EventTypes.Closing)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("CLI");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Collapse) != EventTypes.Collapse)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("COL");
				}
				if ((enmObseleteCriticalEvents & EventTypes.ColumnDividerDoubleClick) != EventTypes.ColumnDividerDoubleClick)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("CDD");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Deactivate) != EventTypes.Deactivate)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("DAT");
				}
				if ((enmObseleteCriticalEvents & EventTypes.DoubleClick) == EventTypes.DoubleClick)
				{
					objCriticalEventsData.Set("DCL");
				}
				if ((enmObseleteCriticalEvents & EventTypes.DragDrop) != EventTypes.DragDrop)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("DD");
				}
				if ((enmObseleteCriticalEvents & EventTypes.EndEdit) != EventTypes.EndEdit)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("EE");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Enter) == EventTypes.Enter)
				{
					objCriticalEventsData.Set("EN");
				}
				if ((enmObseleteCriticalEvents & EventTypes.EnterKeyDown) != EventTypes.EnterKeyDown)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("EKD");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Expand) != EventTypes.Expand)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("EXP");
				}
				if ((enmObseleteCriticalEvents & EventTypes.GotFocus) != EventTypes.GotFocus)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("GF");
				}
				if ((enmObseleteCriticalEvents & EventTypes.KeyDown) != EventTypes.KeyDown)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("KD");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Leave) != EventTypes.Leave)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("LE");
				}
				if ((enmObseleteCriticalEvents & EventTypes.LocationChange) != EventTypes.LocationChange)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("LC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.LostFocus) == EventTypes.LostFocus)
				{
					objCriticalEventsData.Set("LF");
				}
				if ((enmObseleteCriticalEvents & EventTypes.OrientationChanged) != EventTypes.OrientationChanged)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("OC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.PositionChanged) == EventTypes.PositionChanged)
				{
					objCriticalEventsData.Set("PC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.RightClick) != EventTypes.RightClick)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("RC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.SelectionChange) == EventTypes.SelectionChange)
				{
					objCriticalEventsData.Set("SLC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.SizeChange) != EventTypes.SizeChange)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("SC");
				}
				if ((enmObseleteCriticalEvents & EventTypes.StartDrag) != EventTypes.StartDrag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("SD");
				}
				if ((enmObseleteCriticalEvents & EventTypes.Swipe) != EventTypes.Swipe)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("SWP");
				}
				if ((enmObseleteCriticalEvents & EventTypes.TransitionVisualEffectEnd) != EventTypes.TransitionVisualEffectEnd)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("TVE");
				}
				if ((enmObseleteCriticalEvents & EventTypes.ValueChange) != EventTypes.ValueChange)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCriticalEventsData.Set("VC");
				}
			}
		}

		protected void RenderComponentEventAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			CriticalEventsData criticalEventsData = GetCriticalEventsData();
			if (!(criticalEventsData.HasEvents || blnForceRender))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string strValue = criticalEventsData.ToClientString();
				objWriter.WriteAttributeString("E", strValue);
			}
			CriticalEventsData criticalClientEventsData = GetCriticalClientEventsData();
			if (!(criticalClientEventsData.HasEvents || blnForceRender))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string strValue2 = criticalClientEventsData.ToClientString();
				objWriter.WriteAttributeString("OTS", strValue2);
			}
			long num = 0L;
			MouseCaptures mouseEventCaptures = GetMouseEventCaptures();
			if (mouseEventCaptures != MouseCaptures.None)
			{
				num = (long)mouseEventCaptures + 2L;
			}
			KeyCaptures keyEventCaptures = GetKeyEventCaptures();
			if (keyEventCaptures != KeyCaptures.None)
			{
				num |= (long)keyEventCaptures + 1L;
			}
			if (num > 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("EC", num.ToString());
			}
		}

		protected void RenderClientUpdateHandler(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!string.IsNullOrEmpty(ClientUpdateHandler) || blnForceRender)
			{
				if (!(objContext is IContextMethodInvoker contextMethodInvoker))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objWriter.WriteAttributeString("CUH", contextMethodInvoker.GetMethodName(this as ISkinable, ClientUpdateHandler));
				}
			}
		}

		protected void ResetParams()
		{
			D = AttributeType.None;
			E = null;
		}

		protected void RenderUseClientUpdateHandlerAttribute(IContext objContext, IAttributeWriter objWriter)
		{
			bool? e = E;
			bool flag = true;
			if (e == true == flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (e.HasValue)
				{
					if (!string.IsNullOrEmpty(ClientUpdateHandler))
					{
						objWriter.WriteAttributeString("UCU", "1");
					}
					return;
				}
			}
			/*OpCode not supported: LdMemberToken*/;
		}

		protected virtual void FireEvent(IEvent objEvent)
		{
			if (objEvent.Type == "TransitionEnded")
			{
				OnTransitionVisualEffectEnd(EventArgs.Empty);
			}
		}

		[Obsolete("Use VWGClientContext.Invoke instead")]
		protected void InvokeMethod(string strMethodName, params object[] arrArguments)
		{
			ClientArgumentInvokeMethod objClientArgument = new ClientArgumentInvokeMethod();
			VWGClientContext.Current.Invoke(this as ISkinable, InvokationUniqueness.None, objClientArgument, strMethodName, arrArguments);
		}

		[Obsolete("Use VWGClientContext.Invoke instead")]
		protected void InvokeScript(string strJavaScriptCode)
		{
			InvokeMethod("eval", strJavaScriptCode);
		}

		[Obsolete("Use VWGClientContext.Invoke instead")]
		protected void InvokeMethodWithId(string strMember, params object[] arrArgs)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(ID.ToString());
			arrayList.AddRange(arrArgs);
			DoInvokeMethod(strMember, arrayList.ToArray());
		}

		private void DoInvokeMethod(string strMember, object[] arrArgs)
		{
			if (!(Context is IContextMethodInvoker contextMethodInvoker))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contextMethodInvoker.InvokeMethod(this as ISkinable, InvokationUniqueness.None, strMember, arrArgs);
			}
		}

		protected virtual void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (!AddHandler(objSerializableEvent, objValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				UpdateParams(AttributeType.Events);
			}
		}

		protected virtual void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (!RemoveHandler(objSerializableEvent, objValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				UpdateParams(AttributeType.Events);
			}
		}

		protected void RegisterSelf()
		{
			if (IsRegistered)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				RegisterComponent(this);
			}
		}

		protected void UnRegisterSelf()
		{
			if (IsRegistered)
			{
				UnRegisterComponent(this);
			}
		}

		protected virtual void RegisterBatch(ICollection objCollection)
		{
			IContext context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((ISessionRegistry)context).RegisterBatch(objCollection);
			}
		}

		protected virtual void UnRegisterBatch(ICollection objCollection)
		{
			IContext context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((ISessionRegistry)context).UnRegisterBatch(objCollection);
			}
		}

		protected virtual void RegisterComponent(IRegisteredComponent objComponent)
		{
			IContext context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((ISessionRegistry)context).RegisterComponent(objComponent);
			}
		}

		protected virtual void UnRegisterComponent(IRegisteredComponent objComponent)
		{
			IContext context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((ISessionRegistry)context).UnRegisterComponent(objComponent);
			}
		}

		void IRegisteredComponent.UnregisterComponents()
		{
			OnUnregisterComponents();
		}

		protected virtual void OnUnregisterComponents()
		{
		}

		void IRegisteredComponent.RegisterComponents()
		{
			OnRegisterComponents();
		}

		protected virtual void OnRegisterComponents()
		{
		}

		void IRegisteredComponent.RegisterContextMenu()
		{
			RegisterContextMenu();
		}

		void IRegisteredComponent.UnregisterContextMenu()
		{
			UnregisterContextMenu();
		}

		protected virtual void RegisterContextMenu()
		{
		}

		protected virtual void UnregisterContextMenu()
		{
		}

		void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
		{
			IGatewayHandler gatewayHandler = ProcessGatewayRequest(objContext.HostContext, strAction);
			if (gatewayHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				gatewayHandler.ProcessGatewayRequest(objContext, this);
			}
		}

		protected virtual IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
		{
			return ProcessGatewayRequest(objHostContext.HttpContext, strAction);
		}

		protected virtual IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
		{
			return new NotImplementedGateway(strAction);
		}

		void IAddChild.AddChild(object value)
		{
			AddChild(value);
		}

		protected virtual void AddChild(object objValue)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual string GetClientComponentName()
		{
			return ID.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual string GetClientComponentID()
		{
			return ID.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal bool HasClientHandler(string strEvent)
		{
			if (string.IsNullOrEmpty(strEvent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ClientEventList value = GetValue<ClientEventList>(ClientEventsProperty, null);
				if (value != null)
				{
					return value[strEvent] != null;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void AddClientHandler(string strEvent, ClientEventHandler objClientEventHandler)
		{
			if (string.IsNullOrEmpty(strEvent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			ClientEventList clientEventList = GetValue<ClientEventList>(ClientEventsProperty, null);
			if (clientEventList != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objClientEventHandler != null)
			{
				SetValue(ClientEventsProperty, clientEventList = new ClientEventList());
			}
			if (clientEventList != null)
			{
				ClientEventHandler clientEventHandler = clientEventList[strEvent];
				if (clientEventHandler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					clientEventList[strEvent] = objClientEventHandler;
				}
				else
				{
					clientEventList[strEvent] = (ClientEventHandler)Delegate.Combine(clientEventHandler, objClientEventHandler);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RemoveClientHandler(string strEvent, ClientEventHandler objClientEventHandler)
		{
			ClientEventList value = GetValue<ClientEventList>(ClientEventsProperty, null);
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			ClientEventHandler clientEventHandler = value[strEvent];
			if (clientEventHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				value[strEvent] = (ClientEventHandler)Delegate.Remove(clientEventHandler, objClientEventHandler);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void RenderComponentClientEvents(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (ShouldRenderClientEvents)
			{
				GetClientEvents()?.Render(this, objContext, objWriter, lngRequestID);
			}
		}

		protected virtual ClientEventList GetClientEvents()
		{
			return ((IClientComponent)this)?.Events;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void ClearComponentOfflineEvents()
		{
			if (this != null)
			{
				ClientEventList events = ((IClientComponent)this).Events;
				if (events == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					events.Clear();
				}
			}
		}
	}
}
