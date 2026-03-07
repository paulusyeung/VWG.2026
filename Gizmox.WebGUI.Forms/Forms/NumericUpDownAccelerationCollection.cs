// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.NumericUpDownAccelerationCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a sorted collection of <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> objects in the <see cref="T:System.Windows.Forms.NumericUpDown"></see> control.</summary>
  [Obsolete("Not implemented. Added for migration compatibility")]
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [ListBindable(false)]
  [Serializable]
  public class NumericUpDownAccelerationCollection : 
    MarshalByRefObject,
    ICollection<NumericUpDownAcceleration>,
    IEnumerable<NumericUpDownAcceleration>,
    IEnumerable
  {
    /// <summary>Adds a new <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
    /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to add to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
    /// <exception cref="T:System.ArgumentNullException">acceleration is null.</exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void Add(NumericUpDownAcceleration acceleration)
    {
    }

    /// <summary>Adds the elements of the specified array to the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>, keeping the collection sorted.</summary>
    /// <param name="accelerations">An array of type <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>  containing the objects to add to the collection.</param>
    /// <exception cref="T:System.ArgumentNullException">accelerations is null, or one of the entries in the accelerations array is null.</exception>
    public void AddRange(params NumericUpDownAcceleration[] accelerations)
    {
    }

    /// <summary>Removes all elements from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void Clear()
    {
    }

    /// <summary>Determines whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> contains a specific <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see>.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is found in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
    /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to locate in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Contains(NumericUpDownAcceleration acceleration) => false;

    /// <summary>Copies the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> values to a one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> instance at the specified index.</summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> that is the destination of the values copied from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>. </param>
    /// <param name="index">The index in array where copying begins.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void CopyTo(NumericUpDownAcceleration[] array, int index)
    {
    }

    /// <summary>Removes the first occurrence of the specified <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> from the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
    /// <returns>true if the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> is removed from <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>; otherwise, false.</returns>
    /// <param name="acceleration">The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to remove from the collection.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Remove(NumericUpDownAcceleration acceleration) => false;

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    IEnumerator<NumericUpDownAcceleration> IEnumerable<NumericUpDownAcceleration>.GetEnumerator() => (IEnumerator<NumericUpDownAcceleration>) null;

    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) null;

    /// <summary>Gets the number of objects in the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see>.</summary>
    /// <returns>The number of objects in the collection.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int Count => 0;

    /// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.NumericUpDownAccelerationCollection"></see> is read-only.</summary>
    /// <returns>true if the collectionms-help://MS.VSCC.2003/MS.MSDNQTR.2003FEB.1033/cpref/html/frlrfsystemcollectionsilistclasstopic.htm is read-only; otherwise, false.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsReadOnly => false;

    /// <summary>Gets the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> at the specified index number.</summary>
    /// <returns>The <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> with the specified index.</returns>
    /// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.NumericUpDownAcceleration"></see> to get from the collection.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NumericUpDownAcceleration this[int index] => (NumericUpDownAcceleration) null;
  }
}
