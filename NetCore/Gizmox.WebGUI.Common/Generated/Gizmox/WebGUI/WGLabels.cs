#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI
{
	[Serializable]
	public class WGLabels
	{
		public static string Loading => GetString("Loading");

		public static string Sunday => GetString("Sunday");

		public static string Monday => GetString("Monday");

		public static string Tuesday => GetString("Tuesday");

		public static string Wednesday => GetString("Wednesday");

		public static string Thursday => GetString("Thursday");

		public static string Friday => GetString("Friday");

		public static string Saturday => GetString("Saturday");

		public static string SundayShort => GetString("SundayShort");

		public static string MondayShort => GetString("MondayShort");

		public static string TuesdayShort => GetString("TuesdayShort");

		public static string WednesdayShort => GetString("WednesdayShort");

		public static string ThursdayShort => GetString("ThursdayShort");

		public static string FridayShort => GetString("FridayShort");

		public static string SaturdayShort => GetString("SaturdayShort");

		public static string January => GetString("January");

		public static string February => GetString("February");

		public static string March => GetString("March");

		public static string April => GetString("April");

		public static string May => GetString("May");

		public static string June => GetString("June");

		public static string July => GetString("July");

		public static string August => GetString("August");

		public static string September => GetString("September");

		public static string October => GetString("October");

		public static string November => GetString("November");

		public static string December => GetString("December");

		public static string JanuaryShort => GetString("JanuaryShort");

		public static string FebruaryShort => GetString("FebruaryShort");

		public static string MarchShort => GetString("MarchShort");

		public static string AprilShort => GetString("AprilShort");

		public static string MayShort => GetString("MayShort");

		public static string JuneShort => GetString("JuneShort");

		public static string JulyShort => GetString("JulyShort");

		public static string AugustShort => GetString("AugustShort");

		public static string SeptemberShort => GetString("SeptemberShort");

		public static string OctoberShort => GetString("OctoberShort");

		public static string NovemberShort => GetString("NovemberShort");

		public static string DecemberShort => GetString("DecemberShort");

		public static string Ok => GetString("Ok");

		public static string Cancel => GetString("Cancel");

		public static string Apply => GetString("Apply");

		public static string Ignore => GetString("Ignore");

		public static string Retry => GetString("Retry");

		public static string Yes => GetString("Yes");

		public static string No => GetString("No");

		public static string Search => GetString("Search");

		public static string Clear => GetString("Clear");

		public static string Abort => GetString("Abort");

		public static string Next => GetString("Next");

		public static string Previous => GetString("Previous");

		public static string Close => GetString("Close");

		public static string Finish => GetString("Finish");

		public static string Help => GetString("Help");

		public static string Today => GetString("Today");

		public static string Add => GetString("Add");

		public static string Remove => GetString("Remove");

		public static string View => GetString("View");

		public static string Show => GetString("Show");

		public static string Hide => GetString("Hide");

		public static string MoveDown => GetString("MoveDown");

		public static string MoveUp => GetString("MoveUp");

		public static string Ascending => GetString("Ascending");

		public static string Decsending => GetString("Decsending");

		public static string Columns => GetString("Columns");

		public static string Sorting => GetString("Sorting");

		public static string Grouping => GetString("Grouping");

		public static string Open => GetString("Open");

		public static string Back => GetString("Back");

		public static string SelectFilesToUpload => GetString("SelectFilesToUpload");

		public static string Left => GetString("Left");

		public static string Right => GetString("Right");

		public static string DatePicker => GetString("DatePicker");

		public static string MakeNewFolder => GetString("MakeNewFolder");

		public static string Effects => GetString("Effects");

		public static string Strikeout => GetString("Strikeout");

		public static string Underline => GetString("Underline");

		public static string Color => GetString("Color");

		public static string Sample => GetString("Sample");

		public static string Script => GetString("Script");

		public static string FontColon => GetString("FontColon");

		public static string Font => GetString("Font");

		public static string FontStyle => GetString("FontStyle");

		public static string Size => GetString("Size");

		public static string Regular => GetString("Regular");

		public static string Italic => GetString("Italic");

		public static string Bold => GetString("Bold");

		public static string BoldItalic => GetString("BoldItalic");

		public static string More => GetString("More");

		public static string ModifiersColon => GetString("ModifiersColon");

		public static string KeysColon => GetString("KeysColon");

		public static string Reset => GetString("Reset");

		public static string Submit => GetString("Submit");

		public static string TransitionTotalTime => "TTT";

		private static string GetDirAttribute(IContext objContext)
		{
			if (!IsRightToLeft(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
				return "LTR";
			}
			return "RTL";
		}

		private static string GetLeftAttribute(IContext objContext)
		{
			if (!IsRightToLeft(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
				return "left";
			}
			return "right";
		}

		private static string GetRightAttribute(IContext objContext)
		{
			if (IsRightToLeft(objContext))
			{
				return "left";
			}
			return "right";
		}

		private static bool IsRightToLeft(IContext objContext)
		{
			if (objContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return objContext.RightToLeft;
		}

		public static string GetString(string strName, IContext objContext)
		{
			return GetString(strName, objContext, blnApplyCultureInfoValues: false);
		}

		public static string GetString(string strName, IContext objContext, bool blnApplyCultureInfoValues)
		{
			if (!blnApplyCultureInfoValues)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (objContext == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (objContext.CurrentUICulture != null)
					{
						return SR.GetString(objContext.CurrentUICulture, GetName(strName));
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return GetName(strName);
			}
			uint num = SC.ComputeStringHash(strName);
			if (num > 2363768489u)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 3476995255u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num <= 3911251845u)
					{
						if (num > 3766233308u)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num)
							{
							case 3820822815u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "WednesdayShort"))
								{
									break;
								}
								return GetLocalizedDayAbbreviatedName(DayOfWeek.Wednesday, objContext);
							case 3882640957u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "SaturdayAbbreviated"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedAbbreviatedDayName(DayOfWeek.Saturday, objContext);
							case 3894647671u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "Wednesday"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedDayName(DayOfWeek.Wednesday, objContext);
							case 3800771945u:
								if (!(strName == "ThursdayShortest"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedShortestDayName(DayOfWeek.Thursday, objContext);
							case 3911251845u:
								if (!(strName == "June"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedMonthString(6, blnShort: false, objContext);
							}
						}
						else if (num > 3505415673u)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num)
							{
							case 3766233308u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "MondayAbbreviated"))
								{
									break;
								}
								return GetLocalizedAbbreviatedDayName(DayOfWeek.Monday, objContext);
							case 3526961659u:
								if (!(strName == "TuesdayAbbreviated"))
								{
									break;
								}
								return GetLocalizedAbbreviatedDayName(DayOfWeek.Tuesday, objContext);
							}
						}
						else
						{
							switch (num)
							{
							case 3493926232u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "GenitiveJanuary"))
								{
									break;
								}
								return GetLocalizedMonthString(1, blnShort: false, objContext, blnGenitiveName: true);
							case 3505415673u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "Sunday"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedDayName(DayOfWeek.Sunday, objContext);
							}
						}
					}
					else if (num > 4031174830u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 4238833203u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "February"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(2, blnShort: false, objContext);
						case 4245989004u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "GenitiveFebruary"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(2, blnShort: false, objContext, blnGenitiveName: true);
						case 4253028553u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "WednesdayShortest"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedShortestDayName(DayOfWeek.Wednesday, objContext);
						case 4263050160u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "Tuesday"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayName(DayOfWeek.Tuesday, objContext);
						case 4280936556u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "GenitiveJuly"))
							{
								break;
							}
							return GetLocalizedMonthString(7, blnShort: false, objContext, blnGenitiveName: true);
						}
					}
					else if (num > 3924918012u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 4031174830u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "ThursdayAbbreviated"))
							{
								break;
							}
							return GetLocalizedAbbreviatedDayName(DayOfWeek.Thursday, objContext);
						case 3975288839u:
							if (!(strName == "October"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(10, blnShort: false, objContext);
						}
					}
					else
					{
						switch (num)
						{
						case 3923926210u:
							if (!(strName == "MarchShort"))
							{
								break;
							}
							return GetLocalizedMonthString(3, blnShort: true, objContext);
						case 3924918012u:
							if (!(strName == "PMDesignator"))
							{
								break;
							}
							return GetLocalizedAMPMDesignatorString(blnAM: false, blnShort: false, objContext);
						}
					}
				}
				else if (num > 3099624518u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 3229901712u)
					{
						/*OpCode not supported: LdMemberToken*/;
						if (num > 3274005158u)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num)
							{
							case 3276894450u:
								if (!(strName == "SeptemberShort"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedMonthString(9, blnShort: true, objContext);
							case 3476995255u:
								if (!(strName == "NovemberShort"))
								{
									break;
								}
								return GetLocalizedMonthString(11, blnShort: true, objContext);
							case 3363570481u:
								if (!(strName == "GenitiveSeptember"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedMonthString(9, blnShort: false, objContext, blnGenitiveName: true);
							}
						}
						else
						{
							switch (num)
							{
							case 3256006144u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "September"))
								{
									break;
								}
								return GetLocalizedMonthString(9, blnShort: false, objContext);
							case 3274005158u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "AugustShort"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedMonthString(8, blnShort: true, objContext);
							}
						}
					}
					else if (num > 3118674656u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 3229901712u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "March"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(3, blnShort: false, objContext);
						case 3154759506u:
							if (!(strName == "Friday"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayName(DayOfWeek.Friday, objContext);
						}
					}
					else
					{
						switch (num)
						{
						case 3118674656u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "SaturdayShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayAbbreviatedName(DayOfWeek.Saturday, objContext);
						case 3116454008u:
							if (!(strName == "DecemberShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(12, blnShort: true, objContext);
						}
					}
				}
				else if (num > 2636970877u)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 2801973649u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 2880878701u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "TransitionTotalTime"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return TransitionTotalTime;
						case 3002279602u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "GenitiveApril"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(4, blnShort: false, objContext, blnGenitiveName: true);
						case 3099624518u:
							if (!(strName == "PMDesignatorShort"))
							{
								break;
							}
							return GetLocalizedAMPMDesignatorString(blnAM: false, blnShort: true, objContext);
						}
					}
					else
					{
						switch (num)
						{
						case 2725735612u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "SundayAbbreviated"))
							{
								break;
							}
							return GetLocalizedAbbreviatedDayName(DayOfWeek.Sunday, objContext);
						case 2801973649u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "SundayShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayAbbreviatedName(DayOfWeek.Sunday, objContext);
						}
					}
				}
				else if (num > 2582335447u)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 2610292944u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "MayShort"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(5, blnShort: true, objContext);
					case 2636970877u:
						if (!(strName == "January"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(1, blnShort: false, objContext);
					}
				}
				else
				{
					switch (num)
					{
					case 2564533399u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "April"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(4, blnShort: false, objContext);
					case 2582335447u:
						if (!(strName == "Thursday"))
						{
							break;
						}
						return GetLocalizedDayName(DayOfWeek.Thursday, objContext);
					}
				}
			}
			else if (num > 1163822540)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 1810091604)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num <= 2117947313)
					{
						if (num > 1992126328)
						{
							/*OpCode not supported: LdMemberToken*/;
							switch (num)
							{
							case 2078254146u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "TuesdayShortest"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetLocalizedShortestDayName(DayOfWeek.Tuesday, objContext);
							case 2117947313u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "MondayShort"))
								{
									break;
								}
								return GetLocalizedDayAbbreviatedName(DayOfWeek.Monday, objContext);
							}
						}
						else
						{
							switch (num)
							{
							case 1866277967u:
								/*OpCode not supported: LdMemberToken*/;
								if (!(strName == "RightAttribute"))
								{
									break;
								}
								/*OpCode not supported: LdMemberToken*/;
								return GetRightAttribute(objContext);
							case 1992126328u:
								if (!(strName == "GenitiveNovember"))
								{
									break;
								}
								return GetLocalizedMonthString(11, blnShort: false, objContext, blnGenitiveName: true);
							}
						}
					}
					else if (num > 2184092628u)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 2305712907u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "MondayShortest"))
							{
								break;
							}
							return GetLocalizedShortestDayName(DayOfWeek.Monday, objContext);
						case 2323456034u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "TuesdayShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayAbbreviatedName(DayOfWeek.Tuesday, objContext);
						case 2363768489u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "FridayAbbreviated"))
							{
								break;
							}
							return GetLocalizedAbbreviatedDayName(DayOfWeek.Friday, objContext);
						}
					}
					else
					{
						switch (num)
						{
						case 2134756021u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "GenitiveDecember"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(12, blnShort: false, objContext, blnGenitiveName: true);
						case 2184092628u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "DirAttribute"))
							{
								break;
							}
							return GetDirAttribute(objContext);
						}
					}
				}
				else if (num > 1557220238)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num > 1574658204)
					{
						/*OpCode not supported: LdMemberToken*/;
						switch (num)
						{
						case 1714277534u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "December"))
							{
								break;
							}
							return GetLocalizedMonthString(12, blnShort: false, objContext);
						case 1792948479u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "AprilShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(4, blnShort: true, objContext);
						case 1810091604u:
							/*OpCode not supported: LdMemberToken*/;
							if (!(strName == "FridayShort"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedDayAbbreviatedName(DayOfWeek.Friday, objContext);
						}
					}
					else
					{
						switch (num)
						{
						case 1574426987u:
							if (!(strName == "SundayShortest"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedShortestDayName(DayOfWeek.Sunday, objContext);
						case 1574658204u:
							if (!(strName == "August"))
							{
								break;
							}
							/*OpCode not supported: LdMemberToken*/;
							return GetLocalizedMonthString(8, blnShort: false, objContext);
						}
					}
				}
				else if (num > 1330128233)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 1354006397u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "JanuaryShort"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(1, blnShort: true, objContext);
					case 1557220238u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "WednesdayAbbreviated"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedAbbreviatedDayName(DayOfWeek.Wednesday, objContext);
					}
				}
				else
				{
					switch (num)
					{
					case 1330128233u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "AMDesignatorShort"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedAMPMDesignatorString(blnAM: true, blnShort: true, objContext);
					case 1191294613u:
						if (!(strName == "GenitiveMarch"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(3, blnShort: false, objContext, blnGenitiveName: true);
					}
				}
			}
			else if (num > 570164227)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num > 978773849)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 1000858150u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "May"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(5, blnShort: false, objContext);
					case 1051015743u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "November"))
						{
							break;
						}
						return GetLocalizedMonthString(11, blnShort: false, objContext);
					case 1155680656u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "SaturdayShortest"))
						{
							break;
						}
						return GetLocalizedShortestDayName(DayOfWeek.Saturday, objContext);
					case 1163822540u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "FridayShortest"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedShortestDayName(DayOfWeek.Friday, objContext);
					case 1068583255u:
						if (!(strName == "JulyShort"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedMonthString(7, blnShort: true, objContext);
					}
				}
				else if (num > 756625217)
				{
					/*OpCode not supported: LdMemberToken*/;
					switch (num)
					{
					case 906485995u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "GenitiveMay"))
						{
							break;
						}
						return GetLocalizedMonthString(5, blnShort: false, objContext, blnGenitiveName: true);
					case 978773849u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "Monday"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedDayName(DayOfWeek.Monday, objContext);
					}
				}
				else
				{
					switch (num)
					{
					case 639282032u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "LeftAttribute"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLeftAttribute(objContext);
					case 756625217u:
						/*OpCode not supported: LdMemberToken*/;
						if (!(strName == "AMDesignator"))
						{
							break;
						}
						/*OpCode not supported: LdMemberToken*/;
						return GetLocalizedAMPMDesignatorString(blnAM: true, blnShort: false, objContext);
					}
				}
			}
			else if (num > 119792854)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (num)
				{
				case 200141063u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "GenitiveAugust"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedMonthString(8, blnShort: false, objContext, blnGenitiveName: true);
				case 241744182u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "Saturday"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedDayName(DayOfWeek.Saturday, objContext);
				case 388403263u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "ThursdayShort"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedDayAbbreviatedName(DayOfWeek.Thursday, objContext);
				case 570164227u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "FebruaryShort"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedMonthString(2, blnShort: true, objContext);
				case 242017333u:
					if (!(strName == "JuneShort"))
					{
						break;
					}
					return GetLocalizedMonthString(6, blnShort: true, objContext);
				}
			}
			else if (num > 55553775)
			{
				/*OpCode not supported: LdMemberToken*/;
				switch (num)
				{
				case 63958274u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "GenitiveOctober"))
					{
						break;
					}
					return GetLocalizedMonthString(10, blnShort: false, objContext, blnGenitiveName: true);
				case 119792854u:
					/*OpCode not supported: LdMemberToken*/;
					if (!(strName == "GenitiveJune"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedMonthString(6, blnShort: false, objContext, blnGenitiveName: true);
				}
			}
			else
			{
				switch (num)
				{
				case 18653215u:
					if (!(strName == "July"))
					{
						break;
					}
					return GetLocalizedMonthString(7, blnShort: false, objContext);
				case 55553775u:
					if (!(strName == "OctoberShort"))
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
					return GetLocalizedMonthString(10, blnShort: true, objContext);
				}
			}
			if (objContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objContext.CurrentUICulture != null)
				{
					return SR.GetString(objContext.CurrentUICulture, GetName(strName));
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			return GetName(strName);
		}

		public static string GetString(string strName)
		{
			if (Global.Context == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (Global.Context.CurrentUICulture != null)
			{
				return SR.GetString(Global.Context.CurrentUICulture, GetName(strName));
			}
			return strName;
		}

		public static string GetLocalizedDayName(DayOfWeek enmWeekDay, IContext objContext)
		{
			string result = enmWeekDay.ToString();
			if (IsValidCultureContext(objContext))
			{
				result = objContext.CurrentUICulture.DateTimeFormat.GetDayName(enmWeekDay);
			}
			return result;
		}

		private static bool IsValidCultureContext(IContext objContext)
		{
			if (objContext != null)
			{
				return objContext.CurrentUICulture != null;
			}
			return false;
		}

		public static string GetLocalizedDayAbbreviatedName(DayOfWeek enmWeekDay, IContext objContext)
		{
			string result = enmWeekDay.ToString();
			if (!IsValidCultureContext(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = objContext.CurrentUICulture.DateTimeFormat.GetAbbreviatedDayName(enmWeekDay);
			}
			return result;
		}

		public static string GetLocalizedShortestDayName(DayOfWeek enmWeekDay, IContext objContext)
		{
			string result = enmWeekDay.ToString();
			if (!IsValidCultureContext(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = objContext.CurrentUICulture.DateTimeFormat.GetShortestDayName(enmWeekDay);
			}
			return result;
		}

		public static string GetLocalizedAbbreviatedDayName(DayOfWeek enmWeekDay, IContext objContext)
		{
			string result = enmWeekDay.ToString();
			if (!IsValidCultureContext(objContext))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				result = objContext.CurrentUICulture.DateTimeFormat.GetAbbreviatedDayName(enmWeekDay);
			}
			return result;
		}

		public static string GetLocalizedMonthString(int intMonthIndex, bool blnShort, IContext objContext)
		{
			return GetLocalizedMonthString(intMonthIndex, blnShort, objContext, blnGenitiveName: false);
		}

		public static string GetLocalizedMonthString(int intMonthIndex, bool blnShort, IContext objContext, bool blnGenitiveName)
		{
			string result = "Month " + intMonthIndex;
			if (objContext != null)
			{
				if (objContext.CurrentUICulture == null)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else if (!blnShort)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!blnGenitiveName)
					{
						/*OpCode not supported: LdMemberToken*/;
						result = objContext.CurrentUICulture.DateTimeFormat.GetMonthName(intMonthIndex);
					}
					else
					{
						result = objContext.CurrentUICulture.DateTimeFormat.MonthGenitiveNames[intMonthIndex - 1];
					}
				}
				else
				{
					result = objContext.CurrentUICulture.DateTimeFormat.GetAbbreviatedMonthName(intMonthIndex);
				}
			}
			return result;
		}

		public static string GetLocalizedAMPMDesignatorString(bool blnAM, bool blnShort, IContext objContext)
		{
			object obj;
			if (!blnShort)
			{
				if (blnAM)
				{
					/*OpCode not supported: LdMemberToken*/;
					obj = "AM";
				}
				else
				{
					obj = "PM";
				}
			}
			else if (blnAM)
			{
				/*OpCode not supported: LdMemberToken*/;
				obj = "A";
			}
			else
			{
				obj = "P";
			}
			string result = (string)obj;
			if (objContext == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else if (objContext.CurrentUICulture == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				string text;
				if (!blnAM)
				{
					/*OpCode not supported: LdMemberToken*/;
					text = objContext.CurrentUICulture.DateTimeFormat.PMDesignator;
				}
				else
				{
					text = objContext.CurrentUICulture.DateTimeFormat.AMDesignator;
				}
				if (string.IsNullOrEmpty(text))
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					result = ((!blnShort) ? text : text[0].ToString());
				}
			}
			return result;
		}

		private static string GetName(string strName)
		{
			return $"WGLabels{strName}";
		}
	}
}
