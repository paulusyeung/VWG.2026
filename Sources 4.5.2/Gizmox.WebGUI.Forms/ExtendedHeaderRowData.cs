using System;
using System.Collections.Generic;

using System.Web;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public enum HeightMode
    {
        Default = 0,
        Custom
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExtendedHeaderRowDataTypeConverter))]
    public class ExtendedHeaderRowData : SerializableObject
    {
        private HeightMode menuHeightMode;
        private int mintHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedHeaderRowData"/> class.
        /// </summary>
        /// <param name="enuHeightSizeMode">The enu height size mode.</param>
        /// <param name="intHeight">Height of the int.</param>
        public ExtendedHeaderRowData(HeightMode enuHeightSizeMode, int intHeight)
        {
            menuHeightMode = enuHeightSizeMode;
            mintHeight = intHeight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedHeaderRowData"/> class.
        /// </summary>
        public ExtendedHeaderRowData()
        {
            menuHeightMode = HeightMode.Default;
            mintHeight = 0;
        }

        /// <summary>
        /// Height Size Mode.
        /// If Set to Default - get value from DataGridViewRow, If set to Custom - Use user defined value in local 'Height' property
        /// </summary>
        public HeightMode HeightSizeMode
        {
            get { return menuHeightMode; }
            set { menuHeightMode = value; }
        }

        /// <summary>
        /// Custom Height value for Row
        /// </summary>
        public int Height
        {
            get { return mintHeight; }
            set { mintHeight = value; }
        }

        /// <summary>
        /// Renders the row.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        internal void RenderRow(Gizmox.WebGUI.Common.Interfaces.IResponseWriter objWriter)
        {
            objWriter.WriteStartElement(WGTags.Row);
            objWriter.WriteAttributeString(Gizmox.WebGUI.WGAttributes.Height, ((HeightSizeMode == HeightMode.Custom) ? Height : GetDefaultRowHeight()).ToString());
            objWriter.WriteEndElement();
        }


        /// <summary>
        /// Gets the default height of the row.
        /// </summary>
        /// <returns></returns>
        private int GetDefaultRowHeight()
        {
            //Get value from client
            return DataGridViewRow.GetDefaultRowHeight();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "ExtendedHeaderRowData";
    }
    }
}