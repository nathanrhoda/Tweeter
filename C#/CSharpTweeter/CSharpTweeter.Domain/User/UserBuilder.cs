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
                    var user = GetUser(userParsed[0]);
                    userList.AddUser(user);
                    foreach (var usersBeingFollowed in userParsed[1].Trim(' ', '\r').Split(','))
                    {
                        var followed = new User
                        {
                            Name = usersBeingFollowed.Trim(' ', '\r')                        
                        };

                        userList.AddUser(followed);
                        AddUsersBeingFollowed(usersBeingFollowed, user);                        
                    }
                }
            }
            return userList;
        }

        private static User GetUser(string userText)
        {
            var user = new User
            { Name = userText.Trim(' ', '\r') };
        
            return user;
        }

        private static User AddUsersBeingFollowed(string usersBeingFollowed, User user)
        {
            var follower = new User
            { Name = usersBeingFollowed.Trim(' ', '\r') };
            user.Following.AddUser(follower);
            return user;
        }
    }
}

