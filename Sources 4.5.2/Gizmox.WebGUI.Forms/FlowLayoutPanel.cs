using System;
using System.Xml;
using System.ComponentModel;
using System.Drawing;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;

namespace Gizmox.WebGUI.Forms
{

	/// <summary>
    /// Defines constants that specify the direction in which consecutive user interface (UI) elements are placed in a linear layout container.
	/// </summary>
	
	public enum FlowDirection
	{
		/// <summary>
        /// Elements flow from the left edge of the design surface to the right.
		/// </summary>
		LeftToRight = 1,

		/// <summary>
        /// Elements flow from the top of the design surface to the bottom.
		/// </summary>
		TopDown = 2,

		/// <summary>
        /// Elements flow from the right edge of the design surface to the left.
		/// </summary>
		RightToLeft = 4,

		/// <summary>
        /// Elements flow from the bottom of the design surface to the top.
		/// </summary>
		BottomUp = 8,
	}
    
	/// <summary>
    /// Represents a panel that dynamically lays out its contents horizontally or vertically.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(FlowLayoutPanel), "FlowLayoutPanel_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(FlowLayoutPanel), "FlowLayoutPanel.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.FlowLayoutPanelController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.FlowLayoutPanelController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [ToolboxItemCategory("Containers")]
    [MetadataTag(WGTags.FlowLayoutPanel)]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.FlowLayoutPanelSkin)), Serializable()]
    [ProxyComponent(typeof(ProxyFlowLayoutPanel))]
	public class FlowLayoutPanel : Panel
    {
        /// <summary>
        /// Provides a property reference to WrapContents property.
        /// </summary>
        private static SerializableProperty WrapContentsProperty = SerializableProperty.Register("WrapContents", typeof(bool), typeof(FlowLayoutPanel), new SerializablePropertyMetadata(true));
		

        /// <summary>
        /// Provides a property reference to FlowDirection property.
        /// </summary>
        private static SerializableProperty FlowDirectionProperty = SerializableProperty.Register("FlowDirection", typeof(FlowDirection), typeof(FlowLayoutPanel), new SerializablePropertyMetadata(FlowDirection.LeftToRight));

		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> class.
		/// </summary>
        public FlowLayoutPanel()
        {

        }

        /// <summary>
        /// Layout the internal controls to reflect parent changes
        /// </summary>
        /// <param name="objEventArgs">The layout arguments.</param>
        /// <param name="objNewSize">The new parent size.</param>
        /// <param name="objOldSize">The old parent size.</param>
        protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
        {
            // We have a diffrent layout schema
        }

        /// <summary>
        /// Gets the preferred size core.
        /// </summary>
        /// <param name="objProposedSize">The size proposed.</param>
        /// <returns></returns>
        public override Size GetPreferredSize(Size objProposedSize)
        {
            // Define size restrictions
            Size objRestrictedSize = new Size(this.Width, this.Height);
            if (this.AutoSize)
            {
                switch (this.Dock)
                {
                    case DockStyle.None:
                        // No restrictions
                        objRestrictedSize = new Size(int.MaxValue, int.MaxValue);
                        break;
                    case DockStyle.Top:
                    case DockStyle.Bottom:
                        // Restricted width, unlimited height
                        objRestrictedSize = new Size(this.Width, int.MaxValue);
                        break;
                    case DockStyle.Left:
                    case DockStyle.Right:
                        // Unlimited width, restricted height
                        objRestrictedSize = new Size(int.MaxValue, this.Height);
                        break;
                    case DockStyle.Fill:
                        // Restricted width, restricted height
                        objRestrictedSize = new Size(this.Width, this.Height);
                        break;
                }

                // Max width and height values may be restrictive. Never more restrictive than current size though.
                if (this.MaximumSize.Width > 0 && objRestrictedSize.Width > this.MaximumSize.Width)
                    objRestrictedSize.Width = Math.Max(this.MaximumSize.Width, this.Width);
                if (this.MaximumSize.Height > 0 && objRestrictedSize.Height > this.MaximumSize.Height)
                    objRestrictedSize.Height = Math.Max(this.MaximumSize.Height, this.Height);
            }

            // 'Position' of next control during size calculations
            Point objCurrentPosition = new Point(0, 0);

            // Declare preffered sizes.
            int intPreferredWidth = 0;
            int intPreferredHeight = 0;

            // Get the flow direction of the current control
            FlowDirection enmFlowDirection = this.FlowDirection;
           
            // Loop all controls
            foreach (Control objControl in this.Controls)
            {
                if (objControl.Visible)
                {
                    // Get the control margin
                    Padding objMargin = objControl.Margin;

                    // Swithc the flow direction
                    switch (enmFlowDirection)
                    {
                        case FlowDirection.BottomUp:
                        case FlowDirection.TopDown:
                            if (objCurrentPosition.Y == 0)
                            {
                                // First control being measured is positioned, no matter what
                                objCurrentPosition.Y = objControl.Height + objMargin.Vertical;
                                intPreferredHeight = objControl.Height + objMargin.Vertical;
                                intPreferredWidth = objControl.Width + objMargin.Horizontal;
                            }
                            else if ((objCurrentPosition.Y + objControl.Height + objMargin.Vertical) > objRestrictedSize.Height)
                            {
                                // If exceeding height restriction, go to next 'column' and position control there
                                objCurrentPosition.X = intPreferredWidth;
                                objCurrentPosition.Y = objControl.Height + objMargin.Vertical;

                                // New preferred height will be same, or larger if single control exceeds current height
                                intPreferredHeight = Math.Max(intPreferredHeight, objControl.Height + objMargin.Vertical);

                                // New preferred width will be current preferred width, plus new control's width (advanced to next column)
                                intPreferredWidth += objControl.Width + objMargin.Horizontal;
                            }
                            else
                            {
                                // Next control fits within height boundaries
                                objCurrentPosition.Y += objControl.Height + objMargin.Vertical;
                                intPreferredHeight = Math.Max(intPreferredHeight, objCurrentPosition.Y);
                            }
                            break;
                        case FlowDirection.LeftToRight:
                        case FlowDirection.RightToLeft:
                            if (objCurrentPosition.X == 0)
                            {
                                // First control being measured is positioned, no matter what
                                objCurrentPosition.X = objControl.Width + objMargin.Horizontal;
                                intPreferredHeight = objControl.Height + objMargin.Vertical;
                                intPreferredWidth = objControl.Width + objMargin.Horizontal;
                            }
                            else if ((objCurrentPosition.X + objControl.Width + objMargin.Horizontal) > objRestrictedSize.Width)
                            {
                                // If exceeding width restriction, go to next 'row' and position control there
                                objCurrentPosition.X = objControl.Width + objMargin.Horizontal;
                                objCurrentPosition.Y = intPreferredHeight;

                                // New preferred height will be current preferred height, plus new control's height (advanced to next row)
                                intPreferredHeight += objControl.Height + objMargin.Vertical;

                                // New preferred width will be same, or larger if single control exceeds current width
                                intPreferredWidth = Math.Max(intPreferredWidth, objControl.Width + objMargin.Horizontal);
                            }
                            else
                            {
                                // Next control fits within width boundaries
                                objCurrentPosition.X += objControl.Width + objMargin.Horizontal;
                                intPreferredWidth = Math.Max(intPreferredHeight, objCurrentPosition.X);
                            }
                            break;
                    }
                }
            }

            // Get the current control padding
            Padding objPadding = this.Padding;

            // Create a preferred size.
            Size objPreferredSize = new Size(intPreferredWidth + objPadding.Horizontal, intPreferredHeight + objPadding.Vertical);

            // Return preffered size.
            return objPreferredSize;
        }

        /// <summary>
        /// Gets a value indicating whether to reverse control rendering.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
        /// </value>
        protected override bool ReverseControls
        {
            get
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
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // Loop all child controls
            if (this.ReverseControls)
            {
                for (int intIndex = 0; intIndex < Controls.Count; intIndex++)
                {
                    Control objControl = this.Controls[intIndex];
                    if (objControl != null)
                    {
                        objControl.RenderControl(objContext, objWriter, lngRequestID);
                    }
                }
            }
            else
            {
                for (int intIndex = Controls.Count - 1; intIndex > -1; intIndex--)
                {
                    Control objControl = this.Controls[intIndex];
                    if (objControl != null)
                    {
                        objControl.RenderControl(objContext, objWriter, lngRequestID);
                    }
                }
            }
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
            // Setting the left and right attributes.
            string strLeft = objContext.ShouldApplyMirroring ? "right" : "left";
            string strRight = objContext.ShouldApplyMirroring ? "left" : "right";

            // Rendering the WrapContents property.
            if (this.WrapContents)
            {
                objWriter.WriteAttributeString(WGAttributes.WrapContents, "1");
            }

            // Rendering the FlowDirection property.
            objWriter.WriteAttributeString(WGAttributes.FlowDirection, Convert.ToInt32(this.FlowDirection).ToString());

            if (((int)(this.FlowDirection) & ((int)FlowDirection.RightToLeft)) > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.HorizontalAlignment, strRight);
            }
            else
            {
                objWriter.WriteAttributeString(WGAttributes.HorizontalAlignment, strLeft);
            }

            // Rendering alignments.
            if (((int)(this.FlowDirection) & ((int)FlowDirection.BottomUp)) > 0)
			{
                objWriter.WriteAttributeString(WGAttributes.VerticalAlignment, "bottom");
			}
			else
			{
                objWriter.WriteAttributeString(WGAttributes.VerticalAlignment, "top");
			}

			base.RenderAttributes (objContext, objWriter);
		}

        /// <summary>
        /// Sets the minimum size of the client.
        /// </summary>
        /// <param name="objProposedSize">Proposed size.</param>
        protected override void SetMinimumClientSize(Size objProposedSize)
        {
        }

        /// <summary>
        /// Gets a value indicating whether [use minimum client size].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use minimum client size]; otherwise, <c>false</c>.
        /// </value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        protected override bool ShouldRenderMinimumClientSize
        {
            get
            {
                return false;
            }
        }

		/// <summary>
        /// Gets or sets a value indicating the flow direction of the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control.
		/// </summary>
        ///	<returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlowDirection"></see> values indicating the direction of consecutive placement of controls in the panel. The default is <see cref="F:Gizmox.WebGUI.Forms.FlowDirection.LeftToRight"></see>.</returns>
        [DefaultValue(FlowDirection.LeftToRight), SRCategory("CatLayout"), Localizable(true), SRDescription("FlowPanelFlowDirectionDescr")]
        public FlowDirection FlowDirection
        {            
            get
            {
                return this.GetValue<FlowDirection>(FlowLayoutPanel.FlowDirectionProperty);
            }
            set
            {
                // Set value and update control if value changed
                if (this.SetValue<FlowDirection>(FlowLayoutPanel.FlowDirectionProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.Update();

                    // Raise the window state changed
                    FireObservableItemPropertyChanged("FlowDirection");
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support child margins].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [support child margins]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportChildMargins
        {
            get
            {
                return true;
            }
        }

		/// <summary>
        /// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.FlowLayoutPanel"></see> control should wrap its contents or let the contents be clipped.
		/// </summary>
		///	<returns>true if the contents should be wrapped; otherwise, false. The default is true.</returns>
        ///	        
        [DefaultValue(true)]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always)]
        public bool WrapContents
        {
            get
            {
                // Getting the value
                return this.GetValue<bool>(FlowLayoutPanel.WrapContentsProperty);
            }
            set
            {
                // If the value has changed
                if(this.SetValue<bool>(FlowLayoutPanel.WrapContentsProperty, value))
                {
                    // Invalidate layout.
                    this.InvalidateLayout(new LayoutEventArgs(false, true, true));

                    this.FireObservableItemPropertyChanged("WrapContents");
                    this.Update();
                }
            }
        }
    }


}

