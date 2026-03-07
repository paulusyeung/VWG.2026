#region Using

using System;
using System.Xml;
using System.Web;
using System.Collections;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Hosting;

#endregion Using

namespace Gizmox.WebGUI.Forms.Hosts
{
    #region ObjectBox Class

    /// <summary>
    /// Summary description for ObjectBox.
    /// </summary>
    [System.ComponentModel.ToolboxItem(false)]
    [MetadataTag(WGTags.Object)]
    [Serializable()]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Hosts.Skins.ObjectBoxSkin))]
    public class ObjectBox : Control
    {
        #region Static Members
        
        /// <summary>
        /// Provides a property reference to ObjectData property.
        /// </summary>
        private static SerializableProperty ObjectDataProperty = SerializableProperty.Register("ObjectData", typeof(string), typeof(ObjectBox));

        /// <summary>
        /// Provides a property reference to ObjectType property.
        /// </summary>
        private static SerializableProperty ObjectTypeProperty = SerializableProperty.Register("ObjectType", typeof(string), typeof(ObjectBox));

        /// <summary>
        /// Provides a property reference to Gateways property.
        /// </summary>
        private static SerializableProperty GatewaysProperty = SerializableProperty.Register("Gateways", typeof(Hashtable), typeof(ObjectBox));

        /// <summary>
        /// Provides a property reference to Params property.
        /// </summary>
        private static SerializableProperty ParametersProperty = SerializableProperty.Register("Parameters", typeof(ObjectBoxParameterCollection), typeof(ObjectBox));

        #endregion

        #region Class Members

        #endregion Class Members

        #region Classes

#if WG_NET46
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [Serializable]
        public class ObjectBoxParameterCollection : Collection<ObjectBoxParameter>
        {

            private ObjectBox mobjObjectBox = null;



            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectBoxParameterCollection"/> class.
            /// </summary>
            /// <param name="objObjectBox">The obj object box.</param>
            internal ObjectBoxParameterCollection(ObjectBox objObjectBox)
            {
                mobjObjectBox = objObjectBox;
            }


            /// <summary>
            /// Adds the specified  name.
            /// </summary>
            /// <param name="strName">Name.</param>
            /// <param name="objValue">The value.</param>
            public void Add(string strName, object objValue)
            {
                this[strName] = objValue;
            }

            /// <summary>
            /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
            /// <param name="objItem">The object to insert. The value can be null for reference types.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// 	<paramref name="index"/> is less than zero.
            /// -or-
            /// <paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.
            /// </exception>
            protected override void InsertItem(int index, ObjectBoxParameter objItem)
            {
                ValidateItem(objItem);
                SetOwner(objItem);
                FormatValue(objItem);
                base.InsertItem(index, objItem);
            }




            /// <summary>
            /// Replaces the element at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the element to replace.</param>
            /// <param name="objItem">The new value for the element at the specified index. The value can be null for reference types.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// 	<paramref name="index"/> is less than zero.
            /// -or-
            /// <paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.
            /// </exception>
            protected override void SetItem(int index, ObjectBoxParameter objItem)
            {
                ValidateItem(objItem);
                SetOwner(objItem);
                FormatValue(objItem);
                base.SetItem(index, objItem);
            }

            /// <summary>
            /// Gets the object box.
            /// </summary>
            /// <value>The object box.</value>
            internal ObjectBox ObjectBox
            {
                get { return mobjObjectBox; }
            }

            /// <summary>
            /// Sets the owner.
            /// </summary>
            /// <param name="objItem">The item.</param>
            private void SetOwner(ObjectBoxParameter objItem)
            {
                objItem.SetOwner(this);


            }

            /// <summary>
            /// Formats the value.
            /// </summary>
            /// <param name="objParameter">The obj parameter.</param>
            internal void FormatValue(ObjectBoxParameter objParameter)
            {
                GatewayReference objGatewayReference = objParameter.Value as GatewayReference;
                if (objGatewayReference != null)
                {
                    objParameter.Value = objGatewayReference.Handler;
                }

                GatewayHandler objGatewayHandler = objParameter.Value as GatewayHandler;
                if (objGatewayHandler != null)
                {
                    objParameter.Value = new GatewayReference(mobjObjectBox, objParameter.Name);
                }
            }


            /// <summary>
            /// Validates the item.
            /// </summary>
            /// <param name="objItem">The item.</param>
            private void ValidateItem(ObjectBoxParameter objItem)
            {
                if (objItem.Name == null)
                {
                    string strName = null;
                    int intName = 1;

                    while (HasName(strName = string.Format("parameter{0}", intName)))
                    {
                        intName++;
                    }

                    objItem.Name = strName;
                }
                else
                {
                    ValidateName(objItem.Name);
                }
            }

            /// <summary>
            /// Determines whether the specified value has name.
            /// </summary>
            /// <param name="strValue">The value.</param>
            /// <returns>
            /// 	<c>true</c> if the specified value has name; otherwise, <c>false</c>.
            /// </returns>
            internal bool HasName(string strValue)
            {
                foreach (ObjectBoxParameter objParameter in this)
                {
                    if (objParameter.Name == strValue)
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// Validates the name.
            /// </summary>
            /// <param name="strValue">The value.</param>
            internal void ValidateName(string strValue)
            {
                if (HasName(strValue))
                {
                    throw new ArgumentException("Cannot insert duplicate names.");

                }
            }


            /// <summary>
            /// Gets the keys.
            /// </summary>
            /// <value>The keys.</value>
            public string[] Keys
            {
                get
                {
                    List<string> objKeys = new List<string>();

                    foreach (ObjectBoxParameter objParameter in this)
                    {
                        objKeys.Add(objParameter.Name);
                    }

                    return objKeys.ToArray();
                }
            }

            /// <summary>
            /// Determines whether [contains] [the specified STR name].
            /// </summary>
            /// <param name="strName">Name of the STR.</param>
            /// <returns>
            /// 	<c>true</c> if [contains] [the specified STR name]; otherwise, <c>false</c>.
            /// </returns>
            public bool Contains(string strName)
            {
                return this.HasName(strName);
            }

            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> with the specified STR name.
            /// </summary>
            /// <value></value>
            public object this[string strName]
            {
                get
                {
                    foreach (ObjectBoxParameter objParameter in this)
                    {
                        if (objParameter.Name == strName)
                        {
                            return objParameter.Value;
                        }
                    }

                    return null;
                }
                set
                {

                    this.Remove(strName);

                    this.Add(new ObjectBoxParameter(this, strName, value));
                }
            }

            /// <summary>
            /// Removes the specified STR name.
            /// </summary>
            /// <param name="strName">Name of the STR.</param>
            public void Remove(string strName)
            {
                ObjectBoxParameter objOldParam = null;


                foreach (ObjectBoxParameter objParameter in this)
                {
                    if (objParameter.Name == strName)
                    {
                        objOldParam = objParameter;
                        break;
                    }
                }

                if (objOldParam != null)
                {
                    this.Remove(objOldParam);
                }
            }
        }

        /// <summary>
        /// object box parameter
        /// </summary>
        [Serializable]
        public class ObjectBoxParameter
        {
            /// <summary>
            /// 
            /// </summary>
            private ObjectBoxParameterCollection mobjOwner = null;

            /// <summary>
            /// 
            /// </summary>
            private object mobjValue = null;

            /// <summary>
            /// 
            /// </summary>
            private string mstrName = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectBoxParameter"/> class.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ObjectBoxParameter()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectBoxParameter"/> class.
            /// </summary>
            /// <param name="objOwner">The owner.</param>
            /// <param name="strName">Name.</param>
            /// <param name="objValue">The value.</param>
            internal ObjectBoxParameter(ObjectBoxParameterCollection objOwner, string strName, object objValue)
            {
                if (string.IsNullOrEmpty(strName))
                {
                    throw new ArgumentNullException("strName", "Parameter name cannot be null.");
                }
                mobjOwner = objOwner;
                mobjValue = objValue;
                mstrName = strName;
            }

            /// <summary>
            /// Sets the parent.
            /// </summary>
            /// <param name="objOwner">The owner.</param>
            internal void SetOwner(ObjectBoxParameterCollection objOwner)
            {
                mobjOwner = objOwner;
            }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name
            {
                get
                {
                    return mstrName;
                }
                set
                {
                    if (mobjOwner != null)
                    {
                        mobjOwner.ValidateName(value);
                    }

                    mstrName = value;
                }
            }

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            [System.ComponentModel.DefaultValue(null)]
            [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.StringConverter))]
            public object Value
            {
                get { return mobjValue; }
                set { mobjValue = value; }
            }

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </returns>
            public override string ToString()
            {
                return this.Name;
            }
        }

        #endregion

        #region C'Tor\D'Tor

        /// <summary>
        /// Creates a new <see cref="ObjectBox"/> instance.
        /// </summary>
        public ObjectBox()
        {
        }


        #endregion C'Tor\D'Tor

        #region Methods

        #region Parameters

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        public void AddParameter(string strName, string strValue)
        {
            this.Parameters[strName] = strValue;
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        public void AddParameter(string strName, GatewayHandler objHandler)
        {
            this.Parameters[strName] = objHandler;
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="strName">Name of the STR.</param>
        /// <param name="objResourceHandle">The obj resource handle.</param>
        public void AddParameter(string strName, ResourceHandle objResourceHandle)
        {
            Parameters[strName] = objResourceHandle;

        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        public string GetParameter(string strName)
        {
            return this.Parameters[strName] as string;
        }

        /// <summary>
        /// Removes the parameter.
        /// </summary>
        public void RemoveParameter(string strName)
        {
            if (this.Parameters.Contains(strName))
            {
                this.Parameters.Remove(strName);
            }

        }

        /// <summary>
        /// Clears the parameters.
        /// </summary>
        public void ClearParameters()
        {
            this.Parameters.Clear();
        }


        #endregion Parameters


        #region Render

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            
            // Render object's type.
            if (this.ObjectType != string.Empty)
            {
                objWriter.WriteAttributeString(WGAttributes.ObjectType, this.ObjectType);
            }

            // Render object's data.
            if (this.ObjectData != string.Empty)
            {
                objWriter.WriteAttributeString(WGAttributes.Data, this.ObjectData);
            }            
        }

        /// <summary>
        /// Renders the current control.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            base.Render(objContext, objWriter, lngRequestID);

            // loop and create object's params
            foreach (ObjectBoxParameter objParameter in this.Parameters)
            {
                if (!string.IsNullOrEmpty(objParameter.Name))
                {
                    objWriter.WriteStartElement(WGTags.Param);
                    objWriter.WriteAttributeString(WGAttributes.Name, objParameter.Name);

                    object objParamValue = objParameter.Value;
                    if (objParamValue == null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Value, string.Empty);
                    }
                    else
                    {
                        objWriter.WriteAttributeString(WGAttributes.Value, objParamValue.ToString());
                    }

                    objWriter.WriteEndElement();
                }
            }
        }

        #endregion Render

        #endregion Methods

        #region Protected Properties

        /// <summary>
        /// Gets the parameters hash.
        /// </summary>
        /// <value></value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatBehavior"), Description("")]
        public ObjectBoxParameterCollection Parameters
        {
            get
            {
                ObjectBoxParameterCollection objParams = this.GetValue<ObjectBoxParameterCollection>(ObjectBox.ParametersProperty, null);
                if (objParams == null)
                {
                    objParams = new ObjectBoxParameterCollection(this);

                    this.SetValue<ObjectBoxParameterCollection>(ObjectBox.ParametersProperty, objParams);
                }

                return objParams;
            }

        }



        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>The type of the object.</value>
        protected string ObjectType
        {
            get
            {
                return this.GetValue<string>(ObjectBox.ObjectTypeProperty, string.Empty);
            }
            set
            {
                //If the value changed
                if (this.ObjectType != value)
                {
                    //If the value was set to default
                    if (string.IsNullOrEmpty(value))
                    {
                        //Remove from the property store
                        this.RemoveValue<string>(ObjectBox.ObjectTypeProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<string>(ObjectBox.ObjectTypeProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the Data of the object.
        /// </summary>
        /// <value>The Data of the object.</value>
        protected string ObjectData
        {
            get
            {
                return this.GetValue<string>(ObjectBox.ObjectDataProperty, string.Empty);
            }
            set
            {
                //If the value changed
                if (this.ObjectData != value)
                {
                    //If the value was set to default
                    if (string.IsNullOrEmpty(value))
                    {
                        //Remove from the property store
                        this.RemoveValue<string>(ObjectBox.ObjectDataProperty);
                    }
                    else
                    {
                        //Set the value in the property store
                        this.SetValue<string>(ObjectBox.ObjectDataProperty, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the object plugins page.
        /// </summary>
        /// <value>The type of the object plugins page.</value>
        protected string ObjectPluginsPageType
        {
            get
            {
                // Get the property from the property story  
                return Parameters["pluginspagetype"] != null ? Parameters["pluginspagetype"].ToString() : string.Empty;
            }
            set
            {
                Parameters["pluginspagetype"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the object class id.
        /// </summary>
        /// <value>The object class id.</value>
        protected string ObjectClassId
        {
            get
            {
                // Get the property from the property story  
                return Parameters["classid"] != null ? Parameters["classid"].ToString() : string.Empty;
            }
            set
            {
                Parameters["classid"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the object code base.
        /// </summary>
        /// <value>The object code base.</value>
        protected string ObjectCodeBase
        {
            get
            {
                // Get the property from the property story  
                return Parameters["codebase"] != null ? Parameters["codebase"].ToString() : string.Empty;
            }
            set
            {
                Parameters["codebase"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the stand by internal.
        /// </summary>
        /// <value>The stand by internal.</value>
        protected string ObjectStandBy
        {
            get
            {
                // Get the property from the property story  
                return Parameters["standby"] != null ? Parameters["standby"].ToString() : string.Empty;
            }
            set
            {
                Parameters["standby"] = value;
            }
        }

        #endregion Protected Properties

        #region IGatewayControl Members


        /// <summary>
        /// Processes the gateway request.
        /// </summary>
        /// <param name="objHostContext">The host context.</param>
        /// <param name="strAction">The action.</param>
        /// <returns></returns>
        protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
        {
            GatewayReference objGatewayReference = this.Parameters[strAction] as GatewayReference;
            if (objGatewayReference != null)
            {
                if (objGatewayReference.Handler != null)
                {
                    return objGatewayReference.Handler;
                }
            }

            return null;
        }


        #endregion IGatewayControl Members
    }

    #endregion ObjectBox Class

}
