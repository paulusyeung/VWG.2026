using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Notifications : DeviceComponent, INotifications
    {
        private SingleCallMethodStore<EmptyDeviceEventArgs> mobjAlertStore;
        private SingleCallMethodStore<ConfirmEventArgs> mobjConfirmStore;
        private SingleCallMethodStore<EmptyDeviceEventArgs> mobjBeepStore;
        private SingleCallMethodStore<EmptyDeviceEventArgs> mobjVibrateStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notifications"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public Notifications(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.Notifications;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            string strMethodKey = objEvent.Type;

            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(strMethodKey);

            switch (objSplittedValues.Key)
            {
                case "alert":
                    // Insert to args - maybe remove irrelevant args
                    EmptyDeviceEventArgs objArguments = new EmptyDeviceEventArgs();

                    if (mobjAlertStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjAlertStore.InvokeSingleCallMethod(objSplittedValues.Value, objArguments);
                    }
                    break;
                case "confirm":
                    int intButtonIndex;
                    if (int.TryParse(objEvent["ButtonIndex"], out intButtonIndex))
                    {
                        ConfirmEventArgs args = new ConfirmEventArgs(intButtonIndex);

                        mobjConfirmStore.InvokeSingleCallMethod(objSplittedValues.Value, args);
                    }
                    break;
                case "beep":
                    mobjBeepStore.InvokeSingleCallMethod(objSplittedValues.Value, new EmptyDeviceEventArgs());
                    break;
                case "vibrate":
                    mobjVibrateStore.InvokeSingleCallMethod(objSplittedValues.Value, new EmptyDeviceEventArgs());
                    break;
                default:
                    // Throw ??
                    break;
            }
        }

        /// <summary>
        /// Alerts the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        public void Alert(string strMessage)
        {
            Alert(strMessage, null, mobjAlertStore.StoreSingleCallMethod("alert", GetNullAction<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>()));
        }

        /// <summary>
        /// Alerts the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Alert(string strMessage, AlertOptions objOptions, Action<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs> objCallback)
        {
            if (mobjAlertStore == null)
            {
                mobjAlertStore = new SingleCallMethodStore<Gizmox.WebGUI.Common.Device.Common.EmptyDeviceEventArgs>();
            }

            Alert(strMessage, objOptions, mobjAlertStore.StoreSingleCallMethod("alert", objCallback));
        }

        /// <summary>
        /// Alerts the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="fncCallback">The FNC callback.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="arrCallbackParams">The arr callback params.</param>
        private void Alert(string strMessage, AlertOptions objOptions, string fncCallback)
        {
            object[] arrParams = new object[3];
            arrParams[0] = strMessage;
            arrParams[1] = fncCallback;
            arrParams[2] = CommonUtils.GetClientJsonObject(objOptions);

            // Invoke the function
            Invoke("DeviceIntegrator.Notifications.alert", arrParams);
        }

        /// <summary>
        /// Confirms the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        public void Confirm(string strMessage)
        {
            Confirm(strMessage, null, GetNullAction<ConfirmEventArgs>());
        }

        /// <summary>
        /// Confrims the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Confirm(string strMessage, ConfirmOptions objOptions, Action<ConfirmEventArgs> objCallback)
        {
            if (mobjConfirmStore == null)
            {
                mobjConfirmStore = new SingleCallMethodStore<ConfirmEventArgs>();
            }

            Confirm(strMessage, objOptions, mobjConfirmStore.StoreSingleCallMethod("confirm", objCallback));
        }

        /// <summary>
        /// Confirms the specified STR message.
        /// </summary>
        /// <param name="strMessage">The STR message.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="objOptions">The obj options.</param>
        /// <param name="fncCallback">The FNC callback.</param>
        /// <param name="arrCallbackParams">The arr callback params.</param>
        private void Confirm(string strMessage, ConfirmOptions objOptions, string fncCallback)
        {
            object[] arrParams = new object[3];
            arrParams[0] = strMessage;
            arrParams[1] = fncCallback;
            arrParams[2] = CommonUtils.GetClientJsonObject(objOptions);

            // Invoke the function
            Invoke("DeviceIntegrator.Notifications.confirm", arrParams);
        }

        /// <summary>
        /// Beeps the specified int times.
        /// </summary>
        /// <param name="intTimes">The int times.</param>
        public void Beep(int intTimes)
        {
            Beep(intTimes, GetNullAction<EmptyDeviceEventArgs>());
        }

        /// <summary>
        /// Beeps the specified int times.
        /// </summary>
        /// <param name="intTimes">The int times.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Beep(int intTimes, Action<EmptyDeviceEventArgs> objCallback)
        {
            if (mobjBeepStore == null)
            {
                mobjBeepStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
            }

            Beep(intTimes, mobjBeepStore.StoreSingleCallMethod("beep", objCallback));
        }

        /// <summary>
        /// Beeps the specified int times.
        /// </summary>
        /// <param name="intTimes">The int times.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="fncCallback">The FNC callback.</param>
        /// <param name="arrCallbackParams">The arr callback params.</param>
        public void Beep(int intTimes, string fncCallback)
        {
            SingleNumericParameterInvoker("beep", intTimes, fncCallback);
        }

        /// <summary>
        /// Vibrates the specified int duiration in milliseconds.
        /// </summary>
        /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
        public void Vibrate(int intDuirationInMilliseconds)
        {
            Vibrate(intDuirationInMilliseconds, GetNullAction<EmptyDeviceEventArgs>());
        }

        /// <summary>
        /// Beeps the specified int times.
        /// </summary>
        /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void Vibrate(int intDuirationInMilliseconds, Action<EmptyDeviceEventArgs> objCallback)
        {
            if (mobjVibrateStore == null)
            {
                mobjVibrateStore = new SingleCallMethodStore<EmptyDeviceEventArgs>();
            }

            Vibrate(intDuirationInMilliseconds, mobjVibrateStore.StoreSingleCallMethod("vibrate", objCallback));
        }

        /// <summary>
        /// Beeps the specified int times.
        /// </summary>
        /// <param name="intDuirationInMilliseconds">The int duiration in milliseconds.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="fncCallback">The FNC callback.</param>
        /// <param name="arrCallbackParams">The arr callback params.</param>
        private void Vibrate(int intDuirationInMilliseconds, string fncCallback)
        {
            SingleNumericParameterInvoker("vibrate", intDuirationInMilliseconds, fncCallback);
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Notifications_Initialize", ID);
        }

        /// <summary>
        /// Singles the numeric parameter invoker.
        /// </summary>
        /// <param name="strFunction">The STR function.</param>
        /// <param name="intNumericParameter">The int numeric parameter.</param>
        /// <param name="objClientContext">The obj client context.</param>
        /// <param name="fncCallback">The FNC callback.</param>
        /// <param name="arrCallbackParams">The arr callback params.</param>
        private void SingleNumericParameterInvoker(string strFunction, int intNumericParameter, string fncCallback)
        {
            object[] arrParams = new object[2];
            arrParams[0] = intNumericParameter;
            arrParams[1] = fncCallback;

            Invoke(string.Format("DeviceIntegrator.Notifications.{0}", strFunction), arrParams);
        }

        /// <summary>
        /// This method is used just for preventing conflicting between overload methods.
        /// </summary>
        private Action<T> GetNullAction<T>()
        {
            return null;
        }

    }
}
