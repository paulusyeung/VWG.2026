#region Using

using System;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Globalization;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel.Design.Serialization;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents the navigation and manipulation user interface (UI) for controls on a form that are bound to data.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ToolBar), "BindingNavigator_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ToolBar), "BindingNavigator.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.BindingNavigatorController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.BindingNavigatorController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemCategory("Data"), Skin(typeof(BindingNavigatorSkin))]
    [Serializable()]
    public class BindingNavigator : ToolBar, ISupportInitialize
    {
        #region Classes

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class BindingNavigatorLabel : ToolBarButton
        {

            /// <summary>
            /// </summary>
            /// <value></value>
            public override string CustomStyle
            {
                get
                {
                    return "Label";
                }
                set
                {
                    base.CustomStyle = value;
                }
            }
        }


        #endregion

        #region Class Members


        /// <summary>
        /// Provides a property reference to Initializing property.
        /// </summary>
        private static SerializableProperty InitializingProperty = SerializableProperty.Register("Initializing", typeof(bool), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to PositionItem property.
        /// </summary>
        private static SerializableProperty PositionItemProperty = SerializableProperty.Register("PositionItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to MovePreviousItem property.
        /// </summary>
        private static SerializableProperty MovePreviousItemProperty = SerializableProperty.Register("MovePreviousItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to MoveNextItem property.
        /// </summary>
        private static SerializableProperty MoveNextItemProperty = SerializableProperty.Register("MoveNextItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to MoveLastItem property.
        /// </summary>
        private static SerializableProperty MoveLastItemProperty = SerializableProperty.Register("MoveLastItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to MoveFirstItem property.
        /// </summary>
        private static SerializableProperty MoveFirstItemProperty = SerializableProperty.Register("MoveFirstItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to DeleteItem property.
        /// </summary>
        private static SerializableProperty DeleteItemProperty = SerializableProperty.Register("DeleteItem", typeof(ToolBarButton), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to CountItemFormat property.
        /// </summary>
        private static SerializableProperty CountItemFormatProperty = SerializableProperty.Register("CountItemFormat", typeof(string), typeof(BindingNavigator));

        /// <summary>
        /// Provides a property reference to BindingSource property.
        /// </summary>
        private static SerializableProperty BindingSourceProperty = SerializableProperty.Register("BindingSource", typeof(BindingSource), typeof(BindingNavigator));



        /// <summary>
        /// Provides a property reference to AddNewItem property.
        /// </summary>
        private static SerializableProperty AddNewItemProperty = SerializableProperty.Register("AddNewItem", typeof(ToolBarButton), typeof(BindingNavigator));


        /// <summary>Occurs when the state of the navigational user interface (UI) needs to be refreshed to reflect the current state of the underlying data.</summary>
        [SRDescription("BindingNavigatorRefreshItemsEventDescr"), SRCategory("CatBehavior")]
        public event EventHandler RefreshItems
        {
            add
            {
                this.AddHandler(BindingNavigator.RefreshItemsEvent, value);
            }
            remove
            {
                this.RemoveHandler(BindingNavigator.RefreshItemsEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the RefreshItems event.
        /// </summary>
        private EventHandler RefreshItemsHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(BindingNavigator.RefreshItemsEvent);
            }
        }

        /// <summary>
        /// The RefreshItems event registration.
        /// </summary>
        private static readonly SerializableEvent RefreshItemsEvent = SerializableEvent.Register("RefreshItems", typeof(EventHandler), typeof(BindingNavigator));



        #endregion

        #region C'Tors \ D'Tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class, indicating whether to display the standard navigation user interface (UI).</summary>
        /// <param name="blnAddStandardItems">true to show the standard navigational UI; otherwise, false.</param>
        public BindingNavigator(bool blnAddStandardItems)
        {
            // call the method instead of the property in order to avoid calling 
            // RefreshItemsInternal()
            this.SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));
            if (blnAddStandardItems)
            {
                this.AddStandardItems();
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class and adds this new instance to the specified container.</summary>
        /// <param name="objContainer">The <see cref="T:System.ComponentModel.IContainer"></see> to add the new <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingNavigator(IContainer objContainer)
            : this(false)
        {
            // Checking whether the container is not null which happens in Runtime mode
            if (objContainer != null)
            {
                objContainer.Add(this);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class with the specified <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> as the data source.</summary>
        /// <param name="objBindingSource">The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> used as a data source.</param>
        public BindingNavigator(BindingSource objBindingSource)
            : this(true)
        {
            this.BindingSource = objBindingSource;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> class.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingNavigator()
            : this(false)
        {
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Add New button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. The default is null.</returns>
        [SRDescription("BindingNavigatorAddNewItemPropDescr"), TypeConverter(typeof(ReferenceConverter)), SRCategory("CatItems"), DefaultValue(null)]
        public ToolBarButton AddNewItem
        {
            get
            {
                //Get MoveNextItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.AddNewItemProperty);
            }
            set
            {
                if (this.AddNewItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objToolBarButton = this.WireUpButton(this.AddNewItem, value, new EventHandler(this.OnAddNew));
                    //Set the AddNewItem in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.AddNewItemProperty, objToolBarButton);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component that is the source of data.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see> component associated with this <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>. The default is null.</returns>
        [TypeConverter(typeof(ReferenceConverter)), DefaultValue((string)null), SRCategory("CatData"), SRDescription("BindingNavigatorBindingSourcePropDescr")]
        public BindingSource BindingSource
        {
            get
            {
                //Get BindingSource from property store
                return this.GetValue<BindingSource>(BindingNavigator.BindingSourceProperty);
            }
            set
            {
                if (this.BindingSource != value)
                {
                    //Wire Up the old objBindingSource value to a new objBindingSource value
                    BindingSource objBindingSource = this.WireUpBindingSource(this.BindingSource, value);
                    //Set the BindingSource in the property store
                    this.SetValue<BindingSource>(BindingNavigator.BindingSourceProperty, objBindingSource);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the total number of items in the associated <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>. </returns>
        [SRDescription("BindingNavigatorCountItemPropDescr"), SRCategory("CatItems"), TypeConverter(typeof(ReferenceConverter)), DefaultValue(null)]
        [Obsolete("This property is not implemented - please use the PositionItem property which contains both position and count.")]
        public BindingNavigatorLabel CountItem
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a string used to format the information displayed in the <see cref="P:System.Windows.Forms.BindingNavigator.CountItem"></see> control.
        /// </summary>
        /// <value>The count item format.</value>
        /// <returns>The format <see cref="T:System.String"></see> used to format the item count. The default is the string of {0}.</returns>
        [SRCategory("CatAppearance"), SRDescription("BindingNavigatorCountItemFormatPropDescr")]
        public string CountItemFormat
        {
            get
            {
                return this.GetValue<string>(BindingNavigator.CountItemFormatProperty);
            }
            set
            {
                // If an assignment without the call to this.RefreshItemsInternal() is
                // needed, this can be done via private method 
                //this.SetCountItemFormatDirectly(string value).
                if (this.CountItemFormat != value)
                {
                    this.SetValue<string>(BindingNavigator.CountItemFormatProperty, value);
                    this.RefreshItemsInternal();
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Delete functionality.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Delete button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [SRCategory("CatItems"), TypeConverter(typeof(ReferenceConverter)), SRDescription("BindingNavigatorDeleteItemPropDescr"), DefaultValue(null)]
        public ToolBarButton DeleteItem
        {
            get
            {
                //Get DeleteItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.DeleteItemProperty);
            }
            set
            {
                if (this.DeleteItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objDeleteItem = this.WireUpButton(this.DeleteItem, value, new EventHandler(this.OnDelete));
                    //Set the DeleteItem in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.DeleteItemProperty, objDeleteItem);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move First functionality.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move First button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [SRCategory("CatItems"), TypeConverter(typeof(ReferenceConverter)), SRDescription("BindingNavigatorMoveFirstItemPropDescr"), DefaultValue(null)]
        public ToolBarButton MoveFirstItem
        {
            get
            {
                //Get MoveFirstItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.MoveFirstItemProperty);
            }
            set
            {
                if (this.MoveFirstItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objMoveFirstItem = this.WireUpButton(this.MoveFirstItem, value, new EventHandler(this.OnMoveFirst));
                    // Set the MoveFirstItem in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.MoveFirstItemProperty, objMoveFirstItem);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Last functionality.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Last button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [SRDescription("BindingNavigatorMoveLastItemPropDescr"), SRCategory("CatItems"), TypeConverter(typeof(ReferenceConverter)), DefaultValue(null)]
        public ToolBarButton MoveLastItem
        {
            get
            {
                //Get MoveLastItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.MoveLastItemProperty);
            }
            set
            {
                if (this.MoveLastItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objMoveLastItem = this.WireUpButton(this.MoveLastItem, value, new EventHandler(this.OnMoveLast));
                    // Set the MoveLastItem in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.MoveLastItemProperty, objMoveLastItem);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Next functionality.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Next button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [SRCategory("CatItems"), SRDescription("BindingNavigatorMoveNextItemPropDescr"), TypeConverter(typeof(ReferenceConverter)), DefaultValue(null)]
        public ToolBarButton MoveNextItem
        {
            get
            {
                //Get MoveNextItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.MoveNextItemProperty);
            }
            set
            {
                if (this.MoveNextItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objMoveNextItem = this.WireUpButton(this.MoveNextItem, value, new EventHandler(this.OnMoveNext));
                    //Set the MoveNextItem in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.MoveNextItemProperty, objMoveNextItem);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that is associated with the Move Previous functionality.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that represents the Move Previous button for the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</returns>
        [SRCategory("CatItems"), SRDescription("BindingNavigatorMovePreviousItemPropDescr"), TypeConverter(typeof(ReferenceConverter)), DefaultValue(null)]
        public ToolBarButton MovePreviousItem
        {
            get
            {
                //Get MovePreviousItem from property store
                return this.GetValue<ToolBarButton>(BindingNavigator.MovePreviousItemProperty);
            }
            set
            {
                if (this.MovePreviousItem != value)
                {
                    //Wire Up the old Button value to a new Button value
                    ToolBarButton objMovePreviousItem = this.WireUpButton(this.MovePreviousItem, value, new EventHandler(this.OnMovePrevious));
                    //Set the MovePreviousItem key in the property store
                    this.SetValue<ToolBarButton>(BindingNavigator.MovePreviousItemProperty, objMovePreviousItem);
                }
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position within the <see cref="T:Gizmox.WebGUI.Forms.BindingSource"></see>.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> that displays the current position.</returns>
        [SRDescription("BindingNavigatorPositionItemPropDescr"), TypeConverter(typeof(ReferenceConverter)), SRCategory("CatItems"), DefaultValue(null)]
        public BindingNavigatorLabel PositionItem
        {
            get
            {
                //Get MovePreviousItem from property store
                return this.GetValue<BindingNavigatorLabel>(BindingNavigator.PositionItemProperty);
            }
            set
            {
                if (this.PositionItem != value)
                {
                    //Wire Up the  old textbox value to the new textbox value
                    BindingNavigatorLabel objPositionItem = this.WireUpTextBox(this.PositionItem, value, new KeyEventHandler(this.OnPositionKey), new EventHandler(this.OnPositionLostFocus)) as BindingNavigatorLabel;

                    // Set the PositionItem key in the property store
                    this.SetValue<BindingNavigatorLabel>(BindingNavigator.PositionItemProperty, objPositionItem);
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BindingNavigator"/> is initializing.
        /// </summary>
        /// <value><c>true</c> if initializing; otherwise, <c>false</c>.</value>
        private bool Initializing
        {
            get
            {
                //get the boolean value
                return this.GetValue<bool>(BindingNavigator.InitializingProperty);
            }
            set
            {
                if (this.Initializing != value)
                {
                    //Initialize and set value 
                    this.SetValue<bool>(BindingNavigator.InitializingProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets the default text align.
        /// </summary>
        /// <value>The default text align.</value>
        protected override ToolBarTextAlign DefaultTextAlign
        {
            get
            {
                return ToolBarTextAlign.Right;
            }
        }


        /// <summary>
        /// Gets the toolbar button collecction
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public override ToolBarItemCollection Buttons
        {
            get
            {
                return base.Buttons;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>Adds the standard set of navigation items to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> control.</summary>
        public virtual void AddStandardItems()
        {
            if (!this.DesignMode)
            {
                bool blnIsRTL = false;
                this.MoveFirstItem = new ToolBarButton();
                this.MovePreviousItem = new ToolBarButton();
                this.MoveNextItem = new ToolBarButton();
                this.MoveLastItem = new ToolBarButton();
                this.PositionItem = new BindingNavigatorLabel();

                this.AddNewItem = new ToolBarButton();
                this.DeleteItem = new ToolBarButton();

                ToolBarButton separator = new ToolBarButton();
                ToolBarButton separator2 = new ToolBarButton();
                ToolBarButton separator3 = new ToolBarButton();

                char ch = (CommonUtils.IsNullOrEmpty(base.Name) || char.IsLower(base.Name[0])) ? 'b' : 'B';

                this.MoveFirstItem.Name = ch + "indingNavigatorMoveFirstItem";
                this.MovePreviousItem.Name = ch + "indingNavigatorMovePreviousItem";
                this.MoveNextItem.Name = ch + "indingNavigatorMoveNextItem";
                this.MoveLastItem.Name = ch + "indingNavigatorMoveLastItem";
                this.PositionItem.Name = ch + "indingNavigatorPositionItem";
                this.AddNewItem.Name = ch + "indingNavigatorAddNewItem";
                this.DeleteItem.Name = ch + "indingNavigatorDeleteItem";
                separator.Name = ch + "indingNavigatorSeparator";
                separator2.Name = ch + "indingNavigatorSeparator";
                separator3.Name = ch + "indingNavigatorSeparator";

                this.MoveFirstItem.ToolTipText = SR.GetString("BindingNavigatorMoveFirstItemText");
                this.MovePreviousItem.ToolTipText = SR.GetString("BindingNavigatorMovePreviousItemText");
                this.MoveNextItem.ToolTipText = SR.GetString("BindingNavigatorMoveNextItemText");
                this.MoveLastItem.ToolTipText = SR.GetString("BindingNavigatorMoveLastItemText");
                this.AddNewItem.ToolTipText = SR.GetString("BindingNavigatorAddNewItemText");
                this.DeleteItem.ToolTipText = SR.GetString("BindingNavigatorDeleteItemText");
                this.PositionItem.ToolTipText = SR.GetString("BindingNavigatorPositionItemTip");

                if (this.Context != null)
                {
                    //Check in the context if the application is 'right to left'
                    blnIsRTL = this.Context.RightToLeft;
                }

                this.MoveFirstItem.Image = new SkinResourceHandle(this.Skin, string.Format("NavigateHome{0}.gif", (blnIsRTL ? "RTL" : "LTR")));
                this.MovePreviousItem.Image = new SkinResourceHandle(this.Skin, string.Format("NavigatePrev{0}.gif", (blnIsRTL ? "RTL" : "LTR")));
                this.MoveNextItem.Image = new SkinResourceHandle(this.Skin, string.Format("NavigateNext{0}.gif", (blnIsRTL ? "RTL" : "LTR")));
                this.MoveLastItem.Image = new SkinResourceHandle(this.Skin, string.Format("NavigateEnd{0}.gif", (blnIsRTL ? "RTL" : "LTR")));
                this.AddNewItem.Image = new SkinResourceHandle(this.Skin, "Add.gif");
                this.DeleteItem.Image = new SkinResourceHandle(this.Skin, "Delete.gif");

                this.MoveFirstItem.Style = ToolBarButtonStyle.PushButton;
                this.MovePreviousItem.Style = ToolBarButtonStyle.PushButton;
                this.MoveNextItem.Style = ToolBarButtonStyle.PushButton;
                this.MoveLastItem.Style = ToolBarButtonStyle.PushButton;
                this.AddNewItem.Style = ToolBarButtonStyle.PushButton;
                this.DeleteItem.Style = ToolBarButtonStyle.PushButton;

                separator.Style = ToolBarButtonStyle.Separator;
                separator2.Style = ToolBarButtonStyle.Separator;
                separator3.Style = ToolBarButtonStyle.Separator;

                this.Buttons.AddRange(new ToolBarButton[] { this.MoveFirstItem, this.MovePreviousItem, separator, this.PositionItem, separator2, this.MoveNextItem, this.MoveLastItem, separator3, this.AddNewItem, this.DeleteItem });
            }
        }

        /// <summary>Disables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> during the component's initialization.</summary>
        public void BeginInit()
        {
            this.Initializing = true;
        }

        /// <summary>Enables updates to the <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton"></see> controls of the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> after the component's initialization has concluded.</summary>
        public void EndInit()
        {
            this.Initializing = false;
            this.RefreshItemsInternal();
        }

        /// <summary>Causes form validation to occur and returns whether validation was successful.</summary>
        /// <returns>true if validation was successful and focus can shift to the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see>; otherwise, false.</returns>
        public bool Validate()
        {
            return true;
        }

        #endregion

        #region Protected Methods

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.BindingNavigator"></see> and optionally releases the managed resources. </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                this.BindingSource = null;
            }
            base.Dispose(blnDisposing);
        }



        /// <summary>Raises the <see cref="E:System.Windows.Forms.BindingNavigator.RefreshItems"></see> event.</summary>
        protected virtual void OnRefreshItems()
        {
            this.RefreshItemsCore();

            // Raise event if needed
            EventHandler objEventHandler = this.RefreshItemsHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Refreshes the state of the standard items to reflect the current state of the data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void RefreshItemsCore()
        {
            int intCount;
            int num2;
            bool blnAllowNew;
            bool blnAllowRemove;

            //create reference to AddNewItem property          
            ToolBarButton objAddNewItem = this.AddNewItem;

            //create reference to BindingSource property          
            BindingSource objBindingSource = this.BindingSource;

            //create reference to MoveFirst property          
            ToolBarButton objMoveFirstItem = this.MoveFirstItem;

            //create reference to Previous property          
            ToolBarButton objMovePreviousItem = this.MovePreviousItem;

            //create reference to MoveNext property          
            ToolBarButton objMoveNextItem = this.MoveNextItem;

            //create reference to MoveLast property          
            ToolBarButton objMoveLastItem = this.MoveLastItem;

            //create reference to Delete property          
            ToolBarButton objDeleteItem = this.DeleteItem;

            //create reference to Position property          
            ToolBarButton objPositionItem = this.PositionItem;

            if (objBindingSource == null)
            {
                intCount = 0;
                num2 = 0;
                blnAllowNew = false;
                blnAllowRemove = false;
            }
            else
            {
                intCount = this.BindingSource.Count;
                num2 = this.BindingSource.Position + 1;
                blnAllowNew = this.BindingSource.AllowNew;
                blnAllowRemove = this.BindingSource.AllowRemove;
            }
            if (!base.DesignMode)
            {
                if (objMoveFirstItem != null)
                {
                    objMoveFirstItem.Enabled = num2 > 1;
                }
                if (objMovePreviousItem != null)
                {
                    objMovePreviousItem.Enabled = num2 > 1;
                }
                if (objMoveNextItem != null)
                {
                    objMoveNextItem.Enabled = num2 < intCount;
                }
                if (objMoveLastItem != null)
                {
                    objMoveLastItem.Enabled = num2 < intCount;
                }
                if (this.AddNewItem != null)
                {
                    objAddNewItem.Enabled = blnAllowNew;
                }
                if (objDeleteItem != null)
                {
                    objDeleteItem.Enabled = blnAllowRemove && (intCount > 0);
                }
                if (objPositionItem != null)
                {
                    objPositionItem.Enabled = (num2 > 0) && (intCount > 0);
                    
                }
            }
            if (objPositionItem != null)
            {
                objPositionItem.Text =  base.DesignMode ? this.CountItemFormat : string.Format(CultureInfo.CurrentCulture, this.CountItemFormat, new object[] {num2.ToString(CultureInfo.CurrentCulture), intCount });
            }
        }

        #endregion

        #region Private Methods

        // Called when assignment is needed without the call to this.RefreshItemsInternal() as 
        // in the public property CountItemFormat setter.
        private void SetCountItemFormatDirectly(string strValue)
        {
            if (this.CountItemFormat != strValue)
            {
                this.SetValue<string>(BindingNavigator.CountItemFormatProperty, strValue);
            }
        }

        private void AcceptNewPosition()
        {
            BindingSource objBindingSource = this.BindingSource;

            ToolBarButton objPositionItem = this.PositionItem;

            if ((objPositionItem != null) && (objBindingSource != null))
            {
                int intPosition = objBindingSource.Position;
                try
                {
                    intPosition = Convert.ToInt32(objPositionItem.Text, CultureInfo.CurrentCulture) - 1;
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
                if (intPosition != objBindingSource.Position)
                {
                    objBindingSource.Position = intPosition;
                }
                this.RefreshItemsInternal();
            }
        }

        private void CancelNewPosition()
        {
            this.RefreshItemsInternal();
        }

        private void OnAddNew(object sender, EventArgs e)
        {

            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.AddNew();
                this.RefreshItemsInternal();
            }
        }

        private void OnBindingSourceListChanged(object sender, ListChangedEventArgs e)
        {
            this.RefreshItemsInternal();
        }

        private void OnBindingSourceStateChanged(object sender, EventArgs e)
        {
            this.RefreshItemsInternal();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.RemoveCurrent();
                this.RefreshItemsInternal();
            }
        }

        private void OnMoveFirst(object sender, EventArgs e)
        {
            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.MoveFirst();
                this.RefreshItemsInternal();
            }
        }

        private void OnMoveLast(object sender, EventArgs e)
        {
            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.MoveLast();
                this.RefreshItemsInternal();
            }
        }

        private void OnMoveNext(object sender, EventArgs e)
        {
            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.MoveNext();
                this.RefreshItemsInternal();
            }
        }

        private void OnMovePrevious(object sender, EventArgs e)
        {
            BindingSource objBindingSource = this.BindingSource;

            if (this.Validate() && (objBindingSource != null))
            {
                objBindingSource.MovePrevious();
                this.RefreshItemsInternal();
            }
        }

        private void OnPositionKey(object sender, KeyEventArgs e)
        {
            Keys enmKeyCode = e.KeyCode;
            if (enmKeyCode != Keys.Return)
            {
                if (enmKeyCode != Keys.Escape)
                {
                    return;
                }
            }
            else
            {
                this.AcceptNewPosition();
                return;
            }
            this.CancelNewPosition();
        }

        private void OnPositionLostFocus(object sender, EventArgs e)
        {
            this.AcceptNewPosition();
        }

        private void RefreshItemsInternal()
        {
            if (!this.Initializing)
            {
                this.OnRefreshItems();
            }
        }

        private void ResetCountItemFormat()
        {
            this.SetCountItemFormatDirectly(SR.GetString("BindingNavigatorCountItemFormat"));
        }

        private bool ShouldSerializeCountItemFormat()
        {
            string strCountItemFormat = this.CountItemFormat;

            return (strCountItemFormat != SR.GetString("BindingNavigatorCountItemFormat"));
        }

        private BindingSource WireUpBindingSource(BindingSource oldBindingSource, BindingSource newBindingSource)
        {
            if (oldBindingSource != newBindingSource)
            {
                if (oldBindingSource != null)
                {
                    oldBindingSource.PositionChanged -= new EventHandler(this.OnBindingSourceStateChanged);
                    oldBindingSource.CurrentChanged -= new EventHandler(this.OnBindingSourceStateChanged);
                    oldBindingSource.CurrentItemChanged -= new EventHandler(this.OnBindingSourceStateChanged);
                    oldBindingSource.DataSourceChanged -= new EventHandler(this.OnBindingSourceStateChanged);
                    oldBindingSource.DataMemberChanged -= new EventHandler(this.OnBindingSourceStateChanged);
                    oldBindingSource.ListChanged -= new ListChangedEventHandler(this.OnBindingSourceListChanged);
                }
                if (newBindingSource != null)
                {
                    newBindingSource.PositionChanged += new EventHandler(this.OnBindingSourceStateChanged);
                    newBindingSource.CurrentChanged += new EventHandler(this.OnBindingSourceStateChanged);
                    newBindingSource.CurrentItemChanged += new EventHandler(this.OnBindingSourceStateChanged);
                    newBindingSource.DataSourceChanged += new EventHandler(this.OnBindingSourceStateChanged);
                    newBindingSource.DataMemberChanged += new EventHandler(this.OnBindingSourceStateChanged);
                    newBindingSource.ListChanged += new ListChangedEventHandler(this.OnBindingSourceListChanged);
                }
                oldBindingSource = newBindingSource;
                this.RefreshItemsInternal();
            }
            return oldBindingSource;
        }

        private ToolBarButton WireUpButton(ToolBarButton oldButton, ToolBarButton newButton, EventHandler clickHandler)
        {
            if (oldButton != newButton)
            {
                if (oldButton != null)
                {
                    oldButton.Click -= clickHandler;
                }
                if (newButton != null)
                {
                    newButton.Click += clickHandler;
                }
                oldButton = newButton;
                this.RefreshItemsInternal();


            }

            return oldButton;
        }

        private ToolBarButton WireUpLabel(ToolBarButton oldLabel, ToolBarButton newLabel)
        {
            if (oldLabel != newLabel)
            {
                oldLabel = newLabel;
                this.RefreshItemsInternal();
            }
            return oldLabel;
        }


        private ToolBarButton WireUpTextBox(ToolBarButton oldTextBox, ToolBarButton newTextBox, KeyEventHandler keyUpHandler, EventHandler lostFocusHandler)
        {
            if (oldTextBox != newTextBox)
            {
                //ToolStripControlHost host = oldTextBox as ToolStripControlHost;
                //ToolStripControlHost host2 = newTextBox as ToolStripControlHost;
                //if (host != null)
                //{
                //    host.KeyUp -= keyUpHandler;
                //    host.LostFocus -= lostFocusHandler;
                //}
                //if (host2 != null)
                //{
                //    host2.KeyUp += keyUpHandler;
                //    host2.LostFocus += lostFocusHandler;
                //}
                oldTextBox = newTextBox;
                this.RefreshItemsInternal();
            }
            return oldTextBox;
        }

        #endregion

        #endregion
    }
}
