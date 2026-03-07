using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Reflection;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Design
{
    
    /// <summary>
    /// Provides a WebUITypeEditor for visually picking a color.
    /// </summary>
    [Serializable()]
    public class ColorEditor : WebUITypeEditor
    {
        private WebUITypeEditorHandler mobjHandler = null;

		private Color mobjPropertyValue ;

        /// <summary>        
        /// Edits the given object value using the editor style provided by the GetEditStyle method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Create font dialog
            ColorEditorDropDown objColorDialog = new ColorEditorDropDown();
            objColorDialog.Color =  (Color)GetEditorValueFromPropertyValue(objValue);
            objColorDialog.Closed += new EventHandler(objColorDialog_Closed);

			// Store the property value
			mobjPropertyValue = objColorDialog.Color;

            // Store handler
            mobjHandler = objHandler;

            // Show dialog
            IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
            if (objEditorService != null)
            {
                objEditorService.ShowDropDown(objColorDialog);
            }
        }

        /// <summary>
        /// Supplies a editor level mechanism to convert property values before editing
        /// </summary>
        /// <param name="value">The property value.</param>
        /// <returns></returns>
		protected override object GetEditorValueFromPropertyValue(object objValue)
		{
            if (objValue == null)
			{
				return Color.Empty;
			}
			else
			{
                return objValue;
			}
		}

        /// <summary>
        /// Supplies a editor level mechanism to convert editor returned values before assigning to property
        /// </summary>
        /// <param name="value">The editor returned value.</param>
        /// <returns></returns>
		protected override object GetPropertyValueFromEditorValue(object objValue)
		{
            return objValue;
		}

        private void objColorDialog_Closed(object sender, EventArgs e)
        {
            ColorEditorDropDown objColorDialog = (ColorEditorDropDown)sender;
            if (objColorDialog.IsCompleted)
            {
				if (mobjHandler != null)
				{
					object objValue = null;
					try
					{
						objValue = GetPropertyValueFromEditorValue(objColorDialog.Color);
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
		protected Color PropertyValue
		{
			get
			{
				return this.mobjPropertyValue;
			}
		}

    }


    [Serializable()]
    class ColorEditorDropDown : Form
    {

        private TabControl mobjTabControl;
        private TabPage mobjTabCustom;
        private TabPage mobjTabWeb;
        private TabPage mobjTabSystem;
        private ColorListBox mobjListWeb;
        private ColorListBox mobjListSystem;

        private bool mblnIsCompleted = false;
        private Color mobjColor = Color.Empty;

        private static Color[] marrWebColors;
        private static Color[] marrSystemColors;

        public ColorEditorDropDown()
        {
            InitializeComponenet();

            this.Load += new EventHandler(ColorEditorDropDown_Load);
        }

        private void ColorEditorDropDown_Load(object sender, EventArgs e)
        {
            // Get the tabcontrol skin.
            TabControlSkin objTabControlSkin = this.mobjTabControl.TabControlCurrentSkin;
            if (objTabControlSkin != null)
            {
                // Increase the form's height as for the tab control's vertical frames heights.
                this.Height += (objTabControlSkin.TopFrameHeight + objTabControlSkin.BottomFrameHeight + objTabControlSkin.SeperatorFrameHeight);

                // Increase the form's width as for the tab control's horizontal frames widths.
                this.Width += (objTabControlSkin.LeftFrameWidth + objTabControlSkin.RightFrameWidth);
            }

            this.mobjTabControl.SelectedIndex = 0;

            mobjListSystem.Items.AddRange(GetSystemColors());

            mobjListWeb.Items.AddRange(GetWebColors());

            InitializePalette(mobjTabCustom, GetWebColors());
            
        }

        private static Color[] GetWebColors()
        {
            if (marrWebColors == null)
            {
                marrWebColors = GetConstants(typeof(Color));
            }
            return marrWebColors;
        }

        private static Color[] GetSystemColors()
        {
            if (marrSystemColors == null)
            {
                marrSystemColors = GetConstants(typeof(SystemColors));
            }
            return marrSystemColors;
        }

        private static Color[] GetConstants(Type objEnumType)
        {
            MethodAttributes enmAttributes1 = MethodAttributes.Static | MethodAttributes.Public;
            PropertyInfo[] arrPropertyInfos = objEnumType.GetProperties();
            ArrayList objList = new ArrayList();
            for (int num1 = 0; num1 < arrPropertyInfos.Length; num1++)
            {
                PropertyInfo objPropertyInfo = arrPropertyInfos[num1];
                if (objPropertyInfo.PropertyType == typeof(Color))
                {
                    MethodInfo objMethodInfo = objPropertyInfo.GetGetMethod();
                    if ((objMethodInfo != null) && ((objMethodInfo.Attributes & enmAttributes1) == enmAttributes1))
                    {
                        object[] arrObjects1 = null;
                        objList.Add(objPropertyInfo.GetValue(null, arrObjects1));
                    }
                }
            }
            return (Color[])objList.ToArray(typeof(Color));
        }

        private void InitializePalette(TabPage objTabPage,Color[] arrColors)
        {
            int intColor = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Panel objPanel = new Panel();
                    objPanel.Location = new Point(6+x * 26, 6+y * 26);
                    objPanel.Size = new Size(20, 20);
                    objPanel.BorderStyle = BorderStyle.FixedSingle;
                    objPanel.Click += new EventHandler(objPanel_Click);
                    if (arrColors.Length > intColor)
                    {
                        objPanel.Tag = objPanel.BackColor = arrColors[intColor];
                    }
                    else
                    {
                        objPanel.Tag = objPanel.BackColor = Color.White;
                    }
                    objTabPage.Controls.Add(objPanel);
                    intColor++;
                }
            }
        }




        private void InitializeComponenet()
        {
            this.mobjTabControl = new Gizmox.WebGUI.Forms.TabControl();
            this.mobjTabCustom = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjTabWeb = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjListWeb = new Gizmox.WebGUI.Forms.ColorListBox();
            this.mobjTabSystem = new Gizmox.WebGUI.Forms.TabPage();
            this.mobjListSystem = new Gizmox.WebGUI.Forms.ColorListBox();
            this.mobjTabControl.SuspendLayout();
            this.mobjTabWeb.SuspendLayout();
            this.mobjTabSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.mobjTabControl.Controls.Add(this.mobjTabCustom);
            this.mobjTabControl.Controls.Add(this.mobjTabWeb);
            this.mobjTabControl.Controls.Add(this.mobjTabSystem);
            this.mobjTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjTabControl.Location = new System.Drawing.Point(0, 0);
            this.mobjTabControl.Name = "tabControl1";
            this.mobjTabControl.SelectedIndex = 0;
            this.mobjTabControl.Size = new System.Drawing.Size(224, 242);
            this.mobjTabControl.TabIndex = 0;
            this.mobjTabControl.BorderStyle = BorderStyle.FixedSingle;
            this.mobjTabControl.Multiline = false;
            // 
            // mobjTabCustom
            // 
            this.mobjTabCustom.Location = new System.Drawing.Point(4, 22);
            this.mobjTabCustom.Name = "mobjTabCustom";
            this.mobjTabCustom.Padding = new Gizmox.WebGUI.Forms.Padding(2);
            this.mobjTabCustom.Size = new System.Drawing.Size(216, 216);
            this.mobjTabCustom.TabIndex = 0;
            this.mobjTabCustom.Text = "Custom";
            this.mobjTabCustom.AutoScroll = false;

            // 
            // mobjTabWeb
            // 
            this.mobjTabWeb.Controls.Add(this.mobjListWeb);
            this.mobjTabWeb.Location = new System.Drawing.Point(4, 22);
            this.mobjTabWeb.Name = "mobjTabWeb";
            this.mobjTabWeb.Padding = new Gizmox.WebGUI.Forms.Padding(2);
            this.mobjTabWeb.Size = new System.Drawing.Size(216, 216);
            this.mobjTabWeb.TabIndex = 1;
            this.mobjTabWeb.Text = "Web";


            // 
            // mobjListWeb
            // 
            this.mobjListWeb.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListWeb.FormattingEnabled = true;
            this.mobjListWeb.Location = new System.Drawing.Point(3, 3);
            this.mobjListWeb.Name = "mobjListWeb";
            this.mobjListWeb.Size = new System.Drawing.Size(210, 199);
            this.mobjListWeb.TabIndex = 0;
            this.mobjListWeb.SelectedIndexChanged += new EventHandler(mobjListWeb_SelectedIndexChanged);
            // 
            // mobjTabSystem
            // 
            this.mobjTabSystem.Controls.Add(this.mobjListSystem);
            this.mobjTabSystem.Location = new System.Drawing.Point(4, 22);
            this.mobjTabSystem.Name = "mobjTabSystem";
            this.mobjTabSystem.Size = new System.Drawing.Size(216, 216);
            this.mobjTabSystem.TabIndex = 2;
            this.mobjTabSystem.Text = "System";
            this.mobjTabSystem.Padding = new Padding(2);

            // 
            // mobjListSystem
            // 
            this.mobjListSystem.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjListSystem.FormattingEnabled = true;
            this.mobjListSystem.Location = new System.Drawing.Point(0, 0);
            this.mobjListSystem.Name = "mobjListSystem";
            this.mobjListSystem.Size = new System.Drawing.Size(216, 212);
            this.mobjListSystem.TabIndex = 0;
            this.mobjListSystem.SelectedIndexChanged += new EventHandler(mobjListSystem_SelectedIndexChanged);
            // 
            // ColorControl
            // 
            this.DockPadding.All = 2;
            this.ClientSize = new System.Drawing.Size(224, 242);
            this.Controls.Add(this.mobjTabControl);
            this.Name = "ColorControl";
            this.mobjTabControl.ResumeLayout(false);
            this.mobjTabWeb.ResumeLayout(false);
            this.mobjTabSystem.ResumeLayout(false);
            this.ResumeLayout(false);
        }


        private void objPanel_Click(object sender, EventArgs e)
        {
            mblnIsCompleted = true;
            mobjColor = (Color)((Panel)sender).Tag;
            this.Close();
        }

        public void mobjListWeb_SelectedIndexChanged(object sender, EventArgs e)
        {
            mblnIsCompleted = true;
            mobjColor = (Color)mobjListWeb.SelectedItem;
            this.Close();
        }

        public void mobjListSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            mblnIsCompleted = true;
            mobjColor = (Color)mobjListSystem.SelectedItem;
            this.Close();
        }

        public Color Color
        {
            get
            {
                return mobjColor;
            }
            set
            {
                mobjColor = value;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return mblnIsCompleted;
            }
        }
    }
}
