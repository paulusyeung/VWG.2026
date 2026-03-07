using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;

namespace CompanionKit.Controls.ScheduleBox
{
	/// <summary>
	/// Helper class for manipulating with ScheduleBox events
	/// </summary>
	public class Events
	{
		/// <summary>
		/// Wraps creation of a ScheduleBoxEvent
		/// </summary>
		public static ScheduleBoxEvent Create(DateTime start, DateTime end, string subject, string tag)
		{
			ScheduleBoxEvent objEvent = new ScheduleBoxEvent();
			objEvent.Start = start;
			objEvent.End = end;
			objEvent.Subject = subject;
			objEvent.Tag = tag;
			return objEvent;
		}

		/// <summary>
		/// Opens an editing form and adds new event to demoScheduleBox if user confirmed.
		/// Recreates context menu by cloning given eventmenu and attaches the handler for click
		/// for each menu item.
		/// </summary>
		/// <param name="demoScheduleBox">The schedule box.</param>
		/// <param name="eventmenu">The eventmenu with OR without clicked event.</param>
		/// <param name="handler">The handler to response to right click.</param>
		/// <param name="blnCopy">New event created as a copy of clicked eventmenu.Event object.</param>
		public static void ProcessAddEvent(
			Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox,
			Gizmox.WebGUI.Forms.ContextMenu menu,
			bool blnCopy,
			ScheduleBoxEvent objEvent)
		{
			ScheduleBoxEvent newEvent = null;
			if (blnCopy && objEvent != null)
			{
				// Copy data from given event
				newEvent = Events.Create(objEvent.Start, objEvent.End, objEvent.Subject,
					objEvent.Tag != null ? objEvent.Tag.ToString() : "");
			}
			else
			{
				// Create absolutely new event
				newEvent = new ScheduleBoxEvent();
				newEvent.Start = DateTime.Now;
				newEvent.End = newEvent.Start.AddHours(1);
			}

			if (newEvent != null)
			{
				// Opening editing form and attach a context menu
				EventForm eventForm = new EventForm();
				eventForm.TargetEvent = newEvent;
				eventForm.FormClosed += delegate(object form, FormClosedEventArgs eventargs)
				{
					// Respect user choice
					if (((Gizmox.WebGUI.Forms.Form)form).DialogResult == DialogResult.OK)
					{
						newEvent.ContextMenu = menu;

						// <-----------[ Add the event to collection ]---------->
						demoScheduleBox.Events.Add(newEvent);
						demoScheduleBox.FirstDate = newEvent.Start;
					}
				};
				eventForm.ShowDialog();
			}
		}

		/// <summary>
		/// Opens the editing form
		/// </summary>
		public static void ProcessOpenEvent(
			Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox, ScheduleBoxEvent objEvent)
		{
			EventForm eventForm = new EventForm();
			ScheduleBoxEvent selectedEvent = objEvent;
			eventForm.TargetEvent = selectedEvent;
			eventForm.FormClosed += delegate(object form, FormClosedEventArgs eventargs)
			{
				// Respect user choice
				if (((Gizmox.WebGUI.Forms.Form)form).DialogResult == DialogResult.OK)
				{
					// <-----------[ Set first date to Start date to ensure it's visiblity to user ]---------->
					demoScheduleBox.FirstDate = eventForm.TargetEvent.Start;
				}
			};
			eventForm.ShowDialog();
		}

		/// <summary>
		/// Deletes the objEvent if user confirmed.
		/// </summary>
		public static void ProcessDeleteEvent(
			Gizmox.WebGUI.Forms.ScheduleBox demoScheduleBox, ScheduleBoxEvent objEvent)
		{
			MessageBox.Show("Are you sure to delete the event?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
				delegate(object sender, EventArgs args)
				{
					if (((Gizmox.WebGUI.Forms.Form)sender).DialogResult == DialogResult.OK)
						demoScheduleBox.Events.Remove(objEvent);
				});
		}

		/// <summary>
		/// Create an IEnumerable collection of experimental events
		/// </summary>
		public static IEnumerable<ScheduleBoxEvent> GetEvents()
		{
			List<ScheduleBoxEvent> events = new List<ScheduleBoxEvent>();

			//Day 1 - 28/11/2010
			events.Add(Create(
			new DateTime(2010, 11, 28, 8, 15, 00),
			new DateTime(2010, 11, 28, 9, 30, 00),
			"BI Upgrade – A chance to do it right",
			"In this session we will share the best practices and tips upgrading Microsoft BI platform. Upgrading projects are the best chance to do it right, don't miss it. End to end explanation, planning to implementation and QA. Best practices in SSIS and SSAS. With an experience of many large upgrades projects we will give you the keys for success upgrades."
			));

			events.Add(Create(
			new DateTime(2010, 11, 28, 10, 30, 00),
			new DateTime(2010, 11, 28, 11, 00, 00),
			"Developers Tools and Technologies Keynote",
			"Introduction to the new dev technologies."));


			events.Add(Create(
			new DateTime(2010, 11, 28, 16, 15, 00),
			new DateTime(2010, 11, 28, 17, 25, 00),
			"Business Intelligence platform",
			"Presenting Visio services, PerformancePoint Services, Excel Services, PowerPivot and many other great components "
			));

			//Day 2 - 29/11/2010
			events.Add(Create(
			new DateTime(2010, 11, 29, 9, 15, 00),
			new DateTime(2010, 11, 29, 11, 25, 00),
			"Parallel Programming in .NET Framework",
			".NET 4 include new technologies for enabling parallelism in managed applications."
			));

			events.Add(Create(
			new DateTime(2010, 11, 29, 12, 15, 00),
			new DateTime(2010, 11, 29, 14, 25, 00),
			"Building Your First Application in the Cloud",
			"This session will introduce tools and technologies for cloud development, scalability and cloud design patterns."
			));

			events.Add(Create(
			new DateTime(2010, 11, 29, 16, 15, 00),
			new DateTime(2010, 11, 29, 17, 25, 00),
			"Virtualization scenarios for business critical Applications",
			"This session covers virtualization scenarios, the customer pain points and how a combination of systems to solves them. "
			));

			//Day 3 - 30/11/2010
			events.Add(Create(
			new DateTime(2010, 11, 30, 8, 00, 00),
			new DateTime(2010, 11, 30, 9, 00, 00),
			"Breakfast",
			"All included. 3 persons per table."
			));

			events.Add(Create(
			new DateTime(2010, 11, 30, 11, 30, 00),
			new DateTime(2010, 11, 30, 14, 00, 00),
			"Social Computing at its best",
			"Social Computing is 2010's new buzz word but how can we effectivly bring the new Web 2.0 world into the enterprise?"
			));

			events.Add(Create(
			new DateTime(2010, 11, 30, 14, 30, 00),
			new DateTime(2010, 11, 30, 17, 00, 00),
			"Extending the private cloud partners solutions panel",
			"This special panel will host our major partners talking about the integration with Private Cloud solutions in the world of hardware and storage."
			));

			// Overlapping events
			events.Add(Create(
			new DateTime(2010, 11, 30, 16, 30, 00),
			new DateTime(2010, 11, 30, 17, 30, 00),
			"Gizmox - Press conference",
			"Gizmox - the only .NET based vendor to offer instant Client/Server CloudMove - announces a new free downloadable assessment tool."
			));


			// LONG events crossing the few days
			events.Add(Create(
			new DateTime(2010, 11, 23, 10, 00, 00),
			new DateTime(2010, 11, 25, 21, 30, 00),
			"Unplanned free time - [long event crossing the few days]",
			"Consider to use this free time to schedule other events."
			));

			events.Add(Create(
			new DateTime(2010, 11, 24, 13, 00, 00),
			new DateTime(2010, 11, 26, 18, 30, 00),
			"Planned free time - [long event crossing the few days]",
			"Use this free time to travel with guests"
			));

			return events;
		}


	}
}
