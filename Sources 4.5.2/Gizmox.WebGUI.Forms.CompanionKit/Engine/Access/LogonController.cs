using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;

namespace Gizmox.WebGUI.Forms.Access
{
	/// <summary>
	/// Class handles logic to load, manage and authorize Admin users
	/// </summary>
	internal class LogonController
	{
		/// <summary>
		/// Collection of available Admin users 
		/// </summary>
		private static UserCollection mobjUsers = new UserCollection();

		static LogonController()
		{
			LoadUsers();
		}

		/// <summary>
		/// Load collection of registered users from configuration.
		/// </summary>
		private static void LoadUsers()
		{
			mobjUsers.Clear();
			
			string strAdmin = ConfigurationManager.AppSettings["Administrator"];
			
			// Default user: Admin pass: Admin
			// to create new one goto: http://www.xorbin.com/tools/sha1-hash-calculator
			User objAdmin = User.Create("Admin", "4E7AFEBCFBAE000B22C7C85E5560F89A2A0280B4");

			if (!String.IsNullOrEmpty(strAdmin) && strAdmin.Contains(","))
			{
				string[] parts = strAdmin.Split(new char[]{','});
				if (parts.Length == 2)
				{
					objAdmin = User.Init(parts[0].Trim(),parts[1].Trim());
				}
			}

			mobjUsers[objAdmin.UserName.ToLowerInvariant()] = objAdmin;
		}

		/// <summary>
		/// Fetch the user and validate the password provided
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns>User object if validated successfully, otherwise NULL</returns>
		internal static User Validate(string username, string password)
		{
			User objUser = null;
			
			if (mobjUsers.ContainsKey(username.ToLowerInvariant()) )
			{
				objUser = mobjUsers[username.ToLowerInvariant()];
				if(!objUser.Validate(password))
					objUser = null;
			}

			return objUser;
		}
	}
}
