// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ClientUtils
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Security;
using System.Text;
using System.Threading;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for WebGUIUtils.</summary>
  [Serializable]
  internal sealed class ClientUtils
  {
    /// <summary>Returns the largest item from the array of comparable objects.</summary>
    /// <returns>The largest item from the array of comparable objects.</returns>
    /// <param name="arrArgs">array of comparable objects. </param>
    public static IComparable Max(params IComparable[] arrArgs) => ClientUtils.MaxOrMin(true, arrArgs);

    /// <summary>Returns the smallest item from the array of comparable objects.</summary>
    /// <returns>The smallest item from the array of comparable objects.</returns>
    /// <param name="arrArgs">array of comparable objects. </param>
    public static IComparable Min(params IComparable[] arrArgs) => ClientUtils.MaxOrMin(false, arrArgs);

    /// <summary>Returns the smallest or largest (depends on findMax) item from the array of comparable objects.</summary>
    /// <returns>The smallest or largest (depends on findMax) item from the array of comparable objects.</returns>
    /// <param name="blnFindMax">If true then finds the largest item, else find the smallest item</param>
    /// <param name="arrArgs">array of comparable objects. </param>
    private static IComparable MaxOrMin(bool blnFindMax, params IComparable[] arrArgs)
    {
      if (arrArgs.Length == 0 || arrArgs == null)
        throw new NullReferenceException("Null or empty array are invalid.");
      if (arrArgs.Length == 1)
        return arrArgs[0];
      IComparable arrArg = arrArgs[0];
      for (int index = 1; index < arrArgs.Length; ++index)
      {
        if (blnFindMax)
        {
          if (arrArgs[index].CompareTo((object) arrArg) > 0)
            arrArg = arrArgs[index];
        }
        else if (arrArgs[index].CompareTo((object) arrArg) < 0)
          arrArg = arrArgs[index];
      }
      return arrArg;
    }

    /// <summary>Determines whether two specified <see cref="T:System.String"></see> objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
    /// <returns>true if the value of the a parameter is equal to the value of the b parameter; otherwise, false.</returns>
    /// <param name="strA">A <see cref="T:System.String"></see> object or null. </param>
    /// <param name="enmComparisonType">One of the <see cref="T:System.StringComparison"></see> values. </param>
    /// <param name="strB">A <see cref="T:System.String"></see> object or null. </param>
    /// <exception cref="T:System.ArgumentException">comparisonType objIs not a <see cref="T:System.StringComparison"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    public static bool IsEquals(string strA, string strB, StringComparison enmComparisonType) => string.Equals(strA, strB, enmComparisonType);

    public static int GetCombinedHashCodes(params int[] arrIntArgs)
    {
      int combinedHashCodes = -757577119;
      for (int index = 0; index < arrIntArgs.Length; ++index)
        combinedHashCodes = (arrIntArgs[index] ^ combinedHashCodes) * -1640531535;
      return combinedHashCodes;
    }

    public static bool SafeCompareStrings(string string1, string string2, bool blnIgnoreCase) => string1 != null && string2 != null && string1.Length == string2.Length && string.Compare(string1, string2, blnIgnoreCase, CultureInfo.InvariantCulture) == 0;

    public static int RotateLeft(int intValue, int intNBits)
    {
      intNBits %= 32;
      return intValue << intNBits | intValue >> 32 - intNBits;
    }

    public static int GetBitCount(uint uintX)
    {
      int bitCount = 0;
      while (uintX > 0U)
      {
        int num = (int) uintX;
        uintX = (uint) (num & num - 1);
        ++bitCount;
      }
      return bitCount;
    }

    /// <summary>
    /// Determines whether the specified text contains mnemonic.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>
    /// 	<c>true</c> if the specified text contains mnemonic; otherwise, <c>false</c>.
    /// </returns>
    public static bool ContainsMnemonic(string strText)
    {
      if (strText != null)
      {
        int length = strText.Length;
        int num = strText.IndexOf('&', 0);
        if (num >= 0 && num <= length - 2 && strText.IndexOf('&', num + 1) == -1)
          return true;
      }
      return false;
    }

    public static bool IsEnumValid(
      Enum objEnumValue,
      int intValue,
      int intMinValue,
      int intMaxValue)
    {
      return intValue >= intMinValue && intValue <= intMaxValue;
    }

    public static bool IsEnumValid(
      Enum objEnumValue,
      int intValue,
      int intMinValue,
      int intMaxValue,
      int intMaxNumberOfBitsOn)
    {
      return intValue >= intMinValue && intValue <= intMaxValue && ClientUtils.GetBitCount((uint) intValue) <= intMaxNumberOfBitsOn;
    }

    public static bool IsEnumValid_Masked(Enum objEnumValue, int intValue, uint uintMask) => ((long) intValue & (long) uintMask) == (long) intValue;

    public static bool IsEnumValid_NotSequential(
      Enum objEnumValue,
      int intValue,
      params int[] arrEnumValues)
    {
      for (int index = 0; index < arrEnumValues.Length; ++index)
      {
        if (arrEnumValues[index] == intValue)
          return true;
      }
      return false;
    }

    public static bool IsSecurityOrCriticalException(Exception objException) => objException is SecurityException || ClientUtils.IsCriticalException(objException);

    public static bool IsCriticalException(Exception objException)
    {
      switch (objException)
      {
        case NullReferenceException _:
        case StackOverflowException _:
        case OutOfMemoryException _:
        case ThreadAbortException _:
        case ExecutionEngineException _:
        case IndexOutOfRangeException _:
          return true;
        default:
          return objException is AccessViolationException;
      }
    }

    public static object FormatObject(
      object objValue,
      Type objTargetType,
      TypeConverter objSourceConverter,
      TypeConverter objTargetConverter,
      string strFormatString,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue,
      object objDataSourceNullValue)
    {
      return Formatter.FormatObject(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
    }

    public static object ParseObject(
      object objValue,
      Type objTargetType,
      Type objSourceType,
      TypeConverter objTargetConverter,
      TypeConverter objSourceConverter,
      IFormatProvider objFormatInfo,
      object objFormattedNullValue,
      object objDataSourceNullValue)
    {
      return Formatter.ParseObject(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
    }

    public static object GetDefaultDataSourceNullValue(Type objType) => Formatter.GetDefaultDataSourceNullValue(objType);

    /// <summary>Returns a web color</summary>
    /// <param name="objColor"></param>
    /// <returns></returns>
    public static string GetWebColor(Color objColor)
    {
      byte num = objColor.R;
      string str1 = num.ToString("X2", (IFormatProvider) null);
      num = objColor.G;
      string str2 = num.ToString("X2", (IFormatProvider) null);
      num = objColor.B;
      string str3 = num.ToString("X2", (IFormatProvider) null);
      return "#" + str1 + str2 + str3;
    }

    /// <summary>Returns a web color string from an integer array</summary>
    /// <param name="arrColors"></param>
    /// <returns></returns>
    public static string GetWebColor(int[] arrColors)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (int arrColor in arrColors)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.Append(",");
        stringBuilder.Append(ClientUtils.GetWebColor(Color.FromArgb(arrColor)));
      }
      return stringBuilder.ToString();
    }

    public static string GetWebFont(Font objFont)
    {
      string webFont = "";
      if (objFont != null)
      {
        string str1 = (!objFont.Italic ? webFont + "normal " : webFont + "italic ") + "normal ";
        string str2 = !objFont.Bold ? str1 + "normal " : str1 + "bold ";
        switch (objFont.Unit)
        {
          case GraphicsUnit.Pixel:
            str2 = str2 + objFont.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "px ";
            break;
          case GraphicsUnit.Point:
            str2 = str2 + objFont.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "pt ";
            break;
          case GraphicsUnit.Inch:
            str2 = str2 + objFont.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "in ";
            break;
          case GraphicsUnit.Millimeter:
            str2 = str2 + objFont.Size.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "mm ";
            break;
        }
        string str3 = str2 + objFont.FontFamily.Name + " ";
        if (objFont.Underline)
        {
          webFont = str3 + ";text-decoration:underline";
          if (objFont.Strikeout)
            webFont += " line-through";
        }
        else
          webFont = !objFont.Strikeout ? str3 + ";text-decoration:none" : str3 + ";text-decoration:line-through";
      }
      return webFont;
    }

    /// <summary>Get the VWG router type</summary>
    private static Type RouterType => Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.25701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");

    /// <summary>Get a VWG router instance</summary>
    /// <returns></returns>
    internal static IRouter GetRouter()
    {
      Type routerType = ClientUtils.RouterType;
      return routerType != (Type) null ? Activator.CreateInstance(routerType) as IRouter : (IRouter) null;
    }

    [Serializable]
    public class ReadOnlyControlCollection : Control.ControlCollection
    {
      private readonly bool mblnIsReadOnly;

      public ReadOnlyControlCollection(Control objOwner, bool blnIsReadOnly)
        : base(objOwner)
      {
        this.mblnIsReadOnly = blnIsReadOnly;
      }

      public override void Add(Control objControl)
      {
        if (this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        this.AddInternal(objControl);
      }

      internal virtual void AddInternal(Control objControl) => base.Add(objControl);

      public override void Clear()
      {
        if (this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        base.Clear();
      }

      public override void RemoveByKey(string strKey)
      {
        if (this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        base.RemoveByKey(strKey);
      }

      internal virtual void RemoveInternal(Control objControl) => this.Remove(objControl);

      public override bool IsReadOnly => this.mblnIsReadOnly;
    }

    [Serializable]
    public class TypedControlCollection : ClientUtils.ReadOnlyControlCollection
    {
      private Control mobjOwnerControl;
      private Type mobjTypeOfControl;

      public TypedControlCollection(Control objOwner, Type objTypeOfControl)
        : base(objOwner, false)
      {
        this.mobjTypeOfControl = objTypeOfControl;
        this.mobjOwnerControl = objOwner;
      }

      public TypedControlCollection(Control objOwner, Type objTypeOfControl, bool blnIsReadOnly)
        : base(objOwner, blnIsReadOnly)
      {
        this.mobjTypeOfControl = objTypeOfControl;
        this.mobjOwnerControl = objOwner;
      }

      public override void Add(Control objControl)
      {
        Control.CheckParentingCycle(this.mobjOwnerControl, objControl);
        if (objControl == null)
          throw new ArgumentNullException("value");
        if (this.IsReadOnly)
          throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
        if (!this.mobjTypeOfControl.IsAssignableFrom(objControl.GetType()))
          throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfType", (object) this.mobjTypeOfControl.Name)), objControl.GetType().Name);
        base.Add(objControl);
      }
    }
  }
}
