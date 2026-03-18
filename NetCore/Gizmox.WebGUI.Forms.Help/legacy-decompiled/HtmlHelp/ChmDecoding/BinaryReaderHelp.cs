using System;
using System.Collections;
using System.IO;
using System.Text;

namespace HtmlHelp.ChmDecoding;

internal class BinaryReaderHelp
{
	internal static string ExtractString(ref BinaryReader binReader, int offset, bool noOffset, Encoding encoder)
	{
		string text = "";
		if (encoder == null)
		{
			encoder = Encoding.ASCII;
		}
		ArrayList arrayList = new ArrayList();
		if (!noOffset)
		{
			binReader.BaseStream.Seek(offset, SeekOrigin.Begin);
		}
		if (binReader.BaseStream.Position >= binReader.BaseStream.Length)
		{
			return "";
		}
		byte b = binReader.ReadByte();
		while (b != 0 && binReader.BaseStream.Position < binReader.BaseStream.Length)
		{
			arrayList.Add(b);
			b = binReader.ReadByte();
		}
		byte[] array = (byte[])arrayList.ToArray(Type.GetType("System.Byte"));
		return encoder.GetString(array, 0, array.Length);
	}

	internal static string ExtractString(ref BinaryReader binReader, int length, int offset, bool noOffset, Encoding encoder)
	{
		string text = "";
		if (length == 0)
		{
			return "";
		}
		if (encoder == null)
		{
			encoder = Encoding.ASCII;
		}
		ArrayList arrayList = new ArrayList();
		if (!noOffset)
		{
			binReader.BaseStream.Seek(offset, SeekOrigin.Begin);
		}
		if (binReader.BaseStream.Position >= binReader.BaseStream.Length)
		{
			return "";
		}
		byte b = binReader.ReadByte();
		while (b != 0 && arrayList.Count < length && binReader.BaseStream.Position < binReader.BaseStream.Length)
		{
			arrayList.Add(b);
			if (arrayList.Count < length)
			{
				b = binReader.ReadByte();
			}
		}
		byte[] array = (byte[])arrayList.ToArray(Type.GetType("System.Byte"));
		return encoder.GetString(array, 0, array.Length);
	}

	internal static string ExtractString(ref BinaryReader binReader, ref bool bFoundTerminator, int offset, bool noOffset, Encoding encoder)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		if (encoder == null)
		{
			encoder = Encoding.ASCII;
		}
		if (!noOffset)
		{
			binReader.BaseStream.Seek(offset, SeekOrigin.Begin);
		}
		if (binReader.BaseStream.Position >= binReader.BaseStream.Length)
		{
			return "";
		}
		byte b = binReader.ReadByte();
		while (b != 0 && binReader.BaseStream.Position < binReader.BaseStream.Length)
		{
			arrayList.Add(b);
			b = binReader.ReadByte();
			if (b == 0)
			{
				bFoundTerminator = true;
			}
		}
		byte[] array = (byte[])arrayList.ToArray(Type.GetType("System.Byte"));
		return encoder.GetString(array, 0, array.Length);
	}

	internal static string ExtractUTF16String(ref BinaryReader binReader, int offset, bool noOffset, Encoding encoder)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		int num = -1;
		if (!noOffset)
		{
			binReader.BaseStream.Seek(offset, SeekOrigin.Begin);
		}
		if (binReader.BaseStream.Position >= binReader.BaseStream.Length)
		{
			return "";
		}
		if (encoder == null)
		{
			encoder = Encoding.Unicode;
		}
		byte b = binReader.ReadByte();
		int num2 = 0;
		while ((b != 0 || num != 0) && binReader.BaseStream.Position < binReader.BaseStream.Length)
		{
			arrayList.Add(b);
			if (num2 % 2 == 0)
			{
				num = b;
			}
			b = binReader.ReadByte();
			num2++;
		}
		byte[] array = (byte[])arrayList.ToArray(Type.GetType("System.Byte"));
		int num3 = array.Length;
		if (num3 > 0 && num3 % 2 == 1 && array[num3 - 1] == 0)
		{
			num3--;
		}
		return Encoding.Unicode.GetString(array, 0, num3);
	}

	internal static long ReadENCINT(ref BinaryReader binReader)
	{
		long num = 0L;
		byte b = 0;
		int num2 = 0;
		if (binReader.BaseStream.Position >= binReader.BaseStream.Length)
		{
			return num;
		}
		do
		{
			b = binReader.ReadByte();
			num |= (long)(b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	internal static int ReadSRItem(byte[] wclBits, int s, int r, ref int nBitIndex)
	{
		int num = 0;
		int num2 = r;
		int num3 = 0;
		while (wclBits[nBitIndex++] == 1)
		{
			num3++;
		}
		if (num3 == 0)
		{
			int num4 = 0;
			for (int i = 0; i < num2; i++)
			{
				num4 |= (1 & wclBits[nBitIndex]) << num2 - i - 1;
				nBitIndex++;
			}
			return num4;
		}
		num2 += num3 - 1;
		int num5 = 0;
		int num6 = 0;
		for (int j = 0; j < num2; j++)
		{
			num5 |= (1 & wclBits[nBitIndex]) << num2 - j - 1;
			nBitIndex++;
		}
		for (int k = 0; k < r; k++)
		{
			num6 <<= 1;
			num6 |= 1;
		}
		num6++;
		num6 *= (int)Math.Pow(2.0, num3 - 1);
		return num6 + num5;
	}
}
