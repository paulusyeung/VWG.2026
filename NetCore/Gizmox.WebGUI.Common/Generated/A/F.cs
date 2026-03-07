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

namespace A
{
	internal abstract class F
	{
		internal class E : F
		{
			private static DbProviderFactory B;

			private static string C;

			static E()
			{
				ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["Gizmox.WebGUI.Virtualization.Connection"];
				if (connectionStringSettings == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new Exception("Could not find configured connection string named 'Gizmox.WebGUI.Virtualization.Connection'.");
				}
				B = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
				if (B == null)
				{
					/*OpCode not supported: LdMemberToken*/;
					throw new Exception($"Could not get DbProviderFactory from the '{connectionStringSettings.ProviderName}' provider name.");
				}
				C = connectionStringSettings.ConnectionString;
			}

			private IDbConnection CreateConnection()
			{
				DbConnection dbConnection = B.CreateConnection();
				((IDbConnection)dbConnection).ConnectionString = C;
				((IDbConnection)dbConnection).Open();
				return dbConnection;
			}

			private void AddParameter(IDbCommand objDbCommand, string strName, object objValue)
			{
				DbParameter dbParameter = B.CreateParameter();
				dbParameter.ParameterName = strName;
				dbParameter.Value = objValue;
				objDbCommand.Parameters.Add(dbParameter);
			}

			private VirtualNode GetVirtualNode(IDataReader objDbDataReader)
			{
				return new VirtualNode(objDbDataReader.GetGuid(objDbDataReader.GetOrdinal("Id")), objDbDataReader.GetString(objDbDataReader.GetOrdinal("Name")), objDbDataReader.GetGuid(objDbDataReader.GetOrdinal("ParentId")), objDbDataReader.GetGuid(objDbDataReader.GetOrdinal("Type")), objDbDataReader.GetGuid(objDbDataReader.GetOrdinal("Forest")), objDbDataReader.GetDateTime(objDbDataReader.GetOrdinal("CreatedOn")), objDbDataReader.GetString(objDbDataReader.GetOrdinal("CreatedBy")), objDbDataReader.GetDateTime(objDbDataReader.GetOrdinal("UpdatedOn")), objDbDataReader.GetString(objDbDataReader.GetOrdinal("UpdatedBy")), objDbDataReader.GetGuid(objDbDataReader.GetOrdinal("DataId")), objDbDataReader.GetString(objDbDataReader.GetOrdinal("DataValue")), GetDataContentLength(objDbDataReader), objDbDataReader.GetBoolean(objDbDataReader.GetOrdinal("IsNew")), objDbDataReader.GetInt64(objDbDataReader.GetOrdinal("Attributes")));
			}

			private int GetDataContentLength(IDataReader objDbDataReader)
			{
				int ordinal = objDbDataReader.GetOrdinal("DataContentLength");
				if (ordinal <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!objDbDataReader.IsDBNull(ordinal))
					{
						return (int)objDbDataReader.GetInt64(ordinal);
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				return 0;
			}

			internal override VirtualNode Move(VirtualReference objSourceReference, VirtualReference objTargetReference)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "MoveVirtualNode";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "SourceRootId", objSourceReference.RootId);
						AddParameter(dbCommand, "SourcePath", objSourceReference.Path);
						AddParameter(dbCommand, "SourcePathType", objSourceReference.PathType);
						AddParameter(dbCommand, "SourceNodeName", objSourceReference.NodeName);
						AddParameter(dbCommand, "SourceNodeType", objSourceReference.NodeType);
						AddParameter(dbCommand, "SourceForest", objSourceReference.ForestId);
						AddParameter(dbCommand, "TargetRootId", objTargetReference.RootId);
						AddParameter(dbCommand, "TargetPath", objTargetReference.Path);
						AddParameter(dbCommand, "TargetPathType", objTargetReference.PathType);
						AddParameter(dbCommand, "TargetNodeName", objTargetReference.NodeName);
						AddParameter(dbCommand, "TargetNodeType", objTargetReference.NodeType);
						AddParameter(dbCommand, "TargetForest", objTargetReference.ForestId);
						AddParameter(dbCommand, "MovedBy", NormalizeParameter(VirtualUser.Current.Username));
						using IDataReader dataReader = dbCommand.ExecuteReader();
						if (!dataReader.Read())
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							result = GetVirtualNode(dataReader);
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override VirtualNode Copy(VirtualReference objSourceReference, VirtualReference objTargetReference)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					using IDbCommand dbCommand = dbConnection.CreateCommand();
					dbCommand.CommandText = "CopyVirtualNode";
					dbCommand.CommandType = CommandType.StoredProcedure;
					AddParameter(dbCommand, "SourceRootId", objSourceReference.RootId);
					AddParameter(dbCommand, "SourcePath", objSourceReference.Path);
					AddParameter(dbCommand, "SourcePathType", objSourceReference.PathType);
					AddParameter(dbCommand, "SourceNodeName", objSourceReference.NodeName);
					AddParameter(dbCommand, "SourceNodeType", objSourceReference.NodeType);
					AddParameter(dbCommand, "SourceForest", objSourceReference.ForestId);
					AddParameter(dbCommand, "TargetRootId", objTargetReference.RootId);
					AddParameter(dbCommand, "TargetPath", objTargetReference.Path);
					AddParameter(dbCommand, "TargetPathType", objTargetReference.PathType);
					AddParameter(dbCommand, "TargetNodeName", objTargetReference.NodeName);
					AddParameter(dbCommand, "TargetNodeType", objTargetReference.NodeType);
					AddParameter(dbCommand, "TargetForest", objTargetReference.ForestId);
					AddParameter(dbCommand, "CreatedBy", NormalizeParameter(VirtualUser.Current.Username));
					IDataReader dataReader = dbCommand.ExecuteReader();
					try
					{
						if (!dataReader.Read())
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							result = GetVirtualNode(dataReader);
						}
					}
					finally
					{
						if (dataReader == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dataReader.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override VirtualNode Create(VirtualReference objVirtualReference, string strName, Guid objType, long lngAttributes, Guid objDataId, string strDataValue, byte[] arrDataContent)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "CreateVirtualNode";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "Name", NormalizeParameter(strName));
						AddParameter(dbCommand, "Type", objType);
						AddParameter(dbCommand, "CreatedBy", NormalizeParameter(VirtualUser.Current.Username));
						AddParameter(dbCommand, "Attributes", lngAttributes);
						AddParameter(dbCommand, "DataId", objDataId);
						AddParameter(dbCommand, "DataValue", NormalizeParameter(strDataValue));
						AddParameter(dbCommand, "DataContent", arrDataContent);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							if (dataReader.Read())
							{
								result = GetVirtualNode(dataReader);
							}
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override void Delete(VirtualReference objVirtualReference, bool blnRecursive)
			{
				using IDbConnection dbConnection = CreateConnection();
				using IDbCommand dbCommand = dbConnection.CreateCommand();
				dbCommand.CommandText = "DeleteVirtualNode";
				dbCommand.CommandType = CommandType.StoredProcedure;
				AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
				AddParameter(dbCommand, "Path", objVirtualReference.Path);
				AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
				AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
				AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
				AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
				dbCommand.ExecuteNonQuery();
			}

			internal override void Update(VirtualReference objVirtualReference, string strNewName)
			{
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "SetVirtualNodeName";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "UpdatedBy", NormalizeParameter(VirtualUser.Current.Username));
						AddParameter(dbCommand, "Name", NormalizeParameter(strNewName));
						dbCommand.ExecuteNonQuery();
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
			}

			internal override void Update(VirtualReference objVirtualReference, long lngAttributes)
			{
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "SetVirtualNodeAttributes";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "UpdatedBy", NormalizeParameter(VirtualUser.Current.Username));
						AddParameter(dbCommand, "Attributes", lngAttributes);
						dbCommand.ExecuteNonQuery();
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
			}

			internal override void Update(VirtualReference objVirtualReference, Guid objDataId, string strDataValue, byte[] arrDataContent)
			{
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "SetVirtualNodeData";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "UpdatedBy", NormalizeParameter(VirtualUser.Current.Username));
						AddParameter(dbCommand, "DataId", objDataId);
						AddParameter(dbCommand, "DataValue", NormalizeParameter(strDataValue));
						AddParameter(dbCommand, "DataContent", NormalizeParameter(arrDataContent));
						dbCommand.ExecuteNonQuery();
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
			}

			internal override Stream CreateEmptyContent()
			{
				return new MemoryStream();
			}

			internal override Stream ReadContent(VirtualReference objVirtualReference)
			{
				MemoryStream memoryStream = null;
				using (IDbConnection dbConnection = CreateConnection())
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodeContent";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							if (!dataReader.Read())
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								byte[] array = (byte[])dataReader[0];
								if (array == null)
								{
									/*OpCode not supported: LdMemberToken*/;
									memoryStream = new MemoryStream();
								}
								else
								{
									memoryStream = new MemoryStream();
									memoryStream.Write(array, 0, array.Length);
									memoryStream.Position = 0L;
								}
							}
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				return memoryStream;
			}

			internal override VirtualNode ReadParent(VirtualReference objVirtualReference)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					using IDbCommand dbCommand = dbConnection.CreateCommand();
					dbCommand.CommandText = "GetVirtualNodeParent";
					dbCommand.CommandType = CommandType.StoredProcedure;
					AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
					AddParameter(dbCommand, "Path", objVirtualReference.Path);
					AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
					AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
					AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
					AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
					using IDataReader dataReader = dbCommand.ExecuteReader();
					if (!dataReader.Read())
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						result = GetVirtualNode(dataReader);
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override VirtualNode ReadRoot(VirtualReference objVirtualReference)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodeRoot";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							if (!dataReader.Read())
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								result = GetVirtualNode(dataReader);
							}
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override VirtualNode Read(VirtualReference objVirtualReference)
			{
				VirtualNode result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					using IDbCommand dbCommand = dbConnection.CreateCommand();
					dbCommand.CommandText = "GetVirtualNode";
					dbCommand.CommandType = CommandType.StoredProcedure;
					AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
					AddParameter(dbCommand, "Path", objVirtualReference.Path);
					AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
					AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
					AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
					AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
					IDataReader dataReader = dbCommand.ExecuteReader();
					try
					{
						if (!dataReader.Read())
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							result = GetVirtualNode(dataReader);
						}
					}
					finally
					{
						if (dataReader == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dataReader.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			private object NormalizeParameter(byte[] arrBytes)
			{
				if (arrBytes == null)
				{
					return new byte[0];
				}
				return arrBytes;
			}

			private object NormalizeParameter(string strParamterValue)
			{
				if (strParamterValue != null)
				{
					/*OpCode not supported: LdMemberToken*/;
					return strParamterValue;
				}
				return string.Empty;
			}

			internal override string ReadPath(VirtualReference objVirtualReference)
			{
				string result = null;
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodePath";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							if (!dataReader.Read())
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								result = (string)dataReader[0];
							}
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
				return result;
			}

			internal override VirtualNode[] ReadList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB, string strSearchPattern)
			{
				VirtualNode[] array = new VirtualNode[0];
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodes";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "TypeFilterA", objTypeFilterA);
						AddParameter(dbCommand, "TypeFilterB", objTypeFilterB);
						AddParameter(dbCommand, "SearchPattern", strSearchPattern);
						using IDataReader dataReader = dbCommand.ExecuteReader();
						List<VirtualNode> list = new List<VirtualNode>();
						while (dataReader.Read())
						{
							/*OpCode not supported: LdMemberToken*/;
							list.Add(GetVirtualNode(dataReader));
						}
						return list.ToArray();
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
			}

			internal override int GetListCount(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB)
			{
				int result = 0;
				using (IDbConnection dbConnection = CreateConnection())
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodesCount";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "TypeFilterA", objTypeFilterA);
						AddParameter(dbCommand, "TypeFilterB", objTypeFilterB);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							if (!dataReader.Read())
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								result = dataReader.GetInt32(0);
							}
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				return result;
			}

			internal override string[] ReadNameList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB, string strSearchPattern)
			{
				string[] array = new string[0];
				IDbConnection dbConnection = CreateConnection();
				try
				{
					IDbCommand dbCommand = dbConnection.CreateCommand();
					try
					{
						dbCommand.CommandText = "GetVirtualNodeNames";
						dbCommand.CommandType = CommandType.StoredProcedure;
						AddParameter(dbCommand, "RootId", objVirtualReference.RootId);
						AddParameter(dbCommand, "Path", objVirtualReference.Path);
						AddParameter(dbCommand, "PathType", objVirtualReference.PathType);
						AddParameter(dbCommand, "NodeName", objVirtualReference.NodeName);
						AddParameter(dbCommand, "NodeType", objVirtualReference.NodeType);
						AddParameter(dbCommand, "Forest", objVirtualReference.ForestId);
						AddParameter(dbCommand, "TypeFilterA", objTypeFilterA);
						AddParameter(dbCommand, "TypeFilterB", objTypeFilterB);
						AddParameter(dbCommand, "SearchPattern", strSearchPattern);
						IDataReader dataReader = dbCommand.ExecuteReader();
						try
						{
							List<string> list = new List<string>();
							while (dataReader.Read())
							{
								list.Add(dataReader.GetString(0));
							}
							return list.ToArray();
						}
						finally
						{
							if (dataReader == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								dataReader.Dispose();
							}
						}
					}
					finally
					{
						if (dbCommand == null)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							dbCommand.Dispose();
						}
					}
				}
				finally
				{
					if (dbConnection == null)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						dbConnection.Dispose();
					}
				}
			}
		}

		private static F A;

		public static F Current => A;

		static F()
		{
			A = new E();
		}

		internal VirtualNode Create(VirtualReference objVirtualReference, string strName, Guid objType, long lngAttributes)
		{
			return Create(objVirtualReference, strName, objType, lngAttributes, Guid.Empty, string.Empty, new byte[0]);
		}

		internal VirtualNode Create(VirtualReference objVirtualReference, string strName, Guid objType)
		{
			return Create(objVirtualReference, strName, objType, 0L);
		}

		internal abstract VirtualNode Create(VirtualReference objVirtualReference, string strName, Guid objType, long lngAttributes, Guid objDataId, string strDataValue, byte[] arrDataContent);

		internal VirtualNode Create(VirtualReference objVirtualReference, string strName, Guid objType, Guid objDataId, string strDataValue, byte[] arrDataContent)
		{
			return Create(objVirtualReference, strName, objType, 0L, objDataId, strDataValue, arrDataContent);
		}

		internal void Delete(VirtualReference objVirtualReference)
		{
			Delete(objVirtualReference, blnRecursive: false);
		}

		internal abstract void Delete(VirtualReference objVirtualReference, bool blnRecursive);

		internal abstract void Update(VirtualReference objVirtualReference, string strNewName);

		internal abstract void Update(VirtualReference objVirtualReference, long lngAttributes);

		internal abstract void Update(VirtualReference objVirtualReference, Guid objDataId, string strDataValue, byte[] arrDataContent);

		internal void Update(VirtualReference objVirtualReference, Guid objDataId, string strDataValue, Stream objContentStream)
		{
			if (objContentStream.Position == 0L)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objContentStream.Position = 0L;
			}
			byte[] array = new byte[objContentStream.Length];
			objContentStream.Read(array, 0, array.Length);
			Update(objVirtualReference, objDataId, strDataValue, array);
		}

		internal abstract VirtualNode Read(VirtualReference objVirtualReference);

		internal abstract VirtualNode Copy(VirtualReference objSourceReference, VirtualReference objTargetReference);

		internal abstract VirtualNode Move(VirtualReference objSourceReference, VirtualReference objTargetReference);

		internal abstract VirtualNode ReadParent(VirtualReference virtualReference);

		internal abstract VirtualNode ReadRoot(VirtualReference virtualReference);

		internal abstract Stream ReadContent(VirtualReference objVirtualReference);

		internal abstract string ReadPath(VirtualReference objVirtualReference);

		internal abstract VirtualNode[] ReadList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB, string strSearchPattern);

		internal VirtualNode[] ReadList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB)
		{
			return ReadList(objVirtualReference, objTypeFilterA, objTypeFilterB, string.Empty);
		}

		internal abstract string[] ReadNameList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB, string strSearchPattern);

		internal string[] ReadNameList(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB)
		{
			return ReadNameList(objVirtualReference, objTypeFilterA, objTypeFilterB, string.Empty);
		}

		internal abstract int GetListCount(VirtualReference objVirtualReference, Guid objTypeFilterA, Guid objTypeFilterB);

		internal abstract Stream CreateEmptyContent();
	}
}
