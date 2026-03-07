// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CalendarUtils
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// DateTimePicker and MonthCalendar utils class. Stores culture-specific and default date/time related static values.
  /// </summary>
  internal static class CalendarUtils
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    internal static readonly DateTime MaxDateTime;
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static readonly DateTime MinDateTime = new DateTime(1753, 1, 1);

    /// <summary>Gets the maximum date time.</summary>
    internal static DateTime MaximumDateTime
    {
      get
      {
        DateTime supportedDateTime = CultureInfo.CurrentUICulture.Calendar.MaxSupportedDateTime;
        return supportedDateTime.Year > CalendarUtils.MaxDateTime.Year ? CalendarUtils.MaxDateTime : supportedDateTime;
      }
    }

    /// <summary>Gets the minimum date time.</summary>
    internal static DateTime MinimumDateTime
    {
      get
      {
        DateTime supportedDateTime = CultureInfo.CurrentUICulture.Calendar.MinSupportedDateTime;
        return supportedDateTime.Year < CalendarUtils.MinDateTime.Year ? CalendarUtils.MinDateTime : supportedDateTime;
      }
    }

    /// <summary>
    /// Initializes the <see cref="T:Gizmox.WebGUI.Forms.CalendarUtils" /> class.
    /// </summary>
    static CalendarUtils() => CalendarUtils.MaxDateTime = new DateTime(9998, 12, 31);

    /// <summary>Gets the effective max date.</summary>
    /// <param name="objMaxDate">The max date.</param>
    /// <returns></returns>
    internal static DateTime GetEffectiveMaxDate(DateTime objMaxDate)
    {
      DateTime maximumDateTime = CalendarUtils.MaximumDateTime;
      return objMaxDate > maximumDateTime ? maximumDateTime : objMaxDate;
    }

    /// <summary>Gets the effective min date.</summary>
    /// <param name="objMinDate">The min date.</param>
    /// <returns></returns>
    internal static DateTime GetEffectiveMinDate(DateTime objMinDate)
    {
      DateTime minimumDateTime = CalendarUtils.MinimumDateTime;
      return objMinDate < minimumDateTime ? minimumDateTime : objMinDate;
    }

    /// <summary>Represents the selection range select direction.</summary>
    internal enum SelectDirection
    {
      LeftToRight,
      RightToLeft,
      None,
    }
  }
}
