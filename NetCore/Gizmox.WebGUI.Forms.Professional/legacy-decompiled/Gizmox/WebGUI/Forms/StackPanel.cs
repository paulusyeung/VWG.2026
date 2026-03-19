using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
/// A Panel control
/// </summary>
[Serializable]
[Skin(typeof(StackPanelSkin))]
[ToolboxBitmap(typeof(StackPanel), "Professional.StackPanel_45.png")]
[ClientController("Gizmox.WebGUI.Client.Controllers.StackPanelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[DesignTimeController("Gizmox.WebGUI.Forms.Professional.Design.Controllers.StackPanelController, Gizmox.WebGUI.Forms.Professional.Design")]
public class StackPanel : Panel, IRequiresRegistration
{
	/// <summary>
	///
	/// </summary>
	private Orientation menmOrientation = Orientation.Vertical;

	/// <summary>
	/// Gets or sets the orientation.
	/// </summary>
	/// <value>
	/// The orientation.
	/// </value>
	[Category("Layout")]
	[Description("The orientation of the control")]
	[DefaultValue(Orientation.Vertical)]
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
				UpdateParams(AttributeType.Layout);
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StackPanel" /> class.
	/// </summary>
	public StackPanel()
	{
		CustomStyle = "StackPanel";
	}

	/// <summary>
	/// Renders the scrollable attribute
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
	{
		base.RenderAttributes(objContext, objWriter);
		RenderOrientationAttribute(objContext, objWriter, blnForceRender: false);
	}

	/// <summary>
	/// Renders the orientation attribute.
	/// </summary>
	/// <param name="objContext">The obj context.</param>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderOrientationAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
	{
		Orientation orientation = Orientation;
		if (orientation != Orientation.Vertical || blnForceRender)
		{
			objWriter.WriteAttributeString("ORI", Convert.ToInt32(orientation).ToString());
		}
	}

	/// <summary>
	/// An abstract param attribute rendering
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
		{
			RenderOrientationAttribute(objContext, objWriter, blnForceRender: true);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:ControlAdded" /> event.
	/// </summary>
	/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
	/// <remarks></remarks>
	protected override void OnControlAdded(ControlEventArgs e)
	{
		base.OnControlAdded(e);
		if (e.Control != null)
		{
			e.Control.VisibleChanged += OnContainedControlVisiblityChanged;
		}
	}

	/// <summary>
	/// Raises the <see cref="E:ControlRemoved" /> event.
	/// </summary>
	/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.ControlEventArgs" /> instance containing the event data.</param>
	/// <remarks></remarks>
	protected override void OnControlRemoved(ControlEventArgs e)
	{
		base.OnControlRemoved(e);
		if (e.Control != null)
		{
			e.Control.VisibleChanged -= OnContainedControlVisiblityChanged;
		}
	}

	/// <summary>
	/// Called when [contained control visiblity changed].
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	/// <remarks></remarks>
	private void OnContainedControlVisiblityChanged(object sender, EventArgs e)
	{
		Update(blnRedrawOnly: false);
	}
}
