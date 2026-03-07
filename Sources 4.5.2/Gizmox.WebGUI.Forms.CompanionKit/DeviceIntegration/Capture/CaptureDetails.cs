using System;
using System.Collections.Generic;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Device.Capture;

namespace CompanionKit.DeviceIntegration.Capture
{
    [Serializable]
    public class CaptureDetails : UserControl
    {
        private Label mobjSize;
        private Label mobjLastModifiedDate;
        private Label mobjType;
        private Label mobjPath;
        private Label mobjName;
        private Panel panel1;
        private Panel panel3;
        private Panel mobjPanel;
        private Label mobjPathText;
        private Label mobjNameText;
        private Label mobjTypeText;
        private Label mobjLastModifiedText;
        private Label mobjSizeText;
        private Label mobjDurationText;
        private Label mobjWidthText;
        private Label mobjHeightText;
        private Label mobjBitrateText;
        private Label mobjCodecsText;
        private Panel panel2;
        private Label mobjDuration;
        private Label mobjWidth;
        private Label mobjHeight;
        private Label mobjBitrate;
        private Label mobjCodecs;
        private Panel panel4;
        private ExpandableGroupBox mobjMoreDetailsBox;
        private IMediaFile mobjMediaFile;

        internal IMediaFile MediaFile
        {
            get { return mobjMediaFile; }
        }
    
        public CaptureDetails()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.mobjName = new Gizmox.WebGUI.Forms.Label();
            this.mobjPath = new Gizmox.WebGUI.Forms.Label();
            this.mobjType = new Gizmox.WebGUI.Forms.Label();
            this.mobjLastModifiedDate = new Gizmox.WebGUI.Forms.Label();
            this.mobjSize = new Gizmox.WebGUI.Forms.Label();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanel = new Gizmox.WebGUI.Forms.Panel();
            this.mobjSizeText = new Gizmox.WebGUI.Forms.Label();
            this.mobjLastModifiedText = new Gizmox.WebGUI.Forms.Label();
            this.mobjTypeText = new Gizmox.WebGUI.Forms.Label();
            this.mobjPathText = new Gizmox.WebGUI.Forms.Label();
            this.mobjNameText = new Gizmox.WebGUI.Forms.Label();
            this.mobjDurationText = new Gizmox.WebGUI.Forms.Label();
            this.mobjWidthText = new Gizmox.WebGUI.Forms.Label();
            this.mobjHeightText = new Gizmox.WebGUI.Forms.Label();
            this.mobjBitrateText = new Gizmox.WebGUI.Forms.Label();
            this.mobjCodecsText = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjDuration = new Gizmox.WebGUI.Forms.Label();
            this.mobjWidth = new Gizmox.WebGUI.Forms.Label();
            this.mobjHeight = new Gizmox.WebGUI.Forms.Label();
            this.mobjBitrate = new Gizmox.WebGUI.Forms.Label();
            this.mobjCodecs = new Gizmox.WebGUI.Forms.Label();
            this.panel4 = new Gizmox.WebGUI.Forms.Panel();
            this.mobjMoreDetailsBox = new Gizmox.WebGUI.Forms.ExpandableGroupBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mobjPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mobjMoreDetailsBox)).BeginInit();
            this.mobjMoreDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobjName
            // 
            this.mobjName.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjName.Location = new System.Drawing.Point(0, 39);
            this.mobjName.Name = "mobjName";
            this.mobjName.Size = new System.Drawing.Size(310, 35);
            this.mobjName.TabIndex = 0;
            this.mobjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjPath
            // 
            this.mobjPath.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPath.Location = new System.Drawing.Point(0, 19);
            this.mobjPath.Name = "mobjPath";
            this.mobjPath.Size = new System.Drawing.Size(310, 35);
            this.mobjPath.TabIndex = 0;
            this.mobjPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjType
            // 
            this.mobjType.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjType.Location = new System.Drawing.Point(0, 38);
            this.mobjType.Name = "mobjType";
            this.mobjType.Size = new System.Drawing.Size(310, 35);
            this.mobjType.TabIndex = 0;
            this.mobjType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLastModifiedDate
            // 
            this.mobjLastModifiedDate.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLastModifiedDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjLastModifiedDate.Location = new System.Drawing.Point(0, 57);
            this.mobjLastModifiedDate.Name = "mobjLastModifiedDate";
            this.mobjLastModifiedDate.Size = new System.Drawing.Size(310, 35);
            this.mobjLastModifiedDate.TabIndex = 0;
            this.mobjLastModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjSize
            // 
            this.mobjSize.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjSize.Location = new System.Drawing.Point(0, 76);
            this.mobjSize.Name = "mobjSize";
            this.mobjSize.Size = new System.Drawing.Size(310, 35);
            this.mobjSize.TabIndex = 0;
            this.mobjSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.mobjPanel);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 165);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mobjSize);
            this.panel3.Controls.Add(this.mobjLastModifiedDate);
            this.panel3.Controls.Add(this.mobjType);
            this.panel3.Controls.Add(this.mobjPath);
            this.panel3.Controls.Add(this.mobjName);
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(100, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 100);
            this.panel3.TabIndex = 1;
            // 
            // mobjPanel
            // 
            this.mobjPanel.Controls.Add(this.mobjSizeText);
            this.mobjPanel.Controls.Add(this.mobjLastModifiedText);
            this.mobjPanel.Controls.Add(this.mobjTypeText);
            this.mobjPanel.Controls.Add(this.mobjPathText);
            this.mobjPanel.Controls.Add(this.mobjNameText);
            this.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.mobjPanel.Location = new System.Drawing.Point(0, 0);
            this.mobjPanel.Name = "mobjPanel";
            this.mobjPanel.Size = new System.Drawing.Size(100, 100);
            this.mobjPanel.TabIndex = 0;
            this.mobjPanel.Text = "Last Modified:";
            // 
            // mobjSizeText
            // 
            this.mobjSizeText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjSizeText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjSizeText.Location = new System.Drawing.Point(0, 111);
            this.mobjSizeText.Name = "mobjSizeText";
            this.mobjSizeText.Size = new System.Drawing.Size(100, 35);
            this.mobjSizeText.TabIndex = 0;
            this.mobjSizeText.Text = "Size:";
            this.mobjSizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjLastModifiedText
            // 
            this.mobjLastModifiedText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjLastModifiedText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjLastModifiedText.Location = new System.Drawing.Point(0, 88);
            this.mobjLastModifiedText.Name = "mobjLastModifiedText";
            this.mobjLastModifiedText.Size = new System.Drawing.Size(100, 35);
            this.mobjLastModifiedText.TabIndex = 0;
            this.mobjLastModifiedText.Text = "Last Modified:";
            this.mobjLastModifiedText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjTypeText
            // 
            this.mobjTypeText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjTypeText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjTypeText.Location = new System.Drawing.Point(0, 65);
            this.mobjTypeText.Name = "mobjTypeText";
            this.mobjTypeText.Size = new System.Drawing.Size(100, 35);
            this.mobjTypeText.TabIndex = 0;
            this.mobjTypeText.Text = "Type:";
            this.mobjTypeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjPathText
            // 
            this.mobjPathText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjPathText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjPathText.Location = new System.Drawing.Point(0, 19);
            this.mobjPathText.Name = "mobjPathText";
            this.mobjPathText.Size = new System.Drawing.Size(100, 35);
            this.mobjPathText.TabIndex = 0;
            this.mobjPathText.Text = "File Path:";
            this.mobjPathText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjNameText
            // 
            this.mobjNameText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjNameText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjNameText.Location = new System.Drawing.Point(0, 0);
            this.mobjNameText.Name = "mobjNameText";
            this.mobjNameText.Size = new System.Drawing.Size(100, 35);
            this.mobjNameText.TabIndex = 0;
            this.mobjNameText.Text = "Name:";
            this.mobjNameText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjDurationText
            // 
            this.mobjDurationText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDurationText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjDurationText.Location = new System.Drawing.Point(0, 76);
            this.mobjDurationText.Name = "mobjDurationText";
            this.mobjDurationText.Size = new System.Drawing.Size(100, 35);
            this.mobjDurationText.TabIndex = 0;
            this.mobjDurationText.Text = "Duration:";
            this.mobjDurationText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjWidthText
            // 
            this.mobjWidthText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWidthText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjWidthText.Location = new System.Drawing.Point(0, 57);
            this.mobjWidthText.Name = "mobjWidthText";
            this.mobjWidthText.Size = new System.Drawing.Size(100, 35);
            this.mobjWidthText.TabIndex = 0;
            this.mobjWidthText.Text = "Width:";
            this.mobjWidthText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjHeightText
            // 
            this.mobjHeightText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjHeightText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjHeightText.Location = new System.Drawing.Point(0, 38);
            this.mobjHeightText.Name = "mobjHeightText";
            this.mobjHeightText.Size = new System.Drawing.Size(100, 35);
            this.mobjHeightText.TabIndex = 0;
            this.mobjHeightText.Text = "Height:";
            this.mobjHeightText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjBitrateText
            // 
            this.mobjBitrateText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjBitrateText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjBitrateText.Location = new System.Drawing.Point(0, 19);
            this.mobjBitrateText.Name = "mobjBitrateText";
            this.mobjBitrateText.Size = new System.Drawing.Size(100, 35);
            this.mobjBitrateText.TabIndex = 0;
            this.mobjBitrateText.Text = "Bitrate:";
            this.mobjBitrateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCodecsText
            // 
            this.mobjCodecsText.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCodecsText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjCodecsText.Location = new System.Drawing.Point(0, 0);
            this.mobjCodecsText.Name = "mobjCodecsText";
            this.mobjCodecsText.Size = new System.Drawing.Size(100, 35);
            this.mobjCodecsText.TabIndex = 0;
            this.mobjCodecsText.Text = "Codecs:";
            this.mobjCodecsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mobjDurationText);
            this.panel2.Controls.Add(this.mobjWidthText);
            this.panel2.Controls.Add(this.mobjHeightText);
            this.panel2.Controls.Add(this.mobjBitrateText);
            this.panel2.Controls.Add(this.mobjCodecsText);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 319);
            this.panel2.TabIndex = 0;
            this.panel2.Text = "Last Modified:";
            // 
            // mobjDuration
            // 
            this.mobjDuration.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjDuration.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjDuration.Location = new System.Drawing.Point(0, 76);
            this.mobjDuration.Name = "mobjDuration";
            this.mobjDuration.Size = new System.Drawing.Size(304, 35);
            this.mobjDuration.TabIndex = 0;
            this.mobjDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjWidth
            // 
            this.mobjWidth.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjWidth.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjWidth.Location = new System.Drawing.Point(0, 57);
            this.mobjWidth.Name = "mobjWidth";
            this.mobjWidth.Size = new System.Drawing.Size(304, 35);
            this.mobjWidth.TabIndex = 0;
            this.mobjWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjHeight
            // 
            this.mobjHeight.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjHeight.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjHeight.Location = new System.Drawing.Point(0, 38);
            this.mobjHeight.Name = "mobjHeight";
            this.mobjHeight.Size = new System.Drawing.Size(304, 35);
            this.mobjHeight.TabIndex = 0;
            this.mobjHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjBitrate
            // 
            this.mobjBitrate.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjBitrate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjBitrate.Location = new System.Drawing.Point(0, 19);
            this.mobjBitrate.Name = "mobjBitrate";
            this.mobjBitrate.Size = new System.Drawing.Size(304, 35);
            this.mobjBitrate.TabIndex = 0;
            this.mobjBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mobjCodecs
            // 
            this.mobjCodecs.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjCodecs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mobjCodecs.Location = new System.Drawing.Point(0, 39);
            this.mobjCodecs.Name = "mobjCodecs";
            this.mobjCodecs.Size = new System.Drawing.Size(304, 35);
            this.mobjCodecs.TabIndex = 0;
            this.mobjCodecs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.mobjDuration);
            this.panel4.Controls.Add(this.mobjWidth);
            this.panel4.Controls.Add(this.mobjHeight);
            this.panel4.Controls.Add(this.mobjBitrate);
            this.panel4.Controls.Add(this.mobjCodecs);
            this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 319);
            this.panel4.TabIndex = 1;
            // 
            // mobjMoreDetailsBox
            // 
            this.mobjMoreDetailsBox.Controls.Add(this.panel4);
            this.mobjMoreDetailsBox.Controls.Add(this.panel2);
            this.mobjMoreDetailsBox.CustomStyle = "X";
            this.mobjMoreDetailsBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMoreDetailsBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.mobjMoreDetailsBox.IsExpanded = false;
            this.mobjMoreDetailsBox.Location = new System.Drawing.Point(0, 165);
            this.mobjMoreDetailsBox.Name = "mobjMoreDetailsBox";
            this.mobjMoreDetailsBox.Size = new System.Drawing.Size(410, 339);
            this.mobjMoreDetailsBox.TabIndex = 1;
            this.mobjMoreDetailsBox.Text = "Show more details";
            this.mobjMoreDetailsBox.Expand += new System.EventHandler(this.mobjMoreDetailsBox_Expand);
            this.mobjMoreDetailsBox.Visible = false;
            // 
            // CaptureDetails
            // 
            this.Controls.Add(this.mobjMoreDetailsBox);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(410, 527);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.mobjPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mobjMoreDetailsBox)).EndInit();
            this.mobjMoreDetailsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMediaFile(IMediaFile objMediaFile)
        {
            this.mobjMoreDetailsBox.Visible = true;

            mobjMediaFile = objMediaFile;
            this.mobjName.Text = objMediaFile.Name;
            this.mobjPath.Text = objMediaFile.FullPath;
            this.mobjType.Text = objMediaFile.Type;
            this.mobjLastModifiedDate.Text = objMediaFile.LastModifiedDate.ToString();
            this.mobjSize.Text = objMediaFile.Size.ToString();

            this.mobjBitrate.Text = string.Empty;
            this.mobjCodecs.Text = string.Empty;
            this.mobjHeight.Text = string.Empty;
            this.mobjWidth.Text = string.Empty;
            this.mobjDuration.Text = string.Empty;
        }

        private void GotMetadata(object sender, MediaFileDataEventArgs objArguments)
        {
            if (!objArguments.HasError)
            {
                this.mobjBitrate.Text = GetString(objArguments.MediaFileData.Bitrate.ToString());
                this.mobjCodecs.Text = GetString(objArguments.MediaFileData.Codecs.ToString());
                this.mobjHeight.Text = GetString(objArguments.MediaFileData.Height.ToString());
                this.mobjWidth.Text = GetString(objArguments.MediaFileData.Width.ToString());
                this.mobjDuration.Text = GetString(objArguments.MediaFileData.Duration.ToString());
            }
        }

        private string GetString(string strValue)
        {
            return string.IsNullOrEmpty(strValue) || strValue == "0" ? "N/A" : strValue;
        }

        private void mobjMoreDetailsBox_Expand(object sender, EventArgs e)
        {
            mobjMediaFile.GetFormatData(GotMetadata);
        }
    }
}