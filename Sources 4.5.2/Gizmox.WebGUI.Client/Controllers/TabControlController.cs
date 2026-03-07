#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TabControlController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class TabControlController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public TabControlController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public TabControlController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			SetWinTabControlSelectedIndex();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinTabControlSelectedIndex()
		{
			this.WinTabControl.SelectedIndex = this.WebTabControl.SelectedIndex;
		}

        /// <summary>
		///
		/// </summary>
        protected virtual void SetTargetTabControlSelectedIndex()
		{
            this.WinTabControl.Multiline = this.WebTabControl.Multiline;
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetSourceTabControlSelectedIndex()
        {
            this.WebTabControl.Multiline = this.WinTabControl.Multiline;
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "SelectedIndex":
				    SetWinTabControlSelectedIndex();
				    break;
				case "TabPages":
				    SetWinControlControls();
				    break;
                case "Multiline":
                    SetTargetTabControlSelectedIndex();
                    break;
			}
		}

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Multiline":
                    SetSourceTabControlSelectedIndex();
                    break;
            }
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.TabControl();
		}
		
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.TabControl WebTabControl
		{
			get
			{
				return base.SourceObject as WebForms.TabControl;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.TabControl WinTabControl
		{
			get
			{
				return base.TargetObject as WinForms.TabControl;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion TabControlController Class
	
}
