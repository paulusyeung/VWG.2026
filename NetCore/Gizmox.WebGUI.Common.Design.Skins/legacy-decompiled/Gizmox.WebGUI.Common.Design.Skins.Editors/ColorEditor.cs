using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

public class ColorEditor : System.Drawing.Design.ColorEditor
{
	private Color mobjEmptyColor = Color.Empty;

	public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
	{
		if (objProvider != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)objProvider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				Type nestedType = typeof(System.Drawing.Design.ColorEditor).GetNestedType("ColorUI", BindingFlags.NonPublic);
				if (nestedType != null)
				{
					Control control = DocumentUtils.GetFieldValue(this, typeof(ColorEditor), "colorUI", BindingFlags.Instance | BindingFlags.NonPublic) as Control;
					if (control == null)
					{
						control = Activator.CreateInstance(nestedType, this) as Control;
						DocumentUtils.SetFieldValue(this, typeof(ColorEditor), "colorUI", BindingFlags.Instance | BindingFlags.NonPublic, control);
					}
					if (DocumentUtils.GetPropertyValue(control, "SystemColorValues", BindingFlags.Instance | BindingFlags.NonPublic) is object[])
					{
						if (mobjEmptyColor == Color.Empty)
						{
							ConstructorInfo constructor = typeof(Color).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[4]
							{
								typeof(long),
								typeof(short),
								typeof(string),
								typeof(KnownColor)
							}, null);
							if (constructor != null)
							{
								object obj = constructor.Invoke(new object[4]
								{
									0,
									Convert.ToInt16(8),
									"Empty",
									0
								});
								if (obj != null && obj is Color)
								{
									mobjEmptyColor = (Color)obj;
								}
							}
						}
						if (mobjEmptyColor != Color.Empty && DocumentUtils.GetFieldValue(control, nestedType, "systemColorConstants", BindingFlags.Instance | BindingFlags.NonPublic) is object[] array && !new List<object>(array).Contains(mobjEmptyColor))
						{
							object[] array2 = new object[array.Length + 1];
							array.CopyTo(array2, 0);
							array2[array.Length] = mobjEmptyColor;
							DocumentUtils.SetFieldValue(control, nestedType, "systemColorConstants", BindingFlags.Instance | BindingFlags.NonPublic, array2);
							control.Controls.Clear();
							DocumentUtils.InvokeMethod(control, "InitializeComponent", BindingFlags.Instance | BindingFlags.NonPublic);
							DocumentUtils.InvokeMethod(control, "AdjustListBoxItemHeight", BindingFlags.Instance | BindingFlags.NonPublic);
						}
					}
					DocumentUtils.InvokeMethod(control, "Start", windowsFormsEditorService, objValue);
					windowsFormsEditorService.DropDownControl(control);
					object propertyValue = DocumentUtils.GetPropertyValue(control, "Value");
					if (propertyValue != null)
					{
						objValue = ((!mobjEmptyColor.Equals(propertyValue)) ? propertyValue : ((object)Color.Empty));
					}
					DocumentUtils.InvokeMethod(control, "End");
				}
			}
		}
		return objValue;
	}
}
