using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;
using System.Runtime.Serialization;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{

    #region Cursor Class

    /// <summary>Represents the image used to paint the mouse pointer.</summary>
    /// <filterpriority>1</filterpriority>
    /// <completionlist cref="T:Gizmox.WebGUI.Forms.Cursors" />

#if WG_NET46
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
    [TypeConverter(typeof(CursorConverter)), Serializable()]
    public sealed class Cursor : IDisposable
    {
        #region Members

        private string mstrType;
        private string mstrStyle;

        #endregion

        #region C'tor/D'tor

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class.
        /// </summary>
        /// <param name="strType">Type of the STR.</param>
        public Cursor(string strType)
            : this(strType, "default")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class.
        /// </summary>
        /// <param name="strType">Type of the STR.</param>
        /// <param name="strStyle">The STR style.</param>
        public Cursor(string strType, string strStyle)
        {
            mstrType = strType;
            mstrStyle = strStyle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class from the specified Windows handle.       
        /// </summary>
        /// <param name="ptrHandle">The handle.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        public Cursor(IntPtr ptrHandle)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class from the specified data stream.
        /// </summary>
        /// <param name="objStream">The stream.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        public Cursor(Stream objStream)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class  from the specified resource with the specified resource type.
        /// </summary>
        /// <param name="objType">The type.</param>
        /// <param name="objResource">The resource.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
        public Cursor(Type objType, string objResource)
            : this(objType.Module.Assembly.GetManifestResourceStream(objType, objResource))
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            get
            {
                return mstrType;
            }
        }

        /// <summary>
        /// Gets or sets the bounds that represent the clipping rectangle for the cursor.
        /// </summary>
        /// <value>
        /// The clip.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static Rectangle Clip
        {
            get
            {
                return Rectangle.Empty;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets the handle of the cursor.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr Handle
        {
            get
            {
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the hotspot of cursor.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point HotSpot
        {
            get
            {
                return Point.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the cursor's position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public static Point Position
        {
            get
            {
                // Get current context.
                IContextParams objContext = VWGContext.Current as IContextParams;
                if (objContext != null)
                {
                    // Return CursorPosition.
                    return objContext.CursorPosition;
                }
                // Return default.
                return Point.Empty;
            }

            private set
            {
            }

        }

        /// <summary>
        /// Gets the size of the cursor object.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size Size
        {
            get
            {
                return Size.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(StringConverter)), DefaultValue((string)null), SRCategory("CatData"), Localizable(false), Bindable(true), SRDescription("ControlTagDescr")]
        public object Tag
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
        /// Gets or sets the Style.
        /// </summary>
        /// <value>
        /// The Style.
        /// </value>
        private string Style
        {
            get { return mstrStyle; }
        }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Cursor Current
        {
            get
            {
                return Cursors.Default;
            }
            set
            {

            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Renders the cursor.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        internal void RenderCursor(IContext objContext, IAttributeWriter objWriter)
        {
            if (this != Cursors.Default)
            {
                objWriter.WriteAttributeString(WGAttributes.Cursor, mstrStyle);
            }
        }

        /// <summary>Retrieves a human readable string representing this <see cref="T:System.Windows.Forms.Cursor"></see>.</summary>
        /// <returns>A <see cref="T:System.String"></see> that represents this <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            string strText = null;

            strText = TypeDescriptor.GetConverter(typeof(Cursor)).ConvertToString(this);

            return ("[Cursor: " + strText + "]");
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="objCursor1">The left.</param>
        /// <param name="objCursor2">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Cursor objCursor1, Cursor objCursor2)
        {
            // If only one of the parameters is null
            if (object.ReferenceEquals(objCursor1, null) != object.ReferenceEquals(objCursor2, null))
            {
                return false;
            }

            // If both are null or the same object
            if (object.Equals(objCursor1, objCursor2))
            {
                return true;
            }

            // None are null - Compare cursor styles as strings.
            return string.Equals(objCursor1.Style, objCursor2.Style);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="objCursor1">The left.</param>
        /// <param name="objCursor2">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Cursor objCursor1, Cursor objCursor2)
        {
            return !(objCursor1 == objCursor2);
        }

        /// <summary>
        /// Copies the handle  of this Cursor.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr CopyHandle()
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// Draws the cursor on the specified surface, within the specified bounds.
        /// </summary>
        /// <param name="objGraphics">The g.</param>
        /// <param name="objTargetRect">The target rect.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void Draw(Graphics objGraphics, Rectangle objTargetRect)
        {
        }

        /// <summary>
        /// Draws the cursor in a stretched format on the specified surface, within the specified bounds.
        /// </summary>
        /// <param name="objGraphics">The g.</param>
        /// <param name="objTargetRect">The target rect.</param>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void DrawStretched(Graphics objGraphics, Rectangle objTargetRect)
        {
        }

        /// <summary>
        /// Returns a hash code for this Cursor.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// Hides the cursor.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static void Hide()
        {
        }

        /// <summary>
        /// Shows this cursor.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static void Show()
        {
        }

        #endregion

        #region IDisposable

        /// <summary>
        ///Releases all resources used by the Cursor.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }

    #endregion

    #region Cursors Class

    /// <summary>Provides a collection of <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> objects for use by a Windows Forms application.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public sealed class Cursors
    {

        private static Cursor appStarting;
        private static Cursor arrow;
        private static Cursor cross;
        private static Cursor defaultCursor;
        private static Cursor hand;
        private static Cursor help;
        private static Cursor hSplit;
        private static Cursor iBeam;
        private static Cursor no;
        private static Cursor noMove2D;
        private static Cursor noMoveHoriz;
        private static Cursor noMoveVert;
        private static Cursor panEast;
        private static Cursor panNE;
        private static Cursor panNorth;
        private static Cursor panNW;
        private static Cursor panSE;
        private static Cursor panSouth;
        private static Cursor panSW;
        private static Cursor panWest;
        private static Cursor sizeAll;
        private static Cursor sizeNESW;
        private static Cursor sizeNS;
        private static Cursor sizeNWSE;
        private static Cursor sizeWE;
        private static Cursor upArrow;
        private static Cursor vSplit;
        private static Cursor wait;

        private Cursors()
        {
        }

        internal static Cursor KnownCursorFromHCursor(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
            {
                return null;
            }
            return Cursors.Default;
        }


        /// <summary>Gets the cursor that appears when an application starts.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when an application starts.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor AppStarting
        {
            get
            {
                if (Cursors.appStarting == null)
                {
                    Cursors.appStarting = new Cursor("AppStarting", "progress");
                }
                return Cursors.appStarting;
            }
        }

        /// <summary>Gets the arrow cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the arrow cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor Arrow
        {
            get
            {
                if (Cursors.arrow == null)
                {
                    Cursors.arrow = new Cursor("Arrow");
                }
                return Cursors.arrow;
            }
        }

        /// <summary>Gets the crosshair cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the crosshair cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor Cross
        {
            get
            {
                if (Cursors.cross == null)
                {
                    Cursors.cross = new Cursor("Cross");
                }
                return Cursors.cross;
            }
        }

        /// <summary>Gets the default cursor, which is usually an arrow cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the default cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor Default
        {
            get
            {
                if (Cursors.defaultCursor == null)
                {
                    Cursors.defaultCursor = new Cursor("Default");
                }
                return Cursors.defaultCursor;
            }
        }

        /// <summary>Gets the hand cursor, typically used when hovering over a Web link.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the hand cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor Hand
        {
            get
            {
                if (Cursors.hand == null)
                {
                    Cursors.hand = new Cursor("Hand", "pointer");
                }
                return Cursors.hand;
            }
        }

        /// <summary>Gets the Help cursor, which is a combination of an arrow and a question mark.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the Help cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor Help
        {
            get
            {
                if (Cursors.help == null)
                {
                    Cursors.help = new Cursor("Help", "help");
                }
                return Cursors.help;
            }
        }

        /// <summary>Gets the cursor that appears when the mouse is positioned over a horizontal splitter bar.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when the mouse is positioned over a horizontal splitter bar.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor HSplit
        {
            get
            {
                if (Cursors.hSplit == null)
                {
                    Cursors.hSplit = new Cursor("HSplit");
                }
                return Cursors.hSplit;
            }
        }

        /// <summary>Gets the I-beam cursor, which is used to show where the text cursor appears when the mouse is clicked.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the I-beam cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor IBeam
        {
            get
            {
                if (Cursors.iBeam == null)
                {
                    Cursors.iBeam = new Cursor("IBeam", "text");
                }
                return Cursors.iBeam;
            }
        }

        /// <summary>Gets the cursor that indicates that a particular region is invalid for the current operation.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that indicates that a particular region is invalid for the current operation.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor No
        {
            get
            {
                if (Cursors.no == null)
                {
                    Cursors.no = new Cursor("No", "not-allowed");
                }
                return Cursors.no;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in both a horizontal and vertical direction.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor NoMove2D
        {
            get
            {
                if (Cursors.noMove2D == null)
                {
                    Cursors.noMove2D = new Cursor("NoMove2D");
                }
                return Cursors.noMove2D;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in a horizontal direction.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor NoMoveHoriz
        {
            get
            {
                if (Cursors.noMoveHoriz == null)
                {
                    Cursors.noMoveHoriz = new Cursor("NoMoveHoriz");
                }
                return Cursors.noMoveHoriz;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is not moving, but the window can be scrolled in a vertical direction.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is not moving.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor NoMoveVert
        {
            get
            {
                if (Cursors.noMoveVert == null)
                {
                    Cursors.noMoveVert = new Cursor("NoMoveVert");
                }
                return Cursors.noMoveVert;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the right.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the right.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanEast
        {
            get
            {
                if (Cursors.panEast == null)
                {
                    Cursors.panEast = new Cursor("PanEast");
                }
                return Cursors.panEast;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the right.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the right.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanNE
        {
            get
            {
                if (Cursors.panNE == null)
                {
                    Cursors.panNE = new Cursor("PanNE");
                }
                return Cursors.panNE;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in an upward direction.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in an upward direction.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanNorth
        {
            get
            {
                if (Cursors.panNorth == null)
                {
                    Cursors.panNorth = new Cursor("PanNorth");
                }
                return Cursors.panNorth;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the left.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically upward and to the left.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanNW
        {
            get
            {
                if (Cursors.panNW == null)
                {
                    Cursors.panNW = new Cursor("PanNW");
                }
                return Cursors.panNW;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the right.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the right.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanSE
        {
            get
            {
                if (Cursors.panSE == null)
                {
                    Cursors.panSE = new Cursor("PanSE");
                }
                return Cursors.panSE;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in a downward direction.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling vertically in a downward direction.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanSouth
        {
            get
            {
                if (Cursors.panSouth == null)
                {
                    Cursors.panSouth = new Cursor("PanSouth");
                }
                return Cursors.panSouth;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the left.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally and vertically downward and to the left.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanSW
        {
            get
            {
                if (Cursors.panSW == null)
                {
                    Cursors.panSW = new Cursor("PanSW");
                }
                return Cursors.panSW;
            }
        }

        /// <summary>Gets the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the left.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears during wheel operations when the mouse is moving and the window is scrolling horizontally to the left.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor PanWest
        {
            get
            {
                if (Cursors.panWest == null)
                {
                    Cursors.panWest = new Cursor("PanWest");
                }
                return Cursors.panWest;
            }
        }

        /// <summary>Gets the four-headed sizing cursor, which consists of four joined arrows that point north, south, east, and west.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the four-headed sizing cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor SizeAll
        {
            get
            {
                if (Cursors.sizeAll == null)
                {
                    Cursors.sizeAll = new Cursor("SizeAll");
                }
                return Cursors.sizeAll;
            }
        }

        /// <summary>Gets the two-headed diagonal (northeast/southwest) sizing cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents two-headed diagonal (northeast/southwest) sizing cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor SizeNESW
        {
            get
            {
                if (Cursors.sizeNESW == null)
                {
                    Cursors.sizeNESW = new Cursor("SizeNESW");
                }
                return Cursors.sizeNESW;
            }
        }

        /// <summary>Gets the two-headed vertical (north/south) sizing cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed vertical (north/south) sizing cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor SizeNS
        {
            get
            {
                if (Cursors.sizeNS == null)
                {
                    Cursors.sizeNS = new Cursor("SizeNS");
                }
                return Cursors.sizeNS;
            }
        }

        /// <summary>Gets the two-headed diagonal (northwest/southeast) sizing cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed diagonal (northwest/southeast) sizing cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor SizeNWSE
        {
            get
            {
                if (Cursors.sizeNWSE == null)
                {
                    Cursors.sizeNWSE = new Cursor("SizeNWSE");
                }
                return Cursors.sizeNWSE;
            }
        }

        /// <summary>Gets the two-headed horizontal (west/east) sizing cursor.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the two-headed horizontal (west/east) sizing cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor SizeWE
        {
            get
            {
                if (Cursors.sizeWE == null)
                {
                    Cursors.sizeWE = new Cursor("SizeWE");
                }
                return Cursors.sizeWE;
            }
        }

        /// <summary>Gets the up arrow cursor, typically used to identify an insertion point.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the up arrow cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor UpArrow
        {
            get
            {
                if (Cursors.upArrow == null)
                {
                    Cursors.upArrow = new Cursor("UpArrow");
                }
                return Cursors.upArrow;
            }
        }

        /// <summary>Gets the cursor that appears when the mouse is positioned over a vertical splitter bar.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when the mouse is positioned over a vertical splitter bar.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor VSplit
        {
            get
            {
                if (Cursors.vSplit == null)
                {
                    Cursors.vSplit = new Cursor("VSplit");
                }
                return Cursors.vSplit;
            }
        }

        /// <summary>Gets the wait cursor, typically an hourglass shape.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the wait cursor.</returns>
        /// <filterpriority>1</filterpriority>
        public static Cursor WaitCursor
        {
            get
            {
                if (Cursors.wait == null)
                {
                    Cursors.wait = new Cursor("WaitCursor", "wait");
                }
                return Cursors.wait;
            }
        }



    }

    #endregion

    #region CursorConverter Class
    /// <summary>Provides a type converter to convert <see cref="T:System.Windows.Forms.Cursor"></see> objects to and from various other representations.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class CursorConverter : TypeConverter
    {
        [NonSerialized]
        private TypeConverter.StandardValuesCollection mobjValues;

        /// <summary>Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
        /// <returns>true if this object can perform the conversion.</returns>
        /// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
        /// <param name="objSourceType">The type you wish to convert from. </param>
        /// <filterpriority>1</filterpriority>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            if ((objSourceType != typeof(string)) && (objSourceType != typeof(byte[])))
            {
                return base.CanConvertFrom(objContext, objSourceType);
            }
            return true;
        }

        /// <summary>Gets a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context. </param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"></see> that represents the type you wish to convert to. </param>
        /// <filterpriority>1</filterpriority>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if ((objDestinationType != typeof(InstanceDescriptor)) && (objDestinationType != typeof(byte[])))
            {
                return base.CanConvertTo(objContext, objDestinationType);
            }
            return true;
        }

        /// <filterpriority>1</filterpriority>
        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string strText = ((string)objValue).Trim();
                foreach (PropertyInfo objPropertyInfo in this.GetProperties())
                {
                    if (ClientUtils.IsEquals(objPropertyInfo.Name, strText, StringComparison.OrdinalIgnoreCase))
                    {
                        object[] arrIndex = null;
                        return objPropertyInfo.GetValue(null, arrIndex);
                    }
                }
            }
            //if (value is byte[])
            //{
            //    return new Cursor(new MemoryStream((byte[])value));
            //}
            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        /// <filterpriority>1</filterpriority>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if ((objDestinationType == typeof(string)) && (objValue != null))
            {
                PropertyInfo[] arrPropertyInfos = this.GetProperties();
                int index = -1;
                for (int i = 0; i < arrPropertyInfos.Length; i++)
                {
                    PropertyInfo objPropertyInfo = arrPropertyInfos[i];
                    object[] arrObjects = null;
                    Cursor objA = (Cursor)objPropertyInfo.GetValue(null, arrObjects);
                    if (objA == ((Cursor)objValue))
                    {
                        if (object.ReferenceEquals(objA, objValue))
                        {
                            return objPropertyInfo.Name;
                        }
                        index = i;
                    }
                }
                if (index == -1)
                {
                    throw new FormatException(SR.GetString("CursorCannotCovertToString"));
                }
                return arrPropertyInfos[index].Name;
            }

            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is Cursor))
            {
                //convert to InstanceDescriptor
                return ConvertToInstanceDescriptor(objContext, objValue);
            }

            if (objDestinationType != typeof(byte[]))
            {
                return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
            }

            //if (value != null)
            //{
            //    MemoryStream stream = new MemoryStream();
            //    ((Cursor)value).SavePicture(stream);
            //    stream.Close();
            //    return stream.ToArray();
            //}

            return new byte[0];
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
        {
            foreach (PropertyInfo objPropertyInfo in this.GetProperties())
            {
                if (objPropertyInfo.GetValue(null, null) == objValue)
                {
                    return new InstanceDescriptor(objPropertyInfo, null);
                }
            }

            return new byte[0];
        }

        private PropertyInfo[] GetProperties()
        {
            return typeof(Cursors).GetProperties(BindingFlags.Public | BindingFlags.Static);
        }

        /// <summary>Retrieves a collection containing a set of standard values for the data type this validator is designed for. This will return null if the data type does not support a standard set of values.</summary>
        /// <returns>A collection containing a standard set of valid values, or null. The default implementation always returns null.</returns>
        /// <param name="objContext">A formatter context. This object can be used to extract additional information about the environment this converter is being invoked from. This may be null, so you should always check. Also, properties on the context object may also return null. </param>
        /// <filterpriority>1</filterpriority>
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext objContext)
        {
            if (this.mobjValues == null)
            {
                ArrayList objList = new ArrayList();
                foreach (PropertyInfo objPropertyInfo in this.GetProperties())
                {
                    object[] arrIndex = null;
                    objList.Add(objPropertyInfo.GetValue(null, arrIndex));
                }
                this.mobjValues = new TypeConverter.StandardValuesCollection(objList.ToArray());
            }
            return this.mobjValues;
        }

        /// <summary>Determines if this object supports a standard set of values that can be picked from a list.</summary>
        /// <returns>Returns true if GetStandardValues should be called to find a common set of values the object supports.</returns>
        /// <param name="objContext">A type descriptor through which additional context may be provided. </param>
        /// <filterpriority>1</filterpriority>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }


    }
    #endregion


}

