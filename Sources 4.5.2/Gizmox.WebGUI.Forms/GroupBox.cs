#region Using

using System;
using System.Xml;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region GroupBox Class

    /// <summary>
    ///  Represents a Panel control.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(GroupBox), "GroupBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(GroupBox), "GroupBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.GroupBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.GroupBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.GroupBox)]
    [Skin(typeof(GroupBoxSkin))]
    public class GroupBox : Control
    {
        #region C'Tor / D'Tor

        /// <summary>
        /// Creates a new <see cref="Panel"/> instance.
        /// </summary>
        public GroupBox()
        {
            base.SetStyle(ControlStyles.ContainerControl, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, this.OwnerDraw);
            base.SetStyle(ControlStyles.Selectable, false);
            this.TabStop = false;
        }


        #endregion C'Tor / D'Tor

        #region Methods

        /// <summary>
        /// Gets a value indicating whether is owner draw.
        /// </summary>
        /// <value><c>true</c> if owner draw; otherwise, <c>false</c>.</value>
        private bool OwnerDraw
        {
            get
            {
                return (this.FlatStyle != FlatStyle.System);
            }
        }


        /// <summary>
        /// Gets the preferred size or the client minimum size.
        /// </summary>
        /// <param name="objProposedSize">The proposed size.</param>
        /// <param name="blnIsClientMinimumSize">if set to <c>true</c> [BLN is client minimum size].</param>
        /// <returns></returns>
        protected override Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
        {
            Size objPreferredSize = base.GetPreferredSize(objProposedSize,blnIsClientMinimumSize);

            if (this.AutoSize)
            {
                //Get the skin
                GroupBoxSkin objGroupBoxSkin = this.Skin as GroupBoxSkin;

                //If we got a skin
                if (objGroupBoxSkin != null)
                {
                    //Get the padding value
                    PaddingValue objPaddingValue = objGroupBoxSkin.Padding;
                    if (objPaddingValue != null)
                    {
                        //Add the padding size
                        objPreferredSize.Width += objPaddingValue.Horizontal;
                        objPreferredSize.Height += objPaddingValue.Vertical;
                    }

                    // Add frame sizes
                    objPreferredSize.Width += objGroupBoxSkin.LeftFrameWidth;
                    objPreferredSize.Width += objGroupBoxSkin.RightFrameWidth;

                    objPreferredSize.Height += objGroupBoxSkin.TopFrameHeight;
                    objPreferredSize.Height += objGroupBoxSkin.BottomFrameHeight;
                }
            }

            return objPreferredSize;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // add attributes to control element
            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);
        }

        /// <summary>
        /// An abstract param attribute rendering
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            objWriter.WriteAttributeText(WGAttributes.Text, Text, TextFilter.CarriageReturn | TextFilter.NewLine);
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new GroupBoxRenderer(this);
        }


        #endregion Methods

        #region Properties

        /// <summary>
        /// Indicates if to render padding attribute
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
        {
            return PaddingValue.Empty != objPadding;
        }

        /// <summary>
        /// Gets or sets a value indicating whether tab stop is enabled.
        /// </summary>
        /// <value><c>true</c> if tab stop is enabled; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
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
        /// Gets the control contained area offset.
        /// </summary>
        protected override PaddingValue ContainedAreaOffset
        {
            get
            {
                GroupBoxSkin objGroupBoxSkin = SkinFactory.GetSkin(this) as GroupBoxSkin;
                if (objGroupBoxSkin != null)
                {
                    Padding objFramePadding = new Padding();

                    objFramePadding.Bottom = objGroupBoxSkin.BottomFrameHeight;
                    objFramePadding.Top = objGroupBoxSkin.TopFrameHeight;
                    objFramePadding.Left = objGroupBoxSkin.LeftFrameWidth;
                    objFramePadding.Right = objGroupBoxSkin.RightFrameWidth;

                    return new PaddingValue(objFramePadding + base.ContainedAreaOffset);
                }

                return base.ContainedAreaOffset;

            }
        }

        
        /// <summary>
        /// Gets or sets the flat style.
        /// </summary>
        /// <value>The flat style.</value>
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Flat;
            }
            set
            {
            }
        }


        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 100);
            }
        }

        #endregion Properties

    }

    #endregion GroupBox Class


    #region GroupBoxRenderer Class

    /// <summary>
    /// Provides support for rendering a groupbox control  
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class GroupBoxRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBoxRenderer"/> class.
        /// </summary>
        /// <param name="objGroupBox">The groupbox control.</param>
        public GroupBoxRenderer(GroupBox objGroupBox)
            : base(objGroupBox)
        {
        }

        /// <summary>
        /// Renders the border.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
        {

        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            RenderControls(objContext, objGraphics);
        }


    }

    #endregion

}
