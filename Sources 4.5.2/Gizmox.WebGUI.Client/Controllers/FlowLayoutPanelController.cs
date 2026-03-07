#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region FlowLayoutPanelController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class FlowLayoutPanelController : PanelController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public FlowLayoutPanelController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public FlowLayoutPanelController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			SetWinFlowLayoutPanelFlowDirection();
			
		}

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "FlowDirection":
                    SetWinFlowLayoutPanelFlowDirection();
                    break;
                case "WrapContents":
                    SetWinFlowLayoutPanelWrapContents();
                    break;
                default:
                    base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }

        private void SetWinFlowLayoutPanelWrapContents()
        {
            this.WinFlowLayoutPanel.WrapContents = this.WebFlowLayoutPanel.WrapContents;                  
        }


        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            switch (objPropertyChangeArgs.Property)
            {
                case "FlowDirection":
                    SetWebFlowLayoutPanelFlowDirection();
                    break;
                default:
                    base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
                    break;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinFlowLayoutPanelFlowDirection()
		{
			WinForms.FlowDirection enmFlowDirection;
			
			if(((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WebForms.FlowDirection.RightToLeft))>0)
			{
				enmFlowDirection = WinForms.FlowDirection.RightToLeft;
			}
			else if(((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WebForms.FlowDirection.LeftToRight))>0)
			{
				enmFlowDirection = WinForms.FlowDirection.LeftToRight;
			}
			else if(((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WebForms.FlowDirection.BottomUp))>0)
			{
				enmFlowDirection = WinForms.FlowDirection.BottomUp;
			}
			else
			{
				enmFlowDirection = WinForms.FlowDirection.TopDown;
			}
			
			this.WinFlowLayoutPanel.FlowDirection = enmFlowDirection;
            
		}

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWebFlowLayoutPanelFlowDirection()
        {
            WebForms.FlowDirection enmFlowDirection;

            if (((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WinForms.FlowDirection.RightToLeft)) > 0)
            {
                enmFlowDirection = WebForms.FlowDirection.RightToLeft;
            }
            else if (((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WinForms.FlowDirection.LeftToRight)) > 0)
            {
                enmFlowDirection = WebForms.FlowDirection.LeftToRight;
            }
            else if (((int)(this.WebFlowLayoutPanel.FlowDirection) & ((int)WinForms.FlowDirection.BottomUp)) > 0)
            {
                enmFlowDirection = WebForms.FlowDirection.BottomUp;
            }
            else
            {
                enmFlowDirection = WebForms.FlowDirection.TopDown;
            }

            this.WebFlowLayoutPanel.FlowDirection = enmFlowDirection;            
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.FlowLayoutPanel();
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
		public WebForms.FlowLayoutPanel WebFlowLayoutPanel
		{
			get
			{
				return base.SourceObject as WebForms.FlowLayoutPanel;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.FlowLayoutPanel WinFlowLayoutPanel
		{
			get
			{
				return base.TargetObject as WinForms.FlowLayoutPanel;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion FlowLayoutPanelController Class
	
}
