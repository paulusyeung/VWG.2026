using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HierarchicInfo : SerializableObject, INotifyPropertyChanged, IComponent
    {
        #region Static Methods

        /// <summary>
        /// Gets the cloned infos.
        /// </summary>
        /// <param name="objHierarchicInfos">The obj hierarchic infos.</param>
        /// <param name="blnIncludeRoot">if set to <c>true</c> [includes root info].</param>
        /// <returns></returns>
        internal static ObservableCollection<HierarchicInfo> GetClonedInfos(ObservableCollection<HierarchicInfo> objHierarchicInfos, bool blnIncludeRoot)
        {
            ObservableCollection<HierarchicInfo> objClonedInfos = new ObservableCollection<HierarchicInfo>();
            int intStartIndex = blnIncludeRoot ? 0 : 1;

            for (int i = intStartIndex; i < objHierarchicInfos.Count; i++)
            {
                // The list is already sorted so the output must also be sorted!
                objClonedInfos.Add(objHierarchicInfos[i]);
            }

            return objClonedInfos;
        }

        #endregion Static Methods

        #region Class Memebers

        #region Static events

        internal static readonly SerializableEvent HierarchyInfoChangedEvent = SerializableEvent.Register("Event", typeof(Delegate), typeof(HierarchicInfo));

        #endregion Static events

        private BindingSource mobjBindedSource;
        private ObservableCollection<FilterRelation> mobjFilteringDataMembers;
        private List<string> mobjKeys;
        private ISite mobjSite;
        private SuspendableObservableCollection<string> mobjHiddenColumns;
        private string mstrHierarchyName;

        #endregion Class Memebers

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicInfo"/> class.
        /// </summary>
        public HierarchicInfo()
        {
            this.mobjKeys = new List<string>();
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                this.AddHandler(HierarchyInfoChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(HierarchyInfoChangedEvent, value);
            }
        }

        #endregion

        /// <summary>
        /// Gets the hidden columns indicator.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SuspendableObservableCollection<string> HiddenColumns
        {
            get
            {
                if (this.mobjHiddenColumns == null)
                {
                    this.mobjHiddenColumns = new SuspendableObservableCollection<string>();
                }

                return mobjHiddenColumns;
            }
        }

        /// <summary>
        /// Gets or sets the name of the hierarchy.
        /// </summary>
        /// <value>
        /// The name of the hierarchy.
        /// </value>
        public string HierarchyName
        {
            get
            {
                return mstrHierarchyName;
            }
            set
            {
                mstrHierarchyName = value;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            // If user did not define a name for the hierarchy
            if (string.IsNullOrEmpty(mstrHierarchyName))
            {
                // Get Name from currency manager
                return this.BindedSource.CurrencyManager.GetListName();
            }

            return mstrHierarchyName;
        }

        /// <summary>
        /// Gets or sets the filtering data members.
        /// </summary>
        /// <value>
        /// The filtering data members.
        /// </value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ObservableCollection<FilterRelation> FilteringDataMembers
        {
            get
            {
                if (mobjFilteringDataMembers == null)
                {
                    this.FilteringDataMembers = new ObservableCollection<FilterRelation>();
                }

                return mobjFilteringDataMembers;
            }
            set
            {
                if (mobjFilteringDataMembers != value)
                {
                    AttachDetachEventsFromFilteringMembers(mobjFilteringDataMembers, false);

                    mobjFilteringDataMembers = value;

                    AttachDetachEventsFromFilteringMembers(mobjFilteringDataMembers, true);

                    GenerateKeys();

                    this.OnPropertyChanged("FilteringDataMembers");
                }
            }
        }

        /// <summary>
        /// Attaches the detach events from filtering members.
        /// </summary>
        /// <param name="objFilteringDataMembers">The obj filtering data members.</param>
        /// <param name="blnAttach">if set to <c>true</c> [BLN attach].</param>
        private void AttachDetachEventsFromFilteringMembers(ObservableCollection<FilterRelation> objFilteringDataMembers, bool blnAttach)
        {
            if (objFilteringDataMembers != null && !this.DesignMode)
            {
                if (blnAttach)
                {
                    // Attach events    
                    objFilteringDataMembers.CollectionChanged += new NotifyCollectionChangedEventHandler(mobjFilteringDataMembers_CollectionChanged);

                    foreach (FilterRelation objFilterRelation in objFilteringDataMembers)
                    {
                        objFilterRelation.PropertyChanged += new PropertyChangedEventHandler(objFilterRelation_PropertyChanged);
                    }
                }
                else
                {
                    // Detach events
                    objFilteringDataMembers.CollectionChanged -= new NotifyCollectionChangedEventHandler(mobjFilteringDataMembers_CollectionChanged);

                    foreach (FilterRelation objFilterRelation in objFilteringDataMembers)
                    {
                        objFilterRelation.PropertyChanged -= new PropertyChangedEventHandler(objFilterRelation_PropertyChanged);
                    }
                }
            }
        }

        /// <summary>
        /// Generates the keys.
        /// </summary>
        private void GenerateKeys()
        {
            this.Keys.Clear();

            foreach (FilterRelation objFilterRelation in mobjFilteringDataMembers)
            {
                this.Keys.Add(objFilterRelation.SourceColumnDataName);
            }
        }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        internal List<string> Keys
        {
            get
            {
                return mobjKeys;
            }
        }

        /// <summary>
        /// Handles the CollectionChanged event of the mobjFilteringDataMembers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        void mobjFilteringDataMembers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!DesignMode)
            {
                if (e.NewItems != null)
                {
                    // Attach event listener to new items
                    foreach (FilterRelation objFilterRelation in e.NewItems)
                    {
                        objFilterRelation.PropertyChanged += new PropertyChangedEventHandler(objFilterRelation_PropertyChanged);
                    }
                }

                if (e.OldItems != null)
                {
                    // detach event listener to new items
                    foreach (FilterRelation objFilterRelation in e.OldItems)
                    {
                        objFilterRelation.PropertyChanged -= new PropertyChangedEventHandler(objFilterRelation_PropertyChanged);
                    }
                }

                GenerateKeys();

                this.OnPropertyChanged("FilteringDataMembersChanged");
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the objFilterRelation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        void objFilterRelation_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            GenerateKeys();

            this.OnPropertyChanged(e.PropertyName);
        }

        /// <summary>
        /// Gets or sets the binded source.
        /// </summary>
        /// <value>
        /// The binded source.
        /// </value>
        public BindingSource BindedSource
        {
            get
            {
                return mobjBindedSource;
            }
            set
            {
                if (mobjBindedSource != value)
                {
                    mobjBindedSource = value;

                    this.OnPropertyChanged("BindedSource");
                }
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="strName">The name.</param>
        protected void OnPropertyChanged(string strName)
        {
            PropertyChangedEventHandler objHierarchyInfoChangedEventHandler = this.GetHandler(HierarchyInfoChangedEvent) as PropertyChangedEventHandler;
            if (objHierarchyInfoChangedEventHandler != null)
            {
                objHierarchyInfoChangedEventHandler(this, new PropertyChangedEventArgs(strName));
            }
        }

        #region IComponent Members

        public event EventHandler Disposed;

        /// <summary>Gets a value that indicates whether the <see cref="T:System.ComponentModel.Component"></see> is currently in design mode.</summary>
        /// <returns>true if the <see cref="T:System.ComponentModel.Component"></see> is in design mode; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool DesignMode
        {
            get
            {
                ISite objSite = this.mobjSite;
                if (objSite != null)
                {
                    return objSite.DesignMode;
                }
                return false;
            }
        }

        /// <summary>Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ISite Site
        {
            get
            {
                return this.mobjSite;
            }
            set
            {
                this.mobjSite = value;
            }
        }

        #region IDisposable Members

        /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> and optionally releases the managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if ((this.mobjSite != null) && (this.mobjSite.Container != null))
                    {
                        this.mobjSite.Container.Remove(this);
                    }

                    EventHandler handler = this.Disposed;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
       }

        #endregion IDisposable Members

        #endregion IComponent Members
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FilterRelation : SerializableObject, INotifyPropertyChanged, IComponent
    {
        #region Members

        #region Static events

        internal static readonly SerializableEvent MemberChangedEvent = SerializableEvent.Register("Event", typeof(Delegate), typeof(FilterRelation));

        #endregion

        private string mstrSourceDataMember;
        private string mstrTargetDataMember;
        private ISite mobjSite;

        #endregion

        /// <summary>
        /// Gets or sets the name of the target column data.
        /// </summary>
        /// <value>
        /// The name of the target column data.
        /// </value>
        public string TargetColumnDataName
        {
            get
            {
                return mstrTargetDataMember;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("TargetColumnDataName must not be null nor empty");
                }

                mstrTargetDataMember = value;

                OnPropertyChanged("TargetDataMember");
            }
        }

        /// <summary>
        /// Gets or sets the name of the source column data.
        /// </summary>
        /// <value>
        /// The name of the source column data.
        /// </value>
        public string SourceColumnDataName
        {
            get { return mstrSourceDataMember; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("SourceColumnDataName must not be null nor empty");
                }

                mstrSourceDataMember = value;

                OnPropertyChanged("SourceDataMember");

            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="strName">The name.</param>
        protected void OnPropertyChanged(string strName)
        {
            PropertyChangedEventHandler objHierarchyInfoChangedEventHandler = this.GetHandler(MemberChangedEvent) as PropertyChangedEventHandler;
            if (objHierarchyInfoChangedEventHandler != null)
            {
                objHierarchyInfoChangedEventHandler(this, new PropertyChangedEventArgs(strName));
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                this.AddHandler(MemberChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(MemberChangedEvent, value);
            }
        }

        #endregion

        #region IComponent Members

        /// <summary>
        /// Represents the method that handles the <see cref="E:System.ComponentModel.IComponent.Disposed"/> event of a component.
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual ISite Site
        {
            get
            {
                return this.mobjSite;
            }
            set
            {
                this.mobjSite = value;
            }
        }

        /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> and optionally releases the managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (this)
                {
                    if ((this.mobjSite != null) && (this.mobjSite.Container != null))
                    {
                        this.mobjSite.Container.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}
