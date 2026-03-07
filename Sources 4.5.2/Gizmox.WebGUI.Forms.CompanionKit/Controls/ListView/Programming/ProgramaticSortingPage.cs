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

namespace CompanionKit.Controls.ListView.Programming
{
    public partial class ProgramaticSortingPage : UserControl
    {
		private ListViewComparer[] Comparers = null;

        public ProgramaticSortingPage()
        {
            InitializeComponent();

			Comparers = new ListViewComparer[]
			{
				// compare users by name (case insensitive)
				new StringComparer(0, SortOrder.Ascending, CaseInsensitiveComparer.Default),
				
				// compare by ID
				new NumericComparer(1, SortOrder.Ascending),
				
				// compare by phone (case insensitive)
				new StringComparer(2, SortOrder.Ascending, CaseInsensitiveComparer.Default)
			};

			// Set a custom implemented sorter
            this.mobjListView.ListViewItemSorter = Comparers[0];

            // Populate the ListView
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User A",	"6",  "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "user B",	"7",  "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User C",	"8",  "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "user D",	"9",  "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User E",	"10", "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "user F",	"12", "8-800-9513546" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User G",	"11", "8-800-8524563" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "user H",	"1",  "8-800-9874613" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "User Y",	"4",  "8-800-1234556" }));
            this.mobjListView.Items.Add(new ListViewItem(new string[] { "user Z",	"5",  "8-800-9513546" }));

			// sort the items on initialization
			this.mobjListView.Sort();
        }

        /// <summary>
        /// Handles the ColumnClick event of the mobjListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnClickEventArgs"/> instance containing the event data.</param>
        private void mobjListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
			// pick the column's comparer
			ListViewComparer objComparer = Comparers[e.Column];
			
			// set the comparer to the listview
			this.mobjListView.ListViewItemSorter = objComparer;

			// change the order to opposite one
			objComparer.Order = objComparer.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

            // Call the sort method
            this.mobjListView.Sort();
        }

		/// <summary>
		/// Implements a base class for comparison of ListView items per column
		/// </summary>
		public abstract class ListViewComparer : IComparer
        {
            protected int column;
            protected SortOrder order;

			public ListViewComparer(int Column, SortOrder Order)
            {
                column = Column;
                order = Order;
            }

            public int Column
            {
                set
                {
                    column = value;
                }
				get
				{
					return column;
				}
            }

            public SortOrder Order
            {
                set
                {
                    order = value;
                }
				get
				{
					return order;
				}
            }

			public abstract int Compare(object x, object y);
        }

		/// <summary>
		/// Implements a class for comparison of listview items
		/// according to a numeric data in the given column
		/// </summary>
		public class NumericComparer : ListViewComparer
		{
			public NumericComparer(int Column, SortOrder order):
				base(Column, order)
			{
			}
            
			public override int Compare(object x, object y)
            {
                int returnVal = 
					Int32.Parse(((ListViewItem)x).SubItems[column].Text) -
                    Int32.Parse(((ListViewItem)y).SubItems[column].Text);

                return order == SortOrder.Ascending ? returnVal : returnVal * -1;
            }
		}

		/// <summary>
		/// Implements a class for comparison of listview items
		/// according to a literal data in the given column
		/// by the given IComparer object
		/// </summary>		
		public class StringComparer : ListViewComparer
		{
			IComparer mobjComparer = null;

			public StringComparer(int Column, SortOrder order, IComparer StringComparer):
				base(Column, order)
			{
				mobjComparer = StringComparer;
			}

			public override int Compare(object x, object y)
            {
                int returnVal = mobjComparer.Compare( 
                    ((ListViewItem)x).SubItems[column].Text,
                    ((ListViewItem)y).SubItems[column].Text);
                return order == SortOrder.Ascending ? returnVal : returnVal * -1;
            }
		}

    }
}