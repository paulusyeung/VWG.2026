#region Using

using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// 
    /// </summary>
    public enum TableLayoutPanelCellBorderStyle
    {
        /// <summary>
        /// No borders.
        /// </summary>
        None,
        /// <summary>
        /// A single-line border.
        /// </summary>
        Single,
        /// <summary>
        /// A single-line sunken border.
        /// </summary>
        Inset,
        /// <summary>
        /// A double-line sunken border.
        /// </summary>
        InsetDouble,
        /// <summary>
        /// A single-line raised border.
        /// </summary>
        Outset,
        /// <summary>
        /// A double-line raised border.
        /// </summary>
        OutsetDouble,
        /// <summary>
        /// A single-line border containing a raised portion.
        /// </summary>
        OutsetPartial
    }

    #endregion

    #region TableLayoutCellPaintEventArgs Class

    /// <summary>
    /// Provides data for the CellPaint event.
    /// </summary>
    [Serializable()]
    public class TableLayoutCellPaintEventArgs : PaintEventArgs
    {
        #region Class Members

        private Rectangle mobjBoundsRect;
        private int mintColumn;
        private int mintRow;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutCellPaintEventArgs"/> class.
        /// </summary>
        /// <param name="objGraphics">The g.</param>
        /// <param name="objClipRectangle">The clip rectangle.</param>
        /// <param name="objCellBounds">The cell bounds.</param>
        /// <param name="intColumn">The column.</param>
        /// <param name="intRow">The row.</param>
        public TableLayoutCellPaintEventArgs(Graphics objGraphics, Rectangle objClipRectangle, Rectangle objCellBounds, int intColumn, int intRow)
            : base(objGraphics, objClipRectangle)
        {
            this.mobjBoundsRect = objCellBounds;
            this.mintRow = intRow;
            this.mintColumn = intColumn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the size and location of the cell.
        /// </summary>
        /// <value>The cell bounds.</value>
        public Rectangle CellBounds
        {
            get
            {
                return this.mobjBoundsRect;
            }
        }

        /// <summary>
        /// GGets the column of the cell.
        /// </summary>
        /// <value>The column.</value>
        public int Column
        {
            get
            {
                return this.mintColumn;
            }
        }

        /// <summary>
        /// Gets the row of the cell.
        /// </summary>
        /// <value>The row.</value>
        public int Row
        {
            get
            {
                return this.mintRow;
            }
        }

        #endregion
    }

    #endregion

    #region TableLayoutPanelCellPosition Structure

    /// <summary>
    /// Represents a cell in a TableLayoutPanel.
    /// </summary>
    [StructLayout(LayoutKind.Sequential), TypeConverter(typeof(TableLayoutPanelCellPositionTypeConverter)), Serializable()]

    public struct TableLayoutPanelCellPosition
    {
        private int mintRow;
        private int mintColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutPanelCellPosition"/> struct.
        /// </summary>
        /// <param name="intColumn">The column.</param>
        /// <param name="intRow">The row.</param>
        public TableLayoutPanelCellPosition(int intColumn, int intRow)
        {
            if (intRow < -1)
            {
                throw new ArgumentOutOfRangeException("row", SR.GetString("InvalidArgument", new object[] { "row", intRow.ToString(CultureInfo.CurrentCulture) }));
            }
            if (intColumn < -1)
            {
                throw new ArgumentOutOfRangeException("column", SR.GetString("InvalidArgument", new object[] { "column", intColumn.ToString(CultureInfo.CurrentCulture) }));
            }
            this.mintRow = intRow;
            this.mintColumn = intColumn;
        }

        /// <summary>
        /// Gets or sets the row number of the current TableLayoutPanelCellPosition.
        /// </summary>
        /// <value>The row.</value>
        public int Row
        {
            get
            {
                return this.mintRow;
            }
            set
            {
                this.mintRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the column number of the current TableLayoutPanelCellPosition.
        /// </summary>
        /// <value>The column.</value>
        public int Column
        {
            get
            {
                return this.mintColumn;
            }
            set
            {
                this.mintColumn = value;
            }
        }

        /// <summary>
        /// Specifies whether this TableLayoutPanelCellPosition contains the same row and column as the specified TableLayoutPanelCellPosition.
        /// </summary>
        /// <param name="objOther">The other.</param>
        /// <returns></returns>
        public override bool Equals(object objOther)
        {
            if (objOther is TableLayoutPanelCellPosition)
            {
                TableLayoutPanelCellPosition objPosition = (TableLayoutPanelCellPosition)objOther;
                if (objPosition.mintRow == this.mintRow)
                {
                    return (objPosition.mintColumn == this.mintColumn);
                }
            }
            return false;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="objPos1">The p1.</param>
        /// <param name="objPos2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(TableLayoutPanelCellPosition objPos1, TableLayoutPanelCellPosition objPos2)
        {
            if (objPos1.Row == objPos2.Row)
            {
                return (objPos1.Column == objPos2.Column);
            }
            return false;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="objPos1">The p1.</param>
        /// <param name="objPos2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(TableLayoutPanelCellPosition objPos1, TableLayoutPanelCellPosition objPos2)
        {
            return (objPos1 != objPos2);
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return (this.Column.ToString(CultureInfo.CurrentCulture) + "," + this.Row.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return CommonUtils.GetCombinedHashCodes(new int[] { this.mintRow, this.mintColumn });
        }
    }

    #endregion

    #region TableLayoutPanelCellPositionTypeConverter Class

    [Serializable()]
    public class TableLayoutPanelCellPositionTypeConverter : TypeConverter
    {
        #region Methods

        #region Public Methods

        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            return ((objSourceType == typeof(string)) || base.CanConvertFrom(objContext, objSourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            return ((objDestinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(objContext, objDestinationType));
        }

        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (!(objValue is string))
            {
                return base.ConvertFrom(objContext, objCulture, objValue);
            }
            string str = ((string)objValue).Trim();
            if (str.Length == 0)
            {
                return null;
            }
            if (objCulture == null)
            {
                objCulture = CultureInfo.CurrentCulture;
            }
            char ch = objCulture.TextInfo.ListSeparator[0];
            string[] arrStrArray = str.Split(new char[] { ch });
            int[] arrNumArray = new int[arrStrArray.Length];
            TypeConverter objConverter = TypeDescriptor.GetConverter(typeof(int));
            for (int i = 0; i < arrNumArray.Length; i++)
            {
                arrNumArray[i] = (int)objConverter.ConvertFromString(objContext, objCulture, arrStrArray[i]);
            }
            if (arrNumArray.Length != 2)
            {
                throw new ArgumentException(SR.GetString("TextParseFailedFormat", new object[] { str, "column, row" }));
            }
            return new TableLayoutPanelCellPosition(arrNumArray[0], arrNumArray[1]);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is TableLayoutPanelCellPosition))
            {
                return ConvertToInstanceDescriptor(objContext, objValue);
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
            TableLayoutPanelCellPosition objPosition = (TableLayoutPanelCellPosition)objValue;
            return new InstanceDescriptor(typeof(TableLayoutPanelCellPosition).GetConstructor(new Type[] { typeof(int), typeof(int) }), new object[] { objPosition.Column, objPosition.Row });
        }

        public object CreateInstance(ITypeDescriptorContext objContext, Hashtable objPropertyValues)
        {
            return new TableLayoutPanelCellPosition((int)objPropertyValues["Column"], (int)objPropertyValues["Row"]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            return TypeDescriptor.GetProperties(typeof(TableLayoutPanelCellPosition), arrAttributes).Sort(new string[] { "Column", "Row" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        #endregion

        #endregion
    }

    #endregion
}
