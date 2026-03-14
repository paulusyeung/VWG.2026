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
	/// Provides focus management functionality for controls that can function as a container for other controls.
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[Skin(typeof(ContainerControlSkin))]
	public class ContainerControl : ScrollableControl, IContainerControl
	{
		/// 
		/// Provides a property reference to AutoValidate property.
		/// </summary>
		private static SerializableProperty AutoValidateProperty = SerializableProperty.Register("AutoValidate", typeof(AutoValidate), typeof(ContainerControl), new SerializablePropertyMetadata(AutoValidate.Inherit));

		/// 
		/// Provides a property reference to UnvalidatedControl property.
		/// </summary>
		private static SerializableProperty UnvalidatedControlProperty = SerializableProperty.Register("UnvalidatedControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to FocusedControl property.
		/// </summary>
		private static SerializableProperty FocusedControlProperty = SerializableProperty.Register("FocusedControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ActiveControl property.
		/// </summary>
		private static SerializableProperty ActiveControlProperty = SerializableProperty.Register("ActiveControl", typeof(Control), typeof(ContainerControl), new SerializablePropertyMetadata(null));

		/// 
		/// The AutoValidateChanged event registration.
		/// </summary>
		private static readonly SerializableEvent AutoValidateChangedEvent;

		private static readonly int mintStateParentChanged;

		private static readonly int mintStateProcessingMnemonic;

		private static readonly int mintStateScalingChild;

		private static readonly int mintStateScalingNeededOnLayout;

		private static readonly int mintStateValidating;

		/// 
		/// Gets the state of the validation.
		/// </summary>
		/// The state of the validation.</value>
		private SerializableBitVector32 mobjValidationState = default(SerializableBitVector32);

		/// 
		/// Gets the hanlder for the AutoValidateChanged event.
		/// </summary>
		private EventHandler AutoValidateChangedHandler => (EventHandler)GetHandler(AutoValidateChanged);

		/// 
		/// Gets the inner most focused container control.
		/// </summary>
		/// The inner most focused container control.</value>
		internal ContainerControl InnerMostFocusedContainerControl
		{
			get
			{
				ContainerControl containerControl = this;
				while (containerControl != containerControl.FocusedControlInternal && containerControl.FocusedControlInternal is ContainerControl)
				{
					containerControl = (ContainerControl)containerControl.FocusedControlInternal;
				}
				return containerControl;
			}
		}

		/// Gets or sets the active control on the container control.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that is currently active on the <see cref="T:Gizmox.WebGUI.Forms.ContainerControl"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> assigned could not be activated. </exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ContainerControlActiveControlDescr")]
		[Browsable(false)]
		[SRCategory("CatBehavior")]
		public Control ActiveControl
		{
			get
			{
				return ActiveControlInternal;
			}
			set
			{
				SetActiveControl(value);
			}
		}

		/// Gets or sets the dimensions that the control was designed to.</summary>
		/// A <see cref="T:System.Drawing.SizeF"></see> containing the dots per inch (DPI) or <see cref="T:System.Drawing.Font"></see> size that the control was designed to.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The width or height of the <see cref="T:System.Drawing.SizeF"></see> value is less than 0 when setting this value.</exception>
		[Obsolete("Not implemented by design.")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Localizable(true)]
		[SRCategory("CatLayout")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SizeF AutoScaleDimensions
		{
			get
			{
				return SizeF.Empty;
			}
			set
			{
			}
		}

		/// Gets or sets the automatic scaling mode of the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> that represents the current scaling mode. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoScaleMode.None"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">An <see cref="T:Gizmox.WebGUI.Forms.AutoScaleMode"></see> value that is not valid was used to set this property.</exception>
		[Obsolete("Not implemented by design.")]
		[SRCategory("CatLayout")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[SRDescription("ContainerControlAutoScaleModeDescr")]
		public AutoScaleMode AutoScaleMode
		{
			get
			{
				return AutoScaleMode.None;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the active control reference.
		/// </summary>
		/// The active control reference.</value>
		private Control ActiveControlInternal
		{
			get
			{
				return GetValue(ActiveControlProperty);
			}
			set
			{
				SetValue(ActiveControlProperty, value);
			}
		}

		/// 
		/// Gets or sets the focused control reference.
		/// </summary>
		/// The focused control reference.</value>
		private Control FocusedControlInternal
		{
			get
			{
				return GetValue(FocusedControlProperty);
			}
			set
			{
				SetValue(FocusedControlProperty, value);
			}
		}

		/// 
		/// Gets or sets the unvalidated control reference.
		/// </summary>
		/// The unvalidated control reference.</value>
		private Control UnvalidatedControlInternal
		{
			get
			{
				return GetValue(UnvalidatedControlProperty);
			}
			set
			{
				SetValue(UnvalidatedControlProperty, value);
			}
		}

		/// Gets or sets a value that indicates whether controls in this container will be automatically validated when the focus changes.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> enumerated value that indicates whether contained controls are implicitly validated on focus change. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoValidate.Inherit"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A <see cref="T:Gizmox.WebGUI.Forms.AutoValidate"></see> value that is not valid was used to set this property.</exception>
		/// 2</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[SRDescription("ContainerControlAutoValidate")]
		[SRCategory("CatBehavior")]
		[AmbientValue(-1)]
		public virtual AutoValidate AutoValidate
		{
			get
			{
				AutoValidate value = GetValue(AutoValidateProperty);
				if (value == AutoValidate.Inherit)
				{
					return Control.GetAutoValidateForControl(this);
				}
				return value;
			}
			set
			{
				switch (value)
				{
				case AutoValidate.Inherit:
				case AutoValidate.Disable:
				case AutoValidate.EnablePreventFocusChange:
				case AutoValidate.EnableAllowFocusChange:
					if (SetValue(AutoValidateProperty, value))
					{
						OnAutoValidateChanged(EventArgs.Empty);
					}
					break;
				default:
					throw new InvalidEnumArgumentException("AutoValidate", (int)value, typeof(AutoValidate));
				}
			}
		}

		/// 
		/// Gets the inner most active container control.
		/// </summary>
		/// The inner most active container control.</value>
		internal ContainerControl InnerMostActiveContainerControl
		{
			get
			{
				ContainerControl containerControl = this;
				while (containerControl != containerControl.ActiveControl && containerControl.ActiveControl is ContainerControl)
				{
					containerControl = (ContainerControl)containerControl.ActiveControl;
				}
				return containerControl;
			}
		}

		/// 
		/// Gets the parent form.
		/// </summary>
		/// The parent form.</value>
		[SRCategory("CatAppearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("ContainerControlParentFormDescr")]
		[Browsable(false)]
		public Form ParentForm => ParentFormInternal;

		/// 
		/// Gets the parent form internal.
		/// </summary>
		/// The parent form internal.</value>
		internal Form ParentFormInternal
		{
			get
			{
				if (ParentInternal != null)
				{
					return ParentInternal.FindFormInternal();
				}
				if (this is Form)
				{
					return null;
				}
				return FindFormInternal();
			}
		}

		/// 
		/// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
		/// </summary>
		/// </value>
		/// The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
		[SRDescription("ContainerControlBindingContextDescr")]
		[Browsable(false)]
		public override BindingContext BindingContext
		{
			get
			{
				BindingContext bindingContext = base.BindingContext;
				if (bindingContext == null)
				{
					bindingContext = (BindingContext = new BindingContext());
				}
				return bindingContext;
			}
			set
			{
				base.BindingContext = value;
			}
		}

		/// 
		/// Gets a value indicating whether [support focus events].
		/// </summary>
		/// true</c> if [supports focus events]; otherwise, false</c>.</value>
		protected internal override bool SupportsFocusEvents => false;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ContainerControl.AutoValidate"></see> property changes.</summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[SRDescription("ContainerControlOnAutoValidateChangedDescr")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AutoValidateChanged
		{
			add
			{
				AddHandler(AutoValidateChangedEvent, value);
			}
			remove
			{
				RemoveHandler(AutoValidateChangedEvent, value);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ContainerControl.AutoValidateChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnAutoValidateChanged(EventArgs e)
		{
			AutoValidateChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			OnBindingContextChanged(EventArgs.Empty);
		}

		/// 
		/// Handles validation on enter.
		/// </summary>
		/// <param name="objEnterControl">The enter control.</param>
		private void EnterValidation(Control objEnterControl)
		{
			Control unvalidatedControlInternal = UnvalidatedControlInternal;
			if (objEnterControl == null || !objEnterControl.CausesValidation || unvalidatedControlInternal == null)
			{
				return;
			}
			AutoValidate autoValidateForControl = Control.GetAutoValidateForControl(unvalidatedControlInternal);
			if (autoValidateForControl != AutoValidate.Disable)
			{
				Control control = objEnterControl;
				while (control != null && !control.IsDescendant(unvalidatedControlInternal))
				{
					control = control.ParentInternal;
				}
				bool blnPreventFocusChangeOnError = autoValidateForControl == AutoValidate.EnablePreventFocusChange;
				ValidateThroughAncestor(control, blnPreventFocusChangeOnError);
			}
		}

		/// 
		/// Resets the validation flag.
		/// </summary>
		private void ResetValidationFlag()
		{
			ControlCollection controls = base.Controls;
			int count = controls.Count;
			for (int i = 0; i < count; i++)
			{
				controls[i].ValidationCancelled = false;
			}
		}

		/// 
		/// Resets the active and focused controls recursive.
		/// </summary>
		internal void ResetActiveAndFocusedControlsRecursive()
		{
			Control activeControlInternal = ActiveControlInternal;
			if (activeControlInternal is ContainerControl && activeControlInternal != this)
			{
				((ContainerControl)activeControlInternal).ResetActiveAndFocusedControlsRecursive();
			}
			ActiveControlInternal = null;
			FocusedControlInternal = null;
		}

		/// 
		/// Ensures the unvalidated control.
		/// </summary>
		/// <param name="objCandidate">The candidate.</param>
		private void EnsureUnvalidatedControl(Control objCandidate)
		{
			if (!mobjValidationState[mintStateValidating] && UnvalidatedControlInternal == null && objCandidate != null && objCandidate.ShouldAutoValidate)
			{
				UnvalidatedControlInternal = objCandidate;
			}
		}

		/// Causes all of the child controls within a control that support validation to validate their data. </summary>
		/// true if all of the children validated successfully; otherwise, false. </returns>
		/// <param name="validationConstraints">Tells <see cref="M:Gizmox.WebGUI.Forms.ContainerControl.ValidateChildren(Gizmox.WebGUI.Forms.ValidationConstraints)"></see> how deeply to descend the control hierarchy when validating the control's children.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public virtual bool ValidateChildren(ValidationConstraints validationConstraints)
		{
			if ((validationConstraints < ValidationConstraints.None) || validationConstraints > (ValidationConstraints.Enabled | ValidationConstraints.ImmediateChildren | ValidationConstraints.Selectable | ValidationConstraints.TabStop | ValidationConstraints.Visible))
			{
				throw new InvalidEnumArgumentException("validationConstraints", (int)validationConstraints, typeof(ValidationConstraints));
			}
			return !PerformContainerValidation(validationConstraints);
		}

		/// 
		/// Validates this instance.
		/// </summary>
		/// </returns>
		public bool Validate()
		{
			return Validate(blnCheckAutoValidate: false);
		}

		/// 
		/// Validates the specified check auto validate.
		/// </summary>
		/// <param name="blnCheckAutoValidate">if set to true</c> [check auto validate].</param>
		/// </returns>
		public bool Validate(bool blnCheckAutoValidate)
		{
			bool blnValidatedControlAllowsFocusChange;
			return ValidateInternal(blnCheckAutoValidate, out blnValidatedControlAllowsFocusChange);
		}

		/// Causes all of the child controls within a control that support validation to validate their data. </summary>
		/// true if all of the children validated successfully; otherwise, false. </returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool ValidateChildren()
		{
			return ValidateChildren(ValidationConstraints.Selectable);
		}

		/// 
		/// Validates the internal.
		/// </summary>
		/// <param name="blnCheckAutoValidate">if set to true</c> [check auto validate].</param>
		/// <param name="blnValidatedControlAllowsFocusChange">if set to true</c> [validated control allows focus change].</param>
		/// </returns>
		internal bool ValidateInternal(bool blnCheckAutoValidate, out bool blnValidatedControlAllowsFocusChange)
		{
			blnValidatedControlAllowsFocusChange = false;
			if (AutoValidate != AutoValidate.EnablePreventFocusChange && (ActiveControlInternal == null || !ActiveControlInternal.CausesValidation))
			{
				return true;
			}
			if (UnvalidatedControlInternal == null)
			{
				if (FocusedControlInternal is ContainerControl && FocusedControlInternal.CausesValidation)
				{
					ContainerControl containerControl = (ContainerControl)FocusedControlInternal;
					if (!containerControl.ValidateInternal(blnCheckAutoValidate, out blnValidatedControlAllowsFocusChange))
					{
						return false;
					}
				}
				else
				{
					UnvalidatedControlInternal = FocusedControlInternal;
				}
			}
			bool blnPreventFocusChangeOnError = true;
			Control control = ((UnvalidatedControlInternal != null) ? UnvalidatedControlInternal : FocusedControlInternal);
			if (control != null)
			{
				AutoValidate autoValidateForControl = Control.GetAutoValidateForControl(control);
				if (blnCheckAutoValidate && autoValidateForControl == AutoValidate.Disable)
				{
					return true;
				}
				blnPreventFocusChangeOnError = autoValidateForControl == AutoValidate.EnablePreventFocusChange;
				blnValidatedControlAllowsFocusChange = autoValidateForControl == AutoValidate.EnableAllowFocusChange;
			}
			return ValidateThroughAncestor(null, blnPreventFocusChangeOnError);
		}

		/// 
		/// Validates the through ancestor.
		/// </summary>
		/// <param name="objAncestorControl">The ancestor control.</param>
		/// <param name="blnPreventFocusChangeOnError">if set to true</c> [prevent focus change on error].</param>
		/// </returns>
		private bool ValidateThroughAncestor(Control objAncestorControl, bool blnPreventFocusChangeOnError)
		{
			if (objAncestorControl == null)
			{
				objAncestorControl = this;
			}
			if (mobjValidationState[mintStateValidating])
			{
				return false;
			}
			if (UnvalidatedControlInternal == null)
			{
				UnvalidatedControlInternal = FocusedControlInternal;
			}
			if (UnvalidatedControlInternal == null)
			{
				return true;
			}
			if (!objAncestorControl.IsDescendant(UnvalidatedControlInternal))
			{
				return false;
			}
			mobjValidationState[mintStateValidating] = true;
			bool flag = false;
			Control activeControlInternal = ActiveControlInternal;
			Control control = UnvalidatedControlInternal;
			if (activeControlInternal != null)
			{
				activeControlInternal.ValidationCancelled = false;
				if (activeControlInternal is ContainerControl)
				{
					(activeControlInternal as ContainerControl).ResetValidationFlag();
				}
			}
			try
			{
				while (control != null && control != objAncestorControl)
				{
					try
					{
						flag = control.PerformControlValidation(bulkValidation: false);
					}
					catch
					{
						flag = true;
						throw;
					}
					if (flag)
					{
						break;
					}
					control = control.ParentInternal;
				}
				if (flag && blnPreventFocusChangeOnError)
				{
					if (UnvalidatedControlInternal == null && control != null && objAncestorControl.IsDescendant(control))
					{
						UnvalidatedControlInternal = control;
					}
					if (activeControlInternal == ActiveControlInternal && activeControlInternal != null)
					{
						CancelEventArgs e = new CancelEventArgs();
						e.Cancel = true;
						activeControlInternal.NotifyValidationResult(control, e);
						if (activeControlInternal is ContainerControl)
						{
							ContainerControl containerControl = activeControlInternal as ContainerControl;
							if (containerControl.FocusedControlInternal != null)
							{
								containerControl.FocusedControlInternal.ValidationCancelled = true;
							}
							containerControl.ResetActiveAndFocusedControlsRecursive();
						}
					}
					SetActiveControlInternal(UnvalidatedControlInternal);
				}
			}
			finally
			{
				UnvalidatedControlInternal = null;
				mobjValidationState[mintStateValidating] = false;
			}
			return !flag;
		}

		/// 
		/// Updates the focused control state
		/// </summary>
		internal virtual void UpdateFocusedControl()
		{
			EnsureUnvalidatedControl(FocusedControlInternal);
			Control control = FocusedControlInternal;
			while (ActiveControlInternal != control)
			{
				if (control == null || control.IsDescendant(ActiveControlInternal))
				{
					Control control2 = ActiveControlInternal;
					while (true)
					{
						Control parentInternal = control2.ParentInternal;
						if (parentInternal == this || parentInternal == control)
						{
							break;
						}
						control2 = control2.ParentInternal;
					}
					Control control3 = (FocusedControlInternal = control);
					Control control5 = control3;
					EnterValidation(control2);
					if (FocusedControlInternal != control5)
					{
						control = FocusedControlInternal;
						continue;
					}
					control = control2;
					control.NotifyEnter();
					continue;
				}
				ContainerControl innerMostFocusedContainerControl = InnerMostFocusedContainerControl;
				Control control6 = null;
				if (innerMostFocusedContainerControl.FocusedControlInternal != null)
				{
					control = innerMostFocusedContainerControl.FocusedControlInternal;
					control6 = innerMostFocusedContainerControl;
					if (innerMostFocusedContainerControl != this)
					{
						innerMostFocusedContainerControl.FocusedControlInternal = null;
						if (innerMostFocusedContainerControl.ParentInternal == null || !(innerMostFocusedContainerControl.ParentInternal is MdiClient))
						{
							innerMostFocusedContainerControl.ActiveControlInternal = null;
						}
					}
				}
				else
				{
					control = innerMostFocusedContainerControl;
					if (innerMostFocusedContainerControl.ParentInternal != null)
					{
						ContainerControl containerControl = innerMostFocusedContainerControl.ParentInternal.GetContainerControlInternal() as ContainerControl;
						control6 = containerControl;
						if (containerControl != null && containerControl != this)
						{
							containerControl.FocusedControlInternal = null;
							containerControl.ActiveControlInternal = null;
						}
					}
				}
				do
				{
					Control control7 = control;
					if (control != null)
					{
						control = control.ParentInternal;
					}
					if (control == this)
					{
						control = null;
					}
					control7?.NotifyLeave();
				}
				while (control != null && control != control6 && !control.IsDescendant(ActiveControlInternal));
			}
			FocusedControlInternal = ActiveControlInternal;
			if (ActiveControl != null)
			{
				EnterValidation(ActiveControlInternal);
			}
		}

		/// When overridden by a derived class, updates which button is the default button.</summary>
		protected virtual void UpdateDefaultButton()
		{
		}

		/// 
		/// Assigns the current active control
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// </returns>
		private bool AssignActiveControlInternal(Control objControl)
		{
			if (ActiveControlInternal != objControl)
			{
				try
				{
					if (objControl != null)
					{
						objControl.BecomingActiveControl = true;
					}
					ActiveControlInternal = objControl;
					UpdateFocusedControl();
				}
				finally
				{
					if (objControl != null)
					{
						objControl.BecomingActiveControl = false;
					}
				}
				if (ActiveControlInternal == objControl)
				{
					FindFormInternal()?.UpdateDefaultButton();
				}
			}
			else
			{
				FocusedControlInternal = ActiveControlInternal;
			}
			return ActiveControlInternal == objControl;
		}

		/// 
		/// Sets control active
		/// </summary>
		/// <param name="objControl"></param>
		protected void SetActiveControl(Control objControl)
		{
			SetActiveControlInternal(objControl);
		}

		/// 
		/// Sets the current active control
		/// </summary>
		/// <param name="objValue">The obj value.</param>
		internal void SetActiveControlInternal(Control objValue)
		{
			if (ActiveControlInternal == objValue && (objValue == null || objValue.Focused))
			{
				return;
			}
			if (objValue != null && !Contains(objValue))
			{
				throw new ArgumentException(SR.GetString("CannotActivateControl"));
			}
			ContainerControl containerControl = this;
			if (objValue != null && objValue.ParentInternal != null)
			{
				containerControl = objValue.ParentInternal.GetContainerControlInternal() as ContainerControl;
			}
			bool flag = containerControl?.ActivateControlInternal(objValue, blnOriginator: false) ?? AssignActiveControlInternal(objValue);
			if (containerControl != null && flag)
			{
				ContainerControl containerControl2 = this;
				while (containerControl2.ParentInternal != null && containerControl2.ParentInternal.GetContainerControlInternal() is ContainerControl)
				{
					containerControl2 = containerControl2.ParentInternal.GetContainerControlInternal() as ContainerControl;
				}
				if (containerControl2.ContainsFocus && (objValue == null || !(objValue is UserControl) || (objValue is UserControl && !((UserControl)objValue).HasFocusableChild())))
				{
					containerControl.FocusActiveControlInternal();
				}
			}
		}

		/// 
		/// Assigns focus to the activeControl. If there is no activeControl then
		/// focus is given to the form. 
		/// package scope for Form
		/// </summary>
		internal void FocusActiveControlInternal()
		{
			Control activeControlInternal = ActiveControlInternal;
			if (activeControlInternal != null && activeControlInternal.Visible)
			{
				if (VWGContext.Current is IApplicationContext applicationContext && applicationContext.GetFocused() != activeControlInternal)
				{
					applicationContext.SetFocused(activeControlInternal, blnInvokeFocusCommand: true);
					activeControlInternal.OnGotFocus(EventArgs.Empty);
				}
				return;
			}
			ContainerControl containerControl = this;
			while (containerControl != null && !containerControl.Visible)
			{
				Control parentInternal = containerControl.ParentInternal;
				if (parentInternal != null)
				{
					containerControl = parentInternal.GetContainerControlInternal() as ContainerControl;
					continue;
				}
				break;
			}
			if (containerControl != null && containerControl.Visible && Context is IApplicationContext applicationContext2 && applicationContext2.GetFocused() != containerControl)
			{
				applicationContext2.SetFocused(containerControl, blnInvokeFocusCommand: true);
				containerControl.OnGotFocus(EventArgs.Empty);
			}
		}

		/// 
		/// Activates a control with in the container
		/// </summary>
		/// <param name="objControl">The control to be activated.</param>
		/// </returns>
		bool IContainerControl.ActivateControl(Control objControl)
		{
			return ActivateControlInternal(objControl, blnOriginator: true);
		}

		/// 
		/// Afters the control removed.
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="objOldParent">The obj old parent.</param>
		internal virtual void AfterControlRemoved(Control objControl, Control objOldParent)
		{
			if (objControl == ActiveControlInternal || objControl.Contains(ActiveControlInternal))
			{
				if (SelectNextControl(objControl, blnForward: true, blnTabStopOnly: true, blnNested: true, blnWrap: true))
				{
					FocusActiveControlInternal();
				}
				else
				{
					SetActiveControlInternal(null);
				}
			}
			else if (ActiveControlInternal == null && ParentInternal != null && ParentInternal.GetContainerControlInternal() is ContainerControl containerControl && containerControl.ActiveControl == this)
			{
				FindFormInternal()?.SelectNextControl(this, blnForward: true, blnTabStopOnly: true, blnNested: true, blnWrap: true);
			}
			ContainerControl containerControl2 = this;
			while (containerControl2 != null)
			{
				Control parentInternal = containerControl2.ParentInternal;
				if (parentInternal == null)
				{
					break;
				}
				containerControl2 = parentInternal.GetContainerControlInternal() as ContainerControl;
				if (containerControl2 != null && containerControl2.UnvalidatedControlInternal != null && (containerControl2.UnvalidatedControlInternal == objControl || objControl.Contains(containerControl2.UnvalidatedControlInternal)))
				{
					containerControl2.UnvalidatedControlInternal = objOldParent;
				}
			}
			if (objControl == UnvalidatedControlInternal || objControl.Contains(UnvalidatedControlInternal))
			{
				UnvalidatedControlInternal = null;
			}
		}

		/// 
		/// Activates the control internal.
		/// </summary>
		/// <param name="objControl">The control.</param>
		/// </returns>
		internal bool ActivateControlInternal(Control objControl)
		{
			return ActivateControlInternal(objControl, blnOriginator: true);
		}

		/// 
		/// Activates a control with in the container
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// <param name="blnOriginator">if set to true</c> [BLN originator].</param>
		/// </returns>
		internal bool ActivateControlInternal(Control objControl, bool blnOriginator)
		{
			bool result = true;
			bool flag = false;
			ContainerControl containerControl = null;
			Control parent = base.Parent;
			if (parent != null)
			{
				containerControl = parent.GetContainerControlInternal() as ContainerControl;
				if (containerControl != null)
				{
					flag = containerControl.ActiveControl != this;
				}
			}
			if (objControl != ActiveControlInternal || flag)
			{
				if (flag && !containerControl.ActivateControlInternal(this, blnOriginator: false))
				{
					return false;
				}
				result = AssignActiveControlInternal(objControl);
			}
			if (blnOriginator)
			{
				ScrollActiveControlIntoView();
			}
			return result;
		}

		/// 
		/// Scrolls the parent scollable control to make the control visible
		/// </summary>
		private void ScrollActiveControlIntoView()
		{
			Control activeControlInternal = ActiveControlInternal;
			if (activeControlInternal != null)
			{
				for (ScrollableControl scrollableControl = FindScrollableParent(activeControlInternal); scrollableControl != null; scrollableControl = FindScrollableParent(scrollableControl))
				{
					scrollableControl.ScrollControlIntoView(ActiveControlInternal);
					activeControlInternal = scrollableControl;
				}
			}
		}

		/// 
		/// Finds the parent scrollable control
		/// </summary>
		/// <param name="objControl">The obj control.</param>
		/// </returns>
		private ScrollableControl FindScrollableParent(Control objControl)
		{
			Control parentInternal = objControl.ParentInternal;
			while (parentInternal != null && !(parentInternal is ScrollableControl))
			{
				parentInternal = parentInternal.ParentInternal;
			}
			return parentInternal as ScrollableControl;
		}

		/// 
		/// Selects the specified directed.
		/// </summary>
		/// <param name="blnDirected">if set to true</c> [directed].</param>
		/// <param name="blnForward">if set to true</c> [forward].</param>
		protected override void Select(bool blnDirected, bool blnForward)
		{
			bool flag = true;
			if (ParentInternal != null)
			{
				IContainerControl containerControlInternal = ParentInternal.GetContainerControlInternal();
				if (containerControlInternal != null)
				{
					containerControlInternal.ActiveControl = this;
					flag = containerControlInternal.ActiveControl == this;
				}
			}
			if (blnDirected && flag)
			{
				SelectNextControl(null, blnForward, blnTabStopOnly: true, blnNested: true, blnWrap: false);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ContainerControl" /> instance.
		/// </summary>
		public ContainerControl()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, blnValue: false);
		}

		static ContainerControl()
		{
			AutoValidateChanged = SerializableEvent.Register("AutoValidateChanged", typeof(EventHandler), typeof(ContainerControl));
			mintStateParentChanged = SerializableBitVector32.CreateMask(mintStateScalingChild);
			mintStateProcessingMnemonic = SerializableBitVector32.CreateMask(mintStateValidating);
			mintStateScalingChild = SerializableBitVector32.CreateMask(mintStateProcessingMnemonic);
			mintStateScalingNeededOnLayout = SerializableBitVector32.CreateMask();
			mintStateValidating = SerializableBitVector32.CreateMask(mintStateScalingNeededOnLayout);
		}
	}
}
