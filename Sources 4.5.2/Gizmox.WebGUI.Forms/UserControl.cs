#region Using

using System;
using System.Xml;
using System.ComponentModel;
using System.ComponentModel.Design;

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;


#endregion

namespace Gizmox.WebGUI.Forms
{
	/// <summary>
    /// Provides an empty control that can be used to create other controls.
	/// </summary>
	[ToolboxItem(true)]
	[DesignerCategory("UserControl")]
    [DefaultEvent("Load")]
#if WG_NET46
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET452
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET451
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET45
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET40
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET35
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#elif WG_NET2
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#else
    [Designer("Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", typeof(IRootDesigner))]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.UserControlController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
#endif
    [MetadataTag("UC")]
    [Skin(typeof(UserControlSkin))]
    [Serializable()]
	public class UserControl : ContainerControl, IUserControl
	{
		
		#region Class Members

        #region Events related
        
        /// <summary>
        /// Occurs before the control becomes visible for the first time.
        /// </summary>
        [SRCategory("CatBehavior"), SRDescription("UserControlOnLoadDescr")]
		public event EventHandler Load
        {
            add
            {
                this.AddHandler(UserControl.LoadEvent, value);
            }
            remove
            {
                this.RemoveHandler(UserControl.LoadEvent, value);
            }
        }
        
        /// <summary>
        /// Gets the hanlder for the Load event.
        /// </summary>
        private EventHandler LoadHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(UserControl.LoadEvent);
            }
        }

        /// <summary>
        /// The Load event registration.
        /// </summary>
        private static readonly SerializableEvent LoadEvent = SerializableEvent.Register("Load", typeof(EventHandler), typeof(UserControl));

        #endregion

        /// <summary>
        /// The current context object
        /// </summary>
        [NonSerialized()]
        private IContext mobjContext = null;

		#endregion

		#region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UserControl"></see> class.
        /// </summary>
		public UserControl()
		{
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}
		
		#endregion

        #region Methods
        
        #region Render

        /// <summary>
        /// Renders the specified obj context.
        /// </summary>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // render child controls
            RenderControls(objContext, objWriter, lngRequestID);
        }

        #endregion

        #region Events
        
        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnCreateControl()
        {
            // Call control create base
            base.OnCreateControl();

            // Call the load event
            this.OnLoad(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.UserControl.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLoad(EventArgs e)
        {
            // Raise event if needed
            EventHandler objEventHandler = this.LoadHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }
        
        #endregion

        /// <summary>
        /// Determines whether has focusable child.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if has focusable child; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasFocusableChild()
        {
            Control objControl = null;
            do
            {
                objControl = base.GetNextControl(objControl, true);
            }
            while ((((objControl == null) || !objControl.CanSelect) || !objControl.TabStop) && (objControl != null));
            return (objControl != null);
        }

        /// <summary>
        /// Causes all of the child controls within a control that support validation to validate their data.
        /// </summary>
        /// <param name="validationConstraints">Tells <see cref="M:System.Windows.Forms.ContainerControl.ValidateChildren(System.Windows.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
        /// <returns>
        /// true if all of the children validated successfully; otherwise, false.
        /// </returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            return base.ValidateChildren(validationConstraints);
        }

        #endregion

		#region Properties

		
        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value></value>
        /// <returns>true if enabled; otherwise, false.</returns>
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }
        /// <summary>Indicates the automatic sizing behavior of the control.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always)]
        new public virtual AutoSizeMode AutoSizeMode
        {
            get
            {
                return base.AutoSizeMode;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(AutoSizeMode));
                }
                base.AutoSizeMode = value;
            }
        }
		
        #endregion 
    
        #region IUserControl Members

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value></value>
        public override IContext Context
        {
            get
            {
                if (mobjContext != null)
                {
                    return mobjContext;
                }
                return base.Context;
            }
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="objContext">The context.</param>
        void IUserControl.SetContext(IContext objContext)
        {
            mobjContext = objContext;
        }

        #endregion
    }
}
