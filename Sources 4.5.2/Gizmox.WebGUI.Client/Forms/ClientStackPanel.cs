using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Gizmox.WebGUI.Client.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientStackPanel : Panel
    {
        #region Fields (2)

        private Dictionary<Control, Size> marrControlSizes = new Dictionary<Control, Size>();
        private Orientation menmOrientation = Orientation.Vertical;

        #endregion Fields

        #region Properties (1)

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>
        /// The orientation.
        /// </value>
        public Orientation Orientation
        {
            get
            {
                return menmOrientation;
            }
            set
            {
                if (menmOrientation != value)
                {
                    menmOrientation = value;

                    foreach (Control objCotrol in this.Controls)
                    {
                        ApplyControlSize(objCotrol);

                        ApplyControlDockStyle(objCotrol);
                    }
                }
            }
        }

        #endregion Properties

        #region Methods (4)

        // Protected Methods (2) 

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs"/> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            Control objControl = e.Control;
            if (objControl != null)
            {
                marrControlSizes.Add(objControl, objControl.Size);

                objControl.DockChanged += new EventHandler(OnContainedControlDockChanged);

                ApplyControlDockStyle(objControl);
            }
        }

        /// <summary>
        /// Called when [contained control dock changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void OnContainedControlDockChanged(object sender, EventArgs e)
        {
            Control objControl = sender as Control;
            if (objControl != null)
            {
                ApplyControlDockStyle(objControl);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs"/> that contains the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            Control objControl = e.Control;
            if (objControl != null)
            {
                objControl.DockChanged -= new EventHandler(OnContainedControlDockChanged);

                if (marrControlSizes.ContainsKey(objControl))
                {
                    marrControlSizes.Remove(objControl);
                }
            }
        }
        // Private Methods (2) 

        /// <summary>
        /// Applies the control dock style.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        private void ApplyControlDockStyle(Control objControl)
        {
            if (objControl != null)
            {
                objControl.SuspendLayout();

                objControl.Dock = this.Orientation == Orientation.Vertical ? DockStyle.Top : DockStyle.Left;

                objControl.ResumeLayout();
            }
        }

        /// <summary>
        /// Applies the size of the control.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        private void ApplyControlSize(Control objControl)
        {
            if (objControl != null)
            {
                Size objSize = marrControlSizes[objControl];
                if (objSize != null)
                {
                    objControl.SuspendLayout();

                    switch (this.Orientation)
                    {
                        case Orientation.Horizontal:
                            objControl.Width = objSize.Width;
                            break;
                        case Orientation.Vertical:
                            objControl.Height = objSize.Height;
                            break;
                    }

                    objControl.ResumeLayout();
                }
            }
        }

        #endregion Methods
    }
}
