using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kingdango.SaltedHashPassword
{
    public static class SaltedHash
	{
	    private const int DefaultSaltLength = 24;

		public static string GenerateSaltString()
		{
			return Convert.ToBase64String(GenerateSalt());
		}

	    public static byte[] GenerateSalt(int length = DefaultSaltLength)
		{
			var csprng = new RNGCryptoServiceProvider();
			var salt = new byte[length];

			csprng.GetBytes(salt);

			return salt;
		}

		public static string GenerateSaltedHash(string valueToHash, string salt)
		{
			return Convert.ToBase64String(GenerateSaltedHash(Encoding.Default.GetBytes(valueToHash), Encoding.Default.GetBytes(salt)));
		}

		public static byte[] GenerateSaltedHash(byte[] valueToHash, byte[] salt)
		{
			HashAlgorithm algorithm = new SHA256Managed();
			
			return algorithm.ComputeHash(valueToHash.Concat(salt).ToArray());
		}

		public static bool AreHashesEqual(string a, string b)
		{
			return AreHashesEqual(Convert.FromBase64String(a), Convert.FromBase64String(b));
		}

		public static bool AreHashesEqual(byte[] a, byte[] b)
		{
			return a.Length == b.Length && a.SequenceEqual(b);
		}
    }
}
