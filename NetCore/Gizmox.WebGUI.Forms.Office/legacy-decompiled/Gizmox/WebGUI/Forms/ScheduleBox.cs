using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxBitmap(typeof(ScheduleBox), "Office.ScheduleBox_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.ScheduleBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.ScheduleBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[ToolboxItem(true)]
[ToolboxItemCategory("Common Controls")]
[MetadataTag("SCB")]
[Skin(typeof(ScheduleBoxSkin))]
public class ScheduleBox : Control, IRequiresRegistration
{
	public delegate void ScheduleBoxEventHandler(object sender, ScheduleBoxEventArgs e);

	[Serializable]
	public class ScheduleBoxEventArgs : EventArgs
	{
		private ScheduleBoxEvent mobjEvent;

		public ScheduleBoxEvent Event => mobjEvent;

		public ScheduleBoxEventArgs(ScheduleBoxEvent objEvent)
		{
			mobjEvent = objEvent;
		}
	}

	private const int mcntWorkStartHour = 8;

	private const int mcntWorkEndHour = 17;

	private ScheduleBoxEventCollection mobjEvents;

	private DateTime mobjFirstDate = DateTime.Now;

	private ScheduleBoxView menmView;

	private ScheduleBoxHourFormat menmHour;

	private List<DateTime> mobjDays;

	private Day menmFirstDayOfWeek;

	private bool displayMonthHeader;

	private int mintWorkStartHour = 8;

	private int mintWorkEndHour = 17;

	private static readonly DateTime mobjReferenceDate = new DateTime(1970, 1, 1);

	protected override bool IsDelayedDrawing => true;

	[Obsolete("Not implemented. Added for migration compatibility")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool CompressWeekEnds => true;

	public ScheduleBoxEventCollection Events
	{
		get
		{
			if (mobjEvents == null)
			{
				mobjEvents = CreateEventsCollectionInstance();
			}
			return mobjEvents;
		}
	}

	public DateTime FirstDate
	{
		get
		{
			return mobjFirstDate;
		}
		set
		{
			if (mobjFirstDate != value)
			{
				mobjFirstDate = value;
				mobjDays = null;
				Update();
			}
		}
	}

	public Day FirstDayOfWeek
	{
		get
		{
			return menmFirstDayOfWeek;
		}
		set
		{
			if (value != Day.Sunday && value != Day.Monday)
			{
				throw new ArgumentOutOfRangeException("FirstDayOfWeek", "Schedule box FirstDayOfWeek can receive Monday or Sunday.");
			}
			if (menmFirstDayOfWeek != value)
			{
				menmFirstDayOfWeek = value;
				Update();
			}
		}
	}

	public ScheduleBoxView View
	{
		get
		{
			return menmView;
		}
		set
		{
			if (menmView != value)
			{
				menmView = value;
				mobjDays = null;
				Update();
			}
		}
	}

	public ScheduleBoxHourFormat HourFormat
	{
		get
		{
			return menmHour;
		}
		set
		{
			if (menmHour != value)
			{
				menmHour = value;
				Update();
			}
		}
	}

	public bool DisplayMonthHeader
	{
		get
		{
			return displayMonthHeader;
		}
		set
		{
			if (displayMonthHeader != value)
			{
				displayMonthHeader = value;
				Update();
			}
		}
	}

	protected internal int TotalDaysToDisplay
	{
		get
		{
			switch (menmView)
			{
			case ScheduleBoxView.Week:
				return 5;
			case ScheduleBoxView.FullWeek:
				return 7;
			case ScheduleBoxView.Day:
				return 1;
			case ScheduleBoxView.FullMonth:
			case ScheduleBoxView.Month:
				return DateTime.DaysInMonth(FirstDate.Year, FirstDate.Month);
			default:
				return 5;
			}
		}
	}

	public int WorkStartHour
	{
		get
		{
			return mintWorkStartHour + 1;
		}
		set
		{
			if (ValidateWorkHour(mintWorkStartHour, mintWorkEndHour, value, bIsStartHour: true))
			{
				mintWorkStartHour = value - 1;
				Update();
			}
		}
	}

	public int WorkEndHour
	{
		get
		{
			return mintWorkEndHour;
		}
		set
		{
			if (ValidateWorkHour(mintWorkStartHour, mintWorkEndHour, value, bIsStartHour: false))
			{
				mintWorkEndHour = value;
				Update();
			}
		}
	}

	public event ScheduleBoxEventHandler EventDoubleClick;

	public event ScheduleBoxEventHandler EventClick;

	[Category("Client")]
	[Description("Occurs when the schedule event is clicked.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientEventClick
	{
		add
		{
			AddClientHandler("Click", value);
		}
		remove
		{
			RemoveClientHandler("Click", value);
		}
	}

	[Category("Client")]
	[Description("Occurs when the schedule event is double clicked.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientEventDoubleClick
	{
		add
		{
			AddClientHandler("DoubleClick", value);
		}
		remove
		{
			RemoveClientHandler("DoubleClick", value);
		}
	}

	protected override void FireEvent(IEvent objEvent)
	{
		if (CommonUtils.IsNullOrEmpty(objEvent.Member))
		{
			base.FireEvent(objEvent);
			return;
		}
		int num = -1;
		if (objEvent.Member[0] != 'E')
		{
			return;
		}
		num = int.Parse(objEvent.Member.Substring(1));
		string type = objEvent.Type;
		if (!(type == "DoubleClick"))
		{
			if (!(type == "Click"))
			{
				return;
			}
			{
				foreach (ScheduleBoxEvent @event in Events)
				{
					if (@event.EventId != num)
					{
						continue;
					}
					int eventValue = GetEventValue(objEvent, "X", 0);
					int eventValue2 = GetEventValue(objEvent, "Y", 0);
					MouseEventArgs e = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, eventValue, eventValue2, 0);
					if (e != null)
					{
						if (e.Button == MouseButtons.Right)
						{
							@event.OnRightClick(e);
						}
						else if (e.Button == MouseButtons.Left)
						{
							OnEventClick(new ScheduleBoxEventArgs(@event));
						}
					}
					break;
				}
				return;
			}
		}
		foreach (ScheduleBoxEvent event2 in Events)
		{
			if (event2.EventId == num)
			{
				OnEventDoubleClick(new ScheduleBoxEventArgs(event2));
			}
		}
	}

	protected virtual void OnEventDoubleClick(ScheduleBoxEventArgs objScheduleBoxEventArgs)
	{
		this.EventDoubleClick?.Invoke(this, objScheduleBoxEventArgs);
	}

	protected virtual void OnEventClick(ScheduleBoxEventArgs objScheduleBoxEventArgs)
	{
		this.EventClick?.Invoke(this, objScheduleBoxEventArgs);
	}

	private int DayToNumber(DayOfWeek enmDay)
	{
		return enmDay switch
		{
			DayOfWeek.Sunday => 1, 
			DayOfWeek.Monday => 2, 
			DayOfWeek.Tuesday => 3, 
			DayOfWeek.Wednesday => 4, 
			DayOfWeek.Thursday => 5, 
			DayOfWeek.Friday => 6, 
			DayOfWeek.Saturday => 7, 
			_ => 1, 
		};
	}

	private int DayToNumber(Day enmDay)
	{
		return enmDay switch
		{
			Day.Sunday => 1, 
			Day.Monday => 2, 
			Day.Tuesday => 3, 
			Day.Wednesday => 4, 
			Day.Thursday => 5, 
			Day.Friday => 6, 
			Day.Saturday => 7, 
			_ => 1, 
		};
	}

	protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
	{
		objWriter.WriteAttributeString("HF", HourFormat.ToString());
		objWriter.WriteAttributeString("DMH", displayMonthHeader.ToString());
		if (mintWorkStartHour != 8 || mintWorkEndHour != 17)
		{
			objWriter.WriteAttributeString("WSH", mintWorkStartHour.ToString());
			objWriter.WriteAttributeString("WEH", mintWorkEndHour.ToString());
		}
		if (menmView != ScheduleBoxView.Month)
		{
			objWriter.WriteAttributeString("VW", "Days");
			if (menmView == ScheduleBoxView.FullMonth)
			{
				objWriter.WriteAttributeString("FM", "Yes");
			}
			else
			{
				objWriter.WriteAttributeString("FM", "No");
			}
		}
		else
		{
			objWriter.WriteAttributeString("VW", "Month");
			DateTime dateTime = new DateTime(FirstDate.Year, FirstDate.Month, 1, 0, 0, 0);
			DateTime dateTime2 = new DateTime(FirstDate.Year, FirstDate.Month, 1, 0, 0, 0);
			objWriter.WriteAttributeString("CMH", GetMonthString(FirstDate.Month) + " / " + FirstDate.ToString("yyyy"));
			dateTime2 = dateTime2.AddMonths(1).AddDays(-1.0);
			int num = DayToNumber(menmFirstDayOfWeek);
			int num2 = DayToNumber(dateTime.DayOfWeek);
			int num3 = 0;
			objWriter.WriteAttributeString("DST", ((num > num2) ? (7 - (num - num2) + 1) : (num2 - num + 1)).ToString());
			objWriter.WriteAttributeString("DDS", dateTime2.Day.ToString());
		}
		switch (menmFirstDayOfWeek)
		{
		case Day.Sunday:
		case Day.Default:
			objWriter.WriteAttributeString("DFWD", "1");
			break;
		case Day.Monday:
			objWriter.WriteAttributeString("DFWD", "2");
			break;
		}
		DateTime dateTime3 = mobjFirstDate.Date;
		if (menmView == ScheduleBoxView.Month)
		{
			dateTime3 = new DateTime(dateTime3.Year, dateTime3.Month, 1);
		}
		DateTime dateTime4 = dateTime3.AddDays(TotalDaysToDisplay - 1);
		objWriter.WriteAttributeString("SD", GetDateAsDayNumber(dateTime3).ToString());
		objWriter.WriteAttributeString("ED", GetDateAsDayNumber(dateTime4).ToString());
		objWriter.WriteAttributeString("OCE", GetEventClientCriticalEventsData().ToClientString());
		objWriter.WriteAttributeString("RCT", "30");
		DateTime dateTime5 = dateTime3;
		int num4 = -1;
		while (dateTime5 <= dateTime4)
		{
			if (menmView == ScheduleBoxView.FullMonth && displayMonthHeader && num4 != dateTime5.Month)
			{
				num4 = dateTime5.Month;
				int num5 = 0;
				num5 = ((dateTime4.Month != num4) ? (new DateTime(dateTime5.Year, num4, 1, 0, 0, 0).AddMonths(1).AddDays(-1.0).Day - dateTime3.Day + 1) : dateTime4.Day);
				objWriter.WriteStartElement("Month");
				objWriter.WriteAttributeString("MDS", num5.ToString());
				objWriter.WriteAttributeString("MHD", GetMonthString(num4) + " / " + dateTime5.Year);
				objWriter.WriteEndElement();
			}
			objWriter.WriteStartElement("Day");
			RenderDayAttributes(objWriter, dateTime5);
			objWriter.WriteEndElement();
			dateTime5 = dateTime5.AddDays(1.0);
		}
		List<List<ScheduleBoxEvent>> list = new List<List<ScheduleBoxEvent>>();
		foreach (ScheduleBoxEvent @event in Events)
		{
			objWriter.WriteStartElement("Event");
			objWriter.WriteAttributeString("mId", @event.ID);
			objWriter.WriteAttributeString("oId", GetProxyPropertyValue("ID", ID).ToString());
			RenderEventEvents(objWriter, @event);
			int num6 = Convert.ToInt32(GetDateAsDayNumber(@event.Start));
			int num7 = Convert.ToInt32(GetDateAsDayNumber(@event.End));
			objWriter.WriteAttributeString("SD", num6.ToString());
			objWriter.WriteAttributeString("ED", num7.ToString());
			objWriter.WriteAttributeString("ST1", GetDateAsTimeNumber(@event.Start).ToString());
			objWriter.WriteAttributeString("ET1", GetDateAsTimeNumber(@event.End).ToString());
			if (num6 < num7)
			{
				int num8 = -1;
				bool flag = false;
				for (int i = 0; i < list.Count; i++)
				{
					if (num8 != -1)
					{
						break;
					}
					foreach (ScheduleBoxEvent item in list[i])
					{
						if (item.IsInRange(@event) || @event.IsInRange(item))
						{
							flag = flag || true;
						}
						if (flag)
						{
							break;
						}
					}
					if (!flag)
					{
						num8 = i;
					}
					flag = false;
				}
				if (num8 == -1)
				{
					list.Add(new List<ScheduleBoxEvent>());
					list[list.Count - 1].Add(@event);
					num8 = list.Count - 1;
				}
				else
				{
					list[num8].Add(@event);
				}
				objWriter.WriteAttributeString("RCT", num8.ToString());
			}
			objWriter.WriteAttributeText("SUB", @event.Subject);
			objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(@event.BackgroundColor));
			OnRenderEventAttributes(@event, objWriter);
			objWriter.WriteEndElement();
		}
	}

	protected virtual void OnRenderEventAttributes(ScheduleBoxEvent objEvent, IResponseWriter objWriter)
	{
	}

	protected virtual void RenderDayAttributes(IResponseWriter objWriter, DateTime objDay)
	{
		objWriter.WriteAttributeString("VLB", GetDateAsDayNumber(objDay).ToString());
		if (objDay.Date == DateTime.Now.Date)
		{
			objWriter.WriteAttributeString("ITD", "1");
		}
		if (menmView != ScheduleBoxView.FullMonth)
		{
			objWriter.WriteAttributeString("TL", objDay.ToShortDateString());
		}
		else
		{
			objWriter.WriteAttributeString("TL", objDay.ToString("dd"));
		}
	}

	public static double GetDateAsDayNumber(DateTime objDate)
	{
		return Math.Floor((objDate - mobjReferenceDate).TotalDays);
	}

	public static int GetDateAsTimeNumber(DateTime objDate)
	{
		return objDate.Hour * 60 + objDate.Minute;
	}

	private void RenderEventEvents(IResponseWriter objWriter, ScheduleBoxEvent objEvent)
	{
		CriticalEventsData eventCriticalEventsData = GetEventCriticalEventsData(objEvent);
		if (eventCriticalEventsData.HasEvents)
		{
			objWriter.WriteAttributeString("E", eventCriticalEventsData.ToClientString());
		}
		CriticalEventsData eventClientCriticalEventsData = GetEventClientCriticalEventsData();
		if (eventClientCriticalEventsData.HasEvents)
		{
			objWriter.WriteAttributeString("OTS", eventClientCriticalEventsData.ToClientString());
		}
	}

	private CriticalEventsData GetEventCriticalEventsData(ScheduleBoxEvent objEvent)
	{
		CriticalEventsData criticalEventsData = new CriticalEventsData();
		if (this.EventClick != null)
		{
			criticalEventsData.Set("CL");
		}
		if (this.EventDoubleClick != null)
		{
			criticalEventsData.Set("DCL");
		}
		if (objEvent.ContextMenu != null || ContextMenu != null)
		{
			criticalEventsData.Set("RC");
		}
		return criticalEventsData;
	}

	private CriticalEventsData GetEventClientCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = new CriticalEventsData();
		if (HasClientHandler("Click"))
		{
			criticalEventsData.Set("CL");
		}
		if (HasClientHandler("DoubleClick"))
		{
			criticalEventsData.Set("DCL");
		}
		return criticalEventsData;
	}

	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (this.EventClick != null)
		{
			criticalEventsData.Set("CL");
		}
		if (this.EventDoubleClick != null)
		{
			criticalEventsData.Set("DCL");
		}
		return criticalEventsData;
	}

	protected virtual ScheduleBoxEventCollection CreateEventsCollectionInstance()
	{
		return new ScheduleBoxEventCollection(this);
	}

	internal void EnsureVisibleEvent(ScheduleBoxEvent objScheduleBoxEvent)
	{
		switch (View)
		{
		case ScheduleBoxView.Month:
			if (FirstDate.Month != objScheduleBoxEvent.Start.Month || FirstDate.Year != objScheduleBoxEvent.Start.Year)
			{
				FirstDate = new DateTime(objScheduleBoxEvent.Start.Year, objScheduleBoxEvent.Start.Month, 1);
			}
			break;
		case ScheduleBoxView.Week:
		case ScheduleBoxView.FullWeek:
		case ScheduleBoxView.FullMonth:
			if (objScheduleBoxEvent.Start >= FirstDate.AddDays(TotalDaysToDisplay) || objScheduleBoxEvent.Start < FirstDate)
			{
				FirstDate = new DateTime(objScheduleBoxEvent.Start.Year, objScheduleBoxEvent.Start.Month, objScheduleBoxEvent.Start.Day);
			}
			break;
		default:
			FirstDate = objScheduleBoxEvent.Start.Date;
			break;
		}
		InvokeMethodWithId("ScheduleBox_PerformScrollIntoView", objScheduleBoxEvent.ID);
	}

	protected internal virtual void OnEventUpdated(ScheduleBoxEvent objEvent)
	{
		Update();
	}

	protected internal virtual void OnEventAdded(ScheduleBoxEvent objEvent)
	{
		Update();
	}

	protected internal virtual void OnEventRemoved(ScheduleBoxEvent objEvent)
	{
		Update();
	}

	protected internal virtual void OnEventsCleared()
	{
		Update();
	}

	private bool ValidateWorkHour(int intStartWorkHour, int intEndWorkHour, int intNewValue, bool bIsStartHour)
	{
		if (intNewValue < 0 || intNewValue > 24)
		{
			throw new Exception("Work hour must be bettwen 0 and 24.");
		}
		if (bIsStartHour)
		{
			if (intNewValue > intEndWorkHour)
			{
				throw new Exception("Work start hour cant be higher then the work end hour.");
			}
		}
		else if (intStartWorkHour > intNewValue)
		{
			throw new Exception("Work start hour cant be higher then the work end hour.");
		}
		return true;
	}

	protected override void AddChild(object objValue)
	{
		if (objValue is ScheduleBoxEvent)
		{
			Events.Add((ScheduleBoxEvent)objValue);
		}
		else
		{
			base.AddChild(objValue);
		}
	}

	internal string GetMonthString(int month)
	{
		string result = "Undefined";
		switch (month)
		{
		case 1:
			result = WGLabels.January;
			break;
		case 2:
			result = WGLabels.February;
			break;
		case 3:
			result = WGLabels.March;
			break;
		case 4:
			result = WGLabels.April;
			break;
		case 5:
			result = WGLabels.May;
			break;
		case 6:
			result = WGLabels.June;
			break;
		case 7:
			result = WGLabels.July;
			break;
		case 8:
			result = WGLabels.August;
			break;
		case 9:
			result = WGLabels.September;
			break;
		case 10:
			result = WGLabels.October;
			break;
		case 11:
			result = WGLabels.November;
			break;
		case 12:
			result = WGLabels.December;
			break;
		}
		return result;
	}

	private void ResetDisplayMonthHeader()
	{
		DisplayMonthHeader = false;
	}

	private void ResetFirstDate()
	{
		FirstDate = DateTime.Now;
	}

	private void ResetFirstDayOfWeek()
	{
		FirstDayOfWeek = Day.Monday;
	}

	private void ResetHourFormat()
	{
		HourFormat = ScheduleBoxHourFormat.Clock12H;
	}

	private void ResetView()
	{
		View = ScheduleBoxView.Week;
	}

	private void ResetWorkEndHour()
	{
		WorkEndHour = 17;
	}

	private void ResetWorkStartHour()
	{
		WorkStartHour = 8;
	}
}
