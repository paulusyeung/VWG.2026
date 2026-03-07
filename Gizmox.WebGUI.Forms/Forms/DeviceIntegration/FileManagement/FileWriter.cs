// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileWriter
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
  public class FileWriter : DevicePropertyDictionary, IFileWriter, IFileSaver
  {
    private IFileEntry mobjFileEntry;
    private FileManager mobjFileManager;
    private int mintLastErrorCode;
    private EventHandler<EmptyDeviceEventArgs> mobjWriteEndCallback;
    private KeyValuePair<string, object[]> mobjWriteEndClientCallbackData;
    private EventHandler<EmptyDeviceEventArgs> mobjWriteCallback;
    private KeyValuePair<string, object[]> mobjWriteClientCallbackData;
    private EventHandler<EmptyDeviceEventArgs> mobjWriteStartCallback;
    private KeyValuePair<string, object[]> mobjWriteStartClientCallbackData;
    private EventHandler<EmptyDeviceEventArgs> mobjErrorCallback;
    private KeyValuePair<string, object[]> mobjErrorClientCallbackData;
    private EventHandler<EmptyDeviceEventArgs> mobjAbortCallback;
    private KeyValuePair<string, object[]> mobjAbortClientCallbackData;
    private bool mblnIsFinished;

    /// <summary>Froms the VWG event.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <param name="objFileEntryContext">The obj file entry context.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    /// <returns></returns>
    internal static IFileWriter FromVWGEvent(
      IEvent objEvent,
      Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileEntry objFileEntryContext,
      FileManager objFileManager)
    {
      FileWriter objFileWriter = new FileWriter((IFileEntry) objFileEntryContext, objFileManager);
      FileWriter.FillAttributes(objFileWriter, objEvent);
      return (IFileWriter) objFileWriter;
    }

    private static void FillAttributes(FileWriter objFileWriter, IEvent objEvent)
    {
      ulong result1;
      if (!string.IsNullOrEmpty(objEvent["length"]) && ulong.TryParse(objEvent["length"], out result1))
        objFileWriter.Length = result1;
      ulong result2;
      if (!string.IsNullOrEmpty(objEvent["position"]) && ulong.TryParse(objEvent["position"], out result2))
        objFileWriter.Position = result2;
      int result3;
      if (!string.IsNullOrEmpty(objEvent["error"]) && int.TryParse(objEvent["error"], out result3))
        objFileWriter.LastErrorCode = result3;
      else
        objFileWriter.LastErrorCode = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileWriter" /> class.
    /// </summary>
    /// <param name="objFileEntry">The obj file entry.</param>
    /// <param name="objFileManager">The obj file manager.</param>
    public FileWriter(IFileEntry objFileEntry, FileManager objFileManager)
    {
      this.ReadyState = ReadyStateType.Init;
      this.mblnIsFinished = false;
      this.mobjFileEntry = objFileEntry;
      this.mobjFileManager = objFileManager;
    }

    /// <summary>Gets or sets the length.</summary>
    /// <value>The length.</value>
    public ulong Length
    {
      get => this.GetValuetypePropertyOrDefault<ulong>("length");
      internal set => this.AddValueTypeProperty<ulong>("length", value);
    }

    /// <summary>Gets or sets the position.</summary>
    /// <value>The position.</value>
    public ulong Position
    {
      get => this.GetValuetypePropertyOrDefault<ulong>("position");
      internal set => this.AddValueTypeProperty<ulong>("position", value);
    }

    /// <summary>Seeks the specified LNG position.</summary>
    /// <param name="lngOffset">The LNG position.</param>
    public void Seek(long lngOffset)
    {
      if (lngOffset < 0L)
        this.Position = (ulong) Math.Max(lngOffset + (long) this.Length, 0L);
      else if (lngOffset - (long) this.Length > 0L)
        this.Position = this.Length;
      else
        this.Position = (ulong) lngOffset;
    }

    /// <summary>Truncates the specified LNG length.</summary>
    /// <param name="lngLength">Length of the LNG.</param>
    public void Truncate(ulong lngLength) => this.mobjFileManager.Truncate(this, lngLength);

    /// <summary>Writes the specified STR data.</summary>
    /// <param name="strData">The STR data.</param>
    public void Write(string strData) => this.mobjFileManager.WriteToFile(this, strData);

    /// <summary>Gets the error.</summary>
    public int LastErrorCode
    {
      get => this.mintLastErrorCode;
      internal set => this.mintLastErrorCode = value;
    }

    /// <summary>Gets the state of the ready.</summary>
    /// <value>The state of the ready.</value>
    public ReadyStateType ReadyState
    {
      get
      {
        int? valueTypeProperty = this.GetNullableValueTypeProperty<int>("readyState");
        return valueTypeProperty.HasValue && Enum.IsDefined(typeof (ReaderReadyStateType), (object) valueTypeProperty) ? (ReadyStateType) valueTypeProperty.Value : ReadyStateType.Init;
      }
      internal set => this.AddValueTypeProperty<int>("readyState", (int) value);
    }

    /// <summary>Sets the abort event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetAbortEvent(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjAbortCallback = objCallback;

    /// <summary>Sets the error event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjErrorCallback = objCallback;

    /// <summary>Sets the write end event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetWriteEndEvent(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjWriteEndCallback = objCallback;

    /// <summary>Sets the write event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetWriteEvent(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjWriteCallback = objCallback;

    /// <summary>Sets the write start event.</summary>
    /// <param name="objCallback">The obj callback.</param>
    public void SetWriteStartEvent(EventHandler<EmptyDeviceEventArgs> objCallback) => this.mobjWriteStartCallback = objCallback;

    /// <summary>Gets the file entry.</summary>
    internal IFileEntry FileEntry => this.mobjFileEntry;

    /// <summary>Gets the write start value.</summary>
    /// <returns></returns>
    internal object GetWriteStartValue() => this.GetServerSideEventTypeString((object) this.mobjWriteStartCallback, this.mobjWriteStartClientCallbackData);

    private object GetServerSideEventTypeString(
      object objCallback,
      KeyValuePair<string, object[]> objClientCallbackData)
    {
      IDictionary<string, object> dictionary = (IDictionary<string, object>) new Dictionary<string, object>();
      if (objCallback != null)
        dictionary.Add("server", (object) true);
      if (objClientCallbackData.Key != null)
      {
        dictionary.Add("client", (object) objClientCallbackData.Key);
        if (objClientCallbackData.Value != null)
          dictionary.Add("clientp", (object) objClientCallbackData.Value);
      }
      return dictionary.Count > 0 ? (object) dictionary : (object) null;
    }

    /// <summary>Gets the write value.</summary>
    /// <returns></returns>
    internal object GetWriteValue() => this.GetServerSideEventTypeString((object) this.mobjWriteCallback, this.mobjWriteClientCallbackData);

    /// <summary>Gets the error value.</summary>
    /// <returns></returns>
    internal object GetErrorValue() => this.GetServerSideEventTypeString((object) this.mobjErrorCallback, this.mobjErrorClientCallbackData);

    /// <summary>Gets the write end value.</summary>
    /// <returns></returns>
    internal object GetWriteEndValue() => this.GetServerSideEventTypeString((object) this.mobjWriteEndCallback, this.mobjWriteEndClientCallbackData);

    /// <summary>Gets the abort value.</summary>
    /// <returns></returns>
    internal object GetAbortValue() => this.GetServerSideEventTypeString((object) this.mobjAbortCallback, this.mobjAbortClientCallbackData);

    /// <summary>Determines whether [has server side events].</summary>
    /// <returns>
    ///   <c>true</c> if [has server side events]; otherwise, <c>false</c>.
    /// </returns>
    internal bool HasServerSideEvents() => this.mobjWriteCallback != null || this.mobjWriteEndCallback != null || this.mobjWriteStartCallback != null || this.mobjErrorCallback != null || this.mobjAbortCallback != null;

    /// <summary>Handles the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    internal void HandleEvent(IEvent objEvent)
    {
      switch (objEvent.Member.ToLower())
      {
        case "update":
          FileWriter.FillAttributes(this, objEvent);
          break;
        case "writestart":
          if (this.mobjWriteStartCallback != null)
            this.mobjWriteStartCallback((object) this, new EmptyDeviceEventArgs());
          this.ReadyState = ReadyStateType.Writing;
          break;
        case "write":
          if (this.mobjWriteCallback != null)
            this.mobjWriteCallback((object) this, new EmptyDeviceEventArgs());
          this.ReadyState = ReadyStateType.Done;
          if (this.mobjWriteEndCallback != null)
          {
            this.mobjWriteEndCallback((object) this, new EmptyDeviceEventArgs());
            break;
          }
          break;
        case "error":
          this.ReadyState = ReadyStateType.Done;
          if (this.mobjErrorCallback != null)
            this.mobjErrorCallback((object) this, new EmptyDeviceEventArgs());
          if (this.mobjWriteEndCallback != null)
          {
            this.mobjWriteEndCallback((object) this, new EmptyDeviceEventArgs());
            break;
          }
          break;
        case "abort":
          this.ReadyState = ReadyStateType.Done;
          if (this.mobjAbortCallback != null)
            this.mobjAbortCallback((object) this, new EmptyDeviceEventArgs());
          if (this.mobjWriteEndCallback != null)
          {
            this.mobjWriteEndCallback((object) this, new EmptyDeviceEventArgs());
            break;
          }
          break;
        case "writeend":
          this.ReadyState = ReadyStateType.Done;
          if (this.mobjWriteEndCallback != null)
          {
            this.mobjWriteEndCallback((object) this, new EmptyDeviceEventArgs());
            break;
          }
          break;
        default:
          throw new Exception();
      }
      if (this.ReadyState != ReadyStateType.Done)
        return;
      this.mblnIsFinished = true;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement.FileWriter" /> is finished.
    /// </summary>
    /// <value>
    ///   <c>true</c> if finished; otherwise, <c>false</c>.
    /// </value>
    internal bool Finished
    {
      get
      {
        int num = this.mblnIsFinished ? 1 : 0;
        this.mblnIsFinished = false;
        return num != 0;
      }
    }

    internal IDictionary<string, object> GetCallbacksData
    {
      get
      {
        IDictionary<string, object> dictionary = (IDictionary<string, object>) new Dictionary<string, object>();
        if (this.GetWriteStartValue() != null)
          dictionary.Add("writeStart", this.GetWriteStartValue());
        object writeValue = this.GetWriteValue();
        if (writeValue != null)
          dictionary.Add("write", writeValue);
        object writeEndValue = this.GetWriteEndValue();
        if (writeEndValue != null)
          dictionary.Add("writeEnd", writeEndValue);
        object errorValue = this.GetErrorValue();
        if (errorValue != null)
          dictionary.Add("error", errorValue);
        object abortValue = this.GetAbortValue();
        if (abortValue != null)
          dictionary.Add("abort", abortValue);
        return dictionary.Count > 0 ? dictionary : (IDictionary<string, object>) null;
      }
    }
  }
}
