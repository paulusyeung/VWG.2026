// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColorListBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for ColorListBox.</summary>
  [ToolboxItem(false)]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColorListBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ColorListBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxBitmap(typeof (ListBox), "Gizmox.WebGUI.Forms.ColorListBox.bmp")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ColorListBoxSkin))]
  [Obsolete("Use List box insted of Color list box")]
  [Serializable]
  public class ColorListBox : ListBox
  {
    /// <summary>Gets the items.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public new ListBox.ObjectCollection Items => base.Items;

    /// <summary>
    /// 
    /// </summary>
    protected override ListBox.ObjectCollection CreateItemCollection() => (ListBox.ObjectCollection) new ColorListBox.ObjectCollection(this);

    /// <summary>Should render color.</summary>
    /// <returns></returns>
    protected override bool ShouldRenderColor() => true;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public new class ObjectCollection : ListBox.ObjectCollection
    {
      private ColorListBox mobjParent;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColorListBox.ObjectCollection" /> instance.
      /// </summary>
      internal ObjectCollection(ColorListBox objParent)
        : base((ListBox) objParent)
      {
        this.mobjParent = objParent;
      }

      /// <summary>Adds the specified obj color.</summary>
      /// <param name="objColor">Color of the obj.</param>
      /// <returns></returns>
      public int Add(Color objColor) => this.Add((object) objColor);
    }
  }
}
