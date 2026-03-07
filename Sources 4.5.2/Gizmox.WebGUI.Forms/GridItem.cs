namespace Gizmox.WebGUI.Forms
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Implements one row in a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
    /// </summary>

    [Serializable()]
    public abstract class GridItem : SerializableObject
    {


        /// <summary>
        /// The object property registration.
        /// </summary>
        private static readonly SerializableProperty userDataProperty = SerializableProperty.Register("userData", typeof(object), typeof(GridItem));


        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        /// <value>The user data.</value>
        private object userData
        {
            get
            {
                return this.GetValue<object>(GridItem.userDataProperty);
            }
            set
            {
                this.SetValue<object>(GridItem.userDataProperty, value);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> class. 
        /// </summary>
        protected GridItem()
        {
        }

        /// <summary>
        /// When overridden in a derived class, returns the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see> to which the current <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> belongs.
        /// </summary>
        /// <returns>The owning PropertyGrid.</returns>
        [Browsable(false)]
        public abstract PropertyGrid OwnerGrid{get;}


        /// <summary>
        /// When overridden in a derived class, selects this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
        /// </summary>
        /// <returns>true if the selection is successful; otherwise, false.</returns>
        public abstract bool Select();

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the specified property is expandable to show nested properties.
        /// </summary>
        /// <returns>true if the specified property can be expanded; otherwise, false. The default is false.</returns>
        public virtual bool Expandable
        {
            get
            {
                return false;
            }
        }

        /// <summary>When overridden in a derived class, gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is in an expanded state.</summary>
        /// <returns>false in all cases.</returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="P:Gizmox.WebGUI.Forms.GridItem.Expanded"></see> property was set to true, but a <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is not expandable.</exception>
        public virtual bool Expanded
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotSupportedException(SR.GetString("GridItemNotExpandable"));
            }
        }

        /// <summary>
        /// When overridden in a derived class, gets the collection of <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> objects, if any, associated as a child of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItemCollection"></see>.</returns>
        public abstract GridItemCollection GridItems { get; }

        /// <summary>
        /// When overridden in a derived class, gets the type of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.GridItemType"></see> values.</returns>
        public abstract Gizmox.WebGUI.Forms.GridItemType GridItemType { get; }

        /// <summary>
        /// When overridden in a derived class, gets the text of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"></see> representing the text associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
        public abstract string Label { get; }

        /// <summary>
        /// When overridden in a derived class, gets the parent <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>, if any.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> representing the parent of the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
        public abstract GridItem Parent { get; }

        /// <summary>
        /// When overridden in a derived class, gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
        public abstract System.ComponentModel.PropertyDescriptor PropertyDescriptor { get; }

        /// <summary>
        /// Gets or sets user-defined data about the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>An <see cref="T:System.Object"></see> that contains data about the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
        [SRCategory("CatData"), Localizable(false), Bindable(true), TypeConverter(typeof(StringConverter)), Gizmox.WebGUI.Forms.SRDescription("ControlTagDescr"), DefaultValue((string) null)]
        public object Tag
        {
            get
            {
                return this.userData;
            }
            set
            {
                this.userData = value;
            }
        }

        /// <summary>
        /// When overridden in a derived class, gets the current value of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.
        /// </summary>
        /// <returns>The current value of this <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>. This can be null.</returns>
        public abstract object Value { get; }




    }
}

