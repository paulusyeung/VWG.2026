using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using EnvDTE;

namespace Gizmox.WebGUI.Common.Design.Skins;

public class DocumentDesinger : ComponentDesigner, IRootDesigner, IDesigner, IDisposable, IServiceProvider, ITypeResolutionService
{
	protected class DocumentNestedContainer : NestedContainer
	{
		private DocumentDesinger mobjDocumentDesigner;

		public DocumentNestedContainer(IComponent objComponent, DocumentDesinger objDocumentDesigner)
			: base(objComponent)
		{
			mobjDocumentDesigner = objDocumentDesigner;
		}

		protected override object GetService(Type service)
		{
			object service2 = base.GetService(service);
			if (service2 == null)
			{
				service2 = mobjDocumentDesigner.GetService(service);
			}
			return service2;
		}
	}

	private bool mblnSuspendDesignerNotifications;

	private DocumentDesignerFrame mobjFrame;

	private Type mobjSkinType;

	private Type mobjThemeType;

	private Type mobjResourceType;

	private NestedContainer mobjNestedContainer;

	public Type SkinType
	{
		get
		{
			if (mobjSkinType == null)
			{
				mobjSkinType = DocumentUtils.InvokeMethod(base.Component, "GetSkinType", "Skin") as Type;
			}
			return mobjSkinType;
		}
	}

	public Type ThemeType
	{
		get
		{
			if (mobjThemeType == null)
			{
				mobjThemeType = DocumentUtils.InvokeMethod(base.Component, "GetSkinType", "Theme") as Type;
			}
			return mobjThemeType;
		}
	}

	internal DocumentDesignerFrame Frame
	{
		get
		{
			return mobjFrame;
		}
		set
		{
			mobjFrame = value;
		}
	}

	public Type ResourceType
	{
		get
		{
			if (mobjResourceType == null)
			{
				mobjResourceType = DocumentUtils.InvokeMethod(base.Component, "GetReousrceType", "SkinResource") as Type;
			}
			return mobjResourceType;
		}
	}

	ViewTechnology[] IRootDesigner.SupportedTechnologies => new ViewTechnology[1] { ViewTechnology.Default };

	public override void Initialize(IComponent objComponent)
	{
		base.Initialize(objComponent);
		mobjNestedContainer = new DocumentNestedContainer(base.Component, this);
		RemoveExtenderProviders();
	}

	private void RemoveExtenderProviders()
	{
		IExtenderListService extenderListService = (IExtenderListService)GetService(typeof(IExtenderListService));
		if (extenderListService == null)
		{
			return;
		}
		System.ComponentModel.IExtenderProvider[] extenderProviders = extenderListService.GetExtenderProviders();
		foreach (System.ComponentModel.IExtenderProvider extenderProvider in extenderProviders)
		{
			if (extenderProvider != null && extenderProvider.GetType().FullName == "System.ComponentModel.Design.Serialization.CodeDomDesignerLoader+ModifiersExtenderProvider")
			{
				RemoveExtenderProvider(extenderProvider);
			}
		}
	}

	private void RemoveExtenderProvider(System.ComponentModel.IExtenderProvider objExtenderProvider)
	{
		((IExtenderProviderService)GetService(typeof(IExtenderProviderService)))?.RemoveExtenderProvider(objExtenderProvider);
	}

	protected override object GetService(Type service)
	{
		if (mblnSuspendDesignerNotifications && service == typeof(INestedContainer))
		{
			return mobjNestedContainer;
		}
		return base.GetService(service);
	}

	protected override void PostFilterProperties(IDictionary objProperties)
	{
		objProperties.Remove("GenerateMember");
		objProperties.Remove("Modifiers");
		base.PostFilterProperties(objProperties);
	}

	object IRootDesigner.GetView(ViewTechnology technology)
	{
		if (mobjFrame == null)
		{
			mobjFrame = new DocumentDesignerFrame(this);
			AddService(typeof(DocumentDesignerFrame), mobjFrame);
		}
		return mobjFrame;
	}

	private void AddService(Type objServiceType, ServiceCreatorCallback objServiceCreatorCallback)
	{
		IServiceContainer serviceContainer = (IServiceContainer)GetService(typeof(IServiceContainer));
		if (serviceContainer != null)
		{
			if (serviceContainer.GetService(objServiceType) != null)
			{
				serviceContainer.RemoveService(objServiceType);
			}
			serviceContainer.AddService(objServiceType, objServiceCreatorCallback);
		}
	}

	private void AddService(Type objServiceType, object objServiceInstance)
	{
		IServiceContainer serviceContainer = (IServiceContainer)GetService(typeof(IServiceContainer));
		if (serviceContainer != null)
		{
			if (serviceContainer.GetService(objServiceType) != null)
			{
				serviceContainer.RemoveService(objServiceType);
			}
			serviceContainer.AddService(objServiceType, objServiceInstance);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && mobjFrame != null)
		{
			mobjFrame.Dispose();
		}
		base.Dispose(disposing);
	}

	public void SuspendDesignerNotifications()
	{
		mblnSuspendDesignerNotifications = true;
	}

	public void ResumeDesignerNotifications()
	{
		mblnSuspendDesignerNotifications = false;
	}

	protected void SetSelectedComponent(object objComponent)
	{
		((ISelectionService)GetService(typeof(ISelectionService)))?.SetSelectedComponents(new object[1] { objComponent });
	}

	internal object GetServiceInternal(Type objServiceType)
	{
		return GetService(objServiceType);
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		if (typeof(ITypeResolutionService) == serviceType)
		{
			return this;
		}
		return GetService(serviceType);
	}

	Assembly ITypeResolutionService.GetAssembly(AssemblyName name, bool throwOnError)
	{
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetAssembly(name, throwOnError);
	}

	Assembly ITypeResolutionService.GetAssembly(AssemblyName name)
	{
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetAssembly(name);
	}

	string ITypeResolutionService.GetPathOfAssembly(AssemblyName name)
	{
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetPathOfAssembly(name);
	}

	Type ITypeResolutionService.GetType(string name, bool throwOnError, bool ignoreCase)
	{
		Type componentType = GetComponentType(name, ignoreCase);
		if (componentType != null)
		{
			return componentType;
		}
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetType(name, throwOnError, ignoreCase);
	}

	private Type GetComponentType(string name, bool ignoreCase)
	{
		IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		if (designerHost != null && designerHost.RootComponentClassName == name)
		{
			ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
			if (projectItem != null)
			{
				return GetComponentType(projectItem.FileCodeModel.CodeElements, name, ignoreCase);
			}
		}
		return null;
	}

	private Type GetComponentType(CodeElements objCodeElements, string name, bool ignoreCase)
	{
		foreach (CodeElement objCodeElement in objCodeElements)
		{
			if (objCodeElement.Kind == vsCMElement.vsCMElementClass && (objCodeElement.Name == name || objCodeElement.FullName == name))
			{
				ITypeResolutionService typeResolutionService = (ITypeResolutionService)GetService(typeof(ITypeResolutionService));
				if (typeResolutionService != null)
				{
					return typeResolutionService.GetType(objCodeElement.FullName, throwOnError: false);
				}
			}
			if (objCodeElement.Kind == vsCMElement.vsCMElementNamespace)
			{
				Type componentType = GetComponentType(objCodeElement.Children, name, ignoreCase);
				if (componentType != null)
				{
					return componentType;
				}
			}
		}
		return null;
	}

	Type ITypeResolutionService.GetType(string name, bool throwOnError)
	{
		Type componentType = GetComponentType(name, ignoreCase: false);
		if (componentType != null)
		{
			return componentType;
		}
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetType(name, throwOnError);
	}

	Type ITypeResolutionService.GetType(string name)
	{
		Type componentType = GetComponentType(name, ignoreCase: false);
		if (componentType != null)
		{
			return componentType;
		}
		return ((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.GetType(name);
	}

	void ITypeResolutionService.ReferenceAssembly(AssemblyName name)
	{
		((ITypeResolutionService)GetService(typeof(ITypeResolutionService)))?.ReferenceAssembly(name);
	}
}
