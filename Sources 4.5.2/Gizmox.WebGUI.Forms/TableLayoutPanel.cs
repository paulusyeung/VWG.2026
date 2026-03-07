#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Drawing2D;
using Gizmox.WebGUI.Forms.Layout;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Globalization;
using System.Drawing.Design;
using System.Collections.Generic;


#endregion

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    /// <summary>
    /// 
    /// </summary>
    public delegate void TableLayoutCellPaintEventHandler(object sender, TableLayoutCellPaintEventArgs e);

    #endregion

    #region Enums

    /// <summary>
    /// TableLayoutPanelGrowStyle
    /// </summary>
    public enum TableLayoutPanelGrowStyle
    {
        /// <summary>
        /// FixedSize
        /// </summary>
        FixedSize,
        /// <summary>
        /// AddRows
        /// </summary>
        AddRows,
        /// <summary>
        /// AddColumns
        /// </summary>
        AddColumns
    }

    /// <summary>
    /// BoundsSpecified
    /// </summary>
    public enum BoundsSpecified
    {
        /// <summary>
        /// All
        /// </summary>
        All = 15,
        /// <summary>
        /// Height
        /// </summary>
        Height = 8,
        /// <summary>
        /// Location
        /// </summary>
        Location = 3,
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Size
        /// </summary>
        Size = 12,
        /// <summary>
        /// Width
        /// </summary>
        Width = 4,
        /// <summary>
        /// X
        /// </summary>
        X = 1,
        /// <summary>
        /// Y
        /// </summary>
        Y = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SizeType
    {
        /// <summary>
        /// AutoSize
        /// </summary>
        AutoSize,
        /// <summary>
        /// Absolute
        /// </summary>
        Absolute,
        /// <summary>
        /// Percent
        /// </summary>
        Percent
    }

    #endregion

    #region TableLayoutPanel Class

    /// <summary>
    /// A table layout control.
    /// </summary>
    /// <remarks>
    /// Use this layout control to create static layout that updates
    /// with control resizing.
    /// </remarks>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(TableLayoutPanel), "TableLayoutPanel_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(TableLayoutPanel), "TableLayoutPanel.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("Gizmox.WebGUI.Forms.Design.TableLayoutPanelDesigner, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]    
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutPanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [ProvideProperty("Column", typeof(Control)), SRDescription("DescriptionTableLayoutPanel"), ProvideProperty("ColumnSpan", typeof(Control)), ProvideProperty("RowSpan", typeof(Control)), ProvideProperty("Row", typeof(Control)), ProvideProperty("CellPosition", typeof(Control)), DefaultProperty("ColumnCount"), DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
#endif
    [ToolboxItemCategory("Containers")]
    [MetadataTag(WGTags.TableLayoutPanel)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.TableLayoutPanelSkin)), Serializable()]
    [ProxyComponent(typeof(ProxyTableLayoutPanel))]
    public class TableLayoutPanel : Control, IExtenderProvider
    {
        /// <summary>
        /// Provides a property reference to LayoutSettings property.
        /// </summary>
        private static SerializableProperty LayoutSettingsProperty = SerializableProperty.Register("LayoutSettings", typeof(TableLayoutSettings), typeof(TableLayoutPanel), new SerializablePropertyMetadata(null));

        #region Class Members

        private static readonly SerializableEvent EventCellPaint = SerializableEvent.Register("Event", typeof(Delegate), typeof(TableLayoutPanel));

        private BorderStyle menmBorderStyle = BorderStyle.None;

        /// <summary>
        /// Occurs when [cell paint].
        /// </summary>
        [SRCategory("CatAppearance"), SRDescription("TableLayoutPanelOnPaintCellDescr")]
        public event TableLayoutCellPaintEventHandler CellPaint
        {
            add
            {
                this.AddHandler(EventCellPaint, value);
            }
            remove
            {
                this.RemoveHandler(EventCellPaint, value);
            }
        }

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutPanel"/> class.
        /// </summary>
        public TableLayoutPanel()
        {
            // Create new tabel layout settings.
            this.SetValue<TableLayoutSettings>(TableLayoutPanel.LayoutSettingsProperty, TableLayout.CreateSettings(this));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Localizable(true), Browsable(false)]
        new public Color BorderColor
        {
            get
            {
                return base.BorderColor;
            }
            set
            {
                base.BorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Localizable(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public int BorderWidth
        {
            get
            {
                return base.BorderWidth;
            }
            set
            {
                base.BorderWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), Localizable(true), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        new public BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the cell border style.
        /// </summary>
        /// <value>The cell border style.</value>
        [SRCategory("CatAppearance"), Localizable(true), DefaultValue(0), SRDescription("TableLayoutPanelCellBorderStyleDescr")]
        public TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get
            {
                return this.LayoutSettings.CellBorderStyle;
            }
            set
            {
                this.LayoutSettings.CellBorderStyle = value;
                FireObservableItemPropertyChanged("CellBorderStyle");
                if (value != TableLayoutPanelCellBorderStyle.None)
                {
                    base.SetStyle(ControlStyles.ResizeRedraw, true);
                }
                base.Invalidate();
            }
        }

        private int CellBorderWidth
        {
            get
            {
                return this.LayoutSettings.CellBorderWidth;
            }
        }

        /// <summary>
        /// Gets or sets the column count.
        /// </summary>
        /// <value>The column count.</value>
        [SRDescription("GridPanelColumnsDescr"), Localizable(true), SRCategory("CatLayout"), DefaultValue(0)]
        public int ColumnCount
        {
            get
            {
                return this.LayoutSettings.ColumnCount;
            }
            set
            {
                this.LayoutSettings.ColumnCount = value;
                FireObservableItemPropertyChanged("ColumnCount");
                this.Update();
            }
        }

        /// <summary>
        /// Gets the column styles.
        /// </summary>
        /// <value>The column styles.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("GridPanelColumnStylesDescr"), SRCategory("CatLayout"), MergableProperty(false), Browsable(true)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("Columns")]
#endif
        public TableLayoutColumnStyleCollection ColumnStyles
        {
            get
            {
                return this.LayoutSettings.ColumnStyles;
            }
        }

        /// <summary>
        /// Gets the collection of controls contained within the control.
        /// </summary>
        /// <value></value>
        [Browsable(false), SRDescription("ControlControlsDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        new public TableLayoutControlCollection Controls
        {
            get
            {
                return (TableLayoutControlCollection)base.Controls;
            }
        }

        /// <summary>
        /// Gets or sets the grow style.
        /// </summary>
        /// <value>The grow style.</value>
        [SRDescription("TableLayoutPanelGrowStyleDescr"), DefaultValue(1), SRCategory("CatLayout")]
        public TableLayoutPanelGrowStyle GrowStyle
        {
            get
            {
                return this.LayoutSettings.GrowStyle;
            }
            set
            {
                this.LayoutSettings.GrowStyle = value;
                FireObservableItemPropertyChanged("GrowStyle");
            }
        }

        /// <summary>
        /// Gets the layout engine.
        /// </summary>
        /// <value>The layout engine.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public LayoutEngine LayoutEngine
        {
            get
            {
                return TableLayout.Instance;
            }
        }

        /// <summary>
        /// Gets or sets the layout settings.
        /// </summary>
        /// <value>The layout settings.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public TableLayoutSettings LayoutSettings
        {
            get
            {
                return this.GetValue<TableLayoutSettings>(TableLayoutPanel.LayoutSettingsProperty);
            }
            set
            {
                if ((value != null) && value.IsStub)
                {
                    this.LayoutSettings.ApplySettings(value);
                    FireObservableItemPropertyChanged("LayoutSettings");
                    return;

                }
                throw new NotSupportedException(SR.GetString("TableLayoutSettingSettingsIsNotSupported"));

            }
        }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>The row count.</value>
        [DefaultValue(0), SRDescription("GridPanelRowsDescr"), SRCategory("CatLayout"), Localizable(true)]
        public int RowCount
        {
            get
            {
                return this.LayoutSettings.RowCount;
            }
            set
            {
                this.LayoutSettings.RowCount = value;
                FireObservableItemPropertyChanged("RowCount");
                this.Update();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support child margins].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportChildMargins
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the row styles.
        /// </summary>
        /// <value>The row styles.</value>
        [SRDescription("GridPanelRowStylesDescr"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatLayout"), MergableProperty(false)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("Rows")]
#endif
        public TableLayoutRowStyleCollection RowStyles
        {
            get
            {
                return this.LayoutSettings.RowStyles;
            }
        }

        #endregion

        #region Methods

        #region Render

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // registers the curent control
            RegisterSelf();

            // add attributes to control element
            objWriter.WriteAttributeText(WGAttributes.Text, Text);

            if (CellBorderStyle != TableLayoutPanelCellBorderStyle.None)
            {
                objWriter.WriteAttributeString(WGAttributes.BorderStyle, ((int)CellBorderStyle).ToString());
            }

            int intNewRowNum = 0, intNewColNum = 0;
            GetNewColAndRowCount(out intNewRowNum, out intNewColNum);

            // Calculating the styles of the rows and columns by their order in the style lists.
            List<TableLayoutPanelCellStyle> objRowsCells = new List<TableLayoutPanelCellStyle>();
            List<TableLayoutPanelCellStyle> objColumnsCells = new List<TableLayoutPanelCellStyle>();
            CalculateColAndRowStyle(intNewRowNum, intNewColNum, objRowsCells, objColumnsCells);


            int intInd = 0;
            // write columns
            for (intInd = 0; intInd < intNewColNum; intInd++)
            {
                if (intInd < ColumnStyles.Count)
                {
                    objWriter.WriteStartElement(WGTags.TableLayoutCol);
                    objWriter.WriteAttributeString(WGAttributes.Width, GetLayoutSize(ColumnStyles[intInd].Width, ColumnStyles[intInd].SizeType));

                    // Rendering the columns style information
                    RenderColumnsPositionAttributes(objWriter, objColumnsCells, intInd);
                   
                    objWriter.WriteEndElement();
                }
                else // A column added for orphin cells
                {
                    objWriter.WriteStartElement(WGTags.TableLayoutCol);
                    objWriter.WriteAttributeString(WGAttributes.Width, "1px");

                    // Rendering the columns style information
                    RenderColumnsPositionAttributes(objWriter, objColumnsCells, intInd);

                    objWriter.WriteEndElement();
                }
            }

            // write rows
            for (intInd = 0; intInd < intNewRowNum; intInd++)
            {
                if (intInd < RowStyles.Count)
                {
                    objWriter.WriteStartElement(WGTags.TableLayoutRow);
                    objWriter.WriteAttributeString(WGAttributes.Height, GetLayoutSize(RowStyles[intInd].Height, RowStyles[intInd].SizeType));

                    // Rendering the rows style information
                    RenderRowsPositionAttributes(objWriter, objRowsCells, intInd);
                    
                    objWriter.WriteEndElement();
                }
                else // A row added for orphin cells
                {
                    objWriter.WriteStartElement(WGTags.TableLayoutRow);
                    objWriter.WriteAttributeString(WGAttributes.Height, "1px");

                    // Rendering the rows style information
                    RenderRowsPositionAttributes(objWriter, objRowsCells, intInd);
                    
                    objWriter.WriteEndElement();
                }
            }

            // Loop all controls
            for (int intIndex = this.Controls.Count - 1; intIndex >= 0; intIndex--)
            {
                // Get control
                Control objControl = this.Controls[intIndex];

                TableLayoutControlPosition objPosition = GetControlPosition(objControl);

                // write the XML of originally occupied cells
                if (objPosition.Row > -1 && objPosition.Column > -1)
                {
                    // Render control XML
                    ((IRenderableComponent)objControl).RenderComponent(objContext, objWriter, 0);
                }
            }
        }

        /// <summary>
        /// Renders the columns position attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objColumnsCells">The obj columns cells.</param>
        /// <param name="intInd">The int ind.</param>
        private static void RenderColumnsPositionAttributes(IResponseWriter objWriter, List<TableLayoutPanelCellStyle> objColumnsCells, int intInd)
        {
            if (objColumnsCells.Count > intInd)
            {
                objWriter.WriteAttributeString(WGAttributes.Left, Math.Round((double)objColumnsCells[intInd].LeftPercent, 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.MarginLeft, Math.Round((double)(objColumnsCells[intInd].LeftMarginPixel), 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.Right, Math.Round((double)objColumnsCells[intInd].RightPercent, 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.MarginRight, Math.Round((double)objColumnsCells[intInd].RightMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Renders the rows position attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objRowsCells">The obj rows cells.</param>
        /// <param name="intInd">The int ind.</param>
        private static void RenderRowsPositionAttributes(IResponseWriter objWriter, List<TableLayoutPanelCellStyle> objRowsCells, int intInd)
        {
            if (objRowsCells.Count > intInd)
            {
                objWriter.WriteAttributeString(WGAttributes.Top, Math.Round((double)objRowsCells[intInd].TopPercent, 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.MarginTop, Math.Round((double)(objRowsCells[intInd].TopMarginPixel), 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.Bottom, Math.Round((double)objRowsCells[intInd].BottomPercent, 2).ToString(CultureInfo.InvariantCulture));
                objWriter.WriteAttributeString(WGAttributes.MarginBottom, Math.Round((double)objRowsCells[intInd].BottomMarginPixel, 2).ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Pre-render control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
        {
            //create the container info object
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);

            //Get the TableLayout instance
            TableLayout objTableLayout = TableLayout.Instance;

            if (objContainerInfo != null && objTableLayout != null)
            {
                //Initialized the container info column and rows data
                objTableLayout.AssignRowsAndColumns(objContainerInfo);
            }

            // Loop all controls
            for (int intIndex = this.Controls.Count - 1; intIndex >= 0; intIndex--)
            {
                // Get control
                Control objControl = this.Controls[intIndex];

                TableLayoutControlPosition objPosition = GetControlPosition(objControl);

                // write the XML of originally occupied cells
                if (objPosition.Row > -1 && objPosition.Column > -1)
                {
                    string strRows = GetNumbers(objPosition.Row, objPosition.Row + (objPosition.Rowspan - 1));
                    string strCols = GetNumbers(objPosition.Column, objPosition.Column + (objPosition.Colspan - 1));

                    ((IAttributeExtender)objControl).SetAttribute(WGAttributes.Rows, strRows);
                    ((IAttributeExtender)objControl).SetAttribute(WGAttributes.Cols, strCols);
                    ((IAttributeExtender)objControl).SetAttribute(WGAttributes.Rowspan, objPosition.Rowspan.ToString());
                    ((IAttributeExtender)objControl).SetAttribute(WGAttributes.Colspan, objPosition.Colspan.ToString());
                }
            }

            base.PreRenderControl(objContext, lngRequestID);
        }

        /// <summary>
        /// Gets the col and row style.
        /// </summary>
        /// <param name="intNewRowNum">The int new row num.</param>
        /// <param name="intNewColNum">The int new col num.</param>
        /// <param name="objRowsCells">The obj rows cells.</param>
        /// <param name="objColumnsCells">The obj columns cells.</param>
        private void CalculateColAndRowStyle(int intNewRowNum, int intNewColNum, List<TableLayoutPanelCellStyle> objRowsCells, List<TableLayoutPanelCellStyle> objColumnsCells)
        {
            // Calculating the sum of all cells measures by sizetype (percent or pixels).
            float fltTotalColPixels = 0, fltTotalRowPixels = 0, fltTotalRowPercent = 0, fltTotalColPercent = 0; 
            for (int intRowInd = 0; intRowInd < intNewRowNum; intRowInd++)
            {
                if (intRowInd < RowStyles.Count)
                {
                    if (RowStyles[intRowInd].SizeType == SizeType.Absolute)
                    {
                        fltTotalRowPixels += RowStyles[intRowInd].Height;
                    }
                    else
                    {
                        fltTotalRowPercent += RowStyles[intRowInd].Height;
                    }                    
                }
                else // A row added for cells with no given style
                {
                    //Checking if the cell contains a control.
                    Control objControl = null;

                    for (int intColIndex = 0; intColIndex < intNewColNum; intColIndex++)
                    {
                        Control objTempControl = this.GetControlFromPosition(intColIndex, intRowInd);
						// A protection fron spaned cells, not to calculate same control several times.
                        TableLayoutPanelCellPosition objPosition = this.GetPositionFromControl(objTempControl);
                        if (objTempControl != null && this.GetRowSpan(objTempControl) == 1 && objPosition.Column == intColIndex && objPosition.Row == intRowInd)
                        {
                            if (objControl == null || objControl.Height < objTempControl.Height)
                            {
                                objControl = objTempControl;
                            }
                        }
                    }

                    if (objControl != null)
                    {
                        fltTotalRowPixels += objControl.Height;
                    }
                    else
                    {
                        fltTotalRowPixels += 1;
                    }
                }
            }

            for (int intColInd = 0; intColInd < intNewColNum; intColInd++)
            {
                if (intColInd < ColumnStyles.Count)
                {
                    if (ColumnStyles[intColInd].SizeType == SizeType.Absolute)
                    {
                        fltTotalColPixels += ColumnStyles[intColInd].Width;
                    }
                    else
                    {
                        fltTotalColPercent += ColumnStyles[intColInd].Width;
                    }
                }
                else // A column added for cells with no given style
                {
                    //Checking if the cell contains a control.
                    Control objControl = null;

                    for (int intRowIndex = 0; intRowIndex < intNewRowNum; intRowIndex++)
                    {
                        Control objTempControl = this.GetControlFromPosition(intColInd, intRowIndex);
						// A protection fron spaned cells, not to calculate same control several times.
                        TableLayoutPanelCellPosition objPosition = this.GetPositionFromControl(objTempControl);
                        if (objTempControl != null && objPosition.Column == intColInd && objPosition.Row == intRowIndex)
                        {
                            if (objControl == null || objControl.Width < objTempControl.Width)
                            {
                                objControl = objTempControl;
                            }
                        }
                    }

                    if (objControl != null)
                    {
                        fltTotalColPixels += objControl.Width;
                    }
                    else
                    {
                        fltTotalColPixels += 1;
                    }
                }
            }


            // Caluclating each row's position.
            float fltPassCalculatedAbsolutePixels = 0; // Will use to indicate the absolute sum of pixels used by cells we already calculated.            
            /* The logic is applicable both for the columns and rows:
             The idea is to go through the columns/rows, base the left/top position on the previous cell right/bottom position,
             and to calculate the next right/bottom position based on the cell SizeType.
             All the cells will be rendered with position absolute. meaning, the positions are related to the main div container of the table layout panel control.
             The Top/Bottom/Left/Right positioning will represent the percentage cells of the columns/rows of the table.
             The Margins will set the positions of the pixels SizeType of the columns/rows.
             The first cell is initiated with left/top with 0.
             The following cells left/top will be initiated based on the previous cell with adjusments:
             The percent position will be the complete to 100 of the previous cell, and the pixel size will be the negative of the previous cell. 
             (e.g. if cell A ended with right of 30%, cell B will start with (100%-30%) = 70%. If cell A ended with bottom with margin of 40px, cell B will start with margin -40px)
             The right/bottom will be calculated as follows:
             If the SizeType is "Percent", then i will add the column/row width/height to the top/left (calculated earlier), But will have to save the complete value to 100%. 
             (e.g. if cell A width is 25%, it started with top:0%, bottom:75%, cell B followed with width of 30%, so cell B should be top:25% and bottom: 100% - (25% + 30%) = 45%)
             The pixels are always calculated combined with the cells percent position.
             (e.g. if cell A width is 100%, and cell B width is 100px, then cell A should end 100px before the bottom of the table, thus, cell A will get margin-bottom : 100px.)
             (e.g. if cell A width is 30%, it will "use" 30% of the total pixels in the table, thus will have margin-bottom of 33.3px, the other percent sizetype cells will "use" the other pixels
              proportionally to their width, and will complete up to 100% usage) 
             If the total percentage of the cells is not 100%, it will be normalized to 100% during calculations. */

            for (int intRowInd = 0; intRowInd < intNewRowNum; intRowInd++)
            {
                //The first cell
                if (intRowInd == 0 && intRowInd < RowStyles.Count)
                {
                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objRowsCells.Add(objCell);

                    //Setting cell dimension (Top/Left are already 0);                    
                    if (RowStyles[intRowInd].SizeType == SizeType.Percent)
                    {
                        float fltNormalizedPercentSize = NormalizePercentage(fltTotalRowPercent, RowStyles[intRowInd].Height);
                        objCell.BottomPercent = 100 - fltNormalizedPercentSize;
                        objCell.BottomMarginPixel = (fltNormalizedPercentSize / 100) * fltTotalRowPixels;
                    }
                    else if (RowStyles[intRowInd].SizeType == SizeType.Absolute)
                    {
                        fltPassCalculatedAbsolutePixels += RowStyles[intRowInd].Height;
                        objCell.BottomPercent = 100;
                        objCell.BottomMarginPixel = fltPassCalculatedAbsolutePixels * -1;
                    }
                }
                else if (intRowInd < RowStyles.Count) //all the other cells inserted in design time.
                {
                    //Getting the top cells to use as references for calculations.
                    TableLayoutPanelCellStyle objPrevTopCell = null;
                    objPrevTopCell = objRowsCells[intRowInd - 1];

                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objRowsCells.Add(objCell);

                    // Setting cell dimension based on previous cells.
                    // The top row cell
                    if (objPrevTopCell != null)
                    {
                        objCell.TopPercent = 100 - objPrevTopCell.BottomPercent;
                        objCell.TopMarginPixel = objPrevTopCell.BottomMarginPixel * -1;
                    }

                    if (intRowInd == RowStyles.Count - 1 && intRowInd == intNewRowNum - 1) //the last cell - should complete the cell till the end of the table layout.
                    {
                        objCell.BottomPercent = 0;
                        objCell.BottomMarginPixel = 0;
                    }
                    else
                    {
                        if (RowStyles[intRowInd].SizeType == SizeType.Percent)
                        {
                            float fltNormalizedPercentSize = NormalizePercentage(fltTotalRowPercent, RowStyles[intRowInd].Height);
                            objCell.BottomPercent = 100 - (objCell.TopPercent + fltNormalizedPercentSize);
                            objCell.BottomMarginPixel = ((100 - objCell.BottomPercent) / 100) * fltTotalRowPixels - fltPassCalculatedAbsolutePixels;
                        }
                        else if (RowStyles[intRowInd].SizeType == SizeType.Absolute)
                        {
                            fltPassCalculatedAbsolutePixels += RowStyles[intRowInd].Height;
                            objCell.BottomPercent = 100 - (objCell.TopPercent);
                            objCell.BottomMarginPixel = ((100 - objCell.BottomPercent) / 100) * fltTotalRowPixels - fltPassCalculatedAbsolutePixels;
                        }
                    }
                }
                else // A row added for cells with no given style
                {
                    //Checking if the Row/Column contains a control to set the height if the Row/Column.
                    int intCurrentHeight = 1;

                    for (int intColIndex = 0; intColIndex < intNewColNum; intColIndex++)
                    {
                        Control objTempControl = this.GetControlFromPosition(intColIndex, intRowInd);
                        TableLayoutPanelCellPosition objPosition = this.GetPositionFromControl(objTempControl);
                        if (objTempControl != null)
                        {
                            int iRowSpan = this.GetRowSpan(objTempControl);
                            if (iRowSpan == 1)
                            {
                                if (intCurrentHeight < objTempControl.Height)
                                {
                                    intCurrentHeight = objTempControl.Height;
                                }
                            }
                            else if (iRowSpan > 1 && (objPosition.Row + iRowSpan - 1) == intRowInd)
                            {
                                //If the control is spanned, i will calculate the possible condition based on it's left height (after decreasing previous rows)
                                int intLeftHeight = objTempControl.Height;
                                for (int intLeftHeightIndex = intRowInd - 1; intLeftHeightIndex >= (objPosition.Row); intLeftHeightIndex--)
                                {
                                    TableLayoutPanelCellStyle objTempCell = objRowsCells[intLeftHeightIndex];
                                    intLeftHeight -= (int)(Math.Abs(objTempCell.BottomMarginPixel) - objTempCell.TopMarginPixel);
                                }

                                if (intCurrentHeight < intLeftHeight)
                                {
                                    intCurrentHeight = intLeftHeight;
                                }
                            }
                        }
                    }

                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objRowsCells.Add(objCell);
                                       
                    fltPassCalculatedAbsolutePixels += intCurrentHeight; 

                    // Treating cells with no given style with previous cells
                    if (intRowInd > 0)
                    {
                        // Getting the top cells to use as references for calculations.
                        TableLayoutPanelCellStyle objPrevTopCell = null;
                        objPrevTopCell = objRowsCells[intRowInd - 1];

                        //Setting cell dimension based on previous cells.
                        //The top row cell
                        if (objPrevTopCell != null)
                        {
                            objCell.TopPercent = 100 - objPrevTopCell.BottomPercent;
                            objCell.TopMarginPixel = objPrevTopCell.BottomMarginPixel * -1;
                        }

                        objCell.BottomPercent = 100 - (objCell.TopPercent);
                        objCell.BottomMarginPixel = ((100 - objCell.BottomPercent) / 100) * fltTotalRowPixels - fltPassCalculatedAbsolutePixels;
                    }
                    else // First cell with no given style
                    {
                        // If the first cell is orphin, i should define the total pixels.
                        if (fltTotalRowPixels < this.Height)
                        {
                            fltTotalRowPixels = this.Height;
                        }

                        objCell.BottomPercent = 100 - (objCell.TopPercent);
                        objCell.BottomMarginPixel = ((100 - objCell.BottomPercent) / 100) * fltTotalRowPixels - fltPassCalculatedAbsolutePixels;
                    }

                    // If its a cell with no given style and it's the last row/column, i will set 0 to values to spread the last row/column to the borders of the panel.
                    if (intRowInd == intNewRowNum - 1)
                    {
                        objCell.BottomPercent = 0;
                        objCell.BottomMarginPixel = 0;
                    }
                }
            }            

            // Caluclating each column's position.
            fltPassCalculatedAbsolutePixels = 0;

            for (int intColInd = 0; intColInd < intNewColNum; intColInd++)
            {
                if (intColInd == 0 && intColInd < ColumnStyles.Count)
                {
                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objColumnsCells.Add(objCell);

                    // Setting cell dimension (Top/Left are already 0);
                    if (ColumnStyles[intColInd].SizeType == SizeType.Percent)
                    {
                        float fltNormalizedPercentSize = NormalizePercentage(fltTotalColPercent, ColumnStyles[intColInd].Width);
                        objCell.RightPercent = 100 - fltNormalizedPercentSize;
                        objCell.RightMarginPixel = (fltNormalizedPercentSize / 100) * fltTotalColPixels;
                    }
                    else if (ColumnStyles[intColInd].SizeType == SizeType.Absolute)
                    {
                        fltPassCalculatedAbsolutePixels += ColumnStyles[intColInd].Width;
                        objCell.RightPercent = 100;
                        objCell.RightMarginPixel = fltPassCalculatedAbsolutePixels * -1;//- ((objCell.RightPercent) / 100) * (intTotalColPixels);
                    }
                }
                else if (intColInd < ColumnStyles.Count)
                {
                    TableLayoutPanelCellStyle objPrevLeftCell = null;

                    // Getting the left cell to use as references for calculations.                    
                    objPrevLeftCell = objColumnsCells[intColInd - 1];

                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objColumnsCells.Add(objCell);

                    // Setting cell dimension based on previous cells.
                    // The left side cell
                    if (objPrevLeftCell != null)
                    {
                        objCell.LeftPercent = 100 - objPrevLeftCell.RightPercent;
                        objCell.LeftMarginPixel = objPrevLeftCell.RightMarginPixel * -1;
                    }

                    if (intColInd == ColumnStyles.Count - 1 && intColInd == intNewColNum - 1) //the last cell - should complete the cell till the end of the table layout.
                    {
                        objCell.RightPercent = 0;
                        objCell.RightMarginPixel = 0;
                    }
                    else
                    {
                        if (ColumnStyles[intColInd].SizeType == SizeType.Percent)
                        {
                            float fltNormalizedPercentSize = NormalizePercentage(fltTotalColPercent, ColumnStyles[intColInd].Width);
                            objCell.RightPercent = 100 - (objCell.LeftPercent + fltNormalizedPercentSize);
                            objCell.RightMarginPixel = ((100 - objCell.RightPercent) / 100) * fltTotalColPixels - fltPassCalculatedAbsolutePixels;
                        }
                        else if (ColumnStyles[intColInd].SizeType == SizeType.Absolute)
                        {
                            fltPassCalculatedAbsolutePixels += ColumnStyles[intColInd].Width;
                            objCell.RightPercent = 100 - (objCell.LeftPercent);
                            objCell.RightMarginPixel = ((100 - objCell.RightPercent) / 100) * fltTotalColPixels - fltPassCalculatedAbsolutePixels;
                        }
                    }
                }
                else // A row added for cells with no given style
                {
                    // Checking if the Row/Column contains a control to set the height if the Row/Column                    
                    int intCurrentWidth = 1;
                    
                    for (int intRowIndex = 0; intRowIndex < intNewRowNum; intRowIndex++)
                    {
                        Control objTempControl = this.GetControlFromPosition(intColInd, intRowIndex);
                        TableLayoutPanelCellPosition objPosition = this.GetPositionFromControl(objTempControl);
                        if (objTempControl != null)
                        {
                             int iColSpan = this.GetColumnSpan(objTempControl);
                             if (iColSpan == 1)
                             {
                                 if (intCurrentWidth < objTempControl.Width)
                                 {
                                     intCurrentWidth = objTempControl.Width;
                                 }
                             }
                             else if (iColSpan > 1 && (objPosition.Column + iColSpan - 1) == iColSpan)
                             {
                                 //If the control is spanned, i will calculate the possible condition based on it's left height (after decreasing previous rows)
                                 int intLeftWidth = objTempControl.Height;
                                 for (int intLeftWidthIndex = intColInd - 1; intLeftWidthIndex >= (objPosition.Column); intLeftWidthIndex--)
                                 {
                                     TableLayoutPanelCellStyle objTempCell = objColumnsCells[intLeftWidthIndex];
                                     intLeftWidth -= (int)(Math.Abs(objTempCell.RightMarginPixel) - objTempCell.LeftMarginPixel);
                                 }

                                 if (intCurrentWidth < intLeftWidth)
                                 {
                                     intCurrentWidth = intLeftWidth;
                                 }
                             }
                        }
                    }                    

                    TableLayoutPanelCellStyle objCell = new TableLayoutPanelCellStyle();
                    objColumnsCells.Add(objCell);
                    
                    fltPassCalculatedAbsolutePixels += intCurrentWidth; //constant add of 20px.                        
                                           
                    //Checking if there are any cells previous to this current one
                    if (intColInd > 0)
                    {
                        TableLayoutPanelCellStyle objPrevLeftCell = null;

                        // Getting the left cell to use as references for calculations.     
                        objPrevLeftCell = objColumnsCells[intColInd - 1];
                        
                        // Setting cell dimension based on previous cells.
                        // The left side cell
                        if (objPrevLeftCell != null)
                        {
                            objCell.LeftPercent = 100 - objPrevLeftCell.RightPercent;
                            objCell.LeftMarginPixel = objPrevLeftCell.RightMarginPixel * -1;
                        }
                       
                        objCell.RightPercent = 100 - (objCell.LeftPercent);
                        objCell.RightMarginPixel = ((100 - objCell.RightPercent) / 100) * fltTotalColPixels - fltPassCalculatedAbsolutePixels;
                    }
                    else // First cell with no given style
                    {
                        if (fltTotalColPixels < this.Width)
                        {
                            fltTotalColPixels = this.Width;
                        }

                        objCell.RightPercent = 100;
                        objCell.RightMarginPixel = ((100 - objCell.RightPercent) / 100) * fltTotalColPixels - fltPassCalculatedAbsolutePixels;
                    }

                    //If its a cell with no given style and it's the last row/column, i will set 0 to values to spread the last row/column to the borders of the panel.
                    if (intColInd == intNewColNum - 1)
                    {
                        objCell.RightPercent = 0;
                        objCell.RightMarginPixel = 0;
                    }
                }                
            }
        }

        /// <summary>
        /// Normalizes the percentage mainly when the sum of sizes of cells is not 100.
        /// </summary>
        /// <param name="fltTotalSum">The FLT total sum.</param>
        /// <param name="fltCurrentValue">The FLT current value.</param>
        /// <returns></returns>
        private float  NormalizePercentage(float fltTotalSum, float fltCurrentValue)
        {
            return (fltCurrentValue / fltTotalSum) * 100;
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            if (e.Control != null)
            {
                ((IAttributeExtender)e.Control).SetAttribute(WGAttributes.Rows, null);
                ((IAttributeExtender)e.Control).SetAttribute(WGAttributes.Cols, null);
                ((IAttributeExtender)e.Control).SetAttribute(WGAttributes.Rowspan, null);
                ((IAttributeExtender)e.Control).SetAttribute(WGAttributes.Colspan, null);
            }
        }

        /// <summary>
        /// Gets the new row and column number according to the newly added controls.
        /// </summary>
        /// <param name="intNewRowNum">The row count return value.</param>
        /// <param name="intNewColNum">The column count return value.</param>
        /// <returns></returns>
        internal void GetNewColAndRowCount(out int intNewRowNum, out int intNewColNum)
        {
            //create the container info object
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);
            if (objContainerInfo != null)
            {
                //Get the number of columns and rows to render
                intNewColNum = Math.Max(objContainerInfo.MaxColumns, objContainerInfo.MinColumns);
                intNewRowNum = Math.Max(objContainerInfo.MaxRows, objContainerInfo.MinRows);
            }
            else
            {
                //if no objContainerInfo return 0 for an empty table 
                intNewColNum = 0;
                intNewRowNum = 0;
            }
        }

        /// <summary>
        /// Gets the size of the control.
        /// </summary>
        /// <param name="objProposedSize">The proposed size in a 'Size' struct format.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            int intWidth = objProposedSize.Width;
            int intHeight = objProposedSize.Height;

            if (this.AutoSize)
            {
                // Run over all contained controls.
                if (this.Controls.Count > 0)
                {
                    foreach (Control objChildControl in this.Controls)
                    {
                        TableLayoutControlPosition objPosition = GetControlPosition(objChildControl);

                        // Check the received controls' measurments.
                        if (objPosition != null)
                        {
                            Size objChildProposedSize = new Size(objChildControl.LayoutWidth, objChildControl.LayoutHeight);
                            Size objPreferredSize;

                            if (objChildControl.UsePreferredSize)
                            {
                                // Get the control's prefered size.
                                objPreferredSize = objChildControl.GetPreferredSize(objChildProposedSize);

                                objPreferredSize = GetPreferredSizeByAutoSizeMode(objChildControl, objChildProposedSize, objPreferredSize);
                            }
                            else
                            {
                                objPreferredSize = objChildProposedSize;
                            }

                            // Update the control's column width.
                            if (objPosition.Column >= 0 &&
                                objPosition.Column < this.ColumnStyles.Count &&
                                this.ColumnStyles[objPosition.Column].SizeType == SizeType.AutoSize &&
                                objPreferredSize.Width > this.ColumnStyles[objPosition.Column].Width)
                            {
                                this.ColumnStyles[objPosition.Column].Width = objPreferredSize.Width;
                            }

                            // Update the control's row height.
                            if (objPosition.Row >= 0 &&
                                objPosition.Row < this.RowStyles.Count &&
                                this.RowStyles[objPosition.Row].SizeType == SizeType.AutoSize &&
                                objPreferredSize.Height > this.RowStyles[objPosition.Row].Height)
                            {
                                this.RowStyles[objPosition.Row].Height = objPreferredSize.Height;
                            }
                        }
                    }
                }

                intWidth = 0;
                intHeight = 0;

                foreach (ColumnStyle objColumnStyle in this.ColumnStyles)
                {
                    intWidth += Convert.ToInt32(objColumnStyle.Width);
                }

                foreach (RowStyle objRowStyle in this.RowStyles)
                {
                    intHeight += Convert.ToInt32(objRowStyle.Height);
                }
            }

            return new Size(intWidth, intHeight);
        }


        /// <summary>
        /// Layout the internal controls to reflect parent changes
        /// </summary>
        /// <param name="objEventArgs">The layout arguments.</param>
        /// <param name="objNewSize">The new parent size.</param>
        /// <param name="objOldSize">The old parent size.</param>
        protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
        {
            ControlCollection objControls = this.Controls;

            // If there is a valid control collection
            if (objControls != null)
            {
                // If there are controls
                if (objControls.Count > 0)
                {
                    // Get width change
                    int intWidthChange = objNewSize.Width - objOldSize.Width;

                    // Get height change
                    int intHeightChange = objNewSize.Height - objOldSize.Height;

                    // Check that size has actually been changed.
                    if (intHeightChange != 0 || intWidthChange != 0)
                    {
                        // Loop all child controls
                        foreach (Control objControl in objControls)
                        {
                            // Get the current control docking
                            DockStyle enmControlDock = objControl.Dock;

                            // Define empty column and rows styles.
                            ColumnStyle objColumnStyle = null;
                            RowStyle objRowStyle = null;

                            // Get control's column index.
                            int intColumnIndex = this.GetColumn(objControl);

                            // Validate column index.
                            if (intColumnIndex >= 0 && intColumnIndex < this.ColumnStyles.Count)
                            {
                                // Get control's column and row styles.
                                objColumnStyle = this.ColumnStyles[intColumnIndex];
                            }

                            // Get control's rows index.
                            int intRowIndex = this.GetRow(objControl);

                            // Validate row index.
                            if (intRowIndex >= 0 && intRowIndex < this.RowStyles.Count)
                            {
                                objRowStyle = this.RowStyles[intRowIndex];
                            }

                            // Validate column and row style.
                            if (objColumnStyle != null && objRowStyle != null)
                            {
                                // Check if control's column or row styles has a precent size type.
                                if (objColumnStyle.SizeType == SizeType.Percent || objRowStyle.SizeType == SizeType.Percent)
                                {
                                    // If vertical docking
                                    if (enmControlDock == DockStyle.Left || enmControlDock == DockStyle.Right)
                                    {
                                        if (intWidthChange != 0 &&
                                            objColumnStyle.SizeType == SizeType.Percent &&
                                            enmControlDock == DockStyle.Right)
                                        {
                                            objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                        }

                                        if (intHeightChange != 0 &&
                                            objRowStyle.SizeType == SizeType.Percent)
                                        {
                                            objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                        }
                                    }
                                    // If horizantal docking
                                    else if (enmControlDock == DockStyle.Top || enmControlDock == DockStyle.Bottom)
                                    {
                                        // If control is docked to the right and parent height has changed
                                        if (enmControlDock == DockStyle.Bottom)
                                        {
                                            if (intHeightChange != 0 &&
                                                objRowStyle.SizeType == SizeType.Percent)
                                            {
                                                objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                            }
                                        }

                                        // If width had changed
                                        if (intWidthChange != 0 &&
                                            objColumnStyle.SizeType == SizeType.Percent)
                                        {
                                            objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                        }
                                    }
                                    // If fill docking
                                    else if (enmControlDock == DockStyle.Fill)
                                    {
                                        // If parent size had changed
                                        if ((intWidthChange != 0 && objColumnStyle.SizeType == SizeType.Percent) ||
                                            (intHeightChange != 0 && objRowStyle.SizeType == SizeType.Percent))
                                        {
                                            objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                        }
                                    }
                                    else
                                    {
                                        // Get control location and size
                                        int intControlLeft = objControl.Left;
                                        int intControlTop = objControl.Top;
                                        int intControlHeight = objControl.Height;
                                        int intControlWidth = objControl.Width;

                                        // Get control's anchor value.
                                        AnchorStyles enmAnchor = objControl.Anchor;

                                        // Get control anchoring flags
                                        bool blnIsRightAnchored = objControl.IsRightAnchored(enmAnchor);
                                        bool blnIsLeftAnchored = objControl.IsLeftAnchored(enmAnchor);
                                        bool blnIsTopAnchored = objControl.IsTopAnchored(enmAnchor);
                                        bool blnIsBottomAnchored = objControl.IsBottomAnchored(enmAnchor);

                                        // Dirty flags
                                        bool blnSizeChanged = false;
                                        bool blnLocationChanged = false;

                                        // If width had changed
                                        if (intWidthChange != 0 && objColumnStyle.SizeType == SizeType.Percent)
                                        {
                                            // If right anchored
                                            if (blnIsRightAnchored && !blnIsLeftAnchored)
                                            {
                                                intControlLeft += Convert.ToInt32(objColumnStyle.Size * intWidthChange / 100);
                                                blnLocationChanged = true;
                                            }
                                            // If both right and left anchoring
                                            else if (blnIsRightAnchored && blnIsLeftAnchored)
                                            {
                                                intControlWidth += Convert.ToInt32(objColumnStyle.Size * intWidthChange / 100);
                                                blnSizeChanged = true;
                                            }
                                            // If center anchoring
                                            else if (!blnIsRightAnchored && !blnIsLeftAnchored)
                                            {
                                                intControlLeft += Convert.ToInt32(objColumnStyle.Size * intWidthChange / 200);
                                                blnLocationChanged = true;
                                            }
                                        }

                                        // If height had changed
                                        if (intHeightChange != 0 && objRowStyle.SizeType == SizeType.Percent)
                                        {
                                            // If bottom anchored
                                            if (blnIsBottomAnchored && !blnIsTopAnchored)
                                            {
                                                intControlTop += Convert.ToInt32(objRowStyle.Size * intHeightChange / 100);
                                                blnLocationChanged = true;
                                            }
                                            // If both bottom and top anchoring
                                            else if (blnIsBottomAnchored && blnIsTopAnchored)
                                            {
                                                intControlHeight += Convert.ToInt32(objRowStyle.Size * intHeightChange / 100);
                                                blnSizeChanged = true;
                                            }
                                            // If center anchoring
                                            else if (!blnIsBottomAnchored && !blnIsTopAnchored)
                                            {
                                                intControlTop += Convert.ToInt32(objRowStyle.Size * intHeightChange / 200);
                                                blnLocationChanged = true;
                                            }
                                        }

                                        // If control had changed
                                        if (blnLocationChanged || blnSizeChanged)
                                        {
                                            // Update the control bounds
                                            objControl.UpdateBounds(intControlLeft, intControlTop, intControlWidth, intControlHeight, intControlWidth, intControlHeight, objEventArgs.IsClientSource);

                                            // If the location had changed
                                            if (blnLocationChanged)
                                            {
                                                // Raise the location changed event
                                                objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                            }

                                            // If the size had changed
                                            if (blnSizeChanged)
                                            {
                                                // Raise the size changed event
                                                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the size of the layout.
        /// </summary>
        /// <param name="fltSize">Size of the lay out.</param>
        /// <param name="enmSizeType">Type of size.</param>
        /// <returns></returns>
        private string GetLayoutSize(float fltSize, SizeType enmSizeType)
        {
            string strSize = string.Empty;

            switch (enmSizeType)
            {
                case SizeType.Absolute:
                    strSize = string.Format("{0}px", fltSize.ToString(CultureInfo.InvariantCulture));
                    break;
                case SizeType.AutoSize:
                    strSize = string.Empty;
                    break;
                case SizeType.Percent:
                    strSize = string.Format("{0}%", fltSize.ToString(CultureInfo.InvariantCulture));
                    break;
            }

            return strSize;
        }

        /// <summary>
        /// Renders the child controls.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        /// <remarks>
        /// Overrides default controls rendering cause the fill docking mechanism is not
        /// fit to handle table layout children.
        /// </remarks>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Loop all controls
            for (int intIndex = this.Controls.Count - 1; intIndex >= 0; intIndex--)
            {
                // Get control
                Control objControl = this.Controls[intIndex];

                // Render control
                ((IRenderableComponent)objControl).RenderComponent(objContext, objWriter, lngRequestID);
            }
        }

        #endregion Render

        #region Public Methods

        /// <summary>
        /// Gets the cell position.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRDescription("GridPanelCellPositionDescr"), DefaultValue(-1), SRCategory("CatLayout"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("Cell")]
#endif
        public TableLayoutPanelCellPosition GetCellPosition(Control objControl)
        {
            return this.LayoutSettings.GetCellPosition(objControl);
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new TableLayoutPanelRenderer(this);
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRDescription("GridPanelColumnDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatLayout"), DefaultValue(-1)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("Column")]
#endif
        public int GetColumn(Control objControl)
        {
            return this.LayoutSettings.GetColumn(objControl);
        }

        /// <summary>
        /// Gets the column span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRCategory("CatLayout"), SRDescription("GridPanelGetColumnSpanDescr"), DefaultValue(1)]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("ColumnSpan")]
#endif
        public int GetColumnSpan(Control objControl)
        {
            return this.LayoutSettings.GetColumnSpan(objControl);
        }

        /// <summary>
        /// Gets the column widths.
        /// </summary>
        /// <returns></returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int[] GetColumnWidths()
        {
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);
            if (objContainerInfo.Columns == null)
            {
                return new int[0];
            }
            int[] arrNumArray = new int[objContainerInfo.Columns.Length];
            for (int i = 0; i < objContainerInfo.Columns.Length; i++)
            {
                arrNumArray[i] = objContainerInfo.Columns[i].MinSize;
            }
            return arrNumArray;
        }

        /// <summary>
        /// Returns the child control occupying the specified position.
        /// </summary>
        /// <param name="intColumn">The column position of the control to retrieve.</param>
        /// <param name="intRow">The row position of the control to retrieve.</param>
        /// <returns>
        /// The child control occupying the specified cell; otherwise, null if no control 
        /// exists at the specified column and row.
        /// </returns>
        public Control GetControlFromPosition(int intColumn, int intRow)
        {
            return (Control)LayoutSettings.GetControlFromPosition(intColumn, intRow);
        }

        /// <summary>
        /// Gets the position from control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        public TableLayoutPanelCellPosition GetPositionFromControl(Control objControl)
        {
            return this.LayoutSettings.GetPositionFromControl(objControl);
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue(-1), SRDescription("GridPanelRowDescr"), SRCategory("CatLayout")]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("Row")]
#endif
        public int GetRow(Control objControl)
        {
            return this.LayoutSettings.GetRow(objControl);
        }

        /// <summary>
        /// Gets the row heights.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int[] GetRowHeights()
        {
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);
            if (objContainerInfo.Rows == null)
            {
                return new int[0];
            }
            int[] arrNumArray = new int[objContainerInfo.Rows.Length];
            for (int i = 0; i < objContainerInfo.Rows.Length; i++)
            {
                arrNumArray[i] = objContainerInfo.Rows[i].MinSize;
            }
            return arrNumArray;
        }

        /// <summary>
        /// Gets the row span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRDescription("GridPanelGetRowSpanDescr"), DefaultValue(1), SRCategory("CatLayout")]
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [DisplayName("RowSpan")]
#endif
        public int GetRowSpan(Control objControl)
        {
            return this.LayoutSettings.GetRowSpan(objControl);
        }

        /// <summary>
        /// Sets the cell position.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="objPosition">The position.</param>
        public void SetCellPosition(Control objControl, TableLayoutPanelCellPosition objPosition)
        {
            this.LayoutSettings.SetCellPosition(objControl, objPosition);
            FireObservableItemPropertyChanged("CellPosition", objControl);
            this.Update();
        }

        /// <summary>
        /// Sets the column.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intColumn">The column.</param>
        public void SetColumn(Control objControl, int intColumn)
        {
            this.LayoutSettings.SetColumn(objControl, intColumn);
            FireObservableItemPropertyChanged("Column", objControl);
            this.Update();
        }

        /// <summary>
        /// Sets the column span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intValue">The value.</param>
        public void SetColumnSpan(Control objControl, int intValue)
        {
            this.LayoutSettings.SetColumnSpan(objControl, intValue);
            FireObservableItemPropertyChanged("ColumnSpan", objControl);
            this.Update();
        }

        /// <summary>
        /// Sets the row.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intRow">The row.</param>
        public void SetRow(Control objControl, int intRow)
        {
            this.LayoutSettings.SetRow(objControl, intRow);
            FireObservableItemPropertyChanged("Row", objControl);
            this.Update();
        }

        /// <summary>
        /// Sets the row span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intValue">The value.</param>
        public void SetRowSpan(Control objControl, int intValue)
        {
            this.LayoutSettings.SetRowSpan(objControl, intValue);
            FireObservableItemPropertyChanged("RowSpan", objControl);
            this.Update();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates the controls instance.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TableLayoutControlCollection(this);
        }

        /// <summary>
        /// Raises the <see cref="E:CellPaint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TableLayoutCellPaintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            // Raise event if needed
            TableLayoutCellPaintEventHandler objEventHandler = (TableLayoutCellPaintEventHandler)this.GetHandler(EventCellPaint);
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Layout"/> event.
        /// </summary>
        /// <param name="objLevent">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void OnLayout(LayoutEventArgs objLevent)
        {
            base.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:PaintBackground"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected void OnPaintBackground(PaintEventArgs e)
        {
            int intNum6;
            int intCellBorderWidth = this.CellBorderWidth;
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);
            TableLayout.Strip[] arrColumns = objContainerInfo.Columns;
            TableLayout.Strip[] arrRows = objContainerInfo.Rows;
            TableLayoutPanelCellBorderStyle enmCellBorderStyle = this.CellBorderStyle;
            if ((arrColumns == null) || (arrRows == null))
            {
                return;
            }
            int intLength = arrColumns.Length;
            int intNum3 = arrRows.Length;
            int intNum4 = 0;
            int intNum5 = 0;
            Graphics objGraphics = e.Graphics;
            Rectangle objDisplayRectangle = new Rectangle(this.Location, this.Size);
            Rectangle objClipRectangle = e.ClipRectangle;
            bool blnFlag = this.RightToLeft == RightToLeft.Yes;
            if (blnFlag)
            {
                intNum6 = objDisplayRectangle.Right - (intCellBorderWidth / 2);
            }
            else
            {
                intNum6 = objDisplayRectangle.X + (intCellBorderWidth / 2);
            }
            for (int i = 0; i < intLength; i++)
            {
                int intY = objDisplayRectangle.Y + (intCellBorderWidth / 2);
                if (blnFlag)
                {
                    intNum6 -= arrColumns[i].MinSize;
                }
                for (int j = 0; j < intNum3; j++)
                {
                    Rectangle objRectangle3 = new Rectangle(intNum6, intY, arrColumns[i].MinSize, arrRows[j].MinSize);
                    Rectangle objRect = new Rectangle(objRectangle3.X + ((intCellBorderWidth + 1) / 2), objRectangle3.Y + ((intCellBorderWidth + 1) / 2), objRectangle3.Width - ((intCellBorderWidth + 1) / 2), objRectangle3.Height - ((intCellBorderWidth + 1) / 2));
                    if (objClipRectangle.IntersectsWith(objRect))
                    {
                        TableLayoutCellPaintEventArgs objEventArgs = new TableLayoutCellPaintEventArgs(objGraphics, objClipRectangle, objRect, i, j);
                        this.OnCellPaint(objEventArgs);
                    }
                    intY += arrRows[j].MinSize;
                    if (i == 0)
                    {
                        intNum5 += arrRows[j].MinSize;
                    }
                }
                if (!blnFlag)
                {
                    intNum6 += arrColumns[i].MinSize;
                }
                intNum4 += arrColumns[i].MinSize;
            }
            Rectangle objBoundRect = new Rectangle((intCellBorderWidth / 2) + objDisplayRectangle.X, (intCellBorderWidth / 2) + objDisplayRectangle.Y, objDisplayRectangle.Width - intCellBorderWidth, objDisplayRectangle.Height - intCellBorderWidth);
            switch (enmCellBorderStyle)
            {
                case TableLayoutPanelCellBorderStyle.Inset:
                    objGraphics.DrawLine(SystemPens.ControlDark, objBoundRect.Right, objBoundRect.Y, objBoundRect.Right, objBoundRect.Bottom);
                    objGraphics.DrawLine(SystemPens.ControlDark, objBoundRect.X, (objBoundRect.Y + objBoundRect.Height) - 1, (objBoundRect.X + objBoundRect.Width) - 1, (objBoundRect.Y + objBoundRect.Height) - 1);
                    goto Label_032C;

                case TableLayoutPanelCellBorderStyle.Outset:
                    {
                        using (Pen objPen = new Pen(SystemColors.Window))
                        {
                            objGraphics.DrawLine(objPen, (objBoundRect.X + objBoundRect.Width) - 1, objBoundRect.Y, (objBoundRect.X + objBoundRect.Width) - 1, (objBoundRect.Y + objBoundRect.Height) - 1);
                            objGraphics.DrawLine(objPen, objBoundRect.X, (objBoundRect.Y + objBoundRect.Height) - 1, (objBoundRect.X + objBoundRect.Width) - 1, (objBoundRect.Y + objBoundRect.Height) - 1);
                            goto Label_032C;
                        }
                    }
                default:
                    goto Label_032C;
            }
        Label_032C:
            return;
        }

        /// <summary>
        /// Gets the calculated height of the control.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        internal float GetControlCalculatedHeight(Control objControl, bool blnUseLayoutValues)
        {
            float fltControlCalculatedHeight = 0;

            if (objControl != null)
            {
                // Get the row index of the received control.
                int intRow = this.GetRow(objControl);
                if (intRow >= 0)
                {
                    // Get the row span of the received control.
                    int intRowSpan = this.GetRowSpan(objControl);

                    // Get table layout panel calculated height.
                    float fltCalculatedHeight = this.GetCalculatedHeight(blnUseLayoutValues);

                    // Define an float that will hold the height of all absolute rows.
                    float fltAbsoluteRowsHeight = 0;

                    // Define an float that will hold the height of all relative rows.
                    float fltRelativeRowsHeight = 0;

                    // Get row count.
                    int intRowCount = this.RowCount;

                    // Loop all row styles.
                    foreach (RowStyle objRow in this.RowStyles)
                    {
                        // Check if current row style is in row count scope.
                        if (this.RowStyles.IndexOf(objRow) < intRowCount)
                        {
                            // In case of an absolute row - sum its height.
                            if (objRow.SizeType == SizeType.Absolute)
                            {
                                fltAbsoluteRowsHeight += objRow.Height;
                            }
                            // In case of relative row - sum its height.
                            else if (objRow.SizeType == SizeType.Percent)
                            {
                                fltRelativeRowsHeight += objRow.Height;
                            }
                        }
                    }

                    // Loop all of the recieved control's row span.
                    for (int intRowIndex = 0; intRowIndex < intRowSpan; intRowIndex++)
                    {
                        // Validate handled row style index.
                        if (intRow + intRowIndex < this.RowStyles.Count)
                        {
                            // Get current row style.
                            RowStyle objRowStyle = this.RowStyles[intRow + intRowIndex];
                            if (objRowStyle != null)
                            {
                                // Check if current row style is in row count scope.
                                if (this.RowStyles.IndexOf(objRowStyle) < intRowCount)
                                {
                                    switch (objRowStyle.SizeType)
                                    {
                                        case SizeType.Absolute:
                                            // Sum current row absolute height.
                                            fltControlCalculatedHeight += objRowStyle.Height;
                                            break;
                                        case SizeType.Percent:
                                            // Check that the sum of the absolute rows height is smaller then the 
                                            // flow layout panel height so that the relative rows will have height
                                            // to fill.
                                            if (fltCalculatedHeight > fltAbsoluteRowsHeight)
                                            {
                                                // Get current relative row height
                                                float fltRowHeight = objRowStyle.Height;

                                                // Check if the sum of all relative rows is less then a 100 precent.
                                                if (fltRelativeRowsHeight < 100)
                                                {
                                                    // Add the relative devision of the relative remainder to current row's height.
                                                    fltRowHeight += (((100 - fltRelativeRowsHeight) * fltRowHeight) / 100);
                                                }

                                                // Sum current row relative height.
                                                fltControlCalculatedHeight += (((fltCalculatedHeight - fltAbsoluteRowsHeight) * fltRowHeight) / 100);
                                            }
                                            break;
                                    }
                                }
                              
                            }
                        }
                        else // The row is not in the scope, so it is orphin. and the row height will be the control height.
                        {
                            if (intRowIndex == 0)
                            {// The height is added only if it is the firts cell, when orphin cells are calculated.
                                fltControlCalculatedHeight += objControl.LayoutHeight;
                            }
                        }
                    }
                }
            }

            // Return control calculated height.
            return fltControlCalculatedHeight;
        }

        /// <summary>
        /// Gets the calculated width of the control.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        internal float GetControlCalculatedWidth(Control objControl, bool blnUseLayoutValues)
        {
            float fltControlCalculatedWidth = 0;

            if (objControl != null)
            {
                // Get the column index of the received control.
                int intColumn = this.GetColumn(objControl);
                if (intColumn >= 0)
                {
                    // Get the column span of the received control.
                    int intColumnSpan = this.GetColumnSpan(objControl);

                    // Get table layout panel calculated height.
                    float fltCalculatedWidth = this.GetCalculatedWidth(blnUseLayoutValues);

                    // Define an float that will hold the height of all relative columns.
                    float fltRelativeColumnsWidth = 0;

                    // Define an float that will hold the height of all absolute columns.
                    float fltAbsoluteColumnsWidth = 0;

                    // Get column count.
                    int intColumnCount = this.ColumnCount;

                    // Loop all column styles.
                    foreach (ColumnStyle objColumn in this.ColumnStyles)
                    {
                        // Check if current column style is in column count scope.
                        if (this.ColumnStyles.IndexOf(objColumn) < intColumnCount)
                        {
                            // In case of an absolute column - sum its height.
                            if (objColumn.SizeType == SizeType.Absolute)
                            {
                                fltAbsoluteColumnsWidth += objColumn.Width;
                            }
                            // In case of relative column - sum its width.
                            else if (objColumn.SizeType == SizeType.Percent)
                            {
                                fltRelativeColumnsWidth += objColumn.Width;
                            }
                        }
                    }

                    // Loop all of the recieved control's column span.
                    for (int intColumnIndex = 0; intColumnIndex < intColumnSpan; intColumnIndex++)
                    {
                        // Validate handled column style index.
                        if (intColumn + intColumnIndex < this.ColumnStyles.Count)
                        {
                            // Get current column style.
                            ColumnStyle objColumnStyle = this.ColumnStyles[intColumn + intColumnIndex];
                            if (objColumnStyle != null)
                            {
                                // Check if current column style is in column count scope.
                                if (this.ColumnStyles.IndexOf(objColumnStyle) < intColumnCount)
                                {
                                    switch (objColumnStyle.SizeType)
                                    {
                                        case SizeType.Absolute:
                                            // Sum current column absolute height.
                                            fltControlCalculatedWidth += objColumnStyle.Width;
                                            break;
                                        case SizeType.Percent:
                                            // Check that the sum of the absolute columns height is smaller then the 
                                            // flow layout panel height so that the relative columns will have height
                                            // to fill.
                                            if (fltCalculatedWidth > fltAbsoluteColumnsWidth)
                                            {
                                                // Get current relative column width.
                                                float fltColumnWidth = objColumnStyle.Width;

                                                // Check if the sum of all relative columns is less then a 100 precent.
                                                if (fltRelativeColumnsWidth < 100)
                                                {
                                                    // Add the relative devision of the relative remainder to current column's width.
                                                    fltColumnWidth += (((100 - fltRelativeColumnsWidth) * fltColumnWidth) / 100);
                                                }

                                                // Sum current column relative height.
                                                fltControlCalculatedWidth += (((fltCalculatedWidth - fltAbsoluteColumnsWidth) * fltColumnWidth) / 100);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                        else // The row is not in the scope, so it is orphin. and the row height will be the control height.
                        {
                            if (intColumnIndex == 0)
                            {// The height is added only if it is the firts cell, when orphin cells are calculated.
                                fltControlCalculatedWidth += objControl.LayoutWidth;
                            }
                        }
                    }
                }
            }

            // Return control calculated height.
            return fltControlCalculatedWidth;
        }

        /// <summary>
        /// Gets the control calculated left.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        internal float GetControlCalculatedLeft(Control objControl, bool blnUseLayoutValues)
        {
            // Get the tablelayoutpanel's calculated left.
            float fltControlCalculatedLeft = this.GetCalculatedLeft(blnUseLayoutValues);

            if (objControl != null)
            {
                // Get the column index of the received control.
                int intColumn = this.GetColumn(objControl);
                if (intColumn >= 0)
                {
                    // Get the column span of the received control.
                    int intColumnSpan = this.GetColumnSpan(objControl);

                    // Get the tablelayoutpanel's calculated width.
                    int intTableLayoutPanelCalculatedWidth = this.GetCalculatedWidth(blnUseLayoutValues);

                    // Define an float that will hold the sum of all the relative columns width.
                    float fltRelativeColumnsWidth = 0;

                    // Define an float that will hold the sum of all the absolute columns width.
                    float fltAbsoluteColumnsWidth = 0;

                    // Get column count.
                    int intColumnCount = this.ColumnCount;

                    // Loop all column styles.
                    foreach (ColumnStyle objColumn in this.ColumnStyles)
                    {
                        // Check if current column style is in column count scope.
                        if (this.ColumnStyles.IndexOf(objColumn) < intColumnCount)
                        {
                            // In case of an absolute column - sum its height.
                            if (objColumn.SizeType == SizeType.Absolute)
                            {
                                fltAbsoluteColumnsWidth += objColumn.Width;
                            }
                            // In case of relative column - sum its width.
                            else if (objColumn.SizeType == SizeType.Percent)
                            {
                                fltRelativeColumnsWidth += objColumn.Width;
                            }
                        }
                    }

                    // Loop all columns defined before the cotnrol's column.
                    for (int intColumnIndex = 0; intColumnIndex < intColumn; intColumnIndex++)
                    {
                        // Validate handled column style index.
                        if (intColumnIndex < this.ColumnStyles.Count)
                        {
                            // Get current column style.
                            ColumnStyle objColumnStyle = this.ColumnStyles[intColumnIndex];
                            if (objColumnStyle != null)
                            {
                                // Check if current column style is in column count scope.
                                if (this.ColumnStyles.IndexOf(objColumnStyle) < intColumnCount)
                                {
                                    switch (objColumnStyle.SizeType)
                                    {
                                        case SizeType.Absolute:
                                            // Sum current column absolute width.
                                            fltControlCalculatedLeft += objColumnStyle.Width;
                                            break;
                                        case SizeType.Percent:
                                            // Get current relative column width.
                                            float fltColumnWidth = objColumnStyle.Width;

                                            // Check if the sum of all relative columns is less then a 100 precent.
                                            if (fltRelativeColumnsWidth < 100)
                                            {
                                                // Add the relative devision of the relative remainder to current column's width.
                                                fltColumnWidth += (((100 - fltRelativeColumnsWidth) * fltColumnWidth) / 100);
                                            }

                                            // Sum current column relative width.
                                            fltControlCalculatedLeft += ((intTableLayoutPanelCalculatedWidth * fltColumnWidth) / 100);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fltControlCalculatedLeft;
        }

        /// <summary>
        /// Gets the control calculated top.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        internal float GetControlCalculatedTop(Control objControl, bool blnUseLayoutValues)
        {
            // Get the tablelayoutpanel's calculated top.
            float fltControlCalculatedTop = this.GetCalculatedTop(blnUseLayoutValues);

            if (objControl != null)
            {
                // Get the row index of the received control.
                int intRow = this.GetRow(objControl);
                if (intRow >= 0)
                {
                    // Get the row span of the received control.
                    int intRowSpan = this.GetRowSpan(objControl);

                    // Get the tablelayoutpanel's calculated height.
                    int intTableLayoutPanelCalculatedHeight = this.GetCalculatedHeight(blnUseLayoutValues);

                    // Define an float that will hold the sum of all the relative rows heigh.
                    float fltRelativeRowsHeight = 0;

                    // Define an float that will hold the sum of all the absolute rows heigh.
                    float fltAbsoluteRowsHeight = 0;

                    // Get row count.
                    int intRowCount = this.RowCount;

                    // Loop all row styles.
                    foreach (RowStyle objRow in this.RowStyles)
                    {
                        // Check if current column style is in column count scope.
                        if (this.RowStyles.IndexOf(objRow) < intRowCount)
                        {
                            // In case of an absolute column - sum its height.
                            if (objRow.SizeType == SizeType.Absolute)
                            {
                                fltAbsoluteRowsHeight += objRow.Height;
                            }
                            // In case of relative column - sum its width.
                            else if (objRow.SizeType == SizeType.Percent)
                            {
                                fltRelativeRowsHeight += objRow.Height;
                            }
                        }
                    }

                    // Loop all columns defined before the cotnrol's row.
                    for (int intRowIndex = 0; intRowIndex < intRow; intRowIndex++)
                    {
                        // Validate handled row style index.
                        if (intRowIndex < this.RowStyles.Count)
                        {
                            // Get current row style.
                            RowStyle objRowStyle = this.RowStyles[intRowIndex];
                            if (objRowStyle != null)
                            {
                                // Check if current column style is in column count scope.
                                if (this.RowStyles.IndexOf(objRowStyle) < intRowCount)
                                {
                                    switch (objRowStyle.SizeType)
                                    {
                                        case SizeType.Absolute:
                                            // Sum current column absolute width.
                                            fltControlCalculatedTop += objRowStyle.Height;
                                            break;
                                        case SizeType.Percent:
                                            // Get current relative column width.
                                            float fltRowHeight = objRowStyle.Height;

                                            // Check if the sum of all relative rows is less then a 100 precent.
                                            if (fltRelativeRowsHeight < 100)
                                            {
                                                // Add the relative devision of the relative remainder to current row's height.
                                                fltRowHeight += (((100 - fltRelativeRowsHeight) * fltRowHeight) / 100);
                                            }

                                            // Sum current row relative height.
                                            fltControlCalculatedTop += ((intTableLayoutPanelCalculatedHeight * fltRowHeight) / 100);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return fltControlCalculatedTop;
        }

        /// <summary>
        /// Scales the control.
        /// </summary>
        /// <param name="objFactor">The factor.</param>
        /// <param name="enmSpecified">The specified.</param>
        protected void ScaleControl(SizeF objFactor, BoundsSpecified enmSpecified)
        {
            this.ScaleAbsoluteStyles(objFactor);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a numbers string.
        /// </summary>
        /// <param name="intFrom">Int from.</param>
        /// <param name="intTo">Int to.</param>
        /// <returns></returns>
        private string GetNumbers(int intFrom, int intTo)
        {
            string[] arrNumbers = new string[(intTo - intFrom) + 1];
            for (int intIndex = intFrom; intIndex <= intTo; intIndex++)
            {
                arrNumbers[intIndex - intFrom] = intIndex.ToString();
            }
            return String.Join(",", arrNumbers);
        }

        /// <summary>
        /// Gets a control position.
        /// </summary>
        /// <param name="objControl">Obj control.</param>
        /// <returns></returns>
        private TableLayoutControlPosition GetControlPosition(Control objControl)
        {
            TableLayoutControlPosition objTableLayoutControlPosition = new TableLayoutControlPosition();

            objTableLayoutControlPosition.Control = objControl;
            objTableLayoutControlPosition.Column = GetColumn(objControl);
            objTableLayoutControlPosition.Row = GetRow(objControl);
            objTableLayoutControlPosition.Colspan = GetColumnSpan(objControl);
            objTableLayoutControlPosition.Rowspan = GetRowSpan(objControl);

            return objTableLayoutControlPosition;
        }

        bool IExtenderProvider.CanExtend(object obj)
        {
            Control objControl = obj as Control;
            if (objControl != null)
            {
                return (objControl.Parent == this);
            }
            return false;
        }

        private void ScaleAbsoluteStyles(SizeF objFactor)
        {
            TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(this);
            int intNum = 0;
            int intMinSize = -1;
            int intIndex = objContainerInfo.Rows.Length - 1;
            if (objContainerInfo.Rows.Length > 0)
            {
                intMinSize = objContainerInfo.Rows[intIndex].MinSize;
            }
            int num4 = -1;
            int num5 = objContainerInfo.Columns.Length - 1;
            if (objContainerInfo.Columns.Length > 0)
            {
                num4 = objContainerInfo.Columns[objContainerInfo.Columns.Length - 1].MinSize;
            }
            foreach (ColumnStyle objColumnStyle in (IEnumerable)this.ColumnStyles)
            {
                if (objColumnStyle.SizeType == SizeType.Absolute)
                {
                    if ((intNum == num5) && (num4 > 0))
                    {
                        objColumnStyle.Width = (float)Math.Round((double)(num4 * objFactor.Width));
                    }
                    else
                    {
                        objColumnStyle.Width = (float)Math.Round((double)(objColumnStyle.Width * objFactor.Width));
                    }
                }
                intNum++;
            }
            intNum = 0;
            foreach (RowStyle objRowStyle in (IEnumerable)this.RowStyles)
            {
                if (objRowStyle.SizeType != SizeType.Absolute)
                {
                    continue;
                }
                if ((intNum == intIndex) && (intMinSize > 0))
                {
                    objRowStyle.Height = (float)Math.Round((double)(intMinSize * objFactor.Height));
                    continue;
                }
                objRowStyle.Height = (float)Math.Round((double)(objRowStyle.Height * objFactor.Height));
            }
        }

        private bool ShouldSerializeControls()
        {
            TableLayoutControlCollection objControls = this.Controls;
            if (objControls != null)
            {
                return (objControls.Count > 0);
            }
            return false;
        }

        #endregion

        #endregion
    }

    #endregion

    #region TableLayoutPanelRenderer Class

    /// <summary>
    /// Provides support for rendering a groupbox control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class TableLayoutPanelRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutPanelRenderer"/> class.
        /// </summary>
        /// <param name="objTableLayoutPanel">The groupbox control.</param>
        public TableLayoutPanelRenderer(TableLayoutPanel objTableLayoutPanel)
            : base(objTableLayoutPanel)
        {
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderControls(objContext, objGraphics);
        }
    }

    #endregion

    #region PaintEventArgs Class

    /// <summary>
    /// Provides data for the Paint event.
    /// </summary>
    [Serializable()]
    public class PaintEventArgs : EventArgs, IDisposable
    {
        #region Class Members

        private readonly Rectangle mobjClipRectangle;
        private readonly IntPtr mobjDC;
        private Graphics mobjGraphics;
        private IntPtr mobjOldPal;
        private GraphicsState mobjSavedGraphicsState;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="PaintEventArgs"/> class.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objClipRect">The clip rect.</param>
        public PaintEventArgs(Graphics objGraphics, Rectangle objClipRect)
        {
            this.mobjDC = IntPtr.Zero;
            this.mobjOldPal = IntPtr.Zero;
            if (objGraphics == null)
            {
                throw new ArgumentNullException("graphics");
            }
            this.mobjGraphics = objGraphics;
            this.mobjClipRectangle = objClipRect;
        }

        internal PaintEventArgs(IntPtr objDC, Rectangle objClipRect)
        {
            this.mobjDC = IntPtr.Zero;
            this.mobjOldPal = IntPtr.Zero;
            this.mobjDC = objDC;
            this.mobjClipRectangle = objClipRect;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="PaintEventArgs"/> is reclaimed by garbage collection.
        /// </summary>
        ~PaintEventArgs()
        {
            this.Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the clip rectangle.
        /// </summary>
        /// <value>The clip rectangle.</value>
        public Rectangle ClipRectangle
        {
            get
            {
                return this.mobjClipRectangle;
            }
        }

        /// <summary>
        /// Gets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics
        {
            get
            {
                if ((this.mobjGraphics == null) && (this.mobjDC != IntPtr.Zero))
                {
                    this.mobjGraphics = Graphics.FromHdcInternal(this.mobjDC);
                    this.mobjGraphics.PageUnit = GraphicsUnit.Pixel;
                    this.mobjSavedGraphicsState = this.mobjGraphics.Save();
                }
                return this.mobjGraphics;
            }
        }

        internal IntPtr HDC
        {
            get
            {
                if (this.mobjGraphics == null)
                {
                    return this.mobjDC;
                }
                return IntPtr.Zero;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="blnDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool blnDisposing)
        {
            if ((blnDisposing && (this.mobjGraphics != null)) && (this.mobjDC != IntPtr.Zero))
            {
                this.mobjGraphics.Dispose();
            }
            if ((this.mobjOldPal != IntPtr.Zero) && (this.mobjDC != IntPtr.Zero))
            {
                this.mobjOldPal = IntPtr.Zero;
            }
        }

        #endregion

        #region Internal Methods

        internal void ResetGraphics()
        {
            if ((this.mobjGraphics != null) && (this.mobjSavedGraphicsState != null))
            {
                this.mobjGraphics.Restore(this.mobjSavedGraphicsState);
                this.mobjSavedGraphicsState = null;
            }
        }

        #endregion

        #endregion
    }

    #endregion

    #region TableLayoutRowStyleCollection Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    /// <summary>
    /// A collection that stores RowStyle objects.
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutRowStyleCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class TableLayoutRowStyleCollection : TableLayoutStyleCollection, IObservableList
    {
        #region C'Tors \ D'Tors

        internal TableLayoutRowStyleCollection(IArrangedElement objOwner)
            : base(objOwner)
        {
        }

        internal TableLayoutRowStyleCollection()
            : base(null)
        {
        }

        #endregion

        #region Properties

        internal override string PropertyName
        {
            get
            {
                return PropertyNames.RowStyles;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.TableLayoutStyle"/> at the specified index.
        /// </summary>
        /// <value></value>
        new public RowStyle this[int index]
        {
            get
            {
                return (RowStyle)base[index];
            }
            set
            {
                this[index] = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified row style.
        /// </summary>
        /// <param name="objRowStyle">The row style.</param>
        /// <returns></returns>
        public int Add(RowStyle objRowStyle)
        {
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objRowStyle));
            }
            return ((IList)this).Add(objRowStyle);
        }

        /// <summary>
        /// Adds a row style.
        /// </summary>
        /// <param name="intHeight"></param>
        /// <returns></returns>
        public int Add(int intHeight)
        {
            RowStyle objRowStyle = new RowStyle(intHeight.ToString());
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objRowStyle));
            }
            return this.Add(objRowStyle);
        }

        /// <summary>
        /// Determines whether [contains] [the specified row style].
        /// </summary>
        /// <param name="objRowStyle">The row style.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified row style]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(RowStyle objRowStyle)
        {
            return ((IList)this).Contains(objRowStyle);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="objRowStyle">The row style.</param>
        /// <returns></returns>
        public int IndexOf(RowStyle objRowStyle)
        {
            return ((IList)this).IndexOf(objRowStyle);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="intIndex">The index.</param>
        /// <param name="objRowStyle">The row style.</param>
        public void Insert(int intIndex, RowStyle objRowStyle)
        {
            if (ObservableItemInserted != null)
            {
                ObservableItemInserted(this, new ObservableListEventArgs(objRowStyle));
            }
            ((IList)this).Insert(intIndex, objRowStyle);
        }

        /// <summary>
        /// Removes the specified row style.
        /// </summary>
        /// <param name="objRowStyle">The row style.</param>
        public void Remove(RowStyle objRowStyle)
        {
            if (ObservableItemRemoved != null)
            {
                ObservableItemRemoved(this, new ObservableListEventArgs(objRowStyle));
            }
            ((IList)this).Remove(objRowStyle);
        }

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemRemoved;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event EventHandler ObservableListCleared;

        #endregion

        #endregion
    }

    #endregion

    #region RowStyle Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    /// <summary>
    /// Represents the look and feel of a row in a table layout.
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.RowStyleController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.RowStyleController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class RowStyle : TableLayoutStyle
    {
        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="RowStyle"/> class.
        /// </summary>
        /// <param name="objSizeType">Type of the size.</param>
        /// <param name="fltHeight">The height.</param>
        public RowStyle(SizeType objSizeType, float fltHeight)
        {
            base.SizeType = objSizeType;
            this.Height = fltHeight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowStyle"/> class.
        /// </summary>
        /// <param name="objSizeType">Type of the size.</param>
        public RowStyle(SizeType objSizeType)
        {
            base.SizeType = objSizeType;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strHight"></param>
        public RowStyle(string strHight)
        {
			this.Height = float.Parse(strHight, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intHight"></param>
        public RowStyle(int intHight)
        {
            this.Height = intHight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowStyle"/> class.
        /// </summary>
        public RowStyle()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public float Height
        {
            get
            {
                return base.Size;
            }
            set
            {
                if (base.Size != value)
                {
                    base.Size = value;
                    FireObservableItemPropertyChanged("Height");
                }
            }
        }

        #endregion
    }

    #endregion

    #region TableLayoutStyleCollection Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    /// <summary>
    /// 
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif

    [Serializable()]
    public abstract class TableLayoutStyleCollection : IList, ICollection, IEnumerable, IObservableList
    {
        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableListEventHandler ObservableItemRemoved;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event EventHandler ObservableListCleared;

        #endregion

        #region Class Members

        private ArrayList mobjInnerList = new ArrayList();
        private IArrangedElement mobjOwner;

        #endregion

        #region C'Tors \ D'Tors

        internal TableLayoutStyleCollection(IArrangedElement objOwner)
        {
            this.mobjOwner = objOwner;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public int Count
        {
            get
            {
                return this.mobjInnerList.Count;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return this.mobjInnerList.IsSynchronized;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this.mobjInnerList.SyncRoot;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return this.mobjInnerList.IsFixedSize;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return this.mobjInnerList.IsReadOnly;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.mobjInnerList[index];
            }
            set
            {
                TableLayoutStyle objStyle = (TableLayoutStyle)value;
                this.EnsureNotOwned(objStyle);
                objStyle.Owner = this.Owner;
                this.mobjInnerList[index] = objStyle;
                this.PerformLayoutIfOwned();
            }
        }

        internal IArrangedElement Owner
        {
            get
            {
                return this.mobjOwner;
            }
        }

        internal virtual string PropertyName
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.TableLayoutStyle"/> at the specified index.
        /// </summary>
        /// <value></value>
        public TableLayoutStyle this[int index]
        {
            get
            {
                return (TableLayoutStyle)((IList)this)[index];
            }
            set
            {
                ((IList)this)[index] = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified style.
        /// </summary>
        /// <param name="objStyle">The style.</param>
        /// <returns></returns>
        public int Add(TableLayoutStyle objStyle)
        {
            int intIndex = ((IList)this).Add(objStyle);

            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objStyle));
            }

            return intIndex;
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IList"/> is read-only.
        /// </exception>
        public void Clear()
        {
            foreach (TableLayoutStyle objStyle in this.mobjInnerList)
            {
                objStyle.Owner = null;
            }
            this.mobjInnerList.Clear();
            this.PerformLayoutIfOwned();
            if (ObservableListCleared != null)
            {
                ObservableListCleared(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.IList"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IList"/> is read-only.
        /// -or-
        /// The <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </exception>
        public void RemoveAt(int index)
        {
            TableLayoutStyle objStyle = (TableLayoutStyle)this.mobjInnerList[index];
            objStyle.Owner = null;
            this.mobjInnerList.RemoveAt(index);
            this.PerformLayoutIfOwned();
            if (ObservableItemRemoved != null)
            {
                ObservableItemRemoved(this, new ObservableListEventArgs(objStyle));
            }
        }

        #endregion

        #region Private Methods

        private void EnsureNotOwned(TableLayoutStyle objStyle)
        {
            if (objStyle.Owner != null)
            {
                throw new ArgumentException(SR.GetString("OnlyOneControl", new object[] { objStyle.GetType().Name }), "style");
            }
        }

        void ICollection.CopyTo(Array objArray, int intStartIndex)
        {
            this.mobjInnerList.CopyTo(objArray, intStartIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.mobjInnerList.GetEnumerator();
        }

        int IList.Add(object objStyle)
        {
            this.EnsureNotOwned((TableLayoutStyle)objStyle);
            ((TableLayoutStyle)objStyle).Owner = this.Owner;
            int num = this.mobjInnerList.Add(objStyle);
            this.PerformLayoutIfOwned();
            return num;
        }

        bool IList.Contains(object objStyle)
        {
            return this.mobjInnerList.Contains(objStyle);
        }

        int IList.IndexOf(object objStyle)
        {
            return this.mobjInnerList.IndexOf(objStyle);
        }

        void IList.Insert(int intIndex, object objStyle)
        {
            this.EnsureNotOwned((TableLayoutStyle)objStyle);
            ((TableLayoutStyle)objStyle).Owner = this.Owner;
            this.mobjInnerList.Insert(intIndex, objStyle);
            if (ObservableItemInserted != null)
            {
                ObservableItemInserted(this, new ObservableListEventArgs(objStyle));
            }
            this.PerformLayoutIfOwned();
        }

        void IList.Remove(object objStyle)
        {
            ((TableLayoutStyle)objStyle).Owner = null;
            this.mobjInnerList.Remove(objStyle);
            this.PerformLayoutIfOwned();
        }

        private void PerformLayoutIfOwned()
        {
        }

        #endregion

        #region Internal Methods

        internal void EnsureOwnership(IArrangedElement objOwner)
        {
            this.mobjOwner = objOwner;
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Owner = objOwner;
            }
        }

        #endregion

        #endregion
    }

    #endregion

    #region TableLayoutStyle Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    /// <summary>
    /// 
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [TypeConverter(typeof(TableLayoutSettings.StyleConverter)), Serializable()]
    public abstract class TableLayoutStyle : IObservableItem
    {
        #region Class Members

        private IArrangedElement mobjOwner;
        private float mfltSize;
        private SizeType menmSizeType;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutStyle"/> class.
        /// </summary>
        protected TableLayoutStyle()
        {
        }

        #endregion

        #region Properties

        internal IArrangedElement Owner
        {
            get
            {
                return this.mobjOwner;
            }
            set
            {
                if (this.mobjOwner != value)
                {
                    this.mobjOwner = value;
                    FireObservableItemPropertyChanged("Owner");
                }
            }
        }

        internal float Size
        {
            get
            {
                return this.mfltSize;
            }
            set
            {
                if (value < 0f)
                {
                    object[] arrArgs = new object[] { "Size", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("Size", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }
                if (this.mfltSize != value)
                {
                    this.mfltSize = value;
                    FireObservableItemPropertyChanged("Size");
                    if (this.Owner != null)
                    {
                        Control objOwner = this.Owner as Control;
                        if (objOwner != null)
                        {
                            // Raise the size chaged event
                            objOwner.OnResizeInternal(new LayoutEventArgs(false, true, true));

                            objOwner.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the size.
        /// </summary>
        /// <value>The type of the size.</value>
        [DefaultValue(0)]
        public SizeType SizeType
        {
            get
            {
                return this.menmSizeType;
            }
            set
            {
                if (this.menmSizeType != value)
                {
                    this.menmSizeType = value;
                    FireObservableItemPropertyChanged("SizeType");
                    if (this.Owner != null)
                    {
                        Control objOwner = this.Owner as Control;
                        if (objOwner != null)
                        {
                            objOwner.Invalidate();
                        }
                    }
                }
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool ShouldSerializeSize()
        {
            return (this.SizeType != SizeType.AutoSize);
        }

        #endregion

        #region Internal Methods

        internal void SetSize(float fltSize)
        {
            this.mfltSize = fltSize;
        }

        #endregion

        #region IObservableItem Members

        /// <summary>
        /// Property change indicator for the observable item interface
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

        /// <summary>
        /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
        /// </summary>
        /// <param name="strProperty">The name of the property that has changed</param>
        protected void FireObservableItemPropertyChanged(string strProperty)
        {
            if (ObservableItemPropertyChanged != null)
            {
                ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
            }
        }

        #endregion

        #endregion
    }

    #endregion

    #region TableLayoutSettings Class

    /// <summary>
    /// Collects the characteristics associated with table layouts.
    /// </summary>
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutSettingsController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutSettingsController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif

    [TypeConverter(typeof(TableLayoutSettingsTypeConverter)), Serializable()]
    public sealed class TableLayoutSettings : LayoutSettings, ISerializable, IObservableItem
    {
        #region Classes

        #region StyleConverter Class

        [Serializable()]
        public class StyleConverter : TypeConverter
        {
            #region Methods

            #region Public Methods

            public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
            {
                return ((objDestinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(objContext, objDestinationType));
            }

            /// <summary>
            /// 
            /// </summary>
            /// <remarks>
            /// The function essentially limited to work in Partially trusted environment.
            /// InstanceDescriptor c'tor is requiring Full trust (.NET 2.0 - 3.5)
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
            {
                if (objDestinationType == null)
                {
                    throw new ArgumentNullException("objDestinationType");
                }
                if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is TableLayoutStyle))
                {
                    object objResult = ConvertToInstanceDescriptor(objContext, objValue);
                    if (objResult != null)
                        return objResult;
                }
                return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
            }

            /// <summary>
            /// Convert to InstanceDescriptor
            /// </summary>
            /// <remarks>
            /// Extracted from ConvertTo to avoid limtations of InstanceDescriptor related to partially trusted environment
            /// </remarks>
            private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
            {
                TableLayoutStyle objStyle = (TableLayoutStyle)objValue;
                switch (objStyle.SizeType)
                {
                    case SizeType.AutoSize:
                        return new InstanceDescriptor(objStyle.GetType().GetConstructor(new Type[0]), new object[0]);

                    case SizeType.Absolute:
                    case SizeType.Percent:
                        return new InstanceDescriptor(objStyle.GetType().GetConstructor(
                            new Type[] { typeof(SizeType), typeof(int) }), new object[] { objStyle.SizeType, objStyle.Size });
                }
                return null;
            }

            #endregion

            #endregion
        }

        #endregion

        #region TableLayoutSettingsStub Class

        [Serializable()]
        private class TableLayoutSettingsStub
        {
            #region Class Members

            private TableLayoutColumnStyleCollection mobjColumnStyles;
            private Dictionary<object, TableLayoutSettings.ControlInformation> mobjControlsInfo;
            private static TableLayoutSettings.ControlInformation mobjDefaultControlInfo = new TableLayoutSettings.ControlInformation(null, -1, -1, 1, 1);
            private bool mblnIsValid = true;
            private TableLayoutRowStyleCollection mobjRowStyles;

            #endregion

            #region Properties

            public TableLayoutColumnStyleCollection ColumnStyles
            {
                get
                {
                    if (this.mobjColumnStyles == null)
                    {
                        this.mobjColumnStyles = new TableLayoutColumnStyleCollection();
                    }
                    return this.mobjColumnStyles;
                }
            }

            public bool IsValid
            {
                get
                {
                    return this.mblnIsValid;
                }
            }

            public TableLayoutRowStyleCollection RowStyles
            {
                get
                {
                    if (this.mobjRowStyles == null)
                    {
                        this.mobjRowStyles = new TableLayoutRowStyleCollection();
                    }
                    return this.mobjRowStyles;
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public int GetColumn(object objControlName)
            {
                return this.GetControlInformation(objControlName).Column;
            }

            public int GetColumnSpan(object objControlName)
            {
                return this.GetControlInformation(objControlName).ColumnSpan;
            }

            public int GetRow(object objControlName)
            {
                return this.GetControlInformation(objControlName).Row;
            }

            public int GetRowSpan(object objControlName)
            {
                return this.GetControlInformation(objControlName).RowSpan;
            }

            public void SetColumn(object objControlName, int intColumn)
            {
                if (this.GetColumn(objControlName) != intColumn)
                {
                    TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName);
                    controlInformation.Column = intColumn;
                    this.SetControlInformation(objControlName, controlInformation);
                }
            }

            public void SetColumnSpan(object objControlName, int intValue)
            {
                if (this.GetColumnSpan(objControlName) != intValue)
                {
                    TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName);
                    controlInformation.ColumnSpan = intValue;
                    this.SetControlInformation(objControlName, controlInformation);
                }
            }

            public void SetRow(object objControlName, int intRow)
            {
                if (this.GetRow(objControlName) != intRow)
                {
                    TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName);
                    controlInformation.Row = intRow;
                    this.SetControlInformation(objControlName, controlInformation);
                }
            }

            public void SetRowSpan(object objControlName, int intValue)
            {
                if (this.GetRowSpan(objControlName) != intValue)
                {
                    TableLayoutSettings.ControlInformation controlInformation = this.GetControlInformation(objControlName);
                    controlInformation.RowSpan = intValue;
                    this.SetControlInformation(objControlName, controlInformation);
                }
            }

            #endregion

            #region Private Methods

            private TableLayoutSettings.ControlInformation GetControlInformation(object objControlName)
            {
                if (this.mobjControlsInfo == null)
                {
                    return mobjDefaultControlInfo;
                }
                if (!this.mobjControlsInfo.ContainsKey(objControlName))
                {
                    return mobjDefaultControlInfo;
                }
                return this.mobjControlsInfo[objControlName];
            }

            private void SetControlInformation(object objControlName, TableLayoutSettings.ControlInformation objControlInformation)
            {
                if (this.mobjControlsInfo == null)
                {
                    this.mobjControlsInfo = new Dictionary<object, TableLayoutSettings.ControlInformation>();
                }
                this.mobjControlsInfo[objControlName] = objControlInformation;
            }

            #endregion

            #region Internal Methods

            internal void ApplySettings(TableLayoutSettings objSettings)
            {
                TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(objSettings.Owner);
                Control objContainer = objContainerInfo.Container as Control;
                if ((objContainer != null) && (this.mobjControlsInfo != null))
                {
                    foreach (object obj in this.mobjControlsInfo.Keys)
                    {
                        TableLayoutSettings.ControlInformation objControlInformation = this.mobjControlsInfo[obj];
                        foreach (Control objControl in objContainer.Controls)
                        {
                            if (objControl == null)
                            {
                                continue;
                            }
                            string str = null;
                            PropertyDescriptor objDescriptor = TypeDescriptor.GetProperties(objControl)["Name"];
                            if ((objDescriptor != null) && (objDescriptor.PropertyType == typeof(string)))
                            {
                                str = objDescriptor.GetValue(objControl) as string;
                            }
                            if (ClientUtils.SafeCompareStrings(str, obj as string, false))
                            {
                                objSettings.SetRow(objControl, objControlInformation.Row);
                                objSettings.SetColumn(objControl, objControlInformation.Column);
                                objSettings.SetRowSpan(objControl, objControlInformation.RowSpan);
                                objSettings.SetColumnSpan(objControl, objControlInformation.ColumnSpan);
                                break;
                            }
                        }
                    }
                }
                objContainerInfo.RowStyles = this.mobjRowStyles;
                objContainerInfo.ColumnStyles = this.mobjColumnStyles;
                this.mobjColumnStyles = null;
                this.mobjRowStyles = null;
                this.mblnIsValid = false;
            }

            internal List<TableLayoutSettings.ControlInformation> GetControlsInformation()
            {
                if (this.mobjControlsInfo == null)
                {
                    return new List<TableLayoutSettings.ControlInformation>();
                }
                List<TableLayoutSettings.ControlInformation> objList = new List<TableLayoutSettings.ControlInformation>(this.mobjControlsInfo.Count);
                foreach (object obj2 in this.mobjControlsInfo.Keys)
                {
                    TableLayoutSettings.ControlInformation objItem = this.mobjControlsInfo[obj2];
                    objItem.Name = obj2;
                    objList.Add(objItem);
                }
                return objList;
            }

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region Class Members

        private TableLayoutPanelCellBorderStyle menmBorderStyle;
        private TableLayoutSettingsStub mobjTableLayoutSettingsStub;
        private static int[] marrBorderStyleToOffset = new int[] { 0, 1, 2, 3, 2, 3, 3 };

        #endregion

        #region C'Tors \ D'Tors

        internal TableLayoutSettings(SerializationInfo objSerializationInfo, StreamingContext objContext)
            : base(null)
        {

            this.mobjOwner =objSerializationInfo.GetValue("Owner",typeof(IArrangedElement)) as IArrangedElement;

            // From resx
            if (mobjOwner == null)
            {
                this.mobjTableLayoutSettingsStub = new TableLayoutSettingsStub();
            }

            TypeConverter objConverter = TypeDescriptor.GetConverter(this);
            string str = objSerializationInfo.GetString("SerializedString");
            if (!CommonUtils.IsNullOrEmpty(str) && (objConverter != null))
            {
                TableLayoutSettings objSettings = objConverter.ConvertFromInvariantString(str) as TableLayoutSettings;
                if (objSettings != null)
                {
                    this.ApplySettings(objSettings);
                }
            }
        }

        internal TableLayoutSettings(IArrangedElement objOwner)
            : base(objOwner)
        {
        }

        internal TableLayoutSettings()
            : base(null)
        {
            this.mobjTableLayoutSettingsStub = new TableLayoutSettingsStub();
        }

        #endregion

        #region Properties

        [SRDescription("TableLayoutPanelCellBorderStyleDescr"), DefaultValue(0), SRCategory("CatAppearance")]
        internal TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get
            {
                return this.menmBorderStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 6))
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "CellBorderStyle", value.ToString() }));
                }
                this.menmBorderStyle = value;
                FireObservableItemPropertyChanged("CellBorderStyle");
                TableLayout.GetContainerInfo(base.Owner).CellBorderWidth = marrBorderStyleToOffset[(int)value];
            }
        }

        [DefaultValue(0)]
        internal int CellBorderWidth
        {
            get
            {
                return TableLayout.GetContainerInfo(base.Owner).CellBorderWidth;
            }
        }

        /// <summary>
        /// Gets or sets the column count.
        /// </summary>
        /// <value>The column count.</value>
        [DefaultValue(0), SRDescription("GridPanelColumnsDescr"), SRCategory("CatLayout")]
        public int ColumnCount
        {
            get
            {
                return TableLayout.GetContainerInfo(base.Owner).MaxColumns;
            }
            set
            {
                if (value < 0)
                {
                    object[] arrArgs = new object[] { "ColumnCount", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("ColumnCount", value, SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }
                TableLayout.GetContainerInfo(base.Owner).MaxColumns = value;
                FireObservableItemPropertyChanged("ColumnCount");
            }
        }

        /// <summary>
        /// Gets the column styles.
        /// </summary>
        /// <value>The column styles.</value>
        [SRCategory("CatLayout"), SRDescription("GridPanelColumnStylesDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableLayoutColumnStyleCollection ColumnStyles
        {
            get
            {
                if (this.IsStub)
                {
                    return this.mobjTableLayoutSettingsStub.ColumnStyles;
                }
                return TableLayout.GetContainerInfo(base.Owner).ColumnStyles;
            }
        }

        /// <summary>
        /// Gets or sets the grow style.
        /// </summary>
        /// <value>The grow style.</value>
        [SRDescription("TableLayoutPanelGrowStyleDescr"), DefaultValue(1), SRCategory("CatLayout")]
        public TableLayoutPanelGrowStyle GrowStyle
        {
            get
            {
                return TableLayout.GetContainerInfo(base.Owner).GrowStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "GrowStyle", value.ToString() }));
                }
                TableLayout.ContainerInfo objContainerInfo = TableLayout.GetContainerInfo(base.Owner);
                if (objContainerInfo.GrowStyle != value)
                {
                    objContainerInfo.GrowStyle = value;
                    FireObservableItemPropertyChanged("GrowStyle");
                }
            }
        }

        internal bool IsStub
        {
            get
            {
                return (this.mobjTableLayoutSettingsStub != null);
            }
        }

        /// <summary>
        /// Gets the layout engine.
        /// </summary>
        /// <value>The layout engine.</value>
        public override LayoutEngine LayoutEngine
        {
            get
            {
                return TableLayout.Instance;
            }
        }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>The row count.</value>
        [SRDescription("GridPanelRowsDescr"), DefaultValue(0), SRCategory("CatLayout")]
        public int RowCount
        {
            get
            {
                return TableLayout.GetContainerInfo(base.Owner).MaxRows;
            }
            set
            {
                if (value < 0)
                {
                    object[] arrArgs = new object[] { "RowCount", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("RowCount", value, SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }
                TableLayout.GetContainerInfo(base.Owner).MaxRows = value;
                FireObservableItemPropertyChanged("RowCount");
            }
        }

        /// <summary>
        /// Gets the row styles.
        /// </summary>
        /// <value>The row styles.</value>
        [SRDescription("GridPanelRowStylesDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatLayout")]
        public TableLayoutRowStyleCollection RowStyles
        {
            get
            {
                if (this.IsStub)
                {
                    return this.mobjTableLayoutSettingsStub.RowStyles;
                }
                return TableLayout.GetContainerInfo(base.Owner).RowStyles;
            }
        }

        private TableLayout TableLayout
        {
            get
            {
                return (TableLayout)this.LayoutEngine;
            }
        }

        #endregion

        #region Methods

        #region IObservableItem Members

        /// <summary>
        /// Property change indicator for the observable item interface
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

        /// <summary>
        /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
        /// </summary>
        /// <param name="strProperty">The name of the property that has changed</param>
        protected void FireObservableItemPropertyChanged(string strProperty)
        {
            if (ObservableItemPropertyChanged != null)
            {
                ObservableItemPropertyChanged(this, new ObservableItemPropertyChangedArgs(strProperty));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the cell position.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [DefaultValue(-1), SRDescription("TableLayoutSettingsGetCellPositionDescr"), SRCategory("CatLayout")]
        public TableLayoutPanelCellPosition GetCellPosition(object objControl)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            return new TableLayoutPanelCellPosition(this.GetColumn(objControl), this.GetRow(objControl));
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRCategory("CatLayout"), SRDescription("GridPanelColumnDescr"), DefaultValue(-1)]
        public int GetColumn(object objControl)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            if (this.IsStub)
            {
                return this.mobjTableLayoutSettingsStub.GetColumn(objControl);
            }
            return TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).ColumnPosition;
        }

        /// <summary>
        /// Gets the column span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        public int GetColumnSpan(object objControl)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            if (this.IsStub)
            {
                return this.mobjTableLayoutSettingsStub.GetColumnSpan(objControl);
            }
            return TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).ColumnSpan;
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        [SRDescription("GridPanelRowDescr"), DefaultValue(-1), SRCategory("CatLayout")]
        public int GetRow(object objControl)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            if (this.IsStub)
            {
                return this.mobjTableLayoutSettingsStub.GetRow(objControl);
            }
            return TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).RowPosition;
        }

        /// <summary>
        /// Gets the row span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        public int GetRowSpan(object objControl)
        {
            if (this.IsStub)
            {
                return this.mobjTableLayoutSettingsStub.GetRowSpan(objControl);
            }
            return TableLayout.GetLayoutInfo(this.LayoutEngine.CastToArrangedElement(objControl)).RowSpan;
        }

        /// <summary>
        /// Sets the cell position.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="objCellPosition">The cell position.</param>
        [SRCategory("CatLayout"), DefaultValue(-1), SRDescription("TableLayoutSettingsSetCellPositionDescr")]
        public void SetCellPosition(object objControl, TableLayoutPanelCellPosition objCellPosition)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            this.SetCellPosition(objControl, objCellPosition.Row, objCellPosition.Column, true, true);
        }

        /// <summary>
        /// Sets the column.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intColumn">The column.</param>
        public void SetColumn(object objControl, int intColumn)
        {
            if (intColumn < -1)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "Column", intColumn.ToString(CultureInfo.CurrentCulture) }));
            }
            if (this.IsStub)
            {
                this.mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
            }
            else
            {
                this.SetCellPosition(objControl, -1, intColumn, false, true);
            }
        }

        /// <summary>
        /// Sets the column span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intValue">The value.</param>
        public void SetColumnSpan(object objControl, int intValue)
        {
            if (intValue < 1)
            {
                throw new ArgumentOutOfRangeException("ColumnSpan", SR.GetString("InvalidArgument", new object[] { "ColumnSpan", intValue.ToString(CultureInfo.CurrentCulture) }));
            }
            if (this.IsStub)
            {
                this.mobjTableLayoutSettingsStub.SetColumnSpan(objControl, intValue);
            }
            else
            {
                IArrangedElement objElement = this.LayoutEngine.CastToArrangedElement(objControl);
                if (GetElementContainer(objElement) != null)
                {
                    TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
                }
                TableLayout.GetLayoutInfo(objElement).ColumnSpan = intValue;
            }
        }

        /// <summary>
        /// Sets the row.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intRow">The row.</param>
        public void SetRow(object objControl, int intRow)
        {
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            if (intRow < -1)
            {
                throw new ArgumentOutOfRangeException("Row", SR.GetString("InvalidArgument", new object[] { "Row", intRow.ToString(CultureInfo.CurrentCulture) }));
            }
            this.SetCellPosition(objControl, intRow, -1, true, false);
        }

        /// <summary>
        /// Sets the row span.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intValue">The value.</param>
        public void SetRowSpan(object objControl, int intValue)
        {
            if (intValue < 1)
            {
                throw new ArgumentOutOfRangeException("RowSpan", SR.GetString("InvalidArgument", new object[] { "RowSpan", intValue.ToString(CultureInfo.CurrentCulture) }));
            }
            if (objControl == null)
            {
                throw new ArgumentNullException("control");
            }
            if (this.IsStub)
            {
                this.mobjTableLayoutSettingsStub.SetRowSpan(objControl, intValue);
            }
            else
            {
                IArrangedElement objElement = this.LayoutEngine.CastToArrangedElement(objControl);
                if (GetElementContainer(objElement) != null)
                {
                    TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
                }
                TableLayout.GetLayoutInfo(objElement).RowSpan = intValue;
            }
        }

        #endregion

        #region Private Methods

        void ISerializable.GetObjectData(SerializationInfo objSerializationInfo, StreamingContext objContext)
        {
            TypeConverter objConverter = TypeDescriptor.GetConverter(this);
            string str = (objConverter != null) ? objConverter.ConvertToInvariantString(this) : null;
            if (!CommonUtils.IsNullOrEmpty(str))
            {
                objSerializationInfo.AddValue("SerializedString", str);
            }

            objSerializationInfo.AddValue("Owner", mobjOwner);
        }

        private void SetCellPosition(object objControl, int intRow, int intColumn, bool blnRowSpecified, bool blnColSpecified)
        {
            if (this.IsStub)
            {
                if (blnColSpecified)
                {
                    this.mobjTableLayoutSettingsStub.SetColumn(objControl, intColumn);
                }
                if (blnRowSpecified)
                {
                    this.mobjTableLayoutSettingsStub.SetRow(objControl, intRow);
                }
            }
            else
            {
                IArrangedElement objElement = this.LayoutEngine.CastToArrangedElement(objControl);
                if (GetElementContainer(objElement) != null)
                {
                    TableLayout.ClearCachedAssignments(TableLayout.GetContainerInfo(GetElementContainer(objElement)));
                }
                TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(objElement);
                if (blnColSpecified)
                {
                    layoutInfo.ColumnPosition = intColumn;
                }
                if (blnRowSpecified)
                {
                    layoutInfo.RowPosition = intRow;
                }
            }

            FireObservableItemPropertyChanged("SetCellPosition");
        }

        #endregion

        #region Internal Methods

        internal void ApplySettings(TableLayoutSettings objSettings)
        {
            if (objSettings.IsStub)
            {
                if (!this.IsStub)
                {
                    objSettings.mobjTableLayoutSettingsStub.ApplySettings(this);
                }
                else
                {
                    this.mobjTableLayoutSettingsStub = objSettings.mobjTableLayoutSettingsStub;
                }
            }
        }

        internal IArrangedElement GetControlFromPosition(int intColumn, int intRow)
        {
            return this.TableLayout.GetControlFromPosition(base.Owner, intColumn, intRow);
        }

        internal List<ControlInformation> GetControlsInformation()
        {
            if (this.IsStub)
            {
                return this.mobjTableLayoutSettingsStub.GetControlsInformation();
            }
            List<ControlInformation> objList = new List<ControlInformation>(base.Owner.Children.Count);
            foreach (IArrangedElement objElement in base.Owner.Children)
            {
                Control objComponent = objElement as Control;
                if (objComponent != null)
                {
                    ControlInformation objItemInformation = new ControlInformation();
                    PropertyDescriptor objDescriptor = TypeDescriptor.GetProperties(objComponent)["Name"];
                    if ((objDescriptor != null) && (objDescriptor.PropertyType == typeof(string)))
                    {
                        objItemInformation.Name = objDescriptor.GetValue(objComponent);
                    }
                    objItemInformation.Row = this.GetRow(objComponent);
                    objItemInformation.RowSpan = this.GetRowSpan(objComponent);
                    objItemInformation.Column = this.GetColumn(objComponent);
                    objItemInformation.ColumnSpan = this.GetColumnSpan(objComponent);
                    objList.Add(objItemInformation);
                }
            }
            return objList;
        }

        internal IArrangedElement GetElementContainer(IArrangedElement objElement)
        {
            IArrangedElement objContainer = null;

            if (objElement != null &&
                objElement is Control &&
                ((Control)objElement).Container is IArrangedElement)
            {
                objContainer = ((Control)objElement).Container as IArrangedElement;
            }

            return objContainer;
        }

        internal TableLayoutPanelCellPosition GetPositionFromControl(IArrangedElement objElement)
        {
            return this.TableLayout.GetPositionFromControl(base.Owner, objElement);
        }

        #endregion

        #endregion

        [StructLayout(LayoutKind.Sequential), Serializable()]
        internal struct ControlInformation
        {
            internal object Name;
            internal int Row;
            internal int Column;
            internal int RowSpan;
            internal int ColumnSpan;
            internal ControlInformation(object objName, int intRow, int intColumn, int intRowSpan, int intColumnSpan)
            {
                this.Name = objName;
                this.Row = intRow;
                this.Column = intColumn;
                this.RowSpan = intRowSpan;
                this.ColumnSpan = intColumnSpan;
            }
        }
    }

    #endregion

    #region TableLayoutColumnStyleCollection Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    /// <summary>
    /// 
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif

    [Serializable()]
    public class TableLayoutColumnStyleCollection : TableLayoutStyleCollection, IObservableList
    {
        #region C'Tors \ D'Tors

        internal TableLayoutColumnStyleCollection(IArrangedElement objOwner)
            : base(objOwner)
        {
        }

        internal TableLayoutColumnStyleCollection()
            : base(null)
        {
        }

        #endregion

        #region Properties

        internal override string PropertyName
        {
            get
            {
                return PropertyNames.ColumnStyles;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Gizmox.WebGUI.Forms.TableLayoutStyle"/> at the specified index.
        /// </summary>
        /// <value></value>
        new public ColumnStyle this[int index]
        {
            get
            {
                return (ColumnStyle)base[index];
            }
            set
            {
                this[index] = value;
            }
        }

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemRemoved;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event EventHandler ObservableListCleared;

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified column style.
        /// </summary>
        /// <param name="objcolumnStyle">The column style.</param>
        /// <returns></returns>
        public int Add(ColumnStyle objcolumnStyle)
        {
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objcolumnStyle));
            }

            return ((IList)this).Add(objcolumnStyle);
        }

        /// <summary>
        /// Adds a new column style.
        /// </summary>
        /// <param name="intWidth"></param>
        /// <returns></returns>
        public int Add(int intWidth)
        {
            ColumnStyle objColumnStyle = new ColumnStyle(intWidth.ToString());
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objColumnStyle));
            }
            return Add(objColumnStyle);
        }

        /// <summary>
        /// Determines whether [contains] [the specified column style].
        /// </summary>
        /// <param name="objcolumnStyle">The column style.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified column style]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(ColumnStyle objcolumnStyle)
        {
            return ((IList)this).Contains(objcolumnStyle);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="objcolumnStyle">The column style.</param>
        /// <returns></returns>
        public int IndexOf(ColumnStyle objcolumnStyle)
        {
            return ((IList)this).IndexOf(objcolumnStyle);
        }

        /// <summary>
        /// Inserts the specified index.
        /// </summary>
        /// <param name="intIndex">The index.</param>
        /// <param name="objcolumnStyle">The column style.</param>
        public void Insert(int intIndex, ColumnStyle objcolumnStyle)
        {
            if (ObservableItemInserted != null)
            {
                ObservableItemInserted(this, new ObservableListEventArgs(objcolumnStyle));
            }
            ((IList)this).Insert(intIndex, objcolumnStyle);
        }

        /// <summary>
        /// Removes the specified column style.
        /// </summary>
        /// <param name="objcolumnStyle">The column style.</param>
        public void Remove(ColumnStyle objcolumnStyle)
        {
            if (ObservableItemRemoved != null)
            {
                ObservableItemRemoved(this, new ObservableListEventArgs(objcolumnStyle));
            }
            ((IList)this).Remove(objcolumnStyle);
        }

        #endregion

        #endregion
    }

    #endregion

    #region ColumnStyle Class

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    /// <summary>
    /// 
    /// </summary>
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnStyleController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.ColumnStyleController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class ColumnStyle : TableLayoutStyle
    {
        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnStyle"/> class.
        /// </summary>
        /// <param name="objSizeType">Type of the size.</param>
        /// <param name="fltWidth">The width.</param>
        public ColumnStyle(SizeType objSizeType, float fltWidth)
        {
            base.SizeType = objSizeType;
            this.Width = fltWidth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnStyle"/> class.
        /// </summary>
        /// <param name="objSizeType">Type of the size.</param>
        public ColumnStyle(SizeType objSizeType)
        {
            base.SizeType = objSizeType;
        }

        /// <summary>
        /// Creates a new <see cref="ColumnStyle"/> instance.
        /// </summary>
        /// <param name="strWidth">Width of the current column.</param>
        public ColumnStyle(string strWidth)
        {
			this.Width = float.Parse(strWidth, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Creates a new <see cref="ColumnStyle"/> instance.
        /// </summary>
        /// <param name="intWidth">Width of the current column.</param>
        public ColumnStyle(int intWidth)
        {
            this.Width = intWidth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnStyle"/> class.
        /// </summary>
        public ColumnStyle()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public float Width
        {
            get
            {
                return base.Size;
            }
            set
            {
                if (base.Size != value)
                {
                    base.Size = value;
                    FireObservableItemPropertyChanged("Width");
                }
            }
        }

        #endregion
    }

    #endregion

    #region LayoutEngine Class


    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class LayoutEngine
    {
        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutEngine"/> class.
        /// </summary>
        protected LayoutEngine()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Inits the layout.
        /// </summary>
        /// <param name="objChild">The child.</param>
        /// <param name="enmSpecified">The specified.</param>
        public virtual void InitLayout(object objChild, BoundsSpecified enmSpecified)
        {
            this.InitLayoutCore(this.CastToArrangedElement(objChild), enmSpecified);
        }

        /// <summary>
        /// Layouts the specified container.
        /// </summary>
        /// <param name="objContainer">The container.</param>
        /// <param name="objLayoutEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public virtual bool Layout(object objContainer, LayoutEventArgs objLayoutEventArgs)
        {
            return this.LayoutCore(this.CastToArrangedElement(objContainer), objLayoutEventArgs);
        }

        #endregion

        #region Internal Methods

        internal IArrangedElement CastToArrangedElement(object obj)
        {
            IArrangedElement objElement = obj as IArrangedElement;
            if (obj == null)
            {
                throw new NotSupportedException(SR.GetString("LayoutEngineUnsupportedType", new object[] { obj.GetType() }));
            }
            return objElement;
        }

        internal virtual Size GetPreferredSize(IArrangedElement objContainer, Size objProposedConstraints)
        {
            return Size.Empty;
        }

        /// <summary>
        /// Inits the layout core.
        /// </summary>
        /// <param name="objElement">The element.</param>
        /// <param name="enmBounds">The bounds.</param>
        internal virtual void InitLayoutCore(IArrangedElement objElement, BoundsSpecified enmBounds)
        {
        }

        internal virtual bool LayoutCore(IArrangedElement objContainer, LayoutEventArgs layoutEventArgs)
        {
            return false;
        }

        internal virtual void ProcessSuspendedLayoutEventArgs(IArrangedElement objContainer, LayoutEventArgs args)
        {
        }

        #endregion

        #endregion

    }

    #endregion

    #region TableLayoutControlCollection Class

    /// <summary>
    /// 
    /// </summary>
#if WG_NET46
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ListBindable(false)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutControlCollectionController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutControlCollectionController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class TableLayoutControlCollection : Control.ControlCollection, IObservableList
    {
        #region Class Members

        private TableLayoutPanel mobjContainer;

        #endregion

        #region C'Tors \ D'Tors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLayoutControlCollection"/> class.
        /// </summary>
        /// <param name="objContainer">The container.</param>
        public TableLayoutControlCollection(TableLayoutPanel objContainer)
            : base(objContainer)
        {
            this.mobjContainer = objContainer;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>The container.</value>
        public TableLayoutPanel Container
        {
            get
            {
                return this.mobjContainer;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <param name="intColumn">The column.</param>
        /// <param name="intRow">The row.</param>
        public virtual void Add(Control objControl, int intColumn, int intRow)
        {
            if (ObservableItemAdded != null)
            {
                ObservableItemAdded(this, new ObservableListEventArgs(objControl));
            }
            base.Add(objControl);
            this.mobjContainer.SetColumn(objControl, intColumn);
            this.mobjContainer.SetRow(objControl, intRow);
        }

        #endregion

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event ObservableListEventHandler ObservableItemRemoved;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        new public event EventHandler ObservableListCleared;

        #endregion
    }

    #endregion

    #region LayoutSettings Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class LayoutSettings
    {
        #region Class Members

        internal IArrangedElement mobjOwner;

        #endregion

        #region C'Tors \ D'Tors

        internal LayoutSettings(IArrangedElement objOwner)
        {
            this.mobjOwner = objOwner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutSettings"/> class.
        /// </summary>
        protected LayoutSettings()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the layout engine.
        /// </summary>
        /// <value>The layout engine.</value>
        public virtual LayoutEngine LayoutEngine
        {
            get
            {
                return null;
            }
        }

        internal IArrangedElement Owner
        {
            get
            {
                return this.mobjOwner;
            }
        }

        #endregion
    }

    #endregion

    #region TableLayoutSettingsTypeConverter Class

    /// <summary>
    /// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.
    /// </summary>
    [Serializable()]
    public class TableLayoutSettingsTypeConverter : TypeConverter
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objSourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            return ((objSourceType == typeof(string)) || base.CanConvertFrom(objContext, objSourceType));
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objDestinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            if ((objDestinationType != typeof(InstanceDescriptor)) && (objDestinationType != typeof(string)))
            {
                return base.CanConvertTo(objContext, objDestinationType);
            }
            return true;
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.LoadXml(objValue as string);
                TableLayoutSettings objSettings = new TableLayoutSettings();
                this.ParseControls(objSettings, objXmlDocument.GetElementsByTagName("Control"));
                this.ParseStyles(objSettings, objXmlDocument.GetElementsByTagName("Columns"), true);
                this.ParseStyles(objSettings, objXmlDocument.GetElementsByTagName("Rows"), false);
                return objSettings;
            }
            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="objValue">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="objDestinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="objDestinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            if (!(objValue is TableLayoutSettings) || (objDestinationType != typeof(string)))
            {
                return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
            }
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            TableLayoutSettings objSettings = objValue as TableLayoutSettings;
            StringBuilder objOutput = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(objOutput);
            writer.WriteStartElement("TableLayoutSettings");
            writer.WriteStartElement("Controls");
            foreach (TableLayoutSettings.ControlInformation information in objSettings.GetControlsInformation())
            {
                writer.WriteStartElement("Control");
                writer.WriteAttributeString("Name", information.Name.ToString());
                writer.WriteAttributeString("Row", information.Row.ToString(CultureInfo.CurrentCulture));
                writer.WriteAttributeString("RowSpan", information.RowSpan.ToString(CultureInfo.CurrentCulture));
                writer.WriteAttributeString("Column", information.Column.ToString(CultureInfo.CurrentCulture));
                writer.WriteAttributeString("ColumnSpan", information.ColumnSpan.ToString(CultureInfo.CurrentCulture));
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("Columns");
            StringBuilder objStringBuilder = new StringBuilder();
            foreach (ColumnStyle objStyle in (IEnumerable)objSettings.ColumnStyles)
            {
                objStringBuilder.AppendFormat("{0},{1},", objStyle.SizeType, objStyle.Width);
            }
            if (objStringBuilder.Length > 0)
            {
                objStringBuilder.Remove(objStringBuilder.Length - 1, 1);
            }
            writer.WriteAttributeString("Styles", objStringBuilder.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Rows");
            StringBuilder objStringBuilder2 = new StringBuilder();
            foreach (RowStyle objStyle in (IEnumerable)objSettings.RowStyles)
            {
                objStringBuilder2.AppendFormat("{0},{1},", objStyle.SizeType, objStyle.Height);
            }
            if (objStringBuilder2.Length > 0)
            {
                objStringBuilder2.Remove(objStringBuilder2.Length - 1, 1);
            }
            writer.WriteAttributeString("Styles", objStringBuilder2.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
            return objOutput.ToString();
#else
            return string.Empty;
#endif
        }

        #endregion

        #region Private Methods

        private string GetAttributeValue(XmlNode objXmlNode, string strAttribute)
        {
            XmlAttribute objXmlAttribute = objXmlNode.Attributes[strAttribute];
            if (objXmlAttribute != null)
            {
                return objXmlAttribute.Value;
            }
            return null;
        }

        private int GetAttributeValue(XmlNode objXmlNode, string strAttribute, int intValueIfNotFound)
        {
            double dblNum;
            string strAttributeValue = this.GetAttributeValue(objXmlNode, strAttribute);
            if (!CommonUtils.IsNullOrEmpty(strAttributeValue) && CommonUtils.TryParse(strAttributeValue, out dblNum))
            {
                return Convert.ToInt32(dblNum);
            }
            return intValueIfNotFound;
        }

        private void ParseControls(TableLayoutSettings objSettings, XmlNodeList controlXmlFragments)
        {
            foreach (XmlNode objXmlNode in controlXmlFragments)
            {
                string strAttributeValue = this.GetAttributeValue(objXmlNode, "Name");
                if (!CommonUtils.IsNullOrEmpty(strAttributeValue))
                {
                    int intRow = this.GetAttributeValue(objXmlNode, "Row", -1);
                    int num2 = this.GetAttributeValue(objXmlNode, "RowSpan", 1);
                    int intColumn = this.GetAttributeValue(objXmlNode, "Column", -1);
                    int num4 = this.GetAttributeValue(objXmlNode, "ColumnSpan", 1);
                    objSettings.SetRow(strAttributeValue, intRow);
                    objSettings.SetColumn(strAttributeValue, intColumn);
                    objSettings.SetRowSpan(strAttributeValue, num2);
                    objSettings.SetColumnSpan(strAttributeValue, num4);
                }
            }
        }

        private void ParseStyles(TableLayoutSettings objSettings, XmlNodeList objControlXmlFragments, bool blnColumns)
        {
            foreach (XmlNode objXmlNode in objControlXmlFragments)
            {
                string strAttributeValue = this.GetAttributeValue(objXmlNode, "Styles");
                Type objEnumType = typeof(SizeType);
                if (!CommonUtils.IsNullOrEmpty(strAttributeValue))
                {
                    int num2;
                    for (int i = 0; i < strAttributeValue.Length; i = num2)
                    {
                        float fltNum3;
                        num2 = i;
                        while (char.IsLetter(strAttributeValue[num2]))
                        {
                            num2++;
                        }
                        SizeType objSizeType = (SizeType)Enum.Parse(objEnumType, strAttributeValue.Substring(i, num2 - i), true);
                        while (!char.IsDigit(strAttributeValue[num2]))
                        {
                            num2++;
                        }
                        StringBuilder builder = new StringBuilder();
                        while ((num2 < strAttributeValue.Length) && char.IsDigit(strAttributeValue[num2]))
                        {
                            builder.Append(strAttributeValue[num2]);
                            num2++;
                        }
                        builder.Append('.');
                        while ((num2 < strAttributeValue.Length) && !char.IsLetter(strAttributeValue[num2]))
                        {
                            if (char.IsDigit(strAttributeValue[num2]))
                            {
                                builder.Append(strAttributeValue[num2]);
                            }
                            num2++;
                        }
                        if (!CommonUtils.TryParse(builder.ToString(), out fltNum3))
                        {
                            fltNum3 = 0f;
                        }
                        if (blnColumns)
                        {
                            objSettings.ColumnStyles.Add(new ColumnStyle(objSizeType, fltNum3));
                        }
                        else
                        {
                            objSettings.RowStyles.Add(new RowStyle(objSizeType, fltNum3));
                        }
                    }
                }
            }
        }

        #endregion

        #endregion
    }

    #endregion

    #region TableLayoutControlPosition Class

    /// <summary>
    /// A table layout control layout position.
    /// </summary>
    [Serializable()]
    internal class TableLayoutControlPosition
    {
        #region Class Members

        public int Column;
        public int Row;
        public int Colspan;
        public int Rowspan;
        public Control Control;

        #endregion Class Members
    }

    #endregion

    /// <summary>
    /// This class helps holding style information about each cell in table.
    /// </summary>    
    internal class TableLayoutPanelCellStyle
    {
        float fltTopPercent, fltBottomPercent, fltLeftPercent, fltRightPercent;
        float fltTopMarginPixel, fltBottomMarginPixel, fltLeftMarginPixel, fltRightMarginPixel;

        public TableLayoutPanelCellStyle()
        {
            fltTopPercent = fltBottomPercent = fltLeftPercent = fltRightPercent = 0;
            fltTopMarginPixel = fltBottomMarginPixel = fltLeftMarginPixel = fltRightMarginPixel = 0;
        }

        public float TopPercent
        {
            get
            {
                return fltTopPercent;
            }
            set
            {
                fltTopPercent = value;
            }
        }

        public float BottomPercent
        {
            get
            {
                return fltBottomPercent;
            }
            set
            {
                fltBottomPercent = value;
            }
        }

        public float LeftPercent
        {
            get
            {
                return fltLeftPercent;
            }
            set
            {
                fltLeftPercent = value;
            }
        }

        public float RightPercent
        {
            get
            {
                return fltRightPercent;
            }
            set
            {
                fltRightPercent = value;
            }
        }

        public float TopMarginPixel
        {
            get
            {
                return fltTopMarginPixel;
            }
            set
            {
                fltTopMarginPixel = value;
            }
        }

        public float BottomMarginPixel
        {
            get
            {
                return fltBottomMarginPixel;
            }
            set
            {
                fltBottomMarginPixel = value;
            }
        }

        public float LeftMarginPixel
        {
            get
            {
                return fltLeftMarginPixel;
            }
            set
            {
                fltLeftMarginPixel = value;
            }
        }

        public float RightMarginPixel
        {
            get
            {
                return fltRightMarginPixel;
            }
            set
            {
                fltRightMarginPixel = value;
            }
        }

    }

    
}
