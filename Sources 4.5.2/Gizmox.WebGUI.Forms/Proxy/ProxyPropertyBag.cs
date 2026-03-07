using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    internal delegate void PropertyValueChanging(object sender, EventArgs e);    

    #endregion

    /// <summary>
    /// The property bag dictionary added to support events when changing it.
    /// </summary>
    [Serializable()]
    public class ProxyPropertyBag : Dictionary<string, object>
    {
        /// <summary>
        /// 
        /// </summary>
        private UiPropertyValueChangedEventHandler mobjPropertyValueChangedEventHandler = null;


        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyPropertyBag"/> class.
        /// </summary>
        public ProxyPropertyBag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyPropertyBag"/> class.
        /// </summary>
        /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object containing the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
        /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure containing the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2" />.</param>
        protected ProxyPropertyBag(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            mobjPropertyValueChangedEventHandler = info.GetValue("UiPropertyValueChangedEventHandler", typeof(UiPropertyValueChangedEventHandler)) as UiPropertyValueChangedEventHandler;
        }

        #endregion Ctor




        #region Events

        /// <summary>
        /// Occurs when [UI property value changing].
        /// </summary>
        internal event UiPropertyValueChangedEventHandler PropertyValueChanging
        {
            add
            {
                mobjPropertyValueChangedEventHandler += value;
            }
            remove
            {
                mobjPropertyValueChangedEventHandler -= value;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified string key.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="strKey">The string key.</param>
        /// <returns></returns>
        public object this[string strKey]
        {
            get
            {
                return base[strKey];
            }
            set
            {
                ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs = new ProxyPropertyValueEventArgs(strKey, value);

                OnPropertyValueChanging(objProxyPropertyValueEventArgs);

                base[strKey] = value;
            }
        }

        
        /// <summary>
        /// Raises the <see cref="E:PropertyValueChanging"/> event.
        /// </summary>
        /// <param name="objProxyPropertyValueEventArgs">The <see cref="Gizmox.WebGUI.Forms.ProxyPropertyValueEventArgs"/> instance containing the event data.</param>
        private void OnPropertyValueChanging(ProxyPropertyValueEventArgs objProxyPropertyValueEventArgs)
        {
            if (mobjPropertyValueChangedEventHandler != null)
            {
                mobjPropertyValueChangedEventHandler(this, objProxyPropertyValueEventArgs);
            }
        }


        /// <summary>
        /// Implements the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface and returns the data needed to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.
        /// </summary>
        /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that contains the information required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.</param>
        /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> structure that contains the source and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2" /> instance.</param>
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("UiPropertyValueChangedEventHandler", mobjPropertyValueChangedEventHandler);
        }
    }
}