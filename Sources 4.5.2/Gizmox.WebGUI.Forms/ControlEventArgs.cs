using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>Specifies the effects of a drag-and-drop operation.</summary>
    /// <filterpriority>2</filterpriority>
    [Flags]
    public enum DragDropEffects
    {
        /// <summary>The data is copied, removed from the drag source, and scrolled in the drop target.</summary>
        /// <filterpriority>1</filterpriority>
        All = -2147483645,
        /// <summary>The data is copied to the drop target.</summary>
        /// <filterpriority>1</filterpriority>
        Copy = 1,
        /// <summary>The data from the drag source is linked to the drop target.</summary>
        /// <filterpriority>1</filterpriority>
        Link = 4,
        /// <summary>The data from the drag source is moved to the drop target.</summary>
        /// <filterpriority>1</filterpriority>
        Move = 2,
        /// <summary>The drop target does not accept the data.</summary>
        /// <filterpriority>1</filterpriority>
        None = 0,
        /// <summary>Scrolling is about to start or is currently occurring in the drop target.</summary>
        /// <filterpriority>1</filterpriority>
        Scroll = -2147483648
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SwipeDirection
    {
        /// <summary>
        /// 
        /// </summary>
        Left = 0,
        /// <summary>
        /// 
        /// </summary>
        Right = 1
    }

    #endregion

    #region DragDropEventArgs

    /// <summary>
    /// Contains Drag and drop event arguments.
    /// </summary>
    [ComVisible(true), Serializable()]
    public class DragDropEventArgs : DragEventArgs
    {
        #region Members

        Component mobjSource = null;
        Component mobjTarget = null;
        Component mobjExplicitTarget = null;
        Point mobjRelativePosition;

        #endregion

        #region C'tor / D'tor

        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropEventArgs"/> class.
        /// </summary>
        /// <param name="objData">The data associated with this event.</param>
        /// <param name="intKeyState">The current state of the SHIFT, CTRL, and ALT keys.</param>
        /// <param name="intX">The x-coordinate of the mouse cursor in pixels.</param>
        /// <param name="intY">The y-coordinate of the mouse cursor in pixels.</param>
        /// <param name="enmAllowedEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
        /// <param name="enmEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</param>
        public DragDropEventArgs(IDataObject objData, int intKeyState, int intX, int intY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
            : base(objData, intKeyState, intX, intY, enmAllowedEffect, enmEffect)
        {
            if (objData != null)
            {
                string[] arrFormats = objData.GetFormats();

                if (arrFormats != null && arrFormats.Length > 0)
                {
                    mobjSource = objData.GetData(arrFormats[0]) as Component;
                }
            }
        }

		/// <summary>
        /// Initializes a new instance of the <see cref="DragDropEventArgs"/> class.
        /// </summary>
        /// <param name="objSource">The source.</param>
        /// <param name="objSourceMember">The source member.</param>
        /// <param name="objTarget">The target.</param>
        /// <param name="objTargetMember">The target member.</param>
        /// <param name="intKeyState">State of the key.</param>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="enmAllowedEffect">The allowed effect.</param>
        /// <param name="enmEffect">The effect.</param>
        [Obsolete("Not supported - please use other constructors which exceptes 'ExplicitTarget'."), Browsable(false)]
        public DragDropEventArgs(Component objSource, Component objSourceMember, Component objTarget, Component objTargetMember, int intKeyState, int intX, int intY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
            : base(new DataObject(objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
        {
            mobjSource = objSource;
            mobjTarget = objTarget;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DragDropEventArgs"/> class.
        /// </summary>
        /// <param name="objSource">The obj source.</param>
        /// <param name="objTarget">The obj target.</param>
        /// <param name="intKeyState">State of the int key.</param>
        /// <param name="intX">The int X.</param>
        /// <param name="intY">The int Y.</param>
        /// <param name="enmAllowedEffect">The enm allowed effect.</param>
        /// <param name="enmEffect">The enm effect.</param>
        public DragDropEventArgs(Component objSource, Component objTarget, Component objExplicitTarget, int intKeyState, int intX, int intY, int intRelativeX, int intRelativeY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
            : base(new DataObject(objSource), intKeyState, intX, intY, enmAllowedEffect, enmEffect)
        {
            mobjSource = objSource;
            mobjTarget = objTarget;
            mobjExplicitTarget = objExplicitTarget;
            mobjRelativePosition = new Point(intRelativeX, intRelativeY);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the position relative to the parent control.
        /// </summary>
        public Point RelativePosition
        {
            get
            {
                return mobjRelativePosition;
            }
        }

        /// <summary>
        /// Gets the source component.
        /// </summary>
        /// <value>The source component.</value>
        public Component Source
        {
            get
            {
                return mobjSource;
            }
        }

        /// <summary>
        /// Gets the source component member.
        /// </summary>
        /// <value>The source component member.</value>
        [Obsolete("Not supported - please use 'Source' property instead."), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Component SourceMember
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the target component.
        /// </summary>
        /// <value>The target component.</value>
        public Component Target
        {
            get
            {
                return mobjTarget;
            }
        }

		/// <summary>
        /// Gets the target component member.
        /// </summary>
        /// <value>The target component member.</value>
        [Obsolete("Not supported - please use 'ExplicitTarget' property instead."), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Component TargetMember
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the explicit target.
        /// </summary>
        public Component ExplicitTarget
        {
            get
            {
                return mobjExplicitTarget;
            }
        }

        #endregion
    }

    #endregion

    #region DragEventArgs

    /// <summary>Represents the method that will handle the <see cref="E:System.Windows.Forms.Control.DragDrop"></see>, <see cref="E:System.Windows.Forms.Control.DragEnter"></see>, or <see cref="E:System.Windows.Forms.Control.DragOver"></see> event of a <see cref="T:System.Windows.Forms.Control"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DragEventHandler(object sender, DragEventArgs e);

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.Control.DragDrop"></see>, <see cref="E:System.Windows.Forms.Control.DragEnter"></see>, or <see cref="E:System.Windows.Forms.Control.DragOver"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    [ComVisible(true), Serializable()]
    public class DragEventArgs : EventArgs
    {
        private readonly DragDropEffects menmAllowedEffect;
        private readonly IDataObject mobjData;
        private DragDropEffects menmEffect;
        private readonly int mintKeyState;
        private readonly int mintX;
        private readonly int mintY;

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DragEventArgs"></see> class.</summary>
        /// <param name="intY">The y-coordinate of the mouse cursor in pixels. </param>
        /// <param name="enmAllowedEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
        /// <param name="objData">The data associated with this event. </param>
        /// <param name="intKeyState">The current state of the SHIFT, CTRL, and ALT keys. </param>
        /// <param name="enmEffect">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
        /// <param name="intX">The x-coordinate of the mouse cursor in pixels. </param>
        public DragEventArgs(IDataObject objData, int intKeyState, int intX, int intY, DragDropEffects enmAllowedEffect, DragDropEffects enmEffect)
        {
            this.mobjData = objData;
            this.mintKeyState = intKeyState;
            this.mintX = intX;
            this.mintY = intY;
            this.menmAllowedEffect = enmAllowedEffect;
            this.menmEffect = enmEffect;
        }

        /// <summary>Gets which drag-and-drop operations are allowed by the originator (or source) of the drag event.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</returns>
        /// <filterpriority>1</filterpriority>
        public DragDropEffects AllowedEffect
        {
            get
            {
                return this.menmAllowedEffect;
            }
        }

        /// <summary>Gets the <see cref="T:System.Windows.Forms.IDataObject"></see> that contains the data associated with this event.</summary>
        /// <returns>The data associated with this event.</returns>
        /// <filterpriority>1</filterpriority>
        public IDataObject Data
        {
            get
            {
                return this.mobjData;
            }
        }

        /// <summary>Gets or sets the target drop effect in a drag-and-drop operation.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values.</returns>
        /// <filterpriority>1</filterpriority>
        public DragDropEffects Effect
        {
            get
            {
                return this.menmEffect;
            }
            set
            {
                this.menmEffect = value;
            }
        }

        /// <summary>Gets the current state of the SHIFT, CTRL, and ALT keys, as well as the state of the mouse buttons.</summary>
        /// <returns>The current state of the SHIFT, CTRL, and ALT keys and of the mouse buttons.</returns>
        /// <filterpriority>1</filterpriority>
        public int KeyState
        {
            get
            {
                return this.mintKeyState;
            }
        }

        /// <summary>Gets the x-coordinate of the mouse pointer, in screen coordinates.</summary>
        /// <returns>The x-coordinate of the mouse pointer in pixels.</returns>
        /// <filterpriority>1</filterpriority>
        public int X
        {
            get
            {
                return this.mintX;
            }
        }

        /// <summary>Gets the y-coordinate of the mouse pointer, in screen coordinates.</summary>
        /// <returns>The y-coordinate of the mouse pointer in pixels.</returns>
        /// <filterpriority>1</filterpriority>
        public int Y
        {
            get
            {
                return this.mintY;
            }
        }
    }

    #endregion
}