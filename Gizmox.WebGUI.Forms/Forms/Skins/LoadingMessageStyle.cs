// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Skins.LoadingMessageStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Skins
{
  /// <summary>
  /// 
  /// </summary>
  [TypeConverter(typeof (LoadingMessageStyle.LoadingMessageStyleConverter))]
  [Serializable]
  public class LoadingMessageStyle
  {
    private HorizontalAlignmentValue menmMessageHorizontalAlignment;
    private VerticalAlignmentValue menmMessageVerticalAlignment;
    private StyleValue mobjMessageStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Skins.LoadingMessageStyle" /> class.
    /// </summary>
    /// <param name="enmMessageVerticalAlignment">The enm message vertical alignment.</param>
    /// <param name="enmMessageHorizontalAlignment">The enm message horizontal alignment.</param>
    /// <param name="objMessageStyle">The obj message style.</param>
    public LoadingMessageStyle(
      VerticalAlignmentValue enmMessageVerticalAlignment,
      HorizontalAlignmentValue enmMessageHorizontalAlignment,
      StyleValue objMessageStyle)
    {
      this.menmMessageVerticalAlignment = enmMessageVerticalAlignment;
      this.menmMessageHorizontalAlignment = enmMessageHorizontalAlignment;
      this.mobjMessageStyle = objMessageStyle;
    }

    /// <summary>Gets or sets the message horizontal alignment.</summary>
    /// <value>The message horizontal alignment.</value>
    public HorizontalAlignmentValue MessageHorizontalAlignment
    {
      get => this.menmMessageHorizontalAlignment;
      set => this.menmMessageHorizontalAlignment = value;
    }

    /// <summary>Gets or sets the message style.</summary>
    /// <value>The message style.</value>
    public StyleValue MessageStyle
    {
      get => this.mobjMessageStyle;
      set => this.mobjMessageStyle = value;
    }

    /// <summary>Gets or sets the message vertical alignment.</summary>
    /// <value>The message vertical alignment.</value>
    public VerticalAlignmentValue MessageVerticalAlignment
    {
      get => this.menmMessageVerticalAlignment;
      set => this.menmMessageVerticalAlignment = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public class LoadingMessageStyleConverter : TypeConverter
    {
      /// <summary>
      /// Returns whether this object supports properties, using the specified context.
      /// </summary>
      /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
      /// <returns>
      /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)" /> should be called to find the properties of this object; otherwise, false.
      /// </returns>
      public override bool GetPropertiesSupported(ITypeDescriptorContext objContext) => true;

      /// <summary>
      /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
      /// </summary>
      /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
      /// <param name="objValue">An <see cref="T:System.Object" /> that specifies the type of array for which to get properties.</param>
      /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute" /> that is used as a filter.</param>
      /// <returns>
      /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for this data type, or null if there are no properties.
      /// </returns>
      public override PropertyDescriptorCollection GetProperties(
        ITypeDescriptorContext objContext,
        object objValue,
        Attribute[] arrAttributes)
      {
        return TypeDescriptor.GetProperties(typeof (LoadingMessageStyle), arrAttributes).Sort(new string[3]
        {
          "MessageStyle",
          "MessageHorizontalAlignment",
          "MessageVerticalAlignment"
        });
      }
    }
  }
}
