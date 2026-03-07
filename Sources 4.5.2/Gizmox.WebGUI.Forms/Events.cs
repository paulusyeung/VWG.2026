using System;
using System.Collections;
using System.Text;
using System.Drawing;


namespace Gizmox.WebGUI.Forms
{
    #region KeyEventArgs Class

    /// <summary>
    /// Key event hablder
    /// </summary>
    public delegate void KeyEventHandler(object objSender, KeyEventArgs objArgs);

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class KeyEventArgs : EventArgs
    {
        private Keys menmKeydata;
        private bool mblnHandled = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="enmKeyData">The enm key data.</param>
        public KeyEventArgs(Keys enmKeyData)
        {
            menmKeydata = enmKeyData;
        }

        /// <summary>Gets or sets a value indicating whether the event was handled.</summary>
        /// <returns>true to bypass the control's default handling; otherwise, false to also pass the event along to the default control handler.</returns>
        [Obsolete("Not implemented by design.")]
        public bool Handled
        {
            get
            {
                return this.mblnHandled;
            }
            set
            {
                this.mblnHandled = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="KeyEventArgs"/> is alt.
        /// </summary>
        /// <value><c>true</c> if alt; otherwise, <c>false</c>.</value>
        public virtual bool Alt
        {
            get
            {
                return (menmKeydata & Keys.Alt) == Keys.Alt;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="KeyEventArgs"/> is control.
        /// </summary>
        /// <value><c>true</c> if control; otherwise, <c>false</c>.</value>
        public bool Control
        {
            get
            {
                return (menmKeydata & Keys.Control) == Keys.Control;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="KeyEventArgs"/> is shift.
        /// </summary>
        /// <value><c>true</c> if shift; otherwise, <c>false</c>.</value>
        public virtual bool Shift
        {
            get
            {
                return (menmKeydata & Keys.Shift) == Keys.Shift;
            }
        }

        /// <summary>
        /// Gets the key value.
        /// </summary>
        /// <value>The key value.</value>
        public int KeyValue
        {
            get
            {
                return ((int)menmKeydata) & 0xffff;
            }
        }

        /// <summary>
        /// Gets the key data.
        /// </summary>
        /// <value>The key data.</value>
        public Keys KeyData
        {
            get
            {
                return menmKeydata;
            }
        }

        /// <summary>
        /// Gets the key code.
        /// </summary>
        /// <value>The key code.</value>
        public Keys KeyCode
        {
            get
            {
                Keys enmKeys = menmKeydata & Keys.KeyCode;
                if (!Enum.IsDefined(typeof(Keys), (int)enmKeys))
                {
                    return Keys.None;
                }
                return enmKeys;
            }
        }

        /// <summary>
        /// Gets the modifier flags for a <see cref="E:Gizmox.WebGui.Forms.Control.KeyDown"></see> or <see cref="E:System.Windows.Forms.Control.KeyUp"></see> event. The flags indicate which combination of CTRL, SHIFT, and ALT keys was pressed.
        /// </summary>
        /// <value>The modifiers.</value>
        /// <returns>A <see cref="T:System.Windows.Forms.Keys"></see> value representing one or more modifier flags.</returns>
        public Keys Modifiers
        {
            get
            {
                return (this.menmKeydata & ~Keys.KeyCode);
            }
        }
    }

    #endregion

    #region KeyPressEventArgs Class

    /// <summary>Represents the method that will handle the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event of a <see cref="T:System.Windows.Forms.Control"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void KeyPressEventHandler(object sender, KeyPressEventArgs e);

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class KeyPressEventArgs : EventArgs
    {
        private bool mblnHandled;
        private char mchrKeyChar;

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> class.</summary>
        /// <param name="chrKey">The ASCII character corresponding to the key the user pressed. </param>
        public KeyPressEventArgs(char chrKey)
        {
            this.mchrKeyChar = chrKey;
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event was handled.</summary>
        /// <returns>true if the event is handled; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented by design.")]
        public bool Handled
        {
            get
            {
                return this.mblnHandled;
            }
            set
            {
                this.mblnHandled = value;
            }
        }

        /// <summary>Gets or sets the character corresponding to the key pressed.</summary>
        /// <returns>The ASCII character that is composed. For example, if the user presses SHIFT + K, this property returns an uppercase K.</returns>
        /// <filterpriority>1</filterpriority>
        public char KeyChar
        {
            get
            {
                return this.mchrKeyChar;
            }
            set
            {
                this.mchrKeyChar = value;
            }
        }
    }

    #endregion

    #region MouseEventArgs Class


    /// <summary>
    /// Provides data for the MouseUp, MouseDown, and MouseMove events.
    /// </summary>
    [Serializable()]
    public class MouseEventArgs : EventArgs
    {
        // Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="enmButton">The button.</param>
        /// <param name="intClicks">The clicks.</param>
        /// <param name="intX">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="intDelta">The delta.</param>
        public MouseEventArgs(MouseButtons enmButton, int intClicks, int intX, int intY, int intDelta)
        {
            this.menmButton = enmButton;
            this.mintClicks = intClicks;
            this.mintX = intX;
            this.mintY = intY;
            this.mintDelta = intDelta;
        }

        // Properties
        /// <summary>
        /// Gets which mouse button was pressed.
        /// </summary>
        /// <value>The button.</value>
        public MouseButtons Button
        {
            get
            {
                return this.menmButton;
            }
        }

        /// <summary>
        /// Gets the number of times the mouse button was pressed and released.
        /// </summary>
        /// <value>The clicks.</value>
        public int Clicks
        {
            get
            {
                return this.mintClicks;
            }
        }

        /// <summary>
        /// Gets a signed count of the number of detents the mouse wheel has rotated. A detent is one notch of the mouse wheel.
        /// </summary>
        /// <value>The delta.</value>
        public int Delta
        {
            get
            {
                return this.mintDelta;
            }
        }

		/// <summary>Gets the location of the mouse during the generating mouse event.</summary>
		/// <returns>A <see cref="T:System.Drawing.Point"></see> containing the x- and y- coordinate of the mouse, in pixels.</returns>
		/// <filterpriority>1</filterpriority>
        public Point Location
        {
            get
            {
                return new Point(this.X, this.Y);
            }
        }

        /// <summary>
        /// Gets the x-coordinate of the mouse during the generating mouse event.
        /// </summary>
        /// <value>The X.</value>
        public int X
        {
            get
            {
                return this.mintX;
            }
        }

        /// <summary>
        /// Gets the y-coordinate of the mouse during the generating mouse event.
        /// </summary>
        /// <value>The Y.</value>
        public int Y
        {
            get
            {
                return this.mintY;
            }
        }

        // Fields
        private readonly MouseButtons menmButton;
        private readonly int mintClicks;
        private readonly int mintDelta;
        private readonly int mintX;
        private readonly int mintY;
    }

    /// <summary>
    /// Represents the method that will handle the MouseDown, MouseUp, or MouseMove event of a form, control, or other component.
    /// </summary>
    public delegate void MouseEventHandler(object sender, MouseEventArgs e);

    #endregion

    /// <summary>Allows a custom control to prevent the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseWheel"></see> event from being sent to its parent container.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class HandledMouseEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HandledMouseEventArgs"/> class.
        /// </summary>
        /// <param name="enmButton">The button.</param>
        /// <param name="intClicks">The clicks.</param>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="intDelta">The delta.</param>
        public HandledMouseEventArgs(MouseButtons enmButton, int intClicks, int intX, int intY, int intDelta)
            : base(enmButton, intClicks, intX, intY, intDelta)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandledMouseEventArgs"/> class.
        /// </summary>
        /// <param name="enmButton">The button.</param>
        /// <param name="intClicks">The clicks.</param>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="intDelta">The delta.</param>
        /// <param name="blnDefaultHandledValue">if set to <c>true</c> [default handled value].</param>
        public HandledMouseEventArgs(MouseButtons enmButton, int intClicks, int intX, int intY, int intDelta, bool blnDefaultHandledValue)
            : base(enmButton, intClicks, intX, intY, intDelta)
        {
        }

        /// <summary>Gets or sets whether this event should be forwarded to the control's parent container.</summary>
        /// <returns>true if the mouse event should go to the parent control; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool Handled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}
