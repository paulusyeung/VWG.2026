using Gizmox.WebGUI.Forms.Skins;
using System;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class CheckBoxSwitchVisualTemplateSkin : CheckBoxSkin
    {
        private void InitializeComponent()
        {
        }

        /// <summary>
        /// Gets or sets the checkbox wrapper style.
        /// </summary>
        /// <value>
        /// The check box wrapper style.
        /// </value>
        public virtual StyleValue CheckBoxWrapperStyle
        {
            get
            {
                return new StyleValue(this, "CheckBoxWrapperStyle");
            }
            set
            {
                this.SetValue("CheckBoxWrapperStyle", value);
            }
        }

        /// <summary>
        /// Resets the checkbox wrapper style.
        /// </summary>
        internal void ResetCheckBoxWrapperStyle()
        {
            this.Reset("CheckBoxWrapperStyle");
        }

        /// <summary>
        /// Gets or sets the checkbox state label style.
        /// </summary>
        /// <value>
        /// The check box state label style.
        /// </value>
        public virtual StyleValue CheckBoxStateLabelStyle
        {
            get
            {
                return new StyleValue(this, "CheckBoxStateLabelStyle");
            }
            set
            {
                this.SetValue("CheckBoxStateLabelStyle", value);
            }
        }

        /// <summary>
        /// Resets the checkbox state label style.
        /// </summary>
        internal void ResetCheckBoxStateLabelStyle()
        {
            this.Reset("CheckBoxStateLabelStyle");
        }

        /// <summary>
        /// Gets or sets the checkbox state label before style.
        /// </summary>
        /// <value>
        /// The checkbox state label before style.
        /// </value>
        public virtual StyleValue CheckBoxStateLabelBeforeStyle
        {
            get
            {
                return new StyleValue(this, "CheckBoxStateLabelBeforeStyle");
            }
            set
            {
                this.SetValue("CheckBoxStateLabelBeforeStyle", value);
            }
        }

        /// <summary>
        /// Resets the checkbox state label before style.
        /// </summary>
        internal void ResetCheckBoxStateLabelBeforeStyle()
        {
            this.Reset("CheckBoxStateLabelBeforeStyle");
        }

        /// <summary>
        /// Gets or sets the checkbox state label after style.
        /// </summary>
        /// <value>
        /// The checkbox state label after style.
        /// </value>
        public virtual StyleValue CheckBoxStateLabelAfterStyle
        {
            get
            {
                return new StyleValue(this, "CheckBoxStateLabelAfterStyle");
            }
            set
            {
                this.SetValue("CheckBoxStateLabelAfterStyle", value);
            }
        }

        /// <summary>
        /// Resets the checkbox state label after style.
        /// </summary>
        internal void ResetCheckBoxStateLabelAfterStyle()
        {
            this.Reset("CheckBoxStateLabelAfterStyle");
        }

        /// <summary>
        /// Gets or sets the checkbox switch style.
        /// </summary>
        /// <value>
        /// The checkbox switch style.
        /// </value>
        public virtual StyleValue CheckBoxSwitchStyle
        {
            get
            {
                return new StyleValue(this, "CheckBoxSwitchStyle");
            }
            set
            {
                this.SetValue("CheckBoxSwitchStyle", value);
            }
        }

        /// <summary>
        /// Resets the checkbox switch style.
        /// </summary>
        internal void ResetCheckBoxSwitchStyle()
        {
            this.Reset("CheckBoxSwitchStyle");
        }

        /// <summary>
        /// Gets a value indicating whether [rounded switch].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [rounded switch]; otherwise, <c>false</c>.
        /// </value>
        public bool RoundedSwitch
        {
            get
            {
                return this.GetValue<bool>("RoundedSwitch", true);
            }
            set
            {
                this.SetValue("RoundedSwitch", value);
            }
        }

        /// <summary>
        /// Resets the rounded switch.
        /// </summary>
        internal void ResetRoundedSwitch()
        {
            this.Reset("RoundedSwitch");
        }

        /// <summary>
        /// Gets a value indicating whether [use animation].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use animation]; otherwise, <c>false</c>.
        /// </value>
        public bool UseAnimation
        {
            get
            {
                return this.GetValue<bool>("UseAnimation", true);
            }
            set
            {
                this.SetValue("UseAnimation", value);
            }
        }

        /// <summary>
        /// Resets the use animation.
        /// </summary>
        internal void ResetUseAnimation()
        {
            this.Reset("UseAnimation");
        }

        /// <summary>
        /// Gets the switch width percentage.
        /// </summary>
        /// <value>
        /// The switch width percentage.
        /// </value>
        public int SwitchWidthPercentage
        {
            get
            {
                return this.GetValue<int>("SwitchWidthPercentage", 0);
            }
            set
            {
                this.SetValue("SwitchWidthPercentage", value);
            }
        }

        /// <summary>
        /// Resets the switch width percentage.
        /// </summary>
        internal void ResetSwitchWidthPercentage()
        {
            this.Reset("SwitchWidthPercentage");
        }
    }
}