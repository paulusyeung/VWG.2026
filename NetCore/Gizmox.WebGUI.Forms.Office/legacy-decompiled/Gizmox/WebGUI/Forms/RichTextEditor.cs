using System;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(RichTextEditor), "RichTextEditor_45.png")]
[Skin(typeof(RichTextEditorSkin))]
[MetadataTag("RTE")]
public class RichTextEditor : Control, ISupportsRibbonBar, IRequiresRegistration
{
	private string mstrValue = string.Empty;

	private bool mblnReadOnly;

	private static readonly SerializableEvent ValueChangedEvent;

	private static readonly SerializableEvent ValueChangedQueuedEvent;

	private IContainer components;

	private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChangedEvent);

	private EventHandler ValueChangedQueuedHandler => (EventHandler)GetHandler(ValueChangedQueuedEvent);

	[DefaultValue("")]
	public string Value
	{
		get
		{
			return mstrValue;
		}
		set
		{
			if (mstrValue != value)
			{
				mstrValue = value;
				Update();
			}
		}
	}

	[DefaultValue(false)]
	public bool ReadOnly
	{
		get
		{
			return mblnReadOnly;
		}
		set
		{
			if (mblnReadOnly != value)
			{
				mblnReadOnly = value;
				UpdateParams(AttributeType.Control);
			}
		}
	}

	public event EventHandler ValueChanged
	{
		add
		{
			AddCriticalHandler(ValueChangedEvent, value);
		}
		remove
		{
			RemoveCriticalHandler(ValueChangedEvent, value);
		}
	}

	[Description("Occurs when editor's value changed in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientValueChanged
	{
		add
		{
			AddClientHandler("ValueChange", value);
		}
		remove
		{
			RemoveClientHandler("ValueChange", value);
		}
	}

	public event EventHandler ValueChangedQueued
	{
		add
		{
			AddHandler(ValueChangedQueuedEvent, value);
		}
		remove
		{
			RemoveHandler(ValueChangedQueuedEvent, value);
		}
	}

	protected override void RenderAttributes(IContext context, IAttributeWriter writer)
	{
		base.RenderAttributes(context, writer);
		writer.WriteAttributeText("VLB", Value);
		writer.WriteAttributeString("RO", mblnReadOnly ? "1" : "0");
	}

	protected override void FireEvent(IEvent objEvent)
	{
		string type = objEvent.Type;
		if (type == "ValueChange")
		{
			mstrValue = objEvent["VLB"];
			if (ValueChangedHandler != null)
			{
				ValueChangedHandler(this, EventArgs.Empty);
			}
			if (ValueChangedQueuedHandler != null)
			{
				ValueChangedQueuedHandler(this, EventArgs.Empty);
			}
		}
		else
		{
			base.FireEvent(objEvent);
		}
	}

	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (ValueChangedHandler != null)
		{
			criticalEventsData.Set("VC");
		}
		return base.GetCriticalEventsData();
	}

	protected override CriticalEventsData GetCriticalClientEventsData()
	{
		CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
		if (HasClientHandler("ValueChange"))
		{
			criticalClientEventsData.Set("VC");
		}
		return criticalClientEventsData;
	}

	RibbonBarGroup ISupportsRibbonBar.CreateGroup(string strGroupName)
	{
		return strGroupName switch
		{
			"BasicText" => CreateBasicTextRibbonGroup(null), 
			"Font" => CreateEmtypRibbonGroup(null, "Font"), 
			"Paragraph" => CreateParagraphRibbonGroup(null), 
			"Clipboard" => CreateClipboardRibbonGroup(null), 
			"Zoom" => CreateEmtypRibbonGroup(null, "Zoom"), 
			"Proofing" => CreateProofingRibbonGroup(null), 
			_ => null, 
		};
	}

	void ISupportsRibbonBar.ApplyGroup(RibbonBarGroup objGroup, string strGroupName)
	{
		objGroup.Items.Clear();
		switch (strGroupName)
		{
		case "BasicText":
			CreateBasicTextRibbonGroup(objGroup);
			break;
		case "Font":
			CreateEmtypRibbonGroup(objGroup, "Font");
			break;
		case "Paragraph":
			CreateParagraphRibbonGroup(objGroup);
			break;
		case "Clipboard":
			CreateClipboardRibbonGroup(objGroup);
			break;
		case "Proofing":
			CreateProofingRibbonGroup(objGroup);
			break;
		case "Zoom":
			CreateEmtypRibbonGroup(objGroup, "Zoom");
			break;
		}
	}

	private RibbonBarGroup EnsureGroup(RibbonBarGroup objGroup)
	{
		if (objGroup == null)
		{
			objGroup = new RibbonBarGroup();
		}
		else
		{
			objGroup.Items.Clear();
		}
		return objGroup;
	}

	private RibbonBarGroup CreateEmtypRibbonGroup(RibbonBarGroup objGroup, string strGroupName)
	{
		objGroup = EnsureGroup(objGroup);
		objGroup.Text = strGroupName;
		return objGroup;
	}

	private RibbonBarGroup CreateProofingRibbonGroup(RibbonBarGroup objGroup)
	{
		if (objGroup == null)
		{
			objGroup = new RibbonBarGroup();
		}
		objGroup.Text = "Proofing";
		objGroup.Items.Add(CreateButtonItem("Spelling", "Spelling", "Large.Spelling", "Spelling"));
		return objGroup;
	}

	private RibbonBarGroup CreateParagraphRibbonGroup(RibbonBarGroup objGroup)
	{
		if (objGroup == null)
		{
			objGroup = new RibbonBarGroup();
		}
		objGroup.Text = "Paragraph";
		RibbonBarFlowItem ribbonBarFlowItem = new RibbonBarFlowItem();
		ribbonBarFlowItem.Width = 500;
		objGroup.Items.Add(ribbonBarFlowItem);
		return objGroup;
	}

	private RibbonBarGroup CreateClipboardRibbonGroup(RibbonBarGroup objGroup)
	{
		if (objGroup == null)
		{
			objGroup = new RibbonBarGroup();
		}
		objGroup.Text = "Clipboard";
		RibbonBarButtonItem item = CreateButtonItem("Paste", "Paste", "LargePaste", "Paste");
		objGroup.Items.Add(item);
		RibbonBarStackItem ribbonBarStackItem = new RibbonBarStackItem();
		ribbonBarStackItem.Items.Add(CreateButtonItem("Cut", "Cut", "Cut", "Cut"));
		ribbonBarStackItem.Items.Add(CreateButtonItem("Copy", "Copy", "Copy", "Copy"));
		ribbonBarStackItem.Items.Add(CreateButtonItem("Format Painter ", "Format Painter", "FormatPainter", "Format Painter"));
		objGroup.Items.Add(ribbonBarStackItem);
		return objGroup;
	}

	private RibbonBarGroup CreateBasicTextRibbonGroup(RibbonBarGroup objGroup)
	{
		if (objGroup == null)
		{
			objGroup = new RibbonBarGroup();
		}
		objGroup.Text = "Basic Text";
		RibbonBarFlowItem ribbonBarFlowItem = new RibbonBarFlowItem();
		ribbonBarFlowItem.Width = 233;
		ribbonBarFlowItem.Items.Add(CreateFontStyleToolBar());
		ribbonBarFlowItem.Items.Add(CreateIndentToolBar());
		ribbonBarFlowItem.Items.Add(CreateJustifyToolBar());
		ribbonBarFlowItem.Items.Add(CreateListToolBar());
		ribbonBarFlowItem.Items.Add(CreateUndoRedoToolBar());
		ribbonBarFlowItem.Items.Add(CreateLinkToolBar());
		objGroup.Items.Add(ribbonBarFlowItem);
		return objGroup;
	}

	private RibbonBarToolBarItem CreateLinkToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Link", "Link", "CreateLink"),
				(RibbonBarItem)CreateToolBarItem("Unlink", "UnLink", "UnLink")
			}
		};
	}

	private RibbonBarToolBarItem CreateUndoRedoToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Undo", "Undo", "Undo"),
				(RibbonBarItem)CreateToolBarItem("Redo", "Redo", "Redo")
			}
		};
	}

	private RibbonBarToolBarItem CreateListToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Insert Unordered List", "UnOrderedList", "InsertUnorderedList"),
				(RibbonBarItem)CreateToolBarItem("Insert Ordered List", "OrderedList", "InsertOrderedList")
			}
		};
	}

	private RibbonBarToolBarItem CreateIndentToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Indent", "Indent", "Indent"),
				(RibbonBarItem)CreateToolBarItem("Outdent", "Outdent", "Outdent")
			}
		};
	}

	private RibbonBarToolBarItem CreateJustifyToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Justify Left", "JustifyLeft", "JustifyLeft"),
				(RibbonBarItem)CreateToolBarItem("Justify Center", "JustifyCenter", "JustifyCenter"),
				(RibbonBarItem)CreateToolBarItem("Justify Right", "JustifyRight", "JustifyRight")
			}
		};
	}

	private RibbonBarToolBarItem CreateFontStyleToolBar()
	{
		return new RibbonBarToolBarItem
		{
			Items = 
			{
				(RibbonBarItem)CreateToolBarItem("Bold", "Bold", "Bold"),
				(RibbonBarItem)CreateToolBarItem("Italic", "Italic", "Italic"),
				(RibbonBarItem)CreateToolBarItem("Underline", "Underline", "Underline"),
				(RibbonBarItem)CreateToolBarItem("Strike Through", "StrikeThrough", "strikethrough"),
				(RibbonBarItem)CreateToolBarItem("Subscript", "Subscript", "subscript"),
				(RibbonBarItem)CreateToolBarItem("Superscript", "Superscript", "superscript"),
				(RibbonBarItem)CreateToolBarItem("Remove Format", "RemoveFormat", "RemoveFormat")
			}
		};
	}

	private RibbonBarItem CreateFontSizeComboBox()
	{
		RibbonBarComboBoxItem ribbonBarComboBoxItem = new RibbonBarComboBoxItem();
		ribbonBarComboBoxItem.Items.AddRange(new object[15]
		{
			8, 9, 10, 11, 12, 14, 16, 18, 20, 22,
			24, 26, 36, 48, 72
		});
		ribbonBarComboBoxItem.TextChanged += OnFontSizeComboBoxChanged;
		return ribbonBarComboBoxItem;
	}

	private void OnFontSizeComboBoxChanged(object sender, EventArgs e)
	{
		if (int.TryParse(((RibbonBarComboBoxItem)sender).Text, out var result))
		{
			InvokeMethodWithId("RichTextEditor_Execute", "FontSize", result.ToString());
		}
	}

	private RibbonBarComboBoxItem CreateFontComboBox()
	{
		return new RibbonBarComboBoxItem
		{
			DataSource = FontFamily.Families,
			DisplayMember = "Name",
			ValueMember = "Name"
		};
	}

	private RibbonBarToolBarButtonItem CreateToolBarItem(string strToolTip, string strIcon, string strCommand)
	{
		return CreateToolBarItem(strToolTip, strIcon, strCommand, string.Empty, string.Empty);
	}

	private RibbonBarToolBarButtonItem CreateToolBarItem(string strToolTip, string strIcon, string strCommand, string strParamA)
	{
		return CreateToolBarItem(strToolTip, strIcon, strCommand, strParamA, string.Empty);
	}

	private RibbonBarToolBarButtonItem CreateToolBarItem(string strToolTip, string strIcon, string strCommand, string strParamA, string strParamB)
	{
		return new RibbonBarToolBarButtonItem
		{
			ToolTip = strToolTip,
			Image = CreateIconHandle(strIcon),
			ClientAction = CreateClientAction(strCommand, strParamA, strParamB)
		};
	}

	private RibbonBarButtonItem CreateButtonItem(string strText, string strToolTip, string strIcon, string strCommand)
	{
		return CreateButtonItem(strText, strToolTip, strIcon, strCommand, string.Empty, string.Empty);
	}

	private RibbonBarButtonItem CreateButtonItem(string strText, string strToolTip, string strIcon, string strCommand, string strParamA)
	{
		return CreateButtonItem(strText, strToolTip, strIcon, strCommand, strParamA, string.Empty);
	}

	private RibbonBarButtonItem CreateButtonItem(string strText, string strToolTip, string strIcon, string strCommand, string strParamA, string strParamB)
	{
		return new RibbonBarButtonItem
		{
			Text = strText,
			ToolTip = strToolTip,
			Image = CreateIconHandle(strIcon),
			ClientAction = CreateClientAction(strCommand, strParamA, strParamB)
		};
	}

	private SkinResourceHandle CreateIconHandle(string strIcon)
	{
		return new SkinResourceHandle(base.Skin, $"Actions.{strIcon}.gif");
	}

	private RegisteredClientAction CreateClientAction(string strCommand, string strParamA)
	{
		return RegisteredClientAction.CreateWithId(this, "RichTextEditor_Execute", strCommand, strParamA, string.Empty);
	}

	private RegisteredClientAction CreateClientAction(string strCommand, string strParamA, string strParamB)
	{
		return RegisteredClientAction.CreateWithId(this, "RichTextEditor_Execute", strCommand, strParamA, strParamB);
	}

	private void InitializeComponent()
	{
		components = new Container();
	}

	static RichTextEditor()
	{
		ValueChangedEvent = SerializableEvent.Register("ValueChanged", typeof(EventHandler), typeof(RichTextEditor));
		ValueChangedQueuedEvent = SerializableEvent.Register("ValueChangedQueued", typeof(EventHandler), typeof(RichTextEditor));
	}
}
