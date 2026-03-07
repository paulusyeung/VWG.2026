// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataFormats
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides static, predefined <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format names. Use them to identify the format of data that you store in an <see cref="T:Gizmox.WebGUI.Forms.IDataObject"></see>.</summary>
  /// <filterpriority>2</filterpriority>
  [System.Serializable]
  public class DataFormats
  {
    /// <summary>Specifies a Windows bitmap format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Bitmap;
    /// <summary>Specifies a comma-separated value (CSV) format, which is a common interchange format used by spreadsheets. This format is not used directly by Windows Forms. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string CommaSeparatedValue;
    /// <summary>Specifies the Windows device-independent bitmap (DIB) format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Dib;
    /// <summary>Specifies the Windows Data Interchange Format (DIF), which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Dif;
    /// <summary>Specifies the Windows enhanced metafile format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string EnhancedMetafile;
    /// <summary>Specifies the Windows file drop format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string FileDrop;
    /// <summary>Specifies text consisting of HTML data. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Html;
    /// <summary>Specifies the Windows culture format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Locale;
    /// <summary>Specifies the Windows metafile format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string MetafilePict;
    /// <summary>Specifies the standard Windows original equipment manufacturer (OEM) text format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string OemText;
    /// <summary>Specifies the Windows palette format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Palette;
    /// <summary>Specifies the Windows pen data format, which consists of pen strokes for handwriting software; Windows Forms does not use this format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string PenData;
    /// <summary>Specifies the Resource Interchange File Format (RIFF) audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Riff;
    /// <summary>Specifies text consisting of Rich Text Format (RTF) data. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Rtf;
    /// <summary>Specifies a format that encapsulates any type of Windows Forms object. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Serializable;
    /// <summary>Specifies the Windows Forms string class format, which Windows Forms uses to store string objects. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string StringFormat;
    /// <summary>Specifies the Windows symbolic link format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string SymbolicLink;
    /// <summary>Specifies the standard ANSI text format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Text = nameof (Text);
    /// <summary>Specifies the Tagged Image File Format (TIFF), which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string Tiff;
    /// <summary>Specifies the standard Windows Unicode text format. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string UnicodeText = nameof (UnicodeText);
    /// <summary>Specifies the wave audio format, which Windows Forms does not directly use. This static field is read-only.</summary>
    /// <filterpriority>1</filterpriority>
    public static readonly string WaveAudio;
    private static int mintFormatCount;
    private static DataFormats.Format[] marrFormatList;
    private static object mobjInternalSyncObject;

    static DataFormats()
    {
      DataFormats.Dib = "DeviceIndependentBitmap";
      DataFormats.Bitmap = nameof (Bitmap);
      DataFormats.EnhancedMetafile = nameof (EnhancedMetafile);
      DataFormats.MetafilePict = "MetaFilePict";
      DataFormats.SymbolicLink = nameof (SymbolicLink);
      DataFormats.Dif = "DataInterchangeFormat";
      DataFormats.Tiff = "TaggedImageFileFormat";
      DataFormats.OemText = "OEMText";
      DataFormats.Palette = nameof (Palette);
      DataFormats.PenData = nameof (PenData);
      DataFormats.Riff = "RiffAudio";
      DataFormats.WaveAudio = nameof (WaveAudio);
      DataFormats.FileDrop = nameof (FileDrop);
      DataFormats.Locale = nameof (Locale);
      DataFormats.Html = "HTML Format";
      DataFormats.Rtf = "Rich Text Format";
      DataFormats.CommaSeparatedValue = "Csv";
      DataFormats.StringFormat = typeof (string).FullName;
      DataFormats.mintFormatCount = 0;
      DataFormats.mobjInternalSyncObject = new object();
    }

    private DataFormats()
    {
    }

    private static void EnsureFormatSpace(int intSize)
    {
      if (DataFormats.marrFormatList != null && DataFormats.marrFormatList.Length > DataFormats.mintFormatCount + intSize)
        return;
      DataFormats.Format[] formatArray = new DataFormats.Format[DataFormats.mintFormatCount + 20];
      for (int index = 0; index < DataFormats.mintFormatCount; ++index)
        formatArray[index] = DataFormats.marrFormatList[index];
      DataFormats.marrFormatList = formatArray;
    }

    private static void EnsurePredefined()
    {
      if (DataFormats.mintFormatCount != 0)
        return;
      DataFormats.marrFormatList = new DataFormats.Format[16]
      {
        new DataFormats.Format(DataFormats.UnicodeText, 13),
        new DataFormats.Format(DataFormats.Text, 1),
        new DataFormats.Format(DataFormats.Bitmap, 2),
        new DataFormats.Format(DataFormats.MetafilePict, 3),
        new DataFormats.Format(DataFormats.EnhancedMetafile, 14),
        new DataFormats.Format(DataFormats.Dif, 5),
        new DataFormats.Format(DataFormats.Tiff, 6),
        new DataFormats.Format(DataFormats.OemText, 7),
        new DataFormats.Format(DataFormats.Dib, 8),
        new DataFormats.Format(DataFormats.Palette, 9),
        new DataFormats.Format(DataFormats.PenData, 10),
        new DataFormats.Format(DataFormats.Riff, 11),
        new DataFormats.Format(DataFormats.WaveAudio, 12),
        new DataFormats.Format(DataFormats.SymbolicLink, 4),
        new DataFormats.Format(DataFormats.FileDrop, 15),
        new DataFormats.Format(DataFormats.Locale, 16)
      };
      DataFormats.mintFormatCount = DataFormats.marrFormatList.Length;
    }

    /// <summary>Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified ID.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
    /// <param name="id">The format ID. </param>
    /// <filterpriority>1</filterpriority>
    public static DataFormats.Format GetFormat(int id) => (DataFormats.Format) null;

    /// <summary>Returns a <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> with the Windows Clipboard numeric ID and name for the specified format.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> that has the Windows Clipboard numeric ID and the name of the format.</returns>
    /// <param name="strFormat">The format name. </param>
    /// <exception cref="T:System.ComponentModel.Win32Exception">Registering a new <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> format failed. </exception>
    /// <filterpriority>1</filterpriority>
    public static DataFormats.Format GetFormat(string strFormat) => (DataFormats.Format) null;

    /// <summary>Represents a Clipboard format type.</summary>
    [System.Serializable]
    public class Format
    {
      private readonly int mintId;
      private readonly string mstrName;

      /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataFormats.Format"></see> class with a Boolean that indicates whether a Win32 handle is expected.</summary>
      /// <param name="strName">The name of this format. </param>
      /// <param name="intId">The ID number for this format. </param>
      public Format(string strName, int intId)
      {
        this.mstrName = strName;
        this.mintId = intId;
      }

      /// <summary>Gets the ID number for this format.</summary>
      /// <returns>The ID number for this format.</returns>
      public int Id => this.mintId;

      /// <summary>Gets the name of this format.</summary>
      /// <returns>The name of this format.</returns>
      public string Name => this.mstrName;
    }
  }
}
