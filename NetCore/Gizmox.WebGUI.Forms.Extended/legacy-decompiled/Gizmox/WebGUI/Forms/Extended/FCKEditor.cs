using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Editors;
using Gizmox.WebGUI.Forms.Editors.Skins;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms.Extended;

/// <summary>
/// Summary description for FCKEditor
/// </summary>
[Serializable]
[ToolboxItem(true)]
[ToolboxBitmap(typeof(FCKEditor), "Editors.FCKEditor_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
[MetadataTag("FCKE")]
[WebCompilerResources("Gizmox.WebGUI.Forms.Extended.Editors")]
[Skin(typeof(FCKEditorSkin))]
public class FCKEditor : Control
{
	private FCKeditorConfigurations mobjFCKeditorConfigurations = null;

	private string mstrValue = "";

	private string mstrBasePath = null;

	private string mstrToolbarSet = null;

	/// <summary>
	/// The ValueChanged event registration.
	/// </summary>
	private static readonly SerializableEvent ValueChangedEvent;

	/// <summary>
	/// The ValueChange event registration.
	/// </summary>
	private static readonly SerializableEvent ValueChangedQueuedEvent;

	/// <summary>
	///
	/// </summary>
	private static readonly SerializableEvent SaveEvent;

	/// <summary>
	/// Required designer variable.
	/// </summary>
	[NonSerialized]
	private IContainer components = null;

	/// <summary>
	/// Gets the hanlder for the ValueChanged event.
	/// </summary>
	private EventHandler ValueChangedHandler => (EventHandler)GetHandler(ValueChangedEvent);

	/// <summary>
	/// Gets the hanlder for the ValueChangedQueued event.
	/// </summary>
	private EventHandler ValueChangedQueuedHandler => (EventHandler)GetHandler(ValueChangedQueuedEvent);

	/// <summary>
	/// Gets the save handler.
	/// </summary>
	private EventHandler SaveHandler => (EventHandler)GetHandler(SaveEvent);

	private string ClientID => "CID_" + ((IRegisteredComponent)this).ID;

	private string UniqueID => "UID_" + ((IRegisteredComponent)this).ID;

	/// <summary>
	/// <p>
	/// 	Sets or gets the virtual path to the editor's directory. It is
	/// 	relative to the current page.
	/// </p>
	/// <p>
	/// 	The default value is "/FCKeditor/".
	/// </p>
	/// <p>
	/// 	The base path can be also set in the Web.config file using the 
	/// 	appSettings section. Just set the "FCKeditor:BasePath" for that. 
	/// 	For example:
	/// 	<code>
	/// 	&lt;configuration&gt;
	/// 		&lt;appSettings&gt;
	/// 			&lt;add key="FCKeditor:BasePath" value="/scripts/FCKeditor/" /&gt;
	/// 		&lt;/appSettings&gt;
	/// 	&lt;/configuration&gt;
	/// 	</code>
	/// </p>
	/// </summary>
	[DefaultValue("/FCKeditor/")]
	public string BasePath
	{
		get
		{
			if (mstrBasePath == null)
			{
				mstrBasePath = ConfigurationManager.AppSettings["FCKeditor:BasePath"];
			}
			if (VWGContext.Current == null)
			{
				if (string.IsNullOrEmpty(mstrBasePath))
				{
					mstrBasePath = "../../../../../../../FCKEditor/";
				}
				return mstrBasePath;
			}
			string text = VWGContext.Current.HttpContext.Request.ApplicationPath;
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			text += "FCKEditor/";
			if (string.IsNullOrEmpty(mstrBasePath))
			{
				mstrBasePath = text;
			}
			else
			{
				string pattern = "^(../)+FCKEditor(/)?$";
				Match match = Regex.Match(mstrBasePath, pattern, RegexOptions.IgnoreCase);
				if (match.Success)
				{
					mstrBasePath = text;
				}
			}
			return mstrBasePath;
		}
		set
		{
			mstrBasePath = value;
		}
	}

	/// <summary>
	/// Gets or sets the value.
	/// </summary>
	/// <value>The value.</value>
	[DefaultValue("")]
	[Bindable(true)]
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
				OnValueChanged(EventArgs.Empty);
				Update();
			}
		}
	}

	/// <summary>
	/// Gets the config.
	/// </summary>
	/// <value>The config.</value>
	[Browsable(false)]
	public FCKeditorConfigurations Config
	{
		get
		{
			if (mobjFCKeditorConfigurations == null)
			{
				mobjFCKeditorConfigurations = new FCKeditorConfigurations();
			}
			return mobjFCKeditorConfigurations;
		}
	}

	/// <summary>
	/// Sets a value indicating whether [auto detect language].
	/// </summary>
	/// <value>
	///   <c>true</c> if [auto detect language]; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Always auto detecting unless the Language configuration was specified. Falls back to DefaultLanguage.")]
	[Browsable(false)]
	public bool AutoDetectLanguage
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Extended.FCKEditor" /> is debug.
	/// </summary>
	/// <value>
	///   <c>true</c> if debug; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Not ported.")]
	[Browsable(false)]
	public bool Debug
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets a value indicating whether [enable source XHTML].
	/// </summary>
	/// <value>
	///   <c>true</c> if [enable source XHTML]; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Not ported.")]
	[Browsable(false)]
	public bool EnableSourceXHTML
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the font colors.
	/// </summary>
	/// <value>
	/// The font colors.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use ColorButtonColors instead.")]
	[Browsable(false)]
	public string FontColors
	{
		set
		{
			ColorButtonColors = value;
		}
	}

	/// <summary>
	/// Sets the format indentator.
	/// </summary>
	/// <value>
	/// The format indentator.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x.")]
	[Browsable(false)]
	public string FormatIndentator
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the format output.
	/// </summary>
	/// <value>
	/// The format output.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x.")]
	[Browsable(false)]
	public bool FormatOutput
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the format source.
	/// </summary>
	/// <value>
	/// The format source.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x.")]
	[Browsable(false)]
	public bool FormatSource
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the custom configurations path.
	/// </summary>
	/// <value>
	/// The custom configurations path.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use CustomConfig instead.")]
	[Browsable(false)]
	public string CustomConfigurationsPath
	{
		set
		{
			CustomConfig = value;
		}
	}

	/// <summary>
	/// Sets the editor area CSS.
	/// </summary>
	/// <value>
	/// The editor area CSS.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use ContentsCss instead.")]
	[Browsable(false)]
	public string EditorAreaCSS
	{
		set
		{
			ContentsCss = value;
		}
	}

	/// <summary>
	/// Sets a value indicating whether [enable XHTML].
	/// </summary>
	/// <value>
	///   <c>true</c> if [enable XHTML]; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Not ported.")]
	[Browsable(false)]
	public bool EnableXHTML
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the font formats.
	/// </summary>
	/// <value>
	/// The font formats.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use FormatTags instead.")]
	[Browsable(false)]
	public string FontFormats
	{
		set
		{
			FormatTags = value;
		}
	}

	/// <summary>
	/// Sets a value indicating whether [gecko use SPAN].
	/// </summary>
	/// <value>
	///   <c>true</c> if [gecko use SPAN]; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use Style system instead. http://dev.ckeditor.com/ticket/1607")]
	[Browsable(false)]
	public bool GeckoUseSPAN
	{
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use FilebrowserImageBrowseUrl instead.")]
	[Browsable(false)]
	public string ImageBrowserURL
	{
		set
		{
			FilebrowserImageBrowseUrl = value;
		}
	}

	/// <summary>
	/// Sets the link browser URL.
	/// </summary>
	/// <value>
	/// The link browser URL.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use FilebrowserImageBrowseLinkUrl instead.")]
	[Browsable(false)]
	public string LinkBrowserURL
	{
		set
		{
			FilebrowserImageBrowseLinkUrl = value;
		}
	}

	/// <summary>
	/// Sets the plugins path.
	/// </summary>
	/// <value>
	/// The plugins path.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Not ported.")]
	[Browsable(false)]
	public string PluginsPath
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the skin path.
	/// </summary>
	/// <value>
	/// The skin path.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use Skin instead. Defaults to basedirectory/skin/name.")]
	[Browsable(false)]
	public string SkinPath
	{
		set
		{
			Skin = value;
		}
	}

	/// <summary>
	/// Sets the styles XML path.
	/// </summary>
	/// <value>
	/// The styles XML path.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Not ported.")]
	[Browsable(false)]
	public string StylesXmlPath
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets the toolbar set.
	/// </summary>
	/// <value>
	/// The toolbar set.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use Toolbar instead.")]
	[Browsable(false)]
	public string ToolbarSet
	{
		set
		{
		}
	}

	/// <summary>
	/// Sets a value indicating whether [toolbar start expanded].
	/// </summary>
	/// <value>
	/// 	<c>true</c> if [toolbar start expanded]; otherwise, <c>false</c>.
	/// </value>
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("Obsolete since CKEditor 3.x. Use ToolbarStartupExpanded instead.")]
	[Browsable(false)]
	public bool ToolbarStartExpanded
	{
		set
		{
			ToolbarStartupExpanded = value;
		}
	}

	/// <summary>
	///  Extra height in pixel to leave between the bottom boundary of content with document size when auto resizing.
	/// </summary>
	public int AutoGrowBottomSpace
	{
		set
		{
			if (SetConfigValue("autoGrow_bottomSpace", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The maximum height that the editor can reach using the AutoGrow feature. Zero means unlimited.
	/// </summary>
	public int AutoGrowMaxHeight
	{
		set
		{
			if (SetConfigValue("autoGrow_maxHeight", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The minimum height that the editor can reach using the AutoGrow feature.
	/// </summary>
	public int AutoGrowMinHeight
	{
		set
		{
			if (SetConfigValue("autoGrow_minHeight", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to have the auto grow happen on editor creation.
	/// </summary>
	public bool AutoGrowOnStartup
	{
		set
		{
			if (SetConfigValue("autoGrow_onStartup", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether automatically create wrapping blocks around inline contents inside document body.
	/// </summary>
	public bool AutoParagraph
	{
		set
		{
			if (SetConfigValue("autoParagraph", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool AutoUpdateElement
	{
		set
		{
			if (SetConfigValue("autoUpdateElement", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The base Z-index for floating dialog windows and popups.
	/// </summary>
	public int BaseFloatZIndex
	{
		set
		{
			if (SetConfigValue("baseFloatZIndex", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The base href URL used to resolve relative and absolute URLs in the editor content.
	/// </summary>
	public string BaseHref
	{
		set
		{
			if (SetConfigValue("baseHref", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to escape basic HTML entities in the document, including: nbsp gt lt amp. Note: It should not be subject to change unless when outputting a non-HTML data format like BBCode.
	/// </summary>
	public bool BasicEntities
	{
		set
		{
			if (SetConfigValue("basicEntities", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the class attribute to be used on the body element of the editing area.
	/// </summary>
	public string BodyClass
	{
		set
		{
			if (SetConfigValue("bodyClass", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the id attribute to be used on the body element of the editing area.
	/// </summary>
	public string BodyId
	{
		set
		{
			if (SetConfigValue("bodyId", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to show the browser native context menu when the Ctrl or Meta (Mac) key is pressed on opening the context menu with the right mouse button click or the Menu key.
	/// </summary>
	public bool BrowserContextMenuOnCtrl
	{
		set
		{
			if (SetConfigValue("browserContextMenuOnCtrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines the colors to be displayed in the color selectors. This is a string containing hexadecimal notation for HTML colors, without the '#' prefix.
	/// </summary>
	public string ColorButtonColors
	{
		set
		{
			if (SetConfigValue("colorButton_colors", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to enable the More Colors button in the color selectors.
	/// </summary>
	public bool ColorButtonEnableMore
	{
		set
		{
			if (SetConfigValue("colorButton_enableMore", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The CSS file(s) to be used to apply style to the contents.
	/// </summary>
	public string ContentsCss
	{
		set
		{
			if (SetConfigValue("contentsCss", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The writting direction of the language used to write the editor contents.
	/// </summary>
	public FCKeditorLanguageDirection ContentLangDirection
	{
		set
		{
			Config["contentsLangDirection"] = ((value == FCKeditorLanguageDirection.LeftToRight) ? "'ltr'" : "'rtl'");
		}
	}

	/// <summary>
	/// Language code of the writting language which is used to author the editor contents.
	/// </summary>
	public string ContentsLanguage
	{
		set
		{
			if (SetConfigValue("contentsLanguage", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The URL path for the custom configuration file to be loaded.
	/// </summary>
	public string CustomConfig
	{
		set
		{
			if (SetConfigValue("customConfig", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The characters to be used for indenting the HTML produced by the editor.
	/// </summary>
	public string DataIndentationChars
	{
		set
		{
			if (SetConfigValue("dataIndentationChars", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The language to be used if the language setting is left empty and it is not possible to localize the editor to the user language
	/// </summary>
	public string DefaultLanguage
	{
		set
		{
			if (SetConfigValue("defaultLanguage", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A setting that stores CSS rules to be injected into the page with styles to be applied to the tooltip element.
	/// </summary>
	public string DevtoolsStyles
	{
		set
		{
			if (SetConfigValue("devtools_styles", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The color of the dialog background cover.
	/// </summary>
	public string DialogBackgroundCoverColor
	{
		set
		{
			if (SetConfigValue("dialog_backgroundCoverColor", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The opacity of the dialog background cover.
	/// </summary>
	public int DialogBackgroundCoverOpacity
	{
		set
		{
			if (SetConfigValue("dialog_backgroundCoverOpacity", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The guideline to follow when generating the dialog buttons.
	/// </summary>
	public string DialogButtonsOrder
	{
		set
		{
			if (SetConfigValue("dialog_buttonsOrder", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The distance of magnetic borders used in moving and resizing dialogs, measured in pixels.
	/// </summary>
	public int DialogMagnetDistance
	{
		set
		{
			if (SetConfigValue("dialog_magnetDistance", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// If the dialog has more than one tab, put focus into the first tab as soon as dialog is opened.
	/// </summary>
	public bool DialogStartupFocusTab
	{
		set
		{
			if (SetConfigValue("dialog_startupFocusTab", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Disables the built-in words spell checker if browser provides one.
	/// </summary>
	public bool DisableNativeSpellChecker
	{
		set
		{
			if (SetConfigValue("disableNativeSpellChecker", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Disables the "table tools" offered natively by the browser (currently Firefox only) to make quick table editing operations, like adding or deleting rows and columns.
	/// </summary>
	public bool DisableNativeTableHandles
	{
		set
		{
			if (SetConfigValue("disableNativeTableHandles", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Disables the ability of resize objects (image and tables) in the editing area.
	/// </summary>
	public bool DisableObjectResizing
	{
		set
		{
			if (SetConfigValue("disableObjectResizing", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Disables inline styling on read-only elements.
	/// </summary>
	public bool DisableReadonlyStyling
	{
		set
		{
			if (SetConfigValue("disableReadonlyStyling", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool DivWrapTable
	{
		set
		{
			if (SetConfigValue("div_wrapTable", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the DOCTYPE to be used when loading the editor content as HTML.
	/// </summary>
	public string DocType
	{
		set
		{
			if (SetConfigValue("docType", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The e-mail address anti-spam protection option.
	/// </summary>
	public string EmailProtection
	{
		set
		{
			if (SetConfigValue("emailProtection", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	///
	/// </summary>
	public bool EnableTabKeyTools
	{
		set
		{
			if (SetConfigValue("enableTabKeyTools", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the behavior of the Enter key.
	/// </summary>
	public int EnterMode
	{
		set
		{
			if (SetConfigValue("enterMode", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to use HTML entities in the output.
	/// </summary>
	public bool Entities
	{
		set
		{
			if (SetConfigValue("entities", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A comma separated list of additional entities to be used.
	/// </summary>
	public string EntitiesAdditional
	{
		set
		{
			if (SetConfigValue("entities_additional", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to convert some symbols, mathematical symbols, and Greek letters to HTML entities.
	/// </summary>
	public bool EntitiesGreek
	{
		set
		{
			if (SetConfigValue("entities_greek", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to convert some Latin characters (Latin alphabet No. 1, ISO 8859-1) to HTML entities. The list of entities can be found in the W3C HTML 4.01 Specification, section 24.2.1.
	/// </summary>
	public bool EntitiesLatin
	{
		set
		{
			if (SetConfigValue("entities_latin", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to convert all remaining characters not included in the ASCII character table to their relative decimal numeric representation of HTML entity.
	/// </summary>
	public bool EntitiesProcessNumerical
	{
		set
		{
			if (SetConfigValue("entities_processNumerical", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A list of additional plugins to be loaded.
	/// </summary>
	public string ExtraPlugins
	{
		set
		{
			if (SetConfigValue("extraPlugins", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of an external file browser that should be launched when the Browse Server button is pressed.
	/// </summary>
	public string FilebrowserBrowseUrl
	{
		set
		{
			if (SetConfigValue("filebrowserBrowseUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of an external file browser that should be launched when the Browse Server button is pressed in the Flash dialog window.
	/// </summary>
	public string FilebrowserFlashBrowseUrl
	{
		set
		{
			if (SetConfigValue("filebrowserFlashBrowseUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of the script that handles file uploads in the Flash dialog window.
	/// </summary>
	public string FilebrowserFlashUploadUrl
	{
		set
		{
			if (SetConfigValue("filebrowserFlashUploadUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of an external file browser that should be launched when the Browse Server button is pressed in the Link tab of the Image dialog window.
	/// </summary>
	public string FilebrowserImageBrowseLinkUrl
	{
		set
		{
			if (SetConfigValue("filebrowserImageBrowseLinkUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of an external file browser that should be launched when the Browse Server button is pressed in the Image dialog window.
	/// </summary>
	public string FilebrowserImageBrowseUrl
	{
		set
		{
			if (SetConfigValue("filebrowserImageBrowseUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of the script that handles file uploads in the Image dialog window.
	/// </summary>
	public string FilebrowserImageUploadUrl
	{
		set
		{
			if (SetConfigValue("filebrowserImageUploadUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The location of the script that handles file uploads.
	/// </summary>
	public string FilebrowserUploadUrl
	{
		set
		{
			if (SetConfigValue("filebrowserUploadUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The features to use in the file browser popup window.
	/// </summary>
	public string FilebrowserWindowFeatures
	{
		set
		{
			if (SetConfigValue("filebrowserWindowFeatures", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The height of the file browser popup window. 
	/// </summary>
	public int FilebrowserWindowHeight
	{
		set
		{
			if (SetConfigValue("filebrowserWindowHeight", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The width of the file browser popup window.
	/// </summary>
	public int FilebrowserWindowWidth
	{
		set
		{
			if (SetConfigValue("filebrowserWindowWidth", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool FillEmptyBlocks
	{
		set
		{
			if (SetConfigValue("fillEmptyBlocks", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool FlashAddEmbedTag
	{
		set
		{
			if (SetConfigValue("flashAddEmbedTag", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Use flashEmbedTagOnly and flashAddEmbedTag values on edit.
	/// </summary>
	public bool FlashConvertOnEdit
	{
		set
		{
			if (SetConfigValue("flashConvertOnEdit", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool FlashEmbedTagOnly
	{
		set
		{
			if (SetConfigValue("flashEmbedTagOnly", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Along with floatSpaceDockedOffsetY it defines the amount of offset (in pixels) between float space and the editable left/right boundaries when space element is docked at either side of the editable.
	/// </summary>
	public int FloatSpaceDockedOffsetX
	{
		set
		{
			if (SetConfigValue("floatSpaceDockedOffsetX", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Along with floatSpaceDockedOffsetX it defines the amount of offset (in pixels) between float space and the editable top/bottom boundaries when space element is docked at either side of the editable.
	/// </summary>
	public int FloatSpaceDockedOffsetY
	{
		set
		{
			if (SetConfigValue("floatSpaceDockedOffsetY", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Along with floatSpacePinnedOffsetY it defines the amount of offset (in pixels) between float space and the view port boundaries when space element is pinned.
	/// </summary>
	public int FloatSpacePinnedOffsetX
	{
		set
		{
			if (SetConfigValue("floatSpacePinnedOffsetX", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Along with floatSpacePinnedOffsetX it defines the amount of offset (in pixels) between float space and the view port boundaries when space element is pinned.
	/// </summary>
	public int FloatSpacePinnedOffsetY
	{
		set
		{
			if (SetConfigValue("floatSpacePinnedOffsetY", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The text to be displayed in the Font Size combo is none of the available values matches the current cursor position or text selection.
	/// </summary>
	public string FontSizeDefaultLabel
	{
		set
		{
			if (SetConfigValue("fontSize_defaultLabel", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The list of fonts size to be displayed in the Font Size combo in the toolbar.
	/// </summary>
	public string FontSizes
	{
		set
		{
			if (SetConfigValue("fontSize_sizes", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The text to be displayed in the Font combo is none of the available values matches the current cursor position or text selection.
	/// </summary>
	public string FontDefaultLabel
	{
		set
		{
			if (SetConfigValue("font_defaultLabel", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The list of fonts names to be displayed in the Font combo in the toolbar.
	/// </summary>
	public string FontNames
	{
		set
		{
			if (SetConfigValue("font_names", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Force the use of enterMode as line break regardless of the context.
	/// </summary>
	public bool ForceEnterMode
	{
		set
		{
			if (SetConfigValue("forceEnterMode", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to force all pasting operations to insert on plain text into the editor, loosing any formatting information possibly available in the source text.
	/// </summary>
	public bool ForcePasteAsPlainText
	{
		set
		{
			if (SetConfigValue("forcePasteAsPlainText", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public bool ForceSimpleAmpersand
	{
		set
		{
			if (SetConfigValue("forceSimpleAmpersand", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A list of semi colon separated style names (by default tags) representing the style definition for each entry to be displayed in the Format combo in the toolbar. Each entry must have its relative definition configuration in a setting named 'format_(tagName)'. For example, the 'p' entry has its definition taken from config.format_p.
	/// </summary>
	public string FormatTags
	{
		set
		{
			if (SetConfigValue("format_tags", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Indicates whether the contents to be edited are being input as a full HTML page.
	/// </summary>
	public bool FullPage
	{
		set
		{
			if (SetConfigValue("fullPage", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to escape HTML when the editor updates the original input element.
	/// </summary>
	public bool HtmlEncodeOutput
	{
		set
		{
			if (SetConfigValue("htmlEncodeOutput", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether the editor must output an empty value ('') if it's contents is made by an empty paragraph only.
	/// </summary>
	public bool IgnoreEmptyParagraph
	{
		set
		{
			if (SetConfigValue("ignoreEmptyParagraph", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Padding text to set off the image in preview area.
	/// </summary>
	public string ImagePreviewText
	{
		set
		{
			if (SetConfigValue("image_previewText", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to remove links when emptying the link URL field in the image dialog.
	/// </summary>
	public bool ImageRemoveLinkByEmptyURL
	{
		set
		{
			if (SetConfigValue("image_removeLinkByEmptyURL", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Size of each indentation step.
	/// </summary>
	public int IndentOffset
	{
		set
		{
			if (SetConfigValue("indentOffset", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Unit for the indentation style.
	/// </summary>
	public string IndentUnit
	{
		set
		{
			if (SetConfigValue("indentUnit", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The user interface language localization to use.
	/// </summary>
	public string Language
	{
		set
		{
			if (SetConfigValue("language", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to show 'Advanced' tab.
	/// </summary>
	public bool LinkShowAdvancedTab
	{
		set
		{
			if (SetConfigValue("linkShowAdvancedTab", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>        
	///  Whether to show 'Target' tab
	///  </summary>       
	public bool LinkShowTargetTab
	{
		set
		{
			if (SetConfigValue("linkShowTargetTab", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines box color.
	/// </summary>
	public string MagiclineColor
	{
		set
		{
			if (SetConfigValue("magicline_color", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines the distance between mouse pointer and the box, within which the box stays revealed and no other focus space is offered to be accessed. The value is relative to magicline_triggerOffset.
	/// </summary>
	public int MagiclineHoldDistance
	{
		set
		{
			if (SetConfigValue("magicline_holdDistance", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines default keystroke that access the closest unreachable focus space after the caret (start of the selection).
	/// </summary>
	public int MagiclineKeystrokeNext
	{
		set
		{
			if (SetConfigValue("magicline_keystrokeNext", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines default keystroke that access the closest unreachable focus space before the caret (start of the selection). 
	/// </summary>
	public int MagiclineKeystrokePrevious
	{
		set
		{
			if (SetConfigValue("magicline_keystrokePrevious", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Activates plugin mode that considers all focus spaces between CKEDITOR.dtd.$block elements as accessible by the box.
	/// </summary>
	public bool MagiclinePutEverywhere
	{
		set
		{
			if (SetConfigValue("magicline_putEverywhere", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the default vertical distance between element edge and mouse pointer that causes the box to appear.
	/// </summary>
	public int MagiclineTriggerOffset
	{
		set
		{
			if (SetConfigValue("magicline_triggerOffset", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A comma separated list of items group names to be displayed in the context menu.
	/// </summary>
	public string MenuGroups
	{
		set
		{
			if (SetConfigValue("menu_groups", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The amount of time, in milliseconds, the editor waits before displaying submenu options when moving the mouse over options that contain submenus, like the "Cell Properties" entry for tables.
	/// </summary>
	public int MenuSubMenuDelay
	{
		set
		{
			if (SetConfigValue("menu_subMenuDelay", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The HTML to load in the editor when the "new page" command is executed.
	/// </summary>
	public string NewpageHtml
	{
		set
		{
			if (SetConfigValue("newpage_html", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The file that provides the MS Word cleanup function for pasting operations.
	/// </summary>
	public string PasteFromWordCleanupFile
	{
		set
		{
			if (SetConfigValue("pasteFromWordCleanupFile", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to transform MS Word outline numbered headings into lists.
	/// </summary>
	public bool PasteFromWordNumberedHeadingToList
	{
		set
		{
			if (SetConfigValue("pasteFromWordNumberedHeadingToList", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to prompt the user about the clean up of content being pasted from MS Word.
	/// </summary>
	public bool PasteFromWordPromptCleanup
	{
		set
		{
			if (SetConfigValue("pasteFromWordPromptCleanup", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to ignore all font related formatting styles, including: font size; font family; font foreground/background color.
	/// </summary>
	public bool PasteFromWordRemoveFontStyles
	{
		set
		{
			if (SetConfigValue("pasteFromWordRemoveFontStyles", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to remove element styles that can't be managed with the editor.
	/// </summary>
	public bool PasteFromWordRemoveStyles
	{
		set
		{
			if (SetConfigValue("pasteFromWordRemoveStyles", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Comma separated list of plugins to be used for an editor instance, besides, the actual plugins that to be loaded could be still affected by two other settings: extraPlugins and removePlugins.
	/// </summary>
	public string Plugins
	{
		set
		{
			if (SetConfigValue("plugins", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// If true, makes the editor start in read-only state.
	/// </summary>
	public bool ReadOnly
	{
		set
		{
			if (SetConfigValue("readOnly", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// List of toolbar button names that must not be rendered.
	/// </summary>
	public string RemoveButtons
	{
		set
		{
			if (SetConfigValue("removeButtons", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The dialog contents to removed.
	/// </summary>
	public string RemoveDialogTabs
	{
		set
		{
			if (SetConfigValue("removeDialogTabs", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A comma separated list of elements attributes to be removed when executing the remove format command.
	/// </summary>
	public string RemoveFormatAttributes
	{
		set
		{
			if (SetConfigValue("removeFormatAttributes", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A comma separated list of elements to be removed when executing the remove format command.
	/// </summary>
	public string RemoveFormatTags
	{
		set
		{
			if (SetConfigValue("removeFormatTags", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// A list of plugins that must not be loaded.
	/// </summary>
	public string RemovePlugins
	{
		set
		{
			if (SetConfigValue("removePlugins", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The dimensions for which the editor resizing is enabled.
	/// </summary>
	public string ResizeDir
	{
		set
		{
			if (SetConfigValue("resize_dir", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to enable the resizing feature.
	/// </summary>
	public bool ResizeEnabled
	{
		set
		{
			if (SetConfigValue("resize_enabled", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The maximum editor height, in pixels, when resizing the editor interface by using the resize handle.
	/// </summary>
	public int ResizeMaxHeight
	{
		set
		{
			if (SetConfigValue("resize_maxHeight", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The maximum editor width, in pixels, when resizing the editor interface by using the resize handle.
	/// </summary>
	public int ResizeMaxWidth
	{
		set
		{
			if (SetConfigValue("resize_maxWidth", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The minimum editor height, in pixels, when resizing the editor interface by using the resize handle.
	/// </summary>
	public int ResizeMinHeight
	{
		set
		{
			if (SetConfigValue("resize_minHeight", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The minimum editor width, in pixels, when resizing the editor interface by using the resize handle.
	/// </summary>
	public int ResizeMinWidth
	{
		set
		{
			if (SetConfigValue("resize_minWidth", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// If enabled (set to true), turns on SCAYT automatically after loading the editor.
	/// </summary>
	public bool ScaytAutoStartup
	{
		set
		{
			if (SetConfigValue("scayt_autoStartup", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Customizes the display of SCAYT context menu commands ("Add Word", "Ignore" and "Ignore All").
	/// </summary>
	public string ScaytContextCommands
	{
		set
		{
			if (SetConfigValue("scayt_contextCommands", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines the order SCAYT context menu items by groups.
	/// </summary>
	public string ScaytContextMenuItemsOrder
	{
		set
		{
			if (SetConfigValue("scayt_contextMenuItemsOrder", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Links SCAYT to custom dictionaries.
	/// </summary>
	public string ScaytCustomDictionaryIds
	{
		set
		{
			if (SetConfigValue("scayt_customDictionaryIds", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the customer ID for SCAYT.
	/// </summary>
	public string ScaytCustomerid
	{
		set
		{
			if (SetConfigValue("scayt_customerid", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Defines the number of SCAYT suggestions to show in the main context menu.
	/// </summary>
	public int ScaytMaxSuggestions
	{
		set
		{
			if (SetConfigValue("scayt_maxSuggestions", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Enables/disables the "More Suggestions" sub-menu in the context menu.
	/// </summary>
	public string ScaytMoreSuggestions
	{
		set
		{
			if (SetConfigValue("scayt_moreSuggestions", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the default spell checking language for SCAYT.
	/// </summary>
	public string ScaytSpellCheckLanguage
	{
		set
		{
			if (SetConfigValue("scayt_sLang", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the URL to SCAYT core.
	/// </summary>
	public string ScaytSrcUrl
	{
		set
		{
			if (SetConfigValue("scayt_srcUrl", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the visibility of particular tabs in the SCAYT dialog window and toolbar button.
	/// </summary>
	public string ScaytUiTabs
	{
		set
		{
			if (SetConfigValue("scayt_uiTabs", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Makes it possible to activate a custom dictionary in SCAYT.
	/// </summary>
	public string ScaytUserDictionaryName
	{
		set
		{
			if (SetConfigValue("scayt_userDictionaryName", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Similarly to the enterMode setting, it defines the behavior of the Shift+Enter key combination. 
	/// </summary>
	public int ShiftEnterMode
	{
		set
		{
			if (SetConfigValue("shiftEnterMode", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The editor skin name.
	/// </summary>
	public new string Skin
	{
		set
		{
			if (SetConfigValue("skin", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The number of columns to be generated by the smilies matrix.
	/// </summary>
	public int SmileyColumns
	{
		set
		{
			if (SetConfigValue("smiley_columns", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The base path used to build the URL for the smiley images.
	/// </summary>
	public string SmileyPath
	{
		set
		{
			if (SetConfigValue("smiley_path", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Controls CSS tab-size property of the sourcearea view.
	/// </summary>
	public int SourceAreaTabSize
	{
		set
		{
			if (SetConfigValue("sourceAreaTabSize", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets whether the editable should have the focus when editor is loading for the first time.
	/// </summary>
	public bool StartupFocus
	{
		set
		{
			if (SetConfigValue("startupFocus", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The mode to load at the editor startup.
	/// </summary>
	public string StartupMode
	{
		set
		{
			if (SetConfigValue("startupMode", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to automaticaly enable the show block command when the editor loads.
	/// </summary>
	public bool StartupOutlineBlocks
	{
		set
		{
			if (SetConfigValue("startupOutlineBlocks", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether to automatically enable the "show borders" command when the editor loads.
	/// </summary>
	public bool StartupShowBorders
	{
		set
		{
			if (SetConfigValue("startupShowBorders", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The "styles definition set" to use in the editor.
	/// </summary>
	public string StylesSet
	{
		set
		{
			if (SetConfigValue("stylesSet", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The editor tabindex value.
	/// </summary>
	public new int TabIndex
	{
		set
		{
			if (SetConfigValue("tabIndex", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	public int TabSpaces
	{
		set
		{
			if (SetConfigValue("tabSpaces", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The templates definition set to use.
	/// </summary>
	public string Templates
	{
		set
		{
			if (SetConfigValue("templates", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether the "Replace actual contents" checkbox is checked by default in the Templates dialog.
	/// </summary>
	public bool TemplatesReplaceContent
	{
		set
		{
			if (SetConfigValue("templates_replaceContent", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The toolbox (alias toolbar) definition.
	/// </summary>
	/// <value>
	/// The toolbar.
	/// </value>
	public string[] Toolbar
	{
		set
		{
			if (SetConfigValue("toolbar", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Sets the toolbar groups.
	/// </summary>
	/// <value>
	/// The toolbar groups.
	/// </value>
	public string[] ToolbarGroups
	{
		set
		{
			if (SetConfigValue("toolbarGroups", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether the toolbar can be collapsed by the user.
	/// </summary>
	public bool ToolbarCanCollapse
	{
		set
		{
			if (SetConfigValue("toolbarCanCollapse", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// When enabled, makes the arrow keys navigation cycle within the current toolbar group.
	/// </summary>
	public bool ToolbarGroupCycling
	{
		set
		{
			if (SetConfigValue("toolbarGroupCycling", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The "UI space" to which rendering the toolbar.
	/// </summary>
	public string ToolbarLocation
	{
		set
		{
			if (SetConfigValue("toolbarLocation", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Whether the toolbar must start expanded when the editor is loaded.
	/// </summary>
	public bool ToolbarStartupExpanded
	{
		set
		{
			if (SetConfigValue("toolbarStartupExpanded", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The base user interface color to be used by the editor.
	/// </summary>
	public string UiColor
	{
		set
		{
			if (SetConfigValue("uiColor", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// The number of undo steps to be saved.
	/// </summary>
	public int UndoStackSize
	{
		set
		{
			if (SetConfigValue("undoStackSize", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Indicates that some of the editor features, like alignment and text direction, should use the "computed value" of the feature to indicate its on/off state instead of using the "real value".
	/// </summary>
	public bool UseComputedState
	{
		set
		{
			if (SetConfigValue("useComputedState", value))
			{
				UpdateParams(AttributeType.Extended);
			}
		}
	}

	/// <summary>
	/// Occurs when the Value property changes.
	/// </summary>
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

	/// <summary>
	/// Occurs when [client value changed].
	/// </summary>
	[Description("Occurs when FCKEditor's value changed in client mode.")]
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

	/// <summary>
	/// Occurs when the Value property changes (Queued).
	/// </summary>
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

	/// <summary>
	/// Occurs when [save].
	/// </summary>
	public event EventHandler Save
	{
		add
		{
			AddHandler(SaveEvent, value);
		}
		remove
		{
			RemoveHandler(SaveEvent, value);
		}
	}

	/// <summary>
	/// Occurs when Save button is clicked.
	/// </summary>
	[Description("Occurs when FCKEditor's Save button is clicked in client mode.")]
	[Category("Client")]
	public event ClientEventHandler ClientSave
	{
		add
		{
			AddClientHandler("Save", value);
		}
		remove
		{
			RemoveClientHandler("Save", value);
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Extended.FCKEditor" /> class.
	/// </summary>
	public FCKEditor()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Renders the attributes.
	/// </summary>
	/// <param name="context">The context.</param>
	/// <param name="writer">The writer.</param>
	protected override void RenderAttributes(IContext context, IAttributeWriter writer)
	{
		base.RenderAttributes(context, writer);
		string text = BasePath;
		if (text.StartsWith("~"))
		{
			text = text.Replace("~", "../../../../../../../");
		}
		string text2 = "fckeditor.html";
		text = text + "editor/" + text2 + "?InstanceName=" + ClientID;
		writer.WriteAttributeString("ClientID", ClientID);
		writer.WriteAttributeString("UniqueID", UniqueID);
		writer.WriteAttributeText("VLB", Value, (TextFilter)7);
		writer.WriteAttributeString("SR", text);
		writer.WriteAttributeString("Config", Config.GetHiddenFieldString());
	}

	/// <summary>
	/// Renders updated attributes
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="lngRequestID"></param>
	protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
	{
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.Extended))
		{
			objWriter.WriteAttributeString("Config", Config.GetHiddenFieldString());
		}
	}

	/// <summary>
	/// Fires an event.
	/// </summary>
	/// <param name="objEvent">event.</param>
	protected override void FireEvent(IEvent objEvent)
	{
		string type = objEvent.Type;
		if (!(type == "ValueChange"))
		{
			if (type == "Save")
			{
				OnSave(EventArgs.Empty);
			}
			else
			{
				base.FireEvent(objEvent);
			}
		}
		else
		{
			mstrValue = CommonUtils.DecodeText(objEvent["VLB"]);
			OnValueChanged(EventArgs.Empty);
		}
	}

	/// <summary>
	/// Raises the <see cref="E:ValueChanged" /> event.
	/// </summary>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnValueChanged(EventArgs e)
	{
		ValueChangedHandler?.Invoke(this, e);
		ValueChangedQueuedHandler?.Invoke(this, e);
	}

	/// <summary>
	/// Raises the <see cref="E:ValueChanged" /> event.
	/// </summary>
	/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
	protected virtual void OnSave(EventArgs e)
	{
		SaveHandler?.Invoke(this, e);
	}

	/// <summary>
	/// Gets the critical events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalEventsData()
	{
		CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
		if (ValueChangedHandler != null)
		{
			criticalEventsData.Set("VC");
		}
		if (SaveHandler != null)
		{
			criticalEventsData.Set("SAV");
		}
		return criticalEventsData;
	}

	/// <summary>
	/// Gets the critical client events.
	/// </summary>
	/// <returns></returns>
	protected override CriticalEventsData GetCriticalClientEventsData()
	{
		CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
		if (HasClientHandler("ValueChange"))
		{
			criticalClientEventsData.Set("VC");
		}
		if (HasClientHandler("Save"))
		{
			criticalClientEventsData.Set("SAV");
		}
		return criticalClientEventsData;
	}

	/// <summary>
	/// Sets the config value.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="strKey">The STR key.</param>
	/// <param name="objValue">The obj value.</param>
	private bool SetConfigValue<T>(string strKey, T objValue)
	{
		string text = string.Empty;
		if (objValue is bool)
		{
			text = (Convert.ToBoolean(objValue) ? "true" : "false");
		}
		else if (objValue is string)
		{
			text = $"'{Convert.ToString(objValue)}'";
		}
		else if (objValue is string[])
		{
			if (objValue is string[] value)
			{
				text = string.Format("[{0}]", string.Join(",", value));
			}
		}
		else
		{
			text = Convert.ChangeType(objValue, typeof(string), CultureInfo.InvariantCulture) as string;
		}
		if (Config[strKey] != text)
		{
			Config[strKey] = text;
			return true;
		}
		return false;
	}

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	/// <summary>
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	}

	static FCKEditor()
	{
		ValueChangedEvent = SerializableEvent.Register("ValueChange", typeof(EventHandler), typeof(FCKEditor));
		ValueChangedQueuedEvent = SerializableEvent.Register("ValueChange", typeof(EventHandler), typeof(FCKEditor));
		SaveEvent = SerializableEvent.Register("Save", typeof(EventHandler), typeof(FCKEditor));
	}
}
