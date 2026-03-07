using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class GroupingAreaStyleProperties
    {
        #region Fields (1)

        private DataGridView mobjDataGridView = null;
        private DataGridViewSkin mobjSkin = null;

        #endregion Fields

        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingAreaStyleProperties"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        public GroupingAreaStyleProperties(DataGridView objDataGridView)
        {
            mobjDataGridView = objDataGridView;
            mobjSkin = SkinFactory.GetSkin(mobjDataGridView) as DataGridViewSkin;
        }

        #endregion Constructors

        #region Properties (7)

        /// <summary>
        /// Gets or sets the height of the grouping area.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        [Category("Appearance"), Description("Background height of data grid view grouping area.")]
        public int Height
        {
            get
            {
                return mobjDataGridView.GroupingAreaHeight;
            }
            set
            {
                mobjDataGridView.GroupingAreaHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the backcolor of the grouping area.
        /// </summary>
        /// <value>
        /// The backcolor of the grouping area.
        /// </value>        
        [Category("Appearance"), Description("Background color of data grid view grouping area.")]
        public Color BackColor
        {
            get
            {
                return mobjDataGridView.GroupingAreaBackColor;
            }

            set
            {
                mobjDataGridView.GroupingAreaBackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>
        /// The background image.
        /// </value>
        [Category("Appearance"), Description("Background image of data grid view grouping area."), DefaultValue(null)]
        public ResourceHandle BackgroundImage
        {
            get
            {
                return mobjDataGridView.GroupingAreaBackgroundImage;
            }

            set
            {
                mobjDataGridView.GroupingAreaBackgroundImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image position.
        /// </summary>
        /// <value>
        /// The background image position.
        /// </value>
        [DefaultValue(BackgroundImagePosition.MiddleCenter), Category("Appearance"), Description("Position of data grid view grouping area background image.")]
        public BackgroundImagePosition BackgroundImagePosition
        {
            get
            {
                return mobjDataGridView.GroupingAreaBackgroundImagePosition;
            }

            set
            {
                mobjDataGridView.GroupingAreaBackgroundImagePosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image repeat.
        /// </summary>
        /// <value>
        /// The background image repeat.
        /// </value>
        [DefaultValue(BackgroundImageRepeat.Repeat), Category("Appearance"), Description("Repeat style of data grid view grouping area background image.")]
        public BackgroundImageRepeat BackgroundImageRepeat
        {
            get
            {
                return mobjDataGridView.GroupingAreaBackgroundImageRepeat;
            }

            set
            {
                mobjDataGridView.GroupingAreaBackgroundImageRepeat = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>
        /// The color of the border.
        /// </value>        
        [Category("Appearance"), Description("Border color of data grid view grouping area.")]
        public BorderColor BorderColor
        {
            get
            {
                return mobjDataGridView.GroupingAreaBorderColor;
            }

            set
            {
                mobjDataGridView.GroupingAreaBorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>
        /// The border style.
        /// </value>        
        [Category("Appearance"), Description("Border style of data grid view grouping area.")]
        public BorderStyle BorderStyle
        {
            get
            {
                return mobjDataGridView.GroupingAreaBorderStyle;
            }

            set
            {
                mobjDataGridView.GroupingAreaBorderStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>
        /// The width of the border.
        /// </value>       
        [Category("Appearance"), Description("Border width of data grid view grouping area.")]
        public BorderWidth BorderWidth
        {
            get
            {
                return mobjDataGridView.GroupingAreaBorderWidth;
            }

            set
            {
                mobjDataGridView.GroupingAreaBorderWidth = value;
            }
        }

        #endregion Properties

        #region Methods (5)

        // Public Methods (1) 

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Empty;
        }
        // Private Methods (4) 

        /// <summary>
        /// Determines whether to serialize the backcolor of grouping area.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBackColor()
        {
            DataGridViewSkin objSkin = SkinFactory.GetSkin(mobjDataGridView) as DataGridViewSkin;

            if (objSkin != null)
            {
                return BackColor != objSkin.GroupingDropAreaStyle.BackColor;
            }

            return false;
        }

        /// <summary>
        /// Determines whether to serialize the border color of grouping area.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderColor()
        {
            if (mobjSkin != null)
            {
                return BorderColor != mobjSkin.GroupingDropAreaStyle.BorderColor;
            }

            return false;
        }

        /// <summary>
        ///  Determines whether to serialize the border style of grouping area.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderStyle()
        {
            if (mobjSkin != null)
            {
                return BorderStyle != mobjSkin.GroupingDropAreaStyle.BorderStyle;
            }

            return false;
        }

        /// <summary>
        ///  Determines whether to serialize the border width of grouping area.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderWidth()
        {
            if (mobjSkin != null)
            {
                return BorderWidth != mobjSkin.GroupingDropAreaStyle.BorderWidth;
            }

            return false;
        }

        /// <summary>
        /// Determines whether to serialize the height of grouping area.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeHeight()
        {
            if (mobjSkin != null)
            {
                return Height != mobjSkin.DropAreaHeight;
            }

            return false;
        }

        #endregion Methods
    }
}
