// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TreeViewVisualTemplate
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [VisualTemplate(typeof (TreeView), "Visually adjusts the TreeView control to an appearance more suitable for the customized device.")]
  [Skin(typeof (TreeViewVisualTemplateSkin))]
  [Serializable]
  public class TreeViewVisualTemplate : VisualTemplate
  {
    private bool mblnUseTreeViewOriginalFont;
    private int mintItemHeight;
    private int mintBackButtonHeight;
    private int? mintCalculatedItemHeight;
    private string mstrDefaultBackButtonText = "Back";

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewVisualTemplate" /> class.
    /// </summary>
    public TreeViewVisualTemplate()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewVisualTemplate" /> class.
    /// </summary>
    /// <param name="blnUseTreeViewOriginalFont">if set to <c>true</c> [BLN use TreeView original font].</param>
    public TreeViewVisualTemplate(
      bool blnUseTreeViewOriginalFont,
      int intItemHeight,
      int intBackButtonHeight,
      string strDefaultBackButtonText)
    {
      this.mblnUseTreeViewOriginalFont = blnUseTreeViewOriginalFont;
      this.mintItemHeight = intItemHeight;
      this.mintBackButtonHeight = intBackButtonHeight;
      this.mstrDefaultBackButtonText = strDefaultBackButtonText;
    }

    /// <summary>Renders the specified object context.</summary>
    /// <param name="objContext">The object context.</param>
    /// <param name="objWriter">The object writer.</param>
    public override void Render(IContext objContext, IAttributeWriter objWriter)
    {
      base.Render(objContext, objWriter);
      objWriter.WriteAttributeString("VIS_OF", this.mblnUseTreeViewOriginalFont ? "1" : "0");
      if (this.mintItemHeight > 0)
        objWriter.WriteAttributeString("VIS_TV_IH", this.mintItemHeight);
      else
        objWriter.WriteAttributeString("VIS_TV_IH", this.GetCalculatedNodeHeight());
      if (this.mintBackButtonHeight > 0)
        objWriter.WriteAttributeString("VIS_TV_BBH", this.mintBackButtonHeight);
      else
        objWriter.WriteAttributeString("VIS_TV_BBH", this.GetCalculatedNodeHeight());
      objWriter.WriteAttributeString("VIS_TV_BBT", string.IsNullOrEmpty(this.mstrDefaultBackButtonText) ? "" : this.mstrDefaultBackButtonText);
    }

    /// <summary>Gets the name of the visual template.</summary>
    /// <value>The name of the visual template.</value>
    public override string VisualTemplateName => "TreeViewVisualTemplateWithPaging";

    /// <summary>Gets the visualizer image.</summary>
    /// <value>The visualizer image.</value>
    public override ResourceHandle VisualizerImage => (ResourceHandle) new SkinResourceHandle(typeof (TreeViewVisualTemplateSkin), "TreeViewVisualTemplate_Paging.png");

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => "Paged TreeView";

    /// <summary>
    /// Gets or sets a value indicating whether [use TreeView font].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [use TreeView font]; otherwise, <c>false</c>.
    /// </value>
    [DisplayName("Use Original Font")]
    [Description("This will set the font of the treeview as the original font, avoiding the visualtemplate style.")]
    public bool UseTreeViewOriginalFont
    {
      get => this.mblnUseTreeViewOriginalFont;
      set => this.mblnUseTreeViewOriginalFont = value;
    }

    /// <summary>Gets or sets the height of the item.</summary>
    /// <value>The height of the item.</value>
    public int ItemHeight
    {
      get => this.mintItemHeight;
      set => this.mintItemHeight = value;
    }

    /// <summary>Gets or sets the height of the back button.</summary>
    /// <value>The height of the back button.</value>
    public int BackButtonHeight
    {
      get => this.mintBackButtonHeight;
      set => this.mintBackButtonHeight = value;
    }

    /// <summary>Gets or sets the default back button text.</summary>
    /// <value>The default back button text.</value>
    public string DefaultBackButtonText
    {
      get => this.mstrDefaultBackButtonText;
      set => this.mstrDefaultBackButtonText = value;
    }

    /// <summary>Gets the calculated height of the node.</summary>
    /// <returns></returns>
    private int GetCalculatedNodeHeight()
    {
      if (!this.mintCalculatedItemHeight.HasValue)
      {
        TreeViewVisualTemplateSkin skin = SkinFactory.GetSkin((ISkinable) this) as TreeViewVisualTemplateSkin;
        TreeViewVisualTemplateSkin visualTemplateSkin = skin;
        int imageHeight = visualTemplateSkin.GetImageHeight(visualTemplateSkin.TreeViewVisualTemplateNextLTR, 0);
        int val2 = 0;
        int num = 4;
        if (skin.TreeNodeNormalStyle.Font != null)
        {
          Graphics graphics = Graphics.FromImage((Image) new Bitmap(1, 1));
          val2 = (int) Math.Ceiling((double) skin.TreeNodeNormalStyle.Font.GetHeight(graphics)) + num;
        }
        this.mintCalculatedItemHeight = new int?(Math.Max(Math.Max(imageHeight, val2), skin.TreeViewNodeHeight));
      }
      return this.mintCalculatedItemHeight.Value;
    }

    /// <summary>Converts to string.</summary>
    /// <returns></returns>
    internal override string ConvertToString()
    {
      string str = this.mblnUseTreeViewOriginalFont ? "1" : "0";
      return string.Format("{0}|{1}|{2}|{3}|{4}", (object) base.ConvertToString(), (object) str, (object) this.mintItemHeight, (object) this.mintBackButtonHeight, (object) this.mstrDefaultBackButtonText);
    }

    /// <summary>Converts from string.</summary>
    /// <param name="objVisualTemplateValues">The object visual template values.</param>
    internal override void ConvertFromString(List<string> objVisualTemplateValues)
    {
      if (objVisualTemplateValues.Count != 4)
        return;
      this.mblnUseTreeViewOriginalFont = !string.IsNullOrEmpty(objVisualTemplateValues[0]) && objVisualTemplateValues[0] == "1";
      int.TryParse(objVisualTemplateValues[1], out this.mintItemHeight);
      int.TryParse(objVisualTemplateValues[2], out this.mintBackButtonHeight);
      this.mstrDefaultBackButtonText = objVisualTemplateValues[3];
    }

    /// <summary>Gets the constroctor arguments. (For TypeContevert)</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object[] GetConsturctorArguments() => new object[4]
    {
      (object) this.mblnUseTreeViewOriginalFont,
      (object) this.mintItemHeight,
      (object) this.mintBackButtonHeight,
      (object) this.mstrDefaultBackButtonText
    };

    /// <summary>Gets the constroctor types. (For TypeContevert)</summary>
    public override Type[] GetConstructorTypes() => new Type[4]
    {
      typeof (bool),
      typeof (int),
      typeof (int),
      typeof (string)
    };
  }
}
