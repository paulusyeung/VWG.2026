#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Microsoft.Reporting.WebForms;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace CompanionKit.Concepts.Context
{
    public partial class ContextPage : UserControl
    {
        public ContextPage()
        {
            InitializeComponent();

            LoadContextParams();
            LoadSessionParams();
            LoadApplicationParams();
            LoadCookiesParams();
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonSave1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonSave1_Click(object sender, System.EventArgs e)
        {
            this.Context["ParameterA"] = this.mobjParameterATxt1.Text;
            this.Context["ParameterB"] = this.mobjParameterBTxt1.Text;
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonLoad1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonLoad1_Click(object sender, System.EventArgs e)
        {
            LoadContextParams();
        }

        /// <summary>
        /// Loads the context params.
        /// </summary>
        private void LoadContextParams()
        {
            this.mobjParameterATxt1.Text = GetContextParameter("ParameterA");
            this.mobjParameterBTxt1.Text = GetContextParameter("ParameterB");
        }

        /// <summary>
        /// Loads the session params.
        /// </summary>
        private void LoadSessionParams()
        {
            this.mobjParameterATxt3.Text = GetSessionParameter("ParameterA");
            this.mobjParameterBTxt3.Text = GetSessionParameter("ParameterB");
        }

        /// <summary>
        /// Loads the application params.
        /// </summary>
        private void LoadApplicationParams()
        {
            this.mobjParameterATxt4.Text = GetApplicationParameter("ParameterA");
            this.mobjParameterBTxt4.Text = GetApplicationParameter("ParameterB");
        }

        /// <summary>
        /// Loads the cookies params.
        /// </summary>
        private void LoadCookiesParams()
        {
            this.mobjParameterATxt2.Text = GetCookiesParameter("ParameterA");
            this.mobjParameterBTxt2.Text = GetCookiesParameter("ParameterB");
        }

        /// <summary>
        /// Gets the context parameter.
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <returns></returns>
        private string GetContextParameter(string strKey)
        {
            object objValue = VWGContext.Current[strKey];
            if (objValue != null)
            {
                return objValue.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the session parameter.
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <returns></returns>
        private string GetSessionParameter(string strKey)
        {
            object objValue = VWGContext.Current.Session[strKey];
            if (objValue != null)
            {
                return objValue.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the cookies parameter.
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <returns></returns>
        private string GetCookiesParameter(string strKey)
        {
            object objValue = VWGContext.Current.Cookies[strKey];
            if (objValue != null)
            {
                return objValue.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the application parameter.
        /// </summary>
        /// <param name="strKey">The STR key.</param>
        /// <returns></returns>
        private string GetApplicationParameter(string strKey)
        {
            object objValue = VWGContext.Current.Application[strKey];
            if (objValue != null)
            {
                return objValue.ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonSave3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonSave3_Click(object sender, System.EventArgs e)
        {
            lock (mobjLock)
            {
                VWGContext.Current.Session["ParameterA"] = this.mobjParameterATxt3.Text;
                VWGContext.Current.Session["ParameterB"] = this.mobjParameterBTxt3.Text;
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonSave4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonSave4_Click(object sender, System.EventArgs e)
        {
            lock (mobjLock)
            {
                VWGContext.Current.Application["ParameterA"] = this.mobjParameterATxt4.Text;
                VWGContext.Current.Application["ParameterB"] = this.mobjParameterBTxt4.Text;
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonLoad3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonLoad3_Click(object sender, System.EventArgs e)
        {
            LoadSessionParams();
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonLoad4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonLoad4_Click(object sender, System.EventArgs e)
        {
            LoadApplicationParams();
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonLoad2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonLoad2_Click(object sender, System.EventArgs e)
        {
            LoadCookiesParams();
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonSave2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonSave2_Click(object sender, System.EventArgs e)
        {
            VWGContext.Current.Cookies["ParameterA"] = this.mobjParameterATxt2.Text;
            VWGContext.Current.Cookies["ParameterB"] = this.mobjParameterBTxt2.Text;
        }
    }
}