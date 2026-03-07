using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class FileWriter : DevicePropertyDictionary, IFileWriter
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

        /// <summary>
        /// Froms the VWG event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="objFileEntryContext">The obj file entry context.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        /// <returns></returns>
        internal static IFileWriter FromVWGEvent(IEvent objEvent, FileEntry objFileEntryContext, FileManager objFileManager)
        {
            FileWriter objFileWriter = new FileWriter(objFileEntryContext, objFileManager);

            FillAttributes(objFileWriter, objEvent);

            return objFileWriter;
        }

        private static void FillAttributes(FileWriter objFileWriter, IEvent objEvent)
        {
            ulong lngLength;
            ulong lngPosition;
            int intLastErrorCode;

            if (!string.IsNullOrEmpty(objEvent["length"]) && ulong.TryParse(objEvent["length"], out lngLength))
            {
                objFileWriter.Length = lngLength;
            }
            if (!string.IsNullOrEmpty(objEvent["position"]) && ulong.TryParse(objEvent["position"], out lngPosition))
            {
                objFileWriter.Position = lngPosition;
            }
            if (!string.IsNullOrEmpty(objEvent["error"]) && int.TryParse(objEvent["error"], out intLastErrorCode))
            {
                objFileWriter.LastErrorCode = intLastErrorCode;
            }
            else
            {
                objFileWriter.LastErrorCode = 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="objFileEntry">The obj file entry.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        public FileWriter(IFileEntry objFileEntry, FileManager objFileManager)
        {
            this.ReadyState = ReadyStateType.Init;
            mblnIsFinished = false;
            mobjFileEntry = objFileEntry;
            mobjFileManager = objFileManager;
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public ulong Length
        {
            get
            {
                return GetValuetypePropertyOrDefault<ulong>("length");
            }
            internal set
            {
                AddValueTypeProperty("length", value);
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public ulong Position
        {
            get
            {
                return GetValuetypePropertyOrDefault<ulong>("position");
            }
            internal set
            {
                AddValueTypeProperty("position", value);
            }
        }

        /// <summary>
        /// Seeks the specified LNG position.
        /// </summary>
        /// <param name="lngOffset">The LNG position.</param>
        public void Seek(long lngOffset)
        {
            // See back from end of file.
            if (lngOffset < 0)
            {
                this.Position = (ulong)Math.Max((lngOffset + (long)this.Length), 0);
            }
            // Offset is bigger than file size so set position
            // to the end of the file.
            else if (lngOffset - (long)this.Length > 0)
            {
                this.Position = this.Length;
            }
            // Offset is between 0 and file size so set the position
            // to start writing.
            else
            {
                this.Position = (ulong)lngOffset;
            }
        }

        /// <summary>
        /// Truncates the specified LNG length.
        /// </summary>
        /// <param name="lngLength">Length of the LNG.</param>
        public void Truncate(ulong lngLength)
        {
            mobjFileManager.Truncate(this, lngLength);
        }

        /// <summary>
        /// Writes the specified STR data.
        /// </summary>
        /// <param name="strData">The STR data.</param>
        public void Write(string strData)
        {
            mobjFileManager.WriteToFile(this, strData);
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public int LastErrorCode
        {
            get
            {
                return mintLastErrorCode;
            }
            internal set
            {
                mintLastErrorCode = value;
            }
        }

        /// <summary>
        /// Gets the state of the ready.
        /// </summary>
        /// <value>
        /// The state of the ready.
        /// </value>
        public ReadyStateType ReadyState
        {
            get
            {
                int? intValue = GetNullableValueTypeProperty<int>("readyState");

                if (intValue != null && Enum.IsDefined(typeof(ReaderReadyStateType), intValue))
                {
                    return (ReadyStateType)intValue;
                }

                return ReadyStateType.Init;
            }
            internal set
            {
                AddValueTypeProperty("readyState", (int)value);
            }
        }

        /// <summary>
        /// Sets the abort event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetAbortEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjAbortCallback = objCallback;
        }

        /// <summary>
        /// Sets the error event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjErrorCallback = objCallback;
        }

        /// <summary>
        /// Sets the write end event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetWriteEndEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjWriteEndCallback = objCallback;
        }

        /// <summary>
        /// Sets the write event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetWriteEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjWriteCallback = objCallback;
        }

        /// <summary>
        /// Sets the write start event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetWriteStartEvent(EventHandler<EmptyDeviceEventArgs> objCallback)
        {
            mobjWriteStartCallback = objCallback;
        }

        /// <summary>
        /// Gets the file entry.
        /// </summary>
        internal IFileEntry FileEntry
        {
            get { return mobjFileEntry; }
        }

        /// <summary>
        /// Gets the write start value.
        /// </summary>
        /// <returns></returns>
        internal object GetWriteStartValue()
        {
            return GetServerSideEventTypeString(mobjWriteStartCallback, mobjWriteStartClientCallbackData);
        }

        private object GetServerSideEventTypeString(object objCallback, KeyValuePair<string, object[]> objClientCallbackData)
        {
            IDictionary<string, object> objEventData = new Dictionary<string, object>();
            if (objCallback != null)
            {
                objEventData.Add("server", true);
            }

            if (objClientCallbackData.Key != null)
            {
                objEventData.Add("client", objClientCallbackData.Key);
                if (objClientCallbackData.Value != null)
                {
                    objEventData.Add("clientp", objClientCallbackData.Value);
                }
            }

            if (objEventData.Count > 0)
            {
                return objEventData;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the write value.
        /// </summary>
        /// <returns></returns>
        internal object GetWriteValue()
        {
            return GetServerSideEventTypeString(mobjWriteCallback, mobjWriteClientCallbackData);
        }

        /// <summary>
        /// Gets the error value.
        /// </summary>
        /// <returns></returns>
        internal object GetErrorValue()
        {
            return GetServerSideEventTypeString(mobjErrorCallback, mobjErrorClientCallbackData);
        }

        /// <summary>
        /// Gets the write end value.
        /// </summary>
        /// <returns></returns>
        internal object GetWriteEndValue()
        {
            return GetServerSideEventTypeString(mobjWriteEndCallback, mobjWriteEndClientCallbackData);
        }

        /// <summary>
        /// Gets the abort value.
        /// </summary>
        /// <returns></returns>
        internal object GetAbortValue()
        {
            return GetServerSideEventTypeString(mobjAbortCallback, mobjAbortClientCallbackData);
        }

        /// <summary>
        /// Determines whether [has server side events].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has server side events]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasServerSideEvents()
        {
            return mobjWriteCallback != null || mobjWriteEndCallback != null || mobjWriteStartCallback != null || mobjErrorCallback != null || mobjAbortCallback != null;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void HandleEvent(IEvent objEvent)
        {
            switch (objEvent.Member.ToLower())
            {
                case "update":
                    FillAttributes(this, objEvent);
                    break;

                case "writestart":
                    if (mobjWriteStartCallback != null)
                    {
                        mobjWriteStartCallback(this, new EmptyDeviceEventArgs());
                    }
                    this.ReadyState = ReadyStateType.Writing;
                    break;

                case "write":
                    if (mobjWriteCallback != null)
                    {
                        mobjWriteCallback(this, new EmptyDeviceEventArgs());
                    }

                    this.ReadyState = ReadyStateType.Done;

                    if (mobjWriteEndCallback != null)
                    {
                        mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
                    }                    
                    break;

                case "error":
                    this.ReadyState = ReadyStateType.Done;
                    if (mobjErrorCallback != null)
                    {
                        mobjErrorCallback(this, new EmptyDeviceEventArgs());
                    }
                    if (mobjWriteEndCallback != null)
                    {
                        mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
                    }                   
                    break;

                case "abort":
                    this.ReadyState = ReadyStateType.Done;
                    if (mobjAbortCallback != null)
                    {
                        mobjAbortCallback(this, new EmptyDeviceEventArgs());
                    }
                    if (mobjWriteEndCallback != null)
                    {
                        mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
                    }
                    break;

                case "writeend":
                    this.ReadyState = ReadyStateType.Done;
                    if (mobjWriteEndCallback != null)
                    {
                        mobjWriteEndCallback(this, new EmptyDeviceEventArgs());
                    }                    
                    break;

                default:
                    throw new Exception();
            }

            if (this.ReadyState == ReadyStateType.Done)
            {
                mblnIsFinished = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FileWriter"/> is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if finished; otherwise, <c>false</c>.
        /// </value>
        internal bool Finished
        {
            get
            {
                bool objValue = mblnIsFinished;
                mblnIsFinished = false;

                return objValue;
            }
        }

        internal IDictionary<string, object> GetCallbacksData
        {
            get
            {
                IDictionary<string, object> objargs = new Dictionary<string, object>();
                object objValue;
                objValue = this.GetWriteStartValue();
                if (objValue != null)
                {
                    objargs.Add("writeStart", this.GetWriteStartValue());
                }
                objValue = this.GetWriteValue();
                if (objValue != null)
                {
                    objargs.Add("write", objValue);
                }
                objValue = this.GetWriteEndValue();
                if (objValue != null)
                {
                    objargs.Add("writeEnd", objValue);
                }
                objValue = this.GetErrorValue();
                if (objValue != null)
                {
                    objargs.Add("error", objValue);
                }
                objValue = this.GetAbortValue();
                if (objValue != null)
                {
                    objargs.Add("abort", objValue);
                }

                if (objargs.Count > 0)
                {
                    return objargs;
                }

                return null;
            }
        }
    }
}
