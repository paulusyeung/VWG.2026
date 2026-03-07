// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.ColorEditorDropDown
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace Gizmox.WebGUI.Forms.Design
{
  [Serializable]
  internal class ColorEditorDropDown : Form
  {
    private TabControl mobjTabControl;
    private TabPage mobjTabCustom;
    private TabPage mobjTabWeb;
    private TabPage mobjTabSystem;
    private ColorListBox mobjListWeb;
    private ColorListBox mobjListSystem;
    private bool mblnIsCompleted;
    private Color mobjColor = Color.Empty;
    private static Color[] marrWebColors;
    private static Color[] marrSystemColors;

    public ColorEditorDropDown()
    {
      this.InitializeComponenet();
      this.Load += new EventHandler(this.ColorEditorDropDown_Load);
    }

    private void ColorEditorDropDown_Load(object sender, EventArgs e)
    {
      TabControlSkin controlCurrentSkin = this.mobjTabControl.TabControlCurrentSkin;
      if (controlCurrentSkin != null)
      {
        this.Height += controlCurrentSkin.TopFrameHeight + controlCurrentSkin.BottomFrameHeight + controlCurrentSkin.SeperatorFrameHeight;
        this.Width += controlCurrentSkin.LeftFrameWidth + controlCurrentSkin.RightFrameWidth;
      }
      this.mobjTabControl.SelectedIndex = 0;
      this.mobjListSystem.Items.AddRange((ICollection) ColorEditorDropDown.GetSystemColors());
      this.mobjListWeb.Items.AddRange((ICollection) ColorEditorDropDown.GetWebColors());
      this.InitializePalette(this.mobjTabCustom, ColorEditorDropDown.GetWebColors());
    }

    private static Color[] GetWebColors()
    {
      if (ColorEditorDropDown.marrWebColors == null)
        ColorEditorDropDown.marrWebColors = ColorEditorDropDown.GetConstants(typeof (Color));
      return ColorEditorDropDown.marrWebColors;
    }

    private static Color[] GetSystemColors()
    {
      if (ColorEditorDropDown.marrSystemColors == null)
        ColorEditorDropDown.marrSystemColors = ColorEditorDropDown.GetConstants(typeof (SystemColors));
      return ColorEditorDropDown.marrSystemColors;
    }

    private static Color[] GetConstants(Type objEnumType)
    {
      MethodAttributes methodAttributes = MethodAttributes.Public | MethodAttributes.Static;
      PropertyInfo[] properties = objEnumType.GetProperties();
      ArrayList arrayList = new ArrayList();
      for (int index1 = 0; index1 < properties.Length; ++index1)
      {
        PropertyInfo propertyInfo = properties[index1];
        if (propertyInfo.PropertyType == typeof (Color))
        {
          MethodInfo getMethod = propertyInfo.GetGetMethod();
          if (getMethod != (MethodInfo) null && (getMethod.Attributes & methodAttributes) == methodAttributes)
          {
            object[] index2 = (object[]) null;
            arrayList.Add(propertyInfo.GetValue((object) null, index2));
          }
        }
      }
      return (Color[]) arrayList.ToArray(typeof (Color));
    }

    private void InitializePalette(TabPage objTabPage, Color[] arrColors)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        for (int index3 = 0; index3 < 8; ++index3)
        {
          Panel objValue = new Panel();
          objValue.Location = new Point(6 + index3 * 26, 6 + index2 * 26);
          objValue.Size = new Size(20, 20);
          objValue.BorderStyle = BorderStyle.FixedSingle;
          objValue.Click += new EventHandler(this.objPanel_Click);
          if (arrColors.Length > index1)
          {
            Panel panel = objValue;
            Color arrColor;
            Color color = arrColor = arrColors[index1];
            panel.BackColor = arrColor;
            panel.Tag = (object) color;
          }
          else
          {
            Panel panel = objValue;
            Color white;
            Color color = white = Color.White;
            panel.BackColor = white;
            panel.Tag = (object) color;
          }
          objTabPage.Controls.Add((Control) objValue);
          ++index1;
        }
      }
    }

    private void InitializeComponenet()
    {
      this.mobjTabControl = new TabControl();
      this.mobjTabCustom = new TabPage();
      this.mobjTabWeb = new TabPage();
      this.mobjListWeb = new ColorListBox();
      this.mobjTabSystem = new TabPage();
      this.mobjListSystem = new ColorListBox();
      this.mobjTabControl.SuspendLayout();
      this.mobjTabWeb.SuspendLayout();
      this.mobjTabSystem.SuspendLayout();
      this.SuspendLayout();
      this.mobjTabControl.Controls.Add((Control) this.mobjTabCustom);
      this.mobjTabControl.Controls.Add((Control) this.mobjTabWeb);
      this.mobjTabControl.Controls.Add((Control) this.mobjTabSystem);
      this.mobjTabControl.Dock = DockStyle.Fill;
      this.mobjTabControl.Location = new Point(0, 0);
      this.mobjTabControl.Name = "tabControl1";
      this.mobjTabControl.SelectedIndex = 0;
      this.mobjTabControl.Size = new Size(224, 242);
      this.mobjTabControl.TabIndex = 0;
      this.mobjTabControl.BorderStyle = BorderStyle.FixedSingle;
      this.mobjTabControl.Multiline = false;
      this.mobjTabCustom.Location = new Point(4, 22);
      this.mobjTabCustom.Name = "mobjTabCustom";
      this.mobjTabCustom.Padding = new Padding(2);
      this.mobjTabCustom.Size = new Size(216, 216);
      this.mobjTabCustom.TabIndex = 0;
      this.mobjTabCustom.Text = "Custom";
      this.mobjTabCustom.AutoScroll = false;
      this.mobjTabWeb.Controls.Add((Control) this.mobjListWeb);
      this.mobjTabWeb.Location = new Point(4, 22);
      this.mobjTabWeb.Name = "mobjTabWeb";
      this.mobjTabWeb.Padding = new Padding(2);
      this.mobjTabWeb.Size = new Size(216, 216);
      this.mobjTabWeb.TabIndex = 1;
      this.mobjTabWeb.Text = "Web";
      this.mobjListWeb.Dock = DockStyle.Fill;
      this.mobjListWeb.FormattingEnabled = true;
      this.mobjListWeb.Location = new Point(3, 3);
      this.mobjListWeb.Name = "mobjListWeb";
      this.mobjListWeb.Size = new Size(210, 199);
      this.mobjListWeb.TabIndex = 0;
      this.mobjListWeb.SelectedIndexChanged += new EventHandler(this.mobjListWeb_SelectedIndexChanged);
      this.mobjTabSystem.Controls.Add((Control) this.mobjListSystem);
      this.mobjTabSystem.Location = new Point(4, 22);
      this.mobjTabSystem.Name = "mobjTabSystem";
      this.mobjTabSystem.Size = new Size(216, 216);
      this.mobjTabSystem.TabIndex = 2;
      this.mobjTabSystem.Text = "System";
      this.mobjTabSystem.Padding = new Padding(2);
      this.mobjListSystem.Dock = DockStyle.Fill;
      this.mobjListSystem.FormattingEnabled = true;
      this.mobjListSystem.Location = new Point(0, 0);
      this.mobjListSystem.Name = "mobjListSystem";
      this.mobjListSystem.Size = new Size(216, 212);
      this.mobjListSystem.TabIndex = 0;
      this.mobjListSystem.SelectedIndexChanged += new EventHandler(this.mobjListSystem_SelectedIndexChanged);
      this.DockPadding.All = 2;
      this.ClientSize = new Size(224, 242);
      this.Controls.Add((Control) this.mobjTabControl);
      this.Name = "ColorControl";
      this.mobjTabControl.ResumeLayout(false);
      this.mobjTabWeb.ResumeLayout(false);
      this.mobjTabSystem.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void objPanel_Click(object sender, EventArgs e)
    {
      this.mblnIsCompleted = true;
      this.mobjColor = (Color) ((Component) sender).Tag;
      this.Close();
    }

    public void mobjListWeb_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.mblnIsCompleted = true;
      this.mobjColor = (Color) this.mobjListWeb.SelectedItem;
      this.Close();
    }

    public void mobjListSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.mblnIsCompleted = true;
      this.mobjColor = (Color) this.mobjListSystem.SelectedItem;
      this.Close();
    }

    public Color Color
    {
      get => this.mobjColor;
      set => this.mobjColor = value;
    }

    public bool IsCompleted => this.mblnIsCompleted;
  }
}
