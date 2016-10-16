using System;
using System.Collections.Generic;

namespace CSharpTweeter.Domain
{
    public class UserBuilder
    {
        public static UserList Create(string users)
        {
            var userList = new UserList();

            foreach (var userText in users.Split('\n'))
            {
                if (!String.IsNullOrEmpty(userText))
                {

                    var userParsed = userText.Replace(" follows ", "|").Split('|');
                    var follower = GetFollower(userParsed[0], userList);

                    foreach (var tweetingUser in userParsed[1].Trim(' ', '\r').Split(','))
                    {
                        var tweeter = GetTweeter(tweetingUser, follower);
                        userList.AddUser(tweeter);
                    }
                }
            }
            return userList;
        }

        private static User GetTweeter(string tweetingUser, User follower)
        {
            var tweeter = new User
            {Name = tweetingUser.Trim(' ', '\r')};

            tweeter.Followers.AddUser(follower);
            return tweeter;
        }

        private static User GetFollower(string userParsed, UserList userList)
        {
            var follower = new User
            {Name = userParsed.Trim(' ', '\r')};
            userList.AddUser(follower);
            return follower;
        }
    }
}

