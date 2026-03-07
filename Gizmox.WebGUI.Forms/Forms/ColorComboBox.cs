// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ColorComboBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [ToolboxBitmap(typeof (ListBox), "Gizmox.WebGUI.Forms.ColorListBox.bmp")]
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ColorComboBoxSkin))]
  [Obsolete("Use Combo box insted of Color combo box")]
  [Serializable]
  public class ColorComboBox : ComboBox
  {
    /// <summary>Gets or sets the drop down style.</summary>
    /// <value></value>
    [DefaultValue(ComboBoxStyle.DropDownList)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ComboBoxStyle DropDownStyle
    {
      get => ComboBoxStyle.DropDownList;
      set
      {
        if (value != ComboBoxStyle.DropDownList)
          throw new ArgumentException("ColorComboBox.DropDropDownStyle can only be DropDownList", nameof (DropDownStyle));
      }
    }

    public override string GetItemText(object objItem) => objItem is Color color ? color.Name : "White";

    /// <summary>Gets the items.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [SRCategory("CatData")]
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    public new ComboBox.ObjectCollection Items => base.Items;

    /// <summary>
    /// 
    /// </summary>
    protected override ComboBox.ObjectCollection CreateItemCollection() => (ComboBox.ObjectCollection) new ColorComboBox.ObjectCollection(this);

    /// <summary>Should render color.</summary>
    /// <returns></returns>
    protected override bool ShouldRenderColor() => true;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public new class ObjectCollection : ComboBox.ObjectCollection
    {
      private ColorComboBox mobjParent;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColorComboBox.ObjectCollection" /> instance.
      /// </summary>
      internal ObjectCollection(ColorComboBox objParent)
        : base((ComboBox) objParent)
      {
        this.mobjParent = objParent;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objColor"></param>
      public int Add(Color objColor) => this.Add((object) objColor);
    }
  }
}
