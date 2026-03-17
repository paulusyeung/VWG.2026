using System;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Client.Design;

public class ClientFactory
{
	private static Type c3baac09af1b17439f86660239eaa0cb3;

	private static Type ClientDesignContext
	{
		get
		{
			if (!(c3baac09af1b17439f86660239eaa0cb3 == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				return c3baac09af1b17439f86660239eaa0cb3;
			}
			throw new Exception("Cound not load client design context.");
		}
	}

	static ClientFactory()
	{
		Assembly clientAssembly = GetClientAssembly();
		if (!(clientAssembly != null))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			c3baac09af1b17439f86660239eaa0cb3 = clientAssembly.GetType("Gizmox.WebGUI.Client.Design.ClientDesignContext");
		}
	}

	private static Assembly GetClientAssembly()
	{
		new AssemblyName();
		return Assembly.Load("Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23");
	}

	private static object InvokeStatic(string strMethod, params object[] arrArgs)
	{
		MethodInfo method = ClientDesignContext.GetMethod(strMethod, BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod);
		if (!(method != null))
		{
			/*OpCode not supported: LdMemberToken*/;
			return null;
		}
		return method.Invoke(null, arrArgs);
	}

	public static IContext CreateContext(IClientDesignServices objDesignServices)
	{
		return (IContext)InvokeStatic("CreateContext", objDesignServices);
	}

	public static IClientObjectController CreateMenuController(IContext objContext, IComponent objWebComponent)
	{
		return (IClientObjectController)InvokeStatic("CreateMenuController", objContext, objWebComponent);
	}

	internal static IClientObjectController CreateController(IContext objContext, object objWebComponent)
	{
		return (IClientObjectController)InvokeStatic("CreateControllerByWebObject", objContext, objWebComponent);
	}
}
