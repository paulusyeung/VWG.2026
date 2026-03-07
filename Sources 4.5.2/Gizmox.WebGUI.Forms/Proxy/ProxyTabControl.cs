using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Proxy TabControl
    /// </summary>
    [Serializable(), ToolboxItem(false)]
    public class ProxyTabControl : ProxyControl, IProxyNavigationControl, INavigationControl
    {
        #region Members

        /// <summary>
        /// The object proxy tab pages
        /// </summary>
        [NonSerialized]
        ProxyTabPageCollection objProxyTabPages;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabControl" /> class.
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="objParent">The obj parent.</param>
        /// <param name="blnStateComponent">if set to <c>true</c> [BLN state component].</param>
        public ProxyTabControl(Component objComponent, ProxyComponent objParent, bool blnStateComponent)
            : base(objComponent, objParent, blnStateComponent)
        {

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabControl"/> class.
        /// </summary>
        public ProxyTabControl()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:SourceComponentFireEvent"/> event.
        /// </summary>
        /// <param name="objFireEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyFireEventArgs"/> instance containing the event data.</param>
        internal override void OnSourceComponentFireEvent(ProxyFireEventArgs objFireEventArgs)
        {
            base.OnSourceComponentFireEvent(objFireEventArgs);

            // NOTE: We want to allow the state "ValueChange" in tab control..
            if (objFireEventArgs.Event.Type == "ValueChange")
            {
                objFireEventArgs.AllowEvent = true;
            }            
        }

        /// <summary>
        /// Gets the proxy component property owner.
        /// </summary>
        /// <param name="objPropertyDescriptor"></param>
        /// <returns></returns>
        protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "TabPages")
            {
                return this;
            }

            return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
        }

        /// <summary>
        /// Gets the proxy component properties.
        /// </summary>
        /// <param name="arrAttributes">The arr attributes.</param>
        /// <returns></returns>
        protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = base.GetProxyComponentProperties(arrAttributes);
            if (!this.IsStateComponent)
            {
                System.ComponentModel.PropertyDescriptorCollection objPropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(this, arrAttributes, true);

                //Get property descriptor for current property
                System.ComponentModel.PropertyDescriptor objPropertyDescriptor = objPropertyDescriptorCollection["TabPages"];

                objCollection.Add(objPropertyDescriptor);
            }

            return objCollection;
        }

        /// <summary>
        /// Renders the specified obj context.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = objProxyComponent;
                }
            }

            base.Render(objContext, objWriter, lngRequestID);

            foreach (ProxyComponent objProxyComponent in this.Components)
            {
                Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objSourceComponent.ProxyComponent = null;
                }
            }
        }

        /// <summary>
        /// For EMS editing purposes
        /// </summary>
        /// <value>
        /// The tab pages.
        /// </value>
#if WG_NET46
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET452
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET451
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET45
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET40
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET35
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=3.5.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#elif WG_NET2
        [WebEditor("Gizmox.WebGUI.Forms.Design.EmulatorCollectionEditor, Gizmox.WebGUI.Emulation, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d", typeof(WebUITypeEditor))]
#endif
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProxyTabPageCollection TabPages
        {
            get
            {
                if (objProxyTabPages == null)
                {
                    objProxyTabPages = new ProxyTabPageCollection(this);
                }

                return objProxyTabPages;
            }
        }

        /// <summary>
        /// Happens after the load of the component from XAML.
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();

            if (!this.IsStateComponent)
            {
                // Because this is not a "state" TabControl, we need to insert all the TabPages by hand.
                TabControl objTabControl = (this.SourceComponent as TabControl);
                if (objTabControl != null)
                {
                    foreach (ProxyComponent objProxyComponent in this.Components)
                    {
                        TabPage objTabPage = objProxyComponent.SourceComponent as TabPage;

                        if (objTabPage != null && !objTabControl.TabPages.Contains(objTabPage))
                        {
                            objTabControl.TabPages.Add(objTabPage);
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException(string.Format("this.SourceComponent is null or not a TabControl. Type is {0}", this.SourceComponent == null ? "null" : this.SourceComponent.GetType().Name));
                }
            }
        }

        /// <summary>
        /// Gets the proxy property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objDefaultValue">The obj default value.</param>
        /// <returns></returns>
        public override T GetProxyPropertyValue<T>(string strPropertyName, T objDefaultValue)
        {
            if (strPropertyName == "TabPages")
            {
                //this.TabPages
                List<TabPage> objTabPageCollection = new List<TabPage>();
                foreach (ProxyTabPage objProxyTabPage in this.TabPages)
	            {
                    TabPage objTabPage = objProxyTabPage.SourceComponent as TabPage;
                    if (objTabPage != null)
                    {
                        objTabPageCollection.Add(objTabPage);
                    }
	            }

                object objResult = objTabPageCollection;
                return (T)objResult;

            }

            return base.GetProxyPropertyValue<T>(strPropertyName, objDefaultValue);
        }

        private INavigationControl TabControl
        {
            get
            {
                return this.SourceComponent as INavigationControl;
            }
        }

        ProxyControl IProxyNavigationControl.AddNew()
        {
            ProxyTabPage objProxyTabPage = new ProxyTabPage();
            TabPages.Add(objProxyTabPage);

            return objProxyTabPage;
        }

        void IProxyNavigationControl.RemoveCurrent()
        {
            TabPages.RemoveAt(this.TabControl.SelectedIndex);
        }

        /// <summary>
        /// The count change event handler
        /// </summary>
        private EventHandler mobjCountChangeEventHandler = null;

        /// <summary>
        /// Occurs when count change.
        /// </summary>
        event EventHandler IProxyNavigationControl.CountChange
        {
            add
            {
                RegisterCollectionChange(true);
                mobjCountChangeEventHandler += value;
            }
            remove
            {
                mobjCountChangeEventHandler -= value;
                RegisterCollectionChange(false);
            }
        }

        /// <summary>
        /// Registers the collection change.
        /// </summary>
        /// <param name="blnRegister">if set to <c>true</c> [BLN register].</param>
        private void RegisterCollectionChange(bool blnRegister)
        {
            if (blnRegister)
            {
                if (mobjCountChangeEventHandler == null)
                {
                    TabControl objTabControl = this.SourceComponent as TabControl;
                    if (objTabControl != null)
                    {
                        Gizmox.WebGUI.Forms.Control.ControlCollection objControlCollection = objTabControl.Controls;

                        if (objControlCollection != null)
                        {
                            objControlCollection.ObservableItemAdded += Controls_ObservableItemAdded;
                            objControlCollection.ObservableItemInserted += Controls_ObservableItemInserted;
                            objControlCollection.ObservableItemRemoved += Controls_ObservableItemRemoved;
                            objControlCollection.ObservableListCleared += Controls_ObservableListCleared;
                        }
                    }
                }
            }
            else
            {
                if (mobjCountChangeEventHandler == null)
                {
                    TabControl objTabControl = this.SourceComponent as TabControl;
                    if (objTabControl != null)
                    {
                        Gizmox.WebGUI.Forms.Control.ControlCollection objControlCollection = objTabControl.Controls;

                        if (objControlCollection != null)
                        {
                            objControlCollection.ObservableItemAdded -= Controls_ObservableItemAdded;
                            objControlCollection.ObservableItemInserted -= Controls_ObservableItemInserted;
                            objControlCollection.ObservableItemRemoved -= Controls_ObservableItemRemoved;
                            objControlCollection.ObservableListCleared -= Controls_ObservableListCleared;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the ObservableListCleared event of the Controls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Controls_ObservableListCleared(object sender, EventArgs e)
        {
            OnCountChange(new EventArgs());
        }

        /// <summary>
        /// Handles the ObservableItemRemoved event of the Controls control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        void Controls_ObservableItemRemoved(object objSender, ObservableListEventArgs objArgs)
        {
            OnCountChange(new EventArgs());
        }

        /// <summary>
        /// Handles the ObservableItemInserted event of the Controls control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        void Controls_ObservableItemInserted(object objSender, ObservableListEventArgs objArgs)
        {
            OnCountChange(new EventArgs());
        }

        /// <summary>
        /// Handles the ObservableItemAdded event of the Controls control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="ObservableListEventArgs"/> instance containing the event data.</param>
        void Controls_ObservableItemAdded(object objSender, ObservableListEventArgs objArgs)
        {
            OnCountChange(new EventArgs());
        }

        /// <summary>
        /// Raises the <see cref="E:CountChange" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCountChange(EventArgs e)
        {
            // Raise event if needed            
            if (mobjCountChangeEventHandler != null)
            {
                mobjCountChangeEventHandler(this, e);
            }
        }

        int INavigationControl.Count
        {
            get { return this.TabControl.Count; }
        }

        bool INavigationControl.MoveFirst()
        {
            return this.TabControl.MoveFirst();
        }

        bool INavigationControl.MoveLast()
        {
            return this.TabControl.MoveLast();
        }

        bool INavigationControl.MoveNext()
        {
            return this.TabControl.MoveNext();
        }

        bool INavigationControl.MovePrevious()
        {
            return this.TabControl.MovePrevious();
        }

        void INavigationControl.MoveTo(int intIndex)
        {
            this.TabControl.MoveTo(intIndex);
        }

        int INavigationControl.SelectedIndex
        {
            get { return this.TabControl.SelectedIndex; }
        }

        #endregion Methods

       
    }


    /// <summary>
    /// 
    /// </summary>
    public class ProxyTabPage : ProxyControl
    {
        /// <summary>
        /// The mobj name
        /// </summary>
        private string mobjName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabPage"/> class.
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        /// <param name="objParentProxy">The object parent proxy.</param>
        public ProxyTabPage(Component objComponent, ProxyComponent objParentProxy, bool blnStateComponent)
            : base(objComponent, objParentProxy, blnStateComponent)
        {

        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="ProxyTabPage"/> class.
        ///// </summary>
        ///// <param name="objComponent">The obj component.</param>
        //public ProxyTabPage(Component objComponent)
        //    :base(objComponent)
        //{

        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabPage" /> class.
        /// </summary>
        public ProxyTabPage()
            :base()
        {

        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        public string Name
        {
            get
            {
                string objName = mobjName;
                if (string.IsNullOrEmpty(mobjName))
                {
                    objName = "TabPage";
                }
                return objName;
            }
            set
            {
                mobjName = value;
            }
        }

        public override ProxyComponent Parent
        {
            get
            {
                return base.Parent;
            }
            set
            {
                if (value != null && !(value is ProxyTabControl))
                {
                    throw new ArgumentException(string.Format("Cannot add component of type 'TabPage' to container of type '{0}'", value.GetType().Name));
                }

                base.Parent = value;
            }
        }

        /// <summary>
        /// Returns wether proxy component is visible.
        /// </summary>
        protected override bool GetVisible()
        {
            ProxyTabControl objProxyTabControl = Parent as ProxyTabControl;
            if (objProxyTabControl != null)
            {
                int intTabPageIndex = objProxyTabControl.TabPages.IndexOf(this);

                TabControl objTabControl = objProxyTabControl.SourceComponent as TabControl;
                if (objTabControl.SelectedIndex != intTabPageIndex) 
                { 
                    return false; 
                }
            }

            return base.GetVisible();
        }

        /// <summary>
        /// Gets the proxy component property owner.
        /// </summary>
        /// <param name="objPropertyDescriptor"></param>
        /// <returns></returns>
        protected override object GetProxyComponentPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            if (objPropertyDescriptor != null && objPropertyDescriptor.Name == "Name")
            {
                return this;
            }

            return base.GetProxyComponentPropertyOwner(objPropertyDescriptor);
        }

        /// <summary>
        /// Gets the proxy component properties.
        /// </summary>
        /// <param name="arrAttributes">The arr attributes.</param>
        /// <returns></returns>
        protected override PropertyDescriptorCollection GetProxyComponentProperties(Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection objCollection = base.GetProxyComponentProperties(arrAttributes);

            System.ComponentModel.PropertyDescriptorCollection objPropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(this, arrAttributes, true);

            //Get property descriptor for current property
            System.ComponentModel.PropertyDescriptor objPropertyDescriptor = objPropertyDescriptorCollection["Name"];

            objCollection.Add(objPropertyDescriptor);

            return objCollection;
        }
    }

    #region ProxyTabPageCollection

    /// <summary>
    /// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects.
    /// </summary>
    [Serializable()]
    public class ProxyTabPageCollection : ICollection, IList, IComparer
    {
        #region Class Members

        /// <summary>
        /// The mobj proxy tab control
        /// </summary>
        private ProxyTabControl mobjProxyTabControl = null;

        /// <summary>
        /// The mobj tab control
        /// </summary>
        private TabControl mobjTabControl = null;

        #endregion Class Members

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTabPageCollection"/> class.
        /// </summary>
        /// <param name="objOwner">The object owner.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProxyTabPageCollection(ProxyTabControl objOwner)
        {
            mobjProxyTabControl = objOwner;
            mobjTabControl = mobjProxyTabControl.SourceComponent as TabControl;
        }

        #endregion C'Tor

        #region Members

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        protected ProxyTabControl Owner
        {
            get { return mobjProxyTabControl; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is synchronized (thread safe).
        /// </summary>
        /// <returns>false in all cases.</returns>
        public bool IsSynchronized
        {
            get
            {
                return ((ICollection)mobjProxyTabControl.Components).IsSynchronized;
            }
        }

        /// <summary>
        /// Gets the number of tab pages in the collection.
        /// </summary>
        /// <returns>The number of tab pages in the collection.</returns>
        [Browsable(false)]
        public int Count
        {
            get
            {
                return mobjProxyTabControl.Components.Count;
            }
        }

        /// <summary>
        /// Copies the elements of the collection to the specified array, starting at the specified index.
        /// </summary>
        /// <param name="objDestArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in the array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentException">dest is multidimensional.-or-index is equal to or greater than the length of dest.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> is greater than the available space from index to the end of dest.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
        /// <exception cref="T:System.InvalidCastException">The items in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> cannot be cast automatically to the type of dest.</exception>
        /// <exception cref="T:System.ArgumentNullException">dest is null.</exception>
        public void CopyTo(Array objDestArray, int index)
        {
            List<object> arr = new List<object>();
            foreach (ProxyComponent item in mobjProxyTabControl.Components)
            {
                arr.Add(item);
            }

            arr.ToArray().CopyTo(objDestArray, index);
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
        /// </summary>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.</returns>
        public object SyncRoot
        {
            get
            {
                return ((ICollection)mobjProxyTabControl.Components).SyncRoot;
            }
        }

        /// <summary>
        /// Adds a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to the collection.
        /// </summary>
        /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to add.</param>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException">The specified value is null.</exception>
        public virtual int Add(object objTabPage)
        {
            ProxyComponent objComponent = objTabPage as ProxyComponent;
            Insert(this.Count, objComponent);
            return mobjProxyTabControl.Components.IndexOf(objComponent);
        }

        /// <summary>
        /// Removes a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> from the collection.
        /// </summary>
        /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
        /// <exception cref="T:System.ArgumentNullException">The value parameter is null.</exception>
        public virtual void Remove(object objTabPage)
        {
            ProxyTabPage objComponent = objTabPage as ProxyTabPage;

            mobjProxyTabControl.Components.Remove(objComponent);
            mobjTabControl.Controls.Remove(objComponent.SourceComponent as Control);

        }

        /// <summary>
        /// Returns an enumeration of all the tab pages in the collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> for the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return mobjProxyTabControl.Components.GetEnumerator();
        }

        /// <summary>
        /// Returns the index of the specified tab page in the collection.
        /// </summary>
        /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to locate in the collection.</param>
        /// <returns>
        /// The zero-based index of the tab page; -1 if it cannot be found.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The value of page is null.</exception>
        public int IndexOf(object objTabPage)
        {
            ProxyTabPage objComponent = objTabPage as ProxyTabPage;

            return mobjProxyTabControl.Components.IndexOf(objComponent);
        }

        /// <summary>
        /// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the tab page to get or set.</param>
        /// <returns>
        /// The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> at the specified index.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the highest available index.</exception>
        public ProxyTabPage this[int index]
        {
            get
            {
                return (ProxyTabPage)mobjProxyTabControl.Components[index];
            }
        }

        #endregion Members

        #region IList Members

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        /// <returns>This property always returns false.</returns>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the tab page at the specified index from the collection.
        /// </summary>
        /// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to remove.</param>
        public void RemoveAt(int index)
        {
            mobjProxyTabControl.Components.RemoveAt(index);
            mobjTabControl.Controls.RemoveAt(index);
        }

        /// <summary>
        /// Inserts an existing tab page into the collection at the specified index.
        /// </summary>
        /// <param name="index">The location where the tab page is inserted.</param>
        /// <param name="objTabPage">The <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> to insert in the collection.</param>
        public void Insert(int index, object objTabPage)
        {
            ProxyTabPage objNewTabPage = objTabPage as ProxyTabPage;
            if (objNewTabPage == null)
            {
                throw new ArgumentException(string.Format("Cannot add component of type '{0}' to container of type 'ProxyTabControl'", objTabPage.GetType().Name));
            }

            if (objNewTabPage.SourceComponent == null && string.IsNullOrEmpty(objNewTabPage.UniqueID))
            {
                objNewTabPage.NonStateComponentType = typeof(TabPage).FullName;
                objNewTabPage.Parent = Owner;
            }

            mobjTabControl.TabPages.Insert(index, objNewTabPage.SourceComponent as TabPage);


            Hashtable ObjTabIndexHashTable = new Hashtable();

            // if received variable is not a TabPage, exit immediately
            if (objNewTabPage == null)
            {
                return;
            }
            // if the current TabPageCollection is not holding any TabPages
            if (this.Count == 0)
            {
                // adding the TabPage to the current TabPageCollection
                mobjProxyTabControl.Components.Add(objNewTabPage);

            }
            else
            {
                // Saving all actual indexes into tabindexes.
                foreach (ProxyTabPage objProxyPage in this)
                {
                    TabPage objPage = objProxyPage.SourceComponent as TabPage;
                    ObjTabIndexHashTable.Add(objPage.GetHashCode(), objPage.TabIndex);
                    objPage.TabIndex = this.IndexOf(objProxyPage);
                }

                // if requested index is out of range, set the tab, at the end of the sequence.
                if (index > this.Count || index < 0)
                {
                    index = this.Count;
                }

                // advancing the TabIndex of all TabPages with a TabIndex value that is equal or greater than 'index'.
                this.AdvanceTabIndexFromIndex((ushort)index, 1);
                // adding the TabPage to the current TabPageCollection
                mobjProxyTabControl.Components.Add(objNewTabPage);

                (objNewTabPage.SourceComponent as TabPage).TabIndex = index;

                // Sorting tabs by TabIndexes
                mobjProxyTabControl.Components.Sort(delegate(ProxyComponent objX, ProxyComponent objY)
                {
                    TabPage objControlX = objX.SourceComponent as TabPage;
                    TabPage objControlY = objY.SourceComponent as TabPage;
                    if (objControlX != null && objControlY != null)
                    {
                        int intResult = objControlX.TabIndex.CompareTo(objControlY.TabIndex);
                        return intResult;
                    }
                    return 0;
                });
            }
        }

        /// <summary>
        /// Returns a sorted TabPage list from current unsorted TabPageCollection.
        /// </summary>
        /// <param name="blnSortByIndex">if set to <c>true</c> [BLN sort by index].</param>
        /// <returns></returns>
        protected ArrayList GetSortedTabPageListFromCurrent(bool blnSortByIndex)
        {
            // Creating an Array and copying all TabPages from 'this' to a TabPage Array and sorting by TabIndex.            
            ArrayList objTabPageList;
            objTabPageList = new ArrayList();

            foreach (ProxyTabPage objTabPage in this)
            {
                objTabPageList.Add(objTabPage);
            }

            if (blnSortByIndex) // Sorting by the index of the TabPageCollection.
            {

                objTabPageList.Sort(this);
            }
            else               // Sorting by the TabIndex property of TabPage.
            {
                objTabPageList.Sort(new ProxyTabIndexComparer());
            }
            return objTabPageList;
        }

        /// <summary>
        /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
        /// </summary>
        /// <param name="usrFromIndex">Index of the usr from.</param>
        /// <param name="usrAdvanceBy">The usr advance by.</param>
        protected void AdvanceTabIndexFromIndex(ushort usrFromIndex, ushort usrAdvanceBy)
        {
            if (this.Count < 2)
            {
                return;
            }

            // Getting a list of all the TabPages, sorted by the index of the TabPageCollection
            ArrayList objTabPageList = GetSortedTabPageListFromCurrent(true);
            this.AdvanceTabIndexFromIndex(ref objTabPageList, usrFromIndex, usrAdvanceBy);
        }

        /// <summary>
        /// Advances the TabIndex property by the value of 'advanceBy', begginning at the 'fromIndex' position.
        /// </summary>
        /// <param name="objTabPageList">The obj tab page list.</param>
        /// <param name="usrFromIndex">Index of the usr from.</param>
        /// <param name="usrAdvanceBy">The usr advance by.</param>
        protected void AdvanceTabIndexFromIndex(ref ArrayList objTabPageList, ushort usrFromIndex, ushort usrAdvanceBy)
        {
            TabPage objTabPage = null;
            // if received invalid input, exit immediately.
            if (usrFromIndex < 0 || usrAdvanceBy <= 0 || usrFromIndex > (objTabPageList.Count - 1))
            {
                return;
            }

            for (ushort usrInd = usrFromIndex; usrInd < objTabPageList.Count; usrInd++)
            {
                objTabPage = (objTabPageList[usrInd] as ProxyTabPage).SourceComponent as TabPage;
                if (objTabPage == null)
                {
                    continue;
                }

                objTabPage.TabIndex += usrAdvanceBy;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> control is in the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see>.
        /// </summary>
        /// <param name="objValue">The object to locate in the collection.</param>
        /// <returns>
        /// true if the specified object is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> in the collection; otherwise, false.
        /// </returns>
        public bool Contains(object objValue)
        {
            ProxyTabPage objComponent = objValue as ProxyTabPage;

            return mobjProxyTabControl.Components.Contains(objComponent);
        }

        /// <summary>
        /// Removes all the tab pages from the collection.
        /// </summary>
        public void Clear()
        {
            mobjProxyTabControl.Components.Clear();
            mobjTabControl.Controls.Clear();
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> has a fixed size.
        /// </summary>
        /// <returns>false in all cases.</returns>
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        #endregion IList Members

        #region IComparer Members

        /// <summary>
        /// Compares the index of two sequencial TabPages in the TabPageCollection.
        /// </summary>
        /// <param name="objArgFirstTP">The first TabPage.</param>
        /// <param name="objArgSecondTP">The second TabPage.</param>
        /// <returns></returns>
        public int Compare(object objArgFirstTP, object objArgSecondTP)
        {
            TabPage objFirstTabPage = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;
            TabPage objSecondTabPage = (objArgFirstTP as ProxyTabPage).SourceComponent as TabPage;

            if (objFirstTabPage == null || objSecondTabPage == null)
            {
                return 0;
            }

            return this.IndexOf(objArgFirstTP).CompareTo(this.IndexOf(objArgSecondTP));
        }

        /// <summary>
        /// Implements IComparer for TabPages sorting by TabIndex
        /// </summary>
        /// <returns></returns>
        [Serializable()]
        private class ProxyTabIndexComparer : IComparer
        {
            #region IComparer Members

            int IComparer.Compare(object objX, object objY)
            {
                TabPage objControlX = (objX as ProxyTabPage).SourceComponent as TabPage;
                TabPage objControlY = (objY as ProxyTabPage).SourceComponent as TabPage;
                if (objControlX != null && objControlY != null)
                {
                    int intResult = objControlX.TabIndex.CompareTo(objControlY.TabIndex);
                    return intResult;
                }
                return 0;
            }

            #endregion
        }

        #endregion


        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        object IList.this[int index]
        {
            get
            {
                return Owner.Components[index];
            }
            set
            {
            }
        }
    }

    #endregion TabPageCollection
}