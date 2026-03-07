using System;
using System.Collections.Generic;
using System.Text;
using PrintingDrawing = System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [DefaultProperty("DocumentName"), SRDescription("PrintDocumentDesc"), DefaultEvent("PrintPage")]
    public class PrintDocument : Component
    {
		#region Members

        private string mstrDocumentName = "this";
        private PrintingDrawing.PageSettings mobjDefaultPageSettings = null;
        private PrintingDrawing.PrinterSettings mobjPrinterSettings = null;
        private List<Bitmap> mobjBitmapsList = null;
        private Dictionary<PrintingDrawing.PrintPageEventArgs, Graphics> mobjGraphicsDictionary = null;
        private bool mblnUserSetPageSettings;

        private static readonly SerializableEvent BeginPrintEvent = SerializableEvent.Register("BeginPrint", typeof(PrintingDrawing.PrintEventHandler), typeof(PrintDocument));
        private static readonly SerializableEvent EndPrintEvent = SerializableEvent.Register("EndPrint", typeof(PrintingDrawing.PrintEventHandler), typeof(PrintDocument));
        private static readonly SerializableEvent PrintPageEvent = SerializableEvent.Register("PrintPage", typeof(PrintingDrawing.PrintPageEventHandler), typeof(PrintDocument));
        private static readonly SerializableEvent QueryPageSettingsEvent = SerializableEvent.Register("QueryPageSettings", typeof(PrintingDrawing.QueryPageSettingsEventHandler), typeof(PrintDocument));
        
		#endregion 

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintDocument"/> class.
        /// </summary>
        public PrintDocument()
        {
            this.mstrDocumentName = "document";
            this.mobjPrinterSettings = new PrintingDrawing.PrinterSettings();
            this.mobjDefaultPageSettings = new PrintingDrawing.PageSettings(this.mobjPrinterSettings);
        }

		#endregion Constructors 

		#region Properties

        /// <summary>
        /// Gets the bitmaps list.
        /// </summary>
        /// <value>The bitmaps list.</value>
        internal List<Bitmap> BitmapsList
        {
            get
            {
                if (mobjBitmapsList == null)
                {
                    mobjBitmapsList = new List<Bitmap>();
                }

                return mobjBitmapsList;
            }
        }

        /// <summary>
        /// Gets the graphics dictionary.
        /// </summary>
        /// <value>The graphics dictionary.</value>
        private Dictionary<PrintingDrawing.PrintPageEventArgs, Graphics> GraphicsDictionary
        {
            get
            {
                if (mobjGraphicsDictionary == null)
                {
                    mobjGraphicsDictionary = new Dictionary<PrintingDrawing.PrintPageEventArgs, Graphics>();
                }

                return mobjGraphicsDictionary;
            }
        }

        /// <summary>
        /// Gets the begin print handler.
        /// </summary>
        /// <value>The begin print handler.</value>
        private PrintingDrawing.PrintEventHandler BeginPrintHandler
        {
            get
            {
                return (PrintingDrawing.PrintEventHandler)this.GetHandler(PrintDocument.BeginPrintEvent);
            }
        }

        /// <summary>
        /// Gets or sets the default page settings.
        /// </summary>
        /// <value>The default page settings.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("PDOCdocumentPageSettingsDescr"), Browsable(false)]
        public PrintingDrawing.PageSettings DefaultPageSettings
        {
            get
            {
                return this.mobjDefaultPageSettings;
            }
            set
            {
                if (value == null)
                {
                    value = new PrintingDrawing.PageSettings();
                }
                this.mobjDefaultPageSettings = value;
                this.mblnUserSetPageSettings = true;
            }
        }
 
        /// <summary>
        /// Gets or sets the name of the this.
        /// </summary>
        /// <value>The name of the this.</value>
        [SRDescription("PDOCdocumentNameDescr"), DefaultValue("this")]
        public string DocumentName
        {
            get
            {
                return this.mstrDocumentName;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                this.mstrDocumentName = value;
            }
        }

        /// <summary>
        /// Gets the end print handler.
        /// </summary>
        /// <value>The end print handler.</value>
        private PrintingDrawing.PrintEventHandler EndPrintHandler
        {
            get
            {
                return (PrintingDrawing.PrintEventHandler)this.GetHandler(PrintDocument.EndPrintEvent);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [origin at margins].
        /// </summary>
        /// <value><c>true</c> if [origin at margins]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OriginAtMargins
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the print controller.
        /// </summary>
        /// <value>The print controller.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrintingDrawing.PrintController PrintController
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the printer settings.
        /// </summary>
        /// <value>The printer settings.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrintingDrawing.PrinterSettings PrinterSettings
        {
            get
            {
                return this.mobjPrinterSettings;
            }
            set
            {
                if (value == null)
                {
                    value = new PrintingDrawing.PrinterSettings();
                }
                this.mobjPrinterSettings = value;
                if (!this.mblnUserSetPageSettings)
                {
                    this.mobjDefaultPageSettings = this.mobjPrinterSettings.DefaultPageSettings;
                }
            }
        }


        /// <summary>
        /// Gets the print page handler.
        /// </summary>
        /// <value>The print page handler.</value>
        private PrintingDrawing.PrintPageEventHandler PrintPageHandler
        {
            get
            {
                return (PrintingDrawing.PrintPageEventHandler)this.GetHandler(PrintDocument.PrintPageEvent);
            }
        }

		#endregion Properties 

		#region Delegates and Events

        /// <summary>
        /// Occurs when [begin print].
        /// </summary>
        [SRDescription("PDOCbeginPrintDescr")]
        public event PrintingDrawing.PrintEventHandler BeginPrint
        {
            add
            {
                this.AddCriticalHandler(PrintDocument.BeginPrintEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(PrintDocument.BeginPrintEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [end print].
        /// </summary>
        [SRDescription("PDOCendPrintDescr")]
        public event PrintingDrawing.PrintEventHandler EndPrint
        {
            add
            {
                this.AddCriticalHandler(PrintDocument.EndPrintEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(PrintDocument.EndPrintEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [print page].
        /// </summary>
        [SRDescription("PDOCprintPageDescr")]
        public event PrintingDrawing.PrintPageEventHandler PrintPage
        {
            add
            {
                this.AddCriticalHandler(PrintDocument.PrintPageEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(PrintDocument.PrintPageEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [query page settings].
        /// </summary>
        [SRDescription("PDOCqueryPageSettingsDescr")]
        public event PrintingDrawing.QueryPageSettingsEventHandler QueryPageSettings
        {
            add
            {
                this.AddCriticalHandler(PrintDocument.QueryPageSettingsEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(PrintDocument.QueryPageSettingsEvent, value);
            }
        }

        /// <summary>
        /// Gets the begin print handler.
        /// </summary>
        /// <value>The begin print handler.</value>
        private PrintingDrawing.QueryPageSettingsEventHandler QueryPageSettingsHandler
        {
            get
            {
                return (PrintingDrawing.QueryPageSettingsEventHandler)this.GetHandler(PrintDocument.QueryPageSettingsEvent);
            }
        }

		#endregion Delegates and Events 

		#region Methods

        /// <summary>
        /// Prints this instance.
        /// </summary>
        public void Print()
        {
            ClearLists();

            PrintingDrawing.PrintEventArgs e = new PrintingDrawing.PrintEventArgs();

            // Handle the BeginPrint event.
            this.OnBeginPrint(e);

            // Check if print was canceled.
            if (e.Cancel)
            {
                // Handle the EndPrint event.
                this.OnEndPrint(e);
            }
            else
            {
                bool blnCancel = true;
                try
                {
                    // Perform print loop.
                    blnCancel = this.PrintLoop();
                }
                finally
                {
                    // Handle the EndPrint event.
                    this.OnEndPrint(e);

                    // Updfate cancel property.
                    e.Cancel = blnCancel | e.Cancel;
                }
            }
        }

        /// <summary>
        /// Clears the lists.
        /// </summary>
        private void ClearLists()
        {
            if (mobjBitmapsList != null)
            {
                mobjBitmapsList.Clear();
            }

            if (mobjGraphicsDictionary != null)
            {
                mobjGraphicsDictionary.Clear();
            }
        }

        /// <summary>
        /// Creates the print page event.
        /// </summary>
        /// <param name="objPageSettings">The obj page settings.</param>
        /// <returns></returns>
        private PrintingDrawing.PrintPageEventArgs CreatePrintPageEvent(PrintingDrawing.PageSettings objPageSettings)
        {
            Rectangle objBounds = Rectangle.Empty;

            // Try getting static context params.
            IContextParams objContextParams = VWGContext.Current as IContextParams;
            if (objContextParams != null)
            {
                // Build bounds as for screen available size.
                objBounds = new Rectangle(Point.Empty, new Size(objContextParams.ScreenAvailableWidth, objContextParams.ScreenAvailableHeight));
            }

            // Create a new bitmap based on bounds.
            Bitmap objBitmap = new Bitmap(objBounds.Width, objBounds.Height);

            // Create a new graphics based on bitmap.
            Graphics objGraphics = Graphics.FromImage(objBitmap);
            
            // Create a new print page events arguments.
            PrintingDrawing.PrintPageEventArgs objPrintPageEventArgs = new PrintingDrawing.PrintPageEventArgs(objGraphics, new Rectangle(0, 0, objBounds.Width, objBounds.Height), objBounds, objPageSettings);

            // Add bitmap to list.
            this.BitmapsList.Add(objBitmap);

            // Add graphics to dictionary.
            this.GraphicsDictionary.Add(objPrintPageEventArgs, objGraphics);

            // Return created print page events arguments.
            return objPrintPageEventArgs;
        }

        /// <summary>
        /// Prints in loop all pages.
        /// </summary>
        /// <returns></returns>
        private bool PrintLoop()
        {
            PrintingDrawing.PrintPageEventArgs objPrintPageEventArgs = null;
            PrintingDrawing.QueryPageSettingsEventArgs objQueryPageSettingsEventArgs = new PrintingDrawing.QueryPageSettingsEventArgs(this.DefaultPageSettings.Clone() as PrintingDrawing.PageSettings);

            do
            {
                // Handle the QueryPageSettings event.
                this.OnQueryPageSettings(objQueryPageSettingsEventArgs);

                // Check if print was canceled.
                if (objQueryPageSettingsEventArgs.Cancel)
                {
                    return true;
                }

                // Creates the print page event.
                objPrintPageEventArgs = this.CreatePrintPageEvent(objQueryPageSettingsEventArgs.PageSettings);

                try
                {
                    // Handle the PrintPage event.
                    this.OnPrintPage(objPrintPageEventArgs);
                }
                finally
                {
                    // Try getting graphics object by event arguments.
                    if (this.GraphicsDictionary.ContainsKey(objPrintPageEventArgs))
                    {
                        // Try getting graphics object by event arguments.
                        Graphics objCurrentGraphics = this.GraphicsDictionary[objPrintPageEventArgs];
                        if (objCurrentGraphics != null)
                        {
                            // Dispose graphics.
                            objCurrentGraphics.Dispose();
                        }

                        // Remove graphics from dictionary.
                        this.GraphicsDictionary.Remove(objPrintPageEventArgs);
                    }
                }

                // Check if print was canceled.
                if (objPrintPageEventArgs.Cancel)
                {
                    return true;
                }
            }
            // Loop while has more pages.
            while (objPrintPageEventArgs.HasMorePages);

            return false;
        }

        /// <summary>
        /// Toes the string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ("[PrintDocument " + this.DocumentName + "]");
        }

        /// <summary>
        /// Raises the <see cref="E:BeginPrint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnBeginPrint(PrintingDrawing.PrintEventArgs e)
        {
            // Raise event if needed
            PrintingDrawing.PrintEventHandler objEventHandler = this.BeginPrintHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:EndPrint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEndPrint(PrintingDrawing.PrintEventArgs e)
        {
            // Raise event if needed
            PrintingDrawing.PrintEventHandler objEventHandler = this.EndPrintHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:PrintPage"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPrintPage(PrintingDrawing.PrintPageEventArgs e)
        {
            // Raise event if needed
            PrintingDrawing.PrintPageEventHandler objEventHandler = this.PrintPageHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:QueryPageSettings"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Drawing.Printing.QueryPageSettingsEventArgs"/> instance containing the event data.</param>
        protected virtual void OnQueryPageSettings(PrintingDrawing.QueryPageSettingsEventArgs e)
        {
            // Raise event if needed
            PrintingDrawing.QueryPageSettingsEventHandler objEventHandler = this.QueryPageSettingsHandler;
            if (objEventHandler != null)
            {
                objEventHandler(this, e);
            }
        }

		#endregion Methods 
    }
}