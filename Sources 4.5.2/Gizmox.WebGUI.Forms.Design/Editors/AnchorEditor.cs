using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;

using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;


namespace Gizmox.WebGUI.Forms.Design
{
	
	public class AnchorEditor : UITypeEditor
	{
		private WinForms.Design.AnchorEditor objWinAnchorEditor;

		public AnchorEditor() : base()
		{
			objWinAnchorEditor = new WinForms.Design.AnchorEditor();
		}

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
            WebGUIForms.AnchorStyles enmWGAnchor = WebGUIForms.AnchorStyles.None;

            if (value != null)
            {
                enmWGAnchor = (WebGUIForms.AnchorStyles)value;
            }

            return AnchorEditor.ConvertAnchoring((WinForms.AnchorStyles)objWinAnchorEditor.EditValue(context, provider, AnchorEditor.ConvertAnchoring(enmWGAnchor)));
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

        /// <summary>
        /// Converts the anchoring.
        /// </summary>
        /// <param name="enmWGAnchor">WG anchor.</param>
        /// <returns></returns>
        public static WinForms.AnchorStyles ConvertAnchoring(WebGUIForms.AnchorStyles enmWGAnchor)
        {
            WinForms.AnchorStyles enmAnchor = WinForms.AnchorStyles.None;

            if (((int)(enmWGAnchor) & ((int)WebGUIForms.AnchorStyles.Left)) > 0) enmAnchor |= WinForms.AnchorStyles.Left;
            if (((int)(enmWGAnchor) & ((int)WebGUIForms.AnchorStyles.Right)) > 0) enmAnchor |= WinForms.AnchorStyles.Right;
            if (((int)(enmWGAnchor) & ((int)WebGUIForms.AnchorStyles.Top)) > 0) enmAnchor |= WinForms.AnchorStyles.Top;
            if (((int)(enmWGAnchor) & ((int)WebGUIForms.AnchorStyles.Bottom)) > 0) enmAnchor |= WinForms.AnchorStyles.Bottom;

            return enmAnchor;
        }



        /// <summary>
        /// Converts the anchoring.
        /// </summary>
        /// <param name="enmAnchor">anchor.</param>
        /// <returns></returns>
        public static WebGUIForms.AnchorStyles ConvertAnchoring(WinForms.AnchorStyles enmAnchor)
        {
            WebGUIForms.AnchorStyles enmWGAnchor = WebGUIForms.AnchorStyles.None;

            if (((int)(enmAnchor) & ((int)WinForms.AnchorStyles.Left)) > 0) enmWGAnchor |= WebGUIForms.AnchorStyles.Left;
            if (((int)(enmAnchor) & ((int)WinForms.AnchorStyles.Right)) > 0) enmWGAnchor |= WebGUIForms.AnchorStyles.Right;
            if (((int)(enmAnchor) & ((int)WinForms.AnchorStyles.Top)) > 0) enmWGAnchor |= WebGUIForms.AnchorStyles.Top;
            if (((int)(enmAnchor) & ((int)WinForms.AnchorStyles.Bottom)) > 0) enmWGAnchor |= WebGUIForms.AnchorStyles.Bottom;

            return enmWGAnchor;
        }
	}
}

