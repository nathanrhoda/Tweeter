using System;
using System.Collections.Generic;

namespace CSharpTweeter.Domain
{
    public class UserBuilder
    {
        public static List<User> Create(string users)
        {
            var userList = new List<User>();
            
            foreach (var userText in users.Split('\n'))
            {
                if (!String.IsNullOrEmpty(userText))
                {
                    var user = GetUser(userText);                                        
                    var followers = GetFollowers(userText);
                    foreach (var follower in followers)
                    {
                        if (!user.Followers.Exists(x => x.Equals(follower)))
                        {
                            user.Followers.Add(follower);
                        }
                    }

                    if (!userList.Exists(x => x.Equals(user)))
                    {
                        userList.Add(user);
                    }
                }                
            }
            return userList;
        }

        private static List<User> GetFollowers(string userText)
        {
            var followerList = new List<User>();
            var followersText = userText.Substring(userText.IndexOf(" follows ", StringComparison.Ordinal))
                    .Replace(" follows ", "")
                    .TrimEnd('\r');

            foreach (var follower in followersText.Split(','))
            {
                var user = new User
                {
                    Name = follower
                };
                followerList.Add(user);
            }

            return followerList;

        }

        private static User GetUser(string userText)
        {
            var userString = userText.Substring(0, userText.IndexOf(" follows", StringComparison.Ordinal));
            var user = new User
            {
                Name = userString
            }; 
            return user;
        }
    }   
}

