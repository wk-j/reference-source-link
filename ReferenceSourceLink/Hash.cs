using System;
using System.Security.Cryptography;
using System.Text;

// https://github.com/KirillOsenkov/SourceBrowser/blob/85a396386d8a82490b8ab8784a2a04313ed51f68/src/HtmlGenerator/Utilities/Serialization.cs

namespace ReferenceSourceLink {
	public class Hash {

		public static string GetMD5Hash(string input, int digits) {
			using (var md5 = MD5.Create()) {
				var bytes = Encoding.UTF8.GetBytes(input);
				var hashBytes = md5.ComputeHash(bytes);
				return ByteArrayToHexString(hashBytes, digits);
			}
		}

		public static string ByteArrayToHexString(byte[] bytes, int digits = 0) {
			if (digits == 0) {
				digits = bytes.Length * 2;
			}

			char[] c = new char[digits];
			byte b;
			for (int i = 0; i < digits / 2; i++) {
				b = ((byte)(bytes[i] >> 4));
				c[i * 2] = (char)(b > 9 ? b + 87 : b + 0x30);
				b = ((byte)(bytes[i] & 0xF));
				c[i * 2 + 1] = (char)(b > 9 ? b + 87 : b + 0x30);
			}

			return new string(c);
		}
	}
}
