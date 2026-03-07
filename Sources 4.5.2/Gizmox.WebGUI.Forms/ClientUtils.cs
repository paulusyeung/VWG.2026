using System;
using System.Globalization;
using System.Threading;
using System.Security;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Summary description for WebGUIUtils.
    /// </summary>

    [Serializable()]
    internal sealed class ClientUtils
    {
        /// <summary>Returns the largest item from the array of comparable objects.</summary>
        /// <returns>The largest item from the array of comparable objects.</returns>
        /// <param name="arrArgs">array of comparable objects. </param>
        public static IComparable Max(params IComparable[] arrArgs)
        {
            return MaxOrMin(true, arrArgs);
        }

        /// <summary>Returns the smallest item from the array of comparable objects.</summary>
        /// <returns>The smallest item from the array of comparable objects.</returns>
        /// <param name="arrArgs">array of comparable objects. </param>
        public static IComparable Min(params IComparable[] arrArgs)
        {
            return MaxOrMin(false, arrArgs);
        }
        /// <summary>Returns the smallest or largest (depends on findMax) item from the array of comparable objects.</summary>
        /// <returns>The smallest or largest (depends on findMax) item from the array of comparable objects.</returns>
        /// <param name="blnFindMax">If true then finds the largest item, else find the smallest item</param>
        /// <param name="arrArgs">array of comparable objects. </param>
        private static IComparable MaxOrMin(Boolean blnFindMax, params IComparable[] arrArgs)
        {
            if (arrArgs.Length == 0 || arrArgs == null)
            {
                throw new NullReferenceException("Null or empty array are invalid.");
            }
            else if (arrArgs.Length == 1)
            {
                return arrArgs[0];
            }
            else
            {
                IComparable objMaxOrMax = arrArgs[0];
                for (int index = 1; index < arrArgs.Length; index++)
                {
                    if (blnFindMax)
                    {
                        if (arrArgs[index].CompareTo(objMaxOrMax) > 0)
                        {
                            objMaxOrMax = arrArgs[index];
                        }
                    }
                    else
                    {
                        if (arrArgs[index].CompareTo(objMaxOrMax) < 0)
                        {
                            objMaxOrMax = arrArgs[index];
                        }
                    }
                }
                return objMaxOrMax;
            }
        }

        [Serializable()]
        public class ReadOnlyControlCollection : Control.ControlCollection
        {
            public ReadOnlyControlCollection(Control objOwner, bool blnIsReadOnly)
                : base(objOwner)
            {
                this.mblnIsReadOnly = blnIsReadOnly;
            }

            public override void Add(Control objControl)
            {
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
                this.AddInternal(objControl);
            }

            internal virtual void AddInternal(Control objControl)
            {
                base.Add(objControl);
            }

            public override void Clear()
            {
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
                base.Clear();
            }

            public override void RemoveByKey(string strKey)
            {
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
                base.RemoveByKey(strKey);
            }

            internal virtual void RemoveInternal(Control objControl)
            {
                base.Remove(objControl);
            }

            public override bool IsReadOnly
            {
                get
                {
                    return this.mblnIsReadOnly;
                }
            }

            private readonly bool mblnIsReadOnly;
        }

        [Serializable()]
        public class TypedControlCollection : ReadOnlyControlCollection
        {
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
                {
                    throw new ArgumentNullException("value");
                }
                if (this.IsReadOnly)
                {
                    throw new NotSupportedException(SR.GetString("ReadonlyControlsCollection"));
                }
                if (!this.mobjTypeOfControl.IsAssignableFrom(objControl.GetType()))
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.GetString("TypedControlCollectionShouldBeOfType", new object[] { this.mobjTypeOfControl.Name }), new object[0]), objControl.GetType().Name);
                }
                base.Add(objControl);
            }


            private Control mobjOwnerControl;
            private Type mobjTypeOfControl;
        }

        /// <summary>Determines whether two specified <see cref="T:System.String"></see> objects have the same value. A parameter specifies the culture, case, and sort rules used in the comparison.</summary>
        /// <returns>true if the value of the a parameter is equal to the value of the b parameter; otherwise, false.</returns>
        /// <param name="strA">A <see cref="T:System.String"></see> object or null. </param>
        /// <param name="enmComparisonType">One of the <see cref="T:System.StringComparison"></see> values. </param>
        /// <param name="strB">A <see cref="T:System.String"></see> object or null. </param>
        /// <exception cref="T:System.ArgumentException">comparisonType objIs not a <see cref="T:System.StringComparison"></see> value. </exception>
        /// <filterpriority>1</filterpriority>
        public static bool IsEquals(string strA, string strB, StringComparison enmComparisonType)
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            return string.Equals(strA, strB, enmComparisonType);
#else
            if ((enmComparisonType < StringComparison.CurrentCulture) || (enmComparisonType > StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Comparison type not supported.");
            }
            if (strA != strB)
            {
                if ((strA != null) && (strB != null))
                {
                    switch (enmComparisonType)
                    {
                        case StringComparison.CurrentCulture:
                            return (CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None) == 0);

                        case StringComparison.CurrentCultureIgnoreCase:
                            return (CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase) == 0);

                        case StringComparison.InvariantCulture:
                            return (CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.None) == 0);

                        case StringComparison.InvariantCultureIgnoreCase:
                            return (CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase) == 0);

                        case StringComparison.Ordinal:
                            return strA == strB;

                        case StringComparison.OrdinalIgnoreCase:
                            if (strA.Length != strB.Length)
                            {
                                return false;
                            }
                            return strA.ToLower() == strB.ToLower();
                    }
                    throw new ArgumentException("Comparison type not supported.");
                }
                return false;
            }
            return true;
#endif
        }

        public static int GetCombinedHashCodes(params int[] arrIntArgs)
        {
            int intNum1 = -757577119;
            for (int intNum2 = 0; intNum2 < arrIntArgs.Length; intNum2++)
            {
                intNum1 = (arrIntArgs[intNum2] ^ intNum1) * -1640531535;
            }
            return intNum1;
        }

        public static bool SafeCompareStrings(string string1, string string2, bool blnIgnoreCase)
        {
            if ((string1 == null) || (string2 == null))
            {
                return false;
            }
            if (string1.Length != string2.Length)
            {
                return false;
            }
            return (string.Compare(string1, string2, blnIgnoreCase, CultureInfo.InvariantCulture) == 0);
        }

        public static int RotateLeft(int intValue, int intNBits)
        {
            intNBits = intNBits % 0x20;
            return ((intValue << (intNBits & 0x1f)) | (intValue >> ((0x20 - intNBits) & 0x1f)));
        }

        public static int GetBitCount(uint uintX)
        {
            int intNum = 0;
            while (uintX > 0)
            {
                uintX &= uintX - 1;
                intNum++;
            }
            return intNum;
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
                int intLength = strText.Length;
                int intIndex = strText.IndexOf('&', 0);

                if (((intIndex >= 0) && (intIndex <= (intLength - 2))) && (strText.IndexOf('&', intIndex + 1) == -1))
                {
                    return true;
                }
            }

            return false;
        }

        #region Enum Related Methods

        public static bool IsEnumValid(Enum objEnumValue, int intValue, int intMinValue, int intMaxValue)
        {
            return ((intValue >= intMinValue) && (intValue <= intMaxValue));
        }

        public static bool IsEnumValid(Enum objEnumValue, int intValue, int intMinValue, int intMaxValue, int intMaxNumberOfBitsOn)
        {
            return (((intValue >= intMinValue) && (intValue <= intMaxValue)) && (ClientUtils.GetBitCount((uint)intValue) <= intMaxNumberOfBitsOn));
        }

        public static bool IsEnumValid_Masked(Enum objEnumValue, int intValue, uint uintMask)
        {
            return ((intValue & uintMask) == intValue);
        }

        public static bool IsEnumValid_NotSequential(Enum objEnumValue, int intValue, params int[] arrEnumValues)
        {
            for (int num1 = 0; num1 < arrEnumValues.Length; num1++)
            {
                if (arrEnumValues[num1] == intValue)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Exception Related Methods

        public static bool IsSecurityOrCriticalException(Exception objException)
        {
            if (!(objException is SecurityException))
            {
                return ClientUtils.IsCriticalException(objException);
            }
            return true;
        }

        public static bool IsCriticalException(Exception objException)
        {
            if (((!(objException is NullReferenceException) && !(objException is StackOverflowException)) && (!(objException is OutOfMemoryException) && !(objException is ThreadAbortException))) && (!(objException is ExecutionEngineException) && !(objException is IndexOutOfRangeException)))
            {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                return (objException is AccessViolationException);
#else
                return false;
#endif

            }
            return true;
        }

        #endregion

        #region Formatter Access Methods

        public static object FormatObject(object objValue, Type objTargetType, TypeConverter objSourceConverter, TypeConverter objTargetConverter, string strFormatString, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
        {
            return Formatter.FormatObject(objValue, objTargetType, objSourceConverter, objTargetConverter, strFormatString, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
        }

        public static object ParseObject(object objValue, Type objTargetType, Type objSourceType, TypeConverter objTargetConverter, TypeConverter objSourceConverter, IFormatProvider objFormatInfo, object objFormattedNullValue, object objDataSourceNullValue)
        {
            return Formatter.ParseObject(objValue, objTargetType, objSourceType, objTargetConverter, objSourceConverter, objFormatInfo, objFormattedNullValue, objDataSourceNullValue);
        }

        public static object GetDefaultDataSourceNullValue(Type objType)
        {
            return Formatter.GetDefaultDataSourceNullValue(objType);
        }

        #endregion

        /// <summary>
        /// Returns a web color
        /// </summary>
        /// <param name="objColor"></param>
        /// <returns></returns>
        public static string GetWebColor(Color objColor)
        {
            return ("#" + objColor.R.ToString("X2", null) + objColor.G.ToString("X2", null) + objColor.B.ToString("X2", null));
        }

        /// <summary>
        /// Returns a web color string from an integer array
        /// </summary>
        /// <param name="arrColors"></param>
        /// <returns></returns>
        public static string GetWebColor(int[] arrColors)
        {
            StringBuilder objOutput = new StringBuilder();
            foreach (int intColor in arrColors)
            {
                if (objOutput.Length > 0) objOutput.Append(",");
                objOutput.Append(GetWebColor(Color.FromArgb(intColor)));
            }
            return objOutput.ToString();
        }

        public static string GetWebFont(Font objFont)
        {
            string strFont = "";

            // if given font is valid
            if (objFont != null)
            {
                if (objFont.Italic) strFont += "italic ";
                else strFont += "normal ";
                strFont += "normal ";
                if (objFont.Bold) strFont += "bold ";
                else strFont += "normal ";
                switch (objFont.Unit)
                {
                    case GraphicsUnit.Pixel:
                        strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "px ";
                        break;
                    case GraphicsUnit.Point:
                        strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "pt ";
                        break;
                    case GraphicsUnit.Inch:
                        strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "in ";
                        break;
                    case GraphicsUnit.Millimeter:
                        strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "mm ";
                        break;
                }

                strFont += objFont.FontFamily.Name + " ";

                if (objFont.Underline)
                {
                    strFont += ";text-decoration:underline";
                    if (objFont.Strikeout)
                    {
                        strFont += " line-through";
                    }
                }
                else if (objFont.Strikeout)
                {
                    strFont += ";text-decoration:line-through";
                }
                else
                {
                    strFont += ";text-decoration:none";
                }
            }
            return strFont;
        }

        /// <summary>
        /// Get the VWG router type
        /// </summary>
        private static Type RouterType
        {
            get
            {
                Type objRouterType = null;
#if WG_NET46
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.6.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET452
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.25701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET451
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.15701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET45
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.5.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET40
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=4.0.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET35
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=3.0.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#elif WG_NET2
                objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=2.0.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#else
				objRouterType = Type.GetType("Gizmox.WebGUI.Server.Router,Gizmox.WebGUI.Server,Version=1.0.5701.0,Culture=neutral,PublicKeyToken=3de6eb684226c24d");
#endif
                return objRouterType;
            }
        }

        /// <summary>
        /// Get a VWG router instance
        /// </summary>
        /// <returns></returns>
        internal static IRouter GetRouter()
        {
            Type objRouterType = RouterType;
            if (objRouterType != null)
            {
                return Activator.CreateInstance(objRouterType) as IRouter;
            }
            return null;
        }
    }
}
