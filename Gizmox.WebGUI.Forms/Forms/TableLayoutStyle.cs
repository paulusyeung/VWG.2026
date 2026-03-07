// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TableLayoutStyle
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [TypeConverter(typeof (TableLayoutSettings.StyleConverter))]
  [Serializable]
  public abstract class TableLayoutStyle : IObservableItem
  {
    private IArrangedElement mobjOwner;
    private float mfltSize;
    private SizeType menmSizeType;

    internal IArrangedElement Owner
    {
      get => this.mobjOwner;
      set
      {
        if (this.mobjOwner == value)
          return;
        this.mobjOwner = value;
        this.FireObservableItemPropertyChanged(nameof (Owner));
      }
    }

    internal float Size
    {
      get => this.mfltSize;
      set
      {
        if ((double) value < 0.0)
          throw new ArgumentOutOfRangeException(nameof (Size), SR.GetString("InvalidLowBoundArgumentEx", (object) nameof (Size), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture), (object) 0.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if ((double) this.mfltSize == (double) value)
          return;
        this.mfltSize = value;
        this.FireObservableItemPropertyChanged(nameof (Size));
        if (this.Owner == null || !(this.Owner is Control owner))
          return;
        owner.OnResizeInternal(new LayoutEventArgs(false, true, true));
        owner.Invalidate();
      }
    }

    /// <summary>Gets or sets the type of the size.</summary>
    /// <value>The type of the size.</value>
    [DefaultValue(0)]
    public SizeType SizeType
    {
      get => this.menmSizeType;
      set
      {
        if (this.menmSizeType == value)
          return;
        this.menmSizeType = value;
        this.FireObservableItemPropertyChanged(nameof (SizeType));
        if (this.Owner == null || !(this.Owner is Control owner))
          return;
        owner.Invalidate();
      }
    }

    private bool ShouldSerializeSize() => this.SizeType != 0;

    internal void SetSize(float fltSize) => this.mfltSize = fltSize;

    /// <summary>
    /// Property change indicator for the observable item interface
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public event ObservableItemPropertyChangedHandler ObservableItemPropertyChanged;

    /// <summary>
    /// Fires the ObservableItemPropertyChanged event of the IObservableItem interface.
    /// </summary>
    /// <param name="strProperty">The name of the property that has changed</param>
    protected void FireObservableItemPropertyChanged(string strProperty)
    {
      if (this.ObservableItemPropertyChanged == null)
        return;
      this.ObservableItemPropertyChanged((object) this, new ObservableItemPropertyChangedArgs(strProperty));
    }
  }
}
