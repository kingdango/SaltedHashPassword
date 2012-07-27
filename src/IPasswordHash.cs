using System.Runtime.InteropServices;

namespace Kingdango.SaltedHashPassword
{

	[ComVisible(true)]
	[Guid("E7C7FD7B-6AC5-494F-911A-53CD3FE8FB4B")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IPasswordHash
	{
		string Password { get; set; }
		
		string Salt { get; set; }

		string GetHashedPassword();
	}
	
}
