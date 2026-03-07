using System;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{

	
	public class DockEditor : UITypeEditor
	{
		private WinForms.Design.DockEditor objWinDockEditor;

		public DockEditor() : base()
		{
			objWinDockEditor = new WinForms.Design.DockEditor();
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{

            WinForms.DockStyle enmDock = (WinForms.DockStyle)objWinDockEditor.EditValue(context, provider, DockEditor.ConvertDocking((WebGUIForms.DockStyle)value));
            return DockEditor.ConvertDocking(enmDock);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.DropDown;
		}

        /// Converts the docking.
        /// </summary>
        /// <param name="enmDock">dock.</param>
        /// <returns></returns>
        public static WebGUIForms.DockStyle ConvertDocking(WinForms.DockStyle enmDock)
        {
            return (WebGUIForms.DockStyle)Enum.Parse(typeof(WebGUIForms.DockStyle), enmDock.ToString());
        }

        /// <summary>
        /// Converts the docking.
        /// </summary>
        /// <param name="enmWGDock">WG dock.</param>
        /// <returns></returns>
        public static WinForms.DockStyle ConvertDocking(WebGUIForms.DockStyle enmWGDock)
        {
            return (WinForms.DockStyle)Enum.Parse(typeof(WinForms.DockStyle), enmWGDock.ToString());
        }
	}
}
