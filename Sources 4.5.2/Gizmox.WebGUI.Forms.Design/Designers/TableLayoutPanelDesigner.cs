using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Data;

using Gizmox.WebGUI.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{

    /// <summary>
    /// 
    /// </summary>
    public class TableLayoutPanelDesigner : ComponentDesigner
    {
        
		#region Properties 

		/// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>The table.</value>
        internal TableLayoutPanel Table
        {
            get
            {
                return (base.Component as TableLayoutPanel);
            }
        }
		
		#endregion 

		#region Methods 

        /// <summary>
        /// Prepares the designer to view, edit, and design the specified component.
        /// </summary>
        /// <param name="component">The component for this designer.</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Try getting designer host.
            IDesignerHost objDesignerHost = this.GetService(typeof(IDesignerHost)) as IDesignerHost;

            // Check if current initialization is a cause of designer loading.
            if (objDesignerHost != null && !objDesignerHost.Loading)
            {
                this.CreateEmptyTable();
            }
        }

		/// <summary>
        /// Creates the empty table.
        /// </summary>
        private void CreateEmptyTable()
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.Table)["ColumnCount"];
            if (descriptor != null)
            {
                descriptor.SetValue(this.Table, 2);
            }
            PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(this.Table)["RowCount"];
            if (descriptor2 != null)
            {
                descriptor2.SetValue(this.Table, 2);
            }
            this.EnsureAvailableStyles();
            this.InitializeNewStyles();
        }
		
		/// <summary>
        /// Ensures the available styles.
        /// </summary>
        /// <returns></returns>
        private bool EnsureAvailableStyles()
        {
            int intColumnWidths = 2;
            int intRowHeights = 2;
            this.Table.SuspendLayout();
            try
            {
                if (intColumnWidths > this.Table.ColumnStyles.Count)
                {
                    int num = intColumnWidths - this.Table.ColumnStyles.Count;
                    for (int i = 0; i < num; i++)
                    {
                        this.Table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                    }
                }
                if (intRowHeights > this.Table.RowStyles.Count)
                {
                    int num3 = intRowHeights - this.Table.RowStyles.Count;
                    for (int j = 0; j < num3; j++)
                    {
                        this.Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                    }
                }
            }
            finally
            {
                this.Table.ResumeLayout();
            }
            return true;
        }
		
		/// <summary>
        /// Initializes the new styles.
        /// </summary>
        private void InitializeNewStyles()
        {
            Size size = this.Table.Size;
            this.Table.ColumnStyles[0].SizeType = SizeType.Percent;
            this.Table.ColumnStyles[0].Width = 50;
            this.Table.ColumnStyles[1].SizeType = SizeType.Percent;
            this.Table.ColumnStyles[1].Width = 50;
            this.Table.RowStyles[0].SizeType = SizeType.Percent;
            this.Table.RowStyles[0].Height = 50;
            this.Table.RowStyles[1].SizeType = SizeType.Percent;
            this.Table.RowStyles[1].Height = 50;
        }
		
		#endregion 
    }
}

