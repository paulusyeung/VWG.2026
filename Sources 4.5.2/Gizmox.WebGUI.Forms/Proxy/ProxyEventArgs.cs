using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
    #region FireEventEventArgs Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    internal class ProxyFireEventArgs : EventArgs
    {
        #region Fields

        private bool mblnAllowEvent = true;
        private IEvent mobjEvent = null;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyFireEventArgs"/> class.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <param name="blnAllowEvent">if set to <c>true</c> [BLN allow event].</param>
        public ProxyFireEventArgs(IEvent objEvent, bool blnAllowEvent)
        {
            mobjEvent = objEvent;
            mblnAllowEvent = blnAllowEvent;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow event].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow event]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowEvent
        {
            get
            {
                return mblnAllowEvent;
            }
            set
            {
                mblnAllowEvent = value;
            }
        }

        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public IEvent Event
        {
            get
            {
                return mobjEvent;
            }
            set
            {
                mobjEvent = value;
            }
        }

        #endregion Properties
    } 

    #endregion

    #region ProxyPropertyValueEventArgs Class

    [Serializable()]
    internal class ProxyPropertyValueEventArgs : EventArgs
    {
        #region Fields

        private object mobjValue = null;
        private string mstrPropertyName = string.Empty;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyPropertyValueEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <param name="objValue">The obj value.</param>
        public ProxyPropertyValueEventArgs(string strPropertyName, object objValue)
        {
            mstrPropertyName = strPropertyName;
            mobjValue = objValue;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName
        {
            get
            {
                return mstrPropertyName;
            }
            set
            {
                mstrPropertyName = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get
            {
                return mobjValue;
            }
            set
            {
                mobjValue = value;
            }
        }

        #endregion Properties
    }
    
    #endregion

    #region ProxyFilterPropertiesEventArgs Class

    [Serializable()]
    internal class ProxyFilterPropertiesEventArgs : EventArgs
    {
        #region Fields

        private IDictionary mobjPropertyDescriptors = null;        

        #endregion Fields

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyFilterPropertiesEventArgs"/> class.
        /// </summary>
        /// <param name="objPropertyDescriptors">The obj property descriptors.</param>
        public ProxyFilterPropertiesEventArgs(IDictionary objPropertyDescriptors)
        {
            mobjPropertyDescriptors = objPropertyDescriptors;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the property descriptors.
        /// </summary>
        /// <value>
        /// The property descriptors.
        /// </value>
        public IDictionary PropertyDescriptors
        {
            get
            {
                return mobjPropertyDescriptors;
            }
            set
            {
                mobjPropertyDescriptors = value;
            }
        }

        #endregion Properties

    }

    #endregion ProxyFilterPropertiesEventArgs Class
}