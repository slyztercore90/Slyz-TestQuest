using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Melia.Web.Util
{
	public static class FileUtils
	{
		public static string GetMd5Hash(byte[] input)
		{
			var md5 = MD5.Create();
			var array = md5.ComputeHash(input);
			var stringBuilder = new StringBuilder();

			for (var i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}

			return stringBuilder.ToString();
		}

		public static byte[] FileToByteArray(string fileName)
		{
			byte[] fileData = null;

			using (var fs = File.OpenRead(fileName))
			{
				using (var binaryReader = new BinaryReader(fs))
				{
					fileData = binaryReader.ReadBytes((int)fs.Length);
				}
			}
			return fileData;
		}
	}
}
