using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public abstract class ScrollBar : Control
    {
		#region Constructors

        // Methods
        public ScrollBar()
        {
        }

		#endregion Constructors 

		#region Properties

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LargeChange
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Maximum
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Minimum
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SmallChange
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Value
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

		#endregion Properties 

		#region Delegates and Events

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event ScrollEventHandler Scroll;

		#endregion Delegates and Events 

		#region Methods

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnScroll(ScrollEventArgs se)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual void OnValueChanged(EventArgs e)
        {
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected void UpdateScrollInfo()
        {
        }

		#endregion Methods 
    }
}
