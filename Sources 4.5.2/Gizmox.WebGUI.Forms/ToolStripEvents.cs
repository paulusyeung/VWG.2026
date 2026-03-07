using System;
using System.Drawing;

using Gizmox.WebGUI.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    #region EventArgs Classes

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripArrowRenderEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripArrowRenderEventArgs"></see> class. </summary> 
        ///<param name="arrowRectangle">The bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param> 
        ///<param name="g">The graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param> 
        ///<param name="arrowDirection">The direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</param> 
        ///<param name="toolStripItem">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</param> 
        ///<param name="arrowColor">The color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</param>
        public ToolStripArrowRenderEventArgs(Graphics g, ToolStripItem toolStripItem, Rectangle arrowRectangle, Color arrowColor, ArrowDirection arrowDirection)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets or sets the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the color of the arrow.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ArrowColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the bounding area of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding area.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ArrowRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow points.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ArrowDirection"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrowDirection Direction
        {
            get
            {
                return ArrowDirection.Left;
            }
            set
            {
            }
        }

        ///<summary>Gets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> arrow.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint. </returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graphics Graphics
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to paint the arrow.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem Item
        {
            get
            {
                return null;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class GiveFeedbackEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.GiveFeedbackEventArgs"></see> class.</summary> 
        ///<param name="effect">The type of drag-and-drop operation. Possible values are obtained by applying the bitwise OR (|) operation to the constants defined in the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see>. </param> 
        ///<param name="useDefaultCursors">true if default pointers are used; otherwise, false. </param>
        public GiveFeedbackEventArgs(DragDropEffects effect, bool useDefaultCursors)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the drag-and-drop operation feedback that is displayed.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DragDropEffects"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DragDropEffects Effect
        {
            get
            {
                return DragDropEffects.None;
            }
        }

        ///<summary>Gets or sets whether drag operation should use the default cursors that are associated with drag-drop effects.</summary> 
        ///<returns>true if the default pointers are used; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseDefaultCursors
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [ComVisible(true)]
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class QueryContinueDragEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QueryContinueDragEventArgs"></see> class.</summary> 
        ///<param name="escapePressed">true if the ESC key was pressed; otherwise, false. </param> 
        ///<param name="keyState">The current state of the SHIFT, CTRL, and ALT keys. </param> 
        ///<param name="action">A <see cref="T:Gizmox.WebGUI.Forms.DragAction"></see> value. </param>
        public QueryContinueDragEventArgs(int keyState, bool escapePressed, DragAction action)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets or sets the status of a drag-and-drop operation.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.DragAction"></see> value.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DragAction Action
        {
            get
            {
                return DragAction.Continue;
            }
            set
            {
            }
        }

        ///<summary>Gets whether the user pressed the ESC key.</summary> 
        ///<returns>true if the ESC key was pressed; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EscapePressed
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets the current state of the SHIFT, CTRL, and ALT keys.</summary> 
        ///<returns>The current state of the SHIFT, CTRL, and ALT keys.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int KeyState
        {
            get
            {
                return 0;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripItemRenderEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> and using the specified <see cref="T:System.Drawing.Graphics"></see>. </summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> object used to draw the item.</param> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to be drawn.</param>
        public ToolStripItemRenderEventArgs(Graphics g, ToolStripItem item)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graphics Graphics
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripItem Item
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Owner"></see> property for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> to paint.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> that is the owner of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStrip ToolStrip
        {
            get
            {
                return null;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripGripRenderEventArgs : ToolStripRenderEventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripRenderEventArgs"></see> class.</summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> object used to paint the move handle.</param> 
        ///<param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> the move handle is to be drawn on.</param>
        public ToolStripGripRenderEventArgs(Graphics g, ToolStrip toolStrip) : base(g, toolStrip)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the rectangle representing the area in which to paint the move handle.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the area in which to paint the move handle.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle GripBounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets the style that indicates whether the move handle is displayed vertically or horizontally.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripGripDisplayStyle GripDisplayStyle
        {
            get
            {
                return ToolStripGripDisplayStyle.Horizontal;
            }
        }

        ///<summary>Gets the style that indicates whether or not the move handle is visible.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripGripDisplayStyle"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripGripStyle GripStyle
        {
            get
            {
                return ToolStripGripStyle.Visible;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripRenderEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> and using the specified <see cref="T:System.Drawing.Graphics"></see>. </summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param> 
        ///<param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
        public ToolStripRenderEventArgs(Graphics g, ToolStrip toolStrip)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, using the specified <see cref="T:System.Drawing.Graphics"></see> to paint the specified bounds with the specified <see cref="T:System.Drawing.Color"></see>.</summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> to use for painting.</param> 
        ///<param name="backColor">The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</param> 
        ///<param name="affectedBounds">The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</param> 
        ///<param name="toolStrip">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to paint.</param>
        public ToolStripRenderEventArgs(Graphics g, ToolStrip toolStrip, Rectangle affectedBounds, Color backColor)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted. </summary> 
        ///<returns>The <see cref="T:System.Drawing.Rectangle"></see> representing the bounds of the area to be painted.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle AffectedBounds
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets the <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Color"></see> that the background of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is painted with.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BackColor
        {
            get
            {
                return Color.Empty;
            }
        }

        ///<summary>Gets the <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Rectangle"></see> representing the overlap area between a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> and its <see cref="P:Gizmox.WebGUI.Forms.ToolStripDropDown.OwnerItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority> 
        ///<PermissionSet> 
        ///  <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///  <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
        ///  <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
        ///</PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ConnectedArea
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        ///<summary>Gets the <see cref="T:System.Drawing.Graphics"></see> used to paint.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graphics Graphics
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to be painted.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStrip ToolStrip
        {
            get
            {
                return null;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripItemImageRenderEventArgs : ToolStripItemRenderEventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> within the specified space and that has the specified properties.</summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to paint the image.</param> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</param> 
        ///<param name="imageRectangle">The bounding area of the image.</param>
        public ToolStripItemImageRenderEventArgs(Graphics g, ToolStripItem item, Rectangle imageRectangle)
            : base(g, item)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemImageRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> that displays an image within the specified space and that has the specified properties. </summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to paint the image.</param> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the image.</param> 
        ///<param name="image">The <see cref="T:System.Drawing.Image"></see> to paint.</param> 
        ///<param name="imageRectangle">The bounding area of the image.</param>
        public ToolStripItemImageRenderEventArgs(Graphics g, ToolStripItem item, Image image, Rectangle imageRectangle)
            : base(g, item)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the image painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Image"></see> painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Image
        {
            get
            {
                return null;
            }
        }

        ///<summary>Gets the rectangle that represents the bounding area of the image.</summary> 
        ///<returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding area of the image.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ImageRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripItemTextRenderEventArgs : ToolStripItemRenderEventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> class with the specified text and text properties format.</summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to draw the text.</param> 
        ///<param name="textRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</param> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the text.</param> 
        ///<param name="format">The display and layout information for text strings.</param> 
        ///<param name="textColor">The <see cref="T:System.Drawing.Color"></see> used to draw the text.</param> 
        ///<param name="textFont">The <see cref="T:System.Drawing.Font"></see> used to draw the text.</param> 
        ///<param name="text">The text to be drawn.</param>
        public ToolStripItemTextRenderEventArgs(Graphics g, ToolStripItem item, string text, Rectangle textRectangle, Color textColor, Font textFont, TextFormatFlags format)
            : base(g, item)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemTextRenderEventArgs"></see> class with the specified text and text properties. </summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> used to draw the text.</param> 
        ///<param name="textRectangle">The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</param> 
        ///<param name="item">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> on which to draw the text.</param> 
        ///<param name="textAlign">The <see cref="T:System.Drawing.ContentAlignment"></see> that specifies the vertical and horizontal alignment of the text in the bounding area.</param> 
        ///<param name="textColor">The <see cref="T:System.Drawing.Color"></see> used to draw the text.</param> 
        ///<param name="textFont">The <see cref="T:System.Drawing.Font"></see> used to draw the text.</param> 
        ///<param name="text">The text to be drawn.</param>
        public ToolStripItemTextRenderEventArgs(Graphics g, ToolStripItem item, string text, Rectangle textRectangle, Color textColor, Font textFont, ContentAlignment textAlign)
            : base(g, item)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets or sets the text to be drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>A string that represents the text to be painted on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text. </summary> 
        ///<returns>A <see cref="T:System.Drawing.Color"></see> that represents the color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> text.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color TextColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets whether the text is drawn vertically or horizontally.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextDirection"></see> values. </returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripTextDirection TextDirection
        {
            get
            {
                return ToolStripTextDirection.Inherit;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the font of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Font"></see> of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Font TextFont
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the display and layout information of the text drawn on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
        ///<returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.TextFormatFlags"></see> values that specify the display and layout information of the drawn text. </returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextFormatFlags TextFormat
        {
            get
            {
                return TextFormatFlags.Left;
            }
            set
            {
            }
        }

        ///<summary>Gets or sets the rectangle that represents the bounds to draw the text in.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Rectangle"></see> that represents the bounds to draw the text in.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle TextRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
            set
            {
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripSeparatorRenderEventArgs : ToolStripItemRenderEventArgs
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparatorRenderEventArgs"></see> class. </summary> 
        ///<param name="g">The <see cref="T:System.Drawing.Graphics"></see> to paint with.</param> 
        ///<param name="vertical">A value indicating whether or not the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is to be drawn vertically.</param> 
        ///<param name="separator">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> to be painted.</param>
        public ToolStripSeparatorRenderEventArgs(Graphics g, ToolStripSeparator separator, bool vertical) : base(g, separator)
        {
        }

        #endregion C'Tors

        #region Properties

        ///<summary>Gets a value indicating whether the display style for the grip is vertical. </summary> 
        ///<returns>true if the display style for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see> is vertical; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Vertical
        {
            get
            {
                return false;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripContentPanelRenderEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanelRenderEventArgs"></see> class. </summary> 
        ///<param name="g">A <see cref="T:System.Drawing.Graphics"></see> representing the GDI+ drawing surface.</param> 
        ///<param name="contentPanel">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> to render.</param>
        public ToolStripContentPanelRenderEventArgs(Graphics g, ToolStripContentPanel contentPanel)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the object to use for drawing.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Graphics"></see> to use for drawing.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graphics Graphics
        {
            get
            {
                return null;
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see> affected by the click.</summary> 
        ///<returns>A <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripContentPanel ToolStripContentPanel
        {
            get
            {
                return null;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripPanelRenderEventArgs : EventArgs
    {


        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRenderEventArgs"></see> class for the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> that uses the specified graphics for drawing. </summary> 
        ///<param name="g">The graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
        ///<param name="toolStripPanel">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to draw.</param>
        public ToolStripPanelRenderEventArgs(Graphics g, ToolStripPanel toolStripPanel)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets or sets the graphics used to paint the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
        ///<returns>The <see cref="T:System.Drawing.Graphics"></see> used to paint.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Graphics Graphics
        {
            get
            {
                return null;
            }
        }

        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        ///<summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to paint.</summary> 
        ///<returns>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> to paint.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripPanel ToolStripPanel
        {
            get
            {
                return null;
            }
        }

        #endregion Properties

    }

    /// <summary>Provides data for <see cref="T:System.Windows.Forms.ToolStripItem"></see> events.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class ToolStripItemEventArgs : EventArgs
    {
        #region Members

        private ToolStripItem mobjToolStripItem; 

        #endregion

        #region C'tors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemEventArgs"></see> class, specifying a <see cref="T:System.Windows.Forms.ToolStripItem"></see>. </summary>
        /// <param name="item">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> for which to specify events.</param>
        public ToolStripItemEventArgs(ToolStripItem item)
        {
            this.mobjToolStripItem = item;
        } 

        #endregion

        #region Properties

        /// <summary>Gets a <see cref="T:System.Windows.Forms.ToolStripItem"></see> for which to handle events.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ToolStripItem"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public ToolStripItem Item
        {
            get
            {
                return this.mobjToolStripItem;
            }
        } 

        #endregion
    }

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.ToolStrip.ItemClicked"></see> event.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class ToolStripItemClickedEventArgs : EventArgs
    {
        #region Members

        private ToolStripItem mobjClickedItem;

        #endregion Members

        #region Constructors 

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs"></see> class, specifying the <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked. </summary>
        /// <param name="clickedItem">The <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked.</param>
        public ToolStripItemClickedEventArgs(ToolStripItem clickedItem)
        {
            this.mobjClickedItem = clickedItem;
        }

		#endregion Constructors 

		#region Properties 

        /// <summary>Gets the item that was clicked on the <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ToolStripItem"></see> that was clicked.</returns>
        /// <filterpriority>1</filterpriority>
        public ToolStripItem ClickedItem
        {
            get
            {
                return this.mobjClickedItem;
            }
        }

		#endregion Properties 
    }

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.ToolStripDropDown.Closed"></see> event. </summary>
    [Serializable()]
    public class ToolStripDropDownClosedEventArgs : EventArgs
    {
        #region Members

        private ToolStripDropDownCloseReason menmCloseReason; 

        #endregion

        #region C'tors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownClosedEventArgs"></see> class. </summary>
        /// <param name="reason">One of the <see cref="T:System.Windows.Forms.ToolStripDropDownCloseReason"></see> values.</param>
        public ToolStripDropDownClosedEventArgs(ToolStripDropDownCloseReason reason)
        {
            this.menmCloseReason = reason;
        } 

        #endregion

        #region Properties

        /// <summary>Gets the reason that the <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> closed.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripDropDownCloseReason"></see> values.</returns>
        public ToolStripDropDownCloseReason CloseReason
        {
            get
            {
                return this.menmCloseReason;
            }
        } 

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ToolStripDropDownClosingEventArgs : CancelEventArgs
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownClosingEventArgs"></see> class with the specified reason for closing. </summary> 
        ///<param name="reason">One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</param>
        public ToolStripDropDownClosingEventArgs(ToolStripDropDownCloseReason reason)
        {
        }

        #endregion C'Tors

        #region Properties

        ///<summary>Gets the reason that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is closing.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownCloseReason"></see> values.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolStripDropDownCloseReason CloseReason
        {
            get
            {
                return ToolStripDropDownCloseReason.AppClicked;
            }
        }

        #endregion Properties
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class UICuesEventArgs : EventArgs
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UICuesEventArgs"></see> class with the specified <see cref="T:Gizmox.WebGUI.Forms.UICues"></see>.</summary> 
        ///<param name="uicues">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values. </param>
        public UICuesEventArgs(UICues uicues)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets the bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values.</summary> 
        ///<returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.UICues"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.UICues.Changed"></see>.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UICues Changed
        {
            get
            {
                return UICues.Changed;
            }
        }

        ///<summary>Gets a value indicating whether the state of the focus cues has changed.</summary> 
        ///<returns>true if the state of the focus cues has changed; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeFocus
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether the state of the keyboard cues has changed.</summary> 
        ///<returns>true if the state of the keyboard cues has changed; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ChangeKeyboard
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether focus rectangles are shown after the change.</summary> 
        ///<returns>true if focus rectangles are shown after the change; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowFocus
        {
            get
            {
                return false;
            }
        }

        ///<summary>Gets a value indicating whether keyboard cues are underlined after the change.</summary> 
        ///<returns>true if keyboard cues are underlined after the change; otherwise, false.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowKeyboard
        {
            get
            {
                return false;
            }
        }

        #endregion Properties
    }

    [ComVisible(true)]
    [Serializable()]
    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public class ScrollEventArgs : EventArgs
    {
        #region C'Tors

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see> and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see> properties.</summary> 
        ///<param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param> 
        ///<param name="newValue">The new value for the scroll bar. </param>
        public ScrollEventArgs(ScrollEventType type, int newValue)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.ScrollOrientation"></see> properties.</summary> 
        ///<param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param> 
        ///<param name="newValue">The new value for the scroll bar. </param> 
        ///<param name="scroll">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values. </param>
        public ScrollEventArgs(ScrollEventType type, int newValue, ScrollOrientation scroll)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.OldValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see> properties.</summary> 
        ///<param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param> 
        ///<param name="oldValue">The old value for the scroll bar. </param> 
        ///<param name="newValue">The new value for the scroll bar. </param>
        public ScrollEventArgs(ScrollEventType type, int oldValue, int newValue)
        {
        }

        ///<summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventArgs"></see> class using the given values for the <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.Type"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.OldValue"></see>, <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.NewValue"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ScrollEventArgs.ScrollOrientation"></see> properties.</summary> 
        ///<param name="type">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values. </param> 
        ///<param name="oldValue">The old value for the scroll bar. </param> 
        ///<param name="newValue">The new value for the scroll bar. </param> 
        ///<param name="scroll">One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values. </param>
        public ScrollEventArgs(ScrollEventType type, int oldValue, int newValue, ScrollOrientation scroll)
        {
        }

        #endregion C'Tors


        #region Properties

        ///<summary>Gets or sets the new <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> of the scroll bar.</summary> 
        ///<returns>The numeric value that the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> property will be changed to.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NewValue
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        ///<summary>Gets the old <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> of the scroll bar.</summary> 
        ///<returns>The numeric value that the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Value"></see> property contained before it changed.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OldValue
        {
            get
            {
                return 0;
            }
        }

        ///<summary>Gets the scroll bar orientation that raised the Scroll event.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollOrientation"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScrollOrientation ScrollOrientation
        {
            get
            {
                return ScrollOrientation.VerticalScroll;
            }
        }

        ///<summary>Gets the type of scroll event that occurred.</summary> 
        ///<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollEventType"></see> values.</returns> 
        ///<filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScrollEventType Type
        {
            get
            {
                return ScrollEventType.EndScroll;
            }
        }

        #endregion Properties
    } 

    #endregion

    #region Delegates

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void GiveFeedbackEventHandler(object sender, GiveFeedbackEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void PaintEventHandler(object sender, PaintEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void QueryContinueDragEventHandler(object sender, QueryContinueDragEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripArrowRenderEventHandler(object sender, ToolStripArrowRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripItemRenderEventHandler(object sender, ToolStripItemRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripGripRenderEventHandler(object sender, ToolStripGripRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripRenderEventHandler(object sender, ToolStripRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripItemImageRenderEventHandler(object sender, ToolStripItemImageRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripItemTextRenderEventHandler(object sender, ToolStripItemTextRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripSeparatorRenderEventHandler(object sender, ToolStripSeparatorRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripContentPanelRenderEventHandler(object sender, ToolStripContentPanelRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripPanelRenderEventHandler(object sender, ToolStripPanelRenderEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void UICuesEventHandler(object sender, UICuesEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ToolStripDropDownClosingEventHandler(object sender, ToolStripDropDownClosingEventArgs e);

    [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false)]
    public delegate void ScrollEventHandler(object sender, ScrollEventArgs e);

    public delegate void ToolStripDropDownClosedEventHandler(object sender, ToolStripDropDownClosedEventArgs e);

    public delegate void ToolStripItemClickedEventHandler(object sender, ToolStripItemClickedEventArgs e);

    public delegate void ToolStripItemEventHandler(object sender, ToolStripItemEventArgs e);

    #endregion
}
