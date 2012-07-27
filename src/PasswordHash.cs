using System;
using System.Runtime.InteropServices;

namespace Kingdango.SaltedHashPassword
{
	/// <summary>
	/// COM Wrapper Class intended to expose .NET AES hashing algorythms to classic ASP websites
	/// </summary>
	[Guid("E60E1E21-AB06-43BA-8788-5F10D5FED5CF")]
	[ClassInterface(ClassInterfaceType.None)]
	public class PasswordHash : IPasswordHash
	{
		public string Password { get; set; }

		public string Salt { get; set; }

		/// <summary>
		/// COM Interop only supports default constructor
		/// </summary>
		public PasswordHash()
		{
			// Generate a salt by default to cover the most common use-case, can also be overwritten
			this.Salt = SaltedHash.GenerateSaltString();
		}

		public string GetHashedPassword()
		{
			if(string.IsNullOrEmpty(this.Password))
			{
				throw new InvalidOperationException("You must set the PlainTextPassword property before you can generate a hashed version of the password.");
			}

			return SaltedHash.GenerateSaltedHash(this.Password, this.Salt);
		}

	}
}
