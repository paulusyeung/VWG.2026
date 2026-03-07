using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Common.Device.Common;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Globalization : DeviceComponent, IGlobalization
    {
        private SingleCallMethodStore<GlobalizationEventArgs> mobjSingleCallMethodStore;
        private SingleCallMethodStore<GlobalizationDateEventArgs> mobjSingleDateCallMethodStore;
        private SingleCallMethodStore<GlobalizationInfoEventArgs> mobjInfoSingleCallMethodStore;
        private SingleCallMethodStore<GlobalizationDatePatternEventArgs> mobjDatePatternSingleCallMethodStore;
        private SingleCallMethodStore<GlobalizationNumberPatternEventArgs> mobjNumberPatternSingleCallMethodStore;
        private SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> mobjCurrencyPatternSingleCallMethodStore;
        private SingleCallMethodStore<GlobalizationListEventArgs> mobjListSingleCallMethodStore;


        /// <summary>
        /// Initializes a new instance of the <see cref="Globalization"/> class.
        /// </summary>
        /// <param name="objDeviceIntegrator">The obj device integrator.</param>
        public Globalization(DeviceIntegrator objDeviceIntegrator)
            : base(objDeviceIntegrator)
        { }


        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationEventArgs> SingleCallMethodStore
        {
            get
            {
                if (mobjSingleCallMethodStore == null)
                {
                    mobjSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>();
                }
                return mobjSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationDateEventArgs> SingleDateCallMethodStore
        {
            get
            {
                if (mobjSingleDateCallMethodStore == null)
                {
                    mobjSingleDateCallMethodStore = new SingleCallMethodStore<GlobalizationDateEventArgs>();
                }
                return mobjSingleDateCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationDatePatternEventArgs> SingleDatePatternCallMethodStore
        {
            get
            {
                if (mobjDatePatternSingleCallMethodStore == null)
                {
                    mobjDatePatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationDatePatternEventArgs>();
                }
                return mobjDatePatternSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the globalization info single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationInfoEventArgs> SingleInfoCallMethodStore
        {
            get
            {
                if (mobjInfoSingleCallMethodStore == null)
                {
                    mobjInfoSingleCallMethodStore = new SingleCallMethodStore<GlobalizationInfoEventArgs>();
                }
                return mobjInfoSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationNumberPatternEventArgs> SingleNumberCallMethodStore
        {
            get
            {
                if (mobjNumberPatternSingleCallMethodStore == null)
                {
                    mobjNumberPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationNumberPatternEventArgs>();
                }
                return mobjNumberPatternSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> SingleCurrencyCallMethodStore
        {
            get
            {
                if (mobjCurrencyPatternSingleCallMethodStore == null)
                {
                    mobjCurrencyPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs>();
                }
                return mobjCurrencyPatternSingleCallMethodStore;
            }
        }

        /// <summary>
        /// Gets the Connection single-call methods store.
        /// </summary>
        private SingleCallMethodStore<GlobalizationListEventArgs> SingleListCallMethodStore
        {
            get
            {
                if (mobjListSingleCallMethodStore == null)
                {
                    mobjListSingleCallMethodStore = new SingleCallMethodStore<GlobalizationListEventArgs>();
                }
                return mobjListSingleCallMethodStore;
            }
        }

        protected internal override void RenderSubComponents(long lngRequestID, IContext objContext, IResponseWriter objWriter)
        {
            base.RenderSubComponents(lngRequestID, objContext, objWriter);

            Invoke("Globalization_Initialize", ID);
        }

        /// <summary>
        /// Dates to string.
        /// </summary>
        /// <param name="objDateTime">The obj date time.</param>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void dateToString(DateTime objDateTime, Action<GlobalizationEventArgs> objCallback, Common.Device.Globalization.GlobalizationDateOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod("datobj", objCallback);
            Invoke("DeviceIntegrator.Globalization.dateToString", objDateTime, strMethodKey);
        }

        /// <summary>
        /// Gets the currency pattern.
        /// </summary>
        /// <param name="strCurrencyCode">The STR currency code.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void getCurrencyPattern(string strCurrencyCode, Action<Common.Device.Globalization.GlobalizationCurrencyPatternEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCurrencyCallMethodStore.StoreSingleCallMethod("cur", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.getCurrencyPattern", strCurrencyCode, strMethodKey);
        }

        /// <summary>
        /// Gets the date names.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void getDateNames(Action<Common.Device.Globalization.GlobalizationListEventArgs> objCallback, Common.Device.Globalization.GlobalizationDateNameOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleListCallMethodStore.StoreSingleCallMethod("lst", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.getDateNames", strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        /// <summary>
        /// Gets the date pattern.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void getDatePattern(Action<Common.Device.Globalization.GlobalizationDatePatternEventArgs> objCallback, Common.Device.Globalization.GlobalizationDateOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleDatePatternCallMethodStore.StoreSingleCallMethod("dat", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.getDatePattern", strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        /// <summary>
        /// Gets the number pattern.
        /// </summary>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void getNumberPattern(Action<Common.Device.Globalization.GlobalizationNumberPatternEventArgs> objCallback, GlobalizationNumberOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleNumberCallMethodStore.StoreSingleCallMethod("num", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.getNumberPattern", strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        public void getGlobalizationInfo(Action<Common.Device.Globalization.GlobalizationInfoEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleInfoCallMethodStore.StoreSingleCallMethod("gi", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.getGlobalizationInfo", strMethodKey);
        }

        /// <summary>
        /// Determines whether [is day light savings time] [the specified obj date time].
        /// </summary>
        /// <param name="objDateTime">The obj date time.</param>
        /// <param name="objCallback">The obj callback.</param>
        public void isDayLightSavingsTime(DateTime objDateTime, Action<Common.Device.Globalization.GlobalizationEventArgs> objCallback)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.isDayLightSavingsTime", objDateTime, strMethodKey);
        }

        /// <summary>
        /// Numbers to string.
        /// </summary>
        /// <param name="dblNumber">The DBL number.</param>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void numberToString(double dblNumber, Action<Common.Device.Globalization.GlobalizationEventArgs> objCallback, Common.Device.Globalization.GlobalizationNumberOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.numberToString", dblNumber, strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        /// <summary>
        /// Strings to date.
        /// </summary>
        /// <param name="strStringInput">The STR string input.</param>
        /// <param name="objCallback">The obj callback.</param>
        /// <param name="objOptions">The obj options.</param>
        public void stringToDate(string strStringInput, Action<Common.Device.Globalization.GlobalizationDateEventArgs> objCallback, Common.Device.Globalization.GlobalizationDateOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleDateCallMethodStore.StoreSingleCallMethod("datobj", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.stringToDate", strStringInput, strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        public void stringToNumber(string strStringInput, Action<Common.Device.Globalization.GlobalizationEventArgs> objCallback, Common.Device.Globalization.GlobalizationNumberOptions objOptions)
        {
            //Store the method for handling in the response
            string strMethodKey = SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);

            // Call the offline api for getting the device informtaion
            Invoke("DeviceIntegrator.Globalization.stringToNumber", strStringInput, strMethodKey, CommonUtils.GetClientJsonObject(objOptions));
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <returns></returns>
        protected internal override string GetTag()
        {
            return WGTags.DeviceGlobalization;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(Common.Interfaces.IEvent objEvent)
        {
            base.FireEvent(objEvent);
            HandleEvent(objEvent);
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        private void HandleEvent(Common.Interfaces.IEvent objEvent)
        {
            string strMethodKey = objEvent.Type;

            KeyValuePair<string, string> objSplittedValues = SplitPrefixFromMethodKey(strMethodKey);

            switch (objSplittedValues.Key)
            {
                case "gi":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationInfoEventArgs objInfoArguments = GetGlobalizationInfoEventArgs(objEvent);

                    if (mobjInfoSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjInfoSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objInfoArguments);
                    }
                    break;
                case "gen":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationEventArgs objGenArguments = GetGeneralEventArgs(objEvent);

                    if (mobjSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objGenArguments);
                    }
                    break;
                case "dat":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationDatePatternEventArgs objDateArguments = GetDatePatternEventArgs(objEvent);

                    if (mobjDatePatternSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjDatePatternSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objDateArguments);
                    }
                    break;
                case "datobj":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationDateEventArgs objDateObjArguments = GetDateEventArgs(objEvent);

                    if (mobjSingleDateCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjSingleDateCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objDateObjArguments);
                    }
                    break;
                case "num":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationNumberPatternEventArgs objNumArguments = GetNumberPatternEventArgs(objEvent);

                    if (mobjNumberPatternSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjNumberPatternSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objNumArguments);
                    }
                    break;
                case "cur":
                    // Insert to args - maybe remove irrelevant args
                    GlobalizationCurrencyPatternEventArgs objCurArguments = GetCurrencyPatternEventArgs(objEvent);

                    if (mobjCurrencyPatternSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjCurrencyPatternSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objCurArguments);
                    }
                    break;
                case "lst":
                    GlobalizationListEventArgs objListArguments = GetListEventArgs(objEvent);

                    if (mobjListSingleCallMethodStore.HasRegisteredMethod(objSplittedValues.Value))
                    {
                        // Invoke a single call method with a method key
                        mobjListSingleCallMethodStore.InvokeSingleCallMethod(objSplittedValues.Value, objListArguments);
                    }

                    break;
                default:
                    // Throw ??
                    break;
            }
        }

        /// <summary>
        /// Gets the date event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationDateEventArgs GetDateEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationDateEventArgs objArguments = null;

            if (!GlobalizationDateEventArgs.TryGetError(objEvent, out objArguments))
            {
                if (!string.IsNullOrEmpty(objEvent["ReturnValue"]))
                {
                    string[] strValues = objEvent["ReturnValue"].Split(',');

                    // Millisecond is not supported in all platforms.
                    int intMillisecond;
                    int.TryParse(strValues[6], out intMillisecond);

                    objArguments = new GlobalizationDateEventArgs(new DateTime(int.Parse(strValues[0]), int.Parse(strValues[1]), int.Parse(strValues[2]), int.Parse(strValues[3]), int.Parse(strValues[4]), int.Parse(strValues[5]), intMillisecond));
                }
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the list event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationListEventArgs GetListEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationListEventArgs objArguments = null;

            if (!GlobalizationListEventArgs.TryGetError(objEvent, out objArguments))
            {
                if (!string.IsNullOrEmpty(objEvent["ReturnValue"]))
                {
                    string[] strValues = objEvent["ReturnValue"].Split(',');

                    objArguments = new GlobalizationListEventArgs(new List<string>(strValues));
                }
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the currency pattern event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationCurrencyPatternEventArgs GetCurrencyPatternEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationCurrencyPatternEventArgs objArguments = null;

            if (!GlobalizationCurrencyPatternEventArgs.TryGetError(objEvent, out objArguments))
            {
                string strPattern = objEvent["pattern"];
                string strCode = objEvent["code"];
                string strFraction = objEvent["fraction"];
                string strRounding = objEvent["rounding"];
                string strDecimal = objEvent["decimal"];
                string strGrouping = objEvent["grouping"];

                objArguments = new GlobalizationCurrencyPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strCode);
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the number pattern event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationNumberPatternEventArgs GetNumberPatternEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationNumberPatternEventArgs objArguments = null;

            if (!GlobalizationNumberPatternEventArgs.TryGetError(objEvent, out objArguments))
            {
                string strPattern = objEvent["pattern"];
                string strFraction = objEvent["fraction"];
                string strRounding = objEvent["rounding"];
                string strDecimal = objEvent["decimal"];
                string strGrouping = objEvent["grouping"];
                string strSymbol = objEvent["symbol"];
                string strPositive = objEvent["positive"];
                string strNegative = objEvent["negative"];

                objArguments = new GlobalizationNumberPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strSymbol, strPositive, strNegative);
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the date pattern event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationDatePatternEventArgs GetDatePatternEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationDatePatternEventArgs objArguments = null;

            if (!GlobalizationDatePatternEventArgs.TryGetError(objEvent, out objArguments))
            {
                string strPattern = objEvent["pattern"];
                string strTimezone = objEvent["timezone"];
                string strUtc_offset = objEvent["utc_offset"];
                string strDst_offset = objEvent["dst_offset"];

                objArguments = new GlobalizationDatePatternEventArgs(strPattern, strTimezone, strUtc_offset, strDst_offset);
            }

            return objArguments;
        }

        /// <summary>
        /// Gets the general event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationEventArgs GetGeneralEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationEventArgs objArguments = null;

            if (!GlobalizationEventArgs.TryGetError(objEvent, out objArguments))
            {
                if (!string.IsNullOrEmpty(objEvent["ReturnValue"]))
                {

                    objArguments = new GlobalizationEventArgs(objEvent["ReturnValue"]);
                }
            }

            return objArguments;
        }


        /// <summary>
        /// Gets the general event args.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private GlobalizationInfoEventArgs GetGlobalizationInfoEventArgs(Common.Interfaces.IEvent objEvent)
        {
            // Prepare an arguments object
            GlobalizationInfoEventArgs objArguments = null;

            if (!GlobalizationInfoEventArgs.TryGetError(objEvent, out objArguments))
            {
                objArguments = new GlobalizationInfoEventArgs(objEvent["PreferredLanguage"], objEvent["LocaleName"], objEvent["FirstDayOfWeek"]);
            }

            return objArguments;
        }

    }
}
