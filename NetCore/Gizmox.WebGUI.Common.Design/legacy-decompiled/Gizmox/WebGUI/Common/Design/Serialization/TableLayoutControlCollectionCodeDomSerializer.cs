using System;
using System.CodeDom;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class TableLayoutControlCollectionCodeDomSerializer : System.ComponentModel.Design.Serialization.CollectionCodeDomSerializer
{
	protected override object SerializeCollection(IDesignerSerializationManager manager, CodeExpression targetExpression, Type targetType, ICollection originalCollection, ICollection valuesToSerialize)
	{
		CodeStatementCollection codeStatementCollection = new CodeStatementCollection();
		CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(targetExpression, "Add");
		if (valuesToSerialize.Count > 0)
		{
			if (originalCollection == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				bool flag = false;
				if (!(manager.Context[typeof(ExpressionContext)] is ExpressionContext expressionContext))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (expressionContext.Expression != targetExpression)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(expressionContext.Owner is IComponent component))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(component)[typeof(InheritanceAttribute)];
					flag = inheritanceAttribute != null && inheritanceAttribute.InheritanceLevel == InheritanceLevel.Inherited;
				}
				IEnumerator enumerator = valuesToSerialize.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						object current = enumerator.Current;
						bool flag2 = !(current is IComponent);
						if (flag2)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							InheritanceAttribute inheritanceAttribute2 = (InheritanceAttribute)TypeDescriptor.GetAttributes(current)[typeof(InheritanceAttribute)];
							if (inheritanceAttribute2 != null)
							{
								if (inheritanceAttribute2.InheritanceLevel != InheritanceLevel.InheritedReadOnly)
								{
									/*OpCode not supported: LdMemberToken*/;
									flag2 = !(inheritanceAttribute2.InheritanceLevel == InheritanceLevel.Inherited && flag);
								}
								else
								{
									flag2 = false;
								}
							}
							else
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							continue;
						}
						CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression();
						codeMethodInvokeExpression.Method = method;
						CodeExpression codeExpression = SerializeToExpression(manager, current);
						if (codeExpression == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (Config.GetFormsAssembly().GetType("Gizmox.WebGUI.Forms.Control").IsAssignableFrom(current.GetType()))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							codeExpression = new CodeCastExpression(Config.GetFormsAssembly().GetType("Gizmox.WebGUI.Forms.Control"), codeExpression);
						}
						if (codeExpression == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						object obj = originalCollection.GetType().InvokeMember("Owner", BindingFlags.GetProperty, null, originalCollection, null);
						if (obj == null)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						int num = Convert.ToInt32(obj.GetType().InvokeMember("GetColumn", BindingFlags.InvokeMethod, null, obj, new object[1] { current }));
						int num2 = Convert.ToInt32(obj.GetType().InvokeMember("GetRow", BindingFlags.InvokeMethod, null, obj, new object[1] { current }));
						codeMethodInvokeExpression.Parameters.Add(codeExpression);
						if (num != -1)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (num2 == -1)
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_02d7;
						}
						codeMethodInvokeExpression.Parameters.Add(new CodePrimitiveExpression(num));
						codeMethodInvokeExpression.Parameters.Add(new CodePrimitiveExpression(num2));
						goto IL_02d7;
						IL_02d7:
						codeStatementCollection.Add(codeMethodInvokeExpression);
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
		}
		return codeStatementCollection;
	}
}
