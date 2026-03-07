// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.ServerExplorerTree
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Virtualization.Management
{
  [ToolboxItem(false)]
  [Serializable]
  internal class ServerExplorerTree : TreeView
  {
    private ListView mobjListView;

    internal ListView List
    {
      get => this.mobjListView;
      set => this.mobjListView = value;
    }
  }
}
