using System;
using System.Collections.Generic;

using System.Text;

namespace Gizmox.WebGUI.Forms
{
    [Serializable]
    [System.ComponentModel.ToolboxItem(false)]
    public class DockedTabPage : TabPage
    {
		#region Fields (1) 

        private DockingWindow objDockedWindow;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedTabPage"/> class.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        public DockedTabPage(DockingWindow objWindow) : base(objWindow.Text) 
        {
            this.Image = objWindow.Image;
            this.HeaderToolTip = objWindow.TabHeaderToolTip;
            this.Controls.Add(objWindow);
        }

		#endregion Constructors 

		#region Properties (2) 

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with this control.
        /// </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for this control, or null if there is no <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. The default is null.</returns>
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                // Skip the tab control's context menu 
                if (this.Parent != null && this.Parent.Parent != null)
                {
                    return this.Parent.Parent.ContextMenuStrip;
                }

                return base.ContextMenuStrip;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        /// <summary>
        /// Gets the window.
        /// </summary>
        public DockingWindow Window
        {
            get { return objDockedWindow; }
        }

		#endregion Properties 

		#region Methods (3) 

		// Protected Methods (3) 

        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is DockingWindow)
            {
                base.OnControlAdded(e);
                this.objDockedWindow = (e.Control as DockingWindow);
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            if (e.Control is DockingWindow)
            {
                base.OnControlRemoved(e);

                this.Parent.Controls.Remove(this);
            }
            else
            {
                throw new Exception();
            }

        }

		#endregion Methods 
    }
}
