using System;
namespace FirstAmerican.Common
{
	public static class RegularExpressions
	{
		public const string EmailAddress = "^ *[_a-zA-Z0-9-'!#$\\|~\\^-\\{\\}`\\&\\+\\=]+(\\.[_a-zA-Z0-9-'!#$\\|~\\^-\\{\\}`\\&\\+\\=]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name|army)) *$";
		public const string StrongPassword = "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\\W).{8,}$";
		public const string DoesNotContainUriReservedCharacters = "^[^\\\\/=\\+&%#\\?\\<\\>]+$";
	}
}
