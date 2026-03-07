#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.Reflection;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ToolBarButtonController Class
	
	/// <summary>
	/// Controls the relations between a webgui mainmenu and a winforms mainmenu
	/// </summary>
	
	public class ToolBarButtonController : ComponentController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ToolBarButtonController(IContext objContext,object objWebControl,object objWinControl) :base(objContext,objWebControl,objWinControl)
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebControl"></param>
		/// <param name="objWinControl"></param>
		public ToolBarButtonController(IContext objContext,object objWebControl) :base(objContext,objWebControl)
		{
			
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController ();

			SetWinToolBarButtonText();
			SetWinToolBarButtonToolTipText();
			SetWinToolBarButtonPushed();
			SetWinToolBarButtonStyle();
            SetWinToolBarButtonImageIndex();
            SetWinToolBarButtonImageKey();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void LoadController()
		{
			base.LoadController ();
			SetWinToolBarImageIndex();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinToolBarImageIndex()
		{
			WinForms.ToolBar objWinToolBar = WinToolBarButton.Parent as WinForms.ToolBar;
			if(objWinToolBar!=null)
			{
				if(this.WebToolBarButton.Image!=null)
				{
					if(objWinToolBar.ImageList==null)
					{
						objWinToolBar.ImageList = new WinForms.ImageList();
					}

					this.WinToolBarButton.ImageIndex = GetWinImageIndex(objWinToolBar.ImageList, this.WebToolBarButton.Image);
				}
                else if (this.WinToolBarButton.ImageIndex != -1)
                {
                    this.WinToolBarButton.ImageIndex = -1;
                }
			}
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinToolBarButtonText()
		{
			this.WinToolBarButton.Text = this.WebToolBarButton.Text;

            // Define a local refference to the winforms button.
            WinForms.ToolBarButton objToolBarButton = this.WinToolBarButton;
            if (objToolBarButton != null)
            {
                // Invoke the uppdate button function in order to recreate the button.
                typeof(WinForms.ToolBarButton).InvokeMember("UpdateButton", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, objToolBarButton, new object[] { true, true, false });
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinToolBarButtonToolTipText()
		{
			this.WinToolBarButton.ToolTipText = this.WebToolBarButton.ToolTipText;
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinToolBarButtonPushed()
		{
            this.WinToolBarButton.Pushed = this.WebToolBarButton.Pushed; 
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinToolBarButtonStyle()
		{
			this.WinToolBarButton.Style = (WinForms.ToolBarButtonStyle)GetConvertedEnum(typeof(WinForms.ToolBarButtonStyle),this.WebToolBarButton.Style);
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ToolBarButton();
		}

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Text":
                    SetWinToolBarButtonText();
                    break;
                case "Style":
                    SetWinToolBarButtonStyle();
                    break;
                case "Pushed":
                    SetWinToolBarButtonPushed();
                    break;
                case "ToolTipText":
                    SetWinToolBarButtonToolTipText();
                    break;
                case "ImageIndex":
                case "Image":
                    SetWinToolBarButtonImageIndex();
                    break;
                case "ImageKey":
                    SetWinToolBarButtonImageKey();
                    break;
            }
        }

        /// <summary>
        /// Sets the index of the win tool bar button image.
        /// </summary>
        private void SetWinToolBarButtonImageIndex()
        {
            if (this.WebToolBarButton.Image != null && this.WinToolBarButton.Parent != null)
            {
                WinForms.ToolBar objWinToolBar = WinToolBarButton.Parent as WinForms.ToolBar;
                if (objWinToolBar.ImageList == null)
                {
                    objWinToolBar.ImageList = new WinForms.ImageList();
                }

               this.WinToolBarButton.ImageIndex = GetWinImageIndex(objWinToolBar.ImageList, this.WebToolBarButton.Image);
            }
            //When the Image is Null and the ImageIndex exist(We just remove an Image from the designer)
            else if(this.WinToolBarButton.ImageIndex != -1)
            {
                //remove the image
                this.WinToolBarButton.ImageIndex = -1;
            }
        }

        /// <summary>
        /// Sets the win tool bar button image key.
        /// </summary>
        private void SetWinToolBarButtonImageKey()
        {
            if (this.WebToolBarButton.Image != null && this.WinToolBarButton.Parent != null)
            {
                WinForms.ToolBar objWinToolBar = WinToolBarButton.Parent as WinForms.ToolBar;
                if (objWinToolBar.ImageList == null)
                {
                    objWinToolBar.ImageList = new WinForms.ImageList();
                }

                if (this.GetWinImageIndex(objWinToolBar.ImageList, this.WebToolBarButton.Image, this.WebToolBarButton.ImageKey)>-1)
                {
                    this.WinToolBarButton.ImageKey = this.WebToolBarButton.ImageKey;
                }
            }
            else if(this.WinToolBarButton.ImageKey != string.Empty)
            {
                this.WinToolBarButton.ImageKey = string.Empty;
            }
        }

		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ToolBarButton WebToolBarButton
		{
			get
			{
				return base.SourceObject as WebForms.ToolBarButton;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ToolBarButton WinToolBarButton
		{
			get
			{
				return base.TargetObject as WinForms.ToolBarButton;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ToolBarButtonController Class
	
}
