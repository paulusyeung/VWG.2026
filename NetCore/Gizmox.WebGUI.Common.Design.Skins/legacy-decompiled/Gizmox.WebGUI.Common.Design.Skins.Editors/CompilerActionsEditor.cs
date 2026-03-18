using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

public class CompilerActionsEditor : UITypeEditor
{
	public override bool IsDropDownResizable => false;

	public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
	{
		if (objContext != null && objContext.Instance != null && objContext.Container != null && objProvider != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)objProvider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				object instance = objContext.Instance;
				if (instance != null)
				{
					Type propertyType = DocumentUtils.GetPropertyType(instance, "CompilerActions");
					if (propertyType != null)
					{
						int num = Convert.ToInt32(DocumentUtils.GetPropertyValue(instance, "CompilerActions"));
						if (num >= 0)
						{
							CheckedListBox checkedListBox = new CheckedListBox();
							checkedListBox.CheckOnClick = true;
							checkedListBox.Dock = DockStyle.Fill;
							checkedListBox.BorderStyle = BorderStyle.None;
							checkedListBox.Height = 54;
							foreach (object value in Enum.GetValues(propertyType))
							{
								int num2 = Convert.ToInt32(value);
								if (num2 != Convert.ToInt32(Enum.Parse(propertyType, "None")))
								{
									checkedListBox.Items.Add(value, (num & num2) == num2);
								}
							}
							IComponentChangeService componentChangeService = objProvider.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
							object instance2 = objContext.Instance;
							windowsFormsEditorService.DropDownControl(checkedListBox);
							int num3 = Convert.ToInt32(Enum.Parse(propertyType, "None"));
							foreach (int checkedItem in checkedListBox.CheckedItems)
							{
								num3 |= checkedItem;
							}
							if (num != num3)
							{
								DocumentUtils.SetPropertyValue(instance, "CompilerActions", num3);
								if (componentChangeService != null)
								{
									PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(instance2).Find("CompilerActions", ignoreCase: false);
									if (propertyDescriptor != null)
									{
										componentChangeService.OnComponentChanged(instance2, propertyDescriptor, num, num3);
									}
								}
							}
						}
					}
				}
			}
		}
		return objValue;
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}
}
