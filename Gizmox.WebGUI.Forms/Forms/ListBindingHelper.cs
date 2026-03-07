// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ListBindingHelper
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides functionality to discover a bindable list and the properties of the items contained in the list when they differ from the public properties of the object to which they bind.</summary>
  [Serializable]
  public class ListBindingHelper
  {
    private static Attribute[] marrBrowsableAttribute;

    private static object GetFirstItemByEnumerable(IEnumerable enumerable)
    {
      object itemByEnumerable = (object) null;
      if (enumerable is IList)
      {
        IList list = enumerable as IList;
        return list.Count <= 0 ? (object) null : list[0];
      }
      try
      {
        IEnumerator enumerator = enumerable.GetEnumerator();
        enumerator.Reset();
        if (enumerator.MoveNext())
          itemByEnumerable = enumerator.Current;
        enumerator.Reset();
      }
      catch (NotSupportedException ex)
      {
        itemByEnumerable = (object) null;
      }
      return itemByEnumerable;
    }

    /// <summary>Returns a list associated with the specified data source.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the underlying list if it exists; otherwise, the original data source specified by list.</returns>
    /// <param name="objList">The data source to examine for its underlying list.</param>
    public static object GetList(object objList) => objList is IListSource ? (object) (objList as IListSource).GetList() : objList;

    /// <summary>Returns an object, typically a list, from the evaluation of a specified data source and optional data member.</summary>
    /// <returns>An <see cref="T:System.Object"></see> representing the underlying list if it was found; otherwise, dataSource.</returns>
    /// <param name="objDataSource">The data source from which to find the list.</param>
    /// <param name="strDataMember">The name of the data source property that contains the list. This can be null.</param>
    /// <exception cref="T:System.ArgumentException">The specified data member name did not match any of the properties found for the data source.</exception>
    public static object GetList(object objDataSource, string strDataMember)
    {
      objDataSource = ListBindingHelper.GetList(objDataSource);
      if (objDataSource != null && (object) (objDataSource as Type) == null)
      {
        if (!CommonUtils.IsNullOrEmpty(strDataMember))
        {
          PropertyDescriptor propertyDescriptor = ListBindingHelper.GetListItemProperties(objDataSource).Find(strDataMember, true);
          if (propertyDescriptor == null)
            throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", (object) strDataMember));
          object component;
          switch (objDataSource)
          {
            case ICurrencyManagerProvider _:
              CurrencyManager currencyManager = (objDataSource as ICurrencyManagerProvider).CurrencyManager;
              component = currencyManager == null || currencyManager.Position < 0 || currencyManager.Position > currencyManager.Count - 1 ? (object) null : currencyManager.Current;
              break;
            case IEnumerable _:
              component = ListBindingHelper.GetFirstItemByEnumerable(objDataSource as IEnumerable);
              break;
            default:
              component = objDataSource;
              break;
          }
          return component != null ? propertyDescriptor.GetValue(component) : (object) null;
        }
      }
      return objDataSource;
    }

    /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a specified data source, or properties of the specified data source.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> containing the properties of the items contained in list, or properties of list.</returns>
    /// <param name="objList">The data source to examine for property information.</param>
    public static PropertyDescriptorCollection GetListItemProperties(object objList)
    {
      if (objList == null)
        return new PropertyDescriptorCollection((PropertyDescriptor[]) null);
      if ((object) (objList as Type) != null)
        return ListBindingHelper.GetListItemPropertiesByType(objList as Type);
      object list = ListBindingHelper.GetList(objList);
      switch (list)
      {
        case ITypedList _:
          return (list as ITypedList).GetItemProperties((PropertyDescriptor[]) null);
        case IEnumerable _:
          return ListBindingHelper.GetListItemPropertiesByEnumerable(list as IEnumerable);
        default:
          return TypeDescriptor.GetProperties(list);
      }
    }

    /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in a collection property of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of the item type contained in a collection property of the data source.</returns>
    /// <param name="objList">The data source to be examined for property information.</param>
    /// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data source to examine. This can be null.</param>
    public static PropertyDescriptorCollection GetListItemProperties(
      object objList,
      PropertyDescriptor[] arrListAccessors)
    {
      if (arrListAccessors == null || arrListAccessors.Length == 0)
        return ListBindingHelper.GetListItemProperties(objList);
      if ((object) (objList as Type) != null)
        return ListBindingHelper.GetListItemPropertiesByType(objList as Type, arrListAccessors);
      object list = ListBindingHelper.GetList(objList);
      switch (list)
      {
        case ITypedList _:
          return (list as ITypedList).GetItemProperties(arrListAccessors);
        case IEnumerable _:
          return ListBindingHelper.GetListItemPropertiesByEnumerable(list as IEnumerable, arrListAccessors);
        default:
          return ListBindingHelper.GetListItemPropertiesByInstance(list, arrListAccessors, 0);
      }
    }

    /// <summary>Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that describes the properties of an item type contained in the specified data member of a data source. Uses the specified <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array to indicate which properties to examine.</summary>
    /// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> describing the properties of an item type contained in a collection property of the specified data source.</returns>
    /// <param name="objDataSource">The data source to be examined for property information.</param>
    /// <param name="strDataMember">The optional data member to be examined for property information. This can be null.</param>
    /// <param name="arrListAccessors">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array describing which properties of the data member to examine. This can be null.</param>
    /// <exception cref="T:System.ArgumentException">The specified data member could not be found in the specified data source.</exception>
    public static PropertyDescriptorCollection GetListItemProperties(
      object objDataSource,
      string strDataMember,
      PropertyDescriptor[] arrListAccessors)
    {
      objDataSource = ListBindingHelper.GetList(objDataSource);
      if (!CommonUtils.IsNullOrEmpty(strDataMember))
      {
        PropertyDescriptor propertyDescriptor = ListBindingHelper.GetListItemProperties(objDataSource).Find(strDataMember, true);
        if (propertyDescriptor == null)
          throw new ArgumentException(SR.GetString("DataSourceDataMemberPropNotFound", (object) strDataMember));
        int length = arrListAccessors == null ? 1 : arrListAccessors.Length + 1;
        PropertyDescriptor[] propertyDescriptorArray = new PropertyDescriptor[length];
        propertyDescriptorArray[0] = propertyDescriptor;
        for (int index = 1; index < length; ++index)
          propertyDescriptorArray[index] = arrListAccessors[index - 1];
        arrListAccessors = propertyDescriptorArray;
      }
      return ListBindingHelper.GetListItemProperties(objDataSource, arrListAccessors);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(
      IEnumerable enumerable)
    {
      PropertyDescriptorCollection propertiesByEnumerable = (PropertyDescriptorCollection) null;
      Type type = enumerable.GetType();
      if (typeof (Array).IsAssignableFrom(type))
        propertiesByEnumerable = TypeDescriptor.GetProperties(type.GetElementType(), ListBindingHelper.BrowsableAttributeList);
      else if (enumerable is ITypedList typedList)
      {
        propertiesByEnumerable = typedList.GetItemProperties((PropertyDescriptor[]) null);
      }
      else
      {
        PropertyInfo typedIndexer = ListBindingHelper.GetTypedIndexer(type);
        if (typedIndexer != (PropertyInfo) null && !typeof (ICustomTypeDescriptor).IsAssignableFrom(typedIndexer.PropertyType))
          propertiesByEnumerable = TypeDescriptor.GetProperties(typedIndexer.PropertyType, ListBindingHelper.BrowsableAttributeList);
      }
      if (propertiesByEnumerable != null)
        return propertiesByEnumerable;
      object itemByEnumerable = ListBindingHelper.GetFirstItemByEnumerable(enumerable);
      if (!(enumerable is string))
      {
        if (itemByEnumerable == null)
          return new PropertyDescriptorCollection((PropertyDescriptor[]) null);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(itemByEnumerable, ListBindingHelper.BrowsableAttributeList);
        if (enumerable is IList || properties != null && properties.Count != 0)
          return properties;
      }
      return TypeDescriptor.GetProperties((object) enumerable, ListBindingHelper.BrowsableAttributeList);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(
      IEnumerable enumerable,
      PropertyDescriptor[] arrListAccessors)
    {
      if (arrListAccessors == null || arrListAccessors.Length == 0)
        return ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable);
      return enumerable is ITypedList typedList ? typedList.GetItemProperties(arrListAccessors) : ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable, arrListAccessors, 0);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByEnumerable(
      IEnumerable iEnumerable,
      PropertyDescriptor[] arrListAccessors,
      int intStartIndex)
    {
      object objTarget = (object) null;
      object itemByEnumerable = ListBindingHelper.GetFirstItemByEnumerable(iEnumerable);
      if (itemByEnumerable != null)
        objTarget = ListBindingHelper.GetList(arrListAccessors[intStartIndex].GetValue(itemByEnumerable));
      if (objTarget == null)
        return ListBindingHelper.GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType, arrListAccessors, intStartIndex);
      ++intStartIndex;
      if (!(objTarget is IEnumerable enumerable))
        return ListBindingHelper.GetListItemPropertiesByInstance(objTarget, arrListAccessors, intStartIndex);
      return intStartIndex == arrListAccessors.Length ? ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable) : ListBindingHelper.GetListItemPropertiesByEnumerable(enumerable, arrListAccessors, intStartIndex);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByInstance(
      object objTarget,
      PropertyDescriptor[] arrListAccessors,
      int intStartIndex)
    {
      if (arrListAccessors == null || arrListAccessors.Length <= intStartIndex)
        return TypeDescriptor.GetProperties(objTarget, ListBindingHelper.BrowsableAttributeList);
      object objList = arrListAccessors[intStartIndex].GetValue(objTarget);
      if (objList == null)
        return ListBindingHelper.GetListItemPropertiesByType(arrListAccessors[intStartIndex].PropertyType);
      PropertyDescriptor[] arrListAccessors1 = (PropertyDescriptor[]) null;
      if (arrListAccessors.Length > intStartIndex + 1)
      {
        int length = arrListAccessors.Length - (intStartIndex + 1);
        arrListAccessors1 = new PropertyDescriptor[length];
        for (int index = 0; index < length; ++index)
          arrListAccessors1[index] = arrListAccessors[intStartIndex + 1 + index];
      }
      return ListBindingHelper.GetListItemProperties(objList, arrListAccessors1);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByType(Type objType) => TypeDescriptor.GetProperties(ListBindingHelper.GetListItemType((object) objType), ListBindingHelper.BrowsableAttributeList);

    private static PropertyDescriptorCollection GetListItemPropertiesByType(
      Type objType,
      PropertyDescriptor[] arrListAccessors)
    {
      return arrListAccessors == null || arrListAccessors.Length == 0 ? ListBindingHelper.GetListItemPropertiesByType(objType) : ListBindingHelper.GetListItemPropertiesByType(objType, arrListAccessors, 0);
    }

    private static PropertyDescriptorCollection GetListItemPropertiesByType(
      Type objType,
      PropertyDescriptor[] arrListAccessors,
      int intStartIndex)
    {
      Type propertyType = arrListAccessors[intStartIndex].PropertyType;
      ++intStartIndex;
      return intStartIndex >= arrListAccessors.Length ? ListBindingHelper.GetListItemProperties((object) propertyType) : ListBindingHelper.GetListItemPropertiesByType(propertyType, arrListAccessors, intStartIndex);
    }

    /// <summary>Returns the data type of the items in the specified list.</summary>
    /// <returns>The <see cref="T:System.Type"></see> of the items contained in the list.</returns>
    /// <param name="objList">The list to be examined for type information. </param>
    public static Type GetListItemType(object objList)
    {
      if (objList == null)
        return (Type) null;
      Type type = (object) (objList as Type) != null ? objList as Type : objList.GetType();
      object obj = (object) (objList as Type) != null ? (object) null : objList;
      if (typeof (Array).IsAssignableFrom(type))
        return type.GetElementType();
      PropertyInfo typedIndexer = ListBindingHelper.GetTypedIndexer(type);
      if (typedIndexer != (PropertyInfo) null)
        return typedIndexer.PropertyType;
      return obj is IEnumerable ? ListBindingHelper.GetListItemTypeByEnumerable(obj as IEnumerable) : type;
    }

    /// <summary>Returns the data type of the items in the specified data source.</summary>
    /// <returns>For complex data binding, the <see cref="T:System.Type"></see> of the items represented by the dataMember in the data source; otherwise, the <see cref="T:System.Type"></see> of the item in the list itself.</returns>
    /// <param name="objDataSource">The data source to examine for items. </param>
    /// <param name="strDataMember">The optional name of the property on the data source that is to be used as the data member. This can be null.</param>
    public static Type GetListItemType(object objDataSource, string strDataMember)
    {
      if (objDataSource != null)
      {
        if (CommonUtils.IsNullOrEmpty(strDataMember))
          return ListBindingHelper.GetListItemType(objDataSource);
        PropertyDescriptorCollection listItemProperties = ListBindingHelper.GetListItemProperties(objDataSource);
        if (listItemProperties == null)
          return typeof (object);
        PropertyDescriptor propertyDescriptor = listItemProperties.Find(strDataMember, true);
        if (propertyDescriptor != null && !(propertyDescriptor.PropertyType is ICustomTypeDescriptor))
          return ListBindingHelper.GetListItemType((object) propertyDescriptor.PropertyType);
      }
      return typeof (object);
    }

    private static Type GetListItemTypeByEnumerable(IEnumerable iEnumerable)
    {
      object itemByEnumerable = ListBindingHelper.GetFirstItemByEnumerable(iEnumerable);
      return itemByEnumerable == null ? typeof (object) : itemByEnumerable.GetType();
    }

    /// <summary>Returns the name of an underlying list, given a data source and optional <see cref="T:System.ComponentModel.PropertyDescriptor"></see> array.</summary>
    /// <returns>The name of the list in the data source, as described by listAccessors, orthe name of the data source type.</returns>
    /// <param name="objList">The data source to examine for the list name.</param>
    /// <param name="arrListAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the data source. This can be null.</param>
    public static string GetListName(object objList, PropertyDescriptor[] arrListAccessors)
    {
      if (objList == null)
        return string.Empty;
      if (objList is ITypedList typedList)
        return typedList.GetListName(arrListAccessors);
      Type objType;
      if (arrListAccessors == null || arrListAccessors.Length == 0)
      {
        Type type = objList as Type;
        objType = !(type != (Type) null) ? objList.GetType() : type;
      }
      else
        objType = arrListAccessors[0].PropertyType;
      return ListBindingHelper.GetListNameFromType(objType);
    }

    private static string GetListNameFromType(Type objType)
    {
      if (typeof (Array).IsAssignableFrom(objType))
        return objType.GetElementType().Name;
      if (!typeof (IList).IsAssignableFrom(objType))
        return objType.Name;
      PropertyInfo typedIndexer = ListBindingHelper.GetTypedIndexer(objType);
      return typedIndexer != (PropertyInfo) null ? typedIndexer.PropertyType.Name : objType.Name;
    }

    private static PropertyInfo GetTypedIndexer(Type objType)
    {
      if (!typeof (IList).IsAssignableFrom(objType) && !typeof (ITypedList).IsAssignableFrom(objType) && !typeof (IListSource).IsAssignableFrom(objType))
        return (PropertyInfo) null;
      PropertyInfo typedIndexer = (PropertyInfo) null;
      PropertyInfo[] properties = objType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
      for (int index = 0; index < properties.Length; ++index)
      {
        if (properties[index].GetIndexParameters().Length != 0 && properties[index].PropertyType != typeof (object))
        {
          typedIndexer = properties[index];
          if (typedIndexer.Name == "Item")
            return typedIndexer;
        }
      }
      return typedIndexer;
    }

    private static Attribute[] BrowsableAttributeList
    {
      get
      {
        if (ListBindingHelper.marrBrowsableAttribute == null)
          ListBindingHelper.marrBrowsableAttribute = new Attribute[1]
          {
            (Attribute) new BrowsableAttribute(true)
          };
        return ListBindingHelper.marrBrowsableAttribute;
      }
    }
  }
}
