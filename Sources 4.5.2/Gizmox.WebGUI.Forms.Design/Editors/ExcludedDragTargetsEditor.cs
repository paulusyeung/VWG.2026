using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public class ExcludedDragTargetsEditor : DragTargetsEditor
    {
        /// <summary>
        /// Gets the handled drag targets.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <returns></returns>
        protected override Component[] GetHandledDragTargets(Component objComponent)
        {
            return objComponent.ExcludedDragTargets;
        }
    }
}
