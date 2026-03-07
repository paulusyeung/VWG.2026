using System;

using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{

	///<summary>Specifies what to render (image or text) for this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripItemDisplayStyle : int
	{
		///<summary>Specifies that only an image is to be rendered for this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Image = 2,

		///<summary>Specifies that both an image and text are to be rendered for this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		ImageAndText = 3,

		///<summary>Specifies that neither image nor text is to be rendered for this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		None = 0,

		///<summary>Specifies that only text is to be rendered for this <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Text = 1
	}

	///<summary>Specifies how and if a drag-and-drop operation should continue.</summary> 
	///<filterpriority>2</filterpriority>
	[ComVisible(true)]
	public enum DragAction : int
	{
		///<summary>The operation is canceled with no drop message.</summary> 
		///<filterpriority>1</filterpriority>
		Cancel = 2,

		///<summary>The operation will continue.</summary> 
		///<filterpriority>1</filterpriority>
		Continue = 0,

		///<summary>The operation will stop with a drop.</summary> 
		///<filterpriority>1</filterpriority>
		Drop = 1
	}

	///<summary>Determines the alignment of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> in a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripItemAlignment : int
	{
		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be anchored toward the left or top end of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, depending on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> orientation. If the value of <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> is Yes, items marked as <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Left"></see> are aligned to the right side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
		Left = 0,

		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be anchored toward the right or bottom end of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, depending on the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> orientation. If the value of <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> is Yes, items marked as <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right"></see> are aligned to the left side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
		Right = 1
	}

	///<summary>Specifies whether the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> while retaining the original image proportions.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripItemImageScaling : int
	{
		///<summary>Specifies that the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		None = 0,

		///<summary>Specifies that the size of the image on a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is automatically adjusted to fit on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
		SizeToFit = 1
	}

	///<summary>Specifies the kind of action to take if a match is found when combining menu items on a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
	///<filterpriority>2</filterpriority>
	public enum MergeAction : int
	{
		///<summary>Appends the item to the end of the collection, ignoring match results.</summary> 
		///<filterpriority>1</filterpriority>
		Append = 0,

		///<summary>Inserts the item to the target's collection immediately preceding the matched item. A match of the end of the list results in the item being appended to the list. If there is no match or the match is at the beginning of the list, the item is inserted at the beginning of the collection.</summary> 
		///<filterpriority>1</filterpriority>
		Insert = 1,

		///<summary>A match is required, but no action is taken. Use this for tree creation and successful access to nested layouts.</summary> 
		///<filterpriority>1</filterpriority>
		MatchOnly = 4,

		///<summary>Removes the matched item.</summary> 
		///<filterpriority>1</filterpriority>
		Remove = 3,

		///<summary>Replaces the matched item with the source item. The original item's drop-down items do not become children of the incoming item.</summary> 
		///<filterpriority>1</filterpriority>
		Replace = 2
	}

	///<summary>Determines whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is placed in the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripItemOverflow : int
	{
		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is permanently shown in the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Always = 1,

		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> drifts between the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> and the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> as required if space is not available on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		AsNeeded = 2,

		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is never a candidate for the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>. If the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> cannot fit on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>, it will not be shown.</summary> 
		///<filterpriority>1</filterpriority>
		Never = 0
	}

	///<summary>Specifies where a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripItemPlacement : int
	{
		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out on the main <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Main = 0,

		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is not to be layed out on the screen.</summary> 
		///<filterpriority>1</filterpriority>
		None = 2,

		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> is to be layed out on the overflow <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Overflow = 1
	}

	///<summary>Specifies the text orientation to use with a particular <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.LayoutStyle"></see>.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripTextDirection : int
	{
		///<summary>Specifies horizontal text orientation.</summary> 
		///<filterpriority>1</filterpriority>
		Horizontal = 1,

		///<summary>Specifies that the text direction is inherited from the parent control.</summary> 
		///<filterpriority>1</filterpriority>
		Inherit = 0,

		///<summary>Specifies that text is to be rotated 270 degrees.</summary> 
		///<filterpriority>1</filterpriority>
		Vertical270 = 3,

		///<summary>Specifies that text is to be rotated 90 degrees.</summary> 
		///<filterpriority>1</filterpriority>
		Vertical90 = 2
	}

	///<summary>Specifies the direction to move when getting items with the <see cref="M:Gizmox.WebGUI.Forms.ToolStrip.GetNextItem(Gizmox.WebGUI.Forms.ToolStripItem,Gizmox.WebGUI.Forms.ArrowDirection)"></see> method.</summary>
	public enum ArrowDirection : int
	{
		///<summary>The direction is down (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Vertical"></see>).</summary>
		Down = 17,

		///<summary>The direction is left (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>).</summary>
		Left = 0,

		///<summary>The direction is right (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Horizontal"></see>).</summary>
		Right = 16,

		///<summary>The direction is left (<see cref="F:Gizmox.WebGUI.Forms.Orientation.Vertical"></see>).</summary>
		Up = 1
	}

	///<summary>Specifies the orientation of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip).</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripGripDisplayStyle : int
	{
		///<summary>Specifies a horizontal orientation for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip).</summary> 
		///<filterpriority>1</filterpriority>
		Horizontal = 0,

		///<summary>Specifies a vertical orientation for the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip).</summary> 
		///<filterpriority>1</filterpriority>
		Vertical = 1
	}

	///<summary>Specifies visibility of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip).</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripGripStyle : int
	{
		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip) is not visible.</summary> 
		///<filterpriority>1</filterpriority>
		Hidden = 0,

		///<summary>Specifies that a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> move handle (grip) is visible.</summary> 
		///<filterpriority>1</filterpriority>
		Visible = 1
    }

	///<summary>Specifies the painting style applied to one <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> contained in a form.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripRenderMode : int
	{

		///<summary>Indicates that the <see cref="P:Gizmox.WebGUI.Forms.ToolStrip.RenderMode"></see> is not determined by the <see cref="T:Gizmox.WebGUI.Forms.ToolStripManager"></see> or the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripRenderer"></see> other than <see cref="T:Gizmox.WebGUI.Forms.ToolStripProfessionalRenderer"></see>, <see cref="T:Gizmox.WebGUI.Forms.ToolStripSystemRenderer"></see></summary> 
		///<filterpriority>1</filterpriority>
		Custom = 0,

		///<summary>Indicates that the <see cref="P:Gizmox.WebGUI.Forms.ToolStripManager.RenderMode"></see> or <see cref="P:Gizmox.WebGUI.Forms.ToolStripManager.Renderer"></see> determines the painting style.</summary> 
		///<filterpriority>1</filterpriority>
		ManagerRenderMode = 3,

		///<summary>Indicates the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripProfessionalRenderer"></see> to paint.</summary> 
		///<filterpriority>1</filterpriority>
		Professional = 2,

		///<summary>Indicates the use of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSystemRenderer"></see> to paint.</summary> 
		///<filterpriority>1</filterpriority>
		System = 1
	}

	///<summary>Specifies how a control should be docked by default when added through a designer.</summary> 
	///<filterpriority>2</filterpriority>
	public enum DockingBehavior : int
	{
		///<summary>Prompt the user for the desired docking behavior.</summary> 
		///<filterpriority>1</filterpriority>
		Ask = 1,

		///<summary>Set the control's <see cref="P:Gizmox.WebGUI.Forms.Control.Dock"></see> property to <see cref="F:Gizmox.WebGUI.Forms.DockStyle.Fill"></see>  when it is dropped into a container with no other child controls.</summary> 
		///<filterpriority>1</filterpriority>
		AutoDock = 2,

		///<summary>Do not prompt the user for the desired docking behavior.</summary> 
		///<filterpriority>1</filterpriority>
		Never = 0
	}

	///<summary>Specifies the possible alignments with which the items of a <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> can be displayed.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ToolStripLayoutStyle : int
	{
		///<summary>Specifies that items flow horizontally or vertically as necessary.</summary> 
		///<filterpriority>1</filterpriority>
		Flow = 3,

		///<summary>Specifies that items are laid out horizontally and overflow as necessary.</summary>
		HorizontalStackWithOverflow = 1,

		///<summary>Specifies that items are laid out automatically.</summary>
		StackWithOverflow = 0,

		///<summary>Specifies that items are laid out flush left.</summary> 
		///<filterpriority>1</filterpriority>
		Table = 4,

		///<summary>Specifies that items are laid out vertically, are centered within the control, and overflow as necessary.</summary>
		VerticalStackWithOverflow = 2
	}

	///<summary>Specifies which child controls to skip.</summary>
	[Flags()]
	public enum GetChildAtPointSkip : int
	{
		///<summary>Skips disabled child windows.</summary>
		Disabled = 2,

		///<summary>Skips invisible child windows.</summary>
		Invisible = 1,

		///<summary>Does not skip any child windows.</summary>
		None = 0,

		///<summary>Skips transparent child windows.</summary>
		Transparent = 4
	}

	///<summary>Specifies the direction in which a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control is displayed relative to its parent control.</summary>
	public enum ToolStripDropDownDirection : int
	{
		///<summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed above and to the left of its parent control.</summary>
		AboveLeft = 0,

		///<summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed above and to the right of its parent control.</summary>
		AboveRight = 1,

		///<summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed below and to the left of its parent control.</summary>
		BelowLeft = 2,

		///<summary>Uses the mouse position to specify that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed below and to the right of its parent control.</summary>
		BelowRight = 3,

		///<summary>Compensates for nested drop-down controls and responds to the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> setting, specifying either <see cref="F:Gizmox.WebGUI.Forms.ToolStripDropDownDirection.Left"></see> or <see cref="F:Gizmox.WebGUI.Forms.ToolStripDropDownDirection.Right"></see> accordingly.</summary>
		Default = 7,

		///<summary>Compensates for nested drop-down controls and specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed to the left of its parent control.</summary>
		Left = 4,

		///<summary>Compensates for nested drop-down controls and specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is displayed to the right of its parent control.</summary>
		Right = 5
	}

	///<summary>Specifies the reason that a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed.</summary>
	public enum ToolStripDropDownCloseReason : int
	{
		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because an application was launched.</summary>
        [Obsolete("Not implemented. Added for migration compatibility")]
        AppClicked = 1,

		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because another application has received the focus.</summary>
		AppFocusChange = 0,

		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDown.Close"></see> method was called.</summary>
		CloseCalled = 4,

		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because one of its items was clicked.</summary>
		ItemClicked = 2,

		///<summary>Specifies that the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> control was closed because of keyboard activity, such as the ESC key being pressed.</summary>
		Keyboard = 3
	}

	///<summary>Specifies the state of the user interface.</summary> 
	///<filterpriority>2</filterpriority>
	[Flags()]
	public enum UICues : int
	{
		///<summary>The state of the focus cues and keyboard cues has changed.</summary> 
		///<filterpriority>1</filterpriority>
		Changed = 12,

		///<summary>The state of the focus cues has changed.</summary> 
		///<filterpriority>1</filterpriority>
		ChangeFocus = 4,

		///<summary>The state of the keyboard cues has changed.</summary> 
		///<filterpriority>1</filterpriority>
		ChangeKeyboard = 8,

		///<summary>No change was made.</summary> 
		///<filterpriority>1</filterpriority>
		None = 0,

		///<summary>Focus rectangles are displayed after the change.</summary> 
		///<filterpriority>1</filterpriority>
		ShowFocus = 1,

		///<summary>Keyboard cues are underlined after the change.</summary> 
		///<filterpriority>1</filterpriority>
		ShowKeyboard = 2,

		///<summary>Focus rectangles are displayed and keyboard cues are underlined after the change.</summary> 
		///<filterpriority>1</filterpriority>
		Shown = 3
	}

	///<summary>Specifies the type of action used to raise the <see cref="E:Gizmox.WebGUI.Forms.ScrollBar.Scroll"></see> event.</summary> 
	///<filterpriority>2</filterpriority>
	[ComVisible(true)]
	public enum ScrollEventType : int
	{
		///<summary>The scroll box has stopped moving.</summary> 
		///<filterpriority>1</filterpriority>
		EndScroll = 8,

		///<summary>The scroll box was moved to the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Minimum"></see> position.</summary> 
		///<filterpriority>1</filterpriority>
		First = 6,

		///<summary>The scroll box moved a large distance. The user clicked the scroll bar to the left(horizontal) or above(vertical) the scroll box, or pressed the PAGE UP key.</summary> 
		///<filterpriority>1</filterpriority>
		LargeDecrement = 2,

		///<summary>The scroll box moved a large distance. The user clicked the scroll bar to the right(horizontal) or below(vertical) the scroll box, or pressed the PAGE DOWN key.</summary> 
		///<filterpriority>1</filterpriority>
		LargeIncrement = 3,

		///<summary>The scroll box was moved to the <see cref="P:Gizmox.WebGUI.Forms.ScrollBar.Maximum"></see> position.</summary> 
		///<filterpriority>1</filterpriority>
		Last = 7,

		///<summary>The scroll box was moved a small distance. The user clicked the left(horizontal) or top(vertical) scroll arrow, or pressed the UP ARROW key.</summary> 
		///<filterpriority>1</filterpriority>
		SmallDecrement = 0,

		///<summary>The scroll box was moved a small distance. The user clicked the right(horizontal) or bottom(vertical) scroll arrow, or pressed the DOWN ARROW key.</summary> 
		///<filterpriority>1</filterpriority>
		SmallIncrement = 1,

		///<summary>The scroll box was moved.</summary> 
		///<filterpriority>1</filterpriority>
		ThumbPosition = 4,

		///<summary>The scroll box is currently being moved.</summary> 
		///<filterpriority>1</filterpriority>
		ThumbTrack = 5
	}

	///<summary>Specifies the scroll bar orientation for the <see cref="E:Gizmox.WebGUI.Forms.ScrollBar.Scroll"></see> event.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ScrollOrientation : int
	{
		///<summary>The horizontal scroll bar.</summary> 
		///<filterpriority>1</filterpriority>
		HorizontalScroll = 0,

		///<summary>The vertical scroll bar.</summary> 
		///<filterpriority>1</filterpriority>
		VerticalScroll = 1
	}

	///<summary>Specifies the style that a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> uses to indicate the progress of an operation.</summary> 
	///<filterpriority>2</filterpriority>
	public enum ProgressBarStyle : int
	{
		///<summary>Indicates progress by increasing the number of segmented blocks in a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Blocks = 0,

		///<summary>Indicates progress by increasing the size of a smooth, continuous bar in a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see>.</summary> 
		///<filterpriority>1</filterpriority>
		Continuous = 1,

		///<summary>Indicates progress by continuously scrolling a block across a <see cref="T:Gizmox.WebGUI.Forms.ProgressBar"></see> in a marquee fashion.</summary>
		Marquee = 2
	}

    ///<summary>Specifies which sides of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> have borders.</summary>
    [ComVisible(true)]
    public enum ToolStripStatusLabelBorderSides : int
    {
        ///<summary>All sides of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> have borders.</summary>
        All = 15,

        ///<summary>Only the bottom side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
        Bottom = 8,

        ///<summary>Only the left side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
        Left = 1,

        ///<summary>The <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has no borders.</summary>
        None = 0,

        ///<summary>Only the right side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
        Right = 4,

        ///<summary>Only the top side of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> has borders.</summary>
        Top = 2
    }
}
