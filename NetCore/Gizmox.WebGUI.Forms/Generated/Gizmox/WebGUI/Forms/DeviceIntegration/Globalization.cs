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
/// 
	///
	/// </summary>
	[Serializable]
	public class Globalization : DeviceComponent, IGlobalization
	{
		private SingleCallMethodStore<GlobalizationEventArgs> mobjSingleCallMethodStore;

		private SingleCallMethodStore<GlobalizationDateEventArgs> mobjSingleDateCallMethodStore;

		private SingleCallMethodStore<GlobalizationInfoEventArgs> mobjInfoSingleCallMethodStore;

		private SingleCallMethodStore<GlobalizationDatePatternEventArgs> mobjDatePatternSingleCallMethodStore;

		private SingleCallMethodStore<GlobalizationNumberPatternEventArgs> mobjNumberPatternSingleCallMethodStore;

		private SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> mobjCurrencyPatternSingleCallMethodStore;

		private SingleCallMethodStore<GlobalizationListEventArgs> mobjListSingleCallMethodStore;

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationEventArgs> SingleCallMethodStore<GlobalizationEventArgs>
		{
			get
			{
				if (mobjSingleCallMethodStore == null)
				{
					mobjSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>();
				}
				return mobjSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationDateEventArgs> SingleDateCallMethodStore
		{
			get
			{
				if (mobjSingleDateCallMethodStore == null)
				{
					mobjSingleDateCallMethodStore = new SingleCallMethodStore<GlobalizationDateEventArgs>();
				}
				return mobjSingleDateCallMethodStore;
			}
		}

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationDatePatternEventArgs> SingleDatePatternCallMethodStore
		{
			get
			{
				if (mobjDatePatternSingleCallMethodStore == null)
				{
					mobjDatePatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationDatePatternEventArgs>();
				}
				return mobjDatePatternSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the globalization info single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationInfoEventArgs> SingleInfoCallMethodStore
		{
			get
			{
				if (mobjInfoSingleCallMethodStore == null)
				{
					mobjInfoSingleCallMethodStore = new SingleCallMethodStore<GlobalizationInfoEventArgs>();
				}
				return mobjInfoSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationNumberPatternEventArgs> SingleNumberCallMethodStore
		{
			get
			{
				if (mobjNumberPatternSingleCallMethodStore == null)
				{
					mobjNumberPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationNumberPatternEventArgs>();
				}
				return mobjNumberPatternSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> SingleCurrencyCallMethodStore
		{
			get
			{
				if (mobjCurrencyPatternSingleCallMethodStore == null)
				{
					mobjCurrencyPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs>();
				}
				return mobjCurrencyPatternSingleCallMethodStore;
			}
		}

		/// 
		/// Gets the Connection single-call methods store.
		/// </summary>
		private SingleCallMethodStore<GlobalizationListEventArgs> SingleListCallMethodStore
		{
			get
			{
				if (mobjListSingleCallMethodStore == null)
				{
					mobjListSingleCallMethodStore = new SingleCallMethodStore<GlobalizationListEventArgs>();
				}
				return mobjListSingleCallMethodStore;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Globalization" /> class.
		/// </summary>
		/// <param name="objDeviceIntegrator">The obj device integrator.</param>
		public Globalization(DeviceIntegrator objDeviceIntegrator)
			: base(objDeviceIntegrator)
		{
		}

		protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
		{
			base.RenderSubComponents(lngRequestID, objContext, objWriter);
			Invoke("Globalization_Initialize", ID);
		}

		/// 
		/// Dates to string.
		/// </summary>
		/// <param name="objDateTime">The obj date time.</param>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void dateToString(DateTime objDateTime, Action<GlobalizationEventArgs> objCallback, GlobalizationDateOptions objOptions)
		{
			string text = SingleCallMethodStore<GlobalizationEventArgs>.StoreSingleCallMethod("datobj", objCallback);
			Invoke("DeviceIntegrator.Globalization.dateToString", objDateTime, text);
		}

		/// 
		/// Gets the currency pattern.
		/// </summary>
		/// <param name="strCurrencyCode">The STR currency code.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void getCurrencyPattern(string strCurrencyCode, Action<GlobalizationCurrencyPatternEventArgs> objCallback)
		{
			string text = SingleCurrencyCallMethodStore.StoreSingleCallMethod("cur", objCallback);
			Invoke("DeviceIntegrator.Globalization.getCurrencyPattern", strCurrencyCode, text);
		}

		/// 
		/// Gets the date names.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void getDateNames(Action<GlobalizationListEventArgs> objCallback, GlobalizationDateNameOptions objOptions)
		{
			string text = SingleListCallMethodStore.StoreSingleCallMethod("lst", objCallback);
			Invoke("DeviceIntegrator.Globalization.getDateNames", text, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Gets the date pattern.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void getDatePattern(Action<GlobalizationDatePatternEventArgs> objCallback, GlobalizationDateOptions objOptions)
		{
			string text = SingleDatePatternCallMethodStore.StoreSingleCallMethod("dat", objCallback);
			Invoke("DeviceIntegrator.Globalization.getDatePattern", text, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Gets the number pattern.
		/// </summary>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void getNumberPattern(Action<GlobalizationNumberPatternEventArgs> objCallback, GlobalizationNumberOptions objOptions)
		{
			string text = SingleNumberCallMethodStore.StoreSingleCallMethod("num", objCallback);
			Invoke("DeviceIntegrator.Globalization.getNumberPattern", text, CommonUtils.GetClientJsonObject(objOptions));
		}

		public void getGlobalizationInfo(Action<GlobalizationInfoEventArgs> objCallback)
		{
			string text = SingleInfoCallMethodStore.StoreSingleCallMethod("gi", objCallback);
			Invoke("DeviceIntegrator.Globalization.getGlobalizationInfo", text);
		}

		/// 
		/// Determines whether [is day light savings time] [the specified obj date time].
		/// </summary>
		/// <param name="objDateTime">The obj date time.</param>
		/// <param name="objCallback">The obj callback.</param>
		public void isDayLightSavingsTime(DateTime objDateTime, Action<GlobalizationEventArgs> objCallback)
		{
			string text = SingleCallMethodStore<GlobalizationEventArgs>.StoreSingleCallMethod("gen", objCallback);
			Invoke("DeviceIntegrator.Globalization.isDayLightSavingsTime", objDateTime, text);
		}

		/// 
		/// Numbers to string.
		/// </summary>
		/// <param name="dblNumber">The DBL number.</param>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void numberToString(double dblNumber, Action<GlobalizationEventArgs> objCallback, GlobalizationNumberOptions objOptions)
		{
			string text = SingleCallMethodStore<GlobalizationEventArgs>.StoreSingleCallMethod("gen", objCallback);
			Invoke("DeviceIntegrator.Globalization.numberToString", dblNumber, text, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Strings to date.
		/// </summary>
		/// <param name="strStringInput">The STR string input.</param>
		/// <param name="objCallback">The obj callback.</param>
		/// <param name="objOptions">The obj options.</param>
		public void stringToDate(string strStringInput, Action<GlobalizationDateEventArgs> objCallback, GlobalizationDateOptions objOptions)
		{
			string text = SingleDateCallMethodStore.StoreSingleCallMethod("datobj", objCallback);
			Invoke("DeviceIntegrator.Globalization.stringToDate", strStringInput, text, CommonUtils.GetClientJsonObject(objOptions));
		}

		public void stringToNumber(string strStringInput, Action<GlobalizationEventArgs> objCallback, GlobalizationNumberOptions objOptions)
		{
			string text = SingleCallMethodStore<GlobalizationEventArgs>.StoreSingleCallMethod("gen", objCallback);
			Invoke("DeviceIntegrator.Globalization.stringToNumber", strStringInput, text, CommonUtils.GetClientJsonObject(objOptions));
		}

		/// 
		/// Gets the tag.
		/// </summary>
		/// </returns>
		protected internal override string GetTag()
		{
			return "GLZ";
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			HandleEvent(objEvent);
		}

		/// 
		/// Handles the event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		private void HandleEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			KeyValuePair<string, string> keyValuePair = SplitPrefixFromMethodKey(type);
			switch (keyValuePair.Key)
			{
			case "gi":
			{
				GlobalizationInfoEventArgs globalizationInfoEventArgs = GetGlobalizationInfoEventArgs(objEvent);
				if (mobjInfoSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjInfoSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, globalizationInfoEventArgs);
				}
				break;
			}
			case "gen":
			{
				GlobalizationEventArgs generalEventArgs = GetGeneralEventArgs(objEvent);
				if (mobjSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, generalEventArgs);
				}
				break;
			}
			case "dat":
			{
				GlobalizationDatePatternEventArgs datePatternEventArgs = GetDatePatternEventArgs(objEvent);
				if (mobjDatePatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjDatePatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, datePatternEventArgs);
				}
				break;
			}
			case "datobj":
			{
				GlobalizationDateEventArgs dateEventArgs = GetDateEventArgs(objEvent);
				if (mobjSingleDateCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjSingleDateCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, dateEventArgs);
				}
				break;
			}
			case "num":
			{
				GlobalizationNumberPatternEventArgs numberPatternEventArgs = GetNumberPatternEventArgs(objEvent);
				if (mobjNumberPatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjNumberPatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, numberPatternEventArgs);
				}
				break;
			}
			case "cur":
			{
				GlobalizationCurrencyPatternEventArgs currencyPatternEventArgs = GetCurrencyPatternEventArgs(objEvent);
				if (mobjCurrencyPatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjCurrencyPatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, currencyPatternEventArgs);
				}
				break;
			}
			case "lst":
			{
				GlobalizationListEventArgs listEventArgs = GetListEventArgs(objEvent);
				if (mobjListSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
				{
					mobjListSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, listEventArgs);
				}
				break;
			}
			}
		}

		/// 
		/// Gets the date event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationDateEventArgs GetDateEventArgs(IEvent objEvent)
		{
			GlobalizationDateEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
			{
				string[] array = objEvent["ReturnValue"].Split(',');
				int.TryParse(array[6], out var result);
				objEventArgs = new GlobalizationDateEventArgs(new DateTime(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]), int.Parse(array[3]), int.Parse(array[4]), int.Parse(array[5]), result));
			}
			return objEventArgs;
		}

		/// 
		/// Gets the list event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationListEventArgs GetListEventArgs(IEvent objEvent)
		{
			GlobalizationListEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
			{
				string[] collection = objEvent["ReturnValue"].Split(',');
				objEventArgs = new GlobalizationListEventArgs(new List<object>(collection));
			}
			return objEventArgs;
		}

		/// 
		/// Gets the currency pattern event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationCurrencyPatternEventArgs GetCurrencyPatternEventArgs(IEvent objEvent)
		{
			GlobalizationCurrencyPatternEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				string strPattern = objEvent["pattern"];
				string strCode = objEvent["code"];
				string strFraction = objEvent["fraction"];
				string strRounding = objEvent["rounding"];
				string strDecimal = objEvent["decimal"];
				string strGrouping = objEvent["grouping"];
				objEventArgs = new GlobalizationCurrencyPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strCode);
			}
			return objEventArgs;
		}

		/// 
		/// Gets the number pattern event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationNumberPatternEventArgs GetNumberPatternEventArgs(IEvent objEvent)
		{
			GlobalizationNumberPatternEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				string strPattern = objEvent["pattern"];
				string strFraction = objEvent["fraction"];
				string strRounding = objEvent["rounding"];
				string strDecimal = objEvent["decimal"];
				string strGrouping = objEvent["grouping"];
				string strSymbol = objEvent["symbol"];
				string strPositive = objEvent["positive"];
				string strNegative = objEvent["negative"];
				objEventArgs = new GlobalizationNumberPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strSymbol, strPositive, strNegative);
			}
			return objEventArgs;
		}

		/// 
		/// Gets the date pattern event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationDatePatternEventArgs GetDatePatternEventArgs(IEvent objEvent)
		{
			GlobalizationDatePatternEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				string strPattern = objEvent["pattern"];
				string strTimezone = objEvent["timezone"];
				string strUtc_offset = objEvent["utc_offset"];
				string strDst_offset = objEvent["dst_offset"];
				objEventArgs = new GlobalizationDatePatternEventArgs(strPattern, strTimezone, strUtc_offset, strDst_offset);
			}
			return objEventArgs;
		}

		/// 
		/// Gets the general event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationEventArgs GetGeneralEventArgs(IEvent objEvent)
		{
			GlobalizationEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
			{
				objEventArgs = new GlobalizationEventArgs(objEvent["ReturnValue"]);
			}
			return objEventArgs;
		}

		/// 
		/// Gets the general event args.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private GlobalizationInfoEventArgs GetGlobalizationInfoEventArgs(IEvent objEvent)
		{
			GlobalizationInfoEventArgs objEventArgs = null;
			if (!DeviceEventArgs.TryGetError(objEvent, out objEventArgs))
			{
				objEventArgs = new GlobalizationInfoEventArgs(objEvent["PreferredLanguage"], objEvent["LocaleName"], objEvent["FirstDayOfWeek"]);
			}
			return objEventArgs;
		}
	}
}
