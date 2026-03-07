// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MdiClient
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Represents the container for multiple-document interface (MDI) child forms. This class cannot be inherited.
  /// </summary>
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [Gizmox.WebGUI.Forms.MetadataTag("MDIC")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MdiClientSkin))]
  [Serializable]
  public sealed class MdiClient : Control
  {
    /// <summary>The Children property registration.</summary>
    private static readonly SerializableProperty ChildrenProperty = SerializableProperty.Register("Children", typeof (ArrayList), typeof (MdiClient));

    /// <summary>Gets or sets the children.</summary>
    /// <value>The children.</value>
    private ArrayList ChildrenInternal
    {
      get => this.GetValue<ArrayList>(MdiClient.ChildrenProperty);
      set => this.SetValue<ArrayList>(MdiClient.ChildrenProperty, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> class.
    /// </summary>
    public MdiClient()
    {
      this.ChildrenInternal = new ArrayList();
      this.SetStyle(ControlStyles.Selectable, false);
      this.Dock = DockStyle.Fill;
    }

    /// <summary>
    /// Creates a new instance of the control collection for the control.
    /// </summary>
    /// <returns>
    /// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> assigned to the control.
    /// </returns>
    protected override Control.ControlCollection CreateControlsInstance() => (Control.ControlCollection) new MdiClient.ControlCollection(this);

    /// <summary>
    /// Arranges the multiple-document interface (MDI) child forms within the MDI parent form.
    /// </summary>
    /// <param name="value">One of the <see cref="T:Gizmox.WebGUI.Forms.MdiLayout"></see> values that defines the layout of MDI child forms.</param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void LayoutMdi(MdiLayout value)
    {
      if (!(this.Parent is Form parent) || !parent.IsMdiContainer || parent.OwnedForms.Length == 0)
        return;
      int num = 0;
      foreach (Form ownedForm in parent.OwnedForms)
      {
        ownedForm.StartPosition = FormStartPosition.Manual;
        if (value == MdiLayout.Cascade)
        {
          ownedForm.Top = num * 29;
          ownedForm.Left = num * 22;
        }
        ownedForm.UpdateParamsInternal(AttributeType.Layout);
        ++num;
      }
    }

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.Parent == null)
        return;
      objWriter.WriteAttributeString("MDP", this.Parent.ID.ToString());
    }

    /// <summary>Shoulds the color of the serialize back.</summary>
    /// <returns></returns>
    internal override bool ShouldSerializeBackColor() => this.BackColor != SystemColors.AppWorkspace;

    private bool ShouldSerializeLocation() => false;

    /// <summary>Shoulds the size of the serialize.</summary>
    /// <returns></returns>
    protected override bool ShouldSerializeSize() => false;

    /// <summary>
    /// Gets or sets the background image displayed in the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
    /// </summary>
    /// <returns>An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
    [Localizable(true)]
    public override ResourceHandle BackgroundImage
    {
      get
      {
        ResourceHandle backgroundImage = base.BackgroundImage;
        if (backgroundImage == null && this.ParentInternal != null)
          backgroundImage = this.ParentInternal.BackgroundImage;
        return backgroundImage;
      }
      set => base.BackgroundImage = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => this.BackgroundImage != null && this.ParentInternal != null && base.BackgroundImageLayout != this.ParentInternal.BackgroundImageLayout ? this.ParentInternal.BackgroundImageLayout : base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>
    /// Gets the child multiple-document interface (MDI) forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> control.
    /// </summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Form"></see> array that contains the child MDI forms of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see>.</returns>
    public Form[] MdiChildren
    {
      get
      {
        Form[] mdiChildren = new Form[this.ChildrenInternal.Count];
        this.ChildrenInternal.CopyTo((Array) mdiChildren, 0);
        return mdiChildren;
      }
    }

    /// <summary>
    /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.MdiClient"></see> controls.
    /// </summary>
    [Serializable]
    public new class ControlCollection : Control.ControlCollection
    {
      private MdiClient mobjOwner;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MdiClient.ControlCollection"></see> class, specifying the owner of the collection.
      /// </summary>
      /// <param name="objOwner">The owner of the collection.</param>
      public ControlCollection(MdiClient objOwner)
        : base((Control) objOwner)
      {
        this.mobjOwner = objOwner;
      }

      /// <summary>
      /// Adds a control to the multiple-document interface (MDI) Container.
      /// </summary>
      /// <param name="objControl">MDI Child Form to add. </param>
      public override void Add(Control objControl)
      {
        if (!(objControl is Form) || !((Form) objControl).IsMdiChild)
          throw new ArgumentException(SR.GetString("MDIChildAddToNonMDIParent"), "value");
        this.mobjOwner.ChildrenInternal.Add((object) (Form) objControl);
        base.Add(objControl);
      }

      /// <summary>Removes a child control.</summary>
      /// <param name="objValue">MDI Child Form to remove. </param>
      public override void Remove(Control objValue)
      {
        this.mobjOwner.ChildrenInternal.Remove((object) objValue);
        base.Remove(objValue);
      }
    }
  }
}
