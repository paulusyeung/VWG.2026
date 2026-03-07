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
	#region TableLayoutControlCollectionController Class

	///  <summary>
	/// Represents a collection of child controls in a table layout container.
	///  </summary>
	
	public class TableLayoutControlCollectionController : ControlCollectionController
	{
		#region C'Tors

		public TableLayoutControlCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList) : base(objContext,objSourceObject,objSourceList,objTargetObject,objTargetList)
		{
		}

		#endregion C'Tors


		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
            return base.CreateObjectControlerBySourceObject(objSourceObject);
		}

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            return base.CreateTargetObject(objSourceObject);
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

        protected override void InitializedContained()
        {
            base.InitializedContained();
        }

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.TableLayoutControlCollection TargetTableLayoutControlCollection
		{
			get
			{
				return this.TargetObject as ControllerTarget.TableLayoutControlCollection;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutControlCollection SourceTableLayoutControlCollection
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutControlCollection;
			}
		}

		#endregion Properties

	}

	#endregion TableLayoutControlCollectionController Class

}
