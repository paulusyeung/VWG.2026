#region Using

using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins; 

#endregion

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
    /// <summary>
    /// 
    /// </summary>
    [MetadataTag(WGTags.PropertyGridView)]
    [Skin(typeof(PropertyGridSkin)), Serializable()]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class PropertyGridView : Control, IServiceProvider, IWebUIEditorService
    {
        #region Class Members

        protected const short ERROR_MSGBOX_UP = 2;
        protected const short ERROR_NONE = 0;
        protected const short ERROR_THROWN = 1;
        protected const int mcntDefaultLablesColumnWidth = 100;

        private const short FlagBtnLaunchedEditor = 0x100;
        private const short FlagInPropertySet = 0x10;
        private const short FlagIsNewSelection = 2;
        private const short FlagNeedsRefresh = 1;
        private const short FlagNeedUpdateUIBasedOnFont = 0x80;
        private const short FlagNoDefault = 0x200;
        private const short FlagResizableDropDown = 0x400;
        internal const int MaxRecurseExpand = 10;

        private short errorState
        {
            get
            {
                return this.GetValue<short>(PropertyGridView.errorStateProperty);
            }
            set
            {
                this.SetValue<short>(PropertyGridView.errorStateProperty, value);
            }
        }

        /// <summary>
        /// The short property registration.
        /// </summary>
        private static readonly SerializableProperty errorStateProperty = SerializableProperty.Register("errorState", typeof(short), typeof(PropertyGridView));

        private short flags
        {
            get
            {
                return this.GetValue<short>(PropertyGridView.flagsProperty, 0x83);
            }
            set
            {
                this.SetValue<short>(PropertyGridView.flagsProperty, value);
            }
        }

        /// <summary>
        /// The short property registration.
        /// </summary>
        private static readonly SerializableProperty flagsProperty = SerializableProperty.Register("flags", typeof(short), typeof(PropertyGridView));

        private Font fontBold
        {
            get
            {
                return this.GetValue<Font>(PropertyGridView.fontBoldProperty);
            }
            set
            {
                this.SetValue<Font>(PropertyGridView.fontBoldProperty, value);
            }
        }

        /// <summary>
        /// The Font property registration.
        /// </summary>
        private static readonly SerializableProperty fontBoldProperty = SerializableProperty.Register("fontBold", typeof(Font), typeof(PropertyGridView));

        private GridEntryCollection mobjAllGridEntries
        {
            get
            {
                return this.GetValue<GridEntryCollection>(PropertyGridView.mobjAllGridEntriesProperty);
            }
            set
            {
                this.SetValue<GridEntryCollection>(PropertyGridView.mobjAllGridEntriesProperty, value);
            }
        }

        /// <summary>
        /// The GridEntryCollection property registration.
        /// </summary>
        private static readonly SerializableProperty mobjAllGridEntriesProperty = SerializableProperty.Register("mobjAllGridEntries", typeof(GridEntryCollection), typeof(PropertyGridView));

        private IHelpService mobjHelpService
        {
            get
            {
                return this.GetValue<IHelpService>(PropertyGridView.mobjHelpServiceProperty);
            }
            set
            {
                this.SetValue<IHelpService>(PropertyGridView.mobjHelpServiceProperty, value);
            }
        }

        /// <summary>
        /// The IHelpService property registration.
        /// </summary>
        private static readonly SerializableProperty mobjHelpServiceProperty = SerializableProperty.Register("mobjHelpService", typeof(IHelpService), typeof(PropertyGridView));

        private PropertyGrid mobjOwnerGrid
        {
            get
            {
                return this.GetValue<PropertyGrid>(PropertyGridView.mobjOwnerGridProperty);
            }
            set
            {
                this.SetValue<PropertyGrid>(PropertyGridView.mobjOwnerGridProperty, value);
            }
        }

        /// <summary>
        /// The PropertyGrid property registration.
        /// </summary>
        private static readonly SerializableProperty mobjOwnerGridProperty = SerializableProperty.Register("mobjOwnerGrid", typeof(PropertyGrid), typeof(PropertyGridView));

        private GridEntry mobjSelectedGridEntry
        {
            get
            {
                return this.GetValue<GridEntry>(PropertyGridView.mobjSelectedGridEntryProperty);
            }
            set
            {
                this.SetValue<GridEntry>(PropertyGridView.mobjSelectedGridEntryProperty, value);
            }
        }

        /// <summary>
        /// The GridEntry property registration.
        /// </summary>
        private static readonly SerializableProperty mobjSelectedGridEntryProperty = SerializableProperty.Register("mobjSelectedGridEntry", typeof(GridEntry), typeof(PropertyGridView));

        private int mintSelectedRow
        {
            get
            {
                return this.GetValue<int>(PropertyGridView.mintSelectedRowProperty, -1);
            }
            set
            {
                this.SetValue<int>(PropertyGridView.mintSelectedRowProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintSelectedRowProperty = SerializableProperty.Register("mintSelectedRow", typeof(int), typeof(PropertyGridView));

        private IServiceProvider mobjServiceProvider
        {
            get
            {
                return this.GetValue<IServiceProvider>(PropertyGridView.mobjServiceProviderProperty);
            }
            set
            {
                this.SetValue<IServiceProvider>(PropertyGridView.mobjServiceProviderProperty, value);
            }
        }

        /// <summary>
        /// The IServiceProvider property registration.
        /// </summary>
        private static readonly SerializableProperty mobjServiceProviderProperty = SerializableProperty.Register("mobjServiceProvider", typeof(IServiceProvider), typeof(PropertyGridView));

        private int mintTipInfo
        {
            get
            {
                return this.GetValue<int>(PropertyGridView.mintTipInfoProperty, -1);
            }
            set
            {
                this.SetValue<int>(PropertyGridView.mintTipInfoProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintTipInfoProperty = SerializableProperty.Register("mintTipInfo", typeof(int), typeof(PropertyGridView));

        private IHelpService mobjTopHelpService
        {
            get
            {
                return this.GetValue<IHelpService>(PropertyGridView.mobjTopHelpServiceProperty);
            }
            set
            {
                this.SetValue<IHelpService>(PropertyGridView.mobjTopHelpServiceProperty, value);
            }
        }

        /// <summary>
        /// The IHelpService property registration.
        /// </summary>
        private static readonly SerializableProperty mobjTopHelpServiceProperty = SerializableProperty.Register("mobjTopHelpService", typeof(IHelpService), typeof(PropertyGridView));

        private GridEntryCollection mobjTopLevelGridEntries
        {
            get
            {
                return this.GetValue<GridEntryCollection>(PropertyGridView.mobjTopLevelGridEntriesProperty);
            }
            set
            {
                this.SetValue<GridEntryCollection>(PropertyGridView.mobjTopLevelGridEntriesProperty, value);
            }
        }

        /// <summary>
        /// The GridEntryCollection property registration.
        /// </summary>
        private static readonly SerializableProperty mobjTopLevelGridEntriesProperty = SerializableProperty.Register("mobjTopLevelGridEntries", typeof(GridEntryCollection), typeof(PropertyGridView));

        internal int mintTotalProps
        {
            get
            {
                return this.GetValue<int>(PropertyGridView.mintTotalPropsProperty, -1);
            }
            set
            {
                this.SetValue<int>(PropertyGridView.mintTotalPropsProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintTotalPropsProperty = SerializableProperty.Register("mintTotalProps", typeof(int), typeof(PropertyGridView));

        private int mintLablesColumnWidth
        {
            get
            {
                return this.GetValue<int>(PropertyGridView.mintLablesColumnWidthProperty, mcntDefaultLablesColumnWidth);
            }
            set
            {
                this.SetValue<int>(PropertyGridView.mintLablesColumnWidthProperty, value);
            }
        }

        /// <summary>
        /// The int property registration.
        /// </summary>
        private static readonly SerializableProperty mintLablesColumnWidthProperty = SerializableProperty.Register("mintLablesColumnWidth", typeof(int), typeof(PropertyGridView));

        #endregion

        #region C'Tor

        /// <summary>
        /// 
        /// </summary>
        static PropertyGridView()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objServiceProvider"></param>
        /// <param name="objPropertyGrid"></param>
        public PropertyGridView(IServiceProvider objServiceProvider, PropertyGrid objPropertyGrid)
        {

            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, false);
            base.SetStyle(ControlStyles.UserMouse, true);

            this.mobjOwnerGrid = objPropertyGrid;
            this.mobjServiceProvider = objServiceProvider;
            base.TabStop = true;
            this.Text = "PropertyGridView";
            this.CreateUI();

        }

        #endregion

        #region Methods

        #region Render Related

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            if (!this.OwnerGrid.HelpVisible)
            {
                objWriter.WriteAttributeString(WGAttributes.HelpVisible, "0");
            }
            if (this.LablesColumnWidth != mcntDefaultLablesColumnWidth)
            {
                objWriter.WriteAttributeString(WGAttributes.LablesColumnWidth, this.LablesColumnWidth.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
        {
            if (mobjTopLevelGridEntries != null)
            {
                foreach (GridEntry objGridEntry in this.mobjTopLevelGridEntries)
                {
                    ((IRenderableComponentMember)objGridEntry).RenderComponent(objContext, objWriter, lngRequestID, !blnFullRedraw);
                }
            }
        }

        #endregion

        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Member == string.Empty)
            {
                base.FireEvent(objEvent);

                switch (objEvent.Type)
                {
                    case "SplitterChange":
                        if (objEvent[WGAttributes.Width] != null)
                        {
                            double dlbWidth = Convert.ToDouble(objEvent[WGAttributes.Width], CultureInfo.InvariantCulture );

                            this.LablesColumnWidth = Convert.ToInt32(dlbWidth);
                        }
                        break;
                }
            }
            else
            {
                int intMemberID = int.Parse(objEvent.Member);

                IRegisteredComponentMember objGridEntry = GetGridEntry(intMemberID);
                if (objGridEntry != null)
                {

                    objGridEntry.FireEvent(objEvent);
                }
            }

        }

        private IRegisteredComponentMember GetGridEntry(int intMemberID)
        {
            return GetGridEntry(intMemberID, this.mobjTopLevelGridEntries);
        }

        private IRegisteredComponentMember GetGridEntry(int intMemberID, GridEntryCollection objGridEntries)
        {
            if (objGridEntries != null)
            {
                foreach (GridEntry objGridEntry in objGridEntries)
                {
                    IRegisteredComponentMember objComponent = objGridEntry as IRegisteredComponentMember;
                    if (objComponent.MemberID == intMemberID)
                    {
                        return objComponent;
                    }

                    objComponent = GetGridEntry(intMemberID, objGridEntry.Children);
                    if (objComponent != null)
                    {
                        return objComponent;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Clears all properties
        /// </summary>
        public void ClearProps()
        {
            // If there are entries
            if (this.HasEntries)
            {
                this.mobjTopLevelGridEntries = null;
                this.mobjAllGridEntries = null;
                this.mintSelectedRow = -1;
                this.mintTipInfo = -1;
            }
        }

        /// <summary>
        /// Closes the current opened drop down
        /// </summary>
        public void CloseDropDown()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Commit()
        {
            return true;
        }

        /// <summary>
        /// Commits the text.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="objGridEntry">The grid entry.</param>
        /// <returns></returns>
        internal bool CommitText(string strText, GridEntry objGridEntry)
        {
            object objValue = null;

            if (objGridEntry == null)
            {
                return true;
            }
            try
            {
                objValue = objGridEntry.ConvertTextToValue(strText);
            }
            catch (Exception objException1)
            {
                this.SetCommitError(1);
                this.ShowInvalidMessage(objGridEntry.PropertyLabel, strText, objException1);
                return false;
            }
            this.SetCommitError(0);
            return this.CommitValue(objGridEntry, objValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        private bool CommitText(string strText)
        {
            return this.CommitText(strText, this.mobjSelectedGridEntry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private bool CommitValue(object objValue)
        {
            GridEntry objGridEntry = this.mobjSelectedGridEntry;
            if (objGridEntry == null)
            {
                return true;
            }

            PropertyValueChangingEventArgs e = this.mobjOwnerGrid.OnPropertyValueSetting(objGridEntry, objValue);
            objValue = e.NewValue;
            if (e.Cancel)
            {
                // Change cancelled
                objGridEntry.Update();
                return false;
            }
            else
            {
                object objOldValue = null;
                try
                {
                    objOldValue = objGridEntry.PropertyValue;
                }
                catch
                {
                }                
                bool blnResult = this.DoCommitValue(objGridEntry, objValue);
                this.mobjOwnerGrid.OnPropertyValueSet(objGridEntry, objOldValue);
                return blnResult;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGridEntry"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private bool DoCommitValue(GridEntry objGridEntry, object objValue)
        {

            return objGridEntry.SetPropertyValue(objValue, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objGridEntry"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        internal bool CommitValue(GridEntry objGridEntry, object objValue)
        {
            PropertyValueChangingEventArgs e = this.mobjOwnerGrid.OnPropertyValueSetting(objGridEntry, objValue);
            objValue = e.NewValue;
            if (e.Cancel)
            {
                // Change cancelled
                objGridEntry.Update();
                return false;
            }
            else
            {
                object objOldValue = null;
                try
                {
                    objOldValue = objGridEntry.PropertyValue;
                }
                catch
                {
                }
                bool blnResult = this.DoCommitValue(objGridEntry, objValue);
                this.mobjOwnerGrid.OnPropertyValueSet(objGridEntry, objOldValue);
                
                // If value has changed, update Reset button.
                if (blnResult)
                {
                    this.UpdateResetButtonUI(objGridEntry);
                }
                
                return blnResult;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objEntries"></param>
        /// <returns></returns>
        private int CountPropsFromOutline(GridEntryCollection objEntries)
        {
            if (objEntries == null)
            {
                return 0;
            }
            int num1 = objEntries.Count;
            for (int num2 = 0; num2 < objEntries.Count; num2++)
            {
                if (((GridEntry)objEntries[num2]).InternalExpanded)
                {
                    num1 += this.CountPropsFromOutline(((GridEntry)objEntries[num2]).Children);
                }
            }
            return num1;
        }

        private Bitmap CreateDownArrow()
        {
            Bitmap bitmap1 = null;
            try
            {
                Icon icon1 = new Icon(typeof(PropertyGrid), "Arrow.ico");
                bitmap1 = icon1.ToBitmap();
                icon1.Dispose();
            }
            catch (Exception)
            {
                bitmap1 = new Bitmap(0x10, 0x10);
            }
            return bitmap1;
        }

        protected virtual void CreateUI()
        {

        }

        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {

                this.mobjOwnerGrid = null;
                this.mobjTopLevelGridEntries = null;
                this.mobjAllGridEntries = null;
                this.mobjServiceProvider = null;
                this.mobjTopHelpService = null;
                if ((this.mobjHelpService != null) && (this.mobjHelpService is IDisposable))
                {
                    ((IDisposable)this.mobjHelpService).Dispose();
                }
                this.mobjHelpService = null;

                if (this.fontBold != null)
                {
                    this.fontBold.Dispose();
                    this.fontBold = null;
                }


            }
            base.Dispose(blnDisposing);
        }

        public void DoCopyCommand()
        {
            if (this.CanCopy)
            {

            }
        }

        public void DoCutCommand()
        {
            if (this.CanCut)
            {

            }
        }

        public void DoPasteCommand()
        {
            if (this.CanPaste)
            {

            }
        }

        public void DoubleClickRow(int intRow, bool blnToggleExpand, int type)
        {

        }

        private GridEntry GetGridEntryFromRow(int intRow)
        {
            return null;
        }

        public void DoUndoCommand()
        {
            if (this.CanUndo)
            {

            }
        }

        public virtual void DropDownDone()
        {
            this.CloseDropDown();
        }

        public virtual void DropDownUpdate()
        {

        }

        public bool EnsurePendingChangesCommitted()
        {
            this.CloseDropDown();
            return this.Commit();
        }

        private GridEntry FindEquivalentGridEntry(GridEntryCollection objEntries)
        {
            if ((objEntries == null) || (objEntries.Count == 0))
            {
                return null;
            }
            GridEntryCollection objCollection1 = this.GetAllGridEntries();
            if ((objCollection1 == null) || (objCollection1.Count == 0))
            {
                return null;
            }
            GridEntry objGridEntry = null;
            int num1 = 0;
            int num2 = objCollection1.Count;
            for (int num3 = 0; num3 < objEntries.Count; num3++)
            {
                if (objEntries[num3] != null)
                {
                    if (objGridEntry != null)
                    {
                        int num5 = objCollection1.Count;
                        if (!objGridEntry.InternalExpanded)
                        {
                            objCollection1 = this.GetAllGridEntries();
                        }
                        num2 = objGridEntry.VisibleChildCount;
                    }
                    int num4 = num1;
                    objGridEntry = null;
                    while ((num1 < objCollection1.Count) && ((num1 - num4) <= num2))
                    {
                        if (objEntries.GetEntry(num3).NonParentEquals(objCollection1[num1]))
                        {
                            objGridEntry = objCollection1.GetEntry(num1);
                            num1++;
                            break;
                        }
                        num1++;
                    }
                    if (objGridEntry == null)
                    {
                        return objGridEntry;
                    }
                }
            }
            return objGridEntry;
        }

        public virtual void Flush()
        {

        }

        private GridEntryCollection GetAllGridEntries()
        {
            return this.GetAllGridEntries(false);
        }

        private GridEntryCollection GetAllGridEntries(bool fUpdateCache)
        {
            if (this.mintTotalProps == -1 || !this.HasEntries)
            {
                return null;
            }
            if ((this.mobjAllGridEntries == null) || fUpdateCache)
            {
                GridEntry[] arrEntries = new GridEntry[this.mintTotalProps];
                try
                {
                    this.GetGridEntriesFromOutline(this.mobjTopLevelGridEntries, 0, 0, arrEntries);
                }
                catch (Exception)
                {
                }
                this.mobjAllGridEntries = new GridEntryCollection(null, arrEntries);
            }
            return this.mobjAllGridEntries;
        }

        private int GetCurrentValueIndex(GridEntry objGridEntry)
        {
            if (objGridEntry.Enumerable)
            {
                try
                {
                    object[] arrObjects1 = objGridEntry.GetPropertyValueList();
                    object obj1 = objGridEntry.PropertyValue;
                    string strText1 = objGridEntry.TypeConverter.ConvertToString(objGridEntry, obj1);
                    if ((arrObjects1 != null) && (arrObjects1.Length > 0))
                    {
                        int num1 = -1;
                        int num2 = -1;
                        for (int num3 = 0; num3 < arrObjects1.Length; num3++)
                        {
                            object obj2 = arrObjects1[num3];
                            string strText2 = objGridEntry.TypeConverter.ConvertToString(obj2);
                            if ((obj1 == obj2) || (string.Compare(strText1, strText2, true, CultureInfo.InvariantCulture) == 0))
                            {
                                num1 = num3;
                            }
                            if (((obj1 != null) && (obj2 != null)) && obj2.Equals(obj1))
                            {
                                num2 = num3;
                            }
                            if ((num1 == num2) && (num1 != -1))
                            {
                                return num1;
                            }
                        }
                        if (num1 != -1)
                        {
                            return num1;
                        }
                        if (num2 != -1)
                        {
                            return num2;
                        }
                    }
                }
                catch (Exception)
                {
                }

            }
            return -1;
        }

        public virtual int GetDefaultOutlineIndent()
        {
            return 10;
        }

        private bool GetFlag(short shortFlag)
        {
            return ((this.flags & shortFlag) != 0);
        }

        private int GetGridEntriesFromOutline(GridEntryCollection objEntries, int cCur, int cTarget, GridEntry[] arrGridEntries)
        {
            if ((objEntries != null) && (objEntries.Count != 0))
            {
                cCur--;
                for (int num1 = 0; num1 < objEntries.Count; num1++)
                {
                    cCur++;
                    if (cCur >= (cTarget + arrGridEntries.Length))
                    {
                        return cCur;
                    }
                    GridEntry objGridEntry = objEntries.GetEntry(num1);
                    if (cCur >= cTarget)
                    {
                        arrGridEntries[cCur - cTarget] = objGridEntry;
                    }
                    if (objGridEntry.InternalExpanded)
                    {
                        GridEntryCollection objCollection1 = objGridEntry.Children;
                        if ((objCollection1 != null) && (objCollection1.Count > 0))
                        {
                            cCur = this.GetGridEntriesFromOutline(objCollection1, cCur + 1, cTarget, arrGridEntries);
                        }
                    }
                }
            }
            return cCur;
        }

        private GridEntry GetGridEntryFromOffset(int offset)
        {
            GridEntryCollection objCollection1 = this.GetAllGridEntries();
            if (((objCollection1 != null) && (offset >= 0)) && (offset < objCollection1.Count))
            {
                return objCollection1.GetEntry(offset);
            }
            return null;
        }

        private GridEntryCollection GetGridEntryHierarchy(GridEntry objGridEntry)
        {
            if (objGridEntry == null)
            {
                return null;
            }
            int num1 = objGridEntry.PropertyDepth;
            if (num1 > 0)
            {
                GridEntry[] arrEntries = new GridEntry[num1 + 1];
                while ((objGridEntry != null) && (num1 >= 0))
                {
                    arrEntries[num1] = objGridEntry;
                    objGridEntry = objGridEntry.ParentGridEntry;
                    num1 = objGridEntry.PropertyDepth;
                }
                return new GridEntryCollection(null, arrEntries);
            }
            return new GridEntryCollection(null, new GridEntry[] { objGridEntry });
        }

        private IHelpService GetHelpService()
        {
            if ((this.mobjHelpService == null) && (this.ServiceProvider != null))
            {
                this.mobjTopHelpService = (IHelpService)this.ServiceProvider.GetService(typeof(IHelpService));
                if (this.mobjTopHelpService != null)
                {
                    IHelpService objService1 = this.mobjTopHelpService.CreateLocalContext(HelpContextType.ToolWindowSelection);
                    if (objService1 != null)
                    {
                        this.mobjHelpService = objService1;
                    }
                }
            }
            return this.mobjHelpService;
        }

        public new object GetService(Type objClassService)
        {
            if (objClassService == typeof(IWebUIEditorService))
            {
                return this;
            }
            if (this.ServiceProvider != null)
            {
                return this.mobjServiceProvider.GetService(objClassService);
            }
            return null;
        }

        private int GetRowFromGridEntry(GridEntry objGridEntry)
        {
            // TODO: PROPERTYGRID
            return -1;
        }

        protected virtual void OnRecreateChildren(object s, GridEntryRecreateChildrenEventArgs e)
        {
            GridEntry objGridEntry = (GridEntry)s;
            if (objGridEntry.Expanded)
            {
                GridEntry[] arrEntries = new GridEntry[this.mobjAllGridEntries.Count];
                this.mobjAllGridEntries.CopyTo(arrEntries, 0);
                int num1 = -1;
                for (int num2 = 0; num2 < arrEntries.Length; num2++)
                {
                    if (arrEntries[num2] == objGridEntry)
                    {
                        num1 = num2;
                        break;
                    }
                }

                if (e.OldChildCount != e.NewChildCount)
                {
                    int num3 = arrEntries.Length + (e.NewChildCount - e.OldChildCount);
                    GridEntry[] arrEntries2 = new GridEntry[num3];
                    Array.Copy(arrEntries, 0, arrEntries2, 0, num1 + 1);
                    Array.Copy(arrEntries, (num1 + e.OldChildCount) + 1, arrEntries2, (num1 + e.NewChildCount) + 1, arrEntries.Length - ((num1 + e.OldChildCount) + 1));
                    arrEntries = arrEntries2;
                }
                GridEntryCollection objCollection1 = objGridEntry.Children;
                int num4 = objCollection1.Count;
                for (int num5 = 0; num5 < num4; num5++)
                {
                    arrEntries[(num1 + num5) + 1] = objCollection1.GetEntry(num5);
                }
                this.mobjAllGridEntries.Clear();
                this.mobjAllGridEntries.AddRange(arrEntries);

            }
            if (e.OldChildCount != e.NewChildCount)
            {
                this.mintTotalProps = this.CountPropsFromOutline(this.mobjTopLevelGridEntries);
            }
            base.Invalidate();
        }

        private void OnSysColorChange(object sender, UserPreferenceChangedEventArgs e)
        {
            if ((e.Category == UserPreferenceCategory.Color) || (e.Category == UserPreferenceCategory.Accessibility))
            {
                this.SetFlag(0x80, true);
            }
        }

        public virtual void PopupDialog(int intRow)
        {
            GridEntry objGridEntry = this.GetGridEntryFromRow(intRow);
            if (objGridEntry != null)
            {
            }
        }

        protected virtual void RecalculateProps()
        {
            int num1 = this.CountPropsFromOutline(this.mobjTopLevelGridEntries);
            if (this.mintTotalProps != num1)
            {
                this.mintTotalProps = num1;

                this.mobjAllGridEntries = null;
            }
        }

        public void Refresh()
        {
            this.Refresh(false, -1, -1);
            base.Invalidate();
        }

        public void Refresh(bool blnFullRefresh)
        {
            this.Refresh(blnFullRefresh, -1, -1);
        }

        private void Refresh(bool blnFullRefresh, int intRowStart, int intRowEnd)
        {
            this.SetFlag(FlagNeedsRefresh, true);
            GridEntry objGridEntry = null;
            if (!base.IsDisposed)
            {

                if (intRowStart == -1)
                {
                    intRowStart = 0;
                }
                if (blnFullRefresh || this.mobjOwnerGrid.HavePropEntriesChanged())
                {

                    int num1 = this.mintTotalProps;
                    object obj1 = ((this.mobjTopLevelGridEntries == null) || (this.mobjTopLevelGridEntries.Count == 0)) ? null : ((GridEntry)this.mobjTopLevelGridEntries[0]).GetValueOwner();
                    if (blnFullRefresh)
                    {
                        this.mobjOwnerGrid.RefreshProperties(true);
                    }
                    this.UpdateHelpAttributes(this.mobjSelectedGridEntry, null);
                    this.SetFlag(2, true);
                    this.mobjTopLevelGridEntries = this.mobjOwnerGrid.GetPropEntries();
                    this.mobjAllGridEntries = null;
                    this.RecalculateProps();
                    int num2 = this.mintTotalProps;
                    if (num2 > 0)
                    {


                        if (objGridEntry == null)
                        {
                            objGridEntry = this.mobjOwnerGrid.GetDefaultGridEntry();
                            this.SetFlag(0x200, (objGridEntry == null) && (this.mintTotalProps > 0));
                        }

                        if (objGridEntry == null)
                        {
                            this.mintSelectedRow = 0;
                            this.mobjSelectedGridEntry = this.GetGridEntryFromRow(this.mintSelectedRow);
                        }

                    }
                    else
                    {
                        if (num1 == 0)
                        {
                            return;
                        }

                    }
                }
                if (!this.HasEntries)
                {
                    this.mobjOwnerGrid.SetStatusBox(null, null);

                    this.mintSelectedRow = -1;
                    base.Invalidate();
                }
                else
                {
                    this.mobjOwnerGrid.ClearValueCaches();

                }
            }
        }

        internal void RemoveSelectedEntryHelpAttributes()
        {
            this.UpdateHelpAttributes(this.mobjSelectedGridEntry, null);
        }

        /// <summary>
        /// Resets this property.
        /// </summary>
        public virtual void Reset()
        {
            GridEntry objSelectedGridEntry = this.SelectedGridEntry;
            if (objSelectedGridEntry != null)
            {
                // Reset property.
                objSelectedGridEntry.ResetPropertyValue();
                
                // Causes grid entry redraw.
                objSelectedGridEntry.Update();
                
                // Update Reset button UI.
                UpdateResetButtonUI(objSelectedGridEntry);
            }
        }  

        protected virtual void ResetOrigin(Graphics objGraphics)
        {
            objGraphics.ResetTransform();
        }

        public virtual void RunDialog(Form objDialog)
        {
            this.ShowDialog(objDialog);
        }

        private void SetCommitError(short shortError)
        {
            this.SetCommitError(shortError, shortError == 1);
        }

        private void SetCommitError(short shortError, bool blnCapture)
        {
            this.errorState = shortError;
        }

        private void SetFlag(short shortFlag, bool blnValue)
        {
            if (blnValue)
            {
                this.flags = (short)(((ushort)this.flags) | ((ushort)shortFlag));
            }
            else
            {
                this.flags = (short)(this.flags & ~shortFlag);
            }
        }

        /// <summary>
        /// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
        /// </summary>
        /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
        public void ShowDialog(CommonDialog objDialog)
        {
            if (objDialog != null)
            {
                // Creating a default DialogType
                DialogTypes objCurrentDialogType = DialogTypes.ModalWindow;
                
                if (this.OwnerGrid != null && this.OwnerGrid.Form != null)
                {
                    // Getting the current form (ownerform) dialog type
                    objCurrentDialogType = this.OwnerGrid.Form.DialogType;
                }

                // If the current DialogType is PopupWindow, every webUIEditor will also be opened as a popup window.
                if (objCurrentDialogType == DialogTypes.PopupWindow)
                {
                    objDialog.ShowPopup(TopLevelControl as Form, this.SelectedGridEntry, null, DialogAlignment.Below, Point.Empty); 
                }
                else
                {
                    objDialog.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
        /// </summary>
        /// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
        public void ShowDialog(Form objDialog)
        {
            if (objDialog != null)
            {
                // Creating a default DialogType
                DialogTypes objCurrentDialogType = DialogTypes.ModalWindow;
                
                if (this.OwnerGrid != null && this.OwnerGrid.Form != null)
                {
                    // Getting the current form (ownerform) dialog type
                    objCurrentDialogType = this.OwnerGrid.Form.DialogType;
                }

                // If the current DialogType is PopupWindow, every webUIEditor will also be opened as a popup window.
                if (objCurrentDialogType == DialogTypes.PopupWindow)
                {
                    objDialog.ShowPopup(); 
                }
                else
                {
                    objDialog.ShowDialog();
                }
            }
        }

        private void ShowInvalidMessage(string strPropName, object objValue, Exception objException)
        {
            // TODO:PROPERTYGRID
        }

        public void ShowDropDown(Form objDialog)
        {
            if (objDialog != null)
            {
                if (this.SelectedGridEntry != null)
                {
                    objDialog.Width = this.Width - this.LablesColumnWidth - 15;

                    objDialog.ShowPopup(TopLevelControl as Form, this.SelectedGridEntry, DialogAlignment.Below);
                }
                else
                {
                    objDialog.ShowPopup();
                }
            }
        }

        private void UpdateHelpAttributes(GridEntry objOldEntry, GridEntry objNewEntry)
        {
            IHelpService objService1 = this.GetHelpService();
            if ((objService1 != null) && (objOldEntry != objNewEntry))
            {
                GridEntry objGridEntry = objOldEntry;
                if ((objOldEntry != null) && !objNewEntry.Disposed)
                {
                    while (objGridEntry != null)
                    {
                        objService1.RemoveContextAttribute("Keyword", objGridEntry.HelpKeyword);
                        objGridEntry = objGridEntry.ParentGridEntry;
                    }
                }
                if (objNewEntry != null)
                {
                    objGridEntry = objNewEntry;
                    this.UpdateHelpAttributes(objService1, objGridEntry, true);
                }
            }
        }

        private void UpdateHelpAttributes(IHelpService objHelpService, GridEntry objGridEntry, bool blnAddAsF1)
        {
            if (objGridEntry != null)
            {
                this.UpdateHelpAttributes(objHelpService, objGridEntry.ParentGridEntry, false);
                string strText1 = objGridEntry.HelpKeyword;
                if (strText1 != null)
                {
                    objHelpService.AddContextAttribute("Keyword", strText1, blnAddAsF1 ? HelpKeywordType.F1Keyword : HelpKeywordType.GeneralKeyword);
                }
            }
        }

        private void UpdateResetCommand(GridEntry objGridEntry)
        {

        }

        #endregion

        #region Properties

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool CanCopy
        {
            get
            {
                return false;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public bool CanCut
        {
            get
            {
                if (this.CanCopy)
                {
                    return this.mobjSelectedGridEntry.IsTextEditable;
                }
                return false;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool CanPaste
        {
            get
            {
                if (this.mobjSelectedGridEntry != null)
                {
                    return this.mobjSelectedGridEntry.IsTextEditable;
                }
                return false;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool CanUndo
        {
            get
            {
                return false;
            }
        }

        protected override bool IsDelayedDrawing
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        private bool HasEntries
        {
            get
            {
                if (this.mobjTopLevelGridEntries != null)
                {
                    return (this.mobjTopLevelGridEntries.Count > 0);
                }
                return false;
            }
        }

        protected bool NeedsCommit
        {
            get
            {
                return false;
            }
        }

        public PropertyGrid OwnerGrid
        {
            get
            {
                return this.mobjOwnerGrid;
            }
        }

        internal void SetActiveGridEntry(GridEntry objGridEntry)
        {
            this.OwnerGrid.SetActiveGridEntry(objGridEntry);
        }

        internal GridEntry SelectedGridEntry
        {
            get
            {
                return this.mobjSelectedGridEntry;
            }
            set
            {
                this.mobjSelectedGridEntry = value;

                // Update Reset button UI according to property reset functionality.
                UpdateResetButtonUI(value);
            }
        }

        /// <summary>
        /// Updates the Reset button UI.
        /// </summary>
        /// <param name="objGridEntry">The value.</param>
        internal void UpdateResetButtonUI(GridEntry objGridEntry)
        {
            // Get owner grid reset button.
            PropertyGrid objOwner = this.OwnerGrid;
            
            if (objOwner != null)
            {
                ToolStripButton objResetButton = objOwner.ResetButton;
                if (objResetButton != null)
                {                    
                    // Set its availability as property reset ability.
                    bool blnCanReset = objResetButton.Enabled = objOwner.CanResetPropertyValue(objGridEntry);

                    // Update tooltip text.
                    objResetButton.Text = blnCanReset ? string.Format("{0} {1}", SR.GetString("PBRSToolTipReset"), objGridEntry.PropertyName) : string.Empty;
                    objResetButton.Update(); 
                }
                
                               
            }
        }

        public IServiceProvider ServiceProvider
        {
            get
            {
                return this.mobjServiceProvider;
            }
            set
            {
                if (value != this.mobjServiceProvider)
                {
                    this.mobjServiceProvider = value;
                    this.mobjTopHelpService = null;
                    if ((this.mobjHelpService != null) && (this.mobjHelpService is IDisposable))
                    {
                        ((IDisposable)this.mobjHelpService).Dispose();
                    }
                    this.mobjHelpService = null;
                }
            }
        }

        private int TipColumn
        {
            get
            {
                return ((this.mintTipInfo & -65536) >> 0x10);
            }
            set
            {
                this.mintTipInfo &= 0xffff;
                this.mintTipInfo |= (value & 0xffff) << 0x10;
            }
        }

        private int TipRow
        {
            get
            {
                return (this.mintTipInfo & 0xffff);
            }
            set
            {
                this.mintTipInfo &= -65536;
                this.mintTipInfo |= value & 0xffff;
            }
        }

        private int LablesColumnWidth
        {
            get
            {
                return mintLablesColumnWidth;
            }
            set
            {
                if (mintLablesColumnWidth != value)
                {
                    mintLablesColumnWidth = value;
                }
            }
        }

        #endregion
    }
}