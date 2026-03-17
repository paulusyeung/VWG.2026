using System;
using System.CodeDom;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class ObjectBoxParameterCollectionSelrializer : CodeDomSerializer
{
	public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
	{
		if (manager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (codeObject != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
			if (codeDomSerializer != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return codeDomSerializer.Deserialize(manager, codeObject);
			}
			return null;
		}
		object paramName;
		if (manager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			paramName = "manager";
		}
		else
		{
			paramName = "codeObject";
		}
		throw new ArgumentNullException((string)paramName);
	}

	public override object Serialize(IDesignerSerializationManager manager, object value)
	{
		object obj = base.Serialize(manager, value);
		if (!(value is IEnumerable enumerable))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (!(obj is CodeStatementCollection))
			{
				return obj;
			}
			CodeExpression expression = GetExpression(manager, value);
			if (expression == null)
			{
				return obj;
			}
			/*OpCode not supported: LdMemberToken*/;
			IEnumerator enumerator = enumerable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					object current = enumerator.Current;
					string value2 = (string)current.GetType().GetProperty("Name").GetValue(current, new object[0]);
					object value3 = current.GetType().GetProperty("Value").GetValue(current, new object[0]);
					CodeMethodInvokeExpression value4 = new CodeMethodInvokeExpression(expression, "Add", new CodePrimitiveExpression(value2), new CodePrimitiveExpression(value3));
					((CodeStatementCollection)obj).Add(value4);
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
		return obj;
	}
}
