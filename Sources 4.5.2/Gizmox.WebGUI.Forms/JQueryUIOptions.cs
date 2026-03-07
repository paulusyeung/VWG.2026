using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;


namespace Gizmox.WebGUI.Forms
{

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class JQueryUIOptions
    {
        private int mintXgrid = 0;
        private int mintYgrid = 0;

        private Component mobjOwner = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="jQueryUIOptions"/> class.
        /// </summary>
        internal JQueryUIOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="jQueryUIOptions"/> class.
        /// </summary>
        /// <param name="intXgrid">The int xgrid.</param>
        /// <param name="intYgrid">The int ygrid.</param>
        public JQueryUIOptions(int intXgrid, int intYgrid)
        {
            this.mintXgrid = intXgrid;
            this.mintYgrid = intYgrid;
        }

        /// <summary>
        /// Gets or sets the xgrid.
        /// </summary>
        /// <value>
        /// The xgrid.
        /// </value>
        [DefaultValue(0)]
        [SRDescription("Gets or sets the Xgrid (Used to when resizing or dragging in snap mode.).")]
        public int Xgrid
        {
            get { return mintXgrid; }
            set { mintXgrid = value; }
        }

        /// <summary>
        /// Gets or sets the ygrid.
        /// </summary>
        /// <value>
        /// The ygrid.
        /// </value>
        [DefaultValue(0)]
        [SRDescription("Gets or sets the Xgrid (Used to when resizing or dragging in snap mode.).")]
        public int Ygrid
        {
            get { return mintYgrid; }
            set { mintYgrid = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        internal Component Owner
        {
            get { return this.mobjOwner; }
            set { this.mobjOwner = value; }
        }

        /// <summary>
        /// Determines whether this instance is default.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </returns>
        internal virtual bool IsDefault()
        {
            return mintXgrid == 0 && mintXgrid == 0;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string strReply = string.Format("{0}|{1}", Xgrid, Ygrid);

            return strReply;
        }

        /// <summary>
        /// To the render string.
        /// </summary>
        /// <returns></returns>
        public virtual string ToRenderString()
        {
            if (this.mintXgrid > 1 || this.mintYgrid > 1)
            {
                return string.Format("{0}|", "grid:[" + this.mintXgrid + "," + this.mintYgrid + "]");
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="strValues">The STR values.</param>
        internal virtual void ConvertFromString(params string[] strValues)
        {
            if (strValues.Length == 2)
            {
                this.Xgrid = int.Parse(strValues[0]);
                this.Ygrid = int.Parse(strValues[1]);
            }
        }



    }

    /// <summary>
    /// Snap Mode for draggable controls.
    /// </summary>
    [Serializable]
    public enum SnapMode
    {
        Both,
        Inner,
        Outer
    }
        
    /// <summary>
    /// Revert mode for draggable controls.
    /// </summary>
    [Serializable]
    public enum RevertMode
    {
        None,
        Always,
        Invalid,
        Valid
    }

    /// <summary>
    /// Snap to mode for draggable controls.
    /// </summary>
    [Serializable]
    public enum SnapTo
    {
        None,
        All,
        Siblings
    }

    /// <summary>
    /// This class represents the abilities of the jquery draggble.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(DraggableOptionsTypeConverter))]
    public class DraggableOptions : JQueryUIOptions
    {
        private bool mblnIsDraggable = true;
        private SnapTo menmSnapTo = SnapTo.None;
        private SnapMode menmSnapMode = SnapMode.Both;
        private int mintSnapTolerance = 20;
        private RevertMode menmRevertMode = RevertMode.None;
        private int mintRevertDuration = 500;
        private bool mblnAllowNegativeAxes = true;


        /// <summary>
        /// Initializes a new instance of the <see cref="DraggableOptions"/> class.
        /// </summary>
        /// <param name="blnIsDraggable">if set to <c>true</c> [BLN is draggable].</param>
        public DraggableOptions(bool blnIsDraggable)
        {
            this.mblnIsDraggable = blnIsDraggable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DraggableOptions" /> class.
        /// </summary>
        /// <param name="blnIsDraggable">if set to <c>true</c> [BLN is draggable].</param>
        /// <param name="enmSnapTo">The enm snap to.</param>
        /// <param name="enmSnapMode">The enm snap mode.</param>
        /// <param name="intSnapTolerance">The int snap tolerance.</param>
        /// <param name="enmRevertMode">The enm revert mode.</param>
        /// <param name="intRevertDuration">Duration of the int revert.</param>
        /// <param name="intXgrid">The int xgrid.</param>
        /// <param name="intYgrid">The int ygrid.</param>
        /// <param name="blnAllowNegativeAxes">if set to <c>true</c> [BLN allow negative values].</param>
        public DraggableOptions(bool blnIsDraggable, SnapTo enmSnapTo, SnapMode enmSnapMode, int intSnapTolerance, RevertMode enmRevertMode, int intRevertDuration, int intXgrid, int intYgrid, bool blnAllowNegativeAxes)
        {
            this.mblnIsDraggable = blnIsDraggable;
            this.menmSnapTo = enmSnapTo;
            this.menmSnapMode = enmSnapMode;
            this.menmRevertMode = enmRevertMode;
            this.mintSnapTolerance = intSnapTolerance;
            this.mintRevertDuration = intRevertDuration;
            this.Xgrid = intXgrid;
            this.Ygrid = intYgrid;
            mblnAllowNegativeAxes = blnAllowNegativeAxes;
        }


        /// <summary>
        /// Determines whether this instance is default.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </returns>
        internal override bool IsDefault()
        {
            return base.IsDefault() && menmSnapTo == Forms.SnapTo.None && SnapMode == Forms.SnapMode.Both && SnapTolerance == 20 && RevertMode == Forms.RevertMode.None && RevertDuration == 500 && AllowNegativeAxes==true;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", (mblnIsDraggable) ? "1" : "0", (int)menmSnapTo, (int)menmSnapMode, Xgrid, Ygrid, mintSnapTolerance, (int)menmRevertMode, mintRevertDuration, mblnAllowNegativeAxes);
        }

        /// <summary>
        /// To the render string.
        /// </summary>
        /// <returns></returns>
        internal string ToRenderString()
        {
            // Will build the draggable parameters based on pairs of key value.
            StringBuilder objStringBuilderOfParams = new StringBuilder();

            // Getting parameters from the base class.
            objStringBuilderOfParams.Append(base.ToRenderString());
            
            // Rendering the snapTo, snap mode siblings gets a special treatment on the server.
            if (menmSnapTo != Forms.SnapTo.None)
            {
                if (menmSnapTo == Forms.SnapTo.Siblings)
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "snap:siblings");
                }
                else
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "snap:true");
                }
            }

            // SnapMode based on the jQuery options.
            if (menmSnapMode != Forms.SnapMode.Both)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "snapMode:\\'" + menmSnapMode.ToString().ToLower() + "\\'");
            }

            // The SnapTolerance in pixels.
            if (mintSnapTolerance != 20)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "snapTolerance:" + mintSnapTolerance.ToString());
            }

            // RevertMode, based on the jQeury options.
            if (menmRevertMode != RevertMode.None)
            {
                if (menmRevertMode != Forms.RevertMode.Always)
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "revert:\\'" + menmRevertMode.ToString().ToLower() + "\\'");
                }
                else
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "revert:true");
                }
            }

            if (mintRevertDuration != 500)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "revertDuration:" + mintRevertDuration.ToString());
            }

            if (!mblnAllowNegativeAxes)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "allowNegativeAxes:false");
            }
            
            // Trimming the last '|' to have a correct number of elements.
            return objStringBuilderOfParams.ToString().TrimEnd('|');
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is draggable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is draggable; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [SRDescription("Gets or sets a value indicating whether this instance is draggable.")]
        public bool IsDraggable
        {
            get
            {
                return mblnIsDraggable;
            }
            set
            {
                this.mblnIsDraggable = value;
            }
        }

        /// <summary>
        /// Whether the element should snap to other elements.
        /// </summary>
        /// <value>
        /// The snap to.
        /// </value>
        [DefaultValue(SnapTo.None)]
        [SRDescription("Whether the element should snap to other elements.")]
        public SnapTo SnapTo
        {
            get
            {
                return menmSnapTo;
            }
            set
            {
                menmSnapTo = value;
            }
        }


        /// <summary>
        /// Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: "inner", "outer", "both", "Grid".
        /// </summary>
        /// <value>
        /// The snap mode.
        /// </value>
        [DefaultValue(SnapMode.Both)]
        [SRDescription("Determines which edges of snap elements the draggable will snap to. Ignored if the SnapTo option is off.. Possible values: \"inner\", \"outer\", \"both\",\"Grid\".")]
        public SnapMode SnapMode
        {
            get { return menmSnapMode; }
            set { menmSnapMode = value; }
        }

        /// <summary>
        /// The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.
        /// </summary>
        /// <value>
        /// The snap tolerance.
        /// </value>
        [DefaultValue(20)]
        [SRDescription("The distance in pixels from the snap element edges at which snapping should occur. Ignored if the SnapTo option is off.")]
        public int SnapTolerance
        {
            get { return mintSnapTolerance; }
            set { mintSnapTolerance = value; }
        }

        /// <summary>
        /// Whether the element should revert to its start position when dragging stops.
        /// </summary>
        /// <value>
        /// The revert mode.
        /// </value>
        [DefaultValue(RevertMode.None)]
        [SRDescription("Whether the element should revert to its start position when dragging stops.")]
        public RevertMode RevertMode
        {
            get { return menmRevertMode; }
            set { menmRevertMode = value; }
        }

        /// <summary>
        /// The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.
        /// </summary>
        /// <value>
        /// The duration of the revert.
        /// </value>
        [DefaultValue(500)]
        [SRDescription("The duration of the revert animation, in milliseconds. Ignored if the RevertMode option is none.")]
        public int RevertDuration
        {
            get { return mintRevertDuration; }
            set { mintRevertDuration = value; }
        }


        /// <summary>
        /// Gets or sets a value indicating whether negative axes values are permitted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow negative axes values]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool AllowNegativeAxes
        {
            get { return mblnAllowNegativeAxes; }
            set { mblnAllowNegativeAxes = value; }
        }
        
    }


    /// <summary>
    /// 
    /// </summary>
    public enum ContainmentMode
    {
        None,
        Parent,
        Form
    }

    /// <summary>
    /// This class represents the abilities of the jquery Resizable.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ResizableOptionsTypeConverter))]
    public class ResizableOptions : JQueryUIOptions
    {
        private bool mblnIsResizable = true;
        private Component[] mobjAlsoResize = new Component[0];
        private bool mblnAnimate = false;
        private int mintAnimateDuration = 500;
        private bool mblnAspectRatio = false;
        private bool mblnAutoHide = false;        
        private ContainmentMode menmContainmentMode = ContainmentMode.None;
        private bool mblnGhost = false;


        /// <summary>
        /// Initializes a new instance of the <see cref="ResizableOptions"/> class.
        /// </summary>
        internal ResizableOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResizableOptions"/> class.
        /// </summary>
        /// <param name="blnIsResizable">if set to <c>true</c> [BLN is Resizable].</param>
        public ResizableOptions(bool blnIsResizable)
        {
            this.mblnIsResizable = blnIsResizable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResizableOptions" /> class.
        /// </summary>
        /// <param name="blnIsResizable">if set to <c>true</c> [BLN is Resizable].</param>
        /// <param name="objAlsoResize">The obj also resize.</param>
        /// <param name="blnAnimate">if set to <c>true</c> [BLN animate].</param>
        /// <param name="intAnimateDuration">Duration of the int animate.</param>
        /// <param name="blnAspectRatio">if set to <c>true</c> [BLN aspect ratio].</param>
        /// <param name="blnAutoHide">if set to <c>true</c> [BLN auto hide].</param>
        /// <param name="enmContainmentMode">The enm containment mode.</param>
        /// <param name="blnGhost">if set to <c>true</c> [BLN ghost].</param>
        /// <param name="intXgrid">The int xgrid.</param>
        /// <param name="intYgrid">The int ygrid.</param>
        public ResizableOptions(bool blnIsResizable, Component[] objAlsoResize, bool blnAnimate, int intAnimateDuration, bool blnAspectRatio, bool blnAutoHide, ContainmentMode enmContainmentMode, bool blnGhost, int intXgrid, int intYgrid)
            : base(intXgrid, intYgrid)
        {
            this.mblnIsResizable = blnIsResizable;
            this.mobjAlsoResize = objAlsoResize;
            this.mblnAnimate = blnAnimate;
            this.mintAnimateDuration = intAnimateDuration;
            this.mblnAspectRatio = blnAspectRatio;
            this.mblnAutoHide = blnAutoHide;
            this.menmContainmentMode = enmContainmentMode;
            this.mblnGhost = blnGhost;          
        }

        /// <summary>
        /// Determines whether this instance is default.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsDefault()
        {
            return base.IsDefault()
                && (mobjAlsoResize == null || mobjAlsoResize.Length == 0)
                && mblnAnimate == false
                && mintAnimateDuration == 500
                && mblnAspectRatio == false
                && mblnAutoHide == false                
                && menmContainmentMode == Forms.ContainmentMode.None
                && mblnGhost == false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string strReply = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                (mblnIsResizable) ? "1" : "0",
                (mblnAnimate) ? "1" : "0",
                mintAnimateDuration,
                (mblnAspectRatio) ? "1" : "0",
                (mblnAutoHide) ? "1" : "0",
                (int)menmContainmentMode,
                (mblnGhost) ? "1" : "0",               
                base.ToString());

            return strReply;
        }

        /// <summary>
        /// To the render string.
        /// </summary>
        /// <returns></returns>
        internal string ToRenderString()
        {
            // Will build the resizable parameters based on pairs of key value.
            StringBuilder objStringBuilderOfParams = new StringBuilder();

            // Getting the base class parameters (common to all jQuery options we supply)
            objStringBuilderOfParams.Append(base.ToRenderString());
            
            // Will render the animation property with additional data if needed.
            if (mblnAnimate)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "animate:true");

                if (mintAnimateDuration != 500)
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "animateDuration:" + mintAnimateDuration);
                }
            }

            // Will turn on aspect ratio.
            if (mblnAspectRatio)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "aspectRatio:true");
            }

            // Will turn on auto hide.
            if (mblnAutoHide)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "autoHide:true");
            }

            // Will turn on ghost display.
            if (mblnGhost)
            {
                objStringBuilderOfParams.AppendFormat("{0}|", "ghost:true");
            }

            // Will define the containment mode, (if Parent is selected, will supply a selector for the parent container.
            if (menmContainmentMode != Forms.ContainmentMode.None)
            {
                if (menmContainmentMode == Forms.ContainmentMode.Form)
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "containment:\\'document\\'");
                }
                else if (menmContainmentMode == Forms.ContainmentMode.Parent)
                {
                    objStringBuilderOfParams.AppendFormat("{0}|", "containment:\\'parent\\'");
                }
            }
            
            // AlsoRezise will collect all the IDs of the components in the array, to build a selector for the also resize option.
            if (mobjAlsoResize != null && mobjAlsoResize.Length > 0)
            {
                objStringBuilderOfParams.Append("alsoResize:\\'");
                bool blnIsFirst = true;

                foreach (Component objComponentToResize in mobjAlsoResize)
                {
                    if (!blnIsFirst)
                    {
                        objStringBuilderOfParams.Append(",");
                    }

                    objStringBuilderOfParams.AppendFormat("#VWG_{0}", objComponentToResize.ID);

                    blnIsFirst = false;
                }

                objStringBuilderOfParams.Append("\\'|");
            }

            return objStringBuilderOfParams.ToString().TrimEnd('|');
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Resizable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is Resizable; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("One or more elements to resize synchronously with the resizable element.")]
        public bool IsResizable
        {
            get
            {
                return mblnIsResizable;
            }
            set
            {
                this.mblnIsResizable = value;
            }
        }

        /// <summary>
        /// One or more elements to resize synchronously with the resizable element.
        /// </summary>
        /// <value>
        /// The also resize.
        /// </value>
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.JQueryUIControlsSelectionsEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        [TypeConverter(typeof(JQueryUIOptionsComponentTypeConverter))]
        [SRDescription("Gets or sets a value indicating whether this instance is Resizable.")]
        public Component[] AlsoResize
        {
            get
            {
                return mobjAlsoResize;
            }
            set
            {
                this.mobjAlsoResize = value;
            }
        }


        /// <summary>
        /// Animates to the final size after resizing.
        /// Due to a known bug in jQeury (http://bugs.jqueryui.com/ticket/7453), this property is hidden at the moment.
        /// </summary>
        /// <value>
        ///   <c>true</c> if animate; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        [SRDescription("Animates to the final size after resizing.")]
        public bool Animate
        {
            get
            {
                return this.mblnAnimate;
            }
            set
            {
                this.mblnAnimate = value;
            }
        }

        /// <summary>
        /// How long to animate when using the animate option.
        /// </summary>
        /// <value>
        /// The duration of the animate.
        /// </value>
        [Browsable(false)]
        [SRDescription("How long to animate when using the animate option.")]
        public int AnimateDuration
        {
            get
            {
                return this.mintAnimateDuration;
            }
            set
            {
                this.mintAnimateDuration = value;
            }
        }

        /// <summary>
        /// Whether the element should be constrained to a specific aspect ratio.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [aspect ratio]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("Whether the element should be constrained to a specific aspect ratio.")]
        public bool AspectRatio
        {
            get
            {
                return this.mblnAspectRatio;
            }
            set
            {
                this.mblnAspectRatio = value;
            }
        }

        /// <summary>
        /// Whether the handles should hide when the user is not hovering over the element.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [auto hide]; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("Whether the handles should hide when the user is not hovering over the element.")]
        public bool AutoHide
        {
            get
            {
                return this.mblnAutoHide;
            }
            set
            {
                this.mblnAutoHide = value;
            }
        }

        /// <summary>
        /// Constrains resizing to within the bounds of the specified element or region.
        /// </summary>
        /// <value>
        /// The containment mode.
        /// </value>
        [SRDescription("Constrains resizing to within the bounds of the specified element or region.")]
        public ContainmentMode ContainmentMode
        {
            get
            {
                return menmContainmentMode;
            }
            set
            {
                this.menmContainmentMode = value;
            }
        }

        /// <summary>
        /// If set to true, a semi-transparent helper element is shown for resizing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if ghost; otherwise, <c>false</c>.
        /// </value>
        [SRDescription("If set to true, a semi-transparent helper element is shown for resizing.")]
        public bool Ghost
        {
            get
            {
                return this.mblnGhost;
            }
            set
            {
                this.mblnGhost = value;
            }
        }

        
        /// <summary>
        /// Converts from string.
        /// </summary>
        /// <param name="strValues">The STR values.</param>
        /// <returns></returns>
        internal void ConvertFromString(string strValue)
        {
            string[] strValues = ((string)strValue).Split('|');
            if (strValues.Length == 9)
            {
                this.IsResizable = (strValues[0] == "1") ? true : false;
                this.Animate = (strValues[1] == "1") ? true : false;
                this.AnimateDuration = int.Parse(strValues[2]);
                this.AspectRatio = (strValues[3] == "1") ? true : false;
                this.AutoHide = (strValues[4] == "1") ? true : false;
                this.ContainmentMode = (ContainmentMode)int.Parse(strValues[5]);
                this.Ghost = (strValues[6] == "1") ? true : false;                
                base.ConvertFromString(strValues[7], strValues[8]);
            }
            else if (strValues.Length == 1)
            {
                this.IsResizable = (strValues[0] == "1") ? true : false;
            }
            else
            {
                this.IsResizable = false;
            }
        }
    }





    /// <summary>
    /// Type converter for the draggable option object.
    /// </summary>
    [Serializable()]
    public class DraggableOptionsTypeConverter : TypeConverter
    {

        /// <summary>
        /// Converts the specified objValue object to an enumeration object.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can convert from] the specified context; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) || destinationType == typeof(bool))
            {
                return true;
            }
            return base.CanConvertFrom(context, destinationType);
        }

        /// <summary>
        /// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
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
                string[] strValues = ((string)value).Split('|');
                if (strValues.Length == 9)
                {
                    // Based on this order (from the tostring) "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", (mblnIsDraggable) ? "1" : "0", menmSnapTo, enmSnapMode, intXgrid, intYgrid, intSnapTolerance, enmRevertMode, intRevertDuration, blnAllowNegativeAxes
                    DraggableOptions objDraggableOptions = new DraggableOptions((strValues[0] == "1") ? true : false);
                    objDraggableOptions.SnapTo = (SnapTo)int.Parse(strValues[1]);
                    objDraggableOptions.SnapMode = (SnapMode)int.Parse(strValues[2]);
                    objDraggableOptions.Xgrid = int.Parse(strValues[3]);
                    objDraggableOptions.Ygrid = int.Parse(strValues[4]);
                    objDraggableOptions.SnapTolerance = int.Parse(strValues[5]);
                    objDraggableOptions.RevertMode = (RevertMode)int.Parse(strValues[6]);
                    objDraggableOptions.RevertDuration = int.Parse(strValues[7]);
                    objDraggableOptions.AllowNegativeAxes = bool.Parse(strValues[8]);

                    return objDraggableOptions;
                }
                else
                {
                    return new DraggableOptions(false);
                }
            }
            if (value is bool)
            {
                return new DraggableOptions((bool)value);
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given objValue object to the specified destination type.
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");

            }
            if (destinationType == typeof(InstanceDescriptor))
            {
                object objInstanceDescriptor = ConvertToInstanceDescriptor(context, value);
                if (objInstanceDescriptor != null)
                {
                    return objInstanceDescriptor;
                }
            }
            else if (destinationType == typeof(string))
            {
                return ConvertToString(context, value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }


        /// <summary>
        /// gives the InstanceDescriptor of the object
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
        {
            DraggableOptions objDraggableOptions = value as DraggableOptions;
            if (objDraggableOptions != null)// && (!objDraggableOptions.IsDefault() || objDraggableOptions.IsDraggable))
            {
                object[] arrArguments = null;
                Type[] arrTypes = null;

                if (objDraggableOptions.IsDefault())
                {
                    arrArguments = new object[] { objDraggableOptions.IsDraggable };
                    arrTypes = new Type[] { objDraggableOptions.IsDraggable.GetType() };
                }
                else
                {
                    arrArguments = new object[] { objDraggableOptions.IsDraggable, objDraggableOptions.SnapTo, objDraggableOptions.SnapMode, objDraggableOptions.SnapTolerance, objDraggableOptions.RevertMode, objDraggableOptions.RevertDuration, objDraggableOptions.Xgrid, objDraggableOptions.Ygrid, objDraggableOptions.AllowNegativeAxes};
                    arrTypes = new Type[] { objDraggableOptions.IsDraggable.GetType(), objDraggableOptions.SnapTo.GetType(), objDraggableOptions.SnapMode.GetType(), objDraggableOptions.SnapTolerance.GetType(), objDraggableOptions.RevertMode.GetType(), objDraggableOptions.RevertDuration.GetType(), objDraggableOptions.Xgrid.GetType(), objDraggableOptions.Ygrid.GetType(), objDraggableOptions.AllowNegativeAxes.GetType() };
                }

                return new InstanceDescriptor(typeof(DraggableOptions).GetConstructor(arrTypes), arrArguments);
            }
            return null;
        }

        /// <summary>
        /// converts the object to string.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private new string ConvertToString(ITypeDescriptorContext objContext, object value)
        {
            DraggableOptions objDraggableOptions = value as DraggableOptions;
            if (objDraggableOptions != null)
            {
                return objDraggableOptions.ToString();
            }
            return "";
        }


        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value);
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

    }




    /// <summary>
    /// Type converter for the draggable option object.
    /// </summary>
    [Serializable()]
    public class ResizableOptionsTypeConverter : TypeConverter
    {
        /// <summary>
        /// Converts the specified objValue object to an enumeration object.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can convert from] the specified context; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) || destinationType == typeof(bool))
            {
                return true;
            }
            return base.CanConvertFrom(context, destinationType);
        }

        /// <summary>
        /// Gets a objValue indicating whether this converter can convert an object to the given destination type using the objContext.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
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
            if (value != null)
            {
                if (value is string)
                {       // Based on this order (from the tostring)  {0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}  (mblnIsResizable) ? "1" : "0", (int)menmResizableMode,  (mblnAnimate) ? "1" : "0", mintAnimateDuration, (mblnAspectRatio) ? "1" : "0",(mblnAutoHide) ? "1" : "0",    (int)menmContainmentMode,(mblnGhost) ? "1" : "0",  mobjMaxWidthAndHeight, mobjMinWidthAndHeight, base.ToString());                   
                    ResizableOptions objResizableOptions = new ResizableOptions();
                    objResizableOptions.ConvertFromString((string)value);

                    return objResizableOptions;
                }
                if (value is bool)
                {
                    return new ResizableOptions((bool)value);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given objValue object to the specified destination type.
        /// </summary>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");

            }
            if (destinationType == typeof(InstanceDescriptor))
            {
                object objInstanceDescriptor = ConvertToInstanceDescriptor(context, value);
                if (objInstanceDescriptor != null)
                {
                    return objInstanceDescriptor;
                }
            }
            else if (destinationType == typeof(string))
            {
                return ConvertToString(context, value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }


        /// <summary>
        /// gives the InstanceDescriptor of the object
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object value)
        {
            ResizableOptions objResizableOptions = value as ResizableOptions;
            if (objResizableOptions != null)
            {
                object[] arrArguments = null;
                Type[] arrTypes = null;

                if (objResizableOptions.IsDefault())
                {
                    arrArguments = new object[] { objResizableOptions.IsResizable };
                    arrTypes = new Type[] { objResizableOptions.IsResizable.GetType() };
                }
                else
                {
                    arrArguments = new object[] { objResizableOptions.IsResizable, objResizableOptions.AlsoResize, objResizableOptions.Animate, objResizableOptions.AnimateDuration, objResizableOptions.AspectRatio, objResizableOptions.AutoHide, objResizableOptions.ContainmentMode, objResizableOptions.Ghost, objResizableOptions.Xgrid, objResizableOptions.Ygrid };
                    arrTypes = new Type[] { objResizableOptions.IsResizable.GetType(), objResizableOptions.AlsoResize.GetType(), objResizableOptions.Animate.GetType(), objResizableOptions.AnimateDuration.GetType(), objResizableOptions.AspectRatio.GetType(), objResizableOptions.AutoHide.GetType(), objResizableOptions.ContainmentMode.GetType(), objResizableOptions.Ghost.GetType(), objResizableOptions.Xgrid.GetType(), objResizableOptions.Ygrid.GetType() };
                }

                return new InstanceDescriptor(typeof(ResizableOptions).GetConstructor(arrTypes), arrArguments);
            }
            return null;
        }

        /// <summary>
        /// converts the object to string.
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        private new string ConvertToString(ITypeDescriptorContext objContext, object value)
        {
            ResizableOptions objResizableOptions = value as ResizableOptions;
            if (objResizableOptions != null)
            {
                return objResizableOptions.ToString();
            }
            return "";
        }


        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value, attributes);
        }
               
        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }



    /// <summary>
    /// Used for the components array in this class to avoid the expand button in the grid.
    /// </summary>
    public class JQueryUIOptionsComponentTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
