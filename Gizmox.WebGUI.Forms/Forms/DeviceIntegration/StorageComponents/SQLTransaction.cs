// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents.SQLTransaction
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents
{
  /// <summary>
  /// Allows the user to execute SQL statements against the Web SQL Database on device.
  /// </summary>
  [Serializable]
  public class SQLTransaction : ISQLTransaction
  {
    private Database mobjDatabase;
    private string mstrId;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents.SQLTransaction" /> class.
    /// </summary>
    /// <param name="objDatabase">The database.</param>
    internal SQLTransaction(Database objDatabase)
    {
      this.mobjDatabase = objDatabase;
      this.mstrId = "tx_" + (object) this.GetHashCode();
    }

    /// <summary>Gets the transaction ID.</summary>
    internal string ID => this.mstrId;

    /// <summary>Executes the SQL command (server callback).</summary>
    /// <param name="objMethod">The callback method.</param>
    /// <param name="strSQLCommand">The SQL command.</param>
    public void ExecuteSQL(EventHandler<SQLResultEventArgs> objMethod, string strSQLCommand) => this.mobjDatabase.Storage.Invoke("DeviceIntegrator.Storage.executeSQLByTransaction", new ArrayList()
    {
      (object) this.mobjDatabase.Storage.ExecuteSQLMethods.StoreContextualSingleCallMethod((object) this, "executeSQL", objMethod),
      (object) strSQLCommand,
      (object) this.mstrId
    }.ToArray());
  }
}
