using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Client.Design;

namespace Gizmox.WebGUI.Forms.Design;

public class MappedComponentDesigner : ComponentDesigner, IClientObjectController
{
	private IClientObjectController c2a03ce5f5ed8ed805909bbe9f5ef40ef;

	private IComponent c7715442310fe837272fc240ed6e72cf8;

	public override DesignerVerbCollection Verbs
	{
		get
		{
			if (Controller is IClientDesigner clientDesigner)
			{
				return clientDesigner.GetVerbs();
			}
			return base.Verbs;
		}
	}

	protected IClientObjectController Controller
	{
		get
		{
			if (c2a03ce5f5ed8ed805909bbe9f5ef40ef != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				IContextServices contextServices = (IContextServices)GetService(typeof(IContextServices));
				if (contextServices == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					c2a03ce5f5ed8ed805909bbe9f5ef40ef = null;
				}
				else
				{
					c2a03ce5f5ed8ed805909bbe9f5ef40ef = contextServices.GetControllerByWebObject(base.Component);
				}
			}
			return c2a03ce5f5ed8ed805909bbe9f5ef40ef;
		}
	}

	protected IComponent MappedComponent => MappedComponentInternal;

	internal virtual IComponent MappedComponentInternal
	{
		get
		{
			if (c7715442310fe837272fc240ed6e72cf8 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c7715442310fe837272fc240ed6e72cf8 = GetMappedComponent();
			}
			return c7715442310fe837272fc240ed6e72cf8;
		}
	}

	object IClientObjectController.SourceObject => base.Component;

	object IClientObjectController.TargetObject => MappedComponent;

	object IClientObjectController.SelectableObject => ((IClientObjectController)this).TargetObject;

	bool IClientObjectController.UseVsMenuDeisgner => ((IClientObjectController)this).UseVsMenuDeisgner;

	protected override void PostFilterAttributes(IDictionary attributes)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PostFilterAttributes(attributes);
		}
		else
		{
			designerFilter.PostFilterAttributes(attributes);
		}
	}

	protected override void PostFilterEvents(IDictionary events)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PostFilterEvents(events);
		}
		else
		{
			designerFilter.PostFilterEvents(events);
		}
	}

	protected override void PostFilterProperties(IDictionary properties)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PostFilterProperties(properties);
		}
		else
		{
			designerFilter.PostFilterProperties(properties);
		}
	}

	protected override void PreFilterAttributes(IDictionary attributes)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PreFilterAttributes(attributes);
		}
		else
		{
			designerFilter.PreFilterAttributes(attributes);
		}
	}

	protected override void PreFilterEvents(IDictionary events)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PreFilterEvents(events);
		}
		else
		{
			designerFilter.PreFilterEvents(events);
		}
	}

	protected override void PreFilterProperties(IDictionary properties)
	{
		if (!(Controller is IDesignerFilter designerFilter))
		{
			/*OpCode not supported: LdMemberToken*/;
			base.PreFilterProperties(properties);
		}
		else
		{
			designerFilter.PreFilterProperties(properties);
		}
	}

	protected virtual IComponent GetMappedComponent()
	{
		return null;
	}

	void IClientObjectController.Initialize()
	{
	}

	void IClientObjectController.InitializeNew()
	{
	}

	void IClientObjectController.Load()
	{
	}

	void IClientObjectController.Terminate()
	{
	}

	void IClientObjectController.SetParent(IClientObjectController objController)
	{
	}
}
