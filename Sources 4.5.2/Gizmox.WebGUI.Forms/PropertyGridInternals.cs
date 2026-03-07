#region Using

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Serialization;

#endregion

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{

    #region GridEntry Class

    /// <summary>
    /// Base class for property grid entries
    /// </summary>
    [Serializable()]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class GridEntry : GridItem, ITypeDescriptorContext, IServiceProvider, IRegisteredComponentMember, IRenderableComponentMember
    {

        #region Class Members

        /// <summary>
        /// Indicates last modified time
        /// </summary>
        private long LastModified
        {
            get
            {
                return this.GetValue<long>(GridEntry.LastModifiedProperty);
            }
            set
            {
                this.SetValue<long>(GridEntry.LastModifiedProperty, value);
            }
        }

        /// <summary>
        /// The long property registration.
        /// </summary>
        private static readonly SerializableProperty LastModifiedProperty = SerializableProperty.Register("LastModified", typeof(long), typeof(GridEntry));


        /// <summary>
        /// Indicates last modified parameters time
        /// </summary>
        private long mlngLastModifiedParams
        {
            get
            {
                return this.GetValue<long>(GridEntry.mlngLastModifiedParamsProperty);
            }
            set
            {
                this.SetValue<long>(GridEntry.mlngLastModifiedParamsProperty, value);
            }
        }

        /// <summary>
        /// The long property registration.
        /// </summary>
        private static readonly SerializableProperty mlngLastModifiedParamsProperty = SerializableProperty.Register("mlngLastModifiedParams", typeof(long), typeof(GridEntry));



        /// <summary>
        /// Indicate modified params types
        /// </summary>
        private AttributeType menmLastModifiedParams
        {
            get
            {
                return this.GetValue<AttributeType>(GridEntry.menmLastModifiedParamsProperty, AttributeType.None);
            }
            set
            {
                this.SetValue<AttributeType>(GridEntry.menmLastModifiedParamsProperty, value);
            }
        }

        /// <summary>
        /// The AttributeType property registration.
        /// </summary>
        private static readonly SerializableProperty menmLastModifiedParamsProperty = SerializableProperty.Register("menmLastModifiedParams", typeof(AttributeType), typeof(GridEntry));



        /// <summary>
        /// The current attribute sorter
        /// </summary>
        internal static AttributeTypeSorter AttributeTypeSorter;

        /// <summary>
        /// Item cache values
        /// </summary>
        private CacheItems mobjCacheItems
        {
            get
            {
                return this.GetValue<CacheItems>(GridEntry.mobjCacheItemsProperty);
            }
            set
            {
                this.SetValue<CacheItems>(GridEntry.mobjCacheItemsProperty, value);
            }
        }

        /// <summary>
        /// The CacheItems property registration.
        /// </summary>
        private static readonly SerializableProperty mobjCacheItemsProperty = SerializableProperty.Register("mobjCacheItems", typeof(CacheItems), typeof(GridEntry));



        /// <summary>
        /// Grid Entry children collection
        /// </summary>
        private GridEntryCollection mobjChildCollection
        {
            get
            {
                return this.GetValue<GridEntryCollection>(GridEntry.mobjChildCollectionProperty);
            }
            set
            {
                this.SetValue<GridEntryCollection>(GridEntry.mobjChildCollectionProperty, value);
            }
        }

        /// <summary>
        /// The GridEntryCollection property registration.
        /// </summary>
        private static readonly SerializableProperty mobjChildCollectionProperty = SerializableProperty.Register("mobjChildCollection", typeof(GridEntryCollection), typeof(GridEntry));



        /// <summary>
        /// The owner property grid
        /// </summary>
        protected PropertyGrid mobjOwnerPropertyGrid
        {
            get
            {
                return this.GetValue<PropertyGrid>(GridEntry.mobjOwnerPropertyGridProperty);
            }
            set
            {
                this.SetValue<PropertyGrid>(GridEntry.mobjOwnerPropertyGridProperty, value);
            }
        }

        /// <summary>
        /// The PropertyGrid property registration.
        /// </summary>
        protected static readonly SerializableProperty mobjOwnerPropertyGridProperty = SerializableProperty.Register("mobjOwnerPropertyGrid", typeof(PropertyGrid), typeof(GridEntry));



        /// <summary>
        /// The parent grid entry
        /// </summary>
        internal GridEntry mobjParentGridEntry
        {
            get
            {
                return this.GetValue<GridEntry>(GridEntry.mobjParentGridEntryProperty);
            }
            set
            {
                this.SetValue<GridEntry>(GridEntry.mobjParentGridEntryProperty, value);
            }
        }

        /// <summary>
        /// The GridEntry property registration.
        /// </summary>
        private static readonly SerializableProperty mobjParentGridEntryProperty = SerializableProperty.Register("mobjParentGridEntry", typeof(GridEntry), typeof(GridEntry));

        /// <summary>
        /// The grid entry type convertor to use
        /// </summary>
        protected System.ComponentModel.TypeConverter mobjConverter
        {
            get
            {
                return this.GetValue<System.ComponentModel.TypeConverter>(GridEntry.mobjConverterProperty);
            }
            set
            {
                this.SetValue<System.ComponentModel.TypeConverter>(GridEntry.mobjConverterProperty, value);
            }
        }

        /// <summary>
        /// The System.ComponentModel.TypeConverter property registration.
        /// </summary>
        private static readonly SerializableProperty mobjConverterProperty = SerializableProperty.Register("mobjConverter", typeof(System.ComponentModel.TypeConverter), typeof(GridEntry));

        /// <summary>
        /// The property depth value indicating how deep is it in the property tree
        /// </summary>
        private int mintPropertyDepth
        {
            get
            {
                return this.GetValue<int>(GridEntry.mintPropertyDepthProperty);
            }
            set
            {
                this.SetValue<int>(GridEntry.mintPropertyDepthProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintPropertyDepthProperty = SerializableProperty.Register("mintPropertyDepth", typeof(int), typeof(GridEntry));



        /// <summary>
        /// The current sort type
        /// </summary>
        protected PropertySort menmPropertySort
        {
            get
            {
                return this.GetValue<PropertySort>(GridEntry.menmPropertySortProperty);
            }
            set
            {
                this.SetValue<PropertySort>(GridEntry.menmPropertySortProperty, value);
            }
        }

        /// <summary>
        /// The Gizmox.WebGUI.Forms.PropertySort property registration.
        /// </summary>
        private static readonly SerializableProperty menmPropertySortProperty = SerializableProperty.Register("menmPropertySort", typeof(PropertySort), typeof(GridEntry));



        /// <summary>
        /// Display Name Comparer
        /// </summary>
        protected static IComparer DisplayNameComparer;

        /// <summary>
        /// The grid entry web editor
        /// </summary>
        protected WebUITypeEditor mobjEditor
        {
            get
            {
                return this.GetValue<Gizmox.WebGUI.Forms.Design.WebUITypeEditor>(GridEntry.mobjEditorProperty);
            }
            set
            {
                this.SetValue<Gizmox.WebGUI.Forms.Design.WebUITypeEditor>(GridEntry.mobjEditorProperty, value);
            }
        }

        /// <summary>
        /// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
        /// </summary>
        private static readonly SerializableProperty mobjEditorProperty = SerializableProperty.Register("mobjEditor", typeof(Gizmox.WebGUI.Forms.Design.WebUITypeEditor), typeof(GridEntry));



        /// <summary>
        /// The grid entry state
        /// </summary>
        internal int State
        {
            get
            {
                return this.GetValue<int>(GridEntry.StateProperty);
            }
            set
            {
                this.SetValue<int>(GridEntry.StateProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty StateProperty = SerializableProperty.Register("State", typeof(int), typeof(GridEntry));



        #region Constants

        internal const int mcntFlagsCategories = 0x200000;
        internal const int mcntFlagsChecked = -2147483648;
        internal const int mcntFlagsExpand = 0x10000;
        internal const int mcntFlagsExpandable = 0x20000;
        internal const int mcntFlagsExpandableFailed = 0x80000;
        internal const int mcntFlagsNoCustomPaint = 0x100000;
        internal const int mcntFlagsNoCustomEditable = 0x10;
        internal const int mcntFlagsCustomPaint = 4;
        internal const int mcntFlagsDisposed = 0x2000;
        internal const int mcntFlagsDropDownEditable = 0x20;
        internal const int mcntFlagsEnumarable = 2;
        internal const int mcntFlagsForceReadOnly = 0x400;
        internal const int mcntFlagsImidiatlyEditable = 8;
        internal const int mcntFlagsImmutable = 0x200;
        internal const int mcntFlagsLabelBold = 0x40;
        internal const int mcntFlagsReadOnlyEditable = 0x80;
        internal const int mcntFlagsRenderPassword = 0x1000;
        internal const int mcntFlagsRenderReadOnly = 0x100;
        internal const int mcntFlagsTextEditable = 1;
        protected const int mcntNotifyCanReset = 2;
        protected const int mcctNotifyDoubleClick = 3;
        protected const int mcntNotifyReset = 1;
        protected const int mcntNotifyShouldPresist = 4;

        private const int mcntMaximumLengthOfPropertyString = 0x3e8;

        #endregion

        #endregion

        #region C'Tor / D'Tor

        /// <summary>
        /// 
        /// </summary>
        static GridEntry()
        {
            GridEntry.AttributeTypeSorter = new Gizmox.WebGUI.Forms.PropertyGridInternal.AttributeTypeSorter();
            GridEntry.DisplayNameComparer = new DisplayNameSortComparer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPropertyGrid"></param>
        /// <param name="objParentGridEntry"></param>
        protected GridEntry(PropertyGrid objPropertyGrid, GridEntry objParentGridEntry)
        {

            // Initialize a sure rendered time stamp
            mlngLastModifiedParams = LastModified = GetCurrentTicks(true);

            // Set the local variabls
            this.mobjParentGridEntry = objParentGridEntry;
            this.mobjOwnerPropertyGrid = objPropertyGrid;

            if (objParentGridEntry != null)
            {
                this.mintPropertyDepth = objParentGridEntry.PropertyDepth + 1;
                this.menmPropertySort = objParentGridEntry.menmPropertySort;
                if (objParentGridEntry.ForceReadOnly)
                {
                    this.State |= 0x400;
                }
            }
            else
            {
                this.mintPropertyDepth = -1;
            }
        }



        ~GridEntry()
        {
            this.Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if value can be reset
        /// </summary>
        /// <returns></returns>
        public virtual bool CanResetPropertyValue()
        {
            return this.NotifyValue(mcntNotifyCanReset);
        }

        /// <summary>
        /// Clear the cached values
        /// </summary>
        internal void ClearCachedValues()
        {
            this.ClearCachedValues(true);
        }

        /// <summary>
        /// Clear cached values
        /// </summary>
        /// <param name="blnClearChildren"></param>
        internal void ClearCachedValues(bool blnClearChildren)
        {
            if (this.mobjCacheItems != null)
            {
                this.mobjCacheItems.mblnUseValueString = false;
                this.mobjCacheItems.mobjLastValue = null;
                this.mobjCacheItems.mblnUseShouldSerialize = false;
            }
            if (blnClearChildren)
            {
                for (int intIndex = 0; intIndex < this.ChildCollection.Count; intIndex++)
                {
                    this.ChildCollection.GetEntry(intIndex).ClearCachedValues();
                }
            }
        }

        /// <summary>
        /// Convert the current text value to object using the type convertor
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public object ConvertTextToValue(string strText)
        {
            if (this.TypeConverter.CanConvertFrom(this, typeof(string)))
            {
                return this.TypeConverter.ConvertFromString(this, strText);
            }
            return strText;
        }

        /// <summary>
        /// Create the root property grid
        /// </summary>
        /// <param name="objPropertyGridView"></param>
        /// <param name="arrObjects"></param>
        /// <param name="objServiceProvider"></param>
        /// <param name="objCurrentHost"></param>
        /// <param name="objPropertyTab"></param>
        /// <param name="objInitialSortType"></param>
        /// <returns></returns>
        internal static IRootGridEntry Create(PropertyGridView objPropertyGridView, object[] arrObjects, IServiceProvider objServiceProvider, IDesignerHost objCurrentHost, PropertyTab objPropertyTab, Gizmox.WebGUI.Forms.PropertySort objInitialSortType)
        {
            IRootGridEntry objRootGridEntry = null;
            if ((arrObjects == null) || (arrObjects.Length == 0))
            {
                return null;
            }
            try
            {
                if (arrObjects.Length == 1)
                {
                    return new SingleSelectRootGridEntry(objPropertyGridView, arrObjects[0], objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
                }
                objRootGridEntry = new MultiSelectRootGridEntry(objPropertyGridView, arrObjects, objServiceProvider, objCurrentHost, objPropertyTab, objInitialSortType);
            }
            catch (Exception)
            {
                throw;
            }
            return objRootGridEntry;
        }

        /// <summary>
        /// Creates the grid entry children
        /// </summary>
        /// <returns></returns>
        protected virtual bool CreateChildren()
        {
            return this.CreateChildren(false);
        }

        /// <summary>
        /// Creates the grid entry children
        /// </summary>
        /// <param name="blnDiffOldChildren"></param>
        /// <returns></returns>
        protected virtual bool CreateChildren(bool blnDiffOldChildren)
        {
            if (!this.GetStateSet(mcntFlagsExpandable))
            {
                if (this.mobjChildCollection != null)
                {
                    this.mobjChildCollection.Clear();
                }
                else
                {
                    this.mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
                }
                return false;
            }
            if ((!blnDiffOldChildren && (this.mobjChildCollection != null)) && (this.mobjChildCollection.Count > 0))
            {
                return true;
            }
            GridEntry[] arrEntries = this.GetPropEntries(this, this.PropertyValue, this.PropertyType);
            bool blnFlag1 = (arrEntries != null) && (arrEntries.Length > 0);
            if ((blnDiffOldChildren && (this.mobjChildCollection != null)) && (this.mobjChildCollection.Count > 0))
            {
                bool blnFlag2 = true;
                if (arrEntries.Length == this.mobjChildCollection.Count)
                {
                    for (int num1 = 0; num1 < arrEntries.Length; num1++)
                    {
                        if (!arrEntries[num1].NonParentEquals(this.mobjChildCollection[num1]))
                        {
                            blnFlag2 = false;
                            break;
                        }
                    }
                }
                else
                {
                    blnFlag2 = false;
                }
                if (blnFlag2)
                {
                    return true;
                }
            }
            if (!blnFlag1)
            {
                this.SetState(mcntFlagsExpandableFailed, true);
                if (this.mobjChildCollection != null)
                {
                    this.mobjChildCollection.Clear();
                }
                else
                {
                    this.mobjChildCollection = new GridEntryCollection(this, new GridEntry[0]);
                }
                if (this.InternalExpanded)
                {
                    this.InternalExpanded = false;
                }
                return blnFlag1;
            }
            if (this.mobjChildCollection != null)
            {
                this.mobjChildCollection.Clear();
                this.mobjChildCollection.AddRange(arrEntries);
                return blnFlag1;
            }
            this.mobjChildCollection = new GridEntryCollection(this, arrEntries);
            return blnFlag1;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="blnDisposing"></param>
        protected virtual void Dispose(bool blnDisposing)
        {
            this.State |= -2147483648;
            this.SetState(0x2000, true);
            this.mobjCacheItems = null;
            this.mobjConverter = null;
            this.mobjEditor = null;
            if (blnDisposing)
            {
                this.DisposeChildren();
            }
        }

        /// <summary>
        /// Dispose recursivly
        /// </summary>
        public virtual void DisposeChildren()
        {
            if (this.mobjChildCollection != null)
            {
                this.mobjChildCollection.Dispose();
                this.mobjChildCollection = null;
            }
        }

        /// <summary>
        /// Edit the current property value through its Web UI Editor
        /// </summary>
        internal virtual void EditPropertyValue()
        {
            if (this.UITypeEditor != null)
            {
                try
                {
                    object obj1 = this.PropertyValue;

                    //Creating event args 
                    ShowingTypeEditorEventArgs objEventArgs = new ShowingTypeEditorEventArgs(this);

                    // Calling the before edit value event
                    this.mobjOwnerPropertyGrid.OnShowingEditTypeEditor(objEventArgs);

                    if (!objEventArgs.IsCancelled)
                    {
                        this.UITypeEditor.EditValue(this, this, obj1, new WebUITypeEditorHandler(EditPropertyValue_Callback));
                    }

                }
                catch (Exception objException1)
                {

                    MessageBox.Show(objException1.Message, SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, 0);
                }
            }
        }

        /// <summary>
        /// Handle property editing callback response 
        /// </summary>
        /// <param name="objValue"></param>
        protected virtual void EditPropertyValue_Callback(object objValue)
        {
            try
            {
                if (!this.Disposed)
                {
                    object obj1 = this.PropertyValue;
                    if ((objValue != obj1) && this.IsValueEditable)
                    {
                        if (this.OwnerGridView != null)
                        {
                            this.OwnerGridView.CommitValue(this, objValue);
                        }

                        //Check if current entry should be expandable and has no childs.
                        EnsureGridEntryChildren();
                    }

                    this.RecreateChildren();
                }
            }
            catch (Exception objException1)
            {

                MessageBox.Show(objException1.Message, SR.GetString("PBRSErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, 0);
            }
        }

        /// <summary>
        /// Checks if a grid entry is equal to this one
        /// </summary>
        /// <param name="objObject"></param>
        /// <returns></returns>
        public override bool Equals(object objObject)
        {
            if (this.NonParentEquals(objObject))
            {
                return (((GridEntry)objObject).ParentGridEntry == this.ParentGridEntry);
            }
            return false;
        }

        /// <summary>
        /// Search for property value
        /// </summary>
        /// <param name="strPropertyName"></param>
        /// <param name="objPropertyType"></param>
        /// <returns></returns>
        public virtual object FindPropertyValue(string strPropertyName, Type objPropertyType)
        {
            object obj1 = this.GetValueOwner();
            PropertyDescriptor objPropertyDescriptor1 = TypeDescriptor.GetProperties(obj1)[strPropertyName];
            if ((objPropertyDescriptor1 != null) && (objPropertyDescriptor1.PropertyType == objPropertyType))
            {
                return objPropertyDescriptor1.GetValue(obj1);
            }
            if (this.mobjParentGridEntry != null)
            {
                return this.mobjParentGridEntry.FindPropertyValue(strPropertyName, objPropertyType);
            }
            return null;
        }

        /// <summary>
        /// Get index from a given child grid entry
        /// </summary>
        /// <param name="objGridEntry"></param>
        /// <returns></returns>
        internal virtual int GetChildIndex(GridEntry objGridEntry)
        {
            return this.Children.GetEntry(objGridEntry);
        }

        /// <summary>
        /// Get the value for child grid entrys
        /// </summary>
        /// <param name="objChildEntry"></param>
        /// <returns></returns>
        public virtual object GetChildValueOwner(GridEntry objChildEntry)
        {
            return this.PropertyValue;
        }

        public virtual IComponent[] GetComponents()
        {
            IComponent component1 = this.Component;
            if (component1 != null)
            {
                return new IComponent[] { component1 };
            }
            return null;
        }

        /// <summary>
        /// Gets a specifiec state
        /// </summary>
        /// <param name="intFlag"></param>
        /// <returns></returns>
        protected virtual bool GetStateSet(int intFlag)
        {
            return ((intFlag & this.Flags) != 0);
        }

        /// <summary>
        /// Gets the current grid entry hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            object obj1 = this.PropertyLabel;
            object obj2 = this.PropertyType;
            uint num1 = (obj1 == null) ? 0 : ((uint)obj1.GetHashCode());
            uint num2 = (obj2 == null) ? 0 : ((uint)obj2.GetHashCode());
            uint num3 = (uint)base.GetType().GetHashCode();
            return (int)((num1 ^ ((num2 << 13) | (num2 >> 0x13))) ^ ((num3 << 0x1a) | (num3 >> 6)));
        }

        /// <summary>
        /// Gets a flag indicating
        /// </summary>
        /// <param name="strValueString"></param>
        /// <returns></returns>
        internal bool GetMultipleLines(string strValueString)
        {
            if ((strValueString.IndexOf('\n') <= 0) && (strValueString.IndexOf('\r') <= 0))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the child grid entries
        /// </summary>
        /// <param name="objParentGridEntry"></param>
        /// <param name="objObject"></param>
        /// <param name="objType"></param>
        /// <returns></returns>
        protected virtual GridEntry[] GetPropEntries(GridEntry objParentGridEntry, object objObject, Type objType)
        {
            if (objObject == null)
            {
                return null;
            }
            GridEntry[] arrGridEntries = null;
            Attribute[] arrAttributes = new Attribute[this.BrowsableAttributes.Count];
            this.BrowsableAttributes.CopyTo(arrAttributes, 0);
            PropertyTab objPropertyTab = this.CurrentTab;
            try
            {
                bool blnFlag1 = this.ForceReadOnly;
                if (!blnFlag1)
                {
                    ReadOnlyAttribute attribute1 = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(objObject)[typeof(ReadOnlyAttribute)];
                    blnFlag1 = (attribute1 != null) && !attribute1.IsDefaultAttribute();
                }
                if (this.TypeConverter.GetPropertiesSupported(this) || this.AlwaysAllowExpand)
                {
                    PropertyDescriptorCollection objPropertyDescriptions = null;
                    System.ComponentModel.PropertyDescriptor objPropertyDescription = null;
                    if (objPropertyTab != null)
                    {
                        objPropertyDescriptions = objPropertyTab.GetProperties(this, objObject, arrAttributes);
                        objPropertyDescription = objPropertyTab.GetDefaultProperty(objObject);
                    }
                    else
                    {
                        objPropertyDescriptions = this.TypeConverter.GetProperties(this, objObject, arrAttributes);
                        objPropertyDescription = TypeDescriptor.GetDefaultProperty(objObject);
                    }
                    if (objPropertyDescriptions == null)
                    {
                        return null;
                    }
                    if ((this.menmPropertySort & Gizmox.WebGUI.Forms.PropertySort.Alphabetical) != Gizmox.WebGUI.Forms.PropertySort.NoSort)
                    {
                        if ((objType == null) || !objType.IsArray)
                        {
                            objPropertyDescriptions = objPropertyDescriptions.Sort(GridEntry.DisplayNameComparer);
                        }
                        System.ComponentModel.PropertyDescriptor[] arrPropertyDescriptors = new System.ComponentModel.PropertyDescriptor[objPropertyDescriptions.Count];
                        objPropertyDescriptions.CopyTo(arrPropertyDescriptors, 0);
                        objPropertyDescriptions = new PropertyDescriptorCollection(this.SortParenProperties(arrPropertyDescriptors));
                    }
                    if ((objPropertyDescription == null) && (objPropertyDescriptions.Count > 0))
                    {
                        objPropertyDescription = objPropertyDescriptions[0];
                    }
                    if (((objPropertyDescriptions == null) || (objPropertyDescriptions.Count == 0)) && (((objType != null) && objType.IsArray) && (objObject != null)))
                    {
                        Array objArray = (Array)objObject;
                        arrGridEntries = new GridEntry[objArray.Length];
                        for (int intIndex = 0; intIndex < arrGridEntries.Length; intIndex++)
                        {
                            arrGridEntries[intIndex] = new ArrayElementGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, intIndex);
                        }
                        return arrGridEntries;
                    }
                    bool blnCreateInstanceSupported = this.TypeConverter.GetCreateInstanceSupported(this);
                    arrGridEntries = new GridEntry[objPropertyDescriptions.Count];
                    int num2 = 0;
                    foreach (PropertyDescriptor objPropertyDescriptor2 in objPropertyDescriptions)
                    {
                        GridEntry objGridEntry;
                        bool blnFlag3 = false;
                        try
                        {
                            object obj1 = objObject;
                            if (objObject is ICustomTypeDescriptor)
                            {
                                obj1 = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(objPropertyDescriptor2);
                            }
                            objPropertyDescriptor2.GetValue(obj1);
                        }
                        catch (Exception)
                        {
                            blnFlag3 = true;
                        }
                        if (blnCreateInstanceSupported)
                        {
                            objGridEntry = new ImmutablePropertyDescriptorGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, objPropertyDescriptor2, blnFlag3);
                        }
                        else
                        {

                            objGridEntry = new PropertyDescriptorGridEntry(this.mobjOwnerPropertyGrid, objParentGridEntry, objPropertyDescriptor2, blnFlag3);

                            // Verifiy expanded children exists
                            if (objGridEntry.IsExpandable)
                            {
                                objGridEntry.CreateChildren();
                            }

                        }
                        if (blnFlag1)
                        {
                            objGridEntry.State |= 0x400;
                        }
                        if (objPropertyDescriptor2.Equals(objPropertyDescription))
                        {
                            this.DefaultChild = objGridEntry;
                        }
                        arrGridEntries[num2++] = objGridEntry;
                    }
                }
                return arrGridEntries;
            }
            catch (Exception)
            {
            }
            return arrGridEntries;
        }

        /// <summary>
        /// Get the property text value
        /// </summary>
        /// <returns></returns>
        public virtual string GetPropertyTextValue()
        {
            return this.GetPropertyTextValue(this.PropertyValue);
        }

        /// <summary>
        /// Get the text value of a specific object value
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public virtual string GetPropertyTextValue(object objValue)
        {
            if (CommonUtils.IsMono)
            {
                Char emptyChar = new char();
                if (objValue is char && (char)objValue == emptyChar)
                {
                    return string.Empty;
                }
            }
            string strValue = null;
            System.ComponentModel.TypeConverter objTypeConvertor = this.TypeConverter;
            try
            {
                strValue = objTypeConvertor.ConvertToString(this, objValue);
            }
            catch (Exception)
            {
            }
            if (strValue == null)
            {
                strValue = string.Empty;
            }
            return strValue;
        }

        /// <summary>
        /// Get value list
        /// </summary>
        /// <returns></returns>
        public virtual object[] GetPropertyValueList()
        {
            ICollection objCollection = this.TypeConverter.GetStandardValues(this);
            if (objCollection != null)
            {
                object[] arrValues = new object[objCollection.Count];
                objCollection.CopyTo(arrValues, 0);
                return arrValues;
            }
            return new object[0];
        }


        /// <summary>
        /// Get a specific service (service propvider implentation)
        /// </summary>
        /// <param name="objServiceType"></param>
        /// <returns></returns>
        public virtual object GetService(Type objServiceType)
        {
            if (objServiceType == typeof(GridItem))
            {
                return this;
            }
            if (this.mobjParentGridEntry != null)
            {
                return this.mobjParentGridEntry.GetService(objServiceType);
            }
            return null;
        }

        /// <summary>
        /// Return information used for testing
        /// </summary>
        /// <returns></returns>
        public virtual string GetTestingInfo()
        {
            string strText1 = "object = (";
            string strText2 = this.GetPropertyTextValue();
            if (strText2 == null)
            {
                strText2 = "(null)";
            }
            else
            {
                strText2 = strText2.Replace('\0', ' ');
            }
            Type objType1 = this.PropertyType;
            if (objType1 == null)
            {
                objType1 = typeof(object);
            }
            strText1 = strText1 + this.FullLabel;
            object obj1 = strText1;
            return string.Concat(new object[] { obj1, "), property = (", this.PropertyLabel, ",", objType1.AssemblyQualifiedName, "), value = [", strText2, "], expandable = ", this.Expandable.ToString(), ", readOnly = ", this.ShouldRenderReadOnly });
        }

        /// <summary>
        /// Get the value of the parent grid entry
        /// </summary>
        /// <returns></returns>
        public virtual object GetValueOwner()
        {
            if (this.mobjParentGridEntry == null)
            {
                return this.PropertyValue;
            }
            return this.mobjParentGridEntry.GetChildValueOwner(this);
        }

        /// <summary>
        /// Get the value of a merged value
        /// </summary>
        /// <returns></returns>
        public virtual object[] GetValueOwners()
        {
            object objValue = this.GetValueOwner();
            if (objValue != null)
            {
                return new object[] { objValue };
            }
            return null;
        }

        /// <summary>
        /// Get current value type
        /// </summary>
        /// <returns></returns>
        public virtual Type GetValueType()
        {
            return this.PropertyType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objObject"></param>
        /// <returns></returns>
        internal virtual bool NonParentEquals(object objObject)
        {
            if (objObject == this)
            {
                return true;
            }
            if (objObject != null)
            {
                if (!(objObject is GridEntry))
                {
                    return false;
                }
                GridEntry objGridEntry = (GridEntry)objObject;
                if (objGridEntry.PropertyLabel.Equals(this.PropertyLabel) && objGridEntry.PropertyType.Equals(this.PropertyType))
                {
                    return (objGridEntry.PropertyDepth == this.PropertyDepth);
                }
            }
            return false;
        }

        /// <summary>
        /// Notifies child value change
        /// </summary>
        /// <param name="objGridEntry"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        internal virtual bool NotifyChildValue(GridEntry objGridEntry, int intType)
        {
            return objGridEntry.NotifyValueGivenParent(objGridEntry.GetValueOwner(), intType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intType"></param>
        /// <returns></returns>
        internal virtual bool NotifyValue(int intType)
        {
            if (this.mobjParentGridEntry == null)
            {
                return true;
            }
            return this.mobjParentGridEntry.NotifyChildValue(this, intType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objObject"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        internal virtual bool NotifyValueGivenParent(object objObject, int intType)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnComponentChanged()
        {
            if (this.ComponentChangeService != null)
            {
                this.ComponentChangeService.OnComponentChanged(this.GetValueOwner(), this.PropertyDescriptor, null, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool OnComponentChanging()
        {
            if (this.ComponentChangeService != null)
            {
                try
                {
                    this.ComponentChangeService.OnComponentChanging(this.GetValueOwner(), this.PropertyDescriptor);
                }
                catch (CheckoutException objException1)
                {
                    if (objException1 != CheckoutException.Canceled)
                    {
                        throw objException1;
                    }
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void RecreateChildren()
        {
            this.RecreateChildren(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intOldCount"></param>
        internal void RecreateChildren(int intOldCount)
        {
            bool blnFlag1 = this.InternalExpanded || (intOldCount > 0);
            if (intOldCount == -1)
            {
                intOldCount = this.VisibleChildCount;
            }
            this.ResetState();
            if (intOldCount != 0)
            {
                foreach (GridEntry objGridEntry in this.ChildCollection)
                {
                    objGridEntry.RecreateChildren();
                }
                this.DisposeChildren();
                this.InternalExpanded = blnFlag1;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Refresh()
        {
            Type objType1 = this.PropertyType;
            if ((objType1 != null) && objType1.IsArray)
            {
                this.CreateChildren(true);
            }
            if (this.mobjChildCollection != null)
            {
                if ((this.InternalExpanded && (this.mobjCacheItems != null)) && ((this.mobjCacheItems.mobjLastValue != null) && (this.mobjCacheItems.mobjLastValue != this.PropertyValue)))
                {
                    this.ClearCachedValues();
                    this.RecreateChildren();
                    return;
                }
                if (this.InternalExpanded)
                {
                    foreach (object obj1 in this.mobjChildCollection)
                    {
                        ((GridEntry)obj1).Refresh();
                    }
                }
                else
                {
                    this.DisposeChildren();
                }
            }
            this.ClearCachedValues();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ResetPropertyValue()
        {
            this.NotifyValue(mcntNotifyReset);
            this.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void ResetState()
        {
            this.Flags = 0;
            this.ClearCachedValues();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Select()
        {
            if (!this.Disposed)
            {
                try
                {
                    this.GridEntryHost.SelectedGridEntry = this;
                    return true;
                }
                catch
                {
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="blnValue"></param>
        protected virtual void SetState(int intFlag, bool blnValue)
        {
            this.SetFlag(intFlag, blnValue ? intFlag : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="intValue"></param>
        protected virtual void SetFlag(int intFlag, int intValue)
        {
            this.Flags = (this.Flags & ~intFlag) | intValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intValidFlag"></param>
        /// <param name="intFlag"></param>
        /// <param name="blnValue"></param>
        protected virtual void SetFlag(int intValidFlag, int intFlag, bool blnValue)
        {
            this.SetFlag((int)(intValidFlag | intFlag), (int)(intValidFlag | (blnValue ? intFlag : 0)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public virtual bool SetPropertyTextValue(string strValue)
        {
            return this.SetPropertyTextValue(strValue, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="blnRequireUpdate"></param>
        /// <returns></returns>
        internal virtual bool SetPropertyTextValue(string strValue, bool blnRequireUpdate)
        {
            bool blnFlag1 = (this.mobjChildCollection != null) && (this.mobjChildCollection.Count > 0);
            this.SetPropertyValue(this.ConvertTextToValue(strValue), blnRequireUpdate);
            this.CreateChildren();
            bool blnFlag2 = (this.mobjChildCollection != null) && (this.mobjChildCollection.Count > 0);
            return (blnFlag1 != blnFlag2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual bool ShouldSerializePropertyValue()
        {
            if (this.mobjCacheItems != null)
            {
                if (this.mobjCacheItems.mblnUseShouldSerialize)
                {
                    return this.mobjCacheItems.mblnLastShouldSerialize;
                }
                this.mobjCacheItems.mblnLastShouldSerialize = this.NotifyValue(mcntNotifyShouldPresist);
                this.mobjCacheItems.mblnUseShouldSerialize = true;
            }
            else
            {
                this.mobjCacheItems = new CacheItems();
                this.mobjCacheItems.mblnLastShouldSerialize = this.NotifyValue(mcntNotifyShouldPresist);
                this.mobjCacheItems.mblnUseShouldSerialize = true;
            }
            return this.mobjCacheItems.mblnLastShouldSerialize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrPropertyDescriptors"></param>
        /// <returns></returns>
        private PropertyDescriptor[] SortParenProperties(System.ComponentModel.PropertyDescriptor[] arrPropertyDescriptors)
        {
            PropertyDescriptor[] arrDescriptors = null;
            int num1 = 0;
            for (int num2 = 0; num2 < arrPropertyDescriptors.Length; num2++)
            {
                if (((ParenthesizePropertyNameAttribute)arrPropertyDescriptors[num2].Attributes[typeof(ParenthesizePropertyNameAttribute)]).NeedParenthesis)
                {
                    if (arrDescriptors == null)
                    {
                        arrDescriptors = new System.ComponentModel.PropertyDescriptor[arrPropertyDescriptors.Length];
                    }
                    arrDescriptors[num1++] = arrPropertyDescriptors[num2];
                    arrPropertyDescriptors[num2] = null;
                }
            }
            if (num1 > 0)
            {
                for (int num3 = 0; num3 < arrPropertyDescriptors.Length; num3++)
                {
                    if (arrPropertyDescriptors[num3] != null)
                    {
                        arrDescriptors[num1++] = arrPropertyDescriptors[num3];
                    }
                }
                arrPropertyDescriptors = arrDescriptors;
            }
            return arrPropertyDescriptors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (base.GetType().FullName + " " + this.PropertyLabel);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual bool AllowMerge
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual bool AlwaysAllowExpand
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual AttributeCollection Attributes
        {
            get
            {
                return TypeDescriptor.GetAttributes(this.PropertyType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual AttributeCollection BrowsableAttributes
        {
            get
            {
                if (this.mobjParentGridEntry != null)
                {
                    return this.mobjParentGridEntry.BrowsableAttributes;
                }
                return null;
            }
            set
            {
                this.mobjParentGridEntry.BrowsableAttributes = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected GridEntryCollection ChildCollection
        {
            get
            {
                if (this.mobjChildCollection == null)
                {
                    //this.CreateChildren();
                    this.mobjChildCollection = new GridEntryCollection(this, null);

                }
                return this.mobjChildCollection;
            }
            set
            {
                if (this.mobjChildCollection != value)
                {
                    if (this.mobjChildCollection != null)
                    {
                        this.mobjChildCollection.Dispose();
                        this.mobjChildCollection = null;
                    }
                    this.mobjChildCollection = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ChildCount
        {
            get
            {
                if (this.Children != null)
                {
                    return this.Children.Count;
                }
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual GridEntryCollection Children
        {
            get
            {
                if ((this.mobjChildCollection == null) && !this.Disposed)
                {
                    this.CreateChildren();
                }
                return this.mobjChildCollection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IComponent Component
        {
            get
            {
                object obj1 = this.GetValueOwner();
                if (obj1 is IComponent)
                {
                    return (IComponent)obj1;
                }
                if (this.mobjParentGridEntry != null)
                {
                    return this.mobjParentGridEntry.Component;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual IComponentChangeService ComponentChangeService
        {
            get
            {
                return this.mobjParentGridEntry.ComponentChangeService;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual IContainer Container
        {
            get
            {
                IComponent component1 = this.Component;
                if (component1 != null)
                {
                    ISite objSite = component1.Site;
                    if (objSite != null)
                    {
                        return objSite.Container;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual PropertyTab CurrentTab
        {
            get
            {
                if (this.mobjParentGridEntry != null)
                {
                    return this.mobjParentGridEntry.CurrentTab;
                }
                return null;
            }
            set
            {
                if (this.mobjParentGridEntry != null)
                {
                    this.mobjParentGridEntry.CurrentTab = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual GridEntry DefaultChild
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual IDesignerHost DesignerHost
        {
            get
            {
                if (this.mobjParentGridEntry != null)
                {
                    return this.mobjParentGridEntry.DesignerHost;
                }
                return null;
            }
            set
            {
                if (this.mobjParentGridEntry != null)
                {
                    this.mobjParentGridEntry.DesignerHost = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal bool Disposed
        {
            get
            {
                return this.GetStateSet(0x2000);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual bool Enumerable
        {
            get
            {
                return ((this.Flags & 2) != 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Expandable
        {
            get
            {
                bool blnFlag1 = this.GetStateSet(mcntFlagsExpandable);
                if ((blnFlag1 && (this.mobjChildCollection != null)) && (this.mobjChildCollection.Count > 0))
                {
                    return true;
                }
                if (this.GetStateSet(mcntFlagsExpandableFailed))
                {
                    return false;
                }
                if ((blnFlag1 && ((this.mobjCacheItems == null) || (this.mobjCacheItems.mobjLastValue == null))) && (this.PropertyValue == null))
                {
                    blnFlag1 = false;
                }
                return blnFlag1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Expanded
        {
            get
            {
                return this.InternalExpanded;
            }
            set
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual int Flags
        {
            get
            {
                // PG:TODO
                if ((this.State & -2147483648) == 0)
                {
                    this.State |= -2147483648;
                    TypeConverter objConverter1 = this.TypeConverter;
                    WebUITypeEditor objEditor = this.UITypeEditor;

                    object objInstance = this.Instance;
                    bool blnReadOnly = this.ForceReadOnly;
                    bool blnTextEditable = objEditor != null ? objEditor.IsTextEditable : true;
                    if (objInstance != null)
                    {
                        blnReadOnly |= TypeDescriptor.GetAttributes(objInstance).Contains(InheritanceAttribute.InheritedReadOnly);
                    }
                    if (objConverter1.GetStandardValuesSupported(this))
                    {
                        this.State |= 2;
                    }
                    // Set text editable value
                    if (!blnReadOnly && blnTextEditable && objConverter1.CanConvertFrom(this, typeof(string)) && !objConverter1.GetStandardValuesExclusive(this))
                    {
                        this.State |= 1;
                    }
                    bool blnIsImmutable = TypeDescriptor.GetAttributes(this.PropertyType)[typeof(ImmutableObjectAttribute)].Equals(ImmutableObjectAttribute.Yes);
                    bool blnCanCreateInstance = blnIsImmutable || objConverter1.GetCreateInstanceSupported(this);
                    if (blnCanCreateInstance)
                    {
                        this.State |= 0x200;
                    }
                    if (objConverter1.GetPropertiesSupported(this))
                    {
                        this.State |= 0x20000;
                        if ((!blnReadOnly && ((this.State & 1) == 0)) && !blnIsImmutable)
                        {
                            this.State |= 0x80;
                        }
                    }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    if (this.Attributes.Contains(PasswordPropertyTextAttribute.Yes))
                    {
                        this.State |= 0x1000;
                    }
#endif
                    if (objEditor != null)
                    {


                        if (!blnReadOnly)
                        {
                            switch (objEditor.GetEditStyle(this))
                            {
                                case UITypeEditorEditStyle.Modal:
                                    this.State |= 0x10;
                                    if (!blnCanCreateInstance && !this.PropertyType.IsValueType)
                                    {
                                        this.State |= 0x80;
                                    }
                                    break;

                                case UITypeEditorEditStyle.DropDown:
                                    this.State |= 0x20;
                                    break;
                            }
                        }
                    }
                }
                return this.State;
            }
            set
            {
                this.State = value;
            }
        }



        internal virtual bool ForceReadOnly
        {
            get
            {
                return ((this.State & 0x400) != 0);
            }
        }

        public string FullLabel
        {
            get
            {
                string strText1 = null;
                if (this.mobjParentGridEntry != null)
                {
                    strText1 = this.mobjParentGridEntry.FullLabel;
                }
                if (strText1 != null)
                {
                    strText1 = strText1 + ".";
                }
                else
                {
                    strText1 = "";
                }
                return (strText1 + this.PropertyLabel);
            }
        }

        internal virtual PropertyGridView GridEntryHost
        {
            get
            {
                if (this.mobjParentGridEntry != null)
                {
                    return this.mobjParentGridEntry.GridEntryHost;
                }
                return null;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override GridItemCollection GridItems
        {
            get
            {
                if (this.Disposed)
                {
                    throw new ObjectDisposedException(SR.GetString("GridItemDisposed"));
                }
                if ((this.IsExpandable && (this.mobjChildCollection != null)) && (this.mobjChildCollection.Count == 0))
                {
                    this.CreateChildren();
                }
                return this.Children;
            }
        }

        public override Gizmox.WebGUI.Forms.GridItemType GridItemType
        {
            get
            {
                return Gizmox.WebGUI.Forms.GridItemType.Property;
            }
        }

        internal virtual bool HasValue
        {
            get
            {
                return true;
            }
        }

        public virtual string HelpKeyword
        {
            get
            {
                string strText1 = null;
                if (this.mobjParentGridEntry != null)
                {
                    strText1 = this.mobjParentGridEntry.HelpKeyword;
                }
                if (strText1 == null)
                {
                    strText1 = string.Empty;
                }
                return strText1;
            }
        }

        internal virtual string HelpKeywordInternal
        {
            get
            {
                return this.HelpKeyword;
            }
        }

        public virtual object Instance
        {
            get
            {
                object obj1 = this.GetValueOwner();
                if ((this.mobjParentGridEntry != null) && (obj1 == null))
                {
                    return this.mobjParentGridEntry.Instance;
                }
                return obj1;
            }
        }

        internal virtual bool InternalExpanded
        {
            get
            {
                if ((this.mobjChildCollection != null) && (this.mobjChildCollection.Count != 0))
                {
                    return this.GetStateSet(mcntFlagsExpand);
                }
                return false;
            }
            set
            {
                if (this.Expandable && (value != this.InternalExpanded))
                {
                    if ((this.mobjChildCollection != null) && (this.mobjChildCollection.Count > 0))
                    {
                        this.SetState(mcntFlagsExpand, value);
                    }
                    else
                    {
                        this.SetState(mcntFlagsExpand, false);
                        if (value)
                        {
                            bool blnFlag1 = this.CreateChildren();
                            this.SetState(mcntFlagsExpand, blnFlag1);
                        }
                    }
                }
            }
        }

        public virtual bool IsExpandable
        {
            get
            {
                return this.Expandable;
            }
            set
            {
                if (value != this.GetStateSet(mcntFlagsExpandable))
                {
                    this.SetState(mcntFlagsExpandableFailed, false);
                    this.SetState(mcntFlagsExpandable, value);
                }
            }
        }

        public virtual bool IsTextEditable
        {
            get
            {
                if (this.IsValueEditable)
                {
                    return ((this.Flags & 1) != 0);
                }
                return false;
            }
        }

        public virtual bool IsValueEditable
        {
            get
            {
                if (!this.ForceReadOnly)
                {
                    return (0 != (this.Flags & 0x33));
                }
                return false;
            }
        }

        public override string Label
        {
            get
            {
                return this.PropertyLabel;
            }
        }

        public virtual bool NeedsCustomEditorButton
        {
            get
            {
                if ((this.Flags & 0x10) == 0)
                {
                    return false;
                }
                if (!this.IsValueEditable)
                {
                    return ((this.Flags & 0x80) != 0);
                }
                return true;
            }
        }

        public virtual bool NeedsDropDownButton
        {
            get
            {
                return ((this.Flags & 0x20) != 0);
            }
        }

        [Browsable(false)]
        public override PropertyGrid OwnerGrid
        {
            get
            {
                return this.mobjOwnerPropertyGrid;
            }
        }

        public PropertyGridView OwnerGridView
        {
            get
            {
                if (this.mobjOwnerPropertyGrid != null)
                {
                    return this.mobjOwnerPropertyGrid.PropertyGridView;
                }
                else
                {
                    return null;
                }
            }
        }

        public override GridItem Parent
        {
            get
            {
                if (this.Disposed)
                {
                    throw new ObjectDisposedException(SR.GetString("GridItemDisposed"));
                }
                return this.ParentGridEntry;
            }
        }

        public virtual GridEntry ParentGridEntry
        {
            get
            {
                return this.mobjParentGridEntry;
            }
            set
            {
                this.mobjParentGridEntry = value;
                if (value != null)
                {
                    this.mintPropertyDepth = value.PropertyDepth + 1;
                    if (this.mobjChildCollection != null)
                    {
                        for (int num1 = 0; num1 < this.mobjChildCollection.Count; num1++)
                        {
                            this.mobjChildCollection.GetEntry(num1).ParentGridEntry = this;
                        }
                    }
                }
            }
        }

        public virtual string PropertyCategory
        {
            get
            {
                return CategoryAttribute.Default.Category;
            }
        }

        public virtual int PropertyDepth
        {
            get
            {
                return this.mintPropertyDepth;
            }
        }

        public virtual string PropertyDescription
        {
            get
            {
                return null;
            }
        }

        public override System.ComponentModel.PropertyDescriptor PropertyDescriptor
        {
            get
            {
                return null;
            }
        }

        public virtual string PropertyLabel
        {
            get
            {
                return null;
            }
        }

        public virtual string PropertyName
        {
            get
            {
                return this.PropertyLabel;
            }
        }

        public virtual Type PropertyType
        {
            get
            {
                object obj1 = this.PropertyValue;
                if (obj1 != null)
                {
                    return obj1.GetType();
                }
                return null;
            }
        }

        internal bool SetPropertyValue(object objValue, bool blnRequireUpdate)
        {
            if (this.PropertyValue != objValue)
            {
                this.PropertyValue = objValue;

                // Update ParentGrid for Expandable Property
                if (this.ParentGridEntry != null && this.ParentGridEntry.GridItemType == Forms.GridItemType.Property)
                {
                    this.ParentGridEntry.UpdateParams();
                }

                if (blnRequireUpdate)
                {
                    this.Update();
                }
                return true;
            }
            return false;
        }

        public virtual object PropertyValue
        {
            get
            {
                if (this.mobjCacheItems != null)
                {
                    return this.mobjCacheItems.mobjLastValue;
                }
                return null;
            }
            set
            {
            }
        }

        public virtual bool ShouldRenderPassword
        {
            get
            {
                return ((this.Flags & 0x1000) != 0);
            }
        }

        public virtual bool ShouldRenderReadOnly
        {
            get
            {
                if (this.ForceReadOnly)
                {
                    return true;
                }
                if ((this.Flags & 0x100) != 0)
                {
                    return true;
                }
                if (!this.IsValueEditable)
                {
                    return (0 == (this.Flags & 0x80));
                }
                return false;
            }
        }

        internal virtual System.ComponentModel.TypeConverter TypeConverter
        {
            get
            {
                if (this.mobjConverter == null)
                {
                    object obj1 = this.PropertyValue;
                    if (obj1 == null)
                    {
                        this.mobjConverter = TypeDescriptor.GetConverter(this.PropertyType);
                    }
                    else
                    {
                        this.mobjConverter = TypeDescriptor.GetConverter(obj1);
                    }
                }
                return this.mobjConverter;
            }
        }

        internal virtual WebUITypeEditor UITypeEditor
        {
            get
            {
                if ((this.mobjEditor == null) && (this.PropertyType != null))
                {
                    this.mobjEditor = (Gizmox.WebGUI.Forms.Design.WebUITypeEditor)WebUITypeEditor.GetEditor(this.PropertyType);
                }
                if (this.mobjEditor == null && this.TypeConverter != null && this.TypeConverter.GetStandardValuesExclusive(this))
                {
                    this.mobjEditor = new StandardValuesEditor(this.TypeConverter);
                }

                return this.mobjEditor;
            }
        }

        public override object Value
        {
            get
            {
                return this.PropertyValue;
            }
        }

        internal int VisibleChildCount
        {
            get
            {
                if (!this.Expanded)
                {
                    return 0;
                }
                int num1 = this.ChildCount;
                int num2 = num1;
                for (int num3 = 0; num3 < num1; num3++)
                {
                    num2 += this.ChildCollection.GetEntry(num3).VisibleChildCount;
                }
                return num2;
            }
        }

        #endregion

        #region CacheItems Class

        [Serializable()]
        private class CacheItems
        {

            public bool mblnLastShouldSerialize;
            public object mobjLastValue;
            public Font mobjLastValueFont;
            public string mstrLastValueString;
            public int mintLastValueTextWidth;
            public bool mblnUseShouldSerialize;
            public bool mblnUseValueString;
        }

        #endregion

        #region DisplayNameSortComparer Class

        [Serializable()]
        public class DisplayNameSortComparer : IComparer
        {
            public int Compare(object objLeft, object objRight)
            {
                return string.Compare(((PropertyDescriptor)objLeft).DisplayName, ((PropertyDescriptor)objRight).DisplayName, true, CultureInfo.CurrentCulture);
            }

        }

        #endregion

        #region IRegisteredComponentMember Members

        private bool IsRegistered
        {
            get
            {
                return this.GetValue<bool>(GridEntry.IsRegisteredProperty, false);
            }
            set
            {
                this.SetValue<bool>(GridEntry.IsRegisteredProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty IsRegisteredProperty = SerializableProperty.Register("IsRegistered", typeof(bool), typeof(GridEntry));




        /// <summary>
        /// The long property registration.
        /// </summary>
        private static readonly SerializableProperty MemberIDProperty = SerializableProperty.Register("MemberID", typeof(long), typeof(GridEntry));


        private void RegisterSelf()
        {
            if (!IsRegistered)
            {
                if (this.mobjOwnerPropertyGrid != null)
                {
                    this.mobjOwnerPropertyGrid.RegisterGridComponent(this);
                }
            }
        }

        bool IRegisteredComponentMember.IsRegistered
        {
            get
            {
                return IsRegistered;
            }
            set
            {
                IsRegistered = value;
            }
        }

        private long MemberID
        {
            get
            {
                return this.GetValue<long>(GridEntry.MemberIDProperty, 0);
            }
            set
            {
                this.SetValue<long>(GridEntry.MemberIDProperty, value);
            }
        }

        long IRegisteredComponentMember.MemberID
        {
            get
            {
                return MemberID;
            }
            set
            {
                MemberID = value;
            }
        }

        long IRegisteredComponentMember.OwnerID
        {
            get
            {
                return ((IRegisteredComponent)this.OwnerGridView).ID;
            }
        }


        void IEventHandler.FireEvent(IEvent objEvent)
        {
            this.FireEvent(objEvent);
        }

        internal void OnValueChangeError(Exception objException)
        {
            MessageBox.Show(objException.Message, "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Update();
        }

        /// <summary>
        /// Gets the event integer attribute value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="strAttribute">The attribute name.</param>
        /// <param name="intDefault">The default integer value.</param>
        /// <returns></returns>
        protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
        {
            string strValue = objEvent[strAttribute];
            if (CommonUtils.IsNullOrEmpty(strValue))
            {
                return intDefault;
            }
            else
            {
                return int.Parse(strValue);
            }
        }

        /// <summary>
        /// Gets the event buttons value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="enmDefault">The default value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
        {
            // Get the button property of the event
            string strButton = objEvent["BTN"];
            switch (strButton)
            {
                case "L":
                    return MouseButtons.Left;
                case "R":
                    return MouseButtons.Right;
                default:
                    return enmDefault;
            }
        }

        protected virtual void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "ValueChange":
                    try
                    {
                        // Get the new value out of the recieved event.
                        string strNewValue = CommonUtils.DecodeText(objEvent[WGAttributes.Value]);

                        // Preserve last value.
                        object objOldValue = this.PropertyValue;

                        // Validate new value through editor.
                        if (this.mobjEditor != null)
                        {
                            this.mobjEditor.ValidatePropertyValueInternal(strNewValue);
                        }

                        // Set property text new value.
                        if (this.OwnerGridView.CommitText(strNewValue, this))
                        {
                            //Check if current entry should be expandable and has no childs.
                            EnsureGridEntryChildren();
                        }
                    }
                    catch (Exception objException)
                    {
                        OnValueChangeError(objException);
                    }

                    break;
                case "ExpandChange":
                    this.SetState(mcntFlagsExpand, objEvent[WGAttributes.Value] == "1");
                    break;
                case "NavigateEditor":
                    EditPropertyValue();
                    break;
                case "Activated":
                    SetActive();
                    break;
                case "Click":
                    if (this.OwnerGrid != null)
                    {
                        this.OwnerGrid.FireClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    }
                    break;
                case "KeyDown":
                    if (this.OwnerGrid != null)
                    {
                        this.OwnerGrid.FireKeyDown(objEvent);
                    }
                    break;
            }
        }

        /// <summary>
        /// Ensures the grid entry children.
        /// </summary>
        private void EnsureGridEntryChildren()
        {
            // Check if current entry should be expandable and has no childs.
            if ((this.IsExpandable && (this.mobjChildCollection != null)) && (this.mobjChildCollection.Count == 0))
            {
                // Create new childs - if needed.
                if (this.CreateChildren())
                {
                    // If new childs has been created - update owner grid.
                    if (this.OwnerGridView != null)
                    {
                        this.OwnerGridView.Update();
                    }
                }
            }
        }

        private void SetActive()
        {
            if (OwnerGridView != null &&
                OwnerGridView.SelectedGridEntry != this)
            {
                OwnerGridView.SetActiveGridEntry(this);
                OwnerGridView.SelectedGridEntry = this;
            }
        }

        #region Render Related

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected virtual EventTypes GetCriticalEvents()
        {
            return EventTypes.None;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected virtual CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            if (this.OwnerGrid != null)
            {
                objEvents.Set(this.OwnerGrid.GetEntriesCriticalEventsData());
            }

            EventTypes objObseleteEvents = GetCriticalEvents();
            RegisteredComponent.MergeCriticalEventsWithObselete(ref objEvents, objObseleteEvents);

            return objEvents;
        }

        /// <summary>
        /// Renders the component event attributes.
        /// </summary>
        /// <param name="objContext">context.</param>
        /// <param name="objWriter">writer.</param>
        private void RenderComponentEventAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // Render critical events.
            CriticalEventsData objEvents = GetCriticalEventsData();
            if (objEvents.HasEvents)
            {
                string strCriticalEvents = objEvents.ToClientString();
                objWriter.WriteAttributeString(WGAttributes.Events, strCriticalEvents);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderComponentAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            // render control identifier
            objWriter.WriteAttributeString(WGAttributes.MemberID, MemberID.ToString());

            // don't waste bandwidth, assume equvalence if omitted
            if (this.ParentGridEntry != null)
            {
                objWriter.WriteAttributeString(WGAttributes.OwnerEntryID, this.ParentGridEntry.MemberID.ToString());
            }

            // Render owner if needed
            if (blnRenderOwner)
            {
                objWriter.WriteAttributeString(WGAttributes.OwnerID, ((IRegisteredComponentMember)this).OwnerID.ToString());
            }

            // render event attributes
            RenderComponentEventAttributes(objContext, objWriter);
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            // render component attributes
            RenderComponentAttributes(objContext, objWriter, blnRenderOwner);

            objWriter.WriteAttributeString(WGAttributes.Text, this.Label);

            if (this is CategoryGridEntry)
            {
                objWriter.WriteAttributeString(WGAttributes.Type, "C");
                if (this.Expanded) objWriter.WriteAttributeString(WGAttributes.Expanded, "1");

            }
            else
            {
                objWriter.WriteAttributeText(WGAttributes.Value, this.HasValue ? this.GetPropertyTextValue() : "");
                if (this.IsExpandable) objWriter.WriteAttributeString(WGAttributes.HasNodes, "1");
                if (!this.IsTextEditable) objWriter.WriteAttributeString(WGAttributes.ReadOnly, "0");
                if (this.Expanded) objWriter.WriteAttributeString(WGAttributes.Expanded, "1");
                if (!this.ShouldRenderReadOnly)
                {
                    if (this.NeedsCustomEditorButton)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Type, "B");
                    }
                    else if (this.NeedsDropDownButton)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Type, "D");
                    }
                }

                if (this.UITypeEditor is ColorEditor)
                {
                    ColorEditor objColorEditor = (ColorEditor)this.UITypeEditor;
                    objWriter.WriteAttributeString(WGAttributes.Color, CommonUtils.GetHtmlColor((Color)objColorEditor.GetEditorValueFromPropertyValueInternal(this.PropertyValue)));

                }

                objWriter.WriteAttributeString(WGAttributes.Depth, this.mintPropertyDepth.ToString());

            }
        }

        /// <summary>
        /// Renders the updated attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderUpdatedAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            // render component attributes
            RenderComponentAttributes(objContext, objWriter, blnRenderOwner);

            // Whenever this grid entry had child entries - force redrawing them.
            if (mobjChildCollection != null && mobjChildCollection.Count > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.ForceChildRedraw, "1");
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw) || IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeText(WGAttributes.Value, this.HasValue ? this.GetPropertyTextValue() : "", TextFilter.CarriageReturn | TextFilter.NewLine);
                if (this.UITypeEditor is ColorEditor)
                {
                    ColorEditor objColorEditor = (ColorEditor)this.UITypeEditor;
                    objWriter.WriteAttributeString(WGAttributes.Color, CommonUtils.GetHtmlColor((Color)objColorEditor.GetEditorValueFromPropertyValueInternal(this.PropertyValue)));

                }
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            GridItemCollection objChildCollection = this.GridItems;

            if (objChildCollection != null)
            {
                foreach (IRenderableComponentMember objGridEntry in objChildCollection)
                {
                    objGridEntry.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
                }
            }
        }

        /// <summary>
        /// Renders the component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        void IRenderableComponentMember.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            this.RenderControl(objContext, objWriter, lngRequestID, blnRenderOwner);
        }

        /// <summary>
        /// Checks if the current control needs rendering and
        /// continues to process sub tree
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            // Ensure Registered
            RegisterSelf();

            // if control is dirty
            if (IsDirty(lngRequestID))
            {
                // write control element tags
                objWriter.WriteStartElement(WGConst.Prefix, WGTags.PropertyGridEntry, WGConst.Namespace);

                // add generic attributes
                RenderAttributes(objContext, (IAttributeWriter)objWriter, blnRenderOwner);

                // close control element tag
                objWriter.WriteEndElement();

                // render control
                RenderControls(objContext, objWriter, 0, blnRenderOwner);

            }
            else
            {
                // if only control params are dirty
                if (IsDirtyAttributes(lngRequestID))
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);

                    // render control
                    RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID, blnRenderOwner);

                    // close control element tag
                    objWriter.WriteEndElement();

                    // render control
                    RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);

                }
                else
                {
                    // render control
                    RenderControls(objContext, objWriter, lngRequestID, blnRenderOwner);
                }
            }

        }

        #endregion

        #region Dirty Management

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public virtual void Update()
        {
            LastModified = GetCurrentTicks();
            menmLastModifiedParams = AttributeType.None;
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
        public virtual void Update(bool blnRedrawOnly)
        {
            if (blnRedrawOnly) UpdateParams(AttributeType.Redraw);
            else Update();
        }


        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        internal virtual void Update(AttributeType enmParams)
        {
            UpdateParams(enmParams);
        }

        /// <summary>
        /// Updates only the parameters of this instance.
        /// </summary>
        protected void UpdateParams()
        {
            mlngLastModifiedParams = GetCurrentTicks();
            menmLastModifiedParams = AttributeType.All;
        }

        protected void UpdateParams(AttributeType enmParams)
        {
            mlngLastModifiedParams = GetCurrentTicks();
            menmLastModifiedParams |= enmParams;
        }

        /// <summary>
        /// Determines whether the specified component is dirty.
        /// </summary>
        /// <param name="lngRequestID">Request ID.</param>
        /// <returns>
        /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsDirty(long lngRequestID)
        {
            return LastModified > lngRequestID;
        }

        /// <summary>
        /// Determines whether the specified component is dirty.
        /// </summary>
        /// <param name="lngRequestID">Request ID.</param>
        /// <returns>
        /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsDirtyAttributes(long lngRequestID)
        {
            return mlngLastModifiedParams > lngRequestID;
        }

        protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams)
        {
            return mlngLastModifiedParams > lngRequestID && (((int)menmLastModifiedParams & (int)enmParams) > 0);
        }




        #endregion

        #endregion

        /// <summary>
        /// Gets the initial size of the serializable filed storage.
        /// </summary>
        /// <value>The initial size of the serializable filed storage.</value>
        protected internal override int SerializableFieldStorageInitialSize
        {
            get
            {
                return 20;
            }
        }
    }

    #endregion

    #region GridEntryCollection Class

    [Serializable()]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GridEntryCollection : GridItemCollection
    {
        public GridEntryCollection(GridEntry objOwner, GridEntry[] arrEntries)
            : base(arrEntries)
        {
            this.mobjOwner = objOwner;

        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="arrValues">The arr values.</param>
        public void AddRange(GridEntry[] arrValues)
        {
            if (arrValues == null)
            {
                throw new ArgumentNullException("value");
            }
            if (base.marrEntries != null)
            {
                GridEntry[] arrEntries = new GridEntry[base.marrEntries.Length + arrValues.Length];
                base.marrEntries.CopyTo(arrEntries, 0);
                arrValues.CopyTo(arrEntries, base.marrEntries.Length);
                base.marrEntries = arrEntries;
            }
            else
            {
                base.marrEntries = (GridEntry[])arrValues.Clone();


            }

            this.mobjOwner.OwnerGrid.RegisterGridComponents(base.marrEntries);
        }

        public void Clear()
        {
            mobjOwner.OwnerGrid.UnRegisterGridComponents(base.marrEntries);
            base.marrEntries = new GridEntry[0];
        }

        public void CopyTo(Array objDestinationArray, int index)
        {
            base.marrEntries.CopyTo(objDestinationArray, index);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool blnDisposing)
        {
            if ((blnDisposing && (this.mobjOwner != null)) && (base.marrEntries != null))
            {
                for (int num1 = 0; num1 < base.marrEntries.Length; num1++)
                {
                    if (base.marrEntries[num1] != null)
                    {
                        ((GridEntry)base.marrEntries[num1]).Dispose();
                        base.marrEntries[num1] = null;
                    }
                }
                base.marrEntries = new GridEntry[0];
            }
        }

        ~GridEntryCollection()
        {
            this.Dispose(false);
        }

        internal GridEntry GetEntry(int index)
        {
            return (GridEntry)base.marrEntries[index];
        }

        internal int GetEntry(GridEntry objChild)
        {
            return Array.IndexOf(base.marrEntries, objChild);
        }


        private GridEntry mobjOwner;
    }

    #endregion

    #region ArrayElementGridEntry Class

    [Serializable()]
    internal class ArrayElementGridEntry : GridEntry
    {
        protected int mintIndex
        {
            get
            {
                return this.GetValue<int>(ArrayElementGridEntry.mintIndexProperty);
            }
            set
            {
                this.SetValue<int>(ArrayElementGridEntry.mintIndexProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintIndexProperty = SerializableProperty.Register("mintIndex", typeof(int), typeof(ArrayElementGridEntry));



        public ArrayElementGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, int intIndex)
            : base(objOwnerGrid, objParentGridEntry)
        {
            this.mintIndex = intIndex;
            this.SetState(0x100, ((objParentGridEntry.Flags & 0x100) != 0) || objParentGridEntry.ForceReadOnly);
        }


        public override Gizmox.WebGUI.Forms.GridItemType GridItemType
        {
            get
            {
                return Gizmox.WebGUI.Forms.GridItemType.ArrayValue;
            }
        }

        public override bool IsValueEditable
        {
            get
            {
                return this.ParentGridEntry.IsValueEditable;
            }
        }

        public override string PropertyLabel
        {
            get
            {
                return ("[" + this.mintIndex.ToString(CultureInfo.CurrentCulture) + "]");
            }
        }

        public override Type PropertyType
        {
            get
            {
                return base.mobjParentGridEntry.PropertyType.GetElementType();
            }
        }

        public override object PropertyValue
        {
            get
            {
                object obj1 = this.GetValueOwner();
                return ((Array)obj1).GetValue(this.mintIndex);
            }
            set
            {
                object obj1 = this.GetValueOwner();
                ((Array)obj1).SetValue(value, this.mintIndex);
            }
        }

        public override bool ShouldRenderReadOnly
        {
            get
            {
                return this.ParentGridEntry.ShouldRenderReadOnly;
            }
        }



    }

    #endregion

    #region ImmutablePropertyDescriptorGridEntry Class


    [Serializable()]
    internal class ImmutablePropertyDescriptorGridEntry : PropertyDescriptorGridEntry
    {
        internal ImmutablePropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, PropertyDescriptor objPropertyDescriptor, bool blnHide)
            : base(objOwnerGrid, objParentGridEntry, objPropertyDescriptor, blnHide)
        {
        }

        internal override bool NotifyValueGivenParent(object objObject, int intType)
        {
            return this.ParentGridEntry.NotifyValue(intType);
        }


        private GridEntry InstanceParentGridEntry
        {
            get
            {
                GridEntry objGridEntry = this.ParentGridEntry;
                if (objGridEntry is CategoryGridEntry)
                {
                    objGridEntry = objGridEntry.ParentGridEntry;
                }
                return objGridEntry;
            }
        }

        protected override bool IsPropertyReadOnly
        {
            get
            {
                return this.ShouldRenderReadOnly;
            }
        }

        public override object PropertyValue
        {
            get
            {
                return base.PropertyValue;
            }
            set
            {
                object obj1 = this.GetValueOwner();
                GridEntry objGridEntry = this.InstanceParentGridEntry;
                TypeConverter objConverter1 = objGridEntry.TypeConverter;
                PropertyDescriptorCollection objCollection1 = objConverter1.GetProperties(objGridEntry, obj1);
                IDictionary objDictionary = new Hashtable(objCollection1.Count);
                object obj2 = null;
                for (int num1 = 0; num1 < objCollection1.Count; num1++)
                {
                    if ((base.mobjPropertyInfo.Name != null) && base.mobjPropertyInfo.Name.Equals(objCollection1[num1].Name))
                    {
                        objDictionary[objCollection1[num1].Name] = value;
                    }
                    else
                    {
                        objDictionary[objCollection1[num1].Name] = objCollection1[num1].GetValue(obj1);
                    }
                }
                try
                {
                    obj2 = objConverter1.CreateInstance(objGridEntry, objDictionary);
                }
                catch (Exception objException1)
                {
                    if (CommonUtils.IsNullOrEmpty(objException1.Message))
                    {
                        throw new TargetInvocationException(SR.GetString("ExceptionCreatingObject", new object[] { this.InstanceParentGridEntry.PropertyType.FullName, objException1.ToString() }), objException1);
                    }
                    throw;
                }
                if (obj2 != null)
                {
                    objGridEntry.PropertyValue = obj2;
                    objGridEntry.Update(AttributeType.Redraw);
                }
            }
        }

        public override bool ShouldRenderReadOnly
        {
            get
            {
                return this.InstanceParentGridEntry.ShouldRenderReadOnly;
            }
        }

    }
    #endregion

    #region MergePropertyDescriptor Class

    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
    [Serializable()]
    internal class MergePropertyDescriptor : PropertyDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergePropertyDescriptor"/> class.
        /// </summary>
        /// <param name="arrDescriptors">The arr descriptors.</param>
        public MergePropertyDescriptor(PropertyDescriptor[] arrDescriptors)
            : base(arrDescriptors[0].Name, null)
        {
            this.marrDescriptors = arrDescriptors;
        }

        public override bool CanResetValue(object objComponent)
        {
            if (this.menmCanReset == TriState.Unknown)
            {
                this.menmCanReset = TriState.Yes;
                Array objArray = (Array)objComponent;
                for (int num1 = 0; num1 < this.marrDescriptors.Length; num1++)
                {
                    if (!this.marrDescriptors[num1].CanResetValue(this.GetPropertyOwnerForComponent(objArray, num1)))
                    {
                        this.menmCanReset = TriState.No;
                        break;
                    }
                }
            }
            return (this.menmCanReset == TriState.Yes);
        }

        private object CopyValue(object objValue)
        {
            if (objValue != null)
            {
                Type objType1 = objValue.GetType();
                if (objType1.IsValueType)
                {
                    return objValue;
                }
                object obj1 = null;
                ICloneable cloneable1 = objValue as ICloneable;
                if (cloneable1 != null)
                {
                    obj1 = cloneable1.Clone();
                }
                if (obj1 == null)
                {
                    TypeConverter objConverter1 = TypeDescriptor.GetConverter(objValue);
                    if (objConverter1.CanConvertTo(typeof(InstanceDescriptor)))
                    {
                        InstanceDescriptor descriptor1 = (InstanceDescriptor)objConverter1.ConvertTo(null, CultureInfo.InvariantCulture, objValue, typeof(InstanceDescriptor));
                        if ((descriptor1 != null) && descriptor1.IsComplete)
                        {
                            obj1 = descriptor1.Invoke();
                        }
                    }
                    if (((obj1 == null) && objConverter1.CanConvertTo(typeof(string))) && objConverter1.CanConvertFrom(typeof(string)))
                    {
                        object obj2 = objConverter1.ConvertToInvariantString(objValue);
                        obj1 = objConverter1.ConvertFromInvariantString((string)obj2);
                    }
                }
                if ((obj1 == null) && objType1.IsSerializable)
                {
                    BinaryFormatter formatter1 = new BinaryFormatter();
                    MemoryStream stream1 = new MemoryStream();
                    formatter1.Serialize(stream1, objValue);
                    stream1.Position = 0;
                    obj1 = formatter1.Deserialize(stream1);
                }
                if (obj1 != null)
                {
                    return obj1;
                }
            }
            return objValue;
        }

        protected override AttributeCollection CreateAttributeCollection()
        {
            return new MergedAttributeCollection(this);
        }

        public override object GetEditor(Type objEditorBaseType)
        {
            return this.marrDescriptors[0].GetEditor(objEditorBaseType);
        }

        private object GetPropertyOwnerForComponent(Array objArray, int i)
        {
            object obj1 = objArray.GetValue(i);
            if (obj1 is ICustomTypeDescriptor)
            {
                obj1 = ((ICustomTypeDescriptor)obj1).GetPropertyOwner(this.marrDescriptors[i]);
            }
            return obj1;
        }

        public override object GetValue(object objComponent)
        {
            bool blnFlag1;
            return this.GetValue((Array)objComponent, out blnFlag1);
        }

        public object GetValue(Array objComponentsArray, out bool blnAllEqual)
        {
            blnAllEqual = true;
            object obj1 = this.marrDescriptors[0].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, 0));
            if (obj1 is ICollection)
            {
                if (this.mobjCollection == null)
                {
                    this.mobjCollection = new MultiMergeCollection((ICollection)obj1);
                }
                else
                {
                    if (this.mobjCollection.Locked)
                    {
                        return this.mobjCollection;
                    }
                    this.mobjCollection.SetItems((ICollection)obj1);
                }
            }
            for (int num1 = 1; num1 < this.marrDescriptors.Length; num1++)
            {
                object obj2 = this.marrDescriptors[num1].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, num1));
                if (this.mobjCollection != null)
                {
                    if (!this.mobjCollection.MergeCollection((ICollection)obj2))
                    {
                        blnAllEqual = false;
                        return null;
                    }
                }
                else if (((obj1 != null) || (obj2 != null)) && ((obj1 == null) || !obj1.Equals(obj2)))
                {
                    blnAllEqual = false;
                    return null;
                }
            }
            if ((blnAllEqual && (this.mobjCollection != null)) && (this.mobjCollection.Count == 0))
            {
                return null;
            }
            if (this.mobjCollection == null)
            {
                return obj1;
            }
            return this.mobjCollection;
        }

        internal object[] GetValues(Array objComponentsArray)
        {
            object[] arrObjects1 = new object[objComponentsArray.Length];
            for (int num1 = 0; num1 < objComponentsArray.Length; num1++)
            {
                arrObjects1[num1] = this.marrDescriptors[num1].GetValue(this.GetPropertyOwnerForComponent(objComponentsArray, num1));
            }
            return arrObjects1;
        }

        public override void ResetValue(object objComponent)
        {
            Array objArray = (Array)objComponent;
            for (int num1 = 0; num1 < this.marrDescriptors.Length; num1++)
            {
                this.marrDescriptors[num1].ResetValue(this.GetPropertyOwnerForComponent(objArray, num1));
            }
        }

        private void SetCollectionValues(Array objArray, IList objListValue)
        {
            try
            {
                if (this.mobjCollection != null)
                {
                    this.mobjCollection.Locked = true;
                }
                object[] arrObjects1 = new object[objListValue.Count];
                objListValue.CopyTo(arrObjects1, 0);
                for (int num1 = 0; num1 < this.marrDescriptors.Length; num1++)
                {
                    IList objList = this.marrDescriptors[num1].GetValue(this.GetPropertyOwnerForComponent(objArray, num1)) as IList;
                    if (objList != null)
                    {
                        objList.Clear();
                        foreach (object obj1 in arrObjects1)
                        {
                            objList.Add(obj1);
                        }
                    }
                }
            }
            finally
            {
                if (this.mobjCollection != null)
                {
                    this.mobjCollection.Locked = false;
                }
            }
        }

        public override void SetValue(object objComponent, object objValue)
        {
            Array objArray = (Array)objComponent;
            if ((objValue is IList) && typeof(IList).IsAssignableFrom(this.PropertyType))
            {
                this.SetCollectionValues(objArray, (IList)objValue);
            }
            else
            {
                for (int num1 = 0; num1 < this.marrDescriptors.Length; num1++)
                {
                    object obj1 = this.CopyValue(objValue);
                    this.marrDescriptors[num1].SetValue(this.GetPropertyOwnerForComponent(objArray, num1), obj1);
                }
            }
        }

        public override bool ShouldSerializeValue(object objComponent)
        {
            Array objArray = (Array)objComponent;
            for (int num1 = 0; num1 < this.marrDescriptors.Length; num1++)
            {
                if (!this.marrDescriptors[num1].ShouldSerializeValue(this.GetPropertyOwnerForComponent(objArray, num1)))
                {
                    return false;
                }
            }
            return true;
        }


        public override Type ComponentType
        {
            get
            {
                return this.marrDescriptors[0].ComponentType;
            }
        }

        public override TypeConverter Converter
        {
            get
            {
                return this.marrDescriptors[0].Converter;
            }
        }

        public override string DisplayName
        {
            get
            {
                return this.marrDescriptors[0].DisplayName;
            }
        }

        public override bool IsLocalizable
        {
            get
            {
                if (this.menmLocalizable == TriState.Unknown)
                {
                    this.menmLocalizable = TriState.Yes;
                    foreach (PropertyDescriptor objPropertyDescriptor1 in this.marrDescriptors)
                    {
                        if (!objPropertyDescriptor1.IsLocalizable)
                        {
                            this.menmLocalizable = TriState.No;
                            break;
                        }
                    }
                }
                return (this.menmLocalizable == TriState.Yes);
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                if (this.menmReadOnly == TriState.Unknown)
                {
                    this.menmReadOnly = TriState.No;
                    foreach (PropertyDescriptor objPropertyDescriptor1 in this.marrDescriptors)
                    {
                        if (objPropertyDescriptor1.IsReadOnly)
                        {
                            this.menmReadOnly = TriState.Yes;
                            break;
                        }
                    }
                }
                return (this.menmReadOnly == TriState.Yes);
            }
        }

        public PropertyDescriptor this[int index]
        {
            get
            {
                return this.marrDescriptors[index];
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.marrDescriptors[0].PropertyType;
            }
        }


        private TriState menmCanReset;
        private MultiMergeCollection mobjCollection;
        private PropertyDescriptor[] marrDescriptors;
        private TriState menmLocalizable;
        private TriState menmReadOnly;


        [Serializable()]
        private class MergedAttributeCollection : AttributeCollection
        {
            public MergedAttributeCollection(MergePropertyDescriptor objOwner)
                : base(null)
            {
                this.mobjOwner = objOwner;
            }

            private Attribute GetCommonAttribute(Type objAttributeType)
            {
                Attribute attribute1;
                if (this.marrAttributeCollections == null)
                {
                    this.marrAttributeCollections = new AttributeCollection[this.mobjOwner.marrDescriptors.Length];
                    for (int num1 = 0; num1 < this.mobjOwner.marrDescriptors.Length; num1++)
                    {
                        this.marrAttributeCollections[num1] = this.mobjOwner.marrDescriptors[num1].Attributes;
                    }
                }
                if (this.marrAttributeCollections.Length == 0)
                {
                    return base.GetDefaultAttribute(objAttributeType);
                }
                if (this.mobjFoundAttributes != null)
                {
                    attribute1 = this.mobjFoundAttributes[objAttributeType] as Attribute;
                    if (attribute1 != null)
                    {
                        return attribute1;
                    }
                }
                attribute1 = this.marrAttributeCollections[0][objAttributeType];
                if (attribute1 == null)
                {
                    return null;
                }
                for (int num2 = 1; num2 < this.marrAttributeCollections.Length; num2++)
                {
                    Attribute attribute2 = this.marrAttributeCollections[num2][objAttributeType];
                    if (!attribute1.Equals(attribute2))
                    {
                        attribute1 = base.GetDefaultAttribute(objAttributeType);
                        break;
                    }
                }
                if (this.mobjFoundAttributes == null)
                {
                    this.mobjFoundAttributes = new Hashtable();
                }
                this.mobjFoundAttributes[objAttributeType] = attribute1;
                return attribute1;
            }


            public override Attribute this[Type objAttributeType]
            {
                get
                {
                    return this.GetCommonAttribute(objAttributeType);
                }
            }


            private AttributeCollection[] marrAttributeCollections;
            private IDictionary mobjFoundAttributes;
            private MergePropertyDescriptor mobjOwner;
        }

        [Serializable()]
        private class MultiMergeCollection : ICollection, IEnumerable
        {
            public MultiMergeCollection(ICollection original)
            {
                this.SetItems(original);
            }

            public void CopyTo(Array objArray, int index)
            {
                if (this.marrItems != null)
                {
                    Array.Copy(this.marrItems, 0, objArray, index, this.marrItems.Length);
                }
            }

            public IEnumerator GetEnumerator()
            {
                if (this.marrItems != null)
                {
                    return this.marrItems.GetEnumerator();
                }
                return new object[0].GetEnumerator();
            }

            public bool MergeCollection(ICollection objNewCollection)
            {
                if (!this.mblnLocked)
                {
                    if (this.marrItems.Length != objNewCollection.Count)
                    {
                        this.marrItems = new object[0];
                        return false;
                    }
                    object[] arrObjects1 = new object[objNewCollection.Count];
                    objNewCollection.CopyTo(arrObjects1, 0);
                    for (int num1 = 0; num1 < arrObjects1.Length; num1++)
                    {
                        if (((arrObjects1[num1] == null) != (this.marrItems[num1] == null)) || ((this.marrItems[num1] != null) && !this.marrItems[num1].Equals(arrObjects1[num1])))
                        {
                            this.marrItems = new object[0];
                            return false;
                        }
                    }
                }
                return true;
            }

            public void SetItems(ICollection objCollection)
            {
                if (!this.mblnLocked)
                {
                    this.marrItems = new object[objCollection.Count];
                    objCollection.CopyTo(this.marrItems, 0);
                }
            }


            public int Count
            {
                get
                {
                    if (this.marrItems != null)
                    {
                        return this.marrItems.Length;
                    }
                    return 0;
                }
            }

            public bool Locked
            {
                get
                {
                    return this.mblnLocked;
                }
                set
                {
                    this.mblnLocked = value;
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }


            private object[] marrItems;
            private bool mblnLocked;
        }

        private enum TriState
        {
            Unknown,
            Yes,
            No
        }
    }

    #endregion

    #region MultiPropertyDescriptorGridEntry Class

    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
    [Serializable()]
    internal class MultiPropertyDescriptorGridEntry : PropertyDescriptorGridEntry
    {
        private MergePropertyDescriptor mobjMergePropertyDescriptor
        {
            get
            {
                return this.GetValue<MergePropertyDescriptor>(MultiPropertyDescriptorGridEntry.mobjMergePropertyDescriptorProperty);
            }
            set
            {
                this.SetValue<MergePropertyDescriptor>(MultiPropertyDescriptorGridEntry.mobjMergePropertyDescriptorProperty, value);
            }
        }

        /// <summary>
        /// The MergePropertyDescriptor property registration.
        /// </summary>
        private static readonly SerializableProperty mobjMergePropertyDescriptorProperty = SerializableProperty.Register("mobjMergePropertyDescriptor", typeof(MergePropertyDescriptor), typeof(MultiPropertyDescriptorGridEntry));


        private object[] marrObjects
        {
            get
            {
                return this.GetValue<object[]>(MultiPropertyDescriptorGridEntry.marrObjectsProperty);
            }
            set
            {
                this.SetValue<object[]>(MultiPropertyDescriptorGridEntry.marrObjectsProperty, value);
            }
        }

        /// <summary>
        /// The object{} property registration.
        /// </summary>
        private static readonly SerializableProperty marrObjectsProperty = SerializableProperty.Register("marrObjects", typeof(object[]), typeof(MultiPropertyDescriptorGridEntry));



        public MultiPropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, object[] arrObjects, PropertyDescriptor[] arrPropDescriptors, bool blnHide)
            : base(objOwnerGrid, objParentGridEntry, blnHide)
        {
            this.mobjMergePropertyDescriptor = new MergePropertyDescriptor(arrPropDescriptors);
            this.marrObjects = arrObjects;
            base.Initialize(this.mobjMergePropertyDescriptor);
        }

        protected override bool CreateChildren()
        {
            return this.CreateChildren(false);
        }

        protected override bool CreateChildren(bool blnDiffOldChildren)
        {
            try
            {
                if (this.mobjMergePropertyDescriptor.PropertyType.IsValueType || ((this.Flags & 0x200) != 0))
                {
                    return base.CreateChildren(blnDiffOldChildren);
                }
                base.ChildCollection.Clear();
                MultiPropertyDescriptorGridEntry[] arrEntries = MultiSelectRootGridEntry.PropertyMerger.GetMergedProperties(this.mobjMergePropertyDescriptor.GetValues(this.marrObjects), this, base.menmPropertySort, this.CurrentTab);
                if (arrEntries != null)
                {
                    base.ChildCollection.AddRange(arrEntries);
                }
                bool blnFlag1 = this.Children.Count > 0;
                if (!blnFlag1)
                {
                    this.SetState(0x80000, true);
                }
                return blnFlag1;
            }
            catch
            {
                return false;
            }
        }

        public override object GetChildValueOwner(GridEntry objChildGridEntry)
        {
            if (!this.mobjMergePropertyDescriptor.PropertyType.IsValueType && ((this.Flags & 0x200) == 0))
            {
                return this.mobjMergePropertyDescriptor.GetValues(this.marrObjects);
            }
            return base.GetChildValueOwner(objChildGridEntry);
        }

        public override IComponent[] GetComponents()
        {
            IComponent[] arrComponents = new IComponent[this.marrObjects.Length];
            Array.Copy(this.marrObjects, 0, arrComponents, 0, this.marrObjects.Length);
            return arrComponents;
        }

        public override string GetPropertyTextValue(object objValue)
        {
            bool blnFlag1 = true;
            try
            {
                if (((objValue == null) && (this.mobjMergePropertyDescriptor.GetValue(this.marrObjects, out blnFlag1) == null)) && !blnFlag1)
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
            return base.GetPropertyTextValue(objValue);
        }

        internal override bool NotifyChildValue(GridEntry objGridEntry, int intType)
        {
            bool blnFlag1 = false;
            IDesignerHost objHost = this.DesignerHost;
            DesignerTransaction objTransaction = null;
            if (objHost != null)
            {
                objTransaction = objHost.CreateTransaction();
            }
            try
            {
                blnFlag1 = base.NotifyChildValue(objGridEntry, intType);
            }
            finally
            {
                if (objTransaction != null)
                {
                    objTransaction.Commit();
                }
            }
            return blnFlag1;
        }

        protected override void NotifyParentChange(GridEntry objGridEntry)
        {
            while (((objGridEntry != null) && (objGridEntry is PropertyDescriptorGridEntry)) && ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo.Attributes.Contains(NotifyParentPropertyAttribute.Yes))
            {
                object obj1 = objGridEntry.GetValueOwner();
                while (!(objGridEntry is PropertyDescriptorGridEntry) || this.OwnersEqual(obj1, objGridEntry.GetValueOwner()))
                {
                    objGridEntry = objGridEntry.ParentGridEntry;
                    if (objGridEntry == null)
                    {
                        break;
                    }
                }
                if (objGridEntry != null)
                {
                    obj1 = objGridEntry.GetValueOwner();
                    IComponentChangeService objService1 = this.ComponentChangeService;
                    if (objService1 == null)
                    {
                        continue;
                    }
                    Array objArray = obj1 as Array;
                    if (objArray != null)
                    {
                        for (int num1 = 0; num1 < objArray.Length; num1++)
                        {
                            PropertyDescriptor objPropertyDescriptor1 = ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo;
                            if (objPropertyDescriptor1 is MergePropertyDescriptor)
                            {
                                objPropertyDescriptor1 = ((MergePropertyDescriptor)objPropertyDescriptor1)[num1];
                            }
                            if (objPropertyDescriptor1 != null)
                            {
                                objService1.OnComponentChanging(objArray.GetValue(num1), objPropertyDescriptor1);
                                objService1.OnComponentChanged(objArray.GetValue(num1), objPropertyDescriptor1, null, null);
                            }
                        }
                        continue;
                    }
                    objService1.OnComponentChanging(obj1, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo);
                    objService1.OnComponentChanged(obj1, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo, null, null);
                }
            }
        }

        internal override bool NotifyValueGivenParent(object objObject, int intType)
        {
            if (objObject is ICustomTypeDescriptor)
            {
                objObject = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(base.mobjPropertyInfo);
            }
            switch (intType)
            {
                case 1:
                    {
                        object[] arrObjects1 = (object[])objObject;
                        if ((arrObjects1 != null) && (arrObjects1.Length > 0))
                        {
                            IDesignerHost objHost = this.DesignerHost;
                            DesignerTransaction objTransaction = null;
                            if (objHost != null)
                            {
                                objTransaction = objHost.CreateTransaction(SR.GetString("PropertyGridResetValue", new object[] { this.PropertyName }));
                            }
                            try
                            {
                                bool blnFlag1 = !(arrObjects1[0] is IComponent) || (((IComponent)arrObjects1[0]).Site == null);
                                if (blnFlag1 && !this.OnComponentChanging())
                                {
                                    if (objTransaction != null)
                                    {
                                        objTransaction.Cancel();
                                        objTransaction = null;
                                    }
                                    return false;
                                }
                                this.mobjMergePropertyDescriptor.ResetValue(objObject);
                                if (blnFlag1)
                                {
                                    this.OnComponentChanged();
                                }
                                this.NotifyParentChange(this);
                            }
                            finally
                            {
                                if (objTransaction != null)
                                {
                                    objTransaction.Commit();
                                }
                            }
                        }
                        return false;
                    }
                case 3:
                case 5:
                    {
                        MergePropertyDescriptor objPropertyDescriptor1 = base.mobjPropertyInfo as MergePropertyDescriptor;
                        if (objPropertyDescriptor1 == null)
                        {
                            return base.NotifyValueGivenParent(objObject, intType);
                        }
                        object[] arrObjects3 = (object[])objObject;
                        if (base.mobjEventBindings == null)
                        {
                            base.mobjEventBindings = (IEventBindingService)this.GetService(typeof(IEventBindingService));
                        }
                        if (base.mobjEventBindings != null)
                        {
                            EventDescriptor descriptor2 = base.mobjEventBindings.GetEvent(objPropertyDescriptor1[0]);
                            if (descriptor2 != null)
                            {
                                return base.ViewEvent(objObject, null, descriptor2, true);
                            }
                        }
                        return false;
                    }
            }
            return base.NotifyValueGivenParent(objObject, intType);
        }

        public override void OnComponentChanged()
        {
            if (this.ComponentChangeService != null)
            {
                int num1 = this.marrObjects.Length;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    this.ComponentChangeService.OnComponentChanged(this.marrObjects[num2], this.mobjMergePropertyDescriptor[num2], null, null);
                }
            }
        }

        public override bool OnComponentChanging()
        {
            if (this.ComponentChangeService != null)
            {
                int num1 = this.marrObjects.Length;
                for (int num2 = 0; num2 < num1; num2++)
                {
                    try
                    {
                        this.ComponentChangeService.OnComponentChanging(this.marrObjects[num2], this.mobjMergePropertyDescriptor[num2]);
                    }
                    catch (CheckoutException objException1)
                    {
                        if (objException1 != CheckoutException.Canceled)
                        {
                            throw objException1;
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool OwnersEqual(object objOwner1, object objOwner2)
        {
            if (!(objOwner1 is Array))
            {
                return (objOwner1 == objOwner2);
            }
            Array objArray1 = objOwner1 as Array;
            Array objArray2 = objOwner2 as Array;
            if (((objArray1 == null) || (objArray2 == null)) || (objArray1.Length != objArray2.Length))
            {
                return false;
            }
            for (int num1 = 0; num1 < objArray1.Length; num1++)
            {
                if (objArray1.GetValue(num1) != objArray2.GetValue(num1))
                {
                    return false;
                }
            }
            return true;
        }


        public override IContainer Container
        {
            get
            {
                IContainer container1 = null;
                foreach (object obj1 in this.marrObjects)
                {
                    IComponent component1 = obj1 as IComponent;
                    if ((component1 != null) && (component1.Site != null))
                    {
                        if (container1 == null)
                        {
                            container1 = component1.Site.Container;
                            return container1;
                        }
                        if (container1 == component1.Site.Container)
                        {
                            return container1;
                        }
                    }
                    return null;
                }
                return container1;
            }
        }

        public override bool Expandable
        {
            get
            {
                bool blnFlag1 = this.GetStateSet(0x20000);
                if (blnFlag1 && (base.ChildCollection.Count > 0))
                {
                    return true;
                }
                if (this.GetStateSet(0x80000))
                {
                    return false;
                }
                try
                {
                    object[] arrObjects1 = this.mobjMergePropertyDescriptor.GetValues(this.marrObjects);
                    for (int num1 = 0; num1 < arrObjects1.Length; num1++)
                    {
                        if (arrObjects1[num1] == null)
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    blnFlag1 = false;
                }
                return blnFlag1;
            }
        }

        public override object PropertyValue
        {
            set
            {
                base.PropertyValue = value;
                base.RecreateChildren();
                if (this.Expanded)
                {
                    this.GridEntryHost.Refresh(false);
                }
            }
        }



    }

    #endregion

    #region MultiSelectRootGridEntry Class

    [Serializable()]
    internal class MultiSelectRootGridEntry : SingleSelectRootGridEntry
    {
        static MultiSelectRootGridEntry()
        {
            MultiSelectRootGridEntry.PropertyComparer = new PDComparer();
        }

        internal MultiSelectRootGridEntry(PropertyGridView objPropertyGridView, object obj, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
            : base(objPropertyGridView, obj, objBaseProvider, objHost, objPropertyTab, objSortType)
        {
        }

        protected override bool CreateChildren()
        {
            return this.CreateChildren(false);
        }

        protected override bool CreateChildren(bool blnDiffOldChildren)
        {
            try
            {
                object[] arrObjects1 = (object[])base.objValue;
                base.ChildCollection.Clear();
                MultiPropertyDescriptorGridEntry[] arrEntries = PropertyMerger.GetMergedProperties(arrObjects1, this, base.menmPropertySort, this.CurrentTab);
                if (arrEntries != null)
                {
                    base.ChildCollection.AddRange(arrEntries);
                }
                bool blnFlag1 = this.Children.Count > 0;
                if (!blnFlag1)
                {
                    this.SetState(0x80000, true);
                }
                base.CategorizePropEntries();
                return blnFlag1;
            }
            catch
            {
                return false;
            }
        }


        internal override bool ForceReadOnly
        {
            get
            {
                if (!base.forceReadOnlyChecked)
                {
                    bool blnFlag1 = false;
                    foreach (object obj1 in ((Array)base.objValue))
                    {
                        ReadOnlyAttribute attribute1 = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(obj1)[typeof(ReadOnlyAttribute)];
                        if (((attribute1 != null) && !attribute1.IsDefaultAttribute()) || TypeDescriptor.GetAttributes(obj1).Contains(InheritanceAttribute.InheritedReadOnly))
                        {
                            blnFlag1 = true;
                            break;
                        }
                    }
                    if (blnFlag1)
                    {
                        base.State |= 0x400;
                    }
                    base.forceReadOnlyChecked = true;
                }
                return base.ForceReadOnly;
            }
        }


        private static PDComparer PropertyComparer;


        [Serializable()]
        private class PDComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                PropertyDescriptor objPropertyDescriptor1 = obj1 as PropertyDescriptor;
                PropertyDescriptor objPropertyDescriptor2 = obj2 as PropertyDescriptor;
                if ((objPropertyDescriptor1 == null) && (objPropertyDescriptor2 == null))
                {
                    return 0;
                }
                if (objPropertyDescriptor1 == null)
                {
                    return -1;
                }
                if (objPropertyDescriptor2 == null)
                {
                    return 1;
                }
                int num1 = string.Compare(objPropertyDescriptor1.Name, objPropertyDescriptor2.Name, false, CultureInfo.InvariantCulture);
                if (num1 == 0)
                {
                    num1 = string.Compare(objPropertyDescriptor1.PropertyType.FullName, objPropertyDescriptor2.PropertyType.FullName, true, CultureInfo.CurrentCulture);
                }
                return num1;
            }

        }

        [Serializable()]
        internal class PropertyMerger
        {
            private static ArrayList GetCommonProperties(object[] arrObjects, bool blnPresort, PropertyTab objPropertyTab, GridEntry objParentEntry)
            {
                PropertyDescriptorCollection[] arrCollectionArray1 = new PropertyDescriptorCollection[arrObjects.Length];
                Attribute[] arrAttributeArray1 = new Attribute[objParentEntry.BrowsableAttributes.Count];
                objParentEntry.BrowsableAttributes.CopyTo(arrAttributeArray1, 0);
                for (int num1 = 0; num1 < arrObjects.Length; num1++)
                {
                    PropertyDescriptorCollection objCollection1 = objPropertyTab.GetProperties(objParentEntry, arrObjects[num1], arrAttributeArray1);
                    if (blnPresort)
                    {
                        objCollection1 = objCollection1.Sort(MultiSelectRootGridEntry.PropertyComparer);
                    }
                    arrCollectionArray1[num1] = objCollection1;
                }
                ArrayList objList = new ArrayList();
                PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[arrObjects.Length];
                int[] arrNumbers = new int[arrCollectionArray1.Length];
                for (int num2 = 0; num2 < arrCollectionArray1[0].Count; num2++)
                {
                    PropertyDescriptor objPropertyDescriptor1 = arrCollectionArray1[0][num2];
                    bool blnFlag1 = objPropertyDescriptor1.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute();
                    for (int num3 = 1; blnFlag1 && (num3 < arrCollectionArray1.Length); num3++)
                    {
                        if (arrNumbers[num3] >= arrCollectionArray1[num3].Count)
                        {
                            blnFlag1 = false;
                            break;
                        }
                        PropertyDescriptor objPropertyDescriptor2 = arrCollectionArray1[num3][arrNumbers[num3]];
                        if (objPropertyDescriptor1.Equals(objPropertyDescriptor2))
                        {
                            arrNumbers[num3]++;
                            if (!objPropertyDescriptor2.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute())
                            {
                                blnFlag1 = false;
                                break;
                            }
                            arrDescriptors[num3] = objPropertyDescriptor2;
                        }
                        else
                        {
                            int num4 = arrNumbers[num3];
                            objPropertyDescriptor2 = arrCollectionArray1[num3][num4];
                            blnFlag1 = false;
                            while (MultiSelectRootGridEntry.PropertyComparer.Compare(objPropertyDescriptor2, objPropertyDescriptor1) <= 0)
                            {
                                if (objPropertyDescriptor1.Equals(objPropertyDescriptor2))
                                {
                                    if (!objPropertyDescriptor2.Attributes[typeof(MergablePropertyAttribute)].IsDefaultAttribute())
                                    {
                                        blnFlag1 = false;
                                        num4++;
                                        break;
                                    }
                                    blnFlag1 = true;
                                    arrDescriptors[num3] = objPropertyDescriptor2;
                                    arrNumbers[num3] = num4 + 1;
                                    break;
                                }
                                num4++;
                                if (num4 >= arrCollectionArray1[num3].Count)
                                {
                                    break;
                                }
                                objPropertyDescriptor2 = arrCollectionArray1[num3][num4];
                            }
                            if (!blnFlag1)
                            {
                                arrNumbers[num3] = num4;
                                break;
                            }
                        }
                    }
                    if (blnFlag1)
                    {
                        arrDescriptors[0] = objPropertyDescriptor1;
                        objList.Add(arrDescriptors.Clone());
                    }
                }
                return objList;
            }

            /// <summary>
            /// Gets the merged properties.
            /// </summary>
            /// <param name="arrObjects">The arr objects.</param>
            /// <param name="objParentEntry">The obj parent entry.</param>
            /// <param name="objSort">The obj sort.</param>
            /// <param name="objPropertyTab">The obj property tab.</param>
            /// <returns></returns>
            public static MultiPropertyDescriptorGridEntry[] GetMergedProperties(object[] arrObjects, GridEntry objParentEntry, PropertySort objSort, PropertyTab objPropertyTab)
            {
                try
                {
                    int num1 = arrObjects.Length;
                    if ((objSort & PropertySort.Alphabetical) != PropertySort.NoSort)
                    {
                        ArrayList objList = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(arrObjects, true, objPropertyTab, objParentEntry);
                        MultiPropertyDescriptorGridEntry[] arrEntries = new MultiPropertyDescriptorGridEntry[objList.Count];
                        for (int num2 = 0; num2 < arrEntries.Length; num2++)
                        {
                            arrEntries[num2] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[])objList[num2], false);
                        }
                        return MultiSelectRootGridEntry.PropertyMerger.SortParenEntries(arrEntries);
                    }
                    object[] arrObjects1 = new object[num1 - 1];
                    Array.Copy(arrObjects, 1, arrObjects1, 0, num1 - 1);
                    ArrayList objList2 = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(arrObjects1, true, objPropertyTab, objParentEntry);
                    ArrayList objList3 = MultiSelectRootGridEntry.PropertyMerger.GetCommonProperties(new object[] { arrObjects[0] }, false, objPropertyTab, objParentEntry);
                    PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[objList3.Count];
                    for (int num3 = 0; num3 < objList3.Count; num3++)
                    {
                        arrDescriptors[num3] = ((PropertyDescriptor[])objList3[num3])[0];
                    }
                    objList2 = MultiSelectRootGridEntry.PropertyMerger.UnsortedMerge(arrDescriptors, objList2);
                    MultiPropertyDescriptorGridEntry[] arrEntries2 = new MultiPropertyDescriptorGridEntry[objList2.Count];
                    for (int num4 = 0; num4 < arrEntries2.Length; num4++)
                    {
                        arrEntries2[num4] = new MultiPropertyDescriptorGridEntry(objParentEntry.OwnerGrid, objParentEntry, arrObjects, (PropertyDescriptor[])objList2[num4], false);
                    }
                    return MultiSelectRootGridEntry.PropertyMerger.SortParenEntries(arrEntries2);
                }
                catch
                {
                    return null;
                }
            }

            private static MultiPropertyDescriptorGridEntry[] SortParenEntries(MultiPropertyDescriptorGridEntry[] arrEntries)
            {
                MultiPropertyDescriptorGridEntry[] arrEntries2 = null;
                int num1 = 0;
                for (int num2 = 0; num2 < arrEntries.Length; num2++)
                {
                    if (arrEntries[num2].ParensAroundName)
                    {
                        if (arrEntries2 == null)
                        {
                            arrEntries2 = new MultiPropertyDescriptorGridEntry[arrEntries.Length];
                        }
                        arrEntries2[num1++] = arrEntries[num2];
                        arrEntries[num2] = null;
                    }
                }
                if (num1 > 0)
                {
                    for (int num3 = 0; num3 < arrEntries.Length; num3++)
                    {
                        if (arrEntries[num3] != null)
                        {
                            arrEntries2[num1++] = arrEntries[num3];
                        }
                    }
                    arrEntries = arrEntries2;
                }
                return arrEntries;
            }

            private static ArrayList UnsortedMerge(PropertyDescriptor[] arrBaseEntries, ArrayList sortedMergedEntries)
            {
                ArrayList objList = new ArrayList();
                PropertyDescriptor[] arrDescriptors = new PropertyDescriptor[((PropertyDescriptor[])sortedMergedEntries[0]).Length + 1];
                for (int num1 = 0; num1 < arrBaseEntries.Length; num1++)
                {
                    PropertyDescriptor objPropertyDescriptor1 = arrBaseEntries[num1];
                    PropertyDescriptor[] arrDescriptors2 = null;
                    string strText1 = objPropertyDescriptor1.Name + " " + objPropertyDescriptor1.PropertyType.FullName;
                    int num2 = sortedMergedEntries.Count;
                    int num3 = num2 / 2;
                    int num4 = 0;
                    while (num2 > 0)
                    {
                        PropertyDescriptor[] arrDescriptors3 = (PropertyDescriptor[])sortedMergedEntries[num4 + num3];
                        PropertyDescriptor objPropertyDescriptor2 = arrDescriptors3[0];
                        string strText2 = objPropertyDescriptor2.Name + " " + objPropertyDescriptor2.PropertyType.FullName;
                        int num5 = string.Compare(strText1, strText2, false, CultureInfo.InvariantCulture);
                        if (num5 == 0)
                        {
                            arrDescriptors2 = arrDescriptors3;
                            break;
                        }
                        if (num5 < 0)
                        {
                            num2 = num3;
                        }
                        else
                        {
                            int num6 = num3 + 1;
                            num4 += num6;
                            num2 -= num6;
                        }
                        num3 = num2 / 2;
                    }
                    if (arrDescriptors2 != null)
                    {
                        arrDescriptors[0] = objPropertyDescriptor1;
                        Array.Copy(arrDescriptors2, 0, arrDescriptors, 1, arrDescriptors2.Length);
                        objList.Add(arrDescriptors.Clone());
                    }
                }
                return objList;
            }

        }
    }

    #endregion

    #region PropertyDescriptorGridEntry Class

    [Serializable()]
    internal class PropertyDescriptorGridEntry : GridEntry
    {

        private static IEventBindingService mobjTargetBindingService;
        private static IComponent mobjTargetComponent;
        private static EventDescriptor mobjTargetEventDescriptor;

        private const byte mParensAroundNameNo = 0;
        private const byte mParensAroundNameUnknown = 0xff;
        private const byte mParensAroundNameYes = 1;

        private bool mblnActiveXHide
        {
            get
            {
                return this.GetValue<bool>(PropertyDescriptorGridEntry.mblnActiveXHideProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyDescriptorGridEntry.mblnActiveXHideProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty mblnActiveXHideProperty = SerializableProperty.Register("mblnActiveXHide", typeof(bool), typeof(PropertyDescriptorGridEntry));


        protected IEventBindingService mobjEventBindings
        {
            get
            {
                return this.GetValue<IEventBindingService>(PropertyDescriptorGridEntry.mobjEventBindingsProperty);
            }
            set
            {
                this.SetValue<IEventBindingService>(PropertyDescriptorGridEntry.mobjEventBindingsProperty, value);
            }
        }

        /// <summary>
        /// The IEventBindingService property registration.
        /// </summary>
        private static readonly SerializableProperty mobjEventBindingsProperty = SerializableProperty.Register("mobjEventBindings", typeof(IEventBindingService), typeof(PropertyDescriptorGridEntry));


        private System.ComponentModel.TypeConverter mobjEexceptionConverter
        {
            get
            {
                return this.GetValue<System.ComponentModel.TypeConverter>(PropertyDescriptorGridEntry.mobjEexceptionConverterProperty);
            }
            set
            {
                this.SetValue<System.ComponentModel.TypeConverter>(PropertyDescriptorGridEntry.mobjEexceptionConverterProperty, value);
            }
        }

        /// <summary>
        /// The System.ComponentModel.TypeConverter property registration.
        /// </summary>
        private static readonly SerializableProperty mobjEexceptionConverterProperty = SerializableProperty.Register("mobjEexceptionConverter", typeof(System.ComponentModel.TypeConverter), typeof(PropertyDescriptorGridEntry));


        private WebUITypeEditor mobjExceptionEditor
        {
            get
            {
                return this.GetValue<Gizmox.WebGUI.Forms.Design.WebUITypeEditor>(PropertyDescriptorGridEntry.mobjExceptionEditorProperty);
            }
            set
            {
                this.SetValue<Gizmox.WebGUI.Forms.Design.WebUITypeEditor>(PropertyDescriptorGridEntry.mobjExceptionEditorProperty, value);
            }
        }

        /// <summary>
        /// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
        /// </summary>
        private static readonly SerializableProperty mobjExceptionEditorProperty = SerializableProperty.Register("mobjExceptionEditor", typeof(Gizmox.WebGUI.Forms.Design.WebUITypeEditor), typeof(PropertyDescriptorGridEntry));


        private bool mblnForceRenderReadOnly
        {
            get
            {
                return this.GetValue<bool>(PropertyDescriptorGridEntry.mblnForceRenderReadOnlyProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyDescriptorGridEntry.mblnForceRenderReadOnlyProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty mblnForceRenderReadOnlyProperty = SerializableProperty.Register("mblnForceRenderReadOnly", typeof(bool), typeof(PropertyDescriptorGridEntry));


        private string mstrHelpKeyword
        {
            get
            {
                return this.GetValue<string>(PropertyDescriptorGridEntry.mstrHelpKeywordProperty);
            }
            set
            {
                this.SetValue<string>(PropertyDescriptorGridEntry.mstrHelpKeywordProperty, value);
            }
        }

        /// <summary>
        /// The string property registration.
        /// </summary>
        private static readonly SerializableProperty mstrHelpKeywordProperty = SerializableProperty.Register("mstrHelpKeyword", typeof(string), typeof(PropertyDescriptorGridEntry));


        private const int IMAGE_SIZE = 8;

        private bool mblnIsSerializeContentsProp
        {
            get
            {
                return this.GetValue<bool>(PropertyDescriptorGridEntry.mblnIsSerializeContentsPropProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyDescriptorGridEntry.mblnIsSerializeContentsPropProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty mblnIsSerializeContentsPropProperty = SerializableProperty.Register("mblnIsSerializeContentsProp", typeof(bool), typeof(PropertyDescriptorGridEntry));


        private byte mParensAroundName
        {
            get
            {
                return this.GetValue<byte>(PropertyDescriptorGridEntry.mParensAroundNameProperty);
            }
            set
            {
                this.SetValue<byte>(PropertyDescriptorGridEntry.mParensAroundNameProperty, value);
            }
        }

        /// <summary>
        /// The byte property registration.
        /// </summary>
        private static readonly SerializableProperty mParensAroundNameProperty = SerializableProperty.Register("mParensAroundName", typeof(byte), typeof(PropertyDescriptorGridEntry));


        internal System.ComponentModel.PropertyDescriptor mobjPropertyInfo
        {
            get
            {
                return this.GetValue<System.ComponentModel.PropertyDescriptor>(PropertyDescriptorGridEntry.mobjPropertyInfoProperty);
            }
            set
            {
                this.SetValue<System.ComponentModel.PropertyDescriptor>(PropertyDescriptorGridEntry.mobjPropertyInfoProperty, value);
            }
        }

        /// <summary>
        /// The System.ComponentModel.PropertyDescriptor property registration.
        /// </summary>
        private static readonly SerializableProperty mobjPropertyInfoProperty = SerializableProperty.Register("mobjPropertyInfo", typeof(System.ComponentModel.PropertyDescriptor), typeof(PropertyDescriptorGridEntry));


        private IPropertyValueUIService mobjPropertyValueUIService
        {
            get
            {
                return this.GetValue<IPropertyValueUIService>(PropertyDescriptorGridEntry.mobjPropertyValueUIServiceProperty);
            }
            set
            {
                this.SetValue<IPropertyValueUIService>(PropertyDescriptorGridEntry.mobjPropertyValueUIServiceProperty, value);
            }
        }

        /// <summary>
        /// The IPropertyValueUIService property registration.
        /// </summary>
        private static readonly SerializableProperty mobjPropertyValueUIServiceProperty = SerializableProperty.Register("mobjPropertyValueUIService", typeof(IPropertyValueUIService), typeof(PropertyDescriptorGridEntry));


        private bool mobjServiceChecked
        {
            get
            {
                return this.GetValue<bool>(PropertyDescriptorGridEntry.mobjServiceCheckedProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyDescriptorGridEntry.mobjServiceCheckedProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty mobjServiceCheckedProperty = SerializableProperty.Register("mobjServiceChecked", typeof(bool), typeof(PropertyDescriptorGridEntry));


        private PropertyValueUIItem[] marrPropertyValueUIItems
        {
            get
            {
                return this.GetValue<PropertyValueUIItem[]>(PropertyDescriptorGridEntry.marrPropertyValueUIItemsProperty);
            }
            set
            {
                this.SetValue<PropertyValueUIItem[]>(PropertyDescriptorGridEntry.marrPropertyValueUIItemsProperty, value);
            }
        }

        /// <summary>
        /// The PropertyValueUIItem{} property registration.
        /// </summary>
        private static readonly SerializableProperty marrPropertyValueUIItemsProperty = SerializableProperty.Register("marrPropertyValueUIItems", typeof(PropertyValueUIItem[]), typeof(PropertyDescriptorGridEntry));


        private bool mblnReadOnlyVerified
        {
            get
            {
                return this.GetValue<bool>(PropertyDescriptorGridEntry.mblnReadOnlyVerifiedProperty);
            }
            set
            {
                this.SetValue<bool>(PropertyDescriptorGridEntry.mblnReadOnlyVerifiedProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty mblnReadOnlyVerifiedProperty = SerializableProperty.Register("mblnReadOnlyVerified", typeof(bool), typeof(PropertyDescriptorGridEntry));



        private string mstrToolTipText
        {
            get
            {
                return this.GetValue<string>(PropertyDescriptorGridEntry.mstrToolTipTextProperty);
            }
            set
            {
                this.SetValue<string>(PropertyDescriptorGridEntry.mstrToolTipTextProperty, value);
            }
        }

        /// <summary>
        /// The string property registration.
        /// </summary>
        private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register("mstrToolTipText", typeof(string), typeof(PropertyDescriptorGridEntry));



        internal PropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, bool blnHide)
            : base(objOwnerGrid, objParentGridEntry)
        {
            this.mParensAroundName = 0xff;
            this.mblnActiveXHide = blnHide;
        }

        internal PropertyDescriptorGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGridEntry, System.ComponentModel.PropertyDescriptor objPropInfo, bool blnHide)
            : base(objOwnerGrid, objParentGridEntry)
        {
            this.mParensAroundName = 0xff;
            this.mblnActiveXHide = blnHide;
            this.Initialize(objPropInfo);
        }

        /// <summary>
        /// Dispose recursivly
        /// Parent method must be overrided
        /// in order to preserve the member ids 
        /// of the children.
        /// </summary>
        public override void DisposeChildren()
        {
        }


        protected override void EditPropertyValue_Callback(object objValue)
        {
            base.EditPropertyValue_Callback(objValue);
            if (!this.IsValueEditable)
            {
                RefreshPropertiesAttribute attribute1 = (RefreshPropertiesAttribute)this.mobjPropertyInfo.Attributes[typeof(RefreshPropertiesAttribute)];
                if ((attribute1 != null) && !attribute1.RefreshProperties.Equals(RefreshProperties.None))
                {
                    this.GridEntryHost.Refresh((attribute1 != null) && attribute1.Equals(RefreshPropertiesAttribute.All));
                }
            }
        }


        /// <summary>
        /// Get property value
        /// </summary>
        /// <param name="objTarget">The obj target.</param>
        /// <returns></returns>
        protected object GetPropertyValueCore(object objTarget)
        {
            object obj1;
            if (this.mobjPropertyInfo == null)
            {
                return null;
            }
            if (objTarget is ICustomTypeDescriptor)
            {
                objTarget = ((ICustomTypeDescriptor)objTarget).GetPropertyOwner(this.mobjPropertyInfo);
            }
            try
            {
                obj1 = OwnerGrid.GetPropertyValue(this.mobjPropertyInfo, objTarget);
            }
            catch
            {
                throw;
            }
            return obj1;
        }

        protected void Initialize(System.ComponentModel.PropertyDescriptor objPropInfo)
        {
            this.mobjPropertyInfo = objPropInfo;
            this.mblnIsSerializeContentsProp = this.mobjPropertyInfo.SerializationVisibility == DesignerSerializationVisibility.Content;
            if (!this.mblnActiveXHide && this.IsPropertyReadOnly)
            {
                this.SetState(1, false);
            }
            if (this.mblnIsSerializeContentsProp && this.TypeConverter.GetPropertiesSupported())
            {
                this.SetState(0x20000, true);
            }
        }

        protected virtual void NotifyParentChange(GridEntry objGridEntry)
        {
            while (((objGridEntry != null) && (objGridEntry is PropertyDescriptorGridEntry)) && ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo.Attributes.Contains(NotifyParentPropertyAttribute.Yes))
            {
                object obj1 = objGridEntry.GetValueOwner();
                while (!(objGridEntry is PropertyDescriptorGridEntry) || (obj1 == objGridEntry.GetValueOwner()))
                {
                    objGridEntry = objGridEntry.ParentGridEntry;
                    if (objGridEntry == null)
                    {
                        break;
                    }
                }
                if (objGridEntry != null)
                {
                    obj1 = objGridEntry.GetValueOwner();
                    IComponentChangeService objService1 = this.ComponentChangeService;
                    if (objService1 != null)
                    {
                        objService1.OnComponentChanging(obj1, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo);
                        objService1.OnComponentChanged(obj1, ((PropertyDescriptorGridEntry)objGridEntry).mobjPropertyInfo, null, null);
                    }
                    objGridEntry.ClearCachedValues(false);

                }
            }
        }

        internal override bool NotifyValueGivenParent(object objObject, int intType)
        {
            if (objObject is ICustomTypeDescriptor)
            {
                objObject = ((ICustomTypeDescriptor)objObject).GetPropertyOwner(this.mobjPropertyInfo);
            }
            switch (intType)
            {
                case 1:
                    this.SetPropertyValue(objObject, null, true, SR.GetString("PropertyGridResetValue", new object[] { this.PropertyName }));
                    if (this.marrPropertyValueUIItems != null)
                    {
                        for (int num1 = 0; num1 < this.marrPropertyValueUIItems.Length; num1++)
                        {
                            this.marrPropertyValueUIItems[num1].Reset();
                        }
                    }
                    this.marrPropertyValueUIItems = null;
                    return false;

                case 2:
                    {
                        try
                        {
                            return (this.mobjPropertyInfo.CanResetValue(objObject) || ((this.marrPropertyValueUIItems != null) && (this.marrPropertyValueUIItems.Length > 0)));
                        }
                        catch
                        {
                            if (this.mobjEexceptionConverter == null)
                            {
                                this.Flags = 0;
                                this.mobjEexceptionConverter = new ExceptionConverter();
                                //TODO: PROPERTYGRID
                                // this.exceptionEditor = new ExceptionEditor();
                            }
                            return false;
                        }
                    }
                case 3:
                case 5:
                    if (this.mobjEventBindings == null)
                    {
                        this.mobjEventBindings = (IEventBindingService)this.GetService(typeof(IEventBindingService));
                    }
                    if ((this.mobjEventBindings != null) && (this.mobjEventBindings.GetEvent(this.mobjPropertyInfo) != null))
                    {
                        return this.ViewEvent(objObject, null, null, true);
                    }
                    return false;

                case 4:
                    {
                        try
                        {
                            return this.mobjPropertyInfo.ShouldSerializeValue(objObject);
                        }
                        catch
                        {
                            if (this.mobjEexceptionConverter == null)
                            {
                                this.Flags = 0;
                                this.mobjEexceptionConverter = new ExceptionConverter();
                                // TODO:PROPERTYGRID
                                //this.exceptionEditor = new ExceptionEditor();
                            }
                            return false;
                        }
                    }
                default:
                    return false;
            }

        }

        public override void OnComponentChanged()
        {
            base.OnComponentChanged();
            this.NotifyParentChange(this);
        }


        private void SetFlagsAndExceptionInfo(int intFlags, ExceptionConverter objConverter, ExceptionEditor objEditor)
        {
            this.Flags = intFlags;
            this.mobjEexceptionConverter = objConverter;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="objObect">The obj obect.</param>
        /// <param name="objValue">The obj value.</param>
        /// <param name="blnReset">if set to <c>true</c> [BLN reset].</param>
        /// <param name="strUndoText">The STR undo text.</param>
        /// <returns></returns>
        private object SetPropertyValue(object objObect, object objValue, bool blnReset, string strUndoText)
        {
            DesignerTransaction objTransaction = null;
            try
            {
                object obj1 = this.GetPropertyValueCore(objObect);
                if ((objValue != null) && objValue.Equals(obj1))
                {
                    return objValue;
                }
                base.ClearCachedValues();
                IDesignerHost objHost = this.DesignerHost;
                if (objHost != null)
                {
                    string strText1 = (strUndoText == null) ? SR.GetString("PropertyGridSetValue", new object[] { this.mobjPropertyInfo.Name }) : strUndoText;
                    objTransaction = objHost.CreateTransaction(strText1);
                }
                bool blnFlag1 = !(objObect is IComponent) || (((IComponent)objObect).Site == null);
                if (blnFlag1)
                {
                    try
                    {
                        if (this.ComponentChangeService != null)
                        {
                            this.ComponentChangeService.OnComponentChanging(objObect, this.mobjPropertyInfo);
                        }
                    }
                    catch (CheckoutException objException1)
                    {
                        if (objException1 != CheckoutException.Canceled)
                        {
                            throw objException1;
                        }
                        return obj1;
                    }
                }
                bool blnFlag2 = this.InternalExpanded;
                int num1 = -1;
                if (blnFlag2)
                {
                    num1 = base.ChildCount;
                }
                RefreshPropertiesAttribute attribute1 = (RefreshPropertiesAttribute)this.mobjPropertyInfo.Attributes[typeof(RefreshPropertiesAttribute)];
                bool blnFlag3 = blnFlag2 || ((attribute1 != null) && !attribute1.RefreshProperties.Equals(RefreshProperties.None));
                if (blnFlag3)
                {
                    this.DisposeChildren();
                }
                EventDescriptor descriptor1 = null;
                if ((objObect != null) && (objValue is string))
                {
                    if (this.mobjEventBindings == null)
                    {
                        this.mobjEventBindings = (IEventBindingService)this.GetService(typeof(IEventBindingService));
                    }
                    if (this.mobjEventBindings != null)
                    {
                        descriptor1 = this.mobjEventBindings.GetEvent(this.mobjPropertyInfo);
                    }
                    if (descriptor1 == null)
                    {
                        object obj2 = objObect;
                        if ((this.mobjPropertyInfo is MergePropertyDescriptor) && (objObect is Array))
                        {
                            Array objArray = objObect as Array;
                            if (objArray.Length > 0)
                            {
                                obj2 = objArray.GetValue(0);
                            }
                        }
                        descriptor1 = TypeDescriptor.GetEvents(obj2)[this.mobjPropertyInfo.Name];
                    }
                }
                bool blnFlag4 = false;
                try
                {
                    if (blnReset)
                    {
                        this.mobjPropertyInfo.ResetValue(objObect);
                    }
                    else if (descriptor1 != null)
                    {
                        this.ViewEvent(objObect, (string)objValue, descriptor1, false);
                    }
                    else
                    {
                        this.SetPropertyValueCore(objObect, objValue, true);
                    }
                    blnFlag4 = true;
                    if (blnFlag1 && (this.ComponentChangeService != null))
                    {
                        this.ComponentChangeService.OnComponentChanged(objObect, this.mobjPropertyInfo, null, objValue);
                    }
                    this.NotifyParentChange(this);
                    return objObect;
                }
                finally
                {
                    if (blnFlag3 && (this.GridEntryHost != null))
                    {
                        base.RecreateChildren(num1);
                        if (blnFlag4)
                        {
                            this.GridEntryHost.Refresh((attribute1 != null) && attribute1.Equals(RefreshPropertiesAttribute.All));
                        }
                    }
                }
            }
            catch (CheckoutException objException2)
            {
                if (objTransaction != null)
                {
                    objTransaction.Cancel();
                    objTransaction = null;
                }
                if (objException2 != CheckoutException.Canceled)
                {
                    throw;
                }
                return null;
            }
            catch
            {
                if (objTransaction != null)
                {
                    objTransaction.Cancel();
                    objTransaction = null;
                }
                throw;
            }
            finally
            {
                if (objTransaction != null)
                {
                    objTransaction.Commit();
                }
            }

        }

        private void SetPropertyValueCore(object objObject, object objValue, bool blnDoUndo)
        {
            if (this.mobjPropertyInfo != null)
            {
                object obj1 = objObject;
                if (obj1 is ICustomTypeDescriptor)
                {
                    obj1 = ((ICustomTypeDescriptor)obj1).GetPropertyOwner(this.mobjPropertyInfo);
                }
                bool blnFlag1 = false;
                if (this.ParentGridEntry != null)
                {
                    Type objType1 = this.ParentGridEntry.PropertyType;
                    blnFlag1 = objType1.IsValueType || objType1.IsArray;
                }
                if (obj1 != null)
                {
                    this.OwnerGrid.SetPropertyValue(mobjPropertyInfo, obj1, objValue);

                    if (blnFlag1)
                    {
                        GridEntry objGridEntry = this.ParentGridEntry;
                        if ((objGridEntry != null) && objGridEntry.IsValueEditable)
                        {
                            objGridEntry.PropertyValue = objObject;
                        }
                    }
                }


            }

        }




        protected bool ViewEvent(object objObject, string strNewHandler, EventDescriptor objEventdesc, bool blnAlwaysNavigate)
        {
            object obj1 = this.GetPropertyValueCore(objObject);
            string strText1 = obj1 as string;
            if (((strText1 == null) && (obj1 != null)) && ((this.TypeConverter != null) && this.TypeConverter.CanConvertTo(typeof(string))))
            {
                strText1 = this.TypeConverter.ConvertToString(obj1);
            }
            if ((strNewHandler == null) && !CommonUtils.IsNullOrEmpty(strText1))
            {
                strNewHandler = strText1;
            }
            else if ((strText1 == strNewHandler) && !CommonUtils.IsNullOrEmpty(strNewHandler))
            {
                return true;
            }
            IComponent component1 = objObject as IComponent;
            if ((component1 == null) && (this.mobjPropertyInfo is MergePropertyDescriptor))
            {
                Array objArray = objObject as Array;
                if ((objArray != null) && (objArray.Length > 0))
                {
                    component1 = objArray.GetValue(0) as IComponent;
                }
            }
            if (component1 == null)
            {
                return false;
            }
            if (this.mobjPropertyInfo.IsReadOnly)
            {
                return false;
            }
            if (objEventdesc == null)
            {
                if (this.mobjEventBindings == null)
                {
                    this.mobjEventBindings = (IEventBindingService)this.GetService(typeof(IEventBindingService));
                }
                if (this.mobjEventBindings != null)
                {
                    objEventdesc = this.mobjEventBindings.GetEvent(this.mobjPropertyInfo);
                }
            }
            IDesignerHost objHost = this.DesignerHost;
            DesignerTransaction objTransaction = null;
            try
            {
                if (objEventdesc.EventType == null)
                {
                    return false;
                }
                if (objHost != null)
                {
                    string strText2 = (component1.Site != null) ? component1.Site.Name : component1.GetType().Name;
                    objTransaction = this.DesignerHost.CreateTransaction(SR.GetString("WindowsFormsSetEvent", new object[] { strText2 + "." + this.PropertyName }));
                }
                if (this.mobjEventBindings == null)
                {
                    ISite objSite = component1.Site;
                    if (objSite != null)
                    {
                        this.mobjEventBindings = (IEventBindingService)objSite.GetService(typeof(IEventBindingService));
                    }
                }
                if ((strNewHandler == null) && (this.mobjEventBindings != null))
                {
                    strNewHandler = this.mobjEventBindings.CreateUniqueMethodName(component1, objEventdesc);
                }
                if (strNewHandler != null)
                {
                    if (this.mobjEventBindings != null)
                    {
                        bool blnFlag1 = false;
                        foreach (string strText3 in this.mobjEventBindings.GetCompatibleMethods(objEventdesc))
                        {
                            if (strNewHandler == strText3)
                            {
                                blnFlag1 = true;
                                break;
                            }
                        }
                        if (!blnFlag1)
                        {
                            blnAlwaysNavigate = true;
                        }
                    }
                    this.mobjPropertyInfo.SetValue(objObject, strNewHandler);
                }
                if (blnAlwaysNavigate && (this.mobjEventBindings != null))
                {
                    PropertyDescriptorGridEntry.mobjTargetBindingService = this.mobjEventBindings;
                    PropertyDescriptorGridEntry.mobjTargetComponent = component1;
                    PropertyDescriptorGridEntry.mobjTargetEventDescriptor = objEventdesc;
                }
            }
            catch
            {
                if (objTransaction != null)
                {
                    objTransaction.Cancel();
                    objTransaction = null;
                }
                throw;
            }
            finally
            {
                if (objTransaction != null)
                {
                    objTransaction.Commit();
                }
            }
            return true;
        }


        public override bool AllowMerge
        {
            get
            {
                MergablePropertyAttribute attribute1 = (MergablePropertyAttribute)this.mobjPropertyInfo.Attributes[typeof(MergablePropertyAttribute)];
                if (attribute1 != null)
                {
                    return attribute1.IsDefaultAttribute();
                }
                return true;
            }
        }

        internal override AttributeCollection Attributes
        {
            get
            {
                return this.mobjPropertyInfo.Attributes;
            }
        }

        internal override bool Enumerable
        {
            get
            {
                if (base.Enumerable)
                {
                    return !this.IsPropertyReadOnly;
                }
                return false;
            }
        }

        public override string HelpKeyword
        {
            get
            {
                if (this.mstrHelpKeyword == null)
                {
                    object obj1 = this.GetValueOwner();
                    if (obj1 == null)
                    {
                        return null;
                    }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                    HelpKeywordAttribute attribute1 = (HelpKeywordAttribute)this.mobjPropertyInfo.Attributes[typeof(HelpKeywordAttribute)];
                    if ((attribute1 != null) && !attribute1.IsDefaultAttribute())
                    {
                        return attribute1.HelpKeyword;
                    }
#endif
                    if (this is ImmutablePropertyDescriptorGridEntry)
                    {
                        this.mstrHelpKeyword = this.PropertyName;
                        GridEntry objGridEntry = this;
                        while (objGridEntry.ParentGridEntry != null)
                        {
                            objGridEntry = objGridEntry.ParentGridEntry;
                            if ((objGridEntry.PropertyValue == obj1) || (obj1.GetType().IsValueType && (obj1.GetType() == objGridEntry.PropertyValue.GetType())))
                            {
                                this.mstrHelpKeyword = objGridEntry.PropertyName + "." + this.mstrHelpKeyword;
                                break;
                            }
                        }
                    }
                    else
                    {
                        string strText1 = "";
                        Type objType1 = this.mobjPropertyInfo.ComponentType;
                        if (objType1.IsCOMObject)
                        {
                            strText1 = TypeDescriptor.GetClassName(obj1);
                        }
                        else
                        {
                            Type objType2 = obj1.GetType();
                            if (!objType1.IsPublic || !objType1.IsAssignableFrom(objType2))
                            {
                                PropertyDescriptor objPropertyDescriptor1 = TypeDescriptor.GetProperties(objType2)[this.PropertyName];
                                if (objPropertyDescriptor1 != null)
                                {
                                    objType1 = objPropertyDescriptor1.ComponentType;
                                }
                                else
                                {
                                    objType1 = null;
                                }
                            }
                            if (objType1 == null)
                            {
                                strText1 = TypeDescriptor.GetClassName(obj1);
                            }
                            else
                            {
                                strText1 = objType1.FullName;
                            }
                        }
                        this.mstrHelpKeyword = strText1 + "." + this.mobjPropertyInfo.Name;
                    }
                }
                return this.mstrHelpKeyword;
            }
        }

        internal override string HelpKeywordInternal
        {
            get
            {
                return this.PropertyLabel;
            }
        }

        protected virtual bool IsPropertyReadOnly
        {
            get
            {
                return this.mobjPropertyInfo.IsReadOnly;
            }
        }

        public override bool IsValueEditable
        {
            get
            {
                if ((this.mobjEexceptionConverter == null) && !this.IsPropertyReadOnly)
                {
                    return base.IsValueEditable;
                }
                return false;
            }
        }



        public override bool NeedsDropDownButton
        {
            get
            {
                if (base.NeedsDropDownButton)
                {
                    return !this.IsPropertyReadOnly;
                }
                return false;
            }
        }

        internal bool ParensAroundName
        {
            get
            {
                if (0xff == this.mParensAroundName)
                {
                    if (((ParenthesizePropertyNameAttribute)this.mobjPropertyInfo.Attributes[typeof(ParenthesizePropertyNameAttribute)]).NeedParenthesis)
                    {
                        this.mParensAroundName = 1;
                    }
                    else
                    {
                        this.mParensAroundName = 0;
                    }
                }
                return (this.mParensAroundName == 1);
            }
        }

        public override string PropertyCategory
        {
            get
            {
                string strText1 = this.mobjPropertyInfo.Category;
                if ((strText1 != null) && (strText1.Length != 0))
                {
                    return strText1;
                }
                return base.PropertyCategory;
            }
        }

        public override string PropertyDescription
        {
            get
            {
                return this.mobjPropertyInfo.Description;
            }
        }

        public override System.ComponentModel.PropertyDescriptor PropertyDescriptor
        {
            get
            {
                return this.mobjPropertyInfo;
            }
        }

        public override string PropertyLabel
        {
            get
            {
                string strText1 = this.mobjPropertyInfo.DisplayName;
                if (this.ParensAroundName)
                {
                    strText1 = "(" + strText1 + ")";
                }
                return strText1;
            }
        }

        public override string PropertyName
        {
            get
            {
                if (this.mobjPropertyInfo != null)
                {
                    return this.mobjPropertyInfo.Name;
                }
                return null;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this.mobjPropertyInfo.PropertyType;
            }
        }

        public override object PropertyValue
        {
            get
            {
                try
                {
                    object obj1 = this.GetPropertyValueCore(this.GetValueOwner());
                    if (this.mobjEexceptionConverter != null)
                    {
                        this.SetFlagsAndExceptionInfo(0, null, null);
                    }
                    return obj1;
                }
                catch (Exception objException1)
                {
                    if (this.mobjEexceptionConverter == null)
                    {
                        this.SetFlagsAndExceptionInfo(0, new ExceptionConverter(), new ExceptionEditor());
                    }
                    return objException1;
                }
            }
            set
            {
                this.SetPropertyValue(this.GetValueOwner(), value, false, null);
            }
        }

        private IPropertyValueUIService PropertyValueUIService
        {
            get
            {
                if (!this.mobjServiceChecked && (this.mobjPropertyValueUIService == null))
                {
                    this.mobjPropertyValueUIService = (IPropertyValueUIService)this.GetService(typeof(IPropertyValueUIService));
                    this.mobjServiceChecked = true;
                }
                return this.mobjPropertyValueUIService;
            }
        }

        public override bool ShouldRenderReadOnly
        {
            get
            {
                if (base.ForceReadOnly || this.mblnForceRenderReadOnly)
                {
                    return true;
                }
                if ((this.mobjPropertyInfo.IsReadOnly && !this.mblnReadOnlyVerified) && this.GetStateSet(0x80))
                {
                    Type objType1 = this.PropertyType;
                    if ((objType1 != null) && ((objType1.IsArray || objType1.IsValueType) || objType1.IsPrimitive))
                    {
                        this.SetState(0x80, false);
                        this.SetState(0x100, true);
                        this.mblnForceRenderReadOnly = true;
                    }
                }
                this.mblnReadOnlyVerified = true;
                if ((base.ShouldRenderReadOnly && !this.mblnIsSerializeContentsProp) && !base.NeedsCustomEditorButton)
                {
                    return true;
                }
                return false;
            }
        }

        internal override System.ComponentModel.TypeConverter TypeConverter
        {
            get
            {
                if (this.mobjEexceptionConverter != null)
                {
                    return this.mobjEexceptionConverter;
                }
                if (base.mobjConverter == null)
                {
                    base.mobjConverter = this.mobjPropertyInfo.Converter;
                }
                return base.TypeConverter;
            }
        }

        internal override WebUITypeEditor UITypeEditor
        {
            get
            {
                if (this.mobjExceptionEditor != null)
                {
                    return this.mobjExceptionEditor;
                }
                base.mobjEditor = WebUITypeEditor.GetPropertyEditor(this.mobjPropertyInfo, typeof(Gizmox.WebGUI.Forms.Design.WebUITypeEditor));
                if (base.mobjEditor != null)
                {
                    return base.UITypeEditor;
                }
                return base.UITypeEditor;
            }
        }





        [Serializable()]
        public class ExceptionConverter : TypeConverter
        {
            public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
            {
                if (objDestinationType != typeof(string))
                {
                    throw base.GetConvertToException(objValue, objDestinationType);
                }
                if (!(objValue is Exception))
                {
                    return null;
                }
                Exception objException1 = (Exception)objValue;
                if (objException1.InnerException != null)
                {
                    objException1 = objException1.InnerException;
                }
                return objException1.Message;
            }

        }

        [Serializable()]
        private class ExceptionEditor : WebUITypeEditor
        {
            public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
            {
                Exception objException1 = objValue as Exception;
                if (objException1 != null)
                {

                    string strText1 = objException1.Message;
                    if ((strText1 == null) || (strText1.Length == 0))
                    {
                        strText1 = objException1.ToString();
                    }
                    MessageBox.Show(strText1, SR.GetString("PropertyGridExceptionInfo"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, 0);
                }
            }

            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
            {
                return UITypeEditorEditStyle.Modal;
            }

        }
    }

    #endregion

    #region SingleSelectRootGridEntry Class

    [Serializable()]
    internal class SingleSelectRootGridEntry : GridEntry, IRootGridEntry
    {
        protected IServiceProvider baseProvider
        {
            get
            {
                return this.GetValue<IServiceProvider>(SingleSelectRootGridEntry.baseProviderProperty);
            }
            set
            {
                this.SetValue<IServiceProvider>(SingleSelectRootGridEntry.baseProviderProperty, value);
            }
        }

        /// <summary>
        /// The IServiceProvider property registration.
        /// </summary>
        private static readonly SerializableProperty baseProviderProperty = SerializableProperty.Register("baseProvider", typeof(IServiceProvider), typeof(SingleSelectRootGridEntry));


        protected AttributeCollection browsableAttributes
        {
            get
            {
                return this.GetValue<AttributeCollection>(SingleSelectRootGridEntry.browsableAttributesProperty);
            }
            set
            {
                this.SetValue<AttributeCollection>(SingleSelectRootGridEntry.browsableAttributesProperty, value);
            }
        }

        /// <summary>
        /// The AttributeCollection property registration.
        /// </summary>
        private static readonly SerializableProperty browsableAttributesProperty = SerializableProperty.Register("browsableAttributes", typeof(AttributeCollection), typeof(SingleSelectRootGridEntry));


        private IComponentChangeService changeService
        {
            get
            {
                return this.GetValue<IComponentChangeService>(SingleSelectRootGridEntry.changeServiceProperty);
            }
            set
            {
                this.SetValue<IComponentChangeService>(SingleSelectRootGridEntry.changeServiceProperty, value);
            }
        }

        /// <summary>
        /// The IComponentChangeService property registration.
        /// </summary>
        private static readonly SerializableProperty changeServiceProperty = SerializableProperty.Register("changeService", typeof(IComponentChangeService), typeof(SingleSelectRootGridEntry));


        protected bool forceReadOnlyChecked
        {
            get
            {
                return this.GetValue<bool>(SingleSelectRootGridEntry.forceReadOnlyCheckedProperty);
            }
            set
            {
                this.SetValue<bool>(SingleSelectRootGridEntry.forceReadOnlyCheckedProperty, value);
            }
        }

        /// <summary>
        /// The bool property registration.
        /// </summary>
        private static readonly SerializableProperty forceReadOnlyCheckedProperty = SerializableProperty.Register("forceReadOnlyChecked", typeof(bool), typeof(SingleSelectRootGridEntry));


        protected PropertyGridView gridEntryHost
        {
            get
            {
                return this.GetValue<PropertyGridView>(SingleSelectRootGridEntry.gridEntryHostProperty);
            }
            set
            {
                this.SetValue<PropertyGridView>(SingleSelectRootGridEntry.gridEntryHostProperty, value);
            }
        }

        /// <summary>
        /// The PropertyGridView property registration.
        /// </summary>
        private static readonly SerializableProperty gridEntryHostProperty = SerializableProperty.Register("gridEntryHost", typeof(PropertyGridView), typeof(SingleSelectRootGridEntry));


        protected IDesignerHost host
        {
            get
            {
                return this.GetValue<IDesignerHost>(SingleSelectRootGridEntry.hostProperty);
            }
            set
            {
                this.SetValue<IDesignerHost>(SingleSelectRootGridEntry.hostProperty, value);
            }
        }

        /// <summary>
        /// The IDesignerHost property registration.
        /// </summary>
        private static readonly SerializableProperty hostProperty = SerializableProperty.Register("host", typeof(IDesignerHost), typeof(SingleSelectRootGridEntry));


        protected object objValue
        {
            get
            {
                return this.GetValue<object>(SingleSelectRootGridEntry.objValueProperty);
            }
            set
            {
                this.SetValue<object>(SingleSelectRootGridEntry.objValueProperty, value);
            }
        }

        /// <summary>
        /// The object property registration.
        /// </summary>
        private static readonly SerializableProperty objValueProperty = SerializableProperty.Register("objValue", typeof(object), typeof(SingleSelectRootGridEntry));


        protected string objValueClassName
        {
            get
            {
                return this.GetValue<string>(SingleSelectRootGridEntry.objValueClassNameProperty);
            }
            set
            {
                this.SetValue<string>(SingleSelectRootGridEntry.objValueClassNameProperty, value);
            }
        }

        /// <summary>
        /// The string property registration.
        /// </summary>
        private static readonly SerializableProperty objValueClassNameProperty = SerializableProperty.Register("objValueClassName", typeof(string), typeof(SingleSelectRootGridEntry));


        protected GridEntry propDefault
        {
            get
            {
                return this.GetValue<GridEntry>(SingleSelectRootGridEntry.propDefaultProperty);
            }
            set
            {
                this.SetValue<GridEntry>(SingleSelectRootGridEntry.propDefaultProperty, value);
            }
        }

        /// <summary>
        /// The GridEntry property registration.
        /// </summary>
        private static readonly SerializableProperty propDefaultProperty = SerializableProperty.Register("propDefault", typeof(GridEntry), typeof(SingleSelectRootGridEntry));


        protected PropertyTab tab
        {
            get
            {
                return this.GetValue<PropertyTab>(SingleSelectRootGridEntry.tabProperty);
            }
            set
            {
                this.SetValue<PropertyTab>(SingleSelectRootGridEntry.tabProperty, value);
            }
        }

        /// <summary>
        /// The PropertyTab property registration.
        /// </summary>
        private static readonly SerializableProperty tabProperty = SerializableProperty.Register("tab", typeof(PropertyTab), typeof(SingleSelectRootGridEntry));



        internal SingleSelectRootGridEntry(PropertyGridView objPropertyGridView, object objValue, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
            : this(objPropertyGridView, objValue, null, objBaseProvider, objHost, objPropertyTab, objSortType)
        {
        }

        internal SingleSelectRootGridEntry(PropertyGridView objGridEntryHost, object objValue, GridEntry objParentEntry, IServiceProvider objBaseProvider, IDesignerHost objHost, PropertyTab objPropertyTab, PropertySort objSortType)
            : base(objGridEntryHost.OwnerGrid, objParentEntry)
        {
            this.host = objHost;
            this.gridEntryHost = objGridEntryHost;
            this.baseProvider = objBaseProvider;
            this.tab = objPropertyTab;
            this.objValue = objValue;
            this.objValueClassName = TypeDescriptor.GetClassName(this.objValue);
            this.IsExpandable = true;
            base.menmPropertySort = objSortType;
            this.InternalExpanded = true;
        }

        internal void CategorizePropEntries()
        {
            if (this.Children.Count > 0)
            {
                GridEntry[] arrEntries = new GridEntry[this.Children.Count];
                this.Children.CopyTo(arrEntries, 0);
                if ((base.menmPropertySort & PropertySort.Categorized) != PropertySort.NoSort)
                {
                    Hashtable hashtable1 = new Hashtable();
                    for (int num1 = 0; num1 < arrEntries.Length; num1++)
                    {
                        GridEntry objGridEntry = arrEntries[num1];
                        if (objGridEntry != null)
                        {
                            string strText1 = objGridEntry.PropertyCategory;
                            ArrayList objList = (ArrayList)hashtable1[strText1];
                            if (objList == null)
                            {
                                objList = new ArrayList();
                                hashtable1[strText1] = objList;
                            }
                            objList.Add(objGridEntry);
                        }
                    }
                    ArrayList objList2 = new ArrayList();
                    IDictionaryEnumerator enumerator1 = hashtable1.GetEnumerator();
                    while (enumerator1.MoveNext())
                    {
                        ArrayList objList3 = (ArrayList)enumerator1.Value;
                        if (objList3 != null)
                        {
                            string strText2 = (string)enumerator1.Key;
                            if (objList3.Count > 0)
                            {
                                GridEntry[] arrEntries2 = new GridEntry[objList3.Count];
                                objList3.CopyTo(arrEntries2, 0);
                                try
                                {
                                    objList2.Add(new CategoryGridEntry(base.mobjOwnerPropertyGrid, this, strText2, arrEntries2));
                                    continue;
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    arrEntries = new GridEntry[objList2.Count];
                    objList2.CopyTo(arrEntries, 0);
                    StringSorter.Sort(arrEntries);
                    base.ChildCollection.Clear();
                    base.ChildCollection.AddRange(arrEntries);
                }
            }
        }

        protected override bool CreateChildren()
        {
            bool blnFlag1 = base.CreateChildren();
            this.CategorizePropEntries();
            return blnFlag1;
        }

        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                this.host = null;
                this.baseProvider = null;
                this.tab = null;
                this.gridEntryHost = null;
                this.changeService = null;
            }
            this.objValue = null;
            this.objValueClassName = null;
            this.propDefault = null;
            base.Dispose(blnDisposing);
        }

        public override object GetService(Type objServiceType)
        {
            object obj1 = null;
            if (this.host != null)
            {
                obj1 = this.host.GetService(objServiceType);
            }
            if ((obj1 == null) && (this.baseProvider != null))
            {
                obj1 = this.baseProvider.GetService(objServiceType);
            }
            return obj1;
        }

        public void ResetBrowsableAttributes()
        {
            this.browsableAttributes = new AttributeCollection(new Attribute[] { BrowsableAttribute.Yes });
        }

        public virtual void ShowCategories(bool fCategories)
        {
            if (((base.menmPropertySort &= PropertySort.Categorized) != PropertySort.NoSort) != fCategories)
            {
                if (fCategories)
                {
                    base.menmPropertySort |= PropertySort.Categorized;
                }
                else
                {
                    base.menmPropertySort &= ~PropertySort.Categorized;
                }
                if (this.Expandable && (base.ChildCollection != null))
                {
                    this.CreateChildren();
                }
            }
        }


        internal override bool AlwaysAllowExpand
        {
            get
            {
                return true;
            }
        }

        public override AttributeCollection BrowsableAttributes
        {
            get
            {
                if (this.browsableAttributes == null)
                {
                    this.browsableAttributes = new AttributeCollection(new Attribute[] { BrowsableAttribute.Yes });
                }
                return this.browsableAttributes;
            }
            set
            {
                if (value == null)
                {
                    this.ResetBrowsableAttributes();
                }
                else
                {
                    bool blnFlag1 = true;
                    if (((this.browsableAttributes != null) && (value != null)) && (this.browsableAttributes.Count == value.Count))
                    {
                        Attribute[] arrAttributeArray1 = new Attribute[this.browsableAttributes.Count];
                        Attribute[] arrAttributeArray2 = new Attribute[value.Count];
                        this.browsableAttributes.CopyTo(arrAttributeArray1, 0);
                        value.CopyTo(arrAttributeArray2, 0);
                        Array.Sort(arrAttributeArray1, GridEntry.AttributeTypeSorter);
                        Array.Sort(arrAttributeArray2, GridEntry.AttributeTypeSorter);
                        for (int num1 = 0; num1 < arrAttributeArray1.Length; num1++)
                        {
                            if (!arrAttributeArray1[num1].Equals(arrAttributeArray2[num1]))
                            {
                                blnFlag1 = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        blnFlag1 = false;
                    }
                    this.browsableAttributes = value;
                    if ((!blnFlag1 && (this.Children != null)) && (this.Children.Count > 0))
                    {
                        this.DisposeChildren();
                    }
                }
            }
        }

        protected override IComponentChangeService ComponentChangeService
        {
            get
            {
                if (this.changeService == null)
                {
                    this.changeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
                }
                return this.changeService;
            }
        }

        public override PropertyTab CurrentTab
        {
            get
            {
                return this.tab;
            }
            set
            {
                this.tab = value;
            }
        }

        internal override GridEntry DefaultChild
        {
            get
            {
                return this.propDefault;
            }
            set
            {
                this.propDefault = value;
            }
        }

        internal override IDesignerHost DesignerHost
        {
            get
            {
                return this.host;
            }
            set
            {
                this.host = value;
            }
        }

        internal override bool ForceReadOnly
        {
            get
            {
                if (!this.forceReadOnlyChecked)
                {
                    ReadOnlyAttribute attribute1 = (ReadOnlyAttribute)TypeDescriptor.GetAttributes(this.objValue)[typeof(ReadOnlyAttribute)];
                    if (((attribute1 != null) && !attribute1.IsDefaultAttribute()) || TypeDescriptor.GetAttributes(this.objValue).Contains(InheritanceAttribute.InheritedReadOnly))
                    {
                        base.State |= 0x400;
                    }
                    this.forceReadOnlyChecked = true;
                }
                if (base.ForceReadOnly)
                {
                    return true;
                }
                if (this.GridEntryHost != null)
                {
                    return !this.GridEntryHost.Enabled;
                }
                return false;
            }
        }

        internal override PropertyGridView GridEntryHost
        {
            get
            {
                return this.gridEntryHost;
            }
            set
            {
                this.gridEntryHost = value;
            }
        }

        public override Gizmox.WebGUI.Forms.GridItemType GridItemType
        {
            get
            {
                return Gizmox.WebGUI.Forms.GridItemType.Root;
            }
        }

        public override string HelpKeyword
        {
            get
            {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                HelpKeywordAttribute attribute1 = (HelpKeywordAttribute)TypeDescriptor.GetAttributes(this.objValue)[typeof(HelpKeywordAttribute)];
                if ((attribute1 != null) && !attribute1.IsDefaultAttribute())
                {
                    return attribute1.HelpKeyword;
                }
#endif
                return this.objValueClassName;
            }
        }

        public override string PropertyLabel
        {
            get
            {
                if (this.objValue is IComponent)
                {
                    ISite objSite = ((IComponent)this.objValue).Site;
                    if (objSite == null)
                    {
                        return this.objValue.GetType().Name;
                    }
                    return objSite.Name;
                }
                if (this.objValue != null)
                {
                    return this.objValue.ToString();
                }
                return null;
            }
        }

        public override object PropertyValue
        {
            get
            {
                return this.objValue;
            }
            set
            {
                object obj1 = this.objValue;
                this.objValue = value;
                this.objValueClassName = TypeDescriptor.GetClassName(this.objValue);
                base.mobjOwnerPropertyGrid.ReplaceSelectedObject(obj1, value);
            }
        }
    }

    #endregion

    #region CategoryGridEntry Class

    [Serializable()]
    internal class CategoryGridEntry : GridEntry
    {
        private static Hashtable mobjCategoryStates;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        internal string Name
        {
            get
            {
                return this.GetValue<string>(CategoryGridEntry.NameProperty);
            }
            set
            {
                this.SetValue<string>(CategoryGridEntry.NameProperty, value);
            }
        }

        /// <summary>
        /// The string property registration.
        /// </summary>
        private static readonly SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(CategoryGridEntry));



        public CategoryGridEntry(PropertyGrid objOwnerGrid, GridEntry objParentGrid, string strName, GridEntry[] arrChildGridEntries)
            : base(objOwnerGrid, objParentGrid)
        {
            this.Name = strName;
            if (CategoryGridEntry.mobjCategoryStates == null)
            {
                CategoryGridEntry.mobjCategoryStates = new Hashtable();
            }
            lock (CategoryGridEntry.mobjCategoryStates)
            {
                if (!CategoryGridEntry.mobjCategoryStates.ContainsKey(strName))
                {
                    CategoryGridEntry.mobjCategoryStates.Add(strName, true);
                }
            }
            this.IsExpandable = true;
            for (int num1 = 0; num1 < arrChildGridEntries.Length; num1++)
            {
                arrChildGridEntries[num1].ParentGridEntry = this;
            }
            base.ChildCollection = new GridEntryCollection(this, arrChildGridEntries);
            lock (CategoryGridEntry.mobjCategoryStates)
            {
                this.InternalExpanded = (bool)CategoryGridEntry.mobjCategoryStates[strName];
            }
            this.SetState(0x40, true);
        }

        protected override bool CreateChildren(bool blnDiffOldChildren)
        {
            return true;
        }

        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                if (base.ChildCollection != null)
                {
                    base.ChildCollection = null;
                }
            }
            base.Dispose(blnDisposing);
        }

        public override void DisposeChildren()
        {
        }



        public override object GetChildValueOwner(GridEntry objChildGridEntry)
        {
            return this.ParentGridEntry.GetChildValueOwner(objChildGridEntry);
        }

        public override string GetPropertyTextValue(object objObject)
        {
            return "";
        }

        public override string GetTestingInfo()
        {
            string strText1 = "object = (";
            strText1 = strText1 + base.FullLabel;
            return (strText1 + "), Category = (" + this.PropertyLabel + ")");
        }

        internal override bool NotifyChildValue(GridEntry objGridEntry, int intType)
        {
            return base.mobjParentGridEntry.NotifyChildValue(objGridEntry, intType);
        }


        public override bool Expandable
        {
            get
            {
                return !this.GetStateSet(0x80000);
            }
        }

        public override Gizmox.WebGUI.Forms.GridItemType GridItemType
        {
            get
            {
                return Gizmox.WebGUI.Forms.GridItemType.Category;
            }
        }

        internal override bool HasValue
        {
            get
            {
                return false;
            }
        }

        public override string HelpKeyword
        {
            get
            {
                return null;
            }
        }

        internal override bool InternalExpanded
        {
            set
            {
                base.InternalExpanded = value;
                lock (CategoryGridEntry.mobjCategoryStates)
                {
                    CategoryGridEntry.mobjCategoryStates[this.Name] = value;
                }
            }
        }



        public override int PropertyDepth
        {
            get
            {
                return (base.PropertyDepth - 1);
            }
        }

        public override string PropertyLabel
        {
            get
            {
                return this.Name;
            }
        }


        public override Type PropertyType
        {
            get
            {
                return typeof(void);
            }
        }

    }
    #endregion

    #region IRootGridEntry Interface

    /// <summary>Defines methods and a property that allow filtering on specific attributes.</summary>
    public interface IRootGridEntry
    {
        /// <summary>Resets the <see cref="P:Gizmox.WebGUI.Forms.PropertyGridInternal.IRootGridEntry.BrowsableAttributes"></see> property to the default value.</summary>
        void ResetBrowsableAttributes();
        /// <summary>Sorts the properties in the property browser.</summary>
        /// <param name="blnShowCategories">true to group the properties by category; otherwise, false.</param>
        void ShowCategories(bool blnShowCategories);

        /// <summary>Gets or sets the attributes on which the property browser filters.</summary>
        /// <returns>The attributes on which the property browser filters.</returns>
        AttributeCollection BrowsableAttributes { get; set; }

    }

    #endregion

    #region AttributeTypeSorter Class

    [Serializable()]
    internal class AttributeTypeSorter : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            Attribute attribute1 = obj1 as Attribute;
            Attribute attribute2 = obj2 as Attribute;
            if ((attribute1 == null) && (attribute2 == null))
            {
                return 0;
            }
            if (attribute1 == null)
            {
                return -1;
            }
            if (attribute2 == null)
            {
                return 1;
            }
            return string.Compare(AttributeTypeSorter.GetTypeIdString(attribute1), AttributeTypeSorter.GetTypeIdString(attribute2), false, CultureInfo.InvariantCulture);
        }

        private static string GetTypeIdString(Attribute objAttribute)
        {
            string strText1;
            object obj1 = objAttribute.TypeId;
            if (obj1 == null)
            {
                return "";
            }
            if (AttributeTypeSorter.mobjTypeIds == null)
            {
                AttributeTypeSorter.mobjTypeIds = new Hashtable();
                strText1 = null;
            }
            else
            {
                strText1 = AttributeTypeSorter.mobjTypeIds[obj1] as string;
            }
            if (strText1 == null)
            {
                strText1 = obj1.ToString();
                AttributeTypeSorter.mobjTypeIds[obj1] = strText1;
            }
            return strText1;
        }


        private static IDictionary mobjTypeIds;
    }

    #endregion

    #region PropertiesTab Class


    /// <summary>
    /// Represents the Properties tab on a PropertyGrid control.
    /// </summary>
    [Serializable()]
    public class PropertiesTab : PropertyTab
    {
        /// <summary>
        /// Gets the default Property Descriptor.
        /// </summary>
        /// <param name="objObject">The obj object.</param>
        /// <returns></returns>
        public override PropertyDescriptor GetDefaultProperty(object objObject)
        {
            PropertyDescriptor objPropertyDescriptor1 = base.GetDefaultProperty(objObject);
            if (objPropertyDescriptor1 == null)
            {
                PropertyDescriptorCollection objCollection1 = this.GetProperties(objObject);
                if (objCollection1 == null)
                {
                    return objPropertyDescriptor1;
                }
                for (int num1 = 0; num1 < objCollection1.Count; num1++)
                {
                    if ("Name".Equals(objCollection1[num1].Name))
                    {
                        return objCollection1[num1];
                    }
                }
            }
            return objPropertyDescriptor1;
        }

        /// <summary>
        /// Returns a collection of property descriors
        /// </summary>
        /// <param name="objComponent">The obj component.</param>
        /// <param name="arrAttributes">The arr attributes.</param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes)
        {
            return this.GetProperties(null, objComponent, arrAttributes);
        }

        /// <summary>
        /// Returns a collection of property descriors
        /// </summary>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
        {
            if (arrAttributes == null)
            {
                arrAttributes = new Attribute[] { BrowsableAttribute.Yes };
            }

            // If we are in Partially Trusted Environment(PTE), filter by additional attribute
            // to hide properties marked as not browsable(false) in PTE
            if (CommonUtils.IsEnvironmentSecurityPermitted)
            {
                Attribute[] arrAttributesSecured = new Attribute[arrAttributes.Length + 1];
                arrAttributes.CopyTo(arrAttributesSecured, 0);
                arrAttributesSecured[arrAttributesSecured.Length - 1] = LimitedTrustBrowsableAttribute.Yes;
                arrAttributes = arrAttributesSecured;
            }

            if (objContext != null)
            {
                TypeConverter objConverter1 = (objContext.PropertyDescriptor == null) ? TypeDescriptor.GetConverter(objComponent) : objContext.PropertyDescriptor.Converter;
                if ((objConverter1 != null) && objConverter1.GetPropertiesSupported(objContext))
                {
                    return objConverter1.GetProperties(objContext, objComponent, arrAttributes);
                }
            }
            return TypeDescriptor.GetProperties(objComponent, arrAttributes);
        }


        /// <summary>
        /// Gets the Help keyword that is to be associated with this tab.
        /// </summary>
        /// <value></value>
        /// <returns>The string vs.properties.</returns>
        public override string HelpKeyword
        {
            get
            {
                return "vs.properties";
            }
        }

        /// <summary>Gets the name of the Properties tab.</summary>
        /// <returns>The string Properties.</returns>
        public override string TabName
        {
            get
            {
                return SR.GetString("PBRSToolTipProperties");
            }
        }

    }

    #endregion
}