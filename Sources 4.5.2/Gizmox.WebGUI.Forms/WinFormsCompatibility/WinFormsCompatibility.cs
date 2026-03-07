using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class WinFormsCompatibility
    {
        /// <summary>
        /// The store dictionary for WinFormsCompatibility features.
        /// </summary>
        private Dictionary<string, bool> mobjFeatureIsOnIndexByFeatureName;

        /// <summary>
        /// Represents the method that will handle the WinFormsCompatibility option changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="WinFormsCompatibilityEventArgs"/> instance containing the event data.</param>
        public delegate void WinFormsCompatibilityEventHandler(object sender, WinFormsCompatibilityEventArgs e);

        /// <summary>
        /// Called when option value is changed.
        /// </summary>
        public event WinFormsCompatibilityEventHandler OptionValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinFormsCompatibility"/> class.
        /// </summary>
        public WinFormsCompatibility()
        {
            mobjFeatureIsOnIndexByFeatureName = new Dictionary<string, bool>();
        }

        /// <summary>
        /// Gets the feature.
        /// </summary>
        /// <param name="strFeatureName">Name of the string feature.</param>
        /// <returns></returns>
        protected WinFormsCompatibilityStates GetFeature(string strFeatureName)
        {
            bool blnFeatureState = false;

            if (mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out blnFeatureState))
            {
                return blnFeatureState ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
            }
            else
            {
                return WinFormsCompatibilityStates.Default;
            }
        }

        /// <summary>
        /// Gets the feature value from configuration.
        /// </summary>
        /// <param name="strFeatureName">Name of the string feature.</param>
        /// <returns></returns>
        private bool GetFeatureValueFromConfiguration(string strFeatureName)
        {
            // If current vwg context and its config are initialized.
            if (VWGContext.Current != null && VWGContext.Current.Config != null)
            {
                return VWGContext.Current.Config.IsWinFormsCompatibilityOptionOn(strFeatureName);
            }
            return false;
        }

        /// <summary>
        /// Gets the feature bool value.
        /// </summary>
        /// <param name="strFeatureName">Name of the string feature.</param>
        /// <returns></returns>
        protected bool GetFeatureBoolValue(string strFeatureName)
        {
            bool blnFeatureState = false;

            if (!mobjFeatureIsOnIndexByFeatureName.TryGetValue(strFeatureName, out blnFeatureState))
            {
                blnFeatureState = GetFeatureValueFromConfiguration(strFeatureName);
            }

            return blnFeatureState;
        }

        /// <summary>
        /// Sets the feature.
        /// </summary>
        /// <param name="strFeatureName">Name of the string feature.</param>
        /// <param name="blnState">if set to <c>true</c> [BLN state].</param>
        protected void SetFeature(string strFeatureName, WinFormsCompatibilityStates enmState)
        {
            // Preserve current boolean value of feature.
            bool blnCurrentFeatureBoolValue = GetFeatureBoolValue(strFeatureName);

            // Perform feature setting.
            if (enmState == WinFormsCompatibilityStates.Default)
            {
                mobjFeatureIsOnIndexByFeatureName.Remove(strFeatureName);
            }
            else
            {
                mobjFeatureIsOnIndexByFeatureName[strFeatureName] = enmState == WinFormsCompatibilityStates.True;
            }

            // If boolean feature value is changed.
            if (blnCurrentFeatureBoolValue != GetFeatureBoolValue(strFeatureName))
            {
                OnOptionValueChanged(strFeatureName);
            }
        }

        /// <summary>
        /// Called when option value is changed.
        /// </summary>
        private void OnOptionValueChanged(string strChangedOptionName)
        {
            if (OptionValueChanged != null)
            {
                OptionValueChanged(this, new WinFormsCompatibilityEventArgs(strChangedOptionName));
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// WinFormsCompatibility event arguments.
    /// </summary>
    [Serializable()]
    public class WinFormsCompatibilityEventArgs : EventArgs
    {
        #region C'Tor / D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="WinFormsCompatibilityEventArgs"/> class.
        /// </summary>
        /// <param name="strChangedOptionName">Name of the changed option.</param>
        public WinFormsCompatibilityEventArgs(string strChangedOptionName)
        {
            this.mstrChangedOptionName = strChangedOptionName;
        }

        #endregion C'Tor / D'Tor

        #region Properties

        /// <summary>
        /// Gets or sets the name of the changed option.
        /// </summary>
        /// <value>
        /// The name of the changed option.
        /// </value>
        public string ChangedOptionName
        {
            get
            {
                return this.mstrChangedOptionName;
            }
            set
            {
                this.mstrChangedOptionName = value;
            }
        }

        #endregion Properties

        #region Class Members

        /// <summary>
        /// The changed option name
        /// </summary>
        private string mstrChangedOptionName;

        #endregion Class Members
    }
}
