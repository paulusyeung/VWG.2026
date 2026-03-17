using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Skins;

[Serializable]
[ToolboxBitmap(typeof(MonthCalendar), "MonthCalendar.bmp")]
public class ScheduleBoxSkin : ControlSkin
{
	[Category("States")]
	[Description("The control style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue ControlStyle => new StyleValue(this, "ControlStyle");

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue EventStyleInMonthView => new StyleValue(this, "EventStyleInMonthView");

	[Category("States")]
	[Description("The header style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue HeaderStyle => new StyleValue(this, "HeaderStyle");

	[Category("States")]
	[Description("The header events style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue HeaderEventsStyle => new StyleValue(this, "HeaderEventsStyle");

	[Category("States")]
	[Description("The date header label style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue DateHeaderLabelStyle => new StyleValue(this, "DateHeaderLabelStyle", HeaderStyle);

	[Category("States")]
	[Description("The day separator style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue DaySeparatorStyle => new StyleValue(this, "DaySeparatorStyle");

	[Category("States")]
	[Description("The event background style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue EventBackgroundStyle => new StyleValue(this, "EventBackgroundStyle");

	[Category("States")]
	[Description("The event style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue EventStyle => new StyleValue(this, "EventStyle");

	[Category("States")]
	[Description("The all day event style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue AllDayEventStyle => new StyleValue(this, "AllDayEventStyle", EventStyle);

	[Category("States")]
	[Description("The even row cell style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue EventRowCellStyle => new StyleValue(this, "EventRowCellStyle");

	[Category("States")]
	[Description("The odd row cell style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue OddRowCellStyle => new StyleValue(this, "OddRowCellStyle");

	[Category("States")]
	[Description("The day hour left border style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue DayHourLeftBorderStyle => new StyleValue(this, "DayHourLeftBorderStyle");

	[Category("States")]
	[Description("The day hour style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue DayHourStyle => new StyleValue(this, "DayHourStyle");

	[Category("States")]
	[Description("The day hour right border style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue DayHourRightBorderStyle => new StyleValue(this, "DayHourRightBorderStyle", DayHourStyle);

	[Category("States")]
	[Description("The month days container style in month view.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue MonthDaysContainerStyleInMonthView => new StyleValue(this, "MonthDaysContainerStyleInMonthView");

	[Category("States")]
	[Description("The today style in month view.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue TodayStyleInMonthView => new StyleValue(this, "TodayStyleInMonthView");

	[Category("States")]
	[Description("The current month days style in month view.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue CurrentMonthDaysStyleInMonthView => new StyleValue(this, "CurrentMonthDaysStyleInMonthView");

	[Category("States")]
	[Description("The previous month days style in month view.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public StyleValue PreviousMonthDaysStyleInMonthView => new StyleValue(this, "PreviousMonthDaysStyleInMonthView");

	[Category("Sizes")]
	[Description("The header label height.")]
	public int HeaderLabelHeight
	{
		get
		{
			return GetValue("HeaderLabelHeight", 18);
		}
		set
		{
			SetValue("HeaderLabelHeight", value);
		}
	}

	[Category("Sizes")]
	[Description("The all day event height.")]
	public int AllDayEventHeight
	{
		get
		{
			return GetValue("AllDayEventHeight", 20);
		}
		set
		{
			SetValue("AllDayEventHeight", value);
		}
	}

	[Category("Sizes")]
	[Description("The day hour container width.")]
	public int DayHourContainerWidth
	{
		get
		{
			return GetValue("DayHourContainerWidth", 45);
		}
		set
		{
			SetValue("DayHourContainerWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The day hour container border width.")]
	public int DayHourContainerBorderWidth
	{
		get
		{
			return GetValue("DayHourContainerBorderWidth", 3);
		}
		set
		{
			SetValue("DayHourContainerBorderWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The day separator width.")]
	public int DaySeparatorWidth
	{
		get
		{
			return GetValue("DaySeparatorWidth", 7);
		}
		set
		{
			SetValue("DaySeparatorWidth", value);
		}
	}

	[Category("Sizes")]
	[Description("The half hour height.")]
	public int HalfHourHeight
	{
		get
		{
			return GetValue("HalfHourHeight", DefaultHalfHourHeight);
		}
		set
		{
			SetValue("HalfHourHeight", value);
		}
	}

	protected virtual int DefaultHalfHourHeight => 20;

	private void InitializeComponent()
	{
	}

	internal void ResetHalfHourHeight()
	{
		Reset("HalfHourHeight");
	}
}
