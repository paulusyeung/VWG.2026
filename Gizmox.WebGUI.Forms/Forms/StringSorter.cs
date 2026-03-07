// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.StringSorter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using System;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal sealed class StringSorter
  {
    public const int Descending = -2147483648;
    public const int IgnoreCase = 1;
    public const int IgnoreKanaType = 65536;
    public const int IgnoreNonSpace = 2;
    public const int IgnoreSymbols = 4;
    public const int IgnoreWidth = 131072;
    public const int StringSort = 4096;
    private const int CompareOptions = 200711;
    private bool mblnDescending;
    private object[] marrItems;
    private string[] marrKeys;
    private int mintLCID;
    private int mintOptions;

    private StringSorter(
      CultureInfo objCulture,
      string[] arrKeys,
      object[] arrItem,
      int intOptions)
    {
      if (arrKeys == null)
      {
        if (arrItem is string[])
        {
          arrKeys = (string[]) arrItem;
          arrItem = (object[]) null;
        }
        else
        {
          arrKeys = new string[arrItem.Length];
          for (int index = 0; index < arrItem.Length; ++index)
          {
            object obj = arrItem[index];
            if (obj != null)
              arrKeys[index] = obj.ToString();
          }
        }
      }
      this.marrKeys = arrKeys;
      this.marrItems = arrItem;
      this.mintLCID = objCulture == null ? (Global.Context == null || Global.Context.CurrentUICulture == null ? CultureInfo.CurrentUICulture.LCID : Global.Context.CurrentUICulture.LCID) : objCulture.LCID;
      this.mintOptions = intOptions & 200711;
      this.mblnDescending = (intOptions & int.MinValue) != 0;
    }

    internal static int ArrayLength(object[] arrObjects) => arrObjects == null ? 0 : arrObjects.Length;

    public static int Compare(string s1, string s2) => StringSorter.Compare(Global.Context.CurrentUICulture, s1, s2, 0);

    public static int Compare(string s1, string s2, int intOption) => StringSorter.Compare(Global.Context.CurrentUICulture, s1, s2, intOption);

    public static int Compare(CultureInfo objCulture, string s1, string s2, int intOption) => StringSorter.Compare(objCulture.LCID, s1, s2, intOption);

    private static int Compare(int intLcid, string s1, string s2, int intOption) => s1 == null ? (s2 != null ? -1 : 0) : (s2 == null ? 1 : string.Compare(s1, s2, false, Global.Context == null || Global.Context.CurrentUICulture == null ? CultureInfo.CurrentUICulture : Global.Context.CurrentUICulture));

    private int CompareKeys(string s1, string s2)
    {
      int num = StringSorter.Compare(this.mintLCID, s1, s2, this.mintOptions);
      return !this.mblnDescending ? num : -num;
    }

    private void QuickSort(int intLeft, int intRight)
    {
      do
      {
        int intLeft1 = intLeft;
        int intRight1 = intRight;
        string marrKey1 = this.marrKeys[intLeft1 + intRight1 >> 1];
        do
        {
          while (this.CompareKeys(this.marrKeys[intLeft1], marrKey1) < 0)
            ++intLeft1;
          while (this.CompareKeys(marrKey1, this.marrKeys[intRight1]) < 0)
            --intRight1;
          if (intLeft1 <= intRight1)
          {
            if (intLeft1 < intRight1)
            {
              string marrKey2 = this.marrKeys[intLeft1];
              this.marrKeys[intLeft1] = this.marrKeys[intRight1];
              this.marrKeys[intRight1] = marrKey2;
              if (this.marrItems != null)
              {
                object marrItem = this.marrItems[intLeft1];
                this.marrItems[intLeft1] = this.marrItems[intRight1];
                this.marrItems[intRight1] = marrItem;
              }
            }
            ++intLeft1;
            --intRight1;
          }
          else
            break;
        }
        while (intLeft1 <= intRight1);
        if (intRight1 - intLeft <= intRight - intLeft1)
        {
          if (intLeft < intRight1)
            this.QuickSort(intLeft, intRight1);
          intLeft = intLeft1;
        }
        else
        {
          if (intLeft1 < intRight)
            this.QuickSort(intLeft1, intRight);
          intRight = intRight1;
        }
      }
      while (intLeft < intRight);
    }

    public static void Sort(object[] arrItems) => StringSorter.Sort((CultureInfo) null, (string[]) null, arrItems, 0, StringSorter.ArrayLength(arrItems), 0);

    public static void Sort(object[] arrItems, int intOption) => StringSorter.Sort((CultureInfo) null, (string[]) null, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);

    public static void Sort(string[] arrKeys, object[] arrItems) => StringSorter.Sort((CultureInfo) null, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), 0);

    public static void Sort(CultureInfo objCulture, object[] arrItems, int intOption) => StringSorter.Sort(objCulture, (string[]) null, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);

    public static void Sort(object[] arrItems, int index, int intCount) => StringSorter.Sort((CultureInfo) null, (string[]) null, arrItems, index, intCount, 0);

    public static void Sort(string[] arrKeys, object[] arrItems, int intOption) => StringSorter.Sort((CultureInfo) null, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);

    public static void Sort(object[] arrItems, int index, int intCount, int intOption) => StringSorter.Sort((CultureInfo) null, (string[]) null, arrItems, index, intCount, intOption);

    public static void Sort(
      CultureInfo objCulture,
      string[] arrKeys,
      object[] arrItems,
      int intOption)
    {
      StringSorter.Sort(objCulture, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);
    }

    public static void Sort(string[] arrKeys, object[] arrItems, int index, int intCount) => StringSorter.Sort((CultureInfo) null, arrKeys, arrItems, index, intCount, 0);

    public static void Sort(
      CultureInfo objCulture,
      object[] arrItems,
      int index,
      int intCount,
      int intOption)
    {
      StringSorter.Sort(objCulture, (string[]) null, arrItems, index, intCount, intOption);
    }

    public static void Sort(
      string[] arrKeys,
      object[] arrItems,
      int index,
      int intCount,
      int intOption)
    {
      StringSorter.Sort((CultureInfo) null, arrKeys, arrItems, index, intCount, intOption);
    }

    public static void Sort(
      CultureInfo objCulture,
      string[] arrKeys,
      object[] arrItems,
      int index,
      int intCount,
      int intOption)
    {
      if (arrItems == null || arrKeys != null && arrKeys.Length != arrItems.Length)
        throw new ArgumentException(SR.GetString("ArraysNotSameSize", (object) "keys", (object) "items"));
      if (intCount <= 1)
        return;
      StringSorter stringSorter = new StringSorter(objCulture, arrKeys, arrItems, intOption);
      int intLeft = index;
      int intRight = intLeft + intCount - 1;
      stringSorter.QuickSort(intLeft, intRight);
    }
  }
}
