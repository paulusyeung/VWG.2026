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

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
[Serializable]
	public class DeviceMedia : WatchedDeviceComponent, IDeviceMedia
	{
		private Dictionary<string, Media> mobjIdMediaMap = new Dictionary<string, Media>();

		private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;

		private SingleCallMethodStore<MediaPositionEventArgs> mobjMediaPositionEventArgsStore;

		private SingleCallMethodStore<MediaEventArgs> mobjMediaEventArgsStore;

		private Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>> mobjMediaIdPositionChangedStoreMap = new Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>>();

		/// 
		/// Gets the media position event args store.
		/// </summary>
		internal SingleCallMethodStore<MediaPositionEventArgs> MediaPositionEventArgsStore
		{
			get
			{
				if (mobjMediaPositionEventArgsStore == null)
				{
					mobjMediaPositionEventArgsStore = new SingleCallMethodStore<MediaPositionEventArgs>();
				}
				return mobjMediaPositionEventArgsStore;
			}
		}

		/// 
		/// Gets the media event args store.
		/// </summary>
		internal SingleCallMethodStore<MediaEventArgs> MediaEventArgsStore
		{
			get
			{
				if (mobjMediaEventArgsStore == null)
				{
					mobjMediaEventArgsStore = new SingleCallMethodStore<MediaEventArgs>();
				}
				return mobjMediaEventArgsStore;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.DeviceMedia" /> class.
		/// </summary>
		/// <param name="objIntegrator">The obj integrator.</param>
		public DeviceMedia(DeviceIntegrator objIntegrator)
			: base(objIntegrator)
		{
		}

		private MultipleCallMethodStore<MediaPositionEventArgs> GetPositionChangedStore(Media objMedia)
		{
			MultipleCallMethodStore<MediaPositionEventArgs> value = null;
			if (!mobjMediaIdPositionChangedStoreMap.TryGetValue(objMedia.Id, out value))
			{
				value = new MultipleCallMethodStore<MediaPositionEventArgs>();
				mobjMediaIdPositionChangedStoreMap.Add(objMedia.Id, value);
			}
			return value;
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "DMA";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			if (objEvent.Type == "Duration")
			{
				string s = objEvent["dur"];
				float duration = float.Parse(s);
				string key = objEvent["mid"];
				Media media = mobjIdMediaMap[key];
				media.Duration = duration;
				return;
			}
			if (objEvent.Type == "Position")
			{
				string text = objEvent["mediaIdsPositionData"];
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
					foreach (string text2 in array)
					{
						string[] array2 = text2.Split(new string[1] { "-" }, StringSplitOptions.RemoveEmptyEntries);
						Media objMedia = mobjIdMediaMap[array2[0]];
						float fltPosition = float.Parse(array2[1]);
						OnPositionChanged(objMedia, new MediaPositionEventArgs(fltPosition));
					}
				}
				return;
			}
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(objEvent.Type);
			if (keyValuePair.Key == null)
			{
				if (mobjIdMediaMap.TryGetValue(objEvent.Type, out var value))
				{
					value.HandleEvent(objEvent);
				}
				return;
			}
			string key2 = keyValuePair.Key;
			float fltValue2;
			if (!(key2 == "pos"))
			{
				if (!(key2 == "dur"))
				{
					throw new Exception();
				}
				if (CommonUtils.TryParse(objEvent["dur"], out float fltValue))
				{
					Media media2 = mobjIdMediaMap[keyValuePair.Value];
					media2.Duration = fltValue;
				}
			}
			else if (CommonUtils.TryParse(objEvent["pos"], out fltValue2))
			{
				MediaPositionEventArgs args = new MediaPositionEventArgs(fltValue2);
				mobjMediaPositionEventArgsStore.InvokeContextualMethod(keyValuePair.Value, args);
			}
		}

		/// 
		/// Raises the <see cref="E:OnPositionChanged" /> event.
		/// </summary>
		private void OnPositionChanged(Media objMedia, MediaPositionEventArgs objArguments)
		{
			MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = GetPositionChangedStore(objMedia);
			positionChangedStore.InvokeMultipleCallMethods(objArguments);
		}

		/// 
		/// Creates a media.
		/// </summary>
		/// <param name="strSource">The STR source.</param>
		/// </returns>
		public IMedia CreateMedia(string strSource)
		{
			Update();
			Media media = new Media(strSource, this);
			mobjIdMediaMap.Add(media.GetHashCode().ToString(), media);
			return media;
		}

		/// 
		/// Plays the specified obj media.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void Play(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.playBack", "play", objMedia.GetHashCode().ToString());
		}

		/// 
		/// Pauses the specified obj media.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void Pause(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.playBack", "pause", objMedia.GetHashCode().ToString());
		}

		/// 
		/// Stops the specified obj media.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void Stop(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.playBack", "stop", objMedia.GetHashCode().ToString());
		}

		/// 
		/// Releases the specified obj media.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void Release(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.release", objMedia.GetHashCode().ToString());
		}

		/// 
		/// Seeks to.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="lngMilliseconds">The LNG milliseconds.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void SeekTo(Media objMedia, ulong lngMilliseconds)
		{
			Invoke("DeviceIntegrator.Media.seek", objMedia.GetHashCode().ToString(), lngMilliseconds);
		}

		/// 
		/// Renders the sub components.
		/// </summary>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Media_Initialize", ID);
			foreach (Media value in mobjIdMediaMap.Values)
			{
				if (value.IsDirty(lngRequestID))
				{
					RenderMedia(value, objContext, objWriter);
				}
			}
			if (mobjClientMethodsInvocationBuffer == null)
			{
				return;
			}
			foreach (KeyValuePair<string, object[]> item in mobjClientMethodsInvocationBuffer)
			{
				VWGClientContext.Current.Invoke(item.Key, item.Value);
			}
			mobjClientMethodsInvocationBuffer.Clear();
			mobjClientMethodsInvocationBuffer = null;
		}

		/// 
		/// Renders the media.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderMedia(Media objMedia, IContext objContext, IResponseWriter objWriter)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (objMedia.GetSuccessData() != null)
			{
				flag = true;
			}
			if (objMedia.GetErrorData() != null)
			{
				flag2 = true;
			}
			if (objMedia.GetStateData() != null)
			{
				flag3 = true;
			}
			bool flag4 = false;
			if (mobjMediaIdPositionChangedStoreMap.ContainsKey(objMedia.Id))
			{
				flag4 = true;
			}
			VWGClientContext.Current.Invoke(base.DeviceIntegrator, "Media_InitializeMedia", objMedia.Id, objMedia.Source, flag, flag2, flag3, flag4);
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		internal override void RenderAttributes(IContext objContext, IResponseWriter objWriter)
		{
			IAttributeWriter attributeWriter = objWriter as IAttributeWriter;
			if (GetCriticalEventsData().HasEvents)
			{
				attributeWriter.WriteAttributeString("E", GetCriticalEventsData().ToClientString());
			}
		}

		public void AddPositionChanged(Media objMedia, Action<MediaPositionEventArgs> objAction)
		{
			MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = GetPositionChangedStore(objMedia);
			positionChangedStore.AddMultipleCallMethod(objAction);
			objMedia.Update();
		}

		public void RemovePositionChanged(Media objMedia, Action<MediaPositionEventArgs> objAction)
		{
			MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = GetPositionChangedStore(objMedia);
			positionChangedStore.RemoveMultipleCallMethod(objAction);
			if (!positionChangedStore.HasEventListeners())
			{
				mobjMediaIdPositionChangedStoreMap.Remove(objMedia.Id);
			}
			objMedia.Update();
		}

		/// 
		/// Gets the current position.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objCallback">The obj callback.</param>
		internal void GetCurrentPosition(Media objMedia, EventHandler<MediaPositionEventArgs> objCallback)
		{
			Invoke("DeviceIntegrator.Media.getCurrentPosition", objMedia.GetHashCode().ToString(), MediaPositionEventArgsStore.StoreContextualSingleCallMethod(objMedia, "pos", objCallback));
		}

		/// 
		/// Starts the record.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void StartRecord(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.playBack", "startRecord", objMedia.GetHashCode().ToString());
		}

		/// 
		/// Stops the record.
		/// </summary>
		/// <param name="objMedia">The obj media.</param>
		/// <param name="objClientContext">The obj client context.</param>
		internal void StopRecord(Media objMedia)
		{
			Invoke("DeviceIntegrator.Media.playBack", "stopRecord", objMedia.GetHashCode().ToString());
		}

		public override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = new CriticalEventsData();
			foreach (MultipleCallMethodStore<MediaPositionEventArgs> value in mobjMediaIdPositionChangedStoreMap.Values)
			{
				if (value.HasEventListeners())
				{
					criticalEventsData.Set("DMP");
				}
			}
			return criticalEventsData;
		}
	}
}
