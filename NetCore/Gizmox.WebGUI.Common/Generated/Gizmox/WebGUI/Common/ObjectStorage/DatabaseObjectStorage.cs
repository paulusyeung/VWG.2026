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

namespace Gizmox.WebGUI.Common.ObjectStorage
{
	[Serializable]
	public class DatabaseObjectStorage : BaseObjectStorage
	{
		private string mstrConnectionString;

		private string mstrTableName;

		private string mstrKeyColumnName;

		private string mstrObjectColumnName;

		public string ObjectColumnName
		{
			get
			{
				return mstrObjectColumnName;
			}
			set
			{
				mstrObjectColumnName = value;
			}
		}

		public string KeyColumnName
		{
			get
			{
				return mstrKeyColumnName;
			}
			set
			{
				mstrKeyColumnName = value;
			}
		}

		public string TableName
		{
			get
			{
				return mstrTableName;
			}
			set
			{
				mstrTableName = value;
			}
		}

		public string ConnectionString
		{
			get
			{
				return mstrConnectionString;
			}
			set
			{
				mstrConnectionString = value;
			}
		}

		public DatabaseObjectStorage()
		{
		}

		public DatabaseObjectStorage(string strConnectionString, string strTableName, string strKeyColumnName, string strObjectColumnName)
		{
			mstrConnectionString = strConnectionString;
			mstrTableName = strTableName;
			mstrKeyColumnName = strKeyColumnName;
			mstrObjectColumnName = strObjectColumnName;
		}

		public override T RetrieveObject<T>(string strKey)
		{
			SqlConnection sqlConnection = null;
			try
			{
				sqlConnection = new SqlConnection(mstrConnectionString);
				sqlConnection.Open();
				SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
				DataTable dataTable = GetDataTable(sqlConnection, objSqlDataAdapter, strKey);
				if (dataTable.Rows.Count == 0)
				{
					return null;
				}
				string strObject = dataTable.Rows[0][mstrObjectColumnName] as string;
				return ConvertStringToObject<T>(strObject);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		public override void SaveObject<T>(string strKey, T objObject)
		{
			SqlConnection sqlConnection = null;
			try
			{
				TypeDescriptor.GetConverter(typeof(T));
				string text = ConvertObjectToString(objObject);
				sqlConnection = new SqlConnection(mstrConnectionString);
				sqlConnection.Open();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
				DataTable dataTable = GetDataTable(sqlConnection, sqlDataAdapter, strKey);
				new SqlCommandBuilder(sqlDataAdapter);
				if (dataTable.Rows.Count != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					new SqlCommand($"update {mstrTableName} set {mstrObjectColumnName} = '{text}' where {mstrKeyColumnName} = '{strKey}'", sqlConnection).ExecuteNonQuery();
				}
				else
				{
					new SqlCommand($"insert into {mstrTableName} ({mstrKeyColumnName}, {mstrObjectColumnName}) VALUES ('{strKey}', '{text}')", sqlConnection).ExecuteNonQuery();
				}
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		public override bool RemoveObject(string strKey)
		{
			SqlConnection sqlConnection = null;
			try
			{
				sqlConnection = new SqlConnection(mstrConnectionString);
				sqlConnection.Open();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
				DataTable dataTable = GetDataTable(sqlConnection, sqlDataAdapter, strKey);
				if (dataTable.Rows.Count != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					new SqlCommand($"delete from {mstrTableName} where {mstrKeyColumnName} = '{strKey}'", sqlConnection).ExecuteNonQuery();
					sqlDataAdapter.Update(dataTable);
					return true;
				}
				return false;
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		public override string[] GetAllKeys()
		{
			SqlConnection sqlConnection = null;
			List<string> list = new List<string>();
			try
			{
				sqlConnection = new SqlConnection(mstrConnectionString);
				sqlConnection.Open();
				SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
				IEnumerator enumerator = GetDataTable(sqlConnection, objSqlDataAdapter, "").Rows.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						/*OpCode not supported: LdMemberToken*/;
						object obj = ((DataRow)enumerator.Current)[mstrKeyColumnName];
						if (obj == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							list.Add(obj.ToString());
						}
					}
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
			finally
			{
				sqlConnection.Close();
			}
			return list.ToArray();
		}

		private DataTable GetDataTable(SqlConnection objSqlConnection, SqlDataAdapter objSqlDataAdapter, string strKey)
		{
			string text = $"select {mstrKeyColumnName}, {mstrObjectColumnName} from {mstrTableName}";
			if (!string.IsNullOrEmpty(strKey))
			{
				text += $" where {mstrKeyColumnName} = '{strKey}'";
			}
			objSqlDataAdapter.SelectCommand = new SqlCommand(text, objSqlConnection);
			DataTable dataTable = new DataTable(mstrTableName);
			objSqlDataAdapter.Fill(dataTable);
			return dataTable;
		}
	}
}
