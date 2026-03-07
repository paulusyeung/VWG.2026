using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Represents a small rectangular pop-up window that displays a brief description of a control's purpose when the user rests the pointer on the control.
    /// </summary>
    [ProvideProperty("ToolTip", typeof(Control))]
    [SRDescription("DescriptionToolTip")]
    [ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ToolTip), "ToolTip_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ToolTip), "ToolTip.bmp")]
#endif
    [TypeDescriptionProvider(typeof(ToolTipTypeDescriptionProvider)), Skin(typeof(ToolTipSkin))]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require), Serializable()]
    public class ToolTip : ComponentBase, IExtenderProvider, ISkinable
    {
        #region ToolTipTypeDescriptionProvider Class

        /// <summary>
        /// 
        /// </summary>
        private class ToolTipTypeDescriptionProvider : TypeDescriptionProvider
        {
            #region ComponentBaseTypeDelegator Class

            /// <summary>
            /// 
            /// </summary>
            class ToolTipTypeDelegator : TypeDelegator
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="ToolTipTypeDelegator"/> class.
                /// </summary>
                /// <param name="objDelegatingType">Type of the obj delegating.</param>
                public ToolTipTypeDelegator(Type objDelegatingType)
                    : base(objDelegatingType)
                {
                }

                /// <summary>
                /// Gets the attributes assigned to the TypeDelegator.
                /// </summary>
                /// <returns>
                /// A TypeAttributes object representing the implementation attribute flags.
                /// </returns>
                protected override TypeAttributes GetAttributeFlagsImpl()
                {
                    return (base.GetAttributeFlagsImpl() & ~TypeAttributes.Serializable);
                }
            }

            #endregion

            /// <summary>
            ///  Static that holds a default type provider of a component base.
            /// </summary>
            private static TypeDescriptionProvider mobjDefaultTypeProvider = TypeDescriptor.GetProvider(typeof(ComponentBase));

            /// <summary>
            /// Initializes a new instance of the <see cref="ToolTipTypeDescriptionProvider"/> class.
            /// </summary>
            public ToolTipTypeDescriptionProvider()
                : base(mobjDefaultTypeProvider)
            {
            }

            /// <summary>
            /// Gets the type of the reflection.
            /// </summary>
            /// <param name="objObjectType">Type of the obj object.</param>
            /// <param name="objInstance">The obj instance.</param>
            /// <returns></returns>
            public override Type GetReflectionType(Type objObjectType, object objInstance)
            {
                // cst recieved instance to a component base.
                ComponentBase objComponentBase = objInstance as ComponentBase;
                if (objComponentBase != null)
                {
                    // Check if recieved component is in design mode.
                    if (objComponentBase.Site != null && objComponentBase.Site.DesignMode)
                    {
                        // Return a component base type delegator.
                        return new ToolTipTypeDelegator(objObjectType);
                    }
                }

                return base.GetReflectionType(objObjectType, objInstance);
            }
        }

        #endregion ToolTipTypeDescriptionProvider Class

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> without a specified container.
        /// </summary>
        public ToolTip()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> class with a specified container.
        /// </summary>
        ///	<param name="objContainer">An <see cref="T:System.ComponentModel.IContainer"></see> that represents the container of the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see>. </param>
        public ToolTip(IContainer objContainer)
        {
            objContainer.Add(this);
        }

        #endregion C'tors

        #region ToolTip Property Extension

        /// <summary>
        /// Associates ToolTip text with the specified control.
        /// </summary>
        ///	<param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to associate the ToolTip text with. </param>
        ///	<param name="strCaption">The ToolTip text to display when the pointer is on the control. </param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void SetToolTip(Control objControl, string strCaption)
        {
            if (objControl != null)
            {
                objControl.ToolTip = strCaption;
            }
        }

        /// <summary>Retrieves the ToolTip text associated with the specified control.</summary>
        /// <returns>A <see cref="T:System.String"></see> containing the ToolTip text for the specified control.</returns>
        /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> for which to retrieve the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text. </param>
        /// <filterpriority>1</filterpriority>
        [DefaultValue("")]
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#elif WG_NET2 || WG_NET35 
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        [Localizable(true), SRDescription("ToolTipToolTipDescr")]
        public string GetToolTip(Control objControl)
        {
            return (objControl != null) ? objControl.ToolTip : "";
        }

        #endregion

        #region Serializable Properties

        /// <summary>
        /// The Active property registration.
        /// </summary>
        private static SerializableProperty ActiveProperty = SerializableProperty.Register("Active", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

        /// <summary>
        /// The IsBalloon property registration.
        /// </summary>
        private static SerializableProperty IsBalloonProperty = SerializableProperty.Register("IsBalloon", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

        /// <summary>
        /// The AutoPopDelay property registration.
        /// </summary>
        private static SerializableProperty AutoPopDelayProperty = SerializableProperty.Register("AutoPopDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(5000));

        /// <summary>
        /// The InitialDelay property registration.
        /// </summary>
        private static SerializableProperty InitialDelayProperty = SerializableProperty.Register("InitialDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(0));

        /// <summary>
        /// The ReshowDelay property registration.
        /// </summary>
        private static SerializableProperty ReshowDelayProperty = SerializableProperty.Register("ReshowDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(0));
        /// <summary>
        /// The ToolTipTitle property registration.
        /// </summary>
        private static SerializableProperty ToolTipTitleProperty = SerializableProperty.Register("ToolTipTitle", typeof(string), typeof(ToolTip), new SerializablePropertyMetadata(string.Empty));
        /// <summary>
        /// The ToolTipIcon property registration.
        /// </summary>
        private static SerializableProperty ToolTipIconProperty = SerializableProperty.Register("ToolTipIcon", typeof(ToolTipIcon), typeof(ToolTip), new SerializablePropertyMetadata(default(ToolTipIcon)));
        /// <summary>
        /// The AutomaticDelay property registration.
        /// </summary>
        private static SerializableProperty AutomaticDelayProperty = SerializableProperty.Register("AutomaticDelay", typeof(int), typeof(ToolTip), new SerializablePropertyMetadata(500));

        /// <summary>
        /// The ShowAlways property registration.
        /// </summary>
        private static SerializableProperty ShowAlwaysProperty = SerializableProperty.Register("ShowAlways", typeof(bool), typeof(ToolTip), new SerializablePropertyMetadata(true));

        #endregion Serializable Properties

        #region Obsolete

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ToolTip"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Active
        {
            get
            {
                return this.GetValue<bool>(ToolTip.ActiveProperty);
            }
            set
            {
                this.SetValue<bool>(ToolTip.ActiveProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is balloon.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is balloon; otherwise, <c>false</c>.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(false), SRDescription("ToolTipIsBalloonDescr")]
        public bool IsBalloon
        {
            get
            {
                return this.GetValue<bool>(ToolTip.IsBalloonProperty);
            }
            set
            {
                this.SetValue<bool>(ToolTip.IsBalloonProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the period of time the ToolTip remains visible if the pointer is stationary on a control with specified ToolTip text
        /// </summary>
        /// <value>
        /// The period of time, in milliseconds, that the ToolTip remains visible when the pointer is stationary on a control. The default value is 5000.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [RefreshProperties(RefreshProperties.All), SRDescription("ToolTipAutoPopDelayDescr")]
        public int AutoPopDelay
        {
            get
            {
                return this.GetValue<int>(ToolTip.AutoPopDelayProperty);
            }
            set
            {
                this.SetValue<int>(ToolTip.AutoPopDelayProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the time that passes before the ToolTip appears.
        /// </summary>
        /// <value>
        /// The period of time, in milliseconds, that the pointer must remain stationary on a control before the ToolTip window is displayed.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ToolTipInitialDelayDescr"), RefreshProperties(RefreshProperties.All)]
        public int InitialDelay
        {
            get
            {
                return this.GetValue<int>(ToolTip.InitialDelayProperty);
            }
            set
            {
                this.SetValue<int>(ToolTip.InitialDelayProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the length of time that must transpire before subsequent ToolTip windows appear as the pointer moves from one control to another.
        /// </summary>
        /// <value>
        /// The length of time, in milliseconds, that it takes subsequent ToolTip windows to appear.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ToolTipReshowDelayDescr"), RefreshProperties(RefreshProperties.All)]
        public int ReshowDelay
        {
            get
            {
                return this.GetValue<int>(ToolTip.ReshowDelayProperty);
            }
            set
            {
                this.SetValue<int>(ToolTip.ReshowDelayProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a title for the ToolTip window.
        /// </summary>
        /// <value>
        /// A String containing the window title.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(""), SRDescription("ToolTipTitleDescr")]
        public string ToolTipTitle
        {
            get
            {
                return this.GetValue<string>(ToolTip.ToolTipTitleProperty);
            }
            set
            {
                this.SetValue<string>(ToolTip.ToolTipTitleProperty, value);
            }
        }

        /// <summary>
        ///Gets or sets a value that defines the type of icon to be displayed alongside the ToolTip text.
        /// </summary>
        /// <value>
        /// One of the Gizmox.WebGUI.Forms.ToolTipIcon enumerated values.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(0), SRDescription("ToolTipToolTipIconDescr")]
        public ToolTipIcon ToolTipIcon
        {
            get
            {
                return this.GetValue<ToolTipIcon>(ToolTip.ToolTipIconProperty);
            }
            set
            {
                this.SetValue<ToolTipIcon>(ToolTip.ToolTipIconProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the automatic delay for the ToolTip.
        /// </summary>
        /// <value>
        /// The automatic delay, in milliseconds. The default is 500.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [RefreshProperties(RefreshProperties.All), SRDescription("ToolTipAutomaticDelayDescr"), DefaultValue(500)]
        public int AutomaticDelay
        {
            get
            {
                return this.GetValue<int>(ToolTip.AutomaticDelayProperty);
            }
            set
            {
                this.SetValue<int>(ToolTip.AutomaticDelayProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a ToolTip window is displayed, even when its parent control is not active.
        /// </summary>
        /// <value>
        ///   true if the ToolTip is always displayed; otherwise, false. The default is false.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRDescription("ToolTipShowAlwaysDescr"), DefaultValue(false)]
        public bool ShowAlways
        {
            get
            {
                return this.GetValue<bool>(ToolTip.ShowAlwaysProperty);
            }
            set
            {
                this.SetValue<bool>(ToolTip.ShowAlwaysProperty, value);
            }
        }

        #endregion

        #region ISkinable

        string ISkinable.Theme
        {
            get { return VWGContext.Current.CurrentTheme; }
        }

        #endregion

        #region IExtenderProvider Members

        /// <summary>
        /// Returns true if the ToolTip can offer an extender property to the specified target component.
        /// </summary>
        /// <param name="objTarget">The target.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can extend the specified target; otherwise, <c>false</c>.
        /// </returns>
        public bool CanExtend(object objTarget)
        {
            return ((objTarget is Control) && !(objTarget is ToolTip));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the name of the extended tool tip template.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns></returns>
        protected string GetExtendedToolTipTemplateName(Control objControl)
        {
            if (objControl != null)
            {
                string strToolTipKey = this.ToolTipKey;

                // Get control's tooltip descriptor
                ToolTipDescriptor objToolTipDescriptor = objControl.ExtendedToolTipDescriptor;

                // If control's tooltip descriptor complies tooltip type..
                if (objToolTipDescriptor != null && objToolTipDescriptor.ToolTipKey == strToolTipKey)
                {
                    // Get its template name
                    return objToolTipDescriptor.ToolTipTemplateName;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the name of the extended tool tip template.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="strValue">The STR value.</param>
        protected void SetExtendedToolTipTemplateName(Control objControl, string strValue)
        {
            if (objControl != null)
            {
                string strToolTipKey = this.ToolTipKey;

                // Get control's tooltip descriptor
                ToolTipDescriptor objToolTipDescriptor = objControl.ExtendedToolTipDescriptor;

                if (objToolTipDescriptor == null)
                {
                    // Create new descriptor, if does not exist.
                    objToolTipDescriptor = new ToolTipDescriptor(strToolTipKey);
                }

                // Get its extended properties
                Dictionary<string, string> arrExtendedProperties = objToolTipDescriptor.ExtendedProperties;

                // If descriptor key does not comply to current key..
                if (objToolTipDescriptor.ToolTipKey != strToolTipKey)
                {
                    // Clear properties.
                    arrExtendedProperties.Clear();

                    // Set current key.
                    objToolTipDescriptor.ToolTipKey = strToolTipKey;
                }

                // Set template name.
                objToolTipDescriptor.ToolTipTemplateName = strValue;

                // Apply descriptor to control.
                objControl.ExtendedToolTipDescriptor = objToolTipDescriptor;

                // Update params.
                objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
            }
        }

        /// <summary>
        /// Gets the extended tool tip property.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="strPropertyName">Name of the STR property.</param>
        /// <returns></returns>
        protected string GetExtendedToolTipProperty(Control objControl, string strPropertyName)
        {
            if (objControl != null)
            {
                string strToolTipKey = this.ToolTipKey;

                // Get control's tooltip descriptor
                ToolTipDescriptor objToolTipDescriptor = objControl.ExtendedToolTipDescriptor;

                // If control's tooltip descriptor complies tooltip type..
                if (objToolTipDescriptor != null && objToolTipDescriptor.ToolTipKey == strToolTipKey)
                {
                    // Get its extended properties
                    Dictionary<string, string> arrExtendedProperties = objToolTipDescriptor.ExtendedProperties;

                    // If property exists
                    if (arrExtendedProperties.ContainsKey(strPropertyName))
                    {
                        // Get its value.
                        return arrExtendedProperties[strPropertyName];
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the extended tool tip property.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="strPropertyName">The STR key.</param>
        /// <param name="strValue">The STR value.</param>
        protected void SetExtendedToolTipProperty(Control objControl, string strPropertyName, string strValue)
        {
            if (objControl != null)
            {
                string strToolTipKey = this.ToolTipKey;

                // Get control's tooltip descriptor
                ToolTipDescriptor objToolTipDescriptor = objControl.ExtendedToolTipDescriptor;

                if (objToolTipDescriptor == null)
                {
                    // Create new descriptor, if does not exist.
                    objToolTipDescriptor = new ToolTipDescriptor(strToolTipKey);
                }

                // Get its extended properties
                Dictionary<string, string> arrExtendedProperties = objToolTipDescriptor.ExtendedProperties;

                // If descriptor key does not comply to current key..
                if (objToolTipDescriptor.ToolTipKey != strToolTipKey)
                {
                    // Clear properties.
                    arrExtendedProperties.Clear();

                    // Set current key.
                    objToolTipDescriptor.ToolTipKey = strToolTipKey;
                }

                // If property exists
                if (arrExtendedProperties.ContainsKey(strPropertyName))
                {
                    // Update its value
                    arrExtendedProperties[strPropertyName] = strValue;
                }
                else
                {
                    // Otherwise, add it.
                    arrExtendedProperties.Add(strPropertyName, strValue);
                }

                // Apply descriptor to control.
                objControl.ExtendedToolTipDescriptor = objToolTipDescriptor;

                // Update params.
                objControl.UpdateParamsInternal(AttributeType.ExtendedToolTip);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the tool tip key. Identifies tooltip on client.
        /// </summary>
        protected virtual string ToolTipKey
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ToolTipDescriptor
    {
        #region Members

        private string mstrToolTipKey;
        private string mstrToolTipTemplateName;
        private Dictionary<string, string> marrExtendedProperties;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the tool tip key.
        /// </summary>
        /// <value>
        /// The tool tip key.
        /// </value>
        public string ToolTipKey
        {
            get { return mstrToolTipKey; }
            set { mstrToolTipKey = value; }
        }

        /// <summary>
        /// Gets the extended properties.
        /// </summary>
        /// <value>
        /// The extended properties.
        /// </value>
        public Dictionary<string, string> ExtendedProperties
        {
            get
            {
                if (marrExtendedProperties == null)
                {
                    marrExtendedProperties = new Dictionary<string, string>();
                }
                return marrExtendedProperties;
            }
        }

        /// <summary>
        /// Gets the serialized properties.
        /// </summary>
        public string SerializedProperties
        {
            get
            {
                StringBuilder objStringBuilder = new StringBuilder(string.Empty);

                // Define separators
                string strKeyValueSeparator = "_VWG_KVS_";
                string strEntrySeparator = string.Empty;

                // Iterate through collection and write separated values.
                foreach (string strKey in this.marrExtendedProperties.Keys)
                {
                    objStringBuilder.AppendFormat("{0}{1}{2}{3}", strEntrySeparator, strKey, strKeyValueSeparator, this.marrExtendedProperties[strKey]);
                    strEntrySeparator = "_VWG_ETT_";
                }

                return objStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the name of the tool tip template.
        /// </summary>
        /// <value>
        /// The name of the tool tip template.
        /// </value>
        public string ToolTipTemplateName
        {
            get { return mstrToolTipTemplateName; }
            set { mstrToolTipTemplateName = value; }
        }

        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolTipDescriptor"/> class.
        /// </summary>
        /// <param name="strToolTipKey">The STR tool tip key.</param>
        public ToolTipDescriptor(string strToolTipKey)
        {
            mstrToolTipKey = strToolTipKey;
        }

        #endregion C'tors
    }
}
