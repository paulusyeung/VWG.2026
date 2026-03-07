// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.FileDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Displays a dialog box from which the user can select a file.</summary>
  /// <filterpriority>1</filterpriority>
  [DefaultProperty("FileName")]
  [DefaultEvent("FileOk")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (FileDialogSkin))]
  [Serializable]
  public abstract class FileDialog : CommonDialog
  {
    /// <summary>Dialog bitmap options</summary>
    internal int mintOptions;
    /// <summary>The file dialog filter</summary>
    private string mstrFilter = string.Empty;
    /// <summary>Dialog title</summary>
    private string mstrTitle;
    /// <summary>The dialog default extention</summary>
    private string mstrDefaultExt;
    /// <summary>The dialog initial directory</summary>
    private string mstrInitialDir;
    /// <summary>Multi dotted extensions supported</summary>
    private bool mblnSupportMultiDottedExtensions;
    /// <summary>The maximum file size</summary>
    private int mintMaxFileSize = 4096;
    /// <summary>The files collection</summary>
    private FileHandleCollection mobjFilesList;

    /// <summary>Occurs when the user clicks on the Open or Save button on a file dialog box.</summary>
    [SRDescription("FDfileOkDescr")]
    public event CancelEventHandler FileOk;

    internal FileDialog() => this.Reset();

    /// <summary>Handler the dialog closing event</summary>
    /// <param name="e"></param>
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      if (this.DialogResult != DialogResult.OK)
        return;
      this.OnFileOk(new CancelEventArgs());
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.FileDialog.FileOk"></see> event.</summary>
    /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
    protected void OnFileOk(CancelEventArgs e)
    {
      CancelEventHandler fileOk = this.FileOk;
      if (fileOk == null)
        return;
      fileOk((object) this, e);
    }

    /// <summary>Resets all properties to their default values.</summary>
    public override void Reset()
    {
      this.mintOptions = -2147481596;
      this.mstrTitle = (string) null;
      this.mstrInitialDir = (string) null;
      this.mstrDefaultExt = (string) null;
      this.mstrFilter = "";
      this.mblnSupportMultiDottedExtensions = false;
      this.mobjFilesList = new FileHandleCollection();
    }

    /// <summary>Provides a string version of this object.</summary>
    /// <returns>A string version of this object.</returns>
    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder(base.ToString() + ": Title: " + this.Title + ", FileName: ");
      try
      {
        stringBuilder.Append(this.FileName);
      }
      catch (Exception ex)
      {
        stringBuilder.Append("<");
        stringBuilder.Append(ex.GetType().FullName);
        stringBuilder.Append(">");
      }
      return stringBuilder.ToString();
    }

    /// <summary>Sets a file dialog option</summary>
    /// <param name="intOption"></param>
    /// <param name="blnValue"></param>
    internal void SetOption(int intOption, bool blnValue)
    {
      if (blnValue)
        this.mintOptions |= intOption;
      else
        this.mintOptions &= ~intOption;
    }

    /// <summary>Gets a file dialog option</summary>
    /// <param name="intOption"></param>
    /// <returns></returns>
    internal bool GetOption(int intOption) => (this.mintOptions & intOption) != 0;

    /// <summary>Gets or sets a value indicating whether the dialog box automatically adds an extension to a file name if the user omits the extension.</summary>
    /// <returns>true if the dialog box adds an extension to a file name if the user omits the extension; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("FDaddExtensionDescr")]
    [DefaultValue(true)]
    public bool AddExtension
    {
      get => this.GetOption(int.MinValue);
      set => this.SetOption(int.MinValue, value);
    }

    /// <summary>
    /// Gets of sets the Maximum file size allowed in kilobytes.
    /// </summary>
    [DefaultValue(4096)]
    public int MaxFileSize
    {
      get => this.mintMaxFileSize;
      set => this.mintMaxFileSize = value;
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.</summary>
    /// <returns>true if the dialog box displays a warning if the user specifies a file name that does not exist; otherwise, false. The default value is false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("FDcheckFileExistsDescr")]
    public virtual bool CheckFileExists
    {
      get => this.GetOption(4096);
      set => this.SetOption(4096, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a path that does not exist.</summary>
    /// <returns>true if the dialog box displays a warning when the user specifies a path that does not exist; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("FDcheckPathExistsDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool CheckPathExists
    {
      get => this.GetOption(2048);
      set => this.SetOption(2048, value);
    }

    /// <summary>Gets or sets the default file name extension.</summary>
    /// <returns>The default file name extension. The returned string does not include the period. The default value is an empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue("")]
    [SRCategory("CatBehavior")]
    [SRDescription("FDdefaultExtDescr")]
    public string DefaultExt
    {
      get => this.mstrDefaultExt != null ? this.mstrDefaultExt : "";
      set
      {
        if (value != null)
        {
          if (value.StartsWith("."))
            value = value.Substring(1);
          else if (value.Length == 0)
            value = (string) null;
        }
        this.mstrDefaultExt = value;
      }
    }

    /// <summary>Gets or sets a value indicating whether the dialog box returns the location of the file referenced by the shortcut or whether it returns the location of the shortcut (.lnk).</summary>
    /// <returns>true if the dialog box returns the location of the file referenced by the shortcut; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("FDdereferenceLinksDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    public bool DereferenceLinks
    {
      get => !this.GetOption(1048576);
      set => this.SetOption(1048576, !value);
    }

    /// <summary>Gets or sets a string containing the file name selected in the file dialog box.</summary>
    /// <returns>The file name selected in the file dialog box. The default value is an empty string ("").</returns>
    [DefaultValue("")]
    [SRDescription("FDfileNameDescr")]
    [SRCategory("CatData")]
    public string FileName
    {
      get => this.File != null ? this.File.FileName : "";
      set
      {
        this.Files.Clear();
        if (value == null)
          return;
        this.Files.Add(value, (FileHandle) PhysicalFileHandle.Create(value));
      }
    }

    /// <summary>Gets the file names of all selected files in the dialog box.</summary>
    /// <returns>An array of type <see cref="T:System.String"></see>, containing the file names of all selected files in the dialog box.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("FDFileNamesDescr")]
    public string[] FileNames
    {
      get
      {
        string[] fileNames = new string[this.Files.Count];
        for (int index = 0; index < this.Files.Count; ++index)
          fileNames[index] = this.Files[index].FileName;
        return fileNames;
      }
    }

    /// <summary>Gets the current selected file</summary>
    [Browsable(false)]
    public FileHandle File => this.mobjFilesList.Count > 0 ? this.mobjFilesList[0] : (FileHandle) null;

    /// <summary>Gets the current selected files</summary>
    [Browsable(false)]
    public FileHandleCollection Files => this.mobjFilesList;

    /// <summary>Gets or sets the current file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box.</summary>
    /// <returns>The file filtering options available in the dialog box.</returns>
    /// <exception cref="T:System.ArgumentException">Filter format is invalid. </exception>
    [SRCategory("CatBehavior")]
    [DefaultValue("")]
    [Localizable(true)]
    [SRDescription("FDfilterDescr")]
    public string Filter
    {
      get => this.mstrFilter;
      set
      {
        if (!CommonUtils.IsNullOrEmpty(value))
        {
          string[] strArray = value.Split('|');
          if (strArray == null || strArray.Length % 2 != 0)
            throw new ArgumentException(SR.GetString("FileDialogInvalidFilter"));
        }
        this.mstrFilter = value;
      }
    }

    /// <summary>Gets or sets the index of the filter currently selected in the file dialog box.</summary>
    /// <returns>A value containing the index of the filter currently selected in the file dialog box. The default value is 1.</returns>
    [SRDescription("FDfilterIndexDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(1)]
    public int FilterIndex
    {
      get => 1;
      set
      {
      }
    }

    /// <summary>Gets or sets the initial directory displayed by the file dialog box.</summary>
    /// <returns>The initial directory displayed by the file dialog box. The default is an empty string ("").</returns>
    [DefaultValue("")]
    [SRCategory("CatData")]
    [SRDescription("FDinitialDirDescr")]
    public string InitialDirectory
    {
      get => this.mstrInitialDir != null ? this.mstrInitialDir : "";
      set => this.mstrInitialDir = value;
    }

    /// <summary>Gets values to initialize the <see cref="T:Gizmox.WebGUI.Forms.FileDialog"></see>.</summary>
    /// <returns>A bitwise combination of internal values that initializes the <see cref="T:Gizmox.WebGUI.Forms.FileDialog"></see>.</returns>
    protected int Options => this.mintOptions;

    /// <summary>Gets or sets a value indicating whether the dialog box restores the current directory before closing.</summary>
    /// <returns>true if the dialog box restores the current directory to its original value if the user changed the directory while searching for files; otherwise, false. The default value is false.</returns>
    [SRDescription("FDrestoreDirectoryDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool RestoreDirectory
    {
      get => this.GetOption(8);
      set => this.SetOption(8, value);
    }

    /// <summary>Gets or sets a value indicating whether the Help button is displayed in the file dialog box.</summary>
    /// <returns>true if the dialog box includes a help button; otherwise, false. The default value is false.</returns>
    [SRDescription("FDshowHelpDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool ShowHelp
    {
      get => this.GetOption(16);
      set => this.SetOption(16, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether [support multi dotted extensions].
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [support multi dotted extensions]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("FDsupportMultiDottedExtensionsDescr")]
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    public bool SupportMultiDottedExtensions
    {
      get => this.mblnSupportMultiDottedExtensions;
      set => this.mblnSupportMultiDottedExtensions = value;
    }

    /// <summary>Gets or sets the file dialog box title.</summary>
    /// <returns>The file dialog box title. The default value is an empty string ("").</returns>
    [DefaultValue("")]
    [Localizable(true)]
    [SRDescription("FDtitleDescr")]
    [SRCategory("CatAppearance")]
    public string Title
    {
      get => this.mstrTitle != null ? this.mstrTitle : string.Empty;
      set => this.mstrTitle = value;
    }

    /// <summary>Gets or sets a value indicating whether the dialog box accepts only valid Win32 file names.</summary>
    /// <returns>true if the dialog box accepts only valid Win32 file names; otherwise, false. The default value is true.</returns>
    [SRDescription("FDvalidateNamesDescr")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool ValidateNames
    {
      get => !this.GetOption(256);
      set => this.SetOption(256, !value);
    }
  }
}
