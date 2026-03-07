// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.SaveFileDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Hosting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>SaveFileDialog class.</summary>
  [SRDescription("DescriptionSaveFileDialog")]
  [ToolboxBitmap(typeof (SaveFileDialog), "SaveFileDialog_45.bmp")]
  [ToolboxItem(true)]
  [Serializable]
  public class SaveFileDialog : FileDialog
  {
    private SaveFileDialog.SaveFileDialogForm mobjSaveFileDialogForm;

    /// <summary>
    /// Gets or sets a value indicating whether [create prompt].
    /// </summary>
    /// <value><c>true</c> if [create prompt]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool CreatePrompt
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [overwrite prompt].
    /// </summary>
    /// <value><c>true</c> if [overwrite prompt]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OverwritePrompt
    {
      get => true;
      set
      {
      }
    }

    /// <summary>Opens a file.</summary>
    /// <returns></returns>
    public Stream OpenFile() => this.File != null ? this.File.InputStream : throw new ArgumentNullException();

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm()
    {
      FileHandle file = this.File;
      if (file != null)
      {
        if (this.mobjSaveFileDialogForm == null)
          this.mobjSaveFileDialogForm = new SaveFileDialog.SaveFileDialogForm((CommonDialog) this);
        Link.Download((ResourceHandle) new GatewayResourceHandle((IRegisteredComponent) this.mobjSaveFileDialogForm, "download"), file.FileName);
      }
      return (CommonDialog.CommonDialogForm) null;
    }

    /// <summary>Resets all properties to their default values.</summary>
    public override void Reset()
    {
      base.Reset();
      this.SetOption(2, true);
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    protected sealed class SaveFileDialogForm : CommonDialog.CommonDialogForm
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SaveFileDialog.SaveFileDialogForm" /> class.
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public SaveFileDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.RegisterSelf();
      }

      /// <summary>Provides a way to handle gateway requests.</summary>
      /// <param name="objHostContext">The gateway request HOST context.</param>
      /// <param name="strAction">The gateway request action.</param>
      /// <returns>
      /// By default this method returns a instance of a class which implements the IGatewayHandler and
      /// throws a non implemented HttpException.
      /// </returns>
      /// <remarks>
      /// This method is called from the implementation of IGatewayComponent which replaces the
      /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
      /// RegisteredComponent class which is the base class of most of the Visual WebGui
      /// components.
      /// Referencing a RegisterComponent that overrides this method is done the same way that
      /// a control implementing IGatewayControl, which is by using the GatewayReference class.
      /// </remarks>
      protected override IGatewayHandler ProcessGatewayRequest(
        HostContext objHostContext,
        string strAction)
      {
        if (!(strAction == "download"))
          return base.ProcessGatewayRequest(objHostContext, strAction);
        if (this.CommonDialogOwner is SaveFileDialog commonDialogOwner)
        {
          FileHandle file = commonDialogOwner.File;
          if (file != null)
          {
            objHostContext.Response.ContentType = file.ContentType;
            objHostContext.Response.WriteFile(file.FileName);
          }
        }
        return (IGatewayHandler) null;
      }
    }
  }
}
