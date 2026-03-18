using System;

namespace HtmlHelp.ChmDecoding;

[Flags]
public enum DumpingFlags
{
	DumpTextTOC = 1,
	DumpBinaryTOC = 2,
	DumpTextIndex = 4,
	DumpBinaryIndex = 8,
	DumpStrings = 0x10,
	DumpUrlStr = 0x20,
	DumpUrlTbl = 0x40,
	DumpTopics = 0x80,
	DumpFullText = 0x100
}
