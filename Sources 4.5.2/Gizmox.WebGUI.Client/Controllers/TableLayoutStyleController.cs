#region Using

using System;
using System.ComponentModel;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TableLayoutStyleController Class

	///  <summary>
	/// Implements the basic functionality that represents the appearance and behavior of a table layout.
	///  </summary>
	
	public class TableLayoutStyleController : ObjectController
	{
		#region C'Tors

		public TableLayoutStyleController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
		}

		public TableLayoutStyleController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
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
			this.SetTargetTableLayoutStyleSizeType();
		}

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();
            this.SetSourceTableLayoutStyleSizeType();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();
            this.SetTargetTableLayoutStyleSizeType();
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
				case "SizeType":
					SetSourceTableLayoutStyleSizeType();
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
				case "SizeType":
					SetTargetTableLayoutStyleSizeType();
					break;
				default:
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected virtual void SetSourceTableLayoutStyleSizeType()
		{
			this.SourceTableLayoutStyle.SizeType=(ControllerSource.SizeType)this.GetConvertedEnum(typeof(ControllerSource.SizeType), this.TargetTableLayoutStyle.SizeType);
		}

		protected virtual void SetTargetTableLayoutStyleSizeType()
		{
			this.TargetTableLayoutStyle.SizeType=(ControllerTarget.SizeType)this.GetConvertedEnum(typeof(ControllerTarget.SizeType), this.SourceTableLayoutStyle.SizeType);
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.TableLayoutStyle TargetTableLayoutStyle
		{
			get
			{
				return this.TargetObject as ControllerTarget.TableLayoutStyle;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutStyle SourceTableLayoutStyle
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutStyle;
			}
		}

		#endregion Properties

	}

	#endregion TableLayoutStyleController Class

}
