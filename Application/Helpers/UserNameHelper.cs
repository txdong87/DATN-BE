using Domain.Shared.Constants;
using System;
using System.Text.RegularExpressions;

namespace Application.Helpers
{
    public class UserNameHelper
    {
        
        public static bool CheckValidUserName(string fullname,string username)
        {
            var previousUserNameWithoutNumber = Regex.Match(username, @"[a-zA-Z]+").Value;

            return previousUserNameWithoutNumber == GetNewUserNameWithoutNumber(fullname);
        }

        public static string GetNewUserNameWithoutNumber(string fullName)
        {
            

            var nameWordArray = fullName.Split(" ");

            var userName = nameWordArray[0];

            for (int i = 1; i < nameWordArray.Length; i++)
            {
                userName += nameWordArray[i].Substring(0, 1);
            }

            return userName.ToLower();
        }

        public static string GetNewPassword(string userName )
        {
            return userName.ToLower() + "@";
        }
    }
}
