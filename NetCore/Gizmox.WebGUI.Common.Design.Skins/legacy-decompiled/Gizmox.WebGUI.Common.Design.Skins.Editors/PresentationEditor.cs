using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

public class PresentationEditor : UITypeEditor
{
	public override bool IsDropDownResizable => false;

	protected virtual string PresentationPropertyName => string.Empty;

	public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
	{
		if (objContext != null && objContext.Instance != null && objContext.Container != null && objProvider != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)objProvider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				string presentationPropertyName = PresentationPropertyName;
				if (!string.IsNullOrEmpty(presentationPropertyName))
				{
					object instance = objContext.Instance;
					if (instance != null)
					{
						Type propertyType = DocumentUtils.GetPropertyType(instance, presentationPropertyName);
						if (propertyType != null)
						{
							int num = Convert.ToInt32(DocumentUtils.GetPropertyValue(instance, presentationPropertyName));
							if (num >= 0)
							{
								Panel panel = CreateDropDownPanel(num, propertyType);
								IComponentChangeService componentChangeService = objProvider.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
								object instance2 = objContext.Instance;
								windowsFormsEditorService.DropDownControl(panel);
								int dropDownSuggestedValue = GetDropDownSuggestedValue(panel, propertyType);
								if (num != dropDownSuggestedValue)
								{
									DocumentUtils.SetPropertyValue(instance, presentationPropertyName, dropDownSuggestedValue);
									if (componentChangeService != null)
									{
										PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(instance2).Find(presentationPropertyName, ignoreCase: false);
										if (propertyDescriptor != null)
										{
											componentChangeService.OnComponentChanged(instance2, propertyDescriptor, num, dropDownSuggestedValue);
										}
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

	private int GetDropDownSuggestedValue(Panel objDropDownPanel, Type objPresentationEngineType)
	{
		int num = 0;
		if (objDropDownPanel != null && objDropDownPanel.Controls["objAgnosticRadioButton"] is RadioButton radioButton)
		{
			if (radioButton.Checked)
			{
				num = Convert.ToInt32(Enum.Parse(objPresentationEngineType, "Agnostic"));
			}
			else if (objDropDownPanel.Controls["objCheckedListBox"] is CheckedListBox checkedListBox)
			{
				foreach (int checkedItem in checkedListBox.CheckedItems)
				{
					num |= checkedItem;
				}
			}
		}
		return num;
	}

	private Panel CreateDropDownPanel(int intSelectedPresentationEngine, Type objPresentationEngineType)
	{
		Panel panel = new Panel();
		RadioButton radioButton = new RadioButton();
		RadioButton radioButton2 = new RadioButton();
		CheckedListBox checkedListBox = new CheckedListBox();
		radioButton.Dock = DockStyle.Top;
		radioButton.Size = new Size(317, 17);
		radioButton.Text = "Agnostic";
		radioButton.TabIndex = 0;
		radioButton.Name = "objAgnosticRadioButton";
		radioButton.Click += DropDownRadioButton_Click;
		radioButton.Checked = Convert.ToInt32(Enum.Parse(objPresentationEngineType, "Agnostic")) == intSelectedPresentationEngine;
		radioButton2.Dock = DockStyle.Top;
		radioButton2.Size = new Size(317, 25);
		radioButton2.Text = "Specific";
		radioButton2.TabIndex = 1;
		radioButton2.Name = "objSpecificRadioButton";
		radioButton2.Click += DropDownRadioButton_Click;
		radioButton2.Checked = Convert.ToInt32(Enum.Parse(objPresentationEngineType, "Agnostic")) != intSelectedPresentationEngine;
		checkedListBox.Dock = DockStyle.Fill;
		checkedListBox.CheckOnClick = true;
		checkedListBox.TabIndex = 2;
		checkedListBox.Name = "objCheckedListBox";
		foreach (object value in Enum.GetValues(objPresentationEngineType))
		{
			int num = Convert.ToInt32(value);
			if (num != Convert.ToInt32(Enum.Parse(objPresentationEngineType, "Agnostic")))
			{
				checkedListBox.Items.Add(value, (intSelectedPresentationEngine & num) == num);
			}
		}
		panel.Controls.Add(checkedListBox);
		panel.Controls.Add(radioButton2);
		panel.Controls.Add(radioButton);
		panel.Dock = DockStyle.Fill;
		panel.Padding = new Padding(5, 5, 5, 0);
		panel.Height = 120;
		return panel;
	}

	private void DropDownRadioButton_Click(object sender, EventArgs e)
	{
		if (sender is RadioButton radioButton)
		{
			Control control = radioButton.Parent.Controls["objCheckedListBox"];
			if (control != null)
			{
				control.Enabled = radioButton.Name == "objSpecificRadioButton";
			}
		}
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}
}
