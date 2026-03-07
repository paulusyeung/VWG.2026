// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Layout.IArrangedElement
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Layout
{
  /// <summary>
  /// 
  /// </summary>
  internal interface IArrangedElement : IComponent, IDisposable
  {
    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objProposedSize">Size of the proposed.</param>
    /// <returns></returns>
    Size GetPreferredSize(Size objProposedSize);

    /// <summary>Gets the children.</summary>
    /// <value>The children.</value>
    ArrangedElementCollection Children { get; }

    /// <summary>
    /// Gets a value indicating whether [participates in layout].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [participates in layout]; otherwise, <c>false</c>.
    /// </value>
    bool ParticipatesInLayout { get; }

    /// <summary>Sets the bounds.</summary>
    /// <param name="objBounds">The bounds.</param>
    /// <param name="enmSpecified">The specified.</param>
    void SetBounds(Rectangle objBounds, BoundsSpecified enmSpecified);

    /// <summary>Gets the bounds.</summary>
    /// <value>The bounds.</value>
    Rectangle Bounds { get; }

    /// <summary>Gets the value.</summary>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <returns></returns>
    T GetValue<T>(SerializableProperty objSerializableProperty);

    /// <summary>Sets the value.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objSerializableProperty">The serializable property.</param>
    /// <param name="objValue">The obj value.</param>
    void SetValue<T>(SerializableProperty objSerializableProperty, T objValue);
  }
}
