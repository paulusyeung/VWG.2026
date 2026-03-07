#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using System.Runtime.InteropServices;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Specifies whether an object or text is aligned to the left or right of a reference point.
    /// </summary>
    public enum LeftRightAlignment
    {
        /// <summary>
        /// The object or text is aligned to the left of the reference point.
        /// </summary>
        Left,
        /// <summary>
        /// The object or text is aligned to the right of the reference point.
        /// </summary>
        Right
    }

    #region  UpDownBase class

    /// <summary>
    /// Implements the basic functionality required by a spin box (also known as an up-down control).
    /// </summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.UpDownBaseSkin)), Serializable()]
    public abstract class UpDownBase : ContainerControl
    {

        #region  Fields

        /// <summary>
        /// Provides a property reference to ChangingText Property.
        /// </summary>
        private static SerializableProperty ChangingTextProperty = SerializableProperty.Register("ChangingText", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to HideButtons property.
        /// </summary>
        private static SerializableProperty HideButtonsProperty = SerializableProperty.Register("HideButtons", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to UpDownAlign  Property.
        /// </summary>        
        private static SerializableProperty InterceptArrowKeysProperty = SerializableProperty.Register("InterceptArrowKeys", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to HorizontalAlignment property.
        /// </summary>
        private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(HorizontalAlignment), typeof(UpDownBase), new SerializablePropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        /// Provides a property reference to Text property.
        /// </summary>
        private static SerializableProperty TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(UpDownBase), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to UpDownAlign  Property.
        /// </summary>        
        private static SerializableProperty UpDownAlignProperty = SerializableProperty.Register("UpDownAlign", typeof(LeftRightAlignment), typeof(UpDownBase), new SerializablePropertyMetadata(LeftRightAlignment.Right));

        /// <summary>
        /// Provides a property reference to HideButtons property.
        /// </summary>
        private static SerializableProperty UserEditProperty = SerializableProperty.Register("UserEdit", typeof(bool), typeof(UpDownBase), new SerializablePropertyMetadata(false));

        #endregion

        #region Enums

        /// <summary>
        /// 
        /// </summary>
        internal enum ButtonID
        {
            /// <summary>
            /// 
            /// </summary>
            None,
            /// <summary>
            /// 
            /// </summary>
            Up,
            /// <summary>
            /// 
            /// </summary>
            Down
        }

        #endregion

        #region  Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class.
        /// </summary>
        public UpDownBase()
        {
            base.SetStyle(ControlStyles.FixedHeight | ControlStyles.ResizeRedraw | ControlStyles.Opaque, true);
            base.SetStyle(ControlStyles.StandardClick, false);
            base.SetStyle(ControlStyles.UseTextForAccessibility, false);
        }

        #endregion

        #region  Properties

        /// <summary>Gets a value indicating whether the container will allow the user to scroll to any controls placed outside of its visible boundaries.</summary>
        /// <returns>false in all cases.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value indicating whether the control should automatically resize based on its contents.</summary>
        /// <returns>true to indicate the control should automatically resize based on its contents; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        /// <summary>Gets or sets the layout of the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.BackgroundImage"></see> of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see>.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        /// <summary>Gets or sets the border style for the spin box (also known as an up-down control).</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.BorderStyle.Fixed3D"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("UpDownBaseBorderStyleDescr"), SRCategory("CatAppearance"), DefaultValue(2), DispId(-504)]
        public override BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the text property is being changed internally by its parent class.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property is being changed internally by the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class; otherwise, false.</returns>
        protected bool ChangingText
        {
            get
            {
                return this.GetValue<bool>(UpDownBase.ChangingTextProperty);
            }
            set
            {
                this.SetValue<bool>(UpDownBase.ChangingTextProperty, value);
            }
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(120, this.PreferredHeight);
            }
        }

        /// <summary>Gets the dock padding settings for all edges of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> control.</summary>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScrollableControl.DockPaddingEdges DockPadding
        {
            get
            {
                return base.DockPadding;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the buttons are hidden or not.
        /// </summary>
        /// <returns>true if the buttons are hidden; otherwise, false. The default is false.</returns>
        [DefaultValue(false), SRCategory("CatAppearance")]
        public bool HideButtons
        {
            get
            {
                return this.GetValue<bool>(UpDownBase.HideButtonsProperty);
            }
            set
            {

                if (this.SetValue<bool>(UpDownBase.HideButtonsProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the user can use the UP ARROW and DOWN ARROW keys to select values.</summary>
        /// <returns>true if the control allows the use of the UP ARROW and DOWN ARROW keys to select values; otherwise, false. The default value is true.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(true), SRDescription("UpDownBaseInterceptArrowKeysDescr"), SRCategory("CatBehavior")]
        public bool InterceptArrowKeys
        {
            get
            {
                return this.GetValue<bool>(UpDownBase.InterceptArrowKeysProperty);
            }
            set
            {
                if (this.SetValue<bool>(UpDownBase.InterceptArrowKeysProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the maximum size of the spin box (also known as an up-down control).</summary>
        /// <returns>The <see cref="T:System.Drawing.Size"></see>, which is the maximum size of the spin box.</returns>
        /// <filterpriority>1</filterpriority>
        public override Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }
            set
            {
                base.MaximumSize = new Size(value.Width, 0);
            }
        }

        /// <summary>Gets or sets the minimum size of the spin box (also known as an up-down control).</summary>
        /// <returns>The <see cref="T:System.Drawing.Size"></see>, which is the minimum size of the spin box.</returns>
        /// <filterpriority>1</filterpriority>
        public override Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }
            set
            {
                base.MinimumSize = new Size(value.Width, 0);
            }
        }

        /// <summary>Gets the height of the spin box (also known as an up-down control).</summary>
        /// <returns>The height, in pixels, of the spin box.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced), SRDescription("UpDownBasePreferredHeightDescr"), SRCategory("CatLayout"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PreferredHeight
        {
            get
            {
                int intFontHeight = Convert.ToInt32(CommonUtils.GetFontHeight(this.Font));
                if (this.BorderStyle != BorderStyle.None)
                {
                    return (intFontHeight + ((this.BorderWidth.Bottom + this.BorderWidth.Left + this.BorderWidth.Right + this.BorderWidth.Top) + 3));
                }
                return (intFontHeight + 3);
            }
        }

        /// <summary>Gets or sets a value indicating whether the user can edit the band's cells.</summary>
        /// <returns>true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public virtual bool ReadOnly
        {
            get
            {
                return this.GetState(ComponentState.ReadOnly);
            }
            set
            {
                // Set the readonly state and update control if value has changed
                if (this.SetStateWithCheck(ComponentState.ReadOnly, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the text displayed in the spin box (also known as an up-down control).</summary>
        /// <returns>The string value displayed in the spin box.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true)]
        public override string Text
        {
            get
            {
                return this.GetValue<string>(UpDownBase.TextProperty);
            }
            set
            {
                if (this.SetTextInternal(value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the alignment of the text in the spin box (also known as an up-down control).</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), DefaultValue(HorizontalAlignment.Left), SRDescription("UpDownBaseTextAlignDescr"), Localizable(true)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.GetValue<HorizontalAlignment>(TextAlignProperty);
            }
            set
            {
                if (this.SetValue<HorizontalAlignment>(TextAlignProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text internal.
        /// </summary>
        /// <param name="strValue">The value.</param>
        /// <returns></returns>
        protected bool SetTextInternal(string strValue)
        {
            if (this.SetValue<string>(UpDownBase.TextProperty, strValue))
            {
                this.OnTextBoxTextChanged(this, EventArgs.Empty);
                this.ChangingText = false;
                if (this.UserEdit)
                {
                    this.ValidateEditText();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Gets or sets the alignment of the up and down buttons on the spin box (also known as an up-down control).</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.LeftRightAlignment.Right"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("UpDownBaseAlignmentDescr"), Localizable(true), DefaultValue(1), SRCategory("CatAppearance")]
        public LeftRightAlignment UpDownAlign
        {
            get
            {
                return this.GetValue<LeftRightAlignment>(UpDownBase.UpDownAlignProperty);
            }
            set
            {
                if (this.SetValue<LeftRightAlignment>(UpDownBase.UpDownAlignProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether a value has been entered by the user.</summary>
        /// <returns>true if the user has changed the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property; otherwise, false.</returns>
        protected bool UserEdit
        {
            get
            {
                return this.GetValue<bool>(UpDownBase.UserEditProperty);
            }
            set
            {
                this.SetValue<bool>(UpDownBase.UserEditProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports focus events].
        /// </summary>
        /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
        protected internal override bool SupportsFocusEvents
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether raise click event on mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the resizable allowed directions.
        /// </summary>
        protected override string[] ResizableAllowedDirections
        {
            get
            {
                return new string[] { "e", "w" };
            }
        }

        #endregion

        #region  Methods

        /// <summary>
        /// When overridden in a derived class, 
        /// handles the clicking of the down button on the spin box 
        /// (also known as an up-down control).</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void DownButton();

        /// <summary>
        /// Selects a range of text in the spin box 
        /// (also known as an up-down control) specifying 
        /// the starting position and number of characters 
        /// to select.
        /// </summary>
        /// <param name="intStart">The position of the first character to be selected. </param>
        /// <param name="intLength">The total number of characters to be selected. </param>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Select(int intStart, int intLength)
        {

            this.InvokeMethodWithId("UpDownBase_SetSelection", intStart, intLength);
        }

        /// <summary>When overridden in a derived class, handles the clicking of the up button on the spin box (also known as an up-down control).</summary>
        /// <filterpriority>1</filterpriority>
        public abstract void UpButton();

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "ValueChange":
                    string strValue = CommonUtils.DecodeText(objEvent[WGAttributes.Value]);
                    bool blnIsIndex = (objEvent[WGAttributes.Index] == "1");

                    if (!string.IsNullOrEmpty(strValue))
                    {
                        this.SetUpDownValue(strValue, blnIsIndex);
                    }
                    break;
                default:
                    base.FireEvent(objEvent);
                    break;
            }
        }

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            KeyCaptures enmKeyCaptures = base.GetKeyEventCaptures();
            enmKeyCaptures |= KeyCaptures.UpKeyCapture;
            enmKeyCaptures |= KeyCaptures.DownKeyCapture;
            enmKeyCaptures |= KeyCaptures.EndKeyCapture;
            enmKeyCaptures |= KeyCaptures.HomeKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageDownKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageUpKeyCapture;
            return enmKeyCaptures;
        }

        /// <summary>When overridden in a derived class, raises the Changed event.</summary>
        /// <param name="objSource">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnChanged(object objSource, EventArgs e)
        {
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.Height = this.PreferredHeight;
            base.OnFontChanged(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        protected virtual void OnTextBoxKeyDown(object objSource, KeyEventArgs e)
        {
            if (this.InterceptArrowKeys)
            {
                if (e.KeyData == Keys.Up)
                {
                    this.UpButton();
                }
                else if (e.KeyData == Keys.Down)
                {
                    this.DownButton();
                }
            }
            if ((e.KeyCode == Keys.Return) && this.UserEdit)
            {
                this.ValidateEditText();
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
        protected virtual void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LostFocus"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnTextBoxLostFocus(object objSource, EventArgs e)
        {
            if (this.UserEdit)
            {
                this.ValidateEditText();
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Resize"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnTextBoxResize(object objSource, EventArgs e)
        {
            base.Height = this.PreferredHeight;
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.TextChanged"></see> event.</summary>
        /// <param name="objSource">The source of the event. </param>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnTextBoxTextChanged(object objSource, EventArgs e)
        {
            if (this.ChangingText)
            {
                this.ChangingText = false;
            }
            else
            {
                this.UserEdit = true;
            }
            this.OnTextChanged(e);
            this.OnChanged(objSource, new EventArgs());
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render the hide buttons flag attribute
            if (this.HideButtons)
            {
                objWriter.WriteAttributeString(WGAttributes.HideButtons, "1");
            }

            // Render the hide ReadOnly flag attribute
            if (this.ReadOnly)
            {
                objWriter.WriteAttributeString(WGAttributes.ReadOnly, "1");
            }

            // Render the InterceptArrowKeys flag attribute
            if (!this.InterceptArrowKeys)
            {
                objWriter.WriteAttributeString(WGAttributes.InterceptArrowKeys, "0");
            }

            if (this.TextAlign != HorizontalAlignment.Center)
            {
                objWriter.WriteAttributeString(WGAttributes.TextAlign, this.TextAlign.ToString());
            }

            LeftRightAlignment enmAlignment = this.UpDownAlign;

            if ((enmAlignment == LeftRightAlignment.Left && !this.Context.RightToLeft) ||
                (enmAlignment == LeftRightAlignment.Right && this.Context.RightToLeft))
            {
                objWriter.WriteAttributeString(WGAttributes.UpDownAlign, LeftRightAlignment.Left.ToString());
            }
        }

        /// <summary>
        /// Sets up down value.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
        protected virtual void SetUpDownValue(string strValue, bool blnIsIndex)
        {
        }

        /// <summary>When overridden in a derived class, updates the text displayed in the spin box (also known as an up-down control).</summary>
        protected abstract void UpdateEditText();

        /// <summary>When overridden in a derived class, validates the text displayed in the spin box (also known as an up-down control).</summary>
        protected virtual void ValidateEditText()
        {
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new UpDownBaseRenderer(this);
        }

        #region  private Methods

        /// <summary>
        /// Called when [up down].
        /// </summary>
        /// <param name="objSource">The source.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.UpDownEventArgs"/> instance containing the event data.</param>
        private void OnUpDown(object objSource, UpDownEventArgs e)
        {
            if (e.ButtonID == 1)
            {
                this.UpButton();
            }
            else if (e.ButtonID == 2)
            {
                this.DownButton();
            }
        }

        #endregion

        #region  internal Methods

        internal override Rectangle ApplyBoundsConstraints(int intSuggestedX, int intSuggestedY, int intProposedWidth, int intProposedHeight)
        {
            return base.ApplyBoundsConstraints(intSuggestedX, intSuggestedY, intProposedWidth, this.PreferredHeight);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
        /// </summary>
        internal virtual void OnStartTimer()
        {
        }

        /// <summary>
        /// Called when [stop timer].
        /// </summary>
        internal virtual void OnStopTimer()
        {
        }

        #endregion

        #endregion
    }

    #endregion

    #region  UpDownEventArgs class

    /// <summary>Provides data for controls that derive from the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    public class UpDownEventArgs : EventArgs
    {

        #region  Fields

        private int mintButtonID;

        #endregion

        #region  Constructors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UpDownEventArgs"></see> class</summary>
        /// <param name="intButtonPushed">The button that was clicked on the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> control.</param>
        public UpDownEventArgs(int intButtonPushed)
        {
            this.mintButtonID = intButtonPushed;
        }

        #endregion

        #region Properties

        /// <summary>Gets a value that represents which button the user clicked.</summary>
        /// <returns>A value that represents which button the user clicked.</returns>
        /// <filterpriority>1</filterpriority>
        public int ButtonID
        {
            get
            {
                return this.mintButtonID;
            }
        }

        #endregion
    }

    #endregion

    #region UpDownBaseRenderer Class

    /// <summary>
    /// Provides support for rendering UpDownBasees
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class UpDownBaseRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpDownBaseRenderer"/> class.
        /// </summary>
        /// <param name="objUpDownBase">The up down base.</param>
        internal UpDownBaseRenderer(UpDownBase objUpDownBase)
            : base(objUpDownBase)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current UpDownBase
            UpDownBase objUpDownBase = this.Control as UpDownBase;
            if (objUpDownBase != null)
            {
                //Write the UpDownBase text
                RenderText(objContext, objGraphics, objUpDownBase.Text, objUpDownBase.Font, objUpDownBase.ForeColor, objUpDownBase.Size, HorizontalAlignment.Left, true);
            }
        }
    }

    #endregion
}
