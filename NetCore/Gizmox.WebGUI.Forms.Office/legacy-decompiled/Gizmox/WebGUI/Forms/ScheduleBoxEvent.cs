using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class ScheduleBoxEvent : SerializableObject, IIdentifiedComponent
{
	private static SerializableProperty ContextMenuProperty = SerializableProperty.Register("ContextMenu", typeof(ContextMenu), typeof(ScheduleBoxEvent));

	private static SerializableProperty SubjectProperty = SerializableProperty.Register("Subject", typeof(string), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(string.Empty));

	private static SerializableProperty StartProperty = SerializableProperty.Register("Start", typeof(DateTime), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(DateTime.MinValue));

	private static SerializableProperty EndProperty = SerializableProperty.Register("End", typeof(DateTime), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(DateTime.MinValue));

	private static SerializableProperty OwnerProperty = SerializableProperty.Register("Owner", typeof(ScheduleBox), typeof(ScheduleBoxEvent));

	private static SerializableProperty TagProperty = SerializableProperty.Register("Tag", typeof(object), typeof(ScheduleBoxEvent));

	private static SerializableProperty BackgroundColorProperty = SerializableProperty.Register("BackgroudColor", typeof(Color), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(Color.Empty));

	private static SerializableProperty EventIdProperty = SerializableProperty.Register("EventId", typeof(int), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(0));

	internal int EventId
	{
		get
		{
			return GetValue<int>(EventIdProperty);
		}
		set
		{
			SetValue(EventIdProperty, value);
		}
	}

	protected internal ScheduleBox Owner
	{
		get
		{
			return GetValue<ScheduleBox>(OwnerProperty);
		}
		set
		{
			SetValue(OwnerProperty, value);
		}
	}

	public string Subject
	{
		get
		{
			return GetValue<string>(SubjectProperty);
		}
		set
		{
			if (SetValue(SubjectProperty, value) && Owner != null)
			{
				Owner.OnEventUpdated(this);
			}
		}
	}

	public DateTime Start
	{
		get
		{
			return GetValue<DateTime>(StartProperty);
		}
		set
		{
			if (SetValue(StartProperty, value))
			{
				if (DateTime.Compare(value, End) == 1)
				{
					SetValue(EndProperty, value.AddHours(1.0));
				}
				if (Owner != null)
				{
					Owner.OnEventUpdated(this);
				}
			}
		}
	}

	public DateTime End
	{
		get
		{
			return GetValue<DateTime>(EndProperty);
		}
		set
		{
			if (DateTime.Compare(value, Start) == -1)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (SetValue(EndProperty, value) && Owner != null)
			{
				Owner.OnEventUpdated(this);
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return GetValue<Color>(BackgroundColorProperty);
		}
		set
		{
			if (SetValue(BackgroundColorProperty, value) && Owner != null)
			{
				Owner.OnEventUpdated(this);
			}
		}
	}

	internal TimeSpan DateDiff => new TimeSpan(End.Ticks - Start.Ticks);

	internal double Days => Math.Ceiling(DateDiff.TotalDays);

	internal double Hours => Math.Ceiling(DateDiff.TotalHours);

	internal int HalfHours => (int)Math.Ceiling(DateDiff.TotalHours * 2.0);

	internal double Duration
	{
		get
		{
			ScheduleBoxSkin scheduleBoxSkin = null;
			if (Owner != null)
			{
				scheduleBoxSkin = SkinFactory.GetSkin(Owner, typeof(ScheduleBoxSkin)) as ScheduleBoxSkin;
			}
			int num = scheduleBoxSkin?.HalfHourHeight ?? 20;
			double num2 = DateDiff.TotalHours * 2.0;
			if (num2 * (double)num < 1.0)
			{
				return 1.0 / (double)num;
			}
			return num2;
		}
	}

	internal int OffsetY
	{
		get
		{
			ScheduleBoxSkin scheduleBoxSkin = null;
			if (Owner != null)
			{
				scheduleBoxSkin = SkinFactory.GetSkin(Owner, typeof(ScheduleBoxSkin)) as ScheduleBoxSkin;
			}
			int num = scheduleBoxSkin?.HalfHourHeight ?? 21;
			int num2 = Start.Minute;
			if (num2 >= 30)
			{
				num2 -= 30;
			}
			return num * num2 / 30;
		}
	}

	internal int StartHalfHoursFromMidnight => (int)Math.Floor(Start.TimeOfDay.TotalHours * 2.0);

	public bool AllDayEvent => Start.Date != End.Date;

	[DefaultValue(null)]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return GetValue<object>(TagProperty);
		}
		set
		{
			SetValue(TagProperty, value);
		}
	}

	[Browsable(true)]
	[DefaultValue(null)]
	public virtual ContextMenu ContextMenu
	{
		get
		{
			ContextMenu contextMenu = GetValue<ContextMenu>(ContextMenuProperty);
			if (contextMenu == null && Owner != null)
			{
				contextMenu = Owner.ContextMenu;
			}
			return contextMenu;
		}
		set
		{
			SetValue(ContextMenuProperty, value);
		}
	}

	public string ID => $"E{EventId}";

	protected internal ScheduleBoxEvent(ScheduleBox objOwner, int intEventId, string strSubject, DateTime objStart, DateTime objEnd)
	{
		EventId = intEventId;
		Owner = objOwner;
		Subject = strSubject;
		End = objEnd;
		Start = objStart;
	}

	public ScheduleBoxEvent()
	{
		DateTime now = DateTime.Now;
		End = now.AddHours(1.0);
		Start = now;
	}

	internal bool IsStartDay(DateTime objDay)
	{
		return Start.Date == objDay.Date;
	}

	internal bool IsEndDay(DateTime objDay)
	{
		return End.Date == objDay.Date;
	}

	internal bool IsInRange(ScheduleBoxEvent objEvent)
	{
		if (IsInRange(objEvent.Start) || IsInRange(objEvent.End))
		{
			return true;
		}
		return false;
	}

	internal bool IsInRange(DateTime objDay)
	{
		if (Start.CompareTo(objDay) == -1 && End.CompareTo(objDay) == 1)
		{
			return true;
		}
		if (IsStartDay(objDay) || IsEndDay(objDay))
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "Event: {" + Subject + "}";
	}

	internal void OnRightClick(MouseEventArgs objMouseEventArgs)
	{
		ContextMenu?.Show(Owner, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
	}

	public void EnsureVisible()
	{
		if (Owner != null)
		{
			Owner.EnsureVisibleEvent(this);
		}
	}
}
