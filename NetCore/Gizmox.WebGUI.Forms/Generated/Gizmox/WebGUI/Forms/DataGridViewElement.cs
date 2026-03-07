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
	/// Provides the base class for elements of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class DataGridViewElement : SerializableObject, IRenderableComponentMember, IIdentifiedComponent
	{
		/// 
		/// Renderable enumeration.
		/// </summary>
		[Serializable]
		internal enum Renderable
		{
			/// 
			/// Represents ContextMenu attribute.
			/// </summary>
			ContextMenuAttribute = 1,
			/// 
			/// Represents Selected attribute.
			/// </summary>
			SelectedAttribute = 2,
			/// 
			/// Represents ErrorText attribute.
			/// </summary>
			ErrorTextAttribute = 4
		}

		/// 
		/// PreRenderable enumeration.
		/// </summary>
		[Serializable]
		internal enum PreRenderable
		{
			/// 
			/// Represents DataGridViewCellStyle.
			/// </summary>
			CellStyle = 1
		}

		/// 
		/// ElementReadOnly Type
		/// </summary>
		[Serializable]
		protected internal enum ElementReadOnlyType
		{
			/// 
			/// value not set
			/// </summary>
			NotSet,
			/// 
			/// element is not read only
			/// </summary>
			False,
			/// 
			/// element is read only
			/// </summary>
			True
		}

		private string mstrTagName;

		private ElementReadOnlyType menmElementReadOnly = ElementReadOnlyType.NotSet;

		private DataGridViewElementStates menmState;

		private DataGridViewElementClientStates menmClientState = DataGridViewElementClientStates.None;

		private DataGridView mobjDataGridView = null;

		/// 
		/// Gets or sets the last modified params.
		/// </summary>
		/// The last modified params.</value>
		internal long LastModifiedParams;

		/// 
		/// Gets or sets the type of the last modified params.
		/// </summary>
		/// The type of the last modified params.</value>
		internal AttributeType LastModifiedParamsType = AttributeType.None;

		/// 
		/// Gets or sets the last modified.
		/// </summary>
		/// The last modified.</value>
		internal long LastModified;

		/// 
		/// Gets the member ID.
		/// </summary>
		/// The member ID.</value>
		protected virtual string MemberID => "0";

		/// 
		/// Gets the location.
		/// </summary>
		/// The location.</value>
		protected internal virtual Point Location => Point.Empty;

		/// 
		/// Gets the member ID internal.
		/// </summary>
		/// The member ID internal.</value>
		internal string MemberIDInternal => MemberID;

		/// 
		/// Gets the owner ID.
		/// </summary>
		/// The owner ID.</value>
		private string OwnerID
		{
			get
			{
				DataGridView dataGridView = DataGridView;
				return dataGridView.GetProxyPropertyValue("ID", dataGridView.ID).ToString();
			}
		}

		/// 
		/// Gets or sets the name of the tag.
		/// </summary>
		/// The name of the tag.</value>
		protected string TagName
		{
			get
			{
				return mstrTagName;
			}
			set
			{
				mstrTagName = value;
			}
		}

		/// 
		/// Gets or sets the element read only.
		/// </summary>
		/// The element read only.</value>
		protected internal virtual ElementReadOnlyType ElementReadOnly
		{
			get
			{
				return menmElementReadOnly;
			}
			set
			{
				menmElementReadOnly = value;
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
		[Browsable(false)]
		public virtual bool IsEventsEnabled => true;

		/// 
		/// Gets the default render mask. Initialized to render all.
		/// </summary>
		internal virtual int RenderMask => 0;

		/// 
		/// Gets the default prerender mask. Initialized to prerender all.
		/// </summary>
		internal virtual int PreRenderMask => 0;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control associated with this element.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control that contains this element. The default is null.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataGridView DataGridView
		{
			get
			{
				return mobjDataGridView;
			}
			private set
			{
				mobjDataGridView = value;
			}
		}

		internal DataGridView DataGridViewInternal
		{
			set
			{
				DataGridView dataGridView = DataGridView;
				if (dataGridView != value)
				{
					DataGridView = value;
					OnDataGridViewChanged();
				}
			}
		}

		/// Gets the user interface (UI) state of the element.</summary>
		/// A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the state.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewElementStates State
		{
			get
			{
				return menmState;
			}
			private set
			{
				menmState = value;
			}
		}

		/// 
		/// Gets or sets the state of the client.
		/// </summary>
		/// The state of the client.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal DataGridViewElementClientStates ClientState
		{
			get
			{
				return menmClientState;
			}
			set
			{
				menmClientState = value;
			}
		}

		internal DataGridViewElementStates StateInternal
		{
			set
			{
				State = value;
			}
		}

		string IIdentifiedComponent.ID => MemberID;

		/// 
		/// Determines whether element should render provided renderable.
		/// </summary>
		/// <param name="intRenderMask">The render mask.</param>
		/// <param name="enmRenderableToCheck">The attribute to check.</param>
		/// </returns>
		internal static bool ShouldRender(int intRenderMask, Renderable enmRenderableToCheck)
		{
			return ((uint)intRenderMask & (uint)enmRenderableToCheck) != (uint)enmRenderableToCheck;
		}

		/// 
		/// Determines whether element should prerender provided prerenderable.
		/// </summary>
		/// <param name="intPreRenderMask">The int pre render mask.</param>
		/// <param name="enmPreRenderableToCheck">The enm pre renderable to check.</param>
		/// </returns>
		internal static bool ShouldPreRender(int intPreRenderMask, PreRenderable enmPreRenderableToCheck)
		{
			return ((uint)intPreRenderMask & (uint)enmPreRenderableToCheck) != (uint)enmPreRenderableToCheck;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElement"></see> class.</summary>
		public DataGridViewElement()
		{
			State = DataGridViewElementStates.Visible;
			InitializeCompoent();
		}

		/// 
		///
		/// </summary>
		/// <param name="objDGVTemplate"></param>
		internal DataGridViewElement(DataGridViewElement objDGVTemplate)
		{
			InitializeCompoent();
			State = objDGVTemplate.State & (DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.ResizableSet | DataGridViewElementStates.Visible);
		}

		/// 
		/// Initializes the compoent.
		/// </summary>
		private void InitializeCompoent()
		{
			LastModifiedParams = (LastModified = GetCurrentTicks(blnIsForceRender: true));
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		[Obsolete("Use GetCriticalEventsData instead")]
		protected virtual EventTypes GetCriticalEvents()
		{
			return EventTypes.None;
		}

		/// 
		/// Gets the critical event name.
		/// </summary>
		protected virtual CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData objCriticalEventsData = new CriticalEventsData();
			EventTypes criticalEvents = GetCriticalEvents();
			RegisteredComponent.MergeCriticalEventsWithObselete(ref objCriticalEventsData, criticalEvents);
			return objCriticalEventsData;
		}

		/// 
		/// Clears the element read only from property store.
		/// </summary>
		protected internal void ClearElementReadOnly()
		{
			menmElementReadOnly = ElementReadOnlyType.NotSet;
		}

		/// 
		/// Gets the element read only.
		/// </summary>
		/// <param name="blnElementReadOnlyValue">if set to true</c> [BLN element read only value].</param>
		/// true</c> if the property store have value, false</c> if proprty store is empty</returns>
		protected internal bool GetElementReadOnly(out bool blnElementReadOnlyValue)
		{
			bool result = menmElementReadOnly != ElementReadOnlyType.NotSet;
			blnElementReadOnlyValue = menmElementReadOnly == ElementReadOnlyType.True;
			return result;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected internal virtual void FireEvent(IEvent objEvent)
		{
		}

		/// 
		/// Renders the element's event attributes.
		/// </summary>
		/// <param name="objContext">context.</param>
		/// <param name="objWriter">writer.</param>       
		protected virtual void RenderElementEventAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			CriticalEventsData criticalEventsData = GetCriticalEventsData();
			if (criticalEventsData.HasEvents || blnForceRender)
			{
				string strValue = criticalEventsData.ToClientString();
				objWriter.WriteAttributeString("E", strValue);
			}
		}

		/// 
		/// Renders the element's meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderElementAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			objWriter.WriteAttributeString("mId", MemberID);
			if (blnRenderOwner)
			{
				objWriter.WriteAttributeString("oId", OwnerID);
			}
			RenderElementEventAttributes(objContext, objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the element update attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderElementUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			objWriter.WriteAttributeString("mId", MemberID);
			if (blnRenderOwner)
			{
				objWriter.WriteAttributeString("oId", OwnerID);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Events))
			{
				RenderElementEventAttributes(objContext, objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			RenderElementAttributes(objContext, objWriter, blnRenderOwner);
		}

		/// 
		/// Renders the updated attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			RenderElementUpdateAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Adds a critical event delegate to the list.
		/// </summary>
		/// <param name="objSerializableEvent">The serializable event.</param>
		/// <param name="objValue">The delegate to add to the list.</param>
		protected void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (AddHandler(objSerializableEvent, objValue))
			{
				UpdateParams(AttributeType.Events);
			}
		}

		/// 
		/// Removes a critical event delegate from the list.
		/// </summary>
		/// <param name="objSerializableEvent">The serializable event.</param>
		/// <param name="objValue">The delegate to remove from the list.</param>
		protected void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
		{
			if (RemoveHandler(objSerializableEvent, objValue))
			{
				UpdateParams(AttributeType.Events);
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
		}

		void IRenderableComponentMember.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Pres the render component.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		internal virtual void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
		}

		/// 
		/// Posts the render component.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		internal virtual void PostRenderComponent(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			ResetParams();
		}

		/// 
		/// Checks if the current control needs rendering and
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		protected virtual void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			if (IsDirty(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, TagName, WGConst.Namespace);
				RenderAttributes(objContext, (IAttributeWriter)objWriter, blnRenderOwner);
				RenderComponents(objContext, objWriter, 0L, blnRenderOwner);
				objWriter.WriteEndElement();
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
				RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID, blnRenderOwner);
				RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
				objWriter.WriteEndElement();
			}
			else
			{
				RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
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
			return int.Parse(text);
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public virtual void Update()
		{
			LastModified = GetCurrentTicks();
			LastModifiedParamsType = AttributeType.None;
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="blnRedrawOnly">if set to true</c> [BLN redraw only].</param>
		public virtual void Update(bool blnRedrawOnly)
		{
			if (blnRedrawOnly)
			{
				UpdateParams(AttributeType.Redraw);
			}
			else
			{
				Update();
			}
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		internal virtual void Update(AttributeType enmParams)
		{
			UpdateParams(enmParams);
		}

		/// 
		/// Updates only the parameters of this instance.
		/// </summary>
		protected virtual void UpdateParams()
		{
			LastModifiedParams = GetCurrentTicks();
			LastModifiedParamsType = AttributeType.All;
		}

		/// 
		/// Updates the params.
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		protected internal virtual void UpdateParams(AttributeType enmParams)
		{
			LastModifiedParams = GetCurrentTicks();
			LastModifiedParamsType |= enmParams;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lngRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		internal bool IsDirty(long lngRequestID)
		{
			return LastModified > lngRequestID;
		}

		/// 
		/// Resets the params.
		/// </summary>
		protected void ResetParams()
		{
			LastModifiedParamsType = AttributeType.None;
		}

		/// 
		/// Determines whether the specified component is dirty.
		/// </summary>
		/// <param name="lngRequestID">Request ID.</param>
		/// 
		/// 	true</c> if the specified component is dirty; otherwise, false</c>.
		/// </returns>
		protected bool IsDirtyAttributes(long lngRequestID)
		{
			return LastModifiedParams > lngRequestID;
		}

		/// 
		/// Determines whether [is dirty attributes] [the specified LNG request ID].
		/// </summary>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="enmParams">The enm params.</param>
		/// 
		/// 	true</c> if [is dirty attributes] [the specified LNG request ID]; otherwise, false</c>.
		/// </returns>
		protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams)
		{
			return LastModifiedParams > lngRequestID && (LastModifiedParamsType & enmParams) > AttributeType.None;
		}

		/// Called when the element is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		protected virtual void OnDataGridViewChanged()
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected void RaiseCellClick(DataGridViewCellEventArgs e)
		{
			DataGridView?.OnCellClickInternal(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected void RaiseCellContentClick(DataGridViewCellEventArgs e)
		{
			DataGridView?.OnCellContentClickInternal(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected void RaiseCellContentDoubleClick(DataGridViewCellEventArgs e)
		{
			DataGridView?.OnCellContentDoubleClickInternal(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected void RaiseCellValueChanged(DataGridViewCellEventArgs e)
		{
			RaiseCellValueChanged(e, blnClientSource: false);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		protected internal void RaiseCellValueChanged(DataGridViewCellEventArgs e, bool blnClientSource)
		{
			DataGridView?.OnCellValueChangedInternal(e, blnClientSource);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> that contains the event data. </param>
		protected void RaiseDataError(DataGridViewDataErrorEventArgs e)
		{
			DataGridView?.OnDataErrorInternal(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseWheel"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		protected void RaiseMouseWheel(MouseEventArgs e)
		{
			DataGridView?.OnMouseWheelInternal(e);
		}

		internal bool StateExcludes(DataGridViewElementStates elementState)
		{
			return (State & elementState) == 0;
		}

		internal bool StateIncludes(DataGridViewElementStates elementState)
		{
			return (State & elementState) == elementState;
		}
	}
}
