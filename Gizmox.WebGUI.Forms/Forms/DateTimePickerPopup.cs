// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DateTimePickerPopup
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (DateTimePickerPopupSkin))]
  [Serializable]
  public class DateTimePickerPopup : Form
  {
    protected MonthCalendar mobjMonthCalendar;
    protected DateTime mobjDate;
    protected DateTimePicker mobjDateTimePicker;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePickerPopup" /> class.
    /// </summary>
    public DateTimePickerPopup() => this.InitializeComponent();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDateTimePicker"></param>
    public DateTimePickerPopup(DateTimePicker objDateTimePicker)
      : this()
    {
      this.mobjDateTimePicker = objDateTimePicker;
      if (this.mobjDateTimePicker == null)
        return;
      this.mobjMonthCalendar.Value = this.mobjDateTimePicker.Value;
      this.mobjMonthCalendar.FirstDayOfWeek = this.mobjDateTimePicker.CalendarFirstDayOfWeek;
      this.mobjMonthCalendar.VisualEffect = this.mobjDateTimePicker.VisualEffect;
      if (this.mobjDateTimePicker.CloseUpHandler != null)
        this.Closed += new EventHandler(this.DateTimePickerPopup_Closed);
      if (!(this.mobjDateTimePicker.Skin is DateTimePickerSkin skin))
        return;
      this.Size = skin.DropDownSize;
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitializeComponent()
    {
      this.mobjMonthCalendar = new MonthCalendar(this.mobjDateTimePicker, this);
      this.SuspendLayout();
      this.mobjMonthCalendar.Dock = DockStyle.Fill;
      this.mobjMonthCalendar.BorderStyle = BorderStyle.None;
      this.mobjMonthCalendar.BorderWidth = (BorderWidth) 0;
      this.Controls.Add((Control) this.mobjMonthCalendar);
      this.Size = new Size(177, 154);
      this.ClientSize = new Size(177, 154);
      this.Text = WGLabels.DatePicker;
      this.ResumeLayout(false);
    }

    /// <summary>Called when [month calander value changed].</summary>
    /// <param name="blnClosePopUp">if set to <c>true</c> [BLN close pop up].</param>
    internal void OnMonthCalanderValueChanged(bool blnClosePopUp)
    {
      TimeSpan zero = TimeSpan.Zero;
      if (this.mobjDateTimePicker != null)
      {
        DateTime dateTime1 = this.mobjDateTimePicker.Value;
        TimeSpan timeOfDay = dateTime1.TimeOfDay;
        dateTime1 = this.mobjMonthCalendar.Value;
        DateTime dateTime2 = dateTime1.Add(timeOfDay);
        if (dateTime2 >= this.mobjDateTimePicker.MinDate && dateTime2 <= this.mobjDateTimePicker.MaxDate)
          this.mobjDateTimePicker.Value = dateTime2;
        this.mobjDateTimePicker.Focus();
      }
      if (!blnClosePopUp)
        return;
      this.Close();
    }

    private void DateTimePickerPopup_Closed(object sender, EventArgs e) => this.mobjDateTimePicker.OnCloseUp(new EventArgs());
  }
}
