#region Using

using System;
using System.ComponentModel;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Runtime.Serialization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region StatusBar Class

    /// <summary>
    /// Represents a Gizmox.WebGUI.Forms status bar control. Although <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(StatusBar), "StatusBar_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(StatusBar), "StatusBar.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("Text")]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.StatusBar)]
    [Skin(typeof(StatusBarSkin))]
    [Serializable()]
    [ProxyComponent(typeof(ProxyStatusBar))]
    public class StatusBar : Control
    {


        /// <summary>
        /// Provides a property reference to StatusBarPanelCollection property.
        /// </summary>
        private static SerializableProperty StatusBarPanelCollectionProperty = SerializableProperty.Register("StatusBarPanelCollection", typeof(StatusBarPanelCollection), typeof(StatusBar));



      /// <summary>
        /// Provides a property reference to ShowPanels property.
        /// </summary>
        private static SerializableProperty ShowPanelsProperty = SerializableProperty.Register("ShowPanels", typeof(bool), typeof(StatusBar));

        #region StatusBarPanelCollection Class

        /// <summary>
        /// Represents the collection of panels in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
        /// </summary>
        [ListBindable(false), Serializable()]
        public class StatusBarPanelCollection : ICollection, IEnumerable, IList, IObservableList
        {
            #region IList Members

            /// <summary>
            /// Gets a value indicating whether this collection is read-only.
            /// </summary>
            ///	<returns>true if this collection is read-only; otherwise, false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return mobjList.IsReadOnly;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> at the specified index.
            /// </summary>
            ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel located at the specified index within the collection.</returns>
            ///	<param name="index">The index of the panel in the collection to get or set. </param>
            ///	<exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
            ///	<exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the collection was null. </exception>
            public StatusBarPanel this[int index]
            {
                get
                {
                    return (StatusBarPanel)mobjList[index];
                }
                set
                {
                    mobjList[index] = value;
                }
            }

            /// <summary>
            /// Removes the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> located at the specified index within the collection.
            /// </summary>
            ///	<param name="index">The zero-based index of the item to remove. </param>
            ///	<exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
            public void RemoveAt(int index)
            {
                object objRemoved = this[index];
                mobjList.RemoveAt(index);

                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(objRemoved));
                }
            }

            /// <summary>
            /// Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> into the collection at the specified index.
            /// </summary>
            ///	<param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to insert. </param>
            ///	<param name="index">The zero-based index location where the panel is inserted. </param>
            ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property of the value parameter's panel is not a valid <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> value. </exception>
            ///	<exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
            ///	<exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
            ///	<exception cref="T:System.ArgumentException">The value parameter's parent is not null. </exception>
            public void Insert(int index, StatusBarPanel value)
            {
                mobjList.Insert(index, value);

                if (ObservableItemInserted != null)
                {
                    ObservableItemInserted(this, new ObservableListEventArgs(value));
                }
            }

            /// <summary>
            /// Removes the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> from the collection.
            /// </summary>
            ///	<param name="value">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to remove from the collection. </param>
            ///	<exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the value parameter is null. </exception>
            public void Remove(StatusBarPanel value)
            {
                mobjList.Remove(value);

                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(value));
                }
            }

            /// <summary>
            /// Determines whether the specified panel is located within the collection.
            /// </summary>
            ///	<returns>true if the panel is located within the collection; otherwise, false.</returns>
            ///	<param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
            public bool Contains(StatusBarPanel objPanel)
            {
                return mobjList.Contains(objPanel);
            }

            /// <summary>
            /// Removes all items from the collection.
            /// </summary>
            public void Clear()
            {
                mobjList.Clear();

                if (ObservableListCleared != null)
                {
                    ObservableListCleared(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Returns the index within the collection of the specified panel.
            /// </summary>
            ///	<returns>The zero-based index where the panel is located within the collection; otherwise, negative one (-1).</returns>
            ///	<param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
            public int IndexOf(StatusBarPanel objPanel)
            {
                return mobjList.IndexOf(objPanel);
            }

            /// <summary>
            /// Adds a <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to the collection.
            /// </summary>
            ///	<returns>The zero-based index of the item in the collection.</returns>
            ///	<param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> that represents the panel to add to the collection. </param>
            ///	<exception cref="T:System.ArgumentException">The parent of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> specified in the value parameter is not null. </exception>
            ///	<exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> being added to the collection was null. </exception>
            public int Add(StatusBarPanel value)
            {
                value.InternalParent = mobjStatusBar;
                int intIndex = mobjList.Add(value);
                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(value));
                }

                return intIndex;
            }

            /// <summary>
            /// Adds an array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to the collection.
            /// </summary>
            ///	<param name="arrPnels">An array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to add. </param>
            ///	<exception cref="T:System.ArgumentNullException">The array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects being added to the collection was null. </exception>
            public void AddRange(StatusBarPanel[] arrPnels)
            {
                foreach (StatusBarPanel objStatusBarPanel in arrPnels)
                {
                    Add(objStatusBarPanel);
                }
            }

            /// <summary>
            /// Gets a value indicating whether the collection has a fixed size.
            /// </summary>
            ///	<returns>false in all cases.</returns>
            public bool IsFixedSize
            {
                get
                {
                    return mobjList.IsFixedSize;
                }
            }


            #endregion IList Members

            #region ICollection Members

            /// <summary>
            /// Gets a value indicating whether access to the collection is synchronized (thread safe).
            /// </summary>
            ///	<returns>false in all cases.</returns>
            public bool IsSynchronized
            {
                get
                {
                    return mobjList.IsSynchronized;
                }
            }

            /// <summary>
            /// Gets the number of items in the collection.
            /// </summary>
            ///	<returns>The number of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects in the collection.</returns>
            [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
            public int Count
            {
                get
                {
                    return mobjList.Count;
                }
            }

            /// <summary>
            /// Copies the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> to a compatible one-dimensional array, starting at the specified index of the target array.
            /// </summary>
            ///	<param name="objDestinationArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.  </param>
            ///	<param name="index">The zero-based index in the array at which copying begins.</param>
            ///	<exception cref="T:System.InvalidCastException">The type in the collection cannot be cast automatically to the type of array.</exception>
            ///	<exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
            ///	<exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> is greater than the available space from index to the end of array.</exception>
            ///	<exception cref="T:System.ArgumentNullException">array is null.</exception>
            public void CopyTo(Array objDestinationArray, int index)
            {
                mobjList.CopyTo(objDestinationArray, index);
            }

            /// <summary>
            /// Gets an object that can be used to synchronize access to the collection.
            /// </summary>
            /// <returns>The object used to synchronize access to the collection.</returns>
            public object SyncRoot
            {
                get
                {
                    return mobjList.SyncRoot;
                }
            }


            #endregion ICollection Members

            #region IEnumerable Members

            /// <summary>
            /// Returns an enumerator to use to iterate through the item collection.
            /// </summary>
            ///	<returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
            public IEnumerator GetEnumerator()
            {
                return mobjList.GetEnumerator();
            }


            #endregion IEnumerable Members

            #region Class Members

            private ArrayList mobjList;

            private StatusBar mobjStatusBar;


            #endregion Class Members

            #region C'Tor / D'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class.
            /// </summary>
            ///	<param name="objStatusBar">The <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control that contains this collection. </param>
            public StatusBarPanelCollection(StatusBar objStatusBar)
            {
                mobjStatusBar = objStatusBar;
                mobjList = new ArrayList();
            }


            #endregion C'Tor / D'Tor

            #region IList Members

            int IList.Add(object objValue)
            {
                ((StatusBarPanel)objValue).InternalParent = mobjStatusBar;
                return this.Add((StatusBarPanel)objValue);
            }

            void IList.Clear()
            {
                this.Clear();
            }

            bool IList.Contains(object objValue)
            {
                return this.Contains((StatusBarPanel)objValue);
            }

            int IList.IndexOf(object objValue)
            {
                return this.IndexOf((StatusBarPanel)objValue);
            }

            void IList.Insert(int index, object objValue)
            {
                this[index] = (StatusBarPanel)objValue;
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            bool IList.IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            void IList.Remove(object objValue)
            {
                this.Remove((StatusBarPanel)objValue);
            }

            void IList.RemoveAt(int index)
            {
                this.Remove(this[index]);
            }

            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    this[index] = (StatusBarPanel)value;
                }
            }

            #endregion

            #region ICollection Members

            void ICollection.CopyTo(Array objArray, int index)
            {
                mobjList.CopyTo(objArray, index);
            }

            int ICollection.Count
            {
                get { return mobjList.Count; }
            }

            bool ICollection.IsSynchronized
            {
                get { return mobjList.IsSynchronized; }
            }

            object ICollection.SyncRoot
            {
                get { return mobjList.SyncRoot; }
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                return mobjList.GetEnumerator();
            }

            #endregion

            #region IObservableList Members

            /// <summary>
            /// Occurs when [observable item inserted].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemInserted;

            /// <summary>
            /// Occurs when [observable item added].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemAdded;

            /// <summary>
            /// Occurs when [observable list cleared].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event EventHandler ObservableListCleared;

            /// <summary>
            /// Occurs when [observable item removed].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemRemoved;

            #endregion

        }

        #endregion StatusBarPanelCollection Class

        #region Class Members

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> class.
        /// </summary>
        public StatusBar()
        {
            base.SetStyle(ControlStyles.Selectable | ControlStyles.UserPaint, false);
            this.Dock = DockStyle.Bottom;
            this.TabStop = false;
        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            StatusBarPanelCollection objPanels = this.Panels;

            // register the Panels
            if (objPanels != null)
            {
                RegisterBatch(objPanels);
            }
        }

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();
            
            StatusBarPanelCollection objPanels = this.Panels;

            // Unregister the Panels
            if (objPanels != null)
            {
                UnRegisterBatch(objPanels);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            if (this.Panels.Count == 0 || !ShowPanels)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.Text, TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Gets the status bar critical events.
        /// </summary>
        /// <returns></returns>
        internal CriticalEventsData GetStatusBarCriticalEventsData()
        {
            return this.GetCriticalEventsData();
        }

        /// <summary>
        /// Fires the status bar event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void FireStatusBarEvent(IEvent objEvent)
        {
            this.FireEvent(objEvent);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.Text, TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (this.ShowPanels)
            {
                // add all child nodes
                foreach (StatusBarPanel objPanel in Panels)
                {
                    RegisterComponent(objPanel);
                    objPanel.RenderPanel(objContext, objWriter, lngRequestID); ;
                }
            }
        }


        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.Panels;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        /// <summary>
        /// Gets the default back color internal.
        /// </summary>
        /// <value>The default back color internal.</value>
        internal Color DefaultBackColorInternal
        {
            get { return this.DefaultBackColor; }
        }

        /// <summary>
        /// Gets the default fore color internal.
        /// </summary>
        /// <value>The default fore color internal.</value>
        internal Color DefaultForeColorInternal
        {
            get { return this.DefaultForeColor; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether any panels that have been added to the control are displayed.
        /// </summary>
        ///	<returns>true if panels are displayed; otherwise, false. The default is false.</returns>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("StatusBarShowPanelsDescr")]
        public bool ShowPanels
        {
            get
            {
                return this.GetValue<bool>(StatusBar.ShowPanelsProperty, false);
            }
            set
            {
                if (ShowPanels != value)
                {
                    if (value == false)
                    {
                        this.RemoveValue<bool>(StatusBar.ShowPanelsProperty);
                    }
                    else
                    {
                        this.SetValue<bool>(StatusBar.ShowPanelsProperty, value);
                    }
                    Update();

                    FireObservableItemPropertyChanged("ShowPanels");
                }           
            }
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        /// <value></value>
        [Localizable(true), DefaultValue(DockStyle.Bottom)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

        /// <summary>
        /// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> panels contained within the control.
        /// </summary>
        ///	<returns>A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> containing the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.</returns>
        [Browsable(true), SRCategory("CatAppearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("StatusBarPanelsDescr"), Localizable(true), MergableProperty(false)]
        public StatusBarPanelCollection Panels
        {
            get
            {
                //Get the value from property store
                StatusBarPanelCollection objPanels = this.GetValue<StatusBarPanelCollection>(StatusBar.StatusBarPanelCollectionProperty, null);

                //If this is the first time
                if (objPanels == null)
                {
                    //CreateControl a new CollectionBase and store it
                    objPanels = CreatePanelsCollection();
                    this.SetValue<StatusBarPanelCollection>(StatusBar.StatusBarPanelCollectionProperty, objPanels);

                }

                return objPanels;
            }

        }

        /// <summary>
        /// Creates the panels Collection.
        /// </summary>
        /// <returns></returns>
        [Browsable(false)]        
        protected virtual StatusBarPanelCollection CreatePanelsCollection()
        {
            return new StatusBarPanelCollection(this);             
        }



        #endregion Properties
    }

    #endregion StatusBar Class

    #region StatusBarPanel Class

    /// <summary>
    /// Represents a panel in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control. Although the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see> control replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarPanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarPanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [DefaultProperty("Text"), ToolboxItem(false), DesignTimeVisible(false)]
    [Serializable()]
    public class StatusBarPanel : Gizmox.WebGUI.Forms.Component, System.ComponentModel.ISupportInitialize
    {
        #region Class Members

        private StatusBarPanelAutoSize menmAutoSize = StatusBarPanelAutoSize.None;

        private HorizontalAlignment menmAlignment = HorizontalAlignment.Left;

        private string mstrText = "";

        private int mintWidth = 100;


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> class.
        /// </summary>
        public StatusBarPanel()
        {

        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Updates the containing status bar.
        /// </summary>
        private void UpdateStatusBar()
        {
            StatusBar objStatusBar = this.OwnerStatusBar;
            if (objStatusBar != null)
            {
                objStatusBar.Update();
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            StatusBar objStatusBar = this.OwnerStatusBar;
            if (objStatusBar != null)
            {
                objEvents.Set(objStatusBar.GetStatusBarCriticalEventsData());
            }

            return objEvents;
        }


        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            StatusBar objStatusBar = this.OwnerStatusBar;
            if (objStatusBar != null)
            {
                objStatusBar.FireStatusBarEvent(objEvent);
            }
        }

        /// <summary>
        /// Renders the panel.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        internal void RenderPanel(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (IsDirty(lngRequestID))
            {

                objWriter.WriteStartElement(WGTags.StatusPanel);
                RegisterSelf();
                RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);
                if (menmAlignment != HorizontalAlignment.Left)
                {
                    objWriter.WriteAttributeString(WGAttributes.HorizontalAlignment, menmAlignment.ToString());
                }
                StatusBar objStatusBar = this.InternalParent as StatusBar;
                if (objStatusBar != null)
                {
                    // if there is a border
                    if (objStatusBar.Font != Control.DefaultFont)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(objStatusBar.Font));
                    }

                    // if there not transparent
                    if (objStatusBar.BackColor != objStatusBar.DefaultBackColorInternal)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(objStatusBar.BackColor));
                    }

                    // if there not transparent
                    if (objStatusBar.ForeColor != objStatusBar.DefaultForeColorInternal)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objStatusBar.ForeColor));
                    }
                }

                objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);
                objWriter.WriteAttributeString(WGAttributes.AutoSize, ((int)AutoSize).ToString());
                objWriter.WriteAttributeString(WGAttributes.Width, this.Width.ToString());
                objWriter.WriteEndElement();
            }
        }


        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the width of the status bar panel within the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
        /// </summary>
        ///	<returns>The width, in pixels, of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see>.</returns>
        ///	<exception cref="T:System.ArgumentException">The width specified is less than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.MinWidth"></see> property. </exception>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRDescription("StatusBarPanelWidthDescr"), SRCategory("CatAppearance"), DefaultValue(100)]
        public int Width
        {
            get
            {
                return mintWidth;
            }
            set
            {
                if (mintWidth != value)
                {
                    mintWidth = value;

                    FireObservableItemPropertyChanged("Width");

                    // Update containing status bar.
                    this.UpdateStatusBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the status bar panel is automatically resized.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.None"></see>.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> enumeration. </exception>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(1), SRCategory("CatAppearance"), SRDescription("StatusBarPanelAutoSizeDescr"), RefreshProperties(RefreshProperties.All)]
        public StatusBarPanelAutoSize AutoSize
        {
            get
            {
                return menmAutoSize;
            }
            set
            {
                if (menmAutoSize != value)
                {
                    menmAutoSize = value;

                    FireObservableItemPropertyChanged("AutoSize");

                    // Update containing status bar.
                    this.UpdateStatusBar();
                }
            }
        }

        /// <summary>
        /// Gets or sets the alignment of text and icons within the status bar panel.
        /// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default is<see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
        ///	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned to the property is not a member of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration. </exception>
        ///	<PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("StatusBarPanelAlignmentDescr"), SRCategory("CatAppearance"), DefaultValue(HorizontalAlignment.Left), Localizable(true)]
        public HorizontalAlignment Alignment
        {
            get
            {
                return menmAlignment;
            }
            set
            {
                if (menmAlignment != value)
                {
                    menmAlignment = value;
                    FireObservableItemPropertyChanged("Alignment");
                    Update();
                }

            }
        }

        /// <summary>
        /// Gets the owner status bar.
        /// </summary>
        /// <value>The owner status bar.</value>
        private StatusBar OwnerStatusBar
        {
            get
            {
                return this.InternalParent as StatusBar;
            }
        }

        /// <summary>
        /// Gets or sets the text of the status bar panel.
        /// </summary>
        /// <returns>The text displayed in the panel.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRDescription("StatusBarPanelTextDescr"), SRCategory("CatAppearance"), DefaultValue("")]
        public string Text
        {
            get
            {
                return mstrText;
            }
            set
            {
                if (mstrText != value)
                {
                    mstrText = value;
                    FireObservableItemPropertyChanged("Text");
                    Update();
                }
            }
        }

        /// <summary>Gets or sets the minimum allowed width of the status bar panel within the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control.</summary>
        /// <returns>The minimum width, in pixels, of the <see cref="T:Gizmox.WebGui.Forms.StatusBarPanel"></see>.</returns>
        /// <exception cref="T:System.ArgumentException">A value less than 0 is assigned to the property. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Localizable(true), SRCategory("CatBehavior"), SRDescription("StatusBarPanelMinWidthDescr"), DefaultValue(10), RefreshProperties(RefreshProperties.All)]
        public int MinWidth
        {
            get
            {
                return 10;
            }
            set
            {}
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> control that hosts the status bar panel.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGui.Forms.StatusBar"></see> that contains the panel.</returns>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Localizable(true), SRCategory("CatAppearance"), SRDescription("StatusBarPanelNameDescr")]
        public string Name
        {
            get
            {
                return string.Empty;
            }
            set
            {}
        }
 

 

 

 

        #endregion Properties

        #region ISupportInitialize Members

        /// <summary>
        ///
        /// </summary>
        public void BeginInit()
        {

        }

        /// <summary>
        ///
        /// </summary>
        public void EndInit()
        {

        }


        #endregion ISupportInitialize Members

    }

    #endregion StatusBarPanel Class



    #region StatusBarPanelAutoSize Enum

    /// <summary>
    /// Specifies how a <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> on a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control behaves when the control resizes.
    /// </summary>

    public enum StatusBarPanelAutoSize
    {
        /// <summary>
        /// The width of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> is determined by its contents.
        /// </summary>
        Contents = 3,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> does not change size when the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control resizes.
        /// </summary>
        None = 1,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> shares the available space on the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> (the space not taken up by other panels whose <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.Contents"></see>) with other panels that have their <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property set to <see cref="F:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize.Spring"></see>.
        /// </summary>
        Spring = 2
    }


    #endregion StatusBarPanelAutoSize Enum

}
