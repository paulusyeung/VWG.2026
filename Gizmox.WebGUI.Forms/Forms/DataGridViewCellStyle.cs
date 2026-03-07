// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewCellStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Serialization;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the formatting and style information applied to individual cells within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
  /// <filterpriority>2</filterpriority>
  [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
  [TypeConverter(typeof (DataGridViewCellStyleConverter))]
  [Serializable]
  public class DataGridViewCellStyle : SerializableObject, ICloneable
  {
    private const string DATAGRIDVIEWCELLSTYLE_nullText = "";
    private DataGridViewCellStyleScopes menmScope;
    private DataGridView mobjDataGridView;
    private DataGridViewTriState menmWrapMode;
    private object mobjTag;
    private Padding mobjPadding = Padding.Empty;
    private object mobjNullValue = (object) string.Empty;
    private object mobjFormat;
    private DataGridViewContentAlignment menmAlignment;
    private Color mobjSelectionForeColor = Color.Empty;
    private Color mobjSelectionBackColor = Color.Empty;
    private object mobjFormatProvider;
    private Color mobjForeColor = Color.Empty;
    private SerializableFont mobjFont;
    private Color mobjBackColor = Color.Empty;
    private object mobjDataSourceNullValue = (object) DBNull.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle" /> class.
    /// </summary>
    public DataGridViewCellStyle() => this.Scope = DataGridViewCellStyleScopes.None;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> class using the property values of the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used as a template to provide initial property values. </param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
    public DataGridViewCellStyle(DataGridViewCellStyle objDataGridViewCellStyle)
    {
      if (objDataGridViewCellStyle == null)
        throw new ArgumentNullException("dataGridViewCellStyle");
      this.Scope = DataGridViewCellStyleScopes.None;
      this.BackColor = objDataGridViewCellStyle.BackColor;
      this.ForeColor = objDataGridViewCellStyle.ForeColor;
      this.SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
      this.SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
      this.Font = objDataGridViewCellStyle.Font;
      this.NullValue = objDataGridViewCellStyle.NullValue;
      this.DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
      this.Format = objDataGridViewCellStyle.Format;
      if (!objDataGridViewCellStyle.IsFormatProviderDefault)
        this.FormatProvider = objDataGridViewCellStyle.FormatProvider;
      this.AlignmentInternal = objDataGridViewCellStyle.Alignment;
      this.WrapModeInternal = objDataGridViewCellStyle.WrapMode;
      this.Tag = objDataGridViewCellStyle.Tag;
      this.PaddingInternal = objDataGridViewCellStyle.Padding;
    }

    /// <summary>Called when [property changed].</summary>
    /// <param name="enmProperty">The property.</param>
    private void OnPropertyChanged(
      DataGridViewCellStyle.DataGridViewCellStylePropertyInternal enmProperty)
    {
      DataGridView dataGridView = this.DataGridView;
      if (dataGridView == null || this.Scope == DataGridViewCellStyleScopes.None)
        return;
      dataGridView.OnCellStyleContentChanged(this, enmProperty);
    }

    internal void AddScope(DataGridView objDataGridView, DataGridViewCellStyleScopes enmScope)
    {
      this.Scope |= enmScope;
      this.DataGridView = objDataGridView;
    }

    /// <summary>Applies the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</param>
    /// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
    /// <filterpriority>1</filterpriority>
    public virtual void ApplyStyle(DataGridViewCellStyle objDataGridViewCellStyle)
    {
      if (objDataGridViewCellStyle == null)
        throw new ArgumentNullException("dataGridViewCellStyle");
      if (!objDataGridViewCellStyle.BackColor.IsEmpty)
        this.BackColor = objDataGridViewCellStyle.BackColor;
      if (!objDataGridViewCellStyle.ForeColor.IsEmpty)
        this.ForeColor = objDataGridViewCellStyle.ForeColor;
      if (!objDataGridViewCellStyle.SelectionBackColor.IsEmpty)
        this.SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
      if (!objDataGridViewCellStyle.SelectionForeColor.IsEmpty)
        this.SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
      if (objDataGridViewCellStyle.Font != null)
        this.Font = objDataGridViewCellStyle.Font;
      if (!objDataGridViewCellStyle.IsNullValueDefault)
        this.NullValue = objDataGridViewCellStyle.NullValue;
      if (!objDataGridViewCellStyle.IsDataSourceNullValueDefault)
        this.DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
      if (objDataGridViewCellStyle.Format.Length != 0)
        this.Format = objDataGridViewCellStyle.Format;
      if (!objDataGridViewCellStyle.IsFormatProviderDefault)
        this.FormatProvider = objDataGridViewCellStyle.FormatProvider;
      if (objDataGridViewCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
        this.AlignmentInternal = objDataGridViewCellStyle.Alignment;
      if (objDataGridViewCellStyle.WrapMode != DataGridViewTriState.NotSet)
        this.WrapModeInternal = objDataGridViewCellStyle.WrapMode;
      if (objDataGridViewCellStyle.Tag != null)
        this.Tag = objDataGridViewCellStyle.Tag;
      if (!(objDataGridViewCellStyle.Padding != Padding.Empty))
        return;
      this.PaddingInternal = objDataGridViewCellStyle.Padding;
    }

    /// <summary>Creates an exact copy of this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents an exact copy of this cell style.</returns>
    public virtual DataGridViewCellStyle Clone() => new DataGridViewCellStyle(this);

    /// <summary>Returns a value indicating whether this instance is equivalent to the specified object.</summary>
    /// <returns>true if o is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> and has the same property values as this instance; otherwise, false.</returns>
    /// <param name="o">An object to compare with this instance, or null. </param>
    /// <filterpriority>1</filterpriority>
    public override bool Equals(object obj) => obj is DataGridViewCellStyle objDataGridViewCellStyle && this.GetDifferencesFrom(objDataGridViewCellStyle) == DataGridViewCellStyleDifferences.None;

    /// <summary>Gets the differences from.</summary>
    /// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
    /// <returns></returns>
    internal DataGridViewCellStyleDifferences GetDifferencesFrom(
      DataGridViewCellStyle objDataGridViewCellStyle)
    {
      int num = objDataGridViewCellStyle.Alignment != this.Alignment || objDataGridViewCellStyle.DataSourceNullValue != this.DataSourceNullValue || objDataGridViewCellStyle.Font != this.Font || objDataGridViewCellStyle.Format != this.Format || objDataGridViewCellStyle.FormatProvider != this.FormatProvider || objDataGridViewCellStyle.NullValue != this.NullValue || objDataGridViewCellStyle.Padding != this.Padding || objDataGridViewCellStyle.Tag != this.Tag ? 1 : (objDataGridViewCellStyle.WrapMode != this.WrapMode ? 1 : 0);
      bool flag = objDataGridViewCellStyle.BackColor != this.BackColor || objDataGridViewCellStyle.ForeColor != this.ForeColor || objDataGridViewCellStyle.SelectionBackColor != this.SelectionBackColor || objDataGridViewCellStyle.SelectionForeColor != this.SelectionForeColor;
      if (num != 0)
        return DataGridViewCellStyleDifferences.AffectPreferredSize;
      return flag ? DataGridViewCellStyleDifferences.DoNotAffectPreferredSize : DataGridViewCellStyleDifferences.None;
    }

    /// <summary>Removes the scope.</summary>
    /// <param name="scope">The scope.</param>
    internal void RemoveScope(DataGridViewCellStyleScopes scope)
    {
      this.Scope &= ~scope;
      if (this.Scope != DataGridViewCellStyleScopes.None)
        return;
      this.DataGridView = (DataGridView) null;
    }

    internal bool ShouldSerializeBackColor() => this.mobjBackColor != Color.Empty;

    internal bool ShouldSerializeFont() => this.mobjFont != null;

    internal bool ShouldSerializeForeColor() => this.mobjForeColor != Color.Empty;

    internal bool ShouldSerializeFormatProvider() => this.mobjFormatProvider != null;

    internal bool ShouldSerializePadding() => this.Padding != Padding.Empty;

    internal bool ShouldSerializeSelectionBackColor() => this.mobjSelectionBackColor != Color.Empty;

    internal bool ShouldSerializeSelectionForeColor() => this.mobjSelectionForeColor != Color.Empty;

    internal bool ShouldSerializeAlignment() => this.menmAlignment != 0;

    object ICloneable.Clone() => (object) this.Clone();

    /// <summary>Returns a string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <returns>A string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(128);
      stringBuilder.Append("DataGridViewCellStyle {");
      bool flag = true;
      if (this.BackColor != Color.Empty)
      {
        stringBuilder.Append(" BackColor=" + this.BackColor.ToString());
        flag = false;
      }
      if (this.ForeColor != Color.Empty)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" ForeColor=" + this.ForeColor.ToString());
        flag = false;
      }
      if (this.SelectionBackColor != Color.Empty)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" SelectionBackColor=" + this.SelectionBackColor.ToString());
        flag = false;
      }
      if (this.SelectionForeColor != Color.Empty)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" SelectionForeColor=" + this.SelectionForeColor.ToString());
        flag = false;
      }
      if (this.Font != null)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" Font=" + this.Font.ToString());
        flag = false;
      }
      if (!this.IsNullValueDefault && this.NullValue != null)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" NullValue=" + this.NullValue.ToString());
        flag = false;
      }
      if (!this.IsDataSourceNullValueDefault && this.DataSourceNullValue != null)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" DataSourceNullValue=" + this.DataSourceNullValue.ToString());
        flag = false;
      }
      if (!CommonUtils.IsNullOrEmpty(this.Format))
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" Format=" + this.Format);
        flag = false;
      }
      if (this.WrapMode != DataGridViewTriState.NotSet)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" WrapMode=" + this.WrapMode.ToString());
        flag = false;
      }
      if (this.Alignment != DataGridViewContentAlignment.NotSet)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" Alignment=" + this.Alignment.ToString());
        flag = false;
      }
      if (this.Padding != Padding.Empty)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" Padding=" + this.Padding.ToString());
        flag = false;
      }
      if (this.Tag != null)
      {
        if (!flag)
          stringBuilder.Append(",");
        stringBuilder.Append(" Tag=" + this.Tag.ToString());
      }
      stringBuilder.Append(" }");
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets the data grid view.</summary>
    /// <value>The data grid view.</value>
    private DataGridView DataGridView
    {
      get => this.mobjDataGridView;
      set => this.mobjDataGridView = value;
    }

    /// <summary>Gets or sets a value indicating the position of the cell content within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewContentAlignment.NotSet"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    [SRDescription("DataGridViewCellStyleAlignmentDescr")]
    [DefaultValue(DataGridViewContentAlignment.NotSet)]
    [SRCategory("CatLayout")]
    public DataGridViewContentAlignment Alignment
    {
      get => this.menmAlignment;
      set
      {
        switch (value)
        {
          case DataGridViewContentAlignment.NotSet:
          case DataGridViewContentAlignment.TopLeft:
          case DataGridViewContentAlignment.TopCenter:
          case DataGridViewContentAlignment.TopRight:
          case DataGridViewContentAlignment.MiddleLeft:
          case DataGridViewContentAlignment.MiddleCenter:
          case DataGridViewContentAlignment.MiddleRight:
          case DataGridViewContentAlignment.BottomLeft:
          case DataGridViewContentAlignment.BottomCenter:
          case DataGridViewContentAlignment.BottomRight:
            this.AlignmentInternal = value;
            break;
          default:
            throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewContentAlignment));
        }
      }
    }

    internal DataGridViewContentAlignment AlignmentInternal
    {
      set
      {
        if (this.Alignment == value)
          return;
        this.menmAlignment = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    public Color BackColor
    {
      get => this.mobjBackColor;
      set
      {
        Color mobjBackColor1 = this.mobjBackColor;
        Color mobjBackColor2 = this.mobjBackColor;
        if (this.mobjBackColor.Equals((object) value))
          return;
        this.mobjBackColor = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Color);
      }
    }

    /// <summary>Gets or sets the value saved to the data source when the user enters a null value into a cell.</summary>
    /// <returns>The value saved to the data source when the user specifies a null cell value. The default is <see cref="F:System.DBNull.Value"></see>.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object DataSourceNullValue
    {
      get => this.mobjDataSourceNullValue;
      set
      {
        object dataSourceNullValue = this.DataSourceNullValue;
        if (dataSourceNullValue == value || dataSourceNullValue != null && dataSourceNullValue.Equals(value))
          return;
        this.mobjDataSourceNullValue = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <returns>The <see cref="T:System.Drawing.Font"></see> applied to the cell text. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    public Font Font
    {
      get => (Font) this.mobjFont;
      set
      {
        if ((this.mobjFont != null || value == null) && (this.mobjFont == null || this.mobjFont.Equals((object) (SerializableFont) value)))
          return;
        this.mobjFont = (SerializableFont) value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Font);
      }
    }

    /// <summary>Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    public Color ForeColor
    {
      get => this.mobjForeColor;
      set
      {
        Color mobjForeColor1 = this.mobjForeColor;
        Color mobjForeColor2 = this.mobjForeColor;
        if (this.mobjForeColor.Equals((object) value))
          return;
        this.mobjForeColor = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.ForeColor);
      }
    }

    /// <summary>Gets or sets the format string applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <returns>A string that indicates the format of the cell value. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    [DefaultValue("")]
    [SRCategory("CatBehavior")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string Format
    {
      get => (string) this.mobjFormat ?? string.Empty;
      set
      {
        string format1 = this.Format;
        this.mobjFormat = (object) value;
        string format2 = this.Format;
        if (format1.Equals(format2))
          return;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets or sets the object used to provide culture-specific formatting of <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell values.</summary>
    /// <returns>An <see cref="T:System.IFormatProvider"></see> used for cell formatting. The default is <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public IFormatProvider FormatProvider
    {
      get
      {
        if (this.mobjFormatProvider == null)
        {
          IContext current = VWGContext.Current;
          if (current != null)
            return (IFormatProvider) current.CurrentUICulture;
        }
        return this.mobjFormatProvider as IFormatProvider;
      }
      set
      {
        if (value == this.mobjFormatProvider)
          return;
        this.mobjFormatProvider = (object) value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property has been set.</summary>
    /// <returns>true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property is the default value; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public bool IsDataSourceNullValueDefault => this.mobjDataSourceNullValue == DBNull.Value;

    /// <summary>Gets a value that indicates whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property has been set.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property is the default value; otherwise, false.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public bool IsFormatProviderDefault => this.mobjFormatProvider == null;

    /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property has been set.</summary>
    /// <returns>true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property is the default value; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    public bool IsNullValueDefault => this.mobjNullValue is string && this.mobjNullValue.Equals((object) "");

    /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell display value corresponding to a cell value of <see cref="F:System.DBNull.Value"></see> or null.</summary>
    /// <returns>The object used to indicate a null value in a cell. The default is <see cref="F:System.String.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatData")]
    [DefaultValue("")]
    [TypeConverter(typeof (StringConverter))]
    public object NullValue
    {
      get => this.mobjNullValue;
      set
      {
        object nullValue = this.NullValue;
        if (this.mobjNullValue == value)
          return;
        this.mobjNullValue = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets or sets the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatLayout")]
    public Padding Padding
    {
      get => this.mobjPadding;
      set
      {
        if (value.Left < 0 || value.Right < 0 || value.Top < 0 || value.Bottom < 0)
        {
          if (value.All != -1)
          {
            value.All = 0;
          }
          else
          {
            value.Left = Math.Max(0, value.Left);
            value.Right = Math.Max(0, value.Right);
            value.Top = Math.Max(0, value.Top);
            value.Bottom = Math.Max(0, value.Bottom);
          }
        }
        this.PaddingInternal = value;
      }
    }

    internal Padding PaddingInternal
    {
      set
      {
        if (!(this.mobjPadding != value))
          return;
        this.mobjPadding = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    /// <summary>Gets or sets the scope.</summary>
    /// <value>The scope.</value>
    internal DataGridViewCellStyleScopes Scope
    {
      get => this.menmScope;
      set => this.menmScope = value;
    }

    /// <summary>Gets or sets the background color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    public Color SelectionBackColor
    {
      get => this.mobjSelectionBackColor;
      set
      {
        Color selectionBackColor1 = this.mobjSelectionBackColor;
        Color selectionBackColor2 = this.mobjSelectionBackColor;
        if (this.mobjSelectionBackColor.Equals((object) value))
          return;
        this.mobjSelectionBackColor = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Color);
      }
    }

    /// <summary>Gets or sets the foreground color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatAppearance")]
    public Color SelectionForeColor
    {
      get => this.mobjSelectionForeColor;
      set
      {
        Color selectionForeColor1 = this.mobjSelectionForeColor;
        Color selectionForeColor2 = this.mobjSelectionForeColor;
        if (this.mobjSelectionForeColor.Equals((object) value))
          return;
        this.mobjSelectionForeColor = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Color);
      }
    }

    /// <summary>Gets or sets an object that contains additional data related to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
    /// <returns>An object that contains additional data. The default is null.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object Tag
    {
      get => this.mobjTag;
      set => this.mobjTag = value;
    }

    /// <summary>Gets or sets a value indicating whether textual content in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell is wrapped to subsequent lines or truncated when it is too long to fit on a single line.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.NotSet"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(DataGridViewTriState.NotSet)]
    [SRCategory("CatLayout")]
    public DataGridViewTriState WrapMode
    {
      get => this.menmWrapMode;
      set => this.WrapModeInternal = ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2) ? value : throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (DataGridViewTriState));
    }

    internal DataGridViewTriState WrapModeInternal
    {
      set
      {
        if (this.WrapMode == value)
          return;
        this.menmWrapMode = value;
        this.OnPropertyChanged(DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Other);
      }
    }

    [Serializable]
    internal enum DataGridViewCellStylePropertyInternal
    {
      Color,
      Other,
      Font,
      ForeColor,
    }
  }
}
