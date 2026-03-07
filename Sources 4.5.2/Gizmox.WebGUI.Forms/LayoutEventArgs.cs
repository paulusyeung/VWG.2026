using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    #region LayoutEventArgs Class


    /// <summary>
    /// Provides data for the Layout event. This class cannot be inherited.
    /// </summary>
    [Serializable()]
    public sealed class LayoutEventArgs : EventArgs
    {

        #region Class Members

        /// <summary>
        /// 
        /// </summary>
        private readonly IComponent affectedComponent;

        /// <summary>
        /// 
        /// </summary>
        private readonly string mstrAffectedProperty;

        /// <summary>
        /// 
        /// </summary>
        private readonly bool mblnIsClientSource;

        /// <summary>
        /// 
        /// </summary>
        private readonly bool mblnShouldUpdateSiblings;

        /// <summary>
        /// 
        /// </summary>
        private readonly bool mblnShouldUpdateParent;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutEventArgs"/> class.
        /// </summary>
        /// <param name="objAffectedComponent">The affected component.</param>
        /// <param name="strAffectedProperty">The affected property.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutEventArgs(IComponent objAffectedComponent, string strAffectedProperty)
        {
            this.affectedComponent = objAffectedComponent;
            this.mstrAffectedProperty = strAffectedProperty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutEventArgs"/> class.
        /// </summary>
        /// <param name="objAffectedControl">The affected control.</param>
        /// <param name="strAffectedProperty">The affected property.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LayoutEventArgs(Control objAffectedControl, string strAffectedProperty)
            : this((IComponent)objAffectedControl, strAffectedProperty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutEventArgs"/> class.
        /// </summary>
        /// <param name="blnIsClientSource">if set to <c>true</c> is client source.</param>
        /// <param name="blnShouldUpdateSiblings">if set to <c>true</c> should update siblings.</param>
        /// <param name="blnShouldUpdateParent">if set to <c>true</c> [BLN should update parent].</param>
        public LayoutEventArgs(bool blnIsClientSource, bool blnShouldUpdateSiblings, bool blnShouldUpdateParent)
        {
            mblnIsClientSource = blnIsClientSource;
            mblnShouldUpdateSiblings = blnShouldUpdateSiblings;
            mblnShouldUpdateParent = blnShouldUpdateParent;
        }

        /// <summary>
        /// Clones the specified should update siblings.
        /// </summary>
        /// <param name="blnShouldUpdateSiblings">if set to <c>true</c> should update siblings.</param>
        /// <param name="blnShouldUpdateParent">if set to <c>true</c> [BLN should update parent].</param>
        /// <returns></returns>
        public LayoutEventArgs Clone(bool blnShouldUpdateSiblings, bool blnShouldUpdateParent)
        {
            return new LayoutEventArgs(this.IsClientSource, blnShouldUpdateSiblings, blnShouldUpdateParent);
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets the affected component.
        /// </summary>
        /// <value>The affected component.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IComponent AffectedComponent
        {
            get
            {
                return this.affectedComponent;
            }
        }

        /// <summary>
        /// Gets the affected control.
        /// </summary>
        /// <value>The affected control.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Control AffectedControl
        {
            get
            {
                return (this.affectedComponent as Control);
            }
        }

        /// <summary>
        /// Gets the affected property.
        /// </summary>
        /// <value>The affected property.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AffectedProperty
        {
            get
            {
                return this.mstrAffectedProperty;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this event is client source.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this event is client source; otherwise, <c>false</c>.
        /// </value>
        public bool IsClientSource
        {
            get { return mblnIsClientSource; }
        }

        /// <summary>
        /// Gets a value indicating whether should update siblings.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should update siblings; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldUpdateSiblings
        {
            get { return mblnShouldUpdateSiblings; }
        }

        /// <summary>
        /// Gets a value indicating whether [should update parent].
        /// </summary>
        /// <value><c>true</c> if [should update parent]; otherwise, <c>false</c>.</value>
        public bool ShouldUpdateParent
        {
            get { return mblnShouldUpdateParent; }
        } 

        #endregion

    }

    #endregion
}
