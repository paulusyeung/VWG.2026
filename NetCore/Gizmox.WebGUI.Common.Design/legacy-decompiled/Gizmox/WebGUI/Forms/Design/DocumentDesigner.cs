using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using A;
using Gizmox.VSIntegration;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Design.Host;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms.Design;

[ToolboxItemFilter("Gizmox.WebGUI.Forms")]
public abstract class DocumentDesigner : ScrollableControlDesigner, IClientDesignServices, c0ea366c6e22bc6f4872ab3d07ffe081e, IDesigner, IRootDesigner, ISelectionService, IDesignerSerializationService, IToolboxUser, IDisposable
{
	internal class c53dbbce1d9d6ee0f646e1b4b9136c85a : IMenuEditorService
	{
		private IMenuEditorService c91394d3661d2dd7e94a5636504e7de84;

		private DocumentDesigner c2e22f8750bcee89e8c53a79782472ea3;

		public c53dbbce1d9d6ee0f646e1b4b9136c85a(DocumentDesigner objClientDocumentDesigner, IMenuEditorService objInternalClientDocumentDesigner)
		{
			c91394d3661d2dd7e94a5636504e7de84 = objInternalClientDocumentDesigner;
			c2e22f8750bcee89e8c53a79782472ea3 = objClientDocumentDesigner;
		}

		public Menu GetMenu()
		{
			return c91394d3661d2dd7e94a5636504e7de84.GetMenu();
		}

		public bool IsActive()
		{
			return c91394d3661d2dd7e94a5636504e7de84.IsActive();
		}

		public bool MessageFilter(ref Message m)
		{
			return c91394d3661d2dd7e94a5636504e7de84.MessageFilter(ref m);
		}

		public void SetMenu(Menu menu)
		{
			c91394d3661d2dd7e94a5636504e7de84.SetMenu(menu);
		}

		public void SetSelection(MenuItem item)
		{
			if (item.Container == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c91394d3661d2dd7e94a5636504e7de84.SetSelection(item);
			}
		}
	}

	internal class c7a433c9901f38077a9d995a14590b833 : ContainerFilterService
	{
		private DocumentDesigner c2e22f8750bcee89e8c53a79782472ea3;

		public c7a433c9901f38077a9d995a14590b833(DocumentDesigner objClientDocumentDesigner)
		{
			c2e22f8750bcee89e8c53a79782472ea3 = objClientDocumentDesigner;
		}

		public override ComponentCollection FilterComponents(ComponentCollection objComponents)
		{
			if (!c2e22f8750bcee89e8c53a79782472ea3.IsDesignerInitializing)
			{
				if (c2e22f8750bcee89e8c53a79782472ea3.IsDesignerDisposing)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!c2e22f8750bcee89e8c53a79782472ea3.IsDesignerUnloading)
				{
					/*OpCode not supported: LdMemberToken*/;
					List<IComponent> list = new List<IComponent>();
					IEnumerator enumerator = objComponents.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							IComponent component = (IComponent)enumerator.Current;
							if (component is IFilteredCompoenent)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								list.Add(component);
							}
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
					return new ComponentCollection(list.ToArray());
				}
			}
			return objComponents;
		}
	}

	internal class cdeda86617d557eb7345123f5da4c4248 : IServiceContainer, IDisposable, IServiceProvider
	{
		private IServiceProvider cae9d693bf7358789745a79d913e9f60a;

		private Dictionary<Type, object> cb4736196cdaaee27454e28f91b967348;

		private bool c8f722c2f01c4b2ccc57832c47697501b;

		private IServiceContainer Container
		{
			get
			{
				IServiceContainer result = null;
				if (cae9d693bf7358789745a79d913e9f60a == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = (IServiceContainer)cae9d693bf7358789745a79d913e9f60a.GetService(typeof(IServiceContainer));
				}
				return result;
			}
		}

		private Dictionary<Type, object> Services
		{
			get
			{
				if (cb4736196cdaaee27454e28f91b967348 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					cb4736196cdaaee27454e28f91b967348 = new Dictionary<Type, object>();
				}
				return cb4736196cdaaee27454e28f91b967348;
			}
		}

		public cdeda86617d557eb7345123f5da4c4248(IServiceContainer objParentProvider)
		{
			cae9d693bf7358789745a79d913e9f60a = objParentProvider;
		}

		public void Dispose()
		{
			if (c8f722c2f01c4b2ccc57832c47697501b)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			c8f722c2f01c4b2ccc57832c47697501b = true;
			using Dictionary<Type, object>.KeyCollection.Enumerator enumerator = Services.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				Type current = enumerator.Current;
				if (!(current != typeof(IMenuCommandService)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(Services[current] is IDisposable disposable))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					disposable.Dispose();
				}
			}
		}

		public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
		{
			if (!promote)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IServiceContainer container = Container;
				if (container != null)
				{
					container.AddService(serviceType, callback, promote);
					return;
				}
			}
			if (!(serviceType == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				if (callback != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					_ = serviceType == typeof(IMenuCommandService);
					Services[serviceType] = callback;
					return;
				}
				throw new ArgumentNullException("callback");
			}
			throw new ArgumentNullException("serviceType");
		}

		public void AddService(Type serviceType, ServiceCreatorCallback callback)
		{
			AddService(serviceType, callback, promote: false);
		}

		public void AddService(Type serviceType, object serviceInstance, bool promote)
		{
			if (!promote)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IServiceContainer container = Container;
				if (container != null)
				{
					container.AddService(serviceType, serviceInstance, promote);
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (serviceInstance != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				Services[serviceType] = serviceInstance;
				return;
			}
			throw new ArgumentNullException("serviceInstance");
		}

		public void AddService(Type serviceType, object serviceInstance)
		{
			AddService(serviceType, serviceInstance, promote: false);
		}

		public void RemoveService(Type serviceType, bool promote)
		{
			if (!promote)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IServiceContainer container = Container;
				if (container != null)
				{
					container.RemoveService(serviceType, promote);
					return;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (!(serviceType == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				Services.Remove(serviceType);
				return;
			}
			throw new ArgumentNullException("serviceType");
		}

		public void RemoveService(Type serviceType)
		{
			RemoveService(serviceType, promote: false);
		}

		public object GetService(Type serviceType)
		{
			object obj = null;
			if (!Services.ContainsKey(serviceType))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = Services[serviceType];
			}
			if (!(obj is ServiceCreatorCallback))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = ((ServiceCreatorCallback)obj)(this, serviceType);
				if (obj == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (obj.GetType().IsCOMObject)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (serviceType.IsAssignableFrom(obj.GetType()))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					obj = null;
				}
				Services[serviceType] = obj;
			}
			if (obj != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (cae9d693bf7358789745a79d913e9f60a == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = cae9d693bf7358789745a79d913e9f60a.GetService(serviceType);
			}
			return obj;
		}
	}

	private bool cbb839226bc7d343f6b8a05a0f2b85d37;

	private bool c4a81e8b1edf2821b2d23661cb37f44a7;

	private bool ce9e8cfad68884fc52b80d7b7ea71658b;

	private static bool ce70439f44c1f861a343e2fed60562d6e;

	private bool c8853b50a23d6c5b83593cb35f510c893 = true;

	private bool cfc81215a41c271ffc2faf61006d1b828;

	private bool cb094c6a1ac6cbc6924d5d6507cee5a98;

	private bool ce0791a62305956c47285db876d1aaadb;

	private bool c0aebe43930109af962ddd3b49cffd824;

	private IDesignTimeDeviceRepository c973949642e2ed3bcc69a32cb0ea9da69;

	private Dictionary<string, SizeF> c90ba050e5d91f811359d937118b0db57 = new Dictionary<string, SizeF>();

	private Hashtable c202c55d3d502c9fae5c2f012cff4cd7d;

	private CodeDomLocalizationProvider ccf97179bcd82f4e7172a034748d7e517;

	private ClientDesignerExtenders c3fd699794d086d480adc6c928c5bf3cd;

	private string c525eb630fea51a316107792002312c4f;

	private EventHandlerList cba51a85763227e8ccaa17b66eed14d8a;

	private IContext cc964016db8f72d2070814faf8db78325;

	private IComponent c02d372e5ee0cf467f88d155247083a46;

	private Control c16a84cf8d1c28229324d4ead19247937;

	private IDesignerHost cdb48aa4e7dd6e2bf19b07a462fc57f04;

	private IDesigner ce246ad6b9329fd59bb390adad9300d1e;

	private IContainer cd6ccc4c7f063e81d30cb403897118eef;

	private IContainer cb5d0f1452073c18194f59fb5fc299ee9;

	private bool c28c3ea5a74b9788786d9d9acf5a8b809;

	private ServiceContainer c11bb41ea1daf1807b684b770cfa932c6;

	private cdeda86617d557eb7345123f5da4c4248 c636e79616d9f1e5e1bcdbe6de6d61e76;

	private Hashtable c7cd7e2d687b1696579dd1d1847c9e0c2;

	private static object c3e8235eb72072b645dfcb2add4885552;

	private static object caa3ef1e9e3625a197fd9165076a1d87f;

	public ViewTechnology[] SupportedTechnologies => new ViewTechnology[1] { ViewTechnology.Default };

	private bool IsNotificationSuspened => DesignContext.IsNotificationSuspened;

	public string ConfigurationFilePath
	{
		get
		{
			if (!string.IsNullOrEmpty(c525eb630fea51a316107792002312c4f))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c525eb630fea51a316107792002312c4f = GetConfigurationFilePath();
			}
			return c525eb630fea51a316107792002312c4f;
		}
	}

	IDesignTimeDeviceRepository IClientDesignServices.DesignTimeDeviceRepository
	{
		get
		{
			if (c973949642e2ed3bcc69a32cb0ea9da69 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c973949642e2ed3bcc69a32cb0ea9da69 = CommonUtils.GetProvider<IDesignTimeDeviceRepository>(GetDefaultDesignDeviceRepositoryString(), blnIsCache: false);
			}
			return c973949642e2ed3bcc69a32cb0ea9da69;
		}
	}

	private ISelectionService WebSelectionService => (ISelectionService)GetService(typeof(ISelectionService));

	object ISelectionService.PrimarySelection
	{
		get
		{
			if (WebSelectionService != null)
			{
				return GetMappedComponent(WebSelectionService.PrimarySelection, blnWinComponent: false);
			}
			return null;
		}
	}

	int ISelectionService.SelectionCount
	{
		get
		{
			if (WebSelectionService == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return 0;
			}
			return WebSelectionService.SelectionCount;
		}
	}

	internal bool IsDesignerInitializing => c8853b50a23d6c5b83593cb35f510c893;

	internal bool IsDesignerRefreshing => cfc81215a41c271ffc2faf61006d1b828;

	public bool IsDesignerUnloading => c0aebe43930109af962ddd3b49cffd824;

	public bool IsDesignerDisposing => cb094c6a1ac6cbc6924d5d6507cee5a98;

	internal IServiceContainer WinServiceContainer
	{
		get
		{
			if (c636e79616d9f1e5e1bcdbe6de6d61e76 == null)
			{
				c636e79616d9f1e5e1bcdbe6de6d61e76 = new cdeda86617d557eb7345123f5da4c4248((IServiceContainer)GetService(typeof(IServiceContainer)));
				c636e79616d9f1e5e1bcdbe6de6d61e76.AddService(typeof(IDesignerSerializationService), this);
				c636e79616d9f1e5e1bcdbe6de6d61e76.AddService(typeof(c0ea366c6e22bc6f4872ab3d07ffe081e), this);
				c636e79616d9f1e5e1bcdbe6de6d61e76.AddService(typeof(ISelectionService), this);
			}
			return c636e79616d9f1e5e1bcdbe6de6d61e76;
		}
	}

	internal IDesignerHost WinDesingerHost
	{
		get
		{
			if (cdb48aa4e7dd6e2bf19b07a462fc57f04 == null)
			{
				cdb48aa4e7dd6e2bf19b07a462fc57f04 = new ccc53407af8f11baecaaada159429c8fa(WinServiceContainer, Context);
			}
			return cdb48aa4e7dd6e2bf19b07a462fc57f04;
		}
	}

	internal ca8ff5d161d38d5b5f53f0832d3763eee ClientDesingerHost => (ca8ff5d161d38d5b5f53f0832d3763eee)WinDesingerHost;

	internal IDesignerHost WebDesingerHost => (IDesignerHost)GetService(typeof(IDesignerHost));

	internal IContextServices ContextServices => (IContextServices)Context;

	private IClinetDesignContext DesignContext => (IClinetDesignContext)Context;

	private IClientDesignServices DesignServices => this;

	internal IContainer WinRootContainer
	{
		get
		{
			if (cd6ccc4c7f063e81d30cb403897118eef == null)
			{
				cd6ccc4c7f063e81d30cb403897118eef = WinDesingerHost.Container;
			}
			return cd6ccc4c7f063e81d30cb403897118eef;
		}
	}

	internal IContainer WebRootContainer
	{
		get
		{
			if (cb5d0f1452073c18194f59fb5fc299ee9 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cb5d0f1452073c18194f59fb5fc299ee9 = WebDesingerHost.Container;
			}
			return cb5d0f1452073c18194f59fb5fc299ee9;
		}
	}

	private IDesigner WinRootDesigner
	{
		get
		{
			if (ce246ad6b9329fd59bb390adad9300d1e != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IComponent mappedComponent = GetMappedComponent(base.Component, blnWinComponent: false);
				ce246ad6b9329fd59bb390adad9300d1e = ((ccc53407af8f11baecaaada159429c8fa)WinRootContainer).GetDesigner(mappedComponent);
			}
			return ce246ad6b9329fd59bb390adad9300d1e;
		}
	}

	internal IToolboxService ToolboxService => (IToolboxService)GetService(typeof(IToolboxService));

	internal IServiceContainer LocalServiceContainer
	{
		get
		{
			if (c11bb41ea1daf1807b684b770cfa932c6 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c11bb41ea1daf1807b684b770cfa932c6 = new ServiceContainer((IServiceContainer)base.GetService(typeof(IServiceContainer)));
				c11bb41ea1daf1807b684b770cfa932c6.AddService(typeof(IMenuEditorService), OnCreateService);
				c11bb41ea1daf1807b684b770cfa932c6.AddService(typeof(ContainerFilterService), OnCreateService);
			}
			return c11bb41ea1daf1807b684b770cfa932c6;
		}
	}

	internal IServiceContainer DesignSurfaceServiceContainer => (IServiceContainer)base.GetService(typeof(IServiceContainer));

	internal IMenuEditorService MenuEditorService => (IMenuEditorService)GetService(typeof(IMenuEditorService));

	internal IDesignerSerializationService DesignerSerializationService => (IDesignerSerializationService)GetService(typeof(IDesignerSerializationService));

	internal IContext Context => cc964016db8f72d2070814faf8db78325;

	public event EventHandler SelectionChanged
	{
		add
		{
			cba51a85763227e8ccaa17b66eed14d8a.AddHandler(c3e8235eb72072b645dfcb2add4885552, value);
		}
		remove
		{
			cba51a85763227e8ccaa17b66eed14d8a.RemoveHandler(c3e8235eb72072b645dfcb2add4885552, value);
		}
	}

	public event EventHandler SelectionChanging
	{
		add
		{
			cba51a85763227e8ccaa17b66eed14d8a.AddHandler(caa3ef1e9e3625a197fd9165076a1d87f, value);
		}
		remove
		{
			cba51a85763227e8ccaa17b66eed14d8a.RemoveHandler(caa3ef1e9e3625a197fd9165076a1d87f, value);
		}
	}

	static DocumentDesigner()
	{
		ce70439f44c1f861a343e2fed60562d6e = false;
		c3e8235eb72072b645dfcb2add4885552 = new object();
		caa3ef1e9e3625a197fd9165076a1d87f = new object();
		if (HostContext.Current == null)
		{
			SerializableObject.IsSerializationEnabled = false;
		}
	}

	public DocumentDesigner()
	{
		c202c55d3d502c9fae5c2f012cff4cd7d = new Hashtable();
		cba51a85763227e8ccaa17b66eed14d8a = new EventHandlerList();
		cc964016db8f72d2070814faf8db78325 = ClientFactory.CreateContext(this);
		ConfigurationManager.AppSettings["EnableOptimizedDesignerReloading"] = "false";
	}

	internal void DoClientDefalutAction(object objWinComponent)
	{
	}

	private void StripEvents(object objControl)
	{
		if (objControl == null)
		{
			return;
		}
		if (!(GetService(typeof(IEventBindingService)) is IEventBindingService eventBindingService))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IEnumerator enumerator = eventBindingService.GetEventProperties(TypeDescriptor.GetEvents(objControl)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)enumerator.Current;
				if (propertyDescriptor != null)
				{
					if (propertyDescriptor.IsReadOnly)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (propertyDescriptor.GetValue(objControl) is string)
					{
						propertyDescriptor.SetValue(objControl, null);
					}
				}
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

	private object[] GetSelectableComponent(ICollection objWinComponents)
	{
		ArrayList arrayList = new ArrayList();
		if (objWinComponents == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			IEnumerator enumerator = objWinComponents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					IComponent objWinObject = (IComponent)enumerator.Current;
					IClientObjectController controllerByWinObject = ContextServices.GetControllerByWinObject(objWinObject);
					if (controllerByWinObject == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					object selectableObject = controllerByWinObject.SelectableObject;
					if (selectableObject == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!arrayList.Contains(selectableObject))
					{
						arrayList.Add(selectableObject);
					}
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
		return arrayList.ToArray();
	}

	protected override void PreFilterProperties(IDictionary objProperties)
	{
		base.PreFilterProperties(objProperties);
		string[] array = new string[5] { "Anchor", "Dock", "TabIndex", "TabStop", "Visible" };
		for (int i = 0; i < array.Length; i++)
		{
			PropertyDescriptor propertyDescriptor = (PropertyDescriptor)objProperties[array[i]];
			if (propertyDescriptor != null)
			{
				objProperties[array[i]] = TypeDescriptor.CreateProperty(propertyDescriptor.ComponentType, propertyDescriptor, BrowsableAttribute.No, DesignerSerializationVisibilityAttribute.Hidden);
			}
		}
	}

	public virtual object GetView(ViewTechnology enmTechnology)
	{
		if (c16a84cf8d1c28229324d4ead19247937 == null)
		{
			c16a84cf8d1c28229324d4ead19247937 = AddSurface((Control)GetView(ViewTechnology.Default, c02d372e5ee0cf467f88d155247083a46));
			if (c16a84cf8d1c28229324d4ead19247937 != null)
			{
				IClientObjectController controllerByWebObject = ((IContextServices)Context).GetControllerByWebObject(base.Component);
				if (controllerByWebObject == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					controllerByWebObject.Initialize();
					controllerByWebObject.Load();
				}
				RefreshDesigner();
				try
				{
					DesignContext.SuspendNotifications();
					((ccc53407af8f11baecaaada159429c8fa)WinDesingerHost).OnLoadComplete();
				}
				finally
				{
					DesignContext.ResumeNotifications();
				}
			}
		}
		return c16a84cf8d1c28229324d4ead19247937;
	}

	private Control AddSurface(Control control)
	{
		return SurfaceExtender.AddSurface(control, this);
	}

	protected virtual object GetView(ViewTechnology technology, IComponent objComponent)
	{
		return new Control();
	}

	public override void Initialize(IComponent objComponent)
	{
		c02d372e5ee0cf467f88d155247083a46 = objComponent;
		cfc81215a41c271ffc2faf61006d1b828 = !c8853b50a23d6c5b83593cb35f510c893;
		c8853b50a23d6c5b83593cb35f510c893 = true;
		base.Initialize(objComponent);
		if (!(objComponent is IForm form))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			form.SetContext(Context);
		}
		LoadApplicationConfiguration();
		IServiceContainer designSurfaceServiceContainer = DesignSurfaceServiceContainer;
		if (designSurfaceServiceContainer == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (designSurfaceServiceContainer.GetService(typeof(IInheritanceService)) == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				designSurfaceServiceContainer.RemoveService(typeof(IInheritanceService));
			}
			designSurfaceServiceContainer.AddService(typeof(IInheritanceService), new InheritanceService());
		}
		if (objComponent is IUserControl userControl)
		{
			userControl.SetContext(Context);
		}
		if (IsDesignerRefreshing)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (c3fd699794d086d480adc6c928c5bf3cd == null)
		{
			IExtenderProviderService extenderProviderService = (IExtenderProviderService)GetService(typeof(IExtenderProviderService));
			if (extenderProviderService == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c3fd699794d086d480adc6c928c5bf3cd = new ClientDesignerExtenders();
				c3fd699794d086d480adc6c928c5bf3cd.Extend(extenderProviderService);
			}
		}
		AddInheritedComponents();
		IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		if (designerHost == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			designerHost.LoadComplete += OnLoadComplete;
			designerHost.Deactivated += OnWebDesignerHostDeactivated;
			designerHost.Activated += OnWebDesignerHostActivated;
		}
		DesignSurface designSurface = (DesignSurface)GetService(typeof(DesignSurface));
		if (designSurface != null)
		{
			designSurface.Unloading += OnDesignSurfaceUnloading;
			designSurface.Unloaded += OnDesignSurfaceUnloaded;
		}
	}

	private object GetProjectProperty(string strProperty)
	{
		Type type = Type.GetType("EnvDTE.ProjectItem, EnvDTE", throwOnError: false);
		if (type != null)
		{
			Type type2 = Type.GetType("EnvDTE.Project, EnvDTE", throwOnError: false);
			if (!(type2 != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(Type.GetType("EnvDTE.ConfigurationManager, EnvDTE", throwOnError: false) != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(Type.GetType("EnvDTE.Configuration, EnvDTE", throwOnError: false) != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Type.GetType("EnvDTE.Properties, EnvDTE", throwOnError: false) != null)
			{
				Type type3 = Type.GetType("EnvDTE.Property, EnvDTE", throwOnError: false);
				if (!(type3 != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object service = GetService(type);
					if (service == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						PropertyInfo property = type.GetProperty("ContainingProject");
						if (property != null)
						{
							object value = property.GetValue(service, new object[0]);
							if (value == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								PropertyInfo property2 = type2.GetProperty("Properties");
								if (property2 != null)
								{
									IEnumerable enumerable = (IEnumerable)property2.GetValue(value, new object[0]);
									if (enumerable == null)
									{
										/*OpCode not supported: LdMemberToken*/;
									}
									else
									{
										PropertyInfo property3 = type3.GetProperty("Name");
										PropertyInfo property4 = type3.GetProperty("Value");
										{
											IEnumerator enumerator = enumerable.GetEnumerator();
											try
											{
												while (enumerator.MoveNext())
												{
													/*OpCode not supported: LdMemberToken*/;
													object current = enumerator.Current;
													if (!((string)property3.GetValue(current, new object[0]) == strProperty))
													{
														/*OpCode not supported: LdMemberToken*/;
														continue;
													}
													return property4.GetValue(current, new object[0]);
												}
											}
											finally
											{
												IDisposable disposable = enumerator as IDisposable;
												if (disposable != null)
												{
													disposable.Dispose();
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return null;
	}

	private bool ShouldUpgradeProject()
	{
		object projectProperty = GetProjectProperty("FullPath");
		object projectProperty2 = GetProjectProperty("FileName");
		if (projectProperty == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (projectProperty2 != null)
		{
			return ProjectHelper.ShouldUpgrageProjectAt(Path.Combine((string)projectProperty, (string)projectProperty2));
		}
		return false;
	}

	private void OnDesignSurfaceUnloaded(object sender, EventArgs e)
	{
		c0aebe43930109af962ddd3b49cffd824 = false;
	}

	private void OnDesignSurfaceUnloading(object sender, EventArgs e)
	{
		c0aebe43930109af962ddd3b49cffd824 = true;
	}

	private void AddInheritedComponents()
	{
		if (!(GetService(typeof(IInheritanceService)) is IInheritanceService inheritanceService))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			inheritanceService.AddInheritedComponents(base.Component, WebRootContainer);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (ce0791a62305956c47285db876d1aaadb)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cb094c6a1ac6cbc6924d5d6507cee5a98 = true;
			try
			{
				DesignContext.SuspendNotifications();
				DesignSurface designSurface = (DesignSurface)GetService(typeof(DesignSurface));
				if (designSurface == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					designSurface.Unloading -= OnDesignSurfaceUnloading;
					designSurface.Unloaded -= OnDesignSurfaceUnloaded;
				}
				IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					designerHost.Deactivated -= OnWebDesignerHostDeactivated;
					designerHost.Activated -= OnWebDesignerHostActivated;
				}
				ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
				if (selectionService != null)
				{
					selectionService.SelectionChanged -= OnWebSelectionChanged;
					selectionService.SelectionChanging -= OnWebSelectionChanging;
				}
				IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
				if (componentChangeService != null)
				{
					componentChangeService.ComponentRename -= OnWebComponentRenamed;
					componentChangeService.ComponentAdded -= OnWebComponentAdded;
					componentChangeService.ComponentChanged -= OnWebComponentChanged;
				}
				if (cdb48aa4e7dd6e2bf19b07a462fc57f04 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					componentChangeService = (IComponentChangeService)cdb48aa4e7dd6e2bf19b07a462fc57f04.GetService(typeof(IComponentChangeService));
					componentChangeService.ComponentRemoved -= OnWinComponentRemoved;
					componentChangeService.ComponentChanged -= OnWinComponentChanged;
					componentChangeService.ComponentAdded -= OnWinComponentAdded;
					((IDisposable)cdb48aa4e7dd6e2bf19b07a462fc57f04).Dispose();
					cdb48aa4e7dd6e2bf19b07a462fc57f04 = null;
				}
				if (c3fd699794d086d480adc6c928c5bf3cd != null)
				{
					c3fd699794d086d480adc6c928c5bf3cd.Dispose();
					c3fd699794d086d480adc6c928c5bf3cd = null;
				}
				if (ccf97179bcd82f4e7172a034748d7e517 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					ccf97179bcd82f4e7172a034748d7e517.Dispose();
					ccf97179bcd82f4e7172a034748d7e517 = null;
				}
				if (c16a84cf8d1c28229324d4ead19247937 != null)
				{
					c16a84cf8d1c28229324d4ead19247937.Dispose();
					c16a84cf8d1c28229324d4ead19247937 = null;
				}
				if (c636e79616d9f1e5e1bcdbe6de6d61e76 != null)
				{
					c636e79616d9f1e5e1bcdbe6de6d61e76.Dispose();
					c636e79616d9f1e5e1bcdbe6de6d61e76 = null;
				}
				if (c11bb41ea1daf1807b684b770cfa932c6 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					c11bb41ea1daf1807b684b770cfa932c6.Dispose();
					c11bb41ea1daf1807b684b770cfa932c6 = null;
				}
				if (cba51a85763227e8ccaa17b66eed14d8a != null)
				{
					cba51a85763227e8ccaa17b66eed14d8a.Dispose();
					cba51a85763227e8ccaa17b66eed14d8a = null;
				}
				DisposeDesignerToolboxInfo();
			}
			finally
			{
				cb094c6a1ac6cbc6924d5d6507cee5a98 = false;
				ce0791a62305956c47285db876d1aaadb = true;
			}
		}
		base.Dispose(disposing);
	}

	private void DisposeDesignerToolboxInfo()
	{
		if (!(GetService(typeof(IDesignerHost)) is IDesignerHost designerHost))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (!(designerHost.GetService(typeof(IServiceContainer)) is IServiceContainer serviceContainer))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		object service = serviceContainer.GetService(typeof(IToolboxService));
		if (service == null)
		{
			return;
		}
		Type typeFromHandle = typeof(ToolboxService);
		if (typeFromHandle != null)
		{
			FieldInfo field = typeFromHandle.GetField("_lastState", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			if (!(field != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			if (!(field.GetValue(service) is IDisposable disposable))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			disposable.Dispose();
			field.SetValue(service, null);
		}
	}

	public override void DoDefaultAction()
	{
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		ICollection selectedComponents = selectionService.GetSelectedComponents();
		IEventBindingService eventBindingService = (IEventBindingService)GetService(typeof(IEventBindingService));
		EventDescriptor eventDescriptor = null;
		DesignerTransaction designerTransaction = null;
		IComponent component = null;
		try
		{
			IEnumerator enumerator = selectedComponents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					object current = enumerator.Current;
					PropertyDescriptor propertyDescriptor = null;
					string text = null;
					bool flag = false;
					if (!(current is IComponent))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					EventDescriptor defaultEvent = TypeDescriptor.GetDefaultEvent(current);
					if (defaultEvent != null && selectionService != null)
					{
						propertyDescriptor = eventBindingService.GetEventProperty(defaultEvent);
					}
					if (propertyDescriptor == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (propertyDescriptor.IsReadOnly)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					try
					{
						if (designerTransaction != null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							designerTransaction = WebDesingerHost.CreateTransaction("Adding " + defaultEvent.Name + " event handler.");
						}
					}
					catch (CheckoutException ex)
					{
						if (ex != CheckoutException.Canceled)
						{
							throw ex;
						}
						return;
					}
					text = (string)propertyDescriptor.GetValue(current);
					if (text != null)
					{
						/*OpCode not supported: LdMemberToken*/;
						flag = true;
						IEnumerator enumerator2 = eventBindingService.GetCompatibleMethods(defaultEvent).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								string text2 = (string)enumerator2.Current;
								if (!(text == text2))
								{
									/*OpCode not supported: LdMemberToken*/;
									continue;
								}
								flag = false;
								break;
							}
						}
						finally
						{
							if (!(enumerator2 is IDisposable disposable))
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
						flag = true;
						text = eventBindingService.CreateUniqueMethodName((IComponent)current, defaultEvent);
					}
					if (!flag)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (propertyDescriptor == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						propertyDescriptor.SetValue(current, text);
					}
					component = (IComponent)current;
					eventDescriptor = defaultEvent;
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable2))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		finally
		{
			designerTransaction?.Commit();
		}
		if (component == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (eventDescriptor != null)
		{
			eventBindingService.ShowCode(component, eventDescriptor);
		}
	}

	protected override object GetService(Type serviceType)
	{
		if (!(serviceType == typeof(IServiceContainer)))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (!(serviceType == typeof(IMenuEditorService)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return base.GetService(serviceType);
			}
			return MenuEditorService;
		}
		return LocalServiceContainer;
	}

	private void SetWinInheritanceAttribute(IComponent objWinComponent)
	{
		if (!(GetService(typeof(IInheritanceService)) is IInheritanceService inheritanceService))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IComponent mappedComponent = GetMappedComponent(objWinComponent, blnWinComponent: true);
		if (mappedComponent == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IDesigner winRootDesigner = WinRootDesigner;
		if (winRootDesigner == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		FieldInfo field = winRootDesigner.GetType().BaseType.GetField("inheritanceService", BindingFlags.Instance | BindingFlags.NonPublic);
		if (field != null && field.GetValue(winRootDesigner) is InheritanceService inheritanceService2)
		{
			FieldInfo field2 = inheritanceService2.GetType().BaseType.GetField("inheritedComponents", BindingFlags.Instance | BindingFlags.NonPublic);
			if (!(field2 != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(field2.GetValue(inheritanceService2) is Hashtable hashtable))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (inheritanceService.GetInheritanceAttribute(mappedComponent) == InheritanceAttribute.Default)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				hashtable[objWinComponent] = inheritanceService.GetInheritanceAttribute(mappedComponent);
			}
		}
	}

	private void RefreshDesigner()
	{
		IEnumerator enumerator = WebRootContainer.Components.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				IComponent component = (IComponent)enumerator.Current;
				if (ContextServices.GetControllerByWebObject(component) != null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (component is IMainMenu || component is IContextMenu)
				{
					IClientObjectController clientObjectController = ClientFactory.CreateMenuController(Context, component);
					clientObjectController.Initialize();
					clientObjectController.Load();
					((IContextServices)Context).RegisterController(clientObjectController);
					((IClientDesignServices)this).RegisterWinComponent((IComponent)clientObjectController.TargetObject, component.Site.Name);
				}
				else
				{
					if (component is IMenu)
					{
						continue;
					}
					if (((IContextServices)Context).GetControllerByWebObject(component) != null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					IClientObjectController clientObjectController2 = ContextServices.CreateControllerByWebObject(component);
					if (clientObjectController2 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					clientObjectController2.Initialize();
					clientObjectController2.Load();
					((IContextServices)Context).RegisterController(clientObjectController2);
					if (clientObjectController2.TargetObject is IComponent)
					{
						((IClientDesignServices)this).RegisterWinComponent((IComponent)clientObjectController2.TargetObject, component.Site.Name);
					}
				}
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

	private void OnLoadComplete(object objSender, EventArgs objArgs)
	{
		((IDesignerHost)objSender).LoadComplete -= OnLoadComplete;
		ISelectionService obj = (ISelectionService)GetService(typeof(ISelectionService));
		obj.SelectionChanged += OnWebSelectionChanged;
		obj.SelectionChanging += OnWebSelectionChanging;
		IComponentChangeService obj2 = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		obj2.ComponentRename += OnWebComponentRenamed;
		obj2.ComponentAdded += OnWebComponentAdded;
		obj2.ComponentChanged += OnWebComponentChanged;
		IComponentChangeService obj3 = (IComponentChangeService)WinDesingerHost.GetService(typeof(IComponentChangeService));
		obj3.ComponentRemoved += OnWinComponentRemoved;
		obj3.ComponentChanged += OnWinComponentChanged;
		obj3.ComponentAdded += OnWinComponentAdded;
		LoadToolbox();
		c8853b50a23d6c5b83593cb35f510c893 = false;
		cfc81215a41c271ffc2faf61006d1b828 = false;
	}

	private void LoadApplicationConfiguration()
	{
		string configurationFilePath = ConfigurationFilePath;
		if (File.Exists(configurationFilePath))
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(configurationFilePath);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("WebGUI");
			if (elementsByTagName.Count == 1)
			{
				Config.GetInstance(elementsByTagName[0] as XmlElement, blnCacheConfig: true);
			}
		}
	}

	private void OnWebComponentAdded(object sender, ComponentEventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		ce9e8cfad68884fc52b80d7b7ea71658b = true;
		if (e.Component is IMainMenu menu)
		{
			if (!(base.Component is IForm form))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (form.Menu != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				form.Menu = menu;
			}
		}
	}

	private void OnWebComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (e.Member == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (IsNotificationSuspened)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (!(e.Component is IComponent))
		{
			/*OpCode not supported: LdMemberToken*/;
			IEnumerator enumerator = DesignServices.GetSelectedWinComponents().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					object current = enumerator.Current;
					IClientObjectController controllerByWinObject = ContextServices.GetControllerByWinObject(current);
					if (controllerByWinObject != null)
					{
						DesignContext.NotifyItemPropertyChanged(controllerByWinObject, new ObservableItemPropertyChangedArgs("Unknown"), blnWebEvent: true);
					}
				}
				return;
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
		IClientObjectController controllerByWebObject = ContextServices.GetControllerByWebObject(e.Component);
		if (controllerByWebObject == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			DesignContext.NotifyItemPropertyChanged(controllerByWebObject, new ObservableItemPropertyChangedArgs(e.Member.Name), blnWebEvent: true);
		}
	}

	private void OnWebComponentRenamed(object sender, ComponentRenameEventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IComponent mappedComponent = GetMappedComponent(e.Component, blnWinComponent: false);
		if (mappedComponent == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (mappedComponent.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ClientDesingerHost.RenameComponent(mappedComponent, e.NewName);
		}
	}

	private void OnWinComponentRemoved(object sender, ComponentEventArgs e)
	{
		if (IsNotificationSuspened)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IClientObjectController controllerByWinObject = ContextServices.GetControllerByWinObject(e.Component);
		if (controllerByWinObject == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (!(controllerByWinObject.SourceObject is IComponent component))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			WebRootContainer.Remove(component);
			component.Dispose();
		}
		controllerByWinObject.Terminate();
		ContextServices.UnregisterController(controllerByWinObject);
	}

	private void OnWinComponentAdded(object sender, ComponentEventArgs e)
	{
		if (IsNotificationSuspened)
		{
			return;
		}
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (ContextServices.GetControllerByWinObject(e.Component) == null)
		{
			IClientObjectController clientObjectController = ContextServices.CreateControllerByWinObject(e.Component);
			if (clientObjectController == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			ContextServices.RegisterController(clientObjectController);
			DesignServices.RegisterWebComponent((IComponent)clientObjectController.SourceObject, e.Component.Site.Name);
		}
	}

	private void OnWinComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		if (IsNotificationSuspened)
		{
			return;
		}
		IClientObjectController controllerByWinObject = ((IContextServices)Context).GetControllerByWinObject(e.Component);
		if (controllerByWinObject == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		string strProperty = "VWGNullProperty";
		if (e.Member != null)
		{
			strProperty = e.Member.Name;
		}
		DesignContext.NotifyItemPropertyChanged(controllerByWinObject, new ObservableItemPropertyChangedArgs(strProperty), blnWebEvent: false);
	}

	bool IToolboxUser.GetToolSupported(ToolboxItem objTool)
	{
		try
		{
			Type type = GetTypeByName(objTool.TypeName);
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				while (type != typeof(object))
				{
					/*OpCode not supported: LdMemberToken*/;
					string text = type.ToString();
					if (text.StartsWith("System.Windows"))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!text.StartsWith("System.IO") && !text.StartsWith("System.Drawing"))
					{
						if (text.StartsWith("CrystalDecisions"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (text.StartsWith("Microsoft"))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!text.StartsWith("System.Web") && !text.StartsWith("System.Diagnostics"))
						{
							/*OpCode not supported: LdMemberToken*/;
							type = type.BaseType;
							continue;
						}
					}
					return false;
				}
			}
			return true;
		}
		catch
		{
			return true;
		}
	}

	void IToolboxUser.ToolPicked(ToolboxItem tool)
	{
	}

	public static Type GetTypeByName(string strName)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			/*OpCode not supported: LdMemberToken*/;
			Type type = assemblies[i].GetType(strName);
			if (type != null)
			{
				return type;
			}
		}
		return null;
	}

	public IDesigner GetParentDesinger()
	{
		return this;
	}

	public object GetParentService(Type objType)
	{
		if (!(objType == typeof(IMenuEditorService)))
		{
			/*OpCode not supported: LdMemberToken*/;
			return GetService(objType);
		}
		return MenuEditorService;
	}

	void IClientDesignServices.FireWinComponentChanged(object objSource, string strPropertyName, object objOldValue, object objNewValue)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (c8853b50a23d6c5b83593cb35f510c893)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IComponentChangeService componentChangeService = (IComponentChangeService)WinDesingerHost.GetService(typeof(IComponentChangeService));
		if (componentChangeService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objSource).Find(strPropertyName, ignoreCase: false);
		if (propertyDescriptor == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			componentChangeService.OnComponentChanged(objSource, propertyDescriptor, objOldValue, objNewValue);
		}
	}

	void IClientDesignServices.FireWinComponentChanging(object objSource, string strPropertyName)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (c8853b50a23d6c5b83593cb35f510c893)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IComponentChangeService componentChangeService = (IComponentChangeService)WinDesingerHost.GetService(typeof(IComponentChangeService));
		if (componentChangeService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objSource).Find(strPropertyName, ignoreCase: false);
		if (propertyDescriptor != null)
		{
			componentChangeService.OnComponentChanging(objSource, propertyDescriptor);
		}
	}

	void IClientDesignServices.FireWebComponentChanged(object objSource, string strPropertyName, object objOldValue, object objNewValue)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (c8853b50a23d6c5b83593cb35f510c893)
			{
				return;
			}
			IComponentChangeService componentChangeService = (IComponentChangeService)WebDesingerHost.GetService(typeof(IComponentChangeService));
			if (componentChangeService != null)
			{
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objSource).Find(strPropertyName, ignoreCase: false);
				if (propertyDescriptor == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					componentChangeService.OnComponentChanged(objSource, propertyDescriptor, objOldValue, objNewValue);
				}
			}
		}
	}

	void IClientDesignServices.FireWebComponentChanging(object objSource, string strPropertyName)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (c0aebe43930109af962ddd3b49cffd824)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (c8853b50a23d6c5b83593cb35f510c893)
			{
				return;
			}
			IComponentChangeService componentChangeService = (IComponentChangeService)WebDesingerHost.GetService(typeof(IComponentChangeService));
			if (componentChangeService == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objSource).Find(strPropertyName, ignoreCase: false);
			if (propertyDescriptor == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				componentChangeService.OnComponentChanging(objSource, propertyDescriptor);
			}
		}
	}

	void IClientDesignServices.RegisterWinComponent(IComponent objWinComponent)
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			if (!ShouldRegisterWinComponent(objWinComponent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			SetWinInheritanceAttribute(objWinComponent);
			WinRootContainer.Add(objWinComponent);
		}
	}

	void IClientDesignServices.RegisterWinComponent(IComponent objWinComponent, string strName)
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			if (!ShouldRegisterWinComponent(objWinComponent))
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			SetWinInheritanceAttribute(objWinComponent);
			WinRootContainer.Add(objWinComponent, strName);
		}
	}

	void IClientDesignServices.RefreshDesigner()
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98 && ce9e8cfad68884fc52b80d7b7ea71658b)
		{
			RefreshDesigner();
			ce9e8cfad68884fc52b80d7b7ea71658b = false;
		}
	}

	void IClientDesignServices.UnregisterWebComponent(IComponent objWebComponent)
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			WebRootContainer.Remove(objWebComponent);
		}
	}

	void IClientDesignServices.UnregisterWinComponent(IComponent objWinComponent)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			WinRootContainer.Remove(objWinComponent);
		}
	}

	void IClientDesignServices.RegisterWebComponent(IComponent objWebComponent)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			WebRootContainer.Add(objWebComponent);
		}
	}

	void IClientDesignServices.RegisterWebComponent(IComponent objWebComponent, string strName)
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			WebRootContainer.Add(objWebComponent, strName);
		}
	}

	void IClientDesignServices.RegisterWebComponent(IComponent objContainerComponent, IComponent objWebComponent)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((INestedContainer)objContainerComponent.Site.GetService(typeof(INestedContainer))).Add(objWebComponent);
		}
	}

	void IClientDesignServices.RegisterWebComponent(IComponent objContainerComponent, IComponent objWebComponent, string strName)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((INestedContainer)objContainerComponent.Site.GetService(typeof(INestedContainer))).Add(objWebComponent, strName);
		}
	}

	bool IClientDesignServices.IsRegisteredWinComponent(IComponent objWinComponent)
	{
		return objWinComponent.Site != null;
	}

	bool IClientDesignServices.IsRegisteredWebComponent(IComponent objWebComponent)
	{
		return objWebComponent.Site != null;
	}

	void IClientDesignServices.SelectWebComponent(IComponent objWebComponent)
	{
		if (!cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
			if (selectionService != null)
			{
				ArrayList arrayList = new ArrayList();
				arrayList.Add(objWebComponent);
				selectionService.SetSelectedComponents(arrayList);
			}
		}
	}

	ICollection IClientDesignServices.GetSelectedWebComponents()
	{
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return selectionService.GetSelectedComponents();
	}

	ICollection IClientDesignServices.GetSelectedWinComponents()
	{
		ISelectionService selectionService = (ISelectionService)WinDesingerHost.GetService(typeof(ISelectionService));
		if (selectionService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return selectionService.GetSelectedComponents();
	}

	private bool ShouldRegisterWinComponent(IComponent objWinComponent)
	{
		bool result = false;
		IComponent mappedComponent = GetMappedComponent(objWinComponent, blnWinComponent: true);
		if (mappedComponent == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (!(GetService(typeof(IInheritanceService)) is IInheritanceService inheritanceService))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (inheritanceService.GetInheritanceAttribute(mappedComponent) == InheritanceAttribute.InheritedReadOnly)
				{
					result = true;
					goto IL_006b;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			result = mappedComponent.Site != null;
		}
		goto IL_006b;
		IL_006b:
		return result;
	}

	Config IClientDesignServices.GetConfiguration()
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml("<Config/>");
		return Config.GetInstance(xmlDocument.DocumentElement);
	}

	private Hashtable CreateNamedDirectories()
	{
		Hashtable hashtable = new Hashtable();
		if (!File.Exists(ConfigurationFilePath))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			try
			{
				RestoreNamedDirectories(ConfigurationFilePath, hashtable);
			}
			catch
			{
				hashtable = null;
			}
		}
		return hashtable;
	}

	private string GetConfigurationFilePath()
	{
		string result = null;
		Assembly assembly = Assembly.Load("EnvDTE");
		if (!(assembly != null))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			Type type = assembly.GetType("EnvDTE.DTE");
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object service = GetService(type);
				if (service == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (GetCOMPropertyValue(service, "ActiveSolutionProjects") is Array array)
				{
					if (array.Length <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						object value = array.GetValue(0);
						if (value != null)
						{
							string text = GetCOMPropertyValue(value, "FullName") as string;
							if (CommonUtils.IsNullOrEmpty(text))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								string directoryName = Path.GetDirectoryName(text);
								string text2 = Path.Combine(directoryName, "Web.config");
								if (!File.Exists(text2))
								{
									/*OpCode not supported: LdMemberToken*/;
									string configFilePathProperty = GetConfigFilePathProperty(text);
									if (!string.IsNullOrEmpty(configFilePathProperty))
									{
										result = Path.Combine(directoryName, configFilePathProperty);
										result = Path.Combine(result, "Web.config");
									}
								}
								else
								{
									result = text2;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	private string GetConfigFilePathProperty(string strProjectPath)
	{
		return ProjectHelper.GetProjectExtensionProperty(strProjectPath, "ConfigFilePath");
	}

	private void RestoreNamedDirectories(string strConfigFile, Hashtable objNamedDirectories)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(strConfigFile);
		foreach (XmlNode item in xmlDocument.SelectNodes("//WebGUI/Directories/Directory"))
		{
			if (!(item is XmlElement xmlElement))
			{
				/*OpCode not supported: LdMemberToken*/;
				continue;
			}
			string attribute = xmlElement.GetAttribute("Code");
			string text = xmlElement.GetAttribute("Path");
			if (CommonUtils.IsNullOrEmpty(attribute, text))
			{
				/*OpCode not supported: LdMemberToken*/;
				continue;
			}
			if (Path.IsPathRooted(text))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = Path.Combine(Path.GetDirectoryName(strConfigFile), text);
			}
			objNamedDirectories[attribute] = text;
		}
	}

	private object GetCOMPropertyValue(object objInstance, string strProperty)
	{
		if (objInstance == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return objInstance.GetType().InvokeMember(strProperty, BindingFlags.GetProperty, null, objInstance, new object[0]);
	}

	private object GetCOMMethodValue(object objInstance, string strMethodName, params object[] arrParams)
	{
		if (objInstance == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return objInstance.GetType().InvokeMember(strMethodName, BindingFlags.InvokeMethod, null, objInstance, arrParams);
	}

	string IClientDesignServices.GetNamedDirecotry(string strDirectoryName)
	{
		string text = null;
		if (c7cd7e2d687b1696579dd1d1847c9e0c2 == null)
		{
			c7cd7e2d687b1696579dd1d1847c9e0c2 = CreateNamedDirectories();
		}
		if (c7cd7e2d687b1696579dd1d1847c9e0c2 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			text = c7cd7e2d687b1696579dd1d1847c9e0c2[strDirectoryName] as string;
		}
		if (text != null)
		{
			return text;
		}
		return string.Empty;
	}

	string IClientDesignServices.GetConfigurationPath(string strConfig)
	{
		return ConfigurationFilePath;
	}

	SizeF IClientDesignServices.GetFormScaleFactor(string strBrowserId)
	{
		if (WebDesingerHost == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			string typeAssemblyQualifiedName = GetTypeAssemblyQualifiedName(WebDesingerHost.RootComponentClassName, throwOnError: false);
			if (typeAssemblyQualifiedName != null)
			{
				if (c90ba050e5d91f811359d937118b0db57.ContainsKey(typeAssemblyQualifiedName))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					SizeF value = new SizeF(1f, 1f);
					if (strBrowserId == null)
					{
						strBrowserId = ((IClientDesignServices)this).GetBrowserId((string)null);
					}
					if (strBrowserId == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						IDesignTimeDeviceRepository designTimeDeviceRepository = ((IClientDesignServices)this).DesignTimeDeviceRepository;
						if (designTimeDeviceRepository == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							value = designTimeDeviceRepository.GetDeviceScaleFactor(this, strBrowserId);
						}
					}
					c90ba050e5d91f811359d937118b0db57.Add(typeAssemblyQualifiedName, value);
				}
				return c90ba050e5d91f811359d937118b0db57[typeAssemblyQualifiedName];
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		return new SizeF(1f, 1f);
	}

	string IClientDesignServices.GetBrowserId(string strFormStrongTypeName)
	{
		string result = null;
		if (string.IsNullOrEmpty(ConfigurationFilePath))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(ConfigurationFilePath);
			string typeFullName = GetTypeFullName(WebDesingerHost.RootComponentClassName);
			if (typeFullName == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = MappedFormsLoader.GetFormBrowserId(xmlDocument, typeFullName);
			}
		}
		return result;
	}

	internal string GetTypeAssemblyQualifiedName(string name, bool throwOnError)
	{
		string result = null;
		ITypeResolutionService typeResolutionService = (ITypeResolutionService)GetService(typeof(ITypeResolutionService));
		if (typeResolutionService != null)
		{
			Type type = typeResolutionService.GetType(name, throwOnError);
			if (!(type != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = type.AssemblyQualifiedName;
			}
		}
		return result;
	}

	private string GetTypeFullName(string strTypeName)
	{
		string text = null;
		ITypeResolutionService typeResolutionService = (ITypeResolutionService)GetService(typeof(ITypeResolutionService));
		if (typeResolutionService != null)
		{
			Type type = typeResolutionService.GetType(strTypeName, throwOnError: false);
			if (type != null)
			{
				text = $"{type.FullName}, {type.Assembly.GetName().Name}";
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			string activeProjectAssemblyName = GetActiveProjectAssemblyName();
			if (!string.IsNullOrEmpty(activeProjectAssemblyName))
			{
				text = $"{strTypeName}, {activeProjectAssemblyName}";
			}
		}
		return text;
	}

	private string GetActiveProjectAssemblyName()
	{
		Assembly assembly = Assembly.Load("EnvDTE");
		if (!(assembly != null))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			Type type = assembly.GetType("EnvDTE.DTE");
			if (type != null)
			{
				object service = GetService(type);
				if (service == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(GetCOMPropertyValue(service, "ActiveSolutionProjects") is Array array))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (array.Length <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object value = array.GetValue(0);
					if (value == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						object cOMPropertyValue = GetCOMPropertyValue(value, "Properties");
						if (cOMPropertyValue != null)
						{
							object cOMMethodValue = GetCOMMethodValue(cOMPropertyValue, "Item", "AssemblyName");
							if (cOMMethodValue != null)
							{
								return GetCOMPropertyValue(cOMMethodValue, "Value") as string;
							}
						}
					}
				}
			}
		}
		return null;
	}

	private string GetDefaultDesignDeviceRepositoryString()
	{
		_ = string.Empty;
		return "Gizmox.WebGUI.Common.DeviceRepository.BrowserRepository, Gizmox.WebGUI.Common, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=263fa4ef694acff6";
	}

	ICollection IDesignerSerializationService.Deserialize(object serializationData)
	{
		if (DesignerSerializationService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		ICollection collection = DesignerSerializationService.Deserialize(serializationData);
		ArrayList arrayList = new ArrayList();
		Point point = new Point(0, 0);
		Point point2 = new Point(0, 0);
		bool flag = true;
		IEnumerator enumerator = collection.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				object current = enumerator.Current;
				if (!(current is IControl control))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (control.Parent != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				StripEvents(control);
				if (!(control.Left < point.X || flag))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					point.X = control.Left;
				}
				if (!(control.Top < point.Y || flag))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					point.Y = control.Top;
				}
				if (!(control.Left + control.Width > point2.X || flag))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					point2.X = control.Left + control.Width;
				}
				if (control.Top + control.Height > point2.Y || flag)
				{
					point2.Y = control.Top + control.Height;
				}
				UpdateControlName(control);
				IClientObjectController clientObjectController = ClientFactory.CreateController(Context, current);
				((IContextServices)Context).RegisterController(clientObjectController);
				((IClientDesignServices)this).RegisterWinComponent((IComponent)clientObjectController.TargetObject);
				clientObjectController.Initialize();
				clientObjectController.Load();
				arrayList.Add(clientObjectController.TargetObject);
				flag = false;
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
		IControl control2 = null;
		Control control3 = null;
		int num = 0;
		int num2 = 0;
		ISelectionService selectionService = (ISelectionService)GetService(typeof(ISelectionService));
		if (selectionService != null)
		{
			control2 = selectionService.PrimarySelection as IControl;
			if (control2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj;
				if (control2 != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					obj = GetMappedComponent(control2, blnWinComponent: false);
				}
				else
				{
					obj = null;
				}
				control3 = obj as Control;
				int num3 = point2.X - point.X;
				int num4 = point2.Y - point.Y;
				num = control3.Width / 2 - num3 / 2 - point.X;
				num2 = control3.Height / 2 - num4 / 2 - point.Y;
			}
		}
		if (control2 != null)
		{
			bool flag2 = false;
			{
				IEnumerator enumerator2 = collection.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(enumerator2.Current is IControl control4))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						if (control4.Parent != null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						control4.Left += num;
						control4.Top += num2;
						control2.Controls.Add(control4);
						control4.BringToFront();
						flag2 = true;
					}
				}
				finally
				{
					IDisposable disposable3 = enumerator2 as IDisposable;
					if (disposable3 != null)
					{
						disposable3.Dispose();
					}
				}
			}
			if (flag2 && GetService(typeof(IComponentChangeService)) is IComponentChangeService componentChangeService)
			{
				componentChangeService.OnComponentChanged(control2, null, null, null);
			}
		}
		if (control3 != null)
		{
			enumerator = arrayList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(enumerator.Current is Control control5))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (control5.Parent != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (control3 != null)
					{
						control5.Left += num;
						control5.Top += num2;
						control3.Controls.Add(control5);
						control5.BringToFront();
					}
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable2))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		return null;
	}

	private static void UpdateControlName(IControl objWebControl)
	{
		if (objWebControl == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (!(objWebControl is IComponent component))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (component.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(objWebControl)["Name"];
			if (propertyDescriptor != null)
			{
				string text = (string)propertyDescriptor.GetValue(objWebControl);
				PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(objWebControl)["Text"];
				if (propertyDescriptor2 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string text2 = (string)propertyDescriptor2.GetValue(objWebControl);
					if (!(text == text2))
					{
						/*OpCode not supported: LdMemberToken*/;
						propertyDescriptor.SetValue(objWebControl, component.Site.Name);
					}
					else
					{
						propertyDescriptor.SetValue(objWebControl, component.Site.Name);
						propertyDescriptor2.SetValue(objWebControl, component.Site.Name);
					}
				}
			}
		}
		IEnumerator enumerator = objWebControl.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				UpdateControlName((IControl)enumerator.Current);
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

	object IDesignerSerializationService.Serialize(ICollection objects)
	{
		if (DesignerSerializationService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		ArrayList arrayList = new ArrayList();
		int i = 0;
		IEnumerator enumerator = objects.GetEnumerator();
		try
		{
			for (; enumerator.MoveNext(); i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				object current = enumerator.Current;
				if (i != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!(current is IComponent))
					{
						arrayList.Add(current);
						continue;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				AddAssociatedComponents(GetMappedComponent(current, blnWinComponent: true), arrayList);
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
		return DesignerSerializationService.Serialize(arrayList);
	}

	private void AddAssociatedComponents(IComponent objWebComponent, ArrayList objWebComponents)
	{
		if (objWebComponent == null)
		{
			return;
		}
		if (!(WebDesingerHost.GetDesigner(objWebComponent) is ComponentDesigner { AssociatedComponents: var associatedComponents }))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (associatedComponents == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			IEnumerator enumerator = associatedComponents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (current is IComponent)
					{
						AddAssociatedComponents(current as IComponent, objWebComponents);
					}
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
		if (objWebComponents.Contains(objWebComponent))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			objWebComponents.Add(objWebComponent);
		}
	}

	private void OnWebSelectionChanging(object sender, EventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		EventHandler eventHandler = (EventHandler)cba51a85763227e8ccaa17b66eed14d8a[caa3ef1e9e3625a197fd9165076a1d87f];
		if (eventHandler == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			eventHandler(this, e);
		}
	}

	private void OnWebSelectionChanged(object sender, EventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		EventHandler eventHandler = (EventHandler)cba51a85763227e8ccaa17b66eed14d8a[c3e8235eb72072b645dfcb2add4885552];
		if (eventHandler == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			eventHandler(this, e);
		}
	}

	private void OnWebDesignerHostDeactivated(object sender, EventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (cdb48aa4e7dd6e2bf19b07a462fc57f04 != null)
		{
			((ccc53407af8f11baecaaada159429c8fa)cdb48aa4e7dd6e2bf19b07a462fc57f04).Deactivate();
		}
	}

	private void OnWebDesignerHostActivated(object sender, EventArgs e)
	{
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (cdb48aa4e7dd6e2bf19b07a462fc57f04 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((ccc53407af8f11baecaaada159429c8fa)cdb48aa4e7dd6e2bf19b07a462fc57f04).Activate();
		}
	}

	bool ISelectionService.GetComponentSelected(object objWinComponent)
	{
		if (WebSelectionService != null)
		{
			IComponent mappedComponent = GetMappedComponent(objWinComponent, blnWinComponent: true);
			if (mappedComponent != null)
			{
				return WebSelectionService.GetComponentSelected(mappedComponent);
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		return false;
	}

	ICollection ISelectionService.GetSelectedComponents()
	{
		if (WebSelectionService == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return new object[0];
		}
		return GetMappedComponents(WebSelectionService.GetSelectedComponents(), blnWinComponents: false);
	}

	void ISelectionService.SetSelectedComponents(ICollection objWinComponents, SelectionTypes enmSelectionType)
	{
		if (c28c3ea5a74b9788786d9d9acf5a8b809)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (cb094c6a1ac6cbc6924d5d6507cee5a98)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		cbb839226bc7d343f6b8a05a0f2b85d37 = true;
		try
		{
			if (WebSelectionService != null)
			{
				WebSelectionService.SetSelectedComponents(GetMappedComponents(GetSelectableComponent(objWinComponents), blnWinComponents: true), enmSelectionType);
			}
		}
		finally
		{
			cbb839226bc7d343f6b8a05a0f2b85d37 = false;
		}
	}

	void ISelectionService.SetSelectedComponents(ICollection objWinComponents)
	{
		if (c28c3ea5a74b9788786d9d9acf5a8b809)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (cb094c6a1ac6cbc6924d5d6507cee5a98)
			{
				return;
			}
			cbb839226bc7d343f6b8a05a0f2b85d37 = true;
			try
			{
				if (WebSelectionService == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					WebSelectionService.SetSelectedComponents(GetMappedComponents(GetSelectableComponent(objWinComponents), blnWinComponents: true));
				}
			}
			finally
			{
				cbb839226bc7d343f6b8a05a0f2b85d37 = false;
			}
		}
	}

	private ToolboxItem GetToolboxItem(Type objType)
	{
		IEnumerator enumerator = TypeDescriptor.GetAttributes(objType).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!((Attribute)enumerator.Current is ToolboxItemAttribute toolboxItemAttribute))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				if (!(toolboxItemAttribute.ToolboxItemType != null))
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				try
				{
					return Activator.CreateInstance(toolboxItemAttribute.ToolboxItemType, objType) as ToolboxItem;
				}
				catch (Exception)
				{
					return null;
				}
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
		return null;
	}

	private void LoadToolbox()
	{
		try
		{
			if (ce70439f44c1f861a343e2fed60562d6e)
			{
				return;
			}
			ClearToolboxCategory("Visual WebGUI Controls");
			string strCategory = "Visual WebGUI Controls";
			Hashtable mobjItemsCache = new Hashtable();
			Type[] formToolboxItemTypes = CommonUtils.GetFormToolboxItemTypes();
			for (int i = 0; i < formToolboxItemTypes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type objType = formToolboxItemTypes[i];
				try
				{
					ToolboxItem toolboxItem = GetToolboxItem(objType);
					AddToolboxItem(mobjItemsCache, toolboxItem, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem, objType);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetOfficeToolboxItemTypes();
			foreach (Type objType2 in formToolboxItemTypes)
			{
				try
				{
					ToolboxItem toolboxItem2 = GetToolboxItem(objType2);
					AddToolboxItem(mobjItemsCache, toolboxItem2, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem2, objType2);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetExtendedToolboxItemTypes();
			foreach (Type objType3 in formToolboxItemTypes)
			{
				try
				{
					ToolboxItem toolboxItem3 = GetToolboxItem(objType3);
					AddToolboxItem(mobjItemsCache, toolboxItem3, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem3, objType3);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetProfessionalToolboxItemTypes();
			foreach (Type objType4 in formToolboxItemTypes)
			{
				try
				{
					ToolboxItem toolboxItem4 = GetToolboxItem(objType4);
					AddToolboxItem(mobjItemsCache, toolboxItem4, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem4, objType4);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetChartsToolboxItemTypes();
			for (int i = 0; i < formToolboxItemTypes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type objType5 = formToolboxItemTypes[i];
				try
				{
					ToolboxItem toolboxItem5 = GetToolboxItem(objType5);
					AddToolboxItem(mobjItemsCache, toolboxItem5, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem5, objType5);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetReportingToolboxItemTypes();
			for (int i = 0; i < formToolboxItemTypes.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				Type objType6 = formToolboxItemTypes[i];
				try
				{
					ToolboxItem toolboxItem6 = GetToolboxItem(objType6);
					AddToolboxItem(mobjItemsCache, toolboxItem6, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem6, objType6);
				}
				catch (Exception)
				{
				}
			}
			formToolboxItemTypes = CommonUtils.GetCommonToolboxItemTypes();
			foreach (Type objType7 in formToolboxItemTypes)
			{
				try
				{
					ToolboxItem toolboxItem7 = GetToolboxItem(objType7);
					AddToolboxItem(mobjItemsCache, toolboxItem7, strCategory);
					AddToolboxItem(mobjItemsCache, toolboxItem7, objType7);
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		finally
		{
			ce70439f44c1f861a343e2fed60562d6e = true;
		}
	}

	private void ClearToolboxCategory(string strCategory)
	{
		ToolboxItemCollection toolboxItems = ToolboxService.GetToolboxItems(strCategory);
		if (toolboxItems.Count <= 0)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		IEnumerator enumerator = new ArrayList(toolboxItems).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				ToolboxItem toolboxItem = (ToolboxItem)enumerator.Current;
				ToolboxService.RemoveToolboxItem(toolboxItem, strCategory);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void AddToolboxItem(Hashtable mobjItemsCache, ToolboxItem objToolboxItem, Type objType)
	{
		if (objToolboxItem == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		object[] customAttributes = objType.GetCustomAttributes(typeof(ToolboxItemCategoryAttribute), inherit: true);
		if (customAttributes.Length == 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!(customAttributes[0] is ToolboxItemCategoryAttribute toolboxItemCategoryAttribute))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			AddToolboxItem(mobjItemsCache, objToolboxItem, toolboxItemCategoryAttribute.Category);
		}
	}

	private void AddToolboxItem(Hashtable mobjItemsCache, ToolboxItem objToolboxItem, string strCategory)
	{
		if (objToolboxItem == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		ToolboxItemCollection toolboxItemCollection = mobjItemsCache[strCategory] as ToolboxItemCollection;
		if (toolboxItemCollection != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			toolboxItemCollection = (ToolboxItemCollection)(mobjItemsCache[strCategory] = ToolboxService.GetToolboxItems(strCategory));
		}
		if (toolboxItemCollection == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (toolboxItemCollection.Contains(objToolboxItem))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		ToolboxService.AddToolboxItem(objToolboxItem, strCategory);
	}

	internal IComponent GetMappedComponent(object objComponent, bool blnWinComponent)
	{
		if (objComponent == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		IClientObjectController clientObjectController = null;
		if (blnWinComponent)
		{
			clientObjectController = ((IContextServices)Context).GetControllerByWinObject(objComponent);
			if (clientObjectController != null)
			{
				return clientObjectController.SourceObject as IComponent;
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			clientObjectController = ((IContextServices)Context).GetControllerByWebObject(objComponent);
			if (clientObjectController != null)
			{
				return clientObjectController.TargetObject as IComponent;
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		return null;
	}

	internal List<object> GetMappedComponents(ICollection objComponents, bool blnWinComponents)
	{
		if (objComponents != null)
		{
			List<object> list = new List<object>();
			IEnumerator enumerator = objComponents.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					object mappedComponent = GetMappedComponent(current, blnWinComponents);
					if (mappedComponent == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						list.Add(mappedComponent);
					}
				}
				return list;
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
		return null;
	}

	private object OnCreateService(IServiceContainer container, Type serviceType)
	{
		if (!(serviceType == typeof(ContainerFilterService)))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (!(serviceType == typeof(IMenuEditorService)))
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			ConstructorInfo[] constructors = Type.GetType("Microsoft.VisualStudio.Windows.Forms.MenuEditorService, Microsoft.VisualStudio.Windows.Forms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a").GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			return new c53dbbce1d9d6ee0f646e1b4b9136c85a(this, (IMenuEditorService)constructors[0].Invoke(new object[1] { WinDesingerHost }));
		}
		return new c7a433c9901f38077a9d995a14590b833(this);
	}
}
