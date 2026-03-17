using System.ComponentModel;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Client.Design.Host;

public class ClientDesignerExtenders
{
	[ProvideProperty("Name", typeof(IComponent))]
	public class NameExtenderProvider : IExtenderProvider
	{
		private IComponent c540f1216d1d88800f5e15f53be1aae48;

		internal NameExtenderProvider()
		{
		}

		public virtual bool CanExtend(object o)
		{
			if (GetBaseComponent(o) == o)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!TypeDescriptor.GetAttributes(o)[typeof(InheritanceAttribute)].Equals(InheritanceAttribute.NotInherited))
			{
				return false;
			}
			return true;
		}

		protected IComponent GetBaseComponent(object o)
		{
			if (c540f1216d1d88800f5e15f53be1aae48 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				ISite site = ((IComponent)o).Site;
				if (site == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					IDesignerHost designerHost = (IDesignerHost)site.GetService(typeof(IDesignerHost));
					if (designerHost != null)
					{
						c540f1216d1d88800f5e15f53be1aae48 = designerHost.RootComponent;
					}
				}
			}
			return c540f1216d1d88800f5e15f53be1aae48;
		}

		[MergableProperty(false)]
		[Category("Design")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[ParenthesizePropertyName(true)]
		public virtual string GetName(IComponent comp)
		{
			ISite site = comp.Site;
			if (site == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return site.Name;
		}

		public void SetName(IComponent objComponent, string strName)
		{
			if (!(objComponent is IControl control))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				control.Name = strName;
			}
			ISite site = objComponent.Site;
			if (site == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				site.Name = strName;
			}
		}
	}

	public class NameInheritedExtenderProvider : NameExtenderProvider
	{
		internal NameInheritedExtenderProvider()
		{
		}

		public override bool CanExtend(object o)
		{
			if (GetBaseComponent(o) == o)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (!TypeDescriptor.GetAttributes(o)[typeof(InheritanceAttribute)].Equals(InheritanceAttribute.NotInherited))
				{
					return true;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return false;
		}

		[ReadOnly(true)]
		public override string GetName(IComponent comp)
		{
			return base.GetName(comp);
		}
	}

	private IExtenderProviderService ccf340e87342ff98fe1b12d30cb45f4b3;

	private IExtenderProvider[] c432283ca61cf9be9333fbad6df129ecf;

	public void Extend(IExtenderProviderService ex)
	{
		if (ccf340e87342ff98fe1b12d30cb45f4b3 == ex)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		ccf340e87342ff98fe1b12d30cb45f4b3 = ex;
		if (c432283ca61cf9be9333fbad6df129ecf == null)
		{
			c432283ca61cf9be9333fbad6df129ecf = new IExtenderProvider[2]
			{
				new NameExtenderProvider(),
				new NameInheritedExtenderProvider()
			};
		}
		for (int i = 0; i < c432283ca61cf9be9333fbad6df129ecf.Length; i++)
		{
			/*OpCode not supported: LdMemberToken*/;
			ex.AddExtenderProvider(c432283ca61cf9be9333fbad6df129ecf[i]);
		}
	}

	public void Dispose()
	{
		if (ccf340e87342ff98fe1b12d30cb45f4b3 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		if (c432283ca61cf9be9333fbad6df129ecf == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		for (int i = 0; i < c432283ca61cf9be9333fbad6df129ecf.Length; i++)
		{
			ccf340e87342ff98fe1b12d30cb45f4b3.RemoveExtenderProvider(c432283ca61cf9be9333fbad6df129ecf[i]);
		}
		c432283ca61cf9be9333fbad6df129ecf = null;
		ccf340e87342ff98fe1b12d30cb45f4b3 = null;
	}
}
