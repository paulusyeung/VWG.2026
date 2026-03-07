using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.MonthCalendar.ApplicationScenarios
{
    public partial class OpenDatePageWikipediaPage : UserControl
    {
        public OpenDatePageWikipediaPage()
        {
            InitializeComponent();

			// set the initial value
			this.mobjDemoMonthCalendar.Value = DateTime.Now;
        }

		public string GetUrl(DateTime objDate)
		{
			CultureInfo mobjCulture = new CultureInfo("en-US");
			return string.Format("http://en.wikipedia.org/wiki/{0}", objDate.ToString("MMMM_d", mobjCulture));
		}

         /// <summary>
        /// Handles Load event of the example' UserControl.
        /// </summary>
        private void OpenDatePageWikipediaPage_Load(object sender, EventArgs e)
        {
            // Set initial pages for HTLMBox
			this.mobjWikiPageHtmlBox.Url = this.GetUrl(this.mobjDemoMonthCalendar.Value);
        }

        /// <summary>
        /// Handles ValueChanged event of the demonstrated MonthCalendar
        /// </summary>
		private void mobjDemoMonthCalendar_ValueChanged(object sender, EventArgs e)
		{
			this.mobjWikiPageHtmlBox.Url = this.GetUrl(this.mobjDemoMonthCalendar.Value);
		}
    }
}