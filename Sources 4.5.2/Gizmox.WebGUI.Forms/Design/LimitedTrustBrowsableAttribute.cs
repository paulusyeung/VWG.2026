using System;
using System.Text;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// Specifies whether a property or event should be displayed in a Properties window 
    /// of the PropertyGrid in Partially Trusted Environment.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true), Serializable()]
    public sealed class LimitedTrustBrowsableAttribute : Attribute
    {
		#region Fields 

		/// <summary>
        /// Specifies the default value for the <see cref="T:Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsableAttribute"></see>, 
        /// which is <see cref="F:Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsableAttribute.Yes"></see>. This static field is read-only.</summary>
        public static readonly LimitedTrustBrowsableAttribute Default;
		private bool mblnBrowsable = true;
		/// <summary>
        /// Specifies that a property or event cannot be modified at design time. This static field is read-only.
        /// </summary>
        public static readonly LimitedTrustBrowsableAttribute No;
		/// <summary>
        /// Specifies that a property or event can be modified at design time. This static field is read-only.
        /// </summary>
        public static readonly LimitedTrustBrowsableAttribute Yes;

		#endregion

		#region Constructors 

		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.BrowsableAttribute"></see> class.
        /// </summary>
        /// <param name="blnBrowsable">true if a property or event can be modified at design time; otherwise, false. The default is true. </param>
        public LimitedTrustBrowsableAttribute(bool blnBrowsable)
        {
            this.mblnBrowsable = blnBrowsable;
        }
		
		static LimitedTrustBrowsableAttribute()
        {
            No      = new LimitedTrustBrowsableAttribute(false);
            Yes     = new LimitedTrustBrowsableAttribute(true);
            Default = Yes;
        }
		
		#endregion 

		#region Properties

		/// <summary>
        /// Gets a value indicating whether an object is browsable.
        /// </summary>
        /// <returns>
        /// true if the object is browsable; otherwise, false.
        /// </returns>
        public bool Browsable
        {
            get
            {
                return this.mblnBrowsable;
            }
        }
		
		#endregion

		#region Methods

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <returns>true if obj is equal to this instance; otherwise, false.</returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            LimitedTrustBrowsableAttribute attribute = obj as LimitedTrustBrowsableAttribute;
            return ((attribute != null) && (attribute.Browsable == this.mblnBrowsable));
        }
		
		/// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return this.mblnBrowsable.GetHashCode();
        }
		
		/// <summary>
        /// Determines if this attribute is the default.
        /// </summary>
        /// <returns>
        /// true if the attribute is the default value for this attribute class; otherwise, false.
        /// </returns>
        public override bool IsDefaultAttribute()
        {
            return this.Equals(LimitedTrustBrowsableAttribute.Default);
        }
		
		#endregion
    }
}
