using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;

namespace Gizmox.WebGUI.Forms
{
    internal partial class AdministrationFormBase : Form, IAdministrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui Form Designer generated code

        private void InitializeComponent()
        {
            mobjLogo = new PictureBox();
            mobjFooterLogo = new PictureBox();
            mobjTopPanel = new Panel();
            mobjFooterPanelTop = new AdministrationFooterPanel();
            mobjFooterPanel = new Panel();
            mobjHeaderLabel = new AdministrationHeaderLabel();
            //
            // mobjTopPanelTop
            //
            mobjFooterPanelTop.Height = 30;
            mobjFooterPanelTop.Controls.Add(mobjFooterLogo);
            mobjFooterPanelTop.Dock = DockStyle.Top;
            mobjFooterPanelTop.BorderWidth = new Forms.BorderWidth(0, 0, 0, 1);
            mobjFooterPanelTop.BorderColor = Color.LightGray;
            mobjFooterPanelTop.BorderStyle = Forms.BorderStyle.FixedSingle;
            mobjFooterPanelTop.DockPadding.Right = 50;
            mobjFooterPanelTop.DockPadding.Left = 3;
            mobjFooterPanelTop.DockPadding.Top = 3;
            //
            // mobjFooterLogo
            //
            mobjFooterLogo.Image = new Gizmox.WebGUI.Common.Resources.AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.LogoBottom.png");
            mobjFooterLogo.Dock = DockStyle.Right;
            mobjFooterLogo.Width = 216;
            //
            // objHeaderLabel
            //
            mobjHeaderLabel.Dock = DockStyle.Fill;
            mobjHeaderLabel.TextAlign = ContentAlignment.BottomLeft;
            //
            // mobjLogo
            //
            mobjLogo.Image = new Gizmox.WebGUI.Common.Resources.AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.LogoTop.png");
            mobjLogo.Dock = DockStyle.Left;
            mobjLogo.Width = 236;
            //
            // mobjFooterPanel
            //
            mobjFooterPanel.Dock = DockStyle.Bottom;
            mobjFooterPanel.Height = 50;
            mobjFooterPanel.Controls.Add(mobjFooterPanelTop);
            //
            // mobjTopPanel
            //
            mobjTopPanel.Dock = DockStyle.Top;
            mobjTopPanel.Height = 64;
            mobjTopPanel.Controls.Add(mobjHeaderLabel);
            mobjTopPanel.Controls.Add(mobjLogo);
            mobjTopPanel.VisualEffect = new BoxShadowVisualEffect(0, 5, 35, 0, Color.FromArgb(1, 68,68,68), false);
            mobjTopPanel.DockPadding.Top = 17;
            mobjTopPanel.DockPadding.Bottom = 17;
            mobjTopPanel.DockPadding.Left = 50;
            //
            // this
            //
            this.Text = "Administration";
            this.Controls.Add(mobjTopPanel);
            this.Controls.Add(mobjFooterPanel);
        }

        private PictureBox mobjLogo;
        private PictureBox mobjFooterLogo;
        private AdministrationFooterPanel mobjFooterPanelTop;
        private Panel mobjTopPanel;
        private Panel mobjFooterPanel;
        private AdministrationHeaderLabel mobjHeaderLabel;

        #endregion
    }
}
