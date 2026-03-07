#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace A
{
	internal class BC
	{
		internal static CodeCompileUnit Read(Stream objXamlStream, ZB objReaderSettings)
		{
			return Generate(YB.Read(objXamlStream, objReaderSettings), objReaderSettings);
		}

		internal static CodeCompileUnit Read(QB objDocumentNode, ZB objReaderSettings)
		{
			return Generate(objDocumentNode, objReaderSettings);
		}

		private static CodeCompileUnit Generate(QB objDocumentNode, ZB objReaderSettings)
		{
			CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
			CodeNamespace codeNamespace = new CodeNamespace(objDocumentNode.ClassNamespace);
			codeCompileUnit.Namespaces.Add(codeNamespace);
			CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration(objDocumentNode.ClassName);
			CodeAttributeDeclaration value = new CodeAttributeDeclaration(new CodeTypeReference("System.Serializable"));
			codeTypeDeclaration.CustomAttributes.Add(value);
			codeTypeDeclaration.IsPartial = false;
			if (string.IsNullOrEmpty(objDocumentNode.Inherits))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				codeTypeDeclaration.BaseTypes.Add(new CodeTypeReference(objDocumentNode.Inherits));
			}
			codeNamespace.Types.Add(codeTypeDeclaration);
			GenerateConstructor(objDocumentNode, codeTypeDeclaration);
			GenerateInitializeComponent(objDocumentNode, codeTypeDeclaration);
			return codeCompileUnit;
		}

		private static void GenerateConstructor(QB objDocumentNode, CodeTypeDeclaration objCodeType)
		{
			CodeConstructor codeConstructor = new CodeConstructor();
			codeConstructor.Attributes = MemberAttributes.Public;
			codeConstructor.Statements.Add(new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "InitializeComponent"));
			objCodeType.Members.Add(codeConstructor);
		}

		private static void GenerateInitializeComponent(QB objDocumentNode, CodeTypeDeclaration objCodeType)
		{
			CodeMemberMethod codeMemberMethod = new CodeMemberMethod();
			codeMemberMethod.Name = "InitializeComponent";
			objCodeType.Members.Add(codeMemberMethod);
			GenerateComponentVariables(objDocumentNode, codeMemberMethod);
			GenerateComponentFieldInitializations(objDocumentNode, codeMemberMethod);
			GenerateSuspendLayoutCalls(objDocumentNode, codeMemberMethod);
			GenerateSupportInitializationCalls(objDocumentNode, codeMemberMethod, "BeginInit");
			GenerateTypeMemberInitializations(objDocumentNode, codeMemberMethod);
			GenerateSupportInitializationCalls(objDocumentNode, codeMemberMethod, "EndInit");
			GenerateResumeLayoutCalls(objDocumentNode, codeMemberMethod);
			GenerateTypeMemberInitialization(codeMemberMethod, objDocumentNode.RootType, blnIsRootNode: true);
		}

		private static void GenerateResumeLayoutCalls(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod)
		{
			AC[] types = objDocumentNode.Types;
			for (int i = 0; i < types.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				AC aC = types[i];
				if (!aC.GenerateSuspendLayout)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					GenerateMethodCall(objIntializeComponentMethod, new CodeVariableReferenceExpression(aC.ID), "ResumeLayout");
				}
			}
			GenerateMethodCall(objIntializeComponentMethod, new CodeThisReferenceExpression(), "ResumeLayout");
		}

		private static void GenerateSuspendLayoutCalls(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod)
		{
			AC[] types = objDocumentNode.Types;
			foreach (AC aC in types)
			{
				if (!aC.GenerateSuspendLayout)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					GenerateMethodCall(objIntializeComponentMethod, new CodeVariableReferenceExpression(aC.ID), "SuspendLayout");
				}
			}
			GenerateMethodCall(objIntializeComponentMethod, new CodeThisReferenceExpression(), "SuspendLayout");
		}

		private static void GenerateTypeMemberInitializations(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod)
		{
			AC[] types = objDocumentNode.Types;
			for (int i = 0; i < types.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				AC objTypeNode = types[i];
				GenerateTypeMemberInitialization(objIntializeComponentMethod, objTypeNode, blnIsRootNode: false);
			}
		}

		private static void GenerateComponentFieldInitializations(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod)
		{
			AC[] types = objDocumentNode.Types;
			foreach (AC aC in types)
			{
				if (!aC.GenerateMember)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					GenerateFieldIntialization(objIntializeComponentMethod, aC);
				}
			}
		}

		private static void GenerateComponentVariables(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod)
		{
			AC[] types = objDocumentNode.Types;
			for (int i = 0; i < types.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				AC aC = types[i];
				if (aC.GenerateMember)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					GenerateVariableDeclarationAndIntialization(objIntializeComponentMethod, aC);
				}
			}
		}

		private static void GenerateSupportInitializationCalls(QB objDocumentNode, CodeMemberMethod objIntializeComponentMethod, string strMethodName)
		{
			AC[] types = objDocumentNode.Types;
			foreach (AC aC in types)
			{
				if (aC.State == WB.C)
				{
					if (!typeof(ISupportInitialize).IsAssignableFrom(aC.Type))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						GenerateSupportInitializationCall(objIntializeComponentMethod.Statements, new CodeVariableReferenceExpression(aC.ID), strMethodName);
					}
				}
			}
		}

		private static void GenerateSupportInitializationCall(CodeStatementCollection statements, CodeExpression valueExpression, string methodName)
		{
			CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(new CodeCastExpression(new CodeTypeReference(typeof(ISupportInitialize)), valueExpression), methodName);
			CodeExpressionStatement value = new CodeExpressionStatement(new CodeMethodInvokeExpression
			{
				Method = method
			});
			statements.Add(value);
		}

		private static void GenerateMethodCall(CodeMemberMethod objIntializeComponentMethod, CodeExpression objTargetObject, string strMethodName)
		{
			CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(objTargetObject, strMethodName);
			CodeExpressionStatement value = new CodeExpressionStatement(new CodeMethodInvokeExpression
			{
				Method = method
			});
			objIntializeComponentMethod.Statements.Add(value);
		}

		private static void GenerateTypeMemberInitialization(CodeMemberMethod objIntializeComponentMethod, AC objTypeNode, bool blnIsRootNode)
		{
			CodeCommentStatement value = new CodeCommentStatement($"\n{objTypeNode.ID}\n");
			objIntializeComponentMethod.Statements.Add(value);
			CodeExpression codeExpression = null;
			if (!blnIsRootNode)
			{
				/*OpCode not supported: LdMemberToken*/;
				codeExpression = new CodeVariableReferenceExpression(objTypeNode.ID);
			}
			else
			{
				codeExpression = new CodeThisReferenceExpression();
			}
			RB[] members = objTypeNode.Members;
			for (int i = 0; i < members.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				RB rB = members[i];
				if (rB.State != WB.C)
				{
					continue;
				}
				SB[] value2 = rB.Value;
				if (!rB.IsProperty)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!rB.IsEvent)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					if (value2.Length != 1)
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					string text = (string)value2[0].Value;
					if (string.IsNullOrEmpty(text))
					{
						/*OpCode not supported: LdMemberToken*/;
						continue;
					}
					CodeEventReferenceExpression codeEventReferenceExpression = new CodeEventReferenceExpression();
					codeEventReferenceExpression.TargetObject = codeExpression;
					codeEventReferenceExpression.EventName = rB.MemberName;
					CodeAttachEventStatement codeAttachEventStatement = new CodeAttachEventStatement();
					codeAttachEventStatement.Event = codeEventReferenceExpression;
					codeAttachEventStatement.Listener = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), text);
					objIntializeComponentMethod.Statements.Add(codeAttachEventStatement);
					continue;
				}
				CodePropertyReferenceExpression codePropertyReferenceExpression = new CodePropertyReferenceExpression();
				codePropertyReferenceExpression.TargetObject = codeExpression;
				codePropertyReferenceExpression.PropertyName = rB.MemberName;
				if (!rB.CanWrite)
				{
					if (rB.IsCollectionProperty)
					{
						SB[] array = value2;
						for (int j = 0; j < array.Length; j++)
						{
							/*OpCode not supported: LdMemberToken*/;
							SB objValue = array[j];
							CodeExpression valueCodeExpression = GetValueCodeExpression(rB, objValue);
							if (valueCodeExpression == null)
							{
								/*OpCode not supported: LdMemberToken*/;
								continue;
							}
							CodeMethodReferenceExpression method = new CodeMethodReferenceExpression(codePropertyReferenceExpression, "Add");
							CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression();
							codeMethodInvokeExpression.Method = method;
							codeMethodInvokeExpression.Parameters.Add(valueCodeExpression);
							objIntializeComponentMethod.Statements.Add(codeMethodInvokeExpression);
						}
						continue;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				if (!rB.CanWrite)
				{
					continue;
				}
				if (value2.Length == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				CodeExpression codeExpression2 = null;
				codeExpression2 = GetMemberValueForProperty(rB, value2);
				if (codeExpression2 == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				CodeAssignStatement codeAssignStatement = new CodeAssignStatement();
				codeAssignStatement.Left = codePropertyReferenceExpression;
				codeAssignStatement.Right = codeExpression2;
				objIntializeComponentMethod.Statements.Add(codeAssignStatement);
			}
			if (!objTypeNode.ImplementsIAddChild)
			{
				/*OpCode not supported: LdMemberToken*/;
				return;
			}
			AC[] children = objTypeNode.Children;
			for (int i = 0; i < children.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				AC aC = children[i];
				if (aC.State != WB.C)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				CodeMethodReferenceExpression method2 = new CodeMethodReferenceExpression(new CodeCastExpression(new CodeTypeReference(typeof(IAddChild)), codeExpression), "AddChild");
				CodeExpressionStatement value3 = new CodeExpressionStatement(new CodeMethodInvokeExpression
				{
					Method = method2,
					Parameters = { (CodeExpression)new CodeVariableReferenceExpression(aC.ID) }
				});
				objIntializeComponentMethod.Statements.Add(value3);
			}
		}

		private static CodeExpression GetMemberValueForProperty(RB objMemberNode, SB[] arrValues)
		{
			for (int i = 0; i < arrValues.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				CodeExpression codeExpression = null;
				codeExpression = GetValueCodeExpression(objMemberNode, arrValues[i]);
				if (codeExpression == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				return codeExpression;
			}
			return null;
		}

		private static CodeExpression GetValueCodeExpression(RB objMemberNode, SB objValue)
		{
			CodeExpression codeExpression = null;
			if (objValue.IsReference)
			{
				codeExpression = new CodeVariableReferenceExpression(objValue.ReferenceID);
			}
			else
			{
				PropertyInfo propertyInfo = objMemberNode.Member as PropertyInfo;
				if (!(propertyInfo != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					codeExpression = GenerateExpressionForValue(propertyInfo, objValue.Value, objValue.ValueType);
					if (codeExpression != null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (!objValue.IsPrimitive)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						codeExpression = new CodePrimitiveExpression(objValue.Value);
					}
				}
			}
			return codeExpression;
		}

		private static void GenerateFieldIntialization(CodeMemberMethod objIntializeComponentMethod, AC objTypeNode)
		{
			CodeAssignStatement codeAssignStatement = new CodeAssignStatement();
			codeAssignStatement.Left = new CodeVariableReferenceExpression(objTypeNode.ID);
			codeAssignStatement.Right = new CodeObjectCreateExpression(new CodeTypeReference(objTypeNode.Type));
			objIntializeComponentMethod.Statements.Add(codeAssignStatement);
		}

		private static void GenerateVariableDeclarationAndIntialization(CodeMemberMethod objIntializeComponentMethod, AC objTypeNode)
		{
			CodeVariableDeclarationStatement codeVariableDeclarationStatement = new CodeVariableDeclarationStatement(objTypeNode.Type, objTypeNode.ID);
			codeVariableDeclarationStatement.InitExpression = new CodeObjectCreateExpression(new CodeTypeReference(objTypeNode.Type));
			objIntializeComponentMethod.Statements.Add(codeVariableDeclarationStatement);
		}

		private static void GenerateTypeMembers(QB objDocumentNode, CodeTypeDeclaration objCodeType)
		{
			AC[] types = objDocumentNode.Types;
			for (int i = 0; i < types.Length; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				AC aC = types[i];
				if (!aC.GenerateMember)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objCodeType.Members.Add(new CodeMemberField(aC.Type, aC.ID));
				}
			}
		}

		internal static CodeExpression GenerateExpressionForValue(PropertyInfo objPropertyInfo, object objValue, Type objValueType)
		{
			CodeExpression result = null;
			if (!(objValueType == null))
			{
				/*OpCode not supported: LdMemberToken*/;
				PropertyDescriptor propertyDescriptor = null;
				if (!(objPropertyInfo != null))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					propertyDescriptor = TypeDescriptor.GetProperties(objPropertyInfo.ReflectedType)[objPropertyInfo.Name];
				}
				if (!(objValueType == typeof(string)))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (objValue is string)
				{
					return new CodePrimitiveExpression((string)objValue);
				}
				if (!objValueType.IsPrimitive)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!(objPropertyInfo == null))
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else if (objValueType == typeof(object) && (objValue == null || objValue.GetType().IsPrimitive))
					{
						return new CodePrimitiveExpression(objValue);
					}
					if (!objValueType.IsArray)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (!(objValueType == typeof(Type)))
						{
							/*OpCode not supported: LdMemberToken*/;
							TypeConverter typeConverter = null;
							if (propertyDescriptor == null)
							{
								/*OpCode not supported: LdMemberToken*/;
								typeConverter = TypeDescriptor.GetConverter(objValueType);
							}
							else
							{
								typeConverter = propertyDescriptor.Converter;
							}
							bool flag = false;
							if (typeConverter == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								InstanceDescriptor instanceDescriptor = null;
								if (typeConverter.CanConvertTo(typeof(InstanceDescriptor)))
								{
									instanceDescriptor = (InstanceDescriptor)typeConverter.ConvertTo(objValue, typeof(InstanceDescriptor));
								}
								if (instanceDescriptor != null)
								{
									if (instanceDescriptor.MemberInfo is FieldInfo)
									{
										result = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(instanceDescriptor.MemberInfo.DeclaringType.FullName), instanceDescriptor.MemberInfo.Name);
										flag = true;
									}
									else if (!(instanceDescriptor.MemberInfo is PropertyInfo))
									{
										/*OpCode not supported: LdMemberToken*/;
										object[] array = new object[instanceDescriptor.Arguments.Count];
										instanceDescriptor.Arguments.CopyTo(array, 0);
										CodeExpression[] array2 = new CodeExpression[array.Length];
										if (!(instanceDescriptor.MemberInfo is MethodInfo))
										{
											/*OpCode not supported: LdMemberToken*/;
											if (!(instanceDescriptor.MemberInfo is ConstructorInfo))
											{
												/*OpCode not supported: LdMemberToken*/;
											}
											else
											{
												ParameterInfo[] parameters = ((ConstructorInfo)instanceDescriptor.MemberInfo).GetParameters();
												for (int i = 0; i < array.Length; i++)
												{
													/*OpCode not supported: LdMemberToken*/;
													array2[i] = GenerateExpressionForValue(null, array[i], parameters[i].ParameterType);
												}
												CodeObjectCreateExpression codeObjectCreateExpression = new CodeObjectCreateExpression(instanceDescriptor.MemberInfo.DeclaringType.FullName);
												CodeExpression[] array3 = array2;
												foreach (CodeExpression value in array3)
												{
													codeObjectCreateExpression.Parameters.Add(value);
												}
												result = codeObjectCreateExpression;
												flag = true;
											}
										}
										else
										{
											ParameterInfo[] parameters2 = ((MethodInfo)instanceDescriptor.MemberInfo).GetParameters();
											for (int k = 0; k < array.Length; k++)
											{
												/*OpCode not supported: LdMemberToken*/;
												array2[k] = GenerateExpressionForValue(null, array[k], parameters2[k].ParameterType);
											}
											CodeMethodInvokeExpression codeMethodInvokeExpression = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(instanceDescriptor.MemberInfo.DeclaringType.FullName), instanceDescriptor.MemberInfo.Name);
											CodeExpression[] array3 = array2;
											for (int j = 0; j < array3.Length; j++)
											{
												/*OpCode not supported: LdMemberToken*/;
												CodeExpression value2 = array3[j];
												codeMethodInvokeExpression.Parameters.Add(value2);
											}
											result = new CodeCastExpression(objValueType, codeMethodInvokeExpression);
											flag = true;
										}
									}
									else
									{
										result = new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(instanceDescriptor.MemberInfo.DeclaringType.FullName), instanceDescriptor.MemberInfo.Name);
										flag = true;
									}
								}
							}
							if (flag)
							{
								return result;
							}
							if (!(objValueType.GetMethod("Parse", new Type[2]
							{
								typeof(string),
								typeof(CultureInfo)
							}) != null))
							{
								/*OpCode not supported: LdMemberToken*/;
								if (!(objValueType.GetMethod("Parse", new Type[1] { typeof(string) }) == null))
								{
									/*OpCode not supported: LdMemberToken*/;
									return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(objValueType.FullName), "Parse")
									{
										Parameters = { (CodeExpression)new CodePrimitiveExpression(objValue.ToString()) }
									};
								}
								return null;
							}
							CodeMethodInvokeExpression codeMethodInvokeExpression2 = new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(objValueType.FullName), "Parse");
							string value3 = ((typeConverter == null) ? objValue.ToString() : typeConverter.ConvertToInvariantString(objValue));
							codeMethodInvokeExpression2.Parameters.Add(new CodePrimitiveExpression(value3));
							codeMethodInvokeExpression2.Parameters.Add(new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(CultureInfo)), "InvariantCulture"));
							return codeMethodInvokeExpression2;
						}
						return new CodeTypeOfExpression((Type)objValue);
					}
					Array array4 = (Array)objValue;
					CodeArrayCreateExpression codeArrayCreateExpression = new CodeArrayCreateExpression();
					codeArrayCreateExpression.CreateType = new CodeTypeReference(objValueType.GetElementType());
					if (array4 == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						{
							IEnumerator enumerator = array4.GetEnumerator();
							try
							{
								while (enumerator.MoveNext())
								{
									/*OpCode not supported: LdMemberToken*/;
									object current = enumerator.Current;
									codeArrayCreateExpression.Initializers.Add(GenerateExpressionForValue(null, current, objValueType.GetElementType()));
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
					}
					return codeArrayCreateExpression;
				}
				return new CodePrimitiveExpression(objValue);
			}
			throw new ArgumentNullException("valueType");
		}
	}
}
