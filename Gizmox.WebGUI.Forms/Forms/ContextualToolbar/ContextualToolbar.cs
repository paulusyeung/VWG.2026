// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.ContextualToolbar
{
  /// <summary>Summary description for ContextualToolbar</summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ContextualToolbarSkin))]
  [Serializable]
  internal class ContextualToolbar : Form, IServiceProvider, IWebUIEditorService
  {
    private PropertyInfo mobjControlProperty;
    private Gizmox.WebGUI.Forms.Component mobjComponent;
    private Point mobjEditorDialogLocation = Point.Empty;
    private ContextualToolbarPropertyValueChangedEventHandler mobjCustomPropertyValueChangeEvent;
    private List<Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton> mobjListOfButtons = new List<Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton>();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar" /> class.
    /// </summary>
    public ContextualToolbar()
    {
      this.CustomStyle = nameof (ContextualToolbar);
      this.InitContextualToolbarButtons();
    }

    /// <summary>Initializes the base buttons buttons.</summary>
    protected virtual void InitContextualToolbarButtons()
    {
      ContextualToolbarSkin skin = this.Skin as ContextualToolbarSkin;
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("Font", skin.ContextualToolbarFont, "Change the font type and size."));
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("ForeColor", skin.ContextualToolbarForeColor, "Change the text color."));
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("BackColor", skin.ContextualToolbarBackColor, "Change the background color."));
      this.AddChild((object) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton("Dock", skin.ContextualToolbarDock, "Change the docking type."));
    }

    /// <summary>
    /// Gets or sets a value indicating whether [activate on pre render].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [activate on pre render]; otherwise, <c>false</c>.
    /// </value>
    protected override bool ActivateOnShow
    {
      get => false;
      set => base.ActivateOnShow = value;
    }

    /// <summary>Gets or sets the control property.</summary>
    /// <value>The control property.</value>
    private PropertyInfo ControlProperty
    {
      get => this.mobjControlProperty;
      set => this.mobjControlProperty = value;
    }

    /// <summary>Gets or sets the component.</summary>
    /// <value>The component.</value>
    private Gizmox.WebGUI.Forms.Component Component
    {
      get => this.mobjComponent;
      set => this.mobjComponent = value;
    }

    /// <summary>Gets or sets the editor dialog location.</summary>
    /// <value>The editor dialog location.</value>
    private Point EditorDialogLocation
    {
      get => this.mobjEditorDialogLocation;
      set => this.mobjEditorDialogLocation = value;
    }

    /// <summary>Gets or sets the custom property value change event.</summary>
    /// <value>The custom property value change event.</value>
    private ContextualToolbarPropertyValueChangedEventHandler CustomPropertyValueChangeEvent
    {
      get => this.mobjCustomPropertyValueChangeEvent;
      set => this.mobjCustomPropertyValueChangeEvent = value;
    }

    /// <summary>Renders the controls sub tree</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void RenderControls(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      foreach (Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton mobjListOfButton in this.mobjListOfButtons)
        mobjListOfButton.RenderControl(objContext, objWriter, lngRequestID);
    }

    /// <summary>catched the event fired.</summary>
    /// <param name="objEvent">event.</param>
    internal static void FireEvent(Gizmox.WebGUI.Forms.Component objComponent, IEvent objEvent) => Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.FireEvent(objComponent, objEvent, (ContextualToolbarPropertyValueChangedEventHandler) null);

    /// <summary>catched the event fired.</summary>
    /// <param name="objEvent">event.</param>
    internal static void FireEvent(
      Gizmox.WebGUI.Forms.Component objComponent,
      IEvent objEvent,
      ContextualToolbarPropertyValueChangedEventHandler objCustomPropertyValueChangedEvent)
    {
      string str1 = objEvent["ARG"];
      string str2 = objEvent["RPS"];
      if (string.IsNullOrEmpty(str1))
        return;
      PropertyInfo property = objComponent.GetType().GetProperty(str1, BindingFlags.Instance | BindingFlags.Public);
      object objValue = (object) null;
      if (objComponent is Control)
      {
        if (property != (PropertyInfo) null)
          objValue = property.GetValue((object) objComponent, (object[]) null);
      }
      else
      {
        ProxyComponent proxyComponent = objComponent as ProxyComponent;
        if (property == (PropertyInfo) null && proxyComponent != null)
        {
          proxyComponent.PropertyBag.TryGetValue(str1, out objValue);
          property = proxyComponent.SourceComponent.GetType().GetProperty(str1, BindingFlags.Instance | BindingFlags.Public);
          if (objValue == null)
            objValue = property.GetValue((object) proxyComponent.SourceComponent, (object[]) null);
        }
        else if (property != (PropertyInfo) null && proxyComponent != null)
          objValue = property.GetValue((object) proxyComponent, (object[]) null);
      }
      if (!(property != (PropertyInfo) null))
        return;
      WebUITypeEditor webUiTypeEditor = WebUITypeEditor.GetPropertyEditor(TypeDescriptor.GetProperties((object) objComponent)[property.Name], typeof (WebUITypeEditor)) ?? WebUITypeEditor.GetEditor(property.PropertyType);
      Point point = Point.Empty;
      if (!string.IsNullOrEmpty(str2))
      {
        string[] strArray = str2.Split(',');
        int result1;
        int result2;
        if (int.TryParse(strArray[0], out result1) && int.TryParse(strArray[1], out result2))
          point = new Point(result1, result2);
      }
      Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar objProvider = new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar();
      objProvider.ControlProperty = property;
      objProvider.Component = objComponent;
      objProvider.EditorDialogLocation = point;
      objProvider.CustomPropertyValueChangeEvent = objCustomPropertyValueChangedEvent;
      webUiTypeEditor.EditValue((ITypeDescriptorContext) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarContext(objComponent), (IServiceProvider) objProvider, objValue, new WebUITypeEditorHandler(objProvider.EditPropertyValue_Callback));
    }

    /// <summary>Shows the contextual toolbar.</summary>
    /// <param name="proxyControl">The proxy control.</param>
    /// <param name="objOnEditorWindowOpen">The object on editor window open.</param>
    /// <param name="objOnEditorWindowClosed">The object on editor window closed.</param>
    internal static void ShowContextualToolbar(
      Gizmox.WebGUI.Forms.Component objComponent,
      EventHandler objOnEditorWindowOpen,
      EventHandler objOnEditorWindowClosed)
    {
      if (objComponent == null || Form.GetValidOwnerForm(objComponent.Form) == null || !(CommonUtils.GetCustomAttribute(objComponent.GetType(), typeof (ContextualToolbarAttribute), true) is ContextualToolbarAttribute customAttribute) || !(customAttribute.CotextualToolbarType != (Type) null) || !(customAttribute.CotextualToolbarType == typeof (Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar)) && !customAttribute.CotextualToolbarType.IsSubclassOf(typeof (Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar)) || !(Activator.CreateInstance(customAttribute.CotextualToolbarType) is Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar instance))
        return;
      if (objOnEditorWindowClosed != null)
        instance.Closed += objOnEditorWindowClosed;
      Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.CurrentContextualToolbar = instance;
      if (instance.Skin is ContextualToolbarSkin skin)
        instance.Size = skin.ContextualToolbarSize;
      if (objOnEditorWindowOpen != null)
        objOnEditorWindowOpen((object) skin, new EventArgs());
      int num = (int) instance.ShowPopup(objComponent, DialogAlignment.Above);
    }

    /// <summary>Shows the contextual toolbar.</summary>
    /// <param name="lngId">The int identifier.</param>
    internal static void ShowContextualToolbar(Gizmox.WebGUI.Forms.Component objComponent) => Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ShowContextualToolbar(objComponent, (EventHandler) null, (EventHandler) null);

    /// <summary>Gets the current.</summary>
    /// <value>The current.</value>
    private static Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar CurrentContextualToolbar
    {
      get
      {
        if (!(VWGContext.Current is IContextParams current))
          return (Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar) null;
        if (current.ContextualToolbar == null)
          current.ContextualToolbar = (IForm) new Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar();
        return current.ContextualToolbar as Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar;
      }
      set
      {
        if (!(VWGContext.Current is IContextParams current))
          return;
        current.ContextualToolbar = (IForm) value;
      }
    }

    /// <summary>Handle property editing callback response</summary>
    /// <param name="objValue"></param>
    protected virtual void EditPropertyValue_Callback(object objValue)
    {
      try
      {
        if (this.mobjComponent == null || !(this.mobjControlProperty != (PropertyInfo) null))
          return;
        if (this.mobjCustomPropertyValueChangeEvent == null)
          this.mobjControlProperty.SetValue((object) this.mobjComponent, objValue, (object[]) null);
        else
          this.mobjCustomPropertyValueChangeEvent((object) this.mobjComponent, new ContextualToolbarPropertyValueEventArgs(this.mobjControlProperty.Name, objValue));
      }
      catch (Exception ex)
      {
      }
    }

    /// <summary>Closes any previously opened drop down control area.</summary>
    void IWebUIEditorService.CloseDropDown()
    {
    }

    /// <summary>
    /// Displays the specified control in a drop down area below a value field of the property grid that provides this service.
    /// </summary>
    /// <param name="objDialog">The dialog.</param>
    void IWebUIEditorService.ShowDropDown(Form objDialog)
    {
      if (objDialog == null)
        return;
      int num = (int) objDialog.ShowPopup((Gizmox.WebGUI.Forms.Component) Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.CurrentContextualToolbar, DialogAlignment.Below);
    }

    /// <summary>
    /// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
    void IWebUIEditorService.ShowDialog(Form objDialog) => ((IWebUIEditorService) this).ShowDropDown(objDialog);

    /// <summary>
    /// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
    /// </summary>
    /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
    void IWebUIEditorService.ShowDialog(CommonDialog objDialog)
    {
      if (objDialog == null)
        return;
      int num = (int) objDialog.ShowPopup((Form) Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.CurrentContextualToolbar, (IRegisteredComponent) Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.CurrentContextualToolbar, (EventHandler) null, DialogAlignment.Below, this.mobjEditorDialogLocation);
    }

    /// <summary>Gets the service object of the specified type.</summary>
    /// <param name="serviceType">An object that specifies the type of service object to get.</param>
    /// <returns>
    /// A service object of type <paramref name="serviceType" />.-or- null if there is no service object of type <paramref name="serviceType" />.
    /// </returns>
    public new object GetService(Type serviceType) => serviceType == typeof (IWebUIEditorService) ? (object) this : (object) null;

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (!(objValue is Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton contextualToolbarButton))
        return;
      contextualToolbarButton.Owner = this;
      this.mobjListOfButtons.Add(contextualToolbarButton);
    }

    /// <summary>Will contain information about a button data</summary>
    [Serializable]
    protected class ContextualToolbarButton : RegisteredComponent
    {
      private Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar mobjOwnerContextualToolbar;
      private string mstrPropertyName;
      private ImageResourceReference mobjButtonImageResourceReference;
      private string mstrTooltip;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarButton" /> class.
      /// </summary>
      /// <param name="strPropertyName">Name of the string property.</param>
      /// <param name="strCssClassName">Name of the string CSS class.</param>
      /// <param name="objButtonImageResourceReference">The object button image resource reference.</param>
      /// <param name="strTooltip">The string tooltip.</param>
      public ContextualToolbarButton(
        string strPropertyName,
        ImageResourceReference objButtonImageResourceReference,
        string strTooltip)
      {
        this.mstrPropertyName = strPropertyName;
        this.mobjButtonImageResourceReference = objButtonImageResourceReference;
        this.mstrTooltip = strTooltip;
      }

      /// <summary>Gets the current application context.</summary>
      public override IContext Context => this.mobjOwnerContextualToolbar != null ? this.mobjOwnerContextualToolbar.Context : VWGContext.Current;

      /// <summary>Gets or sets the owner contextual toolbar.</summary>
      /// <value>The owner contextual toolbar.</value>
      public Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar Owner
      {
        get => this.mobjOwnerContextualToolbar;
        set => this.mobjOwnerContextualToolbar = value;
      }

      /// <summary>Renders the contextualtoolbar.</summary>
      /// <param name="objContext">The object context.</param>
      /// <param name="objWriter">The object writer.</param>
      /// <param name="lngRequestID">The LNG request identifier.</param>
      protected internal virtual void RenderControl(
        IContext objContext,
        IResponseWriter objWriter,
        long lngRequestID)
      {
        objWriter.WriteStartElement(WGConst.ControlsPrefix, "CTBB", WGConst.ControlsNamespace);
        this.RenderAttributes(objContext, (IAttributeWriter) objWriter);
        objWriter.WriteEndElement();
      }

      /// <summary>Renders the attributes.</summary>
      /// <param name="objContext">The object context.</param>
      /// <param name="attributeWriter">The attribute writer.</param>
      protected virtual void RenderAttributes(IContext objContext, IAttributeWriter attributeWriter)
      {
        if (!string.IsNullOrEmpty(this.mstrPropertyName))
          attributeWriter.WriteAttributeString("N", this.mstrPropertyName);
        if (this.mobjButtonImageResourceReference != null)
          attributeWriter.WriteAttributeString("IM", this.mobjButtonImageResourceReference.GetValue(objContext));
        if (string.IsNullOrEmpty(this.mstrTooltip))
          return;
        attributeWriter.WriteAttributeString("TT", this.mstrTooltip);
      }
    }

    /// <summary>
    /// The context of the contextual tool bar to be passed to editors.
    /// </summary>
    [Serializable]
    internal class ContextualToolbarContext : ITypeDescriptorContext, IServiceProvider
    {
      private Gizmox.WebGUI.Forms.Component mobjComponent;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ContextualToolbarContext" /> class.
      /// </summary>
      /// <param name="objComponent">The object component.</param>
      public ContextualToolbarContext(Gizmox.WebGUI.Forms.Component objComponent) => this.mobjComponent = objComponent;

      /// <summary>
      /// Gets the container representing this <see cref="T:System.ComponentModel.TypeDescriptor" /> request.
      /// </summary>
      /// <returns>An <see cref="T:System.ComponentModel.IContainer" /> with the set of objects for this <see cref="T:System.ComponentModel.TypeDescriptor" />; otherwise, null if there is no container or if the <see cref="T:System.ComponentModel.TypeDescriptor" /> does not use outside objects.</returns>
      public IContainer Container => (IContainer) null;

      public object Instance => (object) this.mobjComponent;

      public void OnComponentChanged()
      {
      }

      public bool OnComponentChanging() => true;

      public PropertyDescriptor PropertyDescriptor => (PropertyDescriptor) null;

      public object GetService(Type serviceType) => (object) null;
    }
  }
}
