// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.CreateParams
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Encapsulates the information needed when creating a control.</summary>
  [Serializable]
  public class CreateParams : SerializableObject
  {
    private static readonly SerializableProperty mstrCaptionProperty = SerializableProperty.Register(nameof (mstrCaption), typeof (string), typeof (CreateParams));
    private static readonly SerializableProperty mstrClassNameProperty = SerializableProperty.Register(nameof (mstrClassName), typeof (string), typeof (CreateParams));
    private static readonly SerializableProperty mstrClassStyleProperty = SerializableProperty.Register(nameof (mstrClassStyle), typeof (int), typeof (CreateParams));
    private static readonly SerializableProperty mintHeightProperty = SerializableProperty.Register(nameof (mintHeight), typeof (int), typeof (CreateParams));
    private static readonly SerializableProperty mobjParamProperty = SerializableProperty.Register(nameof (mobjParam), typeof (object), typeof (CreateParams));
    private static readonly SerializableProperty mintWidthProperty = SerializableProperty.Register(nameof (mintWidth), typeof (int), typeof (CreateParams));
    private static readonly SerializableProperty mintXProperty = SerializableProperty.Register(nameof (mintX), typeof (int), typeof (CreateParams));
    private static readonly SerializableProperty mintYProperty = SerializableProperty.Register(nameof (mintY), typeof (int), typeof (CreateParams));

    private string mstrCaption
    {
      get => this.GetValue<string>(CreateParams.mstrCaptionProperty);
      set => this.SetValue<string>(CreateParams.mstrCaptionProperty, value);
    }

    private string mstrClassName
    {
      get => this.GetValue<string>(CreateParams.mstrClassNameProperty);
      set => this.SetValue<string>(CreateParams.mstrClassNameProperty, value);
    }

    private int mstrClassStyle
    {
      get => this.GetValue<int>(CreateParams.mstrClassStyleProperty);
      set => this.SetValue<int>(CreateParams.mstrClassStyleProperty, value);
    }

    private int mintHeight
    {
      get => this.GetValue<int>(CreateParams.mintHeightProperty);
      set => this.SetValue<int>(CreateParams.mintHeightProperty, value);
    }

    private object mobjParam
    {
      get => this.GetValue<object>(CreateParams.mobjParamProperty);
      set => this.SetValue<object>(CreateParams.mobjParamProperty, value);
    }

    private int mintWidth
    {
      get => this.GetValue<int>(CreateParams.mintWidthProperty);
      set => this.SetValue<int>(CreateParams.mintWidthProperty, value);
    }

    private int mintX
    {
      get => this.GetValue<int>(CreateParams.mintXProperty);
      set => this.SetValue<int>(CreateParams.mintXProperty, value);
    }

    private int mintY
    {
      get => this.GetValue<int>(CreateParams.mintYProperty);
      set => this.SetValue<int>(CreateParams.mintYProperty, value);
    }

    /// <summary>Gets or sets the control's initial text.</summary>
    /// <returns>The control's initial text.</returns>
    /// <filterpriority>1</filterpriority>
    public string Caption
    {
      get => this.mstrCaption;
      set => this.mstrCaption = value;
    }

    /// <summary>Gets or sets the name of the Windows class to derive the control from.</summary>
    /// <returns>The name of the Windows class to derive the control from.</returns>
    /// <filterpriority>1</filterpriority>
    public string ClassName
    {
      get => this.mstrClassName;
      set => this.mstrClassName = value;
    }

    /// <summary>Gets or sets a bitwise combination of class style values.</summary>
    /// <returns>A bitwise combination of the class style values.</returns>
    /// <filterpriority>1</filterpriority>
    public int ClassStyle
    {
      get => this.mstrClassStyle;
      set => this.mstrClassStyle = value;
    }

    /// <summary>Gets or sets a bitwise combination of extended window style values.</summary>
    /// <returns>A bitwise combination of the extended window style values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ExStyle
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the initial height of the control.</summary>
    /// <returns>The numeric value that represents the initial height of the control.</returns>
    /// <filterpriority>1</filterpriority>
    public int Height
    {
      get => this.mintHeight;
      set => this.mintHeight = value;
    }

    /// <summary>Gets or sets additional parameter information needed to create the control.</summary>
    /// <returns>The <see cref="T:System.Object"></see> that holds additional parameter information needed to create the control.</returns>
    /// <filterpriority>1</filterpriority>
    public object Param
    {
      get => this.mobjParam;
      set => this.mobjParam = value;
    }

    /// <summary>Gets or sets the control's parent.</summary>
    /// <returns>An <see cref="T:System.IntPtr"></see> that contains the window handle of the control's parent.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IntPtr Parent
    {
      get => IntPtr.Zero;
      set
      {
      }
    }

    /// <summary>Gets or sets a bitwise combination of window style values.</summary>
    /// <returns>A bitwise combination of the window style values.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int Style
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the initial width of the control.</summary>
    /// <returns>The numeric value that represents the initial width of the control.</returns>
    /// <filterpriority>1</filterpriority>
    public int Width
    {
      get => this.mintWidth;
      set => this.mintWidth = value;
    }

    /// <summary>Gets or sets the initial left position of the control.</summary>
    /// <returns>The numeric value that represents the initial left position of the control.</returns>
    /// <filterpriority>1</filterpriority>
    public int X
    {
      get => this.mintX;
      set => this.mintX = value;
    }

    /// <summary>Gets or sets the top position of the initial location of the control.</summary>
    /// <returns>The numeric value that represents the top position of the initial location of the control.</returns>
    /// <filterpriority>1</filterpriority>
    public int Y
    {
      get => this.mintY;
      set => this.mintY = value;
    }
  }
}
