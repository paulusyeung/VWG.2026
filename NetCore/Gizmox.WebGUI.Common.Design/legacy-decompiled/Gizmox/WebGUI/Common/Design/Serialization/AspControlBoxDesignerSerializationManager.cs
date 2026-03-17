using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class AspControlBoxDesignerSerializationManager : IDesignerSerializationManager, IServiceProvider
{
	private IDesignerSerializationManager cedc76772d48b9997b03489b326a2a563;

	public ContextStack Context
	{
		get
		{
			if (cedc76772d48b9997b03489b326a2a563 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return cedc76772d48b9997b03489b326a2a563.Context;
		}
	}

	public PropertyDescriptorCollection Properties
	{
		get
		{
			if (cedc76772d48b9997b03489b326a2a563 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			return cedc76772d48b9997b03489b326a2a563.Properties;
		}
	}

	event ResolveNameEventHandler IDesignerSerializationManager.ResolveName
	{
		add
		{
			if (cedc76772d48b9997b03489b326a2a563 != null)
			{
				cedc76772d48b9997b03489b326a2a563.ResolveName += value;
			}
		}
		remove
		{
			if (cedc76772d48b9997b03489b326a2a563 != null)
			{
				cedc76772d48b9997b03489b326a2a563.ResolveName -= value;
			}
		}
	}

	event EventHandler IDesignerSerializationManager.SerializationComplete
	{
		add
		{
			if (cedc76772d48b9997b03489b326a2a563 != null)
			{
				cedc76772d48b9997b03489b326a2a563.SerializationComplete += value;
			}
		}
		remove
		{
			if (cedc76772d48b9997b03489b326a2a563 != null)
			{
				cedc76772d48b9997b03489b326a2a563.SerializationComplete -= value;
			}
		}
	}

	public AspControlBoxDesignerSerializationManager(IDesignerSerializationManager objManager)
	{
		cedc76772d48b9997b03489b326a2a563 = objManager;
	}

	public void AddSerializationProvider(IDesignerSerializationProvider provider)
	{
		if (cedc76772d48b9997b03489b326a2a563 != null)
		{
			cedc76772d48b9997b03489b326a2a563.AddSerializationProvider(provider);
		}
	}

	public object CreateInstance(Type type, ICollection arguments, string name, bool addToContainer)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return cedc76772d48b9997b03489b326a2a563.CreateInstance(type, arguments, name, addToContainer);
	}

	public object GetInstance(string name)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return cedc76772d48b9997b03489b326a2a563.GetInstance(name);
	}

	public string GetName(object value)
	{
		if (cedc76772d48b9997b03489b326a2a563 != null)
		{
			return cedc76772d48b9997b03489b326a2a563.GetName(value);
		}
		return string.Empty;
	}

	public object GetSerializer(Type objectType, Type serializerType)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		if (!(serializerType == typeof(MemberCodeDomSerializer)))
		{
			/*OpCode not supported: LdMemberToken*/;
			return cedc76772d48b9997b03489b326a2a563.GetSerializer(objectType, serializerType);
		}
		return new AspControlBoxMemberCodeDomSerializer(cedc76772d48b9997b03489b326a2a563.GetSerializer(objectType, serializerType) as MemberCodeDomSerializer);
	}

	public Type GetType(string typeName)
	{
		if (cedc76772d48b9997b03489b326a2a563 != null)
		{
			return cedc76772d48b9997b03489b326a2a563.GetType(typeName);
		}
		return null;
	}

	public void RemoveSerializationProvider(IDesignerSerializationProvider provider)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cedc76772d48b9997b03489b326a2a563.RemoveSerializationProvider(provider);
		}
	}

	public void ReportError(object errorInformation)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cedc76772d48b9997b03489b326a2a563.ReportError(errorInformation);
		}
	}

	public void SetName(object instance, string name)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cedc76772d48b9997b03489b326a2a563.SetName(instance, name);
		}
	}

	public object GetService(Type serviceType)
	{
		if (cedc76772d48b9997b03489b326a2a563 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return cedc76772d48b9997b03489b326a2a563.GetService(serviceType);
	}
}
