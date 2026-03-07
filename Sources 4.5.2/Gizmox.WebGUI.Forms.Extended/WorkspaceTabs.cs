#region Using

using System;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region WorkspaceTabs
	
	/// <summary>
    /// Manages a related set of tab pages.
	/// </summary>
	[ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(WorkspaceTabs), "Extended.WorkspaceTabs_45.png")]
#else
    [ToolboxBitmap(typeof(WorkspaceTabs), "Extended.WorkspaceTabs.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Forms.Extended.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.WorkspaceTabsController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("TabPages"),DefaultEvent("SelectedIndexChanged")]
    [ToolboxItemCategory("Containers")]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.WorkspaceTabsSkin)), Serializable()]
    public class WorkspaceTabs : TabControl, IRequiresRegistration
	{
		#region C'Tor/D'Tor
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTabs"></see> class.
		/// </summary>
		public WorkspaceTabs() : base()
		{
            
		}

		#endregion C'Tor/D'Tor	

        /// <summary>
        /// Gets or sets the client update handler.
        /// </summary>
        /// <value>The client update handler.</value>
        protected override string ClientUpdateHandler
        {
            get
            {
                return (this.ClientBehavior == TabControlClientBehavior.DrawingOptimized ? "WorkspaceTabs_UpdateHandler" : string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the visual appearance of the control's tabs.
        /// </summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> values. The default is Normal.</returns>
        ///   
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> value. </exception>
        ///   
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override TabAppearance Appearance
        {
            get
            {
                return TabAppearance.Workspace;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether more than one row of tabs can be displayed.
        /// </summary>
        /// <value></value>
        /// <returns>true if more than one row of tabs can be displayed; otherwise, false. The default is true.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
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
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects in this <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), MergableProperty(false)]
        public new WorkspaceTabsCollection TabPages
        {
            get
            {
                return (WorkspaceTabsCollection)base.TabPages;
            }
        }

        /// <summary>
        /// Creates the tab page collection.
        /// </summary>
        /// <returns></returns>
        protected override TabPageCollection CreateTabPageCollection()
        {
            return new WorkspaceTabsCollection(this);
        }
        /// <summary>
        /// Provides a property reference to ShowCloseButton property.
        /// </summary>
        private static SerializableProperty ShowCloseButtonProperty = SerializableProperty.Register("ShowCloseButton", typeof(bool), typeof(WorkspaceTabs), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Gets or Sets value indication if the close button (when Appearance==TabAppearance.Workspace) 
        /// should be shown
        /// </summary>
        [DefaultValue(true)]
        public override bool  ShowCloseButton
        {
            get
            {
                return this.GetValue<bool>(WorkspaceTabs.ShowCloseButtonProperty);
            }
            set
            {
                if (this.SetValue<bool>(WorkspaceTabs.ShowCloseButtonProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
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
    }

    #endregion

    #region WorkspaceTab

    /// <summary>
    /// Represents a single tab page in a <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTabs"></see>.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif

    [DesignTimeVisible(false), ToolboxItem(false), DefaultProperty("Text"), Serializable()]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.WorkspaceTabSkin))]
	public class WorkspaceTab : TabPage
	{
		#region C'Tors
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTab"></see> class.
		/// </summary>
        public WorkspaceTab() : base()
		{
            this.CustomStyle = "Workspace";
		}
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.WorkspaceTab"></see> class and specifies the text for the tab.
		/// </summary>
        ///	<param name="strText">The text for the tab. </param>
		public WorkspaceTab(string strText) : base(strText)
		{
            this.CustomStyle = "Workspace";
		}
		
		#endregion C'Tors

        /// <summary>
        /// Gets or sets the appearance.
        /// </summary>
        /// <value>
        /// The appearance.
        /// </value>
        protected override TabAppearance Appearance
        {
            get
            {
                return TabAppearance.Workspace;
            }
            set
            { }
        }
    }
	
	#endregion WorkspaceTab

    #region WorkspaceTabsCollection
	
	/// <summary>
	/// Tab pages collection class
	/// </summary>

    [Serializable()]
    public class WorkspaceTabsCollection : TabPageCollection
	{

		#region C'Tor
		
		/// <summary>
		/// Creates a new <see cref="TabPageCollection"/> instance.
		/// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WorkspaceTabsCollection(TabControl objTabControl)
            : base(objTabControl)
		{
	
		}
		
		
		#endregion C'Tor
		

		/// <summary>
		/// Adds the specified tab page.
		/// </summary>
		/// <param name="objTabPage">tab page.</param>
		/// <returns></returns>
		public override int Add(TabPage objTabPage)
		{
			if(objTabPage is WorkspaceTab)
			{
				return base.Add(objTabPage);
			}
			else
			{
				return -1;
			}
		}
		
		/// <summary>
		/// Removes the specified tab page.
		/// </summary>
		/// <param name="objTabPage">tab page.</param>
		public override void Remove(TabPage objTabPage)
		{
			base.Remove(objTabPage);
		}

		/// <summary>
		/// Gets the <see cref="TabPage"/> with the specified int index.
		/// </summary>
		/// <value></value>
		public new WorkspaceTab this[int intIndex]
		{
			get
			{
				return (WorkspaceTab)base[intIndex];
			}
		}
		
	}
	
	#endregion WorkspaceTabsCollection
}
