#region Using

using System;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;

#endregion

namespace Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents
{
    /// <summary>
    /// Represents client Storage result set.
    /// </summary>
    [Serializable]
    public class SQLResultSet : DevicePropertyDictionary, ISQLResultSet
    {
        /// <summary>
        /// Gets the row ID of the row that the SQL statement inserted into the database.
        /// </summary>
        public uint? InsertID
        {
            get
            {
                return GetNullableValueTypeProperty<uint>("insertId");
            }
            internal set
            {
                AddNullableValueTypeProperty("insertId", value);
            }
        }

        /// <summary>
        /// Gets the number of rows affected by the latest INSERT query (if INSERT performed).
        /// </summary>
        public uint? RowsAffected
        {
            get
            {
                return GetNullableValueTypeProperty<uint>("rowsAffected");
            }
            internal set
            {
                AddNullableValueTypeProperty("rowsAffected", value);
            }
        }

        /// <summary>
        /// Gets the rows returned by query.
        /// </summary>
        public IEnumerable<Dictionary<string, string>> Rows
        {
            get
            {
                return GetNullableProperty<IEnumerable<Dictionary<string, string>>>("rows");
            }
            internal set
            {
                SetNullableProperty("rows", value);
            }
        }

    }
}
