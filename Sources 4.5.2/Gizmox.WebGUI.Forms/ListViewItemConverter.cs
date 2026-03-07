#region Using

using System;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region ListViewItemConverter Class

    /// <summary>
    /// Provides a type converter to convert <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see> objects to and from various other representations.
    /// </summary>

    [Serializable()]
    public class ListViewItemConverter : ExpandableObjectConverter
    {
        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewItemConverter"/> class.
        /// </summary>
        public ListViewItemConverter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"></see> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"></see>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"></see> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"></see> to convert the value parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        /// <exception cref="T:System.ArgumentNullException">The objDestinationType parameter is null. </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }

            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is ListViewItem))
            {
                object objResult = ConvertToInstanceDescriptor(objContext, objValue);
                if (objResult != null)
                    return objResult;
            }

            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
        {
            ConstructorInfo objConstructorInfo;
            Type[] arrTypes;
            object[] arrObjects;
            ListViewItem objItem = (ListViewItem)objValue;
            //for (int num1 = 1; num1 < objItem.SubItems.Count; num1++)
            //{
            //    if (item1.SubItems[num1].CustomStyle)
            //    {
            //        typeArray1 = new Type[2] { typeof(ListViewItem.ListViewSubItem[]), typeof(int) };
            //        info1 = typeof(ListViewItem).GetConstructor(typeArray1);
            //        if (info1 == null)
            //        {
            //            break;
            //        }
            //        ListViewItem.ListViewSubItem[] itemArray1 = new ListViewItem.ListViewSubItem[item1.SubItems.Count];
            //        ((ICollection)item1.SubItems).CopyTo(itemArray1, 0);
            //        objArray1 = new object[2] { itemArray1, item1.ImageIndex };
            //        return new InstanceDescriptor(info1, objArray1, false);
            //    }
            //}
            string[] arrTextArray = new string[objItem.SubItems.Count];
            
            // Collect sub-items' text to the array
            for (int i = 0; i < arrTextArray.Length; i++)
            {
                arrTextArray[i] = objItem.SubItems[i].Text;
            }
            //				if (item1.SubItems[0].CustomStyle)
            //				{
            //					typeArray1 = new Type[5] { typeof(string[]), typeof(int), typeof(Color), typeof(Color), typeof(Font) } ;
            //					info1 = typeof(ListViewItem).GetConstructor(typeArray1);
            //					if (info1 != null)
            //					{
            //						objArray1 = new object[5] { textArray1, item1.ImageIndex, item1.SubItems[0].CustomForeColor ? item1.ForeColor : Color.Empty, item1.SubItems[0].CustomBackColor ? item1.BackColor : Color.Empty, item1.SubItems[0].CustomFont ? item1.Font : null } ;
            //						return new InstanceDescriptor(info1, objArray1, false);
            //					}
            //				}
            if ((objItem.ImageIndex == -1) && (objItem.SubItems.Count <= 1))
            {
                arrTypes = new Type[1] { typeof(string) };
                objConstructorInfo = typeof(ListViewItem).GetConstructor(arrTypes);
                if (objConstructorInfo != null)
                {
                    arrObjects = new object[1] { objItem.Text };
                    return new InstanceDescriptor(objConstructorInfo, arrObjects, false);
                }
            }
            if (objItem.SubItems.Count <= 1)
            {
                arrTypes = new Type[2] { typeof(string), typeof(int) };
                objConstructorInfo = typeof(ListViewItem).GetConstructor(arrTypes);
                if (objConstructorInfo != null)
                {
                    arrObjects = new object[2] { objItem.Text, objItem.ImageIndex };
                    return new InstanceDescriptor(objConstructorInfo, arrObjects, false);
                }
            }
            arrTypes = new Type[2] { typeof(string[]), typeof(int) };
            objConstructorInfo = typeof(ListViewItem).GetConstructor(arrTypes);
            if (objConstructorInfo != null)
            {
                arrObjects = new object[2] { arrTextArray, objItem.ImageIndex };
                return new InstanceDescriptor(objConstructorInfo, arrObjects, false);
            }

            return null;
        }

        #endregion Methods
    }

    #endregion ListViewItemConverter Class
}
