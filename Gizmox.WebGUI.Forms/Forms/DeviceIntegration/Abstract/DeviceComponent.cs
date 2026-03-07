// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.DeviceComponent
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration.Abstract
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public abstract class DeviceComponent : RegisteredComponent
  {
    private DeviceIntegrator mobjDeviceIntegrator;
    private List<KeyValuePair<string, object[]>> mobjClientMethodsInvocationBuffer;
    private bool mblnBufferInvoke = true;
    private bool mblnShouldThrowUnsupportedError = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.DeviceComponent" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public DeviceComponent(DeviceIntegrator objDeviceIntegrator) => this.mobjDeviceIntegrator = objDeviceIntegrator;

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal abstract string GetTag();

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "DNIE")
        throw new NotSupportedException(string.Format("This Device Provider do not support the {0} method of {1}", (object) objEvent["methodName"], (object) objEvent["featureName"]));
    }

    /// <summary>Renders the component ID.</summary>
    /// <param name="objWriter">The obj writer.</param>
    protected void RenderComponentID(IAttributeWriter objWriter) => objWriter.WriteAttributeString("Id", this.ID.ToString());

    /// <summary>Gets the mobile integrator.</summary>
    protected internal DeviceIntegrator DeviceIntegrator => this.mobjDeviceIntegrator;

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.DeviceIntegrator.Update();
    }

    /// <summary>Gets the current application context.</summary>
    public override IContext Context => VWGContext.Current;

    /// <summary>Renders the attributes.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    internal virtual void RenderAttributes(IContext objContext, IResponseWriter objWriter)
    {
    }

    /// <summary>
    /// Called just before the RenderComponent is called.
    /// NOTE: This method is called also if the component is not dirty.
    /// </summary>
    public void OnRendering(IContext objContext, IResponseWriter objWriter, long lngRequestID) => this.mblnBufferInvoke = false;

    /// <summary>
    /// Called after the render component is called.
    /// NOTE: This method is called also if the component is not dirty.
    /// </summary>
    public void OnRendered(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      this.InvokeBufferedMethods();
      this.mblnBufferInvoke = true;
    }

    /// <summary>Renders the component.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="lngRequestID">The LNG request ID.</param>
    internal void RenderComponent(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      if (!this.IsRegistered)
        this.RegisterSelf();
      if (!this.IsDirty(lngRequestID))
        return;
      objWriter.WriteStartElement(this.GetTag());
      this.RenderComponentID(objWriter as IAttributeWriter);
      this.RenderAttributes(objContext, objWriter);
      this.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.RenderComponentClientEvents(objContext, objWriter, lngRequestID);
      this.ClearComponentOfflineEvents();
      objWriter.WriteEndElement();
    }

    protected internal virtual void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
    }

    /// <summary>Invoke all methods that are stored in the buffer</summary>
    private void InvokeBufferedMethods()
    {
      if (this.mobjClientMethodsInvocationBuffer == null)
        return;
      foreach (KeyValuePair<string, object[]> keyValuePair in this.mobjClientMethodsInvocationBuffer)
        VWGClientContext.Current.Invoke(keyValuePair.Key, keyValuePair.Value);
      this.mobjClientMethodsInvocationBuffer.Clear();
      this.mobjClientMethodsInvocationBuffer = (List<KeyValuePair<string, object[]>>) null;
    }

    /// <summary>Centralized method to invoke client methods</summary>
    /// <param name="strMethodName"></param>
    /// <param name="arrArguments"></param>
    protected internal virtual void Invoke(string strMethodName, params object[] arrArguments)
    {
      if (this.mblnBufferInvoke)
      {
        this.mobjClientMethodsInvocationBuffer = this.mobjClientMethodsInvocationBuffer ?? new List<KeyValuePair<string, object[]>>();
        this.mobjClientMethodsInvocationBuffer.Add(new KeyValuePair<string, object[]>(strMethodName, arrArguments));
      }
      else
        VWGClientContext.Current.Invoke((ISkinable) this.DeviceIntegrator, strMethodName, arrArguments);
    }

    /// <summary>Splits the prefix from method key.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <returns></returns>
    protected internal KeyValuePair<string, string> SplitPrefixFromMethodKey(string strValue)
    {
      string[] strArray = strValue.Split('-');
      return strArray.Length == 2 ? new KeyValuePair<string, string>(strArray[0], strArray[1]) : new KeyValuePair<string, string>((string) null, (string) null);
    }
  }
}
