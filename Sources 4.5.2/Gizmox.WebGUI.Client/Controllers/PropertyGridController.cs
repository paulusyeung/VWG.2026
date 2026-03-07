#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region PropertyGridController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class PropertyGridController : ControlController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PropertyGridController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public PropertyGridController(IContext objContext,object objWebTreeView) :base(objContext,objWebTreeView)
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
			SetWinPropertyGridSelectedObjects();
            SetWinPropertyGridHelpVisible();
            SetWinPropertyGridPropertySort();
		}


        /// <summary>
        /// Sets the win property grid help visible.
        /// </summary>
        protected virtual void SetWinPropertyGridHelpVisible()
		{
			this.WinPropertyGrid.HelpVisible = this.WebPropertyGrid.HelpVisible;
		}

        /// <summary>
        /// Sets the win property grid selected objects.
        /// </summary>
        protected virtual void SetWinPropertyGridSelectedObjects()
        {
            this.WinPropertyGrid.SelectedObjects = this.WebPropertyGrid.SelectedObjects;
        }

        /// <summary>
        /// Sets the win property grid prperty sort.
        /// </summary>
        private void SetWinPropertyGridPropertySort()
        {
            this.WinPropertyGrid.PropertySort = (WinForms.PropertySort)this.GetConvertedEnum(typeof(WinForms.PropertySort), this.WebPropertyGrid.PropertySort);
        }

		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.PropertyGrid();
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
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange (objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "SelectedObjects":
				    SetWinPropertyGridSelectedObjects();
				    break;
				case "SelectedObject":
				    SetWinPropertyGridSelectedObjects();
				    break;
                case "HelpVisible":
                    SetWinPropertyGridHelpVisible();
				    break;
                case "PropertySort":
                    SetWinPropertyGridPropertySort();
                    break;
			}
		}		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.PropertyGrid WebPropertyGrid
		{
			get
			{
				return base.SourceObject as WebForms.PropertyGrid;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.PropertyGrid WinPropertyGrid
		{
			get
			{
				return base.TargetObject as WinForms.PropertyGrid;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion PropertyGridController Class
	
}
