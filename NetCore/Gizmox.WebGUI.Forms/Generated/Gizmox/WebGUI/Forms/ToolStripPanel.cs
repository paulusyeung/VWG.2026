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
	/// Creates a container within which other controls can share horizontal or vertical space.</summary>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[MetadataTag("TSPN")]
	[Skin(typeof(ToolStripPanelSkin))]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripPanel : ContainerControl, IArrangedElement, IComponent, IDisposable
	{
		/// Represents all the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects in a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
		[Serializable]
		[ComVisible(false)]
		[ListBindable(false)]
		public class ToolStripPanelRowCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
		{
			private ToolStripPanel mobjOwner;

			bool IList.IsFixedSize => base.InnerList.IsFixedSize;

			bool IList.IsReadOnly => base.InnerList.IsReadOnly;

			object IList.this[int index]
			{
				get
				{
					return base.InnerList[index];
				}
				set
				{
					throw new NotSupportedException(SR.GetString("ToolStripCollectionMustInsertAndRemove"));
				}
			}

			/// Gets a particular <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> as specified by the index parameter.</returns>
			/// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> within the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			public new virtual ToolStripPanelRow this[int index] => (ToolStripPanelRow)base.InnerList[index];

			/// Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class with the specified number of rows in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
			/// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			/// <param name="value">The number of rows in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			public ToolStripPanelRowCollection(ToolStripPanel owner, ToolStripPanelRow[] value)
			{
				mobjOwner = owner;
				AddRange(value);
			}

			/// Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> class in the specified <see cref="T:System.Windows.Forms.ToolStripPanel"></see>. </summary>
			/// <param name="owner">The <see cref="T:System.Windows.Forms.ToolStripPanel"></see> that holds this <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			public ToolStripPanelRowCollection(ToolStripPanel owner)
			{
				mobjOwner = owner;
			}

			/// Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// The position of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</returns>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public int Add(ToolStripPanelRow value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				int num = base.InnerList.Add(value);
				OnAdd(value, num);
				return num;
			}

			/// Adds an array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
			/// <param name="value">An array of <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public void AddRange(ToolStripPanelRow[] value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				ToolStripPanel toolStripPanel = mobjOwner;
				toolStripPanel?.SuspendLayout();
				try
				{
					for (int i = 0; i < value.Length; i++)
					{
						Add(value[i]);
					}
				}
				finally
				{
					toolStripPanel?.ResumeLayout();
				}
			}

			/// Adds the specified <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to a <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to add to the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public void AddRange(ToolStripPanelRowCollection value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				ToolStripPanel toolStripPanel = mobjOwner;
				toolStripPanel?.SuspendLayout();
				try
				{
					int count = value.Count;
					for (int i = 0; i < count; i++)
					{
						Add(value[i]);
					}
				}
				finally
				{
					toolStripPanel?.ResumeLayout();
				}
			}

			/// Removes all <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> objects from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			public virtual void Clear()
			{
				if (mobjOwner != null)
				{
					mobjOwner.SuspendLayout();
				}
				try
				{
					while (Count != 0)
					{
						RemoveAt(Count - 1);
					}
				}
				finally
				{
					if (mobjOwner != null)
					{
						mobjOwner.ResumeLayout();
					}
				}
			}

			/// Determines whether the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// true if the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> is in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>; otherwise, false.</returns>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to search for in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</param>
			public bool Contains(ToolStripPanelRow value)
			{
				return base.InnerList.Contains(value);
			}

			/// Copies the entire <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> into an existing array at a specified location within the array.</summary>
			/// <param name="array">An <see cref="T:System.Array"></see> representing the array to copy the contents of the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
			/// <param name="index">The location within the destination array to copy the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> to.</param>
			public void CopyTo(ToolStripPanelRow[] array, int index)
			{
				base.InnerList.CopyTo(array, index);
			}

			/// Gets the index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// The index of the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</returns>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to return the index of.</param>
			public int IndexOf(ToolStripPanelRow value)
			{
				return base.InnerList.IndexOf(value);
			}

			/// Inserts the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified location in the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to insert.</param>
			/// <param name="index">The zero-based index at which to insert the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>.</param>
			/// <exception cref="T:System.ArgumentNullException">value is null.</exception>
			public void Insert(int index, ToolStripPanelRow value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				base.InnerList.Insert(index, value);
				OnAdd(value, index);
			}

			/// Removes the specified <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// <param name="value">The <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
			public void Remove(ToolStripPanelRow value)
			{
				base.InnerList.Remove(value);
				OnAfterRemove(value);
			}

			/// Removes the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> at the specified index from the <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see>.</summary>
			/// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see> to remove.</param>
			public void RemoveAt(int index)
			{
				ToolStripPanelRow row = null;
				if (index < Count && index >= 0)
				{
					row = (ToolStripPanelRow)base.InnerList[index];
				}
				base.InnerList.RemoveAt(index);
				OnAfterRemove(row);
			}

			int IList.Add(object value)
			{
				return Add(value as ToolStripPanelRow);
			}

			void IList.Clear()
			{
				Clear();
			}

			bool IList.Contains(object value)
			{
				return base.InnerList.Contains(value);
			}

			int IList.IndexOf(object value)
			{
				return IndexOf(value as ToolStripPanelRow);
			}

			void IList.Insert(int index, object value)
			{
				Insert(index, value as ToolStripPanelRow);
			}

			void IList.Remove(object value)
			{
				Remove(value as ToolStripPanelRow);
			}

			void IList.RemoveAt(int index)
			{
				RemoveAt(index);
			}

			private void OnAdd(ToolStripPanelRow value, int index)
			{
				if (mobjOwner != null)
				{
					mobjOwner.Update();
				}
			}

			private void OnAfterRemove(ToolStripPanelRow row)
			{
			}
		}

		private static readonly SerializableProperty mobjToolStripPanelRowCollectionProperty = SerializableProperty.Register("mobjToolStripPanelRowCollection", typeof(ToolStripPanelRowCollection), typeof(ToolStripPanel));

		private static readonly SerializableProperty mobjRowMarginProperty = SerializableProperty.Register("mobjRowMargin", typeof(Padding), typeof(ToolStripPanel));

		private static readonly SerializableProperty menmOrientationProperty = SerializableProperty.Register("menmOrientation", typeof(Orientation), typeof(ToolStripPanel));

		private static readonly SerializableProperty mblnLockedProperty = SerializableProperty.Register("mblnLocked", typeof(bool), typeof(ToolStripPanel));

		private static readonly SerializableProperty mobjOwnerToolStripContainerProperty = SerializableProperty.Register("mobjOwnerToolStripContainer", typeof(ToolStripContainer), typeof(ToolStripPanel));

		private ToolStripPanelRowCollection mobjToolStripPanelRowCollection
		{
			get
			{
				return GetValue(mobjToolStripPanelRowCollectionProperty, null);
			}
			set
			{
				SetValue(mobjToolStripPanelRowCollectionProperty, value);
			}
		}

		private Padding mobjRowMargin
		{
			get
			{
				return GetValue(mobjRowMarginProperty);
			}
			set
			{
				SetValue(mobjRowMarginProperty, value);
			}
		}

		private Orientation menmOrientation
		{
			get
			{
				return GetValue(menmOrientationProperty);
			}
			set
			{
				SetValue(menmOrientationProperty, value);
			}
		}

		private bool mblnLocked
		{
			get
			{
				return GetValue(mblnLockedProperty);
			}
			set
			{
				SetValue(mblnLockedProperty, value);
			}
		}

		private ToolStripContainer mobjOwnerToolStripContainer
		{
			get
			{
				return GetValue(mobjOwnerToolStripContainerProperty, null);
			}
			set
			{
				SetValue(mobjOwnerToolStripContainerProperty, value);
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
				base.AllowDrop = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override bool AutoScroll
		{
			get
			{
				return base.AutoScroll;
			}
			set
			{
				base.AutoScroll = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMargin
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMinSize
		{
			get
			{
				return Size.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically adjusts its size when the form is resized.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> automatically resizes; otherwise, false. The default is true.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		/// </value>
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
				if (value == DockStyle.Left || value == DockStyle.Right)
				{
					Orientation = Orientation.Vertical;
				}
				else
				{
					Orientation = Orientation.Horizontal;
				}
			}
		}

		/// 
		/// Gets the layout engine.
		/// </summary>
		/// The layout engine.</value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual LayoutEngine LayoutEngine => null;

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized.</summary>
		/// true if the <see cref="T:System.Windows.Forms.ToolStripPanel"></see> can be moved or resized; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool Locked
		{
			get
			{
				return mblnLocked;
			}
			set
			{
				if (mblnLocked != value)
				{
					mblnLocked = value;
				}
			}
		}

		/// Gets or sets a value indicating the horizontal or vertical orientation of the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
		/// One of the <see cref="T:System.Windows.Forms.Orientation"></see> values.</returns>
		public Orientation Orientation
		{
			get
			{
				return menmOrientation;
			}
			set
			{
				if (menmOrientation != value)
				{
					menmOrientation = value;
					mobjRowMargin = LayoutUtils.FlipPadding(mobjRowMargin);
				}
			}
		}

		/// Gets or sets a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> used to customize the appearance of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> that handles painting.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderer Renderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// Gets or sets the painting styles to be applied to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderMode"></see> values.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripRenderMode RenderMode
		{
			get
			{
				return ToolStripRenderMode.Custom;
			}
			set
			{
			}
		}

		/// Gets or sets the spacing, in pixels, between the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s and the <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.Padding"></see> value representing the spacing, in pixels.</returns>
		public Padding RowMargin
		{
			get
			{
				return mobjRowMargin;
			}
			set
			{
				mobjRowMargin = value;
			}
		}

		/// 
		/// Gets the rows internal.
		/// </summary>
		/// The rows internal.</value>
		[Browsable(false)]
		[SRDescription("ToolStripPanelRowsDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		internal ToolStripPanelRowCollection RowsInternal
		{
			get
			{
				if (mobjToolStripPanelRowCollection == null)
				{
					mobjToolStripPanelRowCollection = new ToolStripPanelRowCollection(this);
				}
				return mobjToolStripPanelRowCollection;
			}
		}

		/// Gets the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Windows.Forms.ToolStripPanel.ToolStripPanelRowCollection"></see> representing the <see cref="T:System.Windows.Forms.ToolStripPanelRow"></see>s in this <see cref="T:System.Windows.Forms.ToolStripPanel"></see>.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ToolStripPanelRowsDescr")]
		[Browsable(false)]
		public ToolStripPanelRow[] Rows
		{
			get
			{
				ToolStripPanelRow[] array = new ToolStripPanelRow[RowsInternal.Count];
				RowsInternal.CopyTo(array, 0);
				return array;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// An <see cref="T:System.Int32"></see> representing the tab index.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// true if enabled; otherwise, false.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// This property is not relevant to this class.</summary>
		/// A <see cref="T:System.String"></see> representing the display text.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// 
		/// Gets the children.
		/// </summary>
		/// The children.</value>
		ArrangedElementCollection IArrangedElement.Children => RowsInternal;

		/// Occurs when the value of the <see cref="P:System.Windows.Forms.ToolStripPanel.AutoSize"></see> property changes. </summary>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public new event EventHandler AutoSizeChanged
		{
			add
			{
				base.AutoSizeChanged += value;
			}
			remove
			{
				base.AutoSizeChanged -= value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripPanel.Renderer"></see> property changes.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler RendererChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabIndexChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public event EventHandler TabStopChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		/// This event is not relevant for this class.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChanged
		{
			add
			{
				base.TextChanged += value;
			}
			remove
			{
				base.TextChanged -= value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> class. </summary>
		public ToolStripPanel()
		{
			mobjRowMargin = new Padding(3, 0, 0, 0);
			SuspendLayout();
			AutoSize = true;
			MinimumSize = Size.Empty;
			mblnLocked = false;
			TabStop = false;
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, blnValue: true);
			SetStyle(ControlStyles.Selectable, blnValue: false);
			ResumeLayout(blnPerformLayout: true);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel" /> class.
		/// </summary>
		/// <param name="objOwnerToolStripContainer">The owner tool strip container.</param>
		internal ToolStripPanel(ToolStripContainer objOwnerToolStripContainer)
			: this()
		{
			mobjOwnerToolStripContainer = objOwnerToolStripContainer;
		}

		/// Begins the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void BeginInit()
		{
		}

		/// Ends the initialization of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public void EndInit()
		{
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary> 
		/// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param>
		public void Join(ToolStrip toolStripToDrag)
		{
			Join(toolStripToDrag, Point.Empty);
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> in the specified row.</summary> 
		/// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
		/// <param name="row">An <see cref="T:System.Int32"></see> representing the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> to which the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> is added.</param> 
		/// <exception cref="T:System.ArgumentOutOfRangeException">The row parameter is less than zero (0).</exception>
		public void Join(ToolStrip toolStripToDrag, int row)
		{
			if (row < 0)
			{
				throw new ArgumentOutOfRangeException("row", SR.GetString("IndexOutOfRange", row.ToString(CultureInfo.CurrentCulture)));
			}
			Join(toolStripToDrag, Point.Empty);
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified coordinates.</summary> 
		/// <param name="y">The vertical client coordinate, in pixels.</param> 
		/// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
		/// <param name="x">The horizontal client coordinate, in pixels.</param>
		public void Join(ToolStrip toolStripToDrag, int x, int y)
		{
			Join(toolStripToDrag, new Point(x, y));
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to a <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> at the specified location.</summary> 
		/// <param name="toolStripToDrag">The <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</param> 
		/// <param name="location">A <see cref="T:System.Drawing.Point"></see> value representing the x- and y-client coordinates, in pixels, of the new location for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</param>
		public void Join(ToolStrip toolStripToDrag, Point location)
		{
			if (toolStripToDrag == null)
			{
				throw new ArgumentNullException("toolStripToDrag");
			}
			toolStripToDrag.ParentInternal = this;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripPanel.RendererChanged"></see> event.</summary> 
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual void OnRendererChanged(EventArgs e)
		{
		}

		/// Retrieves the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> given a point within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see> client area.</summary> 
		/// The <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> that contains the raftingContainerPoint, or null if no such <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see> exists.</returns> 
		/// <param name="clientLocation">A <see cref="T:System.Drawing.Point"></see> used as a reference to find the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanelRow"></see>.</param>
		public ToolStripPanelRow PointToRow(Point clientLocation)
		{
			foreach (ToolStripPanelRow item in RowsInternal)
			{
				Rectangle rectangle = LayoutUtils.InflateRect(item.Bounds, item.Margin);
				if (ParentInternal != null)
				{
					if (Orientation == Orientation.Horizontal && rectangle.Width == 0)
					{
						rectangle.Width = ParentInternal.DisplayRectangle.Width;
					}
					else if (Orientation == Orientation.Vertical && rectangle.Height == 0)
					{
						rectangle.Height = ParentInternal.DisplayRectangle.Height;
					}
				}
				if (rectangle.Contains(clientLocation))
				{
					return item;
				}
			}
			return null;
		}
	}
}
