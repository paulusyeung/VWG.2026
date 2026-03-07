#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.MainMenu.Features
{
    public partial class MainMenuForm : Gizmox.WebGUI.Forms.Form
    {
        /// <summary>
        /// Represents type of sample app.
        /// </summary>
        private MainMenuSampleTypes _mainMenuSampleTypes = MainMenuSampleTypes.Icon;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates instance of the class.
        /// </summary>
        /// <param name="mainMenuSampleTypes">type of sample app.</param>
        public MainMenuForm(MainMenuSampleTypes mainMenuSampleTypes)
            : this()
        {
            _mainMenuSampleTypes = mainMenuSampleTypes;
        }

        /// <summary>
        /// Handles the Load event of the MainMenuForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // Set shortcut keys
            this.menuItem10.Shortcut = Shortcut.CtrlS;
            this.menuItem11.Shortcut = Shortcut.CtrlShiftS;
            this.menuItem16.Shortcut = Shortcut.CtrlP;

            this.menuItem24.Shortcut = Shortcut.CtrlShiftN;
            this.menuItem26.Shortcut = Shortcut.CtrlN;

            this.menuItem28.Shortcut = Shortcut.CtrlShiftO;
            this.menuItem30.Shortcut = Shortcut.CtrlO;

            this.menuItem39.Shortcut = Shortcut.CtrlZ;
            this.menuItem40.Shortcut = Shortcut.CtrlY;

            this.menuItem44.Shortcut = Shortcut.CtrlX;
            this.menuItem45.Shortcut = Shortcut.CtrlC;
            this.menuItem46.Shortcut = Shortcut.CtrlV;
            this.menuItem47.Shortcut = Shortcut.CtrlShiftV;
            this.menuItem48.Shortcut = Shortcut.Del;

            this.menuItem51.Shortcut = Shortcut.CtrlA;
            this.menuItem59.Shortcut = Shortcut.CtrlG;


            this.menuItem54.Shortcut = Shortcut.CtrlF;
            this.menuItem55.Shortcut = Shortcut.CtrlH;
            this.menuItem56.Shortcut = Shortcut.CtrlShiftF;
            this.menuItem57.Shortcut = Shortcut.CtrlShiftH;
            this.menuItem58.Shortcut = Shortcut.AltF12;

            this.menuItem70.Shortcut = Shortcut.CtrlShiftU;
            this.menuItem71.Shortcut = Shortcut.CtrlU;
            this.menuItem75.Shortcut = Shortcut.CtrlI;

            switch (_mainMenuSampleTypes)
            {
                case MainMenuSampleTypes.RadioBox :
                    this.mainMenu1.MenuItems.Add(this.menuItem117);
                    this.menuItemCheckedState.Text = string.Format("Select any menu item of the '{0}' menu!", this.menuItem117.Text);
                    break;
                case MainMenuSampleTypes.CheckBox :
                    this.mainMenu1.MenuItems.Add(this.menuItem112);
                    this.menuItemCheckedState.Text = string.Format("Select any menu item of the '{0}' menu!", this.menuItem112.Text);
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the menuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            String clickedMenuItem = menuItem.Text;
            Gizmox.WebGUI.Forms.Menu parentMenuItem = menuItem.Parent;
            while(parentMenuItem != null && parentMenuItem.GetType().Equals(typeof(MenuItem))) {
                clickedMenuItem = ((MenuItem)parentMenuItem).Text + "->" + clickedMenuItem;
                parentMenuItem = ((MenuItem)parentMenuItem).Parent;
            }
            this.representClickedMenuItemLabel.Text = string.Format("You selected the '{0}' menu item.", clickedMenuItem);
        }

        /// <summary>
        /// Handles the Click event of the menuItem23 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuItem23_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Handles the Click event of the menuItemCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuItemCheck_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            menuItem.Checked = !menuItem.Checked;
            this.menuItemCheckedState.Text = string.Format("Menu item '{0}' was {1} last time!", menuItem.Text, menuItem.Checked ? "checked" : "unchecked");
            menuItem_Click(sender, e);
        }


        /// <summary>
        /// Handles the Click event of the menuItemRadioCheck control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuItemRadioCheck_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if(menuItem == menuItem118) {
                this.menuItem118.Checked = true;
                this.menuItem119.Checked = false;
                this.menuItem123.Checked = false;
                this.menuItem124.Checked = false;
                this.menuItem125.Checked = false;
            }
            else if (menuItem == menuItem119)
            {
                this.menuItem118.Checked = false;
                this.menuItem119.Checked = true;
                this.menuItem123.Checked = false;
                this.menuItem124.Checked = false;
                this.menuItem125.Checked = false;
            } 
            else if(menuItem == menuItem123)
            {
                this.menuItem118.Checked = false;
                this.menuItem119.Checked = false;
                this.menuItem123.Checked = true;
                this.menuItem124.Checked = false;
                this.menuItem125.Checked = false;
            } 
            else if(menuItem == menuItem124)
            {
               this.menuItem118.Checked = false;
                this.menuItem119.Checked = false;
                this.menuItem123.Checked = false;
                this.menuItem124.Checked = true;
                this.menuItem125.Checked = false;
            }
            else if (menuItem == menuItem125)
            {
                this.menuItem118.Checked = false;
                this.menuItem119.Checked = false;
                this.menuItem123.Checked = false;
                this.menuItem124.Checked = false;
                this.menuItem125.Checked = true;
            }
            this.menuItemCheckedState.Text = string.Format("Menu item '{0}' was checked last time!", menuItem.Text);
            menuItem_Click(sender, e);
        }

        public enum MainMenuSampleTypes
        {
            Icon,
            KeyBoard,
            CheckBox,
            RadioBox
        }

    }
}