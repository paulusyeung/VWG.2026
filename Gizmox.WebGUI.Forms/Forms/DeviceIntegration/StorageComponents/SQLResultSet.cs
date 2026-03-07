// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents.SQLResultSet
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents
{
  /// <summary>Represents client Storage result set.</summary>
  [Serializable]
  public class SQLResultSet : DevicePropertyDictionary, ISQLResultSet
  {
    /// <summary>
    /// Gets the row ID of the row that the SQL statement inserted into the database.
    /// </summary>
    public uint? InsertID
    {
      get => this.GetNullableValueTypeProperty<uint>("insertId");
      internal set => this.AddNullableValueTypeProperty<uint>("insertId", value);
    }

    /// <summary>
    /// Gets the number of rows affected by the latest INSERT query (if INSERT performed).
    /// </summary>
    public uint? RowsAffected
    {
      get => this.GetNullableValueTypeProperty<uint>("rowsAffected");
      internal set => this.AddNullableValueTypeProperty<uint>("rowsAffected", value);
    }

    /// <summary>Gets the rows returned by query.</summary>
    public IEnumerable<Dictionary<string, string>> Rows
    {
      get => this.GetNullableProperty<IEnumerable<Dictionary<string, string>>>("rows");
      internal set => this.SetNullableProperty<IEnumerable<Dictionary<string, string>>>("rows", value);
    }
  }
}
