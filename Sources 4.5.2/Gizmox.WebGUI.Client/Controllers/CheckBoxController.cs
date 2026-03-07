#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region CheckBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class CheckBoxController : ButtonBaseControler
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public CheckBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public CheckBoxController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
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
			SetWinCheckBoxChecked();
            SetWinCheckBoxThreeState();
            SetWinCheckBoxCheckState();
            SetWinAppearance();
            SetWinCheckAlign();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinCheckBoxChecked()
		{
			this.WinCheckBox.Checked = this.WebCheckBox.Checked;
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinCheckBoxThreeState()
        {
            this.WinCheckBox.ThreeState = this.WebCheckBox.ThreeState;
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinCheckBoxCheckState()
        {
            this.WinCheckBox.CheckState = (WinForms.CheckState)GetConvertedEnum(typeof(WinForms.CheckState), this.WebCheckBox.CheckState);
        }

        /// <summary>
        /// Sets the win appearance.
        /// </summary>
        protected virtual void SetWinAppearance()
        {
            object objAppearance = this.GetConvertedEnum(typeof(WinForms.Appearance), this.WebCheckBox.Appearance);
            if (objAppearance != null)
            {
                this.WinCheckBox.Appearance = (WinForms.Appearance)objAppearance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWinCheckAlign()
        {
            this.WinCheckBox.CheckAlign = this.WebCheckBox.CheckAlign;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetWebCheckAlign()
        {
            this.WebCheckBox.CheckAlign = this.WinCheckBox.CheckAlign;
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.CheckBox();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			this.WinCheckBox.Click+=new EventHandler(WinCheckBox_CheckedChanged);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Event objEvent = CreateWebEvent("ValueChange");
			objEvent.SetParameter("Checked",this.WinCheckBox.Checked?"1":"0");
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinCheckBox.Click-=new EventHandler(WinCheckBox_CheckedChanged);
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
				case "Checked":
				    SetWinCheckBoxChecked();
				    break;
                case "ThreeState":
                    SetWinCheckBoxThreeState();
                    break;
                case "CheckState":
                    SetWinCheckBoxCheckState();
                    break;
                case "CheckAlign":
                    SetWinCheckAlign();
                    break;
                case "Appearance":
                    SetWinAppearance();
                    break;
			}
		}

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "CheckAlign":
                    SetWebCheckAlign();
                    break;
            }
        }
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.CheckBox WebCheckBox
		{
			get
			{
				return base.SourceObject as WebForms.CheckBox;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.CheckBox WinCheckBox
		{
			get
			{
				return base.TargetObject as WinForms.CheckBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion CheckBoxController Class
	
}
