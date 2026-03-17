using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Design.Host;
using Gizmox.WebGUI.Common.Interfaces;

namespace A;

[ProvideProperty("Name", typeof(IComponent))]
internal class ccc53407af8f11baecaaada159429c8fa : ca8ff5d161d38d5b5f53f0832d3763eee, IComponentChangeService, IDesignerHost, IEventBindingService, IExtenderListService, IExtenderProviderService, IServiceContainer, ITypeDescriptorFilterService, IContainer, IExtenderProvider, IDisposable, IServiceProvider
{
	internal class cda1369eed9e89805abb85f93c0ed98aa : NestedContainer
	{
		private ccc53407af8f11baecaaada159429c8fa c756caef060ee57f414b3ff387ee08c71;

		public cda1369eed9e89805abb85f93c0ed98aa(ccc53407af8f11baecaaada159429c8fa objClientHost, IComponent objOwner)
			: base(objOwner)
		{
			c756caef060ee57f414b3ff387ee08c71 = objClientHost;
		}

		protected override object GetService(Type service)
		{
			return c756caef060ee57f414b3ff387ee08c71.GetService(service);
		}

		public override void Add(IComponent component)
		{
			base.Add(component);
			CreateDesinger(component);
		}

		private void CreateDesinger(IComponent component)
		{
			IDesigner designer = c756caef060ee57f414b3ff387ee08c71.CreateDesigner(component);
			try
			{
				designer.Initialize(component);
			}
			catch
			{
				c756caef060ee57f414b3ff387ee08c71.RemoveDesigner(component);
				Remove(component);
				throw;
			}
		}

		public override void Add(IComponent component, string name)
		{
			base.Add(component, name);
			CreateDesinger(component);
		}

		protected override ISite CreateSite(IComponent component, string name)
		{
			return base.CreateSite(component, name);
		}

		public override void Remove(IComponent component)
		{
			base.Remove(component);
			c756caef060ee57f414b3ff387ee08c71.RemoveDesigner(component);
		}

		private string GetFullName(string strName)
		{
			return $"{OwnerName}.{strName}";
		}
	}

	private Stack cd4a7b8da83b25420eb5d89b4a792a2f4;

	private IServiceContainer cef22b3a165097455787ecc938bfb65f5;

	private Hashtable c85fef5f5b9a75a973bb13e3d2571f38c;

	private Hashtable ccf829a3b1abcc206a61734b37875d808;

	private ArrayList ca792b2d8ade9c1327a4e5ebb5452a151;

	private IComponent cd21b4bf3e39a90eef04bdd2ee6ac57af;

	private IContext cc964016db8f72d2070814faf8db78325;

	private string c202dff5eb931f6a68d731f768c2b31a3;

	private c0ea366c6e22bc6f4872ab3d07ffe081e cb7e511218d045d8cc80e2ee0266f21ce;

	[CompilerGenerated]
	private EventHandler cddefd9b0cb3cdc68a7caf82ad8073df1;

	[CompilerGenerated]
	private EventHandler c811828a55f805d444ebde872c6871bcf;

	private EventHandlerList cba51a85763227e8ccaa17b66eed14d8a = new EventHandlerList();

	private static object c9bb875674008a55b24b72c57582217ca = new object();

	[CompilerGenerated]
	private DesignerTransactionCloseEventHandler c257732f4206ee56635f17e478e7c80cc;

	[CompilerGenerated]
	private DesignerTransactionCloseEventHandler ce291af70f359c015d2a6679b98f6b5b6;

	[CompilerGenerated]
	private EventHandler ce838511233967195f60b64b78ca788f3;

	[CompilerGenerated]
	private EventHandler c0ce604cb2f3805d0180a3024d687b0bd;

	[CompilerGenerated]
	private ComponentEventHandler c35a8904af2ae3e685b51209fec5fcadb;

	[CompilerGenerated]
	private ComponentEventHandler c7a12a1187912d468c8da6d38e1b1ec65;

	[CompilerGenerated]
	private ComponentChangedEventHandler c5bfdc1503bac80aacab20e841f0b2f3a;

	[CompilerGenerated]
	private ComponentChangingEventHandler c5545c10765c313c2ddf324114bbc009a;

	[CompilerGenerated]
	private ComponentEventHandler c0f9592842b674e0bbadc8bd856cdac9c;

	[CompilerGenerated]
	private ComponentEventHandler cc5ca13948b895e09b330cd6ae0ca0e9d;

	[CompilerGenerated]
	private ComponentRenameEventHandler c397750f13657efc00e5bf77865823de9;

	private bool c4d8bb9aaa7cdeeffc13c3e2f6947d798;

	private string c51dc97bb0b8b978bbea04bd848a839f6 = "DisposeLock";

	private bool c8f722c2f01c4b2ccc57832c47697501b;

	private c0ea366c6e22bc6f4872ab3d07ffe081e ParentDesigner
	{
		get
		{
			if (cb7e511218d045d8cc80e2ee0266f21ce != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cb7e511218d045d8cc80e2ee0266f21ce = (c0ea366c6e22bc6f4872ab3d07ffe081e)cef22b3a165097455787ecc938bfb65f5.GetService(typeof(c0ea366c6e22bc6f4872ab3d07ffe081e));
			}
			return cb7e511218d045d8cc80e2ee0266f21ce;
		}
	}

	public IContainer Container => this;

	public bool InTransaction => cd4a7b8da83b25420eb5d89b4a792a2f4.Count > 0;

	public bool Loading => false;

	public IComponent RootComponent => cd21b4bf3e39a90eef04bdd2ee6ac57af;

	public IContext Context => cc964016db8f72d2070814faf8db78325;

	public IClinetDesignContext DesignContext => Context as IClinetDesignContext;

	public string RootComponentClassName => cd21b4bf3e39a90eef04bdd2ee6ac57af.GetType().Name;

	public string TransactionDescription
	{
		get
		{
			if (!InTransaction)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return ((DesignerTransaction)cd4a7b8da83b25420eb5d89b4a792a2f4.Peek()).Description;
		}
	}

	public ComponentCollection Components
	{
		get
		{
			IComponent[] components = new IComponent[0];
			if (c85fef5f5b9a75a973bb13e3d2571f38c.Count != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				components = new IComponent[c85fef5f5b9a75a973bb13e3d2571f38c.Count];
				c85fef5f5b9a75a973bb13e3d2571f38c.Values.CopyTo(components, 0);
				return new ComponentCollection(components);
			}
			return new ComponentCollection(components);
		}
	}

	public event EventHandler Activated
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = cddefd9b0cb3cdc68a7caf82ad8073df1;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref cddefd9b0cb3cdc68a7caf82ad8073df1, value2, eventHandler2);
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
			EventHandler eventHandler = cddefd9b0cb3cdc68a7caf82ad8073df1;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref cddefd9b0cb3cdc68a7caf82ad8073df1, value2, eventHandler2);
				if ((object)eventHandler == eventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event EventHandler Deactivated
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = c811828a55f805d444ebde872c6871bcf;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref c811828a55f805d444ebde872c6871bcf, value2, eventHandler2);
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
			EventHandler eventHandler = c811828a55f805d444ebde872c6871bcf;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref c811828a55f805d444ebde872c6871bcf, value2, eventHandler2);
				if ((object)eventHandler == eventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event EventHandler LoadComplete
	{
		add
		{
			cba51a85763227e8ccaa17b66eed14d8a.AddHandler(c9bb875674008a55b24b72c57582217ca, value);
		}
		remove
		{
			cba51a85763227e8ccaa17b66eed14d8a.RemoveHandler(c9bb875674008a55b24b72c57582217ca, value);
		}
	}

	public event DesignerTransactionCloseEventHandler TransactionClosed
	{
		[CompilerGenerated]
		add
		{
			DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler = c257732f4206ee56635f17e478e7c80cc;
			DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler2;
			do
			{
				designerTransactionCloseEventHandler2 = designerTransactionCloseEventHandler;
				DesignerTransactionCloseEventHandler value2 = (DesignerTransactionCloseEventHandler)Delegate.Combine(designerTransactionCloseEventHandler2, value);
				designerTransactionCloseEventHandler = Interlocked.CompareExchange(ref c257732f4206ee56635f17e478e7c80cc, value2, designerTransactionCloseEventHandler2);
			}
			while ((object)designerTransactionCloseEventHandler != designerTransactionCloseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler = c257732f4206ee56635f17e478e7c80cc;
			while (true)
			{
				DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler2 = designerTransactionCloseEventHandler;
				DesignerTransactionCloseEventHandler value2 = (DesignerTransactionCloseEventHandler)Delegate.Remove(designerTransactionCloseEventHandler2, value);
				designerTransactionCloseEventHandler = Interlocked.CompareExchange(ref c257732f4206ee56635f17e478e7c80cc, value2, designerTransactionCloseEventHandler2);
				if ((object)designerTransactionCloseEventHandler == designerTransactionCloseEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event DesignerTransactionCloseEventHandler TransactionClosing
	{
		[CompilerGenerated]
		add
		{
			DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler = ce291af70f359c015d2a6679b98f6b5b6;
			while (true)
			{
				DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler2 = designerTransactionCloseEventHandler;
				DesignerTransactionCloseEventHandler value2 = (DesignerTransactionCloseEventHandler)Delegate.Combine(designerTransactionCloseEventHandler2, value);
				designerTransactionCloseEventHandler = Interlocked.CompareExchange(ref ce291af70f359c015d2a6679b98f6b5b6, value2, designerTransactionCloseEventHandler2);
				if ((object)designerTransactionCloseEventHandler == designerTransactionCloseEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler = ce291af70f359c015d2a6679b98f6b5b6;
			while (true)
			{
				DesignerTransactionCloseEventHandler designerTransactionCloseEventHandler2 = designerTransactionCloseEventHandler;
				DesignerTransactionCloseEventHandler value2 = (DesignerTransactionCloseEventHandler)Delegate.Remove(designerTransactionCloseEventHandler2, value);
				designerTransactionCloseEventHandler = Interlocked.CompareExchange(ref ce291af70f359c015d2a6679b98f6b5b6, value2, designerTransactionCloseEventHandler2);
				if ((object)designerTransactionCloseEventHandler == designerTransactionCloseEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event EventHandler TransactionOpened
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = ce838511233967195f60b64b78ca788f3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ce838511233967195f60b64b78ca788f3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = ce838511233967195f60b64b78ca788f3;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref ce838511233967195f60b64b78ca788f3, value2, eventHandler2);
				if ((object)eventHandler == eventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event EventHandler TransactionOpening
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = c0ce604cb2f3805d0180a3024d687b0bd;
			while (true)
			{
				EventHandler eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref c0ce604cb2f3805d0180a3024d687b0bd, value2, eventHandler2);
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
			EventHandler eventHandler = c0ce604cb2f3805d0180a3024d687b0bd;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref c0ce604cb2f3805d0180a3024d687b0bd, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event ComponentEventHandler ComponentAdded
	{
		[CompilerGenerated]
		add
		{
			ComponentEventHandler componentEventHandler = c35a8904af2ae3e685b51209fec5fcadb;
			ComponentEventHandler componentEventHandler2;
			do
			{
				componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Combine(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c35a8904af2ae3e685b51209fec5fcadb, value2, componentEventHandler2);
			}
			while ((object)componentEventHandler != componentEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ComponentEventHandler componentEventHandler = c35a8904af2ae3e685b51209fec5fcadb;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Remove(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c35a8904af2ae3e685b51209fec5fcadb, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentEventHandler ComponentAdding
	{
		[CompilerGenerated]
		add
		{
			ComponentEventHandler componentEventHandler = c7a12a1187912d468c8da6d38e1b1ec65;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Combine(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c7a12a1187912d468c8da6d38e1b1ec65, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			ComponentEventHandler componentEventHandler = c7a12a1187912d468c8da6d38e1b1ec65;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Remove(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c7a12a1187912d468c8da6d38e1b1ec65, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentChangedEventHandler ComponentChanged
	{
		[CompilerGenerated]
		add
		{
			ComponentChangedEventHandler componentChangedEventHandler = c5bfdc1503bac80aacab20e841f0b2f3a;
			while (true)
			{
				ComponentChangedEventHandler componentChangedEventHandler2 = componentChangedEventHandler;
				ComponentChangedEventHandler value2 = (ComponentChangedEventHandler)Delegate.Combine(componentChangedEventHandler2, value);
				componentChangedEventHandler = Interlocked.CompareExchange(ref c5bfdc1503bac80aacab20e841f0b2f3a, value2, componentChangedEventHandler2);
				if ((object)componentChangedEventHandler == componentChangedEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			ComponentChangedEventHandler componentChangedEventHandler = c5bfdc1503bac80aacab20e841f0b2f3a;
			while (true)
			{
				ComponentChangedEventHandler componentChangedEventHandler2 = componentChangedEventHandler;
				ComponentChangedEventHandler value2 = (ComponentChangedEventHandler)Delegate.Remove(componentChangedEventHandler2, value);
				componentChangedEventHandler = Interlocked.CompareExchange(ref c5bfdc1503bac80aacab20e841f0b2f3a, value2, componentChangedEventHandler2);
				if ((object)componentChangedEventHandler == componentChangedEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentChangingEventHandler ComponentChanging
	{
		[CompilerGenerated]
		add
		{
			ComponentChangingEventHandler componentChangingEventHandler = c5545c10765c313c2ddf324114bbc009a;
			while (true)
			{
				ComponentChangingEventHandler componentChangingEventHandler2 = componentChangingEventHandler;
				ComponentChangingEventHandler value2 = (ComponentChangingEventHandler)Delegate.Combine(componentChangingEventHandler2, value);
				componentChangingEventHandler = Interlocked.CompareExchange(ref c5545c10765c313c2ddf324114bbc009a, value2, componentChangingEventHandler2);
				if ((object)componentChangingEventHandler == componentChangingEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			ComponentChangingEventHandler componentChangingEventHandler = c5545c10765c313c2ddf324114bbc009a;
			while (true)
			{
				ComponentChangingEventHandler componentChangingEventHandler2 = componentChangingEventHandler;
				ComponentChangingEventHandler value2 = (ComponentChangingEventHandler)Delegate.Remove(componentChangingEventHandler2, value);
				componentChangingEventHandler = Interlocked.CompareExchange(ref c5545c10765c313c2ddf324114bbc009a, value2, componentChangingEventHandler2);
				if ((object)componentChangingEventHandler == componentChangingEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentEventHandler ComponentRemoved
	{
		[CompilerGenerated]
		add
		{
			ComponentEventHandler componentEventHandler = c0f9592842b674e0bbadc8bd856cdac9c;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Combine(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c0f9592842b674e0bbadc8bd856cdac9c, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			ComponentEventHandler componentEventHandler = c0f9592842b674e0bbadc8bd856cdac9c;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Remove(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref c0f9592842b674e0bbadc8bd856cdac9c, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentEventHandler ComponentRemoving
	{
		[CompilerGenerated]
		add
		{
			ComponentEventHandler componentEventHandler = cc5ca13948b895e09b330cd6ae0ca0e9d;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Combine(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref cc5ca13948b895e09b330cd6ae0ca0e9d, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		[CompilerGenerated]
		remove
		{
			ComponentEventHandler componentEventHandler = cc5ca13948b895e09b330cd6ae0ca0e9d;
			while (true)
			{
				ComponentEventHandler componentEventHandler2 = componentEventHandler;
				ComponentEventHandler value2 = (ComponentEventHandler)Delegate.Remove(componentEventHandler2, value);
				componentEventHandler = Interlocked.CompareExchange(ref cc5ca13948b895e09b330cd6ae0ca0e9d, value2, componentEventHandler2);
				if ((object)componentEventHandler == componentEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public event ComponentRenameEventHandler ComponentRename
	{
		[CompilerGenerated]
		add
		{
			ComponentRenameEventHandler componentRenameEventHandler = c397750f13657efc00e5bf77865823de9;
			ComponentRenameEventHandler componentRenameEventHandler2;
			do
			{
				componentRenameEventHandler2 = componentRenameEventHandler;
				ComponentRenameEventHandler value2 = (ComponentRenameEventHandler)Delegate.Combine(componentRenameEventHandler2, value);
				componentRenameEventHandler = Interlocked.CompareExchange(ref c397750f13657efc00e5bf77865823de9, value2, componentRenameEventHandler2);
			}
			while ((object)componentRenameEventHandler != componentRenameEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ComponentRenameEventHandler componentRenameEventHandler = c397750f13657efc00e5bf77865823de9;
			while (true)
			{
				ComponentRenameEventHandler componentRenameEventHandler2 = componentRenameEventHandler;
				ComponentRenameEventHandler value2 = (ComponentRenameEventHandler)Delegate.Remove(componentRenameEventHandler2, value);
				componentRenameEventHandler = Interlocked.CompareExchange(ref c397750f13657efc00e5bf77865823de9, value2, componentRenameEventHandler2);
				if ((object)componentRenameEventHandler == componentRenameEventHandler2)
				{
					break;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
	}

	public ccc53407af8f11baecaaada159429c8fa(IServiceContainer parent, IContext objContext)
	{
		cef22b3a165097455787ecc938bfb65f5 = parent;
		cc964016db8f72d2070814faf8db78325 = objContext;
		c85fef5f5b9a75a973bb13e3d2571f38c = new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
		ccf829a3b1abcc206a61734b37875d808 = new Hashtable();
		cd4a7b8da83b25420eb5d89b4a792a2f4 = new Stack();
		parent.AddService(typeof(IDesignerHost), this);
		parent.AddService(typeof(IContainer), this);
		parent.AddService(typeof(IComponentChangeService), this);
		parent.AddService(typeof(ITypeDescriptorFilterService), this);
		parent.AddService(typeof(IEventBindingService), this);
		ca792b2d8ade9c1327a4e5ebb5452a151 = new ArrayList();
		parent.AddService(typeof(IExtenderListService), this);
		parent.AddService(typeof(IExtenderProviderService), this);
		AddExtenderProvider(this);
	}

	public object GetService(Type serviceType)
	{
		object obj = cef22b3a165097455787ecc938bfb65f5.GetService(serviceType);
		if (obj != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			c0ea366c6e22bc6f4872ab3d07ffe081e c0ea366c6e22bc6f4872ab3d07ffe081e2 = (c0ea366c6e22bc6f4872ab3d07ffe081e)cef22b3a165097455787ecc938bfb65f5.GetService(typeof(c0ea366c6e22bc6f4872ab3d07ffe081e));
			if (c0ea366c6e22bc6f4872ab3d07ffe081e2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				obj = c0ea366c6e22bc6f4872ab3d07ffe081e2.GetParentService(serviceType);
			}
		}
		return obj;
	}

	public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
	{
		cef22b3a165097455787ecc938bfb65f5.AddService(serviceType, callback, promote);
	}

	public void AddService(Type serviceType, ServiceCreatorCallback callback)
	{
		cef22b3a165097455787ecc938bfb65f5.AddService(serviceType, callback);
	}

	public void AddService(Type serviceType, object serviceInstance, bool promote)
	{
		cef22b3a165097455787ecc938bfb65f5.AddService(serviceType, serviceInstance, promote);
	}

	public void AddService(Type serviceType, object serviceInstance)
	{
		if (!(serviceInstance is ComponentTray componentTray))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			componentTray.AutoArrange = true;
		}
		cef22b3a165097455787ecc938bfb65f5.AddService(serviceType, serviceInstance);
	}

	public void RemoveService(Type serviceType, bool promote)
	{
		cef22b3a165097455787ecc938bfb65f5.RemoveService(serviceType, promote);
	}

	public void RemoveService(Type serviceType)
	{
		cef22b3a165097455787ecc938bfb65f5.RemoveService(serviceType);
	}

	public void Activate()
	{
		if (cddefd9b0cb3cdc68a7caf82ad8073df1 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cddefd9b0cb3cdc68a7caf82ad8073df1(this, EventArgs.Empty);
		}
	}

	public void Deactivate()
	{
		if (c811828a55f805d444ebde872c6871bcf == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			c811828a55f805d444ebde872c6871bcf(this, EventArgs.Empty);
		}
	}

	internal void OnLoadComplete()
	{
		EventHandler eventHandler = (EventHandler)cba51a85763227e8ccaa17b66eed14d8a[c9bb875674008a55b24b72c57582217ca];
		if (eventHandler == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			eventHandler(this, EventArgs.Empty);
		}
	}

	public IComponent CreateComponent(IComponent objWebComponent)
	{
		if (objWebComponent.Site != null)
		{
			_ = objWebComponent.Site.Name;
		}
		return CreateComponent(objWebComponent, null);
	}

	public IComponent CreateComponent(IComponent objWebComponent, string name)
	{
		IClientObjectController clientObjectController = DesignContext.CreateControllerByWebObject(Context, objWebComponent);
		IComponent component = null;
		if (clientObjectController == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			component = (IComponent)clientObjectController.TargetObject;
			((IContextServices)Context).RegisterController(clientObjectController);
			Add(component, clientObjectController, name);
		}
		return component;
	}

	public IComponent CreateComponent(Type componentClass)
	{
		return CreateComponent(componentClass, null);
	}

	public IComponent CreateComponent(Type objComponentType, string strName)
	{
		IComponent component = null;
		Type type = objComponentType;
		IClientObjectController clientObjectController = null;
		if (type.Namespace == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!type.Namespace.StartsWith("System.Windows.Forms"))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			Type type2 = Type.GetType(type.FullName.Replace("System.Windows.Forms", "Gizmox.WebGUI.Forms"));
			if (!(type2 != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				type = type2;
			}
		}
		if (IsWinFormsType(type))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			clientObjectController = DesignContext.CreateControllerByWebType(Context, type);
			if (clientObjectController == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				clientObjectController.InitializeNew();
				component = (IComponent)clientObjectController.TargetObject;
				((IContextServices)Context).RegisterController(clientObjectController);
				Add(component, clientObjectController, strName);
				DesignContext.InitializeController(clientObjectController);
			}
		}
		return component;
	}

	public void RenameComponent(IComponent component, string name)
	{
		if (component.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (component.Site.Name != name)
		{
			string name2 = component.Site.Name;
			c85fef5f5b9a75a973bb13e3d2571f38c.Remove(component.Site.Name);
			component.Site.Name = name;
			c85fef5f5b9a75a973bb13e3d2571f38c.Add(name, component);
			OnComponentRename(component, name2, name);
		}
	}

	public DesignerTransaction CreateTransaction(string strDescription)
	{
		DesignerTransaction designerTransaction = null;
		if (cd4a7b8da83b25420eb5d89b4a792a2f4.Count != 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (c0ce604cb2f3805d0180a3024d687b0bd == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			c0ce604cb2f3805d0180a3024d687b0bd(this, EventArgs.Empty);
		}
		if (strDescription != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			designerTransaction = new c20a268b578394023f20ae96bd0d1462b(this, strDescription);
		}
		else
		{
			designerTransaction = new c20a268b578394023f20ae96bd0d1462b(this);
		}
		cd4a7b8da83b25420eb5d89b4a792a2f4.Push(designerTransaction);
		if (ce838511233967195f60b64b78ca788f3 != null)
		{
			ce838511233967195f60b64b78ca788f3(this, EventArgs.Empty);
		}
		return designerTransaction;
	}

	internal void OnTransactionClosing(bool commit)
	{
		if (ce291af70f359c015d2a6679b98f6b5b6 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ce291af70f359c015d2a6679b98f6b5b6(this, new DesignerTransactionCloseEventArgs(commit));
		}
	}

	internal void OnTransactionClosed(bool commit)
	{
		if (c257732f4206ee56635f17e478e7c80cc != null)
		{
			c257732f4206ee56635f17e478e7c80cc(this, new DesignerTransactionCloseEventArgs(commit));
		}
		cd4a7b8da83b25420eb5d89b4a792a2f4.Pop();
	}

	public DesignerTransaction CreateTransaction()
	{
		return CreateTransaction(null);
	}

	private void DestroyControl(IControl objControl)
	{
		IEnumerator enumerator = objControl.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				IControl objControl2 = (IControl)enumerator.Current;
				DestroyControl(objControl2);
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

	private bool HasRelevantSite(IComponent objComponent)
	{
		if (objComponent.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return false;
		}
		return objComponent.Site.Container == this;
	}

	public void DestroyComponent(IComponent component)
	{
		if (component == null)
		{
			return;
		}
		Control control = component as Control;
		if (!HasRelevantSite(component))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (control == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (control.Controls.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				foreach (Control item in new ArrayList(control.Controls))
				{
					DestroyComponent(item);
				}
			}
			if (control.Parent == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				control.Parent.Controls.Remove(control);
			}
		}
		DesignerTransaction designerTransaction = CreateTransaction("Destroy Component");
		OnComponentChanging(component, null);
		OnComponentChanged(component, null, null, null);
		Remove(component);
		designerTransaction.Commit();
	}

	public IDesigner GetDesigner(IComponent objComponent)
	{
		if (objComponent != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return (IDesigner)ccf829a3b1abcc206a61734b37875d808[objComponent];
		}
		return null;
	}

	public Type GetType(string typeName)
	{
		ITypeResolutionService typeResolutionService = (ITypeResolutionService)GetService(typeof(ITypeResolutionService));
		if (typeResolutionService != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return typeResolutionService.GetType(typeName);
		}
		return Type.GetType(typeName);
	}

	internal bool ContainsName(string name)
	{
		return c85fef5f5b9a75a973bb13e3d2571f38c.Contains(name);
	}

	private ISite CreateSite(IComponent objComponent, string strName)
	{
		if (strName != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			strName = ((INameCreationService)GetService(typeof(INameCreationService))).CreateName(this, objComponent.GetType());
		}
		ClientSite clientSite = new ClientSite(this, strName);
		clientSite.SetComponent(objComponent);
		return clientSite;
	}

	private IDesigner CreateDesigner(IComponent objComponent)
	{
		return CreateDesigner(objComponent, blnRootDesigner: false);
	}

	private IDesigner CreateDesigner(IComponent objComponent, bool blnRootDesigner)
	{
		IDesigner designer = (IDesigner)ccf829a3b1abcc206a61734b37875d808[objComponent];
		if (designer == null)
		{
			if (!IsMenuComponent(objComponent))
			{
				/*OpCode not supported: LdMemberToken*/;
				TypeDescriptor.Refresh(objComponent);
				if (!blnRootDesigner)
				{
					/*OpCode not supported: LdMemberToken*/;
					designer = TypeDescriptor.CreateDesigner(objComponent, typeof(IDesigner));
				}
				else
				{
					designer = TypeDescriptor.CreateDesigner(objComponent, typeof(IRootDesigner));
				}
			}
			else
			{
				designer = (IDesigner)Activator.CreateInstance(GetMenuDesignerType());
			}
			if (designer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ccf829a3b1abcc206a61734b37875d808[objComponent] = designer;
			}
		}
		return designer;
	}

	private void RemoveDesigner(IComponent objComponent)
	{
		if (!ccf829a3b1abcc206a61734b37875d808.Contains(objComponent))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ccf829a3b1abcc206a61734b37875d808.Remove(objComponent);
		}
	}

	public void Add(IComponent objComponent, string strName)
	{
		if (!AddToContainerPreProcess(objComponent, strName, this))
		{
			return;
		}
		strName = AddInternal(objComponent, strName);
		try
		{
			AddToContainerPostProcess(objComponent, strName, this);
		}
		catch (Exception ex)
		{
			if (ex == CheckoutException.Canceled)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Remove(objComponent);
			}
			throw;
		}
	}

	private string AddInternal(IComponent objComponent, string strName)
	{
		ISite site = (objComponent.Site = CreateSite(objComponent, strName));
		c85fef5f5b9a75a973bb13e3d2571f38c[site.Name] = objComponent;
		return site.Name;
	}

	internal void AddToContainerPostProcess(IComponent objComponent, string strName, IContainer objContainerToAddTo)
	{
		IDesigner designer = null;
		if (!(objComponent is IExtenderProvider))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (TypeDescriptor.GetAttributes(objComponent).Contains(InheritanceAttribute.InheritedReadOnly))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!(GetService(typeof(IExtenderProviderService)) is IExtenderProviderService extenderProviderService))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			extenderProviderService.AddExtenderProvider((IExtenderProvider)objComponent);
		}
		if (cd21b4bf3e39a90eef04bdd2ee6ac57af != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			designer = CreateDesigner(objComponent, blnRootDesigner: false);
		}
		else
		{
			designer = CreateDesigner(objComponent, blnRootDesigner: true) as IRootDesigner;
			if (designer == null)
			{
				throw new Exception("No top level designer.")
				{
					HelpLink = "DesignerHostNoTopLevelDesigner"
				};
			}
			cd21b4bf3e39a90eef04bdd2ee6ac57af = objComponent;
			if (c202dff5eb931f6a68d731f768c2b31a3 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c202dff5eb931f6a68d731f768c2b31a3 = objComponent.Site.Name;
			}
		}
		if (designer == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ccf829a3b1abcc206a61734b37875d808[objComponent] = designer;
			try
			{
				designer.Initialize(objComponent);
				if (designer.Component == null)
				{
					throw new InvalidOperationException("Desinger needs a component.");
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			catch
			{
				RemoveDesigner(objComponent);
				throw;
			}
			if (!(designer is IExtenderProvider))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(GetService(typeof(IExtenderProviderService)) is IExtenderProviderService extenderProviderService2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				extenderProviderService2.AddExtenderProvider((IExtenderProvider)designer);
			}
		}
		if (c35a8904af2ae3e685b51209fec5fcadb != null)
		{
			c35a8904af2ae3e685b51209fec5fcadb(this, new ComponentEventArgs(objComponent));
		}
	}

	internal bool AddToContainerPreProcess(IComponent objComponent, string strName, IContainer objContainerToAddTo)
	{
		if (objComponent != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			if (c4d8bb9aaa7cdeeffc13c3e2f6947d798)
			{
				throw new Exception("Component can not be added when host is unloading.")
				{
					HelpLink = "DesignerHostUnloading"
				};
			}
			ISite site = objComponent.Site;
			if (site != null)
			{
				if (site.Container == this)
				{
					if (strName == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						site.Name = strName;
					}
					return false;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (c7a12a1187912d468c8da6d38e1b1ec65 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c7a12a1187912d468c8da6d38e1b1ec65(this, new ComponentEventArgs(objComponent));
			}
			return true;
		}
		throw new ArgumentNullException("objComponent");
	}

	public void Add(IComponent objComponent, IClientObjectController objController, string strName)
	{
		if (objController == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!(objController.SourceObject is IComponent component))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (component.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			strName = component.Site.Name;
		}
		Add(objComponent, strName);
	}

	public void Add(IComponent component)
	{
		Add(component, null, null);
	}

	public void Remove(IComponent component)
	{
		ISite site = component.Site;
		IDesigner designer = null;
		if (component == null)
		{
			return;
		}
		/*OpCode not supported: LdMemberToken*/;
		if (component.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (component.Site.Container != this)
			{
				return;
			}
			/*OpCode not supported: LdMemberToken*/;
			if (cc5ca13948b895e09b330cd6ae0ca0e9d != null)
			{
				cc5ca13948b895e09b330cd6ae0ca0e9d(this, new ComponentEventArgs(component));
			}
			if (component is IExtenderProvider)
			{
				((IExtenderProviderService)GetService(typeof(IExtenderProviderService))).RemoveExtenderProvider((IExtenderProvider)component);
			}
			c85fef5f5b9a75a973bb13e3d2571f38c.Remove(site.Name);
			designer = (IDesigner)ccf829a3b1abcc206a61734b37875d808[component];
			if (designer == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				designer.Dispose();
				ccf829a3b1abcc206a61734b37875d808.Remove(component);
			}
			if (c0f9592842b674e0bbadc8bd856cdac9c != null)
			{
				try
				{
					c0f9592842b674e0bbadc8bd856cdac9c(this, new ComponentEventArgs(component));
				}
				catch (Exception)
				{
				}
			}
			component.Site = null;
		}
	}

	public void Dispose()
	{
		if (c8f722c2f01c4b2ccc57832c47697501b)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		c8f722c2f01c4b2ccc57832c47697501b = true;
		string obj = c51dc97bb0b8b978bbea04bd848a839f6;
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			IEnumerator enumerator = ((IEnumerable)new ArrayList(c85fef5f5b9a75a973bb13e3d2571f38c.Keys)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					string key = (string)enumerator.Current;
					IComponent component = (IComponent)c85fef5f5b9a75a973bb13e3d2571f38c[key];
					if (component == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					IDesigner designer = GetDesigner(component);
					if (designer == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						designer.Dispose();
					}
					component.Site = null;
					component.Dispose();
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
			c85fef5f5b9a75a973bb13e3d2571f38c.Clear();
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

	public void OnComponentChanged(object component, MemberDescriptor member, object oldValue, object newValue)
	{
		if (c5bfdc1503bac80aacab20e841f0b2f3a != null)
		{
			c5bfdc1503bac80aacab20e841f0b2f3a(this, new ComponentChangedEventArgs(component, member, oldValue, newValue));
		}
	}

	public void OnComponentChanging(object component, MemberDescriptor member)
	{
		if (c5545c10765c313c2ddf324114bbc009a != null)
		{
			c5545c10765c313c2ddf324114bbc009a(this, new ComponentChangingEventArgs(component, member));
		}
	}

	internal void OnComponentRename(object component, string oldName, string newName)
	{
		if (c397750f13657efc00e5bf77865823de9 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			c397750f13657efc00e5bf77865823de9(this, new ComponentRenameEventArgs(component, oldName, newName));
		}
	}

	public bool CanExtend(object extendee)
	{
		return extendee is IComponent;
	}

	[Description("The variable used to refer to this component in source code.")]
	[DesignOnly(true)]
	[ParenthesizePropertyName(true)]
	[Category("Design")]
	[Browsable(true)]
	public string GetName(IComponent component)
	{
		if (component.Site == null)
		{
			throw new InvalidOperationException("Component is not sited.");
		}
		return component.Site.Name;
	}

	public void SetName(IComponent component, string name)
	{
		if (component.Site == null)
		{
			throw new InvalidOperationException("Component is not sited.");
		}
		component.Site.Name = name;
	}

	public bool FilterAttributes(IComponent component, IDictionary attributes)
	{
		IDesigner designer = GetDesigner(component);
		if (!(designer is IDesignerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((IDesignerFilter)designer).PreFilterAttributes(attributes);
			((IDesignerFilter)designer).PostFilterAttributes(attributes);
		}
		return designer != null;
	}

	public bool FilterEvents(IComponent component, IDictionary events)
	{
		IDesigner designer = GetDesigner(component);
		if (!(designer is IDesignerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((IDesignerFilter)designer).PreFilterEvents(events);
			((IDesignerFilter)designer).PostFilterEvents(events);
		}
		return designer != null;
	}

	public bool FilterProperties(IComponent component, IDictionary properties)
	{
		IDesigner designer = GetDesigner(component);
		if (!(designer is IDesignerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			((IDesignerFilter)designer).PreFilterProperties(properties);
			((IDesignerFilter)designer).PostFilterProperties(properties);
		}
		return designer != null;
	}

	public IExtenderProvider[] GetExtenderProviders()
	{
		IExtenderProvider[] array = new IExtenderProvider[ca792b2d8ade9c1327a4e5ebb5452a151.Count];
		ca792b2d8ade9c1327a4e5ebb5452a151.CopyTo(array, 0);
		return array;
	}

	public void AddExtenderProvider(IExtenderProvider objProvider)
	{
		if (ca792b2d8ade9c1327a4e5ebb5452a151.Contains(objProvider))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ca792b2d8ade9c1327a4e5ebb5452a151.Add(objProvider);
		}
	}

	public void RemoveExtenderProvider(IExtenderProvider objProvider)
	{
		if (!ca792b2d8ade9c1327a4e5ebb5452a151.Contains(objProvider))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ca792b2d8ade9c1327a4e5ebb5452a151.Remove(objProvider);
		}
	}

	public PropertyDescriptor GetEventProperty(EventDescriptor e)
	{
		((c0ea366c6e22bc6f4872ab3d07ffe081e)GetService(typeof(c0ea366c6e22bc6f4872ab3d07ffe081e)))?.GetParentDesinger().DoDefaultAction();
		return null;
	}

	public ICollection GetCompatibleMethods(EventDescriptor e)
	{
		return null;
	}

	public PropertyDescriptorCollection GetEventProperties(EventDescriptorCollection events)
	{
		return null;
	}

	public bool ShowCode(IComponent component, EventDescriptor e)
	{
		return false;
	}

	public bool ShowCode(int lineNumber)
	{
		return false;
	}

	public bool ShowCode()
	{
		return false;
	}

	public EventDescriptor GetEvent(PropertyDescriptor property)
	{
		return null;
	}

	public string CreateUniqueMethodName(IComponent component, EventDescriptor e)
	{
		return null;
	}

	private EventDescriptor GetEventDescriptior(object component, string strName)
	{
		return null;
	}

	private bool IsMenuComponent(IComponent objComponent)
	{
		if (!(Context is IContextServices contextServices))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			IClientObjectController controllerByWinObject = contextServices.GetControllerByWinObject(objComponent);
			if (controllerByWinObject != null)
			{
				return controllerByWinObject.UseVsMenuDeisgner;
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		return false;
	}

	private Type GetMenuDesignerType()
	{
		return Type.GetType("Microsoft.VisualStudio.Windows.Forms.MenuDesigner, Microsoft.VisualStudio.Windows.Forms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
	}

	private bool IsWinFormsType(Type objSourceType)
	{
		if (objSourceType != null)
		{
			if (!(objSourceType.Assembly == typeof(Control).Assembly))
			{
				return IsWinFormsType(objSourceType.BaseType);
			}
			return true;
		}
		return false;
	}
}
