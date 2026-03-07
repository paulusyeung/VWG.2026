#region Using

using System;
using System.Globalization;
using Gizmox.WebGUI.Common;

#endregion

namespace Gizmox.WebGUI.Forms
{

    [Serializable()]
    internal sealed class StringSorter
    {

        #region Class Members
        
        public const int Descending = -2147483648;
        public const int IgnoreCase = 1;
        public const int IgnoreKanaType = 0x10000;
        public const int IgnoreNonSpace = 2;
        public const int IgnoreSymbols = 4;
        public const int IgnoreWidth = 0x20000;
        public const int StringSort = 0x1000;

        private const int CompareOptions = 0x31007;
        private bool mblnDescending;
        private object[] marrItems;
        private string[] marrKeys;
        private int mintLCID;
        private int mintOptions; 
        
        #endregion
        

        private StringSorter(CultureInfo objCulture, string[] arrKeys, object[] arrItem, int intOptions)
        {
            if (arrKeys == null)
            {
                if (arrItem is string[])
                {
                    arrKeys = (string[]) arrItem;
                    arrItem = null;
                }
                else
                {
                    arrKeys = new string[arrItem.Length];
                    for (int num1 = 0; num1 < arrItem.Length; num1++)
                    {
                        object obj1 = arrItem[num1];
                        if (obj1 != null)
                        {
                            arrKeys[num1] = obj1.ToString();
                        }
                    }
                }
            }
            this.marrKeys = arrKeys;
            this.marrItems = arrItem;
            this.mintLCID = (objCulture == null) ? (Global.Context != null && Global.Context.CurrentUICulture != null ? Global.Context.CurrentUICulture.LCID : CultureInfo.CurrentUICulture.LCID) : objCulture.LCID;
            this.mintOptions = intOptions & 0x31007;
            this.mblnDescending = (intOptions & -2147483648) != 0;
        }

        internal static int ArrayLength(object[] arrObjects)
        {
            if (arrObjects == null)
            {
                return 0;
            }
            return arrObjects.Length;
        }

        public static int Compare(string s1, string s2)
        {
            return StringSorter.Compare(Global.Context.CurrentUICulture, s1, s2, 0);
        }

        public static int Compare(string s1, string s2, int intOption)
        {
            return StringSorter.Compare(Global.Context.CurrentUICulture, s1, s2, intOption);
        }

        public static int Compare(CultureInfo objCulture, string s1, string s2, int intOption)
        {
            return StringSorter.Compare(objCulture.LCID, s1, s2, intOption);
        }

        private static int Compare(int intLcid, string s1, string s2, int intOption)
        {
            if (s1 == null)
            {
                if (s2 != null)
                {
                    return -1;
                }
                return 0;
            }
            if (s2 == null)
            {
                return 1;
            }
            return string.Compare(s1, s2, false, (Global.Context != null && Global.Context.CurrentUICulture != null ? Global.Context.CurrentUICulture : CultureInfo.CurrentUICulture));
        }

        private int CompareKeys(string s1, string s2)
        {
            int num1 = StringSorter.Compare(this.mintLCID, s1, s2, this.mintOptions);
            if (!this.mblnDescending)
            {
                return num1;
            }
            return -num1;
        }

        private void QuickSort(int intLeft, int intRight)
        {
            do
            {
                int num1 = intLeft;
                int num2 = intRight;
                string strText1 = this.marrKeys[(num1 + num2) >> 1];
                do
                {
                    while (this.CompareKeys(this.marrKeys[num1], strText1) < 0)
                    {
                        num1++;
                    }
                    while (this.CompareKeys(strText1, this.marrKeys[num2]) < 0)
                    {
                        num2--;
                    }
                    if (num1 > num2)
                    {
                        break;
                    }
                    if (num1 < num2)
                    {
                        string strText2 = this.marrKeys[num1];
                        this.marrKeys[num1] = this.marrKeys[num2];
                        this.marrKeys[num2] = strText2;
                        if (this.marrItems != null)
                        {
                            object obj1 = this.marrItems[num1];
                            this.marrItems[num1] = this.marrItems[num2];
                            this.marrItems[num2] = obj1;
                        }
                    }
                    num1++;
                    num2--;
                }
                while (num1 <= num2);
                if ((num2 - intLeft) <= (intRight - num1))
                {
                    if (intLeft < num2)
                    {
                        this.QuickSort(intLeft, num2);
                    }
                    intLeft = num1;
                }
                else
                {
                    if (num1 < intRight)
                    {
                        this.QuickSort(num1, intRight);
                    }
                    intRight = num2;
                }
            }
            while (intLeft < intRight);
        }

        public static void Sort(object[] arrItems)
        {
            StringSorter.Sort(null, null, arrItems, 0, StringSorter.ArrayLength(arrItems), 0);
        }

        public static void Sort(object[] arrItems, int intOption)
        {
            StringSorter.Sort(null, null, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);
        }

        public static void Sort(string[] arrKeys, object[] arrItems)
        {
            StringSorter.Sort(null, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), 0);
        }

        public static void Sort(CultureInfo objCulture, object[] arrItems, int intOption)
        {
            StringSorter.Sort(objCulture, null, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);
        }

        public static void Sort(object[] arrItems, int index, int intCount)
        {
            StringSorter.Sort(null, null, arrItems, index, intCount, 0);
        }

        public static void Sort(string[] arrKeys, object[] arrItems, int intOption)
        {
            StringSorter.Sort(null, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);
        }

        public static void Sort(object[] arrItems, int index, int intCount, int intOption)
        {
            StringSorter.Sort(null, null, arrItems, index, intCount, intOption);
        }

        public static void Sort(CultureInfo objCulture, string[] arrKeys, object[] arrItems, int intOption)
        {
            StringSorter.Sort(objCulture, arrKeys, arrItems, 0, StringSorter.ArrayLength(arrItems), intOption);
        }

        public static void Sort(string[] arrKeys, object[] arrItems, int index, int intCount)
        {
            StringSorter.Sort(null, arrKeys, arrItems, index, intCount, 0);
        }

        public static void Sort(CultureInfo objCulture, object[] arrItems, int index, int intCount, int intOption)
        {
            StringSorter.Sort(objCulture, null, arrItems, index, intCount, intOption);
        }

        public static void Sort(string[] arrKeys, object[] arrItems, int index, int intCount, int intOption)
        {
            StringSorter.Sort(null, arrKeys, arrItems, index, intCount, intOption);
        }

        public static void Sort(CultureInfo objCulture, string[] arrKeys, object[] arrItems, int index, int intCount, int intOption)
        {
            if ((arrItems == null) || ((arrKeys != null) && (arrKeys.Length != arrItems.Length)))
            {
                throw new ArgumentException(SR.GetString("ArraysNotSameSize", new object[] { "keys", "items" }));
            }
            if (intCount > 1)
            {
                new StringSorter(objCulture, arrKeys, arrItems, intOption).QuickSort(index, (index + intCount) - 1);
            }
        }



    }
}

