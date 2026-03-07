#region Using

using System;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Specifies the styles of the column headers in a ListView control.
    /// </summary>    
    public enum ColumnHeaderStyle
    {
        // Fields
        /// <summary>
        /// The column headers function like buttons and can carry out an action, such as sorting, when clicked.
        /// </summary>
        Clickable = 2,
        /// <summary>
        /// The column headers do not respond to the click of a mouse.
        /// </summary>
        Nonclickable = 1,
        /// <summary>
        /// The column header is not displayed in report view.
        /// </summary>
        None = 0
    }

    /// <summary>
    /// sort order options enumeration
    /// </summary>    
    [Serializable()]
    public enum SortOrder
    {
        /// <summary>
        /// The items are sorted in ascending order.
        /// </summary>
        Ascending = 1,
        /// <summary>
        /// The items are sorted in ascending order.
        /// </summary>
        Descending = 2,
        /// <summary>
        /// The items are not sorted.
        /// </summary>
        None = 0
    }

    /// <summary>Specifies how a column contained in a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> should be resized.</summary>

    public enum ColumnHeaderAutoResizeStyle
    {
        /// <summary>
        /// Specifies no resizing should occur.
        /// </summary>
        None,
        /// <summary>
        /// Specifies the column should be resized based on the length of the column header content.
        /// </summary>
        HeaderSize,
        /// <summary>
        /// Specifies the column should be resized based on the length of the column content.
        /// </summary>
        ColumnContent
    }






    #endregion Enums

    #region ColumnHeader Class

    /// <summary>
    /// Summary description for ColumnHeader.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.DesignTimeVisible(false)]
    [Serializable()]
    [TypeConverter(typeof(ColumnHeaderConverter))]
    public class ColumnHeader : Component, IComparable
    {
        #region Class Members

        /// <summary>
        /// The column header name
        /// </summary>
        [NonSerialized]
        private string mstrName = string.Empty;

        /// <summary>
        /// The column header label
        /// </summary>
        [NonSerialized]
        private string mstrLabel = string.Empty;

        /// <summary>
        /// The column header type
        /// </summary>
        [NonSerialized]
        private ListViewColumnType menmType = ListViewColumnType.Text;

        /// <summary>
        /// The column header width
        /// </summary>
        [NonSerialized]
        private int mintWidth = 150;

        /// <summary>
        /// The column header internal width
        /// </summary>
        [NonSerialized]
        private int mintInternalWidth = 150;

        /// <summary>
        /// The column header text align
        /// </summary>
        [NonSerialized]
        private HorizontalAlignment menmTextAlign = HorizontalAlignment.Left;

        /// <summary>
        /// The coumn header content alignment
        /// </summary>
        [NonSerialized]
        private ExtendedHorizontalAlignment menmContentAlignment = ExtendedHorizontalAlignment.Inherit;

        /// <summary>
        /// The column header index
        /// </summary>
        [NonSerialized]
        private int mintIndex = -1;

        /// <summary>
        /// The column header resource
        /// </summary>
        [NonSerialized]
        private ResourceHandle mobjResourceHandler = null;

        /// <summary>
        /// The column header display index
        /// </summary>
        [NonSerialized]
        private int mintDisplayIndexInternal = -1;

        /// <summary>
        /// Sort direction
        /// </summary>
        [NonSerialized]
        private SortOrder menmSortOrder = SortOrder.None;

        /// <summary>
        /// Sort position
        /// </summary>
        [NonSerialized]
        private int mintSortPosition = 1000;

        /// <summary>
        /// The column header group by flag
        /// </summary>
        [NonSerialized]
        private bool mblnGroupBy = false;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private int mintGroupByPosition = -1;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private int mintPreferedItemHeight = 0;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private int mintImageIndex = -1;

        /// <summary>
        /// 
        /// </summary>
        [NonSerialized]
        private string mstrImageKey = string.Empty;


        /// <summary>
        /// The amount of fields that the control writes / reads
        /// </summary>
        private const int mcntSerializableDataFieldCount = 15;

        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnHeader"/> class.
        /// </summary>
        public ColumnHeader()
        {
            InitializeState(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnHeader"/> class.
        /// </summary>
        /// <param name="strLabel">The STR label.</param>
        public ColumnHeader(string strLabel)
        {
            mstrLabel = strLabel;
            InitializeState(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        public ColumnHeader(string strName, string strLabel)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            InitializeState(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        /// <param name="blnLoaded"></param>
        public ColumnHeader(string strName, string strLabel, bool blnLoaded)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            InitializeState(blnLoaded);
        }

        /// <summary>
        /// Creates a new <see cref="ColumnHeader"/> instance.
        /// </summary>
        /// <param name="strName">Name.</param>
        /// <param name="strLabel">Label.</param>
        /// <param name="intWidth">Width.</param>
        public ColumnHeader(string strName, string strLabel, int intWidth)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            mintWidth = intWidth;
            InternalWidth = intWidth;
            InitializeState(true);
        }

        /// <summary>
        /// Creates a new <see cref="ColumnHeader"/> instance.
        /// </summary>
        /// <param name="strName">Name.</param>
        /// <param name="strLabel">Label.</param>
        /// <param name="intWidth">Width.</param>
        /// <param name="blnLoaded"></param>
        public ColumnHeader(string strName, string strLabel, int intWidth, bool blnLoaded)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            mintWidth = intWidth;
            InternalWidth = intWidth;
            InitializeState(blnLoaded);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        /// <param name="intWidth"></param>
        /// <param name="enmType"></param>        
        public ColumnHeader(string strName, string strLabel, int intWidth, ListViewColumnType enmType)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            mintWidth = intWidth;
            InternalWidth = intWidth;
            menmType = enmType;
            InitializeState(true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strLabel"></param>
        /// <param name="intWidth"></param>
        /// <param name="enmType"></param>
        /// <param name="blnLoaded"></param>
        public ColumnHeader(string strName, string strLabel, int intWidth, ListViewColumnType enmType, bool blnLoaded)
        {
            mstrName = strName;
            mstrLabel = strLabel;
            mintWidth = intWidth;
            InternalWidth = intWidth;
            menmType = enmType;
            InitializeState(blnLoaded);
        }


        #endregion C'Tor\D'Tor

        #region Methods

        /// <summary>
        /// Should serialize the display index.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeDisplayIndex()
        {
            return (this.DisplayIndex != this.Index);
        }

        /// <summary>
        /// Should serialize the name.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeName()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        /// <summary>
        /// Should serialize the text.
        /// </summary>
        /// <returns></returns>
        internal bool ShouldSerializeText()
        {
            return (this.Text != null);
        }

        /// <summary>
        /// Shoulds the serialize image.
        /// </summary>
        /// <returns></returns>
        internal bool ShouldSerializeImage()
        {
            return (this.mobjResourceHandler != null);
        }









        #region Events

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            //If the control is hidden or disabled
            //don't fire it's events
            if (this.Visible)
            {
                ListView objListView = null;

                // Select event type
                switch (objEvent.Type)
                {
                    case "ChangeColumnWidth":
                        double dblWidth = 0;

                        if (CommonUtils.TryParse(objEvent["Width"], out dblWidth))
                        {
                            mintWidth = Convert.ToInt32(dblWidth);

                            objListView = this.InternalParent as ListView;
                            if (objListView != null)
                            {
                                objListView.InternalColumnWidthChanged(this.Index);
                            }
                        }
                        break;
                    case "Sort":
                        objListView = this.InternalParent as ListView;
                        if (objListView != null)
                        {
                            objListView.SortBy(this);
                        }
                        break;
                }
            }

            base.FireEvent(objEvent);
        }

        #endregion Events

        /// <summary>
        /// Renders the column header.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        internal void RenderColumn(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            if (IsDirty(lngRequestID))
            {
                if (IsValidColumn)
                {
                    objWriter.WriteStartElement(WGTags.Column);
                    objWriter.WriteAttributeString("Id", this.GetProxyPropertyValue<long>("ID", this.ID).ToString());
                    objWriter.WriteAttributeString(WGAttributes.Name, "c" + Index.ToString());
                    objWriter.WriteAttributeText(WGAttributes.Text, Label, TextFilter.CarriageReturn | TextFilter.NewLine);
                    objWriter.WriteAttributeString(WGAttributes.Width, Math.Max(Width, 1).ToString());
                    objWriter.WriteAttributeString(WGAttributes.Type, Type.ToString());

                    objWriter.WriteAttributeString(WGAttributes.TextAlign, GetTextAlign());
                    objWriter.WriteAttributeString(WGAttributes.ContentAlign, GetContentAlign());

                    ResourceHandle objImage = this.Image;
                    if (objImage != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Image, objImage.ToString());
                    }
                    if (SortOrder != SortOrder.None)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Sort, (SortOrder == SortOrder.Ascending) ? "1" : "0");
                    }

                    // render VisualEffect attributes
                    RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter)objWriter);

                    // render event attributes
                    RenderComponentEventAttributes(objContext, (IAttributeWriter)objWriter, false);

                    // Render the client id.
                    RenderClientID((IAttributeWriter)objWriter, false);

                    // Render extended component attributes.
                    RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);

                    objWriter.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetTextAlign()
        {
            switch (this.TextAlign)
            {
                case HorizontalAlignment.Left:
                    return this.Context.RightToLeft ? "right" : "left";

                case HorizontalAlignment.Right:
                    return this.Context.RightToLeft ? "left" : "right";

                default:
                    return "center";

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetContentAlign()
        {
            switch (this.ContentAlign)
            {
                case ExtendedHorizontalAlignment.Left:
                    return this.Context.RightToLeft ? "right" : "left";

                case ExtendedHorizontalAlignment.Right:
                    return this.Context.RightToLeft ? "left" : "right";

                case ExtendedHorizontalAlignment.Inherit:
                    return GetTextAlign();

                default:
                    return "center";

            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ("ColumnHeader: Text: " + this.Text);
        }

        /// <summary>Resizes the width of the column as indicated by the resize style.</summary>
        /// <param name="enmHeaderAutoResize">One of the <see cref="T:System.Windows.Forms.ColumnHeaderAutoResizeStyle"></see>  values.</param>
        /// <exception cref="T:System.InvalidOperationException">A value other than <see cref="F:System.Windows.Forms.ColumnHeaderAutoResizeStyle.None"></see> is passed to the <see cref="M:System.Windows.Forms.ColumnHeader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle)"></see> method when the <see cref="P:System.Windows.Forms.ListView.View"></see> property is a value other than <see cref="F:System.Windows.Forms.View.Details"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void AutoResize(ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
        {
            if ((enmHeaderAutoResize < ColumnHeaderAutoResizeStyle.None) || (enmHeaderAutoResize > ColumnHeaderAutoResizeStyle.ColumnContent))
            {
                throw new InvalidEnumArgumentException("headerAutoResize", (int)enmHeaderAutoResize, typeof(ColumnHeaderAutoResizeStyle));
            }
            if (this.Owner != null)
            {
                this.Owner.AutoResizeColumn(this.Index, enmHeaderAutoResize);
            }
        }

        #endregion Methods

        #region Optimized Serialization Implementation

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                return base.SerializableDataInitialSize + mcntSerializableDataFieldCount;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the GroupBy proeprty
            mblnGroupBy = objReader.ReadBoolean();

            // Read the iContentAlignment proeprty
            menmContentAlignment = (ExtendedHorizontalAlignment)objReader.ReadObject();

            // Read the SortOrder proeprty
            menmSortOrder = (SortOrder)objReader.ReadObject();

            // Read the TextAlign proeprty
            menmTextAlign = (HorizontalAlignment)objReader.ReadObject();

            // Read the Type proeprty
            menmType = (ListViewColumnType)objReader.ReadObject();

            // Read the DisplayIndexInternal proeprty
            mintDisplayIndexInternal = objReader.ReadInt32();

            // Read the GroupByPosition proeprty
            mintGroupByPosition = objReader.ReadInt32();

            // Read the Index proeprty
            mintIndex = objReader.ReadInt32();

            // Read the InternalWidth proeprty
            mintInternalWidth = objReader.ReadInt32();

            // Read the PreferedItemHeight proeprty
            mintPreferedItemHeight = objReader.ReadInt32();

            // Read the SortPosition proeprty
            mintSortPosition = objReader.ReadInt32();

            // Read the Width proeprty
            mintWidth = objReader.ReadInt32();

            // Read the ResourceHandler proeprty
            mobjResourceHandler = (ResourceHandle)objReader.ReadObject();

            // Read the Label proeprty
            mstrLabel = objReader.ReadString();

            // Read the Name proeprty
            mstrName = objReader.ReadString();

            // Read the ImageIndex
            mintImageIndex = objReader.ReadInt32();

            // Read the ImageKey
            mstrImageKey = objReader.ReadString();
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the current control state
            objWriter.WriteObject(mblnGroupBy);
            objWriter.WriteObject(menmContentAlignment);
            objWriter.WriteObject(menmSortOrder);
            objWriter.WriteObject(menmTextAlign);
            objWriter.WriteObject(menmType);
            objWriter.WriteInt32(mintDisplayIndexInternal);
            objWriter.WriteInt32(mintGroupByPosition);
            objWriter.WriteInt32(mintIndex);
            objWriter.WriteInt32(mintInternalWidth);
            objWriter.WriteInt32(mintPreferedItemHeight);
            objWriter.WriteInt32(mintSortPosition);
            objWriter.WriteInt32(mintWidth);
            objWriter.WriteObject(mobjResourceHandler);
            objWriter.WriteString(mstrLabel);
            objWriter.WriteString(mstrName);
            objWriter.WriteObject(mintImageIndex);
            objWriter.WriteObject(mstrImageKey);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the display index.
        /// </summary>
        /// <value>The display index.</value>
        [Localizable(true), Gizmox.WebGUI.Forms.SRCategory("CatBehavior"), Gizmox.WebGUI.Forms.SRDescription("ColumnHeaderDisplayIndexDescr")]
        public int DisplayIndex
        {
            get
            {
                return this.DisplayIndexInternal;
            }
            set
            {
                if (this.Owner == null)
                {
                    this.DisplayIndexInternal = value;
                }
                else
                {
                    if ((value < 0) || (value > (this.Owner.Columns.Count - 1)))
                    {
                        throw new ArgumentOutOfRangeException("DisplayIndex", SR.GetString("ColumnHeaderBadDisplayIndex"));
                    }
                    int num = Math.Min(this.DisplayIndexInternal, value);
                    int num2 = Math.Max(this.DisplayIndexInternal, value);
                    int[] arrCols = new int[this.Owner.Columns.Count];
                    bool blnFlag = value > this.DisplayIndexInternal;
                    ColumnHeader header = null;
                    for (int i = 0; i < this.Owner.Columns.Count; i++)
                    {
                        ColumnHeader header2 = this.Owner.Columns[i];
                        if (header2.DisplayIndex == this.DisplayIndexInternal)
                        {
                            header = header2;
                        }
                        else if ((header2.DisplayIndex >= num) && (header2.DisplayIndex <= num2))
                        {
                            header2.DisplayIndexInternal -= blnFlag ? 1 : -1;
                        }
                        if (i != this.Index)
                        {
                            arrCols[header2.DisplayIndexInternal] = i;
                        }
                    }
                    header.DisplayIndexInternal = value;

                    //Clear Sorted Columns list
                    this.Owner.Columns.ClearSortedColumns();
                }


            }
        }

        /// <summary>
        /// Gets or sets the display index internal.
        /// </summary>
        /// <value>The display index internal.</value>
        internal int DisplayIndexInternal
        {
            get
            {
                return this.mintDisplayIndexInternal;
            }
            set
            {
                this.mintDisplayIndexInternal = value;

                if (InternalParent != null)
                {
                    InternalParent.Update();
                }
            }
        }

        private ListView Owner
        {
            get
            {
                return this.InternalParent as ListView;
            }
        }

        #region General

        /// <summary>
        /// Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>. 
        /// </summary>
        /// <returns>
        /// The image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>.
        /// </returns>
        public ResourceHandle Image
        {
            get
            {
                // The "GetImage" function will work with the ImageList mode, otherwise, will return the current object image resource handler.
                ResourceHandle objTempImage = null;
                if (ImageList != null)
                {
                    objTempImage = this.GetImage(null, ImageList, this.ImageIndex, this.ImageKey, -1, string.Empty);
                }

                if (objTempImage != null)
                {
                    return objTempImage;
                }
                else
                {
                    return this.mobjResourceHandler;
                }
            }
            set
            {
                if (this.mobjResourceHandler != value)
                {
                    this.mobjResourceHandler = value;

                    // Reseting other image values
                    this.mintImageIndex = -1;
                    this.mstrImageKey = string.Empty;

                    ListView objListView = this.ListView;
                    if (objListView != null)
                    {
                        objListView.Update();
                    }
                }
            }
        }


        /// <summary>Gets or sets the index of the image that is displayed for the item.</summary>
        /// <returns>The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
        /// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [DefaultValue(-1), RefreshProperties(RefreshProperties.Repaint), SRDescription("ListViewItemImageIndexDescr"), Localizable(true), SRCategory("CatBehavior")]
        public int ImageIndex
        {
            get
            {
                return mintImageIndex;
            }
            set
            {
                // If image index is diffrent the current value
                if (this.mintImageIndex != value)
                {
                    this.mintImageIndex = value;

                    // Reseting other image values
                    this.mobjResourceHandler = null;
                    this.mstrImageKey = string.Empty;

                    // Update the column header
                    ListView objListView = this.ListView;
                    if (objListView != null)
                    {
                        objListView.Update();
                    }
                }
            }
        }

        /// <summary>Gets or sets the key for the image that is displayed for the item.</summary>
        /// <returns>The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
        [SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue("")]
        public string ImageKey
        {
            get
            {
                return this.mstrImageKey;
            }
            set
            {
                // If image key is difefrent
                if (!this.mstrImageKey.Equals(value))
                {
                    this.mstrImageKey = value;

                    // Reseting other image values
                    this.mobjResourceHandler = null;
                    this.mintImageIndex = -1;

                    // Update the column header
                    ListView objListView = this.ListView;
                    if (objListView != null)
                    {
                        objListView.Update();
                    }
                }
            }
        }


        /// <summary>
        /// Gets the image list.
        /// </summary>
        [Browsable(false)]
        public ImageList ImageList
        {
            get
            {
                // If there is a valid list view owner for this list item
                if (this.ListView != null)
                {
                    // Get the list view image based on listview view state
                    switch (this.ListView.View)
                    {
                        case View.LargeIcon:
                            //case View.Tile:
                            return this.ListView.LargeImageList;

                        case View.Details:
                        case View.SmallIcon:
                        case View.List:
                            return this.ListView.SmallImageList;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the list view.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        public ListView ListView
        {
            get
            {
                return this.InternalParent as ListView;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ColumnHeader"/> is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
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
                    if (this.InternalParent != null)
                    {
                        this.InternalParent.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ColumnHeader"/> is loaded.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if loaded; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool Loaded
        {
            get
            {
                return this.GetState(ComponentState.Loaded);
            }
            set
            {
                this.SetState(ComponentState.Loaded, value);
            }
        }

        /// <summary>
        /// Initializes the state.
        /// </summary>
        private void InitializeState(bool blnLoaded)
        {
            // Set the default state
            this.SetState(ComponentState.Visible, true);
            this.SetState(ComponentState.Loaded, blnLoaded);
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public int Index
        {
            get
            {
                return mintIndex;
            }
        }

        /// <summary>
        /// Sets the internal index.
        /// </summary>
        /// <value></value>
        internal int InternalIndex
        {
            set
            {
                if (InternalParent != null)
                {
                    InternalParent.Update();
                }
                mintIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public string Name
        {
            get
            {
                return mstrName;
            }
            set
            {
                if (InternalParent != null)
                {
                    InternalParent.Update();
                }
                mstrName = value;
            }
        }

        /// <summary>Gets or sets the text displayed in the column header.</summary>
        /// <returns>The text displayed in the column header.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRDescription("ColumnCaption")]
        public string Text
        {
            get
            {
                return Label;
            }
            set
            {
                Label = value;

                FireObservableItemPropertyChanged("Text");
            }
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.Browsable(false)]
        public string Label
        {
            get
            {
                return mstrLabel;
            }
            set
            {
                if (InternalParent != null)
                {
                    InternalParent.Update();
                }
                mstrLabel = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value></value>
        public int Width
        {
            get
            {
                return mintWidth;
            }
            set
            {
                InternalWidth = value;

                if (InternalWidth > 0)
                {
                    mintWidth = InternalWidth;
                }
                else
                {
                    if (this.Owner != null && !(this.Owner.InUpadte > 0))
                    {
                        mintWidth = this.Owner.GetColumnFixedWidth(this.Index, InternalWidth, false);
                    }
                }

                if (InternalParent != null)
                {
                    InternalParent.Update();
                }

                FireObservableItemPropertyChanged("Width");
            }
        }

        /// <summary>
        /// Gets or sets the internal width.
        /// </summary>
        /// <value></value>
        internal int InternalWidth
        {
            get
            {
                return mintInternalWidth;
            }
            set
            {
                mintInternalWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(ListViewColumnType.Text)]
        public ListViewColumnType Type
        {
            get
            {
                return menmType;
            }
            set
            {
                menmType = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the prefered item.
        /// </summary>
        /// <value>The height of the prefered item.</value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(0)]
        public int PreferedItemHeight
        {
            get
            {
                if (this.Type == ListViewColumnType.Control)
                {
                    return mintPreferedItemHeight;
                }
                return 0;
            }
            set { mintPreferedItemHeight = value; }
        }


        /// <summary>
        /// Should serialize the item prefered height.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializePreferedItemHeight()
        {
            return this.Type == ListViewColumnType.Control && mintPreferedItemHeight > 0;
        }


        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return menmTextAlign;
            }
            set
            {
                menmTextAlign = value;
            }
        }

        /// <summary>
        /// Gets or sets the column header alignment.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(ExtendedHorizontalAlignment.Inherit)]
        public ExtendedHorizontalAlignment ContentAlign
        {
            get
            {
                return menmContentAlignment;
            }
            set
            {
                if (menmContentAlignment != value)
                {
                    if (InternalParent != null)
                    {
                        InternalParent.Update();
                    }
                    menmContentAlignment = value;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal bool IsValidColumn
        {
            get
            {
                return Visible && Loaded;
            }
        }


        #endregion General

        #region Sorting

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public SortOrder SortOrder
        {
            get
            {
                return menmSortOrder;
            }
            set
            {
                menmSortOrder = value;
            }
        }

        /// <summary>
        /// Gets or sets the sort position.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int SortPosition
        {
            get
            {
                return mintSortPosition;
            }
            set
            {
                mintSortPosition = value;
            }
        }


        #endregion Sorting

        #region Grouping

        /// <summary>
        /// Gets or sets a value indicating whether to group by column.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if group by column; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool GroupBy
        {
            get
            {
                return mblnGroupBy;
            }
            set
            {
                mblnGroupBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the group by position.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int GroupByPosition
        {
            get
            {
                return mintGroupByPosition;
            }
            set
            {
                mintGroupByPosition = value;
            }
        }


        #endregion Grouping

        #endregion Properties

        #region IComparable Members

        /// <summary>
        ///
        /// </summary>
        /// <param name="objObject"></param>
        public int CompareTo(object objObject)
        {
            ColumnHeader objColumnHeader = objObject as ColumnHeader;
            if (objColumnHeader != null)
            {
                return objColumnHeader.DisplayIndex < this.DisplayIndex ? 1 : -1;
            }
            else
            {
                return 0;
            }
        }


        #endregion IComparable Members

    }

    #endregion ColumnHeader Class

    #region ColumnHeaderSortingData Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ColumnHeaderSortingData : IComparer
    {
        #region Class Members

        /// <summary>
        ///
        /// </summary>
        private ListView mobjListView;


        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ColumnHeaderSortingData"/> instance.
        /// </summary>
        /// <param name="objListView">list view.</param>
        public ColumnHeaderSortingData(ListView objListView)
        {
            // Set local references
            mobjListView = objListView;
        }


        #endregion C'Tor\D'Tor

        #region Methods

        #region IComparer Members

        /// <summary>
        /// Compares the specified column headers
        /// </summary>
        /// <param name="objObjectA">Column A.</param>
        /// <param name="objObjectB">Column B.</param>
        /// <returns></returns>
        public int Compare(object objObjectA, object objObjectB)
        {
            ColumnHeader objColumnA = objObjectA as ColumnHeader;
            ColumnHeader objColumnB = objObjectB as ColumnHeader;
            if (objColumnA.SortPosition > objColumnB.SortPosition) return 1;
            else if (objColumnA.SortPosition < objColumnB.SortPosition) return -1;
            else return 0;
        }


        #endregion IComparer Members

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the columns in the order there are used in the sorting.
        /// </summary>
        /// <value></value>
        public ICollection SortedColumns
        {
            get
            {
                ArrayList objColumns = new ArrayList(mobjListView.Columns);
                objColumns.Sort(this);
                return objColumns;
            }
        }

        /// <summary>
        /// Gets the sorting participating columns.
        /// </summary>
        /// <value></value>
        public ICollection SortingColumns
        {
            get
            {
                // Create checked item collection
                ArrayList objSortedColumns = new ArrayList();

                // Loop all columns
                foreach (ColumnHeader objColumnHeader in SortedColumns)
                {
                    // Add sorted column
                    if (objColumnHeader.SortOrder != SortOrder.None)
                    {
                        objSortedColumns.Add(objColumnHeader);
                    }
                }

                // Return sorted header collection
                return objSortedColumns;
            }
        }


        #endregion Properties

    }

    #endregion ColumnHeaderSortingData Class

    #region ColumnHeaderGroupingData Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class ColumnHeaderGroupingData : IComparer
    {
        #region Class Members

        /// <summary>
        ///
        /// </summary>
        private ListView mobjListView;


        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ColumnHeaderGroupingData"/> instance.
        /// </summary>
        /// <param name="objListView">list view.</param>
        public ColumnHeaderGroupingData(ListView objListView)
        {
            // Set local references
            mobjListView = objListView;
        }


        #endregion C'Tor\D'Tor

        #region Methods

        #region IComparer Members

        /// <summary>
        /// Compares the specified column headers
        /// </summary>
        /// <param name="objObjectA">Column A.</param>
        /// <param name="objObjectB">Column B.</param>
        /// <returns></returns>
        public int Compare(object objObjectA, object objObjectB)
        {
            ColumnHeader objColumnA = objObjectA as ColumnHeader;
            ColumnHeader objColumnB = objObjectB as ColumnHeader;
            if (objColumnA.GroupByPosition > objColumnB.GroupByPosition) return 1;
            else if (objColumnA.GroupByPosition < objColumnB.GroupByPosition) return -1;
            else return 0;
        }


        #endregion IComparer Members

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the columns in the order there are used in the grouping.
        /// </summary>
        /// <value></value>
        public ICollection SortedColumns
        {
            get
            {
                ArrayList objColumns = new ArrayList(mobjListView.Columns);
                objColumns.Sort(this);
                return objColumns;
            }
        }

        /// <summary>
        /// Gets the sorting participating columns.
        /// </summary>
        /// <value></value>
        public ICollection GroupingColumns
        {
            get
            {
                // Create checked item collection
                ArrayList objGroupingColumns = new ArrayList();

                // Loop all columns
                foreach (ColumnHeader objColumnHeader in SortedColumns)
                {
                    // Add grouped column
                    if (objColumnHeader.GroupBy)
                    {
                        objGroupingColumns.Add(objColumnHeader);
                    }
                }

                // Return grouped header collection
                return objGroupingColumns;
            }
        }


        #endregion Properties

    }

    #endregion ColumnHeaderGroupingData Class

    #region ColumnHeaderConverter Class
    /// <summary>
    /// This class represents the ColumnHeader Converter.
    /// Used to avoid the default behaviour of the designer adding columns into the form's resx file.
    /// </summary>
    [Serializable()]
    public class ColumnHeaderConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            ConstructorInfo constructor;
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (!(destinationType == typeof(InstanceDescriptor)) || !(value is ColumnHeader))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            Type reflectionType = TypeDescriptor.GetReflectionType(value);
            constructor = reflectionType.GetConstructor(new Type[0]);

            if (constructor == null)
            {
                throw new ArgumentException(SR.GetString("NoDefaultConstructor", new object[] { reflectionType.FullName }));
            }
            return new InstanceDescriptor(constructor, new object[0], false);
        }
    }

    #endregion ColumnHeaderConverter Class
}
