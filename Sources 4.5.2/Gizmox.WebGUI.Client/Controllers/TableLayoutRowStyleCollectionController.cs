#region Using

using System;
using System.Collections;
using System.ComponentModel;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TableLayoutRowStyleCollectionController Class

	///  <summary>
	/// A collection that stores  objects.
	///  </summary>
	
	public class TableLayoutRowStyleCollectionController : TableLayoutStyleCollectionController
	{
		#region C'Tors

		public TableLayoutRowStyleCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList) : base(objContext,objSourceObject,objSourceList,objTargetObject,objTargetList)
		{
		}

		#endregion C'Tors


		#region Methods


        protected override ObjectController CreateObjectControlerByTargetObject(object objTargetObject)
        {
            return new RowStyleController(Context, null, objTargetObject);
        }

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
            return new RowStyleController(this.Context, objSourceObject);
		}

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            return new ControllerTarget.RowStyle();
		}



		/// <summary>
		/// Initializes this controller.
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
		}

		/// <summary>
		/// Terminates this controller.
		/// </summary>
		public override void Terminate()
		{
			base.Terminate();
		}

		protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch(objPropertyChangeArgs.Property)
			{
				default:
					base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch(objPropertyChangeArgs.Property)
			{
				default:
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.TableLayoutRowStyleCollection TargetTableLayoutRowStyleCollection
		{
			get
			{
				return this.TargetObject as ControllerTarget.TableLayoutRowStyleCollection;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutRowStyleCollection SourceTableLayoutRowStyleCollection
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutRowStyleCollection;
			}
		}

		#endregion Properties

	}

	#endregion TableLayoutRowStyleCollectionController Class

}
