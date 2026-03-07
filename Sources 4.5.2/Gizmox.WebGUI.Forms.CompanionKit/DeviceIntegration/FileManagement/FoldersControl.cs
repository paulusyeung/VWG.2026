using System;
using System.Collections.Generic;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.FileManagement;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.CustomControls;

namespace Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class FoldersControl : UserControl
    {
        private EventHandler<EntryEventArgs> mobjDirectoryChanged;
        private Label mobjHeaderLabel;
        private FileManagerFoldersListView mobjListView;
        private IDirectoryEntry mobjDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersControl"/> class.
        /// </summary>
        public FoldersControl()
        {
            InitializeComponent();

            this.mobjListView.ListViewItemSorter = new DirectoryContentsComparer();
        }

        /// <summary>
        /// Gets the list view.
        /// </summary>
        public ListView ListView
        {
            get { return mobjListView; }
        }

        public void LoadFolder(IEntry objEntry)
        {
            if (objEntry.IsDirectory)
            {
                LoadFolder(objEntry as IDirectoryEntry);
            }
        }

        public void LoadFolder(IDirectoryEntry objDirectory)
        {
            mobjDirectory = objDirectory;
            this.mobjListView.Items.Clear();

            IDirectoryReader objReader = mobjDirectory.CreateReader();

            objReader.ReadEntries(FolderReaderComplete);
            if (mobjDirectoryChanged != null)
            {
                mobjDirectoryChanged(this, new EntryEventArgs(objDirectory));
            }
        }

        private void FolderReaderComplete(object sender, DirectoryReaderEventArgs objDirectoryReaderArguments)
        {
            if (!objDirectoryReaderArguments.HasError)
            {
                this.mobjHeaderLabel.Text = "\\" + mobjDirectory.Name;

                foreach (IEntry objEntry in objDirectoryReaderArguments.Entries)
                {
                    ListViewItem item;

                    if (objEntry.IsFile)
                    {
                        item = new ListViewItem(new ImageResourceHandle("File.png").ToString());
                    }
                    else
                    {
                        item = new ListViewItem(new ImageResourceHandle("Folder.png").ToString());
                    }

                    item.Tag = objEntry;
                    item.SubItems.Add(objEntry.Name);

                    mobjListView.Items.Add(item);
                }

                mobjListView.Sort();
            }
        }

        private void InitializeComponent()
        {
            Gizmox.WebGUI.Forms.ColumnHeader mobjImageColumn;
            Gizmox.WebGUI.Forms.ColumnHeader mobjName;
            this.mobjHeaderLabel = new Gizmox.WebGUI.Forms.Label();
            this.mobjListView = new Gizmox.WebGUI.Forms.CompanionKit.DeviceIntegration.FileManagement.CustomControls.FileManagerFoldersListView();
            mobjImageColumn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            mobjName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mobjImageColumn
            // 
            mobjImageColumn.Text = "Type";
            mobjImageColumn.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            mobjImageColumn.Width = 50;
            // 
            // mobjName
            // 
            mobjName.Text = "Name";
            mobjName.Width = 300;
            // 
            // mobjHeaderLabel
            // 
            this.mobjHeaderLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.mobjHeaderLabel.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.mobjHeaderLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjHeaderLabel.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mobjHeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.mobjHeaderLabel.Name = "mobjHeaderLabel";
            this.mobjHeaderLabel.Size = new System.Drawing.Size(660, 30);
            this.mobjHeaderLabel.TabIndex = 0;
            this.mobjHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.mobjListView.AutoGenerateColumns = true;
            this.mobjListView.CheckBoxes = true;
            this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            mobjImageColumn,
            mobjName});
            this.mobjListView.CustomStyle = "FileManagerFoldersListViewSkin";
            this.mobjListView.DataMember = null;
            this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListView.FullRowSelect = true;
            this.mobjListView.HeaderStyle = Gizmox.WebGUI.Forms.ColumnHeaderStyle.Nonclickable;
            this.mobjListView.ItemsPerPage = 20;
            this.mobjListView.Location = new System.Drawing.Point(0, 30);
            this.mobjListView.MultiSelect = false;
            this.mobjListView.Name = "listView1";
            this.mobjListView.ShowItemToolTips = false;
            this.mobjListView.Size = new System.Drawing.Size(660, 571);
            this.mobjListView.TabIndex = 1;
            this.mobjListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // FoldersControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mobjListView);
            this.Controls.Add(this.mobjHeaderLabel);
            this.Size = new System.Drawing.Size(660, 601);
            this.ResumeLayout(false);

        }

        private string GetIcon(string strName)
        {
            return (new IconResourceHandle(strName)).ToString();
        }

        private class DirectoryContentsComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Component objX = x as Component;
                Component objY = y as Component;

                if (objX != null && objY != null)
                {
                    IEntry objEntryX = objX.Tag as IEntry;
                    IEntry objEntryY = objY.Tag as IEntry;

                    if (objEntryX != null && objEntryY != null)
                    {
                        if (objEntryX.IsDirectory)
                        {
                            if (objEntryY.IsDirectory)
                            {
                                return string.Compare(objEntryX.Name, objEntryY.Name);
                            }

                            return -1;
                        }
                        else
                        {
                            if (objEntryY.IsFile)
                            {
                                return string.Compare(objEntryX.Name, objEntryY.Name);
                            }

                            return 1;
                        }
                    }
                }

                return 0;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public IDirectoryEntry CurrentDirectory
        {
            get { return mobjDirectory; }
        }

        public event EventHandler<EntryEventArgs> DirectoryChanged
        {
            add { mobjDirectoryChanged += value; }
            remove { mobjDirectoryChanged -= value; }
        }

        internal void Reload()
        {
            this.LoadFolder(mobjDirectory);
        }

        private int mintLastCheckedIndex = -1;

        private void listView1_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {

        }
    }
}