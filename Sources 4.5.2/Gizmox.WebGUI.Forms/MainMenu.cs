#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Collections;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;


#endregion 

namespace Gizmox.WebGUI.Forms
{
    #region MainMenu Class

    /// <summary>
    /// Summary description for MainMenu.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(MainMenu), "MainMenu_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(MainMenu), "MainMenu.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemFilter("Gizmox.WebGUI.Forms.MainMenu")]
    [ToolboxItemCategory("Menus & Toolbars")]
    [MetadataTag(WGTags.MainMenu)]
    [Skin(typeof(MainMenuSkin))]
    [Serializable()]
    [ProxyComponent(typeof(ProxyMainMenu))]
    public class MainMenu : Control, IRegisteredComponentContainer, IMainMenu
    {
        #region Class Members

        /// <summary>
        /// The main menu menu items
        /// </summary>
        private MenuItemCollection ItemsInternal
        {
            get
            {
                return this.GetValue<MenuItemCollection>(MainMenu.ItemsProperty, null);
            }
            set
            {
                this.SetValue<MenuItemCollection>(MainMenu.ItemsProperty, value);
            }
        }

        /// <summary>
        /// The Items property registration.
        /// </summary>
        private static readonly SerializableProperty ItemsProperty = SerializableProperty.Register("Items", typeof(MenuItemCollection), typeof(MainMenu));

        #endregion

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="MainMenu"/> instance.
        /// </summary>
        /// <param name="objControl">parent control.</param>
        internal MainMenu(Control objControl)
        {
            // Set the main menu parent
            this.InternalParent = objControl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
            : this(null)
        {
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing && this.Form != null)
            {
                this.Form.Menu = null;
            }

            base.Dispose(blnDisposing);
        }

        #endregion

        /// <summary>
        /// Renders the height.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        internal override void RenderHeight(IContext objContext, IAttributeWriter objWriter)
        {
            MainMenuSkin objSkin = this.Skin as MainMenuSkin;
            if (objSkin != null)
            {
                objWriter.WriteAttributeString("H", objSkin.Height.ToString());
            }
            else
            {
                base.RenderHeight(objContext, objWriter);
            }
        }

        /// <summary>
        /// MainMenu render impementation
        /// </summary>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Get menu item critical events
            string strEvents = this.GetMenuItemCriticalEventsData().ToClientString();

            // add all column declaration
            foreach (MenuItem objMenuItem in MenuItems)
            {
                if (objMenuItem.Visible)
                {
                    // Register enter event.
                    objMenuItem.Enter += new EventHandler(MenuItem_Enter);

                    this.RegisterComponent(objMenuItem);

                    objWriter.WriteStartElement(WGTags.Item);

                    objWriter.WriteAttributeString(WGAttributes.Id, objMenuItem.GetProxyPropertyValue<long>("ID", objMenuItem.ID).ToString());

                    if (!objMenuItem.Enabled)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Enabled, "0");
                    }

                    objWriter.WriteAttributeString(WGAttributes.Events, strEvents);

                    // Render the has nodes attribute - if needed.
                    if (objMenuItem != null && objMenuItem.MenuItems.Count > 0)
                    {
                        objWriter.WriteAttributeString(WGAttributes.HasNodes, "1");
                    }

                    objWriter.WriteAttributeText(WGAttributes.Text, objMenuItem.Text, TextFilter.CarriageReturn | TextFilter.NewLine);

                    // Render extended component attributes.
                    objMenuItem.RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);

                    objWriter.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Gets the critical events of specific menu item instance.
        /// </summary>
        private CriticalEventsData GetMenuItemCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            objEvents.Set(WGEvents.Click);

            if (this.HasHandler(Control.DoubleClickEvent))
            {
                objEvents.Set(WGEvents.DoubleClick);
            }

            //Return critical events
            return objEvents;
        }

        /// <summary>
        /// Handles the Enter event of the MenuItem control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItem_Enter(object objSender, EventArgs e)
        {
            MenuItem objMenuItem = objSender as MenuItem;
            if (objMenuItem != null)
            {
                // Show sub menu.
                this.ShowSubMenu(objMenuItem);
            }
        }

        /// <summary>
        /// Shows the submenu form.
        /// </summary>
        /// <param name="objMenuItem">The obj menu item.</param>
        private void ShowSubMenu(MenuItem objMenuItem)
        {
            // Check that the recievd menu is not already shown and that it has sub menu items.
            if (objMenuItem != null && objMenuItem.MenuItems.Count > 0)
            {
                // Show submenu form.
                objMenuItem.Show(objMenuItem, Point.Empty, DialogAlignment.Below);
            }
        }


        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            // If value is a menu item
            if (objValue is MenuItem)
            {
                this.MenuItems.Add((MenuItem)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        [System.ComponentModel.ListBindable(false)]
        [System.ComponentModel.Browsable(false)]
        public MenuItemCollection MenuItems
        {
            get
            {
                if (this.ItemsInternal == null)
                {
                    this.ItemsInternal = new MenuItemCollection(this);
                }
                return this.ItemsInternal;
            }
        }

        /// <summary>
        /// Gets the parent of this component.
        /// </summary>
        /// <value></value>
        public override Component InternalParent
        {
            get
            {
                return base.InternalParent;
            }
            set
            {
                if (base.InternalParent != value)
                {
                    if (value == null)
                    {
                        this.MenuItems.RemovingFromDOM();
                    }
                    base.InternalParent = value;
                    if (value != null)
                    {
                        this.MenuItems.AttachedToDOM();
                    }
                }
            }
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            // register the Items
            if (ItemsInternal != null)
            {
                RegisterBatch(ItemsInternal);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister the Items
            if (ItemsInternal != null)
            {
                UnRegisterBatch(ItemsInternal);
            }
        }

        #region IRegisteredComponentContainer Members

        ICollection IRegisteredComponentContainer.ContainedComponents
        {
            get
            {
                return ItemsInternal;
            }
        }

        #endregion

        #region IMainMenu Members

        ICollection IMainMenu.MenuItems
        {
            get
            {
                return this.MenuItems;
            }
        }

        System.ComponentModel.IComponent IMainMenu.Parent
        {
            get
            {
                return this.Parent;
            }
        }

        #endregion

        /// <summary>
        /// Fires the click event.
        /// </summary>
        /// <param name="objMouseEventArgs">The <see cref="Gizmox.WebGUI.Forms.MouseEventArgs"/> instance containing the event data.</param>
        internal void FireClick(MouseEventArgs objMouseEventArgs)
        {
            this.OnClick(objMouseEventArgs);
        }

        /// <summary>
        /// Fires the double click event.
        /// </summary>
        /// <param name="objMouseEventArgs">The <see cref="Gizmox.WebGUI.Forms.MouseEventArgs"/> instance containing the event data.</param>
        internal void FireDoubleClick(MouseEventArgs objMouseEventArgs)
        {
            this.OnDoubleClick(objMouseEventArgs);
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.MenuItems;
        }
    }

    #endregion
}
