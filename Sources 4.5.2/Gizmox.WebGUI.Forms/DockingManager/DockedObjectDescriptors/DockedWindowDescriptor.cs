using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    [Serializable]
    internal class DockedWindowDescriptor : DockedObjectDescriptor
    {
		#region Fields (3) 

        private Type mobjWindowType;
        private string mstrText;
        private string mstrHeaderText;
        private string mstrHeaderToolTip;
        private string mstrTabHeaderToolTip;
        private DockingWindowName mobjWindowName;
        private DockState menmCurrentDockState;
        private DockState menmLastDockState;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedWindowDescriptor"/> class.
        /// </summary>
        /// <param name="objWindow">The obj window.</param>
        public DockedWindowDescriptor(DockingWindow objWindow)
        {
            this.mobjWindowName = new DockingWindowName();
            this.mobjWindowType = objWindow.GetType();
        }

		#endregion Constructors 

		#region Properties (2) 

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return mstrText; }
        }

        /// <summary>
        /// Gets the type of the window.
        /// </summary>
        /// <value>
        /// The type of the window.
        /// </value>
        public Type WindowType
        {
            get
            {
                return mobjWindowType;
            }
        }

        /// <summary>
        /// Gets or sets the state of the current dock.
        /// </summary>
        /// <value>
        /// The state of the current dock.
        /// </value>
        internal DockState CurrentDockState
        {
            get { return menmCurrentDockState; }
            set { menmCurrentDockState = value; }
        }

		#endregion Properties 

		#region Methods (4) 

		// Internal Methods (4) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal override bool CanUpdateFrom(Type objType)
        {
            if (objType == typeof(DockedTabControl))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clones the without references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal override T CloneWithoutReferences<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates from tab control.
        /// </summary>
        /// <param name="objDockedTabControl">The obj docked tab control.</param>
        /// <param name="blnPreventExtraction">if set to <c>true</c> [BLN prevent extraction].</param>
        internal override void UpdateFromTabControl(DockedTabControl objDockedTabControl, bool blnPreventExtraction)
        {
            if (!blnPreventExtraction)
            {
                // Check if the window moved to a different zone with a different ZoneType
                objDockedTabControl.OwningZone.Manager.HandleWindowStateChanged(this, objDockedTabControl);
            }
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objManager"></param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        {
            DockingWindow objWindow = objControl as DockingWindow;

            if (objWindow != null)
            {
                this.mstrText = objWindow.Text;
                this.mobjWindowName.WindowName = objWindow.Name;
            }
        }

		#endregion Methods 
    
        /// <summary>
        /// Gets the name of the window.
        /// </summary>
        /// <value>
        /// The name of the window.
        /// </value>
        internal DockingWindowName WindowName
        {
            get
            {
                return this.mobjWindowName;
            }
        }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText 
        {
            get
            {
                return mstrHeaderText;
            }
            set
            {
                mstrHeaderText = value;
            }
        }

        /// <summary>
        /// Gets or sets the header tool tip.
        /// </summary>
        /// <value>
        /// The header tool tip.
        /// </value>
        public string HeaderToolTip
        {
            get
            {
                return mstrHeaderToolTip;
            }
            set
            {
                mstrHeaderToolTip = value;
            }
        }

        /// <summary>
        /// Gets or sets the tab header tool tip.
        /// </summary>
        /// <value>
        /// The tab header tool tip.
        /// </value>
        public string TabHeaderToolTip
        {
            get { return mstrTabHeaderToolTip; }
            set { mstrTabHeaderToolTip = value; }
        }

        /// <summary>
        /// Gets or sets the last state of the dock.
        /// </summary>
        /// <value>
        /// The last state of the dock.
        /// </value>
        public DockState LastDockState 
        { 
            get
            {
                return menmLastDockState;
            } 
            set
            {
                menmLastDockState = value;
            } 
        }
    }
}
