// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Administration.AdministrationContent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Administration.Abstract;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.Administration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class AdministrationContent : UserControl
  {
    /// <summary>Gets the content properties.</summary>
    /// <value>The content properties.</value>
    public abstract ContentProperties ContentProperties { get; }

    /// <summary>Gets the index.</summary>
    /// <value>The index.</value>
    public abstract int Index { get; }

    /// <summary>Updates the content.</summary>
    protected void UpdateContent()
    {
      Control control = (Control) this;
      while (!(control is IContentUpdateable) && !(control is AdministrationFormBase))
      {
        control = control.Parent;
        if (control is IContentUpdateable)
        {
          (control as IContentUpdateable).UpdateContent();
          break;
        }
      }
    }

    /// <summary>
    /// On loading of the AdministrationContent, first do the functionality here
    /// </summary>
    /// <param name="objData">Data used by the automatic functionality</param>
    public virtual void PerformAutomateAction(object objData)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AdministrationContentSorter : IComparer<AdministrationContent>
    {
      /// <summary>
      /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
      /// </summary>
      /// <param name="x">The first object to compare.</param>
      /// <param name="y">The second object to compare.</param>
      /// <returns>
      /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
      /// </returns>
      public int Compare(AdministrationContent x, AdministrationContent y) => x.Index.CompareTo(y.Index);
    }
  }
}
