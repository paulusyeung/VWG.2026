#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region PanelController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class PanelController : ScrollableControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PanelController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PanelController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			SetWinPanelPanelType();
            SetWinControlBorderStyle();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinPanelPanelType()
		{
			if(WinClientPanel!=null && !this.DesignMode)
			{
				this.WinClientPanel.PanelType = this.WebPanel.PanelType;
			}
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new Forms.ClientPanel();
		}

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
            switch(objPropertyChangeArgs.Property)
            {
                case "AutoSize":
                    SetWinControlAutoSize();
                    break;
                case "AutoSizeMode":
                    SetWinControlAutoSizeMode();
                    break;
                case "BorderStyle":
                    SetWinControlBorderStyle();
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void SetWinControlBorderStyle()
        {
            if (Enum.GetName(typeof(WinForms.BorderStyle), this.WebPanel.BorderStyle) != null)
            {
                this.WinPanel.BorderStyle = (WinForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle), this.WebPanel.BorderStyle, this.WinPanel.BorderStyle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SetWebControlBorderStyle()
        {
            this.WebPanel.BorderStyle = (WebForms.BorderStyle)GetConvertedEnum(typeof(WinForms.BorderStyle), this.WinPanel.BorderStyle, this.WebPanel.BorderStyle);
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
            switch(objPropertyChangeArgs.Property)
            {
                case "AutoSize":
                    SetWebControlAutoSize();
                    break;
                case "AutoSizeMode":
                    SetWebControlAutoSizeMode();
                    break;
                case "BorderStyle":
                    SetWebControlAutoSize();
                    break;
            }
        }
        protected override void InitializedContained()
        {
            base.InitializedContained();
            SetWinControlAutoSize();
            SetWebControlAutoSize();
            SetWinControlAutoSizeMode();
            SetWebControlAutoSizeMode();
        }
        protected virtual void SetWinControlAutoSize()
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            this.WinPanel.AutoSize = this.WebPanel.AutoSize;
#endif
        }
        protected virtual void SetWebControlAutoSize()
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            this.WebPanel.AutoSize = this.WinPanel.AutoSize;
#endif
        }
        protected virtual void SetWinControlAutoSizeMode()
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            this.WinPanel.AutoSizeMode = (System.Windows.Forms.AutoSizeMode)this.GetConvertedEnum(typeof(System.Windows.Forms.AutoSizeMode), this.WebPanel.AutoSizeMode);
#endif
        }
        protected virtual void SetWebControlAutoSizeMode()
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            this.WebPanel.AutoSizeMode = (Gizmox.WebGUI.Forms.AutoSizeMode)this.GetConvertedEnum(typeof(Gizmox.WebGUI.Forms.AutoSizeMode), this.WinPanel.AutoSizeMode); 
#endif
        }
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.Panel WebPanel
		{
			get
			{
				return base.SourceObject as WebForms.Panel;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.Panel WinPanel
		{
			get
			{
                return base.TargetObject as WinForms.Panel;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public Forms.ClientPanel WinClientPanel
		{
			get
			{
				return base.TargetObject as Forms.ClientPanel;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion PanelController Class
	
}
