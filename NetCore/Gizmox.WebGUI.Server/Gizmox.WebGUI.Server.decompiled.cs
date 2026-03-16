using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Exceptions;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Server.Hosting.Providers;
using Gizmox.WebGUI.Server.Providers;
using Gizmox.WebGUI.Server.Resources;
using Gizmox.WebGUI.Server.Resources.Readers;
using ITimer = Gizmox.WebGUI.Common.Interfaces.ITimer;
using c8097136eb8ff7ad5cea315298ffd25c8 = System.Object;

namespace A
{
	internal class c572ceec0c50008c8ac659ffc23e7c9be
	{
		private static readonly Assembly c997f2da7fa1afa4f2930c6cd7c7242ff;

		static c572ceec0c50008c8ac659ffc23e7c9be()
		{
			if ((object)c997f2da7fa1afa4f2930c6cd7c7242ff != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = executingAssembly.GetName().Name;
			string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
			foreach (string text in manifestResourceNames)
			{
				if (name == text)
				{
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
					byte[] rawAssembly = c908eaefa54d6b5be30c4c863d79037e1.cc2ad4aa851b5f88a873f3f558265da16(manifestResourceStream);
					c997f2da7fa1afa4f2930c6cd7c7242ff = Assembly.Load(rawAssembly);
					break;
				}
			}
		}

		internal static void cf69d6ae76180683091290afddd654dd7()
		{
			AppDomain.CurrentDomain.ResourceResolve += c41bf83b2bda1a46b918b03de6cae6519;
		}

		private static Assembly c41bf83b2bda1a46b918b03de6cae6519(object cdfb56dcce46633c2dbd3f626b9642971, ResolveEventArgs c08cca9fce72772fe8e847fccce069851)
		{
			if ((object)c997f2da7fa1afa4f2930c6cd7c7242ff == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return c997f2da7fa1afa4f2930c6cd7c7242ff;
			}
			string[] manifestResourceNames = c997f2da7fa1afa4f2930c6cd7c7242ff.GetManifestResourceNames();
			foreach (string text in manifestResourceNames)
			{
				if (!(text == c08cca9fce72772fe8e847fccce069851.Name))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return c997f2da7fa1afa4f2930c6cd7c7242ff;
			}
			return null;
		}
	}
	internal class c1aa09394d9e776d366c1c429ca623754 : NameObjectCollectionBase, IApplication, INonSerializable, ICollection, IEnumerable
	{
		private HostApplicationState c93fd0f78c1c608397524e7be6fe19474;

		private int c55bfa65df757cfb294c5ff88a1faba92 = -1;

		private int c4a0ebb17332b8bf5b4947dd1ed6f7b28 = 180;

		public object this[string strName]
		{
			get
			{
				return BaseGet(strName);
			}
			set
			{
				BaseSet(strName, value);
			}
		}

		public object this[int intIndex] => BaseGet(intIndex);

		public c1aa09394d9e776d366c1c429ca623754(HostContext objHostContext)
		{
			c93fd0f78c1c608397524e7be6fe19474 = objHostContext.Application;
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	internal class BaseCollection : ICollection, IEnumerable
	{
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public virtual int Count => List.Count;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsReadOnly => false;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsSynchronized => false;

		protected virtual ArrayList List => null;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public object SyncRoot => this;

		public void CopyTo(Array ar, int index)
		{
			List.CopyTo(ar, index);
		}

		public IEnumerator GetEnumerator()
		{
			return List.GetEnumerator();
		}
	}
}
namespace A
{
	internal class c4d3cdb893b7f640a5aa2a40bfe2211b1 : HostHttpHandler, IRequiresSessionState
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		protected override bool SupportsGZip => true;

		public new bool IsReusable => false;

		internal Context Context => c8f695bda1002ddbedbc6a2bfcf6960a0;

		internal ISessionRegistry SessionRegistry => c8f695bda1002ddbedbc6a2bfcf6960a0;

		internal c4d3cdb893b7f640a5aa2a40bfe2211b1(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			if (!SerializableMember.TraceMode && !SkinFactory.TraceMode)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				_ = DateTime.Now.Ticks;
				SkinFactory.ResetTracing();
			}
			objHostContext.Response.Expires = -1;
			objHostContext.Response.CacheControl = "no-cache";
			objHostContext.Response.AddHeader("Pragma", "no-cache");
			objHostContext.Response.Cache.SetNoStore();
			bool flag = true;
			bool traceEnabled = CommonSwitches.TraceEnabled;
			IResponseWriter objXmlWriter = null;
			Global.Context = Context;
			bool flag2 = Context.ManagePendingTermination();
			try
			{
				Thread.CurrentThread.CurrentUICulture = Context.CurrentUICulture;
			}
			catch (Exception)
			{
			}
			IServerResponse serverResponse = (IServerResponse)Context.Response;
			IRequestParams requestParams = (IRequestParams)Context.Request;
			_ = Context.Session;
			ITimerHandlerContainer context = Context;
			long lngTimeMarker = 0L;
			int intNextInvokationTime = 0;
			try
			{
				if (string.IsNullOrEmpty(requestParams.WebSocketConnectionId))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IContextParams)Context).WebSocketConnectionId = requestParams.WebSocketConnectionId;
					Application.WebSockets.WebSocketInitialized();
				}
				if (!objHostContext.Session.IsNewSession)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Context.IsLoggedOn = false;
					Context.RefreshRequiered = true;
				}
				Context.RequestProcessingState = RequestProcessingState.InitiatingMainForm;
				IForm form = null;
				if (!Context.UseAuthentication)
				{
					/*OpCode not supported: LdMemberToken*/;
					form = GetMainForm(objHostContext);
				}
				else
				{
					form = ((!Context.IsLoggedOn) ? GetLogonForm() : GetMainForm(objHostContext));
				}
				bool blnFullResponse;
				if (form != null)
				{
					blnFullResponse = false;
					form.SetContext(Context);
					Context.RequestProcessingState = RequestProcessingState.ProcessEvents;
					Context.ProcessLoad(form, objHostContext);
					if (!flag2)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Context.FireApplicationThreadRefresh();
					}
					Context.FireApplicationThreadTick();
					if (!requestParams.IsPostback)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (form is ILogonForm)
						{
							if (!Context.IsLoggedOn)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								form = GetMainForm(objHostContext);
								Context.ProcessLoad(form, objHostContext);
							}
						}
						if (form.IsClosed)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!Context.IsTerminated)
						{
							goto IL_05a0;
						}
						if (Context.IsTransfered)
						{
							goto IL_05a0;
						}
						/*OpCode not supported: LdMemberToken*/;
						serverResponse.WriteClosed(ref objXmlWriter);
						((IContextTerminate)Context).Terminate(blnForce: true);
					}
					else
					{
						if (!traceEnabled)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							ProcessClientTracing(Context, (Request)requestParams);
						}
						if (requestParams.HasEvents)
						{
							IEventCollection events = requestParams.Events;
							while (events.Count > 0)
							{
								/*OpCode not supported: LdMemberToken*/;
								IEvent obj = events.Dequeue();
								lngTimeMarker = DateTime.Now.Ticks;
								try
								{
									UpdateContextModifierKeys(obj);
									UpdateContextCursorPosition(obj);
									Context.ProcessEvent(lngTimeMarker, obj);
								}
								catch (Exception objException)
								{
									Context.HandleApplicationException(objException, objHostContext);
								}
								finally
								{
									ClearContextModifierKeys();
									ClearContextCursorPosition();
								}
								ProcessKeepConnected(obj);
								if (!IsSessionAbandoned(objHostContext))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									Context.IsLoggedOn = false;
									Context.RefreshRequiered = true;
								}
								if (!Context.UseAuthentication)
								{
									continue;
								}
								if (Context.IsLoggedOn)
								{
									/*OpCode not supported: LdMemberToken*/;
									continue;
								}
								if (form is ILogonForm)
								{
									/*OpCode not supported: LdMemberToken*/;
									continue;
								}
								form = GetLogonForm();
								form.SetContext(Context);
								Context.ProcessLoad(form, objHostContext);
								blnFullResponse = true;
								break;
							}
							Context.FireApplicationIdle();
						}
						if (form is ILogonForm && Context.IsLoggedOn)
						{
							form = GetMainForm(objHostContext);
							Context.ProcessLoad(form, objHostContext);
							blnFullResponse = true;
						}
						if (form.IsClosed)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!Context.IsTerminated)
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_041e;
						}
						if (Context.IsTransfered)
						{
							goto IL_041e;
						}
						serverResponse.WriteClosed(ref objXmlWriter);
						((IContextTerminate)Context).Terminate(blnForce: true);
					}
					goto IL_0640;
				}
				objHostContext.Response.Write("WebGUI:Gen_ The URL does not have a registered form.");
				goto IL_065b;
				IL_05a0:
				if (!Context.RefreshRequiered)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (flag)
					{
						if (!context.HasTimers)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							intNextInvokationTime = context.InvokeTimers(DateTime.Now.Ticks);
						}
					}
					HandleResponse(ref objXmlWriter, serverResponse, requestParams, ref lngTimeMarker, intNextInvokationTime, form, blnFullResponse: true);
				}
				else
				{
					if (!Context.IsTransfered)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						SwitchToTransferedForm();
					}
					serverResponse.WriteRefresh(ref objXmlWriter);
				}
				goto IL_0640;
				IL_041e:
				if (!Context.RefreshRequiered)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!flag)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!context.HasTimers)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						intNextInvokationTime = context.InvokeTimers(DateTime.Now.Ticks);
					}
					if (!Context.IsTransfered)
					{
						/*OpCode not supported: LdMemberToken*/;
						HandleResponse(ref objXmlWriter, serverResponse, requestParams, ref lngTimeMarker, intNextInvokationTime, form, blnFullResponse);
					}
					else
					{
						SwitchToTransferedForm();
						if (!Context.RefreshRequiered)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							serverResponse.WriteRefresh(ref objXmlWriter);
						}
					}
				}
				else
				{
					if (!Context.IsTransfered)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						SwitchToTransferedForm();
					}
					serverResponse.WriteRefresh(ref objXmlWriter);
				}
				goto IL_0640;
				IL_065b:
				if (c371e0db5909d312669b7b89a30fa1396.SessionTracing.RegistrationSummaryTrace)
				{
					VerboseRecord.Write("Server", "Session/Registry", "Summary", $"{SessionRegistry.Count} registered components.", blnCondition: true);
					foreach (IRegisteredComponent item in SessionRegistry)
					{
						if (item == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (item.IsConnected)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (item is IForm)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							VerboseRecord.Write("Server", "Session/Registry", "Summary", $"{item.GetType().Name} floating component.", blnCondition: true);
						}
					}
				}
				Global.ClearRequestParams();
				goto end_IL_0103;
				IL_0640:
				form.ClearContext();
				goto IL_065b;
				end_IL_0103:;
			}
			catch (Exception ex2)
			{
				Global.ClearRequestParams();
				throw new HttpException(ex2.Message, ex2);
			}
			if (SerializableMember.TraceMode || SkinFactory.TraceMode)
			{
				_ = DateTime.Now.Ticks;
				SkinFactory.ResetTracing();
				IEnumerator enumerator2 = SerializableMember.RegisteredMembers.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						SerializableMember current = (SerializableMember)enumerator2.Current;
						_ = 0u | ((current.CallGetTime > 1.0) ? 1u : 0u) | ((current.CallSetTime > 1.0) ? 1u : 0u) | ((current.CallSetCount > 10000) ? 1u : 0u) | ((current.CallGetCount > 10000) ? 1u : 0u);
						current.ResetTracing();
					}
				}
				finally
				{
					if (enumerator2 is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
			Context.RequestProcessingState = RequestProcessingState.None;
		}

		private void ClearContextCursorPosition()
		{
			Context context = Context;
			if (context != null)
			{
				context.CursorPosition = Point.Empty;
			}
		}

		private void UpdateContextCursorPosition(IEvent objEvent)
		{
			Context context = Context;
			if (context != null)
			{
				context.CursorPosition = objEvent.CursorPosition;
			}
		}

		private void ClearContextModifierKeys()
		{
			Context context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				context.ModifierKeys = Keys.None;
			}
		}

		private void UpdateContextModifierKeys(IEvent objEvent)
		{
			if (Context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Keys keys = Keys.None;
			if (!objEvent.AltKey)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				keys |= Keys.Alt;
			}
			if (!objEvent.ControlKey)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				keys |= Keys.Control;
			}
			if (!objEvent.ShiftKey)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				keys |= Keys.Shift;
			}
			if (keys != Keys.None)
			{
				Context.ModifierKeys = keys;
			}
		}

		private void HandleResponse(ref IResponseWriter objResponseWriter, IServerResponse objResponse, IRequestParams objRequest, ref long lngTimeMarker, int intNextInvokationTime, IForm objMainForm, bool blnFullResponse)
		{
			if (!c371e0db5909d312669b7b89a30fa1396.EmulateSessionStateSerialization.Enabled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CommonUtils.TrySerialize(objMainForm);
			}
			Context context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Context.RequestProcessingState = RequestProcessingState.PreRenderResponse;
			objMainForm.PreRenderForm(context, objRequest.LastRender);
			long activeFormId = context.GetActiveFormId();
			objResponse.Start(DateTime.Now.Ticks, intNextInvokationTime, ref objResponseWriter, blnFullResponse, activeFormId);
			lngTimeMarker = DateTime.Now.Ticks;
			Context.RequestProcessingState = RequestProcessingState.RenderResponse;
			IContextParams context2 = Context;
			if (context2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (context2.ActiveProxyMasterPage == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				long num;
				if (blnFullResponse)
				{
					/*OpCode not supported: LdMemberToken*/;
					num = 0L;
				}
				else
				{
					num = objRequest.LastRender;
				}
				long lngRequestID = num;
				context2.ActiveProxyMasterPage.PreRender(context, lngRequestID);
				context2.ActiveProxyMasterPage.Render(context, objResponseWriter, lngRequestID);
				context2.ActiveProxyMasterPage.PostRender(context, lngRequestID);
			}
			objMainForm.RenderForm(context, objResponseWriter, blnFullResponse ? 0 : objRequest.LastRender);
			if (!(context.GetDeviceIntegratorInternal(blnCanBeNull: true) is IRenderableComponent renderableComponent))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IResponseWriter objWriter = objResponseWriter;
				long lngRequestID2;
				if (blnFullResponse)
				{
					/*OpCode not supported: LdMemberToken*/;
					lngRequestID2 = 0L;
				}
				else
				{
					lngRequestID2 = objRequest.LastRender;
				}
				renderableComponent.RenderComponent(context, objWriter, lngRequestID2);
			}
			Application.WebSockets.RenderComponent(context, objResponseWriter, blnFullResponse ? 0 : objRequest.LastRender);
			RenderClientContext(objResponseWriter, context, objRequest);
			TraceRecord.Write(new RenderTraceRecord(objMainForm, lngTimeMarker));
			objResponse.End(objResponseWriter);
			Context.RequestProcessingState = RequestProcessingState.PostRrenderResponse;
			objMainForm.PostRenderForm(context, objRequest.LastRender);
		}

		private void RenderClientContext(IResponseWriter objResponseWriter, IContext objContext, IRequestParams objRequest)
		{
			if (!(objContext is IClientContextProvider { ClientContext: var clientContext }))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (clientContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			_ = Context;
			clientContext.RenderMethodInvokes(objContext, objResponseWriter);
		}

		private void ProcessKeepConnected(IEvent objCriticalEvent)
		{
			if (objCriticalEvent == null)
			{
				return;
			}
			if (!Context.UseKeepConnectedLimitation)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!(objCriticalEvent.Type == "KeepConnected"))
			{
				/*OpCode not supported: LdMemberToken*/;
				Context.KeepConnectedCount = 0;
				return;
			}
			Context.KeepConnectedCount++;
			if (Context.KeepConnectedCount <= Context.KeepConnectedLimitation)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!((IApplicationContext)Context).HandleApplicationTimeout())
			{
				/*OpCode not supported: LdMemberToken*/;
				Context.Redirect($"Timeout{Context.CurrentExtension}");
			}
			else
			{
				Context.KeepConnectedCount = 0;
			}
		}

		private bool IsSessionAbandoned(HostContext objHostContext)
		{
			bool result = false;
			if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objHostContext.Session == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objHostContext.Session.SyncRoot == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(objHostContext.Session.SyncRoot is HttpSessionStateContainer))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = ((HttpSessionStateContainer)objHostContext.Session.SyncRoot).IsAbandoned;
			}
			return result;
		}

		private void SwitchToTransferedForm()
		{
			IForm transferForm = Context.TransferForm;
			if (Context != null)
			{
				if (Context.MainForm == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					IForm mainForm = Context.MainForm;
					Context.MainForm = null;
					mainForm.Dispose();
				}
			}
			Context.MainForm = transferForm;
			Context.ActiveForm = transferForm;
			transferForm.SetContext(Context);
		}

		private void ProcessClientTracing(Context objContext, Request objRequest)
		{
			string[] array = objRequest.ClientTrace.Split('|');
			for (int i = 0; i < array.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = array[i];
				if (!(text != string.Empty))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					TraceRecord.Write(new c4a194a1d5eede9f56caccd510597e467(text, objContext));
				}
			}
		}

		private IForm GetLogonForm()
		{
			IForm form = null;
			if (!(Context.MainForm is ILogonForm))
			{
				Context.SuspendedMainForm = Context.MainForm;
				Context.SuspendedActiveForm = Context.ActiveForm;
				Context.MainForm = null;
				Context.ActiveForm = null;
			}
			form = Context.MainForm;
			if (form != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				form = Context.CreateLogonForm();
				InitializeSSOLogonAuthentication(form);
				Context.MainForm = form;
				Context.ActiveForm = form;
			}
			return form;
		}

		private void InitializeSSOLogonAuthentication(IForm objLogonForm)
		{
			if (objLogonForm == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			IContextParams context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (context.SSOData == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Type type = objLogonForm.GetType();
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (type.GetCustomAttributes(typeof(SSOFormAttribute), inherit: true).Length != 1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				PropertyInfo[] properties = type.GetProperties();
				if (properties == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (properties.Length == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();
					PropertyInfo[] array = properties;
					for (int i = 0; i < array.Length; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						PropertyInfo propertyInfo = array[i];
						object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(SSOFieldAttribute), inherit: true);
						if (customAttributes == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (customAttributes.Length != 1)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (customAttributes[0] is SSOFieldAttribute sSOFieldAttribute)
						{
							dictionary.Add(sSOFieldAttribute.FieldName, propertyInfo);
						}
					}
					if (dictionary.Count <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						using Dictionary<string, PropertyInfo>.Enumerator enumerator = dictionary.GetEnumerator();
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							KeyValuePair<string, PropertyInfo> current = enumerator.Current;
							current.Value.SetValue(objLogonForm, context.SSOData[current.Key], new object[0]);
						}
					}
				}
			}
			context.SSOData = null;
		}

		public IForm GetMainForm(HostContext objHostContext)
		{
			IForm form = null;
			form = Context.MainForm;
			if (form == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (form is ILogonForm)
			{
				SessionRegistry.UnRegisterComponent(form);
				form = null;
				Context.MainForm = null;
				Context.ActiveForm = null;
				if (Context.SuspendedMainForm == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					IForm form2 = (Context.MainForm = Context.SuspendedMainForm);
					form = form2;
					Context.ActiveForm = Context.SuspendedActiveForm;
					Context.SuspendedMainForm = null;
					Context.SuspendedActiveForm = null;
				}
			}
			if (form != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				form = Context.CreateMainForm();
				Context.MainForm = form;
				Context.ActiveForm = form;
			}
			return form;
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	public class Context : Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext, IApplicationContext, IClientContextProvider, IContext, IContextClipboard, IContextMethodInvoker, IContextParams, IContextPipeline, IContextTerminate, IContextVariables, IDeviceRepository, IEventHandler, IFormResolver, INonSerializable, ISessionRegistry, ITimerHandlerContainer
	{
		private enum c94e3ea055e647d2e8639675f595ce66c
		{
			cbb6acf84f381b1c72e4bc37184f2046f,
			cc37c5ba9f1a83c753118cdbf42f0b64f
		}

		private HostContext mobjHostContext;

		private Request mobjRequest;

		private Response mobjResponse;

		private Session mobjSession;

		private c1aa09394d9e776d366c1c429ca623754 mobjApplication;

		private ICookies mobjCookies;

		private ContextContainer mobjContextContainer;

		private static string mstrLogonLocking;

		private bool mblnRefreshRequiered;

		private bool mblnIsTransfered;

		private string mstrCapture = string.Empty;

		private static IServer mobjServer;

		private IForm mobjTransferForm;

		private HostRequestInfo mobjRequestInfo;

		private CultureInfo mobjCurrentUICulture;

		private ArrayList mobjCommands;

		private ClientContext mobjClientContext;

		private Hashtable mobjCommandsHash;

		private bool? mblnRightToLeft;

		private bool? mblnShouldApplyMirroring;

		private static bool mblnUseKeepConnectedLimitation;

		private static int mintKeepConnectedLimitation;

		private static bool mblnUseGZipCompression;

		private static c94e3ea055e647d2e8639675f595ce66c menmDesignTimeDirection;

		private static bool mblnAllowMirroring;

		protected static readonly string mstrDynamicExtension;

		private EventProcessor mobjEventProcessor;

		private ContextContainer CurrentContainer
		{
			get
			{
				if (mobjContextContainer == null)
				{
					EnsureSession();
					if (mobjSession == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!mobjSession.IsValid)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjContextContainer = mobjSession.GetContextContainer(CurrentPage, CurrentPageInstance);
					}
				}
				return mobjContextContainer;
			}
		}

		public bool IsPngSupport => (((IContextParams)this).MISCBrowserCapabilities & MISCBrowserCapabilities.PngSupport) == MISCBrowserCapabilities.PngSupport;

		private ContextContainer CurrentWorkingContainer
		{
			get
			{
				if (mobjContextContainer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjContextContainer = ((Session)Session).GetContextContainer(CurrentPage, CurrentPageInstance, blnCreateIfNotFound: false);
				}
				return mobjContextContainer;
			}
		}

		private IApplicationContext ApplicationContext => CurrentContainer;

		Config IContext.Config => HostRuntime.Config;

		IDeviceIntegrator IContext.DeviceIntegrator => GetDeviceIntegratorInternal(blnCanBeNull: false);

		public IRequest Request
		{
			get
			{
				if (mobjRequest == null)
				{
					mobjRequest = new Request(mobjHostContext, this, mobjRequestInfo);
				}
				return mobjRequest;
			}
		}

		public IServer Server
		{
			get
			{
				if (mobjServer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjServer = new c173574dfe7801dce5957ec1ae08dfabb(mobjHostContext);
				}
				return mobjServer;
			}
		}

		public IResponse Response
		{
			get
			{
				if (mobjResponse == null)
				{
					mobjResponse = new Response(mobjHostContext, this);
				}
				return mobjResponse;
			}
		}

		public ICookies Cookies
		{
			get
			{
				if (mobjCookies == null)
				{
					mobjCookies = new Cookies(mobjHostContext, mobjRequestInfo);
				}
				return mobjCookies;
			}
		}

		public IApplication Application
		{
			get
			{
				if (mobjApplication != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjApplication = mobjHostContext.Application["WGApplication"] as c1aa09394d9e776d366c1c429ca623754;
					if (mobjApplication != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjHostContext.Application["WGApplication"] = (mobjApplication = new c1aa09394d9e776d366c1c429ca623754(mobjHostContext));
					}
				}
				return mobjApplication;
			}
		}

		public HttpContext HttpContext => mobjHostContext.HttpContext;

		public HostContext HostContext => mobjHostContext;

		public Gizmox.WebGUI.Common.Interfaces.ISession Session
		{
			get
			{
				EnsureSession();
				return mobjSession;
			}
		}

		public bool IsStatelessApplication => mobjRequestInfo.IsStatelessApplicationOrRequest;

		public bool IsLoggedOn
		{
			get
			{
				EnsureSession();
				if (mobjSession == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mobjSession.IsValid)
				{
					if (mobjSession.IsLoggedOn)
					{
						return true;
					}
					if (CurrentContainer == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						return false;
					}
					return CurrentContainer.IsLoggedOn;
				}
				return false;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.IsLoggedOn = value;
				}
			}
		}

		internal int KeepConnectedCount
		{
			get
			{
				if (CurrentContainer != null)
				{
					return CurrentContainer.KeepConnectedCount;
				}
				return 0;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.KeepConnectedCount = value;
				}
			}
		}

		public IForm ActiveForm
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.ActiveForm;
			}
			set
			{
				if (value != null && !value.TopLevel)
				{
					return;
				}
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				CurrentContainer.ActiveForm = value;
				if (CurrentContainer.MainForm != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.MainForm = value;
				}
				if (EmulationService == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					EmulationService.OnActiveFormSet();
				}
			}
		}

		internal IEmulationService EmulationService
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.EmulationService;
			}
		}

		public IForm SuspendedActiveForm
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.SuspendedActiveForm;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.SuspendedActiveForm = value;
				}
			}
		}

		internal bool IsRedirectToSSLRequired => mobjRequestInfo.IsRedirectToSSLRequired;

		public IForm MainForm
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.MainForm;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.MainForm = value;
				}
			}
		}

		public IForm SuspendedMainForm
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.SuspendedMainForm;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.SuspendedMainForm = value;
				}
			}
		}

		internal IForm TransferForm => mobjTransferForm;

		public string Referrer
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.Referrer;
			}
			set
			{
				if (CurrentContainer != null)
				{
					CurrentContainer.Referrer = value;
				}
			}
		}

		internal string RedirectToUrl
		{
			get
			{
				if (mobjContextContainer == null)
				{
					return string.Empty;
				}
				return mobjContextContainer.RedirectToUrl;
			}
		}

		internal bool IsTerminated
		{
			get
			{
				if (CurrentWorkingContainer == null)
				{
					return false;
				}
				return CurrentWorkingContainer.IsTerminated;
			}
		}

		internal bool IsTransfered => mblnIsTransfered;

		public ArrayList Commands
		{
			get
			{
				if (mobjCommands != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjCommands = new ArrayList();
				}
				return mobjCommands;
			}
		}

		public Hashtable CommandsHash
		{
			get
			{
				if (mobjCommandsHash == null)
				{
					mobjCommandsHash = new Hashtable();
				}
				return mobjCommandsHash;
			}
		}

		internal ArrayList CommandsInternal => Commands;

		public CultureInfo CurrentUICulture
		{
			get
			{
				if (mobjCurrentUICulture != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					EnsureSession();
					if (mobjSession == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mobjSession.IsValid)
					{
						mobjCurrentUICulture = mobjSession.CurrentUICulture;
						goto IL_0089;
					}
					if (string.IsNullOrEmpty(mobjRequestInfo.CultureDirectory))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mobjCurrentUICulture = new CultureInfo(mobjRequestInfo.CultureDirectory);
					}
				}
				goto IL_0089;
				IL_0089:
				return mobjCurrentUICulture;
			}
			set
			{
				if (value == null)
				{
					return;
				}
				mblnRightToLeft = null;
				mblnShouldApplyMirroring = null;
				EnsureSession();
				if (mobjSession != null)
				{
					CultureInfo currentUICulture = CurrentUICulture;
					mobjSession.CurrentUICulture = value;
					if (currentUICulture == value)
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
					mblnRefreshRequiered = true;
					mobjCurrentUICulture = value;
					mobjRequestInfo.CultureDirectory = value.Name;
				}
			}
		}

		public RequestProcessingState RequestProcessingState
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return RequestProcessingState.None;
				}
				return CurrentContainer.RequestProcessingState;
			}
			internal set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.RequestProcessingState = value;
				}
			}
		}

		public string CurrentTheme
		{
			get
			{
				if (!string.IsNullOrEmpty(mobjRequestInfo.ThemeDirectory))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					HostRequestInfo hostRequestInfo = mobjRequestInfo;
					string themeDirectory;
					if (CurrentPage == WGConst.AdministrationPage)
					{
						/*OpCode not supported: LdMemberToken*/;
						themeDirectory = ConfigHelper.Administration.Theme;
					}
					else
					{
						themeDirectory = HostRuntime.Config.DefaultTheme;
					}
					hostRequestInfo.ThemeDirectory = themeDirectory;
				}
				else
				{
					mobjRequestInfo.ThemeDirectory = CurrentContainer.CurrentTheme;
				}
				return mobjRequestInfo.ThemeDirectory;
			}
			set
			{
				if (!(CurrentPage != WGConst.AdministrationPage))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				object obj;
				if (string.IsNullOrEmpty(value))
				{
					/*OpCode not supported: LdMemberToken*/;
					obj = "Default";
				}
				else
				{
					obj = value;
				}
				string text = (string)obj;
				if (!(mobjRequestInfo.ThemeDirectory != text))
				{
					return;
				}
				bool flag = false;
				string[] themes = HostRuntime.Config.Themes;
				for (int i = 0; i < themes.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text2 = themes[i];
					if (!(text.ToLowerInvariant() == text2.ToLowerInvariant()))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					mobjRequestInfo.ThemeDirectory = text2;
					flag = true;
					mblnRefreshRequiered = true;
					if (CurrentContainer == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						CurrentContainer.CurrentTheme = mobjRequestInfo.ThemeDirectory;
					}
					break;
				}
				if (flag)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				throw new ArgumentException($"Cannot find '{text}' in registed themes.", "value");
			}
		}

		public bool SupportsMultipleThemes
		{
			get
			{
				if (AvailableThemes.Count > 1)
				{
					return true;
				}
				if (AvailableThemes.Count != 1)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return AvailableThemes[0] != Config.GetInstance().DefaultTheme;
			}
		}

		public ReadOnlyCollection<string> AvailableThemes
		{
			get
			{
				if (CurrentContainer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return CurrentContainer.AvailableThemes;
				}
				return mobjRequestInfo.AvailableThemes;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				CurrentContainer.AvailableThemes = value;
				mblnRefreshRequiered = true;
			}
		}

		public bool FullScreenMode
		{
			get
			{
				ContextContainer currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					return mobjRequestInfo.FullScreenMode = currentContainer.FullScreenMode;
				}
				return mobjRequestInfo.FullScreenMode;
			}
			set
			{
				ContextContainer currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (currentContainer.FullScreenMode != value)
				{
					mobjRequestInfo.FullScreenMode = value;
					currentContainer.FullScreenMode = value;
					mblnRefreshRequiered = true;
				}
			}
		}

		internal bool RefreshRequiered
		{
			get
			{
				return mblnRefreshRequiered;
			}
			set
			{
				mblnRefreshRequiered = value;
			}
		}

		internal string AuthenticationFormType => mobjRequestInfo.AuthenticationFormType;

		internal string CurrentPageName
		{
			get
			{
				string text = CurrentPage;
				string[] array = text.Split('~');
				if (array.Length != 0)
				{
					text = array[array.Length - 1];
				}
				return $"{text}{CurrentExtension}";
			}
		}

		protected virtual string CurrentPage => ((IRequestParams)Request).Page;

		protected virtual string CurrentPageInstance => ((IRequestParams)Request).PageInstance;

		public ExecutionMode ExecutionMode => ExecutionMode.Web;

		public bool RightToLeft
		{
			get
			{
				if (mblnRightToLeft.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mblnRightToLeft = IsRightToLeftCulture(CurrentUICulture);
				}
				return mblnRightToLeft.Value;
			}
		}

		public bool ShouldApplyMirroring
		{
			get
			{
				if (mblnShouldApplyMirroring.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mblnAllowMirroring)
				{
					if (menmDesignTimeDirection == c94e3ea055e647d2e8639675f595ce66c.cc37c5ba9f1a83c753118cdbf42f0b64f)
					{
						mblnShouldApplyMirroring = RightToLeft;
					}
					else
					{
						mblnShouldApplyMirroring = !RightToLeft;
					}
				}
				else
				{
					mblnShouldApplyMirroring = false;
				}
				return mblnShouldApplyMirroring.Value;
			}
		}

		internal bool UseAuthentication => mobjRequestInfo.UseAuthentication;

		internal static bool UseGZipCompression => mblnUseGZipCompression;

		internal static bool UseKeepConnectedLimitation => mblnUseKeepConnectedLimitation;

		internal static int KeepConnectedLimitation => mintKeepConnectedLimitation;

		internal virtual string CurrentExtension => mstrDynamicExtension;

		internal static SessionStateMode SessionStateMode
		{
			get
			{
				SessionStateMode result = SessionStateMode.InProc;
				try
				{
					if (!(ConfigurationManager.GetSection("system.web/sessionState") is SessionStateSection sessionStateSection))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = sessionStateSection.Mode;
					}
				}
				catch (SecurityException)
				{
				}
				return result;
			}
		}

		public object this[string strKey]
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer[strKey];
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer[strKey] = value;
				}
			}
		}

		public NameValueCollection Arguments
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.Arguments;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.Arguments = value;
				}
			}
		}

		public NameValueCollection Results
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				NameValueCollection nameValueCollection = CurrentContainer.Results;
				if (nameValueCollection != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					NameValueCollection nameValueCollection2 = (CurrentContainer.Results = new ResultsProvider());
					nameValueCollection = nameValueCollection2;
				}
				return nameValueCollection;
			}
		}

		ITimerHandler ITimerHandlerContainer.Timers
		{
			get
			{
				ContextContainer currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return currentContainer.Timers;
			}
		}

		bool ITimerHandlerContainer.HasTimers
		{
			get
			{
				ContextContainer currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return currentContainer.HasTimers;
			}
		}

		private IContextClipboard ContextClipboard => CurrentContainer;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public NameValueCollection SSOData
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return ((IContextParams)CurrentContainer).SSOData;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IContextParams)CurrentContainer).SSOData = value;
				}
			}
		}

		long IContextParams.LastRender
		{
			get
			{
				if (mobjRequest != null)
				{
					return mobjRequest.LastRender;
				}
				return 0L;
			}
		}

		internal Keys ModifierKeys
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return Keys.None;
				}
				return CurrentContainer.ModifierKeys;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.ModifierKeys = value;
				}
			}
		}

		public Point CursorPosition
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return Point.Empty;
				}
				return CurrentContainer.CursorPosition;
			}
			set
			{
				if (CurrentContainer != null)
				{
					CurrentContainer.CursorPosition = value;
				}
			}
		}

		public virtual Presentation Presentation => Presentation.Browser;

		public virtual PresentationEngine PresentationEngine
		{
			get
			{
				switch (mobjRequestInfo.BrowserDirectory)
				{
				case "ie":
					/*OpCode not supported: LdMemberToken*/;
					return PresentationEngine.InternetExplorer;
				case "kit":
					/*OpCode not supported: LdMemberToken*/;
					return PresentationEngine.WebKit;
				case "moz":
					return PresentationEngine.Mozilla;
				case "opr":
					return PresentationEngine.Opera;
				default:
					return PresentationEngine.Agnostic;
				}
			}
		}

		Keys IContextParams.ModifierKeys
		{
			get
			{
				return ModifierKeys;
			}
			set
			{
				ModifierKeys = value;
			}
		}

		string IContextParams.Browser => mobjRequestInfo.BrowserDirectory;

		DeviceOrientation IContextParams.StartupDeviceOrientation => ((IContextParams)CurrentContainer).StartupDeviceOrientation;

		int IContextParams.ScreenAvailableHeight => ((IContextParams)CurrentContainer).ScreenAvailableHeight;

		int IContextParams.ScreenAvailableWidth => ((IContextParams)CurrentContainer).ScreenAvailableWidth;

		int IContextParams.ScreenHeight
		{
			get
			{
				return ((IContextParams)CurrentContainer).ScreenHeight;
			}
			set
			{
				((IContextParams)CurrentContainer).ScreenHeight = value;
			}
		}

		int IContextParams.ScreenWidth
		{
			get
			{
				return ((IContextParams)CurrentContainer).ScreenWidth;
			}
			set
			{
				((IContextParams)CurrentContainer).ScreenWidth = value;
			}
		}

		int IContextParams.ScreenDevicePixelRatio => ((IContextParams)CurrentContainer).ScreenDevicePixelRatio;

		int IContextParams.ScreenColorDepth => ((IContextParams)CurrentContainer).ScreenColorDepth;

		string[] IContextParams.PreloadedResources => ((IContextParams)CurrentContainer).PreloadedResources;

		Graphics IContextParams.MeasurementGraphics => ((IContextParams)CurrentContainer).MeasurementGraphics;

		CSS3BrowserCapabilities IContextParams.CSS3BrowserCapabilities
		{
			get
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (mobjRequestInfo == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						return CSS3BrowserCapabilities.Empty;
					}
					return mobjRequestInfo.CSS3BrowserCapabilities;
				}
				return currentContainer.CSS3BrowserCapabilities;
			}
			set
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					currentContainer.CSS3BrowserCapabilities = value;
				}
			}
		}

		HTML5BrowserCapabilities IContextParams.HTML5BrowserCapabilities
		{
			get
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (mobjRequestInfo == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						return HTML5BrowserCapabilities.Empty;
					}
					return mobjRequestInfo.HTML5BrowserCapabilities;
				}
				return currentContainer.HTML5BrowserCapabilities;
			}
			set
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					currentContainer.HTML5BrowserCapabilities = value;
				}
			}
		}

		MISCBrowserCapabilities IContextParams.MISCBrowserCapabilities
		{
			get
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (mobjRequestInfo == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						return MISCBrowserCapabilities.Empty;
					}
					return mobjRequestInfo.MISCBrowserCapabilities;
				}
				return currentContainer.MISCBrowserCapabilities;
			}
			set
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					currentContainer.MISCBrowserCapabilities = value;
				}
			}
		}

		string IContextParams.BrowserId => ((IContextParams)CurrentContainer).BrowserId;

		IEmulatorForm IContextParams.EmulatorForm
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.EmulatorForm;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.EmulatorForm = value;
				}
			}
		}

		string IContextParams.CurrentPageName
		{
			get
			{
				if (mobjRequestInfo == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return mobjRequestInfo.PageName;
			}
		}

		ICollection<string> IContextParams.SystemPages
		{
			get
			{
				return null;
			}
		}

		IEmulationDevice IContextParams.EmulationDevice
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.EmulationDevice;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.EmulationDevice = value;
				}
			}
		}

		IProxyMasterPage IContextParams.ActiveProxyMasterPage
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.ActiveProxyMasterPage;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.ActiveProxyMasterPage = value;
				}
			}
		}

		Dictionary<string, IProxyMasterPage> IContextParams.NameProxyMasterPageMap
		{
			get
			{
				if (CurrentContainer != null)
				{
					return CurrentContainer.NameProxyMasterPageMap;
				}
				return null;
			}
		}

		IForm IContextParams.ContextualToolbar
		{
			get
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return currentContainer.ContextualToolbar;
			}
			set
			{
				IContextParams currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					currentContainer.ContextualToolbar = value;
				}
			}
		}

		private ISessionRegistry SessionRegistry
		{
			get
			{
				ContextContainer result = CurrentContainer ?? throw new Exception("Could not access component registry.");
				/*OpCode not supported: LdMemberToken*/;
				return result;
			}
		}

		int ISessionRegistry.Count => SessionRegistry.Count;

		ClientContext IClientContextProvider.ClientContext
		{
			get
			{
				if (mobjClientContext == null)
				{
					mobjClientContext = new ClientContext();
				}
				return mobjClientContext;
			}
		}

		int Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext.ScreenHeight => ((IContextParams)this).ScreenHeight;

		int Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext.ScreenWidth => ((IContextParams)this).ScreenWidth;

		int Gizmox.WebGUI.Common.Interfaces.Device.IDeviceContext.ScreenDevicePixelRatio => ((IContextParams)this).ScreenDevicePixelRatio;

		IForm[] IFormResolver.AccessibleForms
		{
			get
			{
				ContextContainer currentContainer = CurrentContainer;
				if (currentContainer != null)
				{
					return currentContainer.AccessibleForms;
				}
				return new IForm[0];
			}
		}

		string IContextParams.WebSocketConnectionId
		{
			get
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return CurrentContainer.WebSocketConnectionId;
			}
			set
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.WebSocketConnectionId = value;
				}
			}
		}

		public WebSocketService WebSocketService
		{
			get
			{
				return CurrentContainer.WebSocketService;
			}
			set
			{
			}
		}

		event ComponentMessageEventHandler IContext.ComponentMessage
		{
			add
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.ComponentMessage += value;
				}
			}
			remove
			{
				if (CurrentContainer == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CurrentContainer.ComponentMessage -= value;
				}
			}
		}

		event Gizmox.WebGUI.Forms.ThreadExceptionEventHandler IApplicationContext.ThreadException
		{
			add
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadException += value;
				}
			}
			remove
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadException -= value;
				}
			}
		}

		event EventHandler IApplicationContext.ThreadRefresh
		{
			add
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadRefresh += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadRefresh -= value;
				}
			}
		}

		event EventHandler IApplicationContext.ThreadTick
		{
			add
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadTick += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadTick -= value;
				}
			}
		}

		event EventHandler IApplicationContext.ThreadSuspend
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadSuspend += value;
				}
			}
			remove
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadSuspend -= value;
				}
			}
		}

		event ThreadMessageEventHandler IApplicationContext.ThreadMessage
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadMessage += value;
				}
			}
			remove
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadMessage -= value;
				}
			}
		}

		event CancelEventHandler IApplicationContext.BeforeApplicationTimeout
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.BeforeApplicationTimeout += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.BeforeApplicationTimeout -= value;
				}
			}
		}

		event ThreadBookmarkEventHandler IApplicationContext.ThreadBookmarkNavigate
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadBookmarkNavigate += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadBookmarkNavigate -= value;
				}
			}
		}

		event EventHandler IApplicationContext.ApplicationExit
		{
			add
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ApplicationExit += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ApplicationExit -= value;
				}
			}
		}

		event EventHandler IApplicationContext.EnterThreadModal
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.EnterThreadModal += value;
				}
			}
			remove
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.EnterThreadModal -= value;
				}
			}
		}

		event EventHandler IApplicationContext.Idle
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.Idle += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.Idle -= value;
				}
			}
		}

		event EventHandler IApplicationContext.LeaveThreadModal
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.LeaveThreadModal += value;
				}
			}
			remove
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.LeaveThreadModal -= value;
				}
			}
		}

		event EventHandler IApplicationContext.ThreadExit
		{
			add
			{
				if (ApplicationContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ApplicationContext.ThreadExit += value;
				}
			}
			remove
			{
				if (ApplicationContext != null)
				{
					ApplicationContext.ThreadExit -= value;
				}
			}
		}

		static Context()
		{
			mstrLogonLocking = "LogonLocking";
			mobjServer = null;
			mblnUseKeepConnectedLimitation = false;
			mintKeepConnectedLimitation = 0;
			mblnUseGZipCompression = false;
			menmDesignTimeDirection = c94e3ea055e647d2e8639675f595ce66c.cc37c5ba9f1a83c753118cdbf42f0b64f;
			mblnAllowMirroring = true;
			mstrDynamicExtension = string.Empty;
			mintKeepConnectedLimitation = HostRuntime.Config.GetFeatureValue("KeepConnectedLimitation", 0);
			mblnUseKeepConnectedLimitation = mintKeepConnectedLimitation > 0;
			mblnUseGZipCompression = HostRuntime.Config.GetFeatureValue("GZipCompression", blnDefault: false);
			string featureValue = HostRuntime.Config.GetFeatureValue("DesignTimeDirection", string.Empty);
			if (!string.IsNullOrEmpty(featureValue) && string.Equals(featureValue, "RightToLeft", StringComparison.InvariantCultureIgnoreCase))
			{
				menmDesignTimeDirection = c94e3ea055e647d2e8639675f595ce66c.cbb6acf84f381b1c72e4bc37184f2046f;
			}
			mblnAllowMirroring = HostRuntime.Config.IsFeatureEnabled("AllowMirroring", true);
			mstrDynamicExtension = HostRuntime.Config.DynamicExtension;
		}

		public Context(HostContext objHostContext)
		{
			mobjHostContext = objHostContext;
			mobjRequestInfo = objHostContext.Request.Info;
		}

		internal void LoadInitializationData(NameValueCollection objData)
		{
			MainForm = null;
			mobjContextContainer.CurrentTheme = null;
			CurrentContainer.LoadInitializationData(objData);
		}

		internal void LoadBrowserId()
		{
			if (((IContextParams)this).BrowserId != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentContainer.LoadBrowserId();
			}
		}

		internal void LoadServerSideBrowserCapabilities(HostContext objHostContext)
		{
			((IContextParams)this).MISCBrowserCapabilities |= MISCBrowserCapabilities.PngSupport;
			if (!HostRuntime.Config.GetFeatureValue("PngSupport", blnDefault: true))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(objHostContext.Request.Browser.Browser == "IE"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objHostContext.Request.Browser.MajorVersion < 7)
			{
				((IContextParams)this).MISCBrowserCapabilities -= 256;
			}
		}

		internal IDeviceIntegrator GetDeviceIntegratorInternal(bool blnCanBeNull)
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			if (CurrentContainer.DeviceIntegrator != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentContainer.DeviceIntegrator = CommonUtils.GetProvider<IDeviceIntegrator>("Gizmox.WebGUI.Forms.DeviceIntegration.DeviceIntegrator, Gizmox.WebGUI.Forms", blnIsCache: false, blnCanBeNull);
			}
			return CurrentContainer.DeviceIntegrator;
		}

		private void EnsureSession()
		{
			if (mobjSession != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjSession = new Session(mobjHostContext);
			}
		}

		public void OpenLink(ILink objLink)
		{
			OpenLink(objLink, null);
		}

		public void OpenLink(ILink objLink, ILinkParameters objLinkParameters)
		{
			if (!(objLink is IFormLink formLink))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IRouter router = ce7877c7ee4c3060c535e119111a8c060.GetRouter();
				if (router == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (formLink.FormApplication != null)
				{
					NameValueCollection arguments = router.GetArguments(formLink.FormApplication, formLink.FormInstance);
					if (arguments == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string[] names = objLinkParameters.QueryString.Names;
						for (int i = 0; i < names.Length; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							string name = names[i];
							arguments[name] = objLinkParameters.QueryString[name];
						}
						names = objLinkParameters.Form.Names;
						foreach (string name2 in names)
						{
							arguments[name2] = objLinkParameters.Form[name2];
						}
					}
				}
				objLinkParameters.QueryString.Clear();
				objLinkParameters.Form.Clear();
				objLinkParameters.QueryString["vwginstance"] = formLink.FormInstance;
			}
			((IContextMethodInvoker)this).InvokeMethod((ISkinable)null, InvokationUniqueness.None, "Forms_OpenLink", new object[5]
			{
				GetLinkUrl(objLink, objLinkParameters),
				GetLinkTarget(objLinkParameters),
				GetOpenLinkArguments(objLinkParameters),
				(objLinkParameters != null) ? GetLinkQueryString(objLinkParameters.Form) : "",
				GetOpenLinkMode(objLinkParameters)
			});
		}

		private string GetLinkUrl(ILink objLink, ILinkParameters objLinkParameters)
		{
			string url = objLink.Url;
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.QueryString.Count > 0)
			{
				if (url.IndexOf("?") > 0)
				{
					return $"{url}&{GetLinkQueryString(objLinkParameters.QueryString)}";
				}
				return $"{url}?{GetLinkQueryString(objLinkParameters.QueryString)}";
			}
			return url;
		}

		private string GetLinkQueryString(ILinkArguments objLinkArguments)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] names = objLinkArguments.Names;
			for (int i = 0; i < names.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = names[i];
				if (stringBuilder.Length <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append("&");
				}
				stringBuilder.AppendFormat("{0}={1}", text, HttpUtility.UrlEncode(objLinkArguments[text]));
			}
			return stringBuilder.ToString();
		}

		private string GetLinkTarget(ILinkParameters objLinkParameters)
		{
			if (objLinkParameters != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return objLinkParameters.Target;
			}
			return "_blank";
		}

		private string GetOpenLinkArguments(ILinkParameters objLinkParameters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.Size != Size.Empty)
			{
				stringBuilder.AppendFormat("height={0},", objLinkParameters.Size.Height);
				stringBuilder.AppendFormat("width={0},", objLinkParameters.Size.Width);
			}
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.Location != Point.Empty)
			{
				stringBuilder.AppendFormat("top={0},", objLinkParameters.Location.Y);
				stringBuilder.AppendFormat("left={0},", objLinkParameters.Location.X);
			}
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.Resizable)
			{
				stringBuilder.Append("resizable=yes,");
				goto IL_0107;
			}
			stringBuilder.Append("resizable=no,");
			goto IL_0107;
			IL_01f1:
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.ShowTitleBar)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append("titlebar=yes,");
				goto IL_0230;
			}
			stringBuilder.Append("titlebar=no,");
			goto IL_0230;
			IL_013c:
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.ShowMenuBar)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append("menubar=yes,");
				goto IL_0179;
			}
			stringBuilder.Append("menubar=no,");
			goto IL_0179;
			IL_0179:
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!objLinkParameters.ScrollBars)
				{
					stringBuilder.Append("scrollbars=no,");
					goto IL_01b6;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			stringBuilder.Append("scrollbars=yes,");
			goto IL_01b6;
			IL_0230:
			if (objLinkParameters != null)
			{
				if (!objLinkParameters.FullScreen)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append("fullscreen=yes,");
				}
			}
			return stringBuilder.ToString().Trim(',');
			IL_0107:
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.ShowLocationBar)
			{
				stringBuilder.Append("location=yes,");
				goto IL_013c;
			}
			stringBuilder.Append("location=no,");
			goto IL_013c;
			IL_01b6:
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objLinkParameters.ShowStatusBar)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append("status=yes,");
				goto IL_01f1;
			}
			stringBuilder.Append("status=no,");
			goto IL_01f1;
		}

		private string GetOpenLinkMode(ILinkParameters objLinkParameters)
		{
			if (objLinkParameters == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return LinkWindowStyle.Normal.ToString();
			}
			return objLinkParameters.WindowStyle.ToString();
		}

		internal void FireApplicationThreadRefresh()
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentContainer.FireApplicationThreadRefresh();
			}
		}

		internal void FireApplicationThreadTick()
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentContainer.FireApplicationThreadTick();
			}
		}

		internal void FireApplicationIdle()
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentContainer.FireApplicationIdle();
			}
		}

		public void Redirect(string strUrl)
		{
			CurrentContainer.RedirectToUrl = strUrl;
			((IContextTerminate)this).Terminate(blnForce: false);
		}

		public void Transfer(IForm objForm)
		{
			MainForm.Close();
			if (!MainForm.IsClosed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mobjTransferForm = objForm;
			mblnRefreshRequiered = true;
			mblnIsTransfered = true;
		}

		public void Terminate(bool blnLogOff)
		{
			((IContextTerminate)this).Terminate(blnForce: false);
			if (!blnLogOff)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IsLoggedOn = false;
			}
		}

		public virtual string GetContextVariable(string strVariableName)
		{
			uint num = c03836b967832c5af40c98cf7300bc21d.ComputeStringHash(strVariableName);
			if (num > 2032329808)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num <= 2949015487u)
				{
					if (num <= 2323123755u)
					{
						if (num > 2158644945u)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num)
							{
							case 2174507497u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "PreserveFocusElement"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								if (HostRuntime.Config.PreserveFocusElement)
								{
									/*OpCode not supported: LdMemberToken*/;
									return "1";
								}
								return "0";
							case 2323123755u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "PositioningDirection"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								if (ShouldApplyMirroring)
								{
									/*OpCode not supported: LdMemberToken*/;
									return "RTL";
								}
								return "LTR";
							case 2173968609u:
								if (!(strVariableName == "MISCBrowserCapabilities"))
								{
									break;
								}
								return Convert.ToInt32(mobjRequestInfo.MISCBrowserCapabilities).ToString();
							}
						}
						else
						{
							switch (num)
							{
							case 2158223625u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "ApplicationTitle"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetApplicationTitle();
							case 2158644945u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "PageInstance"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetEncodedPageInstance(mobjRequestInfo.PageInstance);
							}
						}
					}
					else if (num > 2841983297u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 2879437274u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "CurrentPageName"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							if (HostRuntime.Config.ForcePageInstance)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (!mobjRequestInfo.PageInstanceWasGiven)
							{
								/*OpCode not supported: LdMemberToken*/;
								return CurrentPageName;
							}
							return $"{CurrentPageName}?vwginstance={mobjRequestInfo.PageInstance}";
						case 2937241461u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "BrowserIE"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							if (!GetIsBroweserIE())
							{
								return "0";
							}
							return "1";
						case 2949015487u:
							if (!(strVariableName == "HTML5BrowserCapabilities"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return Convert.ToInt32(mobjRequestInfo.HTML5BrowserCapabilities).ToString();
						}
					}
					else
					{
						switch (num)
						{
						case 2591284123u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "Language"))
							{
								break;
							}
							return CurrentUICulture.TwoLetterISOLanguageName;
						case 2841983297u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "ApplicationMetaTags"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetApplicationMetadataTags();
						case 2457286800u:
							if (!(strVariableName == "Left"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							if (RightToLeft)
							{
								/*OpCode not supported: LdMemberToken*/;
								return "right";
							}
							return "left";
						}
					}
				}
				else if (num > 3156395988u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 3737991432u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 3805978556u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "GeolocationTimeout"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return ConfigHelper.DeviceIntegrationInfo.GeolocationTimeout.ToString();
						case 3963473495u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "CompassFrequency"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return ConfigHelper.DeviceIntegrationInfo.CompassFrequency.ToString();
						case 4174238223u:
						{
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "ThousandsSeparator"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							string result = ",";
							if (CurrentUICulture != null)
							{
								result = CurrentUICulture.NumberFormat.NumberGroupSeparator;
							}
							return result;
						}
						}
					}
					else
					{
						switch (num)
						{
						case 3238436216u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "EnableClientShortcuts"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							if (!c371e0db5909d312669b7b89a30fa1396.EnableClientShortcuts.Enabled)
							{
								return "0";
							}
							return "1";
						case 3627352105u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "AccelerationFrequency"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return ConfigHelper.DeviceIntegrationInfo.AccelerationFrequency.ToString();
						case 3737991432u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "FavoriteIcon"))
							{
								break;
							}
							return new IconResourceHandle("favicon.ico").ToString();
						}
					}
				}
				else if (num > 3099413806u)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 3142268575u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "IncludedScripts"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetIncludedScriptBlocks();
					case 3149719873u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "CSS3BrowserCapabilities"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return Convert.ToInt32(mobjRequestInfo.CSS3BrowserCapabilities).ToString();
					case 3156395988u:
						if (!(strVariableName == "MultiThemeDefault"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (SupportsMultipleThemes)
						{
							/*OpCode not supported: LdMemberToken*/;
							return CurrentTheme;
						}
						return "";
					}
				}
				else
				{
					switch (num)
					{
					case 3097553768u:
						if (!(strVariableName == "DebugPageName"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (HostRuntime.Config.ForcePageInstance)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!mobjRequestInfo.PageInstanceWasGiven)
						{
							/*OpCode not supported: LdMemberToken*/;
							return $"{CurrentPageName}?debug=1";
						}
						return $"{CurrentPageName}?debug=1&vwginstance={mobjRequestInfo.PageInstance}";
					case 3034044411u:
						if (!(strVariableName == "ThemedStyleSheets"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetThemedStyleSheetBlocks(GetContextRouter(blnClosingSeperator: true));
					case 3099413806u:
						if (!(strVariableName == "MediaPositionFrequency"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return ConfigHelper.DeviceIntegrationInfo.MediaPositionFrequency.ToString();
					}
				}
			}
			else if (num <= 1274479241)
			{
				if (num > 584329164)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 903149769)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 938465287)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (strVariableName == "RouterContext")
							{
								/*OpCode not supported: LdMemberToken*/;
								goto IL_0a86;
							}
						}
						else
						{
							switch (num)
							{
							case 1051447074u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "IncludedStyleSheets"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetIncludedStyleSheetBlocks();
							case 1274479241u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strVariableName == "VWGVersion"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return WGConst.Version;
							}
						}
					}
					else
					{
						switch (num)
						{
						case 800407154u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "XmlNamespaces"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return $"xmlns:WG='{WGConst.Namespace}' xmlns:WC='{WGConst.ControlsNamespace}'";
						case 844131816u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "CacheDirectory"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return mobjRequestInfo.CacheDirectory;
						case 903149769u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strVariableName == "DebugEnabled"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							if (c371e0db5909d312669b7b89a30fa1396.ShowDebugger.Enabled)
							{
								/*OpCode not supported: LdMemberToken*/;
								return "1";
							}
							return "0";
						}
					}
				}
				else if (num > 431991288)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 456834182u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "AppendRequestContentTypeHeader"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (HostRuntime.Config.IsFeatureEnabled("AppendRequestContentTypeHeader", true))
						{
							/*OpCode not supported: LdMemberToken*/;
							return "1";
						}
						return "0";
					case 513712005u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "Right"))
						{
							break;
						}
						if (!RightToLeft)
						{
							return "right";
						}
						return "left";
					case 584329164u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "GeolocationMaximumAge"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return ConfigHelper.DeviceIntegrationInfo.GeolocationMaximumAge.ToString();
					}
				}
				else
				{
					switch (num)
					{
					case 147053252u:
						if (!(strVariableName == "AutoHideTaskBar"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (HostRuntime.Config.GetFeatureValue("AutoHideTaskBar", blnDefault: true))
						{
							/*OpCode not supported: LdMemberToken*/;
							return "1";
						}
						return "0";
					case 431991288u:
						if (!(strVariableName == "AccessibilityMode"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (HostRuntime.Config.AccessibilityMode)
						{
							/*OpCode not supported: LdMemberToken*/;
							return "1";
						}
						return "0";
					}
				}
			}
			else if (num > 1597034635)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num <= 1914523991)
				{
					switch (num)
					{
					case 1613294357u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "PageName"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return mobjRequestInfo.PageName;
					case 1644100618u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "Direction"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (RightToLeft)
						{
							/*OpCode not supported: LdMemberToken*/;
							return "RTL";
						}
						return "LTR";
					case 1914523991u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "DynamicExtension"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return HostRuntime.Config.DynamicExtension;
					}
				}
				else if (num == 1928508858)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (strVariableName == "RouterContextEx")
					{
						/*OpCode not supported: LdMemberToken*/;
						goto IL_0a86;
					}
				}
				else
				{
					switch (num)
					{
					case 1968842559u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "GeolocationEnableHighAccuracy"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						if (ConfigHelper.DeviceIntegrationInfo.GeolocationEnableHighAccuracy)
						{
							/*OpCode not supported: LdMemberToken*/;
							return "1";
						}
						return "0";
					case 2032329808u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strVariableName == "ApplicationNonScriptContent"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetApplicationNonScriptContent();
					}
				}
			}
			else if (num > 1454196458)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (num)
				{
				case 1597034635u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strVariableName == "FullScreenMode"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					if (mobjRequestInfo.FullScreenMode)
					{
						/*OpCode not supported: LdMemberToken*/;
						return "1";
					}
					return "0";
				case 1477675490u:
				{
					if (!(strVariableName == "NumberDecimalSeparator"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					string result2 = ".";
					if (CurrentUICulture == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result2 = CurrentUICulture.NumberFormat.NumberDecimalSeparator;
					}
					return result2;
				}
				case 1554348843u:
					if (!(strVariableName == "SupportsMultipleThemes"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					if (SupportsMultipleThemes)
					{
						/*OpCode not supported: LdMemberToken*/;
						return "1";
					}
					return "0";
				}
			}
			else
			{
				switch (num)
				{
				case 1393871294u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strVariableName == "KeepConnectedInterval"))
					{
						break;
					}
					return HostRuntime.Config.GetFeatureValue("KeepConnectedInterval", 120000).ToString();
				case 1329799353u:
					if (!(strVariableName == "BrowserCapabilitiesEnums"))
					{
						break;
					}
					return GetBrowserCapabilitiesEnums();
				case 1454196458u:
					if (!(strVariableName == "BrowserObsoleteIE"))
					{
						break;
					}
					if (GetIsBroweserObseleteIE())
					{
						/*OpCode not supported: LdMemberToken*/;
						return "1";
					}
					return "0";
				}
			}
			return string.Empty;
			IL_0a86:
			return GetContextRouter(strVariableName == "RouterContext");
		}

		private string GetContextRouter(bool blnClosingSeperator)
		{
			if (mobjRequestInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return string.Empty;
			}
			if (this != null)
			{
				mobjRequestInfo.CSS3BrowserCapabilities = ((IContextParams)this).CSS3BrowserCapabilities;
				mobjRequestInfo.HTML5BrowserCapabilities = ((IContextParams)this).HTML5BrowserCapabilities;
				mobjRequestInfo.MISCBrowserCapabilities = ((IContextParams)this).MISCBrowserCapabilities;
			}
			if (this != null)
			{
				mobjRequestInfo.FullScreenMode = ((IContext)this).FullScreenMode;
			}
			return mobjRequestInfo.GetRouterContext(CurrentUICulture, blnClosingSeperator);
		}

		private bool GetIsBroweserObseleteIE()
		{
			if (!(mobjRequestInfo.Browser.Browser == "IE"))
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return mobjRequestInfo.Browser.MajorVersion <= 8;
		}

		private bool GetIsBroweserIE()
		{
			if (mobjRequestInfo.Browser.Browser == "IE")
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return mobjRequestInfo.Browser.Browser == "InternetExplorer";
		}

		private string GetBrowserCapabilitiesEnums()
		{
			StringBuilder strBuffer = new StringBuilder();
			GetBrowserCapabilitiesByEnumType<CSS3BrowserCapabilities>(ref strBuffer);
			strBuffer.Append("|");
			GetBrowserCapabilitiesByEnumType<HTML5BrowserCapabilities>(ref strBuffer);
			strBuffer.Append("|");
			GetBrowserCapabilitiesByEnumType<MISCBrowserCapabilities>(ref strBuffer);
			return strBuffer.ToString();
		}

		private void GetBrowserCapabilitiesByEnumType<TEnum>(ref StringBuilder strBuffer) where TEnum : struct, Enum
		{
			bool flag = true;
			string[] names = Enum.GetNames(typeof(TEnum));
			for (int i = 0; i < names.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = names[i];
				if (!flag)
				{
					strBuffer.Append(",");
				}
				strBuffer.Append($"{text}={(int)Enum.Parse(typeof(TEnum), text)}");
				flag = false;
			}
		}

		private string GetEncodedPageInstance(string strPageInstance)
		{
			if (HttpContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (HttpContext.Server != null)
				{
					return HttpContext.Server.UrlEncode(strPageInstance);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return strPageInstance;
		}

		private string GetIncludedScriptBlocks()
		{
			return HostRuntime.Config.GetIncludedScriptBlocks(Presentation, PresentationEngine);
		}

		private string GetIncludedStyleSheetBlocks()
		{
			return HostRuntime.Config.GetIncludedStyleSheetBlocks(Presentation, PresentationEngine);
		}

		private string GetThemedStyleSheetBlocks(string strRouterContext)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!SupportsMultipleThemes)
			{
				/*OpCode not supported: LdMemberToken*/;
				stringBuilder.Append($"<link href=\"Resources.Browser.Form.css{ConfigHelper.DynamicExtension}\" type=\"text/css\" rel=\"stylesheet\"/>");
			}
			else
			{
				IEnumerator enumerator = AvailableThemes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						string current = (string)enumerator.Current;
						string arg = strRouterContext.Replace($"/{CurrentTheme}/", $"/{current}/");
						stringBuilder.Append($"<link href=\"{arg}Resources.Browser.Form.css{ConfigHelper.DynamicExtension}\" type=\"text/css\" rel=\"stylesheet\"/>\n");
					}
				}
				finally
				{
					if (enumerator is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
			return stringBuilder.ToString();
		}

		private bool IsRightToLeftCulture(CultureInfo objCulture)
		{
			if (objCulture != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objCulture.TextInfo == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return objCulture.TwoLetterISOLanguageName == "he";
				}
				return objCulture.TextInfo.IsRightToLeft;
			}
			return false;
		}

		protected virtual string GetApplicationNonScriptContent()
		{
			return "Your browser does not support JavaScript!";
		}

		public virtual bool RenderStaticSEOContent(HostContext objHostContext)
		{
			return false;
		}

		protected virtual string GetApplicationTitle()
		{
			return string.Empty;
		}

		protected virtual string GetApplicationMetadataTags()
		{
			return HostRuntime.Config.GetApplicationMeta(mobjRequestInfo.PageName);
		}

		internal IForm CreateMainForm()
		{
			IForm form = null;
			string currentPage = CurrentPage;
			string applicationMode = HostRuntime.Config.GetApplicationMode(currentPage);
			string application = HostRuntime.Config.GetApplication(currentPage);
			if (string.IsNullOrEmpty(application))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Type type = Type.GetType(application, throwOnError: false);
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (applicationMode == "Factory")
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!typeof(IFormFactory).IsAssignableFrom(type))
					{
						form = GetFactoredForm(type);
						goto IL_00ac;
					}
					form = CreateFormWithFactory(type, currentPage);
				}
			}
			goto IL_00ac;
			IL_00ac:
			if (form == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((IFormResolver)this).RegisterForm(form);
			}
			return form;
		}

		private IForm GetFactoredForm(Type objFormType)
		{
			return (IForm)GetType().GetInterface("IContext").GetMethod("CreateForm").MakeGenericMethod(objFormType)
				.Invoke(this, new object[1]);
		}

		internal IForm CreateLogonForm()
		{
			IForm form = null;
			Monitor.Enter(mstrLogonLocking);
			try
			{
				string text = AuthenticationFormType;
				if (!string.IsNullOrEmpty(text))
				{
					Type type = Type.GetType(text, throwOnError: false);
					if (type != null)
					{
						IForm factoredForm = GetFactoredForm(type);
						if (factoredForm == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							Type type2 = factoredForm.GetType();
							if (!(type2 != type))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								text = type2.AssemblyQualifiedName;
							}
						}
					}
					form = CreateForm(CurrentPage, text);
					if (!(form is ILogonForm))
					{
						throw new Exception("Logon form must implement the ILogonForm interface.");
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Monitor.Exit(mstrLogonLocking);
			}
			return form;
		}

		private IForm CreateForm(string strPage, string strType, params object[] arrArguments)
		{
			IForm form = null;
			if (string.IsNullOrEmpty(strType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Type type = Type.GetType(strType, throwOnError: false);
				if (type == null)
				{
					throw new Exception($"Could not find form type {strType}.");
				}
				/*OpCode not supported: LdMemberToken*/;
				form = CreateFormWithFactory(type, strPage, arrArguments);
				if (form != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					form = Activator.CreateInstance(type, arrArguments) as IForm;
					if (form != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						form = MainForm;
					}
				}
			}
			return form;
		}

		private IForm CreateFormWithFactory(Type objFormType, string strPage, params object[] arrArguments)
		{
			if (objFormType != null)
			{
				if (string.IsNullOrEmpty(strPage))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!typeof(IFormFactory).IsAssignableFrom(objFormType))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (Activator.CreateInstance(objFormType, arrArguments) is IFormFactory formFactory)
					{
						return formFactory.CreateForm(strPage);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			return null;
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
			((IEventHandler)CurrentContainer).FireEvent(objEvent);
		}

		void IContextTerminate.Terminate(bool blnForce)
		{
			if (!blnForce)
			{
				/*OpCode not supported: LdMemberToken*/;
				CurrentContainer.IsTerminated = true;
				return;
			}
			VerboseRecord.Write(CurrentPage + CurrentPageInstance, "Server/Context/Containers", "Terminate", "Terminating the current context container.");
			EnsureSession();
			if (mobjSession == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mobjSession.DeleteContextContainer(CurrentPage, CurrentPageInstance);
			mobjContextContainer = null;
		}

		void IContextTerminate.SetPendingTermination()
		{
			CurrentContainer.SetPendingTermination();
		}

		void IContextTerminate.ClearPendingTermination()
		{
			CurrentContainer.ClearPendingTermination();
		}

		internal void HandleApplicationException(Exception objException, HostContext objHostContext)
		{
			CurrentContainer.HandleApplicationException(objException, objHostContext);
		}

		internal bool ManagePendingTermination()
		{
			if (!CurrentContainer.IsPendingTermination)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			CurrentContainer.ClearPendingTermination();
			CurrentContainer.ClearBookmarks();
			return true;
		}

		internal void InitializeMainFormSize()
		{
			if (CurrentContainer != null)
			{
				CurrentContainer.InitializeMainFormSize();
			}
		}

		string IContextMethodInvoker.GetMethodName(ISkinable objTarget, string strMember)
		{
			return VWGClientContext.Current.GetScopeMethodName(this, objTarget, strMember);
		}

		[Obsolete("Use VWGClientContext.Invoke instead")]
		void IContextMethodInvoker.InvokeMethod(ISkinable objObscuringContext, InvokationUniqueness enmUniqueness, string strMethodName, params object[] arrArguments)
		{
			ClientArgumentInvokeMethod objClientArgument = new ClientArgumentInvokeMethod();
			VWGClientContext.Current.Invoke(objObscuringContext, enmUniqueness, objClientArgument, strMethodName, arrArguments);
		}

		int ITimerHandlerContainer.InvokeTimers(long lngCurrentTicks)
		{
			ContextContainer currentContainer = CurrentContainer;
			if (currentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 0;
			}
			return currentContainer.InvokeTimers(lngCurrentTicks);
		}

		bool IApplicationContext.HandleThreadException(Exception objThreadException)
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return ApplicationContext.HandleThreadException(objThreadException);
		}

		bool IApplicationContext.HandleApplicationTimeout()
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return ApplicationContext.HandleApplicationTimeout();
		}

		void IApplicationContext.OnThreadException(Exception objThreadException)
		{
			if (ApplicationContext != null)
			{
				ApplicationContext.OnThreadException(objThreadException);
			}
		}

		void IApplicationContext.SetUnhandledExceptionMode(UnhandledExceptionMode enmMode, bool blnThreadScope)
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ApplicationContext.SetUnhandledExceptionMode(enmMode, blnThreadScope);
			}
		}

		void IApplicationContext.SendThreadMessage(ThreadMessage objThreadMessage)
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ApplicationContext.SendThreadMessage(objThreadMessage);
			}
		}

		void IApplicationContext.SetThreadBookmark(object objData, string strTitle)
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			ApplicationContext.SetThreadBookmark(objData, strTitle);
			if (CurrentContainer.CurrentBookmarkID == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			((IContextMethodInvoker)this).InvokeMethod((ISkinable)null, InvokationUniqueness.Global, "Bookmarks_SetBookmark", new object[2] { CurrentContainer.CurrentBookmarkID, strTitle });
		}

		void IApplicationContext.SetFocused(IControl objControl, bool blnInvokeFocusCommand)
		{
			if (ApplicationContext != null)
			{
				if (blnInvokeFocusCommand)
				{
					((IContextMethodInvoker)this).InvokeMethod(objControl as ISkinable, InvokationUniqueness.Global, "Controls_Focus", new object[1] { objControl.ID });
				}
				ApplicationContext.SetFocused(objControl, blnInvokeFocusCommand);
			}
		}

		IControl IApplicationContext.GetFocused()
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return ApplicationContext.GetFocused();
		}

		bool IApplicationContext.IsFocused(IControl objControl)
		{
			if (ApplicationContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return ApplicationContext.IsFocused(objControl);
		}

		void IContextClipboard.SetDataObject(IDataObject data, bool copy, int retryTimes, int retryDelay)
		{
			if (ContextClipboard == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ContextClipboard.SetDataObject(data, copy, retryTimes, retryDelay);
			}
		}

		IDataObject IContextClipboard.GetDataObject()
		{
			if (ContextClipboard != null)
			{
				return ContextClipboard.GetDataObject();
			}
			return null;
		}

		void IContextClipboard.Clear()
		{
			if (ContextClipboard == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ContextClipboard.Clear();
			}
		}

		void IContextParams.InvokeComponentMessage(object sender, ComponentMessageEventArgs e)
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				((IContextParams)CurrentContainer).InvokeComponentMessage(sender, e);
			}
		}

		FormAccessMode IContextParams.GetFormAccessMode(IForm objFormToDisplay)
		{
			IContextParams currentContainer = CurrentContainer;
			if (currentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return FormAccessMode.FullControl;
			}
			return currentContainer.GetFormAccessMode(objFormToDisplay);
		}

		public string GetBrowserParentId(string strBrowserId)
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return CurrentContainer.GetBrowserParentId(strBrowserId);
		}

		public string GetBrowserId(HostContext objContext)
		{
			if (CurrentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return CurrentContainer.GetBrowserId(objContext);
		}

		long IContextPipeline.ProcessRequest(string strEvents)
		{
			long lngLastRender = 0L;
			using Queue<IEvent>.Enumerator enumerator = ce7877c7ee4c3060c535e119111a8c060.GetEvents(this, strEvents, out lngLastRender).GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				IEvent current = enumerator.Current;
				IEventHandler eventHandler = null;
				if (!(current.Source == "0"))
				{
					/*OpCode not supported: LdMemberToken*/;
					eventHandler = SessionRegistry.GetRegisteredComponent(current.Source);
				}
				else
				{
					eventHandler = this;
				}
				if (eventHandler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				try
				{
					eventHandler.FireEvent(current);
				}
				catch (Exception ex)
				{
					if (((IApplicationContext)this).HandleThreadException(ex))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					throw ex;
				}
			}
			return lngLastRender;
		}

		internal long GetActiveFormId()
		{
			IForm activeForm = ActiveForm;
			IFormParams formParams = activeForm as IFormParams;
			long iD = activeForm.ID;
			if (formParams == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (formParams.ProxyForm == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (formParams.ProxyForm is RegisteredComponent registeredComponent)
			{
				iD = registeredComponent.ID;
			}
			return iD;
		}

		void IContextPipeline.GenerateResponse(TextWriter objOutput, long lngRequestId)
		{
			IServerResponse obj = Response as IServerResponse;
			IResponseWriter objXmlWriter = new ce018c227db41322d626ccf24fa858c9c(objOutput);
			int intNextInvokationTime = 0;
			bool flag = false;
			MainForm.PreRenderForm(this, lngRequestId);
			obj.Start(DateTime.Now.Ticks, intNextInvokationTime, ref objXmlWriter, flag, GetActiveFormId());
			IForm mainForm = MainForm;
			IResponseWriter objWriter = objXmlWriter;
			long lngRequestID;
			if (flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				lngRequestID = 0L;
			}
			else
			{
				lngRequestID = lngRequestId;
			}
			mainForm.RenderForm(this, objWriter, lngRequestID);
			VWGClientContext.Current.RenderMethodInvokes(this, objXmlWriter);
			obj.End(objXmlWriter);
			MainForm.PostRenderForm(this, lngRequestId);
		}

		IEnumerator ISessionRegistry.GetEnumerator()
		{
			return SessionRegistry.GetEnumerator();
		}

		IRegisteredComponent ISessionRegistry.GetRegisteredComponent(string strComponentId)
		{
			return SessionRegistry.GetRegisteredComponent(strComponentId);
		}

		IRegisteredComponent ISessionRegistry.GetRegisteredComponent(long lngComponentId)
		{
			return SessionRegistry.GetRegisteredComponent(lngComponentId);
		}

		void ISessionRegistry.RegisterComponent(IRegisteredComponent objComponent)
		{
			SessionRegistry.RegisterComponent(objComponent);
		}

		void ISessionRegistry.UnRegisterComponent(IRegisteredComponent objComponent)
		{
			SessionRegistry.UnRegisterComponent(objComponent);
		}

		void ISessionRegistry.RegisterBatch(ICollection objCollection)
		{
			SessionRegistry.RegisterBatch(objCollection);
		}

		void ISessionRegistry.UnRegisterBatch(ICollection objCollection)
		{
			SessionRegistry.UnRegisterBatch(objCollection);
		}

		private EventProcessor GetEventProcessor()
		{
			if (mobjEventProcessor != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjEventProcessor = CurrentContainer.GetEventProcessor();
			}
			return mobjEventProcessor;
		}

		internal void ProcessLoad(IForm objForm, HostContext objContext)
		{
			if (!(ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread"))
			{
				/*OpCode not supported: LdMemberToken*/;
				CurrentContainer.ShowForm(objForm, objContext);
				return;
			}
			if (objForm.Visible)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c389104d09ae3e4cf7ac5587082a5647d objEvent = new c389104d09ae3e4cf7ac5587082a5647d(objForm, objContext);
			EventProcessor eventProcessor = GetEventProcessor();
			eventProcessor.Enqueue(objEvent);
			eventProcessor.Process();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void ProcessEvent(long lngTimeMarker, IEvent objEvent)
		{
			if (!(ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread"))
			{
				/*OpCode not supported: LdMemberToken*/;
				ISessionRegistry sessionRegistry = SessionRegistry;
				if (sessionRegistry == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				IEventHandler eventHandler = null;
				eventHandler = ((!(objEvent.Source == "0")) ? ((IEventHandler)sessionRegistry.GetRegisteredComponent(objEvent.Source)) : ((IEventHandler)this));
				if (eventHandler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				if (!CommonSwitches.TraceVerbose)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					VerboseRecord.Write(eventHandler, "Server/Events", objEvent.Type, "Invoking event handler.");
				}
				((IContextParams)this).InvokeComponentMessage((object)eventHandler, (ComponentMessageEventArgs)new ProcessEventMessageEventArgs("ProcessedEvent", objEvent));
				eventHandler.FireEvent(objEvent);
				if (!(eventHandler is IRegisteredComponent objComponent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					TraceRecord.Write(new EventTraceRecord(objEvent, objComponent, lngTimeMarker));
				}
			}
			else
			{
				EventProcessor eventProcessor = GetEventProcessor();
				eventProcessor.Enqueue(objEvent);
				eventProcessor.Process();
			}
		}

		IContextThreadingService IContext.GetThreadingService()
		{
			if (!(ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread"))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return GetEventProcessor();
		}

		IForm IContext.CreateForm<T>(params object[] arrArguments)
		{
			MappedFormInfo mappedFormInfo = CurrentContainer.GetMappedFormInfo(typeof(T));
			if (string.IsNullOrEmpty(mappedFormInfo.Theme))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CurrentTheme = mappedFormInfo.Theme;
			}
			return CreateForm(CurrentPage, mappedFormInfo.Type, arrArguments);
		}

		void IFormResolver.RegisterForm(IForm objForm)
		{
			CurrentContainer?.RegisterForm(objForm);
		}

		void IFormResolver.UnRegisterForm(IForm objForm)
		{
			ContextContainer currentContainer = CurrentContainer;
			if (currentContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				currentContainer.UnRegisterForm(objForm);
			}
		}
	}
	[Serializable]
	internal class ContextContainer : SerializableObject, IApplicationContext, IContextClipboard, IContextParams, IEventHandler, ISessionRegistry, IDisposable
	{
		private static Dictionary<Type, bool> mobjValidComponents;

		private static object mobjValidComponentsLock;

		private static Dictionary<string, Dictionary<Type, MappedFormInfo>> mobjMappedForms;

		private static object mobjMappedFormsLock;

		private static readonly SerializableEvent ThreadExceptionEvent;

		private static readonly SerializableEvent ComponentMessageEvent;

		private static readonly SerializableEvent ApplicationExitEvent;

		private static readonly SerializableEvent EnterThreadModalEvent;

		private static readonly SerializableEvent IdleEvent;

		private static readonly SerializableEvent LeaveThreadModalEvent;

		private static readonly SerializableEvent ThreadExitEvent;

		private static readonly SerializableEvent ThreadSuspendEvent;

		private static readonly SerializableEvent ThreadRefreshEvent;

		private static readonly SerializableEvent ThreadTickEvent;

		private static readonly SerializableEvent ThreadBookmarkNavigateEvent;

		private static readonly SerializableEvent ThreadMessageEvent;

		private static readonly SerializableEvent BeforeApplicationTimeoutEvent;

		private static readonly SerializableProperty ReferrerProperty;

		private static readonly SerializableProperty TimersProperty;

		private static readonly SerializableProperty UnhandledExceptionModeProperty;

		private static readonly SerializableProperty RedirectToUrlProperty;

		private static readonly SerializableProperty LogonFormProperty;

		private static readonly SerializableProperty SuspendedMainFormProperty;

		private static readonly SerializableProperty SuspendedActiveFormProperty;

		private static readonly SerializableProperty ClipboardDataObjectProperty;

		[NonSerialized]
		private IForm c041406373b776e9eedae420b2df5c769;

		private IDeviceIntegrator mobjDeviceIntegrator;

		private Dictionary<string, FormAccessMode> mobjFormAccessModes;

		[NonSerialized]
		private IForm cc2ac04595cfc10712837b059af86e638;

		[NonSerialized]
		private IEmulationService c047ba2eb809594268824a28d315a9487;

		[NonSerialized]
		private IControl c7f59f6afcc1cae87717b1a7e44bd2b74;

		[NonSerialized]
		private string c93ed3bd0206ade21c68f4c15dbf65708;

		[NonSerialized]
		private RequestProcessingState cda2bae3985e58061125209be457c6a7b;

		[NonSerialized]
		private LoginHelper c74879b6b4a4a3d7b0196475325109d8a = new LoginHelper();

		[NonSerialized]
		private bool? c678ffad96a590813df31a895c2fde176;

		[NonSerialized]
		private int c08de36444cd0b4618b04ed2f742996f0 = -1;

		[NonSerialized]
		private ArrayList cc9af67efd5e3701c34c235b7ec5f1f29;

		[NonSerialized]
		private int c97914221e94add3b5c5fedd286e1ce12;

		private ReadOnlyCollection<string> marrAvailableThemes;

		private bool mblnIsTerminated;

		private bool mblnIsPendingTermination;

		private DateTime mobjPendingTerminationTimeStamp = DateTime.MaxValue;

		[NonSerialized]
		private NameValueCollection cba1c73d27874bcfa90be4c04e7fbe93f;

		[NonSerialized]
		private NameValueCollection c8bee4159344556cb0ce1661b84398052;

		[NonSerialized]
		private Hashtable cf12f9b84144c3552a40d6130626735e9;

		[NonSerialized]
		private bool c9c0b127d9609e396a2f14de32e3864d3;

		[NonSerialized]
		private Keys ce888a75e87da33b24d2f8be0d47e4cd0;

		[NonSerialized]
		private Point ccf9ca10024688bdd357c2c9372b0f39b = Point.Empty;

		[NonSerialized]
		private Dictionary<long, IRegisteredComponent> c6cde426f87a1b2ca1cf005c54ff47761;

		[NonSerialized]
		private long c321de290f3a3775115d1677c9c8ad1e1 = 1L;

		[NonSerialized]
		private EventProcessor c0b80cda3b33a914716e26fe0bfa78d9f;

		private DeviceOrientation menmStartupDeviceOrientation;

		private int mintScreenAvailableHeight = 768;

		private int mintScreenAvailableWidth = 1024;

		private int mintScreenHeight = 768;

		private int mintScreenWidth = 1024;

		private int mintScreenColorDepth = 16;

		private int mintScreenDevicePixelRatio = -1;

		private int mintBrowserHeight = -1;

		private int mintBrowserWidth = -1;

		private bool mblnSupportBorderRadius;

		private CSS3BrowserCapabilities menmCSS3BrowserCapabilities = CSS3BrowserCapabilities.Empty;

		private HTML5BrowserCapabilities menmHTML5BrowserCapabilities = HTML5BrowserCapabilities.Empty;

		private MISCBrowserCapabilities menmMISCBrowserCapabilities = MISCBrowserCapabilities.Empty;

		private string[] marrPreloadedResources;

		private NameValueCollection mobjSSOLogonAuthentication;

		[NonSerialized]
		private Graphics c5e1957f843f5e0211f8a582a420dc9e3;

		private string mstrBrowserId;

		private List<object> mobjNavigationForms = new List<object>();

		private string mstrWebSocketConnectionId;

		[NonSerialized]
		private IEmulatorForm cc3a02d2829d86da7c1f0932ee7e98518;

		[NonSerialized]
		private IEmulationDevice c5b3a0eee9a0456dd1877bb1b13c6403b;

		[NonSerialized]
		private IProxyMasterPage cadc93c39478274021fdac7dc0df7676a;

		[NonSerialized]
		private Dictionary<string, IProxyMasterPage> c585ed66edcd6768b169cc0ef7afa52b1 = new Dictionary<string, IProxyMasterPage>();

		private Dictionary<Type, Dictionary<string, List<object>>> mobjVisualTemplatesData;

		private IForm mobjContextualToolbar;

		private WebSocketService mobjWebSocketService;

		private const int mintSerializableFieldCount = 10;

		private Gizmox.WebGUI.Forms.ThreadExceptionEventHandler ThreadExceptionHandler => (Gizmox.WebGUI.Forms.ThreadExceptionEventHandler)GetHandler(ThreadExceptionEvent);

		private EventHandler ApplicationExitHandler => (EventHandler)GetHandler(ApplicationExitEvent);

		private EventHandler EnterThreadModalHandler => (EventHandler)GetHandler(EnterThreadModalEvent);

		private EventHandler IdleHandler => (EventHandler)GetHandler(IdleEvent);

		private EventHandler LeaveThreadModalHandler => (EventHandler)GetHandler(LeaveThreadModalEvent);

		private EventHandler ThreadExitHandler => (EventHandler)GetHandler(ThreadExitEvent);

		private EventHandler ThreadSuspendHandler => (EventHandler)GetHandler(ThreadSuspendEvent);

		private EventHandler ThreadRefreshHandler => (EventHandler)GetHandler(ThreadRefreshEvent);

		private EventHandler ThreadTickHandler => (EventHandler)GetHandler(ThreadTickEvent);

		private ThreadBookmarkEventHandler ThreadBookmarkNavigateHandler => (ThreadBookmarkEventHandler)GetHandler(ThreadBookmarkNavigateEvent);

		private ThreadMessageEventHandler ThreadMessageHandler => (ThreadMessageEventHandler)GetHandler(ThreadMessageEvent);

		private CancelEventHandler BeforeApplicationTimeoutHandler => (CancelEventHandler)GetHandler(BeforeApplicationTimeoutEvent);

		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 10 + SerializationWriter.GetRequiredCapacity(c6cde426f87a1b2ca1cf005c54ff47761) + SerializationWriter.GetRequiredCapacity(cc9af67efd5e3701c34c235b7ec5f1f29) + SerializationWriter.GetRequiredCapacity(cf12f9b84144c3552a40d6130626735e9) + SerializationWriter.GetRequiredCapacity(c8bee4159344556cb0ce1661b84398052) + SerializationWriter.GetRequiredCapacity(cba1c73d27874bcfa90be4c04e7fbe93f);

		public IForm ActiveForm
		{
			get
			{
				return cc2ac04595cfc10712837b059af86e638;
			}
			set
			{
				cc2ac04595cfc10712837b059af86e638 = value;
			}
		}

		public IForm SuspendedActiveForm
		{
			get
			{
				return GetValue(SuspendedActiveFormProperty);
			}
			set
			{
				SetValue(SuspendedActiveFormProperty, value);
			}
		}

		public IForm MainForm
		{
			get
			{
				return c041406373b776e9eedae420b2df5c769;
			}
			set
			{
				if (c041406373b776e9eedae420b2df5c769 != value)
				{
					if (c041406373b776e9eedae420b2df5c769 != null)
					{
						mintBrowserHeight = c041406373b776e9eedae420b2df5c769.Height;
						mintBrowserWidth = c041406373b776e9eedae420b2df5c769.Width;
					}
					c041406373b776e9eedae420b2df5c769 = value;
					InitializeFormSize(c041406373b776e9eedae420b2df5c769);
				}
			}
		}

		public IForm SuspendedMainForm
		{
			get
			{
				return GetValue(SuspendedMainFormProperty);
			}
			set
			{
				SetValue(SuspendedMainFormProperty, value);
			}
		}

		public IForm LogonForm
		{
			get
			{
				return GetValue(LogonFormProperty);
			}
			set
			{
				SetValue(LogonFormProperty, value);
			}
		}

		public IEmulatorForm EmulatorForm
		{
			get
			{
				return cc3a02d2829d86da7c1f0932ee7e98518;
			}
			set
			{
				cc3a02d2829d86da7c1f0932ee7e98518 = value;
			}
		}

		public IEmulationDevice EmulationDevice
		{
			get
			{
				return c5b3a0eee9a0456dd1877bb1b13c6403b;
			}
			set
			{
				c5b3a0eee9a0456dd1877bb1b13c6403b = value;
			}
		}

		public IProxyMasterPage ActiveProxyMasterPage
		{
			get
			{
				return cadc93c39478274021fdac7dc0df7676a;
			}
			set
			{
				cadc93c39478274021fdac7dc0df7676a = value;
			}
		}

		public Dictionary<string, IProxyMasterPage> NameProxyMasterPageMap => c585ed66edcd6768b169cc0ef7afa52b1;

		public string Referrer
		{
			get
			{
				return GetValue(ReferrerProperty);
			}
			set
			{
				SetValue(ReferrerProperty, value);
			}
		}

		internal ContextTimers Timers
		{
			get
			{
				ContextTimers contextTimers = GetValue(TimersProperty);
				if (contextTimers != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					contextTimers = new ContextTimers(this);
					SetValue(TimersProperty, contextTimers);
					((ISessionRegistry)this).RegisterComponent((IRegisteredComponent)contextTimers);
				}
				return contextTimers;
			}
		}

		internal bool HasTimers
		{
			get
			{
				ContextTimers value = GetValue(TimersProperty);
				if (value != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return value.HasTimers;
				}
				return false;
			}
		}

		internal bool IsPendingTermination => mblnIsPendingTermination;

		internal bool ShouldTerminate
		{
			get
			{
				if (!mblnIsTerminated)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!mblnIsPendingTermination)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (DateTime.Now.CompareTo(mobjPendingTerminationTimeStamp) > 0)
						{
							return true;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					return false;
				}
				return true;
			}
		}

		public bool IsLoggedOn
		{
			get
			{
				return c74879b6b4a4a3d7b0196475325109d8a.IsLoggedOn;
			}
			set
			{
				c74879b6b4a4a3d7b0196475325109d8a.IsLoggedOn = value;
			}
		}

		public ReadOnlyCollection<string> AvailableThemes
		{
			get
			{
				if (marrAvailableThemes == null)
				{
					List<string> list = new List<string>();
					foreach (string availableTheme in Config.GetInstance().AvailableThemes)
					{
						list.Add(availableTheme);
					}
					marrAvailableThemes = new ReadOnlyCollection<string>(list);
				}
				if (marrAvailableThemes.Count != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					List<string> list2 = new List<string>();
					list2.Add(CurrentTheme);
					marrAvailableThemes = new ReadOnlyCollection<string>(list2);
				}
				return marrAvailableThemes;
			}
			set
			{
				marrAvailableThemes = value;
			}
		}

		internal string RedirectToUrl
		{
			get
			{
				return GetValue(RedirectToUrlProperty);
			}
			set
			{
				SetValue(RedirectToUrlProperty, value);
			}
		}

		internal bool IsTerminated
		{
			get
			{
				return mblnIsTerminated;
			}
			set
			{
				mblnIsTerminated = value;
			}
		}

		internal NameValueCollection Arguments
		{
			get
			{
				if (c8bee4159344556cb0ce1661b84398052 == null)
				{
					c8bee4159344556cb0ce1661b84398052 = new ArgumentsProvider();
				}
				return c8bee4159344556cb0ce1661b84398052;
			}
			set
			{
				c8bee4159344556cb0ce1661b84398052 = value;
			}
		}

		internal NameValueCollection Results
		{
			get
			{
				if (cba1c73d27874bcfa90be4c04e7fbe93f != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cba1c73d27874bcfa90be4c04e7fbe93f = new ResultsProvider();
				}
				return cba1c73d27874bcfa90be4c04e7fbe93f;
			}
			set
			{
				cba1c73d27874bcfa90be4c04e7fbe93f = value;
			}
		}

		internal object this[string strKey]
		{
			get
			{
				if (cf12f9b84144c3552a40d6130626735e9 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return cf12f9b84144c3552a40d6130626735e9[strKey];
				}
				return null;
			}
			set
			{
				if (!c371e0db5909d312669b7b89a30fa1396.EmulateSessionStateSerialization.Enabled)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					CommonUtils.TrySerialize(value);
				}
				if (cf12f9b84144c3552a40d6130626735e9 == null)
				{
					cf12f9b84144c3552a40d6130626735e9 = new Hashtable();
				}
				cf12f9b84144c3552a40d6130626735e9[strKey] = value;
			}
		}

		internal bool HasUnhandledExceptionHandlers => ThreadExceptionHandler != null;

		internal UnhandledExceptionMode UnhandledExceptionMode
		{
			get
			{
				UnhandledExceptionMode value = GetValue(UnhandledExceptionModeProperty);
				if (!HasUnhandledExceptionHandlers)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (value == UnhandledExceptionMode.ThrowException)
					{
						return UnhandledExceptionMode.Automatic;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return value;
			}
		}

		internal int CurrentBookmarkID => c08de36444cd0b4618b04ed2f742996f0;

		private ArrayList ThreadBookmarks
		{
			get
			{
				if (cc9af67efd5e3701c34c235b7ec5f1f29 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cc9af67efd5e3701c34c235b7ec5f1f29 = new ArrayList();
				}
				return cc9af67efd5e3701c34c235b7ec5f1f29;
			}
		}

		int ISessionRegistry.Count => c6cde426f87a1b2ca1cf005c54ff47761.Count;

		public bool IsPngSupport => (((IContextParams)this).MISCBrowserCapabilities & MISCBrowserCapabilities.PngSupport) == MISCBrowserCapabilities.PngSupport;

		internal int KeepConnectedCount
		{
			get
			{
				return c97914221e94add3b5c5fedd286e1ce12;
			}
			set
			{
				c97914221e94add3b5c5fedd286e1ce12 = value;
			}
		}

		public RequestProcessingState RequestProcessingState
		{
			get
			{
				return cda2bae3985e58061125209be457c6a7b;
			}
			internal set
			{
				cda2bae3985e58061125209be457c6a7b = value;
			}
		}

		internal string CurrentTheme
		{
			get
			{
				if (c93ed3bd0206ade21c68f4c15dbf65708 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c93ed3bd0206ade21c68f4c15dbf65708 = ((((IContextParams)this).CurrentPageName == WGConst.AdministrationPage) ? ConfigHelper.Administration.Theme : HostRuntime.Config.DefaultTheme);
				}
				return c93ed3bd0206ade21c68f4c15dbf65708;
			}
			set
			{
				if (c93ed3bd0206ade21c68f4c15dbf65708 != value)
				{
					c93ed3bd0206ade21c68f4c15dbf65708 = value;
					if (MainForm == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						MainForm.PerformLayout(blnForceLayout: true);
					}
				}
			}
		}

		internal bool FullScreenMode
		{
			get
			{
				bool? flag = c678ffad96a590813df31a895c2fde176;
				if (flag.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					return flag == true;
				}
				return ConfigHelper.FullScreenMode;
			}
			set
			{
				bool? flag = c678ffad96a590813df31a895c2fde176;
				bool flag2 = value;
				if (flag == true == flag2)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (flag.HasValue)
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
				}
				c678ffad96a590813df31a895c2fde176 = value;
			}
		}

		private Dictionary<string, FormAccessMode> FormAccessModes
		{
			get
			{
				if (mobjFormAccessModes != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjFormAccessModes = new Dictionary<string, FormAccessMode>();
				}
				return mobjFormAccessModes;
			}
		}

		internal Keys ModifierKeys
		{
			get
			{
				return ce888a75e87da33b24d2f8be0d47e4cd0;
			}
			set
			{
				ce888a75e87da33b24d2f8be0d47e4cd0 = value;
			}
		}

		public Point CursorPosition
		{
			get
			{
				return ccf9ca10024688bdd357c2c9372b0f39b;
			}
			set
			{
				ccf9ca10024688bdd357c2c9372b0f39b = value;
			}
		}

		string IContextParams.CurrentPageName
		{
			get
			{
				HostRequestInfo info = VWGContext.Current.HostContext.Request.Info;
				if (info == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return info.PageName;
			}
		}

		ICollection<string> IContextParams.SystemPages
		{
			get
			{
				return null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		NameValueCollection IContextParams.SSOData
		{
			get
			{
				return mobjSSOLogonAuthentication;
			}
			set
			{
				mobjSSOLogonAuthentication = value;
			}
		}

		long IContextParams.LastRender => 0L;

		Keys IContextParams.ModifierKeys
		{
			get
			{
				return ModifierKeys;
			}
			set
			{
				ModifierKeys = value;
			}
		}

		string IContextParams.Browser => string.Empty;

		DeviceOrientation IContextParams.StartupDeviceOrientation => menmStartupDeviceOrientation;

		int IContextParams.ScreenAvailableHeight => mintScreenAvailableHeight;

		int IContextParams.ScreenAvailableWidth => mintScreenAvailableWidth;

		int IContextParams.ScreenHeight
		{
			get
			{
				return mintScreenHeight;
			}
			set
			{
				mintScreenHeight = value;
			}
		}

		int IContextParams.ScreenWidth
		{
			get
			{
				return mintScreenWidth;
			}
			set
			{
				mintScreenWidth = value;
			}
		}

		int IContextParams.ScreenDevicePixelRatio => mintScreenDevicePixelRatio;

		CSS3BrowserCapabilities IContextParams.CSS3BrowserCapabilities
		{
			get
			{
				return menmCSS3BrowserCapabilities;
			}
			set
			{
				menmCSS3BrowserCapabilities = value;
			}
		}

		HTML5BrowserCapabilities IContextParams.HTML5BrowserCapabilities
		{
			get
			{
				return menmHTML5BrowserCapabilities;
			}
			set
			{
				menmHTML5BrowserCapabilities = value;
			}
		}

		MISCBrowserCapabilities IContextParams.MISCBrowserCapabilities
		{
			get
			{
				return menmMISCBrowserCapabilities;
			}
			set
			{
				menmMISCBrowserCapabilities = value;
			}
		}

		int IContextParams.ScreenColorDepth => mintScreenColorDepth;

		string[] IContextParams.PreloadedResources
		{
			get
			{
				if (marrPreloadedResources != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					marrPreloadedResources = HostRuntime.Config.PreloadedResources;
				}
				return marrPreloadedResources;
			}
		}

		Graphics IContextParams.MeasurementGraphics
		{
			get
			{
				if (c5e1957f843f5e0211f8a582a420dc9e3 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Bitmap image = new Bitmap(1, 1);
					c5e1957f843f5e0211f8a582a420dc9e3 = Graphics.FromImage(image);
				}
				return c5e1957f843f5e0211f8a582a420dc9e3;
			}
		}

		string IContextParams.BrowserId => mstrBrowserId;

		IForm IContextParams.ContextualToolbar
		{
			get
			{
				return mobjContextualToolbar;
			}
			set
			{
				mobjContextualToolbar = value;
			}
		}

		internal IDeviceIntegrator DeviceIntegrator
		{
			get
			{
				return mobjDeviceIntegrator;
			}
			set
			{
				if (mobjDeviceIntegrator == value)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjDeviceIntegrator = value;
				}
			}
		}

		internal IForm[] AccessibleForms
		{
			get
			{
				List<IForm> list = new List<IForm>();
				for (int num = mobjNavigationForms.Count - 1; num >= 0; num--)
				{
					/*OpCode not supported: LdMemberToken*/;
					IForm form = (IForm)mobjNavigationForms[num];
					list.Add(form);
					if (form.DialogType == DialogTypes.MainWindow)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					if (form.DialogType == DialogTypes.ModalWindow)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
				}
				list.Reverse();
				return list.ToArray();
			}
		}

		public string WebSocketConnectionId
		{
			get
			{
				return mstrWebSocketConnectionId;
			}
			set
			{
				mstrWebSocketConnectionId = value;
			}
		}

		public WebSocketService WebSocketService
		{
			get
			{
				if (mobjWebSocketService == null)
				{
					mobjWebSocketService = new WebSocketService();
				}
				return mobjWebSocketService;
			}
			set
			{
			}
		}

		public IEmulationService EmulationService
		{
			get
			{
				if (c047ba2eb809594268824a28d315a9487 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Type type = Type.GetType(string.Format("{0}, {1}", "Gizmox.WebGUI.Server.Emulation.EmulationService", CommonUtils.GetFullAssemblyName("Gizmox.WebGUI.Emulation")));
					if (!(type != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						c047ba2eb809594268824a28d315a9487 = Activator.CreateInstance(type) as IEmulationService;
					}
				}
				return c047ba2eb809594268824a28d315a9487;
			}
		}

		public event Gizmox.WebGUI.Forms.ThreadExceptionEventHandler ThreadException
		{
			add
			{
				Delegate handler = GetHandler(ThreadExceptionEvent);
				if ((object)handler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Delegate[] invocationList = handler.GetInvocationList();
					foreach (Delegate objValue in invocationList)
					{
						RemoveHandler(ThreadExceptionEvent, objValue);
					}
				}
				AddHandler(ThreadExceptionEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadExceptionEvent, value);
			}
		}

		public event ComponentMessageEventHandler ComponentMessage
		{
			add
			{
				AddHandler(ComponentMessageEvent, value);
			}
			remove
			{
				RemoveHandler(ComponentMessageEvent, value);
			}
		}

		public event EventHandler ApplicationExit
		{
			add
			{
				AddHandler(ApplicationExitEvent, value);
			}
			remove
			{
				RemoveHandler(ApplicationExitEvent, value);
			}
		}

		public event EventHandler EnterThreadModal
		{
			add
			{
				AddHandler(EnterThreadModalEvent, value);
			}
			remove
			{
				RemoveHandler(EnterThreadModalEvent, value);
			}
		}

		public event EventHandler Idle
		{
			add
			{
				AddHandler(IdleEvent, value);
			}
			remove
			{
				RemoveHandler(IdleEvent, value);
			}
		}

		public event EventHandler LeaveThreadModal
		{
			add
			{
				AddHandler(LeaveThreadModalEvent, value);
			}
			remove
			{
				RemoveHandler(LeaveThreadModalEvent, value);
			}
		}

		public event EventHandler ThreadExit
		{
			add
			{
				AddHandler(ThreadExitEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadExitEvent, value);
			}
		}

		public event EventHandler ThreadSuspend
		{
			add
			{
				AddHandler(ThreadSuspendEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadSuspendEvent, value);
			}
		}

		public event EventHandler ThreadRefresh
		{
			add
			{
				AddHandler(ThreadRefreshEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadRefreshEvent, value);
			}
		}

		public event EventHandler ThreadTick
		{
			add
			{
				AddHandler(ThreadTickEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadTickEvent, value);
			}
		}

		public event ThreadBookmarkEventHandler ThreadBookmarkNavigate
		{
			add
			{
				AddHandler(ThreadBookmarkNavigateEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadBookmarkNavigateEvent, value);
			}
		}

		public event ThreadMessageEventHandler ThreadMessage
		{
			add
			{
				AddHandler(ThreadMessageEvent, value);
			}
			remove
			{
				RemoveHandler(ThreadMessageEvent, value);
			}
		}

		public event CancelEventHandler BeforeApplicationTimeout
		{
			add
			{
				AddHandler(BeforeApplicationTimeoutEvent, value);
			}
			remove
			{
				RemoveHandler(BeforeApplicationTimeoutEvent, value);
			}
		}

		static ContextContainer()
		{
			mobjValidComponents = null;
			mobjValidComponentsLock = new object();
			mobjMappedForms = null;
			mobjMappedFormsLock = new object();
			ThreadExceptionEvent = SerializableEvent.Register("ThreadException", typeof(Gizmox.WebGUI.Forms.ThreadExceptionEventHandler), typeof(ContextContainer));
			ComponentMessageEvent = SerializableEvent.Register("ComponentMessage", typeof(ComponentMessageEventHandler), typeof(ContextContainer));
			ApplicationExitEvent = SerializableEvent.Register("ApplicationExit", typeof(EventHandler), typeof(ContextContainer));
			EnterThreadModalEvent = SerializableEvent.Register("EnterThreadModal", typeof(EventHandler), typeof(ContextContainer));
			IdleEvent = SerializableEvent.Register("Idle", typeof(EventHandler), typeof(ContextContainer));
			LeaveThreadModalEvent = SerializableEvent.Register("LeaveThreadModal", typeof(EventHandler), typeof(ContextContainer));
			ThreadExitEvent = SerializableEvent.Register("ThreadExit", typeof(EventHandler), typeof(ContextContainer));
			ThreadSuspendEvent = SerializableEvent.Register("ThreadSuspend", typeof(EventHandler), typeof(ContextContainer));
			ThreadRefreshEvent = SerializableEvent.Register("ThreadRefresh", typeof(EventHandler), typeof(ContextContainer));
			ThreadTickEvent = SerializableEvent.Register("ThreadTick", typeof(EventHandler), typeof(ContextContainer));
			ThreadBookmarkNavigateEvent = SerializableEvent.Register("ThreadBookmarkNavigate", typeof(ThreadBookmarkEventHandler), typeof(ContextContainer));
			ThreadMessageEvent = SerializableEvent.Register("ThreadMessage", typeof(ThreadMessageEventHandler), typeof(ContextContainer));
			BeforeApplicationTimeoutEvent = SerializableEvent.Register("BeforeApplicationTimeoutEvent", typeof(CancelEventHandler), typeof(ContextContainer));
			ReferrerProperty = SerializableProperty.Register("Referrer", typeof(string), typeof(ContextContainer), new SerializablePropertyMetadata(string.Empty));
			TimersProperty = SerializableProperty.Register("Timers", typeof(ContextTimers), typeof(ContextContainer), new SerializablePropertyMetadata(null));
			UnhandledExceptionModeProperty = SerializableProperty.Register("UnhandledExceptionMode", typeof(UnhandledExceptionMode), typeof(ContextContainer), new SerializablePropertyMetadata(UnhandledExceptionMode.ThrowException));
			RedirectToUrlProperty = SerializableProperty.Register("RedirectToUrl", typeof(string), typeof(ContextContainer), new SerializablePropertyMetadata(string.Empty));
			LogonFormProperty = SerializableProperty.Register("LogonForm", typeof(IForm), typeof(ContextContainer), new SerializablePropertyMetadata(null));
			SuspendedMainFormProperty = SerializableProperty.Register("SuspendedMainForm", typeof(IForm), typeof(ContextContainer), new SerializablePropertyMetadata(null));
			SuspendedActiveFormProperty = SerializableProperty.Register("SuspendedActiveForm", typeof(IForm), typeof(ContextContainer), new SerializablePropertyMetadata(null));
			ClipboardDataObjectProperty = SerializableProperty.Register("ClipboardDataObject", typeof(IDataObject), typeof(ContextContainer), new SerializablePropertyMetadata(null));
			mobjValidComponents = new Dictionary<Type, bool>();
		}

		internal ContextContainer(string strKey)
		{
			c6cde426f87a1b2ca1cf005c54ff47761 = new Dictionary<long, IRegisteredComponent>();
		}

		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			c041406373b776e9eedae420b2df5c769 = (IForm)objReader.ReadObject();
			cc2ac04595cfc10712837b059af86e638 = (IForm)objReader.ReadObject();
			cc3a02d2829d86da7c1f0932ee7e98518 = (IEmulatorForm)objReader.ReadObject();
			c5b3a0eee9a0456dd1877bb1b13c6403b = (IEmulationDevice)objReader.ReadObject();
			cadc93c39478274021fdac7dc0df7676a = (IProxyMasterPage)objReader.ReadObject();
			c585ed66edcd6768b169cc0ef7afa52b1 = (Dictionary<string, IProxyMasterPage>)objReader.ReadObject();
			c7f59f6afcc1cae87717b1a7e44bd2b74 = (IControl)objReader.ReadObject();
			c74879b6b4a4a3d7b0196475325109d8a = (LoginHelper)objReader.ReadObject();
			c97914221e94add3b5c5fedd286e1ce12 = objReader.ReadInt32();
			ce888a75e87da33b24d2f8be0d47e4cd0 = (Keys)objReader.ReadInt32();
			c93ed3bd0206ade21c68f4c15dbf65708 = objReader.ReadString();
			cda2bae3985e58061125209be457c6a7b = (RequestProcessingState)objReader.ReadInt32();
			c08de36444cd0b4618b04ed2f742996f0 = objReader.ReadInt32();
			c321de290f3a3775115d1677c9c8ad1e1 = objReader.ReadInt64();
			ccf9ca10024688bdd357c2c9372b0f39b = (Point)objReader.ReadObject();
			c047ba2eb809594268824a28d315a9487 = (IEmulationService)objReader.ReadObject();
			c6cde426f87a1b2ca1cf005c54ff47761 = objReader.ReadDictionary<long, IRegisteredComponent>();
			cc9af67efd5e3701c34c235b7ec5f1f29 = objReader.ReadArrayList(blnReturnNullIfEmpty: true);
			cf12f9b84144c3552a40d6130626735e9 = objReader.ReadHashtable(blnReturnNullIfEmpty: true);
			cba1c73d27874bcfa90be4c04e7fbe93f = objReader.ReadNameValueCollection(blnReturnNullIfEmpty: true);
			c8bee4159344556cb0ce1661b84398052 = objReader.ReadNameValueCollection(blnReturnNullIfEmpty: true);
		}

		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteObject(c041406373b776e9eedae420b2df5c769);
			objWriter.WriteObject(cc2ac04595cfc10712837b059af86e638);
			objWriter.WriteObject(cc3a02d2829d86da7c1f0932ee7e98518);
			objWriter.WriteObject(c5b3a0eee9a0456dd1877bb1b13c6403b);
			objWriter.WriteObject(cadc93c39478274021fdac7dc0df7676a);
			objWriter.WriteObject(c585ed66edcd6768b169cc0ef7afa52b1);
			objWriter.WriteObject(c7f59f6afcc1cae87717b1a7e44bd2b74);
			objWriter.WriteObject(c74879b6b4a4a3d7b0196475325109d8a);
			objWriter.WriteInt32(c97914221e94add3b5c5fedd286e1ce12);
			objWriter.WriteInt32(Convert.ToInt32(ce888a75e87da33b24d2f8be0d47e4cd0));
			objWriter.WriteString(c93ed3bd0206ade21c68f4c15dbf65708);
			objWriter.WriteInt32(Convert.ToInt32(cda2bae3985e58061125209be457c6a7b));
			objWriter.WriteInt32(c08de36444cd0b4618b04ed2f742996f0);
			objWriter.WriteInt64(c321de290f3a3775115d1677c9c8ad1e1);
			objWriter.WriteObject(ccf9ca10024688bdd357c2c9372b0f39b);
			objWriter.WriteObject(c047ba2eb809594268824a28d315a9487);
			objWriter.WriteDictionary(c6cde426f87a1b2ca1cf005c54ff47761);
			objWriter.WriteArray(cc9af67efd5e3701c34c235b7ec5f1f29);
			objWriter.WriteHashtable(cf12f9b84144c3552a40d6130626735e9);
			objWriter.WriteNameValueCollection(cba1c73d27874bcfa90be4c04e7fbe93f);
			objWriter.WriteNameValueCollection(c8bee4159344556cb0ce1661b84398052);
		}

		void IContextClipboard.SetDataObject(IDataObject data, bool copy, int retryTimes, int retryDelay)
		{
			SetValue(ClipboardDataObjectProperty, data);
		}

		IDataObject IContextClipboard.GetDataObject()
		{
			return GetValue(ClipboardDataObjectProperty);
		}

		void IContextClipboard.Clear()
		{
			RemoveValue(ClipboardDataObjectProperty);
		}

		internal int InvokeTimers(long lngCurrentTicks)
		{
			ContextTimers value = GetValue(TimersProperty);
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 0;
			}
			return value.InvokeTimers(lngCurrentTicks);
		}

		internal void SetPendingTermination()
		{
			SetPendingTermination(value: true);
		}

		internal void ClearPendingTermination()
		{
			SetPendingTermination(value: false);
		}

		private void SetPendingTermination(bool value)
		{
			if (mblnIsPendingTermination == value)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mblnIsPendingTermination = value;
			if (value)
			{
				mobjPendingTerminationTimeStamp = DateTime.Now.AddMinutes(1.0);
				FireApplicationThreadSuspend();
			}
		}

		private static string GetDefaultDeviceRepositoryString()
		{
			_ = string.Empty;
			return "Gizmox.WebGUI.Common.DeviceRepository.BrowserRepository, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
		}

		public void SetUnhandledExceptionMode(UnhandledExceptionMode enmMode, bool blnThreadScope)
		{
			SetValue(UnhandledExceptionModeProperty, enmMode);
		}

		void IApplicationContext.OnThreadException(Exception objThreadException)
		{
			ThreadExceptionHandler?.Invoke(this, new Gizmox.WebGUI.Forms.ThreadExceptionEventArgs(objThreadException));
		}

		bool IApplicationContext.HandleThreadException(Exception objThreadException)
		{
			bool flag = HandleException(objThreadException);
			if (!flag)
			{
				if (!(objThreadException is LogonException))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(Global.Context is Context context))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!context.UseAuthentication)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!LogonException.IsLogonException(objThreadException))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					context.Session.IsLoggedOn = false;
					flag = true;
				}
			}
			return flag;
		}

		bool IApplicationContext.HandleApplicationTimeout()
		{
			CancelEventArgs e = new CancelEventArgs();
			if (BeforeApplicationTimeoutHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				BeforeApplicationTimeoutHandler(this, e);
			}
			return e.Cancel;
		}

		void IApplicationContext.SetFocused(IControl objControl, bool blnInvokeFocusCommand)
		{
			c7f59f6afcc1cae87717b1a7e44bd2b74 = objControl;
		}

		IControl IApplicationContext.GetFocused()
		{
			return c7f59f6afcc1cae87717b1a7e44bd2b74;
		}

		bool IApplicationContext.IsFocused(IControl objControl)
		{
			return c7f59f6afcc1cae87717b1a7e44bd2b74 == objControl;
		}

		void IApplicationContext.SetThreadBookmark(object objData, string strTitle)
		{
			if (c08de36444cd0b4618b04ed2f742996f0 + 1 >= ThreadBookmarks.Count)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ThreadBookmarks.RemoveRange(c08de36444cd0b4618b04ed2f742996f0 + 1, ThreadBookmarks.Count - (c08de36444cd0b4618b04ed2f742996f0 + 1));
			}
			c08de36444cd0b4618b04ed2f742996f0 = ThreadBookmarks.Add(objData);
		}

		void IApplicationContext.SendThreadMessage(ThreadMessage objThreadMessage)
		{
		}

		internal void ClearBookmarks()
		{
			c08de36444cd0b4618b04ed2f742996f0 = -1;
			if (cc9af67efd5e3701c34c235b7ec5f1f29 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cc9af67efd5e3701c34c235b7ec5f1f29.Clear();
			}
		}

		internal void NavigateBookmark(int intBookmarkID)
		{
			if (ThreadBookmarks.Count <= intBookmarkID)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c08de36444cd0b4618b04ed2f742996f0 = intBookmarkID;
			ThreadBookmarkNavigateHandler?.Invoke(this, new ThreadBookmarkEventArgs(ThreadBookmarks[intBookmarkID]));
		}

		public void RegisterComponent(IRegisteredComponent objComponent)
		{
			if (objComponent.IsRegistered)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!IsRegisteredComponent(objComponent))
			{
				throw new ArgumentException("The Control is not registered: " + objComponent.GetType().Name);
			}
			if ((objComponent.RegisteredState & RegisteredState.Identified) != RegisteredState.Identified)
			{
				objComponent.ID = c321de290f3a3775115d1677c9c8ad1e1++;
			}
			if (!c371e0db5909d312669b7b89a30fa1396.SessionTracing.RegistrationTrace)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VerboseRecord.Write("Server", "Session/Registry", "Registering", $"Component of type '{objComponent.GetType().Name}' (id={objComponent.ID}).", blnCondition: true);
			}
			c6cde426f87a1b2ca1cf005c54ff47761.Add(objComponent.ID, objComponent);
			objComponent.RegisterContextMenu();
			if (objComponent is IControl control)
			{
				RegisterBatch(control.Controls);
			}
			objComponent.IsRegistered = true;
			objComponent.RegisterComponents();
		}

		private bool IsRegisteredComponent(IRegisteredComponent objComponent)
		{
			if (!(objComponent is IRequiresRegistration))
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			Type type = objComponent.GetType();
			if (mobjValidComponents.ContainsKey(type))
			{
				return mobjValidComponents[type];
			}
			object obj = mobjValidComponentsLock;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (!mobjValidComponents.ContainsKey(type))
				{
					/*OpCode not supported: LdMemberToken*/;
					Type[] registeredControls = HostRuntime.Config.RegisteredControls;
					foreach (Type type2 in registeredControls)
					{
						if (!(type == type2))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						return mobjValidComponents[type] = true;
					}
					return mobjValidComponents[type] = false;
				}
				return mobjValidComponents[type];
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
		}

		public void UnRegisterComponent(IRegisteredComponent objComponent)
		{
			if (!objComponent.IsRegistered)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!c371e0db5909d312669b7b89a30fa1396.SessionTracing.RegistrationTrace)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VerboseRecord.Write("Server", "Session/Registry", "Unregistering", $"Component of type '{objComponent.GetType().Name}' (id={objComponent.ID}).", blnCondition: true);
			}
			c6cde426f87a1b2ca1cf005c54ff47761.Remove(objComponent.ID);
			objComponent.IsRegistered = false;
			objComponent.UnregisterContextMenu();
			objComponent.UnregisterComponents();
		}

		public void RegisterBatch(ICollection objCollection)
		{
			IEnumerator enumerator = objCollection.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					IRegisteredComponent objComponent = (IRegisteredComponent)enumerator.Current;
					RegisterComponent(objComponent);
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
		}

		public void UnRegisterBatch(ICollection objCollection)
		{
			foreach (IRegisteredComponent item in objCollection)
			{
				UnRegisterComponent(item);
			}
		}

		public IRegisteredComponent GetRegisteredComponent(string strComponentId)
		{
			long result = -1L;
			if (long.TryParse(strComponentId, out result))
			{
				return ((ISessionRegistry)this).GetRegisteredComponent(result);
			}
			return null;
		}

		public IRegisteredComponent GetRegisteredComponent(long lngComponentId)
		{
			if (!c6cde426f87a1b2ca1cf005c54ff47761.ContainsKey(lngComponentId))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return c6cde426f87a1b2ca1cf005c54ff47761[lngComponentId];
		}

		IEnumerator ISessionRegistry.GetEnumerator()
		{
			return c6cde426f87a1b2ca1cf005c54ff47761.Values.GetEnumerator();
		}

		internal void LoadInitializationData(NameValueCollection objData)
		{
			try
			{
				int num;
				if (objData["DOR"] == "0")
				{
					/*OpCode not supported: LdMemberToken*/;
					num = 1;
				}
				else
				{
					num = 0;
				}
				menmStartupDeviceOrientation = (DeviceOrientation)num;
				mintScreenAvailableHeight = int.Parse(objData["SAH"]);
				mintScreenAvailableWidth = int.Parse(objData["SAW"]);
				mintScreenHeight = int.Parse(objData["SCH"]);
				mintScreenWidth = int.Parse(objData["SCW"]);
				mintScreenColorDepth = int.Parse(objData["SCD"]);
				string text = objData["SDPR"];
				if (!string.IsNullOrEmpty(text) && CommonUtils.TryParse(text, out double dblValue))
				{
					mintScreenDevicePixelRatio = Convert.ToInt32(dblValue);
				}
				mintBrowserHeight = int.Parse(objData["BRH"]);
				mintBrowserWidth = int.Parse(objData["BRW"]);
			}
			catch
			{
			}
		}

		internal void LoadBrowserId()
		{
			try
			{
				IDeviceRepository provider = CommonUtils.GetProvider<IDeviceRepository>(GetDefaultDeviceRepositoryString(), blnIsCache: true);
				if (provider == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrBrowserId = provider.GetBrowserId(HostContext.Current);
				}
			}
			catch
			{
			}
		}

		internal bool HandleException(Exception objException)
		{
			switch (UnhandledExceptionMode)
			{
			case UnhandledExceptionMode.ThrowException:
				return false;
			case UnhandledExceptionMode.Automatic:
				if (!HasUnhandledExceptionHandlers)
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				((IApplicationContext)this).OnThreadException(objException);
				return true;
			case UnhandledExceptionMode.CatchException:
				return true;
			}
			return false;
		}

		internal void FireApplicationThreadRefresh()
		{
			if (ThreadRefreshHandler != null)
			{
				ThreadRefreshHandler(this, EventArgs.Empty);
			}
		}

		internal void FireApplicationThreadTick()
		{
			if (ThreadTickHandler != null)
			{
				ThreadTickHandler(this, EventArgs.Empty);
			}
		}

		internal void FireApplicationIdle()
		{
			if (IdleHandler != null)
			{
				IdleHandler(this, EventArgs.Empty);
			}
		}

		internal void FireApplicationApplicationExit()
		{
			if (ApplicationExitHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ApplicationExitHandler(this, EventArgs.Empty);
			}
		}

		private void FireApplicationThreadSuspend()
		{
			if (ThreadSuspendHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ThreadSuspendHandler(this, EventArgs.Empty);
			}
		}

		internal void FireApplicationThreadExit()
		{
			if (ThreadExitHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ThreadExitHandler(this, EventArgs.Empty);
			}
		}

		internal void InitializeMainFormSize()
		{
			InitializeFormSize(MainForm);
		}

		private void InitializeFormSize(IForm objForm)
		{
			if (objForm == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (mintBrowserWidth != -1)
			{
				objForm.Width = mintBrowserWidth;
			}
			if (mintBrowserHeight != -1)
			{
				objForm.Height = mintBrowserHeight;
			}
		}

		public MappedFormInfo GetMappedFormInfo(Type objSourceFormType)
		{
			return GetMappedFormInfo(objSourceFormType, mstrBrowserId);
		}

		private MappedFormInfo GetMappedFormInfo(Type objSourceFormType, string strBrowserId)
		{
			MappedFormInfo mappedFormInfo = null;
			if (strBrowserId == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mobjMappedForms == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				object obj = mobjMappedFormsLock;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (mobjMappedForms != null)
					{
						if (!mobjMappedForms.ContainsKey(strBrowserId))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!mobjMappedForms[strBrowserId].ContainsKey(objSourceFormType))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mappedFormInfo = mobjMappedForms[strBrowserId][objSourceFormType];
						}
					}
					else
					{
						mobjMappedForms = MappedFormsLoader.GetMappedFormsList();
						if (!mobjMappedForms.ContainsKey(strBrowserId))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (mobjMappedForms[strBrowserId].ContainsKey(objSourceFormType))
						{
							mappedFormInfo = mobjMappedForms[strBrowserId][objSourceFormType];
						}
					}
				}
				finally
				{
					if (!lockTaken)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Monitor.Exit(obj);
					}
				}
			}
			else if (!mobjMappedForms.ContainsKey(strBrowserId))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!mobjMappedForms[strBrowserId].ContainsKey(objSourceFormType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mappedFormInfo = mobjMappedForms[strBrowserId][objSourceFormType];
			}
			if (mappedFormInfo == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (strBrowserId != null)
				{
					IDeviceRepository provider = CommonUtils.GetProvider<IDeviceRepository>(GetDefaultDeviceRepositoryString(), blnIsCache: true);
					if (provider == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						string browserParentId = provider.GetBrowserParentId(strBrowserId);
						if (browserParentId != null)
						{
							return GetMappedFormInfo(objSourceFormType, browserParentId);
						}
					}
				}
				return new MappedFormInfo(objSourceFormType.AssemblyQualifiedName, null);
			}
			return mappedFormInfo;
		}

		internal string GetBrowserParentId(string strBrowserId)
		{
			try
			{
				IDeviceRepository provider = CommonUtils.GetProvider<IDeviceRepository>(GetDefaultDeviceRepositoryString(), blnIsCache: true);
				if (provider != null)
				{
					return provider.GetBrowserParentId(strBrowserId);
				}
			}
			catch
			{
			}
			return null;
		}

		internal string GetBrowserId(HostContext objContext)
		{
			try
			{
				IDeviceRepository provider = CommonUtils.GetProvider<IDeviceRepository>(GetDefaultDeviceRepositoryString(), blnIsCache: true);
				if (provider != null)
				{
					return provider.GetBrowserId(objContext);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			catch
			{
			}
			return null;
		}

		void IContextParams.InvokeComponentMessage(object sender, ComponentMessageEventArgs e)
		{
			Delegate handler = GetHandler(ComponentMessageEvent);
			if ((object)handler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			Delegate[] invocationList = handler.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				invocationList[i].DynamicInvoke(sender, e);
			}
		}

		FormAccessMode IContextParams.GetFormAccessMode(IForm objForm)
		{
			string fullName = objForm.GetType().FullName;
			if (!FormAccessModes.ContainsKey(fullName))
			{
				IFormsSecurityProvider provider = CommonUtils.GetProvider<IFormsSecurityProvider>("Gizmox.WebGUI.Common.Forms.Security.SimpleSecurityProvider, Gizmox.WebGUI.Common", blnIsCache: true);
				return FormAccessModes[fullName] = provider.GetFormAccessMode(objForm);
			}
			return FormAccessModes[fullName];
		}

		~ContextContainer()
		{
			Dispose(disposing: false);
		}

		private void Dispose(bool disposing)
		{
			if (!disposing)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (c9c0b127d9609e396a2f14de32e3864d3)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c9c0b127d9609e396a2f14de32e3864d3 = true;
			if (ThreadExitHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ThreadExitHandler(this, EventArgs.Empty);
			}
			if (ApplicationExitHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ApplicationExitHandler(this, EventArgs.Empty);
			}
		}

		void IDisposable.Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		internal EventProcessor GetEventProcessor()
		{
			if (c0b80cda3b33a914716e26fe0bfa78d9f != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0b80cda3b33a914716e26fe0bfa78d9f = new EventProcessor(this);
			}
			return c0b80cda3b33a914716e26fe0bfa78d9f;
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
			if (!(objEvent is c389104d09ae3e4cf7ac5587082a5647d c389104d09ae3e4cf7ac5587082a5647d))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objEvent is c374a3936366b6f158df4c740a52c0f05 c374a3936366b6f158df4c740a52c0f)
				{
					c374a3936366b6f158df4c740a52c0f.Invoke();
					return;
				}
				string type = objEvent.Type;
				if (!(type == "NavigateBookmark"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					NavigateBookmark(int.Parse(objEvent["VLB"]));
				}
			}
			else
			{
				ShowForm(c389104d09ae3e4cf7ac5587082a5647d.Form, c389104d09ae3e4cf7ac5587082a5647d.Context);
			}
		}

		internal void ShowForm(IForm objForm, HostContext objContext)
		{
			try
			{
				objForm.Visible = true;
				if (ActiveForm == null)
				{
					objForm.Active = true;
				}
			}
			catch (Exception objException)
			{
				HandleApplicationException(objException, objContext);
			}
		}

		internal void HandleApplicationException(Exception objException, HostContext objHostContext)
		{
			if (objException == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (((IApplicationContext)this).HandleThreadException(objException))
				{
					return;
				}
				if (!objHostContext.IsCustomErrorEnabled)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (objException is HttpException)
					{
						throw objException;
					}
					throw new HttpException(objException.Message, objException);
				}
				HandleCustomErrors(objException);
			}
		}

		private void HandleCustomErrors(Exception objException)
		{
			CustomErrorsSection customErrorsSection = null;
			try
			{
				customErrorsSection = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
			}
			catch (SecurityException)
			{
				throw new HttpException(500, "Visual WebGui server cannot process custom error pages. Check the trust level within your web.config file. Required trust level is Full or High or custom with granted ConfigurationPermission.", objException);
			}
			if (customErrorsSection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string text = customErrorsSection.DefaultRedirect;
			CustomError customError = customErrorsSection.Errors[GetHttpCodeForException(objException).ToString(CultureInfo.InvariantCulture)];
			if (customError == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = customError.Redirect;
			}
			if (!string.IsNullOrEmpty(text))
			{
				RedirectToUrl = text;
				IsTerminated = true;
			}
		}

		private int GetHttpCodeForException(Exception objException)
		{
			if (!(objException is HttpException))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objException is UnauthorizedAccessException)
				{
					return 401;
				}
				/*OpCode not supported: LdMemberToken*/;
				if (objException is PathTooLongException)
				{
					return 414;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int httpCode = ((HttpException)objException).GetHttpCode();
				if (httpCode > 0)
				{
					return httpCode;
				}
			}
			if (objException.InnerException == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 500;
			}
			return GetHttpCodeForException(objException.InnerException);
		}

		internal void RegisterForm(IForm objForm)
		{
			mobjNavigationForms.Add(objForm);
		}

		internal void UnRegisterForm(IForm objForm)
		{
			mobjNavigationForms.Remove(objForm);
		}
	}
}
namespace A
{
	internal class c908eaefa54d6b5be30c4c863d79037e1
	{
		internal static byte[] cc2ad4aa851b5f88a873f3f558265da16(Stream c286e8b84f07343a2f7ce638bbe7e7941)
		{
			byte b = (byte)c286e8b84f07343a2f7ce638bbe7e7941.ReadByte();
			byte[] array = new byte[c286e8b84f07343a2f7ce638bbe7e7941.Length - 1];
			c286e8b84f07343a2f7ce638bbe7e7941.Read(array, 0, array.Length);
			if ((b & 1) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				byte[] array2 = new byte[8];
				Buffer.BlockCopy(array, 0, array2, 0, 8);
				dESCryptoServiceProvider.IV = array2;
				byte[] array3 = new byte[8];
				Buffer.BlockCopy(array, 8, array3, 0, 8);
				bool flag = true;
				byte[] array4 = array3;
				for (int i = 0; i < array4.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (array4[i] != 0)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array3 = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
				}
				dESCryptoServiceProvider.Key = array3;
				array = dESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 16, array.Length - 16);
			}
			if ((b & 2) == 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				try
				{
					MemoryStream memoryStream = new MemoryStream(array);
					DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
					MemoryStream memoryStream2 = new MemoryStream((int)memoryStream.Length * 2);
					int num = 1000;
					byte[] buffer = new byte[num];
					while (true)
					{
						int num2 = deflateStream.Read(buffer, 0, num);
						if (num2 > 0)
						{
							memoryStream2.Write(buffer, 0, num2);
						}
						if (num2 < num)
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					array = memoryStream2.ToArray();
				}
				catch (Exception)
				{
				}
			}
			return array;
		}
	}
	internal class cff226624b4ce0bb76d1f43eb8c1f9407
	{
		private ILink cef1d1e7f26a27499c8e39883af099edf;

		private ILinkParameters cbf23f3f8d49acbe9a181ea8d9d36cd19;

		public ILink Link => cef1d1e7f26a27499c8e39883af099edf;

		public ILinkParameters Parameters => cbf23f3f8d49acbe9a181ea8d9d36cd19;

		public cff226624b4ce0bb76d1f43eb8c1f9407(ILink objLink)
		{
			cef1d1e7f26a27499c8e39883af099edf = objLink;
		}

		public cff226624b4ce0bb76d1f43eb8c1f9407(ILink objLink, ILinkParameters objLinkParameters)
		{
			cef1d1e7f26a27499c8e39883af099edf = objLink;
			cbf23f3f8d49acbe9a181ea8d9d36cd19 = objLinkParameters;
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	internal class ContextTimers : IEventHandler, IRegisteredComponent, ITimerHandler
	{
		private Dictionary<int, ITimer> mobjTimers;

		private int mintUniqueTimerId;

		private bool mblnIsRegistered;

		private long mlngGuid;

		private readonly ContextContainer mobjContextContainer;

		private int mintEventTimerResult = -1;

		public bool HasTimers
		{
			get
			{
				if (mobjTimers == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return false;
				}
				return mobjTimers.Count > 0;
			}
		}

		bool IRegisteredComponent.IsRegistered
		{
			get
			{
				return mblnIsRegistered;
			}
			set
			{
				mblnIsRegistered = value;
			}
		}

		bool IRegisteredComponent.IsConnected => true;

		long IRegisteredComponent.ID
		{
			get
			{
				return mlngGuid;
			}
			set
			{
				mlngGuid = value;
			}
		}

		RegisteredState IRegisteredComponent.RegisteredState
		{
			get
			{
				RegisteredState registeredState = RegisteredState.Unregistered;
				if (mlngGuid != 0L)
				{
					registeredState = RegisteredState.Identified;
				}
				if (mblnIsRegistered)
				{
					registeredState |= RegisteredState.Registered;
				}
				return registeredState;
			}
		}

		public ContextTimers(ContextContainer objContextContainer)
		{
			mobjContextContainer = objContextContainer;
		}

		public void AddTimer(ITimer objTimer)
		{
			if (mobjTimers != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjTimers = new Dictionary<int, ITimer>();
			}
			if (objTimer.TimerID != -1)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mintUniqueTimerId++;
				objTimer.TimerID = mintUniqueTimerId;
			}
			if (!mobjTimers.ContainsKey(objTimer.TimerID))
			{
				mobjTimers[objTimer.TimerID] = objTimer;
				if (!CommonSwitches.TraceVerbose)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					VerboseRecord.Write("Timers", "Server/Timers", "Register", "A timer has been registered (interval=" + objTimer.Interval + ")");
				}
			}
		}

		public void RemoveTimer(ITimer objTimer)
		{
			if (objTimer == null)
			{
				return;
			}
			if (mobjTimers == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mobjTimers.ContainsKey(objTimer.TimerID))
			{
				mobjTimers.Remove(objTimer.TimerID);
				if (CommonSwitches.TraceVerbose)
				{
					VerboseRecord.Write("Timers", "Server/Timers", "Unregister", "A timer has been unregistered.");
				}
			}
		}

		public int InvokeTimers(long lngCurrentTicks)
		{
			if (mobjTimers != null && mobjTimers.Count > 0)
			{
				int num = 0;
				foreach (ITimer item in new List<ITimer>(mobjTimers.Values))
				{
					int num2 = item.GetNextInvokation(lngCurrentTicks);
					if (num2 >= 30)
					{
						/*OpCode not supported: LdMemberToken*/;
						VerboseRecord.Write("Timers", "Server/Timers", "Invoke", "intTimerNextInvokation=" + num2);
					}
					else
					{
						if (!CommonSwitches.TraceVerbose)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							VerboseRecord.Write("Timers", "Server/Timers", "Invoke", "Invoke timer.");
						}
						num2 = InvokeTimer(item);
					}
					if (num2 >= 100)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num == 0)
						{
							num = num2;
						}
						else if (num > num2)
						{
							num = num2;
						}
					}
					else
					{
						num = 100;
					}
				}
				if (num > 120000)
				{
					num = 120000;
				}
				return num;
			}
			return 0;
		}

		private int InvokeTimer(ITimer objTimer)
		{
			if (!(ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread"))
			{
				/*OpCode not supported: LdMemberToken*/;
				return objTimer.InvokeTimer();
			}
			mintEventTimerResult = -1;
			EventProcessor eventProcessor = mobjContextContainer.GetEventProcessor();
			eventProcessor.Enqueue(new c374a3936366b6f158df4c740a52c0f05(this, objTimer));
			eventProcessor.Process();
			return mintEventTimerResult;
		}

		internal void InvokeTimerAsEvent(ITimer objTimer)
		{
			mintEventTimerResult = objTimer.InvokeTimer();
		}

		public int GetNextInvokation(long lngCurrentTicks)
		{
			if (mobjTimers != null)
			{
				if (mobjTimers.Count > 0)
				{
					int num = 120000;
					using Dictionary<int, ITimer>.ValueCollection.Enumerator enumerator = mobjTimers.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						int nextInvokation = enumerator.Current.GetNextInvokation(lngCurrentTicks);
						if (nextInvokation < num)
						{
							if (nextInvokation <= 2000)
							{
								/*OpCode not supported: LdMemberToken*/;
								num = 2000;
							}
							else
							{
								num = nextInvokation;
							}
						}
					}
					return num;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return 120000;
		}

		void IEventHandler.FireEvent(IEvent objEvent)
		{
		}

		void IRegisteredComponent.UnregisterContextMenu()
		{
		}

		void IRegisteredComponent.UnregisterComponents()
		{
		}

		void IRegisteredComponent.RegisterContextMenu()
		{
		}

		void IRegisteredComponent.RegisterComponents()
		{
		}
	}
	[Serializable]
	internal class Cookies : ICookies
	{
		private HostContext mobjHostContext;

		private HostRequestInfo mobjRequestInfo;

		public string this[string strKey]
		{
			get
			{
				HostCookie hostCookie = mobjHostContext.Request.Cookies[strKey];
				if (hostCookie != null)
				{
					return hostCookie.Value;
				}
				return "";
			}
			set
			{
				bool flag = true;
				string[] allKeys = mobjHostContext.Response.Cookies.AllKeys;
				for (int i = 0; i < allKeys.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(allKeys[i] == strKey))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					flag = false;
					break;
				}
				string value2 = null;
				HostCookie hostCookie;
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
					hostCookie = mobjHostContext.Response.Cookies[strKey];
					value2 = hostCookie.Value;
					hostCookie.Value = value;
				}
				else
				{
					hostCookie = mobjHostContext.Response.Cookies.Create(strKey, value);
					hostCookie.Path = mobjRequestInfo.ApplicationRelativePath;
					mobjHostContext.Response.Cookies.Add(hostCookie);
				}
				if (GetCookiesSize(mobjHostContext.Request.Cookies, mobjHostContext.Response.Cookies) > 4095)
				{
					if (!flag)
					{
						/*OpCode not supported: LdMemberToken*/;
						hostCookie.Value = value2;
					}
					else
					{
						mobjHostContext.Response.Cookies.Remove(strKey);
					}
					throw new ApplicationException("Cookies size cannot exceed 4kb.");
				}
				hostCookie.Expires = DateTime.Now.AddYears(1);
			}
		}

		public Cookies(HostContext objHostContext, HostRequestInfo objRequestInfo)
		{
			mobjHostContext = objHostContext;
			mobjRequestInfo = objRequestInfo;
		}

		private int GetCookiesSize(HostCookieCollection requestCookies, HostCookieCollection responseCookies)
		{
			Hashtable hashtable = new Hashtable();
			string text = string.Empty;
			string text2 = string.Empty;
			for (int i = 0; i < responseCookies.Count; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				HostCookie hostCookie = responseCookies[i];
				if (ce7877c7ee4c3060c535e119111a8c060.IsHttpOnlyCookie(hostCookie))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (hashtable.ContainsKey(hostCookie.Name))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					hashtable.Add(hostCookie.Name, true);
				}
				text = text + text2 + hostCookie.Name + "=" + hostCookie.Value;
				text2 = "; ";
			}
			for (int j = 0; j < requestCookies.Count; j++)
			{
				/*OpCode not supported: LdMemberToken*/;
				HostCookie hostCookie2 = requestCookies[j];
				if (!ce7877c7ee4c3060c535e119111a8c060.IsHttpOnlyCookie(hostCookie2))
				{
					if (!(hostCookie2.Name != "ASP.NET_SessionId"))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (hashtable.ContainsKey(hostCookie2.Name))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					text = text + text2 + hostCookie2.Name + "=" + hostCookie2.Value;
					text2 = "; ";
				}
			}
			return text.Length;
		}
	}
}
namespace A
{
	internal class c0c355030c647d69d6d5b626a5c3e6e60 : HostHttpHandler
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		private string c0b97e5a6f41263c18a6f50d219f1b751 = string.Empty;

		private string c9d776e9f46495317b5eca1aed07554d6 = string.Empty;

		public string Message
		{
			get
			{
				return c9d776e9f46495317b5eca1aed07554d6;
			}
			set
			{
				c9d776e9f46495317b5eca1aed07554d6 = value;
			}
		}

		public string Source
		{
			get
			{
				return c0b97e5a6f41263c18a6f50d219f1b751;
			}
			set
			{
				c0b97e5a6f41263c18a6f50d219f1b751 = value;
			}
		}

		internal c0c355030c647d69d6d5b626a5c3e6e60(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			IResponseWriter objXmlWriter = null;
			((IServerResponse)c8f695bda1002ddbedbc6a2bfcf6960a0.Response).WriteError(Source, Message, ref objXmlWriter);
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	internal class Event : EventArgs, IEvent
	{
		private readonly string mstrType = string.Empty;

		private readonly string mstrValue = string.Empty;

		private readonly string mstrSource = string.Empty;

		private readonly string mstrTarget = string.Empty;

		private readonly string mstrMember = string.Empty;

		private readonly Keys menmModifierKeys;

		private readonly int mintCursorPositionX;

		private readonly int mintCursorPositionY;

		private string[] mstrAttributeNames;

		private string[] mstrAttributeValues;

		private int mintAttributeLength;

		public string Type => mstrType;

		public string Value => mstrValue;

		public string Member => mstrMember;

		public string Source => mstrSource;

		public string Target => mstrTarget;

		public string this[string strParam]
		{
			get
			{
				switch (strParam)
				{
				case "SR":
					/*OpCode not supported: LdMemberToken*/;
					return mstrSource;
				case "TRG":
					/*OpCode not supported: LdMemberToken*/;
					return mstrTarget;
				case "TP":
					return mstrType;
				case "MM":
					return mstrMember;
				default:
				{
					for (int i = 0; i < mintAttributeLength; i++)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!string.Equals(mstrAttributeNames[i], strParam, StringComparison.InvariantCulture))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						return mstrAttributeValues[i];
					}
					return string.Empty;
				}
				}
			}
		}

		public Keys KeyCode
		{
			get
			{
				if (!Contains("KC"))
				{
					/*OpCode not supported: LdMemberToken*/;
					return Keys.None;
				}
				return (Keys)Enum.Parse(typeof(Keys), this["KC"]);
			}
		}

		public bool AltKey => (menmModifierKeys & Keys.Alt) != 0;

		public bool ControlKey => (menmModifierKeys & Keys.Control) != 0;

		public bool ShiftKey => (menmModifierKeys & Keys.Shift) != 0;

		public Point CursorPosition => new Point(mintCursorPositionX, mintCursorPositionY);

		internal Event(XPathNavigator objNavigator)
		{
			double dblValue = 0.0;
			if (objNavigator == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			mstrValue = objNavigator.Value;
			if (!objNavigator.MoveToFirstAttribute())
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			while (true)
			{
				string name = objNavigator.Name;
				uint num = c03836b967832c5af40c98cf7300bc21d.ComputeStringHash(name);
				if (num > 1071631567)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num <= 1210393485)
					{
						if (num == 1193615866)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (name == "CPX")
							{
								/*OpCode not supported: LdMemberToken*/;
								if (CommonUtils.TryParse(objNavigator.Value, out dblValue))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									mintCursorPositionX = 0;
								}
								mintCursorPositionX = Convert.ToInt32(dblValue);
								goto IL_037b;
							}
						}
						else if (num == 1210393485)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (name == "CPY")
							{
								if (CommonUtils.TryParse(objNavigator.Value, out dblValue))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									mintCursorPositionY = 0;
								}
								mintCursorPositionY = Convert.ToInt32(dblValue);
								goto IL_037b;
							}
						}
						goto IL_02d1;
					}
					if (num != 1694669136)
					{
						if (num != 3629662412u || !(name == "TRG"))
						{
							goto IL_02d1;
						}
						/*OpCode not supported: LdMemberToken*/;
						mstrTarget = objNavigator.Value;
					}
					else
					{
						if (!(name == "SR"))
						{
							goto IL_02d1;
						}
						mstrSource = objNavigator.Value;
					}
				}
				else if (num == 687173353)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(name == "TP"))
					{
						goto IL_02d1;
					}
					/*OpCode not supported: LdMemberToken*/;
					mstrType = objNavigator.Value;
				}
				else if (num == 828403533)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(name == "MDK"))
					{
						goto IL_02d1;
					}
					try
					{
						menmModifierKeys = (Keys)Enum.Parse(typeof(Keys), objNavigator.Value);
					}
					catch (ArgumentNullException)
					{
					}
					catch (ArgumentException)
					{
					}
					catch (OverflowException)
					{
					}
				}
				else
				{
					if (num != 1071631567 || !(name == "MM"))
					{
						goto IL_02d1;
					}
					mstrMember = objNavigator.Value;
				}
				goto IL_037b;
				IL_02d1:
				if (mintAttributeLength == 0)
				{
					mstrAttributeNames = new string[4];
					mstrAttributeValues = new string[4];
				}
				else if (mstrAttributeValues.Length != mintAttributeLength)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mstrAttributeValues = RealocArray(mstrAttributeValues, mintAttributeLength * 2);
					mstrAttributeNames = RealocArray(mstrAttributeNames, mintAttributeLength * 2);
				}
				mstrAttributeNames[mintAttributeLength] = objNavigator.Name;
				mstrAttributeValues[mintAttributeLength] = objNavigator.Value;
				mintAttributeLength++;
				goto IL_037b;
				IL_037b:
				if (!objNavigator.MoveToNextAttribute())
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}

		private string[] RealocArray(string[] arrOldArray, int intNewLength)
		{
			string[] array = new string[intNewLength];
			arrOldArray.CopyTo(array, 0);
			return array;
		}

		public bool Contains(string strParam)
		{
			return !string.IsNullOrEmpty(this[strParam]);
		}
	}
}
namespace A
{
	internal class c389104d09ae3e4cf7ac5587082a5647d : IEvent
	{
		private readonly IForm cd275fcc4030f7ba15a6ca41e6185befc;

		private readonly HostContext c8f695bda1002ddbedbc6a2bfcf6960a0;

		public IForm Form => cd275fcc4030f7ba15a6ca41e6185befc;

		public HostContext Context => c8f695bda1002ddbedbc6a2bfcf6960a0;

		string IEvent.Source => "0";

		string IEvent.Member => string.Empty;

		string IEvent.Type => "$Load";

		string IEvent.Target => string.Empty;

		string IEvent.Value => string.Empty;

		string IEvent.this[string strParam] => string.Empty;

		Keys IEvent.KeyCode => Keys.None;

		bool IEvent.AltKey => false;

		bool IEvent.ControlKey => false;

		bool IEvent.ShiftKey => false;

		public Point CursorPosition => Point.Empty;

		public c389104d09ae3e4cf7ac5587082a5647d(IForm objForm, HostContext objContext)
		{
			cd275fcc4030f7ba15a6ca41e6185befc = objForm;
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		bool IEvent.Contains(string strParam)
		{
			return false;
		}
	}
	internal class c374a3936366b6f158df4c740a52c0f05 : IEvent
	{
		private readonly ContextTimers c5850c886415c91c2d4e533cac8eaaf7a;

		private readonly ITimer c149db771e6bedf48a94d30433d64453f;

		internal ContextTimers ContextTimers => c5850c886415c91c2d4e533cac8eaaf7a;

		public ITimer Timer => c149db771e6bedf48a94d30433d64453f;

		string IEvent.Source => "0";

		string IEvent.Value => string.Empty;

		string IEvent.Member => string.Empty;

		string IEvent.Type => "$Timer";

		string IEvent.Target => string.Empty;

		string IEvent.this[string strParam] => string.Empty;

		Keys IEvent.KeyCode => Keys.None;

		bool IEvent.AltKey => false;

		bool IEvent.ControlKey => false;

		bool IEvent.ShiftKey => false;

		public Point CursorPosition => Point.Empty;

		public c374a3936366b6f158df4c740a52c0f05(ContextTimers contextTimers, ITimer objTimer)
		{
			c5850c886415c91c2d4e533cac8eaaf7a = contextTimers;
			c149db771e6bedf48a94d30433d64453f = objTimer;
		}

		bool IEvent.Contains(string strParam)
		{
			return false;
		}

		internal void Invoke()
		{
			c5850c886415c91c2d4e533cac8eaaf7a.InvokeTimerAsEvent(c149db771e6bedf48a94d30433d64453f);
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	internal class EventProcessor : IContextThreadingService
	{
		private class c62f5849854222385ef56e1893b2527e8
		{
			private readonly HttpContext ca9d5358fd7023c6f55d0597e68d14c51;

			private readonly Thread ca4ce3d0df2793c0637bc9a4ee3dbce87;

			public HttpContext HttpContext => ca9d5358fd7023c6f55d0597e68d14c51;

			public c62f5849854222385ef56e1893b2527e8(Thread objRequestThread, HttpContext objHttpContext)
			{
				ca4ce3d0df2793c0637bc9a4ee3dbce87 = objRequestThread;
				ca9d5358fd7023c6f55d0597e68d14c51 = objHttpContext;
			}

			public void ApplyRequestInfo()
			{
				HttpContext.Current = ca9d5358fd7023c6f55d0597e68d14c51;
				Thread currentThread = Thread.CurrentThread;
				if (currentThread != null)
				{
					currentThread.CurrentCulture = ca4ce3d0df2793c0637bc9a4ee3dbce87.CurrentCulture;
					currentThread.CurrentUICulture = ca4ce3d0df2793c0637bc9a4ee3dbce87.CurrentUICulture;
				}
			}
		}

		private Thread mobjProcessingThread;

		private c62f5849854222385ef56e1893b2527e8 mobjRequestProcessorInfo;

		private Queue<IEvent> mobjProcessingQueue = new Queue<IEvent>();

		private IEvent mobjCurrentProcessedEvent;

		private Dictionary<IForm, Queue<IEvent>> mobjSuspendedQueues = new Dictionary<IForm, Queue<IEvent>>();

		private bool mblnIsProcessingEvent;

		private Stack<IForm> mobjModalForms = new Stack<IForm>();

		private bool mblnClosingModalForm;

		private object mobjThreadManipulationLock = new object();

		private readonly ContextContainer mobjOwner;

		public bool IsProcessing
		{
			get
			{
				if (mobjProcessingQueue.Count > 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!mblnIsProcessingEvent)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!mblnClosingModalForm)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (mobjModalForms.Count <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							IForm form = mobjModalForms.Peek();
							if (form == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								if (!form.IsModalActive)
								{
									return true;
								}
								/*OpCode not supported: LdMemberToken*/;
							}
						}
						return false;
					}
					return true;
				}
				return true;
			}
		}

		public EventProcessor(ContextContainer objOwner)
		{
			mobjOwner = objOwner;
		}

		private void Process(IEvent objEvent)
		{
			if (objEvent == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			IEventHandler eventHandler = null;
			if (!(objEvent.Source == "0"))
			{
				/*OpCode not supported: LdMemberToken*/;
				eventHandler = ((ISessionRegistry)mobjOwner).GetRegisteredComponent(objEvent.Source);
			}
			else
			{
				eventHandler = mobjOwner;
			}
			if (eventHandler == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!CommonSwitches.TraceVerbose)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				VerboseRecord.Write(eventHandler, "Server/Events", objEvent.Type, "Invoking event handler.");
			}
			mobjCurrentProcessedEvent = objEvent;
			try
			{
				eventHandler.FireEvent(objEvent);
			}
			catch (Exception objThreadException)
			{
				if (!(VWGContext.Current is IApplicationContext applicationContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					applicationContext.HandleThreadException(objThreadException);
				}
			}
			finally
			{
				mblnClosingModalForm = false;
				mobjCurrentProcessedEvent = null;
			}
		}

		private void ProcessEvents()
		{
			ProcessEvents(blnReleaseThread: true);
		}

		private void ProcessEvents(bool blnReleaseThread)
		{
			try
			{
				if (mobjProcessingQueue.Count <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					mobjRequestProcessorInfo = null;
					return;
				}
				if (mobjRequestProcessorInfo == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjRequestProcessorInfo.ApplyRequestInfo();
					mobjRequestProcessorInfo = null;
				}
				IEvent objEvent = mobjProcessingQueue.Dequeue();
				mblnIsProcessingEvent = true;
				try
				{
					Process(objEvent);
				}
				finally
				{
					mblnIsProcessingEvent = false;
				}
			}
			finally
			{
				if (!blnReleaseThread)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjProcessingThread = null;
				}
			}
		}

		internal void Process()
		{
			if (mobjProcessingThread != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjProcessingThread = new Thread(ProcessEvents);
				mobjProcessingThread.Start();
			}
			while (IsProcessing)
			{
				/*OpCode not supported: LdMemberToken*/;
				Thread.Sleep(1);
			}
		}

		private void AttachThread(Thread objCurrentThread)
		{
			mobjRequestProcessorInfo = new c62f5849854222385ef56e1893b2527e8(Thread.CurrentThread, HttpContext.Current);
		}

		internal void Enqueue(IEvent objEvent)
		{
			AttachThread(Thread.CurrentThread);
			mobjProcessingQueue.Enqueue(objEvent);
		}

		private bool ReleaseQueue(IForm objForm)
		{
			if (!mobjSuspendedQueues.ContainsKey(objForm))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Queue<IEvent> queue = mobjSuspendedQueues[objForm];
				mobjSuspendedQueues.Remove(objForm);
				if (queue.Count > 0)
				{
					IContext context = objForm.Context;
					if (context != null)
					{
						if (!(context.Request is IRequestParams { Events: var events }))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (events == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							Queue<IEvent> queue2 = new Queue<IEvent>();
							while (events.Count > 0)
							{
								/*OpCode not supported: LdMemberToken*/;
								queue2.Enqueue(events.Dequeue());
							}
							while (queue.Count > 0)
							{
								/*OpCode not supported: LdMemberToken*/;
								events.Enqueue(queue.Dequeue());
							}
							while (queue2.Count > 0)
							{
								/*OpCode not supported: LdMemberToken*/;
								events.Enqueue(queue2.Dequeue());
							}
						}
					}
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		private bool SuspendQueue(IForm objForm)
		{
			IContext context = objForm.Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (context.Request is IRequestParams { Events: var events })
				{
					Queue<IEvent> queue = new Queue<IEvent>();
					if (events != null)
					{
						while (events.Count > 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							queue.Enqueue(events.Dequeue());
						}
					}
					mobjSuspendedQueues[objForm] = queue;
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		void IContextThreadingService.ReleaseDialog(IForm objForm)
		{
			ReleaseQueue(objForm);
		}

		DialogResult IContextThreadingService.GetDialogResult(IForm objForm)
		{
			if (objForm == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return DialogResult.None;
			}
			if (!SuspendQueue(objForm))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				mobjModalForms.Push(objForm);
				mblnClosingModalForm = false;
				mblnIsProcessingEvent = false;
				while (objForm.IsModalActive)
				{
					/*OpCode not supported: LdMemberToken*/;
					ProcessEvents(blnReleaseThread: false);
					Thread.Sleep(1);
				}
				mblnClosingModalForm = true;
				mobjModalForms.Pop();
			}
			return objForm.DialogResult;
		}
	}
	[Serializable]
	internal class EventQueue : Queue<IEvent>, IEventCollection, ICollection, IEnumerable
	{
		internal EventQueue()
		{
		}

		IEvent IEventCollection.Dequeue()
		{
			return Dequeue();
		}

		IEvent IEventCollection.Peek()
		{
			return Peek();
		}

		void IEventCollection.Enqueue(IEvent objEvent)
		{
			Enqueue(objEvent);
		}
	}
	[Serializable]
	internal class LoginHelper
	{
		private Dictionary<string, bool> marrLoggedOnPageMap = new Dictionary<string, bool>();

		public bool IsLoggedOn
		{
			get
			{
				string key = "NonSystemPages";
				if (!(VWGContext.Current is IContextParams contextParams))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!contextParams.SystemPages.Contains(contextParams.CurrentPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					key = contextParams.CurrentPageName;
				}
				return marrLoggedOnPageMap.ContainsKey(key);
			}
			set
			{
				string key = "NonSystemPages";
				if (!(VWGContext.Current is IContextParams contextParams))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!contextParams.SystemPages.Contains(contextParams.CurrentPageName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					key = contextParams.CurrentPageName;
				}
				if (value)
				{
					marrLoggedOnPageMap[key] = true;
				}
				else
				{
					marrLoggedOnPageMap.Remove(key);
				}
			}
		}
	}
	public class Manifest : HostHttpHandler, ISkinable, IRequiresSessionState
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		string ISkinable.Theme => c8f695bda1002ddbedbc6a2bfcf6960a0.CurrentTheme;

		public Manifest(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public override void ProcessRequest(HostContext context)
		{
			context.Response.Buffer = false;
			context.Response.ContentType = "text/xml";
			context.Response.CacheControl = "no-cache";
			context.Response.AddHeader("Pragma", "no-cache");
			context.Response.Expires = -1;
			XmlTextWriter xmlTextWriter = new XmlTextWriter(context.Response.OutputStream, context.Response.ContentEncoding);
			xmlTextWriter.Namespaces = true;
			xmlTextWriter.WriteStartDocument(standalone: true);
			xmlTextWriter.WriteStartElement("MFT");
			xmlTextWriter.WriteStartElement("TS");
			Type[] registeredControls = HostRuntime.Config.RegisteredControls;
			for (int i = 0; i < registeredControls.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type objControlType = registeredControls[i];
				WriteManifestControl(objControlType, xmlTextWriter);
			}
			xmlTextWriter.WriteEndElement();
			WriteManifestSections(xmlTextWriter);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
		}

		protected virtual void WriteManifestControl(Type objControlType, XmlTextWriter objXmlWriter)
		{
			string tag = Metadata.GetTag(objControlType, blnThrowError: false);
			if (tag == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			objXmlWriter.WriteStartElement("TG");
			objXmlWriter.WriteAttributeString("N", tag);
			WriteManifestAttributes(objControlType, objXmlWriter);
			WriteManifestContent(objControlType, objXmlWriter);
			objXmlWriter.WriteEndElement();
		}

		protected virtual void WriteManifestSections(XmlTextWriter objXmlWriter)
		{
		}

		protected virtual void WriteManifestAttributes(Type objControlType, XmlTextWriter objXmlWriter)
		{
		}

		protected virtual void WriteManifestContent(Type objControlType, XmlTextWriter objXmlWriter)
		{
		}
	}
}
namespace A
{
	internal class cd3a470667f73191a4881f7d757bf0439 : HostHttpHandler
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		public cd3a470667f73191a4881f7d757bf0439(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public override void ProcessRequest(HostContext context)
		{
			string arg = "";
			string text = context.Request.QueryString["method"];
			if (!(text == "token"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				arg = Guid.NewGuid().ToString();
			}
			context.Response.Write(string.Format("mobjVWGInstances[{0}].{1}('{2}');", context.Request.QueryString["instace"], context.Request.QueryString["callback"], arg));
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	public class Preload : HostHttpHandler, IRequiresSessionState
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		protected override bool SupportsGZip => true;

		private bool IsPreloadArgumnetsLoaded
		{
			get
			{
				IContextParams context = Context;
				if (context != null)
				{
					return context.CSS3BrowserCapabilities != CSS3BrowserCapabilities.Empty;
				}
				return false;
			}
		}

		public new bool IsReusable => false;

		protected Context Context => c8f695bda1002ddbedbc6a2bfcf6960a0;

		public Preload(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			IRequestParams requestParams = (IRequestParams)Context.Request;
			CheckValidEnvironment();
			CheckValidApplication(requestParams);
			Global.Context = Context;
			try
			{
				if (requestParams.IsUserPostback)
				{
					((IContextTerminate)Context).Terminate(blnForce: true);
				}
				if (objHostContext.Request.Form["vwginit"] != "1")
				{
					if (Context.Arguments != null)
					{
						/*OpCode not supported: LdMemberToken*/;
						NameValueCollection nameValueCollection = new ArgumentsProvider(objHostContext.Request);
						IEnumerator enumerator = nameValueCollection.Keys.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								string name = (string)enumerator.Current;
								Context.Arguments[name] = nameValueCollection[name];
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
					}
					else
					{
						Context.Arguments = new ArgumentsProvider(objHostContext.Request);
					}
				}
				if (!requestParams.IsUserPostback)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (c8f695bda1002ddbedbc6a2bfcf6960a0.IsStatelessApplication)
					{
						string currentTheme = Context.CurrentTheme;
						CSS3BrowserCapabilities cSS3BrowserCapabilities = CSS3BrowserCapabilities.None;
						MISCBrowserCapabilities mISCBrowserCapabilities = MISCBrowserCapabilities.None;
						HTML5BrowserCapabilities hTML5BrowserCapabilities = HTML5BrowserCapabilities.None;
						IContextParams context = Context;
						if (context == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mISCBrowserCapabilities = context.MISCBrowserCapabilities;
							cSS3BrowserCapabilities = context.CSS3BrowserCapabilities;
							hTML5BrowserCapabilities = context.HTML5BrowserCapabilities;
						}
						((IContextTerminate)Context).Terminate(blnForce: true);
						Context.CurrentTheme = currentTheme;
						if (context == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (mISCBrowserCapabilities == MISCBrowserCapabilities.None)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								context.MISCBrowserCapabilities = mISCBrowserCapabilities;
							}
							if (cSS3BrowserCapabilities == CSS3BrowserCapabilities.None)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								context.CSS3BrowserCapabilities = cSS3BrowserCapabilities;
							}
							if (hTML5BrowserCapabilities == HTML5BrowserCapabilities.None)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								context.HTML5BrowserCapabilities = hTML5BrowserCapabilities;
							}
						}
					}
				}
				else
				{
					VerboseRecord.Write(this, "Server/Context/Arguments", "Setting", "Setting the 'Context.Arguments' property to reflect external arguments.");
					Context.Referrer = objHostContext.Request.Form["Referrer"];
				}
				if (requestParams.IsUserPostback)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!((Request)requestParams).PageInstanceWasForced)
					{
						if (HandleSSOLogonRequest(objHostContext))
						{
							/*OpCode not supported: LdMemberToken*/;
							return;
						}
						objHostContext.Response.Expires = -1;
						objHostContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
						objHostContext.Response.ContentType = "text/html";
						string text = null;
						if (!IsSupportedBrowser(objHostContext))
						{
							if (Context.RenderStaticSEOContent(objHostContext))
							{
								/*OpCode not supported: LdMemberToken*/;
								return;
							}
							text = GetUnsupportedBrowserFileName();
						}
						if (!IsTimeoutRequest(requestParams))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text = GetTimeoutFileName();
						}
						if (text != null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text = GetBrowserFileName(objHostContext);
						}
						Context.EmulationService?.OnPreload();
						SkinFactory.WriteSkinResource(Context, objHostContext.Response.OutputStream, text, objHostContext.Request.QueryString);
						return;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				string text2 = objHostContext.Request.Url.GetLeftPart(UriPartial.Path);
				int num = text2.IndexOf("/post.", StringComparison.InvariantCultureIgnoreCase);
				if (num <= -1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					text2 = text2.Substring(0, num + 1) + text2.Substring(num + 6);
				}
				string pageInstance = requestParams.PageInstance;
				if (!string.IsNullOrEmpty(pageInstance))
				{
					text2 = ((!text2.Contains("?")) ? $"{text2}?vwginstance={pageInstance}" : $"{text2}&vwginstance={pageInstance}");
				}
				objHostContext.Response.Redirect(text2);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void HandleSSOLogonPostRequest(HostContext objHostContext)
		{
			if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			HostRequest request = objHostContext.Request;
			if (request == null)
			{
				return;
			}
			string value = request.QueryString["vwgssologonpost"];
			if (string.IsNullOrEmpty(value))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			bool result = false;
			if (!bool.TryParse(value, out result))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!result)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			IContextParams context = Context;
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				context.SSOData = new NameValueCollection(objHostContext.Request.Form);
			}
		}

		private bool HandleSSOLogonRequest(HostContext objHostContext)
		{
			bool result = false;
			if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				HostRequest request = objHostContext.Request;
				if (request == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string value = request.QueryString["vwgssologon"];
					if (string.IsNullOrEmpty(value))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						bool result2 = false;
						if (!bool.TryParse(value, out result2))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!result2)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							string authenticationFormType = Context.AuthenticationFormType;
							if (string.IsNullOrEmpty(authenticationFormType))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								Type type = Type.GetType(authenticationFormType);
								if (!(type != null))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else if (type.GetCustomAttributes(typeof(SSOFormAttribute), inherit: true).Length != 1)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									PropertyInfo[] properties = type.GetProperties();
									if (properties == null)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else if (properties.Length == 0)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										List<SSOFieldAttribute> list = new List<SSOFieldAttribute>();
										PropertyInfo[] array = properties;
										for (int i = 0; i < array.Length; i++)
										{
											/*OpCode not supported: LdMemberToken*/;
											object[] customAttributes = array[i].GetCustomAttributes(typeof(SSOFieldAttribute), inherit: true);
											if (customAttributes != null)
											{
												if (customAttributes.Length != 1)
												{
													/*OpCode not supported: LdMemberToken*/;
												}
												else if (customAttributes[0] is SSOFieldAttribute item)
												{
													list.Add(item);
												}
											}
										}
										if (list.Count <= 0)
										{
											/*OpCode not supported: LdMemberToken*/;
										}
										else
										{
											Context.RequestProcessingState = RequestProcessingState.PreRenderResponse;
											Context.RequestProcessingState = RequestProcessingState.RenderResponse;
											objHostContext.Response.ContentType = "text/html";
											objHostContext.Response.Expires = -1;
											HtmlTextWriter htmlTextWriter = new HtmlTextWriter(new StreamWriter(objHostContext.Response.OutputStream, Encoding.UTF8));
											if (htmlTextWriter == null)
											{
												/*OpCode not supported: LdMemberToken*/;
											}
											else
											{
												htmlTextWriter.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
												htmlTextWriter.WriteBeginTag("html");
												htmlTextWriter.WriteAttribute("lang", Context.CurrentUICulture.TwoLetterISOLanguageName);
												htmlTextWriter.Write(">");
												htmlTextWriter.WriteFullBeginTag("head");
												htmlTextWriter.WriteFullBeginTag("title");
												htmlTextWriter.Write("Login");
												htmlTextWriter.WriteEndTag("title");
												htmlTextWriter.WriteEndTag("head");
												htmlTextWriter.WriteFullBeginTag("body");
												htmlTextWriter.WriteBeginTag("form");
												htmlTextWriter.WriteAttribute("method", "post");
												htmlTextWriter.WriteAttribute("action", $"{Context.CurrentPageName}?vwgssologonpost=true");
												htmlTextWriter.Write(">");
															using (List<SSOFieldAttribute>.Enumerator enumerator = list.GetEnumerator())
												{
													while (enumerator.MoveNext())
													{
														/*OpCode not supported: LdMemberToken*/;
														SSOFieldAttribute current = enumerator.Current;
														htmlTextWriter.WriteBeginTag("label");
														htmlTextWriter.WriteAttribute("for", current.FieldName);
														htmlTextWriter.Write(">");
														if (!string.IsNullOrEmpty(current.FieldCaption))
														{
															htmlTextWriter.Write(current.FieldCaption);
														}
														else
														{
															htmlTextWriter.WriteAttribute("style", "display:none;");
															htmlTextWriter.Write(current.FieldName);
														}
														htmlTextWriter.WriteEndTag("label");
														htmlTextWriter.WriteBeginTag("input");
														htmlTextWriter.WriteAttribute("id", current.FieldName);
														htmlTextWriter.WriteAttribute("name", current.FieldName);
														htmlTextWriter.WriteAttribute("type", Convert.ToString(current.FieldType).ToLower());
														htmlTextWriter.Write("/>");
																	htmlTextWriter.Write("<br/>");
													}
												}
												htmlTextWriter.WriteBeginTag("input");
												htmlTextWriter.WriteAttribute("type", "submit");
												htmlTextWriter.WriteAttribute("value", WGLabels.Submit);
												htmlTextWriter.Write("/>");
												htmlTextWriter.WriteEndTag("form");
												htmlTextWriter.WriteEndTag("body");
												htmlTextWriter.WriteEndTag("html");
												htmlTextWriter.Flush();
											}
											Context.RequestProcessingState = RequestProcessingState.PostRrenderResponse;
											result = true;
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		protected void LoadPreloadArgumnets(HostContext objHostContext)
		{
			if (objHostContext == null)
			{
				return;
			}
			string s = objHostContext.Request.Form["SCH"];
			string s2 = objHostContext.Request.Form["SCW"];
			string s3 = objHostContext.Request.Form["SAW"];
			string s4 = objHostContext.Request.Form["SAW"];
			string s5 = objHostContext.Request.Form["SCD"];
			string s6 = objHostContext.Request.Form["BRH"];
			string s7 = objHostContext.Request.Form["BRW"];
			string s8 = objHostContext.Request.Form["CSS3"];
			string s9 = objHostContext.Request.Form["H5"];
			string s10 = objHostContext.Request.Form["MSC"];
			int result = -1;
			int result2 = -1;
			int result3 = -1;
			int result4 = -1;
			int result5 = -1;
			int result6 = -1;
			int result7 = -1;
			int result8 = -1;
			int result9 = -1;
			int result10 = -1;
			if (!int.TryParse(s, out result))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!int.TryParse(s2, out result2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!int.TryParse(s3, out result3))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!int.TryParse(s4, out result4))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!int.TryParse(s5, out result5) || !int.TryParse(s6, out result6))
				{
					return;
				}
				if (!int.TryParse(s7, out result7))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!int.TryParse(s8, out result8))
					{
						return;
					}
					if (!int.TryParse(s9, out result9))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (int.TryParse(s10, out result10))
					{
						IContextParams context = Context;
						if (context != null)
						{
							context.CSS3BrowserCapabilities = (CSS3BrowserCapabilities)Enum.ToObject(typeof(CSS3BrowserCapabilities), result8);
							context.HTML5BrowserCapabilities = (HTML5BrowserCapabilities)Enum.ToObject(typeof(HTML5BrowserCapabilities), result9);
							context.MISCBrowserCapabilities = (MISCBrowserCapabilities)Enum.ToObject(typeof(MISCBrowserCapabilities), result10);
							Context.LoadServerSideBrowserCapabilities(objHostContext);
							Context.LoadInitializationData(objHostContext.Request.Form);
						}
					}
				}
			}
		}

		private void CheckValidEnvironment()
		{
			if (Context.SessionStateMode != SessionStateMode.Off)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new HttpException(500, "Visual WebGui server cannot operate in a session without state. Check that session state mode is not set to off <sessionState mode=\"Off\"/> within your web.config file.");
		}

		private bool IsTimeoutRequest(IRequestParams objRequest)
		{
			string text = string.Empty;
			if (objRequest == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = objRequest.Page.ToLowerInvariant();
			}
			return text == "timeout";
		}

		protected virtual bool IsSupportedBrowser(HostContext objHostContext)
		{
			if (HostRuntime.Config.VerifyBrowserSupport)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!CommonUtils.IsNullOrEmpty(objHostContext.Request.UserAgent))
				{
					if (objHostContext.Request.UserAgent.IndexOf("Netscape") != -1)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (objHostContext.Request.UserAgent.IndexOf("Mozilla") != -1)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (objHostContext.Request.UserAgent.IndexOf("MSIE") == -1)
					{
						if (objHostContext.Request.UserAgent.IndexOf("WebKit") != -1)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (objHostContext.Request.UserAgent.IndexOf("Opera") == -1)
							{
								goto IL_00f6;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
					}
					return true;
				}
				goto IL_00f6;
			}
			return true;
			IL_00f6:
			return false;
		}

		protected virtual void CheckValidApplication(IRequestParams objRequest)
		{
			if (IsTimeoutRequest(objRequest))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (HostRuntime.Config.CheckApplication(objRequest.Page))
			{
				throw new c4b9d8940357a2004f101d96253adea63();
			}
		}

		protected virtual string GetUnsupportedBrowserFileName()
		{
			return "Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Messages.Unsupported.htm";
		}

		protected virtual string GetTimeoutFileName()
		{
			return "Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Messages.Timeout.htm";
		}

		protected virtual string GetDebugPreloadFrameFileName()
		{
			return "Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Debug.Preload.htm";
		}

		private string GetBrowserFileName(HostContext objHostContext)
		{
			HandleSSOLogonPostRequest(objHostContext);
			if (!(objHostContext.Request.Form["vwginit"] == "1"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (c371e0db5909d312669b7b89a30fa1396.ShowDebugger.Enabled)
				{
					if (objHostContext.Request.QueryString["debug"] != "1")
					{
						return GetDebugPreloadFrameFileName();
					}
					/*OpCode not supported: LdMemberToken*/;
					if (!IsPreloadArgumnetsLoaded)
					{
						return GetPreloadFrameFileName();
					}
				}
				else if (!IsPreloadArgumnetsLoaded)
				{
					return GetPreloadFrameFileName();
				}
			}
			else
			{
				LoadPreloadArgumnets(objHostContext);
				Context.LoadBrowserId();
			}
			return GetBrowserFileName();
		}

		protected virtual string GetPreloadFrameFileName()
		{
			return "Gizmox.WebGUI.Forms.Skins.CommonSkin.Preload.htm";
		}

		protected virtual string GetBrowserFileName()
		{
			return "Gizmox.WebGUI.Forms.Skins.CommonSkin.Commons.Dialogs.Main.htm";
		}
	}
	[Serializable]
	internal class Request : INonSerializable, IRequest, IRequestParams
	{
		private Context mobjContext;

		private string mstrRequestTrace = string.Empty;

		private long mlngLastRender;

		private bool mblnHasEvents;

		private XPathDocument mobjDocument;

		private XPathNavigator mobjNavigator;

		private EventQueue mobjEvents;

		private HostRequestInfo mobjRequestInfo;

		public bool IsCompressionRequired => mobjRequestInfo.IsCompressionRequested;

		public bool IsUserPostback => mobjRequestInfo.IsUserPostbackRequest;

		public bool IsPostback => mobjRequestInfo.IsPostbackRequest;

		public RequestType Type => mobjRequestInfo.PageType;

		public string Page => mobjRequestInfo.PageName;

		public string PageInstance => mobjRequestInfo.PageInstance;

		public string WebSocketConnectionId => mobjRequestInfo.WebSocketConnectionId;

		public Uri HttpsRedirectionUri => mobjRequestInfo.HttpsRedirectionUri;

		public bool PageInstanceWasForced => mobjRequestInfo.PageInstanceWasForced;

		public bool HasEvents => mblnHasEvents;

		public string Resource => mobjRequestInfo.PageResource;

		public IEventCollection Events => mobjEvents;

		public long LastRender => mlngLastRender;

		internal string ClientTrace
		{
			get
			{
				return mstrRequestTrace;
			}
			set
			{
				mstrRequestTrace = value;
			}
		}

		internal Request(HostContext objHostContext, Context objContext, HostRequestInfo objRequestInfo)
		{
			mobjContext = objContext;
			mobjRequestInfo = objRequestInfo;
			if (mobjRequestInfo.PageType != RequestType.Content)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!mobjRequestInfo.IsPostbackRequest)
				{
					return;
				}
				try
				{
					mobjEvents = ce7877c7ee4c3060c535e119111a8c060.GetEvents(mobjContext, objHostContext, out mlngLastRender);
					if (mobjEvents == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (mobjEvents.Count <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						mblnHasEvents = true;
					}
					if (CommonSwitches.TraceEnabled)
					{
						if (mobjNavigator == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							mstrRequestTrace = mobjNavigator.GetAttribute("Trace", "");
						}
					}
				}
				catch
				{
					mblnHasEvents = false;
				}
			}
		}
	}
	[Serializable]
	internal class Response : INonSerializable, IResponse, IServerResponse
	{
		private Context mobjContext;

		private Stream mobjOutputStream;

		private string mstrGeneralPrefix = WGConst.Prefix;

		private string mstrGeneralNamespace = WGConst.Namespace;

		private string mstrControlsPrefix = WGConst.ControlsPrefix;

		private string mstrControlsNamespace = WGConst.ControlsNamespace;

		private ArrayList mobjTraces;

		private bool mblnTrace = true;

		private string mstrSessionId = "";

		private HostContext mobjHostContext;

		public string GeneralNamespacePrefix => mstrGeneralPrefix;

		public string GeneralNamespaceUrl => mstrGeneralNamespace;

		public string ControlsNamespacePrefix => mstrControlsPrefix;

		public string ControlsNamespaceUrl => mstrControlsNamespace;

		private Context Context => mobjContext;

		internal Response(HostContext objHostContext, Context objContext)
		{
			if (((Request)objContext.Request).Type != RequestType.Gateway)
			{
				objHostContext.Response.ContentType = "text/xml";
			}
			mstrSessionId = objHostContext.Session.SessionID;
			mobjOutputStream = objHostContext.Response.OutputStream;
			mobjContext = objContext;
			mobjHostContext = objHostContext;
		}

		public void Start(long lngLastRender, int intNextInvokationTime, ref IResponseWriter objResponseWriter, bool blnRenderParams, long intActiveFormGuid)
		{
			if (objResponseWriter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objResponseWriter = new ce018c227db41322d626ccf24fa858c9c(mobjOutputStream, Context.HostContext.Response.ContentEncoding);
			}
			XmlTextWriter xmlTextWriter = (XmlTextWriter)objResponseWriter;
			xmlTextWriter.Namespaces = true;
			xmlTextWriter.WriteStartDocument(standalone: true);
			xmlTextWriter.WriteStartElement(GeneralNamespacePrefix, "R", GeneralNamespaceUrl);
			xmlTextWriter.WriteAttributeString("LR", lngLastRender.ToString());
			xmlTextWriter.WriteAttributeString("AF", intActiveFormGuid.ToString());
			xmlTextWriter.WriteAttributeString("xmlns", "WC", "http://www.w3.org/2000/xmlns/", WGConst.ControlsNamespace);
			if (intNextInvokationTime <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				xmlTextWriter.WriteAttributeString("TM", intNextInvokationTime.ToString());
			}
			if (blnRenderParams)
			{
				xmlTextWriter.WriteAttributeString("Ext", HostRuntime.Config.DynamicExtension);
				if (c371e0db5909d312669b7b89a30fa1396.ShowEvents.Enabled)
				{
					xmlTextWriter.WriteAttributeString("Events", "1");
				}
				xmlTextWriter.WriteAttributeString("V", WGConst.Version);
				if (c371e0db5909d312669b7b89a30fa1396.ShowClientErrors.Enabled)
				{
					xmlTextWriter.WriteAttributeString("DM", "1");
				}
				if (!CommonSwitches.TraceEnabled)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!CommonSwitches.TraceInfo)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					xmlTextWriter.WriteAttributeString("Trace", "1");
				}
				if (!HostRuntime.Config.InlineWindows)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					xmlTextWriter.WriteAttributeString("InlineWindows", "1");
				}
			}
		}

		public void End(IResponseWriter objResponseWriter)
		{
			XmlTextWriter xmlTextWriter = (XmlTextWriter)objResponseWriter;
			if (CommonSwitches.TraceEnabled)
			{
				WriteTraces(xmlTextWriter);
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}

		public void WriteRefresh(ref IResponseWriter objResponseWriter)
		{
			if (objResponseWriter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objResponseWriter = new ce018c227db41322d626ccf24fa858c9c(mobjOutputStream, Context.HostContext.Response.ContentEncoding);
			}
			XmlTextWriter obj = (XmlTextWriter)objResponseWriter;
			obj.Namespaces = true;
			obj.WriteStartDocument(standalone: true);
			obj.WriteStartElement(GeneralNamespacePrefix, "RE", GeneralNamespaceUrl);
			obj.WriteEndElement();
			obj.WriteEndDocument();
			obj.Flush();
			obj.Close();
		}

		public void WriteClosed(ref IResponseWriter objResponseWriter)
		{
			if (objResponseWriter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objResponseWriter = new ce018c227db41322d626ccf24fa858c9c(mobjOutputStream, mobjHostContext.Response.ContentEncoding);
			}
			XmlTextWriter xmlTextWriter = (XmlTextWriter)objResponseWriter;
			xmlTextWriter.Namespaces = true;
			xmlTextWriter.WriteStartDocument(standalone: true);
			xmlTextWriter.WriteStartElement(GeneralNamespacePrefix, "R", GeneralNamespaceUrl);
			if (!(Context.RedirectToUrl == string.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
				xmlTextWriter.WriteAttributeString("RedirectToUrl", Context.RedirectToUrl);
			}
			else
			{
				xmlTextWriter.WriteAttributeString("Refferer", Context.Referrer);
				string[] allKeys = Context.Results.AllKeys;
				for (int i = 0; i < allKeys.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = allKeys[i];
					xmlTextWriter.WriteStartElement(GeneralNamespacePrefix, "R", GeneralNamespaceUrl);
					xmlTextWriter.WriteAttributeString("N", text);
					xmlTextWriter.WriteAttributeString("VLB", Context.Results[text]);
					xmlTextWriter.WriteEndElement();
				}
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}

		public void Trace(string strMessage)
		{
			Trace("General", strMessage);
		}

		public void Trace(string strSubject, string strMessage)
		{
			if (mblnTrace)
			{
				if (mobjTraces != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					mobjTraces = new ArrayList();
				}
				mobjTraces.Add(strSubject + "..." + strMessage);
			}
		}

		public void WriteTraces(XmlTextWriter objResponseWriter)
		{
			objResponseWriter.WriteStartElement(GeneralNamespacePrefix, "Traces", GeneralNamespaceUrl);
			if (!mblnTrace)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (mobjTraces == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IEnumerator enumerator = mobjTraces.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						string value = (string)enumerator.Current;
						objResponseWriter.WriteStartElement("Trace");
						objResponseWriter.WriteAttributeString("Message", value);
						objResponseWriter.WriteEndElement();
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
			}
			objResponseWriter.WriteEndElement();
		}

		public void WriteError(string strSource, string strMessage, ref IResponseWriter objResponseWriter)
		{
			if (objResponseWriter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objResponseWriter = new ce018c227db41322d626ccf24fa858c9c(mobjOutputStream, mobjHostContext.Response.ContentEncoding);
			}
			XmlTextWriter obj = (XmlTextWriter)objResponseWriter;
			obj.WriteStartElement(GeneralNamespacePrefix, "Error", GeneralNamespaceUrl);
			obj.WriteElementString("Source", strSource);
			obj.WriteElementString("Message", strMessage);
			obj.WriteEndElement();
			End(objResponseWriter);
		}

		public void WriteException(Exception objException, ref IResponseWriter objResponseWriter)
		{
			WriteError(objException.Source, objException.Message, ref objResponseWriter);
		}
	}
}
namespace A
{
	internal class ce018c227db41322d626ccf24fa858c9c : XmlTextWriter, IAttributeWriter, INonSerializable, IResponseWriter
	{
		private static char[] c56cc4188fcd683111449ad12ea49073b = new char[2] { '\\', 'n' };

		private static char[] ce16fc40c473decd29a8df7169b3b91ad = new char[2] { '\\', 'r' };

		private static char[] c4737418ecea9165421adde5c8722b921 = new char[2] { '\\', 't' };

		private static char[] c7012280e3981a199ba9bfe636d486860 = new char[2] { '\\', 'b' };

		private static char[] cca334f5903acfbbc724a6e91cb47978e = new char[2] { '\\', '\\' };

		private const int c5a3c1835a1e99cad1bb4b2ee8aa6f966 = 0;

		private const int cb62e5408c0248015396aa037515b6c8e = 1;

		private const int c761d9d16fe3b749eb992ec3afc1d7256 = 2;

		public ce018c227db41322d626ccf24fa858c9c(Stream objStream, Encoding objEncoding)
			: base(objStream, objEncoding)
		{
		}

		public ce018c227db41322d626ccf24fa858c9c(TextWriter objTextWriter)
			: base(objTextWriter)
		{
		}

		void IAttributeWriter.WriteAttributeString(string strAttribute, int intValue)
		{
			WriteAttributeString(strAttribute, intValue.ToString());
		}

		void IAttributeWriter.WriteAttributeString(string strAttribute, bool blnValue)
		{
			WriteAttributeString(strAttribute, blnValue ? "0" : "1");
		}

		void IAttributeWriter.WriteAttributeString(string strAttribute, double dblValue)
		{
			WriteAttributeString(strAttribute, dblValue.ToString());
		}

		public void WriteAttributeText(string strAttribute, string strText)
		{
			WriteAttributeText(strAttribute, strText, TextFilter.CarriageReturn);
		}

		public void WriteAttributeText(string strAttribute, string strText, TextFilter enmFilter)
		{
			WriteStartAttribute(null, strAttribute, null);
			if (string.IsNullOrEmpty(strText))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int intBufferPosition = 0;
				char[] arrBuffer = new char[20];
				int length = strText.Length;
				int num = 0;
				for (int i = 0; i < length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					char c = strText[i];
					switch (c)
					{
					case '\\':
						FlushBuffer(arrBuffer, ref intBufferPosition);
						WriteChars(cca334f5903acfbbc724a6e91cb47978e, 0, cca334f5903acfbbc724a6e91cb47978e.Length);
						num = 0;
						continue;
					case '\n':
						FlushBuffer(arrBuffer, ref intBufferPosition);
						if ((enmFilter & TextFilter.NewLine) == TextFilter.NewLine)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							WriteChars(c56cc4188fcd683111449ad12ea49073b, 0, c56cc4188fcd683111449ad12ea49073b.Length);
						}
						num = 0;
						continue;
					case '\r':
						FlushBuffer(arrBuffer, ref intBufferPosition);
						if ((enmFilter & TextFilter.CarriageReturn) == TextFilter.CarriageReturn)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							WriteChars(ce16fc40c473decd29a8df7169b3b91ad, 0, ce16fc40c473decd29a8df7169b3b91ad.Length);
						}
						num = 0;
						continue;
					}
					/*OpCode not supported: LdMemberToken*/;
					if (c != '\t')
					{
						/*OpCode not supported: LdMemberToken*/;
						if (c != ' ')
						{
							/*OpCode not supported: LdMemberToken*/;
							if (char.IsControl(c))
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							AppendBuffer(arrBuffer, c, ref intBufferPosition);
							num = 0;
							continue;
						}
						bool flag = false;
						if (i != length - 1 && i != 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							flag = num == 2;
						}
						else
						{
							flag = true;
						}
						if (flag)
						{
							num = 1;
							FlushBuffer(arrBuffer, ref intBufferPosition);
							WriteChars(c7012280e3981a199ba9bfe636d486860, 0, c7012280e3981a199ba9bfe636d486860.Length);
						}
						else
						{
							num = 2;
							AppendBuffer(arrBuffer, ' ', ref intBufferPosition);
						}
					}
					else
					{
						FlushBuffer(arrBuffer, ref intBufferPosition);
						if ((enmFilter & TextFilter.Tab) == TextFilter.Tab)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							WriteChars(c4737418ecea9165421adde5c8722b921, 0, c4737418ecea9165421adde5c8722b921.Length);
						}
						num = 0;
					}
				}
				FlushBuffer(arrBuffer, ref intBufferPosition);
			}
			WriteEndAttribute();
		}

		private void AppendBuffer(char[] arrBuffer, char chrCurrent, ref int intBufferPosition)
		{
			arrBuffer[intBufferPosition] = chrCurrent;
			intBufferPosition++;
			if (arrBuffer.Length != intBufferPosition)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				FlushBuffer(arrBuffer, ref intBufferPosition);
			}
		}

		private void FlushBuffer(char[] arrBuffer, ref int intBufferPosition)
		{
			if (intBufferPosition <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			WriteChars(arrBuffer, 0, intBufferPosition);
			intBufferPosition = 0;
		}

		void IAttributeWriter.WriteAttributeString(string strAttribute, string strValue)
		{
			WriteAttributeString(strAttribute, strValue);
		}

		void IResponseWriter.WriteStartElement(string strElementName)
		{
			WriteStartElement(strElementName);
		}

		void IResponseWriter.WriteAttributeString(string strAttribute, string strValue)
		{
			WriteAttributeString(strAttribute, strValue);
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	public class Router : IRouter, IHttpHandlerFactory
	{
		private static bool mblnHostRuntimeAssigned = false;

		private static object mobjHostRuntimeAssignmentLocking = new object();

		public bool IsReusable => false;

		public Router()
		{
			if (mblnHostRuntimeAssigned)
			{
				return;
			}
			object obj = mobjHostRuntimeAssignmentLocking;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (!mblnHostRuntimeAssigned)
				{
					HostRuntime.Current = CreateHostRuntimeInstance();
					mblnHostRuntimeAssigned = true;
				}
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
		}

		protected virtual HostRuntime CreateHostRuntimeInstance()
		{
			return new HttpHostRuntime();
		}

		void IHttpHandlerFactory.ReleaseHandler(IHttpHandler objHandler)
		{
			ReleaseHttpHandler(objHandler);
		}

		protected virtual void ReleaseHttpHandler(IHttpHandler objHandler)
		{
			if (!(objHandler is IDisposable disposable))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				disposable.Dispose();
			}
		}

		IHttpHandler IHttpHandlerFactory.GetHandler(HttpContext objHttpContext, string strRequestType, string strUrl, string strPathTranslated)
		{
			IHttpHandler httpHandler = null;
			HostContext objHostContext = (HostContext.Current = HttpHostContext.Create(objHttpContext));
			httpHandler = GetHandler(objHostContext);
			if (CommonUtils.IsMono)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!HostRuntime.Config.AspCompatMode)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (httpHandler is c4d3cdb893b7f640a5aa2a40bfe2211b1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(httpHandler is Gateway))
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_006f;
				}
				httpHandler = new AspCompatHandler(httpHandler);
			}
			goto IL_006f;
			IL_006f:
			return httpHandler;
		}

		protected HostHttpHandler GetHandler(HostContext objHostContext)
		{
			HostHttpHandler hostHttpHandler = null;
			Context context = CreateContext(objHostContext);
			if (context.IsRedirectToSSLRequired)
			{
				RedirectToSSL(objHostContext);
				return null;
			}
			try
			{
				return GetHttpHandler(objHostContext, context);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected static void ApplyContentDispositionIfNeeded(HostContext objHttpContext, RequestType enmRequestType)
		{
			if (enmRequestType > RequestType.Content)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (enmRequestType)
				{
				case RequestType.Statistics:
				case RequestType.Preload:
				case RequestType.Capture:
				case RequestType.Mashup:
				case RequestType.Manifest:
					return;
				}
			}
			else
			{
				switch (enmRequestType)
				{
				case RequestType.Unknown:
					/*OpCode not supported: LdMemberToken*/;
					return;
				case RequestType.Content:
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
			}
			string text = objHttpContext.Request.QueryString["content-disposition"];
			if (string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objHttpContext.Response.AddHeader("Content-Disposition", $"attachment; filename={text}");
			}
		}

		private void RedirectToSSL(HostContext objHostContext)
		{
			objHostContext.Response.Redirect(objHostContext.Request.Info.HttpsRedirectionUri.ToString(), endResponse: true);
		}

		protected virtual Context CreateContext(HostContext objHostContext)
		{
			return new Context(objHostContext);
		}

		protected virtual HostHttpHandler GetHttpHandler(HostContext objHostContext, Context objContext)
		{
			RequestType type = ((IRequestParams)objContext.Request).Type;
			if (!CommonUtils.IsMono)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objHostContext.Response.Buffer = false;
			}
			ApplyContentDispositionIfNeeded(objHostContext, type);
			HostHttpHandler result = null;
			switch (type)
			{
			case RequestType.Content:
				result = new c4d3cdb893b7f640a5aa2a40bfe2211b1(objContext);
				break;
			case RequestType.Preload:
				result = new Preload(objContext);
				break;
			case RequestType.Assemblies:
				result = new AssemblyResource(objContext);
				break;
			case RequestType.Types:
				result = new TypeResource(objContext);
				break;
			case RequestType.Skins:
				result = new Gizmox.WebGUI.Server.Resources.SkinResource(objContext);
				break;
			case RequestType.Resources:
				result = new Gizmox.WebGUI.Server.Resources.SkinResource(objContext);
				break;
			case RequestType.Mashup:
				result = new cd3a470667f73191a4881f7d757bf0439(objContext);
				break;
			case RequestType.Manifest:
				result = new Manifest(objContext);
				break;
			case RequestType.Gateway:
				result = new Gateway(objContext);
				break;
			case RequestType.StaticGateway:
				result = new StaticGateway(objContext);
				break;
			case RequestType.Images:
				result = new Gizmox.WebGUI.Server.Resources.FileResource(objContext, "Images", ((IRequestParams)objContext.Request).Page);
				break;
			case RequestType.Icons:
				result = new Gizmox.WebGUI.Server.Resources.FileResource(objContext, "Icons", ((IRequestParams)objContext.Request).Page);
				break;
			case RequestType.Data:
				result = new Gizmox.WebGUI.Server.Resources.FileResource(objContext, "Data", ((IRequestParams)objContext.Request).Page);
				break;
			case RequestType.FrameStyleImage:
				result = new FrameStyleImageResource(objContext);
				break;
			case RequestType.Statistics:
			{
				if (!CommonUtils.IsMono)
				{
					Process currentProcess = Process.GetCurrentProcess();
					objHostContext.Response.Write("StartTime:" + currentProcess.StartTime.ToLongTimeString() + "Gen_");
					objHostContext.Response.Write("PeakMemoryUsed:" + currentProcess.PeakWorkingSet64 / 1024 / 1024 + "mbGen_");
					objHostContext.Response.Write("Age in seconds:" + (DateTime.Now - currentProcess.StartTime).TotalSeconds + "Gen_");
				}
				break;
			}
			}
			return result;
		}

		NameValueCollection IRouter.GetArguments(string strForm, string strInstance)
		{
			NameValueCollection result = null;
			ContextContainer contextContainer = new Session(null).GetContextContainer(strForm, strInstance);
			if (contextContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = contextContainer.Arguments;
			}
			return result;
		}

		NameValueCollection IRouter.GetResults(string strForm, string strInstance)
		{
			NameValueCollection result = null;
			ContextContainer contextContainer = new Session(null).GetContextContainer(strForm, strInstance);
			if (contextContainer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = new ReadOnlyResultsProvider(contextContainer.Results);
			}
			return result;
		}
	}
}
namespace A
{
	internal class c173574dfe7801dce5957ec1ae08dfabb : INonSerializable, IServer
	{
		private HostContext cd431adf28613291c7da2754be3a77468;

		internal c173574dfe7801dce5957ec1ae08dfabb(HostContext objHostContext)
		{
			cd431adf28613291c7da2754be3a77468 = objHostContext;
		}

		public string MapPath(string strPath)
		{
			return cd431adf28613291c7da2754be3a77468.Server.MapPath(strPath);
		}
	}
	internal class c371e0db5909d312669b7b89a30fa1396
	{
		private static BooleanSwitch c72391f530bbf1f562df02bb8741c3731;

		private static BooleanSwitch ce582cea81baed6f3d10f48ce8e3c79f6;

		private static BooleanSwitch ca57dbf53e147389d60d81318feac2fbe;

		private static BooleanSwitch c5381381cd303ddb5de8a288e5a103d06;

		private static BooleanSwitch cd2e35605463f665b584d89a063b86c20;

		private static SessionTracingSwitch c389d669fe2dc357f2aa6b59709958977;

		private static BooleanSwitch cca4829d856a00c24bc92c260aa5c8cbf;

		private static BooleanSwitch c2ee651e7ef33168e867faa69b9fc42a3;

		public static BooleanSwitch DisableObscuring => c72391f530bbf1f562df02bb8741c3731;

		public static BooleanSwitch EnableClientShortcuts => ce582cea81baed6f3d10f48ce8e3c79f6;

		public static BooleanSwitch ShowDebugger => cca4829d856a00c24bc92c260aa5c8cbf;

		public static BooleanSwitch EmulateSessionStateSerialization => c2ee651e7ef33168e867faa69b9fc42a3;

		public static BooleanSwitch ShowEvents => ca57dbf53e147389d60d81318feac2fbe;

		public static BooleanSwitch ShowClientErrors => c5381381cd303ddb5de8a288e5a103d06;

		public static BooleanSwitch DisableCaching => cd2e35605463f665b584d89a063b86c20;

		public static SessionTracingSwitch SessionTracing => c389d669fe2dc357f2aa6b59709958977;

		static c371e0db5909d312669b7b89a30fa1396()
		{
			c72391f530bbf1f562df02bb8741c3731 = new BooleanSwitch("VWG_DisableObscuringSwitch", "Enable client scripts obscuring and compacting.");
			ce582cea81baed6f3d10f48ce8e3c79f6 = new BooleanSwitch("VWG_EnableClientShortcutsSwitch", "Enable client Shortcut.");
			ca57dbf53e147389d60d81318feac2fbe = new BooleanSwitch("VWG_ShowEventsSwitch", "Show client side event alerts.");
			cca4829d856a00c24bc92c260aa5c8cbf = new BooleanSwitch("VWG_ShowDebuggerSwitch", "Show client side debugger.");
			c2ee651e7ef33168e867faa69b9fc42a3 = new BooleanSwitch("VWG_EmulateSessionStateSerializationSwitch", "Emulateses session state serialization.");
			c5381381cd303ddb5de8a288e5a103d06 = new BooleanSwitch("VWG_ShowClientErrorsSwitch", "Show client side errors.");
			cd2e35605463f665b584d89a063b86c20 = new BooleanSwitch("VWG_DisableCachingSwitch", "Disables resource caching.");
			c389d669fe2dc357f2aa6b59709958977 = new SessionTracingSwitch("VWG_SessionTracingSwitch", "Session tracing definitions");
		}
	}
}
namespace Gizmox.WebGUI.Server
{
	[Serializable]
	internal class SessionTracingSwitch : Switch
	{
		public bool RegistrationTrace => (base.SwitchSetting & 1) > 0;

		public bool RegistrationSummaryTrace => (base.SwitchSetting & 2) > 0;

		public SessionTracingSwitch(string strName, string strDescription)
			: base(strName, strDescription)
		{
		}
	}
	[Serializable]
	internal class Session : Gizmox.WebGUI.Common.Interfaces.ISession
	{
		private HostSessionState mobjHttpSession;

		private SessionContainer mobjSessionContainer;

		private SessionContainer SessionContainer
		{
			get
			{
				if (mobjSessionContainer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (mobjHttpSession != null)
				{
					mobjSessionContainer = mobjHttpSession["__vwg_session"] as SessionContainer;
					if (mobjSessionContainer == null)
					{
						mobjHttpSession["__vwg_session"] = (mobjSessionContainer = new SessionContainer());
					}
				}
				else
				{
					mobjSessionContainer = new SessionContainer();
				}
				return mobjSessionContainer;
			}
		}

		public string SessionID => mobjHttpSession.SessionID;

		public bool IsLoggedOn
		{
			get
			{
				return SessionContainer.IsLoggedOn;
			}
			set
			{
				SessionContainer.IsLoggedOn = value;
			}
		}

		public CultureInfo CurrentUICulture
		{
			get
			{
				return SessionContainer.CurrentUICulture;
			}
			set
			{
				SessionContainer.CurrentUICulture = value;
			}
		}

		public object this[string strProperty]
		{
			get
			{
				return mobjHttpSession[strProperty];
			}
			set
			{
				mobjHttpSession[strProperty] = value;
			}
		}

		public bool IsValid => mobjHttpSession != null;

		static Session()
		{
		}

		internal Session(HostContext objHostContext)
		{
			if (objHostContext == null)
			{
				objHostContext = HttpHostContext.Create(HttpContext.Current);
			}
			if (objHostContext != null)
			{
				HostSessionState session = objHostContext.Session;
				if (session != null)
				{
					mobjHttpSession = session;
				}
			}
		}

		internal ContextContainer GetContextContainer(string strKey, string strInstance, bool blnCreateIfNotFound)
		{
			ContextContainer contextContainer = null;
			string contextContainerKey = GetContextContainerKey(strKey, strInstance);
			if (mobjHttpSession == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contextContainer = mobjHttpSession[contextContainerKey] as ContextContainer;
				if (contextContainer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!blnCreateIfNotFound)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					contextContainer = new ContextContainer(strKey);
					mobjHttpSession[contextContainerKey] = contextContainer;
				}
			}
			return contextContainer;
		}

		internal ContextContainer GetContextContainer(string strKey, string strInstance)
		{
			return GetContextContainer(strKey, strInstance, blnCreateIfNotFound: true);
		}

		internal void DeleteContextContainer(string strKey, string strInstance)
		{
			mobjHttpSession.Remove(GetContextContainerKey(strKey, strInstance));
		}

		private string GetContextContainerKey(string strKey, string strInstance)
		{
			if (!string.IsNullOrEmpty(strInstance))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				strInstance = "0";
			}
			return $"__vwg_ctx_{strKey}_{strInstance}";
		}
	}
	[Serializable]
	internal class SessionContainer : SerializableObject
	{
		[NonSerialized]
		private LoginHelper c74879b6b4a4a3d7b0196475325109d8a = new LoginHelper();

		[NonSerialized]
		private CultureInfo c7ce8a52d648ad8c61c4d4cc0656bf66f;

		protected override int SerializableDataInitialSize => 2;

		public bool IsLoggedOn
		{
			get
			{
				return c74879b6b4a4a3d7b0196475325109d8a.IsLoggedOn;
			}
			set
			{
				c74879b6b4a4a3d7b0196475325109d8a.IsLoggedOn = value;
			}
		}

		public CultureInfo CurrentUICulture
		{
			get
			{
				return c7ce8a52d648ad8c61c4d4cc0656bf66f;
			}
			set
			{
				try
				{
					if (value == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Thread.CurrentThread.CurrentUICulture = value;
					}
				}
				catch (Exception)
				{
				}
				c7ce8a52d648ad8c61c4d4cc0656bf66f = value;
			}
		}

		public SessionContainer()
		{
			c7ce8a52d648ad8c61c4d4cc0656bf66f = Thread.CurrentThread.CurrentUICulture;
			if (c7ce8a52d648ad8c61c4d4cc0656bf66f == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c7ce8a52d648ad8c61c4d4cc0656bf66f.IsNeutralCulture)
			{
				c7ce8a52d648ad8c61c4d4cc0656bf66f = CultureInfo.CreateSpecificCulture(c7ce8a52d648ad8c61c4d4cc0656bf66f.Name);
			}
		}

		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			c74879b6b4a4a3d7b0196475325109d8a = (LoginHelper)objReader.ReadObject();
			c7ce8a52d648ad8c61c4d4cc0656bf66f = objReader.ReadCultureInfo();
		}

		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteObject(c74879b6b4a4a3d7b0196475325109d8a);
			objWriter.WriteCultureInfo(c7ce8a52d648ad8c61c4d4cc0656bf66f);
		}
	}
	internal class AspCompatHandler : Page, IHttpAsyncHandler, IHttpHandler, IRequiresSessionState
	{
		private sealed class CompletedAsyncResult : IAsyncResult
		{
			private static readonly WaitHandle c77d3ddf1cce494581bdff10f3c299df4 = new ManualResetEvent(initialState: true);

			public object AsyncState => null;

			public WaitHandle AsyncWaitHandle => c77d3ddf1cce494581bdff10f3c299df4;

			public bool CompletedSynchronously => true;

			public bool IsCompleted => true;

			public static readonly CompletedAsyncResult Instance = new CompletedAsyncResult();
		}

		private IHttpHandler cf43726a9df8a68715ad349493cc1f936;

		internal AspCompatHandler(IHttpHandler objHttpHandler)
		{
			cf43726a9df8a68715ad349493cc1f936 = objHttpHandler;
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (cf43726a9df8a68715ad349493cc1f936 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cf43726a9df8a68715ad349493cc1f936.ProcessRequest(HttpContext.Current);
			}
		}

		public IAsyncResult BeginProcessRequest(HttpContext objContext, AsyncCallback objAsyncCallback, object objExtraData)
		{
			if (cf43726a9df8a68715ad349493cc1f936 != null)
			{
				cf43726a9df8a68715ad349493cc1f936.ProcessRequest(objContext);
			}
			IAsyncResult asyncResult = CompletedAsyncResult.Instance;
			objAsyncCallback?.Invoke(asyncResult);
			return asyncResult;
		}

		public void EndProcessRequest(IAsyncResult objResult)
		{
			_ = objResult;
		}
	}
}
namespace A
{
	internal class c4a194a1d5eede9f56caccd510597e467 : TraceRecord
	{
		private string[] c729771ff2841b23a485df14168ad8c15;

		private Type c798a533b1c141b902aef328d97cdfd46;

		public override string Subject => c729771ff2841b23a485df14168ad8c15[2];

		public override string Description => c729771ff2841b23a485df14168ad8c15[3];

		public override Type Type => c798a533b1c141b902aef328d97cdfd46;

		public override string Section => "Client/Processing";

		internal c4a194a1d5eede9f56caccd510597e467(string strClientRecord, Context objContext)
		{
			c729771ff2841b23a485df14168ad8c15 = strClientRecord.Split(',');
			if (!(c729771ff2841b23a485df14168ad8c15[0] != "0"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IRegisteredComponent registeredComponent = ((ISessionRegistry)objContext).GetRegisteredComponent(c729771ff2841b23a485df14168ad8c15[0]);
				if (registeredComponent == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c798a533b1c141b902aef328d97cdfd46 = registeredComponent.GetType();
				}
			}
			base.Performance = long.Parse(c729771ff2841b23a485df14168ad8c15[1]);
		}
	}
	internal class ce7877c7ee4c3060c535e119111a8c060
	{
		private static Type RouterType => Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.25701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");

		internal static EventQueue GetEvents(Context objContext, string strEvents, out long lngLastRender)
		{
			return GetEvents(objContext, new StringReader(strEvents), out lngLastRender);
		}

		internal static EventQueue GetEvents(Context objContext, HostContext objHostContext, out long lngLastRender)
		{
			return GetEvents(objContext, objHostContext.Request, out lngLastRender);
		}

		internal static EventQueue GetEvents(Context objContext, HostRequest objHostRequest, out long lngLastRender)
		{
			return GetEvents(objContext, objHostRequest.InputStream, out lngLastRender);
		}

		internal static EventQueue GetEvents(Context objContext, Stream objStream, out long lngLastRender)
		{
			return GetEvents(objContext, new StreamReader(objStream), out lngLastRender);
		}

		internal static EventQueue GetEvents(Context objContext, TextReader objTextReader, out long lngLastRender)
		{
			XPathNavigator xPathNavigator = new XPathDocument(objTextReader).CreateNavigator();
			xPathNavigator.MoveToRoot();
			xPathNavigator.MoveToFirstChild();
			if (!(xPathNavigator.LocalName == "ES"))
			{
				/*OpCode not supported: LdMemberToken*/;
				lngLastRender = 0L;
			}
			else
			{
				string attribute = xPathNavigator.GetAttribute("LR", "");
				if (!string.IsNullOrEmpty(attribute))
				{
					/*OpCode not supported: LdMemberToken*/;
					lngLastRender = long.Parse(attribute);
				}
				else
				{
					lngLastRender = 0L;
				}
			}
			return GetEvents(objContext, xPathNavigator);
		}

		internal static EventQueue GetEvents(Context objContext, XPathNavigator objNavigator)
		{
			EventQueue eventQueue = new EventQueue();
			XPathNodeIterator xPathNodeIterator = objNavigator.Select(objNavigator.Compile("E"));
			while (xPathNodeIterator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				eventQueue.Enqueue(new Event(xPathNodeIterator.Current.Clone()));
			}
			return eventQueue;
		}

		public static bool IsNullOrEmpty(string strInput)
		{
			return string.IsNullOrEmpty(strInput);
		}

		public static bool IsHttpOnlyCookie(HostCookie objCookie)
		{
			return objCookie.HttpOnly;
		}

		internal static IRouter GetRouter()
		{
			Type routerType = RouterType;
			if (!(routerType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return Activator.CreateInstance(routerType) as IRouter;
		}
	}
}
namespace Gizmox.WebGUI.Server.Resources
{
	public class AssemblyResource : HostHttpHandler
	{
		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		public new bool IsReusable => false;

		public AssemblyResource(Context objContext)
		{
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
		}

		public virtual bool WriteResourceToStream(HostContext objHostContext, Assembly objAssembly, string strResource)
		{
			EmbededResource embededResource = new EmbededResource(objAssembly, strResource);
			if (embededResource == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			objHostContext.Response.Expires = 10000;
			objHostContext.Response.Cache.SetCacheability(HttpCacheability.Private);
			objHostContext.Response.ContentType = CommonUtils.GetMimeType(strResource);
			embededResource.WriteToStream(objHostContext.Response.OutputStream);
			return true;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			string text = ((IRequestParams)c8f695bda1002ddbedbc6a2bfcf6960a0.Request).Resource;
			string text2 = objHostContext.Request.QueryString["assembly"];
			if (text2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(text2 != string.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Assembly assembly = Assembly.Load(text2);
				if (!(assembly != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string text3 = assembly.GetName().Name + ".";
					if (text.StartsWith(text3))
					{
						text = text.Substring(text3.Length);
					}
					if (WriteResourceToStream(objHostContext, assembly, text))
					{
						return;
					}
				}
			}
			objHostContext.Response.StatusCode = 404;
		}
	}
	public class FileResource : HostHttpHandler
	{
		private string c371b2177b80904d6813b44c347727694;

		private string c5c15416f334984d2521537c5f1392f70;

		private string c2c89d19b44c14e9caa49181b8f41b29a;

		private string c474f3a05a0e7acf0c7a304176b277caf = string.Empty;

		private Context c8f695bda1002ddbedbc6a2bfcf6960a0;

		private static DateTime PastDate => DateTime.MinValue;

		public FileResource(Context objContext, string strType, string strResource)
		{
			c5c15416f334984d2521537c5f1392f70 = strType;
			c2c89d19b44c14e9caa49181b8f41b29a = strResource;
			c8f695bda1002ddbedbc6a2bfcf6960a0 = objContext;
			c371b2177b80904d6813b44c347727694 = ResourceHandle.GetPhysicalFilePath(HttpUtility.UrlDecode(strResource), HostRuntime.Config.GetDirectory(strType));
			if (File.Exists(c371b2177b80904d6813b44c347727694))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string directory = HostRuntime.Config.GetDirectory("Generated");
			if (directory == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			string path = Path.Combine(directory, strType + "." + strResource);
			if (!File.Exists(path))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c371b2177b80904d6813b44c347727694 = path;
			}
		}

		protected virtual void WriteContentType(HostContext objHostContext)
		{
			if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(c2c89d19b44c14e9caa49181b8f41b29a != string.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objHostContext.Response.ContentType = CommonUtils.GetMimeType(c2c89d19b44c14e9caa49181b8f41b29a);
			}
		}

		protected virtual void WriteFile(HostContext objHostContext, string strPath, string strContentType)
		{
			objHostContext.Response.WriteFile(strPath);
		}

		protected virtual bool Exists(string strPath)
		{
			return File.Exists(c371b2177b80904d6813b44c347727694);
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			if (!Exists(c371b2177b80904d6813b44c347727694))
			{
				/*OpCode not supported: LdMemberToken*/;
				objHostContext.Response.StatusCode = 404;
				return;
			}
			DateTime expires = DateTime.Now.AddDays(365.0);
			objHostContext.Response.AddFileDependency(c371b2177b80904d6813b44c347727694);
			objHostContext.Response.Cache.SetExpires(expires);
			objHostContext.Response.Cache.SetETagFromFileDependencies();
			_ = CommonUtils.IsMono;
			objHostContext.Response.Cache.SetValidUntilExpires(validUntilExpires: true);
			objHostContext.Response.Cache.SetCacheability(HttpCacheability.Public);
			objHostContext.Response.Cache.SetMaxAge(new TimeSpan(365, 0, 0, 0));
			objHostContext.Response.Cache.SetProxyMaxAge(new TimeSpan(365, 0, 0, 0));
			WriteContentType(objHostContext);
			WriteFile(objHostContext, c371b2177b80904d6813b44c347727694, c474f3a05a0e7acf0c7a304176b277caf);
		}
	}
	public class FrameStyleImageResource : HostHttpHandler
	{
		protected Context mobjContext;

		public FrameStyleImageResource(Context objContext)
		{
			mobjContext = objContext;
		}

		protected virtual void WriteImage(HostContext objHostContext, Image objImage)
		{
			if (objImage == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (c371e0db5909d312669b7b89a30fa1396.DisableCaching.Enabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				objHostContext.Response.Expires = -1;
			}
			else
			{
				objHostContext.Response.Expires = 10000;
				objHostContext.Response.Cache.SetCacheability(HttpCacheability.Private);
			}
			ImageFormat rawFormat = objImage.RawFormat;
			objHostContext.Response.ContentType = CommonUtils.GetMimeType(rawFormat);
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				objImage.Save(memoryStream, ImageFormat.Png);
				memoryStream.WriteTo(objHostContext.Response.OutputStream);
			}
			finally
			{
				if (memoryStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			if (mobjContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objHostContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!(mobjContext.Request is IRequestParams { Resource: var resource }) || string.IsNullOrEmpty(resource))
				{
					return;
				}
				string text = objHostContext.Request.QueryString["skin"];
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				Type type = Type.GetType(text);
				if (!(type != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				Skin skin = SkinFactory.GetSkin(mobjContext, type);
				if (skin == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				PropertyInfo property = type.GetProperty(resource);
				if (!(property != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				object value = property.GetValue(skin, new object[0]);
				if (value == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				Image frameStyleImage = GetFrameStyleImage(skin, value);
				if (frameStyleImage != null)
				{
					WriteImage(objHostContext, frameStyleImage);
				}
			}
		}

		private Image GetFrameStyleImage(Skin objSkin, object objFrameStyle)
		{
			Image result = null;
			if (objFrameStyle == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Image imageByFramePartProperty = GetImageByFramePartProperty(objSkin, objFrameStyle, "LeftTopStyle");
				Image imageByFramePartProperty2 = GetImageByFramePartProperty(objSkin, objFrameStyle, "TopStyle");
				Image imageByFramePartProperty3 = GetImageByFramePartProperty(objSkin, objFrameStyle, "RightTopStyle");
				Image imageByFramePartProperty4 = GetImageByFramePartProperty(objSkin, objFrameStyle, "LeftStyle");
				Image imageByFramePartProperty5 = GetImageByFramePartProperty(objSkin, objFrameStyle, "CenterStyle");
				Image imageByFramePartProperty6 = GetImageByFramePartProperty(objSkin, objFrameStyle, "RightStyle");
				Image imageByFramePartProperty7 = GetImageByFramePartProperty(objSkin, objFrameStyle, "LeftBottomStyle");
				Image imageByFramePartProperty8 = GetImageByFramePartProperty(objSkin, objFrameStyle, "BottomStyle");
				Image imageByFramePartProperty9 = GetImageByFramePartProperty(objSkin, objFrameStyle, "RightBottomStyle");
				if (imageByFramePartProperty != null)
				{
					if (imageByFramePartProperty2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (imageByFramePartProperty3 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (imageByFramePartProperty4 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (imageByFramePartProperty5 != null)
					{
						if (imageByFramePartProperty6 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (imageByFramePartProperty7 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (imageByFramePartProperty8 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (imageByFramePartProperty9 == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							int maxSize = GetMaxSize(imageByFramePartProperty.Height, imageByFramePartProperty2.Height, imageByFramePartProperty3.Height);
							int maxSize2 = GetMaxSize(imageByFramePartProperty4.Height, 0, imageByFramePartProperty6.Height);
							int maxSize3 = GetMaxSize(imageByFramePartProperty7.Height, imageByFramePartProperty8.Height, imageByFramePartProperty9.Height);
							int maxSize4 = GetMaxSize(imageByFramePartProperty.Width, imageByFramePartProperty4.Width, imageByFramePartProperty7.Width);
							int maxSize5 = GetMaxSize(imageByFramePartProperty2.Width, imageByFramePartProperty5.Width, imageByFramePartProperty8.Width);
							int maxSize6 = GetMaxSize(imageByFramePartProperty3.Width, imageByFramePartProperty6.Width, imageByFramePartProperty9.Width);
							int num = maxSize + maxSize2 + maxSize3;
							int num2 = maxSize4 + maxSize5 + maxSize6;
							if (num <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (num2 <= 0)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								Bitmap bitmap = new Bitmap(num2, num);
								Graphics graphics = Graphics.FromImage(bitmap);
								try
								{
									graphics.DrawImage(imageByFramePartProperty, new Rectangle(0, 0, maxSize4, maxSize));
									graphics.DrawImage(imageByFramePartProperty2, new Rectangle(maxSize4, 0, maxSize5, maxSize));
									graphics.DrawImage(imageByFramePartProperty3, new Rectangle(maxSize4 + maxSize5, 0, maxSize6, maxSize));
									graphics.DrawImage(imageByFramePartProperty4, new Rectangle(0, maxSize, maxSize4, maxSize2));
									graphics.DrawImage(imageByFramePartProperty6, new Rectangle(maxSize4 + maxSize5, maxSize, maxSize6, maxSize2));
									graphics.DrawImage(imageByFramePartProperty7, new Rectangle(0, maxSize + maxSize2, maxSize4, maxSize3));
									graphics.DrawImage(imageByFramePartProperty8, new Rectangle(maxSize4, maxSize + maxSize2, maxSize5, maxSize3));
									graphics.DrawImage(imageByFramePartProperty9, new Rectangle(maxSize4 + maxSize5, maxSize + maxSize2, maxSize6, maxSize3));
								}
								finally
								{
									if (graphics == null)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										((IDisposable)graphics).Dispose();
									}
								}
								result = bitmap;
							}
						}
					}
				}
			}
			return result;
		}

		private int GetMaxSize(int intSize1, int intSize2, int intSize3)
		{
			return Math.Max(Math.Max(intSize1, intSize2), intSize3);
		}

		private Image GetImageByFramePartProperty(Skin objSkin, object objFrameStyle, string strFramePartProperty)
		{
			Image result = null;
			if (objSkin == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objFrameStyle == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (string.IsNullOrEmpty(strFramePartProperty))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object propertyValue = GetPropertyValue(objFrameStyle, strFramePartProperty);
				if (propertyValue != null)
				{
					object propertyValue2 = GetPropertyValue(propertyValue, "BackgroundImage");
					if (propertyValue2 != null)
					{
						string text = Convert.ToString(GetPropertyValue(propertyValue2, "ResourceName"));
						if (string.IsNullOrEmpty(text))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (objSkin.Resources[text] is ImageResource imageResource)
						{
							result = Image.FromStream(imageResource.ContentStream);
						}
					}
				}
			}
			return result;
		}

		public object GetPropertyValue(object objInstance, string strProperty)
		{
			return GetPropertyValue(objInstance, strProperty, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		}

		public object GetPropertyValue(object objInstance, string strProperty, BindingFlags enmBindingFlags)
		{
			if (objInstance == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				PropertyInfo property = objInstance.GetType().GetProperty(strProperty, enmBindingFlags);
				if (property != null)
				{
					object obj = null;
					try
					{
						return property.GetValue(objInstance, new object[0]);
					}
					catch (TargetInvocationException ex)
					{
						if (ex.InnerException == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							throw ex;
						}
						throw ex.InnerException;
					}
				}
			}
			return null;
		}
	}
	public class SkinResource : HostHttpHandler
	{
		protected Context mobjContext;

		public SkinResource(Context objContext)
		{
			mobjContext = objContext;
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			Global.Context = new Context(objHostContext);
			if (c371e0db5909d312669b7b89a30fa1396.DisableCaching.Enabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				objHostContext.Response.Expires = -1;
			}
			else
			{
				objHostContext.Response.Expires = 10000;
				objHostContext.Response.Cache.SetCacheability(HttpCacheability.Private);
			}
			string resource = ((IRequestParams)mobjContext.Request).Resource;
			SkinFactory.WriteSkinResource(mobjContext, objHostContext, resource, objHostContext.Request.QueryString);
		}
	}
	public class TypeResource : HostHttpHandler
	{
		protected Context mobjContext;

		public new bool IsReusable => false;

		public TypeResource(Context objContext)
		{
			mobjContext = objContext;
		}

		protected virtual void SaveResource(HostContext objHostContext, object objResource)
		{
			if (objResource is Image { RawFormat: var rawFormat } image)
			{
				objHostContext.Response.ContentType = CommonUtils.GetMimeType(rawFormat);
				MemoryStream memoryStream = new MemoryStream();
				image.Save(memoryStream, rawFormat);
				memoryStream.WriteTo(objHostContext.Response.OutputStream);
			}
		}

		public override void ProcessRequest(HostContext objHostContext)
		{
			string resource = ((IRequestParams)mobjContext.Request).Resource;
			string text = objHostContext.Request.QueryString["culture"];
			if (text != null && text != string.Empty)
			{
				string text2 = objHostContext.Request.QueryString["type"];
				if (!string.IsNullOrEmpty(text2))
				{
					Type type = Type.GetType(text2);
					if (!(type != null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						System.Resources.ResourceManager resourceManager = null;
						string text3 = objHostContext.Request.QueryString["basepath"];
						if (string.IsNullOrEmpty(text3))
						{
							/*OpCode not supported: LdMemberToken*/;
							resourceManager = new System.Resources.ResourceManager(type);
						}
						else
						{
							resourceManager = new System.Resources.ResourceManager(text3, type.Assembly);
						}
						if (resourceManager != null)
						{
							object obj = resourceManager.GetObject(resource, new CultureInfo(text));
							if (obj == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								SetResponseCacheState(objHostContext);
								if (obj.GetType() == typeof(string))
								{
									objHostContext.Response.ContentType = CommonUtils.GetMimeType(Convert.ToString(obj));
									objHostContext.Response.Write(Convert.ToString(obj));
									return;
								}
								/*OpCode not supported: LdMemberToken*/;
								if (obj is Image)
								{
									SaveResource(objHostContext, obj);
									return;
								}
							}
						}
					}
				}
			}
			objHostContext.Response.StatusCode = 404;
		}

		private static void SetResponseCacheState(HostContext objHostContext)
		{
			if (c371e0db5909d312669b7b89a30fa1396.DisableCaching.Enabled)
			{
				/*OpCode not supported: LdMemberToken*/;
				objHostContext.Response.Expires = -1;
			}
			else
			{
				objHostContext.Response.Expires = 10000;
				objHostContext.Response.Cache.SetCacheability(HttpCacheability.Private);
			}
		}
	}
}
namespace Gizmox.WebGUI.Server.Resources.Readers
{
	public class EmbededResource : IResourceReader
	{
		private string c2c89d19b44c14e9caa49181b8f41b29a = string.Empty;

		private Assembly cd7bd2298ff38ed446dfc179283dce6bc;

		public bool IsValid => ResourceInfo != null;

		public Assembly Assembly => cd7bd2298ff38ed446dfc179283dce6bc;

		public string Resource => c2c89d19b44c14e9caa49181b8f41b29a;

		public ManifestResourceInfo ResourceInfo => cd7bd2298ff38ed446dfc179283dce6bc.GetManifestResourceInfo(c2c89d19b44c14e9caa49181b8f41b29a);

		public EmbededResource(Assembly objAssembly, string strResource)
		{
			cd7bd2298ff38ed446dfc179283dce6bc = objAssembly;
			c2c89d19b44c14e9caa49181b8f41b29a = objAssembly.FullName.Split(',')[0] + "." + strResource;
		}

		public virtual Stream ToStream()
		{
			return cd7bd2298ff38ed446dfc179283dce6bc.GetManifestResourceStream(c2c89d19b44c14e9caa49181b8f41b29a);
		}

		public XmlDocument ToXml()
		{
			XmlDocument xmlDocument = new XmlDocument();
			Stream stream = ToStream();
			try
			{
				xmlDocument.Load(stream);
			}
			catch (Exception ex)
			{
				stream.Close();
				throw new Exception(c2c89d19b44c14e9caa49181b8f41b29a + ": " + ex.Message, ex);
			}
			stream.Close();
			return xmlDocument;
		}

		public override string ToString()
		{
			StreamReader streamReader = new StreamReader(ToStream());
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}

		public virtual void WriteToStream(Stream objOutputStream)
		{
			Stream stream = ToStream();
			if (stream == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, (int)stream.Length);
			objOutputStream.Write(array, 0, array.Length);
			objOutputStream.Flush();
		}
	}
	public interface IResourceReader
	{
		Stream ToStream();

		XmlDocument ToXml();

		void WriteToStream(Stream objOutputStream);
	}
}
namespace A
{
	internal class c4245054b3fd54036d1104770b7d5a359 : Gizmox.WebGUI.Server.Resources.Readers.IResourceReader
	{
		private string c2c89d19b44c14e9caa49181b8f41b29a = string.Empty;

		internal c4245054b3fd54036d1104770b7d5a359(string strDirectory, string strResource)
		{
			c2c89d19b44c14e9caa49181b8f41b29a = Path.Combine(strDirectory, strResource);
		}

		public Stream ToStream()
		{
			return new FileStream(c2c89d19b44c14e9caa49181b8f41b29a, FileMode.Open);
		}

		public XmlDocument ToXml()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(c2c89d19b44c14e9caa49181b8f41b29a);
			return xmlDocument;
		}

		public override string ToString()
		{
			return new StreamReader(ToStream()).ReadToEnd();
		}

		public void WriteToStream(Stream objOutputStream)
		{
			Stream stream = ToStream();
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, (int)stream.Length);
			objOutputStream.Write(array, 0, array.Length);
		}
	}
}
namespace Gizmox.WebGUI.Server.Providers
{
	[Serializable]
	internal class ArgumentsProvider : NameValueCollection, IMashupArguments
	{
		private MashupType menmMashupType;

		private string mstrMashupId = string.Empty;

		string IMashupArguments.Token => mstrMashupId;

		MashupType IMashupArguments.Type => menmMashupType;

		public ArgumentsProvider()
		{
		}

		protected ArgumentsProvider(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ArgumentsProvider(HostRequest objHostRequest)
		{
			string[] allKeys = objHostRequest.QueryString.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text = allKeys[i];
				if (text == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					base[text] = objHostRequest.QueryString[text];
				}
			}
			allKeys = objHostRequest.Form.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				string text2 = allKeys[i];
				switch (text2)
				{
				case null:
					/*OpCode not supported: LdMemberToken*/;
					continue;
				case "$mashuptoken":
					/*OpCode not supported: LdMemberToken*/;
					mstrMashupId = objHostRequest.Form[text2];
					continue;
				case "$mashuptype":
				{
					/*OpCode not supported: LdMemberToken*/;
					string text3 = objHostRequest.Form[text2];
					if (!(text3 == "modaldialog"))
					{
						/*OpCode not supported: LdMemberToken*/;
						menmMashupType = MashupType.None;
						break;
					}
					menmMashupType = MashupType.ModalDialog;
					continue;
				}
				}
				base[text2] = objHostRequest.Form[text2];
			}
		}
	}
	[Serializable]
	internal class ResultsProvider : NameValueCollection
	{
		public ResultsProvider()
		{
		}

		protected ResultsProvider(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	[Serializable]
	internal class ReadOnlyResultsProvider : NameValueCollection
	{
		public ReadOnlyResultsProvider(NameValueCollection objResults)
			: base(objResults)
		{
			base.IsReadOnly = true;
		}

		protected ReadOnlyResultsProvider(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
namespace Gizmox.WebGUI.Server.Hosting
{
	public class NativeHost : MarshalByRefObject, IRegisteredObject
	{
		private cbe9936ad5de9658f311b4f493232f253 cf3e5d8e1dfde533d35adce734e508a91;

		private Thread c64e9b02c482ab4e9e7f9a6f359be56f2;

		private NativeHostManager ced367db5b823e306bb2ee64f9bc70439;

		private cbe9936ad5de9658f311b4f493232f253 HostProvider
		{
			get
			{
				if (cf3e5d8e1dfde533d35adce734e508a91 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return cf3e5d8e1dfde533d35adce734e508a91;
				}
				throw new Exception("Host provider was not set.");
			}
		}

		public static NativeHost CreateApplicationHost(NativeHostType enmProvider, string virtualDir, string physicalDir, string strRouterType)
		{
			NativeHost obj = (NativeHost)ApplicationHost.CreateApplicationHost(typeof(NativeHost), virtualDir, physicalDir);
			obj.SetProvider(enmProvider, strRouterType);
			return obj;
		}

		private void SetProvider(NativeHostType enmProvider, string strRouterType)
		{
			switch (enmProvider)
			{
			case NativeHostType.BasicHttp:
				SetBasicHttpProvider(strRouterType);
				break;
			case NativeHostType.ServiceModel:
				SetServiceModelProvider(strRouterType);
				break;
			}
		}

		private void SetServiceModelProvider(string strRouterType)
		{
			SetBasicHttpProvider(strRouterType);
		}

		private void SetBasicHttpProvider(string strRouterType)
		{
			if (cf3e5d8e1dfde533d35adce734e508a91 == null)
			{
				cf3e5d8e1dfde533d35adce734e508a91 = new c83f55bfaea118cbc7c5b104c28b0ead1(strRouterType);
			}
		}

		public void Start(int intPort)
		{
			HostProvider.Start(intPort);
			StartManager();
		}

		private void StartManager()
		{
			if (ced367db5b823e306bb2ee64f9bc70439 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ced367db5b823e306bb2ee64f9bc70439 = new NativeHostManager();
			}
			if (c64e9b02c482ab4e9e7f9a6f359be56f2 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c64e9b02c482ab4e9e7f9a6f359be56f2 = new Thread(ced367db5b823e306bb2ee64f9bc70439.Work);
			c64e9b02c482ab4e9e7f9a6f359be56f2.Start();
		}

		public void Stop()
		{
			HostProvider.Stop();
			StopManager();
		}

		private void StopManager()
		{
			if (c64e9b02c482ab4e9e7f9a6f359be56f2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c64e9b02c482ab4e9e7f9a6f359be56f2.Abort();
			}
		}

		void IRegisteredObject.Stop(bool immediate)
		{
			Stop();
		}
	}
	public enum NativeHostType
	{
		BasicHttp,
		ServiceModel
	}
}
namespace A
{
	internal class cf9c108a83c2ec23486bfd1aaec3e18c0 : HostApplicationState
	{
		private readonly cc5d4538b8a75eeeda8789c0af1e3f5cf cf102aec84154bfa80dbf25fb36ea7b1e;

		private static c71d256837eaaf39075d8af87b6efab58 ce672cf87792ce33842ea91dc321f9601;

		public override object this[string name]
		{
			get
			{
				return ce672cf87792ce33842ea91dc321f9601.Get(name);
			}
			set
			{
				ce672cf87792ce33842ea91dc321f9601.Set(name, value);
			}
		}

		public override string[] AllKeys => ce672cf87792ce33842ea91dc321f9601.AllKeys;

		public override object this[int index] => ce672cf87792ce33842ea91dc321f9601.Get(index);

		public override int Count => ce672cf87792ce33842ea91dc321f9601.Count;

		static cf9c108a83c2ec23486bfd1aaec3e18c0()
		{
			ce672cf87792ce33842ea91dc321f9601 = new c71d256837eaaf39075d8af87b6efab58();
		}

		internal cf9c108a83c2ec23486bfd1aaec3e18c0(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			cf102aec84154bfa80dbf25fb36ea7b1e = objNativeHostContext;
		}

		public override void Add(string name, object value)
		{
			ce672cf87792ce33842ea91dc321f9601.Set(name, value);
		}

		public override void Clear()
		{
			ce672cf87792ce33842ea91dc321f9601.Clear();
		}

		public override object Get(int index)
		{
			return ce672cf87792ce33842ea91dc321f9601.Get(index);
		}

		public override object Get(string name)
		{
			return ce672cf87792ce33842ea91dc321f9601.Get(name);
		}

		public override string GetKey(int index)
		{
			return ce672cf87792ce33842ea91dc321f9601.GetKey(index);
		}

		public override void Lock()
		{
			ce672cf87792ce33842ea91dc321f9601.Lock();
		}

		public override void Remove(string name)
		{
			ce672cf87792ce33842ea91dc321f9601.Remove(name);
		}

		public override void RemoveAll()
		{
			ce672cf87792ce33842ea91dc321f9601.RemoveAll();
		}

		public override void RemoveAt(int index)
		{
			ce672cf87792ce33842ea91dc321f9601.RemoveAt(index);
		}

		public override void Set(string name, object value)
		{
			ce672cf87792ce33842ea91dc321f9601.Set(name, value);
		}

		public override void UnLock()
		{
			ce672cf87792ce33842ea91dc321f9601.UnLock();
		}
	}
	internal class cd12d86998ba27b9e6a5efc5345ff136a : HostBrowserCapabilities
	{
		private string cebde4e33ae29c9750dd4730814b3afca;

		public override string Browser
		{
			get
			{
				if (string.IsNullOrEmpty(cebde4e33ae29c9750dd4730814b3afca))
				{
					/*OpCode not supported: LdMemberToken*/;
					return "IE";
				}
				if (Regex.IsMatch(cebde4e33ae29c9750dd4730814b3afca, "MSIE ([^;]*)|Trident.*; rv:([0-9.]+)", RegexOptions.IgnoreCase))
				{
					return "IE";
				}
				if (cebde4e33ae29c9750dd4730814b3afca.IndexOf("WebKit") <= -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (cebde4e33ae29c9750dd4730814b3afca.IndexOf("Opera") <= -1)
					{
						/*OpCode not supported: LdMemberToken*/;
						return "Mozilla";
					}
					return "Opera";
				}
				return "WebKit";
			}
		}

		public override int MajorVersion => 10;

		public override double MinorVersion => 10.0;

		public override string this[string key] => cebde4e33ae29c9750dd4730814b3afca;

		internal cd12d86998ba27b9e6a5efc5345ff136a(string strUserAgent)
		{
			cebde4e33ae29c9750dd4730814b3afca = strUserAgent;
		}
	}
	internal class c37d80acb6a34f4d02fce208bae287aba : HostCache
	{
		private static c71d256837eaaf39075d8af87b6efab58 c9a3a99b7715097c1ec1164c6351b22b5;

		public override object this[string key]
		{
			get
			{
				return c9a3a99b7715097c1ec1164c6351b22b5.Get(key);
			}
			set
			{
				c9a3a99b7715097c1ec1164c6351b22b5.Set(key, value);
			}
		}

		static c37d80acb6a34f4d02fce208bae287aba()
		{
			c9a3a99b7715097c1ec1164c6351b22b5 = new c71d256837eaaf39075d8af87b6efab58();
		}

		internal c37d80acb6a34f4d02fce208bae287aba()
		{
		}
	}
	internal class c161856d0e44a0e392f8f2936b6dd3011 : HostCachePolicy
	{
		private cace92c1d33698dcd2e5827f7129bb7f3 cccaea3803161b3e9ae034a02762fc87f;

		private string c979017224f4cb81e9bd78ccb00645982;

		private bool c92af6c8b49eb0cfa0aad3acd46f697a8 = true;

		private HttpCacheability c59e1f2bb25a053d476118c5de9e86166 = HttpCacheability.NoCache;

		private string cebe00dc6c575e43d568984f951b979f1;

		private DateTime c9b81ee94487e4ad313bee5bc8e42e82d = DateTime.Now;

		private DateTime c78c6fdc4ab7b7a553df4e34399e764de = DateTime.Now;

		private TimeSpan ca5c9ab5320d4508c90a81de33258ec16 = TimeSpan.Zero;

		internal c161856d0e44a0e392f8f2936b6dd3011(cace92c1d33698dcd2e5827f7129bb7f3 objWCFResponseContext)
		{
			cccaea3803161b3e9ae034a02762fc87f = objWCFResponseContext;
		}

		public override void AppendCacheExtension(string extension)
		{
			c979017224f4cb81e9bd78ccb00645982 = extension;
		}

		public override void SetAllowResponseInBrowserHistory(bool allow)
		{
			c92af6c8b49eb0cfa0aad3acd46f697a8 = allow;
		}

		public override void SetCacheability(HttpCacheability cacheability)
		{
			c59e1f2bb25a053d476118c5de9e86166 = HttpCacheability.NoCache;
		}

		public override void SetCacheability(HttpCacheability cacheability, string field)
		{
		}

		public override void SetETag(string etag)
		{
			cebe00dc6c575e43d568984f951b979f1 = etag;
		}

		public override void SetETagFromFileDependencies()
		{
		}

		public override void SetExpires(DateTime date)
		{
			c9b81ee94487e4ad313bee5bc8e42e82d = date;
		}

		public override void SetLastModified(DateTime date)
		{
			c78c6fdc4ab7b7a553df4e34399e764de = date;
		}

		public override void SetLastModifiedFromFileDependencies()
		{
		}

		public override void SetMaxAge(TimeSpan delta)
		{
			ca5c9ab5320d4508c90a81de33258ec16 = delta;
		}

		public override void SetNoServerCaching()
		{
		}

		public override void SetNoStore()
		{
		}

		public override void SetNoTransforms()
		{
		}

		public override void SetOmitVaryStar(bool omit)
		{
		}

		public override void SetProxyMaxAge(TimeSpan delta)
		{
		}

		public override void SetRevalidation(HttpCacheRevalidation revalidation)
		{
		}

		public override void SetSlidingExpiration(bool slide)
		{
		}

		public override void SetValidUntilExpires(bool validUntilExpires)
		{
		}

		public override void SetVaryByCustom(string custom)
		{
		}
	}
	internal class cc5d4538b8a75eeeda8789c0af1e3f5cf : HostContext
	{
		private Hashtable cc2d9bcf218b471edb8b1315391cc93aa;

		private readonly DateTime c3eed7f8af5c177bac639089eda675965 = DateTime.Now;

		private readonly cc5493c4d24769facba3e8ccf0d9f6c9f cd0c51359af2cb24eafa122eb3f0c8d4a;

		public override HttpContext HttpContext => null;

		public override IDictionary Items
		{
			get
			{
				if (cc2d9bcf218b471edb8b1315391cc93aa != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cc2d9bcf218b471edb8b1315391cc93aa = new Hashtable();
				}
				return cc2d9bcf218b471edb8b1315391cc93aa;
			}
		}

		public override DateTime Timestamp => c3eed7f8af5c177bac639089eda675965;

		public override bool IsCustomErrorEnabled => true;

		public override IPrincipal User
		{
			get
			{
				return Thread.CurrentPrincipal;
			}
			set
			{
				Thread.CurrentPrincipal = value;
			}
		}

		internal cc5d4538b8a75eeeda8789c0af1e3f5cf(cc5493c4d24769facba3e8ccf0d9f6c9f objOperationContext)
		{
			if (objOperationContext == null)
			{
				throw new ArgumentNullException("objOperationContext");
			}
			cd0c51359af2cb24eafa122eb3f0c8d4a = objOperationContext;
		}

		protected override HostApplicationState CreateApplication()
		{
			return new cf9c108a83c2ec23486bfd1aaec3e18c0(this);
		}

		protected override HostRequest CreateRequest()
		{
			return new c78e5c1fcf0436550622498d41cad2569(this);
		}

		protected override HostResponse CreateResponse()
		{
			return new cace92c1d33698dcd2e5827f7129bb7f3(this);
		}

		protected override HostServerUtility CreateServer()
		{
			return new c744e7d032b86117503485c939244d1d6(this);
		}

		protected override HostSessionState CreateSession()
		{
			return new c42bf24b2c012023ad4887c99081a42fe(this);
		}

		internal c2f083329b832bfcd1ac0ca00333517cf GetRequestContext()
		{
			return cd0c51359af2cb24eafa122eb3f0c8d4a.Request;
		}

		internal ceef7f894921bcd269a4ecca3829f5747 GetResponseContext()
		{
			return cd0c51359af2cb24eafa122eb3f0c8d4a.Response;
		}
	}
	internal class cf7ad5d0b2c305a159d5fa4d6a6d7532d : HostCookie
	{
		private bool c47905fb331459cf1cd7f0663b842fb0c;

		private bool c5ff0352e65738a36220606b95cb70c61;

		private string c79fffda5dd11a5c19125206c0b124928;

		private bool c55ea7c90ef9b1675de1475390cbec476;

		private DateTime ca1f092ec6c3074e45be04cdb62261c33;

		private bool c34ab9ded77834aa7584eaada062b1048;

		private c95df08bd4b9e4ffcc8088c4a1158cab5 c6b4fbb874fe140e33a0178edc055fa43;

		private string cfb88fd6448584cdcf273e5a1cc1ba7af;

		private string c01a12fa8cc5674fd3df41c39dcb99ccd;

		private bool ce7f87c55c5198659d568d4f73a115f19;

		private string ca03b765fbf0a37c204832355dc830a32;

		internal bool Added
		{
			get
			{
				return c47905fb331459cf1cd7f0663b842fb0c;
			}
			set
			{
				c47905fb331459cf1cd7f0663b842fb0c = value;
			}
		}

		internal bool Changed
		{
			get
			{
				return c5ff0352e65738a36220606b95cb70c61;
			}
			set
			{
				c5ff0352e65738a36220606b95cb70c61 = value;
			}
		}

		public override string Domain
		{
			get
			{
				return c79fffda5dd11a5c19125206c0b124928;
			}
			set
			{
				c79fffda5dd11a5c19125206c0b124928 = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override DateTime Expires
		{
			get
			{
				if (c55ea7c90ef9b1675de1475390cbec476)
				{
					/*OpCode not supported: LdMemberToken*/;
					return ca1f092ec6c3074e45be04cdb62261c33;
				}
				return DateTime.MinValue;
			}
			set
			{
				ca1f092ec6c3074e45be04cdb62261c33 = value;
				c55ea7c90ef9b1675de1475390cbec476 = true;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override bool HasKeys => Values.HasKeys();

		public override bool HttpOnly
		{
			get
			{
				return c34ab9ded77834aa7584eaada062b1048;
			}
			set
			{
				c34ab9ded77834aa7584eaada062b1048 = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override string this[string key]
		{
			get
			{
				return Values[key];
			}
			set
			{
				Values[key] = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override string Name
		{
			get
			{
				return cfb88fd6448584cdcf273e5a1cc1ba7af;
			}
			set
			{
				cfb88fd6448584cdcf273e5a1cc1ba7af = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override string Path
		{
			get
			{
				return c01a12fa8cc5674fd3df41c39dcb99ccd;
			}
			set
			{
				c01a12fa8cc5674fd3df41c39dcb99ccd = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override bool Secure
		{
			get
			{
				return ce7f87c55c5198659d568d4f73a115f19;
			}
			set
			{
				ce7f87c55c5198659d568d4f73a115f19 = value;
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override string Value
		{
			get
			{
				if (c6b4fbb874fe140e33a0178edc055fa43 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return ca03b765fbf0a37c204832355dc830a32;
				}
				return c6b4fbb874fe140e33a0178edc055fa43.ToString(urlencoded: false);
			}
			set
			{
				if (c6b4fbb874fe140e33a0178edc055fa43 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					ca03b765fbf0a37c204832355dc830a32 = value;
				}
				else
				{
					c6b4fbb874fe140e33a0178edc055fa43.Clear();
					c6b4fbb874fe140e33a0178edc055fa43.Add(null, value);
				}
				c5ff0352e65738a36220606b95cb70c61 = true;
			}
		}

		public override NameValueCollection Values
		{
			get
			{
				if (c6b4fbb874fe140e33a0178edc055fa43 == null)
				{
					c6b4fbb874fe140e33a0178edc055fa43 = new c95df08bd4b9e4ffcc8088c4a1158cab5();
					if (ca03b765fbf0a37c204832355dc830a32 != null)
					{
						if (ca03b765fbf0a37c204832355dc830a32.IndexOf('&') >= 0 || ca03b765fbf0a37c204832355dc830a32.IndexOf('=') >= 0)
						{
							c6b4fbb874fe140e33a0178edc055fa43.FillFromString(ca03b765fbf0a37c204832355dc830a32);
						}
						else
						{
							c6b4fbb874fe140e33a0178edc055fa43.Add(null, ca03b765fbf0a37c204832355dc830a32);
						}
						ca03b765fbf0a37c204832355dc830a32 = null;
					}
				}
				c5ff0352e65738a36220606b95cb70c61 = true;
				return c6b4fbb874fe140e33a0178edc055fa43;
			}
		}

		internal cf7ad5d0b2c305a159d5fa4d6a6d7532d()
		{
			c01a12fa8cc5674fd3df41c39dcb99ccd = "/";
			c5ff0352e65738a36220606b95cb70c61 = true;
		}

		public cf7ad5d0b2c305a159d5fa4d6a6d7532d(string name)
		{
			c01a12fa8cc5674fd3df41c39dcb99ccd = "/";
			cfb88fd6448584cdcf273e5a1cc1ba7af = name;
			SetDefaultsFromConfig();
			c5ff0352e65738a36220606b95cb70c61 = true;
		}

		public cf7ad5d0b2c305a159d5fa4d6a6d7532d(string name, string value)
		{
			c01a12fa8cc5674fd3df41c39dcb99ccd = "/";
			cfb88fd6448584cdcf273e5a1cc1ba7af = name;
			ca03b765fbf0a37c204832355dc830a32 = value;
			SetDefaultsFromConfig();
			c5ff0352e65738a36220606b95cb70c61 = true;
		}

		internal cf7ad5d0b2c305a159d5fa4d6a6d7532d(Cookie objCookie)
		{
			cfb88fd6448584cdcf273e5a1cc1ba7af = objCookie.Name;
			c01a12fa8cc5674fd3df41c39dcb99ccd = objCookie.Path;
			c79fffda5dd11a5c19125206c0b124928 = objCookie.Domain;
			ca1f092ec6c3074e45be04cdb62261c33 = objCookie.Expires;
			if (!(ca1f092ec6c3074e45be04cdb62261c33 != DateTime.MinValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c55ea7c90ef9b1675de1475390cbec476 = true;
			}
			ce7f87c55c5198659d568d4f73a115f19 = objCookie.Secure;
			c34ab9ded77834aa7584eaada062b1048 = objCookie.HttpOnly;
			ca03b765fbf0a37c204832355dc830a32 = objCookie.Value;
		}

		internal string GetSetCookieHeader(HostContext context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (string.IsNullOrEmpty(cfb88fd6448584cdcf273e5a1cc1ba7af))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append(cfb88fd6448584cdcf273e5a1cc1ba7af);
				stringBuilder.Append('=');
			}
			if (c6b4fbb874fe140e33a0178edc055fa43 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (ca03b765fbf0a37c204832355dc830a32 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append(ca03b765fbf0a37c204832355dc830a32);
				}
			}
			else
			{
				stringBuilder.Append(c6b4fbb874fe140e33a0178edc055fa43.ToString(urlencoded: false));
			}
			if (!string.IsNullOrEmpty(c79fffda5dd11a5c19125206c0b124928))
			{
				stringBuilder.Append("; domain=");
				stringBuilder.Append(c79fffda5dd11a5c19125206c0b124928);
			}
			if (!c55ea7c90ef9b1675de1475390cbec476)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(ca1f092ec6c3074e45be04cdb62261c33 != DateTime.MinValue))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("; expires=");
				stringBuilder.Append(cd7567fabfab19f45801248f44cd80893.FormatHttpCookieDateTime(ca1f092ec6c3074e45be04cdb62261c33));
			}
			if (string.IsNullOrEmpty(c01a12fa8cc5674fd3df41c39dcb99ccd))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("; path=");
				stringBuilder.Append(c01a12fa8cc5674fd3df41c39dcb99ccd);
			}
			if (!ce7f87c55c5198659d568d4f73a115f19)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("; secure");
			}
			if (!c34ab9ded77834aa7584eaada062b1048)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!SupportsHttpOnly(context))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				stringBuilder.Append("; HttpOnly");
			}
			return stringBuilder.ToString();
		}

		private void SetDefaultsFromConfig()
		{
			ce7f87c55c5198659d568d4f73a115f19 = false;
			c34ab9ded77834aa7584eaada062b1048 = false;
			c79fffda5dd11a5c19125206c0b124928 = "";
		}

		private bool SupportsHttpOnly(HostContext context)
		{
			if (context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (context.Request != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (context.Request.Browser != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return true;
				}
				return false;
			}
			return false;
		}

		internal Cookie ToCookie()
		{
			Cookie cookie = new Cookie(Name, Value, Path, Domain);
			if (!c55ea7c90ef9b1675de1475390cbec476)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cookie.Expires = Expires;
			}
			cookie.HttpOnly = HttpOnly;
			cookie.Secure = Secure;
			return cookie;
		}
	}
	internal sealed class c8a2e6509a4d765ea0a1dadc462172f91 : HostCookieCollection
	{
		private c8641b93435b8b4af13d1463b310513c9 cc0aa48935ec86920ecc0fd2384b9e257 = new c8641b93435b8b4af13d1463b310513c9();

		public override string[] AllKeys => cc0aa48935ec86920ecc0fd2384b9e257.AllKeys;

		public override HostCookie this[string name] => (HostCookie)cc0aa48935ec86920ecc0fd2384b9e257[name];

		public override HostCookie this[int index] => (HostCookie)cc0aa48935ec86920ecc0fd2384b9e257[index];

		public override int Count => cc0aa48935ec86920ecc0fd2384b9e257.Count;

		public override void Add(HostCookie cookie)
		{
			if (cookie != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				cc0aa48935ec86920ecc0fd2384b9e257.Add(cookie.Name, (cf7ad5d0b2c305a159d5fa4d6a6d7532d)cookie);
				return;
			}
			throw new ArgumentNullException("cookie");
		}

		public override void Add(string name)
		{
			Add(Create(name));
		}

		public override void Add(string name, string value)
		{
			Add(Create(name, value));
		}

		public override void Clear()
		{
			cc0aa48935ec86920ecc0fd2384b9e257.Clear();
		}

		public override void CopyTo(Array dest, int index)
		{
			cc0aa48935ec86920ecc0fd2384b9e257.CopyTo(dest, index);
		}

		public override HostCookie Get(int index)
		{
			return (HostCookie)cc0aa48935ec86920ecc0fd2384b9e257.Get(index);
		}

		public override HostCookie Get(string name)
		{
			return (HostCookie)cc0aa48935ec86920ecc0fd2384b9e257.Get(name);
		}

		public override string GetKey(int index)
		{
			return cc0aa48935ec86920ecc0fd2384b9e257.GetKey(index);
		}

		public override void Remove(string name)
		{
			cc0aa48935ec86920ecc0fd2384b9e257.Remove(name);
		}

		public override void Set(HostCookie cookie)
		{
			Add(cookie);
		}

		public override HostCookie Create(string name, string value)
		{
			return new cf7ad5d0b2c305a159d5fa4d6a6d7532d
			{
				Name = name,
				Value = value
			};
		}

		public override HostCookie Create(string name)
		{
			return new cf7ad5d0b2c305a159d5fa4d6a6d7532d
			{
				Name = name
			};
		}

		internal void AddCookie(cf7ad5d0b2c305a159d5fa4d6a6d7532d objCookie, bool blnAppend)
		{
			if (blnAppend)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Clear();
			}
			Add(objCookie);
		}

		internal void MakeReadOnly()
		{
			cc0aa48935ec86920ecc0fd2384b9e257.MakeReadOnly();
		}

		internal void MakeWritable()
		{
			cc0aa48935ec86920ecc0fd2384b9e257.MakeWritable();
		}

		internal void Add(Cookie objCookie)
		{
			Add(new cf7ad5d0b2c305a159d5fa4d6a6d7532d(objCookie));
		}
	}
	internal class c4c3fb34cc40b22ec21c1274d148345e5 : HostFileCollection
	{
		private c8641b93435b8b4af13d1463b310513c9 c785fdb34d8ae3b30db65b308c251e6f9;

		public override string[] AllKeys
		{
			get
			{
				if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return new string[0];
				}
				return c785fdb34d8ae3b30db65b308c251e6f9.AllKeys;
			}
		}

		public override int Count
		{
			get
			{
				if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return 0;
				}
				return c785fdb34d8ae3b30db65b308c251e6f9.Count;
			}
		}

		public override NameObjectCollectionBase.KeysCollection Keys
		{
			get
			{
				EnsureStorage();
				return c785fdb34d8ae3b30db65b308c251e6f9.Keys;
			}
		}

		public override HostPostedFile this[int index]
		{
			get
			{
				if (c785fdb34d8ae3b30db65b308c251e6f9 != null)
				{
					return (HostPostedFile)c785fdb34d8ae3b30db65b308c251e6f9[index];
				}
				return null;
			}
		}

		public override HostPostedFile this[string name]
		{
			get
			{
				if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return (HostPostedFile)c785fdb34d8ae3b30db65b308c251e6f9[name];
			}
		}

		public override void CopyTo(Array dest, int index)
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 != null)
			{
				c785fdb34d8ae3b30db65b308c251e6f9.CopyTo(dest, index);
			}
		}

		public override HostPostedFile Get(string name)
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return (HostPostedFile)c785fdb34d8ae3b30db65b308c251e6f9.Get(name);
		}

		public override HostPostedFile Get(int index)
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 != null)
			{
				return (HostPostedFile)c785fdb34d8ae3b30db65b308c251e6f9.Get(index);
			}
			return null;
		}

		public override IEnumerator GetEnumerator()
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return c785fdb34d8ae3b30db65b308c251e6f9.GetEnumerator();
		}

		public override string GetKey(int index)
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return c785fdb34d8ae3b30db65b308c251e6f9.GetKey(index);
		}

		internal void AddFile(string strName, c0392e356553c4f7784233271beeb65d8 objPostedFile)
		{
			EnsureStorage();
			c785fdb34d8ae3b30db65b308c251e6f9.Add(strName, objPostedFile);
		}

		private void EnsureStorage()
		{
			if (c785fdb34d8ae3b30db65b308c251e6f9 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c785fdb34d8ae3b30db65b308c251e6f9 = new c8641b93435b8b4af13d1463b310513c9();
			}
		}
	}
}
namespace Gizmox.WebGUI.Server.Hosting
{
	public class NativeHostManager
	{
		public void Work()
		{
			while (true)
			{
				Thread.Sleep(TimeSpan.FromMinutes(1.0));
				DoWork();
			}
		}

		private void DoWork()
		{
			c42bf24b2c012023ad4887c99081a42fe.CleanSessions();
		}
	}
}
namespace A
{
	internal sealed class c8641b93435b8b4af13d1463b310513c9 : NameObjectCollectionBase
	{
		private c8097136eb8ff7ad5cea315298ffd25c8[] c2b5eacdd0775b8f3b877e66c16e12081;

		private string[] cbfdabd1d2ef3eae59b5fbcb9dff3a28c;

		public string[] AllKeys
		{
			get
			{
				if (cbfdabd1d2ef3eae59b5fbcb9dff3a28c != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cbfdabd1d2ef3eae59b5fbcb9dff3a28c = BaseGetAllKeys();
				}
				return cbfdabd1d2ef3eae59b5fbcb9dff3a28c;
			}
		}

		public c8097136eb8ff7ad5cea315298ffd25c8 this[string name] => Get(name);

		public c8097136eb8ff7ad5cea315298ffd25c8 this[int index] => Get(index);

		internal c8641b93435b8b4af13d1463b310513c9()
			: base(cd7567fabfab19f45801248f44cd80893.CaseInsensitiveInvariantKeyComparer)
		{
		}

		internal void Add(string key, c8097136eb8ff7ad5cea315298ffd25c8 value)
		{
			c2b5eacdd0775b8f3b877e66c16e12081 = null;
			cbfdabd1d2ef3eae59b5fbcb9dff3a28c = null;
			BaseAdd(key, value);
		}

		public void CopyTo(Array dest, int index)
		{
			if (c2b5eacdd0775b8f3b877e66c16e12081 == null)
			{
				int count = Count;
				c2b5eacdd0775b8f3b877e66c16e12081 = new c8097136eb8ff7ad5cea315298ffd25c8[count];
				for (int i = 0; i < count; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					c2b5eacdd0775b8f3b877e66c16e12081[i] = Get(i);
				}
			}
			if (c2b5eacdd0775b8f3b877e66c16e12081 != null)
			{
				c2b5eacdd0775b8f3b877e66c16e12081.CopyTo(dest, index);
			}
		}

		public c8097136eb8ff7ad5cea315298ffd25c8 Get(int index)
		{
			return (c8097136eb8ff7ad5cea315298ffd25c8)BaseGet(index);
		}

		public c8097136eb8ff7ad5cea315298ffd25c8 Get(string name)
		{
			return (c8097136eb8ff7ad5cea315298ffd25c8)BaseGet(name);
		}

		public string GetKey(int index)
		{
			return BaseGetKey(index);
		}

		public void Clear()
		{
			BaseClear();
		}

		internal void Remove(string name)
		{
			throw new NotImplementedException();
		}

		internal void MakeReadOnly()
		{
			base.IsReadOnly = true;
		}

		internal void MakeWritable()
		{
			base.IsReadOnly = false;
		}
	}
	internal class c95df08bd4b9e4ffcc8088c4a1158cab5 : NameValueCollection
	{
		internal c95df08bd4b9e4ffcc8088c4a1158cab5(bool blnReadOnly)
		{
			base.IsReadOnly = blnReadOnly;
		}

		internal c95df08bd4b9e4ffcc8088c4a1158cab5()
		{
		}

		internal c95df08bd4b9e4ffcc8088c4a1158cab5(NameValueCollection objInternalCollection)
			: base(objInternalCollection)
		{
		}

		internal void MakeReadOnly()
		{
			base.IsReadOnly = true;
		}

		internal void MakeWritable()
		{
			base.IsReadOnly = false;
		}

		public override string ToString()
		{
			return ToString(urlencoded: true);
		}

		internal void FillFromString(string s)
		{
			FillFromString(s, urlencoded: false, null);
		}

		internal void FillFromString(string s, bool urlencoded, Encoding encoding)
		{
			int num = s?.Length ?? 0;
			for (int i = 0; i < num; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				int num2 = i;
				int num3 = -1;
				for (; i < num; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					char c = s[i];
					if (c != '=')
					{
						/*OpCode not supported: LdMemberToken*/;
						if (c == '&')
						{
							/*OpCode not supported: LdMemberToken*/;
							break;
						}
					}
					else if (num3 < 0)
					{
						num3 = i;
					}
				}
				string text = null;
				string text2 = null;
				if (num3 < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					text2 = s.Substring(num2, i - num2);
				}
				else
				{
					text = s.Substring(num2, num3 - num2);
					text2 = s.Substring(num3 + 1, i - num3 - 1);
				}
				if (!urlencoded)
				{
					/*OpCode not supported: LdMemberToken*/;
					base.Add(text, text2);
				}
				else
				{
					base.Add(HttpUtility.UrlDecode(text, encoding), HttpUtility.UrlDecode(text2, encoding));
				}
				if (i != num - 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (s[i] != '&')
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					base.Add(null, string.Empty);
				}
			}
		}

		internal virtual string ToString(bool urlencoded)
		{
			return ToString(urlencoded, null);
		}

		internal virtual string ToString(bool urlencoded, IDictionary excludeKeys)
		{
			int count = Count;
			if (count != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				StringBuilder stringBuilder = new StringBuilder();
				int num;
				if (excludeKeys == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					num = 0;
				}
				else
				{
					num = ((excludeKeys["__VIEWSTATE"] != null) ? 1 : 0);
				}
				bool flag = (byte)num != 0;
				for (int i = 0; i < count; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = GetKey(i);
					if (flag)
					{
						if (text == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (text.StartsWith("__VIEWSTATE", StringComparison.Ordinal))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
					}
					if (excludeKeys != null && text != null && excludeKeys[text] != null)
					{
						continue;
					}
					if (!urlencoded)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						text = HttpUtility.UrlEncodeUnicode(text);
					}
					string text2;
					if (!string.IsNullOrEmpty(text))
					{
						/*OpCode not supported: LdMemberToken*/;
						text2 = text + "=";
					}
					else
					{
						text2 = string.Empty;
					}
					string value = text2;
					ArrayList arrayList = (ArrayList)BaseGet(i);
					int num2;
					if (arrayList != null)
					{
						/*OpCode not supported: LdMemberToken*/;
						num2 = arrayList.Count;
					}
					else
					{
						num2 = 0;
					}
					int num3 = num2;
					if (stringBuilder.Length <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						stringBuilder.Append('&');
					}
					switch (num3)
					{
					case 1:
					{
						stringBuilder.Append(value);
						string text3 = (string)arrayList[0];
						if (!urlencoded)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text3 = HttpUtility.UrlEncodeUnicode(text3);
						}
						stringBuilder.Append(text3);
						continue;
					}
					case 0:
						stringBuilder.Append(value);
						continue;
					}
					/*OpCode not supported: LdMemberToken*/;
					for (int j = 0; j < num3; j++)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (j <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							stringBuilder.Append('&');
						}
						stringBuilder.Append(value);
						string text3 = (string)arrayList[j];
						if (!urlencoded)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							text3 = HttpUtility.UrlEncodeUnicode(text3);
						}
						stringBuilder.Append(text3);
					}
				}
				return stringBuilder.ToString();
			}
			return string.Empty;
		}
	}
	internal abstract class cc5493c4d24769facba3e8ccf0d9f6c9f
	{
		private c2f083329b832bfcd1ac0ca00333517cf c7dd26c4bf4ef13b3d43278f21e941595;

		private ceef7f894921bcd269a4ecca3829f5747 c8c6f583cc37cdd8b5e849a68ce6d2c15;

		public c2f083329b832bfcd1ac0ca00333517cf Request
		{
			get
			{
				if (c7dd26c4bf4ef13b3d43278f21e941595 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c7dd26c4bf4ef13b3d43278f21e941595 = CreateRequestContext();
				}
				return c7dd26c4bf4ef13b3d43278f21e941595;
			}
		}

		public ceef7f894921bcd269a4ecca3829f5747 Response
		{
			get
			{
				if (c8c6f583cc37cdd8b5e849a68ce6d2c15 == null)
				{
					c8c6f583cc37cdd8b5e849a68ce6d2c15 = CreateResponseContext();
				}
				return c8c6f583cc37cdd8b5e849a68ce6d2c15;
			}
		}

		protected abstract c2f083329b832bfcd1ac0ca00333517cf CreateRequestContext();

		protected abstract ceef7f894921bcd269a4ecca3829f5747 CreateResponseContext();
	}
	internal abstract class c2f083329b832bfcd1ac0ca00333517cf
	{
		private c17eb5257c817ec33d2ee18a3ea3e22dd cc8eb39cb40ff05d8aafe72f6a69a6158;

		public abstract Uri Url { get; }

		public abstract string Method { get; }

		public abstract NameValueCollection QueryString { get; }

		public abstract string UserAgent { get; }

		public abstract Stream InputStream { get; }

		public c17eb5257c817ec33d2ee18a3ea3e22dd Headers
		{
			get
			{
				if (cc8eb39cb40ff05d8aafe72f6a69a6158 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cc8eb39cb40ff05d8aafe72f6a69a6158 = CreateHeaders();
				}
				return cc8eb39cb40ff05d8aafe72f6a69a6158;
			}
		}

		public abstract string RawUrl { get; }

		public abstract c8a2e6509a4d765ea0a1dadc462172f91 CreateCookies();

		protected abstract c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders();
	}
	internal abstract class ceef7f894921bcd269a4ecca3829f5747
	{
		private c17eb5257c817ec33d2ee18a3ea3e22dd cc8eb39cb40ff05d8aafe72f6a69a6158;

		public c17eb5257c817ec33d2ee18a3ea3e22dd Headers
		{
			get
			{
				if (cc8eb39cb40ff05d8aafe72f6a69a6158 == null)
				{
					cc8eb39cb40ff05d8aafe72f6a69a6158 = CreateHeaders();
				}
				return cc8eb39cb40ff05d8aafe72f6a69a6158;
			}
		}

		public abstract string StatusDescription { get; set; }

		public abstract int StatusCode { get; set; }

		public abstract Encoding ContentEncoding { get; set; }

		public abstract string ContentType { get; set; }

		public abstract Stream OutputStream { get; }

		protected abstract c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders();

		public abstract void Flush(bool blnIsFinal);

		public abstract void Close(cace92c1d33698dcd2e5827f7129bb7f3 objResponse);

		public abstract void WriteCookieHeader(cc5d4538b8a75eeeda8789c0af1e3f5cf objHostContext, c8a2e6509a4d765ea0a1dadc462172f91 objHostResponseCookies);

		public abstract void WriteGeneratedHeaders(Dictionary<string, string> objGeneratedHeaders);
	}
	internal abstract class c17eb5257c817ec33d2ee18a3ea3e22dd : NameValueCollection
	{
		public abstract string this[HttpResponseHeader header] { get; set; }

		public abstract string this[HttpRequestHeader header] { get; set; }

		protected c17eb5257c817ec33d2ee18a3ea3e22dd(NameValueCollection objCollection)
			: base(objCollection)
		{
		}

		protected c17eb5257c817ec33d2ee18a3ea3e22dd()
		{
		}

		public abstract void Add(HttpRequestHeader header, string value);

		public abstract void Add(HttpResponseHeader header, string value);
	}
	internal class c0392e356553c4f7784233271beeb65d8 : HostPostedFile
	{
		private string cefa6fdc064e992332e8d8f678382ea6f;

		private string c421f5077661ff4724491620fd657cef7;

		private c8eb346db2ce88520a45fe2dd3036d3c5 c3264f8deed67be92c3828c702f5328de;

		public override int ContentLength => (int)c3264f8deed67be92c3828c702f5328de.Length;

		public override string ContentType => cefa6fdc064e992332e8d8f678382ea6f;

		public override string FileName => c421f5077661ff4724491620fd657cef7;

		public override Stream InputStream => c3264f8deed67be92c3828c702f5328de;

		internal c0392e356553c4f7784233271beeb65d8(string filename, string contentType, c8eb346db2ce88520a45fe2dd3036d3c5 stream)
		{
			c421f5077661ff4724491620fd657cef7 = filename;
			cefa6fdc064e992332e8d8f678382ea6f = contentType;
			c3264f8deed67be92c3828c702f5328de = stream;
		}

		public override void SaveAs(string filename)
		{
			if (Path.IsPathRooted(filename))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				filename = Path.Combine(HostRuntime.AppDomainAppPath, filename);
			}
			FileStream fileStream = new FileStream(filename, FileMode.Create);
			try
			{
				c3264f8deed67be92c3828c702f5328de.WriteTo(fileStream);
				fileStream.Flush();
			}
			finally
			{
				fileStream.Close();
			}
		}
	}
	internal abstract class cbe9936ad5de9658f311b4f493232f253 : ProviderBase
	{
		internal class cea09b7af3dcd7c9114a3a07f5cb90fa8 : ProviderCollection
		{
			public new cbe9936ad5de9658f311b4f493232f253 this[string name] => (cbe9936ad5de9658f311b4f493232f253)base[name];
		}

		public abstract void Start(int intPort);

		public abstract void Stop();

		public override void Initialize(string strName, NameValueCollection objConfig)
		{
			base.Initialize(strName, objConfig);
		}
	}
	internal class c78e5c1fcf0436550622498d41cad2569 : HostRequest
	{
		private readonly cc5d4538b8a75eeeda8789c0af1e3f5cf cf102aec84154bfa80dbf25fb36ea7b1e;

		private static c95df08bd4b9e4ffcc8088c4a1158cab5 c0b852293c693ba9ca31d3458642a206c;

		private c4c3fb34cc40b22ec21c1274d148345e5 cb2fe01838ec5c70778e10d292b7224ad;

		private c95df08bd4b9e4ffcc8088c4a1158cab5 c24917fd69bff885cdff6c1d7ce684c36;

		private readonly c2f083329b832bfcd1ac0ca00333517cf c8365a5ef8bdaef6439f19319a8e47a43;

		private c8a2e6509a4d765ea0a1dadc462172f91 c2b5ce7f7a0d2fd0cf5c029026ff5edce;

		private Encoding c4564bdacf0e27874fdfe7cd843ec92cc;

		private ce24e6cda64b98aa5c7b56212211ec57c[] c12b524e587e153de4721e94742d88ac9;

		private c4ce1a7d86d5e0c4b51327c0a0619459b cfe8767fe1be955bf90ddf4c65417359f;

		public override string ContentType => GetRequestHeader(HttpRequestHeader.ContentType, "");

		public override int ContentLength
		{
			get
			{
				string text = c8365a5ef8bdaef6439f19319a8e47a43.Headers[HttpRequestHeader.ContentLength];
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
					return 0;
				}
				int.TryParse(text, out var result);
				return result;
			}
		}

		public override NameValueCollection Headers => c8365a5ef8bdaef6439f19319a8e47a43.Headers;

		public override string HttpMethod => c8365a5ef8bdaef6439f19319a8e47a43.Method;

		public override Stream InputStream => c8365a5ef8bdaef6439f19319a8e47a43.InputStream;

		public override string this[string key]
		{
			get
			{
				string text = QueryString[key];
				if (text == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					text = Form[key];
					if (text == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						HostCookie hostCookie = base.Cookies[key];
						if (hostCookie == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							text = ServerVariables[key];
							if (text != null)
							{
								return text;
							}
							return null;
						}
						return hostCookie.Value;
					}
					return text;
				}
				return text;
			}
		}

		public override NameValueCollection QueryString => c8365a5ef8bdaef6439f19319a8e47a43.QueryString;

		public override NameValueCollection ServerVariables => c0b852293c693ba9ca31d3458642a206c;

		public override string UserAgent => c8365a5ef8bdaef6439f19319a8e47a43.UserAgent;

		public override Uri Url => c8365a5ef8bdaef6439f19319a8e47a43.Url;

		public override NameValueCollection Form
		{
			get
			{
				if (c24917fd69bff885cdff6c1d7ce684c36 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (c24917fd69bff885cdff6c1d7ce684c36.Count != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_0089;
				}
				if (!ContentType.StartsWith("application/x-www-form-urlencoded", StringComparison.InvariantCultureIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadUrlEncodedRequest();
				}
				if (!ContentType.StartsWith("multipart/form-data", StringComparison.InvariantCultureIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadMultipartFormDataRequest();
				}
				if (c24917fd69bff885cdff6c1d7ce684c36 == null)
				{
					c24917fd69bff885cdff6c1d7ce684c36 = new c95df08bd4b9e4ffcc8088c4a1158cab5(blnReadOnly: true);
				}
				goto IL_0089;
				IL_0089:
				return c24917fd69bff885cdff6c1d7ce684c36;
			}
		}

		internal cace92c1d33698dcd2e5827f7129bb7f3 Response
		{
			get
			{
				if (cf102aec84154bfa80dbf25fb36ea7b1e == null)
				{
					return null;
				}
				return (cace92c1d33698dcd2e5827f7129bb7f3)cf102aec84154bfa80dbf25fb36ea7b1e.Response;
			}
		}

		public override Encoding ContentEncoding
		{
			get
			{
				if (c4564bdacf0e27874fdfe7cd843ec92cc != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c4564bdacf0e27874fdfe7cd843ec92cc = GetEncodingFromHeaders();
					if (c4564bdacf0e27874fdfe7cd843ec92cc == null)
					{
						c4564bdacf0e27874fdfe7cd843ec92cc = Encoding.UTF8;
					}
				}
				return c4564bdacf0e27874fdfe7cd843ec92cc;
			}
			set
			{
				c4564bdacf0e27874fdfe7cd843ec92cc = value;
			}
		}

		public override string RawUrl
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string PhysicalApplicationPath => HostRuntime.AppDomainAppPath;

		static c78e5c1fcf0436550622498d41cad2569()
		{
			c0b852293c693ba9ca31d3458642a206c = new c95df08bd4b9e4ffcc8088c4a1158cab5();
		}

		internal c78e5c1fcf0436550622498d41cad2569(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			cf102aec84154bfa80dbf25fb36ea7b1e = objNativeHostContext;
			c8365a5ef8bdaef6439f19319a8e47a43 = objNativeHostContext.GetRequestContext();
		}

		public override void SaveAs(string filename, bool includeHeaders)
		{
			throw new NotImplementedException();
		}

		private string GetRequestHeader(HttpRequestHeader enmHttpRequestHeader, string strDefaultValue)
		{
			string text = c8365a5ef8bdaef6439f19319a8e47a43.Headers[enmHttpRequestHeader];
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = strDefaultValue;
			}
			return text;
		}

		private void LoadMultipartFormDataRequest()
		{
			c24917fd69bff885cdff6c1d7ce684c36 = new c95df08bd4b9e4ffcc8088c4a1158cab5();
			ce24e6cda64b98aa5c7b56212211ec57c[] multipartContent = GetMultipartContent();
			if (multipartContent != null)
			{
				for (int i = 0; i < multipartContent.Length; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (multipartContent[i].IsFormItem)
					{
						c24917fd69bff885cdff6c1d7ce684c36.Add(multipartContent[i].Name, multipartContent[i].GetAsString(ContentEncoding));
					}
				}
			}
			c24917fd69bff885cdff6c1d7ce684c36.MakeReadOnly();
		}

		private void LoadMultipartFormFilesRequest()
		{
			if (cb2fe01838ec5c70778e10d292b7224ad != null)
			{
				return;
			}
			cb2fe01838ec5c70778e10d292b7224ad = new c4c3fb34cc40b22ec21c1274d148345e5();
			ce24e6cda64b98aa5c7b56212211ec57c[] multipartContent = GetMultipartContent();
			if (multipartContent == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			for (int i = 0; i < multipartContent.Length; i++)
			{
				if (!multipartContent[i].IsFile)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				c0392e356553c4f7784233271beeb65d8 asPostedFile = multipartContent[i].GetAsPostedFile();
				cb2fe01838ec5c70778e10d292b7224ad.AddFile(multipartContent[i].Name, asPostedFile);
			}
		}

		private ce24e6cda64b98aa5c7b56212211ec57c[] GetMultipartContent()
		{
			if (c12b524e587e153de4721e94742d88ac9 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				byte[] multipartBoundary = GetMultipartBoundary();
				if (multipartBoundary == null)
				{
					return new ce24e6cda64b98aa5c7b56212211ec57c[0];
				}
				/*OpCode not supported: LdMemberToken*/;
				c4ce1a7d86d5e0c4b51327c0a0619459b entireRawContent = GetEntireRawContent();
				if (entireRawContent == null)
				{
					return new ce24e6cda64b98aa5c7b56212211ec57c[0];
				}
				/*OpCode not supported: LdMemberToken*/;
				c12b524e587e153de4721e94742d88ac9 = cb20c1f7cba27532cb3aa743ab1a81e3a.Parse(entireRawContent, entireRawContent.Length, multipartBoundary, ContentEncoding);
			}
			return c12b524e587e153de4721e94742d88ac9;
		}

		private c4ce1a7d86d5e0c4b51327c0a0619459b GetEntireRawContent()
		{
			if (cfe8767fe1be955bf90ddf4c65417359f != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				int maxRequestLengthBytes = cd7567fabfab19f45801248f44cd80893.MaxRequestLengthBytes;
				c4ce1a7d86d5e0c4b51327c0a0619459b c4ce1a7d86d5e0c4b51327c0a0619459b2 = new c4ce1a7d86d5e0c4b51327c0a0619459b(cd7567fabfab19f45801248f44cd80893.RequestLengthDiskThresholdBytes, ContentLength);
				int num;
				if (ContentLength > 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					num = ContentLength;
				}
				else
				{
					num = int.MaxValue;
				}
				int num2 = num;
				byte[] array = new byte[8192];
				int num3 = c4ce1a7d86d5e0c4b51327c0a0619459b2.Length;
				while (num2 > 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					int num4 = array.Length;
					if (num4 <= num2)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						num4 = num2;
					}
					int num5 = InputStream.Read(array, 0, num4);
					if (num5 <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					c4ce1a7d86d5e0c4b51327c0a0619459b2.AddBytes(array, 0, num5);
					num2 -= num5;
					num3 += num5;
					if (num3 <= maxRequestLengthBytes)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					throw new HttpException("Request exceded max bytes.");
				}
				c4ce1a7d86d5e0c4b51327c0a0619459b2.DoneAddingBytes();
				cfe8767fe1be955bf90ddf4c65417359f = c4ce1a7d86d5e0c4b51327c0a0619459b2;
			}
			return cfe8767fe1be955bf90ddf4c65417359f;
		}

		private byte[] GetMultipartBoundary()
		{
			string attributeFromHeader = GetAttributeFromHeader(ContentType, "boundary");
			if (attributeFromHeader == null)
			{
				return null;
			}
			attributeFromHeader = "--" + attributeFromHeader;
			return Encoding.ASCII.GetBytes(attributeFromHeader.ToCharArray());
		}

		private static string GetAttributeFromHeader(string headerValue, string attrName)
		{
			if (headerValue != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				int length = headerValue.Length;
				int length2 = attrName.Length;
				int i;
				for (i = 1; i < length; i += length2)
				{
					i = CultureInfo.InvariantCulture.CompareInfo.IndexOf(headerValue, attrName, i, CompareOptions.IgnoreCase);
					if (i < 0)
					{
						break;
					}
					if (i + length2 >= length)
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					char c = headerValue[i - 1];
					char c2 = headerValue[i + length2];
					switch (c)
					{
					case ';':
						/*OpCode not supported: LdMemberToken*/;
						goto IL_00a3;
					case ',':
						/*OpCode not supported: LdMemberToken*/;
						goto IL_00a3;
					default:
						{
							if (char.IsWhiteSpace(c))
							{
								goto IL_00a3;
							}
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						IL_00a3:
						if (c2 == '=')
						{
							/*OpCode not supported: LdMemberToken*/;
							break;
						}
						if (!char.IsWhiteSpace(c2))
						{
							continue;
						}
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
					break;
				}
				if (i < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (i < length)
				{
					i += length2;
					while (true)
					{
						if (i >= length)
						{
							/*OpCode not supported: LdMemberToken*/;
							break;
						}
						if (!char.IsWhiteSpace(headerValue[i]))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						i++;
					}
					if (i < length && headerValue[i] == '=')
					{
						/*OpCode not supported: LdMemberToken*/;
						i++;
						while (true)
						{
							if (i >= length)
							{
								/*OpCode not supported: LdMemberToken*/;
								break;
							}
							if (!char.IsWhiteSpace(headerValue[i]))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							i++;
						}
						if (i < length)
						{
							/*OpCode not supported: LdMemberToken*/;
							int num;
							if (i >= length)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								if (headerValue[i] == '"')
								{
									if (i != length - 1)
									{
										/*OpCode not supported: LdMemberToken*/;
										num = headerValue.IndexOf('"', i + 1);
										if (num >= 0 && num != i + 1)
										{
											/*OpCode not supported: LdMemberToken*/;
											return headerValue.Substring(i + 1, num - i - 1).Trim();
										}
										return null;
									}
									return null;
								}
								/*OpCode not supported: LdMemberToken*/;
							}
							for (num = i; num < length; num++)
							{
								/*OpCode not supported: LdMemberToken*/;
								if (headerValue[num] == ' ')
								{
									/*OpCode not supported: LdMemberToken*/;
									break;
								}
								if (headerValue[num] == ',')
								{
									break;
								}
							}
							if (num != i)
							{
								/*OpCode not supported: LdMemberToken*/;
								return headerValue.Substring(i, num - i).Trim();
							}
							return null;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			return null;
		}

		private Encoding GetEncodingFromHeaders()
		{
			if (UserAgent != null && CultureInfo.InvariantCulture.CompareInfo.IsPrefix(UserAgent, "UP"))
			{
				string text = Headers["x-up-devcap-post-charset"];
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					try
					{
						return Encoding.GetEncoding(text);
					}
					catch
					{
					}
				}
			}
			string contentType = ContentType;
			if (contentType != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				string attributeFromHeader = GetAttributeFromHeader(contentType, "charset");
				if (attributeFromHeader == null)
				{
					return null;
				}
				Encoding result = null;
				try
				{
					result = Encoding.GetEncoding(attributeFromHeader);
				}
				catch
				{
				}
				return result;
			}
			return null;
		}

		private void LoadUrlEncodedRequest()
		{
			c24917fd69bff885cdff6c1d7ce684c36 = new c95df08bd4b9e4ffcc8088c4a1158cab5(blnReadOnly: false);
			if (ContentLength <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Stream inputStream = c8365a5ef8bdaef6439f19319a8e47a43.InputStream;
				if (inputStream == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string strRequestContent = new StreamReader(inputStream).ReadToEnd();
					LoadUrlEncodedContent(c24917fd69bff885cdff6c1d7ce684c36, strRequestContent);
				}
			}
			c24917fd69bff885cdff6c1d7ce684c36.MakeReadOnly();
		}

		private void LoadUrlEncodedContent(NameValueCollection objNameValueCollection, string strRequestContent)
		{
			string[] array = strRequestContent.Split('?', '=', '&');
			for (int i = 0; i < array.Length; i += 2)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (array.Length <= i + 1)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objNameValueCollection[array[i]] = HttpUtility.UrlDecode(array[i + 1]);
				}
			}
		}

		protected override HostCookieCollection CreateCookies()
		{
			return c8365a5ef8bdaef6439f19319a8e47a43.CreateCookies();
		}

		protected override HostRequestInfo CreateRequestInfo()
		{
			return new c31d0a0be77ebf1737e46293d5b000a14(this);
		}

		protected override HostBrowserCapabilities CreateBrowserCapabilities()
		{
			return new cd12d86998ba27b9e6a5efc5345ff136a(UserAgent);
		}

		protected override HostFileCollection CreateFileCollection()
		{
			if (cb2fe01838ec5c70778e10d292b7224ad != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!ContentType.StartsWith("multipart/form-data", StringComparison.InvariantCultureIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadMultipartFormFilesRequest();
				}
				if (cb2fe01838ec5c70778e10d292b7224ad != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cb2fe01838ec5c70778e10d292b7224ad = new c4c3fb34cc40b22ec21c1274d148345e5();
				}
			}
			return cb2fe01838ec5c70778e10d292b7224ad;
		}

		public string MapPath(string virtualPath)
		{
			if (virtualPath == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return HostRuntime.AppDomainAppPath;
			}
			if (!cd7567fabfab19f45801248f44cd80893.IsAppRelativePath(virtualPath))
			{
				/*OpCode not supported: LdMemberToken*/;
				throw new NotImplementedException();
			}
			return cd7567fabfab19f45801248f44cd80893.MakeVirtualPathAppAbsolute(virtualPath, HostRuntime.AppDomainAppPath);
		}
	}
	internal class c31d0a0be77ebf1737e46293d5b000a14 : HostRequestInfo
	{
		internal c31d0a0be77ebf1737e46293d5b000a14(c78e5c1fcf0436550622498d41cad2569 objNativeHostRequest)
			: base(objNativeHostRequest)
		{
		}
	}
	internal class c8eb346db2ce88520a45fe2dd3036d3c5 : Stream
	{
		private c4ce1a7d86d5e0c4b51327c0a0619459b c037bcf050635121630a73c4c7d7aeaef;

		private int c7170a3e9ede2d2c40a24d4ba8b8f609c;

		private int c6c8825a68bb355e4fb9316c36fb08eaf;

		private int c7ce87c4c7e7486dd821581e5c37d9fc5;

		public override bool CanRead => true;

		public override bool CanSeek => true;

		public override bool CanWrite => false;

		public override long Length => c7170a3e9ede2d2c40a24d4ba8b8f609c;

		public override long Position
		{
			get
			{
				return c7ce87c4c7e7486dd821581e5c37d9fc5;
			}
			set
			{
				Seek(value, SeekOrigin.Begin);
			}
		}

		internal c8eb346db2ce88520a45fe2dd3036d3c5(c4ce1a7d86d5e0c4b51327c0a0619459b data, int offset, int length)
		{
			Init(data, offset, length);
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				if (!disposing)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Uninit();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		public override void Flush()
		{
		}

		internal byte[] GetAsByteArray()
		{
			if (c7170a3e9ede2d2c40a24d4ba8b8f609c != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return c037bcf050635121630a73c4c7d7aeaef.GetAsByteArray(c6c8825a68bb355e4fb9316c36fb08eaf, c7170a3e9ede2d2c40a24d4ba8b8f609c);
			}
			return null;
		}

		protected void Init(c4ce1a7d86d5e0c4b51327c0a0619459b data, int offset, int length)
		{
			c037bcf050635121630a73c4c7d7aeaef = data;
			c6c8825a68bb355e4fb9316c36fb08eaf = offset;
			c7170a3e9ede2d2c40a24d4ba8b8f609c = length;
			c7ce87c4c7e7486dd821581e5c37d9fc5 = 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = c7170a3e9ede2d2c40a24d4ba8b8f609c - c7ce87c4c7e7486dd821581e5c37d9fc5;
			if (count >= num)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				num = count;
			}
			if (num > 0)
			{
				c037bcf050635121630a73c4c7d7aeaef.CopyBytes(c6c8825a68bb355e4fb9316c36fb08eaf + c7ce87c4c7e7486dd821581e5c37d9fc5, buffer, offset, num);
			}
			c7ce87c4c7e7486dd821581e5c37d9fc5 += num;
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			int num = c7ce87c4c7e7486dd821581e5c37d9fc5;
			int num2 = (int)offset;
			num = origin switch
			{
				SeekOrigin.Begin => num2, 
				SeekOrigin.Current => c7ce87c4c7e7486dd821581e5c37d9fc5 + num2, 
				SeekOrigin.End => c7170a3e9ede2d2c40a24d4ba8b8f609c + num2, 
				_ => throw new ArgumentOutOfRangeException("origin"), 
			};
			if (num < 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (num <= c7170a3e9ede2d2c40a24d4ba8b8f609c)
			{
				/*OpCode not supported: LdMemberToken*/;
				c7ce87c4c7e7486dd821581e5c37d9fc5 = num;
				return c7ce87c4c7e7486dd821581e5c37d9fc5;
			}
			throw new ArgumentOutOfRangeException("offset");
		}

		public override void SetLength(long length)
		{
			throw new NotSupportedException();
		}

		protected void Uninit()
		{
			c037bcf050635121630a73c4c7d7aeaef = null;
			c6c8825a68bb355e4fb9316c36fb08eaf = 0;
			c7170a3e9ede2d2c40a24d4ba8b8f609c = 0;
			c7ce87c4c7e7486dd821581e5c37d9fc5 = 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		internal void WriteTo(Stream s)
		{
			if (c037bcf050635121630a73c4c7d7aeaef == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c7170a3e9ede2d2c40a24d4ba8b8f609c <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c037bcf050635121630a73c4c7d7aeaef.WriteBytes(c6c8825a68bb355e4fb9316c36fb08eaf, c7170a3e9ede2d2c40a24d4ba8b8f609c, s);
			}
		}
	}
	internal sealed class cb20c1f7cba27532cb3aa743ab1a81e3a
	{
		private byte[] c0908d341b0ec23dde66f6eba319bc3c0;

		private c4ce1a7d86d5e0c4b51327c0a0619459b c037bcf050635121630a73c4c7d7aeaef;

		private ArrayList c2898891c9249c65a3c8aed938883e2b6 = new ArrayList();

		private Encoding c244d47e3df0f97e914b86def6bf1e3b1;

		private bool c08593c23f949dc45b09fee7e7ecd4434;

		private int c7170a3e9ede2d2c40a24d4ba8b8f609c;

		private int c729145fcbad4fd9f030e8176b89d52b1 = -1;

		private int c560f589573e40b22638efcb9d2c24a9b = -1;

		private string cd41b269ff26b68f08b0821e577fe3ba0;

		private int cc649f32106cab286b21190a57474fb73 = -1;

		private int cdfd1e1b18c8cd80871f4ada479b11107 = -1;

		private string c0e35d7cb59ae343a5bd2f4706c28019f;

		private string c35b78a95cbdbd251fb576f8ba4b307e7;

		private int c7ce87c4c7e7486dd821581e5c37d9fc5;

		private cb20c1f7cba27532cb3aa743ab1a81e3a(c4ce1a7d86d5e0c4b51327c0a0619459b data, int length, byte[] boundary, Encoding encoding)
		{
			c037bcf050635121630a73c4c7d7aeaef = data;
			c7170a3e9ede2d2c40a24d4ba8b8f609c = length;
			c0908d341b0ec23dde66f6eba319bc3c0 = boundary;
			c244d47e3df0f97e914b86def6bf1e3b1 = encoding;
		}

		private bool AtBoundaryLine()
		{
			int num = c0908d341b0ec23dde66f6eba319bc3c0.Length;
			if (c729145fcbad4fd9f030e8176b89d52b1 == num)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (c729145fcbad4fd9f030e8176b89d52b1 != num + 2)
				{
					return false;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			for (int i = 0; i < num; i++)
			{
				if (c037bcf050635121630a73c4c7d7aeaef[c560f589573e40b22638efcb9d2c24a9b + i] == c0908d341b0ec23dde66f6eba319bc3c0[i])
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return false;
			}
			if (c729145fcbad4fd9f030e8176b89d52b1 == num)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_00c4;
			}
			if (c037bcf050635121630a73c4c7d7aeaef[c560f589573e40b22638efcb9d2c24a9b + num] != 45)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c037bcf050635121630a73c4c7d7aeaef[c560f589573e40b22638efcb9d2c24a9b + num + 1] == 45)
			{
				c08593c23f949dc45b09fee7e7ecd4434 = true;
				goto IL_00c4;
			}
			return false;
			IL_00c4:
			return true;
		}

		private bool AtEndOfData()
		{
			if (c7ce87c4c7e7486dd821581e5c37d9fc5 < c7170a3e9ede2d2c40a24d4ba8b8f609c)
			{
				return c08593c23f949dc45b09fee7e7ecd4434;
			}
			return true;
		}

		private string ExtractValueFromContentDispositionHeader(string l, int pos, string name)
		{
			string text = name + "=\"";
			int num = CultureInfo.InvariantCulture.CompareInfo.IndexOf(l, text, pos, CompareOptions.IgnoreCase);
			if (num >= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				num += text.Length;
				int num2 = l.IndexOf('"', num);
				if (num2 >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num2 != num)
					{
						/*OpCode not supported: LdMemberToken*/;
						return l.Substring(num, num2 - num);
					}
					return string.Empty;
				}
				return null;
			}
			return null;
		}

		private bool GetNextLine()
		{
			int num = c7ce87c4c7e7486dd821581e5c37d9fc5;
			c560f589573e40b22638efcb9d2c24a9b = -1;
			while (num < c7170a3e9ede2d2c40a24d4ba8b8f609c)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (c037bcf050635121630a73c4c7d7aeaef[num] != 10)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (++num == c7170a3e9ede2d2c40a24d4ba8b8f609c)
					{
						c560f589573e40b22638efcb9d2c24a9b = c7ce87c4c7e7486dd821581e5c37d9fc5;
						c729145fcbad4fd9f030e8176b89d52b1 = num - c7ce87c4c7e7486dd821581e5c37d9fc5;
						c7ce87c4c7e7486dd821581e5c37d9fc5 = c7170a3e9ede2d2c40a24d4ba8b8f609c;
					}
					continue;
				}
				c560f589573e40b22638efcb9d2c24a9b = c7ce87c4c7e7486dd821581e5c37d9fc5;
				c729145fcbad4fd9f030e8176b89d52b1 = num - c7ce87c4c7e7486dd821581e5c37d9fc5;
				c7ce87c4c7e7486dd821581e5c37d9fc5 = num + 1;
				if (c729145fcbad4fd9f030e8176b89d52b1 <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (c037bcf050635121630a73c4c7d7aeaef[num - 1] == 13)
				{
					c729145fcbad4fd9f030e8176b89d52b1--;
				}
				break;
			}
			return c560f589573e40b22638efcb9d2c24a9b >= 0;
		}

		internal static ce24e6cda64b98aa5c7b56212211ec57c[] Parse(c4ce1a7d86d5e0c4b51327c0a0619459b data, int length, byte[] boundary, Encoding encoding)
		{
			cb20c1f7cba27532cb3aa743ab1a81e3a obj = new cb20c1f7cba27532cb3aa743ab1a81e3a(data, length, boundary, encoding);
			obj.ParseIntoElementList();
			return (ce24e6cda64b98aa5c7b56212211ec57c[])obj.c2898891c9249c65a3c8aed938883e2b6.ToArray(typeof(ce24e6cda64b98aa5c7b56212211ec57c));
		}

		private void ParseIntoElementList()
		{
			while (GetNextLine())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (AtBoundaryLine())
				{
					break;
				}
			}
			if (AtEndOfData())
			{
				return;
			}
			do
			{
				ParsePartHeaders();
				if (AtEndOfData())
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				ParsePartData();
				if (cc649f32106cab286b21190a57474fb73 == -1)
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				if (c35b78a95cbdbd251fb576f8ba4b307e7 != null)
				{
					c2898891c9249c65a3c8aed938883e2b6.Add(new ce24e6cda64b98aa5c7b56212211ec57c(c35b78a95cbdbd251fb576f8ba4b307e7, c0e35d7cb59ae343a5bd2f4706c28019f, cd41b269ff26b68f08b0821e577fe3ba0, c037bcf050635121630a73c4c7d7aeaef, cdfd1e1b18c8cd80871f4ada479b11107, cc649f32106cab286b21190a57474fb73));
				}
			}
			while (!AtEndOfData());
		}

		private void ParsePartData()
		{
			cdfd1e1b18c8cd80871f4ada479b11107 = c7ce87c4c7e7486dd821581e5c37d9fc5;
			cc649f32106cab286b21190a57474fb73 = -1;
			while (GetNextLine())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!AtBoundaryLine())
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				int num = c560f589573e40b22638efcb9d2c24a9b - 1;
				if (c037bcf050635121630a73c4c7d7aeaef[num] != 10)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					num--;
				}
				if (c037bcf050635121630a73c4c7d7aeaef[num] == 13)
				{
					num--;
				}
				cc649f32106cab286b21190a57474fb73 = num - cdfd1e1b18c8cd80871f4ada479b11107 + 1;
				break;
			}
		}

		private void ParsePartHeaders()
		{
			c35b78a95cbdbd251fb576f8ba4b307e7 = null;
			c0e35d7cb59ae343a5bd2f4706c28019f = null;
			cd41b269ff26b68f08b0821e577fe3ba0 = null;
			while (GetNextLine())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (c729145fcbad4fd9f030e8176b89d52b1 == 0)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				byte[] array = new byte[c729145fcbad4fd9f030e8176b89d52b1];
				c037bcf050635121630a73c4c7d7aeaef.CopyBytes(c560f589573e40b22638efcb9d2c24a9b, array, 0, c729145fcbad4fd9f030e8176b89d52b1);
				string text = c244d47e3df0f97e914b86def6bf1e3b1.GetString(array);
				int num = text.IndexOf(':');
				if (num < 0)
				{
					continue;
				}
				string text2 = text.Substring(0, num);
				if (!text2.Equals("Content-Disposition", StringComparison.InvariantCultureIgnoreCase))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (text2.Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
					{
						cd41b269ff26b68f08b0821e577fe3ba0 = text.Substring(num + 1).Trim();
					}
				}
				else
				{
					c35b78a95cbdbd251fb576f8ba4b307e7 = ExtractValueFromContentDispositionHeader(text, num + 1, "name");
					c0e35d7cb59ae343a5bd2f4706c28019f = ExtractValueFromContentDispositionHeader(text, num + 1, "filename");
				}
			}
		}
	}
	internal class c4ce1a7d86d5e0c4b51327c0a0619459b : IDisposable
	{
		private class c4d2d2c71a8107b35b7642b1e1ee418dc : IDisposable
		{
			private string c421f5077661ff4724491620fd657cef7;

			private Stream c6452e94d4a2e583d2fa9d3a12a587a26;

			private TempFileCollection ca8c5f6d6c4d962f8a040cb7738fc037a;

			internal c4d2d2c71a8107b35b7642b1e1ee418dc()
			{
				string text = Path.Combine(HostRuntime.CodegenDir, "uploads");
				new FileIOPermission(FileIOPermissionAccess.AllAccess, text).Assert();
				if (Directory.Exists(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					try
					{
						Directory.CreateDirectory(text);
					}
					catch
					{
					}
				}
				ca8c5f6d6c4d962f8a040cb7738fc037a = new TempFileCollection(text, keepFiles: false);
				c421f5077661ff4724491620fd657cef7 = ca8c5f6d6c4d962f8a040cb7738fc037a.AddExtension("post", keepFile: false);
				c6452e94d4a2e583d2fa9d3a12a587a26 = new FileStream(c421f5077661ff4724491620fd657cef7, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.DeleteOnClose);
			}

			internal void AddBytes(byte[] data, int offset, int length)
			{
				if (c6452e94d4a2e583d2fa9d3a12a587a26 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					c6452e94d4a2e583d2fa9d3a12a587a26.Write(data, offset, length);
					return;
				}
				throw new InvalidOperationException();
			}

			public void Dispose()
			{
				try
				{
					if (c6452e94d4a2e583d2fa9d3a12a587a26 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						c6452e94d4a2e583d2fa9d3a12a587a26.Close();
					}
					ca8c5f6d6c4d962f8a040cb7738fc037a.Delete();
					((IDisposable)ca8c5f6d6c4d962f8a040cb7738fc037a).Dispose();
				}
				catch
				{
				}
				finally
				{
				}
			}

			internal void DoneAddingBytes()
			{
				if (c6452e94d4a2e583d2fa9d3a12a587a26 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					c6452e94d4a2e583d2fa9d3a12a587a26.Flush();
					c6452e94d4a2e583d2fa9d3a12a587a26.Seek(0L, SeekOrigin.Begin);
					return;
				}
				throw new InvalidOperationException();
			}

			internal int GetBytes(int offset, int length, byte[] buffer, int bufferOffset)
			{
				if (c6452e94d4a2e583d2fa9d3a12a587a26 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					c6452e94d4a2e583d2fa9d3a12a587a26.Seek(offset, SeekOrigin.Begin);
					return c6452e94d4a2e583d2fa9d3a12a587a26.Read(buffer, bufferOffset, length);
				}
				throw new InvalidOperationException();
			}
		}

		private int c6a11e22b6f114bad2a54dadabeaa344e;

		private int cd5b57621482e476bda7e5c86c4ce332c;

		private bool c5af32c9c7d52ca19e03825ae61217453;

		private byte[] c037bcf050635121630a73c4c7d7aeaef;

		private int c73e4b844a19ec51658be6ff2a033ada0;

		private c4d2d2c71a8107b35b7642b1e1ee418dc cf5686312a3110410e52e3cea82a5c56f;

		private int c5d17b77f83523bb3b35b4d429ab55256;

		private int c7170a3e9ede2d2c40a24d4ba8b8f609c;

		internal byte this[int index]
		{
			get
			{
				if (c5af32c9c7d52ca19e03825ae61217453)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (cf5686312a3110410e52e3cea82a5c56f == null)
					{
						return c037bcf050635121630a73c4c7d7aeaef[index];
					}
					if (index < cd5b57621482e476bda7e5c86c4ce332c)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (index < cd5b57621482e476bda7e5c86c4ce332c + c6a11e22b6f114bad2a54dadabeaa344e)
						{
							return c037bcf050635121630a73c4c7d7aeaef[index - cd5b57621482e476bda7e5c86c4ce332c];
						}
						/*OpCode not supported: LdMemberToken*/;
					}
					if (index >= 0 && index < c7170a3e9ede2d2c40a24d4ba8b8f609c)
					{
						/*OpCode not supported: LdMemberToken*/;
						c6a11e22b6f114bad2a54dadabeaa344e = cf5686312a3110410e52e3cea82a5c56f.GetBytes(index, c037bcf050635121630a73c4c7d7aeaef.Length, c037bcf050635121630a73c4c7d7aeaef, 0);
						cd5b57621482e476bda7e5c86c4ce332c = index;
						return c037bcf050635121630a73c4c7d7aeaef[0];
					}
					throw new ArgumentOutOfRangeException("index");
				}
				throw new InvalidOperationException();
			}
		}

		internal int Length => c7170a3e9ede2d2c40a24d4ba8b8f609c;

		internal c4ce1a7d86d5e0c4b51327c0a0619459b(int fileThreshold, int expectedLength)
		{
			c5d17b77f83523bb3b35b4d429ab55256 = fileThreshold;
			c73e4b844a19ec51658be6ff2a033ada0 = expectedLength;
			if (c73e4b844a19ec51658be6ff2a033ada0 >= 0)
			{
				if (c73e4b844a19ec51658be6ff2a033ada0 < c5d17b77f83523bb3b35b4d429ab55256)
				{
					c037bcf050635121630a73c4c7d7aeaef = new byte[c73e4b844a19ec51658be6ff2a033ada0];
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			c037bcf050635121630a73c4c7d7aeaef = new byte[c5d17b77f83523bb3b35b4d429ab55256];
		}

		internal void AddBytes(byte[] data, int offset, int length)
		{
			if (c5af32c9c7d52ca19e03825ae61217453)
			{
				throw new InvalidOperationException();
			}
			if (length <= 0)
			{
				return;
			}
			if (cf5686312a3110410e52e3cea82a5c56f != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (c7170a3e9ede2d2c40a24d4ba8b8f609c + length <= c037bcf050635121630a73c4c7d7aeaef.Length)
				{
					Array.Copy(data, offset, c037bcf050635121630a73c4c7d7aeaef, c7170a3e9ede2d2c40a24d4ba8b8f609c, length);
					c7170a3e9ede2d2c40a24d4ba8b8f609c += length;
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
				if (c7170a3e9ede2d2c40a24d4ba8b8f609c + length <= c5d17b77f83523bb3b35b4d429ab55256)
				{
					byte[] destinationArray = new byte[c5d17b77f83523bb3b35b4d429ab55256];
					if (c7170a3e9ede2d2c40a24d4ba8b8f609c <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Array.Copy(c037bcf050635121630a73c4c7d7aeaef, 0, destinationArray, 0, c7170a3e9ede2d2c40a24d4ba8b8f609c);
					}
					Array.Copy(data, offset, destinationArray, c7170a3e9ede2d2c40a24d4ba8b8f609c, length);
					c037bcf050635121630a73c4c7d7aeaef = destinationArray;
					c7170a3e9ede2d2c40a24d4ba8b8f609c += length;
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
				cf5686312a3110410e52e3cea82a5c56f = new c4d2d2c71a8107b35b7642b1e1ee418dc();
				cf5686312a3110410e52e3cea82a5c56f.AddBytes(c037bcf050635121630a73c4c7d7aeaef, 0, c7170a3e9ede2d2c40a24d4ba8b8f609c);
			}
			cf5686312a3110410e52e3cea82a5c56f.AddBytes(data, offset, length);
			c7170a3e9ede2d2c40a24d4ba8b8f609c += length;
		}

		internal void CopyBytes(int offset, byte[] buffer, int bufferOffset, int length)
		{
			if (c5af32c9c7d52ca19e03825ae61217453)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (cf5686312a3110410e52e3cea82a5c56f == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					Array.Copy(c037bcf050635121630a73c4c7d7aeaef, offset, buffer, bufferOffset, length);
					return;
				}
				if (offset < cd5b57621482e476bda7e5c86c4ce332c)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (offset + length < cd5b57621482e476bda7e5c86c4ce332c + c6a11e22b6f114bad2a54dadabeaa344e)
				{
					Array.Copy(c037bcf050635121630a73c4c7d7aeaef, offset - cd5b57621482e476bda7e5c86c4ce332c, buffer, bufferOffset, length);
					return;
				}
				if (length > c037bcf050635121630a73c4c7d7aeaef.Length)
				{
					/*OpCode not supported: LdMemberToken*/;
					cf5686312a3110410e52e3cea82a5c56f.GetBytes(offset, length, buffer, bufferOffset);
				}
				else
				{
					c6a11e22b6f114bad2a54dadabeaa344e = cf5686312a3110410e52e3cea82a5c56f.GetBytes(offset, c037bcf050635121630a73c4c7d7aeaef.Length, c037bcf050635121630a73c4c7d7aeaef, 0);
					cd5b57621482e476bda7e5c86c4ce332c = offset;
					Array.Copy(c037bcf050635121630a73c4c7d7aeaef, offset - cd5b57621482e476bda7e5c86c4ce332c, buffer, bufferOffset, length);
				}
				return;
			}
			throw new InvalidOperationException();
		}

		public void Dispose()
		{
			if (cf5686312a3110410e52e3cea82a5c56f == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cf5686312a3110410e52e3cea82a5c56f.Dispose();
			}
		}

		internal void DoneAddingBytes()
		{
			if (c037bcf050635121630a73c4c7d7aeaef != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c037bcf050635121630a73c4c7d7aeaef = new byte[0];
			}
			if (cf5686312a3110410e52e3cea82a5c56f == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cf5686312a3110410e52e3cea82a5c56f.DoneAddingBytes();
			}
			c5af32c9c7d52ca19e03825ae61217453 = true;
		}

		internal byte[] GetAsByteArray()
		{
			if (cf5686312a3110410e52e3cea82a5c56f != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (c7170a3e9ede2d2c40a24d4ba8b8f609c == c037bcf050635121630a73c4c7d7aeaef.Length)
				{
					return c037bcf050635121630a73c4c7d7aeaef;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return GetAsByteArray(0, c7170a3e9ede2d2c40a24d4ba8b8f609c);
		}

		internal byte[] GetAsByteArray(int offset, int length)
		{
			if (c5af32c9c7d52ca19e03825ae61217453)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (length != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					byte[] array = new byte[length];
					CopyBytes(offset, array, 0, length);
					return array;
				}
				return new byte[0];
			}
			throw new InvalidOperationException();
		}

		internal void WriteBytes(int offset, int length, Stream stream)
		{
			if (!c5af32c9c7d52ca19e03825ae61217453)
			{
				throw new InvalidOperationException();
			}
			if (cf5686312a3110410e52e3cea82a5c56f == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				stream.Write(c037bcf050635121630a73c4c7d7aeaef, offset, length);
				return;
			}
			int num = offset;
			int num2 = length;
			int num3;
			if (num2 > c5d17b77f83523bb3b35b4d429ab55256)
			{
				/*OpCode not supported: LdMemberToken*/;
				num3 = c5d17b77f83523bb3b35b4d429ab55256;
			}
			else
			{
				num3 = num2;
			}
			byte[] buffer = new byte[num3];
			while (num2 > 0)
			{
				int length2 = ((num2 > c5d17b77f83523bb3b35b4d429ab55256) ? c5d17b77f83523bb3b35b4d429ab55256 : num2);
				int bytes = cf5686312a3110410e52e3cea82a5c56f.GetBytes(num, length2, buffer, 0);
				if (bytes == 0)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				stream.Write(buffer, 0, bytes);
				num += bytes;
				num2 -= bytes;
			}
		}
	}
	internal sealed class ce24e6cda64b98aa5c7b56212211ec57c
	{
		private string cefa6fdc064e992332e8d8f678382ea6f;

		private c4ce1a7d86d5e0c4b51327c0a0619459b c037bcf050635121630a73c4c7d7aeaef;

		private string c421f5077661ff4724491620fd657cef7;

		private int c7170a3e9ede2d2c40a24d4ba8b8f609c;

		private string cfb88fd6448584cdcf273e5a1cc1ba7af;

		private int c6c8825a68bb355e4fb9316c36fb08eaf;

		internal bool IsFile => c421f5077661ff4724491620fd657cef7 != null;

		internal bool IsFormItem => c421f5077661ff4724491620fd657cef7 == null;

		internal string Name => cfb88fd6448584cdcf273e5a1cc1ba7af;

		internal ce24e6cda64b98aa5c7b56212211ec57c(string name, string filename, string contentType, c4ce1a7d86d5e0c4b51327c0a0619459b data, int offset, int length)
		{
			cfb88fd6448584cdcf273e5a1cc1ba7af = name;
			c421f5077661ff4724491620fd657cef7 = filename;
			cefa6fdc064e992332e8d8f678382ea6f = contentType;
			c037bcf050635121630a73c4c7d7aeaef = data;
			c6c8825a68bb355e4fb9316c36fb08eaf = offset;
			c7170a3e9ede2d2c40a24d4ba8b8f609c = length;
		}

		internal c0392e356553c4f7784233271beeb65d8 GetAsPostedFile()
		{
			return new c0392e356553c4f7784233271beeb65d8(c421f5077661ff4724491620fd657cef7, cefa6fdc064e992332e8d8f678382ea6f, new c8eb346db2ce88520a45fe2dd3036d3c5(c037bcf050635121630a73c4c7d7aeaef, c6c8825a68bb355e4fb9316c36fb08eaf, c7170a3e9ede2d2c40a24d4ba8b8f609c));
		}

		internal string GetAsString(Encoding encoding)
		{
			if (c7170a3e9ede2d2c40a24d4ba8b8f609c > 0)
			{
				return encoding.GetString(c037bcf050635121630a73c4c7d7aeaef.GetAsByteArray(c6c8825a68bb355e4fb9316c36fb08eaf, c7170a3e9ede2d2c40a24d4ba8b8f609c));
			}
			return string.Empty;
		}
	}
	internal class cace92c1d33698dcd2e5827f7129bb7f3 : HostResponse
	{
		private readonly cc5d4538b8a75eeeda8789c0af1e3f5cf cf102aec84154bfa80dbf25fb36ea7b1e;

		private c8a2e6509a4d765ea0a1dadc462172f91 c0951dea56eb7c6fcef9d0ff89e501ad5;

		private int c43b1a704b23da52e05882fe387ddea4f = -1;

		private DateTime cae18173bda417dfe247bf199739bcc8c = DateTime.Now;

		private bool c6b5cad5dda6c828beaa1cf6fda3e08da = true;

		private ceef7f894921bcd269a4ecca3829f5747 c0b291fa196233b38dd654b1a9b86d68c;

		private c5ca4829f76d4d094a7528d975cdd02a3 c0188879500f864986585fe15bcb006d1;

		private TextWriter c7283a324743e8b98c8dfb64bd34244f8;

		private Encoding c4564bdacf0e27874fdfe7cd843ec92cc = Encoding.UTF8;

		private bool cd93a432034cb723db2c915f775f979e0;

		private List<cd94ec38370c382c3ef317f8e23e34525> c955c6c079a9e507ce85e15c235b21fef;

		private bool cc77c92d8719a2d4aa7946c176fa59c60;

		private string cacdfb1289ad7489eaedfd2d163e2c3ed;

		public override string ContentType
		{
			get
			{
				return c0b291fa196233b38dd654b1a9b86d68c.ContentType;
			}
			set
			{
				c0b291fa196233b38dd654b1a9b86d68c.ContentType = value;
			}
		}

		public override Stream Filter
		{
			get
			{
				c5ca4829f76d4d094a7528d975cdd02a3 c5ca4829f76d4d094a7528d975cdd02a4 = (c5ca4829f76d4d094a7528d975cdd02a3)OutputStream;
				if (c5ca4829f76d4d094a7528d975cdd02a4 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return null;
				}
				return c5ca4829f76d4d094a7528d975cdd02a4.ResponseFilter;
			}
			set
			{
				c5ca4829f76d4d094a7528d975cdd02a3 c5ca4829f76d4d094a7528d975cdd02a4 = (c5ca4829f76d4d094a7528d975cdd02a3)OutputStream;
				if (c5ca4829f76d4d094a7528d975cdd02a4 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c5ca4829f76d4d094a7528d975cdd02a4.ResponseFilter = value;
				}
			}
		}

		public override bool Buffer
		{
			get
			{
				return c6b5cad5dda6c828beaa1cf6fda3e08da;
			}
			set
			{
				c6b5cad5dda6c828beaa1cf6fda3e08da = value;
			}
		}

		public override Encoding ContentEncoding
		{
			get
			{
				return c4564bdacf0e27874fdfe7cd843ec92cc;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				c4564bdacf0e27874fdfe7cd843ec92cc = value;
			}
		}

		public override int Expires
		{
			get
			{
				return c43b1a704b23da52e05882fe387ddea4f;
			}
			set
			{
				c43b1a704b23da52e05882fe387ddea4f = value;
				cae18173bda417dfe247bf199739bcc8c = DateTime.Now.AddMinutes(c43b1a704b23da52e05882fe387ddea4f);
				base.Cache.SetExpires(cae18173bda417dfe247bf199739bcc8c);
			}
		}

		public override DateTime ExpiresAbsolute
		{
			get
			{
				return cae18173bda417dfe247bf199739bcc8c;
			}
			set
			{
				cae18173bda417dfe247bf199739bcc8c = value;
				base.Cache.SetExpires(cae18173bda417dfe247bf199739bcc8c);
			}
		}

		public override Stream OutputStream
		{
			get
			{
				if (c0188879500f864986585fe15bcb006d1 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c0188879500f864986585fe15bcb006d1 = new c5ca4829f76d4d094a7528d975cdd02a3(this, c0b291fa196233b38dd654b1a9b86d68c.OutputStream);
				}
				return c0188879500f864986585fe15bcb006d1;
			}
		}

		public override string Status
		{
			get
			{
				return c0b291fa196233b38dd654b1a9b86d68c.StatusDescription;
			}
			set
			{
				c0b291fa196233b38dd654b1a9b86d68c.StatusDescription = value;
			}
		}

		public override int StatusCode
		{
			get
			{
				return c0b291fa196233b38dd654b1a9b86d68c.StatusCode;
			}
			set
			{
				c0b291fa196233b38dd654b1a9b86d68c.StatusCode = value;
			}
		}

		public override string StatusDescription
		{
			get
			{
				return c0b291fa196233b38dd654b1a9b86d68c.StatusDescription;
			}
			set
			{
				c0b291fa196233b38dd654b1a9b86d68c.StatusDescription = value;
			}
		}

		public override string CacheControl
		{
			get
			{
				if (cacdfb1289ad7489eaedfd2d163e2c3ed != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return cacdfb1289ad7489eaedfd2d163e2c3ed;
				}
				return "private";
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (string.Compare(value, "private", StringComparison.InvariantCultureIgnoreCase) != 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (string.Compare(value, "public", StringComparison.InvariantCultureIgnoreCase) != 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (string.Compare(value, "no-cache", StringComparison.InvariantCultureIgnoreCase) != 0)
							{
								throw new ArgumentException("Invalid cache control value.");
							}
							cacdfb1289ad7489eaedfd2d163e2c3ed = value;
							base.Cache.SetCacheability(HttpCacheability.NoCache);
						}
						else
						{
							cacdfb1289ad7489eaedfd2d163e2c3ed = value;
							base.Cache.SetCacheability(HttpCacheability.Public);
						}
					}
					else
					{
						cacdfb1289ad7489eaedfd2d163e2c3ed = value;
						base.Cache.SetCacheability(HttpCacheability.Private);
					}
				}
				else
				{
					cacdfb1289ad7489eaedfd2d163e2c3ed = null;
					base.Cache.SetCacheability(HttpCacheability.NoCache);
				}
			}
		}

		public override TextWriter Output
		{
			get
			{
				if (c7283a324743e8b98c8dfb64bd34244f8 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c7283a324743e8b98c8dfb64bd34244f8 = new StreamWriter(OutputStream, ContentEncoding);
				}
				return c7283a324743e8b98c8dfb64bd34244f8;
			}
		}

		internal cace92c1d33698dcd2e5827f7129bb7f3(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			cf102aec84154bfa80dbf25fb36ea7b1e = objNativeHostContext;
			c0b291fa196233b38dd654b1a9b86d68c = objNativeHostContext.GetResponseContext();
		}

		protected override HostCachePolicy CreateCache()
		{
			return new c161856d0e44a0e392f8f2936b6dd3011(this);
		}

		public override void ClearHeaders()
		{
			if (c955c6c079a9e507ce85e15c235b21fef == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c955c6c079a9e507ce85e15c235b21fef.Clear();
			}
		}

		public override void AppendHeader(string name, string value)
		{
			if (c955c6c079a9e507ce85e15c235b21fef != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c955c6c079a9e507ce85e15c235b21fef = new List<cd94ec38370c382c3ef317f8e23e34525>();
			}
			c955c6c079a9e507ce85e15c235b21fef.Add(new cd94ec38370c382c3ef317f8e23e34525(name, value));
		}

		public override void WriteFile(string filename)
		{
			byte[] array = File.ReadAllBytes(filename);
			OutputStream.Write(array, 0, array.Length);
		}

		public override void AddHeader(string name, string value)
		{
			if (c955c6c079a9e507ce85e15c235b21fef != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c955c6c079a9e507ce85e15c235b21fef = new List<cd94ec38370c382c3ef317f8e23e34525>();
			}
			c955c6c079a9e507ce85e15c235b21fef.Add(new cd94ec38370c382c3ef317f8e23e34525(name, value));
		}

		public override void Write(string s)
		{
			Output.Write(s);
		}

		public override void Redirect(string url)
		{
			throw new NotImplementedException();
		}

		public override void Redirect(string url, bool endResponse)
		{
			throw new NotImplementedException();
		}

		public override void AddFileDependency(string filename)
		{
		}

		protected override HostCookieCollection CreateCookies()
		{
			if (c0951dea56eb7c6fcef9d0ff89e501ad5 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0951dea56eb7c6fcef9d0ff89e501ad5 = new c8a2e6509a4d765ea0a1dadc462172f91();
			}
			return c0951dea56eb7c6fcef9d0ff89e501ad5;
		}

		internal void Flush(bool blnIsFinal)
		{
			if (c7283a324743e8b98c8dfb64bd34244f8 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c7283a324743e8b98c8dfb64bd34244f8.Flush();
			}
			if (c0188879500f864986585fe15bcb006d1 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0188879500f864986585fe15bcb006d1.Flush();
			}
			if (!blnIsFinal)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0b291fa196233b38dd654b1a9b86d68c.Flush(blnIsFinal);
			}
		}

		private void WriteHeaders()
		{
			WriteBufferedHeaders();
			WriteCookieHeader();
			WriteCacheHeaders();
		}

		private void WriteBufferedHeaders()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (c955c6c079a9e507ce85e15c235b21fef == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				using List<cd94ec38370c382c3ef317f8e23e34525>.Enumerator enumerator = c955c6c079a9e507ce85e15c235b21fef.GetEnumerator();
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					cd94ec38370c382c3ef317f8e23e34525 current = enumerator.Current;
					string name = current.Name;
					string value = current.Value;
					if (!dictionary.ContainsKey(current.Name))
					{
						/*OpCode not supported: LdMemberToken*/;
						dictionary[name] = value;
					}
					else
					{
						dictionary[name] = $"{dictionary[name]}; {value}";
					}
				}
			}
			c0b291fa196233b38dd654b1a9b86d68c.WriteGeneratedHeaders(dictionary);
		}

		private void WriteCacheHeaders()
		{
		}

		private void WriteCookieHeader()
		{
			if (c0951dea56eb7c6fcef9d0ff89e501ad5 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (c0951dea56eb7c6fcef9d0ff89e501ad5.Count > 0)
			{
				c0b291fa196233b38dd654b1a9b86d68c.WriteCookieHeader(cf102aec84154bfa80dbf25fb36ea7b1e, c0951dea56eb7c6fcef9d0ff89e501ad5);
			}
		}

		public override void BinaryWrite(byte[] buffer)
		{
			OutputStream.Write(buffer, 0, buffer.Length);
		}

		public override void Flush()
		{
			Flush(blnIsFinal: false);
		}

		public override void End()
		{
		}

		public override void ClearContent()
		{
			if (c0188879500f864986585fe15bcb006d1 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0188879500f864986585fe15bcb006d1.Clear();
			}
			c7283a324743e8b98c8dfb64bd34244f8 = null;
		}

		public override void Close()
		{
			c0b291fa196233b38dd654b1a9b86d68c.Close(this);
		}

		public override void Write(char[] buffer, int index, int count)
		{
			Output.Write(buffer, index, count);
		}

		public override void Write(object obj)
		{
			Output.Write(obj);
		}

		internal void OnStartOutputStreamWrite()
		{
			WriteHeaders();
			cd93a432034cb723db2c915f775f979e0 = true;
		}
	}
	internal class cd94ec38370c382c3ef317f8e23e34525
	{
		private string c73d3ecc9fa2a1ba6c3a0dd4e68431adb;

		private string c1f6a428050495652348849b3c40b9bff;

		internal string Name => c73d3ecc9fa2a1ba6c3a0dd4e68431adb;

		internal string Value => c1f6a428050495652348849b3c40b9bff;

		internal cd94ec38370c382c3ef317f8e23e34525(string strName, string strValue)
		{
			c73d3ecc9fa2a1ba6c3a0dd4e68431adb = strName;
			c1f6a428050495652348849b3c40b9bff = strValue;
		}
	}
	internal class c5ca4829f76d4d094a7528d975cdd02a3 : Stream
	{
		private Stream c0188879500f864986585fe15bcb006d1;

		private Stream c0397de0ae722c3af1103eb889d640d47;

		private cace92c1d33698dcd2e5827f7129bb7f3 ca037ad54e722dd36aa035c2e77246e8f;

		private bool c6f51712d3cbdef76642db282e990d79e = true;

		public Stream ResponseFilter
		{
			get
			{
				if (c0397de0ae722c3af1103eb889d640d47 != null)
				{
					return c0397de0ae722c3af1103eb889d640d47;
				}
				return c0188879500f864986585fe15bcb006d1;
			}
			set
			{
				c0397de0ae722c3af1103eb889d640d47 = value;
			}
		}

		public override bool CanRead => c0188879500f864986585fe15bcb006d1.CanRead;

		public override bool CanSeek => c0188879500f864986585fe15bcb006d1.CanSeek;

		public override bool CanWrite => c0188879500f864986585fe15bcb006d1.CanWrite;

		public override long Length => c0188879500f864986585fe15bcb006d1.Length;

		public override long Position
		{
			get
			{
				return c0188879500f864986585fe15bcb006d1.Position;
			}
			set
			{
				c0188879500f864986585fe15bcb006d1.Position = value;
			}
		}

		public c5ca4829f76d4d094a7528d975cdd02a3(cace92c1d33698dcd2e5827f7129bb7f3 objHostResponse, Stream objResponseStream)
		{
			c0188879500f864986585fe15bcb006d1 = objResponseStream;
			ca037ad54e722dd36aa035c2e77246e8f = objHostResponse;
		}

		public override void Close()
		{
			if (c0397de0ae722c3af1103eb889d640d47 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0397de0ae722c3af1103eb889d640d47.Close();
			}
			c0188879500f864986585fe15bcb006d1.Close();
		}

		public override void Flush()
		{
			if (c0397de0ae722c3af1103eb889d640d47 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0397de0ae722c3af1103eb889d640d47.Flush();
			}
			c0188879500f864986585fe15bcb006d1.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return c0188879500f864986585fe15bcb006d1.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return c0188879500f864986585fe15bcb006d1.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			c0188879500f864986585fe15bcb006d1.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			EnsureWriteStarted();
			if (c0397de0ae722c3af1103eb889d640d47 != null)
			{
				c0397de0ae722c3af1103eb889d640d47.Write(buffer, offset, count);
			}
			else
			{
				c0188879500f864986585fe15bcb006d1.Write(buffer, offset, count);
			}
		}

		private void EnsureWriteStarted()
		{
			if (!c6f51712d3cbdef76642db282e990d79e)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c6f51712d3cbdef76642db282e990d79e = false;
			ca037ad54e722dd36aa035c2e77246e8f.OnStartOutputStreamWrite();
		}

		public override void WriteByte(byte value)
		{
			EnsureWriteStarted();
			if (c0397de0ae722c3af1103eb889d640d47 != null)
			{
				c0397de0ae722c3af1103eb889d640d47.WriteByte(value);
			}
			else
			{
				c0188879500f864986585fe15bcb006d1.WriteByte(value);
			}
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			EnsureWriteStarted();
			if (c0397de0ae722c3af1103eb889d640d47 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return c0188879500f864986585fe15bcb006d1.BeginWrite(buffer, offset, count, callback, state);
			}
			return c0397de0ae722c3af1103eb889d640d47.BeginWrite(buffer, offset, count, callback, state);
		}

		public override void EndWrite(IAsyncResult asyncResult)
		{
			if (c0397de0ae722c3af1103eb889d640d47 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				c0188879500f864986585fe15bcb006d1.EndWrite(asyncResult);
			}
			else
			{
				c0397de0ae722c3af1103eb889d640d47.EndWrite(asyncResult);
			}
		}

		internal void Clear()
		{
		}
	}
	internal class cd7828cf49a0345d31ec56391fc89818e : HostRuntime, IDisposable
	{
		private c37d80acb6a34f4d02fce208bae287aba c32affe21b1ef4e1f6885b0a639b3a0d9 = new c37d80acb6a34f4d02fce208bae287aba();

		private string cc91e97d53517bcba0b09372116e7bb25;

		private string c1cbdbd29bc8538836f7e7855571fad5b;

		private string c45cb40604d7948845fdbd0dad607decd;

		private string c931ef322369629b6d9fa306ddb5c8b11;

		private string c57bc24c36668acec41fa7b530f2d1ceb;

		private string c194b0af7078d2a03dabcbc41f050e7f5;

		private string c23076895a07dab649ebe3196ed14a659;

		private string TempDirectory
		{
			get
			{
				if (cc91e97d53517bcba0b09372116e7bb25 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cc91e97d53517bcba0b09372116e7bb25 = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("P"));
					Directory.CreateDirectory(cc91e97d53517bcba0b09372116e7bb25);
				}
				return cc91e97d53517bcba0b09372116e7bb25;
			}
		}

		public cd7828cf49a0345d31ec56391fc89818e()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			c1cbdbd29bc8538836f7e7855571fad5b = (string)currentDomain.GetData(".appDomain");
			c45cb40604d7948845fdbd0dad607decd = (string)currentDomain.GetData(".appId");
			c931ef322369629b6d9fa306ddb5c8b11 = (string)currentDomain.GetData(".appPath");
			c57bc24c36668acec41fa7b530f2d1ceb = (string)currentDomain.GetData(".appVPath");
			c194b0af7078d2a03dabcbc41f050e7f5 = (string)currentDomain.GetData(".domainId");
			c23076895a07dab649ebe3196ed14a659 = Path.Combine(c931ef322369629b6d9fa306ddb5c8b11, "bin");
		}

		protected override string GetAppDomainAppId()
		{
			return c1cbdbd29bc8538836f7e7855571fad5b;
		}

		protected override string GetAppDomainAppPath()
		{
			return c931ef322369629b6d9fa306ddb5c8b11;
		}

		protected override string GetAppDomainAppVirtualPath()
		{
			return c57bc24c36668acec41fa7b530f2d1ceb;
		}

		protected override string GetAppDomainId()
		{
			return c194b0af7078d2a03dabcbc41f050e7f5;
		}

		protected override string GetAspClientScriptPhysicalPath()
		{
			throw new NotImplementedException();
		}

		protected override string GetAspClientScriptVirtualPath()
		{
			throw new NotImplementedException();
		}

		protected override string GetAspInstallDirectory()
		{
			throw new NotImplementedException();
		}

		protected override string GetBinDirectory()
		{
			return c23076895a07dab649ebe3196ed14a659;
		}

		protected override HostCache GetCache()
		{
			return c32affe21b1ef4e1f6885b0a639b3a0d9;
		}

		protected override string GetClrInstallDirectory()
		{
			throw new NotImplementedException();
		}

		protected override string GetCodegenDir()
		{
			return Path.Combine(TempDirectory, "codegendir");
		}

		protected override bool GetIsOnUNCShare()
		{
			throw new NotImplementedException();
		}

		protected override string GetMachineConfigurationDirectory()
		{
			throw new NotImplementedException();
		}

		void IDisposable.Dispose()
		{
			try
			{
				if (cc91e97d53517bcba0b09372116e7bb25 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Directory.Delete(cc91e97d53517bcba0b09372116e7bb25, recursive: true);
				}
			}
			catch
			{
			}
		}
	}
	internal class c744e7d032b86117503485c939244d1d6 : HostServerUtility
	{
		private readonly cc5d4538b8a75eeeda8789c0af1e3f5cf cf102aec84154bfa80dbf25fb36ea7b1e;

		public override string MachineName => Environment.MachineName;

		internal c744e7d032b86117503485c939244d1d6(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			cf102aec84154bfa80dbf25fb36ea7b1e = objNativeHostContext;
		}

		public override string MapPath(string path)
		{
			return ((c78e5c1fcf0436550622498d41cad2569)cf102aec84154bfa80dbf25fb36ea7b1e.Request).MapPath(path);
		}

		public override string HtmlDecode(string s)
		{
			return HttpUtility.HtmlDecode(s);
		}

		public override void HtmlDecode(string s, TextWriter output)
		{
			HttpUtility.HtmlDecode(s, output);
		}

		public override string HtmlEncode(string s)
		{
			return HttpUtility.HtmlEncode(s);
		}

		public override void HtmlEncode(string s, TextWriter output)
		{
			HttpUtility.HtmlEncode(s, output);
		}

		public override string UrlDecode(string s)
		{
			return HttpUtility.UrlDecode(s);
		}

		public override void UrlDecode(string s, TextWriter output)
		{
			if (s != null)
			{
				output.Write(UrlDecode(s));
			}
		}

		public override string UrlEncode(string s)
		{
			return HttpUtility.UrlEncode(s);
		}

		public override void UrlEncode(string s, TextWriter output)
		{
			if (s == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				output.Write(UrlEncode(s));
			}
		}

		public override string UrlPathEncode(string s)
		{
			return HttpUtility.UrlPathEncode(s);
		}
	}
	internal class c42bf24b2c012023ad4887c99081a42fe : HostSessionState
	{
		private readonly cc5d4538b8a75eeeda8789c0af1e3f5cf cf102aec84154bfa80dbf25fb36ea7b1e;

		private c467aad5231514918e85bf3fe62b6cbb3 cc1aeb567ec4bbff3794af63bb9d8dba0;

		private static Dictionary<string, c467aad5231514918e85bf3fe62b6cbb3> c0522e7c67bb77713364449b1feca1cfa = new Dictionary<string, c467aad5231514918e85bf3fe62b6cbb3>();

		private static object c9dbb72da642902bcd1729f6e2bdef81c = new object();

		public override int Count => SessionStorage.Count;

		public override bool IsNewSession => cc1aeb567ec4bbff3794af63bb9d8dba0 == null;

		public override object this[int index]
		{
			get
			{
				return SessionStorage.Get(index);
			}
			set
			{
				SessionStorage.Set(index, value);
			}
		}

		public override object this[string name]
		{
			get
			{
				return SessionStorage.Get(name);
			}
			set
			{
				SessionStorage.Set(name, value);
			}
		}

		public override NameObjectCollectionBase.KeysCollection Keys => SessionStorage.Keys;

		public override int LCID
		{
			get
			{
				return SessionStorage.LCID;
			}
			set
			{
				SessionStorage.LCID = value;
			}
		}

		public override string SessionID => SessionStorage.SessionID;

		public override object SyncRoot => SessionStorage;

		public override bool IsSynchronized => true;

		public override bool IsReadOnly => false;

		public override bool IsCookieless => false;

		public override HostSessionStateMode Mode => HostSessionStateMode.InProc;

		private c467aad5231514918e85bf3fe62b6cbb3 SessionStorage
		{
			get
			{
				if (cc1aeb567ec4bbff3794af63bb9d8dba0 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cc1aeb567ec4bbff3794af63bb9d8dba0 = GetSessionStorage(cf102aec84154bfa80dbf25fb36ea7b1e);
				}
				return cc1aeb567ec4bbff3794af63bb9d8dba0;
			}
		}

		internal c42bf24b2c012023ad4887c99081a42fe(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			cf102aec84154bfa80dbf25fb36ea7b1e = objNativeHostContext;
		}

		public override void Abandon()
		{
			if (cc1aeb567ec4bbff3794af63bb9d8dba0 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			object obj = c9dbb72da642902bcd1729f6e2bdef81c;
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (cc1aeb567ec4bbff3794af63bb9d8dba0 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return;
				}
				c0522e7c67bb77713364449b1feca1cfa.Remove(cc1aeb567ec4bbff3794af63bb9d8dba0.SessionID);
				cc1aeb567ec4bbff3794af63bb9d8dba0 = null;
			}
			finally
			{
				if (!lockTaken)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					Monitor.Exit(obj);
				}
			}
		}

		public override void Add(string name, object value)
		{
			SessionStorage.Add(name, value);
		}

		public override void Clear()
		{
			SessionStorage.Clear();
		}

		public override void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public override IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public override void Remove(string name)
		{
			SessionStorage.Remove(name);
		}

		public override void RemoveAll()
		{
			SessionStorage.RemoveAll();
		}

		public override void RemoveAt(int index)
		{
			SessionStorage.RemoveAt(index);
		}

		private c467aad5231514918e85bf3fe62b6cbb3 GetSessionStorage(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			c467aad5231514918e85bf3fe62b6cbb3 value = null;
			string sessionIDFromRequest = GetSessionIDFromRequest(objNativeHostContext);
			if (!string.IsNullOrEmpty(sessionIDFromRequest))
			{
				if (c0522e7c67bb77713364449b1feca1cfa.TryGetValue(sessionIDFromRequest, out value))
				{
					/*OpCode not supported: LdMemberToken*/;
					value.Touch(cf102aec84154bfa80dbf25fb36ea7b1e);
				}
				else
				{
					object obj = c9dbb72da642902bcd1729f6e2bdef81c;
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (c0522e7c67bb77713364449b1feca1cfa.TryGetValue(sessionIDFromRequest, out value))
						{
							/*OpCode not supported: LdMemberToken*/;
							value.Touch(cf102aec84154bfa80dbf25fb36ea7b1e);
						}
						else
						{
							value = (c0522e7c67bb77713364449b1feca1cfa[sessionIDFromRequest] = new c467aad5231514918e85bf3fe62b6cbb3(sessionIDFromRequest));
						}
					}
					finally
					{
						if (!lockTaken)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							Monitor.Exit(obj);
						}
					}
				}
			}
			else
			{
				lock (c9dbb72da642902bcd1729f6e2bdef81c)
				{
					value = new c467aad5231514918e85bf3fe62b6cbb3();
					c0522e7c67bb77713364449b1feca1cfa[value.SessionID] = value;
					objNativeHostContext.Response.Cookies.Add(CreateSessionCookie(objNativeHostContext, value.SessionID));
				}
			}
			return value;
		}

		private cf7ad5d0b2c305a159d5fa4d6a6d7532d CreateSessionCookie(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext, string strSessionID)
		{
			cf7ad5d0b2c305a159d5fa4d6a6d7532d obj = (cf7ad5d0b2c305a159d5fa4d6a6d7532d)objNativeHostContext.Response.Cookies.Create("ASP.NET_SessionId", strSessionID);
			obj.Path = "/";
			obj.HttpOnly = true;
			return obj;
		}

		private static string GetSessionIDFromRequest(cc5d4538b8a75eeeda8789c0af1e3f5cf objNativeHostContext)
		{
			return objNativeHostContext.Request.Cookies["ASP.NET_SessionId"]?.Value;
		}

		internal static void CleanSessions()
		{
			long ticks = DateTime.Now.Ticks;
			List<object> list = new List<object>();
			using (Dictionary<string, c467aad5231514918e85bf3fe62b6cbb3>.ValueCollection.Enumerator enumerator = c0522e7c67bb77713364449b1feca1cfa.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					c467aad5231514918e85bf3fe62b6cbb3 current = enumerator.Current;
					if (TimeSpan.FromTicks(ticks - current.LastUsed).Minutes <= 10)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add(current);
					}
				}
			}
			lock (c9dbb72da642902bcd1729f6e2bdef81c)
			{
				foreach (c467aad5231514918e85bf3fe62b6cbb3 item in list)
				{
					c0522e7c67bb77713364449b1feca1cfa.Remove(item.SessionID);
				}
			}
		}
	}
	internal class c467aad5231514918e85bf3fe62b6cbb3 : c71d256837eaaf39075d8af87b6efab58
	{
		private readonly string c67a22149a7912a848caa85f9a6cd3e48;

		private int cfa62e6b3f9f9b67f741603f3aa6247bd;

		private long ca8da0bac30909c1ac31df0a06bb87b9b;

		private long c8cff24aab8919cc2cdabd5025399146a;

		public string SessionID => c67a22149a7912a848caa85f9a6cd3e48;

		public int LCID
		{
			get
			{
				return cfa62e6b3f9f9b67f741603f3aa6247bd;
			}
			set
			{
				cfa62e6b3f9f9b67f741603f3aa6247bd = value;
			}
		}

		public long LastUsed => c8cff24aab8919cc2cdabd5025399146a;

		internal c467aad5231514918e85bf3fe62b6cbb3()
			: this(CreateSessionID())
		{
		}

		internal c467aad5231514918e85bf3fe62b6cbb3(string strSessionID)
		{
			c67a22149a7912a848caa85f9a6cd3e48 = strSessionID;
			cfa62e6b3f9f9b67f741603f3aa6247bd = Thread.CurrentThread.CurrentUICulture.LCID;
			ca8da0bac30909c1ac31df0a06bb87b9b = (c8cff24aab8919cc2cdabd5025399146a = DateTime.Now.Ticks);
		}

		private static string CreateSessionID()
		{
			return Guid.NewGuid().ToString("N").ToLowerInvariant();
		}

		internal void Touch(cc5d4538b8a75eeeda8789c0af1e3f5cf objContext)
		{
			c8cff24aab8919cc2cdabd5025399146a = objContext.Timestamp.Ticks;
		}
	}
	internal class c71d256837eaaf39075d8af87b6efab58 : NameObjectCollectionBase
	{
		public string[] AllKeys => BaseGetAllKeys();

		public void Add(string name, object value)
		{
			BaseAdd(name, value);
		}

		public void Clear()
		{
			BaseClear();
		}

		public object Get(int index)
		{
			return BaseGet(index);
		}

		public object Get(string name)
		{
			return BaseGet(name);
		}

		public string GetKey(int index)
		{
			return BaseGetKey(index);
		}

		internal void Remove(string name)
		{
			BaseRemove(name);
		}

		internal void RemoveAll()
		{
			BaseClear();
		}

		internal void RemoveAt(int index)
		{
			BaseRemoveAt(index);
		}

		internal void Set(string name, object value)
		{
			if (BaseGet(name) == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				BaseRemove(name);
			}
			BaseSet(name, value);
		}

		internal void Set(int index, object value)
		{
			BaseSet(index, value);
		}

		internal void UnLock()
		{
			throw new NotImplementedException();
		}

		internal void Lock()
		{
			throw new NotImplementedException();
		}
	}
	internal static class cd7567fabfab19f45801248f44cd80893
	{
		private static StringComparer cf3a3c41d8ca293a4151475a4d158870c;

		internal static StringComparer CaseInsensitiveInvariantKeyComparer
		{
			get
			{
				if (cf3a3c41d8ca293a4151475a4d158870c == null)
				{
					cf3a3c41d8ca293a4151475a4d158870c = StringComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);
				}
				return cf3a3c41d8ca293a4151475a4d158870c;
			}
		}

		internal static int MaxRequestLengthBytes => int.MaxValue;

		internal static int RequestLengthDiskThresholdBytes => int.MaxValue;

		static cd7567fabfab19f45801248f44cd80893()
		{
		}

		internal static string FormatHttpCookieDateTime(DateTime dt)
		{
			if (!(dt < DateTime.MaxValue.AddDays(-1.0)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(dt > DateTime.MinValue.AddDays(1.0)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				dt = dt.ToUniversalTime();
			}
			return dt.ToString("ddd, dd-MMM-yyyy HH':'mm':'ss 'GMT'", DateTimeFormatInfo.InvariantInfo);
		}

		internal static bool IsAppRelativePath(string path)
		{
			if (path == null)
			{
				return false;
			}
			int length = path.Length;
			if (length != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (path[0] == '~')
				{
					/*OpCode not supported: LdMemberToken*/;
					if (length == 1)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (path[1] != '\\')
					{
						return path[1] == '/';
					}
					return true;
				}
				return false;
			}
			return false;
		}

		internal static string FixVirtualPathSlashes(string virtualPath)
		{
			virtualPath = virtualPath.Replace('\\', '/');
			while (true)
			{
				string text = virtualPath.Replace("//", "/");
				if (text == virtualPath)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
				virtualPath = text;
			}
			return virtualPath;
		}

		internal static string MakeVirtualPathAppAbsolute(string virtualPath, string applicationPath)
		{
			if (virtualPath.Length == 1)
			{
				if (virtualPath[0] == '~')
				{
					return applicationPath;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (virtualPath.Length < 2)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (virtualPath[0] != '~')
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (virtualPath[1] == '/' || virtualPath[1] == '\\')
				{
					if (applicationPath.Length <= 1)
					{
						/*OpCode not supported: LdMemberToken*/;
						return "/" + virtualPath.Substring(2);
					}
					return applicationPath + virtualPath.Substring(2);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (IsRooted(virtualPath))
			{
				/*OpCode not supported: LdMemberToken*/;
				return virtualPath;
			}
			throw new ArgumentOutOfRangeException("virtualPath");
		}

		internal static bool IsRooted(string basepath)
		{
			if (string.IsNullOrEmpty(basepath))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (basepath[0] != '/')
				{
					return basepath[0] == '\\';
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return true;
		}
	}
	internal class c83f55bfaea118cbc7c5b104c28b0ead1 : cbe9936ad5de9658f311b4f493232f253
	{
		private HttpListener c39fceb55290094ddaf035dd7bff0bd8e;

		private string c0013d26044511f18275b0f167fa07761;

		private Thread c691590fd2de5de5543e233dcf8f10ac0;

		public c83f55bfaea118cbc7c5b104c28b0ead1(string strRouterType)
		{
			c0013d26044511f18275b0f167fa07761 = strRouterType;
		}

		public override void Start(int intPort)
		{
			c39fceb55290094ddaf035dd7bff0bd8e = new HttpListener();
			c39fceb55290094ddaf035dd7bff0bd8e.Prefixes.Add($"http://*:{intPort}/");
			c39fceb55290094ddaf035dd7bff0bd8e.Start();
			c691590fd2de5de5543e233dcf8f10ac0 = new Thread(Process);
			c691590fd2de5de5543e233dcf8f10ac0.Start();
		}

		private void Process()
		{
			while (true)
			{
				HttpListenerContext context = c39fceb55290094ddaf035dd7bff0bd8e.GetContext();
				Type type = null;
				if (!string.IsNullOrEmpty(c0013d26044511f18275b0f167fa07761))
				{
					type = Type.GetType(c0013d26044511f18275b0f167fa07761);
				}
				if (type == null)
				{
					type = typeof(HttpWorker);
				}
				new Thread((Activator.CreateInstance(type, context) as HttpWorker).ProcessRequest).Start();
			}
		}

		public override void Stop()
		{
			c691590fd2de5de5543e233dcf8f10ac0.Abort();
		}
	}
	internal class ce7ef5e6d4362cc294f023fa9a01ef001 : cc5493c4d24769facba3e8ccf0d9f6c9f
	{
		private readonly HttpListenerContext cd0c51359af2cb24eafa122eb3f0c8d4a;

		internal ce7ef5e6d4362cc294f023fa9a01ef001(HttpListenerContext objOperationContext)
		{
			cd0c51359af2cb24eafa122eb3f0c8d4a = objOperationContext;
		}

		protected override c2f083329b832bfcd1ac0ca00333517cf CreateRequestContext()
		{
			return new c010ade5f91a750ddf0602225bb88ebf8(cd0c51359af2cb24eafa122eb3f0c8d4a.Request);
		}

		protected override ceef7f894921bcd269a4ecca3829f5747 CreateResponseContext()
		{
			return new c988c3cd4794f60fe8bd6549f4d75f72e(cd0c51359af2cb24eafa122eb3f0c8d4a.Response);
		}
	}
	internal class c010ade5f91a750ddf0602225bb88ebf8 : c2f083329b832bfcd1ac0ca00333517cf
	{
		private HttpListenerRequest c9183a6b0110269721196beff8b1bff03;

		private c8a2e6509a4d765ea0a1dadc462172f91 c2b5ce7f7a0d2fd0cf5c029026ff5edce;

		public override Uri Url => c9183a6b0110269721196beff8b1bff03.Url;

		public override string Method => c9183a6b0110269721196beff8b1bff03.HttpMethod;

		public override NameValueCollection QueryString => c9183a6b0110269721196beff8b1bff03.QueryString;

		public override string UserAgent => c9183a6b0110269721196beff8b1bff03.UserAgent;

		public override Stream InputStream => c9183a6b0110269721196beff8b1bff03.InputStream;

		public override string RawUrl => c9183a6b0110269721196beff8b1bff03.RawUrl;

		internal c010ade5f91a750ddf0602225bb88ebf8(HttpListenerRequest objHttpListenerRequest)
		{
			c9183a6b0110269721196beff8b1bff03 = objHttpListenerRequest;
		}

		protected override c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders()
		{
			return new c3980b5f4b08a7e67dcac0357637c868e((WebHeaderCollection)c9183a6b0110269721196beff8b1bff03.Headers);
		}

		public override c8a2e6509a4d765ea0a1dadc462172f91 CreateCookies()
		{
			if (c2b5ce7f7a0d2fd0cf5c029026ff5edce != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c2b5ce7f7a0d2fd0cf5c029026ff5edce = new c8a2e6509a4d765ea0a1dadc462172f91();
				foreach (Cookie cookie in c9183a6b0110269721196beff8b1bff03.Cookies)
				{
					c2b5ce7f7a0d2fd0cf5c029026ff5edce.Add(cookie);
				}
			}
			return c2b5ce7f7a0d2fd0cf5c029026ff5edce;
		}
	}
	internal class c988c3cd4794f60fe8bd6549f4d75f72e : ceef7f894921bcd269a4ecca3829f5747
	{
		private HttpListenerResponse c856db71de6d644b695f46065b38f7d98;

		public override string StatusDescription
		{
			get
			{
				return c856db71de6d644b695f46065b38f7d98.StatusDescription;
			}
			set
			{
				c856db71de6d644b695f46065b38f7d98.StatusDescription = value;
			}
		}

		public override int StatusCode
		{
			get
			{
				return c856db71de6d644b695f46065b38f7d98.StatusCode;
			}
			set
			{
				c856db71de6d644b695f46065b38f7d98.StatusCode = value;
			}
		}

		public override Stream OutputStream => c856db71de6d644b695f46065b38f7d98.OutputStream;

		public override Encoding ContentEncoding
		{
			get
			{
				return c856db71de6d644b695f46065b38f7d98.ContentEncoding;
			}
			set
			{
				c856db71de6d644b695f46065b38f7d98.ContentEncoding = value;
			}
		}

		public override string ContentType
		{
			get
			{
				return c856db71de6d644b695f46065b38f7d98.ContentType;
			}
			set
			{
				c856db71de6d644b695f46065b38f7d98.ContentType = value;
			}
		}

		internal c988c3cd4794f60fe8bd6549f4d75f72e(HttpListenerResponse objHttpListenerResponse)
		{
			c856db71de6d644b695f46065b38f7d98 = objHttpListenerResponse;
		}

		protected override c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders()
		{
			return new c3980b5f4b08a7e67dcac0357637c868e(c856db71de6d644b695f46065b38f7d98.Headers);
		}

		public override void Flush(bool blnIsFinal)
		{
			c856db71de6d644b695f46065b38f7d98.OutputStream.Flush();
		}

		public override void Close(cace92c1d33698dcd2e5827f7129bb7f3 objResponse)
		{
			objResponse.OutputStream.Close();
		}

		public override void WriteCookieHeader(cc5d4538b8a75eeeda8789c0af1e3f5cf objHostContext, c8a2e6509a4d765ea0a1dadc462172f91 objHostResponseCookies)
		{
			for (int i = 0; i < objHostResponseCookies.Count; i++)
			{
				cf7ad5d0b2c305a159d5fa4d6a6d7532d cf7ad5d0b2c305a159d5fa4d6a6d7532d2 = (cf7ad5d0b2c305a159d5fa4d6a6d7532d)objHostResponseCookies[i];
				c856db71de6d644b695f46065b38f7d98.Cookies.Add(cf7ad5d0b2c305a159d5fa4d6a6d7532d2.ToCookie());
			}
		}

		public override void WriteGeneratedHeaders(Dictionary<string, string> objGeneratedHeaders)
		{
			using Dictionary<string, string>.Enumerator enumerator = objGeneratedHeaders.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				KeyValuePair<string, string> current = enumerator.Current;
				string key = current.Key;
				if (key == "Content-Type")
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c856db71de6d644b695f46065b38f7d98.AddHeader(current.Key, current.Value);
				}
			}
		}
	}
	internal class c3980b5f4b08a7e67dcac0357637c868e : c17eb5257c817ec33d2ee18a3ea3e22dd
	{
		private WebHeaderCollection cc8eb39cb40ff05d8aafe72f6a69a6158;

		public override string this[HttpResponseHeader header]
		{
			get
			{
				return cc8eb39cb40ff05d8aafe72f6a69a6158[header];
			}
			set
			{
				cc8eb39cb40ff05d8aafe72f6a69a6158[header] = value;
			}
		}

		public override string this[HttpRequestHeader header]
		{
			get
			{
				return cc8eb39cb40ff05d8aafe72f6a69a6158[header];
			}
			set
			{
				cc8eb39cb40ff05d8aafe72f6a69a6158[header] = value;
			}
		}

		internal c3980b5f4b08a7e67dcac0357637c868e(WebHeaderCollection objHeaders)
			: base(objHeaders)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158 = objHeaders;
		}

		public override void Add(HttpRequestHeader header, string value)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158.Add(header, value);
		}

		public override void Add(HttpResponseHeader header, string value)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158.Add(header, value);
		}
	}
}
namespace Gizmox.WebGUI.Server.Hosting.Providers
{
	public class HttpWorker : Router
	{
		private HttpListenerContext c1a041a7502a9f9ecf6793c6969ec4691;

		public HttpWorker(HttpListenerContext objListenerContext)
		{
			c1a041a7502a9f9ecf6793c6969ec4691 = objListenerContext;
		}

		public void ProcessRequest()
		{
			try
			{
				cc5d4538b8a75eeeda8789c0af1e3f5cf cc5d4538b8a75eeeda8789c0af1e3f5cf = (cc5d4538b8a75eeeda8789c0af1e3f5cf)(HostContext.Current = new cc5d4538b8a75eeeda8789c0af1e3f5cf(new ce7ef5e6d4362cc294f023fa9a01ef001(c1a041a7502a9f9ecf6793c6969ec4691)));
				cace92c1d33698dcd2e5827f7129bb7f3 cace92c1d33698dcd2e5827f7129bb7f = (cace92c1d33698dcd2e5827f7129bb7f3)cc5d4538b8a75eeeda8789c0af1e3f5cf.Response;
				try
				{
					HostHttpHandler handler = GetHandler(cc5d4538b8a75eeeda8789c0af1e3f5cf);
					if (handler == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						handler.ProcessRequest(cc5d4538b8a75eeeda8789c0af1e3f5cf);
					}
					cace92c1d33698dcd2e5827f7129bb7f.Flush(blnIsFinal: true);
					cace92c1d33698dcd2e5827f7129bb7f.Close();
				}
				catch (Exception ex)
				{
					HostException ex2 = ex as HostException;
					if (ex2 == null)
					{
						ex2 = new HostException(ex.Message, ex);
					}
					cace92c1d33698dcd2e5827f7129bb7f.StatusCode = ex2.GetHttpCode();
					cace92c1d33698dcd2e5827f7129bb7f.ContentType = "text/html";
					cace92c1d33698dcd2e5827f7129bb7f.ClearContent();
					cace92c1d33698dcd2e5827f7129bb7f.Write(ex2.GetHtmlErrorMessage());
					cace92c1d33698dcd2e5827f7129bb7f.Flush(blnIsFinal: true);
					cace92c1d33698dcd2e5827f7129bb7f.Close();
				}
			}
			catch (Exception)
			{
			}
		}

		protected override HostRuntime CreateHostRuntimeInstance()
		{
			return new cd7828cf49a0345d31ec56391fc89818e();
		}
	}
}
namespace A
{
	#if false
	internal class cc35bd2e92626481bf869ea1a694423f9 : cbe9936ad5de9658f311b4f493232f253
	{
		private string c0013d26044511f18275b0f167fa07761;

		private ServiceHost c05d77fe94e55faed3c28e64219ef7ad6;

		public cc35bd2e92626481bf869ea1a694423f9(string strRouterType)
		{
			c0013d26044511f18275b0f167fa07761 = strRouterType;
		}

		public cc35bd2e92626481bf869ea1a694423f9()
		{
		}

		public override void Start(int intPort)
		{
			Type type = null;
			if (!string.IsNullOrEmpty(c0013d26044511f18275b0f167fa07761))
			{
				type = Type.GetType(c0013d26044511f18275b0f167fa07761);
			}
			if (!(type == null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				type = typeof(ServiceRouter);
			}
			c05d77fe94e55faed3c28e64219ef7ad6 = new ServiceHost(type);
			ccf66674c4ce8be001eb08f08199e976d binding = new ccf66674c4ce8be001eb08f08199e976d();
			c05d77fe94e55faed3c28e64219ef7ad6.AddServiceEndpoint(typeof(IWgxMessageRouterService), binding, new Uri($"http://{Environment.MachineName}:{intPort}/")).Behaviors.Add(new c05ef08f0b692fce1a8adccb1bcb1b863());
			c05d77fe94e55faed3c28e64219ef7ad6.Open();
		}

		public override void Stop()
		{
			c05d77fe94e55faed3c28e64219ef7ad6.Close();
			c05d77fe94e55faed3c28e64219ef7ad6 = null;
		}
	}
	internal class c789b4c651116176c84514d9304ff9038 : Message
	{
		private class cef9a142a3ffdb1df6c779cbbff1c0e02 : BodyWriter
		{
			private class c833df0ca00ea4d487550196adecaab23 : BodyWriter
			{
				private byte[] c0dad11f63630009444b77152de99a0ce;

				private int c78f7bb45db8e36296ed84a6ddaa7b173;

				public c833df0ca00ea4d487550196adecaab23(byte[] array, int size)
					: base(isBuffered: true)
				{
					c0dad11f63630009444b77152de99a0ce = array;
					c78f7bb45db8e36296ed84a6ddaa7b173 = size;
				}

				protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
				{
					writer.WriteStartElement("Binary", string.Empty);
					writer.WriteBase64(c0dad11f63630009444b77152de99a0ce, 0, c78f7bb45db8e36296ed84a6ddaa7b173);
					writer.WriteEndElement();
				}
			}

			private class c5b81b43bfdeb5a0c75657938b2e95391 : IStreamProvider
			{
				private Stream c56f373e57dd343bf7ff4fff62ca50605;

				internal c5b81b43bfdeb5a0c75657938b2e95391(Stream stream)
				{
					c56f373e57dd343bf7ff4fff62ca50605 = stream;
				}

				public Stream GetStream()
				{
					return c56f373e57dd343bf7ff4fff62ca50605;
				}

				public void ReleaseStream(Stream stream)
				{
				}
			}

			private Stream c56f373e57dd343bf7ff4fff62ca50605;

			private object c0d1ccf6b172bf10e3c6d5d629320ccec;

			private object ThisLock => c0d1ccf6b172bf10e3c6d5d629320ccec;

			public cef9a142a3ffdb1df6c779cbbff1c0e02(Stream stream)
				: base(isBuffered: false)
			{
				if (stream == null)
				{
					throw new ArgumentNullException("stream");
				}
				c56f373e57dd343bf7ff4fff62ca50605 = stream;
				c0d1ccf6b172bf10e3c6d5d629320ccec = new object();
			}

			protected override BodyWriter OnCreateBufferedCopy(int maxBufferSize)
			{
				throw new NotSupportedException();
			}

			protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
			{
				object obj = ThisLock;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					writer.WriteStartElement("Binary", string.Empty);
					writer.WriteValue(new c5b81b43bfdeb5a0c75657938b2e95391(c56f373e57dd343bf7ff4fff62ca50605));
					writer.WriteEndElement();
				}
				finally
				{
					if (!lockTaken)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						Monitor.Exit(obj);
					}
				}
			}
		}

		private class c66b6db269feb1de32f2a317055368c99 : MessageBuffer
		{
			private BodyWriter c86e77b490e081f30ab645a790ebab847;

			private bool c355147cd695faa9f5a8ec2838723e256;

			private MessageHeaders cb9e9e87f07d71868c5983f2b4979d04d;

			private MessageProperties c2ef6e20f0510406b2de04b47d177c9b9;

			private object c0d1ccf6b172bf10e3c6d5d629320ccec = new object();

			public override int BufferSize => 0;

			private object ThisLock => c0d1ccf6b172bf10e3c6d5d629320ccec;

			public c66b6db269feb1de32f2a317055368c99(MessageHeaders headers, MessageProperties properties, BodyWriter bodyWriter)
			{
				c86e77b490e081f30ab645a790ebab847 = bodyWriter;
				cb9e9e87f07d71868c5983f2b4979d04d = headers;
				c2ef6e20f0510406b2de04b47d177c9b9 = properties;
			}

			public override void Close()
			{
				lock (ThisLock)
				{
					if (c355147cd695faa9f5a8ec2838723e256)
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
					c355147cd695faa9f5a8ec2838723e256 = true;
					c86e77b490e081f30ab645a790ebab847 = null;
					cb9e9e87f07d71868c5983f2b4979d04d = null;
					c2ef6e20f0510406b2de04b47d177c9b9 = null;
				}
			}

			private Exception CreateDisposedException()
			{
				return new ObjectDisposedException("Instance was disposed.");
			}

			public override Message CreateMessage()
			{
				lock (ThisLock)
				{
					if (!c355147cd695faa9f5a8ec2838723e256)
					{
						/*OpCode not supported: LdMemberToken*/;
						return new c789b4c651116176c84514d9304ff9038(cb9e9e87f07d71868c5983f2b4979d04d, c2ef6e20f0510406b2de04b47d177c9b9, c86e77b490e081f30ab645a790ebab847);
					}
					throw CreateDisposedException();
				}
			}
		}

		private BodyWriter c7d8703a8e58a42bb44782b20b7a64d28;

		private MessageHeaders cc8eb39cb40ff05d8aafe72f6a69a6158;

		private MessageProperties ced0fc73f19b9454c0dfca7a1c670d588;

		internal const string ca48fa773c346fad554a9daefa71a9c4f = "Binary";

		public override MessageHeaders Headers
		{
			get
			{
				if (!base.IsDisposed)
				{
					/*OpCode not supported: LdMemberToken*/;
					return cc8eb39cb40ff05d8aafe72f6a69a6158;
				}
				throw CreateDisposedException();
			}
		}

		public override bool IsEmpty => false;

		public override bool IsFault => false;

		public override MessageProperties Properties
		{
			get
			{
				if (!base.IsDisposed)
				{
					/*OpCode not supported: LdMemberToken*/;
					return ced0fc73f19b9454c0dfca7a1c670d588;
				}
				throw CreateDisposedException();
			}
		}

		public override MessageVersion Version
		{
			get
			{
				if (!base.IsDisposed)
				{
					/*OpCode not supported: LdMemberToken*/;
					return MessageVersion.None;
				}
				throw CreateDisposedException();
			}
		}

		public c789b4c651116176c84514d9304ff9038(Stream objStream)
		{
			if (objStream != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				c7d8703a8e58a42bb44782b20b7a64d28 = new cef9a142a3ffdb1df6c779cbbff1c0e02(objStream);
				cc8eb39cb40ff05d8aafe72f6a69a6158 = new MessageHeaders(MessageVersion.None, 1);
				ced0fc73f19b9454c0dfca7a1c670d588 = new MessageProperties();
				return;
			}
			throw new ArgumentNullException("stream");
		}

		public c789b4c651116176c84514d9304ff9038(MessageHeaders headers, MessageProperties properties, BodyWriter bodyWriter)
		{
			if (bodyWriter != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				cc8eb39cb40ff05d8aafe72f6a69a6158 = new MessageHeaders(headers);
				ced0fc73f19b9454c0dfca7a1c670d588 = new MessageProperties(properties);
				c7d8703a8e58a42bb44782b20b7a64d28 = bodyWriter;
				return;
			}
			throw new ArgumentNullException("bodyWriter");
		}

		private Exception CreateDisposedException()
		{
			return new ObjectDisposedException("Instance was disposed.");
		}

		protected override void OnBodyToString(XmlDictionaryWriter writer)
		{
			if (!c7d8703a8e58a42bb44782b20b7a64d28.IsBuffered)
			{
				/*OpCode not supported: LdMemberToken*/;
				writer.WriteString("Body is streamed.");
			}
			else
			{
				c7d8703a8e58a42bb44782b20b7a64d28.WriteBodyContents(writer);
			}
		}

		protected override void OnClose()
		{
			Exception ex = null;
			try
			{
				base.OnClose();
			}
			catch (Exception ex2)
			{
				if (c88d621fab5cdf8581691951923d7cf75.IsFatal(ex2))
				{
					throw;
				}
				/*OpCode not supported: LdMemberToken*/;
				ex = ex2;
			}
			try
			{
				if (ced0fc73f19b9454c0dfca7a1c670d588 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ced0fc73f19b9454c0dfca7a1c670d588.Dispose();
				}
			}
			catch (Exception ex3)
			{
				if (c88d621fab5cdf8581691951923d7cf75.IsFatal(ex3))
				{
					throw;
				}
				/*OpCode not supported: LdMemberToken*/;
				if (ex != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ex = ex3;
				}
			}
			if (ex == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				c7d8703a8e58a42bb44782b20b7a64d28 = null;
				return;
			}
			throw ex;
		}

		protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
		{
			return new c66b6db269feb1de32f2a317055368c99(bodyWriter: (!c7d8703a8e58a42bb44782b20b7a64d28.IsBuffered) ? c7d8703a8e58a42bb44782b20b7a64d28.CreateBufferedCopy(maxBufferSize) : c7d8703a8e58a42bb44782b20b7a64d28, headers: Headers, properties: new MessageProperties(Properties));
		}

		protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
		{
			c7d8703a8e58a42bb44782b20b7a64d28.WriteBodyContents(writer);
		}
	}
	internal class ccf66674c4ce8be001eb08f08199e976d : Binding
	{
		private HttpTransportBindingElement c8f418582704be06d750b432a6c6d666f;

		private c7d26dca8405829051a712a9045e43705 cc53464e04c5aaca47eb9bf1a1a1e3238;

		public override string Scheme => "http";

		public ccf66674c4ce8be001eb08f08199e976d()
		{
			c8f418582704be06d750b432a6c6d666f = new HttpTransportBindingElement();
			c8f418582704be06d750b432a6c6d666f.TransferMode = TransferMode.Streamed;
			cc53464e04c5aaca47eb9bf1a1a1e3238 = new c7d26dca8405829051a712a9045e43705();
		}

		public override BindingElementCollection CreateBindingElements()
		{
			return new BindingElementCollection { cc53464e04c5aaca47eb9bf1a1a1e3238, c8f418582704be06d750b432a6c6d666f };
		}
	}
	internal class cc0188db8cbae7af55a4f39e59c985f68 : Stream
	{
		private string cfc923df1ee8f5afe841bb3eec4c33b7b;

		private string c931df781d2d9c197000f5be56d33ab3c;

		private bool c5d0520aa337093f8fed8d730699ee483;

		private Message c967e6ea8827aca092a8774e27efe7221;

		private long cbce438242d9ef67d03d9872f6b10f24c;

		private XmlDictionaryReader c6255f4d5c7a51c846ca9a8c2ffbbecf2;

		private string c7d9d14ab59b7b87200d2f61667d13fd4;

		private string c712fb6697c05f13801700d4d88518ff4;

		public override bool CanRead => c967e6ea8827aca092a8774e27efe7221.State != MessageState.Closed;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				EnsureStreamIsOpen();
				return cbce438242d9ef67d03d9872f6b10f24c;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		internal cc0188db8cbae7af55a4f39e59c985f68(Message message, string wrapperName, string wrapperNs, string elementName, string elementNs, bool isRequest)
		{
			c967e6ea8827aca092a8774e27efe7221 = message;
			cbce438242d9ef67d03d9872f6b10f24c = 0L;
			c7d9d14ab59b7b87200d2f61667d13fd4 = wrapperName;
			c712fb6697c05f13801700d4d88518ff4 = wrapperNs;
			cfc923df1ee8f5afe841bb3eec4c33b7b = elementName;
			c931df781d2d9c197000f5be56d33ab3c = elementNs;
			c5d0520aa337093f8fed8d730699ee483 = isRequest;
		}

		public override void Close()
		{
			c967e6ea8827aca092a8774e27efe7221.Close();
			if (c6255f4d5c7a51c846ca9a8c2ffbbecf2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c6255f4d5c7a51c846ca9a8c2ffbbecf2.Close();
				c6255f4d5c7a51c846ca9a8c2ffbbecf2 = null;
			}
			base.Close();
		}

		private void EnsureStreamIsOpen()
		{
			if (c967e6ea8827aca092a8774e27efe7221.State != MessageState.Closed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new ObjectDisposedException("Instance was disposed.");
		}

		private static void Exhaust(XmlDictionaryReader reader)
		{
			if (reader == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			while (reader.Read())
			{
				/*OpCode not supported: LdMemberToken*/;
			}
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			EnsureStreamIsOpen();
			if (buffer != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (offset >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (count >= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (buffer.Length - offset >= count)
						{
							/*OpCode not supported: LdMemberToken*/;
							try
							{
								if (c6255f4d5c7a51c846ca9a8c2ffbbecf2 != null)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									c6255f4d5c7a51c846ca9a8c2ffbbecf2 = c967e6ea8827aca092a8774e27efe7221.GetReaderAtBodyContents();
									if (c7d9d14ab59b7b87200d2f61667d13fd4 != null)
									{
										c6255f4d5c7a51c846ca9a8c2ffbbecf2.MoveToContent();
										c6255f4d5c7a51c846ca9a8c2ffbbecf2.ReadStartElement(c7d9d14ab59b7b87200d2f61667d13fd4, c712fb6697c05f13801700d4d88518ff4);
									}
									c6255f4d5c7a51c846ca9a8c2ffbbecf2.MoveToContent();
									if (c6255f4d5c7a51c846ca9a8c2ffbbecf2.NodeType == XmlNodeType.EndElement)
									{
										return 0;
									}
									/*OpCode not supported: LdMemberToken*/;
									c6255f4d5c7a51c846ca9a8c2ffbbecf2.ReadStartElement(cfc923df1ee8f5afe841bb3eec4c33b7b, c931df781d2d9c197000f5be56d33ab3c);
								}
								if (c6255f4d5c7a51c846ca9a8c2ffbbecf2.MoveToContent() != XmlNodeType.Text)
								{
									Exhaust(c6255f4d5c7a51c846ca9a8c2ffbbecf2);
									return 0;
								}
								int num = c6255f4d5c7a51c846ca9a8c2ffbbecf2.ReadContentAsBase64(buffer, offset, count);
								cbce438242d9ef67d03d9872f6b10f24c += num;
								if (num != 0)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									Exhaust(c6255f4d5c7a51c846ca9a8c2ffbbecf2);
								}
								return num;
							}
							catch (Exception ex)
							{
								if (!c88d621fab5cdf8581691951923d7cf75.IsFatal(ex))
								{
									/*OpCode not supported: LdMemberToken*/;
									throw new IOException("Error while reading message body stream.", ex);
								}
								throw;
							}
						}
						throw new ArgumentException();
					}
					throw new ArgumentOutOfRangeException("count");
				}
				throw new ArgumentOutOfRangeException("offset");
			}
			throw new ArgumentNullException("buffer");
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
	}
	internal class c274d7b988b53c49d68155f1d7e8b7032 : MessageEncoder
	{
		public override string ContentType => "text/html";

		public override string MediaType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override MessageVersion MessageVersion => MessageVersion.None;

		public override bool IsContentTypeSupported(string contentType)
		{
			return true;
		}

		public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
		{
			throw new NotImplementedException();
		}

		public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			Message message = Message.CreateMessage(new c65c53e4bcb4263998a3022f881765f91(stream, null), maxSizeOfHeaders, MessageVersion.None);
			message.Properties.Encoder = this;
			return message;
		}

		public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
		{
			MemoryStream memoryStream = new MemoryStream();
			WriteEncodedMessage(message, memoryStream);
			return new ArraySegment(memoryStream.ToArray());
		}

		public override void WriteMessage(Message message, Stream stream)
		{
			WriteEncodedMessage(message, stream);
		}

		private void WriteEncodedMessage(Message message, Stream stream)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			message.Properties.Encoder = this;
			using cac363891aa3b9932536c282a02e19015 cac363891aa3b9932536c282a02e19016 = new cac363891aa3b9932536c282a02e19015(stream);
			message.WriteMessage(cac363891aa3b9932536c282a02e19016);
			cac363891aa3b9932536c282a02e19016.Flush();
		}
	}
	internal class ce99981e3adc56205d59f10e8767b1f7d : MessageEncoderFactory
	{
		public override MessageEncoder Encoder => new c274d7b988b53c49d68155f1d7e8b7032();

		public override MessageVersion MessageVersion => MessageVersion.None;
	}
	internal class c7d26dca8405829051a712a9045e43705 : MessageEncodingBindingElement
	{
		public override MessageVersion MessageVersion
		{
			get
			{
				return MessageVersion.None;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public c7d26dca8405829051a712a9045e43705()
		{
		}

		protected c7d26dca8405829051a712a9045e43705(MessageEncodingBindingElement elementToBeCloned)
			: base(elementToBeCloned)
		{
		}

		public override MessageEncoderFactory CreateMessageEncoderFactory()
		{
			return new ce99981e3adc56205d59f10e8767b1f7d();
		}

		public override IChannelFactory BuildChannelFactory(BindingContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (CanBuildChannelFactory(context))
			{
				/*OpCode not supported: LdMemberToken*/;
				context.BindingParameters.Add(this);
				return context.BuildInnerChannelFactory();
			}
			throw new InvalidOperationException($"Channel Not Supported - {typeof(TChannel).Name}");
		}

		public override bool CanBuildChannelFactory(BindingContext context)
		{
			if (context != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return typeof(TChannel) == typeof(IRequestChannel);
			}
			throw new ArgumentNullException("context");
		}

		public override IChannelListener BuildChannelListener(BindingContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (CanBuildChannelListener(context))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (context.BindingParameters.Contains(this))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					context.BindingParameters.Add(this);
				}
				return context.BuildInnerChannelListener();
			}
			throw new InvalidOperationException($"Channel Not Supported - {typeof(TChannel).Name}");
		}

		public override bool CanBuildChannelListener(BindingContext context)
		{
			if (context != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!context.BindingParameters.Contains(this))
				{
					context.BindingParameters.Add(this);
				}
				return typeof(TChannel) == typeof(IReplyChannel);
			}
			throw new ArgumentNullException("context");
		}

		public override BindingElement Clone()
		{
			return new c7d26dca8405829051a712a9045e43705(this);
		}
	}
	internal class ca09ae07266bf2c48eb4ddeb0fcfcec19 : BindingElementExtensionElement
	{
		private ConfigurationPropertyCollection c2ef6e20f0510406b2de04b47d177c9b9;

		public override Type BindingElementType => typeof(ca09ae07266bf2c48eb4ddeb0fcfcec19);

		[IntegerValidator(MinValue = 1)]
		[ConfigurationProperty("maxReadPoolSize", DefaultValue = 64)]
		public int MaxReadPoolSize
		{
			get
			{
				return (int)base["maxReadPoolSize"];
			}
			set
			{
				base["maxReadPoolSize"] = value;
			}
		}

		[ConfigurationProperty("maxWritePoolSize", DefaultValue = 16)]
		[IntegerValidator(MinValue = 1)]
		public int MaxWritePoolSize
		{
			get
			{
				return (int)base["maxWritePoolSize"];
			}
			set
			{
				base["maxWritePoolSize"] = value;
			}
		}

		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				if (c2ef6e20f0510406b2de04b47d177c9b9 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ConfigurationPropertyCollection configurationPropertyCollection = new ConfigurationPropertyCollection();
					configurationPropertyCollection.Add(new ConfigurationProperty("maxReadPoolSize", typeof(int), 64, null, new IntegerValidator(1, int.MaxValue, rangeIsExclusive: false), ConfigurationPropertyOptions.None));
					configurationPropertyCollection.Add(new ConfigurationProperty("maxWritePoolSize", typeof(int), 16, null, new IntegerValidator(1, int.MaxValue, rangeIsExclusive: false), ConfigurationPropertyOptions.None));
					configurationPropertyCollection.Add(new ConfigurationProperty("readerQuotas", typeof(XmlDictionaryReaderQuotasElement), null, null, null, ConfigurationPropertyOptions.None));
					c2ef6e20f0510406b2de04b47d177c9b9 = configurationPropertyCollection;
				}
				return c2ef6e20f0510406b2de04b47d177c9b9;
			}
		}

		[ConfigurationProperty("readerQuotas")]
		public XmlDictionaryReaderQuotasElement ReaderQuotas => (XmlDictionaryReaderQuotasElement)base["readerQuotas"];

		public override void ApplyConfiguration(BindingElement bindingElement)
		{
			base.ApplyConfiguration(bindingElement);
		}

		public override void CopyFrom(ServiceModelExtensionElement from)
		{
			base.CopyFrom(from);
			TextMessageEncodingElement textMessageEncodingElement = (TextMessageEncodingElement)from;
			MaxReadPoolSize = textMessageEncodingElement.MaxReadPoolSize;
			MaxWritePoolSize = textMessageEncodingElement.MaxWritePoolSize;
		}

		protected override BindingElement CreateBindingElement()
		{
			c7d26dca8405829051a712a9045e43705 c7d26dca8405829051a712a9045e43706 = new c7d26dca8405829051a712a9045e43705();
			ApplyConfiguration(c7d26dca8405829051a712a9045e43706);
			return c7d26dca8405829051a712a9045e43706;
		}

		protected override void InitializeFrom(BindingElement bindingElement)
		{
			base.InitializeFrom(bindingElement);
			_ = (c7d26dca8405829051a712a9045e43705)bindingElement;
		}
	}
	internal class c05ef08f0b692fce1a8adccb1bcb1b863 : IEndpointBehavior, IDispatchOperationSelector
	{
		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
			endpointDispatcher.DispatchRuntime.OperationSelector = this;
			endpointDispatcher.ContractFilter = new c66b4ace2210cffe3e7f1bcebc32c3dbc();
			endpointDispatcher.AddressFilter = new c66b4ace2210cffe3e7f1bcebc32c3dbc();
		}

		public void Validate(ServiceEndpoint endpoint)
		{
		}

		public string SelectOperation(ref Message message)
		{
			return "ProcessRequest";
		}
	}
	internal class c66b4ace2210cffe3e7f1bcebc32c3dbc : MessageFilter
	{
		public override bool Match(Message message)
		{
			return true;
		}

		public override bool Match(MessageBuffer buffer)
		{
			return true;
		}
	}
	internal class c899778c0b509372178206c18b7459ef4 : Attribute, IOperationBehavior
	{
		public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
		{
		}

		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
			dispatchOperation.Formatter = new c4f15cd5be244132740dc2ca190c09b0c(operationDescription);
		}

		public void Validate(OperationDescription operationDescription)
		{
		}
	}
	internal class c05f011beb5abd2ea363d4c9607c83112 : cc5493c4d24769facba3e8ccf0d9f6c9f
	{
		private readonly OperationContext cd0c51359af2cb24eafa122eb3f0c8d4a;

		private readonly Stream c345903b631440726388c6645bbb4e37f;

		internal c05f011beb5abd2ea363d4c9607c83112(OperationContext objOperationContext, Stream objRequestStream)
		{
			cd0c51359af2cb24eafa122eb3f0c8d4a = objOperationContext;
			c345903b631440726388c6645bbb4e37f = objRequestStream;
		}

		protected override c2f083329b832bfcd1ac0ca00333517cf CreateRequestContext()
		{
			return new ccd14c4e86ac9df73fc71db6f462c8261(GetRequestMessageProperty(), cd0c51359af2cb24eafa122eb3f0c8d4a.IncomingMessageHeaders.To, c345903b631440726388c6645bbb4e37f);
		}

		protected override ceef7f894921bcd269a4ecca3829f5747 CreateResponseContext()
		{
			return new ce40a3ca2295806a368ab1bb00c91d43a(GetResponseMessageProperty());
		}

		private HttpResponseMessageProperty GetResponseMessageProperty()
		{
			if (cd0c51359af2cb24eafa122eb3f0c8d4a.OutgoingMessageProperties.ContainsKey(HttpResponseMessageProperty.Name))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				HttpResponseMessageProperty httpResponseMessageProperty = new HttpResponseMessageProperty();
				httpResponseMessageProperty.Headers[HttpResponseHeader.ContentType] = "text/html";
				cd0c51359af2cb24eafa122eb3f0c8d4a.OutgoingMessageProperties.Add(HttpResponseMessageProperty.Name, httpResponseMessageProperty);
			}
			return cd0c51359af2cb24eafa122eb3f0c8d4a.OutgoingMessageProperties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
		}

		private HttpRequestMessageProperty GetRequestMessageProperty()
		{
			if (cd0c51359af2cb24eafa122eb3f0c8d4a.IncomingMessageProperties != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (cd0c51359af2cb24eafa122eb3f0c8d4a.IncomingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
				{
					/*OpCode not supported: LdMemberToken*/;
					return cd0c51359af2cb24eafa122eb3f0c8d4a.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
				}
				return null;
			}
			return null;
		}
	}
	internal class ccd14c4e86ac9df73fc71db6f462c8261 : c2f083329b832bfcd1ac0ca00333517cf
	{
		private readonly HttpRequestMessageProperty cdd0a59072169236d2b1ab6fd6470c071;

		private readonly Uri c3d0430e35a3fbd64b372f2db3c078e14;

		private readonly Stream c345903b631440726388c6645bbb4e37f;

		private c95df08bd4b9e4ffcc8088c4a1158cab5 cca36663d1bd206ff44fab0f5db668bf6;

		private c8a2e6509a4d765ea0a1dadc462172f91 c2b5ce7f7a0d2fd0cf5c029026ff5edce;

		public override string UserAgent
		{
			get
			{
				string text = cdd0a59072169236d2b1ab6fd6470c071.Headers[HttpRequestHeader.UserAgent];
				if (text == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return string.Empty;
				}
				return text;
			}
		}

		public override Uri Url => c3d0430e35a3fbd64b372f2db3c078e14;

		public override string Method => cdd0a59072169236d2b1ab6fd6470c071.Method;

		public override NameValueCollection QueryString
		{
			get
			{
				if (cca36663d1bd206ff44fab0f5db668bf6 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					LoadQueryStringValues();
				}
				return cca36663d1bd206ff44fab0f5db668bf6;
			}
		}

		public override Stream InputStream => c345903b631440726388c6645bbb4e37f;

		public override string RawUrl
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		internal ccd14c4e86ac9df73fc71db6f462c8261(HttpRequestMessageProperty objHttpRequestMessageProperty, Uri objHttpRequestUri, Stream objRequestStream)
		{
			cdd0a59072169236d2b1ab6fd6470c071 = objHttpRequestMessageProperty;
			c3d0430e35a3fbd64b372f2db3c078e14 = objHttpRequestUri;
			c345903b631440726388c6645bbb4e37f = objRequestStream;
		}

		private void LoadQueryStringValues()
		{
			cca36663d1bd206ff44fab0f5db668bf6 = new c95df08bd4b9e4ffcc8088c4a1158cab5();
			LoadUrlEncodedContent(cca36663d1bd206ff44fab0f5db668bf6, cdd0a59072169236d2b1ab6fd6470c071.QueryString);
			cca36663d1bd206ff44fab0f5db668bf6.MakeReadOnly();
		}

		private void LoadUrlEncodedContent(NameValueCollection objNameValueCollection, string strRequestContent)
		{
			string[] array = strRequestContent.Split('?', '=', '&');
			for (int i = 0; i < array.Length; i += 2)
			{
				if (array.Length > i + 1)
				{
					objNameValueCollection[array[i]] = HttpUtility.UrlDecode(array[i + 1]);
				}
			}
		}

		protected override c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders()
		{
			return new c026df48457d2512ec2c42989bee314c1(cdd0a59072169236d2b1ab6fd6470c071.Headers);
		}

		public override c8a2e6509a4d765ea0a1dadc462172f91 CreateCookies()
		{
			if (c2b5ce7f7a0d2fd0cf5c029026ff5edce == null)
			{
				c2b5ce7f7a0d2fd0cf5c029026ff5edce = new c8a2e6509a4d765ea0a1dadc462172f91();
				FillInCookiesCollection(c2b5ce7f7a0d2fd0cf5c029026ff5edce);
			}
			return c2b5ce7f7a0d2fd0cf5c029026ff5edce;
		}

		private cf7ad5d0b2c305a159d5fa4d6a6d7532d CreateCookieFromString(string s)
		{
			cf7ad5d0b2c305a159d5fa4d6a6d7532d cf7ad5d0b2c305a159d5fa4d6a6d7532d2 = new cf7ad5d0b2c305a159d5fa4d6a6d7532d();
			int num;
			if (s != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				num = s.Length;
			}
			else
			{
				num = 0;
			}
			int num2 = num;
			int num3 = 0;
			bool flag = true;
			int num4 = 1;
			int num5;
			for (; num3 < num2; num3 = num5 + 1)
			{
				/*OpCode not supported: LdMemberToken*/;
				num5 = s.IndexOf('&', num3);
				if (num5 >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					num5 = num2;
				}
				if (!flag)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00ab;
				}
				int num6 = s.IndexOf('=', num3);
				if (num6 < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (num6 < num5)
				{
					cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Name = s.Substring(num3, num6 - num3);
					num3 = num6 + 1;
					goto IL_00a9;
				}
				if (num5 != num2)
				{
					/*OpCode not supported: LdMemberToken*/;
					goto IL_00a9;
				}
				cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Name = s;
				return cf7ad5d0b2c305a159d5fa4d6a6d7532d2;
				IL_00a9:
				flag = false;
				goto IL_00ab;
				IL_00ab:
				num6 = s.IndexOf('=', num3);
				if (num6 >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (num5 != num2)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (num4 == 0)
					{
						cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Value = s.Substring(num3, num2 - num3);
						continue;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				if (num6 < 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (num6 < num5)
				{
					cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Values.Add(s.Substring(num3, num6 - num3), s.Substring(num6 + 1, num5 - num6 - 1));
					num4++;
					continue;
				}
				cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Values.Add(null, s.Substring(num3, num5 - num3));
				num4++;
			}
			return cf7ad5d0b2c305a159d5fa4d6a6d7532d2;
		}

		private string GetRequestHeader(HttpRequestHeader enmHttpRequestHeader, string strDefaultValue)
		{
			string text = base.Headers[enmHttpRequestHeader];
			if (!string.IsNullOrEmpty(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = strDefaultValue;
			}
			return text;
		}

		internal void FillInCookiesCollection(c8a2e6509a4d765ea0a1dadc462172f91 cookieCollection)
		{
			string requestHeader = GetRequestHeader(HttpRequestHeader.Cookie, "");
			int num = requestHeader?.Length ?? 0;
			int num2 = 0;
			cf7ad5d0b2c305a159d5fa4d6a6d7532d cf7ad5d0b2c305a159d5fa4d6a6d7532d2 = null;
			while (num2 < num)
			{
				/*OpCode not supported: LdMemberToken*/;
				int i;
				for (i = num2; i < num; i++)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (requestHeader[i] == ';')
					{
						/*OpCode not supported: LdMemberToken*/;
						break;
					}
				}
				string text = requestHeader.Substring(num2, i - num2).Trim();
				num2 = i + 1;
				if (text.Length == 0)
				{
					continue;
				}
				cf7ad5d0b2c305a159d5fa4d6a6d7532d cf7ad5d0b2c305a159d5fa4d6a6d7532d3 = CreateCookieFromString(text);
				if (cf7ad5d0b2c305a159d5fa4d6a6d7532d2 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string name = cf7ad5d0b2c305a159d5fa4d6a6d7532d3.Name;
					if (name == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (name.Length > 0)
					{
						if (name[0] == '$')
						{
							if (!name.Equals("$Path", StringComparison.InvariantCultureIgnoreCase))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (!name.Equals("$Domain", StringComparison.InvariantCultureIgnoreCase))
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Domain = cf7ad5d0b2c305a159d5fa4d6a6d7532d3.Value;
								}
							}
							else
							{
								cf7ad5d0b2c305a159d5fa4d6a6d7532d2.Path = cf7ad5d0b2c305a159d5fa4d6a6d7532d3.Value;
							}
							continue;
						}
						/*OpCode not supported: LdMemberToken*/;
					}
				}
				c2b5ce7f7a0d2fd0cf5c029026ff5edce.AddCookie(cf7ad5d0b2c305a159d5fa4d6a6d7532d3, blnAppend: true);
				cf7ad5d0b2c305a159d5fa4d6a6d7532d2 = cf7ad5d0b2c305a159d5fa4d6a6d7532d3;
			}
		}
	}
	internal class ce40a3ca2295806a368ab1bb00c91d43a : ceef7f894921bcd269a4ecca3829f5747
	{
		private HttpResponseMessageProperty c3b5dee40f3890ae26aa8130ddba97008;

		private MemoryStream cd08baebddf9e8700312fb2806de24716;

		private Encoding c4564bdacf0e27874fdfe7cd843ec92cc = Encoding.UTF8;

		private string c474f3a05a0e7acf0c7a304176b277caf = "text/html";

		public override string StatusDescription
		{
			get
			{
				return c3b5dee40f3890ae26aa8130ddba97008.StatusDescription;
			}
			set
			{
				c3b5dee40f3890ae26aa8130ddba97008.StatusDescription = value;
			}
		}

		public override int StatusCode
		{
			get
			{
				return (int)c3b5dee40f3890ae26aa8130ddba97008.StatusCode;
			}
			set
			{
				c3b5dee40f3890ae26aa8130ddba97008.StatusCode = (HttpStatusCode)value;
			}
		}

		public override Stream OutputStream
		{
			get
			{
				if (cd08baebddf9e8700312fb2806de24716 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cd08baebddf9e8700312fb2806de24716 = new MemoryStream();
				}
				return cd08baebddf9e8700312fb2806de24716;
			}
		}

		public override Encoding ContentEncoding
		{
			get
			{
				return c4564bdacf0e27874fdfe7cd843ec92cc;
			}
			set
			{
				c4564bdacf0e27874fdfe7cd843ec92cc = value;
			}
		}

		public override string ContentType
		{
			get
			{
				return c474f3a05a0e7acf0c7a304176b277caf;
			}
			set
			{
				c474f3a05a0e7acf0c7a304176b277caf = value;
			}
		}

		internal ce40a3ca2295806a368ab1bb00c91d43a(HttpResponseMessageProperty objHttpResponseMessageProperty)
		{
			c3b5dee40f3890ae26aa8130ddba97008 = objHttpResponseMessageProperty;
		}

		protected override c17eb5257c817ec33d2ee18a3ea3e22dd CreateHeaders()
		{
			return new c026df48457d2512ec2c42989bee314c1(c3b5dee40f3890ae26aa8130ddba97008.Headers);
		}

		public override void Flush(bool blnIsFinal)
		{
			if (cd08baebddf9e8700312fb2806de24716 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cd08baebddf9e8700312fb2806de24716.Flush();
			}
		}

		public override void Close(cace92c1d33698dcd2e5827f7129bb7f3 objResponse)
		{
		}

		public override void WriteCookieHeader(cc5d4538b8a75eeeda8789c0af1e3f5cf objHostContext, c8a2e6509a4d765ea0a1dadc462172f91 objHostResponseCookies)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < objHostResponseCookies.Count; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				cf7ad5d0b2c305a159d5fa4d6a6d7532d cf7ad5d0b2c305a159d5fa4d6a6d7532d2 = (cf7ad5d0b2c305a159d5fa4d6a6d7532d)objHostResponseCookies[i];
				stringBuilder.Append(cf7ad5d0b2c305a159d5fa4d6a6d7532d2.GetSetCookieHeader(objHostContext));
				stringBuilder.Append(';');
			}
			base.Headers[HttpResponseHeader.SetCookie] = stringBuilder.ToString();
		}

		public override void WriteGeneratedHeaders(Dictionary<string, string> objGeneratedHeaders)
		{
			base.Headers.Add("Content-Type", c474f3a05a0e7acf0c7a304176b277caf);
			using Dictionary<string, string>.Enumerator enumerator = objGeneratedHeaders.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				KeyValuePair<string, string> current = enumerator.Current;
				string key = current.Key;
				if (key == "Content-Type")
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					base.Headers.Add(current.Key, current.Value);
				}
			}
		}
	}
	internal class c026df48457d2512ec2c42989bee314c1 : c17eb5257c817ec33d2ee18a3ea3e22dd
	{
		private WebHeaderCollection cc8eb39cb40ff05d8aafe72f6a69a6158;

		public override string this[HttpResponseHeader header]
		{
			get
			{
				return cc8eb39cb40ff05d8aafe72f6a69a6158[header];
			}
			set
			{
				cc8eb39cb40ff05d8aafe72f6a69a6158[header] = value;
			}
		}

		public override string this[HttpRequestHeader header]
		{
			get
			{
				return cc8eb39cb40ff05d8aafe72f6a69a6158[header];
			}
			set
			{
				cc8eb39cb40ff05d8aafe72f6a69a6158[header] = value;
			}
		}

		internal c026df48457d2512ec2c42989bee314c1(WebHeaderCollection objHeaders)
			: base(objHeaders)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158 = objHeaders;
		}

		public override void Add(HttpRequestHeader header, string value)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158.Add(header, value);
		}

		public override void Add(HttpResponseHeader header, string value)
		{
			cc8eb39cb40ff05d8aafe72f6a69a6158.Add(header, value);
		}
	}
}
namespace Gizmox.WebGUI.Server.Hosting.Providers
{
	[ServiceContract]
	internal interface IWgxMessageRouterService
	{
		[OperationContract(Action = "*", ReplyAction = "*")]
		[c899778c0b509372178206c18b7459ef4]
		Stream ProcessRequest(Stream objInput);
	}
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class ServiceRouter : Router, IWgxMessageRouterService
	{
		public Stream ProcessRequest(Stream objInputStream)
		{
			cc5d4538b8a75eeeda8789c0af1e3f5cf cc5d4538b8a75eeeda8789c0af1e3f5cf = (cc5d4538b8a75eeeda8789c0af1e3f5cf)(HostContext.Current = new cc5d4538b8a75eeeda8789c0af1e3f5cf(new c05f011beb5abd2ea363d4c9607c83112(OperationContext.Current, objInputStream)));
			cace92c1d33698dcd2e5827f7129bb7f3 cace92c1d33698dcd2e5827f7129bb7f = (cace92c1d33698dcd2e5827f7129bb7f3)cc5d4538b8a75eeeda8789c0af1e3f5cf.Response;
			try
			{
				HostHttpHandler handler = GetHandler(cc5d4538b8a75eeeda8789c0af1e3f5cf);
				if (handler == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					handler.ProcessRequest(cc5d4538b8a75eeeda8789c0af1e3f5cf);
				}
				cace92c1d33698dcd2e5827f7129bb7f.Flush(blnIsFinal: true);
			}
			catch (Exception ex)
			{
				HostException ex2 = ex as HostException;
				if (ex2 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ex2 = new HostException(ex.Message, ex);
				}
				cace92c1d33698dcd2e5827f7129bb7f.StatusCode = ex2.GetHttpCode();
				cace92c1d33698dcd2e5827f7129bb7f.ContentType = "text/html";
				cace92c1d33698dcd2e5827f7129bb7f.ClearContent();
				cace92c1d33698dcd2e5827f7129bb7f.Write(ex2.GetHtmlErrorMessage());
			}
			Stream outputStream = cc5d4538b8a75eeeda8789c0af1e3f5cf.Response.OutputStream;
			outputStream.Position = 0L;
			return outputStream;
		}

		protected override HostRuntime CreateHostRuntimeInstance()
		{
			return new cd7828cf49a0345d31ec56391fc89818e();
		}
	}
}
namespace A
{
	internal class c4f15cd5be244132740dc2ca190c09b0c : IClientMessageFormatter, IDispatchMessageFormatter
	{
		private string c3f4ef78e7d93675289acd47c575ce339;

		private string cbb697a44cca12ac9b5828c44b81d9cf5;

		private string cff06c8a4bd4d294ff480d54b9a563ddd;

		public c4f15cd5be244132740dc2ca190c09b0c(OperationDescription operation)
		{
			if (operation != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				cff06c8a4bd4d294ff480d54b9a563ddd = operation.Name;
				c3f4ef78e7d93675289acd47c575ce339 = operation.DeclaringContract.Name;
				cbb697a44cca12ac9b5828c44b81d9cf5 = operation.DeclaringContract.Namespace;
				return;
			}
			throw new ArgumentNullException("operation");
		}

		private Message CreateMessageFromStream(object data)
		{
			if (data != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Stream objStream = (data as Stream) ?? throw new ArgumentNullException("data");
				/*OpCode not supported: LdMemberToken*/;
				return new c789b4c651116176c84514d9304ff9038(objStream);
			}
			return Message.CreateMessage(MessageVersion.None, null);
		}

		public object DeserializeReply(Message message, object[] parameters)
		{
			return GetStreamFromMessage(message, isRequest: false);
		}

		public void DeserializeRequest(Message message, object[] parameters)
		{
			parameters[0] = GetStreamFromMessage(message, isRequest: true);
		}

		private Stream GetStreamFromMessage(Message message, bool isRequest)
		{
			return new cc0188db8cbae7af55a4f39e59c985f68(message, null, null, "Binary", string.Empty, isRequest);
		}

		internal static bool IsEmptyMessage(Message message)
		{
			return message.IsEmpty;
		}

		public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
		{
			return CreateMessageFromStream(result);
		}

		public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
		{
			return CreateMessageFromStream(parameters[0]);
		}
	}
	internal class c88d621fab5cdf8581691951923d7cf75
	{
		public static bool IsFatal(Exception objException)
		{
			return false;
		}
	}
	internal class c65c53e4bcb4263998a3022f881765f91 : XmlDictionaryReader
	{
		private enum c27c003d222543a738e3ce2a98ff58a0e
		{
			c15237c974999eadccdef6285120a2d16,
			c7d11793b9081c240eb01cdb31b90c0d4,
			cadb91a70b2f2eb1a2b09c39b2f3b9aba,
			c582069cf41774b23ba5fb2c01246ac44,
			ca7417e035c0868c6aab170c90bf3b07e
		}

		private string c0c956c9f95e31bd953a148e7a5d335b2;

		private const int c5a58160069d361231131d570bb586e80 = 1024;

		private bool c24c3902a27e8ab03a437f825e97edc3d;

		private NameTable c9322f3a1d826b7c4bac14b229e862ffd;

		private c27c003d222543a738e3ce2a98ff58a0e cbce438242d9ef67d03d9872f6b10f24c;

		private XmlDictionaryReaderQuotas c2c01157c3342e1e7b2b1225dff858ed5;

		private bool cb7889c3623fa9ef7bb693ea1c68a7042;

		private Stream c56f373e57dd343bf7ff4fff62ca50605;

		public override int AttributeCount => 0;

		public override string BaseURI => string.Empty;

		public override bool CanCanonicalize => false;

		public override bool CanReadBinaryContent => true;

		public override bool CanReadValueChunk => false;

		public override bool CanResolveEntity => false;

		public override int Depth
		{
			get
			{
				if (cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba)
				{
					/*OpCode not supported: LdMemberToken*/;
					return 1;
				}
				return 0;
			}
		}

		public override bool EOF => cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e;

		public override bool HasAttributes => false;

		public override bool HasValue => cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba;

		public override bool IsDefault => false;

		public override bool IsEmptyElement => false;

		public override string LocalName
		{
			get
			{
				if (cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4)
				{
					/*OpCode not supported: LdMemberToken*/;
					return "Binary";
				}
				return null;
			}
		}

		public override string NamespaceURI => string.Empty;

		public override XmlNameTable NameTable
		{
			get
			{
				if (c9322f3a1d826b7c4bac14b229e862ffd != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c9322f3a1d826b7c4bac14b229e862ffd = new NameTable();
					c9322f3a1d826b7c4bac14b229e862ffd.Add("ProcessRequest");
				}
				return c9322f3a1d826b7c4bac14b229e862ffd;
			}
		}

		public override XmlNodeType NodeType => cbce438242d9ef67d03d9872f6b10f24c switch
		{
			c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4 => XmlNodeType.Element, 
			c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba => XmlNodeType.Text, 
			c27c003d222543a738e3ce2a98ff58a0e.c582069cf41774b23ba5fb2c01246ac44 => XmlNodeType.EndElement, 
			c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e => XmlNodeType.None, 
			_ => XmlNodeType.None, 
		};

		public override string Prefix => string.Empty;

		public override XmlDictionaryReaderQuotas Quotas => c2c01157c3342e1e7b2b1225dff858ed5;

		public override ReadState ReadState
		{
			get
			{
				switch (cbce438242d9ef67d03d9872f6b10f24c)
				{
				case c27c003d222543a738e3ce2a98ff58a0e.c15237c974999eadccdef6285120a2d16:
					return ReadState.Initial;
				case c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4:
				case c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba:
				case c27c003d222543a738e3ce2a98ff58a0e.c582069cf41774b23ba5fb2c01246ac44:
					return ReadState.Interactive;
				case c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e:
					return ReadState.Closed;
				default:
					return ReadState.Error;
				}
			}
		}

		public override string Value
		{
			get
			{
				if (cbce438242d9ef67d03d9872f6b10f24c != c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba)
				{
					/*OpCode not supported: LdMemberToken*/;
					return string.Empty;
				}
				return GetStreamAsBase64String();
			}
		}

		public c65c53e4bcb4263998a3022f881765f91(Stream stream, XmlDictionaryReaderQuotas quotas)
		{
			if (stream != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				c56f373e57dd343bf7ff4fff62ca50605 = stream;
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.c15237c974999eadccdef6285120a2d16;
				if (quotas == null)
				{
					quotas = XmlDictionaryReaderQuotas.Max;
				}
				c2c01157c3342e1e7b2b1225dff858ed5 = quotas;
				return;
			}
			throw new ArgumentNullException("stream");
		}

		public override void Close()
		{
			if (!c24c3902a27e8ab03a437f825e97edc3d)
			{
				try
				{
					c56f373e57dd343bf7ff4fff62ca50605.Close();
				}
				finally
				{
					cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e;
					c24c3902a27e8ab03a437f825e97edc3d = true;
				}
			}
		}

		private void EnsureInStream()
		{
			if (cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new XmlException("badddd....");
		}

		public override string GetAttribute(int i)
		{
			throw new ArgumentOutOfRangeException("i");
		}

		public override string GetAttribute(string name)
		{
			return null;
		}

		public override string GetAttribute(string name, string namespaceURI)
		{
			return null;
		}

		private string GetStreamAsBase64String()
		{
			if (cb7889c3623fa9ef7bb693ea1c68a7042)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c0c956c9f95e31bd953a148e7a5d335b2 = Convert.ToBase64String(ReadContentAsBase64());
				cb7889c3623fa9ef7bb693ea1c68a7042 = true;
			}
			return c0c956c9f95e31bd953a148e7a5d335b2;
		}

		public override string LookupNamespace(string prefix)
		{
			if (prefix == string.Empty)
			{
				return string.Empty;
			}
			if (!(prefix == "xml"))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (prefix == "xmlns")
				{
					return "http://www.w3.org/2000/xmlns/";
				}
				return null;
			}
			return "http://www.w3.org/XML/1998/namespace";
		}

		public override bool MoveToAttribute(string name)
		{
			throw new XmlException("badd...");
		}

		public override bool MoveToAttribute(string name, string ns)
		{
			throw new XmlException("badd...");
		}

		public override bool MoveToElement()
		{
			if (cbce438242d9ef67d03d9872f6b10f24c == c27c003d222543a738e3ce2a98ff58a0e.c15237c974999eadccdef6285120a2d16)
			{
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4;
				return true;
			}
			return false;
		}

		public override bool MoveToFirstAttribute()
		{
			return false;
		}

		public override bool MoveToNextAttribute()
		{
			return false;
		}

		public override bool Read()
		{
			switch (cbce438242d9ef67d03d9872f6b10f24c)
			{
			case c27c003d222543a738e3ce2a98ff58a0e.c15237c974999eadccdef6285120a2d16:
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4;
				return true;
			case c27c003d222543a738e3ce2a98ff58a0e.c7d11793b9081c240eb01cdb31b90c0d4:
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba;
				return true;
			case c27c003d222543a738e3ce2a98ff58a0e.cadb91a70b2f2eb1a2b09c39b2f3b9aba:
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.c582069cf41774b23ba5fb2c01246ac44;
				return true;
			case c27c003d222543a738e3ce2a98ff58a0e.c582069cf41774b23ba5fb2c01246ac44:
				cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e;
				return false;
			case c27c003d222543a738e3ce2a98ff58a0e.ca7417e035c0868c6aab170c90bf3b07e:
				return false;
			default:
				return false;
			}
		}

		public override bool ReadAttributeValue()
		{
			return false;
		}

		public override int ReadContentAsBase64(byte[] buffer, int index, int count)
		{
			if (buffer != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (index >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (count >= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						EnsureInStream();
						int num = c56f373e57dd343bf7ff4fff62ca50605.Read(buffer, index, count);
						if (num == 0)
						{
							cbce438242d9ef67d03d9872f6b10f24c = c27c003d222543a738e3ce2a98ff58a0e.c582069cf41774b23ba5fb2c01246ac44;
						}
						return num;
					}
					throw new ArgumentOutOfRangeException("count");
				}
				throw new ArgumentOutOfRangeException("index");
			}
			throw new ArgumentNullException("buffer");
		}

		public override int ReadContentAsBinHex(byte[] buffer, int index, int count)
		{
			throw new NotSupportedException();
		}

		public override void ResolveEntity()
		{
			throw new NotSupportedException();
		}
	}
	internal class cac363891aa3b9932536c282a02e19015 : XmlDictionaryWriter
	{
		private Stream c56f373e57dd343bf7ff4fff62ca50605;

		private WriteState cce024d50c8051cf7f1b4825179cfaf70;

		public override WriteState WriteState => cce024d50c8051cf7f1b4825179cfaf70;

		public cac363891aa3b9932536c282a02e19015(Stream objStream)
		{
			c56f373e57dd343bf7ff4fff62ca50605 = objStream;
			cce024d50c8051cf7f1b4825179cfaf70 = WriteState.Start;
		}

		public override void Close()
		{
			if (cce024d50c8051cf7f1b4825179cfaf70 == WriteState.Closed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			cce024d50c8051cf7f1b4825179cfaf70 = WriteState.Closed;
			c56f373e57dd343bf7ff4fff62ca50605.Close();
		}

		public override void Flush()
		{
			c56f373e57dd343bf7ff4fff62ca50605.Flush();
		}

		public override string LookupPrefix(string ns)
		{
			if (!(ns == string.Empty))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(ns == "http://www.w3.org/XML/1998/namespace"))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(ns == "http://www.w3.org/2000/xmlns/"))
					{
						/*OpCode not supported: LdMemberToken*/;
						return null;
					}
					return "xmlns";
				}
				return "xml";
			}
			return string.Empty;
		}

		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			if (buffer != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (index >= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (count >= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (count > buffer.Length - index)
						{
							throw new ArgumentOutOfRangeException("count");
						}
						ThrowIfClosed();
						c56f373e57dd343bf7ff4fff62ca50605.Write(buffer, index, count);
						cce024d50c8051cf7f1b4825179cfaf70 = WriteState.Content;
						return;
					}
					throw new ArgumentOutOfRangeException("count");
				}
				throw new ArgumentOutOfRangeException("index");
			}
			throw new ArgumentNullException("buffer");
		}

		private void ThrowIfClosed()
		{
			if (cce024d50c8051cf7f1b4825179cfaf70 != WriteState.Closed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new InvalidOperationException("Cannot write while closed.");
		}

		public override void WriteCData(string text)
		{
			throw new NotImplementedException();
		}

		public override void WriteCharEntity(char ch)
		{
			throw new NotImplementedException();
		}

		public override void WriteChars(char[] buffer, int index, int count)
		{
			throw new NotImplementedException();
		}

		public override void WriteComment(string text)
		{
			throw new NotImplementedException();
		}

		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			throw new NotImplementedException();
		}

		public override void WriteEndAttribute()
		{
			throw new NotImplementedException();
		}

		public override void WriteEndDocument()
		{
		}

		public override void WriteEndElement()
		{
			ThrowIfClosed();
			if (cce024d50c8051cf7f1b4825179cfaf70 == WriteState.Element)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (cce024d50c8051cf7f1b4825179cfaf70 == WriteState.Content)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			throw new XmlException("badddd");
		}

		public override void WriteEntityRef(string name)
		{
			throw new NotImplementedException();
		}

		public override void WriteFullEndElement()
		{
			throw new NotImplementedException();
		}

		public override void WriteProcessingInstruction(string name, string text)
		{
			throw new NotImplementedException();
		}

		public override void WriteRaw(string data)
		{
			throw new NotImplementedException();
		}

		public override void WriteRaw(char[] buffer, int index, int count)
		{
			throw new NotImplementedException();
		}

		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			throw new NotImplementedException();
		}

		public override void WriteStartDocument(bool standalone)
		{
			ThrowIfClosed();
		}

		public override void WriteStartDocument()
		{
			ThrowIfClosed();
		}

		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			ThrowIfClosed();
			cce024d50c8051cf7f1b4825179cfaf70 = WriteState.Element;
		}

		public override void WriteString(string text)
		{
			byte[] array = Convert.FromBase64String(text);
			WriteBase64(array, 0, array.Length);
		}

		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			throw new NotImplementedException();
		}

		public override void WriteWhitespace(string ws)
		{
			throw new NotImplementedException();
		}
	}
	#endif
	internal class c4b9d8940357a2004f101d96253adea63 : HttpException
	{
		public c4b9d8940357a2004f101d96253adea63()
			: base(404, "The requested application could not be found.")
		{
		}

		public c4b9d8940357a2004f101d96253adea63(string strMessage)
			: base(404, strMessage)
		{
		}
	}
	internal class ca365ef464ba7e87502aeda5f66cf2ebd : HttpException
	{
		public ca365ef464ba7e87502aeda5f66cf2ebd(string strExceptionMessage)
			: base(400, strExceptionMessage)
		{
		}
	}
	[CompilerGenerated]
	internal sealed class c03836b967832c5af40c98cf7300bc21d
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 6)]
		internal struct c0551663312abf2fcd040ca9d176ee1c4
		{
		}

		internal static readonly c0551663312abf2fcd040ca9d176ee1c4 ce668bbbb6572e5ef53619f9d283bb280/* Not supported: data(3F 00 3D 00 26 00) */;

		internal static uint ComputeStringHash(string s)
		{
			uint num = default(uint);
			if (s == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				num = 2166136261u;
				for (int i = 0; i < s.Length; i++)
				{
					num = (s[i] ^ num) * 16777619;
				}
			}
			return num;
		}
	}
}


