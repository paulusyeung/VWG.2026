// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Design.EventsTab
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms.Design
{
  /// <summary>Provides a <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> that can display events for selection and linking.</summary>
  [Serializable]
  public class EventsTab : PropertyTab
  {
    private IDesignerHost mobjCurrentHost;
    private IServiceProvider mobjServiceProvider;
    private bool mblnSunkEvent;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.EventsTab"></see> class.</summary>
    /// <param name="objServiceProvider">An <see cref="T:System.IServiceProvider"></see> to use. </param>
    public EventsTab(IServiceProvider objServiceProvider) => this.mobjServiceProvider = objServiceProvider;

    /// <summary>Gets a value indicating whether the specified object can be extended.</summary>
    /// <returns>true if the specified object can be extended; otherwise, false.</returns>
    /// <param name="objExtendee">The object to test for extensibility. </param>
    public override bool CanExtend(object objExtendee) => !Marshal.IsComObject(objExtendee);

    /// <summary>Gets the default property from the specified object.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> indicating the default property.</returns>
    /// <param name="obj">The object to retrieve the default property of. </param>
    public override PropertyDescriptor GetDefaultProperty(object obj)
    {
      IEventBindingService eventPropertyService = this.GetEventPropertyService(obj, (ITypeDescriptorContext) null);
      if (eventPropertyService != null)
      {
        EventDescriptor defaultEvent = TypeDescriptor.GetDefaultEvent(obj);
        if (defaultEvent != null)
          return eventPropertyService.GetEventProperty(defaultEvent);
      }
      return (PropertyDescriptor) null;
    }

    private IEventBindingService GetEventPropertyService(
      object obj,
      ITypeDescriptorContext objContext)
    {
      IEventBindingService eventPropertyService = (IEventBindingService) null;
      if (!this.mblnSunkEvent)
      {
        IDesignerEventService service = (IDesignerEventService) this.mobjServiceProvider.GetService(typeof (IDesignerEventService));
        if (service != null)
          service.ActiveDesignerChanged += new ActiveDesignerEventHandler(this.OnActiveDesignerChanged);
        this.mblnSunkEvent = true;
      }
      if (eventPropertyService == null && this.mobjCurrentHost != null)
        eventPropertyService = (IEventBindingService) this.mobjCurrentHost.GetService(typeof (IEventBindingService));
      if (eventPropertyService == null && obj is IComponent)
      {
        ISite site = ((IComponent) obj).Site;
        if (site != null)
          eventPropertyService = (IEventBindingService) site.GetService(typeof (IEventBindingService));
      }
      if (eventPropertyService == null && objContext != null)
        eventPropertyService = (IEventBindingService) objContext.GetService(typeof (IEventBindingService));
      return eventPropertyService;
    }

    /// <summary>Gets all the properties of the event tab that match the specified attributes.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
    /// <param name="arrAttributes">An array of <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
    /// <param name="objComponent">The component to retrieve the properties of. </param>
    public override PropertyDescriptorCollection GetProperties(
      object objComponent,
      Attribute[] arrAttributes)
    {
      return this.GetProperties((ITypeDescriptorContext) null, objComponent, arrAttributes);
    }

    /// <summary>Gets all the properties of the event tab that match the specified attributes and context.</summary>
    /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain context information. </param>
    /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
    /// <param name="objComponent">The component to retrieve the properties of. </param>
    public override PropertyDescriptorCollection GetProperties(
      ITypeDescriptorContext objContext,
      object objComponent,
      Attribute[] arrAttributes)
    {
      IEventBindingService eventPropertyService = this.GetEventPropertyService(objComponent, objContext);
      if (eventPropertyService == null)
        return new PropertyDescriptorCollection((PropertyDescriptor[]) null);
      EventDescriptorCollection events = TypeDescriptor.GetEvents(objComponent, arrAttributes);
      PropertyDescriptorCollection properties1 = eventPropertyService.GetEventProperties(events);
      Attribute[] attributeArray = new Attribute[arrAttributes.Length + 1];
      Array.Copy((Array) arrAttributes, 0, (Array) attributeArray, 0, arrAttributes.Length);
      attributeArray[arrAttributes.Length] = (Attribute) DesignerSerializationVisibilityAttribute.Content;
      PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(objComponent, attributeArray);
      if (properties2.Count > 0)
      {
        ArrayList arrayList = (ArrayList) null;
        for (int index = 0; index < properties2.Count; ++index)
        {
          PropertyDescriptor oldPropertyDescriptor = properties2[index];
          if (oldPropertyDescriptor.Converter.GetPropertiesSupported() && TypeDescriptor.GetEvents(oldPropertyDescriptor.GetValue(objComponent), arrAttributes).Count > 0)
          {
            if (arrayList == null)
              arrayList = new ArrayList();
            PropertyDescriptor property = TypeDescriptor.CreateProperty(oldPropertyDescriptor.ComponentType, oldPropertyDescriptor, (Attribute) MergablePropertyAttribute.No);
            arrayList.Add((object) property);
          }
        }
        if (arrayList != null)
        {
          PropertyDescriptor[] sourceArray = new PropertyDescriptor[arrayList.Count];
          arrayList.CopyTo((Array) sourceArray, 0);
          PropertyDescriptor[] propertyDescriptorArray = new PropertyDescriptor[properties1.Count + sourceArray.Length];
          properties1.CopyTo((Array) propertyDescriptorArray, 0);
          Array.Copy((Array) sourceArray, 0, (Array) propertyDescriptorArray, properties1.Count, sourceArray.Length);
          properties1 = new PropertyDescriptorCollection(propertyDescriptorArray);
        }
      }
      return properties1;
    }

    private void OnActiveDesignerChanged(object sender, ActiveDesignerEventArgs adevent) => this.mobjCurrentHost = adevent.NewDesigner;

    /// <summary>Gets the Help keyword for the tab.</summary>
    /// <returns>The Help keyword for the tab.</returns>
    public override string HelpKeyword => "Events";

    /// <summary>Gets the name of the tab.</summary>
    /// <returns>The name of the tab.</returns>
    public override string TabName => Gizmox.WebGUI.Forms.SR.GetString("PBRSToolTipEvents");
  }
}
