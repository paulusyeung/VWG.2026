using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Gizmox.WebGUI.Forms;

[Serializable]
public class ScheduleBoxEventCollection : BaseCollection, IList, ICollection, IEnumerable
{
	private ScheduleBox mobjOwner;

	private ArrayList mobjEvents;

	private int mintLastEventId;

	protected int LastEventId
	{
		get
		{
			return mintLastEventId;
		}
		set
		{
			mintLastEventId = value;
		}
	}

	protected override ArrayList List => mobjEvents;

	protected ScheduleBox Owner
	{
		get
		{
			return mobjOwner;
		}
		set
		{
			mobjOwner = value;
		}
	}

	internal ArrayList AllDayEvents
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ScheduleBoxEvent scheduleBoxEvent = (ScheduleBoxEvent)enumerator.Current;
					if (scheduleBoxEvent.AllDayEvent)
					{
						arrayList.Add(scheduleBoxEvent);
					}
				}
				return arrayList;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	internal ArrayList PartialDayEvents
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ScheduleBoxEvent scheduleBoxEvent = (ScheduleBoxEvent)enumerator.Current;
					if (!scheduleBoxEvent.AllDayEvent)
					{
						arrayList.Add(scheduleBoxEvent);
					}
				}
				return arrayList;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}

	public ScheduleBoxEvent this[int index]
	{
		get
		{
			return (ScheduleBoxEvent)mobjEvents[index];
		}
		set
		{
			if (value != null)
			{
				mintLastEventId++;
				value.EventId = mintLastEventId;
				value.Owner = mobjOwner;
				mobjEvents[index] = value;
				mobjOwner.OnEventAdded(value);
			}
		}
	}

	object IList.this[int index]
	{
		get
		{
			return mobjEvents[index];
		}
		set
		{
			this[index] = (ScheduleBoxEvent)value;
		}
	}

	public bool IsFixedSize => false;

	protected internal ScheduleBoxEventCollection(ScheduleBox objOwner)
	{
		mobjOwner = objOwner;
		mobjEvents = new ArrayList();
	}

	public ScheduleBoxEvent Add(string strSubject, DateTime objStart, DateTime objEnd)
	{
		mintLastEventId++;
		ScheduleBoxEvent scheduleBoxEvent = new ScheduleBoxEvent(mobjOwner, mintLastEventId, strSubject, objStart, objEnd);
		mobjEvents.Add(scheduleBoxEvent);
		mobjOwner.OnEventAdded(scheduleBoxEvent);
		return scheduleBoxEvent;
	}

	public virtual int Add(ScheduleBoxEvent objEvent)
	{
		if (objEvent != null)
		{
			mintLastEventId++;
			objEvent.EventId = mintLastEventId;
			objEvent.Owner = mobjOwner;
			int result = mobjEvents.Add(objEvent);
			mobjOwner.OnEventAdded(objEvent);
			return result;
		}
		return -1;
	}

	public void Remove(ScheduleBoxEvent objEvent)
	{
		if (mobjEvents.Contains(objEvent))
		{
			mobjEvents.Remove(objEvent);
			mobjOwner.OnEventRemoved(objEvent);
		}
	}

	public void Clear()
	{
		mobjEvents.Clear();
		mobjOwner.OnEventsCleared();
	}

	public void RemoveAt(int index)
	{
		Remove((ScheduleBoxEvent)mobjEvents[index]);
	}

	public void Insert(int index, object value)
	{
		this[index] = (ScheduleBoxEvent)value;
	}

	void IList.Remove(object value)
	{
		Remove((ScheduleBoxEvent)value);
	}

	public bool Contains(object value)
	{
		return mobjEvents.Contains(value);
	}

	public int IndexOf(object value)
	{
		return mobjEvents.IndexOf(value);
	}

	int IList.Add(object value)
	{
		return mobjEvents.Add(value);
	}

	bool IList.IsReadOnly => base.IsReadOnly;
}
