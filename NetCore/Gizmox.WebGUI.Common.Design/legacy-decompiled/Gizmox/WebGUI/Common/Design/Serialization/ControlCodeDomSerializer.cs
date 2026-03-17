using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class ControlCodeDomSerializer : CodeDomSerializer
{
	public override object Deserialize(IDesignerSerializationManager objManager, object objCodeObject)
	{
		ArrayList arrayList = null;
		if (objManager != null && objCodeObject != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			IContainer container = (IContainer)objManager.GetService(typeof(IContainer));
			if (container == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				arrayList = new ArrayList(container.Components.Count);
				IEnumerator enumerator = container.Components.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						IComponent component = (IComponent)enumerator.Current;
						if (!(component is IControl))
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						((IControl)component).SuspendLayout();
						arrayList.Add(component);
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
			object obj = null;
			try
			{
				CodeDomSerializer codeDomSerializer = (CodeDomSerializer)objManager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
				if (codeDomSerializer != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					NormalizeConvertibleCodeAssignments(objCodeObject);
					return codeDomSerializer.Deserialize(objManager, objCodeObject);
				}
				return null;
			}
			finally
			{
				if (arrayList == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					{
						IEnumerator enumerator2 = arrayList.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								/*OpCode not supported: LdMemberToken*/;
								((IControl)enumerator2.Current).ResumeLayout(blnPerformLayout: false);
							}
						}
						finally
						{
							IDisposable disposable2 = enumerator2 as IDisposable;
							if (disposable2 != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
			}
		}
		object paramName;
		if (objManager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			paramName = "objManager";
		}
		else
		{
			paramName = "objCodeObject";
		}
		throw new ArgumentNullException((string)paramName);
	}

	private void NormalizeConvertibleCodeAssignments(object objCodeObject)
	{
		if (!(objCodeObject is CodeStatementCollection codeStatementCollection))
		{
			return;
		}
		IEnumerator enumerator = codeStatementCollection.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!((CodeStatement)enumerator.Current is CodeAssignStatement codeAssignStatement))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(codeAssignStatement.Left is CodePropertyReferenceExpression { PropertyName: var propertyName }))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (propertyName == "BorderColor")
				{
					/*OpCode not supported: LdMemberToken*/;
					if (codeAssignStatement.Right is CodePropertyReferenceExpression { TargetObject: CodeTypeOfExpression targetObject } codePropertyReferenceExpression2 && targetObject.Type.BaseType == typeof(Color).FullName)
					{
						codeAssignStatement.Right = new CodeObjectCreateExpression("Gizmox.WebGUI.Forms.BorderColor", new CodePropertyReferenceExpression(targetObject, codePropertyReferenceExpression2.PropertyName));
					}
				}
				else if (propertyName == "BorderWidth")
				{
					/*OpCode not supported: LdMemberToken*/;
					if (codeAssignStatement.Right is CodePrimitiveExpression codePrimitiveExpression && codePrimitiveExpression.Value is int)
					{
						codeAssignStatement.Right = new CodeObjectCreateExpression("Gizmox.WebGUI.Forms.BorderWidth", codePrimitiveExpression);
					}
				}
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

	private bool HasMixedInheritedChildren(IControl parent)
	{
		bool flag = false;
		bool flag2 = false;
		IEnumerator enumerator = parent.Controls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes((IControl)enumerator.Current)[typeof(InheritanceAttribute)];
				if (inheritanceAttribute != null && inheritanceAttribute.InheritanceLevel != InheritanceLevel.NotInherited)
				{
					flag = true;
				}
				else
				{
					flag2 = true;
				}
				if (flag && flag2)
				{
					return true;
				}
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
		return false;
	}

	protected bool IsSuspendResumeRequired(IDesignerSerializationManager objManager, IControl objControl)
	{
		if (!(objManager.GetService(typeof(IDesignerHost)) is IDesignerHost designerHost))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (designerHost.RootComponent == objControl)
			{
				return true;
			}
			/*OpCode not supported: LdMemberToken*/;
			IEnumerator enumerator = objControl.Controls.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					IControl control = (IControl)enumerator.Current;
					if (control.Site == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						if (objControl.Site == null)
						{
							continue;
						}
						if (control.Site.Container != objControl.Site.Container)
						{
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(control)[typeof(InheritanceAttribute)];
						if (inheritanceAttribute != null)
						{
							if (inheritanceAttribute.InheritanceLevel != InheritanceLevel.InheritedReadOnly)
							{
								return true;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
					}
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
		return false;
	}

	public override object Serialize(IDesignerSerializationManager objManager, object value)
	{
		if (objManager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (value != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			CodeDomSerializer codeDomSerializer = (CodeDomSerializer)objManager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
			if (codeDomSerializer != null)
			{
				/*OpCode not supported: LdMemberToken*/;
				object obj = codeDomSerializer.Serialize(objManager, value);
				SerializeRegisteredTimers(objManager, obj as CodeStatementCollection, value);
				InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(value)[typeof(InheritanceAttribute)];
				InheritanceLevel inheritanceLevel = InheritanceLevel.NotInherited;
				if (inheritanceAttribute != null)
				{
					inheritanceLevel = inheritanceAttribute.InheritanceLevel;
				}
				if (inheritanceLevel != InheritanceLevel.InheritedReadOnly)
				{
					IDesignerHost designerHost = (IDesignerHost)objManager.GetService(typeof(IDesignerHost));
					if (designerHost == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(designerHost.RootComponent)["Localizable"];
						if (propertyDescriptor == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!(propertyDescriptor.PropertyType == typeof(bool)))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (!(bool)propertyDescriptor.GetValue(designerHost.RootComponent))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							SerializeControlHierarchy(objManager, designerHost, value);
						}
					}
					if (!(obj is CodeStatementCollection))
					{
						return obj;
					}
					/*OpCode not supported: LdMemberToken*/;
					if (IsSuspendResumeRequired(objManager, (IControl)value))
					{
						SerializeSuspendResume(objManager, (CodeStatementCollection)obj, value, "SuspendLayout");
						SerializeSuspendResume(objManager, (CodeStatementCollection)obj, value, "ResumeLayout");
					}
					if (!HasMixedInheritedChildren((IControl)value))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						SerializeZOrder(objManager, (CodeStatementCollection)obj, (IControl)value);
					}
				}
				return obj;
			}
			return null;
		}
		object paramName;
		if (objManager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			paramName = "objManager";
		}
		else
		{
			paramName = "value";
		}
		throw new ArgumentNullException((string)paramName);
	}

	private void SerializeRegisteredTimers(IDesignerSerializationManager objManager, CodeStatementCollection arrCodeStatementCollection, object objControl)
	{
		if (objManager == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (arrCodeStatementCollection == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (objControl == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (!(objManager.GetService(typeof(IDesignerHost)) is IDesignerHost designerHost))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (designerHost.RootComponent != objControl)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (designerHost.Container == null)
			{
				return;
			}
			List<CodeFieldReferenceExpression> list = new List<CodeFieldReferenceExpression>();
			{
				IEnumerator enumerator = designerHost.Container.Components.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						IComponent component = (IComponent)enumerator.Current;
						if (component.GetType().FullName == "Gizmox.WebGUI.Forms.Timer")
						{
							list.Add(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), objManager.GetName(component)));
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
			if (list.Count <= 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			CodePropertyReferenceExpression left = new CodePropertyReferenceExpression(SerializeToExpression(objManager, objControl), "RegisteredTimers");
			CodeArrayCreateExpression codeArrayCreateExpression = new CodeArrayCreateExpression("Gizmox.WebGUI.Forms.Timer", list.Count);
			codeArrayCreateExpression.Initializers.AddRange(list.ToArray());
			arrCodeStatementCollection.Add(new CodeAssignStatement(left, codeArrayCreateExpression));
		}
	}

	private void SerializeControlHierarchy(IDesignerSerializationManager objManager, IDesignerHost host, object value)
	{
		if (!(value is IControl control))
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		string text;
		if (control != host.RootComponent)
		{
			/*OpCode not supported: LdMemberToken*/;
			text = objManager.GetName(value);
			if (text == null)
			{
				return;
			}
		}
		else
		{
			text = "$this";
			IEnumerator enumerator = host.Container.Components.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					IComponent component = (IComponent)enumerator.Current;
					if (component is IControl)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (TypeDescriptor.GetAttributes(component).Contains(InheritanceAttribute.InheritedReadOnly))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string name = objManager.GetName(component);
					string assemblyQualifiedName = component.GetType().AssemblyQualifiedName;
					if (name == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					SerializeResourceInvariant(objManager, ">>" + name + ".Name", name);
					SerializeResourceInvariant(objManager, ">>" + name + ".Type", assemblyQualifiedName);
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
		SerializeResourceInvariant(objManager, ">>" + text + ".Name", objManager.GetName(value));
		SerializeResourceInvariant(objManager, ">>" + text + ".Type", control.GetType().AssemblyQualifiedName);
		IControl parent = control.Parent;
		if (parent == null)
		{
			return;
		}
		if (parent.Site == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		string text2;
		if (parent != host.RootComponent)
		{
			/*OpCode not supported: LdMemberToken*/;
			text2 = objManager.GetName(parent);
		}
		else
		{
			text2 = "$this";
		}
		if (text2 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			SerializeResourceInvariant(objManager, ">>" + text + ".Parent", text2);
		}
		for (int i = 0; i < parent.Controls.Count; i++)
		{
			/*OpCode not supported: LdMemberToken*/;
			if (parent.Controls[i] != control)
			{
				/*OpCode not supported: LdMemberToken*/;
				continue;
			}
			SerializeResourceInvariant(objManager, ">>" + text + ".ZOrder", i.ToString());
			break;
		}
	}

	private void SerializeSuspendResume(IDesignerSerializationManager objManager, CodeStatementCollection statements, object value, string methodName)
	{
		objManager.GetName(value);
		CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(SerializeToExpression(objManager, value), methodName);
		CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression();
		codeMethodInvokeExpression.Method = method;
		CodeExpressionStatement codeExpressionStatement = new CodeExpressionStatement(codeMethodInvokeExpression);
		if (!(methodName == "SuspendLayout"))
		{
			/*OpCode not supported: LdMemberToken*/;
			codeMethodInvokeExpression.Parameters.Add(new CodePrimitiveExpression(false));
			codeExpressionStatement.UserData["statement-ordering"] = "end";
		}
		else
		{
			codeExpressionStatement.UserData["statement-ordering"] = "begin";
		}
		statements.Add(codeExpressionStatement);
	}

	private void SerializeZOrder(IDesignerSerializationManager objManager, CodeStatementCollection statements, IControl control)
	{
		for (int num = control.Controls.Count - 1; num >= 0; num--)
		{
			/*OpCode not supported: LdMemberToken*/;
			IControl control2 = (IControl)control.Controls[num];
			if (control2 == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (control2.Site == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (control2.Site.Container != control.Site.Container)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (((InheritanceAttribute)TypeDescriptor.GetAttributes(control2)[typeof(InheritanceAttribute)]).InheritanceLevel == InheritanceLevel.InheritedReadOnly)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(new CodePropertyReferenceExpression(SerializeToExpression(objManager, control), "Controls"), "SetChildIndex");
				CodeMethodInvokeExpression obj = new CodeMethodInvokeExpression
				{
					Method = method
				};
				CodeExpression value = SerializeToExpression(objManager, control2);
				obj.Parameters.Add(value);
				obj.Parameters.Add(SerializeToExpression(objManager, 0));
				CodeExpressionStatement value2 = new CodeExpressionStatement(obj);
				statements.Add(value2);
			}
		}
	}
}
