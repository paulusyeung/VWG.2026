#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Drawing.Design;
using System.Globalization;
using Gizmox.WebGUI.Forms.Client;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents a Windows spin box (also known as an up-down control) that displays string values.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(DomainUpDown), "DomainUpDown_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(DomainUpDown), "DomainUpDown.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DomainUpDownController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DomainUpDownController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("Items"), DefaultEvent("SelectedItemChanged"), SRDescription("DescriptionDomainUpDown")]

    [MetadataTag(WGTags.DomainUpDown)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DomainUpDownSkin)), Serializable()]
    /// <summary>Represents a Windows spin box (also known as an up-down control) that displays string values.</summary>
    /// <filterpriority>2</filterpriority>    
    public class DomainUpDown : UpDownBase
    {

        #region  Fields

        /// <summary>
        /// The SelectedItemChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectedItemChangedEvent = SerializableEvent.Register("SelectedItemChanged", typeof(EventHandler), typeof(DomainUpDown));

        /// <summary>
        /// Provides a property reference to Wrap property.
        /// </summary>
        private static SerializableProperty WrapProperty = SerializableProperty.Register("Wrap", typeof(bool), typeof(DomainUpDown), new SerializablePropertyMetadata(false));

        /// <summary>
        /// The index of the domain.
        /// </summary>
        private int mintDomainIndex = -1;

        /// <summary>
        /// A flag indicating if items we sorted
        /// </summary>
        private bool mblnItemsWhereSorted = false;

        /// <summary>
        /// The domain up down items collection 
        /// </summary>
        private DomainUpDownItemCollection mobjItems = null;

        /// <summary>
        /// The current editing value
        /// </summary>
        private string mstrStringValue = string.Empty;

        #endregion

        #region  Constructors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
        public DomainUpDown()
        {
            this.Text = string.Empty;
        }

        #endregion

        #region  Properties

        /// <summary>A collection of objects assigned to the spin box (also known as an up-down control).</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.DomainUpDown.DomainUpDownItemCollection"></see> that contains an <see cref="T:System.Object"></see> collection.</returns>
        /// <filterpriority>1</filterpriority>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Localizable(true), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRCategory("CatData"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("DomainUpDownItemsDescr")]
#else
        [Localizable(true), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), SRCategory("CatData"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("DomainUpDownItemsDescr")]
#endif
        public DomainUpDownItemCollection Items
        {
            get
            {
                // If items needs to be created
                if (mobjItems == null)
                {
                    // Create items collection
                    mobjItems = new DomainUpDownItemCollection(this);
                }

                // Return the items collection
                return mobjItems;
            }
        }

        /// <summary>Gets or sets the spacing between the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control's contents and its edges.</summary>
        /// <returns><see cref="F:System.Windows.Forms.Padding.Empty"></see> in all cases.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }

        /// <summary>Gets or sets the index value of the selected item.</summary>
        /// <returns>The zero-based index value of the selected item. The default value is -1.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than the default, -1.-or- The assigned value is greater than the <see cref="P:System.Windows.Forms.DomainUpDown.Items"></see> count. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(-1), SRDescription("DomainUpDownSelectedIndexDescr"), SRCategory("CatAppearance"), Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                if (base.UserEdit)
                {
                    return -1;
                }
                return this.mintDomainIndex;
            }
            set
            {
                if (value != this.SelectedIndex)
                {
                    this.SelectedIndexInternal = value;

                    // Register a partial rendering of visual attributes.
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// The currently selected index
        /// </summary>
        private int SelectedIndexInternal
        {
            set
            {
                if ((value < -1) || (value >= this.Items.Count))
                {
                    throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidArgument", new object[] { "SelectedIndex", value.ToString(CultureInfo.CurrentCulture) }));
                }
                if (value != this.SelectedIndex)
                {
                    this.SelectIndex(value);
                }
            }
        }

        /// <summary>Gets or sets the selected item based on the index value of the selected item in the collection.</summary>
        /// <returns>The selected item based on the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedIndex"></see> value. The default value is null.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("DomainUpDownSelectedItemDescr"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                int intSelectedIndex = this.SelectedIndex;
                if (intSelectedIndex != -1)
                {
                    return this.Items[intSelectedIndex];
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    this.SelectedIndex = -1;
                }
                else
                {
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if ((value != null) && value.Equals(this.Items[i]))
                        {
                            this.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the selected item changed handler.
        /// </summary>
        /// <value>The selected item changed handler.</value>
        private EventHandler SelectedItemChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(DomainUpDown.SelectedItemChangedEvent);
            }
        }





        /// <summary>Gets or sets a value indicating whether the item collection is sorted.</summary>
        /// <returns>true if the item collection is sorted; otherwise, false. The default value is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("DomainUpDownSortedDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool Sorted
        {
            get
            {
                return this.GetState(ControlState.Sorted);
            }
            set
            {
                // If value had changed
                if (this.SetStateWithCheck(ControlState.Sorted, value))
                {
                    // Update the control to reflect changes
                    this.Update();
                }
            }
        }




        /// <summary>Gets or sets a value indicating whether the collection of items continues to the first or last item if the user continues past the end of the list.</summary>
        /// <returns>true if the list starts again when the user reaches the beginning or end of the collection; otherwise, false. The default value is false.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("DomainUpDownWrapDescr"), SRCategory("CatBehavior"), Localizable(true), DefaultValue(false)]
        public bool Wrap
        {
            get
            {
                return this.GetValue<bool>(DomainUpDown.WrapProperty);
            }
            set
            {
                // Set the wrap property and update if value had changed
                if (this.SetValue<bool>(DomainUpDown.WrapProperty, value))
                {
                    this.Update();
                }
            }
        }

        #endregion

        #region Delegates and Events

        // Events 

        /// <summary>Occurs when the value of the <see cref="P:System.Windows.Forms.DomainUpDown.Padding"></see> property changes.</summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler PaddingChanged
        {
            add
            {
                base.PaddingChanged += value;
            }
            remove
            {
                base.PaddingChanged -= value;
            }
        }

        /// <summary>Occurs when the <see cref="P:System.Windows.Forms.DomainUpDown.SelectedItem"></see> property has been changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("DomainUpDownOnSelectedItemChangedDescr")]
        public event EventHandler SelectedItemChanged
        {
            add
            {
                this.AddCriticalHandler(DomainUpDown.SelectedItemChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(DomainUpDown.SelectedItemChangedEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("DomainUpDownOnSelectedItemChangedDescr"), Category("Client")]
        public event ClientEventHandler ClientSelectedItemChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        #endregion

        #region Methods

        // Public Methods 

        /// <summary>Displays the next item in the object collection.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override void DownButton()
        {
            if ((this.Items != null) && (this.Items.Count > 0))
            {
                int index = -1;
                if (base.UserEdit)
                {
                    index = this.MatchIndex(this.Text, false, this.mintDomainIndex);
                }
                if (index != -1)
                {
                    this.SelectIndex(index);
                }
                else if (this.mintDomainIndex < (this.Items.Count - 1))
                {
                    this.SelectIndex(this.mintDomainIndex + 1);
                }
                else if (this.Wrap)
                {
                    this.SelectIndex(0);
                }
            }
        }

        /// <summary>Returns a string that represents the <see cref="T:System.Windows.Forms.DomainUpDown"></see> control.</summary>
        /// <returns>A string that represents the current <see cref="T:System.Windows.Forms.DomainUpDown"></see>. </returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            string str = base.ToString();
            if (this.Items != null)
            {
                str = (str + ", Items.Count: " + this.Items.Count.ToString(CultureInfo.CurrentCulture)) + ", SelectedIndex: " + this.SelectedIndex.ToString(CultureInfo.CurrentCulture);
            }
            return str;
        }

        /// <summary>Displays the previous item in the collection.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override void UpButton()
        {
            if (((this.Items != null) && (this.Items.Count > 0)) && (this.mintDomainIndex != -1))
            {
                int index = -1;
                if (base.UserEdit)
                {
                    index = this.MatchIndex(this.Text, false, this.mintDomainIndex);
                }
                if (index != -1)
                {
                    this.SelectIndex(index);
                }
                else if (this.mintDomainIndex > 0)
                {
                    this.SelectIndex(this.mintDomainIndex - 1);
                }
                else if (this.Wrap)
                {
                    this.SelectIndex(this.Items.Count - 1);
                }
            }
        }

        // Protected Methods 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (SelectedItemChangedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
        /// <param name="objSource">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnChanged(object objSource, EventArgs e)
        {
            this.OnSelectedItemChanged(objSource, e);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.DomainUpDown.SelectedItemChanged"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected void OnSelectedItemChanged(object objSource, EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.SelectedItemChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event. </summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
        protected override void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e)
        {
            if (base.ReadOnly)
            {
                char[] arrChars = new char[] { e.KeyChar };
                switch (char.GetUnicodeCategory(arrChars[0]))
                {
                    case UnicodeCategory.LetterNumber:
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                    case UnicodeCategory.MathSymbol:
                    case UnicodeCategory.OtherLetter:
                    case UnicodeCategory.OtherNumber:
                    case UnicodeCategory.UppercaseLetter:
                        {
                            int index = this.MatchIndex(new string(arrChars), false, this.mintDomainIndex + 1);
                            if (index != -1)
                            {
                                this.SelectIndex(index);
                            }
                            e.Handled = true;
                            break;
                        }
                }
            }
            base.OnTextBoxKeyPress(objSource, e);
        }

        /// <summary>
        /// Renders the specified obj context.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            //The item collection 
            DomainUpDownItemCollection objItems = this.Items;
            //Start render the xml options node
            objWriter.WriteStartElement(WGTags.Options);

            //Render node for each item
            for (int intIndex = 0; intIndex < objItems.Count; intIndex++)
            {
                objWriter.WriteStartElement(WGTags.Option);
                RenderItemAttributes(objWriter, objItems[intIndex], intIndex);
                objWriter.WriteEndElement();
            }
            //Render end element
            objWriter.WriteEndElement();
        }


        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render Value attribute 
            if (this.mintDomainIndex >= 0)
            {
                objWriter.WriteAttributeString(WGAttributes.Value, this.mintDomainIndex.ToString());
            }

            // Render Text attribute 
            objWriter.WriteAttributeText(WGAttributes.Text, this.Text, TextFilter.CarriageReturn | TextFilter.NewLine);
        }


        /// <summary>
        /// Renders the item attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objItem">The obj item.</param>
        /// <param name="intIndex">Index of the int.</param>
        internal protected virtual void RenderItemAttributes(IResponseWriter objWriter, object objItem, int intIndex)
        {
            //Render Value attribute 
            objWriter.WriteAttributeString(WGAttributes.Index, intIndex.ToString());

            if (objItem != null)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, objItem.ToString(), TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Renders the updated attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            //Render the updated attributes
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            // Check the visual attribute type.
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Rende text and value attributes.
                objWriter.WriteAttributeString(WGAttributes.Value, this.mintDomainIndex.ToString());
                objWriter.WriteAttributeText(WGAttributes.Text, this.Text.ToString(), TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Sets up down value.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
        protected override void SetUpDownValue(string strValue, bool blnIsIndex)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                if (blnIsIndex)
                {
                    int intIndex = Convert.ToInt32(strValue);
                    if (intIndex >= 0 && intIndex < this.Items.Count)
                    {
                        this.SelectedIndexInternal = intIndex;
                    }
                }
                else
                {
                    this.SetTextInternal(strValue);
                }
            }
        }

        /// <summary>Updates the text in the spin box (also known as an up-down control) to display the selected item.</summary>
        protected override void UpdateEditText()
        {
            base.UserEdit = false;
            base.ChangingText = true;
            this.Text = this.mstrStringValue;
        }


        /// <summary>
        /// Selects the index.
        /// </summary>
        /// <param name="index">The index.</param>
        private void SelectIndex(int index)
        {
            if (((this.Items == null) || (index < -1)) || (index >= this.Items.Count))
            {
                index = -1;
            }
            else
            {
                this.mintDomainIndex = index;
                if (this.mintDomainIndex >= 0)
                {
                    this.mstrStringValue = this.Items[this.mintDomainIndex].ToString();
                    base.UserEdit = false;
                    this.UpdateEditText();
                }
                else
                {
                    base.UserEdit = true;
                }
            }
        }

        /// <summary>
        /// Sorts the domain items.
        /// </summary>
        private void SortDomainItems()
        {
            if (!this.mblnItemsWhereSorted)
            {
                this.mblnItemsWhereSorted = true;
                try
                {
                    if (this.Sorted && (this.Items != null))
                    {
                        ArrayList.Adapter(this.Items).Sort(new DomainUpDownItemCompare());
                        if (!base.UserEdit)
                        {
                            int index = this.MatchIndex(this.mstrStringValue, true);
                            if (index != -1)
                            {
                                this.SelectIndex(index);
                            }
                        }
                    }
                }
                finally
                {
                    this.mblnItemsWhereSorted = false;
                }
            }
        }


        /// <summary>
        /// Matches the index.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="blnComplete">if set to <c>true</c> [complete].</param>
        /// <returns></returns>
        internal int MatchIndex(string strText, bool blnComplete)
        {
            return this.MatchIndex(strText, blnComplete, this.mintDomainIndex);
        }

        /// <summary>
        /// Matches the index.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="blnComplete">if set to <c>true</c> [complete].</param>
        /// <param name="intStartPosition">The start position.</param>
        /// <returns></returns>
        internal int MatchIndex(string strText, bool blnComplete, int intStartPosition)
        {
            if (this.Items == null)
            {
                return -1;
            }
            if (strText.Length < 1)
            {
                return -1;
            }
            if (this.Items.Count <= 0)
            {
                return -1;
            }
            if (intStartPosition < 0)
            {
                intStartPosition = this.Items.Count - 1;
            }
            if (intStartPosition >= this.Items.Count)
            {
                intStartPosition = 0;
            }
            int num = intStartPosition;
            int num2 = -1;
            bool blnFlag = false;
            if (!blnComplete)
            {
                strText = strText.ToUpper(CultureInfo.InvariantCulture);
            }
            do
            {
                if (blnComplete)
                {
                    blnFlag = this.Items[num].ToString().Equals(strText);
                }
                else
                {
                    blnFlag = this.Items[num].ToString().ToUpper(CultureInfo.InvariantCulture).StartsWith(strText);
                }
                if (blnFlag)
                {
                    num2 = num;
                }
                num++;
                if (num >= this.Items.Count)
                {
                    num = 0;
                }
            }
            while (!blnFlag && (num != intStartPosition));
            return num2;
        }

        #endregion

        #region  Nested Classes

        /// <summary>Encapsulates a collection of objects for use by the <see cref="T:System.Windows.Forms.DomainUpDown"></see> class.</summary>
        [Serializable]
        public class DomainUpDownItemCollection : ArrayList
        {
            private DomainUpDown mobjOwner;

            internal DomainUpDownItemCollection(DomainUpDown objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>Adds the specified object to the end of the collection.</summary>
            /// <returns>The zero-based index value of the <see cref="T:System.Object"></see> added to the collection.</returns>
            /// <param name="objItem">The <see cref="T:System.Object"></see> to be added to the end of the collection. </param>
            public override int Add(object objItem)
            {
                int num = base.Add(objItem);
                if (this.mobjOwner.Sorted)
                {
                    this.mobjOwner.SortDomainItems();
                }
                mobjOwner.Update();
                return num;
            }

            /// <summary>Inserts the specified object into the collection at the specified location.</summary>
            /// <param name="objItem">The <see cref="T:System.Object"></see> to insert. </param>
            /// <param name="index">The indexed location within the collection to insert the <see cref="T:System.Object"></see>. </param>
            public override void Insert(int index, object objItem)
            {
                base.Insert(index, objItem);
                if (this.mobjOwner.Sorted)
                {
                    this.mobjOwner.SortDomainItems();
                }
                mobjOwner.Update();
            }

            /// <summary>Removes the specified item from the collection.</summary>
            /// <param name="objItem">The <see cref="T:System.Object"></see> to remove from the collection. </param>
            public override void Remove(object objItem)
            {
                int index = this.IndexOf(objItem);
                if (index == -1)
                {
                    throw new ArgumentOutOfRangeException("item", SR.GetString("InvalidArgument", new object[] { "item", objItem.ToString() }));
                }
                this.RemoveAt(index);
                mobjOwner.Update();
            }

            /// <summary>Removes the item from the specified location in the collection.</summary>
            /// <param name="intItem">The indexed location of the <see cref="T:System.Object"></see> in the collection. </param>
            public override void RemoveAt(int intItem)
            {
                base.RemoveAt(intItem);
                if (intItem < this.mobjOwner.mintDomainIndex)
                {
                    this.mobjOwner.SelectIndex(this.mobjOwner.mintDomainIndex - 1);
                }
                else if (intItem == this.mobjOwner.mintDomainIndex)
                {
                    this.mobjOwner.SelectIndex(-1);
                }
                else
                {
                    this.mobjOwner.Update();
                }

            }

            /// <summary>Gets or sets the item at the specified indexed location in the collection.</summary>
            /// <returns>An <see cref="T:System.Object"></see> that represents the item at the specified indexed location.</returns>
            /// <param name="index">The indexed location of the item in the collection. </param>
            [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public override object this[int index]
            {
                get
                {
                    return base[index];
                }
                set
                {
                    base[index] = value;
                    if (this.mobjOwner.SelectedIndex == index)
                    {
                        this.mobjOwner.SelectIndex(index);
                    }
                    if (this.mobjOwner.Sorted)
                    {
                        this.mobjOwner.SortDomainItems();
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        private sealed class DomainUpDownItemCompare : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                if ((obj1 != obj2) && ((obj1 != null) && (obj2 != null)))
                {
                    return string.Compare(obj1.ToString(), obj2.ToString(), false, CultureInfo.CurrentCulture);
                }
                return 0;
            }
        }

        #endregion


    }
}
