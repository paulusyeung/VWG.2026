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
	#region ComboBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class ComboBoxController : ListControlController
	{
		#region Class Members
		
		private ItemsCollectionController mobjItemsCollectionController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ComboBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(Context,this.WebComboBox,this.WebComboBox.Items,this.WinComboBox,this.WinComboBox.Items);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public ComboBoxController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(Context,this.WebComboBox,this.WebComboBox.Items,this.WinComboBox,this.WinComboBox.Items);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "DropDownStyle":
                    SetWinComboDropDownStyle();
                    break;
                case "Items":
                    SetWinComboBoxItems();
                    break;
            }
        }

        /// <summary>
        /// Sets the win combo box items.
        /// </summary>
        private void SetWinComboBoxItems()
        {
            if (this.WinComboBox != null && this.WebComboBox != null)
            {
                this.WinComboBox.Items.Clear();

                object[] arrItems = new object[this.WebComboBox.Items.Count];

                this.WebComboBox.Items.CopyTo(arrItems, 0);

                this.WinComboBox.Items.AddRange(arrItems);
            }
        }

        /// <summary>
        /// Wires required events for controller to work in design time
        /// </summary>
        protected override void WireDesignTimeEvents()
        {
            base.WireDesignTimeEvents();

            this.WinComboBox.SizeChanged += new EventHandler(WinComboBox_SizeChanged);
        }

        /// <summary>
        /// Handles the Size Changed event of the WinComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinComboBox_SizeChanged(object sender, EventArgs e)
        {
            this.SetWebControlSize();
        }

        /// <summary>
        /// Initializes the new.
        /// </summary>
        public override void InitializeNew()
        {
            base.InitializeNew();

            if (this.WebComboBox != null)
            {
                this.WebComboBox.FormattingEnabled = true;
            }
        }

        /// <summary>
        /// Unwires wired design time events
        /// </summary>
        protected override void UnwireDesignTimeEvents()
        {
            base.UnwireDesignTimeEvents();

            this.WinComboBox.SizeChanged -= new EventHandler(WinComboBox_SizeChanged);
        }

        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "DropDownStyle":
                    SetWebComboDropDownStyle();
                    break;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

            this.SetWinComboDropDownStyle();
            this.SetWinComboBoxItems();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained ();
			mobjItemsCollectionController.Initialize();
		}

        /// <summary>
        /// </summary>
        protected override void SetWebControlText()
        {
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinComboDropDownStyle()
        {
            this.WinComboBox.DropDownStyle = (WinForms.ComboBoxStyle)GetConvertedEnum(typeof(WinForms.ComboBoxStyle), this.WebComboBox.DropDownStyle);            
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebComboDropDownStyle()
        {
            this.WebComboBox.DropDownStyle = (WebForms.ComboBoxStyle)GetConvertedEnum(typeof(WebForms.ComboBoxStyle), this.WinComboBox.DropDownStyle);
        }


		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ComboBox();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			this.WinComboBox.SelectedIndexChanged+=new EventHandler(WinListBox_SelectedIndexChanged);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			Event objEvent = CreateWebEvent("ValueChange");
			objEvent.SetParameter(WGAttributes.Value,this.WinComboBox.SelectedIndex.ToString());
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinComboBox.SelectedIndexChanged-=new EventHandler(WinListBox_SelectedIndexChanged);
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ComboBox WebComboBox
		{
			get
			{
				return base.SourceObject as WebForms.ComboBox;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ComboBox WinComboBox
		{
			get
			{
				return base.TargetObject as WinForms.ComboBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ComboBoxController Class
	
}
