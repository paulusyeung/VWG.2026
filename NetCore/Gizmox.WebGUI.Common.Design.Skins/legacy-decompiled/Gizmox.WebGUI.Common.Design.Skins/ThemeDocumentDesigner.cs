using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using EnvDTE;
using Gizmox.WebGUI.Common.Design.Skins.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins;

public class ThemeDocumentDesigner : DocumentDesinger
{
	private delegate object GetValueDelegate(object objControl, object[] arrIndex);

	private delegate object InvokeMethodDelegate(object objControl, object[] arrParams);

	private Type mobjSkinContainerAttributeType;

	private List<Type> mobjSkinTypes;

	private Type mobjSkinVisibilityAttributeType;

	private const string mstrThemeDataFileName = "theme.data";

	private const string mcntPropertyIdetifier = "~VwgProp~";

	public Type SkinContainerAttributeType
	{
		get
		{
			if (mobjSkinContainerAttributeType == null)
			{
				mobjSkinContainerAttributeType = DocumentUtils.InvokeMethod(base.Component, "GetSkinType", "SkinContainerAttribute") as Type;
			}
			return mobjSkinContainerAttributeType;
		}
	}

	public List<Type> SkinTypes => mobjSkinTypes;

	public Type SkinVisibilityAttributeType
	{
		get
		{
			if (mobjSkinVisibilityAttributeType == null)
			{
				mobjSkinVisibilityAttributeType = DocumentUtils.InvokeMethod(base.Component, "GetSkinType", "SkinVisibilityAttribute") as Type;
			}
			return mobjSkinVisibilityAttributeType;
		}
	}

	internal event ProgressChangedDelegate ProgressChanged;

	internal event ProcessCompletedDelegate ProcessCompleted;

	public ThemeDocumentDesigner()
	{
		mobjSkinTypes = new List<Type>();
	}

	private void OnProgressChanged(int intValue, int intMinimum, int intMaximum)
	{
		if (this.ProgressChanged != null)
		{
			this.ProgressChanged(this, new ProgressChangedArgs(intValue, intMinimum, intMaximum));
		}
	}

	private void OnProcessCompleted(bool blnChangesApplied)
	{
		if (this.ProcessCompleted != null)
		{
			this.ProcessCompleted(this, new ProcessCompletedArgs(blnChangesApplied));
		}
	}

	public void ExportResources(string strExportPath, string[] arrResourceTypes)
	{
		if (!string.IsNullOrEmpty(strExportPath) && arrResourceTypes != null && arrResourceTypes.Length != 0 && SkinTypes != null && SkinTypes.Count > 0)
		{
			List<string> propertyResourceTypes = GetPropertyResourceTypes(arrResourceTypes);
			List<string> list = new List<string>(arrResourceTypes);
			if (list != null && list.Count > 0)
			{
				OnProgressChanged(0, 0, SkinTypes.Count - 1);
			}
			foreach (Type skinType in SkinTypes)
			{
				IComponent skinInstance = GetSkinInstance(skinType);
				if (skinInstance != null)
				{
					if (propertyResourceTypes.Count > 0 && InvokeControlMethod(base.Frame, "GetSkinValueResources", new object[1] { skinInstance }) is IEnumerable enumerable)
					{
						foreach (object item in enumerable)
						{
							Type type = item.GetType();
							PropertyInfo property = type.GetProperty("Key");
							if (!(property != null))
							{
								continue;
							}
							object value = property.GetValue(item, new object[0]);
							if (value == null)
							{
								continue;
							}
							string text = Convert.ToString(value);
							if (string.IsNullOrEmpty(text))
							{
								continue;
							}
							PropertyInfo propertyFromResourceKey = GetPropertyFromResourceKey(skinType, text);
							if (!(propertyFromResourceKey != null) || !propertyResourceTypes.Contains(propertyFromResourceKey.PropertyType.FullName))
							{
								continue;
							}
							PropertyInfo property2 = type.GetProperty("Value");
							if (property2 != null && DocumentUtils.IsVisible(property2))
							{
								object value2 = property2.GetValue(item, new object[0]);
								if (value2 != null)
								{
									WriteValueResource(skinType, propertyFromResourceKey.PropertyType, text, value2, strExportPath);
								}
							}
						}
					}
					if (DocumentUtils.GetPropertyValue(skinInstance, "Resources") is IEnumerable enumerable2)
					{
						foreach (object item2 in enumerable2)
						{
							if (item2 == null)
							{
								continue;
							}
							PropertyInfo property3 = item2.GetType().GetProperty("Value");
							if (!(property3 != null))
							{
								continue;
							}
							object value3 = property3.GetValue(item2, new object[0]);
							if (value3 != null)
							{
								Type type2 = value3.GetType();
								if (list.Contains(type2.Name))
								{
									WriteFileResource(value3, strExportPath, DocumentUtils.IsInherited(skinInstance, value3));
								}
							}
						}
					}
				}
				OnProgressChanged(SkinTypes.IndexOf(skinType), -1, -1);
			}
			UpdateThemeDataFile(strExportPath);
		}
		OnProcessCompleted(blnChangesApplied: true);
	}

	private PropertyInfo GetPropertyFromResourceKey(Type objSkinType, string strSkinResourceKey)
	{
		PropertyInfo propertyInfo = null;
		if (objSkinType != null && !string.IsNullOrEmpty(strSkinResourceKey))
		{
			string[] array = strSkinResourceKey.Split('.');
			if (array.Length != 0)
			{
				propertyInfo = objSkinType.GetProperty(array[0]);
				if (propertyInfo != null && array.Length > 1)
				{
					return GetPropertyFromResourceKey(propertyInfo.PropertyType, string.Join(".", array, 1, array.Length - 1));
				}
			}
		}
		return propertyInfo;
	}

	public object GetControlProperty(Control objControl, string strPropertyName)
	{
		Delegate method = new GetValueDelegate(objControl.GetType().GetProperty(strPropertyName).GetValue);
		return objControl.Invoke(method, objControl, null);
	}

	public object InvokeControlMethod(Control objControl, string strMethodName, object[] arrParams)
	{
		Delegate method = new InvokeMethodDelegate(objControl.GetType().GetMethod(strMethodName).Invoke);
		return objControl.Invoke(method, objControl, arrParams);
	}

	private List<string> GetPropertyResourceTypes(string[] arrResourceTypes)
	{
		List<string> list = new List<string>();
		foreach (string text in arrResourceTypes)
		{
			if (text.StartsWith("Property::"))
			{
				list.AddRange(text.Replace("Property::", string.Empty).Split(','));
			}
		}
		return list;
	}

	private bool ImportValueResource(FileInfo objResourceFileInfo)
	{
		bool result = false;
		if (objResourceFileInfo != null)
		{
			string text = string.Empty;
			string strSkinName = string.Empty;
			string text2 = objResourceFileInfo.Name;
			int num = text2.LastIndexOf(objResourceFileInfo.Extension);
			if (num != -1)
			{
				text2 = text2.Substring(0, num);
			}
			int num2 = text2.IndexOf("~VwgProp~");
			if (num2 != -1)
			{
				text = text2.Substring(num2 + "~VwgProp~".Length);
				strSkinName = text2.Substring(0, num2);
			}
			if (!string.IsNullOrEmpty(strSkinName) && !string.IsNullOrEmpty(text))
			{
				Type type = SkinTypes.Find((Type objType) => objType.Name == strSkinName);
				if (type != null)
				{
					IComponent skinInstance = GetSkinInstance(type);
					if (skinInstance != null && !string.IsNullOrEmpty(text) && DocumentUtils.GetPropertyValue(skinInstance, "ValueResources") is IEnumerable enumerable)
					{
						foreach (object item in enumerable)
						{
							if (item == null)
							{
								continue;
							}
							Type type2 = item.GetType();
							PropertyInfo property = type2.GetProperty("Key");
							if (!(property != null))
							{
								continue;
							}
							object value = property.GetValue(item, new object[0]);
							if (value == null || !(text == Convert.ToString(value)))
							{
								continue;
							}
							PropertyInfo property2 = type2.GetProperty("Value");
							if (!(property2 != null))
							{
								continue;
							}
							object value2 = property2.GetValue(item, new object[0]);
							if (value2 != null)
							{
								PropertyInfo propertyFromResourceKey = GetPropertyFromResourceKey(type, text);
								if (propertyFromResourceKey != null)
								{
									OverrideValueResource(objResourceFileInfo.FullName, value2, skinInstance, propertyFromResourceKey.PropertyType);
									result = true;
									break;
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	private bool ImportFileResource(FileInfo objResourceFileInfo)
	{
		bool result = false;
		if (objResourceFileInfo != null)
		{
			string[] array = objResourceFileInfo.Name.Split('.');
			if (array != null && array.Length != 0)
			{
				string strComponentName = array[0];
				if (!string.IsNullOrEmpty(strComponentName))
				{
					Type type = SkinTypes.Find((Type objType) => objType.Name == strComponentName);
					if (type != null)
					{
						IComponent skinInstance = GetSkinInstance(type);
						if (skinInstance != null && DocumentUtils.GetPropertyValue(skinInstance, "Resources") is IEnumerable enumerable)
						{
							foreach (object item in enumerable)
							{
								if (item == null)
								{
									continue;
								}
								PropertyInfo property = item.GetType().GetProperty("Value");
								if (!(property != null))
								{
									continue;
								}
								object value = property.GetValue(item, new object[0]);
								if (value != null && DocumentUtils.IsVisible(value))
								{
									string text = DocumentUtils.GetPropertyValue(value, "FileName", string.Empty);
									if (!DocumentUtils.IsInherited(skinInstance, value))
									{
										text = GetResourceInheritedName(text);
									}
									if (objResourceFileInfo.Name == text)
									{
										OverrideFileResource(objResourceFileInfo.FullName, skinInstance, value);
										result = true;
										break;
									}
								}
							}
						}
					}
				}
			}
		}
		return result;
	}

	public void ImportResources(string strImportPath)
	{
		bool blnChangesApplied = false;
		if (!string.IsNullOrEmpty(strImportPath))
		{
			DateTime themeDataFileLastWriteTime = GetThemeDataFileLastWriteTime(strImportPath);
			if (themeDataFileLastWriteTime != DateTime.MinValue)
			{
				string[] files = Directory.GetFiles(strImportPath);
				int intValue = 0;
				if (files != null && files.Length != 0)
				{
					OnProgressChanged(intValue, 0, files.Length - 1);
				}
				string[] array = files;
				for (int i = 0; i < array.Length; i++)
				{
					FileInfo fileInfo = new FileInfo(array[i]);
					if (fileInfo != null && fileInfo.Name != "theme.data" && fileInfo.LastWriteTime > themeDataFileLastWriteTime)
					{
						blnChangesApplied = ((!fileInfo.Name.Contains("~VwgProp~")) ? ImportFileResource(fileInfo) : ImportValueResource(fileInfo));
					}
					OnProgressChanged(intValue++, -1, -1);
				}
				UpdateThemeDataFile(strImportPath);
			}
			else
			{
				MessageBox.Show(string.Format("Selected folder misses the '{0}' system file.", "theme.data"), "Corrupted import folder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		OnProcessCompleted(blnChangesApplied);
	}

	public override void Initialize(IComponent objComponent)
	{
		base.Initialize(objComponent);
		INestedContainer nestedContainer = (INestedContainer)GetService(typeof(INestedContainer));
		if (nestedContainer == null)
		{
			return;
		}
		ITypeDiscoveryService typeDiscoveryService = (ITypeDiscoveryService)GetService(typeof(ITypeDiscoveryService));
		if (typeDiscoveryService == null)
		{
			return;
		}
		foreach (Type type in typeDiscoveryService.GetTypes(base.SkinType, excludeGlobalTypes: false))
		{
			if (!(type != base.SkinType))
			{
				continue;
			}
			mobjSkinTypes.Add(type);
			if (IsVisibleSkinType(type))
			{
				IComponent component = (IComponent)Activator.CreateInstance(type);
				if (component != null)
				{
					DocumentUtils.InvokeMethod(component, "SetOwner", objComponent);
					nestedContainer.Add(component, DocumentUtils.GetComponentName(component, nestedContainer.Components));
				}
			}
		}
	}

	private ResXFileRef CreateResourceProjectItem(string strFileName, byte[] arrContent, Type objContentType)
	{
		ProjectItem projectItem = (ProjectItem)GetService(typeof(ProjectItem));
		if (projectItem != null)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Guid.NewGuid().ToString("P"));
			string text2 = Path.Combine(text, strFileName);
			try
			{
				Directory.CreateDirectory(text);
				File.WriteAllBytes(text2, arrContent);
				foreach (ProjectItem projectItem4 in projectItem.ProjectItems)
				{
					if (projectItem4.Name == strFileName)
					{
						projectItem4.Delete();
						break;
					}
				}
				string path = Path.Combine(Path.GetDirectoryName(projectItem.get_FileNames((short)0)), strFileName);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				ProjectItem projectItem3 = projectItem.ProjectItems.AddFromFileCopy(text2);
				if (projectItem3 != null)
				{
					string typeName = string.Join(",", objContentType.AssemblyQualifiedName.Split(','), 0, 2);
					return new ResXFileRef(projectItem3.get_FileNames((short)0), typeName);
				}
			}
			finally
			{
				Directory.Delete(text, recursive: true);
			}
		}
		return null;
	}

	private string GetResourceInheritedName(string strFileName)
	{
		if (!string.IsNullOrEmpty(strFileName))
		{
			int num = strFileName.IndexOf(".");
			if (num >= 0)
			{
				strFileName = strFileName.Substring(num + 1);
			}
		}
		return strFileName;
	}

	private string GetResourcePrefix(IComponent objComponent)
	{
		if (objComponent != null && objComponent.Site != null && base.Component != null && base.Component.Site != null)
		{
			return $"{base.Component.Site.Name}.{objComponent.Site.Name}";
		}
		return string.Empty;
	}

	private IComponent GetSkinInstance(Type objSkinType)
	{
		INestedContainer nestedContainer = (INestedContainer)GetService(typeof(INestedContainer));
		if (nestedContainer != null)
		{
			foreach (IComponent component in nestedContainer.Components)
			{
				if (component.GetType() == objSkinType)
				{
					return component;
				}
			}
			return null;
		}
		return null;
	}

	private string GetSkinKey(string strResourceName)
	{
		if (strResourceName.Contains(":"))
		{
			string[] array = strResourceName.Split(':');
			return array[array.Length - 1];
		}
		return strResourceName;
	}

	private DateTime GetThemeDataFileLastWriteTime(string strPath)
	{
		DateTime result = DateTime.MinValue;
		if (!string.IsNullOrEmpty(strPath))
		{
			string path = Path.Combine(strPath, "theme.data");
			if (File.Exists(path))
			{
				result = File.GetLastWriteTime(path);
			}
		}
		return result;
	}

	internal bool IsVisibleSkinType(Type objSkinType)
	{
		object[] customAttributes = objSkinType.GetCustomAttributes(SkinVisibilityAttributeType, inherit: false);
		if (customAttributes.Length != 0 && (int)DocumentUtils.GetPropertyValue(customAttributes[0], "Visibility") > 300)
		{
			return false;
		}
		return true;
	}

	private void OverrideValueResource(string strFilePath, object objSkinResource, object objSkinComponent, Type objSkinPropertyValueType)
	{
		if (string.IsNullOrEmpty(strFilePath) || objSkinResource == null || objSkinComponent == null || !(objSkinPropertyValueType != null))
		{
			return;
		}
		string text = string.Empty;
		string fullName = objSkinPropertyValueType.FullName;
		if (!(fullName == "System.Drawing.Color"))
		{
			if (fullName == "Gizmox.WebGUI.Forms.BorderColor")
			{
				Bitmap bitmap = new Bitmap(strFilePath);
				if (bitmap != null)
				{
					Color color = bitmap.GetPixel(0, 0);
					Color color2 = bitmap.GetPixel(2, 0);
					Color color3 = bitmap.GetPixel(1, 1);
					Color color4 = bitmap.GetPixel(1, 0);
					if (color.A == 0)
					{
						color = Color.Transparent;
					}
					if (color2.A == 0)
					{
						color2 = Color.Transparent;
					}
					if (color3.A == 0)
					{
						color3 = Color.Transparent;
					}
					if (color4.A == 0)
					{
						color4 = Color.Transparent;
					}
					TypeConverter converter = TypeDescriptor.GetConverter(objSkinPropertyValueType);
					if (converter != null)
					{
						text = converter.ConvertToInvariantString(Activator.CreateInstance(objSkinPropertyValueType, color, color4, color2, color3));
					}
				}
			}
		}
		else
		{
			Bitmap bitmap = new Bitmap(strFilePath);
			if (bitmap != null)
			{
				Color color5 = bitmap.GetPixel(0, 0);
				if (color5.A == 0)
				{
					color5 = Color.Transparent;
				}
				TypeConverter converter2 = TypeDescriptor.GetConverter(objSkinPropertyValueType);
				if (converter2 != null)
				{
					text = converter2.ConvertToInvariantString(color5);
				}
			}
		}
		if (!string.IsNullOrEmpty(text) && objSkinComponent is IDictionary dictionary)
		{
			DocumentUtils.SetPropertyValue(objSkinResource, "Value", text);
			dictionary[DocumentUtils.GetResourceName(objSkinComponent, objSkinResource)] = objSkinResource;
		}
	}

	private void OverrideFileResource(string strFilePath, object objSkinComponent, object objSkinResource)
	{
		if (string.IsNullOrEmpty(strFilePath) || objSkinComponent == null || objSkinResource == null)
		{
			return;
		}
		object obj = null;
		if (!DocumentUtils.IsInherited(objSkinComponent, objSkinResource))
		{
			obj = objSkinResource;
		}
		else if (objSkinResource is ICloneable cloneable)
		{
			obj = cloneable.Clone();
		}
		if (obj == null || !(objSkinComponent is IDictionary dictionary))
		{
			return;
		}
		dictionary[DocumentUtils.GetResourceName(objSkinComponent, objSkinResource)] = obj;
		if ((ProjectItem)GetService(typeof(ProjectItem)) == null)
		{
			return;
		}
		byte[] arrContent = File.ReadAllBytes(strFilePath);
		Type type = (Type)DocumentUtils.GetPropertyValue(objSkinResource, "CompilerContentType");
		if (type != null)
		{
			string resourceName = DocumentUtils.GetResourceName(objSkinComponent, objSkinResource);
			ResXFileRef resXFileRef = CreateResourceProjectItem($"{GetResourcePrefix(objSkinComponent as IComponent)}.{resourceName}", arrContent, type);
			if (resXFileRef != null)
			{
				DocumentUtils.SetPropertyValue(obj, "Content", resXFileRef);
				DocumentUtils.SetPropertyValue(obj, "FileName", Path.GetFileName(resXFileRef.FileName));
			}
		}
	}

	private void UpdateThemeDataFile(string strPath)
	{
		if (!string.IsNullOrEmpty(strPath))
		{
			string path = Path.Combine(strPath, "theme.data");
			if (File.Exists(path))
			{
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			File.Create(path);
			File.SetAttributes(path, FileAttributes.Hidden);
		}
	}

	private void WriteFileResource(object objSkinResource, string strResourcesPath, bool blnIsInherited)
	{
		if (objSkinResource == null || string.IsNullOrEmpty(strResourcesPath))
		{
			return;
		}
		string text = (string)DocumentUtils.GetPropertyValue(objSkinResource, "FileName");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (!blnIsInherited)
		{
			text = GetResourceInheritedName(text);
		}
		string path = Path.Combine(strResourcesPath, text);
		Stream stream = (Stream)DocumentUtils.GetPropertyValue(objSkinResource, "ContentStream");
		if (stream != null)
		{
			if (File.Exists(path))
			{
				File.SetAttributes(path, FileAttributes.Normal);
				File.Delete(path);
			}
			byte[] array = new byte[stream.Length];
			stream.Position = 0L;
			stream.Read(array, 0, array.Length);
			File.WriteAllBytes(path, array);
		}
	}

	private void WriteValueResource(Type objSkinType, Type objSkinPropertyValueType, string strSkinPropertyName, object objSkinResource, string strResourcesPath)
	{
		if (!(objSkinPropertyValueType != null) || string.IsNullOrEmpty(strSkinPropertyName) || !(objSkinType != null) || objSkinResource == null || string.IsNullOrEmpty(strResourcesPath))
		{
			return;
		}
		object propertyValue = DocumentUtils.GetPropertyValue(objSkinResource, "Value");
		if (propertyValue == null)
		{
			return;
		}
		string fullName = objSkinPropertyValueType.FullName;
		if (!(fullName == "System.Drawing.Color"))
		{
			if (!(fullName == "Gizmox.WebGUI.Forms.BorderColor"))
			{
				return;
			}
			object obj = null;
			Type type = propertyValue.GetType();
			if (type == objSkinPropertyValueType || type.IsAssignableFrom(objSkinPropertyValueType))
			{
				obj = propertyValue;
			}
			else if (propertyValue is string)
			{
				string text = Convert.ToString(propertyValue);
				if (!string.IsNullOrEmpty(text))
				{
					TypeConverter converter = TypeDescriptor.GetConverter(objSkinPropertyValueType);
					if (converter != null)
					{
						obj = converter.ConvertFromInvariantString(text);
					}
				}
			}
			if (obj == null)
			{
				return;
			}
			Color color = (Color)DocumentUtils.GetPropertyValue(obj, "Left");
			Color color2 = (Color)DocumentUtils.GetPropertyValue(obj, "Right");
			Color color3 = (Color)DocumentUtils.GetPropertyValue(obj, "Bottom");
			Color color4 = (Color)DocumentUtils.GetPropertyValue(obj, "Top");
			string path = string.Format("{0}{1}{2}.png", objSkinType.Name, "~VwgProp~", strSkinPropertyName);
			string filename = Path.Combine(strResourcesPath, path);
			if (GetControlProperty(base.Frame, "DrawingGraphics") is Graphics g)
			{
				Bitmap bitmap = new Bitmap(3, 2, g);
				if (bitmap != null)
				{
					bitmap.SetPixel(0, 0, color);
					bitmap.SetPixel(1, 0, color4);
					bitmap.SetPixel(2, 0, color2);
					bitmap.SetPixel(0, 1, color);
					bitmap.SetPixel(1, 1, color3);
					bitmap.SetPixel(2, 1, color2);
					bitmap.Save(filename, ImageFormat.Png);
				}
			}
			return;
		}
		Color color5 = Color.Empty;
		if (propertyValue is Color)
		{
			color5 = (Color)propertyValue;
		}
		else if (propertyValue is string)
		{
			string text2 = Convert.ToString(propertyValue);
			if (!string.IsNullOrEmpty(text2))
			{
				TypeConverter converter2 = TypeDescriptor.GetConverter(objSkinPropertyValueType);
				if (converter2 != null)
				{
					color5 = (Color)converter2.ConvertFromInvariantString(text2);
				}
			}
		}
		if (color5.IsEmpty)
		{
			return;
		}
		string path2 = string.Format("{0}{1}{2}.png", objSkinType.Name, "~VwgProp~", strSkinPropertyName);
		string filename2 = Path.Combine(strResourcesPath, path2);
		if (GetControlProperty(base.Frame, "DrawingGraphics") is Graphics g2)
		{
			Bitmap bitmap2 = new Bitmap(1, 1, g2);
			if (bitmap2 != null)
			{
				bitmap2.SetPixel(0, 0, color5);
				bitmap2.Save(filename2, ImageFormat.Png);
			}
		}
	}
}
