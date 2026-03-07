// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ICurrencyManagerProvider
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides custom binding management for components.</summary>
  /// <filterpriority>2</filterpriority>
  [SRDescription("ICurrencyManagerProviderDescr")]
  public interface ICurrencyManagerProvider
  {
    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> for this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see> and the specified data member.</summary>
    /// <returns>The related <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> obtained from this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see> and the specified data member.</returns>
    /// <param name="strDataMember">The name of the column or list, within the data source, to obtain the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> for.</param>
    CurrencyManager GetRelatedCurrencyManager(string strDataMember);

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see>. </summary>
    /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> associated with this <see cref="T:Gizmox.WebGUI.Forms.ICurrencyManagerProvider"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    CurrencyManager CurrencyManager { get; }
  }
}
