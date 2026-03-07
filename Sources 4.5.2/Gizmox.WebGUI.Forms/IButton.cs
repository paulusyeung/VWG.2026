using System;

namespace Gizmox.WebGUI.Forms
{
	/// <summary>
	/// Summary description for IButton.
	/// </summary>
	public interface IButtonControl
	{
		/// <summary>
		/// <para>Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.</para>
		/// </summary>
		/// <param name="value">
		/// <see langword="true" /> if the control should behave as a default button; otherwise <see langword="false" />.</param>
		void NotifyDefault(bool blnValue);
		/// <summary>
		/// <para>Generates a <see cref="E:System.Windows.Forms.Control.Click" /> event for the control.</para>
		/// </summary>
		void PerformClick();

		/// <summary>
		/// <para> Gets or sets the value returned to the parent form when the
		/// button is clicked.</para>
		/// </summary>
		DialogResult DialogResult { get; set; }

	}
}
