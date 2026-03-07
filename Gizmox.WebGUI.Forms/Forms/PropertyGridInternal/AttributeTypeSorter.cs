// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.AttributeTypeSorter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class AttributeTypeSorter : IComparer
  {
    private static IDictionary mobjTypeIds;

    public int Compare(object obj1, object obj2)
    {
      Attribute objAttribute1 = obj1 as Attribute;
      Attribute objAttribute2 = obj2 as Attribute;
      if (objAttribute1 == null && objAttribute2 == null)
        return 0;
      if (objAttribute1 == null)
        return -1;
      return objAttribute2 == null ? 1 : string.Compare(AttributeTypeSorter.GetTypeIdString(objAttribute1), AttributeTypeSorter.GetTypeIdString(objAttribute2), false, CultureInfo.InvariantCulture);
    }

    private static string GetTypeIdString(Attribute objAttribute)
    {
      object typeId = objAttribute.TypeId;
      if (typeId == null)
        return "";
      string typeIdString;
      if (AttributeTypeSorter.mobjTypeIds == null)
      {
        AttributeTypeSorter.mobjTypeIds = (IDictionary) new Hashtable();
        typeIdString = (string) null;
      }
      else
        typeIdString = AttributeTypeSorter.mobjTypeIds[typeId] as string;
      if (typeIdString == null)
      {
        typeIdString = typeId.ToString();
        AttributeTypeSorter.mobjTypeIds[typeId] = (object) typeIdString;
      }
      return typeIdString;
    }
  }
}
