Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Namespace CompanionKit.Controls.RibbonBar.ApplicationScenario

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TextEditingApplicationPage
        Inherits UserControl

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Visual WebGui UserControl Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the WebGui UserControl Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextEditingApplicationPage))
            Me.mobjMainRibbonBar = New Gizmox.WebGUI.Forms.RibbonBar()
            Me.ContextualTabGroup1 = New Gizmox.WebGUI.Forms.ContextualTabGroup()
            Me.mobjMessageRibbonBarPage = New Gizmox.WebGUI.Forms.RibbonBarPage()
            Me.mobjClipboardRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjBasicTextRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjNamesRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjAddressBookRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjCheckNamesRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjIncludeRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjAttachFileRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjAttachItemRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjBusinessCardRibbonBarDropDownButtonItem = New Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem()
            Me.mobjCalendarRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjSignatureRibbonBarDropDownButtonItem = New Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem()
            Me.mobjOptionsRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjFollowUpRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjOptionsRibbonBarStackItem = New Gizmox.WebGUI.Forms.RibbonBarStackItem()
            Me.mobjPermissionRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjHighImportanceRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjLowImportanceRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjProffingRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjFormatTextRibbonBarPage = New Gizmox.WebGUI.Forms.RibbonBarPage()
            Me.mobjFonRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjParagraphRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjZoomRibbonBarGroup = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjGroupedRibbonBarPage1 = New Gizmox.WebGUI.Forms.RibbonBarPage()
            Me.RibbonBarGroup1 = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjGroupedRibbonBarPage2 = New Gizmox.WebGUI.Forms.RibbonBarPage()
            Me.RibbonBarGroup2 = New Gizmox.WebGUI.Forms.RibbonBarGroup()
            Me.mobjQAButton1 = New Gizmox.WebGUI.Forms.ToolStripButton()
            Me.mobjQAButton2 = New Gizmox.WebGUI.Forms.ToolStripButton()
            Me.mobjStartMenuButton1 = New Gizmox.WebGUI.Forms.ToolStripButton()
            Me.mobjStartMenuButton2 = New Gizmox.WebGUI.Forms.ToolStripButton()
            Me.mobjStartMenuButton3 = New Gizmox.WebGUI.Forms.ToolStripButton()
            Me.mobjCutRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjCopyRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjFormatPainterRibbonBarButtonItem = New Gizmox.WebGUI.Forms.RibbonBarButtonItem()
            Me.mobjMessagePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjRichTextEditorPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjRichTextEditor = New Gizmox.WebGUI.Forms.RichTextEditor()
            Me.mobjAttachmentsContextMenu = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.mobjOpenSaveMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjRemoveMenuItem = New Gizmox.WebGUI.Forms.MenuItem()
            Me.mobjAccountsContextMenu = New Gizmox.WebGUI.Forms.ContextMenu()
            Me.mobjMainErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjMessagePanel.SuspendLayout()
            Me.mobjRichTextEditorPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjMainRibbonBar
            '
            Me.mobjMainRibbonBar.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMainRibbonBar.ContextualTabGroups.AddRange(New Gizmox.WebGUI.Forms.ContextualTabGroup() {Me.ContextualTabGroup1})
            Me.mobjMainRibbonBar.Location = New System.Drawing.Point(0, 0)
            Me.mobjMainRibbonBar.Name = "mobjMainRibbonBar"
            Me.mobjMainRibbonBar.Pages.Add(Me.mobjMessageRibbonBarPage)
            Me.mobjMainRibbonBar.Pages.Add(Me.mobjFormatTextRibbonBarPage)
            Me.mobjMainRibbonBar.Pages.Add(Me.mobjGroupedRibbonBarPage1)
            Me.mobjMainRibbonBar.Pages.Add(Me.mobjGroupedRibbonBarPage2)
            Me.mobjMainRibbonBar.QuickAccessToolBarItems.AddRange(New Gizmox.WebGUI.Forms.ToolStripItem() {Me.mobjQAButton1, Me.mobjQAButton2})
            Me.mobjMainRibbonBar.SelectedIndex = 0
            Me.mobjMainRibbonBar.ShowExpandButton = True
            Me.mobjMainRibbonBar.ShowQuickAccessToolbar = True
            Me.mobjMainRibbonBar.ShowStartButton = True
            Me.mobjMainRibbonBar.StartMenuProperties.LeftToolStripProperties.Items.AddRange(New Gizmox.WebGUI.Forms.ToolStripItem() {Me.mobjStartMenuButton1, Me.mobjStartMenuButton2, Me.mobjStartMenuButton3})
            Me.mobjMainRibbonBar.TabIndex = 0
            '
            'ContextualTabGroup1
            '
            Me.ContextualTabGroup1.Text = "Grouped Tabs"
            '
            'mobjMessageRibbonBarPage
            '
            Me.mobjMessageRibbonBarPage.AutoScroll = False
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjClipboardRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjBasicTextRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjNamesRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjIncludeRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjOptionsRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.Groups.Add(Me.mobjProffingRibbonBarGroup)
            Me.mobjMessageRibbonBarPage.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.[Default]
            Me.mobjMessageRibbonBarPage.Text = "Message"
            Me.mobjMessageRibbonBarPage.Visible = True
            '
            'mobjClipboardRibbonBarGroup
            '
            Me.mobjClipboardRibbonBarGroup.Text = "Clipboard"
            '
            'mobjBasicTextRibbonBarGroup
            '
            Me.mobjBasicTextRibbonBarGroup.Text = "Basic text"
            '
            'mobjNamesRibbonBarGroup
            '
            Me.mobjNamesRibbonBarGroup.Items.Add(Me.mobjAddressBookRibbonBarButtonItem)
            Me.mobjNamesRibbonBarGroup.Items.Add(Me.mobjCheckNamesRibbonBarButtonItem)
            Me.mobjNamesRibbonBarGroup.Text = "Names"
            '
            'mobjAddressBookRibbonBarButtonItem
            '
            Me.mobjAddressBookRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjAddressBookRibbonBarButtonItem.Enabled = False
            Me.mobjAddressBookRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjAddressBookRibbonBarButtonItem.Image"))
            Me.mobjAddressBookRibbonBarButtonItem.Text = "Address Book"
            '
            'mobjCheckNamesRibbonBarButtonItem
            '
            Me.mobjCheckNamesRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjCheckNamesRibbonBarButtonItem.Enabled = False
            Me.mobjCheckNamesRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjCheckNamesRibbonBarButtonItem.Image"))
            Me.mobjCheckNamesRibbonBarButtonItem.Text = "Check Names"
            '
            'mobjIncludeRibbonBarGroup
            '
            Me.mobjIncludeRibbonBarGroup.Items.Add(Me.mobjAttachFileRibbonBarButtonItem)
            Me.mobjIncludeRibbonBarGroup.Items.Add(Me.mobjAttachItemRibbonBarButtonItem)
            Me.mobjIncludeRibbonBarGroup.Items.Add(Me.mobjBusinessCardRibbonBarDropDownButtonItem)
            Me.mobjIncludeRibbonBarGroup.Items.Add(Me.mobjCalendarRibbonBarButtonItem)
            Me.mobjIncludeRibbonBarGroup.Items.Add(Me.mobjSignatureRibbonBarDropDownButtonItem)
            Me.mobjIncludeRibbonBarGroup.Text = "Include"
            '
            'mobjAttachFileRibbonBarButtonItem
            '
            Me.mobjAttachFileRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjAttachFileRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjAttachFileRibbonBarButtonItem.Image"))
            Me.mobjAttachFileRibbonBarButtonItem.Text = "Attach File"
            '
            'mobjAttachItemRibbonBarButtonItem
            '
            Me.mobjAttachItemRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjAttachItemRibbonBarButtonItem.Enabled = False
            Me.mobjAttachItemRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjAttachItemRibbonBarButtonItem.Image"))
            Me.mobjAttachItemRibbonBarButtonItem.Text = "Attach Item"
            '
            'mobjBusinessCardRibbonBarDropDownButtonItem
            '
            Me.mobjBusinessCardRibbonBarDropDownButtonItem.ClientAction = Nothing
            Me.mobjBusinessCardRibbonBarDropDownButtonItem.Enabled = False
            Me.mobjBusinessCardRibbonBarDropDownButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjBusinessCardRibbonBarDropDownButtonItem.Image"))
            Me.mobjBusinessCardRibbonBarDropDownButtonItem.Text = "Business Card"
            '
            'mobjCalendarRibbonBarButtonItem
            '
            Me.mobjCalendarRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjCalendarRibbonBarButtonItem.Enabled = False
            Me.mobjCalendarRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjCalendarRibbonBarButtonItem.Image"))
            Me.mobjCalendarRibbonBarButtonItem.Text = "Calendar"
            '
            'mobjSignatureRibbonBarDropDownButtonItem
            '
            Me.mobjSignatureRibbonBarDropDownButtonItem.ClientAction = Nothing
            Me.mobjSignatureRibbonBarDropDownButtonItem.Enabled = False
            Me.mobjSignatureRibbonBarDropDownButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjSignatureRibbonBarDropDownButtonItem.Image"))
            Me.mobjSignatureRibbonBarDropDownButtonItem.Text = "Signature"
            '
            'mobjOptionsRibbonBarGroup
            '
            Me.mobjOptionsRibbonBarGroup.Items.Add(Me.mobjFollowUpRibbonBarButtonItem)
            Me.mobjOptionsRibbonBarGroup.Items.Add(Me.mobjOptionsRibbonBarStackItem)
            Me.mobjOptionsRibbonBarGroup.Text = "Options"
            '
            'mobjFollowUpRibbonBarButtonItem
            '
            Me.mobjFollowUpRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjFollowUpRibbonBarButtonItem.Enabled = False
            Me.mobjFollowUpRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjFollowUpRibbonBarButtonItem.Image"))
            Me.mobjFollowUpRibbonBarButtonItem.Text = "Follow Up"
            '
            'mobjOptionsRibbonBarStackItem
            '
            Me.mobjOptionsRibbonBarStackItem.Items.Add(Me.mobjPermissionRibbonBarButtonItem)
            Me.mobjOptionsRibbonBarStackItem.Items.Add(Me.mobjHighImportanceRibbonBarButtonItem)
            Me.mobjOptionsRibbonBarStackItem.Items.Add(Me.mobjLowImportanceRibbonBarButtonItem)
            '
            'mobjPermissionRibbonBarButtonItem
            '
            Me.mobjPermissionRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjPermissionRibbonBarButtonItem.Enabled = False
            Me.mobjPermissionRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPermissionRibbonBarButtonItem.Image"))
            Me.mobjPermissionRibbonBarButtonItem.Text = "Permission"
            '
            'mobjHighImportanceRibbonBarButtonItem
            '
            Me.mobjHighImportanceRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjHighImportanceRibbonBarButtonItem.Enabled = False
            Me.mobjHighImportanceRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjHighImportanceRibbonBarButtonItem.Image"))
            Me.mobjHighImportanceRibbonBarButtonItem.Text = "High Importance"
            '
            'mobjLowImportanceRibbonBarButtonItem
            '
            Me.mobjLowImportanceRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjLowImportanceRibbonBarButtonItem.Enabled = False
            Me.mobjLowImportanceRibbonBarButtonItem.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjLowImportanceRibbonBarButtonItem.Image"))
            Me.mobjLowImportanceRibbonBarButtonItem.Text = "Low Importance"
            '
            'mobjProffingRibbonBarGroup
            '
            Me.mobjProffingRibbonBarGroup.Text = "Proofing"
            '
            'mobjFormatTextRibbonBarPage
            '
            Me.mobjFormatTextRibbonBarPage.AutoScroll = False
            Me.mobjFormatTextRibbonBarPage.Groups.Add(Me.mobjFonRibbonBarGroup)
            Me.mobjFormatTextRibbonBarPage.Groups.Add(Me.mobjParagraphRibbonBarGroup)
            Me.mobjFormatTextRibbonBarPage.Groups.Add(Me.mobjZoomRibbonBarGroup)
            Me.mobjFormatTextRibbonBarPage.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.[Default]
            Me.mobjFormatTextRibbonBarPage.Text = "Format Text"
            Me.mobjFormatTextRibbonBarPage.Visible = True
            '
            'mobjFonRibbonBarGroup
            '
            Me.mobjFonRibbonBarGroup.Text = "Font"
            '
            'mobjParagraphRibbonBarGroup
            '
            Me.mobjParagraphRibbonBarGroup.Text = "Paragraph"
            '
            'mobjZoomRibbonBarGroup
            '
            Me.mobjZoomRibbonBarGroup.Text = "Zoom"
            '
            'mobjGroupedRibbonBarPage1
            '
            Me.mobjGroupedRibbonBarPage1.AutoScroll = False
            Me.mobjGroupedRibbonBarPage1.ContextualTabGroup = Me.ContextualTabGroup1
            Me.mobjGroupedRibbonBarPage1.Groups.Add(Me.RibbonBarGroup1)
            Me.mobjGroupedRibbonBarPage1.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.[Default]
            Me.mobjGroupedRibbonBarPage1.Text = "Just Another Tab1"
            Me.mobjGroupedRibbonBarPage1.Visible = True
            '
            'mobjGroupedRibbonBarPage2
            '
            Me.mobjGroupedRibbonBarPage2.AutoScroll = False
            Me.mobjGroupedRibbonBarPage2.ContextualTabGroup = Me.ContextualTabGroup1
            Me.mobjGroupedRibbonBarPage2.Groups.Add(Me.RibbonBarGroup2)
            Me.mobjGroupedRibbonBarPage2.ScrollerType = Gizmox.WebGUI.Forms.ScrollerType.[Default]
            Me.mobjGroupedRibbonBarPage2.Text = "Just Another Tab2"
            Me.mobjGroupedRibbonBarPage2.Visible = True
            '
            'mobjQAButton1
            '
            Me.mobjQAButton1.Name = "mobjQAButton1"
            Me.mobjQAButton1.Size = New System.Drawing.Size(38, 17)
            Me.mobjQAButton1.Text = "Test1"
            '
            'mobjQAButton2
            '
            Me.mobjQAButton2.Name = "mobjQAButton2"
            Me.mobjQAButton2.Size = New System.Drawing.Size(38, 17)
            Me.mobjQAButton2.Text = "Test2"
            '
            'mobjStartMenuButton1
            '
            Me.mobjStartMenuButton1.Name = "mobjStartMenuButton1"
            Me.mobjStartMenuButton1.Size = New System.Drawing.Size(105, 17)
            Me.mobjStartMenuButton1.Tag = "1"
            Me.mobjStartMenuButton1.Text = "Start Menu Button1"
            '
            'mobjStartMenuButton2
            '
            Me.mobjStartMenuButton2.Name = "mobjStartMenuButton2"
            Me.mobjStartMenuButton2.Size = New System.Drawing.Size(105, 17)
            Me.mobjStartMenuButton2.Tag = "2"
            Me.mobjStartMenuButton2.Text = "Start Menu Button2"
            '
            'mobjStartMenuButton3
            '
            Me.mobjStartMenuButton3.Name = "mobjStartMenuButton3"
            Me.mobjStartMenuButton3.Size = New System.Drawing.Size(105, 17)
            Me.mobjStartMenuButton3.Tag = "3"
            Me.mobjStartMenuButton3.Text = "Start Menu Button3"
            '
            'mobjCutRibbonBarButtonItem
            '
            Me.mobjCutRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjCutRibbonBarButtonItem.Text = "Cut"
            '
            'mobjCopyRibbonBarButtonItem
            '
            Me.mobjCopyRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjCopyRibbonBarButtonItem.Text = "Copy"
            '
            'mobjFormatPainterRibbonBarButtonItem
            '
            Me.mobjFormatPainterRibbonBarButtonItem.ClientAction = Nothing
            Me.mobjFormatPainterRibbonBarButtonItem.Text = "Format Painter"
            '
            'mobjMessagePanel
            '
            Me.mobjMessagePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.mobjMessagePanel.Controls.Add(Me.mobjRichTextEditorPanel)
            Me.mobjMessagePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMessagePanel.Location = New System.Drawing.Point(0, 115)
            Me.mobjMessagePanel.Name = "mobjMessagePanel"
            Me.mobjMessagePanel.Size = New System.Drawing.Size(945, 367)
            Me.mobjMessagePanel.TabIndex = 1
            '
            'mobjRichTextEditorPanel
            '
            Me.mobjRichTextEditorPanel.Controls.Add(Me.mobjRichTextEditor)
            Me.mobjRichTextEditorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextEditorPanel.DockPadding.All = 5
            Me.mobjRichTextEditorPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjRichTextEditorPanel.Name = "mobjRichTextEditorPanel"
            Me.mobjRichTextEditorPanel.Padding = New Gizmox.WebGUI.Forms.Padding(5)
            Me.mobjRichTextEditorPanel.Size = New System.Drawing.Size(945, 367)
            Me.mobjRichTextEditorPanel.TabIndex = 1
            '
            'mobjRichTextEditor
            '
            Me.mobjRichTextEditor.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjRichTextEditor.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextEditor.Location = New System.Drawing.Point(5, 5)
            Me.mobjRichTextEditor.Name = "mobjRichTextEditor"
            Me.mobjRichTextEditor.Size = New System.Drawing.Size(935, 357)
            Me.mobjRichTextEditor.TabIndex = 0
            '
            'mobjAttachmentsContextMenu
            '
            Me.mobjAttachmentsContextMenu.MenuItems.AddRange(New Gizmox.WebGUI.Forms.MenuItem() {Me.mobjOpenSaveMenuItem, Me.mobjRemoveMenuItem})
            '
            'mobjOpenSaveMenuItem
            '
            Me.mobjOpenSaveMenuItem.Index = 0
            Me.mobjOpenSaveMenuItem.Tag = "OpenSave"
            Me.mobjOpenSaveMenuItem.Text = "Open / Save"
            '
            'mobjRemoveMenuItem
            '
            Me.mobjRemoveMenuItem.Index = 1
            Me.mobjRemoveMenuItem.Tag = "Remove"
            Me.mobjRemoveMenuItem.Text = "Remove"
            '
            'mobjMainErrorProvider
            '
            Me.mobjMainErrorProvider.BlinkRate = 3
            '
            'TextEditingApplicationPage
            '
            Me.Controls.Add(Me.mobjMessagePanel)
            Me.Controls.Add(Me.mobjMainRibbonBar)
            Me.Size = New System.Drawing.Size(945, 482)
            Me.Text = "TextEditingApplicationPage"
            Me.mobjMessagePanel.ResumeLayout(False)
            Me.mobjRichTextEditorPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjMainRibbonBar As Gizmox.WebGUI.Forms.RibbonBar
        Friend WithEvents mobjMessagePanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjAccountsContextMenu As Gizmox.WebGUI.Forms.ContextMenu
        Friend WithEvents mobjRichTextEditorPanel As Gizmox.WebGUI.Forms.Panel
        Friend WithEvents mobjRichTextEditor As Gizmox.WebGUI.Forms.RichTextEditor
        Friend WithEvents mobjMainErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Friend WithEvents mobjMessageRibbonBarPage As Gizmox.WebGUI.Forms.RibbonBarPage
        Friend WithEvents mobjClipboardRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjCutRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjCopyRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjFormatPainterRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjBasicTextRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjNamesRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjAddressBookRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjCheckNamesRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjOptionsRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjFollowUpRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjOptionsRibbonBarStackItem As Gizmox.WebGUI.Forms.RibbonBarStackItem
        Friend WithEvents mobjPermissionRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjHighImportanceRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjLowImportanceRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjProffingRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjIncludeRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjAttachFileRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjAttachItemRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjBusinessCardRibbonBarDropDownButtonItem As Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem
        Friend WithEvents mobjCalendarRibbonBarButtonItem As Gizmox.WebGUI.Forms.RibbonBarButtonItem
        Friend WithEvents mobjSignatureRibbonBarDropDownButtonItem As Gizmox.WebGUI.Forms.RibbonBarDropDownButtonItem
        Friend WithEvents mobjOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Friend WithEvents mobjAttachmentsContextMenu As Gizmox.WebGUI.Forms.ContextMenu
        Friend WithEvents mobjRemoveMenuItem As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents mobjOpenSaveMenuItem As Gizmox.WebGUI.Forms.MenuItem
        Friend WithEvents mobjFormatTextRibbonBarPage As Gizmox.WebGUI.Forms.RibbonBarPage
        Friend WithEvents mobjFonRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjParagraphRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjZoomRibbonBarGroup As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents ContextualTabGroup1 As Gizmox.WebGUI.Forms.ContextualTabGroup
        Friend WithEvents mobjGroupedRibbonBarPage1 As Gizmox.WebGUI.Forms.RibbonBarPage
        Friend WithEvents RibbonBarGroup1 As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjGroupedRibbonBarPage2 As Gizmox.WebGUI.Forms.RibbonBarPage
        Friend WithEvents RibbonBarGroup2 As Gizmox.WebGUI.Forms.RibbonBarGroup
        Friend WithEvents mobjQAButton1 As Gizmox.WebGUI.Forms.ToolStripButton
        Friend WithEvents mobjQAButton2 As Gizmox.WebGUI.Forms.ToolStripButton
        Friend WithEvents mobjStartMenuButton1 As Gizmox.WebGUI.Forms.ToolStripButton
        Friend WithEvents mobjStartMenuButton2 As Gizmox.WebGUI.Forms.ToolStripButton
        Friend WithEvents mobjStartMenuButton3 As Gizmox.WebGUI.Forms.ToolStripButton
    End Class

End Namespace