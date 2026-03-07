// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DeviceIntegration.Globalization
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.DeviceIntegration
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class Globalization : DeviceComponent, IGlobalization
  {
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationEventArgs> mobjSingleCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDateEventArgs> mobjSingleDateCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationInfoEventArgs> mobjInfoSingleCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDatePatternEventArgs> mobjDatePatternSingleCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationNumberPatternEventArgs> mobjNumberPatternSingleCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> mobjCurrencyPatternSingleCallMethodStore;
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationListEventArgs> mobjListSingleCallMethodStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DeviceIntegration.Globalization" /> class.
    /// </summary>
    /// <param name="objDeviceIntegrator">The obj device integrator.</param>
    public Globalization(DeviceIntegrator objDeviceIntegrator)
      : base(objDeviceIntegrator)
    {
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationEventArgs> SingleCallMethodStore
    {
      get
      {
        if (this.mobjSingleCallMethodStore == null)
          this.mobjSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationEventArgs>();
        return this.mobjSingleCallMethodStore;
      }
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDateEventArgs> SingleDateCallMethodStore
    {
      get
      {
        if (this.mobjSingleDateCallMethodStore == null)
          this.mobjSingleDateCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDateEventArgs>();
        return this.mobjSingleDateCallMethodStore;
      }
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDatePatternEventArgs> SingleDatePatternCallMethodStore
    {
      get
      {
        if (this.mobjDatePatternSingleCallMethodStore == null)
          this.mobjDatePatternSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationDatePatternEventArgs>();
        return this.mobjDatePatternSingleCallMethodStore;
      }
    }

    /// <summary>
    /// Gets the globalization info single-call methods store.
    /// </summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationInfoEventArgs> SingleInfoCallMethodStore
    {
      get
      {
        if (this.mobjInfoSingleCallMethodStore == null)
          this.mobjInfoSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationInfoEventArgs>();
        return this.mobjInfoSingleCallMethodStore;
      }
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationNumberPatternEventArgs> SingleNumberCallMethodStore
    {
      get
      {
        if (this.mobjNumberPatternSingleCallMethodStore == null)
          this.mobjNumberPatternSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationNumberPatternEventArgs>();
        return this.mobjNumberPatternSingleCallMethodStore;
      }
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> SingleCurrencyCallMethodStore
    {
      get
      {
        if (this.mobjCurrencyPatternSingleCallMethodStore == null)
          this.mobjCurrencyPatternSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs>();
        return this.mobjCurrencyPatternSingleCallMethodStore;
      }
    }

    /// <summary>Gets the Connection single-call methods store.</summary>
    private Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationListEventArgs> SingleListCallMethodStore
    {
      get
      {
        if (this.mobjListSingleCallMethodStore == null)
          this.mobjListSingleCallMethodStore = new Gizmox.WebGUI.Forms.DeviceIntegration.Abstract.SingleCallMethodStore<GlobalizationListEventArgs>();
        return this.mobjListSingleCallMethodStore;
      }
    }

    protected internal override void RenderSubComponents(
      long lngRequestID,
      IContext objContext,
      IResponseWriter objWriter)
    {
      base.RenderSubComponents(lngRequestID, objContext, objWriter);
      this.Invoke("Globalization_Initialize", (object) this.ID);
    }

    /// <summary>Dates to string.</summary>
    /// <param name="objDateTime">The obj date time.</param>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void dateToString(
      DateTime objDateTime,
      Action<GlobalizationEventArgs> objCallback,
      GlobalizationDateOptions objOptions)
    {
      string str = this.SingleCallMethodStore.StoreSingleCallMethod("datobj", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.dateToString", (object) objDateTime, (object) str);
    }

    /// <summary>Gets the currency pattern.</summary>
    /// <param name="strCurrencyCode">The STR currency code.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void getCurrencyPattern(
      string strCurrencyCode,
      Action<GlobalizationCurrencyPatternEventArgs> objCallback)
    {
      string str = this.SingleCurrencyCallMethodStore.StoreSingleCallMethod("cur", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.getCurrencyPattern", (object) strCurrencyCode, (object) str);
    }

    /// <summary>Gets the date names.</summary>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void getDateNames(
      Action<GlobalizationListEventArgs> objCallback,
      GlobalizationDateNameOptions objOptions)
    {
      this.Invoke("DeviceIntegrator.Globalization.getDateNames", (object) this.SingleListCallMethodStore.StoreSingleCallMethod("lst", objCallback), (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    /// <summary>Gets the date pattern.</summary>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void getDatePattern(
      Action<GlobalizationDatePatternEventArgs> objCallback,
      GlobalizationDateOptions objOptions)
    {
      this.Invoke("DeviceIntegrator.Globalization.getDatePattern", (object) this.SingleDatePatternCallMethodStore.StoreSingleCallMethod("dat", objCallback), (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    /// <summary>Gets the number pattern.</summary>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void getNumberPattern(
      Action<GlobalizationNumberPatternEventArgs> objCallback,
      GlobalizationNumberOptions objOptions)
    {
      this.Invoke("DeviceIntegrator.Globalization.getNumberPattern", (object) this.SingleNumberCallMethodStore.StoreSingleCallMethod("num", objCallback), (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    public void getGlobalizationInfo(Action<GlobalizationInfoEventArgs> objCallback) => this.Invoke("DeviceIntegrator.Globalization.getGlobalizationInfo", (object) this.SingleInfoCallMethodStore.StoreSingleCallMethod("gi", objCallback));

    /// <summary>
    /// Determines whether [is day light savings time] [the specified obj date time].
    /// </summary>
    /// <param name="objDateTime">The obj date time.</param>
    /// <param name="objCallback">The obj callback.</param>
    public void isDayLightSavingsTime(
      DateTime objDateTime,
      Action<GlobalizationEventArgs> objCallback)
    {
      string str = this.SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.isDayLightSavingsTime", (object) objDateTime, (object) str);
    }

    /// <summary>Numbers to string.</summary>
    /// <param name="dblNumber">The DBL number.</param>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void numberToString(
      double dblNumber,
      Action<GlobalizationEventArgs> objCallback,
      GlobalizationNumberOptions objOptions)
    {
      string str = this.SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.numberToString", (object) dblNumber, (object) str, (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    /// <summary>Strings to date.</summary>
    /// <param name="strStringInput">The STR string input.</param>
    /// <param name="objCallback">The obj callback.</param>
    /// <param name="objOptions">The obj options.</param>
    public void stringToDate(
      string strStringInput,
      Action<GlobalizationDateEventArgs> objCallback,
      GlobalizationDateOptions objOptions)
    {
      string str = this.SingleDateCallMethodStore.StoreSingleCallMethod("datobj", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.stringToDate", (object) strStringInput, (object) str, (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    public void stringToNumber(
      string strStringInput,
      Action<GlobalizationEventArgs> objCallback,
      GlobalizationNumberOptions objOptions)
    {
      string str = this.SingleCallMethodStore.StoreSingleCallMethod("gen", objCallback);
      this.Invoke("DeviceIntegrator.Globalization.stringToNumber", (object) strStringInput, (object) str, (object) CommonUtils.GetClientJsonObject((object) objOptions));
    }

    /// <summary>Gets the tag.</summary>
    /// <returns></returns>
    protected internal override string GetTag() => "GLZ";

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      this.HandleEvent(objEvent);
    }

    /// <summary>Handles the event.</summary>
    /// <param name="objEvent">The obj event.</param>
    private void HandleEvent(IEvent objEvent)
    {
      KeyValuePair<string, string> keyValuePair = this.SplitPrefixFromMethodKey(objEvent.Type);
      string key = keyValuePair.Key;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(key))
      {
        case 242376115:
          if (!(key == "num"))
            break;
          GlobalizationNumberPatternEventArgs patternEventArgs1 = this.GetNumberPatternEventArgs(objEvent);
          if (!this.mobjNumberPatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjNumberPatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, patternEventArgs1);
          break;
        case 1210089661:
          if (!(key == "gi"))
            break;
          GlobalizationInfoEventArgs globalizationInfoEventArgs = this.GetGlobalizationInfoEventArgs(objEvent);
          if (!this.mobjInfoSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjInfoSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, globalizationInfoEventArgs);
          break;
        case 1283654292:
          if (!(key == "lst"))
            break;
          GlobalizationListEventArgs listEventArgs = this.GetListEventArgs(objEvent);
          if (!this.mobjListSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjListSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, listEventArgs);
          break;
        case 1577891605:
          if (!(key == "gen"))
            break;
          GlobalizationEventArgs generalEventArgs = this.GetGeneralEventArgs(objEvent);
          if (!this.mobjSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, generalEventArgs);
          break;
        case 2447721395:
          if (!(key == "datobj"))
            break;
          GlobalizationDateEventArgs dateEventArgs = this.GetDateEventArgs(objEvent);
          if (!this.mobjSingleDateCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjSingleDateCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, dateEventArgs);
          break;
        case 3612282246:
          if (!(key == "dat"))
            break;
          GlobalizationDatePatternEventArgs patternEventArgs2 = this.GetDatePatternEventArgs(objEvent);
          if (!this.mobjDatePatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjDatePatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, patternEventArgs2);
          break;
        case 4233508661:
          if (!(key == "cur"))
            break;
          GlobalizationCurrencyPatternEventArgs patternEventArgs3 = this.GetCurrencyPatternEventArgs(objEvent);
          if (!this.mobjCurrencyPatternSingleCallMethodStore.HasRegisteredMethod(keyValuePair.Value))
            break;
          this.mobjCurrencyPatternSingleCallMethodStore.InvokeSingleCallMethod(keyValuePair.Value, patternEventArgs3);
          break;
      }
    }

    /// <summary>Gets the date event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationDateEventArgs GetDateEventArgs(IEvent objEvent)
    {
      GlobalizationDateEventArgs objEventArgs = (GlobalizationDateEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationDateEventArgs>(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
      {
        string[] strArray = objEvent["ReturnValue"].Split(',');
        int result;
        int.TryParse(strArray[6], out result);
        objEventArgs = new GlobalizationDateEventArgs(new DateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]), int.Parse(strArray[4]), int.Parse(strArray[5]), result));
      }
      return objEventArgs;
    }

    /// <summary>Gets the list event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationListEventArgs GetListEventArgs(IEvent objEvent)
    {
      GlobalizationListEventArgs objEventArgs = (GlobalizationListEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationListEventArgs>(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
        objEventArgs = new GlobalizationListEventArgs(new List<string>((IEnumerable<string>) objEvent["ReturnValue"].Split(',')));
      return objEventArgs;
    }

    /// <summary>Gets the currency pattern event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationCurrencyPatternEventArgs GetCurrencyPatternEventArgs(IEvent objEvent)
    {
      GlobalizationCurrencyPatternEventArgs objEventArgs = (GlobalizationCurrencyPatternEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationCurrencyPatternEventArgs>(objEvent, out objEventArgs))
      {
        string strPattern = objEvent["pattern"];
        string str1 = objEvent["code"];
        string str2 = objEvent["fraction"];
        string str3 = objEvent["rounding"];
        string str4 = objEvent["decimal"];
        string str5 = objEvent["grouping"];
        string strFraction = str2;
        string strRounding = str3;
        string strDecimal = str4;
        string strGrouping = str5;
        string strCode = str1;
        objEventArgs = new GlobalizationCurrencyPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strCode);
      }
      return objEventArgs;
    }

    /// <summary>Gets the number pattern event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationNumberPatternEventArgs GetNumberPatternEventArgs(IEvent objEvent)
    {
      GlobalizationNumberPatternEventArgs objEventArgs = (GlobalizationNumberPatternEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationNumberPatternEventArgs>(objEvent, out objEventArgs))
      {
        string strPattern = objEvent["pattern"];
        string str1 = objEvent["fraction"];
        string str2 = objEvent["rounding"];
        string str3 = objEvent["decimal"];
        string str4 = objEvent["grouping"];
        string str5 = objEvent["symbol"];
        string str6 = objEvent["positive"];
        string str7 = objEvent["negative"];
        string strFraction = str1;
        string strRounding = str2;
        string strDecimal = str3;
        string strGrouping = str4;
        string strSymbol = str5;
        string strPositive = str6;
        string strNegative = str7;
        objEventArgs = new GlobalizationNumberPatternEventArgs(strPattern, strFraction, strRounding, strDecimal, strGrouping, strSymbol, strPositive, strNegative);
      }
      return objEventArgs;
    }

    /// <summary>Gets the date pattern event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationDatePatternEventArgs GetDatePatternEventArgs(IEvent objEvent)
    {
      GlobalizationDatePatternEventArgs objEventArgs = (GlobalizationDatePatternEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationDatePatternEventArgs>(objEvent, out objEventArgs))
      {
        string strPattern = objEvent["pattern"];
        string str1 = objEvent["timezone"];
        string str2 = objEvent["utc_offset"];
        string str3 = objEvent["dst_offset"];
        string strTimezone = str1;
        string strUtc_offset = str2;
        string strDst_offset = str3;
        objEventArgs = new GlobalizationDatePatternEventArgs(strPattern, strTimezone, strUtc_offset, strDst_offset);
      }
      return objEventArgs;
    }

    /// <summary>Gets the general event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationEventArgs GetGeneralEventArgs(IEvent objEvent)
    {
      GlobalizationEventArgs objEventArgs = (GlobalizationEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationEventArgs>(objEvent, out objEventArgs) && !string.IsNullOrEmpty(objEvent["ReturnValue"]))
        objEventArgs = new GlobalizationEventArgs(objEvent["ReturnValue"]);
      return objEventArgs;
    }

    /// <summary>Gets the general event args.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private GlobalizationInfoEventArgs GetGlobalizationInfoEventArgs(IEvent objEvent)
    {
      GlobalizationInfoEventArgs objEventArgs = (GlobalizationInfoEventArgs) null;
      if (!DeviceEventArgs.TryGetError<GlobalizationInfoEventArgs>(objEvent, out objEventArgs))
        objEventArgs = new GlobalizationInfoEventArgs(objEvent["PreferredLanguage"], objEvent["LocaleName"], objEvent["FirstDayOfWeek"]);
      return objEventArgs;
    }
  }
}
