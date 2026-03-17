using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using A;

namespace Gizmox.WebGUI.Client.Design.Host;

public class ClientSite : IDictionaryService, ISite, IServiceProvider
{
	private IDesignerHost c49b0831076ca879d1f1e580ef82dd5cf;

	private IComponent c8aa1599af9a5dbd4897d38ffe06a569a;

	private Hashtable cb7ee2c126a67aacd9f585626dcca736e;

	private string c92d64072c993d9d383a473e26cde1e03;

	private INestedContainer c7f06a6ca5d6388f3b1f9233fddd6bc37;

	public IComponent Component => c8aa1599af9a5dbd4897d38ffe06a569a;

	public IContainer Container => c49b0831076ca879d1f1e580ef82dd5cf.Container;

	public bool DesignMode => true;

	public string Name
	{
		get
		{
			return c92d64072c993d9d383a473e26cde1e03;
		}
		set
		{
			if (value != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!(value == c92d64072c993d9d383a473e26cde1e03))
				{
					/*OpCode not supported: LdMemberToken*/;
					if (((ccc53407af8f11baecaaada159429c8fa)c49b0831076ca879d1f1e580ef82dd5cf).ContainsName(value))
					{
						throw new ArgumentException("There is already a component with this name in the container.");
					}
					string text = c92d64072c993d9d383a473e26cde1e03;
					MemberDescriptor member = TypeDescriptor.CreateProperty(c8aa1599af9a5dbd4897d38ffe06a569a.GetType(), "Name", typeof(string));
					((ccc53407af8f11baecaaada159429c8fa)c49b0831076ca879d1f1e580ef82dd5cf).OnComponentChanging(c8aa1599af9a5dbd4897d38ffe06a569a, member);
					c92d64072c993d9d383a473e26cde1e03 = value;
					((ccc53407af8f11baecaaada159429c8fa)c49b0831076ca879d1f1e580ef82dd5cf).OnComponentRename(c8aa1599af9a5dbd4897d38ffe06a569a, text, c92d64072c993d9d383a473e26cde1e03);
					((ccc53407af8f11baecaaada159429c8fa)c49b0831076ca879d1f1e580ef82dd5cf).OnComponentChanged(c8aa1599af9a5dbd4897d38ffe06a569a, member, text, c92d64072c993d9d383a473e26cde1e03);
				}
				return;
			}
			throw new ArgumentException("Cannot set a component's name to a null value.");
		}
	}

	private INestedContainer CurrentNestedContainer
	{
		get
		{
			if (c7f06a6ca5d6388f3b1f9233fddd6bc37 == null)
			{
				c7f06a6ca5d6388f3b1f9233fddd6bc37 = new ccc53407af8f11baecaaada159429c8fa.cda1369eed9e89805abb85f93c0ed98aa((ccc53407af8f11baecaaada159429c8fa)c49b0831076ca879d1f1e580ef82dd5cf, Component);
			}
			return c7f06a6ca5d6388f3b1f9233fddd6bc37;
		}
	}

	public ClientSite(IDesignerHost host, string name)
	{
		c49b0831076ca879d1f1e580ef82dd5cf = host;
		c92d64072c993d9d383a473e26cde1e03 = name;
	}

	public object GetService(Type serviceType)
	{
		if (!(serviceType == typeof(IDictionaryService)))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (serviceType == typeof(INestedContainer))
			{
				return CurrentNestedContainer;
			}
			return c49b0831076ca879d1f1e580ef82dd5cf.GetService(serviceType);
		}
		return this;
	}

	internal void SetComponent(IComponent component)
	{
		c8aa1599af9a5dbd4897d38ffe06a569a = component;
		if (c92d64072c993d9d383a473e26cde1e03 == null)
		{
			INameCreationService nameCreationService = (INameCreationService)GetService(typeof(INameCreationService));
			c92d64072c993d9d383a473e26cde1e03 = nameCreationService.CreateName(c49b0831076ca879d1f1e580ef82dd5cf.Container, component.GetType());
		}
	}

	public object GetKey(object value)
	{
		if (cb7ee2c126a67aacd9f585626dcca736e != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return GetKeyFromValue(value);
		}
		return null;
	}

	private object GetKeyFromValue(object value)
	{
		IDictionaryEnumerator enumerator = cb7ee2c126a67aacd9f585626dcca736e.GetEnumerator();
		while (enumerator.MoveNext())
		{
			/*OpCode not supported: LdMemberToken*/;
			if (enumerator.Value != value)
			{
				/*OpCode not supported: LdMemberToken*/;
				continue;
			}
			return enumerator.Key;
		}
		return null;
	}

	public object GetValue(object key)
	{
		if (cb7ee2c126a67aacd9f585626dcca736e != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return cb7ee2c126a67aacd9f585626dcca736e[key];
		}
		return null;
	}

	public void SetValue(object key, object value)
	{
		if (cb7ee2c126a67aacd9f585626dcca736e == null)
		{
			cb7ee2c126a67aacd9f585626dcca736e = new Hashtable();
		}
		if (value != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			cb7ee2c126a67aacd9f585626dcca736e[key] = value;
		}
		else
		{
			cb7ee2c126a67aacd9f585626dcca736e.Remove(key);
		}
	}
}
