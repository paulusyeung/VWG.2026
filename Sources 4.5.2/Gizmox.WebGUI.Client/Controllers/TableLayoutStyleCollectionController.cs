#region Using

using System;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TableLayoutStyleCollectionController Class

	///  <summary>
	/// Implements the basic functionality for a collection of table layout styles.
	///  </summary>
    
	public class TableLayoutStyleCollectionController : ObjectCollectionController
	{
		#region C'Tors

		public TableLayoutStyleCollectionController(IContext objContext, object objSourceObject, IList objSourceList, object objTargetObject, IList objTargetList) : base(objContext,objSourceObject,objSourceList,objTargetObject,objTargetList)
		{
		}

		#endregion C'Tors


		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override ObjectController CreateObjectControlerBySourceObject(object objSourceObject)
		{
            return new TableLayoutStyleController(this.Context, objSourceObject);
		}

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            if(objSourceObject is ControllerSource.RowStyle)
            {
                return new ControllerTarget.RowStyle();
            }
            else if (objSourceObject is ControllerSource.ColumnStyle)
            {
                return new ControllerTarget.ColumnStyle();
            }
            else
            {
                return null;
            }
		}

		/// <summary>
		/// Initializes this controller.
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
		}

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
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
		public ControllerTarget.TableLayoutStyleCollection TargetTableLayoutStyleCollection
		{
			get
			{
				return this.TargetObject as ControllerTarget.TableLayoutStyleCollection;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutStyleCollection SourceTableLayoutStyleCollection
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutStyleCollection;
			}
		}

        /// <summary>
        /// Gets a value indicating whether [override exist win objects].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [override exist win objects]; otherwise, <c>false</c>.
        /// </value>
        protected override bool OverrideExistWinObjects
        {
            get
            {
                return true;
            }
        }

		#endregion Properties

	}

	#endregion TableLayoutStyleCollectionController Class

}
