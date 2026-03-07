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

namespace Gizmox.WebGUI.Forms
{
	[Flags]
	[Editor("Gizmox.WebGUI.Forms.Design.ShortcutKeysEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[TypeConverter(typeof(KeysConverter))]
	public enum Keys
	{
		A = 0x41,
		Add = 0x6B,
		Alt = 0x40000,
		Apps = 0x5D,
		Attn = 0xF6,
		B = 0x42,
		Back = 8,
		BrowserBack = 0xA6,
		BrowserFavorites = 0xAB,
		BrowserForward = 0xA7,
		BrowserHome = 0xAC,
		BrowserRefresh = 0xA8,
		BrowserSearch = 0xAA,
		BrowserStop = 0xA9,
		C = 0x43,
		Cancel = 3,
		Capital = 0x14,
		CapsLock = 0x14,
		Clear = 0xC,
		Control = 0x20000,
		ControlKey = 0x11,
		Crsel = 0xF7,
		D = 0x44,
		D0 = 0x30,
		D1 = 0x31,
		D2 = 0x32,
		D3 = 0x33,
		D4 = 0x34,
		D5 = 0x35,
		D6 = 0x36,
		D7 = 0x37,
		D8 = 0x38,
		D9 = 0x39,
		Decimal = 0x6E,
		Delete = 0x2E,
		Divide = 0x6F,
		Down = 0x28,
		E = 0x45,
		End = 0x23,
		Enter = 0xD,
		EraseEof = 0xF9,
		Escape = 0x1B,
		Execute = 0x2B,
		Exsel = 0xF8,
		F = 0x46,
		F1 = 0x70,
		F10 = 0x79,
		F11 = 0x7A,
		F12 = 0x7B,
		F13 = 0x7C,
		F14 = 0x7D,
		F15 = 0x7E,
		F16 = 0x7F,
		F17 = 0x80,
		F18 = 0x81,
		F19 = 0x82,
		F2 = 0x71,
		F20 = 0x83,
		F21 = 0x84,
		F22 = 0x85,
		F23 = 0x86,
		F24 = 0x87,
		F3 = 0x72,
		F4 = 0x73,
		F5 = 0x74,
		F6 = 0x75,
		F7 = 0x76,
		F8 = 0x77,
		F9 = 0x78,
		FinalMode = 0x18,
		G = 0x47,
		H = 0x48,
		HanguelMode = 0x15,
		HangulMode = 0x15,
		HanjaMode = 0x19,
		Help = 0x2F,
		Home = 0x24,
		I = 0x49,
		IMEAceept = 0x1E,
		IMEConvert = 0x1C,
		IMEModeChange = 0x1F,
		IMENonconvert = 0x1D,
		Insert = 0x2D,
		J = 0x4A,
		JunjaMode = 0x17,
		K = 0x4B,
		KanaMode = 0x15,
		KanjiMode = 0x19,
		KeyCode = 0xFFFF,
		L = 0x4C,
		LaunchApplication1 = 0xB6,
		LaunchApplication2 = 0xB7,
		LaunchMail = 0xB4,
		LButton = 1,
		LControlKey = 0xA2,
		Left = 0x25,
		LineFeed = 0xA,
		LMenu = 0xA4,
		LShiftKey = 0xA0,
		LWin = 0x5B,
		M = 0x4D,
		MButton = 4,
		MediaNextTrack = 0xB0,
		MediaPlayPause = 0xB3,
		MediaPreviousTrack = 0xB1,
		MediaStop = 0xB2,
		Menu = 0x12,
		Modifiers = -65536,
		Multiply = 0x6A,
		N = 0x4E,
		Next = 0x22,
		NoName = 0xFC,
		None = 0,
		NumLock = 0x90,
		NumPad0 = 0x60,
		NumPad1 = 0x61,
		NumPad2 = 0x62,
		NumPad3 = 0x63,
		NumPad4 = 0x64,
		NumPad5 = 0x65,
		NumPad6 = 0x66,
		NumPad7 = 0x67,
		NumPad8 = 0x68,
		NumPad9 = 0x69,
		O = 0x4F,
		Oem8 = 0xDF,
		OemBackslash = 0xE2,
		OemClear = 0xFE,
		OemCloseBrackets = 0xDD,
		Oemcomma = 0xBC,
		OemMinus = 0xBD,
		OemOpenBrackets = 0xDB,
		OemPeriod = 0xBE,
		OemPipe = 0xDC,
		Oemplus = 0xBB,
		OemQuestion = 0xBF,
		OemQuotes = 0xDE,
		OemSemicolon = 0xBA,
		Oemtilde = 0xC0,
		P = 0x50,
		Pa1 = 0xFD,
		PageDown = 0x22,
		PageUp = 0x21,
		Pause = 0x13,
		Play = 0xFA,
		Print = 0x2A,
		PrintScreen = 0x2C,
		Prior = 0x21,
		ProcessKey = 0xE5,
		Q = 0x51,
		R = 0x52,
		RButton = 2,
		RControlKey = 0xA3,
		Return = 0xD,
		Right = 0x27,
		RMenu = 0xA5,
		RShiftKey = 0xA1,
		RWin = 0x5C,
		S = 0x53,
		Scroll = 0x91,
		Select = 0x29,
		SelectMedia = 0xB5,
		Separator = 0x6C,
		Shift = 0x10000,
		ShiftKey = 0x10,
		Snapshot = 0x2C,
		Space = 0x20,
		Subtract = 0x6D,
		T = 0x54,
		Tab = 9,
		U = 0x55,
		Up = 0x26,
		V = 0x56,
		VolumeDown = 0xAE,
		VolumeMute = 0xAD,
		VolumeUp = 0xAF,
		W = 0x57,
		X = 0x58,
		XButton1 = 5,
		XButton2 = 6,
		Y = 0x59,
		Z = 0x5A,
		Zoom = 0xFB
	}
}
