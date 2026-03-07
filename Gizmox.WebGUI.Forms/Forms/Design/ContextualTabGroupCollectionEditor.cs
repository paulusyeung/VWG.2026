// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class ContextualTabGroupCollectionEditor : CollectionEditor
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor" /> class.
    /// </summary>
    /// <param name="objType">The type of the collection for this editor to edit.</param>
    public ContextualTabGroupCollectionEditor(Type objType)
      : base(objType)
    {
    }

    /// <summary>
    /// Sets the specified array as the items of the collection.
    /// </summary>
    /// <param name="objEditValue">The collection to edit.</param>
    /// <param name="arrValues">An array of objects to set as the collection items.</param>
    /// <returns>
    /// The newly created collection object or, otherwise, the collection indicated by the editValue parameter.
    /// </returns>
    protected override object SetItems(object objEditValue, object[] arrValues)
    {
      if (objEditValue != null && objEditValue is ContextualTabGroupCollection)
      {
        ContextualTabGroupCollection tabGroupCollection = (ContextualTabGroupCollection) objEditValue;
        tabGroupCollection.ClearInternal();
        for (int index = 0; index < arrValues.Length; ++index)
        {
          if (arrValues[index] is ContextualTabGroup arrValue)
            tabGroupCollection.Add(arrValue);
        }
      }
      return objEditValue;
    }

    /// <summary>
    /// Creates a new form to display and edit the current collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.
    /// </returns>
    protected override CollectionEditor.CollectionForm CreateCollectionForm()
    {
      CollectionEditor.CollectionForm collectionForm = base.CreateCollectionForm();
      collectionForm.Closed += new EventHandler(this.objForm_Closed);
      return collectionForm;
    }

    /// <summary>Handles the Closed event of the objForm control.</summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objForm_Closed(object sender, EventArgs e)
    {
      if (!(sender is Form))
        return;
      ITypeDescriptorContext context = this.Context;
      if (context == null || !(context.Instance is TabControl instance))
        return;
      ContextualTabGroupCollection contextualTabGroups = instance.ContextualTabGroups;
      if (contextualTabGroups == null)
        return;
      foreach (TabPage tabPage in instance.TabPages)
      {
        ContextualTabGroup contextualTabGroup = tabPage.ContextualTabGroup;
        if (contextualTabGroup != null && !contextualTabGroups.Contains(contextualTabGroup))
          tabPage.ContextualTabGroup = (ContextualTabGroup) null;
      }
    }
  }
}
