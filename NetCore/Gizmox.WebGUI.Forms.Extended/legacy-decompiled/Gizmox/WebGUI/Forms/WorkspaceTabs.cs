using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Manages a related set of tab pages.
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(WorkspaceTabs), "Extended.WorkspaceTabs_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
[ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[DefaultProperty("TabPages")]
[DefaultEvent("SelectedIndexChanged")]
[ToolboxItemCategory("Containers")]
[Skin(typeof(WorkspaceTabsSkin))]
public class WorkspaceTabs : TabControl, IRequiresRegistration
{
	/// <summary>
	/// Provides a property reference to ShowCloseButton property.
	/// </summary>
	private static SerializableProperty ShowCloseButtonProperty = SerializableProperty.Register("ShowCloseButton", typeof(bool), typeof(WorkspaceTabs), new SerializablePropertyMetadata(true));

	/// <summary>
	/// Gets or sets the client update handler.
	/// </summary>
	/// <value>The client update handler.</value>
	protected override string ClientUpdateHandler => (ClientBehavior == TabControlClientBehavior.DrawingOptimized) ? "WorkspaceTabs_UpdateHandler" : string.Empty;

	/// <summary>
	/// Gets or sets the visual appearance of the control's tabs.
	/// </summary>
	/// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> values. The default is Normal.</returns>
	///
	/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> value. </exception>
	///
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public override TabAppearance Appearance
	{
		get
		{
			return TabAppearance.Workspace;
		}
		set
		{
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether more than one row of tabs can be displayed.
	/// </summary>
	/// <value></value>
	/// <returns>true if more than one row of tabs can be displayed; otherwise, false. The default is true.</returns>
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override bool Multiline
	{
		get
		{
			return false;
		}
		set
		{
			base.Multiline = value;
		}
	}

	/// <summary>
	/// Gets the collection of tab pages in this tab control.
	/// </summary>
	/// <returns>A <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects in this <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.</returns>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[MergableProperty(false)]
	public new WorkspaceTabsCollection TabPages => (WorkspaceTabsCollection)base.TabPages;

	/// <summary>
	/// Gets or Sets value indication if the close button (when Appearance==TabAppearance.Workspace) 
	/// should be shown
	/// </summary>
	[DefaultValue(true)]
	public override bool ShowCloseButton
	{
		get
		{
			return GetValue<bool>(ShowCloseButtonProperty);
		}
		set
		{
			if (SetValue(ShowCloseButtonProperty, value))
			{
				UpdateParams(AttributeType.Control);
			}
		}
	}

	/// <summary>
	/// Gets or sets the max page headers.
	/// </summary>
	/// <value>
	/// The max page headers.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Obsolete("Not supported")]
	public override int MaxTabPageHeaders
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTabs"></see> class.
	/// </summary>
	public WorkspaceTabs()
	{
	}

	/// <summary>
	/// Creates the tab page collection.
	/// </summary>
	/// <returns></returns>
	protected override TabPageCollection CreateTabPageCollection()
	{
		return new WorkspaceTabsCollection(this);
	}
}
