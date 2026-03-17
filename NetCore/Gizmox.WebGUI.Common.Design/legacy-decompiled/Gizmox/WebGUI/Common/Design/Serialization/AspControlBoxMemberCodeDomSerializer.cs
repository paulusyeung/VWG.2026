using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using A;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class AspControlBoxMemberCodeDomSerializer : MemberCodeDomSerializer
{
	private MemberCodeDomSerializer cb3e0219aaceaa0b56994b3949c5ab2cf;

	public AspControlBoxMemberCodeDomSerializer(MemberCodeDomSerializer objMemberCodeDomSerializer)
	{
		cb3e0219aaceaa0b56994b3949c5ab2cf = objMemberCodeDomSerializer;
	}

	public override void Serialize(IDesignerSerializationManager manager, object value, MemberDescriptor descriptor, CodeStatementCollection statements)
	{
		if (cb3e0219aaceaa0b56994b3949c5ab2cf == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cb3e0219aaceaa0b56994b3949c5ab2cf.Serialize(manager, value, descriptor, statements);
		}
	}

	public override bool ShouldSerialize(IDesignerSerializationManager manager, object value, MemberDescriptor descriptor)
	{
		if (cb3e0219aaceaa0b56994b3949c5ab2cf == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			bool flag = false;
			if (!(descriptor is PropertyDescriptor))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				flag = GetPropertyValue(manager, descriptor as PropertyDescriptor, value, out var _) == null;
			}
			if (!flag)
			{
				return cb3e0219aaceaa0b56994b3949c5ab2cf.ShouldSerialize(manager, value, descriptor);
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		return false;
	}

	private object GetPropertyValue(IDesignerSerializationManager manager, PropertyDescriptor property, object value, out bool validValue)
	{
		object result = null;
		validValue = true;
		try
		{
			if (property.ShouldSerializeValue(value))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				AmbientValueAttribute ambientValueAttribute = (AmbientValueAttribute)property.Attributes[typeof(AmbientValueAttribute)];
				if (ambientValueAttribute != null)
				{
					return ambientValueAttribute.Value;
				}
				/*OpCode not supported: LdMemberToken*/;
				DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];
				if (defaultValueAttribute != null)
				{
					return defaultValueAttribute.Value;
				}
				/*OpCode not supported: LdMemberToken*/;
				validValue = false;
			}
			result = property.GetValue(value);
		}
		catch (Exception ex)
		{
			validValue = false;
			manager.ReportError(c68b754590e04bede43f044278809a4dd.GetString("SerializerPropertyGenFailed", property.Name, ex.Message));
		}
		return result;
	}
}
