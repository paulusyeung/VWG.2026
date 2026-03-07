// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Cursors
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides a collection of <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> objects for use by a Windows Forms application.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
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

    internal static Cursor KnownCursorFromHCursor(IntPtr handle) => handle == IntPtr.Zero ? (Cursor) null : Cursors.Default;

    /// <summary>Gets the cursor that appears when an application starts.</summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor that appears when an application starts.</returns>
    /// <filterpriority>1</filterpriority>
    public static Cursor AppStarting
    {
      get
      {
        if (Cursors.appStarting == (Cursor) null)
          Cursors.appStarting = new Cursor(nameof (AppStarting), "progress");
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
        if (Cursors.arrow == (Cursor) null)
          Cursors.arrow = new Cursor(nameof (Arrow));
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
        if (Cursors.cross == (Cursor) null)
          Cursors.cross = new Cursor(nameof (Cross));
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
        if (Cursors.defaultCursor == (Cursor) null)
          Cursors.defaultCursor = new Cursor(nameof (Default));
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
        if (Cursors.hand == (Cursor) null)
          Cursors.hand = new Cursor(nameof (Hand), "pointer");
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
        if (Cursors.help == (Cursor) null)
          Cursors.help = new Cursor(nameof (Help), "help");
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
        if (Cursors.hSplit == (Cursor) null)
          Cursors.hSplit = new Cursor(nameof (HSplit));
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
        if (Cursors.iBeam == (Cursor) null)
          Cursors.iBeam = new Cursor(nameof (IBeam), "text");
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
        if (Cursors.no == (Cursor) null)
          Cursors.no = new Cursor(nameof (No), "not-allowed");
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
        if (Cursors.noMove2D == (Cursor) null)
          Cursors.noMove2D = new Cursor(nameof (NoMove2D));
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
        if (Cursors.noMoveHoriz == (Cursor) null)
          Cursors.noMoveHoriz = new Cursor(nameof (NoMoveHoriz));
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
        if (Cursors.noMoveVert == (Cursor) null)
          Cursors.noMoveVert = new Cursor(nameof (NoMoveVert));
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
        if (Cursors.panEast == (Cursor) null)
          Cursors.panEast = new Cursor(nameof (PanEast));
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
        if (Cursors.panNE == (Cursor) null)
          Cursors.panNE = new Cursor(nameof (PanNE));
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
        if (Cursors.panNorth == (Cursor) null)
          Cursors.panNorth = new Cursor(nameof (PanNorth));
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
        if (Cursors.panNW == (Cursor) null)
          Cursors.panNW = new Cursor(nameof (PanNW));
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
        if (Cursors.panSE == (Cursor) null)
          Cursors.panSE = new Cursor(nameof (PanSE));
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
        if (Cursors.panSouth == (Cursor) null)
          Cursors.panSouth = new Cursor(nameof (PanSouth));
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
        if (Cursors.panSW == (Cursor) null)
          Cursors.panSW = new Cursor(nameof (PanSW));
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
        if (Cursors.panWest == (Cursor) null)
          Cursors.panWest = new Cursor(nameof (PanWest));
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
        if (Cursors.sizeAll == (Cursor) null)
          Cursors.sizeAll = new Cursor(nameof (SizeAll));
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
        if (Cursors.sizeNESW == (Cursor) null)
          Cursors.sizeNESW = new Cursor(nameof (SizeNESW));
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
        if (Cursors.sizeNS == (Cursor) null)
          Cursors.sizeNS = new Cursor(nameof (SizeNS));
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
        if (Cursors.sizeNWSE == (Cursor) null)
          Cursors.sizeNWSE = new Cursor(nameof (SizeNWSE));
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
        if (Cursors.sizeWE == (Cursor) null)
          Cursors.sizeWE = new Cursor(nameof (SizeWE));
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
        if (Cursors.upArrow == (Cursor) null)
          Cursors.upArrow = new Cursor(nameof (UpArrow));
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
        if (Cursors.vSplit == (Cursor) null)
          Cursors.vSplit = new Cursor(nameof (VSplit));
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
        if (Cursors.wait == (Cursor) null)
          Cursors.wait = new Cursor(nameof (WaitCursor), "wait");
        return Cursors.wait;
      }
    }
  }
}
