using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpTweeter.Domain
{
    public class UserService
    {        
        private string _userFilePath;

        public UserService(string userFilePath)
        {
            if (!File.Exists(userFilePath))
            {
                throw new FileNotFoundException(string.Format("File does not exist {0}", userFilePath));
            }
            this._userFilePath = userFilePath;                        
        }
                
        public UserList GetUsers()
        {
            var fileText = File.ReadAllText(_userFilePath);
            return UserBuilder.Create(fileText);
        }
        
     
    }
}
