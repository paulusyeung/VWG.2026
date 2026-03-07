#region Using

using System;
using System.ComponentModel;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region ColumnStyleController Class

	///  <summary>
	/// Represents the look and feel of a column in a table layout.
	///  </summary>
	
	public class ColumnStyleController : TableLayoutStyleController
	{
		#region C'Tors

		public ColumnStyleController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
		}

		public ColumnStyleController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
		{
		}

		#endregion C'Tors


		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override object CreateTargetObject(object objSourceObject)
		{
            ControllerSource.ColumnStyle objSourceColumnStyle = objSourceObject as ControllerSource.ColumnStyle;
            return new ControllerTarget.ColumnStyle((ControllerTarget.SizeType)this.GetConvertedEnum(typeof(ControllerTarget.SizeType), objSourceColumnStyle.SizeType), objSourceColumnStyle.Width);
		}

        protected override object CreateSourceObject(object objTargetObject)
        {
            ControllerTarget.ColumnStyle objTargetColumnStyle = objTargetObject as ControllerTarget.ColumnStyle;
            return new ControllerSource.ColumnStyle((ControllerSource.SizeType)this.GetConvertedEnum(typeof(ControllerSource.SizeType), objTargetColumnStyle.SizeType), objTargetColumnStyle.Width);
        }

		/// <summary>
		/// Initializes this controller.
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();
            if (this.DesignInitialization)
            {
                this.SetSourceColumnStyleWidth();
            }
            else
            {
                this.SetTargetColumnStyleWidth();
            }
		}

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetSourceColumnStyleWidth();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            this.SetTargetColumnStyleWidth();
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
				case "Width":
					SetSourceColumnStyleWidth();
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
				case "Width":
					SetTargetColumnStyleWidth();
					break;
				default:
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected virtual void SetSourceColumnStyleWidth()
		{
			this.SourceColumnStyle.Width=this.TargetColumnStyle.Width;
		}

		protected virtual void SetTargetColumnStyleWidth()
		{
			this.TargetColumnStyle.Width=this.SourceColumnStyle.Width;
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.ColumnStyle TargetColumnStyle
		{
			get
			{
				return this.TargetObject as ControllerTarget.ColumnStyle;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.ColumnStyle SourceColumnStyle
		{
			get
			{
				return this.SourceObject as ControllerSource.ColumnStyle;
			}
		}

		#endregion Properties

	}

	#endregion ColumnStyleController Class

}
