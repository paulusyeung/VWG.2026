using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using A;

namespace Gizmox.WebGUI.Common.Design.Serialization;

public class CollectionCodeDomSerializer : CodeDomSerializer
{
	private static CollectionCodeDomSerializer c5407c8926f0172471b65669e75292e21;

	public static CollectionCodeDomSerializer Default
	{
		get
		{
			if (c5407c8926f0172471b65669e75292e21 == null)
			{
				c5407c8926f0172471b65669e75292e21 = new CollectionCodeDomSerializer();
			}
			return c5407c8926f0172471b65669e75292e21;
		}
	}

	protected virtual bool PreferAddRange => true;

	public override object Deserialize(IDesignerSerializationManager manager, object codeObject)
	{
		return null;
	}

	private ICollection GetCollectionDelta(ICollection original, ICollection modified)
	{
		if (original == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (modified != null && original.Count != 0)
		{
			IEnumerator enumerator = modified.GetEnumerator();
			if (enumerator != null)
			{
				IDictionary dictionary = new HybridDictionary();
				foreach (object item in original)
				{
					if (!dictionary.Contains(item))
					{
						/*OpCode not supported: LdMemberToken*/;
						dictionary.Add(item, 1);
					}
					else
					{
						int num = (int)dictionary[item];
						dictionary[item] = ++num;
					}
				}
				ArrayList arrayList = null;
				for (int i = 0; i < modified.Count; i++)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					object current2 = enumerator.Current;
					if (dictionary.Contains(current2))
					{
						if (arrayList == null)
						{
							arrayList = new ArrayList();
							enumerator.Reset();
							for (int j = 0; j < i; j++)
							{
								if (!enumerator.MoveNext())
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								arrayList.Add(enumerator.Current);
							}
							enumerator.MoveNext();
						}
						int num2 = (int)dictionary[current2];
						if (--num2 != 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							dictionary[current2] = num2;
						}
						else
						{
							dictionary.Remove(current2);
						}
					}
					else
					{
						arrayList?.Add(current2);
					}
				}
				if (arrayList != null)
				{
					return arrayList;
				}
			}
		}
		return modified;
	}

	public override object Serialize(IDesignerSerializationManager manager, object value)
	{
		object result = null;
		object obj = manager.Context.Current;
		if (!(obj is ExpressionContext expressionContext))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			obj = expressionContext.Expression;
		}
		if (obj != null)
		{
			Type type = obj.GetType();
			if (!(type.Name == "CodeValueExpression"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				CodeExpression expression = (CodeExpression)type.InvokeMember("Expression", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, obj, null);
				object value2 = type.InvokeMember("Value", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, obj, null);
				Type t = (Type)type.InvokeMember("ExpressionType", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, obj, null);
				cb61326e3535b3ff39f7574e41092b768 cb61326e3535b3ff39f7574e41092b = new cb61326e3535b3ff39f7574e41092b768(expression, value2, t);
				if (cb61326e3535b3ff39f7574e41092b.Value != value)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					obj = cb61326e3535b3ff39f7574e41092b.Expression;
				}
			}
		}
		if (!(obj is CodePropertyReferenceExpression))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (!(value is Array))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = SerializeArray(manager, null, null, (Array)value, null);
			}
			return result;
		}
		if (!(value is ICollection))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			CodePropertyReferenceExpression codePropertyReferenceExpression = (CodePropertyReferenceExpression)obj;
			object obj2 = DeserializeExpression(manager, null, codePropertyReferenceExpression.TargetObject);
			if (obj2 == null)
			{
				return result;
			}
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(obj2)[codePropertyReferenceExpression.PropertyName];
			if (propertyDescriptor == null)
			{
				return result;
			}
			Type propertyType = propertyDescriptor.PropertyType;
			if (typeof(Array).IsAssignableFrom(propertyType))
			{
				return SerializeArray(manager, codePropertyReferenceExpression, propertyType.GetElementType(), (Array)value, obj2);
			}
			/*OpCode not supported: LdMemberToken*/;
			MethodInfo[] methods = propertyType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
			MethodInfo methodInfo = null;
			MethodInfo methodInfo2 = null;
			ParameterInfo[] array = null;
			MethodInfo[] array2 = methods;
			foreach (MethodInfo methodInfo3 in array2)
			{
				if (!methodInfo3.Name.Equals("AddRange"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					array = methodInfo3.GetParameters();
					if (array.Length == 1 && array[0].ParameterType.IsArray)
					{
						methodInfo = methodInfo3;
						if (PreferAddRange)
						{
							/*OpCode not supported: LdMemberToken*/;
							break;
						}
					}
				}
				if (!methodInfo3.Name.Equals("Add"))
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				array = methodInfo3.GetParameters();
				if (array.Length != 1)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				methodInfo2 = methodInfo3;
				if (!PreferAddRange)
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
			}
			if (!PreferAddRange)
			{
				if (!(methodInfo != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!(methodInfo2 != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					methodInfo = null;
				}
			}
			if (methodInfo != null)
			{
				return SerializeViaAddRange(manager, codePropertyReferenceExpression, (ICollection)value, methodInfo, array[0], obj2);
			}
			if (!(methodInfo2 != null))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = SerializeViaAdd(manager, codePropertyReferenceExpression, (ICollection)value, methodInfo2, array[0], obj2);
			}
		}
		return result;
	}

	private object SerializeArray(IDesignerSerializationManager manager, CodePropertyReferenceExpression propRef, Type asType, Array array, object targetObject)
	{
		object result = null;
		if (array.Rank == 1)
		{
			/*OpCode not supported: LdMemberToken*/;
			Type type = null;
			if (!(asType != null))
			{
				/*OpCode not supported: LdMemberToken*/;
				type = array.GetType().GetElementType();
			}
			else
			{
				type = asType;
			}
			CodeTypeReference createType = new CodeTypeReference(type);
			CodeArrayCreateExpression codeArrayCreateExpression = new CodeArrayCreateExpression();
			codeArrayCreateExpression.CreateType = createType;
			bool flag = true;
			ICollection collection = array;
			bool flag2 = false;
			if (targetObject is IComponent component)
			{
				InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(component)[typeof(InheritanceAttribute)];
				int num;
				if (inheritanceAttribute == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					num = 0;
				}
				else
				{
					num = ((inheritanceAttribute.InheritanceLevel == InheritanceLevel.Inherited) ? 1 : 0);
				}
				flag2 = (byte)num != 0;
			}
			if (!flag2)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(manager.Context[typeof(PropertyDescriptor)] is PropertyDescriptor propertyDescriptor))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Type type2 = propertyDescriptor.GetType();
				if (!(type2.Name == "InheritedPropertyDescriptor"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object obj = type2.InvokeMember("OriginalValue", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, propertyDescriptor, null);
					collection = GetCollectionDelta(obj as ICollection, array);
				}
			}
			cb61326e3535b3ff39f7574e41092b768 context = new cb61326e3535b3ff39f7574e41092b768(null, collection, type);
			manager.Context.Push(context);
			try
			{
				IEnumerator enumerator = collection.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						object current = enumerator.Current;
						if (current is IComponent)
						{
							if (TypeDescriptor.GetAttributes(current).Contains(InheritanceAttribute.InheritedReadOnly))
							{
								flag = false;
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
						}
						object obj2 = SerializeToExpression(manager, current);
						if (obj2 is CodeExpression)
						{
							codeArrayCreateExpression.Initializers.Add((CodeExpression)obj2);
							continue;
						}
						flag = false;
						break;
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
			finally
			{
				manager.Context.Pop();
			}
			if (flag)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (propRef == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return codeArrayCreateExpression;
				}
				return new CodeAssignStatement(propRef, codeArrayCreateExpression);
			}
			return result;
		}
		(new object[1])[0] = array.Rank.ToString();
		manager.ReportError("SerializerInvalidArrayRank");
		return result;
	}

	private object SerializeViaAdd(IDesignerSerializationManager manager, CodePropertyReferenceExpression propRef, ICollection collection, MethodInfo addMethod, ParameterInfo parameter, object targetObject)
	{
		CodeStatementCollection codeStatementCollection = new CodeStatementCollection();
		CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(propRef, addMethod.Name);
		if (!(collection.GetType().GetMethod("Clear", new Type[0]) != null))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (manager.Properties["ClearCollections"] == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			codeStatementCollection.Add(new CodeMethodInvokeExpression(propRef, "Clear"));
		}
		if (manager.Context[typeof(PropertyDescriptor)] is PropertyDescriptor propertyDescriptor)
		{
			Type type = propertyDescriptor.GetType();
			if (!(type.Name == "InheritedPropertyDescriptor"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				object obj = type.InvokeMember("OriginalValue", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, propertyDescriptor, null);
				collection = GetCollectionDelta(obj as ICollection, collection);
				if (collection.Count == 0)
				{
					return codeStatementCollection;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
		}
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = collection.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				bool flag = false;
				if (!(current is IComponent))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!(current is IComponent component))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (component.Site == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(current)[typeof(InheritanceAttribute)];
					if (inheritanceAttribute == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						flag = true;
					}
					else
					{
						flag = inheritanceAttribute.InheritanceLevel != InheritanceLevel.InheritedReadOnly;
					}
				}
				if (flag)
				{
					CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression();
					codeMethodInvokeExpression.Method = method;
					cb61326e3535b3ff39f7574e41092b768 context = new cb61326e3535b3ff39f7574e41092b768(null, current, parameter.ParameterType);
					manager.Context.Push(context);
					CodeExpression codeExpression = null;
					try
					{
						codeExpression = SerializeToExpression(manager, current);
					}
					finally
					{
						manager.Context.Pop();
					}
					if (codeExpression == null)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					codeMethodInvokeExpression.Parameters.Add(codeExpression);
					arrayList.Add(codeMethodInvokeExpression);
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
		if (!UseCollectionReversing(collection))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			arrayList.Reverse();
		}
		enumerator = arrayList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				/*OpCode not supported: LdMemberToken*/;
				CodeMethodInvokeExpression value = (CodeMethodInvokeExpression)enumerator.Current;
				codeStatementCollection.Add(value);
			}
			return codeStatementCollection;
		}
		finally
		{
			if (!(enumerator is IDisposable disposable2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	private object SerializeViaAddRange(IDesignerSerializationManager manager, CodePropertyReferenceExpression propRef, ICollection collection, MethodInfo addRangeMethod, ParameterInfo parameter, object targetObject)
	{
		CodeStatementCollection codeStatementCollection = new CodeStatementCollection();
		if (!(collection.GetType().GetMethod("Clear", new Type[0]) != null))
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			PropertyDescriptor propertyDescriptor = manager.Properties["ClearCollections"];
			if (propertyDescriptor == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(propertyDescriptor.PropertyType == typeof(bool)))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (!(bool)propertyDescriptor.GetValue(manager))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				codeStatementCollection.Add(new CodeMethodInvokeExpression(propRef, "Clear"));
			}
		}
		if (collection.Count == 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			ArrayList arrayList = new ArrayList(collection.Count);
			bool flag = false;
			if (!(manager.Context[typeof(PropertyDescriptor)] is PropertyDescriptor propertyDescriptor2))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Type type = propertyDescriptor2.GetType();
				if (!(type.Name == "InheritedPropertyDescriptor"))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					object obj = type.InvokeMember("OriginalValue", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty, null, propertyDescriptor2, null);
					flag = true;
					collection = GetCollectionDelta(obj as ICollection, collection);
					if (collection.Count == 0)
					{
						return codeStatementCollection;
					}
				}
			}
			cb61326e3535b3ff39f7574e41092b768 context = new cb61326e3535b3ff39f7574e41092b768(null, collection, parameter.ParameterType.GetElementType());
			manager.Context.Push(context);
			try
			{
				IEnumerator enumerator = collection.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						object current = enumerator.Current;
						bool flag2 = false;
						if (!(current is IComponent))
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							if (!(current is IComponent component))
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else if (component.Site == null)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							InheritanceAttribute inheritanceAttribute = (InheritanceAttribute)TypeDescriptor.GetAttributes(current)[typeof(InheritanceAttribute)];
							if (inheritanceAttribute != null)
							{
								if (inheritanceAttribute.InheritanceLevel != InheritanceLevel.InheritedReadOnly)
								{
									/*OpCode not supported: LdMemberToken*/;
									if (!(inheritanceAttribute.InheritanceLevel == InheritanceLevel.Inherited && flag))
									{
										/*OpCode not supported: LdMemberToken*/;
										flag2 = true;
									}
									else
									{
										flag2 = false;
									}
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
							/*OpCode not supported: LdMemberToken*/;
							continue;
						}
						CodeExpression codeExpression = SerializeToExpression(manager, current);
						if (codeExpression == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							arrayList.Add(codeExpression);
						}
					}
				}
				finally
				{
					IDisposable disposable2 = enumerator as IDisposable;
					if (disposable2 != null)
					{
						disposable2.Dispose();
					}
				}
			}
			finally
			{
				manager.Context.Pop();
			}
			if (UseCollectionReversing(collection))
			{
				arrayList.Reverse();
			}
			if (arrayList.Count <= 0)
			{
				return codeStatementCollection;
			}
			/*OpCode not supported: LdMemberToken*/;
			CodeTypeReference createType = new CodeTypeReference(parameter.ParameterType.GetElementType());
			CodeArrayCreateExpression codeArrayCreateExpression = new CodeArrayCreateExpression();
			codeArrayCreateExpression.CreateType = createType;
			IEnumerator enumerator2 = arrayList.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					/*OpCode not supported: LdMemberToken*/;
					CodeExpression value = (CodeExpression)enumerator2.Current;
					codeArrayCreateExpression.Initializers.Add(value);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					disposable.Dispose();
				}
			}
			CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(propRef, addRangeMethod.Name);
			CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression();
			codeMethodInvokeExpression.Method = method;
			codeMethodInvokeExpression.Parameters.Add(codeArrayCreateExpression);
			codeStatementCollection.Add(new CodeExpressionStatement(codeMethodInvokeExpression));
		}
		return codeStatementCollection;
	}

	protected virtual bool UseCollectionReversing(ICollection objCollection)
	{
		return false;
	}
}
