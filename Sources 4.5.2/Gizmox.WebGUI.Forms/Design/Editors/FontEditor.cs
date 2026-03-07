using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design
{
    
    /// <summary>
    /// Provides a user interface to select and configure a Font object.
    /// </summary>
    [Serializable()]
    public class FontEditor : WebUITypeEditor
    {
        private WebUITypeEditorHandler mobjHandler = null;

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Create font dialog
            FontDialog objFontDialog = new FontDialog();
            objFontDialog.Font =  this.GetEditorValueFromPropertyValue(objValue) as Font;
            objFontDialog.Closed += new EventHandler(objFontDialog_Closed);

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDialog(objFontDialog);
            }
        }

        private void objFontDialog_Closed(object sender, EventArgs e)
        {
            FontDialog objFontDialog = (FontDialog)sender;
            if (objFontDialog.DialogResult==DialogResult.OK)
            {
                if (mobjHandler != null)
                {
                    mobjHandler(this.GetPropertyValueFromEditorValue(objFontDialog.Font));
                }
            }
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}
