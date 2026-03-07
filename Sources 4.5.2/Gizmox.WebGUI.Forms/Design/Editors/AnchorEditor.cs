using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{    
    
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class AnchorEditor : WebUITypeEditor
    {
		#region AnchorEditorDropDown Class


        [Serializable()]
        class AnchorEditorDropDown : Form
        {
            private AnchorPanel mobjPanelTop;
            private AnchorPanel mobjPanelBottom;
            private AnchorPanel mobjPanelLeft;
            private AnchorPanel mobjPanelRight;
            private Panel mobjPanelCenter;

            private bool mblnIsCompleted = true;

            private bool mblnTop = false;
            private bool mblnBottom = false;
            private bool mblnLeft = false;
            private bool mblnRight = false;

            private AnchorStyles mobjValue = AnchorStyles.None;

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjPanelTop = new AnchorPanel();
                this.mobjPanelBottom = new AnchorPanel();
                this.mobjPanelLeft = new AnchorPanel();
                this.mobjPanelRight = new AnchorPanel();
                this.mobjPanelCenter = new Panel();
                this.SuspendLayout();
                // 
                // mobjPanelTop
                // 
                this.mobjPanelTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.mobjPanelTop.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.mobjPanelTop.Location = new System.Drawing.Point(68, 0);
                this.mobjPanelTop.Name = "mobjPanelTop";
                this.mobjPanelTop.Size = new System.Drawing.Size(9, 25);
                this.mobjPanelTop.TabIndex = 0;
                this.mobjPanelTop.Click += new System.EventHandler(this.mobjPanelTop_Click);
                // 
                // mobjPanelBottom
                // 
                this.mobjPanelBottom.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.mobjPanelBottom.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.mobjPanelBottom.Location = new System.Drawing.Point(68, 67);
                this.mobjPanelBottom.Name = "mobjPanelBottom";
                this.mobjPanelBottom.Size = new System.Drawing.Size(9, 25);
                this.mobjPanelBottom.TabIndex = 1;
                this.mobjPanelBottom.Click += new System.EventHandler(this.mobjPanelBottom_Click);
                // 
                // mobjPanelLeft
                // 
                this.mobjPanelLeft.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.mobjPanelLeft.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.mobjPanelLeft.Location = new System.Drawing.Point(0, 41);
                this.mobjPanelLeft.Name = "mobjPanelLeft";
                this.mobjPanelLeft.Size = new System.Drawing.Size(25, 10);
                this.mobjPanelLeft.TabIndex = 2;
                this.mobjPanelLeft.Click += new System.EventHandler(this.mobjPanelLeft_Click);
                // 
                // mobjPanelRight
                // 
                this.mobjPanelRight.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.mobjPanelRight.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.mobjPanelRight.Location = new System.Drawing.Point(120, 41);
                this.mobjPanelRight.Name = "mobjPanelRight";
                this.mobjPanelRight.Size = new System.Drawing.Size(25, 10);
                this.mobjPanelRight.TabIndex = 3;
                this.mobjPanelRight.Click += new System.EventHandler(this.mobjPanelRight_Click);
                // 
                // mobjPanelCenter
                // 
                this.mobjPanelCenter.BackColor = Color.FromArgb(200,200,200);
                this.mobjPanelCenter.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.mobjPanelCenter.Location = new System.Drawing.Point(27, 27);
                this.mobjPanelCenter.Name = "mobjPanelCenter";
                this.mobjPanelCenter.Size = new System.Drawing.Size(91, 38);
                this.mobjPanelCenter.TabIndex = 4;
                // 
                // AnchorEditorDropDown
                // 
                this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Left;
                this.Controls.Add(this.mobjPanelCenter);
                this.Controls.Add(this.mobjPanelRight);
                this.Controls.Add(this.mobjPanelLeft);
                this.Controls.Add(this.mobjPanelBottom);
                this.Controls.Add(this.mobjPanelTop);
                this.DragTargets = new Gizmox.WebGUI.Forms.Control[0];
                this.Size = new System.Drawing.Size(145, 92);
                this.Text = "AnchorEditorDropDown";
                this.ResumeLayout(false);

            }

            #endregion

            /// <summary>
            /// Initializes a new instance of the <see cref="AnchorEditorDropDown"/> class.
            /// </summary>
            public AnchorEditorDropDown()
            {
                InitializeComponent();
            }

            private void mobjPanelTop_Click(object sender, EventArgs e)
            {
                this.mblnTop = !this.mblnTop;
                UpdateAnchoring();
                UpdateValue();
            }

            private void mobjPanelRight_Click(object sender, EventArgs e)
            {
                this.mblnRight = !this.mblnRight;
                UpdateAnchoring();
                UpdateValue();
            }

            private void mobjPanelLeft_Click(object sender, EventArgs e)
            {
                this.mblnLeft = !this.mblnLeft;
                UpdateAnchoring();
                UpdateValue();
            }

            private void mobjPanelBottom_Click(object sender, EventArgs e)
            {
                this.mblnBottom = !this.mblnBottom;
                UpdateAnchoring();
                UpdateValue();
            }


            private void UpdateAnchoring()
            {
                Color mobjUnSelectedColor = Color.White;
                Color mobjSelectedColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
                this.mobjPanelTop.BackColor = this.mblnTop ? mobjSelectedColor : mobjUnSelectedColor;
                this.mobjPanelBottom.BackColor = this.mblnBottom ? mobjSelectedColor : mobjUnSelectedColor;
                this.mobjPanelLeft.BackColor = this.mblnLeft ? mobjSelectedColor : mobjUnSelectedColor;
                this.mobjPanelRight.BackColor = this.mblnRight ? mobjSelectedColor : mobjUnSelectedColor;
            }

            private void UpdateValue()
            {
                AnchorStyles enmStyle = AnchorStyles.None;
                if (this.mblnLeft)
                {
                    enmStyle |= AnchorStyles.Left;
                }
                if (this.mblnTop)
                {
                    enmStyle |= AnchorStyles.Top;
                }
                if (this.mblnBottom)
                {
                    enmStyle |= AnchorStyles.Bottom;
                }
                if (this.mblnRight)
                {
                    enmStyle |= AnchorStyles.Right;
                }

                this.mobjValue = enmStyle;
            }

            public AnchorStyles Value
            {
                get
                {
                    return mobjValue;
                }
                set
                {
                    if (mobjValue != value)
                    {
                        this.mblnLeft = ((value & AnchorStyles.Left) == AnchorStyles.Left);
                        this.mblnRight = ((value & AnchorStyles.Right) == AnchorStyles.Right);
                        this.mblnTop = ((value & AnchorStyles.Top) == AnchorStyles.Top);
                        this.mblnBottom = ((value & AnchorStyles.Bottom) == AnchorStyles.Bottom);
                        UpdateAnchoring();
                        mobjValue = value;
                    }
                }
            }



            public bool IsCompleted
            {
                get
                {
                    return this.mblnIsCompleted;
                }
            }


        }

		#endregion

		#region Class Members

        private WebUITypeEditorHandler mobjHandler = null;

		private AnchorStyles mobjPropertyValue = AnchorStyles.None;

		#endregion Class Members

		#region C'Tor

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Create font dialog
            AnchorEditorDropDown objAnchorDialog = new AnchorEditorDropDown();
            objAnchorDialog.Value =  (AnchorStyles)GetEditorValueFromPropertyValue(objValue);
            objAnchorDialog.Closed += new EventHandler(objAnchorDialog_Closed);
            

			// Store the property value
			mobjPropertyValue = objAnchorDialog.Anchor;

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDropDown(objAnchorDialog);
            }
        }

		#endregion C'Tor

        private void objAnchorDialog_Closed(object sender, EventArgs e)
        {
            AnchorEditorDropDown objAnchorDialog = (AnchorEditorDropDown)sender;
            if (objAnchorDialog.IsCompleted)
            {
				if (mobjHandler != null)
				{
					object objValue = null;
					try
					{
						objValue = GetPropertyValueFromEditorValue(objAnchorDialog.Value);
					}
					catch (Exception objException)
					{
						this.OnValueChangeError(objException);
						return;
					}

					mobjHandler(objValue);
				}
            }
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <value>The property value.</value>
		protected AnchorStyles PropertyValue
		{
			get
			{
				return this.mobjPropertyValue;
			}
		}

    }


}
