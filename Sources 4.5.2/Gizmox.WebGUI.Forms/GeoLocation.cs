using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
    #region Delegates

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.GeographicLocationChangedEventArgs"/> instance containing the event data.</param>
    public delegate void GeographicLocationChangedEventHandler(object sender, GeographicLocationChangedEventArgs e);

    #endregion

    #region GeoLocation Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class GeoLocation
    {
		#region Fields (3) 

        public static GeoLocation Empty = new GeoLocation(0, 0);
        private double mdblLatitude = 0;
        private double mdblLongitude = 0;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocation"/> class.
        /// </summary>
        /// <param name="dblLatitude">The DBL latitude.</param>
        /// <param name="dblLongitude">The DBL longitude.</param>
        public GeoLocation(double dblLatitude, double dblLongitude)
        {
            mdblLatitude = dblLatitude;
            mdblLongitude = dblLongitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocation"/> class.
        /// </summary>
        public GeoLocation()
        {
        }

		#endregion Constructors 

		#region Properties (2) 

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude
        {
            get
            {
                return mdblLatitude;
            }
            set
            {
                mdblLatitude = value;
            }
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude
        {
            get
            {
                return mdblLongitude;
            }
            set
            {
                mdblLongitude = value;
            }
        }

		#endregion Properties 
    } 

    #endregion

    #region GeoLocationChangedEventArgs Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class GeographicLocationChangedEventArgs : EventArgs
    {
		#region Fields (1) 

        GeoLocation mobjLocation = GeoLocation.Empty;

		#endregion Fields 

		#region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GeographicLocationChangedEventArgs"/> class.
        /// </summary>
        /// <param name="objGeoPosition">The obj geo position.</param>
        public GeographicLocationChangedEventArgs(GeoLocation objGeoPosition)
        {
            mobjLocation = objGeoPosition;
        }

		#endregion Constructors 

		#region Properties (1) 

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public GeoLocation Location
        {
            get
            {
                return mobjLocation;
            }
            set
            {
                mobjLocation = value;
            }
        }

		#endregion Properties 
    } 

    #endregion

    #region GeoLocationData Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [Description("A data which defines the geographic location services.")]
    [TypeConverterAttribute(typeof(GeoLocationDataTypeConverter))]
    [ToolboxItem(false), DesignTimeVisible(false)]
    public class GeoLocationData : ComponentBase
    {
        #region Events

        /// <summary>
        /// Occurs when [geo location data changed].
        /// </summary>
        internal event EventHandler GeoLocationDataChanged; 

        #endregion

		#region Fields (5) 

        public static readonly GeoLocationData Empty = new GeoLocationData(false, false, null, null);
        private bool mblnRepeatCheck = false;
        private bool mblnEnableHighAccuracy = false;
        private double? mdblMaximumAge = null;
        private double? mdblTimeout = null;

		#endregion Fields 

		#region Constructors (2) 

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocationData"/> class.
        /// </summary>
        /// <param name="blnRepeatCheck">if set to <c>true</c> [BLN repeat check].</param>
        /// <param name="blnEnableHighAccuracy">if set to <c>true</c> [BLN enable high accuracy].</param>
        /// <param name="dblMaximumAge">The DBL maximum age.</param>
        /// <param name="dblTimeout">The DBL timeout.</param>
        public GeoLocationData(bool blnRepeatCheck, bool blnEnableHighAccuracy, double? dblMaximumAge, double? dblTimeout) 
        {
            mblnRepeatCheck = blnRepeatCheck;
            mblnEnableHighAccuracy = blnEnableHighAccuracy;
            mdblMaximumAge = dblMaximumAge;
            mdblTimeout = dblTimeout;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocationData"/> class.
        /// </summary>
        public GeoLocationData()
        {
        }

		#endregion Constructors 

		#region Properties (5) 

        /// <summary>
        /// Gets or sets a value indicating whether [repeat check].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [repeat check]; otherwise, <c>false</c>.
        /// </value>
        [Description("Deifines whether to repeat location changed event."), DefaultValue(false), RefreshProperties(RefreshProperties.All)]
        public bool RepeatCheck
        {
            get
            {
                return mblnRepeatCheck;
            }
            set
            {
                if (mblnRepeatCheck != value)
                {
                    mblnRepeatCheck = value;

                    this.OnGeoLocationDataChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable high accuracy].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable high accuracy]; otherwise, <c>false</c>.
        /// </value>
        [Description("Deifines whether the geo-location will be enabled with high accuracy."), RefreshProperties(RefreshProperties.All), DefaultValue(false)]
        public bool EnableHighAccuracy
        {
            get
            {
                return mblnEnableHighAccuracy;
            }
            set
            {
                if (mblnEnableHighAccuracy != value)
                {
                    mblnEnableHighAccuracy = value;

                    this.OnGeoLocationDataChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum age.
        /// </summary>
        /// <value>
        /// The maximum age.
        /// </value>
        [Description("Deifines the geo-location positions maximum age (in milliseconds)."), RefreshProperties(RefreshProperties.All), DefaultValue(null)]
        public double? MaximumAge
        {
            get
            {
                if (mdblMaximumAge != null && mdblMaximumAge < 0)
                {
                    return 0;
                }
                return mdblMaximumAge;
            }
            set
            {
                if (mdblMaximumAge != value)
                {
                    mdblMaximumAge = value;

                    this.OnGeoLocationDataChanged();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports geo location].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [supports geo location]; otherwise, <c>false</c>.
        /// </value>
        private static bool SupportsGeoLocation
        {
            get
            {
                IContextParams objContextParams = VWGContext.Current as IContextParams;
                if (objContextParams != null)
                {
                    return (objContextParams.MISCBrowserCapabilities & MISCBrowserCapabilities.Geolocation) == MISCBrowserCapabilities.Geolocation;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        [Description("Deifines the geo-location timeout for a single position request (in milliseconds)."), RefreshProperties(RefreshProperties.All), DefaultValue(null)]
        public double? Timeout
        {
            get
            {
                if (mdblTimeout != null && mdblTimeout < 0)
                {
                    return 0;
                }
                return mdblTimeout;
            }
            set
            {
                if (mdblTimeout != value)
                {
                    mdblTimeout = value;

                    this.OnGeoLocationDataChanged();
                }
            }
        }

		#endregion Properties 

		#region Methods (4) 

		// Private Methods (4) 

        /// <summary>
        /// Called when [geo location data changed].
        /// </summary>
        private void OnGeoLocationDataChanged()
        {
            if (GeoLocationDataChanged != null)
            {
                GeoLocationDataChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Resets the repeat check.
        /// </summary>
        private void ResetRepeatCheck()
        {
            this.RepeatCheck = Empty.RepeatCheck;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder objBuilder = new StringBuilder();

            if (this.RepeatCheck)
            {
                this.AppendKey(objBuilder, "RepeatCheck");
            }

            if (this.EnableHighAccuracy)
            {
                this.AppendKey(objBuilder, "EnableHighAccuracy");
            }

            if (this.MaximumAge != null)
            {
                this.AppendKey(objBuilder, string.Format("MaximumAge({0})", this.MaximumAge));
            }

            if (this.Timeout != null)
            {
                this.AppendKey(objBuilder, string.Format("Timeout({0})", this.Timeout));
            }

            return objBuilder.ToString();
        }

        /// <summary>
        /// Appends the key.
        /// </summary>
        /// <param name="objBuilder">The obj builder.</param>
        /// <param name="strKey">The STR key.</param>
        private void AppendKey(StringBuilder objBuilder, string strKey)
        {
            if (objBuilder.Length > 0)
            {
                objBuilder.Append(",");
            }

            objBuilder.Append(strKey);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            GeoLocationData objGeoLocationData = obj as GeoLocationData;
            if (objGeoLocationData != null)
            {
                return  this.RepeatCheck == objGeoLocationData.RepeatCheck && this.EnableHighAccuracy == objGeoLocationData.EnableHighAccuracy && 
                        this.MaximumAge == objGeoLocationData.MaximumAge && this.Timeout == objGeoLocationData.Timeout;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Resets the enable high accuracy.
        /// </summary>
        private void ResetEnableHighAccuracy()
        {
            this.EnableHighAccuracy = Empty.EnableHighAccuracy;
        }

        /// <summary>
        /// Resets the maximum age.
        /// </summary>
        private void ResetMaximumAge()
        {
            this.MaximumAge = null;
        }

        /// <summary>
        /// Resets the timeout.
        /// </summary>
        private void ResetTimeout()
        {
            this.Timeout = null;
        }

		#endregion Methods 
    } 
    
    #endregion

    #region GeoLocationDataTypeConverter

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class GeoLocationDataTypeConverter : TypeConverter
    {
		#region Methods (6) 

		// Public Methods (6) 

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"></see> is associated with, using the specified context, given a set of property values for the object.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <param name="objPropertyValues">An <see cref="T:System.Collections.IDictionary"></see> of new property values.</param>
        /// <returns>
        /// An <see cref="T:System.Object"></see> representing the given <see cref="T:System.Collections.IDictionary"></see>, or null if the object cannot be created. This method always returns null.
        /// </returns>
        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            bool blnRepeatCheck = false;
            bool blnEnableHighAccuracy = false;
            double? dblMaximumAge = 0;
            double? dblTimeout = 0;

            if (objPropertyValues.Contains("RepeatCheck"))
            {
                blnRepeatCheck = Convert.ToBoolean(objPropertyValues["RepeatCheck"]);
            }

            if (objPropertyValues.Contains("EnableHighAccuracy"))
            {
                blnEnableHighAccuracy = Convert.ToBoolean(objPropertyValues["EnableHighAccuracy"]);
            }

            if (objPropertyValues.Contains("MaximumAge"))
            {
                dblMaximumAge = objPropertyValues["MaximumAge"] as double?;
            }

            if (objPropertyValues.Contains("Timeout"))
            {
                dblTimeout = objPropertyValues["Timeout"] as double?;
            }

            return new GeoLocationData(blnRepeatCheck, blnEnableHighAccuracy, dblMaximumAge, dblTimeout);
        }

        /// <summary>
        /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value, using the specified context.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
        /// <returns>
        /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"></see> to create a new value; otherwise, false.
        /// </returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="objValue">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            return TypeDescriptor.GetProperties(typeof(GeoLocationData), arrAttributes).Sort();
        }

        /// <summary>
        /// Returns whether this object supports properties, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
        /// </returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

		#endregion Methods 
    } 

    #endregion
}
