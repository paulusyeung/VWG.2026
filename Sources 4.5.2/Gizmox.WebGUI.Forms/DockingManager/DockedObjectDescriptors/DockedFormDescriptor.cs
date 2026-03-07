using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DockedFormDescriptor : DockedObjectDescriptor
    {
		#region Fields (3) 

        private long mlngOwningFormId;
        private Point mobjLocation;
        private Size mobjSize;
        private FormWindowState menmWindowState;

		#endregion Fields 

		#region Properties (3) 

        /// <summary>
        /// Gets or sets the state of the window.
        /// </summary>
        /// <value>
        /// The state of the window.
        /// </value>
        public FormWindowState WindowState
        {
            get { return menmWindowState; }
            set { menmWindowState = value; }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        public Point Location
        {
            get { return mobjLocation; }
        }

        /// <summary>
        /// Gets the owning form id.
        /// </summary>
        public long OwningFormId
        {
            get { return mlngOwningFormId; }
            set { mlngOwningFormId = value; }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public Size Size
        {
            get { return mobjSize; }
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
            if (typeof(DockingManager).IsAssignableFrom(objType))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clones without references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal override T CloneWithoutReferences<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Forms the closing.
        /// </summary>
        internal void FormClosing()
        {
            this.mlngOwningFormId = -1;
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        {
            DockedForm objForm = objControl as DockedForm;

            this.menmWindowState = objForm.WindowState;
            this.mobjSize = objForm.Size;
            this.mobjLocation = objForm.Location;
        }

		#endregion Methods 
    }
}
