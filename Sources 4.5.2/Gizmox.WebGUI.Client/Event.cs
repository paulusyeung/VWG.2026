#region Using

using System;
using System.Collections.Specialized;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;
using System.Drawing;

#endregion Using

namespace Gizmox.WebGUI.Client
{
    #region Event Class

    /// <summary>
    /// An
    /// </summary>

    public class Event : EventArgs, IEvent
    {
        #region Class Members

        /// <summary>
        /// WebGUI Context
        /// </summary>
        private NameValueCollection mobjParams = null;

        /// <summary>
        /// Event attributes
        /// </summary>
        private string mstrType = string.Empty;

        private IRegisteredComponent mobjSource = null;

        private IRegisteredComponent mobjTarget = null;

        private string mstrMember = string.Empty;

        private IContext mobjContext = null;


        #endregion Class Members

        #region C'Tor

        /// <summary>
        ///
        /// </summary>
        internal Event(IContext objContext, string strType, IRegisteredComponent objSource)
            : this(objContext, strType, objSource, null, "")
        {

        }

        /// <summary>
        ///
        /// </summary>
        internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget)
            : this(objContext, strType, objSource, objTarget, "")
        {

        }

        /// <summary>
        ///
        /// </summary>
        internal Event(IContext objContext, string strType, IRegisteredComponent objSource, IRegisteredComponent objTarget, string strMember)
        {



            // set evetn data
            mstrType = strType;
            mobjSource = objSource;
            mobjTarget = objTarget;
            mstrMember = strMember;
            mobjContext = objContext;

        }


        #endregion C'Tor

        #region Events

        /// <summary>
        ///
        /// </summary>
        public void Fire()
        {
            this.mobjSource.FireEvent(this);
            ((IContextNotifications)this.mobjContext).SendNotifications();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        public void SetParameter(string strName, string strValue)
        {
            if (mobjParams == null)
            {
                mobjParams = new NameValueCollection();
            }
            mobjParams[strName] = strValue;
        }

        public bool Contains(string strParam)
        {
            if (mobjParams != null)
            {
                return this[strParam] != null;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get the type of the current event
        /// </summary>
        public string Type
        {
            get
            {
                return mstrType;
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the internal member of the current event
        /// </summary>
        public string Member
        {
            get
            {
                return mstrMember;
            }
        }

        /// <summary>
        /// Get the source of the current event
        /// </summary>
        public string Source
        {
            get
            {
                return mobjSource.ID.ToString();
            }
        }

        /// <summary>
        /// Gets the target of the current event
        /// </summary>
        public string Target
        {
            get
            {
                return mobjTarget != null ? mobjTarget.ID.ToString() : "";
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="String"/> with the specified param name.
        /// </summary>
        /// <value></value>
        public string this[string strParam]
        {
            get
            {
                if (this.mobjParams == null)
                {
                    return "";
                }
                else
                {
                    return this.mobjParams[strParam];
                }
            }
        }

        /// <summary>Gets the keyboard code for an event.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> value that is the key code for the event.</returns>
        public Keys KeyCode
        {
            get
            {
                // If key code was sent
                if (this.Contains(WGAttributes.KeyCode))
                {
                    return (Keys)Enum.Parse(typeof(Keys), this[WGAttributes.KeyCode]);
                }
                else
                {
                    return Keys.None;
                }
            }
        }

        /// <summary>Gets a value indicating whether the ALT key was pressed.</summary>
        /// <returns>true if the ALT key was pressed; otherwise, false.</returns>
        public bool AltKey
        {
            get
            {
                return this[WGAttributes.AltKey] == "1";
            }
        }

        /// <summary>Gets a value indicating whether the CTRL key was pressed.</summary>
        /// <returns>true if the CTRL key was pressed; otherwise, false.</returns>
        public bool ControlKey
        {
            get
            {
                return this[WGAttributes.ControlKey] == "1";
            }
        }

        /// <summary>Gets a value indicating whether the SHIFT key was pressed.</summary>
        /// <returns>true if the SHIFT key was pressed; otherwise, false.</returns>
        public bool ShiftKey
        {
            get
            {
                return this[WGAttributes.ShiftKey] == "1";
            }
        }

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        public Point CursorPosition
        {
            get
            {
                return Point.Empty;
            }
        }

        #endregion
    }

    #endregion Event Class

}
