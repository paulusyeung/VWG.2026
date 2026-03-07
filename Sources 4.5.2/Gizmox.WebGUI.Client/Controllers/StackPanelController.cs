using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace Gizmox.WebGUI.Client.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class StackPanelController : PanelController
    {
		#region Constructors (2) 

        /// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public StackPanelController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public StackPanelController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
		{
		}

		#endregion Constructors 

		#region Methods (8) 

		// Public Methods (4) 

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="strProperty">The STR property.</param>
        /// <returns></returns>
        public object GetPropertyValue(object objInstance, string strProperty)
        {
            return GetPropertyValue(objInstance, strProperty, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="strProperty">The STR property.</param>
        /// <param name="strDefault">The STR default.</param>
        /// <returns></returns>
        public string GetPropertyValue(object objInstance, string strProperty, string strDefault)
        {
            object objPropertyValue = GetPropertyValue(objInstance, strProperty); ;
            if (objPropertyValue != null)
            {
                TypeConverter objConverter = TypeDescriptor.GetConverter(objPropertyValue.GetType());
                if (objConverter != null)
                {
                    if (objConverter.CanConvertTo(typeof(string)))
                    {
                        return objConverter.ConvertToInvariantString(objPropertyValue);
                    }
                }
            }
            return strDefault;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="strProperty">The STR property.</param>
        /// <param name="enmBindingFlags">The enm binding flags.</param>
        /// <returns></returns>
        public object GetPropertyValue(object objInstance, string strProperty, BindingFlags enmBindingFlags)
        {
            if (objInstance != null)
            {
                // Get property info.
                PropertyInfo objProperty = objInstance.GetType().GetProperty(strProperty, enmBindingFlags);
                if (objProperty != null)
                {
                    // Define an empty property value.
                    object objPropertyValue = null;

                    try
                    {
                        // Try getting property value.
                        objPropertyValue = objProperty.GetValue(objInstance, new object[] { });
                    }
                    // In case of a target invocation.
                    catch (TargetInvocationException objTargetInvocationException)
                    {
                        // Check if inner exception exists.
                        if (objTargetInvocationException.InnerException != null)
                        {
                            // Throw inner exception.
                            throw objTargetInvocationException.InnerException;
                        }
                        else
                        {
                            throw objTargetInvocationException;
                        }
                    }

                    // Return property value.
                    return objPropertyValue;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="objInstance">The obj instance.</param>
        /// <param name="strProperty">The STR property.</param>
        /// <param name="objValue">The obj value.</param>
        public void SetPropertyValue(object objInstance, string strProperty, object objValue)
        {
            if (objInstance != null)
            {
                PropertyInfo objProperty = objInstance.GetType().GetProperty(strProperty);
                if (objProperty != null)
                {
                    objProperty.SetValue(objInstance, objValue, new object[] { });
                }
            }
        }
		// Protected Methods (3) 

        /// <summary>
        /// Create the winforms object
        /// </summary>
        /// <param name="objWebObject"></param>
        /// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new ClientStackPanel();
        }

        /// <summary>
        /// </summary>
        protected override void InitializeController()
        {
            base.InitializeController();

            this.SetWinStackPanelOrientation();
        }

        /// <summary>
        /// Called when [source object property change].
        /// </summary>
        /// <param name="objPropertyChangeArgs">The obj property change args.</param>
        protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnSourceObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Orientation":
                    this.SetWinStackPanelOrientation();
                    break;
            }
        }
		// Private Methods (1) 

        /// <summary>
        /// Sets the win stack panel orientation.
        /// </summary>
        private void SetWinStackPanelOrientation()
        {
            if (this.SourceObject != null && this.TargetObject != null)
            {
                object enmOrientation = this.GetPropertyValue(this.SourceObject, "Orientation");
                if (enmOrientation != null)
                {
                    this.SuspendNotifications();

                    this.SetPropertyValue(this.TargetObject, "Orientation", enmOrientation);

                    this.ResumeNotifications();
                }
            }
        }

		#endregion Methods 
    }
}
