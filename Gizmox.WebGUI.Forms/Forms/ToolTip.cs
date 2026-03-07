// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolTip
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents a small rectangular pop-up window that displays a brief description of a control's purpose when the user rests the pointer on the control.
  /// </summary>
  [ProvideProperty("ToolTip", typeof (Control))]
  [SRDescription("DescriptionToolTip")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (ToolTip), "ToolTip_45.bmp")]
  [TypeDescriptionProvider(typeof (ToolTip.ToolTipTypeDescriptionProvider))]
  [Skin(typeof (ToolTipSkin))]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [Serializable]
  public class ToolTip : ComponentBase, IExtenderProvider, ISkinable
  {
    /// <summary>The Active property registration.</summary>
    private static SerializableProperty ActiveProperty = SerializableProperty.Register(nameof (Active), typeof (bool), typeof (ToolTip), new SerializablePropertyMetadata((object) true));
    /// <summary>The IsBalloon property registration.</summary>
    private static SerializableProperty IsBalloonProperty = SerializableProperty.Register(nameof (IsBalloon), typeof (bool), typeof (ToolTip), new SerializablePropertyMetadata((object) true));
    /// <summary>The AutoPopDelay property registration.</summary>
    private static SerializableProperty AutoPopDelayProperty = SerializableProperty.Register(nameof (AutoPopDelay), typeof (int), typeof (ToolTip), new SerializablePropertyMetadata((object) 5000));
    /// <summary>The InitialDelay property registration.</summary>
    private static SerializableProperty InitialDelayProperty = SerializableProperty.Register(nameof (InitialDelay), typeof (int), typeof (ToolTip), new SerializablePropertyMetadata((object) 0));
    /// <summary>The ReshowDelay property registration.</summary>
    private static SerializableProperty ReshowDelayProperty = SerializableProperty.Register(nameof (ReshowDelay), typeof (int), typeof (ToolTip), new SerializablePropertyMetadata((object) 0));
    /// <summary>The ToolTipTitle property registration.</summary>
    private static SerializableProperty ToolTipTitleProperty = SerializableProperty.Register(nameof (ToolTipTitle), typeof (string), typeof (ToolTip), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>The ToolTipIcon property registration.</summary>
    private static SerializableProperty ToolTipIconProperty = SerializableProperty.Register(nameof (ToolTipIcon), typeof (ToolTipIcon), typeof (ToolTip), new SerializablePropertyMetadata((object) ToolTipIcon.None));
    /// <summary>The AutomaticDelay property registration.</summary>
    private static SerializableProperty AutomaticDelayProperty = SerializableProperty.Register(nameof (AutomaticDelay), typeof (int), typeof (ToolTip), new SerializablePropertyMetadata((object) 500));
    /// <summary>The ShowAlways property registration.</summary>
    private static SerializableProperty ShowAlwaysProperty = SerializableProperty.Register(nameof (ShowAlways), typeof (bool), typeof (ToolTip), new SerializablePropertyMetadata((object) true));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> without a specified container.
    /// </summary>
    public ToolTip()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> class with a specified container.
    /// </summary>
    /// <param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see>. </param>
    public ToolTip(IContainer objContainer) => objContainer.Add((IComponent) this);

    /// <summary>Associates ToolTip text with the specified control.</summary>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to associate the ToolTip text with. </param>
    /// <param name="strCaption">The ToolTip text to display when the pointer is on the control. </param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void SetToolTip(Control objControl, string strCaption)
    {
      if (objControl == null)
        return;
      objControl.ToolTip = strCaption;
    }

    /// <summary>Retrieves the ToolTip text associated with the specified control.</summary>
    /// <returns>A <see cref="T:System.String"></see> containing the ToolTip text for the specified control.</returns>
    /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text. </param>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [Localizable(true)]
    [SRDescription("ToolTipToolTipDescr")]
    public string GetToolTip(Control objControl) => objControl == null ? "" : objControl.ToolTip;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolTip" /> is active.
    /// </summary>
    /// <value>
    ///   <c>true</c> if active; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Active
    {
      get => this.GetValue<bool>(ToolTip.ActiveProperty);
      set => this.SetValue<bool>(ToolTip.ActiveProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is balloon.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is balloon; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(false)]
    [SRDescription("ToolTipIsBalloonDescr")]
    public bool IsBalloon
    {
      get => this.GetValue<bool>(ToolTip.IsBalloonProperty);
      set => this.SetValue<bool>(ToolTip.IsBalloonProperty, value);
    }

    /// <summary>
    /// Gets or sets the period of time the ToolTip remains visible if the pointer is stationary on a control with specified ToolTip text
    /// </summary>
    /// <value>
    /// The period of time, in milliseconds, that the ToolTip remains visible when the pointer is stationary on a control. The default value is 5000.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("ToolTipAutoPopDelayDescr")]
    public int AutoPopDelay
    {
      get => this.GetValue<int>(ToolTip.AutoPopDelayProperty);
      set => this.SetValue<int>(ToolTip.AutoPopDelayProperty, value);
    }

    /// <summary>
    /// Gets or sets the time that passes before the ToolTip appears.
    /// </summary>
    /// <value>
    /// The period of time, in milliseconds, that the pointer must remain stationary on a control before the ToolTip window is displayed.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ToolTipInitialDelayDescr")]
    [RefreshProperties(RefreshProperties.All)]
    public int InitialDelay
    {
      get => this.GetValue<int>(ToolTip.InitialDelayProperty);
      set => this.SetValue<int>(ToolTip.InitialDelayProperty, value);
    }

    /// <summary>
    /// Gets or sets the length of time that must transpire before subsequent ToolTip windows appear as the pointer moves from one control to another.
    /// </summary>
    /// <value>
    /// The length of time, in milliseconds, that it takes subsequent ToolTip windows to appear.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ToolTipReshowDelayDescr")]
    [RefreshProperties(RefreshProperties.All)]
    public int ReshowDelay
    {
      get => this.GetValue<int>(ToolTip.ReshowDelayProperty);
      set => this.SetValue<int>(ToolTip.ReshowDelayProperty, value);
    }

    /// <summary>Gets or sets a title for the ToolTip window.</summary>
    /// <value>A String containing the window title.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue("")]
    [SRDescription("ToolTipTitleDescr")]
    public string ToolTipTitle
    {
      get => this.GetValue<string>(ToolTip.ToolTipTitleProperty);
      set => this.SetValue<string>(ToolTip.ToolTipTitleProperty, value);
    }

    /// <summary>
    /// Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text.
    ///  </summary>
    /// <value>
    /// One of the Gizmox.WebGUI.Forms.ToolTipIcon enumerated values.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(0)]
    [SRDescription("ToolTipToolTipIconDescr")]
    public ToolTipIcon ToolTipIcon
    {
      get => this.GetValue<ToolTipIcon>(ToolTip.ToolTipIconProperty);
      set => this.SetValue<ToolTipIcon>(ToolTip.ToolTipIconProperty, value);
    }

    /// <summary>Gets or sets the automatic delay for the ToolTip.</summary>
    /// <value>The automatic delay, in milliseconds. The default is 500.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("ToolTipAutomaticDelayDescr")]
    [DefaultValue(500)]
    public int AutomaticDelay
    {
      get => this.GetValue<int>(ToolTip.AutomaticDelayProperty);
      set => this.SetValue<int>(ToolTip.AutomaticDelayProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether a ToolTip window is displayed, even when its parent control is not active.
    /// </summary>
    /// <value>
    ///   true if the ToolTip is always displayed; otherwise, false. The default is false.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRDescription("ToolTipShowAlwaysDescr")]
    [DefaultValue(false)]
    public bool ShowAlways
    {
      get => this.GetValue<bool>(ToolTip.ShowAlwaysProperty);
      set => this.SetValue<bool>(ToolTip.ShowAlwaysProperty, value);
    }

    string ISkinable.Theme => VWGContext.Current.CurrentTheme;

    /// <summary>
    /// Returns true if the ToolTip can offer an extender property to the specified target component.
    /// </summary>
    /// <param name="objTarget">The target.</param>
    /// <returns>
    /// 	<c>true</c> if this instance can extend the specified target; otherwise, <c>false</c>.
    /// </returns>
    public bool CanExtend(object objTarget) => objTarget is Control && !(objTarget is ToolTip);

    /// <summary>Gets the name of the extended tool tip template.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <returns></returns>
    protected string GetExtendedToolTipTemplateName(Control objControl)
    {
      if (objControl != null)
      {
        string toolTipKey = this.ToolTipKey;
        ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor;
        if (toolTipDescriptor != null && toolTipDescriptor.ToolTipKey == toolTipKey)
          return toolTipDescriptor.ToolTipTemplateName;
      }
      return string.Empty;
    }

    /// <summary>Sets the name of the extended tool tip template.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="strValue">The STR value.</param>
    protected void SetExtendedToolTipTemplateName(Control objControl, string strValue)
    {
      if (objControl == null)
        return;
      string toolTipKey = this.ToolTipKey;
      ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor ?? new ToolTipDescriptor(toolTipKey);
      Dictionary<string, string> extendedProperties = toolTipDescriptor.ExtendedProperties;
      if (toolTipDescriptor.ToolTipKey != toolTipKey)
      {
        extendedProperties.Clear();
        toolTipDescriptor.ToolTipKey = toolTipKey;
      }
      toolTipDescriptor.ToolTipTemplateName = strValue;
      objControl.ExtendedToolTipDescriptor = toolTipDescriptor;
      objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
    }

    /// <summary>Gets the extended tool tip property.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="strPropertyName">Name of the STR property.</param>
    /// <returns></returns>
    protected string GetExtendedToolTipProperty(Control objControl, string strPropertyName)
    {
      if (objControl != null)
      {
        string toolTipKey = this.ToolTipKey;
        ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor;
        if (toolTipDescriptor != null && toolTipDescriptor.ToolTipKey == toolTipKey)
        {
          Dictionary<string, string> extendedProperties = toolTipDescriptor.ExtendedProperties;
          if (extendedProperties.ContainsKey(strPropertyName))
            return extendedProperties[strPropertyName];
        }
      }
      return string.Empty;
    }

    /// <summary>Sets the extended tool tip property.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="strPropertyName">The STR key.</param>
    /// <param name="strValue">The STR value.</param>
    protected void SetExtendedToolTipProperty(
      Control objControl,
      string strPropertyName,
      string strValue)
    {
      if (objControl == null)
        return;
      string toolTipKey = this.ToolTipKey;
      ToolTipDescriptor toolTipDescriptor = objControl.ExtendedToolTipDescriptor ?? new ToolTipDescriptor(toolTipKey);
      Dictionary<string, string> extendedProperties = toolTipDescriptor.ExtendedProperties;
      if (toolTipDescriptor.ToolTipKey != toolTipKey)
      {
        extendedProperties.Clear();
        toolTipDescriptor.ToolTipKey = toolTipKey;
      }
      if (extendedProperties.ContainsKey(strPropertyName))
        extendedProperties[strPropertyName] = strValue;
      else
        extendedProperties.Add(strPropertyName, strValue);
      objControl.ExtendedToolTipDescriptor = toolTipDescriptor;
      objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
    }

    /// <summary>Gets the tool tip key. Identifies tooltip on client.</summary>
    protected virtual string ToolTipKey => string.Empty;

    /// <summary>
    /// 
    /// </summary>
    private class ToolTipTypeDescriptionProvider : TypeDescriptionProvider
    {
      /// <summary>
      ///  Static that holds a default type provider of a component base.
      /// </summary>
      private static TypeDescriptionProvider mobjDefaultTypeProvider = TypeDescriptor.GetProvider(typeof (ComponentBase));

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip.ToolTipTypeDescriptionProvider" /> class.
      /// </summary>
      public ToolTipTypeDescriptionProvider()
        : base(ToolTip.ToolTipTypeDescriptionProvider.mobjDefaultTypeProvider)
      {
      }

      /// <summary>Gets the type of the reflection.</summary>
      /// <param name="objObjectType">Type of the obj object.</param>
      /// <param name="objInstance">The obj instance.</param>
      /// <returns></returns>
      public override Type GetReflectionType(Type objObjectType, object objInstance) => objInstance is ComponentBase componentBase && componentBase.Site != null && componentBase.Site.DesignMode ? (Type) new ToolTip.ToolTipTypeDescriptionProvider.ToolTipTypeDelegator(objObjectType) : base.GetReflectionType(objObjectType, objInstance);

      /// <summary>
      /// 
      /// </summary>
      private class ToolTipTypeDelegator : TypeDelegator
      {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip.ToolTipTypeDescriptionProvider.ToolTipTypeDelegator" /> class.
        /// </summary>
        /// <param name="objDelegatingType">Type of the obj delegating.</param>
        public ToolTipTypeDelegator(Type objDelegatingType)
          : base(objDelegatingType)
        {
        }

        /// <summary>Gets the attributes assigned to the TypeDelegator.</summary>
        /// <returns>
        /// A TypeAttributes object representing the implementation attribute flags.
        /// </returns>
        protected override TypeAttributes GetAttributeFlagsImpl() => base.GetAttributeFlagsImpl() & ~TypeAttributes.Serializable;
      }
    }
  }
}
