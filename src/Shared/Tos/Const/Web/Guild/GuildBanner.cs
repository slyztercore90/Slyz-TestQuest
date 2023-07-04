using System.Linq;

namespace Melia.Shared.Tos.Const.Web.Guild
{
	public static class GuildBanner
	{
		public static bool IsValidImageFormat(byte[] image)
		{
			byte[] array = new byte[10];
			for (int i = 0; i < 10; i++)
			{
				array[i] = image[i];
			}
			byte[][] array2 = new byte[1][] { new byte[4] { 137, 80, 78, 71 } };
			foreach (byte[] array3 in array2)
			{
				if (array3.SequenceEqual(array.Take(array3.Length)))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsStandardSize(byte[] bytes, int fixWidth, int fixHeight)
		{
			byte[] array = new byte[8];
			for (int i = 16; i < 24; i++)
			{
				array[i - 16] = bytes[i];
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j <= 3; j++)
			{
				num = array[j] | (num << 8);
				num2 = array[j + 4] | (num2 << 8);
			}
			if (num == fixWidth && num2 == fixHeight)
			{
				return true;
			}
			return false;
		}
	}
}
