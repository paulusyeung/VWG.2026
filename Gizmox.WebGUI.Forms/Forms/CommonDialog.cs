// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CommonDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the base class used for displaying dialog boxes on the screen.</summary>
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItem(false)]
  [ToolboxItemCategory("Dialogs")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (CommonDialogSkin))]
  [Serializable]
  public abstract class CommonDialog : ComponentBase, ICommonDialog, ISkinable
  {
    /// <summary>Holds the user data</summary>
    private object mobjTag;
    /// <summary>
    /// 
    /// </summary>
    private string mstrTheme = string.Empty;
    /// <summary>The last dialog result</summary>
    private DialogResult menmDialogResult;
    /// <summary>The skin of the current control</summary>
    [NonSerialized]
    private CommonDialogSkin mobjSkin;

    /// <summary>Occurs when the user clicks the Help button on a common dialog box.</summary>
    [SRDescription("CommonDialogHelpRequested")]
    public event EventHandler HelpRequest;

    /// <summary>The form close event</summary>
    public event EventHandler Closed;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.HelpRequest"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that provides the event data. </param>
    protected virtual void OnHelpRequest(EventArgs e)
    {
      EventHandler helpRequest = this.HelpRequest;
      if (helpRequest == null)
        return;
      helpRequest((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.CommonDialog.Close"></see> event.</summary>
    /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.EventArgs"></see> that provides the event data. </param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnClosed(EventArgs e)
    {
      EventHandler closed = this.Closed;
      if (closed == null)
        return;
      closed((object) this, e);
    }

    /// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
    public abstract void Reset();

    /// <summary>Runs a common dialog box with a default owner.</summary>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    public DialogResult ShowDialog() => this.ShowDialog((Form) null, (EventHandler) null, true);

    /// <summary>Runs a common dialog box with a default owner.</summary>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>
    public DialogResult ShowDialog(bool blnShowModalMask) => this.ShowDialog((Form) null, (EventHandler) null, blnShowModalMask);

    /// <summary>Runs a common dialog box with a default owner.</summary>
    /// <param name="objEventHandler">Event handler for dialog closed event</param>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    public DialogResult ShowDialog(EventHandler objEventHandler) => this.ShowDialog((Form) null, objEventHandler, true);

    /// <summary>Runs a common dialog box with a default owner.</summary>
    /// <param name="objEventHandler">Event handler for dialog closed event</param>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>
    public DialogResult ShowDialog(EventHandler objEventHandler, bool blnShowModalMask) => this.ShowDialog((Form) null, objEventHandler, blnShowModalMask);

    /// <summary>Runs a common dialog box with the specified owner.</summary>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
    public DialogResult ShowDialog(Form objOwner) => this.ShowDialog(objOwner, (EventHandler) null, true);

    /// <summary>Runs a common dialog box with the specified owner.</summary>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
    /// <param name="blnShowModalMask">Determines whether a form has a modal mask when modal.</param>
    public DialogResult ShowDialog(Form objOwner, bool blnShowModalMask) => this.ShowDialog(objOwner, (EventHandler) null, blnShowModalMask);

    /// <summary>Runs a common dialog box with the specified owner.</summary>
    /// <returns><see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.</returns>
    /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box. </param>
    /// <param name="objEventHandler">Event handler for dialog closed event</param>
    public DialogResult ShowDialog(Form objOwner, EventHandler objEventHandler) => this.ShowDialog(objOwner, objEventHandler, true);

    /// <summary>Runs a common dialog box with the specified owner.</summary>
    /// <param name="objOwner">Any object that implements <see cref="T:Gizmox.WebGUI.Forms.IWin32Window"></see> that represents the top-level window that will own the modal dialog box.</param>
    /// <param name="objEventHandler">The obj event handler.</param>
    /// <param name="blnShowModalMask">if set to <c>true</c> [BLN show modal mask].</param>
    /// <returns>
    /// 	<see cref="F:Gizmox.WebGUI.Forms.DialogResult.OK"></see> if the user clicks OK in the dialog box; otherwise, <see cref="F:Gizmox.WebGUI.Forms.DialogResult.Cancel"></see>.
    /// </returns>
    public DialogResult ShowDialog(
      Form objOwner,
      EventHandler objEventHandler,
      bool blnShowModalMask)
    {
      DialogResult dialogResult = DialogResult.None;
      if (VWGContext.Current is IContextCommonDialogHandler current)
      {
        current.ShowDialog((ICommonDialog) this, (IForm) objOwner, new EventHandler(this.CommonDialogForm_Closed), objEventHandler);
      }
      else
      {
        CommonDialog.CommonDialogForm form = this.CreateForm();
        if (form != null)
        {
          if (objEventHandler != null)
            form.DirectHandler = objEventHandler;
          form.ModalMask = blnShowModalMask;
          form.Closed += new EventHandler(this.CommonDialogForm_Closed);
          dialogResult = objOwner == null ? form.ShowDialog() : form.ShowDialog(objOwner);
        }
      }
      return dialogResult;
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup(
      Form objOwnerForm,
      IRegisteredComponent objComponent,
      EventHandler objEventHandler,
      DialogAlignment enmAlignment,
      Point objPopupLocation)
    {
      DialogResult dialogResult = DialogResult.None;
      CommonDialog.CommonDialogForm form = this.CreateForm();
      if (form != null)
      {
        if (objEventHandler != null)
          form.DirectHandler = objEventHandler;
        form.Closed += new EventHandler(this.CommonDialogForm_Closed);
        if (objPopupLocation.IsEmpty)
        {
          dialogResult = form.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Below);
        }
        else
        {
          form.Location = objPopupLocation;
          form.StartPosition = FormStartPosition.Manual;
          dialogResult = form.ShowPopup(objOwnerForm, objComponent, DialogAlignment.Custom);
        }
      }
      return dialogResult;
    }

    /// <summary>Displays the form as a popup window.</summary>
    public DialogResult ShowPopup(
      Form objOwnerForm,
      IRegisteredComponentMember objComponentMember,
      EventHandler objEventHandler,
      DialogAlignment enmAlignment,
      Point objPopupLocation)
    {
      DialogResult dialogResult = DialogResult.None;
      CommonDialog.CommonDialogForm form = this.CreateForm();
      if (form != null)
      {
        if (objEventHandler != null)
          form.DirectHandler = objEventHandler;
        form.Closed += new EventHandler(this.CommonDialogForm_Closed);
        if (objPopupLocation.IsEmpty)
        {
          dialogResult = form.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Below);
        }
        else
        {
          form.Location = objPopupLocation;
          form.StartPosition = FormStartPosition.Manual;
          dialogResult = form.ShowPopup(objOwnerForm, objComponentMember, DialogAlignment.Custom);
        }
      }
      return dialogResult;
    }

    /// <summary>Handles the form close event</summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CommonDialogForm_Closed(object sender, EventArgs e)
    {
      ICommonDialogHandler commonDialogHandler = (ICommonDialogHandler) sender;
      if (commonDialogHandler == null)
        return;
      this.menmDialogResult = commonDialogHandler.DialogResult;
      this.OnClosed(EventArgs.Empty);
      if (commonDialogHandler.DirectHandler == null)
        return;
      commonDialogHandler.DirectHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected abstract CommonDialog.CommonDialogForm CreateForm();

    /// <summary>Returns the last dialog result</summary>
    public DialogResult DialogResult => this.menmDialogResult;

    /// <summary>Gets or sets an object that contains data about the control. </summary>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(null)]
    [TypeConverter(typeof (StringConverter))]
    [Bindable(true)]
    [Localizable(false)]
    [SRCategory("CatData")]
    [SRDescription("ControlTagDescr")]
    public object Tag
    {
      get => this.mobjTag;
      set => this.mobjTag = value;
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [WebEditor(typeof (WebThemeEditor), typeof (WebUITypeEditor))]
    [SRCategory("CatAppearance")]
    [SRDescription("ControlThemeDescr")]
    [DefaultValue("Inherit")]
    [ProxyBrowsable(true)]
    public string Theme
    {
      get => this.mstrTheme;
      set => this.mstrTheme = value;
    }

    /// <summary>Gets the skin of the current control.</summary>
    /// <value>The skin of the current control.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    protected CommonDialogSkin Skin
    {
      get
      {
        if (this.mobjSkin == null)
          this.mobjSkin = (CommonDialogSkin) SkinFactory.GetSkin((ISkinable) this);
        return this.mobjSkin;
      }
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    string ISkinable.Theme
    {
      get
      {
        IContext current = VWGContext.Current;
        return current != null ? current.CurrentTheme : "Default";
      }
    }

    /// <summary>Handles apply event</summary>
    /// <param name="e"></param>
    protected virtual void OnApply(EventArgs e)
    {
    }

    /// <summary>Execute the apply event</summary>
    void ICommonDialog.OnApply() => this.OnApply(EventArgs.Empty);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    protected class CommonDialogForm : Form, ICommonDialogHandler
    {
      /// <summary>Holds reference to the owner color dialog component</summary>
      private CommonDialog mobjCommonDialog;
      /// <summary>The dialog direct handler</summary>
      private EventHandler mobjDirectHandler;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public CommonDialogForm(CommonDialog objCommonDialog) => this.mobjCommonDialog = objCommonDialog;

      /// <summary>Gets the theme related to the skinable component.</summary>
      /// <value>The theme related to the skinable component.</value>
      public override string Theme
      {
        get => this.CommonDialogOwner != null ? this.CommonDialogOwner.Theme : base.Theme;
        set => base.Theme = value;
      }

      /// <summary>Gets the owner commong</summary>
      protected CommonDialog CommonDialogOwner => this.mobjCommonDialog;

      /// <summary>Gets or sets the direct handler</summary>
      internal EventHandler DirectHandler
      {
        get => this.mobjDirectHandler;
        set => this.mobjDirectHandler = value;
      }

      /// <summary>
      /// 
      /// </summary>
      EventHandler ICommonDialogHandler.DirectHandler => this.DirectHandler;

      /// <summary>
      /// 
      /// </summary>
      DialogResult ICommonDialogHandler.DialogResult => this.DialogResult;
    }

    internal delegate void EventRaisedHander(IEvent objEvent);

    [ToolboxItem(false)]
    [Serializable]
    internal class HtmlBoxHost : HtmlBox
    {
      private NameValueCollection mobjProperties;

      internal event CommonDialog.EventRaisedHander EventRaised;

      protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
      {
        base.RenderAttributes(objContext, objWriter);
        if (this.mobjProperties == null)
          return;
        foreach (string allKey in this.mobjProperties.AllKeys)
          objWriter.WriteAttributeString(allKey, this.mobjProperties[allKey]);
      }

      protected override void FireEvent(IEvent objEvent)
      {
        base.FireEvent(objEvent);
        if (this.EventRaised == null)
          return;
        this.EventRaised(objEvent);
      }

      public override string Url
      {
        get
        {
          string url = base.Url;
          if (url == null)
            return (string) null;
          return url.IndexOf("?") == -1 ? string.Format("{0}?id={1}", (object) url, (object) this.ID) : string.Format("{0}&id={1}", (object) url, (object) this.ID);
        }
        set => base.Url = value;
      }

      public string GetProperty(string strName) => this.mobjProperties == null ? (string) null : this.mobjProperties[strName];

      public void SetProperty(string strName, string strValue)
      {
        if (strValue == null && this.mobjProperties != null)
          this.mobjProperties.Remove(strValue);
        if (this.mobjProperties == null)
          this.mobjProperties = new NameValueCollection();
        this.mobjProperties[strName] = strValue;
      }

      internal void InvokeExecuter(params object[] arrParams) => this.InvokeMethodWithId("FrameControl_Execute", arrParams);
    }
  }
}
