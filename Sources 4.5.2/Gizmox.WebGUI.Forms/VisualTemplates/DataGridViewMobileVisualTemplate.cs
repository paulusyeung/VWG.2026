using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [VisualTemplate(typeof(DataGridView), "Visually adjusts the DataGridView control to an appearance more suitable for the customized device.")]
    [Skin(typeof(DataGridViewMobileVisualTemplateSkin))]
    [Serializable()]
    public class DataGridViewMobileVisualTemplate : VisualTemplate
    {
        private int mintNumberOfDisplayedColumns = 3;
        private string mstrNewColumnOrder = null;
        private int mintCaptionHeight = 0;
        private int? mintCalculatedCaptionHeight = null;
        private int mintBottomMenuHeight = 0;
        private int? mintCalculatedBottomMenuHeight = null;
        private List<string> mobjFilterOperators = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewVisualTemplate"/> class.
        /// </summary>
        public DataGridViewMobileVisualTemplate()
        {

        }



        /// <summary>
        /// Renders the specified object context.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        public override void Render(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.Render(objContext, objWriter);

            objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewNumberOfDisplayedColumns, this.mintNumberOfDisplayedColumns);

            if (!string.IsNullOrEmpty(mstrNewColumnOrder))
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateListViewNewColumnOrder, this.mstrNewColumnOrder);
            }

            if (this.mintCaptionHeight > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewCaptionHeight, this.mintCaptionHeight);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewCaptionHeight, GetCalculatedCaptionHeight());
            }

            if (this.mintBottomMenuHeight > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewBottomMenuHeight, this.mintBottomMenuHeight);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewBottomMenuHeight, GetCalculatedBottomMenuHeight());
            }

            if (this.mobjFilterOperators != null)
            {
                StringBuilder objBuilder = new StringBuilder();

                foreach (string objFilterOperator in mobjFilterOperators)
                {
                    objBuilder.Append(objFilterOperator);
                }

                objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewDataPagesFilterOptions, objBuilder.ToString().Trim('|'));
            }


            objWriter.WriteAttributeString(WGAttributes.VisualTemplateDataGridViewDataPagesRowHeight, GetCalculatedBottomMenuHeight());
        }

        /// <summary>
        /// Gets the calculated height of the node.
        /// </summary>
        /// <returns></returns>
        private int GetCalculatedCaptionHeight()
        {
            if (!mintCalculatedCaptionHeight.HasValue)
            {
                DataGridViewMobileVisualTemplateSkin objDataGridViewMobileVisualTemplateSkin = SkinFactory.GetSkin(this) as DataGridViewMobileVisualTemplateSkin;
                mintCalculatedCaptionHeight = objDataGridViewMobileVisualTemplateSkin.CaptionHeight;
            }

            return mintCalculatedCaptionHeight.Value;
        }

        /// <summary>
        /// Gets the calculated height of the node.
        /// </summary>
        /// <returns></returns>
        private int GetCalculatedBottomMenuHeight()
        {
            if (!mintCalculatedBottomMenuHeight.HasValue)
            {
                DataGridViewMobileVisualTemplateSkin objDataGridViewMobileVisualTemplateSkin = SkinFactory.GetSkin(this) as DataGridViewMobileVisualTemplateSkin;
                mintCalculatedBottomMenuHeight = objDataGridViewMobileVisualTemplateSkin.BottomMenuHeight;
            }

            return mintCalculatedBottomMenuHeight.Value;
        }


        /// <summary>
        /// Gets or sets the new column order.
        /// </summary>
        /// <value>
        /// The new column order.
        /// </value>
        public string NewColumnOrder
        {
            get
            {
                return mstrNewColumnOrder;
            }
            set
            {
                this.mstrNewColumnOrder = value;
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
                return "DataGridViewVisualTemplateForMobile";
            }
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        public override ResourceHandle VisualizerImage
        {
            get
            {
                return new SkinResourceHandle(typeof(TreeViewVisualTemplateSkin), "DataGridViewVisualTemplate_Mobile.png"); ;
            }
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objControl"></param>
        /// <param name="objEvent">The object event.</param>
        protected internal override void FireEvent(Control objControl, Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objControl, objEvent);

            DataGridView objDataGridView = objControl as DataGridView;

            if (objDataGridView != null)
            {
                string strEventAction = objEvent["EventAction"];

                if (!string.IsNullOrEmpty(strEventAction))
                {
                    string strMember = objEvent.Member;
                    Point objMemberPosition = objDataGridView.GetMemberPosition(strMember);

                    switch (strEventAction)
                    {


                        case "ShowFilterOptions":
                            if (objMemberPosition.X != -1)
                            {
                                DataGridViewFilterRow objFilterRow = objDataGridView.FilterRow;
                                DataGridViewFilterCell objFilterCell = objFilterRow.Cells[objMemberPosition.X] as DataGridViewFilterCell;

                                if (objFilterCell != null)
                                {
                                    List<FilterComparisonOperator> objFilterOperators = Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(objFilterCell.OwningColumn.ValueType);
                                    mobjFilterOperators = new List<string>();

                                    foreach (FilterComparisonOperator objOperator in objFilterOperators)
                                    {
                                        mobjFilterOperators.Add(string.Format("{0}|{1}|", SR.GetString(string.Format("FilterComparisionOperator_{0}", objOperator.ToString())), Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(objDataGridView, objOperator)));
                                    }
                                }
                            }

                            //objDataGridView.UpdateParams(AttributeType.Visual);

                            break;
                        case "SetFilterOption":
                            if (objMemberPosition.X != -1)
                            {
                                // Get the list again
                                DataGridViewFilterRow objFilterRow = objDataGridView.FilterRow;
                                DataGridViewFilterCell objFilterCell = objFilterRow.Cells[objMemberPosition.X] as DataGridViewFilterCell;

                                List<FilterComparisonOperator> objFilterOperators = Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(objFilterCell.OwningColumn.ValueType);

                                // Get the selected value (index)
                                string strFunctionIndex = objEvent[WGAttributes.Value];

                                int intIndex;
                                if (int.TryParse(strFunctionIndex, out intIndex))
                                {
                                    // Check for index validity
                                    if (intIndex < objFilterOperators.Count)
                                    {
                                        // Setting the filter.
                                        ResourceHandle objImageHandle = Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(objDataGridView, objFilterOperators[intIndex]);
                                        Gizmox.WebGUI.Forms.DataGridViewFilterCell.DataGridViewFilterControl objFilterControl = objFilterCell.DataGridViewFilterControlObject;
                                        objFilterControl.SetOperator(objFilterOperators[intIndex], objImageHandle);
                                        objFilterControl.FireFilterChanged(false);
                                    }
                                }
                            }
                            break;
                        case "AddGroup":
                            // Get the column data property name.
                            string strColumnDataPropertyName = objEvent[WGAttributes.Name];

                            // Insert new group into GroupingColumns.
                            if (!string.IsNullOrEmpty(strColumnDataPropertyName))
                            {
                                objDataGridView.InsertGroupingColumn(string.Empty, strColumnDataPropertyName);

                                // Raise GroupingChanged if needed.
                                objDataGridView.OnGroupingChanged(DataGridViewGroupingAction.Add, strColumnDataPropertyName);
                            }
                            break;
                    }
                }
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
            return "Mobile DataGridView";
        }




        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal override string ConvertToString()
        {
            return string.Empty;
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal override void ConvertFromString(List<string> objVisualTemplateValues)
        {

        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeContevert)
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override object[] GetConsturctorArguments()
        {
            return new object[1];
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeContevert)
        /// </summary>
        public override Type[] GetConstructorTypes()
        {
            return new Type[1];
        }       
    }
}