using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using HtmlHelp.ChmDecoding;

namespace HtmlHelp;

public class ChmFileInfo
{
	private string _chmFileName = "";

	private CHMFile _associatedFile = null;

	[Description("The full name of the loaded CHM file")]
	public string ChmFileName => _associatedFile.ChmFilePath;

	[Browsable(false)]
	public FileInfo FileInfo => new FileInfo(_associatedFile.ChmFilePath);

	[Description("The file version: 2 for compatibility=1.0, 3 for compatibility=1.1")]
	public int FileVersion
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.FileVersion;
			}
			return 0;
		}
	}

	[Description("The name of the sitemap contents file.")]
	public string ContentsFile
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.ContentsFile;
			}
			return "";
		}
	}

	[Description("The name of the sitemap index file.")]
	public string IndexFile
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.IndexFile;
			}
			return "";
		}
	}

	[Description("The url of the default topic. If emtpy, the first topic of the table of contents will be used.")]
	public string DefaultTopic
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.DefaultTopic;
			}
			return "";
		}
	}

	[Description("The title of the viewer window.")]
	public string HelpWindowTitle
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.HelpWindowTitle;
			}
			return "";
		}
	}

	[Description("A flag id DBCS is in use")]
	public bool DBCS
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.DBCS;
			}
			return false;
		}
	}

	[Description("A flag specifying if fulltext-search is supported.")]
	public bool FullTextSearch
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.FullTextSearch;
			}
			return false;
		}
	}

	[Description("A flag specifying if the CHM contains associative links (ALinks index).")]
	public bool HasALinks
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.HasALinks;
			}
			return false;
		}
	}

	[Description("A flag specifying if the CHM contains keyword links (KLinks index).")]
	public bool HasKLinks
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.HasKLinks;
			}
			return false;
		}
	}

	[Description("The name of the default window.")]
	public string DefaultWindow
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.DefaultWindow;
			}
			return "";
		}
	}

	[Description("The name of the compile file.")]
	public string CompileFile
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.CompileFile;
			}
			return "";
		}
	}

	[Description("A flag specifying if this CHM contains a binary index (false = text based sitemap index or none)")]
	public bool BinaryIndex
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.BinaryIndex;
			}
			return false;
		}
	}

	[Description("The version of the compiler with which this file was created.")]
	public string CompilerVersion
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.CompilerVersion;
			}
			return "";
		}
	}

	[Description("A flag specifying if the CHM contains a binary table of contents (false = text based sitemap toc or none)")]
	public bool BinaryTOC
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.BinaryTOC;
			}
			return false;
		}
	}

	[Description("The default font face.")]
	public string FontFace
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.FontFace;
			}
			return "";
		}
	}

	[Description("The default font size.")]
	public double FontSize
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.FontSize;
			}
			return 0.0;
		}
	}

	[Description("The default character set.")]
	public int CharacterSet
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.CharacterSet;
			}
			return 1;
		}
	}

	[Description("The default code page.")]
	public int CodePage
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.CodePage;
			}
			return 0;
		}
	}

	[Browsable(false)]
	public CultureInfo Culture
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.Culture;
			}
			return CultureInfo.CurrentCulture;
		}
	}

	[Description("The total number of topic nodes in this file (incl. table of contents and index).")]
	public int NumberOfTopicNodes
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.NumberOfTopicNodes;
			}
			return 0;
		}
	}

	[Description("The image list name.")]
	public string ImageList
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.ImageList;
			}
			return "";
		}
	}

	[Description("The background setting.")]
	public int Background
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.Background;
			}
			return 0;
		}
	}

	[Description("The foreground setting.")]
	public int Foreground
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.Foreground;
			}
			return 0;
		}
	}

	[Description("The frame name.")]
	public string FrameName
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.FrameName;
			}
			return "";
		}
	}

	[Description("The window name.")]
	public string WindowName
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.WindowName;
			}
			return "";
		}
	}

	[Description("The merged file list")]
	public string[] MergedFiles
	{
		get
		{
			if (_associatedFile != null)
			{
				return _associatedFile.MergedFiles;
			}
			return new string[0];
		}
	}

	public ChmFileInfo(string chmFile)
	{
		if (!File.Exists(chmFile))
		{
			throw new ArgumentException("Chm file must exist on disk !", "chmFileName");
		}
		if (!chmFile.ToLower().EndsWith(".chm"))
		{
			throw new ArgumentException("HtmlHelp file must have the extension .chm !", "chmFile");
		}
		_chmFileName = chmFile;
		_associatedFile = new CHMFile(null, chmFile, onlySystemData: true);
	}

	internal ChmFileInfo(CHMFile associatedFile)
	{
		_associatedFile = associatedFile;
		if (_associatedFile == null)
		{
			throw new ArgumentException("Associated CHMFile instance must not be null !", "associatedFile");
		}
	}
}
