using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;

namespace A;

internal class c2aee64b9953eb2782d163182e14d7764
{
	internal static byte[] ce041d9d9d766f6f8ac29991be74361c7(Stream ccb7baeed39ba4d8ba745f9cea1273fc3)
	{
		byte b = (byte)ccb7baeed39ba4d8ba745f9cea1273fc3.ReadByte();
		byte[] array = new byte[ccb7baeed39ba4d8ba745f9cea1273fc3.Length - 1];
		ccb7baeed39ba4d8ba745f9cea1273fc3.Read(array, 0, array.Length);
		if ((b & 1) != 0)
		{
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array2 = new byte[8];
			Buffer.BlockCopy(array, 0, array2, 0, 8);
			dESCryptoServiceProvider.IV = array2;
			byte[] array3 = new byte[8];
			Buffer.BlockCopy(array, 8, array3, 0, 8);
			bool flag = true;
			byte[] array4 = array3;
			for (int i = 0; i < array4.Length; i++)
			{
				if (array4[i] == 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					continue;
				}
				flag = false;
				break;
			}
			if (!flag)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				array3 = Assembly.GetExecutingAssembly().GetName().GetPublicKeyToken();
			}
			dESCryptoServiceProvider.Key = array3;
			array = dESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 16, array.Length - 16);
		}
		if ((b & 2) == 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream(array);
				DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
				MemoryStream memoryStream2 = new MemoryStream((int)memoryStream.Length * 2);
				int num = 1000;
				byte[] buffer = new byte[num];
				while (true)
				{
					int num2 = deflateStream.Read(buffer, 0, num);
					if (num2 <= 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						memoryStream2.Write(buffer, 0, num2);
					}
					if (num2 < num)
					{
						break;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				array = memoryStream2.ToArray();
			}
			catch (Exception)
			{
			}
		}
		return array;
	}
}
