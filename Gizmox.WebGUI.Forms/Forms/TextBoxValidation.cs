// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextBoxValidation
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [Serializable]
  public class TextBoxValidation
  {
    private string mstrInValidateMessage = string.Empty;
    private string mstrValueValidationExpression = string.Empty;
    private string mstrCharacterValidationMask = string.Empty;
    private string mstrCharacterValidationExpression = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TextBoxValidation" /> class.
    /// </summary>
    /// <param name="strValueValidationExpression">The value validation expression.</param>
    /// <param name="strInValidateMessage">The in validate message.</param>
    public TextBoxValidation(string strValueValidationExpression, string strInValidateMessage)
    {
      this.mstrValueValidationExpression = strValueValidationExpression;
      this.mstrInValidateMessage = strInValidateMessage;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TextBoxValidation" /> class.
    /// </summary>
    /// <param name="strValueValidationExpression">The value validation expression.</param>
    /// <param name="strInValidateMessage">The in validate message.</param>
    /// <param name="strCharacterValidationMask">The character validation mask.</param>
    public TextBoxValidation(
      string strValueValidationExpression,
      string strInValidateMessage,
      string strCharacterValidationMask)
      : this(strValueValidationExpression, strInValidateMessage)
    {
      this.mstrCharacterValidationMask = strCharacterValidationMask;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TextBoxValidation" /> class.
    /// </summary>
    /// <param name="strValueValidationExpression">The value validation expression.</param>
    /// <param name="strInValidateMessage">The in validate message.</param>
    /// <param name="strCharacterValidationMask">The character validation mask.</param>
    /// <param name="strCharacterValidationExpression">The character validation expression.</param>
    public TextBoxValidation(
      string strValueValidationExpression,
      string strInValidateMessage,
      string strCharacterValidationMask,
      string strCharacterValidationExpression)
      : this(strValueValidationExpression, strInValidateMessage, strCharacterValidationMask)
    {
      this.mstrCharacterValidationExpression = strCharacterValidationExpression;
    }

    /// <summary>Gets the decimal separator.</summary>
    /// <value>The decimal separator.</value>
    private static string DecimalSeparator => Global.Context.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;

    /// <summary>Gets or sets the character validation expression.</summary>
    /// <value>The character validation expression.</value>
    public string CharacterValidationExpression
    {
      get => this.mstrCharacterValidationExpression;
      set => this.mstrCharacterValidationExpression = value;
    }

    /// <summary>Gets the validator expression.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is no lnoger exists - please use the 'ValueValidationExpression' property instead.")]
    public string Expression => this.mstrValueValidationExpression;

    /// <summary>Gets the value validation expression.</summary>
    /// <value>The value validation expression.</value>
    public string ValueValidationExpression => this.mstrValueValidationExpression;

    /// <summary>
    /// Gets the validator charecter mask (Example: "0-9" or "a-zA-Z0-9@.").
    /// </summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is no lnoger exists - please use the 'CharacterValidationMask' property instead.")]
    public string Mask => this.mstrCharacterValidationMask;

    /// <summary>Gets the character validation mask.</summary>
    /// <value>The character validation mask.</value>
    public string CharacterValidationMask => this.mstrCharacterValidationMask;

    /// <summary>Gets the validator invalid message.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is no lnoger exists - please use the 'InValidateMessage' property instead.")]
    public string Message => this.mstrInValidateMessage;

    /// <summary>Gets the in validate message.</summary>
    /// <value>The in validate message.</value>
    public string InValidateMessage => this.mstrInValidateMessage;

    /// <summary>Gets an integer validator.</summary>
    /// <value></value>
    public static TextBoxValidation IntegerValidator
    {
      get
      {
        CultureInfo currentUiCulture = CultureInfo.CurrentUICulture;
        if (Global.Context != null && Global.Context.CurrentUICulture != null)
          currentUiCulture = Global.Context.CurrentUICulture;
        return new TextBoxValidation("String(value).match(/^-{0,1}[0-9]*$/)", SR.GetString(currentUiCulture, "WGLablesIntegerRequiered"), "0-9\\-|\\x1B");
      }
    }

    /// <summary>Gets an integer mask validator.</summary>
    /// <value></value>
    public static TextBoxValidation IntegerMaskValidator => new TextBoxValidation("", "", "0-9\\-|\\x1B");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intMinValue"></param>
    /// <param name="intMaxValue"></param>
    public static TextBoxValidation CreateIntegerValidator(int intMinValue, int intMaxValue)
    {
      CultureInfo currentUiCulture = CultureInfo.CurrentUICulture;
      if (Global.Context != null && Global.Context.CurrentUICulture != null)
        currentUiCulture = Global.Context.CurrentUICulture;
      return new TextBoxValidation(string.Format("String(value).match(/^[0-9]*$/)&& (value>={0} && value<={1})", (object) intMinValue, (object) intMaxValue), SR.GetString(currentUiCulture, "WGLablesIntegerRangeRequiered", (object) intMinValue, (object) intMaxValue), "0-9|\\x1B");
    }

    /// <summary>Gets an floating point number validator.</summary>
    /// <value></value>
    public static TextBoxValidation FloatValidator
    {
      get
      {
        CultureInfo currentUiCulture = CultureInfo.CurrentUICulture;
        if (Global.Context != null && Global.Context.CurrentUICulture != null)
          currentUiCulture = Global.Context.CurrentUICulture;
        return new TextBoxValidation("String(value).match(/^-{0,1}[0-9]*([" + TextBoxValidation.DecimalSeparator + "][0-9]+){0,1}$/)", SR.GetString(currentUiCulture, "WGLablesFloatRequiered"), "0-9\\" + TextBoxValidation.DecimalSeparator + "\\|\\x1B");
      }
    }

    /// <summary>Gets an floating point number mask validator.</summary>
    /// <value></value>
    public static TextBoxValidation FloatMaskValidator => new TextBoxValidation("", "", "0-9\\" + TextBoxValidation.DecimalSeparator + "\\|\\x1B");

    /// <summary>Gets an code mask validator.</summary>
    /// <value></value>
    public static TextBoxValidation CodeMaskValidator => new TextBoxValidation("", "", "a-zA-Z0-9_|\\x1B");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="intMinValue"></param>
    /// <param name="intMaxValue"></param>
    public static TextBoxValidation CreateFloatValidator(double intMinValue, double intMaxValue)
    {
      CultureInfo currentUiCulture = CultureInfo.CurrentUICulture;
      if (Global.Context != null && Global.Context.CurrentUICulture != null)
        currentUiCulture = Global.Context.CurrentUICulture;
      return new TextBoxValidation(string.Format("(value>={0} && value<={1})", (object) intMinValue, (object) intMaxValue), SR.GetString(currentUiCulture, "WGLablesFloatRangeRequiered", (object) intMinValue, (object) intMaxValue));
    }

    /// <summary>Gets an email validator.</summary>
    /// <value></value>
    public static TextBoxValidation EmailValidator
    {
      get
      {
        CultureInfo currentUiCulture = CultureInfo.CurrentUICulture;
        if (Global.Context != null && Global.Context.CurrentUICulture != null)
          currentUiCulture = Global.Context.CurrentUICulture;
        return new TextBoxValidation(string.Format("String(value).match(/{0}/)", (object) "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\\w-]+\\.)+[a-zA-Z]{2,4})$"), SR.GetString(currentUiCulture, "WGLablesEmailRequiered"));
      }
    }
  }
}
