// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FormCollection
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>A form collection class</summary>
  [Serializable]
  internal class FormCollection : CollectionBase
  {
    /// <summary>InternalParent form</summary>
    private Form mobjParent;
    private bool mblnHasModal;
    private Form mobjModalForm;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FormCollection" /> class.
    /// </summary>
    /// <param name="objParent">The parent.</param>
    internal FormCollection(Form objParent) => this.mobjParent = objParent;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.FormCollection" /> class.
    /// </summary>
    /// <param name="objParent">The parent.</param>
    /// <param name="objForms">The forms.</param>
    internal FormCollection(Form objParent, object[] arrForms)
    {
      this.mobjParent = objParent;
      this.InnerList.AddRange((ICollection) arrForms);
    }

    /// <summary>Containses the specified form.</summary>
    /// <param name="objForm">form.</param>
    /// <returns></returns>
    public bool Contains(Form objForm) => this.List.Contains((object) objForm);

    /// <summary>Adds the specified obj form.</summary>
    /// <param name="objForm">The obj form.</param>
    /// <returns></returns>
    internal int Add(Form objForm)
    {
      if (this.HasModal && objForm.Modal)
        return -1;
      objForm.OwnerInternal = this.mobjParent;
      if (!objForm.TopLevel && objForm.Modal)
      {
        this.mblnHasModal = true;
        this.mobjModalForm = objForm;
      }
      int num = this.List.Add((object) objForm);
      this.mobjParent.OnFormAdded(objForm);
      return num;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objForm"></param>
    internal void Remove(Form objForm)
    {
      if (objForm.Modal)
      {
        this.mblnHasModal = false;
        this.mobjModalForm = (Form) null;
      }
      if (!this.List.Contains((object) objForm))
        return;
      this.List.Remove((object) objForm);
      this.mobjParent.OnFormRemoved(objForm);
    }

    /// <summary>Set form's position.</summary>
    /// <param name="objForm">The form.</param>
    /// <param name="intIndex">Index of the form.</param>
    internal void SetFormPosition(Form objForm, int intIndex)
    {
      if (objForm == null || !this.List.Contains((object) objForm) || this.List.IndexOf((object) objForm) == intIndex || intIndex < 0 || intIndex >= this.List.Count)
        return;
      this.List.Remove((object) objForm);
      this.List.Insert(intIndex, (object) objForm);
    }

    /// <summary>Indexes the of.</summary>
    /// <param name="objForm">The obj form.</param>
    /// <returns></returns>
    public int IndexOf(Form objForm) => this.InnerList.IndexOf((object) objForm);

    /// <summary>
    /// Gets a value indicating whether this window has modal child window.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has modal; otherwise, <c>false</c>.
    /// </value>
    public bool HasModal => this.mblnHasModal;
  }
}
