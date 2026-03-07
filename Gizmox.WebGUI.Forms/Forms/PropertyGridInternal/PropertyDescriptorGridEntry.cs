// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PropertyGridInternal.PropertyDescriptorGridEntry
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
  [Serializable]
  internal class PropertyDescriptorGridEntry : GridEntry
  {
    private static IEventBindingService mobjTargetBindingService;
    private static IComponent mobjTargetComponent;
    private static EventDescriptor mobjTargetEventDescriptor;
    private const byte mParensAroundNameNo = 0;
    private const byte mParensAroundNameUnknown = 255;
    private const byte mParensAroundNameYes = 1;
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty mblnActiveXHideProperty = SerializableProperty.Register(nameof (mblnActiveXHide), typeof (bool), typeof (PropertyDescriptorGridEntry));
    /// <summary>The IEventBindingService property registration.</summary>
    private static readonly SerializableProperty mobjEventBindingsProperty = SerializableProperty.Register(nameof (mobjEventBindings), typeof (IEventBindingService), typeof (PropertyDescriptorGridEntry));
    /// <summary>
    /// The System.ComponentModel.TypeConverter property registration.
    /// </summary>
    private static readonly SerializableProperty mobjEexceptionConverterProperty = SerializableProperty.Register(nameof (mobjEexceptionConverter), typeof (TypeConverter), typeof (PropertyDescriptorGridEntry));
    /// <summary>
    /// The Gizmox.WebGUI.Forms.Design.WebUITypeEditor property registration.
    /// </summary>
    private static readonly SerializableProperty mobjExceptionEditorProperty = SerializableProperty.Register(nameof (mobjExceptionEditor), typeof (WebUITypeEditor), typeof (PropertyDescriptorGridEntry));
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty mblnForceRenderReadOnlyProperty = SerializableProperty.Register(nameof (mblnForceRenderReadOnly), typeof (bool), typeof (PropertyDescriptorGridEntry));
    /// <summary>The string property registration.</summary>
    private static readonly SerializableProperty mstrHelpKeywordProperty = SerializableProperty.Register(nameof (mstrHelpKeyword), typeof (string), typeof (PropertyDescriptorGridEntry));
    private const int IMAGE_SIZE = 8;
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty mblnIsSerializeContentsPropProperty = SerializableProperty.Register(nameof (mblnIsSerializeContentsProp), typeof (bool), typeof (PropertyDescriptorGridEntry));
    /// <summary>The byte property registration.</summary>
    private static readonly SerializableProperty mParensAroundNameProperty = SerializableProperty.Register(nameof (mParensAroundName), typeof (byte), typeof (PropertyDescriptorGridEntry));
    /// <summary>
    /// The System.ComponentModel.PropertyDescriptor property registration.
    /// </summary>
    private static readonly SerializableProperty mobjPropertyInfoProperty = SerializableProperty.Register(nameof (mobjPropertyInfo), typeof (PropertyDescriptor), typeof (PropertyDescriptorGridEntry));
    /// <summary>The IPropertyValueUIService property registration.</summary>
    private static readonly SerializableProperty mobjPropertyValueUIServiceProperty = SerializableProperty.Register(nameof (mobjPropertyValueUIService), typeof (IPropertyValueUIService), typeof (PropertyDescriptorGridEntry));
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty mobjServiceCheckedProperty = SerializableProperty.Register(nameof (mobjServiceChecked), typeof (bool), typeof (PropertyDescriptorGridEntry));
    /// <summary>The PropertyValueUIItem{} property registration.</summary>
    private static readonly SerializableProperty marrPropertyValueUIItemsProperty = SerializableProperty.Register(nameof (marrPropertyValueUIItems), typeof (PropertyValueUIItem[]), typeof (PropertyDescriptorGridEntry));
    /// <summary>The bool property registration.</summary>
    private static readonly SerializableProperty mblnReadOnlyVerifiedProperty = SerializableProperty.Register(nameof (mblnReadOnlyVerified), typeof (bool), typeof (PropertyDescriptorGridEntry));
    /// <summary>The string property registration.</summary>
    private static readonly SerializableProperty mstrToolTipTextProperty = SerializableProperty.Register(nameof (mstrToolTipText), typeof (string), typeof (PropertyDescriptorGridEntry));

    private bool mblnActiveXHide
    {
      get => this.GetValue<bool>(PropertyDescriptorGridEntry.mblnActiveXHideProperty);
      set => this.SetValue<bool>(PropertyDescriptorGridEntry.mblnActiveXHideProperty, value);
    }

    protected IEventBindingService mobjEventBindings
    {
      get => this.GetValue<IEventBindingService>(PropertyDescriptorGridEntry.mobjEventBindingsProperty);
      set => this.SetValue<IEventBindingService>(PropertyDescriptorGridEntry.mobjEventBindingsProperty, value);
    }

    private TypeConverter mobjEexceptionConverter
    {
      get => this.GetValue<TypeConverter>(PropertyDescriptorGridEntry.mobjEexceptionConverterProperty);
      set => this.SetValue<TypeConverter>(PropertyDescriptorGridEntry.mobjEexceptionConverterProperty, value);
    }

    private WebUITypeEditor mobjExceptionEditor
    {
      get => this.GetValue<WebUITypeEditor>(PropertyDescriptorGridEntry.mobjExceptionEditorProperty);
      set => this.SetValue<WebUITypeEditor>(PropertyDescriptorGridEntry.mobjExceptionEditorProperty, value);
    }

    private bool mblnForceRenderReadOnly
    {
      get => this.GetValue<bool>(PropertyDescriptorGridEntry.mblnForceRenderReadOnlyProperty);
      set => this.SetValue<bool>(PropertyDescriptorGridEntry.mblnForceRenderReadOnlyProperty, value);
    }

    private string mstrHelpKeyword
    {
      get => this.GetValue<string>(PropertyDescriptorGridEntry.mstrHelpKeywordProperty);
      set => this.SetValue<string>(PropertyDescriptorGridEntry.mstrHelpKeywordProperty, value);
    }

    private bool mblnIsSerializeContentsProp
    {
      get => this.GetValue<bool>(PropertyDescriptorGridEntry.mblnIsSerializeContentsPropProperty);
      set => this.SetValue<bool>(PropertyDescriptorGridEntry.mblnIsSerializeContentsPropProperty, value);
    }

    private byte mParensAroundName
    {
      get => this.GetValue<byte>(PropertyDescriptorGridEntry.mParensAroundNameProperty);
      set => this.SetValue<byte>(PropertyDescriptorGridEntry.mParensAroundNameProperty, value);
    }

    internal PropertyDescriptor mobjPropertyInfo
    {
      get => this.GetValue<PropertyDescriptor>(PropertyDescriptorGridEntry.mobjPropertyInfoProperty);
      set => this.SetValue<PropertyDescriptor>(PropertyDescriptorGridEntry.mobjPropertyInfoProperty, value);
    }

    private IPropertyValueUIService mobjPropertyValueUIService
    {
      get => this.GetValue<IPropertyValueUIService>(PropertyDescriptorGridEntry.mobjPropertyValueUIServiceProperty);
      set => this.SetValue<IPropertyValueUIService>(PropertyDescriptorGridEntry.mobjPropertyValueUIServiceProperty, value);
    }

    private bool mobjServiceChecked
    {
      get => this.GetValue<bool>(PropertyDescriptorGridEntry.mobjServiceCheckedProperty);
      set => this.SetValue<bool>(PropertyDescriptorGridEntry.mobjServiceCheckedProperty, value);
    }

    private PropertyValueUIItem[] marrPropertyValueUIItems
    {
      get => this.GetValue<PropertyValueUIItem[]>(PropertyDescriptorGridEntry.marrPropertyValueUIItemsProperty);
      set => this.SetValue<PropertyValueUIItem[]>(PropertyDescriptorGridEntry.marrPropertyValueUIItemsProperty, value);
    }

    private bool mblnReadOnlyVerified
    {
      get => this.GetValue<bool>(PropertyDescriptorGridEntry.mblnReadOnlyVerifiedProperty);
      set => this.SetValue<bool>(PropertyDescriptorGridEntry.mblnReadOnlyVerifiedProperty, value);
    }

    private string mstrToolTipText
    {
      get => this.GetValue<string>(PropertyDescriptorGridEntry.mstrToolTipTextProperty);
      set => this.SetValue<string>(PropertyDescriptorGridEntry.mstrToolTipTextProperty, value);
    }

    internal PropertyDescriptorGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGridEntry,
      bool blnHide)
      : base(objOwnerGrid, objParentGridEntry)
    {
      this.mParensAroundName = byte.MaxValue;
      this.mblnActiveXHide = blnHide;
    }

    internal PropertyDescriptorGridEntry(
      PropertyGrid objOwnerGrid,
      GridEntry objParentGridEntry,
      PropertyDescriptor objPropInfo,
      bool blnHide)
      : base(objOwnerGrid, objParentGridEntry)
    {
      this.mParensAroundName = byte.MaxValue;
      this.mblnActiveXHide = blnHide;
      this.Initialize(objPropInfo);
    }

    /// <summary>
    /// Dispose recursivly
    /// Parent method must be overrided
    /// in order to preserve the member ids
    /// of the children.
    /// </summary>
    public override void DisposeChildren()
    {
    }

    protected override void EditPropertyValue_Callback(object objValue)
    {
      base.EditPropertyValue_Callback(objValue);
      if (this.IsValueEditable)
        return;
      RefreshPropertiesAttribute attribute = (RefreshPropertiesAttribute) this.mobjPropertyInfo.Attributes[typeof (RefreshPropertiesAttribute)];
      if (attribute == null || attribute.RefreshProperties.Equals((object) RefreshProperties.None))
        return;
      this.GridEntryHost.Refresh(attribute != null && attribute.Equals((object) RefreshPropertiesAttribute.All));
    }

    /// <summary>Get property value</summary>
    /// <param name="objTarget">The obj target.</param>
    /// <returns></returns>
    protected object GetPropertyValueCore(object objTarget)
    {
      if (this.mobjPropertyInfo == null)
        return (object) null;
      if (objTarget is ICustomTypeDescriptor)
        objTarget = ((ICustomTypeDescriptor) objTarget).GetPropertyOwner(this.mobjPropertyInfo);
      try
      {
        return this.OwnerGrid.GetPropertyValue(this.mobjPropertyInfo, objTarget);
      }
      catch
      {
        throw;
      }
    }

    protected void Initialize(PropertyDescriptor objPropInfo)
    {
      this.mobjPropertyInfo = objPropInfo;
      this.mblnIsSerializeContentsProp = this.mobjPropertyInfo.SerializationVisibility == DesignerSerializationVisibility.Content;
      if (!this.mblnActiveXHide && this.IsPropertyReadOnly)
        this.SetState(1, false);
      if (!this.mblnIsSerializeContentsProp || !this.TypeConverter.GetPropertiesSupported())
        return;
      this.SetState(131072, true);
    }

    protected virtual void NotifyParentChange(GridEntry objGridEntry)
    {
      while (objGridEntry != null && objGridEntry is PropertyDescriptorGridEntry && ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo.Attributes.Contains((Attribute) NotifyParentPropertyAttribute.Yes))
      {
        object valueOwner1 = objGridEntry.GetValueOwner();
        while (!(objGridEntry is PropertyDescriptorGridEntry) || valueOwner1 == objGridEntry.GetValueOwner())
        {
          objGridEntry = objGridEntry.ParentGridEntry;
          if (objGridEntry == null)
            break;
        }
        if (objGridEntry != null)
        {
          object valueOwner2 = objGridEntry.GetValueOwner();
          IComponentChangeService componentChangeService = this.ComponentChangeService;
          if (componentChangeService != null)
          {
            componentChangeService.OnComponentChanging(valueOwner2, (MemberDescriptor) ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo);
            componentChangeService.OnComponentChanged(valueOwner2, (MemberDescriptor) ((PropertyDescriptorGridEntry) objGridEntry).mobjPropertyInfo, (object) null, (object) null);
          }
          objGridEntry.ClearCachedValues(false);
        }
      }
    }

    internal override bool NotifyValueGivenParent(object objObject, int intType)
    {
      if (objObject is ICustomTypeDescriptor)
        objObject = ((ICustomTypeDescriptor) objObject).GetPropertyOwner(this.mobjPropertyInfo);
      switch (intType)
      {
        case 1:
          this.SetPropertyValue(objObject, (object) null, true, Gizmox.WebGUI.Forms.SR.GetString("PropertyGridResetValue", (object) this.PropertyName));
          if (this.marrPropertyValueUIItems != null)
          {
            for (int index = 0; index < this.marrPropertyValueUIItems.Length; ++index)
              this.marrPropertyValueUIItems[index].Reset();
          }
          this.marrPropertyValueUIItems = (PropertyValueUIItem[]) null;
          return false;
        case 2:
          try
          {
            return this.mobjPropertyInfo.CanResetValue(objObject) || this.marrPropertyValueUIItems != null && this.marrPropertyValueUIItems.Length != 0;
          }
          catch
          {
            if (this.mobjEexceptionConverter == null)
            {
              this.Flags = 0;
              this.mobjEexceptionConverter = (TypeConverter) new PropertyDescriptorGridEntry.ExceptionConverter();
            }
            return false;
          }
        case 3:
        case 5:
          if (this.mobjEventBindings == null)
            this.mobjEventBindings = (IEventBindingService) this.GetService(typeof (IEventBindingService));
          return this.mobjEventBindings != null && this.mobjEventBindings.GetEvent(this.mobjPropertyInfo) != null && this.ViewEvent(objObject, (string) null, (EventDescriptor) null, true);
        case 4:
          try
          {
            return this.mobjPropertyInfo.ShouldSerializeValue(objObject);
          }
          catch
          {
            if (this.mobjEexceptionConverter == null)
            {
              this.Flags = 0;
              this.mobjEexceptionConverter = (TypeConverter) new PropertyDescriptorGridEntry.ExceptionConverter();
            }
            return false;
          }
        default:
          return false;
      }
    }

    public override void OnComponentChanged()
    {
      base.OnComponentChanged();
      this.NotifyParentChange((GridEntry) this);
    }

    private void SetFlagsAndExceptionInfo(
      int intFlags,
      PropertyDescriptorGridEntry.ExceptionConverter objConverter,
      PropertyDescriptorGridEntry.ExceptionEditor objEditor)
    {
      this.Flags = intFlags;
      this.mobjEexceptionConverter = (TypeConverter) objConverter;
    }

    /// <summary>Sets the property value.</summary>
    /// <param name="objObect">The obj obect.</param>
    /// <param name="objValue">The obj value.</param>
    /// <param name="blnReset">if set to <c>true</c> [BLN reset].</param>
    /// <param name="strUndoText">The STR undo text.</param>
    /// <returns></returns>
    private object SetPropertyValue(
      object objObect,
      object objValue,
      bool blnReset,
      string strUndoText)
    {
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      try
      {
        object propertyValueCore = this.GetPropertyValueCore(objObect);
        if (objValue != null && objValue.Equals(propertyValueCore))
          return objValue;
        this.ClearCachedValues();
        IDesignerHost designerHost = this.DesignerHost;
        if (designerHost != null)
        {
          string str;
          if (strUndoText != null)
            str = strUndoText;
          else
            str = Gizmox.WebGUI.Forms.SR.GetString("PropertyGridSetValue", (object) this.mobjPropertyInfo.Name);
          string description = str;
          designerTransaction = designerHost.CreateTransaction(description);
        }
        bool flag1 = !(objObect is IComponent) || ((IComponent) objObect).Site == null;
        if (flag1)
        {
          try
          {
            if (this.ComponentChangeService != null)
              this.ComponentChangeService.OnComponentChanging(objObect, (MemberDescriptor) this.mobjPropertyInfo);
          }
          catch (CheckoutException ex)
          {
            if (ex != CheckoutException.Canceled)
              throw ex;
            return propertyValueCore;
          }
        }
        int num = this.InternalExpanded ? 1 : 0;
        int intOldCount = -1;
        if (num != 0)
          intOldCount = this.ChildCount;
        RefreshPropertiesAttribute attribute = (RefreshPropertiesAttribute) this.mobjPropertyInfo.Attributes[typeof (RefreshPropertiesAttribute)];
        bool flag2 = num != 0 || attribute != null && !attribute.RefreshProperties.Equals((object) RefreshProperties.None);
        if (flag2)
          this.DisposeChildren();
        EventDescriptor objEventdesc = (EventDescriptor) null;
        if (objObect != null && objValue is string)
        {
          if (this.mobjEventBindings == null)
            this.mobjEventBindings = (IEventBindingService) this.GetService(typeof (IEventBindingService));
          if (this.mobjEventBindings != null)
            objEventdesc = this.mobjEventBindings.GetEvent(this.mobjPropertyInfo);
          if (objEventdesc == null)
          {
            object component = objObect;
            if (this.mobjPropertyInfo is MergePropertyDescriptor && objObect is Array)
            {
              Array array = objObect as Array;
              if (array.Length > 0)
                component = array.GetValue(0);
            }
            objEventdesc = TypeDescriptor.GetEvents(component)[this.mobjPropertyInfo.Name];
          }
        }
        bool flag3 = false;
        try
        {
          if (blnReset)
            this.mobjPropertyInfo.ResetValue(objObect);
          else if (objEventdesc != null)
            this.ViewEvent(objObect, (string) objValue, objEventdesc, false);
          else
            this.SetPropertyValueCore(objObect, objValue, true);
          flag3 = true;
          if (flag1 && this.ComponentChangeService != null)
            this.ComponentChangeService.OnComponentChanged(objObect, (MemberDescriptor) this.mobjPropertyInfo, (object) null, objValue);
          this.NotifyParentChange((GridEntry) this);
          return objObect;
        }
        finally
        {
          if (flag2 && this.GridEntryHost != null)
          {
            this.RecreateChildren(intOldCount);
            if (flag3)
              this.GridEntryHost.Refresh(attribute != null && attribute.Equals((object) RefreshPropertiesAttribute.All));
          }
        }
      }
      catch (CheckoutException ex)
      {
        if (designerTransaction != null)
        {
          designerTransaction.Cancel();
          designerTransaction = (DesignerTransaction) null;
        }
        CheckoutException canceled = CheckoutException.Canceled;
        if (ex == canceled)
          return (object) null;
        throw;
      }
      catch
      {
        if (designerTransaction != null)
        {
          designerTransaction.Cancel();
          designerTransaction = (DesignerTransaction) null;
        }
        throw;
      }
      finally
      {
        designerTransaction?.Commit();
      }
    }

    private void SetPropertyValueCore(object objObject, object objValue, bool blnDoUndo)
    {
      if (this.mobjPropertyInfo == null)
        return;
      object objComponent = objObject;
      if (objComponent is ICustomTypeDescriptor)
        objComponent = ((ICustomTypeDescriptor) objComponent).GetPropertyOwner(this.mobjPropertyInfo);
      bool flag = false;
      if (this.ParentGridEntry != null)
      {
        Type propertyType = this.ParentGridEntry.PropertyType;
        flag = propertyType.IsValueType || propertyType.IsArray;
      }
      if (objComponent == null)
        return;
      this.OwnerGrid.SetPropertyValue(this.mobjPropertyInfo, objComponent, objValue);
      if (!flag)
        return;
      GridEntry parentGridEntry = this.ParentGridEntry;
      if (parentGridEntry == null || !parentGridEntry.IsValueEditable)
        return;
      parentGridEntry.PropertyValue = objObject;
    }

    protected bool ViewEvent(
      object objObject,
      string strNewHandler,
      EventDescriptor objEventdesc,
      bool blnAlwaysNavigate)
    {
      object propertyValueCore = this.GetPropertyValueCore(objObject);
      if (!(propertyValueCore is string str) && propertyValueCore != null && this.TypeConverter != null && this.TypeConverter.CanConvertTo(typeof (string)))
        str = this.TypeConverter.ConvertToString(propertyValueCore);
      if (strNewHandler == null)
      {
        if (!CommonUtils.IsNullOrEmpty(str))
        {
          strNewHandler = str;
          goto label_8;
        }
      }
      if (str == strNewHandler)
      {
        if (!CommonUtils.IsNullOrEmpty(strNewHandler))
          return true;
      }
label_8:
      if (!(objObject is IComponent component) && this.mobjPropertyInfo is MergePropertyDescriptor && objObject is Array array && array.Length > 0)
        component = array.GetValue(0) as IComponent;
      if (component == null || this.mobjPropertyInfo.IsReadOnly)
        return false;
      if (objEventdesc == null)
      {
        if (this.mobjEventBindings == null)
          this.mobjEventBindings = (IEventBindingService) this.GetService(typeof (IEventBindingService));
        if (this.mobjEventBindings != null)
          objEventdesc = this.mobjEventBindings.GetEvent(this.mobjPropertyInfo);
      }
      IDesignerHost designerHost = this.DesignerHost;
      DesignerTransaction designerTransaction = (DesignerTransaction) null;
      try
      {
        if (objEventdesc.EventType == (Type) null)
          return false;
        if (designerHost != null)
          designerTransaction = this.DesignerHost.CreateTransaction(Gizmox.WebGUI.Forms.SR.GetString("WindowsFormsSetEvent", (object) ((component.Site != null ? component.Site.Name : component.GetType().Name) + "." + this.PropertyName)));
        if (this.mobjEventBindings == null)
        {
          ISite site = component.Site;
          if (site != null)
            this.mobjEventBindings = (IEventBindingService) site.GetService(typeof (IEventBindingService));
        }
        if (strNewHandler == null && this.mobjEventBindings != null)
          strNewHandler = this.mobjEventBindings.CreateUniqueMethodName(component, objEventdesc);
        if (strNewHandler != null)
        {
          if (this.mobjEventBindings != null)
          {
            bool flag = false;
            foreach (string compatibleMethod in (IEnumerable) this.mobjEventBindings.GetCompatibleMethods(objEventdesc))
            {
              if (strNewHandler == compatibleMethod)
              {
                flag = true;
                break;
              }
            }
            if (!flag)
              blnAlwaysNavigate = true;
          }
          this.mobjPropertyInfo.SetValue(objObject, (object) strNewHandler);
        }
        if (blnAlwaysNavigate)
        {
          if (this.mobjEventBindings != null)
          {
            PropertyDescriptorGridEntry.mobjTargetBindingService = this.mobjEventBindings;
            PropertyDescriptorGridEntry.mobjTargetComponent = component;
            PropertyDescriptorGridEntry.mobjTargetEventDescriptor = objEventdesc;
          }
        }
      }
      catch
      {
        if (designerTransaction != null)
        {
          designerTransaction.Cancel();
          designerTransaction = (DesignerTransaction) null;
        }
        throw;
      }
      finally
      {
        designerTransaction?.Commit();
      }
      return true;
    }

    public override bool AllowMerge
    {
      get
      {
        MergablePropertyAttribute attribute = (MergablePropertyAttribute) this.mobjPropertyInfo.Attributes[typeof (MergablePropertyAttribute)];
        return attribute == null || attribute.IsDefaultAttribute();
      }
    }

    internal override AttributeCollection Attributes => this.mobjPropertyInfo.Attributes;

    internal override bool Enumerable => base.Enumerable && !this.IsPropertyReadOnly;

    public override string HelpKeyword
    {
      get
      {
        if (this.mstrHelpKeyword == null)
        {
          object valueOwner = this.GetValueOwner();
          if (valueOwner == null)
            return (string) null;
          HelpKeywordAttribute attribute = (HelpKeywordAttribute) this.mobjPropertyInfo.Attributes[typeof (HelpKeywordAttribute)];
          if (attribute != null && !attribute.IsDefaultAttribute())
            return attribute.HelpKeyword;
          if (this is ImmutablePropertyDescriptorGridEntry)
          {
            this.mstrHelpKeyword = this.PropertyName;
            GridEntry gridEntry = (GridEntry) this;
            while (gridEntry.ParentGridEntry != null)
            {
              gridEntry = gridEntry.ParentGridEntry;
              if (gridEntry.PropertyValue == valueOwner || valueOwner.GetType().IsValueType && valueOwner.GetType() == gridEntry.PropertyValue.GetType())
              {
                this.mstrHelpKeyword = gridEntry.PropertyName + "." + this.mstrHelpKeyword;
                break;
              }
            }
          }
          else
          {
            Type componentType = this.mobjPropertyInfo.ComponentType;
            string str;
            if (componentType.IsCOMObject)
            {
              str = TypeDescriptor.GetClassName(valueOwner);
            }
            else
            {
              Type type = valueOwner.GetType();
              if (!componentType.IsPublic || !componentType.IsAssignableFrom(type))
              {
                PropertyDescriptor property = TypeDescriptor.GetProperties(type)[this.PropertyName];
                componentType = property == null ? (Type) null : property.ComponentType;
              }
              str = !(componentType == (Type) null) ? componentType.FullName : TypeDescriptor.GetClassName(valueOwner);
            }
            this.mstrHelpKeyword = str + "." + this.mobjPropertyInfo.Name;
          }
        }
        return this.mstrHelpKeyword;
      }
    }

    internal override string HelpKeywordInternal => this.PropertyLabel;

    protected virtual bool IsPropertyReadOnly => this.mobjPropertyInfo.IsReadOnly;

    public override bool IsValueEditable => this.mobjEexceptionConverter == null && !this.IsPropertyReadOnly && base.IsValueEditable;

    public override bool NeedsDropDownButton => base.NeedsDropDownButton && !this.IsPropertyReadOnly;

    internal bool ParensAroundName
    {
      get
      {
        if (byte.MaxValue == this.mParensAroundName)
          this.mParensAroundName = !((ParenthesizePropertyNameAttribute) this.mobjPropertyInfo.Attributes[typeof (ParenthesizePropertyNameAttribute)]).NeedParenthesis ? (byte) 0 : (byte) 1;
        return this.mParensAroundName == (byte) 1;
      }
    }

    public override string PropertyCategory
    {
      get
      {
        string category = this.mobjPropertyInfo.Category;
        return category != null && category.Length != 0 ? category : base.PropertyCategory;
      }
    }

    public override string PropertyDescription => this.mobjPropertyInfo.Description;

    public override PropertyDescriptor PropertyDescriptor => this.mobjPropertyInfo;

    public override string PropertyLabel
    {
      get
      {
        string propertyLabel = this.mobjPropertyInfo.DisplayName;
        if (this.ParensAroundName)
          propertyLabel = "(" + propertyLabel + ")";
        return propertyLabel;
      }
    }

    public override string PropertyName => this.mobjPropertyInfo != null ? this.mobjPropertyInfo.Name : (string) null;

    public override Type PropertyType => this.mobjPropertyInfo.PropertyType;

    public override object PropertyValue
    {
      get
      {
        try
        {
          object propertyValueCore = this.GetPropertyValueCore(this.GetValueOwner());
          if (this.mobjEexceptionConverter != null)
            this.SetFlagsAndExceptionInfo(0, (PropertyDescriptorGridEntry.ExceptionConverter) null, (PropertyDescriptorGridEntry.ExceptionEditor) null);
          return propertyValueCore;
        }
        catch (Exception ex)
        {
          if (this.mobjEexceptionConverter == null)
            this.SetFlagsAndExceptionInfo(0, new PropertyDescriptorGridEntry.ExceptionConverter(), new PropertyDescriptorGridEntry.ExceptionEditor());
          return (object) ex;
        }
      }
      set => this.SetPropertyValue(this.GetValueOwner(), value, false, (string) null);
    }

    private IPropertyValueUIService PropertyValueUIService
    {
      get
      {
        if (!this.mobjServiceChecked && this.mobjPropertyValueUIService == null)
        {
          this.mobjPropertyValueUIService = (IPropertyValueUIService) this.GetService(typeof (IPropertyValueUIService));
          this.mobjServiceChecked = true;
        }
        return this.mobjPropertyValueUIService;
      }
    }

    public override bool ShouldRenderReadOnly
    {
      get
      {
        if (this.ForceReadOnly || this.mblnForceRenderReadOnly)
          return true;
        if (this.mobjPropertyInfo.IsReadOnly && !this.mblnReadOnlyVerified && this.GetStateSet(128))
        {
          Type propertyType = this.PropertyType;
          if (propertyType != (Type) null && (propertyType.IsArray || propertyType.IsValueType || propertyType.IsPrimitive))
          {
            this.SetState(128, false);
            this.SetState(256, true);
            this.mblnForceRenderReadOnly = true;
          }
        }
        this.mblnReadOnlyVerified = true;
        return base.ShouldRenderReadOnly && !this.mblnIsSerializeContentsProp && !this.NeedsCustomEditorButton;
      }
    }

    internal override TypeConverter TypeConverter
    {
      get
      {
        if (this.mobjEexceptionConverter != null)
          return this.mobjEexceptionConverter;
        if (this.mobjConverter == null)
          this.mobjConverter = this.mobjPropertyInfo.Converter;
        return base.TypeConverter;
      }
    }

    internal override WebUITypeEditor UITypeEditor
    {
      get
      {
        if (this.mobjExceptionEditor != null)
          return this.mobjExceptionEditor;
        this.mobjEditor = WebUITypeEditor.GetPropertyEditor(this.mobjPropertyInfo, typeof (WebUITypeEditor));
        WebUITypeEditor mobjEditor = this.mobjEditor;
        return base.UITypeEditor;
      }
    }

    [Serializable]
    public class ExceptionConverter : TypeConverter
    {
      public override object ConvertTo(
        ITypeDescriptorContext objContext,
        CultureInfo objCulture,
        object objValue,
        Type objDestinationType)
      {
        if (objDestinationType != typeof (string))
          throw this.GetConvertToException(objValue, objDestinationType);
        if (!(objValue is Exception))
          return (object) null;
        Exception exception = (Exception) objValue;
        if (exception.InnerException != null)
          exception = exception.InnerException;
        return (object) exception.Message;
      }
    }

    [Serializable]
    private class ExceptionEditor : WebUITypeEditor
    {
      public override void EditValue(
        ITypeDescriptorContext objContext,
        IServiceProvider objProvider,
        object objValue,
        WebUITypeEditorHandler objHandler)
      {
        if (!(objValue is Exception exception))
          return;
        string message = exception.Message;
        if (message == null || message.Length == 0)
          message = exception.ToString();
        int num = (int) MessageBox.Show(message, Gizmox.WebGUI.Forms.SR.GetString("PropertyGridExceptionInfo"), MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, (MessageBoxOptions) 0);
      }

      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext) => UITypeEditorEditStyle.Modal;
    }
  }
}
