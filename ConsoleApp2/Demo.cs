using System;
using System.Globalization;
using System.Text;

namespace ConsoleApp2
{
	public class Demo
	{
		public bool CompareStrings()
		{
			var userName = "HariHaran";
			var accountName = "HariHaran";
			return string.Equals(userName, accountName, StringComparison.OrdinalIgnoreCase);
		}
		public bool CompareStringsWithToLower()
		{
			var userName = "HariHaran";
			var accountName = "HariHaran";
			return userName.ToLower() == accountName.ToLower();
		}

		public string StringBuilder()
		{
			var userName = "HariHaran";
			var age = 22;
			var builder = new StringBuilder();
			builder.Append("Name: ");
			builder.Append(userName);
			builder.Append(", Age: ");
			builder.Append(age);
			return builder.ToString();
		}

		public string StringInterpolation()
		{
			var userName = "HariHaran";
			var age = 22;
			return $"Name: {userName}, Age: {age}";
		}
	}
}
