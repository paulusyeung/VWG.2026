// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.BaseCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides the base functionality for creating data-related collections in the <see cref="N:Gizmox.WebGUI.Forms"></see> namespace.</summary>
  /// <filterpriority>2</filterpriority>
  [Serializable]
  public class BaseCollection : ICollection, IEnumerable
  {
    /// <summary>Copies all the elements of the current one-dimensional <see cref="T:System.Array"></see> to the specified one-dimensional <see cref="T:System.Array"></see> starting at the specified destination <see cref="T:System.Array"></see> index.</summary>
    /// <param name="objArray">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from the current Array. </param>
    /// <param name="index">The zero-based relative index in ar at which copying begins. </param>
    /// <filterpriority>1</filterpriority>
    public void CopyTo(Array objArray, int index) => this.List.CopyTo(objArray, index);

    /// <summary>Gets the object that enables iterating through the members of the collection.</summary>
    /// <returns>An object that implements the <see cref="T:System.Collections.IEnumerator"></see> interface.</returns>
    /// <filterpriority>1</filterpriority>
    public IEnumerator GetEnumerator() => this.List.GetEnumerator();

    /// <summary>Gets the total number of elements in the collection.</summary>
    /// <returns>The total number of elements in the collection.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual int Count => this.List.Count;

    /// <summary>Gets a value indicating whether the collection is read-only.</summary>
    /// <returns>This property is always false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public bool IsReadOnly => false;

    /// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"></see> is synchronized.</summary>
    /// <returns>This property always returns false.</returns>
    /// <filterpriority>2</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public bool IsSynchronized => false;

    /// <summary>Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.</summary>
    /// <returns>An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
    protected virtual ArrayList List => (ArrayList) null;

    /// <summary>Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see>.</summary>
    /// <returns>An object that can be used to synchronize the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public object SyncRoot => (object) this;
  }
}
