#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	/// The base class for all positioned GUI elements
	/// </summary>
	[Serializable]
	[DefaultEvent("Click")]
	[ToolboxItem(false)]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Designer("Gizmox.WebGUI.Forms.Design.ControlDesigner, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd")]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[Skin(typeof(Gizmox.WebGUI.Forms.Skins.ControlSkin))]
	[ProxyComponent(typeof(ProxyControl))]
	[ContextualToolbar(typeof(Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar))]
	public class Control : Component, IControl, IWin32Window, IEventHandler, IRegisteredComponent, IBindableComponent, IComponent, IDisposable, IArrangedElement, IRenderableComponent, IObservableLayoutItem, ISkinable
	{
		/// 
		/// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
		/// </summary>
		[Serializable]
		[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[ListBindable(false)]
		public class ControlCollection : ArrangedElementCollection, IList, ICollection, IEnumerable, ICloneable, IObservableList
		{
			[Serializable]
			private class ControlCollectionEnumerator : IEnumerator
			{
				private ControlCollection mobjControls;

				private int mintCurrent;

				private int mintOriginalCount;

				public object Current
				{
					get
					{
						if (mintCurrent == -1)
						{
							return null;
						}
						return mobjControls[mintCurrent];
					}
				}

				public ControlCollectionEnumerator(ControlCollection objControls)
				{
					mobjControls = objControls;
					mintOriginalCount = objControls.Count;
					mintCurrent = -1;
				}

				public bool MoveNext()
				{
					if (mintCurrent < mobjControls.Count - 1 && mintCurrent < mintOriginalCount - 1)
					{
						mintCurrent++;
						return true;
					}
					return false;
				}

				public void Reset()
				{
					mintCurrent = -1;
				}
			}

			private int mintLastAccessedIndex;

			private Control mobjOwnerControl;

			/// Indicates a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key in the collection.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> with the specified key within the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
			/// <param name="strKey">The name of the control to retrieve from the control collection.</param>
			public virtual Control this[string strKey]
			{
				get
				{
					if (!CommonUtils.IsNullOrEmpty(strKey))
					{
						int index = IndexOfKey(strKey);
						if (IsValidIndex(index))
						{
							return this[index];
						}
					}
					return null;
				}
			}

			/// Indicates the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> at the specified indexed location in the collection.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> located at the specified index location within the control collection.</returns>
			/// <param name="index">The index of the control to retrieve from the control collection. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index value is less than zero or is greater than or equal to the number of controls in the collection. </exception>
			public new virtual Control this[int index]
			{
				get
				{
					if (index < 0 || index >= Count)
					{
						throw new ArgumentOutOfRangeException("index", SR.GetString("IndexOutOfRange"));
					}
					return (Control)base.InnerList[index];
				}
			}

			/// Gets the control that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that owns this <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
			public Control Owner => mobjOwnerControl;

			/// 
			/// Gets a value indicating whether the collection is read-only.
			/// </summary>
			/// </value>
			/// true if the collection is read-only; otherwise, false. The default is false.</returns>
			public override bool IsReadOnly => base.InnerList.IsReadOnly;

			/// 
			/// Gets or sets the <see cref="T:System.Object" /> at the specified index.
			/// </summary>
			/// </value>
			object IList.this[int index]
			{
				get
				{
					return base.InnerList[index];
				}
				set
				{
					base.InnerList[index] = value;
				}
			}

			/// 
			/// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
			/// </summary>
			/// </value>
			/// true if the <see cref="T:System.Collections.IList" /> has a fixed size; otherwise, false.
			/// </returns>
			public bool IsFixedSize => base.InnerList.IsFixedSize;

			bool ICollection.IsSynchronized => base.InnerList.IsSynchronized;

			/// 
			/// Gets the number of elements in the collection.
			/// </summary>
			/// </value>
			/// The number of elements currently contained in the collection.</returns>
			public new int Count => base.InnerList.Count;

			object ICollection.SyncRoot => base.InnerList.SyncRoot;

			/// 
			/// Occurs when [observable item added].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemAdded;

			/// 
			/// Occurs when [observable item inserted].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemInserted;

			/// 
			/// Occurs when [observable item removed].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemRemoved;

			/// 
			/// Occurs when [observable list cleared].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event EventHandler ObservableListCleared;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> class.
			/// </summary>
			/// <param name="owner">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> representing the control that owns the control collection.</param>
			/// <param name="blnReversed">if set to true</c> [BLN reversed].</param>
			public ControlCollection(Control objOwnerControl, bool blnReversed)
			{
				mintLastAccessedIndex = -1;
				mobjOwnerControl = objOwnerControl;
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection" /> class.
			/// </summary>
			/// <param name="objOwnerControl">The owner.</param>
			public ControlCollection(Control objOwnerControl)
				: this(objOwnerControl, blnReversed: false)
			{
			}

			/// Adds the specified control to the control collection.</summary>
			/// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection. </param>
			/// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
			/// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
			public virtual void Add(Control objValue)
			{
				Add(objValue, blnRegisterControl: true, -1);
			}

			/// 
			/// Adds the specified control to the control collection.
			/// </summary>
			/// <param name="objNewControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add to the control collection.</param>
			/// <param name="blnRegisterControl">if set to true</c> [BLN is add range].</param>
			/// <param name="intIndex">Index for insertion.</param>
			/// <exception cref="T:System.Exception">The specified control is a top-level control, or a circular control reference would result if this control were added to the control collection. </exception>
			/// <exception cref="T:System.ArgumentException">The object assigned to the value parameter is not a <see cref="T:Gizmox.WebGUI.Forms.Control"></see>. </exception>
			protected virtual void Add(Control objNewControl, bool blnRegisterControl, int intIndex)
			{
				if (objNewControl == null)
				{
					return;
				}
				if (objNewControl.GetTopLevel())
				{
					throw new ArgumentException(SR.GetString("TopLevelControlAdd"));
				}
				CheckParentingCycle(mobjOwnerControl, objNewControl);
				if (objNewControl.Parent == mobjOwnerControl && Contains(objNewControl))
				{
					objNewControl.SendToBack();
				}
				else
				{
					if (objNewControl.Parent != null)
					{
						objNewControl.Parent.Controls.Remove(objNewControl);
					}
					if (intIndex >= 0)
					{
						base.InnerList.Insert(intIndex, objNewControl);
					}
					else
					{
						base.InnerList.Add(objNewControl);
					}
					if (objNewControl.mintTabIndex == -1)
					{
						int num = 0;
						for (int i = 0; i < Count - 1; i++)
						{
							int tabIndex = this[i].TabIndex;
							if (num <= tabIndex)
							{
								num = tabIndex + 1;
							}
						}
						objNewControl.mintTabIndex = num;
					}
					objNewControl.AssignParent(mobjOwnerControl);
					if (blnRegisterControl)
					{
						objNewControl.RegisterSelf();
						UpdateOwner();
					}
					if (objNewControl.Visible && mobjOwnerControl.Created)
					{
						objNewControl.CreateControl();
					}
					mobjOwnerControl.OnControlAdded(new ControlEventArgs(objNewControl));
					mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					if (this.ObservableItemAdded != null)
					{
						this.ObservableItemAdded(this, new ObservableListEventArgs(objNewControl));
					}
				}
				UpdateProxyForm();
			}

			/// Adds an array of control objects to the collection.</summary>
			/// <param name="arrControls">An array of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects to add to the collection. </param>
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			public virtual void AddRange(Control[] arrControls)
			{
				if (arrControls == null)
				{
					throw new ArgumentNullException("controls");
				}
				if (arrControls.Length == 0)
				{
					return;
				}
				mobjOwnerControl.SuspendLayout();
				try
				{
					for (int i = 0; i < arrControls.Length; i++)
					{
						Add(arrControls[i], blnRegisterControl: false, -1);
					}
					mobjOwnerControl.RegisterBatch(arrControls);
					UpdateOwner();
					UpdateProxyForm();
				}
				finally
				{
					mobjOwnerControl.ResumeLayout(blnPerformLayout: true);
				}
			}

			/// Removes all controls from the collection.</summary>
			public virtual void Clear()
			{
				mobjOwnerControl.SuspendLayout();
				try
				{
					while (Count != 0)
					{
						RemoveAt(Count - 1);
					}
				}
				finally
				{
					mobjOwnerControl.ResumeLayout();
				}
				if (this.ObservableListCleared != null)
				{
					this.ObservableListCleared(this, EventArgs.Empty);
				}
			}

			/// Determines whether the specified control is a member of the collection.</summary>
			/// true if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a member of the collection; otherwise, false.</returns>
			/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
			public bool Contains(Control objControl)
			{
				return base.InnerList.Contains(objControl);
			}

			/// Determines whether the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key.</summary>
			/// true if the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> contains an item with the specified key; otherwise, false.</returns>
			/// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
			public virtual bool ContainsKey(string strKey)
			{
				return IsValidIndex(IndexOfKey(strKey));
			}

			/// Searches for controls by their <see cref="P:Gizmox.WebGUI.Forms.Control.Name"></see> property and builds an array of all the controls that match.</summary>
			/// An array of type <see cref="T:Gizmox.WebGUI.Forms.Control"></see> containing the matching controls.</returns>
			/// <param name="blnSearchAllChildren">true to search all child controls; otherwise, false. </param>
			/// <param name="strKey">The key to locate in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
			/// <exception cref="T:System.ArgumentException">The key parameter is null or the empty string (""). </exception>
			public Control[] Find(string strKey, bool blnSearchAllChildren)
			{
				if (CommonUtils.IsNullOrEmpty(strKey))
				{
					throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
				}
				ArrayList arrayList = FindInternal(strKey, blnSearchAllChildren, this, new ArrayList());
				Control[] array = new Control[arrayList.Count];
				arrayList.CopyTo(array, 0);
				return array;
			}

			private ArrayList FindInternal(string strKey, bool blnSearchAllChildren, ControlCollection objControlsToLookIn, ArrayList foundControls)
			{
				if (objControlsToLookIn == null || foundControls == null)
				{
					return null;
				}
				try
				{
					for (int i = 0; i < objControlsToLookIn.Count; i++)
					{
						if (objControlsToLookIn[i] != null && ClientUtils.SafeCompareStrings(objControlsToLookIn[i].Name, strKey, blnIgnoreCase: true))
						{
							foundControls.Add(objControlsToLookIn[i]);
						}
					}
					if (!blnSearchAllChildren)
					{
						return foundControls;
					}
					for (int j = 0; j < objControlsToLookIn.Count; j++)
					{
						if (objControlsToLookIn[j] != null && objControlsToLookIn[j].Controls != null && objControlsToLookIn[j].Controls.Count > 0)
						{
							foundControls = FindInternal(strKey, blnSearchAllChildren, objControlsToLookIn[j].Controls, foundControls);
						}
					}
				}
				catch (Exception objException)
				{
					if (ClientUtils.IsSecurityOrCriticalException(objException))
					{
						throw;
					}
				}
				return foundControls;
			}

			/// Retrieves the index of the specified child control within the control collection.</summary>
			/// A zero-based index value that represents the location of the specified child control within the control collection.</returns>
			/// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
			/// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
			public int GetChildIndex(Control objChild)
			{
				return GetChildIndex(objChild, blnThrowException: true);
			}

			/// Retrieves the index of the specified child control within the control collection, and optionally raises an exception if the specified control is not within the control collection.</summary>
			/// A zero-based index value that represents the location of the specified child control within the control collection; otherwise -1 if the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not found in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
			/// <param name="blnThrowException">true to throw an exception if the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> specified in the child parameter is not a control in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>; otherwise, false. </param>
			/// <param name="objChild">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for in the control collection. </param>
			/// <exception cref="T:System.ArgumentException">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>, and the throwException parameter value is true. </exception>
			public virtual int GetChildIndex(Control objChild, bool blnThrowException)
			{
				int num = IndexOf(objChild);
				if (num == -1 && blnThrowException)
				{
					throw new ArgumentException(SR.GetString("ControlNotChild"));
				}
				return num;
			}

			/// Retrieves a reference to an enumerator object that is used to iterate over a <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see>.</returns>
			public override IEnumerator GetEnumerator()
			{
				return new ControlCollectionEnumerator(this);
			}

			/// Retrieves the index of the specified control in the control collection.</summary>
			/// A zero-based index value that represents the position of the specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>.</returns>
			/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to locate in the collection. </param>
			public int IndexOf(Control objControl)
			{
				return base.InnerList.IndexOf(objControl);
			}

			/// Retrieves the index of the first occurrence of the specified item within the collection.</summary>
			/// The zero-based index of the first occurrence of the control with the specified name in the collection.</returns>
			/// <param name="strKey">The name of the control to search for. </param>
			public virtual int IndexOfKey(string strKey)
			{
				if (!CommonUtils.IsNullOrEmpty(strKey))
				{
					if (IsValidIndex(mintLastAccessedIndex) && ClientUtils.SafeCompareStrings(this[mintLastAccessedIndex].Name, strKey, blnIgnoreCase: true))
					{
						return mintLastAccessedIndex;
					}
					for (int i = 0; i < Count; i++)
					{
						if (ClientUtils.SafeCompareStrings(this[i].Name, strKey, blnIgnoreCase: true))
						{
							mintLastAccessedIndex = i;
							return i;
						}
					}
					mintLastAccessedIndex = -1;
				}
				return -1;
			}

			private bool IsValidIndex(int index)
			{
				if (index >= 0)
				{
					return index < Count;
				}
				return false;
			}

			/// Removes the specified control from the control collection.</summary>
			/// <param name="objValue">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove from the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </param>
			public virtual void Remove(Control objValue)
			{
				if (objValue != null && base.InnerList.Contains(objValue))
				{
					base.InnerList.Remove(objValue);
					objValue.UnRegisterSelf();
					objValue.AssignParent(null);
					UpdateOwner();
					mobjOwnerControl.OnControlRemoved(new ControlEventArgs(objValue));
					mobjOwnerControl.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					if (this.ObservableItemRemoved != null)
					{
						this.ObservableItemRemoved(this, new ObservableListEventArgs(objValue));
					}
					if (mobjOwnerControl.GetContainerControlInternal() is ContainerControl containerControl)
					{
						containerControl.AfterControlRemoved(objValue, mobjOwnerControl);
					}
					UpdateProxyForm();
				}
			}

			/// Removes a control from the control collection at the specified indexed location.</summary>
			/// <param name="index">The index value of the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
			public void RemoveAt(int index)
			{
				Remove(this[index]);
			}

			/// Removes the child control with the specified key.</summary>
			/// <param name="strKey">The name of the child control to remove. </param>
			public virtual void RemoveByKey(string strKey)
			{
				int index = IndexOfKey(strKey);
				if (IsValidIndex(index))
				{
					RemoveAt(index);
				}
			}

			/// Sets the index of the specified child control in the collection to the specified index value.</summary>
			/// <param name="objChild">The child<see cref="T:Gizmox.WebGUI.Forms.Control"></see> to search for. </param>
			/// <param name="intNewIndex">The new index value of the control. </param>
			/// <exception cref="T:System.ArgumentException">The child control is not in the <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see>. </exception>
			public virtual void SetChildIndex(Control objChild, int intNewIndex)
			{
				SetChildIndexInternal(objChild, intNewIndex);
			}

			internal void Sort(IComparer objComparer)
			{
				base.InnerList.Sort(objComparer);
				UpdateOwner();
			}

			internal virtual void SetChildIndexInternal(Control objChild, int intNewIndex)
			{
				if (objChild == null)
				{
					throw new ArgumentNullException("child");
				}
				int childIndex = GetChildIndex(objChild);
				if (childIndex != intNewIndex)
				{
					if (intNewIndex >= Count || intNewIndex == -1)
					{
						intNewIndex = Count - 1;
					}
					MoveElement(objChild, childIndex, intNewIndex);
					UpdateOwner();
				}
			}

			int IList.Add(object objControl)
			{
				if (objControl is Control)
				{
					Add((Control)objControl);
					return IndexOf((Control)objControl);
				}
				throw new ArgumentException(SR.GetString("ControlBadControl"), "control");
			}

			/// 
			/// Updates the owner.
			/// </summary>
			protected virtual void UpdateOwner()
			{
				if (mobjOwnerControl != null)
				{
					mobjOwnerControl.Update();
				}
			}

			/// 
			/// Updates the proxy form.
			/// </summary>
			private void UpdateProxyForm()
			{
				if (mobjOwnerControl != null)
				{
					Form form = mobjOwnerControl.Form;
					if (form != null && form.ProxyComponent is ProxyForm proxyForm)
					{
						proxyForm.ValidateSourceComponent();
					}
				}
			}

			void IList.Remove(object objControl)
			{
				if (objControl is Control)
				{
					Remove((Control)objControl);
				}
			}

			object ICloneable.Clone()
			{
				ControlCollection controlCollection = mobjOwnerControl.CreateControlsInstance();
				controlCollection.InnerList.AddRange(this);
				return controlCollection;
			}

			/// 
			/// Inserts the specified int index.
			/// </summary>
			/// <param name="intIndex">Index of the value.</param>
			/// <param name="objValue">The value.</param>
			public void Insert(int intIndex, object objValue)
			{
				Add(objValue as Control, blnRegisterControl: true, intIndex);
			}

			/// 
			/// Determines whether the <see cref="T:System.Collections.IList" /> contains a specific value.
			/// </summary>
			/// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
			/// 
			/// true if the <see cref="T:System.Object" /> is found in the <see cref="T:System.Collections.IList" />; otherwise, false.
			/// </returns>
			bool IList.Contains(object objValue)
			{
				return base.InnerList.Contains(objValue);
			}

			/// 
			/// Determines the index of a specific item in the <see cref="T:System.Collections.IList" />.
			/// </summary>
			/// <param name="objValue">The <see cref="T:System.Object" /> to locate in the <see cref="T:System.Collections.IList" />.</param>
			/// 
			/// The index of <paramref name="value" /> if found in the list; otherwise, -1.
			/// </returns>
			int IList.IndexOf(object objValue)
			{
				return base.InnerList.IndexOf(objValue);
			}

			void ICollection.CopyTo(Array objArray, int index)
			{
				base.InnerList.CopyTo(objArray, index);
			}
		}

		/// 
		/// The current control version information
		/// </summary>
		[Serializable]
		private class ControlVersionInfo
		{
			/// 
			/// The control company name
			/// </summary>
			private string mstrCompanyName;

			/// 
			/// The control 
			/// </summary>
			private Control mobjOwner;

			/// 
			/// The product name
			/// </summary>
			private string mstrProductName;

			/// 
			/// The product version
			/// </summary>
			private string mstrProductVersion;

			/// 
			/// Get the control company name
			/// </summary>
			internal string CompanyName
			{
				get
				{
					if (mstrCompanyName == null)
					{
						object[] customAttributes = mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
						if (customAttributes != null && customAttributes.Length != 0)
						{
							mstrCompanyName = ((AssemblyCompanyAttribute)customAttributes[0]).Company;
						}
						if (mstrCompanyName == null || mstrCompanyName.Length == 0)
						{
							string text = mobjOwner.GetType().Namespace;
							if (text == null)
							{
								text = string.Empty;
							}
							int num = text.IndexOf("/");
							if (num != -1)
							{
								mstrCompanyName = text.Substring(0, num);
							}
							else
							{
								mstrCompanyName = text;
							}
						}
					}
					return mstrCompanyName;
				}
			}

			/// 
			/// Get the control product name
			/// </summary>
			internal string ProductName
			{
				get
				{
					if (mstrProductName == null)
					{
						object[] customAttributes = mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
						if (customAttributes != null && customAttributes.Length != 0)
						{
							mstrProductName = ((AssemblyProductAttribute)customAttributes[0]).Product;
						}
						if (mstrProductName == null || mstrProductName.Length == 0)
						{
							string text = mobjOwner.GetType().Namespace;
							if (text == null)
							{
								text = string.Empty;
							}
							int num = text.IndexOf(".");
							if (num != -1)
							{
								mstrProductName = text.Substring(num + 1);
							}
							else
							{
								mstrProductName = text;
							}
						}
					}
					return mstrProductName;
				}
			}

			/// 
			/// Get the control product version
			/// </summary>
			internal string ProductVersion
			{
				get
				{
					if (mstrProductVersion == null)
					{
						object[] customAttributes = mobjOwner.GetType().Module.Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), inherit: false);
						if (customAttributes != null && customAttributes.Length != 0)
						{
							mstrProductVersion = ((AssemblyInformationalVersionAttribute)customAttributes[0]).InformationalVersion;
						}
						if (mstrProductVersion == null || mstrProductVersion.Length == 0)
						{
							mstrProductVersion = "1.0.0.0";
						}
					}
					return mstrProductVersion;
				}
			}

			/// 
			/// Create a new control version information
			/// </summary>
			/// <param name="objOwner">The obj owner.</param>
			internal ControlVersionInfo(Control objOwner)
			{
				mobjOwner = objOwner;
			}
		}

		[Flags]
		internal enum ControlState
		{
			/// 
			/// The top level flag
			/// </summary>
			TopLevel = 1,
			/// 
			/// The tab stop flag
			/// </summary>
			TabStop = 2,
			/// 
			/// The becoming active control flag
			/// </summary>
			BecomingActiveControl = 4,
			/// 
			/// The has positioning flag
			/// </summary>
			HasPositioning = 8,
			/// 
			/// Layout dirty flag.
			/// </summary>
			LayoutIsDirty = 0x10,
			/// 
			/// The cause validation flag
			/// </summary>
			CausesValidation = 0x20,
			/// 
			/// The validation cancelled flag
			/// </summary>
			ValidationCancelled = 0x40,
			/// 
			/// The auto scroll flag
			/// </summary>
			AutoScroll = 0x80,
			/// 
			/// The hscroll flag
			/// </summary>
			HScroll = 0x100,
			/// 
			/// The vscroll flag
			/// </summary>
			VScroll = 0x200,
			/// 
			/// The auto size state flag
			/// </summary>
			AutoSize = 0x400,
			/// 
			/// The created flag
			/// </summary>
			Created = 0x800,
			/// 
			/// The sorted flag
			/// </summary>
			Sorted = 0x1000
		}

		/// 
		/// Provides a property reference to DataBindings property.
		/// </summary>
		private static SerializableProperty DataBindingsProperty;

		/// 
		/// Provides a property reference to BindingContext property.
		/// </summary>
		private static SerializableProperty BindingContextProperty;

		/// 
		/// Provides a property reference to BorderStyle property.
		/// </summary>
		private static SerializableProperty BorderStyleProperty;

		/// 
		/// Provides a property reference to BorderColor property.
		/// </summary>
		private static SerializableProperty BorderColorProperty;

		/// 
		/// Provides a property reference to ErrorMessage property.
		/// </summary>
		private static SerializableProperty ErrorMessageProperty;

		/// 
		/// Provides a property reference to ErrorIcon property.
		/// </summary>
		private static SerializableProperty ErrorIconProperty;

		/// 
		/// Provides a property reference to ErrorIconPadding property.
		/// </summary>
		private static SerializableProperty ErrorIconPaddingProperty;

		/// 
		/// Provides a property reference to ErrorIconAlignment property.
		/// </summary>
		private static SerializableProperty ErrorIconAlignmentProperty;

		/// 
		/// Provides a property reference to LayoutInfo property.
		/// </summary>
		internal static SerializableProperty LayoutInfoProperty;

		/// 
		/// Provides a property reference to ContainerInfo property.
		/// </summary>
		internal static SerializableProperty ContainerInfoProperty;

		/// 
		/// Provides a property reference to BorderWidth property.
		/// </summary>
		private static SerializableProperty BorderWidthProperty;

		/// 
		/// Provides a property reference to Cursor property.
		/// </summary>
		private static SerializableProperty CursorProperty;

		/// 
		/// Provides a property reference to CustomStyle property.
		/// </summary>
		private static SerializableProperty CustomStyleProperty;

		/// 
		/// Provides a property reference to RightToLeft property.
		/// </summary>
		private static SerializableProperty RightToLeftProperty;

		/// 
		/// Provides a property reference to AutoSizeMode property.
		/// </summary>
		private static SerializableProperty AutoSizeModeProperty;

		/// 
		/// Provides a property reference to TextProperty property.
		/// </summary>
		private static readonly SerializableProperty TextProperty;

		/// 
		/// Register the BackgroundImageLayout property
		/// </summary>
		private static SerializableProperty BackgroundImageLayoutProperty;

		/// 
		/// Register the Margin property
		/// </summary>
		private static SerializableProperty MarginProperty;

		/// 
		/// Register the Padding property
		/// </summary>
		private static SerializableProperty PaddingProperty;

		/// 
		/// Register the ForeColor property
		/// </summary>
		private static SerializableProperty ForeColorProperty;

		/// 
		/// Register the BackColor property
		/// </summary>
		private static SerializableProperty BackColorProperty;

		/// 
		/// Register the Theme property
		/// </summary>
		private static SerializableProperty ThemeProperty;

		/// 
		/// Register the Font property
		/// </summary>
		private static SerializableProperty FontProperty;

		/// 
		/// Register the ToolTip property
		/// </summary>
		private static SerializableProperty ToolTipProperty;

		/// 
		/// Register ExtendedToolTipDescriptor property.
		/// </summary>
		private static SerializableProperty ExtendedToolTipDescriptorProperty;

		/// 
		/// Register the TagName property
		/// </summary>
		private static SerializableProperty TagNameProperty;

		/// 
		/// Register the Name property
		/// </summary>
		private static SerializableProperty NameProperty;

		/// 
		/// Register the Accessible Name property
		/// </summary>
		private static SerializableProperty AccessibleNameProperty;

		/// 
		/// Register the Accessible Description property
		/// </summary>
		private static SerializableProperty AccessibleDescriptionProperty;

		/// 
		/// Register the MaximumSize property
		/// </summary>
		private static SerializableProperty MaximumSizeProperty;

		/// 
		/// Register the MinimumSize property
		/// </summary>
		private static SerializableProperty MinimumSizeProperty;

		/// 
		/// Register the KeyFilter property
		/// </summary>
		private static SerializableProperty KeyFilterProperty;

		/// 
		/// Register the ScrollTop property
		/// </summary>
		private static SerializableProperty ScrollTopProperty;

		/// 
		/// Register the ScrollLeft property
		/// </summary>
		private static SerializableProperty ScrollLeftProperty;

		/// 
		///
		/// </summary>
		private static SerializableProperty BackgroundImageProperty;

		/// 
		/// Register the RegisteredTimers property
		/// </summary>
		private static SerializableProperty RegisteredTimersProperty;

		/// 
		/// Register the ImeMode property
		/// </summary>
		private static SerializableProperty ImeModeProperty;

		/// 
		/// Register the ForceContentAvailabilityOnClient property
		/// </summary>
		private static SerializableProperty ForceContentAvailabilityOnClientProperty;

		/// 
		/// Register the Draggable property
		/// </summary>
		private static SerializableProperty DraggableProperty;

		/// 
		/// Register the Resizable property
		/// </summary>
		private static SerializableProperty ResizableProperty;

		/// 
		/// Register the VisualTemplate
		/// </summary>
		private static SerializableProperty VisualTemplateProperty;

		/// 
		/// The ParentChanged event registration.
		/// </summary>
		private static readonly SerializableEvent ParentChangedEvent;

		/// 
		/// The Enter event registration.
		/// </summary>
		private static readonly SerializableEvent EnterEvent;

		/// 
		/// The Leave event registration.
		/// </summary>
		private static readonly SerializableEvent LeaveEvent;

		private static readonly SerializableEvent ResizeEvent;

		/// 
		/// The EnabledChanged event registration.
		/// </summary>
		private static readonly SerializableEvent EnabledChangedEvent;

		/// 
		/// The Click event registration.
		/// </summary>
		internal static readonly SerializableEvent ClickEvent;

		/// 
		///
		/// </summary>
		internal static readonly SerializableEvent ControlSelectedEvent;

		/// 
		///
		/// </summary>
		internal static readonly SerializableEvent ControlDroppedEvent;

		/// 
		/// The MouseClick event registration.
		/// </summary>
		internal static readonly SerializableEvent MouseClickEvent;

		/// 
		/// The KeyDown event registration.
		/// </summary>
		private static readonly SerializableEvent KeyDownEvent;

		/// 
		/// The KeyPress event registration.
		/// </summary>
		private static readonly SerializableEvent KeyPressEvent;

		/// 
		/// The KeyUp event registration.
		/// </summary>
		private static readonly SerializableEvent KeyUpEvent;

		/// 
		/// The GotFocus event registration.
		/// </summary>
		private static readonly SerializableEvent GotFocusEvent;

		/// 
		/// The LostFocus event registration.
		/// </summary>
		private static readonly SerializableEvent LostFocusEvent;

		/// 
		/// The DoubleClick event registration.
		/// </summary>
		internal static readonly SerializableEvent DoubleClickEvent;

		private static readonly SerializableEvent TextChangedEvent;

		/// 
		/// The Validated event registration.
		/// </summary>
		private static readonly SerializableEvent ValidatedEvent;

		/// 
		/// The CausesValidationChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CausesValidationChangedEvent;

		/// 
		/// The Validating event registration.
		/// </summary>
		private static readonly SerializableEvent ValidatingEvent;

		private static readonly SerializableEvent TextChangedQueuedEvent;

		/// 
		/// The LocationChanged event registration.
		/// </summary>
		private static readonly SerializableEvent LocationChangedEvent;

		/// 
		/// The ControlAdded event registration.
		/// </summary>
		private static readonly SerializableEvent ControlAddedEvent;

		private static readonly SerializableEvent ControlEditingEvent;

		/// 
		/// The ControlRemoved event registration.
		/// </summary>
		private static readonly SerializableEvent ControlRemovedEvent;

		/// 
		/// The MouseDown event registration.
		/// </summary>
		internal static readonly SerializableEvent MouseDownEvent;

		/// 
		/// The MouseUp event registration.
		/// </summary>
		internal static readonly SerializableEvent MouseUpEvent;

		/// 
		/// The BindingContextChanged event registration.
		/// </summary>
		private static readonly SerializableEvent BindingContextChangedEvent;

		private static readonly SerializableEvent BackColorChangedEvent;

		private static readonly SerializableEvent BackgroundImageChangedEvent;

		private static readonly SerializableEvent BackgroundImageLayoutChangedEvent;

		private static readonly SerializableEvent FontChangedEvent;

		private static readonly SerializableEvent ForeColorChangedEvent;

		private static readonly SerializableEvent PaddingChangedEvent;

		/// 
		/// The CursorChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CursorChangedEvent;

		/// 
		/// The VisibleChanged event registration.
		/// </summary>
		private static readonly SerializableEvent VisibleChangedEvent;

		/// 
		/// The HelpRequested event registration.
		/// </summary>
		private static readonly SerializableEvent HelpRequestedEvent;

		/// 
		/// The AutoSizeChanged event registration.
		/// </summary>
		private static readonly SerializableEvent AutoSizeChangedEvent;

		/// 
		/// The CursorChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SizeChangedEvent;

		/// 
		/// Gets or sets the control styles.
		/// </summary>
		/// The control styles.</value>
		[NonSerialized]
		private ControlStyles menmControlStyle;

		/// 
		/// The collection of controls this control has 
		/// </summary>
		[NonSerialized]
		private ControlCollection mobjControls;

		/// 
		/// The height of the control.
		/// </summary>
		/// The height of the control.</value>
		[NonSerialized]
		private int mintHeight = 0;

		/// 
		/// The layout height of the control
		/// </summary>
		[NonSerialized]
		private int mintLayoutHeight = 0;

		/// 
		/// The preferred height of the control.
		/// </summary>
		/// The preferred height of the control.</value>
		[NonSerialized]
		private int mintPreferredHeight = -1;

		/// 
		/// The width of the control.
		/// </summary>
		/// The width of the control.</value>
		[NonSerialized]
		private int mintWidth = 0;

		/// 
		/// The layout width of the control.
		/// </summary>
		/// The layout width of the control.</value>
		[NonSerialized]
		private int mintLayoutWidth = 0;

		/// 
		/// The preferred width of the control.
		/// </summary>
		/// The preferred width of the control.</value>
		[NonSerialized]
		private int mintPreferredWidth = -1;

		/// 
		/// The left position of the control.
		/// </summary>
		[NonSerialized]
		private int mintLeft = 0;

		/// 
		/// The top position of the control.
		/// </summary>
		[NonSerialized]
		private int mintTop = 0;

		/// 
		/// The control tab index
		/// </summary>
		[NonSerialized]
		private int mintTabIndex = -1;

		/// 
		/// Control flags
		/// </summary>
		[NonSerialized]
		private int mintSuspendLayout = 0;

		/// 
		/// The current docking state
		/// </summary>
		[NonSerialized]
		private DockStyle menmDock = DockStyle.None;

		/// 
		/// The current anchoring state
		/// </summary>
		[NonSerialized]
		private AnchorStyles menmAnchor = AnchorStyles.Left | AnchorStyles.Top;

		/// 
		/// The component state
		/// </summary>
		[NonSerialized]
		private int mintControlState = 0;

		/// 
		/// The selected state
		/// </summary>
		[NonSerialized]
		private bool mblnSelectedIndicator = false;

		/// 
		/// The amount of fields that the control writes / reads
		/// </summary>
		private const int mcntSerializableDataFieldCount = 14;

		/// 
		/// The ObservableSuspendLayout event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableSuspendLayoutEvent;

		/// 
		/// The ObservableResumeLayout event registration.
		/// </summary>
		private static readonly SerializableEvent ObservableResumeLayoutEvent;

		private EditMode menmEditMode;

		/// 
		/// The skin of the current control
		/// </summary>
		/// 
		/// This field provides the Skin property its presistance an in serialization mode
		/// it is not required to be serialized as the Skin property automaticly generates and
		/// instance if this field is null.
		/// </remarks>
		[NonSerialized]
		private Gizmox.WebGUI.Forms.Skins.ControlSkin mobjSkin = null;

		/// 
		/// Gets the hanlder for the ParentChanged event.
		/// </summary>
		private EventHandler ParentChangedHandler => (EventHandler)GetHandler(ParentChanged);

		/// 
		/// Gets the hanlder for the Enter event.
		/// </summary>
		private EventHandler EnterHandler => (EventHandler)GetHandler(Enter);

		/// 
		/// Gets the hanlder for the Leave event.
		/// </summary>
		private EventHandler LeaveHandler => (EventHandler)GetHandler(Leave);

		private EventHandler ResizeHandler => (EventHandler)GetHandler(Resize);

		/// 
		/// Gets the hanlder for the EnabledChanged event.
		/// </summary>
		private EventHandler EnabledChangedHandler => (EventHandler)GetHandler(EnabledChanged);

		/// 
		/// Gets the control selected handler.
		/// </summary>
		private ControlsEventHandler ControlSelectedHandler => (ControlsEventHandler)GetHandler(ControlSelectedEvent);

		/// 
		/// Gets the control dropped handler.
		/// </summary>
		private ControlEventHandler ControlDroppedHandler => (ControlEventHandler)GetHandler(ControlDroppedEvent);

		/// 
		/// Gets the hanlder for the MouseClick event.
		/// </summary>
		private MouseEventHandler MouseClickHandler => (MouseEventHandler)GetHandler(MouseClickEvent);

		/// 
		/// Gets the hanlder for the KeyDown event.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected KeyEventHandler KeyDownHandler => (KeyEventHandler)GetHandler(KeyDown);

		/// 
		/// Gets the hanlder for the KeyPress event.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected KeyPressEventHandler KeyPressHandler => (KeyPressEventHandler)GetHandler(KeyPress);

		/// 
		/// Gets the hanlder for the KeyUp event.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected KeyEventHandler KeyUpHandler => (KeyEventHandler)GetHandler(KeyUp);

		/// 
		/// Gets the hanlder for the GotFocus event.
		/// </summary>
		private EventHandler GotFocusHandler => (EventHandler)GetHandler(GotFocus);

		/// 
		/// Gets the hanlder for the LostFocus event.
		/// </summary>
		private EventHandler LostFocusHandler => (EventHandler)GetHandler(LostFocus);

		/// 
		/// Gets the hanlder for the DoubleClick event.
		/// </summary>
		private EventHandler DoubleClickHandler => (EventHandler)GetHandler(DoubleClickEvent);

		private EventHandler TextChangedHandler => (EventHandler)GetHandler(TextChanged);

		/// 
		/// Gets the hanlder for the Validated event.
		/// </summary>
		private EventHandler ValidatedHandler => (EventHandler)GetHandler(Validated);

		/// 
		/// Gets the hanlder for the CausesValidationChanged event.
		/// </summary>
		private EventHandler CausesValidationChangedHandler => (EventHandler)GetHandler(CausesValidationChanged);

		/// 
		/// Gets the hanlder for the Validating event.
		/// </summary>
		private CancelEventHandler ValidatingHandler => (CancelEventHandler)GetHandler(Validating);

		private EventHandler TextChangedQueuedHandler => (EventHandler)GetHandler(TextChangedQueued);

		/// 
		/// Gets the hanlder for the LocationChanged event.
		/// </summary>
		private EventHandler LocationChangedHandler => (EventHandler)GetHandler(LocationChanged);

		/// 
		/// Gets the hanlder for the ControlAdded event.
		/// </summary>
		private ControlEventHandler ControlAddedHandler => (ControlEventHandler)GetHandler(ControlAdded);

		/// 
		/// Gets the hanlder for the ControlRemoved event.
		/// </summary>
		private ControlEventHandler ControlRemovedHandler => (ControlEventHandler)GetHandler(ControlRemoved);

		/// 
		/// Gets the hanlder for the MouseDown event.
		/// </summary>
		private MouseEventHandler MouseDownHandler => (MouseEventHandler)GetHandler(MouseDownEvent);

		/// 
		/// Gets the hanlder for the MouseUp event.
		/// </summary>
		private MouseEventHandler MouseUpHandler => (MouseEventHandler)GetHandler(MouseUpEvent);

		/// 
		/// Gets the position of the mouse cursor in screen coordinates.
		/// </summary>
		public static Point MousePosition => Cursor.Position;

		/// 
		/// Gets the hanlder for the BindingContextChanged event.
		/// </summary>
		private EventHandler BindingContextChangedHandler => (EventHandler)GetHandler(BindingContextChanged);

		private EventHandler BackColorChangedHandler => (EventHandler)GetHandler(BackColorChanged);

		private EventHandler BackgroundImageChangedHandler => (EventHandler)GetHandler(BackgroundImageChanged);

		private EventHandler BackgroundImageLayoutChangedHandler => (EventHandler)GetHandler(BackgroundImageLayoutChanged);

		private EventHandler FontChangedHandler => (EventHandler)GetHandler(FontChanged);

		private EventHandler ForeColorChangedHandler => (EventHandler)GetHandler(ForeColorChanged);

		private EventHandler PaddingChangedHandler => (EventHandler)GetHandler(PaddingChanged);

		/// 
		/// Gets the hanlder for the CursorChanged event.
		/// </summary>
		private EventHandler CursorChangedHandler => (EventHandler)GetHandler(CursorChanged);

		/// 
		/// Gets the hanlder for the VisibleChanged event.
		/// </summary>
		private EventHandler VisibleChangedHandler => (EventHandler)GetHandler(VisibleChanged);

		/// 
		/// Gets the hanlder for the HelpRequested event.
		/// </summary>
		private HelpEventHandler HelpRequestedHandler => (HelpEventHandler)GetHandler(HelpRequested);

		/// 
		/// Gets the hanlder for the AutoSizeChanged event.
		/// </summary>
		private EventHandler AutoSizeChangedHandler => (EventHandler)GetHandler(AutoSizeChanged);

		/// 
		/// Gets the hanlder for the CursorChanged event.
		/// </summary>
		private EventHandler SizeChangedHandler => (EventHandler)GetHandler(SizeChanged);

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize
		{
			get
			{
				int serializableDataInitialSize = base.SerializableDataInitialSize;
				serializableDataInitialSize += 14;
				if (ShouldSerializableObjectSerializeControls)
				{
					serializableDataInitialSize += SerializationWriter.GetRequiredCapacity(mobjControls);
				}
				return serializableDataInitialSize;
			}
		}

		/// 
		/// Gets a value indicating whether serializable object should serialize controls.
		/// </summary>
		/// 
		/// 	true</c> if serializable object should serialize controls; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual bool ShouldSerializableObjectSerializeControls => true;

		/// 
		/// Gets a value indicating whether [should auto validate].
		/// </summary>
		/// true</c> if [should auto validate]; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool ShouldAutoValidate => GetAutoValidateForControl(this) != AutoValidate.Disable;

		/// 
		/// Gets a flag indicating if this is a container control
		/// </summary>
		internal virtual bool IsContainerControl => false;

		/// Gets a value indicating whether the control, or one of its child controls, currently has the input focus.</summary>
		/// true if the control or one of its child controls currently has the input focus; otherwise, false.</returns>
		[SRDescription("ControlContainsFocusDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool ContainsFocus
		{
			get
			{
				IContext context = Context;
				if (context != null && context.ActiveForm is Form form)
				{
					if (this == form)
					{
						return true;
					}
					Control activeControl = form.ActiveControl;
					if (activeControl != null)
					{
						if (this == activeControl)
						{
							return true;
						}
						return Contains(activeControl);
					}
				}
				return false;
			}
		}

		/// Gets a value indicating whether the control has input focus.</summary>
		/// true if the control has focus; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[SRDescription("ControlFocusedDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool Focused
		{
			get
			{
				if (Context is IApplicationContext applicationContext)
				{
					return applicationContext.IsFocused(this);
				}
				return false;
			}
		}

		/// 
		/// Gets the children.
		/// </summary>
		/// The children.</value>
		ArrangedElementCollection IArrangedElement.Children => Controls;

		/// 
		/// Gets a value indicating whether [participates in layout].
		/// </summary>
		/// 
		/// 	true</c> if [participates in layout]; otherwise, false</c>.
		/// </value>
		bool IArrangedElement.ParticipatesInLayout => VisibleIntenal;

		/// 
		/// Gets the hanlder for the ObservableSuspendLayout event.
		/// </summary>
		private EventHandler ObservableSuspendLayoutHandler => (EventHandler)GetHandler(ObservableSuspendLayout);

		/// 
		/// Gets the hanlder for the ObservableResumeLayout event.
		/// </summary>
		private ObservableResumeLayoutHandler ObservableResumeLayoutHandler => (ObservableResumeLayoutHandler)GetHandler(ObservableResumeLayout);

		/// 
		/// Gets the create params.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual CreateParams CreateParams => null;

		/// 
		/// Gets a value indicating whether [can edit control].
		/// </summary>
		/// 
		///   true</c> if [can edit control]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool CanEditControl => false;

		/// 
		/// Gets or sets the edit control mode.
		/// </summary>
		/// 
		/// The edit control mode.
		/// </value>
		[DefaultValue(EditMode.Off)]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditMode EditControlMode
		{
			get
			{
				return GetProxyPropertyValue("EditControlMode", menmEditMode);
			}
			set
			{
				if (CanEditControl)
				{
					SetEditControlMode(value, blnFromClient: false);
					return;
				}
				throw new InvalidOperationException($"Control of type '{GetType().FullName}' cannot be edited. To edit override the 'CanEditControl' property");
			}
		}

		/// 
		/// Gets a value indicating whether this instance can access properties.
		/// </summary>
		/// 
		/// 	true</c> if this instance can access properties; otherwise, false</c>.
		/// </value>
		internal virtual bool CanAccessProperties => true;

		/// 
		/// Set text without raising any events
		/// </summary>
		internal virtual string InternalText
		{
			set
			{
				if (SetValue(TextProperty, value))
				{
					OnTextChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [becoming active control].
		/// </summary>
		/// 
		/// 	true</c> if [becoming active control]; otherwise, false</c>.
		/// </value>
		internal bool BecomingActiveControl
		{
			get
			{
				return GetState(ControlState.BecomingActiveControl);
			}
			set
			{
				SetState(ControlState.BecomingActiveControl, value);
			}
		}

		/// 
		/// Gets or sets the text associated with this control.  
		/// </summary>
		[DefaultValue("")]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlTextDescr")]
		[Localizable(true)]
		[Bindable(true)]
		[ProxyBrowsable(true)]
		public virtual string Text
		{
			get
			{
				return GetProxyPropertyValue("Text", GetValue(TextProperty));
			}
			set
			{
				string objValue = ((value == null) ? string.Empty : value);
				if (SetValue(TextProperty, objValue))
				{
					UpdateParams(AttributeType.Control);
					OnTextChanged(EventArgs.Empty);
					FireObservableItemPropertyChanged("Text");
				}
			}
		}

		/// 
		/// Gets or sets the text associated with this control.  
		/// </summary>
		internal string ToolTip
		{
			get
			{
				return GetValue(ToolTipProperty);
			}
			set
			{
				if (SetValue(ToolTipProperty, value))
				{
					UpdateParams(AttributeType.ToolTip);
					FireObservableItemPropertyChanged("ToolTip");
				}
			}
		}

		/// 
		/// Gets the extended tool tip descriptor.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolTipDescriptor ExtendedToolTipDescriptor
		{
			get
			{
				return GetValue(ExtendedToolTipDescriptorProperty);
			}
			set
			{
				if (SetValue(ExtendedToolTipDescriptorProperty, value))
				{
					UpdateParams(AttributeType.ToolTip);
				}
			}
		}

		/// 
		/// Gets which multi theme to skip when writing the html.
		/// </summary>
		protected virtual ControlSkipMultiTheme SkipMultiTheme => ControlSkipMultiTheme.None;

		/// 
		/// Gets the control tag name.  
		/// </summary>
		/// 
		/// This property by default reverts to the previous implementation 
		/// of setting the TagName property, which is obsolete. To use the newer approach which is 
		/// using the MetadataTag attribute do not use the TagName property.
		/// </remarks>
		protected string MetadataTag
		{
			get
			{
				string value = GetValue(TagNameProperty);
				if (CommonUtils.IsNullOrEmpty(value))
				{
					return Metadata.GetTag(this);
				}
				return value;
			}
		}

		/// 
		/// Gets or sets the control tag name.  
		/// </summary>
		[Obsolete("Use MetadataTagAttribute to set tag name or Control.MetadataTag to get tag name.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected string TagName
		{
			get
			{
				return GetValue(TagNameProperty);
			}
			set
			{
				SetValue(TagNameProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether to reverse control rendering.
		/// </summary>
		/// true</c> if to reverse control rendering; otherwise, false</c>.</value>
		protected virtual bool ReverseControls => false;

		/// 
		/// Gets or sets the name associated with this control.  
		/// </summary>
		[Browsable(false)]
		[DefaultValue("")]
		public string Name
		{
			get
			{
				string text = (string.IsNullOrEmpty(AccessibleName) ? GetValue(NameProperty) : AccessibleName);
				if (string.IsNullOrEmpty(text))
				{
					if (Site != null)
					{
						text = Site.Name;
					}
					if (text == null)
					{
						text = string.Empty;
					}
				}
				return text;
			}
			set
			{
				if (value == null)
				{
					SetValue(NameProperty, string.Empty);
				}
				else
				{
					SetValue(NameProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the accessible name associated with this control.  
		/// </summary>
		[SRCategory("CatAccessibility")]
		[SRDescription("ControlAccessibleNameDescr")]
		[Localizable(true)]
		[Browsable(true)]
		[DefaultValue("")]
		public string AccessibleName
		{
			get
			{
				return GetValue(AccessibleNameProperty);
			}
			set
			{
				if (SetValue(AccessibleNameProperty, value))
				{
					UpdateParams(AttributeType.Accessibility);
				}
			}
		}

		/// 
		/// Gets or sets the accessible description associated with this control.  
		/// </summary>
		[SRCategory("CatAccessibility")]
		[SRDescription("ControlAccessibleDescriptionDescr")]
		[Localizable(true)]
		[Browsable(true)]
		[DefaultValue("")]
		public string AccessibleDescription
		{
			get
			{
				return GetValue(AccessibleDescriptionProperty);
			}
			set
			{
				if (SetValue(AccessibleDescriptionProperty, value))
				{
					UpdateParams(AttributeType.Accessibility);
				}
			}
		}

		/// 
		/// Gets the resizable allowed directions.
		/// </summary>
		protected virtual string[] ResizableAllowedDirections => null;

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is resizable.
		/// </summary>
		/// 
		///   true</c> if resizable; otherwise, false</c>.
		/// </value>
		[Description("Properties representing if the control is resizable.")]
		[SRCategory("CatBehavior")]
		public virtual ResizableOptions Resizable
		{
			get
			{
				ResizableOptions resizableOptions = ResizableInternal;
				if (resizableOptions == null)
				{
					resizableOptions = (Resizable = new ResizableOptions(blnIsResizable: false));
				}
				return resizableOptions;
			}
			set
			{
				value.Owner = this;
				if (SetValue(ResizableProperty, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets the resizable internally.
		/// </summary>
		/// 
		/// The resizable value.
		/// </value>
		private ResizableOptions ResizableInternal => GetValue(ResizableProperty);

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is draggable.
		/// </summary>
		/// 
		///   true</c> if draggable; otherwise, false</c>.
		/// </value>
		[Description("Properties representing if the control is draggable.")]
		[SRCategory("CatBehavior")]
		public virtual DraggableOptions Draggable
		{
			get
			{
				DraggableOptions draggableOptions = DraggableInternal;
				if (draggableOptions == null)
				{
					draggableOptions = (Draggable = new DraggableOptions(blnIsDraggable: false));
				}
				return draggableOptions;
			}
			set
			{
				value.Owner = this;
				if (SetValue(DraggableProperty, value))
				{
					UpdateParams(AttributeType.Drag);
				}
			}
		}

		/// 
		/// Gets the draggable internally.
		/// </summary>
		/// 
		/// The draggable value.
		/// </value>
		private DraggableOptions DraggableInternal => GetValue(DraggableProperty);

		/// 
		/// Gets a value indicating whether this instance can focus.
		/// </summary>
		/// 
		/// 	true</c> if this instance can focus; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		public virtual bool CanFocus => Enabled && Visible;

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected virtual bool Focusable => false;

		/// Gets a value indicating whether the control can be selected.</summary>
		/// true if the control can be selected; otherwise, false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatFocus")]
		[SRDescription("ControlCanSelectDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CanSelect => CanSelectCore();

		/// Gets the default font of the control.</summary>
		/// The default <see cref="T:System.Drawing.Font"></see> of the control. The value returned will vary depending on the user's operating system the local culture setting of their system.</returns>
		/// <exception cref="T:System.ArgumentException">The default font or the regional alternative fonts are not installed on the client computer. </exception>
		/// 1</filterpriority>
		public static Font DefaultFont => ThemeFonts.DefaultFont;

		/// 
		/// Gets a value indicating whether [supports focus events].
		/// </summary>
		/// true</c> if [supports focus events]; otherwise, false</c>.</value>
		protected internal virtual bool SupportsFocusEvents => true;

		/// 
		/// Gets or sets the registered timers.
		/// </summary>
		/// The registered timers.</value>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Timer[] RegisteredTimers
		{
			get
			{
				return GetValue<Timer[]>(RegisteredTimersProperty);
			}
			set
			{
				SetValue(RegisteredTimersProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether [use preferred size].
		/// </summary>
		/// true</c> if [use preferred size]; otherwise, false</c>.</value>
		protected internal virtual bool UsePreferredSize => AutoSize;

		/// 
		/// Gets the modifier keys.
		/// </summary>
		/// The modifier keys.</value>
		public static Keys ModifierKeys
		{
			get
			{
				if (!(VWGContext.Current is IContextParams { ModifierKeys: var modifierKeys }))
				{
					return Keys.None;
				}
				return modifierKeys;
			}
		}

		/// 
		/// Gets or sets the IME mode.
		/// </summary>
		/// 
		/// The IME mode.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImeMode ImeMode
		{
			get
			{
				return GetValue(ImeModeProperty);
			}
			set
			{
				SetValue(ImeModeProperty, value);
			}
		}

		/// Gets or sets a value indicating whether this control should redraw its surface using a secondary buffer to reduce or prevent flicker.</summary>
		/// true if the surface of the control should be drawn using double buffering; otherwise, false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[SRDescription("ControlDoubleBufferedDescr")]
		protected virtual bool DoubleBuffered
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Gets the top level control.
		/// </summary>
		[SRCategory("CatBehavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlTopLevelControlDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public Control TopLevelControl => TopLevelControlInternal;

		/// 
		/// Gets the client rectangle.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Rectangle ClientRectangle => new Rectangle(Location, ClientSize);

		/// 
		/// Gets a value indicating whether [supports key navigation].
		/// </summary>
		/// 
		/// true</c> if [supports key navigation]; otherwise, false</c>.
		/// </value>
		protected virtual bool SupportsKeyNavigation => true;

		/// 
		/// Gets a value indicating whether this instance has tab index.
		/// </summary>
		/// 
		/// 	true</c> if this instance has tab index; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool HasTabIndex => mintTabIndex != -1;

		/// 
		/// Gets a value indicating whether this instance is defined for tabbing as group.
		/// </summary>
		/// 
		/// 	true</c> if this instance is tab for group; otherwise, false</c>.
		/// </value>
		protected virtual bool EnableGroupTabbing => false;

		/// 
		/// Gets or sets a value indicating whether [visible intenal].
		/// </summary>
		/// true</c> if [visible intenal]; otherwise, false</c>.</value>
		internal bool VisibleIntenal
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				SetState(ComponentState.Visible, value);
			}
		}

		/// 
		/// Gets a value indicating whether raise click event on right mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise right click event on mouse down; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual bool ShouldRaiseClickOnRightMouseDown
		{
			get
			{
				if (base.ContextMenuInherited != null || base.ContextMenuStripInherited != null)
				{
					return false;
				}
				return true;
			}
		}

		/// 
		/// Gets the top level control internal.
		/// </summary>
		internal Control TopLevelControlInternal
		{
			get
			{
				Control control = this;
				while (control != null && !control.GetTopLevel())
				{
					control = ((!(control is Form { IsMdiChild: not false, MdiParent: not null } form)) ? control.ParentInternal : form.MdiParent);
				}
				return control;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [selected indicator].
		/// </summary>
		/// 
		///   true</c> if [selected indicator]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlSelectedIndicatorDescr")]
		public bool SelectedIndicator
		{
			get
			{
				return mblnSelectedIndicator;
			}
			set
			{
				if (mblnSelectedIndicator != value)
				{
					mblnSelectedIndicator = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new ControlWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ControlWinFormsCompatibility;

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled
		{
			get
			{
				if (!Enabled || !Visible)
				{
					return false;
				}
				return base.IsEventsEnabled;
			}
		}

		/// 
		///  Gets the collection of controls contained within the control. 
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ControlCollection Controls
		{
			get
			{
				if (mobjControls == null)
				{
					mobjControls = CreateControlsInstance();
				}
				return mobjControls;
			}
		}

		/// 
		/// Return the control child controls
		/// </summary>
		[Browsable(false)]
		IList IControl.Controls => Controls;

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Common.Interfaces.IControl" /> is name.
		/// </summary>
		/// true</c> if name; otherwise, false</c>.</value>
		[Browsable(false)]
		string IControl.Name
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}

		/// 
		/// Returns the control parent control
		/// </summary>
		IControl IControl.Parent => Parent;

		/// 
		/// Gets a value indicating whether this control has children.
		/// </summary>
		/// 
		/// 	true</c> if this control has children; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		public bool HasChildren
		{
			get
			{
				if (mobjControls == null)
				{
					return false;
				}
				return mobjControls.Count > 0;
			}
		}

		/// 
		/// Gets or sets the parent container of this control.
		/// </summary>
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.ParentEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Control Parent
		{
			get
			{
				return ParentInternal;
			}
			set
			{
				ParentInternal = value;
			}
		}

		/// 
		/// Gets the get offlien parent.
		/// </summary>
		protected override IClientComponent ClientParent => Parent;

		/// 
		/// Gets or sets the parent container of this control.
		/// </summary>
		/// </value>
		internal virtual Control ParentInternal
		{
			get
			{
				return base.InternalParent as Control;
			}
			set
			{
				Control control = InternalParent as Control;
				if (control != value)
				{
					if (value != null)
					{
						value.Controls.Add(this);
					}
					else
					{
						control.Controls.Remove(this);
					}
				}
			}
		}

		/// 
		/// 	Not Implemented Property.</para>
		/// 	Gets the size of a rectangular area into which the control can fit.</para>
		/// </summary>            
		/// A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public Size PreferredSize
		{
			get
			{
				if (mintPreferredHeight != -1 && mintPreferredWidth != -1)
				{
					return new Size(mintPreferredWidth, mintPreferredHeight);
				}
				return Size.Empty;
			}
		}

		/// Gets or sets the size that is the upper limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		/// 1</filterpriority>
		[AmbientValue(typeof(Size), "0, 0")]
		[SRDescription("ControlMaximumSizeDescr")]
		[SRCategory("CatLayout")]
		public virtual Size MaximumSize
		{
			get
			{
				return GetValue(MaximumSizeProperty, DefaultMaximumSize);
			}
			set
			{
				if (SetValue(MaximumSizeProperty, value))
				{
					SetMaximumSize(this, value);
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// Gets the length and height, in pixels, that is specified as the default maximum size of a control.</summary>
		/// A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
		protected virtual Size DefaultMaximumSize => new Size(0, 0);

		/// Gets the length and height, in pixels, that is specified as the default minimum size of a control.</summary>
		/// A <see cref="M:System.Drawing.Point.#ctor(System.Drawing.Size)"></see> representing the size of the control.</returns>
		protected virtual Size DefaultMinimumSize => new Size(0, 0);

		/// Gets or sets the size that is the lower limit that <see cref="M:Gizmox.WebGUI.Forms.Control.GetPreferredSize(System.Drawing.Size)"></see> can specify.</summary>
		/// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
		/// 1</filterpriority>
		[SRCategory("CatLayout")]
		[SRDescription("ControlMinimumSizeDescr")]
		public virtual Size MinimumSize
		{
			get
			{
				return GetValue(MinimumSizeProperty, DefaultMinimumSize);
			}
			set
			{
				if (SetValue(MinimumSizeProperty, value, DefaultMinimumSize))
				{
					SetMinimumSize(this, value);
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets or sets the key down filter.
		/// </summary>
		/// The key down filter.</value>
		[Description("The key down filter.")]
		[SRCategory("CatBehavior")]
		[DefaultValue(KeyFilter.All)]
		public KeyFilter KeyFilter
		{
			get
			{
				return GetValue(KeyFilterProperty);
			}
			set
			{
				if (SetValue(KeyFilterProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Returns the current version info
		/// </summary>
		private ControlVersionInfo VersionInfo => new ControlVersionInfo(this);

		/// Gets the name of the company or creator of the application containing the control.</summary>
		/// The company name or creator of the application containing the control.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("ControlCompanyNameDescr")]
		public string CompanyName => VersionInfo.CompanyName;

		/// Gets the product name of the assembly containing the control.</summary>
		/// The product name of the assembly containing the control.</returns>
		/// 1</filterpriority>
		[SRDescription("ControlProductNameDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string ProductName => VersionInfo.ProductName;

		/// Gets the version of the assembly containing the control.</summary>
		/// The file version of the assembly containing the control.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlProductVersionDescr")]
		public string ProductVersion => VersionInfo.ProductVersion;

		/// 
		/// Gets or sets the ScrollTop property.
		/// </summary>
		/// The ScrollTop property</value>
		protected int ScrollTop
		{
			get
			{
				return GetValue(ScrollTopProperty);
			}
			set
			{
				if (SetScrollTop(value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets a value indicating whether [horizontal centered].
		/// </summary>
		/// true</c> if [horizontal centered]; otherwise, false</c>.</value>
		internal bool HorizontalCentered => (Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == 0;

		/// 
		/// Gets a value indicating whether [vertical centered].
		/// </summary>
		/// true</c> if [vertical centered]; otherwise, false</c>.</value>
		internal bool VerticalCentered => (Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == 0;

		/// 
		/// Gets or sets the ScrollLeft property.
		/// </summary>
		/// The ScrollLeft property</value>
		protected int ScrollLeft
		{
			get
			{
				return GetValue(ScrollLeftProperty);
			}
			set
			{
				if (SetScrollLeft(value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the control visability.  
		/// </summary>
		[DefaultValue(true)]
		[SRDescription("ControlVisibleDescr")]
		[SRCategory("CatBehavior")]
		public bool Visible
		{
			get
			{
				if (base.DesignMode)
				{
					return GetState(ComponentState.Visible);
				}
				return GetVisibleCore();
			}
			set
			{
				SetVisibleInternal(value);
			}
		}

		/// 
		/// Gets or sets the control enabled state.  
		/// </summary>
		[DefaultValue(true)]
		[SRDescription("ControlEnabledDescr")]
		[SRCategory("CatBehavior")]
		public virtual bool Enabled
		{
			get
			{
				bool state = GetState(ComponentState.Enabled);
				if (base.DesignMode)
				{
					return state;
				}
				if (!state)
				{
					return false;
				}
				return ParentInternal?.Enabled ?? true;
			}
			set
			{
				SetEnabled(value, AttributeType.Enabled);
			}
		}

		/// 
		/// Gets a value indicating whether [enabled internal].
		/// </summary>
		/// 
		///   true</c> if [enabled internal]; otherwise, false</c>.
		/// </value>
		private bool EnabledInternal => GetState(ComponentState.Enabled);

		/// Gets a value indicating whether the control has a handle associated with it.</summary>
		/// true if a handle has been assigned to the control; otherwise, false.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("ControlHandleCreatedDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool IsHandleCreated => base.IsRegistered;

		/// Gets a value indicating whether the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing.</summary>
		/// true if the base <see cref="T:Gizmox.WebGUI.Forms.Control"></see> class is in the process of disposing; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlDisposingDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool Disposing => false;

		/// Gets a value indicating whether the control has been disposed of.</summary>
		/// true if the control has been disposed of; otherwise, false.</returns>
		/// 2</filterpriority>
		[SRDescription("ControlDisposedDescr")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool IsDisposed => false;

		/// 
		/// Gets the parent container control.
		/// </summary>
		/// The parent container control.</value>
		internal ContainerControl ParentContainerControl
		{
			get
			{
				for (Control parentInternal = ParentInternal; parentInternal != null; parentInternal = parentInternal.ParentInternal)
				{
					if (parentInternal is ContainerControl)
					{
						return parentInternal as ContainerControl;
					}
				}
				return null;
			}
		}

		/// Gets the handle that the control is bound to.</summary>
		/// An <see cref="T:System.IntPtr"></see> that contains the handle of the control.</returns>
		/// 2</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[SRDescription("ControlHandleDescr")]
		public IntPtr Handle => new IntPtr(ID);

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// 
		/// 	true</c> if tab stop is enabled; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[SRDescription("ControlTabStopDescr")]
		[SRCategory("CatBehavior")]
		public virtual bool TabStop
		{
			get
			{
				return GetState(ControlState.TabStop);
			}
			set
			{
				if (SetStateWithCheck(ControlState.TabStop, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.</summary>
		/// One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
		[SRDescription("ControlBackgroundImageLayoutDescr")]
		[DefaultValue(ImageLayout.Tile)]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[ProxyBrowsable(true)]
		public virtual ImageLayout BackgroundImageLayout
		{
			get
			{
				return GetValue(BackgroundImageLayoutProperty);
			}
			set
			{
				if (SetValue(BackgroundImageLayoutProperty, value))
				{
					Update();
					OnBackgroundImageLayoutChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets the background image displayed in the control.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		[SRDescription("ControlBackgroundImageDescr")]
		[ProxyBrowsable(true)]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		public virtual ResourceHandle BackgroundImage
		{
			get
			{
				return GetValue(BackgroundImageProperty);
			}
			set
			{
				if (SetValue(BackgroundImageProperty, value))
				{
					Update();
					OnBackgroundImageChanged(EventArgs.Empty);
					FireObservableItemPropertyChanged("BackgroundImage");
				}
			}
		}

		/// 
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlFontDescr")]
		[ProxyBrowsable(true)]
		public virtual Font Font
		{
			get
			{
				return GetValue(FontProperty, DefaultControlFont);
			}
			set
			{
				if (SetValue(FontProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
					OnFontChanged(EventArgs.Empty);
					FireObservableItemPropertyChanged("Font");
				}
			}
		}

		/// Gets or sets where this control is scrolled to in <see cref="M:System.Windows.Forms.ScrollableControl.ScrollControlIntoView(System.Windows.Forms.Control)"></see>.</summary>
		/// A <see cref="T:System.Drawing.Point"></see> specifying the scroll location. The default is the upper-left corner of the control.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(typeof(Point), "0, 0")]
		public virtual Point AutoScrollOffset
		{
			get
			{
				return Point.Empty;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the visual template.
		/// </summary>
		/// 
		/// The visual template.
		/// </value>
		[ProxyBrowsable(true)]
		[Description("Sets the appearance of the control without changing its state")]
		[SRCategory("CatAppearance")]
		public virtual VisualTemplate VisualTemplate
		{
			get
			{
				return GetValue(VisualTemplateProperty, null);
			}
			set
			{
				if (SetValue(VisualTemplateProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
					FireObservableItemPropertyChanged("VisualTemplate");
				}
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[SRDescription("ControlPaddingDescr")]
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[ProxyBrowsable(true)]
		public virtual Padding Padding
		{
			get
			{
				return GetValue(PaddingProperty, DefaultPadding);
			}
			set
			{
				Padding padding = Padding;
				if (SetValue(PaddingProperty, value, DefaultPadding))
				{
					OnPaddingChanged(EventArgs.Empty);
					Update();
					FireObservableItemPropertyChanged("Padding");
					UpdateChildSize(padding.Horizontal != value.Horizontal, padding.Vertical != value.Vertical);
				}
			}
		}

		/// Gets or sets the space between controls.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> representing the space between controls.</returns>
		/// 2</filterpriority>
		[Localizable(true)]
		[SRDescription("ControlMarginDescr")]
		[SRCategory("CatLayout")]
		[ProxyBrowsable(true)]
		public Padding Margin
		{
			get
			{
				return GetValue(MarginProperty, DefaultMargin);
			}
			set
			{
				Padding margin = Margin;
				if (SetValue(MarginProperty, value, DefaultMargin))
				{
					Update();
					FireObservableItemPropertyChanged("Margin");
					InvalidateParentLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: false));
					UpdateChildSize(margin.Horizontal != value.Horizontal, margin.Vertical != value.Vertical);
				}
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		[DefaultValue(DockStyle.None)]
		[SRCategory("CatLayout")]
		[SRDescription("ControlDockDescr")]
		[ProxyBrowsable(true)]
		public virtual DockStyle Dock
		{
			get
			{
				return GetDockInternal();
			}
			set
			{
				if (menmDock != value)
				{
					DockStyle enmCurrentVal = menmDock;
					menmDock = value;
					if (Parent != null)
					{
						Parent.UpdateParams(AttributeType.Redraw);
					}
					menmAnchor = AnchorStyles.Left | AnchorStyles.Top;
					ApplyPreReleaseDockFillCompatibility();
					FireObservableItemPropertyChanged("Dock");
					UpdateParams(AttributeType.Layout);
					UpdateChildSizeAfterDockChange(enmCurrentVal, menmDock);
				}
			}
		}

		/// 
		/// Gets or sets the anchoring style.
		/// </summary>
		/// </value>
		[SRCategory("CatLayout")]
		[SRDescription("ControlAnchorDescr")]
		[ProxyBrowsable(true)]
		public virtual AnchorStyles Anchor
		{
			get
			{
				return GetAnchorInternal();
			}
			set
			{
				if (menmAnchor != value)
				{
					menmAnchor = value;
					menmDock = DockStyle.None;
					Update();
					FireObservableItemPropertyChanged("Anchor");
				}
			}
		}

		/// This property is not relevant for this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[RefreshProperties(RefreshProperties.All)]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlAutoSizeDescr")]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		public virtual bool AutoSize
		{
			get
			{
				return GetState(ControlState.AutoSize);
			}
			set
			{
				if (SetStateWithCheck(ControlState.AutoSize, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
					OnAutoSizeChanged(EventArgs.Empty);
					FireObservableItemPropertyChanged("AutoSize");
				}
			}
		}

		/// 
		/// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
		/// </summary>
		[RefreshProperties(RefreshProperties.All)]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ControlAutoSizeModeDescr")]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(AutoSizeMode.GrowOnly)]
		public virtual AutoSizeMode AutoSizeMode
		{
			get
			{
				return GetValue(AutoSizeModeProperty);
			}
			set
			{
				if (SetValue(AutoSizeModeProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// 
		/// Gets the display rectangle.
		/// </summary>
		/// The display rectangle.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("ControlDisplayRectangleDescr")]
		[Browsable(false)]
		public virtual Rectangle DisplayRectangle => new Rectangle(Location, DisplaySize);

		/// 
		/// Gets the display size.
		/// </summary>
		/// Provides enhancment for performance that cancels the need to get the location for setting the display size.</remarks>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		protected virtual Size DisplaySize => Size;

		/// 
		/// Gets the control contained area offset.
		/// </summary>
		protected virtual PaddingValue ContainedAreaOffset
		{
			get
			{
				if (BorderStyle != BorderStyle.None)
				{
					Padding objValue = default(Padding);
					BorderWidth borderWidth = BorderWidth;
					objValue.Bottom = borderWidth.Bottom;
					objValue.Top = borderWidth.Top;
					objValue.Left = borderWidth.Left;
					objValue.Right = borderWidth.Right;
					return new PaddingValue(objValue);
				}
				return Padding.Empty;
			}
		}

		/// 
		/// Gets the horizontal contained area offset.
		/// </summary>
		private int HorizontalContainedAreaOffset
		{
			get
			{
				PaddingValue containedAreaOffset = ContainedAreaOffset;
				return containedAreaOffset.Left + containedAreaOffset.Right;
			}
		}

		/// 
		/// Gets the vertical contained area offset.
		/// </summary>
		private int VerticalContainedAreaOffset
		{
			get
			{
				PaddingValue containedAreaOffset = ContainedAreaOffset;
				return containedAreaOffset.Top + containedAreaOffset.Bottom;
			}
		}

		/// 
		/// Gets a value indicating whether this control requires layout. Will effect controls with autosize or autoscrol.
		/// </summary>
		/// true</c> if control requires layout; otherwise, false</c>.</value>
		internal virtual bool RequiresLayout => AutoSize;

		/// 
		/// Gets or sets the control location.
		/// </summary>
		/// </value>
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[SRDescription("ControlLocationDescr")]
		[ProxyBrowsable(true)]
		public Point Location
		{
			get
			{
				return new Point(Left, Top);
			}
			set
			{
				if (SetBounds(value.X, value.Y, 0, 0, BoundsSpecified.Location))
				{
					OnLocationChangedInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
					FireObservableItemPropertyChanged("Location");
					if (!IsDocked(Dock))
					{
						UpdateParams(AttributeType.Layout);
					}
				}
			}
		}

		/// 
		/// Gets or sets the size.
		/// </summary>
		/// The size.</value>
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[SRDescription("ControlSizeDescr")]
		[ProxyBrowsable(true)]
		public Size Size
		{
			get
			{
				return new Size(Width, Height);
			}
			set
			{
				if (SetBounds(0, 0, value.Width, value.Height, BoundsSpecified.Size))
				{
					OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					FireObservableItemPropertyChanged("Size");
					UpdateSizeLayuoutParams(blnUpdateCurrent: true, blnForceChildUpdate: false);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to use WG namespace.
		/// </summary>
		/// 
		/// 	true</c> if to use WG namespace; otherwise, false</c>.
		/// </value>
		internal virtual bool UseWGNamespace => false;

		/// 
		/// Gets the layout location.
		/// </summary>
		/// The layout location.</value>
		internal Point LayoutLocation => new Point(mintLeft, mintTop);

		/// 
		/// Gets or sets the tab index.
		/// </summary>
		/// </value>
		[SRDescription("ControlTabIndexDescr")]
		[MergableProperty(false)]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int TabIndex
		{
			get
			{
				if (mintTabIndex != -1)
				{
					return mintTabIndex;
				}
				return 0;
			}
			set
			{
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"TabIndex",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("TabIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				mintTabIndex = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [validation cancelled].
		/// </summary>
		/// true</c> if [validation cancelled]; otherwise, false</c>.</value>
		internal bool ValidationCancelled
		{
			get
			{
				if (GetState(ControlState.ValidationCancelled))
				{
					return true;
				}
				return ParentInternal?.ValidationCancelled ?? false;
			}
			set
			{
				SetState(ControlState.ValidationCancelled, value);
			}
		}

		/// 
		/// Gets/Sets the top position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Top
		{
			get
			{
				return GetCalculatedTop(IsLayoutSuspended || base.DesignMode);
			}
			set
			{
				if (SetBounds(0, value, 0, 0, BoundsSpecified.Y) && !IsDocked(Dock))
				{
					OnLocationChangedInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets/Sets the bottom position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Bottom => Top + Height;

		/// 
		/// Gets or sets a value indicating whether to force content availability on client side.
		/// </summary>
		/// 
		/// 	true</c> if [force content availability on client side]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[SRDescription("ForceContentAvailabilityOnClientDescr")]
		[SRCategory("CatBehavior")]
		public bool ForceContentAvailabilityOnClient
		{
			get
			{
				return GetValue(ForceContentAvailabilityOnClientProperty);
			}
			set
			{
				if (SetValue(ForceContentAvailabilityOnClientProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets/Sets the left position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Left
		{
			get
			{
				return GetCalculatedLeft(IsLayoutSuspended || base.DesignMode);
			}
			set
			{
				if (SetBounds(value, 0, 0, 0, BoundsSpecified.X) && !IsDocked(Dock))
				{
					OnLocationChangedInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets the height of the layout.
		/// </summary>
		/// The height of the layout.</value>
		internal int LayoutHeight => mintHeight;

		/// 
		/// Gets the width of the layout.
		/// </summary>
		/// The width of the layout.</value>
		internal int LayoutWidth => mintWidth;

		/// 
		/// Gets the left value relative to the center of the container
		/// </summary>
		private int CenteredLeft
		{
			get
			{
				Control parent = Parent;
				if (parent != null)
				{
					if (parent is TableLayoutPanel)
					{
						return -(Width / 2);
					}
					return LayoutLeft - parent.mintLayoutWidth / 2;
				}
				return 0;
			}
		}

		/// 
		/// Gets the top value relative to the center of the container
		/// </summary>
		private int CenteredTop
		{
			get
			{
				Control parent = Parent;
				if (parent != null)
				{
					if (parent is TableLayoutPanel)
					{
						return -(Height / 2);
					}
					return LayoutTop - parent.mintLayoutHeight / 2;
				}
				return 0;
			}
		}

		/// 
		/// Gets the layout left.
		/// </summary>
		/// The layout left.</value>
		internal int LayoutLeft => mintLeft;

		/// 
		/// Gets the layout right (based on the layout width).
		/// </summary>
		/// The layout right.</value>
		internal int LayoutRight
		{
			get
			{
				Control parent = Parent;
				if (parent != null)
				{
					if (parent is ScrollableControl { AutoScroll: not false, DisplaySize: var displaySize } && displaySize.Width > parent.mintLayoutWidth)
					{
						return displaySize.Width - (mintLeft + Width);
					}
					return parent.mintLayoutWidth - (mintLeft + Width);
				}
				return mintLeft + mintWidth;
			}
		}

		/// 
		/// Gets the layout bottom (based on the layout height).
		/// </summary>
		/// The layout bottom.</value>
		internal int LayoutBottom
		{
			get
			{
				Control parent = Parent;
				if (parent != null)
				{
					if (parent is ScrollableControl { AutoScroll: not false, DisplaySize: var displaySize } && displaySize.Height > parent.mintLayoutHeight)
					{
						return displaySize.Height - (mintTop + Height);
					}
					return parent.mintLayoutHeight - (mintTop + Height);
				}
				return mintTop + mintHeight;
			}
		}

		/// 
		/// Gets the layout top.
		/// </summary>
		/// The layout top.</value>
		internal int LayoutTop => mintTop;

		/// Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus.</summary>
		/// true if the control causes validation to be performed on any controls requiring validation when it receives focus; otherwise, false. The default is true.</returns>
		/// 2</filterpriority>
		[DefaultValue(true)]
		[SRDescription("ControlCausesValidationDescr")]
		[SRCategory("CatFocus")]
		public bool CausesValidation
		{
			get
			{
				return GetState(ControlState.CausesValidation);
			}
			set
			{
				if (SetStateWithCheck(ControlState.CausesValidation, value))
				{
					OnCausesValidationChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets/Sets the right position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Right => Left + Width;

		/// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ControlRightToLeftDescr")]
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		public virtual RightToLeft RightToLeft
		{
			get
			{
				RightToLeft rightToLeft = GetValue(RightToLeftProperty);
				if (rightToLeft == RightToLeft.Inherit)
				{
					rightToLeft = (RightToLeft)(((int?)ParentInternal?.RightToLeft) ?? ((Context != null) ? (Context.RightToLeft ? 1 : 0) : 0));
				}
				return rightToLeft;
			}
			set
			{
				if (SetValue(RightToLeftProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets/Sets the height position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Height
		{
			get
			{
				return GetCalculatedHeight(IsLayoutSuspended || base.DesignMode);
			}
			set
			{
				SetHeight(value, blnUpdateCurrent: true);
			}
		}

		/// 
		/// Gets/Sets the width position
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Width
		{
			get
			{
				return GetCalculatedWidth(IsLayoutSuspended || base.DesignMode);
			}
			set
			{
				if (SetBounds(0, 0, value, 0, BoundsSpecified.Width))
				{
					OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					DockStyle dock = Dock;
					if (dock != DockStyle.Fill && dock != DockStyle.Top && dock != DockStyle.Bottom)
					{
						UpdateSizeLayuoutParams(blnUpdateCurrent: true, blnForceChildUpdate: false);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance has positioning.
		/// </summary>
		/// 
		/// 	true</c> if this instance has positioning; otherwise, false</c>.
		/// </value>
		protected bool HasPositioning
		{
			get
			{
				return GetState(ControlState.HasPositioning);
			}
			set
			{
				SetState(ControlState.HasPositioning, value);
			}
		}

		/// 
		/// Gets or sets the client size of the form.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Size ClientSize
		{
			get
			{
				return Size;
			}
			set
			{
				Size = value;
			}
		}

		/// Gets or sets the shortcut menu associated with the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ContextMenu"></see> that represents the shortcut menu associated with the control.</returns>
		[Browsable(true)]
		[DefaultValue(null)]
		[SRDescription("ControlContextMenuDescr")]
		[SRCategory("CatBehavior")]
		public override ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
				FireObservableItemPropertyChanged("ContextMenu");
			}
		}

		/// 
		/// Gets or sets the control custom style.
		/// </summary>
		/// </value>
		[DefaultValue("")]
		[SRDescription("ControlCustomStyleDescr")]
		[ProxyBrowsable(true)]
		[SRCategory("CatAppearance")]
		public virtual string CustomStyle
		{
			get
			{
				return GetValue(CustomStyleProperty);
			}
			set
			{
				if (SetValue(CustomStyleProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets a value indicating whether the control has been created.</summary>
		/// true if the control has been created; otherwise, false.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[SRDescription("ControlCreatedDescr")]
		public bool Created => GetState(ControlState.Created);

		/// 
		/// Gets a flag indicating if the object is initializing
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool IsSerializableObjectInitializing
		{
			get
			{
				return !GetState(ControlState.Created);
			}
		}

		/// 
		/// Gets the initial size of the serializable filed storage.
		/// </summary>
		/// The initial size of the serializable filed storage.</value>
		protected override int SerializableFieldStorageInitialSize
		{
			get
			{
				return 12;
			}
		}

		/// Gets or sets the cursor that is displayed when the mouse pointer is over the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> that represents the cursor to display when the mouse pointer is over the control.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlCursorDescr")]
		[ProxyBrowsable(true)]
		public virtual Cursor Cursor
		{
			get
			{
				return GetValue(CursorProperty);
			}
			set
			{
				if (SetValue(CursorProperty, value))
				{
					UpdateParams(AttributeType.Redraw);
				}
			}
		}

		/// 
		/// Gets or sets the border style.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBorderStyleDescr")]
		[ProxyBrowsable(true)]
		public virtual BorderStyle BorderStyle
		{
			get
			{
				return GetValue(BorderStyleProperty, DefaultBorderStyle);
			}
			set
			{
				if (SetValue(BorderStyleProperty, value, DefaultBorderStyle))
				{
					Update();
					FireObservableItemPropertyChanged("BorderStyle");
				}
			}
		}

		/// 
		/// Gets or sets the thickness of the border.
		/// </summary>
		/// Gets or sets a border thickness.</value>
		/// The thinkness struct can be automaticly casted to and from int for backwords compatibility.</remarks>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBorderWidthDescr")]
		[ProxyBrowsable(true)]
		public virtual BorderWidth BorderWidth
		{
			get
			{
				return GetValue(BorderWidthProperty, DefaultBorderWidth);
			}
			set
			{
				if (SetValue(BorderWidthProperty, value, DefaultBorderWidth))
				{
					Update();
					FireObservableItemPropertyChanged("BorderWidth");
				}
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// 
		/// The theme related to the skinable component.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.Editors.ThemeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[WebEditor(typeof(WebThemeEditor), typeof(WebUITypeEditor))]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlThemeDescr")]
		[DefaultValue("Inherit")]
		[ProxyBrowsable(true)]
		public virtual string Theme
		{
			get
			{
				return GetValue(ThemeProperty);
			}
			set
			{
				ICollection collection = null;
				collection = ((VWGContext.Current != null) ? ((ICollection)VWGContext.Current.AvailableThemes) : ((ICollection)Config.GetInstance().AvailableThemes));
				if ((value == "Inherit" || collection.Contains(value)) && SetValue(ThemeProperty, value))
				{
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBackColorDescr")]
		[ProxyBrowsable(true)]
		public virtual Color BackColor
		{
			get
			{
				return GetValue(BackColorProperty, DefaultBackColor);
			}
			set
			{
				if (SetValue(BackColorProperty, value))
				{
					FireObservableItemPropertyChanged("BackColor");
					Update();
					OnBackColorChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has back color.
		/// </summary>
		/// 
		/// 	true</c> if this instance has back color; otherwise, false</c>.
		/// </value>
		internal bool HasBackColor => ContainsValue(BackColorProperty);

		/// 
		/// Gets or sets the border color.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlBorderColorDescr")]
		[ProxyBrowsable(true)]
		public virtual BorderColor BorderColor
		{
			get
			{
				return GetValue(BorderColorProperty, DefaultBorderColor);
			}
			set
			{
				if (SetValue(BorderColorProperty, value, DefaultBorderColor))
				{
					FireObservableItemPropertyChanged("BorderColor");
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the fore color.
		/// </summary>
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("ControlForeColorDescr")]
		[ProxyBrowsable(true)]
		public virtual Color ForeColor
		{
			get
			{
				return GetValue(ForeColorProperty, DefaultForeColor);
			}
			set
			{
				if (SetValue(ForeColorProperty, value))
				{
					Update();
					OnForeColorChanged(new EventArgs());
					FireObservableItemPropertyChanged("ForeColor");
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has fore color.
		/// </summary>
		/// 
		/// 	true</c> if this instance has fore color; otherwise, false</c>.
		/// </value>
		internal bool HasForeColor => ContainsValue(ForeColorProperty);

		/// 
		/// Gets a value indicating whether this instance has right to left.
		/// </summary>
		/// 
		/// 	true</c> if this instance has right to left; otherwise, false</c>.
		/// </value>
		internal bool HasRightToLeft => ContainsValue(RightToLeftProperty);

		/// 
		/// Gets the icon alignment.
		/// </summary>
		/// </returns>
		internal ErrorIconAlignment ErrorIconAlignment
		{
			get
			{
				return GetValue(ErrorIconAlignmentProperty);
			}
			set
			{
				if (SetValue(ErrorIconAlignmentProperty, value))
				{
					UpdateParams(AttributeType.Error);
				}
			}
		}

		/// 
		/// Gets or sets the error icon padding.
		/// </summary>
		/// The error icon padding.</value>
		internal int ErrorIconPadding
		{
			get
			{
				return GetValue(ErrorIconPaddingProperty);
			}
			set
			{
				if (SetValue(ErrorIconPaddingProperty, value))
				{
					UpdateParams(AttributeType.Error);
				}
			}
		}

		/// 
		/// Gets or sets the error icon.
		/// </summary>
		/// The error icon.</value>
		private ResourceHandle ErrorIcon
		{
			get
			{
				return GetValue(ErrorIconProperty);
			}
			set
			{
				SetValue(ErrorIconProperty, value);
			}
		}

		/// 
		/// Gets or sets the error message.
		/// </summary>
		/// The error message.</value>
		private string ErrorMessage
		{
			get
			{
				return GetValue(ErrorMessageProperty);
			}
			set
			{
				SetValue(ErrorMessageProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance is layout suspended non compatible mode.
		/// </summary>
		/// 
		/// 	true</c> if this instance is layout suspended non compatible mode; otherwise, false</c>.
		/// </value>
		internal bool IsNonCompatibleModeLayoutSuspended
		{
			get
			{
				if (mintSuspendLayout <= 0)
				{
					if (!(this is UserControl) && !(this is Form))
					{
						return Parent?.IsNonCompatibleModeLayoutSuspended ?? true;
					}
					return false;
				}
				return true;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is layout suspended.
		/// </summary>
		/// 
		/// 	true</c> if this instance is layout suspended; otherwise, false</c>.
		/// </value>
		protected bool IsLayoutSuspended => mintSuspendLayout > 0;

		/// 
		/// Gets the default width of the border.
		/// </summary>
		/// The default width of the border.</value>
		protected virtual BorderWidth DefaultBorderWidth => Skin.BorderWidth;

		/// 
		/// Gets a value indicating whether this instance is delayed drawing.
		/// </summary>
		/// 
		/// 	true</c> if this instance is delayed drawing; otherwise, false</c>.
		/// </value>
		protected virtual bool IsDelayedDrawing => false;

		/// 
		/// Gets a value indicating whether [auto drawn].
		/// </summary>
		/// 
		///   true</c> if [auto drawn]; otherwise, false</c>.
		/// </value>
		protected virtual bool AutoDrawn => true;

		/// 
		/// Gets a value indicating whether [support child margins].
		/// </summary>
		/// 
		///   true</c> if [support child margins]; otherwise, false</c>.
		/// </value>
		protected virtual bool SupportChildMargins => false;

		/// 
		/// Gets a value indicating whether [force child redraw].
		/// </summary>
		/// true</c> if [force child redraw]; otherwise, false</c>.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool ForceChildRedraw => false;

		/// 
		/// Gets a value indicating whether this instance is redrawing its contained controls.
		/// </summary>
		/// 
		/// 	true</c> if this instance is redrawing; otherwise, false</c>.
		/// </value>
		internal virtual bool Redraws => false;

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected virtual Size DefaultSize => new Size(100, 100);

		/// 
		/// Gets the default color of the back.
		/// </summary>
		/// The default color of the back.</value>
		protected Color DefaultBackColor => Skin.BackColor;

		/// 
		/// Gets the default color of the fore.
		/// </summary>
		/// The default color of the fore.</value>
		protected Color DefaultForeColor => Skin.ForeColor;

		/// 
		/// Gets the default color of the border.
		/// </summary>
		/// The default color of the border.</value>
		protected BorderColor DefaultBorderColor => Skin.BorderColor;

		/// 
		/// Gets the default border style.
		/// </summary>
		/// The default border style.</value>
		protected BorderStyle DefaultBorderStyle => Skin.BorderStyle;

		/// 
		/// Gets the default padding.
		/// </summary>
		/// The default padding.</value>
		protected virtual Padding DefaultPadding => Skin.Padding;

		/// 
		/// Gets the default margin.
		/// </summary>
		/// The default margin.</value>
		protected Padding DefaultMargin => Skin.Margin;

		/// 
		/// Gets the default font.
		/// </summary>
		/// The default font.</value>
		protected Font DefaultControlFont => Skin.Font;

		/// 
		/// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
		/// </summary>
		/// </value>
		/// The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("ControlBindingContextDescr")]
		[Browsable(false)]
		public virtual BindingContext BindingContext
		{
			get
			{
				return BindingContextInternal;
			}
			set
			{
				BindingContextInternal = value;
			}
		}

		/// 
		/// Gets or sets the binding context.
		/// </summary>
		/// The binding context.</value>
		internal BindingContext BindingContextInternal
		{
			get
			{
				BindingContext bindingContext = GetValue(BindingContextProperty, null);
				if (bindingContext == null)
				{
					Control parent = Parent;
					if (parent != null && parent.CanAccessProperties)
					{
						bindingContext = parent.BindingContext;
					}
				}
				return bindingContext;
			}
			set
			{
				if (SetValue(BindingContextProperty, value))
				{
					OnBindingContextChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets the data bindings for the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ControlBindingsCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects for the control.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ParenthesizePropertyName(true)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("ControlBindingsDescr")]
		[SRCategory("CatData")]
		[LimitedTrustBrowsable(false)]
		public ControlBindingsCollection DataBindings
		{
			get
			{
				ControlBindingsCollection controlBindingsCollection = GetValue(DataBindingsProperty);
				if (controlBindingsCollection == null)
				{
					controlBindingsCollection = new ControlBindingsCollection(this);
					SetValue(DataBindingsProperty, controlBindingsCollection);
				}
				return controlBindingsCollection;
			}
		}

		/// Gets or sets the size and location of the control including its nonclient elements, in pixels, relative to the parent control.</summary>
		/// A <see cref="T:System.Drawing.Rectangle"></see> in pixels relative to the parent control that represents the size and location of the control including its nonclient elements.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[SRDescription("ControlBoundsDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatLayout")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle Bounds
		{
			get
			{
				return new Rectangle(mintLeft, mintTop, mintWidth, mintHeight);
			}
			set
			{
				SetBounds(value.X, value.Y, value.Width, value.Height, BoundsSpecified.All);
				UpdateParams(AttributeType.Layout);
			}
		}

		/// 
		/// Gets the skin of the current control.
		/// </summary>
		/// The skin of the current control.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		protected internal Gizmox.WebGUI.Forms.Skins.ControlSkin Skin
		{
			get
			{
				if (mobjSkin == null)
				{
					mobjSkin = (Gizmox.WebGUI.Forms.Skins.ControlSkin)SkinFactory.GetSkin(this);
				}
				return mobjSkin;
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// The theme related to the skinable component.</value>
		string ISkinable.Theme
		{
			get
			{
				if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
				{
					return "Default";
				}
				if (Context != null)
				{
					return Context.CurrentTheme;
				}
				return ConfigHelper.SelectedTheme;
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Parent"></see> property value changes.</summary>
		/// 1</filterpriority>
		[SRDescription("ControlOnParentChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler ParentChanged
		{
			add
			{
				AddHandler(ParentChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ParentChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the control is entered.
		/// </summary>
		public event EventHandler Enter
		{
			add
			{
				AddCriticalHandler(EnterEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(EnterEvent, value);
			}
		}

		/// Occurs when the input focus leaves the control.
		/// Not implemented by design.
		/// </summary>
		public event EventHandler Leave
		{
			add
			{
				AddCriticalHandler(LeaveEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LeaveEvent, value);
			}
		}

		/// 
		/// Occurs when the control is resized.  
		/// </summary>
		public event EventHandler Resize
		{
			add
			{
				AddCriticalHandler(ResizeEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ResizeEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Enabled"></see> property value has changed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ControlOnEnabledChangedDescr")]
		public event EventHandler EnabledChanged
		{
			add
			{
				AddHandler(EnabledChangedEvent, value);
			}
			remove
			{
				RemoveHandler(EnabledChangedEvent, value);
			}
		}

		/// 
		/// Occurs on clicking the button.
		/// </summary>
		public event EventHandler Click
		{
			add
			{
				AddCriticalHandler(ClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ClickEvent, value);
			}
		}

		/// 
		/// Occurs when [controls selected].
		/// </summary>
		public event ControlsEventHandler ControlSelected
		{
			add
			{
				AddCriticalHandler(ControlSelectedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ControlSelectedEvent, value);
			}
		}

		/// 
		/// Occurs when [controls dropped].
		/// </summary>
		public event ControlEventHandler ControlDropped
		{
			add
			{
				AddCriticalHandler(ControlDroppedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ControlDroppedEvent, value);
			}
		}

		/// Occurs when the control is clicked by the mouse.</summary>
		[SRCategory("CatAction")]
		[SRDescription("ControlOnMouseClickDescr")]
		public event MouseEventHandler MouseClick
		{
			add
			{
				AddCriticalHandler(MouseClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(MouseClickEvent, value);
			}
		}

		/// 
		/// Occurs on key down.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		public event KeyEventHandler KeyDown
		{
			add
			{
				AddCriticalHandler(KeyDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(KeyDownEvent, value);
			}
		}

		/// 
		/// Occurs on key press.            
		/// </summary>            
		public event KeyPressEventHandler KeyPress
		{
			add
			{
				AddCriticalHandler(KeyPressEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(KeyPressEvent, value);
			}
		}

		/// 
		/// Occurs on key up.
		/// Implemented by design as KeyPress (Use KeyPress instead).            
		/// </summary>
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		public event KeyEventHandler KeyUp
		{
			add
			{
				AddHandler(KeyUpEvent, value);
			}
			remove
			{
				RemoveHandler(KeyUpEvent, value);
			}
		}

		/// 
		/// Occurs when the control recives focus.
		/// </summary>
		public event EventHandler GotFocus
		{
			add
			{
				AddCriticalHandler(GotFocusEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(GotFocusEvent, value);
			}
		}

		/// 
		/// Occurs when the control loses focus.
		/// </summary>
		public event EventHandler LostFocus
		{
			add
			{
				AddCriticalHandler(LostFocusEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LostFocusEvent, value);
			}
		}

		/// 
		/// Occurs when the control is double clicked.
		/// </summary>
		public event EventHandler DoubleClick
		{
			add
			{
				AddCriticalHandler(DoubleClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DoubleClickEvent, value);
			}
		}

		/// 
		/// Occurs when the Text property value changes.  
		/// </summary>
		public event EventHandler TextChanged
		{
			add
			{
				AddCriticalHandler(TextChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(TextChangedEvent, value);
			}
		}

		/// Occurs when the control is finished validating.</summary>
		/// 1</filterpriority>
		[SRDescription("ControlOnValidatedDescr")]
		[SRCategory("CatFocus")]
		public event EventHandler Validated
		{
			add
			{
				AddCriticalHandler(ValidatedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValidatedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.CausesValidation"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ControlOnCausesValidationChangedDescr")]
		public event EventHandler CausesValidationChanged
		{
			add
			{
				AddHandler(CausesValidationChangedEvent, value);
			}
			remove
			{
				RemoveHandler(CausesValidationChangedEvent, value);
			}
		}

		/// Occurs when the control is validating.</summary>
		/// 1</filterpriority>
		[SRDescription("ControlOnValidatingDescr")]
		[SRCategory("CatFocus")]
		public event CancelEventHandler Validating
		{
			add
			{
				AddCriticalHandler(ValidatingEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ValidatingEvent, value);
			}
		}

		/// 
		/// Occurs when the Text property value changes (Queued).  
		/// </summary>
		public event EventHandler TextChangedQueued
		{
			add
			{
				AddHandler(TextChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(TextChangedQueuedEvent, value);
			}
		}

		/// 
		/// Occurs when the Location property value has changed.
		/// </summary>
		public event EventHandler LocationChanged
		{
			add
			{
				AddCriticalHandler(LocationChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(LocationChangedEvent, value);
			}
		}

		/// 
		/// Occurs when a new control is added to the ControlCollection.
		/// </summary>
		public event ControlEventHandler ControlAdded
		{
			add
			{
				AddHandler(ControlAddedEvent, value);
			}
			remove
			{
				RemoveHandler(ControlAddedEvent, value);
			}
		}

		/// 
		/// Occurs when [edit control editing].
		/// </summary>
		public event EventHandler EditControlEditing
		{
			add
			{
				AddHandler(ControlEditingEvent, value);
			}
			remove
			{
				RemoveHandler(ControlEditingEvent, value);
			}
		}

		/// 
		/// Occurs when a control is removed from the ControlCollection.
		/// </summary>
		public event ControlEventHandler ControlRemoved
		{
			add
			{
				AddHandler(ControlRemovedEvent, value);
			}
			remove
			{
				RemoveHandler(ControlRemovedEvent, value);
			}
		}

		/// 
		/// Occurs when the mouse pointer is over the control and a mouse button is pressed.
		/// Implemented by design as Click (Use Click instead).              
		/// </summary>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		public event MouseEventHandler MouseDown
		{
			add
			{
				AddCriticalHandler(MouseDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(MouseDownEvent, value);
			}
		}

		/// Occurs when the mouse pointer is over the control and a mouse button is released.
		/// Implemented by design as Click (Use Click instead).      
		/// </summary>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		public event MouseEventHandler MouseUp
		{
			add
			{
				AddCriticalHandler(MouseUpEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(MouseUpEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the BindingContext property changes.
		/// </summary>
		public event EventHandler BindingContextChanged
		{
			add
			{
				AddHandler(BindingContextChangedEvent, value);
			}
			remove
			{
				RemoveHandler(BindingContextChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the BackColor property changes.
		/// </summary>
		public event EventHandler BackColorChanged
		{
			add
			{
				AddHandler(BackColorChangedEvent, value);
			}
			remove
			{
				RemoveHandler(BackColorChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the BackgroundImage property changes.
		/// </summary>
		public event EventHandler BackgroundImageChanged
		{
			add
			{
				AddHandler(BackgroundImageChangedEvent, value);
			}
			remove
			{
				RemoveHandler(BackgroundImageChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the BackgroundImageLayout property changes.
		/// </summary>
		public event EventHandler BackgroundImageLayoutChanged
		{
			add
			{
				AddHandler(BackgroundImageLayoutChangedEvent, value);
			}
			remove
			{
				RemoveHandler(BackgroundImageLayoutChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the FontChanged property changes.
		/// </summary>
		public event EventHandler FontChanged
		{
			add
			{
				AddHandler(FontChangedEvent, value);
			}
			remove
			{
				RemoveHandler(FontChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the ForeColorChanged property changes.
		/// </summary>
		public event EventHandler ForeColorChanged
		{
			add
			{
				AddHandler(ForeColorChangedEvent, value);
			}
			remove
			{
				RemoveHandler(ForeColorChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the PaddingChanged property changes.
		/// </summary>
		public event EventHandler PaddingChanged
		{
			add
			{
				AddHandler(PaddingChangedEvent, value);
			}
			remove
			{
				RemoveHandler(PaddingChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
		public event EventHandler CursorChanged
		{
			add
			{
				AddHandler(CursorChangedEvent, value);
			}
			remove
			{
				RemoveHandler(CursorChangedEvent, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.Control.Visible"></see> property value changes.</summary>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("ControlOnVisibleChangedDescr")]
		public event EventHandler VisibleChanged
		{
			add
			{
				AddHandler(VisibleChangedEvent, value);
			}
			remove
			{
				RemoveHandler(VisibleChangedEvent, value);
			}
		}

		/// Occurs when the user requests help for a control.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("ControlOnHelpDescr")]
		public event HelpEventHandler HelpRequested
		{
			add
			{
				AddHandler(HelpRequestedEvent, value);
			}
			remove
			{
				RemoveHandler(HelpRequestedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
		/// </see> property changes.
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRDescription("ControlOnAutoSizeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AutoSizeChanged
		{
			add
			{
				AddHandler(AutoSizeChangedEvent, value);
			}
			remove
			{
				RemoveHandler(AutoSizeChangedEvent, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property changes.</summary>
		[SRDescription("ControlOnSizeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler SizeChanged
		{
			add
			{
				AddHandler(SizeChangedEvent, value);
			}
			remove
			{
				RemoveHandler(SizeChangedEvent, value);
			}
		}

		/// Occurs when an object is dragged into the control's bounds.</summary>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ControlOnDragEnterDescr")]
		[SRCategory("CatDragDrop")]
		public event DragEventHandler DragEnter;

		/// Occurs when the mouse pointer is moved over the control.</summary>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ControlOnMouseMoveDescr")]
		[SRCategory("CatMouse")]
		public event MouseEventHandler MouseMove;

		/// Occurs when the mouse pointer leaves the control.</summary>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatMouse")]
		[SRDescription("ControlOnMouseLeaveDescr")]
		public event MouseEventHandler MouseLeave;

		/// Occurs when the mouse pointer enters the control.</summary>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("ControlOnMouseEnterDescr")]
		[SRCategory("CatMouse")]
		public event MouseEventHandler MouseEnter;

		/// 
		/// Occurs when [observable suspend layout].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event EventHandler ObservableSuspendLayout
		{
			add
			{
				AddHandler(ObservableSuspendLayoutEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableSuspendLayoutEvent, value);
			}
		}

		/// 
		/// Occurs when [observable resume layout].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableResumeLayoutHandler ObservableResumeLayout
		{
			add
			{
				AddHandler(ObservableResumeLayoutEvent, value);
			}
			remove
			{
				RemoveHandler(ObservableResumeLayoutEvent, value);
			}
		}

		/// 
		/// Gets or sets the client click action.
		/// </summary>
		/// 
		/// The client click action.
		/// </value>
		[Category("Client")]
		[Description("Occurs when control is clicked and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientClick
		{
			add
			{
				AddClientHandler("Click", value);
			}
			remove
			{
				RemoveClientHandler("Click", value);
			}
		}

		/// 
		/// Gets or sets the client click action.
		/// </summary>
		/// 
		/// The client click action.
		/// </value>
		[Category("Client")]
		[Description("Occurs when control is clicked and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientDoubleClick
		{
			add
			{
				AddClientHandler("DoubleClick", value);
			}
			remove
			{
				RemoveClientHandler("DoubleClick", value);
			}
		}

		/// 
		/// Gets or sets the client focus action.
		/// </summary>
		/// 
		/// The client focus action.
		/// </value>
		[Category("Client")]
		[Description("Occurs when the control gets focus and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientFocus
		{
			add
			{
				AddClientHandler("GotFocus", value);
			}
			remove
			{
				RemoveClientHandler("GotFocus", value);
			}
		}

		/// 
		/// Gets or sets the client blur action.
		/// </summary>
		/// 
		/// The client blur action.
		/// </value>
		[Category("Client")]
		[Description("Occurs when the control looses focus and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientBlur
		{
			add
			{
				AddClientHandler("LostFocus", value);
			}
			remove
			{
				RemoveClientHandler("LostFocus", value);
			}
		}

		/// 
		/// Occurs when [client key down].
		/// </summary>
		[Category("Client")]
		[Description("Occurs when the control gets key down and client is in client mode.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public event ClientEventHandler ClientKeyDown
		{
			add
			{
				AddClientHandler("KeyDown", value);
			}
			remove
			{
				RemoveClientHandler("KeyDown", value);
			}
		}

		/// 
		/// Static constructor
		/// </summary>
		static Control()
		{
			DataBindingsProperty = SerializableProperty.Register("DataBindings", typeof(ControlBindingsCollection), typeof(Control), new SerializablePropertyMetadata(null));
			BindingContextProperty = SerializableProperty.Register("BindingContext", typeof(BindingContext), typeof(Control), new SerializablePropertyMetadata(null));
			BorderStyleProperty = SerializableProperty.Register("BorderStyle", typeof(BorderStyle), typeof(Control), new SerializablePropertyMetadata());
			BorderColorProperty = SerializableProperty.Register("BorderColor", typeof(BorderColor), typeof(Control), new SerializablePropertyMetadata());
			ErrorMessageProperty = SerializableProperty.Register("ErrorMessage", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			ErrorIconProperty = SerializableProperty.Register("ErrorIcon", typeof(ResourceHandle), typeof(Control), new SerializablePropertyMetadata(null));
			ErrorIconPaddingProperty = SerializableProperty.Register("ErrorIconPadding", typeof(int), typeof(Control), new SerializablePropertyMetadata(1));
			ErrorIconAlignmentProperty = SerializableProperty.Register("ErrorIconAlignment", typeof(ErrorIconAlignment), typeof(Control), new SerializablePropertyMetadata(ErrorIconAlignment.TopRight));
			LayoutInfoProperty = SerializableProperty.Register("LayoutInfo", typeof(TableLayout.LayoutInfo), typeof(Control), new SerializablePropertyMetadata(null));
			ContainerInfoProperty = SerializableProperty.Register("ContainerInfo", typeof(TableLayout.ContainerInfo), typeof(Control), new SerializablePropertyMetadata(null));
			BorderWidthProperty = SerializableProperty.Register("BorderWidth", typeof(BorderWidth), typeof(Control), new SerializablePropertyMetadata());
			CursorProperty = SerializableProperty.Register("Cursor", typeof(Cursor), typeof(Control), new SerializablePropertyMetadata(Cursors.Default));
			CustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			RightToLeftProperty = SerializableProperty.Register("RightToLeft", typeof(RightToLeft), typeof(Control), new SerializablePropertyMetadata(RightToLeft.Inherit));
			AutoSizeModeProperty = SerializableProperty.Register("AutoSizeMode", typeof(AutoSizeMode), typeof(Control), new SerializablePropertyMetadata(AutoSizeMode.GrowOnly));
			TextProperty = SerializableProperty.Register("Text", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			BackgroundImageLayoutProperty = SerializableProperty.Register("BackgroundImageLayout", typeof(ImageLayout), typeof(Control), new SerializablePropertyMetadata(ImageLayout.Tile));
			MarginProperty = SerializableProperty.Register("Margin", typeof(Padding), typeof(Control), new SerializablePropertyMetadata());
			PaddingProperty = SerializableProperty.Register("Padding", typeof(Padding), typeof(Control), new SerializablePropertyMetadata());
			ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(Control), new SerializablePropertyMetadata(Color.Empty));
			BackColorProperty = SerializableProperty.Register("BackColor", typeof(Color), typeof(Control), new SerializablePropertyMetadata(Color.Empty));
			ThemeProperty = SerializableProperty.Register("Theme", typeof(string), typeof(Control), new SerializablePropertyMetadata("Inherit"));
			FontProperty = SerializableProperty.Register("Font", typeof(Font), typeof(Control), new SerializablePropertyMetadata());
			ToolTipProperty = SerializableProperty.Register("ToolTip", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			ExtendedToolTipDescriptorProperty = SerializableProperty.Register("ExtendedToolTipDescriptor", typeof(ToolTipDescriptor), typeof(Control), new SerializablePropertyMetadata());
			TagNameProperty = SerializableProperty.Register("TagName", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			AccessibleNameProperty = SerializableProperty.Register("AccessibleName", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			AccessibleDescriptionProperty = SerializableProperty.Register("AccessibleDescription", typeof(string), typeof(Control), new SerializablePropertyMetadata(string.Empty));
			MaximumSizeProperty = SerializableProperty.Register("MaximumSize", typeof(Size), typeof(Control), new SerializablePropertyMetadata());
			MinimumSizeProperty = SerializableProperty.Register("MinimumSize", typeof(Size), typeof(Control), new SerializablePropertyMetadata());
			KeyFilterProperty = SerializableProperty.Register("KeyFilter", typeof(KeyFilter), typeof(Control), new SerializablePropertyMetadata(KeyFilter.All));
			ScrollTopProperty = SerializableProperty.Register("ScrollTop", typeof(int), typeof(Control), new SerializablePropertyMetadata(0));
			ScrollLeftProperty = SerializableProperty.Register("ScrollLeft", typeof(int), typeof(Control), new SerializablePropertyMetadata(0));
			BackgroundImageProperty = SerializableProperty.Register("BackgroundImage", typeof(ResourceHandle), typeof(Control), new SerializablePropertyMetadata(null));
			RegisteredTimersProperty = SerializableProperty.Register("RegisteredTimers", typeof(Timer[]), typeof(Control), new SerializablePropertyMetadata(null));
			ImeModeProperty = SerializableProperty.Register("ImeMode", typeof(ImeMode), typeof(Control), new SerializablePropertyMetadata(ImeMode.On));
			ForceContentAvailabilityOnClientProperty = SerializableProperty.Register("ForceContentAvailabilityOnClient", typeof(bool), typeof(Control), new SerializablePropertyMetadata(false));
			DraggableProperty = SerializableProperty.Register("Draggable", typeof(DraggableOptions), typeof(Control), new SerializablePropertyMetadata(null));
			ResizableProperty = SerializableProperty.Register("Resizable", typeof(ResizableOptions), typeof(Control), new SerializablePropertyMetadata(null));
			VisualTemplateProperty = SerializableProperty.Register("VisualTemplate", typeof(VisualTemplate), typeof(Control), new SerializablePropertyMetadata(null));
			ParentChanged = SerializableEvent.Register("ParentChanged", typeof(EventHandler), typeof(Control));
			Enter = SerializableEvent.Register("Enter", typeof(EventHandler), typeof(Control));
			Leave = SerializableEvent.Register("Leave", typeof(EventHandler), typeof(Control));
			Resize = SerializableEvent.Register("Resize", typeof(EventHandler), typeof(Control));
			EnabledChanged = SerializableEvent.Register("EnabledChanged", typeof(EventHandler), typeof(Control));
			ClickEvent = SerializableEvent.Register("Click", typeof(EventHandler), typeof(Control));
			ControlSelectedEvent = SerializableEvent.Register("ControlSelected", typeof(ControlsEventHandler), typeof(Control));
			ControlDroppedEvent = SerializableEvent.Register("ControlDropped", typeof(ControlEventHandler), typeof(Control));
			MouseClickEvent = SerializableEvent.Register("MouseClick", typeof(MouseEventHandler), typeof(Control));
			KeyDown = SerializableEvent.Register("KeyDown", typeof(KeyEventHandler), typeof(Control));
			KeyPress = SerializableEvent.Register("KeyPress", typeof(KeyPressEventHandler), typeof(Control));
			KeyUp = SerializableEvent.Register("KeyUp", typeof(KeyEventHandler), typeof(Control));
			GotFocus = SerializableEvent.Register("GotFocus", typeof(EventHandler), typeof(Control));
			LostFocus = SerializableEvent.Register("LostFocus", typeof(EventHandler), typeof(Control));
			DoubleClickEvent = SerializableEvent.Register("DoubleClick", typeof(EventHandler), typeof(Control));
			TextChanged = SerializableEvent.Register("TextChanged", typeof(EventHandler), typeof(Control));
			Validated = SerializableEvent.Register("Validated", typeof(EventHandler), typeof(Control));
			CausesValidationChanged = SerializableEvent.Register("CausesValidationChanged", typeof(EventHandler), typeof(Control));
			Validating = SerializableEvent.Register("Validating", typeof(CancelEventHandler), typeof(Control));
			TextChangedQueued = SerializableEvent.Register("TextChangedQueued", typeof(EventHandler), typeof(Control));
			LocationChanged = SerializableEvent.Register("LocationChanged", typeof(EventHandler), typeof(Control));
			ControlAdded = SerializableEvent.Register("ControlAdded", typeof(ControlEventHandler), typeof(Control));
			ControlEditingEvent = SerializableEvent.Register("EditControlEditingEvent", typeof(EventHandler), typeof(Control));
			ControlRemoved = SerializableEvent.Register("ControlRemoved", typeof(ControlEventHandler), typeof(Control));
			MouseDownEvent = SerializableEvent.Register("MouseDown", typeof(MouseEventHandler), typeof(Control));
			MouseUpEvent = SerializableEvent.Register("MouseUp", typeof(MouseEventHandler), typeof(Control));
			BindingContextChanged = SerializableEvent.Register("BindingContextChanged", typeof(EventHandler), typeof(Control));
			BackColorChanged = SerializableEvent.Register("BackColorChanged", typeof(EventHandler), typeof(Control));
			BackgroundImageChanged = SerializableEvent.Register("BackgroundImageChanged", typeof(EventHandler), typeof(Control));
			BackgroundImageLayoutChanged = SerializableEvent.Register("BackgroundImageLayoutChanged", typeof(EventHandler), typeof(Control));
			FontChanged = SerializableEvent.Register("FontChanged", typeof(EventHandler), typeof(Control));
			ForeColorChanged = SerializableEvent.Register("ForeColorChanged", typeof(EventHandler), typeof(Control));
			PaddingChanged = SerializableEvent.Register("PaddingChanged", typeof(EventHandler), typeof(Control));
			CursorChanged = SerializableEvent.Register("CursorChanged", typeof(EventHandler), typeof(Control));
			VisibleChanged = SerializableEvent.Register("VisibleChanged", typeof(EventHandler), typeof(Control));
			HelpRequested = SerializableEvent.Register("HelpRequested", typeof(HelpEventHandler), typeof(Control));
			AutoSizeChanged = SerializableEvent.Register("AutoSizeChanged", typeof(EventHandler), typeof(Control));
			SizeChanged = SerializableEvent.Register("SizeChanged", typeof(EventHandler), typeof(Control));
			ObservableSuspendLayout = SerializableEvent.Register("ObservableSuspendLayout", typeof(EventHandler), typeof(Control));
			ObservableResumeLayout = SerializableEvent.Register("ObservableResumeLayout", typeof(ObservableResumeLayoutHandler), typeof(Control));
		}

		/// 
		///
		/// </summary>
		public Control()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.UserPaint | ControlStyles.UseTextForAccessibility, blnValue: true);
			SetState(ComponentState.Visible | ComponentState.Enabled | ComponentState.AllowDrag, blnValue: true);
			SetState(ControlState.TabStop | ControlState.HasPositioning | ControlState.CausesValidation, blnValue: true);
			Size defaultSize = DefaultSize;
			mintLayoutHeight = (mintHeight = defaultSize.Height);
			mintLayoutWidth = (mintWidth = defaultSize.Width);
			menmEditMode = EditMode.Off;
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			menmAnchor = (AnchorStyles)objReader.ReadObject();
			menmDock = (DockStyle)objReader.ReadObject();
			menmControlStyle = (ControlStyles)objReader.ReadObject();
			mintHeight = objReader.ReadInt32();
			mintWidth = objReader.ReadInt32();
			mintLeft = objReader.ReadInt32();
			mintTop = objReader.ReadInt32();
			mintLayoutHeight = objReader.ReadInt32();
			mintLayoutWidth = objReader.ReadInt32();
			mintPreferredHeight = objReader.ReadInt32();
			mintPreferredWidth = objReader.ReadInt32();
			mintTabIndex = objReader.ReadInt32();
			mintSuspendLayout = objReader.ReadInt32();
			mintControlState = objReader.ReadInt32();
			mblnSelectedIndicator = objReader.ReadBoolean();
			if (ShouldSerializableObjectSerializeControls)
			{
				object[] array = objReader.ReadArray();
				if (array.Length != 0)
				{
					mobjControls = CreateControlsInstance();
					mobjControls.InnerList.AddRange(array);
				}
			}
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteObject(menmAnchor);
			objWriter.WriteObject(menmDock);
			objWriter.WriteObject(menmControlStyle);
			objWriter.WriteInt32(mintHeight);
			objWriter.WriteInt32(mintWidth);
			objWriter.WriteInt32(mintLeft);
			objWriter.WriteInt32(mintTop);
			objWriter.WriteInt32(mintLayoutHeight);
			objWriter.WriteInt32(mintLayoutWidth);
			objWriter.WriteInt32(mintPreferredHeight);
			objWriter.WriteInt32(mintPreferredWidth);
			objWriter.WriteInt32(mintTabIndex);
			objWriter.WriteInt32(mintSuspendLayout);
			objWriter.WriteInt32(mintControlState);
			objWriter.WriteBoolean(mblnSelectedIndicator);
			if (ShouldSerializableObjectSerializeControls)
			{
				objWriter.WriteArray(mobjControls);
			}
		}

		/// 
		/// Sets the state.
		/// </summary>
		/// <param name="intFlag">The flag to set.</param>
		/// <param name="blnValue">The flag value to set.</param>
		internal void SetState(ControlState enmState, bool blnValue)
		{
			mintControlState = (blnValue ? (mintControlState | (int)enmState) : (mintControlState & (int)(~enmState)));
		}

		/// 
		/// Sets the state and returns a flag if value had changed.
		/// </summary>
		/// <param name="intFlag">The flag to set.</param>
		/// <param name="blnValue">The flag value to set.</param>
		internal bool SetStateWithCheck(ControlState enmState, bool blnValue)
		{
			if (GetState(enmState) != blnValue)
			{
				SetState(enmState, blnValue);
				return true;
			}
			return false;
		}

		/// 
		/// Gets the state.
		/// </summary>
		/// <param name="intFlag">The flag to get.</param>
		/// </returns>
		internal bool GetState(ControlState enmState)
		{
			return ((uint)mintControlState & (uint)enmState) != 0;
		}

		/// 
		/// Shows the contextual toolbar.
		/// </summary>
		public virtual void ShowContextualToolbar()
		{
			Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.ShowContextualToolbar(this);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			RenderComponentAttributes(objContext, objWriter);
			if (TabStop || (Controls.Count > 0 && !IsFocusManagingContainerControl(this)))
			{
				objWriter.WriteAttributeString("TI", TabIndex.ToString());
			}
			if (EnableGroupTabbing)
			{
				objWriter.WriteAttributeString("EGT", "1");
			}
			if (!GetState(ComponentState.Visible))
			{
				objWriter.WriteAttributeString("V", "0");
			}
			RenderEnabledAttribute(objWriter);
			if (Focusable)
			{
				objWriter.WriteAttributeString("F", "1");
			}
			RenderVisualTemplate(objContext, objWriter);
			if (CustomStyle != "")
			{
				objWriter.WriteAttributeString("ES", GetProxyPropertyValue("CustomStyle", CustomStyle));
			}
			if (ShouldRenderExtendedToolTip())
			{
				RenderExtendedToolTip(objWriter, blnForceRender: false);
			}
			else
			{
				string toolTip = ToolTip;
				if (!string.IsNullOrEmpty(toolTip))
				{
					objWriter.WriteAttributeText("TT", toolTip);
				}
			}
			ResourceHandle proxyPropertyValue = GetProxyPropertyValue("BackgroundImage", BackgroundImage);
			if (proxyPropertyValue != null)
			{
				objWriter.WriteAttributeString("BI", proxyPropertyValue.ToString());
			}
			ImageLayout proxyPropertyValue2 = GetProxyPropertyValue("BackgroundImageLayout", BackgroundImageLayout);
			if (ShouldRenderBackgroundImageLayout(proxyPropertyValue2))
			{
				int num = (int)proxyPropertyValue2;
				objWriter.WriteAttributeString("BIL", num.ToString());
			}
			if (ShouldRenderKeyFilter())
			{
				objWriter.WriteAttributeString("KF", Convert.ToInt64(KeyFilter).ToString());
			}
			if (IsDelayedDrawing && !UseWGNamespace)
			{
				objWriter.WriteAttributeString("IDD", "1");
			}
			if (!AutoDrawn)
			{
				objWriter.WriteAttributeString("ADN", "0");
			}
			BorderValue borderValue = new BorderValue();
			borderValue.Width = GetProxyPropertyValue("BorderWidth", BorderWidth);
			borderValue.Color = GetProxyPropertyValue("BorderColor", BorderColor);
			borderValue.Style = GetProxyPropertyValue("BorderStyle", BorderStyle);
			if (ShouldRenderBorder(borderValue))
			{
				objWriter.WriteAttributeString("BR", borderValue.GetValue(objContext));
			}
			if (ShouldRenderErrorMessage())
			{
				objWriter.WriteAttributeText("EM", ErrorMessage);
				objWriter.WriteAttributeString("EIP", ErrorIconPadding.ToString());
				objWriter.WriteAttributeString("EIA", ErrorIconAlignment.ToString());
				ResourceHandle errorIcon = ErrorIcon;
				if (errorIcon != null)
				{
					objWriter.WriteAttributeString("EI", errorIcon.ToString());
				}
			}
			Font proxyPropertyValue3 = GetProxyPropertyValue("Font", Font);
			if (ShouldRenderFont(proxyPropertyValue3))
			{
				objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(proxyPropertyValue3));
			}
			Color proxyPropertyValue4 = GetProxyPropertyValue("BackColor", BackColor);
			if (ShouldRenderBackColor(proxyPropertyValue4))
			{
				RenderBackColorAttribute(objWriter, proxyPropertyValue4);
			}
			Color proxyPropertyValue5 = GetProxyPropertyValue("ForeColor", GetForeColor());
			if (ShouldRenderForeColor(proxyPropertyValue5))
			{
				objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(proxyPropertyValue5));
			}
			Padding proxyPropertyValue6 = GetProxyPropertyValue("Padding", Padding);
			if (ShouldRenderPaddingAttribute(proxyPropertyValue6))
			{
				if (proxyPropertyValue6.IsAll)
				{
					if (proxyPropertyValue6.All != 0)
					{
						objWriter.WriteAttributeString("PA", proxyPropertyValue6.All.ToString());
					}
				}
				else
				{
					if (proxyPropertyValue6.Top != 0)
					{
						objWriter.WriteAttributeString("PT", proxyPropertyValue6.Top.ToString());
					}
					if (proxyPropertyValue6.Right != 0)
					{
						objWriter.WriteAttributeString("PR", proxyPropertyValue6.Right.ToString());
					}
					if (proxyPropertyValue6.Bottom != 0)
					{
						objWriter.WriteAttributeString("PB", proxyPropertyValue6.Bottom.ToString());
					}
					if (proxyPropertyValue6.Left != 0)
					{
						objWriter.WriteAttributeString("PL", proxyPropertyValue6.Left.ToString());
					}
				}
			}
			if ((Parent != null && Parent.SupportChildMargins) || (Parent != null && !Parent.WinFormsCompatibility.IsForbidDockMargin && Dock != DockStyle.None))
			{
				Padding proxyPropertyValue7 = GetProxyPropertyValue("Margin", Margin);
				if (proxyPropertyValue7 != DefaultMargin)
				{
					if (proxyPropertyValue7.IsAll)
					{
						if (proxyPropertyValue7.All != 0)
						{
							objWriter.WriteAttributeString("MA", proxyPropertyValue7.All.ToString());
						}
					}
					else
					{
						objWriter.WriteAttributeString("MT", proxyPropertyValue7.Top.ToString());
						if (proxyPropertyValue7.Right != 0)
						{
							objWriter.WriteAttributeString("MR", proxyPropertyValue7.Right.ToString());
						}
						if (proxyPropertyValue7.Bottom != 0)
						{
							objWriter.WriteAttributeString("MB", proxyPropertyValue7.Bottom.ToString());
						}
						if (proxyPropertyValue7.Left != 0)
						{
							objWriter.WriteAttributeString("ML", proxyPropertyValue7.Left.ToString());
						}
					}
				}
			}
			Cursor proxyPropertyValue8 = GetProxyPropertyValue("Cursor", Cursor);
			if (proxyPropertyValue8 != null)
			{
				proxyPropertyValue8.RenderCursor(objContext, objWriter);
			}
			RenderScollPositionAttributes(objWriter, blnForceRender: false);
			if (this is IButtonControl)
			{
				objWriter.WriteAttributeString("IBC", "1");
			}
			if (!GetProxyPropertyValue("SupportsKeyNavigation", SupportsKeyNavigation))
			{
				objWriter.WriteAttributeString("SKN", "0");
			}
			RenderRightToLeftAttribute(objWriter, blnForceRender: false);
			RenderDraggableAttribute(objContext, objWriter, blnForceRender: false);
			RenderDroppableAttribute(objContext, objWriter, blnForceRender: false);
			RenderResizableAttribute(objContext, objWriter, blnForceRender: false);
			RenderSelectableAttribute(objContext, objWriter, blnForceRender: false);
			if (this is IButtonControl)
			{
				objWriter.WriteAttributeString("ACL", "1");
			}
			RenderSelectedIndicatorAttribute(objContext, objWriter, blnForceRender: false);
			RenderAccessibleNameAttribute(objWriter, blnForcRender: false);
			RenderEditModeAttirbute(objWriter, blnForceRender: false);
			RenderThemeAttribute(objContext, objWriter, blnForceRender: false);
			RenderSkipMultiTheme(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the visual template.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected virtual void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter)
		{
			RenderVisualTemplate(objContext, objWriter, GetProxyPropertyValue("VisualTemplate", VisualTemplate));
		}

		/// 
		/// Renders the visual template.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objVisualTemplate">The obj visual template.</param>
		protected void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter, VisualTemplate objVisualTemplate)
		{
			objVisualTemplate?.Render(objContext, objWriter);
		}

		/// 
		/// Renders the edit mode attirbute.
		/// </summary>
		/// <param name="objWriter">The object writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderEditModeAttirbute(IAttributeWriter objWriter, bool blnForceRender)
		{
			EditMode editControlMode = EditControlMode;
			if (editControlMode == EditMode.On || blnForceRender)
			{
				objWriter.WriteAttributeString("CEM", (editControlMode == EditMode.On) ? "1" : "0");
			}
		}

		/// 
		/// Renders the enabled attribute.
		/// </summary>
		/// <param name="objWriter">The object writer.</param>
		protected virtual void RenderEnabledAttribute(IAttributeWriter objWriter)
		{
			if (!GetProxyPropertyValue("Enabled", EnabledInternal))
			{
				objWriter.WriteAttributeString("En", "0");
			}
		}

		/// 
		/// Renders the scoll position attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSkipMultiTheme(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (blnForceRender || SkipMultiTheme != ControlSkipMultiTheme.None)
			{
				objWriter.WriteAttributeString("SMT", SkipMultiTheme.ToString());
			}
		}

		/// 
		/// Renders the scoll position attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderScollPositionAttributes(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (ScrollTop != 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("SCT", ScrollTop.ToString());
			}
			if (ScrollLeft != 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("SCL", ScrollLeft.ToString());
			}
		}

		/// 
		/// Determines whether to render extended tooltip. 
		/// Renders if at least one value is not empty, and both template name and tooltip key exist.
		/// </summary>
		/// </returns>
		private bool ShouldRenderExtendedToolTip()
		{
			ToolTipDescriptor extendedToolTipDescriptor = ExtendedToolTipDescriptor;
			if (extendedToolTipDescriptor != null)
			{
				string toolTipTemplateName = extendedToolTipDescriptor.ToolTipTemplateName;
				string toolTipKey = extendedToolTipDescriptor.ToolTipKey;
				if (!string.IsNullOrEmpty(toolTipTemplateName) && !string.IsNullOrEmpty(toolTipKey))
				{
					foreach (KeyValuePair<string, string> extendedProperty in extendedToolTipDescriptor.ExtendedProperties)
					{
						if (!string.IsNullOrEmpty(extendedProperty.Value))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		/// 
		/// Renders the extended tooltip.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderExtendedToolTip(IAttributeWriter objWriter, bool blnForceRender)
		{
			string strText = string.Empty;
			string text = string.Empty;
			string text2 = string.Empty;
			ToolTipDescriptor extendedToolTipDescriptor = ExtendedToolTipDescriptor;
			if (extendedToolTipDescriptor != null)
			{
				strText = extendedToolTipDescriptor.SerializedProperties;
				text = extendedToolTipDescriptor.ToolTipTemplateName;
				text2 = extendedToolTipDescriptor.ToolTipKey;
			}
			if ((!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2)) || blnForceRender)
			{
				objWriter.WriteAttributeText("ETT", strText);
				objWriter.WriteAttributeString("ETTN", text);
				objWriter.WriteAttributeString("ETTK", text2);
			}
		}

		/// 
		/// Renders the right to left attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">The BLN force render.</param>
		private void RenderRightToLeftAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			int rightToLeft = (int)RightToLeft;
			if (blnForceRender || rightToLeft != Convert.ToInt32(Context.RightToLeft))
			{
				objWriter.WriteAttributeString("RTL", rightToLeft.ToString());
			}
		}

		/// 
		/// Renders the draggable attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderDraggableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			DraggableOptions proxyPropertyValue = GetProxyPropertyValue("Draggable", DraggableInternal);
			if ((proxyPropertyValue?.IsDraggable ?? false) || blnForceRender)
			{
				objWriter.WriteAttributeString("DA", (proxyPropertyValue != null && proxyPropertyValue.IsDraggable) ? "1" : "0");
				if (proxyPropertyValue != null && proxyPropertyValue.IsDraggable && !proxyPropertyValue.IsDefault())
				{
					objWriter.WriteAttributeString("DAP", proxyPropertyValue.ToRenderString());
				}
			}
		}

		/// 
		/// Renders the droppable attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderDroppableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			bool flag = ControlDroppedHandler != null;
			if (flag || blnForceRender)
			{
				objWriter.WriteAttributeString("DPA", flag ? "1" : "0");
			}
		}

		/// 
		/// Renders the selectable attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderSelectableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			bool flag = ControlSelectedHandler != null;
			if (flag || blnForceRender)
			{
				objWriter.WriteAttributeString("SA", flag ? "1" : "0");
			}
		}

		/// 
		/// Renders the resizable attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderResizableAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			ResizableOptions proxyPropertyValue = GetProxyPropertyValue("Resizable", ResizableInternal);
			string text = string.Empty;
			if (ResizableAllowedDirections != null)
			{
				text = string.Join(",", ResizableAllowedDirections);
			}
			if ((proxyPropertyValue?.IsResizable ?? false) || blnForceRender)
			{
				objWriter.WriteAttributeString("RA", (proxyPropertyValue != null && proxyPropertyValue.IsResizable) ? "1" : "0");
				if (text == null)
				{
					text = string.Empty;
				}
				if (proxyPropertyValue != null && proxyPropertyValue.IsResizable && !proxyPropertyValue.IsDefault())
				{
					objWriter.WriteAttributeString("REP", text + "|" + proxyPropertyValue.ToRenderString());
				}
				else if (!string.IsNullOrEmpty(text))
				{
					objWriter.WriteAttributeString("REP", text + "|");
				}
				else if (blnForceRender)
				{
					objWriter.WriteAttributeString("REP", "");
				}
			}
		}

		/// 
		/// Renders the back color attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objBackColor">Color of the obj back.</param>
		protected virtual void RenderBackColorAttribute(IAttributeWriter objWriter, Color objBackColor)
		{
			objWriter.WriteAttributeString("BG", CommonUtils.GetHtmlColor(objBackColor));
		}

		/// 
		/// Renders the selected indicator attribute.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected void RenderSelectedIndicatorAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			bool proxyPropertyValue = GetProxyPropertyValue("SelectedIndicator", SelectedIndicator);
			if (proxyPropertyValue || blnForceRender)
			{
				objWriter.WriteAttributeString("SIR", proxyPropertyValue ? "1" : "0");
			}
		}

		/// 
		/// Renders the Accessibility Name attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">The BLN force render.</param>
		private void RenderAccessibleNameAttribute(IAttributeWriter objWriter, bool blnForcRender)
		{
			if (Context.Config.AccessibilityMode)
			{
				string text = AccessibleName;
				if (string.IsNullOrEmpty(text))
				{
					text = AccessibleDescription;
				}
				if (string.IsNullOrEmpty(text))
				{
					text = Name;
				}
				if (!string.IsNullOrEmpty(text) || blnForcRender)
				{
					objWriter.WriteAttributeString("ACN", text);
				}
			}
		}

		/// 
		/// Renders the color of the fore.
		/// </summary>
		protected virtual Color GetForeColor()
		{
			return ForeColor;
		}

		/// 
		/// Indicates should render background image layout.
		/// </summary>
		/// </returns>
		private bool ShouldRenderBackgroundImageLayout(ImageLayout objImageLayout)
		{
			return true;
		}

		/// 
		/// Indicates if to render error message.
		/// </summary>
		/// </returns>
		private bool ShouldRenderErrorMessage()
		{
			return !string.IsNullOrEmpty(ErrorMessage);
		}

		/// 
		/// Indicates if to render key filter.
		/// </summary>
		/// </returns>
		private bool ShouldRenderKeyFilter()
		{
			return KeyFilter != KeyFilter.All;
		}

		/// 
		/// Indicates if to render padding attribute
		/// </summary>
		/// </returns>
		protected virtual bool ShouldRenderPaddingAttribute(Padding objPadding)
		{
			return DefaultPadding != objPadding;
		}

		/// 
		/// Indicates if to render padding.
		/// </summary>
		/// </returns>
		private bool ShouldRenderPadding()
		{
			return DefaultPadding != Padding;
		}

		/// 
		/// Shoulds the color of the render fore.
		/// </summary>
		/// <param name="objForeColor">Color of the obj fore.</param>
		/// </returns>
		private bool ShouldRenderForeColor(Color objForeColor)
		{
			return objForeColor != DefaultForeColor;
		}

		/// 
		/// Indicates if to render back color.
		/// </summary>
		/// </returns>
		private bool ShouldRenderBackColor(Color objBackColor)
		{
			return objBackColor != DefaultBackColor;
		}

		/// 
		/// Shoulds the render registered timers.
		/// </summary>
		/// </returns>
		private bool ShouldRenderRegisteredTimers()
		{
			return RegisteredTimers != null;
		}

		/// 
		/// Indicates if to render font.
		/// </summary>
		/// </returns>
		private bool ShouldRenderFont(Font objFont)
		{
			return objFont != DefaultControlFont;
		}

		/// 
		/// Check if conrtol should be rendered.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		protected virtual bool ShouldRenderControl(Control objControl)
		{
			return true;
		}

		/// 
		/// Renders the component.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		void IRenderableComponent.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal virtual void PreRenderControl(IContext objContext, long lngRequestID)
		{
			((IContextParams)Context).InvokeComponentMessage(this, new ComponentMessageEventArgs("PreRenderControl"));
			PreRenderControls(objContext, IsDirty(lngRequestID) ? 0 : lngRequestID);
		}

		/// 
		/// Posts the render control.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal virtual void PostRenderControl(IContext objContext, long lngRequestID)
		{
			ResetParams();
			PostRenderControls(objContext, IsDirty(lngRequestID) ? 0 : lngRequestID);
		}

		/// 
		/// Pre-renders controls.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected virtual void PreRenderControls(IContext objContext, long lngRequestID)
		{
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				proxyComponent.PreRenderComponents(objContext, lngRequestID);
				return;
			}
			int count = Controls.Count;
			for (int i = 0; i < count; i++)
			{
				Controls[i]?.PreRenderControl(objContext, lngRequestID);
			}
		}

		/// 
		/// Posts the render controls.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected virtual void PostRenderControls(IContext objContext, long lngRequestID)
		{
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				proxyComponent.PostRenderComponents(objContext, lngRequestID);
				return;
			}
			int count = Controls.Count;
			for (int i = 0; i < count; i++)
			{
				Controls[i]?.PostRenderControl(objContext, lngRequestID);
			}
		}

		/// 
		/// Checks if the current control needs rendering and 
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected internal virtual void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (IsDirty(lngRequestID))
			{
				RegisterSelf();
				if (UseWGNamespace)
				{
					objWriter.WriteStartElement(WGConst.Prefix, MetadataTag, WGConst.Namespace);
				}
				else
				{
					objWriter.WriteStartElement(WGConst.ControlsPrefix, MetadataTag, WGConst.ControlsNamespace);
				}
				RenderAttributes(objContext, (IAttributeWriter)objWriter);
				RenderPositioning(objContext, (IAttributeWriter)objWriter, blnForceRender: false);
				if (ShouldRenderContentInternal())
				{
					Render(objContext, objWriter, 0L);
				}
				RenderComponentClientEvents(objContext, objWriter, lngRequestID);
				objWriter.WriteEndElement();
			}
			else if (IsDirtyAttributes(lngRequestID))
			{
				objWriter.WriteStartElement(WGConst.Prefix, "PRM", WGConst.Namespace);
				RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID);
				if (ShouldRenderContentInternal())
				{
					RenderControls(objContext, objWriter, lngRequestID, blnFullRedraw: true);
				}
				objWriter.WriteEndElement();
			}
			else if (ShouldRenderContentInternal())
			{
				RenderControls(objContext, objWriter, lngRequestID, blnFullRedraw: false);
			}
		}

		/// 
		/// Shoulds the content of the control.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal bool ShouldRenderContentInternal()
		{
			if (ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient)
			{
				return true;
			}
			return ShouldRenderContent();
		}

		/// 
		/// Shoulds the content of the control.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual bool ShouldRenderContent()
		{
			if (!GetState(ComponentState.Visible))
			{
				return false;
			}
			return ParentInternal?.ShouldRenderContentInternal() ?? true;
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnFullRedraw"></param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
		{
			RenderControls(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected virtual void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			ProxyComponent proxyComponent = ProxyComponent;
			if (proxyComponent != null)
			{
				proxyComponent.RenderComponents(objContext, objWriter, lngRequestID);
				return;
			}
			bool reverseControls = ReverseControls;
			int count = Controls.Count;
			for (int i = ((!reverseControls) ? (count - 1) : 0); reverseControls ? (i < count) : (i > -1); i += (reverseControls ? 1 : (-1)))
			{
				Control control = Controls[i];
				if (control != null && ShouldRenderControl(control))
				{
					control.RenderControl(objContext, objWriter, lngRequestID);
				}
			}
		}

		/// 
		/// An abstract control method rendering 
		/// </summary>
		protected virtual void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderControls(objContext, objWriter, lngRequestID, blnFullRedraw: true);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			if (ForceChildRedraw)
			{
				objWriter.WriteAttributeString("FCR", "1");
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeString("KF", Convert.ToInt64(KeyFilter).ToString());
				RenderScollPositionAttributes(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderRightToLeftAttribute(objWriter, blnForceRender: true);
				objWriter.WriteAttributeString("V", Visible ? "1" : "0");
				RenderSelectedIndicatorAttribute(objContext, objWriter, blnForceRender: true);
				RenderVisualTemplate(objContext, objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Enabled))
			{
				objWriter.WriteAttributeString("En", EnabledInternal ? "1" : "0");
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderPositioning(objContext, objWriter, blnForceRender: true);
				RenderThemeAttribute(objContext, objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
			{
				objWriter.WriteAttributeText("TT", ToolTip);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.ExtendedToolTip))
			{
				RenderExtendedToolTip(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderSkipMultiTheme(objWriter, blnForceRender: true);
			}
			RenderComponentUpdateAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Error))
			{
				string errorMessage = ErrorMessage;
				if (!string.IsNullOrEmpty(errorMessage))
				{
					objWriter.WriteAttributeText("EM", errorMessage);
					objWriter.WriteAttributeString("EIP", ErrorIconPadding.ToString());
					objWriter.WriteAttributeString("EIA", ErrorIconAlignment.ToString());
				}
				else
				{
					objWriter.WriteAttributeString("EM", string.Empty);
				}
				ResourceHandle errorIcon = ErrorIcon;
				if (errorIcon != null)
				{
					objWriter.WriteAttributeString("EI", errorIcon.ToString());
				}
				else
				{
					objWriter.WriteAttributeString("EI", string.Empty);
				}
			}
			Cursor cursor = Cursor;
			if (IsDirtyAttributes(lngRequestID, AttributeType.Redraw) && cursor != null)
			{
				cursor.RenderCursor(objContext, objWriter);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Drag))
			{
				RenderDraggableAttribute(objContext, objWriter, blnForceRender: true);
				RenderDroppableAttribute(objContext, objWriter, blnForceRender: true);
				RenderResizableAttribute(objContext, objWriter, blnForceRender: true);
				RenderSelectableAttribute(objContext, objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Accessibility))
			{
				RenderAccessibleNameAttribute(objWriter, blnForcRender: true);
			}
		}

		/// 
		/// Determines whether [is critical event] [the specified obj event key].
		/// </summary>
		/// <param name="objEventKey">The event key.</param>
		/// 
		/// 	true</c> if [is critical event] [the specified obj event key]; otherwise, false</c>.
		/// </returns>
		protected internal bool IsCriticalEvent(SerializableEvent objEventKey)
		{
			if (objEventKey != null)
			{
				return HasHandler(objEventKey);
			}
			return false;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			IContainerControl containerControl = null;
			IApplicationContext applicationContext = null;
			ISessionRegistry sessionRegistry = null;
			switch (objEvent.Type)
			{
			case "Click":
				OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				break;
			case "DoubleClick":
				OnClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				OnDoubleClick(new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 2, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0));
				break;
			case "KeyDown":
				FireKeyDown(objEvent);
				break;
			case "GotFocus":
				containerControl = GetContainerControlInternal();
				if (containerControl != null && containerControl.ActiveControl != this)
				{
					containerControl.ActivateControl(this);
					OnGotFocus(EventArgs.Empty);
				}
				if (Context is IApplicationContext applicationContext2)
				{
					applicationContext2.SetFocused(this, blnInvokeFocusCommand: false);
				}
				break;
			case "LostFocus":
				containerControl = GetContainerControlInternal();
				if (containerControl != null && containerControl.ActiveControl != this)
				{
					containerControl.ActivateControl(this);
				}
				OnLostFocus(new EventArgs());
				if (Context is IApplicationContext applicationContext3 && applicationContext3.GetFocused() == this)
				{
					applicationContext3.SetFocused(null, blnInvokeFocusCommand: false);
				}
				break;
			case "Resize":
			{
				double value = Convert.ToDouble(objEvent["Width"], CultureInfo.InvariantCulture);
				double value2 = Convert.ToDouble(objEvent["Height"], CultureInfo.InvariantCulture);
				if (SetBounds(0, 0, Convert.ToInt32(value), Convert.ToInt32(value2), BoundsSpecified.Size, blnIsClientSource: true))
				{
					OnResizeInternal(new LayoutEventArgs(blnIsClientSource: true, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
				}
				break;
			}
			case "Move":
			{
				double dblValue2 = -1.0;
				double dblValue3 = -1.0;
				if (CommonUtils.TryParse(objEvent["Left"], out dblValue2) && CommonUtils.TryParse(objEvent["Top"], out dblValue3) && SetBounds(Convert.ToInt32(dblValue2), Convert.ToInt32(dblValue3), 0, 0, BoundsSpecified.Location, blnIsClientSource: true))
				{
					OnLocationChangedInternal(new LayoutEventArgs(blnIsClientSource: true, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
				}
				break;
			}
			case "ScrollPositionChanged":
			{
				double dblValue = 0.0;
				if (!string.IsNullOrEmpty(objEvent["SCT"]))
				{
					int num = 0;
					CommonUtils.TryParse(objEvent["SCT"], out dblValue);
					num = Convert.ToInt32(dblValue);
					SetScrollTop(num);
				}
				if (!string.IsNullOrEmpty(objEvent["SCT"]))
				{
					int num2 = 0;
					CommonUtils.TryParse(objEvent["SCL"], out dblValue);
					num2 = Convert.ToInt32(dblValue);
					SetScrollLeft(num2);
				}
				break;
			}
			case "ControlSelected":
			{
				if (!(Context is ISessionRegistry sessionRegistry3))
				{
					break;
				}
				string text2 = objEvent["SE"];
				if (string.IsNullOrEmpty(text2))
				{
					break;
				}
				string[] array = text2.Split(',');
				if (array.Length == 0)
				{
					break;
				}
				Control[] array2 = new Control[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					if (sessionRegistry3.GetRegisteredComponent(array[i]) is Control control)
					{
						array2[i] = control;
					}
				}
				OnControlsSelected(new ControlsEventArgs(array2));
				break;
			}
			case "ControlDropped":
				if (Context is ISessionRegistry sessionRegistry2)
				{
					string text = objEvent["DPC"];
					if (!string.IsNullOrEmpty(text) && sessionRegistry2.GetRegisteredComponent(text) is Control objControl)
					{
						OnControlDropped(new ControlEventArgs(objControl));
					}
				}
				break;
			case "ContextualToolbarEditor":
				Gizmox.WebGUI.Forms.ContextualToolbar.ContextualToolbar.FireEvent(this, objEvent);
				break;
			case "CEM":
				if (objEvent["Attr.CancelEditingMode"] == "1")
				{
					SetEditControlMode(EditMode.Off, blnFromClient: true);
				}
				else
				{
					ProcessEditModeValue(objEvent);
				}
				break;
			case "VisualTemplate":
				if (VisualTemplate != null)
				{
					VisualTemplate.FireEvent(this, objEvent);
				}
				break;
			}
		}

		/// 
		/// Sets the edit control mode.
		/// </summary>
		/// <param name="enmEditMode">The enm edit mode.</param>
		/// <param name="blnFromClient">if set to true</c> [BLN from client].</param>
		private void SetEditControlMode(EditMode enmEditMode, bool blnFromClient)
		{
			if (menmEditMode != enmEditMode)
			{
				menmEditMode = enmEditMode;
				if (!blnFromClient)
				{
					Update();
				}
			}
		}

		/// 
		/// Processes the edit mode value.
		/// </summary>
		/// <param name="objEvent">The object event.</param>
		private void ProcessEditModeValue(IEvent objEvent)
		{
			EditValueEditingEventArgs e = new EditValueEditingEventArgs(objEvent);
			OnEditValueEditing(e);
			if (!e.Cancel)
			{
				CommitValueEditing(e.FormattedValue);
			}
			EditControlMode = (e.ExitEditMode ? EditMode.Off : EditMode.On);
		}

		/// 
		/// Commits the value editing.
		/// </summary>
		/// <param name="objFormattedValue">The object formatted value.</param>
		protected virtual void CommitValueEditing(object objFormattedValue)
		{
		}

		/// 
		/// Raises the <see cref="E:EditValueEditing" /> event.
		/// </summary>
		/// <param name="objEditValueEditingEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.EditValueEditingEventArgs" /> instance containing the event data.</param>
		protected internal virtual void OnEditValueEditing(EditValueEditingEventArgs objEditValueEditingEventArgs)
		{
			if (GetHandler(ControlEditingEvent) is EventHandler eventHandler)
			{
				eventHandler(this, objEditValueEditingEventArgs);
			}
		}

		/// 
		/// Fires the control added event.
		/// </summary>
		/// <param name="objControl">Added control.</param>
		internal void FireControlAdded(Control objControl)
		{
			if (ControlAddedHandler != null)
			{
				ControlAddedHandler(this, new ControlEventArgs(objControl));
			}
		}

		/// 
		/// Fires the control removed event.
		/// </summary>
		/// <param name="objControl">Removed control.</param>
		internal void FireControlRemoved(Control objControl)
		{
			if (ControlRemovedHandler != null)
			{
				ControlRemovedHandler(this, new ControlEventArgs(objControl));
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
		/// event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnClick(EventArgs objEventArgs)
		{
			MouseEventArgs e = objEventArgs as MouseEventArgs;
			if (e == null)
			{
				e = new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 1);
			}
			OnMouseDown(e);
			if (e.Button == MouseButtons.Left || ShouldRaiseClickOnRightMouseDown)
			{
				OnMouseClick(e);
			}
			OnMouseUp(e);
		}

		/// 
		/// Raises the <see cref="E:ControlAdded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnControlAdded(ControlEventArgs e)
		{
			if (!base.DesignMode && e.Control != null)
			{
				e.Control.ApplyPreReleaseDockFillCompatibility();
			}
			ControlAddedHandler?.Invoke(this, e);
		}

		/// 
		/// Applies the pre release dock fill compatibility.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void ApplyPreReleaseDockFillCompatibility()
		{
			if (IsFillDocked(Dock) && Context != null && Context.Config.IsFeatureEnabled("PreReleaseDockFillCompatibility", false))
			{
				BringToFront();
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.ParentChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentChanged(EventArgs e)
		{
			ParentChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CursorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCursorChanged(EventArgs e)
		{
			CursorChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ControlsSelected" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlsEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnControlsSelected(ControlsEventArgs e)
		{
			ControlSelectedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ControlDropped" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnControlDropped(ControlEventArgs e)
		{
			ControlDroppedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Leave"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLeave(EventArgs e)
		{
			LeaveHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Enter"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnEnter(EventArgs e)
		{
			EnterHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		protected virtual void OnKeyDown(KeyEventArgs e)
		{
			KeyDownHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnKeyPress(KeyPressEventArgs e)
		{
			KeyPressHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.
		/// Implemented by design as KeyPress (Use KeyPress instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as KeyPress(Use KeyPress instead).")]
		protected virtual void OnKeyUp(KeyEventArgs e)
		{
			KeyUpHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseClick"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseClick(MouseEventArgs e)
		{
			((EventHandler)GetHandler(ClickEvent))?.Invoke(this, e);
			((MouseEventHandler)GetHandler(MouseClickEvent))?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
		/// Implemented by design as Click (Use Click instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>            
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected virtual void OnMouseUp(MouseEventArgs e)
		{
			MouseUpHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDoubleClick"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnMouseDoubleClick(MouseEventArgs e)
		{
			DoubleClickHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.
		/// Implemented by design as Click (Use Click instead).
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected virtual void OnMouseDown(MouseEventArgs e)
		{
			MouseDownHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:ControlRemoved" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnControlRemoved(ControlEventArgs e)
		{
			ControlRemovedHandler?.Invoke(this, e);
		}

		/// 
		/// Shoulds the perform container validation.
		/// </summary>
		/// </returns>
		internal virtual bool ShouldPerformContainerValidation()
		{
			return GetStyle(ControlStyles.ContainerControl);
		}

		/// 
		/// Performs the container validation.
		/// </summary>
		/// <param name="validationConstraints">The validation constraints.</param>
		/// </returns>
		internal bool PerformContainerValidation(ValidationConstraints validationConstraints)
		{
			bool result = false;
			foreach (Control control in Controls)
			{
				if ((validationConstraints & ValidationConstraints.ImmediateChildren) != ValidationConstraints.ImmediateChildren && control.ShouldPerformContainerValidation() && control.PerformContainerValidation(validationConstraints))
				{
					result = true;
				}
				if (((validationConstraints & ValidationConstraints.Selectable) != ValidationConstraints.Selectable || control.GetStyle(ControlStyles.Selectable)) && ((validationConstraints & ValidationConstraints.Enabled) != ValidationConstraints.Enabled || control.Enabled) && ((validationConstraints & ValidationConstraints.Visible) != ValidationConstraints.Visible || control.Visible) && ((validationConstraints & ValidationConstraints.TabStop) != ValidationConstraints.TabStop || control.TabStop) && control.PerformControlValidation(bulkValidation: true))
				{
					result = true;
				}
			}
			return result;
		}

		/// 
		/// Performs the control validation.
		/// </summary>
		/// <param name="bulkValidation">if set to true</c> [bulk validation].</param>
		/// </returns>
		internal bool PerformControlValidation(bool bulkValidation)
		{
			if (CausesValidation)
			{
				if (NotifyValidating())
				{
					return true;
				}
				if (bulkValidation)
				{
					NotifyValidated();
				}
				else
				{
					try
					{
						NotifyValidated();
					}
					catch (Exception t)
					{
						Application.OnThreadException(t);
					}
				}
			}
			return false;
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		internal void OnLocationChangedInternal(LayoutEventArgs objEventArgs)
		{
			if (objEventArgs.ShouldUpdateParent)
			{
				InvalidateParentLayout(objEventArgs);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LocationChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLocationChanged(LayoutEventArgs e)
		{
			LocationChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Fires the key down event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		internal void FireKeyDown(IEvent objEvent)
		{
			Keys keys = CreateKeys(objEvent);
			OnKeyDown(new KeyEventArgs(keys));
			OnKeyPress(new KeyPressEventArgs((char)keys));
			OnKeyUp(new KeyEventArgs(keys));
			if (HelpRequestedHandler != null && keys == Keys.F1)
			{
				OnHelpRequested(new HelpEventArgs(new Point(0, 0)));
			}
		}

		/// 
		/// Creates keys from event.
		/// </summary>
		internal static Keys CreateKeys(IEvent objEvent)
		{
			Keys keys = objEvent.KeyCode;
			if (objEvent.AltKey)
			{
				keys |= Keys.Alt;
			}
			if (objEvent.ControlKey)
			{
				keys |= Keys.Control;
			}
			if (objEvent.ShiftKey)
			{
				keys |= Keys.Shift;
			}
			return keys;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("Click"))
			{
				criticalClientEventsData.Set("CL");
			}
			if (HasClientHandler("DoubleClick"))
			{
				criticalClientEventsData.Set("DCL");
			}
			if (HasClientHandler("KeyDown"))
			{
				criticalClientEventsData.Set("KD");
			}
			if (HasClientHandler("GotFocus"))
			{
				criticalClientEventsData.Set("GF");
			}
			if (HasClientHandler("LostFocus"))
			{
				criticalClientEventsData.Set("LF");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (HasHandler(ClickEvent) || HasHandler(MouseClickEvent) || HasHandler(MouseDownEvent) || HasHandler(MouseUpEvent))
			{
				criticalEventsData.Set("CL");
				if (ShouldRaiseClickOnRightMouseDown)
				{
					criticalEventsData.Set("RC");
				}
			}
			if (DoubleClickHandler != null)
			{
				criticalEventsData.Set("DCL");
			}
			if (KeyDownHandler != null)
			{
				criticalEventsData.Set("KD");
			}
			if (KeyUpHandler != null)
			{
				criticalEventsData.Set("KD");
			}
			if (KeyPressHandler != null)
			{
				criticalEventsData.Set("KD");
			}
			if (SupportsFocusEvents)
			{
				if (GotFocusHandler != null)
				{
					criticalEventsData.Set("GF");
				}
				if (LostFocusHandler != null)
				{
					criticalEventsData.Set("LF");
				}
			}
			if (TextChangedHandler != null || ValidatingHandler != null || ValidatedHandler != null)
			{
				criticalEventsData.Set("VC");
			}
			if (ResizeHandler != null || (ParentInternal != null && ParentInternal.AutoSize))
			{
				criticalEventsData.Set("SC");
			}
			if (LocationChangedHandler != null)
			{
				criticalEventsData.Set("LC");
			}
			if (EnterHandler != null)
			{
				criticalEventsData.Set("EN");
			}
			if (LeaveHandler != null)
			{
				criticalEventsData.Set("LE");
			}
			criticalEventsData.Set(GetProxyPropertyValue("GetCriticalEventsData", criticalEventsData));
			return criticalEventsData;
		}

		/// 
		/// Gets the auto validate for control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		internal static AutoValidate GetAutoValidateForControl(Control objControl)
		{
			return objControl.ParentContainerControl?.AutoValidate ?? AutoValidate.EnablePreventFocusChange;
		}

		protected internal void RenderMinMaxSizeAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			if (MinimumSize.Width != DefaultMinimumSize.Width)
			{
				objWriter.WriteAttributeString("MNW", MinimumSize.Width.ToString());
			}
			if (MinimumSize.Height != DefaultMinimumSize.Height)
			{
				objWriter.WriteAttributeString("MNH", MinimumSize.Height.ToString());
			}
			if (MaximumSize.Width != DefaultMaximumSize.Width)
			{
				objWriter.WriteAttributeString("MXW", MaximumSize.Width.ToString());
			}
			if (MaximumSize.Height != DefaultMaximumSize.Height)
			{
				objWriter.WriteAttributeString("MXH", MaximumSize.Height.ToString());
			}
		}

		/// 
		/// Renders the theme.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected virtual void RenderThemeAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (VWGContext.Current.SupportsMultipleThemes)
			{
				string proxyPropertyValue = GetProxyPropertyValue("Theme", Theme);
				if (proxyPropertyValue != "Inherit" || blnForceRender)
				{
					objWriter.WriteAttributeString("TH", (proxyPropertyValue != "Inherit") ? proxyPropertyValue : string.Empty);
				}
			}
		}

		/// 
		/// Renders positioning
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderPositioning(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!HasPositioning)
			{
				return;
			}
			RenderMinMaxSizeAttributes(objContext, objWriter);
			if (Parent is FlowLayoutPanel)
			{
				RenderWidth(objContext, objWriter);
				RenderHeight(objContext, objWriter);
				return;
			}
			DockStyle proxyPropertyValue = GetProxyPropertyValue("Dock", Dock);
			if (proxyPropertyValue == DockStyle.None)
			{
				RenderAnchoring(objContext, objWriter, GetProxyPropertyValue("Anchor", Anchor), blnForceEmptyRender: false);
			}
			else if (blnForceRender)
			{
				RenderAnchoring(objContext, objWriter, AnchorStyles.None, blnForceEmptyRender: true);
			}
			RenderDocking(objContext, objWriter, proxyPropertyValue, blnForceRender);
		}

		/// 
		/// Renders the docking.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="enmDockStyle">The dock style.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected virtual void RenderDocking(IContext objContext, IAttributeWriter objWriter, DockStyle enmDockStyle, bool blnForceRender)
		{
			switch (enmDockStyle)
			{
			case DockStyle.Fill:
				objWriter.WriteAttributeString("D", "F");
				return;
			case DockStyle.Top:
				objWriter.WriteAttributeString("D", "T");
				RenderHeight(objContext, objWriter);
				return;
			case DockStyle.Bottom:
				objWriter.WriteAttributeString("D", "B");
				RenderHeight(objContext, objWriter);
				return;
			case DockStyle.Left:
				objWriter.WriteAttributeString("D", objContext.ShouldApplyMirroring ? "R" : "L");
				RenderWidth(objContext, objWriter);
				return;
			case DockStyle.Right:
				objWriter.WriteAttributeString("D", objContext.ShouldApplyMirroring ? "L" : "R");
				RenderWidth(objContext, objWriter);
				return;
			}
			if (blnForceRender)
			{
				objWriter.WriteAttributeString("D", string.Empty);
			}
		}

		/// 
		/// Renders the anchoring.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="enmAnchorStyle">The anchor style.</param>
		/// <param name="blnForceEmptyRender">if set to true</c> [BLN force empty render].</param>
		protected virtual void RenderAnchoring(IContext objContext, IAttributeWriter objWriter, AnchorStyles enmAnchorStyle, bool blnForceEmptyRender)
		{
			string text = string.Empty;
			if (!blnForceEmptyRender)
			{
				bool flag = Parent is TableLayoutPanel;
				bool flag2 = false;
				bool flag3 = false;
				Point proxyPropertyValue = GetProxyPropertyValue("Location", new Point(mintLeft, mintTop));
				if (IsLeftAnchored(enmAnchorStyle))
				{
					text += "L";
					objWriter.WriteAttributeString("L", flag ? "0" : proxyPropertyValue.X.ToString());
					flag2 = true;
				}
				if (IsRightAnchored(enmAnchorStyle))
				{
					text += "R";
					objWriter.WriteAttributeString("R", flag ? "0" : LayoutRight.ToString());
					flag2 = true;
				}
				if (IsTopAnchored(enmAnchorStyle))
				{
					text += "T";
					objWriter.WriteAttributeString("T", flag ? "0" : proxyPropertyValue.Y.ToString());
					flag3 = true;
				}
				if (IsBottomAnchored(enmAnchorStyle))
				{
					text += "B";
					objWriter.WriteAttributeString("B", flag ? "0" : LayoutBottom.ToString());
					flag3 = true;
				}
				if (!flag2)
				{
					text += "H";
					objWriter.WriteAttributeString("L", CenteredLeft.ToString());
				}
				if (!flag3)
				{
					text += "V";
					objWriter.WriteAttributeString("T", CenteredTop.ToString());
				}
				RenderHeight(objContext, objWriter);
				RenderWidth(objContext, objWriter);
			}
			objWriter.WriteAttributeString("A", text);
		}

		/// 
		/// Renders the height.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// This is a preliminary interface and is subject for change.</remarks>
		internal virtual void RenderHeight(IContext objContext, IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("H", GetProxyPropertyValue("Size", new Size(0, GetCalculatedHeight(blnUseLayoutValues: false))).Height.ToString());
		}

		/// 
		/// Renders the width.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// This is a preliminary interface and is subject for change.</remarks>
		internal virtual void RenderWidth(IContext objContext, IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("W", GetProxyPropertyValue("Size", new Size(GetCalculatedWidth(blnUseLayoutValues: false), 0)).Width.ToString());
		}

		/// 
		/// Gets the container control 
		/// </summary>
		/// </returns>
		internal IContainerControl GetContainerControlInternal()
		{
			Control control = this;
			if (control != null && IsContainerControl)
			{
				control = control.ParentInternal;
			}
			while (control != null && !IsFocusManagingContainerControl(control))
			{
				control = control.ParentInternal;
			}
			return (IContainerControl)control;
		}

		/// 
		/// Gets a flag indicating if a control can manage focus
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// 
		/// 	true</c> if [is focus managing container control] [the specified obj control]; otherwise, false</c>.
		/// </returns>
		private static bool IsFocusManagingContainerControl(Control objControl)
		{
			return (objControl.menmControlStyle & ControlStyles.ContainerControl) == ControlStyles.ContainerControl && objControl is IContainerControl;
		}

		/// 
		/// Sets focus to this control
		/// </summary>
		/// </returns>
		public bool Focus()
		{
			Form form = Form;
			if (form != null && form.Visible && !form.HasModalWindows)
			{
				return FocusInternal();
			}
			return false;
		}

		/// 
		/// Focuses the internal.
		/// </summary>
		/// </returns>
		internal virtual bool FocusInternal()
		{
			if (CanFocus && VWGContext.Current is IApplicationContext applicationContext && applicationContext.GetFocused() != this)
			{
				applicationContext.SetFocused(this, blnInvokeFocusCommand: true);
				OnGotFocus(EventArgs.Empty);
			}
			if (Focused && ParentInternal != null)
			{
				IContainerControl containerControlInternal = ParentInternal.GetContainerControlInternal();
				if (containerControlInternal != null)
				{
					if (containerControlInternal is ContainerControl)
					{
						((ContainerControl)containerControlInternal).SetActiveControlInternal(this);
					}
					else
					{
						containerControlInternal.ActiveControl = this;
					}
				}
			}
			return Focused;
		}

		/// 
		/// Notifies the validated.
		/// </summary>
		private void NotifyValidated()
		{
			OnValidated(EventArgs.Empty);
		}

		/// 
		/// Notifies the validation result.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="ev">The <see cref="T:System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
		internal virtual void NotifyValidationResult(object sender, CancelEventArgs ev)
		{
			ValidationCancelled = ev.Cancel;
		}

		/// 
		/// Notifies the validating.
		/// </summary>
		/// </returns>
		private bool NotifyValidating()
		{
			CancelEventArgs e = new CancelEventArgs();
			OnValidating(e);
			return e.Cancel;
		}

		/// 
		/// Raises the enter event
		/// </summary>
		internal void NotifyEnter()
		{
			OnEnter(EventArgs.Empty);
		}

		/// 
		/// Raises the leave event
		/// </summary>
		internal void NotifyLeave()
		{
			OnLeave(EventArgs.Empty);
		}

		/// Invalidates the entire surface of the control and causes the control to be redrawn.</summary>
		public void Invalidate()
		{
			Invalidate(blnInvalidateChildren: false);
		}

		/// Invalidates a specific region of the control and causes a paint message to be sent to the control. Optionally, invalidates the child controls assigned to the control.</summary>
		public void Invalidate(bool blnInvalidateChildren)
		{
			Update();
		}

		/// 
		/// Activates the control.  
		/// </summary>
		public void Select()
		{
			Select(blnDirected: false, blnForward: false);
		}

		/// 
		///  Activates a child control. Optionally specifies the direction in the tab order to select the control from.  
		/// </summary>
		protected virtual void Select(bool blnDirected, bool blnForward)
		{
			IContainerControl containerControlInternal = GetContainerControlInternal();
			if (containerControlInternal != null)
			{
				containerControlInternal.ActiveControl = this;
			}
		}

		/// 
		/// Activates the next control.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="blnForward">if set to true</c> [BLN forward].</param>
		/// <param name="blnTabStopOnly">if set to true</c> [BLN tab stop only].</param>
		/// <param name="blnNested">if set to true</c> [BLN nested].</param>
		/// <param name="blnWrap">if set to true</c> [BLN wrap].</param>
		/// 
		/// true if a control was activated; otherwise, false.
		/// </returns>
		public bool SelectNextControl(Control objControl, bool blnForward, bool blnTabStopOnly, bool blnNested, bool blnWrap)
		{
			if (!Contains(objControl) || (!blnNested && objControl.Parent != this))
			{
				objControl = null;
			}
			bool flag = false;
			Control control = objControl;
			do
			{
				objControl = GetNextControl(objControl, blnForward);
				if (objControl == null)
				{
					if (!blnWrap)
					{
						break;
					}
					if (flag)
					{
						return false;
					}
					flag = true;
				}
				else if (objControl.CanSelect && (!blnTabStopOnly || objControl.TabStop) && (blnNested || objControl.Parent == this))
				{
					objControl.Select(blnDirected: true, blnForward);
					return true;
				}
			}
			while (objControl != control);
			return false;
		}

		///  
		///     Unsafe internal version of SelectNextControl - Use with caution!
		/// </devdoc>
		internal bool SelectNextControlInternal(Control objControl, bool blnForward, bool blnTabStopOnly, bool blnNested, bool blnWrap)
		{
			return SelectNextControl(objControl, blnForward, blnTabStopOnly, blnNested, blnWrap);
		}

		/// 
		/// Updates the params internally.
		/// </summary>
		/// <param name="enmType">Type of the enm.</param>
		internal void UpdateParamsInternal(AttributeType enmType)
		{
			UpdateParams(enmType);
		}

		/// 
		/// Finds the form internal.
		/// </summary>
		/// </returns>
		internal Form FindFormInternal()
		{
			Control control = this;
			while (control != null && !(control is Form))
			{
				control = control.ParentInternal;
			}
			return (Form)control;
		}

		/// 
		/// Finds the form.
		/// </summary>
		/// </returns>
		public Form FindForm()
		{
			return FindFormInternal();
		}

		/// 
		/// Raises the <see cref="E:EnabledChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnEnabledChanged(EventArgs e)
		{
			EnabledChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:TextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnTextChanged(EventArgs e)
		{
			TextChangedHandler?.Invoke(this, e);
			OnTextChangedQueued(e);
		}

		/// 
		/// Raise TextChangedQueued event
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnTextChangedQueued(EventArgs e)
		{
			TextChangedQueuedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.DoubleClick"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDoubleClick(EventArgs e)
		{
			DoubleClickHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnFontChanged(EventArgs e)
		{
			FontChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ForeColorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnForeColorChanged(EventArgs e)
		{
			ForeColorChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHandleCreated(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleDestroyed"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHandleDestroyed(EventArgs e)
		{
		}

		/// 
		/// Childs the got focus.
		/// </summary>
		/// <param name="objChild">The child.</param>
		private void ChildGotFocus(Control objChild)
		{
			if (Parent != null)
			{
				Parent.ChildGotFocus(objChild);
			}
		}

		/// 
		/// Raises the <see cref="E:GotFocus" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected internal virtual void OnGotFocus(EventArgs e)
		{
			if (Parent != null)
			{
				Parent.ChildGotFocus(this);
			}
			GotFocusHandler?.Invoke(this, new EventArgs());
		}

		/// 
		/// Raises the <see cref="E:LostFocus" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnLostFocus(EventArgs e)
		{
			LostFocusHandler?.Invoke(this, new EventArgs());
		}

		/// 
		///  Displays the control to the user. 
		/// </summary>
		public virtual void Show()
		{
			Visible = true;
		}

		/// 
		/// Conceals the control from the user.  
		/// </summary>
		public void Hide()
		{
			Visible = false;
		}

		/// 
		/// Sets the control minimum size by updating its bounds.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="objValue">The value.</param>
		internal void SetMinimumSize(IArrangedElement objElement, Size objValue)
		{
			Rectangle bounds = objElement.Bounds;
			if (objValue.Width > 0)
			{
				bounds.Width = Math.Max(bounds.Width, objValue.Width);
			}
			if (objValue.Height > 0)
			{
				bounds.Height = Math.Max(bounds.Height, objValue.Height);
				objElement.SetBounds(bounds, BoundsSpecified.Size);
			}
		}

		/// 
		/// Sets the maximum size by updating its bounds.
		/// </summary>
		/// <param name="objElement">The element.</param>
		/// <param name="objValue">The value.</param>
		internal void SetMaximumSize(IArrangedElement objElement, Size objValue)
		{
			Rectangle bounds = objElement.Bounds;
			if (objValue.Width > 0)
			{
				bounds.Width = Math.Min(bounds.Width, objValue.Width);
			}
			if (objValue.Height > 0)
			{
				bounds.Height = Math.Min(bounds.Height, objValue.Height);
			}
			objElement.SetBounds(bounds, BoundsSpecified.Size);
		}

		/// 
		/// Refreshes this instance.
		/// </summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void Refresh()
		{
		}

		/// Begins a drag-and-drop operation.</summary>
		/// A value from the <see cref="T:System.Windows.Forms.DragDropEffects"></see> enumeration that represents the final effect that was performed during the drag-and-drop operation.</returns>
		/// <param name="data">The data to drag. </param>
		/// <param name="allowedEffects">One of the <see cref="T:System.Windows.Forms.DragDropEffects"></see> values. </param>
		/// 1</filterpriority>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects)
		{
			return DragDropEffects.None;
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objProposedSize">Size of the obj proposed.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual Size GetPreferredSize(Size objProposedSize)
		{
			return GetPreferredSize(objProposedSize, blnIsClientMinimumSize: false);
		}

		/// 
		/// Gets the preferred size or the client minimum size.
		/// </summary>
		/// <param name="objProposedSize">The proposed size.</param>
		/// <param name="blnIsClientMinimumSize">if set to true</c> [BLN is client minimum size].</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual Size GetPreferredSize(Size objProposedSize, bool blnIsClientMinimumSize)
		{
			int val = 0;
			int val2 = 0;
			int num = 0;
			int num2 = 0;
			int val3 = 0;
			int val4 = 0;
			if (mobjControls != null)
			{
				int count = mobjControls.Count;
				if (count > 0)
				{
					for (int num3 = count - 1; num3 >= 0; num3--)
					{
						Control control = mobjControls[num3];
						if (control.Visible)
						{
							switch (control.Dock)
							{
							case DockStyle.None:
							{
								AnchorStyles anchor = control.Anchor;
								if (!control.IsBottomAnchored(anchor) && control.IsTopAnchored(anchor))
								{
									val = Math.Max(val, control.LayoutTop + control.Height);
								}
								if (!control.IsRightAnchored(anchor) && control.IsLeftAnchored(anchor))
								{
									val2 = Math.Max(val2, control.LayoutLeft + control.Width);
								}
								break;
							}
							case DockStyle.Top:
							case DockStyle.Bottom:
								num += control.Height;
								if (!blnIsClientMinimumSize || control.AutoSize)
								{
									val4 = Math.Max(val4, num2 + control.PreferredSize.Width);
								}
								break;
							case DockStyle.Right:
							case DockStyle.Left:
								num2 += control.Width;
								if (!blnIsClientMinimumSize || control.AutoSize)
								{
									val3 = Math.Max(val3, num + control.PreferredSize.Height);
								}
								break;
							case DockStyle.Fill:
								if (!blnIsClientMinimumSize || control.AutoSize)
								{
									val3 = Math.Max(val3, num + control.PreferredSize.Height);
									val4 = Math.Max(val4, num2 + control.PreferredSize.Width);
								}
								break;
							}
						}
					}
				}
			}
			return new Size(Math.Max(val2, Math.Max(val4, num2)), Math.Max(val, Math.Max(val3, num)));
		}

		/// 
		/// Gets the preferred size by auto size mode.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objProposedSize">Size of the obj proposed.</param>
		/// <param name="objPreferredSize">Size of the obj preferred.</param>
		/// </returns>
		protected static Size GetPreferredSizeByAutoSizeMode(Control objControl, Size objProposedSize, Size objPreferredSize)
		{
			if (objControl != null && objControl.AutoSize && objControl.AutoSizeMode == AutoSizeMode.GrowOnly)
			{
				if (objPreferredSize.Width < objProposedSize.Width)
				{
					objPreferredSize.Width = objProposedSize.Width;
				}
				if (objPreferredSize.Height < objProposedSize.Height)
				{
					objPreferredSize.Height = objProposedSize.Height;
				}
			}
			return objPreferredSize;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validating"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValidating(CancelEventArgs e)
		{
			ValidatingHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validated"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnValidated(EventArgs e)
		{
			ValidatedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CausesValidationChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCausesValidationChanged(EventArgs e)
		{
			CausesValidationChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.VisibleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnVisibleChanged(EventArgs e)
		{
			bool visible = Visible;
			DoCreateControl(visible);
			VisibleChangedHandler?.Invoke(this, e);
			ControlCollection controls = Controls;
			if (controls == null)
			{
				return;
			}
			for (int i = 0; i < controls.Count; i++)
			{
				Control control = controls[i];
				if (control.Visible)
				{
					control.OnParentVisibleChanged(e);
				}
				if (!visible)
				{
					control.OnParentBecameInvisible();
				}
			}
		}

		/// 
		/// Create a control.
		/// </summary>
		/// <param name="blnVisible">if set to true</c> [BLN visible].</param>
		protected virtual void DoCreateControl(bool blnVisible)
		{
			if (ParentInternal != null && blnVisible && !Created && ParentInternal.Created)
			{
				CreateControl();
			}
		}

		/// 
		/// Raises the <see cref="E:ParentVisibleChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentVisibleChanged(EventArgs e)
		{
			if (GetState(ComponentState.Visible))
			{
				OnVisibleChanged(e);
			}
		}

		/// 
		/// Called when parent became invisible.
		/// </summary>
		internal virtual void OnParentBecameInvisible()
		{
			if (GetState(ComponentState.Visible) && mobjControls != null)
			{
				for (int i = 0; i < mobjControls.Count; i++)
				{
					mobjControls[i].OnParentBecameInvisible();
				}
			}
		}

		/// Supports rendering to the specified bitmap.</summary>
		/// <param name="objBitmap">The bitmap to be drawn to.</param>
		/// <param name="objTargetBounds">The bounds within which the control is rendered.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DrawToBitmap(Bitmap objBitmap, Rectangle objTargetBounds)
		{
			if (objBitmap == null)
			{
				throw new ArgumentNullException("objBitmap");
			}
			if (objTargetBounds.Width <= 0 || objTargetBounds.Height <= 0 || objTargetBounds.X < 0 || objTargetBounds.Y < 0)
			{
				throw new ArgumentException("objTargetBounds");
			}
			int intWidth = Math.Min(Width, objTargetBounds.Width);
			int intHeight = Math.Min(Height, objTargetBounds.Height);
			using Bitmap image = DrawControl(new ControlRenderingContext(objBitmap.PixelFormat), intWidth, intHeight);
			using Graphics graphics = Graphics.FromImage(objBitmap);
			graphics.DrawImage(image, objTargetBounds.Location);
		}

		/// 
		/// Draws the control and return the cotrol bitmap.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="intWidth">The bitmap width.</param>
		/// <param name="intHeight">The bitmap height.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Bitmap DrawControl(ControlRenderingContext objContext, int intWidth, int intHeight)
		{
			Bitmap bitmap = new Bitmap(intWidth, intHeight, objContext.PixelFormat);
			using (Graphics objGraphics = Graphics.FromImage(bitmap))
			{
				DrawControl(objContext, objGraphics);
			}
			return bitmap;
		}

		/// 
		/// Draws the control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual void DrawControl(ControlRenderingContext objContext, Graphics objGraphics)
		{
			GetControlRenderer()?.Render(objContext, objGraphics);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual ControlRenderer GetControlRenderer()
		{
			return new ControlRenderer(this);
		}

		/// 
		/// Sends to back.
		/// </summary>
		public void SendToBack()
		{
			if (Parent != null)
			{
				Parent.Controls.SetChildIndex(this, -1);
			}
		}

		/// 
		/// Brings the control to the front of the z-order.
		/// </summary>       
		public void BringToFront()
		{
			if (Parent != null)
			{
				Parent.Controls.SetChildIndex(this, 0);
			}
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.</summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				SuspendLayout();
				try
				{
					ResetBindings();
					if (Parent != null)
					{
						Parent.Controls.Remove(this);
					}
					ControlCollection controls = Controls;
					if (controls != null)
					{
						for (int i = 0; i < controls.Count; i++)
						{
							Control control = controls[i];
							control.InternalParent = null;
							control.Dispose();
						}
						mobjControls = null;
					}
					base.Dispose(blnDisposing);
					return;
				}
				finally
				{
					ResumeLayout(blnPerformLayout: false);
				}
			}
			base.Dispose(blnDisposing);
		}

		/// 
		/// Resets the created flag.
		/// </summary>
		protected void ResetCreatedFlag()
		{
			SetState(ControlState.Created, blnValue: false);
			foreach (Control control in Controls)
			{
				control.ResetCreatedFlag();
			}
		}

		/// 2</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetBindings()
		{
			DataBindings?.Clear();
		}

		/// 
		/// Resets the text.
		/// </summary>
		public virtual void ResetText()
		{
			Text = string.Empty;
		}

		/// 
		/// Resets the font.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetFont()
		{
			Font = null;
		}

		/// 
		/// Resets the color of the fore.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetForeColor()
		{
			ForeColor = Color.Empty;
		}

		/// 
		/// Resets the color of the back.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBackColor()
		{
			BackColor = Color.Empty;
		}

		/// 
		/// Resets the border style.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBorderStyle()
		{
			BorderStyle = DefaultBorderStyle;
		}

		/// 
		/// Resets the border Color.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBorderColor()
		{
			BorderColor = DefaultBorderColor;
		}

		/// 
		/// Resets the border Width.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetBorderWidth()
		{
			BorderWidth = DefaultBorderWidth;
		}

		/// 
		/// Resets the Anchor.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetAnchor()
		{
			Anchor = AnchorStyles.Left | AnchorStyles.Top;
		}

		/// 
		/// Resets the Minimum Size.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetMinimumSize()
		{
			MinimumSize = DefaultMinimumSize;
		}

		/// 
		/// Resets the Maximum Size.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetMaximumSize()
		{
			MaximumSize = DefaultMaximumSize;
		}

		/// 
		/// Resets the border style.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetPadding()
		{
			RemoveValue(PaddingProperty);
		}

		/// 
		/// Resets the border style.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetMargin()
		{
			RemoveValue(MarginProperty);
		}

		/// 
		/// Resets the border style.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetSize()
		{
			Size = DefaultSize;
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			UnRegisterBatch(Controls);
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			RegisterBatch(Controls);
		}

		/// 
		/// Gets the command text.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// </returns>
		protected internal string GetCommandText(string strText)
		{
			string text = strText;
			if (!base.DesignMode)
			{
				Regex regex = new Regex("(?<![&])&(?![&])");
				text = regex.Replace(text, string.Empty);
				text = text.Replace("&&", "&");
			}
			return text;
		}

		/// 
		/// Invokes client side selection
		/// </summary>
		/// <param name="intStart"></param>
		/// <param name="intLength"></param>
		protected virtual void InvokeSelection(int intStart, int intLength)
		{
			InvokeMethodWithId("Control_SetSelection", intStart, intLength);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new ControlWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "RecursiveResizeEvent")
			{
				UpdateParams(AttributeType.Control);
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}

		/// 
		/// Gets the size of the preferred.
		/// </summary>
		/// <param name="objProposedSize">Size of the proposed.</param>
		/// </returns>
		Size IArrangedElement.GetPreferredSize(Size objProposedSize)
		{
			return GetPreferredSize(objProposedSize);
		}

		/// 
		/// Gets the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objSerializableProperty">The serializable property.</param>
		/// </returns>
		T IArrangedElement.GetValue<T>(SerializableProperty objSerializableProperty)
		{
			return GetValue(objSerializableProperty);
		}

		/// 
		/// Sets the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objSerializableProperty">The serializable property.</param>
		/// <param name="objValue">The obj value.</param>
		void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)
		{
			SetValue(objSerializableProperty, objValue);
		}

		/// 
		/// Creates the graphics.
		/// </summary>
		/// </returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Graphics CreateGraphics()
		{
			return null;
		}

		/// 
		/// Sets the enabled without update.
		/// </summary>
		/// <param name="blnValue">if set to true</c> then control enables.</param>
		/// </returns>
		internal void SetEnabledInternal(bool blnValue)
		{
			if (SetStateWithCheck(ComponentState.Enabled, blnValue))
			{
				OnEnabledChanged(EventArgs.Empty);
				FireObservableItemPropertyChanged("Enabled");
			}
		}

		/// 
		/// Gets the name of the client component.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override string GetClientComponentName()
		{
			return Name;
		}

		/// 
		/// Shoulds the serialize draggable.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeResizable()
		{
			if (Resizable == null || (!Resizable.IsResizable && Resizable.IsDefault()))
			{
				return false;
			}
			return true;
		}

		/// 
		/// Shoulds the serialize draggable.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeDraggable()
		{
			if (Draggable == null || (!Draggable.IsDraggable && Draggable.IsDefault()))
			{
				return false;
			}
			return true;
		}

		/// 
		///
		/// </summary>
		/// </returns>
		internal virtual bool CanSelectCore()
		{
			if ((menmControlStyle & ControlStyles.Selectable) != ControlStyles.Selectable)
			{
				return false;
			}
			for (Control control = this; control != null; control = control.Parent)
			{
				if (!control.Enabled || !control.Visible)
				{
					return false;
				}
			}
			return true;
		}

		/// Retrieves the value of the specified control style bit for the control.</summary>
		/// true if the specified control style bit is set to true; otherwise, false.</returns>
		/// <param name="enmflag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to return the value from. </param>
		protected bool GetStyle(ControlStyles enmflag)
		{
			return (menmControlStyle & enmflag) == enmflag;
		}

		/// Sets the specified style bit to the specified value.</summary>
		/// <param name="enmFlag">The <see cref="T:Gizmox.WebGUI.Forms.ControlStyles"></see> bit to set. </param>
		/// <param name="blnValue">true to apply the specified style to the control; otherwise, false. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void SetStyle(ControlStyles enmFlag, bool blnValue)
		{
			ControlStyles controlStyles = menmControlStyle;
			menmControlStyle = (blnValue ? (controlStyles | enmFlag) : (controlStyles & ~enmFlag));
		}

		/// 
		/// Check if the DragTargets property should be serialized in designtime
		/// </summary>
		private new bool ShouldSerializeDragTargets()
		{
			return DragTargets.Length != 0;
		}

		/// 
		/// Creates the controls instance.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}

		/// 
		/// Performs the layout.
		/// </summary>
		/// <param name="blnForceLayout">if set to true</c> [BLN force layout].</param>
		void IControl.PerformLayout(bool blnForceLayout)
		{
			PerformLayout(blnForceLayout);
		}

		/// 
		/// Sets the scroll top.
		/// </summary>
		/// <param name="intTop">The int top.</param>
		/// </returns>
		protected bool SetScrollTop(int intTop)
		{
			return SetValue(ScrollTopProperty, intTop);
		}

		/// 
		/// Sets the scroll left internal.
		/// </summary>
		/// The scroll left internal.</value>
		protected bool SetScrollLeft(int intLeft)
		{
			return SetValue(ScrollLeftProperty, intLeft);
		}

		/// 
		/// Sets the visible internal.
		/// </summary>
		/// <param name="blnValue">if set to true</c> set visibility true.</param>
		internal virtual void SetVisibleInternal(bool blnValue)
		{
			if (VisibleIntenal != blnValue)
			{
				SetVisibleCore(blnValue);
				InvalidateParentLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: false));
				Update();
			}
		}

		/// 
		/// Returns the visibility internally
		/// </summary>
		/// </returns>
		internal virtual bool GetVisibleCore()
		{
			if (!GetState(ComponentState.Visible))
			{
				return false;
			}
			return ParentInternal?.GetVisibleCore() ?? true;
		}

		/// 
		/// Selects the next if focused.
		/// </summary>
		private void SelectNextIfFocused()
		{
			Control parentInternal = ParentInternal;
			if (ContainsFocus && parentInternal != null)
			{
				IContainerControl containerControlInternal = parentInternal.GetContainerControlInternal();
				if (containerControlInternal != null)
				{
					((Control)containerControlInternal).SelectNextControlInternal(this, blnForward: true, blnTabStopOnly: true, blnNested: true, blnWrap: true);
				}
			}
		}

		/// Sets the control to the specified visible state.</summary>
		/// <param name="blnValue">true to make the control visible; otherwise, false. </param>
		protected virtual void SetVisibleCore(bool blnValue)
		{
			if (GetVisibleCore() != blnValue)
			{
				if (!blnValue)
				{
					SelectNextIfFocused();
				}
				bool flag = false;
				Control parent = Parent;
				if ((blnValue && parent != null && parent.Created) || (blnValue && GetTopLevel()))
				{
					VisibleIntenal = blnValue;
					flag = true;
					try
					{
						if (blnValue)
						{
							CreateControl();
						}
					}
					catch
					{
						VisibleIntenal = !blnValue;
						throw;
					}
				}
				if (GetVisibleCore() != blnValue)
				{
					VisibleIntenal = blnValue;
					flag = true;
				}
				if (flag)
				{
					FireObservableItemPropertyChanged("Visible");
					OnVisibleChanged(EventArgs.Empty);
				}
			}
			else if (VisibleIntenal || blnValue)
			{
				VisibleIntenal = blnValue;
			}
		}

		/// 
		/// Sets the enabled.
		/// </summary>
		/// <param name="value">if set to true</c> [value].</param>
		/// <param name="enmAttributeTypes">The enm attribute types.</param>
		protected void SetEnabled(bool value, AttributeType enmAttributeTypes)
		{
			SetEnabled(value, enmAttributeTypes, blnUseClientUpdateHandler: true);
		}

		/// 
		/// Sets the enabled.
		/// </summary>
		/// <param name="value">if set to true</c> [value].</param>
		/// <param name="enmAttributeTypes">The enm attribute types.</param>
		/// <param name="blnUseClientUpdateHandler">if set to true</c> [BLN use client update handler].</param>
		protected void SetEnabled(bool value, AttributeType enmAttributeTypes, bool blnUseClientUpdateHandler)
		{
			if (SetStateWithCheck(ComponentState.Enabled, value))
			{
				OnEnabledChanged(EventArgs.Empty);
				FireObservableItemPropertyChanged("Enabled");
				UpdateParams(enmAttributeTypes, blnUseClientUpdateHandler);
			}
		}

		/// 
		/// Resets the visual template.
		/// </summary>
		private void ResetVisualTemplate()
		{
			RemoveValue(VisualTemplateProperty);
		}

		/// 
		/// Shoulds the serialize visual template.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool ShouldSerializeVisualTemplate()
		{
			return ContainsValue(VisualTemplateProperty);
		}

		/// 
		/// Computes the location of the specified screen point into client coordinates.
		/// </summary>
		/// <param name="objPoint">The point to be calculated.</param>
		/// point in client coordinates</returns>
		public Point PointToClient(Point objPoint)
		{
			Control parent = Parent;
			if (parent == null)
			{
				return objPoint;
			}
			objPoint.X -= Left;
			objPoint.Y -= Top;
			return parent.PointToClient(objPoint);
		}

		/// 
		/// Points to screen.
		/// Not implemented by design.
		/// </summary>
		/// <param name="objPoint">The p.</param>
		/// </returns>
		[Obsolete("Not implemented by design.")]
		public Point PointToScreen(Point objPoint)
		{
			return objPoint;
		}

		/// 
		/// Prevent serializing margin if not required
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool ShouldSerializeMargin()
		{
			return ContainsValue(MarginProperty);
		}

		/// 
		/// Prevent serializing padding if not required
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool ShouldSerializePadding()
		{
			return ContainsValue(PaddingProperty);
		}

		/// 
		/// Gets the doch style.
		/// </summary>
		/// </returns>
		internal virtual DockStyle GetDockInternal()
		{
			return menmDock;
		}

		/// 
		/// Updates the child controls size when the docking has changed
		/// </summary>
		/// <param name="enmCurrentVal">The old docking value</param>
		/// <param name="enmNewVal">The new docking value</param>
		private void UpdateChildSizeAfterDockChange(DockStyle enmCurrentVal, DockStyle enmNewVal)
		{
			bool flag = false;
			bool flag2 = false;
			if (((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right)) || ((enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top)) || (enmCurrentVal == DockStyle.None && enmNewVal != DockStyle.None) || (enmNewVal == DockStyle.None && enmCurrentVal != DockStyle.None))
			{
				flag = true;
				flag2 = true;
			}
			else if (((enmCurrentVal == DockStyle.Bottom || enmCurrentVal == DockStyle.Top) && enmNewVal == DockStyle.Fill) || (enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Bottom || enmNewVal == DockStyle.Top)))
			{
				flag2 = true;
			}
			else if (((enmCurrentVal == DockStyle.Left || enmCurrentVal == DockStyle.Right) && enmNewVal == DockStyle.Fill) || (enmCurrentVal == DockStyle.Fill && (enmNewVal == DockStyle.Left || enmNewVal == DockStyle.Right)))
			{
				flag = true;
			}
			if (flag || flag2)
			{
				UpdateChildSize(flag, flag2);
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return Controls;
		}

		/// 
		/// Gets the anchor style.
		/// </summary>
		/// </returns>
		internal virtual AnchorStyles GetAnchorInternal()
		{
			return menmAnchor;
		}

		/// 
		/// Updates the size layuout params.
		/// </summary>
		/// <param name="blnUpdateCurrent">if set to true</c> [BLN update current].</param>
		/// <param name="blnForceChildUpdate">if set to true</c> [BLN force child update].</param>
		private void UpdateSizeLayuoutParams(bool blnUpdateCurrent, bool blnForceChildUpdate)
		{
			if (blnUpdateCurrent)
			{
				UpdateParams(AttributeType.Layout);
			}
			if (!(IsLayoutSuspended || blnForceChildUpdate))
			{
				return;
			}
			foreach (Control control3 in Controls)
			{
				AnchorStyles anchor = control3.Anchor;
				if (!control3.IsRightAnchored(anchor) && !control3.IsBottomAnchored(anchor))
				{
					continue;
				}
				control3.UpdateParams(AttributeType.Layout);
				foreach (Control control4 in control3.Controls)
				{
					AnchorStyles anchor2 = control4.Anchor;
					DockStyle dock = control4.Dock;
					if (control4.SizeEffectedByParentResizing(anchor2, dock))
					{
						control4.UpdateSizeLayuoutParams(dock == DockStyle.None, blnForceChildUpdate: true);
					}
				}
			}
		}

		/// 
		/// Updates the size of the child.
		/// </summary>
		private void UpdateChildSize(bool blnHorizontal, bool blnVertical)
		{
			if (IsLayoutSuspended)
			{
				return;
			}
			foreach (Control control in Controls)
			{
				AnchorStyles anchor = control.Anchor;
				DockStyle dock = control.Dock;
				if ((dock == DockStyle.Fill && (blnHorizontal || blnVertical)) || (blnHorizontal && ((control.IsRightAnchored(anchor) && control.IsLeftAnchored(anchor)) || dock == DockStyle.Top || dock == DockStyle.Bottom)) || (blnVertical && ((control.IsTopAnchored(anchor) && control.IsBottomAnchored(anchor)) || dock == DockStyle.Left || dock == DockStyle.Right)))
				{
					control.OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
				}
			}
		}

		/// 
		/// Gets a value indicating whether [size effected by parent resizing].
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// <param name="enmDock">The enm dock.</param>
		/// </returns>
		/// 
		/// 	true</c> if [size effected by parent resizing]; otherwise, false</c>.
		/// </value>
		internal virtual bool SizeEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
		{
			bool flag = false;
			if (Parent != null)
			{
				flag = flag || enmDock != DockStyle.None;
				flag = flag || ((enmAnchor & AnchorStyles.Left) != AnchorStyles.None && (enmAnchor & AnchorStyles.Right) != 0);
				flag = flag || ((enmAnchor & AnchorStyles.Top) != AnchorStyles.None && (enmAnchor & AnchorStyles.Bottom) != 0);
			}
			return flag;
		}

		/// 
		/// Gets a value indicating whether [location effected by parent resizing].
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// <param name="enmDock">The enm dock.</param>
		/// </returns>
		/// 
		/// 	true</c> if [location effected by parent resizing]; otherwise, false</c>.
		/// </value>
		internal bool LocationEffectedByParentResizing(AnchorStyles enmAnchor, DockStyle enmDock)
		{
			bool flag = false;
			if (Parent != null)
			{
				flag = flag || ((enmAnchor & AnchorStyles.Right) != AnchorStyles.None && (enmAnchor & AnchorStyles.Left) == 0);
				flag = flag || ((enmAnchor & AnchorStyles.Bottom) != AnchorStyles.None && (enmAnchor & AnchorStyles.Top) == 0);
				flag = flag || enmDock == DockStyle.Right;
				flag = flag || enmDock == DockStyle.Bottom;
			}
			return flag;
		}

		/// 
		/// Sets the height.
		/// </summary>
		/// <param name="intHeight">Height of the int.</param>
		/// <param name="blnUpdateCurrent">if set to true</c> [BLN update current].</param>
		protected void SetHeight(int intHeight, bool blnUpdateCurrent)
		{
			if (SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height))
			{
				OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				DockStyle dock = Dock;
				if (dock != DockStyle.Fill && dock != DockStyle.Left && dock != DockStyle.Right)
				{
					UpdateSizeLayuoutParams(blnUpdateCurrent, blnForceChildUpdate: false);
				}
			}
		}

		/// 
		/// Gets the calculated height.
		/// </summary>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		protected virtual int GetCalculatedHeight(bool blnUseLayoutValues)
		{
			int num = mintHeight;
			if (!blnUseLayoutValues && InternalParent is Control control)
			{
				DockStyle dock = Dock;
				if (UsePreferredSize && (IsVerticalDocked(dock) || !IsDocked(dock)))
				{
					num = PreferredSize.Height;
					num = ApplyBoundsConstraints(mintLeft, mintTop, Width, num).Height;
				}
				else if (!(control is FlowLayoutPanel))
				{
					if (dock == DockStyle.Left || dock == DockStyle.Right || dock == DockStyle.Fill)
					{
						if (control is TableLayoutPanel tableLayoutPanel)
						{
							num = Convert.ToInt32(tableLayoutPanel.GetControlCalculatedHeight(this, blnUseLayoutValues));
						}
						else
						{
							int num2 = control.Padding.Vertical;
							int num3 = control.Controls.IndexOf(this);
							for (int num4 = control.Controls.Count - 1; num4 > num3; num4--)
							{
								if (num4 != num3)
								{
									Control control2 = control.Controls[num4];
									if (control2.GetState(ComponentState.Visible))
									{
										DockStyle dock2 = control2.Dock;
										if (dock2 == DockStyle.Top || dock2 == DockStyle.Bottom)
										{
											num2 += control2.Height;
										}
									}
								}
							}
							num = control.GetCalculatedHeight(blnUseLayoutValues) - num2;
							Size minimumSize = MinimumSize;
							if (!minimumSize.IsEmpty && minimumSize.Height != 0)
							{
								num = Math.Max(num, minimumSize.Height);
							}
							Size maximumSize = MaximumSize;
							if (!maximumSize.IsEmpty && maximumSize.Height != 0)
							{
								num = Math.Min(num, maximumSize.Height);
							}
						}
					}
				}
				else
				{
					num = ApplyBoundsConstraints(mintLeft, mintTop, Width, num).Height;
				}
			}
			return num;
		}

		/// 
		/// Gets the calculated top.
		/// </summary>
		/// <param name="blnUseLayoutValues">if set to true</c> use layout values.</param>
		/// </returns>
		protected int GetCalculatedTop(bool blnUseLayoutValues)
		{
			DockStyle dock = Dock;
			if (blnUseLayoutValues || Parent == null || !IsDocked(dock))
			{
				return mintTop;
			}
			Control parent = Parent;
			if (parent is TableLayoutPanel tableLayoutPanel)
			{
				return Convert.ToInt32(tableLayoutPanel.GetControlCalculatedTop(this, blnUseLayoutValues));
			}
			if (IsBottomDocked(dock))
			{
				return parent.DisplayRectangle.Height - Height - GetDockBoundries(DockStyle.Bottom);
			}
			return GetDockBoundries(DockStyle.Top);
		}

		/// 
		/// Gets the calculated left.
		/// </summary>
		/// <param name="blnUseLayoutValues">if set to true</c> use layout values.</param>
		/// </returns>
		protected int GetCalculatedLeft(bool blnUseLayoutValues)
		{
			DockStyle dock = Dock;
			if (blnUseLayoutValues || Parent == null || !IsDocked(dock))
			{
				return mintLeft;
			}
			Control parent = Parent;
			if (parent is TableLayoutPanel tableLayoutPanel)
			{
				return Convert.ToInt32(tableLayoutPanel.GetControlCalculatedLeft(this, blnUseLayoutValues));
			}
			if (IsRightDocked(dock))
			{
				return parent.DisplayRectangle.Width - Width - GetDockBoundries(DockStyle.Right);
			}
			return GetDockBoundries(DockStyle.Left);
		}

		/// 
		/// Gets the dock boundries.
		/// </summary>
		/// <param name="enmDockStyle">The dock style.</param>
		/// </returns>
		private int GetDockBoundries(DockStyle enmDockStyle)
		{
			int num = 0;
			Control parent = Parent;
			if (parent != null)
			{
				switch (enmDockStyle)
				{
				case DockStyle.Left:
					num += parent.Padding.Left;
					break;
				case DockStyle.Top:
					num += parent.Padding.Top;
					break;
				case DockStyle.Bottom:
					num += parent.Padding.Bottom;
					break;
				case DockStyle.Right:
					num += parent.Padding.Right;
					break;
				}
				ControlCollection controls = parent.Controls;
				int num2 = controls.IndexOf(this);
				if (num2 > -1)
				{
					for (num2++; num2 < controls.Count; num2++)
					{
						Control control = controls[num2];
						if (control.Dock == enmDockStyle)
						{
							num = ((enmDockStyle != DockStyle.Left && enmDockStyle != DockStyle.Right) ? (num + control.Height) : (num + control.Width));
						}
					}
				}
			}
			return num;
		}

		/// 
		/// Gets a value indicating whether this instance is anchored.
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// 
		/// 	true</c> if the specified enm anchor is anchored; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is anchored; otherwise, false</c>.
		/// </value>
		internal bool IsAnchored(AnchorStyles enmAnchor)
		{
			return enmAnchor != AnchorStyles.None;
		}

		/// 
		/// Gets a value indicating whether this instance is docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if the specified enm dock is docked; otherwise, false</c>.
		/// </returns>
		/// true</c> if this instance is docked; otherwise, false</c>.</value>
		internal bool IsDocked(DockStyle enmDock)
		{
			return enmDock != DockStyle.None;
		}

		/// 
		/// Gets a value indicating whether this instance is right docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is right docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is right docked; otherwise, false</c>.
		/// </value>
		internal bool IsRightDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Right;
		}

		/// 
		/// Determines whether [is fill docked] [the specified enm dock].
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is fill docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		internal bool IsFillDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Fill;
		}

		/// 
		/// Gets a value indicating whether this instance is left docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is left docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is left docked; otherwise, false</c>.
		/// </value>
		internal bool IsLeftDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Left;
		}

		/// 
		/// Gets a value indicating whether this instance is horizontal docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is left docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is left docked; otherwise, false</c>.
		/// </value>
		internal bool IsHorizontalDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Left || enmDock == DockStyle.Right;
		}

		/// 
		/// Determines whether is vertical docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is vertical docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		internal bool IsVerticalDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Top || enmDock == DockStyle.Bottom;
		}

		/// 
		/// Gets a value indicating whether this instance is top docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is top docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is top docked; otherwise, false</c>.
		/// </value>
		internal bool IsTopDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Top;
		}

		/// 
		/// Gets a value indicating whether this instance is bottom docked.
		/// </summary>
		/// <param name="enmDock">The enm dock.</param>
		/// 
		/// 	true</c> if [is bottom docked] [the specified enm dock]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is bottom docked; otherwise, false</c>.
		/// </value>
		internal bool IsBottomDocked(DockStyle enmDock)
		{
			return enmDock == DockStyle.Bottom;
		}

		/// 
		/// Gets a value indicating whether this instance is right anchored.
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// 
		/// 	true</c> if [is right anchored] [the specified enm anchor]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is right anchored; otherwise, false</c>.
		/// </value>
		internal bool IsRightAnchored(AnchorStyles enmAnchor)
		{
			return (enmAnchor & AnchorStyles.Right) != 0;
		}

		/// 
		/// Gets a value indicating whether this instance is left anchored.
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// 
		/// 	true</c> if [is left anchored] [the specified enm anchor]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is left anchored; otherwise, false</c>.
		/// </value>
		internal bool IsLeftAnchored(AnchorStyles enmAnchor)
		{
			return (enmAnchor & AnchorStyles.Left) != 0;
		}

		/// 
		/// Gets a value indicating whether this instance is top anchored.
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// 
		/// 	true</c> if [is top anchored] [the specified enm anchor]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is top anchored; otherwise, false</c>.
		/// </value>
		internal bool IsTopAnchored(AnchorStyles enmAnchor)
		{
			return (enmAnchor & AnchorStyles.Top) != 0;
		}

		/// 
		/// Gets a value indicating whether this instance is bottom anchored.
		/// </summary>
		/// <param name="enmAnchor">The enm anchor.</param>
		/// 
		/// 	true</c> if [is bottom anchored] [the specified enm anchor]; otherwise, false</c>.
		/// </returns>
		/// 
		/// 	true</c> if this instance is bottom anchored; otherwise, false</c>.
		/// </value>
		internal bool IsBottomAnchored(AnchorStyles enmAnchor)
		{
			return (enmAnchor & AnchorStyles.Bottom) != 0;
		}

		/// 
		/// Gets the calculated width.
		/// </summary>
		/// <param name="blnUseLayoutValues">if set to true</c> [BLN use layout values].</param>
		/// </returns>
		protected virtual int GetCalculatedWidth(bool blnUseLayoutValues)
		{
			int num = mintWidth;
			if (!blnUseLayoutValues && InternalParent is Control control)
			{
				DockStyle dock = Dock;
				if (UsePreferredSize && (IsHorizontalDocked(dock) || !IsDocked(dock)))
				{
					num = PreferredSize.Width;
					num = ApplyBoundsConstraints(mintLeft, mintTop, num, mintHeight).Width;
				}
				else if (!(control is FlowLayoutPanel))
				{
					if (dock == DockStyle.Top || dock == DockStyle.Bottom || dock == DockStyle.Fill)
					{
						if (control is TableLayoutPanel tableLayoutPanel)
						{
							num = Convert.ToInt32(tableLayoutPanel.GetControlCalculatedWidth(this, blnUseLayoutValues));
						}
						else
						{
							int num2 = control.Padding.Horizontal;
							int num3 = control.Controls.IndexOf(this);
							for (int num4 = control.Controls.Count - 1; num4 > num3; num4--)
							{
								if (num4 != num3)
								{
									Control control2 = control.Controls[num4];
									if (control2.GetState(ComponentState.Visible))
									{
										DockStyle dock2 = control2.Dock;
										if (dock2 == DockStyle.Right || dock2 == DockStyle.Left)
										{
											num2 += control2.Width;
										}
									}
								}
							}
							num = control.GetCalculatedWidth(blnUseLayoutValues) - num2;
							Size minimumSize = MinimumSize;
							if (!minimumSize.IsEmpty && minimumSize.Width != 0)
							{
								num = Math.Max(num, minimumSize.Width);
							}
							Size maximumSize = MaximumSize;
							if (!maximumSize.IsEmpty && maximumSize.Width != 0)
							{
								num = Math.Min(num, maximumSize.Width);
							}
						}
					}
					else
					{
						num = ApplyBoundsConstraints(mintLeft, mintTop, num, mintHeight).Width;
					}
				}
			}
			return num;
		}

		/// 
		/// Prevent serializing cursor if is default
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeCursor()
		{
			return ContainsValue(CursorProperty);
		}

		/// 
		/// Gets the error message.
		/// </summary>
		/// </returns>
		internal string GetErrorMessage()
		{
			return ErrorMessage;
		}

		/// 
		/// Sets the error.
		/// </summary>
		/// <param name="strValue">value.</param>
		/// <param name="objErrorIcon">The obj error icon.</param>
		internal void SetErrorMessage(string strValue, ResourceHandle objErrorIcon)
		{
			ResourceHandle errorIcon = ErrorIcon;
			string errorMessage = ErrorMessage;
			if (errorIcon != objErrorIcon || errorMessage != strValue)
			{
				ErrorIcon = objErrorIcon;
				ErrorMessage = strValue;
				UpdateParams(AttributeType.Error);
			}
		}

		/// 
		/// Sets the icon alignment.
		/// </summary>
		/// <param name="enmValue">value.</param>
		internal void SetErrorIconAlignment(ErrorIconAlignment enmValue)
		{
		}

		/// 
		/// Raises the <see cref="E:ResizeInternal" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		internal void OnResizeInternal(LayoutEventArgs objEventArgs)
		{
			if (objEventArgs.ShouldUpdateParent)
			{
				InvalidateParentLayout(objEventArgs);
			}
			OnLayoutInternal(objEventArgs);
		}

		/// 
		/// Check if design time layouting is allowed.
		/// </summary>
		/// </returns>
		private bool AllowDesignTimeLayouting()
		{
			bool result = false;
			if (GetService(typeof(IDesignerHost)) is IDesignerHost designerHost)
			{
				result = designerHost.Loading;
			}
			return result;
		}

		/// 
		/// Raises the <see cref="E:Layout" /> event.
		/// </summary>
		/// <param name="levent">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		protected virtual void OnLayout(LayoutEventArgs objEventArgs)
		{
		}

		/// 
		/// Raises the <see cref="E:LayoutInternal" /> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		internal void OnLayoutInternal(LayoutEventArgs objEventArgs)
		{
			if ((base.DesignMode && !AllowDesignTimeLayouting()) || IsLayoutSuspended)
			{
				return;
			}
			Size size = Size;
			int height = size.Height;
			int width = size.Width;
			if (mintLayoutHeight != height || mintLayoutWidth != width)
			{
				if (WinFormsCompatibility.IsRecursiveResizeEvent || !IsNonCompatibleModeLayoutSuspended)
				{
					OnLayoutInternal(objEventArgs, new Size(width, height), new Size(mintLayoutWidth, mintLayoutHeight));
				}
				mintLayoutHeight = height;
				mintLayoutWidth = width;
				OnLayout(objEventArgs);
			}
		}

		/// 
		/// Gets the opposite dock style.
		/// </summary>
		/// <param name="enmDockStyle">The enm dock style.</param>
		/// </returns>
		private DockStyle GetOppositeDockStyle(DockStyle enmDockStyle)
		{
			return enmDockStyle switch
			{
				DockStyle.Top => DockStyle.Bottom, 
				DockStyle.Bottom => DockStyle.Top, 
				DockStyle.Right => DockStyle.Left, 
				DockStyle.Left => DockStyle.Right, 
				_ => DockStyle.None, 
			};
		}

		/// 
		/// Called when child had been resized.
		/// </summary>
		/// <param name="objControl">The resized control.</param>
		/// <param name="objNewSize">The control new size.</param>
		/// <param name="objOldSize">The control old size.</param>
		private void OnDockedChildResizeInternal(LayoutEventArgs objEventArgs, Control objControl, Size objNewSize, Size objOldSize)
		{
			DockStyle dock = objControl.Dock;
			if (dock == DockStyle.None)
			{
				return;
			}
			ControlCollection controls = Controls;
			if (controls.Count <= 1)
			{
				return;
			}
			int num = controls.IndexOf(objControl);
			if (num <= 0)
			{
				return;
			}
			DockStyle oppositeDockStyle = GetOppositeDockStyle(dock);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				Control control = controls[num2];
				if (control.Dock != DockStyle.None && control.Dock != oppositeDockStyle)
				{
					control.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					if (control.Dock != dock)
					{
						control.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
				}
			}
		}

		/// 
		/// Provides controls with the ability to handle size changed
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		/// <param name="objNewSize">The control new size.</param>
		/// <param name="objOldSize">The control old size.</param>
		internal virtual void OnLayoutInternal(LayoutEventArgs objEventArgs, Size objNewSize, Size objOldSize)
		{
			DockStyle dockInternal = GetDockInternal();
			if (dockInternal != DockStyle.None && objEventArgs.ShouldUpdateSiblings)
			{
				Parent?.OnDockedChildResizeInternal(objEventArgs, this, objNewSize, objOldSize);
			}
			OnLayoutControls(objEventArgs, ref objNewSize, ref objOldSize);
		}

		/// 
		/// Layout the internal controls to reflect parent changes
		/// </summary>
		/// <param name="objEventArgs">The layout arguments.</param>
		/// <param name="objNewSize">The new parent size.</param>
		/// <param name="objOldSize">The old parent size.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
		{
			if (mobjControls == null || mobjControls.Count <= 0)
			{
				return;
			}
			int num = objNewSize.Width - objOldSize.Width;
			int num2 = objNewSize.Height - objOldSize.Height;
			foreach (Control mobjControl in mobjControls)
			{
				DockStyle dock = mobjControl.Dock;
				if (dock == DockStyle.Left || dock == DockStyle.Right)
				{
					if (dock == DockStyle.Right && num != 0)
					{
						mobjControl.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
						mobjControl.OnLocationChanged(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (num2 != 0)
					{
						mobjControl.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
						mobjControl.OnSizeChanged(EventArgs.Empty);
					}
					continue;
				}
				if (dock == DockStyle.Top || dock == DockStyle.Bottom)
				{
					if (dock == DockStyle.Bottom && num2 != 0)
					{
						mobjControl.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
						mobjControl.OnLocationChanged(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (num != 0)
					{
						mobjControl.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
						mobjControl.OnSizeChanged(EventArgs.Empty);
					}
					continue;
				}
				if (dock == DockStyle.Fill)
				{
					if (num != 0 || num2 != 0)
					{
						mobjControl.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
						mobjControl.OnSizeChanged(EventArgs.Empty);
					}
					continue;
				}
				int num3 = mobjControl.Left;
				int num4 = mobjControl.Top;
				int num5 = mobjControl.Height;
				int num6 = mobjControl.Width;
				AnchorStyles anchor = mobjControl.Anchor;
				bool flag = mobjControl.IsRightAnchored(anchor);
				bool flag2 = mobjControl.IsLeftAnchored(anchor);
				bool flag3 = mobjControl.IsTopAnchored(anchor);
				bool flag4 = mobjControl.IsBottomAnchored(anchor);
				bool flag5 = false;
				bool flag6 = false;
				if (num != 0)
				{
					if (flag && !flag2)
					{
						num3 += num;
						flag6 = true;
					}
					else if (flag && flag2)
					{
						num6 += num;
						flag5 = true;
					}
					else if (!flag && !flag2)
					{
						num3 += num / 2;
						flag6 = true;
					}
				}
				if (num2 != 0)
				{
					if (flag4 && !flag3)
					{
						num4 += num2;
						flag6 = true;
					}
					else if (flag4 && flag3)
					{
						num5 += num2;
						flag5 = true;
					}
					else if (!flag4 && !flag3)
					{
						num4 += num2 / 2;
						flag6 = true;
					}
				}
				if (flag6 || flag5)
				{
					mobjControl.UpdateBounds(num3, num4, num6, num5, num6, num5, objEventArgs.IsClientSource);
					if (flag6)
					{
						mobjControl.OnLocationChangedInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
					if (flag5)
					{
						mobjControl.OnResizeInternal(objEventArgs.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
					}
				}
			}
		}

		/// 
		/// Raises the <see cref="E:Resize" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnResize(EventArgs e)
		{
			ResizeHandler?.Invoke(this, EventArgs.Empty);
		}

		/// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnSizeChanged(EventArgs e)
		{
			OnResize(e);
			SizeChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Suspends the layout.
		/// </summary>
		public void SuspendLayout()
		{
			mintSuspendLayout++;
			if (mintSuspendLayout == 1)
			{
				ObservableSuspendLayoutHandler?.Invoke(this, EventArgs.Empty);
			}
		}

		/// 
		/// Terminates registered timers.
		/// </summary>
		internal void TerminateRegisteredTimers()
		{
			Timer[] registeredTimers = RegisteredTimers;
			if (registeredTimers != null)
			{
				Timer[] array = registeredTimers;
				foreach (Timer timer in array)
				{
					timer.Enabled = false;
				}
			}
			ControlCollection controls = Controls;
			if (controls.Count <= 0)
			{
				return;
			}
			foreach (Control item in controls)
			{
				item.TerminateRegisteredTimers();
			}
		}

		/// 
		/// Resumes the layout.
		/// </summary>
		public void ResumeLayout()
		{
			ResumeLayout(blnPerformLayout: true);
		}

		/// 
		/// Resumes the layout.
		/// </summary>
		public void ResumeLayout(LayoutEventArgs objEventArgs)
		{
			ResumeLayout(objEventArgs, blnPerformLayout: true);
		}

		/// 
		/// Resumes the layout.
		/// </summary>
		/// <param name="blnPerformLayout">if set to true</c> [BLN perform layout].</param>
		public void ResumeLayout(bool blnPerformLayout)
		{
			ResumeLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true), blnPerformLayout);
		}

		/// 
		/// Resumes the layout.
		/// </summary>
		/// <param name="blnPerformLayout">if set to true</c> [BLN perform layout].</param>
		public void ResumeLayout(LayoutEventArgs objEventArgs, bool blnPerformLayout)
		{
			if (mintSuspendLayout <= 0)
			{
				return;
			}
			mintSuspendLayout--;
			if (mintSuspendLayout == 0)
			{
				if (blnPerformLayout)
				{
					SetState(ControlState.LayoutIsDirty, blnValue: true);
					PerformLayout(objEventArgs);
				}
				else
				{
					Size size = Size;
					mintLayoutHeight = size.Height;
					mintLayoutWidth = size.Width;
				}
				ObservableResumeLayoutHandler?.Invoke(this, new ObservableResumeLayoutArgs(blnPerformLayout));
			}
		}

		/// 
		/// Invalidates the layout.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal void InvalidateLayout(LayoutEventArgs objEventArgs)
		{
			if (base.DesignMode || !RequiresLayout)
			{
				return;
			}
			SetState(ControlState.LayoutIsDirty, blnValue: true);
			if (GetTopLevel())
			{
				PerformLayout(objEventArgs);
				return;
			}
			Control parentInternal = ParentInternal;
			if (parentInternal == null)
			{
				return;
			}
			if (parentInternal.RequiresLayout)
			{
				Size preferredSize = parentInternal.PreferredSize;
				parentInternal.InvalidateLayout(objEventArgs);
				if (preferredSize != parentInternal.PreferredSize && !objEventArgs.IsClientSource)
				{
					parentInternal.UpdateParams(AttributeType.Layout);
				}
			}
			else
			{
				parentInternal.SetState(ControlState.LayoutIsDirty, blnValue: true);
				parentInternal.PerformLayout(objEventArgs);
			}
		}

		/// 
		/// Invalidates the parent layout.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected void InvalidateParentLayout(LayoutEventArgs objEventArgs)
		{
			ParentInternal?.InvalidateLayout(objEventArgs);
		}

		/// 
		/// WinForm complaint - No use.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void PerformLayout()
		{
			PerformLayout(blnForceLayout: false);
		}

		/// 
		/// WinForm complaint - No use.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void PerformLayout(LayoutEventArgs objEventArgs)
		{
			PerformLayout(blnForceLayout: false, objEventArgs);
		}

		/// 
		/// Performs the layout.
		/// </summary>
		/// <param name="blnForceLayout">if set to true</c> [BLN force layout].</param>
		protected internal virtual void PerformLayout(bool blnForceLayout)
		{
			PerformLayout(blnForceLayout, new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: true));
		}

		/// 
		/// Performs the layout.
		/// </summary>
		/// <param name="blnForceLayout">if set to true</c> [BLN force layout].</param>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		private void PerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
		{
			if (IsLayoutSuspended || !Created)
			{
				return;
			}
			foreach (Control control in Controls)
			{
				if (blnForceLayout || control.GetState(ControlState.LayoutIsDirty))
				{
					control.PerformLayout(blnForceLayout, objEventArgs);
				}
			}
			DoPerformLayout(blnForceLayout, objEventArgs);
		}

		/// 
		/// Does the perform layout.
		/// </summary>
		/// <param name="blnForceLayout">if set to true</c> [BLN force layout].</param>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.LayoutEventArgs" /> instance containing the event data.</param>
		private void DoPerformLayout(bool blnForceLayout, LayoutEventArgs objEventArgs)
		{
			if (IsLayoutSuspended || !RequiresLayout || (!blnForceLayout && !GetState(ControlState.LayoutIsDirty)))
			{
				return;
			}
			Size size = new Size(mintWidth, mintHeight);
			if (AutoSizeMode == AutoSizeMode.GrowAndShrink)
			{
				if (MinimumSize.Height > size.Height)
				{
					size.Height = MinimumSize.Height;
				}
				if (MinimumSize.Width > size.Width)
				{
					size.Width = MinimumSize.Width;
				}
			}
			else if (size == Size.Empty)
			{
				size = DefaultSize;
			}
			SetMinimumClientSize(size);
			SetState(ControlState.LayoutIsDirty, blnValue: false);
			Size preferredSize = GetPreferredSize(size);
			preferredSize = GetPreferredSizeByAutoSizeMode(this, size, preferredSize);
			if (SetPreferredSize(preferredSize))
			{
				if (!objEventArgs.IsClientSource)
				{
					UpdateParams(AttributeType.Layout);
				}
				if (AutoSize)
				{
					OnSizeChanged(objEventArgs);
				}
				OnLayoutInternal(objEventArgs);
			}
		}

		/// 
		/// Sets the minimum size of the client.
		/// </summary>
		/// <param name="objProposedSize">Proposed size.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void SetMinimumClientSize(Size objProposedSize)
		{
		}

		/// 
		/// Sets the size of the preferred.
		/// </summary>
		/// <param name="objPreferredSize">Size of the obj preferred.</param>
		/// Returns a flag if control should raise the resize event or do layout.</returns>
		[Browsable(false)]
		protected virtual bool SetPreferredSize(Size objPreferredSize)
		{
			if (mintPreferredHeight == -1 || mintPreferredWidth == -1)
			{
				mintPreferredWidth = objPreferredSize.Width;
				mintPreferredHeight = objPreferredSize.Height;
				return false;
			}
			if (mintPreferredHeight != objPreferredSize.Height || mintPreferredWidth != objPreferredSize.Width)
			{
				mintPreferredWidth = objPreferredSize.Width;
				mintPreferredHeight = objPreferredSize.Height;
				return true;
			}
			return false;
		}

		/// 
		/// Invokes the specified method.
		/// </summary>
		/// <param name="objMethod">method.</param>
		/// </returns>
		public object Invoke(Delegate objMethod)
		{
			return Invoke(objMethod, null);
		}

		/// 
		/// Invokes the specified method.
		/// </summary>
		/// <param name="objMethod">method.</param>
		/// <param name="objArgs">Arguments.</param>
		/// </returns>
		public object Invoke(Delegate objMethod, object[] arrArgs)
		{
			return objMethod?.DynamicInvoke(arrArgs);
		}

		/// 
		/// Shoulds the index of the serialize tab.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeTabIndex()
		{
			return mintTabIndex != -1;
		}

		/// 
		/// Shoulds the color of the serialize back.
		/// </summary>
		/// </returns>
		internal virtual bool ShouldSerializeBackColor()
		{
			return ContainsValue(BackColorProperty);
		}

		/// 
		/// Shoulds the color of the serialize fore.
		/// </summary>
		/// </returns>
		internal virtual bool ShouldSerializeForeColor()
		{
			return ContainsValue(ForeColorProperty);
		}

		/// 
		/// Get a flag indicating if should serialize the font.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeFont()
		{
			return ContainsValue(FontProperty);
		}

		/// 
		/// Shoulds the color of the serialize border.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderColor()
		{
			return DefaultBorderColor != BorderColor;
		}

		/// 
		/// Shoulds the serialize border style.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderStyle()
		{
			return BorderStyle != DefaultBorderStyle;
		}

		/// 
		/// Shoulds the width of the serialize border.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeBorderWidth()
		{
			return DefaultBorderWidth != BorderWidth;
		}

		/// 
		/// Shoulds the color of the serialize border.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeBorderColor(BorderColor objBorderColor)
		{
			return DefaultBorderColor != objBorderColor;
		}

		/// 
		/// Shoulds the serialize border style.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeBorderStyle(BorderStyle objBordeStyle)
		{
			return objBordeStyle != DefaultBorderStyle;
		}

		private bool ShouldSerializeAnchor()
		{
			return Anchor != (AnchorStyles.Left | AnchorStyles.Top);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeMaximumSize()
		{
			return DefaultMaximumSize != MaximumSize;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeMinimumSize()
		{
			return DefaultMinimumSize != MinimumSize;
		}

		private bool ShouldSerializeDock()
		{
			return Dock != DockStyle.None;
		}

		/// 
		/// Shoulds the render border.
		/// </summary>
		/// <param name="objBorderValue">The obj border value.</param>
		/// </returns>
		private bool ShouldRenderBorder(BorderValue objBorderValue)
		{
			return false || ShouldSerializeBorderColor(objBorderValue.Color) || ShouldSerializeBorderStyle(objBorderValue.Style) || ShouldSerializeBorderWidth(objBorderValue.Width);
		}

		/// 
		/// Shoulds the width of the serialize border.
		/// </summary>
		/// <param name="objBorderWidth">Width of the obj border.</param>
		/// </returns>
		private bool ShouldSerializeBorderWidth(BorderWidth objBorderWidth)
		{
			return DefaultBorderWidth != objBorderWidth;
		}

		/// 
		/// Shoulds the serialize text.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeText()
		{
			return !string.IsNullOrEmpty(Text);
		}

		/// 
		/// Shoulds the size of the serialize.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeSize()
		{
			return true;
		}

		/// 
		/// Shoulds the size of the serialize client.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeClientSize()
		{
			return true;
		}

		/// 
		/// Shoulds the serialize right to left.
		/// </summary>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal virtual bool ShouldSerializeRightToLeft()
		{
			return HasRightToLeft;
		}

		/// 
		/// Resets the right to left.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void ResetRightToLeft()
		{
			RightToLeft = RightToLeft.Inherit;
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is Control)
			{
				Control control = (Control)objValue;
				Controls.Add(control);
				control.BringToFront();
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// 
		/// Checks circular control reference.
		/// </summary>
		/// <param name="objBottom">The obj bottom.</param>
		/// <param name="objToFind">The obj to find.</param>
		/// <exception cref="T:System.ArgumentException">
		/// </exception>
		internal static void CheckParentingCycle(Control objBottom, Control objToFind)
		{
			Form form = null;
			Control control = null;
			for (Control control2 = objBottom; control2 != null; control2 = control2.ParentInternal)
			{
				control = control2;
				if (control2 == objToFind)
				{
					throw new ArgumentException(SR.GetString("CircularOwner"));
				}
			}
			if (control != null && control is Form)
			{
				Form form2 = (Form)control;
				for (Form form3 = form2; form3 != null; form3 = form3.OwnerInternal)
				{
					form = form3;
					if (form3 == objToFind)
					{
						throw new ArgumentException(SR.GetString("CircularOwner"));
					}
				}
			}
			if (form != null && form.ParentInternal != null)
			{
				CheckParentingCycle(form.ParentInternal, objToFind);
			}
		}

		/// 
		/// Assigns the parent.
		/// </summary>
		/// <param name="objParent">The obj parent of type Control.</param>
		internal virtual void AssignParent(Control objParent)
		{
			if (CanAccessProperties)
			{
				Control objOldParent = InternalParent as Control;
				bool flag = (InternalParent == null && objParent != null) || (InternalParent != null && objParent == null);
				InternalParent = objParent;
				OnParentChanged(EventArgs.Empty);
				if (IsResizedDueToParentAssignment(objOldParent, objParent))
				{
					OnResizeInternal(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
				}
				if (GetValue(BindingContextProperty) == null)
				{
					OnBindingContextChanged(EventArgs.Empty);
				}
				if (flag)
				{
					OnVisibleChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Determines whether is resized due to parent assignment.
		/// </summary>
		/// <param name="objOldParent">The obj old parent.</param>
		/// <param name="objNewParent">The obj new parent.</param>
		/// 
		///   true</c> if [is resized due to parent assignment] [the specified obj old parent]; otherwise, false</c>.
		/// </returns>
		private bool IsResizedDueToParentAssignment(Control objOldParent, Control objNewParent)
		{
			bool result = false;
			if (objNewParent != null)
			{
				bool flag = objOldParent == null || objOldParent.Width != objNewParent.Width;
				bool flag2 = objOldParent == null || objOldParent.Height != objNewParent.Height;
				AnchorStyles anchor = Anchor;
				DockStyle dock = Dock;
				result = (dock == DockStyle.Fill && (flag || flag2)) || (flag && ((IsRightAnchored(anchor) && IsLeftAnchored(anchor)) || dock == DockStyle.Top || dock == DockStyle.Bottom)) || (flag2 && ((IsTopAnchored(anchor) && IsBottomAnchored(anchor)) || dock == DockStyle.Left || dock == DockStyle.Right));
			}
			return result;
		}

		/// 
		/// Gets the first child control in tab order.
		/// </summary>
		/// <param name="blnForward">if set to true</c> [BLN forward].</param>
		/// </returns>
		internal virtual Control GetFirstChildControlInTabOrder(bool blnForward)
		{
			ControlCollection controls = Controls;
			Control control = null;
			if (controls != null)
			{
				if (blnForward)
				{
					for (int i = 0; i < controls.Count; i++)
					{
						if (control == null || control.TabIndex > controls[i].TabIndex)
						{
							control = controls[i];
						}
					}
					return control;
				}
				for (int num = controls.Count - 1; num >= 0; num--)
				{
					if (control == null || control.TabIndex < controls[num].TabIndex)
					{
						control = controls[num];
					}
				}
			}
			return control;
		}

		/// Retrieves the next control forward or back in the tab order of child controls.</summary>
		/// The next <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in the tab order.</returns>
		/// <param name="blnForward">true to search forward in the tab order; false to search backward. </param>
		/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to start the search with. </param>
		/// 2</filterpriority>
		public Control GetNextControl(Control objControl, bool blnForward)
		{
			if (!Contains(objControl))
			{
				objControl = this;
			}
			if (!blnForward)
			{
				if (objControl != this)
				{
					int num = objControl.mintTabIndex;
					bool flag = false;
					Control control = null;
					Control parent = objControl.Parent;
					int num2 = 0;
					ControlCollection controls = parent.Controls;
					if (controls != null)
					{
						num2 = controls.Count;
					}
					for (int num3 = num2 - 1; num3 >= 0; num3--)
					{
						if (controls[num3] != objControl)
						{
							if (controls[num3].mintTabIndex <= num && (control == null || control.mintTabIndex < controls[num3].mintTabIndex) && (controls[num3].mintTabIndex != num || flag))
							{
								control = controls[num3];
							}
						}
						else
						{
							flag = true;
						}
					}
					if (control == null)
					{
						if (parent == this)
						{
							return null;
						}
						return parent;
					}
					objControl = control;
				}
				ControlCollection controls2 = objControl.Controls;
				while (controls2 != null && controls2.Count > 0 && (objControl == this || !IsFocusManagingContainerControl(objControl)))
				{
					Control firstChildControlInTabOrder = objControl.GetFirstChildControlInTabOrder(blnForward: false);
					if (firstChildControlInTabOrder == null)
					{
						break;
					}
					objControl = firstChildControlInTabOrder;
					controls2 = objControl.Controls;
				}
			}
			else
			{
				ControlCollection controls3 = objControl.Controls;
				if (controls3 != null && controls3.Count > 0 && (objControl == this || !IsFocusManagingContainerControl(objControl)))
				{
					Control firstChildControlInTabOrder2 = objControl.GetFirstChildControlInTabOrder(blnForward: true);
					if (firstChildControlInTabOrder2 != null)
					{
						return firstChildControlInTabOrder2;
					}
				}
				while (objControl != this)
				{
					int tabIndex = objControl.TabIndex;
					bool flag2 = false;
					Control control2 = null;
					Control parent2 = objControl.Parent;
					int num4 = 0;
					ControlCollection controls4 = parent2.Controls;
					if (controls4 != null)
					{
						num4 = controls4.Count;
					}
					for (int i = 0; i < num4; i++)
					{
						if (controls4[i] != objControl)
						{
							if (controls4[i].TabIndex >= tabIndex && (control2 == null || control2.mintTabIndex > controls4[i].mintTabIndex) && (controls4[i].mintTabIndex != tabIndex || flag2))
							{
								control2 = controls4[i];
							}
						}
						else
						{
							flag2 = true;
						}
					}
					if (control2 != null)
					{
						return control2;
					}
					objControl = objControl.Parent;
				}
			}
			if (objControl != this)
			{
				return objControl;
			}
			return null;
		}

		/// 
		/// Gets the top level.
		/// </summary>
		/// </returns>
		protected bool GetTopLevel()
		{
			return GetState(ControlState.TopLevel);
		}

		/// 
		/// Sets the top level.
		/// </summary>
		/// <param name="blnValue">if set to true</c> [value].</param>
		protected void SetTopLevel(bool blnValue)
		{
			SetTopLevelInternal(blnValue);
		}

		/// 
		/// Sets the top level internal.
		/// </summary>
		/// <param name="blnValue">if set to true</c> [value].</param>
		internal void SetTopLevelInternal(bool blnValue)
		{
			if (GetTopLevel() != blnValue)
			{
				if (Parent != null)
				{
					throw new ArgumentException(SR.GetString("TopLevelParentedControl"), "value");
				}
				SetState(ControlState.TopLevel, blnValue);
				if (blnValue && Visible)
				{
					CreateControl();
				}
			}
		}

		/// 
		/// Checks if a control is a contains this control
		/// </summary>
		/// <param name="objDescendantControl">The obj descendant control.</param>
		/// 
		/// 	true</c> if the specified obj descendant control is descendant; otherwise, false</c>.
		/// </returns>
		internal bool IsDescendant(Control objDescendantControl)
		{
			for (Control control = objDescendantControl; control != null; control = control.ParentInternal)
			{
				if (control == this)
				{
					return true;
				}
			}
			return false;
		}

		/// 
		/// Retrieves a value indicating whether the specified control is a child of the control.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// 
		/// true if the specified control is a child of the control; otherwise, false.
		/// </returns>
		public bool Contains(Control objControl)
		{
			while (objControl != null)
			{
				objControl = objControl.Parent;
				if (objControl == null)
				{
					return false;
				}
				if (objControl == this)
				{
					return true;
				}
			}
			return false;
		}

		/// Forces the creation of the control, including the creation of the handle and any child controls.</summary>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void CreateControl()
		{
			CreateControl(blnIgnoreVisible: false);
		}

		/// 
		/// Execute the control creation methods
		/// </summary>
		/// <param name="blnIgnoreVisible"></param>
		internal void CreateControl(bool blnIgnoreVisible)
		{
			if (!((!Created && Visible) || blnIgnoreVisible))
			{
				return;
			}
			SetState(ControlState.Created, blnValue: true);
			bool flag = false;
			try
			{
				ControlCollection controlCollection = mobjControls;
				if (controlCollection != null)
				{
					Control[] array = new Control[controlCollection.Count];
					controlCollection.CopyTo(array, 0);
					Control[] array2 = array;
					foreach (Control control in array2)
					{
						control.CreateControl(blnIgnoreVisible);
					}
				}
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					SetState(ComponentState.Visible, blnValue: false);
				}
			}
			PerformLayout();
			OnCreateControl();
		}

		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnCreateControl()
		{
		}

		/// 
		/// Raises the <see cref="E:ParentBindingContextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnParentBindingContextChanged(EventArgs e)
		{
			if (GetValue(BindingContextProperty) == null)
			{
				OnBindingContextChanged(e);
			}
		}

		/// 
		/// Raises the <see cref="E:BindingContextChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBindingContextChanged(EventArgs e)
		{
			if (ContainsValue(DataBindingsProperty))
			{
				UpdateBindings();
			}
			BindingContextChangedHandler?.Invoke(this, e);
			if (mobjControls != null)
			{
				for (int i = 0; i < mobjControls.Count; i++)
				{
					mobjControls[i].OnParentBindingContextChanged(e);
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageLayoutChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackgroundImageLayoutChanged(EventArgs e)
		{
			BackgroundImageLayoutChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.AutoSizeChanged"></see> event. 
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnAutoSizeChanged(EventArgs e)
		{
			AutoSizeChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackColorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackColorChanged(EventArgs e)
		{
			BackColorChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BackgroundImageChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnBackgroundImageChanged(EventArgs e)
		{
			BackgroundImageChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.PaddingChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnPaddingChanged(EventArgs e)
		{
			PaddingChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HelpRequested"></see> event.</summary>
		/// <param name="objHelpEventArgs">A <see cref="T:Gizmox.WebGUI.Forms.HelpEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual void OnHelpRequested(HelpEventArgs objHelpEventArgs)
		{
			HelpEventHandler helpRequestedHandler = HelpRequestedHandler;
			if (helpRequestedHandler != null)
			{
				helpRequestedHandler(this, objHelpEventArgs);
				objHelpEventArgs.Handled = true;
			}
		}

		/// 
		/// Updates the bindings.
		/// </summary>
		private void UpdateBindings()
		{
			for (int i = 0; i < DataBindings.Count; i++)
			{
				BindingContext.UpdateBinding(BindingContext, DataBindings[i]);
			}
		}

		/// 
		/// Sets the bounds.
		/// </summary>
		/// <param name="intLeft">The int left.</param>
		/// <param name="intTop">The int top.</param>
		/// <param name="intWidth">Width of the int.</param>
		/// <param name="intHeight">Height of the int.</param>
		public void SetBounds(int intLeft, int intTop, int intWidth, int intHeight)
		{
			SetBounds(intLeft, intTop, intWidth, intHeight, BoundsSpecified.All);
		}

		/// 
		/// Sets the specified bounds of the control to the specified location and size.
		/// </summary>
		/// <param name="intLeft">The int left.</param>
		/// <param name="intTop">The int top.</param>
		/// <param name="intWidth">Width of the int layout.</param>
		/// <param name="intHeight">Height of the int layout.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
		{
			return SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource: false);
		}

		/// 
		/// Sets the specified bounds of the control to the specified location and size.
		/// </summary>
		/// <param name="intLeft">The int left.</param>
		/// <param name="intTop">The int top.</param>
		/// <param name="intWidth">Width of the int layout.</param>
		/// <param name="intHeight">Height of the int layout.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
		/// <param name="blnIsClientSource">if set to true</c> [BLN is client source].</param>
		/// </returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public virtual bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
		{
			if ((enmSpecified & BoundsSpecified.X) == 0)
			{
				intLeft = mintLeft;
			}
			if ((enmSpecified & BoundsSpecified.Y) == 0)
			{
				intTop = mintTop;
			}
			if ((enmSpecified & BoundsSpecified.Width) == 0)
			{
				intWidth = mintWidth;
			}
			if ((enmSpecified & BoundsSpecified.Height) == 0)
			{
				intHeight = mintHeight;
			}
			if (mintLeft != intLeft || mintTop != intTop || mintWidth != intWidth || mintHeight != intHeight)
			{
				return SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
			}
			return false;
		}

		/// 
		/// Sets the bounds.
		/// </summary>
		/// <param name="objBounds">The obj bounds.</param>
		/// <param name="enmSpecified">The specified.</param>
		void IArrangedElement.SetBounds(Rectangle objBounds, BoundsSpecified enmSpecified)
		{
			ISite site = Site;
			IComponentChangeService componentChangeService = null;
			PropertyDescriptor propertyDescriptor = null;
			PropertyDescriptor propertyDescriptor2 = null;
			bool flag = false;
			bool flag2 = false;
			if (site != null && site.DesignMode)
			{
				componentChangeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));
				if (componentChangeService != null)
				{
					propertyDescriptor = TypeDescriptor.GetProperties(this)[PropertyNames.Size];
					propertyDescriptor2 = TypeDescriptor.GetProperties(this)[PropertyNames.Location];
					try
					{
						if (propertyDescriptor != null && !propertyDescriptor.IsReadOnly && (objBounds.Width != Width || objBounds.Height != Height))
						{
							if (!(site is INestedSite))
							{
								componentChangeService.OnComponentChanging(this, propertyDescriptor);
							}
							flag = true;
						}
						if (propertyDescriptor2 != null && !propertyDescriptor2.IsReadOnly && (objBounds.X != mintLeft || objBounds.Y != mintTop))
						{
							if (!(site is INestedSite))
							{
								componentChangeService.OnComponentChanging(this, propertyDescriptor2);
							}
							flag2 = true;
						}
					}
					catch (InvalidOperationException)
					{
					}
				}
			}
			SetBoundsCore(objBounds.X, objBounds.Y, objBounds.Width, objBounds.Height, enmSpecified);
			if (site == null || componentChangeService == null)
			{
				return;
			}
			try
			{
				if (flag)
				{
					componentChangeService.OnComponentChanged(this, propertyDescriptor, null, null);
				}
				if (flag2)
				{
					componentChangeService.OnComponentChanged(this, propertyDescriptor2, null, null);
				}
			}
			catch (InvalidOperationException)
			{
			}
		}

		/// Performs the work of setting the specified bounds of this control.</summary>
		/// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control. </param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. </param>
		/// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control. </param>
		/// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control. </param>
		/// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified)
		{
			return SetBoundsCore(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource: false);
		}

		/// 
		/// Performs the work of setting the specified bounds of this control.
		/// </summary>
		/// <param name="intLeft">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Left"></see> property value of the control.</param>
		/// <param name="intTop">The new <see cref="P:Gizmox.WebGUI.Forms.Control.Top"></see> property value of the control.</param>
		/// <param name="intWidth">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutWidth"></see> property value of the control.</param>
		/// <param name="intHeight">The new <see cref="P:System.Gizmox.Forms.Control.intLayoutHeight"></see> property value of the control.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values.</param>
		/// <param name="blnIsClientSource">if set to true</c> [BLN is client source].</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual bool SetBoundsCore(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
		{
			if (mintLeft != intLeft || mintTop != intTop || mintWidth != intWidth || mintHeight != intHeight)
			{
				Rectangle rectangle = ApplyBoundsConstraints(intLeft, intTop, intWidth, intHeight);
				intWidth = rectangle.Width;
				intHeight = rectangle.Height;
				intLeft = rectangle.X;
				intTop = rectangle.Y;
				return UpdateBounds(intLeft, intTop, intWidth, intHeight, blnIsClientSource);
			}
			return false;
		}

		/// 
		/// Applies the bounds constraints.
		/// </summary>
		/// <param name="intSuggestedX">The suggested X.</param>
		/// <param name="intSuggestedY">The suggested Y.</param>
		/// <param name="intProposedWidth">Width of the proposed.</param>
		/// <param name="intProposedHeight">Height of the proposed.</param>
		/// </returns>
		internal virtual Rectangle ApplyBoundsConstraints(int intSuggestedX, int intSuggestedY, int intProposedWidth, int intProposedHeight)
		{
			if (!(MaximumSize != Size.Empty) && !(MinimumSize != Size.Empty))
			{
				return new Rectangle(intSuggestedX, intSuggestedY, intProposedWidth, intProposedHeight);
			}
			Size objB = LayoutUtils.ConvertZeroToUnbounded(MaximumSize);
			Rectangle result = new Rectangle(intSuggestedX, intSuggestedY, 0, 0);
			result.Size = LayoutUtils.IntersectSizes(new Size(intProposedWidth, intProposedHeight), objB);
			result.Size = LayoutUtils.UnionSizes(result.Size, MinimumSize);
			return result;
		}

		/// Updates the bounds of the control with the specified size and location.</summary>
		/// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
		/// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
		/// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
		/// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight)
		{
			return UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, blnIsClientSource: false);
		}

		/// 
		/// Updates the bounds of the control with the specified size and location.
		/// </summary>
		/// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control.</param>
		/// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control.</param>
		/// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control.</param>
		/// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control.</param>
		/// <param name="blnIsClientSource">if set to true</c> [BLN is client source].</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight, bool blnIsClientSource)
		{
			return UpdateBounds(intLeft, intTop, intWidth, intHeight, intWidth, intHeight, blnIsClientSource);
		}

		/// Updates the bounds of the control with the specified size, location, and client size.</summary>
		/// <param name="intTop">The <see cref="P:System.Drawing.Point.Y"></see> coordinate of the control. </param>
		/// <param name="intWidth">The <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
		/// <param name="intClientHeight">The client <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
		/// <param name="intHeight">The <see cref="P:System.Drawing.Size.Height"></see> of the control. </param>
		/// <param name="intClientWidth">The client <see cref="P:System.Drawing.Size.Width"></see> of the control. </param>
		/// <param name="intLeft">The <see cref="P:System.Drawing.Point.X"></see> coordinate of the control. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected internal bool UpdateBounds(int intLeft, int intTop, int intWidth, int intHeight, int intClientWidth, int intClientHeight, bool blnIsClientSource)
		{
			bool flag = mintLeft != intLeft || mintTop != intTop;
			bool flag2 = mintWidth != intWidth || mintHeight != intHeight;
			if (flag2 || flag)
			{
				mintLeft = intLeft;
				mintTop = intTop;
				mintHeight = intHeight;
				mintWidth = intWidth;
				if (flag)
				{
					OnLocationChanged(new LayoutEventArgs(blnIsClientSource, blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
				}
				if (flag2)
				{
					OnSizeChanged(EventArgs.Empty);
				}
				if (!blnIsClientSource)
				{
					UpdateParams(AttributeType.Layout);
				}
				return true;
			}
			return false;
		}
	}
}
