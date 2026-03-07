// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutSettingsTypeConverter
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Provides a unified way of converting types of values to other types, as well as for accessing standard values and subproperties.
  /// </summary>
  [Serializable]
  public class TableLayoutSettingsTypeConverter : TypeConverter
  {
    /// <summary>
    /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objSourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType) => objSourceType == typeof (string) || base.CanConvertFrom(objContext, objSourceType);

    /// <summary>
    /// Returns whether this converter can convert the object to the specified type, using the specified context.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objDestinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
    /// <returns>
    /// true if this converter can perform the conversion; otherwise, false.
    /// </returns>
    public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType) => !(objDestinationType != typeof (InstanceDescriptor)) || !(objDestinationType != typeof (string)) || base.CanConvertTo(objContext, objDestinationType);

    /// <summary>
    /// Converts the given object to the type of this converter, using the specified context and culture information.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objCulture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
    /// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">
    /// The conversion cannot be performed.
    /// </exception>
    public override object ConvertFrom(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue)
    {
      if (!(objValue is string))
        return base.ConvertFrom(objContext, objCulture, objValue);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(objValue as string);
      TableLayoutSettings objSettings = new TableLayoutSettings();
      this.ParseControls(objSettings, xmlDocument.GetElementsByTagName("Control"));
      this.ParseStyles(objSettings, xmlDocument.GetElementsByTagName("Columns"), true);
      this.ParseStyles(objSettings, xmlDocument.GetElementsByTagName("Rows"), false);
      return (object) objSettings;
    }

    /// <summary>
    /// Converts the given value object to the specified type, using the specified context and culture information.
    /// </summary>
    /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
    /// <param name="objCulture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
    /// <param name="objValue">The <see cref="T:System.Object" /> to convert.</param>
    /// <param name="objDestinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
    /// <returns>
    /// An <see cref="T:System.Object" /> that represents the converted value.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// The <paramref name="objDestinationType" /> parameter is null.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The conversion cannot be performed.
    /// </exception>
    public override object ConvertTo(
      ITypeDescriptorContext objContext,
      CultureInfo objCulture,
      object objValue,
      Type objDestinationType)
    {
      if (objDestinationType == (Type) null)
        throw new ArgumentNullException(nameof (objDestinationType));
      if (!(objValue is TableLayoutSettings) || objDestinationType != typeof (string))
        return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
      TableLayoutSettings tableLayoutSettings = objValue as TableLayoutSettings;
      StringBuilder output = new StringBuilder();
      XmlWriter xmlWriter1 = XmlWriter.Create(output);
      xmlWriter1.WriteStartElement("TableLayoutSettings");
      xmlWriter1.WriteStartElement("Controls");
      foreach (TableLayoutSettings.ControlInformation controlInformation in tableLayoutSettings.GetControlsInformation())
      {
        xmlWriter1.WriteStartElement("Control");
        xmlWriter1.WriteAttributeString("Name", controlInformation.Name.ToString());
        XmlWriter xmlWriter2 = xmlWriter1;
        int num = controlInformation.Row;
        string str1 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
        xmlWriter2.WriteAttributeString("Row", str1);
        XmlWriter xmlWriter3 = xmlWriter1;
        num = controlInformation.RowSpan;
        string str2 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
        xmlWriter3.WriteAttributeString("RowSpan", str2);
        XmlWriter xmlWriter4 = xmlWriter1;
        num = controlInformation.Column;
        string str3 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
        xmlWriter4.WriteAttributeString("Column", str3);
        XmlWriter xmlWriter5 = xmlWriter1;
        num = controlInformation.ColumnSpan;
        string str4 = num.ToString((IFormatProvider) CultureInfo.CurrentCulture);
        xmlWriter5.WriteAttributeString("ColumnSpan", str4);
        xmlWriter1.WriteEndElement();
      }
      xmlWriter1.WriteEndElement();
      xmlWriter1.WriteStartElement("Columns");
      StringBuilder stringBuilder1 = new StringBuilder();
      foreach (ColumnStyle columnStyle in (IEnumerable) tableLayoutSettings.ColumnStyles)
        stringBuilder1.AppendFormat("{0},{1},", (object) columnStyle.SizeType, (object) columnStyle.Width);
      if (stringBuilder1.Length > 0)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        stringBuilder2.Remove(stringBuilder2.Length - 1, 1);
      }
      xmlWriter1.WriteAttributeString("Styles", stringBuilder1.ToString());
      xmlWriter1.WriteEndElement();
      xmlWriter1.WriteStartElement("Rows");
      StringBuilder stringBuilder3 = new StringBuilder();
      foreach (RowStyle rowStyle in (IEnumerable) tableLayoutSettings.RowStyles)
        stringBuilder3.AppendFormat("{0},{1},", (object) rowStyle.SizeType, (object) rowStyle.Height);
      if (stringBuilder3.Length > 0)
      {
        StringBuilder stringBuilder4 = stringBuilder3;
        stringBuilder4.Remove(stringBuilder4.Length - 1, 1);
      }
      xmlWriter1.WriteAttributeString("Styles", stringBuilder3.ToString());
      xmlWriter1.WriteEndElement();
      xmlWriter1.WriteEndElement();
      xmlWriter1.Close();
      return (object) output.ToString();
    }

    private string GetAttributeValue(XmlNode objXmlNode, string strAttribute) => objXmlNode.Attributes[strAttribute]?.Value;

    private int GetAttributeValue(XmlNode objXmlNode, string strAttribute, int intValueIfNotFound)
    {
      string attributeValue = this.GetAttributeValue(objXmlNode, strAttribute);
      double dblValue;
      return !CommonUtils.IsNullOrEmpty(attributeValue) && CommonUtils.TryParse(attributeValue, out dblValue) ? Convert.ToInt32(dblValue) : intValueIfNotFound;
    }

    private void ParseControls(TableLayoutSettings objSettings, XmlNodeList controlXmlFragments)
    {
      foreach (XmlNode controlXmlFragment in controlXmlFragments)
      {
        string attributeValue1 = this.GetAttributeValue(controlXmlFragment, "Name");
        if (!CommonUtils.IsNullOrEmpty(attributeValue1))
        {
          int attributeValue2 = this.GetAttributeValue(controlXmlFragment, "Row", -1);
          int attributeValue3 = this.GetAttributeValue(controlXmlFragment, "RowSpan", 1);
          int attributeValue4 = this.GetAttributeValue(controlXmlFragment, "Column", -1);
          int attributeValue5 = this.GetAttributeValue(controlXmlFragment, "ColumnSpan", 1);
          objSettings.SetRow((object) attributeValue1, attributeValue2);
          objSettings.SetColumn((object) attributeValue1, attributeValue4);
          objSettings.SetRowSpan((object) attributeValue1, attributeValue3);
          objSettings.SetColumnSpan((object) attributeValue1, attributeValue5);
        }
      }
    }

    private void ParseStyles(
      TableLayoutSettings objSettings,
      XmlNodeList objControlXmlFragments,
      bool blnColumns)
    {
      foreach (XmlNode controlXmlFragment in objControlXmlFragments)
      {
        string attributeValue = this.GetAttributeValue(controlXmlFragment, "Styles");
        Type enumType = typeof (SizeType);
        int index;
        if (!CommonUtils.IsNullOrEmpty(attributeValue))
        {
          for (int startIndex = 0; startIndex < attributeValue.Length; startIndex = index)
          {
            index = startIndex;
            while (char.IsLetter(attributeValue[index]))
              ++index;
            SizeType objSizeType = (SizeType) Enum.Parse(enumType, attributeValue.Substring(startIndex, index - startIndex), true);
            while (!char.IsDigit(attributeValue[index]))
              ++index;
            StringBuilder stringBuilder = new StringBuilder();
            for (; index < attributeValue.Length && char.IsDigit(attributeValue[index]); ++index)
              stringBuilder.Append(attributeValue[index]);
            stringBuilder.Append('.');
            for (; index < attributeValue.Length && !char.IsLetter(attributeValue[index]); ++index)
            {
              if (char.IsDigit(attributeValue[index]))
                stringBuilder.Append(attributeValue[index]);
            }
            float fltValue;
            if (!CommonUtils.TryParse(stringBuilder.ToString(), out fltValue))
              fltValue = 0.0f;
            if (blnColumns)
              objSettings.ColumnStyles.Add(new ColumnStyle(objSizeType, fltValue));
            else
              objSettings.RowStyles.Add(new RowStyle(objSizeType, fltValue));
          }
        }
      }
    }
  }
}
