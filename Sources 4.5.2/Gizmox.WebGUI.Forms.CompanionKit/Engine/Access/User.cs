using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web.Configuration;
using System.Diagnostics;

namespace Gizmox.WebGUI.Forms.Access
{
	/// <summary>
	/// Describes a User authorized to operate in CompanionKit
	/// </summary>
	class User
	{
		private string mstrUserName = string.Empty;
		private string mstrPassHash = string.Empty;

		private User(string username, string passhash)
		{
			Debug.Assert(!String.IsNullOrEmpty(username), "The username cannot be empty or null");

			mstrUserName = username;
			mstrPassHash = passhash;
		}
		/// <summary>
		/// Gets or sets the name of the user. Case insensitive.
		/// </summary>
		public string UserName
		{
			get { return mstrUserName; }
			set { mstrUserName = value; }
		}

		/// <summary>
		/// Password hash associated with the user. Case sensitive.
		/// </summary>
		public string PassHash
		{
			get { return mstrPassHash; }
		}

		public static User Create(string username, string password)
		{
			return new User(username, Hash(password));
		}
		
		public static User Init(string username, string hashedpass)
		{
			return new User(username, hashedpass);
		}

		/// <summary>
		/// Hashes the specified input by SHA1 algorithm.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		private static string Hash(string input)
		{
			return FormsAuthentication.HashPasswordForStoringInConfigFile(input, 
					FormsAuthPasswordFormat.SHA1.ToString());
		}

		/// <summary>
		/// Validates the specified password agains hash associated with this user.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns>True/False</returns>
		internal bool Validate(string password)
		{
			return this.mstrPassHash == Hash(password);
		}
	}

	/// <summary>
	/// Associative collection of users by user name
	/// </summary>
	class UserCollection : Dictionary<string, User>
	{
		public UserCollection()
		{
		}

		public UserCollection(int capacity): base(capacity)
		{
		}
	}
}
