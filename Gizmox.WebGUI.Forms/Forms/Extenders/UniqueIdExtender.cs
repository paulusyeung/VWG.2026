// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Extenders.UniqueIdExtender
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Extenders
{
  /// <summary>
  /// 	<para>UniqueIdExtender adds the ability to sets a unique id to a control.</para>
  /// 	<para>Since Visual WebGui optimizes its requests we can not lean on the internal
  ///     ids of components specified by the server.</para>
  /// 	<para>By uniquely identifying anchor components, we ensure that those Ids will be
  ///     sent back from the server at any response so that we would be able to lean on ids
  ///     in order to create valuable replays.</para>
  /// </summary>
  /// <example>
  ///     This shows how to use a <span style="COLOR: #2b91af">UniqueIdExtender</span> and
  ///     anchor controls to a spesific id.
  ///     <code lang="CS">
  /// 		<![CDATA[
  ///     //Create a global unique Identifiers extender object:
  /// 
  ///     UniqueIdExtender mobjUniqueIdExtender = new UniqueIdExtender();
  /// 
  ///     //Then use it to set Unique-Ids to your anchor components and items:
  /// 
  ///     mobjUniqueIdExtender.SetUniqueId(button1, "B1");
  /// 
  ///     //If you are using control with children controls such as DataGrid or ListView
  ///     //remember to unique identify all created items
  /// 
  ///     DataClasses1DataContext objDataClasses = new DataClasses1DataContext();
  ///     foreach (Employee objEmployee in objDataClasses.Employees)
  ///     {
  ///         ListViewItem mobjListViewItem = new ListViewItem(new string[]
  ///             {objEmployee.EmployeeID.ToString(), objEmployee.FirstName, objEmployee.LastName,
  ///             objEmployee.Title, objEmployee.Country});
  ///         mobjUniqueIdExtender.SetUniqueId(listView1,string.Format("LI{0}", objEmployee.EmployeeID));
  /// 
  ///         listView1.Items.Add(mobjListViewItem);
  ///     }
  ///     ]]>
  /// 	</code>
  /// 	<code lang="VB">
  /// 		<![CDATA[
  ///     'Create a global unique Identifiers extender object:
  /// 
  ///     Dim mobjUniqueIdExtender As New UniqueIdExtender()
  /// 
  ///     'Then use it to set Unique-Ids to your anchor components and items:
  /// 
  ///     mobjUniqueIdExtender.SetUniqueId(Button1, "B1")
  /// 
  ///     'If you are using control with children controls such as DataGrid or ListView
  ///     'remember to unique identify all created items
  ///     Dim objDataClasses As New DataClasses1DataContext()
  /// 
  ///     For Each objEmployee As Employee In objDataClasses.Employees
  ///         Dim mobjListViewItem As New ListViewItem(New String() {objEmployee.EmployeeID.ToString(), objEmployee.FirstName, objEmployee.LastName, objEmployee.Title, objEmployee.Country})
  ///         mobjUniqueIdExtender.SetUniqueId(ListView1, String.Format("LI{0}", objEmployee.EmployeeID))
  ///         ListView1.Items.Add(mobjListViewItem)
  ///     Next]]>
  /// 	</code>
  /// </example>
  /// <requirements>
  /// 	<para>You nee to add a using/import to <font size="2">Gizmox.WebGUI.Forms.Extenders
  ///     to the form</font></para>
  /// </requirements>
  [ProvideProperty("UniqueId", typeof (Gizmox.WebGUI.Forms.Component))]
  [ToolboxItem(false)]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [Serializable]
  public class UniqueIdExtender : ComponentBase, IExtenderProvider
  {
    /// <summary>Sets the unique id.</summary>
    /// <param name="objComponent">The component.</param>
    /// <param name="strId">The unique id.</param>
    public void SetUniqueId(Gizmox.WebGUI.Forms.Component objComponent, string strId) => ((IAttributeExtender) objComponent)?.SetAttribute("CUID", strId);

    /// <summary>Gets the unique id.</summary>
    /// <param name="objComponent">The component.</param>
    /// <returns></returns>
    [Description("Defines the component unique id.")]
    [DefaultValue("")]
    public string GetUniqueId(Gizmox.WebGUI.Forms.Component objComponent)
    {
      IAttributeExtender attributeExtender = (IAttributeExtender) objComponent;
      return attributeExtender != null ? attributeExtender.GetAttribute("CUID") : string.Empty;
    }

    /// <summary>
    /// Specifies whether this object can provide its extender properties to the specified object.
    /// </summary>
    /// <param name="objExtendee">The <see cref="T:System.Object" /> to receive the extender properties.</param>
    /// <returns>
    /// true if this object can provide extender properties to the specified object; otherwise, false.
    /// </returns>
    public bool CanExtend(object objExtendee) => objExtendee is Gizmox.WebGUI.Forms.Component;
  }
}
