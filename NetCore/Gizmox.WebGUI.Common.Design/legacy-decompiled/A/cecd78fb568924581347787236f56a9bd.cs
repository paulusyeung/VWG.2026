using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Design.Serialization;

namespace A;

internal class cecd78fb568924581347787236f56a9bd : ControlCodeDomSerializer
{
	private static readonly string c66d744b0c734207422c143aa41a4bf69 = "LayoutSettings";

	public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
	{
		return GetBaseSerializer(manager).Deserialize(manager, codeObject);
	}

	private CodeDomSerializer GetBaseSerializer(IDesignerSerializationManager manager)
	{
		return (CodeDomSerializer)manager.GetSerializer(Config.GetFormsAssembly().GetType("Gizmox.WebGUI.Forms.TableLayoutPanel").BaseType, typeof(CodeDomSerializer));
	}

	private bool IsLocalizable(IDesignerHost host)
	{
		if (host == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(host.RootComponent)["Localizable"];
			if (propertyDescriptor != null)
			{
				if (propertyDescriptor.PropertyType == typeof(bool))
				{
					return (bool)propertyDescriptor.GetValue(host.RootComponent);
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		return false;
	}

	public override object Serialize(IDesignerSerializationManager manager, object value)
	{
		object result = GetBaseSerializer(manager).Serialize(manager, value);
		if (value != null)
		{
			InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(value)[typeof(InheritanceAttribute)];
			if (inheritanceAttribute == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (inheritanceAttribute.InheritanceLevel == InheritanceLevel.InheritedReadOnly)
			{
				goto IL_00e4;
			}
			IDesignerHost host = (IDesignerHost)manager.GetService(typeof(IDesignerHost));
			if (!IsLocalizable(host))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(value)[c66d744b0c734207422c143aa41a4bf69];
				object obj;
				if (propertyDescriptor != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					obj = propertyDescriptor.GetValue(value);
				}
				else
				{
					obj = null;
				}
				object obj2 = obj;
				if (obj2 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					string resourceName = manager.GetName(value) + "." + c66d744b0c734207422c143aa41a4bf69;
					SerializeResourceInvariant(manager, resourceName, obj2);
				}
			}
		}
		goto IL_00e4;
		IL_00e4:
		return result;
	}
}
