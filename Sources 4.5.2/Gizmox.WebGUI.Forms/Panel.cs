#region Using

using System;
using System.Xml;
using System.Drawing;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel;


#endregion

namespace Gizmox.WebGUI.Forms
{
	#region Enums

	/// <summary>
	/// The panel display tyle
	/// </summary>
	
    [Obsolete("Use HeaderedPanel in the office extension instead")]
    [EditorBrowsable(EditorBrowsableState.Never)]
	public enum PanelType
	{
        /// <summary>
        /// Normal
        /// </summary>
		Normal=0,
        /// <summary>
        /// Titled
        /// </summary>
		Titled=1,
        /// <summary>
        /// Border
        /// </summary>
		Border=2,
        /// <summary>
        /// Page
        /// </summary>
		Page=3,
        /// <summary>
        /// Custom
        /// </summary>
		Custom=4,
        /// <summary>
        /// Navigation
        /// </summary>
		Navigation=5
	}
	#endregion 

	#region Panel Class

	/// <summary>
	///  Represents a Panel control.  
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(Panel), "Panel_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(Panel), "Panel.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
	[Serializable()]
    [ToolboxItemCategory("Containers")]
    [MetadataTag(WGTags.Panel)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.PanelSkin))]
	public class Panel : ScrollableControl
    {
        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to PanelType property.
        /// </summary>
        private static SerializableProperty PanelTypeProperty = SerializableProperty.Register("PanelType", typeof(PanelType), typeof(Panel), new SerializablePropertyMetadata(PanelType.Normal));

        #endregion Serializable Properties

        #region C'tors / D'tors

        /// <summary>
        /// Creates a new <see cref="Panel"/> instance.
        /// </summary>
        public Panel()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable, false);
            
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.TabStop = false;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Render

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // add attributes to control element
            objWriter.WriteAttributeText(WGAttributes.Text, Text);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            objWriter.WriteAttributeText(WGAttributes.Text, Text);
        }

        #endregion Render

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the panel type.
        /// </summary>
        /// <value></value>
        [Obsolete("Use HeaderedPanel in the office extension instead")]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public PanelType PanelType
        {
            get
            {
                return this.GetValue<PanelType>(Panel.PanelTypeProperty);
            }
            set
            {
                if (this.SetValue<PanelType>(Panel.PanelTypeProperty, value))
                {
                    switch (value)
                    {
                        case PanelType.Normal:
                            this.CustomStyle = "";
                            break;
                        case PanelType.Border:
                            this.CustomStyle = "Border";
                            break;
                        case PanelType.Page:
                            this.CustomStyle = "Page";
                            break;
                        case PanelType.Titled:
                            this.CustomStyle = "HeaderedPanel";
                            break;
                        case PanelType.Navigation:
                            this.CustomStyle = "Navigation";
                            break;
                        case PanelType.Custom:
                            this.CustomStyle = "Custom";
                            break;
                    }

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value></value>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                UpdateParams();
                base.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

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

        /// <summary>
        /// Shoulds the type of the serialize panel.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ShouldSerializePanelType()
        {
            return PanelType != PanelType.Normal;
        }

        #endregion Properties
	}

	#endregion
}
