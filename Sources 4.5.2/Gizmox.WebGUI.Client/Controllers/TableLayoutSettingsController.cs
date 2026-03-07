#region Using

using System;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Layout;
using System.Runtime.Serialization;
using ControllerTarget = System.Windows.Forms;
using ControllerSource = Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region TableLayoutSettingsController Class

	///  <summary>
	/// Collects the characteristics associated with table layouts.
	///  </summary>
	
	public class TableLayoutSettingsController : LayoutSettingsController
	{
		#region Class Memebers

		private TableLayoutRowStyleCollectionController mobjRowStylesController = null;
		private TableLayoutColumnStyleCollectionController mobjColumnStylesController = null;
		#endregion Class Memebers

		#region C'Tors

		public TableLayoutSettingsController(IContext objContext, object objSourceObject, object objTargetObject) : base(objContext,objSourceObject,objTargetObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext,this.SourceTableLayoutSettings,this.SourceTableLayoutSettings.RowStyles,this.TargetTableLayoutSettings,this.TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext,this.SourceTableLayoutSettings,this.SourceTableLayoutSettings.ColumnStyles,this.TargetTableLayoutSettings,this.TargetTableLayoutSettings.ColumnStyles);
		}

		public TableLayoutSettingsController(IContext objContext, object objSourceObject) : base(objContext,objSourceObject)
		{
			mobjRowStylesController = new TableLayoutRowStyleCollectionController(objContext,this.SourceTableLayoutSettings,this.SourceTableLayoutSettings.RowStyles,this.TargetTableLayoutSettings,this.TargetTableLayoutSettings.RowStyles);
			mobjColumnStylesController = new TableLayoutColumnStyleCollectionController(objContext,this.SourceTableLayoutSettings,this.SourceTableLayoutSettings.ColumnStyles,this.TargetTableLayoutSettings,this.TargetTableLayoutSettings.ColumnStyles);
		}

		#endregion C'Tors


		#region Methods

		/// <summary>
		/// Creates the target object.
		/// </summary>
		protected override void InitializedContained()
		{
			base.InitializedContained();
			this.mobjRowStylesController.Initialize();
			this.mobjColumnStylesController.Initialize();
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
			this.SetTargetTableLayoutSettingsColumnCount();
			this.SetTargetTableLayoutSettingsRowCount();
			this.SetTargetTableLayoutSettingsGrowStyle();
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
           
                switch (objPropertyChangeArgs.Property)
                {
                    case "ColumnCount":
                        SetSourceTableLayoutSettingsColumnCount();
                        break;
                    case "RowCount":
                        SetSourceTableLayoutSettingsRowCount();
                        break;
                    case "GrowStyle":
                        SetSourceTableLayoutSettingsGrowStyle();
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
				case "ColumnCount":
					SetTargetTableLayoutSettingsColumnCount();
					break;
				case "RowCount":
					SetTargetTableLayoutSettingsRowCount();
					break;
				case "GrowStyle":
					SetTargetTableLayoutSettingsGrowStyle();
					break;
				default:
					base.OnSourceObjectPropertyChange(objPropertyChangeArgs);
					break;
			}
		}

		protected virtual void SetSourceTableLayoutSettingsColumnCount()
		{
			this.SourceTableLayoutSettings.ColumnCount=this.TargetTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetTargetTableLayoutSettingsColumnCount()
		{
			this.TargetTableLayoutSettings.ColumnCount=this.SourceTableLayoutSettings.ColumnCount;
		}

		protected virtual void SetSourceTableLayoutSettingsRowCount()
		{
			this.SourceTableLayoutSettings.RowCount=this.TargetTableLayoutSettings.RowCount;
		}

		protected virtual void SetTargetTableLayoutSettingsRowCount()
		{
			this.TargetTableLayoutSettings.RowCount=this.SourceTableLayoutSettings.RowCount;
		}

		protected virtual void SetSourceTableLayoutSettingsGrowStyle()
		{
			this.SourceTableLayoutSettings.GrowStyle=(ControllerSource.TableLayoutPanelGrowStyle)this.GetConvertedEnum(typeof(ControllerSource.TableLayoutPanelGrowStyle), this.TargetTableLayoutSettings.GrowStyle);
		}

		protected virtual void SetTargetTableLayoutSettingsGrowStyle()
		{
			this.TargetTableLayoutSettings.GrowStyle=(ControllerTarget.TableLayoutPanelGrowStyle)this.GetConvertedEnum(typeof(ControllerTarget.TableLayoutPanelGrowStyle), this.SourceTableLayoutSettings.GrowStyle);
		}

		#endregion Methods

		#region Properties

		/// <summary>
		/// Get typed the target object.
		/// </summary>
		public ControllerTarget.TableLayoutSettings TargetTableLayoutSettings
		{
			get
			{
				return this.TargetObject as ControllerTarget.TableLayoutSettings;
			}
		}

		/// <summary>
		/// Get typed the source object.
		/// </summary>
		public ControllerSource.TableLayoutSettings SourceTableLayoutSettings
		{
			get
			{
				return this.SourceObject as ControllerSource.TableLayoutSettings;
			}
		}

		#endregion Properties

	}

	#endregion TableLayoutSettingsController Class

}
