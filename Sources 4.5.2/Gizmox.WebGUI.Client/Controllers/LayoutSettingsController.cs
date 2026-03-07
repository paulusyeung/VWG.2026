#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region LayoutSettingsController Class

	///  <summary>
	/// Provides a base class for collecting layout scheme characteristics.
	///  </summary>
    
    public abstract class LayoutSettingsController : ObjectController
	{
		#region C'Tors

		public LayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
		}

		public LayoutSettingsController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
		{
		}

		#endregion C'Tors


		#region Methods

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

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.LayoutSettings TargetLayoutSettings
		{
			get
			{
				return this.TargetObject as ControllerTarget.LayoutSettings;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.LayoutSettings SourceLayoutSettings
		{
			get
			{
				return this.SourceObject as ControllerSource.LayoutSettings;
			}
		}

		#endregion Properties

	}

	#endregion LayoutSettingsController Class

}
