// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.SessionNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using System;
using System.Collections;

namespace Gizmox.WebGUI.Virtualization.Management
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  internal class SessionNode : ServerExplorerNode
  {
    internal SessionNode()
    {
      this.Label = "Registery";
      this.Tag = (object) "Registery";
      this.Image = (ResourceHandle) new IconResourceHandle("file.gif");
    }

    protected override void LoadNodes()
    {
    }

    private void LoadControl()
    {
    }

    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 200, HorizontalAlignment.Left);
      objColumns.Add("Value", 300, HorizontalAlignment.Left);
    }

    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      foreach (DictionaryEntry dictionaryEntry in Global.Context.Session as ISessionRegistry)
      {
        if (dictionaryEntry.Value is IRegisteredComponent registeredComponent)
          objItems.Add(registeredComponent.ID.ToString()).SubItems.Add(registeredComponent.GetType().ToString());
      }
    }
  }
}
