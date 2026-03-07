// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.LayoutEngine
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class LayoutEngine
  {
    /// <summary>Inits the layout.</summary>
    /// <param name="objChild">The child.</param>
    /// <param name="enmSpecified">The specified.</param>
    public virtual void InitLayout(object objChild, BoundsSpecified enmSpecified) => this.InitLayoutCore(this.CastToArrangedElement(objChild), enmSpecified);

    /// <summary>Layouts the specified container.</summary>
    /// <param name="objContainer">The container.</param>
    /// <param name="objLayoutEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
    /// <returns></returns>
    public virtual bool Layout(object objContainer, LayoutEventArgs objLayoutEventArgs) => this.LayoutCore(this.CastToArrangedElement(objContainer), objLayoutEventArgs);

    internal IArrangedElement CastToArrangedElement(object obj)
    {
      IArrangedElement arrangedElement = obj as IArrangedElement;
      if (obj == null)
        throw new NotSupportedException(SR.GetString("LayoutEngineUnsupportedType", (object) obj.GetType()));
      return arrangedElement;
    }

    internal virtual Size GetPreferredSize(
      IArrangedElement objContainer,
      Size objProposedConstraints)
    {
      return Size.Empty;
    }

    /// <summary>Inits the layout core.</summary>
    /// <param name="objElement">The element.</param>
    /// <param name="enmBounds">The bounds.</param>
    internal virtual void InitLayoutCore(IArrangedElement objElement, BoundsSpecified enmBounds)
    {
    }

    internal virtual bool LayoutCore(IArrangedElement objContainer, LayoutEventArgs layoutEventArgs) => false;

    internal virtual void ProcessSuspendedLayoutEventArgs(
      IArrangedElement objContainer,
      LayoutEventArgs args)
    {
    }
  }
}
