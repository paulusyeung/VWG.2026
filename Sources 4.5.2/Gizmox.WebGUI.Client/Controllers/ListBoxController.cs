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
	#region ListBoxController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>

    public class ListBoxController : ListControlController
	{
		#region Class Members
		
		private ItemsCollectionController mobjItemsCollectionController = null;
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxController"/> class.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWebTreeView">The obj web tree view.</param>
        /// <param name="objWinTreeView">The obj win tree view.</param>
		public ListBoxController(IContext objContext,object objWebTreeView,object objWinTreeView) :base(objContext,objWebTreeView,objWinTreeView)
		{
			mobjItemsCollectionController = new ItemsCollectionController(Context,this.WebListBox,this.WebListBox.Items,this.WinListBox,this.WinListBox.Items);
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxController"/> class.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWebObject"></param>
		public ListBoxController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
			mobjItemsCollectionController = new ItemsCollectionController(Context,this.WebListBox,this.WebListBox.Items,this.WinListBox,this.WinListBox.Items);
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
			
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained ();
			mobjItemsCollectionController.Initialize();
			SetWinListBoxDataSource();
			SetWinListBoxItems();
		}
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListBoxDataSource()
		{
			if(this.WebListBox.DataSource!=null)
			{
				this.WinListBox.DisplayMember = this.WebListBox.DisplayMember;
				this.WinListBox.DataSource = this.WebListBox.DataSource;
			}
		}

        /// <summary>
        /// Sets the sorted property.
        /// </summary>
        protected virtual void SetSorted()
        {
            if (this.WebListBox != null && this.WinListBox != null)
            {
                this.WinListBox.Sorted = this.WebListBox.Sorted;
            }
        }
		
		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinListBoxItems()
		{
			if (this.WebListBox.DataSource == null)
			{
				this.WinListBox.Items.Clear();
				foreach (object objItem in this.WebListBox.Items)
				{
					this.WinListBox.Items.Add(objItem);
				}
			}
		}
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
		protected override object CreateTargetObject(object objWebObject)
		{
			return new WinForms.ListBox();
		}
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();
			
			this.WinListBox.SelectedIndexChanged+=new EventHandler(WinListBox_SelectedIndexChanged);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WinListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StringBuilder objValue = new StringBuilder();
			foreach(int intIndex in this.WinListBox.SelectedIndices)
			{
				if(objValue.Length>0) objValue.Append(",");
				objValue.Append(intIndex.ToString());
			}
			
			Event objEvent = CreateWebEvent("SelectionChange");
			objEvent.SetParameter("Indexes",objValue.ToString());
            objEvent.SetParameter("Incremental", "0");
			objEvent.Fire();
		}
		
		/// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();
			this.WinListBox.SelectedIndexChanged-=new EventHandler(WinListBox_SelectedIndexChanged);
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
				case "DataSource":
				    SetWinListBoxDataSource();
				    break;
				case "Items":
				    SetWinListBoxItems();
				    break;
                case "Sorted":
                    SetSorted();
                    break;

			}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.ListBox WebListBox
		{
			get
			{
				return base.SourceObject as WebForms.ListBox;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.ListBox WinListBox
		{
			get
			{
				return base.TargetObject as WinForms.ListBox;
			}
		}
		
		
		#endregion Properties
		
	}
	
	#endregion ListBoxController Class
	
}
