// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.MultiSelectRootGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class MultiSelectRootGridEntry : SingleSelectRootGridEntry
  {
    private static MultiSelectRootGridEntry.PDComparer PropertyComparer = new MultiSelectRootGridEntry.PDComparer();

    internal MultiSelectRootGridEntry(
      PropertyGridView objPropertyGridView,
      object obj,
      IServiceProvider objBaseProvider,
      IDesignerHost objHost,
      PropertyTab objPropertyTab,
      PropertySort objSortType)
      : base(objPropertyGridView, obj, objBaseProvider, objHost, objPropertyTab, objSortType)
    {
    }

    protected override bool CreateChildren() => this.CreateChildren(false);

    protected override bool CreateChildren(bool blnDiffOldChildren)
    {
      try
      {
        object[] objValue = (object[]) this.objValue;
        this.ChildCollection.Clear();
        int menmPropertySort = (int) this.menmPropertySort;
        PropertyTab currentTab = this.CurrentTab;
        MultiPropertyDescriptorGridEntry[] mergedProperties = MultiSelectRootGridEntry.PropertyMerger.GetMergedProperties(objValue, (GridEntry) this, (PropertySort) menmPropertySort, currentTab);
        if (mergedProperties != null)
          this.ChildCollection.AddRange((GridEntry[]) mergedProperties);
        int num = this.Children.Count > 0 ? 1 : 0;
        if (num == 0)
          this.SetState(524288, true);
        this.CategorizePropEntries();
        return num != 0;
      }
      catch
      {
        return false;
      }
    }

    internal override bool ForceReadOnly
    {
      get
      {
        if (!this.forceReadOnlyChecked)
        {
          bool flag = false;
          foreach (object component in (Array) this.objValue)
          {
            ReadOnlyAttribute attribute = (ReadOnlyAttribute) TypeDescriptor.GetAttributes(component)[typeof (ReadOnlyAttribute)];
            if (attribute != null && !attribute.IsDefaultAttribute() || TypeDescriptor.GetAttributes(component).Contains((Attribute) InheritanceAttribute.InheritedReadOnly))
            {
              flag = true;
              break;
            }
          }
          if (flag)
            this.State |= 1024;
          this.forceReadOnlyChecked = true;
        }
        return base.ForceReadOnly;
      }
    }

    [Serializable]
    private class PDComparer : IComparer
    {
      public int Compare(object obj1, object obj2)
      {
        PropertyDescriptor propertyDescriptor1 = obj1 as PropertyDescriptor;
        PropertyDescriptor propertyDescriptor2 = obj2 as PropertyDescriptor;
        if (propertyDescriptor1 == null && propertyDescriptor2 == null)
          return 0;
        if (propertyDescriptor1 == null)
          return -1;
        if (propertyDescriptor2 == null)
          return 1;
        int num = string.Compare(propertyDescriptor1.Name, propertyDescriptor2.Name, false, CultureInfo.InvariantCulture);
        if (num == 0)
          num = string.Compare(propertyDescriptor1.PropertyType.FullName, propertyDescriptor2.PropertyType.FullName, true, CultureInfo.CurrentCulture);
        return num;
      }
    }

    [Serializable]
    internal class PropertyMerger
    {
      private static ArrayList GetCommonProperties(
        object[] arrObjects,
        bool blnPresort,
        PropertyTab objPropertyTab,
        GridEntry objParentEntry)
      {
        PropertyDescriptorCollection[] descriptorCollectionArray = new PropertyDescriptorCollection[arrObjects.Length];
        Attribute[] arrAttributes = new Attribute[objParentEntry.BrowsableAttributes.Count];
        objParentEntry.BrowsableAttributes.CopyTo((Array) arrAttributes, 0);
        for (int index = 0; index < arrObjects.Length; ++index)
        {
          PropertyDescriptorCollection descriptorCollection = objPropertyTab.GetProperties((ITypeDescriptorContext) objParentEntry, arrObjects[index], arrAttributes);
          if (blnPresort)
            descriptorCollection = descriptorCollection.Sort((IComparer) MultiSelectRootGridEntry.PropertyComparer);
          descriptorCollectionArray[index] = descriptorCollection;
        }
        ArrayList commonProperties = new ArrayList();
        PropertyDescriptor[] propertyDescriptorArray = new PropertyDescriptor[arrObjects.Length];
        int[] numArray = new int[descriptorCollectionArray.Length];
        for (int index1 = 0; index1 < descriptorCollectionArray[0].Count; ++index1)
        {
          PropertyDescriptor propertyDescriptor1 = descriptorCollectionArray[0][index1];
          bool flag = propertyDescriptor1.Attributes[typeof (MergablePropertyAttribute)].IsDefaultAttribute();
          for (int index2 = 1; flag && index2 < descriptorCollectionArray.Length; ++index2)
          {
            if (numArray[index2] >= descriptorCollectionArray[index2].Count)
            {
              flag = false;
              break;
            }
            PropertyDescriptor propertyDescriptor2 = descriptorCollectionArray[index2][numArray[index2]];
            if (propertyDescriptor1.Equals((object) propertyDescriptor2))
            {
              ++numArray[index2];
              if (!propertyDescriptor2.Attributes[typeof (MergablePropertyAttribute)].IsDefaultAttribute())
              {
                flag = false;
                break;
              }
              propertyDescriptorArray[index2] = propertyDescriptor2;
            }
            else
            {
              int index3 = numArray[index2];
              PropertyDescriptor propertyDescriptor3 = descriptorCollectionArray[index2][index3];
              flag = false;
              for (; MultiSelectRootGridEntry.PropertyComparer.Compare((object) propertyDescriptor3, (object) propertyDescriptor1) <= 0; propertyDescriptor3 = descriptorCollectionArray[index2][index3])
              {
                if (propertyDescriptor1.Equals((object) propertyDescriptor3))
                {
                  if (!propertyDescriptor3.Attributes[typeof (MergablePropertyAttribute)].IsDefaultAttribute())
                  {
                    flag = false;
                    ++index3;
                    break;
                  }
                  flag = true;
                  propertyDescriptorArray[index2] = propertyDescriptor3;
                  numArray[index2] = index3 + 1;
                  break;
                }
                ++index3;
                if (index3 >= descriptorCollectionArray[index2].Count)
                  break;
              }
              if (!flag)
              {
                numArray[index2] = index3;
                break;
              }
            }
          }
          if (flag)
          {
            propertyDescriptorArray[0] = propertyDescriptor1;
            commonProperties.Add(propertyDescriptorArray.Clone());
          }
        }
        return commonProperties;
      }

      /// <summary>Gets the merged properties.</summary>
      /// <param name="arrObjects">The arr objects.</param>
      /// <param name="objParentEntry">The obj parent entry.</param>
      /// <param name="objSort">The obj sort.</param>
      /// <param name="objPropertyTab">The obj property tab.</param>
      /// <returns></returns>
      public static MultiPropertyDescriptorGridEntry[] GetMergedProperties(
        object[] arrObjects,
        GridEntry objParentEntry,
        PropertySort objSort,
        PropertyTab objPropertyTab)
      {
        try
        {
          int length = arrObjects.Length;
          if ((objSort & PropertySort.Alphabetical) != PropertySort.NoSort)
          {
            ArrayList commonProperties = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(arrObjects, true, objPropertyTab, objParentEntry);
            MultiPropertyDescriptorGridEntry[] arrEntries = new MultiPropertyDescriptorGridEntry[commonProperties.Count];
            for (int index = 0; index < arrEntries.Length; ++index)
              arrEntries[index] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[]) commonProperties[index], false);
            return MultiSelectRootGridEntry.PropertyMerger.SortParenEntries(arrEntries);
          }
          object[] objArray = new object[length - 1];
          Array.Copy((Array) arrObjects, 1, (Array) objArray, 0, length - 1);
          ArrayList commonProperties1 = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(objArray, true, objPropertyTab, objParentEntry);
          ArrayList commonProperties2 = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(new object[1]
          {
            arrObjects[0]
          }, false, objPropertyTab, objParentEntry);
          PropertyDescriptor[] arrBaseEntries = new PropertyDescriptor[commonProperties2.Count];
          for (int index = 0; index < commonProperties2.Count; ++index)
            arrBaseEntries[index] = ((PropertyDescriptor[]) commonProperties2[index])[0];
          ArrayList arrayList = MultiSelectRootGridEntry.PropertyMerger.UnsortedMerge(arrBaseEntries, commonProperties1);
          MultiPropertyDescriptorGridEntry[] arrEntries1 = new MultiPropertyDescriptorGridEntry[arrayList.Count];
          for (int index = 0; index < arrEntries1.Length; ++index)
            arrEntries1[index] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[]) arrayList[index], false);
          return MultiSelectRootGridEntry.PropertyMerger.SortParenEntries(arrEntries1);
        }
        catch
        {
          return (MultiPropertyDescriptorGridEntry[]) null;
        }
      }

      private static MultiPropertyDescriptorGridEntry[] SortParenEntries(
        MultiPropertyDescriptorGridEntry[] arrEntries)
      {
        MultiPropertyDescriptorGridEntry[] descriptorGridEntryArray = (MultiPropertyDescriptorGridEntry[]) null;
        int num = 0;
        for (int index = 0; index < arrEntries.Length; ++index)
        {
          if (arrEntries[index].ParensAroundName)
          {
            if (descriptorGridEntryArray == null)
              descriptorGridEntryArray = new MultiPropertyDescriptorGridEntry[arrEntries.Length];
            descriptorGridEntryArray[num++] = arrEntries[index];
            arrEntries[index] = (MultiPropertyDescriptorGridEntry) null;
          }
        }
        if (num > 0)
        {
          for (int index = 0; index < arrEntries.Length; ++index)
          {
            if (arrEntries[index] != null)
              descriptorGridEntryArray[num++] = arrEntries[index];
          }
          arrEntries = descriptorGridEntryArray;
        }
        return arrEntries;
      }

      private static ArrayList UnsortedMerge(
        PropertyDescriptor[] arrBaseEntries,
        ArrayList sortedMergedEntries)
      {
        ArrayList arrayList = new ArrayList();
        PropertyDescriptor[] destinationArray = new PropertyDescriptor[((PropertyDescriptor[]) sortedMergedEntries[0]).Length + 1];
        for (int index = 0; index < arrBaseEntries.Length; ++index)
        {
          PropertyDescriptor arrBaseEntry = arrBaseEntries[index];
          PropertyDescriptor[] sourceArray = (PropertyDescriptor[]) null;
          string strA = arrBaseEntry.Name + " " + arrBaseEntry.PropertyType.FullName;
          int num1 = sortedMergedEntries.Count;
          int num2 = num1 / 2;
          int num3 = 0;
          while (num1 > 0)
          {
            PropertyDescriptor[] sortedMergedEntry = (PropertyDescriptor[]) sortedMergedEntries[num3 + num2];
            PropertyDescriptor propertyDescriptor = sortedMergedEntry[0];
            string strB = propertyDescriptor.Name + " " + propertyDescriptor.PropertyType.FullName;
            int num4 = string.Compare(strA, strB, false, CultureInfo.InvariantCulture);
            if (num4 == 0)
            {
              sourceArray = sortedMergedEntry;
              break;
            }
            if (num4 < 0)
            {
              num1 = num2;
            }
            else
            {
              int num5 = num2 + 1;
              num3 += num5;
              num1 -= num5;
            }
            num2 = num1 / 2;
          }
          if (sourceArray != null)
          {
            destinationArray[0] = arrBaseEntry;
            Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 1, sourceArray.Length);
            arrayList.Add(destinationArray.Clone());
          }
        }
        return arrayList;
      }
    }
  }
}
