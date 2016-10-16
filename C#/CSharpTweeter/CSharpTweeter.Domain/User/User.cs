using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTweeter.Domain
{
    public class User
    {
        public User()
        {
            Following = new UserList();
        }
        public string Name { get; set; }
        public UserList Following { get; private set; }



        public override bool Equals(object obj)
        {
            return Name.Equals(((User)obj).Name);
        }
    }

    public class UserList 
    {
        public UserList()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; private set; }


        public User this[int index]
        {
            get { return Users[index]; }            
        }

        public int Count
        {
            get { return Users.Count; }
            
        }
        public void AddUser(User user)
        {
            if (!this.Users.Contains(user))
            {
                this.Users.Add(user);                
            }
        }

        
    }
}
