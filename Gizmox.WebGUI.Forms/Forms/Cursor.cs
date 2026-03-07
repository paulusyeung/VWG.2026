// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Cursor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the image used to paint the mouse pointer.</summary>
  /// <filterpriority>1</filterpriority>
  /// <completionlist cref="T:Gizmox.WebGUI.Forms.Cursors" />
  [Editor("Gizmox.WebGUI.Forms.Design.CursorEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [TypeConverter(typeof (CursorConverter))]
  [Serializable]
  public sealed class Cursor : IDisposable
  {
    private string mstrType;
    private string mstrStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class.
    /// </summary>
    /// <param name="strType">Type of the STR.</param>
    public Cursor(string strType)
      : this(strType, "default")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class.
    /// </summary>
    /// <param name="strType">Type of the STR.</param>
    /// <param name="strStyle">The STR style.</param>
    public Cursor(string strType, string strStyle)
    {
      this.mstrType = strType;
      this.mstrStyle = strStyle;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class from the specified Windows handle.
    /// </summary>
    /// <param name="ptrHandle">The handle.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    public Cursor(IntPtr ptrHandle)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class from the specified data stream.
    /// </summary>
    /// <param name="objStream">The stream.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    public Cursor(Stream objStream)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Cursor" /> class  from the specified resource with the specified resource type.
    /// </summary>
    /// <param name="objType">The type.</param>
    /// <param name="objResource">The resource.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    public Cursor(System.Type objType, string objResource)
      : this(objType.Module.Assembly.GetManifestResourceStream(objType, objResource))
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public string Type => this.mstrType;

    /// <summary>
    /// Gets or sets the bounds that represent the clipping rectangle for the cursor.
    /// </summary>
    /// <value>The clip.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Rectangle Clip
    {
      get => Rectangle.Empty;
      set
      {
      }
    }

    /// <summary>Gets the handle of the cursor.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IntPtr Handle => IntPtr.Zero;

    /// <summary>Gets the hotspot of cursor.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Point HotSpot => Point.Empty;

    /// <summary>Gets or sets the cursor's position.</summary>
    /// <value>The position.</value>
    public static Point Position
    {
      get => VWGContext.Current is IContextParams current ? current.CursorPosition : Point.Empty;
      private set
      {
      }
    }

    /// <summary>Gets the size of the cursor object.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size Size => Size.Empty;

    /// <summary>Gets or sets the tag.</summary>
    /// <value>The tag.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [TypeConverter(typeof (StringConverter))]
    [DefaultValue(null)]
    [SRCategory("CatData")]
    [Localizable(false)]
    [Bindable(true)]
    [SRDescription("ControlTagDescr")]
    public object Tag
    {
      get => (object) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the Style.</summary>
    /// <value>The Style.</value>
    private string Style => this.mstrStyle;

    /// <summary>Gets or sets the current.</summary>
    /// <value>The current.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Cursor Current
    {
      get => Cursors.Default;
      set
      {
      }
    }

    /// <summary>Renders the cursor.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    internal void RenderCursor(IContext objContext, IAttributeWriter objWriter)
    {
      if (!(this != Cursors.Default))
        return;
      objWriter.WriteAttributeString("CUR", this.mstrStyle);
    }

    /// <summary>Retrieves a human readable string representing this <see cref="T:System.Windows.Forms.Cursor"></see>.</summary>
    /// <returns>A <see cref="T:System.String"></see> that represents this <see cref="T:System.Windows.Forms.Cursor"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString() => "[Cursor: " + TypeDescriptor.GetConverter(typeof (Cursor)).ConvertToString((object) this) + "]";

    /// <summary>Implements the operator ==.</summary>
    /// <param name="objCursor1">The left.</param>
    /// <param name="objCursor2">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(Cursor objCursor1, Cursor objCursor2)
    {
      if ((object) objCursor1 == null != ((object) objCursor2 == null))
        return false;
      return object.Equals((object) objCursor1, (object) objCursor2) || string.Equals(objCursor1.Style, objCursor2.Style);
    }

    /// <summary>Implements the operator !=.</summary>
    /// <param name="objCursor1">The left.</param>
    /// <param name="objCursor2">The right.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(Cursor objCursor1, Cursor objCursor2) => !(objCursor1 == objCursor2);

    /// <summary>Copies the handle  of this Cursor.</summary>
    /// <returns></returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IntPtr CopyHandle() => IntPtr.Zero;

    /// <summary>
    /// Draws the cursor on the specified surface, within the specified bounds.
    /// </summary>
    /// <param name="objGraphics">The g.</param>
    /// <param name="objTargetRect">The target rect.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void Draw(Graphics objGraphics, Rectangle objTargetRect)
    {
    }

    /// <summary>
    /// Draws the cursor in a stretched format on the specified surface, within the specified bounds.
    /// </summary>
    /// <param name="objGraphics">The g.</param>
    /// <param name="objTargetRect">The target rect.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void DrawStretched(Graphics objGraphics, Rectangle objTargetRect)
    {
    }

    /// <summary>Returns a hash code for this Cursor.</summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    /// </returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override int GetHashCode() => 0;

    /// <summary>Hides the cursor.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static void Hide()
    {
    }

    /// <summary>Shows this cursor.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static void Show()
    {
    }

    /// <summary>Releases all resources used by the Cursor.</summary>
    public void Dispose()
    {
    }
  }
}
