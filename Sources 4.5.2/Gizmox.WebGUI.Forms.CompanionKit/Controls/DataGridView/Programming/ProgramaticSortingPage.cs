#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Collections;

#endregion

namespace CompanionKit.Controls.DataGridView.Programming
{
    public partial class ProgramaticSortingPage : UserControl
    {
        private int _sortColumn = -1;
        private SortOrder _sortOrder = SortOrder.Ascending;

        private DataGridViewItemComparer _numericComparer = null;
        private DataGridViewItemComparer _stringComparer = null;

		public ProgramaticSortingPage()
        {
            InitializeComponent();
        }

        private void ProgramaticSortingPage_Load(object sender, EventArgs e)
        {
          
            // compare by number
			_numericComparer = new NumericComparer(0, SortOrder.Ascending);

			// compare by text
			_stringComparer = new StringComparer(1, SortOrder.Ascending, CaseInsensitiveComparer.Default);	
				
            // Fill up DataGridView
            for (int i = 1; i < 20; ++i)
            {
                this.mobjDataGridView.Rows.Add((20-i).ToString(), string.Format("User{0}", i), string.Format("user{0}@gmail.com", i),
                                         string.Format("8-800-236589{0}", i), "Franklin",
                                         string.Format("10{0} Murfreeboro Rd.", i), "USA", "Tennessee", "37064");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Call the sort method to manually sort.
            this.mobjDataGridView.Sort(GetComparatorForColumn(e.ColumnIndex));
        }

        /// <summary>
        /// Gets comparator for the specified column
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private DataGridViewItemComparer GetComparatorForColumn(int columnIndex)
        {
            // Select comparator according to column index
            DataGridViewItemComparer itemComparer = null;
            switch (columnIndex)
            {
                case 0:
                    itemComparer = _numericComparer;
                    break;
                default:
                    itemComparer = _stringComparer;
                    break;
            }

            itemComparer.Column = columnIndex;
            // Determine whether the column is the same as the last column clicked.
            if (columnIndex != _sortColumn)
            {
                // Set the sort column to the new column.
                _sortColumn = columnIndex;
                // Set the sort order to ascending by default.
                _sortOrder = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
				_sortOrder  = (_sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
				
            }
            itemComparer.Order = _sortOrder;

            return itemComparer;
        }

        // Implements comparator for the custom sorting of items by columns.
        public abstract class  DataGridViewItemComparer : IComparer
        {
            protected int column;
            protected SortOrder order;
            public DataGridViewItemComparer(int Column, SortOrder order)
            {
                this.column = Column;
                this.order = order;
            }

            public int Column
            {
                set
                {
                    column = value;
                }
            }

            public SortOrder Order
            {
                set
                {
                    order = value;
                }
            }

            public abstract int Compare(object x, object y);
        }

        /// <summary>
        /// Implements a class for comparison of DataGridView items
        /// according to a numeric data in the given column
        /// </summary>
        public class NumericComparer : DataGridViewItemComparer
        {
            public NumericComparer(int Column, SortOrder order)
                :base(Column, order)
            {
            }

            public override int Compare(object x, object y)
            {
                DataGridViewRow dataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
                int returnVal =
                    Int32.Parse(dataGridViewRow1.Cells[column].Value.ToString()) -
                    Int32.Parse(dataGridViewRow2.Cells[column].Value.ToString());

                return order == SortOrder.Ascending ? returnVal : returnVal * -1;
            }
        }

        /// <summary>
        /// Implements a class for comparison of DataGridView items
        /// according to a literal data in the given column
        /// by the given IComparer object
        /// </summary>		
        public class StringComparer : DataGridViewItemComparer
        {
            IComparer mobjComparer = null;

            public StringComparer(int Column, SortOrder order, IComparer StringComparer)
                :base(Column, order)
            {
                mobjComparer = StringComparer;
            }

            public override int Compare(object x, object y)
            {
                DataGridViewRow dataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow dataGridViewRow2 = (DataGridViewRow)y;
                int returnVal = mobjComparer.Compare(
                    dataGridViewRow1.Cells[column].Value.ToString(),
                    dataGridViewRow2.Cells[column].Value.ToString());
                return order == SortOrder.Ascending ? returnVal : returnVal * -1;
            }
        }


    }
}
