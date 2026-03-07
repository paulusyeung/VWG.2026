// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PrintDocument
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [DefaultProperty("DocumentName")]
  [SRDescription("PrintDocumentDesc")]
  [DefaultEvent("PrintPage")]
  [Serializable]
  public class PrintDocument : Component
  {
    private string mstrDocumentName = "this";
    private PageSettings mobjDefaultPageSettings;
    private PrinterSettings mobjPrinterSettings;
    private List<Bitmap> mobjBitmapsList;
    private Dictionary<PrintPageEventArgs, Graphics> mobjGraphicsDictionary;
    private bool mblnUserSetPageSettings;
    private static readonly SerializableEvent BeginPrintEvent = SerializableEvent.Register("BeginPrint", typeof (PrintEventHandler), typeof (PrintDocument));
    private static readonly SerializableEvent EndPrintEvent = SerializableEvent.Register("EndPrint", typeof (PrintEventHandler), typeof (PrintDocument));
    private static readonly SerializableEvent PrintPageEvent = SerializableEvent.Register("PrintPage", typeof (PrintPageEventHandler), typeof (PrintDocument));
    private static readonly SerializableEvent QueryPageSettingsEvent = SerializableEvent.Register("QueryPageSettings", typeof (QueryPageSettingsEventHandler), typeof (PrintDocument));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PrintDocument" /> class.
    /// </summary>
    public PrintDocument()
    {
      this.mstrDocumentName = "document";
      this.mobjPrinterSettings = new PrinterSettings();
      this.mobjDefaultPageSettings = new PageSettings(this.mobjPrinterSettings);
    }

    /// <summary>Gets the bitmaps list.</summary>
    /// <value>The bitmaps list.</value>
    internal List<Bitmap> BitmapsList
    {
      get
      {
        if (this.mobjBitmapsList == null)
          this.mobjBitmapsList = new List<Bitmap>();
        return this.mobjBitmapsList;
      }
    }

    /// <summary>Gets the graphics dictionary.</summary>
    /// <value>The graphics dictionary.</value>
    private Dictionary<PrintPageEventArgs, Graphics> GraphicsDictionary
    {
      get
      {
        if (this.mobjGraphicsDictionary == null)
          this.mobjGraphicsDictionary = new Dictionary<PrintPageEventArgs, Graphics>();
        return this.mobjGraphicsDictionary;
      }
    }

    /// <summary>Gets the begin print handler.</summary>
    /// <value>The begin print handler.</value>
    private PrintEventHandler BeginPrintHandler => (PrintEventHandler) this.GetHandler(PrintDocument.BeginPrintEvent);

    /// <summary>Gets or sets the default page settings.</summary>
    /// <value>The default page settings.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("PDOCdocumentPageSettingsDescr")]
    [Browsable(false)]
    public PageSettings DefaultPageSettings
    {
      get => this.mobjDefaultPageSettings;
      set
      {
        if (value == null)
          value = new PageSettings();
        this.mobjDefaultPageSettings = value;
        this.mblnUserSetPageSettings = true;
      }
    }

    /// <summary>Gets or sets the name of the this.</summary>
    /// <value>The name of the this.</value>
    [SRDescription("PDOCdocumentNameDescr")]
    [DefaultValue("this")]
    public string DocumentName
    {
      get => this.mstrDocumentName;
      set
      {
        if (value == null)
          value = string.Empty;
        this.mstrDocumentName = value;
      }
    }

    /// <summary>Gets the end print handler.</summary>
    /// <value>The end print handler.</value>
    private PrintEventHandler EndPrintHandler => (PrintEventHandler) this.GetHandler(PrintDocument.EndPrintEvent);

    /// <summary>
    /// Gets or sets a value indicating whether [origin at margins].
    /// </summary>
    /// <value><c>true</c> if [origin at margins]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool OriginAtMargins
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the print controller.</summary>
    /// <value>The print controller.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PrintController PrintController
    {
      get => (PrintController) null;
      set
      {
      }
    }

    /// <summary>Gets or sets the printer settings.</summary>
    /// <value>The printer settings.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public PrinterSettings PrinterSettings
    {
      get => this.mobjPrinterSettings;
      set
      {
        if (value == null)
          value = new PrinterSettings();
        this.mobjPrinterSettings = value;
        if (this.mblnUserSetPageSettings)
          return;
        this.mobjDefaultPageSettings = this.mobjPrinterSettings.DefaultPageSettings;
      }
    }

    /// <summary>Gets the print page handler.</summary>
    /// <value>The print page handler.</value>
    private PrintPageEventHandler PrintPageHandler => (PrintPageEventHandler) this.GetHandler(PrintDocument.PrintPageEvent);

    /// <summary>Occurs when [begin print].</summary>
    [SRDescription("PDOCbeginPrintDescr")]
    public event PrintEventHandler BeginPrint
    {
      add => this.AddCriticalHandler(PrintDocument.BeginPrintEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(PrintDocument.BeginPrintEvent, (Delegate) value);
    }

    /// <summary>Occurs when [end print].</summary>
    [SRDescription("PDOCendPrintDescr")]
    public event PrintEventHandler EndPrint
    {
      add => this.AddCriticalHandler(PrintDocument.EndPrintEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(PrintDocument.EndPrintEvent, (Delegate) value);
    }

    /// <summary>Occurs when [print page].</summary>
    [SRDescription("PDOCprintPageDescr")]
    public event PrintPageEventHandler PrintPage
    {
      add => this.AddCriticalHandler(PrintDocument.PrintPageEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(PrintDocument.PrintPageEvent, (Delegate) value);
    }

    /// <summary>Occurs when [query page settings].</summary>
    [SRDescription("PDOCqueryPageSettingsDescr")]
    public event QueryPageSettingsEventHandler QueryPageSettings
    {
      add => this.AddCriticalHandler(PrintDocument.QueryPageSettingsEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(PrintDocument.QueryPageSettingsEvent, (Delegate) value);
    }

    /// <summary>Gets the begin print handler.</summary>
    /// <value>The begin print handler.</value>
    private QueryPageSettingsEventHandler QueryPageSettingsHandler => (QueryPageSettingsEventHandler) this.GetHandler(PrintDocument.QueryPageSettingsEvent);

    /// <summary>Prints this instance.</summary>
    public void Print()
    {
      this.ClearLists();
      PrintEventArgs e = new PrintEventArgs();
      this.OnBeginPrint(e);
      if (e.Cancel)
      {
        this.OnEndPrint(e);
      }
      else
      {
        bool flag = true;
        try
        {
          flag = this.PrintLoop();
        }
        finally
        {
          this.OnEndPrint(e);
          e.Cancel = flag | e.Cancel;
        }
      }
    }

    /// <summary>Clears the lists.</summary>
    private void ClearLists()
    {
      if (this.mobjBitmapsList != null)
        this.mobjBitmapsList.Clear();
      if (this.mobjGraphicsDictionary == null)
        return;
      this.mobjGraphicsDictionary.Clear();
    }

    /// <summary>Creates the print page event.</summary>
    /// <param name="objPageSettings">The obj page settings.</param>
    /// <returns></returns>
    private PrintPageEventArgs CreatePrintPageEvent(PageSettings objPageSettings)
    {
      Rectangle pageBounds = Rectangle.Empty;
      if (VWGContext.Current is IContextParams current)
        pageBounds = new Rectangle(Point.Empty, new Size(current.ScreenAvailableWidth, current.ScreenAvailableHeight));
      Bitmap bitmap = new Bitmap(pageBounds.Width, pageBounds.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      PrintPageEventArgs key = new PrintPageEventArgs(graphics, new Rectangle(0, 0, pageBounds.Width, pageBounds.Height), pageBounds, objPageSettings);
      this.BitmapsList.Add(bitmap);
      this.GraphicsDictionary.Add(key, graphics);
      return key;
    }

    /// <summary>Prints in loop all pages.</summary>
    /// <returns></returns>
    private bool PrintLoop()
    {
      QueryPageSettingsEventArgs e = new QueryPageSettingsEventArgs(this.DefaultPageSettings.Clone() as PageSettings);
      PrintPageEventArgs printPageEvent;
      do
      {
        this.OnQueryPageSettings(e);
        if (e.Cancel)
          return true;
        printPageEvent = this.CreatePrintPageEvent(e.PageSettings);
        try
        {
          this.OnPrintPage(printPageEvent);
        }
        finally
        {
          if (this.GraphicsDictionary.ContainsKey(printPageEvent))
          {
            this.GraphicsDictionary[printPageEvent]?.Dispose();
            this.GraphicsDictionary.Remove(printPageEvent);
          }
        }
        if (printPageEvent.Cancel)
          return true;
      }
      while (printPageEvent.HasMorePages);
      return false;
    }

    /// <summary>Toes the string.</summary>
    /// <returns></returns>
    public override string ToString() => "[PrintDocument " + this.DocumentName + "]";

    /// <summary>
    /// Raises the <see cref="E:BeginPrint" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Drawing.Printing.PrintEventArgs" /> instance containing the event data.</param>
    protected virtual void OnBeginPrint(PrintEventArgs e)
    {
      PrintEventHandler beginPrintHandler = this.BeginPrintHandler;
      if (beginPrintHandler == null)
        return;
      beginPrintHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:EndPrint" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Drawing.Printing.PrintEventArgs" /> instance containing the event data.</param>
    protected virtual void OnEndPrint(PrintEventArgs e)
    {
      PrintEventHandler endPrintHandler = this.EndPrintHandler;
      if (endPrintHandler == null)
        return;
      endPrintHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:PrintPage" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Drawing.Printing.PrintPageEventArgs" /> instance containing the event data.</param>
    protected virtual void OnPrintPage(PrintPageEventArgs e)
    {
      PrintPageEventHandler printPageHandler = this.PrintPageHandler;
      if (printPageHandler == null)
        return;
      printPageHandler((object) this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:QueryPageSettings" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.Drawing.Printing.QueryPageSettingsEventArgs" /> instance containing the event data.</param>
    protected virtual void OnQueryPageSettings(QueryPageSettingsEventArgs e)
    {
      QueryPageSettingsEventHandler pageSettingsHandler = this.QueryPageSettingsHandler;
      if (pageSettingsHandler == null)
        return;
      pageSettingsHandler((object) this, e);
    }
  }
}
