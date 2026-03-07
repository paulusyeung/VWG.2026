using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// ShortcutKeysEditor
    /// </summary>
    public class ShortcutKeysEditor : UITypeEditor
    {
        private WinForms.Design.ShortcutKeysEditor objWinShortcutKeysEditor;

        public ShortcutKeysEditor()
            : base()
        {
            objWinShortcutKeysEditor = new WinForms.Design.ShortcutKeysEditor();
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

            WinForms.Keys enmKeys = (WinForms.Keys)objWinShortcutKeysEditor.EditValue(context, provider, ShortcutKeysEditor.ConvertShortcutKeys((WebGUIForms.Keys)value));
            return ShortcutKeysEditor.ConvertShortcutKeys(enmKeys);
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }


        /// <summary>
        /// Converts the shortcut keys.
        /// </summary>
        /// <param name="enmKeys">The enm keys.</param>
        /// <returns></returns>
        public static WebGUIForms.Keys ConvertShortcutKeys(WinForms.Keys enmKeys)
        {
            return (WebGUIForms.Keys)Enum.Parse(typeof(WebGUIForms.Keys), enmKeys.ToString());
        }


        /// <summary>
        /// Converts the shortcut keys.
        /// </summary>
        /// <param name="enmWGKeys">The enm WG keys.</param>
        /// <returns></returns>
        public static WinForms.Keys ConvertShortcutKeys(WebGUIForms.Keys enmWGKeys)
        {
            return (WinForms.Keys)Enum.Parse(typeof(WinForms.Keys), enmWGKeys.ToString());
        }
    }
}
