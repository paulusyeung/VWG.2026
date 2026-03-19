using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design;

public class ContextualTabGroupEditor : UITypeEditor
{
	private IWindowsFormsEditorService mobjEditorService;

	protected ITypeDescriptorContext mobjContext;

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context != null && context.Instance != null && context.Container != null && provider != null)
		{
			mobjEditorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
			if (mobjEditorService != null)
			{
				mobjContext = context;
				WebForms.TabPage objHandledComponent = TabPage;
				if (objHandledComponent == null || objHandledComponent.TabControl == null)
				{
					return value;
				}

				WinForms.ListBox objListBox = new WinForms.ListBox();
				WebForms.ContextualTabGroupCollection objContextualTabGroupCollection = objHandledComponent.TabControl.ContextualTabGroups;
				WebForms.ContextualTabGroup[] objContextualTabGroups = new WebForms.ContextualTabGroup[objContextualTabGroupCollection.Count];
				objContextualTabGroupCollection.CopyTo(objContextualTabGroups, 0);

				objListBox.Items.Add(WebForms.SR.GetString("None"));
				objListBox.Items.AddRange(objContextualTabGroups);

				if (objHandledComponent.ContextualTabGroup != null)
				{
					int intCurrentSelectedItem = objContextualTabGroupCollection.IndexOf(objHandledComponent.ContextualTabGroup) + 1;
					objListBox.SelectedIndex = intCurrentSelectedItem;
				}

				objListBox.SelectedIndexChanged += objListBox_SelectedIndexChanged;
				mobjEditorService.DropDownControl(objListBox);
				value = objListBox.SelectedItem as WebForms.ContextualTabGroup;
			}
		}

		return value;
	}

	protected virtual WebForms.TabPage TabPage => mobjContext?.Instance as WebForms.TabPage;

	private void objListBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		mobjEditorService?.CloseDropDown();
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}

	public override bool IsDropDownResizable => true;
}
