#region Using

using System;
using System.Xml;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Specialized;
using System.Collections.Generic;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region enums

    /// <summary>Specifies the behavior of a <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> when it is merged with items in another menu.</summary>
    /// <filterpriority>2</filterpriority>
    [Obsolete("Not implemented yet.")]
    public enum MenuMerge
    {
        Add,
        Replace,
        MergeItems,
        Remove
    }

    #endregion

    #region ShortcutsContainer Class

    /// <summary>
    /// Contains a collection of mapped shortcuts
    /// </summary>
    /// <remarks>
    /// The chortcut container is used internaly by the VWG form to 
    /// hold all shortcuts and their component mappings.
    /// </remarks>
    [ToolboxItem(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Serializable()]
    public class ShortcutsContainer : Component, IEnumerable
    {

        private Hashtable mobjShortcuts = null;

        private Hashtable mobjComponents = null;

        internal ShortcutsContainer()
        {

        }

        internal void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // if control is dirty
            if (IsDirty(lngRequestID))
            {
                this.RegisterSelf();

                objWriter.WriteStartElement(WGConst.Prefix, WGTags.ShortcutsContainer, WGConst.Namespace);
                RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);
                if (mobjShortcuts != null)
                {
                    foreach (string strShortcut in mobjShortcuts.Keys)
                    {
                        IRegisteredComponent objComponent = mobjShortcuts[strShortcut] as IRegisteredComponent;
                        if (objComponent != null)
                        {
                            objWriter.WriteStartElement(WGTags.Item);
                            objWriter.WriteAttributeString(WGAttributes.Shortcut, strShortcut);
                            objWriter.WriteEndElement();
                        }
                    }
                }
                objWriter.WriteEndElement();
            }
        }
        private Hashtable Components
        {
            get
            {
                if (mobjComponents == null)
                {
                    mobjComponents = new Hashtable();
                }
                return mobjComponents;
            }
        }

        private Hashtable Shortcuts
        {
            get
            {
                if (mobjShortcuts == null)
                {
                    mobjShortcuts = new Hashtable();
                }
                return mobjShortcuts;
            }
        }

        /// <summary>
        /// Maps a new shortcut
        /// </summary>
        /// <param name="strShortcut"></param>
        /// <param name="objComponent"></param>
        public void Add(string strShortcut, IRegisteredComponent objComponent)
        {
            this.Remove(objComponent);
            this.Shortcuts[strShortcut] = objComponent;
            this.Components[objComponent] = strShortcut;
            this.Update();
        }

        /// <summary>
        /// Removes an existing shortcut mapping
        /// </summary>
        /// <param name="objComponent"></param>
        public void Remove(IRegisteredComponent objComponent)
        {
            if (this.Components.ContainsKey(objComponent))
            {
                string strShortcut = (string)this.Components[objComponent];
                if (this.Shortcuts[strShortcut] == objComponent)
                {
                    this.Shortcuts.Remove(strShortcut);
                }

                this.Components.Remove(objComponent);
                this.Update();
            }
        }

        /// <summary>
        /// Get compenent mapped to shortcut
        /// </summary>
        /// <param name="enmShortcut"></param>
        /// <returns></returns>
        public IRegisteredComponent this[string strShortcut]
        {
            get
            {
                return this.Shortcuts[strShortcut] as IRegisteredComponent;
            }
        }

        /// <summary>
        /// Get shortcut mapped to component
        /// </summary>
        /// <param name="objComponent"></param>
        /// <returns></returns>
        public string this[IRegisteredComponent objComponent]
        {
            get
            {
                if (this.Components.Contains(objComponent))
                {
                    return (string)this.Components[objComponent];
                }
                else
                {
                    return null;
                }
            }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Shortcuts.GetEnumerator();
        }

        #endregion
    }

    #endregion ShortcutsContainer Class

    #region MenuItem Class

    /// <summary>
    /// Summary description for Menu Item.
    /// </summary>
    [Serializable()]
    [DefaultProperty("Text"), ToolboxItem(false), DesignTimeVisible(false), DefaultEvent("Click")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    public class MenuItem : Menu
    {
        #region Fields

        /// <summary>
        /// The TextInteranl property registration.
        /// </summary>
        private static readonly SerializableProperty TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(MenuItem));

        /// <summary>
        /// The IconInteranl property registration.
        /// </summary>
        private static readonly SerializableProperty IconProperty = SerializableProperty.Register("Icon", typeof(ResourceHandle), typeof(MenuItem));

        /// <summary>
        /// The RadioCheckInteranl property registration.
        /// </summary>
        private static readonly SerializableProperty RadioCheckProperty = SerializableProperty.Register("RadioCheck", typeof(bool), typeof(MenuItem));

        /// <summary>
        /// The ShortcutInternal property registration.
        /// </summary>
        private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register("Shortcut", typeof(Shortcut), typeof(MenuItem));

        /// <summary>
        /// The Click event registration.
        /// </summary>
        private static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof(EventHandler), typeof(MenuItem));

        /// <summary>
        /// The Enter event registration.
        /// </summary>
        private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(MenuItem));

        /// <summary>
        /// The ShowShortcut property registration.
        /// </summary>
        private static readonly SerializableProperty ShowShortcutProperty = SerializableProperty.Register("ShowShortcut", typeof(bool), typeof(MenuItem));

        /// <summary>
        /// The Name property registration.
        /// </summary>
        private static readonly SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(MenuItem));

        #endregion Fields

        #region C'tors / D'tors

        /// <summary>Initializes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> with a blank caption.</summary>
        public MenuItem()
        {
            TextInteranl = "";

            // Set the initilize state
            InitializeState();
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption for the menu item.</summary>
        /// <param name="strText">The caption for the menu item. </param>
        public MenuItem(string strText)
        {
            TextInteranl = strText;

            // Set the initilize state
            InitializeState();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="strIcon">The icon.</param>
        public MenuItem(string strText, string strIcon)
        {
            TextInteranl = strText;
            if (strIcon != "")
            {
                IconInteranl = new IconResourceHandle(strIcon + ".gif");
            }

            // Set the initilize state
            InitializeState();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="strText">The menu item Text</param>
        /// <param name="strIcon">The menu item icon</param>
        /// <param name="objTag">The obj tag.</param>
        public MenuItem(string strText, string strIcon, object objTag)
            : this(strText, strIcon)
        {
            Tag = objTag;
        }

        /// <summary>Initializes a new instance of the class with a specified caption and event handler for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event of the menu item.</summary>
        /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
        /// <param name="strText">The caption for the menu item. </param>
        public MenuItem(string strText, EventHandler onClick)
            : this(MenuMerge.Add, 0, Shortcut.None, strText, onClick, null, null, null)
        {

        }

        /// <summary>Initializes a new instance of the class with a specified caption and an array of submenu items defined for the menu item.</summary>
        /// The items param is not impemented.
        /// <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
        /// <param name="strText">The caption for the menu item. </param>
        [Obsolete("The items param is not impemented use public MenuItem(string strText)")]
        public MenuItem(string strText, MenuItem[] arrItems)
            : this(MenuMerge.Add, 0, Shortcut.None, strText, null, null, null, arrItems)
        {
        }

        /// <summary>Initializes a new instance of the class with a specified caption, event handler, and associated shortcut key for the menu item.</summary>
        /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
        /// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
        /// <param name="strText">The caption for the menu item. </param>
        public MenuItem(string strText, EventHandler onClick, Shortcut enmShortcut)
            : this(MenuMerge.Add, 0, enmShortcut, strText, onClick, null, null, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption; defined event-handlers for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see>, <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> and <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> events; a shortcut key; a merge type; and order specified for the menu item.</summary>
        /// The mergeType, mergeOrder, onSelect, onPopup and items params are not impemented.
        /// <param name="onSelect">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> event for this menu item[not impemented]. </param>
        /// <param name="intMergeOrder">The relative position that this menu item will take in a merged menu[not impemented]. </param>
        /// <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
        /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
        /// <param name="enmMergeType">One of the <see cref="T:Gizmox.WebGUI.Forms.MenuMerge"></see> values[not impemented]. </param>
        /// <param name="onPopup">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> event for this menu item[not impemented]. </param>
        /// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
        /// <param name="strText">The caption for the menu item. </param>
        [Obsolete("TThe mergeType, mergeOrder, onSelect, onPopup and items params are not impemented use public MenuItem(string text, EventHandler onClick, Shortcut shortcut)")]
        public MenuItem(MenuMerge enmMergeType, int intMergeOrder, Shortcut enmShortcut, string strText, EventHandler onClick,
            EventHandler onPopup, EventHandler onSelect, MenuItem[] arrItems)
        {
            TextInteranl = strText;
            this.Click += onClick;
            ShortcutInternal = enmShortcut;

            // Set the initilize state
            InitializeState();
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            if (this.Visible && this.Enabled)
            {
                // invoke base method
                base.FireEvent(objEvent);

                // Select event type
                switch (objEvent.Type)
                {
                    case "DoubleClick":
                        if (this.Enabled)
                        {
                            //check if parent is MainMenu
                            if (this.InternalParent != null && this.InternalParent is MainMenu)
                            {
                                //fire Double Click event
                                ((MainMenu)this.InternalParent).FireDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                            }
                        }
                        break;
                    case "Shortcut":
                    case "Click":
                        if (this.Enabled)
                        {
                            //If this is a valid click
                            bool blnIsLeftClick = true;

                            //If this is a click and not shortcut test if right click
                            if (objEvent.Type == "Click")
                            {
                                //Get mouse event args
                                //If we have events args, check it's a left click
                                blnIsLeftClick = MouseButtons.Left == GetEventButtonsValue(objEvent, MouseButtons.Left);

                                //check if parent is MainMenu
                                if (this.InternalParent != null && this.InternalParent is MainMenu)
                                {
                                    //fire Click event
                                    ((MainMenu)this.InternalParent).FireClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                                }
                            }

                            //if we have a valid click
                            if (blnIsLeftClick)
                            {
                                // We should avoid calling to ClickHandler in case we have
                                // submenu items, because Click() handler will called also
                                if (this.MenuItems.Count == 0)
                                {
                                    this.OnClick(new EventArgs());
                                }
                                else
                                {
                                    // Show submenu items, only, avoiding calling to the handler
                                    Show(this, Point.Empty, DialogAlignment.Below);
                                }

                                Component objComponent = GetAncestorByType(typeof(Control));
                                if (objComponent != null && this.MenuItems.Count == 0)
                                {
                                    objComponent.FireMenuClick(this);
                                }
                            }
                        }
                        break;

                    case "Enter":
                        if (this.Enabled)
                        {
                            if (EnterHandler != null)
                            {
                                EnterHandler(this, new EventArgs());
                            }
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnClick(EventArgs objEventArgs)
        {
            if (ClickHandler != null)
            {
                ClickHandler(this, objEventArgs);
            }
        }

        #endregion

        #region Render

        #endregion Render


        internal void AttachedToDOM()
        {
            this.RegisterShortcut();
            this.MenuItems.AttachedToDOM();
        }

        internal void RemovingFromDOM()
        {
            this.UnregisterShortcut(false);
            this.MenuItems.RemovingFromDOM();
        }

        private void UnregisterShortcut(bool blnForce)
        {
            if (ShortcutInternal != Shortcut.None || blnForce)
            {
                Form objParentForm = this.Form;
                if (objParentForm != null)
                {
                    objParentForm.Shortcuts.Remove(this);
                }
            }
        }

        private void RegisterShortcut()
        {
            if (ShortcutInternal != Shortcut.None)
            {
                Form objParentForm = this.Form;
                if (objParentForm != null)
                {
                    objParentForm.Shortcuts.Add(ShortcutInternal.ToString(), this);
                }
            }
        }

        /// <summary>
        /// Fires the click.
        /// </summary>
        internal void FireClick()
        {
            if (ClickHandler != null)
            {
                ClickHandler(this, new EventArgs());
            }

            if (this.Parent != null)
            {
                this.Parent.FireClick(this);
            }
        }

        /// <summary>
        /// Initializes the state.
        /// </summary>
        private void InitializeState()
        {
            // Set the default state
            this.SetState(ComponentState.Visible | ComponentState.Enabled, true);
        }

        /// <summary>
        /// Disposes the specified component.
        /// </summary>
        /// <param name="blnDisposing"></param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                if (this.Parent != null)
                {
                    this.Parent.MenuItems.Remove(this);
                }
            }
            base.Dispose(blnDisposing);
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

        #endregion Methods

        #region Properties

        private string TextInteranl
        {
            get
            {
                return this.GetValue<string>(MenuItem.TextProperty, string.Empty);
            }
            set
            {
                this.SetValue<string>(MenuItem.TextProperty, value);
            }
        }

        private ResourceHandle IconInteranl
        {
            get
            {
                return this.GetValue<ResourceHandle>(MenuItem.IconProperty, null);
            }
            set
            {
                this.SetValue<ResourceHandle>(MenuItem.IconProperty, value);
            }
        }

        private bool RadioCheckInteranl
        {
            get
            {
                return this.GetValue<bool>(MenuItem.RadioCheckProperty, false);
            }
            set
            {
                this.SetValue<bool>(MenuItem.RadioCheckProperty, value);
            }
        }

        private Shortcut ShortcutInternal
        {
            get
            {
                return this.GetValue<Shortcut>(MenuItem.ShortcutProperty, Shortcut.None);
            }
            set
            {
                this.SetValue<Shortcut>(MenuItem.ShortcutProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
                    if (value == null && base.InternalParent != null)
                    {
                        this.UnregisterShortcut(false);
                    }

                    base.InternalParent = value;

                    if (value != null)
                    {
                        this.RegisterShortcut();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the shortcut.
        /// </summary>
        /// <value></value>
        [DefaultValue(Shortcut.None)]
        public Shortcut Shortcut
        {
            get
            {
                return ShortcutInternal;
            }
            set
            {
                if (ShortcutInternal != value)
                {
                    ShortcutInternal = value;

                    if (!this.DesignMode)
                    {
                        if (value == Shortcut.None)
                        {
                            this.UnregisterShortcut(true);
                        }
                        else
                        {
                            this.RegisterShortcut();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show shortcut.
        /// </summary>
        /// <value><c>true</c> if [show shortcut]; otherwise, <c>false</c>.</value>
        [Localizable(true), SRDescription("MenuItemShowShortCutDescr"), DefaultValue(true)]
        public bool ShowShortcut
        {
            get
            {
                return this.GetValue<bool>(MenuItem.ShowShortcutProperty, true);
            }
            set
            {
                if (value != this.ShowShortcut)
                {
                    if (value != true)
                    {
                        this.SetValue<bool>(MenuItem.ShowShortcutProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(MenuItem.ShowShortcutProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the menu item Text.
        /// </summary>
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Localizable(true)]
        [SRDescription("MenuItemTextDescr")]
        public string Text
        {
            get
            {
                return TextInteranl;
            }
            set
            {
                if (this.TextInteranl != value)
                {
                    this.TextInteranl = value;

                    //If the menu item is one of the Main menu items(and not a context menu item)
                    //if the value has been change we have to repaint the main menu
                    if (this.InternalParent != null && this.InternalParent is MainMenu)
                    {
                        this.InternalParent.Update();
                    }
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether a check mark 
        ///  appears next to the text of the menu item.  
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return this.GetState(ComponentState.Checked);
            }
            set
            {
                this.SetState(ComponentState.Checked, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the MenuItem , if checked, 
        /// displays a radio-button instead of a check mark.  
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool RadioCheck
        {
            get
            {
                return RadioCheckInteranl;
            }
            set
            {
                RadioCheckInteranl = value;
            }
        }

        /// <summary>
        /// Gets or sets the menu icon.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(null)]
        public ResourceHandle Icon
        {
            get
            {
                return IconInteranl;
            }
            set
            {
                IconInteranl = value;
            }
        }

        /// <summary>
        /// Indicated if the menu item is visible.
        /// </summary>
        [DefaultValue(true)]
        [Browsable(false)]
        public bool Visible
        {
            get
            {
                return this.GetState(ComponentState.Visible);
            }
            set
            {
                if (this.SetStateWithCheck(ComponentState.Visible, value))
                {
                    //If the menu item is one of the Main menu items(and not a context menu item)
                    //if the value has been change we have to repaint the main menu
                    if (this.InternalParent != null && this.InternalParent is MainMenu)
                    {
                        this.InternalParent.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MenuItem"/> is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool Enabled
        {
            get
            {
                return this.GetState(ComponentState.Enabled);
            }
            set
            {
                if (this.SetStateWithCheck(ComponentState.Enabled, value))
                {
                    //If the menu item is one of the Main menu items(and not a context menu item)
                    //if the value has been change we have to repaint the main menu
                    if (this.InternalParent != null && this.InternalParent is MainMenu)
                    {
                        this.InternalParent.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the parent menu of this menu item.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public Menu Parent
        {
            get
            {
                return InternalParent as Menu;
            }
        }

        /// <summary>
        /// Gets the parent menu items.
        /// </summary>
        /// <value>The parent menu items.</value>
        private MenuItemCollection ParentMenuItems
        {
            get
            {
                MenuItemCollection objMenuItemCollection = null;

                if (this.InternalParent != null)
                {
                    if (this.InternalParent is MainMenu)
                    {
                        objMenuItemCollection = ((MainMenu)this.InternalParent).MenuItems;
                    }
                    else if (this.InternalParent is Menu)
                    {
                        objMenuItemCollection = ((Menu)this.InternalParent).MenuItems;
                    }
                }

                return objMenuItemCollection;
            }
        }

        /// <summary>
        /// <para> Gets or sets a value indicating the position of the menu item in its parent menu.</para>
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get
            {
                if (this.ParentMenuItems != null)
                {
                    return ((IList)this.ParentMenuItems).IndexOf(this);
                }
                return -1;
            }
            set
            {
                int index = this.Index;
                if (index >= 0)
                {
                    if ((value < 0) || (value >= this.ParentMenuItems.Count))
                    {
                        throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "value", value.ToString() }));
                    }
                    if (value != index)
                    {
                        this.ParentMenuItems.RemoveAt(index);
                        this.ParentMenuItems.Add(value, this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                return this.GetValue<string>(MenuItem.NameProperty, string.Empty);
            }
            set
            {
                this.SetValue<string>(MenuItem.NameProperty, value);
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Invokes when a menu item was clicked
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This event is obsolete")]
        public override event MenuEventHandler MenuClick
        {
            add
            {
                base.MenuClick += value;
            }
            remove
            {
                base.MenuClick -= value;
            }
        }

        /// <summary>
        /// <summary>Occurs when a drag-and-drop operation is completed.</summary>
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This event is obsolete")]
        public override event DragEventHandler DragDrop
        {
            add
            {
                base.DragDrop += value;
            }
            remove
            {
                base.DragDrop -= value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Click
        {
            add
            {
                this.AddHandler(MenuItem.ClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(MenuItem.ClickEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [enter].
        /// </summary>
        public event EventHandler Enter
        {
            add
            {
                this.AddHandler(MenuItem.EnterEvent, value);
            }
            remove
            {
                this.RemoveHandler(MenuItem.EnterEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Click event.
        /// </summary>
        internal EventHandler ClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(MenuItem.ClickEvent);
            }
        }

        /// <summary>
        /// Gets the enter handler.
        /// </summary>
        /// <value>The enter handler.</value>
        private EventHandler EnterHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(MenuItem.EnterEvent);
            }
        }

        #endregion Events
    }

    #endregion

    #region Menu Class

    /// <summary>
    /// Represents the base functionality for all menus. 
    /// </summary>
    [ListBindable(false)]
    [System.ComponentModel.DesignTimeVisible(false)]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItemCategory("Menus & Toolbars")]
    [Skin(typeof(Skins.MenuSkin))]
    [Serializable()]
    public class Menu : Component, IMenu, ISkinable
    {
        #region Classes


        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        internal class MenuForm : Form
        {
            /// <summary>
            /// The PreferdMenuItemIconWidthProperty property registration.
            /// </summary>
            private static readonly SerializableProperty PreferdMenuItemIconWidthProperty = SerializableProperty.Register("PreferdMenuItemIconWidth", typeof(int), typeof(MenuForm));
            private static readonly SerializableProperty PreferdMenuItemLabelWidthProperty = SerializableProperty.Register("PreferdMenuItemLabelWidth", typeof(int), typeof(MenuForm));
            private static readonly SerializableProperty PreferdMenuItemShortCutWidthProperty = SerializableProperty.Register("PreferdMenuItemShortCutWidth", typeof(int), typeof(MenuForm));
            private static readonly SerializableProperty PreferdMenuItemArrowWidthProperty = SerializableProperty.Register("PreferdMenuItemArrowWidth", typeof(int), typeof(MenuForm));
            private static readonly SerializableProperty ShareFocusProperty = SerializableProperty.Register("ShareFocus", typeof(bool), typeof(MenuForm));


            /// <summary>
            /// Gets a value indicating whether animation is enabled by default.
            /// </summary>
            /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
            protected override bool DefaultAnimation
            {
                get
                {
                    return this.AnimationEnabled;
                }
            }

            /// <summary>
            /// Gets or sets the width of the mint preferd menu item icon.
            /// </summary>
            /// <value>The width of the mint preferd menu item icon.</value>
            internal int PreferdMenuItemIconWidthInternal
            {
                get
                {
                    return this.GetValue<int>(MenuForm.PreferdMenuItemIconWidthProperty);
                }
                set
                {
                    this.SetValue<int>(MenuForm.PreferdMenuItemIconWidthProperty, value);
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [share focus].
            /// </summary>
            /// <value><c>true</c> if [share focus]; otherwise, <c>false</c>.</value>
            internal bool ShareFocus
            {
                get
                {
                    return this.GetValue<bool>(MenuForm.ShareFocusProperty);
                }
                set
                {
                    this.SetValue<bool>(MenuForm.ShareFocusProperty, value);
                }
            }

            /// <summary>
            /// Gets or sets the width of the mint preferd menu item label.
            /// </summary>
            /// <value>The width of the mint preferd menu item label.</value>
            internal int PreferdMenuItemLabelWidthInternal
            {
                get
                {
                    return this.GetValue<int>(MenuForm.PreferdMenuItemLabelWidthProperty);
                }
                set
                {
                    this.SetValue<int>(MenuForm.PreferdMenuItemLabelWidthProperty, value);
                }
            }

            /// <summary>
            /// Gets or sets the width of the mint preferd menu item shotr cut.
            /// </summary>
            /// <value>The width of the mint preferd menu item shotr cut.</value>
            internal int PreferdMenuItemShortCutWidthInternal
            {
                get
                {
                    return this.GetValue<int>(MenuForm.PreferdMenuItemShortCutWidthProperty);
                }
                set
                {
                    this.SetValue<int>(MenuForm.PreferdMenuItemShortCutWidthProperty, value);
                }
            }

            /// <summary>
            /// Gets or sets the width of the mint preferd menu item arrow.
            /// </summary>
            /// <value>The width of the mint preferd menu item arrow.</value>
            internal int PreferdMenuItemArrowWidthInternal
            {
                get
                {
                    return this.GetValue<int>(MenuForm.PreferdMenuItemArrowWidthProperty);
                }
                set
                {
                    this.SetValue<int>(MenuForm.PreferdMenuItemArrowWidthProperty, value);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private Menu mobjMenu = null;

            /// <summary>
            /// Gets or sets the owning menu.
            /// </summary>
            /// <value>The owning menu.</value>
            public Menu OwningMenu
            {
                get
                {
                    return mobjMenu;
                }
            }

            /// <summary>
            /// Gets a value indicating whether to reverse control rendering.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
            /// </value>
            protected override bool ReverseControls
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// Renders the forms attribute
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                // Render owner id.
                if (this.OwningMenu != null && this.OwningMenu is MenuItem)
                {
                    if (this.OwningMenu.Owner != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.OwnerID, this.OwningMenu.Owner.ID);
                    }
                }

                // Render share focus attribute.
                if (this.ShareFocus)
                {
                    objWriter.WriteAttributeString(WGAttributes.ShareFocus, "1");
                }

                // Render Label Width
                objWriter.WriteAttributeString(WGAttributes.MenuItemLabelWidth, PreferdMenuItemLabelWidthInternal);

                //Render ShotrCut Width
                if (PreferdMenuItemShortCutWidthInternal > 0)
                {
                    objWriter.WriteAttributeString(WGAttributes.MenuItemShortCutWidth, PreferdMenuItemShortCutWidthInternal);
                }

                //Render Arrow Width (Has to be renderd to the client becous the width is calculated with pedding.)
                if (PreferdMenuItemArrowWidthInternal > 0)
                {
                    objWriter.WriteAttributeString(WGAttributes.MenuItemArrowWidth, PreferdMenuItemArrowWidthInternal);
                }

                base.RenderAttributes(objContext, objWriter);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MenuControl"/> class.
            /// </summary>
            /// <param name="objMenu">The owner menu.</param>
            internal MenuForm(Menu objMenu)
            {
                this.CustomStyle = "Menu";
                mobjMenu = objMenu;

                this.Size = new Size(200, 400);
            }

            /// <summary>
            /// Shows the menu.
            /// </summary>
            /// <param name="objComponent">The obj component.</param>
            /// <param name="objPoint">The obj point.</param>
            /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
            internal void ShowMenu(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment)
            {
                if (this.OwningMenu != null && this.OwningMenu.MenuItems.Count > 0)
                {
                    InitializeMenu(objPoint);
                    this.ShowPopup(objComponent, enmDialogAlignment);
                }
            }

            /// <summary>
            /// Shows the menu.
            /// </summary>
            /// <param name="objClientComponent">The obj client component.</param>
            /// <param name="objPoint">The obj point.</param>
            /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
            internal void ShowMenu(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment)
            {
                if (this.OwningMenu != null && this.OwningMenu.MenuItems.Count > 0)
                {
                    InitializeMenu(objPoint);

                    this.ShowPopup(objSourceComponent, objMemberComponent, enmDialogAlignment);
                }
            }

            /// <summary>
            /// Shows the menu internal.
            /// </summary>
            /// <param name="objPoint">The obj point.</param>
            /// <returns></returns>
            private void InitializeMenu(Point objPoint)
            {
                this.Controls.Clear();
                bool blnIsThisTheFirstItem = true;
                bool blnFoundAnItemWithSubItems = false;
                int intHeight = 0;
                int intWidth = 0;
                MenuItemControl objDisabledMenuItemControl = null;
                MenuItemControl objFirstMenuItemControl = null;

                //go over every item in the menu
                foreach (MenuItem objMenuItem in OwningMenu.MenuItems)
                {
                    //Add the item only if it's visible
                    if (objMenuItem.Visible)
                    {
                        //Create a menu item control from the menu item
                        MenuItemControl objMenuItemControl = new MenuItemControl(objMenuItem);
                        this.Controls.Add(objMenuItemControl);

						// If no disabled menu item found so far, check if current menu item is disabled.
                        if (objDisabledMenuItemControl == null && !objMenuItem.Enabled)
                        {
							// Preserve current menu item.
                            objDisabledMenuItemControl = objMenuItemControl;
                        }

                        //If the MenuItem is no a seperator get the preferd width for the columns
                        if (!objMenuItemControl.IsSeperator)
                        {
                            //if this the first item that we incounter get the icon column width and arrow thay wont change in the the next item.
                            if (blnIsThisTheFirstItem)
                            {
                                objFirstMenuItemControl = objMenuItemControl;

                                this.PreferdMenuItemIconWidthInternal = objMenuItemControl.GetPreferdIconColumnWidth();
                                this.PreferdMenuItemArrowWidthInternal = objMenuItemControl.GetPreferdArrowWidth();
                                blnIsThisTheFirstItem = false;
                            }
                            //If an item was found with sub items we can stop checking if there is need to drow the subitems arrow
                            if (!blnFoundAnItemWithSubItems)
                            {
                                //If the item has subitems
                                if (objMenuItemControl.HasSubItems)
                                {
                                    //found one
                                    blnFoundAnItemWithSubItems = true;
                                }
                            }

                            this.PreferdMenuItemLabelWidthInternal = Math.Max(this.PreferdMenuItemLabelWidthInternal, objMenuItemControl.GetPreferdLableWidth());
                            this.PreferdMenuItemShortCutWidthInternal = Math.Max(this.PreferdMenuItemShortCutWidthInternal, objMenuItemControl.GetPreferdShortCutWidth());
                        }

                        intHeight += objMenuItemControl.Height;
                    }
                }

                //Sum the total menu width
                intWidth = PreferdMenuItemLabelWidthInternal + PreferdMenuItemShortCutWidthInternal + PreferdMenuItemIconWidthInternal;

                // Enable arrow scrolling for lists with more than 5 items
                if (OwningMenu.AutoScrollItemCount >= 0 && OwningMenu.MenuItems.Count > OwningMenu.AutoScrollItemCount)
                {
                    this.AutoScroll = true;
                    this.ScrollerType = Forms.ScrollerType.Arrows;
                }

                // Add to totals the offsets, frames, margins and paddings of containers
                MenuSkin objMenuSkin = SkinFactory.GetSkin(this.mobjMenu) as MenuSkin;
                if (objMenuSkin != null)
                {
                    //Add popup offset to Menu's size
                    intHeight += objMenuSkin.PopupWindowOffsetHeight;
                    intWidth += objMenuSkin.PopupWindowOffsetWidth;
                }

                // Add icon padding values against total width
                if (objFirstMenuItemControl != null)
                {
                    MenuItemSkin objMenuItemSkin = SkinFactory.GetSkin(objFirstMenuItemControl) as MenuItemSkin;
                    if (objMenuItemSkin != null)
                    {
                        intWidth += (this.Context.RightToLeft ?
                            objMenuItemSkin.MenuItemIconPaddingLTR.Left + objMenuItemSkin.MenuItemIconPaddingLTR.Right :
                            objMenuItemSkin.MenuItemIconPaddingRTL.Left + objMenuItemSkin.MenuItemIconPaddingRTL.Right);
                    }
                }

                //If we found an item with sub items add the arrow image width to the menu width
                if (blnFoundAnItemWithSubItems)
                {
                    intWidth += PreferdMenuItemArrowWidthInternal;
                }

                if (intWidth % 2 != 0)
                {
                    intWidth += 1;
                }

				// Check if a disabled menu item was found.
                if (objDisabledMenuItemControl != null)
                {
                    // Try gwtting a menu item skin.
                    MenuItemSkin objMenuItemSkin = SkinFactory.GetSkin(objDisabledMenuItemControl) as MenuItemSkin;
                    if (objMenuItemSkin != null)
                    {
						// Get menu item disabled style.
                        StyleValue objControlDisabledStyle = objMenuItemSkin.ControlDisabledStyle;
                        if (objControlDisabledStyle != null)
                        {
							// Add border width - if style is other then none.
                            if (objControlDisabledStyle.BorderStyle != Forms.BorderStyle.None)
                            {
                                intWidth += (objControlDisabledStyle.BorderWidth.Left + objControlDisabledStyle.BorderWidth.Right);
                            }
                        }
                    }
                }

                //Set calculated size to menu
                this.Size = new Size(intWidth, intHeight);

                if (objPoint != Point.Empty)
                {
                    this.Location = objPoint;

                    this.StartPosition = FormStartPosition.Manual;
                }
            }

            /// <summary>
            /// Gets the critical events.
            /// </summary>
            /// <returns></returns>
            protected override CriticalEventsData GetCriticalEventsData()
            {
                CriticalEventsData objEvents = base.GetCriticalEventsData();

                //Register the closed(form closed)event.
                //So, if the Context Menu Collapse event is on the client will raise the unload event to the server
                if (OwningMenu != null && OwningMenu is ContextMenu && ((ContextMenu)(OwningMenu)).RegisteredCollapseEvent)
                {
                    objEvents.Set(WGEvents.Closed);
                }


                return objEvents;

            }

            /// <summary>
            /// Closes all hierarchic forms.
            /// </summary>
            internal void CloseAll()
            {
                //Close the form 
                this.Close();

                //Get the owner form
                MenuForm objMenuForm = this.Owner as MenuForm;
                if (objMenuForm != null)
                {
                    //Close all forms
                    objMenuForm.CloseAll();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        [MetadataTag(WGTags.MenuItem)]
        [Skin(typeof(Skins.MenuItemSkin))]
        internal class MenuItemControl : Control
        {
            private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register("Shortcut", typeof(Shortcut), typeof(MenuItemControl));

            /// <summary>
            /// 
            /// </summary>
            private MenuItem mobjMenuItem = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="MenuItemControl"/> class.
            /// </summary>
            /// <param name="objMenuItem">The obj menu item.</param>
            internal MenuItemControl(MenuItem objMenuItem)
            {
                mobjMenuItem = objMenuItem;
                this.Text = objMenuItem.Text;
                this.Tag = objMenuItem;
                this.VisualEffect = objMenuItem.VisualEffect;

                int intHeight = 0;

                if (IsSeperator)
                {
                    intHeight = ((MenuItemSkin)this.Skin).SeperatorHeight;
                }
                else
                {
                    intHeight = ((MenuItemSkin)this.Skin).Height;
                }

                if (!objMenuItem.Enabled)
                {
                    // Try gwtting a menu item skin.
                    MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;
                    if (objMenuItemSkin != null)
                    {
                        // Get menu item disabled style.
                        StyleValue objControlDisabledStyle = objMenuItemSkin.ControlDisabledStyle;
                        if (objControlDisabledStyle != null)
                        {
                            // Add border width - if style is other then none.
                            if (objControlDisabledStyle.BorderStyle != Forms.BorderStyle.None)
                            {
                                intHeight += (objControlDisabledStyle.BorderWidth.Top + objControlDisabledStyle.BorderWidth.Bottom);
                            }
                        }
                    }
                }

                this.Height = intHeight;

                if (!this.HasSubItems)
                {
                    this.Click += new EventHandler(MenuItemControl_Click);
                }
            }            

            /// <summary>
            /// Fires an event.
            /// </summary>
            /// <param name="objEvent">event.</param>
            protected override void FireEvent(IEvent objEvent)
            {
                // Select event type
                switch (objEvent.Type)
                {
                    case "Enter":
                        this.OnEnter();
                        break;
                }

                base.FireEvent(objEvent);
            }

            /// <summary>
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                // Render the has nodes attribute - if needed.
                if (mobjMenuItem != null)
                {
                    //Render Text
                    if (!string.IsNullOrEmpty(mobjMenuItem.Text))
                    {
                        objWriter.WriteAttributeText(WGAttributes.Text, mobjMenuItem.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
                    }
                    //Render if the item has a children  menu
                    if (this.HasSubItems)
                    {
                        objWriter.WriteAttributeString(WGAttributes.HasNodes, "1");
                    }


                    //Render if the item is disabled
                    if (!mobjMenuItem.Enabled)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Enabled, "0");
                    }

                    //Render if the item is checked
                    if (mobjMenuItem.Checked)
                    {
                        //If the item is RadioChecked
                        if (mobjMenuItem.RadioCheck)
                        {
                            objWriter.WriteAttributeString(WGAttributes.RadioCheck, "1");
                        }
                        else
                        {
                            objWriter.WriteAttributeString(WGAttributes.Checked, "1");
                        }
                    }


                    //Render if the item has an icon
                    if (mobjMenuItem.Icon != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Icon, mobjMenuItem.Icon.ToString());
                    }

                    //Render if this item is a seperator item
                    if (IsSeperator)
                    {
                        objWriter.WriteAttributeString(WGAttributes.IsSeperator, "1");
                    }

                    //render the items Shortcut if no short cut is selected render 0 so the div will not be renderd
                    if (mobjMenuItem.Shortcut != Shortcut.None)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Shortcut, GetShortcutString());
                    }

                    //Render registerd client invocation if exists
                    RegisteredClientAction objRegisteredClientAction = mobjMenuItem.ClientAction;
                    if (objRegisteredClientAction != null)
                    {
                       objRegisteredClientAction.RenderAttributes((IContextMethodInvoker)objContext, objWriter);
                    }

                    // Render extended component attributes.
                    mobjMenuItem.RenderExtendedComponentAttributes(objContext, objWriter);
                }
                base.RenderAttributes(objContext, objWriter);
            }

            /// <summary>
            /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
            /// event.
            /// </summary>
            /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            protected override void OnClick(EventArgs objEventArgs)
            {
                if (mobjMenuItem == null || mobjMenuItem.MenuItems.Count == 0)
                {
                    //Get the Menu form
                    MenuForm objMenuForm = this.Form as MenuForm;
                    if (objMenuForm != null)
                    {
                        //Close form
                        objMenuForm.CloseAll();
                    }
                    //Fire Menu item click event
                    mobjMenuItem.FireClick();
                }
                base.OnClick(objEventArgs);
            }

            /// <summary>
            /// Raises the <see cref="E:TransitionVisualEffectEnd" /> event.
            /// </summary>
            /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
            protected override void OnTransitionVisualEffectEnd(EventArgs e)
            {
                if (mobjMenuItem != null)
                {
                   mobjMenuItem.OnTransitionVisualEffectEnd(new EventArgs());
                }
            }


            /// <summary>
            /// Handles the Enter event of the MenuItemControl control.
            /// </summary>
            private void OnEnter()
            {
                // Show submenu form.
                this.ShowSubMenu(this.Tag as MenuItem);
            }

            /// <summary>
            /// Gets/Sets the controls docking style
            /// </summary>
            /// <value></value>
            public override DockStyle Dock
            {
                get
                {
                    return DockStyle.Top;
                }
                set
                {
                    base.Dock = value;
                }
            }

            /// <summary>
            /// Handles the Click event of the MenuItemControl control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            void MenuItemControl_Click(object sender, EventArgs e)
            {
                Button objButton = sender as Button;
                if (objButton != null && this.Form != null)
                {
                    MenuItem objMenuItem = objButton.Tag as MenuItem;
                    if (objMenuItem != null)
                    {
                        if (this.HasSubItems)
                        {
                            // Show submenu form.
                            this.ShowSubMenu(objMenuItem);
                        }
                        else
                        {
                            //Fire Click Event
                            OnClick(new EventArgs());
                        }
                    }
                }
            }

            /// <summary>
            /// Shows the sub menu.
            /// </summary>
            /// <param name="objMenuItem">The obj menu item.</param>
            private void ShowSubMenu(MenuItem objMenuItem)
            {
                // Check that the recievd menu has sub menu items.
                if (this.HasSubItems)
                {
                    // Show submenu form.
                    objMenuItem.Show(this, Point.Empty, this.Context.RightToLeft ? DialogAlignment.Left : DialogAlignment.Right, true);
                }
            }

            /// <summary>
            /// Fires the click.
            /// </summary>
            /// <param name="objMenuItem">The obj menu item.</param>
            internal void FireClick(MenuItem objMenuItem)
            {
                if (mobjMenuItem != null)
                {
                    Menu objMenuParent = mobjMenuItem.Parent;
                    if (objMenuParent != null)
                    {
                        objMenuParent.FireClick(objMenuItem);
                    }
                    else
                    {
                        Component objComponentParent = mobjMenuItem.InternalParent;
                        if (objComponentParent != null)
                        {
                            objComponentParent.FireMenuClick(objMenuItem);
                        }
                    }
                }
            }

            /// <summary>
            /// Gets a value indicating whether this instance is seperator.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is seperator; otherwise, <c>false</c>.
            /// </value>
            internal bool IsSeperator
            {
                get
                {
                    if (mobjMenuItem.Text == "-")
                    {
                        return true;
                    }
                    return false;
                }
            }


            /// <summary>
            /// Gets a value indicating whether this instance has sub items.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance has sub items; otherwise, <c>false</c>.
            /// </value>
            internal bool HasSubItems
            {
                get
                {
                    if (mobjMenuItem != null && mobjMenuItem.MenuItems.Count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

            public Shortcut Shortcut
            {
                get
                {
                    return this.GetValue<Gizmox.WebGUI.Forms.Shortcut>(MenuItemControl.ShortcutProperty);
                }
                set
                {
                    if (this.Shortcut != value)
                    {

                        // update text value
                        this.SetValue<Gizmox.WebGUI.Forms.Shortcut>(MenuItemControl.ShortcutProperty, value);

                    }
                }
            }

            /// <summary>
            /// Gets the shortcut string.
            /// </summary>
            /// <returns></returns>
            private string GetShortcutString()
            {
                TypeConverter objTypeConverter = TypeDescriptor.GetConverter(typeof(Keys));
                if (objTypeConverter != null)
                {
                    return objTypeConverter.ConvertToString((Keys)mobjMenuItem.Shortcut);
                }
                return Shortcut.ToString();
            }

            #region Methods

            /// <summary>
            /// Gets the width of the preferd lable.
            /// </summary>
            /// <returns></returns>
            internal int GetPreferdLableWidth()
            {
                //If no text dont calculate the length of the text
                if (string.IsNullOrEmpty(this.Text))
                {
                    return 0;
                }

                //Get the current skin
                MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;
                if (objMenuItemSkin != null)
                {
                    if (this.Font != null)
                    {
                        //Get the current style value from the noraml item skin value
                        StyleValue objStyleValue = (StyleValue)((BidirectionalSkinValue<StyleValue>)objMenuItemSkin.MenuItemLabelNormalStyle).GetObject(this.Context);
                        int intPaddingOffset = 0;
                        if (objStyleValue != null)
                        {
                            //sum the item padding offset of left and right
                            intPaddingOffset = objStyleValue.Padding.Left + objStyleValue.Padding.Right;
                        }
                        //Return the calculated string mesument and the font size with the item width offset 
                        return CommonUtils.GetStringMeasurements(this.Text, this.Font, true).Width + intPaddingOffset;
                    }
                }
                return this.Text.Length * 10;

            }


            /// <summary>
            /// Gets the font of the text displayed by the control.
            /// </summary>
            /// <value></value>
            public override Font Font
            {
                get
                {
                    //Get the current skin
                    MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;
                    Font objFont = base.Font;

                    if (objMenuItemSkin != null)
                    {
                        //Get the menu item normal StyleValue
                        StyleValue objSkinValue = (StyleValue)((BidirectionalSkinValue<StyleValue>)objMenuItemSkin.MenuItemNormalCenter).GetObject(this.Context);
                        if (objSkinValue != null)
                        {
                            //Set the normal item font
                            objFont = objSkinValue.Font;
                        }
                    }

                    return objFont;
                }
            }
            /// <summary>
            /// Gets the width of the preferd short cut.
            /// </summary>
            /// <returns></returns>
            internal int GetPreferdShortCutWidth()
            {
                //If this item has a short cut return the shortcut size else return 0
                if (mobjMenuItem.Shortcut == Shortcut.None)
                {
                    return 0;
                }
                else
                {
                    string strShortcut = GetShortcutString();
                    //Get the current skin
                    MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;
                    if (objMenuItemSkin != null)
                    {
                        if (this.Font != null)
                        {
                            //Get the current style value from the noraml item skin value
                            StyleValue objStyleValue = (StyleValue)((BidirectionalSkinValue<StyleValue>)objMenuItemSkin.MenuItemLabelNormalStyle).GetObject(this.Context);
                            int intPaddingOffset = 0;
                            if (objStyleValue != null)
                            {
                                //sum the item padding offset of left and right
                                intPaddingOffset = objStyleValue.Padding.Left + objStyleValue.Padding.Right;
                            }
                            //Return the calculated string mesument and the font size with the item width offset


                            return CommonUtils.GetStringMeasurements(strShortcut, this.Font, true).Width + intPaddingOffset;
                        }
                    }
                    return strShortcut.Length * 10;
                }
            }

            /// <summary>
            /// Gets the width of the preferd arrow.
            /// </summary>
            /// <returns></returns>
            internal int GetPreferdArrowWidth()
            {
                //Get the current skin
                MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;

                //If the skin exists
                if (objMenuItemSkin != null)
                {
                    // Get the arrow icon padding value
                    PaddingValue objPaddingValue = (PaddingValue)((BidirectionalSkinValue<PaddingValue>)objMenuItemSkin.MenuItemArrowPadding).GetObject(this.Context);
                    int intPaddingOffset = 0;

                    //If we go an objPaddingValue sum the offset width of the icon
                    if (objPaddingValue != null)
                    {
                        intPaddingOffset = objPaddingValue.Left + objPaddingValue.Right;
                    }

                    string strSkinValue = ((BidirectionalSkinValue<int>)objMenuItemSkin.ArrowImageWidth).GetValue(this.Context);
                    return int.Parse(strSkinValue) + intPaddingOffset;

                }
                return 0;
            }

            /// <summary>
            /// Gets the width of the preferd icon column.
            /// </summary>
            /// <returns></returns>
            internal int GetPreferdIconColumnWidth()
            {
                //Get the current skin
                MenuItemSkin objMenuItemSkin = this.Skin as MenuItemSkin;

                if (objMenuItemSkin != null)
                {
                    return objMenuItemSkin.MenuItemIconsColumnWidth;
                }

                return 0;
            }

            #endregion
        }

        #endregion

        #region Members

        #region Static Members

        /// <summary>
        /// The Collapse event registration.
        /// </summary>
        private static readonly SerializableEvent CollapseEvent = SerializableEvent.Register("Collapse", typeof(EventHandler), typeof(Menu));

        /// <summary>
        /// The Popup event registration.
        /// </summary>
        private static readonly SerializableEvent PopupEvent = SerializableEvent.Register("Popup", typeof(EventHandler), typeof(Menu));

        /// <summary>
        /// The ItemsInternal property registration.
        /// </summary>
        private static readonly SerializableProperty ItemsProperty = SerializableProperty.Register("Items", typeof(MenuItemCollection), typeof(Menu));

        /// <summary>
        /// The IsRegisteredInternal property registration.
        /// </summary>
        private static readonly SerializableProperty IsRegisteredProperty = SerializableProperty.Register("IsRegistered", typeof(bool), typeof(Menu));

        /// <summary>
        /// The ReferenceCountInteranl property registration.
        /// </summary>
        private static readonly SerializableProperty ReferenceCountProperty = SerializableProperty.Register("ReferenceCount", typeof(int), typeof(Menu));

        /// <summary>
        /// The Owner property registration.
        /// </summary>
        private static readonly SerializableProperty OwnerProperty = SerializableProperty.Register("Owner", typeof(Component), typeof(Menu));

        /// <summary>
        /// The Member property registration.
        /// </summary>
        private static readonly SerializableProperty MemberProperty = SerializableProperty.Register("Member", typeof(IIdentifiedComponent), typeof(Menu));

        /// <summary>
        /// The ScrollerForItemcountExceedin property registration.
        /// </summary>
        private static readonly SerializableProperty AutoScrollItemCountProperty = SerializableProperty.Register("AutoScrollItemCount", typeof(int), typeof(Menu));

        #endregion

        #endregion

        #region Events Related

        /// <summary>Occurs when the shortcut menu collapses.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ContextMenuCollapseDescr")]
        public event EventHandler Collapse
        {
            add
            {
                this.AddHandler(Menu.CollapseEvent, value);
            }
            remove
            {
                this.RemoveHandler(Menu.CollapseEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Collapse event.
        /// </summary>
        private EventHandler CollapseHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Menu.CollapseEvent);
            }
        }


        /// <summary>Occurs before the shortcut menu is displayed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("MenuItemOnInitDescr")]
        public event EventHandler Popup
        {
            add
            {
                this.AddHandler(Menu.PopupEvent, value);
            }
            remove
            {
                this.RemoveHandler(Menu.PopupEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Popup event.
        /// </summary>
        private EventHandler PopupHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Menu.PopupEvent);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the shortcut menu at the specified position and with the specified alignment.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public void Show(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment)
        {
            ShowInternal(objComponent, null, objPoint, enmDialogAlignment, null);

        }

        

        /// <summary>
        /// Shows the specified obj component.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
        /// <param name="blnShareFocus">if set to <c>true</c> [BLN share focus].</param>
        public void Show(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment, bool blnShareFocus)
        {
            ShowInternal(objComponent, null, objPoint, enmDialogAlignment, blnShareFocus);
        }

        /// <summary>
        /// Displays the shortcut menu at the specified position and with the specified alignment.
        /// </summary>
        /// <param name="objSourceComponent">The obj source component.</param>
        /// <param name="objMemberComponent">The obj member component.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public void Show(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment)
        {
            ShowInternal(objSourceComponent, objMemberComponent, objPoint, enmDialogAlignment, null);
        }

        /// <summary>
        /// Displays the shortcut menu at the specified position.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objPoint">The obj point.</param>
        public void Show(Component objComponent, Point objPoint)
        {
            this.Show(objComponent, objPoint, DialogAlignment.Custom);
        }

        /// <summary>
        /// Displays the shortcut menu at the specified position and with the specified alignment.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
        [Obsolete("LeftRightAlignment is not suported yet")]
        public void Show(Component objComponent, Point objPoint, LeftRightAlignment enmLeftRightAlignment)
        {
            this.Show(objComponent, objPoint, DialogAlignment.Custom);
        }

        /// <summary>
        /// Shows the specified obj source component.
        /// </summary>
        /// <param name="objSourceComponent">The obj source component.</param>
        /// <param name="objMemberComponent">The obj member component.</param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
        [Obsolete("LeftRightAlignment is not suported yet")]
        public void Show(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, LeftRightAlignment enmLeftRightAlignment)
        {
            ShowInternal(objSourceComponent, objMemberComponent, objPoint, DialogAlignment.Custom, null);
        }

        /// <summary>
        /// private function to deal with all the common code of the Show function.
        /// </summary>
        /// <param name="objComponent">>The obj component.</param>
        /// <param name="objMemberComponent"></param>
        /// <param name="objPoint">The obj point.</param>
        /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
        private void ShowInternal(Component objComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment, bool? blnShareFocus)
        {
            //getting the menuform for this menu
            MenuForm objMenuForm = this.MappedMenuForm;

            //checking the object owner not null
            if (objComponent != null)
            {
                //setting the object owner
                this.Owner = objComponent;
            }

            //checking the member not null
            if (objMemberComponent != null)
            {
                this.Member = objMemberComponent;
            }

            if (blnShareFocus != null)
            {
                //setting its focus
                objMenuForm.ShareFocus = (bool)blnShareFocus;
            }

            // Raise the popup event
            this.OnPopup(EventArgs.Empty);

            //showing the menu
            if (objMemberComponent != null)
            {
                objMenuForm.ShowMenu(objComponent, objMemberComponent, objPoint, enmDialogAlignment);
            }
            else
            {
                objMenuForm.ShowMenu(objComponent, objPoint, enmDialogAlignment);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Popup" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnPopup(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.PopupHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        #region IMenu Members

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <value>The menu items.</value>
        ICollection IMenu.MenuItems
        {
            get { return this.MenuItems; }
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <value>The parent.</value>
        IComponent IMenu.Parent
        {
            get { return this.InternalParent; }
        }


        #endregion


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

        #endregion

        #region Properties

        #region Skinning Related

        /// <summary>
        /// The skin of the current menu
        /// </summary>
        [NonSerialized()]
        private MenuSkin mobjSkin = null;


        /// <summary>
        /// Gets the skin of the current menu.
        /// </summary>
        /// <value>The skin of the current menu.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        protected MenuSkin Skin
        {
            get
            {
                // If skin was not yet registered
                if (mobjSkin == null)
                {
                    // Register menu for skinning
                    mobjSkin = (MenuSkin)SkinFactory.GetSkin(this);
                }
                return mobjSkin;
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>The theme related to the skinable component.</value>
        string ISkinable.Theme
        {
            get
            {
                return this.Context.CurrentTheme;
            }
        }

        #endregion

        #region Hidden Properties

        /// <summary>
        /// Gets or sets the context menu code.
        /// </summary>
        /// <value></value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ContextMenu ContextMenu
        {
            get
            {
                return base.ContextMenu;
            }
            set
            {
                base.ContextMenu = value;
            }
        }

        #endregion

        /// <summary>
        /// Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)
        /// </summary>
        /// <value>Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never).</value>
        [DefaultValue(10)]
        [SRDescription("Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)"), Localizable(true), SRCategory("Misc")]
        public int AutoScrollItemCount
        {
            get
            {
                return this.GetValue<int>(Menu.AutoScrollItemCountProperty, 10);
            }
            set
            {
                this.SetValue<int>(Menu.AutoScrollItemCountProperty, value);
            }
        }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <value>The menu items.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [ListBindable(false)]
        [Browsable(false)]
        public MenuItemCollection MenuItems
        {
            get
            {
                // Get existing menu item collection
                MenuItemCollection objItems = this.GetValue<MenuItemCollection>(Menu.ItemsProperty, null);
                if (objItems == null)
                {
                    // Get new menu items collection
                    objItems = new MenuItemCollection(this);

                    // Set the items 
                    this.SetValue<MenuItemCollection>(Menu.ItemsProperty, objItems);
                }

                return objItems;
            }
        }


        /// <summary>
        /// Gets the mapped menu form.
        /// </summary>
        /// <value>The mapped menu form.</value>
        private MenuForm MappedMenuForm
        {
            get
            {
                // Create new menu form
                MenuForm objMenuForm = new MenuForm(this);

                // Check if this menu is a context menu which is registered to the collapsed event.
                if (this is ContextMenu && ((ContextMenu)this).RegisteredCollapseEvent)
                {
                    // Register the menu form's closed event.
                    objMenuForm.Closed += new EventHandler(objMenuControl_Closed);
                }

                // Return the menu form
                return objMenuForm;
            }
        }

        /// <summary>
        /// Handles the Closed event of the objMenuControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void objMenuControl_Closed(object sender, EventArgs e)
        {
            if (this is ContextMenu)
            {
                ((ContextMenu)this).OnCollapse(new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets the owner control.
        /// </summary>
        /// <value>The owner control.</value>
        internal Component Owner
        {
            get
            {
                return this.GetValue<Component>(Menu.OwnerProperty, null);
            }
            set
            {
                if (value != this.Owner)
                {
                    this.SetValue<Component>(Menu.OwnerProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        /// <value>The member.</value>
        internal IIdentifiedComponent Member
        {
            get
            {
                return this.GetValue<IIdentifiedComponent>(Menu.MemberProperty, null);
            }
            set
            {
                if (value != this.Member)
                {
                    this.SetValue<IIdentifiedComponent>(Menu.MemberProperty, value);
                }
            }
        }


        #endregion

        /// <summary>
        /// Fires the click.
        /// </summary>
        /// <param name="objMenuItem">The menu item.</param>
        protected internal void FireClick(MenuItem objMenuItem)
        {
            MenuItemControl objMenuItemControl = this.Owner as MenuItemControl;
            if (objMenuItemControl != null)
            {
                if (objMenuItemControl.Form is MenuForm)
                {
                    objMenuItemControl.Form.Close();
                }
                objMenuItemControl.FireClick(objMenuItem);
            }
            else
            {
                Component objComponent = this.Owner;
                if (objComponent != null)
                {
                    objComponent.FireMenuClick(objMenuItem, this.Member);
                }
            }
        }

        /// <summary>
        /// Invokes when a menu item was clicked
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This event is obsolete")]
        public override event MenuEventHandler MenuClick
        {
            add
            {
                base.MenuClick += value;
            }
            remove
            {
                base.MenuClick -= value;
            }
        }

        /// <summary>
        /// <summary>Occurs when a drag-and-drop operation is completed.</summary>
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This event is obsolete")]
        public override event DragEventHandler DragDrop
        {
            add
            {
                base.DragDrop += value;
            }
            remove
            {
                base.DragDrop -= value;
            }
        }
    }

    #endregion

    #region MenuItemColletction

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class MenuItemCollection : ICollection, IEnumerable, IList, INotifyCollectionChanged
    {

        private ArrayList mobjMenus = null;
        private Component mobjParent = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemCollection"/> class.
        /// </summary>
        /// <param name="objParent">The obj parent.</param>
        public MenuItemCollection(Component objParent)
        {
            mobjMenus = new ArrayList();
            mobjParent = objParent;
        }

        /// <summary>
        /// <para>Removes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> from the menu
        /// item collection at a specified index.</para>
        /// </summary>
        /// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to remove.</param>
        public virtual void RemoveAt(int index)
        {
            if (mobjMenus != null)
            {
                this.Remove(mobjMenus[index] as MenuItem);
            }
        }

        /// <summary>
        /// <para>Adds a previously created <see cref="T:Gizmox.WebGUI.Forms.MenuItem" />
        /// at the
        /// specified index within the menu item collection.</para>
        /// </summary>
        /// <param name="index">The position to add the new item.</param>
        /// <param name="objItem">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> to add.</param>
        /// <returns>
        /// <para>The zero-based index where the item is stored in the collection.</para>
        /// </returns>
        /// <exception cref="T:System.Exception">The <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> being added is already in use.</exception>
        /// <exception cref="T:System.ArgumentException">The index supplied in the <paramref name="index" /> parameter is larger than the size of the collection.</exception>
        public virtual int Add(int index, MenuItem objItem)
        {
            if (mobjMenus != null)
            {
                mobjMenus.Insert(index, objItem);
                return index;
            }

            return -1;
        }

        /// <summary>
        /// Adds a previously created MenuItem to the end of the current menu.
        /// </summary>
        /// <param name="objMenuItem">The MenuItem to add.</param>
        /// <returns>The zero-based index where the item is stored in the collection.</returns>
        public int Add(MenuItem objMenuItem)
        {
            objMenuItem.InternalParent = mobjParent;
            mobjParent.Update();


            int intIndex = mobjMenus.Add(objMenuItem);

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, objMenuItem));
            }

            return intIndex;
        }

        /// <summary>
        /// Adds a new MenuItem to the end of the current menu with a specified caption and a specified event handler for the Click event.
        /// </summary>
        /// <param name="strCaption">The caption of the menu item.</param>
        /// <param name="objOnClick">An EventHandler that represents the event handler that is called when the item is clicked by the user, or when a user presses an accelerator or shortcut key for the menu item.</param>
        /// <returns>A MenuItem that represents the menu item being added to the collection.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MenuItem Add(string strCaption, EventHandler objOnClick)
        {
            // Create new item from given parameters
            MenuItem objItem = new MenuItem(strCaption, objOnClick);

            // Add it to this
            this.Add(objItem);

            // Return the item
            return objItem;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="arrMenuItems">The obj menu items.</param>
        public void AddRange(MenuItem[] arrMenuItems)
        {
            //Initialize the index sorted mennu array.
            MenuItem[] arrMenuItems2 = new MenuItem[arrMenuItems.Length];

            // Flag that all menu items has index.
            bool blnHasIndexes = true;

            foreach (MenuItem objMenuItem in arrMenuItems)
            {
                if (blnHasIndexes &&
                    objMenuItem.Index >= 0 &&
                    objMenuItem.Index < arrMenuItems2.Length)
                {
                    // Position the handled menu item in the right location in the menus array.
                    arrMenuItems2[objMenuItem.Index] = objMenuItem;
                }
                else
                {
                    // Flag that one of the menu items has no index.
                    blnHasIndexes = false;

                    // Add the handled menu item to the class member - array list.
                    Add(objMenuItem);
                }
            }

            // Check if all menu items has indexes.
            if (blnHasIndexes)
            {
                // Run over the index sorted menu array.
                for (int intMenuIndex = 0; intMenuIndex < arrMenuItems2.Length; intMenuIndex++)
                {
                    // Add the handled menu item to the class member - array list.
                    Add(arrMenuItems2[intMenuIndex]);
                }
            }
        }

        /// <summary>
        /// Determines whether [contains] [the specified obj menu item].
        /// </summary>
        /// <param name="objMenuItem">The obj menu item.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified obj menu item]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(MenuItem objMenuItem)
        {
            return mobjMenus.Contains(objMenuItem);
        }

        internal void AttachedToDOM()
        {
            foreach (MenuItem objMenuItem in mobjMenus)
            {
                objMenuItem.AttachedToDOM();
            }
        }

        internal void RemovingFromDOM()
        {
            foreach (MenuItem objMenuItem in mobjMenus)
            {
                objMenuItem.RemovingFromDOM();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objMenuItem"></param>
        public void Remove(MenuItem objMenuItem)
        {
            if (objMenuItem.InternalParent == mobjParent)
            {
                if (mobjParent != null)
                {
                    ((Gizmox.WebGUI.Common.Interfaces.IRegisteredComponent)mobjParent).UnregisterContextMenu();
                    objMenuItem.InternalParent = null;
                }
            }

            mobjMenus.Remove(objMenuItem);
            mobjParent.Update();

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, objMenuItem));
            }

        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IList"/> is read-only.
        /// </exception>
        public void Clear()
        {
            mobjMenus.Clear();
            mobjParent.Update();

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }

        }

        /// <summary>
        /// Gets the menu item count.
        /// </summary>
        /// <value></value>
        public int Count
        {
            get
            {
                return mobjMenus.Count;
            }
        }

        #region IEnumerable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return mobjMenus.GetEnumerator();
        }

        #endregion

        #region IList Members

        bool System.Collections.IList.IsReadOnly
        {
            get
            {
                return mobjMenus.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets the <see cref="Gizmox.WebGUI.Forms.MenuItem"/> at the specified index.
        /// </summary>
        /// <value></value>
        public MenuItem this[int index]
        {
            get
            {
                return (MenuItem)mobjMenus[index];
            }
        }

        object System.Collections.IList.this[int index]
        {
            get
            {
                return mobjMenus[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            mobjMenus.RemoveAt(index);
        }

        void System.Collections.IList.Insert(int index, object objValue)
        {
            throw new NotSupportedException();

        }

        void System.Collections.IList.Remove(object objValue)
        {
            this.Remove((MenuItem)objValue);
        }

        bool System.Collections.IList.Contains(object objValue)
        {
            return this.Contains((MenuItem)objValue);
        }

        void System.Collections.IList.Clear()
        {
            mobjMenus.Clear();
        }

        int System.Collections.IList.IndexOf(object objValue)
        {
            return mobjMenus.IndexOf(objValue);
        }

        int System.Collections.IList.Add(object objValue)
        {
            if (objValue is MenuItem)
            {
                this.Add((MenuItem)objValue);
                return mobjMenus.IndexOf((MenuItem)objValue);
            }
            throw new ArgumentException("value");

        }

        bool System.Collections.IList.IsFixedSize
        {
            get
            {
                return mobjMenus.IsFixedSize;
            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.
        /// </returns>
        public bool IsSynchronized
        {
            get
            {
                return mobjMenus.IsSynchronized;
            }
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="objArray">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is less than zero.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="objArray"/> is multidimensional.
        /// -or-
        /// <paramref name="index"/> is equal to or greater than the length of <paramref name="array"/>.
        /// -or-
        /// The number of elements in the source <see cref="T:System.Collections.ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The type of the source <see cref="T:System.Collections.ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(Array objArray, int index)
        {
            mobjMenus.CopyTo(objArray, index);
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public object SyncRoot
        {
            get
            {
                return mobjMenus.SyncRoot;
            }
        }

        #endregion

        #region INotifyCollectionChanged Members

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion INotifyCollectionChanged Members
    }

    #endregion

    #region MenuCollection

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class MenuCollection : Component, IEnumerable
    {

        private ArrayList mobjMenus = null;

        internal MenuCollection(Component objParent)
        {
            mobjMenus = new ArrayList();
            InternalParent = objParent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objMenu"></param>
        /// <returns></returns>
        public int Add(Menu objMenu)
        {
            objMenu.InternalParent = InternalParent;
            Update();
            return mobjMenus.Add(objMenu);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objMenu"></param>
        public void Remove(Menu objMenu)
        {
            if (objMenu.InternalParent == InternalParent)
            {
                this.UnRegisterComponent(objMenu);
                objMenu.InternalParent = null;
            }
            mobjMenus.Remove(objMenu);
            Update();
        }




        #region IEnumerable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return mobjMenus.GetEnumerator();
        }

        #endregion
    }

    #endregion

    #region MenuItemEvent/MenuEventHandler Class

    /// <summary>
    /// Handles menu item events
    /// </summary>
    public delegate void MenuEventHandler(object objSource, MenuItemEventArgs objArgs);

    /// <summary>
    /// Menu item event arguments
    /// </summary>
    [Serializable()]
    public class MenuItemEventArgs : EventArgs
    {
        /// <summary>
        /// Menu Item
        /// </summary>
        public readonly MenuItem MenuItem;

        /// <summary>
        /// 
        /// </summary>
        public readonly Component Source;

        /// <summary>
        /// 
        /// </summary>
        public readonly IIdentifiedComponent Member;

        /// <summary>
        /// Creates a new <see cref="MenuItemEventArgs"/> instance.
        /// </summary>
        /// <param name="objMenuItem">menu item.</param>
        /// <param name="objSource">The obj source.</param>
        public MenuItemEventArgs(MenuItem objMenuItem, Component objSource)
        {
            MenuItem = objMenuItem;
            Source = objSource;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemEventArgs"/> class.
        /// </summary>
        /// <param name="objMenuItem">The obj menu item.</param>
        /// <param name="objSource">The obj source.</param>
        /// <param name="objMember">The obj member.</param>
        public MenuItemEventArgs(MenuItem objMenuItem, Component objSource, IIdentifiedComponent objMember)
            : this(objMenuItem, objSource)
        {
            Member = objMember;
        }
    }

    #endregion
}
