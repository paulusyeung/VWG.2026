// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents.Database
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
  /// <summary>Represents client database.</summary>
  [Serializable]
  public class Database : IDatabase, IDatabaseOptions
  {
    private string mstrName;
    private string mstrVersion;
    private string mstrDisplayName;
    private double mdblSize;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Storage mobjStorage;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents.Database" /> class.
    /// </summary>
    /// <param name="objOptions">The database options.</param>
    /// <param name="objStorage">The storage.</param>
    public Database(DatabaseOptions objOptions, Gizmox.WebGUI.Forms.DeviceIntegration.Storage objStorage)
    {
      this.mstrName = objOptions.Name;
      this.mstrVersion = objOptions.Version;
      this.mstrDisplayName = objOptions.DisplayName;
      this.mdblSize = objOptions.Size;
      this.mobjStorage = objStorage;
    }

    /// <summary>Gets the storage.</summary>
    public Gizmox.WebGUI.Forms.DeviceIntegration.Storage Storage => this.mobjStorage;

    /// <summary>Gets the name of the database.</summary>
    /// <value>The name of the database.</value>
    public string Name
    {
      get => this.mstrName;
      private set => this.mstrName = value;
    }

    /// <summary>Gets the version of the database.</summary>
    /// <value>The version of the database.</value>
    public string Version
    {
      get => this.mstrVersion;
      private set => this.mstrVersion = value;
    }

    /// <summary>Gets the display name of the database.</summary>
    /// <value>The display name of the database.</value>
    public string DisplayName
    {
      get => this.mstrDisplayName;
      private set => this.mstrDisplayName = value;
    }

    /// <summary>Gets the size of the database in bytes.</summary>
    /// <value>The size of the database in bytes.</value>
    public double Size
    {
      get => this.mdblSize;
      private set => this.mdblSize = value;
    }

    /// <summary>
    /// Allows to atomically verify the version number and change it at the same time as doing a schema update (server).
    /// </summary>
    /// <param name="strNewVersion">The new version.</param>
    public void ChangeVersion(string strNewVersion) => this.mstrVersion = strNewVersion;

    /// <summary>Gets a database transaction.</summary>
    /// <param name="objCallback">Method called when transaction completes.</param>
    /// <returns></returns>
    public ISQLTransaction Transaction(EventHandler<TransactionEventArgs> objCallback)
    {
      SQLTransaction sqlTransaction = new SQLTransaction(this);
      this.mobjStorage.Invoke("DeviceIntegrator.Storage.transaction", new ArrayList()
      {
        (object) this.mobjStorage.TransactionCallbackMethods.StoreContextualSingleCallMethod((object) this, "transaction", objCallback),
        DatabaseOptions.GetClientArgument((IDatabaseOptions) this),
        (object) sqlTransaction.ID
      }.ToArray());
      return (ISQLTransaction) sqlTransaction;
    }
  }
}
