#region Using

using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Serialization;
using System.Globalization;
using System.Drawing.Imaging;
using Gizmox.WebGUI.Forms.Client;
using System.Drawing.Design;
using Gizmox.WebGUI.Common.Configuration;
using System.Text;
using Gizmox.WebGUI.Forms.Design;
using System.Collections.ObjectModel;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region MethodInvoker Delegate

    /// <summary>
    /// Represents a delegate that can execute any method in managed code that is declared void and takes no parameters. 
    /// </summary>
    public delegate void MethodInvoker();

    #endregion

    #region ControlEventArgs Class

    /// <summary>
    /// Represents the method that will handle the ControlAdded and ControlRemoved events of the Control class.
    /// </summary>
    public delegate void ControlEventHandler(object sender, ControlEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ControlsEventArgs"/> instance containing the event data.</param>
    public delegate void ControlsEventHandler(object sender, ControlsEventArgs e);

    /// <summary>
    /// Control event arguments
    /// </summary>
    [Serializable()]
    public class ControlsEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private Control[] mobjControl;

        /// <summary>
        /// Creates a new <see cref="ControlsEventArgs"/> instance.
        /// </summary>
        /// <param name="objControl">control.</param>
        public ControlsEventArgs(Control[] objControl)
        {
            mobjControl = objControl;
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value></value>
        public Control[] Controls
        {
            get
            {
                return mobjControl;
            }
        }
    }

    /// <summary>
    /// Control event arguments
    /// </summary>
    [Serializable()]
    public class ControlEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private Control mobjControl;

        /// <summary>
        /// Creates a new <see cref="ControlEventArgs"/> instance.
        /// </summary>
        /// <param name="objControl">control.</param>
        public ControlEventArgs(Control objControl)
        {
            mobjControl = objControl;
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <value></value>
        public Control Control
        {
            get
            {
                return mobjControl;
            }
        }
    }

    #endregion

    #region Control Class

    /// <summary>
    /// The base class for all positioned GUI elements
    /// </summary>
    [System.ComponentModel.DefaultEvent("Click")]
    [System.ComponentModel.ToolboxItem(false)]
#if WG_NET46
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET452
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET451
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET45
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET40
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET35
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#elif WG_NET2
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#else
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
#endif
    [System.ComponentModel.ToolboxItemFilter("Gizmox.WebGUI.Forms", System.ComponentModel.ToolboxItemFilterType.Require)]
    [Skin(typeof(ControlSkin))]
    [Serializable()]
    [ProxyComponent(typeof(ProxyControl))]
    [ContextualToolbar.ContextualToolbar(typeof(ContextualToolbar.ContextualToolbar))]
    public class Control : Component, IControl, IBindableComponent, IArrangedElement, IRenderableComponent, IObservableLayoutItem, ISkinable
    {
        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to DataBindings property.
        /// </summary>
        private static SerializableProperty DataBindingsProperty = SerializableProperty.Register("DataBindings", typeof(ControlBindingsCollection), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to BindingContext property.
        /// </summary>
        private static SerializableProperty BindingContextProperty = SerializableProperty.Register("BindingContext", typeof(BindingContext), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to BorderStyle property.
        /// </summary>
        private static SerializableProperty BorderStyleProperty = SerializableProperty.Register("BorderStyle", typeof(BorderStyle), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Provides a property reference to BorderColor property.
        /// </summary>
        private static SerializableProperty BorderColorProperty = SerializableProperty.Register("BorderColor", typeof(BorderColor), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Provides a property reference to ErrorMessage property.
        /// </summary>
        private static SerializableProperty ErrorMessageProperty = SerializableProperty.Register("ErrorMessage", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to ErrorIcon property.
        /// </summary>
        private static SerializableProperty ErrorIconProperty = SerializableProperty.Register("ErrorIcon", typeof(ResourceHandle), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ErrorIconPadding property.
        /// </summary>
        private static SerializableProperty ErrorIconPaddingProperty = SerializableProperty.Register("ErrorIconPadding", typeof(int), typeof(Control), new SerializablePropertyMetadata(1));

        /// <summary>
        /// Provides a property reference to ErrorIconAlignment property.
        /// </summary>
        private static SerializableProperty ErrorIconAlignmentProperty = SerializableProperty.Register("ErrorIconAlignment", typeof(ErrorIconAlignment), typeof(Control), new SerializablePropertyMetadata(ErrorIconAlignment.TopRight));

        /// <summary>
        /// Provides a property reference to LayoutInfo property.
        /// </summary>
        internal static SerializableProperty LayoutInfoProperty = SerializableProperty.Register("LayoutInfo", typeof(TableLayout.LayoutInfo), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to ContainerInfo property.
        /// </summary>
        internal static SerializableProperty ContainerInfoProperty = SerializableProperty.Register("ContainerInfo", typeof(TableLayout.ContainerInfo), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Provides a property reference to BorderWidth property.
        /// </summary>
        private static SerializableProperty BorderWidthProperty = SerializableProperty.Register("BorderWidth", typeof(BorderWidth), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Provides a property reference to Cursor property.
        /// </summary>
        private static SerializableProperty CursorProperty = SerializableProperty.Register("Cursor", typeof(Cursor), typeof(Control), new SerializablePropertyMetadata(Cursors.Default));

        /// <summary>
        /// Provides a property reference to CustomStyle property.
        /// </summary>
        private static SerializableProperty CustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Provides a property reference to RightToLeft property.
        /// </summary>
        private static SerializableProperty RightToLeftProperty = SerializableProperty.Register("RightToLeft", typeof(RightToLeft), typeof(Control), new SerializablePropertyMetadata(RightToLeft.Inherit));


        /// <summary>
        /// Provides a property reference to AutoSizeMode property.
        /// </summary>
        private static SerializableProperty AutoSizeModeProperty = SerializableProperty.Register("AutoSizeMode", typeof(AutoSizeMode), typeof(Control), new SerializablePropertyMetadata(AutoSizeMode.GrowOnly));

        /// <summary>
        /// Provides a property reference to TextProperty property.
        /// </summary>
        private static readonly SerializableProperty TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register the BackgroundImageLayout property
        /// </summary>
        private static SerializableProperty BackgroundImageLayoutProperty = SerializableProperty.Register("BackgroundImageLayout", typeof(ImageLayout), typeof(Control), new SerializablePropertyMetadata(ImageLayout.Tile));

        /// <summary>
        /// Register the Margin property
        /// </summary>
        private static SerializableProperty MarginProperty = SerializableProperty.Register("Margin", typeof(Padding), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the Padding property
        /// </summary>
        private static SerializableProperty PaddingProperty = SerializableProperty.Register("Padding", typeof(Padding), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the ForeColor property
        /// </summary>
        private static SerializableProperty ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(Control), new SerializablePropertyMetadata(Color.Empty));

        /// <summary>
        /// Register the BackColor property
        /// </summary>
        private static SerializableProperty BackColorProperty = SerializableProperty.Register("BackColor", typeof(Color), typeof(Control), new SerializablePropertyMetadata(Color.Empty));

        /// <summary>
        /// Register the Theme property
        /// </summary>
        private static SerializableProperty ThemeProperty = SerializableProperty.Register("Theme", typeof(string), typeof(Control), new SerializablePropertyMetadata("Inherit"));

        /// <summary>
        /// Register the Font property
        /// </summary>
        private static SerializableProperty FontProperty = SerializableProperty.Register("Font", typeof(Font), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the ToolTip property
        /// </summary>
        private static SerializableProperty ToolTipProperty = SerializableProperty.Register("ToolTip", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register ExtendedToolTipDescriptor property.
        /// </summary>
        private static SerializableProperty ExtendedToolTipDescriptorProperty = SerializableProperty.Register("ExtendedToolTipDescriptor", typeof(ToolTipDescriptor), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the TagName property
        /// </summary>
        private static SerializableProperty TagNameProperty = SerializableProperty.Register("TagName", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register the Name property
        /// </summary>
        private static SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register the Accessible Name property
        /// </summary>
        private static SerializableProperty AccessibleNameProperty = SerializableProperty.Register("AccessibleName", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register the Accessible Description property
        /// </summary>
        private static SerializableProperty AccessibleDescriptionProperty = SerializableProperty.Register("AccessibleDescription", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));

        /// <summary>
        /// Register the MaximumSize property
        /// </summary>
        private static SerializableProperty MaximumSizeProperty = SerializableProperty.Register("MaximumSize", typeof(Size), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the MinimumSize property
        /// </summary>
        private static SerializableProperty MinimumSizeProperty = SerializableProperty.Register("MinimumSize", typeof(Size), typeof(Control), new SerializablePropertyMetadata());

        /// <summary>
        /// Register the KeyFilter property
        /// </summary>
        private static SerializableProperty KeyFilterProperty = SerializableProperty.Register("KeyFilter", typeof(KeyFilter), typeof(Control), new SerializablePropertyMetadata(KeyFilter.All));

        /// <summary>
        /// Register the ScrollTop property
        /// </summary>
        private static SerializableProperty ScrollTopProperty = SerializableProperty.Register("ScrollTop", typeof(int), typeof(Control), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Register the ScrollLeft property
        /// </summary>
        private static SerializableProperty ScrollLeftProperty = SerializableProperty.Register("ScrollLeft", typeof(int), typeof(Control), new SerializablePropertyMetadata(0));

        /// <summary>
        /// 
        /// </summary>
        private static SerializableProperty BackgroundImageProperty = SerializableProperty.Register("BackgroundImage", typeof(ResourceHandle), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Register the RegisteredTimers property
        /// </summary>
        private static SerializableProperty RegisteredTimersProperty = SerializableProperty.Register("RegisteredTimers", typeof(Timer[]), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Register the ImeMode property
        /// </summary>
        private static SerializableProperty ImeModeProperty = SerializableProperty.Register("ImeMode", typeof(ImeMode), typeof(Control), new SerializablePropertyMetadata(ImeMode.On));

        /// <summary>
        /// Register the ForceContentAvailabilityOnClient property
        /// </summary>
        private static SerializableProperty ForceContentAvailabilityOnClientProperty = SerializableProperty.Register("ForceContentAvailabilityOnClient", typeof(bool), typeof(Control), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Register the Draggable property
        /// </summary>
        private static SerializableProperty DraggableProperty = SerializableProperty.Register("Draggable", typeof(DraggableOptions), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Register the Resizable property
        /// </summary>
        private static SerializableProperty ResizableProperty = SerializableProperty.Register("Resizable", typeof(ResizableOptions), typeof(Control), new SerializablePropertyMetadata(null));

        /// <summary>
        /// Register the VisualTemplate
        /// </summary>
        private static SerializableProperty VisualTemplateProperty = SerializableProperty.Register("VisualTemplate", typeof(VisualTemplate), typeof(Control), new SerializablePropertyMetadata(null));

        #endregion

        #region ControlCollection Class

        /// <summary>
        /// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
        /// </summary>
#if WG_NET46
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
        [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [System.ComponentModel.ListBindable(false)]
        [Serializable()]
        public class ControlCollection : ArrangedElementCollection, IList, ICollection, System.Collections.IEnumerable, ICloneable, IObservableList
        {
            private int mintLastAccessedIndex;
            private Control mobjOwnerControl;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> class.
            /// </summary>
            /// <param name="owner">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> representing the control that owns the control collection.</param>
            /// <param name="blnReversed">if set to <c>true</c> [BLN reversed].</param>
            public ControlCollection(Control objOwnerControl, bool blnReversed)
            {
                this.mintLastAccessedIndex = -1;
                this.mobjOwnerControl = objOwnerControl;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ControlCollection"/> class.
            /// </summary>
            /// <param name="objOwnerControl">The owner.</param>
            public ControlCollection(Control objOwnerControl)
                : this(objOwnerControl, false)
            {
            }

            /// <summary>Adds the specified control to the control collection.</summary>
            /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
            /// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
            /// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
            public virtual void Add(Control objValue)
            {
                this.Add(objValue, true, -1);
            }

            /// <summary>
            /// Adds the specified control to the control collection.
            /// </summary>
            /// <param name="objNewControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection.</param>
            /// <param name="blnRegisterControl">if set to <c>true</c> [BLN is add range].</param>
            /// <param name="intIndex">Index for insertion.</param>
            /// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
            /// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
            protected virtual void Add(Control objNewControl, bool blnRegisterControl, int intIndex)
            {
                // Validate new control.
                if (objNewControl != null)
                {
                    // Enforce addition of a top level control.
                    if (objNewControl.GetTopLevel())
                    {
                        throw new ArgumentException(SR.GetString("TopLevelControlAdd"));
                    }

                    // Check parent cycling.
                    Control.CheckParentingCycle(this.mobjOwnerControl, objNewControl);

                    // Check if new control is already a child of the owner control.
                    if (objNewControl.Parent == this.mobjOwnerControl &&
                        this.Contains(objNewControl))
                    {
                        // Send new control to back.
                        objNewControl.SendToBack();
                    }
                    else
                    {
                        // Check if new control has a parent.
                        if (objNewControl.Parent != null)
                        {
                            // Remove new control from its current parent.
                            objNewControl.Parent.Controls.Remove(objNewControl);
                        }

                        // Cehck if an insertion is required.
                        if (intIndex >= 0)
                        {
                            // Perform inner insertion.
                            base.InnerList.Insert(intIndex, objNewControl);
                        }
                        else
                        {
                            // Perform inner addition.
                            base.InnerList.Add(objNewControl);
                        }

                        // Check if new control does not have a tab index.
                        if (objNewControl.mintTabIndex == -1)
                        {
                            // Define a new tab index integer.
                            int intNewTabIndex = 0;

                            // Loop all contained controls.
                            for (int num2 = 0; num2 < (this.Count - 1); num2++)
                            {
                                // Get current control tab index.
                                int intCurrentTabIndex = this[num2].TabIndex;

                                // Check if current tab index is bigger then the new one.
                                if (intNewTabIndex <= intCurrentTabIndex)
                                {
                                    // Set the new tab index to be the maximal detected so far.
                                    intNewTabIndex = intCurrentTabIndex + 1;
                                }
                            }

                            // Set the new control's tab index.
                            objNewControl.mintTabIndex = intNewTabIndex;
                        }

                        // Assign the new control's parent.
                        objNewControl.AssignParent(this.mobjOwnerControl);

                        // Check if registratio is needed.
                        if (blnRegisterControl)
                        {
                            // Register new control.
                            objNewControl.RegisterSelf();

                            // Update owner.
                            this.UpdateOwner();
                        }

                        // In case that new control is visible and the owner is created.
                        if (objNewControl.Visible && this.mobjOwnerControl.Created)
                        {
                            // Perform create control.
                            objNewControl.CreateControl();
                        }

                        // Raise the OnControlAdded event on the owner.
                        this.mobjOwnerControl.OnControlAdded(new ControlEventArgs(objNewControl));

                        // Invalidate owner's layout and enforce layout performing.
                        this.mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(false, true, true));

                        // Handle ObservableItemAdded.
                        if (this.ObservableItemAdded != null)
                        {
                            this.ObservableItemAdded(this, new ObservableListEventArgs(objNewControl));
                        }
                    }

                    UpdateProxyForm();
                }
            }

            /// <summary>Adds an array of control objects to the collection.</summary>
            /// <param name="arrControls">An array of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects to add to the collection. </param>
            [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
            public virtual void AddRange(Control[] arrControls)
            {
                if (arrControls == null)
                {
                    throw new ArgumentNullException("controls");
                }
                if (arrControls.Length > 0)
                {
                    this.mobjOwnerControl.SuspendLayout();
                    try
                    {
                        for (int num1 = 0; num1 < arrControls.Length; num1++)
                        {
                            this.Add(arrControls[num1], false, -1);
                        }
                        this.mobjOwnerControl.RegisterBatch(arrControls);
                        this.UpdateOwner();
                        UpdateProxyForm();
                    }
                    finally
                    {
                        this.mobjOwnerControl.ResumeLayout(true);
                    }
                }
            }

            /// <summary>Removes all controls from the collection.</summary>
            public virtual void Clear()
            {
                this.mobjOwnerControl.SuspendLayout();

                try
                {
                    while (this.Count != 0)
                    {
                        this.RemoveAt(this.Count - 1);
                    }
                }
                finally
                {
                    this.mobjOwnerControl.ResumeLayout();
                }

                if (ObservableListCleared != null)
                {
                    ObservableListCleared(this, EventArgs.Empty);
                }
            }

            /// <summary>Determines whether the specified control is a member of the collection.</summary>
            /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a member of the collection; otherwise, false.</returns>
            /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
            public bool Contains(Control objControl)
            {
                return base.InnerList.Contains(objControl);
            }

            /// <summary>Determines whether the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key.</summary>
            /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key; otherwise, false.</returns>
            /// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
            public virtual bool ContainsKey(string strKey)
            {
                return this.IsValidIndex(this.IndexOfKey(strKey));
            }

            /// <summary>Searches for controls by their <see cref="P:Gizmox.WebGUI.Forms.Control.Name"></see> property and builds an array of all the controls that match.</summary>
            /// <returns>An array of type <see cref="T:Gizmox.WebGUI.Forms.Control"></see> containing the matching controls.</returns>
            /// <param name="blnSearchAllChildren">true to search all child controls; otherwise, false. </param>
            /// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
            /// <exception cref="T:System.ArgumentException">The key parameter is null or the empty string (""). </exception>
            public Control[] Find(string strKey, bool blnSearchAllChildren)
            {
                if (CommonUtils.IsNullOrEmpty(strKey))
                {
                    throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
                }
                ArrayList objList1 = this.FindInternal(strKey, blnSearchAllChildren, this, new ArrayList());
                Control[] arrControls = new Control[objList1.Count];
                objList1.CopyTo(arrControls, 0);
                return arrControls;
            }

            private ArrayList FindInternal(string strKey, bool blnSearchAllChildren, Control.ControlCollection objControlsToLookIn, ArrayList foundControls)
            {
                if ((objControlsToLookIn == null) || (foundControls == null))
                {
                    return null;
                }
                try
                {
                    for (int num1 = 0; num1 < objControlsToLookIn.Count; num1++)
                    {
                        if ((objControlsToLookIn[num1] != null) && ClientUtils.SafeCompareStrings(objControlsToLookIn[num1].Name, strKey, true))
                        {
                            foundControls.Add(objControlsToLookIn[num1]);
                        }
                    }
                    if (!blnSearchAllChildren)
                    {
                        return foundControls;
                    }
                    for (int num2 = 0; num2 < objControlsToLookIn.Count; num2++)
                    {
                        if (((objControlsToLookIn[num2] != null) && (objControlsToLookIn[num2].Controls != null)) && (objControlsToLookIn[num2].Controls.Count > 0))
                        {
                            foundControls = this.FindInternal(strKey, blnSearchAllChildren, objControlsToLookIn[num2].Controls, foundControls);
                        }
                    }
                }
                catch (Exception objException1)
                {
                    if (ClientUtils.IsSecurityOrCriticalException(objException1))
                    {
                        throw;
                    }
                }
                return foundControls;
            }

            /// <summary>Retrieves the index of the specified child control within the control collection.</summary>
            /// <returns>A zero-based index value that represents the location of the specified child control within the control collection.</returns>
            /// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
            /// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
            public int GetChildIndex(Control objChild)
            {
                return this.GetChildIndex(objChild, true);
            }

            /// <summary>Retrieves the index of the specified child control within the control collection, and optionally raises an exception if the specified control is not within the control collection.</summary>
            /// <returns>A zero-based index value that represents the location of the specified child control within the control collection; otherwise -1 if the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not found in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
            /// <param name="blnThrowException">true to throw an exception if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> specified in the child parameter is not a control in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>; otherwise, false. </param>
            /// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
            /// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>, and the throwException parameter value is true. </exception>
            public virtual int GetChildIndex(Control objChild, bool blnThrowException)
            {
                int num1 = this.IndexOf(objChild);
                if ((num1 == -1) && blnThrowException)
                {
                    throw new ArgumentException(SR.GetString("ControlNotChild"));
                }
                return num1;
            }

            /// <summary>Retrieves a reference to an enumerator object that is used to iterate over a <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator"></see>.</returns>
            public override System.Collections.IEnumerator GetEnumerator()
            {
                return new ControlCollectionEnumerator(this);
            }

            /// <summary>Retrieves the index of the specified control in the control collection.</summary>
            /// <returns>A zero-based index value that represents the position of the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
            /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
            public int IndexOf(Control objControl)
            {
                return base.InnerList.IndexOf(objControl);
            }

            /// <summary>Retrieves the index of the first occurrence of the specified item within the collection.</summary>
            /// <returns>The zero-based index of the first occurrence of the control with the specified name in the collection.</returns>
            /// <param name="strKey">The name of the control to search for. </param>
            public virtual int IndexOfKey(string strKey)
            {
                if (!CommonUtils.IsNullOrEmpty(strKey))
                {
                    if (this.IsValidIndex(this.mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[this.mintLastAccessedIndex].Name, strKey, true))
                    {
                        return this.mintLastAccessedIndex;
                    }
                    for (int num1 = 0; num1 < this.Count; num1++)
                    {
                        if (ClientUtils.SafeCompareStrings(this[num1].Name, strKey, true))
                        {
                            this.mintLastAccessedIndex = num1;
                            return num1;
                        }
                    }
                    this.mintLastAccessedIndex = -1;
                }
                return -1;
            }

            private bool IsValidIndex(int index)
            {
                if (index >= 0)
                {
                    return (index < this.Count);
                }
                return false;
            }

            /// <summary>Removes the specified control from the control collection.</summary>
            /// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove from the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
            public virtual void Remove(Control objValue)
            {
                if (objValue != null && base.InnerList.Contains(objValue))
                {
                    base.InnerList.Remove(objValue);
                    objValue.UnRegisterSelf();
                    objValue.AssignParent(null);
                    this.UpdateOwner();
                    this.mobjOwnerControl.OnControlRemoved(new ControlEventArgs(objValue));

                    // Invalidate owner's layout and enforce layout performing.
                    this.mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    if (this.ObservableItemRemoved != null)
                    {
                        this.ObservableItemRemoved(this, new ObservableListEventArgs(objValue));
                    }
                    ContainerControl objcontainerControlInternal = this.mobjOwnerControl.GetContainerControlInternal() as ContainerControl;
                    if (objcontainerControlInternal != null)
                    {
                        objcontainerControlInternal.AfterControlRemoved(objValue, this.mobjOwnerControl);
                    }

                    UpdateProxyForm();
                }
            }

            /// <summary>Removes a control from the control collection at the specified indexed location.</summary>
            /// <param name="index">The index value of the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
            public void RemoveAt(int index)
            {
                this.Remove(this[index]);
            }

            /// <summary>Removes the child control with the specified key.</summary>
            /// <param name="strKey">The name of the child control to remove. </param>
            public virtual void RemoveByKey(string strKey)
            {
                int num1 = this.IndexOfKey(strKey);
                if (this.IsValidIndex(num1))
                {
                    this.RemoveAt(num1);
                }
            }

            /// <summary>Sets the index of the specified child control in the collection to the specified index value.</summary>
            /// <param name="objChild">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for. </param>
            /// <param name="intNewIndex">The new index value of the control. </param>
            /// <exception cref="T:System.ArgumentException">The child control is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
            public virtual void SetChildIndex(Control objChild, int intNewIndex)
            {
                this.SetChildIndexInternal(objChild, intNewIndex);
            }

            internal void Sort(IComparer objComparer)
            {
                this.InnerList.Sort(objComparer);
                this.UpdateOwner();
            }

            internal virtual void SetChildIndexInternal(Control objChild, int intNewIndex)
            {
                if (objChild == null)
                {
                    throw new ArgumentNullException("child");
                }
                int num1 = this.GetChildIndex(objChild);
                if (num1 != intNewIndex)
                {
                    if ((intNewIndex >= this.Count) || (intNewIndex == -1))
                    {
                        intNewIndex = this.Count - 1;
                    }
                    base.MoveElement(objChild, num1, intNewIndex);
                    this.UpdateOwner();
                }
            }

            int IList.Add(object objControl)
            {
                if (objControl is Control)
                {
                    this.Add((Control)objControl);
                    return this.IndexOf((Control)objControl);
                }
                throw new ArgumentException(SR.GetString("ControlBadControl"), "control");
            }

            /// <summary>
            /// Updates the owner.
            /// </summary>
            protected virtual void UpdateOwner()
            {
                if (mobjOwnerControl != null)
                {
                    mobjOwnerControl.Update();
                }
            }

            /// <summary>
            /// Updates the proxy form.
            /// </summary>
            private void UpdateProxyForm()
            {
                if (mobjOwnerControl != null)
                {
                    // Get owner control's form
                    Form objForm = mobjOwnerControl.Form;

                    if (objForm != null)
                    {
                        // Check if there is a proxyform
                        ProxyForm objProxyForm = objForm.ProxyComponent as ProxyForm;
                        if (objProxyForm != null)
                        {
                            // Validate proxyform  source components
                            objProxyForm.ValidateSourceComponent();
                        }
                    }
                }
            }

            void IList.Remove(object objControl)
            {
                if (objControl is Control)
                {
                    this.Remove((Control)objControl);
                }
            }

            object ICloneable.Clone()
            {
                Control.ControlCollection objCollection1 = this.mobjOwnerControl.CreateControlsInstance();
                objCollection1.InnerList.AddRange(this);
                return objCollection1;
            }


            /// <summary>Indicates a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key in the collection.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key within the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
            /// <param name="strKey">The name of the control to retrieve from the control collection.</param>
            public virtual Control this[string strKey]
            {
                get
                {
                    if (!CommonUtils.IsNullOrEmpty(strKey))
                    {
                        int num1 = this.IndexOfKey(strKey);
                        if (this.IsValidIndex(num1))
                        {
                            return this[num1];
                        }
                    }
                    return null;
                }
            }

            /// <summary>Indicates the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> at the specified indexed location in the collection.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> located at the specified index location within the control collection.</returns>
            /// <param name="index">The index of the control to retrieve from the control collection. </param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than zero or is greater than or equal to the number of controls in the collection. </exception>
            public new virtual Control this[int index]
            {
                get
                {
                    if ((index < 0) || (index >= this.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", SR.GetString("IndexOutOfRange"));
                    }
                    return (Control)base.InnerList[index];
                }
            }

            /// <summary>Gets the control that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
            /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
            public Control Owner
            {
                get
                {
                    return this.mobjOwnerControl;
                }
            }

            [Serializable]
            private class ControlCollectionEnumerator : System.Collections.IEnumerator
            {
                // Fields
                private Control.ControlCollection mobjControls;
                private int mintCurrent;
                private int mintOriginalCount;


                public ControlCollectionEnumerator(Control.ControlCollection objControls)
                {
                    this.mobjControls = objControls;
                    this.mintOriginalCount = objControls.Count;
                    this.mintCurrent = -1;
                }

                public bool MoveNext()
                {
                    if ((this.mintCurrent < (this.mobjControls.Count - 1)) && (this.mintCurrent < (this.mintOriginalCount - 1)))
                    {
                        this.mintCurrent++;
                        return true;
                    }
                    return false;
                }

                public void Reset()
                {
                    this.mintCurrent = -1;
                }


                public object Current
                {
                    get
                    {
                        if (this.mintCurrent == -1)
                        {
                            return null;
                        }
                        return this.mobjControls[this.mintCurrent];
                    }
                }



            }
            #region IObservableList Members

            /// <summary>
            /// Occurs when [observable item added].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemAdded;

            /// <summary>
            /// Occurs when [observable item inserted].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemInserted;

            /// <summary>
            /// Occurs when [observable item removed].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event ObservableListEventHandler ObservableItemRemoved;

            /// <summary>
            /// Occurs when [observable list cleared].
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public event EventHandler ObservableListCleared;

            #endregion

            #region IList Members

            /// <summary>
            /// Gets a value indicating whether the collection is read-only.
            /// </summary>
            /// <value></value>
            /// <returns>true if the collection is read-only; otherwise, false. The default is false.</returns>
            public override bool IsReadOnly
            {
                get
                {
                    return base.InnerList.IsReadOnly;
                }
            }

            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> at the specified index.
            /// </summary>
            /// <value></value>
            object System.Collections.IList.this[int index]
            {
                get
                {
                    return base.InnerList[index];
                }
                set
                {
                    base.InnerList[index] = value;
                }
            }

            /// <summary>
            /// Inserts the specified int index.
            /// </summary>
            /// <param name="intIndex">Index of the value.</param>
            /// <param name="objValue">The value.</param>
            public void Insert(int intIndex, object objValue)
            {
                this.Add(objValue as Control, true, intIndex);
            }

            /// <summary>
            /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
            /// </summary>
            /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
            /// <returns>
            /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
            /// </returns>
            bool System.Collections.IList.Contains(object objValue)
            {
                return base.InnerList.Contains(objValue);
            }

            /// <summary>
            /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            /// <param name="objValue">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
            /// <returns>
            /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
            /// </returns>
            int System.Collections.IList.IndexOf(object objValue)
            {
                return base.InnerList.IndexOf(objValue);
            }

            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
            /// </summary>
            /// <value></value>
            /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.
            /// </returns>
            public bool IsFixedSize
            {
                get
                {
                    return base.InnerList.IsFixedSize;
                }
            }

            #endregion

            #region ICollection Members

            bool ICollection.IsSynchronized
            {
                get
                {
                    // TODO:  Add ControlCollection.IsSynchronized getter implementation
                    return this.InnerList.IsSynchronized;
                }
            }

            /// <summary>
            /// Gets the number of elements in the collection.
            /// </summary>
            /// <value></value>
            /// <returns>The number of elements currently contained in the collection.</returns>
            new public int Count
            {
                get
                {
                    return this.InnerList.Count;
                }
            }

            void ICollection.CopyTo(Array objArray, int index)
            {
                this.InnerList.CopyTo(objArray, index);
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this.InnerList.SyncRoot;
                }
            }

            #endregion
        }

        #endregion

        #region ControlVersionInfo Class

        /// <summary>
        /// The current control version information
        /// </summary>
        [Serializable()]
        private class ControlVersionInfo
        {
            /// <summary>
            /// The control company name
            /// </summary>
            private string mstrCompanyName;

            /// <summary>
            /// The control 
            /// </summary>
            private Control mobjOwner;

            /// <summary>
            /// The product name
            /// </summary>
            private string mstrProductName;

            /// <summary>
            /// The product version
            /// </summary>
            private string mstrProductVersion;

            /// <summary>
            /// Create a new control version information
            /// </summary>
            /// <param name="objOwner">The obj owner.</param>
            internal ControlVersionInfo(Control objOwner)
            {
                this.mobjOwner = objOwner;
            }

            /// <summary>
            /// Get the control company name
            /// </summary>
            internal string CompanyName
            {
                get
                {
                    if (this.mstrCompanyName == null)
                    {
                        object[] arrCustomAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                        if ((arrCustomAttributes != null) && (arrCustomAttributes.Length > 0))
                        {
                            this.mstrCompanyName = ((AssemblyCompanyAttribute)arrCustomAttributes[0]).Company;
                        }
                        if ((this.mstrCompanyName == null) || (this.mstrCompanyName.Length == 0))
                        {
                            string strText = this.mobjOwner.GetType().Namespace;
                            if (strText == null)
                            {
                                strText = string.Empty;
                            }
                            int intLength = strText.IndexOf("/");
                            if (intLength != -1)
                            {
                                this.mstrCompanyName = strText.Substring(0, intLength);
                            }
                            else
                            {
                                this.mstrCompanyName = strText;
                            }
                        }
                    }
                    return this.mstrCompanyName;
                }
            }

            /// <summary>
            /// Get the control product name
            /// </summary>
            internal string ProductName
            {
                get
                {
                    if (this.mstrProductName == null)
                    {
                        object[] arrCustomAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                        if ((arrCustomAttributes != null) && (arrCustomAttributes.Length > 0))
                        {
                            this.mstrProductName = ((AssemblyProductAttribute)arrCustomAttributes[0]).Product;
                        }
                        if ((this.mstrProductName == null) || (this.mstrProductName.Length == 0))
                        {
                            string strText = this.mobjOwner.GetType().Namespace;
                            if (strText == null)
                            {
                                strText = string.Empty;
                            }
                            int intIndex = strText.IndexOf(".");
                            if (intIndex != -1)
                            {
                                this.mstrProductName = strText.Substring(intIndex + 1);
                            }
                            else
                            {
                                this.mstrProductName = strText;
                            }
                        }
                    }
                    return this.mstrProductName;
                }
            }

            /// <summary>
            /// Get the control product version
            /// </summary>
            internal string ProductVersion
            {
                get
                {
                    if (this.mstrProductVersion == null)
                    {
                        object[] arrCustomAttributes = this.mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                        if ((arrCustomAttributes != null) && (arrCustomAttributes.Length > 0))
                        {
                            this.mstrProductVersion = ((AssemblyInformationalVersionAttribute)arrCustomAttributes[0]).InformationalVersion;
                        }
                        if (this.mstrProductVersion == null || this.mstrProductVersion.Length == 0)
                        {
                            this.mstrProductVersion = "1.0.0.0";
                        }
                    }
                    return this.mstrProductVersion;
                }
            }
        }

        #endregion

        #region Events

        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property value changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ControlOnParentChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler ParentChanged
        {
            add
            {
                this.AddHandler(Control.ParentChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ParentChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ParentChanged event.
        /// </summary>
        private EventHandler ParentChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.ParentChangedEvent);
            }
        }

        /// <summary>
        /// The ParentChanged event registration.
        /// </summary>
        private static readonly SerializableEvent ParentChangedEvent = SerializableEvent.Register("ParentChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the control is entered.
        /// </summary>
        public event EventHandler Enter
        {
            add
            {
                this.AddCriticalHandler(Control.EnterEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.EnterEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Enter event.
        /// </summary>
        private EventHandler EnterHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.EnterEvent);
            }
        }

        /// <summary>
        /// The Enter event registration.
        /// </summary>
        private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the input focus leaves the control.
        /// Not implemented by design.
        /// </summary>
        public event EventHandler Leave
        {
            add
            {
                this.AddCriticalHandler(Control.LeaveEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.LeaveEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Leave event.
        /// </summary>
        private EventHandler LeaveHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.LeaveEvent);
            }
        }

        /// <summary>
        /// The Leave event registration.
        /// </summary>
        private static readonly SerializableEvent LeaveEvent = SerializableEvent.Register("Leave", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the control is resized.  
        /// </summary>
        public event EventHandler Resize
        {
            add
            {
                this.AddCriticalHandler(Control.ResizeEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ResizeEvent, value);
            }
        }

        private EventHandler ResizeHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.ResizeEvent);
            }
        }

        private static readonly SerializableEvent ResizeEvent = SerializableEvent.Register("Resize", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Enabled"></see> property value has changed.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatPropertyChanged"), SRDescription("ControlOnEnabledChangedDescr")]
        public event EventHandler EnabledChanged
        {
            add
            {
                this.AddHandler(Control.EnabledChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.EnabledChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the EnabledChanged event.
        /// </summary>
        private EventHandler EnabledChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.EnabledChangedEvent);
            }
        }

        /// <summary>
        /// The EnabledChanged event registration.
        /// </summary>
        private static readonly SerializableEvent EnabledChangedEvent = SerializableEvent.Register("EnabledChanged", typeof(EventHandler), typeof(Control));


        /// <summary>
        /// The Click event registration.
        /// </summary>
        internal static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof(EventHandler), typeof(Control));

        /// <summary>
        /// Occurs on clicking the button.
        /// </summary>
        public event EventHandler Click
        {
            add
            {
                this.AddCriticalHandler(Control.ClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ClickEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static readonly SerializableEvent ControlSelectedEvent = SerializableEvent.Register("ControlSelected", typeof(ControlsEventHandler), typeof(Control));

        /// <summary>
        /// Occurs when [controls selected].
        /// </summary>
        public event ControlsEventHandler ControlSelected
        {
            add
            {
                this.AddCriticalHandler(Control.ControlSelectedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ControlSelectedEvent, value);
            }
        }

        /// <summary>
        /// Gets the control selected handler.
        /// </summary>
        private ControlsEventHandler ControlSelectedHandler
        {
            get
            {
                return (ControlsEventHandler)this.GetHandler(Control.ControlSelectedEvent);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static readonly SerializableEvent ControlDroppedEvent = SerializableEvent.Register("ControlDropped", typeof(ControlEventHandler), typeof(Control));

        /// <summary>
        /// Occurs when [controls dropped].
        /// </summary>
        public event ControlEventHandler ControlDropped
        {
            add
            {
                this.AddCriticalHandler(Control.ControlDroppedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ControlDroppedEvent, value);
            }
        }

        /// <summary>
        /// Gets the control dropped handler.
        /// </summary>
        private ControlEventHandler ControlDroppedHandler
        {
            get
            {
                return (ControlEventHandler)this.GetHandler(Control.ControlDroppedEvent);
            }
        }

        /// <summary>Occurs when the control is clicked by the mouse.</summary>
        [SRCategory("CatAction"), SRDescription("ControlOnMouseClickDescr")]
        public event MouseEventHandler MouseClick
        {
            add
            {
                this.AddCriticalHandler(Control.MouseClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.MouseClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the MouseClick event.
        /// </summary>
        private MouseEventHandler MouseClickHandler
        {
            get
            {
                return (MouseEventHandler)this.GetHandler(Control.MouseClickEvent);
            }
        }

        /// <summary>
        /// The MouseClick event registration.
        /// </summary>
        internal static readonly SerializableEvent MouseClickEvent = SerializableEvent.Register("MouseClick", typeof(MouseEventHandler), typeof(Control));




        /// <summary>
        /// Occurs on key down.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
        public event KeyEventHandler KeyDown
        {
            add
            {
                this.AddCriticalHandler(Control.KeyDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.KeyDownEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the KeyDown event.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected KeyEventHandler KeyDownHandler
        {
            get
            {
                return (KeyEventHandler)this.GetHandler(Control.KeyDownEvent);
            }
        }

        /// <summary>
        /// The KeyDown event registration.
        /// </summary>
        private static readonly SerializableEvent KeyDownEvent = SerializableEvent.Register("KeyDown", typeof(KeyEventHandler), typeof(Control));



        /// <summary>
        /// Occurs on key press.            
        /// </summary>            
        public event KeyPressEventHandler KeyPress
        {
            add
            {
                this.AddCriticalHandler(Control.KeyPressEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.KeyPressEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the KeyPress event.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected KeyPressEventHandler KeyPressHandler
        {
            get
            {
                return (KeyPressEventHandler)this.GetHandler(Control.KeyPressEvent);
            }
        }

        /// <summary>
        /// The KeyPress event registration.
        /// </summary>
        private static readonly SerializableEvent KeyPressEvent = SerializableEvent.Register("KeyPress", typeof(KeyPressEventHandler), typeof(Control));



        /// <summary>
        /// Occurs on key up.
        /// Implemented by design as KeyPress (Use KeyPress instead).            
        /// </summary>
        [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
        public event KeyEventHandler KeyUp
        {
            add
            {
                this.AddHandler(Control.KeyUpEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.KeyUpEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the KeyUp event.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected KeyEventHandler KeyUpHandler
        {
            get
            {
                return (KeyEventHandler)this.GetHandler(Control.KeyUpEvent);
            }
        }

        /// <summary>
        /// The KeyUp event registration.
        /// </summary>
        private static readonly SerializableEvent KeyUpEvent = SerializableEvent.Register("KeyUp", typeof(KeyEventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the control recives focus.
        /// </summary>
        public event EventHandler GotFocus
        {
            add
            {
                this.AddCriticalHandler(Control.GotFocusEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.GotFocusEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the GotFocus event.
        /// </summary>
        private EventHandler GotFocusHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.GotFocusEvent);
            }
        }

        /// <summary>
        /// The GotFocus event registration.
        /// </summary>
        private static readonly SerializableEvent GotFocusEvent = SerializableEvent.Register("GotFocus", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the control loses focus.
        /// </summary>
        public event EventHandler LostFocus
        {
            add
            {
                this.AddCriticalHandler(Control.LostFocusEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.LostFocusEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the LostFocus event.
        /// </summary>
        private EventHandler LostFocusHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.LostFocusEvent);
            }
        }

        /// <summary>
        /// The LostFocus event registration.
        /// </summary>
        private static readonly SerializableEvent LostFocusEvent = SerializableEvent.Register("LostFocus", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the control is double clicked.
        /// </summary>
        public event EventHandler DoubleClick
        {
            add
            {
                this.AddCriticalHandler(Control.DoubleClickEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.DoubleClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the DoubleClick event.
        /// </summary>
        private EventHandler DoubleClickHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.DoubleClickEvent);
            }
        }

        /// <summary>
        /// The DoubleClick event registration.
        /// </summary>
        internal static readonly SerializableEvent DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof(EventHandler), typeof(Control));

        /// <summary>
        /// Occurs when the Text property value changes.  
        /// </summary>
        public event EventHandler TextChanged
        {
            add
            {
                this.AddCriticalHandler(Control.TextChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.TextChangedEvent, value);
            }
        }

        private EventHandler TextChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.TextChangedEvent);
            }
        }

        private static readonly SerializableEvent TextChangedEvent = SerializableEvent.Register("TextChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the control is finished validating.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ControlOnValidatedDescr"), SRCategory("CatFocus")]
        public event EventHandler Validated
        {
            add
            {
                this.AddCriticalHandler(Control.ValidatedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ValidatedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Validated event.
        /// </summary>
        private EventHandler ValidatedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.ValidatedEvent);
            }
        }

        /// <summary>
        /// The Validated event registration.
        /// </summary>
        private static readonly SerializableEvent ValidatedEvent = SerializableEvent.Register("Validated", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatPropertyChanged"), SRDescription("ControlOnCausesValidationChangedDescr")]
        public event EventHandler CausesValidationChanged
        {
            add
            {
                this.AddHandler(Control.CausesValidationChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.CausesValidationChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CausesValidationChanged event.
        /// </summary>
        private EventHandler CausesValidationChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.CausesValidationChangedEvent);
            }
        }

        /// <summary>
        /// The CausesValidationChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CausesValidationChangedEvent = SerializableEvent.Register("CausesValidationChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the control is validating.</summary>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ControlOnValidatingDescr"), SRCategory("CatFocus")]
        public event CancelEventHandler Validating
        {
            add
            {
                this.AddCriticalHandler(Control.ValidatingEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.ValidatingEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the Validating event.
        /// </summary>
        private CancelEventHandler ValidatingHandler
        {
            get
            {
                return (CancelEventHandler)this.GetHandler(Control.ValidatingEvent);
            }
        }

        /// <summary>
        /// The Validating event registration.
        /// </summary>
        private static readonly SerializableEvent ValidatingEvent = SerializableEvent.Register("Validating", typeof(CancelEventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the Text property value changes (Queued).  
        /// </summary>
        public event EventHandler TextChangedQueued
        {
            add
            {
                this.AddHandler(Control.TextChangedQueuedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.TextChangedQueuedEvent, value);
            }
        }

        private EventHandler TextChangedQueuedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.TextChangedQueuedEvent);
            }
        }

        private static readonly SerializableEvent TextChangedQueuedEvent = SerializableEvent.Register("TextChangedQueued", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the Location property value has changed.
        /// </summary>
        public event EventHandler LocationChanged
        {
            add
            {
                this.AddCriticalHandler(Control.LocationChangedEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.LocationChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the LocationChanged event.
        /// </summary>
        private EventHandler LocationChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.LocationChangedEvent);
            }
        }

        /// <summary>
        /// The LocationChanged event registration.
        /// </summary>
        private static readonly SerializableEvent LocationChangedEvent = SerializableEvent.Register("LocationChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when a new control is added to the ControlCollection.
        /// </summary>
        public event ControlEventHandler ControlAdded
        {
            add
            {
                this.AddHandler(Control.ControlAddedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ControlAddedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ControlAdded event.
        /// </summary>
        private ControlEventHandler ControlAddedHandler
        {
            get
            {
                return (ControlEventHandler)this.GetHandler(Control.ControlAddedEvent);
            }
        }

        /// <summary>
        /// The ControlAdded event registration.
        /// </summary>
        private static readonly SerializableEvent ControlAddedEvent = SerializableEvent.Register("ControlAdded", typeof(ControlEventHandler), typeof(Control));
        private static readonly SerializableEvent ControlEditingEvent = SerializableEvent.Register("EditControlEditingEvent", typeof(EventHandler<EditValueEditingEventArgs>), typeof(Control));

        
        /// <summary>
        /// Occurs when [edit control editing].
        /// </summary>
        public event EventHandler<EditValueEditingEventArgs> EditControlEditing
        {
            add
            {
                this.AddHandler(Control.ControlEditingEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ControlEditingEvent, value);
            }
        }


        /// <summary>
        /// Occurs when a control is removed from the ControlCollection.
        /// </summary>
        public event ControlEventHandler ControlRemoved
        {
            add
            {
                this.AddHandler(Control.ControlRemovedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ControlRemovedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ControlRemoved event.
        /// </summary>
        private ControlEventHandler ControlRemovedHandler
        {
            get
            {
                return (ControlEventHandler)this.GetHandler(Control.ControlRemovedEvent);
            }
        }

        /// <summary>
        /// The ControlRemoved event registration.
        /// </summary>
        private static readonly SerializableEvent ControlRemovedEvent = SerializableEvent.Register("ControlRemoved", typeof(ControlEventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// Implemented by design as Click (Use Click instead).              
        /// </summary>
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        public event MouseEventHandler MouseDown
        {
            add
            {
                this.AddCriticalHandler(Control.MouseDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.MouseDownEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the MouseDown event.
        /// </summary>
        private MouseEventHandler MouseDownHandler
        {
            get
            {
                return (MouseEventHandler)this.GetHandler(Control.MouseDownEvent);
            }
        }

        /// <summary>
        /// The MouseDown event registration.
        /// </summary>
        internal static readonly SerializableEvent MouseDownEvent = SerializableEvent.Register("MouseDown", typeof(MouseEventHandler), typeof(Control));




        /// <summary>Occurs when the mouse pointer is over the control and a mouse button is released.
        /// Implemented by design as Click (Use Click instead).      
        /// </summary>
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        public event MouseEventHandler MouseUp
        {
            add
            {
                this.AddCriticalHandler(Control.MouseUpEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(Control.MouseUpEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the MouseUp event.
        /// </summary>
        private MouseEventHandler MouseUpHandler
        {
            get
            {
                return (MouseEventHandler)this.GetHandler(Control.MouseUpEvent);
            }
        }

        /// <summary>
        /// The MouseUp event registration.
        /// </summary>
        internal static readonly SerializableEvent MouseUpEvent = SerializableEvent.Register("MouseUp", typeof(MouseEventHandler), typeof(Control));

        /// <summary>
        /// Gets the position of the mouse cursor in screen coordinates.
        /// </summary>
        public static Point MousePosition
        {
            get
            {
                return Cursor.Position;
            }
        }

        /// <summary>
        /// Occurs when the value of the BindingContext property changes.
        /// </summary>
        public event EventHandler BindingContextChanged
        {
            add
            {
                this.AddHandler(Control.BindingContextChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.BindingContextChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the BindingContextChanged event.
        /// </summary>
        private EventHandler BindingContextChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.BindingContextChangedEvent);
            }
        }

        /// <summary>
        /// The BindingContextChanged event registration.
        /// </summary>
        private static readonly SerializableEvent BindingContextChangedEvent = SerializableEvent.Register("BindingContextChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the value of the BackColor property changes.
        /// </summary>
        public event EventHandler BackColorChanged
        {
            add
            {
                this.AddHandler(Control.BackColorChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.BackColorChangedEvent, value);
            }
        }

        private EventHandler BackColorChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.BackColorChangedEvent);
            }
        }

        private static readonly SerializableEvent BackColorChangedEvent = SerializableEvent.Register("BackColorChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the value of the BackgroundImage property changes.
        /// </summary>
        public event EventHandler BackgroundImageChanged
        {
            add
            {
                this.AddHandler(Control.BackgroundImageChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.BackgroundImageChangedEvent, value);
            }
        }

        private EventHandler BackgroundImageChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.BackgroundImageChangedEvent);
            }
        }

        private static readonly SerializableEvent BackgroundImageChangedEvent = SerializableEvent.Register("BackgroundImageChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the BackgroundImageLayout property changes.
        /// </summary>
        public event EventHandler BackgroundImageLayoutChanged
        {
            add
            {
                this.AddHandler(Control.BackgroundImageLayoutChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.BackgroundImageLayoutChangedEvent, value);
            }
        }

        private EventHandler BackgroundImageLayoutChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.BackgroundImageLayoutChangedEvent);
            }
        }

        private static readonly SerializableEvent BackgroundImageLayoutChangedEvent = SerializableEvent.Register("BackgroundImageLayoutChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the FontChanged property changes.
        /// </summary>
        public event EventHandler FontChanged
        {
            add
            {
                this.AddHandler(Control.FontChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.FontChangedEvent, value);
            }
        }

        private EventHandler FontChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.FontChangedEvent);
            }
        }

        private static readonly SerializableEvent FontChangedEvent = SerializableEvent.Register("FontChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the ForeColorChanged property changes.
        /// </summary>
        public event EventHandler ForeColorChanged
        {
            add
            {
                this.AddHandler(Control.ForeColorChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ForeColorChangedEvent, value);
            }
        }

        private EventHandler ForeColorChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.ForeColorChangedEvent);
            }
        }

        private static readonly SerializableEvent ForeColorChangedEvent = SerializableEvent.Register("ForeColorChanged", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when the PaddingChanged property changes.
        /// </summary>
        public event EventHandler PaddingChanged
        {
            add
            {
                this.AddHandler(Control.PaddingChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.PaddingChangedEvent, value);
            }
        }

        private EventHandler PaddingChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.PaddingChangedEvent);
            }
        }

        private static readonly SerializableEvent PaddingChangedEvent = SerializableEvent.Register("PaddingChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
        public event EventHandler CursorChanged
        {
            add
            {
                this.AddHandler(Control.CursorChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.CursorChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CursorChanged event.
        /// </summary>
        private EventHandler CursorChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.CursorChangedEvent);
            }
        }

        /// <summary>
        /// The CursorChanged event registration.
        /// </summary>
        private static readonly SerializableEvent CursorChangedEvent = SerializableEvent.Register("CursorChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.</summary>
        [SRCategory("CatPropertyChanged"), SRDescription("ControlOnVisibleChangedDescr")]
        public event EventHandler VisibleChanged
        {
            add
            {
                this.AddHandler(Control.VisibleChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.VisibleChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the VisibleChanged event.
        /// </summary>
        private EventHandler VisibleChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.VisibleChangedEvent);
            }
        }

        /// <summary>
        /// The VisibleChanged event registration.
        /// </summary>
        private static readonly SerializableEvent VisibleChangedEvent = SerializableEvent.Register("VisibleChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when the user requests help for a control.</summary>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), SRDescription("ControlOnHelpDescr")]
        public event HelpEventHandler HelpRequested
        {
            add
            {
                this.AddHandler(Control.HelpRequestedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.HelpRequestedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the HelpRequested event.
        /// </summary>
        private HelpEventHandler HelpRequestedHandler
        {
            get
            {
                return (HelpEventHandler)this.GetHandler(Control.HelpRequestedEvent);
            }
        }

        /// <summary>
        /// The HelpRequested event registration.
        /// </summary>
        private static readonly SerializableEvent HelpRequestedEvent = SerializableEvent.Register("HelpRequested", typeof(HelpEventHandler), typeof(Control));



        /// <summary>
        /// The AutoSizeChanged event registration.
        /// </summary>
        private static readonly SerializableEvent AutoSizeChangedEvent = SerializableEvent.Register("AutoSizeChanged", typeof(EventHandler), typeof(Control));

        /// <summary>
        /// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
        /// </see> property changes.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always), SRDescription("ControlOnAutoSizeChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler AutoSizeChanged
        {
            add
            {
                this.AddHandler(Control.AutoSizeChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.AutoSizeChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the AutoSizeChanged event.
        /// </summary>
        private EventHandler AutoSizeChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.AutoSizeChangedEvent);
            }
        }



        /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
        [SRDescription("ControlOnSizeChangedDescr"), SRCategory("CatPropertyChanged")]
        public event EventHandler SizeChanged
        {
            add
            {
                this.AddHandler(Control.SizeChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.SizeChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the CursorChanged event.
        /// </summary>
        private EventHandler SizeChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.SizeChangedEvent);
            }
        }

        /// <summary>
        /// The CursorChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SizeChangedEvent = SerializableEvent.Register("SizeChanged", typeof(EventHandler), typeof(Control));



        /// <summary>Occurs when an object is dragged into the control's bounds.</summary>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [SRDescription("ControlOnDragEnterDescr"), SRCategory("CatDragDrop")]
        public event DragEventHandler DragEnter;



        /// <summary>Occurs when the mouse pointer is moved over the control.</summary>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [SRDescription("ControlOnMouseMoveDescr"), SRCategory("CatMouse")]
        public event MouseEventHandler MouseMove;

        /// <summary>Occurs when the mouse pointer leaves the control.</summary>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [SRCategory("CatMouse"), SRDescription("ControlOnMouseLeaveDescr")]
        public event MouseEventHandler MouseLeave;

        /// <summary>Occurs when the mouse pointer enters the control.</summary>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [SRDescription("ControlOnMouseEnterDescr"), SRCategory("CatMouse")]
        public event MouseEventHandler MouseEnter;


        #endregion

        #region Class Members


        /// <summary>
        /// Gets or sets the control styles.
        /// </summary>
        /// <value>The control styles.</value>
        [NonSerialized]
        private ControlStyles menmControlStyle;


        /// <summary>
        /// The collection of controls this control has 
        /// </summary>
        [NonSerialized]
        private ControlCollection mobjControls;


        /// <summary>
        /// The height of the control.
        /// </summary>
        /// <value>The height of the control.</value>
        [NonSerialized]
        private int mintHeight = 0;

        /// <summary>
        /// The layout height of the control
        /// </summary>
        [NonSerialized]
        private int mintLayoutHeight = 0;

        /// <summary>
        /// The preferred height of the control.
        /// </summary>
        /// <value>The preferred height of the control.</value>
        [NonSerialized]
        private int mintPreferredHeight = -1;

        /// <summary>
        /// The width of the control.
        /// </summary>
        /// <value>The width of the control.</value>
        [NonSerialized]
        private int mintWidth = 0;

        /// <summary>
        /// The layout width of the control.
        /// </summary>
        /// <value>The layout width of the control.</value>
        [NonSerialized]
        private int mintLayoutWidth = 0;

        /// <summary>
        /// The preferred width of the control.
        /// </summary>
        /// <value>The preferred width of the control.</value>
        [NonSerialized]
        private int mintPreferredWidth = -1;

        /// <summary>
        /// The left position of the control.
        /// </summary>
        [NonSerialized]
        private int mintLeft = 0;

        /// <summary>
        /// The top position of the control.
        /// </summary>
        [NonSerialized]
        private int mintTop = 0;

        /// <summary>
        /// The control tab index
        /// </summary>
        [NonSerialized]
        private int mintTabIndex = -1;

        /// <summary>
        /// Control flags
        /// </summary>
        [NonSerialized]
        private int mintSuspendLayout = 0;


        /// <summary>
        /// The current docking state
        /// </summary>
        [NonSerialized]
        private DockStyle menmDock = DockStyle.None;

        /// <summary>
        /// The current anchoring state
        /// </summary>
        [NonSerialized]
        private AnchorStyles menmAnchor = AnchorStyles.Left | AnchorStyles.Top;


        /// <summary>
        /// The component state
        /// </summary>
        [NonSerialized]
        private int mintControlState = 0;

        /// <summary>
        /// The selected state
        /// </summary>
        [NonSerialized]
        private bool mblnSelectedIndicator = false;

        #endregion

        #region C'Tor/D'Tor

        /// <summary>
        /// Static constructor
        /// </summary>
        static Control()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public Control()
        {
            // Set defaul style
            this.SetStyle(ControlStyles.UseTextForAccessibility | ControlStyles.AllPaintingInWmPaint | ControlStyles.StandardDoubleClick | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.UserPaint, true);

            // Set the control default state
            this.SetState(ComponentState.Enabled | ComponentState.Visible | ComponentState.AllowDrag, true);
            this.SetState(ControlState.HasPositioning | ControlState.CausesValidation | ControlState.TabStop, true);


            // Get the default size
            Size objDefaultSize = this.DefaultSize;

            // Set the default size
            mintLayoutHeight = mintHeight = objDefaultSize.Height;
            mintLayoutWidth = mintWidth = objDefaultSize.Width;
            menmEditMode = Forms.EditMode.Off;
        }

        #endregion

        #region Methods

        #region Serialization Optimization

        /// <summary>
        /// The amount of fields that the control writes / reads
        /// </summary>
        private const int mcntSerializableDataFieldCount = 14;

        /// <summary>
        /// The size of the initiale serialization data array which is the optmized serialization graph.
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// This value should be the actual size needed so that re-allocations and truncating will not be required.
        /// </remarks>
        protected override int SerializableDataInitialSize
        {
            get
            {
                int intSerializableDataInitialSize = base.SerializableDataInitialSize;

                // Add the amount of fields that the control writes
                intSerializableDataInitialSize += mcntSerializableDataFieldCount;

                // If control should serialized controls we need to add the collection size
                if (this.ShouldSerializableObjectSerializeControls)
                {
                    // Add the controls array required capacity
                    intSerializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjControls);
                }

                return intSerializableDataInitialSize;
            }
        }

        /// <summary>
        /// Called when serializable object is deserialized and we need to extract the optimized
        /// object graph to the working graph.
        /// </summary>
        /// <param name="objReader">The optimized object graph reader.</param>
        protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
        {
            base.OnSerializableObjectDeserializing(objReader);

            // Read the current control state
            menmAnchor = (AnchorStyles)objReader.ReadObject();
            menmDock = (DockStyle)objReader.ReadObject();
            menmControlStyle = (ControlStyles)objReader.ReadObject();
            mintHeight = objReader.ReadInt32();
            mintWidth = objReader.ReadInt32();
            mintLeft = objReader.ReadInt32();
            mintTop = objReader.ReadInt32();
            mintLayoutHeight = objReader.ReadInt32();
            mintLayoutWidth = objReader.ReadInt32();
            mintPreferredHeight = objReader.ReadInt32();
            mintPreferredWidth = objReader.ReadInt32();
            mintTabIndex = objReader.ReadInt32();
            mintSuspendLayout = objReader.ReadInt32();
            mintControlState = objReader.ReadInt32();
            mblnSelectedIndicator = objReader.ReadBoolean();

            // If control should serialized controls it should deserialize them
            if (this.ShouldSerializableObjectSerializeControls)
            {
                // Read the controls array 
                object[] arrControls = objReader.ReadArray();

                // If there are controls
                if (arrControls.Length > 0)
                {
                    // Create the controls array
                    mobjControls = this.CreateControlsInstance();

                    // Add the controls
                    mobjControls.InnerList.AddRange(arrControls);
                }
            }
        }

        /// <summary>
        /// Called before serializable object is serialized to optimize the application object graph.
        /// </summary>
        /// <param name="objWriter">The optimized object graph writer.</param>
        protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
        {
            base.OnSerializableObjectSerializing(objWriter);

            // Write the current control state
            objWriter.WriteObject(menmAnchor);
            objWriter.WriteObject(menmDock);
            objWriter.WriteObject(menmControlStyle);
            objWriter.WriteInt32(mintHeight);
            objWriter.WriteInt32(mintWidth);
            objWriter.WriteInt32(mintLeft);
            objWriter.WriteInt32(mintTop);
            objWriter.WriteInt32(mintLayoutHeight);
            objWriter.WriteInt32(mintLayoutWidth);
            objWriter.WriteInt32(mintPreferredHeight);
            objWriter.WriteInt32(mintPreferredWidth);
            objWriter.WriteInt32(mintTabIndex);
            objWriter.WriteInt32(mintSuspendLayout);
            objWriter.WriteInt32(mintControlState);
            objWriter.WriteBoolean(mblnSelectedIndicator);

            // If controls should be serialized
            if (this.ShouldSerializableObjectSerializeControls)
            {
                // Store the controls array
                objWriter.WriteArray(mobjControls);
            }
        }


        /// <summary>
        /// Gets a value indicating whether serializable object should serialize controls.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if serializable object should serialize controls; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual bool ShouldSerializableObjectSerializeControls
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region State Methods        



        [Flags]
        internal enum ControlState : int
        {
            /// <summary>
            /// The top level flag
            /// </summary>
            TopLevel = 1,

            /// <summary>
            /// The tab stop flag
            /// </summary>
            TabStop = 2,

            /// <summary>
            /// The becoming active control flag
            /// </summary>
            BecomingActiveControl = 4,

            /// <summary>
            /// The has positioning flag
            /// </summary>
            HasPositioning = 8,

            /// <summary>
            /// Layout dirty flag.
            /// </summary>
            LayoutIsDirty = 16,

            /// <summary>
            /// The cause validation flag
            /// </summary>
            CausesValidation = 32,

            /// <summary>
            /// The validation cancelled flag
            /// </summary>
            ValidationCancelled = 64,

            /// <summary>
            /// The auto scroll flag
            /// </summary>
            AutoScroll = 128,

            /// <summary>
            /// The hscroll flag
            /// </summary>
            HScroll = 256,

            /// <summary>
            /// The vscroll flag
            /// </summary>
            VScroll = 512,

            /// <summary>
            /// The auto size state flag
            /// </summary>
            AutoSize = 1024,

            /// <summary>
            /// The created flag
            /// </summary>
            Created = 2048,

            /// <summary>
            /// The sorted flag
            /// </summary>
            Sorted = 4096,

        }

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="intFlag">The flag to set.</param>
        /// <param name="blnValue">The flag value to set.</param>
        internal void SetState(ControlState enmState, bool blnValue)
        {
            this.mintControlState = blnValue ? (this.mintControlState | ((int)enmState)) : (this.mintControlState & ~((int)enmState));
        }

        /// <summary>
        /// Sets the state and returns a flag if value had changed.
        /// </summary>
        /// <param name="intFlag">The flag to set.</param>
        /// <param name="blnValue">The flag value to set.</param>
        internal bool SetStateWithCheck(ControlState enmState, bool blnValue)
        {
            // Check if the value had changed
            if (GetState(enmState) != blnValue)
            {
                SetState(enmState, blnValue);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="intFlag">The flag to get.</param>
        /// <returns></returns>
        internal bool GetState(ControlState enmState)
        {
            return ((this.mintControlState & ((int)enmState)) != 0);
        }

        #endregion

        /// <summary>
        /// Shows the contextual toolbar.
        /// </summary>
        public virtual void ShowContextualToolbar()
        {
            ContextualToolbar.ContextualToolbar.ShowContextualToolbar(this);
        }

        #region Render

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // render component attributes
            RenderComponentAttributes(objContext, objWriter);

            // Render the tab index attribute.
            if (this.TabStop || (this.Controls.Count > 0 && !Control.IsFocusManagingContainerControl(this)))
            {
                objWriter.WriteAttributeString(WGAttributes.TabIndex, this.TabIndex.ToString());
            }

            //Render Tabbing as group indication
            if (this.EnableGroupTabbing)
            {
                objWriter.WriteAttributeString(WGAttributes.EnableGroupTabbing, "1");
            }

            // Get the visible state
            bool blnVisible = this.GetState(ComponentState.Visible);

            // If not visible render the visible attribute 
            if (!blnVisible)
            {
                objWriter.WriteAttributeString(WGAttributes.Visible, "0");
            }

            RenderEnabledAttribute(objWriter);  
          
            if (this.Focusable) objWriter.WriteAttributeString(WGAttributes.Focus, "1");

            // Render the visual template
            RenderVisualTemplate(objContext, objWriter);

            if (this.CustomStyle != "") objWriter.WriteAttributeString(WGAttributes.CustomStyle, this.GetProxyPropertyValue<string>("CustomStyle", this.CustomStyle));
            

            if (ShouldRenderExtendedToolTip())
            {
                RenderExtendedToolTip(objWriter, false);
            }
            else
            {
                string strToolTip = this.ToolTip;
                if (!string.IsNullOrEmpty(strToolTip))
                {
                    objWriter.WriteAttributeText(WGAttributes.ToolTip, strToolTip);
                }
            }

            ResourceHandle objBackgroundImage = this.GetProxyPropertyValue<ResourceHandle>("BackgroundImage", this.BackgroundImage);
            if (objBackgroundImage != null)
            {
                objWriter.WriteAttributeString(WGAttributes.BackgroundImage, objBackgroundImage.ToString());
            }

            ImageLayout objImageLayout = this.GetProxyPropertyValue<ImageLayout>("BackgroundImageLayout", this.BackgroundImageLayout);
            if (this.ShouldRenderBackgroundImageLayout(objImageLayout))
            {
                objWriter.WriteAttributeString(WGAttributes.BackgroundImageLayout, ((int)objImageLayout).ToString());
            }

            if (this.ShouldRenderKeyFilter())
            {
                objWriter.WriteAttributeString(WGAttributes.KeyFilter, Convert.ToInt64(this.KeyFilter).ToString());
            }

            // If is delayed drawing and is not wg namespace
            if (this.IsDelayedDrawing && !this.UseWGNamespace)
            {
                objWriter.WriteAttributeString(WGAttributes.IsDelayedDrawing, "1");
            }

            if (!this.AutoDrawn)
            {
                objWriter.WriteAttributeString(WGAttributes.AutoDrawn, "0");
            }

            // Render the border style to the client
            BorderValue objBorderValue = new BorderValue();
            objBorderValue.Width = this.GetProxyPropertyValue<BorderWidth>("BorderWidth", this.BorderWidth);
            objBorderValue.Color = this.GetProxyPropertyValue<BorderColor>("BorderColor", this.BorderColor);
            objBorderValue.Style = this.GetProxyPropertyValue<BorderStyle>("BorderStyle", this.BorderStyle);

            if (this.ShouldRenderBorder(objBorderValue))
            {
                // Render the border according to the specific presentation layer
                objWriter.WriteAttributeString(WGAttributes.Border, objBorderValue.GetValue(objContext));
            }

            // Render error message if needed
            if (ShouldRenderErrorMessage())
            {
                objWriter.WriteAttributeText(WGAttributes.ErrorMessage, this.ErrorMessage);
                objWriter.WriteAttributeString(WGAttributes.ErrorIconPadding, this.ErrorIconPadding.ToString());
                objWriter.WriteAttributeString(WGAttributes.ErrorIconAlignment, this.ErrorIconAlignment.ToString());

                // Render an error icon if needed.
                ResourceHandle objErrorIcon = this.ErrorIcon;
                if (objErrorIcon != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.ErrorIcon, objErrorIcon.ToString());
                }
            }

            Font objFont = this.GetProxyPropertyValue<Font>("Font", this.Font);
            if (ShouldRenderFont(objFont))
            {
                objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(objFont));
            }

            Color objBackColor = this.GetProxyPropertyValue<Color>("BackColor", this.BackColor);
            if (ShouldRenderBackColor(objBackColor))
            {
                RenderBackColorAttribute(objWriter, objBackColor);
            }

            Color objForeColor = this.GetProxyPropertyValue<Color>("ForeColor", this.GetForeColor());
            if (ShouldRenderForeColor(objForeColor))
            {
                objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objForeColor));
            }

            // Get current padding value
            Padding objPadding = this.GetProxyPropertyValue<Padding>("Padding", this.Padding);
            if (ShouldRenderPaddingAttribute(objPadding))
            {
                if (objPadding.IsAll)
                {
                    if (objPadding.All != 0) objWriter.WriteAttributeString(WGAttributes.PaddingAll, objPadding.All.ToString());
                }
                else
                {
                    if (objPadding.Top != 0) objWriter.WriteAttributeString(WGAttributes.PaddingTop, objPadding.Top.ToString());
                    if (objPadding.Right != 0) objWriter.WriteAttributeString(WGAttributes.PaddingRight, objPadding.Right.ToString());
                    if (objPadding.Bottom != 0) objWriter.WriteAttributeString(WGAttributes.PaddingBottom, objPadding.Bottom.ToString());
                    if (objPadding.Left != 0) objWriter.WriteAttributeString(WGAttributes.PaddingLeft, objPadding.Left.ToString());
                }
            }

            // If parent supports child margins.
            if ((this.Parent != null && this.Parent.SupportChildMargins) || (this.Parent != null && this.Parent.WinFormsCompatibility.IsForbidDockMargin == false && this.Dock != DockStyle.None))
            {
                Padding objMargin = this.GetProxyPropertyValue<Padding>("Margin", this.Margin);
                // If the margin property has content.
                if (objMargin != this.DefaultMargin)
                {
                    if (objMargin.IsAll)
                    {
                        if (objMargin.All != 0) objWriter.WriteAttributeString(WGAttributes.MarginAll, objMargin.All.ToString());
                    }
                    else
                    {
                        objWriter.WriteAttributeString(WGAttributes.MarginTop, objMargin.Top.ToString());
                        if (objMargin.Right != 0) objWriter.WriteAttributeString(WGAttributes.MarginRight, objMargin.Right.ToString());
                        if (objMargin.Bottom != 0) objWriter.WriteAttributeString(WGAttributes.MarginBottom, objMargin.Bottom.ToString());
                        if (objMargin.Left != 0) objWriter.WriteAttributeString(WGAttributes.MarginLeft, objMargin.Left.ToString());
                    }
                }
            }

            // Render cursor if needed
            Cursor objCursor = this.GetProxyPropertyValue<Cursor>("Cursor", this.Cursor);
            if (objCursor != null)
            {
                objCursor.RenderCursor(objContext, objWriter);
            }

            // Renders the scoll position attributes.
            RenderScollPositionAttributes(objWriter, false);

            // Check if this is a button control - a control that may be accept button.
            if (this is IButtonControl)
            {
                objWriter.WriteAttributeString(WGAttributes.IsButtonControl, "1");
            }

            if (!GetProxyPropertyValue("SupportsKeyNavigation", this.SupportsKeyNavigation))
            {
                objWriter.WriteAttributeString(WGAttributes.SupportsKeyNavigation, "0");
            }

            // Renders the right to left attribute.
            RenderRightToLeftAttribute(objWriter, false);

            // Renders the draggable attribute.
            this.RenderDraggableAttribute(objContext, objWriter, false);

            // Renders the droppable attribute.
            this.RenderDroppableAttribute(objContext, objWriter, false);

            // Renders the resizable attribute.
            this.RenderResizableAttribute(objContext, objWriter, false);

            // Renders the selectable attribute.
            this.RenderSelectableAttribute(objContext, objWriter, false);

            if (this is IButtonControl)
            {
                objWriter.WriteAttributeString(WGAttributes.AcceptCotnrol, "1");
            }


            // Renders the selected indicator attribute.
            RenderSelectedIndicatorAttribute(objContext, objWriter, false);

            RenderAccessibleNameAttribute(objWriter, false);
            
            RenderEditModeAttirbute(objWriter, false);

            // Renders theme attribute
            RenderThemeAttribute(objContext, objWriter, false);

            RenderSkipMultiTheme(objWriter, false);
        }

        /// <summary>
        /// Renders the visual template.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter)
        {
            this.RenderVisualTemplate(objContext, objWriter, this.GetProxyPropertyValue<VisualTemplate>("VisualTemplate", this.VisualTemplate));
        }

        /// <summary>
        /// Renders the visual template.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objVisualTemplate">The obj visual template.</param>
        protected void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter, VisualTemplate objVisualTemplate)
        {
            if (objVisualTemplate != null)
            {
                objVisualTemplate.Render(objContext, objWriter);
            }
        }

        /// <summary>
        /// Renders the edit mode attirbute.
        /// </summary>
        /// <param name="objWriter">The object writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderEditModeAttirbute(IAttributeWriter objWriter, bool blnForceRender)
        {
            EditMode enmEditMode = this.EditControlMode;

            if (enmEditMode == Forms.EditMode.On || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ControlEditMode, enmEditMode == Forms.EditMode.On ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the enabled attribute.
        /// </summary>
        /// <param name="objWriter">The object writer.</param>
        protected virtual void RenderEnabledAttribute(IAttributeWriter objWriter)
        {
            if (!this.GetProxyPropertyValue<bool>("Enabled", this.EnabledInternal))
            {
                objWriter.WriteAttributeString(WGAttributes.Enabled, "0");
            }
        }

        /// <summary>
        /// Renders the scoll position attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSkipMultiTheme(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Write scrolling position
            if (blnForceRender || SkipMultiTheme != ControlSkipMultiTheme.None)
            {
                objWriter.WriteAttributeString(WGAttributes.SkipMultiTheme, SkipMultiTheme.ToString());
            }
        }

        /// <summary>
        /// Renders the scoll position attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderScollPositionAttributes(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Write scrolling position
            if (this.ScrollTop != 0 || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ScrollTop, this.ScrollTop.ToString());
            }
            if (this.ScrollLeft != 0 || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ScrollLeft, this.ScrollLeft.ToString());
            }
        }

        /// <summary>
        /// Determines whether to render extended tooltip. 
        /// Renders if at least one value is not empty, and both template name and tooltip key exist.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderExtendedToolTip()
        {
            // Get this ExtendedToolTip descriptor.
            ToolTipDescriptor objToolTipDescriptor = this.ExtendedToolTipDescriptor;

            if (objToolTipDescriptor != null)
            {
                string strTemplateName = objToolTipDescriptor.ToolTipTemplateName;
                string strToolTipKey = objToolTipDescriptor.ToolTipKey;

                if (!string.IsNullOrEmpty(strTemplateName) && !string.IsNullOrEmpty(strToolTipKey))
                {
                    // Iterate properties
                    foreach (KeyValuePair<string, string> objProperty in objToolTipDescriptor.ExtendedProperties)
                    {
                        // Return whether non-empty value found
                        if (!string.IsNullOrEmpty(objProperty.Value))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Renders the extended tooltip.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderExtendedToolTip(IAttributeWriter objWriter, bool blnForceRender)
        {
            string strExtendedToolTip = string.Empty;
            string strExtendedToolTipTemplateName = string.Empty;
            string strExtendedToolTipKey = string.Empty;

            // Get this ExtendedToolTip descriptor.
            ToolTipDescriptor objToolTipDescriptor = this.ExtendedToolTipDescriptor;

            // Get descriptor data. 
            if (objToolTipDescriptor != null)
            {
                strExtendedToolTip = objToolTipDescriptor.SerializedProperties;
                strExtendedToolTipTemplateName = objToolTipDescriptor.ToolTipTemplateName;
                strExtendedToolTipKey = objToolTipDescriptor.ToolTipKey;
            }

            // If necessary data exists, or it is forced to render..
            if ((!string.IsNullOrEmpty(strExtendedToolTipTemplateName) && !string.IsNullOrEmpty(strExtendedToolTipKey)) || blnForceRender)
            {
                objWriter.WriteAttributeText(WGAttributes.ExtendedToolTip, strExtendedToolTip);
                objWriter.WriteAttributeString(WGAttributes.ExtendedToolTipTemplateName, strExtendedToolTipTemplateName);
                objWriter.WriteAttributeString(WGAttributes.ExtendedToolTipKey, strExtendedToolTipKey);
            }
        }

        /// <summary>
        /// Renders the right to left attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">The BLN force render.</param>
        private void RenderRightToLeftAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Get RightToLeft value 
            int intRightToLeft = (int)this.RightToLeft;

            // Check if value is different from context RightToLeft
            if (blnForceRender || intRightToLeft != Convert.ToInt32(Context.RightToLeft))
            {
                objWriter.WriteAttributeString(WGAttributes.RightToLeft, intRightToLeft.ToString());
            }
        }

        /// <summary>
        /// Renders the draggable attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderDraggableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            DraggableOptions objDraggableOptions = this.GetProxyPropertyValue<DraggableOptions>("Draggable", this.DraggableInternal);

            // Render draggable targets
            if ((objDraggableOptions != null && objDraggableOptions.IsDraggable) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Draggable, (objDraggableOptions != null && objDraggableOptions.IsDraggable) ? "1" : "0");

                // Render the draggable options if it is true, and with no default values.
                if (objDraggableOptions != null && objDraggableOptions.IsDraggable && !objDraggableOptions.IsDefault())
                {
                    objWriter.WriteAttributeString(WGAttributes.DraggableParams, objDraggableOptions.ToRenderString());
                }
            }
        }

        /// <summary>
        /// Renders the droppable attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderDroppableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnDroppable = this.ControlDroppedHandler != null;

            // Render droppable targets
            if (blnDroppable || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Droppable, blnDroppable ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the selectable attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderSelectableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnSelectable = this.ControlSelectedHandler != null;

            // Render selectable targets
            if (blnSelectable || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Selectable, blnSelectable ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the resizable attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderResizableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            ResizableOptions objResizable = this.GetProxyPropertyValue<ResizableOptions>("Resizable", this.ResizableInternal);
            string strDirections = string.Empty;

            //Join string array to single string
            if (this.ResizableAllowedDirections != null)
            {
                strDirections = String.Join(",", this.ResizableAllowedDirections);
            }

            // Render resizable targets
            if ((objResizable != null && objResizable.IsResizable) || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Resizable, (objResizable != null && objResizable.IsResizable) ? "1" : "0");

                // If the direction string is null, set it to empty, to avoid exceptions.
                if (strDirections == null)
                {
                    strDirections = string.Empty;
                }

                // If there is a resizable object, with resizable true, with NON default values, render it.
                // Otherwise, render just the directions (if exists).
                if (objResizable != null && objResizable.IsResizable && !objResizable.IsDefault())
                {
                    objWriter.WriteAttributeString(WGAttributes.ResizableParams, strDirections + "|" + objResizable.ToRenderString());
                }
                else if (!string.IsNullOrEmpty(strDirections))
                {
                    objWriter.WriteAttributeString(WGAttributes.ResizableParams, strDirections + "|");
                }
                else if (blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.ResizableParams, "");
                }
            }
        }

        /// <summary>
        /// Renders the back color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objBackColor">Color of the obj back.</param>
        protected virtual void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor)
        {
            objWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(objBackColor));
        }

        /// <summary>
        /// Renders the selected indicator attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected void RenderSelectedIndicatorAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnSelectedIndicator = this.GetProxyPropertyValue<bool>("SelectedIndicator", this.SelectedIndicator);

            if (blnSelectedIndicator || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.SelectedIndicator, blnSelectedIndicator ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the Accessibility Name attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">The BLN force render.</param>
        private void RenderAccessibleNameAttribute(IAttributeWriter objWriter, bool blnForcRender)
        {
            if (this.Context.Config.AccessibilityMode)
            {
                // Get the stored name property
                string strName = this.AccessibleName;

                if (string.IsNullOrEmpty(strName))
                {
                    strName = this.AccessibleDescription;
                }

                // If name is empty
                if (string.IsNullOrEmpty(strName))
                {
                    // If name is not null get the name of the control
                    strName = this.Name;
                }

                if (!string.IsNullOrEmpty(strName) || blnForcRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.AccessibleName, strName);
                }
            }
        }

        /// <summary>
        /// Renders the color of the fore.
        /// </summary>
        protected virtual Color GetForeColor()
        {
            return this.ForeColor;
        }

        /// <summary>
        /// Indicates should render background image layout.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderBackgroundImageLayout(ImageLayout objImageLayout)
        {
            return objImageLayout != null;
        }

        /// <summary>
        /// Indicates if to render error message.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderErrorMessage()
        {
            return !string.IsNullOrEmpty(this.ErrorMessage);
        }

        /// <summary>
        /// Indicates if to render key filter.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderKeyFilter()
        {
            return this.KeyFilter != KeyFilter.All;
        }

        /// <summary>
        /// Indicates if to render padding attribute
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldRenderPaddingAttribute(Padding objPadding)
        {
            return this.DefaultPadding != objPadding;
        }

        /// <summary>
        /// Indicates if to render padding.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderPadding()
        {
            return this.DefaultPadding != this.Padding;
        }

        /// <summary>
        /// Shoulds the color of the render fore.
        /// </summary>
        /// <param name="objForeColor">Color of the obj fore.</param>
        /// <returns></returns>
        private bool ShouldRenderForeColor(Color objForeColor)
        {
            return objForeColor != this.DefaultForeColor;
        }

        /// <summary>
        /// Indicates if to render back color.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderBackColor(Color objBackColor)
        {
            return objBackColor != this.DefaultBackColor;
        }

        /// <summary>
        /// Shoulds the render registered timers.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderRegisteredTimers()
        {
            return this.RegisteredTimers != null;
        }

        /// <summary>
        /// Indicates if to render font.
        /// </summary>
        /// <returns></returns>
        private bool ShouldRenderFont(Font objFont)
        {
            return objFont != this.DefaultControlFont;
        }

        /// <summary>
        /// Check if conrtol should be rendered.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        protected virtual bool ShouldRenderControl(Control objControl)
        {
            return true;
        }

        /// <summary>
        /// Renders the component.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        void IRenderableComponent.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.RenderControl(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Pre-render control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected internal virtual void PreRenderControl(IContext objContext, long lngRequestID)
        {
            // Invoke contextual pre-render control event.
            ((IContextParams)this.Context).InvokeComponentMessage(this, new ComponentMessageEventArgs("PreRenderControl"));

            // Pre-renders controls.
            this.PreRenderControls(objContext, this.IsDirty(lngRequestID) ? 0 : lngRequestID);
        }

        /// <summary>
        /// Posts the render control.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected internal virtual void PostRenderControl(IContext objContext, long lngRequestID)
        {
            // Reset  params.
            this.ResetParams();

            // Post-renders controls.
            this.PostRenderControls(objContext, this.IsDirty(lngRequestID) ? 0 : lngRequestID);

        }

        /// <summary>
        /// Pre-renders controls.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        protected virtual void PreRenderControls(IContext objContext, long lngRequestID)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                objProxyComponent.PreRenderComponents(objContext, lngRequestID);
            }
            else
            {

                // Get controls count.
                int intControlsCount = this.Controls.Count;

                // Loop all controls.
                for (int intIndex = 0; intIndex < intControlsCount; intIndex += 1)
                {
                    // Get current control
                    Control objControl = Controls[intIndex];
                    if (objControl != null)
                    {
                        // Pre-render control.
                        objControl.PreRenderControl(objContext, lngRequestID);
                    }
                }
            }
        }

        /// <summary>
        /// Posts the render controls.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        protected virtual void PostRenderControls(IContext objContext, long lngRequestID)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                objProxyComponent.PostRenderComponents(objContext, lngRequestID);
            }
            else
            {
                // Get controls count.
                int intControlsCount = this.Controls.Count;

                // Loop all controls.
                for (int intIndex = 0; intIndex < intControlsCount; intIndex += 1)
                {
                    // Get current control
                    Control objControl = Controls[intIndex];
                    if (objControl != null)
                    {
                        // Post-render control.
                        objControl.PostRenderControl(objContext, lngRequestID);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the current control needs rendering and 
        /// continues to process sub tree/
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected internal virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // if control is dirty
            if (IsDirty(lngRequestID))
            {
                // check control is registered
                RegisterSelf();

                if (UseWGNamespace)
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.Prefix, this.MetadataTag, WGConst.Namespace);

                }
                else
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.ControlsPrefix, this.MetadataTag, WGConst.ControlsNamespace);
                }

                // add generic attributes
                RenderAttributes(objContext, (IAttributeWriter)objWriter);

                // renders positioning attributes
                RenderPositioning(objContext, (IAttributeWriter)objWriter, false);

                // If control content rendering is required
                if (this.ShouldRenderContentInternal())
                {
                    // render control
                    Render(objContext, objWriter, 0);
                }

                // Render component client events
                RenderComponentClientEvents(objContext, objWriter, lngRequestID);

                // close control element tag
                objWriter.WriteEndElement();
            }
            else
            {
                // if only control params are dirty
                if (IsDirtyAttributes(lngRequestID))
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);

                    // render control
                    RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);

                    // If control content rendering is required
                    if (this.ShouldRenderContentInternal())
                    {
                        // render control
                        RenderControls(objContext, objWriter, lngRequestID, true);
                    }

                    // close control element tag
                    objWriter.WriteEndElement();
                }
                else
                {
                    // If control content rendering is required
                    if (this.ShouldRenderContentInternal())
                    {
                        // render control
                        RenderControls(objContext, objWriter, lngRequestID, false);
                    }
                }
            }
        }

        /// <summary>
        /// Shoulds the content of the control.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool ShouldRenderContentInternal()
        {
            if (this.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
            {
                return true;
            }

            return this.ShouldRenderContent();
        }


        /// <summary>
        /// Shoulds the content of the control.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool ShouldRenderContent()
        {
            // Get visibility from the current control
            if (!this.GetState(ComponentState.Visible))
            {
                // Current control is invisible
                return false;
            }

            // If parent exists return it's should render content, otherwise return true.
            Control objParent = this.ParentInternal;
            if (objParent != null)
            {
                return objParent.ShouldRenderContentInternal();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnFullRedraw"></param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
        {
            this.RenderControls(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            ProxyComponent objProxyComponent = this.ProxyComponent;
            if (objProxyComponent != null)
            {
                objProxyComponent.RenderComponents(objContext, objWriter, lngRequestID);
            }
            else
            {
                bool blnReverseControls = this.ReverseControls;
                int intControlsCount = this.Controls.Count;

                // Loop all controls.
                for (int intIndex = blnReverseControls ? 0 : intControlsCount - 1; blnReverseControls ? intIndex < intControlsCount : intIndex > -1; intIndex += (blnReverseControls ? 1 : -1))
                {
                    // Get current control
                    Control objControl = Controls[intIndex];
                    if (objControl != null)
                    {
                        // Check if conrtol should be rendered.
                        if (this.ShouldRenderControl(objControl))
                        {
                            // Render control.
                            objControl.RenderControl(objContext, objWriter, lngRequestID);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// An abstract control method rendering 
        /// </summary>
        protected virtual void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // render child controls
            RenderControls(objContext, objWriter, lngRequestID, true);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            if (this.ForceChildRedraw)
            {
                objWriter.WriteAttributeString(WGAttributes.ForceChildRedraw, "1");
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeString(WGAttributes.KeyFilter, Convert.ToInt64(this.KeyFilter).ToString());

                // Renders the scoll position attributes.
                RenderScollPositionAttributes(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Renders the right to left attribute.
                RenderRightToLeftAttribute(objWriter, true);

                objWriter.WriteAttributeString(WGAttributes.Visible, Visible ? "1" : "0");

                // Renders the selected indicator attribute.
                RenderSelectedIndicatorAttribute(objContext, objWriter, true);

                // Render the visual template
                RenderVisualTemplate(objContext, objWriter);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
            {
                objWriter.WriteAttributeString(WGAttributes.Enabled, EnabledInternal ? "1" : "0");
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                // Render positioning 
                this.RenderPositioning(objContext, objWriter, true);

                // Renders theme attribute
                RenderThemeAttribute(objContext, (IAttributeWriter)objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
            {
                objWriter.WriteAttributeText(WGAttributes.ToolTip, this.ToolTip);
            }

            // Render extended tooltip
            if (IsDirtyAttributes(lngRequestID, AttributeType.ExtendedToolTip))
            {
                RenderExtendedToolTip(objWriter, true);
            }

            // Render skip multi theme.
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderSkipMultiTheme(objWriter, true);
            }

            // Render component update attributes.
            this.RenderComponentUpdateAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Error))
            {
                string strErrorMessage = this.ErrorMessage;
                if (!string.IsNullOrEmpty(strErrorMessage))
                {
                    objWriter.WriteAttributeText(WGAttributes.ErrorMessage, strErrorMessage);
                    objWriter.WriteAttributeString(WGAttributes.ErrorIconPadding, this.ErrorIconPadding.ToString());
                    objWriter.WriteAttributeString(WGAttributes.ErrorIconAlignment, this.ErrorIconAlignment.ToString());
                }
                else
                {
                    objWriter.WriteAttributeString(WGAttributes.ErrorMessage, string.Empty);
                }

                // Render an error icon if needed or clear the error icon.
                ResourceHandle objErrorIcon = this.ErrorIcon;
                if (objErrorIcon != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.ErrorIcon, objErrorIcon.ToString());
                }
                else
                {
                    objWriter.WriteAttributeString(WGAttributes.ErrorIcon, string.Empty);
                }
            }

            // Write cursor
            Cursor objCursor = this.Cursor;
            if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw) && objCursor != null)
            {
                objCursor.RenderCursor(objContext, objWriter);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Drag))
            {
                // Renders the draggable attribute.
                this.RenderDraggableAttribute(objContext, objWriter, true);

                // Renders the droppable attribute.
                this.RenderDroppableAttribute(objContext, objWriter, true);

                // Renders the resizable attribute.
                this.RenderResizableAttribute(objContext, objWriter, true);

                // Renders the selectable attribute.
                this.RenderSelectableAttribute(objContext, objWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Accessibility))
            {
                this.RenderAccessibleNameAttribute(objWriter, true);
            }
        }

        #endregion

        #region Events


        /// <summary>
        /// Determines whether [is critical event] [the specified obj event key].
        /// </summary>
        /// <param name="objEventKey">The event key.</param>
        /// <returns>
        /// 	<c>true</c> if [is critical event] [the specified obj event key]; otherwise, <c>false</c>.
        /// </returns>
        protected internal bool IsCriticalEvent(SerializableEvent objEventKey)
        {
            if (objEventKey != null)
            {
                return this.HasHandler(objEventKey);
            }

            return false;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // invoke base method
            base.FireEvent(objEvent);

            // Define an empty container object.
            IContainerControl objContainer = null;

            // Define an empty application context.
            IApplicationContext objApplicationContext = null;
            ISessionRegistry objSessionRegistry = null;

            // Select event type
            switch (objEvent.Type)
            {
                case "Click":
                    OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    break;
                case "DoubleClick":
                    OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    OnDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
                    break;
                case "KeyDown":
                    FireKeyDown(objEvent);
                    break;
                case "GotFocus":
                    // Get container.
                    objContainer = this.GetContainerControlInternal();
                    if (objContainer != null)
                    {
                        // Check if this control is not the active cotnrol.
                        if (objContainer.ActiveControl != this)
                        {
                            // Activate this control.
                            objContainer.ActivateControl(this);

                            // Raise the got focus event.
                            this.OnGotFocus(EventArgs.Empty);
                        }
                    }

                    // Get application context.
                    objApplicationContext = this.Context as IApplicationContext;
                    if (objApplicationContext != null)
                    {
                        // Preserve this control as focused control at context.
                        objApplicationContext.SetFocused(this, false);
                    }
                    break;
                case "LostFocus":
                    // Get container.
                    objContainer = this.GetContainerControlInternal();
                    if (objContainer != null)
                    {
                        // Check if this control is not the active cotnrol.
                        if (objContainer.ActiveControl != this)
                        {
                            // Activate this control.
                            objContainer.ActivateControl(this);
                        }
                    }

                    // Raise the lost focus event.
                    OnLostFocus(new EventArgs());

                    // Get application context.
                    objApplicationContext = this.Context as IApplicationContext;
                    if (objApplicationContext != null)
                    {
                        // Check if this control is the focsed cotnrol at context.
                        if (objApplicationContext.GetFocused() == this)
                        {
                            // Clear focused control at context.
                            objApplicationContext.SetFocused(null, false);
                        }
                    }
                    break;
                case "Resize":
                    double dblWidth = Convert.ToDouble(objEvent["Width"], System.Globalization.CultureInfo.InvariantCulture);
                    double dblHeight = Convert.ToDouble(objEvent["Height"], System.Globalization.CultureInfo.InvariantCulture);

                    if (this.SetBounds(0, 0, Convert.ToInt32(dblWidth), Convert.ToInt32(dblHeight), BoundsSpecified.Size, true))
                    {
                        OnResizeInternal(new LayoutEventArgs(true, false, true));
                    }
                    break;
                case "Move":
                    double dblLeft = -1;
                    double dblTop = -1;

                    if (CommonUtils.TryParse(objEvent["Left"], out dblLeft) && CommonUtils.TryParse(objEvent["Top"], out dblTop))
                    {
                        if (this.SetBounds(Convert.ToInt32(dblLeft), Convert.ToInt32(dblTop), 0, 0, BoundsSpecified.Location, true))
                        {
                            OnLocationChangedInternal(new LayoutEventArgs(true, false, true));
                        }
                    }
                    break;
                case "ScrollPositionChanged":
                    double dblResult = 0;

                    if (!string.IsNullOrEmpty(objEvent[WGAttributes.ScrollTop]))
                    {
                        int tempScrollTopInternal = 0;
                        CommonUtils.TryParse(objEvent[WGAttributes.ScrollTop], out dblResult);
                        tempScrollTopInternal = Convert.ToInt32(dblResult);
                        this.SetScrollTop(tempScrollTopInternal);
                    }

                    if (!string.IsNullOrEmpty(objEvent[WGAttributes.ScrollTop]))
                    {
                        int tempScrollLeftInternal = 0;
                        CommonUtils.TryParse(objEvent[WGAttributes.ScrollLeft], out dblResult);
                        tempScrollLeftInternal = Convert.ToInt32(dblResult);
                        this.SetScrollLeft(tempScrollLeftInternal);
                    }
                    break;
                case "ControlSelected":
                    objSessionRegistry = this.Context as ISessionRegistry;
                    if (objSessionRegistry != null)
                    {
                        string strSelected = objEvent[WGAttributes.Selected];
                        if (!string.IsNullOrEmpty(strSelected))
                        {
                            string[] objControlIDs = strSelected.Split(',');
                            if (objControlIDs.Length > 0)
                            {
                                Control[] objSelectedControls = new Control[objControlIDs.Length];

                                for (int i = 0; i < objControlIDs.Length; i++)
                                {
                                    Control objControl = objSessionRegistry.GetRegisteredComponent(objControlIDs[i]) as Control;

                                    if (objControl != null)
                                    {
                                        objSelectedControls[i] = objControl;
                                    }
                                }

                                this.OnControlsSelected(new ControlsEventArgs(objSelectedControls));
                            }
                        }
                    }
                    break;
                case "ControlDropped":
                    objSessionRegistry = this.Context as ISessionRegistry;
                    if (objSessionRegistry != null)
                    {
                        string strDropped = objEvent[WGAttributes.DroppedControl];
                        if (!string.IsNullOrEmpty(strDropped))
                        {
                            Control objControl = objSessionRegistry.GetRegisteredComponent(strDropped) as Control;
                            if (objControl != null)
                            {
                                this.OnControlDropped(new ControlEventArgs(objControl));
                            }
                        }
                    }
                    break;
                case "ContextualToolbarEditor":
                    ContextualToolbar.ContextualToolbar.FireEvent(this, objEvent);
                    break;
                case WGAttributes.ControlEditMode:
                    if (objEvent["Attr.CancelEditingMode"] == "1")
                    {
                        SetEditControlMode(EditMode.Off, true);
                    }
                    else
                    {
                        ProcessEditModeValue(objEvent);
                    }
                    break;
                case "VisualTemplate":
                    if (this.VisualTemplate != null)
                    {
                        this.VisualTemplate.FireEvent(this, objEvent);
                    }
                    break;
            }
        }

        /// <summary>
        /// Sets the edit control mode.
        /// </summary>
        /// <param name="enmEditMode">The enm edit mode.</param>
        /// <param name="blnFromClient">if set to <c>true</c> [BLN from client].</param>
        private void SetEditControlMode(EditMode enmEditMode, bool blnFromClient)
        {
            if (menmEditMode != enmEditMode)
            {
                menmEditMode = enmEditMode;
                if (!blnFromClient)
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Processes the edit mode value.
        /// </summary>
        /// <param name="objEvent">The object event.</param>
        private void ProcessEditModeValue(IEvent objEvent)
        {
            EditValueEditingEventArgs objEditValueEditingEventArgs = new EditValueEditingEventArgs(objEvent);
            OnEditValueEditing(objEditValueEditingEventArgs);

            if (!objEditValueEditingEventArgs.Cancel)
            {
                CommitValueEditing(objEditValueEditingEventArgs.FormattedValue);
            }

            this.EditControlMode = objEditValueEditingEventArgs.ExitEditMode ? EditMode.Off : Forms.EditMode.On;
        }

        /// <summary>
        /// Commits the value editing.
        /// </summary>
        /// <param name="objFormattedValue">The object formatted value.</param>
        protected virtual void CommitValueEditing(object objFormattedValue)
        {
            
        }

        /// <summary>
        /// Raises the <see cref="E:EditValueEditing" /> event.
        /// </summary>
        /// <param name="objEditValueEditingEventArgs">The <see cref="EditValueEditingEventArgs"/> instance containing the event data.</param>
        protected internal virtual void OnEditValueEditing(EditValueEditingEventArgs objEditValueEditingEventArgs)
        {
            EventHandler<EditValueEditingEventArgs> objHandler = GetHandler(Control.ControlEditingEvent) as EventHandler<EditValueEditingEventArgs>;

            if (objHandler != null)
            {
                objHandler(this, objEditValueEditingEventArgs);
            }
        }
        
        /// <summary>
        /// Fires the control added event.
        /// </summary>
        /// <param name="objControl">Added control.</param>
        internal void FireControlAdded(Control objControl)
        {
            if (this.ControlAddedHandler != null)
            {
                this.ControlAddedHandler(this, new ControlEventArgs(objControl));
            }
        }

        /// <summary>
        /// Fires the control removed event.
        /// </summary>
        /// <param name="objControl">Removed control.</param>
        internal void FireControlRemoved(Control objControl)
        {
            if (this.ControlRemovedHandler != null)
            {
                this.ControlRemovedHandler(this, new ControlEventArgs(objControl));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
        /// event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnClick(EventArgs objEventArgs)
        {
            MouseEventArgs objMouseEventArgs = objEventArgs as MouseEventArgs;
            if (objMouseEventArgs == null)
            {
                objMouseEventArgs = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
            }

            // Raise mouse down evnet.
            OnMouseDown(objMouseEventArgs);

            // Check if mouse click was with the left button.
            if (objMouseEventArgs.Button == MouseButtons.Left || this.ShouldRaiseClickOnRightMouseDown)
            {
                // Raise click evnet.
                OnMouseClick(objMouseEventArgs);
            }

            // Raise mouse up evnet.
            OnMouseUp(objMouseEventArgs);
        }


        /// <summary>
        /// Raises the <see cref="E:ControlAdded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnControlAdded(ControlEventArgs e)
        {
            if (!this.DesignMode)
            {
                // Validate added control.
                if (e.Control != null)
                {
                    // Applies the pre release dock fill compatibility.
                    e.Control.ApplyPreReleaseDockFillCompatibility();
                }
            }

            ControlEventHandler objEventHandler = this.ControlAddedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Applies the pre release dock fill compatibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual void ApplyPreReleaseDockFillCompatibility()
        {
            // Check if added control has a fill docking.
            if (this.IsFillDocked(this.Dock))
            {
                // Check pre release dock fill compatibility.
                if (this.Context != null && this.Context.Config.IsFeatureEnabled("PreReleaseDockFillCompatibility", false))
                {
                    // Bring control to front.
                    this.BringToFront();
                }
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.ParentChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CursorChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnCursorChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CursorChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlsSelected"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlsEventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnControlsSelected(ControlsEventArgs e)
        {
            ControlsEventHandler objEventHandler = this.ControlSelectedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlDropped"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnControlDropped(ControlEventArgs e)
        {
            ControlEventHandler objEventHandler = this.ControlDroppedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Leave"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnLeave(EventArgs e)
        {
            EventHandler objEventHandler = this.LeaveHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Enter"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnEnter(EventArgs e)
        {
            EventHandler objEventHandler = this.EnterHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            KeyEventHandler objEventHandler = this.KeyDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnKeyPress(KeyPressEventArgs e)
        {
            KeyPressEventHandler objEventHandler = this.KeyPressHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
        /// Implemented by design as KeyPress (Use KeyPress instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [Obsolete("Implemented by design as KeyPress(Use KeyPress instead).")]
        protected virtual void OnKeyUp(KeyEventArgs e)
        {
            KeyEventHandler objEventHandler = this.KeyUpHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseClick"></see> event.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnMouseClick(MouseEventArgs e)
        {
            EventHandler objClickHandler = (EventHandler)GetHandler(Control.ClickEvent);
            if (objClickHandler != null)
            {
                objClickHandler(this, e);
            }

            MouseEventHandler objMouseEventHandler = (MouseEventHandler)GetHandler(Control.MouseClickEvent);
            if (objMouseEventHandler != null)
            {
                objMouseEventHandler(this, e);
            }

        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
        /// Implemented by design as Click (Use Click instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>            
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            MouseEventHandler objEventHandler = this.MouseUpHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDoubleClick"></see> event.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnMouseDoubleClick(MouseEventArgs e)
        {
            EventHandler objEventHandler = this.DoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
        /// Implemented by design as Click (Use Click instead).
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [Obsolete("Implemented by design as Click (Use Click instead).")]
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            MouseEventHandler objEventHandler = this.MouseDownHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ControlRemoved"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ControlEventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnControlRemoved(ControlEventArgs e)
        {
            ControlEventHandler objEventHandler = this.ControlRemovedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Shoulds the perform container validation.
        /// </summary>
        /// <returns></returns>
        internal virtual bool ShouldPerformContainerValidation()
        {
            return this.GetStyle(ControlStyles.ContainerControl);
        }

        /// <summary>
        /// Gets a value indicating whether [should auto validate].
        /// </summary>
        /// <value><c>true</c> if [should auto validate]; otherwise, <c>false</c>.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool ShouldAutoValidate
        {
            get
            {
                return (GetAutoValidateForControl(this) != AutoValidate.Disable);
            }
        }

        /// <summary>
        /// Performs the container validation.
        /// </summary>
        /// <param name="validationConstraints">The validation constraints.</param>
        /// <returns></returns>
        internal bool PerformContainerValidation(ValidationConstraints validationConstraints)
        {
            bool blnFlag = false;
            foreach (Control objControl in this.Controls)
            {
                if ((((validationConstraints & ValidationConstraints.ImmediateChildren) != ValidationConstraints.ImmediateChildren) && objControl.ShouldPerformContainerValidation()) && objControl.PerformContainerValidation(validationConstraints))
                {
                    blnFlag = true;
                }
                if ((((((validationConstraints & ValidationConstraints.Selectable) != ValidationConstraints.Selectable) || objControl.GetStyle(ControlStyles.Selectable)) && (((validationConstraints & ValidationConstraints.Enabled) != ValidationConstraints.Enabled) || objControl.Enabled)) && ((((validationConstraints & ValidationConstraints.Visible) != ValidationConstraints.Visible) || objControl.Visible) && (((validationConstraints & ValidationConstraints.TabStop) != ValidationConstraints.TabStop) || objControl.TabStop))) && objControl.PerformControlValidation(true))
                {
                    blnFlag = true;
                }
            }
            return blnFlag;
        }

        /// <summary>
        /// Performs the control validation.
        /// </summary>
        /// <param name="bulkValidation">if set to <c>true</c> [bulk validation].</param>
        /// <returns></returns>
        internal bool PerformControlValidation(bool bulkValidation)
        {
            if (this.CausesValidation)
            {
                if (this.NotifyValidating())
                {
                    return true;
                }
                if (bulkValidation)
                {
                    this.NotifyValidated();
                }
                else
                {
                    try
                    {
                        this.NotifyValidated();
                    }
                    catch (Exception objException)
                    {
                        Application.OnThreadException(objException);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        internal void OnLocationChangedInternal(LayoutEventArgs objEventArgs)
        {
            // Check whether parent should be invalidated.
            if (objEventArgs.ShouldUpdateParent)
            {
                // Invalidate parent's layout.
                this.InvalidateParentLayout(objEventArgs);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnLocationChanged(LayoutEventArgs e)
        {
            EventHandler objEventHandler = this.LocationChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Fires the key down event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        internal void FireKeyDown(IEvent objEvent)
        {
            Keys enmKeys = CreateKeys(objEvent);

            // Raise key down event
            OnKeyDown(new KeyEventArgs(enmKeys));
            OnKeyPress(new KeyPressEventArgs((char)enmKeys));
            OnKeyUp(new KeyEventArgs(enmKeys));

            // Check if help requested is attached and that this is an F1 keydown
            if (HelpRequestedHandler != null && enmKeys == Keys.F1)
            {
                // Raise the help requested event
                OnHelpRequested(new HelpEventArgs(new Point(0, 0)));
            }
        }

        /// <summary>
        /// Creates keys from event.
        /// </summary>
        internal static Keys CreateKeys(IEvent objEvent)
        {
            // Parse the key down event key code.
            Keys enmKeys = objEvent.KeyCode;

            // Check if the alt key was pressed.
            if (objEvent.AltKey)
            {
                enmKeys |= Keys.Alt;
            }

            // Check if the control key was pressed.
            if (objEvent.ControlKey)
            {
                enmKeys |= Keys.Control;
            }

            // Check if the shift key was pressed.
            if (objEvent.ShiftKey)
            {
                enmKeys |= Keys.Shift;
            }

            return enmKeys;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();

            if (this.HasClientHandler("Click"))
            {
                objEvents.Set(WGEvents.Click);
            }

            if (this.HasClientHandler("DoubleClick"))
            {
                objEvents.Set(WGEvents.DoubleClick);
            }

            if (this.HasClientHandler("KeyDown"))
            {
                objEvents.Set(WGEvents.KeyDown);
            }

            if (this.HasClientHandler("GotFocus"))
            {
                objEvents.Set(WGEvents.GotFocus);
            }

            if (this.HasClientHandler("LostFocus"))
            {
                objEvents.Set(WGEvents.LostFocus);
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // Check if one of the click handlers is registered.
            if (this.HasHandler(Control.ClickEvent) || this.HasHandler(Control.MouseClickEvent) ||
                this.HasHandler(Control.MouseDownEvent) || this.HasHandler(Control.MouseUpEvent))
            {
                objEvents.Set(WGEvents.Click);

                // Check if this control support raise click event on right click
                if (this.ShouldRaiseClickOnRightMouseDown)
                {
                    objEvents.Set(WGEvents.RightClick);
                }
            }
            if (this.DoubleClickHandler != null) objEvents.Set(WGEvents.DoubleClick);
            if (this.KeyDownHandler != null) objEvents.Set(WGEvents.KeyDown);
            if (this.KeyUpHandler != null) objEvents.Set(WGEvents.KeyDown);
            if (this.KeyPressHandler != null) objEvents.Set(WGEvents.KeyDown);

            if (this.SupportsFocusEvents)
            {
                if (this.GotFocusHandler != null) objEvents.Set(WGEvents.GotFocus);
                if (this.LostFocusHandler != null) objEvents.Set(WGEvents.LostFocus);
            }

            if (this.TextChangedHandler != null || this.ValidatingHandler != null || this.ValidatedHandler != null)
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            if (this.ResizeHandler != null || (ParentInternal != null && ParentInternal.AutoSize)) objEvents.Set(WGEvents.SizeChange);
            if (this.LocationChangedHandler != null) objEvents.Set(WGEvents.LocationChange);
            if (this.EnterHandler != null) objEvents.Set(WGEvents.Enter);
            if (this.LeaveHandler != null) objEvents.Set(WGEvents.Leave);

            objEvents.Set(GetProxyPropertyValue<CriticalEventsData>("GetCriticalEventsData", objEvents));

            return objEvents;
        }

        #endregion

        #region Positioning

        /// <summary>
        /// Gets the auto validate for control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns></returns>
        internal static AutoValidate GetAutoValidateForControl(Control objControl)
        {
            ContainerControl objParentContainerControl = objControl.ParentContainerControl;
            if (objParentContainerControl == null)
            {
                return AutoValidate.EnablePreventFocusChange;
            }
            return objParentContainerControl.AutoValidate;
        }

        internal protected void RenderMinMaxSizeAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            #region Minimum and Maximum size

            // Renders control's minimum width.
            if (this.MinimumSize.Width != this.DefaultMinimumSize.Width)
            {
                objWriter.WriteAttributeString(WGAttributes.MinimumWidth, this.MinimumSize.Width.ToString());
            }

            // Renders control's minimum height.
            if (this.MinimumSize.Height != this.DefaultMinimumSize.Height)
            {
                objWriter.WriteAttributeString(WGAttributes.MinimumHeight, this.MinimumSize.Height.ToString());
            }

            // Renders control's maximum width.
            if (this.MaximumSize.Width != this.DefaultMaximumSize.Width)
            {
                objWriter.WriteAttributeString(WGAttributes.MaximumWidth, this.MaximumSize.Width.ToString());
            }

            // Renders control's maximum height.
            if (this.MaximumSize.Height != this.DefaultMaximumSize.Height)
            {
                objWriter.WriteAttributeString(WGAttributes.MaximumHeight, this.MaximumSize.Height.ToString());
            }

            #endregion
        }

        /// <summary>
        /// Renders the theme.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="objWriter">The object writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected virtual void RenderThemeAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            if (VWGContext.Current.SupportsMultipleThemes)
            {
                string strTheme = this.GetProxyPropertyValue<string>("Theme", this.Theme);

                if (strTheme != "Inherit" || blnForceRender)
                {
                    objWriter.WriteAttributeString(WGAttributes.Theme, strTheme != "Inherit" ? strTheme : string.Empty);
                }
            }
        }

        /// <summary>
        /// Renders positioning
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderPositioning(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            // Is not a positioned object
            if (HasPositioning)
            {
                RenderMinMaxSizeAttributes(objContext, objWriter);

                // Check if current control is contained on a flow layout panel.
                if (this.Parent is FlowLayoutPanel)
                {
                    // Render control's size/
                    this.RenderWidth(objContext, objWriter);
                    this.RenderHeight(objContext, objWriter);
                }
                else
                {
                    // Get docking value.
                    DockStyle enmDockStyle = this.GetProxyPropertyValue<DockStyle>("Dock", this.Dock);

                    // Check dock style.
                    if (enmDockStyle == DockStyle.None)
                    {
                        // Render anchoring style.
                        RenderAnchoring(objContext, objWriter, this.GetProxyPropertyValue<AnchorStyles>("Anchor", this.Anchor), false);
                    }
                    else if (blnForceRender)
                    {
                        // Render anchoring style.
                        RenderAnchoring(objContext, objWriter, AnchorStyles.None, true);
                    }

                    // Render docking style.
                    RenderDocking(objContext, objWriter, enmDockStyle, blnForceRender);
                }
            }
        }

        /// <summary>
        /// Renders the docking.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="enmDockStyle">The dock style.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected virtual void RenderDocking(IContext objContext, IAttributeWriter objWriter, DockStyle enmDockStyle, bool blnForceRender)
        {
            switch (enmDockStyle)
            {
                // fill docking style
                case DockStyle.Fill:
                    objWriter.WriteAttributeString(WGAttributes.Docking, "F");
                    break;

                // top docking style
                case DockStyle.Top:
                    objWriter.WriteAttributeString(WGAttributes.Docking, WGAttributes.Top);
                    RenderHeight(objContext, objWriter);
                    break;

                // bottom docking style
                case DockStyle.Bottom:
                    objWriter.WriteAttributeString(WGAttributes.Docking, WGAttributes.Bottom);
                    RenderHeight(objContext, objWriter);
                    break;

                // left docking style
                case DockStyle.Left:
                    objWriter.WriteAttributeString(WGAttributes.Docking, objContext.ShouldApplyMirroring ? WGAttributes.Right : WGAttributes.Left);
                    RenderWidth(objContext, objWriter);
                    break;

                // right docking style
                case DockStyle.Right:
                    objWriter.WriteAttributeString(WGAttributes.Docking, objContext.ShouldApplyMirroring ? WGAttributes.Left : WGAttributes.Right);
                    RenderWidth(objContext, objWriter);
                    break;
                default:
                    if (blnForceRender)
                    {
                        // Render empty docking - for update mode.
                        objWriter.WriteAttributeString(WGAttributes.Docking, string.Empty);
                    }
                    break;
            }
        }

        /// <summary>
        /// Renders the anchoring.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="enmAnchorStyle">The anchor style.</param>
        /// <param name="blnForceEmptyRender">if set to <c>true</c> [BLN force empty render].</param>
        protected virtual void RenderAnchoring(IContext objContext, IAttributeWriter objWriter, AnchorStyles enmAnchorStyle, bool blnForceEmptyRender)
        {
            // Define default empty anchoring.
            string strAnchoring = string.Empty;

            // Check if should force empty rendering.
            if (!blnForceEmptyRender)
            {
                // Check if the control's parent is table lay out panel.
                bool blnContainedInTableLayoutPanel = (this.Parent is TableLayoutPanel);

                // Define horizontal and vertical flags.
                bool blnHorzAnchoring = false;
                bool blnVertAnchoring = false;

                // Get location.
                Point objLocation = this.GetProxyPropertyValue<Point>("Location", new Point(mintLeft, mintTop));

                if (this.IsLeftAnchored(enmAnchorStyle))
                {
                    strAnchoring += WGAttributes.Left;
                    objWriter.WriteAttributeString(WGAttributes.Left, (blnContainedInTableLayoutPanel ? "0" : objLocation.X.ToString()));
                    blnHorzAnchoring = true;
                }

                if (this.IsRightAnchored(enmAnchorStyle))
                {
                    strAnchoring += WGAttributes.Right;
                    objWriter.WriteAttributeString(WGAttributes.Right, (blnContainedInTableLayoutPanel ? "0" : LayoutRight.ToString()));
                    blnHorzAnchoring = true;
                }

                if (this.IsTopAnchored(enmAnchorStyle))
                {
                    strAnchoring += WGAttributes.Top;
                    objWriter.WriteAttributeString(WGAttributes.Top, (blnContainedInTableLayoutPanel ? "0" : objLocation.Y.ToString()));
                    blnVertAnchoring = true;
                }

                if (this.IsBottomAnchored(enmAnchorStyle))
                {
                    strAnchoring += WGAttributes.Bottom;
                    objWriter.WriteAttributeString(WGAttributes.Bottom, (blnContainedInTableLayoutPanel ? "0" : LayoutBottom.ToString()));
                    blnVertAnchoring = true;
                }

                if (!blnHorzAnchoring)
                {
                    strAnchoring += "H";
                    objWriter.WriteAttributeString(WGAttributes.Left, this.CenteredLeft.ToString());
                }

                if (!blnVertAnchoring)
                {
                    strAnchoring += "V";
                    objWriter.WriteAttributeString(WGAttributes.Top, this.CenteredTop.ToString());
                }

                // Write dimensions
                RenderHeight(objContext, objWriter);
                RenderWidth(objContext, objWriter);
            }

            // Render anchoring attribute.
            objWriter.WriteAttributeString(WGAttributes.Anchoring, strAnchoring);
        }

        /// <summary>
        /// Renders the height.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <remarks>This is a preliminary interface and is subject for change.</remarks>
        internal virtual void RenderHeight(IContext objContext, IAttributeWriter objWriter)
        {
            // Get size object.
            Size objSize = this.GetProxyPropertyValue<Size>("Size", new Size(0, this.GetCalculatedHeight(false)));

            // Render height attribute.
            objWriter.WriteAttributeString(WGAttributes.Height, objSize.Height.ToString());
        }

        /// <summary>
        /// Renders the width.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <remarks>This is a preliminary interface and is subject for change.</remarks>
        internal virtual void RenderWidth(IContext objContext, IAttributeWriter objWriter)
        {
            // Get size object.
            Size objSize = this.GetProxyPropertyValue<Size>("Size", new Size(this.GetCalculatedWidth(false), 0));

            // Render width attribute.
            objWriter.WriteAttributeString("W", objSize.Width.ToString());
        }

        #endregion

        #region Focus Related

        /// <summary>
        /// Gets the container control 
        /// </summary>
        /// <returns></returns>
        internal IContainerControl GetContainerControlInternal()
        {
            Control objControl = this;

            // Get the container control
            if ((objControl != null) && this.IsContainerControl)
            {
                objControl = objControl.ParentInternal;
            }

            // Gets the focus management control
            while ((objControl != null) && !Control.IsFocusManagingContainerControl(objControl))
            {
                objControl = objControl.ParentInternal;
            }
            return (IContainerControl)objControl;
        }


        /// <summary>
        /// Gets a flag indicating if a control can manage focus
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <returns>
        /// 	<c>true</c> if [is focus managing container control] [the specified obj control]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsFocusManagingContainerControl(Control objControl)
        {
            return (((objControl.menmControlStyle & ControlStyles.ContainerControl) == ControlStyles.ContainerControl) && (objControl is IContainerControl));

        }

        /// <summary>
        /// Gets a flag indicating if this is a container control
        /// </summary>
        internal virtual bool IsContainerControl
        {
            get
            {
                return false;
            }
        }
        /// <summary>Gets a value indicating whether the control, or one of its child controls, currently has the input focus.</summary>
        /// <returns>true if the control or one of its child controls currently has the input focus; otherwise, false.</returns>
        [SRDescription("ControlContainsFocusDescr")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool ContainsFocus
        {
            get
            {
                // Get the current context
                IContext objContext = this.Context;
                if (objContext != null)
                {
                    // Get context active form.
                    Form objActiveForm = objContext.ActiveForm as Form;
                    if (objActiveForm != null)
                    {
                        // In case that this is the active form, return true.
                        if (this == objActiveForm)
                        {
                            return true;
                        }
                        else
                        {
                            // Get the active control on the active form
                            Control objActiveControl = objActiveForm.ActiveControl;
                            if (objActiveControl != null)
                            {
                                // In case that this is the active control on the active form, return true.
                                if (this == objActiveControl)
                                {
                                    return true;
                                }
                                else
                                {
                                    // Check whether this control contains the active control on the active form.
                                    return this.Contains(objActiveControl);
                                }
                            }
                        }
                    }
                }

                return false;
            }
        }



        /// <summary>Gets a value indicating whether the control has input focus.</summary>
        /// <returns>true if the control has focus; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.Browsable(false), SRDescription("ControlFocusedDescr"), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool Focused
        {
            get
            {
                IApplicationContext objApplicationContext = this.Context as IApplicationContext;
                if (objApplicationContext != null)
                {
                    return objApplicationContext.IsFocused(this);
                }
                return false;
            }
        }


        /// <summary>
        /// Sets focus to this control
        /// </summary>
        /// <returns></returns>
        public bool Focus()
        {
            // Get the owner form
            Form objForm = this.Form;

            // If form is valid
            if (objForm != null)
            {
                // If form is visible
                if (objForm.Visible)
                {
                    // If the form does not have modal dialog opened
                    if (!objForm.HasModalWindows)
                    {
                        // Set focus to the control
                        return this.FocusInternal();
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Focuses the internal.
        /// </summary>
        /// <returns></returns>
        internal virtual bool FocusInternal()
        {
            if (this.CanFocus)
            {
                IApplicationContext objApplicationContext = VWGContext.Current as IApplicationContext;

                if (objApplicationContext != null)
                {
                    // Check that current focused control is different from this.
                    if (objApplicationContext.GetFocused() != this)
                    {
                        // Set focus.
                        objApplicationContext.SetFocused(this, true);

                        // Raise the on got focus event
                        this.OnGotFocus(EventArgs.Empty);
                    }
                }
            }
            if (this.Focused && (this.ParentInternal != null))
            {
                IContainerControl objContainerControlInternal = this.ParentInternal.GetContainerControlInternal();
                if (objContainerControlInternal != null)
                {
                    if (objContainerControlInternal is ContainerControl)
                    {
                        ((ContainerControl)objContainerControlInternal).SetActiveControlInternal(this);
                    }
                    else
                    {
                        objContainerControlInternal.ActiveControl = this;
                    }
                }
            }
            return this.Focused;
        }

        /// <summary>
        /// Notifies the validated.
        /// </summary>
        private void NotifyValidated()
        {
            this.OnValidated(EventArgs.Empty);
        }

        /// <summary>
        /// Notifies the validation result.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="ev">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        internal virtual void NotifyValidationResult(object sender, CancelEventArgs ev)
        {
            this.ValidationCancelled = ev.Cancel;
        }

        /// <summary>
        /// Notifies the validating.
        /// </summary>
        /// <returns></returns>
        private bool NotifyValidating()
        {
            CancelEventArgs e = new CancelEventArgs();
            this.OnValidating(e);
            return e.Cancel;
        }

        /// <summary>
        /// Raises the enter event
        /// </summary>
        internal void NotifyEnter()
        {
            this.OnEnter(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the leave event
        /// </summary>
        internal void NotifyLeave()
        {
            this.OnLeave(EventArgs.Empty);
        }

        /// <summary>Invalidates the entire surface of the control and causes the control to be redrawn.</summary>
        public void Invalidate()
        {
            this.Invalidate(false);
        }

        /// <summary>Invalidates a specific region of the control and causes a paint message to be sent to the control. Optionally, invalidates the child controls assigned to the control.</summary>
        public void Invalidate(bool blnInvalidateChildren)
        {
            this.Update();
        }

        /// <summary>
        /// Activates the control.  
        /// </summary>
        public void Select()
        {
            this.Select(false, false);
        }

        /// <summary>
        ///  Activates a child control. Optionally specifies the direction in the tab order to select the control from.  
        /// </summary>
        protected virtual void Select(bool blnDirected, bool blnForward)
        {
            IContainerControl objContainerControlInternal = this.GetContainerControlInternal();
            if (objContainerControlInternal != null)
            {
                objContainerControlInternal.ActiveControl = this;
            }
        }

        /// <summary>
        /// Activates the next control.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
        /// <param name="blnTabStopOnly">if set to <c>true</c> [BLN tab stop only].</param>
        /// <param name="blnNested">if set to <c>true</c> [BLN nested].</param>
        /// <param name="blnWrap">if set to <c>true</c> [BLN wrap].</param>
        /// <returns>
        /// true if a control was activated; otherwise, false.
        /// </returns>
        public bool SelectNextControl(Control objControl, bool blnForward, bool blnTabStopOnly, bool blnNested, bool blnWrap)
        {
            if (!this.Contains(objControl) || (!blnNested && (objControl.Parent != this)))
            {
                objControl = null;
            }
            bool blnFlag = false;
            Control objControl2 = objControl;
            do
            {
                objControl = this.GetNextControl(objControl, blnForward);
                if (objControl == null)
                {
                    if (!blnWrap)
                    {
                        break;
                    }
                    if (blnFlag)
                    {
                        return false;
                    }
                    blnFlag = true;
                }
                else if ((objControl.CanSelect && (!blnTabStopOnly || objControl.TabStop)) && (blnNested || (objControl.Parent == this)))
                {
                    objControl.Select(true, blnForward);
                    return true;
                }
            }
            while (objControl != objControl2);
            return false;
        }

        /// <devdoc> 
        ///     Unsafe internal version of SelectNextControl - Use with caution!
        /// </devdoc>
        internal bool SelectNextControlInternal(Control objControl, bool blnForward, bool blnTabStopOnly, bool blnNested, bool blnWrap)
        {
            return SelectNextControl(objControl, blnForward, blnTabStopOnly, blnNested, blnWrap);
        }

        /// <summary>
        /// Updates the params internally.
        /// </summary>
        /// <param name="enmType">Type of the enm.</param>
        internal void UpdateParamsInternal(AttributeType enmType)
        {
            this.UpdateParams(enmType);
        }

        /// <summary>
        /// Finds the form internal.
        /// </summary>
        /// <returns></returns>
        internal Form FindFormInternal()
        {
            Control objParentInternal = this;

            while ((objParentInternal != null) && !(objParentInternal is Form))
            {
                objParentInternal = objParentInternal.ParentInternal;
            }

            return (Form)objParentInternal;
        }

        /// <summary>
        /// Finds the form.
        /// </summary>
        /// <returns></returns>
        public Form FindForm()
        {
            return this.FindFormInternal();
        }

        #endregion

        #region Visual Related

        /// <summary>
        /// Raises the <see cref="E:EnabledChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnabledChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.EnabledChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:TextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.TextChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            // Raise queued event if needed
            OnTextChangedQueued(e);
        }

        /// <summary>
        /// Raise TextChangedQueued event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTextChangedQueued(EventArgs e)
        {
            // Raise queued event if needed
            EventHandler objEventHandler = this.TextChangedQueuedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DoubleClick"></see> event. </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnDoubleClick(EventArgs e)
        {
            EventHandler objEventHandler = this.DoubleClickHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnFontChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.FontChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ForeColorChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected virtual void OnForeColorChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.ForeColorChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnHandleCreated(EventArgs e)
        {

        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleDestroyed"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnHandleDestroyed(EventArgs e)
        {


        }

        /// <summary>
        /// Childs the got focus.
        /// </summary>
        /// <param name="objChild">The child.</param>
        private void ChildGotFocus(Control objChild)
        {
            if (this.Parent != null)
            {
                this.Parent.ChildGotFocus(objChild);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        internal protected virtual void OnGotFocus(EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.ChildGotFocus(this);
            }

            EventHandler objEventHandler = this.GotFocusHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:LostFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnLostFocus(EventArgs e)
        {
            EventHandler objEventHandler = this.LostFocusHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, new EventArgs());
            }
        }



        /// <summary>
        ///  Displays the control to the user. 
        /// </summary>
        public virtual void Show()
        {
            this.Visible = true;
        }

        /// <summary>
        /// Conceals the control from the user.  
        /// </summary>
        public void Hide()
        {
            this.Visible = false;
        }

        /// <summary>
        /// Sets the control minimum size by updating its bounds.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="objValue">The value.</param>
        internal void SetMinimumSize(IArrangedElement objElement, Size objValue)
        {
                // Get the element's bounds into a rectangle
                Rectangle objRectangle = objElement.Bounds;
                if (objValue.Width > 0)
                {
                    // Set the width to the largest of the two
                    objRectangle.Width = Math.Max(objRectangle.Width, objValue.Width);
                }
                if (objValue.Height > 0)
                {
                    // Set the Height to the largest of the two
                    objRectangle.Height = Math.Max(objRectangle.Height, objValue.Height);
                    //Set Bounds of the element.
                    objElement.SetBounds(objRectangle, BoundsSpecified.Size);
                }
        }

        /// <summary>
        /// Sets the maximum size by updating its bounds.
        /// </summary>
        /// <param name="objElement">The element.</param>
        /// <param name="objValue">The value.</param>
        internal void SetMaximumSize(IArrangedElement objElement, Size objValue)
        {
                // Get the element's bounds into a rectangle
                Rectangle objRectangle = objElement.Bounds;

                if (objValue.Width > 0)
                {
                    // Set the width to the smallest of the two
                    objRectangle.Width = Math.Min(objRectangle.Width, objValue.Width);
                }
                if (objValue.Height > 0)
                {
                    // Set the Height to the smallest of the two
                    objRectangle.Height = Math.Min(objRectangle.Height, objValue.Height);
                }

                //Set Bounds of the element.
                objElement.SetBounds(objRectangle, BoundsSpecified.Size);
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual void Refresh()
        {

        }


        /// <summary>Begins a drag-and-drop operation.</summary>
        /// <returns>A value from the <see cref="T:System.Windows.Forms.DragDropEffects"></see> enumeration that represents the final effect that was performed during the drag-and-drop operation.</returns>
        /// <param name="data">The data to drag. </param>
        /// <param name="allowedEffects">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
        /// <filterpriority>1</filterpriority>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
        {
            return DragDropEffects.None;
        }




        #endregion

        #region Protected

        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objProposedSize">Size of the obj proposed.</param>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public virtual Size GetPreferredSize(Size objProposedSize)
        {
            return GetPreferredSize(objProposedSize, false);
        }


        /// <summary>
        /// Gets the preferred size or the client minimum size.
        /// </summary>
        /// <param name="objProposedSize">The proposed size.</param>
        /// <param name="blnIsClientMinimumSize">if set to <c>true</c> [BLN is client minimum size].</param>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
        {
            // Define a maximal height for all contained controls with no docking.
            int intMaxHeightAnchored = 0;

            // Define a maximal width for all contained controls with no docking.
            int intMaxWidthAnchored = 0;

            // Acumalation variables for actual used area
            int intDockedUsedHeight = 0;
            int intDockedUsedWidth = 0;

            // Calculated miminum sizes
            int intDockedMinimumHeight = 0;
            int intDockedMinimumWidth = 0;

            // If there is a valid control collection
            if (mobjControls != null)
            {
                // Get the controls count
                int intControlsCount = mobjControls.Count;

                // If there are controls
                if (intControlsCount > 0)
                {
                    // Loop all child controls from end to start.
                    for (int intIndex = intControlsCount - 1; intIndex >= 0; intIndex--)
                    {
                        // Get current control
                        Control objChild = mobjControls[intIndex];

                        // Ignore invisible controls 
                        if (objChild.Visible)
                        {
                            // Check control docking
                            switch (objChild.Dock)
                            {
                                case DockStyle.None:
                                    AnchorStyles enmAnchor = objChild.Anchor;

                                    // If effects height
                                    if (!objChild.IsBottomAnchored(enmAnchor) && objChild.IsTopAnchored(enmAnchor))
                                    {
                                        // Check if current child's bottom point is bigger then the on found so far.
                                        intMaxHeightAnchored = Math.Max(intMaxHeightAnchored, objChild.LayoutTop + objChild.Height);
                                    }

                                    // If effects width
                                    if (!objChild.IsRightAnchored(enmAnchor) && objChild.IsLeftAnchored(enmAnchor))
                                    {
                                        // Check if current child's right point is bigger then the on found so far.
                                        intMaxWidthAnchored = Math.Max(intMaxWidthAnchored, objChild.LayoutLeft + objChild.Width);
                                    }
                                    break;

                                case DockStyle.Top:
                                case DockStyle.Bottom:

                                    // Add the current used height
                                    intDockedUsedHeight += objChild.Height;

                                    // If should include child in calculations
                                    if (!blnIsClientMinimumSize || objChild.AutoSize)
                                    {
                                        // Recalculate the new docked mimimum width
                                        intDockedMinimumWidth = Math.Max(intDockedMinimumWidth, intDockedUsedWidth + objChild.PreferredSize.Width);
                                    }
                                    break;

                                case DockStyle.Left:
                                case DockStyle.Right:

                                    // Add the current used width
                                    intDockedUsedWidth += objChild.Width;

                                    // If should include child in calculations
                                    if (!blnIsClientMinimumSize || objChild.AutoSize)
                                    {
                                        // Recalculate the new docked mimimum height
                                        intDockedMinimumHeight = Math.Max(intDockedMinimumHeight, intDockedUsedHeight + objChild.PreferredSize.Height);
                                    }
                                    break;

                                case DockStyle.Fill:
                                    // If should include child in calculations
                                    if (!blnIsClientMinimumSize || objChild.AutoSize)
                                    {
                                        // Recalculate the new docked mimimum height
                                        intDockedMinimumHeight = Math.Max(intDockedMinimumHeight, intDockedUsedHeight + objChild.PreferredSize.Height);

                                        // Recalculate the new docked mimimum width
                                        intDockedMinimumWidth = Math.Max(intDockedMinimumWidth, intDockedUsedWidth + objChild.PreferredSize.Width);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            // Create a preferred size.
            Size objPreferredSize = new Size(
                Math.Max(intMaxWidthAnchored, Math.Max(intDockedMinimumWidth, intDockedUsedWidth)),
                Math.Max(intMaxHeightAnchored, Math.Max(intDockedMinimumHeight, intDockedUsedHeight)));

            return objPreferredSize;
        }

        /// <summary>
        /// Gets the preferred size by auto size mode.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objProposedSize">Size of the obj proposed.</param>
        /// <param name="objPreferredSize">Size of the obj preferred.</param>
        /// <returns></returns>
        protected static Size GetPreferredSizeByAutoSizeMode(Control objControl, Size objProposedSize, Size objPreferredSize)
        {
            if (objControl != null && objControl.AutoSize)
            {
                //If this is grow only
                if (objControl.AutoSizeMode == AutoSizeMode.GrowOnly)
                {
                    //If preferred Width is smaler then proposed Width
                    if (objPreferredSize.Width < objProposedSize.Width)
                    {
                        objPreferredSize.Width = objProposedSize.Width;
                    }

                    //If preferred Height is smaler then proposed Height
                    if (objPreferredSize.Height < objProposedSize.Height)
                    {
                        objPreferredSize.Height = objProposedSize.Height;
                    }
                }
            }

            return objPreferredSize;
        }


        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validating"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            CancelEventHandler objEventHandler = ValidatingHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validated"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnValidated(EventArgs e)
        {
            EventHandler objEventHandler = ValidatedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CausesValidationChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnCausesValidationChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.CausesValidationChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.VisibleChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnVisibleChanged(EventArgs e)
        {
            bool blnVisible = this.Visible;

            // Create cotnrol if needed.
            DoCreateControl(blnVisible);

            EventHandler objEventHandler = VisibleChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            ControlCollection objControlsCollection = this.Controls;
            if (objControlsCollection != null)
            {
                // PERFNOTE: This is more efficient than using Foreach.  Foreach 
                // forces the creation of an array subset enum each time we
                // enumerate 
                for (int i = 0; i < objControlsCollection.Count; i++)
                {
                    Control objControl = objControlsCollection[i];
                    if (objControl.Visible)
                    {
                        objControl.OnParentVisibleChanged(e);
                    }
                    if (!blnVisible)
                    {
                        objControl.OnParentBecameInvisible();
                    }
                }
            }
        }

        /// <summary>
        /// Create a control.
        /// </summary>
        /// <param name="blnVisible">if set to <c>true</c> [BLN visible].</param>
        protected virtual void DoCreateControl(bool blnVisible)
        {
            // Check if control should be created.
            if (this.ParentInternal != null && blnVisible && !this.Created && this.ParentInternal.Created)
            {
                this.CreateControl();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ParentVisibleChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentVisibleChanged(EventArgs e)
        {
            // If is visible
            if (this.GetState(ComponentState.Visible))
            {
                this.OnVisibleChanged(e);
            }
        }


        /// <summary>
        /// Called when parent became invisible.
        /// </summary>
        internal virtual void OnParentBecameInvisible()
        {
            if (this.GetState(ComponentState.Visible))
            {
                if (mobjControls != null)
                {
                    for (int intIndex = 0; intIndex < mobjControls.Count; intIndex++)
                    {
                        mobjControls[intIndex].OnParentBecameInvisible();
                    }
                }
            }
        }

        /// <summary>Supports rendering to the specified bitmap.</summary>
        /// <param name="objBitmap">The bitmap to be drawn to.</param>
        /// <param name="objTargetBounds">The bounds within which the control is rendered.</param>
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public void DrawToBitmap(Bitmap objBitmap, Rectangle objTargetBounds)
        {
            // Validate bitmap
            if (objBitmap == null)
            {
                throw new ArgumentNullException("objBitmap");
            }

            // Validate target bounds
            if (((objTargetBounds.Width <= 0) || (objTargetBounds.Height <= 0)) || ((objTargetBounds.X < 0) || (objTargetBounds.Y < 0)))
            {
                throw new ArgumentException("objTargetBounds");
            }

            // Get the drawing width
            int intWidth = Math.Min(this.Width, objTargetBounds.Width);
            int intHeight = Math.Min(this.Height, objTargetBounds.Height);

            // Create bitmap for drawing control
            using (Bitmap objBufferBitmap = DrawControl(new ControlRenderingContext(objBitmap.PixelFormat), intWidth, intHeight))
            {
                // Create graphics to draw on the givven bitmap
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    // Draw the control bitmap
                    objGraphics.DrawImage(objBufferBitmap, objTargetBounds.Location);
                }
            }

        }

        /// <summary>
        /// Draws the control and return the cotrol bitmap.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="intWidth">The bitmap width.</param>
        /// <param name="intHeight">The bitmap height.</param>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        internal Bitmap DrawControl(ControlRenderingContext objContext, int intWidth, int intHeight)
        {

            // Create bitmap for drawing control
            Bitmap objControlBitmap = new Bitmap(intWidth, intHeight, objContext.PixelFormat);

            // Create graphics for drawing control
            using (Graphics objControlGraphics = Graphics.FromImage(objControlBitmap))
            {
                DrawControl(objContext, objControlGraphics);
            }

            return objControlBitmap;

        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void DrawControl(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the control renderer
            ControlRenderer objControlRenderer = GetControlRenderer();

            // If there is a valid control renderer
            if (objControlRenderer != null)
            {
                // Render the control
                objControlRenderer.Render(objContext, objGraphics);
            }
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ControlRenderer GetControlRenderer()
        {
            return new ControlRenderer(this);
        }



        /// <summary>
        /// Sends to back.
        /// </summary>
        public void SendToBack()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.SetChildIndex(this, -1);
            }
        }


        /// <summary>
        /// Brings the control to the front of the z-order.
        /// </summary>       
        public void BringToFront()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.SetChildIndex(this, 0);
            }
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.</summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool blnDisposing)
        {
            if (blnDisposing)
            {
                this.SuspendLayout();
                try
                {
                    this.ResetBindings();

                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                    }

                    ControlCollection objControls = (ControlCollection)this.Controls;
                    if (objControls != null)
                    {
                        for (int i = 0; i < objControls.Count; i++)
                        {
                            Control objControl = objControls[i];
                            objControl.InternalParent = null;
                            objControl.Dispose();
                        }
                        mobjControls = null;
                    }

                    base.Dispose(blnDisposing);
                }
                finally
                {
                    this.ResumeLayout(false);
                }
            }
            else
            {
                base.Dispose(blnDisposing);
            }
        }

        /// <summary>
        /// Resets the created flag.
        /// </summary>
        protected void ResetCreatedFlag()
        {
            this.SetState(ControlState.Created, false);

            foreach (Control objChildControl in this.Controls)
            {
                objChildControl.ResetCreatedFlag();
            }
        }

        #region Reset

        /// <filterpriority>2</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetBindings()
        {
            ControlBindingsCollection objBindings = (ControlBindingsCollection)this.DataBindings;
            if (objBindings != null)
            {
                objBindings.Clear();
            }
        }

        /// <summary>
        /// Resets the text.
        /// </summary>
        public virtual void ResetText()
        {
            this.Text = string.Empty;
        }

        /// <summary>
        /// Resets the font.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetFont()
        {
            this.Font = null;
        }

        /// <summary>
        /// Resets the color of the fore.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetForeColor()
        {
            this.ForeColor = Color.Empty;
        }

        /// <summary>
        /// Resets the color of the back.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBackColor()
        {
            this.BackColor = Color.Empty;
        }

        /// <summary>
        /// Resets the border style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBorderStyle()
        {
            this.BorderStyle = this.DefaultBorderStyle;
        }

        /// <summary>
        /// Resets the border Color.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBorderColor()
        {
            this.BorderColor = this.DefaultBorderColor;
        }

        /// <summary>
        /// Resets the border Width.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBorderWidth()
        {
            this.BorderWidth = this.DefaultBorderWidth;
        }

        /// <summary>
        /// Resets the Anchor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetAnchor()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        /// <summary>
        /// Resets the Minimum Size.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetMinimumSize()
        {
            this.MinimumSize = this.DefaultMinimumSize;
        }

        /// <summary>
        /// Resets the Maximum Size.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetMaximumSize()
        {
            this.MaximumSize = this.DefaultMaximumSize;
        }

        /// <summary>
        /// Resets the border style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetPadding()
        {
            RemoveValue<Padding>(Control.PaddingProperty);
        }

        /// <summary>
        /// Resets the border style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetMargin()
        {
            RemoveValue<Padding>(Control.MarginProperty);
        }

        /// <summary>
        /// Resets the border style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetSize()
        {
            this.Size = this.DefaultSize;
        }

        #endregion Reset

        /// <summary>
        /// Called when [unregister components].
        /// </summary>
        protected override void OnUnregisterComponents()
        {
            base.OnUnregisterComponents();

            // Unregister control children
            UnRegisterBatch(this.Controls);
        }

        /// <summary>
        /// Called when [register components].
        /// </summary>
        protected override void OnRegisterComponents()
        {
            base.OnRegisterComponents();

            // Unregister control children
            RegisterBatch(this.Controls);
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <returns></returns>
        internal protected string GetCommandText(string strText)
        {
            string strRes = strText;

            if (!this.DesignMode)
            {
                Regex objRegexp = new Regex("(?<![&])&(?![&])");
                strRes = objRegexp.Replace(strRes, string.Empty);
                strRes = strRes.Replace("&&", "&");
            }

            return strRes;
        }

        /// <summary>
        /// Invokes client side selection
        /// </summary>
        /// <param name="intStart"></param>
        /// <param name="intLength"></param>
        protected virtual void InvokeSelection(int intStart, int intLength)
        {
            this.InvokeMethodWithId("Control_SetSelection", intStart, intLength);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new ControlWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.RecursiveResizeEvent)
            {
                // Update control params.
                this.UpdateParams(AttributeType.Control);
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion

        #region IArrangedElement Members


        /// <summary>
        /// Gets the size of the preferred.
        /// </summary>
        /// <param name="objProposedSize">Size of the proposed.</param>
        /// <returns></returns>
        Size IArrangedElement.GetPreferredSize(Size objProposedSize)
        {
            return this.GetPreferredSize(objProposedSize);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        ArrangedElementCollection IArrangedElement.Children
        {
            get
            {
                return this.Controls;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [participates in layout].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [participates in layout]; otherwise, <c>false</c>.
        /// </value>
        bool IArrangedElement.ParticipatesInLayout
        {
            get { return this.VisibleIntenal; }
        }


        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <returns></returns>
        T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty)
        {
            return this.GetValue<T>(objSerializableProperty);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objSerializableProperty">The serializable property.</param>
        /// <param name="objValue">The obj value.</param>
        void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)
        {
            this.SetValue<T>(objSerializableProperty, objValue);
        }


        #endregion

        #region IObservableLayoutItem Members

        /// <summary>
        /// Occurs when [observable suspend layout].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event EventHandler ObservableSuspendLayout
        {
            add
            {
                this.AddHandler(Control.ObservableSuspendLayoutEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ObservableSuspendLayoutEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableSuspendLayout event.
        /// </summary>
        private EventHandler ObservableSuspendLayoutHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(Control.ObservableSuspendLayoutEvent);
            }
        }

        /// <summary>
        /// The ObservableSuspendLayout event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableSuspendLayoutEvent = SerializableEvent.Register("ObservableSuspendLayout", typeof(EventHandler), typeof(Control));



        /// <summary>
        /// Occurs when [observable resume layout].
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public event ObservableResumeLayoutHandler ObservableResumeLayout
        {
            add
            {
                this.AddHandler(Control.ObservableResumeLayoutEvent, value);
            }
            remove
            {
                this.RemoveHandler(Control.ObservableResumeLayoutEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the ObservableResumeLayout event.
        /// </summary>
        private ObservableResumeLayoutHandler ObservableResumeLayoutHandler
        {
            get
            {
                return (ObservableResumeLayoutHandler)this.GetHandler(Control.ObservableResumeLayoutEvent);
            }
        }

        /// <summary>
        /// The ObservableResumeLayout event registration.
        /// </summary>
        private static readonly SerializableEvent ObservableResumeLayoutEvent = SerializableEvent.Register("ObservableResumeLayout", typeof(ObservableResumeLayoutHandler), typeof(Control));



        #endregion

        #region Compatibility

        #region Compatibility Methods

        /// <summary>
        /// Creates the graphics.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Graphics CreateGraphics()
        {
            return null;
        }

        #endregion

        #region Compatibility Properties

        /// <summary>
        /// Gets the create params.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual CreateParams CreateParams
        {
            get
            {
                return null;
            }
        }

        #endregion

        #endregion

        #endregion

        #region Properties

        #region ControlEdit

        private EditMode menmEditMode;

        /// <summary>
        /// Gets a value indicating whether [can edit control].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit control]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Browsable(true)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CanEditControl 
        {
            get 
            { 
                return false; 
            }
        }

        /// <summary>
        /// Gets or sets the edit control mode.
        /// </summary>
        /// <value>
        /// The edit control mode.
        /// </value>
        [DefaultValue(EditMode.Off), Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EditMode EditControlMode 
        { 
            get 
            {
                return GetProxyPropertyValue<EditMode>("EditControlMode", menmEditMode);
            } 
            set 
            {
                if (this.CanEditControl)
                {
                    SetEditControlMode(value, false);
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Control of type '{0}' cannot be edited. To edit override the 'CanEditControl' property", this.GetType().FullName));
                }
            } 
        }

        #endregion

        #region General

        /// <summary>
        /// Gets a value indicating whether this instance can access properties.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can access properties; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool CanAccessProperties
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// Set text without raising any events
        /// </summary>
        internal virtual string InternalText
        {
            set
            {
                // Set text and raise even if text changed
                if (this.SetValue<string>(Control.TextProperty, value))
                {
                    // Raise event changed
                    OnTextChanged(EventArgs.Empty);
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [becoming active control].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [becoming active control]; otherwise, <c>false</c>.
        /// </value>
        internal bool BecomingActiveControl
        {
            get
            {
                return this.GetState(ControlState.BecomingActiveControl);
            }
            set
            {
                this.SetState(ControlState.BecomingActiveControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.  
        /// </summary>
        [System.ComponentModel.DefaultValue("")]
        [SRCategory("CatAppearance")]
        [SRDescription("ControlTextDescr")]
        [System.ComponentModel.Localizable(true)]
        [System.ComponentModel.Bindable(true), ProxyBrowsable(true)]
        public virtual string Text
        {
            get
            {
                return GetProxyPropertyValue<string>("Text", this.GetValue<string>(Control.TextProperty));
            }
            set
            {
                // If text has changed
                string strValue = (value == null ? string.Empty : value);

                // Set the text value and update control and raise events if text had changed
                if (this.SetValue<string>(Control.TextProperty, strValue))
                {
                    // Update control params
                    UpdateParams(AttributeType.Control);

                    // Raise event if needed
                    OnTextChanged(EventArgs.Empty);

                    // Fire event changed
                    this.FireObservableItemPropertyChanged("Text");
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.  
        /// </summary>
        internal string ToolTip
        {
            get
            {
                return this.GetValue<string>(Control.ToolTipProperty);
            }
            set
            {
                // Set text and if value had changed update the control and raise events
                if (this.SetValue<string>(Control.ToolTipProperty, value))
                {
                    // Update control params
                    UpdateParams(AttributeType.ToolTip);

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("ToolTip");

                }
            }
        }

        /// <summary>
        /// Gets the extended tool tip descriptor.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolTipDescriptor ExtendedToolTipDescriptor
        {
            get
            {
                return this.GetValue<ToolTipDescriptor>(Control.ExtendedToolTipDescriptorProperty);
            }

            set
            {
                if (SetValue<ToolTipDescriptor>(Control.ExtendedToolTipDescriptorProperty, value))
                {
                    // Update control params
                    UpdateParams(AttributeType.ToolTip);
                }
            }

        }

        /// <summary>
        /// Gets which multi theme to skip when writing the html.
        /// </summary>
        protected virtual ControlSkipMultiTheme SkipMultiTheme
        {
            get
            {
                return ControlSkipMultiTheme.None;
            }
        }

        /// <summary>
        /// Gets the control tag name.  
        /// </summary>
        /// <remarks>
        /// This property by default reverts to the previous implementation 
        /// of setting the TagName property, which is obsolete. To use the newer approach which is 
        /// using the MetadataTag attribute do not use the TagName property.
        /// </remarks>
        protected string MetadataTag
        {
            get
            {
                // Get the tag name property value with out accessing the tag name property as
                // it is defined obsolete
                string strTagName = this.GetValue<string>(Control.TagNameProperty);

                // Tag name is not definied we can look at the newer implementation
                if (CommonUtils.IsNullOrEmpty(strTagName))
                {
                    return Metadata.GetTag(this);
                }
                else
                {
                    return strTagName;
                }
            }
        }

        /// <summary>
        /// Gets or sets the control tag name.  
        /// </summary>
        [Obsolete("Use MetadataTagAttribute to set tag name or Control.MetadataTag to get tag name.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected string TagName
        {
            get
            {
                return this.GetValue<string>(Control.TagNameProperty);
            }
            set
            {
                this.SetValue<string>(Control.TagNameProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether to reverse control rendering.
        /// </summary>
        /// <value><c>true</c> if to reverse control rendering; otherwise, <c>false</c>.</value>
        protected virtual bool ReverseControls
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Sets the enabled without update.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> then control enables.</param>
        /// <returns></returns>
        internal void SetEnabledInternal(bool blnValue)
        {
            if (this.SetStateWithCheck(ComponentState.Enabled, blnValue))
            {
                OnEnabledChanged(EventArgs.Empty);
                FireObservableItemPropertyChanged("Enabled");
            }

        }


        /// <summary>
        /// Gets the name of the client component.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string GetClientComponentName()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets or sets the name associated with this control.  
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DefaultValue("")]
        public string Name
        {
            get
            {
                // Get the stored name property
                string strName = string.IsNullOrEmpty(this.AccessibleName) ? this.GetValue<string>(Control.NameProperty) : this.AccessibleName;

                // If name is empty
                if (string.IsNullOrEmpty(strName))
                {
                    // If site is not null get the name from the site
                    if (this.Site != null)
                    {
                        strName = this.Site.Name;
                    }

                    // If name is still null change to empty string
                    if (strName == null)
                    {
                        strName = string.Empty;
                    }
                }
                return strName;
            }
            set
            {
                // If value is null set empty string
                if (value == null)
                {
                    this.SetValue<string>(Control.NameProperty, string.Empty);
                }
                else
                {
                    // Set the value sent
                    this.SetValue<string>(Control.NameProperty, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the accessible name associated with this control.  
        /// </summary>
        [SRCategory("CatAccessibility")]
        [SRDescription("ControlAccessibleNameDescr")]
        [Localizable(true)]
        [Browsable(true)]
        [DefaultValue("")]
        public string AccessibleName
        {
            get
            {
                // Get the stored name property
                return this.GetValue<string>(Control.AccessibleNameProperty);
            }
            set
            {
                if (this.SetValue<string>(Control.AccessibleNameProperty, value))
                {
                    this.UpdateParams(AttributeType.Accessibility);
                }
            }
        }


        /// <summary>
        /// Gets or sets the accessible description associated with this control.  
        /// </summary>
        [SRCategory("CatAccessibility")]
        [SRDescription("ControlAccessibleDescriptionDescr")]
        [Localizable(true)]
        [Browsable(true)]
        [DefaultValue("")]
        public string AccessibleDescription
        { 
            get
            {
                // Get the stored name property
                return this.GetValue<string>(Control.AccessibleDescriptionProperty);
            }
            set
            {
                if (this.SetValue<string>(Control.AccessibleDescriptionProperty, value))
                {
                    this.UpdateParams(AttributeType.Accessibility);
                }
            }
        }
        /// <summary>
        /// Gets the resizable allowed directions.
        /// </summary>
        protected virtual string[] ResizableAllowedDirections
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is resizable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if resizable; otherwise, <c>false</c>.
        /// </value>
        [Description("Properties representing if the control is resizable."), SRCategory("CatBehavior")]
        public virtual ResizableOptions Resizable
        {
            get
            {
                ResizableOptions objTempResizable = this.ResizableInternal;

                // Creating a default resizable basic object.
                if (objTempResizable == null)
                {
                    objTempResizable = new ResizableOptions(false);
                    this.Resizable = objTempResizable;
                }

                return objTempResizable;
            }
            set
            {
                // Setting the owner of the objcet.
                value.Owner = this;

                if (this.SetValue<ResizableOptions>(Control.ResizableProperty, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets the resizable internally.
        /// </summary>
        /// <value>
        /// The resizable value.
        /// </value>
        private ResizableOptions ResizableInternal
        {
            get
            {
                return this.GetValue<ResizableOptions>(Control.ResizableProperty);
            }
        }

        /// <summary>
        /// Shoulds the serialize draggable.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeResizable()
        {
            // If there is no resizable, or there is, but it is assigend false, and has only default values, then no render should be made.
            if (this.Resizable == null || (!this.Resizable.IsResizable && this.Resizable.IsDefault()))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Control"/> is draggable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if draggable; otherwise, <c>false</c>.
        /// </value>
        [Description("Properties representing if the control is draggable."), SRCategory("CatBehavior")]
        public virtual DraggableOptions Draggable
        {
            get
            {
                DraggableOptions objTempDraggable = this.DraggableInternal;

                if (objTempDraggable == null)
                {
                    objTempDraggable = new DraggableOptions(false);
                    this.Draggable = objTempDraggable;
                }

                return objTempDraggable;
            }
            set
            {
                value.Owner = this;

                if (this.SetValue<DraggableOptions>(Control.DraggableProperty, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Drag);
                }
            }
        }

        /// <summary>
        /// Gets the draggable internally.
        /// </summary>
        /// <value>
        /// The draggable value.
        /// </value>
        private DraggableOptions DraggableInternal
        {
            get
            {
                return this.GetValue<DraggableOptions>(Control.DraggableProperty);
            }
        }

        /// <summary>
        /// Shoulds the serialize draggable.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeDraggable()
        {
            // If there is no draggable, or there is, but it is assigend false, and has only default values, then no render should be made.
            if (this.Draggable == null || (!this.Draggable.IsDraggable && this.Draggable.IsDefault()))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets a value indicating whether this instance can focus.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can focus; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(false)]
        public virtual bool CanFocus
        {
            get
            {
                return this.Enabled && this.Visible;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected virtual bool Focusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the control can be selected.</summary>
        /// <returns>true if the control can be selected; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatFocus")]
        [SRDescription("ControlCanSelectDescr")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool CanSelect
        {
            get
            {
                return this.CanSelectCore();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual bool CanSelectCore()
        {
            if ((this.menmControlStyle & ControlStyles.Selectable) != ControlStyles.Selectable)
            {
                return false;
            }
            for (Control objControl = this; objControl != null; objControl = objControl.Parent)
            {
                if (!objControl.Enabled || !objControl.Visible)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>Retrieves the value of the specified control style bit for the control.</summary>
        /// <returns>true if the specified control style bit is set to true; otherwise, false.</returns>
        /// <param name="enmflag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to return the value from. </param>
        protected bool GetStyle(ControlStyles enmflag)
        {
            return ((this.menmControlStyle & enmflag) == enmflag);
        }

        /// <summary>Sets the specified style bit to the specified value.</summary>
        /// <param name="enmFlag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to set. </param>
        /// <param name="blnValue">true to apply the specified style to the control; otherwise, false. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected void SetStyle(ControlStyles enmFlag, bool blnValue)
        {
            ControlStyles enmControlStyles = this.menmControlStyle;
            this.menmControlStyle = blnValue ? (enmControlStyles | enmFlag) : (enmControlStyles & ~enmFlag);
        }








        /// <summary>Gets the default font of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Font"></see> of the control. The value returned will vary depending on the user's operating system the local culture setting of their system.</returns>
        /// <exception cref="T:System.ArgumentException">The default font or the regional alternative fonts are not installed on the client computer. </exception>
        /// <filterpriority>1</filterpriority>
        public static Font DefaultFont
        {
            get
            {
                return ThemeFonts.DefaultFont;
            }
        }


        /// <summary>
        /// Gets a value indicating whether [supports focus events].
        /// </summary>
        /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
        protected internal virtual bool SupportsFocusEvents
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the registered timers.
        /// </summary>
        /// <value>The registered timers.</value>
        [DefaultValue(null), Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Timer[] RegisteredTimers
        {
            get
            {
                return this.GetValue<Timer[]>(Control.RegisteredTimersProperty);
            }
            set
            {
                this.SetValue<Timer[]>(Control.RegisteredTimersProperty, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [use preferred size].
        /// </summary>
        /// <value><c>true</c> if [use preferred size]; otherwise, <c>false</c>.</value>
        protected internal virtual bool UsePreferredSize
        {
            get
            {
                return this.AutoSize;
            }
        }

        /// <summary>
        /// Gets the modifier keys.
        /// </summary>
        /// <value>The modifier keys.</value>
        public static Keys ModifierKeys
        {
            get
            {
                IContextParams objContextParams = VWGContext.Current as IContextParams;
                if (objContextParams != null)
                {
                    return objContextParams.ModifierKeys;
                }

                return Keys.None;
            }
        }

        /// <summary>
        /// Gets or sets the IME mode.
        /// </summary>
        /// <value>
        /// The IME mode.
        /// </value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImeMode ImeMode
        {
            get
            {
                return this.GetValue<ImeMode>(Control.ImeModeProperty);
            }
            set
            {
                this.SetValue<ImeMode>(Control.ImeModeProperty, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether this control should redraw its surface using a secondary buffer to reduce or prevent flicker.</summary>
        /// <returns>true if the surface of the control should be drawn using double buffering; otherwise, false.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), SRDescription("ControlDoubleBufferedDescr")]
        protected virtual bool DoubleBuffered
        {
            get
            {
                return false;
            }
            set
            { }
        }

        /// <summary>
        /// Gets the top level control.
        /// </summary>
        [SRCategory("CatBehavior"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlTopLevelControlDescr"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Control TopLevelControl
        {
            get
            {
                return this.TopLevelControlInternal;
            }
        }

        #region ClientRectangle

        /// <summary>
        /// Gets the client rectangle.
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Drawing.Rectangle ClientRectangle
        {
            get
            {
                return new System.Drawing.Rectangle(this.Location, this.ClientSize);
            }
        }

        #endregion


        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool SupportsKeyNavigation
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Drag & Drop

        /// <summary>
        /// Check if the DragTargets property should be serialized in designtime
        /// </summary>
        new private bool ShouldSerializeDragTargets()
        {
            // Return true if the drag targets collection has components, false otherwise.
            return this.DragTargets.Length > 0;
        }

        #endregion

        #region Private

        /// <summary>
        /// Gets a value indicating whether this instance has tab index.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has tab index; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasTabIndex
        {
            get
            {
                // Return false if the private tab index is -1, true otherwise.
                return mintTabIndex != -1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is defined for tabbing as group.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is tab for group; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool EnableGroupTabbing
        {
            get
            {

                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [visible intenal].
        /// </summary>
        /// <value><c>true</c> if [visible intenal]; otherwise, <c>false</c>.</value>
        internal bool VisibleIntenal
        {
            get
            {
                return this.GetState(ComponentState.Visible);
            }
            set
            {
                this.SetState(ComponentState.Visible, value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether raise click event on right mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise right click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        ///         
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                if (this.ContextMenuInherited != null || this.ContextMenuStripInherited != null)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets the top level control internal.
        /// </summary>
        internal Control TopLevelControlInternal
        {
            get
            {
                Control objParentInternal = this;
                while ((objParentInternal != null) && !objParentInternal.GetTopLevel())
                {
                    Form objForm = objParentInternal as Form;
                    if (objForm != null && objForm.IsMdiChild && objForm.MdiParent != null)
                    {
                        objParentInternal = objForm.MdiParent;
                    }
                    else
                    {
                        objParentInternal = objParentInternal.ParentInternal;
                    }
                }
                return objParentInternal;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [selected indicator].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [selected indicator]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [SRCategory("CatAppearance")]
        [SRDescription("ControlSelectedIndicatorDescr")]
        public bool SelectedIndicator
        {
            get
            {
                return mblnSelectedIndicator;
            }
            set
            {
                if (mblnSelectedIndicator != value)
                {
                    mblnSelectedIndicator = value;
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ControlWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as ControlWinFormsCompatibility;
            }
        }

        #endregion

        #region Object Model


        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                // If this is disabled or invisible, return false.
                if (!this.Enabled || !this.Visible)
                {
                    return false;
                }
                else
                {
                    return base.IsEventsEnabled;
                }
            }
        }

        /// <summary>
        ///  Gets the collection of controls contained within the control. 
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public ControlCollection Controls
        {
            get
            {
                // If this' controls collection doesn't exist, create it.
                if (mobjControls == null)
                {
                    mobjControls = this.CreateControlsInstance();
                }
                // Return this' controls collection.
                return mobjControls;
            }
        }

        /// <summary>
        /// Creates the controls instance.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual Control.ControlCollection CreateControlsInstance()
        {
            return new Control.ControlCollection(this);
        }

        /// <summary>
        /// Return the control child controls
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        IList IControl.Controls
        {
            get
            {
                return Controls;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IControl"/> is name.
        /// </summary>
        /// <value><c>true</c> if name; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Browsable(false)]
        string IControl.Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        /// <summary>
        /// Returns the control parent control
        /// </summary>
        IControl IControl.Parent
        {
            get
            {
                return (IControl)this.Parent;
            }
        }

        /// <summary>
        /// Performs the layout.
        /// </summary>
        /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
        void IControl.PerformLayout(bool blnForceLayout)
        {
            this.PerformLayout(blnForceLayout);
        }

        /// <summary>
        /// Gets a value indicating whether this control has children.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this control has children; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.Browsable(false)]
        public bool HasChildren
        {
            get
            {
                // Go through this' controls collection, return true if count is larger than 0. 
                if (mobjControls == null)
                {
                    return false;
                }
                else
                {
                    return mobjControls.Count > 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent container of this control.
        /// </summary>
        /// <value></value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Control Parent
        {
            get
            {
                return this.ParentInternal;
            }
            set
            {
                this.ParentInternal = value;
            }
        }


        /// <summary>
        /// Gets the get offlien parent.
        /// </summary>
        protected override IClientComponent ClientParent
        {
            get
            {
                return this.Parent;
            }
        }


        /// <summary>
        /// Gets or sets the parent container of this control.
        /// </summary>
        /// <value></value>
        internal virtual Control ParentInternal
        {
            get
            {
                return base.InternalParent as Control;
            }
            set
            {
                // Get parent control
                Control objParent = this.InternalParent as Control;
                // If parent changes
                if (objParent != value)
                {
                    // If new parent exists
                    if (value != null)
                    {
                        // Add me to the new parent's control collection
                        value.Controls.Add(this);
                    }
                    // If new parent is null, remove me from my old parent's control collection
                    else
                    {
                        objParent.Controls.Remove(this);
                    }
                }
            }
        }

        #endregion

        #region Size Related Properties

        /// <summary>
        /// 	<para>Not Implemented Property.</para>
        /// 	<para>Gets the size of a rectangular area into which the control can fit.</para>
        /// </summary>            
        /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.Browsable(false)]
        public Size PreferredSize
        {
            get
            {
                // If prefered size was set
                if (mintPreferredHeight != -1 && mintPreferredWidth != -1)
                {
                    // Get the preferred size object
                    return new Size(mintPreferredWidth, mintPreferredHeight);
                }
                else
                {
                    return Size.Empty;
                }
            }
        }

        /// <summary>Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.AmbientValue(typeof(Size), "0, 0"), SRDescription("ControlMaximumSizeDescr"), SRCategory("CatLayout")]
        public virtual Size MaximumSize
        {
            get
            {
                return this.GetValue<Size>(Control.MaximumSizeProperty, this.DefaultMaximumSize);
            }
            set
            {
                // Set maximum size and if value had changed update paramse
                if (this.SetValue<Size>(Control.MaximumSizeProperty, value))
                {
                    // Sets the control maximum size
                    SetMaximumSize(this, value);

                    // Update params.
                    this.UpdateParams(AttributeType.Layout);
                }
            }
        }

        /// <summary>Gets the length and height, in pixels, that is specified as the default maximum size of a control.</summary>
        /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
        protected virtual Size DefaultMaximumSize
        {
            get
            {
                return new Size(0, 0);
            }
        }

        /// <summary>Gets the length and height, in pixels, that is specified as the default minimum size of a control.</summary>
        /// <returns>A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
        protected virtual Size DefaultMinimumSize
        {
            get
            {
                return new Size(0, 0);
            }
        }

        /// <summary>Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatLayout"), SRDescription("ControlMinimumSizeDescr")]
        public virtual Size MinimumSize
        {
            get
            {
                return this.GetValue<Size>(Control.MinimumSizeProperty, this.DefaultMinimumSize);
            }
            set
            {
                // If value is diffrent then current
                if (this.SetValue<Size>(Control.MinimumSizeProperty, value, this.DefaultMinimumSize))
                {
                    // Sets the control minimum size
                    SetMinimumSize(this, value);

                    // Update params.
                    this.UpdateParams(AttributeType.Layout);
                }
            }
        }

        #endregion

        #region KeyUp/Down/Press Related Properties

        /// <summary>
        /// Gets or sets the key down filter.
        /// </summary>
        /// <value>The key down filter.</value>
        [Description("The key down filter."), SRCategory("CatBehavior"), DefaultValue(KeyFilter.All)]
        public KeyFilter KeyFilter
        {
            get
            {
                return this.GetValue<KeyFilter>(Control.KeyFilterProperty);
            }
            set
            {
                // Set the key filter and update control if value changed
                if (this.SetValue<KeyFilter>(Control.KeyFilterProperty, value))
                {
                    UpdateParams(AttributeType.Control);
                }
            }
        }

        #endregion

        #region Version Information Related

        /// <summary>
        /// Returns the current version info
        /// </summary>
        private ControlVersionInfo VersionInfo
        {
            get
            {
                return new ControlVersionInfo(this);
            }
        }

        /// <summary>Gets the name of the company or creator of the application containing the control.</summary>
        /// <returns>The company name or creator of the application containing the control.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), SRDescription("ControlCompanyNameDescr")]
        public string CompanyName
        {
            get
            {
                return this.VersionInfo.CompanyName;
            }
        }

        /// <summary>Gets the product name of the assembly containing the control.</summary>
        /// <returns>The product name of the assembly containing the control.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ControlProductNameDescr"), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false)]
        public string ProductName
        {
            get
            {
                return this.VersionInfo.ProductName;
            }
        }

        /// <summary>Gets the version of the assembly containing the control.</summary>
        /// <returns>The file version of the assembly containing the control.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), SRDescription("ControlProductVersionDescr")]
        public string ProductVersion
        {
            get
            {
                return this.VersionInfo.ProductVersion;
            }
        }

        #endregion

        #region Visual States

        /// <summary>
        /// Gets or sets the ScrollTop property.
        /// </summary>
        /// <value>The ScrollTop property</value>
        protected int ScrollTop
        {
            get
            {
                return this.GetValue<int>(Control.ScrollTopProperty);
            }
            set
            {
                // Set the scroll top and update the control if value changed
                if (this.SetScrollTop(value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [horizontal centered].
        /// </summary>
        /// <value><c>true</c> if [horizontal centered]; otherwise, <c>false</c>.</value>
        internal bool HorizontalCentered
        {
            get
            {
                return ((this.Anchor & (AnchorStyles.Right | AnchorStyles.Left)) == AnchorStyles.None);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [vertical centered].
        /// </summary>
        /// <value><c>true</c> if [vertical centered]; otherwise, <c>false</c>.</value>
        internal bool VerticalCentered
        {
            get
            {
                return ((this.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == AnchorStyles.None);
            }
        }

        /// <summary>
        /// Sets the scroll top.
        /// </summary>
        /// <param name="intTop">The int top.</param>
        /// <returns></returns>
        protected bool SetScrollTop(int intTop)
        {

            return this.SetValue<int>(Control.ScrollTopProperty, intTop);
        }

        /// <summary>
        /// Gets or sets the ScrollLeft property.
        /// </summary>
        /// <value>The ScrollLeft property</value>
        protected int ScrollLeft
        {
            get
            {
                return this.GetValue<int>(Control.ScrollLeftProperty);
            }
            set
            {
                // Set scroll left and update control if value changed
                if (this.SetScrollLeft(value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Sets the scroll left internal.
        /// </summary>
        /// <value>The scroll left internal.</value>
        protected bool SetScrollLeft(int intLeft)
        {
            return this.SetValue<int>(Control.ScrollLeftProperty, intLeft);
        }

        /// <summary>
        /// Gets or sets the control visability.  
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        [SRDescription("ControlVisibleDescr")]
        [SRCategory("CatBehavior")]
        public bool Visible
        {
            get
            {
                //in design time we should return the state of the control
                //if not , the child control will get the visible property from one of 
                //his fathers.
                //If one of the fathers will have visible = false at design time , the
                //control will get visible = false at design time and will be like that 
                //at run time also.
                if (this.DesignMode)
                {
                    return this.GetState(ComponentState.Visible);
                }
                else
                {
                    return this.GetVisibleCore();
                }
            }
            set
            {
                SetVisibleInternal(value);
            }
        }

        //protected bool RenderNonVisible

        /// <summary>
        /// Sets the visible internal.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> set visibility true.</param>
        internal virtual void SetVisibleInternal(bool blnValue)
        {
            // If the visible value should change
            if (this.VisibleIntenal != blnValue)
            {
                SetVisibleCore(blnValue);

                // Invalidate parent layout.
                this.InvalidateParentLayout(new LayoutEventArgs(false, true, false));

                this.Update();
            }
        }

        /// <summary>
        /// Returns the visibility internally
        /// </summary>
        /// <returns></returns>
        internal virtual bool GetVisibleCore()
        {
            // Get visibility from the current control
            if (!this.GetState(ComponentState.Visible))
            {
                // Current control is invisible
                return false;
            }

            // If parent exists return it's visible state, otherwise return true.
            Control objParent = this.ParentInternal;
            if (objParent != null)
            {
                return objParent.GetVisibleCore();
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Selects the next if focused.
        /// </summary>
        private void SelectNextIfFocused()
        {
            // If has a parent and focus, select next control
            Control objParent = this.ParentInternal;
            if (this.ContainsFocus && (objParent != null))
            {
                // If has a container, select next control
                IContainerControl objContainerControlInternal = objParent.GetContainerControlInternal();
                if (objContainerControlInternal != null)
                {
                    ((Control)objContainerControlInternal).SelectNextControlInternal(this, true, true, true, true);
                }
            }
        }

        /// <summary>Sets the control to the specified visible state.</summary>
        /// <param name="blnValue">true to make the control visible; otherwise, false. </param>
        protected virtual void SetVisibleCore(bool blnValue)
        {
            if (this.GetVisibleCore() != blnValue)
            {
                // If invisible
                if (!blnValue)
                {
                    this.SelectNextIfFocused();
                }
                // A flag to fire a property changed event
                bool blnFirePropertyChanged = false;

                // Set visibility and create control in case that: 
                // 1. Handled was created.
                // 2. Visibility is going to turn to true and the control's parent was created.
                // 3. Visibility is going to turn to true and the control is a top level control (Form for example).
                Control objControl = this.Parent;
                if (((blnValue && (objControl != null)) && objControl.Created) ||
                    (blnValue && this.GetTopLevel()))
                {
                    // Update the component state
                    this.VisibleIntenal = blnValue;
                    blnFirePropertyChanged = true;
                    try
                    {
                        if (blnValue)
                        {
                            this.CreateControl();
                        }
                    }
                    catch
                    {
                        // Update the component state
                        this.VisibleIntenal = !blnValue;
                        throw;
                    }
                }
                if (this.GetVisibleCore() != blnValue)
                {
                    // Update the component state
                    this.VisibleIntenal = blnValue;
                    blnFirePropertyChanged = true;
                }
                if (blnFirePropertyChanged)
                {
                    // Fire visible changed
                    FireObservableItemPropertyChanged("Visible");

                    // Raise VisibleChanged event
                    OnVisibleChanged(EventArgs.Empty);
                }
            }
            else if (this.VisibleIntenal || blnValue)
            {
                // Update the component state
                this.VisibleIntenal = blnValue;
            }
        }

        /// <summary>
        /// Gets or sets the control enabled state.  
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        [SRDescription("ControlEnabledDescr")]
        [SRCategory("CatBehavior")]
        public virtual bool Enabled
        {
            get
            {
                // Check enabled state.
                bool blnEnabled = this.GetState(ComponentState.Enabled);
                if (this.DesignMode)
                {
                    // Return enabled state.
                    return blnEnabled;
                }
                else
                {
                    // If current control is disabled
                    if (!blnEnabled)
                    {
                        return false;
                    }
                    else
                    {
                        // If parent exists return it's state, otherwise return true.
                        Control objControl = this.ParentInternal;
                        if (objControl != null)
                        {
                            return objControl.Enabled;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            set
            {
                SetEnabled(value, AttributeType.Enabled);
            }
        }

        /// <summary>
        /// Sets the enabled.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="enmAttributeTypes">The enm attribute types.</param>
        protected void SetEnabled(bool value, AttributeType enmAttributeTypes)
        {
            SetEnabled(value, enmAttributeTypes, true);
        }


        /// <summary>
        /// Sets the enabled.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="enmAttributeTypes">The enm attribute types.</param>
        /// <param name="blnUseClientUpdateHandler">if set to <c>true</c> [BLN use client update handler].</param>
        protected void SetEnabled(bool value, AttributeType enmAttributeTypes, bool blnUseClientUpdateHandler)
        {
            // Set the enabled value and raise events / update control if value had changed
            if (this.SetStateWithCheck(ComponentState.Enabled, value))
            {
                // Raise enabled changed event
                this.OnEnabledChanged(EventArgs.Empty);
                this.FireObservableItemPropertyChanged("Enabled");

                // Update the control to reflect changes
                this.UpdateParams(enmAttributeTypes, blnUseClientUpdateHandler);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [enabled internal].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enabled internal]; otherwise, <c>false</c>.
        /// </value>
        private bool EnabledInternal
        {
            get
            {
                // Check enabled state.
                return this.GetState(ComponentState.Enabled);
            }
        }

        /// <summary>Gets a value indicating whether the control has a handle associated with it.</summary>
        /// <returns>true if a handle has been assigned to the control; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), SRDescription("ControlHandleCreatedDescr"), System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsHandleCreated
        {
            get
            {
                return this.IsRegistered;
            }
        }

        /// <summary>Gets a value indicating whether the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing.</summary>
        /// <returns>true if the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing; otherwise, false.</returns>
        [System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), SRDescription("ControlDisposingDescr"), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool Disposing
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the control has been disposed of.</summary>
        /// <returns>true if the control has been disposed of; otherwise, false.</returns>
        /// <filterpriority>2</filterpriority>
        [SRDescription("ControlDisposedDescr"), System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        public bool IsDisposed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the parent container control.
        /// </summary>
        /// <value>The parent container control.</value>
        internal ContainerControl ParentContainerControl
        {
            get
            {
                // Search up for a container control return it, Return null if not found.
                for (Control objCcontrol = this.ParentInternal; objCcontrol != null; objCcontrol = objCcontrol.ParentInternal)
                {
                    // If is a container control, return it.
                    if (objCcontrol is ContainerControl)
                    {
                        return (objCcontrol as ContainerControl);
                    }
                }
                return null;
            }
        }

        /// <summary>Gets the handle that the control is bound to.</summary>
        /// <returns>An <see cref="T:System.IntPtr"></see> that contains the handle of the control.</returns>
        /// <filterpriority>2</filterpriority>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false), SRDescription("ControlHandleDescr")]
        public IntPtr Handle
        {
            get
            {
                return new IntPtr(this.ID);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if tab stop is enabled; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        [SRDescription("ControlTabStopDescr")]
        [SRCategory("CatBehavior")]
        public virtual bool TabStop
        {
            get
            {
                return this.GetState(ControlState.TabStop);
            }
            set
            {
                // Set the tab stop and update the control if value had changed
                if (this.SetStateWithCheck(ControlState.TabStop, value))
                {
                    // Update the control to reflect the change
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.</summary>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
        [SRDescription("ControlBackgroundImageLayoutDescr"), System.ComponentModel.DefaultValue(ImageLayout.Tile), System.ComponentModel.Localizable(true), SRCategory("CatAppearance"), ProxyBrowsable(true)]
        public virtual ImageLayout BackgroundImageLayout
        {
            get
            {
                // Get the property from the property story
                return this.GetValue<ImageLayout>(Control.BackgroundImageLayoutProperty);
            }
            set
            {
                // Set the background image and if value had changed update control
                if (this.SetValue<ImageLayout>(Control.BackgroundImageLayoutProperty, value))
                {
                    // Update the control
                    this.Update();

                    // Raise the background layout changed event
                    this.OnBackgroundImageLayoutChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(null)]
        [SRDescription("ControlBackgroundImageDescr"), ProxyBrowsable(true)]
        [SRCategory("CatAppearance")]
        [System.ComponentModel.Localizable(true)]
        public virtual ResourceHandle BackgroundImage
        {
            get
            {
                return this.GetValue<ResourceHandle>(Control.BackgroundImageProperty);
            }
            set
            {
                // Set the resource handler to the property store
                if (this.SetValue<ResourceHandle>(Control.BackgroundImageProperty, value))
                {
                    // Update the control
                    this.Update();

                    // Raise the BackgroundImageChanged event.
                    this.OnBackgroundImageChanged(EventArgs.Empty);

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("BackgroundImage");
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance"), SRDescription("ControlFontDescr"), ProxyBrowsable(true)]
        public virtual Font Font
        {
            get
            {
                return this.GetValue<Font>(Control.FontProperty, this.DefaultControlFont);
            }
            set
            {
                // Set the current font value and if value cahnged raise events and update control
                if (this.SetValue<Font>(Control.FontProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    // Update control
                    this.Update();

                    // Raise the font changed event
                    this.OnFontChanged(EventArgs.Empty);

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Font");
                }
            }
        }

        /// <summary>Gets or sets where this control is scrolled to in <see cref="M:System.Windows.Forms.ScrollableControl.ScrollControlIntoView(System.Windows.Forms.Control)"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Point"></see> specifying the scroll location. The default is the upper-left corner of the control.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(typeof(Point), "0, 0")]
        public virtual Point AutoScrollOffset
        {
            get
            {
                return Point.Empty;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets the visual template.
        /// </summary>
        /// <value>
        /// The visual template.
        /// </value>
        [ProxyBrowsable(true)]
        [Description("Sets the appearance of the control without changing its state")]
        [SRCategory("CatAppearance")]

        public virtual VisualTemplate VisualTemplate
        {
            get
            {
                return this.GetValue<VisualTemplate>(Control.VisualTemplateProperty, null);
            }
            set
            {
                // Set the current font value and if value cahnged raise events and update control
                if (this.SetValue<VisualTemplate>(Control.VisualTemplateProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    // Update control
                    this.Update();

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("VisualTemplate");
                }
            }
        }

        /// <summary>
        /// Resets the visual template.
        /// </summary>
        private void ResetVisualTemplate()
        {
            this.RemoveValue<VisualTemplate>(Control.VisualTemplateProperty);
        }

        /// <summary>
        /// Shoulds the serialize visual template.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        internal bool ShouldSerializeVisualTemplate()
        {
            return this.ContainsValue<VisualTemplate>(Control.VisualTemplateProperty);
        }


        #endregion

        #region Positioning



        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlPaddingDescr"), Localizable(true), SRCategory("CatLayout"), ProxyBrowsable(true)]
        public virtual Padding Padding
        {
            get
            {
                return GetValue<Padding>(Control.PaddingProperty, this.DefaultPadding);
            }
            set
            {
                // Get current padding
                Padding objCurrentValue = this.Padding;

                // Set the padding value
                if (this.SetValue<Padding>(Control.PaddingProperty, value, this.DefaultPadding))
                {
                    // Raise padding changed event.
                    this.OnPaddingChanged(EventArgs.Empty);

                    // Update the control to reflect the new padding change
                    this.Update();

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Padding");

                    // Update child size
                    UpdateChildSize(objCurrentValue.Horizontal != value.Horizontal, objCurrentValue.Vertical != value.Vertical);
                }
            }
        }

        /// <summary>
        /// Computes the location of the specified screen point into client coordinates.
        /// </summary>
        /// <param name="objPoint">The point to be calculated.</param>
        /// <returns>point in client coordinates</returns>
        public Point PointToClient(Point objPoint)
        {
            Control objParent = this.Parent;

            //if this is a form
            if (objParent == null)
            {
                //return point as is
                return objPoint;
            }

            //else, calculate point in control's coordinates
            objPoint.X -= this.Left;
            objPoint.Y -= this.Top;

            //process parent
            return objParent.PointToClient(objPoint);
        }

        /// <summary>
        /// Points to screen.
        /// Not implemented by design.
        /// </summary>
        /// <param name="objPoint">The p.</param>
        /// <returns></returns>
        [Obsolete("Not implemented by design.")]
        public Point PointToScreen(Point objPoint)
        {
            return objPoint;
        }

        /// <summary>Gets or sets the space between controls.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
        /// <filterpriority>2</filterpriority>
        [Localizable(true), SRDescription("ControlMarginDescr"), SRCategory("CatLayout"), ProxyBrowsable(true)]
        public Padding Margin
        {
            get
            {
                return this.GetValue<Padding>(Control.MarginProperty, this.DefaultMargin);
            }
            set
            {
                // Get current padding
                Padding objCurrentValue = this.Margin;

                // Set the marring and update control if value changed
                if (this.SetValue<Padding>(Control.MarginProperty, value, this.DefaultMargin))
                {
                    // Update the control to reflect the new margin change
                    this.Update();

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Margin");

                    // Invalidate parent layout.
                    this.InvalidateParentLayout(new LayoutEventArgs(false, true, false));

                    // Update child size
                    UpdateChildSize(objCurrentValue.Horizontal != value.Horizontal, objCurrentValue.Vertical != value.Vertical);
                }
            }
        }

        /// <summary>
        /// Prevent serializing margin if not required
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        internal bool ShouldSerializeMargin()
        {
            return this.ContainsValue<Padding>(Control.MarginProperty);
        }


        /// <summary>
        /// Prevent serializing padding if not required
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        internal bool ShouldSerializePadding()
        {
            return this.ContainsValue<Padding>(Control.PaddingProperty);
        }

        /// <summary>
        /// Gets the doch style.
        /// </summary>
        /// <returns></returns>
        internal virtual DockStyle GetDockInternal()
        {
            // Gets the current docking style
            return menmDock;
        }

        /// <summary>
        /// Gets/Sets the controls docking style
        /// </summary>
        [System.ComponentModel.DefaultValue(DockStyle.None)]
        [SRCategory("CatLayout"), SRDescription("ControlDockDescr"), ProxyBrowsable(true)]
        public virtual DockStyle Dock
        {
            set
            {
                // If dock style has changed
                if (menmDock != value)
                {
                    
                    DockStyle enmCurrentVal = menmDock;

                    // Set the new value                    
                    menmDock = value;

                    // Update parent to redraw
                    if (this.Parent != null)
                    {
                        this.Parent.UpdateParams(AttributeType.Redraw);
                    }

                    // Set anchor value back to default.
                    menmAnchor = AnchorStyles.Left | AnchorStyles.Top;

                    // Applies the pre release dock fill compatibility.
                    this.ApplyPreReleaseDockFillCompatibility();

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Dock");

                    // Update params.
                    this.UpdateParams(AttributeType.Layout);

                    //Update the layout of the child controls
                    UpdateChildSizeAfterDockChange(enmCurrentVal, menmDock);
                }
            }
            get
            {
                // Gets the current docking style
                return GetDockInternal();
            }
        }

        /// <summary>
        /// Updates the child controls size when the docking has changed
        /// </summary>
        /// <param name="enmCurrentVal">The old docking value</param>
        /// <param name="enmNewVal">The new docking value</param>
        private void UpdateChildSizeAfterDockChange(DockStyle enmCurrentVal, DockStyle enmNewVal)
        {
            bool blnHorizontal = false;
            bool blnVertical = false;

            if (((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right))
                || ((enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top))
                || (enmCurrentVal == DockStyle.None && enmNewVal != DockStyle.None) || (enmNewVal == DockStyle.None && enmCurrentVal != DockStyle.None))
            {
                blnHorizontal = true;
                blnVertical = true;
            }
            else if (((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && enmNewVal == DockStyle.Fill)
                || (enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top)))
            {
                blnVertical = true;
            }
            else if (((enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && enmNewVal == DockStyle.Fill)
                || (enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right)))
            {
                blnHorizontal = true;
            }
            if (blnHorizontal || blnVertical)
            {
                UpdateChildSize(blnHorizontal, blnVertical);
            }
        }

        /// <summary>
        /// Gets the component offsprings.
        /// </summary>
        /// <param name="strOffspringTypeName">The offspring type.</param>
        /// <returns></returns>
        protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
        {
            return this.Controls;
        }

        /// <summary>
        /// Gets the anchor style.
        /// </summary>
        /// <returns></returns>
        internal virtual AnchorStyles GetAnchorInternal()
        {
            // Gets the current anchor style
            return menmAnchor;
        }

        /// <summary>
        /// Gets or sets the anchoring style.
        /// </summary>
        /// <value></value>
        [SRCategory("CatLayout"), SRDescription("ControlAnchorDescr"), ProxyBrowsable(true)]
        public virtual AnchorStyles Anchor
        {
            get
            {
                return GetAnchorInternal();
            }
            set
            {
                // If anchor style has changed
                if (menmAnchor != value)
                {
                    // Set anchor
                    menmAnchor = value;

                    // Revert dock style to default
                    menmDock = DockStyle.None;

                    // Update current control
                    this.Update();

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Anchor");
                }
            }
        }

        /// <summary>This property is not relevant for this class.</summary>
        /// <returns>true if enabled; otherwise, false.</returns>
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All), System.ComponentModel.Localizable(true), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), SRDescription("ControlAutoSizeDescr"), SRCategory("CatLayout"), System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.ComponentModel.DefaultValue(false)]
        public virtual bool AutoSize
        {
            get
            {
                return this.GetState(ControlState.AutoSize);
            }
            set
            {
                // If auto size is diffrent
                if (this.SetStateWithCheck(ControlState.AutoSize, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    // Update the control to reflect the change
                    this.Update();

                    // Raise the autosize changed event
                    this.OnAutoSizeChanged(EventArgs.Empty);

                    // Rasie the property changed event
                    FireObservableItemPropertyChanged("AutoSize");
                }
            }
        }

        /// <summary>
        /// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
        /// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
        /// </summary>
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All), System.ComponentModel.Localizable(true), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), SRDescription("ControlAutoSizeModeDescr"), SRCategory("CatLayout"), System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.ComponentModel.DefaultValue(AutoSizeMode.GrowOnly)]
        public virtual AutoSizeMode AutoSizeMode
        {
            get
            {
                return this.GetValue<AutoSizeMode>(Control.AutoSizeModeProperty);
            }
            set
            {
                if (this.SetValue<AutoSizeMode>(Control.AutoSizeModeProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the display rectangle.
        /// </summary>
        /// <value>The display rectangle.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Advanced), SRDescription("ControlDisplayRectangleDescr"), Browsable(false)]
        public virtual Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(this.Location, this.DisplaySize);
            }
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        /// <remarks>Provides enhancment for performance that cancels the need to get the location for setting the display size.</remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        protected virtual Size DisplaySize
        {
            get
            {
                // Return by default the control size
                return this.Size;
            }
        }

        /// <summary>
        /// Gets the control contained area offset.
        /// </summary>
        protected virtual PaddingValue ContainedAreaOffset
        {
            get
            {
                // Get Border from control, if border is visible
                if (this.BorderStyle != Forms.BorderStyle.None)
                {
                    // Get BorderWidth from Control
                    Padding objPadding = new Padding();
                    BorderWidth objBorderWidth = this.BorderWidth;

                    objPadding.Bottom = objBorderWidth.Bottom;
                    objPadding.Top = objBorderWidth.Top;
                    objPadding.Left = objBorderWidth.Left;
                    objPadding.Right = objBorderWidth.Right;

                    return new PaddingValue(objPadding);
                }

                return Padding.Empty;
            }
        }

        /// <summary>
        /// Gets the horizontal contained area offset.
        /// </summary>
        private int HorizontalContainedAreaOffset
        {
            get
            {
                PaddingValue objContainedAreaOffset = this.ContainedAreaOffset;
                return objContainedAreaOffset.Left + objContainedAreaOffset.Right;
            }
        }

        /// <summary>
        /// Gets the vertical contained area offset.
        /// </summary>
        private int VerticalContainedAreaOffset
        {
            get
            {
                PaddingValue objContainedAreaOffset = this.ContainedAreaOffset;
                return objContainedAreaOffset.Top + objContainedAreaOffset.Bottom;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this control requires layout. Will effect controls with autosize or autoscrol.
        /// </summary>
        /// <value><c>true</c> if control requires layout; otherwise, <c>false</c>.</value>
        internal virtual bool RequiresLayout
        {
            get
            {
                return this.AutoSize;
            }
        }

        /// <summary>
        /// Gets or sets the control location.
        /// </summary>
        /// <value></value>
        [Localizable(true), SRCategory("CatLayout"), SRDescription("ControlLocationDescr"), ProxyBrowsable(true)]
        public Point Location
        {
            get
            {
                return new Point(Left, Top);
            }
            set
            {
                // If the location value has changed
                if (this.SetBounds(value.X, value.Y, 0, 0, BoundsSpecified.Location))
                {
                    //Raise the LocationChanged event
                    OnLocationChangedInternal(new LayoutEventArgs(false, false, true));

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Location");

                    // If the control is not docked we need update the control
                    if (!this.IsDocked(this.Dock))
                    {
                        // Update params.
                        this.UpdateParams(AttributeType.Layout);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [Localizable(true), SRCategory("CatLayout"), SRDescription("ControlSizeDescr"), ProxyBrowsable(true)]
        public Size Size
        {
            get
            {
                return new Size(Width, Height);
            }
            set
            {
                // If value has changed
                if (this.SetBounds(0, 0, value.Width, value.Height, BoundsSpecified.Size))
                {
                    // Raise the size chaged event
                    OnResizeInternal(new LayoutEventArgs(false, true, true));

                    // Fire event property changed
                    this.FireObservableItemPropertyChanged("Size");

                    // Updates layuout params.
                    UpdateSizeLayuoutParams(true, false);
                }
            }
        }

        /// <summary>
        /// Updates the size layuout params.
        /// </summary>
        /// <param name="blnUpdateCurrent">if set to <c>true</c> [BLN update current].</param>
        /// <param name="blnForceChildUpdate">if set to <c>true</c> [BLN force child update].</param>
        private void UpdateSizeLayuoutParams(bool blnUpdateCurrent, bool blnForceChildUpdate)
        {
            if (blnUpdateCurrent)
            {
                // Update params.
                this.UpdateParams(AttributeType.Layout);
            }

            // Check if layout is suspended.
            if (this.IsLayoutSuspended || blnForceChildUpdate)
            {
                // Loop all child controls.
                foreach (Control objChildControl in this.Controls)
                {
                    // Take child anchor value.
                    AnchorStyles enmChildAnchor = objChildControl.Anchor;

                    // Check if anchoring has bottom or right style.
                    if (objChildControl.IsRightAnchored(enmChildAnchor) || objChildControl.IsBottomAnchored(enmChildAnchor))
                    {
                        // Update params.
                        objChildControl.UpdateParams(AttributeType.Layout);

                        // Loop all child controls.
                        foreach (Control objSubChildControl in objChildControl.Controls)
                        {
                            // Take sub child anchor value.
                            AnchorStyles enmSubChildAnchor = objSubChildControl.Anchor;

                            // Take sub child dock value.
                            DockStyle enmSubChildDock = objSubChildControl.Dock;

                            // Check if sub control should be effected by parent resizing.
                            if (objSubChildControl.SizeEffectedByParentResizing(enmSubChildAnchor, enmSubChildDock))
                            {
                                // Execute recursion on sub child. 
                                // Request to update sub child params only if it is effected by parent resizing out of anchoring.
                                objSubChildControl.UpdateSizeLayuoutParams(enmSubChildDock == DockStyle.None, true);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the size of the child.
        /// </summary>
        private void UpdateChildSize(bool blnHorizontal, bool blnVertical)
        {
            // Check if layout is suspended.
            if (!this.IsLayoutSuspended)
            {
                // Loop all child controls.
                foreach (Control objChildControl in this.Controls)
                {
                    // Take child anchor and dock value.
                    AnchorStyles enmChildAnchor = objChildControl.Anchor;
                    DockStyle enmChildDock = objChildControl.Dock;

                    // Check if anchoring has bottom or right style.
                    if ((enmChildDock == DockStyle.Fill && (blnHorizontal || blnVertical)) ||
                        (blnHorizontal && ((objChildControl.IsRightAnchored(enmChildAnchor) && objChildControl.IsLeftAnchored(enmChildAnchor)) || enmChildDock == DockStyle.Top || enmChildDock == DockStyle.Bottom)) ||
                        (blnVertical && ((objChildControl.IsTopAnchored(enmChildAnchor) && objChildControl.IsBottomAnchored(enmChildAnchor)) || enmChildDock == DockStyle.Left || enmChildDock == DockStyle.Right)))
                    {
                        objChildControl.OnResizeInternal(new LayoutEventArgs(false, false, false));
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use WG namespace.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to use WG namespace; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool UseWGNamespace
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [size effected by parent resizing].
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns></returns>
        /// <value>
        /// 	<c>true</c> if [size effected by parent resizing]; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool SizeEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
        {
            // Flag indicating if Size is effected by resizing
            bool blnSizeEffectedByParentResizing = false;

            // Check if parent exists.
            if (this.Parent != null)
            {
                // Check for any docking.
                blnSizeEffectedByParentResizing |= (enmDock != DockStyle.None);

                // Check if both left and right anchoring is set.
                blnSizeEffectedByParentResizing |= ((enmAnchor & AnchorStyles.Left) != AnchorStyles.None) && ((enmAnchor & AnchorStyles.Right) != AnchorStyles.None);

                // Check if both top and bottom anchoring is set.
                blnSizeEffectedByParentResizing |= ((enmAnchor & AnchorStyles.Top) != AnchorStyles.None) && ((enmAnchor & AnchorStyles.Bottom) != AnchorStyles.None);
            }

            return blnSizeEffectedByParentResizing;
        }

        /// <summary>
        /// Gets a value indicating whether [location effected by parent resizing].
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns></returns>
        /// <value>
        /// 	<c>true</c> if [location effected by parent resizing]; otherwise, <c>false</c>.
        /// </value>
        internal bool LocationEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
        {
            // Flag indicating if location is effected by resizing
            bool blnLocationEffectedByParentResizing = false;

            // Check if parent exists.
            if (this.Parent != null)
            {
                // If is right anchored and not left
                blnLocationEffectedByParentResizing |= ((enmAnchor & AnchorStyles.Right) != AnchorStyles.None) && ((enmAnchor & AnchorStyles.Left) == AnchorStyles.None);

                // If is bottom anchored but not top
                blnLocationEffectedByParentResizing |= ((enmAnchor & AnchorStyles.Bottom) != AnchorStyles.None) && ((enmAnchor & AnchorStyles.Top) == AnchorStyles.None);

                // If is docked to the right
                blnLocationEffectedByParentResizing |= (enmDock == DockStyle.Right);

                // If is docked to the left
                blnLocationEffectedByParentResizing |= (enmDock == DockStyle.Bottom);

            }

            return blnLocationEffectedByParentResizing;
        }


        /// <summary>
        /// Gets the layout location.
        /// </summary>
        /// <value>The layout location.</value>
        internal Point LayoutLocation
        {
            get
            {
                return new Point(mintLeft, mintTop);
            }
        }



        /// <summary>
        /// Gets or sets the tab index.
        /// </summary>
        /// <value></value>
        [SRDescription("ControlTabIndexDescr"), MergableProperty(false), Localizable(true), SRCategory("CatBehavior")]
        public int TabIndex
        {
            get
            {
                // If value differs from -1, return it. Otherwise - return 0.
                if (this.mintTabIndex != -1)
                {
                    return this.mintTabIndex;
                }
                return 0;
            }
            set
            {
                if (value < 0)
                {
                    object[] arrArgs = new object[] { "TabIndex", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("TabIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }
                this.mintTabIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [validation cancelled].
        /// </summary>
        /// <value><c>true</c> if [validation cancelled]; otherwise, <c>false</c>.</value>
        internal bool ValidationCancelled
        {
            get
            {
                // Get the value from the property store, if true - return true
                if (this.GetState(ControlState.ValidationCancelled))
                {
                    return true;
                }
                // Else, If parent exists - return parent value, false otherwise.
                Control objParent = this.ParentInternal;
                if (objParent != null)
                {
                    return objParent.ValidationCancelled;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                this.SetState(ControlState.ValidationCancelled, value);
            }
        }

        /// <summary>
        /// Gets/Sets the top position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Top
        {
            set
            {
                // If top value had changed
                if (this.SetBounds(0, value, 0, 0, BoundsSpecified.Y))
                {
                    // If the control is not docked we need update the control
                    if (!this.IsDocked(this.Dock))
                    {
                        // Raise the LocationChanged event
                        OnLocationChangedInternal(new LayoutEventArgs(false, false, true));

                        // Update params.
                        this.UpdateParams(AttributeType.Layout);
                    }
                }
            }
            get
            {
                return GetCalculatedTop(this.IsLayoutSuspended || this.DesignMode);
            }
        }


        /// <summary>
        /// Gets/Sets the bottom position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Bottom
        {
            get
            {
                return this.Top + this.Height;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to force content availability on client side.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [force content availability on client side]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), SRDescription("ForceContentAvailabilityOnClientDescr"), SRCategory("CatBehavior")]
        public bool ForceContentAvailabilityOnClient
        {
            get
            {
                return this.GetValue<bool>(Control.ForceContentAvailabilityOnClientProperty);
            }
            set
            {
                if (this.SetValue<bool>(Control.ForceContentAvailabilityOnClientProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets/Sets the left position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Left
        {
            set
            {
                // If left value had changed
                if (this.SetBounds(value, 0, 0, 0, BoundsSpecified.X))
                {
                    // If the control is not docked we need update the control
                    if (!this.IsDocked(this.Dock))
                    {
                        // Raise the LocationChanged event
                        OnLocationChangedInternal(new LayoutEventArgs(false, false, true));

                        // Update params.
                        this.UpdateParams(AttributeType.Layout);
                    }
                }
            }
            get
            {
                return GetCalculatedLeft(this.IsLayoutSuspended || this.DesignMode);
            }
        }


        /// <summary>
        /// Gets the height of the layout.
        /// </summary>
        /// <value>The height of the layout.</value>
        internal int LayoutHeight
        {
            get
            {
                return mintHeight;
            }
        }

        /// <summary>
        /// Gets the width of the layout.
        /// </summary>
        /// <value>The width of the layout.</value>
        internal int LayoutWidth
        {
            get
            {
                return mintWidth;
            }
        }

        /// <summary>
        /// Gets the left value relative to the center of the container
        /// </summary>
        private int CenteredLeft
        {
            get
            {
                // Get parent control.
                Control objParent = this.Parent;
                if (objParent != null)
                {
                    // Check if parent is a table layout panel.
                    if (objParent is TableLayoutPanel)
                    {
                        // Return centered position
                        return -(this.Width / 2);
                    }
                    else
                    {
                        // Return centered position
                        return this.LayoutLeft - (objParent.mintLayoutWidth / 2);
                    }
                }

                // Return default zero.
                return 0;
            }
        }

        /// <summary>
        /// Gets the top value relative to the center of the container
        /// </summary>
        private int CenteredTop
        {
            get
            {
                // Get parent control.
                Control objParent = this.Parent;
                if (objParent != null)
                {
                    // Check if parent is a table layout panel.
                    if (objParent is TableLayoutPanel)
                    {
                        // Return centered position
                        return -(this.Height / 2);
                    }
                    else
                    {
                        // Return centered position
                        return this.LayoutTop - (objParent.mintLayoutHeight / 2);
                    }
                }

                // Return default zero.
                return 0;
            }
        }


        /// <summary>
        /// Gets the layout left.
        /// </summary>
        /// <value>The layout left.</value>
        internal int LayoutLeft
        {
            get
            {
                return mintLeft;
            }
        }

        /// <summary>
        /// Gets the layout right (based on the layout width).
        /// </summary>
        /// <value>The layout right.</value>
        internal int LayoutRight
        {
            get
            {
                // Get control parent
                Control objParent = this.Parent;

                // If there is a valid parent
                if (objParent != null)
                {
                    // Try getting a scrollable control parent.
                    ScrollableControl objScrollableParent = objParent as ScrollableControl;
                    if (objScrollableParent != null)
                    {
                        // Check if scrollable control parent is in auto scroll mode. 
                        if (objScrollableParent.AutoScroll)
                        {
                            // Get parent's display size.
                            Size objParentDisplaySize = objScrollableParent.DisplaySize;

                            // Check if parent's display width is bigger then its layout width.
                            if (objParentDisplaySize.Width > objParent.mintLayoutWidth)
                            {
                                // Calculate the bottom position based on the width
                                return objParentDisplaySize.Width - (mintLeft + this.Width);
                            }
                        }
                    }

                    // Calculate the bottom position based on the layout height
                    return objParent.mintLayoutWidth - (mintLeft + this.Width);
                }
                else
                {
                    return mintLeft + mintWidth;
                }
            }
        }

        /// <summary>
        /// Gets the layout bottom (based on the layout height).
        /// </summary>
        /// <value>The layout bottom.</value>
        internal int LayoutBottom
        {
            get
            {
                // Get control parent
                Control objParent = this.Parent;

                // If there is a valid parent
                if (objParent != null)
                {
                    // Try getting a scrollable control parent.
                    ScrollableControl objScrollableParent = objParent as ScrollableControl;
                    if (objScrollableParent != null)
                    {
                        // Check if scrollable control parent is in auto scroll mode. 
                        if (objScrollableParent.AutoScroll)
                        {
                            // Get parent's display size.
                            Size objParentDisplaySize = objScrollableParent.DisplaySize;

                            // Check if parent's display height is bigger then its layout height.
                            if (objParentDisplaySize.Height > objParent.mintLayoutHeight)
                            {
                                // Calculate the bottom position based on the height
                                return objParentDisplaySize.Height - (mintTop + this.Height);
                            }
                        }
                    }

                    // Calculate the bottom position based on the height
                    return objParent.mintLayoutHeight - (mintTop + this.Height);
                }
                else
                {
                    return mintTop + mintHeight;
                }
            }
        }

        /// <summary>
        /// Gets the layout top.
        /// </summary>
        /// <value>The layout top.</value>
        internal int LayoutTop
        {
            get
            {
                return mintTop;
            }
        }


        /// <summary>Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.</summary>
        /// <returns>true if the control causes validation to be performed on any controls requiring validation when it receives focus; otherwise, false. The default is true.</returns>
        /// <filterpriority>2</filterpriority>
        [DefaultValue(true), SRDescription("ControlCausesValidationDescr"), SRCategory("CatFocus")]
        public bool CausesValidation
        {
            get
            {
                return this.GetState(ControlState.CausesValidation);
            }
            set
            {
                if (this.SetStateWithCheck(ControlState.CausesValidation, value))
                {
                    this.OnCausesValidationChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets/Sets the right position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Right
        {
            get
            {
                return (this.Left + this.Width);
            }
        }

        /// <summary>Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRDescription("ControlRightToLeftDescr"), SRCategory("CatAppearance"), System.ComponentModel.Localizable(true)]
        public virtual RightToLeft RightToLeft
        {
            get
            {
                RightToLeft enmRightToLeft = this.GetValue<RightToLeft>(Control.RightToLeftProperty);
                if (enmRightToLeft == RightToLeft.Inherit)
                {
                    Control objParentInternal = this.ParentInternal;
                    if (objParentInternal != null)
                    {
                        enmRightToLeft = objParentInternal.RightToLeft;
                    }
                    else
                    {
                        if (this.Context != null)
                        {
                            enmRightToLeft = this.Context.RightToLeft ? RightToLeft.Yes : RightToLeft.No;
                        }
                        else
                        {
                            enmRightToLeft = RightToLeft.No;
                        }
                    }
                }
                return enmRightToLeft;
            }
            set
            {
                if (this.SetValue<RightToLeft>(Control.RightToLeftProperty, value))
                {
                    this.UpdateParams(AttributeType.Visual);
                }
            }
        }





        /// <summary>
        /// Gets/Sets the height position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Height
        {
            set
            {
                this.SetHeight(value, true);
            }
            get
            {
                return GetCalculatedHeight(this.IsLayoutSuspended || this.DesignMode);
            }
        }


        /// <summary>
        /// Sets the height.
        /// </summary>
        /// <param name="intHeight">Height of the int.</param>
        /// <param name="blnUpdateCurrent">if set to <c>true</c> [BLN update current].</param>
        protected void SetHeight(int intHeight, bool blnUpdateCurrent)
        {
            // If value has changed
            if (this.SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height))
            {
                // Raise the size changed event
                OnResizeInternal(new LayoutEventArgs(false, true, true));

                // Get the control docking
                DockStyle enmDock = this.Dock;

                // If should redraw control
                if (enmDock != DockStyle.Fill && enmDock != DockStyle.Left && enmDock != DockStyle.Right)
                {
                    // Updates layuout params.
                    UpdateSizeLayuoutParams(blnUpdateCurrent, false);
                }
            }
        }

        /// <summary>
        /// Gets the calculated height.
        /// </summary>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        protected virtual int GetCalculatedHeight(bool blnUseLayoutValues)
        {
            int intCalculatedHeight = this.mintHeight;

            // User control has its own design
            if (!blnUseLayoutValues)
            {
                // Try to get parent control
                Control objParent = InternalParent as Control;
                if (objParent != null)
                {
                    // Get the control docking state
                    DockStyle enmDockStyle = this.Dock;

                    // Check if should use preferred size.
                    bool blnUsePreferredSize = (this.UsePreferredSize && (this.IsVerticalDocked(enmDockStyle) || !this.IsDocked(enmDockStyle)));

                    // If need to use preferred size
                    if (blnUsePreferredSize)
                    {
                        intCalculatedHeight = this.PreferredSize.Height;

                        // Apply bounds
                        Rectangle objBounded = this.ApplyBoundsConstraints(mintLeft, mintTop, Width, intCalculatedHeight);
                        intCalculatedHeight = objBounded.Height;
                    }
                    else if (!(objParent is FlowLayoutPanel))
                    {
                        // If control is left or right docked.
                        if ((enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right) || enmDockStyle == DockStyle.Fill)
                        {
                            // Try cast current parent to tale layout panel.
                            TableLayoutPanel objTableLayoutPanel = objParent as TableLayoutPanel;
                            if (objTableLayoutPanel != null)
                            {
                                // Get control's calculated height out of parent table layout panel.
                                intCalculatedHeight = Convert.ToInt32(objTableLayoutPanel.GetControlCalculatedHeight(this, blnUseLayoutValues));
                            }
                            else
                            {
                                // Parent padding vertical size
                                int intPadding = objParent.Padding.Vertical;

                                // Get current control index
                                int intControlIndex = objParent.Controls.IndexOf(this);

                                // Loop all controls that has been added to parent before this control.
                                for (int intIndex = objParent.Controls.Count - 1; intIndex > intControlIndex; intIndex--)
                                {
                                    // Skip over current control
                                    if (intIndex != intControlIndex)
                                    {
                                        Control objCurrentControl = objParent.Controls[intIndex];

                                        // Check that the control is visible
                                        if (objCurrentControl.GetState(ComponentState.Visible))
                                        {
                                            // Get the control docking state
                                            DockStyle enmCurrentDockStyle = objCurrentControl.Dock;
                                            if ((enmCurrentDockStyle == DockStyle.Top) | (enmCurrentDockStyle == DockStyle.Bottom))
                                            {
                                                intPadding += objCurrentControl.Height;
                                            }
                                        }
                                    }
                                }

                                // Calculate parentr height.
                                intCalculatedHeight = objParent.GetCalculatedHeight(blnUseLayoutValues) - intPadding;

                                // Get minimum size.
                                Size objMinimumSize = this.MinimumSize;
                                if (!objMinimumSize.IsEmpty && objMinimumSize.Height != 0)
                                {
                                    // Get maximal height.
                                    intCalculatedHeight = Math.Max(intCalculatedHeight, objMinimumSize.Height);
                                }

                                // Get maximium size.
                                Size objMaximumSize = this.MaximumSize;
                                if (!objMaximumSize.IsEmpty && objMaximumSize.Height != 0)
                                {
                                    // Get minimial height.
                                    intCalculatedHeight = Math.Min(intCalculatedHeight, objMaximumSize.Height);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Apply bounds
                        Rectangle objBounded = this.ApplyBoundsConstraints(mintLeft, mintTop, Width, intCalculatedHeight);
                        intCalculatedHeight = objBounded.Height;
                    }
                }
            }

            return intCalculatedHeight;
        }


        /// <summary>
        /// Gets/Sets the width position
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int Width
        {
            set
            {
                // If value has changed
                if (this.SetBounds(0, 0, value, 0, BoundsSpecified.Width))
                {
                    // Raise the size changed event
                    OnResizeInternal(new LayoutEventArgs(false, true, true));

                    // Get the control docking
                    DockStyle enmDock = this.Dock;

                    // If should redraw control
                    if (enmDock != DockStyle.Fill && enmDock != DockStyle.Top && enmDock != DockStyle.Bottom)
                    {
                        // Updates layuout params.
                        UpdateSizeLayuoutParams(true, false);
                    }
                }
            }
            get
            {
                return GetCalculatedWidth(this.IsLayoutSuspended || this.DesignMode);
            }
        }

        /// <summary>
        /// Gets the calculated top.
        /// </summary>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> use layout values.</param>
        /// <returns></returns>
        protected int GetCalculatedTop(bool blnUseLayoutValues)
        {
            DockStyle enmDock = this.Dock;

            // If use layout values or not set to parent
            if (blnUseLayoutValues || this.Parent == null || !this.IsDocked(enmDock))
            {
                // Return the layout top
                return this.mintTop;
            }
            else
            {
                // Get current parent.
                Control objParent = this.Parent;

                // Try cast current parent to table layout panel.
                TableLayoutPanel objTableLayoutPanel = objParent as TableLayoutPanel;
                if (objTableLayoutPanel != null)
                {
                    // Get control calculated top out of parent table layout panel.
                    return Convert.ToInt32(objTableLayoutPanel.GetControlCalculatedTop(this, blnUseLayoutValues));
                }

                // If is bottom docked
                if (this.IsBottomDocked(enmDock))
                {
                    return objParent.DisplayRectangle.Height - this.Height - GetDockBoundries(DockStyle.Bottom);
                }
                else // if is docked top/left/right/fill
                {
                    return GetDockBoundries(DockStyle.Top);
                }
            }
        }

        /// <summary>
        /// Gets the calculated left.
        /// </summary>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> use layout values.</param>
        /// <returns></returns>
        protected int GetCalculatedLeft(bool blnUseLayoutValues)
        {
            DockStyle enmDock = this.Dock;

            // If use layout values or not set to parent
            if (blnUseLayoutValues || this.Parent == null || !this.IsDocked(enmDock))
            {
                // Return the layout left
                return this.mintLeft;
            }
            else
            {
                // Get current parent.
                Control objParent = this.Parent;

                // Try cast current parent to table layout panel.
                TableLayoutPanel objTableLayoutPanel = objParent as TableLayoutPanel;
                if (objTableLayoutPanel != null)
                {
                    // Get control calculated left out of parent table layout panel.
                    return Convert.ToInt32(objTableLayoutPanel.GetControlCalculatedLeft(this, blnUseLayoutValues));
                }

                // If is right docked
                if (this.IsRightDocked(enmDock))
                {
                    return objParent.DisplayRectangle.Width - this.Width - GetDockBoundries(DockStyle.Right);
                }
                else // if is left docked or fill
                {
                    return GetDockBoundries(DockStyle.Left);
                }
            }
        }

        /// <summary>
        /// Gets the dock boundries.
        /// </summary>
        /// <param name="enmDockStyle">The dock style.</param>
        /// <returns></returns>
        private int GetDockBoundries(DockStyle enmDockStyle)
        {
            // The calculated boundry
            int intSize = 0;

            // If has parent
            Control objParent = this.Parent;
            if (objParent != null)
            {
                // Add padding calculations
                switch (enmDockStyle)
                {
                    case DockStyle.Left:
                        intSize += objParent.Padding.Left;
                        break;
                    case DockStyle.Top:
                        intSize += objParent.Padding.Top;
                        break;
                    case DockStyle.Bottom:
                        intSize += objParent.Padding.Bottom;
                        break;
                    case DockStyle.Right:
                        intSize += objParent.Padding.Right;
                        break;
                }

                // Get parent control collection
                Control.ControlCollection objControls = objParent.Controls;

                // Get the current index
                int intCurrentIndex = objControls.IndexOf(this);

                // If control is positioned in the controls collection
                if (intCurrentIndex > -1)
                {
                    // Skip self
                    intCurrentIndex++;

                    // Loop all previous docked controls
                    while (intCurrentIndex < objControls.Count)
                    {
                        // Get current control
                        Control objControl = objControls[intCurrentIndex];

                        // If is the same docking
                        if (objControl.Dock == enmDockStyle)
                        {
                            // If is horizontal docking
                            if (enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right)
                            {
                                intSize += objControl.Width;
                            }
                            else
                            {
                                intSize += objControl.Height;
                            }
                        }

                        // Increment current control position
                        intCurrentIndex++;
                    }
                }
            }

            // return the calculated boundry
            return intSize;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is anchored.
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <returns>
        /// 	<c>true</c> if the specified enm anchor is anchored; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is anchored; otherwise, <c>false</c>.
        /// </value>
        internal bool IsAnchored(AnchorStyles enmAnchor)
        {
            return (enmAnchor != AnchorStyles.None);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if the specified enm dock is docked; otherwise, <c>false</c>.
        /// </returns>
        /// <value><c>true</c> if this instance is docked; otherwise, <c>false</c>.</value>
        internal bool IsDocked(DockStyle enmDock)
        {
            return (enmDock != DockStyle.None);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is right docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is right docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is right docked; otherwise, <c>false</c>.
        /// </value>
        internal bool IsRightDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Right);
        }

        /// <summary>
        /// Determines whether [is fill docked] [the specified enm dock].
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is fill docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsFillDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Fill);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is left docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is left docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is left docked; otherwise, <c>false</c>.
        /// </value>
        internal bool IsLeftDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Left);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is horizontal docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is left docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is left docked; otherwise, <c>false</c>.
        /// </value>
        internal bool IsHorizontalDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Left) || (enmDock == DockStyle.Right);
        }


        /// <summary>
        /// Determines whether is vertical docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is vertical docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsVerticalDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Top) || (enmDock == DockStyle.Bottom);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is top docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is top docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is top docked; otherwise, <c>false</c>.
        /// </value>
        internal bool IsTopDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Top);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is bottom docked.
        /// </summary>
        /// <param name="enmDock">The enm dock.</param>
        /// <returns>
        /// 	<c>true</c> if [is bottom docked] [the specified enm dock]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is bottom docked; otherwise, <c>false</c>.
        /// </value>
        internal bool IsBottomDocked(DockStyle enmDock)
        {
            return (enmDock == DockStyle.Bottom);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is right anchored.
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <returns>
        /// 	<c>true</c> if [is right anchored] [the specified enm anchor]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is right anchored; otherwise, <c>false</c>.
        /// </value>
        internal bool IsRightAnchored(AnchorStyles enmAnchor)
        {
            return (enmAnchor & AnchorStyles.Right) != AnchorStyles.None;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is left anchored.
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <returns>
        /// 	<c>true</c> if [is left anchored] [the specified enm anchor]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is left anchored; otherwise, <c>false</c>.
        /// </value>
        internal bool IsLeftAnchored(AnchorStyles enmAnchor)
        {
            return (enmAnchor & AnchorStyles.Left) != AnchorStyles.None;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is top anchored.
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <returns>
        /// 	<c>true</c> if [is top anchored] [the specified enm anchor]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is top anchored; otherwise, <c>false</c>.
        /// </value>
        internal bool IsTopAnchored(AnchorStyles enmAnchor)
        {
            return (enmAnchor & AnchorStyles.Top) != AnchorStyles.None;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is bottom anchored.
        /// </summary>
        /// <param name="enmAnchor">The enm anchor.</param>
        /// <returns>
        /// 	<c>true</c> if [is bottom anchored] [the specified enm anchor]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        /// 	<c>true</c> if this instance is bottom anchored; otherwise, <c>false</c>.
        /// </value>
        internal bool IsBottomAnchored(AnchorStyles enmAnchor)
        {
            return (enmAnchor & AnchorStyles.Bottom) != AnchorStyles.None;
        }

        /// <summary>
        /// Gets the calculated width.
        /// </summary>
        /// <param name="blnUseLayoutValues">if set to <c>true</c> [BLN use layout values].</param>
        /// <returns></returns>
        protected virtual int GetCalculatedWidth(bool blnUseLayoutValues)
        {
            int intCalculatedWidth = this.mintWidth;

            // User control has its own design
            if (!blnUseLayoutValues)
            {
                // Try to get parent control
                Control objParent = InternalParent as Control;
                if (objParent != null)
                {
                    // Get the control docking state
                    DockStyle enmDockStyle = this.Dock;

                    // Check if should use preferred size.
                    bool blnUsePreferredSize = (this.UsePreferredSize && (this.IsHorizontalDocked(enmDockStyle) || !this.IsDocked(enmDockStyle)));

                    // If need to use preferred size
                    if (blnUsePreferredSize)
                    {
                        intCalculatedWidth = this.PreferredSize.Width;

                        // Apply bounds
                        Rectangle objBounded = this.ApplyBoundsConstraints(mintLeft, mintTop, intCalculatedWidth, mintHeight);
                        intCalculatedWidth = objBounded.Width;
                    }
                    else if (!(objParent is FlowLayoutPanel))
                    {
                        // If control is top or bottom docked.
                        if ((enmDockStyle == DockStyle.Top || enmDockStyle == DockStyle.Bottom) || enmDockStyle == DockStyle.Fill)
                        {
                            // Try cast current parent to tale layout panel.
                            TableLayoutPanel objTableLayoutPanel = objParent as TableLayoutPanel;
                            if (objTableLayoutPanel != null)
                            {
                                // Get control calculated width out of parent table layout panel.
                                intCalculatedWidth = Convert.ToInt32(objTableLayoutPanel.GetControlCalculatedWidth(this, blnUseLayoutValues));
                            }
                            else
                            {
                                // Parent padding horizontal size
                                int intPadding = objParent.Padding.Horizontal;

                                // Get current control index
                                int intControlIndex = objParent.Controls.IndexOf(this);

                                // Loop all controls that has been added to parent before this control.
                                for (int intIndex = objParent.Controls.Count - 1; intIndex > intControlIndex; intIndex--)
                                {
                                    // Skip over current control
                                    if (intIndex != intControlIndex)
                                    {
                                        Control objCurrentControl = objParent.Controls[intIndex];

                                        // Check that the control is visible
                                        if (objCurrentControl.GetState(ComponentState.Visible))
                                        {
                                            // Get the control docking state
                                            DockStyle enmCurrentDockStyle = objCurrentControl.Dock;
                                            if ((enmCurrentDockStyle == DockStyle.Right) | (enmCurrentDockStyle == DockStyle.Left))
                                            {
                                                intPadding += objCurrentControl.Width;
                                            }
                                        }
                                    }
                                }

                                // Calculate parent width.
                                intCalculatedWidth = objParent.GetCalculatedWidth(blnUseLayoutValues) - intPadding;

                                // Get minimum size.
                                Size objMinimumSize = this.MinimumSize;
                                if (!objMinimumSize.IsEmpty && objMinimumSize.Width != 0)
                                {
                                    // Get maximal width.
                                    intCalculatedWidth = Math.Max(intCalculatedWidth, objMinimumSize.Width);
                                }

                                // Get maximium size.
                                Size objMaximumSize = this.MaximumSize;
                                if (!objMaximumSize.IsEmpty && objMaximumSize.Width != 0)
                                {
                                    // Get minimal width.
                                    intCalculatedWidth = Math.Min(intCalculatedWidth, objMaximumSize.Width);
                                }
                            }
                        }
                        else
                        {
                            // Apply bounds
                            Rectangle objBounded = this.ApplyBoundsConstraints(mintLeft, mintTop, intCalculatedWidth, mintHeight);
                            intCalculatedWidth = objBounded.Width;
                        }
                    }
                }
            }

            return intCalculatedWidth;
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance has positioning.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has positioning; otherwise, <c>false</c>.
        /// </value>
        protected bool HasPositioning
        {
            get
            {
                return this.GetState(ControlState.HasPositioning);
            }
            set
            {
                this.SetState(ControlState.HasPositioning, value);
            }
        }

        /// <summary>
        /// Gets or sets the client size of the form.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Size ClientSize
        {
            get
            {
                return this.Size;
            }
            set
            {
                this.Size = value;
            }
        }

        /// <summary>Gets or sets the shortcut menu associated with the control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenu"></see> that represents the shortcut menu associated with the control.</returns>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [SRDescription("ControlContextMenuDescr")]
        [SRCategory("CatBehavior")]
        public override ContextMenu ContextMenu
        {
            get
            {
                return base.ContextMenu;
            }
            set
            {
                base.ContextMenu = value;

                // Fire event property changed
                this.FireObservableItemPropertyChanged("ContextMenu");
            }
        }

        #endregion

        #region Styles

        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue("")]
        [SRDescription("ControlCustomStyleDescr"), ProxyBrowsable(true)]
        [SRCategory("CatAppearance")]
        public virtual string CustomStyle
        {
            get
            {
                return this.GetValue<string>(Control.CustomStyleProperty);
            }
            set
            {
                // Set the value and the value had changed update the control
                if (this.SetValue<string>(Control.CustomStyleProperty, value))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        /// <summary>Gets a value indicating whether the control has been created.</summary>
        /// <returns>true if the control has been created; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        [System.ComponentModel.Browsable(false)]
        [SRDescription("ControlCreatedDescr")]
        public bool Created
        {
            get
            {
                return this.GetState(ControlState.Created);
            }
        }

        /// <summary>
        /// Gets a flag indicating if the object is initializing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal override bool IsSerializableObjectInitializing
        {
            get
            {
                // If control was not yet created than it is in initialization mode
                return !this.GetState(ControlState.Created);
            }
        }


        /// <summary>
        /// Gets the initial size of the serializable filed storage.
        /// </summary>
        /// <value>The initial size of the serializable filed storage.</value>
        protected internal override int SerializableFieldStorageInitialSize
        {
            get
            {
                return 12;
            }
        }


        /// <summary>Gets or sets the cursor that is displayed when the mouse pointer is over the control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the control.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("ControlCursorDescr"), ProxyBrowsable(true)]
        public virtual Cursor Cursor
        {
            get
            {
                // Get current cursor from property store
                return this.GetValue<Cursor>(Control.CursorProperty);
            }
            set
            {
                // Set the cursor and if cursor is not current update the control
                if (this.SetValue<Cursor>(Control.CursorProperty, value))
                {
                    // Redraw the control
                    UpdateParams(AttributeType.Redraw);
                }
            }
        }

        /// <summary>
        /// Prevent serializing cursor if is default
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeCursor()
        {
            return this.ContainsValue<Cursor>(Control.CursorProperty);
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderStyleDescr"), ProxyBrowsable(true)]
        public virtual BorderStyle BorderStyle
        {
            get
            {
                // Return border style
                return this.GetValue<BorderStyle>(Control.BorderStyleProperty, this.DefaultBorderStyle);
            }
            set
            {
                // If border style is diffrent from what is in the property store
                if (this.SetValue<BorderStyle>(Control.BorderStyleProperty, value, this.DefaultBorderStyle))
                {
                    // Update the control
                    this.Update();

                    // Fire for border style changed
                    FireObservableItemPropertyChanged("BorderStyle");
                }
            }
        }

        /// <summary>
        /// Gets or sets the thickness of the border.
        /// </summary>
        /// <value>Gets or sets a border thickness.</value>
        /// <remarks>The thinkness struct can be automaticly casted to and from int for backwords compatibility.</remarks>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderWidthDescr"), ProxyBrowsable(true)]
        public virtual BorderWidth BorderWidth
        {
            get
            {
                // Return border width
                return this.GetValue<BorderWidth>(Control.BorderWidthProperty, this.DefaultBorderWidth);
            }
            set
            {
                // Set the border width and if value updated update the control
                if (this.SetValue<BorderWidth>(Control.BorderWidthProperty, value, this.DefaultBorderWidth))
                {
                    // Update the control
                    this.Update();

                    // Fire for border width changed
                    this.FireObservableItemPropertyChanged("BorderWidth");
                }
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>
        /// The theme related to the skinable component.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [WebEditor(typeof(WebThemeEditor), typeof(WebUITypeEditor)), SRCategory("CatAppearance")]
        [SRDescription("ControlThemeDescr"), DefaultValue("Inherit"), ProxyBrowsable(true)]
        public virtual string Theme
        {
            get
            {
                return this.GetValue<string>(Control.ThemeProperty);
            }
            set
            {
                ICollection<string> objAvailableThemes = null;
                if (VWGContext.Current == null)
                {
                    objAvailableThemes = Config.GetInstance().AvailableThemes;
                }
                else                    
                {
                    objAvailableThemes = VWGContext.Current.AvailableThemes;
                }
                if (value == "Inherit" || objAvailableThemes.Contains(value))
                {
                    if (this.SetValue<string>(Control.ThemeProperty, value))
                    {
                        // Update the control
                        this.UpdateParams(AttributeType.Layout);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance"), SRDescription("ControlBackColorDescr"), ProxyBrowsable(true)]
        public virtual Color BackColor
        {
            get
            {
                return this.GetValue<Color>(Control.BackColorProperty, this.DefaultBackColor);

            }
            set
            {
                // Set the back color property and update / raise events if value had changed
                if (this.SetValue<Color>(Control.BackColorProperty, value))
                {
                    // Fire changed in observer
                    FireObservableItemPropertyChanged("BackColor");

                    // Update control
                    this.Update();

                    // Raise the BackgroundImageChanged event.
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has back color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has back color; otherwise, <c>false</c>.
        /// </value>
        internal bool HasBackColor
        {
            get
            {
                return this.ContainsValue<object>(Control.BackColorProperty);
            }
        }

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderColorDescr"), ProxyBrowsable(true)]
        public virtual BorderColor BorderColor
        {
            get
            {
                return this.GetValue<BorderColor>(Control.BorderColorProperty, this.DefaultBorderColor);

            }
            set
            {
                // Set border color and if value changed update control and raise events             
                if (this.SetValue<BorderColor>(Control.BorderColorProperty, value, this.DefaultBorderColor))
                {

                    // Fire changed in observer
                    FireObservableItemPropertyChanged("BorderColor");

                    // Update control
                    this.Update();
                }
            }
        }



        /// <summary>
        /// Gets or sets the fore color.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance"), SRDescription("ControlForeColorDescr"), ProxyBrowsable(true)]
        public virtual Color ForeColor
        {
            get
            {
                // Return backcolor
                return this.GetValue<Color>(Control.ForeColorProperty, this.DefaultForeColor);
            }
            set
            {
                // Set the fore color and update the control if diffrent
                if (this.SetValue<Color>(Control.ForeColorProperty, value))
                {
                    // Update the control
                    this.Update();

                    // Notify fore color changed
                    OnForeColorChanged(new EventArgs());

                    // Fire for color changed
                    FireObservableItemPropertyChanged("ForeColor");
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance has fore color.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has fore color; otherwise, <c>false</c>.
        /// </value>
        internal bool HasForeColor
        {
            get
            {
                return this.ContainsValue<object>(Control.ForeColorProperty);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has right to left.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has right to left; otherwise, <c>false</c>.
        /// </value>
        internal bool HasRightToLeft
        {
            get
            {
                return this.ContainsValue<object>(Control.RightToLeftProperty);
            }
        }

        #endregion

        #region Error Provider Methods

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns></returns>
        internal string GetErrorMessage()
        {
            return this.ErrorMessage;
        }

        /// <summary>
        /// Gets the icon alignment.
        /// </summary>
        /// <returns></returns>
        internal ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return GetValue<ErrorIconAlignment>(Control.ErrorIconAlignmentProperty);
            }
            set
            {
                // If the value is diffrent from wat is currently set
                if (this.SetValue<ErrorIconAlignment>(Control.ErrorIconAlignmentProperty, value))
                {

                    // Update the control to reflect changes
                    this.UpdateParams(AttributeType.Error);
                }
            }
        }



        /// <summary>
        /// Gets or sets the error icon padding.
        /// </summary>
        /// <value>The error icon padding.</value>
        internal int ErrorIconPadding
        {
            get
            {
                return GetValue<int>(Control.ErrorIconPaddingProperty);
            }
            set
            {
                // If value is diffrent than the current error icon padding
                if (this.SetValue<int>(Control.ErrorIconPaddingProperty, value))
                {
                    // Update control to reflect changes
                    UpdateParams(AttributeType.Error);
                }

            }
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="strValue">value.</param>
        /// <param name="objErrorIcon">The obj error icon.</param>
        internal void SetErrorMessage(string strValue, ResourceHandle objErrorIcon)
        {
            // Get the current error icon
            ResourceHandle objCurrentErrorIcon = this.ErrorIcon;

            // Get the current error message
            string strCurrentErrorMessage = this.ErrorMessage;

            // If either error icon has changed or error message we need to update the control
            if (objCurrentErrorIcon != objErrorIcon || strCurrentErrorMessage != strValue)
            {
                // Set the new error icon and message
                this.ErrorIcon = objErrorIcon;
                this.ErrorMessage = strValue;

                // Update the control to reflect changes
                UpdateParams(AttributeType.Error);
            }
        }

        /// <summary>
        /// Gets or sets the error icon.
        /// </summary>
        /// <value>The error icon.</value>
        private ResourceHandle ErrorIcon
        {
            get
            {
                // Get the error icon from the property store
                return GetValue<ResourceHandle>(Control.ErrorIconProperty);
            }
            set
            {
                // Set the new resource handler error icon
                this.SetValue<ResourceHandle>(Control.ErrorIconProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        private string ErrorMessage
        {
            get
            {
                return this.GetValue<string>(Control.ErrorMessageProperty);
            }
            set
            {
                this.SetValue<string>(Control.ErrorMessageProperty, value);
            }
        }

        /// <summary>
        /// Sets the icon alignment.
        /// </summary>
        /// <param name="enmValue">value.</param>
        internal void SetErrorIconAlignment(ErrorIconAlignment enmValue)
        {


        }

        /// <summary>
        /// Raises the <see cref="E:ResizeInternal"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        internal void OnResizeInternal(LayoutEventArgs objEventArgs)
        {
            // Check whether parent should be invalidated.
            if (objEventArgs.ShouldUpdateParent)
            {
                // Invalidate parent's layout.
                this.InvalidateParentLayout(objEventArgs);
            }

            // Call the layouting process 
            OnLayoutInternal(objEventArgs);
        }

        /// <summary>
        /// Check if design time layouting is allowed.
        /// </summary>
        /// <returns></returns>
        private bool AllowDesignTimeLayouting()
        {
            bool blnAllowDesignTimeLayouting = false;

            // Try getting a designer host.
            IDesignerHost objDesignerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (objDesignerHost != null)
            {
                // In case that designer is in loading, allow performing design time layouting.
                blnAllowDesignTimeLayouting = objDesignerHost.Loading;
            }

            return blnAllowDesignTimeLayouting;
        }

        /// <summary>
        /// Raises the <see cref="E:Layout"/> event.
        /// </summary>
        /// <param name="levent">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        protected virtual void OnLayout(LayoutEventArgs objEventArgs)
        {

        }

        /// <summary>
        /// Raises the <see cref="E:LayoutInternal"/> event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        internal void OnLayoutInternal(LayoutEventArgs objEventArgs)
        {
            // Check if in run time or if design time layouting is allowed.
            if (!this.DesignMode || this.AllowDesignTimeLayouting())
            {
                // Check if layout is not suspended.
                if (!this.IsLayoutSuspended)
                {
                    // Get the display size
                    Size objDisplaySize = this.Size;

                    // Get the control height
                    int intDisplayHeight = objDisplaySize.Height;

                    // Get the control width
                    int intDisplayWidth = objDisplaySize.Width;


                    // If size had changed
                    if (mintLayoutHeight != intDisplayHeight || mintLayoutWidth != intDisplayWidth)
                    {
                        if (this.WinFormsCompatibility.IsRecursiveResizeEvent || !this.IsNonCompatibleModeLayoutSuspended)
                        {
                            // Do layout
                            this.OnLayoutInternal(objEventArgs, new Size(intDisplayWidth, intDisplayHeight), new Size(mintLayoutWidth, mintLayoutHeight));
                        }

                        // Update the layout size
                        mintLayoutHeight = intDisplayHeight;
                        mintLayoutWidth = intDisplayWidth;

                        this.OnLayout(objEventArgs);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the opposite dock style.
        /// </summary>
        /// <param name="enmDockStyle">The enm dock style.</param>
        /// <returns></returns>
        private DockStyle GetOppositeDockStyle(DockStyle enmDockStyle)
        {
            switch (enmDockStyle)
            {
                case DockStyle.Top:
                    return DockStyle.Bottom;
                case DockStyle.Bottom:
                    return DockStyle.Top;
                case DockStyle.Right:
                    return DockStyle.Left;
                case DockStyle.Left:
                    return DockStyle.Right;
                default:
                    return DockStyle.None;
            }
        }


        /// <summary>
        /// Called when child had been resized.
        /// </summary>
        /// <param name="objControl">The resized control.</param>
        /// <param name="objNewSize">The control new size.</param>
        /// <param name="objOldSize">The control old size.</param>
        private void OnDockedChildResizeInternal(LayoutEventArgs objEventArgs, Control objControl, Size objNewSize, Size objOldSize)
        {
            // Get control docking
            DockStyle enmControlDock = objControl.Dock;

            // If control is effecting sibling controls
            if (enmControlDock != DockStyle.None)
            {
                // Get parent controls
                ControlCollection objParentControls = this.Controls;

                // If there is more then one control 
                if (objParentControls.Count > 1)
                {
                    // Get the current control index
                    int intControlIndex = objParentControls.IndexOf(objControl);

                    // If the splitter has an effected control
                    if (intControlIndex > 0)
                    {
                        // Get the effected docking style
                        DockStyle enmControlOppositeDockStyle = GetOppositeDockStyle(enmControlDock);

                        // Loop all next sibling control 
                        for (int intIndex = intControlIndex - 1; intIndex >= 0; intIndex--)
                        {
                            // Get current sibling
                            Control objSiblingControl = objParentControls[intIndex];

                            // If control is docked
                            if (objSiblingControl.Dock != DockStyle.None)
                            {
                                // If the sibling docking is the oposite docking
                                if (objSiblingControl.Dock != enmControlOppositeDockStyle)
                                {
                                    // Raise the location changed event
                                    objSiblingControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));

                                    // If not the same docking
                                    if (objSiblingControl.Dock != enmControlDock)
                                    {
                                        objSiblingControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }



        /// <summary>
        /// Provides controls with the ability to handle size changed
        /// </summary>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        /// <param name="objNewSize">The control new size.</param>
        /// <param name="objOldSize">The control old size.</param>
        internal virtual void OnLayoutInternal(LayoutEventArgs objEventArgs, Size objNewSize, Size objOldSize)
        {
            // Get docking style.
            DockStyle enmDock = this.GetDockInternal();

            // If this control has docking
            if (enmDock != DockStyle.None)
            {
                // If update sibling is required
                if (objEventArgs.ShouldUpdateSiblings)
                {
                    // Try to get parent control
                    Control objParent = this.Parent;
                    if (objParent != null)
                    {
                        // Let the parent handle the child resizing
                        objParent.OnDockedChildResizeInternal(objEventArgs, this, objNewSize, objOldSize);
                    }
                }
            }

            // Layout the control controls
            OnLayoutControls(objEventArgs, ref objNewSize, ref objOldSize);
        }

        /// <summary>
        /// Layout the internal controls to reflect parent changes
        /// </summary>
        /// <param name="objEventArgs">The layout arguments.</param>
        /// <param name="objNewSize">The new parent size.</param>
        /// <param name="objOldSize">The old parent size.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
        {
            // If there is a valid control collection
            if (mobjControls != null)
            {
                // If there are controls
                if (mobjControls.Count > 0)
                {
                    // Get width change
                    int intWidthChange = objNewSize.Width - objOldSize.Width;

                    // Get height change
                    int intHeightChange = objNewSize.Height - objOldSize.Height;

                    // Loop all child controls
                    foreach (Control objControl in mobjControls)
                    {
                        // Get the current control docking
                        DockStyle enmControlDock = objControl.Dock;

                        // If vertical docking
                        if (enmControlDock == DockStyle.Left || enmControlDock == DockStyle.Right)
                        {
                            // If control is docked to the right and parent width has changed
                            if (enmControlDock == DockStyle.Right)
                            {
                                if (intWidthChange != 0)
                                {
                                    objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                    objControl.OnLocationChanged(objEventArgs.Clone(false, false));
                                }
                            }

                            // If height had changed
                            if (intHeightChange != 0)
                            {
                                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                objControl.OnSizeChanged(EventArgs.Empty);
                            }
                        }
                        // If horizantal docking
                        else if (enmControlDock == DockStyle.Top || enmControlDock == DockStyle.Bottom)
                        {
                            // If control is docked to the right and parent height has changed
                            if (enmControlDock == DockStyle.Bottom)
                            {
                                if (intHeightChange != 0)
                                {
                                    objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                    objControl.OnLocationChanged(objEventArgs.Clone(false, false));
                                }
                            }

                            // If width had changed
                            if (intWidthChange != 0)
                            {
                                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                objControl.OnSizeChanged(EventArgs.Empty);
                            }
                        }
                        // If fill docking
                        else if (enmControlDock == DockStyle.Fill)
                        {
                            // If parent size had changed
                            if (intWidthChange != 0 || intHeightChange != 0)
                            {
                                objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                objControl.OnSizeChanged(EventArgs.Empty);
                            }
                        }
                        else
                        {
                            // Get control location and size
                            int intControlLeft = objControl.Left;
                            int intControlTop = objControl.Top;
                            int intControlHeight = objControl.Height;
                            int intControlWidth = objControl.Width;

                            // Get control's anchor value.
                            AnchorStyles enmAnchor = objControl.Anchor;

                            // Get control anchoring flags
                            bool blnIsRightAnchored = objControl.IsRightAnchored(enmAnchor);
                            bool blnIsLeftAnchored = objControl.IsLeftAnchored(enmAnchor);
                            bool blnIsTopAnchored = objControl.IsTopAnchored(enmAnchor);
                            bool blnIsBottomAnchored = objControl.IsBottomAnchored(enmAnchor);

                            // Dirty flags
                            bool blnSizeChanged = false;
                            bool blnLocationChanged = false;

                            // If width had changed
                            if (intWidthChange != 0)
                            {
                                // If right anchored
                                if (blnIsRightAnchored && !blnIsLeftAnchored)
                                {
                                    intControlLeft += intWidthChange;
                                    blnLocationChanged = true;
                                }
                                // If both right and left anchoring
                                else if (blnIsRightAnchored && blnIsLeftAnchored)
                                {
                                    intControlWidth += intWidthChange;
                                    blnSizeChanged = true;
                                }
                                // If center anchoring
                                else if (!blnIsRightAnchored && !blnIsLeftAnchored)
                                {
                                    intControlLeft += (intWidthChange / 2);
                                    blnLocationChanged = true;
                                }
                            }

                            // If height had changed
                            if (intHeightChange != 0)
                            {
                                // If bottom anchored
                                if (blnIsBottomAnchored && !blnIsTopAnchored)
                                {
                                    intControlTop += intHeightChange;
                                    blnLocationChanged = true;
                                }
                                // If both bottom and top anchoring
                                else if (blnIsBottomAnchored && blnIsTopAnchored)
                                {
                                    intControlHeight += intHeightChange;
                                    blnSizeChanged = true;
                                }
                                // If center anchoring
                                else if (!blnIsBottomAnchored && !blnIsTopAnchored)
                                {
                                    intControlTop += (intHeightChange / 2);
                                    blnLocationChanged = true;
                                }
                            }

                            // If control had changed
                            if (blnLocationChanged || blnSizeChanged)
                            {
                                // Update the control bounds
                                objControl.UpdateBounds(intControlLeft, intControlTop, intControlWidth, intControlHeight, intControlWidth, intControlHeight, objEventArgs.IsClientSource);

                                // If the location had changed
                                if (blnLocationChanged)
                                {
                                    // Raise the location changed event
                                    objControl.OnLocationChangedInternal(objEventArgs.Clone(false, false));
                                }

                                // If the size had changed
                                if (blnSizeChanged)
                                {
                                    // Raise the size changed event
                                    objControl.OnResizeInternal(objEventArgs.Clone(false, false));
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnResize(EventArgs e)
        {
            EventHandler objEventHandler = this.ResizeHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, EventArgs.Empty);
            }
        }


        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnSizeChanged(EventArgs e)
        {
            OnResize(e);

            EventHandler objEventHandler = this.SizeChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

        }

        #endregion

        #endregion

        #region Layout Methods

        /// <summary>
        /// Suspends the layout.
        /// </summary>
        public void SuspendLayout()
        {
            mintSuspendLayout += 1;

            if (mintSuspendLayout == 1)
            {
                EventHandler objHandler = this.ObservableSuspendLayoutHandler;
                if (objHandler != null)
                {
                    objHandler(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Terminates registered timers.
        /// </summary>
        internal void TerminateRegisteredTimers()
        {
            // Get local registered timers.
            Timer[] objRegisteredTimers = this.RegisteredTimers;
            if (objRegisteredTimers != null)
            {
                // Loop all timers.
                foreach (Timer objTimer in objRegisteredTimers)
                {
                    // Disable current timer.
                    objTimer.Enabled = false;
                }
            }

            // Get local controls collection.
            ControlCollection arrControls = this.Controls;
            if (arrControls.Count > 0)
            {
                // Loop all contained controls.
                foreach (Control objControl in arrControls)
                {
                    // Terminate registered timers.
                    objControl.TerminateRegisteredTimers();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is layout suspended non compatible mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is layout suspended non compatible mode; otherwise, <c>false</c>.
        /// </value>
        internal bool IsNonCompatibleModeLayoutSuspended
        {
            get
            {
                // If not current control suspended
                if (mintSuspendLayout <= 0)
                {
                    // If is a control and not a UserControl or Form
                    if (!(this is UserControl || this is Form))
                    {
                        // Get the control parent
                        Control objControl = this.Parent;

                        // If there is no valid parent
                        if (objControl == null)
                        {
                            // Control is layout suspended until attached to a parent which is not suspended
                            return true;
                        }
                        else
                        {
                            // Get the suspened state of the parent
                            return objControl.IsNonCompatibleModeLayoutSuspended;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is layout suspended.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is layout suspended; otherwise, <c>false</c>.
        /// </value>
        protected bool IsLayoutSuspended
        {
            get
            {
                return mintSuspendLayout > 0;
            }
        }

        /// <summary>
        /// Resumes the layout.
        /// </summary>
        public void ResumeLayout()
        {
            this.ResumeLayout(true);
        }

        /// <summary>
        /// Resumes the layout.
        /// </summary>
        public void ResumeLayout(LayoutEventArgs objEventArgs)
        {
            this.ResumeLayout(objEventArgs, true);
        }

        /// <summary>
        /// Resumes the layout.
        /// </summary>
        /// <param name="blnPerformLayout">if set to <c>true</c> [BLN perform layout].</param>
        public void ResumeLayout(bool blnPerformLayout)
        {
            this.ResumeLayout(new LayoutEventArgs(false, false, true), blnPerformLayout);
        }

        /// <summary>
        /// Resumes the layout.
        /// </summary>
        /// <param name="blnPerformLayout">if set to <c>true</c> [BLN perform layout].</param>
        public void ResumeLayout(LayoutEventArgs objEventArgs, bool blnPerformLayout)
        {
            if (mintSuspendLayout > 0)
            {
                mintSuspendLayout -= 1;

                if (mintSuspendLayout == 0)
                {
                    // Check if perform layout is needed.
                    if (blnPerformLayout)
                    {
                        // Flag that current control is dirty.
                        this.SetState(ControlState.LayoutIsDirty, true);

                        // Perform layout.
                        this.PerformLayout(objEventArgs);
                    }
                    else
                    {
                        // Get the display size
                        Size objDisplaySize = this.Size;

                        // Get the control height
                        mintLayoutHeight = objDisplaySize.Height;

                        // Get the control width
                        mintLayoutWidth = objDisplaySize.Width;
                    }

                    // Perform an observable resume layout. 
                    ObservableResumeLayoutHandler objHandler = this.ObservableResumeLayoutHandler;
                    if (objHandler != null)
                    {
                        objHandler(this, new ObservableResumeLayoutArgs(blnPerformLayout));
                    }
                }
            }
        }

        /// <summary>
        /// Invalidates the layout.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal void InvalidateLayout(LayoutEventArgs objEventArgs)
        {
            // Check if current control requires layout and that this code is not running in design mode.
            if (!this.DesignMode && this.RequiresLayout)
            {
                // Flag that layout is dirty.
                this.SetState(ControlState.LayoutIsDirty, true);

                // Check if this control is a top level control.
                if (this.GetTopLevel())
                {
                    // Perform layout.
                    this.PerformLayout(objEventArgs);
                }
                else
                {
                    // Try getting a parent.
                    Control objParent = this.ParentInternal;
                    if (objParent != null)
                    {
                        // check whether parent requires layout.
                        if (objParent.RequiresLayout)
                        {
                            // Get parent's current preferred size.
                            Size objParentPreferredSize = objParent.PreferredSize;

                            // Invalidate parent's layout.
                            objParent.InvalidateLayout(objEventArgs);

                            // Check if parent's preferred size has changed.
                            if (objParentPreferredSize != objParent.PreferredSize)
                            {
                                if (!objEventArgs.IsClientSource)
                                {
                                    // Redraw parent.
                                    objParent.UpdateParams(AttributeType.Layout);
                                }
                            }
                        }
                        else
                        {
                            // Flag that parent's layout is dirty.
                            objParent.SetState(ControlState.LayoutIsDirty, true);

                            // Perform layout on parent.
                            objParent.PerformLayout(objEventArgs);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Invalidates the parent layout.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void InvalidateParentLayout(LayoutEventArgs objEventArgs)
        {
            // Try getting a parent.
            Control objParent = this.ParentInternal;
            if (objParent != null)
            {
                // Invalidate parent's layout.
                objParent.InvalidateLayout(objEventArgs);
            }
        }

        /// <summary>
        /// WinForm complaint - No use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void PerformLayout()
        {
            this.PerformLayout(false);
        }

        /// <summary>
        /// WinForm complaint - No use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void PerformLayout(LayoutEventArgs objEventArgs)
        {
            this.PerformLayout(false, objEventArgs);
        }

        /// <summary>
        /// Performs the layout.
        /// </summary>
        /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
        protected internal virtual void PerformLayout(bool blnForceLayout)
        {
            this.PerformLayout(blnForceLayout, new LayoutEventArgs(false, false, true));
        }

        /// <summary>
        /// Performs the layout.
        /// </summary>
        /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        private void PerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
        {
            // Check that control is created and that its layout is not suspended.
            if (!this.IsLayoutSuspended && this.Created)
            {
                // Loop all child controls.
                foreach (Control objChildControl in this.Controls)
                {
                    // Check if child control layout's is dirty.
                    if (blnForceLayout || objChildControl.GetState(ControlState.LayoutIsDirty))
                    {
                        // Perform child layout.
                        objChildControl.PerformLayout(blnForceLayout, objEventArgs);
                    }
                }

                // Perform layout.
                this.DoPerformLayout(blnForceLayout, objEventArgs);
            }
        }

        /// <summary>
        /// Does the perform layout.
        /// </summary>
        /// <param name="blnForceLayout">if set to <c>true</c> [BLN force layout].</param>
        /// <param name="objEventArgs">The <see cref="Gizmox.WebGUI.Forms.LayoutEventArgs"/> instance containing the event data.</param>
        private void DoPerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
        {
            // Check if current control is in auto size mode, has dirty layout (or if layout is forced) 
            // and that its layout is not suspended.
            if (!this.IsLayoutSuspended && this.RequiresLayout &&
                (blnForceLayout || this.GetState(ControlState.LayoutIsDirty)))
            {
                // Create a proposed size based on layout size.
                Size objProposedSize = new Size(this.mintWidth, this.mintHeight);

                // If auto size mode supports shrinking
                if (this.AutoSizeMode == AutoSizeMode.GrowAndShrink)
                {
                    if (this.MinimumSize.Height > objProposedSize.Height)
                    {
                        objProposedSize.Height = this.MinimumSize.Height;
                    }

                    if (this.MinimumSize.Width > objProposedSize.Width)
                    {
                        objProposedSize.Width = this.MinimumSize.Width;
                    }
                }
                else if (objProposedSize == Size.Empty)
                {
                    objProposedSize = this.DefaultSize;
                }

                // Set the client minimum size
                this.SetMinimumClientSize(objProposedSize);

                // Flag that layout is not dirty.
                this.SetState(ControlState.LayoutIsDirty, false);

                // Get the prefered size
                Size objPreferredSize = GetPreferredSize(objProposedSize);

                objPreferredSize = GetPreferredSizeByAutoSizeMode(this, objProposedSize, objPreferredSize);

                // Set the new preferred size
                if (this.SetPreferredSize(objPreferredSize))
                {
                    // Check that current layout performance is not caused by a client source.
                    if (!objEventArgs.IsClientSource)
                    {
                        // Flag to render layout attributes.
                        this.UpdateParams(AttributeType.Layout);
                    }

                    // If we are in auto size mode
                    if (this.AutoSize)
                    {
                        // Raise the resize event
                        OnSizeChanged(objEventArgs);
                    }

                    // Call the layouting process 
                    OnLayoutInternal(objEventArgs);
                }
            }
        }

        /// <summary>
        /// Sets the minimum size of the client.
        /// </summary>
        /// <param name="objProposedSize">Proposed size.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void SetMinimumClientSize(Size objProposedSize)
        {
        }

        /// <summary>
        /// Sets the size of the preferred.
        /// </summary>
        /// <param name="objPreferredSize">Size of the obj preferred.</param>
        /// <returns>Returns a flag if control should raise the resize event or do layout.</returns>
        [Browsable(false)]
        protected virtual bool SetPreferredSize(Size objPreferredSize)
        {
            // If preferred size was not set
            if (mintPreferredHeight == -1 || mintPreferredWidth == -1)
            {
                // Set the preferred size
                mintPreferredWidth = objPreferredSize.Width;
                mintPreferredHeight = objPreferredSize.Height;

                // Return layout / resize not needed
                return false;
            }
            else
            {
                // If preferred size had changed
                if (mintPreferredHeight != objPreferredSize.Height || mintPreferredWidth != objPreferredSize.Width)
                {
                    // Set the new preferred size
                    mintPreferredWidth = objPreferredSize.Width;
                    mintPreferredHeight = objPreferredSize.Height;

                    // Return layout / resize needed
                    return true;
                }
                else
                {
                    // Return layout / resize not needed
                    return false;
                }
            }
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="objMethod">method.</param>
        /// <returns></returns>
        public object Invoke(Delegate objMethod)
        {
            return Invoke(objMethod, null);
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="objMethod">method.</param>
        /// <param name="objArgs">Arguments.</param>
        /// <returns></returns>
        public object Invoke(Delegate objMethod, object[] arrArgs)
        {
            if (objMethod != null)
            {
                return objMethod.DynamicInvoke(arrArgs);
            }
            else
            {
                return null;
            }
        }



        #endregion

        #region Should Serialze Methods

        /// <summary>
        /// Shoulds the index of the serialize tab.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeTabIndex()
        {
            return mintTabIndex != -1;
        }

        /// <summary>
        /// Shoulds the color of the serialize back.
        /// </summary>
        /// <returns></returns>
        internal virtual bool ShouldSerializeBackColor()
        {
            return this.ContainsValue<Color>(Control.BackColorProperty);
        }

        /// <summary>
        /// Shoulds the color of the serialize fore.
        /// </summary>
        /// <returns></returns>
        internal virtual bool ShouldSerializeForeColor()
        {
            return this.ContainsValue<Color>(Control.ForeColorProperty);
        }

        /// <summary>
        /// Get a flag indicating if should serialize the font.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeFont()
        {
            return this.ContainsValue<Font>(Control.FontProperty);
        }

        /// <summary>
        /// Shoulds the color of the serialize border.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderColor()
        {
            return this.DefaultBorderColor != this.BorderColor;
        }

        /// <summary>
        /// Shoulds the serialize border style.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderStyle()
        {
            return this.BorderStyle != this.DefaultBorderStyle;
        }

        /// <summary>
        /// Shoulds the width of the serialize border.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeBorderWidth()
        {
            return this.DefaultBorderWidth != this.BorderWidth;
        }

        /// <summary>
        /// Shoulds the color of the serialize border.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeBorderColor(BorderColor objBorderColor)
        {
            return this.DefaultBorderColor != objBorderColor;
        }

        /// <summary>
        /// Shoulds the serialize border style.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeBorderStyle(BorderStyle objBordeStyle)
        {
            return objBordeStyle != this.DefaultBorderStyle;
        }


        private bool ShouldSerializeAnchor()
        {
            return (int)this.Anchor != 5;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeMaximumSize()
        {
            return this.DefaultMaximumSize != this.MaximumSize;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeMinimumSize()
        {
            return this.DefaultMinimumSize != this.MinimumSize;
        }
        private bool ShouldSerializeDock()
        {
            return this.Dock != DockStyle.None;
        }

        /// <summary>
        /// Shoulds the render border.
        /// </summary>
        /// <param name="objBorderValue">The obj border value.</param>
        /// <returns></returns>
        private bool ShouldRenderBorder(BorderValue objBorderValue)
        {
            bool blnRenderBorder = false;

            blnRenderBorder = blnRenderBorder || ShouldSerializeBorderColor(objBorderValue.Color);
            blnRenderBorder = blnRenderBorder || ShouldSerializeBorderStyle(objBorderValue.Style);
            blnRenderBorder = blnRenderBorder || ShouldSerializeBorderWidth(objBorderValue.Width);

            return blnRenderBorder;
        }

        /// <summary>
        /// Shoulds the width of the serialize border.
        /// </summary>
        /// <param name="objBorderWidth">Width of the obj border.</param>
        /// <returns></returns>
        private bool ShouldSerializeBorderWidth(BorderWidth objBorderWidth)
        {
            return this.DefaultBorderWidth != objBorderWidth;
        }

        /// <summary>
        /// Gets the default width of the border.
        /// </summary>
        /// <value>The default width of the border.</value>
        protected virtual BorderWidth DefaultBorderWidth
        {
            get
            {
                return this.Skin.BorderWidth;
            }
        }

        /// <summary>
        /// Shoulds the serialize text.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeText()
        {
            return !string.IsNullOrEmpty(this.Text);
        }

        /// <summary>
        /// Shoulds the size of the serialize.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeSize()
        {
            return true;
        }

        /// <summary>
        /// Shoulds the size of the serialize client.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializeClientSize()
        {
            return true;
        }

        /// <summary>
        /// Shoulds the serialize right to left.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeRightToLeft()
        {
            return this.HasRightToLeft;
        }

        /// <summary>
        /// Resets the right to left.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetRightToLeft()
        {
            this.RightToLeft = RightToLeft.Inherit;
        }

        #endregion

        #region Default Member Values

        /// <summary>
        /// Gets a value indicating whether this instance is delayed drawing.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is delayed drawing; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool IsDelayedDrawing
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [auto drawn].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [auto drawn]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AutoDrawn
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support child margins].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool SupportChildMargins
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets a value indicating whether [force child redraw].
        /// </summary>
        /// <value><c>true</c> if [force child redraw]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool ForceChildRedraw
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is redrawing its contained controls.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is redrawing; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool Redraws
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected virtual Size DefaultSize
        {
            get
            {
                return new Size(100, 100);
            }
        }

        /// <summary>
        /// Gets the default color of the back.
        /// </summary>
        /// <value>The default color of the back.</value>
        protected Color DefaultBackColor
        {
            get
            {
                return this.Skin.BackColor;
            }
        }

        /// <summary>
        /// Gets the default color of the fore.
        /// </summary>
        /// <value>The default color of the fore.</value>
        protected Color DefaultForeColor
        {
            get
            {
                return this.Skin.ForeColor;
            }
        }

        /// <summary>
        /// Gets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        protected BorderColor DefaultBorderColor
        {
            get
            {
                return this.Skin.BorderColor;
            }
        }

        /// <summary>
        /// Gets the default border style.
        /// </summary>
        /// <value>The default border style.</value>
        protected BorderStyle DefaultBorderStyle
        {
            get
            {
                return this.Skin.BorderStyle;
            }
        }

        /// <summary>
        /// Gets the default padding.
        /// </summary>
        /// <value>The default padding.</value>
        protected virtual Padding DefaultPadding
        {
            get
            {
                return this.Skin.Padding;
            }
        }

        /// <summary>
        /// Gets the default margin.
        /// </summary>
        /// <value>The default margin.</value>
        protected Padding DefaultMargin
        {
            get
            {
                return this.Skin.Margin;
            }
        }

        /// <summary>
        /// Gets the default font.
        /// </summary>
        /// <value>The default font.</value>
        protected Font DefaultControlFont
        {
            get
            {
                return this.Skin.Font;
            }
        }


        #endregion

        #region Binding Related

        #region Methods

        #region Protected Methods


        /// <summary>
        /// Adds a child object.
        /// </summary>
        /// <param name="objValue">The child object to add.</param>
        protected override void AddChild(object objValue)
        {
            // If the value to add is a control add it to the controls collection
            if (objValue is Control)
            {
                // Add the control and bring it to the front
                Control objControl = (Control)objValue;
                this.Controls.Add(objControl);
                objControl.BringToFront();
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        /// <summary>
        /// Checks circular control reference.
        /// </summary>
        /// <param name="objBottom">The obj bottom.</param>
        /// <param name="objToFind">The obj to find.</param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        internal static void CheckParentingCycle(Control objBottom, Control objToFind)
        {
            Form objForm = null;
            Control objControl = null;

            // climbe all bottom dynasty and check that objToFind is not his ancestor
            for (Control objAncestor = objBottom; objAncestor != null; objAncestor = objAncestor.ParentInternal)
            {
                objControl = objAncestor;
                if (objAncestor == objToFind)
                {
                    throw new ArgumentException(SR.GetString("CircularOwner"));
                }
            }
            if ((objControl != null) && (objControl is Form))
            {
                Form objBottomsForm = (Form)objControl;
                for (Form objFormAncestor = objBottomsForm; objFormAncestor != null; objFormAncestor = objFormAncestor.OwnerInternal)
                {
                    objForm = objFormAncestor;
                    if (objFormAncestor == objToFind)
                    {
                        throw new ArgumentException(SR.GetString("CircularOwner"));
                    }
                }
            }
            if ((objForm != null) && (objForm.ParentInternal != null))
            {
                CheckParentingCycle(objForm.ParentInternal, objToFind);
            }
        }

        /// <summary>
        /// Assigns the parent.
        /// </summary>
        /// <param name="objParent">The obj parent of type Control.</param>
        internal virtual void AssignParent(Control objParent)
        {
            if (this.CanAccessProperties)
            {
                Control objOldParent = this.InternalParent as Control;

                bool blnVisiblityChanged = ((this.InternalParent == null && objParent != null) || (this.InternalParent != null && objParent == null));

                // Assign the parent so all following logic will have the updated parent.
                this.InternalParent = objParent;

                // Notify parent has changed
                this.OnParentChanged(EventArgs.Empty);

                // Checks whether is resized due to parent assignment.
                if (this.IsResizedDueToParentAssignment(objOldParent, objParent))
                {
                    this.OnResizeInternal(new LayoutEventArgs(false, false, false));
                }

                // If the current binding context is null
                if (this.GetValue<BindingContext>(Control.BindingContextProperty) == null)
                {
                    this.OnBindingContextChanged(EventArgs.Empty);
                }

                if (blnVisiblityChanged)
                {
                    OnVisibleChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Determines whether is resized due to parent assignment.
        /// </summary>
        /// <param name="objOldParent">The obj old parent.</param>
        /// <param name="objNewParent">The obj new parent.</param>
        /// <returns>
        ///   <c>true</c> if [is resized due to parent assignment] [the specified obj old parent]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsResizedDueToParentAssignment(Control objOldParent, Control objNewParent)
        {
            bool blnIsResizedDueToParentAssignment = false;

            if (objNewParent != null)
            {
                // Check whether the new parent really has different dimentions
                bool blnHorizontalSizeChange = objOldParent == null || objOldParent.Width != objNewParent.Width;
                bool blnVerticalSizeChange = objOldParent == null || objOldParent.Height != objNewParent.Height;

                // The acnchoring and docking styles ofthe control determine the control's size inside their parent
                AnchorStyles enmChildAnchor = this.Anchor;
                DockStyle enmChildDock = this.Dock;

                blnIsResizedDueToParentAssignment = (enmChildDock == DockStyle.Fill && (blnHorizontalSizeChange || blnVerticalSizeChange)) ||
                                                    (blnHorizontalSizeChange && ((this.IsRightAnchored(enmChildAnchor) && this.IsLeftAnchored(enmChildAnchor)) || enmChildDock == DockStyle.Top || enmChildDock == DockStyle.Bottom)) ||
                                                    (blnVerticalSizeChange && ((this.IsTopAnchored(enmChildAnchor) && this.IsBottomAnchored(enmChildAnchor)) || enmChildDock == DockStyle.Left || enmChildDock == DockStyle.Right));
            }

            return blnIsResizedDueToParentAssignment;
        }

        /// <summary>
        /// Gets the first child control in tab order.
        /// </summary>
        /// <param name="blnForward">if set to <c>true</c> [BLN forward].</param>
        /// <returns></returns>
        internal virtual Control GetFirstChildControlInTabOrder(bool blnForward)
        {
            Control.ControlCollection objCollection1 = (Control.ControlCollection)this.Controls;
            Control objControl1 = null;
            if (objCollection1 != null)
            {
                if (blnForward)
                {
                    for (int num1 = 0; num1 < objCollection1.Count; num1++)
                    {
                        if ((objControl1 == null) || (objControl1.TabIndex > objCollection1[num1].TabIndex))
                        {
                            objControl1 = objCollection1[num1];
                        }
                    }
                    return objControl1;
                }
                for (int num2 = objCollection1.Count - 1; num2 >= 0; num2--)
                {
                    if ((objControl1 == null) || (objControl1.TabIndex < objCollection1[num2].TabIndex))
                    {
                        objControl1 = objCollection1[num2];
                    }
                }
            }
            return objControl1;
        }

        /// <summary>Retrieves the next control forward or back in the tab order of child controls.</summary>
        /// <returns>The next <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the tab order.</returns>
        /// <param name="blnForward">true to search forward in the tab order; false to search backward. </param>
        /// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to start the search with. </param>
        /// <filterpriority>2</filterpriority>
        public Control GetNextControl(Control objControl, bool blnForward)
        {
            if (!this.Contains(objControl))
            {
                objControl = this;
            }
            if (!blnForward)
            {
                if (objControl != this)
                {
                    int num4 = objControl.mintTabIndex;
                    bool blnFlag2 = false;
                    Control objControl4 = null;
                    Control objControl5 = objControl.Parent;
                    int num5 = 0;
                    Control.ControlCollection objCollection3 = (Control.ControlCollection)objControl5.Controls;
                    if (objCollection3 != null)
                    {
                        num5 = objCollection3.Count;
                    }
                    for (int num6 = num5 - 1; num6 >= 0; num6--)
                    {
                        if (objCollection3[num6] != objControl)
                        {
                            if (((objCollection3[num6].mintTabIndex <= num4) && ((objControl4 == null) || (objControl4.mintTabIndex < objCollection3[num6].mintTabIndex))) && ((objCollection3[num6].mintTabIndex != num4) || blnFlag2))
                            {
                                objControl4 = objCollection3[num6];
                            }
                        }
                        else
                        {
                            blnFlag2 = true;
                        }
                    }
                    if (objControl4 != null)
                    {
                        objControl = objControl4;
                    }
                    else
                    {
                        if (objControl5 == this)
                        {
                            return null;
                        }
                        return objControl5;
                    }
                }
                for (Control.ControlCollection objCollection4 = (Control.ControlCollection)objControl.Controls; ((objCollection4 != null) && (objCollection4.Count > 0)) && ((objControl == this) || !Control.IsFocusManagingContainerControl(objControl)); objCollection4 = (Control.ControlCollection)objControl.Controls)
                {
                    Control objControl6 = objControl.GetFirstChildControlInTabOrder(false);
                    if (objControl6 == null)
                    {
                        break;
                    }
                    objControl = objControl6;
                }
            }
            else
            {
                Control.ControlCollection objCollection1 = (Control.ControlCollection)objControl.Controls;
                if (((objCollection1 != null) && (objCollection1.Count > 0)) && ((objControl == this) || !Control.IsFocusManagingContainerControl(objControl)))
                {
                    Control objControl1 = objControl.GetFirstChildControlInTabOrder(true);
                    if (objControl1 != null)
                    {
                        return objControl1;
                    }
                }
                while (objControl != this)
                {
                    int num1 = objControl.TabIndex;
                    bool blnFlag1 = false;
                    Control objControl2 = null;
                    Control objControl3 = objControl.Parent;
                    int num2 = 0;
                    Control.ControlCollection objCollection2 = (Control.ControlCollection)objControl3.Controls;
                    if (objCollection2 != null)
                    {
                        num2 = objCollection2.Count;
                    }
                    for (int num3 = 0; num3 < num2; num3++)
                    {
                        if (objCollection2[num3] != objControl)
                        {
                            if (((objCollection2[num3].TabIndex >= num1) && ((objControl2 == null) || (objControl2.mintTabIndex > objCollection2[num3].mintTabIndex))) && ((objCollection2[num3].mintTabIndex != num1) || blnFlag1))
                            {
                                objControl2 = objCollection2[num3];
                            }
                        }
                        else
                        {
                            blnFlag1 = true;
                        }
                    }
                    if (objControl2 != null)
                    {
                        return objControl2;
                    }
                    objControl = objControl.Parent;
                }
            }
            if (objControl != this)
            {
                return objControl;
            }
            return null;
        }

        /// <summary>
        /// Gets the top level.
        /// </summary>
        /// <returns></returns>
        protected bool GetTopLevel()
        {
            return this.GetState(ControlState.TopLevel);
        }

        /// <summary>
        /// Sets the top level.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> [value].</param>
        protected void SetTopLevel(bool blnValue)
        {
            this.SetTopLevelInternal(blnValue);
        }

        /// <summary>
        /// Sets the top level internal.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> [value].</param>
        internal void SetTopLevelInternal(bool blnValue)
        {
            if (this.GetTopLevel() != blnValue)
            {
                if (this.Parent != null)
                {
                    throw new ArgumentException(SR.GetString("TopLevelParentedControl"), "value");
                }

                // Set the top level state
                this.SetState(ControlState.TopLevel, blnValue);

                if (blnValue && this.Visible)
                {
                    this.CreateControl();
                }
            }
        }

        /// <summary>
        /// Checks if a control is a contains this control
        /// </summary>
        /// <param name="objDescendantControl">The obj descendant control.</param>
        /// <returns>
        /// 	<c>true</c> if the specified obj descendant control is descendant; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsDescendant(Control objDescendantControl)
        {
            for (Control objControl = objDescendantControl; objControl != null; objControl = objControl.ParentInternal)
            {
                if (objControl == this)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves a value indicating whether the specified control is a child of the control.
        /// </summary>
        /// <param name="objControl">The control.</param>
        /// <returns>
        /// true if the specified control is a child of the control; otherwise, false.
        /// </returns>
        public bool Contains(Control objControl)
        {
            // While control is not null
            while (objControl != null)
            {
                // Get the parent control
                objControl = objControl.Parent;

                // If there is no valid parent
                if (objControl == null)
                {
                    return false;
                }
                if (objControl == this)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>Forces the creation of the control, including the creation of the handle and any child controls.</summary>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void CreateControl()
        {
            this.CreateControl(false);
        }

        /// <summary>
        /// Execute the control creation methods
        /// </summary>
        /// <param name="blnIgnoreVisible"></param>
        internal void CreateControl(bool blnIgnoreVisible)
        {
            // If not created and visible or if forced
            if ((!this.Created && this.Visible) || blnIgnoreVisible)
            {
                // Set creating mode
                this.SetState(ControlState.Created, true);

                // Local creation flag
                bool blnControlCreated = false;
                try
                {
                    // Get controls
                    Control.ControlCollection objControls = this.mobjControls;
                    if (objControls != null)
                    {
                        // Get controls array
                        Control[] arrControls = new Control[objControls.Count];
                        objControls.CopyTo(arrControls, 0);

                        // Loop all controls and create them
                        foreach (Control objControl in arrControls)
                        {
                            objControl.CreateControl(blnIgnoreVisible);
                        }
                    }

                    // Raise the created flag
                    blnControlCreated = true;
                }
                finally
                {
                    // If created the update global flag
                    if (!blnControlCreated)
                    {
                        // Set the current visibility state to false
                        this.SetState(ComponentState.Visible, false);
                    }
                }

                // Perform control's layout.
                this.PerformLayout();

                // Create current control
                this.OnCreateControl();
            }
        }

        /// <summary>Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.</summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnCreateControl()
        {
        }

        /// <summary>
        /// Raises the <see cref="E:ParentBindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnParentBindingContextChanged(EventArgs e)
        {
            // If current binding context value is null
            if (this.GetValue<BindingContext>(Control.BindingContextProperty) == null)
            {
                this.OnBindingContextChanged(e);
            }
        }


        /// <summary>
        /// Raises the <see cref="E:BindingContextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnBindingContextChanged(EventArgs e)
        {
            // If current control has a collection of control bindings
            if (this.ContainsValue<ControlBindingsCollection>(Control.DataBindingsProperty))
            {
                // Update current bindings
                this.UpdateBindings();
            }

            EventHandler objEventHandler = this.BindingContextChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }

            if (this.mobjControls != null)
            {
                for (int num1 = 0; num1 < this.mobjControls.Count; num1++)
                {
                    this.mobjControls[num1].OnParentBindingContextChanged(e);
                }
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageLayoutChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected virtual void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.BackgroundImageLayoutChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }


        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.AutoSizeChanged"></see> event. 
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnAutoSizeChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.AutoSizeChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackColorChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackColorChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.BackColorChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageChanged"></see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackgroundImageChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.BackgroundImageChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.PaddingChanged"></see> event.</summary>
        /// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected virtual void OnPaddingChanged(EventArgs e)
        {
            EventHandler objEventHandler = this.PaddingChangedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event.</summary>
        /// <param name="objHelpEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnHelpRequested(HelpEventArgs objHelpEventArgs)
        {
            HelpEventHandler objEventHandler = this.HelpRequestedHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, objHelpEventArgs);
                objHelpEventArgs.Handled = true;
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Updates the bindings.
        /// </summary>
        private void UpdateBindings()
        {
            for (int num1 = 0; num1 < this.DataBindings.Count; num1++)
            {
                BindingContext.UpdateBinding(this.BindingContext, this.DataBindings[num1]);
            }
        }

        #endregion Private Methods

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced), SRDescription("ControlBindingContextDescr"), System.ComponentModel.Browsable(false)]
        public virtual BindingContext BindingContext
        {
            get
            {
                return this.BindingContextInternal;
            }
            set
            {
                this.BindingContextInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the binding context.
        /// </summary>
        /// <value>The binding context.</value>
        internal BindingContext BindingContextInternal
        {
            get
            {
                // Try to get binding context from current control
                BindingContext objBindingContext = this.GetValue<BindingContext>(Control.BindingContextProperty, null);
                if (objBindingContext == null)
                {
                    // Get the parent control
                    Control objParentControl = this.Parent;

                    // If properties can be accessed and there is a valid parent
                    if (objParentControl != null && objParentControl.CanAccessProperties)
                    {
                        // Get parent biniding context
                        objBindingContext = objParentControl.BindingContext;
                    }
                }
                return objBindingContext;
            }
            set
            {
                // Set binding context and raise event if value had changed
                if (this.SetValue<BindingContext>(Control.BindingContextProperty, value))
                {
                    // Raise the binding context changed event
                    this.OnBindingContextChanged(EventArgs.Empty);
                }
            }
        }


        /// <summary>Gets the data bindings for the control.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for the control.</returns>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.ParenthesizePropertyName(true), System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.All), SRDescription("ControlBindingsDescr"), SRCategory("CatData")]
        [Gizmox.WebGUI.Forms.Design.LimitedTrustBrowsable(false)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                // Get the current databindings
                ControlBindingsCollection objDataBindings = this.GetValue<ControlBindingsCollection>(Control.DataBindingsProperty);

                // Check if there is a valid bindings collection
                if (objDataBindings == null)
                {
                    // Create new control binding collection
                    objDataBindings = new ControlBindingsCollection(this);

                    // Set the data bindings property value
                    this.SetValue<ControlBindingsCollection>(Control.DataBindingsProperty, objDataBindings);
                }

                // Return data bindings
                return objDataBindings;
            }
        }



        #endregion Properties

        #endregion Binding Related

        #region IArrangedElement Members



        /// <summary>
        /// Sets the bounds.
        /// </summary>
        /// <param name="intLeft">The int left.</param>
        /// <param name="intTop">The int top.</param>
        /// <param name="intWidth">Width of the int.</param>
        /// <param name="intHeight">Height of the int.</param>
        public void SetBounds(int intLeft, int intTop, int intWidth, int intHeight)
        {
            this.SetBounds(intLeft, intTop, intWidth, intHeight, BoundsSpecified.All);
        }

        /// <summary>
        /// Sets the specified bounds of the control to the specified location and size.
        /// </summary>
        /// <param name="intLeft">The int left.</param>
        /// <param name="intTop">The int top.</param>
        /// <param name="intWidth">Width of the int layout.</param>
        /// <param name="intHeight">Height of the int layout.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
        {
            return SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, false);
        }

        /// <summary>
        /// Sets the specified bounds of the control to the specified location and size.
        /// </summary>
        /// <param name="intLeft">The int left.</param>
        /// <param name="intTop">The int top.</param>
        /// <param name="intWidth">Width of the int layout.</param>
        /// <param name="intHeight">Height of the int layout.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
        /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
        /// <returns></returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
        {
            // If we need to fill in the left value
            if ((enmSpecified & BoundsSpecified.X) == BoundsSpecified.None)
            {
                intLeft = this.mintLeft;
            }

            // If we need to fill in the top value
            if ((enmSpecified & BoundsSpecified.Y) == BoundsSpecified.None)
            {
                intTop = this.mintTop;
            }

            // If we need to fill in the width value
            if ((enmSpecified & BoundsSpecified.Width) == BoundsSpecified.None)
            {
                intWidth = this.mintWidth;
            }

            // If we need to fill in the height value
            if ((enmSpecified & BoundsSpecified.Height) == BoundsSpecified.None)
            {
                intHeight = this.mintHeight;
            }

            // If a value had changed
            if (((this.mintLeft != intLeft) || (this.mintTop != intTop)) || ((this.mintWidth != intWidth) || (this.mintHeight != intHeight)))
            {
                // Set the bounds with the specified values
                return this.SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
            }

            return false;
        }

        /// <summary>
        /// Sets the bounds.
        /// </summary>
        /// <param name="objBounds">The obj bounds.</param>
        /// <param name="enmSpecified">The specified.</param>
        void IArrangedElement.SetBounds(Rectangle objBounds, BoundsSpecified enmSpecified)
        {
            ISite objSite = this.Site;
            IComponentChangeService objService = null;
            PropertyDescriptor objMember = null;
            PropertyDescriptor objPropertyDescriptor2 = null;
            bool blnFlag = false;
            bool blnFlag2 = false;
            if ((objSite != null) && objSite.DesignMode)
            {
                objService = (IComponentChangeService)objSite.GetService(typeof(IComponentChangeService));
                if (objService != null)
                {
                    objMember = TypeDescriptor.GetProperties(this)[PropertyNames.Size];
                    objPropertyDescriptor2 = TypeDescriptor.GetProperties(this)[PropertyNames.Location];
                    try
                    {
                        if (((objMember != null) && !objMember.IsReadOnly) && ((objBounds.Width != this.Width) || (objBounds.Height != this.Height)))
                        {
                            if (!(objSite is INestedSite))
                            {
                                objService.OnComponentChanging(this, objMember);
                            }
                            blnFlag = true;
                        }
                        if (((objPropertyDescriptor2 != null) && !objPropertyDescriptor2.IsReadOnly) && ((objBounds.X != this.mintLeft) || (objBounds.Y != this.mintTop)))
                        {
                            if (!(objSite is INestedSite))
                            {
                                objService.OnComponentChanging(this, objPropertyDescriptor2);
                            }
                            blnFlag2 = true;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }
            }
            this.SetBoundsCore(objBounds.X, objBounds.Y, objBounds.Width, objBounds.Height, enmSpecified);
            if ((objSite != null) && (objService != null))
            {
                try
                {
                    if (blnFlag)
                    {
                        objService.OnComponentChanged(this, objMember, null, null);
                    }
                    if (blnFlag2)
                    {
                        objService.OnComponentChanged(this, objPropertyDescriptor2, null, null);
                    }
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        /// <summary>Performs the work of setting the specified bounds of this control.</summary>
        /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control. </param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. </param>
        /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control. </param>
        /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control. </param>
        /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
        {
            return SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, false);
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
        /// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
        /// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
        /// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
        /// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
        /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
        {
            // If size or location had changed
            if (((this.mintLeft != intLeft) || (this.mintTop != intTop)) || ((this.mintWidth != intWidth) || (this.mintHeight != intHeight)))
            {
                // Get the bounds contrained
                Rectangle objRectangle = this.ApplyBoundsConstraints(intLeft, intTop, intWidth, intHeight);

                // set the values from the constrained rectangle
                intWidth = objRectangle.Width;
                intHeight = objRectangle.Height;
                intLeft = objRectangle.X;
                intTop = objRectangle.Y;

                // Update the control bounds
                return this.UpdateBounds(intLeft, intTop, intWidth, intHeight, blnIsClientSource);
            }

            return false;
        }

        /// <summary>
        /// Applies the bounds constraints.
        /// </summary>
        /// <param name="intSuggestedX">The suggested X.</param>
        /// <param name="intSuggestedY">The suggested Y.</param>
        /// <param name="intProposedWidth">Width of the proposed.</param>
        /// <param name="intProposedHeight">Height of the proposed.</param>
        /// <returns></returns>
        internal virtual Rectangle ApplyBoundsConstraints(int intSuggestedX, int intSuggestedY, int intProposedWidth, int intProposedHeight)
        {
            if (!(this.MaximumSize != Size.Empty) && !(this.MinimumSize != Size.Empty))
            {
                return new Rectangle(intSuggestedX, intSuggestedY, intProposedWidth, intProposedHeight);
            }
            Size objSize = LayoutUtils.ConvertZeroToUnbounded(this.MaximumSize);
            Rectangle objRectangle = new Rectangle(intSuggestedX, intSuggestedY, 0, 0);
            objRectangle.Size = LayoutUtils.IntersectSizes(new Size(intProposedWidth, intProposedHeight), objSize);
            objRectangle.Size = LayoutUtils.UnionSizes(objRectangle.Size, this.MinimumSize);
            return objRectangle;
        }

        /// <summary>Updates the bounds of the control with the specified size and location.</summary>
        /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
        /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
        /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
        /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight)
        {
            return this.UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, false);
        }

        /// <summary>
        /// Updates the bounds of the control with the specified size and location.
        /// </summary>
        /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control.</param>
        /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control.</param>
        /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control.</param>
        /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control.</param>
        /// <param name="blnIsClientSource">if set to <c>true</c> [BLN is client source].</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight, bool blnIsClientSource)
        {
            return this.UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, blnIsClientSource);
        }

        /// <summary>Updates the bounds of the control with the specified size, location, and client size.</summary>
        /// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
        /// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
        /// <param name="intClientHeight">The client <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
        /// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
        /// <param name="intClientWidth">The client <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
        /// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight, int intClientWidth, int intClientHeight, bool blnIsClientSource)
        {
            // CHeck if location changed
            bool blnLocationChanged = (this.mintLeft != intLeft) || (this.mintTop != intTop);

            // CHeck if size changed
            bool blnSizeChanged = (this.mintWidth != intWidth) || (this.mintHeight != intHeight);

            // If size or location had changed
            if (blnSizeChanged || blnLocationChanged)
            {
                // Set the internal values
                this.mintLeft = intLeft;
                this.mintTop = intTop;
                this.mintHeight = intHeight;
                this.mintWidth = intWidth;

                if (blnLocationChanged)
                {
                    this.OnLocationChanged(new LayoutEventArgs(blnIsClientSource, false, false));
                }
                if (blnSizeChanged)
                {
                    this.OnSizeChanged(EventArgs.Empty);
                }

                if (!blnIsClientSource)
                {
                    this.UpdateParams(AttributeType.Layout);
                }

                return true;
            }
            return false;
        }

        /// <summary>Gets or sets the size and location of the control including its nonclient elements, in pixels, relative to the parent control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> in pixels relative to the parent control that represents the size and location of the control including its nonclient elements.</returns>
        /// <filterpriority>2</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Browsable(false), SRDescription("ControlBoundsDescr"), EditorBrowsable(EditorBrowsableState.Advanced), SRCategory("CatLayout"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(this.mintLeft, this.mintTop, this.mintWidth, this.mintHeight);
            }
            set
            {
                this.SetBounds(value.X, value.Y, value.Width, value.Height, BoundsSpecified.All);

                // Update params.
                this.UpdateParams(AttributeType.Layout);
            }
        }

        #endregion

        #region Skinning Related

        /// <summary>
        /// The skin of the current control
        /// </summary>
        /// <remarks>
        /// This field provides the Skin property its presistance an in serialization mode
        /// it is not required to be serialized as the Skin property automaticly generates and
        /// instance if this field is null.
        /// </remarks>
        [NonSerialized()]
        private ControlSkin mobjSkin = null;


        /// <summary>
        /// Gets the skin of the current control.
        /// </summary>
        /// <value>The skin of the current control.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        protected internal ControlSkin Skin
        {
            get
            {
                // If skin was not yet registered
                if (mobjSkin == null)
                {
                    // Register control for skinning
                    mobjSkin = (ControlSkin)SkinFactory.GetSkin(this);
                }
                return mobjSkin;
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>The theme related to the skinable component.</value>
        string ISkinable.Theme
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
                    if (this.Context != null)
                    {
                        return this.Context.CurrentTheme;
                    }

                    return ConfigHelper.SelectedTheme;
                }
            }
        }

        #endregion


        #region Client Members


        /// <summary>
        /// Gets or sets the client click action.
        /// </summary>
        /// <value>
        /// The client click action.
        /// </value>
        [Category("Client")]
        [Description("Occurs when control is clicked and client is in client mode.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event ClientEventHandler ClientClick
        {
            add
            {
                this.AddClientHandler("Click", value);
            }
            remove
            {
                this.RemoveClientHandler("Click", value);
            }
        }

        /// <summary>
        /// Gets or sets the client click action.
        /// </summary>
        /// <value>
        /// The client click action.
        /// </value>
        [Category("Client")]
        [Description("Occurs when control is clicked and client is in client mode.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event ClientEventHandler ClientDoubleClick
        {
            add
            {
                this.AddClientHandler("DoubleClick", value);
            }
            remove
            {
                this.RemoveClientHandler("DoubleClick", value);
            }
        }


        /// <summary>
        /// Gets or sets the client focus action.
        /// </summary>
        /// <value>
        /// The client focus action.
        /// </value>
        [Category("Client")]
        [Description("Occurs when the control gets focus and client is in client mode.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event ClientEventHandler ClientFocus
        {
            add
            {
                this.AddClientHandler("GotFocus", value);
            }
            remove
            {
                this.RemoveClientHandler("GotFocus", value);
            }
        }

        /// <summary>
        /// Gets or sets the client blur action.
        /// </summary>
        /// <value>
        /// The client blur action.
        /// </value>
        [Category("Client")]
        [Description("Occurs when the control looses focus and client is in client mode.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event ClientEventHandler ClientBlur
        {
            add
            {
                this.AddClientHandler("LostFocus", value);
            }
            remove
            {
                this.RemoveClientHandler("LostFocus", value);
            }
        }

        /// <summary>
        /// Occurs when [client key down].
        /// </summary>
        [Category("Client")]
        [Description("Occurs when the control gets key down and client is in client mode.")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event ClientEventHandler ClientKeyDown
        {
            add
            {
                this.AddClientHandler("KeyDown", value);
            }
            remove
            {
                this.RemoveClientHandler("KeyDown", value);
            }
        }

        #endregion
    }

    #endregion

    #region ControlRenderingContext Class

    /// <summary>
    /// Provides contextual support for rendering
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ControlRenderingContext
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly PixelFormat menmPixelFormat;

        /// <summary>
        /// The image resource cache
        /// </summary>
        private Dictionary<string, Image> mobjImageCache = new Dictionary<string, Image>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlRenderingContext"/> class.
        /// </summary>
        /// <param name="enmPixelFormat">The pixel format.</param>
        internal ControlRenderingContext(PixelFormat enmPixelFormat)
        {
            menmPixelFormat = enmPixelFormat;
        }

        /// <summary>
        /// Gets the pixel format.
        /// </summary>
        public PixelFormat PixelFormat
        {
            get { return menmPixelFormat; }
        }

        /// <summary>
        /// Gets the resource image.
        /// </summary>
        /// <param name="objResourceHandle">The resource handle.</param>
        /// <returns></returns>
        internal Image GetResourceImage(ResourceHandle objResourceHandle)
        {
            Image objResourceImage = null;

            // If there is a valid resources
            if (objResourceHandle != null)
            {
                // If can get image
                if (objResourceHandle.CanGetImage)
                {
                    // Get the image key
                    string strImageKey = objResourceHandle.ToString();

                    // If there is a valid image key
                    if (!string.IsNullOrEmpty(strImageKey))
                    {
                        // Try to get cached image
                        if (!mobjImageCache.TryGetValue(strImageKey, out objResourceImage))
                        {
                            try
                            {
                                // Get the resource image
                                objResourceImage = objResourceHandle.ToImage();
                            }
                            catch
                            {
                                // We don't whant exceptions while rendering
                            }

                            // Cache the result
                            mobjImageCache[strImageKey] = objResourceImage;
                        }
                    }
                }
            }

            return objResourceImage;
        }
    }

    #endregion

    #region ControlRenderer Class

    /// <summary>
    /// Provides support for rendering a control
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class ControlRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Control mobjControl = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlRenderer"/> class.
        /// </summary>
        /// <param name="objControl">The control.</param>
        public ControlRenderer(Control objControl)
        {
            mobjControl = objControl;
        }

        /// <summary>
        /// Renders the control to the specified graphics.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected internal virtual void Render(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderBackground(objContext, objGraphics);
            RenderBorder(objContext, objGraphics);
            RenderContent(objContext, objGraphics);
        }


        /// <summary>
        /// Gets the content region.
        /// </summary>
        /// <returns></returns>
        protected static Rectangle GetContentRegion(Control objControl)
        {
            return GetContentRegion(objControl, true, true);
        }

        /// <summary>
        /// Gets the content region.
        /// </summary>
        /// <returns></returns>
        protected static Rectangle GetContentRegion(Control objControl, bool blnApplyPadding, bool blnApplyBorder)
        {
            int intX = 0;
            int intY = 0;
            int intW = 0;
            int intH = 0;

            // If there is a valid control
            if (objControl != null)
            {
                // Set the control size
                intW = objControl.Width;
                intH = objControl.Height;

                // If should calculate padding
                if (blnApplyPadding)
                {
                    // Apply control padding
                    Padding objPadding = objControl.Padding;
                    intX += objPadding.Left;
                    intY += objPadding.Top;
                    intW -= objPadding.Horizontal;
                    intH -= objPadding.Vertical;
                }

                // If should calculate border
                if (blnApplyBorder)
                {
                    // If there is a valid border
                    if (objControl.BorderStyle != BorderStyle.None)
                    {
                        // Apply control border
                        BorderWidth objBorder = objControl.BorderWidth;
                        intX += objBorder.Left;
                        intY += objBorder.Top;
                        intW -= objBorder.Right + objBorder.Left;
                        intH -= objBorder.Bottom + objBorder.Top;
                    }
                }

                // Make sure size is valid
                if (intW < 0) intW = 0;
                if (intH < 0) intH = 0;
            }

            // REturn the content rectangle
            return new Rectangle(intX, intY, intW, intH);

        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }


        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objForeColor">The fore color.</param>
        /// <param name="objRegionSize">The region size.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        /// <param name="blnWrapText">if set to <c>true</c> wrap text.</param>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Size objRegionSize, HorizontalAlignment enmAlignemnt, bool blnWrapText)
        {
            return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
        }

        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objForeColor">The fore color.</param>
        /// <param name="objRegionSize">The region size.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        /// <param name="blnWrapText">if set to <c>true</c> wrap text.</param>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Size objRegionSize, ContentAlignment enmAlignemnt, bool blnWrapText)
        {
            return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
        }

        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objForeColor">The fore color.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Rectangle objRegion, HorizontalAlignment enmAlignemnt, bool blnWrapText)
        {
            ContentAlignment enmContentAlignment = ContentAlignment.MiddleCenter;

            switch (enmAlignemnt)
            {
                case HorizontalAlignment.Center:
                    enmContentAlignment = ContentAlignment.MiddleCenter;
                    break;
                case HorizontalAlignment.Right:
                    enmContentAlignment = ContentAlignment.MiddleRight;
                    break;
                case HorizontalAlignment.Left:
                    enmContentAlignment = ContentAlignment.MiddleLeft;
                    break;
            }

            return RenderText(objContext, objGraphics, strText, objFont, objForeColor, objRegion, enmContentAlignment, blnWrapText);
        }



        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objForeColor">The fore color.</param>
        /// <param name="objLocation">The location.</param>
        /// <returns></returns>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Point objLocation)
        {
            return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, false);
        }

        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objForeColor">The fore color.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Rectangle objRegion, ContentAlignment enmAlignemnt, bool blnWrapText)
        {
            return RenderText(objContext, objGraphics, strText, objFont, new SolidBrush(objForeColor), objRegion, enmAlignemnt, blnWrapText);
        }


        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objBrush">The brush.</param>
        /// <param name="objLocation">The location.</param>
        /// <returns></returns>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Brush objBrush, Point objLocation)
        {
            return RenderText(objContext, objGraphics, strText, objFont, objBrush, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, false);
        }

        /// <summary>
        /// Gets a flag indicating if the region is visible
        /// </summary>
        /// <param name="objRegion"></param>
        /// <returns></returns>
        protected static bool IsVisibleRegion(Rectangle objRegion)
        {
            return objRegion.Width > 0 && objRegion.Height > 0;
        }

        /// <summary>
        /// Renders the text.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="strText">The text.</param>
        /// <param name="objFont">The font.</param>
        /// <param name="objBrush">The brush.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Brush objBrush, Rectangle objCurrentRegion, ContentAlignment enmAlignemnt, bool blnWrapText)
        {
            SizeF objTextSize;

            // If font is missing
            if (objFont == null)
            {
                objFont = SystemFonts.DefaultFont;
            }

            // If should wrap text
            if (blnWrapText)
            {
                // Get text size with wrapping
                objTextSize = objGraphics.MeasureString(strText, objFont, objCurrentRegion.Width);
            }
            else
            {
                // Get text size without wrapping
                objTextSize = objGraphics.MeasureString(strText, objFont);
            }

            // Get the text location
            PointF objTextLocation = GetContentLocation(objTextSize, objCurrentRegion, enmAlignemnt);

            // Save the current region
            Region objCurrentClip = objGraphics.Clip;

            // Set the cliping region
            objGraphics.Clip = new Region(objCurrentRegion);

            // Draw the graphics string
            objGraphics.DrawString(strText, objFont, objBrush, objTextLocation);

            // Clear the cliping region
            objGraphics.Clip = objCurrentClip;

            return new RectangleF(objTextLocation, objTextSize);
        }


        /// <summary>
        /// Renders the image.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objResourceHandle">The resource handle.</param>
        /// <param name="objLocation">The location.</param>
        protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Point objLocation)
        {
            return RenderImage(objContext, objGraphics, objResourceHandle, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
        }


        /// <summary>
        /// Renders the image.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objResourceHandle">The resource handle.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Rectangle objRegion, ContentAlignment enmAlignemnt)
        {
            // If there is a resource handle
            if (objResourceHandle != null)
            {
                try
                {
                    // If can get image
                    if (objResourceHandle.CanGetImage)
                    {
                        // Get the image from the resource handler
                        Image objImage = objResourceHandle.ToImage();

                        // If there is a valid image
                        if (objImage != null)
                        {
                            // Render the image
                            return RenderImage(objContext, objGraphics, objImage, objRegion, enmAlignemnt);
                        }
                    }
                }
                catch
                {
                    // We don't want exceptions
                }
            }

            return RectangleF.Empty;
        }

        /// <summary>
        /// Renders the image.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objImage">The image.</param>
        /// <param name="objLocation">The location.</param>
        /// <returns></returns>
        protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, Image objImage, Point objLocation)
        {
            return RenderImage(objContext, objGraphics, objImage, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
        }

        /// <summary>
        /// Renders the image.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objImage">The image.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmAlignemnt">The alignemnt.</param>
        protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, Image objImage, Rectangle objRegion, ContentAlignment enmAlignemnt)
        {
            // If there is a valid image
            if (objImage != null)
            {
                // Get the image location
                PointF objImageLocation = GetContentLocation(objImage.Size, objRegion, enmAlignemnt);

                // Draw the image
                objGraphics.DrawImage(objImage, objImageLocation);

                // Return the containing rectangle
                return new RectangleF(objImageLocation, objImage.Size);
            }

            return RectangleF.Empty;
        }



        /// <summary>
        /// Gets the vertical alignment.
        /// </summary>
        /// <param name="enmAlignment">The alignment.</param>
        /// <param name="blnIsLeft">if set to <c>true</c> is left.</param>
        /// <returns></returns>
        protected static ContentAlignment GetVerticalAlignment(ContentAlignment enmAlignment, bool blnIsLeft)
        {
            if (blnIsLeft)
            {
                switch (enmAlignment)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        return ContentAlignment.BottomLeft;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleLeft:
                        return ContentAlignment.MiddleLeft;
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        return ContentAlignment.TopLeft;
                }
            }
            else
            {
                switch (enmAlignment)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomRight:
                        return ContentAlignment.BottomRight;
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleLeft:
                        return ContentAlignment.MiddleRight;
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        return ContentAlignment.TopRight;
                }
            }

            return enmAlignment;
        }

        /// <summary>
        /// Gets the horizontal alignment.
        /// </summary>
        /// <param name="enmAlignment">The alignment.</param>
        /// <param name="blnIsTop">if set to <c>true</c> is top.</param>
        /// <returns></returns>
        protected static ContentAlignment GetHorizontalAlignment(ContentAlignment enmAlignment, bool blnIsTop)
        {
            if (blnIsTop)
            {
                switch (enmAlignment)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                        return ContentAlignment.TopCenter;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                        return ContentAlignment.TopLeft;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                        return ContentAlignment.TopRight;
                }
            }
            else
            {
                switch (enmAlignment)
                {
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.TopCenter:
                        return ContentAlignment.BottomCenter;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                        return ContentAlignment.BottomLeft;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                        return ContentAlignment.BottomRight;
                }
            }

            return enmAlignment;
        }

        /// <summary>
        /// Gets the content location.
        /// </summary>
        /// <param name="objContentSize">The content size.</param>
        /// <param name="objRegion">The region size.</param>
        /// <param name="enmAlignemnt">The content alignemnt.</param>
        /// <returns></returns>
        private static PointF GetContentLocation(SizeF objContentSize, Rectangle objRegion, ContentAlignment enmAlignemnt)
        {
            float fltX = 0;
            float fltY = 0;

            switch (enmAlignemnt)
            {
                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    fltX = objRegion.Right - objContentSize.Width;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.TopLeft:
                    fltX = objRegion.Left;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                    fltX = objRegion.Left + objRegion.Width / 2 - objContentSize.Width / 2;
                    break;
            }



            switch (enmAlignemnt)
            {
                case ContentAlignment.BottomRight:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                    fltY = objRegion.Bottom - objContentSize.Height;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                    fltY = objRegion.Top;
                    break;
                case ContentAlignment.MiddleRight:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                    fltY = objRegion.Top + objRegion.Height / 2 - objContentSize.Height / 2;
                    break;
            }

            return new PointF(fltX, fltY);
        }



        /// <summary>
        /// Docks the in region.
        /// </summary>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmDock">The dock.</param>
        /// <param name="objRectangleF">The docked rectangle.</param>
        /// <returns></returns>
        protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, RectangleF objRectangleF)
        {
            return DockInRegion(objRegion, enmDock, Rectangle.Truncate(objRectangleF));
        }

        /// <summary>
        /// Docks the in region.
        /// </summary>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmDock">The dock.</param>
        /// <param name="objRectangle">The docked rectangle.</param>
        /// <returns></returns>
        protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, Rectangle objRectangle)
        {
            return DockInRegion(objRegion, enmDock, objRectangle.Size);
        }

        /// <summary>
        /// Docks the in region.
        /// </summary>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmDock">The dock.</param>
        /// <param name="objSize">The docked size.</param>
        /// <returns></returns>
        protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, SizeF objSize)
        {
            return DockInRegion(objRegion, enmDock, Size.Truncate(objSize));
        }

        /// <summary>
        /// Docks the in region.
        /// </summary>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmDock">The dock.</param>
        /// <param name="objSize">The docked size.</param>
        /// <returns></returns>
        protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, Size objSize)
        {
            int intX = objRegion.X;
            int intY = objRegion.Y;
            int intH = objRegion.Height;
            int intW = objRegion.Width;

            switch (enmDock)
            {
                case DockStyle.Left:
                    intX += objSize.Width;
                    intW -= objSize.Width;
                    break;
                case DockStyle.Right:
                    intW -= objSize.Width;
                    break;
                case DockStyle.Top:
                    intY += objSize.Height;
                    intH -= objSize.Height;
                    break;
                case DockStyle.Bottom:
                    intH -= objSize.Height;
                    break;
            }

            if (intH < 0) intH = 0;
            if (intW < 0) intW = 0;

            return new Rectangle(intX, intY, intW, intH);
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {
            BorderStyle enmBorderStyle = mobjControl.BorderStyle;

            if (enmBorderStyle != BorderStyle.None && enmBorderStyle != BorderStyle.Clear)
            {
                int intHeight = mobjControl.Height;
                int intWidth = mobjControl.Width;

                if (intHeight > 2 && intWidth > 2)
                {
                    objGraphics.DrawRectangle(new Pen(mobjControl.BorderColor, 1), new Rectangle(0, 0, intWidth - 2, intHeight - 2));
                }
            }

        }

        /// <summary>
        /// Renders the background.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderBackground(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderBackgroundColor(objContext, objGraphics);
            RenderBackgroundImage(objContext, objGraphics);
        }

        /// <summary>
        /// Renders the background image.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderBackgroundImage(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the background color.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderBackgroundColor(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Draw the background
            objGraphics.DrawRectangle(new Pen(mobjControl.BackColor), new Rectangle(new Point(0, 0), mobjControl.Size));
        }


        /// <summary>
        /// Renders the controls.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected virtual void RenderControls(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Loop all controls
            foreach (Control objControl in mobjControl.Controls)
            {
                // Get the control bitmap
                Bitmap objControlBitmap = objControl.DrawControl(objContext, objControl.Width, objControl.Height);

                // If there is a valid control bitmap
                if (objControlBitmap != null)
                {
                    // Draw the control at the specified location
                    objGraphics.DrawImage(objControlBitmap, objControl.Location);
                }
            }
        }


        /// <summary>
        /// Renders the frame.
        /// </summary>
        /// <param name="objGraphics">The obj graphics.</param>
        /// <param name="objFrameStyle">The frame style.</param>
        /// <param name="objRegion">The region.</param>
        protected static void RenderFrame(ControlRenderingContext objContext, Graphics objGraphics, Skin objSkin, FrameStyleValue objFrameStyle, Rectangle objRegion)
        {
            ResourceHandle objTopLeftImage = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftTopStyle.BackgroundImage);
            ResourceHandle objTopRightImage = objSkin.GetResourceHandleFromReference(objFrameStyle.RightTopStyle.BackgroundImage);
            ResourceHandle objBottomLeftImage = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftBottomStyle.BackgroundImage);
            ResourceHandle objBottomRightImage = objSkin.GetResourceHandleFromReference(objFrameStyle.RightBottomStyle.BackgroundImage);

            Rectangle objTopLeftImageRegion = Rectangle.Truncate(RenderImage(objContext, objGraphics, objTopLeftImage, objRegion, ContentAlignment.TopLeft));
            Rectangle objTopRightImageRegion = Rectangle.Truncate(RenderImage(objContext, objGraphics, objTopRightImage, objRegion, ContentAlignment.TopRight));
            Rectangle objBottomLeftImageRegion = Rectangle.Truncate(RenderImage(objContext, objGraphics, objBottomLeftImage, objRegion, ContentAlignment.BottomLeft));
            Rectangle objBottomRightImageRegion = Rectangle.Truncate(RenderImage(objContext, objGraphics, objBottomRightImage, objRegion, ContentAlignment.BottomRight));


            ResourceHandle objLeftImage = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftStyle.BackgroundImage);
            ResourceHandle objRightImage = objSkin.GetResourceHandleFromReference(objFrameStyle.RightStyle.BackgroundImage);
            ResourceHandle objTopImage = objSkin.GetResourceHandleFromReference(objFrameStyle.TopStyle.BackgroundImage);
            ResourceHandle objBottomImage = objSkin.GetResourceHandleFromReference(objFrameStyle.BottomStyle.BackgroundImage);


            int intLeftWidth = objTopLeftImageRegion.Width;
            int intRightWidth = objTopRightImageRegion.Width;
            int intTopHeight = objTopLeftImageRegion.Height;
            int intBottomHeight = objBottomLeftImageRegion.Height;

            Rectangle objLeftRegion = new Rectangle(objRegion.Left, objRegion.Top + intTopHeight, intLeftWidth, Math.Max(objRegion.Height - intTopHeight - intBottomHeight, 0));
            Rectangle objRightRegion = new Rectangle(objRegion.Right - intRightWidth, objRegion.Top + intTopHeight, intRightWidth, Math.Max(objRegion.Height - intTopHeight - intBottomHeight, 0));
            Rectangle objTopRegion = new Rectangle(objRegion.Left + intLeftWidth, objRegion.Top, Math.Max(objRegion.Width - intLeftWidth - intRightWidth, 0), intTopHeight);
            Rectangle objBottomRegion = new Rectangle(objRegion.Left + intLeftWidth, objRegion.Bottom - intBottomHeight, Math.Max(objRegion.Width - intLeftWidth - intRightWidth, 0), intBottomHeight);

            RenderStyle(objContext, objGraphics, objSkin, objFrameStyle.CenterStyle, new Rectangle(objRegion.Left + intLeftWidth, objRegion.Top + intTopHeight, Math.Max(objRegion.Width - intLeftWidth - intRightWidth, 0), Math.Max(objRegion.Height - intTopHeight - intBottomHeight, 0)));
            RenderRepeatedImage(objContext, objGraphics, objLeftImage, objLeftRegion, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopLeft);
            RenderRepeatedImage(objContext, objGraphics, objRightImage, objRightRegion, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopRight);
            RenderRepeatedImage(objContext, objGraphics, objTopImage, objTopRegion, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.TopLeft);
            RenderRepeatedImage(objContext, objGraphics, objBottomImage, objBottomRegion, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.BottomLeft);
        }

        /// <summary>
        /// Renders the style.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objSkin">The skin.</param>
        /// <param name="objStyle">The style.</param>
        /// <param name="objRegion">The region.</param>
        protected static void RenderStyle(ControlRenderingContext objContext, Graphics objGraphics, Skin objSkin, StyleValue objStyle, Rectangle objRegion)
        {
            try
            {
                ResourceHandle objImage = objSkin.GetResourceHandleFromReference(objStyle.BackgroundImage);
                if (objImage != null)
                {
                    RenderRepeatedImage(objContext, objGraphics, objImage, objRegion, objStyle.BackgroundImageRepeat, objStyle.BackgroundImagePosition);
                }
            }
            catch
            {
                // We don't want exceptions while rendering
            }
        }

        /// <summary>
        /// Renders the repeated image.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objResourceHandle">The resource handle.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmImageRepeat">The image repeat.</param>
        /// <param name="enmImagePosition">The image position.</param>
        protected static void RenderRepeatedImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Rectangle objRegion, BackgroundImageRepeat enmImageRepeat, BackgroundImagePosition enmImagePosition)
        {
            if (objResourceHandle != null)
            {
                // Get the image from the resource handler
                Image objImage = objContext.GetResourceImage(objResourceHandle);

                // If there is a valid image
                if (objImage != null)
                {
                    // Render the image
                    RenderRepeatedImage(objContext, objGraphics, objImage, objRegion, enmImageRepeat, enmImagePosition);
                }
            }
        }

        /// <summary>
        /// Renders the repeated image.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objImage">The image.</param>
        /// <param name="objRegion">The region.</param>
        /// <param name="enmImageRepeat">The image repeat.</param>
        /// <param name="enmImagePosition">The image position.</param>
        protected static void RenderRepeatedImage(ControlRenderingContext objContext, Graphics objGraphics, Image objImage, Rectangle objRegion, BackgroundImageRepeat enmImageRepeat, BackgroundImagePosition enmImagePosition)
        {
            if (objImage != null)
            {
                TextureBrush objTextureBrush = objTextureBrush = new TextureBrush(objImage, System.Drawing.Drawing2D.WrapMode.Tile); ;


                if (enmImageRepeat == BackgroundImageRepeat.RepeatX)
                {
                    switch (enmImagePosition)
                    {
                        case BackgroundImagePosition.TopCenter:
                        case BackgroundImagePosition.TopLeft:
                        case BackgroundImagePosition.TopRight:
                            objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
                            break;
                        case BackgroundImagePosition.BottomCenter:
                        case BackgroundImagePosition.BottomRight:
                        case BackgroundImagePosition.BottomLeft:
                            objRegion.Y = objRegion.Bottom - objImage.Height;
                            objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
                            break;
                        case BackgroundImagePosition.MiddleCenter:
                        case BackgroundImagePosition.MiddleLeft:
                        case BackgroundImagePosition.MiddleRight:
                            objRegion.Y += objRegion.Height / 2 - objRegion.Height / 2;
                            objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
                            break;
                    }
                }
                else if (enmImageRepeat == BackgroundImageRepeat.RepeatY)
                {
                    switch (enmImagePosition)
                    {

                        case BackgroundImagePosition.MiddleLeft:
                        case BackgroundImagePosition.TopLeft:
                        case BackgroundImagePosition.BottomLeft:
                            objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
                            break;
                        case BackgroundImagePosition.MiddleRight:
                        case BackgroundImagePosition.TopRight:
                        case BackgroundImagePosition.BottomRight:
                            objRegion.X = objRegion.Right - objImage.Width;
                            objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
                            break;
                        case BackgroundImagePosition.BottomCenter:
                        case BackgroundImagePosition.MiddleCenter:
                        case BackgroundImagePosition.TopCenter:
                            objRegion.X += objRegion.Width / 2 - objRegion.Width / 2;
                            objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
                            break;
                    }
                }


                objGraphics.FillRectangle(objTextureBrush, objRegion);

            }

        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        public Control Control
        {
            get { return mobjControl; }
        }
    }

    #endregion

}
