using System;
using System.Linq;

namespace SiGEv.Utils
{
	public class StringProtocol
	{
		private static Random random = new Random();

		public static string RandomString(int length=6)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
