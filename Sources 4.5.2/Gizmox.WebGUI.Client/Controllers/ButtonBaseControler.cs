#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
    #region ButtonBaseControler Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>

    public class ButtonBaseControler : ControlController
    {
        #region Class Members


        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ButtonBaseControler(IContext objContext, object objWebButtonBase, object objWinButtonBase)
            : base(objContext, objWebButtonBase, objWinButtonBase)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objWebTreeView"></param>
        /// <param name="objWinTreeView"></param>
        public ButtonBaseControler(IContext objContext, object objWebButtonBase)
            : base(objContext, objWebButtonBase)
        {
        }


        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        ///
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinButtonBaseTextImageRelation();
            SetWinButtonBaseImage();
            SetWinButtonBaseImageIndex();
            SetWinButtonBaseImageKey();
            SetWinButtonBaseImageAlign();
            SetWinButtonBaseUseVisualStyleBackColor();
            SetWinButtonBaseTextAlign();            
        }

        /// <summary>
        /// Sets the win button base use visual style back property.
        /// </summary>
        private void SetWinButtonBaseTextAlign()
        {
            this.WinButtonBase.TextAlign = WebButtonBase.TextAlign;
        }

        /// <summary>
        /// Sets the web button base use visual style back property.
        /// </summary>
        private void SetWebButtonBaseUseVisualStyleBackColor()
        {
            this.WebButtonBase.UseVisualStyleBackColor = WinButtonBase.UseVisualStyleBackColor;
        }

        /// <summary>
        /// Sets the win button base use visual style back property.
        /// </summary>
        private void SetWinButtonBaseUseVisualStyleBackColor()
        {
            this.WinButtonBase.UseVisualStyleBackColor = WebButtonBase.UseVisualStyleBackColor;
        }

        /// <summary>
        /// Sets the win button base text image relation.
        /// </summary>
        protected virtual void SetWinButtonBaseTextImageRelation()
        {
            this.WinButtonBase.TextImageRelation = (WinForms.TextImageRelation)GetConvertedEnum(typeof(WinForms.TextImageRelation), this.WebButtonBase.TextImageRelation);
        }

        /// <summary>
        /// Sets the win button base image align.
        /// </summary>
        protected virtual void SetWinButtonBaseImageAlign()
        {
            this.WinButtonBase.ImageAlign = (System.Drawing.ContentAlignment)GetConvertedEnum(typeof(System.Drawing.ContentAlignment), this.WebButtonBase.ImageAlign);
        }

        /// <summary>
        /// Sets the index of the win button base image.
        /// </summary>
        protected virtual void SetWinButtonBaseImageIndex()
        {
            if (this.WebButtonBase.ImageIndex != -1)
            {
                if (this.WinButtonBase.ImageList == null)
                {
                    this.WinButtonBase.ImageList = new WinForms.ImageList();
                }
                this.WinButtonBase.ImageIndex = this.GetWinImageIndex(this.WinButtonBase.ImageList, this.WebButtonBase.Image);
}
            else
            {
                if (this.WinButtonBase.ImageIndex != -1)
                {
                    this.WinButtonBase.ImageIndex = -1;
                }
            }
        }

        /// <summary>
        /// Sets the win button base image key.
        /// </summary>
        protected virtual void SetWinButtonBaseImageKey()
        {
            if (this.WebButtonBase.ImageKey != string.Empty)
            {
                if (this.WinButtonBase.ImageList == null)
                {
                    this.WinButtonBase.ImageList = new WinForms.ImageList();
                }

                if (this.GetWinImageIndex(this.WinButtonBase.ImageList, this.WebButtonBase.Image, this.WebButtonBase.ImageKey)>-1)
                {
                    this.WinButtonBase.ImageKey = this.WebButtonBase.ImageKey;
                }
            }
            else
            {
                if (this.WinButtonBase.ImageKey != string.Empty)
                {
                    this.WinButtonBase.ImageKey = string.Empty;
                }
            }
        }

        /// <summary>
        /// Sets the win button base image.
        /// </summary>
        protected virtual void SetWinButtonBaseImage()
        {
            if (WebButtonBase.Image != null)
            {
                // Convert the image from Gizmox resource handler to a System.Drawing Image
                this.WinButtonBase.Image = GetWinImageFromResourceHandle(this.WebButtonBase.Image);
            }
            else if (this.WinButtonBase.Image != null)
            {
                this.WinButtonBase.Image = null;
            }
        }

                

        #region Events

        /// <summary>
        ///
        /// </summary>
        /// <param name="strProperty"></param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Image":
                    SetWinButtonBaseImage();
                    break;
                case "ImageIndex":
                    SetWinButtonBaseImageIndex();
                    break;
                case "ImageKey":
                    SetWinButtonBaseImageKey();
                    break;
                case "TextImageRelation":
                    SetWinButtonBaseTextImageRelation();
                    break;
                case "ImageAlign":
                    SetWinButtonBaseImageAlign();
                    break;
                case "UseVisualStyleBackColor":
                    SetWinButtonBaseUseVisualStyleBackColor();
                    break;
                case "TextAlign":
                    SetWinButtonBaseTextAlign();
                    break;
            }
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "UseVisualStyleBackColor":
                    SetWebButtonBaseUseVisualStyleBackColor();
                    break;
            }
        }


        #endregion Events

        #endregion Methods

        #region Properties

        /// <summary>
        ///
        /// </summary>
        public WebForms.ButtonBase WebButtonBase
        {
            get
            {
                return base.SourceObject as WebForms.ButtonBase;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public WinForms.ButtonBase WinButtonBase
        {
            get
            {
                return base.TargetObject as WinForms.ButtonBase;
            }
        }


        #endregion Properties

    }

    #endregion RadioButtonController Class

}
