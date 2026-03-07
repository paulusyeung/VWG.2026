using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [VisualTemplate(typeof(TreeView), "Visually adjusts the TreeView control to an appearance more suitable for the customized device.")]
    [Skin(typeof(TreeViewVisualTemplateSkin))]
    [Serializable()]
    public class TreeViewVisualTemplate : VisualTemplate
    {
        private bool mblnUseTreeViewOriginalFont;
        private int mintItemHeight = 0;
        private int mintBackButtonHeight = 0;
        private int? mintCalculatedItemHeight;
        private string mstrDefaultBackButtonText = "Back";

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewVisualTemplate"/> class.
        /// </summary>
        public TreeViewVisualTemplate()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewVisualTemplate" /> class.
        /// </summary>
        /// <param name="blnUseTreeViewOriginalFont">if set to <c>true</c> [BLN use TreeView original font].</param>
        public TreeViewVisualTemplate(bool blnUseTreeViewOriginalFont, int intItemHeight, int intBackButtonHeight, string strDefaultBackButtonText)
        {
            mblnUseTreeViewOriginalFont = blnUseTreeViewOriginalFont;
            mintItemHeight = intItemHeight;
            mintBackButtonHeight = intBackButtonHeight;
            mstrDefaultBackButtonText = strDefaultBackButtonText;
        }

        /// <summary>
        /// Renders the specified object context.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        public override void Render(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.Render(objContext, objWriter);

            objWriter.WriteAttributeString(WGAttributes.VisualTemplateUseOriginalFont, (this.mblnUseTreeViewOriginalFont) ? "1" : "0");

            if (mintItemHeight > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateTreeViewItemHeight, mintItemHeight);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateTreeViewItemHeight, GetCalculatedNodeHeight());
            }

            if (mintBackButtonHeight > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateTreeViewBackButtonHeight, mintBackButtonHeight);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.VisualTemplateTreeViewBackButtonHeight, GetCalculatedNodeHeight());
            }

            objWriter.WriteAttributeString(WGAttributes.VisualTemplateTreeViewBackButtonText, (string.IsNullOrEmpty(this.mstrDefaultBackButtonText)) ? "" : this.mstrDefaultBackButtonText);
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
                return "TreeViewVisualTemplateWithPaging";
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
                return new SkinResourceHandle(typeof(TreeViewVisualTemplateSkin), "TreeViewVisualTemplate_Paging.png"); ;
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
            return "Paged TreeView";
        }


        /// <summary>
        /// Gets or sets a value indicating whether [use TreeView font].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use TreeView font]; otherwise, <c>false</c>.
        /// </value>
        [DisplayName("Use Original Font")]
        [Description("This will set the font of the treeview as the original font, avoiding the visualtemplate style.")]
        public bool UseTreeViewOriginalFont
        {
            get
            {
                return this.mblnUseTreeViewOriginalFont;
            }
            set
            {
                this.mblnUseTreeViewOriginalFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>
        /// The height of the item.
        /// </value>        
        public int ItemHeight
        {
            get
            {
                return this.mintItemHeight;
            }
            set
            {
                this.mintItemHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the back button.
        /// </summary>
        /// <value>
        /// The height of the back button.
        /// </value>
        public int BackButtonHeight
        {
            get
            {
                return this.mintBackButtonHeight;
            }
            set
            {
                this.mintBackButtonHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the default back button text.
        /// </summary>
        /// <value>
        /// The default back button text.
        /// </value>
        public string DefaultBackButtonText
        {
            get
            {
                return this.mstrDefaultBackButtonText;
            }
            set
            {
                this.mstrDefaultBackButtonText = value;
            }
        }


        /// <summary>
        /// Gets the calculated height of the node.
        /// </summary>
        /// <returns></returns>
        private int GetCalculatedNodeHeight()
        {
            if (!mintCalculatedItemHeight.HasValue)
            {
                TreeViewVisualTemplateSkin objTreeViewVisualTemplateSkin = SkinFactory.GetSkin(this) as TreeViewVisualTemplateSkin;
                int intImageHeight = objTreeViewVisualTemplateSkin.GetImageHeight(objTreeViewVisualTemplateSkin.TreeViewVisualTemplateNextLTR, 0);

                int intFontHeight = 0;

                //Set the default padding fix
                int intHeigtFixConstant = 4;
                if (objTreeViewVisualTemplateSkin.TreeNodeNormalStyle.Font != null)
                {
                    Bitmap objMeasurementBitmap = new Bitmap(1, 1);
                    Graphics objMeasurementGraphics = Graphics.FromImage(objMeasurementBitmap);
                    intFontHeight = (int)Math.Ceiling((double)objTreeViewVisualTemplateSkin.TreeNodeNormalStyle.Font.GetHeight(objMeasurementGraphics)) + intHeigtFixConstant;
                }

                mintCalculatedItemHeight = Math.Max(Math.Max(intImageHeight, intFontHeight), objTreeViewVisualTemplateSkin.TreeViewNodeHeight);
            }

            return mintCalculatedItemHeight.Value;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal override string ConvertToString()
        {
            string strUseOriginalFont = (mblnUseTreeViewOriginalFont) ? "1" : "0";            
            return string.Format("{0}|{1}|{2}|{3}|{4}", base.ConvertToString(), strUseOriginalFont, this.mintItemHeight, this.mintBackButtonHeight, this.mstrDefaultBackButtonText);
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal override void ConvertFromString(List<string> objVisualTemplateValues)
        {
            if (objVisualTemplateValues.Count == 4)
            {
                mblnUseTreeViewOriginalFont = (!string.IsNullOrEmpty(objVisualTemplateValues[0]) && objVisualTemplateValues[0] == "1") ? true : false;
                int.TryParse(objVisualTemplateValues[1], out this.mintItemHeight);
                int.TryParse(objVisualTemplateValues[2], out this.mintBackButtonHeight);
                this.mstrDefaultBackButtonText = objVisualTemplateValues[3];
            }
        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeContevert)
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override object[] GetConsturctorArguments()
        {
            return new object[4] { mblnUseTreeViewOriginalFont, mintItemHeight, mintBackButtonHeight, mstrDefaultBackButtonText };
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeContevert)
        /// </summary>
        public override Type[] GetConstructorTypes()
        {
            return new Type[4] { typeof(bool), typeof(int), typeof(int), typeof(string) };
        }
    }
}