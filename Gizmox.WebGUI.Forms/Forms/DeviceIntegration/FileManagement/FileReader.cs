// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileReader
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class FileReader : IFileReader
  {
    private IFileEntry mobjFileEntry;
    private FileManager mobjFileManager;
    private bool mblnFinished;
    private ReaderReadyStateType menmReaderReadyStateType;
    private EventHandler<FileReaderEventArgs> mobjAbortCallback;
    private KeyValuePair<string, object[]> mobjAbortClientCallbackData;
    private EventHandler<FileReaderEventArgs> mobjErrorCallback;
    private KeyValuePair<string, object[]> mobjErrorClientCallbackData;
    private EventHandler<FileReaderEventArgs> mobjLoadEndCallback;
    private KeyValuePair<string, object[]> mobjLoadEndClientCallbackData;
    private EventHandler<FileReaderEventArgs> mobjLoadCallback;
    private KeyValuePair<string, object[]> mobjLoadClientCallbackData;
    private EventHandler<FileReaderEventArgs> mobjLoadStartCallback;
    private KeyValuePair<string, object[]> mobjLoadStartClientCallbackData;
    private int mintLastErrorCode;
    private string mstrResult;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileReader" /> class.
    /// </summary>
    /// <param name="objFileEntry">The obj file entry.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    public FileReader(IFileEntry objFileEntry, FileManager objFileManager)
    {
      this.ReadyState = ReaderReadyStateType.Empty;
      this.mobjFileEntry = objFileEntry;
      this.mobjFileManager = objFileManager;
    }

    /// <summary>Gets the file entry.</summary>
    internal IFileEntry FileEntry => this.mobjFileEntry;

    /// <summary>Gets the last error code.</summary>
    public int LastErrorCode
    {
      get => this.mintLastErrorCode;
      internal set => this.mintLastErrorCode = value;
    }

    /// <summary>Reads as data URL.</summary>
    public void ReadAsDataUrl() => this.mobjFileManager.ReadAsDataUrl(this);

    /// <summary>Reads as text.</summary>
    public void ReadAsText() => this.ReadAsText((string) null);

    /// <summary>Reads as text.</summary>
    /// <param name="strEncoding">The STR encoding.</param>
    /// <param name="objContext">The obj context.</param>
    public void ReadAsText(string strEncoding) => this.mobjFileManager.ReadAsText(this, strEncoding);

    /// <summary>Gets the result.</summary>
    public string Result
    {
      get => this.mstrResult;
      internal set => this.mstrResult = value;
    }

    /// <summary>Sets the abort event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetAbortEvent(EventHandler<FileReaderEventArgs> objCallback) => this.mobjAbortCallback = objCallback;

    /// <summary>Sets the error event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetErrorEvent(EventHandler<FileReaderEventArgs> objCallback) => this.mobjErrorCallback = objCallback;

    /// <summary>Sets the load end event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetLoadEndEvent(EventHandler<FileReaderEventArgs> objCallback) => this.mobjLoadEndCallback = objCallback;

    /// <summary>Sets the load event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetLoadEvent(EventHandler<FileReaderEventArgs> objCallback) => this.mobjLoadCallback = objCallback;

    /// <summary>Sets the load start event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetLoadStartEvent(EventHandler<FileReaderEventArgs> objCallback) => this.mobjLoadStartCallback = objCallback;

    /// <summary>Gets the error value.</summary>
    /// <returns></returns>
    internal object GetErrorValue() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjErrorCallback, this.mobjErrorClientCallbackData);

    /// <summary>Gets the abort value.</summary>
    /// <returns></returns>
    internal object GetAbortValue() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjAbortCallback, this.mobjAbortClientCallbackData);

    /// <summary>Gets the load start value.</summary>
    /// <returns></returns>
    internal object GetLoadStartValue() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjLoadStartCallback, this.mobjLoadStartClientCallbackData);

    /// <summary>Gets the load start value.</summary>
    /// <returns></returns>
    internal object GetLoadEndValue() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjLoadEndCallback, this.mobjLoadEndClientCallbackData);

    /// <summary>Gets the load value.</summary>
    /// <returns></returns>
    internal object GetLoadValue() => DeviceUtils.GetServerSideEventTypeString((object) this.mobjLoadCallback, this.mobjLoadClientCallbackData);

    /// <summary>Determines whether [has server side events].</summary>
    /// <returns>
    ///   <c>true</c> if [has server side events]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasServerSideEvents() => this.mobjLoadCallback != null || this.mobjLoadEndCallback != null || this.mobjLoadStartCallback != null || this.mobjErrorCallback != null || this.mobjAbortCallback != null;

    /// <summary>Handles the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void HandleEvent(IEvent objEvent)
    {
      switch (objEvent.Member.ToLower())
      {
        case "value":
          this.Result = objEvent.Value;
          int result;
          this.LastErrorCode = string.IsNullOrEmpty(objEvent["error"]) || !int.TryParse(objEvent["error"], out result) ? 0 : result;
          break;
        case "loadstart":
          if (this.mobjLoadStartCallback != null)
            this.mobjLoadStartCallback((object) this, new FileReaderEventArgs((IFileReader) this));
          this.ReadyState = ReaderReadyStateType.Loading;
          break;
        case "load":
          if (this.mobjLoadCallback != null)
            this.mobjLoadCallback((object) this, new FileReaderEventArgs((IFileReader) this));
          this.ReadyState = ReaderReadyStateType.Done;
          if (this.mobjLoadEndCallback != null)
          {
            this.mobjLoadEndCallback((object) this, new FileReaderEventArgs((IFileReader) this));
            break;
          }
          break;
        case "loadend":
          this.ReadyState = ReaderReadyStateType.Done;
          if (this.mobjLoadEndCallback != null)
          {
            this.mobjLoadEndCallback((object) this, new FileReaderEventArgs((IFileReader) this));
            break;
          }
          break;
        case "error":
          this.ReadyState = ReaderReadyStateType.Done;
          if (this.mobjErrorCallback != null)
            this.mobjErrorCallback((object) this, new FileReaderEventArgs((IFileReader) this));
          if (this.mobjLoadEndCallback != null)
          {
            this.mobjLoadEndCallback((object) this, new FileReaderEventArgs((IFileReader) this));
            break;
          }
          break;
        case "abort":
          this.ReadyState = ReaderReadyStateType.Done;
          if (this.mobjAbortCallback != null)
            this.mobjAbortCallback((object) this, new FileReaderEventArgs((IFileReader) this));
          if (this.mobjLoadEndCallback != null)
          {
            this.mobjLoadEndCallback((object) this, new FileReaderEventArgs((IFileReader) this));
            break;
          }
          break;
        default:
          throw new Exception();
      }
      if (this.ReadyState != ReaderReadyStateType.Done)
        return;
      this.mblnFinished = true;
    }

    /// <summary>Gets the callbacks.</summary>
    internal IDictionary<string, object> GetCallbacksData
    {
      get
      {
        IDictionary<string, object> dictionary = (IDictionary<string, object>) new Dictionary<string, object>();
        object loadStartValue = this.GetLoadStartValue();
        if (loadStartValue != null)
          dictionary.Add("loadStart", loadStartValue);
        object loadValue = this.GetLoadValue();
        if (loadValue != null)
          dictionary.Add("load", loadValue);
        object loadEndValue = this.GetLoadEndValue();
        if (loadEndValue != null)
          dictionary.Add("loadEnd", loadEndValue);
        object errorValue = this.GetErrorValue();
        if (errorValue != null)
          dictionary.Add("error", errorValue);
        object abortValue = this.GetAbortValue();
        if (abortValue != null)
          dictionary.Add("abort", abortValue);
        return dictionary.Count > 0 ? dictionary : (IDictionary<string, object>) null;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileReader" /> is finished.
    /// </summary>
    /// <value>
    ///   <c>true</c> if finished; otherwise, <c>false</c>.
    /// </value>
    public bool Finished
    {
      get
      {
        int num = this.mblnFinished ? 1 : 0;
        this.mblnFinished = false;
        return num != 0;
      }
    }

    /// <summary>Gets the state of the ready.</summary>
    /// <value>The state of the ready.</value>
    public ReaderReadyStateType ReadyState
    {
      get => this.menmReaderReadyStateType;
      internal set => this.menmReaderReadyStateType = value;
    }
  }
}
