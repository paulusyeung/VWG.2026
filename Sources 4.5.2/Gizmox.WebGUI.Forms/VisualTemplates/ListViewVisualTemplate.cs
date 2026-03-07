using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// The appearances available for grouping.
    /// </summary>
    [Serializable]
    public enum ListViewVisualTemplateGroupingStyleEnum : int
    {
        None,
        Original,
        AlphabetGrouping
    }

    /// <summary>
    /// The appearances available for one item (ListViewItem).
    /// </summary>
    [Serializable]
    public enum ListViewVisualTemplateRowTemplateEnum : int
    {
        None,
        Custom,
        ContactList
    }

    /// <summary>
    /// The visual appearnce object of the ListView
    /// </summary>
    [VisualTemplate(typeof(ListView), "Visually adjusts the ListView control to an appearance more suitable for the customized device.")]
    [Serializable]
    [Skin(typeof(ListViewVisualTemplateSkin))]
    public class ListViewVisualTemplate : VisualTemplate
    {
        private ListViewVisualTemplateGroupingStyleEnum menmListViewVisualTemplateGroupingStyleEnum = ListViewVisualTemplateGroupingStyleEnum.Original;
        private ListViewVisualTemplateRowTemplateEnum menmListViewVisualTemplateRowTemplateEnum = ListViewVisualTemplateRowTemplateEnum.None;
        private string mstrColumnNumberNewOrder;
        private string mstrListViewVisualTemplateRowCustomStyleName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewVisualTemplate"/> class.
        /// </summary>
        public ListViewVisualTemplate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListViewVisualTemplate"/> class.
        /// </summary>
        /// <param name="enmProxyListViewGroupsVisualizerStyle">The enm proxy ListView groups visualizer style.</param>
        /// <param name="strColumnNumberNewOrder">The string column number new order.</param>
        public ListViewVisualTemplate(ListViewVisualTemplateGroupingStyleEnum enmProxyListViewGroupsVisualizerStyle, ListViewVisualTemplateRowTemplateEnum enmListViewVisualTemplateRowTemplateEnum, string strColumnNumberNewOrder, string strListViewVisualTemplateRowCustomStyleName)
        {
            this.menmListViewVisualTemplateGroupingStyleEnum = enmProxyListViewGroupsVisualizerStyle;
            this.menmListViewVisualTemplateRowTemplateEnum = enmListViewVisualTemplateRowTemplateEnum;
            this.mstrColumnNumberNewOrder = strColumnNumberNewOrder;
            this.mstrListViewVisualTemplateRowCustomStyleName = strListViewVisualTemplateRowCustomStyleName;
        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeContevert)
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override object[] GetConsturctorArguments()
        {
            return new object[4] { menmListViewVisualTemplateGroupingStyleEnum, menmListViewVisualTemplateRowTemplateEnum, mstrColumnNumberNewOrder, mstrListViewVisualTemplateRowCustomStyleName };
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeContevert)
        /// </summary>
        public override Type[] GetConstructorTypes()
        {
            return new Type[4] { typeof(ListViewVisualTemplateGroupingStyleEnum), typeof(ListViewVisualTemplateRowTemplateEnum), typeof(string), typeof(string) };
        }

        /// <summary>
        /// Gets or sets the proxy ListView groups visualizer style.
        /// </summary>
        /// <value>
        /// The proxy ListView groups visualizer style.
        /// </value>
        [DisplayName("Grouping style")]
        [Description("The grouping option of the ListViewItems.")]
        public ListViewVisualTemplateGroupingStyleEnum ListViewVisualTemplateGroupingStyle
        {
            get
            {
                return menmListViewVisualTemplateGroupingStyleEnum;
            }
            set
            {
                this.menmListViewVisualTemplateGroupingStyleEnum = value;
            }
        }

        /// <summary>
        /// Gets or sets the proxy ListView groups visualizer style.
        /// </summary>
        /// <value>
        /// The proxy ListView groups visualizer style.
        /// </value>        
        [DisplayName("Row template")]
        [Description("The template of a row in the ListView. To insert a custom template, choose \"Custom\".")]
        public ListViewVisualTemplateRowTemplateEnum ListViewVisualTemplateRowTemplate
        {
            get
            {
                return menmListViewVisualTemplateRowTemplateEnum;
            }
            set
            {
                this.menmListViewVisualTemplateRowTemplateEnum = value;
            }
        }

        /// <summary>
        /// Renders the specified object context.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        public override void Render(IContext objContext, IAttributeWriter objWriter)
        {
            base.Render(objContext, objWriter);

            // Rendering grouping method
            objWriter.WriteAttributeString(WGAttributes.VisualTemplateListViewGrouping, menmListViewVisualTemplateGroupingStyleEnum.ToString());

            // Rendering the columns new order is there is any.
            if (!string.IsNullOrEmpty(mstrColumnNumberNewOrder))
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateListViewNewColumnOrder, mstrColumnNumberNewOrder);
            }

            // Rendering the required row template.
            if (menmListViewVisualTemplateRowTemplateEnum == ListViewVisualTemplateRowTemplateEnum.Custom)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateListViewItemRowTemplate, ListViewVisualTemplateRowCustomStyleName);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateListViewItemRowTemplate, menmListViewVisualTemplateRowTemplateEnum.ToString());
            }
        }

        /// <summary>
        /// Gets or sets the column number new order.
        /// </summary>
        /// <value>
        /// The column number new order.
        /// </value>
        [WebEditor(typeof(VisualTemplateListViewColumnOrderEditor), typeof(WebUITypeEditor))]
        [Editor(typeof(VisualTemplateListViewColumnOrderEditor), typeof(WebUITypeEditor))]
#if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [DisplayName("Columns order")]
        [Description("The order of the columns. Used together with row templates to determine the items position.")]
        public string ColumnNumberNewOrder
        {
            get
            {
                return this.mstrColumnNumberNewOrder;
            }
            set
            {
                this.mstrColumnNumberNewOrder = value;
            }
        }

        /// <summary>
        /// Gets the name of the visual template.
        /// </summary>
        /// <value>
        /// The name of the visual template.
        /// </value>
        public override string VisualTemplateName
        {
            get
            {
                return "ListViewVisualTemplate";
            }
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        public override Common.Resources.ResourceHandle VisualizerImage
        {
            get
            {
                return new SkinResourceHandle(typeof(ListViewVisualTemplateSkin), "ContactListWithGrouping.png"); ;
            }
        }

        /// <summary>
        /// Gets or sets the name of the ListView visual template row custom style.
        /// </summary>
        /// <value>
        /// The name of the ListView visual template row custom style.
        /// </value>
        [DisplayName("Custom template")]
        [Description("The name of a custom row template. To insert a custom template, choose \"Custom\" under \"Row template\". Don't forget to set the columns order as well.")]
        public virtual string ListViewVisualTemplateRowCustomStyleName
        {
            get
            {
                return mstrListViewVisualTemplateRowCustomStyleName;
            }
            set
            {
                mstrListViewVisualTemplateRowCustomStyleName = value;
            }
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Customizable Display";
        }


        /// <summary>
        /// Gets the default visual template for a given control.
        /// </summary>
        /// <param name="objControl">The object control.</param>
        /// <returns></returns>
        public override VisualTemplate GetDefault(Control objControl)
        {
            ListView objListView = objControl as ListView;

            if (objListView != null)
            {
                // Setting default parameters to a new ListViewVisualTempalte
                ListViewVisualTemplate objDefaultVisualTemplate = new ListViewVisualTemplate();

                // Set the default grouping
                objDefaultVisualTemplate.ListViewVisualTemplateGroupingStyle = ListViewVisualTemplateGroupingStyleEnum.AlphabetGrouping;

                // Setting default columns rows
                StringBuilder objSortedColumns = new StringBuilder();
                List<ColumnHeader> objListOfUsedColumns = new List<ColumnHeader>();
                foreach (ColumnHeader objColumnHeader in objListView.SortingColumns)
                {
                    if (objColumnHeader.Type == ListViewColumnType.Number || objColumnHeader.Type == ListViewColumnType.Text || objColumnHeader.Type == ListViewColumnType.Date)
                    {
                        objSortedColumns.Append(string.Format("{0}|", objColumnHeader.Index));
                        objListOfUsedColumns.Add(objColumnHeader);
                    }
                }

                foreach (ColumnHeader objColumnHeader in objListView.Columns)
                {
                    if (!objListOfUsedColumns.Contains(objColumnHeader))
                    {
                        if (objColumnHeader.Type == ListViewColumnType.Number || objColumnHeader.Type == ListViewColumnType.Text || objColumnHeader.Type == ListViewColumnType.Date)
                        {
                            objSortedColumns.Append(string.Format("{0}|", objColumnHeader.Index));
                        }
                    }
                }

                objDefaultVisualTemplate.ColumnNumberNewOrder = objSortedColumns.ToString().Trim('|');

                // Setting the custom style
                objDefaultVisualTemplate.ListViewVisualTemplateRowTemplate = ListViewVisualTemplateRowTemplateEnum.ContactList;

                return objDefaultVisualTemplate;
            }

            return null;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal override string ConvertToString()
        {
            string strNewOrderColumn = (mstrColumnNumberNewOrder == null) ? string.Empty : mstrColumnNumberNewOrder.Replace('|', '~');
            string strRowCustomStyleName = (mstrListViewVisualTemplateRowCustomStyleName == null) ? string.Empty : mstrListViewVisualTemplateRowCustomStyleName;
            return string.Format("{0}|{1}|{2}|{3}|{4}", base.ConvertToString(), (int)menmListViewVisualTemplateGroupingStyleEnum, (int)menmListViewVisualTemplateRowTemplateEnum, strRowCustomStyleName, strNewOrderColumn);
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal override void ConvertFromString(List<string> objVisualTemplateValues)
        {
            int intListViewVisualTemplateGroupingStyleEnum = 0;
            int intListViewVisualTemplateRowTemplateEnum = 0;
            if (objVisualTemplateValues.Count == 4 && int.TryParse(objVisualTemplateValues[0], out intListViewVisualTemplateGroupingStyleEnum) && int.TryParse(objVisualTemplateValues[1], out intListViewVisualTemplateRowTemplateEnum))
            {
                if (Enum.IsDefined(typeof(ListViewVisualTemplateGroupingStyleEnum), intListViewVisualTemplateGroupingStyleEnum))
                {
                    this.menmListViewVisualTemplateGroupingStyleEnum = (ListViewVisualTemplateGroupingStyleEnum)intListViewVisualTemplateGroupingStyleEnum;
                }

                if (Enum.IsDefined(typeof(ListViewVisualTemplateRowTemplateEnum), intListViewVisualTemplateRowTemplateEnum))
                {
                    this.menmListViewVisualTemplateRowTemplateEnum = (ListViewVisualTemplateRowTemplateEnum)intListViewVisualTemplateRowTemplateEnum;
                }

                if (!string.IsNullOrEmpty(objVisualTemplateValues[2]))
                {
                    this.mstrListViewVisualTemplateRowCustomStyleName = objVisualTemplateValues[2];
                }
                else
                {
                    this.mstrListViewVisualTemplateRowCustomStyleName = string.Empty;
                }

                if (!string.IsNullOrEmpty(objVisualTemplateValues[3]))
                {
                    this.mstrColumnNumberNewOrder = objVisualTemplateValues[3].Replace('~', '|');
                }
                else
                {
                    this.mstrColumnNumberNewOrder = string.Empty;
                }
            }
        }

    }
}
