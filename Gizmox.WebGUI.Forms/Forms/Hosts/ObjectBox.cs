// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.ObjectBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>Summary description for ObjectBox.</summary>
  [ToolboxItem(false)]
  [Gizmox.WebGUI.Forms.MetadataTag("OBJ")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (ObjectBoxSkin))]
  [Serializable]
  public class ObjectBox : Control
  {
    /// <summary>Provides a property reference to ObjectData property.</summary>
    private static SerializableProperty ObjectDataProperty = SerializableProperty.Register(nameof (ObjectData), typeof (string), typeof (ObjectBox));
    /// <summary>Provides a property reference to ObjectType property.</summary>
    private static SerializableProperty ObjectTypeProperty = SerializableProperty.Register(nameof (ObjectType), typeof (string), typeof (ObjectBox));
    /// <summary>Provides a property reference to Gateways property.</summary>
    private static SerializableProperty GatewaysProperty = SerializableProperty.Register("Gateways", typeof (Hashtable), typeof (ObjectBox));
    /// <summary>Provides a property reference to Params property.</summary>
    private static SerializableProperty ParametersProperty = SerializableProperty.Register(nameof (Parameters), typeof (ObjectBox.ObjectBoxParameterCollection), typeof (ObjectBox));

    /// <summary>Adds the parameter.</summary>
    public void AddParameter(string strName, string strValue) => this.Parameters[strName] = (object) strValue;

    /// <summary>Adds the parameter.</summary>
    public void AddParameter(string strName, GatewayHandler objHandler) => this.Parameters[strName] = (object) objHandler;

    /// <summary>Adds the parameter.</summary>
    /// <param name="strName">Name of the STR.</param>
    /// <param name="objResourceHandle">The obj resource handle.</param>
    public void AddParameter(string strName, ResourceHandle objResourceHandle) => this.Parameters[strName] = (object) objResourceHandle;

    /// <summary>Gets the parameter.</summary>
    public string GetParameter(string strName) => this.Parameters[strName] as string;

    /// <summary>Removes the parameter.</summary>
    public void RemoveParameter(string strName)
    {
      if (!this.Parameters.Contains(strName))
        return;
      this.Parameters.Remove(strName);
    }

    /// <summary>Clears the parameters.</summary>
    public void ClearParameters() => this.Parameters.Clear();

    /// <summary>Renders the controls meta attributes</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.ObjectType != string.Empty)
        objWriter.WriteAttributeString("OT", this.ObjectType);
      if (!(this.ObjectData != string.Empty))
        return;
      objWriter.WriteAttributeString("DAT", this.ObjectData);
    }

    /// <summary>Renders the current control.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.Render(objContext, objWriter, lngRequestID);
      foreach (ObjectBox.ObjectBoxParameter parameter in (Collection<ObjectBox.ObjectBoxParameter>) this.Parameters)
      {
        if (!string.IsNullOrEmpty(parameter.Name))
        {
          objWriter.WriteStartElement("P");
          objWriter.WriteAttributeString("N", parameter.Name);
          object obj = parameter.Value;
          if (obj == null)
            objWriter.WriteAttributeString("VLB", string.Empty);
          else
            objWriter.WriteAttributeString("VLB", obj.ToString());
          objWriter.WriteEndElement();
        }
      }
    }

    /// <summary>Gets the parameters hash.</summary>
    /// <value></value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
    [Description("")]
    public ObjectBox.ObjectBoxParameterCollection Parameters
    {
      get
      {
        ObjectBox.ObjectBoxParameterCollection objValue = this.GetValue<ObjectBox.ObjectBoxParameterCollection>(ObjectBox.ParametersProperty, (ObjectBox.ObjectBoxParameterCollection) null);
        if (objValue == null)
        {
          objValue = new ObjectBox.ObjectBoxParameterCollection(this);
          this.SetValue<ObjectBox.ObjectBoxParameterCollection>(ObjectBox.ParametersProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Gets or sets the type of the object.</summary>
    /// <value>The type of the object.</value>
    protected string ObjectType
    {
      get => this.GetValue<string>(ObjectBox.ObjectTypeProperty, string.Empty);
      set
      {
        if (!(this.ObjectType != value))
          return;
        if (string.IsNullOrEmpty(value))
          this.RemoveValue<string>(ObjectBox.ObjectTypeProperty);
        else
          this.SetValue<string>(ObjectBox.ObjectTypeProperty, value);
      }
    }

    /// <summary>Gets or sets the Data of the object.</summary>
    /// <value>The Data of the object.</value>
    protected string ObjectData
    {
      get => this.GetValue<string>(ObjectBox.ObjectDataProperty, string.Empty);
      set
      {
        if (!(this.ObjectData != value))
          return;
        if (string.IsNullOrEmpty(value))
          this.RemoveValue<string>(ObjectBox.ObjectDataProperty);
        else
          this.SetValue<string>(ObjectBox.ObjectDataProperty, value);
      }
    }

    /// <summary>Gets or sets the type of the object plugins page.</summary>
    /// <value>The type of the object plugins page.</value>
    protected string ObjectPluginsPageType
    {
      get => this.Parameters["pluginspagetype"] == null ? string.Empty : this.Parameters["pluginspagetype"].ToString();
      set => this.Parameters["pluginspagetype"] = (object) value;
    }

    /// <summary>Gets or sets the object class id.</summary>
    /// <value>The object class id.</value>
    protected string ObjectClassId
    {
      get => this.Parameters["classid"] == null ? string.Empty : this.Parameters["classid"].ToString();
      set => this.Parameters["classid"] = (object) value;
    }

    /// <summary>Gets or sets the object code base.</summary>
    /// <value>The object code base.</value>
    protected string ObjectCodeBase
    {
      get => this.Parameters["codebase"] == null ? string.Empty : this.Parameters["codebase"].ToString();
      set => this.Parameters["codebase"] = (object) value;
    }

    /// <summary>Gets or sets the stand by internal.</summary>
    /// <value>The stand by internal.</value>
    protected string ObjectStandBy
    {
      get => this.Parameters["standby"] == null ? string.Empty : this.Parameters["standby"].ToString();
      set => this.Parameters["standby"] = (object) value;
    }

    /// <summary>Processes the gateway request.</summary>
    /// <param name="objHostContext">The host context.</param>
    /// <param name="strAction">The action.</param>
    /// <returns></returns>
    protected override IGatewayHandler ProcessGatewayRequest(
      HostContext objHostContext,
      string strAction)
    {
      return this.Parameters[strAction] is GatewayReference parameter && parameter.Handler != null ? (IGatewayHandler) parameter.Handler : (IGatewayHandler) null;
    }

    [Editor("Gizmox.WebGUI.Forms.Design.ObjectBoxParameterCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Serializable]
    public class ObjectBoxParameterCollection : Collection<ObjectBox.ObjectBoxParameter>
    {
      private ObjectBox mobjObjectBox;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameterCollection" /> class.
      /// </summary>
      /// <param name="objObjectBox">The obj object box.</param>
      internal ObjectBoxParameterCollection(ObjectBox objObjectBox) => this.mobjObjectBox = objObjectBox;

      /// <summary>Adds the specified  name.</summary>
      /// <param name="strName">Name.</param>
      /// <param name="objValue">The value.</param>
      public void Add(string strName, object objValue) => this[strName] = objValue;

      /// <summary>
      /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1" /> at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
      /// <param name="objItem">The object to insert. The value can be null for reference types.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// 	<paramref name="index" /> is less than zero.
      /// -or-
      /// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
      /// </exception>
      protected override void InsertItem(int index, ObjectBox.ObjectBoxParameter objItem)
      {
        this.ValidateItem(objItem);
        this.SetOwner(objItem);
        this.FormatValue(objItem);
        base.InsertItem(index, objItem);
      }

      /// <summary>Replaces the element at the specified index.</summary>
      /// <param name="index">The zero-based index of the element to replace.</param>
      /// <param name="objItem">The new value for the element at the specified index. The value can be null for reference types.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">
      /// 	<paramref name="index" /> is less than zero.
      /// -or-
      /// <paramref name="index" /> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.
      /// </exception>
      protected override void SetItem(int index, ObjectBox.ObjectBoxParameter objItem)
      {
        this.ValidateItem(objItem);
        this.SetOwner(objItem);
        this.FormatValue(objItem);
        base.SetItem(index, objItem);
      }

      /// <summary>Gets the object box.</summary>
      /// <value>The object box.</value>
      internal ObjectBox ObjectBox => this.mobjObjectBox;

      /// <summary>Sets the owner.</summary>
      /// <param name="objItem">The item.</param>
      private void SetOwner(ObjectBox.ObjectBoxParameter objItem) => objItem.SetOwner(this);

      /// <summary>Formats the value.</summary>
      /// <param name="objParameter">The obj parameter.</param>
      internal void FormatValue(ObjectBox.ObjectBoxParameter objParameter)
      {
        if (objParameter.Value is GatewayReference gatewayReference)
          objParameter.Value = (object) gatewayReference.Handler;
        if (!(objParameter.Value is GatewayHandler))
          return;
        objParameter.Value = (object) new GatewayReference((IRegisteredComponent) this.mobjObjectBox, objParameter.Name);
      }

      /// <summary>Validates the item.</summary>
      /// <param name="objItem">The item.</param>
      private void ValidateItem(ObjectBox.ObjectBoxParameter objItem)
      {
        if (objItem.Name == null)
        {
          int num = 1;
          string str;
          while (this.HasName(str = string.Format("parameter{0}", (object) num)))
            ++num;
          objItem.Name = str;
        }
        else
          this.ValidateName(objItem.Name);
      }

      /// <summary>Determines whether the specified value has name.</summary>
      /// <param name="strValue">The value.</param>
      /// <returns>
      /// 	<c>true</c> if the specified value has name; otherwise, <c>false</c>.
      /// </returns>
      internal bool HasName(string strValue)
      {
        foreach (ObjectBox.ObjectBoxParameter objectBoxParameter in (Collection<ObjectBox.ObjectBoxParameter>) this)
        {
          if (objectBoxParameter.Name == strValue)
            return true;
        }
        return false;
      }

      /// <summary>Validates the name.</summary>
      /// <param name="strValue">The value.</param>
      internal void ValidateName(string strValue)
      {
        if (this.HasName(strValue))
          throw new ArgumentException("Cannot insert duplicate names.");
      }

      /// <summary>Gets the keys.</summary>
      /// <value>The keys.</value>
      public string[] Keys
      {
        get
        {
          List<string> stringList = new List<string>();
          foreach (ObjectBox.ObjectBoxParameter objectBoxParameter in (Collection<ObjectBox.ObjectBoxParameter>) this)
            stringList.Add(objectBoxParameter.Name);
          return stringList.ToArray();
        }
      }

      /// <summary>
      /// Determines whether [contains] [the specified STR name].
      /// </summary>
      /// <param name="strName">Name of the STR.</param>
      /// <returns>
      /// 	<c>true</c> if [contains] [the specified STR name]; otherwise, <c>false</c>.
      /// </returns>
      public bool Contains(string strName) => this.HasName(strName);

      /// <summary>
      /// Gets or sets the <see cref="T:System.Object" /> with the specified STR name.
      /// </summary>
      /// <value></value>
      public object this[string strName]
      {
        get
        {
          foreach (ObjectBox.ObjectBoxParameter objectBoxParameter in (Collection<ObjectBox.ObjectBoxParameter>) this)
          {
            if (objectBoxParameter.Name == strName)
              return objectBoxParameter.Value;
          }
          return (object) null;
        }
        set
        {
          this.Remove(strName);
          this.Add(new ObjectBox.ObjectBoxParameter(this, strName, value));
        }
      }

      /// <summary>Removes the specified STR name.</summary>
      /// <param name="strName">Name of the STR.</param>
      public void Remove(string strName)
      {
        ObjectBox.ObjectBoxParameter objectBoxParameter1 = (ObjectBox.ObjectBoxParameter) null;
        foreach (ObjectBox.ObjectBoxParameter objectBoxParameter2 in (Collection<ObjectBox.ObjectBoxParameter>) this)
        {
          if (objectBoxParameter2.Name == strName)
          {
            objectBoxParameter1 = objectBoxParameter2;
            break;
          }
        }
        if (objectBoxParameter1 == null)
          return;
        this.Remove(objectBoxParameter1);
      }
    }

    /// <summary>object box parameter</summary>
    [Serializable]
    public class ObjectBoxParameter
    {
      /// <summary>
      /// 
      /// </summary>
      private ObjectBox.ObjectBoxParameterCollection mobjOwner;
      /// <summary>
      /// 
      /// </summary>
      private object mobjValue;
      /// <summary>
      /// 
      /// </summary>
      private string mstrName;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameter" /> class.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public ObjectBoxParameter()
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.ObjectBox.ObjectBoxParameter" /> class.
      /// </summary>
      /// <param name="objOwner">The owner.</param>
      /// <param name="strName">Name.</param>
      /// <param name="objValue">The value.</param>
      internal ObjectBoxParameter(
        ObjectBox.ObjectBoxParameterCollection objOwner,
        string strName,
        object objValue)
      {
        if (string.IsNullOrEmpty(strName))
          throw new ArgumentNullException(nameof (strName), "Parameter name cannot be null.");
        this.mobjOwner = objOwner;
        this.mobjValue = objValue;
        this.mstrName = strName;
      }

      /// <summary>Sets the parent.</summary>
      /// <param name="objOwner">The owner.</param>
      internal void SetOwner(ObjectBox.ObjectBoxParameterCollection objOwner) => this.mobjOwner = objOwner;

      /// <summary>Gets or sets the name.</summary>
      /// <value>The name.</value>
      public string Name
      {
        get => this.mstrName;
        set
        {
          if (this.mobjOwner != null)
            this.mobjOwner.ValidateName(value);
          this.mstrName = value;
        }
      }

      /// <summary>Gets or sets the value.</summary>
      /// <value>The value.</value>
      [DefaultValue(null)]
      [TypeConverter(typeof (StringConverter))]
      public object Value
      {
        get => this.mobjValue;
        set => this.mobjValue = value;
      }

      /// <summary>
      /// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
      /// </returns>
      public override string ToString() => this.Name;
    }
  }
}
