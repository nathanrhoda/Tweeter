using System;
using System.Collections.Generic;

namespace CSharpTweeter.Domain
{
    public class UserBuilder
    {
        public static List<object> Create(string users)
        {
            var userList = new List<object>();
            var followersList = new List<object>();
            
            foreach (var userText in users.Split('\n'))
            {
                if (!String.IsNullOrEmpty(userText))
                {
                    var user = userText.Substring(0, userText.IndexOf(" follows", StringComparison.Ordinal));
                    var followers = userText.Substring(userText.IndexOf(" follows ", StringComparison.Ordinal)).Replace(" follows ", "").TrimEnd('\r');

                    if (!userList.Exists(x => x.Equals(user)))
                    {
                        userList.Add(user);
                    }                    
                }                
            }
            return userList;
        }
    }
}