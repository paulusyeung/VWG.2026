#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.IO;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region LabelController Class

    /// <summary>
    /// Controls the relations between a webgui control and a winforms control
    /// </summary>
	
	public class LabelController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public LabelController(IContext objContext,object objWebLabel,object objWinLabel) :base(objContext,objWebLabel,objWinLabel)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebLabel"></param>
		/// <param name="objWinLabel"></param>
		public LabelController(IContext objContext, object objWebLabel)
		/// <summary>
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWebLabel"></param>
		: base(objContext, objWebLabel)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// </summary>
        protected override void SetWinControlBorderStyle()
        {
            if (Enum.GetName(typeof(WinForms.BorderStyle), this.WebLabel.BorderStyle) != null)
            {
                this.WinLabel.BorderStyle = (WinForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle), this.WebLabel.BorderStyle, this.WinLabel.BorderStyle);
            }
        }

        /// <summary>
        /// Sets the win label image.
        /// </summary>
        protected virtual void SetWinLabelImage()
        {
            if (WebLabel.Image != null)
            {
                // Convert the image from Gizmox resource handler to a System.Drawing Image
                WinLabel.Image = GetWinImageFromResourceHandle(this.WebLabel.Image);
            }
            else
            {
                // Empty image
                WinLabel.Image = null;
            }
        }

        /// <summary>
        /// Sets the index of the win label image.
        /// </summary>
        protected virtual void SetWinLabelImageIndex()
        {
            if (this.WebLabel.Image != null)
            {
                if (this.WinLabel.ImageList == null)
                {
                    this.WinLabel.ImageList = new WinForms.ImageList();
                }
                this.WinLabel.ImageIndex = this.GetWinImageIndex(this.WinLabel.ImageList, this.WebLabel.Image);
            }
            else
            {
                this.WinLabel.ImageIndex = -1;
            }
        }

        /// <summary>
        /// Sets the win label image key.
        /// </summary>
        protected virtual void SetWinLabelImageKey()
        {
            if (this.WebLabel.Image != null)
            {
                if (this.WinLabel.ImageList == null)
                {
                    this.WinLabel.ImageList = new WinForms.ImageList();
                }

                if (this.GetWinImageIndex(this.WinLabel.ImageList, this.WebLabel.Image, this.WebLabel.ImageKey) > -1)
                {
                    this.WinLabel.ImageKey = this.WebLabel.ImageKey;
                }
            }
            else
            {
                this.WinLabel.ImageKey = string.Empty;
            }
        }

        /// <summary>
        /// Sets the win label image align.
        /// </summary>
        private void SetWinLabelImageAlign()
        {
            this.WinLabel.ImageAlign = (System.Drawing.ContentAlignment)GetConvertedEnum(typeof(System.Drawing.ContentAlignment), this.WebLabel.ImageAlign);
        }
		
		/// <summary>
		///
		/// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            SetWinLabelTextAlign();
            SetWinLabelImage();
            SetWinLabelImageIndex();
            SetWinLabelImageKey();
            SetWinLabelImageAlign();
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinLabelTextAlign()
		{
			this.WinLabel.TextAlign = this.WebLabel.TextAlign;
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.Label();
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
				case "TextAlign":
				    SetWinLabelTextAlign();
				    break;
                case "Image":
                    SetWinLabelImage();
                    break;
                case "ImageIndex":
                    SetWinLabelImageIndex();
                    break;
                case "ImageKey":
                    SetWinLabelImageKey();
                    break;
                case "ImageAlign":
                    SetWinLabelImageAlign();
                    break;
			}
		}		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Label WebLabel
		{
			get
			{
				return base.SourceObject as WebForms.Label;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.Label WinLabel
		{
			get
			{
				return base.TargetObject as WinForms.Label;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion LabelController Class
	
}
