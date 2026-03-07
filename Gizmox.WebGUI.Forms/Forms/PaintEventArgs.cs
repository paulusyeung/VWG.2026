// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PaintEventArgs
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides data for the Paint event.</summary>
  [Serializable]
  public class PaintEventArgs : EventArgs, IDisposable
  {
    private readonly Rectangle mobjClipRectangle;
    private readonly IntPtr mobjDC;
    private Graphics mobjGraphics;
    private IntPtr mobjOldPal;
    private GraphicsState mobjSavedGraphicsState;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> class.
    /// </summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objClipRect">The clip rect.</param>
    public PaintEventArgs(Graphics objGraphics, Rectangle objClipRect)
    {
      this.mobjDC = IntPtr.Zero;
      this.mobjOldPal = IntPtr.Zero;
      this.mobjGraphics = objGraphics != null ? objGraphics : throw new ArgumentNullException("graphics");
      this.mobjClipRectangle = objClipRect;
    }

    internal PaintEventArgs(IntPtr objDC, Rectangle objClipRect)
    {
      this.mobjDC = IntPtr.Zero;
      this.mobjOldPal = IntPtr.Zero;
      this.mobjDC = objDC;
      this.mobjClipRectangle = objClipRect;
    }

    /// <summary>
    /// Releases unmanaged resources and performs other cleanup operations before the
    /// <see cref="T:Gizmox.WebGUI.Forms.PaintEventArgs" /> is reclaimed by garbage collection.
    /// </summary>
    ~PaintEventArgs() => this.Dispose(false);

    /// <summary>Gets the clip rectangle.</summary>
    /// <value>The clip rectangle.</value>
    public Rectangle ClipRectangle => this.mobjClipRectangle;

    /// <summary>Gets the graphics.</summary>
    /// <value>The graphics.</value>
    public Graphics Graphics
    {
      get
      {
        if (this.mobjGraphics == null && this.mobjDC != IntPtr.Zero)
        {
          this.mobjGraphics = Graphics.FromHdcInternal(this.mobjDC);
          this.mobjGraphics.PageUnit = GraphicsUnit.Pixel;
          this.mobjSavedGraphicsState = this.mobjGraphics.Save();
        }
        return this.mobjGraphics;
      }
    }

    internal IntPtr HDC => this.mobjGraphics == null ? this.mobjDC : IntPtr.Zero;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    /// <param name="blnDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.mobjGraphics != null && this.mobjDC != IntPtr.Zero)
        this.mobjGraphics.Dispose();
      if (!(this.mobjOldPal != IntPtr.Zero) || !(this.mobjDC != IntPtr.Zero))
        return;
      this.mobjOldPal = IntPtr.Zero;
    }

    internal void ResetGraphics()
    {
      if (this.mobjGraphics == null || this.mobjSavedGraphicsState == null)
        return;
      this.mobjGraphics.Restore(this.mobjSavedGraphicsState);
      this.mobjSavedGraphicsState = (GraphicsState) null;
    }
  }
}
