using System;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design;

public class ControlDesigner : MappedComponentDesigner
{
	public override ICollection AssociatedComponents
	{
		get
		{
			if (base.Component is IControl control)
			{
				ArrayList arrayList = null;
				{
					IEnumerator enumerator = control.Controls.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							/*OpCode not supported: LdMemberToken*/;
							IControl control2 = (IControl)enumerator.Current;
							if (control2.Site != null)
							{
								if (arrayList != null)
								{
									/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									arrayList = new ArrayList();
								}
								arrayList.Add(control2);
							}
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
				if (arrayList != null)
				{
					return arrayList;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return base.AssociatedComponents;
		}
	}

	protected override IComponent ParentComponent
	{
		get
		{
			if (!(base.Component is IControl control))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (control.Parent is IComponent result)
				{
					return result;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return base.ParentComponent;
		}
	}

	protected override void PostFilterProperties(IDictionary properties)
	{
		if (properties.Contains("Parent"))
		{
			AttributeCollection attributes = TypeDescriptor.GetAttributes(base.Component);
			if (attributes == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(attributes[typeof(InheritanceAttribute)] is InheritanceAttribute inheritanceAttribute))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (inheritanceAttribute.InheritanceLevel != InheritanceLevel.Inherited)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				PropertyDescriptor propertyDescriptor = properties["Parent"] as PropertyDescriptor;
				propertyDescriptor = TypeDescriptor.CreateProperty(propertyDescriptor.ComponentType, propertyDescriptor, new BrowsableAttribute(browsable: true), new TypeConverterAttribute(typeof(ReferenceConverter)));
				properties[propertyDescriptor.Name] = propertyDescriptor;
			}
		}
		base.PostFilterProperties(properties);
	}
}
