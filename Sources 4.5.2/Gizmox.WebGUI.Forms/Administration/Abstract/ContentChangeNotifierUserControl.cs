using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms.Administration.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusData
    {
        private string mstrStatusText;
        private System.Drawing.Font mobjFont;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusData"/> class.
        /// </summary>
        /// <param name="strText">The string text.</param>
        /// <param name="objFont">The object font.</param>
        public StatusData(string strText, System.Drawing.Font objFont)
        {
            this.mstrStatusText = strText;
            mobjFont = objFont;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusData"/> class.
        /// </summary>
        /// <param name="strText">The string text.</param>
        public StatusData(string strText)
            : this(strText, null)
        { }

        /// <summary>
        /// Sets the status text.
        /// </summary>
        /// <value>
        /// The status text.
        /// </value>
        public string StatusText
        {
            set { mstrStatusText = value; }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return mstrStatusText; }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The font.
        /// </value>
        public System.Drawing.Font Font
        {
            get { return mobjFont; }
            set { mobjFont = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class ContentChangeNotifierUserControl : UserControl
    {
        /// <summary>
        /// The content changed event
        /// </summary>
        private static readonly SerializableEvent ContentChangedEvent = SerializableEvent.Register("ContentChangedEvent", typeof(EventHandler), typeof(ContentChangeNotifierUserControl));

        /// <summary>
        /// Gets the name of the current content.
        /// </summary>
        /// <returns></returns>
        public abstract string GetCurrentContentName();

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns></returns>
        public abstract List<StatusData> GetStatus();

        /// <summary>
        /// Occurs when [content changed].
        /// </summary>
        internal event EventHandler ContentChanged
        {
            add
            {
                this.AddHandler(ContentChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ContentChangedEvent, value);
            }
        }

        /// <summary>
        /// Called when [content changed].
        /// </summary>
        /// <param name="strContentName">Name of the string content.</param>
        protected void OnContentChanged()
        {
            EventHandler objHandler = GetHandler(ContentChangedEvent) as EventHandler;

            if(objHandler != null)
            {
                objHandler(this, EventArgs.Empty);
            }
        }

    }
}
