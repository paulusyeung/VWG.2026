#region Using

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection; 

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewCellConverter Class

    [Serializable()]
    public class DataGridViewCellConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }

            DataGridViewCell objCell = objValue as DataGridViewCell;
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objCell != null))
            {
                object objResult = ConvertToInstanceDescriptor(objContext, objCell);
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
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, DataGridViewCell objCell)
        {
            ConstructorInfo objConstructorInfo = objCell.GetType().GetConstructor(new Type[0]);
            if (objConstructorInfo != null)
            {
                return new InstanceDescriptor(objConstructorInfo, new object[0], false);
            }
            return null;
        }
    }

    #endregion

    #region DataGridViewColumnConverter Class

    [Serializable()]
    public class DataGridViewColumnConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }

            DataGridViewColumn objColumn = objValue as DataGridViewColumn;

            if ((objDestinationType == typeof(InstanceDescriptor)) && (objColumn != null))
            {
                object objResult = ConvertToInstanceDescriptor(objContext, objColumn);
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
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, DataGridViewColumn objColumn)
        {
            ConstructorInfo objConstructorInfo;
            if (objColumn.CellType != null)
            {
                objConstructorInfo = objColumn.GetType().GetConstructor(new Type[] { typeof(Type) });
                if (objConstructorInfo != null)
                {
                    return new InstanceDescriptor(objConstructorInfo, new object[] { objColumn.CellType }, false);
                }
            }
            objConstructorInfo = objColumn.GetType().GetConstructor(new Type[0]);
            if (objConstructorInfo != null)
            {
                return new InstanceDescriptor(objConstructorInfo, new object[0], false);
            }

            return null;
        }
    }

    #endregion

    #region DataGridViewCellStyleConverter Class

    /// <summary>Converts <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> objects to and from other data types.  </summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewCellStyleConverter : TypeConverter
    {
        /// <filterpriority>1</filterpriority>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        /// <filterpriority>1</filterpriority>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is DataGridViewCellStyle))
            {
                return ConvertToInstanceDescriptor(objValue);
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private object ConvertToInstanceDescriptor(object objValue)
        {
            ConstructorInfo objConstructorInfo = objValue.GetType().GetConstructor(new Type[0]);
            return new InstanceDescriptor(objConstructorInfo, new object[0], false);
        }
    }

    #endregion

    #region DataGridViewRowConverter Class

    [Serializable()]
    public class DataGridViewRowConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if (objDestinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(objContext, objDestinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            DataGridViewRow objRow = objValue as DataGridViewRow;
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objRow != null))
            {
                InstanceDescriptor objTarget = ConvertToInstanceDescriptor(objRow);
                if (objTarget != null)
                {
                    return objTarget;
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        /// <summary>
        /// Convert to InstanceDescriptor
        /// </summary>
        /// <remarks>
        /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
        /// </remarks>
        private InstanceDescriptor ConvertToInstanceDescriptor(DataGridViewRow objRow)
        {
            ConstructorInfo objConstructorInfo = objRow.GetType().GetConstructor(new Type[0]);
            if (objConstructorInfo != null)
            {
                return new InstanceDescriptor(objConstructorInfo, new object[0], false);
            }
            return null;
        }
    }

    #endregion
}