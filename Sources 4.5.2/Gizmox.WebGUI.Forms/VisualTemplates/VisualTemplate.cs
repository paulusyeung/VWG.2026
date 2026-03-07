using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{

    #if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    #endif
    [WebEditor(typeof(VisualTemplateEditor), typeof(WebUITypeEditor))]
    [TypeConverter(typeof(VisualTemplatesTypeConverter))]
    [Serializable]
    public abstract class VisualTemplate : ISkinable
    {
        /// <summary>
        /// Renders the specified object context.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        public virtual void Render(IContext objContext, IAttributeWriter objWriter)
        {
            objWriter.WriteAttributeString(WGAttributes.VisualTemplate, this.VisualTemplateName);
        }

        /// <summary>
        /// Gets the constroctor arguments. (For TypeConverter)
        /// </summary>
        /// <returns></returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual object[] GetConsturctorArguments()
        {
            return new object[0];
        }

        /// <summary>
        /// Gets the constroctor types. (For TypeConverter)
        /// </summary>
        public virtual Type[] GetConstructorTypes()
        {
            return new Type[0];
        }

        public virtual VisualTemplate GetDefault(Control objControl)
        {
            return null;
        }

        /// <summary>
        /// Gets the name of the visual template.
        /// </summary>
        /// <value>
        /// The name of the visual template.
        /// </value>
        [Browsable(false)]
        public abstract string VisualTemplateName
        {
            get;
        }

        /// <summary>
        /// Gets the visualizer image.
        /// </summary>
        /// <value>
        /// The visualizer image.
        /// </value>
        [Browsable(false)]
        public virtual Common.Resources.ResourceHandle VisualizerImage
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the visualizer default image.
        /// </summary>
        /// <value>
        /// The visualizer default image.
        /// </value>
        internal static Common.Resources.ResourceHandle VisualizerDefaultImage
        {
            get
            {
                return new SkinResourceHandle(typeof(ControlSkin), "VisualTemplate_None.png");
            }
        }
                
        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>
        /// The theme related to the skinable component.
        /// </value>
        [Browsable(false)]
        public string Theme
        {
            get
            {
                // Only if in design-time and not apply selected theme
                if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
                {
                    return "Default";
                }
                else
                {
                    if (VWGContext.Current != null)
                    {
                        return VWGContext.Current.CurrentTheme;
                    }

                    return ConfigHelper.SelectedTheme;
                }
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        internal virtual string ConvertToString()
        {
            return string.Format("{0}, {1}", this.GetType().FullName, this.GetType().Assembly.GetName().Name);
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="objVisualTemplateValues">The object visual template values.</param>
        internal virtual void ConvertFromString(List<string> objVisualTemplateValues)
        {
            
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The object event.</param>
        protected internal virtual void FireEvent(Control objControl, IEvent objEvent)
        {

        }
    }

    /// <summary>
    /// Type converter for the draggable option object.
    /// </summary>
    [Serializable()]
    public class VisualTemplatesTypeConverter : TypeConverter
    {
        /// <summary>
        /// Converts the specified objValue object to an enumeration object.
        /// </summary>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            bool blnResult = base.CanConvertFrom(context, destinationType);
            return blnResult;
        }

        /// <summary>
        /// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
        /// </summary>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
            {
                return true;
            }

            bool blnResult = base.CanConvertTo(context, destinationType);
            return blnResult;
        }

        /// <summary>
        /// converts from string to the object.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="culture"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string strValue = (string)value;

                if (!string.IsNullOrEmpty(strValue))
                {
                    string[] arrValues = strValue.Split('|');

                    List<string> arrVisualTemplateValues = new List<string>();

                    for(int index = 1; index < arrValues.Length; index++)
                    {
                        arrVisualTemplateValues.Add(arrValues[index]);
                    }
                    
                    VisualTemplate objVisualTemplate = GetVisualTemplateObjectFromString(arrValues[0],arrVisualTemplateValues);
                    return objVisualTemplate;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }


        /// <summary>
        /// Converts the given objValue object to the specified destination type.
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                object objInstanceDescriptor = ConvertToInstanceDescriptor(context, value);
                return objInstanceDescriptor;
            }
            else if (destinationType == typeof(string))
            {
                return ConvertToString(context, value);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// converts the object to string.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private new string ConvertToString(ITypeDescriptorContext objContext, object value)
        {
            VisualTemplate objVisualTemplate = value as VisualTemplate;
            if (objVisualTemplate != null)
            {
                return objVisualTemplate.ConvertToString();
            }
            return "";
        }

        /// <summary>
        /// gives the InstanceDescriptor of the object
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
        {
            VisualTemplate objVisualTemplate = value as VisualTemplate;
            object[] arrArguments = objVisualTemplate.GetConsturctorArguments();
            Type[] objTypes = objVisualTemplate.GetConstructorTypes();
            ConstructorInfo objConsrutorInfo = objVisualTemplate.GetType().GetConstructor(objTypes);
            return new InstanceDescriptor(objConsrutorInfo, arrArguments);
        }


        /// <summary>
        /// Gets the visual effect object from string.
        /// </summary>
        /// <param name="strVisualEffectType">Name of the STR visual effect.</param>
        /// <param name="strVisualEffectValue">The STR visual effect objValue.</param>
        /// <returns></returns>
        protected virtual VisualTemplate GetVisualTemplateObjectFromString(string strVisualTypeType, List<string> objVisualTemplateValues)
        {
            VisualTemplate objVisualTemplate = null;
            
            // Sertting the full type name that will be checked
            string strVisualTemplateFullType = strVisualTypeType;

            string[] arrControlType = strVisualTypeType.Split(',');
            if (arrControlType.Length > 1)
            {
                strVisualTemplateFullType = string.Format("{0}, {1}", arrControlType[0], CommonUtils.GetFullAssemblyName(arrControlType[1].Trim()));                
            }

            Type objVisualTemplateType = Type.GetType(strVisualTemplateFullType);
            if (objVisualTemplateType != null)
            {
                objVisualTemplate = Activator.CreateInstance(objVisualTemplateType) as VisualTemplate;
                if (objVisualTemplate != null)
                {
                    objVisualTemplate.ConvertFromString(objVisualTemplateValues);
                }
            }

            return objVisualTemplate;
        }
    }
}
