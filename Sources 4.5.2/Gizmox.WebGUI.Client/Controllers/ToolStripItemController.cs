#region Using

using System;
using System.Text;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using 

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ToolStripItemController : ComponentController
    {
        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebToolStripItem">The web tool strip item.</param>
        /// <param name="objWinToolStripItem">The win tool strip item.</param>
		public ToolStripItemController(IContext objContext,object objWebToolStripItem,object objWinToolStripItem) : base(objContext,objWebToolStripItem,objWinToolStripItem)
		{
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemController"/> class.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWebToolStripItem">The web tool strip.</param>
        public ToolStripItemController(IContext objContext, object objWebToolStripItem) : base(objContext, objWebToolStripItem)
		{
        }		
		
		#endregion C'Tor/D'Tor

        #region Class Members


        #endregion Class Members

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ToolStripItem WebToolStripItem
        {
            get
            {
                return base.SourceObject as WebForms.ToolStripItem;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ToolStripItem WinToolStripItem
        {
            get
            {
                return base.TargetObject as WinForms.ToolStripItem;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generic create winforms control
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "AutoSize":
                    this.SetWinToolStripItemAutoSize();
                    break;
                case "Alignment":
                    this.SetWinToolStripItemAlignment();
                    break;
                case "Anchor":
                    this.SetWinToolStripItemAnchor();
                    break;
                case "Available":
                    this.SetWinToolStripItemAvailable();
                    break;
                case "BackColor":
                    this.SetWinToolStripItemBackColor();
                    break;
                case "BackgroundImage":
                    this.SetWinToolStripItemBackgroundImage();
                    break;
                case "BackgroundImageLayout":
                    this.SetWinToolStripItemBackgroundImageLayout();
                    break;
                case "DisplayStyle":
                    this.SetWinToolStripItemDisplayStyle();
                    break;
                case "Dock":
                    this.SetWinToolStripItemDock();
                    break;
                case "Enabled":
                    this.SetWinToolStripItemEnabled();
                    break;
                case "Font":
                    this.SetWinToolStripItemFont();
                    break;
                case "ForeColor":
                    this.SetWinToolStripItemForeColor();
                    break;
                case "Height":
                    this.SetWinToolStripItemHeight();
                    break;
                case "Image":
                    this.SetWinToolStripItemImage();
                    break;
                case "ImageAlign":
                    this.SetWinToolStripItemImageAlign();
                    break;
                case "ImageIndex":
                    this.SetWinToolStripItemImageIndex();
                    break;
                case "ImageKey":
                    this.SetWinToolStripItemImageKey();
                    break;
                case "ImageScaling":
                    this.SetWinToolStripItemImageScaling();
                    break;
                case "MergeAction":
                    this.SetWinToolStripItemMergeAction();
                    break;
                case "MergeIndex":
                    this.SetWinToolStripItemMergeIndex();
                    break;
                case "Name":
                    this.SetWinToolStripItemName();
                    break;
                case "Padding":
                    this.SetWinToolStripItemPadding();
                    break;
                case "RightToLeft":
                    this.SetWinToolStripItemRightToLeft();
                    break;
                case "RightToLeftAutoMirrorImage":
                    this.SetWinToolStripItemRightToLeftAutoMirrorImage();
                    break;
                case "Size":
                    this.SetWinToolStripItemSize();
                    break;
                case "Text":
                    this.SetWinToolStripItemText();
                    break;
                case "TextAlign":
                    this.SetWinToolStripItemTextAlign();
                    break;
                case "TextDirection":
                    this.SetWinToolStripItemTextDirection();
                    break;
                case "TextImageRelation":
                    this.SetWinToolStripItemTextImageRelation();
                    break;
                case "ToolTipText":
                    this.SetWinToolStripItemToolTipText();
                    break;
                case "Width":
                    this.SetWinToolStripItemWidth();
                    break;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    this.SetWebToolStripItemText();
                    break;
            }
        }

        /// <summary>
        /// Loads properties after component is assigned to its parent
        /// </summary>
        protected override void LoadController()
        {
            base.LoadController();

            this.SetWebToolStripItemName();
        }

        /// <summary>
        /// Sets the web tool strip item text.
        /// </summary>
        private void SetWebToolStripItemText()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WebToolStripItem.Text = this.WinToolStripItem.Text;
            }
        }

        /// <summary>
        /// Sets the name of the web tool strip item.
        /// </summary>
        private void SetWebToolStripItemName()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WebToolStripItem.Name = this.WinToolStripItem.Name;
            }
        }

        /// <summary>
        /// Initializes the controller
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinToolStripItemAutoSize();
            this.SetWinToolStripItemAlignment();
            this.SetWinToolStripItemAnchor();
            this.SetWinToolStripItemAvailable();
            this.SetWinToolStripItemBackColor();
            this.SetWinToolStripItemBackgroundImage();
            this.SetWinToolStripItemBackgroundImageLayout();
            this.SetWinToolStripItemDisplayStyle();
            this.SetWinToolStripItemDock();
            this.SetWinToolStripItemEnabled();
            this.SetWinToolStripItemFont();
            this.SetWinToolStripItemForeColor();
            this.SetWinToolStripItemImageAlign();
            this.SetWinToolStripItemImageIndex();
            this.SetWinToolStripItemImageKey();
            this.SetWinToolStripItemImageScaling();
            this.SetWinToolStripItemImage(); // When initializing the Image property must be after The ImageIndex and ImageKey properties because they remove the image.
            this.SetWinToolStripItemMergeAction();
            this.SetWinToolStripItemMergeIndex();
            this.SetWinToolStripItemName();
            this.SetWinToolStripItemPadding();
            this.SetWinToolStripItemRightToLeft();
            this.SetWinToolStripItemRightToLeftAutoMirrorImage();
            this.SetWinToolStripItemSize();
            this.SetWinToolStripItemText();
            this.SetWinToolStripItemTextAlign();
            this.SetWinToolStripItemTextDirection();
            this.SetWinToolStripItemTextImageRelation();
            this.SetWinToolStripItemToolTipText();
            this.InitializeWinToolStripItemVisiblity();
        }

        /// <summary>
        /// Sets the size of the win tool strip item auto.
        /// </summary>
        protected virtual void SetWinToolStripItemAutoSize()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.AutoSize = this.WebToolStripItem.AutoSize;
            }
        }

        /// <summary>
        /// Sets the win tool strip item alignment.
        /// </summary>
        protected virtual void SetWinToolStripItemAlignment()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Alignment = (WinForms.ToolStripItemAlignment)this.GetConvertedEnum(typeof(WinForms.ToolStripItemAlignment), this.WebToolStripItem.Alignment);
            }
        }

        /// <summary>
        /// Sets the win tool strip item anchor.
        /// </summary>
        protected virtual void SetWinToolStripItemAnchor()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Anchor = (WinForms.AnchorStyles)this.GetConvertedEnum(typeof(WinForms.AnchorStyles), this.WebToolStripItem.Anchor);
            }
        }

        /// <summary>
        /// Sets the win tool strip item available.
        /// </summary>
        protected virtual void SetWinToolStripItemAvailable()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Available = this.WebToolStripItem.Available;
            }
        }

        /// <summary>
        /// Sets the color of the win tool strip item back.
        /// </summary>
        protected virtual void SetWinToolStripItemBackColor()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                if (this.WebToolStripItem.BackColor != Color.Transparent)
                {
                    this.WinToolStripItem.BackColor = this.WebToolStripItem.BackColor;
                }
            }
        }

        /// <summary>
        /// Sets the win tool strip item background image.
        /// </summary>
        protected virtual void SetWinToolStripItemBackgroundImage()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.BackgroundImage = this.GetWinImageFromResourceHandle(this.WebToolStripItem.BackgroundImage);
            }
        }

        /// <summary>
        /// Sets the win tool strip item background image layout.
        /// </summary>
        protected virtual void SetWinToolStripItemBackgroundImageLayout()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.BackgroundImageLayout = (WinForms.ImageLayout)this.GetConvertedEnum(typeof(WinForms.ImageLayout), this.WebToolStripItem.BackgroundImageLayout);
            }
        }

        /// <summary>
        /// Sets the win tool strip item display style.
        /// </summary>
        protected virtual void SetWinToolStripItemDisplayStyle()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.DisplayStyle = (WinForms.ToolStripItemDisplayStyle)this.GetConvertedEnum(typeof(WinForms.ToolStripItemDisplayStyle), this.WebToolStripItem.DisplayStyle);
            }
        }

        /// <summary>
        /// Sets the win tool strip item dock.
        /// </summary>
        protected virtual void SetWinToolStripItemDock()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Dock = (WinForms.DockStyle)this.GetConvertedEnum(typeof(WinForms.DockStyle), this.WebToolStripItem.Dock);
            }
        }

        /// <summary>
        /// Sets the win tool strip item enabled.
        /// </summary>
        protected virtual void SetWinToolStripItemEnabled()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Enabled = this.WebToolStripItem.Enabled;
            }
        }

        /// <summary>
        /// Sets the win tool strip item font.
        /// </summary>
        protected virtual void SetWinToolStripItemFont()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                if (this.WebToolStripItem.Font == null)
                {
                    this.WinToolStripItem.Font = null;
                }
                else
                this.WinToolStripItem.Font = new Font(this.WebToolStripItem.Font.FontFamily, this.WebToolStripItem.Font.Size * TargetVerticalScaleFactor);
            }
        }

        /// <summary>
        /// Sets the color of the win tool strip item fore.
        /// </summary>
        protected virtual void SetWinToolStripItemForeColor()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ForeColor = this.WebToolStripItem.ForeColor;
            }
        }

        /// <summary>
        /// Sets the height of the win tool strip item.
        /// </summary>
        protected virtual void SetWinToolStripItemHeight()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Height = Convert.ToInt32(this.WebToolStripItem.Height * TargetVerticalScaleFactor);
            }
        }

        /// <summary>
        /// Sets the win tool strip item image.
        /// </summary>
        protected virtual void SetWinToolStripItemImage()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Image = this.GetWinImageFromResourceHandle(this.WebToolStripItem.Image);
            }
        }

        /// <summary>
        /// Sets the win tool strip item image align.
        /// </summary>
        protected virtual void SetWinToolStripItemImageAlign()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ImageAlign = this.WebToolStripItem.ImageAlign;
            }
        }

        /// <summary>
        /// Sets the index of the win tool strip item image.
        /// </summary>
        protected virtual void SetWinToolStripItemImageIndex()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ImageIndex = this.WebToolStripItem.ImageIndex;
            }
        }

        /// <summary>
        /// Sets the win tool strip item image key.
        /// </summary>
        protected virtual void SetWinToolStripItemImageKey()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ImageKey = this.WebToolStripItem.ImageKey;
            }
        }

        /// <summary>
        /// Sets the win tool strip item image scaling.
        /// </summary>
        protected virtual void SetWinToolStripItemImageScaling()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ImageScaling = (WinForms.ToolStripItemImageScaling)this.GetConvertedEnum(typeof(WinForms.ToolStripItemImageScaling), this.WebToolStripItem.ImageScaling);
            }
        }

        /// <summary>
        /// Sets the win tool strip item merge action.
        /// </summary>
        protected virtual void SetWinToolStripItemMergeAction()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.MergeAction = (WinForms.MergeAction)this.GetConvertedEnum(typeof(WinForms.MergeAction), this.WebToolStripItem.MergeAction);
            }
        }

        /// <summary>
        /// Sets the index of the win tool strip item merge.
        /// </summary>
        protected virtual void SetWinToolStripItemMergeIndex()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.MergeIndex = this.WebToolStripItem.MergeIndex;
            }
        }

        /// <summary>
        /// Sets the name of the win tool strip item.
        /// </summary>
        protected virtual void SetWinToolStripItemName()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Name = this.WebToolStripItem.Name;
            }
        }

        /// <summary>
        /// Sets the win tool strip item padding.
        /// </summary>
        protected virtual void SetWinToolStripItemPadding()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                WebForms.Padding objWebPadding = this.WebToolStripItem.Padding;
                if (objWebPadding != null)
                {
                    this.WinToolStripItem.Padding = new WinForms.Padding(objWebPadding.Left, objWebPadding.Top, objWebPadding.Right, objWebPadding.Bottom);
                }
            }
        }

        /// <summary>
        /// Sets the win tool strip item right to left.
        /// </summary>
        protected virtual void SetWinToolStripItemRightToLeft()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.RightToLeft = (WinForms.RightToLeft)this.GetConvertedEnum(typeof(WinForms.RightToLeft), this.WebToolStripItem.RightToLeft);
            }
        }

        /// <summary>
        /// Sets the win tool strip item right to left auto mirror image.
        /// </summary>
        protected virtual void SetWinToolStripItemRightToLeftAutoMirrorImage()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.RightToLeftAutoMirrorImage = this.WebToolStripItem.RightToLeftAutoMirrorImage;
            }
        }

        /// <summary>
        /// Sets the size of the win tool strip item.
        /// </summary>
        protected virtual void SetWinToolStripItemSize()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                Size objWebToolStripItemSize = this.WebToolStripItem.Size;
                this.WinToolStripItem.Size = new Size(Convert.ToInt32(objWebToolStripItemSize.Width * TargetHorizontalScaleFactor), Convert.ToInt32(objWebToolStripItemSize.Height * TargetVerticalScaleFactor));
            }
        }

        /// <summary>
        /// Sets the win tool strip item text.
        /// </summary>
        protected virtual void SetWinToolStripItemText()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                if (this.WinToolStripItem.Text != this.WebToolStripItem.Text)
                {
                    this.WinToolStripItem.Text = this.WebToolStripItem.Text;
                }
            }
        }

        /// <summary>
        /// </summary>
        protected override void WireEvents()
        {
            base.WireEvents();

            this.WinToolStripItem.TextChanged += new EventHandler(WinToolStripItem_TextChanged);
        }

        /// <summary>
        /// </summary>
        protected override void UnwireEvents()
        {
            base.UnwireEvents();

            this.WinToolStripItem.TextChanged -= new EventHandler(WinToolStripItem_TextChanged);
        }

        /// <summary>
        /// Handles the TextChanged event of the WinToolStripItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinToolStripItem_TextChanged(object sender, EventArgs e)
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                if (this.WinToolStripItem.AutoSize)
                {
                    Size objWinToolStripItemSize = this.WinToolStripItem.GetPreferredSize(this.WinToolStripItem.Size);
                    this.WebToolStripItem.Size = new System.Drawing.Size(Convert.ToInt32(objWinToolStripItemSize.Width / TargetHorizontalScaleFactor), Convert.ToInt32(objWinToolStripItemSize.Height / TargetVerticalScaleFactor));
                }
            }
        }

        /// <summary>
        /// Sets the win tool strip item text align.
        /// </summary>
        protected virtual void SetWinToolStripItemTextAlign()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.TextAlign = this.WebToolStripItem.TextAlign;
            }
        }

        /// <summary>
        /// Sets the win tool strip item text direction.
        /// </summary>
        protected virtual void SetWinToolStripItemTextDirection()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.TextDirection = (WinForms.ToolStripTextDirection)this.GetConvertedEnum(typeof(WinForms.ToolStripTextDirection), this.WebToolStripItem.TextDirection);
            }
        }

        /// <summary>
        /// Sets the win tool strip item text image relation.
        /// </summary>
        protected virtual void SetWinToolStripItemTextImageRelation()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.TextImageRelation = (WinForms.TextImageRelation)this.GetConvertedEnum(typeof(WinForms.TextImageRelation), this.WebToolStripItem.TextImageRelation);
            }
        }

        /// <summary>
        /// Sets the win tool strip item tool tip text.
        /// </summary>
        protected virtual void SetWinToolStripItemToolTipText()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.ToolTipText = this.WebToolStripItem.ToolTipText;
            }
        }

        /// <summary>
        /// Initializes the win tool strip item visiblity.
        /// </summary>
        protected virtual void InitializeWinToolStripItemVisiblity()
        {
            if (this.WinToolStripItem != null)
            {
                this.WinToolStripItem.Visible = true;
            }
        }

        /// <summary>
        /// Sets the width of the win tool strip item.
        /// </summary>
        protected virtual void SetWinToolStripItemWidth()
        {
            if (this.WinToolStripItem != null && this.WebToolStripItem != null)
            {
                this.WinToolStripItem.Width = Convert.ToInt32(this.WebToolStripItem.Width * TargetHorizontalScaleFactor);
            }
        }

        #endregion
    }
}
