// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.MergePropertyDescriptor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class MergePropertyDescriptor : PropertyDescriptor
  {
    private MergePropertyDescriptor.TriState menmCanReset;
    private MergePropertyDescriptor.MultiMergeCollection mobjCollection;
    private PropertyDescriptor[] marrDescriptors;
    private MergePropertyDescriptor.TriState menmLocalizable;
    private MergePropertyDescriptor.TriState menmReadOnly;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyGridInternal.MergePropertyDescriptor" /> class.
    /// </summary>
    /// <param name="arrDescriptors">The arr descriptors.</param>
    public MergePropertyDescriptor(PropertyDescriptor[] arrDescriptors)
      : base(arrDescriptors[0].Name, (Attribute[]) null)
    {
      this.marrDescriptors = arrDescriptors;
    }

    public override bool CanResetValue(object objComponent)
    {
      if (this.menmCanReset == MergePropertyDescriptor.TriState.Unknown)
      {
        this.menmCanReset = MergePropertyDescriptor.TriState.Yes;
        Array objArray = (Array) objComponent;
        for (int i = 0; i < this.marrDescriptors.Length; ++i)
        {
          if (!this.marrDescriptors[i].CanResetValue(this.GetPropertyOwnerForComponent(objArray, i)))
          {
            this.menmCanReset = MergePropertyDescriptor.TriState.No;
            break;
          }
        }
      }
      return this.menmCanReset == MergePropertyDescriptor.TriState.Yes;
    }

    private object CopyValue(object objValue)
    {
      if (objValue != null)
      {
        Type type = objValue.GetType();
        if (type.IsValueType)
          return objValue;
        object obj = (object) null;
        if (objValue is ICloneable cloneable)
          obj = cloneable.Clone();
        if (obj == null)
        {
          TypeConverter converter = TypeDescriptor.GetConverter(objValue);
          if (converter.CanConvertTo(typeof (InstanceDescriptor)))
          {
            InstanceDescriptor instanceDescriptor = (InstanceDescriptor) converter.ConvertTo((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, objValue, typeof (InstanceDescriptor));
            if (instanceDescriptor != null && instanceDescriptor.IsComplete)
              obj = instanceDescriptor.Invoke();
          }
          if (obj == null && converter.CanConvertTo(typeof (string)) && converter.CanConvertFrom(typeof (string)))
          {
            object invariantString = (object) converter.ConvertToInvariantString(objValue);
            obj = converter.ConvertFromInvariantString((string) invariantString);
          }
        }
        if (obj == null && type.IsSerializable)
        {
          BinaryFormatter binaryFormatter = new BinaryFormatter();
          MemoryStream serializationStream = new MemoryStream();
          binaryFormatter.Serialize((Stream) serializationStream, objValue);
          serializationStream.Position = 0L;
          obj = binaryFormatter.Deserialize((Stream) serializationStream);
        }
        if (obj != null)
          return obj;
      }
      return objValue;
    }

    protected override AttributeCollection CreateAttributeCollection() => (AttributeCollection) new MergePropertyDescriptor.MergedAttributeCollection(this);

    public override object GetEditor(Type objEditorBaseType) => this.marrDescriptors[0].GetEditor(objEditorBaseType);

    private object GetPropertyOwnerForComponent(Array objArray, int i)
    {
      object propertyOwner = objArray.GetValue(i);
      if (propertyOwner is ICustomTypeDescriptor)
        propertyOwner = ((ICustomTypeDescriptor) propertyOwner).GetPropertyOwner(this.marrDescriptors[i]);
      return propertyOwner;
    }

    public override object GetValue(object objComponent) => this.GetValue((Array) objComponent, out bool _);

    public object GetValue(Array objComponentsArray, out bool blnAllEqual)
    {
      blnAllEqual = true;
      object obj = this.marrDescriptors[0].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, 0));
      if (obj is ICollection)
      {
        if (this.mobjCollection == null)
        {
          this.mobjCollection = new MergePropertyDescriptor.MultiMergeCollection((ICollection) obj);
        }
        else
        {
          if (this.mobjCollection.Locked)
            return (object) this.mobjCollection;
          this.mobjCollection.SetItems((ICollection) obj);
        }
      }
      for (int i = 1; i < this.marrDescriptors.Length; ++i)
      {
        object objNewCollection = this.marrDescriptors[i].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, i));
        if (this.mobjCollection != null)
        {
          if (!this.mobjCollection.MergeCollection((ICollection) objNewCollection))
          {
            blnAllEqual = false;
            return (object) null;
          }
        }
        else if ((obj != null || objNewCollection != null) && (obj == null || !obj.Equals(objNewCollection)))
        {
          blnAllEqual = false;
          return (object) null;
        }
      }
      if (blnAllEqual && this.mobjCollection != null && this.mobjCollection.Count == 0)
        return (object) null;
      return this.mobjCollection == null ? obj : (object) this.mobjCollection;
    }

    internal object[] GetValues(Array objComponentsArray)
    {
      object[] values = new object[objComponentsArray.Length];
      for (int i = 0; i < objComponentsArray.Length; ++i)
        values[i] = this.marrDescriptors[i].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, i));
      return values;
    }

    public override void ResetValue(object objComponent)
    {
      Array objArray = (Array) objComponent;
      for (int i = 0; i < this.marrDescriptors.Length; ++i)
        this.marrDescriptors[i].ResetValue(this.GetPropertyOwnerForComponent(objArray, i));
    }

    private void SetCollectionValues(Array objArray, IList objListValue)
    {
      try
      {
        if (this.mobjCollection != null)
          this.mobjCollection.Locked = true;
        object[] objArray1 = new object[objListValue.Count];
        objListValue.CopyTo((Array) objArray1, 0);
        for (int i = 0; i < this.marrDescriptors.Length; ++i)
        {
          if (this.marrDescriptors[i].GetValue(this.GetPropertyOwnerForComponent(objArray, i)) is IList list)
          {
            list.Clear();
            foreach (object obj in objArray1)
              list.Add(obj);
          }
        }
      }
      finally
      {
        if (this.mobjCollection != null)
          this.mobjCollection.Locked = false;
      }
    }

    public override void SetValue(object objComponent, object objValue)
    {
      Array objArray = (Array) objComponent;
      if (objValue is IList && typeof (IList).IsAssignableFrom(this.PropertyType))
      {
        this.SetCollectionValues(objArray, (IList) objValue);
      }
      else
      {
        for (int i = 0; i < this.marrDescriptors.Length; ++i)
        {
          object obj = this.CopyValue(objValue);
          this.marrDescriptors[i].SetValue(this.GetPropertyOwnerForComponent(objArray, i), obj);
        }
      }
    }

    public override bool ShouldSerializeValue(object objComponent)
    {
      Array objArray = (Array) objComponent;
      for (int i = 0; i < this.marrDescriptors.Length; ++i)
      {
        if (!this.marrDescriptors[i].ShouldSerializeValue(this.GetPropertyOwnerForComponent(objArray, i)))
          return false;
      }
      return true;
    }

    public override Type ComponentType => this.marrDescriptors[0].ComponentType;

    public override TypeConverter Converter => this.marrDescriptors[0].Converter;

    public override string DisplayName => this.marrDescriptors[0].DisplayName;

    public override bool IsLocalizable
    {
      get
      {
        if (this.menmLocalizable == MergePropertyDescriptor.TriState.Unknown)
        {
          this.menmLocalizable = MergePropertyDescriptor.TriState.Yes;
          foreach (PropertyDescriptor marrDescriptor in this.marrDescriptors)
          {
            if (!marrDescriptor.IsLocalizable)
            {
              this.menmLocalizable = MergePropertyDescriptor.TriState.No;
              break;
            }
          }
        }
        return this.menmLocalizable == MergePropertyDescriptor.TriState.Yes;
      }
    }

    public override bool IsReadOnly
    {
      get
      {
        if (this.menmReadOnly == MergePropertyDescriptor.TriState.Unknown)
        {
          this.menmReadOnly = MergePropertyDescriptor.TriState.No;
          foreach (PropertyDescriptor marrDescriptor in this.marrDescriptors)
          {
            if (marrDescriptor.IsReadOnly)
            {
              this.menmReadOnly = MergePropertyDescriptor.TriState.Yes;
              break;
            }
          }
        }
        return this.menmReadOnly == MergePropertyDescriptor.TriState.Yes;
      }
    }

    public PropertyDescriptor this[int index] => this.marrDescriptors[index];

    public override Type PropertyType => this.marrDescriptors[0].PropertyType;

    [Serializable]
    private class MergedAttributeCollection : AttributeCollection
    {
      private AttributeCollection[] marrAttributeCollections;
      private IDictionary mobjFoundAttributes;
      private MergePropertyDescriptor mobjOwner;

      public MergedAttributeCollection(MergePropertyDescriptor objOwner)
        : base((Attribute[]) null)
      {
        this.mobjOwner = objOwner;
      }

      private Attribute GetCommonAttribute(Type objAttributeType)
      {
        if (this.marrAttributeCollections == null)
        {
          this.marrAttributeCollections = new AttributeCollection[this.mobjOwner.marrDescriptors.Length];
          for (int index = 0; index < this.mobjOwner.marrDescriptors.Length; ++index)
            this.marrAttributeCollections[index] = this.mobjOwner.marrDescriptors[index].Attributes;
        }
        if (this.marrAttributeCollections.Length == 0)
          return this.GetDefaultAttribute(objAttributeType);
        if (this.mobjFoundAttributes != null && this.mobjFoundAttributes[(object) objAttributeType] is Attribute mobjFoundAttribute)
          return mobjFoundAttribute;
        Attribute defaultAttribute = this.marrAttributeCollections[0][objAttributeType];
        if (defaultAttribute == null)
          return (Attribute) null;
        for (int index = 1; index < this.marrAttributeCollections.Length; ++index)
        {
          Attribute attribute = this.marrAttributeCollections[index][objAttributeType];
          if (!defaultAttribute.Equals((object) attribute))
          {
            defaultAttribute = this.GetDefaultAttribute(objAttributeType);
            break;
          }
        }
        if (this.mobjFoundAttributes == null)
          this.mobjFoundAttributes = (IDictionary) new Hashtable();
        this.mobjFoundAttributes[(object) objAttributeType] = (object) defaultAttribute;
        return defaultAttribute;
      }

      public override Attribute this[Type objAttributeType] => this.GetCommonAttribute(objAttributeType);
    }

    [Serializable]
    private class MultiMergeCollection : ICollection, IEnumerable
    {
      private object[] marrItems;
      private bool mblnLocked;

      public MultiMergeCollection(ICollection original) => this.SetItems(original);

      public void CopyTo(Array objArray, int index)
      {
        if (this.marrItems == null)
          return;
        Array.Copy((Array) this.marrItems, 0, objArray, index, this.marrItems.Length);
      }

      public IEnumerator GetEnumerator() => this.marrItems != null ? this.marrItems.GetEnumerator() : new object[0].GetEnumerator();

      public bool MergeCollection(ICollection objNewCollection)
      {
        if (!this.mblnLocked)
        {
          if (this.marrItems.Length != objNewCollection.Count)
          {
            this.marrItems = new object[0];
            return false;
          }
          object[] objArray = new object[objNewCollection.Count];
          objNewCollection.CopyTo((Array) objArray, 0);
          for (int index = 0; index < objArray.Length; ++index)
          {
            if (objArray[index] == null != (this.marrItems[index] == null) || this.marrItems[index] != null && !this.marrItems[index].Equals(objArray[index]))
            {
              this.marrItems = new object[0];
              return false;
            }
          }
        }
        return true;
      }

      public void SetItems(ICollection objCollection)
      {
        if (this.mblnLocked)
          return;
        this.marrItems = new object[objCollection.Count];
        objCollection.CopyTo((Array) this.marrItems, 0);
      }

      public int Count => this.marrItems != null ? this.marrItems.Length : 0;

      public bool Locked
      {
        get => this.mblnLocked;
        set => this.mblnLocked = value;
      }

      bool ICollection.IsSynchronized => false;

      object ICollection.SyncRoot => (object) this;
    }

    private enum TriState
    {
      Unknown,
      Yes,
      No,
    }
  }
}
