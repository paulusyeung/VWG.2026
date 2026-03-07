#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region DataGidViewColumnController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class DataGidViewColumnController : ComponentController
	{
		#region Class Members
		
		
		#endregion Class Members
		
		#region C'Tor/D'Tor
		
		/// <summary>
		///
		/// </summary>
        /// <param name="objWebColumn"></param>
        /// <param name="objWinColumn"></param>
        public DataGidViewColumnController(IContext objContext, object objWebColumn, object objWinColumn)
            : base(objContext, objWebColumn, objWinColumn)
		{
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public DataGidViewColumnController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// Updates the source.
        /// </summary>
        public override void UpdateSource()
        {
            base.UpdateSource();

            SetWebColumnHeaderText();
            SetWebColumnName();
            SetWebColumnWidth();
            SetWebColumnDataPropertyName();
        }

        /// <summary>
        /// Updates the target.
        /// </summary>
        public override void UpdateTarget()
        {
            base.UpdateTarget();

            SetWinColumnDataPropertyName();
            SetWinColumnDefaultCellStyle();
            SetWinColumnHeaderCellValue();
            SetWinColumnWidth();
            SetWinColumnName();
        }

		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

            SetWinColumnDataPropertyName();
            SetWinColumnDefaultCellStyle();
			SetWinColumnHeaderCellValue();
			SetWinColumnWidth();
            SetWinColumnName();
            SetWinColumnAutoSizeMode();
		}

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);
            
            switch (objPropertyChangeArgs.Property)
            {
                case "HeaderText":
                    SetWebColumnHeaderText();
                    break;
                case "Name":
                    SetWebColumnName();
                    break;
                case "Width":
                    SetWebColumnWidth();
                    break;
                case "DataPropertyName":
                    SetWebColumnDataPropertyName();
                    break;
            }
        }

        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch(objPropertyChangeArgs.Property)
			{
                case "DefaultCellStyle":
                    SetWinColumnDefaultCellStyle();
				    break;
                case "HeaderText":
                    SetWinColumnHeaderCellValue();
                    break;
                case "Name":
                    SetWinColumnName();
                    break;
                case "Width":
                    SetWinColumnWidth();
                    break;
                case "DataPropertyName":
                    SetWinColumnDataPropertyName();
                    break;
                case "AutoSizeMode":
                    SetWinColumnAutoSizeMode();
                    break;

			}
        }
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		public override void FireWebPropertyChanged(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.FireWebPropertyChanged(objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
                case "HeaderText":
				    SetWinColumnHeaderCellValue();
				    break;

				case "Width":
				    SetWinColumnWidth();
				    break;
			}
		}
		
		#region Set Property

        /// <summary>
        /// 
        /// </summary>
        protected void SetWinColumnDefaultCellStyle()
        {
            // Check that the column's cell style is not null.
            if (this.WebColumn != null &&
                this.WebColumn.DefaultCellStyle != null &&
                this.WinColumn != null)
            {
                // Check if the winforms cell style is null and create a new one.
                if (this.WinColumn.DefaultCellStyle == null)
                {
                    this.WinColumn.DefaultCellStyle = new WinForms.DataGridViewCellStyle();
                }

                // Get all of the WinForms DataGridViewCellStyle data out of the WebGUI DataGridViewCellStyle.
                this.WinColumn.DefaultCellStyle.Alignment = (WinForms.DataGridViewContentAlignment)Enum.Parse(typeof(WinForms.DataGridViewContentAlignment), this.WebColumn.DefaultCellStyle.Alignment.ToString());
                this.WinColumn.DefaultCellStyle.BackColor = this.WebColumn.DefaultCellStyle.BackColor;
                this.WinColumn.DefaultCellStyle.DataSourceNullValue = this.WebColumn.DefaultCellStyle.DataSourceNullValue;
                if (this.WebColumn.DefaultCellStyle.Font == null)
                {
                    this.WinColumn.DefaultCellStyle.Font = null;
                }
                else
                {
                    this.WinColumn.DefaultCellStyle.Font = new Font(this.WebColumn.DefaultCellStyle.Font.FontFamily, this.WebColumn.DefaultCellStyle.Font.Size * TargetVerticalScaleFactor);
                }
                this.WinColumn.DefaultCellStyle.ForeColor = this.WebColumn.DefaultCellStyle.ForeColor;
                this.WinColumn.DefaultCellStyle.Format = this.WebColumn.DefaultCellStyle.Format;
                this.WinColumn.DefaultCellStyle.FormatProvider = this.WebColumn.DefaultCellStyle.FormatProvider;
                this.WinColumn.DefaultCellStyle.NullValue = this.WebColumn.DefaultCellStyle.NullValue;
                this.WinColumn.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(this.WebColumn.DefaultCellStyle.Padding.Left, this.WebColumn.DefaultCellStyle.Padding.Top, this.WebColumn.DefaultCellStyle.Padding.Right, this.WebColumn.DefaultCellStyle.Padding.Bottom);
                this.WinColumn.DefaultCellStyle.SelectionBackColor = this.WebColumn.DefaultCellStyle.SelectionBackColor;
                this.WinColumn.DefaultCellStyle.SelectionForeColor = this.WebColumn.DefaultCellStyle.SelectionForeColor;
                this.WinColumn.DefaultCellStyle.Tag = this.WebColumn.DefaultCellStyle.Tag;
                this.WinColumn.DefaultCellStyle.WrapMode = (WinForms.DataGridViewTriState)Enum.Parse(typeof(WinForms.DataGridViewTriState), this.WebColumn.DefaultCellStyle.WrapMode.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinColumnDataPropertyName()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WinColumn.DataPropertyName = this.WebColumn.DataPropertyName;
            }
#endif
        }

        /// <summary>
        /// Sets the win column auto size mode.
        /// </summary>
        private void SetWinColumnAutoSizeMode()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WinColumn.AutoSizeMode = (WinForms.DataGridViewAutoSizeColumnMode)GetConvertedEnum(typeof(WinForms.DataGridViewAutoSizeColumnMode), this.WebColumn.AutoSizeMode, this.WinColumn.AutoSizeMode);
            }
#endif
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWinColumnName()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WinColumn.Name = this.WebColumn.Name;
            }
#endif
        }


		/// <summary>
		///
		/// </summary>
		protected virtual void SetWinColumnHeaderCellValue()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WinColumn.HeaderCell.Value = this.WebColumn.HeaderCell.Value;
            }
#endif
		}

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebColumnDataPropertyName()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WebColumn.DataPropertyName = this.WinColumn.DataPropertyName;
            }
#endif
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebColumnWidth()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WebColumn.Width = Convert.ToInt32(this.WinColumn.Width / TargetHorizontalScaleFactor);
            }
#endif
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebColumnName()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WebColumn.Name = this.WinColumn.Name;
            }
#endif
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void SetWebColumnHeaderText()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WebColumn.HeaderText = this.WinColumn.HeaderText;
            }
#endif
        }
		
		/// <summary>
		///
		/// </summary>
        protected virtual void SetWinColumnWidth()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            if (this.WebColumn != null &&
                this.WinColumn != null)
            {
                this.WinColumn.Width = Convert.ToInt32(this.WebColumn.Width * TargetHorizontalScaleFactor);
            }
#endif
		}
		
		
		#endregion Set Property
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.DataGridViewColumn WebColumn
		{
			get
			{
                return base.SourceObject as WebForms.DataGridViewColumn;
			}
		}
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        /// <summary>
		///
		/// </summary>
        public WinForms.DataGridViewColumn WinColumn
		{
			get
			{
                return base.TargetObject as WinForms.DataGridViewColumn;
			}
		}
#endif

		#endregion Properties
		
	}
	
	#endregion DataGidViewColumnController Class
	
}
