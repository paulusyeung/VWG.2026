#region Using

using System;
using System.ComponentModel;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region RowStyleController Class

	///  <summary>
	/// Represents the look and feel of a row in a table layout.
	///  </summary>
	
	public class RowStyleController : TableLayoutStyleController
	{
		#region C'Tors

		public RowStyleController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
		}

		public RowStyleController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
		{
		}

		#endregion C'Tors


		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            ControllerSource.RowStyle objSourceRowStyle = objSourceObject as ControllerSource.RowStyle;
            return new ControllerTarget.RowStyle((ControllerTarget.SizeType)this.GetConvertedEnum(typeof(ControllerTarget.SizeType), objSourceRowStyle.SizeType), objSourceRowStyle.Height);
		}

        protected override object CreateSourceObject(object objTargetObject)
        {
            ControllerTarget.RowStyle objTargetRowStyle = objTargetObject as ControllerTarget.RowStyle;
            return new ControllerSource.RowStyle((ControllerSource.SizeType)this.GetConvertedEnum(typeof(ControllerSource.SizeType), objTargetRowStyle.SizeType), objTargetRowStyle.Height);
        }

		/// <summary>
		/// Initializes this controller.
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
            if (this.DesignInitialization)
            {
                this.SetSourceRowStyleHeight();
            }
            else
            {
                this.SetTargetRowStyleHeight();
            }
		}

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetSourceRowStyleHeight();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            this.SetTargetRowStyleHeight();
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
				case "Height":
					SetSourceRowStyleHeight();
					break;
				default:
					base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			switch(objPropertyChangeArgs.Property)
			{
				case "Height":
					SetTargetRowStyleHeight();
					break;
				default:
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected virtual void SetSourceRowStyleHeight()
		{
			this.SourceRowStyle.Height=this.TargetRowStyle.Height;
		}

		protected virtual void SetTargetRowStyleHeight()
		{
			this.TargetRowStyle.Height=this.SourceRowStyle.Height;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.RowStyle TargetRowStyle
		{
			get
			{
				return this.TargetObject as ControllerTarget.RowStyle;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.RowStyle SourceRowStyle
		{
			get
			{
				return this.SourceObject as ControllerSource.RowStyle;
			}
		}

		#endregion Properties

	}

	#endregion RowStyleController Class

}
