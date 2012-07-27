using System;
using System.Collections.Generic;
using System.Text;
using Kingdango.SaltedHashPassword;

namespace TestHarness
{
	class Program
	{
		static void Main(string[] args)
		{
			var password = new PasswordHash {Password = "This is a test password.", Salt = Convert.ToBase64String(SaltedHash.GenerateSalt(128))};

			Console.WriteLine(password.Salt);
			Console.WriteLine(password.GetHashedPassword());
			Console.ReadKey();
		}
	}
}
