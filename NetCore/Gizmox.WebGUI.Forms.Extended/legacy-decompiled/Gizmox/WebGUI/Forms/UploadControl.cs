using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Web;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// Summary description for UploadControl
///
/// jQuery File Upload Plugin 5.40.1
/// https://github.com/blueimp/jQuery-File-Upload
/// http://blueimp.github.io/jQuery-File-Upload/
///
/// Copyright 2010, Sebastian Tschan
/// https://blueimp.net
///
/// Licensed under the MIT license:
/// http://www.opensource.org/licenses/MIT
/// </summary>
[Serializable]
[ToolboxBitmap(typeof(UploadControl), "Upload.UploadControl.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[ToolboxItem(true)]
[MetadataTag("UploadControl")]
[Skin(typeof(UploadControlSkin))]
public class UploadControl : Control, IRequiresRegistration
{
	private static readonly SerializableProperty UploadMaxNumberOfFilesProperty = SerializableProperty.Register("UploadMaxNumberOfFiles", typeof(int), typeof(UploadControl));

	private static readonly SerializableProperty UploadMaxFileSizeProperty = SerializableProperty.Register("UploadMaxFileSize", typeof(long), typeof(UploadControl));

	private static readonly SerializableProperty UploadMinFileSizeProperty = SerializableProperty.Register("UploadMinFileSize", typeof(long), typeof(UploadControl));

	private static readonly SerializableProperty UploadFileTypesProperty = SerializableProperty.Register("UploadFileTypes", typeof(string), typeof(UploadControl));

	private static readonly SerializableProperty UploadTempFilePathProperty = SerializableProperty.Register("UploadTempFilePath", typeof(string), typeof(UploadControl));

	private static readonly SerializableProperty UploadBufferSizeProperty = SerializableProperty.Register("UploadBufferSize", typeof(int), typeof(UploadControl));

	private static readonly SerializableProperty UploadClientChunkSizeProperty = SerializableProperty.Register("UploadClientChunkSize", typeof(int), typeof(UploadControl));

	private static readonly SerializableProperty UploadTextProperty = SerializableProperty.Register("UploadText", typeof(string), typeof(UploadControl));

	private static readonly SerializableProperty UploadShowFilenameOnBarProperty = SerializableProperty.Register("UploadShowFilenameOnBar", typeof(bool), typeof(UploadControl));

	private static readonly SerializableProperty UploadShowSpeedOnBarProperty = SerializableProperty.Register("UploadShowSpeedOnBar", typeof(bool), typeof(UploadControl));

	/// <summary>
	/// Internal temporary full name of file being uploaded in chunks.
	/// </summary>
	private string mstrChunkedFileName;

	/// <summary>
	/// File has been added to the upload control, uploads will now start
	/// </summary>
	private static readonly SerializableEvent UploadBatchStartingEvent;

	/// <summary>
	/// The gateway file complete event registration
	/// </summary>
	private static readonly SerializableEvent UploadChunkRequestCompletedEvent;

	/// <summary>
	/// The upload file complete event registration
	/// </summary>
	private static readonly SerializableEvent UploadFileCompletedEvent;

	/// <summary>
	/// The upload batch complete event registration
	/// </summary>
	private static readonly SerializableEvent UploadBatchCompletedEvent;

	/// <summary>
	/// The unhandled error event registration
	/// </summary>
	private static readonly SerializableEvent UploadErrorEvent;

	/// <summary>
	/// Maximum number of files that can be uploaded in each multiselection. 0 = Unlimited.
	/// </summary>
	[Category("UploadControl")]
	[Description("Maximum number of files that can be uploaded in each multiselection. 0 = Unlimited")]
	[DefaultValue(0)]
	public int UploadMaxNumberOfFiles
	{
		get
		{
			return GetValue(UploadMaxNumberOfFilesProperty, 0);
		}
		set
		{
			if (UploadMaxNumberOfFiles != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("UploadMaxNumberOfFiles", string.Format(SR.GetString("UploadControlErrorMinSize"), value));
				}
				SetValue(UploadMaxNumberOfFilesProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Maximum size of upload file in bytes. 0 = Unlimited
	/// </summary>
	[Category("UploadControl")]
	[Description("Maximum size of upload file in bytes. 0 = Unlimited")]
	[DefaultValue(0)]
	public long UploadMaxFileSize
	{
		get
		{
			return GetValue(UploadMaxFileSizeProperty, 0L);
		}
		set
		{
			if (UploadMaxFileSize != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("UploadMaxFileSize", string.Format(SR.GetString("UploadControlErrorMinSize"), value));
				}
				SetValue(UploadMaxFileSizeProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Minimum size of upload file in bytes. 0 = Unlimited
	/// </summary>
	[Category("UploadControl")]
	[Description("Minimum size of upload file in bytes. 0 = Unlimited")]
	[DefaultValue(0)]
	public long UploadMinFileSize
	{
		get
		{
			return GetValue(UploadMinFileSizeProperty, 0L);
		}
		set
		{
			if (UploadMinFileSize != value)
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("UploadMinFileSize", string.Format(SR.GetString("UploadControlErrorMinSize"), value));
				}
				SetValue(UploadMinFileSizeProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Regular expression match string for valid filename and extension
	/// Default: "^.*$", means all files. 
	/// Example: "^.*\.(gif|jpe?g|png)$", means *.gif, *.jpg, *.jpeg, *.png
	/// </summary>
	[Category("UploadControl")]
	[Description("Regular expression match string for valid filename and extension")]
	[DefaultValue("^.*$")]
	public string UploadFileTypes
	{
		get
		{
			return GetValue(UploadFileTypesProperty, "^.*$");
		}
		set
		{
			if (UploadFileTypes != value)
			{
				SetValue(UploadFileTypesProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Path to store temporary files while being uploaded
	/// Files on this path are not deleted by this control and must be cleaned up by the user's code
	/// </summary>
	[Category("UploadControl")]
	[Description("Path to store temporary files while being uploaded")]
	[DefaultValue("")]
	public string UploadTempFilePath
	{
		get
		{
			string text = GetValue(UploadTempFilePathProperty, "");
			if (string.IsNullOrEmpty(text))
			{
				text = Path.GetTempPath();
			}
			return text;
		}
		set
		{
			if (UploadTempFilePath != value)
			{
				SetValue(UploadTempFilePathProperty, value);
			}
		}
	}

	/// <summary>
	/// Buffer size in bytes used by server-side to process uploaded chunks of uploaded files 
	/// </summary>
	[Category("UploadControl")]
	[Description("Buffer size in bytes used by server-side to process uploaded chunks of uploaded files")]
	[DefaultValue(3072000)]
	public int UploadBufferSize
	{
		get
		{
			int num = GetValue(UploadBufferSizeProperty, 3072000);
			if (num <= 0)
			{
				num = 3072000;
			}
			return num;
		}
		set
		{
			int num = value;
			if (num <= 0)
			{
				num = 3072000;
			}
			if (UploadBufferSize != num)
			{
				SetValue(UploadBufferSizeProperty, num);
			}
		}
	}

	/// <summary>
	/// Size of each chunk the jQuery client uses to upload
	/// When increasing client chunk size, make sure to check and/or adjust your web.config's values for:
	///   - system.web/httpRuntime/maxRequestLength
	///   - system.web/httpRuntime/executionTimeout
	///   - system.webServer/security/requestFiltering/requestLimit/maxAllowedContentLength
	/// </summary>
	[Category("UploadControl")]
	[Description("Size of each chunk the jQuery client uses to upload")]
	[DefaultValue(3072000)]
	public int UploadClientChunkSize
	{
		get
		{
			int num = GetValue(UploadClientChunkSizeProperty, 3072000);
			if (num <= 0)
			{
				num = 3072000;
			}
			return num;
		}
		set
		{
			int num = value;
			if (num <= 0)
			{
				num = 3072000;
			}
			if (UploadClientChunkSize != num)
			{
				SetValue(UploadClientChunkSizeProperty, num);
				Update();
			}
		}
	}

	/// <summary>
	/// Text used to prompt for files on upload control
	/// </summary>
	[Category("UploadControl")]
	[Description("Text used to prompt for files on upload control")]
	[DefaultValue("select or drop files here")]
	public string UploadText
	{
		get
		{
			return GetValue(UploadTextProperty, "select or drop files here");
		}
		set
		{
			if (UploadText != value)
			{
				SetValue(UploadTextProperty, value);
				Update();
			}
		}
	}

	/// <summary>
	/// Show name of file currently being uploaded on progressbar in uploadcontrol
	/// </summary>
	[Category("UploadControl")]
	[Description("Show name of file currently being uploaded on progressbar in uploadcontrol")]
	[DefaultValue(true)]
	public bool UploadShowFilenameOnBar
	{
		get
		{
			return GetValue(UploadShowFilenameOnBarProperty, objDefault: true);
		}
		set
		{
			if (UploadShowFilenameOnBar != value)
			{
				SetValue(UploadShowFilenameOnBarProperty, value, objDefaultValue: true);
				Update();
			}
		}
	}

	/// <summary>
	/// Show current upload speed in Kilo bits per second on progressbar in uploadcontrol
	/// </summary>
	[Category("UploadControl")]
	[Description("Show current upload speed in Kilo bits per second on progressbar in uploadcontrol")]
	[DefaultValue(true)]
	public bool UploadShowSpeedOnBar
	{
		get
		{
			return GetValue(UploadShowSpeedOnBarProperty, objDefault: true);
		}
		set
		{
			if (UploadShowSpeedOnBar != value)
			{
				SetValue(UploadShowSpeedOnBarProperty, value, objDefaultValue: true);
				Update();
			}
		}
	}

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			if (base.Enabled != value)
			{
				base.Enabled = value;
				Update();
			}
		}
	}

	/// <summary>
	/// Get the handler for UploadFileCompleted
	/// </summary>
	private UploadFileCompletedHandler UploadFileCompletedHandler => (UploadFileCompletedHandler)GetHandler(UploadFileCompletedEvent);

	/// <summary>
	/// Get the handler for UploadStart
	/// </summary>
	private UploadEventHandler UploadBatchStartingHandler => (UploadEventHandler)GetHandler(UploadBatchStartingEvent);

	/// <summary>
	/// Get the handler for UploadBatchCompleted
	/// </summary>
	private UploadEventHandler UploadBatchCompletedHandler => (UploadEventHandler)GetHandler(UploadBatchCompletedEvent);

	/// <summary>
	/// Get the handler for UploadError
	/// </summary>
	private UploadErrorHandler UploadErrorHandler => (UploadErrorHandler)GetHandler(UploadErrorEvent);

	/// <summary>
	/// Get the handler for UploadFileRequestCompleted
	/// </summary>
	private UploadChunkRequestCompletedHandler UploadChunkRequestCompletedHandler => (UploadChunkRequestCompletedHandler)GetHandler(UploadChunkRequestCompletedEvent);

	/// <summary>
	/// Fires when an upload of a single file has completed. Fired once for every uploaded file.
	/// EventArgs have information on the file and the temprary storage of the file.
	/// The file is stored on the temporary folder, possibly using name different from the original name.
	/// </summary>
	[Category("UploadControl")]
	[Description("Fires when an upload of a single file has completed. Fired once for every uploaded file.")]
	public event UploadFileCompletedHandler UploadFileCompleted
	{
		add
		{
			AddCriticalHandler(UploadFileCompletedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(UploadFileCompletedEvent, value);
		}
	}

	/// <summary>
	/// Event fired when a file has been added to the jQuery control on the client, and upload is about to start
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired when a file has been added to the jQuery control on the client, and upload is about to start")]
	public event UploadEventHandler UploadBatchStarting
	{
		add
		{
			AddCriticalHandler(UploadBatchStartingEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(UploadBatchStartingEvent, value);
		}
	}

	/// <summary>
	/// Event fired at the end of each batch of uploaded files, when the batch completes.
	/// When multiselecting files, UploadFileCompleted will fire for each individual file, followed by one UploadBatchCompleted.
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired at the end of each batch of uploaded files, when the batch completes.")]
	public event UploadEventHandler UploadBatchCompleted
	{
		add
		{
			AddCriticalHandler(UploadBatchCompletedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(UploadBatchCompletedEvent, value);
		}
	}

	/// <summary>
	/// Event fired upon detecting an unhandled Exception
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired upon detecting an unhandled Exception")]
	public event UploadErrorHandler UploadError
	{
		add
		{
			AddCriticalHandler(UploadErrorEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(UploadErrorEvent, value);
		}
	}

	/// <summary>
	/// Fired when every chunk of an uploaded file has been received by the gateway. Fired once for each chunk of every uploaded file.
	/// </summary>
	[Category("UploadControl")]
	[Description("Fires when upload completes on a group of files added in same action")]
	public event UploadChunkRequestCompletedHandler UploadChunkRequestCompleted
	{
		add
		{
			AddCriticalHandler(UploadChunkRequestCompletedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(UploadChunkRequestCompletedEvent, value);
		}
	}

	/// <summary>
	/// Fires when an upload of a single file has completed. Fired once for every uploaded file.
	/// EventArgs have a list type for uploaded files, which will contain only one uploaded file.
	/// The error property of the file's results indicates the error if not empty.
	/// </summary>
	[Category("UploadControl")]
	[Description("Fires when an upload of a single file has completed. Fired once for every uploaded file.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientUploadFileCompleted
	{
		add
		{
			AddClientHandler("UploadFileCompleted", value);
		}
		remove
		{
			RemoveClientHandler("UploadFileCompleted", value);
		}
	}

	/// <summary>
	/// Event fired when a file has been added to the jQuery control on the client, and upload is about to start
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired when a file has been added to the jQuery control on the client, and upload is about to start")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientUploadBatchStarting
	{
		add
		{
			AddClientHandler("UploadBatchStarting", value);
		}
		remove
		{
			RemoveClientHandler("UploadBatchStarting", value);
		}
	}

	/// <summary>
	/// Event fired at the end of each batch of uploaded files, when the batch completes.
	/// When multiselecting files, UploadFileCompleted will fire for each individual file, followed by one UploadBatchCompleted.
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired at the end of each batch of uploaded files, when the batch completes.")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientUploadBatchCompleted
	{
		add
		{
			AddClientHandler("UploadBatchCompleted", value);
		}
		remove
		{
			RemoveClientHandler("UploadBatchCompleted", value);
		}
	}

	/// <summary>
	/// Event fired upon detecting an unhandled Exception
	/// </summary>
	[Category("UploadControl")]
	[Description("Event fired upon detecting an unhandled Exception")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientUploadError
	{
		add
		{
			AddClientHandler("UploadError", value);
		}
		remove
		{
			RemoveClientHandler("UploadError", value);
		}
	}

	/// <summary>
	/// Fired when every chunk of an uploaded file has been received by the gateway. Fired once for each chunk of every uploaded file.
	/// </summary>
	[Category("UploadControl")]
	[Description("Fires when upload completes on a group of files added in same action")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DefaultValue(null)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public event ClientEventHandler ClientUploadChunkRequestCompleted
	{
		add
		{
			AddClientHandler("UploadChunkRequestCompleted", value);
		}
		remove
		{
			RemoveClientHandler("UploadChunkRequestCompleted", value);
		}
	}

	/// <summary>
	/// Constructor for UploadControl
	/// </summary>
	public UploadControl()
	{
	}

	/// <summary>
	/// Detecting if upload chunk gateway request is the first chunk of a file being uploaded
	/// </summary>
	/// <param name="strRange">Pattern used by jQuery upload control: "bytes 0-116649/116650"</param>
	/// <returns></returns>
	private bool isFirstRange(string strRange)
	{
		return strRange.StartsWith("bytes 0-");
	}

	/// <summary>
	/// Detecting if upload chunk gateway request is the last chunk of a file being uploaded
	/// </summary>
	/// <param name="strRange">Pattern range used by upload control: "bytes 100000-116649/116650"</param>
	/// <returns></returns>
	private bool isLastRange(string strRange)
	{
		long num = long.Parse(strRange.Substring(strRange.IndexOf("-") + 1, strRange.IndexOf("/") - strRange.IndexOf("-") - 1));
		long num2 = long.Parse(strRange.Substring(strRange.IndexOf("/") + 1));
		return num + 1 >= num2;
	}

	/// <summary>
	/// Process Ajax gateway upload request posted by the jQuery upload client component
	/// </summary>
	/// <param name="objHostContext"></param>
	/// <param name="strAction">The only supported action is "ULPost", posted by the jQuery upload control as Ajax gateway request</param>
	/// <returns></returns>
	protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
	{
		if (strAction == "ULP")
		{
			objHostContext.Response.ContentType = "text/plain";
			try
			{
				string text = objHostContext.Request.Headers["Content-Range"];
				if (text != null && objHostContext.Request.Files.Count > 1)
				{
					throw new NotSupportedException("Chunked file uploads only supported for one file at a time");
				}
				List<UploadFileResult> list = new List<UploadFileResult>();
				HttpPostedFile httpPostedFile = objHostContext.HttpContext.Request.Files[0];
				string empty = string.Empty;
				string[] array = httpPostedFile.FileName.Split('\\');
				empty = array[array.Length - 1];
				if (text != null)
				{
					if (isFirstRange(text))
					{
						mstrChunkedFileName = Path.Combine(UploadTempFilePath, Guid.NewGuid().ToString() + "_" + empty);
					}
					if (mstrChunkedFileName == null)
					{
						throw new NotSupportedException("Chunked file upload missing initial chunk");
					}
				}
				string text2;
				if (text == null)
				{
					text2 = Path.Combine(UploadTempFilePath, Guid.NewGuid().ToString() + "_" + empty);
					httpPostedFile.SaveAs(text2);
				}
				else
				{
					text2 = mstrChunkedFileName;
					using FileStream fileStream = new FileStream(text2, FileMode.Append, FileAccess.Write);
					byte[] buffer = new byte[UploadBufferSize];
					for (long num = httpPostedFile.InputStream.Read(buffer, 0, UploadBufferSize); num > 0; num = httpPostedFile.InputStream.Read(buffer, 0, UploadBufferSize))
					{
						fileStream.Write(buffer, 0, (int)num);
					}
					fileStream.Flush();
					fileStream.Close();
				}
				UploadFileResult item = new UploadFileResult(empty, httpPostedFile.ContentLength, httpPostedFile.ContentType, text2);
				list.Add(item);
				if (UploadChunkRequestCompletedHandler != null)
				{
					UploadChunkRequestResult objResult = new UploadChunkRequestResult(empty, httpPostedFile.ContentLength, httpPostedFile.ContentType, text2, text);
					UploadChunkRequestCompletedHandler(this, new UploadChunkRequestEventArgs(objResult));
				}
				string serialized = JsonSerializer.Serialize(list.ToArray());
				objHostContext.Response.Write(serialized);
				return null;
			}
			catch (Exception ex)
			{
				if (UploadErrorHandler != null)
				{
					UploadErrorHandler(this, new UploadErrorEventArgs(ex.Message, ex));
					return null;
				}
				throw;
			}
		}
		return base.ProcessGatewayRequest(objHostContext, strAction);
	}

	/// <summary>
	/// Simle error checking 
	/// </summary>
	/// <param name="strFileName"></param>
	/// <param name="objFile"></param>
	/// <returns></returns>
	private string UploadValidate(string strFileName, HttpPostedFile objFile)
	{
		if (objFile.ContentLength == 0)
		{
			return SR.GetString("UploadcontrolErrorContentMissing");
		}
		if (UploadMinFileSize > 0 && objFile.ContentLength < UploadMinFileSize)
		{
			return string.Format(SR.GetString("UploadControlErrorMinSize"), strFileName);
		}
		if (UploadMaxFileSize > 0 && objFile.ContentLength > UploadMaxFileSize)
		{
			return string.Format(SR.GetString("UploadControlErrorMaxSize"), strFileName);
		}
		if (!string.IsNullOrEmpty(UploadFileTypes))
		{
			Regex regex = new Regex(UploadFileTypes);
			if (!regex.IsMatch(Path.GetExtension(strFileName)))
			{
				return string.Format(SR.GetString("UploadControlFileNotAllowed"), strFileName);
			}
		}
		return string.Empty;
	}

	/// <summary>
	/// Render attributes for UploadControl
	/// </summary>
	/// <param name="context"></param>
	/// <param name="writer"></param>
	protected override void RenderAttributes(IContext context, IAttributeWriter writer)
	{
		writer.WriteAttributeString("ULFiles", UploadMaxNumberOfFiles.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("ULMax", UploadMaxFileSize.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("ULMin", UploadMinFileSize.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("ULTypes", UploadFileTypes);
		writer.WriteAttributeString("ULP", new GatewayReference(this, "ULP").ToString());
		writer.WriteAttributeString("ULT", UploadText);
		writer.WriteAttributeString("ULC", UploadClientChunkSize.ToString(CultureInfo.InvariantCulture));
		writer.WriteAttributeString("ULBF", UploadShowFilenameOnBar ? "1" : "0");
		writer.WriteAttributeString("ULBS", UploadShowSpeedOnBar ? "1" : "0");
		writer.WriteAttributeString("ULEN", Enabled ? "1" : "0");
		base.RenderAttributes(context, writer);
	}

	/// <summary>
	/// Handle and process events raised by the jQuery upload control
	/// </summary>
	/// <param name="objEvent"></param>
	protected override void FireEvent(IEvent objEvent)
	{
		if (objEvent.Type == "Fail")
		{
			string text = objEvent["error"].ToString();
			string text2 = string.Format(SR.GetString("UploadControlError" + text), objEvent["result"].ToString());
			if (UploadErrorHandler == null)
			{
				throw new HttpException(text2);
			}
			UploadErrorHandler(this, new UploadErrorEventArgs(text2, null));
		}
		else if (objEvent.Type == "Done")
		{
			long result = 0L;
			if (!long.TryParse(objEvent["Size"], out result))
			{
				result = 0L;
			}
			UploadFileResult objResult = new UploadFileResult(objEvent["Name"].ToString(), result, objEvent["Type"].ToString(), objEvent["TempName"]);
			if (UploadFileCompletedHandler != null)
			{
				UploadFileCompletedHandler(this, new UploadCompletedEventArgs(objResult));
			}
		}
		else if (objEvent.Type == "Start")
		{
			if (UploadBatchStartingHandler != null)
			{
				UploadBatchStartingHandler(this, EventArgs.Empty);
			}
		}
		else if (objEvent.Type == "Stop")
		{
			if (UploadBatchCompletedHandler != null)
			{
				UploadBatchCompletedHandler(this, EventArgs.Empty);
			}
		}
		else
		{
			base.FireEvent(objEvent);
		}
	}

	/// <summary>
	/// Gets the critical events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (UploadErrorHandler != null)
		{
			criticalEventsData.Set("ULEH");
		}
		if (UploadFileCompletedHandler != null)
		{
			criticalEventsData.Set("ULFCH");
		}
		if (UploadBatchStartingHandler != null)
		{
			criticalEventsData.Set("ULBSH");
		}
		if (UploadBatchCompletedHandler != null)
		{
			criticalEventsData.Set("ULBCH");
		}
		return criticalEventsData;
	}

	/// <summary>
	/// Gets the critical client events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalClientEventsData()
	{
		CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
		if (HasClientHandler("UploadErrorHandler"))
		{
			criticalClientEventsData.Set("ULEH");
		}
		if (HasClientHandler("UploadFileCompletedHandler"))
		{
			criticalClientEventsData.Set("ULFCH");
		}
		if (HasClientHandler("UploadBatchStartingHandler"))
		{
			criticalClientEventsData.Set("ULBSH");
		}
		if (HasClientHandler("UploadBatchCompletedHandler"))
		{
			criticalClientEventsData.Set("ULBCH");
		}
		return criticalClientEventsData;
	}

	static UploadControl()
	{
		UploadBatchStartingEvent = SerializableEvent.Register("UploadBatchStarting", typeof(UploadEventHandler), typeof(UploadControl));
		UploadChunkRequestCompletedEvent = SerializableEvent.Register("UploadChunkRequestCompletedEvent", typeof(UploadChunkRequestCompletedHandler), typeof(UploadControl));
		UploadFileCompletedEvent = SerializableEvent.Register("UploadFileCompletedEvent", typeof(UploadFileCompletedHandler), typeof(UploadControl));
		UploadBatchCompletedEvent = SerializableEvent.Register("UploadBatchCompleted", typeof(UploadEventHandler), typeof(UploadControl));
		UploadErrorEvent = SerializableEvent.Register("UploadError", typeof(UploadErrorHandler), typeof(UploadControl));
	}
}
