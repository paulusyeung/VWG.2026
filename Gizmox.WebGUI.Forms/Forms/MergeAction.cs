// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MergeAction
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the kind of action to take if a match is found when combining menu items on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  public enum MergeAction
  {
    /// <summary>Appends the item to the end of the collection, ignoring match results.</summary>
    /// <filterpriority>1</filterpriority>
    Append,
    /// <summary>Inserts the item to the target's collection immediately preceding the matched item. A match of the end of the list results in the item being appended to the list. If there is no match or the match is at the beginning of the list, the item is inserted at the beginning of the collection.</summary>
    /// <filterpriority>1</filterpriority>
    Insert,
    /// <summary>Replaces the matched item with the source item. The original item's drop-down items do not become children of the incoming item.</summary>
    /// <filterpriority>1</filterpriority>
    Replace,
    /// <summary>Removes the matched item.</summary>
    /// <filterpriority>1</filterpriority>
    Remove,
    /// <summary>A match is required, but no action is taken. Use this for tree creation and successful access to nested layouts.</summary>
    /// <filterpriority>1</filterpriority>
    MatchOnly,
  }
}
