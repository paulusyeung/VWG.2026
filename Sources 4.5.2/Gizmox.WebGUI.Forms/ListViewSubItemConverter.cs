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
	#region ListViewSubItemConverter Class
	
	/// <summary>
	/// Summary description for ListViewSubItemConverter.
	/// </summary>

    [Serializable()]
    public class ListViewSubItemConverter : ExpandableObjectConverter
	{
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		public ListViewSubItemConverter()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		#endregion C'Tor / D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
        /// <param name="objContext"></param>
		/// <param name="objDestinationType"></param>
		public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
		{
			if (objDestinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(objContext, objDestinationType);
		}
		
		/// <summary>
		///
		/// </summary>
        /// <param name="objContext"></param>
        /// <param name="objCulture"></param>
        /// <param name="objValue"></param>
		/// <param name="objDestinationType"></param>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
		{
			if (objDestinationType == null)
			{
				throw new ArgumentNullException("objDestinationType");
			}
			if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is ListViewItem.ListViewSubItem))
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
            ListViewItem.ListViewSubItem objSubItem = (ListViewItem.ListViewSubItem)objValue;
            //				if (item1.CustomStyle)
            //				{
            //					typeArray1 = new Type[5] { typeof(ListViewItem), typeof(string), typeof(Color), typeof(Color), typeof(Font) } ;
            //					info1 = typeof(ListViewItem.ListViewSubItem).GetConstructor(typeArray1);
            //					if (info1 != null)
            //					{
            //						objArray1 = new object[5];
            //						objArray1[1] = item1.Text;
            //						objArray1[2] = item1.ForeColor;
            //						objArray1[3] = item1.BackColor;
            //						objArray1[4] = item1.Font;
            //						return new InstanceDescriptor(info1, objArray1, true);
            //					}
            //				}
            arrTypes = new Type[2] { typeof(ListViewItem), typeof(string) };
            objConstructorInfo = typeof(ListViewItem.ListViewSubItem).GetConstructor(arrTypes);
            if (objConstructorInfo != null)
            {
                arrObjects = new object[2];
                arrObjects[1] = objSubItem.Text;
                return new InstanceDescriptor(objConstructorInfo, arrObjects, true);
            }
            return null;
        }

		#endregion Methods
	}
	
	#endregion ListViewSubItemConverter Class
}
