using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;

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
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="objFileEntry">The obj file entry.</param>
        /// <param name="objFileManager">The obj file manager.</param>
        public FileReader(IFileEntry objFileEntry, FileManager objFileManager)
        {
            this.ReadyState = ReaderReadyStateType.Empty;
            mobjFileEntry = objFileEntry;
            mobjFileManager = objFileManager;
        }

        /// <summary>
        /// Gets the file entry.
        /// </summary>
        internal IFileEntry FileEntry
        {
            get { return mobjFileEntry; }
        }

        /// <summary>
        /// Gets the last error code.
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
        /// Reads as data URL.
        /// </summary>
        public void ReadAsDataUrl()
        {
            mobjFileManager.ReadAsDataUrl(this);            
        }

        /// <summary>
        /// Reads as text.
        /// </summary>
        public void ReadAsText()
        {
            ReadAsText(null);
        }

        /// <summary>
        /// Reads as text.
        /// </summary>
        /// <param name="strEncoding">The STR encoding.</param>
        /// <param name="objContext">The obj context.</param>
        public void ReadAsText(string strEncoding)
        {
            mobjFileManager.ReadAsText(this, strEncoding);
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public string Result
        {
            get { return mstrResult; }
            internal set { mstrResult = value; }
        }

        /// <summary>
        /// Sets the abort event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetAbortEvent(EventHandler<FileReaderEventArgs> objCallback)
        {
            mobjAbortCallback = objCallback;
        }

        /// <summary>
        /// Sets the error event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetErrorEvent(EventHandler<FileReaderEventArgs> objCallback)
        {
            mobjErrorCallback = objCallback;
        }

        /// <summary>
        /// Sets the load end event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetLoadEndEvent(EventHandler<FileReaderEventArgs> objCallback)
        {
            mobjLoadEndCallback = objCallback;
        }

        /// <summary>
        /// Sets the load event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetLoadEvent(EventHandler<FileReaderEventArgs> objCallback)
        {
            mobjLoadCallback = objCallback;
        }

        /// <summary>
        /// Sets the load start event.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        public void SetLoadStartEvent(EventHandler<FileReaderEventArgs> objCallback)
        {
            mobjLoadStartCallback = objCallback;
        }

        /// <summary>
        /// Gets the error value.
        /// </summary>
        /// <returns></returns>
        internal object GetErrorValue()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjErrorCallback, mobjErrorClientCallbackData);
        }

        /// <summary>
        /// Gets the abort value.
        /// </summary>
        /// <returns></returns>
        internal object GetAbortValue()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjAbortCallback, mobjAbortClientCallbackData);
        }

        /// <summary>
        /// Gets the load start value.
        /// </summary>
        /// <returns></returns>
        internal object GetLoadStartValue()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjLoadStartCallback, mobjLoadStartClientCallbackData);
        }

        /// <summary>
        /// Gets the load start value.
        /// </summary>
        /// <returns></returns>
        internal object GetLoadEndValue()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjLoadEndCallback, mobjLoadEndClientCallbackData);
        }

        /// <summary>
        /// Gets the load value.
        /// </summary>
        /// <returns></returns>
        internal object GetLoadValue()
        {
            return DeviceUtils.GetServerSideEventTypeString(mobjLoadCallback, mobjLoadClientCallbackData);
        }

        /// <summary>
        /// Determines whether [has server side events].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has server side events]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasServerSideEvents()
        {
            return mobjLoadCallback != null || mobjLoadEndCallback != null || mobjLoadStartCallback != null || mobjErrorCallback != null || mobjAbortCallback != null;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        internal void HandleEvent(IEvent objEvent)
        {
            switch (objEvent.Member.ToLower())
            {
                case "value":
                    this.Result = objEvent.Value;
                    int intLastErrorCode;

                    if (!string.IsNullOrEmpty(objEvent["error"]) && int.TryParse(objEvent["error"], out intLastErrorCode))
                    {
                        this.LastErrorCode = intLastErrorCode;
                    }
                    else
                    {
                        this.LastErrorCode = 0;
                    }
                    
                    break;

                case "loadstart":
                    if (mobjLoadStartCallback != null)
                    {
                        mobjLoadStartCallback(this, new FileReaderEventArgs(this));
                    }
                    this.ReadyState = ReaderReadyStateType.Loading;
                    break;

                case "load":
                    if (mobjLoadCallback != null)
                    {
                        mobjLoadCallback(this, new FileReaderEventArgs(this));
                    }

                    this.ReadyState = ReaderReadyStateType.Done;

                    if (mobjLoadEndCallback != null)
                    {
                        mobjLoadEndCallback(this, new FileReaderEventArgs(this));
                    }
                    break;

                case "loadend":
					this.ReadyState = ReaderReadyStateType.Done;
                    if (mobjLoadEndCallback != null)
                    {
                        mobjLoadEndCallback(this, new FileReaderEventArgs(this));
                    }
                    break;

                case "error":
                    this.ReadyState = ReaderReadyStateType.Done;
                    if (mobjErrorCallback != null)
                    {
                        mobjErrorCallback(this, new FileReaderEventArgs(this));
                    }
                    if (mobjLoadEndCallback != null)
                    {
                        mobjLoadEndCallback(this, new FileReaderEventArgs(this));
                    }
                    break;

                case "abort":
                    this.ReadyState = ReaderReadyStateType.Done;
                    if (mobjAbortCallback != null)
                    {
                        mobjAbortCallback(this, new FileReaderEventArgs(this));
                    }
                    if (mobjLoadEndCallback != null)
                    {
                        mobjLoadEndCallback(this, new FileReaderEventArgs(this));
                    }
                    break;

                default:
                    throw new Exception();
            }

            if (this.ReadyState == ReaderReadyStateType.Done)
            {
                mblnFinished = true;
            }
        }

        /// <summary>
        /// Gets the callbacks.
        /// </summary>
        internal IDictionary<string, object> GetCallbacksData
        {
            get
            {
                IDictionary<string, object> objargs = new Dictionary<string, object>();
                object objValue;
                objValue = this.GetLoadStartValue();
                if (objValue != null)
                {
                    objargs.Add("loadStart", objValue);
                }
                objValue = this.GetLoadValue();
                if (objValue != null)
                {
                    objargs.Add("load", objValue);
                }
                objValue = this.GetLoadEndValue();
                if (objValue != null)
                {
                    objargs.Add("loadEnd", objValue);
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

        /// <summary>
        /// Gets a value indicating whether this <see cref="FileReader"/> is finished.
        /// </summary>
        /// <value>
        ///   <c>true</c> if finished; otherwise, <c>false</c>.
        /// </value>
        public bool Finished
        {
            get
            {
                bool blnFinished = mblnFinished;
                mblnFinished = false;
                return blnFinished;
            }
        }

        /// <summary>
        /// Gets the state of the ready.
        /// </summary>
        /// <value>
        /// The state of the ready.
        /// </value>
        public ReaderReadyStateType ReadyState
        {
            get
            { 
                return menmReaderReadyStateType; 
            }
            internal set
            {
                menmReaderReadyStateType = value;
            }
        }
    }
}
