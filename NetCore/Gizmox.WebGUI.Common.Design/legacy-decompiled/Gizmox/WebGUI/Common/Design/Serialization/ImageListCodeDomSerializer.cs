using System;
using System.CodeDom;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class ImageListCodeDomSerializer : CodeDomSerializer
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
		if (manager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (value != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
			if (codeDomSerializer == null)
			{
				return null;
			}
			object obj = codeDomSerializer.Serialize(manager, value);
			if (value != null)
			{
				object obj2 = value.GetType().InvokeMember("Images", BindingFlags.GetProperty, null, value, new object[0]);
				if (obj2 != null)
				{
					if (!(obj2.GetType().InvokeMember("Keys", BindingFlags.GetProperty, null, obj2, new object[0]) is StringCollection stringCollection))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (!(obj is CodeStatementCollection))
						{
							return obj;
						}
						/*OpCode not supported: LdMemberToken*/;
						CodeExpression expression = GetExpression(manager, value);
						if (expression == null)
						{
							return obj;
						}
						/*OpCode not supported: LdMemberToken*/;
						CodeExpression codeExpression = new CodePropertyReferenceExpression(expression, "Images");
						if (codeExpression == null)
						{
							return obj;
						}
						/*OpCode not supported: LdMemberToken*/;
						for (int i = 0; i < stringCollection.Count; i++)
						{
							/*OpCode not supported: LdMemberToken*/;
							if (stringCollection[i] != null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (stringCollection[i].Length == 0)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							CodeMethodInvokeExpression value2 = new CodeMethodInvokeExpression(codeExpression, "SetKeyName", new CodePrimitiveExpression(i), new CodePrimitiveExpression(stringCollection[i]));
							((CodeStatementCollection)obj).Add(value2);
						}
					}
				}
			}
			return obj;
		}
		object paramName;
		if (manager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			paramName = "manager";
		}
		else
		{
			paramName = "value";
		}
		throw new ArgumentNullException((string)paramName);
	}
}
