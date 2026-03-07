using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class DockedWindowPlaceHolderDescriptor : DockedObjectDescriptor
    {
		#region Fields (3) 

        private DockedWindowDescriptor mobjWindowDescriptor;
        private ZoneType mobjZoneType;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="DockedWindowPlaceHolderDescriptor"/> class.
        /// </summary>
        /// <param name="objWindowDescriptor">The obj window descriptor.</param>
        /// <param name="objZoneType">Type of the obj zone.</param>
        internal DockedWindowPlaceHolderDescriptor(DockedWindowDescriptor objWindowDescriptor, ZoneType objZoneType)
        {
            this.SetContainer(objWindowDescriptor.ParentDescriptor);
            this.mobjZoneType = objZoneType;
            this.mobjWindowDescriptor = objWindowDescriptor;
        }

		#endregion Constructors 

		#region Properties (2) 

        /// <summary>
        /// Gets the name of the window.
        /// </summary>
        /// <value>
        /// The name of the window.
        /// </value>
        public DockingWindowName WindowName 
        {
            get 
            {
                return mobjWindowDescriptor.WindowName;
            }
        }

        /// <summary>
        /// Gets or sets the type of the zone.
        /// </summary>
        /// <value>
        /// The type of the zone.
        /// </value>
        internal ZoneType ZoneType
        {
            get { return mobjZoneType; }
            set { mobjZoneType = value; }
        }

		#endregion Properties 

		#region Methods (3) 

		// Internal Methods (3) 

        /// <summary>
        /// Determines whether this instance [can update from] the specified obj type.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can update from] the specified obj type; otherwise, <c>false</c>.
        /// </returns>
        internal override bool CanUpdateFrom(Type objType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clones the without references.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal override T CloneWithoutReferences<T>()
        {
            throw new Exception();
        }

        /// <summary>
        /// Updates the self.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objManager"></param>
        internal override void UpdateSelf(Control objControl, DockingManager objManager)
        { }

		#endregion Methods 
    }
}
