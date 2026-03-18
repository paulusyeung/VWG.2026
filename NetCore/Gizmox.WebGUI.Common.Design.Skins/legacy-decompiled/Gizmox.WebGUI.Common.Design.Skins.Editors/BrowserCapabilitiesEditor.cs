using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Common.Design.Skins.Editors;

public class BrowserCapabilitiesEditor : UITypeEditor
{
	public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object value)
	{
		if (objContext != null && objContext.Instance != null)
		{
			BrowserCapabilitiesForm browserCapabilitiesForm = new BrowserCapabilitiesForm(DocumentUtils.GetPropertyValue(objContext.Instance, "BrowserCapabilities"));
			if (browserCapabilitiesForm.ShowDialog() == DialogResult.OK)
			{
				return browserCapabilitiesForm.BrowserCapabilities;
			}
		}
		return base.EditValue(objContext, objProvider, value);
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}
}
