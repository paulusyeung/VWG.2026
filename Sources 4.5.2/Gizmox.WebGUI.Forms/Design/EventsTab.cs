using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Design
{


    /// <summary>Provides a <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> that can display events for selection and linking.</summary>

    [Serializable()]
    public class EventsTab : PropertyTab
    {
        private IDesignerHost mobjCurrentHost;
        private IServiceProvider mobjServiceProvider;
        private bool mblnSunkEvent;

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.EventsTab"></see> class.</summary>
        /// <param name="objServiceProvider">An <see cref="T:System.IServiceProvider"></see> to use. </param>
        public EventsTab(IServiceProvider objServiceProvider)
        {
            this.mobjServiceProvider = objServiceProvider;
        }

        /// <summary>Gets a value indicating whether the specified object can be extended.</summary>
        /// <returns>true if the specified object can be extended; otherwise, false.</returns>
        /// <param name="objExtendee">The object to test for extensibility. </param>
        public override bool CanExtend(object objExtendee)
        {
            return !Marshal.IsComObject(objExtendee);
        }

        /// <summary>Gets the default property from the specified object.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> indicating the default property.</returns>
        /// <param name="obj">The object to retrieve the default property of. </param>
        public override PropertyDescriptor GetDefaultProperty(object obj)
        {
            IEventBindingService objService = this.GetEventPropertyService(obj, null);
            if (objService != null)
            {
                EventDescriptor descriptor1 = TypeDescriptor.GetDefaultEvent(obj);
                if (descriptor1 != null)
                {
                    return objService.GetEventProperty(descriptor1);
                }
            }
            return null;
        }

        private IEventBindingService GetEventPropertyService(object obj, ITypeDescriptorContext objContext)
        {
            IEventBindingService objService1 = null;
            if (!this.mblnSunkEvent)
            {
                IDesignerEventService objService2 = (IDesignerEventService)this.mobjServiceProvider.GetService(typeof(IDesignerEventService));
                if (objService2 != null)
                {
                    objService2.ActiveDesignerChanged += new ActiveDesignerEventHandler(this.OnActiveDesignerChanged);
                }
                this.mblnSunkEvent = true;
            }
            if ((objService1 == null) && (this.mobjCurrentHost != null))
            {
                objService1 = (IEventBindingService) this.mobjCurrentHost.GetService(typeof(IEventBindingService));
            }
            if ((objService1 == null) && (obj is IComponent))
            {
                ISite objSite = ((IComponent)obj).Site;
                if (objSite != null)
                {
                    objService1 = (IEventBindingService)objSite.GetService(typeof(IEventBindingService));
                }
            }
            if ((objService1 == null) && (objContext != null))
            {
                objService1 = (IEventBindingService) objContext.GetService(typeof(IEventBindingService));
            }
            return objService1;
        }

        /// <summary>Gets all the properties of the event tab that match the specified attributes.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
        /// <param name="arrAttributes">An array of <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
        /// <param name="objComponent">The component to retrieve the properties of. </param>
        public override PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes)
        {
            return this.GetProperties(null, objComponent, arrAttributes);
        }

        /// <summary>Gets all the properties of the event tab that match the specified attributes and context.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties. This will be an empty <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> if the component does not implement an event service.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain context information. </param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the event properties to retrieve. </param>
        /// <param name="objComponent">The component to retrieve the properties of. </param>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
        {
            IEventBindingService objService1 = this.GetEventPropertyService(objComponent, objContext);
            if (objService1 == null)
            {
                return new PropertyDescriptorCollection(null);
            }
            EventDescriptorCollection objCollection1 = TypeDescriptor.GetEvents(objComponent, arrAttributes);
            PropertyDescriptorCollection objCollection2 = objService1.GetEventProperties(objCollection1);
            Attribute[] arrAttributeArray1 = new Attribute[arrAttributes.Length + 1];
            Array.Copy(arrAttributes, 0, arrAttributeArray1, 0, arrAttributes.Length);
            arrAttributeArray1[arrAttributes.Length] = DesignerSerializationVisibilityAttribute.Content;
            PropertyDescriptorCollection objCollection3 = TypeDescriptor.GetProperties(objComponent, arrAttributeArray1);
            if (objCollection3.Count > 0)
            {
                ArrayList objList = null;
                for (int num1 = 0; num1 < objCollection3.Count; num1++)
                {
                    PropertyDescriptor objPropertyDescriptor1 = objCollection3[num1];
                    if (objPropertyDescriptor1.Converter.GetPropertiesSupported())
                    {
                        object obj1 = objPropertyDescriptor1.GetValue(objComponent);
                        EventDescriptorCollection objCollection4 = TypeDescriptor.GetEvents(obj1, arrAttributes);
                        if (objCollection4.Count > 0)
                        {
                            if (objList == null)
                            {
                                objList = new ArrayList();
                            }
                            objPropertyDescriptor1 = TypeDescriptor.CreateProperty(objPropertyDescriptor1.ComponentType, objPropertyDescriptor1, new Attribute[] { MergablePropertyAttribute.No });
                            objList.Add(objPropertyDescriptor1);
                        }
                    }
                }
                if (objList != null)
                {
                    PropertyDescriptor[] arrDescriptors1 = new PropertyDescriptor[objList.Count];
                    objList.CopyTo(arrDescriptors1, 0);
                    PropertyDescriptor[] arrDescriptors2 = new PropertyDescriptor[objCollection2.Count + arrDescriptors1.Length];
                    objCollection2.CopyTo(arrDescriptors2, 0);
                    Array.Copy(arrDescriptors1, 0, arrDescriptors2, objCollection2.Count, arrDescriptors1.Length);
                    objCollection2 = new PropertyDescriptorCollection(arrDescriptors2);
                }
            }
            return objCollection2;
        }

        private void OnActiveDesignerChanged(object sender, ActiveDesignerEventArgs adevent)
        {
            this.mobjCurrentHost = adevent.NewDesigner;
        }


        /// <summary>Gets the Help keyword for the tab.</summary>
        /// <returns>The Help keyword for the tab.</returns>
        public override string HelpKeyword
        {
            get
            {
                return "Events";
            }
        }

        /// <summary>Gets the name of the tab.</summary>
        /// <returns>The name of the tab.</returns>
        public override string TabName
        {
            get
            {
                return SR.GetString("PBRSToolTipEvents");
            }
        }
    }
}

